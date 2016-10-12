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
    public partial class _Default : System.Web.UI.Page
    {
        RMain r;
        //CrystalReport1 tr;
        SqlDataAdapter DA;
        DataSet DS;
        protected void Page_Load(object sender, EventArgs e)
        {
            DA = new SqlDataAdapter();
            DS = new DataSet();
            DA.SelectCommand = new SqlCommand();
            DA.SelectCommand.Connection = new SqlConnection(@"Data Source=127.0.0.1\SQL2008R2;Initial Catalog=CWM;Persist Security Info=True;User ID=CWM;Password=manager");
            DA.SelectCommand.CommandText = "select * from CWM..JOBVIEW";
            //DA.SelectCommand.CommandText = "select * from CWM..GetTeamReportByDate('20120423','20120423',1)";
            DA.Fill(DS, "J");
            r.SetDataSource(DS.Tables["J"]);
            //tr.SetDataSource(DS.Tables["J"]);
            // r.SetDataSource();
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
            r = new RMain();
            //tr = new CrystalReport1();
        }
    }
}
