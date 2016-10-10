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
    public partial class Car : Form
    {
        SqlDataAdapter DA;
        DataSet DS;

        public Car()
        {
            InitializeComponent();
        }

        private void Car_Load(object sender, EventArgs e)
        {
            DA = new SqlDataAdapter();
            DS = new DataSet();
            DA.SelectCommand = new SqlCommand();
            DA.SelectCommand.Connection = new SqlConnection(@"Data Source=127.0.0.1;Initial Catalog=CWM;Persist Security Info=True;User ID=CWM;Password=manager");
            DA.SelectCommand.CommandText = "select IDCLASS,CNAME,ID from CWM..CAR order by 1,2";
            int i = DA.Fill(DS, "R");
            dwgEmp.DataSource = DS.Tables["R"];

            dwgEmp.Columns["CNAME"].Width = 250;
            dwgEmp.Columns["CNAME"].HeaderText = "Название";
            dwgEmp.Columns["IDCLASS"].Width = 100;
            dwgEmp.Columns["IDCLASS"].HeaderText = "Класс";
            dwgEmp.Columns["ID"].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddCar ae = new AddCar();
            ae.ShowDialog();
            Car_Load(this, new EventArgs());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dwgEmp.SelectedRows.Count > 1)
            {
                MessageBox.Show("Выберите только один автомобиль!");
                return;
            }
            EditCar ee = new EditCar((int)dwgEmp.SelectedRows[0].Cells["id"].Value);
            ee.ShowDialog();
            Car_Load(this, new EventArgs());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dwgEmp.SelectedRows.Count > 1)
            {
                MessageBox.Show("Выберите только один автомобиль!");
                return;
            }
            DA.DeleteCommand = new SqlCommand();
            DA.DeleteCommand.Connection = new SqlConnection(@"Data Source=127.0.0.1;Initial Catalog=CWM;Persist Security Info=True;User ID=CWM;Password=manager");
            DA.DeleteCommand.Parameters.Add("ID", SqlDbType.Int);
            DA.DeleteCommand.Parameters["ID"].Value = (int)dwgEmp.SelectedRows[0].Cells["id"].Value;
            DA.DeleteCommand.CommandText = "delete from CWM..CAR where ID = @ID";
            DA.DeleteCommand.Connection.Open();
            DA.DeleteCommand.ExecuteNonQuery();
            DA.DeleteCommand.Connection.Close();
            Car_Load(this, new EventArgs());
            MessageBox.Show("Автомобиль успешно удалён!");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<int> SelectedCarsID = new List<int>();
            foreach (DataGridViewRow r in dwgEmp.SelectedRows)
            {
                SelectedCarsID.Add((int)r.Cells["id"].Value);
            }
            fChangeClass fChClass = new fChangeClass(SelectedCarsID);
            fChClass.ShowDialog();
            Car_Load(this, new EventArgs());
            MessageBox.Show("Класс выбранных автомобилей успешно изменён!");

        }
    }
}
