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
    public partial class EditJob : System.Web.UI.Page
    {
        SqlDataAdapter DA;
        DataSet DS;
        DataSet DSJ;
        DataSet DSP;
        DataSet DSPA;
        DataSet DSD;//already deleted
        DataSet DSPAD;
        DataSet PLUS_50;
        List<int> DeletedServices;
        List<int> DeletedServicesA;
        bool Plus_50 = false;
        string EnCon = @"metadata=res://*/CWMModel.csdl|res://*/CWMModel.ssdl|res://*/CWMModel.msl;provider=System.Data.SqlClient;provider connection string=""Data Source=127.0.0.1;Initial Catalog=CWM;Persist Security Info=True;User ID=CWM;Password=manager""";
        protected void Page_Load(object sender, EventArgs e)
        {
            tbCar.Attributes["onclick"] = "chbManual.Checeked = !chbManual.Checeked";
            ScriptManager1.RegisterAsyncPostBackControl(bAdd);
            DA = new SqlDataAdapter();
            DS = new DataSet();
            DSJ = new DataSet();
            DSP = new DataSet();
            DSPA = new DataSet();
            DSD = new DataSet();
            DSPAD = new DataSet();
            DA.SelectCommand = new SqlCommand();
            DA.SelectCommand.Connection = new SqlConnection(@"Data Source=127.0.0.1\SQL2008R2;Initial Catalog=CWM;Persist Security Info=True;User ID=CWM;Password=manager");
            DA.SelectCommand.CommandText = "select * from JOB where ID = " + Request["idj"];
            DA.Fill(DSJ, "J");
            /*string ch = DSJ.Tables[0].Rows[0]["PLUS_50"].ToString();
            if (DSJ.Tables[0].Rows[0]["PLUS_50"].ToString() == "True")
            {
                Plus_50 = true;
            }
            else
            {
                Plus_50 = false;
            }*/
            //Plus_50 = (DSJ.Tables[0].Rows[0]["PLUS_50"].ToString() == "true") ? true : false;
            //if (Plus_50 == null)
            //{
              //  Plus_50 = false;
            //}
            //Plus_50 = o;
            DA.SelectCommand.CommandText = "select * from PACKAGE where ( DELETED = 0 or DELETED is null ) and IDJOB = " + Request["idj"];
            DA.Fill(DSP, "P");
            DA.SelectCommand.CommandText = "select * from PACKAGE where DELETED = 1 and IDJOB = " + Request["idj"];
            DA.Fill(DSD, "D");
            /*DA.SelectCommand.CommandText = "select * from PACKAGEADDSERV where ( DELETED = 0 or DELETED is null ) and IDJOB = " + Request["idj"];
            DA.Fill(DSPA, "PA");
            DA.SelectCommand.CommandText = "select * from PACKAGEADDSERV where DELETED = 1 and IDJOB = " + Request["idj"];
            DA.Fill(DSPAD, "PAD");*/
            if (Session["delp"] != null)
                DeletedServices = Session["delp"] as List<int>;
            if (Session["delpa"] != null)
                DeletedServicesA = Session["delpa"] as List<int>;
            if (!Page.IsPostBack)
            {
                if ((int)DSJ.Tables[0].Rows[0]["TOTALCOST"] == 0)
                {
                    ddlSpecial.SelectedIndex = 1;
                }
                else
                {
                    ddlSpecial.SelectedIndex = 0;
                }

                DeletedServices = new List<int>();
                foreach (DataRow r in DSD.Tables["D"].Rows)
                {
                    DeletedServices.Add((int)r["IDPRICE"]);
                }
                Session.Add("delp", DeletedServices);

                DeletedServicesA = new List<int>();
                /*foreach (DataRow r in DSPAD.Tables["PAD"].Rows)
                {
                    DeletedServicesA.Add((int)r["IDADDSERV"]);
                }*/
                Session.Add("delpa", DeletedServicesA);
                
                tbPlate.Text = DSJ.Tables["J"].Rows[0]["NPLATE"].ToString();
                DA.SelectCommand.CommandText = "select ID,LNAME from CWM..LINE";
                DA.Fill(DS, "L");

                ddlLine.DataSource = DS.Tables["L"];
                ddlLine.DataTextField = "LNAME";
                ddlLine.DataValueField = "ID";
                ddlLine.DataBind();
                foreach (ListItem it in ddlLine.Items)
                {
                    if (it.Value == DSJ.Tables["J"].Rows[0]["LINE"].ToString())
                    {
                        it.Selected = true;
                        break;
                    }
                }
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
                foreach (ListItem it in ddlEmployees.Items)
                {
                    if (it.Value == DSJ.Tables["J"].Rows[0]["IDEMP"].ToString())
                    {
                        it.Selected = true;
                        break;
                    }
                }

                DA.SelectCommand.CommandText = "select ID,CNAME+': '+ANNOTATION as CNAME from CWM..CARCLASS";
                DS = new DataSet();
                DA.Fill(DS, "C");
                ddlClass.DataSource = DS.Tables["C"];
                ddlClass.DataTextField = "CNAME";
                ddlClass.DataValueField = "ID";
                ddlClass.DataBind();
                foreach (ListItem it in ddlClass.Items)
                {
                    if (it.Value == DSJ.Tables["J"].Rows[0]["IDCLASS"].ToString())
                    {
                        it.Selected = true;
                        break;
                    }
                }
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
                foreach (ListItem it in ddlCar.Items)
                {
                    if (it.Value == DSJ.Tables["J"].Rows[0]["IDCAR"].ToString())
                    {
                        it.Selected = true;
                        break;
                    }
                }
                DA.SelectCommand.CommandText = "select ID,PNAME from CWM..PRICELIST where IDCLASS = " + ddlClass.SelectedValue
                    + " order by PNAME";
                DS = new DataSet();
                DA.Fill(DS, "PRICE");
                chblPrice.DataSource = DS.Tables["PRICE"];
                chblPrice.DataTextField = "PNAME";
                chblPrice.DataValueField = "ID";
                chblPrice.DataBind();
                foreach (ListItem it in chblPrice.Items)
                {
                    foreach (DataRow r in DSP.Tables["P"].Rows)
                    {
                        if (it.Value == r["IDPRICE"].ToString())
                        {
                            it.Selected = true;
                        }
                    }
                }
                chblPrice.RepeatColumns = 2;

                /*DA.SelectCommand.CommandText = "select ID,ASNAME from CWM..ADDITIONALSERVICE order by ASNAME";
                DS = new DataSet();
                DA.Fill(DS, "ADDSERV");
                chblAddServ.DataSource = DS.Tables["ADDSERV"];
                chblAddServ.DataTextField = "ASNAME";
                chblAddServ.DataValueField = "ID";
                chblAddServ.DataBind();
                foreach (ListItem it in chblAddServ.Items)
                {
                    foreach (DataRow r in DSPA.Tables["PA"].Rows)
                    {
                        if (it.Value == r["IDADDSERV"].ToString())
                        {
                            it.Selected = true;
                        }
                    }
                }
                chblAddServ.RepeatColumns = 2;
                if (Plus_50 == true)
                {
                    chbPlus_50.Checked = true;
                }
                else
                {
                    chbPlus_50.Checked = false;
                }*/
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
            try
            {
                lError.Text = "";
                if (tbPlate.Text == "")
                {
                    lError.Text = "Введите государственный номер автомобиля!";
                    return;
                }
                if ((chbManual.Checked) && (tbCar.Text == ""))
                {
                    lError.Text = "Введите название автомобиля!";
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
                    return;
                }
                int y = ddlEmployees.SelectedIndex;
                if (y == -1)
                {
                    lError.Text = "Добавьте сотрудников в базу!";
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
                //MarkIDPRICEAsDeleted();
                int cntprice = DSP.Tables["P"].Rows.Count;
                DA.SelectCommand.CommandText = "select * from JOB where ID = " + Request["idj"];
                DA.Fill(DSJ, "J");
                J.IDEMP = int.Parse(ddlEmployees.SelectedValue);
                J.JOBDATE = (DateTime)DSJ.Tables["J"].Rows[0]["JOBDATE"];
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
                    int IDJOB = int.Parse(Request["idj"].ToString());
                    JOB delj = (from jj in cwm.JOB
                                where jj.ID == IDJOB
                                select jj).First();
                    cwm.DeleteObject(delj);

                    var delpack = from pp in cwm.PACKAGE
                                  where pp.IDJOB == IDJOB
                                  select pp;
                    foreach (PACKAGE pack in delpack)
                    {
                        cwm.DeleteObject(pack);
                    }
                    cwm.AddToJOB(J);
                    cwm.SaveChanges();
                    AddNewPackage(J.ID);
                   // AddNewAddPackage(J.ID);
                }
            }
            catch (Exception ex)
            {
                lError.Text = "Ошибка при редактировании задания! Попробуйте обновить страницу и попробовать еще раз. " + ex.Message ;
                return;
            }
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, GetType(), "success", @"alert('Работа успешно отредактирована!');location = ""Default.aspx""", true);
            //Response.Redirect(@"~\default.aspx");
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
                DeletedServices = Session["delp"] as List<int>;
                foreach (int i in DeletedServices)
                {
                    p = new PACKAGE();
                    p.IDJOB = idjob;
                    p.IDPRICE = int.Parse(i.ToString());
                    if (ddlSpecial.Text == "НЕТ")
                    {
                        p.COST = GetCost(i.ToString());
                    }
                    else
                    {
                        p.COST = 0;
                    }

                    p.DELETED = true;
                    cwm.AddToPACKAGE(p);
                }
                cwm.SaveChanges();
            }
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
        //                PAS.IDJOB = idjob;
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
        //        DeletedServicesA = Session["delpa"] as List<int>;
        //        foreach (int i in DeletedServicesA)
        //        {
        //            PAS = new PACKAGEADDSERV();
        //            PAS.IDJOB = idjob;
        //            PAS.IDADDSERV = int.Parse(i.ToString());
        //            if (ddlSpecial.Text == "НЕТ")
        //            {
        //                PAS.COST = GetCostAddServ(i.ToString());
        //            }
        //            else
        //            {
        //                PAS.COST = 0;
        //            }

        //            PAS.DELETED = true;
        //            cwm.AddToPACKAGEADDSERV(PAS);
        //        }
        //        cwm.SaveChanges();
        //    }
        //}
        protected void chblPrice_SelectedIndexChanged(object sender, EventArgs e)
        {

            string value = string.Empty;
            string result = Request.Form["__EVENTTARGET"];//тот, кто вызвал postback
            string[] checkedBox = result.Split('$'); ;

            int index = int.Parse(checkedBox[checkedBox.Length - 1]);

            value = chblPrice.Items[index].Value;

            List<int> toDelete = new List<int>();
            if (chblPrice.Items[index].Selected)
                toDelete.Add(int.Parse(value));
            foreach (DataRow r in DSP.Tables["P"].Rows)
            {
                
                if (value == r["IDPRICE"].ToString()) 
                {
                    if (!(Session["delp"] as List<int>).Contains(int.Parse(value)))
                        (Session["delp"] as List<int>).Add(int.Parse(value));
                    foreach (int i in (Session["delp"] as List<int>))
                    {
                        foreach (ListItem li in chblPrice.Items)
                        {
                            if ((li.Selected) && (li.Value == i.ToString()))
                            {
                                //(Session["delp"] as List<int>).Remove(i);
                                toDelete.Add(i);
                            }
                        }
                    }
                    break;
                }
            }
            foreach (int i in toDelete)
            {
                if ((Session["delp"] as List<int>).Contains(i))
                {
                    (Session["delp"] as List<int>).Remove(i);
                }
            }
        }
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




        private int AddNewCar(string cname, int cclass)
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

        public void OnConfirm(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue.LastIndexOf(',') > 0)
            {
                confirmValue = confirmValue.Substring(confirmValue.LastIndexOf(',')+1);
            }
            if (confirmValue == "Yes")
            {
                using (CWMEntities cwm = new CWMEntities(EnCon))
                {
                    int IDJOB = int.Parse(Request["idj"].ToString());
                    JOB delj = (from jj in cwm.JOB
                                where jj.ID == IDJOB
                                select jj).First();
                    cwm.DeleteObject(delj);

                    var delpack = from pp in cwm.PACKAGE
                                  where pp.IDJOB == IDJOB
                                  select pp;
                    foreach (PACKAGE pack in delpack)
                    {
                        cwm.DeleteObject(pack);
                    }

                    //var delpackadd = from pp in cwm.PACKAGEADDSERV
                    //              where pp.IDJOB == IDJOB
                    //              select pp;
                    //foreach (PACKAGEADDSERV pack in delpackadd)
                    //{
                    //    cwm.DeleteObject(pack);
                    //}

                    cwm.SaveChanges();
                }
                //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Работа успешно удалена!')", true);
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, GetType(), "success", @"alert('Работа успешно удалена!');location = ""Default.aspx""", true);

            }
            else
            {
                //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked NO!')", true);
            }
        }

        protected void chblAddServ_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = string.Empty;
            string result = Request.Form["__EVENTTARGET"];//тот, кто вызвал postback
            string[] checkedBox = result.Split('$'); ;

            int index = int.Parse(checkedBox[checkedBox.Length - 1]);

            value = chblAddServ.Items[index].Value;

            List<int> toDelete = new List<int>();
            if (chblAddServ.Items[index].Selected)
                toDelete.Add(int.Parse(value));
            foreach (DataRow r in DSPA.Tables["PA"].Rows)
            {

                if (value == r["IDADDSERV"].ToString())
                {
                    if (!(Session["delpa"] as List<int>).Contains(int.Parse(value)))
                        (Session["delpa"] as List<int>).Add(int.Parse(value));
                    foreach (int i in (Session["delpa"] as List<int>))
                    {
                        foreach (ListItem li in chblAddServ.Items)
                        {
                            if ((li.Selected) && (li.Value == i.ToString()))
                            {
                                //(Session["delp"] as List<int>).Remove(i);
                                toDelete.Add(i);
                            }
                        }
                    }
                    break;
                }
            }
            foreach (int i in toDelete)
            {
                if ((Session["delpa"] as List<int>).Contains(i))
                {
                    (Session["delpa"] as List<int>).Remove(i);
                }
            }
        }

    }
}
