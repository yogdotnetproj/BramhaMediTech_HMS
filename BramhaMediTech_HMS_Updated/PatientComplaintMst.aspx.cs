using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PatientComplaintMst : BaseClass
{
    BELComplaint objBELComplaint = new BELComplaint();
    DALComplaint objDALComplaint = new DALComplaint();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillPatComplaintGrid();

            show.Visible = false;
            List.Visible = true;

        }
    }
    protected void FillPatComplaintGrid()
    {

        gvPatComplaint.DataSource = objDALComplaint.FillGridComplaint();
        gvPatComplaint.DataBind();
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {

        string Message = "";

        if (!(txtComplaint.Text.Equals(string.Empty)))
        {
            if (Convert.ToInt32(ViewState["PatComplaintId"]) > 0)
            {

                objBELComplaint.PatComplaint = txtComplaint.Text;
                objBELComplaint.PatComplaintId = Convert.ToInt32(ViewState["PatComplaintId"]);
                objBELComplaint.UpdatedBy = Convert.ToString(Session["username"]);

                Message = objDALComplaint.UpdateComplaint(objBELComplaint);
            }
            else
            {
                objBELComplaint.PatComplaint = txtComplaint.Text;
                objBELComplaint.FId = "1";
                objBELComplaint.BranchId = Convert.ToInt32(Session["Branchid"]);
                objBELComplaint.CreatedBy = Convert.ToString(Session["username"]);

                Message = objDALComplaint.InsertComplaint(objBELComplaint);
            }

            DynamicMessage(lblMessage, Message);

            FillPatComplaintGrid();
            clearall();
        }
        show.Visible = false;
        List.Visible = true;

    }
    protected void btnaddnew_Click(object sender, EventArgs e)
    {
        show.Visible = true;
        List.Visible = false;
        lblMessage.Text = "";
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtComplaint.Text = "";

        ViewState["PatComplaintId"] = 0;
        lblMessage.Text = "";
        show.Visible = false;
        List.Visible = true;

    }
    private void clearall()
    {
        txtComplaint.Text = "";
        ViewState["PatComplaintId"] = 0;

    }

    protected void FillPage()
    {
        try
        {
            objBELComplaint = objDALComplaint.SelectOneComplaint(Convert.ToInt32(ViewState["PatComplaintId"]));
            txtComplaint.Text = objBELComplaint.PatComplaint;


        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }

    protected void gvPatComplaint_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            show.Visible = true;
            List.Visible = false;

            string PatComplaintId = (gvPatComplaint.DataKeys[e.NewEditIndex]["PatComplaintId"].ToString());
            ViewState["PatComplaintId"] = PatComplaintId;
            FillPage();
            e.Cancel = true;
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }

    }
    protected void gvPatComplaint_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string PatComplaintId = (gvPatComplaint.DataKeys[e.RowIndex]["PatComplaintId"].ToString());

        string Message = objDALComplaint.DeleteComplaint(Convert.ToInt32(PatComplaintId));
        DynamicMessage(lblMessage, Message);
        
        FillPatComplaintGrid();
        clearall();

    }
    protected void gvPatComplaint_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvPatComplaint.PageIndex = e.NewPageIndex;
        FillPatComplaintGrid();
    }
    
}