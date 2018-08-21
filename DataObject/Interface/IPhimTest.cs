using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObject
{
    public interface IPhimTest
    {
        List<PhimTestBUS> GetPhimTest();
        List<PhimTestBUS> GetPhimTestById(int idphimtest);
        List<PhimTestBUS> GetPhimTestByDate(DateTime fromdate, DateTime todate);
        List<PhimTestBUS> SearchPhimTest(string bophan, string tensanpham, string hientrang);
        int GetMaxSoBoPhimTest(string masanpham, string loaiphim);
        void InsertPhimTest(PhimTestBUS phimtest);
        void UpdatePhimTest(PhimTestBUS phimtest);
        void DeletePhimtest(PhimTestBUS phimtest);
    }
}
