using chattingLib;
using System.Data.OleDb;
using System.Net;
using System.Net.Sockets;

namespace chattingApp
{
    public partial class StartLogin : Form
    {
        #region init
        private OleDbConnection LocalConn;
        private CsChatClient _client;
        private TcpClient _client1;
        public StartLogin()
        {
            InitializeComponent();
            _client = new CsChatClient(IPAddress.Parse("127.0.0.1"), 8080);
        }
        #endregion

        #region 로그인 버튼 클릭
        private async void BtnLogin_Click(object sender, EventArgs e)
        {
            OleDbDataReader myReader;
            string sql = null;
            try
            {
                _client1 = await _client.ConnectAsync(new CsChatting { });
                CsClientHandler CsClientHandler = new CsClientHandler(_client1);
                CsSaveClient.Instance._CsClientHandler = CsClientHandler;

                LocalConn = Common_DB.DBConnection();
                LocalConn.Open();

                if (TxtId.Text == "" || TxtPwd.Text == "")
                {
                    MessageBox.Show("ID 또는 Password를 입력 하세요...");
                    return;
                }

                sql = "select MEM_PWD, MEM_NAME from member ";
                sql += " where MEM_ID = " + "'" + TxtId.Text + "'";
                myReader = Common_DB.DataSelect(sql, LocalConn);

                if (myReader.Read())
                {
                    if (TxtPwd.Text != myReader["MEM_PWD"].ToString())
                    {
                        MessageBox.Show("Password가 맞지 않습니다...");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("등록되지 않은 ID 입니다.");
                    return;
                }
                CsMemList CsMemList = new CsMemList();
                CsMemList.mem_id = TxtId.Text;
                CsMemList.mem_name = myReader["MEM_NAME"].ToString();
                CurrentMem.Instance.User = CsMemList;
                CsClientHandler.Send_id();
                myReader.Close();
                LocalConn.Close();
                this.Hide();
                MemchatList memchatList = new MemchatList();
                memchatList.Show();

            }

            catch (Exception e1)
            {
                MessageBox.Show(e1.ToString() + sql, "FrmLogin :: 로그인오류!");
            }
        }
        #endregion

        #region 회원가입 텍스트 버튼 클릭
        private void BtnJoin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();

            MemberJoin memberJoin1 = new MemberJoin();
            this.DialogResult = DialogResult.OK;
            memberJoin1.Show();
        }
        #endregion

        #region 엔터키 컨트롤
        private void TxtPwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnLogin_Click(sender, e);
            }
        }

        private void TxtId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TxtPwd.Focus();
            }
        }
        #endregion
    }
}
