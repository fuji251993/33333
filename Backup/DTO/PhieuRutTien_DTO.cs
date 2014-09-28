using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class PhieuRutTien_DTO
    {

        protected long _maphieuruttien;
        protected long _maso;
        protected DateTime _ngayrut;
        protected long _sotienrut;
        public long maphieuruttien
        {
            get
            {
                return _maphieuruttien;
            }
            set
            {
                _maphieuruttien = value;
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
        public DateTime ngayrut
        {
            get
            {
                return _ngayrut;
            }
            set
            {
                _ngayrut = value;
            }
        }
        public long sotienrut
        {
            get
            {
                return _sotienrut;
            }
            set
            {
                _sotienrut = value;
            }
        }
    }
}
