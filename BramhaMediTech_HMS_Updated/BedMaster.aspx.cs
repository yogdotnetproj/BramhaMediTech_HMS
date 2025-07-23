using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BedMaster : BaseClass
{
    BELRoom objBELRoom = new BELRoom();
    DALRoom objDALRoom = new DALRoom();
    string Message = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

          
            FillRoomAddressDrop();
            
        }
    }


    protected void FillBedMasterGrid()
    {
        gvBedMaster.DataSource = objDALRoom.FillGridBedMaster(Convert.ToInt32(ddlRoomName.SelectedValue), Convert.ToInt32(Session["FId"]),Convert.ToInt32(Session["BranchId"]));
        gvBedMaster.DataBind();
    }

    protected void FillRoomAddressDrop()
    {

        ddlRoomAddress.DataSource = objDALRoom.FillRoomAddressCombo();
        ddlRoomAddress.DataTextField = "RoomAddress";
        ddlRoomAddress.DataValueField = "RoomAddress";
        ddlRoomAddress.DataBind();
        ddlRoomAddress.Items.Insert(0,new ListItem("Select Room Location","0"));
        ddlRoomAddress.SelectedIndex = 0;
    }


    protected void ddlRoomAddress_SelectedIndexChanged(object sender, EventArgs e)
    {
       string RoomAddress = Convert.ToString(ddlRoomAddress.SelectedValue);
        ViewState["RoomAddress"] = RoomAddress.ToString();
        FillRoomNameDrop(Convert.ToString(ViewState["RoomAddress"]));
    }

    protected void FillRoomNameDrop(string RoomAddress)
    {
        ddlRoomName.DataSource = objDALRoom.FillRoomNameCombo(RoomAddress);
        ddlRoomName.DataValueField = "RoomId";
        ddlRoomName.DataTextField = "RoomName";
        ddlRoomName.DataBind();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        
        //if (!(txtBedName.Text.Equals(string.Empty)))
        //{
            if (Convert.ToInt32(ViewState["BedId"]) > 0)
            {
               // objBELRoom = objDALRoom.SelectOneRoomMaster(Convert.ToInt32(ViewState["RoomId"]));
                objBELRoom.BedId = Convert.ToInt32(ViewState["BedId"]);
               // objBELRoom.BedNo = txtBedName.Text;
                
                    objBELRoom.RoomId = Convert.ToInt32(ddlRoomName.SelectedValue);

                
                    objBELRoom.RoomAddress = Convert.ToString(ddlRoomAddress.SelectedValue);


                objBELRoom.UpdatedBy = Session["username"].ToString();

                Message = objDALRoom.UpdateBedMaster(objBELRoom);
            }
            else
            {
                //objBELRoom.BedNo = txtBedName.Text;
                
                    objBELRoom.RoomAddress = Convert.ToString(ddlRoomAddress.SelectedValue);

                
                    objBELRoom.RoomId = Convert.ToInt32(ddlRoomName.SelectedValue);

               
                //objBELRoom.FId = "1";
                objBELRoom.BranchId = Convert.ToInt32(Session["Branchid"]);
                  objBELRoom.CreatedBy = Session["username"].ToString();
                  ddlRoomName_SelectedIndexChanged(null, null);
               // Message = objDALRoom.InsertBedMaster(objBELRoom);

            }

            Reset();
            DynamicMessage(lblMessage, Message);

            FillBedMasterGrid();
       // }
        

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
       
        ViewState["RoomId"] = 0;
        ViewState["RoomAddress"] =0;
        ddlRoomName.SelectedValue="0";
        ddlRoomAddress.SelectedIndex = 0;

    }

    protected void gvBedMaster_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            //show.Visible = true;
            //List.Visible = false;
            //string BedId = (gvBedMaster.DataKeys[e.NewEditIndex]["BedId"].ToString());
            //ViewState["BedId"] = BedId;
            //FillPage();
            //e.Cancel = true;
            gvBedMaster.EditIndex = e.NewEditIndex;
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
            objBELRoom = objDALRoom.SelectOneBedMaster(Convert.ToInt32(ViewState["BedId"]));          

            ddlRoomAddress.SelectedValue = Convert.ToString(objBELRoom.RoomAddress);
            ddlRoomName.SelectedValue = Convert.ToString(objBELRoom.RoomId);
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }


    protected void gvBedMaster_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        int BedId = Convert.ToInt32(gvBedMaster.DataKeys[e.RowIndex]["BedId"].ToString());

        string Message = objDALRoom.DeleteBedMaster(BedId);
            DynamicMessage(lblMessage, Message);
        
        FillBedMasterGrid();
    }
    
    protected void gvBedMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvBedMaster.PageIndex = e.NewPageIndex;
        FillBedMasterGrid();
    }

    protected void ddlRoomName_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["RoomId"] = Convert.ToInt32(ddlRoomName.SelectedValue);
        objBELRoom = objDALRoom.GetRoomInformation(Convert.ToInt32(ddlRoomName.SelectedValue), Convert.ToInt32(Session["FId"]), Convert.ToInt32(Session["Branchid"]));
        lblTotalBed.Text = Convert.ToString(objBELRoom.TotalBed);
        lblRoomType.Text = Convert.ToString(objBELRoom.RType);
        for (int i = 1; i <= Convert.ToInt32(lblTotalBed.Text); i++)
        {
            objBELRoom.BedNo = Convert.ToString(i);
            objBELRoom.RoomAddress = Convert.ToString(ddlRoomAddress.SelectedValue);
            objBELRoom.RoomId = Convert.ToInt32(ddlRoomName.SelectedValue);
            objBELRoom.BranchId = Convert.ToInt32(Session["Branchid"]);
            objBELRoom.FId = Convert.ToInt32(Session["FId"]);
            objBELRoom.CreatedBy = Session["username"].ToString();

            Message = objDALRoom.InsertBedMaster(objBELRoom);
        }

        FillBedMasterGrid();
            

    }
    protected void gvBedMaster_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int BedId = Convert.ToInt32(gvBedMaster.DataKeys[e.RowIndex]["BedId"].ToString());
        TextBox Bedname = gvBedMaster.Rows[e.RowIndex].FindControl("txt_BedName") as TextBox;
        objBELRoom.BedId = BedId;
        objBELRoom.BedNo = Bedname.Text;
        objBELRoom.FId = Convert.ToInt32(objBELRoom.FId);
        objBELRoom.BranchId = Convert.ToInt32(objBELRoom.BranchId);
        objBELRoom.UpdatedBy = Session["username"].ToString();
        objDALRoom.UpdateBedMaster(objBELRoom);
        gvBedMaster.EditIndex = -1;
        //Call ShowData method for displaying updated data  
        FillBedMasterGrid();
    }
    protected void gvBedMaster_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvBedMaster.EditIndex = -1;
        FillBedMasterGrid();
    }
}