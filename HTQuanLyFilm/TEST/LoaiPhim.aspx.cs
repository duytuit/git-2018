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

namespace HTQuanLyFilm.TEST
{
    public partial class LoaiPhim : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                GetData();
        }

        protected void btnthemmoi_Click(object sender, EventArgs e)
        {
            ClearPopupControls();
            hfIdloaiphim.Value = "insert";
            lblHeader.Text = "Add Insert";
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
            GridView1.DataSourceID = "dsloaiphim";
            GridView1.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (hfIdloaiphim.Value == "insert")
            {
                if (!string.IsNullOrEmpty(txtloaiphim.Text))
                {
                    var service = new Service();
                    var LoaiPhim = new BusinessObjects.LoaiPhimBUS();
                    LoaiPhim.loaiphim = txtloaiphim.Text.Trim();
                    service.InsertLoaiPhim(LoaiPhim);
                    GridView1.DataSourceID = "dsloaiphim";
                    GridView1.DataBind();
                }
                else
                {
                    lbmassge.Text = "không để trống loại phim";
                     popup.Show();
                }

            }
            else
            {
                var service = new Service();
                var LoaiPhim = new BusinessObjects.LoaiPhimBUS();
                LoaiPhim.idloaiphim = Convert.ToInt32(hfIdloaiphim.Value);
                LoaiPhim.loaiphim = txtloaiphim.Text.Trim();
                service.UpdateLoaiPhim(LoaiPhim);
                GridView1.DataSourceID = "dsloaiphim";
                GridView1.DataBind();
            }
        }

        protected void lkEdit_Click(object sender, EventArgs e)
        {
            lblHeader.Text = "Add Edit";
            GridViewRow gvRow = (GridViewRow)((LinkButton)sender).NamingContainer;
            Int32 Idloaiphim = Convert.ToInt32(GridView1.DataKeys[gvRow.RowIndex].Value);
            hfIdloaiphim.Value = Idloaiphim.ToString();
            var service = new Service();
            var result = service.GetLoaiPhimById(Convert.ToInt32(hfIdloaiphim.Value));
            var kq = result.First();
            txtloaiphim.Text = kq.loaiphim;
            popup.Show();
        }
        private void DeleteRecord(int idloaiphim)
        {
            var service = new Service();
            var LoaiPhim = new BusinessObjects.LoaiPhimBUS();
            LoaiPhim.idloaiphim = idloaiphim;
            service.DeleteLoaiPhim(LoaiPhim);
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
            }
            ViewState["SelectedRecords"] = arr;
        }
        #region[Clear Modal Popup controls]
        private void ClearPopupControls()
        {
            txtloaiphim.Text = "";
        }
        #endregion
    }
}