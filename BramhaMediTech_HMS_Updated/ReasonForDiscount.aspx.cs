using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using System.Data;


public partial class ReasonForDiscount :BasePage
{
    BELReasonDiscount objBELDiscount = new BELReasonDiscount();
    DALReasonDiscount objDALDiscount = new DALReasonDiscount();
    string UserId = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            show.Visible = false;
            List.Visible = true;
            FillDiscReasonGrid();

        }


    }
    protected void FillDiscReasonGrid()
    {
        gvDiscount.DataSource = objDALDiscount.FillGrid();
        gvDiscount.DataBind();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        string Message = "";

        if (Convert.ToInt32(ViewState["DiscTypeId"]) > 0)
        {
            objBELDiscount.DiscTypeId = Convert.ToInt32(ViewState["DiscTypeId"]);
            objBELDiscount.DiscType = txtDiscReason.Text;
            objBELDiscount.UpdatedBy = Convert.ToString(Session["username"]);
            Message = objDALDiscount.UpdateDiscReason(objBELDiscount);
        }
        else
        {
            objBELDiscount.DiscType = txtDiscReason.Text;
            objBELDiscount.CreatedBy = Convert.ToString(Session["username"]);
            objBELDiscount.BranchId = Convert.ToInt32(Session["BranchId"]);
            objBELDiscount.FId = "1";

            Message = objDALDiscount.InsertDiscReason(objBELDiscount);
        }


        DynamicMessage(lblMessage, Message);
        show.Visible = false;
        List.Visible = true;
        FillDiscReasonGrid();
        Reset();
    }
    protected void btnaddnew_Click(object sender, EventArgs e)
    {
        show.Visible = true;
        List.Visible = false;
        lblMessage.Text = "";

    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        Reset();
        show.Visible = false;
        List.Visible = true;
        lblMessage.Text = "";
    }

    private void Reset()
    {
        ViewState["DiscTypeId"] = 0;
        txtDiscReason.Text = "";
    }

    protected void gvDiscount_RowEditing(object sender, GridViewEditEventArgs e)
    {
        show.Visible = true;
        List.Visible = false;

        try
        {
            string DiscTypeId = (gvDiscount.DataKeys[e.NewEditIndex]["DiscTypeId"].ToString());
            ViewState["DiscTypeId"] = DiscTypeId;
            FillPage();
            e.Cancel = true;
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }


    protected void FillPage()
    {
        try
        {
            ReadDO();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }

    private void ReadDO()
    {
        objBELDiscount = objDALDiscount.SelectOne(Convert.ToInt32(ViewState["DiscTypeId"]));
        txtDiscReason.Text = objBELDiscount.DiscType;

        
    }


    protected void gvDiscount_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string DiscTypeId = (gvDiscount.DataKeys[e.RowIndex]["DiscTypeId"].ToString());

        string Message = objDALDiscount.DeleteDiscReason(Convert.ToInt32(DiscTypeId));

        DynamicMessage(lblMessage, Message);

        FillDiscReasonGrid();

    }

    protected void gvDiscount_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDiscount.PageIndex = e.NewPageIndex;
        FillDiscReasonGrid();

    }
 
}