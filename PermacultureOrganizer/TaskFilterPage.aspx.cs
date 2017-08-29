using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;


namespace PermacultureOrganizer
{
    public partial class TaskFilterPage : System.Web.UI.Page
    {
        public string ConnectionString = WebConfigurationManager.ConnectionStrings["PermaCultureConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label1.Visible = false;
                tbselecteddatedisplayID.Visible = false;
                btngenerateID.Visible = false;
                Button1.Visible = false;
                tbmonthID.Visible = false;
                monthlabelID.Visible = false;
                btnmonthlygenerateID.Visible = false;
                startdateID.Visible = false;
                enddateID.Visible = false;
                fromdatelabelID.Visible = false;
                todatelabelID.Visible = false;
                btncustomreportID.Visible = false;
            }
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            PdfPTable pdfTable = new PdfPTable(GridView2.HeaderRow.Cells.Count);

            foreach (TableCell headercell in GridView2.HeaderRow.Cells)
            {

                Font font = new Font();
                font.Color = new BaseColor(GridView2.HeaderStyle.ForeColor);

                PdfPCell pdfCell = new PdfPCell(new Phrase(headercell.Text, font));
                pdfCell.BackgroundColor = new BaseColor(GridView2.HeaderStyle.BackColor);
                pdfTable.AddCell(pdfCell);
            }


            foreach (GridViewRow gridViewRow in GridView2.Rows)
            {
                foreach (TableCell tableCell in gridViewRow.Cells)
                {

                    Font font = new Font();
                    font.Color = new BaseColor(GridView2.RowStyle.ForeColor);


                    PdfPCell pdfCell = new PdfPCell(new Phrase(tableCell.Text));
                    pdfCell.BackgroundColor = new BaseColor(GridView2.RowStyle.BackColor);
                    pdfTable.AddCell(pdfCell);
                }
            }

            Document pdfDocument = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
            PdfWriter.GetInstance(pdfDocument, Response.OutputStream);

            pdfDocument.Open();
            pdfDocument.Add(pdfTable);
            pdfDocument.Close();

            Response.ContentType = "application/pdf";
            Response.AppendHeader("content-disposition", "attachment;filename=Tasks..pdf");
            Response.Write(pdfDocument);
            Response.Flush();
            Response.End();

        }

        protected void dayreportID_Click(object sender, EventArgs e)
        {
            Label1.Visible = true;
            tbselecteddatedisplayID.Visible = true;
            btngenerateID.Visible = true;
            Button1.Visible = false;
            tbmonthID.Visible = false;
            monthlabelID.Visible = false;
            btnmonthlygenerateID.Visible = false;
            startdateID.Visible = false;
            enddateID.Visible = false;
            fromdatelabelID.Visible = false;
            todatelabelID.Visible = false;
            btncustomreportID.Visible = false;
        }

        protected void btnmonthreportID_Click(object sender, EventArgs e)
        {
            Label1.Visible = false;
            tbselecteddatedisplayID.Visible = false;
            btngenerateID.Visible = false;
            Button1.Visible = false;
            tbmonthID.Visible = true;
            monthlabelID.Visible = true;
            btnmonthlygenerateID.Visible = true;
            startdateID.Visible = false;
            enddateID.Visible = false;
            fromdatelabelID.Visible = false;
            todatelabelID.Visible = false;
            btncustomreportID.Visible = false;
        }

        protected void btngenerateID_Click(object sender, EventArgs e)
        {
                tbmonthID.Visible = false;
                monthlabelID.Visible = false;
                btnmonthlygenerateID.Visible = false;
                Button1.Visible = true;
                btngenerateID.Visible = false;

                DateTime Date;
               
                Date = Convert.ToDateTime(tbselecteddatedisplayID.Text);
                using (SqlConnection Connection = new SqlConnection(ConnectionString))
                {

                    SqlCommand sqlcmd = new SqlCommand("SELECT tblTask.TaskName,tblTask.TaskDueDate,tblStatus.StatusName,tblCategory.CategoryName FROM tblTask INNER JOIN tblStatus ON tblTask.StatusID = tblStatus.StatusID INNER JOIN tblFrequency ON tblFrequency.FrequencyID = tblTask.FrequencyID inner join tblCategory on tblCategory.CategoryID = tblTask.CategoryID where TaskDueDate = @Date or tbltask.FrequencyID = '302';", Connection);
                    SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
                    sqlcmd.Parameters.Add("@Date", SqlDbType.Date).Value = Date;
                    sqlcmd.Parameters["@Date"].Direction = ParameterDirection.Input;
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    Connection.Open();
                    sqlcmd.ExecuteNonQuery();
                    //                DataGridView1.DataSource = DataSet["tblTask"];
                    GridView2.DataSource = ds;

                    GridView2.DataBind();

                }
            
            
            
        }

