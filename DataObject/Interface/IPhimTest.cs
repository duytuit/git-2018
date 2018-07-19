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
        PhimTestBUS GetPhimTest();
        PhimTestBUS GetPhimTestById(int idphimtest);
        PhimTestBUS GetPhimTestByDate(DateTime fromdate, DateTime todate);
        int GetMaxSoBoPhimTest(string masanpham, string loaiphim);
        void InsertPhimTest(PhimTestBUS phimtest);
        void UpdatePhimTest(PhimTestBUS phimtest);
        void DeletePhimtest(PhimTestBUS phimtest);
    }
}
