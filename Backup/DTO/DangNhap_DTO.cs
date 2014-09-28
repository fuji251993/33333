using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    class DangNhap_DTO
    {
        private string _TenUSer;

        public string TenUSer
        {
            get { return _TenUSer; }
            set { _TenUSer = value; }
        }
        private string _MaKhau;

        public string MaKhau
        {
            get { return _MaKhau; }
            set { _MaKhau = value; }
        }
    }
}
