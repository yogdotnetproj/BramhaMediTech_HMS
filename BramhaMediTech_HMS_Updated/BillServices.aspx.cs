using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class BillServices : BaseClass
{
    BELBillService objBELService = new BELBillService();
    DALBillService objDALService = new DALBillService();
    string UserId = "", BillGroupId = "";
    BELRoom objBELRoom = new BELRoom();
    DALRoom objDALRoom = new DALRoom();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                show.Visible = false;
                List.Visible = true;              
           
            FillBillServiceGrid();
            LoadBillGroupName();
            FillRoomTypeDrop();
            RoomType.Visible = false;
            ChkActive.Checked = true;
           // objBELService = objDALService.GetMaxOrderNo();
           // txtPrintOrderNo.Text = Convert.ToString(objBELService.ServiceOrder + 1);
            }
            catch (Exception)
            {
            }

           
        }

        
    }


    
    protected void FillBillServiceGrid()
    {
        gvBillService.DataSource = objDALService.FillGrid();
        gvBillService.DataBind();
    }
    protected void FillRoomTypeDrop()
    {
        ddlRoomTypeName.DataSource = objDALRoom.FillRoomTypeCombo();
        ddlRoomTypeName.DataTextField = "RType";
        ddlRoomTypeName.DataValueField = "RTypeId";
        ddlRoomTypeName.DataBind();
    }
   
    private void LoadBillGroupName()
    {
        ddlBillGroupName.DataSource = objDALService.FillBillGroupDrop();
        ddlBillGroupName.DataValueField = "BillGroupId";
        ddlBillGroupName.DataTextField = "GroupName";
        ddlBillGroupName.DataBind();
        ddlBillGroupNameSearch.DataSource = objDALService.FillBillGroupDrop();
        ddlBillGroupNameSearch.DataTextField = "GroupName";
        ddlBillGroupNameSearch.DataValueField = "BillGroupId";
        ddlBillGroupNameSearch.DataBind();
    }

    

    protected void txtBillService_TextChanged(object sender, EventArgs e)
    {
       
        txtBillService.Text = txtBillService.Text.Trim();
    }

    protected void ddlBillGroupName_SelectedIndexChanged(object sender, EventArgs e)
    {
       
        BillGroupId = ddlBillGroupName.SelectedValue.ToString();
        DataTable dt = new DataTable();
        
        ViewState["BillGroupID"] = BillGroupId;
        if (ddlBillGroupName.SelectedValue == "2")
        {
            RoomType.Visible = true;
            BillServiceBox.Visible = false;
            txtBillService.Visible = false;
            ddlRoomTypeName.Visible = true;
            RdbServicesFlag.SelectedValue = "RoomWise";
            chkIpd.Checked = true;
            chkIPDDaily.Checked = true;
            ViewState["DailyService"] = "NO";
        }
        if (ddlBillGroupName.SelectedValue == "1")
        {
            RoomType.Visible = false;
            BillServiceBox.Visible = true;
            txtBillService.Visible = true;
            ddlRoomTypeName.Visible =false;
            RdbServicesFlag.SelectedValue="Docwise";
            chkIpd.Checked = false;
            ViewState["DailyService"] = "NO";
        }
        if (ddlBillGroupName.SelectedValue == "4")
        {
            RoomType.Visible = false;
            BillServiceBox.Visible = true;
            txtBillService.Visible = true;
            ddlRoomTypeName.Visible = false;
            RdbServicesFlag.SelectedValue = "Direct";
            chkIpd.Checked = false;
            ViewState["DailyService"] = "NO";
        }
        else
        {
            chkIpd.Checked = false;
            RdbServicesFlag.SelectedValue = "Docwise";
            ViewState["DailyService"] = "NO";

        }
        dt = objDALService.CheckIsBillGroupDaily(ddlBillGroupName.SelectedValue);
        if (dt.Rows.Count > 0)
        {
            if (Convert.ToBoolean(dt.Rows[0]["DailyService"]) == true)
            {
                //ViewState["DailyService"] = "Yes";
                //RoomType.Visible = true;
                //BillServiceBox.Visible = true;
                //txtBillService.Visible = true;
                //ddlRoomTypeName.Visible = true;
                //RdbServicesFlag.SelectedValue = "RoomWise";
                //chkIpd.Checked = true;
                //chkIPDDaily.Checked = true;
                ViewState["DailyService"] = "Yes";
                RoomType.Visible = true;
                if (ddlBillGroupName.SelectedValue != "2")
                {
                   // BillServiceBox.Visible = true;
                   // txtBillService.Visible = true;
                }
                BillServiceBox.Visible = true;
                 txtBillService.Visible = true;
                ddlRoomTypeName.Visible = true;
                RdbServicesFlag.SelectedValue = "RoomWise";
                chkIpd.Checked = true;
                chkIPDDaily.Checked = true;
            }
            else
            {
                RoomType.Visible = false;
            }


        }
    }

   protected void txtPrintOrderNo_TextChanged(object sender, EventArgs e)
    {
        txtPrintOrderNo.Text = txtPrintOrderNo.Text.Trim();
    }

   protected void btnSave_Click(object sender, EventArgs e)
    {       
        string Message = "";      
       
        if (Convert.ToInt32(ViewState["BillServiceId"]) > 0)
        {
            objBELService.BillServiceId = Convert.ToInt32(ViewState["BillServiceId"]);
            
            objBELService.BillGroupId = Convert.ToInt32(ddlBillGroupName.SelectedValue);
           // if (ddlBillGroupName.SelectedValue == "1")
            if(Convert.ToString(ViewState["DailyService"]) == "Yes")
            {
                objBELService.ServiceName = txtBillService.Text;
                if (ddlRoomTypeName.SelectedItem.Text != "Select Room Type")
                {
                    objBELService.RoomType = ddlRoomTypeName.SelectedValue;
                }
                else
                {
                    objBELService.RoomType ="0";
                }
                //objBELService.DailyServiceName = txtBillService.Text; 
            }
            else
            {
                objBELService.ServiceName = txtBillService.Text; 
            }
            objBELService.ServiceOrder = Convert.ToInt32(txtPrintOrderNo.Text);
            objBELService.UnitOfCharges = Convert.ToString(ddlUnitOfCharge.SelectedValue);
            if (chkIpd.Checked)
                objBELService.IsIpd = true;
            else
                objBELService.IsIpd = false;

            if (chkOpd.Checked)
                objBELService.IsOpd = true;
            else
                objBELService.IsOpd = false;

            
            if ( RdbServicesFlag.SelectedValue == "RoomWise")
                objBELService.IsRoomwise = true;
            else
                objBELService.IsRoomwise = false;

            if (RdbServicesFlag.SelectedValue=="Docwise")
                objBELService.Isdoc = true;
            else
                objBELService.Isdoc = false;
            if (RdbServicesFlag.SelectedValue=="Direct")
                objBELService.IsDirect = true;
            else
                objBELService.IsDirect = false;

            if (ChkActive.Checked)
                objBELService.IsActive = true;
            else
                objBELService.IsActive = false;

            if (chkIPDDaily.Checked)
                objBELService.IPDDaily = true;
            else
                objBELService.IPDDaily = false;
                   
            objBELService.UpdatedBy = Convert.ToString(Session["username"]);
            Message = objDALService.UpdateBillService(objBELService);
        }
        else
        {
           // objBELService.ServiceName = txtBillService.Text;
            objBELService.BillGroupId = Convert.ToInt32(ddlBillGroupName.SelectedValue);
           // if (ddlBillGroupName.SelectedValue == "1")
            if (Convert.ToString(ViewState["DailyService"]) == "Yes")
            {
               // objBELService.ServiceName = ddlRoomTypeName.SelectedItem.Text;
               // objBELService.DailyServiceName = txtBillService.Text; 
                objBELService.ServiceName = txtBillService.Text;
                if (ddlRoomTypeName.SelectedItem.Text != "Select Room Type")
                {
                    objBELService.RoomType = ddlRoomTypeName.SelectedValue;
                }
                else
                {
                    objBELService.RoomType = "0";
                }
            }
            else
            {
                objBELService.ServiceName = txtBillService.Text;
            }
            objBELService.ServiceOrder = Convert.ToInt32(txtPrintOrderNo.Text);
            objBELService.UnitOfCharges = Convert.ToString(ddlUnitOfCharge.SelectedValue);
            if (chkIpd.Checked)
                objBELService.IsIpd = true;
            else
                objBELService.IsIpd = false;

            if (chkOpd.Checked)
                objBELService.IsOpd = true;
            else
                objBELService.IsOpd = false;

            if (chkIPDDaily.Checked)
                objBELService.IPDDaily = true;
            else
                objBELService.IPDDaily = false;

            if (RdbServicesFlag.SelectedValue == "RoomWise")
                objBELService.IsRoomwise = true;
            else
                objBELService.IsRoomwise = false;

            if (RdbServicesFlag.SelectedValue=="DocWise")
                objBELService.Isdoc = true;
            else
                objBELService.Isdoc = false;
            if (RdbServicesFlag.SelectedValue=="Direct")
                objBELService.IsDirect = true;
            else
                objBELService.IsDirect = false;

            if (ChkActive.Checked)
                objBELService.IsActive = true;
            else
                objBELService.IsActive = false;


            objBELService.CreatedBy = Convert.ToString(Session["username"]);
            objBELService.BranchId = Convert.ToInt32(Session["BranchId"]);
            objBELService.FId = Convert.ToString(Session["FId"]); ;
            Message = objDALService.InsertBillService(objBELService);
        }

        Reset();
        DynamicMessage(lblMessage, Message);
        show.Visible = false;
        List.Visible = true;
        FillBillServiceGrid();

    }
    protected void btnaddnew_Click(object sender, EventArgs e)
    {
        show.Visible = true;
        List.Visible = false;
        lblMessage.Text = "";
        objBELService = objDALService.GetMaxOrderNo();
        txtPrintOrderNo.Text = Convert.ToString(objBELService.ServiceOrder + 1);

    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        Reset();
        show.Visible = false;
        List.Visible = true;
    }

    private void Reset()
    {
        txtBillService.Text = "";

        ViewState["BillGroupID"] = 0;
        ddlBillGroupName.SelectedIndex = 0;
        ViewState["BillServiceId"] = 0;

        txtPrintOrderNo.Text = "";
        ChkActive.Checked = false;
        ddlUnitOfCharge.SelectedValue="0";
       
        chkOpd.Checked = false;
        chkIpd.Checked = false;
       
      
        lblMessage.Text = "";
    }

    protected void txtBillServiceSearch_TextChanged(object sender, EventArgs e)
    {
        ViewState["SearchBillServiceName"] = txtBillServiceSearch.Text.Trim();
    }

    
    protected void ddlBillGroupNameSearch_SelectedIndexChanged(object sender, EventArgs e)
    {
        BillGroupId = ddlBillGroupNameSearch.SelectedValue.ToString();
        ViewState["SearchBillGroupID"] = BillGroupId;
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        objBELService.ServiceName = Convert.ToString(ViewState["SearchBillServiceName"]);
        objBELService.BillGroupId = Convert.ToInt32(ViewState["SearchBillGroupID"]);
        FillSearchGrid();
    }
    protected void FillSearchGrid()
    {
        objBELService.ServiceName = Convert.ToString(ViewState["SearchBillServiceName"]);
        objBELService.BillGroupId = Convert.ToInt32(ViewState["SearchBillGroupID"]);
        objBELService.FId = Convert.ToString(Session["FId"]);
        objBELService.BranchId = Convert.ToInt32(Session["BranchId"]);
        gvBillService.DataSource = objDALService.FillSearchGrid(objBELService);
        gvBillService.DataBind();
    }
    

    
    protected void gvBillService_RowEditing(object sender, GridViewEditEventArgs e)
    {
        show.Visible = true;
        List.Visible = false;
    
        try
        {
            string BillServiceId = (gvBillService.DataKeys[e.NewEditIndex]["BillServiceId"].ToString());
            ViewState["BillServiceId"] = BillServiceId;
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

    /// <summary>
    /// It Reads The Record Value From Data object and Set in FormFields
    /// </summary>
    private void ReadDO()
    {
        objBELService = objDALService.SelectOne(Convert.ToInt32(ViewState["BillServiceId"]));

        
        ViewState["BillGroupID"] = objBELService.BillGroupId;        
        ddlBillGroupName.SelectedValue = Convert.ToString(objBELService.BillGroupId);
        if (ddlBillGroupName.SelectedValue == "2")
        {
            FillRoomTypeDrop();
            ddlRoomTypeName.SelectedItem.Text = objBELService.ServiceName;
        }
        else
        {
            txtBillService.Text = objBELService.ServiceName;
        }


        txtPrintOrderNo.Text = Convert.ToString(objBELService.ServiceOrder);

        if (objBELService.Isdoc == true)
            RdbServicesFlag.SelectedValue="DocWise";
        
        if (objBELService.IsDirect == true)
            RdbServicesFlag.SelectedValue = "Direct";
        ddlUnitOfCharge.SelectedValue = objBELService.UnitOfCharges;
        ChkActive.Checked = objBELService.IsActive;
        if (objBELService.IsRoomwise == true)
             RdbServicesFlag.SelectedValue ="RoomWise";
      
        if(objBELService.IsIpd==true)
            chkIpd.Checked=true;
        if (objBELService.IsOpd == true)
            chkOpd.Checked = true;
        if ( objBELService.RoomType != "0")
        {
            RoomType.Visible = true ;
            ddlRoomTypeName.SelectedValue = objBELService.RoomType;
        }
        else
        {
            RoomType.Visible = false;
        }
    }

    
    protected void gvBillService_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string BillServiceId = (gvBillService.DataKeys[e.RowIndex]["BillServiceId"].ToString());
         DataTable dtdept = new DataTable();
         dtdept = objDALService.CheckBillServiceIsInUse(BillServiceId);
        if (dtdept.Rows.Count > 0)
        {
            string Message = " Bill service already in use can't delete!";
            DynamicMessage(lblMessage, Message);
        }
        else
        {
            string Message = objDALService.DeleteBillService(Convert.ToInt32(BillServiceId));

            DynamicMessage(lblMessage, Message);
        }
        FillSearchGrid();

    }

    protected void gvBillService_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvBillService.PageIndex = e.NewPageIndex;
        FillSearchGrid();
    }

    protected void btnSetCharges_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/BillServiceCharges.aspx",false);
    }
}