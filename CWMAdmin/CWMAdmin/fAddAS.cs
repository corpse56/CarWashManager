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
    public partial class fAddAS : Form
    {
        SqlDataAdapter DA;
        DataSet DS;

        public fAddAS()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Наименование услуги не может быть пустым!");
                return;
            }
            if (numericUpDown1.Value == 0)
            {
                MessageBox.Show("Цена должна отличаться от нуля!");
                return;
            }

            DA = new SqlDataAdapter();
            DS = new DataSet();
            DA.InsertCommand = new SqlCommand();
            DA.InsertCommand.Connection = new SqlConnection(@"Data Source=127.0.0.1;Initial Catalog=CWM;Persist Security Info=True;User ID=CWM;Password=manager");
            DA.InsertCommand.Parameters.Add("NAME", SqlDbType.NVarChar);
            DA.InsertCommand.Parameters["NAME"].Value = textBox1.Text;
            DA.InsertCommand.Parameters.Add("COST", SqlDbType.Int);
            DA.InsertCommand.Parameters["COST"].Value = numericUpDown1.Value;

            DA.InsertCommand.CommandText = "insert into CWM..ADDITIONALSERVICE (ASNAME,COST) values (@NAME,@COST)";
            DA.InsertCommand.Connection.Open();
            DA.InsertCommand.ExecuteNonQuery();
            DA.InsertCommand.Connection.Close();
            Close();
        }
    }
}
