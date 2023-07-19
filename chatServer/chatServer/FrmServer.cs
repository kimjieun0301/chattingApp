using chattingLib;
using System.Net;
using System.Net.Sockets;

namespace chatServer
{
    public partial class FrmServer : Form
    {
        #region init
        private TcpListener _listener;
        public static FrmServer frmServer;
        public FrmServer()
        {
            InitializeComponent();
            frmServer = this;
        }
        #endregion

        #region 채팅 서버 시작
        private async void BtnListen_Click(object sender, EventArgs e)
        {
            BtnListen.Enabled = false;
            _listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 8080);
            _listener.Start();
            while (true)
            {
                TcpClient client = await _listener.AcceptTcpClientAsync();
                CsClientHandler clientHandler = new CsClientHandler(client);
                _ = clientHandler.HandleClientAsync();
            }
        }
        #endregion

        #region 채팅 서버 종료
        private void FrmServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            _listener.Stop();
            Application.Exit();
        }
        #endregion

        #region 채팅 서버 로그 출력
        public void listview_print(CsChatting chatForm)
        {
            LvChkServer.Items.Add($"{chatForm.MemId},{chatForm.RoomId},{chatForm.MemName},{chatForm.Message}");
            Txtcount.Text = LvChkServer.Items.Count.ToString();
        }
        #endregion
    }
}
