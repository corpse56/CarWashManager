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
    public partial class Edit : System.Web.UI.Page
    {
        SqlDataAdapter DA;
        DataSet DS;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                tbDate.Text = DateTime.Today.ToString("dd.MM.yyyy");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DA = new SqlDataAdapter();
            DS = new DataSet();
            DA.SelectCommand = new SqlCommand();
            DA.SelectCommand.Connection = new SqlConnection("Data Source=127.0.0.1;Initial Catalog=CWM;Persist Security Info=True;User ID=CWM;Password=manager");
            DateTime dt = DateTime.Parse(tbDate.Text);
            DA.SelectCommand.Parameters.Add("dt", SqlDbType.DateTime);
            DA.SelectCommand.Parameters["dt"].Value = dt;
            DA.SelectCommand.CommandText = "select * from CWM..EditJob(@dt)";
            int i = DA.Fill(DS, "JE");

            foreach (DataRow r in DS.Tables["JE"].Rows)
            {
                TableRow row = new TableRow();
                TableCell cell = new TableCell();
                LinkButton lbEditJob = new LinkButton();
                lbEditJob.Text = "Редактировать";
                lbEditJob.PostBackUrl = "~/EditJob.aspx?idj="+r["id"].ToString();
                if (r["en"].ToString() != "")
                {
                    cell.Controls.Add(lbEditJob);
                }
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = r["en"].ToString();
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = r["pl"].ToString();
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = r["tim"].ToString();
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = r["serv"].ToString();
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = r["car"].ToString();
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = r["cost"].ToString();

                row.Cells.Add(cell);
                cell = new TableCell();
                row.Cells.Add(cell);
                row.Cells.Add(cell);
                cell = new TableCell();
                row.Cells.Add(cell);

                lbEditJob = new LinkButton();
                lbEditJob.Text = "Редактировать";
                lbEditJob.PostBackUrl = "~/EditJob.aspx?idj=" + r["id2"].ToString();
                if (r["en2"].ToString() != "")
                {
                    cell.Controls.Add(lbEditJob);
                }
                row.Cells.Add(cell);


                cell = new TableCell();
                cell.Text = r["en2"].ToString();
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = r["pl2"].ToString();
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = r["tim2"].ToString();
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = r["serv2"].ToString();
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = r["car2"].ToString();
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = r["cost2"].ToString();
                row.Height = 45;
                row.Cells.Add(cell);

                tEdit.Rows.Add(row);
            }

        }
    }
}
