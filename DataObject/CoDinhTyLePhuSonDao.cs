﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using AutoMapper;

namespace DataObject
{
   public class CoDinhTyLePhuSonDao : ICoDinhTyLePhuSon
    {

        static CoDinhTyLePhuSonDao()
         {
             Mapper.Initialize(cfg=>{
                 cfg.CreateMap<CoDinhTyLePhuSon, CoDinhTyLePhuSonBUS>().ReverseMap();
           });
          }


        public List<CoDinhTyLePhuSonBUS> GetCoDinhTyLePhuSon()
        {
            using(var context = new datafilmEntities())
            {
                var codinhtylephuson = context.SelectPhuSon().ToList<CoDinhTyLePhuSon>();
                return Mapper.Map<List<CoDinhTyLePhuSon>, List<CoDinhTyLePhuSonBUS>>(codinhtylephuson);
            }
        }

        public CoDinhTyLePhuSonBUS GetCoDinhTyLePhuSonByID(int idphuson)
        {
            using (var context = new datafilmEntities())
            {
                var result = context.SelectIdPhuSon(idphuson).AsQueryable() as CoDinhTyLePhuSon;
                return Mapper.Map<CoDinhTyLePhuSon,CoDinhTyLePhuSonBUS>(result);
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
    }
}
