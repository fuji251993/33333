using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
   public  class ThamSo_DTO
    {
       protected long _mathamso;
       protected string _tenthamso;
       protected float _giatri;
       public long mathamso
       {
           get
           {
               return _mathamso;
           }
           set
           {
               _mathamso = value;
           }
       }
       public string tenthamso
       {
           get
           {
               return _tenthamso;
           }
           set
           {
               _tenthamso = value;
           }
       }
       public float giatri
       {
           get
           {
               return _giatri;
           }
           set
           {
               _giatri = value;
           }
       }
    }
}
