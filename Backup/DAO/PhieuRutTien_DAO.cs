using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using System.Data;

namespace DAO
{
    public static class PhieuRutTien_DAO
    {
        public static void CapNhatPhieuRutTien(PhieuRutTien_DTO phieuruttien)
        {
            string cautruyvan = "update PHIEURUTTIEN set NgayRut='" + phieuruttien.ngayrut + "'" +
                                                        ", SoTienRut=" + phieuruttien.sotienrut +
                                                      " where MaPhieuRutTien=" + phieuruttien.maphieuruttien + "";
            DaTaProvider.ThucHienTruyKhongTraVeBang(cautruyvan);
        }
        public static List<PhieuRutTien_DTO> LayDanhSachPhieuRut()
        {

            string cautruyvan = "select * from PHIEURUTTIEN order by MaPhieuRutTien desc";
            DataTable bangketqua = DaTaProvider.ThucHienTruyVanTraVeBang(cautruyvan);
            List<PhieuRutTien_DTO> danhsachphieugoi = new List<PhieuRutTien_DTO>();
            foreach (DataRow dong in bangketqua.Rows)
            {
                PhieuRutTien_DTO phieurut = new PhieuRutTien_DTO();
                phieurut.maphieuruttien = long.Parse(dong["maphieuruttien"].ToString());
                phieurut.maso = long.Parse(dong["maso"].ToString());
                phieurut.sotienrut = long.Parse(dong["sotienrut"].ToString());
                phieurut.ngayrut = DateTime.Parse(dong["ngayrut"].ToString());
                danhsachphieugoi.Add(phieurut);
            }
            return danhsachphieugoi;
        }
        public static long MaLonNhat()
        {
            string cautruyvan = "select MAX(MaPhieuRutTien) from PHIEURUTTIEN";
            DataTable bangketqua = DaTaProvider.ThucHienTruyVanTraVeBang(cautruyvan);

            long malonnhat;
            if (long.TryParse(bangketqua.Rows[0][0].ToString(), out malonnhat) == false)
            {
                return 0;
            }
            return malonnhat;
        }

        public static void LapPhieuRutTien(PhieuRutTien_DTO phieuruttien)
        {

            string cautruyvan = "Insert into PHIEURUTTIEN(MaSo,NgayRut,SoTienRut) values (" + phieuruttien.maso + ",'" + phieuruttien.ngayrut + "'," + phieuruttien.sotienrut + ")";
            DaTaProvider.ThucHienTruyKhongTraVeBang(cautruyvan);

        }

        public static DataTable danhsachphieugoingay(string a,string ngay)
        {
            string str = "select * from PHIEURUTTIEN where  MaSo = " + a + " and DateValue(NgayRut)= #"+ngay+"#";
            DataTable table = new DataTable();

            table = DaTaProvider.ThucHienTruyVanTraVeBang(str);
            return table;
        }
        public static DataTable danhsachphieurutngay_ngay(string a)
        {
            string str = "select * from PHIEURUTTIEN where  NgayRut = #" + a + "#";
            DataTable table = new DataTable();

            table = DaTaProvider.ThucHienTruyVanTraVeBang(str);
            return table;
        }

        //select  DISTINCT  MaSo  from PHIEURUTTIEN where  NgayRut = #6/3/2009#
        public static DataTable danhsachphieuruttien_ngay_locmaso(int maloai, string ngay, string thang, string nam)
        {
            string str = "select sum(PR.sotienrut) as Tong from PHIEURUTTIEN PR, SOTIETKIEM STK, LOAITIETKIEM LTK where " +
                         " LTK.MaLoaiTietKiem = STK.MaLoaiTietKiem and " +
                         "STK.MaSo = PR.MaSo and " +
                         "LTK.MaLoaiTietKiem =" + maloai + " and " +
                         "Day(NgayRut) = " + ngay + " and " +
                         "Month(NgayRut) = " + thang + " and " +
                         "Year(NgayRut) = " + nam + "";
            DataTable table = new DataTable();

            table = DaTaProvider.ThucHienTruyVanTraVeBang(str);
            return table;
        }
        public static bool DeleteLoai(string MaPhieuRutTien)
        {

            String strSQL = "Delete From PHIEURUTTIEN";
            strSQL += " where MaPhieuRutTien= " + MaPhieuRutTien.ToString() + "";
            DaTaProvider.ThucHienTruyKhongTraVeBang(strSQL);
            return true; 
        } 
        
    }
}
