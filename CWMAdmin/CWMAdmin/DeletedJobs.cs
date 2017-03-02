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
    public partial class DeletedJobs : Form
    {

        SqlDataAdapter DA;
        DataSet DS;
        public DeletedJobs()
        {
            InitializeComponent();
        }

        private void DeletedPack_Load(object sender, EventArgs e)
        {
            DA = new SqlDataAdapter();
            DS = new DataSet();
            DA.SelectCommand = new SqlCommand();
            DA.SelectCommand.Connection = new SqlConnection(@"Data Source=127.0.0.1;Initial Catalog=CWM;Persist Security Info=True;User ID=CWM;Password=manager");
            DA.SelectCommand.CommandText = "select top 1000 A.IDORIGINALJOB id,A.JOBDATE jdate,C.ENAME emp,E.CNAME car,A.LINE line, A.IDCLASS idc," +
                    " A.NPLATE plate, A.TOTALCOST cst, A.DATEDELETED deldate" +
                    " from CWM..REMOVEDJOB A" +
                    "  left join CWM..EMPLOYEE C on C.ID = A.IDEMP" +
                    " left join CWM..CAR E on A.IDCAR = E.ID" +
                    "  order by A.DATEDELETED desc";
            int i = DA.Fill(DS, "R");
            dgwDel.DataSource = DS.Tables["R"];

            dgwDel.Columns["id"].HeaderText = "Номер работы";
            dgwDel.Columns["jdate"].Width = 150;
            dgwDel.Columns["jdate"].HeaderText = "Дата";
            dgwDel.Columns["emp"].Width = 100;
            dgwDel.Columns["emp"].HeaderText = "Сотрудник";
            dgwDel.Columns["car"].Width = 150;
            dgwDel.Columns["car"].HeaderText = "Автомобиль";
            dgwDel.Columns["line"].Width = 70;
            dgwDel.Columns["line"].HeaderText = "Линия";
            dgwDel.Columns["idc"].Width = 70;
            dgwDel.Columns["idc"].HeaderText = "Класс";
            dgwDel.Columns["plate"].Width = 100;
            dgwDel.Columns["plate"].HeaderText = "Гос. номер";
            dgwDel.Columns["cst"].Width = 100;
            dgwDel.Columns["cst"].HeaderText = "Стоимость";
            dgwDel.Columns["deldate"].Width = 150;
            dgwDel.Columns["deldate"].HeaderText = "Дата удаления";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgwDel.SelectedRows.Count == 0)
            {
                MessageBox.Show("Не выбрана ни одна строка!");
                return;
            }
            DA.DeleteCommand = new SqlCommand();
            DA.DeleteCommand.Connection = new SqlConnection(@"Data Source=127.0.0.1;Initial Catalog=CWM;Persist Security Info=True;User ID=CWM;Password=manager");
            DA.DeleteCommand.CommandText = "delete from CWM..PACKAGE where ID = " + dgwDel.SelectedRows[0].Cells["idp"].Value.ToString();
            DA.DeleteCommand.Connection.Open();
            DA.DeleteCommand.ExecuteNonQuery();
            DA.DeleteCommand.Connection.Close();
            DeletedPack_Load(sender, e);
            MessageBox.Show("Услуга удалена из удаленных услуг!");
        }
    }
}
