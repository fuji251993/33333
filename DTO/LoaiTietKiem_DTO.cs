using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class LoaiTietKiem_DTO
    {
        protected long _maloaitietkiem;
        protected string _tenloaitietkiem;
        protected float _laisuat;
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
