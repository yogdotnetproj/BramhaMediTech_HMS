using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Supplier_Master : BaseClass
{
    BELRoom objBELRoom = new BELRoom();
    DALRoom objDALRoom = new DALRoom();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillRoomTypeGrid();

            show.Visible = false;
            List.Visible = true;

        }
    }

    protected void FillRoomTypeGrid()
    {

        gvRoomType.DataSource = objDALRoom.FillGrid_SupplierMaster();
        gvRoomType.DataBind();
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {

        string Message = "";

        if (!(txtRoomType.Text.Equals(string.Empty)))
        {
            if (Convert.ToInt32(ViewState["Suppid"]) > 0)
            {
                // objBELOt = objDALOt.SelectOneOpCat(Convert.ToInt32(ViewState["OprnId"]));
                objBELRoom.RType = txtRoomType.Text;
                objBELRoom.RTypeId = Convert.ToInt32(ViewState["Suppid"]);
                objBELRoom.UpdatedBy = Convert.ToString(Session["username"]);

                Message = objDALRoom.Update_Supplier(objBELRoom);
            }
            else
            {
                objBELRoom.RType = txtRoomType.Text;
                objBELRoom.FId = Convert.ToInt32(Session["FId"]); ;
                objBELRoom.BranchId = Convert.ToInt32(Session["Branchid"]);
                objBELRoom.CreatedBy = Convert.ToString(Session["username"]);

                Message = objDALRoom.Insert_Supplier(objBELRoom);
            }

            DynamicMessage(lblMessage, Message);

            FillRoomTypeGrid();
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
        txtRoomType.Text = "";

        ViewState["Suppid"] = 0;
        lblMessage.Text = "";
        show.Visible = false;
        List.Visible = true;

    }
    private void clearall()
    {
        txtRoomType.Text = "";
        ViewState["Suppid"] = 0;

    }

    protected void FillPage()
    {
        try
        {
            objBELRoom = objDALRoom.Select_SupplierMaster(Convert.ToInt32(ViewState["Suppid"]));
            txtRoomType.Text = objBELRoom.RType;
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }

    protected void gvRoomType_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            show.Visible = true;
            List.Visible = false;

            string RTypeId = (gvRoomType.DataKeys[e.NewEditIndex]["Suppid"].ToString());
            ViewState["Suppid"] = RTypeId;
            FillPage();
            e.Cancel = true;
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }

    }
    protected void gvRoomType_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string RTypeId = (gvRoomType.DataKeys[e.RowIndex]["Suppid"].ToString());

        string Message = objDALRoom.DeleteRoomType(Convert.ToInt32(RTypeId));
        DynamicMessage(lblMessage, Message);

        FillRoomTypeGrid();
        clearall();

    }
    protected void gvRoomType_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        gvRoomType.PageIndex = e.NewPageIndex;

        FillRoomTypeGrid();
    }


    
}