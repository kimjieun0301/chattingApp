using System.Data.OleDb;

namespace chattingApp
{
    public class CsMemList
    {
        #region init
        private OleDbConnection LocalConn;
        public string mem_id { get; set; }
        public string mem_pwd { get; set; }
        public string mem_name { get; set; }
        public string mem_email { get; set; }
        public string mem_pos { get; set; }
        public string mem_dept { get; set; }
        public string mem_hi { get; set; }
        public string mem_upt_dt { get; set; }
        public string mem_upt_id { get; set; }
        public string mem_reg_dt { get; set; }
        public string mem_reg_id { get; set; }
        public string ma { get; set; }
        public int cnt { get; set; }
        public string _mem_use_yn { get; set; }
        public string mem_use_yn
        {
            get
            {
                return _mem_use_yn == "Y" ? "사용" : _mem_use_yn == "N" ? "미사용" : "";
            }
            set
            {
                _mem_use_yn = value == "사용" ? "Y" : value == "미사용" ? "N" : "";
            }
        }

        public CsMemList()
        {
            mem_id = mem_pwd = mem_name = mem_email = mem_pos = mem_dept = mem_hi = mem_upt_dt = mem_upt_id = mem_reg_dt = mem_reg_id = ma = _mem_use_yn = mem_use_yn = "";
            cnt = 0;
        }
        #endregion

        #region 회원 정보 저장
        public void memSave()
        {
            string sql = null;
            try
            {
                LocalConn = Common_DB.DBConnection();
                LocalConn.Open();

                sql = "INSERT INTO MEMBER (MEM_ID, MEM_PWD, MEM_NAME, MEM_EMAIL, MEM_POS, MEM_DEPT, HI, UPT_DT, UPT_ID, REG_DT, REG_ID, MA, USE_YN) " +
                      "VALUES ('" + mem_id + "', '" + mem_pwd + "', '" + mem_name + "', '" + mem_email + "', '" + mem_pos + "', '" + mem_dept + "', '" + mem_hi + "', '" + mem_upt_dt + "', '" + mem_upt_id + "', sysdate, '" + mem_id + "', '" + ma + "', '" + _mem_use_yn + "')";
                Common_DB.DataManupulation(sql, LocalConn);
                LocalConn.Close();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.ToString() + sql, "회원 정보 저장오류!");
            }
        }   
        #endregion
    }
}
