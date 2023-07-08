using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tbcomm.msg.common;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace chattingApp
{
    public partial class chatRoom : Form
    {
        private TcpClient _client;
        private CsChatServer _server;
        public chatRoom()
        {
            InitializeComponent();

            //BtnSendMsg.Click += BtnSendMsg_Click;

            //TxtMessage.KeyDown += TxtMessage_KeyDown;
        }

        public async Task HandleClient(TcpClient client)
        {
            NetworkStream stream = client.GetStream();

            byte[] buffer = new byte[1024];

            while (true)
            {
                int read = await stream.ReadAsync(buffer, 0, buffer.Length);
                if (read <= 0)
                    break;

                String message = Encoding.UTF8.GetString(buffer, 0, read);

                //ListViewItem item = new ListViewItem();
                //item.SubItems.Add(message.ToString());
                MsgList.Items.Add(message);
            }

        }

        private async void BtnSendMsg_Click(object sender, EventArgs e)
        {
            _server = new CsChatServer();
            _client = new TcpClient();
            await _client.ConnectAsync(IPAddress.Parse("127.0.0.1"), 8080);
            _ = HandleClient(_client);

            
            
            NetworkStream stream = _client.GetStream();

            string text = TxtMessage.Text;
            var messageBuffer = Encoding.UTF8.GetBytes(text);

            var msgLengthBuffer = BitConverter.GetBytes(messageBuffer.Length);

            for(int i = 0; i < 100; i++)
            {
                stream.Write(msgLengthBuffer, 0, msgLengthBuffer.Length);
                stream.Write(messageBuffer, 0, messageBuffer.Length);
            }

            //byte[] buffer = new byte[1024];
            //int read = await stream.ReadAsync(messageBuffer, 0, messageBuffer.Length);


            //String message = Encoding.UTF8.GetString(buffer, 0, read);
            //MessageBox.Show(message);
            ////TxtMessage.Clear();
        }


        private void TxtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            TxtMessage.Clear();
        }

    }
}
