using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CWMAdmin
{
    public partial class Price : Form
    {
        SqlDataAdapter DA;
        DataSet DS;

        public Price()
        {
            InitializeComponent();
        }

        private void Price_Load(object sender, EventArgs e)
        {
            DA = new SqlDataAdapter();
            DS = new DataSet();
            DA.SelectCommand = new SqlCommand();
            DA.SelectCommand.Connection = new SqlConnection(@"Data Source=127.0.0.1;Initial Catalog=CWM;Persist Security Info=True;User ID=CWM;Password=manager");
            DA.SelectCommand.CommandText = "with price as " +
                "(select distinct PNAME pn from CWM..PRICELIST) "+
                "select A.pn pn,B.COST c1,C.COST c2,D.COST c3,E.COST c4,F.COST c5 from price A "+
                "left join CWM..PRICELIST B on A.pn = B.PNAME and B.IDCLASS = 1 "+
                "left join CWM..PRICELIST C on A.pn = C.PNAME and C.IDCLASS = 2 "+
                "left join CWM..PRICELIST D on A.pn = D.PNAME and D.IDCLASS = 3 "+
                "left join CWM..PRICELIST E on A.pn = E.PNAME and E.IDCLASS = 4 "+
                "left join CWM..PRICELIST F on A.pn = F.PNAME and F.IDCLASS = 5 order by pn";
            int i = DA.Fill(DS, "R");
            dwgPrice.DataSource = DS.Tables["R"];

            dwgPrice.Columns["pn"].Width = 250;
            dwgPrice.Columns["pn"].HeaderText = "Наименование";
            dwgPrice.Columns["c1"].Width = 100;
            dwgPrice.Columns["c1"].HeaderText = "Цена Класс 1";
            dwgPrice.Columns["c2"].Width = 100;
            dwgPrice.Columns["c2"].HeaderText = "Цена Класс 2";
            dwgPrice.Columns["c3"].Width = 100;
            dwgPrice.Columns["c3"].HeaderText = "Цена Класс 3";
            dwgPrice.Columns["c4"].Width = 100;
            dwgPrice.Columns["c4"].HeaderText = "Цена Класс 4";
            dwgPrice.Columns["c5"].Width = 100;
            dwgPrice.Columns["c5"].HeaderText = "Цена Класс 5";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddPrice ap = new AddPrice();
            ap.ShowDialog();
            Price_Load(this, new EventArgs());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EditPrice ep = new EditPrice(dwgPrice.SelectedRows[0].Cells["pn"].Value.ToString());
            ep.ShowDialog();
            Price_Load(this, new EventArgs());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Вы уверены, что хотите удалить выбранную позицию?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No)
            {
                return;
            }
            DA = new SqlDataAdapter();
            DS = new DataSet();
            DA.DeleteCommand = new SqlCommand();
            DA.DeleteCommand.Connection = new SqlConnection(@"Data Source=127.0.0.1;Initial Catalog=CWM;Persist Security Info=True;User ID=CWM;Password=manager");
            DA.DeleteCommand.Parameters.Add("P", SqlDbType.VarChar);
            DA.DeleteCommand.Parameters["P"].Value = dwgPrice.SelectedRows[0].Cells["pn"].Value.ToString();
            DA.DeleteCommand.CommandText = "delete from CWM..PRICELIST where PNAME = @P";
            DA.DeleteCommand.Connection.Open();
            DA.DeleteCommand.ExecuteNonQuery();
            DA.DeleteCommand.Connection.Close();
            Price_Load(this, new EventArgs());
            MessageBox.Show("Позиция успешно удалена!");
        }
    }
}
