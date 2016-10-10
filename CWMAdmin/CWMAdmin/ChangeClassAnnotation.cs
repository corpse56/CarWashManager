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
    public partial class fChangeClassAnnotation : Form
    {
        SqlDataAdapter DA;
        DataSet DS;
        public fChangeClassAnnotation()
        {
            InitializeComponent();
        }

        private void ChangeClassAnnotation_Load(object sender, EventArgs e)
        {
            DA = new SqlDataAdapter();
            DS = new DataSet();
            DA.SelectCommand = new SqlCommand();
            DA.SelectCommand.Connection = new SqlConnection(@"Data Source=127.0.0.1;Initial Catalog=CWM;Persist Security Info=True;User ID=CWM;Password=manager");
            DA.SelectCommand.CommandText = "select ID ID,CNAME+': '+ANNOTATION v from CWM..CARCLASS";
            DA.Fill(DS, "R");
            comboBox1.DataSource = DS.Tables["R"];
            comboBox1.ValueMember = "ID";
            comboBox1.DisplayMember = "v";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Введите название класса!");
                return;
            }
            DA.UpdateCommand = new SqlCommand();
            DA.UpdateCommand.Connection = new SqlConnection(@"Data Source=127.0.0.1;Initial Catalog=CWM;Persist Security Info=True;User ID=CWM;Password=manager");
            DA.UpdateCommand.Parameters.Add("ANN", SqlDbType.VarChar);
            DA.UpdateCommand.Parameters["ANN"].Value = textBox1.Text;
            DA.UpdateCommand.CommandText = "update CWM..CARCLASS set ANNOTATION = @ANN where ID = " + comboBox1.SelectedValue.ToString();
            DA.UpdateCommand.Connection.Open();
            DA.UpdateCommand.ExecuteNonQuery();
            DA.UpdateCommand.Connection.Close();
            MessageBox.Show("Название класса успешно изменено!");
            Close();

        }
    }
}
