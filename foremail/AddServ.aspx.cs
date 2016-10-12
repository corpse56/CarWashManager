using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;

namespace CarWashManager
{
    public partial class AddServ : System.Web.UI.Page
    {
        SqlDataAdapter DA;
        DataSet DS;

        protected void Page_Load(object sender, EventArgs e)
        {
            DA = new SqlDataAdapter();
            DS = new DataSet();
            DA.SelectCommand = new SqlCommand();
            DA.SelectCommand.Connection = new SqlConnection(@"Data Source=127.0.0.1\SQL2008R2;Initial Catalog=CWM;Persist Security Info=True;User ID=CWM;Password=manager");
            DA.SelectCommand.CommandText = "select * from ADDITIONALSERVICE"; 
            DS = new DataSet();
            DA.Fill(DS, "ADDSERV");
            TableRow row = new TableRow();
            TableCell cell = new TableCell();
            cell.Text = "Наименование услуги";
            row.Cells.Add(cell);

            cell = new TableCell();
            cell.Text = "Цена";
            row.Cells.Add(cell);

            row.BackColor = Color.LightGray;
            tPrice.Rows.Add(row);

            foreach (DataRow r in DS.Tables["ADDSERV"].Rows)
            {
                row = new TableRow();
                cell = new TableCell();
                cell.Text = r["ASNAME"].ToString();
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = r["COST"].ToString();
                row.Cells.Add(cell);

                tPrice.Rows.Add(row);
            }
        }
    }
}
