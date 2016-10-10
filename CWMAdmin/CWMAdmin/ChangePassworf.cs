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
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        SqlDataAdapter DA;
        DataSet DS;

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Введите пароль!");
                return;
            }
            if (textBox1.Text != textBox2.Text)
            {
                MessageBox.Show("Пароли не совпадают!");
                return;
            }
            DA = new SqlDataAdapter();
            DA.UpdateCommand = new SqlCommand();
            DA.UpdateCommand.Connection = new SqlConnection(@"Data Source=127.0.0.1;Initial Catalog=CWM;Persist Security Info=True;User ID=CWM;Password=manager");
            DA.UpdateCommand.Parameters.Add("ANN", SqlDbType.VarChar);
            DA.UpdateCommand.Parameters["ANN"].Value = textBox1.Text;
            DA.UpdateCommand.CommandText = "update CWM..PASSWORD set ADMINPASS = @ANN where LOGIN = 'admin'";
            DA.UpdateCommand.Connection.Open();
            DA.UpdateCommand.ExecuteNonQuery();
            DA.UpdateCommand.Connection.Close();
            MessageBox.Show("Новый пароль успешно установлен!");
            Close();
        }
    }
}
