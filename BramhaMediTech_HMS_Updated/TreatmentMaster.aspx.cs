using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TreatmentMaster :BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindMainGrid();
        }
    }

    private void BindMainGrid()
    {
        gdvTreatment.DataSource = GetTreatmentDetails();
        gdvTreatment.DataBind();
    }

    protected void gdvTreatment_PreRender(object sender, EventArgs e)
    {

    }

    protected void gdvTreatment_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvTreatment.PageIndex = e.NewPageIndex;
        BindMainGrid();
    }

    protected void gdvTreatment_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int rowIndex = e.NewEditIndex;
        string TreatmentId = (gdvTreatment.DataKeys[e.NewEditIndex]["TreatmentId"].ToString());

        GridViewRow row = (GridViewRow)gdvTreatment.Rows[rowIndex];

        Label PatientRegId = (Label)row.FindControl("PatientRegId");
        Label Ipd = (Label)row.FindControl("Ipd");
        Label Opd = (Label)row.FindControl("Opd");
        Label FollowUpDate = (Label)row.FindControl("FollowUpDate");
        Label BranchId = (Label)row.FindControl("BranchId");
        Label CreatedBy = (Label)row.FindControl("CreatedBy");
        Label CreatedOn = (Label)row.FindControl("CreatedOn");


        Response.Redirect(string.Format("~/frmTreatment.aspx?p={0}&i={1}&o={2}&f={3}&b={4}&cb={5}&co={6}&t={7}",
            PatientRegId.Text, Ipd.Text, Opd.Text,FollowUpDate.Text, BranchId.Text, CreatedBy.Text, CreatedOn.Text,TreatmentId.ToString() ));

    }

    protected void gdvTreatment_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {

    }

    protected void gdvTreatment_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void gdvTreatment_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    public DataTable GetTreatmentDetails()
    {
        DataTable dt = new DataTable();

        using (SqlConnection con = DataAccess.ConInitForDC())
        {
            using (SqlCommand cmd = new SqlCommand("usp_GetTreatmentByPatient", con))
            {
                cmd.CommandText = "SELECT * FROM tbl_Treatment Order by Opd desc";

                con.Open();

                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(dt);
                }

                con.Close();
            }
        }
        return dt;
    }

    protected void bntAddNew_Click(object sender, EventArgs e)
    {
        Response.Redirect(string.Format("~/frmTreatment.aspx?p={0}&i={1}&o={2}&f={3}&b={4}&cb={5}&co={6}&t={7}",
            null, null, null, null, null, null, null,null));

    }
}