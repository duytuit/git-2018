using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HTQuanLyFilm.Code
{
    public class AutoTimeInsert
    {
        public static string CaLamViec()
        {
            DateTime hour = DateTime.Now;
            int gio = hour.Hour;
            string ca = null;
            if (gio >= 8 && gio < 20)
            {
                ca = "Ngày";
            }
            else
            {
                ca = "Đêm";
            }
            return ca;
        }
        public static string NgayYeuCau()
        {
            string ngay = null;
            DateTime today = DateTime.Today;
            DateTime hour = DateTime.Now;
            int gio = hour.Hour;
            if (gio < 8)
            {
                ngay = today.AddDays(-1).ToShortDateString();
            }
            else
            {
                ngay = today.ToShortDateString();
            }
            return ngay;

        }
    }
}