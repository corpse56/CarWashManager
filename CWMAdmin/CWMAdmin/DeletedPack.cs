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
    public partial class DeletedPack : Form
    {

        SqlDataAdapter DA;
        DataSet DS;
        public DeletedPack()
        {
            InitializeComponent();
        }

        private void DeletedPack_Load(object sender, EventArgs e)
        {
            DA = new SqlDataAdapter();
            DS = new DataSet();
            DA.SelectCommand = new SqlCommand();
            DA.SelectCommand.Connection = new SqlConnection(@"Data Source=127.0.0.1;Initial Catalog=CWM;Persist Security Info=True;User ID=CWM;Password=manager");
            DA.SelectCommand.CommandText = "select A.ID idp,B.ID id,B.JOBDATE jdate,C.ENAME emp,E.CNAME car,D.PNAME price,B.LINE line, B.IDCLASS idc," +
                    " B.NPLATE plate, A.COST cst" +
                    " from CWM..PACKAGE A" +
                    " left join CWM..JOB B on A.IDJOB = B.ID" +
                    "  left join CWM..EMPLOYEE C on C.ID = B.IDEMP" +
                    " left join CWM..PRICELIST D on A.IDPRICE = D.ID" +
                    " left join CWM..CAR E on B.IDCAR = E.ID"+
                    "  where A.DELETED = 1 and B.ID is not null";
            int i = DA.Fill(DS, "R");
            dgwDel.DataSource = DS.Tables["R"];

            dgwDel.Columns["idp"].Visible = false;
            dgwDel.Columns["id"].Width = 100;
            dgwDel.Columns["id"].HeaderText = "Номер работы";
            dgwDel.Columns["jdate"].Width = 150;
            dgwDel.Columns["jdate"].HeaderText = "Дата";
            dgwDel.Columns["emp"].Width = 100;
            dgwDel.Columns["emp"].HeaderText = "Сотрудник";
            dgwDel.Columns["car"].Width = 150;
            dgwDel.Columns["car"].HeaderText = "Автомобиль";
            dgwDel.Columns["price"].Width = 150;
            dgwDel.Columns["price"].HeaderText = "Услуга";
            dgwDel.Columns["line"].Width = 70;
            dgwDel.Columns["line"].HeaderText = "Линия";
            dgwDel.Columns["idc"].Width = 70;
            dgwDel.Columns["idc"].HeaderText = "Класс";
            dgwDel.Columns["plate"].Width = 100;
            dgwDel.Columns["plate"].HeaderText = "Гос. номер";
            dgwDel.Columns["cst"].Width = 100;
            dgwDel.Columns["cst"].HeaderText = "Стоимость";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (dgwDel.SelectedRows.Count == 0)
            {
                MessageBox.Show("Не выбрана ни одна строка!");
                return;
            }
            foreach (DataGridViewRow row in dgwDel.SelectedRows)
            {
                DA.DeleteCommand = new SqlCommand();
                DA.DeleteCommand.Connection = new SqlConnection(@"Data Source=127.0.0.1;Initial Catalog=CWM;Persist Security Info=True;User ID=CWM;Password=manager");
                DA.DeleteCommand.CommandText = "delete from CWM..PACKAGE where ID = " + dgwDel.SelectedRows[0].Cells["idp"].Value.ToString();
                DA.DeleteCommand.Connection.Open();
                DA.DeleteCommand.ExecuteNonQuery();
                DA.DeleteCommand.Connection.Close();
                dgwDel.Rows.Remove(row);
            }
            //DeletedPack_Load(sender, e);
            MessageBox.Show("Выделенные услуги удалены из удаленных услуг!");
        }
    }
}
