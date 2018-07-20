using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ActionService;


namespace HTQuanLyFilm.PE
{
    public partial class Codinhphuson3f : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var service = new Service();
            var CoDinhPhuSon = new BusinessObjects.CoDinhTyLePhuSonBUS();
            CoDinhPhuSon.tensanpham = TxtTenSanPham.Text.Trim();
            CoDinhPhuSon.loaiphim = DropLoaiPhim.Text;
            CoDinhPhuSon.tylexmin = TxtTyLeXmin.Text.Trim();
            CoDinhPhuSon.tylexmax = TxtTyLeXmax.Text.Trim();
            CoDinhPhuSon.tyleymin = TxtTyLeYmin.Text.Trim();
            CoDinhPhuSon.tyleymax = TxtTyLeYmax.Text.Trim();
            service.InsertCoDinhTyLePhuSon(CoDinhPhuSon);
            ASPxGridView1.DataSourceID = "CoDinhTyLePhuSon";
            ASPxGridView1.DataBind();
        }
    }
}