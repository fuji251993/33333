using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using System.Data;

namespace DAO
{
    public static class SoTietKiem_DAO
    {
        public static long MaLonNhat()
        {
            string cautruyvan = "select MAX(MaSo) from SOTIETKIEM";
            DataTable bangketqua = DaTaProvider.ThucHienTruyVanTraVeBang(cautruyvan); 
            long malonnhat; 
            if (long.TryParse(bangketqua.Rows[0][0].ToString(), out malonnhat) == false)
            {
                return 0;
            }
            return malonnhat;
        }

        public static void LapSoTK(SoTietKiem_DTO sotietkiem)
        {
            string cautruyvan = "Insert into SOTIETKIEM(MaLoaiTietKiem, TenKhachHang, CMND, DiaChi, NgayMoSo, SoTienGoi,TongTien,TinhTrang) values ('" + sotietkiem.maloaitietkiem + "', '" + sotietkiem.tenkhachhang + "', '" + sotietkiem.cmnd + "', '" + sotietkiem.diachi + "', '" + sotietkiem.ngaymo + "', " + sotietkiem.sotiengoi + ","+sotietkiem.sotiengoi+",true);";
            //System.Windows.Forms.MessageBox.Show(cautruyvan);
            DaTaProvider.ThucHienTruyKhongTraVeBang(cautruyvan); 
        }

        public static void CapNhatTongTien(float tongtienmoi, long maso)
        {
            string cautruyvan = "update SOTIETKIEM set TongTien=" + tongtienmoi + " where MaSo=" + maso + "";
            DaTaProvider.ThucHienTruyKhongTraVeBang(cautruyvan);
        } 
        public static void CapNhatSoTietKiem(SoTietKiem_DTO sotietkiem)
        {
            string cautruyvan = "update SOTIETKIEM set   MaLoaiTietKiem=" + sotietkiem.maloaitietkiem +
                                                        ", TenKhachHang='" + sotietkiem.tenkhachhang +"'"+
                                                         ", CMND=" + sotietkiem.cmnd  +
                                                          ", DiaChi='" + sotietkiem.diachi + "'" +
                                                           ", NgayMoSo='" + sotietkiem.ngaymo + "'" +
                                                        ", SoTienGoi=" + sotietkiem.sotiengoi  +
                                                        ", TongTien=" + sotietkiem.tongtien +
                                                        ", TinhTrang=" + sotietkiem.tinhtrang +
                                                        " where MaSo=" + sotietkiem.maso + "";
            DaTaProvider.ThucHienTruyKhongTraVeBang(cautruyvan);
        }
        public static SoTietKiem_DTO LayThongTinSoTietKiem(long maso)
        {
            string cautruyvan = "select * from SOTIETKIEM where MaSo=" + maso + "";
            DataTable bangketqua = DaTaProvider.ThucHienTruyVanTraVeBang(cautruyvan);

            if (bangketqua == null || bangketqua.Rows.Count == 0)
            {
                return null;
            }

            SoTietKiem_DTO SoTK =new SoTietKiem_DTO();
            SoTK.maso = long.Parse(bangketqua.Rows[0][0].ToString());
            SoTK.maloaitietkiem = long.Parse(bangketqua.Rows[0][1].ToString());
            SoTK.tenkhachhang = bangketqua.Rows[0][2].ToString();
            SoTK.cmnd = bangketqua.Rows[0][3].ToString();
            SoTK.diachi = bangketqua.Rows[0][4].ToString();
            SoTK.ngaymo = DateTime.Parse(bangketqua.Rows[0][5].ToString());
            SoTK.sotiengoi = long.Parse(bangketqua.Rows[0][6].ToString());
            SoTK.tongtien = long.Parse(bangketqua.Rows[0][7].ToString());
            SoTK.tinhtrang = bool.Parse(bangketqua.Rows[0][8].ToString());

            return SoTK;
        } 
        public static long LayMaLoaiTietKiem(long maso)
        {
            string cautruyvan = "select MaLoaiTietKiem from SOTIETKIEM where MaSo = " + maso + "";
            DataTable bangketqua = DaTaProvider.ThucHienTruyVanTraVeBang(cautruyvan);
            return long.Parse(bangketqua.Rows[0][0].ToString());
        }

        public static DateTime LayNgayMoSo(long maso)
        {
            string cautruyvan = "select NgayMoSo from SOTIETKIEM where MaSo = " + maso + "";
            //System.Windows.Forms.MessageBox.Show(cautruyvan);
            DataTable bangketqua = DaTaProvider.ThucHienTruyVanTraVeBang(cautruyvan);
            return DateTime.Parse(bangketqua.Rows[0][0].ToString());
        }
        public static void CapNhatTinhTrangSo(long maso,bool tinhtrang)
        {
            string cautruyvan = "update SOTIETKIEM set TinhTrang =" + tinhtrang + " where MaSo=" + maso + "";
            DaTaProvider.ThucHienTruyKhongTraVeBang(cautruyvan);
        }

