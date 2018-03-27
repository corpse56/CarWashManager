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
    public partial class CarsReport : System.Web.UI.Page
    {
        SqlDataAdapter DA;
        DataSet DS;
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
            DA = new SqlDataAdapter();
            DS = new DataSet();
            DA.SelectCommand = new SqlCommand();
            DA.SelectCommand.Connection = new SqlConnection("Data Source=127.0.0.1;Initial Catalog=CWM;Persist Security Info=True;User ID=CWM;Password=manager");
            DA.SelectCommand.Parameters.Add("dt1", SqlDbType.DateTime).Value = DateTime.Parse(tbStart.Text);
            DA.SelectCommand.Parameters.Add("dt2", SqlDbType.DateTime).Value = DateTime.Parse(tbEnd.Text);
            DA.SelectCommand.CommandText = "select * from CWM..CarsReport(@dt1,@dt2)";
            int i = DA.Fill(DS, "CarsReport");

            GridView1.DataSource = DS.Tables["CarsReport"];
            ((BoundField)GridView1.Columns[0]).DataField = "num";
            //((BoundField)GridView1.Columns[0]).
            ((BoundField)GridView1.Columns[1]).DataField = "CAR";
            ((BoundField)GridView1.Columns[2]).DataField = "PLATE";
            ((BoundField)GridView1.Columns[3]).DataField = "T";
            ((BoundField)GridView1.Columns[4]).DataField = "EMP";
            ((BoundField)GridView1.Columns[5]).DataField = "Jservices";
//            ((BoundField)GridView1.Columns[5]).DataFormatString = "{0:dd.MM.yyyy HH:mm}";
            ((BoundField)GridView1.Columns[6]).DataField = "COST";

            GridView1.DataBind();

        }
    }
}
