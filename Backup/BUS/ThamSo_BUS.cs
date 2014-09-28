using System;
using System.Collections.Generic;
using System.Text;
using DAO;
using DTO;

namespace BUS
{
  public static  class ThamSo_BUS
    {
      public static float SoTienGoiToiThieu()
      {
          return ThamSo_DAO.LayGiaTriThamSo("SoTienGoiToiThieu");
      }

      public static float SoTienGoiThemToiThieu()
      {
          return ThamSo_DAO.LayGiaTriThamSo("SoTienGoiThemToiThieu");
      }

      public static float SoNgayDaGoi()
      {
          return ThamSo_DAO.LayGiaTriThamSo("ThoiHanDuocRut");
      }
      public static long LayMaThamSo(string temthamso)
      {
          return ThamSo_DAO.LayMaThamSo(temthamso);
      }

      public static void ThayDoiQuyDinh(long mathamso, float giatri)
      {
          ThamSo_DAO.CapNhatQuyDinh(mathamso, giatri);
      }
    
    }
}
