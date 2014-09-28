using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class TraCuuSo_DTO
    {
        protected long _maso;
        protected long _maloaitietkiem;
        protected string _khachhang;
        protected string _cmnd;
        protected string _diachi;
        protected DateTime _ngaymoso;
        protected float _sotiengoi;
        protected float _tongtien;
        protected bool _tinhtrang;
        protected string _tenloaitietkiem;
        protected float _laisuat;

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
        public string khachhang
        {
            get
            {
                return _khachhang;
            }
            set
            {
                _khachhang = value;
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

        public DateTime ngaymoso
        {
            get
            {
                return _ngaymoso;
            }
            set
            {
                _ngaymoso = value;
            }
        }
        public float sotiengoi
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
        public float tongtien
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
        public string tenloaitietkiem
        {
            get
            {
                return _tenloaitietkiem;
            }
            set
            {
                _tenloaitietkiem = value;
            }
        }
        public float laisuat
        {
            get
            {
                return _laisuat;
            }
            set
            {
                _laisuat = value;
            }
        }
    }
}
