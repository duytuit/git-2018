using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObject
{
    public interface IPhimFpc
    {
        List<PhimFpcBUS> GetPhimFpc();
        List<PhimFpcBUS> GetPhimFpcById(int idphimfpc);
        List<PhimFpcBUS> GetPhimFpcByDate(DateTime fromdate, DateTime todate);
        List<PhimFpcBUS> SearchPhimFpc(string bophan, string tensanpham, string hientrang);
        int GetMaxSoBoPhimFpc(string masanphan, string loaiphim);
        void InsertPhimFpc(PhimFpcBUS phimfpc);
        void UpdatePhimFpc(PhimFpcBUS phimfpc);
        void DeletePhimFpc(PhimFpcBUS phimfpc);
    }
}
