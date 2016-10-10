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
    public partial class AddPrice : Form
    {
        public AddPrice()
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
                MessageBox.Show("Ведите наименование услуги!");
                return;
            }
            PRICELIST p1 = new PRICELIST();
            p1.PNAME = textBox1.Text;
            p1.IDCLASS = 1;
            p1.COST = (int)numericUpDown1.Value;
            PRICELIST p2 = new PRICELIST();
            p2.PNAME = textBox1.Text;
            p2.IDCLASS = 2;
            p2.COST = (int)numericUpDown2.Value;
            PRICELIST p3 = new PRICELIST();
            p3.PNAME = textBox1.Text;
            p3.IDCLASS = 3;
            p3.COST = (int)numericUpDown3.Value;
            PRICELIST p4 = new PRICELIST();
            p4.PNAME = textBox1.Text;
            p4.IDCLASS = 4;
            p4.COST = (int)numericUpDown4.Value;
            PRICELIST p5 = new PRICELIST();
            p5.PNAME = textBox1.Text;
            p5.IDCLASS = 5;
            p5.COST = (int)numericUpDown5.Value;
            try
            {
                using (CWMEntities cwm = new CWMEntities(EnCon))
                {
                    cwm.AddToPRICELIST(p1);
                    cwm.AddToPRICELIST(p2);
                    cwm.AddToPRICELIST(p3);
                    cwm.AddToPRICELIST(p4);
                    cwm.AddToPRICELIST(p5);
                    cwm.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении услуги!",ex.Message);
                return;
            }
            MessageBox.Show("Услуга успешно добавлена");
            Close();
        }
    }
}
