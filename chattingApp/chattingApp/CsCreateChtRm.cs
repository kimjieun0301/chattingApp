using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tbcomm.util;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace chattingApp
{
     public class CsCreateChtRm
    {
        private OleDbConnection LocalConn;
        public CsMemList MemList = new CsMemList();
        public int rm_rm_id { get; set; }
        public string rm_rm_name { get; set; }
        public string rm_upt_id { get; set; }
        public string rm_reg_id { get; set; }
        public int rm_hi { get; set; }
        public string rm_reg_dt { get; set; }
        public string rm_upt_dt { get; set; }
        public string _rm_use_yn { get; set; }
        public string rm_use_yn
        {
            get
            {
                return _rm_use_yn == "Y" ? "사용" : _rm_use_yn == "N" ? "미사용" : "";
            }
            set
            {
                _rm_use_yn = value == "사용" ? "Y" : value == "미사용" ? "N" : "";
            }
        }

        public CsCreateChtRm()
        {
            rm_rm_name = rm_upt_id = rm_reg_id = rm_reg_dt = rm_upt_dt = _rm_use_yn = rm_use_yn = "";
            rm_rm_id = rm_hi = 0;
        }

        public void GetChtRmId()
        {
            OleDbDataReader myReader;
            try
            {
                LocalConn = Common_DB.DBConnection();
                LocalConn.Open();

                string sql1 = " SELECT * " +
                              " FROM chatroom " +
                              " WHERE rm_id = (SELECT MAX(rm_id) FROM chatroom)";
                myReader = Common_DB.DataSelect(sql1, LocalConn);
                if (myReader.Read())
                   rm_rm_id = Convert.ToInt32(myReader["rm_id"].ToString());
            }
            catch (Exception e1)
            {
                Debug.WriteLine("GetChtRmId", e1.ToString());
            }
            finally
            {
                LocalConn.Close();
            }
        }

        public int creaste_ChtRm()
        {
            try
            {
                LocalConn = Common_DB.DBConnection();
                LocalConn.Open();

                string sql = " INSERT INTO chatroom " +
                             " (rm_id, rm_name, upt_id, reg_id, hi, reg_dt, upt_dt, use_yn) " +
                             " VALUES " +
                             " (SEQ_CHRM.NEXTVAL,'" + rm_rm_name + "', '" + CurrentMem.Instance.User.mem_id + "', '" + CurrentMem.Instance.User.mem_id + "', '" + rm_hi + "', sysdate, '','" + _rm_use_yn + "') ";
                Common_DB.DataManupulation(sql, LocalConn);
                GetChtRmId();
            }
            catch (Exception e1)
            {
                Debug.WriteLine("Creaste_ChtRm", e1.ToString());
                return -1;
            }
            finally
            {
                LocalConn.Close();
            }
            return rm_rm_id;
        }
    }
}
