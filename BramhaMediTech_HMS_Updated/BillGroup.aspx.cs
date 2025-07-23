using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class BillGroup : BaseClass
{
    BELBillGroup objBELBillGroup = new BELBillGroup();
    DALBillGroup objDALBillGroup = new DALBillGroup();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                show.Visible = false;
                List.Visible = true;
                objBELBillGroup = objDALBillGroup.GetMaxOrderNoForBillGroup();
                txtGroupOrder.Text = Convert.ToString(objBELBillGroup.GroupOrderNo + 1);
                FillBillGroupGrid();
            }
            catch (Exception)
            {
            }

        }


    }



    protected void FillBillGroupGrid()
    {
        gvBillGroup.DataSource = objDALBillGroup.FillGrid();
        gvBillGroup.DataBind();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        string Message = "";

        if (Convert.ToInt32(ViewState["BillGroupId"]) > 0)
        {
            objBELBillGroup.BillGroupId = Convert.ToInt32(ViewState["BillGroupId"]);
            objBELBillGroup.GroupName = txtBillGroup.Text;
            objBELBillGroup.GroupOrderNo = Convert.ToInt32(txtGroupOrder.Text);
            objBELBillGroup.UpdatedBy = Convert.ToString(Session["username"]);
            objBELBillGroup.GroupType = Convert.ToInt32(RblGroupType.SelectedValue);
            if (ChkDailyService.Checked == true)
            {
                objBELBillGroup.DailyService = true;
            }
            else
            {
                objBELBillGroup.DailyService = false;
            }
            Message = objDALBillGroup.UpdateBillGroup(objBELBillGroup);
        }
        else
        {
            objBELBillGroup.GroupName = txtBillGroup.Text;
            objBELBillGroup.GroupOrderNo = Convert.ToInt32(txtGroupOrder.Text);
            objBELBillGroup.CreatedBy = Convert.ToString(Session["username"]);
            objBELBillGroup.BranchId = Convert.ToInt32(Session["BranchId"]);
            objBELBillGroup.FId = "1";
            objBELBillGroup.GroupType = Convert.ToInt32(RblGroupType.SelectedValue);
            if (ChkDailyService.Checked == true)
            {
                objBELBillGroup.DailyService = true;
            }
            else
            {
                objBELBillGroup.DailyService = false;
            }
            //int OrderNo = objDALSubService.GetMaxOrderNo(Convert.ToInt32(ddlBillService.SelectedValue));
            //objBELSubService.ServiceOrder = OrderNo;
            Message = objDALBillGroup.InsertBillGroup(objBELBillGroup);
        }


        DynamicMessage(lblMessage, Message);
        show.Visible = false;
        List.Visible = true;
        FillBillGroupGrid();
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
 
        ViewState["BillGroupId"] = 0;
        txtGroupOrder.Text = "";
        txtBillGroup.Text = "";
        

    }   



    protected void gvBillGroup_RowEditing(object sender, GridViewEditEventArgs e)
    {
        show.Visible = true;
        List.Visible = false;

        try
        {
            string BillGroupId = (gvBillGroup.DataKeys[e.NewEditIndex]["BillGroupId"].ToString());
            ViewState["BillGroupId"] = BillGroupId;
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
        objBELBillGroup = objDALBillGroup.SelectOne(Convert.ToInt32(ViewState["BillGroupId"]));
        txtBillGroup.Text = objBELBillGroup.GroupName;
        txtGroupOrder.Text =Convert.ToString(objBELBillGroup.GroupOrderNo);
        RblGroupType.SelectedValue= Convert.ToString(objBELBillGroup.GroupType);
        if (objBELBillGroup.DailyService == true)
        {
            ChkDailyService.Checked = true;
        }
        else
        {
            ChkDailyService.Checked = false;
        }
        

    }


    protected void gvBillGroup_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string BillGroupId = (gvBillGroup.DataKeys[e.RowIndex]["BillGroupId"].ToString());
        DataTable dtdept = new DataTable();
        dtdept = objDALBillGroup.CheckGroupIsInUse(BillGroupId);
        if (dtdept.Rows.Count > 0)
        {
            string Message = " Bill group already in use can't delete!";
            DynamicMessage(lblMessage, Message);
        }
        else
        {
            string Message = objDALBillGroup.DeleteBillGroup(Convert.ToInt32(BillGroupId));

            DynamicMessage(lblMessage, Message);
        }
        FillBillGroupGrid();

    }

    protected void gvBillGroup_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvBillGroup.PageIndex = e.NewPageIndex;
        FillBillGroupGrid();

    }
 
 
}