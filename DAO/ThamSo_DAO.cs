using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using System.Data;

namespace DAO
{
   public static class ThamSo_DAO
    {
       public static float LayGiaTriThamSo(string tenthamso)
       {
           string cautruyvan = "select GiaTri from THAMSO where TenThamSo = '"+tenthamso+"'";
           DataTable bangketqua = DaTaProvider.ThucHienTruyVanTraVeBang(cautruyvan);
           return float.Parse(bangketqua.Rows[0][0].ToString());
       }

       public static long LayMaThamSo(string tenthamso)
       {
           string cautruyvan = "select MaThamSo from THAMSO where TenThamSo = '" + tenthamso + "'";
           DataTable bangketqua = DaTaProvider.ThucHienTruyVanTraVeBang(cautruyvan);
           return long.Parse(bangketqua.Rows[0][0].ToString());
       }


       public static void CapNhatQuyDinh(long mathamso, float giatri)
       {

           string cautruyvan = "update THAMSO set GiaTri=" + giatri + " where MaThamSo=" + mathamso + "";
           DaTaProvider.ThucHienTruyKhongTraVeBang(cautruyvan);

       }
       
    }
}
