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
    public partial class fChangeClass : Form
    {
        SqlDataAdapter DA;
        DataSet DS;
        List<int> SelectedCarsID;
        public fChangeClass(List<int> SelectedCarsID_)
        {
            InitializeComponent();
            this.SelectedCarsID = SelectedCarsID_;
        }

        private void fChangeClass_Load(object sender, EventArgs e)
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
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = new SqlConnection(@"Data Source=127.0.0.1;Initial Catalog=CWM;Persist Security Info=True;User ID=CWM;Password=manager");
            cmd.CommandText = "declare @IDS table (ID int not null) ";
            foreach (int i in SelectedCarsID)
            {
                cmd.CommandText += " insert into @IDS (ID) values (" + i.ToString() + ") ";
            }
            cmd.CommandText += " update CWM..CAR set IDCLASS = "+comboBox1.SelectedValue.ToString()+" where ID in (select ID from @IDS)";
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
