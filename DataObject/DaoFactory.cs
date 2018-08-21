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
            get { return new LoaiPhimDao(); }
        }

        public ICoDinhTyLePhuSon CoDinhTyLePhuSon  
        {
            get { return new CoDinhTyLePhuSonDao(); }
        }


        public ICoDinhTyLeTaoMach CoDinhTyLeTaoMach
        {
            get { throw new NotImplementedException(); }
        }

        public IPhimFpc PhimFpc
        {
            get { return new PhimFpcDao(); }
        }

        public IPhimPcb PhimPcb
        {
            get { return new PhimPcbDao(); }
        }

        public IPhimTest PhimTest
        {
            get { return new PhimTestDao(); }
        }

        public IMemBer MemBer
        {
            get { return new MemBerDao(); }
        }
    }
}
