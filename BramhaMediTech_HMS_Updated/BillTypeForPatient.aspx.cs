using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BillTypeForPatient : BaseClass
{
    BELPatBillType objBELBillType = new BELPatBillType();
    DALPatBillType objDALBillType = new DALPatBillType();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
                show.Visible = false;
                List.Visible = true;
                FillBillTypeGrid();
            
        }


    }
    protected void FillBillTypeGrid()
    {
        gvBillType.DataSource = objDALBillType.FillGrid();
        gvBillType.DataBind();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        string Message = "";

        if (Convert.ToInt32(ViewState["BillTypeId"]) > 0)
        {
            objBELBillType.BillTypeId = Convert.ToInt32(ViewState["BillTypeId"]);
            objBELBillType.BillType = txtBillType.Text;
            objBELBillType.UpdatedBy = Convert.ToString(Session["username"]);
            Message = objDALBillType.UpdateBillType(objBELBillType);
        }
        else
        {
            objBELBillType.BillType = txtBillType.Text;
            objBELBillType.CreatedBy = Convert.ToString(Session["username"]);
            objBELBillType.BranchId = Convert.ToInt32(Session["BranchId"]);
            objBELBillType.FId = "1";

            Message = objDALBillType.InsertBillType(objBELBillType);
        }


        DynamicMessage(lblMessage, Message);
        show.Visible = false;
        List.Visible = true;
        FillBillTypeGrid();
        Reset();
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
        show.Visible = false;
        List.Visible = true;
        lblMessage.Text = "";
    }

    private void Reset()
    {
        ViewState["BillTypeId"] = 0;
        txtBillType.Text = "";
    }

    protected void gvBillType_RowEditing(object sender, GridViewEditEventArgs e)
    {
        show.Visible = true;
        List.Visible = false;

        try
        {
            string BillTypeId = (gvBillType.DataKeys[e.NewEditIndex]["BillTypeId"].ToString());
            ViewState["BillTypeId"] = BillTypeId;
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

    private void ReadDO()
    {
        objBELBillType= objDALBillType.SelectOne(Convert.ToInt32(ViewState["BillTypeId"]));
        txtBillType.Text = objBELBillType.BillType;
        

    }


    protected void gvBillType_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string BillTypeId = (gvBillType.DataKeys[e.RowIndex]["BillTypeId"].ToString());

        string Message = objDALBillType.DeleteBillType(Convert.ToInt32(BillTypeId));

        DynamicMessage(lblMessage, Message);

        FillBillTypeGrid();

    }

    protected void gvBillType_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvBillType.PageIndex = e.NewPageIndex;
        FillBillTypeGrid();

    }
 
}