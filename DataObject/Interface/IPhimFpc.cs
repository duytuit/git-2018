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
        PhimFpcBUS GetPhimFpc();
        PhimFpcBUS GetPhimFpcById(int idphimfpc);
        PhimFpcBUS GetPhimFpcByDate(DateTime fromdate, DateTime todate);
        int GetMaxSoBoPhimFpc(string masanphan, string loaiphim);
        void InsertPhimFpc(PhimFpcBUS phimfpc);
        void UpdatePhimFpc(PhimFpcBUS phimfpc);
        void DeletePhimFpc(PhimFpcBUS phimfpc);
    }
}
