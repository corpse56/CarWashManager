using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Security;

namespace CarWashManager
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            //SqlDataAdapter DA = new SqlDataAdapter();
            //DA.SelectCommand = new SqlCommand();
            //DA.SelectCommand.Connection = new SqlConnection("Data Source=127.0.0.1;Initial Catalog=CWM;Persist Security Info=True;User ID=CWM;Password=manager");
            ////DA.SelectCommand.CommandText = "select * from PASSWORD where LOGIN = '" + Login1.UserName.ToLower() + "' and lower(ADMINPASS) = '" + Login1.Password.ToLower() + "'";
            //DA.SelectCommand.Parameters.Add("pwd", SqlDbType.NVarChar).Value = TextBox1.Text.ToLower() ;
            //DA.SelectCommand.CommandText = "select * from PASSWORD where lower(ADMINPASS) = @pwd";

            //DataSet usr = new DataSet();
            //int i = DA.Fill(usr);

            //if (i > 0)
            //{
            //    //string ID = usr.Tables[0].Rows[0]["ID"].ToString();
            //    FormsAuthentication.RedirectFromLoginPage(Login1.UserName, false);
            //    if (Request["ReturnURL"] != null)
            //    {
            //        string url = Request["ReturnURL"];
            //        Response.Redirect(url);
            //    }
            //    else
            //    {
            //        Response.Redirect("adminpage.aspx");
            //    }

            //}
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter DA = new SqlDataAdapter();
            DA.SelectCommand = new SqlCommand();
            DA.SelectCommand.Connection = new SqlConnection("Data Source=127.0.0.1;Initial Catalog=CWM;Persist Security Info=True;User ID=CWM;Password=manager");
            //DA.SelectCommand.CommandText = "select * from PASSWORD where LOGIN = '" + Login1.UserName.ToLower() + "' and lower(ADMINPASS) = '" + Login1.Password.ToLower() + "'";
            DA.SelectCommand.Parameters.Add("pwd", SqlDbType.NVarChar).Value = TextBox1.Text.ToLower();
            DA.SelectCommand.CommandText = "select * from PASSWORD where lower(ADMINPASS) = @pwd";

            DataSet usr = new DataSet();
            int i = DA.Fill(usr);

            if (i > 0)
            {
                //string ID = usr.Tables[0].Rows[0]["ID"].ToString();
                //FormsAuthentication.RedirectFromLoginPage(Login1.UserName, false);
                FormsAuthentication.RedirectFromLoginPage("myUser", false); 
                if (Request["ReturnURL"] != null)
                {
                    string url = Request["ReturnURL"];
                    Response.Redirect(url);
                }
                else
                {
                    Response.Redirect("adminpage.aspx");
                }

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "success", "alert('Пароль неверный!');", true);

                
            }
        }
    }
}
