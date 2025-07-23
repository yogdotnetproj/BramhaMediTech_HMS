using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RateType_Bill : BaseClass
{
    BELRateType objBELRateType = new BELRateType();
    DALRateType objDALRateType = new DALRateType();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillRateTypeGrid();

            show.Visible = false;
            List.Visible = true;

        }
    }
    protected void FillRateTypeGrid()
    {
        gvRateType.DataSource = objDALRateType.FillGridRateType();
        gvRateType.DataBind();
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {

        string Message = "";

        if (!(txtRateType.Text.Equals(string.Empty)))
        {
            if (Convert.ToInt32(ViewState["RateTypeId"]) > 0)
            {
                objBELRateType = objDALRateType.SelectOneRateType(Convert.ToInt32(ViewState["RateTypeId"]));
                objBELRateType.RateType = txtRateType.Text;
                objBELRateType.RateTypeId = Convert.ToInt32(ViewState["RateTypeId"]);
                objBELRateType.UpdatedBy = Convert.ToString(Session["username"]);

                Message = objDALRateType.UpdateRateType(objBELRateType);
            }
            else
            {
                objBELRateType.RateType = txtRateType.Text;
                objBELRateType.FId = "1";
                objBELRateType.BranchId = Convert.ToInt32(Session["Branchid"]);
                objBELRateType.CreatedBy = Convert.ToString(Session["username"]);

                Message = objDALRateType.InsertRateType(objBELRateType);
            }

            DynamicMessage(lblMessage, Message);

            FillRateTypeGrid();
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
        txtRateType.Text = "";
        ViewState["RateTypeId"] = 0;
        lblMessage.Text = "";
        show.Visible = false;
        List.Visible = true;

    }
    private void clearall()
    {
        txtRateType.Text = "";
        ViewState["RateTypeId"] = 0;

    }

    protected void FillPage()
    {
        try
        {
            objBELRateType = objDALRateType.SelectOneRateType(Convert.ToInt32(ViewState["RateTypeId"]));
            txtRateType.Text = objBELRateType.RateType;


        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }

    protected void gvRateType_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            show.Visible = true;
            List.Visible = false;

            string RateTypeId = (gvRateType.DataKeys[e.NewEditIndex]["RateTypeId"].ToString());
            ViewState["RateTypeId"] = RateTypeId;
            FillPage();
            e.Cancel = true;
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }

    }
    protected void gvRateType_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string RateTypeId = (gvRateType.DataKeys[e.RowIndex]["RateTypeId"].ToString());

        string Message = objDALRateType.DeleteRateType(Convert.ToInt32(RateTypeId));
        DynamicMessage(lblMessage, Message);

        FillRateTypeGrid();
        clearall();

    }
    protected void gvRateType_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvRateType.PageIndex = e.NewPageIndex;
        FillRateTypeGrid();
    }
    
}