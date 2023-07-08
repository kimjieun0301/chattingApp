using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using System.Security.Cryptography.X509Certificates;
using System.Drawing.Text;

namespace chattingApp
{
    public class CsChatServer
    {
        private TcpListener _listener;
        public CsChatServer()
        {
            _ = ChatServer();

        }
        public async Task ChatServer()
        {
            _listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 8080);
            _listener.Start();

            while(true)
            {
                TcpClient client = await _listener.AcceptTcpClientAsync();

                _ = HandleClient(client);
            }
        }

        public async Task HandleClient(TcpClient client)
        {
            NetworkStream stream = client.GetStream();

            byte[] sizeBuffer = new byte[4];
            int read;
            while (true)
            {
                read = await stream.ReadAsync(sizeBuffer, 0, sizeBuffer.Length);
                if (read <= 0)
                    break;
                int size = BitConverter.ToInt32(sizeBuffer, 0);
                byte[] buffer = new byte[size];

                read = await stream.ReadAsync(buffer, 0, buffer.Length);
                if (read <= 0)
                    break;
                String message = Encoding.UTF8.GetString(buffer, 0, read);

                var messageBuffer = Encoding.UTF8.GetBytes($"Server : {message}");
                stream.Write(messageBuffer, 0, messageBuffer.Length);
            }

        }
    }
}
