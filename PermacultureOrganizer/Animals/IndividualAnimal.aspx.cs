using PermacultureOrganizer.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PermacultureOrganizer.Animals
{
    public partial class IndividualAnimal : System.Web.UI.Page
    {
        AnimalDAL animalDAL = new AnimalDAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            int individualAnimalID = Convert.ToInt32(Request.QueryString["IndividualAnimalID"]);

            if(IsPostBack)
            {

            }
            else
            {
                DataTable IndividualAnimal = animalDAL.GetIndividualAnimal(individualAnimalID);

                IndividualAnimalName.Text = IndividualAnimal.Rows[0]["Name"].ToString();

                //added by ocllo
                rbAdditionalData.SelectedIndex = 0;
                lbAdditionalData.Items.Clear();
                int ObjectID = individualAnimalID;
                string ObjectName = "IndividualAnimal";
                string Category = rbAdditionalData.SelectedItem.Value;
                lbAdditionalData.DataSource = animalDAL.GetSpecificAdditionalData(ObjectID, ObjectName, Category);
                lbAdditionalData.DataTextField = "Description";
                lbAdditionalData.DataValueField = "DataID";
                lbAdditionalData.DataBind();
                lbAdditionalData.Visible = true;
            }
        }

        //added by ocllo
        protected void rbAdditionalData_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbAdditionalData.Items.Clear();
            string Category = "";
            if (rbAdditionalData.SelectedItem.Text.Equals("Notes"))
            {
                Category = "Note";
            }
            else if (rbAdditionalData.SelectedItem.Text.Equals("Events"))
            {
                Category = "Event";
            }

            else if (rbAdditionalData.SelectedItem.Text.Equals("Web Resources"))
            {
                Category = "Web";
            }
            int ObjectID = Convert.ToInt32(Request.QueryString["IndividualAnimalID"]);
            string ObjectName = "IndividualAnimal";

            lbAdditionalData.DataSource = animalDAL.GetSpecificAdditionalData(ObjectID, ObjectName, Category);
            lbAdditionalData.DataTextField = "Description";
            lbAdditionalData.DataValueField = "DataID";
            lbAdditionalData.DataBind();
            lbAdditionalData.Visible = true;
        }

        // sravan
        protected void DeleteAnimal(object sender, EventArgs e)
        {

            animalDAL.DeleteAnimalInfo(Convert.ToInt32(IndividualAnimalID.Value));

            // animalDAL.DeleteAnimalInfo(Convert.ToInt32(lbAdditionalData.SelectedValue));
        }
    }
}