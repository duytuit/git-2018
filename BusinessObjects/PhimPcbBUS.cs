﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
   public class PhimPcbBUS
    {
        public int idpcb { get; set; }
        public string ca { get; set; }
        public Nullable<System.DateTime> ngay { get; set; }
        public string gio { get; set; }
        public string bophan { get; set; }
        public string masanpham { get; set; }
        public string phanloai { get; set; }
        public string loaiphim { get; set; }
        public string maydung { get; set; }
        public Nullable<int> sobo { get; set; }
        public string tylex { get; set; }
        public string tyley { get; set; }
        public string nguoiyeucau { get; set; }
        public string noidungyeucau { get; set; }
        public string xacnhanpe { get; set; }
        public string xacnhancam { get; set; }
        public string mayin { get; set; }
        public string hientrang { get; set; }
        public string giohoanthanh { get; set; }
        public string ngayxuatxuong { get; set; }
        public string ngaybaophe { get; set; }
        public string noidungbaophe { get; set; }
    }
}
