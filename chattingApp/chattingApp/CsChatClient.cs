using chattingLib;
using System.Net;
using System.Net.Sockets;


namespace chattingApp
{
    public class CsChatClient
    {
        #region init
        private TcpClient? _client;
        protected readonly IPAddress IPAddress;
        protected readonly int Port;
        #endregion

        #region 채팅폼에서 사용할 변수
        private CsChatting ConvertChatHub(CsChatting details)
        {
            return new CsChatting
            {
                MemId = details.MemId,
                RoomId = details.RoomId,
                MemName = details.MemName,
                Message = details.Message,
            };
        }
        #endregion

        #region ip,port 설정
        public CsChatClient(IPAddress iPAddress, int port)
        {
            IPAddress = iPAddress;
            Port = port;
        }
        #endregion

        #region 서버 연결
        public async Task<TcpClient> ConnectAsync(CsChatting details)
        {
            try
            {
                _client = new TcpClient();
                await _client.ConnectAsync(IPAddress, Port);
                CsChatting hub = ConvertChatHub(details);
                CsClientHandler clientHandler = new CsClientHandler(_client);

                _ = clientHandler.HandleClientAsync();             
            }
            catch (Exception ex)
            {
                MessageBox.Show("서버 연결 시도 중 오류 발생:" + ex.Message);
            }
            return _client;
        }
        #endregion
    }
}
