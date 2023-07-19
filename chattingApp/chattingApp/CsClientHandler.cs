using chattingLib;
using System.Net.Sockets;
using System.Text;

namespace chattingApp
{
    public class CsClientHandler
    {
        #region init
        private readonly TcpClient _client;
        private readonly NetworkStream _stream;
        public CsChatting chatForm = new CsChatting();
        public CsClientHandler(TcpClient client)
        {
            _client = client;
            _stream = client.GetStream();
        }
        #endregion

        #region 서버에게 자신의 id 전송
        public void Send_id()
        {
            try
            {
                string id = CurrentMem.Instance.User.mem_id;

                byte[] idBuffer = Encoding.UTF8.GetBytes(id);
                byte[] idLengthBuffer = BitConverter.GetBytes(idBuffer.Length);

                string type = "Cid";
                var typeBuffer = Encoding.UTF8.GetBytes(type);


                _stream.Write(typeBuffer, 0, typeBuffer.Length);
                _stream.Write(idLengthBuffer, 0, idLengthBuffer.Length);
                _stream.Write(idBuffer, 0, idBuffer.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"서버에게 id 전송 중 오류 발생: {ex.Message}");
            }
        }
        #endregion

        #region 클라이언트 핸들러(서버에서 메세지 받기)
        public async Task HandleClientAsync()
        {
            byte[] sizeBuffer = new byte[4];
            int read;
            try
         {
                while (true)
                {
                    read = await _stream.ReadAsync(sizeBuffer, 0, sizeBuffer.Length);
                    if (read <= 0)
                        break;

                    int size = BitConverter.ToInt32(sizeBuffer);
                    byte[] buffer = new byte[size];

                    read = await _stream.ReadAsync(buffer, 0, buffer.Length);
                    if (read <= 0)
                        break;

                    string message = Encoding.UTF8.GetString(buffer, 0, read);
                    chatForm = CsChatting.Parse(message);
                    chatRoom.chatRoom1.listview_print(chatForm);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"메시지 전송 오류 발생: {ex.Message}");
            }
            finally
            {
                _client.Close();
            }
        }
        #endregion

        #region 서버에게 메세지 전송
        public void Send(CsChatting hub)
        {
            try
            {
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
                MessageBox.Show($"메세지 전송 중 오류 발생: {ex.Message}");
            }
        }
        #endregion

        #region 소켓닫기
        public void AppExit()
        {
            _client?.Dispose();
        }
        #endregion
    }
}
