﻿using System.Data.OleDb;

namespace chattingApp
{
	public class Common_DB
	{
        #region 데이터 베이스 연결
        public static OleDbConnection DBConnection()
		{
			OleDbConnection Conn;

            string ConStr = "Provider=tbprov.Tbprov.6; Location=127.0.0.1,8629; Data Source=tibero;User ID=sys;Password=tibero;"
               + "Persist Security Info = True";
            Conn = new OleDbConnection(ConStr);
			return Conn;
		}
        #endregion

        #region 데이터 Select 
        public static OleDbDataReader DataSelect(string sql, OleDbConnection Conn)
		{
			try
			{
				OleDbCommand myCommand = new OleDbCommand(sql, Conn);
				return myCommand.ExecuteReader();
			}
			catch (Exception ex)
			{
				MessageBox.Show(sql + "\n" + ex.Message, "DataSelect");
				return null;
			}
			finally
			{
			}
		}
        #endregion

        #region 데이터 Delete, Insert 
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
