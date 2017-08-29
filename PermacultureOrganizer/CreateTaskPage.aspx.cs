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
    public partial class CreateTaskPage : System.Web.UI.Page
    {
        public string ConnectionString = WebConfigurationManager.ConnectionStrings["PermaCultureConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                duedatecalenderID.Visible = false;
            }
        }


        


        protected void duedatecalenderID_SelectionChanged(object sender, EventArgs e)
        {
            tbduedatedisplayID.Text = duedatecalenderID.SelectedDate.ToString("yyyy-MM-dd");
            
            DateTime time = Convert.ToDateTime(tbduedatedisplayID.Text);
            if (DateTime.Now >= time)
            {
                Label2.Text = "Please check the date selected";
                duedatecalenderID.Visible = true;
            }
            else
            {
                Label2.Text = "";
                duedatecalenderID.Visible = false;
            
            }
        }



        protected void btncreate_Click(object sender, EventArgs e)
        {
            InsertTask();
        }
        public void InsertTask()
        {
            CreateTask(ConnectionString);

        }
        public DataTable CreateTask(string ConnectionString)
        {
            DataTable dtobject = new DataTable();
            using (SqlConnection Connection = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlcmd = new SqlCommand();
                //associate command object with connection
                sqlcmd.Connection = Connection;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "Createtask";

                sqlcmd.Parameters.Add("@TaskName", SqlDbType.VarChar, 1000).Value = Convert.ToString(tbtasknameID.Text);
                sqlcmd.Parameters.Add("@TaskDescription", SqlDbType.VarChar, 1000).Value = Convert.ToString(tbtaskdescID.Text);
                sqlcmd.Parameters.Add("@TaskDueDate", SqlDbType.Date, 1000).Value = Convert.ToDateTime(tbduedatedisplayID.Text);
                sqlcmd.Parameters.Add("@FrequencyID", SqlDbType.Int, 1000).Value = Convert.ToInt16(ddfrequencyID.SelectedValue);
                sqlcmd.Parameters.Add("@StatusID", SqlDbType.Int, 1000).Value = Convert.ToInt16(ddstatusID.SelectedValue);
                sqlcmd.Parameters.Add("@CategoryID", SqlDbType.Int, 1000).Value = Convert.ToInt16(ddcategoryID.SelectedValue);
                sqlcmd.Parameters.Add("@TimeslotID", SqlDbType.Int, 1000).Value = Convert.ToInt16(ddtimeslotID.SelectedValue);
                //sqlcmd.Parameters.Add("@TaskStartTime", SqlDbType.DateTime, 1000).Value = Convert.ToDateTime(tbstarttimeID.Text);
                //sqlcmd.Parameters.Add("@TaskEndtime", SqlDbType.DateTime, 1000).Value = Convert.ToDateTime(tbendtimeID.Text);
                using (SqlDataAdapter sqladapter = new SqlDataAdapter(sqlcmd))
                {
                    DataSet dataset = new DataSet();
                    sqladapter.Fill(dataset);
                    Session["YourMessage"] = "Update was successful";
                    Response.Redirect("MyTasks.aspx");

                    //Response.Write("Record was successfully added!");
                }

            }
            return dtobject;
        }


        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (duedatecalenderID.Visible)
            {
                duedatecalenderID.Visible = false;
            }
            else
            {
                duedatecalenderID.Visible = true;
            }
        }


    }
}