using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using AutoMapper;

namespace DataObject
{
   public class PhimTestDao:IPhimTest
    {
        public List<PhimTestBUS> GetPhimTest()
        {
           using(var context = new datafilmEntities())
           {
               var result = context.SelectGiamDanTest().ToList<PhimTest>();
               return Mapper.Map<List<PhimTest>, List<PhimTestBUS>>(result);
           }
        }

        public List<PhimTestBUS> GetPhimTestById(int idphimtest)
        {
            throw new NotImplementedException();
        }

        public List<PhimTestBUS> GetPhimTestByDate(DateTime fromdate, DateTime todate)
        {
            throw new NotImplementedException();
        }

        public List<PhimTestBUS> SearchPhimTest(string bophan, string tensanpham, string hientrang)
        {
            throw new NotImplementedException();
        }

        public int GetMaxSoBoPhimTest(string masanpham, string loaiphim)
        {
            throw new NotImplementedException();
        }

        public void InsertPhimTest(PhimTestBUS phimtest)
        {
            throw new NotImplementedException();
        }

        public void UpdatePhimTest(PhimTestBUS phimtest)
        {
            throw new NotImplementedException();
        }

        public void DeletePhimtest(PhimTestBUS phimtest)
        {
            throw new NotImplementedException();
        }
    }
}
