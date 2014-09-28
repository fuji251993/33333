using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class BaoCaoNgay_DTO
    {
        private string _MaBaoCaoNgay;

        public string MaBaoCaoNgay
        {
            get { return _MaBaoCaoNgay; }
            set { _MaBaoCaoNgay = value; }
        }
        private DateTime _Ngay;

        public DateTime Ngay
        {
            get { return _Ngay; }
            set { _Ngay = value; }
        }
        private string _MaSo;

        public string MaSo
        {
            get { return _MaSo; }
            set { _MaSo = value; }
        }


     }
}
