using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SpecBodyPartMst : BaseClass
{
    BELBodyPart objBELBodyPart = new BELBodyPart();
    DALBodyPart objDALBodyPart = new DALBodyPart();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillBpGrid();

            show.Visible = false;
            List.Visible = true;

        }
    }
    protected void FillBpGrid()
    {

        gvBodyPart.DataSource = objDALBodyPart.FillGridBodyPart();
        gvBodyPart.DataBind();
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {

        string Message = "";

        if (!(txtbodyPart.Text.Equals(string.Empty)))
        {
            if (Convert.ToInt32(ViewState["SpecimenId"]) > 0)
            {
                
                objBELBodyPart.SpecimenName = txtbodyPart.Text;
                objBELBodyPart.SpecimenId = Convert.ToInt32(ViewState["SpecimenId"]);
                objBELBodyPart.UpdatedBy = Convert.ToString(Session["username"]);

                Message = objDALBodyPart.UpdateBodyPart(objBELBodyPart);
            }
            else
            {
                objBELBodyPart.SpecimenName = txtbodyPart.Text;
                objBELBodyPart.FId = "1";
                objBELBodyPart.BranchId = Convert.ToInt32(Session["Branchid"]);
                objBELBodyPart.CreatedBy = Convert.ToString(Session["username"]);

                Message = objDALBodyPart.InsertBodyPart(objBELBodyPart);
            }

            DynamicMessage(lblMessage, Message);

            FillBpGrid();
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
        txtbodyPart.Text = "";

        ViewState["SpecimenId"] = 0;
        lblMessage.Text = "";
        show.Visible = false;
        List.Visible = true;

    }
    private void clearall()
    {
        txtbodyPart.Text = "";
        ViewState["SpecimenId"] = 0;

    }

    protected void FillPage()
    {
        try
        {
            objBELBodyPart = objDALBodyPart.SelectOneBodyPart(Convert.ToInt32(ViewState["SpecimenId"]));
            txtbodyPart.Text = objBELBodyPart.SpecimenName;


        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }

    protected void gvBodyPart_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            show.Visible = true;
            List.Visible = false;

            string SpecimenId = (gvBodyPart.DataKeys[e.NewEditIndex]["SpecimenId"].ToString());
            ViewState["SpecimenId"] = SpecimenId;
            FillPage();
            e.Cancel = true;
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }

    }
    protected void gvBodyPart_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string SpecimenId = (gvBodyPart.DataKeys[e.RowIndex]["SpecimenId"].ToString());

        string Message = objDALBodyPart.DeleteBodyPart(Convert.ToInt32(SpecimenId));
        DynamicMessage(lblMessage, Message);

        FillBpGrid();
        clearall();

    }
    protected void gvBodyPart_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvBodyPart.PageIndex = e.NewPageIndex;
        FillBpGrid();
    }
    
}