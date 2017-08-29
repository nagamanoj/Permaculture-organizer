using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Permaculture_Garden_Planning.Webpages
{
    public partial class Garden_Plan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ddlMonths.DataSource = GetData("spGetMonths", null);
               ddlMonths.DataBind();
               ddlGardens.DataSource = GetData("spGetGarden", null);
               ddlGardens.DataBind();

               ListItem liMonths = new ListItem("Select Month", "-1");
               ddlMonths.Items.Insert(0, liMonths);

               ListItem liGarden = new ListItem("Select Garden", "-1");
               ddlGardens.Items.Insert(0, liGarden);

               ListItem liVegetable = new ListItem("Select Vegetable", "-1");
               ddlVegetables.Items.Insert(0, liVegetable);

               ddlGardens.Enabled = false;
               ddlVegetables.Enabled = false;



            }

        }

        private DataSet GetData(string SPName, SqlParameter SPParameter)
        {
            string cs = ConfigurationManager.ConnectionStrings["PermaCultureConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            SqlDataAdapter da = new SqlDataAdapter(SPName, con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if(SPParameter!=null)
            {
                da.SelectCommand.Parameters.Add(SPParameter);
            }
                DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        protected void ddlMonths_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlMonths.SelectedIndex ==0)
            {
                ddlVegetables.SelectedIndex = 0;
                ddlVegetables.Enabled = false;
            }
            else
            {
                ddlGardens.Enabled = true;
                ddlVegetables.Enabled = true;
                SqlParameter parameter = new SqlParameter("@MonthID", ddlMonths.SelectedValue);
                DataSet ds = GetData("spGetVegetableByMonthID", parameter);
                ddlVegetables.DataSource = ds;
                ddlVegetables.DataBind();
                ListItem liVegetable = new ListItem("Select Vegetable", "-1");
                ddlVegetables.Items.Insert(0, liVegetable);

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["PermaCultureConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            SqlCommand xp = new SqlCommand("Insert into tbl_planting_plan(planting_date,plan_garden,vegetable_id) Values('2016-03-20',@plan_garden,@vegetable_id )", con);
            //xp.Parameters.AddWithValue("@Planting_date", ddlMonths.SelectedItem);
            xp.Parameters.AddWithValue("@plan_garden", ddlGardens.SelectedValue);
            xp.Parameters.AddWithValue("@vegetable_id", ddlVegetables.SelectedValue);
            con.Open();
            xp.ExecuteNonQuery();
            con.Close(); 
        }
    }
}