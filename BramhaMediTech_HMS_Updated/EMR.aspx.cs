using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EMR :BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

        }
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string message = "Selected Item: " + DropDownList1.SelectedItem.Text;
        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", "alert('" + message + "');", true);

    }
}