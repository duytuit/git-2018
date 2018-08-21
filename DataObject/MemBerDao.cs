using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using AutoMapper;

namespace DataObject
{
   public class MemBerDao:IMemBer
    {
        public List<MemBerBUS> GetMemBer()
        {
            using(var context = new datafilmEntities())
            {
                var result = context.SelectMemBer().ToList<ListMemBer>();
                return Mapper.Map<List<ListMemBer>, List<MemBerBUS>>(result);
            }
        }

        public List<MemBerBUS> GetMemBerById(int idmember)
        {
            using(var context = new datafilmEntities())
            {
                var result = context.SelectMemBerById(idmember).ToList<ListMemBer>();
                return Mapper.Map<List<ListMemBer>, List<MemBerBUS>>(result);
            }
        }

        public List<MemBerBUS> GetListMemBer(string production)
        {
            using(var context = new datafilmEntities())
            {
                var result = context.SelectByProduction(production).ToList<ListMemBer>();
                return Mapper.Map<List<ListMemBer>, List<MemBerBUS>>(result);
            }
        }

        public void InsertMemBer(MemBerBUS member)
        {
            using(var context = new datafilmEntities())
            {
                var entity = Mapper.Map<MemBerBUS,ListMemBer>(member);
                context.ListMemBers.Add(entity);
                context.SaveChanges();
            }
        }

        public void UpdateMemBer(MemBerBUS member)
        {
            using(var context = new datafilmEntities())
            {
                var entity = context.ListMemBers.SingleOrDefault(m => m.idmember == member.idmember);
                entity.member = member.member;
                entity.production = member.production;

                context.SaveChanges();
            }
        }

        public void DeleteMemBer(MemBerBUS member)
        {
            using(var context= new datafilmEntities())
            {
                var entity = context.ListMemBers.SingleOrDefault(m => m.idmember == member.idmember);
                context.ListMemBers.Remove(entity);
                context.SaveChanges();
            }
        }
    }
}
