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
    public partial class CanceledServices : System.Web.UI.Page
    {
        SqlDataAdapter DA;
        DataSet DS;

        protected void Page_Load(object sender, EventArgs e)
        {
            DA = new SqlDataAdapter();
            DS = new DataSet();
            DA.SelectCommand = new SqlCommand();
            DA.SelectCommand.Connection = new SqlConnection(@"Data Source=127.0.0.1;Initial Catalog=CWM;Persist Security Info=True;User ID=CWM;Password=manager");
            DA.SelectCommand.CommandText = "select top 1000 A.ID idp,B.ID id,B.JOBDATE jdate,C.ENAME emp,E.CNAME car,D.PNAME price,B.LINE line, B.IDCLASS idc," +
                    " B.NPLATE plate, A.COST cst" +
                    " from CWM..PACKAGE A" +
                    " left join CWM..JOB B on A.IDJOB = B.ID" +
                    "  left join CWM..EMPLOYEE C on C.ID = B.IDEMP" +
                    " left join CWM..PRICELIST D on A.IDPRICE = D.ID" +
                    " left join CWM..CAR E on B.IDCAR = E.ID" +
                    "  where A.DELETED = 1 order by B.JOBDATE desc";
            DS = new DataSet();
            DA.Fill(DS, "canc");

            GridView1.DataSource = DS.Tables["canc"];
            ((BoundField)GridView1.Columns[0]).DataField = "id";
            ((BoundField)GridView1.Columns[1]).DataField = "jdate";
            ((BoundField)GridView1.Columns[2]).DataField = "emp";
            ((BoundField)GridView1.Columns[3]).DataField = "car";
            ((BoundField)GridView1.Columns[4]).DataField = "price";
            ((BoundField)GridView1.Columns[5]).DataField = "line";
            ((BoundField)GridView1.Columns[6]).DataField = "idc";
            ((BoundField)GridView1.Columns[7]).DataField = "plate";
            ((BoundField)GridView1.Columns[8]).DataField = "cst";
            GridView1.DataBind();

        }
    }
}
