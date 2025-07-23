using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;

public partial class ReligionMaster : BaseClass
{
    BELReligion ObjBELReligion = new BELReligion();
    DALReligion ObjDALReligion = new DALReligion();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                FillReligionGrid();
            }
            catch (Exception)
            {
            }

        }
    }
    protected void FillReligionGrid()
    {
        gvReligion.DataSource = ObjDALReligion.FillGrid();
        gvReligion.DataBind();
    }
    protected void gvReligion_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string ReligionId = (gvReligion.DataKeys[e.RowIndex]["ReligionId"].ToString());

        string Message = ObjDALReligion.DeleteReligion(Convert.ToInt32(ReligionId));
        DynamicMessage(lblMessage, Message);
        FillReligionGrid();
        txtReligion.Text = "";
        
    }
    protected void gvReligion_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {

            string ReligionId = (gvReligion.DataKeys[e.NewEditIndex]["ReligionId"].ToString());
            ViewState["ReligionId"] = ReligionId;
            FillPage();
            e.Cancel = true;
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void gvReligion_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvReligion.PageIndex = e.NewPageIndex;
        FillReligionGrid();
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        
        string Message = "";
        if (!(txtReligion.Text.Equals(string.Empty)))
        {
            if (Convert.ToInt32(ViewState["ReligionId"]) > 0)
            {
                ObjBELReligion = ObjDALReligion.SelectOne(Convert.ToInt32(ViewState["ReligionId"]));
                ObjBELReligion.Religion = txtReligion.Text;
                ObjBELReligion.ReligionId = Convert.ToInt32(ViewState["ReligionId"]);
                ObjBELReligion.UpdatedBy = Convert.ToString(Session["username"]);
                ObjBELReligion.BranchId = Convert.ToInt32(Session["Branchid"]);
                Message = ObjDALReligion.UpdateReligion(ObjBELReligion);
            }
            else
            {
                ObjBELReligion.Religion = txtReligion.Text;
                // objDOPatientCategory.IsActive = true;
                ObjBELReligion.CreatedBy = Convert.ToString(Session["username"]);
                ObjBELReligion.FId = "1";
                ObjBELReligion.BranchId = Convert.ToInt32(Session["Branchid"]);
                Message = ObjDALReligion.ReligionInsert(ObjBELReligion);
            }

            DynamicMessage(lblMessage, Message);

            FillReligionGrid();
            txtReligion.Text = "";
            ViewState["ReligionId"] = 0;

        }
       
    }
    protected void FillPage()
    {
        try
        {
            ObjBELReligion = ObjDALReligion.SelectOne(Convert.ToInt32(ViewState["ReligionId"]));
            txtReligion.Text = ObjBELReligion.Religion;
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtReligion.Text = "";
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {

    }
}