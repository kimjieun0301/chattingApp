using chattingLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace chattingApp
{
    public class CsChatClient
    {
        private TcpClient? _client;
        protected readonly IPAddress IPAddress;
        protected readonly int Port;
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

        public CsChatClient(IPAddress iPAddress, int port)
        {
            IPAddress = iPAddress;
            Port = port;
        }

        public async Task<TcpClient> ConnectAsync(CsChatting details)
        {
            try
            {
                _client = new TcpClient(); //클라이언트 객체
                await _client.ConnectAsync(IPAddress, Port); //연결하는 부분, 비동기 connect사용 내가 만든 서버의 아이피랑 포트 입력해주기

                CsChatting hub = ConvertChatHub(details);
                CsClientHandler clientHandler = new CsClientHandler(_client); //송수신 부분 서버에서 주는 채팅도 받아야되니까
                //Connected?.Invoke(this, new ChatEventArgs(clientHandler, hub));
                //clientHandler.Disconnected += ClientHandler_Disconnected;
                //clientHandler.Received += Received;

                _ = clientHandler.HandleClientAsync();
               // clientHandler?.Send(hub);
                
            }
            catch (Exception ex)
            {
                //DisposeClient();
                //Debug.Print($"서버 연결 시도 중 오류 발생: {ex.Message}");
            }
            return _client;
        }

        //private void DisposeClient()
        //{
        //    _client?.Dispose();
        //}

        //private void ClientHandler_Disconnected(object? sender, ChatEventArgs e)
        //{
        //    DisposeClient();
        //    Disconnected?.Invoke(sender, e);
        //}

        //public void Close()
        //{
        //    DisposeClient();
        //}
    }
}
