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
    public partial class View : System.Web.UI.Page
    {
        public string ConnectionString = WebConfigurationManager.ConnectionStrings["PermaCultureConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                String TaskID = Request.QueryString["TaskID"];


                using (SqlConnection Connection = new SqlConnection(ConnectionString))
                {
                    SqlCommand sqlcmd = new SqlCommand("seeTask", Connection);
                    //associate command object with connection
                    sqlcmd.Connection = Connection;
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter parameter = new SqlParameter("@TaskID", TaskID);
                    sqlcmd.Parameters.Add(parameter);
                    Connection.Open();
                    using (SqlDataReader rdr = sqlcmd.ExecuteReader())
                    {
                        
                       while( rdr.Read())
                        {
                            String Date = rdr["TaskDueDate"].ToString();
                            DateTime date1 = Convert.ToDateTime(Date);
                            lbltaskID.Text = rdr["TaskID"].ToString();
                            Label9.Text = rdr["TaskName"].ToString();
                            Label10.Text = rdr["TaskDescription"].ToString();
                            Label11.Text = rdr["StatusName"].ToString();
                            Label12.Text = rdr["FrequencyName"].ToString();
                            Label13.Text = rdr["CategoryName"].ToString();
                            Label14.Text = date1.ToString("yyyy-MM-dd");
                            Label15.Text = rdr["TimeslotName"].ToString();
                            //Label16.Text = rdr["TaskEndTime"].ToString();

                        }
                    }

                }
            }
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateTaskPage.aspx?TaskID=" + Server.UrlEncode(lbltaskID.Text));
        }

        protected void btndeleteID_Click(object sender, EventArgs e)
        {

            //   String TaskID = Request.QueryString["TaskID"];
            String TaskID = lbltaskID.Text;
            int TaskIDint = Convert.ToInt16(TaskID);
            //@TaskID Int;


            using (SqlConnection Connection = new SqlConnection(ConnectionString))
            {

                SqlCommand sqlcmd = new SqlCommand();
                //associate command object with connection
                sqlcmd.Connection = Connection;
                sqlcmd.CommandType = CommandType.Text;
                sqlcmd.Parameters.Add("@TaskID", SqlDbType.Int).Value = TaskIDint;
                sqlcmd.Parameters["@TaskID"].Direction = ParameterDirection.Input;
                sqlcmd.CommandText = "Delete from tblTask where TaskID = @TaskID";
                Connection.Open();
                sqlcmd.ExecuteNonQuery();
                Connection.Close();

                Response.Redirect("MyTasks.aspx");


            }
        }


    }
}