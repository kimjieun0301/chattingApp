using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tbcomm.util;

namespace chattingApp
{
     public class CsCreateChtRm
    {
        private OleDbConnection LocalConn;
        private CsMemList MemList = new CsMemList();
        public string rm_rm_id { get; set; }
        public string rm_rm_name { get; set; }
        public string rm_upt_id { get; set; }
        public string rm_reg_id { get; set; }
        public string rm_hi { get; set; }
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
            rm_rm_id = rm_rm_name = rm_upt_id = rm_reg_id = rm_hi = rm_reg_dt = rm_upt_dt = _rm_use_yn = rm_use_yn = "";

        }

        public CsCreateChtRm(DataRow v_dr)
        {
            rm_rm_id = v_dr["rm_id"].ToString();
            rm_rm_name = v_dr["rm_name"].ToString();
            rm_upt_id = v_dr["upt_id"].ToString();
            rm_reg_id = v_dr["reg_id"].ToString();
            rm_hi = v_dr["hi"].ToString();
            rm_reg_dt = v_dr["reg_dt"].ToString();
            rm_upt_dt = v_dr["upt_dt"].ToString();
            _rm_use_yn = v_dr["use_yn"].ToString();
            //disp_cfi_cycle = v_dr["cfi_cycle"].ToString() + v_dr["cfi_cycle_unit"].ToString();
        }

        public void GetChtRmId()
        {
            //OleDbDataReader myReader;
            try
            {
                LocalConn = Common_DB.DBConnection();
                LocalConn.Open();

                string sql = "select MEM_ID,MEM_NAME, MEM_POS, MEM_DEPT from member ";
                //sql += " where MEM_ID = " + "'" + TxtId.Text + "'";
                Common_DB.DataManupulation(sql, LocalConn);;
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
        public void Save()
        {
            try
            {
                LocalConn = Common_DB.DBConnection();
                LocalConn.Open();

                if (rm_rm_id.Length == 0)
                    GetChtRmId();



                //Common_DB.DataManupulation(sql, LocalConn); ;
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
    }
}
