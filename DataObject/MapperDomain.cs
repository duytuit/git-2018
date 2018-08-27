using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using AutoMapper;

namespace DataObject
{
   public static class MapperDomain
    {
      public static void MapperConfig()
       {
           Mapper.Initialize(cfg =>
           {
               cfg.CreateMap<CoDinhTyLePhuSon, CoDinhTyLePhuSonBUS>().ReverseMap();
               cfg.CreateMap<ListMemBer, MemBerBUS>().ReverseMap();
               cfg.CreateMap<LoaiPhim, LoaiPhimBUS>().ReverseMap();
               cfg.CreateMap<PhimPcb, PhimPcbBUS>().ReverseMap();
           });
       }
    }
}
