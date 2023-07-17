using chattingLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Net.Sockets;

namespace chatServer
{
    public class CsSendEachRm
    {
        //private ConcurrentDictionary<int, List<CsClientHandler>> _roomHandlersDict;
        Dictionary<int, List<TcpClient>> roomClients = new Dictionary<int, List<TcpClient>>();

        public CsSendEachRm()
        {
            //_roomHandlersDict = new ConcurrentDictionary<int, List<CsClientHandler>>();
        }

        public void Add(int roomId, TcpClient client)
        {
            if (roomClients.ContainsKey(roomId))
            {
                roomClients[roomId].Add(client);
            }
            else
            {
                roomClients[roomId] = new List<TcpClient>() { client };
            }
        }

        public void SendToEahcRoom(int roomId, CsChatting chatForm)
        {
            if (roomClients.TryGetValue(roomId, out List<TcpClient> clients))
            {
                foreach (TcpClient client in clients)
                {
                    NetworkStream stream = client.GetStream();

                    try
                    {
                        byte[] buffer = Encoding.UTF8.GetBytes(chatForm.ToJsonString());
                        byte[] lengthBuffer = BitConverter.GetBytes(buffer.Length);

                        stream.Write(lengthBuffer);
                        stream.Write(buffer); //메세지 전송은 read가 아닌 write 사용
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"클라이언트로 메세지 전송 중 오류 발생: {ex.Message}");
                    }
                }
            }
        }

















        //public void Add(int roomId, CsClientHandler handler)
        //{
        //    _roomHandlersDict.AddOrUpdate(roomId, new List<CsClientHandler>() { handler }, (_, handlers) =>
        //    {
        //        handlers.Add(handler);
        //        return handlers;
        //    });
        //}

        //public void SendToEahcRoom(CsChatting chatForm)
        //{
        //    if (_roomHandlersDict.TryGetValue(chatForm.RoomId, out List<CsClientHandler> roomHandlers))
        //    {
        //        foreach (CsClientHandler handler in roomHandlers)
        //        {
        //            handler.Send(chatForm);
        //        }
        //    }
        //}











        //private Dictionary<int, List<CsClientHandler>> _roomHandlersDict = new();
        //public void Add(CsClientHandler clientHandler, int roomId)
        //{
        //    //int roomId = clientHandler.Send.RoomId;

        //    if (_roomHandlersDict.TryGetValue(roomId, out _))
        //    {
        //        _roomHandlersDict[roomId].Add(clientHandler);
        //    }
        //    else
        //    {
        //        _roomHandlersDict[roomId] = new List<CsClientHandler>() { clientHandler };
        //    }
        //}

        //public void Remove(CsClientHandler clientHandler, int roomId)
        //{
        //    //int roomId = clientHandler.InitialData!.RoomId;

        //    if (_roomHandlersDict.TryGetValue(roomId, out List<CsClientHandler>? roomHandlers))
        //    {
        //        _roomHandlersDict[roomId] = roomHandlers.FindAll(handler => !handler.Equals(clientHandler));
        //    }
        //}

        //public void SendToEahcRoom(CsChatting chatForm)
        //{
        //    if (_roomHandlersDict.TryGetValue(chatForm.RoomId, out List<CsClientHandler>? roomHandlers))
        //    {
        //        roomHandlers.ForEach(handler => handler.Send(chatForm));
        //    }
        //}
    }
}
