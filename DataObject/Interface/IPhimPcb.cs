using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObject
{
    public interface IPhimPcb
    {
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
        List<PhimPcbBUS> SearchPhimPcbByMa3_1f(string loaiphim, string tensanpham, string hientrang);
        List<PhimPcbBUS> SearchPhimPcbByMa4_3f(string bophan, string tensanpham, string hientrang);
        List<PhimPcbBUS> SearchPhimPcbByMa4_2f(string bophan, string tensanpham, string hientrang);
        List<PhimPcbBUS> SearchPhimPcbByPT(string bophan, string tensanpham, string hientrang);
        List<PhimPcbBUS> SearchPhimPcbByPE(string bophan, string tensanpham, string hientrang);
        List<PhimPcbBUS> SearchPhimPcbByMa3_2f(string bophan, string tensanpham, string hientrang);
        int GetMaxSoBoPhimPcb(string bophan, string masanpham, string loaiphim);
        int GetMaxSoBoPhimPcbByPEPT(string masanpham, string loaiphim);
        void InsertPhimPcb(PhimPcbBUS phimpcb);
        void UpdatePhimPcb(PhimPcbBUS phimpcb);
        void UpdatePhimPcbByPE(int idpcb, string xacnhanpe, string hientrang);
        void DeletePhimPcb(PhimPcbBUS phimpcb);
    }
}
