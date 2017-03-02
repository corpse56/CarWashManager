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
    public partial class RemovedJobs : System.Web.UI.Page
    {
        SqlDataAdapter DA;
        DataSet DS;

        protected void Page_Load(object sender, EventArgs e)
        {
            DA = new SqlDataAdapter();
            DS = new DataSet();
            DA.SelectCommand = new SqlCommand();
            DA.SelectCommand.Connection = new SqlConnection("Data Source=127.0.0.1;Initial Catalog=CWM;Persist Security Info=True;User ID=CWM;Password=manager");
            DA.SelectCommand.CommandText = "select top 1000 A.IDORIGINALJOB id,A.JOBDATE jdate,C.ENAME emp,E.CNAME car,A.LINE line, A.IDCLASS idc," +
                    " A.NPLATE plate, A.TOTALCOST cst, A.DATEDELETED deldate" +
                    " from CWM..REMOVEDJOB A" +
                    "  left join CWM..EMPLOYEE C on C.ID = A.IDEMP" +
                    " left join CWM..CAR E on A.IDCAR = E.ID" +
                    "  order by A.DATEDELETED desc";
            DS = new DataSet();
            DA.Fill(DS, "canc");
            
            GridView1.DataSource = DS.Tables["canc"];
            ((BoundField)GridView1.Columns[0]).DataField = "id";
            ((BoundField)GridView1.Columns[1]).DataField = "jdate";
            ((BoundField)GridView1.Columns[2]).DataField = "emp";
            ((BoundField)GridView1.Columns[3]).DataField = "car";
            ((BoundField)GridView1.Columns[4]).DataField = "line";
            ((BoundField)GridView1.Columns[5]).DataField = "idc";
            ((BoundField)GridView1.Columns[6]).DataField = "plate";
            ((BoundField)GridView1.Columns[7]).DataField = "cst";
            ((BoundField)GridView1.Columns[8]).DataField = "deldate";
            GridView1.DataBind();
                //<asp:BoundField HeaderText="Номер работы" />
                //<asp:BoundField HeaderText="Дата" />
                //<asp:BoundField HeaderText="Сотрудник" />
                //<asp:BoundField HeaderText="Автомобиль" />
                //<asp:BoundField HeaderText="Линия" />
                //<asp:BoundField HeaderText="Класс" />
                //<asp:BoundField HeaderText="Гос. номер" />
                //<asp:BoundField HeaderText="Стоимость" />
                //<asp:BoundField HeaderText="Дата удаления работы" />
        }
    }
}
