using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace CarWashManager
{
    public partial class AddJob : System.Web.UI.Page
    {
        SqlDataAdapter DA;
        DataSet DS;
        string EnCon = @"metadata=res://*/CWMModel.csdl|res://*/CWMModel.ssdl|res://*/CWMModel.msl;provider=System.Data.SqlClient;provider connection string=""Data Source=127.0.0.1;Initial Catalog=CWM;Persist Security Info=True;User ID=CWM;Password=manager""";
        protected void Page_Load(object sender, EventArgs e)
        {
            bAdd.Attributes.Add("onclick", " this.disabled = true; " + ClientScript.GetPostBackEventReference(bAdd, null) + ";");
            tbCar.Attributes["onclick"] = "chbManual.Checeked = !chbManual.Checeked";
            ScriptManager1.RegisterAsyncPostBackControl(bAdd);
            DA = new SqlDataAdapter();
            DS = new DataSet();
            DA.SelectCommand = new SqlCommand();
            DA.SelectCommand.Connection = new SqlConnection(@"Data Source=127.0.0.1\SQL2008R2;Initial Catalog=CWM;Persist Security Info=True;User ID=CWM;Password=manager");
            if (!Page.IsPostBack)
            {
                DA.SelectCommand.CommandText = "select ID,LNAME from CWM..LINE";
                DA.Fill(DS, "L");
                ddlLine.DataSource = DS.Tables["L"];
                ddlLine.DataTextField = "LNAME";
                ddlLine.DataValueField = "ID";
                ddlLine.DataBind();

                DA.SelectCommand.CommandText = "select ID,ENAME from CWM..EMPLOYEE where (DELETED != 1 or DELETED is null) order by ENAME";
                DA.Fill(DS, "E");
                DataView dve = new DataView();
                dve = DS.Tables["E"].DefaultView;
                dve.Sort = "ENAME";

                ddlCar.DataSource = dve;
                ddlEmployees.DataSource = dve;
                ddlEmployees.DataTextField = "ENAME";
                ddlEmployees.DataValueField = "ID";
                ddlEmployees.DataBind();
                DA.SelectCommand.CommandText = "select ID,CNAME+': '+ANNOTATION as CNAME from CWM..CARCLASS";
                DS = new DataSet();
                DA.Fill(DS, "C");
                ddlClass.DataSource = DS.Tables["C"];
                ddlClass.DataTextField = "CNAME";
                ddlClass.DataValueField = "ID";
                ddlClass.DataBind();
                DA.SelectCommand.CommandText = "select ID,CNAME from CWM..CAR where IDCLASS = " + ddlClass.SelectedValue + "  order by CNAME";
                DS = new DataSet();
                DA.Fill(DS, "CAR");
                DataView dv = new DataView();
                dv = DS.Tables["CAR"].DefaultView;
                dv.Sort = "CNAME";
                
                ddlCar.DataSource = dv;
                ddlCar.DataTextField = "CNAME";
                ddlCar.DataValueField = "ID";
                
                ddlCar.DataBind();

                DA.SelectCommand.CommandText = "select ID,PNAME from CWM..PRICELIST where IDCLASS = " + ddlClass.SelectedValue
                    + " order by PNAME";
                DS = new DataSet();
                DA.Fill(DS, "PRICE");
                chblPrice.DataSource = DS.Tables["PRICE"];
                chblPrice.DataTextField = "PNAME";
                chblPrice.DataValueField = "ID";
                chblPrice.DataBind();
                chblPrice.RepeatColumns = 2;

                /*DA.SelectCommand.CommandText = "select ID,ASNAME from CWM..ADDITIONALSERVICE order by ASNAME";
                DS = new DataSet();
                DA.Fill(DS, "ADDITIONALSERVICE");
                chblAddServ.DataSource = DS.Tables["ADDITIONALSERVICE"];
                chblAddServ.DataTextField = "ASNAME";
                chblAddServ.DataValueField = "ID";
                chblAddServ.DataBind();
                chblAddServ.RepeatColumns = 2;*/
            }
        }

        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            DA.SelectCommand.CommandText = "select ID,CNAME from CWM..CAR where IDCLASS = " + ddlClass.SelectedValue;
            DS = new DataSet();
            DA.Fill(DS, "CAR");
            //ddlCar.DataSource = DS.Tables["CAR"];
            DataView dv = new DataView();
            dv = DS.Tables["CAR"].DefaultView;
            dv.Sort = "CNAME";
            ddlCar.DataSource = dv;

            ddlCar.DataTextField = "CNAME";
            ddlCar.DataValueField = "ID";
            ddlCar.DataBind();

            DA.SelectCommand.CommandText = "select ID,PNAME from CWM..PRICELIST where IDCLASS = " + ddlClass.SelectedValue
                + " order by PNAME";
            DS = new DataSet();
            DA.Fill(DS, "PRICE");
            chblPrice.DataSource = DS.Tables["PRICE"];
            chblPrice.DataTextField = "PNAME";
            chblPrice.DataValueField = "ID";
            chblPrice.DataBind();
            chblPrice.RepeatColumns = 2;
        }

        protected void chbManual_CheckedChanged(object sender, EventArgs e)
        {
            if (chbManual.Checked)
            {
                tbCar.Enabled = true;
                ddlCar.Enabled = false;
            }
            else
            {
                tbCar.Enabled = false;
                ddlCar.Enabled = true;
            }
        }

        protected void bAdd_Click(object sender, EventArgs e)
        {
            //bAdd.Enabled = false;
            try
            {
                lError.Text = "";
                if (tbPlate.Text == "")
                {
                    lError.Text = "Введите государственный номер автомобиля!";
                    bAdd.Enabled = true;

                    return;
                }
                if ((chbManual.Checked) && (tbCar.Text == ""))
                {
                    lError.Text = "Введите название автомобиля!";
                    bAdd.Enabled = true;

                    return;
                }
                bool ISPrice = false;
                foreach (ListItem c in chblPrice.Items)
                {
                    if (c.Selected)
                    {
                        ISPrice = true;
                        break;
                    }
                }
                if (!ISPrice)
                {
                    lError.Text = "Отметьте хотя бы одну услугу!";
                    bAdd.Enabled = true;

                    return;
                }
                int y = ddlEmployees.SelectedIndex;
                if (y == -1)
                {
                    lError.Text = "Добавьте сотрудников в базу!";
                    bAdd.Enabled = true;

                    return;
                }
                JOB J = new JOB();
                J.IDCLASS = int.Parse(ddlClass.SelectedValue);
                if (chbManual.Checked)
                {
                    J.IDCAR = AddNewCar(tbCar.Text, J.IDCLASS);
                }
                else
                {
                    J.IDCAR = int.Parse(ddlCar.SelectedValue);
                }

                J.IDEMP = int.Parse(ddlEmployees.SelectedValue);
                J.JOBDATE = DateTime.Now;
                J.LINE = int.Parse(ddlLine.SelectedValue);
                J.NPLATE = tbPlate.Text;
                J.IDPACKAGE = -1;
                if (ddlSpecial.Text == "НЕТ")
                {
                    J.TOTALCOST = GetTotalCost();
                }
                else
                {
                    J.TOTALCOST = 0;
                }
                /*if (chbPlus_50.Checked)
                {
                    J.PLUS_50 = true;
                }*/
                using (CWMEntities cwm = new CWMEntities(EnCon))
                {
                    cwm.AddToJOB(J);

                    cwm.SaveChanges();
                    AddNewPackage(J.ID);
                    //AddNewAddPackage(J.ID);
                }
            }
            catch (Exception ex)
            {
                lError.Text = "Ошибка при добавлении задания! Попробуйте обновить страницу и попробовать еще раз. " + ex.Message;// +ex.InnerException.Message;
                bAdd.Enabled = true;
                return;
            }
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, GetType(), "success", @"alert('Работа успешно добавлена!');location = ""Default.aspx""", true);
            //Response.Redirect(@"~\default.aspx");
            //bAdd.Enabled = true;

        }



        private int GetTotalCost()
        {

            string prices = "";
            int result = 0;
            foreach (ListItem c in chblPrice.Items)
            {
                if (c.Selected)
                {
                    prices += c.Value + ",";
                }
            }
            prices = prices.Substring(0, prices.Length - 1);
            DA.SelectCommand.CommandText = "select sum(A.COST) from CWM..PRICELIST A" +
                                           " where ID in (" + prices + ")";
            if (DA.SelectCommand.Connection.State == ConnectionState.Closed)
            {
                DA.SelectCommand.Connection.Open();
            }
            result = (int)DA.SelectCommand.ExecuteScalar();
            prices = "";
            //addservices
            /*foreach (ListItem c in chblAddServ.Items)
            {
                if (c.Selected)
                {
                    prices += c.Value + ",";
                }
            }
            prices = prices.Substring(0, prices.Length - 1);
            DA.SelectCommand.CommandText = "select sum(A.COST) from CWM..ADDITIONALSERVICE A" +
                                           " where ID in (" + prices + ")";
            if (DA.SelectCommand.Connection.State == ConnectionState.Closed)
            {
                DA.SelectCommand.Connection.Open();
            }
            result += (int)DA.SelectCommand.ExecuteScalar();

            if (chbPlus_50.Checked)
            {
                result = result + result / 2;
            }*/
            return result;
        }

        private void AddNewPackage(int idjob)
        {
            PACKAGE p;
            using (CWMEntities cwm = new CWMEntities(EnCon))
            {
                foreach (ListItem c in chblPrice.Items)
                {
                    if (c.Selected)
                    {
                        p = new PACKAGE();
                        p.IDJOB = idjob;
                        p.IDPRICE = int.Parse(c.Value);
                        if (ddlSpecial.Text == "НЕТ")
                        {
                            p.COST = GetCost(c.Value);
                        }
                        else
                        {
                            p.COST = 0;
                        }
                        cwm.AddToPACKAGE(p);

                    }
                }
                cwm.SaveChanges();
            }
            //CrystalReport1 cr = new CrystalReport1();
            //cr.SetDataSource(
        }
        //private void AddNewAddPackage(int idjob)
        //{
        //    PACKAGEADDSERV PAS;
            
        //    using (CWMEntities cwm = new CWMEntities(EnCon))
        //    {
        //        foreach (ListItem c in chblAddServ.Items)
        //        {
        //            if (c.Selected)
        //            {
        //                PAS = new PACKAGEADDSERV();
        //                PAS.IDJOB= idjob;
        //                PAS.IDADDSERV = int.Parse(c.Value);
        //                if (ddlSpecial.Text == "НЕТ")
        //                {
        //                    PAS.COST = GetCostAddServ(c.Value);
        //                }
        //                else
        //                {
        //                    PAS.COST = 0;
        //                }
        //                cwm.AddToPACKAGEADDSERV(PAS);

        //            }
        //        }
        //        cwm.SaveChanges();
        //    }
        //}

        //private int GetCostAddServ(string p)
        //{
        //    ADDITIONALSERVICE AS;
        //    int id = int.Parse(p);
        //    using (CWMEntities cwm = new CWMEntities(EnCon))
        //    {
        //        var c = from t in cwm.ADDITIONALSERVICE
        //                where t.ID == id
        //                select t;
        //        AS = c.First();
        //    }
        //    return AS.COST;
        //}
        private int GetCost(string p)
        {
            PRICELIST res;
            int id = int.Parse(p);
            using (CWMEntities cwm = new CWMEntities(EnCon))
            {
                var c = from t in cwm.PRICELIST
                        where t.ID == id
                        select t;
                res = c.First();
            }
            return res.COST;
        }



        private int AddNewCar(string cname,int cclass)
        {
            CAR c = new CAR();
            c.CNAME = cname;
            c.IDCLASS = cclass;
            using (CWMEntities cwm = new CWMEntities(EnCon))
            {
                cwm.AddToCAR(c);
                cwm.SaveChanges();
            }
            return c.ID;
        }

        protected void tbCar_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
