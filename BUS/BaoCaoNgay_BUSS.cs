using System;
using System.Collections.Generic;
using System.Text;
using DAO;
using DTO;
using System.Data;

namespace BUS
{
    public static class BaoCaoNgay_BUSS
    {
        public static DataTable Listdanhsach_baocaongay()
        {
            return BaoCaoNgay_DAO.tabble_baocaongay();

        }

    }
}
