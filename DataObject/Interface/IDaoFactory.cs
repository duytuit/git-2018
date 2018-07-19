using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObject
{
    public interface IDaoFactory
    {
        ILoaiPhim LoaiPhim { get; }
        ICoDinhTyLePhuSon CoDinhTyLePhuSon{get;}
        ICoDinhTyLeTaoMach CoDinhTyLeTaoMach {get;}
        IPhimFpc PhimFpc{get;}
        IPhimPcb PhimPcb{get;}
        IPhimTest PhimTest{get;}

    }
}
