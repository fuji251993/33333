using System;
using System.Collections.Generic;
using System.Text;
using DAO;
using DTO;
using System.Data;
namespace BUS
{
   public class SoTietKiem_BUS
    {
       public static long MaTiepTheo()
       {
           return SoTietKiem_DAO.MaLonNhat() + 1;
       }
       public static void CapNhatSoTietKiem(SoTietKiem_DTO sotietkiem)
       {
           SoTietKiem_DAO.CapNhatSoTietKiem(sotietkiem);
       }
       public static void LapSoTK(SoTietKiem_DTO sotietkiem)
       {
           SoTietKiem_DAO.LapSoTK(sotietkiem);
       }

       public static SoTietKiem_DTO LayThongTinSoTietKiem(long maso)
       {
           return SoTietKiem_DAO.LayThongTinSoTietKiem(maso);
       }

       public static long LayMaLoaiTietKiem(long maso)
       {
           return SoTietKiem_DAO.LayMaLoaiTietKiem(maso);
       }
       public static DateTime LayNgayMoSo(long maso)
       {
           return SoTietKiem_DAO.LayNgayMoSo(maso);
       }

       public static List<SoTietKiem_DTO> ListSo()
       {
           return SoTietKiem_DAO.ListSo();
       }
       public static List<SoTietKiem_DTO> ListSoMo()
       {
           return SoTietKiem_DAO.ListSoMo();
       }
       public static DataTable BaoCaoNgay(string t)
       {
           return SoTietKiem_DAO.BaoCaoNgay(t);
       }
       public static DataTable SoTietKiem(string t)
       {
           return SoTietKiem_DAO.SoTietKiem(t);
       }
       public static DataTable SoTietKiem(string ngay, string thang)
       {
           return SoTietKiem_DAO.BangLocNgay(ngay, thang);
       }
       public static DataTable BangLocNgay_TheoThang(string thang, string nam)
       {
           return SoTietKiem_DAO.BangLocNgay_TheoThang(thang, nam);
       }
       public static bool DeleteLoai(string MaSo)
       {
           return SoTietKiem_DAO.DeleteLoai(MaSo);
       }
       public static DataTable So_Mo(string ngay, string thang, string nam, string ma)
       {
           return SoTietKiem_DAO.So_Mo(ngay, thang, nam, ma);
       }
       public static DataTable All_So_Dong(string ngay)
       {
           return SoTietKiem_DAO.All_So_Dong(ngay);
       }
    }
}
