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
    public partial class AddCar : Form
    {
        public AddCar()
        {
            InitializeComponent();
        }
        string EnCon = @"metadata=res://*/CWMEntity.csdl|res://*/CWMEntity.ssdl|res://*/CWMEntity.msl;provider=System.Data.SqlClient;provider connection string=""Data Source=127.0.0.1;Initial Catalog=CWM;Persist Security Info=True;User ID=CWM;Password=manager""";

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Введите название автомобиля!");
                return;
            }
            CAR e1 = new CAR();
            e1.CNAME = textBox1.Text;
            if (radioButton1.Checked)
                e1.IDCLASS = 1;
            if (radioButton2.Checked)
                e1.IDCLASS = 2;
            if (radioButton3.Checked)
                e1.IDCLASS = 3;
            if (radioButton4.Checked)
                e1.IDCLASS = 4;
            if (radioButton5.Checked)
                e1.IDCLASS = 5;

            try
            {
                using (CWMEntities cwm = new CWMEntities(EnCon))
                {
                    cwm.AddToCAR(e1);
                    cwm.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении автомобиля!",ex.Message);
                return;
            }
            MessageBox.Show("Автомобиль успешно добавлен!");
            Close();
        }
    }
}
