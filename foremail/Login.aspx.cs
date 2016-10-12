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
            SqlDataAdapter DA = new SqlDataAdapter();
            DA.SelectCommand = new SqlCommand();
            DA.SelectCommand.Connection = new SqlConnection(@"Data Source=127.0.0.1\SQL2008R2;Initial Catalog=CWM;Persist Security Info=True;User ID=CWM;Password=manager");
            DA.SelectCommand.CommandText = "select * from PASSWORD where LOGIN = '" + Login1.UserName.ToLower() + "' and lower(ADMINPASS) = '" + Login1.Password.ToLower() + "'";

            DataSet usr = new DataSet();
            int i = DA.Fill(usr);

            if (i > 0)
            {
                //string ID = usr.Tables[0].Rows[0]["ID"].ToString();
                FormsAuthentication.RedirectFromLoginPage(Login1.UserName, false);
                Response.Redirect("adminpage.aspx");

            }
        }
    }
}
