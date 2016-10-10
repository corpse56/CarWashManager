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
    public partial class EditPrice : Form
    {
        int id1 = 0;
        int id2 = 0;
        int id3 = 0;
        int id4 = 0;
        int id5 = 0;
        PRICELIST pr1;
        PRICELIST pr2;
        PRICELIST pr3;
        PRICELIST pr4;
        PRICELIST pr5;
        public EditPrice(string pn)
        {
            InitializeComponent();
            using (CWMEntities cwm = new CWMEntities(EnCon))
            {
                var r = from p in cwm.PRICELIST
                        where p.PNAME == pn
                        select p;
                foreach (PRICELIST pr in r)
                {
                    if (pr.IDCLASS == 1)
                    {
                        numericUpDown1.Value = pr.COST;
                        pr1 = pr;
                    }
                    if (pr.IDCLASS == 2)
                    {
                        numericUpDown2.Value = pr.COST;
                        pr2 = pr;
                    }
                    if (pr.IDCLASS == 3)
                    {
                        numericUpDown3.Value = pr.COST;
                        pr3 = pr;
                    }
                    if (pr.IDCLASS == 4)
                    {
                        numericUpDown4.Value = pr.COST;
                        pr4 = pr;
                    }
                    if (pr.IDCLASS == 5)
                    {
                        numericUpDown5.Value = pr.COST;
                        pr5 = pr;
                    }
                }
                textBox1.Text = pr1.PNAME;
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
                MessageBox.Show("Ведите наименование услуги!");
                return;
            }
            pr1.PNAME = textBox1.Text;
            pr1.COST = (int)numericUpDown1.Value;
            pr2.PNAME = textBox1.Text;
            pr2.COST = (int)numericUpDown2.Value;
            pr3.PNAME = textBox1.Text;
            pr3.COST = (int)numericUpDown3.Value;
            pr4.PNAME = textBox1.Text;
            pr4.COST = (int)numericUpDown4.Value;
            pr5.PNAME = textBox1.Text;
            pr5.COST = (int)numericUpDown5.Value;
            try
            {
                using (CWMEntities cwm = new CWMEntities(EnCon))
                {
                    PRICELIST p1;
                    PRICELIST p2;
                    PRICELIST p3;
                    PRICELIST p4;
                    PRICELIST p5;
                    p1 = (PRICELIST)(from t in cwm.PRICELIST
                                    where t.ID == pr1.ID
                                    select t).First();
                    p1.PNAME = pr1.PNAME;
                    p1.COST = pr1.COST;
                    p2 = (PRICELIST)(from t in cwm.PRICELIST
                                     where t.ID == pr2.ID
                                     select t).First();
                    p2.PNAME = pr2.PNAME;
                    p2.COST = pr2.COST;

                    p3 = (PRICELIST)(from t in cwm.PRICELIST
                                     where t.ID == pr3.ID
                                     select t).First();
                    p3.PNAME = pr3.PNAME;
                    p3.COST = pr3.COST;

                    p4 = (PRICELIST)(from t in cwm.PRICELIST
                                     where t.ID == pr4.ID
                                     select t).First();
                    p4.PNAME = pr4.PNAME;
                    p4.COST = pr4.COST;

                    p5 = (PRICELIST)(from t in cwm.PRICELIST
                                     where t.ID == pr5.ID
                                     select t).First();
                    p5.PNAME = pr5.PNAME;
                    p5.COST = pr5.COST;

                    cwm.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при редактировании услуги!",ex.Message);
                return;
            }
            MessageBox.Show("Услуга успешно изменена!");
            Close();
        }
    }
}
