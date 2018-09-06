using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using AutoMapper;

namespace DataObject
{
    public class PhimTestDao : IPhimTest
    {
        public List<PhimTestBUS> GetPhimTest()
        {
            using (var context = new datafilmEntities())
            {
                var result = context.SelectGiamDanTest().ToList<PhimTest>();
                return Mapper.Map<List<PhimTest>, List<PhimTestBUS>>(result);
            }
        }

        public List<PhimTestBUS> GetPhimTestById(int idphimtest)
        {
            using (var context = new datafilmEntities())
            {
                var result = context.SelectIdTest(idphimtest).ToList<PhimTest>();
                return Mapper.Map<List<PhimTest>, List<PhimTestBUS>>(result);
            }
        }

        public List<PhimTestBUS> GetPhimTestByDate(DateTime fromdate, DateTime todate)
        {
            using (var context = new datafilmEntities())
            {
                var result = context.SelectNgayPhimTest(fromdate, todate).ToList<PhimTest>();
                return Mapper.Map<List<PhimTest>, List<PhimTestBUS>>(result);
            }
        }

        public List<PhimTestBUS> SearchPhimTest(string loaiphim, string tensanpham, string hientrang)
        {
            using (var context = new datafilmEntities())
            {
                var result = context.SelectGiamDanTest().ToList<PhimTest>();
                if (!string.IsNullOrEmpty(loaiphim))
                {
                    result = context.SearchPhimTest(loaiphim, null, null).ToList<PhimTest>();
                }
                if (!string.IsNullOrEmpty(tensanpham))
                {
                    result = context.SearchPhimTest(null, tensanpham, null).ToList<PhimTest>();
                }
                if (!string.IsNullOrEmpty(hientrang))
                {
                    result = context.SearchPhimTest(null, null, hientrang).ToList<PhimTest>();
                }
                if (!string.IsNullOrEmpty(loaiphim) && !string.IsNullOrEmpty(tensanpham))
                {
                    result = context.SearchPhimTest(loaiphim, tensanpham, null).ToList<PhimTest>();
                }
                if (!string.IsNullOrEmpty(loaiphim) && !string.IsNullOrEmpty(hientrang))
                {
                    result = context.SearchPhimTest(loaiphim, null, hientrang).ToList<PhimTest>();
                }
                if (!string.IsNullOrEmpty(tensanpham) && !string.IsNullOrEmpty(hientrang))
                {
                    result = context.SearchPhimTest(null, tensanpham, hientrang).ToList<PhimTest>();
                }
                if (!string.IsNullOrEmpty(loaiphim) && !string.IsNullOrEmpty(tensanpham) && !string.IsNullOrEmpty(hientrang))
                {
                    result = context.SearchPhimTest(loaiphim, tensanpham, hientrang).ToList<PhimTest>();
                }
                return Mapper.Map<List<PhimTest>, List<PhimTestBUS>>(result);
            }
        }

        public int GetMaxSoBoPhimTest(string bophan, string masanpham, string loaiphim)
        {
            int sobo;
            using (var context = new datafilmEntities())
            {
                var result = context.MaxSoBo_Test(bophan, masanpham, loaiphim).First();
                sobo = Convert.ToInt32(result);
                return sobo;
            }
        }

        public void InsertPhimTest(PhimTestBUS phimtest)
        {
            using (var context = new datafilmEntities())
            {
                var entity = Mapper.Map<PhimTestBUS, PhimTest>(phimtest);
                entity.ca = phimtest.ca;
                entity.ngay = phimtest.ngay;
                entity.gio = phimtest.gio;
                entity.bophan = phimtest.bophan;
                entity.tensanpham = phimtest.tensanpham;
                entity.dulieungay = phimtest.dulieungay;
                entity.loaiphim = phimtest.loaiphim;
                entity.sobo = phimtest.sobo;
                entity.tylex = phimtest.tylex;
                entity.tyley = phimtest.tyley;
                entity.nguoiyeucau = phimtest.nguoiyeucau;
                entity.noidungyeucau = phimtest.noidungyeucau;
                entity.xacnhancam = phimtest.xacnhancam;
                entity.hientrang = phimtest.hientrang;
                entity.giohoanthanh = phimtest.giohoanthanh;
                entity.ngayxuatxuong = phimtest.ngayxuatxuong;
                entity.ngaybaophe = phimtest.ngaybaophe;
                entity.noidungbaophe = phimtest.noidungbaophe;

                context.PhimTests.Add(entity);
                context.SaveChanges();
            }
        }

        public void UpdatePhimTest(PhimTestBUS phimtest)
        {
            using (var context = new datafilmEntities())
            {
                var entity = context.PhimTests.SingleOrDefault(p => p.idtest == phimtest.idtest);

                entity.bophan = phimtest.bophan;
                entity.tensanpham = phimtest.tensanpham;
                entity.dulieungay = phimtest.dulieungay;
                entity.loaiphim = phimtest.loaiphim;
                entity.sobo = phimtest.sobo;
                entity.tylex = phimtest.tylex;
                entity.tyley = phimtest.tyley;
                entity.nguoiyeucau = phimtest.nguoiyeucau;
                entity.noidungyeucau = phimtest.noidungyeucau;
                entity.xacnhancam = phimtest.xacnhancam;
                entity.hientrang = phimtest.hientrang;
                entity.giohoanthanh = phimtest.giohoanthanh;
                entity.ngayxuatxuong = phimtest.ngayxuatxuong;
                entity.ngaybaophe = phimtest.ngaybaophe;
                entity.noidungbaophe = phimtest.noidungbaophe;

                context.SaveChanges();
            }
        }

        public void DeletePhimtest(PhimTestBUS phimtest)
        {
            using (var context = new datafilmEntities())
            {
                var entity = context.PhimTests.SingleOrDefault(p => p.idtest == phimtest.idtest);

                context.PhimTests.Remove(entity);
                context.SaveChanges();
            }
        }
    }
}
