using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OperationType :BasePage
{
    BELOperationTheater objBELOt = new BELOperationTheater();
    DALOperationTheater objDALOt = new DALOperationTheater();
        
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillOpCatGrid();

            show.Visible = false;
            List.Visible = true;

        }
    }
    protected void FillOpCatGrid()
    {
        gvOpCat.DataSource = objDALOt.FillGridOpCat();
        gvOpCat.DataBind();
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {

        string Message = "";

        if (!(txtOpCat.Text.Equals(string.Empty)))
        {
            if (Convert.ToInt32(ViewState["OprnId"]) > 0)
            {
               // objBELOt = objDALOt.SelectOneOpCat(Convert.ToInt32(ViewState["OprnId"]));
                objBELOt.OprnCat = txtOpCat.Text;
                objBELOt.OprnCatId = Convert.ToInt32(ViewState["OprnId"]);
                objBELOt.UpdatedBy = Convert.ToString(Session["username"]);

                Message = objDALOt.UpdateOpCat(objBELOt);
            }
            else
            {
                objBELOt.OprnCat = txtOpCat.Text;
                objBELOt.FId = "1";
                objBELOt.BranchId = Convert.ToInt32(Session["Branchid"]);
                objBELOt.CreatedBy = Convert.ToString(Session["username"]);

                Message = objDALOt.InsertOpCat(objBELOt);
            }

            DynamicMessage(lblMessage, Message);

            FillOpCatGrid();
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
        txtOpCat.Text = "";

        ViewState["OprnId"] = 0;
        lblMessage.Text = "";
        show.Visible = false;
        List.Visible = true;

    }
    private void clearall()
    {
        txtOpCat.Text = "";
        ViewState["OprnId"] = 0;

    }

    protected void FillPage()
    {
        try
        {
            objBELOt = objDALOt.SelectOneOpCat(Convert.ToInt32(ViewState["OprnId"]));
            txtOpCat.Text = objBELOt.OprnCat;


        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }

    protected void gvOpCat_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            show.Visible = true;
            List.Visible = false;

            string OprnCatId = (gvOpCat.DataKeys[e.NewEditIndex]["OprnCatId"].ToString());
            ViewState["OprnId"] = OprnCatId;
            FillPage();
            e.Cancel = true;
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }

    }
    protected void gvOpCat_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string OprnCatId = (gvOpCat.DataKeys[e.RowIndex]["OprnCatId"].ToString());

        string Message = objDALOt.DeleteOpCat(Convert.ToInt32(OprnCatId));
        DynamicMessage(lblMessage, Message);

        FillOpCatGrid();
        clearall();

    }
    protected void gvOpCat_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvOpCat.PageIndex = e.NewPageIndex;
        FillOpCatGrid();
    }
    
}