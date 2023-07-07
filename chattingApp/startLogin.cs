using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chattingApp
{
    public partial class StartLogin : Form
    {
        #region init
        private OleDbConnection LocalConn;
        public StartLogin()
        {
            InitializeComponent();
        }
        #endregion

        #region login button click
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            OleDbDataReader myReader;
            string sql = null;
            try
            {
                LocalConn = Common_DB.DBConnection();
                LocalConn.Open();

                if (TxtId.Text == "" || TxtPwd.Text == "")
                {
                    MessageBox.Show("ID 또는 Password를 입력 하세요...");
                    return;
                }

                sql = "select MEM_PWD from member ";
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
                //Form f = new Form();
                //f.Text = "로그인 OK";
                //f.ShowDialog();
                this.Hide();
                MemchatList memchatList1 = new MemchatList();
                //this.DialogResult = DialogResult.OK;
                memchatList1.Show();

            }

            catch (Exception e1)
            {
                //Log.WriteLine("FrmLogin", e1.ToString());
                MessageBox.Show(e1.ToString() + sql, "FrmLogin :: 로그인오류!");
            }
        }
        private void TxtPwd_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnLogin_Click(sender, e);
            }

        }
        #endregion

        #region member join button click
        private void BtnJoin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();

            MemberJoin memberJoin1 = new MemberJoin();
            this.DialogResult = DialogResult.OK;
            memberJoin1.Show();
        }
        #endregion
    }
}
