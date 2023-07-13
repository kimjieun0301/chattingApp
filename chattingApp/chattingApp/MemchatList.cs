using System.Data.OleDb;

namespace chattingApp
{
    public partial class MemchatList : Form
    {
        #region init
        private OleDbConnection LocalConn;
        public MemchatList()
        {
            InitializeComponent();
        }
        #endregion

        #region 폼 로드
        private void MemchatList_Load(object sender, EventArgs e)
        {
            MemList_binding();
            memberList();
        }
        #endregion

        #region 리스트뷰 바인딩
        // 멤버 리스트 바인딩
        private void MemList_binding()
        {
            memchatListview.Columns.Clear();
            memchatListview.View = View.Details;

            ColumnHeader memName = new ColumnHeader();
            memName.Text = "이름";
            memName.Width = 100;
            memName.TextAlign = HorizontalAlignment.Center;

            ColumnHeader memPos = new ColumnHeader();
            memPos.Text = "직책";
            memPos.Width = 100;
            memPos.TextAlign = HorizontalAlignment.Center;

            ColumnHeader memDept = new ColumnHeader();
            memDept.Text = "부서";
            memDept.Width = 100;
            memDept.TextAlign = HorizontalAlignment.Center;

            ColumnHeader memId = new ColumnHeader();
            memId.Text = "아이디";
            memId.Width = 0;
            memId.TextAlign = HorizontalAlignment.Center;

            memchatListview.Columns.Add(memName);
            memchatListview.Columns.Add(memPos);
            memchatListview.Columns.Add(memDept);
            memchatListview.Columns.Add(memId);
        }

        // 채팅방 리스트 바인딩
        private void ChtRMList_binding()
        {
            memchatListview.Columns.Clear();
            memchatListview.View = View.Details;

            ColumnHeader rmId = new ColumnHeader();
            rmId.Text = "아이디";
            rmId.Width = 80;
            rmId.TextAlign = HorizontalAlignment.Center;

            ColumnHeader rmName = new ColumnHeader();
            rmName.Text = "채팅방 이름";
            rmName.Width = 150;
            rmName.TextAlign = HorizontalAlignment.Center;


            memchatListview.Columns.Add(rmId);
            memchatListview.Columns.Add(rmName);
        }
        #endregion

        #region 멤버 목록 조회
        private void memberList()
        {
            OleDbDataReader myReader;
            string sql = null;
            memchatListview.Items.Clear();
            try
            {
                LocalConn = Common_DB.DBConnection();
                LocalConn.Open();

                sql = "select MEM_ID,MEM_NAME, MEM_POS, MEM_DEPT from member ";
                //sql += " where MEM_ID = " + "'" + TxtId.Text + "'";
                myReader = Common_DB.DataSelect(sql, LocalConn);

                while (myReader.Read())
                {
                    ListViewItem item = new ListViewItem(myReader["MEM_NAME"].ToString());

                    item.SubItems.Add(myReader["MEM_POS"].ToString());
                    item.SubItems.Add(myReader["MEM_DEPT"].ToString());
                    item.SubItems.Add(myReader["MEM_ID"].ToString());

                    //DateTime regDate = (DateTime)myReader["regDate"];
                    //tem.SubItems.Add(regDate.ToLongDateString());

                    memchatListview.Items.Add(item);
                }
                myReader.Close();
            }
            catch (Exception e1)
            {
                //Log.WriteLine("FrmLogin", e1.ToString());
                MessageBox.Show(e1.ToString() + sql, "FrmLogin :: 목록조회오류!");
            }
        }
        #endregion

        #region 채팅방 목록 조회
        private void chtRmList()
        {
            OleDbDataReader myReader;
            string sql = null;
            memchatListview.Items.Clear();
            try
            {
                LocalConn = Common_DB.DBConnection();
                LocalConn.Open();

                sql = "SELECT ING.MEM_ID, ING.RM_ID, RM.RM_NAME " +
                      " FROM INGCHAT ING " +
                      " JOIN CHATROOM RM ON ING.RM_ID = RM.RM_ID " +
                      " WHERE ING.MEM_ID = " + "'" + CurrentMem.Instance.User.mem_id + "'";
                myReader = Common_DB.DataSelect(sql, LocalConn);

                while (myReader.Read())
                {
                    ListViewItem item = new ListViewItem(myReader["RM_ID"].ToString());
                    item.SubItems.Add(myReader["RM_NAME"].ToString());

                    memchatListview.Items.Add(item);
                }
                myReader.Close();
            }
            catch (Exception e1)
            {
                //Log.WriteLine("FrmMemchatList", e1.ToString());
                MessageBox.Show(e1.ToString() + sql, "FrmMemchatList :: 채팅방목록조회오류!");
            }
        }
        #endregion

        #region 멤버 목록 조회 버튼
        private void BtnMemList_Click(object sender, EventArgs e)
        {
            MemList_binding();
            memberList();
        }
        #endregion

        #region 채팅방 목록 조회 버튼
        private void BtnChtRmList_Click(object sender, EventArgs e)
        {
            ChtRMList_binding();
            chtRmList();
        }
        #endregion

        #region 채팅방 만들기 버튼(채팅방 멤버 선택창)
        private void BtnMkChat_Click(object sender, EventArgs e)
        {
            PickMember PickMember1 = new PickMember();
            this.DialogResult = DialogResult.OK;
            PickMember1.Show();
        }
        #endregion

        #region 채팅방 테스트 버튼
        private void BtnChatRoom_Click(object sender, EventArgs e)
        {
            chatRoom chatRoom1 = new chatRoom(37);
            this.DialogResult = DialogResult.OK;
            chatRoom1.Show();
        }
        #endregion

    }
}
