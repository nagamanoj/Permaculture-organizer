using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Permaculture_Garden_Planning.Webpages
{
    public partial class Permaculture_SignUp : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=SQL5018.SmarterASP.net;Initial Catalog=DB_9DE518_Permaculture;User ID=DB_9DE518_Permaculture_admin;Password=4theFuture;MultipleActiveResultSets=True;Application Name=EntityFramework");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String txtFirstName = FirstName.Text;
            String txtLastName = LastName.Text;
            String txtUserName = UserName.Text;
            String txtPwd = Pswd.Text;
            String txtPhone = Telephone.Text;
            String txtAddress = PersonAddress.Text;
            String txtEmail = Email.Text;

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO tblPerson VALUES('" + txtFirstName + "','" + txtLastName + "','" + txtUserName + "','" + txtPwd + "','" + txtPhone + "','" + txtAddress + "','" + txtEmail + "',NULL,NULL,NULL)", con);
                cmd.ExecuteNonQuery();
                con.Close();
                Label1.Text = "Registration is successful";

            }catch(SqlException ex)
            {

            }

        }

        

      
    }
}