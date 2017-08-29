using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int number = int.Parse(DropDownList1.SelectedItem.Text);
        cubeTextBox.Text = (Math.Pow(number, 3.0)).ToString();
    }
}