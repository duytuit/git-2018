using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataObject;
using System.Configuration;
using WebMatrix.WebData;

namespace ActionService
{
   public class Service : IService
    {
       static readonly string provider = ConfigurationManager.AppSettings.Get("DataProvider");
       static readonly IDaoFactory factory = Factoryes.GetFactory(provider);
       static readonly ICoDinhTyLePhuSon codinhphusonDao = factory.CoDinhTyLePhuSon;
       static readonly ILoaiPhim loaiphimDao = factory.LoaiPhim;
       static readonly IPhimPcb phimpcbDao = factory.PhimPcb;
       static readonly IMemBer memberDao = factory.MemBer;
        public List<CoDinhTyLePhuSonBUS> GetCoDinhTyLePhuSon()
        {
           return codinhphusonDao.GetCoDinhTyLePhuSon();
    
        }

       //Cố Định Phủ Sơn
        public List<CoDinhTyLePhuSonBUS> GetCoDinhTyLePhuSonByID(int idphuson)
        {
            return codinhphusonDao.GetCoDinhTyLePhuSonBy(idphuson);
        }

        public void InsertCoDinhTyLePhuSon(CoDinhTyLePhuSonBUS codinhtylephuson)
        {
            codinhphusonDao.InsertCoDinhTyLePhuSon(codinhtylephuson);
        }

        public void UpdateCoDinhTyLePhuSon(CoDinhTyLePhuSonBUS codinhtylephuson)
        {
            codinhphusonDao.UpdateCoDinhTyLePhuSon(codinhtylephuson);
        }

        public void DeleteCoDinhTyLePhuSon(CoDinhTyLePhuSonBUS codinhtylephuson)
        {
            codinhphusonDao.DeleteCoDinhTyLePhuSon(codinhtylephuson);
        }
        public List<CoDinhTyLePhuSonBUS> GetCoDinhPhusonByDate(DateTime datefrom, DateTime todate)
        {
          return codinhphusonDao.GetCoDinhPhusonByDate(datefrom, todate);
        }


        public List<CoDinhTyLePhuSonBUS> GetCoDinhPhuSonBySanPham(string tensanpham)
        {
            return codinhphusonDao.GetCoDinhPhuSonBySanPham(tensanpham);
        }

    

       // Loại Phim
        public List<LoaiPhimBUS> GetLoaiPhim()
        {
            return loaiphimDao.GetLoaiPhim();
        }

        public void InsertLoaiPhim(LoaiPhimBUS loaiphim)
        {
            loaiphimDao.InsertLoaiPhim(loaiphim);
        }

        public void UpdateLoaiPhim(LoaiPhimBUS loaiphim)
        {
            loaiphimDao.UpdateLoaiPhim(loaiphim);
        }

        public void DeleteLoaiPhim(LoaiPhimBUS loaiphim)
        {
            loaiphimDao.DeleteLoaiPhim(loaiphim);
        }


        public List<LoaiPhimBUS> GetLoaiPhimById(int idloaiphim)
        {
           return loaiphimDao.GetLoaiPhimById(idloaiphim);
        }

       // Phim PCB

        public List<PhimPcbBUS> GetPhimPcb()
        {
            return phimpcbDao.GetPhimPcb();
        }

        public List<PhimPcbBUS> GetPhimPcbByDate(DateTime fromdate, DateTime todate)
        {
            return phimpcbDao.GetPhimPcbByDate(fromdate, todate);
        }

        public List<PhimPcbBUS> GetPhimPcbById(int idphimpcb)
        {
            return phimpcbDao.GetPhimPcbById(idphimpcb);
        }

        public List<PhimPcbBUS> SearchPhimPcb(string bophan, string tensanpham, string hientrang)
        {
            return phimpcbDao.SearchPhimPcb(bophan, tensanpham, hientrang);
        }

        public int GetMaxSoBoPhimPcb(string masanpham, string loaiphim)
        {
            return phimpcbDao.GetMaxSoBoPhimPcb(masanpham, loaiphim);
        }

        public void InsertPhimPcb(PhimPcbBUS phimpcb)
        {
            phimpcbDao.InsertPhimPcb(phimpcb);
        }

        public void UpdatePhimPcb(PhimPcbBUS phimpcb)
        {
            phimpcbDao.UpdatePhimPcb(phimpcb);
        }

        public void DeletePhimPcb(PhimPcbBUS phimpcb)
        {
            phimpcbDao.DeletePhimPcb(phimpcb);
        }


        public void UpdatePhimPcbByPE(PhimPcbBUS phimpcb)
        {
            phimpcbDao.UpdatePhimPcbByPE(phimpcb);
        }

        // MemBer
        public List<MemBerBUS> GetListMemBer(string production)
        {
            return memberDao.GetListMemBer(production);
        }

        public List<MemBerBUS> GetMemBer()
        {
            return memberDao.GetMemBer();
        }

        public List<MemBerBUS> GetMemBerById(int idmember)
        {
            throw new NotImplementedException();
        }

        public void InsertMemBer(MemBerBUS member)
        {
            throw new NotImplementedException();
        }

        public void UpdateMemBer(MemBerBUS member)
        {
            throw new NotImplementedException();
        }

        public void DeleteMemBer(MemBerBUS member)
        {
            throw new NotImplementedException();
        }
    }
}
