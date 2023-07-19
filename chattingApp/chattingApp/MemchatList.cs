using System.Data;
using System.Data.OleDb;

namespace chattingApp
{
    public partial class MemchatList : Form
    {
        #region init
        private OleDbConnection LocalConn;
        int searchFlag = 0;
        public MemchatList()
        {
            InitializeComponent();
            lbSearch.Text = "회원이름 : ";
            searchFlag = 1;
            timer1.Start();
            memchatListview.FullRowSelect = true;
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
                if (tbxSearch.Text.Trim().Length > 0)
                {
                    sql += " WHERE MEM_NAME LIKE '%" + tbxSearch.Text.Trim() + "%'";
                }
                myReader = Common_DB.DataSelect(sql, LocalConn);

                while (myReader.Read())
                {
                    ListViewItem item = new ListViewItem(myReader["MEM_NAME"].ToString());

                    item.SubItems.Add(myReader["MEM_POS"].ToString());
                    item.SubItems.Add(myReader["MEM_DEPT"].ToString());
                    item.SubItems.Add(myReader["MEM_ID"].ToString());

                    if (myReader["MEM_ID"].ToString() != CurrentMem.Instance.User.mem_id)
                    {
                        memchatListview.Items.Add(item);
                    }
                }
                myReader.Close();
                LocalConn.Close();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.ToString() + sql, "회원 목록 조회오류!");
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
                if (tbxSearch.Text.Trim().Length > 0)
                {
                    sql += " AND RM.RM_NAME LIKE '%" + tbxSearch.Text.Trim() + "%'";
                }
                myReader = Common_DB.DataSelect(sql, LocalConn);

                while (myReader.Read())
                {
                    ListViewItem item = new ListViewItem(myReader["RM_ID"].ToString());
                    item.SubItems.Add(myReader["RM_NAME"].ToString());

                    memchatListview.Items.Add(item);
                }
                myReader.Close();
                LocalConn.Close();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.ToString() + sql, "채팅방 목록 조회오류!");
            }
        }
        #endregion

        #region 멤버 목록 조회 버튼
        private void BtnMemList_Click(object sender, EventArgs e)
        {
            searchFlag = 1;
            lbSearch.Text = "회원이름 : ";
            MemList_binding();
            memberList();
        }
        #endregion

        #region 채팅방 목록 조회 버튼
        private void BtnChtRmList_Click(object sender, EventArgs e)
        {
            searchFlag = 2;
            lbSearch.Text = "채팅방 이름 : ";
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

        #region 내 프로필 버튼 클릭
        private void BtnMyProf_Click(object sender, EventArgs e)
        {
            MemProf memProf = new MemProf(CurrentMem.Instance.User.mem_id);
            memProf.Show();
        }
        #endregion

        #region 검색 버튼
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (searchFlag == 1)
            {
                MemList_binding();
                memberList();
            }
            else if (searchFlag == 2)
            {
                ChtRMList_binding();
                chtRmList();
            }
        }
        #endregion

        #region 리스트뷰 항목 클릭
        private void memchatListview_MouseClick(object sender, MouseEventArgs e)
        {
            if (searchFlag == 1)
            {
                if (memchatListview.SelectedItems.Count != 0)
                {
                    ListView.SelectedListViewItemCollection items = memchatListview.SelectedItems;
                    ListViewItem lvItem = items[0];
                    try
                    {
                        MemProf memProf = new MemProf(lvItem.SubItems[3].Text);
                        memProf.Show();
                    }
                    catch
                    {
                        MessageBox.Show("존재하지 않는 경로입니다.", MessageBoxIcon.Error.ToString());
                    }
                }
            }
            else if (searchFlag == 2)
            {
                if (memchatListview.SelectedItems.Count != 0)
                {
                    ListView.SelectedListViewItemCollection items = memchatListview.SelectedItems;
                    ListViewItem lvItem = items[0];
                    try
                    {
                        chatRoom chatRoom = new chatRoom(Convert.ToInt32(lvItem.SubItems[0].Text));
                        chatRoom.Show();
                    }
                    catch
                    {
                        MessageBox.Show("존재하지 않는 경로입니다.", MessageBoxIcon.Error.ToString());
                    }
                }
            }
        }
        #endregion

        #region 목록창 닫으면 다 닫히고 프로그램 종료
        private void MemchatList_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                //사용자가 닫고자 할 때
                if (e.CloseReason == CloseReason.UserClosing)
                {
                    CsSaveClient.Instance._CsClientHandler.AppExit();
                    // 다른 창들도 모두 종료하고 프로그램을 완전히 종료
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"오류가 발생했습니다: {ex.Message}");
                // 폼을 닫지 않도록 설정
                e.Cancel = true;
            }
        }
        #endregion

        #region 시계
        private void timer1_Tick(object sender, EventArgs e)
        {
            OleDbDataReader myReader;
            string sql = null;
            try
            {
                LocalConn = Common_DB.DBConnection();
                LocalConn.Open();

                sql = "SELECT SYSDATE AS CurrentDateTime FROM DUAL";
                myReader = Common_DB.DataSelect(sql, LocalConn);

                if (myReader.Read())
                {
                    DateTime currentDateTime = myReader.GetDateTime("CurrentDateTime");
                    string formattedTime = currentDateTime.ToString("yyyy년MM월dd일\ntt hh:mm:ss");
                    label1.Text = formattedTime;
                }
                myReader.Close();
                LocalConn.Close();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.ToString() + sql, "시계 오류!");
            }
        }
        #endregion
    }
}
