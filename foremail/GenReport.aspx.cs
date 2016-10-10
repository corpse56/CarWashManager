using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarWashManager
{
    public partial class GenReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            tbStart.Attributes.Add("readonly", "readonly");
            tbEnd.Attributes.Add("readonly", "readonly");
            if (!Page.IsPostBack)
            {
                CalendarExtender1.SelectedDate = DateTime.Today;
                CalendarExtender2.SelectedDate = DateTime.Today;
                tbStart.Text = DateTime.Today.ToString("dd.MM.yyyy");
                tbEnd.Text = DateTime.Today.ToString("dd.MM.yyyy");
            }
            else
            {
                CalendarExtender1.SelectedDate = DateTime.ParseExact(tbStart.Text, CalendarExtender1.Format, null);
                CalendarExtender2.SelectedDate = DateTime.ParseExact(tbEnd.Text, CalendarExtender2.Format, null);
            }
        }

        protected void chbAllTime_CheckedChanged(object sender, EventArgs e)
        {
            if (chbAllTime.Checked)
            {
                tbEnd.Enabled = false;
                tbStart.Enabled = false;
            }
            else
            {
                tbEnd.Enabled = true;
                tbStart.Enabled = true;
            }
        }

        protected void bShow_Click(object sender, EventArgs e)
        {
            if (chbAllTime.Checked) //за все время
            {
                Response.Redirect("GenReportShow.aspx?start=" + tbStart.Text +
                    "&end=" + tbEnd.Text + "&All=1");
            }
            else
            {
                Response.Redirect("GenReportShow.aspx?start=" + tbStart.Text +
                    "&end=" + tbEnd.Text + "&All=0");
            }
        }
    }
}
