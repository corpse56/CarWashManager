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
    public partial class AddJobStep2 : System.Web.UI.Page
    {
        SqlDataAdapter DA;
        DataSet DS;
        string EnCon = @"metadata=res://*/CWMModel.csdl|res://*/CWMModel.ssdl|res://*/CWMModel.msl;provider=System.Data.SqlClient;provider connection string=""Data Source=127.0.0.1;Initial Catalog=CWM;Persist Security Info=True;User ID=CWM;Password=manager""";
        protected void Page_Load(object sender, EventArgs e)
        {
            bAdd.Attributes.Add("onclick", " this.disabled = true; " + ClientScript.GetPostBackEventReference(bAdd, null) + ";");
            //tbCar.Attributes["onclick"] = "chbManual.Checeked = !chbManual.Checeked";
            string tmp = ClientScript.GetPostBackEventReference(bAdd, null); 
            ScriptManager1.RegisterAsyncPostBackControl(bAdd);
            DA = new SqlDataAdapter();
            DS = new DataSet();
            DA.SelectCommand = new SqlCommand();
            DA.SelectCommand.Connection = new SqlConnection("Data Source=127.0.0.1;Initial Catalog=CWM;Persist Security Info=True;User ID=CWM;Password=manager");
            if (!Page.IsPostBack)
            {
                JOB job = (JOB)Session["JOB"];
                DA.SelectCommand.CommandText = "select ID,PNAME from CWM..PRICELIST where IDCLASS = " + job.IDCLASS
                    + " order by PNAME";
                DS = new DataSet();
                DA.Fill(DS, "PRICE");
                chblPrice.DataSource = DS.Tables["PRICE"];
                chblPrice.DataTextField = "PNAME";
                chblPrice.DataValueField = "ID";
                chblPrice.DataBind();
                chblPrice.RepeatColumns = 2;

            }
        }


  

        protected void bAdd_Click(object sender, EventArgs e)
        {
            JOB SessionJob = (JOB)Session["JOB"];
            try
            {
                int special = (int)Session["special"];
                if (special == 0)
                {
                    SessionJob.TOTALCOST = GetTotalCost();
                }
                else
                {
                    SessionJob.TOTALCOST = 0;
                }
                /*if (chbPlus_50.Checked)
                {
                    J.PLUS_50 = true;
                }*/
                using (CWMEntities cwm = new CWMEntities(EnCon))
                {
                    cwm.AddToJOB(SessionJob);
                    cwm.SaveChanges();
                    AddNewPackage(SessionJob.ID);
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
                        if ((int)Session["special"] == 0)
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
