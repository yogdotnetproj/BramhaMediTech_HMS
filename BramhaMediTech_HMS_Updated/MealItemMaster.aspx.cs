using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MealItemMaster : BaseClass
{
    BELMeal objBELMeal = new BELMeal();
    DALMeal objDALMeal = new DALMeal();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillMealItemGrid();
            show.Visible = false;
            List.Visible = true;
            FillItemUnitDrop();

        }
    }

    protected void FillMealItemGrid()
    {

        gvMealItem.DataSource = objDALMeal.FillGridItemUnit();
        gvMealItem.DataBind();
    }
    protected void FillItemUnitDrop()
    {
        ddlUnit.DataSource = objDALMeal.FillItemUnitDrop();
        ddlUnit.DataTextField = "ItemUnitCode";
        ddlUnit.DataValueField = "ItemUnitCode";
        ddlUnit.DataBind();

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {

        string Message = "";

        if (!(txtItem.Text.Equals(string.Empty)))
        {
            if (Convert.ToInt32(ViewState["FoodItemId"]) > 0)
            {

                objBELMeal.FoodItemName = txtItem.Text;
                objBELMeal.FoodItemQty = Convert.ToInt32(txtItemQty.Text);
                objBELMeal.Calories = Convert.ToInt32(txtItemCalories.Text);
                objBELMeal.FoodItemQty = Convert.ToInt32(txtItemQty.Text);
                objBELMeal.FoodItemId = Convert.ToInt32(ViewState["FoodItemId"]);
                objBELMeal.UpdatedBy = Convert.ToString(Session["username"]);

                Message = objDALMeal.UpdateItemUnit(objBELMeal);
            }
            else
            {
                objBELMeal.FoodItemName = txtItem.Text;
                objBELMeal.FoodItemQty = Convert.ToInt32(txtItemQty.Text);
                objBELMeal.Calories = Convert.ToInt32(txtItemCalories.Text);
                objBELMeal.FoodItemQty = Convert.ToInt32(txtItemQty.Text);
                objBELMeal.FId = "1";
                objBELMeal.BranchId = Convert.ToInt32(Session["Branchid"]);
                objBELMeal.CreatedBy = Convert.ToString(Session["username"]);

                Message = objDALMeal.InsertMealItem(objBELMeal);
            }

            DynamicMessage(lblMessage, Message);

            FillMealItemGrid();
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

        txtItem.Text = "";
        txtItemCalories.Text = "";
        txtItemQty.Text = "";
        ddlUnit.SelectedValue = "0";

        ViewState["FoodItemId"] = 0;
        lblMessage.Text = "";
        show.Visible = false;
        List.Visible = true;

    }
    private void clearall()
    {
        
        ViewState["FoodItemId"] = 0;
    }

    protected void FillPage()
    {
        try
        {
            objBELMeal = objDALMeal.SelectOneMealItem(Convert.ToInt32(ViewState["FoodItemId"]));
            txtItem.Text = objBELMeal.FoodItemName;
            txtItemCalories.Text =Convert.ToString(objBELMeal.Calories);
            txtItemQty.Text =Convert.ToString(objBELMeal.FoodItemQty);
            ddlUnit.SelectedValue = objBELMeal.Unit;

        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }

    
    protected void gvMealItem_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvMealItem.PageIndex = e.NewPageIndex;
        FillMealItemGrid();
    }
    protected void gvMealItem_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            show.Visible = true;
            List.Visible = false;

            string FoodItemId = (gvMealItem.DataKeys[e.NewEditIndex]["FoodItemId"].ToString());
            ViewState["FoodItemId"] = FoodItemId;
            FillPage();
            e.Cancel = true;
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }

    }
    protected void gvMealItem_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string FoodItemId = (gvMealItem.DataKeys[e.RowIndex]["FoodItemId"].ToString());

        string Message = objDALMeal.DeleteMealItem(Convert.ToInt32(FoodItemId));
        DynamicMessage(lblMessage, Message);

        FillMealItemGrid();
        clearall();
    }
}