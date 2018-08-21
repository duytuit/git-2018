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
       List<PhimPcbBUS> GetPhimPcb();
       List<PhimPcbBUS> GetPhimPcbByDate(DateTime fromdate, DateTime todate);
       List<PhimPcbBUS> GetPhimPcbById(int idphimpcb);
       List<PhimPcbBUS> SearchPhimPcb(string bophan, string tensanpham, string hientrang);
        int GetMaxSoBoPhimPcb(string masanpham, string loaiphim);
        void InsertPhimPcb(PhimPcbBUS phimpcb);
        void UpdatePhimPcb(PhimPcbBUS phimpcb);
        void UpdatePhimPcbByPE(PhimPcbBUS phimpcb);
        void DeletePhimPcb(PhimPcbBUS phimpcb);
    }
}
