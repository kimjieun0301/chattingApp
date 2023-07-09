using chattingLib;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace chatServer
{
    public partial class FrmServer : Form
    {
        #region init
        private TcpListener _listener;
        bool initialFlag = true;
        string receivedPath = string.Empty;
        enum DataPacketType { TEXT = 1, IMAGE };
        //int dataType = 0;
        string textData = string.Empty;
        public FrmServer()
        {
            InitializeComponent();
        }
        #endregion

        #region 채팅 서버 시작
        private async void BtnListen_Click(object sender, EventArgs e)
        {
            _listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 8080);
            _listener.Start();
            initialFlag = true;
            while (true)
            {
                TcpClient client = await _listener.AcceptTcpClientAsync();

                _ = HandleClient(client);
            }
        }
        #endregion

        #region 클라이언트 핸들러
        public async Task HandleClient(TcpClient client)
        {
            NetworkStream stream = client.GetStream();

            int fileNameLen = 0;
            byte[] sizeBuffer = new byte[4];
            byte[] statebuffer = new byte[3];
            byte[] imgbuffer = new byte[4096];
            int read;
            while (true)
            {
                read = await stream.ReadAsync(statebuffer, 0, statebuffer.Length);
                //dataType = BitConverter.ToInt32(statebuffer, 0);
                String dataType = Encoding.UTF8.GetString(statebuffer, 0, read);
                if (initialFlag)
                {
                    if (Equals(dataType, "img"))
                    {
                        read = await stream.ReadAsync(imgbuffer, 0, imgbuffer.Length);
                        _ = BitConverter.ToInt32(imgbuffer, 0);
                        fileNameLen = BitConverter.ToInt32(imgbuffer, 0);
                        string fileName = Encoding.UTF8.GetString(imgbuffer, 4, fileNameLen);

                        string pathUser = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                        string pathDownload = Path.Combine(pathUser, "Downloads");

                        receivedPath = Path.Combine(pathDownload, fileName);

                        if (File.Exists(receivedPath))
                            File.Delete(receivedPath);
                    }
                    else if (Equals(dataType, "txt"))// (dataType == (int)DataPacketType.TEXT)
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

                        var chatForm = CsChatting.Parse(message);
                        LvChkServer.Items.Add($"{chatForm.MemId},{chatForm.RoomId},{chatForm.MemName},{chatForm.Message}");

                        Txtcount.Text = LvChkServer.Items.Count.ToString();

                        var messageBuffer = Encoding.UTF8.GetBytes($"Server : {message}");
                        stream.Write(messageBuffer, 0, messageBuffer.Length);
                    }

                }
                if (Equals(dataType, "img"))// (dataType == (int)DataPacketType.IMAGE)
                {
                    read = await stream.ReadAsync(sizeBuffer, 0, sizeBuffer.Length);
                    int bytesRead = 107070;//BitConverter.ToInt32(sizeBuffer, 0);
                    //int bytesRead = await client.GetStream().ReadAsync(sizeBuffer, 0, sizeBuffer.Length);
                    BinaryWriter bw = new BinaryWriter(File.Open(receivedPath, FileMode.Append));
                    if (initialFlag)
                        bw.Write(imgbuffer, 4 + fileNameLen, bytesRead - (4 + fileNameLen));
                    else
                        bw.Write(imgbuffer, 0, bytesRead);

                    initialFlag = false;
                    bw.Close();
                    await stream.ReadAsync(imgbuffer, 0, bytesRead); //(statebuffer, 0, bytesRead, 0, new AsyncCallback(HandleClient), state);
                }

            }
        }
        #endregion
    }
}
