using System;
using System.Collections.Generic;
using System.Text;
using DAO;
using System.Data;

namespace BUS
{
    public class DangNhap_BUSS
    {
        public static DataTable KiemtraUser(string user, string matkhau)
        {
            return DangNhap_DAO.KiemtraUser(user, matkhau);
        }
        public static DataTable datatable_user()
        {
            return DangNhap_DAO.datatable_user();
        }
    }
}
