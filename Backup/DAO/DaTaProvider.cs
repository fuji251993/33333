using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace DAO
{
    public class DaTaProvider
    {
        private static OleDbConnection conection = null;
        protected static string chuoiketnoi = "Provider=Microsoft.Jet.oledb.4.0;data source = QLSOTK.mdb";

        public static DataTable ThucHienTruyVanTraVeBang(string cautruyvan)
        {
            conection = new OleDbConnection(chuoiketnoi);
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            OleDbCommand command = new OleDbCommand();
            conection.Open();
            command.Connection = conection;
            command.CommandText = cautruyvan;
            command.CommandType = CommandType.Text;
            adapter.SelectCommand = command;

            DataTable bangketqua = new DataTable();
            adapter.Fill(bangketqua);
            conection.Close();

            return bangketqua;

        }

        public static void ThucHienTruyKhongTraVeBang(string cautruyvan)
        {
            conection = new OleDbConnection(chuoiketnoi);
            OleDbCommand command = new OleDbCommand();

            conection.Open();
            command.Connection = conection;
            command.CommandText = cautruyvan;
            command.CommandType = CommandType.Text;

            command.ExecuteNonQuery();
            conection.Close();
        }
        public bool ExecuteScalar(string strQuery)
        {
            try
            {
                conection = new OleDbConnection(chuoiketnoi);
                int iCount = 0;
                conection.Open();
                OleDbCommand cmd = new OleDbCommand(strQuery, conection);
                iCount = (int)cmd.ExecuteScalar();

                if (iCount > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Loi thuc thi " + e.Message);
            }
            finally
            {
                conection.Close();
            }
        }
    }
}
