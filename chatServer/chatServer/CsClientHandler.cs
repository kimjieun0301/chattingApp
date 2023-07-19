using chattingLib;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace chatServer
{
    public class CsClientHandler
    {
        #region init
        private OleDbConnection LocalConn;
        private readonly TcpClient _client;
        private readonly NetworkStream _stream;
        bool initialFlag = true;
        string receivedPath = string.Empty;
        public CsChatting chatForm = new CsChatting();
        private static ConcurrentDictionary<string, TcpClient> clientDictionary = new ConcurrentDictionary<string, TcpClient>();
        public CsClientHandler(TcpClient client)
        {
            _client = client;
            _stream = client.GetStream();
        }
        #endregion

        #region 연결된 클라이언트의 memId 받아오기
        public async Task Recieve_id(TcpClient client1)
        {
            byte[] sizeBuffer = new byte[4];
            int read;
            NetworkStream _stream1 = client1.GetStream();
            read = await _stream1.ReadAsync(sizeBuffer, 0, sizeBuffer.Length);
            if (read <= 0)
                Console.WriteLine($"클라이언트로 ID 전송 중 오류 발생");
            int size = BitConverter.ToInt32(sizeBuffer);
            byte[] idbuffer = new byte[size];

            read = await _stream1.ReadAsync(idbuffer, 0, idbuffer.Length);
            if (read <= 0)
                Console.WriteLine($"클라이언트로 ID 전송 중 오류 발생");

            String clientId = Encoding.UTF8.GetString(idbuffer, 0, read);
            if (!clientDictionary.ContainsKey(clientId))
            {
                clientDictionary.TryAdd(clientId, client1);
            }
            else
            {
                Console.WriteLine($"중복된 클라이언트 ID: {clientId}");
            }
        }
        #endregion

        #region 클라이언트로부터 받은 데이터 처리
        public async Task<CsChatting> HandleClientAsync()
        {
            try
            {
                int fileNameLen = 0;
                byte[] sizeBuffer = new byte[4];
                byte[] statebuffer = new byte[3];
                byte[] imgbuffer = new byte[4096];
                int read;
                while (true)
                {
                    read = await _stream.ReadAsync(statebuffer, 0, statebuffer.Length);
                    if (read <= 0)
                        break;
                    String dataType = Encoding.UTF8.GetString(statebuffer, 0, read);
                    if (initialFlag)
                    {
                        if (Equals(dataType, "Cid"))
                        {
                            Recieve_id(_client);
                        }
                        else if (Equals(dataType, "img"))
                        {
                            read = await _stream.ReadAsync(imgbuffer, 0, imgbuffer.Length);
                            if (read <= 0)
                                break;
                            _ = BitConverter.ToInt32(imgbuffer, 0);
                            fileNameLen = BitConverter.ToInt32(imgbuffer, 0);
                            string fileName = Encoding.UTF8.GetString(imgbuffer, 4, fileNameLen);

                            string pathUser = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                            string pathDownload = Path.Combine(pathUser, "Downloads");

                            receivedPath = Path.Combine(pathDownload, fileName);

                            if (File.Exists(receivedPath))
                                File.Delete(receivedPath);
                        }
                        else
                        {
                            read = await _stream.ReadAsync(sizeBuffer, 0, sizeBuffer.Length);
                            if (read <= 0)
                                break;
                            int size = BitConverter.ToInt32(sizeBuffer, 0);
                            byte[] buffer = new byte[size];

                            read = await _stream.ReadAsync(buffer, 0, buffer.Length);
                            if (read <= 0)
                                break;
                            String message = Encoding.UTF8.GetString(buffer, 0, read);

                            CsMessage CsMessage = new CsMessage();
                            chatForm = CsChatting.Parse(message);
                            CsMessage.creaste_ChtMsg(chatForm);
                            Send(chatForm, chatForm.RoomId);

                            FrmServer.frmServer.listview_print(chatForm);
                        }
                    }
                    if (Equals(dataType, "img"))
                    {
                        read = await _stream.ReadAsync(sizeBuffer, 0, sizeBuffer.Length);
                        if (read <= 0)
                            break;
                        int fileDataLength = BitConverter.ToInt32(sizeBuffer, 0);
                        string fileName = receivedPath;
                        using (FileStream fs = new FileStream(fileName, FileMode.Append, FileAccess.Write))
                        {
                            byte[] buffer = new byte[4096];
                            int bytesRead;
                            int totalBytesRead = 0;

                            while (totalBytesRead < fileDataLength && (bytesRead = await _stream.ReadAsync(buffer, 0, Math.Min(buffer.Length, fileDataLength - totalBytesRead))) > 0)
                            {
                                await fs.WriteAsync(buffer, 0, bytesRead);
                                totalBytesRead += bytesRead;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"클라이언트로 메세지 전송 중 오류 발생: {ex.Message}");
            }
            return chatForm;
        }
        #endregion

        #region RoomId로 해당 방에 접속한 클라이언트들의 memId 받아오기
        private List<string> GetClientsInRoom(int roomId)
        {
            List<string> roomId_memId = new List<string>();

            try
            {
                OleDbDataReader myReader;
                LocalConn = Common_DB.DBConnection();
                LocalConn.Open();
                string sql = "SELECT MEM_ID FROM INGCHAT WHERE RM_ID = '" + roomId + "'";

                OleDbCommand command = new OleDbCommand(sql, LocalConn);

                myReader = command.ExecuteReader();

                while (myReader.Read())
                {
                    string value = myReader["MEM_ID"].ToString();
                    roomId_memId.Add(value);
                }

                myReader.Close();
                LocalConn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            return roomId_memId;
        }
        #endregion

        #region 클라이언트로 메시지 전송
        private void Send(CsChatting hub, int roomId)
        {
            List<string> roomClients = GetClientsInRoom(roomId);
            foreach (string memId in roomClients)
            {
                if (clientDictionary.ContainsKey(memId))
                {
                    TcpClient client = clientDictionary[memId];
                    NetworkStream stream = client.GetStream();
                    byte[] buffer = Encoding.UTF8.GetBytes(hub.ToJsonString());
                    byte[] lengthBuffer = BitConverter.GetBytes(buffer.Length);
                    try
                    {
                        stream.Write(lengthBuffer);
                        stream.Write(buffer);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"메시지 전송 중 오류 발생: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine($"클라이언트 {memId}가 접속되어 있지 않습니다.");
                }
            }
        }
        #endregion
    }
}
