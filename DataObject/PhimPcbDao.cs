using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using AutoMapper;

namespace DataObject
{
    public class PhimPcbDao : IPhimPcb
    {

        public List<PhimPcbBUS> GetPhimPcb()
        {
            using (var context = new datafilmEntities())
            {
                var result = context.SelectGiamDanPhimPcb().ToList<PhimPcb>();
                return Mapper.Map<List<PhimPcb>, List<PhimPcbBUS>>(result);
            }
        }

        public List<PhimPcbBUS> GetPhimPcbByDate(string bophan, DateTime fromdate, DateTime todate)
        {
            using (var context = new datafilmEntities())
            {
                var result = context.SelectNgayPcb(bophan, fromdate, todate).ToList<PhimPcb>();
                return Mapper.Map<List<PhimPcb>, List<PhimPcbBUS>>(result);
            }
        }

        public List<PhimPcbBUS> GetPhimPcbById(int idphimpcb)
        {
            using (var context = new datafilmEntities())
            {
                var result = context.SelectIdPcb(idphimpcb).ToList<PhimPcb>();
                return Mapper.Map<List<PhimPcb>, List<PhimPcbBUS>>(result);
            }
        }

        public List<PhimPcbBUS> SearchPhimPcb(string bophan, string tensanpham, string hientrang)
        {
            using (var context = new datafilmEntities())
            {
                var result = context.SelectGiamDanPhimPcb().ToList<PhimPcb>();
                if (!string.IsNullOrEmpty(bophan))
                {
                    result = context.SearchPcb(bophan, null, null).ToList<PhimPcb>();
                }
                if (!string.IsNullOrEmpty(tensanpham))
                {
                    result = context.SearchPcb(null, tensanpham, null).ToList<PhimPcb>();
                }
                if (!string.IsNullOrEmpty(hientrang))
                {
                    result = context.SearchPcb(null, null, hientrang).ToList<PhimPcb>();
                }
                if (!string.IsNullOrEmpty(bophan) && !string.IsNullOrEmpty(tensanpham))
                {
                    result = context.SearchPcb(bophan, tensanpham, null).ToList<PhimPcb>();
                }
                if (!string.IsNullOrEmpty(bophan) && !string.IsNullOrEmpty(hientrang))
                {
                    result = context.SearchPcb(bophan, null, hientrang).ToList<PhimPcb>();
                }
                if (!string.IsNullOrEmpty(tensanpham) && !string.IsNullOrEmpty(hientrang))
                {
                    result = context.SearchPcb(null, tensanpham, hientrang).ToList<PhimPcb>();
                }
                if (!string.IsNullOrEmpty(bophan) && !string.IsNullOrEmpty(tensanpham) && !string.IsNullOrEmpty(hientrang))
                {
                    result = context.SearchPcb(bophan, tensanpham, hientrang).ToList<PhimPcb>();
                }
                return Mapper.Map<List<PhimPcb>, List<PhimPcbBUS>>(result);
            }
        }

        public int GetMaxSoBoPhimPcb(string bophan, string masanpham, string loaiphim)
        {
            int sobo;
            using (var context = new datafilmEntities())
            {
                var result = context.MaxSoBo_PhimPcb(bophan, masanpham, loaiphim).First();
                sobo = Convert.ToInt32(result);
                return sobo;
            }
        }

        public void InsertPhimPcb(PhimPcbBUS phimpcb)
        {
            using (var context = new datafilmEntities())
            {
                var entity = Mapper.Map<PhimPcbBUS, PhimPcb>(phimpcb);
                context.PhimPcbs.Add(entity);
                context.SaveChanges();
            }
        }

        public void UpdatePhimPcb(PhimPcbBUS phimpcb)
        {
            using (var context = new datafilmEntities())
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
            using (var context = new datafilmEntities())
            {
                var entity = context.PhimPcbs.SingleOrDefault(p => p.idpcb == phimpcb.idpcb);
                context.PhimPcbs.Remove(entity);

                context.SaveChanges();
            }
        }


        public void UpdatePhimPcbByPE(int idpcb, string xacnhanpe, string hientrang)
        {
            using (var context = new datafilmEntities())
            {
                context.UpDateXacNhan(idpcb, xacnhanpe, hientrang);

                context.SaveChanges();
            }
        }


