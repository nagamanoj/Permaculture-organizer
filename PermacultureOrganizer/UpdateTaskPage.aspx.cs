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
    public partial class UpdateTaskPage : System.Web.UI.Page
    {
        public string ConnectionString = WebConfigurationManager.ConnectionStrings["PermaCultureConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                duedatecalender1ID.Visible = false;
                string TaskID = Request.QueryString["TaskID"].ToString();
                using (SqlConnection Connection = new SqlConnection(ConnectionString))
                {
                    SqlCommand sqlcmd = new SqlCommand("Viewtask", Connection);
                    //associate command object with connection
                    sqlcmd.Connection = Connection;
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter parameter = new SqlParameter("@TaskID", TaskID);
                    sqlcmd.Parameters.Add(parameter);
                    Connection.Open();
                    using (SqlDataReader rdr = sqlcmd.ExecuteReader())
                    {
                        // while (rdr.Read())
                        rdr.Read();
                        {
                            String Date = rdr["TaskDueDate"].ToString();
                            DateTime Date1 = Convert.ToDateTime(Date);
                            tbtaskname1ID.Text = rdr["TaskName"].ToString();
                            tbtaskdesc1ID.Text = rdr["TaskDescription"].ToString();
                            ddstatus1ID.Text = rdr["StatusID"].ToString();
                            ddfrequency1ID.Text = rdr["FrequencyID"].ToString();
                            ddcategory1ID.Text = rdr["CategoryID"].ToString();
                            ddtimeslot1ID.Text = rdr["TimeslotID"].ToString();
                            tbduedatedisplayID.Text = Date1.ToString("yyyy-MM-dd");
                            //tbstarttime1ID.Text = rdr["TaskStartTime"].ToString();
                            //tbendtime1ID.Text = rdr["TaskEndTime"].ToString();

                        }
                    }

                }
            }
        }

        protected void btnupdateID_Click(object sender, EventArgs e)
        {
            InsertTask();
        }
        public void InsertTask()
        {
            UpdateTask(ConnectionString);

        }
        public DataTable UpdateTask(string ConnectionString)
        {
            string TaskID = Request.QueryString["TaskID"].ToString();

            DataTable dtobject = new DataTable();
            using (SqlConnection Connection = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlcmd = new SqlCommand();
                //associate command object with connection
                sqlcmd.Connection = Connection;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "UpdatingTask";
                
                sqlcmd.Parameters.Add("@TaskID", SqlDbType.Int).Value = Convert.ToInt32(TaskID);
                sqlcmd.Parameters["@TaskID"].Direction = ParameterDirection.Input;
                
                sqlcmd.Parameters.Add("@TaskName", SqlDbType.VarChar, 1000).Value = Convert.ToString(tbtaskname1ID.Text);
                sqlcmd.Parameters.Add("@TaskDescription", SqlDbType.VarChar, 1000).Value = Convert.ToString(tbtaskdesc1ID.Text);
                sqlcmd.Parameters.Add("@TaskDueDate", SqlDbType.Date, 1000).Value = Convert.ToDateTime(tbduedatedisplayID.Text);
                sqlcmd.Parameters.Add("@FrequencyID", SqlDbType.Int, 1000).Value = Convert.ToInt16(ddfrequency1ID.SelectedValue);
                sqlcmd.Parameters.Add("@StatusID", SqlDbType.Int, 1000).Value = Convert.ToInt16(ddstatus1ID.SelectedValue);
                sqlcmd.Parameters.Add("@CategoryID", SqlDbType.Int, 1000).Value = Convert.ToInt16(ddcategory1ID.SelectedValue);
                sqlcmd.Parameters.Add("@TimeslotID", SqlDbType.Int, 1000).Value = Convert.ToInt16(ddtimeslot1ID.SelectedValue);
                //sqlcmd.Parameters.Add("@TaskStartTime", SqlDbType.DateTime, 1000).Value = Convert.ToDateTime(tbstarttime1ID.Text);
                //sqlcmd.Parameters.Add("@TaskEndtime", SqlDbType.DateTime, 1000).Value = Convert.ToDateTime(tbendtime1ID.Text);
                using (SqlDataAdapter sqladapter = new SqlDataAdapter(sqlcmd))
                {
                    
                    DataSet dataset = new DataSet();
                    sqladapter.Fill(dataset);
                    Response.Redirect("MyTasks.aspx");
                }

            }
            return dtobject;
        }

        protected void duedatecalender1ID_SelectionChanged(object sender, EventArgs e)
        {

            tbduedatedisplayID.Text = duedatecalender1ID.SelectedDate.ToString("yyyy-MM-dd");

            DateTime time = Convert.ToDateTime(tbduedatedisplayID.Text);
            if (DateTime.Now >= time)
            {
                Label2.Text = "Please check the date selected";
                duedatecalender1ID.Visible = true;
            }
            else
            {
                Label2.Text = "";
                duedatecalender1ID.Visible = false;

            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (duedatecalender1ID.Visible)
            {
                duedatecalender1ID.Visible = false;
            }
            else
            {
                duedatecalender1ID.Visible = true;
            }
        }

        

    }
}