using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;

namespace CarWashManager
{
    public partial class GenReportShow : System.Web.UI.Page
    {
        RGeneral r;
        //CrystalReport1 tr;
        SqlDataAdapter DA;
        DataSet DS;
        string s = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            DA = new SqlDataAdapter();
            DS = new DataSet();
            DA.SelectCommand = new SqlCommand();
            DA.SelectCommand.Connection = new SqlConnection(@"Data Source=127.0.0.1;Initial Catalog=CWM;Persist Security Info=True;User ID=CWM;Password=manager");
            DA.SelectCommand.Parameters.Add("start", SqlDbType.DateTime);
            DA.SelectCommand.Parameters.Add("end", SqlDbType.DateTime);
            DateTime start = DateTime.Parse(Request["start"],new CultureInfo("ru-RU",false));
            DateTime end = DateTime.Parse(Request["end"], new CultureInfo("ru-RU", false));

            DA.SelectCommand.Parameters["start"].Value = start;
            DA.SelectCommand.Parameters["end"].Value = end;
            if (Request["All"] == "0")
            {
                DA.SelectCommand.CommandText = "select * from CWM..GetGeneralReportByDate(@start,@end) order by dt";
            }
            else
            {
                DA.SelectCommand.CommandText = "select * from CWM..GetGeneralReportAllTime() order by dt";
            }
            int i = DA.Fill(DS, "R");

            ((TextObject)r.Section2.ReportObjects["Text3"]).Text = s;
            r.SetDataSource(DS.Tables["R"]);
            RepViewer.ReportSource = r;
            //RepViewer.Zoom(100);
            //RepViewer.BestFitPage = false;
            //UnitType t = RepViewer.Width.Type;
            //RepViewer.Width = 800;

        }
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
            //InitializeComponent();
            base.OnInit(e);
            if (Request["All"] == "0")
            {
                s = "Общий отчет всего предприятия с " + Request["start"] + " по " + Request["end"];
            }
            else
            {
                s = "Общий отчет всего предприятия за все время";
            }
            r = new RGeneral();

        }
    }
}
