using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BillSubServices :BasePage
{
    BELBillSubService objBELSubService = new BELBillSubService();
    DALBillSubService objDALSubService = new DALBillSubService();
    string UserId = "";
    int BillServiceId=0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                show.Visible = false;
                List.Visible = true;

            }
            catch (Exception)
            {
            }
            
            LoadBillService();
            FillBillSubServiceGrid(Convert.ToInt32(ddlBillService.SelectedValue));         


        }


    }



    protected void FillBillSubServiceGrid(int BillServiceId)
    {
        gvBillSubService.DataSource = objDALSubService.FillGrid(BillServiceId);
        gvBillSubService.DataBind();
    }


    private void LoadBillService()
    {
        ddlBillService.DataSource = objDALSubService.FillBillServiceDrop();
        ddlBillService.DataValueField = "BillServiceId";
        ddlBillService.DataTextField = "ServiceName";
        ddlBillService.DataBind();
        ddlBillServiceSearch.DataSource = objDALSubService.FillBillServiceDrop();
        ddlBillServiceSearch.DataTextField = "ServiceName";
        ddlBillServiceSearch.DataValueField = "BillServiceId";
        ddlBillServiceSearch.DataBind();
    }



    protected void txtBillSubService_TextChanged(object sender, EventArgs e)
    {

        txtBillSubService.Text = txtBillSubService.Text.Trim();
    }

   
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string Message = "";

        if (Convert.ToInt32(ViewState["BillSubServiceId"]) > 0)
        {
            objBELSubService.BillSubServiceId = Convert.ToInt32(ViewState["BillSubServiceId"]);
            objBELSubService.ServiceDetails = txtBillSubService.Text;
            objBELSubService.BillServiceId = Convert.ToInt32(ddlBillService.SelectedValue);
            objBELSubService.UpdatedBy = Convert.ToString(Session["username"]);
            Message = objDALSubService.UpdateBillSubService(objBELSubService);
        }
        else
        {
            objBELSubService.ServiceDetails = txtBillSubService.Text;
            objBELSubService.BillServiceId = Convert.ToInt32(ddlBillService.SelectedValue);             
            objBELSubService.CreatedBy = Convert.ToString(Session["username"]);
            objBELSubService.BranchId = Convert.ToInt32(Session["BranchId"]);
            objBELSubService.FId = "1";
            int OrderNo = objDALSubService.GetMaxOrderNo(Convert.ToInt32(ddlBillService.SelectedValue));
            objBELSubService.ServiceOrder = OrderNo;
            Message = objDALSubService.InsertBillSubService(objBELSubService);
        }

       
        DynamicMessage(lblMessage, Message);
        show.Visible = false;
        List.Visible = true;
        FillBillSubServiceGrid(Convert.ToInt32(ddlBillService.SelectedValue));
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
        txtBillSubService.Text = "";
        ViewState["BillSubServiceId"] = 0;
        ddlBillService.SelectedIndex = 0;
        ViewState["BillServiceId"] = 0;
        
    }



    protected void ddlBillServiceSearch_SelectedIndexChanged(object sender, EventArgs e)
    {
        BillServiceId = Convert.ToInt32(ddlBillServiceSearch.SelectedValue);
        ViewState["BillServiceId"] = BillServiceId;
        FillBillSubServiceGrid(Convert.ToInt32(ViewState["BillServiceId"]));
        lblMessage.Text = "";
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        FillBillSubServiceGrid(Convert.ToInt32(ddlBillService.SelectedValue));
        lblMessage.Text = "";
    }
    



    protected void gvBillSubService_RowEditing(object sender, GridViewEditEventArgs e)
    {
        show.Visible = true;
        List.Visible = false;

        try
        {
            string BillServiceId = (gvBillSubService.DataKeys[e.NewEditIndex]["BillSubServiceId"].ToString());
            ViewState["BillSubServiceId"] = BillServiceId;
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
        objBELSubService = objDALSubService.SelectOne(Convert.ToInt32(ViewState["BillSubServiceId"]));

        txtBillSubService.Text = objBELSubService.ServiceDetails;
        ddlBillService.SelectedValue = Convert.ToString(objBELSubService.BillServiceId);
       
    }


    protected void gvBillSubService_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string BillSubServiceId = (gvBillSubService.DataKeys[e.RowIndex]["BillSubServiceId"].ToString());

        string Message = objDALSubService.DeleteBillSubService(Convert.ToInt32(BillSubServiceId));

        DynamicMessage(lblMessage, Message);

        FillBillSubServiceGrid(Convert.ToInt32(ddlBillService.SelectedValue));


    }

    protected void gvBillSubService_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvBillSubService.PageIndex = e.NewPageIndex;
        FillBillSubServiceGrid(Convert.ToInt32(ddlBillService.SelectedValue));

    }
 
   
}