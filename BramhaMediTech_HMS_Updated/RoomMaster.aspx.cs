using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RoomMaster : BaseClass
{
    BELRoom objBELRoom = new BELRoom();
    DALRoom objDALRoom = new DALRoom();
    string Message = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            FillRoomMasterGrid();
            FillRoomTypeDrop();
            show.Visible = false;
            List.Visible = true;
        }

       
    }

    
    protected void FillRoomMasterGrid()
    {
        gvRoomMaster.DataSource = objDALRoom.FillGridRoomMaster();
        gvRoomMaster.DataBind();
    }

    protected void FillRoomTypeDrop()
    {
        ddlRoomTypeName.DataSource = objDALRoom.FillRoomTypeCombo();
        ddlRoomTypeName.DataTextField = "RType";
        ddlRoomTypeName.DataValueField = "RTypeId";
        ddlRoomTypeName.DataBind();
    }

   
    protected void txtRoomName_TextChanged(object sender, EventArgs e)
    {
        txtRoomName.Text = txtRoomName.Text.Trim();
    }

    
    protected void ddlRoomTypeName_SelectedIndexChanged(object sender, EventArgs e)
    {
        int RoomTypeId =Convert.ToInt32(ddlRoomTypeName.SelectedValue);
        ViewState[" RoomTypeId"] = RoomTypeId.ToString();
    }

   
    protected void btnSave_Click(object sender, EventArgs e)
    {
       
        if (!(txtRoomName.Text.Equals(string.Empty)))
        {
            if (Convert.ToInt32(ViewState["RoomId"]) > 0)
            {
                objBELRoom = objDALRoom.SelectOneRoomMaster(Convert.ToInt32(ViewState["RoomId"]));
                objBELRoom.RoomId = Convert.ToInt32(ViewState["RoomId"]);
                objBELRoom.RoomName = txtRoomName.Text;
                objBELRoom.RoomAddress = txtRoomAddress.Text;
                objBELRoom.TotalBed =Convert.ToInt32(txtTotalBed.Text);
                if (ViewState["RoomTypeId"] != null)
                    objBELRoom.RTypeId = Convert.ToInt32(ViewState["RoomTypeId"]);
                else
                    objBELRoom.RTypeId = Convert.ToInt32(Convert.ToString(ddlRoomTypeName.SelectedValue));
                    objBELRoom.UpdatedBy = Session["username"].ToString();
                    Message = objDALRoom.UpdateRoomMaster(objBELRoom);
            }
            else
            {
                objBELRoom.RoomName = txtRoomName.Text;
                objBELRoom.RoomAddress = Convert.ToString(txtRoomAddress.Text);
                objBELRoom.TotalBed = Convert.ToInt32(txtTotalBed.Text);
                objBELRoom.FId = Convert.ToInt32(Session["FId"]);
                objBELRoom.BranchId = Convert.ToInt32(Session["Branchid"]);
                if (ViewState["RoomTypeId"] != null)
                    objBELRoom.RTypeId = Convert.ToInt32(ViewState["RoomTypeId"]);
                else
                    objBELRoom.RTypeId = Convert.ToInt32(Convert.ToString(ddlRoomTypeName.SelectedValue));
                objBELRoom.CreatedBy = Session["username"].ToString();

                Message = objDALRoom.InsertRoomMaster(objBELRoom);
                
            }

            Reset();
            DynamicMessage(lblMessage, Message);
            
            FillRoomMasterGrid();
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
        Reset();
        lblMessage.Text = "";
        show.Visible = false;
        List.Visible = true;
    }

    private void Reset()
    {
        txtRoomName.Text = "";
        ViewState["RoomId"] = 0;
        ddlRoomTypeName.SelectedValue="0";
        txtRoomAddress.Text = "";

    }

    protected void gvRoomMaster_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            show.Visible = true;
            List.Visible = false;
            string RoomId = (gvRoomMaster.DataKeys[e.NewEditIndex]["RoomId"].ToString());
            ViewState["RoomId"] = RoomId;
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
            objBELRoom = objDALRoom.SelectOneRoomMaster(Convert.ToInt32(ViewState["RoomId"]));
            txtRoomName.Text = objBELRoom.RoomName;
            txtRoomAddress.Text = objBELRoom.RoomAddress;
            ddlRoomTypeName.SelectedValue = Convert.ToString(objBELRoom.RTypeId);
            txtTotalBed.Text = Convert.ToString(objBELRoom.TotalBed);
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }

    
    protected void gvRoomMaster_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        int RoomId = Convert.ToInt32(gvRoomMaster.DataKeys[e.RowIndex]["RoomId"].ToString());
       objBELRoom = objDALRoom.SelectBed(RoomId);
       int BedId = objBELRoom.BedId;
        if (BedId > 0)
        {
            Message = "0Beds Are available,Room Can not Be Deleted";
            DynamicMessage(lblMessage, Message);
        }
        else
        {
            string Message = objDALRoom.DeleteRoomMaster(RoomId);
            DynamicMessage(lblMessage, Message);
        }
        FillRoomMasterGrid();
    }
    protected void gvRoomMaster_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        gvRoomMaster.PageIndex = e.NewSelectedIndex;
        FillRoomMasterGrid();
    }
    protected void gvRoomMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvRoomMaster.PageIndex = e.NewPageIndex;
        FillRoomMasterGrid();
    }
   
}