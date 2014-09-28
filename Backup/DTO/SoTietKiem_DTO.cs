using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
   public class SoTietKiem_DTO
    {
        protected long _maso;
        protected string _tenkhachhang;
        protected string _cmnd;
        protected string _diachi;
        protected long _maloaitietkiem;
        protected DateTime _ngaymo;
        protected long _tongtien;
        protected long _sotiengoi;
        protected bool _tinhtrang;
        
       public long maso
        {
            get
            {
                return _maso;
            }
            set
            {
                _maso = value;
            }
        }
        public string tenkhachhang
        {
            get
            {
                return _tenkhachhang;
            }
            set
            {
                _tenkhachhang = value;
            }
        }
        public string cmnd
        {
            get
            {
                return _cmnd;
            }
            set
            {
                _cmnd = value;
            }
        }
       public string diachi
        {
            get
            {
                return _diachi;
            }
            set
            {
                _diachi = value;
            }
        }
       public long maloaitietkiem
        {
            get
            {
                return _maloaitietkiem;
            }
            set
            {
                _maloaitietkiem = value;
            }
        }
         public DateTime ngaymo
        {
            get
            {
                return _ngaymo;
            }
            set
            {
                _ngaymo = value;
            }
        }
       public long sotiengoi
        {
            get
            {
                return _sotiengoi;
            }
            set
            {
                _sotiengoi = value;
            }
        }
       public long tongtien
        {
            get
            {
                return _tongtien;
            }
            set
            {
                _tongtien = value;
            }
        }
       public bool tinhtrang
       {
           get
           {
               return _tinhtrang;
           }
           set
           {
               _tinhtrang = value;
           }
       }



       }

    
}
