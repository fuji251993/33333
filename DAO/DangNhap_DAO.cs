using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace DAO
{
    public class DangNhap_DAO
    {
        public static DataTable KiemtraUser(string user, string matkhau)
        {
            DaTaProvider d = new DaTaProvider();
            String strSql = " select TenUsers from Users where TenUsers='" + user.ToString() + "' and MatKhau='" + matkhau.ToString() + "'";
            DataTable table = new DataTable();
            table = DaTaProvider.ThucHienTruyVanTraVeBang(strSql);
            return table;
        }
        public static DataTable datatable_user()
        {
            string str = "select * from Users ";
            DataTable table = new DataTable();
            table = DaTaProvider.ThucHienTruyVanTraVeBang(str);
            return table;
        }
    }
}
