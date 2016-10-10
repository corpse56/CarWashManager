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
    public partial class EditCar : Form
    {
        CAR car;
        public EditCar(int id)
        {
            InitializeComponent();
            using (CWMEntities cwm = new CWMEntities(EnCon))
            {
                var r = (from p in cwm.CAR
                         where p.ID == id
                         select p).First();
                textBox1.Text = ((CAR)r).CNAME;
                car = new CAR();
                car.ID = ((CAR)r).ID;
                car.CNAME = ((CAR)r).CNAME;
                car.IDCLASS = ((CAR)r).IDCLASS;
                if (car.IDCLASS == 1)
                    radioButton1.Checked = true;
                if (car.IDCLASS == 2)
                    radioButton2.Checked = true;
                if (car.IDCLASS == 3)
                    radioButton3.Checked = true;
                if (car.IDCLASS == 4)
                    radioButton4.Checked = true;
                if (car.IDCLASS == 5)
                    radioButton5.Checked = true;
            }
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
            try
            {
                using (CWMEntities cwm = new CWMEntities(EnCon))
                {
                    CAR e1;
                    e1 = (CAR)(from t in cwm.CAR
                                    where t.ID == car.ID
                                    select t).First();
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
                    e1.CNAME = textBox1.Text;
                    cwm.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при редактировании автомобиля!", ex.Message);
                return;
            }
            MessageBox.Show("Автомобиль успешно изменен!");
            Close();
        }
    }
}
