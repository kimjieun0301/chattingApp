using System.Data.OleDb;

namespace chattingApp
{
    public partial class MemberJoin : Form
    {
        #region init
        private OleDbConnection LocalConn;
        private OleDbDataReader myReader;
        public MemberJoin()
        {
            InitializeComponent();
        }
        #endregion

        #region 가입 버튼 클릭
        private void btnJoin_Click(object sender, EventArgs e)
        {
            try
            {
                string id = tbxJnId.Text.Trim();
                string name = tbxJnNm.Text.Trim();
                string email = tbxJnEml.Text.Trim();
                string pos = tbxJnPos.Text.Trim();
                string dept = tbxJnDept.Text.Trim();
                string pwd = tbxJnPwd.Text.Trim();

                if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) ||
                    string.IsNullOrEmpty(pos) || string.IsNullOrEmpty(dept) || string.IsNullOrEmpty(pwd))
                {
                    MessageBox.Show("모든 필드를 입력해주세요.", "알림");
                    return;
                }

                if (IsIdDuplicated(id))
                {
                    MessageBox.Show("이미 사용 중인 아이디입니다.", "알림");
                    return;
                }

                CsMemList memList = new CsMemList();
                memList.mem_id = id;
                memList.mem_name = name;
                memList.mem_email = email;
                memList.mem_pos = pos;
                memList.mem_dept = dept;
                memList.mem_pwd = pwd;
                memList.mem_use_yn = "Y";

                memList.memSave();

                MessageBox.Show("회원 가입이 완료되었습니다.", "알림");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"오류가 발생했습니다: {ex.Message}", "오류");
            }
        }
        #endregion

        #region 아이디 중복 확인
        private bool IsIdDuplicated(string id)
        {
            try
            {
                using (LocalConn = Common_DB.DBConnection())
                {
                    LocalConn.Open();

                    string sql = "SELECT COUNT(*) FROM member " +
                                 " WHERE MEM_ID = '" + id + "' ";
                    using (OleDbCommand command = new OleDbCommand(sql, LocalConn))
                    {
                        command.Parameters.AddWithValue("?", id);
                        int count = Convert.ToInt32(command.ExecuteScalar());

                        if (count >= 1)
                        {
                            //MessageBox.Show("이미 등록된 ID 입니다.");
                            return true;
                        }
                        else
                        {
                            //MessageBox.Show("사용 가능한 ID 입니다.");
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"오류가 발생했습니다: {ex.Message}", "오류");
                return true;
            }
        }
        #endregion
    }
}