        public List<PhimPcbBUS> GetPhimPcbMa3_1f()
        {
            using (var context = new datafilmEntities())
            {
                var result = context.SelectByMa3_1f().ToList<PhimPcb>();
                return Mapper.Map<List<PhimPcb>, List<PhimPcbBUS>>(result);
            }
        }

        public List<PhimPcbBUS> GetPhimPcbMa3_2f()
        {
            using (var context = new datafilmEntities())
            {
                var result = context.SelectByMa3_2f().ToList<PhimPcb>();
                return Mapper.Map<List<PhimPcb>, List<PhimPcbBUS>>(result);
            }
        }

        public List<PhimPcbBUS> GetPhimPcbMa4_2f()
        {
            using (var context = new datafilmEntities())
            {
                var result = context.SelectByMa4_2f().ToList<PhimPcb>();
                return Mapper.Map<List<PhimPcb>, List<PhimPcbBUS>>(result);
            }
        }

        public List<PhimPcbBUS> GetPhimPcbMa4_3f()
        {
            using (var context = new datafilmEntities())
            {
                var result = context.SelectByMa4_3f().ToList<PhimPcb>();
                return Mapper.Map<List<PhimPcb>, List<PhimPcbBUS>>(result);
            }
        }


        public List<PhimPcbBUS> SearchPhimPcbByMa3_1f(string loaiphim, string tensanpham, string hientrang)
        {
            using (var context = new datafilmEntities())
            {
                var result = context.SelectByMa3_1f().ToList<PhimPcb>();
                if (!string.IsNullOrEmpty(loaiphim))
                {
                    result = context.SearchPcbMa3_1f(loaiphim, null, null).ToList<PhimPcb>();
                }
                if (!string.IsNullOrEmpty(tensanpham))
                {
                    result = context.SearchPcbMa3_1f(null, tensanpham, null).ToList<PhimPcb>();
                }
                if (!string.IsNullOrEmpty(hientrang))
                {
                    result = context.SearchPcbMa3_1f(null, null, hientrang).ToList<PhimPcb>();
                }
                if (!string.IsNullOrEmpty(loaiphim) && !string.IsNullOrEmpty(tensanpham))
                {
                    result = context.SearchPcbMa3_1f(loaiphim, tensanpham, null).ToList<PhimPcb>();
                }
                if (!string.IsNullOrEmpty(loaiphim) && !string.IsNullOrEmpty(hientrang))
                {
                    result = context.SearchPcbMa3_1f(loaiphim, null, hientrang).ToList<PhimPcb>();
                }
                if (!string.IsNullOrEmpty(tensanpham) && !string.IsNullOrEmpty(hientrang))
                {
                    result = context.SearchPcbMa3_1f(null, tensanpham, hientrang).ToList<PhimPcb>();
                }
                if (!string.IsNullOrEmpty(loaiphim) && !string.IsNullOrEmpty(tensanpham) && !string.IsNullOrEmpty(hientrang))
                {
                    result = context.SearchPcbMa3_1f(loaiphim, tensanpham, hientrang).ToList<PhimPcb>();
                }
                return Mapper.Map<List<PhimPcb>, List<PhimPcbBUS>>(result);
            }
        }


        public List<PhimPcbBUS> SearchPhimPcbByMa4_3f(string bophan, string tensanpham, string hientrang)
        {
            using (var context = new datafilmEntities())
            {
                var result = context.SelectByMa4_3f().ToList<PhimPcb>();
                if (!string.IsNullOrEmpty(bophan) && !string.IsNullOrEmpty(tensanpham))
                {
                    result = context.SearchPcb(bophan, tensanpham, null).ToList<PhimPcb>();
                }
                if (!string.IsNullOrEmpty(bophan) && !string.IsNullOrEmpty(hientrang))
                {
                    result = context.SearchPcb(bophan, null, hientrang).ToList<PhimPcb>();
                }
                if (!string.IsNullOrEmpty(bophan) && !string.IsNullOrEmpty(tensanpham) && !string.IsNullOrEmpty(hientrang))
                {
                    result = context.SearchPcb(bophan, tensanpham, hientrang).ToList<PhimPcb>();
                }
                return Mapper.Map<List<PhimPcb>, List<PhimPcbBUS>>(result);
            }
        }
        public List<PhimPcbBUS> GetPhimPcbByDateFilm(DateTime fromdate, DateTime todate)
        {
            using (var context = new datafilmEntities())
            {
                var result = context.SearchNgayPcb(fromdate, todate).ToList<PhimPcb>();
                return Mapper.Map<List<PhimPcb>, List<PhimPcbBUS>>(result);
            }
        }


