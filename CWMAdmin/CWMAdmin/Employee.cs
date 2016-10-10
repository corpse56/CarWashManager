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
    public partial class Employee : Form
    {
        SqlDataAdapter DA;
        DataSet DS;
        string EnCon = @"metadata=res://*/CWMEntity.csdl|res://*/CWMEntity.ssdl|res://*/CWMEntity.msl;provider=System.Data.SqlClient;provider connection string=""Data Source=127.0.0.1;Initial Catalog=CWM;Persist Security Info=True;User ID=CWM;Password=manager""";

        public Employee()
        {
            InitializeComponent();
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            DA = new SqlDataAdapter();
            DS = new DataSet();
            DA.SelectCommand = new SqlCommand();
            DA.SelectCommand.Connection = new SqlConnection(@"Data Source=127.0.0.1;Initial Catalog=CWM;Persist Security Info=True;User ID=CWM;Password=manager");
            DA.SelectCommand.CommandText = "select * from CWM..EMPLOYEE where (DELETED != 1 or DELETED is null)";
            int i = DA.Fill(DS, "R");
            dwgEmp.DataSource = DS.Tables["R"];

            dwgEmp.Columns["ENAME"].Width = 250;
            dwgEmp.Columns["ENAME"].HeaderText = "Имя";
            dwgEmp.Columns["ID"].Visible = false;
            dwgEmp.Columns["DELETED"].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddEmp ae = new AddEmp();
            ae.ShowDialog();
            Employee_Load(this, new EventArgs());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EditEmp ee = new EditEmp((int)dwgEmp.SelectedRows[0].Cells["id"].Value);
            ee.ShowDialog();
            Employee_Load(this, new EventArgs());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = (int)dwgEmp.SelectedRows[0].Cells["id"].Value;
            try
            {
                using (CWMEntities cwm = new CWMEntities(EnCon))
                {
                    EMPLOYEE e1;
                    e1 = (EMPLOYEE)(from t in cwm.EMPLOYEE
                                    where t.ID == id
                                    select t).First();
                    e1.DELETED = true;
                    cwm.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при редактировании сотрудника!", ex.Message);
                return;
            }
            Employee_Load(this, new EventArgs());
            MessageBox.Show("Сотрудник успешно удален!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Вы уверены, что хотите удалить всех сотрудников?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No)
            {
                return;
            }
            DA = new SqlDataAdapter();
            DS = new DataSet();
            DA.UpdateCommand = new SqlCommand();
            DA.UpdateCommand.Connection = new SqlConnection(@"Data Source=127.0.0.1;Initial Catalog=CWM;Persist Security Info=True;User ID=CWM;Password=manager");
            DA.UpdateCommand.CommandText = "update CWM..EMPLOYEE set DELETED = 1";
            DA.UpdateCommand.Connection.Open();
            DA.UpdateCommand.ExecuteNonQuery();
            DA.UpdateCommand.Connection.Close();
            MessageBox.Show("Все сотрудники успешно удалены!");
        }
    }
}
