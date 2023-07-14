using chattingLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace chattingApp
{
    public class CsClientHandler
    {
        private readonly TcpClient _client;
        private readonly NetworkStream _stream;

        public CsClientHandler(TcpClient client)
        {
            _client = client;
            _stream = client.GetStream(); //getstream을 이용하여 네트워크의 스트림을 가져옴
        }

        public async Task HandleClientAsync()
        {
            byte[] sizeBuffer = new byte[4]; //길이는 int형이라 버퍼크기 4byte 로 설정
            int read;

            try
            {
                while (true)
                {
                    read = await _stream.ReadAsync(sizeBuffer, 0, sizeBuffer.Length);
                    if (read == 0) //read값이 0이면 중단= 비정상 동작
                        break;

                    int size = BitConverter.ToInt32(sizeBuffer); //연속적인 메세지에 대한 오류 때문에 문자열 길이 bitconverter이용해서 int로 저장
                    byte[] buffer = new byte[size]; //해당 size만큼 byte형 배열 버퍼를 생성.

                    read = await _stream.ReadAsync(buffer, 0, buffer.Length); //임의의 버퍼 넣어줌 0부터 버퍼사이즈까지 읽기(비동기로 읽음)
                    if (read == 0)//read값이 0이면 중단= 비정상 동작
                        break;

                    string message = Encoding.UTF8.GetString(buffer, 0, read); //버퍼를 텍스트(스트링)로 변환(인코딩)

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"클라이언트 요청 처리 중 오류 발생: {ex.Message}");
            }
            finally
            {
                _client.Close();
                //Disconnected?.Invoke(this, new ChatEventArgs(this, InitialData!));
            }
        }

        public void Send(CsChatting hub)
        {
            try
            {
                //byte[] buffer = Encoding.UTF8.GetBytes(hub.ToJsonString());
                //byte[] lengthBuffer = BitConverter.GetBytes(buffer.Length);

                //_stream.Write(lengthBuffer);
                //_stream.Write(buffer); //메세지 전송은 read가 아닌 write 사용

                var messageBuffer = Encoding.UTF8.GetBytes(hub.ToJsonString());

                string type = "txt";
                var typeBuffer = Encoding.UTF8.GetBytes(type);

                var msgLengthBuffer = BitConverter.GetBytes(messageBuffer.Length);

                _stream.Write(typeBuffer, 0, typeBuffer.Length);
                _stream.Write(msgLengthBuffer, 0, msgLengthBuffer.Length);
                _stream.Write(messageBuffer, 0, messageBuffer.Length);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"클라이언트로 메세지 전송 중 오류 발생: {ex.Message}");
            }
        }
    }
}