        protected void btnmonthlygenerateID_Click(object sender, EventArgs e)
        {
            Button1.Visible = true;
            Label1.Visible = false;
            tbselecteddatedisplayID.Visible = false;
            btngenerateID.Visible = false;
            tbmonthID.Visible = true;
            monthlabelID.Visible = true;
            btnmonthlygenerateID.Visible = false;

            DateTime Month;
            Month = Convert.ToDateTime(tbmonthID.Text);
            using (SqlConnection Connection = new SqlConnection(ConnectionString))
            {

                SqlCommand sqlcmd = new SqlCommand("SELECT tblTask.TaskName,tblTask.TaskDueDate,tblStatus.StatusName,tblCategory.CategoryName FROM tblTask INNER JOIN tblStatus ON tblTask.StatusID = tblStatus.StatusID INNER JOIN tblFrequency ON tblFrequency.FrequencyID = tblTask.FrequencyID inner join tblCategory on tblCategory.CategoryID = tblTask.CategoryID WHERE YEAR(TaskDueDate) = YEAR(@Month) AND MONTH(TaskDueDate) = MONTH(@Month)", Connection);
                SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
                sqlcmd.Parameters.Add("@Month", SqlDbType.Date).Value = Month;
                sqlcmd.Parameters["@Month"].Direction = ParameterDirection.Input;
                DataSet ds = new DataSet();
                da.Fill(ds);
                Connection.Open();
                sqlcmd.ExecuteNonQuery();
                //DataGridView1.DataSource = DataSet["tblTask"];
                GridView2.DataSource = ds;

                GridView2.DataBind();

            }
        }

        protected void btncustomdatereportID_Click(object sender, EventArgs e)
        {

            Label1.Visible = false;
            tbselecteddatedisplayID.Visible = false;
            btngenerateID.Visible = false;
            Button1.Visible = false;
            tbmonthID.Visible = false;
            monthlabelID.Visible = false;
            btnmonthlygenerateID.Visible = false;
            startdateID.Visible = true;
            enddateID.Visible = true;
            fromdatelabelID.Visible = true;
            todatelabelID.Visible = true;
            btncustomreportID.Visible = true;

        }

        protected void btncustomreportID_Click(object sender, EventArgs e)
        {
            Button1.Visible = true;
            btncustomreportID.Visible = false;

            DateTime Date1;
            DateTime Date2;
            Date1 = Convert.ToDateTime(startdateID.Text);
            Date2 = Convert.ToDateTime(enddateID.Text);
            using (SqlConnection Connection = new SqlConnection(ConnectionString))
            {

                SqlCommand sqlcmd = new SqlCommand("SELECT tblTask.TaskName,tblTask.TaskDueDate,tblStatus.StatusName,tblCategory.CategoryName FROM tblTask INNER JOIN tblStatus ON tblTask.StatusID = tblStatus.StatusID INNER JOIN tblFrequency ON tblFrequency.FrequencyID = tblTask.FrequencyID inner join tblCategory on tblCategory.CategoryID = tblTask.CategoryID WHERE TaskDueDate Between @Date1 and @Date2;", Connection);
                SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
                sqlcmd.Parameters.Add("@Date1", SqlDbType.Date).Value = Date1;
                sqlcmd.Parameters["@Date1"].Direction = ParameterDirection.Input;
                sqlcmd.Parameters.Add("@Date2", SqlDbType.Date).Value = Date2;
                sqlcmd.Parameters["@Date2"].Direction = ParameterDirection.Input;
                DataSet ds = new DataSet();
                da.Fill(ds);
                Connection.Open();
                sqlcmd.ExecuteNonQuery();
                //DataGridView1.DataSource = DataSet["tblTask"];
                GridView2.DataSource = ds;

                GridView2.DataBind();

            }
        }

       
        }
    }
