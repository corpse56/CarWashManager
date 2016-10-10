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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void прайсЛистToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Price p = new Price();
            p.ShowDialog();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void сотрудникиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Employee em = new Employee();
            em.ShowDialog();
        }

        private void автомобилиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Car c = new Car();
            c.ShowDialog();
        }

        private void очиститьВсеЗаданияЗаВсёВремяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Вы уверены, что хотите удалить все задания за всё время? Восстановление возможно только за предыдущий день!", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                SqlDataAdapter DA = new SqlDataAdapter();
                DA.DeleteCommand = new SqlCommand();
                DA.DeleteCommand.Connection = new SqlConnection(@"Data Source=127.0.0.1;Initial Catalog=CWM;Persist Security Info=True;User ID=CWM;Password=manager");
                DA.DeleteCommand.Connection.Open();
                DA.DeleteCommand.CommandText = "delete from CWM..JOB; delete from CWM..PACKAGE";
                DA.DeleteCommand.ExecuteNonQuery();
                MessageBox.Show("Задания успешно удалены!");
            }
        }

        private void удаленныеЗаданияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeletedPack dp = new DeletedPack();
            dp.ShowDialog();
        }

        private void переименоватьКлассыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fChangeClassAnnotation fChAnn = new fChangeClassAnnotation();
            fChAnn.ShowDialog();

        }

        private void дополнительныеУслугиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fADDSERV fas = new fADDSERV();
            fas.ShowDialog();
        }

        private void задатьПарольПанелиАдминистратораToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePassword cp = new ChangePassword();
            cp.ShowDialog();
        }
    }
}
