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

        public CoDinhTyLePhuSonBUS GetCoDinhTyLePhuSonByID(int idphuson)
        {
            throw new NotImplementedException();
        }

        public void InsertCoDinhTyLePhuSon(CoDinhTyLePhuSonBUS codinhtylephuson)
        {
            throw new NotImplementedException();
        }

        public void UpdateCoDinhTyLePhuSon(CoDinhTyLePhuSonBUS codinhtylephuson)
        {
            throw new NotImplementedException();
        }

        public void DeleteCoDinhTyLePhuSon(CoDinhTyLePhuSonBUS codinhtylephuson)
        {
            throw new NotImplementedException();
        }
    }
}
