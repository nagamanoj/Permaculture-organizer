using PermacultureOrganizer.DAL;
using PermacultureOrganizer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PermacultureOrganizer.Animals
{
    public partial class Breeds : System.Web.UI.Page
    {
        AnimalDAL animalDAL = new AnimalDAL();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            int livestockid = Convert.ToInt32(Request.QueryString["LiveStockID"]);
            int breedid;
            if (Request.QueryString["BreedID"] != null)
            {
                breedid = Convert.ToInt32(Request.QueryString["BreedID"]);
            }
            else
            {
                breedid = 0;
            }

            if (breedid > 0)
            {
                SetControls(breedid);
            }

            if (IsPostBack)
            {

            }
            else
            {
                hfLiveStockID.Value = livestockid.ToString();

                GetBreed(livestockid);

                //added by ocllo
                rbAdditionalData.SelectedIndex = 0;
                lbAdditionalData.Items.Clear();
                int ObjectID = breedid;
                string ObjectName = "Breeds";
                string Category = rbAdditionalData.SelectedItem.Value;
                lbAdditionalData.DataSource = animalDAL.GetSpecificAdditionalData(ObjectID, ObjectName, Category);
                lbAdditionalData.DataTextField = "Description";
                lbAdditionalData.DataValueField = "DataID";
                lbAdditionalData.DataBind();
                lbAdditionalData.Visible = true;
                //
            }
        }

        /// <summary>
        /// Gets the breeds for the breed listbox
        /// </summary>
        protected void GetBreed(int livestockID)
        {
            //Bind the breeds to listbox
            var dtBreeds = animalDAL.GetBreedsForLiveStockID(livestockID);
            lbBreeds.DataSource = dtBreeds;
            lbBreeds.DataTextField = "Name";
            lbBreeds.DataValueField = "BreedID";
            lbBreeds.SelectedValue = dtBreeds.Rows[0]["BreedID"].ToString();
            lbBreeds.AutoPostBack = true;
            lbBreeds.DataBind();

            lblLiveStockBreed.Text = "Breeds of " + dtBreeds.Rows[0]["Description"].ToString();
        }

        /// <summary>
        /// Sets up other controls for selected breed
        /// </summary>
        /// <param name="breedID"></param>
        protected void SetControls(int breedID)
        {
            lbIndividualAnimal.DataSource = animalDAL.GetIndividualAnimalsForBreedID(breedID);
            lbIndividualAnimal.DataTextField = "Name";
            lbIndividualAnimal.DataValueField = "IndividualAnimalID";
            lbIndividualAnimal.DataBind();
            lbIndividualAnimal.Visible = true;

            var BreedInfo = animalDAL.GetBreedInfoByID(breedID);

            txtBreedName.Text = BreedInfo.Rows[0]["Name"].ToString();
            txtBreedCount.Text = BreedInfo.Rows[0]["Count"].ToString();
            hfBreedID.Value = BreedInfo.Rows[0]["BreedID"].ToString();

            lblBreedsCount.Text = BreedInfo.Rows[0]["Count"].ToString();
        }

        protected void lbBreeds_SelectedIndexChanged(object sender, EventArgs e)
        {
            int breedID = Convert.ToInt32(((ListBox)sender).SelectedValue);

            var BreedInfo = animalDAL.GetBreedInfoByID(breedID);

            txtBreedName.Text = BreedInfo.Rows[0]["Name"].ToString();
            txtBreedCount.Text = BreedInfo.Rows[0]["Count"].ToString();
            hfBreedID.Value = BreedInfo.Rows[0]["BreedID"].ToString();

            lblBreedsCount.Text = BreedInfo.Rows[0]["Count"].ToString();

            lbIndividualAnimal.DataSource = animalDAL.GetIndividualAnimalsForBreedID(breedID);
            lbIndividualAnimal.DataTextField = "Name";
            lbIndividualAnimal.DataValueField = "IndividualAnimalID";
            lbIndividualAnimal.DataBind();
            lbIndividualAnimal.Visible = true;

            //added by Ocllo
            lbAdditionalData.Items.Clear();
            int ObjectID = breedID;
            string ObjectName = "Breeds";
            string Category = rbAdditionalData.SelectedItem.Value;
            lbAdditionalData.DataSource = animalDAL.GetSpecificAdditionalData(ObjectID, ObjectName, Category);
            lbAdditionalData.DataTextField = "Description";
            lbAdditionalData.DataValueField = "DataID";
            lbAdditionalData.DataBind();
            lbAdditionalData.Visible = true;
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
            int ObjectID = Convert.ToInt32(lbBreeds.SelectedItem.Value);
            string ObjectName = "Breeds";

            lbAdditionalData.DataSource = animalDAL.GetSpecificAdditionalData(ObjectID, ObjectName, Category);
            lbAdditionalData.DataTextField = "Description";
            lbAdditionalData.DataValueField = "DataID";
            lbAdditionalData.DataBind();
            lbAdditionalData.Visible = true;
        }

        protected void BreedUpdate_Click(object sender, EventArgs e)
        {
            BreedModel Breed = new BreedModel();

            Breed.LiveStockID = Convert.ToInt32(hfLiveStockID.Value);
            Breed.BreedID = Convert.ToInt32(hfBreedID.Value);
            Breed.Name = txtBreedName.Text;
            Breed.Count = Convert.ToInt32(txtBreedCount.Text);

            animalDAL.UpdateBreed(Breed);

            GetBreed(Breed.LiveStockID);
            SetControls(Breed.BreedID);
        }

        protected void DeleteBreed(object sender, EventArgs e)
        {
            animalDAL.DeleteBreedInfo(Convert.ToInt32(lbBreeds.SelectedValue));
        }
    }
}