        public static List<SoTietKiem_DTO> ListSo()
        {
            string cautruyvan = "select * from SOTIETKIEM";
            DataTable bangketqua = DaTaProvider.ThucHienTruyVanTraVeBang(cautruyvan);
            if (bangketqua.Rows.Count == 0)
            {
                return null;
            }

            List<SoTietKiem_DTO> danhsachso = new List<SoTietKiem_DTO>();
            foreach (DataRow dong in bangketqua.Rows)
            {
                SoTietKiem_DTO so = new SoTietKiem_DTO();
                so.maso = long.Parse(dong["MaSo"].ToString());
                so.tenkhachhang = dong["TenKhachHang"].ToString();
                so.maloaitietkiem = long.Parse(dong["MaLoaiTietKiem"].ToString());
                so.cmnd = dong["CMND"].ToString();
                so.diachi = dong["DiaChi"].ToString();
                so.ngaymo = DateTime.Parse(dong["NgayMoSo"].ToString());
                so.sotiengoi = long.Parse(dong["SoTienGoi"].ToString());
                so.tongtien = long.Parse(dong["TongTien"].ToString());
                so.tinhtrang = bool.Parse(dong["TinhTrang"].ToString());
                danhsachso.Add(so);
            }
            return danhsachso;
        }
        public static List<SoTietKiem_DTO> ListSoMo()
        {
            string cautruyvan = "select * from SOTIETKIEM where MaLoaiTietKiem=3 and TinhTrang=true ";
            DataTable bangketqua = DaTaProvider.ThucHienTruyVanTraVeBang(cautruyvan);
            if (bangketqua.Rows.Count == 0)
            {
                return null;
            }
            List<SoTietKiem_DTO> danhsachso = new List<SoTietKiem_DTO>();
            foreach (DataRow dong in bangketqua.Rows)
            {
                SoTietKiem_DTO so = new SoTietKiem_DTO();
                so.maso = long.Parse(dong["MaSo"].ToString());
                so.tenkhachhang = dong["TenKhachHang"].ToString();
                so.maloaitietkiem = long.Parse(dong["MaLoaiTietKiem"].ToString());
                so.cmnd = dong["CMND"].ToString();
                so.diachi = dong["DiaChi"].ToString();
                so.ngaymo = DateTime.Parse(dong["NgayMoSo"].ToString());
                so.sotiengoi = long.Parse(dong["SoTienGoi"].ToString());
                so.tongtien = long.Parse(dong["TongTien"].ToString());
                so.tinhtrang = bool.Parse(dong["TinhTrang"].ToString());
                danhsachso.Add(so);
            }
            return danhsachso;
        }
        public static DataTable BaoCaoNgay( string t)
        {
            string cautruyvan = "select * from SOTIETKIEM where NGAYMOSO = #"+ t +"#";
            DataTable bangketqua = DaTaProvider.ThucHienTruyVanTraVeBang(cautruyvan);



            return bangketqua;
        }

        public static DataTable BangLocNgay(string thang, string nam)
        {
            string cautruyvan = "SELECT  * FROM SOTIETKIEM , LOAITIETKIEM  Where month(NgayMoSo) = " + thang + " and year(NgayMoSo) =" + nam + " and SOTIETKIEM.MaLoaiTietKiem=LOAITIETKIEM.MaLoaiTietKiem";
            DataTable bangketqua = DaTaProvider.ThucHienTruyVanTraVeBang(cautruyvan);
            return bangketqua;

        }
        public static DataTable BangLocNgay_TheoThang(string thang, string nam)
        {
            string cautruyvan = "select  DISTINCT NgayMoSo from (SELECT  * FROM SOTIETKIEM Where month(NgayMoSo) = " + thang + " and year(NgayMoSo) =" + nam + ")";
            DataTable bangketqua = DaTaProvider.ThucHienTruyVanTraVeBang(cautruyvan);
            return bangketqua;

        }
        public static DataTable SoTietKiem(string t)
        {
            string cautruyvan = "select * from SOTIETKIEM where MaSo = " + t + "";
            DataTable bangketqua = DaTaProvider.ThucHienTruyVanTraVeBang(cautruyvan);
            return bangketqua;
        }
        public static bool DeleteLoai(string MaSo)
        {

            String strSQL = "Delete From SoTietKiem";
            strSQL += " where MaSo= " + MaSo.ToString() + "";
            DaTaProvider.ThucHienTruyKhongTraVeBang(strSQL);
            return true;


        }
        public static DataTable So_Mo(string ngay, string thang, string nam, string maloaitk)
        {
            string cautruyvan = "select * FROM SOTIETKIEM Where tinhtrang=true and MaloaiTietKiem =" + maloaitk +
                                " and day(NgayMoSo)=" + ngay + " and month(NgayMoSo) = " + thang + " and year(NgayMoSo) =" + nam + "";
            DataTable bangketqua = DaTaProvider.ThucHienTruyVanTraVeBang(cautruyvan);
            return bangketqua;
        }
        public static DataTable All_So_Dong(string ngay)
        {
            string cautruyvan = "select * FROM BAOCAOTHANG Where DateValue(Thang)=#" + ngay + "#";

            DataTable bangketqua = DaTaProvider.ThucHienTruyVanTraVeBang(cautruyvan);
            return bangketqua;
        }
    }

}
