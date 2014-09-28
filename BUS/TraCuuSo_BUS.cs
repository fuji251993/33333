using System;
using System.Collections.Generic;
using System.Text;
using DAO;
using DTO;
using System.Data;

namespace BUS
{
    public static class TraCuuSo_BUS
    {
        public static List<TraCuuSo_DTO> LayDSSTKThoaTraCuu1(string khachhang, string diachi, float tonngtien1, float tongtien2, DateTime ngay1, DateTime ngay2, string tenloaitietkiem, string cmnd, bool tinhtrang)
        {
            return TraCuuSo_DAO.LayDSSOTKThoaTraCuu1(khachhang, diachi, tonngtien1, tongtien2, ngay1, ngay2, tenloaitietkiem, cmnd, tinhtrang);

        }
        public static DataTable LayDSSOTKThoaTraCuu_KhongTraCuuNgay(string khachhang, string diachi, float tonngtien1, float tongtien2, string tenloaitietkiem, string cmnd, bool tinhtrang)
        {
            return TraCuuSo_DAO.LayDSSOTKThoaTraCuu_KhongTraCuuNgay(khachhang, diachi, tonngtien1, tongtien2, tenloaitietkiem, cmnd, tinhtrang);

        }
        public static DataTable LayDSSTKThoaTraCuu2(long maso)
        {
            return TraCuuSo_DAO.LayDSSTKThoaTraCuu2(maso);
        }
    }
}
