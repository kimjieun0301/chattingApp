using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using chattingLib;

namespace chatServer
{
    public class CsMessage
    {
        #region init
        private OleDbConnection LocalConn;
        public int msg_id { get; set; }
        public int rm_id { get; set; }
        public string mem_id { get; set; }
        public string msg_txt { get; set; }
        public string msg_img { get; set; }
        public int hi { get; set; }
        public string reg_id { get; set; }
        public string reg_dt { get; set; }
        public string _use_yn { get; set; }
        public string use_yn
        {
            get
            {
                return _use_yn == "Y" ? "사용" : _use_yn == "N" ? "미사용" : "";
            }
            set
            {
                _use_yn = value == "사용" ? "Y" : value == "미사용" ? "N" : "";
            }
        }

        public CsMessage()
        {
            mem_id = msg_txt = msg_img = reg_id = reg_dt = use_yn = _use_yn = "";
            msg_id = rm_id = hi = 0;
        }
        #endregion

        #region 메시지 저장
        public void creaste_ChtMsg(CsChatting chatForm)
        {
            try
            {
                LocalConn = Common_DB.DBConnection();
                LocalConn.Open();
                
                string sql = " INSERT INTO message " +
                             " (msg_id, rm_id, mem_id, msg_txt, msg_img, reg_id, reg_dt, use_yn, hi) " +
                             " VALUES " +
                             " (SEQ_CHMSG.NEXTVAL,'" + chatForm.RoomId + "', '" + chatForm.MemId + "', '" + chatForm.Message + "', '', '" + chatForm.MemId + "', sysdate, '" + use_yn + "', '" + hi + "') ";
                Common_DB.DataManupulation(sql, LocalConn);
            }
            catch (Exception e1)
            {
                Debug.WriteLine("Creaste_ChtRm", e1.ToString());
            }
            finally
            {
                LocalConn.Close();
            }
        }
        #endregion
    }
}
