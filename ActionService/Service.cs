using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataObject;
using System.Configuration;
using WebMatrix.WebData;

namespace ActionService
{
   public class Service : IService
    {
       static readonly string provider = ConfigurationManager.AppSettings.Get("DataProvider");
       static readonly IDaoFactory factory = Factoryes.GetFactory(provider);
       static readonly ICoDinhTyLePhuSon codinhphusonDao = factory.CoDinhTyLePhuSon;
        public List<CoDinhTyLePhuSonBUS> GetCoDinhTyLePhuSon()
        {
           return codinhphusonDao.GetCoDinhTyLePhuSon();
    
        }

        public List<CoDinhTyLePhuSonBUS> GetCoDinhTyLePhuSonByID(int idphuson)
        {
            return codinhphusonDao.GetCoDinhTyLePhuSonBy(idphuson);
        }

        public void InsertCoDinhTyLePhuSon(CoDinhTyLePhuSonBUS codinhtylephuson)
        {
            codinhphusonDao.InsertCoDinhTyLePhuSon(codinhtylephuson);
        }

        public void UpdateCoDinhTyLePhuSon(CoDinhTyLePhuSonBUS codinhtylephuson)
        {
            codinhphusonDao.UpdateCoDinhTyLePhuSon(codinhtylephuson);
        }

        public void DeleteCoDinhTyLePhuSon(CoDinhTyLePhuSonBUS codinhtylephuson)
        {
            codinhphusonDao.DeleteCoDinhTyLePhuSon(codinhtylephuson);
        }
        public List<CoDinhTyLePhuSonBUS> GetCoDinhPhusonByDate(DateTime datefrom, DateTime todate)
        {
          return codinhphusonDao.GetCoDinhPhusonByDate(datefrom, todate);
        }


        public List<CoDinhTyLePhuSonBUS> GetCoDinhPhuSonBySanPham(string tensanpham)
        {
            return codinhphusonDao.GetCoDinhPhuSonBySanPham(tensanpham);
        }
    }
}
