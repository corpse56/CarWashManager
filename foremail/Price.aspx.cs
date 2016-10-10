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
    public partial class Price : System.Web.UI.Page
    {
        SqlDataAdapter DA;
        DataSet DS;

        protected void Page_Load(object sender, EventArgs e)
        {
            DA = new SqlDataAdapter();
            DS = new DataSet();
            DA.SelectCommand = new SqlCommand();
            DA.SelectCommand.Connection = new SqlConnection(@"Data Source=127.0.0.1;Initial Catalog=CWM;Persist Security Info=True;User ID=CWM;Password=manager");
            DA.SelectCommand.CommandText = "with price as " +
                "(select distinct PNAME pn from CWM..PRICELIST) " +
                "select A.pn pn,B.COST c1,C.COST c2,D.COST c3,E.COST c4,F.COST c5 from price A " +
                "left join CWM..PRICELIST B on A.pn = B.PNAME and B.IDCLASS = 1 " +
                "left join CWM..PRICELIST C on A.pn = C.PNAME and C.IDCLASS = 2 " +
                "left join CWM..PRICELIST D on A.pn = D.PNAME and D.IDCLASS = 3 " +
                "left join CWM..PRICELIST E on A.pn = E.PNAME and E.IDCLASS = 4 " +
                "left join CWM..PRICELIST F on A.pn = F.PNAME and F.IDCLASS = 5 order by pn"; ;
            DS = new DataSet();
            DA.Fill(DS, "PRICE");
            TableRow row = new TableRow();
            TableCell cell = new TableCell();
            cell.Text = "Наименование услуги";
            row.Cells.Add(cell);

            cell = new TableCell();
            cell.Text = "Цена 1 Класс";
            row.Cells.Add(cell);

            cell = new TableCell();
            cell.Text = "Цена 2 Класс";
            row.Cells.Add(cell);

            cell = new TableCell();
            cell.Text = "Цена 3 Класс";
            row.Cells.Add(cell);

            cell = new TableCell();
            cell.Text = "Цена 4 Класс";
            row.Cells.Add(cell);

            cell = new TableCell();
            cell.Text = "Цена 5 Класс";
            row.Cells.Add(cell);
            row.BackColor = Color.LightGray;
            tPrice.Rows.Add(row);

            foreach (DataRow r in DS.Tables["PRICE"].Rows)
            {
                row = new TableRow();
                cell = new TableCell();
                cell.Text = r["pn"].ToString();
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = r["c1"].ToString();
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = r["c2"].ToString();
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = r["c3"].ToString();
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = r["c4"].ToString();
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = r["c5"].ToString();
                row.Cells.Add(cell);

                tPrice.Rows.Add(row);
            }
        }
    }
}
