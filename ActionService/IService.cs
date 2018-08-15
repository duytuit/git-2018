using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace ActionService
{
    public interface IService
    {
        //Co Dinh Ty Le Phu Son
        List<CoDinhTyLePhuSonBUS> GetCoDinhTyLePhuSon();
        List<CoDinhTyLePhuSonBUS> GetCoDinhTyLePhuSonByID(int idphuson);
        List<CoDinhTyLePhuSonBUS> GetCoDinhPhusonByDate(DateTime datefrom, DateTime todate);
        List<CoDinhTyLePhuSonBUS> GetCoDinhPhuSonBySanPham(string tensanpham);
        void InsertCoDinhTyLePhuSon(CoDinhTyLePhuSonBUS codinhtylephuson);
        void UpdateCoDinhTyLePhuSon(CoDinhTyLePhuSonBUS codinhtylephuson);
        void DeleteCoDinhTyLePhuSon(CoDinhTyLePhuSonBUS codinhtylephuson);
    }
}
