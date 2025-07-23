using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddServicesToPackage : BaseClass
{
    BELHealthPackage objBELHPack=new BELHealthPackage();
    DALHealthPackage objDALHPack=new DALHealthPackage ();
    string Message;   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["HPackId"] != null)
            {
                ViewState["HPackId"] = Request.QueryString["HPackId"].ToString();
                objBELHPack.HPackId = Convert.ToInt32(Request.QueryString["HPackId"]);
                objBELHPack = objDALHPack.SelectOne(Convert.ToInt32(ViewState["HPackId"]));
                txtPackName.Text = objBELHPack.HPackName;
                txtPackDetails.Text = objBELHPack.HPackDetails;
                txtPackAmount.Text = Convert.ToString(objBELHPack.HPackAmount);
                txtFromDate.Text = Convert.ToString(objBELHPack.FromDate.ToString("dd/MM/yyyy"));
                txtToDate.Text = Convert.ToString(objBELHPack.ToDate.ToString("dd/MM/yyyy"));
                if (objBELHPack.IsIpd == true)
                    chkIpd.Checked = true;
                if (objBELHPack.IsOpd == true)
                    chkOpd.Checked = true;
                FillGrid(Convert.ToInt32(ViewState["HPackId"]));
                FillBillServiceDrop();
                fillBillSubServiceDrop(Convert.ToInt32(ddlBillService.SelectedValue));
            }
        }
                 

    }
    protected void FillGrid(int HPackId)
    {

        gvBillService.DataSource = objDALHPack.FillPackServiceGrid(HPackId);
        gvBillService.DataBind();
    }
    protected void FillBillServiceDrop()
    {
        ddlBillService.DataSource = objDALHPack.FillBillServiceDrop();
        ddlBillService.DataValueField = "BillServiceId";
        ddlBillService.DataTextField = "ServiceName";
        ddlBillService.DataBind();
    }

    protected void btnsave_Click(object sender, EventArgs e)
    {
        objBELHPack.HPackId = Convert.ToInt32(ViewState["HPackId"]);
        objBELHPack.BillServiceId = Convert.ToInt32(ddlBillService.SelectedValue);
        objBELHPack.BillSubServiceId = Convert.ToInt32(ddlBillSubService.Text);
        if (txtQty.Text != "")
            objBELHPack.Qty = Convert.ToInt32(txtQty.Text);
        else
            objBELHPack.Qty = 0;
        if (txtAmount.Text != "")
            objBELHPack.Amount = Convert.ToDecimal(txtAmount.Text);
        else
            objBELHPack.Amount = 0;
        objBELHPack.CreatedBy = Convert.ToString(Session["username"]);
        objBELHPack.FId = "1";
        objBELHPack.BranchId = Convert.ToInt32(Session["Branchid"]);

        Message = objDALHPack.InsertHPackInfo(objBELHPack);
            DynamicMessage(lblMessage, Message);
            FillGrid(Convert.ToInt32(ViewState["HPackId"]));

    }
    protected void ddlBillService_SelectedIndexChanged(object sender, EventArgs e)
    {
        int BillServiceId = Convert.ToInt32(ddlBillService.SelectedValue);
        fillBillSubServiceDrop(BillServiceId);
       
    }
    protected void fillBillSubServiceDrop(int BillServiceId)
    {
        ddlBillSubService.DataSource = objDALHPack.FillBillSubServiceDrop(BillServiceId);
        ddlBillSubService.DataValueField = "BillSubServiceId";
        ddlBillSubService.DataTextField = "ServiceDetails";
        ddlBillSubService.DataBind();
    }
    protected void gvBillService_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string HPackInfoId = (gvBillService.DataKeys[e.RowIndex]["HPackInfoId"].ToString());

        string Message = objDALHPack.DeleteHPackInfo(Convert.ToInt32(HPackInfoId));

        DynamicMessage(lblMessage, Message);
        FillGrid(Convert.ToInt32(ViewState["HPackId"]));
   
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        ddlBillSubService.SelectedValue = "0";
        ddlBillService.SelectedValue = "0";
        txtAmount.Text = "";
        txtQty.Text = "";
    }
    protected void gvBillService_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("HealthPackageMaster.aspx");
    }
}