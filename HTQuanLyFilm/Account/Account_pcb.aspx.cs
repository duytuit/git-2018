﻿using System;
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

namespace HTQuanLyFilm.Account
{
    public partial class Account_pcb : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txttimkiemsanpham.Attributes["placeholder"] = "Tìm Sản Phẩm...";
            lbsoluong.Text = GridView1.Rows.Count.ToString();
        }
        #region[Clear Modal Popup controls]
        private void ClearPopupControls()
        {

            dropbophanform.Text = "";
            txtsanpham.Text = "";
            dropphanloai.Text = "";
            droploaiphim.Text = "";
            dropmaydung.Text = "";
            txttylex.Text = "";
            txttyley.Text = "";
            txtnguoiyeucau.Text = "";
            txtnoidungyeucau.Text = "";
            dropxacnhancam.Text = "";
            dropmayin.Text = "";
            drophientrangform.Text = "";
            dropnoidungbaophe.Text = "";
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
        public override void VerifyRenderingInServerForm(Control control)
        {
            /*Tell the compiler that the control is rendered
             * explicitly by overriding the VerifyRenderingInServerForm event.*/
        }
        protected void btnthemmoi_Click(object sender, EventArgs e)
        {
            //ClearPopupControls();
            //dropphanloai.Enabled = false;
            //dropbophanform.Enabled = true;
            //txtsanpham.Enabled = true;
            //droploaiphimform.Enabled = true;
            //dropsoluong.Visible = true;
            //dropnoidungbaophe.Visible = false;
            //txttylex.Enabled = true;
            //txttyley.Enabled = true;
            //hfIdpcb.Value = "insert";
            //lblHeader.Text = "Add PhimPcb";
            //popup.Show();
        }

        protected void txttimkiemsanpham_TextChanged(object sender, EventArgs e)
        {
            var service = new Service();
            GridView1.DataSourceID = null;
            GridView1.DataSource = service.SearchPhimPcb(droploaiphim.Text, txttimkiemsanpham.Text.Trim(), drophientrang.Text);
            GridView1.DataBind();
            lbsoluong.Text = GridView1.Rows.Count.ToString();
        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            var service = new Service();
            var PhimPcb = new BusinessObjects.PhimPcbBUS();
            foreach (GridViewRow grow in GridView1.Rows)
            {
                CheckBox chkdel = (CheckBox)grow.FindControl("chk");
                if (chkdel.Checked)
                {

                    PhimPcb.idpcb = Convert.ToInt32(grow.Cells[1].Text);
                    service.DeletePhimPcb(PhimPcb);
                }
            }
            GridView1.DataSourceID = "dsphimpcb";
            GridView1.DataBind();
            lbsoluong.Text = GridView1.Rows.Count.ToString();

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //if (hfIdpcb.Value == "insert")
            //{

            //    if (!string.IsNullOrEmpty(txtsanpham.Text.Trim()) && !string.IsNullOrEmpty(droploaiphimform.Text) && !string.IsNullOrEmpty(txttylex.Text) && !string.IsNullOrEmpty(txttyley.Text))
            //    {
            //        double x, y;
            //        bool checkx = double.TryParse(txttylex.Text, out x);
            //        bool checky = double.TryParse(txttyley.Text, out y);

            //        var service = new Service();
            //        var PhimPcb = new BusinessObjects.PhimPcbBUS();

            //        int soluong = int.Parse(dropsoluong.Text);
            //        int sobo = service.GetMaxSoBoPhimPcb(txtsanpham.Text.Trim(), droploaiphimform.Text);

            //        double tylex1 = Convert.ToDouble(txttylex.Text.Trim(), System.Globalization.CultureInfo.InvariantCulture);
            //        double tyley1 = Convert.ToDouble(txttyley.Text.Trim(), System.Globalization.CultureInfo.InvariantCulture);

            //        PhimPcb.ca = calamviec();
            //        PhimPcb.ngay = Convert.ToDateTime(NgayYeuCau());
            //        PhimPcb.gio = DateTime.Now.ToString("HH:mm");
            //        PhimPcb.bophan = dropbophanform.Text;
            //        PhimPcb.masanpham = txtsanpham.Text.Trim();
            //        PhimPcb.loaiphim = droploaiphimform.Text;
            //        PhimPcb.maydung = dropmaydung.Text;
            //        PhimPcb.sobo = sobo;
            //        PhimPcb.tylex = txttylex.Text.Trim();
            //        PhimPcb.tyley = txttyley.Text.Trim();
            //        PhimPcb.nguoiyeucau = txtnguoiyeucau.Text.Trim();
            //        PhimPcb.noidungyeucau = txtnoidungyeucau.Text.Trim();
            //        PhimPcb.xacnhanpe = "";
            //        PhimPcb.xacnhancam = dropxacnhancam.Text;
            //        PhimPcb.mayin = dropmayin.Text;
            //        PhimPcb.hientrang = drophientrangform.Text;
            //        PhimPcb.giohoanthanh = "";
            //        PhimPcb.ngayxuatxuong = "";
            //        PhimPcb.ngaybaophe = "";
            //        PhimPcb.noidungbaophe = dropnoidungbaophe.Text;

            //        if (sobo == 1)
            //        {
            //            if (checkx && checky)
            //            {
            //                var taomach = service.CheckTyLeTaoMach(txtsanpham.Text.Trim(), droploaiphimform.Text);
            //                var phuson = service.CheckTyLePhuSon(txtsanpham.Text.Trim(), droploaiphimform.Text);


            //                if (taomach.Count > 0)
            //                {
            //                    var kqtaomach = taomach.First();
            //                    double tylex2 = Convert.ToDouble(kqtaomach.tylex.ToString(), System.Globalization.CultureInfo.InvariantCulture);
            //                    double tyley2 = Convert.ToDouble(kqtaomach.tyley.ToString(), System.Globalization.CultureInfo.InvariantCulture);
            //                    if (tylex1 == tylex2 && tyley1 == tyley2)
            //                    {
            //                        if (soluong == 1)
            //                        {
            //                            PhimPcb.phanloai = "Hàng Mới";
            //                            service.InsertPhimPcb(PhimPcb);
            //                            GridView1.DataSourceID = "dsphimpcb";
            //                            GridView1.DataBind();
            //                            lbsoluong.Text = GridView1.Rows.Count.ToString();
            //                        }
            //                        else
            //                        {
            //                            popup.Show();
            //                            lbmessage.Text = "Hãy Để Số Lượng =1! Để Tạo Sản Phẩm Mới!";
            //                        }
            //                    }
            //                    else
            //                    {
            //                        if (soluong == 1)
            //                        {
            //                            //PhimPcb.hientrang = "Tỷ Lệ Bất Thường";
            //                            PhimPcb.phanloai = "Hàng Mới";
            //                            service.InsertPhimPcb(PhimPcb);
            //                            GridView1.DataSourceID = "dsphimpcb";
            //                            GridView1.DataBind();
            //                            lbsoluong.Text = GridView1.Rows.Count.ToString();
            //                        }
            //                        else
            //                        {
            //                            popup.Show();
            //                            lbmessage.Text = "Hãy Để Số Lượng =1! Để Tạo Sản Phẩm Mới!";
            //                        }
            //                    }
            //                }
            //                else if (phuson.Count > 0)
            //                {
            //                    var kqphuson = phuson.First();
            //                    double tylexmin = Convert.ToDouble(kqphuson.tylexmin.ToString(), System.Globalization.CultureInfo.InvariantCulture);
            //                    double tylexmax = Convert.ToDouble(kqphuson.tylexmax.ToString(), System.Globalization.CultureInfo.InvariantCulture);
            //                    double tyleymin = Convert.ToDouble(kqphuson.tyleymin.ToString(), System.Globalization.CultureInfo.InvariantCulture);
            //                    double tyleymax = Convert.ToDouble(kqphuson.tyleymax.ToString(), System.Globalization.CultureInfo.InvariantCulture);
            //                    if (tylexmin < tylex1 && tylex1 < tylexmax)
            //                    {
            //                        if (tyleymin < tyley1 && tyley1 < tyleymax)
            //                        {
            //                            if (soluong == 1)
            //                            {
            //                                PhimPcb.phanloai = "Hàng Mới";
            //                                service.InsertPhimPcb(PhimPcb);
            //                                GridView1.DataSourceID = "dsphimpcb";
            //                                GridView1.DataBind();
            //                                lbsoluong.Text = GridView1.Rows.Count.ToString();
            //                            }
            //                            else
            //                            {
            //                                popup.Show();
            //                                lbmessage.Text = "Hãy Để Số Lượng =1! Để Tạo Sản Phẩm Mới!";
            //                            }
            //                        }
            //                        else
            //                        {

            //                            if (soluong == 1)
            //                            {
            //                                // PhimPcb.hientrang = "Tỷ Lệ Bất Thường";
            //                                PhimPcb.phanloai = "Hàng Mới";
            //                                service.InsertPhimPcb(PhimPcb);
            //                                GridView1.DataSourceID = "dsphimpcb";
            //                                GridView1.DataBind();
            //                                lbsoluong.Text = GridView1.Rows.Count.ToString();
            //                            }
            //                            else
            //                            {
            //                                popup.Show();
            //                                lbmessage.Text = "Hãy Để Số Lượng =1! Để Tạo Sản Phẩm Mới!";
            //                            }
            //                        }
            //                    }
            //                }
            //                else
            //                {
            //                    if (soluong == 1)
            //                    {

            //                        PhimPcb.phanloai = "Hàng Mới";
            //                        service.InsertPhimPcb(PhimPcb);
            //                        GridView1.DataSourceID = "dsphimpcb";
            //                        GridView1.DataBind();
            //                        lbsoluong.Text = GridView1.Rows.Count.ToString();
            //                    }
            //                    else
            //                    {
            //                        popup.Show();
            //                        lbmessage.Text = "Hãy Để Số Lượng =1! Để Tạo Sản Phẩm Mới!";
            //                    }
            //                }
            //            }

            //            else
            //            {
            //                popup.Show();
            //                lbmessage.Text = "Tỷ lệ X và Y phải là số !";
            //            }
            //        }
            //        else
            //        {

            //            if (checkx && checky)
            //            {
            //                var taomach = service.CheckTyLeTaoMach(txtsanpham.Text.Trim(), droploaiphimform.Text);
            //                var phuson = service.CheckTyLePhuSon(txtsanpham.Text.Trim(), droploaiphimform.Text);


            //                if (taomach.Count > 0)
            //                {
            //                    var kqtaomach = taomach.First();
            //                    double tylex2 = Convert.ToDouble(kqtaomach.tylex.ToString(), System.Globalization.CultureInfo.InvariantCulture);
            //                    double tyley2 = Convert.ToDouble(kqtaomach.tyley.ToString(), System.Globalization.CultureInfo.InvariantCulture);
            //                    if (tylex1 == tylex2 && tyley1 == tyley2)
            //                    {
            //                        if (soluong == 1)
            //                        {
            //                            PhimPcb.phanloai = "Làm Lại";
            //                            service.InsertPhimPcb(PhimPcb);
            //                            GridView1.DataSourceID = "dsphimpcb";
            //                            GridView1.DataBind();
            //                            lbsoluong.Text = GridView1.Rows.Count.ToString();
            //                        }
            //                        else
            //                        {
            //                            for (int i = 0; i < soluong; i++)
            //                            {
            //                                PhimPcb.phanloai = "Làm Lại";
            //                                sobo = service.GetMaxSoBoPhimPcb(txtsanpham.Text.Trim(), droploaiphimform.Text);
            //                                PhimPcb.sobo = sobo;
            //                                service.InsertPhimPcb(PhimPcb);
            //                            }
            //                            GridView1.DataSourceID = "dsphimpcb";
            //                            GridView1.DataBind();
            //                            lbsoluong.Text = GridView1.Rows.Count.ToString();

            //                        }
            //                    }
            //                }
            //                if (phuson.Count > 0)
            //                {
            //                    var kqphuson = phuson.First();
            //                    double tylexmin = Convert.ToDouble(kqphuson.tylexmin.ToString(), System.Globalization.CultureInfo.InvariantCulture);
            //                    double tylexmax = Convert.ToDouble(kqphuson.tylexmax.ToString(), System.Globalization.CultureInfo.InvariantCulture);
            //                    double tyleymin = Convert.ToDouble(kqphuson.tyleymin.ToString(), System.Globalization.CultureInfo.InvariantCulture);
            //                    double tyleymax = Convert.ToDouble(kqphuson.tyleymax.ToString(), System.Globalization.CultureInfo.InvariantCulture);
            //                    if (tylexmin < tylex1 && tylex1 < tylexmax)
            //                    {
            //                        if (tyleymin < tyley1 && tyley1 < tyleymax)
            //                        {
            //                            if (soluong == 1)
            //                            {
            //                                PhimPcb.phanloai = "Làm Lại";
            //                                service.InsertPhimPcb(PhimPcb);
            //                                GridView1.DataSourceID = "dsphimpcb";
            //                                GridView1.DataBind();
            //                                lbsoluong.Text = GridView1.Rows.Count.ToString();
            //                            }
            //                            else
            //                            {
            //                                for (int i = 0; i < soluong; i++)
            //                                {
            //                                    PhimPcb.phanloai = "Làm Lại";
            //                                    sobo = service.GetMaxSoBoPhimPcb(txtsanpham.Text.Trim(), droploaiphimform.Text);
            //                                    PhimPcb.sobo = sobo;
            //                                    service.InsertPhimPcb(PhimPcb);
            //                                }
            //                                GridView1.DataSourceID = "dsphimpcb";
            //                                GridView1.DataBind();
            //                                lbsoluong.Text = GridView1.Rows.Count.ToString();

            //                            }
            //                        }

            //                    }
            //                }
            //                else
            //                {
            //                    if (soluong == 1)
            //                    {
            //                        PhimPcb.hientrang = "Tỷ Lệ Bất Thường";
            //                        PhimPcb.phanloai = "Làm Lại";
            //                        service.InsertPhimPcb(PhimPcb);
            //                        GridView1.DataSourceID = "dsphimpcb";
            //                        GridView1.DataBind();
            //                        lbsoluong.Text = GridView1.Rows.Count.ToString();
            //                    }
            //                    else
            //                    {
            //                        for (int i = 0; i < soluong; i++)
            //                        {
            //                            PhimPcb.hientrang = "Tỷ Lệ Bất Thường";
            //                            PhimPcb.phanloai = "Làm Lại";
            //                            sobo = service.GetMaxSoBoPhimPcb(txtsanpham.Text.Trim(), droploaiphimform.Text);
            //                            PhimPcb.sobo = sobo;
            //                            service.InsertPhimPcb(PhimPcb);
            //                        }
            //                        GridView1.DataSourceID = "dsphimpcb";
            //                        GridView1.DataBind();
            //                        lbsoluong.Text = GridView1.Rows.Count.ToString();

            //                    }
            //                }
            //            }

            //            else
            //            {
            //                popup.Show();
            //                lbmessage.Text = "Tỷ lệ X và Y phải là số !";
            //            }


            //        }
            //    }
            //    else
            //    {
            //        popup.Show();
            //        lbmessage.Text = "Không Để Trống Tên Sản Phẩm,Loại Phim và Tỷ Lệ !";
            //    }
            //}
            //else
            //{
            //    if (!string.IsNullOrEmpty(txtsanpham.Text.Trim()) && !string.IsNullOrEmpty(droploaiphimform.Text) && !string.IsNullOrEmpty(txttylex.Text) && !string.IsNullOrEmpty(txttyley.Text))
            //    {
            //        double x, y;
            //        bool checkx = double.TryParse(txttylex.Text, out x);
            //        bool checky = double.TryParse(txttyley.Text, out y);

            //        var service = new Service();
            //        var PhimPcb = new BusinessObjects.PhimPcbBUS();

            //        PhimPcb.idpcb = Convert.ToInt32(hfIdpcb.Value);
            //        PhimPcb.bophan = dropbophanform.Text;
            //        PhimPcb.masanpham = txtsanpham.Text.Trim();
            //        PhimPcb.phanloai = dropphanloai.Text;
            //        PhimPcb.loaiphim = droploaiphimform.Text;
            //        PhimPcb.maydung = dropmaydung.Text;
            //        PhimPcb.tylex = txttylex.Text.Trim();
            //        PhimPcb.tyley = txttyley.Text.Trim();
            //        PhimPcb.nguoiyeucau = txtnguoiyeucau.Text.Trim();
            //        PhimPcb.noidungyeucau = txtnoidungyeucau.Text.Trim();
            //        PhimPcb.xacnhancam = dropxacnhancam.Text;
            //        PhimPcb.mayin = dropmayin.Text;
            //        PhimPcb.hientrang = drophientrangform.Text;
            //        PhimPcb.giohoanthanh = thoigianhoanthanh();
            //        PhimPcb.ngayxuatxuong = ngayxuathang();
            //        PhimPcb.ngaybaophe = ngayphe();
            //        PhimPcb.noidungbaophe = dropnoidungbaophe.Text;


            //        if (checkx && checky)
            //        {
            //            service.UpdatePhimPcb(PhimPcb);
            //            GridView1.DataSourceID = "dsphimpcb";
            //            GridView1.DataBind();
            //        }
            //        else
            //        {
            //            popup.Show();
            //            lbmessage.Text = "Tỷ lệ X và Y phải là số !";
            //        }

            //    }
            //    else
            //    {
            //        popup.Show();
            //        lbmessage.Text = "Không Để Trống Tên Sản Phẩm,Loại Phim và Tỷ Lệ !";
            //    }
            //}
        }

        protected void lkEdit_Click(object sender, EventArgs e)
        {
            //lbmessage.Text = "";
            //dropphanloai.Visible = true;
            //dropsoluong.Visible = false;
            //dropbophanform.Enabled = false;
            //txtsanpham.Enabled = false;
            //droploaiphimform.Enabled = false;
            //dropnoidungbaophe.Visible = true;
            //txttylex.Enabled = false;
            //txttyley.Enabled = false;
            //GridViewRow gvRow = (GridViewRow)((LinkButton)sender).NamingContainer;
            //Int32 Idpcb = Convert.ToInt32(GridView1.DataKeys[gvRow.RowIndex].Value);
            //hfIdpcb.Value = Idpcb.ToString();
            //var service = new Service();
            //var result = service.GetPhimPcbById(Convert.ToInt32(hfIdpcb.Value));
            //var kq = result.First();
            //hftime.Value = kq.gio;
            //dropbophanform.Text = kq.bophan;
            //txtsanpham.Text = kq.masanpham.Trim();
            //dropphanloai.Text = kq.phanloai;
            //droploaiphimform.Text = kq.loaiphim;
            //dropmaydung.Text = kq.maydung;
            //txttylex.Text = kq.tylex.Trim();
            //txttyley.Text = kq.tyley.Trim();
            //txtnguoiyeucau.Text = kq.nguoiyeucau.Trim();
            //txtnoidungyeucau.Text = kq.noidungyeucau.Trim();
            //dropxacnhancam.Text = kq.xacnhancam;
            //dropmayin.Text = kq.mayin;
            //drophientrangform.Text = kq.hientrang;
            //dropnoidungbaophe.Text = kq.noidungbaophe;
            //lblHeader.Text = "Edit PhimPcb";
            //popup.Show();
        }

        protected void drophientrang_SelectedIndexChanged(object sender, EventArgs e)
        {
            var service = new Service();
            GridView1.DataSourceID = null;
            GridView1.DataSource = service.SearchPhimPcb(droploaiphim.Text, txttimkiemsanpham.Text.Trim(), drophientrang.Text);
            GridView1.DataBind();
            lbsoluong.Text = GridView1.Rows.Count.ToString();
        }

        protected void dropbophan_SelectedIndexChanged(object sender, EventArgs e)
        {
            var service = new Service();
            GridView1.DataSourceID = null;
            GridView1.DataSource = service.SearchPhimPcb(droploaiphim.Text, txttimkiemsanpham.Text.Trim(), drophientrang.Text);
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
            if ((drophientrangform.Text == "Đã Xong"))
            {
                hour = DateTime.Now.ToShortTimeString();
            }
            if ((drophientrangform.Text == "Đã Chuyển Xưởng"))
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
            if (drophientrangform.Text == "Đã Chuyển Xưởng")
            {
                ngayxuat = DateTime.Today.ToString("dd/MM/yy");
            }
            return ngayxuat;
        }
        public string ngayphe()
        {

            string phe = null;
            if (drophientrangform.Text == "Đã Báo Phế")
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
                        e.Row.Cells[7].BackColor = Color.FromArgb(0xCC, 0xFF, 0x99);
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

        protected void bind()
        {
            GridView1.DataSourceID = "dsphimpcb";
            GridView1.DataBind();
        }
        protected void Timer1_Tick(object sender, EventArgs e)
        {
            bind();
        }
    }
}