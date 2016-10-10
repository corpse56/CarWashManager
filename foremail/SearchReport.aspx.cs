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
    public partial class SearchReport : System.Web.UI.Page
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
            DA.SelectCommand.Connection = new SqlConnection(@"Data Source=127.0.0.1;Initial Catalog=CWM;Persist Security Info=True;User ID=CWM;Password=manager");

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

                DA.SelectCommand.CommandText = "select  ENAME from CWM..EMPLOYEE where DELETED != 1 or DELETED is null";
                DS = new DataSet();
                DA.Fill(DS, "EMP");
                chblEmp.DataSource = DS.Tables["EMP"];
                chblEmp.DataTextField = "ENAME";
                chblEmp.DataValueField = "ENAME";
                chblEmp.DataBind();
                chblEmp.RepeatColumns = 3;

                DA.SelectCommand.CommandText = "select ID from CWM..CARCLASS";
                DS = new DataSet();
                DA.Fill(DS, "CLASS");
                chblClass.DataSource = DS.Tables["CLASS"];
                chblClass.DataTextField = "ID";
                chblClass.DataValueField = "ID";
                chblClass.DataBind();
                chblClass.RepeatColumns = 5;

                DA.SelectCommand.CommandText = "select ID from CWM..LINE";
                DS = new DataSet();
                DA.Fill(DS, "LINE");
                chblLine.DataSource = DS.Tables["LINE"];
                chblLine.DataTextField = "ID";
                chblLine.DataValueField = "ID";
                chblLine.DataBind();
                chblLine.RepeatColumns = 3;
            }
            else
            {
                CalendarExtender1.SelectedDate = DateTime.ParseExact(tbStart.Text, CalendarExtender1.Format, null);
                CalendarExtender2.SelectedDate = DateTime.ParseExact(tbEnd.Text, CalendarExtender2.Format, null);
            }
        }
        protected void bSelectAllServ_Click(object sender, EventArgs e)
        {
            foreach (ListItem c in chblServ.Items)
            {
                c.Selected = true;
            }

        }
        protected void bDeSelectAllServ_Click(object sender, EventArgs e)
        {
            foreach (ListItem c in chblServ.Items)
            {
                c.Selected = false;
            }
        }
        protected void bSelectAllEmp_Click(object sender, EventArgs e)
        {
            foreach (ListItem c in chblEmp.Items)
            {
                c.Selected = true;
            }

        }
        protected void bDeSelectAllEmp_Click(object sender, EventArgs e)
        {
            foreach (ListItem c in chblEmp.Items)
            {
                c.Selected = false;
            }

        }

        protected void bShow_Click(object sender, EventArgs e)
        {
            string serv = "";
            foreach (ListItem c in chblServ.Items)
            {
                if (c.Selected)
                {
                    serv += "'" + c.Text + "'" + ",";
                }
            }
            if (serv != "")
                serv = serv.Substring(0, serv.Length - 1);
            string emp = "";
            foreach (ListItem c in chblEmp.Items)
            {
                if (c.Selected)
                {
                    emp += "'" + c.Text + "'" + ",";
                }
            }
            if (emp != "")
                emp = emp.Substring(0, emp.Length - 1);
            string idc = "";
            foreach (ListItem c in chblClass.Items)
            {
                if (c.Selected)
                {
                    idc += c.Value +",";
                }
            }
            if (idc != "")
                idc = idc.Substring(0, idc.Length - 1);
            string line = "";
            foreach (ListItem c in chblLine.Items)
            {
                if (c.Selected)
                {
                    line += c.Value +",";
                }
            }
            if (line != "")
                line = line.Substring(0, line.Length - 1);
            string alltime = "0";

            if (chbAllTime.Checked) //за все время
            {
                alltime = "1";
            }
            else
            {
                alltime = "0";
            }
            Response.Redirect("SearchReportShow.aspx?start=" + tbStart.Text +
                "&end=" + tbEnd.Text +
                "&serv=" + serv + "&All="+alltime+
                "&emp="+emp+"&idc="+idc+"&line="+line);
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
