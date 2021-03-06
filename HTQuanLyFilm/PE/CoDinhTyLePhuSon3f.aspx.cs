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


namespace HTQuanLyFilm.PE
{
    public partial class CoDinhTyLePhuSon3f : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            txttimkiemsanpham.Attributes["placeholder"] = "Enter Press Sản Phẩm...";
            lbsoluong.Text = GridView1.Rows.Count.ToString();
        }

        private void GetCoDinhPhuSon()
        {
            var service = new Service();
            GridView1.DataSource = service.GetCoDinhTyLePhuSon();
            GridView1.DataBind();
        }

        protected void btnthemmoi_Click(object sender, EventArgs e)
        {
            ClearPopupControls();
            hfIdphuson.Value = "insert";
            popup.Show();
        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            var service = new Service();
            var CoDinhPhuSon = new BusinessObjects.CoDinhTyLePhuSonBUS();

            foreach (GridViewRow grow in GridView1.Rows)
            {
                CheckBox chkdel = (CheckBox)grow.FindControl("chk");
                if (chkdel.Checked)
                {

                    CoDinhPhuSon.idphuson = Convert.ToInt32(grow.Cells[1].Text);
                    service.DeleteCoDinhTyLePhuSon(CoDinhPhuSon);
                }
            }
            GridView1.DataSourceID = "CoDinhPhuSon";
            GridView1.DataBind();
            lbsoluong.Text = GridView1.Rows.Count.ToString();
        }


        #region[Clear Modal Popup controls]
        private void ClearPopupControls()
        {
            txtsanpham.Text = "";
            dropnguoitao.Text = "";
            droploaiphim.Text = "";
            txttylexmin.Text = "";
            txttylexmax.Text = "";
            txttyleymin.Text = "";
            txttyleymax.Text = "";
        }
        #endregion

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (hfIdphuson.Value == "insert")
            {
                if (!string.IsNullOrEmpty(txtsanpham.Text) && !string.IsNullOrEmpty(dropnguoitao.Text) && !string.IsNullOrEmpty(droploaiphim.Text))
                {
                    var service = new Service();
                    var CoDinhPhuSon = new BusinessObjects.CoDinhTyLePhuSonBUS();
                    CoDinhPhuSon.tensanpham = txtsanpham.Text.Trim();
                    CoDinhPhuSon.ngaytao = DateTime.Now;
                    CoDinhPhuSon.nguoitao = dropnguoitao.Text;
                    CoDinhPhuSon.loaiphim = droploaiphim.Text;
                    CoDinhPhuSon.tylexmin = txttylexmin.Text.Trim();
                    CoDinhPhuSon.tylexmax = txttylexmax.Text.Trim();
                    CoDinhPhuSon.tyleymin = txttyleymin.Text.Trim();
                    CoDinhPhuSon.tyleymax = txttyleymax.Text.Trim();
                    service.InsertCoDinhTyLePhuSon(CoDinhPhuSon);
                    GridView1.DataSourceID = "CoDinhPhuSon";
                    GridView1.DataBind();
                    lbsoluong.Text = GridView1.Rows.Count.ToString();
                    lbmassge.Text = "";
                }
                else
                {
                    lbmassge.Text = "không để trống tên sản phẩm, loại phim và người tạo";
                    popup.Show();
                }

            }
            else
            {
                if (!string.IsNullOrEmpty(txtsanpham.Text) && !string.IsNullOrEmpty(dropnguoitao.Text) && !string.IsNullOrEmpty(droploaiphim.Text))
                {
                    var service = new Service();
                    var CoDinhPhuSon = new BusinessObjects.CoDinhTyLePhuSonBUS();
                    CoDinhPhuSon.idphuson = Convert.ToInt32(hfIdphuson.Value);
                    CoDinhPhuSon.tensanpham = txtsanpham.Text.Trim();
                    CoDinhPhuSon.nguoitao = dropnguoitao.Text;
                    CoDinhPhuSon.ngaytao = DateTime.Now;
                    CoDinhPhuSon.loaiphim = droploaiphim.Text;
                    CoDinhPhuSon.tylexmin = txttylexmin.Text.Trim();
                    CoDinhPhuSon.tylexmax = txttylexmax.Text.Trim();
                    CoDinhPhuSon.tyleymin = txttyleymin.Text.Trim();
                    CoDinhPhuSon.tyleymax = txttyleymax.Text.Trim();
                    service.UpdateCoDinhTyLePhuSon(CoDinhPhuSon);
                    GridView1.DataSourceID = "CoDinhPhuSon";
                    GridView1.DataBind();
                    lbmassge.Text = "";
                }
                else
                {
                    lbmassge.Text = "không để trống tên sản phẩm, loại phim và người tạo";
                    popup.Show();
                }
            }
        }

        protected void txttimkiemsanpham_TextChanged(object sender, EventArgs e)
        {
            var service = new Service();
            GridView1.DataSourceID = null;
            GridView1.DataSource = service.GetCoDinhPhuSonBySanPham(txttimkiemsanpham.Text.Trim());
            GridView1.DataBind();
            lbsoluong.Text = GridView1.Rows.Count.ToString();

        }

        protected void SearchByDate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFromdate.Text) && !string.IsNullOrEmpty(txtTodate.Text))
            {
                var service = new Service();
                var result = service.GetCoDinhPhusonByDate(Convert.ToDateTime(txtFromdate.Text), Convert.ToDateTime(txtTodate.Text));
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

        protected void lkEdit_Click(object sender, EventArgs e)
        {

            GridViewRow gvRow = (GridViewRow)((LinkButton)sender).NamingContainer;
            int Idphuson = Convert.ToInt32(GridView1.DataKeys[gvRow.RowIndex].Value);
            hfIdphuson.Value = Idphuson.ToString();
            var service = new Service();
            var result = service.GetCoDinhTyLePhuSonByID(Convert.ToInt32(hfIdphuson.Value));
            var kq = result.First();
            txtsanpham.Text = kq.tensanpham.Trim();
            dropnguoitao.Text = kq.nguoitao;
            droploaiphim.Text = kq.loaiphim;
            txttylexmin.Text = kq.tylexmin.Trim();
            txttylexmax.Text = kq.tylexmax.Trim();
            txttyleymin.Text = kq.tyleymin.Trim();
            txttyleymax.Text = kq.tyleymax.Trim();
            popup.Show();
        }

        protected void TxtToExcel_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=Cố Định Tỷ Lệ Phủ Sơn.xls");
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
    }
}