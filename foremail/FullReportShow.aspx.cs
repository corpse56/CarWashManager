using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;

namespace CarWashManager
{
    public partial class FullReportShow : System.Web.UI.Page
    {
        SqlDataAdapter DA;
        DataSet DS;

        protected void Page_Load(object sender, EventArgs e)
        {
            DA = new SqlDataAdapter();
            DS = new DataSet();
            DA.SelectCommand = new SqlCommand();
            DA.SelectCommand.Connection = new SqlConnection(@"Data Source=127.0.0.1\SQL2008R2;Initial Catalog=CWM;Persist Security Info=True;User ID=CWM;Password=manager");
            DA.SelectCommand.Parameters.Add("start", SqlDbType.DateTime);
            DA.SelectCommand.Parameters.Add("end", SqlDbType.DateTime);
            DateTime start = DateTime.Parse(Request["start"], new CultureInfo("ru-RU", false));
            DateTime end = DateTime.Parse(Request["end"], new CultureInfo("ru-RU", false));
            string se = Request["serv"];
            DA.SelectCommand.Parameters["start"].Value = start;
            DA.SelectCommand.Parameters["end"].Value = end;
            DA.SelectCommand.CommandText = "select * from CWM..[GetFullReportByDate](@start,@end)";
            DS = new DataSet();
            DA.Fill(DS, "canc");

            Label1.Text = "Полный отчёт с " + start.ToString("dd.MM.yy") + " по " + end.ToString("dd.MM.yy");
            GridView1.DataSource = DS.Tables["canc"];
            ((BoundField)GridView1.Columns[0]).DataField = "EMP";
            ((BoundField)GridView1.Columns[1]).DataField = "PLATE";
            ((BoundField)GridView1.Columns[2]).DataField = "T";
            ((BoundField)GridView1.Columns[3]).DataField = "PS";
            ((BoundField)GridView1.Columns[4]).DataField = "CAR";
            ((BoundField)GridView1.Columns[5]).DataField = "COST";
            //((BoundField)GridView1.Columns[6]).DataField = "EMP2";
            ((BoundField)GridView1.Columns[7]).DataField = "PLATE2";
            ((BoundField)GridView1.Columns[8]).DataField = "T2";
            ((BoundField)GridView1.Columns[9]).DataField = "PS2";
            ((BoundField)GridView1.Columns[10]).DataField = "CAR2";
            ((BoundField)GridView1.Columns[11]).DataField = "COST2";
            GridView1.DataBind();
            Label2.Text = "Итого: " + sum.ToString();
        }
        int sum = 0;
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex == -1) return;
            int c1=0, c2=0;

            int.TryParse(e.Row.Cells[5].Text, out c1);
                //c1 = 0;
            int.TryParse(e.Row.Cells[11].Text, out c2);
                //c2 = 0;
            sum += c1 + c2;
            
        }
    }
}
