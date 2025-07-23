using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MealItemUnit : BaseClass
{
    BELMeal objBELMeal = new BELMeal();
    DALMeal objDALMeal = new DALMeal();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillItemUnitGrid();
            show.Visible = false;
            List.Visible = true;

        }
    }

    protected void FillItemUnitGrid()
    {

        gvUnit.DataSource = objDALMeal.FillGridItemUnit();
        gvUnit.DataBind();
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {

        string Message = "";

        if (!(txtItemUnit.Text.Equals(string.Empty)))
        {
            if (Convert.ToInt32(ViewState["ItemUnitId"]) > 0)
            {
                // objBELOt = objDALOt.SelectOneOpCat(Convert.ToInt32(ViewState["OprnId"]));
                objBELMeal.ItemUnitName = txtItemUnit.Text;
                objBELMeal.ItemUnitCode = txtItemUnitCode.Text;
                objBELMeal.ItemUnitId = Convert.ToInt32(ViewState["ItemUnitId"]);
                objBELMeal.UpdatedBy = Convert.ToString(Session["username"]);

                Message = objDALMeal.UpdateItemUnit(objBELMeal);
            }
            else
            {
                objBELMeal.ItemUnitName = txtItemUnit.Text;
                objBELMeal.ItemUnitCode = txtItemUnitCode.Text;
                objBELMeal.FId = "1";
                objBELMeal.BranchId = Convert.ToInt32(Session["Branchid"]);
                objBELMeal.CreatedBy = Convert.ToString(Session["username"]);

                Message = objDALMeal.InsertItemUnit(objBELMeal);
            }

            DynamicMessage(lblMessage, Message);

            FillItemUnitGrid();
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

        txtItemUnit.Text = "";
        txtItemUnitCode.Text = "";
        ViewState["ItemUnitId"] = 0;
        lblMessage.Text = "";
        show.Visible = false;
        List.Visible = true;

    }
    private void clearall()
    {
        txtItemUnit.Text = "";
        txtItemUnitCode.Text = "";
        ViewState["ItemUnitId"] = 0;
    }

    protected void FillPage()
    {
        try
        {
            objBELMeal = objDALMeal.SelectOneItemUnit(Convert.ToInt32(ViewState["ItemUnitId"]));
            txtItemUnit.Text = objBELMeal.ItemUnitName;
            txtItemUnitCode.Text = Convert.ToString(objBELMeal.ItemUnitCode);


        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }

    protected void gvUnit_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            show.Visible = true;
            List.Visible = false;

            string ItemUnitId = (gvUnit.DataKeys[e.NewEditIndex]["ItemUnitId"].ToString());
            ViewState["ItemUnitId"] = ItemUnitId;
            FillPage();
            e.Cancel = true;
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }

    }
    protected void gvUnit_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string ItemUnitId = (gvUnit.DataKeys[e.RowIndex]["ItemUnitId"].ToString());

        string Message = objDALMeal.DeleteItemUnit(Convert.ToInt32(ItemUnitId));
        DynamicMessage(lblMessage, Message);

        FillItemUnitGrid();
        clearall();

    }
    protected void gvUnit_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvUnit.PageIndex = e.NewPageIndex;
        FillItemUnitGrid();
    }

}