        public List<PhimPcbBUS> SearchPhimPcbByMa4_2f(string bophan, string tensanpham, string hientrang)
        {
            using (var context = new datafilmEntities())
            {
                var result = context.SelectByMa4_2f().ToList<PhimPcb>();
                if (!string.IsNullOrEmpty(bophan))
                {
                    result = context.SearchPcb(bophan, null, null).ToList<PhimPcb>();
                }
                if (!string.IsNullOrEmpty(tensanpham))
                {
                    result = context.SearchPcb(null, tensanpham, null).ToList<PhimPcb>();
                }
                if (!string.IsNullOrEmpty(hientrang))
                {
                    result = context.SearchPcb(null, null, hientrang).ToList<PhimPcb>();
                }
                if (!string.IsNullOrEmpty(bophan) && !string.IsNullOrEmpty(tensanpham))
                {
                    result = context.SearchPcb(bophan, tensanpham, null).ToList<PhimPcb>();
                }
                if (!string.IsNullOrEmpty(bophan) && !string.IsNullOrEmpty(hientrang))
                {
                    result = context.SearchPcb(bophan, null, hientrang).ToList<PhimPcb>();
                }
                if (!string.IsNullOrEmpty(tensanpham) && !string.IsNullOrEmpty(hientrang))
                {
                    result = context.SearchPcb(null, tensanpham, hientrang).ToList<PhimPcb>();
                }
                if (!string.IsNullOrEmpty(bophan) && !string.IsNullOrEmpty(tensanpham) && !string.IsNullOrEmpty(hientrang))
                {
                    result = context.SearchPcb(bophan, tensanpham, hientrang).ToList<PhimPcb>();
                }
                return Mapper.Map<List<PhimPcb>, List<PhimPcbBUS>>(result);
            }
        }

        public List<PhimPcbBUS> SearchPhimPcbByPT(string bophan, string tensanpham, string hientrang)
        {
            using (var context = new datafilmEntities())
            {
                var result = context.SelectByPT().ToList<PhimPcb>();
                if (!string.IsNullOrEmpty(bophan))
                {
                    result = context.SearchPcb(bophan, null, null).ToList<PhimPcb>();
                }
                if (!string.IsNullOrEmpty(tensanpham))
                {
                    result = context.SearchPcb(null, tensanpham, null).ToList<PhimPcb>();
                }
                if (!string.IsNullOrEmpty(hientrang))
                {
                    result = context.SearchPcb(null, null, hientrang).ToList<PhimPcb>();
                }
                if (!string.IsNullOrEmpty(bophan) && !string.IsNullOrEmpty(tensanpham))
                {
                    result = context.SearchPcb(bophan, tensanpham, null).ToList<PhimPcb>();
                }
                if (!string.IsNullOrEmpty(bophan) && !string.IsNullOrEmpty(hientrang))
                {
                    result = context.SearchPcb(bophan, null, hientrang).ToList<PhimPcb>();
                }
                if (!string.IsNullOrEmpty(tensanpham) && !string.IsNullOrEmpty(hientrang))
                {
                    result = context.SearchPcb(null, tensanpham, hientrang).ToList<PhimPcb>();
                }
                if (!string.IsNullOrEmpty(bophan) && !string.IsNullOrEmpty(tensanpham) && !string.IsNullOrEmpty(hientrang))
                {
                    result = context.SearchPcb(bophan, tensanpham, hientrang).ToList<PhimPcb>();
                }
                return Mapper.Map<List<PhimPcb>, List<PhimPcbBUS>>(result);
            }
        }

