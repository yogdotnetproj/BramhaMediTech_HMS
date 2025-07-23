using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OTMaster : BaseClass
{
    BELOperationTheater objBELOt = new BELOperationTheater();
    DALOperationTheater objDALOt = new DALOperationTheater();
        
   

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillOTGrid();

            show.Visible = false;
            List.Visible = true;

        }
    }
    protected void FillOTGrid()
    {
        gvOT.DataSource = objDALOt.FillGridOT();
        gvOT.DataBind();
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {

        string Message = "";

        if (!(txtOTType.Text.Equals(string.Empty)))
        {
            if (Convert.ToInt32(ViewState["OTId"]) > 0)
            {
                //objBELOt= objDALOt.SelectOneOT(Convert.ToInt32(ViewState["OTId"]));
                objBELOt.OTType = txtOTType.Text;
                objBELOt.OTId = Convert.ToInt32(ViewState["OTId"]);
                objBELOt.UpdatedBy = Convert.ToString(Session["username"]);

                Message = objDALOt.UpdateOT(objBELOt);
            }
            else
            {
                objBELOt.OTType = txtOTType.Text;
                objBELOt.FId = "1";
                objBELOt.BranchId = Convert.ToInt32(Session["Branchid"]);
                objBELOt.CreatedBy = Convert.ToString(Session["username"]);

                Message = objDALOt.InsertOT(objBELOt);
            }

            DynamicMessage(lblMessage, Message);

            FillOTGrid();
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
        txtOTType.Text = "";
        ViewState["OTId"] = 0;
        lblMessage.Text = "";
        show.Visible = false;
        List.Visible = true;

    }
    private void clearall()
    {
        txtOTType.Text = "";
        ViewState["OTId"] = 0;

    }

    protected void FillPage()
    {
        try
        {
            objBELOt = objDALOt.SelectOneOT(Convert.ToInt32(ViewState["OTId"]));
            txtOTType.Text = objBELOt.OTType;


        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }

    protected void gvOT_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            show.Visible = true;
            List.Visible = false;

            string OTId = (gvOT.DataKeys[e.NewEditIndex]["OTId"].ToString());
            ViewState["OTId"] = OTId;
            FillPage();
            e.Cancel = true;
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }

    }
    protected void gvOT_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string OTId = (gvOT.DataKeys[e.RowIndex]["OTId"].ToString());

        string Message = objDALOt.DeleteOT(Convert.ToInt32(OTId));
        DynamicMessage(lblMessage, Message);

        FillOTGrid();
        clearall();

    }
    protected void gvOT_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvOT.PageIndex = e.NewPageIndex;
        FillOTGrid();
    }
    
}