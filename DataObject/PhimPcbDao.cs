using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using AutoMapper;

namespace DataObject
{
   public class PhimPcbDao:IPhimPcb
    {

        public List<PhimPcbBUS> GetPhimPcb()
        {
            using(var context = new datafilmEntities())
            {
                var result = context.SelectGiamDanPhimPcb().ToList<PhimPcb>();
                return Mapper.Map<List<PhimPcb>, List<PhimPcbBUS>>(result);
            }
        }

        public List<PhimPcbBUS> GetPhimPcbByDate(DateTime fromdate, DateTime todate)
        {
            using(var context = new datafilmEntities())
            {
                var result = context.SelectNgayPcb(fromdate, todate).ToList<PhimPcb>();
                return Mapper.Map<List<PhimPcb>, List<PhimPcbBUS>>(result);
            }
        }

        public List<PhimPcbBUS> GetPhimPcbById(int idphimpcb)
        {
            using(var context = new datafilmEntities())
            {
                var result = context.SelectIdPcb(idphimpcb).ToList<PhimPcb>();
                return Mapper.Map<List<PhimPcb>, List<PhimPcbBUS>>(result);
            }
        }

        public List<PhimPcbBUS> SearchPhimPcb(string bophan, string tensanpham, string hientrang)
        {
            using(var context = new datafilmEntities())
            {
                var result = context.SelectGiamDanPhimPcb().ToList<PhimPcb>();
                if(!string.IsNullOrEmpty(bophan))
                {
                    result = context.SearchPcb(bophan, null, null).ToList<PhimPcb>();
                }
                if(!string.IsNullOrEmpty(tensanpham))
                {
                    result = context.SearchPcb(null, tensanpham, null).ToList<PhimPcb>();
                }
                if(!string.IsNullOrEmpty(hientrang))
                {
                    result = context.SearchPcb(null, null, hientrang).ToList<PhimPcb>();
                }
                if(!string.IsNullOrEmpty(bophan)&&!string.IsNullOrEmpty(tensanpham))
                {
                    result = context.SearchPcb(bophan, tensanpham, null).ToList<PhimPcb>();
                }
                if(!string.IsNullOrEmpty(bophan)&&!string.IsNullOrEmpty(hientrang))
                {
                    result = context.SearchPcb(bophan, null, hientrang).ToList<PhimPcb>();
                }
                if(!string.IsNullOrEmpty(tensanpham)&&!string.IsNullOrEmpty(hientrang))
                {
                    result = context.SearchPcb(null, tensanpham, hientrang).ToList<PhimPcb>();
                }
                if(!string.IsNullOrEmpty(bophan)&&!string.IsNullOrEmpty(tensanpham)&&!string.IsNullOrEmpty(hientrang))
                {
                    result = context.SearchPcb(bophan, tensanpham, hientrang).ToList<PhimPcb>();
                }
                return Mapper.Map<List<PhimPcb>, List<PhimPcbBUS>>(result);
            }
        }

        public int GetMaxSoBoPhimPcb(string masanpham, string loaiphim)
        {
            int sobo = 0;
            using(var context = new datafilmEntities())
            {
                var result = context.MaxSoBo_PhimPcb(masanpham, loaiphim);
                sobo = Convert.ToInt32(result);
                return sobo; 
            }
        }

        public void InsertPhimPcb(PhimPcbBUS phimpcb)
        {
            using(var context = new datafilmEntities())
            {
                var entity = Mapper.Map<PhimPcbBUS,PhimPcb>(phimpcb);
                context.PhimPcbs.Add(entity);
                context.SaveChanges();
            }
        }

        public void UpdatePhimPcb(PhimPcbBUS phimpcb)
        {
            using(var context = new datafilmEntities())
            {
                var entity = context.PhimPcbs.SingleOrDefault(p => p.idpcb == phimpcb.idpcb);
                entity.bophan = phimpcb.bophan;
                entity.masanpham = phimpcb.masanpham;
                entity.phanloai = phimpcb.phanloai;
                entity.loaiphim = phimpcb.loaiphim;
                entity.maydung = phimpcb.maydung;
                entity.tylex = phimpcb.tylex;
                entity.tyley = phimpcb.tyley;
                entity.nguoiyeucau = phimpcb.nguoiyeucau;
                entity.noidungyeucau = phimpcb.noidungyeucau;
                entity.xacnhancam = phimpcb.xacnhancam;
                entity.mayin = phimpcb.mayin;
                entity.hientrang = phimpcb.hientrang;
                entity.giohoanthanh = phimpcb.giohoanthanh;
                entity.ngayxuatxuong = phimpcb.ngayxuatxuong;
                entity.ngaybaophe = phimpcb.ngaybaophe;
                entity.noidungbaophe = phimpcb.noidungbaophe;

                context.SaveChanges();
            }
        }

        public void DeletePhimPcb(PhimPcbBUS phimpcb)
        {
            using(var context = new datafilmEntities())
            {
                var entity = context.PhimPcbs.SingleOrDefault(p => p.idpcb == phimpcb.idpcb);
                context.PhimPcbs.Remove(entity);

                context.SaveChanges();
            }
        }
    }
}
