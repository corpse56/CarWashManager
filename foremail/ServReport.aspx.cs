using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace CarWashManager
{
    public partial class ServReport : System.Web.UI.Page
    {
        SqlDataAdapter DA;
        DataSet DS;
        string EnCon = @"metadata=res://*/CWMModel.csdl|res://*/CWMModel.ssdl|res://*/CWMModel.msl;provider=System.Data.SqlClient;provider connection string=""Data Source=127.0.0.1;Initial Catalog=CWM;Persist Security Info=True;User ID=CWM;Password=manager""";
        protected void Page_Load(object sender, EventArgs e)
        {
            //ToolkitScriptManager1.RegisterAsyncPostBackControl(bShow);
            tbStart.Attributes.Add("readonly", "readonly");
            tbEnd.Attributes.Add("readonly", "readonly");
            DA = new SqlDataAdapter();
            DS = new DataSet();
            DA.SelectCommand = new SqlCommand();
            DA.SelectCommand.Connection = new SqlConnection("Data Source=127.0.0.1;Initial Catalog=CWM;Persist Security Info=True;User ID=CWM;Password=manager");

            if (!Page.IsPostBack)
            {
                CalendarExtender1.SelectedDate = DateTime.Today;
                CalendarExtender2.SelectedDate = DateTime.Today;
                tbStart.Text = DateTime.Today.ToString("dd.MM.yyyy");
                tbEnd.Text = DateTime.Today.ToString("dd.MM.yyyy");
                DA.SelectCommand.CommandText = "select distinct PNAME from CWM..PRICELIST";
                DS = new DataSet();
                DA.Fill(DS, "SERV");
                chblServ.DataSource = DS.Tables["SERV"];
                chblServ.DataTextField = "PNAME";
                chblServ.DataValueField = "PNAME";
                chblServ.DataBind();
                chblServ.RepeatColumns = 3;
            }
            else
            {
                CalendarExtender1.SelectedDate = DateTime.ParseExact(tbStart.Text, CalendarExtender1.Format, null);
                CalendarExtender2.SelectedDate = DateTime.ParseExact(tbEnd.Text, CalendarExtender2.Format, null);
            }
        }

        protected void bSelectAll_Click(object sender, EventArgs e)
        {
            foreach (ListItem c in chblServ.Items)
            {
                c.Selected = true;
            }

        }

        protected void bDeSelectAll_Click(object sender, EventArgs e)
        {
            foreach (ListItem c in chblServ.Items)
            {
                c.Selected = false;
            }

        }

        protected void bShow_Click(object sender, EventArgs e)
        {
            bool isempselected = false;
            foreach (ListItem c in chblServ.Items)
            {
                if (c.Selected)
                {
                    isempselected = true;
                    break;
                }
            }
            if (!isempselected)
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, GetType(), "unluck",
                        @"alert('Выберите хотя бы одноу услугу!');", true);
                return;
            }
            string serv = "";
            foreach (ListItem c in chblServ.Items)
            {
                if (c.Selected)
                {
                    serv += "'"+c.Value+"'" + ",";
                }
            }
            serv = serv.Substring(0, serv.Length - 1);
            if (chbAllTime.Checked) //за все время
            {
                Response.Redirect("ServReportShow.aspx?start=" + tbStart.Text +
                    "&end=" + tbEnd.Text +
                    "&serv=" + serv + "&All=1");
            }
            else
            {
                Response.Redirect("ServReportShow.aspx?start=" + tbStart.Text +
                    "&end=" + tbEnd.Text +
                    "&serv=" + serv + "&All=0");
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
    }
}
