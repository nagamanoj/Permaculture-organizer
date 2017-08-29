using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Web.Services;

namespace PermacultureOrganizer.Account
{
    public partial class OrchardMain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Call stored procedure to get Orchard Type Name and ID
                ddlOrchardType.DataSource = GetOrchardData("spGetOrchardType", null);
                ddlOrchardType.DataBind();

                //Assign default values for Drop Down List
                ListItem liOrchardType = new ListItem("Select Orchard Type", "-1");
                ddlOrchardType.Items.Insert(0, liOrchardType);

                ListItem liSpecies = new ListItem("Select Species", "-1");
                ddlSpecies.Items.Insert(0, liSpecies);

                ListItem liVariety = new ListItem("Select Variety", "-1");
                ddlVariety.Items.Insert(0, liVariety);

                //Make most fields disabled or invisible at page load
                ddlSpecies.Enabled = false;
                ddlVariety.Enabled = false;
                lblAge.Visible = false;
                lblYields.Visible = false;
                lblPlantedDate.Visible = false;
                lblPlantedFrom.Visible = false;
                txtBoxAge.Visible = false;
                txtBoxYields.Visible = false;
                txtBoxPlantedDate.Visible = false;
                txtBoxPlantedFrom.Visible = false;
                txtBoxAge.Text = "";
                txtBoxYields.Text = "";
                txtBoxPlantedDate.Text = "";
                txtBoxPlantedFrom.Text = "";
                btnOrchardSubmit.Visible = false;
                grdOrchardView.Visible = false;
            }
        }

        private DataSet GetOrchardData(string SPName, SqlParameter SPParameter)
        {
            //Make a connection to the SQL database
            string CS = ConfigurationManager.ConnectionStrings["sqlCon"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);
            SqlDataAdapter sda = new SqlDataAdapter(SPName, con);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (SPParameter != null)
            {
                sda.SelectCommand.Parameters.Add(SPParameter);
            }

            DataSet DS = new DataSet();
            sda.Fill(DS);

            return DS;
        }

        protected void ddlOrchardType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //When default value is selected, disable or make invisible the different fields
            if (ddlOrchardType.SelectedIndex == 0)
            {
                ddlSpecies.SelectedIndex = 0;
                ddlSpecies.Enabled = false;
                ddlVariety.SelectedIndex = 0;
                ddlVariety.Enabled = false;
                lblAge.Visible = false;
                lblYields.Visible = false;
                lblPlantedDate.Visible = false;
                lblPlantedFrom.Visible = false;
                txtBoxAge.Visible = false;
                txtBoxYields.Visible = false;
                txtBoxPlantedDate.Visible = false;
                txtBoxPlantedFrom.Visible = false;
                txtBoxAge.Text = "";
                txtBoxYields.Text = "";
                txtBoxPlantedDate.Text = "";
                txtBoxPlantedFrom.Text = "";
                grdOrchardView.Visible = false;
            }
            //Otherwise, once the item is selected, display the next Drop Down List
            else
            {
                ddlSpecies.Enabled = true;
                SqlParameter parameter = new SqlParameter("@OrchardTypeID", ddlOrchardType.SelectedValue);
                DataSet DS = GetOrchardData("spGetSpeciesByID", parameter);

                ddlSpecies.DataSource = DS;
                ddlSpecies.DataBind();

                ListItem liSpecies = new ListItem("Select Species", "-1");
                ddlSpecies.Items.Insert(0, liSpecies);

                ddlVariety.SelectedIndex = 0;
                ddlVariety.Enabled = false;
            }
        }

        protected void ddlSpecies_SelectedIndexChanged(object sender, EventArgs e)
        {
            //When default value is selected, disable or make invisible the different fields
            if (ddlSpecies.SelectedIndex == 0)
            {
                ddlVariety.SelectedIndex = 0;
                ddlVariety.Enabled = false;
                lblAge.Visible = false;
                lblYields.Visible = false;
                lblPlantedDate.Visible = false;
                lblPlantedFrom.Visible = false;
                txtBoxAge.Visible = false;
                txtBoxYields.Visible = false;
                txtBoxPlantedDate.Visible = false;
                txtBoxPlantedFrom.Visible = false;
                txtBoxAge.Text = "";
                txtBoxYields.Text = "";
                txtBoxPlantedDate.Text = "";
                txtBoxPlantedFrom.Text = "";
                grdOrchardView.Visible = false;
            }
            //Otherwise, once the item is selected, display the next Drop Down List
            else
            {
                ddlVariety.Enabled = true;
                SqlParameter parameter = new SqlParameter("@OrchardItemID", ddlSpecies.SelectedValue);
                DataSet DS = GetOrchardData("spGetVarietyByID", parameter);

                ddlVariety.DataSource = DS;
                ddlVariety.DataBind();

                ListItem liVariety = new ListItem("Select Variety", "-1");
                ddlVariety.Items.Insert(0, liVariety);
            } 
        }

        protected void ddlVariety_SelectedIndexChanged(object sender, EventArgs e)
        {
            //When default value is selected, disable or make invisible the different fields
            if (ddlVariety.SelectedIndex == 0)
            {
                lblAge.Visible = false;
                lblYields.Visible = false;
                lblPlantedDate.Visible = false;
                lblPlantedFrom.Visible = false;
                txtBoxAge.Visible = false;
                txtBoxYields.Visible = false;
                txtBoxPlantedDate.Visible = false;
                txtBoxPlantedFrom.Visible = false;
                txtBoxAge.Text = "";
                txtBoxYields.Text = "";
                txtBoxPlantedDate.Text = "";
                txtBoxPlantedFrom.Text = "";
                grdOrchardView.Visible = false;

            }
            //Otherwise, make the rest of the fields visible.
            else
            {
                lblAge.Visible = true;
                lblYields.Visible = true;
                lblPlantedDate.Visible = true;
                lblPlantedFrom.Visible = true;
                txtBoxAge.Visible = true;
                txtBoxYields.Visible = true;
                txtBoxPlantedDate.Visible = true;
                txtBoxPlantedFrom.Visible = true;
                btnOrchardSubmit.Visible = true;
            }
        }

        protected void btnOrchardSubmit_Click(object sender, EventArgs e)
        {
            //Make a connection to the SQL database
            string CS = ConfigurationManager.ConnectionStrings["sqlCon"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);
            {
                //Declare variables to collect data
                string age = txtBoxAge.Text;
                string yields = txtBoxYields.Text;
                string plantDate = txtBoxPlantedDate.Text;
                string plantFrom = txtBoxPlantedFrom.Text;

                //Declare Sql Command to Insert Into the Orchard database
                SqlCommand usercom = new SqlCommand("INSERT INTO tblUserOrchard(OTypeName, OSpecies, OVariety, OAge, OYields, OPlantDate, OPlantFrom) VALUES(@OTypeName, @OSpecies, @OVariety, @OAge, @OYields, @OPlantDate, @OPlantFrom)", con);
                usercom.Parameters.AddWithValue("@OTypeName", ddlOrchardType.SelectedItem.Text);
                usercom.Parameters.AddWithValue("@OSpecies", ddlSpecies.SelectedItem.Text);
                usercom.Parameters.AddWithValue("@OVariety", ddlVariety.SelectedItem.Text);
                usercom.Parameters.AddWithValue("@OAge", age);
                usercom.Parameters.AddWithValue("@OYields", yields);
                usercom.Parameters.AddWithValue("@OPlantDate", plantDate);
                usercom.Parameters.AddWithValue("@OPlantFrom", plantFrom);

                con.Open();
                usercom.ExecuteNonQuery();
                con.Close();

                //If data was sent to the database, display a message
                if (Page.IsPostBack == true)
                {
                    lblSubmit.Text = ("Your data has been successfully submitted to SQL");
                }
            }
        }

        protected void btnViewData_Click(object sender, EventArgs e)
        {
            //View the data from the database
            grdOrchardView.Visible = true;
        }
    }
}