        public List<PhimPcbBUS> SearchPhimPcbByMa3_2f(string bophan, string tensanpham, string hientrang)
        {
            using (var context = new datafilmEntities())
            {
                var result = context.SelectByMa3_2f().ToList<PhimPcb>();
                if (!string.IsNullOrEmpty(bophan))
                {
                    result = context.SearchPcb(bophan, null, null).ToList<PhimPcb>();
                }
                if (!string.IsNullOrEmpty(tensanpham))
                {
                    result = context.SearchPcb(null, tensanpham, null).ToList<PhimPcb>();
                }
                if (!string.IsNullOrEmpty(hientrang))
                {
                    result = context.SearchPcb(null, null, hientrang).ToList<PhimPcb>();
                }
                if (!string.IsNullOrEmpty(bophan) && !string.IsNullOrEmpty(tensanpham))
                {
                    result = context.SearchPcb(bophan, tensanpham, null).ToList<PhimPcb>();
                }
                if (!string.IsNullOrEmpty(bophan) && !string.IsNullOrEmpty(hientrang))
                {
                    result = context.SearchPcb(bophan, null, hientrang).ToList<PhimPcb>();
                }
                if (!string.IsNullOrEmpty(tensanpham) && !string.IsNullOrEmpty(hientrang))
                {
                    result = context.SearchPcb(null, tensanpham, hientrang).ToList<PhimPcb>();
                }
                if (!string.IsNullOrEmpty(bophan) && !string.IsNullOrEmpty(tensanpham) && !string.IsNullOrEmpty(hientrang))
                {
                    result = context.SearchPcb(bophan, tensanpham, hientrang).ToList<PhimPcb>();
                }
                return Mapper.Map<List<PhimPcb>, List<PhimPcbBUS>>(result);
            }
        }
        public List<PhimPcbBUS> GetPhimPcbPE()
        {
            using (var context = new datafilmEntities())
            {
                var result = context.SelectByPE().ToList<PhimPcb>();
                return Mapper.Map<List<PhimPcb>, List<PhimPcbBUS>>(result);
            }
        }

        public List<PhimPcbBUS> GetPhimPcbPT()
        {
            using (var context = new datafilmEntities())
            {
                var result = context.SelectByPT().ToList<PhimPcb>();
                return Mapper.Map<List<PhimPcb>, List<PhimPcbBUS>>(result);
            }
        }


        public List<PhimPcbBUS> SearchPhimPcbByPE(string bophan, string tensanpham, string hientrang)
        {
            using (var context = new datafilmEntities())
            {
                var result = context.SelectByPE().ToList<PhimPcb>();
                if (!string.IsNullOrEmpty(bophan))
                {
                    result = context.SearchPcb(bophan, null, null).ToList<PhimPcb>();
                }
                if (!string.IsNullOrEmpty(tensanpham))
                {
                    result = context.SearchPcb(null, tensanpham, null).ToList<PhimPcb>();
                }
                if (!string.IsNullOrEmpty(hientrang))
                {
                    result = context.SearchPcb(null, null, hientrang).ToList<PhimPcb>();
                }
                if (!string.IsNullOrEmpty(bophan) && !string.IsNullOrEmpty(tensanpham))
                {
                    result = context.SearchPcb(bophan, tensanpham, null).ToList<PhimPcb>();
                }
                if (!string.IsNullOrEmpty(bophan) && !string.IsNullOrEmpty(hientrang))
                {
                    result = context.SearchPcb(bophan, null, hientrang).ToList<PhimPcb>();
                }
                if (!string.IsNullOrEmpty(tensanpham) && !string.IsNullOrEmpty(hientrang))
                {
                    result = context.SearchPcb(null, tensanpham, hientrang).ToList<PhimPcb>();
                }
                if (!string.IsNullOrEmpty(bophan) && !string.IsNullOrEmpty(tensanpham) && !string.IsNullOrEmpty(hientrang))
                {
                    result = context.SearchPcb(bophan, tensanpham, hientrang).ToList<PhimPcb>();
                }
                return Mapper.Map<List<PhimPcb>, List<PhimPcbBUS>>(result);
            }
        }
        public int GetMaxSoBoPhimPcbByPEPT(string masanpham, string loaiphim)
        {
            int sobo;
            using (var context = new datafilmEntities())
            {
                var result = context.MaxSoBo_PhimPcbByPEPT(masanpham, loaiphim).First();
                sobo = Convert.ToInt32(result);
                return sobo;
            }
        }
    }
}
