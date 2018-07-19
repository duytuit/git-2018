using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObject
{
    public interface IPhimPcb
    {
        PhimPcbBUS GetPhimPcb();
        PhimPcbBUS GetPhimPcbByDate(DateTime fromdate, DateTime todate);
        PhimPcbBUS GetPhimPcbById(int idphimpcb);
        int GetMaxSoBoPhimPcb(string masanpham, string loaiphim);
        void InsertPhimPcb(PhimPcbBUS phimpcb);
        void UpdatePhimPcb(PhimPcbBUS phimpcb);
        void DeletePhimPcb(PhimPcbBUS phimpcb);
    }
}
