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
    public partial class TeamReport : System.Web.UI.Page
    {
        SqlDataAdapter DA;
        DataSet DS;
        string EnCon = @"metadata=res://*/CWMModel.csdl|res://*/CWMModel.ssdl|res://*/CWMModel.msl;provider=System.Data.SqlClient;provider connection string=""Data Source=127.0.0.1;Initial Catalog=CWM;Persist Security Info=True;User ID=CWM;Password=manager""";
        protected void Page_Load(object sender, EventArgs e)
        {
            ToolkitScriptManager1.RegisterAsyncPostBackControl(bShow);
            tbStart.Attributes.Add("readonly", "readonly");
            tbEnd.Attributes.Add("readonly", "readonly");
            DA = new SqlDataAdapter();
            DS = new DataSet();
            DA.SelectCommand = new SqlCommand();
            DA.SelectCommand.Connection = new SqlConnection(@"Data Source=127.0.0.1\SQL2008R2;Initial Catalog=CWM;Persist Security Info=True;User ID=CWM;Password=manager");

            if (!Page.IsPostBack)
            {
                CalendarExtender1.SelectedDate = DateTime.Today;
                CalendarExtender2.SelectedDate = DateTime.Today;
                tbStart.Text = DateTime.Today.ToString("dd.MM.yyyy");
                tbEnd.Text = DateTime.Today.ToString("dd.MM.yyyy");
                DA.SelectCommand.CommandText = "select ID, ENAME  from CWM..EMPLOYEE where DELETED is null or DELETED = 0";
                DS = new DataSet();
                DA.Fill(DS, "EMP");
                chblEmp.DataSource = DS.Tables["EMP"];
                chblEmp.DataTextField = "ENAME";
                chblEmp.DataValueField = "ID";
                chblEmp.DataBind();
                chblEmp.RepeatColumns = 3;
            }
            else
            {
                DateTime tmp;
                //if ((!DateTime.TryParse(tbStart.Text, out tmp)) || (!DateTime.TryParse(tbEnd.Text, out tmp)))
                {
                    CalendarExtender1.SelectedDate = DateTime.ParseExact(tbStart.Text, CalendarExtender1.Format, null);
                    CalendarExtender2.SelectedDate = DateTime.ParseExact(tbEnd.Text, CalendarExtender2.Format, null);
                }
            }
        }

        protected void bSelectAll_Click(object sender, EventArgs e)
        {
            foreach (ListItem c in chblEmp.Items)
            {
                c.Selected = true;
            }

        }

        protected void bDeSelectAll_Click(object sender, EventArgs e)
        {
            foreach (ListItem c in chblEmp.Items)
            {
                c.Selected = false;
            }

        }

        protected void bShow_Click(object sender, EventArgs e)
        {
            bool isempselected = false;
            foreach (ListItem c in chblEmp.Items)
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
                        @"alert('Выберите хотя бы одного сотрудника!');", true);
                return;
            }
            if ((!chbAllTime.Checked) && ((CalendarExtender1.SelectedDate == null) || (CalendarExtender2.SelectedDate == null)))
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, GetType(), "unluck",
                    @"alert('Выберите правильный диапозон дат!');", true);
                return;
            }
            DateTime tmp;
            if ((!DateTime.TryParse(tbStart.Text, out tmp)) || (!DateTime.TryParse(tbEnd.Text, out tmp)))
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, GetType(), "unluck",
                    @"alert('Ошибка при вводе даты!');", true);
                return;
            }
            string emp = "";
            foreach (ListItem c in chblEmp.Items)
            {
                if (c.Selected)
                {
                    emp += c.Value + ",";
                }
            }
            emp = emp.Substring(0, emp.Length - 1);
            if (chbAllTime.Checked) //за все время
            {
                if (chbShortReport.Checked)
                {
                    Response.Redirect("TeamReportShowShort.aspx?start=" + tbStart.Text +
                        "&end=" + tbEnd.Text + "&All=1&emp=" + emp);
                }
                else
                {
                    Response.Redirect("TeamReportShow.aspx?start=" + tbStart.Text +
                        "&end=" + tbEnd.Text +
                        "&emp=" + emp + "&All=1");
                }

            }
            else
            {
                if (chbShortReport.Checked)
                {
                    Response.Redirect("TeamReportShowShort.aspx?start=" + tbStart.Text +
                        "&end=" + tbEnd.Text + "&All=0&emp=" + emp);
                }
                else
                {
                    Response.Redirect("TeamReportShow.aspx?start=" + tbStart.Text +
                        "&end=" + tbEnd.Text +
                        "&emp=" + emp + "&All=0");
                }
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
