using System;
using System.Collections.Generic;
using System.Text;
using DAO;
using DTO;
using System.Data;

namespace BUS
{
    public static class PhieuRutTien_BUS
    {
        public static long MaTiepTheo()
        {
            return PhieuRutTien_DAO.MaLonNhat() + 1;
        }
        public static List<PhieuRutTien_DTO> LayDanhSachPhieuRut()
        {
            return PhieuRutTien_DAO.LayDanhSachPhieuRut();
        }
        public static void LapPhieuRutTien(PhieuRutTien_DTO phieuruttien, float tiencu)
        {
            PhieuRutTien_DAO.LapPhieuRutTien(phieuruttien);
            float tongtienmoi = tiencu - phieuruttien.sotienrut;
            SoTietKiem_DAO.CapNhatTongTien(tongtienmoi, phieuruttien.maso);
            if (tongtienmoi == 0)
            {
                SoTietKiem_DAO.CapNhatTinhTrangSo(phieuruttien.maso, false);
            }
            else SoTietKiem_DAO.CapNhatTinhTrangSo(phieuruttien.maso,true);
           

        }
        public static void CapNhatPhieuRutTien(PhieuRutTien_DTO phieuruttien)
        {
            PhieuRutTien_DAO.CapNhatPhieuRutTien(phieuruttien);
        }
        public static bool DeleteLoai(string MaPhieuRutTien)
        {
            return PhieuRutTien_DAO.DeleteLoai(MaPhieuRutTien);
        }
        public static long TinhLaiKhongKiHan(long maso, float sotiengoibandau)
        {
            List<PhieuGoiTien_DTO> danhsachphieugoi = PhieuGoiTien_DAO.LayDanhSachPhieuGoiBoiMaSo(maso);
            SoTietKiem_DTO SoTietKiem = SoTietKiem_BUS.LayThongTinSoTietKiem(maso);
            LoaiTietKiem_DTO LoaiTietKiem = LoaiTietKiem_BUS.LayDSLTK(SoTietKiem.maloaitietkiem);
            
            long tienlaitong = 0;
            foreach (PhieuGoiTien_DTO phieu in danhsachphieugoi)
            {
                long tienlai;
                int kc = ((TimeSpan)((DateTime.Now - phieu.ngaygoi))).Days / 30;
                if (kc < 1)
                {
                    tienlai = 0;
                }
                else
                {
                    tienlai = (long)((phieu.sotiengoi * LoaiTietKiem.laisuat) / 100);
                }
                tienlaitong = tienlaitong + tienlai;
            }
            return tienlaitong + (long)(sotiengoibandau * LoaiTietKiem.laisuat) / 100;

        }
        public static DataTable DanhSachPhieuRutTien(string a, string ngay)
        {
            return PhieuRutTien_DAO.danhsachphieugoingay(a,ngay);
        }
        public static DataTable danhsachphieurutngay_ngay(string a)
        {
            return PhieuRutTien_DAO.danhsachphieurutngay_ngay(a);
        }
        public static DataTable danhsachphieuruttien_ngay_locmaso(int maloai, string ngay, string thang, string nam)
        {
            return PhieuRutTien_DAO.danhsachphieuruttien_ngay_locmaso(maloai, ngay, thang, nam);
        }
        

       
        
    }
    
}
