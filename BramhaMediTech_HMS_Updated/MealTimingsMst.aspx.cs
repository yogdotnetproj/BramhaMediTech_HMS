using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MealTimingsMst : BaseClass
{
    BELMeal objBELMeal = new BELMeal();
    DALMeal objDALMeal = new DALMeal();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillMealTimeGrid();
            GetMaxOrderNo();
            show.Visible = false;
            List.Visible = true;

        }
    }
    protected void GetMaxOrderNo()
    {
        objBELMeal = objDALMeal.GetMaxOrderNo();
        txtOrderNo.Text = Convert.ToString(objBELMeal.OrderNo);

    }
    protected void FillMealTimeGrid()
    {

        gvMealTime.DataSource = objDALMeal.FillGridMealTime();
        gvMealTime.DataBind();
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {

        string Message = "";

        if (!(txtMealTime.Text.Equals(string.Empty)))
        {
            if (Convert.ToInt32(ViewState["MealTimeId"]) > 0)
            {
                // objBELOt = objDALOt.SelectOneOpCat(Convert.ToInt32(ViewState["OprnId"]));
                objBELMeal.MealTime = txtMealTime.Text;
                objBELMeal.MealTimeId = Convert.ToInt32(ViewState["MealTimeId"]);
                objBELMeal.UpdatedBy = Convert.ToString(Session["username"]);

                Message = objDALMeal.UpdateMealTime(objBELMeal);
            }
            else
            {
                objBELMeal.MealTime = txtMealTime.Text;
                objBELMeal.OrderNo = Convert.ToInt32(txtOrderNo.Text);
                objBELMeal.FId = "1";
                objBELMeal.BranchId = Convert.ToInt32(Session["Branchid"]);
                objBELMeal.CreatedBy = Convert.ToString(Session["username"]);

                Message = objDALMeal.InsertMealTime(objBELMeal);
            }

            DynamicMessage(lblMessage, Message);

            FillMealTimeGrid();
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
        GetMaxOrderNo();
    }


    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtMealTime.Text = "";

        ViewState["MealTimeId"] = 0;
        lblMessage.Text = "";
        show.Visible = false;
        List.Visible = true;

    }
    private void clearall()
    {
        txtMealTime.Text = "";
        ViewState["MealTimeId"] = 0;

    }

    protected void FillPage()
    {
        try
        {
            objBELMeal = objDALMeal.SelectOneMealTime(Convert.ToInt32(ViewState["MealTimeId"]));
            txtMealTime.Text = objBELMeal.MealTime;          
            txtOrderNo.Text = Convert.ToString(objBELMeal.OrderNo);


        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }

    protected void gvMealTime_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            show.Visible = true;
            List.Visible = false;

            string MealTimeId = (gvMealTime.DataKeys[e.NewEditIndex]["MealTimeId"].ToString());
            ViewState["MealTimeId"] = MealTimeId;
            FillPage();
            e.Cancel = true;
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }

    }
    protected void gvMealTime_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string MealTimeId = (gvMealTime.DataKeys[e.RowIndex]["MealTimeId"].ToString());

        string Message = objDALMeal.DeleteMealTime(Convert.ToInt32(MealTimeId));
        DynamicMessage(lblMessage, Message);

        FillMealTimeGrid();
        clearall();

    }
    protected void gvMealTime_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvMealTime.PageIndex = e.NewPageIndex;
        FillMealTimeGrid();
    }

    
}