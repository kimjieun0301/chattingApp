﻿using System.Data.OleDb;

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
            memberList();
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
                    ListViewItem item = new ListViewItem(myReader["MEM_ID"].ToString());



                    item.SubItems.Add(myReader["MEM_NAME"].ToString());

                    item.SubItems.Add(myReader["MEM_POS"].ToString());

                    item.SubItems.Add(myReader["MEM_DEPT"].ToString());


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
            chatRoom chatRoom1 = new chatRoom();
            this.DialogResult = DialogResult.OK;
            chatRoom1.Show();
        }
        #endregion
    }
}
