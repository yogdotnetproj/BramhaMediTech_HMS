using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HealthPackageMaster : BaseClass
{
    BELHealthPackage objBELHPack = new BELHealthPackage();
    DALHealthPackage objDALHPack = new DALHealthPackage();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                show.Visible = false;
                List.Visible = true;
                FillGrid();
                txtFromDate.Text = DateTime.Now.ToString("dd/MM/yyy");
                txtToDate.Text = DateTime.Now.ToString("dd/MM/yyy");
            }
            catch (Exception)
            {
            }
        }


    }

    protected void FillGrid()
    {

        gvHealthPackage.DataSource = objDALHPack.FillGrid();
        gvHealthPackage.DataBind();
    }  


    
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string Message = "";

        if (Convert.ToInt32(ViewState["HPackId"]) > 0)
        {
            objBELHPack.HPackId = Convert.ToInt32(ViewState["HPackId"]);
            objBELHPack.HPackName = txtPackName.Text;
            objBELHPack.HPackAmount = Convert.ToDecimal(txtPackAmount.Text);
            objBELHPack.HPackDetails = txtPackDetails.Text;
            objBELHPack.FromDate = Convert.ToDateTime(txtFromDate.Text);
            objBELHPack.ToDate = Convert.ToDateTime(txtToDate.Text);

            if (chkIpd.Checked)
                objBELHPack.IsIpd = true;
            else
                objBELHPack.IsOpd = false;

            if (chkOpd.Checked)
                objBELHPack.IsOpd = true;
            else
                objBELHPack.IsOpd = false;

            objBELHPack.UpdatedBy = Convert.ToString(Session["username"]);
            Message = objDALHPack.UpdateHpack(objBELHPack);
        }
        else
        {
            objBELHPack.HPackName = txtPackName.Text;
            objBELHPack.HPackAmount = Convert.ToDecimal(txtPackAmount.Text);
            objBELHPack.HPackDetails = txtPackDetails.Text;
            objBELHPack.FromDate = Convert.ToDateTime(txtFromDate.Text);
            objBELHPack.ToDate = Convert.ToDateTime(txtToDate.Text);

            if (chkIpd.Checked)
                objBELHPack.IsIpd = true;
            else
                objBELHPack.IsOpd = false;

            if (chkOpd.Checked)
                objBELHPack.IsOpd = true;
            else
                objBELHPack.IsOpd = false;

            objBELHPack.CreatedBy = Convert.ToString(Session["username"]);
            objBELHPack.BranchId = Convert.ToInt32(Session["BranchId"]);
            objBELHPack.FId = "1";
            Message = objDALHPack.InsertHpack(objBELHPack);
        }

        Reset();
        DynamicMessage(lblMessage, Message);
        show.Visible = false;
        List.Visible = true;
        FillGrid();

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
    }

    private void Reset()
    {
        

        ViewState["HPackId"] = 0;
        txtPackDetails.Text = "";
        txtPackAmount.Text = "";
        txtPackName.Text = "";        
        chkOpd.Checked = false;
        chkIpd.Checked = false;
        
        lblMessage.Text = "";
    }

    protected void gvHealthPackage_RowEditing(object sender, GridViewEditEventArgs e)
    {
        
        show.Visible = true;
        List.Visible = false;

        try
        {
            string HPackId = (gvHealthPackage.DataKeys[e.NewEditIndex]["HPackId"].ToString());
            ViewState["HPackId"] = HPackId;
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

        objBELHPack = objDALHPack.SelectOne(Convert.ToInt32(ViewState["HPackId"]));
        txtPackName.Text = objBELHPack.HPackName;
        txtPackDetails.Text = objBELHPack.HPackDetails;
        txtPackAmount.Text =Convert.ToString(objBELHPack.HPackAmount);
        txtFromDate.Text = Convert.ToString(objBELHPack.FromDate);
        txtToDate.Text = Convert.ToString(objBELHPack.ToDate);
        if (objBELHPack.IsIpd == true)
            chkIpd.Checked = true;
        if (objBELHPack.IsOpd == true)
            chkOpd.Checked = true;
    }


    protected void gvHealthPackage_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string HPackId = (gvHealthPackage.DataKeys[e.RowIndex]["HPackId"].ToString());

        string Message = objDALHPack.DeleteHPack(Convert.ToInt32(HPackId));

        DynamicMessage(lblMessage, Message);

        FillGrid();

    }

    protected void gvHealthPackage_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvHealthPackage.PageIndex = e.NewPageIndex;
        FillGrid();
    }

    protected void btnAddService_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        GridViewRow row = (GridViewRow)btn.NamingContainer;

        int HPackId = Convert.ToInt32(gvHealthPackage.DataKeys[row.RowIndex]["HPackId"].ToString());
       
        Response.Redirect("AddServicesToPackage.aspx?HPackId=" + HPackId + "");
    }
}