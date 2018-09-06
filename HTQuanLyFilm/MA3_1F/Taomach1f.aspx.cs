using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ActionService;
using System.Data;
using System.Collections;
using System.Text;
using System.IO;
using System.Drawing;
using HTQuanLyFilm.Code;


namespace HTQuanLyFilm.MA3_1F
{
    public partial class Taomach1f : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txttimkiemsanpham.Attributes["placeholder"] = "Tìm Sản Phẩm...";
            lbsoluong.Text = GridView1.Rows.Count.ToString();
        }

        protected void SearchByDate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFromdate.Text) && !string.IsNullOrEmpty(txtTodate.Text))
            {
                var service = new Service();
                var result = service.GetPhimPcbByDate("MA3-1F", Convert.ToDateTime(txtFromdate.Text), Convert.ToDateTime(txtTodate.Text));
                GridView1.DataSourceID = null;
                GridView1.DataSource = result;
                GridView1.DataBind();
                lbthongbao.Text = "";
                lbsoluong.Text = GridView1.Rows.Count.ToString();
            }
            else
            {
                lbthongbao.Text = "Không để trống ngày tìm kiếm!";
            }
        }

        protected void TxtToExcel_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=PhimPcb.xls");
            Response.ContentType = "application/excel";
            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            GridView1.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();
        }
        #region[Clear Modal Popup controls]
        private void ClearPopupControls()
        {
            txtsanpham.Text = "";
            droploaiphimform.Text = null;
            txttylex.Text = "";
            txttyley.Text = "";
            dropnguoiyeucau.Text = null;
            txtnoidungyeucau.Text = "";
            lbmessage.Text = "";
        }
        #endregion
        public override void VerifyRenderingInServerForm(Control control)
        {
            /*Tell the compiler that the control is rendered
             * explicitly by overriding the VerifyRenderingInServerForm event.*/
        }
        protected void btnthemmoi_Click(object sender, EventArgs e)
        {

            ClearPopupControls();
            hfIdpcb.Value = "insert";
            dropsoluong.Text = "1";
            popup.Show();
        }

        protected void txttimkiemsanpham_TextChanged(object sender, EventArgs e)
        {
            var service = new Service();
            GridView1.DataSourceID = null;
            GridView1.DataSource = service.SearchPhimPcbByMa3_1f(droploaiphim.Text, txttimkiemsanpham.Text.Trim(), drophientrang.Text);
            GridView1.DataBind();
            lbsoluong.Text = GridView1.Rows.Count.ToString();
        }

        protected void drophientrang_SelectedIndexChanged(object sender, EventArgs e)
        {
            var service = new Service();
            GridView1.DataSourceID = null;
            GridView1.DataSource = service.SearchPhimPcbByMa3_1f(droploaiphim.Text, txttimkiemsanpham.Text.Trim(), drophientrang.Text);
            GridView1.DataBind();
            lbsoluong.Text = GridView1.Rows.Count.ToString();
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label labelphanloai = (Label)e.Row.FindControl("lbphanloai");
                if (!string.IsNullOrEmpty(labelphanloai.Text))
                {
                    if (labelphanloai.Text == "Hàng Mới" || labelphanloai.Text == "Thay Đổi")
                    {

                        //e.Row.ForeColor = Color.Red;
                        e.Row.Cells[5].BackColor = Color.FromArgb(0xCC, 0xFF, 0x99);
                    }
                    //else
                    //{
                    //    e.Row.Cells[7].ForeColor = Color.Black;
                    //}
                }
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label Labelyeucau = (Label)e.Row.FindControl("lbhientrang");
                if (!string.IsNullOrEmpty(Labelyeucau.Text))
                {
                    if (Labelyeucau.Text == "Yêu Cầu Mới")
                    {

                        e.Row.ForeColor = Color.Red;
                        e.Row.Font.Italic = true;
                        e.Row.Font.Bold = true;
                        ////e.Row.Cells[7].ForeColor = Color.Black;
                        //e.Row.Cells[7].BackColor = Color.Yellow;
                    }
                    else if (Labelyeucau.Text == "Tỷ Lệ Bất Thường" || Labelyeucau.Text == "Sai Tỷ Lệ" || Labelyeucau.Text == "Chưa Có Dữ Liệu")
                    {
                        e.Row.ForeColor = Color.Blue;
                        e.Row.Font.Italic = true;
                        e.Row.Font.Bold = true;

                    }
                    else
                    {
                        //e.Row.Cells[7].ForeColor = Color.Black;
                        e.Row.ForeColor = Color.Black;
                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (hfIdpcb.Value == "insert")
            {
                if (!string.IsNullOrEmpty(txtsanpham.Text.Trim()) && !string.IsNullOrEmpty(droploaiphimform.Text) && !string.IsNullOrEmpty(dropnguoiyeucau.Text))
                {
                    var service = new Service();
                    var PhimPcb = new BusinessObjects.PhimPcbBUS();


                    int soluong = int.Parse(dropsoluong.Text);
                    int sobo = service.GetMaxSoBoPhimPcb("MA3-1F", txtsanpham.Text.Trim(), droploaiphimform.Text);

                    PhimPcb.ca = calamviec();
                    PhimPcb.ngay = Convert.ToDateTime(NgayYeuCau());
                    PhimPcb.gio = DateTime.Now.ToString("HH:mm");
                    PhimPcb.bophan = "MA3-1F";
                    PhimPcb.masanpham = txtsanpham.Text.Trim();
                    PhimPcb.loaiphim = droploaiphimform.Text;
                    PhimPcb.maydung = "ADTECH";
                    PhimPcb.sobo = sobo;
                    PhimPcb.tylex = txttylex.Text.Trim();
                    PhimPcb.tyley = txttyley.Text.Trim();
                    PhimPcb.nguoiyeucau = dropnguoiyeucau.Text.Trim();
                    PhimPcb.noidungyeucau = txtnoidungyeucau.Text.Trim();
                    PhimPcb.xacnhanpe = "";
                    PhimPcb.xacnhancam = "";
                    PhimPcb.mayin = "";
                    PhimPcb.hientrang = "Yêu Cầu Mới";
                    PhimPcb.giohoanthanh = "";
                    PhimPcb.ngayxuatxuong = "";
                    PhimPcb.ngaybaophe = "";
                    PhimPcb.noidungbaophe = "";
                    if (dropcustom.Text == "Tỷ Lệ Cố Định")
                    {
                        if (sobo == 1)
                        {
                            var taomach = service.CheckTyLeTaoMach(txtsanpham.Text.Trim(), droploaiphimform.Text);

                            if (taomach.Count > 0)
                            {
                                var kqtaomach = taomach.First();
                                if (soluong == 1)
                                {
                                    PhimPcb.phanloai = "Hàng Mới";
                                    PhimPcb.tylex = kqtaomach.tylex.Trim();
                                    PhimPcb.tyley = kqtaomach.tyley.Trim();
                                    service.InsertPhimPcb(PhimPcb);
                                    ClearPopupControls();
                                    GridView1.DataSourceID = "dsphimpcb";
                                    GridView1.DataBind();
                                    lbsoluong.Text = GridView1.Rows.Count.ToString();
                                    popup.Show();
                                }
                                else
                                {
                                    popup.Show();
                                    lbmessage.Text = "Hãy Để Số Lượng =1! Để Tạo Sản Phẩm Mới!";
                                }
                            }
                            else
                            {
                                popup.Show();
                                lbmessage.Text = "Sản Phẩm Chưa Có Tỷ Lệ Cố Định!";
                            }
                        }
                        else
                        {
                            var taomach = service.CheckTyLeTaoMach(txtsanpham.Text.Trim(), droploaiphimform.Text);

                            if (taomach.Count > 0)
                            {
                                var kqtaomach = taomach.First();
                                if (soluong == 1)
                                {
                                    PhimPcb.phanloai = "Làm Lại";
                                    PhimPcb.tylex = kqtaomach.tylex.Trim();
                                    PhimPcb.tyley = kqtaomach.tyley.Trim();
                                    service.InsertPhimPcb(PhimPcb);
                                    ClearPopupControls();
                                    GridView1.DataSourceID = "dsphimpcb";
                                    GridView1.DataBind();
                                    lbsoluong.Text = GridView1.Rows.Count.ToString();
                                    popup.Show();
                                }
                                else
                                {
                                    for (int i = 0; i < soluong; i++)
                                    {
                                        PhimPcb.phanloai = "Làm Lại";
                                        PhimPcb.tylex = kqtaomach.tylex.Trim();
                                        PhimPcb.tyley = kqtaomach.tyley.Trim();
                                        sobo = service.GetMaxSoBoPhimPcb("MA3-1F", txtsanpham.Text.Trim(), droploaiphimform.Text);
                                        PhimPcb.sobo = sobo;
                                        service.InsertPhimPcb(PhimPcb);
                                    }
                                    ClearPopupControls();
                                    GridView1.DataSourceID = "dsphimpcb";
                                    GridView1.DataBind();
                                    lbsoluong.Text = GridView1.Rows.Count.ToString();
                                    popup.Show();
                                }
                            }
                            else
                            {
                                popup.Show();
                                lbmessage.Text = "Sản Phẩm Chưa Có Tỷ Lệ Cố Định!";
                            }
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(txtsanpham.Text.Trim()) && !string.IsNullOrEmpty(droploaiphimform.Text) && !string.IsNullOrEmpty(dropnguoiyeucau.Text) && !string.IsNullOrEmpty(txttylex.Text) && !string.IsNullOrEmpty(txttyley.Text))
                        {
                            double x, y;
                            bool checkx = double.TryParse(txttylex.Text, out x);
                            bool checky = double.TryParse(txttyley.Text, out y);
                            if (sobo == 1)
                            {
                                if (checkx && checky)
                                {
                                    if (soluong == 1)
                                    {
                                        PhimPcb.phanloai = "Hàng Mới";
                                        PhimPcb.hientrang = "Tỷ Lệ Bất Thường";
                                        service.InsertPhimPcb(PhimPcb);
                                        ClearPopupControls();
                                        GridView1.DataSourceID = "dsphimpcb";
                                        GridView1.DataBind();
                                        lbsoluong.Text = GridView1.Rows.Count.ToString();
                                        popup.Show();
                                    }
                                    else
                                    {
                                        popup.Show();
                                        lbmessage.Text = "Hãy Để Số Lượng =1! Để Tạo Sản Phẩm Mới!";
                                    }
                                }
                                else
                                {
                                    popup.Show();
                                    lbmessage.Text = "Tỷ lệ X và Y phải là số !";
                                }
                            }
                            else
                            {
                                if (checkx && checky)
                                {
                                    if (soluong == 1)
                                    {
                                        PhimPcb.phanloai = "Làm Lại";
                                        PhimPcb.hientrang = "Tỷ Lệ Bất Thường";
                                        service.InsertPhimPcb(PhimPcb);
                                        ClearPopupControls();
                                        GridView1.DataSourceID = "dsphimpcb";
                                        GridView1.DataBind();
                                        lbsoluong.Text = GridView1.Rows.Count.ToString();
                                        popup.Show();
                                    }
                                    else
                                    {
                                        for (int i = 0; i < soluong; i++)
                                        {
                                            PhimPcb.phanloai = "Làm Lại";
                                            PhimPcb.hientrang = "Tỷ Lệ Bất Thường";
                                            sobo = service.GetMaxSoBoPhimPcb("MA3-1F", txtsanpham.Text.Trim(), droploaiphimform.Text);
                                            PhimPcb.sobo = sobo;
                                            service.InsertPhimPcb(PhimPcb);
                                        }
                                        ClearPopupControls();
                                        GridView1.DataSourceID = "dsphimpcb";
                                        GridView1.DataBind();
                                        lbsoluong.Text = GridView1.Rows.Count.ToString();
                                        popup.Show();
                                    }
                                }
                                else
                                {
                                    popup.Show();
                                    lbmessage.Text = "Tỷ lệ X và Y phải là số !";
                                }
                            }
                        }
                        else
                        {
                            popup.Show();
                            lbmessage.Text = "Không Để Trống Tên Sản Phẩm,Loại Phim,Người Yêu Cầu và Tỷ Lệ !";
                        }
                    }
                }
                else
                {
                    popup.Show();
                    lbmessage.Text = "Không Để Trống Tên Sản Phẩm,Loại Phim,Người Yêu Cầu và Tỷ Lệ !";
                }
            }
        }

        protected void dropcustom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dropcustom.Text == "Tỷ lệ theo yêu cầu")
            {
                txttylex.Visible = true;
                txttyley.Visible = true;
                popup.Show();
            }
            else
            {
                txttylex.Visible = false;
                txttyley.Visible = false;
                popup.Show();
            }
        }

        protected void droploaiphim_SelectedIndexChanged(object sender, EventArgs e)
        {
            var service = new Service();
            GridView1.DataSourceID = null;
            GridView1.DataSource = service.SearchPhimPcbByMa3_1f(droploaiphim.Text, txttimkiemsanpham.Text.Trim(), drophientrang.Text);
            GridView1.DataBind();
            lbsoluong.Text = GridView1.Rows.Count.ToString();
        }
        public string calamviec()
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
        public string thoigianhoanthanh()
        {
            string hour = null;
            if ((drophientrang.Text == "Đã Xong"))
            {
                hour = DateTime.Now.ToShortTimeString();
            }
            if ((drophientrang.Text == "Đã Chuyển Xưởng"))
            {
                string thoigiancu = hftime.Value;
                DateTime convertthoigian = Convert.ToDateTime(thoigiancu);
                int giomoi = int.Parse(convertthoigian.AddHours(1).ToString("HH"));
                int phutmoi = convertthoigian.Minute;
                hour = giomoi + ":" + phutmoi;
            }
            return hour;

        }
        public string ngayxuathang()
        {

            string ngayxuat = null;
            if (drophientrang.Text == "Đã Chuyển Xưởng")
            {
                ngayxuat = DateTime.Today.ToString("dd/MM/yy");
            }
            return ngayxuat;
        }
        public string ngayphe()
        {

            string phe = null;
            if (drophientrang.Text == "Đã Báo Phế")
            {
                phe = DateTime.Today.ToString("dd/MM/yy");
            }
            return phe;
        }
        public string NgayYeuCau()
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