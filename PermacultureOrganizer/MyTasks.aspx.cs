using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace PermacultureOrganizer
{
    public partial class MyTasks : System.Web.UI.Page
    {
        public string ConnectionString = WebConfigurationManager.ConnectionStrings["PermaCultureConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblselectcategoryID.Visible = false;
                lblselectstatuID.Visible = false;
                ddcategoryID.Visible = false;
                ddstatusID.Visible = false;
            }

        }

        protected void linkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View.aspx?TaskID=" + ((LinkButton)sender).Text);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateTaskPage.aspx");
        }

        protected void ddstatusID_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvtasksID.Visible = false;
            using (SqlConnection Connection = new SqlConnection(ConnectionString))
            {

                SqlCommand sqlcmd = new SqlCommand("SELECT tblTask.TaskID,tblTask.TaskName,tblTask.TaskDueDate,tblStatus.StatusName ,tblCategory.CategoryName  FROM tblTask INNER JOIN tblStatus ON tblTask.StatusID = tblStatus.StatusID INNER JOIN tblFrequency ON tblFrequency.FrequencyID = tblTask.FrequencyID inner join tblCategory on tblCategory.CategoryID = tblTask.CategoryID WHERE tblTask.StatusID='" + ddstatusID.SelectedItem.Value + "'", Connection);
                SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                Connection.Open();
                sqlcmd.ExecuteNonQuery();
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
        }

        protected void linkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View.aspx?TaskID=" + ((LinkButton)sender).Text);
        }

        protected void ddcategoryID_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvtasksID.Visible = false;
            using (SqlConnection Connection = new SqlConnection(ConnectionString))
            {

                SqlCommand sqlcmd = new SqlCommand("SELECT tblTask.TaskID,tblTask.TaskName,tblTask.TaskDueDate,tblStatus.StatusName ,tblCategory.CategoryName  FROM tblTask INNER JOIN tblStatus ON tblTask.StatusID = tblStatus.StatusID INNER JOIN tblFrequency ON tblFrequency.FrequencyID = tblTask.FrequencyID inner join tblCategory on tblCategory.CategoryID = tblTask.CategoryID WHERE tblTask.CategoryID='" + ddcategoryID.SelectedItem.Value + "'", Connection);
                SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                Connection.Open();
                sqlcmd.ExecuteNonQuery();
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
        }

        protected void ddSortID_SelectedIndexChanged(object sender, EventArgs e)
        {
            int d1 = Int32.Parse(ddSortID.SelectedValue.ToString());
            if (d1 == 600) 
            {
                lblselectcategoryID.Visible = true;
                lblselectstatuID.Visible = false;
                ddcategoryID.Visible = true;
                ddstatusID.Visible = false;
            }
            else if (d1 == 601)
            {
                lblselectstatuID.Visible = true;
                lblselectcategoryID.Visible = false;
                ddcategoryID.Visible = false;
                ddstatusID.Visible = true;
            }
            else if (d1 == 602)
            {
                gvtasksID.Visible = false;
                using (SqlConnection Connection = new SqlConnection(ConnectionString))
                {

                    SqlCommand sqlcmd = new SqlCommand("SELECT tblTask.TaskID,tblTask.TaskName,tblTask.TaskDueDate,tblStatus.StatusName ,tblCategory.CategoryName  FROM tblTask INNER JOIN tblStatus ON tblTask.StatusID = tblStatus.StatusID INNER JOIN tblFrequency ON tblFrequency.FrequencyID = tblTask.FrequencyID inner join tblCategory on tblCategory.CategoryID = tblTask.CategoryID WHERE tblTask.StatusID != 204", Connection);
                    SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    Connection.Open();
                    sqlcmd.ExecuteNonQuery();
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection Connection = new SqlConnection(ConnectionString))
            {

                SqlCommand sqlcmd = new SqlCommand("SELECT tblTask.TaskID,tblTask.TaskName,tblTask.TaskDueDate,tblStatus.StatusName ,tblCategory.CategoryName  FROM tblTask INNER JOIN tblStatus ON tblTask.StatusID = tblStatus.StatusID INNER JOIN tblFrequency ON tblFrequency.FrequencyID = tblTask.FrequencyID inner join tblCategory on tblCategory.CategoryID = tblTask.CategoryID WHERE tblTask.TaskName like'" + TextBox1.Text + "%' or  CONTAINS (TaskName,'" + TextBox1.Text + "') ", Connection);
                SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                Connection.Open();
                sqlcmd.ExecuteNonQuery();
                GridView1.DataSource = ds;
                GridView1.DataBind();


            }
        }

                protected void GridView1_PageIndexChanging (object sender, GridViewPageEventArgs  e)
{
    GridView1.PageIndex = e.NewPageIndex;
    //BindData();
 }

                
            }
        }

        
        

    
