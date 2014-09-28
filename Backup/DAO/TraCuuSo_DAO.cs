using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using System.Data;

namespace DAO
{
    public static class TraCuuSo_DAO
    {
        public static List<TraCuuSo_DTO> LayDSSOTKThoaTraCuu1(string khachhang, string diachi, float tongtien1, float tongtien2, DateTime ngay1, DateTime ngay2, string tenloaitietkiem, string cmnd, bool tinhtrang)
        {
            string cautruyvan = "select * from SOTIETKIEM s,LOAITIETKIEM l where s.MaLoaiTietKiem=l.MaLoaiTietKiem";
            if (khachhang != "")
            {
                cautruyvan = cautruyvan + " and TenKhachHang like '%" + khachhang + "%'";
            }
            if (tenloaitietkiem != "")
            {
                cautruyvan = cautruyvan + " and TenLoaiTietKiem like '%" + tenloaitietkiem + "%'";
            }
            if (diachi != "")
            {
                cautruyvan = cautruyvan + " and DiaChi like '%" + diachi + "%'";

            }
            if (tongtien1 != -1)
            {
                cautruyvan = cautruyvan + " and TongTien > " + tongtien1 + "";

            }
            if (tongtien2 != -1)
            {
                cautruyvan = cautruyvan + " and TongTien < " + tongtien2 + "";
            } 
            if (ngay1.ToString() != "")
            {
                cautruyvan = cautruyvan + " and NgayMoSo > #" + ngay1.Date + "#";

            } 
            if (ngay2.ToString() != "")
            {
                cautruyvan = cautruyvan + " and NgayMoSo < #" + ngay2 + "#"; 
            }
            if (cmnd.ToString() != "")
            {
                cautruyvan = cautruyvan + " and CMND like '%" + cmnd + "%'"; 
            } 
            cautruyvan = cautruyvan + " and TinhTrang=" + tinhtrang + "";
            DataTable bangketqua = DaTaProvider.ThucHienTruyVanTraVeBang(cautruyvan);
            if (bangketqua.Rows.Count == 0)
            {
                return null;
            }
            List<TraCuuSo_DTO> danhsachso = new List<TraCuuSo_DTO>();
            foreach (DataRow dong in bangketqua.Rows)
            {
                TraCuuSo_DTO so = new TraCuuSo_DTO();
                so.maso = long.Parse(dong["MaSo"].ToString());
                so.maloaitietkiem = long.Parse(dong["l.MaLoaiTietKiem"].ToString());
                so.khachhang = dong["TenKhachHang"].ToString();
                so.cmnd = dong["CMND"].ToString();
                so.diachi = dong["DiaChi"].ToString();
                so.ngaymoso = DateTime.Parse(dong["NgayMoSo"].ToString());
                so.sotiengoi = float.Parse(dong["SoTienGoi"].ToString());
                so.tongtien = float.Parse(dong["TongTien"].ToString());
                so.tinhtrang = bool.Parse(dong["TinhTrang"].ToString());
                so.tenloaitietkiem = dong["TenLoaiTietKiem"].ToString();
                so.laisuat = float.Parse(dong["LaiSuat"].ToString());
                danhsachso.Add(so);
            }
            return danhsachso;
        }
        public static DataTable LayDSSOTKThoaTraCuu_KhongTraCuuNgay(string khachhang, string diachi, float tongtien1, float tongtien2, string tenloaitietkiem, string cmnd, bool tinhtrang)
        {
            string cautruyvan = "select * from SOTIETKIEM s,LOAITIETKIEM l where s.MaLoaiTietKiem=l.MaLoaiTietKiem";
            if (khachhang != "")
            {
                cautruyvan = cautruyvan + " and TenKhachHang like '%" + khachhang + "%'";
            }
            if (tenloaitietkiem != "")
            {
                cautruyvan = cautruyvan + " and TenLoaiTietKiem like '%" + tenloaitietkiem + "%'";
            }
            if (diachi != "")
            {
                cautruyvan = cautruyvan + " and DiaChi like '%" + diachi + "%'";

            }
            if (tongtien1 != -1)
            {
                cautruyvan = cautruyvan + " and TongTien > " + tongtien1 + "";

            }
            if (tongtien2 != -1)
            {
                cautruyvan = cautruyvan + " and TongTien < " + tongtien2 + "";
            }
            if (cmnd.ToString() != "")
            {
                cautruyvan = cautruyvan + " and CMND like '%" + cmnd + "%'";
            }
            cautruyvan = cautruyvan + " and TinhTrang=" + tinhtrang + "";
            DataTable bangketqua = DaTaProvider.ThucHienTruyVanTraVeBang(cautruyvan);
            if (bangketqua.Rows.Count == 0)
            {
                return null;
            } 
            return bangketqua;
        }
        public static DataTable LayDSSTKThoaTraCuu2(long maso)
        {
            string cautruyvan = "select * from SOTIETKIEM s,LOAITIETKIEM l where s.MaLoaiTietKiem=l.MaLoaiTietKiem and MaSo=" + maso + "";
            DataTable bangketqua = DaTaProvider.ThucHienTruyVanTraVeBang(cautruyvan);
            if (bangketqua.Rows.Count == 0)
            {
                return null;
            }  
            return bangketqua;
        }

    }
}
