using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmNurseDailySheet :BasePage
{
    clsDocSche obj = new clsDocSche();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindDoctors();
            BindGrid();
        }
    }

    private void BindGrid()
    {

    }
    private void BindDoctors()
    {
        doctorNames.DataSource = obj.ReadDataDocList();
        doctorNames.DataValueField = "DoctorId";
        doctorNames.DataTextField = "DoctorName";
        doctorNames.DataBind();
        doctorNames.Items.Insert(0, new ListItem("--Select--", "-1"));
        doctorNames.SelectedIndex = 0;
    }
    protected void gdvNurse_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvNurse.PageIndex = e.NewPageIndex;
        BindGrid();
    }

    protected void gdvNurse_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void gdvNurse_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }

    protected void gdvNurse_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }

    protected void doctorNames_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}