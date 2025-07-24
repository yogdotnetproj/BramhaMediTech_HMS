using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProvisionalDiagnoMst :BasePage
{
    BELProvDiagno objBELProvDiagno = new BELProvDiagno();
    DALProvDiagno objDALProvDiagno = new DALProvDiagno();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillProvDiagnoGrid();

            show.Visible = false;
            List.Visible = true;

        }
    }
    protected void FillProvDiagnoGrid()
    {

        gvProvDiagno.DataSource = objDALProvDiagno.FillGridProvDiagno();
        gvProvDiagno.DataBind();
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {

        string Message = "";

        if (!(txtProvDiagno.Text.Equals(string.Empty)))
        {
            if (Convert.ToInt32(ViewState["ProvDiagnoId"]) > 0)
            {

                objBELProvDiagno.ProvDiagno = txtProvDiagno.Text;
                objBELProvDiagno.ProvDiagnoId = Convert.ToInt32(ViewState["ProvDiagnoId"]);
                objBELProvDiagno.UpdatedBy = Convert.ToString(Session["username"]);

                Message = objDALProvDiagno.UpdateProvDiagno(objBELProvDiagno);
            }
            else
            {
                objBELProvDiagno.ProvDiagno = txtProvDiagno.Text;
                objBELProvDiagno.FId = "1";
                objBELProvDiagno.BranchId = Convert.ToInt32(Session["Branchid"]);
                objBELProvDiagno.CreatedBy = Convert.ToString(Session["username"]);

                Message = objDALProvDiagno.InsertProvDiagno(objBELProvDiagno);
            }

            DynamicMessage(lblMessage, Message);

            FillProvDiagnoGrid();
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
        txtProvDiagno.Text = "";

        ViewState["ProvDiagnoId"] = 0;
        lblMessage.Text = "";
        show.Visible = false;
        List.Visible = true;

    }
    private void clearall()
    {
        txtProvDiagno.Text = "";
        ViewState["ProvDiagnoId"] = 0;

    }

    protected void FillPage()
    {
        try
        {
            objBELProvDiagno = objDALProvDiagno.SelectOneProvDiagno(Convert.ToInt32(ViewState["ProvDiagnoId"]));
            txtProvDiagno.Text = objBELProvDiagno.ProvDiagno;


        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }

    protected void gvProvDiagno_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            show.Visible = true;
            List.Visible = false;

            string ProvDiagnoId = (gvProvDiagno.DataKeys[e.NewEditIndex]["ProvDiagnoId"].ToString());
            ViewState["ProvDiagnoId"] = ProvDiagnoId;
            FillPage();
            e.Cancel = true;
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }

    }
    protected void gvProvDiagno_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string ProvDiagnoId = (gvProvDiagno.DataKeys[e.RowIndex]["ProvDiagnoId"].ToString());

        string Message = objDALProvDiagno.DeleteProvDiagno(Convert.ToInt32(ProvDiagnoId));
        DynamicMessage(lblMessage, Message);

        FillProvDiagnoGrid();
        clearall();

    }
    protected void gvProvDiagno_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvProvDiagno.PageIndex = e.NewPageIndex;
        FillProvDiagnoGrid();
    }
    
}