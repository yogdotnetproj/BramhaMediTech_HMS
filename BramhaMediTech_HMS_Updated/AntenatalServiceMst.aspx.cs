using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AntenatalServiceMst : BaseClass
{
    BELAntenatal objBELAnte = new BELAntenatal();
    DALAntenatal objDALAnte = new DALAntenatal();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillAnteServGrid();
            GetMaxOrderNo();
            show.Visible = false;
            List.Visible = true;

        }
    }
    protected void GetMaxOrderNo()
    {
      objBELAnte = objDALAnte.GetMaxOrderNo();
      txtOrderNo.Text = Convert.ToString(objBELAnte.OrderNo);

    }
    protected void FillAnteServGrid()
    {

        gvAnteServ.DataSource = objDALAnte.FillGridAnte();
        gvAnteServ.DataBind();
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {

        string Message = "";

        if (!(txtAnteServ.Text.Equals(string.Empty)))
        {
            if (Convert.ToInt32(ViewState["GyParticularId"]) > 0)
            {
                // objBELOt = objDALOt.SelectOneOpCat(Convert.ToInt32(ViewState["OprnId"]));
                objBELAnte.Particular = txtAnteServ.Text;
                objBELAnte.GyParticularId = Convert.ToInt32(ViewState["GyParticularId"]);
                objBELAnte.UpdatedBy = Convert.ToString(Session["username"]);

                Message = objDALAnte.UpdateAnte(objBELAnte);
            }
            else
            {
                objBELAnte.Particular = txtAnteServ.Text;
                objBELAnte.OrderNo =Convert.ToInt32( txtOrderNo.Text);
                objBELAnte.FId = "1";
                objBELAnte.BranchId = Convert.ToInt32(Session["Branchid"]);
                objBELAnte.CreatedBy = Convert.ToString(Session["username"]);

                Message = objDALAnte.InsertAnte(objBELAnte);
            }

            DynamicMessage(lblMessage, Message);

            FillAnteServGrid();
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
        txtAnteServ.Text = "";

        ViewState["GyParticularId"] = 0;
        lblMessage.Text = "";
        show.Visible = false;
        List.Visible = true;

    }
    private void clearall()
    {
        txtAnteServ.Text = "";
        ViewState["GyParticularId"] = 0;

    }

    protected void FillPage()
    {
        try
        {
            objBELAnte = objDALAnte.SelectOneAnte(Convert.ToInt32(ViewState["GyParticularId"]));
            txtAnteServ.Text = objBELAnte.Particular;
            txtOrderNo.Text =Convert.ToString( objBELAnte.OrderNo);


        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }

    protected void gvAnteServ_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            show.Visible = true;
            List.Visible = false;

            string GyParticularId = (gvAnteServ.DataKeys[e.NewEditIndex]["GyParticularId"].ToString());
            ViewState["GyParticularId"] = GyParticularId;
            FillPage();
            e.Cancel = true;
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }

    }
    protected void gvAnteServ_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string GyParticularId = (gvAnteServ.DataKeys[e.RowIndex]["GyParticularId"].ToString());

        string Message = objDALAnte.DeleteAnte(Convert.ToInt32(GyParticularId));
        DynamicMessage(lblMessage, Message);

        FillAnteServGrid();
        clearall();

    }
    protected void gvAnteServ_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvAnteServ.PageIndex = e.NewPageIndex;

        FillAnteServGrid();
    }
    
}