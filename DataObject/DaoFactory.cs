using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObject
{
   public class DaoFactory:IDaoFactory
    {



        public ILoaiPhim LoaiPhim
        {
            get { throw new NotImplementedException(); }
        }

        public ICoDinhTyLePhuSon CoDinhTyLePhuSon  {get { return new CoDinhTyLePhuSonDao(); }}


        public ICoDinhTyLeTaoMach CoDinhTyLeTaoMach
        {
            get { throw new NotImplementedException(); }
        }

        public IPhimFpc PhimFpc
        {
            get { throw new NotImplementedException(); }
        }

        public IPhimPcb PhimPcb
        {
            get { throw new NotImplementedException(); }
        }

        public IPhimTest PhimTest
        {
            get { throw new NotImplementedException(); }
        }
    }
}
