using System.Data.OleDb;

namespace chattingApp
{
    public partial class MemProf : Form
    {
        #region init
        private OleDbConnection LocalConn;
        string _mem_id;
        public MemProf(string mem_id)
        {
            InitializeComponent();
            _mem_id = mem_id;
        }
        #endregion

        #region 폼로드
        private void MemProf_Load(object sender, EventArgs e)
        {
            memberList();
        }
        #endregion

        #region 멤버 정보 조회
        private void memberList()
        {
            OleDbDataReader myReader;
            string sql = null;
            try
            {
                LocalConn = Common_DB.DBConnection();
                LocalConn.Open();

                sql = "select MEM_ID,MEM_NAME, MEM_EMAIL, MEM_POS, MEM_DEPT from member " +
                      " WHERE MEM_ID = '" + _mem_id + "'";
                myReader = Common_DB.DataSelect(sql, LocalConn);

                while (myReader.Read())
                {
                    tbxMemName.Text = myReader["MEM_NAME"].ToString();
                    tbxMemEmail.Text = myReader["MEM_EMAIL"].ToString();
                    tbxMemId.Text = myReader["MEM_ID"].ToString();
                    tbxMemPos.Text = myReader["MEM_POS"].ToString();
                    tbxMemDept.Text = myReader["MEM_DEPT"].ToString();
                }
                myReader.Close();
                LocalConn.Close();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.ToString() + sql, "회원 정보 조회오류!");
            }
        }
        #endregion
    }
}
