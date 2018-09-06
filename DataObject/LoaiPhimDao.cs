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
   public class LoaiPhimDao : ILoaiPhim
    {
     
        public List<LoaiPhimBUS> GetLoaiPhim()
        {
           using(var context = new datafilmEntities())
           {
               var result = context.SelectLoaiPhim().ToList<LoaiPhim>();
               return Mapper.Map<List<LoaiPhim>, List<LoaiPhimBUS>>(result);
           }
        }

        public void InsertLoaiPhim(LoaiPhimBUS loaiphim)
        {
           using(var context = new datafilmEntities())
           {
               var entity = Mapper.Map<LoaiPhimBUS,LoaiPhim>(loaiphim);
               context.LoaiPhims.Add(entity);

               context.SaveChanges();
           }
        }

        public void UpdateLoaiPhim(LoaiPhimBUS loaiphim)
        {
          using (var context = new datafilmEntities())
          {
              var entity = context.LoaiPhims.SingleOrDefault(l => l.idloaiphim == loaiphim.idloaiphim);
              entity.loaiphim = loaiphim.loaiphim;
              entity.bophan = loaiphim.bophan;
              context.SaveChanges();
          }
        }

        public void DeleteLoaiPhim(LoaiPhimBUS loaiphim)
        {
            using(var context = new datafilmEntities())
            {
                var entity = context.LoaiPhims.SingleOrDefault(l => l.idloaiphim == loaiphim.idloaiphim);
                context.LoaiPhims.Remove(entity);
                context.SaveChanges();
            }
        }


        public List<LoaiPhimBUS> GetLoaiPhimById(int idloaiphim)
        {
            using(var context = new datafilmEntities())
            {
                var result = context.SelectIdLoaiPhim(idloaiphim).ToList<LoaiPhim>();
                return Mapper.Map<List<LoaiPhim>, List<LoaiPhimBUS>>(result);
            }
        }


        public List<LoaiPhimBUS> GetLoaiPhimByBoPhan(string bophan)
        {
            using(var context = new datafilmEntities())
            {
                var result = context.SelectLoaiPhimByBoPhan(bophan).ToList<LoaiPhim>();
                return Mapper.Map<List<LoaiPhim>, List<LoaiPhimBUS>>(result);
            }
        }
    }
}
