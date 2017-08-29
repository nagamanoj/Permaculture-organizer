using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PermacultureOrganizer.DAL;
using PermacultureOrganizer.Models;

namespace PermacultureOrganizer.Animals
{
    public partial class LiveStock : System.Web.UI.Page
    {
        AnimalDAL animalDAL = new AnimalDAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {

            }
            else
            {
                GetLiveStock();
            }
        }

        protected void GetLiveStock()
        {
            //Bind the livestock to listbox
            lbLiveStock.DataSource = animalDAL.GetAllLiveStockDescription();
            lbLiveStock.DataTextField = "Description";
            lbLiveStock.DataValueField = "LiveStockID";
            lbLiveStock.AutoPostBack = true;
            lbLiveStock.DataBind();
        }

        protected void SetControls(int livestockID)
        {
            var liveStockInfo = animalDAL.GetLiveStockByID(livestockID);
            lblLiveStockCount.Text = liveStockInfo.Rows[0]["Count"].ToString();
            lblLiveStockDiet.Text = liveStockInfo.Rows[0]["DietType"].ToString();
            lblLiveStockFoodPerAnimal.Text = liveStockInfo.Rows[0]["FoodPerAnimal"].ToString();

            txtbxLiveStockName.Text = liveStockInfo.Rows[0]["Description"].ToString();
            txtbxLiveStockCount.Text = liveStockInfo.Rows[0]["Count"].ToString();
            txtbxLiveStockDietType.Text = liveStockInfo.Rows[0]["DietType"].ToString();
            txtbxLiveStockFoodPerAnimal.Text = liveStockInfo.Rows[0]["FoodPerAnimal"].ToString();
            hfLiveStockID.Value = livestockID.ToString();
        }

        protected void lbLiveStock_SelectedIndexChanged(object sender, EventArgs e)
        {
            int livestockID = Convert.ToInt32(((ListBox)sender).SelectedValue);

            SetControls(livestockID);

            //var AdditionalData = animalDAL.GetAdditionalData(livestockID, "LiveStock");

            lbBreedList.DataSource = animalDAL.GetBreedsForLiveStockID(livestockID);
            lbBreedList.DataTextField = "Name";
            lbBreedList.DataValueField = "BreedID";
            lbBreedList.DataBind();
            lbBreedList.Visible = true;

            //added by Ocllo
            lbAdditionalData.Items.Clear();
            int ObjectID = livestockID;
            string ObjectName = "Livestock";
            string Category = rbAdditionalData.SelectedItem.Value;
            lbAdditionalData.DataSource = animalDAL.GetSpecificAdditionalData(ObjectID, ObjectName, Category);
            lbAdditionalData.DataTextField = "Description";
            lbAdditionalData.DataValueField = "DataID";
            lbAdditionalData.DataBind();
            lbAdditionalData.Visible = true;
        }

        void lbBreedList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int BreedID = Convert.ToInt32(lbBreedList.SelectedValue);
            int LiveStockID = Convert.ToInt32(lbLiveStock.SelectedValue);

            Response.Redirect("~/Breeds.aspx?BreedID=" + BreedID + "&LiveStockID=" + LiveStockID);
        }

        protected void LiveStockUpdate_Click(object sender, EventArgs e)
        {
            LiveStockModel LiveStock = new LiveStockModel();

            LiveStock.LiveStockID = Convert.ToInt32(hfLiveStockID.Value);
            LiveStock.Description = txtbxLiveStockName.Text;
            LiveStock.Count = Convert.ToInt32(txtbxLiveStockCount.Text);
            LiveStock.DietType = txtbxLiveStockDietType.Text;
            LiveStock.FoodPerAnimal = Convert.ToInt32(txtbxLiveStockFoodPerAnimal.Text);

            animalDAL.UpdateLiveStock(LiveStock);

            GetLiveStock();
            SetControls(LiveStock.LiveStockID);
        }

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
            int ObjectID = Convert.ToInt32(lbLiveStock.SelectedItem.Value);
            string ObjectName = "Livestock";

            lbAdditionalData.DataSource = animalDAL.GetSpecificAdditionalData(ObjectID, ObjectName, Category);
            lbAdditionalData.DataTextField = "Description";
            lbAdditionalData.DataValueField = "DataID";
            lbAdditionalData.DataBind();
            lbAdditionalData.Visible = true;
        }

        // sravan
        protected void DeleteLiveStock(object sender, EventArgs e)
        {
            // animalDAL.DeleteLiveStockInfo(Convert.ToInt32(lbLiveStock.SelectedValue));
            animalDAL.DeleteLiveStockInfo(Convert.ToInt32(LiveStockID.Value));
        }
    }
}