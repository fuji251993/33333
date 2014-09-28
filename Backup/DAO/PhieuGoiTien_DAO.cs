using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using System.Data;

namespace DAO
{
    public static  class PhieuGoiTien_DAO
    {
        public static long MaLonNhat()
        {
            string cautruyvan = "select MAX(MaPhieuGoiTien) from PHIEUGOITIEN";
            DataTable bangketqua = DaTaProvider.ThucHienTruyVanTraVeBang(cautruyvan);

            long malonnhat;
            if (long.TryParse(bangketqua.Rows[0][0].ToString(), out malonnhat) == false)
            {
                return 0;
            }
            return malonnhat;
        }

        public static void LapPhieuGoiTien(PhieuGoiTien_DTO phieugoitien)
        {

            string cautruyvan = "Insert into PHIEUGOITIEN(MaSo,NgayGoi,SoTienGoi) values (" + phieugoitien.maso + ",'" + phieugoitien.ngaygoi + "'," + phieugoitien.sotiengoi + ")";
            DaTaProvider.ThucHienTruyKhongTraVeBang(cautruyvan);

        }
        public static void CapNhatPhieuGoiTien(PhieuGoiTien_DTO phieugoitien)
        {
            string cautruyvan = "update PHIEUGOITIEN set NgayGoi='" + phieugoitien.ngaygoi + "'" +
                                                        ", SoTienGoi=" + phieugoitien.sotiengoi +
                                                      " where MaPhieuGoiTien=" + phieugoitien.maphieugoitien + "";
            DaTaProvider.ThucHienTruyKhongTraVeBang(cautruyvan);
        }
        public static List<PhieuGoiTien_DTO> LayDanhSachPhieuGoi()
        {

            string cautruyvan = "select * from PHIEUGOITIEN order by MaPhieuGoiTien desc";
            DataTable bangketqua = DaTaProvider.ThucHienTruyVanTraVeBang(cautruyvan);
            List<PhieuGoiTien_DTO> danhsachphieugoi = new List<PhieuGoiTien_DTO>();
            foreach (DataRow dong in bangketqua.Rows)
            {
                PhieuGoiTien_DTO phieugoi = new PhieuGoiTien_DTO();
                phieugoi.maphieugoitien = long.Parse(dong["MaPhieuGoiTien"].ToString());
                phieugoi.maso = long.Parse(dong["MaSo"].ToString());
                phieugoi.sotiengoi = long.Parse(dong["SoTienGoi"].ToString());
                phieugoi.ngaygoi = DateTime.Parse(dong["NgayGoi"].ToString());
                danhsachphieugoi.Add(phieugoi);
            }
            return danhsachphieugoi;
        }
        public static List<PhieuGoiTien_DTO> LayDanhSachPhieuGoiBoiMaSo(long maso)
        {

            string cautruyvan = "select * from PHIEUGOITIEN where MaSo=" + maso + "";
            DataTable bangketqua = DaTaProvider.ThucHienTruyVanTraVeBang(cautruyvan);
            List<PhieuGoiTien_DTO> danhsachphieugoi = new List<PhieuGoiTien_DTO>();
            foreach (DataRow dong in bangketqua.Rows)
            {
                PhieuGoiTien_DTO phieugoi = new PhieuGoiTien_DTO();
                phieugoi.maphieugoitien = long.Parse(dong["MaPhieuGoiTien"].ToString());
                phieugoi.maso = long.Parse(dong["MaSo"].ToString());
                phieugoi.sotiengoi = long.Parse(dong["SoTienGoi"].ToString());
                phieugoi.ngaygoi = DateTime.Parse(dong["NgayGoi"].ToString());
                danhsachphieugoi.Add(phieugoi);
            }
            return danhsachphieugoi;
        }
        public static DataTable danhsachphieugoingay(string a,string ngay)
        {
            string str = "select * from PHIEUGOITIEN where  MaSo = " + a + " and DateValue(NgayGoi)= #" + ngay + "#";
            DataTable table = new DataTable();

            table = DaTaProvider.ThucHienTruyVanTraVeBang(str);
            return table;
        }
        public static DataTable danhsachphieugoingay_ngay(string a)
        {
            string str = "select * from PHIEUGOITIEN where  NgayGoi = #" + a + "#";
            DataTable table = new DataTable();
            table = DaTaProvider.ThucHienTruyVanTraVeBang(str);
            return table;
        }
        public static DataTable danhsachphieugoitien_ngay_locmaso(int maloai, string ngay, string thang, string nam)
        {
            string str = "select sum(PG.sotiengoi) as Tong from PHIEUGOITIEN PG, SOTIETKIEM STK, LOAITIETKIEM LTK where " +
                         " LTK.MaLoaiTietKiem = STK.MaLoaiTietKiem and " +
                         "STK.MaSo = PG.MaSo and " +
                         "LTK.MaLoaiTietKiem =" + maloai + " and " +
                         "Day(NgayGoi) =" + ngay +
                         " and Month(NgayGoi)=" + thang +
                         " and Year(NgayGoi)=" + nam;
            DataTable table = new DataTable();
            table = DaTaProvider.ThucHienTruyVanTraVeBang(str);
            return table;
        }
        public static bool DeleteLoai(string MaPhieuGoiTien)
        {
            String strSQL = "Delete From PHIEUGOITIEN";
            strSQL += " where MaPhieuGoiTien= " + MaPhieuGoiTien.ToString() + "";
            DaTaProvider.ThucHienTruyKhongTraVeBang(strSQL);
            return true;


        }
    }
}
