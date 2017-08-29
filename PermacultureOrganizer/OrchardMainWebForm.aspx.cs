using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Configuration;

namespace PermacultureOrganizer
{
    public partial class OrchardMainWebForm : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=SQL5018.SmarterASP.net;Initial Catalog=DB_9DE518_Permaculture;Persist Security Info=True;User ID=DB_9DE518_Permaculture_admin;Password=4theFuture");

        public void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LinkButton lbInsert = new LinkButton();
                lbInsert.Click += new EventHandler(lbInsert_Click);

                DropDownList ddlTypeName = new DropDownList();
                ddlTypeName.SelectedIndexChanged += new EventHandler(ddlTypeName_SelectedIndexChanged);

                DropDownList ddlSpecies = new DropDownList();
                ddlSpecies.SelectedIndexChanged += new EventHandler(ddlSpecies_SelectedIndexChanged);

                DropDownList ddlVariety = new DropDownList();
                ddlVariety.SelectedIndexChanged += new EventHandler(ddlVariety_SelectedIndexChanged);

            }
        }

        public void lbInsert_Click(object sender, EventArgs e)
        {
            dsOrchardDatabase.InsertParameters["OTypeName"].DefaultValue = 
                ((DropDownList)gvOrchardData.FooterRow.FindControl("ddlTypeName")).SelectedItem.ToString();
            dsOrchardDatabase.InsertParameters["OSpecies"].DefaultValue =
                ((DropDownList)gvOrchardData.FooterRow.FindControl("ddlSpecies")).SelectedItem.ToString();
            dsOrchardDatabase.InsertParameters["OVariety"].DefaultValue =
                ((DropDownList)gvOrchardData.FooterRow.FindControl("ddlVariety")).SelectedItem.ToString();
            dsOrchardDatabase.InsertParameters["OAge"].DefaultValue =
                ((TextBox)gvOrchardData.FooterRow.FindControl("txtBxAge")).Text;
            dsOrchardDatabase.InsertParameters["OYields"].DefaultValue =
                ((TextBox)gvOrchardData.FooterRow.FindControl("txtBxYields")).Text;
            dsOrchardDatabase.InsertParameters["OPlantDate"].DefaultValue =
                ((TextBox)gvOrchardData.FooterRow.FindControl("txtBxPlantDate")).Text;
            dsOrchardDatabase.InsertParameters["OPlantFrom"].DefaultValue =
                ((TextBox)gvOrchardData.FooterRow.FindControl("txtBxPlantFrom")).Text;
            dsOrchardDatabase.InsertParameters["OTreeSpacing"].DefaultValue =
                ((Label)gvOrchardData.FooterRow.FindControl("lblTreeSpacing")).Text;
            dsOrchardDatabase.InsertParameters["OFertilizingTimes"].DefaultValue =
                ((Label)gvOrchardData.FooterRow.FindControl("lblFertilizingTimes")).Text;
            dsOrchardDatabase.InsertParameters["OWateringNeeds"].DefaultValue =
                ((Label)gvOrchardData.FooterRow.FindControl("lblWateringNeeds")).Text;
            dsOrchardDatabase.InsertParameters["OPollination"].DefaultValue =
                ((Label)gvOrchardData.FooterRow.FindControl("lblPollination")).Text;
            dsOrchardDatabase.InsertParameters["OFertilizer"].DefaultValue =
                ((Label)gvOrchardData.FooterRow.FindControl("lblFertilizer")).Text;
            dsOrchardDatabase.InsertParameters["OPesticide"].DefaultValue =
                ((Label)gvOrchardData.FooterRow.FindControl("lblPesticide")).Text;

            dsOrchardDatabase.Insert();
        }

        protected void gvOrchardData_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gvOrchardData_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlTypeName_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gvr = (GridViewRow)((DropDownList)sender).NamingContainer;
            DropDownList ddlTypeName = (DropDownList)gvr.FindControl("ddlTypeName");
            DropDownList ddlSpecies = (DropDownList)gvr.FindControl("ddlSpecies");

            ddlSpecies.DataTextField = "Species";
            ddlSpecies.DataValueField = "OrchardItemID";
            ddlSpecies.DataSource = RetrieveSpecies(ddlTypeName.SelectedValue);
            ddlSpecies.DataBind();
            ddlSpecies.Items.Insert(0, "Select Species");
        }

        private DataTable RetrieveSpecies(string OrchardTypeID)
        {
            string connString = ConfigurationManager.ConnectionStrings["PermaCultureConnection"].ConnectionString;
            string sql = @"SELECT OrchardItemID, Species FROM tblOrchardItem WHERE OrchardTypeID = " + OrchardTypeID;
            DataTable dtSpecies = new DataTable();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                //Initialize command object
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    //Fill the result set
                    adapter.Fill(dtSpecies);
                }
            }

            return dtSpecies;
        }

        protected void ddlSpecies_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gvr = (GridViewRow)((DropDownList)sender).NamingContainer;
            DropDownList ddlSpecies = (DropDownList)gvr.FindControl("ddlSpecies");
            DropDownList ddlVariety = (DropDownList)gvr.FindControl("ddlVariety");

            ddlVariety.DataTextField = "Variety";
            ddlVariety.DataValueField = "OrchardItemID";
            ddlVariety.DataSource = RetrieveVariety(ddlSpecies.SelectedValue);
            ddlVariety.DataBind();
            ddlVariety.Items.Insert(0, "Select Variety");
        }

        private DataTable RetrieveVariety(string OrchardItemID)
        {
            string connString = ConfigurationManager.ConnectionStrings["PermaCultureConnection"].ConnectionString;
            string sql = @"SELECT OrchardItemID, Variety FROM tblOrchardItem WHERE OrchardItemID = " + OrchardItemID;
            DataTable dtVariety = new DataTable();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                //Initialize command object
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    //Fill the result set
                    adapter.Fill(dtVariety);
                }
            }
            return dtVariety;
        }

        protected void ddlVariety_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gvr = (GridViewRow)((DropDownList)sender).NamingContainer;
            DropDownList ddlVariety = (DropDownList)gvr.FindControl("ddlVariety");
            int OrchardItemID = Convert.ToInt32(ddlVariety.SelectedIndex);
            BindOrchardGrid(OrchardItemID);
        }

        private void BindOrchardGrid(int OrchardItemID)
        {
            DataTable dtLabels = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand("SELECT * FROM tblOrchardItem WHERE OrchardItemID = " + OrchardItemID, con);
            sda.SelectCommand = cmd;
            sda.Fill(dtLabels);

            if (dtLabels.Rows.Count > 0)
            {
                //gvOrchardData.DataSource = dtLabels;
                //lblTreeSpacing.Text = dtLabels.Rows[0]["TreeSpacing"].ToString();
                //gvOrchardData.DataBind();
            }
        }

        protected void ddlVariety_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}