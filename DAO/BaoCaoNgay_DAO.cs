using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using System.Data;


namespace DAO
{
    public static class BaoCaoNgay_DAO
    {
        public static DataTable tabble_baocaongay()
        {
            string cautruyvan = "select* from BAOCAONGAY ";
            DataTable table = DaTaProvider.ThucHienTruyVanTraVeBang(cautruyvan);
            
            return table;
 
        }

    }
}
