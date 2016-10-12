using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Globalization;

namespace CarWashManager
{
    public partial class SearchReportShow : System.Web.UI.Page
    {
        RSearch r;
        //CrystalReport1 tr;
        SqlDataAdapter DA;
        DataSet DS;
        string s = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            DA = new SqlDataAdapter();
            DS = new DataSet();
            DA.SelectCommand = new SqlCommand();
            DA.SelectCommand.Connection = new SqlConnection(@"Data Source=127.0.0.1\SQL2008R2;Initial Catalog=CWM;Persist Security Info=True;User ID=CWM;Password=manager");
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from CWM..GetSearch() where (1=1)");
            if (Request["All"] == "0")
            {
                DateTime start = DateTime.Parse(Request["start"], new CultureInfo("ru-RU", false));
                DateTime end = DateTime.Parse(Request["end"], new CultureInfo("ru-RU", false));
                sb.Append(" and (cast(cast(jd as nvarchar(11)) as datetime) >= '" + start.ToString("yyyyMMdd") + "' and cast(cast(jd as nvarchar(11)) as datetime)<='" + end.ToString("yyyyMMdd") + "')");
            }
            string serv = Request["serv"];
            string emp = Request["emp"];
            string line = Request["line"];
            string idc = Request["idc"];
            if (!((serv == null) || (serv == "")))
            {
                sb.Append(" and (pn in (" + Request["serv"] + "))");
            }
            //else
            //{
            //    sb.Append(" and (pn = 'нет фильтра_')");
            //}

            if (!((emp == null) || (emp == "")))
            {
                sb.Append(" and (en in (" + Request["emp"] + "))");
            }
            //else
            //{
            //    sb.Append(" and (en = 'нет фильтра_')");
            //}

            if (!((line == null) || (line == "")))
            {
                sb.Append(" and (ln in (" + Request["line"] + "))");
            }
            //else
            //{
            //    sb.Append(" and (ln = -999)");
            //}

            if (!((idc == null) || (idc == "")))
            {
                sb.Append(" and (idc in (" + Request["idc"] + "))");
            }
            //else
            //{
            //    sb.Append(" and (idc = -999)");
            //}
            //string ddd = Request["serv"];
            DA.SelectCommand.CommandText = sb.ToString();

            //DA.SelectCommand.CommandText = "select * from CWM..GetTeamReportByDate('20120423','20120423',1)";
            int i = DA.Fill(DS, "R");
            //((TextObject)r.Section2.ReportObjects["Text10"]).Text = "Отчет по бригадам с " +start.ToString("dd.MM.yyyy")+" по " +end.ToString("dd.MM.yyyy");

            //((TextObject)r.Section2.ReportObjects["Text6"]).Text = s;
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
            r = new RSearch();

        }
    }
}
