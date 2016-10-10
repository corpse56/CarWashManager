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
    public partial class fADDSERV : Form
    {
        SqlDataAdapter DA;
        DataSet DS;
        public fADDSERV()
        {
            InitializeComponent();
        }

        private void fADDSERV_Load(object sender, EventArgs e)
        {
            DA = new SqlDataAdapter();
            DS = new DataSet();
            DA.SelectCommand = new SqlCommand();
            DA.SelectCommand.Connection = new SqlConnection(@"Data Source=127.0.0.1;Initial Catalog=CWM;Persist Security Info=True;User ID=CWM;Password=manager");
            DA.SelectCommand.CommandText = "Select ID,ASNAME,COST from CWM..ADDITIONALSERVICE order by 1";
            int i = DA.Fill(DS, "R");
            dwgEmp.DataSource = DS.Tables["R"];

            dwgEmp.Columns["ID"].Visible = false;
            dwgEmp.Columns["ASNAME"].Width = 300;
            dwgEmp.Columns["ASNAME"].HeaderText = "Наименование";
            dwgEmp.Columns["COST"].Width = 100;
            dwgEmp.Columns["COST"].HeaderText = "Цена";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fAddAS f = new fAddAS();
            f.ShowDialog();
            fADDSERV_Load(sender, e);
            MessageBox.Show("Дополнительная услуга успешно добавлена!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fEditAS feas = new fEditAS((int)dwgEmp.SelectedRows[0].Cells["ID"].Value);
            feas.ShowDialog();
            fADDSERV_Load(sender, e);
            MessageBox.Show("Дополнительная услуга успешно изменена!");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Вы уверены, что хотите удалить выбранную услугу?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No)
            {
                return;
            }
            DA.DeleteCommand = new SqlCommand();
            DA.DeleteCommand.Connection = new SqlConnection(@"Data Source=127.0.0.1;Initial Catalog=CWM;Persist Security Info=True;User ID=CWM;Password=manager");
            DA.DeleteCommand.CommandText = "delete from CWM..ADDITIONALSERVICE where ID = " + dwgEmp.SelectedRows[0].Cells["ID"].Value;
            DA.DeleteCommand.Connection.Open();
            DA.DeleteCommand.ExecuteNonQuery();
            DA.DeleteCommand.Connection.Close();
            fADDSERV_Load(sender, e);
            MessageBox.Show("Услуга успешно удалена!");

        }
    }
}
