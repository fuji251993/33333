using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class PhieuGoiTien_DTO
    {
        protected long _maphieugoitien;
        protected long _maso;
        protected DateTime _ngaygoi;
        protected long _sotiengoi;
        public long maphieugoitien
        {
            get
            {
                return _maphieugoitien;
            }
            set
            {
                _maphieugoitien = value;
            }
        }
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
        public DateTime ngaygoi
        {
            get
            {
                return _ngaygoi;
            }
            set
            {
                _ngaygoi = value;
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
    }
}
