using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Permaculture_Garden_Planning.Webpages
{
    public partial class Permaculture_Login : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=SQL5018.SmarterASP.net;Initial Catalog=DB_9DE518_Permaculture;User ID=DB_9DE518_Permaculture_admin;Password=4theFuture;MultipleActiveResultSets=True;Application Name=EntityFramework");
        SqlCommand cmd;
        SqlDataReader dr;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                List<String[]> personsList = new List<String[]>();
                con.Open();
                cmd = new SqlCommand("Select UserName,Pswd from tblPerson where UserName='"+UserName.Text+"'", con);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    if (Password.Text == dr.GetString(1))
                    {
                        Server.Transfer("Permaculture_Home.aspx", true);
                        
                    }
                    else
                    {
                        Label1.Text = "Invalid User Name and Password";
                    }

                }
                else
                {
                    Label1.Text = "Invalid User Name and Password";
                }
                
            }catch(SqlException ex)
            {
                
            }
        }
    }
}