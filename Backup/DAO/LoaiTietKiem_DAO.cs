using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using System.Data;

namespace DAO
{
    public static class LoaiTietKiem_DAO
    {
        public static List<LoaiTietKiem_DTO> DSLoaiTietKiem()
        {
            string cautruyvan = "select * from LOAITIETKIEM";
            DataTable bangketqua = DaTaProvider.ThucHienTruyVanTraVeBang(cautruyvan);
            //sap xep 
            List<LoaiTietKiem_DTO> danhsachloai = new List<LoaiTietKiem_DTO>();

            foreach (DataRow dong in bangketqua.Rows)
            {
                LoaiTietKiem_DTO Loai = new LoaiTietKiem_DTO();
                Loai.maloaitietkiem = long.Parse(dong["MaLoaiTietKiem"].ToString());
                Loai.tenloaitietkiem = dong["TenLoaiTietKiem"].ToString();
                Loai.laisuat = float.Parse(dong["LaiSuat"].ToString());

                danhsachloai.Add(Loai);
            }
            return danhsachloai;
        }

        public static LoaiTietKiem_DTO LayDSLTK(long maloai)
        {
            string cautruyvan = "select * from LOAITIETKIEM where MaLoaiTietKiem=" + maloai + "";
            DataTable bangketqua = DaTaProvider.ThucHienTruyVanTraVeBang(cautruyvan);

            LoaiTietKiem_DTO Loai = new LoaiTietKiem_DTO();
            Loai.maloaitietkiem = long.Parse(bangketqua.Rows[0][0].ToString());
            Loai.tenloaitietkiem = bangketqua.Rows[0][1].ToString();
            Loai.laisuat = float.Parse(bangketqua.Rows[0][2].ToString());

            return Loai;
        }

        public static long LayMaLoaiTietKiemKhongKyHan(string khongkyhan)
        {
            string cautruyvan = "select MaLoaiTietKiem from LOAITIETKIEM where TenLoaiTietKiem = '" + khongkyhan + "'";
            DataTable bangketqua = DaTaProvider.ThucHienTruyVanTraVeBang(cautruyvan);
            return long.Parse(bangketqua.Rows[0][0].ToString());
        }

        public static string LayTenLoaiTietKiem(long maloaitietkiem)
        {
            string cautruyvan = "select TenLoaiTietKiem from LOAITIETKIEM where MaLoaiTietKiem = " + maloaitietkiem + "";
            DataTable bangketqua = DaTaProvider.ThucHienTruyVanTraVeBang(cautruyvan);
            return bangketqua.Rows[0][0].ToString();
        }

        public static float LayLoaiLaiSuat(string tenloaitietkiem)
        {
            string cautruyvan = "select LaiSuat from LOAITIETKIEM where TenLoaiTietKiem = " + tenloaitietkiem + "";
            DataTable bangketqua = DaTaProvider.ThucHienTruyVanTraVeBang(cautruyvan);
            return float.Parse(bangketqua.Rows[0][0].ToString());
        }

        public static float LayLaiSuatBoiMaLoaiTietKiem(long maloaitietkiem)
        {
            string cautruyvan = "select LaiSuat from LOAITIETKIEM where MaLoaiTietKiem= " + maloaitietkiem + "";
            DataTable bangketqua = DaTaProvider.ThucHienTruyVanTraVeBang(cautruyvan);
            return float.Parse(bangketqua.Rows[0][0].ToString());
        }

        public static long MaLonNhat()
        {
            string cautruyvan = "select MAX(MaLoaiTietKiem) from LOAITIETKIEM";
            DataTable bangketqua = DaTaProvider.ThucHienTruyVanTraVeBang(cautruyvan);

            long malonnhat;

            if (long.TryParse(bangketqua.Rows[0][0].ToString(), out malonnhat) == false)
            {
                return 0;
            }
            return malonnhat;
        }
        public static void ThemLoaiTietKiem(LoaiTietKiem_DTO loaitietkiem)
        {
            string cautruyvan = "Insert into LOAITIETKIEM(MaLoaiTietKiem, TenLoaiTietKiem, LaiSuat) values ('" + loaitietkiem.maloaitietkiem + "', '" + loaitietkiem.tenloaitietkiem+"','"+loaitietkiem.laisuat+"');";
            //System.Windows.Forms.MessageBox.Show(cautruyvan);
            DaTaProvider.ThucHienTruyKhongTraVeBang(cautruyvan);

        }

        public static void CapNhatLoaiTietKiem(long maloaitietkiem, float giatri)
        {

            string cautruyvan = "update LOAITIETKIEM set LaiSuat =" + giatri + " where MaLoaiTietKiem =" + maloaitietkiem + "";
            DaTaProvider.ThucHienTruyKhongTraVeBang(cautruyvan);

        }
        public static DataTable LayTenLoaiTietKiem1(string maloaitietkiem)
        {
            string cautruyvan = "select * from LOAITIETKIEM where MaLoaiTietKiem = " + maloaitietkiem + "";
            DataTable bangketqua = DaTaProvider.ThucHienTruyVanTraVeBang(cautruyvan);
            return bangketqua;
        }
        public static DataTable AllLoaiTietKiem()
        {
            string cautruyvan = "select * from LOAITIETKIEM ";
            DataTable bangketqua = DaTaProvider.ThucHienTruyVanTraVeBang(cautruyvan);
            return bangketqua;
        }
       /* public static void XoaLoaiTietKiem(long maloaitietkiem)
        {
            string cautruyvan = "delete  * from LOAITIETKIEM where MaLoaiTietKiem= " + maloaitietkiem + "";
            DaTaProvider.ThucHienTruyKhongTraVeBang(cautruyvan);
        }*/
    }
}
