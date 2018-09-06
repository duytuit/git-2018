using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using AutoMapper;

namespace DataObject
{
   public class CoDinhTaoMachDao:ICoDinhTyLeTaoMach
    {
        public List<CoDinhTyLeTaoMachBUS> GetCoDinhTyLeTaoMach()
        {
            using(var context= new datafilmEntities())
            {
                var result = context.SelectTaoMach().ToList<CoDinhTyLeTaoMach>();
                return Mapper.Map<List<CoDinhTyLeTaoMach>, List<CoDinhTyLeTaoMachBUS>>(result);
            }
        }

        public List<CoDinhTyLeTaoMachBUS> GetCoDinhTyLeTaoMachById(int idtaomach)
        {
           using(var context= new datafilmEntities())
           {
               var result = context.SelectIdTaoMach(idtaomach).ToList<CoDinhTyLeTaoMach>();
               return Mapper.Map<List<CoDinhTyLeTaoMach>,List<CoDinhTyLeTaoMachBUS>>(result);
           }
        }

        public List<CoDinhTyLeTaoMachBUS> GetCoDinhTaoMachBySanPham(string tensanpham)
        {
            using(var context = new datafilmEntities())
            {
                var result = context.SelectTaoMachBySanPham(tensanpham).ToList<CoDinhTyLeTaoMach>();
                return Mapper.Map<List<CoDinhTyLeTaoMach>, List<CoDinhTyLeTaoMachBUS>>(result);
            }
        }

        public List<CoDinhTyLeTaoMachBUS> CheckTyLeTaoMach(string tensanpham, string loaiphim)
        {
            using(var context = new datafilmEntities())
            {
                var result = context.CheckTaoMach(tensanpham, loaiphim).ToList<CoDinhTyLeTaoMach>();
                return Mapper.Map<List<CoDinhTyLeTaoMach>, List<CoDinhTyLeTaoMachBUS>>(result);
            }
        }

        public void InsertCoDinhTyLeTaoMach(CoDinhTyLeTaoMachBUS codinhtyletaomach)
        {
            using(var context = new datafilmEntities())
            {
                var entity = Mapper.Map<CoDinhTyLeTaoMachBUS, CoDinhTyLeTaoMach>(codinhtyletaomach);
               
                entity.ngaytao = codinhtyletaomach.ngaytao;
                entity.nguoitao = codinhtyletaomach.nguoitao;
                entity.tensanpham = codinhtyletaomach.tensanpham;
                entity.loaiphim = codinhtyletaomach.loaiphim;
                entity.tylex = codinhtyletaomach.tylex;
                entity.tyley = codinhtyletaomach.tyley;
                context.CoDinhTyLeTaoMaches.Add(entity);
                context.SaveChanges();

            }
        }

        public void UpdateCoDinhTyLeTaoMach(CoDinhTyLeTaoMachBUS codinhtyletaomach)
        {
            using(var context = new datafilmEntities())
            {
                var entity = context.CoDinhTyLeTaoMaches.SingleOrDefault(c => c.idtaomach == codinhtyletaomach.idtaomach);
                entity.ngaytao = codinhtyletaomach.ngaytao;
                entity.nguoitao = codinhtyletaomach.nguoitao;
                entity.tensanpham = codinhtyletaomach.tensanpham;
                entity.loaiphim = codinhtyletaomach.loaiphim;
                entity.tylex = codinhtyletaomach.tylex;
                entity.tyley = codinhtyletaomach.tyley;

                context.SaveChanges();
            }
        }

        public void DeleteCoDinhTyLeTaoMach(CoDinhTyLeTaoMachBUS codinhtyletaomach)
        {
            using (var context = new datafilmEntities())
            {
                var entity = context.CoDinhTyLeTaoMaches.SingleOrDefault(c => c.idtaomach == codinhtyletaomach.idtaomach);
                context.CoDinhTyLeTaoMaches.Remove(entity);

                context.SaveChanges();
            }
        }
    }
}
