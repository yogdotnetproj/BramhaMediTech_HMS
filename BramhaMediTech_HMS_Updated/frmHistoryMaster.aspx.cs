using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmHistoryMaster : BasePage
{
    cls_frmHistoryMaster objHis = new cls_frmHistoryMaster();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindHistoryDrop();
            BindMainGrid();
        }
    }

    private void BindMainGrid()
    {
        try
        {
            int typeId = drpCategory.SelectedIndex;

            gdvHistory.DataSource = objHis.GetHis(typeId);
            gdvHistory.DataBind();
        }
        catch (Exception)
        {
        }
    }

    protected void drpCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (drpCategory.SelectedIndex > 0)
            {
                btnSave.Enabled = true;
            }
            else
            {
                btnSave.Enabled = false;
            }

            BindMainGrid();
        }
        catch (Exception)
        {
        }

    }

    public void BindHistoryDrop()
    {
        try
        {
            drpCategory.DataSource = objHis.GetHisMaster();
            drpCategory.DataValueField = "historyMasterId";
            drpCategory.DataTextField = "historyMasterName";
            drpCategory.DataBind();
            drpCategory.Items.Insert(0, new ListItem("--Select--", "-1"));
            drpCategory.SelectedIndex = 0;
        }
        catch (Exception)
        {
        }
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        int typeId = Convert.ToInt32(drpCategory.SelectedItem.Value);
        string newTypeName = txtNewType.Text;
        int recId = string.IsNullOrEmpty(txtNewCatId.Value) ? 0 : Convert.ToInt32(txtNewCatId.Value);

        if (recId == 0)
        {
            int res = objHis.InsertUpdateDelete(typeId, recId, newTypeName, "Insert");
            if (res > 0)
            {
                lblMsg.Text = "Record inserted successfully.";
                lblMsg.ForeColor = System.Drawing.Color.Green;
                lblMsg.Visible = true;

                btnCancel_Click(null, null);
                gdvHistory.EditIndex = -1;
            }
            else
            {
                lblMsg.Text = "Failed to insert.";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Visible = true;
            }

        }
        else
        {
            int res = objHis.InsertUpdateDelete(typeId, recId, newTypeName, "Update");
            if (res > 0)
            {
                lblMsg.Text = "Record updated successfully.";
                lblMsg.Visible = true;
                lblMsg.ForeColor = System.Drawing.Color.Green;
                btnCancel_Click(null, null);
                gdvHistory.EditIndex = -1;
            }
            else
            {
                lblMsg.Text = "Failed to update.";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Visible = true;
            }
        }

        BindMainGrid();
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        drpCategory.SelectedIndex = -1;
        txtNewType.Text = "";
        txtNewCatId.Value = "0";
        lblMsg.Text = "";
        lblMsg.Visible = false;
    }

    protected void gdvHistory_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvHistory.PageIndex = e.NewPageIndex;
        BindMainGrid();
    }

    protected void gdvHistory_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int rowIndex = e.NewEditIndex;
        string catId1 = (gdvHistory.DataKeys[e.NewEditIndex]["catId"].ToString());
        ViewState["catId"] = txtNewCatId.Value = catId1;

        GridViewRow row = (GridViewRow)gdvHistory.Rows[rowIndex];

        Label catId = (Label)row.FindControl("catId");
        Label catName = (Label)row.FindControl("catName");
        Label historyMasterName = (Label)row.FindControl("historyMasterName");

        txtNewType.Text = catName.Text;
        try
        {
            int index = drpCategory.Items.IndexOf(drpCategory.Items.FindByText(historyMasterName.Text));
            drpCategory.SelectedIndex = index;

        }
        catch (Exception)
        {
            drpCategory.SelectedIndex = -1;
        }

    }

    private void FillPage()
    {

    }

    protected void Edit_Click(object sender, EventArgs e)
    {
    }

    protected void gdvHistory_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gdvHistory.EditIndex = -1;
    }

    protected void gdvHistory_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {


            string catId1 = (gdvHistory.DataKeys[e.RowIndex]["catId"].ToString());
            ViewState["catId"] = txtNewCatId.Value = catId1;

            GridViewRow row = (GridViewRow)gdvHistory.Rows[e.RowIndex];

            Label catId = (Label)row.FindControl("catId");
            Label catName = (Label)row.FindControl("catName");
            Label historyMasterName = (Label)row.FindControl("historyMasterName");
            int index = drpCategory.Items.IndexOf(drpCategory.Items.FindByText(historyMasterName.Text));
            drpCategory.SelectedIndex = index;
            int typeId = Convert.ToInt32(drpCategory.SelectedItem.Value);

            int res = objHis.InsertUpdateDelete(typeId, Convert.ToInt32(catId.Text), "", "Delete");
            if (res > 0)
            {
                lblMsg.Text = "Record deleted successfully.";
                lblMsg.Visible = true;
                lblMsg.ForeColor = System.Drawing.Color.Green;
                btnCancel_Click(null, null);
                gdvHistory.EditIndex = -1;
                BindMainGrid();
            }
            else
            {
                lblMsg.Text = "Failed to delete.";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Visible = true;
            }
        }
        catch (Exception)
        {

            lblMsg.Text = "Error occurred.";
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Visible = true;
        }
    }

    protected void gdvHistory_PreRender(object sender, EventArgs e)
    {
        GridView gv = (GridView)sender;
        GridViewRow gvr = (GridViewRow)gv.BottomPagerRow;
        if (gvr != null)
        {
            gvr.Visible = true;
        }
    }

    protected void gdvHistory_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[0].Text = "Page " + (gdvHistory.PageIndex + 1) + " of " + gdvHistory.PageCount;
        }
    }
}