using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HTQuanLyFilm.MA3_1F
{
    public partial class Taomach1f : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SearchByDate_Click(object sender, EventArgs e)
        {

        }

        protected void TxtToExcel_Click(object sender, EventArgs e)
        {

        }

        protected void btnthemmoi_Click(object sender, EventArgs e)
        {
            popup.Show();
        }

        protected void txttimkiemsanpham_TextChanged(object sender, EventArgs e)
        {

        }

        protected void drophientrang_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

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

        protected void btnSave1_Click(object sender, EventArgs e)
        {

        }

        protected void dropcustom2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dropcustom1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}