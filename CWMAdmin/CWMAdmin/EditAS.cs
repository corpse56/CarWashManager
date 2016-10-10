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
    public partial class fEditAS : Form
    {
        int id;
        SqlDataAdapter DA;
        DataSet DS;
        public fEditAS(int id_)
        {
            InitializeComponent();
            this.id = id_;
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
            DA.UpdateCommand = new SqlCommand();
            DA.UpdateCommand.Connection = new SqlConnection(@"Data Source=127.0.0.1;Initial Catalog=CWM;Persist Security Info=True;User ID=CWM;Password=manager");
            DA.UpdateCommand.Parameters.Add("NAME", SqlDbType.NVarChar);
            DA.UpdateCommand.Parameters["NAME"].Value = textBox1.Text;
            DA.UpdateCommand.Parameters.Add("COST", SqlDbType.Int);
            DA.UpdateCommand.Parameters["COST"].Value = numericUpDown1.Value;

            DA.UpdateCommand.CommandText = "Update CWM..ADDITIONALSERVICE set ASNAME = @NAME, COST = @COST where ID = "+this.id;
            DA.UpdateCommand.Connection.Open();
            DA.UpdateCommand.ExecuteNonQuery();
            DA.UpdateCommand.Connection.Close();
            Close();
        }

        private void fEditAS_Load(object sender, EventArgs e)
        {
            DA = new SqlDataAdapter();
            DS = new DataSet();
            DA.SelectCommand = new SqlCommand();
            DA.SelectCommand.Connection = new SqlConnection(@"Data Source=127.0.0.1;Initial Catalog=CWM;Persist Security Info=True;User ID=CWM;Password=manager");
            DA.SelectCommand.CommandText = "select ID,ASNAME,COST from CWM..ADDITIONALSERVICE where ID = "+this.id;
            int i = DA.Fill(DS, "R");
            textBox1.Text = (string)DS.Tables["R"].Rows[0]["ASNAME"];
            numericUpDown1.Value = (int)DS.Tables["R"].Rows[0]["COST"];


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
