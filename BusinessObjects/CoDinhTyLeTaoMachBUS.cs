using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
   public class CoDinhTyLeTaoMachBUS
    {
        public int idtaomach { get; set; }
        public Nullable<System.DateTime> ngaytao { get; set; }
        public string nguoitao { get; set; }
        public string tensanpham { get; set; }
        public string loaiphim { get; set; }
        public string tylex { get; set; }
        public string tyley { get; set; }
    }
}
