using System;
using System.Collections.Generic;
using System.Text;
using DAO;
using DTO;
using System.Data;

namespace BUS
{
    public static class PhieuGoiTien_BUS
    {
        public static long MaTiepTheo()
        {
            return PhieuGoiTien_DAO.MaLonNhat() + 1;
        }
        public static List<PhieuGoiTien_DTO> LayDanhSachPhieuGoi()
        {
            return PhieuGoiTien_DAO.LayDanhSachPhieuGoi();
        }
        public static void LapPhieuGoiTien(PhieuGoiTien_DTO phieugoitien, float tiencu)
        {
            PhieuGoiTien_DAO.LapPhieuGoiTien(phieugoitien);
            float tongtienmoi = phieugoitien.sotiengoi + tiencu;
            SoTietKiem_DAO.CapNhatTongTien(tongtienmoi , phieugoitien.maso);
            if (tongtienmoi == 0)
            {
                SoTietKiem_DAO.CapNhatTinhTrangSo(phieugoitien.maso, false);
            }
            else SoTietKiem_DAO.CapNhatTinhTrangSo(phieugoitien.maso, true);
           
        }
        public static void CapNhatPhieuGoiTien(PhieuGoiTien_DTO phieugoitien)
        {
            PhieuGoiTien_DAO.CapNhatPhieuGoiTien(phieugoitien);
        }
        public static bool DeleteLoai(string MaPhieuGoiTien)
        {
            return PhieuGoiTien_DAO.DeleteLoai(MaPhieuGoiTien);
        }
        public static DataTable DanhSachPhieuGoi(string a,string ngay)
        {
            return PhieuGoiTien_DAO.danhsachphieugoingay(a,ngay);
        }
        public static DataTable danhsachphieugoingay_ngay(string a)
        {
            return PhieuGoiTien_DAO.danhsachphieugoingay_ngay(a);
        }

        public static DataTable danhsachphieugoitien_ngay_locmaso(int maloai, string ngay, string thang, string nam)
        {
            return PhieuGoiTien_DAO.danhsachphieugoitien_ngay_locmaso(maloai, ngay, thang, nam);
        }

    }
}
