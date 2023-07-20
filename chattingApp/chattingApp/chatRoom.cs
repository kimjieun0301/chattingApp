using chattingLib;
using System.Data.OleDb;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace chattingApp
{
    public partial class chatRoom : Form
    {
        #region init
        private OleDbConnection LocalConn;
        private TcpClient _client;
        string m_fName = string.Empty;
        int room_id = 0;
        public static chatRoom chatRoom1;
        public chatRoom(int room_id)
        {
            InitializeComponent();
            chatRoom1 = this;
            this.room_id = room_id;
            listview_print(new CsChatting());
        }
        #endregion

        #region 폼로드
        private void chatRoom_Load(object sender, EventArgs e)
        {
            TxtMessage.Focus();
            msgMemList();
            messageList();
        }
        #endregion

        #region 채팅인원 조회
        private void msgMemList()
        {
            OleDbDataReader myReader;
            string sql = null;
            MsgList.Items.Clear();
            try
            {
                LocalConn = Common_DB.DBConnection();
                LocalConn.Open();

                sql = " SELECT * from ingchat " +
                      " WHERE rm_id = '" + room_id + "' " +
                      " ORDER BY MEM_ID ASC";
                myReader = Common_DB.DataSelect(sql, LocalConn);

                while (myReader.Read())
                {
                    chtmemList.Items.Add(myReader["MEM_ID"].ToString());
                }

                myReader.Close();
                LocalConn.Close();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.ToString() + sql, "Frmchatroom :: 채팅인원 조회오류!");
            }
        }
        #endregion

        #region 채팅메세지 새 메시지 조회
        public void listview_print(CsChatting chatForm)
        {
            if (chatForm.RoomId == room_id)
            {
                if (CurrentMem.Instance.User.mem_id == chatForm.MemId)
                    MsgList.Items.Add($"-> {chatForm.MemName} : {chatForm.Message}");
                else
                    MsgList.Items.Add($"{chatForm.MemName} : {chatForm.Message}");
                MsgList.SelectedIndex = MsgList.Items.Count - 1;
            }
        }
        #endregion

        #region 채팅메세지 조회
        private void messageList()
        {
            OleDbDataReader myReader;
            string sql = null;
            MsgList.Items.Clear();
            try
            {
                LocalConn = Common_DB.DBConnection();
                LocalConn.Open();

                sql = " SELECT MSG.MEM_ID, MSG.MSG_TXT, MB.MEM_NAME " +
                      " from MESSAGE MSG " +
                      " JOIN MEMBER MB ON MSG.MEM_ID = MB.MEM_ID " +
                      " WHERE rm_id = '" + room_id + "' " +
                      " ORDER BY msg_id ASC";
                myReader = Common_DB.DataSelect(sql, LocalConn);

                while (myReader.Read())
                {
                    string message;
                    if (CurrentMem.Instance.User.mem_id == myReader["MEM_ID"].ToString())
                        message = "->" + myReader["MEM_NAME"].ToString() + " : " + myReader["MSG_TXT"].ToString();
                    else
                        message = myReader["MEM_NAME"].ToString() + " : " + myReader["MSG_TXT"].ToString();

                    MsgList.Items.Add(message);
                    MsgList.SelectedIndex = MsgList.Items.Count - 1;
                }

                myReader.Close();
                LocalConn.Close();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.ToString() + sql, "Frmchatroom :: 메세지조회오류!");
            }
        }
        #endregion

        #region 사진 전송용 클라이언트 핸들러
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

                MsgList.EndUpdate();
            }
        }
        #endregion

        #region 메세지 전송 버튼 클릭
        private async void BtnSendMsg_Click(object sender, EventArgs e)
        {
            string text = TxtMessage.Text;
            CsSaveClient.Instance._CsClientHandler?.Send(new CsChatting
            {
                MemId = CurrentMem.Instance.User.mem_id,
                RoomId = room_id,
                MemName = CurrentMem.Instance.User.mem_name,
                Message = text,
            });
            TxtMessage.Clear();
        }
        #endregion

        #region 사진 버튼 클릭
        private void BtnSendPic_Click(object sender, EventArgs e)
        {
            string m_splitter = "'\\'";
            string[] m_split = null;
            char[] delimeter = m_splitter.ToCharArray();

            openFileDialog1.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            openFileDialog1.ShowDialog();

            TxtMessage.Text = openFileDialog1.FileName;

            m_split = TxtMessage.Text.Split(delimeter);
            int limit = m_split.Length;

            m_fName = m_split[limit - 1].ToString();

            if (TxtMessage.Text != null)
                BtnSendMsg.Enabled = true;

            Thread t_handler = new Thread(SendData);
            t_handler.IsBackground = true;
            t_handler.Start();
        }
        #endregion

        #region 사진 전송
        private async void SendData()
        {
            _client = new TcpClient();
            await _client.ConnectAsync(IPAddress.Parse("127.0.0.1"), 8080);
            _ = HandleClient(_client);
            NetworkStream stream = _client.GetStream();
            string type = "img";
            var typeBuffer = Encoding.UTF8.GetBytes(type);

            byte[] fileName = Encoding.UTF8.GetBytes(m_fName);
            byte[] fileData = File.ReadAllBytes(TxtMessage.Text);
            byte[] fileNameLen = BitConverter.GetBytes(fileName.Length);
            byte[] fileDataLen = BitConverter.GetBytes(fileData.Length);
            byte[] m_clientData = new byte[4 + fileName.Length + fileData.Length];


            fileNameLen.CopyTo(m_clientData, 0);
            fileName.CopyTo(m_clientData, 4);
            fileData.CopyTo(m_clientData, 4 + fileName.Length);


            stream.Write(typeBuffer, 0, typeBuffer.Length);
            stream.Write(m_clientData, 0, m_clientData.Length);
            stream.Write(fileDataLen, 0, fileDataLen.Length);
            using (FileStream fs = new FileStream(TxtMessage.Text, FileMode.Open, FileAccess.Read))
            {
                byte[] buffer = new byte[4096];
                int bytesRead;

                while ((bytesRead = await fs.ReadAsync(buffer, 0, buffer.Length)) > 0)
                {
                    await stream.WriteAsync(buffer, 0, bytesRead);
                }
            }
        }
        #endregion

        #region 엔터키 컨트롤
        private void TxtMessage_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnSendMsg_Click(sender, e);
            }
        }
        #endregion
    }
}
