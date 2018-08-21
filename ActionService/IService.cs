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
        void InsertCoDinhTyLePhuSon(CoDinhTyLePhuSonBUS codinhtylephuson);
        void UpdateCoDinhTyLePhuSon(CoDinhTyLePhuSonBUS codinhtylephuson);
        void DeleteCoDinhTyLePhuSon(CoDinhTyLePhuSonBUS codinhtylephuson);

        //Loại Phim

        List<LoaiPhimBUS> GetLoaiPhim();
        List<LoaiPhimBUS> GetLoaiPhimById(int idloaiphim);
        void InsertLoaiPhim(LoaiPhimBUS loaiphim);
        void UpdateLoaiPhim(LoaiPhimBUS loaiphim);
        void DeleteLoaiPhim(LoaiPhimBUS loaiphim);

        //Phim PCB

        List<PhimPcbBUS> GetPhimPcb();
        List<PhimPcbBUS> GetPhimPcbByDate(DateTime fromdate, DateTime todate);
        List<PhimPcbBUS> GetPhimPcbById(int idphimpcb);
        List<PhimPcbBUS> SearchPhimPcb(string bophan, string tensanpham, string hientrang);
        int GetMaxSoBoPhimPcb(string masanpham, string loaiphim);
        void InsertPhimPcb(PhimPcbBUS phimpcb);
        void UpdatePhimPcb(PhimPcbBUS phimpcb);
        void UpdatePhimPcbByPE(PhimPcbBUS phimpcb);
        void DeletePhimPcb(PhimPcbBUS phimpcb);

        // MemBer
        List<MemBerBUS> GetMemBer();
        List<MemBerBUS> GetMemBerById(int idmember);
        List<MemBerBUS> GetListMemBer(string production);
        void InsertMemBer(MemBerBUS member);
        void UpdateMemBer(MemBerBUS member);
        void DeleteMemBer(MemBerBUS member);
    }
}
