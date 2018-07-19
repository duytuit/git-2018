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
        CoDinhTyLePhuSonBUS GetCoDinhTyLePhuSonByID(int idphuson);
        void InsertCoDinhTyLePhuSon(CoDinhTyLePhuSonBUS codinhtylephuson);
        void UpdateCoDinhTyLePhuSon(CoDinhTyLePhuSonBUS codinhtylephuson);
        void DeleteCoDinhTyLePhuSon(CoDinhTyLePhuSonBUS codinhtylephuson);

    }
}
