using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CWMAdmin
{
    public partial class EditEmp : Form
    {
        EMPLOYEE emp;
        string EnCon = @"metadata=res://*/CWMEntity.csdl|res://*/CWMEntity.ssdl|res://*/CWMEntity.msl;provider=System.Data.SqlClient;provider connection string=""Data Source=127.0.0.1;Initial Catalog=CWM;Persist Security Info=True;User ID=CWM;Password=manager""";

        public EditEmp(int id)
        {
            InitializeComponent();

            using (CWMEntities cwm = new CWMEntities(EnCon))
            {
                var r = (from p in cwm.EMPLOYEE
                        where p.ID == id
                        select p).First();
                textBox1.Text = ((EMPLOYEE)r).ENAME;
                emp = new EMPLOYEE();
                emp.ID = ((EMPLOYEE)r).ID;
                emp.ENAME = ((EMPLOYEE)r).ENAME;
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Введите имя сотрудника!");
                return;
            }
            try
            {
                using (CWMEntities cwm = new CWMEntities(EnCon))
                {
                    EMPLOYEE e1;
                    e1 = (EMPLOYEE)(from t in cwm.EMPLOYEE
                                    where t.ID == emp.ID
                                    select t).First();
                    e1.ENAME = textBox1.Text;
                    cwm.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при редактировании сотрудника!",ex.Message);
                return;
            }
            MessageBox.Show("Сотрудник успешно изменен!");
            Close();
        }
    }
}
