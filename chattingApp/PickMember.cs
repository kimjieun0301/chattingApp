using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace chattingApp
{
    public partial class PickMember : Form
    {
        private OleDbConnection LocalConn;
        public PickMember()
        {
            InitializeComponent();
            PickMemList.CheckBoxes = true;
            PickMemList.OwnerDraw = true;
        }

        #region 폼 로드
        private void PickMember_Load(object sender, EventArgs e)
        {
            memberList();
        }
        #endregion

        #region 멤버 목록 조회
        private void memberList()
        {
            OleDbDataReader myReader;
            string sql = null;
            PickMemList.Items.Clear();
            try
            {
                LocalConn = Common_DB.DBConnection();
                LocalConn.Open();

                sql = "select MEM_NAME, MEM_POS, MEM_DEPT from member ";
                //sql += " where MEM_ID = " + "'" + TxtId.Text + "'";
                myReader = Common_DB.DataSelect(sql, LocalConn);

                while (myReader.Read())
                {
                    ListViewItem item = new ListViewItem();
                    item.SubItems.Add(myReader["MEM_NAME"].ToString());
                    item.SubItems.Add(myReader["MEM_POS"].ToString());
                    item.SubItems.Add(myReader["MEM_DEPT"].ToString());
                    PickMemList.Items.Add(item);
                }
                myReader.Close();
                LocalConn.Close();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.ToString() + sql, "친구 목록조회오류!");
            }
        }
        #endregion

        #region 체크박스 생성
        private void PickMemList_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            if ((e.ColumnIndex == 0))
            {
                e.DrawBackground();
                bool value = false;
                try
                {
                    value = Convert.ToBoolean(e.Header.Tag);
                }
                catch (Exception)
                {
                }
                CheckBoxRenderer.DrawCheckBox(e.Graphics, new Point(e.Bounds.Left + 4, e.Bounds.Top + 4), value ?
                System.Windows.Forms.VisualStyles.CheckBoxState.CheckedNormal :
                System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal);
            }
            else
            {
                e.DrawDefault = true;
            }
        }
        private void PickMemList_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void PickMemList_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        //맨 위 체크박스 선택 시, 전체 선택
        private void PickMemList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
            {
                bool value = false;
                try
                {
                    value = Convert.ToBoolean(this.PickMemList.Columns[e.Column].Tag);
                }
                catch (Exception)
                {
                }
                this.PickMemList.Columns[e.Column].Tag = !value;
                foreach (ListViewItem item in this.PickMemList.Items)
                    item.Checked = !value;

                this.PickMemList.Invalidate();
            }
        }
        #endregion

        #region 채팅생성 버튼 클릭
        private void MakechatRm_Click(object sender, EventArgs e)
        {
            List<int> checkedItems = new List<int>();

            for (int i = 0; i < PickMemList.Items.Count; i++)
            {
                if (PickMemList.Items[i].Checked)
                    checkedItems.Add(i);
            }

            if (checkedItems.Count == 0)
            {
                MessageBox.Show(this, "선택한 친구가 없습니다.");
                return;
            }

            if (MessageBox.Show(this, checkedItems.Count + "명의 친구와 채팅을 하시겠습니까?", "종료", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                string sql = "INSERT INTO CIS_WC (memName, memPos, memDept) " +
                             "VALUES (@memName, @memPos, @memDept)";

                try
                {
                    LocalConn = Common_DB.DBConnection();
                    LocalConn.Open();

                    using (OleDbCommand cmd = new OleDbCommand(sql, LocalConn))
                    {
                        foreach (int index in checkedItems)
                            {
                                string value1 = PickMemList.Items[index].SubItems[0].Text;
                                string value2 = PickMemList.Items[index].SubItems[1].Text;
                                string value3 = PickMemList.Items[index].SubItems[2].Text;

                                cmd.Parameters.Clear();
                                cmd.Parameters.AddWithValue("@memName", value1);
                                cmd.Parameters.AddWithValue("@memPos", value2);
                                cmd.Parameters.AddWithValue("@memDept", value3);

                            Common_DB.DataManupulation(sql, LocalConn);
                        }
                        MessageBox.Show(this, "채팅방 생성이 완료되었습니다.");
                    }
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.ToString() + sql, "채팅방 생성 오류!");
                }
                finally
                {
                    if (LocalConn != null && LocalConn.State == ConnectionState.Open)
                    {
                        LocalConn.Close();
                    }
                }
            }
        }
        #endregion

    }
}
