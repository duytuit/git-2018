using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObject
{
    public interface ICoDinhTyLePhuSon
    {
        List<CoDinhTyLePhuSonBUS> GetCoDinhTyLePhuSon();
        List<CoDinhTyLePhuSonBUS> GetCoDinhTyLePhuSonBy(int idphuson);
        List<CoDinhTyLePhuSonBUS> GetCoDinhPhusonByDate(DateTime datefrom, DateTime todate);
        List<CoDinhTyLePhuSonBUS> GetCoDinhPhuSonBySanPham(string tensanpham);
        List<MemBerBUS> GetListMemBer(string production);
        void InsertCoDinhTyLePhuSon(CoDinhTyLePhuSonBUS codinhtylephuson);
        void UpdateCoDinhTyLePhuSon(CoDinhTyLePhuSonBUS codinhtylephuson);
        void DeleteCoDinhTyLePhuSon(CoDinhTyLePhuSonBUS codinhtylephuson);

    }
}
