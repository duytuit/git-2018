using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace ActionService
{
    public interface IService
    {
        //Co Dinh Ty Le Phu Son
        List<CoDinhTyLePhuSonBUS> GetCoDinhTyLePhuSon();
        List<CoDinhTyLePhuSonBUS> GetCoDinhTyLePhuSonByID(int idphuson);
        List<CoDinhTyLePhuSonBUS> GetCoDinhPhusonByDate(DateTime datefrom, DateTime todate);
        List<CoDinhTyLePhuSonBUS> GetCoDinhPhuSonBySanPham(string tensanpham);
        List<CoDinhTyLePhuSonBUS> CheckTyLePhuSon(string tensanpham, string loaiphim);
        void InsertCoDinhTyLePhuSon(CoDinhTyLePhuSonBUS codinhtylephuson);
        void UpdateCoDinhTyLePhuSon(CoDinhTyLePhuSonBUS codinhtylephuson);
        void DeleteCoDinhTyLePhuSon(CoDinhTyLePhuSonBUS codinhtylephuson);

        //Co Dinh Ty Le Tao Mach

        List<CoDinhTyLeTaoMachBUS> GetCoDinhTyLeTaoMach();
        List<CoDinhTyLeTaoMachBUS> GetCoDinhTyLeTaoMachById(int idtaomach);
        List<CoDinhTyLeTaoMachBUS> GetCoDinhTaoMachBySanPham(string tensanpham);
        List<CoDinhTyLeTaoMachBUS> CheckTyLeTaoMach(string tensanpham, string loaiphim);
        void InsertCoDinhTyLeTaoMach(CoDinhTyLeTaoMachBUS codinhtyletaomach);
        void UpdateCoDinhTyLeTaoMach(CoDinhTyLeTaoMachBUS codinhtyletaomach);
        void DeleteCoDinhTyLeTaoMach(CoDinhTyLeTaoMachBUS codinhtyletaomach);

        //Loại Phim

        List<LoaiPhimBUS> GetLoaiPhim();
        List<LoaiPhimBUS> GetLoaiPhimById(int idloaiphim);
        List<LoaiPhimBUS> GetLoaiPhimByBoPhan(string bophan);
        void InsertLoaiPhim(LoaiPhimBUS loaiphim);
        void UpdateLoaiPhim(LoaiPhimBUS loaiphim);
        void DeleteLoaiPhim(LoaiPhimBUS loaiphim);

        //Phim PCB

        List<PhimPcbBUS> GetPhimPcb();
        List<PhimPcbBUS> GetPhimPcbMa3_1f();
        List<PhimPcbBUS> GetPhimPcbMa3_2f();
        List<PhimPcbBUS> GetPhimPcbMa4_2f();
        List<PhimPcbBUS> GetPhimPcbMa4_3f();
        List<PhimPcbBUS> GetPhimPcbPE();
        List<PhimPcbBUS> GetPhimPcbPT();
        List<PhimPcbBUS> GetPhimPcbByDate(string bophan, DateTime fromdate, DateTime todate);
        List<PhimPcbBUS> GetPhimPcbByDateFilm(DateTime fromdate, DateTime todate);
        List<PhimPcbBUS> GetPhimPcbById(int idphimpcb);
        List<PhimPcbBUS> SearchPhimPcb(string bophan, string tensanpham, string hientrang);
        List<PhimPcbBUS> SearchPhimPcbByMa4_2f(string bophan, string tensanpham, string hientrang);
        List<PhimPcbBUS> SearchPhimPcbByPT(string bophan, string tensanpham, string hientrang);
        List<PhimPcbBUS> SearchPhimPcbByPE(string bophan, string tensanpham, string hientrang);
        List<PhimPcbBUS> SearchPhimPcbByMa3_2f(string bophan, string tensanpham, string hientrang);
        List<PhimPcbBUS> SearchPhimPcbByMa3_1f(string loaiphim, string tensanpham, string hientrang);
        List<PhimPcbBUS> SearchPhimPcbByMa4_3f(string bophan, string tensanpham, string hientrang);
        int GetMaxSoBoPhimPcb(string bophan, string masanpham, string loaiphim);
        int GetMaxSoBoPhimPcbByPEPT(string masanpham, string loaiphim);
        void InsertPhimPcb(PhimPcbBUS phimpcb);
        void UpdatePhimPcb(PhimPcbBUS phimpcb);
        void UpdatePhimPcbByPE(int idpcb, string xacnhanpe, string hientrang);
        void DeletePhimPcb(PhimPcbBUS phimpcb);


        //PhimFPC

        List<PhimFpcBUS> GetPhimFpc();
        List<PhimFpcBUS> GetPhimFpcById(int idphimfpc);
        List<PhimFpcBUS> GetPhimFpcByDate(DateTime fromdate, DateTime todate);
        List<PhimFpcBUS> SearchPhimFpc(string bophan, string tensanpham, string hientrang);
        int GetMaxSoBoPhimFpc(string masanphan, string loaiphim);
        void InsertPhimFpc(PhimFpcBUS phimfpc);
        void UpdatePhimFpc(PhimFpcBUS phimfpc);
        void DeletePhimFpc(PhimFpcBUS phimfpc);


        //PhimTest

        List<PhimTestBUS> GetPhimTest();
        List<PhimTestBUS> GetPhimTestById(int idphimtest);
        List<PhimTestBUS> GetPhimTestByDate(DateTime fromdate, DateTime todate);
        List<PhimTestBUS> SearchPhimTest(string loaiphim, string tensanpham, string hientrang);
        int GetMaxSoBoPhimTest(string bophan, string masanpham, string loaiphim);
        void InsertPhimTest(PhimTestBUS phimtest);
        void UpdatePhimTest(PhimTestBUS phimtest);
        void DeletePhimtest(PhimTestBUS phimtest);

        // MemBer
        List<MemBerBUS> GetMemBer();
        List<MemBerBUS> GetMemBerById(int idmember);
        List<MemBerBUS> GetListMemBer(string production);
        void InsertMemBer(MemBerBUS member);
        void UpdateMemBer(MemBerBUS member);
        void DeleteMemBer(MemBerBUS member);
    }
}
