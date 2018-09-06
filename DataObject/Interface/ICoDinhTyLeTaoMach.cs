using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObject
{
    public interface ICoDinhTyLeTaoMach
    {
        List<CoDinhTyLeTaoMachBUS> GetCoDinhTyLeTaoMach();
        List<CoDinhTyLeTaoMachBUS> GetCoDinhTyLeTaoMachById(int idtaomach);
        List<CoDinhTyLeTaoMachBUS> GetCoDinhTaoMachBySanPham(string tensanpham);
        List<CoDinhTyLeTaoMachBUS> CheckTyLeTaoMach(string tensanpham,string loaiphim);
        void InsertCoDinhTyLeTaoMach(CoDinhTyLeTaoMachBUS codinhtyletaomach);
        void UpdateCoDinhTyLeTaoMach(CoDinhTyLeTaoMachBUS codinhtyletaomach);
        void DeleteCoDinhTyLeTaoMach(CoDinhTyLeTaoMachBUS codinhtyletaomach);
    }
}
