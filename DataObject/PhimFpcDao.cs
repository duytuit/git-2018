using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using AutoMapper;

namespace DataObject
{
   public class PhimFpcDao:IPhimFpc
    {
        public List<PhimFpcBUS> GetPhimFpc()
        {
            using(var context = new datafilmEntities())
            {
                var result = context.SelectGiamDanFpc().ToList<PhimFpc>();
                return Mapper.Map<List<PhimFpc>, List<PhimFpcBUS>>(result);
            }
        }

        public List<PhimFpcBUS> GetPhimFpcById(int idphimfpc)
        {
            using(var context = new datafilmEntities())
            {
                var result = context.SelectIdFpc(idphimfpc).ToList<PhimFpc>();
                return Mapper.Map<List<PhimFpc>, List<PhimFpcBUS>>(result);
            }
        }

        public List<PhimFpcBUS> GetPhimFpcByDate(DateTime fromdate, DateTime todate)
        {
            using (var context = new datafilmEntities())
            {
                var result = context.SelectNgayFpc(fromdate, todate).ToList<PhimFpc>();
                return Mapper.Map<List<PhimFpc>, List<PhimFpcBUS>>(result);
            }
        }

        public int GetMaxSoBoPhimFpc(string masanphan, string loaiphim)
        {
            int sobo;
            using(var context = new datafilmEntities())
            {
                var result = context.MaxSoBo_Fpc(masanphan, loaiphim).First();
                sobo = Convert.ToInt32(result);
                return sobo;
            }
        }

        public List<PhimFpcBUS> SearchPhimFpc(string bophan, string tensanpham, string hientrang)
        {
            using(var context = new datafilmEntities())
            {
                var result = context.SelectGiamDanFpc().ToList<PhimFpc>();
                if (!string.IsNullOrEmpty(bophan))
                {
                    result = context.SearchPhimFpc(bophan, null, null).ToList<PhimFpc>();
                }
                if (!string.IsNullOrEmpty(tensanpham))
                {
                    result = context.SearchPhimFpc(null, tensanpham, null).ToList<PhimFpc>();
                }
                if (!string.IsNullOrEmpty(hientrang))
                {
                    result = context.SearchPhimFpc(null, null, hientrang).ToList<PhimFpc>();
                }
                if (!string.IsNullOrEmpty(bophan) && !string.IsNullOrEmpty(tensanpham))
                {
                    result = context.SearchPhimFpc(bophan, tensanpham, null).ToList<PhimFpc>();
                }
                if (!string.IsNullOrEmpty(bophan) && !string.IsNullOrEmpty(hientrang))
                {
                    result = context.SearchPhimFpc(bophan, null, hientrang).ToList<PhimFpc>();
                }
                if (!string.IsNullOrEmpty(tensanpham) && !string.IsNullOrEmpty(hientrang))
                {
                    result = context.SearchPhimFpc(null, tensanpham, hientrang).ToList<PhimFpc>();
                }
                if (!string.IsNullOrEmpty(bophan) && !string.IsNullOrEmpty(tensanpham) && !string.IsNullOrEmpty(hientrang))
                {
                    result = context.SearchPhimFpc(bophan, tensanpham, hientrang).ToList<PhimFpc>();
                }
                return Mapper.Map<List<PhimFpc>, List<PhimFpcBUS>>(result);
            }
        }

        public void InsertPhimFpc(PhimFpcBUS phimfpc)
        {
            using(var context = new datafilmEntities())
            {
                var entity = Mapper.Map<PhimFpcBUS, PhimFpc>(phimfpc);
                context.PhimFpcs.Add(entity);
                context.SaveChanges();
            }
        }

        public void UpdatePhimFpc(PhimFpcBUS phimfpc)
        {
            using(var context = new datafilmEntities())
            {
                var entity = context.PhimFpcs.SingleOrDefault(p => p.idfpc == phimfpc.idfpc);
        
                entity.bophan = phimfpc.bophan;
                entity.tensanpham = phimfpc.tensanpham;
                entity.phanloai = phimfpc.phanloai;
                entity.loaiphim = phimfpc.loaiphim;
                entity.tylex = phimfpc.tylex;
                entity.tyley = phimfpc.tyley;
                entity.nguoiyeucau = phimfpc.nguoiyeucau;
                entity.noidungyeucau = phimfpc.noidungyeucau;
                entity.xacnhancam = phimfpc.xacnhancam;
                entity.mayin = phimfpc.mayin;
                entity.hientrang = phimfpc.hientrang;
                entity.giohoanthanh = phimfpc.giohoanthanh;
                entity.ngayxuatxuong = phimfpc.ngayxuatxuong;
                entity.ngaybaophe = phimfpc.ngaybaophe;
                entity.noidungbaophe = phimfpc.noidungbaophe;

                context.SaveChanges();
            } 
        }

        public void DeletePhimFpc(PhimFpcBUS phimfpc)
        {
            using(var context = new datafilmEntities())
            {
                var entity = context.PhimFpcs.SingleOrDefault(p => p.idfpc == phimfpc.idfpc);
                context.PhimFpcs.Remove(entity);
                context.SaveChanges();
            }
        }
        
    }
}
