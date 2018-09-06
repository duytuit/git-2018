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

namespace HTQuanLyFilm.PE
{
    public partial class PE_pcb : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txttimkiemsanpham.Attributes["placeholder"] = "Tìm Sản Phẩm...";
            lbsoluong.Text = GridView1.Rows.Count.ToString();
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
            dropsoluong.Text = null;
        }
        #endregion
        protected void SearchByDate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFromdate.Text) && !string.IsNullOrEmpty(txtTodate.Text))
            {
                var service = new Service();
                var result = service.GetPhimPcbByDateFilm(Convert.ToDateTime(txtFromdate.Text), Convert.ToDateTime(txtTodate.Text));
                GridView1.DataSourceID = null;
                GridView1.DataSource = result;
                GridView1.DataBind();
                dropbophan.Text = null;
                txttimkiemsanpham.Text = null;
                drophientrang.Text = null;
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
        public override void VerifyRenderingInServerForm(Control control)
        {
            /*Tell the compiler that the control is rendered
             * explicitly by overriding the VerifyRenderingInServerForm event.*/
        }
        protected void btnthemmoi_Click(object sender, EventArgs e)
        {
            hfIdpcb.Value = "insert";
            lblHeader.Text = "Add PhimPcb";
            lbmessage.Text = "";
            ClearPopupControls();
            txtsanpham.Enabled = true;
            droploaiphimform.Enabled = true;
            txttylex.Enabled = true;
            txttyley.Enabled = true;
            dropnguoiyeucau.Visible = true;
            dropsoluong.Visible = true;
            txtnoidungyeucau.Enabled = true;
            popup.Show();
        }

        protected void txttimkiemsanpham_TextChanged(object sender, EventArgs e)
        {
            var service = new Service();
            GridView1.DataSourceID = null;
            GridView1.DataSource = service.SearchPhimPcb(dropbophan.Text, txttimkiemsanpham.Text.Trim(), drophientrang.Text);
            GridView1.DataBind();
            lbsoluong.Text = GridView1.Rows.Count.ToString();
        }

        protected void drophientrang_SelectedIndexChanged(object sender, EventArgs e)
        {
            var service = new Service();
            GridView1.DataSourceID = null;
            GridView1.DataSource = service.SearchPhimPcb(dropbophan.Text, txttimkiemsanpham.Text.Trim(), drophientrang.Text);
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
                if (!string.IsNullOrEmpty(txtsanpham.Text.Trim()) && !string.IsNullOrEmpty(droploaiphimform.Text) && !string.IsNullOrEmpty(txttylex.Text) && !string.IsNullOrEmpty(txttyley.Text) && !string.IsNullOrEmpty(dropnguoiyeucau.Text))
                {
                    var service = new Service();
                    var PhimPcb = new BusinessObjects.PhimPcbBUS();

                    double x, y;
                    bool checkx = double.TryParse(txttylex.Text, out x);
                    bool checky = double.TryParse(txttyley.Text, out y);

                    int soluong = int.Parse(dropsoluong.Text);
                    int sobo = service.GetMaxSoBoPhimPcbByPEPT(txtsanpham.Text.Trim(), droploaiphimform.Text);


                    PhimPcb.ca = calamviec();
                    PhimPcb.ngay = Convert.ToDateTime(NgayYeuCau());
                    PhimPcb.gio = DateTime.Now.ToString("HH:mm");
                    PhimPcb.bophan = "PE";
                    PhimPcb.masanpham = txtsanpham.Text.Trim();
                    PhimPcb.loaiphim = droploaiphimform.Text;
                    PhimPcb.maydung = "";
                    PhimPcb.sobo = sobo;
                    PhimPcb.tylex = txttylex.Text.Trim();
                    PhimPcb.tyley = txttyley.Text.Trim();
                    PhimPcb.nguoiyeucau = dropnguoiyeucau.Text.Trim();
                    PhimPcb.noidungyeucau = txtnoidungyeucau.Text.Trim();
                    PhimPcb.xacnhanpe = txtxacnhanpe.Text.Trim();
                    PhimPcb.xacnhancam = "";
                    PhimPcb.mayin = "";
                    PhimPcb.hientrang = "Yêu Cầu Mới";
                    PhimPcb.giohoanthanh = "";
                    PhimPcb.ngayxuatxuong = "";
                    PhimPcb.ngaybaophe = "";
                    PhimPcb.noidungbaophe = "";

                    if (sobo == 1)
                    {
                        if (checkx && checky)
                        {
                            if (soluong == 1)
                            {
                                PhimPcb.phanloai = "Hàng Mới";
                                service.InsertPhimPcb(PhimPcb);
                                GridView1.DataSourceID = "dsphimpcb";
                                GridView1.DataBind();
                                lbsoluong.Text = GridView1.Rows.Count.ToString();
                                ClearPopupControls();
                                popup.Show();
                                lbmessage.Text = "";
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
                                service.InsertPhimPcb(PhimPcb);
                                GridView1.DataSourceID = "dsphimpcb";
                                GridView1.DataBind();
                                lbsoluong.Text = GridView1.Rows.Count.ToString();
                                ClearPopupControls();
                                popup.Show();
                                lbmessage.Text = "";
                            }
                            else
                            {
                                for (int i = 0; i < soluong; i++)
                                {
                                    PhimPcb.phanloai = "Làm Lại";
                                    sobo = service.GetMaxSoBoPhimPcbByPEPT(txtsanpham.Text.Trim(), droploaiphimform.Text);
                                    PhimPcb.sobo = sobo;
                                    service.InsertPhimPcb(PhimPcb);
                                }
                                GridView1.DataSourceID = "dsphimpcb";
                                GridView1.DataBind();
                                lbsoluong.Text = GridView1.Rows.Count.ToString();
                                ClearPopupControls();
                                popup.Show();
                                lbmessage.Text = "";
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
                    lbmessage.Text = "Không Để Trống Tên Sản Phẩm,Loại Phim,Tỷ Lệ và Người Yêu Cầu !";
                }
            }
            else
            {
                var service = new Service();
                var PhimPcb = new BusinessObjects.PhimPcbBUS();

                if (hfhientrang.Value == "Tỷ Lệ Bất Thường")
                {
                    if (!string.IsNullOrEmpty(txtxacnhanpe.Text))
                    {

                        int idpcb = Convert.ToInt32(hfIdpcb.Value);
                        string xacnhanpe = txtxacnhanpe.Text.Trim();
                        string hientrang = "Yêu Cầu Mới";
                        service.UpdatePhimPcbByPE(idpcb, xacnhanpe, hientrang);
                        GridView1.DataSourceID = "dsphimpcb";
                        GridView1.DataBind();
                        lbsoluong.Text = GridView1.Rows.Count.ToString();
                        lbmessage.Text = "";
                        dropbophan.Text = null;
                        txttimkiemsanpham.Text = null;
                        drophientrang.Text = null;
                    }
                    else
                    {
                        popup.Show();
                        lbmessage.Text = "Hãy Xác Nhận Lại Yêu Cầu Phim Cho Bô Phận !";
                    }
                }
                else
                {
                    popup.Show();
                    lbmessage.Text = "Bạn Chỉ Xác Nhận Hàng Có Tỷ Lệ Bất Thường!";
                }
            }
        }

        protected void lkEdit_Click(object sender, EventArgs e)
        {
            txtsanpham.Enabled = false;
            droploaiphimform.Enabled = false;
            txttylex.Enabled = false;
            txttyley.Enabled = false;
            dropnguoiyeucau.Visible = false;
            txtnoidungyeucau.Enabled = false;
            dropsoluong.Visible = false;
            GridViewRow gvRow = (GridViewRow)((LinkButton)sender).NamingContainer;
            Int32 Idpcb = Convert.ToInt32(GridView1.DataKeys[gvRow.RowIndex].Value);
            hfIdpcb.Value = Idpcb.ToString();
            var service = new Service();
            var result = service.GetPhimPcbById(Convert.ToInt32(hfIdpcb.Value));
            var kq = result.First();
            txtsanpham.Text = kq.masanpham.Trim();
            droploaiphimform.Text = kq.loaiphim;
            txttylex.Text = kq.tylex.Trim();
            txttyley.Text = kq.tyley.Trim();
            txtnoidungyeucau.Text = kq.noidungyeucau;
            txtxacnhanpe.Text = kq.xacnhanpe;
            hfhientrang.Value = kq.hientrang;
            lblHeader.Text = "Edit PhimPcb";
            lbmessage.Text = "";
            this.popup.Show();
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

        protected void dropbophan_SelectedIndexChanged(object sender, EventArgs e)
        {
            var service = new Service();
            GridView1.DataSourceID = null;
            GridView1.DataSource = service.SearchPhimPcb(dropbophan.Text, txttimkiemsanpham.Text.Trim(), drophientrang.Text);
            GridView1.DataBind();
            lbsoluong.Text = GridView1.Rows.Count.ToString();
        }
    }
}