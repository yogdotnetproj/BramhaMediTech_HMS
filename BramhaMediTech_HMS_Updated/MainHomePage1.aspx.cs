using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MainHomePage1 : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnHMS_Click(object sender, ImageClickEventArgs e)
    {
        Server.Transfer("~/Home.aspx", true);
    }
    protected void btnpatho_Click(object sender, ImageClickEventArgs e)
    {
        string LabName = "Pathology";
        Response.Redirect("~/Pathology/Home1.aspx?UserType=" + Session["usertype"] + " &FID=" + Session["FId"] + "&username=" + Session["username"] + "&LabName=" + LabName + "&HMS=Yes ", true);
    }
    protected void btnRadio_Click(object sender, ImageClickEventArgs e)
    {
        //Response.Redirect("~/Lab/Home1.aspx", true);
        string LabName = "Radiology";
        Response.Redirect("~/Radiology/Home1.aspx?UserType=" + Session["usertype"] + " &FID=" + Session["FId"] + "&username=" + Session["username"] + "&LabName=" + LabName + "&HMS=Yes ", true);

    }
    protected void btnPharmacy_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Pharmacy/Home.aspx?UserType="+ Session["usertype"] + " &FID="+ Session["FId"] + "&username="+ Session["username"] + "&HMS=Yes ", true);

    }
    protected void btnInven_Click(object sender, ImageClickEventArgs e)
    {
        string LabName = "Laboratory";
        Response.Redirect("~/Laboratory/Home1.aspx?UserType=" + Session["usertype"] + " &FID=" + Session["FId"] + "&username=" + Session["username"] + "&LabName=" + LabName + "&HMS=Yes ", true);

    }
    protected void btnQuality_Click(object sender, ImageClickEventArgs e)
    {
       // string LabName = "Laboratory";
        Response.Redirect("~/Inventory/Home.aspx?UserType=" + Session["usertype"] + " &FID=" + Session["FId"] + "&username=" + Session["username"] + "&HMS=Yes ", true);

    }
    protected void btnusermgt_Click(object sender, ImageClickEventArgs e)
    {
         Server.Transfer("~/UserManagementHome.aspx", true);
        
    }
}