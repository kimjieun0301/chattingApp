using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chattingApp
{
	public class Common_DB
	{
        #region DataBase Connection
        public static OleDbConnection DBConnection()
		{
			OleDbConnection Conn;
			string ConStr = "Provider=tbprov.Tbprov.6; Data Source =localhost, 8629, tibero; User ID = sys; Password=tibero;"
               + "Persist Security Info = True";
            Conn = new OleDbConnection(ConStr);
			return Conn;
		}
        #endregion

        #region DataSelect 
        public static OleDbDataReader DataSelect(string sql, OleDbConnection Conn)
		{
			try
			{
				OleDbCommand myCommand = new OleDbCommand(sql, Conn);
				return myCommand.ExecuteReader();
			}
			catch (Exception ex)
			{
				//Log File에 출력 
				MessageBox.Show(sql + "\n" + ex.Message, "DataSelect");
				return null;
			}
			finally
			{
			}
		}
        #endregion

        #region DataDelete, DataInsert 
        public static bool DataManupulation(string sql, OleDbConnection Conn)
		{
			try
			{
				OleDbCommand myCommand = new OleDbCommand(sql, Conn);
				myCommand.ExecuteNonQuery();
				return true;
			}
			catch (Exception ex)
			{
				//Log File에 출력 
				MessageBox.Show(sql + "\n" + ex.Message, "DataManupulation");
				return false;
			}
			finally
			{
			}
		}
        #endregion
    }
}
