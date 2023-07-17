using chattingLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using tbcomm.comm;

namespace chatServer
{
    public class CsClientHandler
    {
        private OleDbConnection LocalConn;
        private readonly TcpClient _client;
        private readonly NetworkStream _stream;
        private readonly Dictionary<string, TcpClient> clientDictionary;
        bool initialFlag = true;
        string receivedPath = string.Empty;
        public CsChatting chatForm = new CsChatting();
        //CsClientHandler CsClientHandler1 { get; set; }
        //Dictionary<int, List<CsClientHandler>> roomHandlersDict = new Dictionary<int, List<CsClientHandler>>();

        private bool isFirstClientConnected = false;
        public CsClientHandler(TcpClient client, Dictionary<string, TcpClient> _clientDictionary)
        {
            _client = client;
            _stream = client.GetStream(); //getstream을 이용하여 네트워크의 스트림을 가져옴
            clientDictionary= _clientDictionary;
        }


        public async Task<CsChatting> HandleClientAsync()
        {
            //byte[] sizeBuffer = new byte[4]; //길이는 int형이라 버퍼크기 4byte 로 설정
            //int read;

            //try
            //{
            //    while (true)
            //    {
            //        read = await _stream.ReadAsync(sizeBuffer, 0, sizeBuffer.Length);
            //        if (read == 0) //read값이 0이면 중단= 비정상 동작
            //            break;

            //        int size = BitConverter.ToInt32(sizeBuffer); //연속적인 메세지에 대한 오류 때문에 문자열 길이 bitconverter이용해서 int로 저장
            //        byte[] buffer = new byte[size]; //해당 size만큼 byte형 배열 버퍼를 생성.

            //        read = await _stream.ReadAsync(buffer, 0, buffer.Length); //임의의 버퍼 넣어줌 0부터 버퍼사이즈까지 읽기(비동기로 읽음)
            //        if (read == 0)//read값이 0이면 중단= 비정상 동작
            //            break;

            //        string message = Encoding.UTF8.GetString(buffer, 0, read); //버퍼를 텍스트(스트링)로 변환(인코딩)

            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"클라이언트 요청 처리 중 오류 발생: {ex.Message}");
            //}
            //finally
            //{
            //    _client.Close();
            //    //Disconnected?.Invoke(this, new ChatEventArgs(this, InitialData!));
            //}




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
                    //dataType = BitConverter.ToInt32(statebuffer, 0);
                    String dataType = Encoding.UTF8.GetString(statebuffer, 0, read);
                    if (initialFlag)
                    {
                        if (Equals(dataType, "Cid"))
                        {
                           //Recieve_id();
                        }
                        else if(Equals(dataType, "img"))
                        {
                            read = await _stream.ReadAsync(imgbuffer, 0, imgbuffer.Length);
                            _ = BitConverter.ToInt32(imgbuffer, 0);
                            fileNameLen = BitConverter.ToInt32(imgbuffer, 0);
                            string fileName = Encoding.UTF8.GetString(imgbuffer, 4, fileNameLen);

                            string pathUser = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                            string pathDownload = Path.Combine(pathUser, "Downloads");

                            receivedPath = Path.Combine(pathDownload, fileName);

                            if (File.Exists(receivedPath))
                                File.Delete(receivedPath);
                        }
                        else //if (Equals(dataType, "txt"))// (dataType == (int)DataPacketType.TEXT)
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
                            //CsSendEachRm CsSendEachRm = new CsSendEachRm();
                            //CsSendEachRm.Add(chatForm.RoomId, _client);
                            //CsSendEachRm.SendToEahcRoom(chatForm.RoomId, chatForm);
                            //FrmServer frmServer = new FrmServer();
                            FrmServer.frmServer.listview_print(chatForm);
                            //LvChkServer.Items.Add($"{chatForm.MemId},{chatForm.RoomId},{chatForm.MemName},{chatForm.Message}");
                            //Txtcount.Text = LvChkServer.Items.Count.ToString();

                            //var messageBuffer = Encoding.UTF8.GetBytes($"Server : {message}");
                            //stream.Write(messageBuffer, 0, messageBuffer.Length);
                        }

                    }
                    if (Equals(dataType, "img"))// (dataType == (int)DataPacketType.IMAGE)
                    {
                        read = await _stream.ReadAsync(sizeBuffer, 0, sizeBuffer.Length);
                        int bytesRead = 107070;//BitConvertser.ToInt32(sizeBuffer, 0);
                                               //int bytesRead = await client.GetStream().ReadAsync(sizeBuffer, 0, sizeBuffer.Length);
                        BinaryWriter bw = new BinaryWriter(File.Open(receivedPath, FileMode.Append));
                        if (initialFlag)
                            bw.Write(imgbuffer, 4 + fileNameLen, bytesRead - (4 + fileNameLen));
                        else
                            bw.Write(imgbuffer, 0, bytesRead);

                        initialFlag = false;
                        bw.Close();
                        await _stream.ReadAsync(imgbuffer, 0, bytesRead); //(statebuffer, 0, bytesRead, 0, new AsyncCallback(HandleClient), state);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"클라이언트로 메세지 전송 중 오류 발생: {ex.Message}");
            }
            return chatForm;
        }

        private List<string> GetClientsInRoom(int roomId)
        {
            //List<string> roomId_memId = new List<string>();

            //try
            //{
            //    string sql = "SELECT MEM_ID FROM INGCHAT WHERE RM_ID = '" + roomId + "'";
            //    OleDbDataReader myReader = Common_DB.DataSelect(sql, LocalConn);

            //    while (myReader.Read())
            //    {
            //        roomId_memId.Add(myReader["MEM_ID"].ToString());
            //    }

            //    myReader.Close();
            //}
            //catch (Exception e)
            //{
            //    MessageBox.Show(e.ToString(), "Error!");
            //}
            List<string> roomId_memId = new List<string>();

            try
            {
                OleDbDataReader myReader;
                LocalConn = Common_DB.DBConnection();
                LocalConn.Open();
                string sql = "SELECT MEM_ID FROM INGCHAT WHERE RM_ID = '" + roomId + "'";

                // 데이터베이스 연결 및 쿼리 실행
               // OleDbConnection connection = new OleDbConnection(LocalConn);
                OleDbCommand command = new OleDbCommand(sql, LocalConn);
                //LocalConn.Open();
                myReader = command.ExecuteReader();
               // OleDbDataReader myReader = Common_DB.DataSelect(sql, LocalConn);

                // 결과 값 반복하여 List에 추가
                while (myReader.Read())
                {
                    string value = myReader["MEM_ID"].ToString();
                    roomId_memId.Add(value);
                }

                myReader.Close();
                LocalConn.Close();
                // connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            // 결과 값을 확인
            foreach (string value in roomId_memId)
            {
                Console.WriteLine(value);
            }

            return roomId_memId;
        }

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
                        _stream.Write(lengthBuffer);
                        _stream.Write(buffer); //메세지 전송은 read가 아닌 write 사용
                        // 전송 성공
                    }
                    catch (Exception ex)
                    {
                        // 전송 실패 처리
                        Console.WriteLine($"메시지 전송 중 오류 발생: {ex.Message}");
                    }
                }
                else
                {
                    // 클라이언트가 접속되어 있지 않음
                    Console.WriteLine($"클라이언트 {memId}가 접속되어 있지 않습니다.");
                }
            }
        }

        //8번 추출한 room id 를 ingChat 테이블에서 select해서
        //추출한 room id를 찾아서 해당 room id와 매핑이 되어있는 여러 개의 memid와 dictionar
        //public void Send(CsChatting hub, int roomId)
        //{
        //    try
        //    {
        //        List<string> roomClients = GetClientsInRoom(roomId);
        //        foreach (TcpClient roomClient in roomClients)
        //        {
        //            byte[] messageBuffer = Encoding.UTF8.GetBytes(receivedMessage);
        //            roomClient.GetStream().Write(messageBuffer, 0, messageBuffer.Length);
        //        }

        //        byte[] buffer = Encoding.UTF8.GetBytes(hub.ToJsonString());
        //        byte[] lengthBuffer = BitConverter.GetBytes(buffer.Length);

        //        _stream.Write(lengthBuffer);
        //        _stream.Write(buffer); //메세지 전송은 read가 아닌 write 사용
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"클라이언트로 메세지 전송 중 오류 발생: {ex.Message}");
        //    }
        //}
    }

    //public async void Send(CsChatting hub)
    //{
    //    try
    //    {
    //        //var messageBuffer = Encoding.UTF8.GetBytes(hub.ToJsonString());

    //        //string type = "txt";
    //        //var typeBuffer = Encoding.UTF8.GetBytes(type);

    //        //var msgLengthBuffer = BitConverter.GetBytes(messageBuffer.Length);

    //        //_stream.Write(typeBuffer, 0, typeBuffer.Length);
    //        //_stream.Write(msgLengthBuffer, 0, msgLengthBuffer.Length);
    //        //_stream.Write(messageBuffer, 0, messageBuffer.Length);


    //        //NetworkStream stream = client.GetStream();

    //        int fileNameLen = 0;
    //        byte[] sizeBuffer = new byte[4];
    //        byte[] statebuffer = new byte[3];
    //        byte[] imgbuffer = new byte[4096];
    //        int read;
    //        while (true)
    //        {
    //            read = await _stream.ReadAsync(statebuffer, 0, statebuffer.Length);
    //            //dataType = BitConverter.ToInt32(statebuffer, 0);
    //            String dataType = Encoding.UTF8.GetString(statebuffer, 0, read);
    //            if (initialFlag)
    //            {
    //                if (Equals(dataType, "img"))
    //                {
    //                    read = await _stream.ReadAsync(imgbuffer, 0, imgbuffer.Length);
    //                    _ = BitConverter.ToInt32(imgbuffer, 0);
    //                    fileNameLen = BitConverter.ToInt32(imgbuffer, 0);
    //                    string fileName = Encoding.UTF8.GetString(imgbuffer, 4, fileNameLen);

    //                    string pathUser = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
    //                    string pathDownload = Path.Combine(pathUser, "Downloads");

    //                    receivedPath = Path.Combine(pathDownload, fileName);

    //                    if (File.Exists(receivedPath))
    //                        File.Delete(receivedPath);
    //                }
    //                else if (Equals(dataType, "txt"))// (dataType == (int)DataPacketType.TEXT)
    //                {
    //                    read = await _stream.ReadAsync(sizeBuffer, 0, sizeBuffer.Length);
    //                    if (read <= 0)
    //                        break;
    //                    int size = BitConverter.ToInt32(sizeBuffer, 0);
    //                    byte[] buffer = new byte[size];

    //                    read = await _stream.ReadAsync(buffer, 0, buffer.Length);
    //                    if (read <= 0)
    //                        break;
    //                    String message = Encoding.UTF8.GetString(buffer, 0, read);

    //                    CsMessage CsMessage = new CsMessage();
    //                    var chatForm = CsChatting.Parse(message);
    //                    CsMessage.creaste_ChtMsg(chatForm);
    //                    //LvChkServer.Items.Add($"{chatForm.MemId},{chatForm.RoomId},{chatForm.MemName},{chatForm.Message}");
    //                    //Txtcount.Text = LvChkServer.Items.Count.ToString();

    //                    //var messageBuffer = Encoding.UTF8.GetBytes($"Server : {message}");
    //                    //stream.Write(messageBuffer, 0, messageBuffer.Length);
    //                }

    //            }
    //            if (Equals(dataType, "img"))// (dataType == (int)DataPacketType.IMAGE)
    //            {
    //                read = await _stream.ReadAsync(sizeBuffer, 0, sizeBuffer.Length);
    //                int bytesRead = 107070;//BitConverter.ToInt32(sizeBuffer, 0);
    //                                       //int bytesRead = await client.GetStream().ReadAsync(sizeBuffer, 0, sizeBuffer.Length);
    //                BinaryWriter bw = new BinaryWriter(File.Open(receivedPath, FileMode.Append));
    //                if (initialFlag)
    //                    bw.Write(imgbuffer, 4 + fileNameLen, bytesRead - (4 + fileNameLen));
    //                else
    //                    bw.Write(imgbuffer, 0, bytesRead);

    //                initialFlag = false;
    //                bw.Close();
    //                await _stream.ReadAsync(imgbuffer, 0, bytesRead); //(statebuffer, 0, bytesRead, 0, new AsyncCallback(HandleClient), state);
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Console.WriteLine($"클라이언트로 메세지 전송 중 오류 발생: {ex.Message}");
    //    }
    //}
    //}
}
