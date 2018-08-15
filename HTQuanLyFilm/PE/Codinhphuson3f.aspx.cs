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
    public partial class Codinhphuson3f : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (IsPostBack)
            //    GetData();
            //var service = new Service();
            //var result = service.GetCoDinhTyLePhuSonByID(5);
            //var user = result.First();
            //LBtest.Text = user.tensanpham; 
          
        }
        //protected void GridView1_DataBound(object sender, EventArgs e)
        //{
        //    //GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
        //    //for (int i = 0; i < GridView1.Columns.Count; i++)
        //    //{
        //    //    TableHeaderCell cell = new TableHeaderCell();
        //    //    TextBox txtSearch = new TextBox();
        //    //    txtSearch.Attributes["placeholder"] = GridView1.Columns[i].HeaderText;
        //    //    txtSearch.CssClass = "search_textbox";
        //    //    cell.Controls.Add(txtSearch);
        //    //    row.Controls.Add(cell);
        //    //}
        //    //GridView1.HeaderRow.Parent.Controls.AddAt(1, row);
        //}   
        private void DeleteRecord(int idphuson)
        {
            var service = new Service();
            var CoDinhPhuSon = new BusinessObjects.CoDinhTyLePhuSonBUS();
            CoDinhPhuSon.idphuson=idphuson;
            service.DeleteCoDinhTyLePhuSon(CoDinhPhuSon);
        }

     
        private void ShowMessage(int count)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("alert('");
            sb.Append(count.ToString());
            sb.Append(" records deleted.');");
            sb.Append("</script>");
            ClientScript.RegisterStartupScript(this.GetType(),"script", sb.ToString());
        }
        private void SetData()
        {
            int currentCount = 0;
            CheckBox chkAll = (CheckBox)GridView2.HeaderRow.Cells[0].FindControl("CheckAll");

            chkAll.Checked = true;
            ArrayList arr = (ArrayList)ViewState["SelectedRecords"];
            for (int i = 0; i < GridView2.Rows.Count; i++)
            {
                CheckBox chk = (CheckBox)GridView2.Rows[i].Cells[0].FindControl("chk");
                if (chk != null)
                {
                    chk.Checked = arr.Contains(GridView2.DataKeys[i].Value);
                    if (!chk.Checked)
                        chkAll.Checked = false;
                    else
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

            for (int i = 0; i < GridView2.Rows.Count; i++)
            {
                CheckBox chkAll = (CheckBox)GridView2.HeaderRow.Cells[0].FindControl("CheckAll");
                if (chkAll.Checked)
                {
                    if (!arr.Contains(GridView2.DataKeys[i].Value))
                    {
                        arr.Add(GridView2.DataKeys[i].Value);
                    }
                }
                else
                {
                    CheckBox chk = (CheckBox)GridView2.Rows[i].Cells[0].FindControl("chk");
                    if (chk.Checked)
                    {
                        if (!arr.Contains(GridView2.DataKeys[i].Value))
                        {
                            arr.Add(GridView2.DataKeys[i].Value);
                        }
                    }
                    else
                    {
                        if (arr.Contains(GridView2.DataKeys[i].Value))
                        {
                            arr.Remove(GridView2.DataKeys[i].Value);
                        }
                    }
                }
            }
            ViewState["SelectedRecords"] = arr;
        }

        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
               GridView2.PageIndex = e.NewPageIndex;
               GridView2.DataBind();
               SetData();
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            int count = 0;
            SetData();
            GridView2.DataBind();
            ArrayList arr = (ArrayList)ViewState["SelectedRecords"];
            count = arr.Count;
            for (int i = 0; i < GridView2.Rows.Count; i++)
            {
                if (arr.Contains(GridView2.DataKeys[i].Value))
                {
                    DeleteRecord(Convert.ToInt32(GridView2.DataKeys[i].Value.ToString()));
                    arr.Remove(GridView2.DataKeys[i].Value);
                }
            }
            ViewState["SelectedRecords"] = arr;
            hfCount.Value = "0";
            GridView2.DataSourceID = "CoDinhTyLePhuSon";
            GridView2.DataBind();
            ShowMessage(count);
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
          
        
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            txtngaytao.Text = string.Empty;
            dropnguoitao.Text = string.Empty;
            txtsanpham.Text = string.Empty;
            droploaiphim.Text = string.Empty;
            txttylexmin.Text = string.Empty;
            txttylexmax.Text = string.Empty;
            txttyleymin.Text = string.Empty;
            txttyleymax.Text = string.Empty;
            ModalPopupExtender1.Show();
            //popup.Show();
        }

        protected void btnSave_Click(object sender, EventArgs e)
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
            GridView2.DataSourceID = "CoDinhTyLePhuSon";
            GridView2.DataBind();
            
        }

        protected void LinkButton1_Click1(object sender, EventArgs e)
        {
            ModalPopupExtender1.Show();
        }

     
        //protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //       if (e.CommandName == "update")
        //       {
        //           var service = new Service();
        //           var CoDinhPhuSon = new BusinessObjects.CoDinhTyLePhuSonBUS();
        //           var result = service.GetCoDinhTyLePhuSonByID(Convert.ToInt32(e.CommandArgument.ToString()));
        //               var kq = result.First();
        //               txtsanpham.Text = kq.tensanpham;
        //               txtngaytao.Text = kq.ngaytao.ToString();
        //               dropnguoitao.Text = kq.nguoitao;
        //               droploaiphim.Text = kq.loaiphim;
        //               txttylexmin.Text = kq.tylexmin;
        //               txttylexmax.Text = kq.tylexmax;
        //               txttyleymin.Text = kq.tyleymin;
        //               txttyleymax.Text = kq.tyleymax;
        //               TextBox1SanPham.Text = kq.tensanpham;
        //               hdinsert.Value = "update";
        //               hdidphuson.Value =e.CommandArgument.ToString();
        //       }
        //}

        //protected void Button4_Click(object sender, EventArgs e)
        //{
        //    hdinsert.Value = "insert";
          
        //}

    }
}