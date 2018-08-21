using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace DataObject
{
   public interface IMemBer
    {
        List<MemBerBUS> GetMemBer();
        List<MemBerBUS> GetMemBerById(int idmember);
        List<MemBerBUS> GetListMemBer(string production);
        void InsertMemBer(MemBerBUS member);
        void UpdateMemBer(MemBerBUS member);
        void DeleteMemBer(MemBerBUS member);
    }
}
