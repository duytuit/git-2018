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
        static readonly ICoDinhTyLeTaoMach codinhtaomachDao = factory.CoDinhTyLeTaoMach;
        static readonly ILoaiPhim loaiphimDao = factory.LoaiPhim;
        static readonly IPhimPcb phimpcbDao = factory.PhimPcb;
        static readonly IMemBer memberDao = factory.MemBer;
        static readonly IPhimFpc phimfpcDao = factory.PhimFpc;
        static readonly IPhimTest phimtestDao = factory.PhimTest;
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
        public List<CoDinhTyLePhuSonBUS> CheckTyLePhuSon(string tensanpham, string loaiphim)
        {
            return codinhphusonDao.CheckTyLePhuSon(tensanpham, loaiphim);
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
        public List<LoaiPhimBUS> GetLoaiPhimByBoPhan(string bophan)
        {
            return loaiphimDao.GetLoaiPhimByBoPhan(bophan);
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

        public List<PhimPcbBUS> GetPhimPcbMa3_1f()
        {
            return phimpcbDao.GetPhimPcbMa3_1f();
        }

        public List<PhimPcbBUS> GetPhimPcbMa3_2f()
        {
            return phimpcbDao.GetPhimPcbMa3_2f();
        }

        public List<PhimPcbBUS> GetPhimPcbMa4_2f()
        {
            return phimpcbDao.GetPhimPcbMa4_2f();
        }

        public List<PhimPcbBUS> GetPhimPcbMa4_3f()
        {
            return phimpcbDao.GetPhimPcbMa4_3f();
        }
        public List<PhimPcbBUS> GetPhimPcbPE()
        {
            return phimpcbDao.GetPhimPcbPE();
        }

        public List<PhimPcbBUS> GetPhimPcbPT()
        {
            return phimpcbDao.GetPhimPcbPT();
        }
        public List<PhimPcbBUS> GetPhimPcbByDate(string bophan, DateTime fromdate, DateTime todate)
        {
            return phimpcbDao.GetPhimPcbByDate(bophan, fromdate, todate);
        }
        public List<PhimPcbBUS> GetPhimPcbByDateFilm(DateTime fromdate, DateTime todate)
        {
            return phimpcbDao.GetPhimPcbByDateFilm(fromdate, todate);
        }

        public List<PhimPcbBUS> GetPhimPcbById(int idphimpcb)
        {
            return phimpcbDao.GetPhimPcbById(idphimpcb);
        }
        public List<PhimPcbBUS> SearchPhimPcbByMa4_2f(string bophan, string tensanpham, string hientrang)
        {
            return phimpcbDao.SearchPhimPcbByMa4_2f(bophan, tensanpham, hientrang);
        }

        public List<PhimPcbBUS> SearchPhimPcbByPT(string bophan, string tensanpham, string hientrang)
        {
            return phimpcbDao.SearchPhimPcbByPT(bophan, tensanpham, hientrang);
        }
        public List<PhimPcbBUS> SearchPhimPcbByPE(string bophan, string tensanpham, string hientrang)
        {
            return phimpcbDao.SearchPhimPcbByPE(bophan, tensanpham, hientrang);
        }
        public List<PhimPcbBUS> SearchPhimPcbByMa3_2f(string bophan, string tensanpham, string hientrang)
        {
            return phimpcbDao.SearchPhimPcbByMa3_2f(bophan, tensanpham, hientrang);
        }
        public List<PhimPcbBUS> SearchPhimPcb(string bophan, string tensanpham, string hientrang)
        {
            return phimpcbDao.SearchPhimPcb(bophan, tensanpham, hientrang);
        }
        public List<PhimPcbBUS> SearchPhimPcbByMa3_1f(string loaiphim, string tensanpham, string hientrang)
        {
            return phimpcbDao.SearchPhimPcbByMa3_1f(loaiphim, tensanpham, hientrang);
        }
        public List<PhimPcbBUS> SearchPhimPcbByMa4_3f(string bophan, string tensanpham, string hientrang)
        {
            return phimpcbDao.SearchPhimPcbByMa4_3f(bophan, tensanpham, hientrang);
        }

        public int GetMaxSoBoPhimPcb(string bophan, string masanpham, string loaiphim)
        {
            return phimpcbDao.GetMaxSoBoPhimPcb(bophan, masanpham, loaiphim);
        }
        public int GetMaxSoBoPhimPcbByPEPT(string masanpham, string loaiphim)
        {
            return phimpcbDao.GetMaxSoBoPhimPcbByPEPT(masanpham, loaiphim);
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


        public void UpdatePhimPcbByPE(int idpcb, string xacnhanpe, string hientrang)
        {
            phimpcbDao.UpdatePhimPcbByPE(idpcb, xacnhanpe, hientrang);
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
            return memberDao.GetMemBerById(idmember);
        }

        public void InsertMemBer(MemBerBUS member)
        {
            memberDao.InsertMemBer(member);
        }

        public void UpdateMemBer(MemBerBUS member)
        {
            memberDao.UpdateMemBer(member);
        }

        public void DeleteMemBer(MemBerBUS member)
        {
            memberDao.DeleteMemBer(member);
        }

        // Co Dinh Ty Le Tao Mach

        public List<CoDinhTyLeTaoMachBUS> GetCoDinhTyLeTaoMach()
        {
            return codinhtaomachDao.GetCoDinhTyLeTaoMach();
        }

        public List<CoDinhTyLeTaoMachBUS> GetCoDinhTyLeTaoMachById(int idtaomach)
        {
            return codinhtaomachDao.GetCoDinhTyLeTaoMachById(idtaomach);
        }

        public List<CoDinhTyLeTaoMachBUS> GetCoDinhTaoMachBySanPham(string tensanpham)
        {
            return codinhtaomachDao.GetCoDinhTaoMachBySanPham(tensanpham);
        }

        public List<CoDinhTyLeTaoMachBUS> CheckTyLeTaoMach(string tensanpham, string loaiphim)
        {
            return codinhtaomachDao.CheckTyLeTaoMach(tensanpham, loaiphim);
        }

        public void InsertCoDinhTyLeTaoMach(CoDinhTyLeTaoMachBUS codinhtyletaomach)
        {
            codinhtaomachDao.InsertCoDinhTyLeTaoMach(codinhtyletaomach);
        }

        public void UpdateCoDinhTyLeTaoMach(CoDinhTyLeTaoMachBUS codinhtyletaomach)
        {
            codinhtaomachDao.UpdateCoDinhTyLeTaoMach(codinhtyletaomach);
        }

        public void DeleteCoDinhTyLeTaoMach(CoDinhTyLeTaoMachBUS codinhtyletaomach)
        {
            codinhtaomachDao.DeleteCoDinhTyLeTaoMach(codinhtyletaomach);
        }

        //PhimFPC

        public List<PhimFpcBUS> GetPhimFpc()
        {
            return phimfpcDao.GetPhimFpc();
        }

        public List<PhimFpcBUS> GetPhimFpcById(int idphimfpc)
        {
            return phimfpcDao.GetPhimFpcById(idphimfpc);
        }

        public List<PhimFpcBUS> GetPhimFpcByDate(DateTime fromdate, DateTime todate)
        {
            return phimfpcDao.GetPhimFpcByDate(fromdate, todate);
        }

        public List<PhimFpcBUS> SearchPhimFpc(string bophan, string tensanpham, string hientrang)
        {
            return phimfpcDao.SearchPhimFpc(bophan, tensanpham, hientrang);
        }

        public int GetMaxSoBoPhimFpc(string masanphan, string loaiphim)
        {
            return phimfpcDao.GetMaxSoBoPhimFpc(masanphan, loaiphim);
        }

        public void InsertPhimFpc(PhimFpcBUS phimfpc)
        {
            phimfpcDao.InsertPhimFpc(phimfpc);
        }

        public void UpdatePhimFpc(PhimFpcBUS phimfpc)
        {
            phimfpcDao.UpdatePhimFpc(phimfpc);
        }

        public void DeletePhimFpc(PhimFpcBUS phimfpc)
        {
            phimfpcDao.DeletePhimFpc(phimfpc);
        }


        //PhimTest

        public List<PhimTestBUS> GetPhimTest()
        {
            return phimtestDao.GetPhimTest();
        }

        public List<PhimTestBUS> GetPhimTestById(int idphimtest)
        {
            return phimtestDao.GetPhimTestById(idphimtest);
        }

        public List<PhimTestBUS> GetPhimTestByDate(DateTime fromdate, DateTime todate)
        {
            return phimtestDao.GetPhimTestByDate(fromdate, todate);
        }

        public List<PhimTestBUS> SearchPhimTest(string loaiphim, string tensanpham, string hientrang)
        {
            return phimtestDao.SearchPhimTest(loaiphim, tensanpham, hientrang);
        }

        public int GetMaxSoBoPhimTest(string bophan, string masanpham, string loaiphim)
        {
            return phimtestDao.GetMaxSoBoPhimTest(bophan, masanpham, loaiphim);
        }

        public void InsertPhimTest(PhimTestBUS phimtest)
        {
            phimtestDao.InsertPhimTest(phimtest);
        }

        public void UpdatePhimTest(PhimTestBUS phimtest)
        {
            phimtestDao.UpdatePhimTest(phimtest);
        }

        public void DeletePhimtest(PhimTestBUS phimtest)
        {
            phimtestDao.DeletePhimtest(phimtest);
        }
    }
}
