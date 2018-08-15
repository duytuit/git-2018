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


namespace HTQuanLyFilm.PE
{
    public partial class CoDinhTyLePhuSon3f : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                GetData();
            txttimkiemsanpham.Attributes["placeholder"] = "Enter Press Sản Phẩm...";
        }
        private void DeleteRecord(int idphuson)
        {
            var service = new Service();
            var CoDinhPhuSon = new BusinessObjects.CoDinhTyLePhuSonBUS();
            CoDinhPhuSon.idphuson = idphuson;
            service.DeleteCoDinhTyLePhuSon(CoDinhPhuSon);
        }

        private void GetCoDinhPhuSon()
        {
             var service = new Service();
             GridView1.DataSource = service.GetCoDinhTyLePhuSon();
             GridView1.DataBind();
        }
        private void ShowMessage(int count)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("alert('");
            sb.Append(count.ToString());
            sb.Append(" records deleted.');");
            sb.Append("</script>");
            ClientScript.RegisterStartupScript(this.GetType(), "script", sb.ToString());
        }
        private void SetData()
        {
            int currentCount = 0;
            ArrayList arr = (ArrayList)ViewState["SelectedRecords"];
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox chk = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("chk");
                if (chk != null)
                {
                    chk.Checked = arr.Contains(GridView1.DataKeys[i].Value);
                        currentCount++;
                }
            }
            hfCount.Value = (arr.Count - currentCount).ToString();
        }
        private void GetData()
        {
            ArrayList arr;
            if (ViewState["SelectedRecords"] != null)
                arr = (ArrayList)ViewState["SelectedRecords"];
            else
                arr = new ArrayList();

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
               
                    CheckBox chk = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("chk");
                    if (chk.Checked)
                    {
                        if (!arr.Contains(GridView1.DataKeys[i].Value))
                        {
                            arr.Add(GridView1.DataKeys[i].Value);
                        }
                    }
                    else
                    {
                        if (arr.Contains(GridView1.DataKeys[i].Value))
                        {
                            arr.Remove(GridView1.DataKeys[i].Value);
                        }
                    }
               // }
            }
            ViewState["SelectedRecords"] = arr;
        }

        protected void btnthemmoi_Click(object sender, EventArgs e)
        {
            ClearPopupControls();
            popup.Show();
        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            int count = 0;
            SetData();
            GridView1.DataBind();
            ArrayList arr = (ArrayList)ViewState["SelectedRecords"];
            count = arr.Count;
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                if (arr.Contains(GridView1.DataKeys[i].Value))
                {
                    DeleteRecord(Convert.ToInt32(GridView1.DataKeys[i].Value.ToString()));
                    arr.Remove(GridView1.DataKeys[i].Value);
                }
            }
            ViewState["SelectedRecords"] = arr;
            hfCount.Value = "0";
            ShowMessage(count);
            GridView1.DataSourceID = "CoDinhPhuSon";
            GridView1.DataBind();
            
        }

      
        #region[Clear Modal Popup controls]
        private void ClearPopupControls()
        {
            txtsanpham.Text = "";
            txtngaytao.Text = "";
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
            if(hfIdphuson.Value=="0")
            { 
                var service = new Service();
                var CoDinhPhuSon = new BusinessObjects.CoDinhTyLePhuSonBUS();
                CoDinhPhuSon.tensanpham = txtsanpham.Text.Trim();
                CoDinhPhuSon.ngaytao = Convert.ToDateTime(txtngaytao.Text.Trim());
                CoDinhPhuSon.nguoitao = dropnguoitao.Text;
                CoDinhPhuSon.loaiphim = droploaiphim.Text;
                CoDinhPhuSon.tylexmin = txttylexmin.Text.Trim();
                CoDinhPhuSon.tylexmax = txttylexmax.Text.Trim();
                CoDinhPhuSon.tyleymin = txttyleymin.Text.Trim();
                CoDinhPhuSon.tyleymax = txttyleymax.Text.Trim();
                service.InsertCoDinhTyLePhuSon(CoDinhPhuSon);
                GridView1.DataSourceID = "CoDinhPhuSon";
                GridView1.DataBind();
            }
            else
            {
                var service = new Service();
                var CoDinhPhuSon = new BusinessObjects.CoDinhTyLePhuSonBUS();
                CoDinhPhuSon.idphuson = Convert.ToInt32(hfIdphuson.Value);
                CoDinhPhuSon.tensanpham = txtsanpham.Text.Trim();
                CoDinhPhuSon.nguoitao = dropnguoitao.Text;
                CoDinhPhuSon.ngaytao =Convert.ToDateTime(txtngaytao.Text.Trim());
                CoDinhPhuSon.loaiphim = droploaiphim.Text;
                CoDinhPhuSon.tylexmin = txttylexmin.Text.Trim();
                CoDinhPhuSon.tylexmax = txttylexmax.Text.Trim();
                CoDinhPhuSon.tyleymin = txttyleymin.Text.Trim();
                CoDinhPhuSon.tyleymax = txttyleymax.Text.Trim();
                service.UpdateCoDinhTyLePhuSon(CoDinhPhuSon);
                GridView1.DataSourceID = "CoDinhPhuSon";
                GridView1.DataBind();
            }
        }

        protected void txttimkiemsanpham_TextChanged(object sender, EventArgs e)
        {
            var service = new Service();
            GridView1.DataSourceID = null;
            GridView1.DataSource = service.GetCoDinhPhuSonBySanPham(txttimkiemsanpham.Text.Trim());
            GridView1.DataBind();
        }

        protected void SearchByDate_Click(object sender, EventArgs e)
        {
            var service = new Service();
            var result = service.GetCoDinhPhusonByDate(Convert.ToDateTime(TextBox1.Text), Convert.ToDateTime(TextBox2.Text));
            GridView1.DataSourceID = null;
            GridView1.DataSource = result;
            GridView1.DataBind();
        }

        protected void lkEdit_Click(object sender, EventArgs e)
        {
            GridViewRow gvRow = (GridViewRow)((LinkButton)sender).NamingContainer;
            Int32 Idphuson = Convert.ToInt32(GridView1.DataKeys[gvRow.RowIndex].Value);
            hfIdphuson.Value = Idphuson.ToString();
            var service = new Service();
            var result = service.GetCoDinhTyLePhuSonByID(Convert.ToInt32(hfIdphuson.Value));
            var kq = result.First();
            txtsanpham.Text = kq.tensanpham.Trim();
            txtngaytao.Text = kq.ngaytao.ToString().Trim();
            dropnguoitao.Text = kq.nguoitao.Trim();
            droploaiphim.Text = kq.loaiphim.Trim();
            txttylexmin.Text = kq.tylexmin.Trim();
            txttylexmax.Text = kq.tylexmax.Trim();
            txttyleymin.Text = kq.tyleymin.Trim();
            txttyleymax.Text = kq.tyleymax.Trim();
            popup.Show();
        }
 
    }
}