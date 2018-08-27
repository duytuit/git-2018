using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using AutoMapper;
using System.Data;

namespace DataObject
{
   public class CoDinhTyLePhuSonDao : ICoDinhTyLePhuSon
    {
       //static  CoDinhTyLePhuSonDao()
       //{
       //    Mapper.Initialize(cfg =>
       //    {
       //        cfg.CreateMap<CoDinhTyLePhuSon, CoDinhTyLePhuSonBUS>().ReverseMap();
       //        cfg.CreateMap<ListMemBer, MemBerBUS>().ReverseMap();
       //        cfg.CreateMap<LoaiPhim, LoaiPhimBUS>().ReverseMap();
       //        cfg.CreateMap<PhimPcb, PhimPcbBUS>().ReverseMap();
       //    });
       //}
        public List<CoDinhTyLePhuSonBUS> GetCoDinhTyLePhuSon()
        {
            using(var context = new datafilmEntities())
            {
                var codinhtylephuson = context.SelectPhuSon().ToList<CoDinhTyLePhuSon>();
                return Mapper.Map<List<CoDinhTyLePhuSon>, List<CoDinhTyLePhuSonBUS>>(codinhtylephuson);
            }
        }

        public List<CoDinhTyLePhuSonBUS> GetCoDinhTyLePhuSonBy(int idphuson)
        {
            using (var context = new datafilmEntities())
            {
                var result = context.SelectIdPhuSon(idphuson).ToList<CoDinhTyLePhuSon>();
                return Mapper.Map<List<CoDinhTyLePhuSon>,List< CoDinhTyLePhuSonBUS>>(result);
           
            }
        }

        public void InsertCoDinhTyLePhuSon(CoDinhTyLePhuSonBUS codinhtylephuson)
        {
            using (var context = new datafilmEntities())
            {
                var entity = Mapper.Map<CoDinhTyLePhuSonBUS, CoDinhTyLePhuSon>(codinhtylephuson);
                context.CoDinhTyLePhuSons.Add(entity);
                context.SaveChanges();
            }

        }

        public void UpdateCoDinhTyLePhuSon(CoDinhTyLePhuSonBUS codinhtylephuson)
        {

            using (var context = new datafilmEntities())
            {
                var entity = context.CoDinhTyLePhuSons.SingleOrDefault(c => c.idphuson == codinhtylephuson.idphuson);
                entity.tensanpham = codinhtylephuson.tensanpham;
                entity.ngaytao = codinhtylephuson.ngaytao;
                entity.nguoitao = codinhtylephuson.nguoitao;
                entity.loaiphim = codinhtylephuson.loaiphim;
                entity.tylexmin = codinhtylephuson.tylexmin;
                entity.tylexmax = codinhtylephuson.tylexmax;
                entity.tyleymin = codinhtylephuson.tyleymin;
                entity.tyleymax = codinhtylephuson.tyleymax;
       
                context.SaveChanges();
            }
        }

        public void DeleteCoDinhTyLePhuSon(CoDinhTyLePhuSonBUS codinhtylephuson)
        {
            using (var context = new datafilmEntities())
            {
                var entity = context.CoDinhTyLePhuSons.SingleOrDefault(c => c.idphuson == codinhtylephuson.idphuson);
                context.CoDinhTyLePhuSons.Remove(entity);
                context.SaveChanges();

            }
        }


        public List<CoDinhTyLePhuSonBUS> GetCoDinhPhusonByDate(DateTime datefrom, DateTime todate)
        {
            using(var context = new datafilmEntities())
            {
                var result = context.SelectByDateCoDinhPhuSon(datefrom, todate).ToList<CoDinhTyLePhuSon>();
                return Mapper.Map<List<CoDinhTyLePhuSon>,List< CoDinhTyLePhuSonBUS>>(result);
            }
        }


        public List<CoDinhTyLePhuSonBUS> GetCoDinhPhuSonBySanPham(string tensanpham)
        {
            using (var context = new datafilmEntities())
            {
                var result = context.SelectCoDinhPhuSonBySanPham(tensanpham).ToList<CoDinhTyLePhuSon>();
                return Mapper.Map<List<CoDinhTyLePhuSon>, List<CoDinhTyLePhuSonBUS>>(result);
            }
        }
    }
}
