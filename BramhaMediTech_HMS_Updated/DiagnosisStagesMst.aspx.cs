using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DiagnosisStagesMst :  BaseClass
{
    BELDiagno objBELDiagno = new BELDiagno();
    DALDiagno objDALDiagno = new DALDiagno();

    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
            Diagno1.Visible = true;
            Diagno2.Visible = false;
            Diagno3.Visible = false;
            FillDiagno1Grid();
            FillDiagno1Drop();
            FillDiagno2Drop();
           

        }
    }

    protected void FillDiagno1Grid()
    {
        gvDiagno1.DataSource = objDALDiagno.FillGridDiagno1();
        gvDiagno1.DataBind();
    }
    protected void FillDiagno2Grid(int TrDiagnoId)
    {

        gvDiagno2.DataSource = objDALDiagno.FillGridDiagno2(TrDiagnoId);
        gvDiagno2.DataBind();
    }
    protected void FillDiagno3Grid(int TrDiagnostage2Id)
    {

        gvDiagno3.DataSource = objDALDiagno.FillGridDiagno3(TrDiagnostage2Id);
        gvDiagno3.DataBind();
    }
    protected void btnDstage1_Click(object sender, EventArgs e)
    {
        Diagno1.Visible = true;
        Diagno2.Visible = false;
        Diagno3.Visible = false;
    }
    protected void btnDstage2_Click(object sender, EventArgs e)
    {
        Diagno1.Visible = false;
        Diagno2.Visible = true;
        Diagno3.Visible = false;
    }
    protected void btnDstage3_Click(object sender, EventArgs e)
    {
        Diagno1.Visible = false;
        Diagno2.Visible = false;
        Diagno3.Visible = true;
    }

    //__________________________________Diagno1_______________________________________________

   
    protected void btnsaveD1_Click(object sender, EventArgs e)
    {
        string Message = "";

        if (!(txtDiagnosis1.Text.Equals(string.Empty)))
        {
            if (Convert.ToInt32(ViewState["TrDiagnoId"]) > 0)
            {
                // objBELOt = objDALOt.SelectOneOpCat(Convert.ToInt32(ViewState["OprnId"]));
                objBELDiagno.TrDiagnoName = txtDiagnosis1.Text;
                objBELDiagno.TrDiagnoId = Convert.ToInt32(ViewState["TrDiagnoId"]);
                objBELDiagno.ICDId = txtICDCode.Text;
                objBELDiagno.UpdatedBy = Convert.ToString(Session["username"]);

                Message = objDALDiagno.UpdateDiagno1(objBELDiagno);
            }
            else
            {
                objBELDiagno.TrDiagnoName = txtDiagnosis1.Text;
                objBELDiagno.ICDId = txtICDCode.Text;
                objBELDiagno.BranchId = Convert.ToInt32(Session["Branchid"]);
                objBELDiagno.CreatedBy = Convert.ToString(Session["username"]);
                Message = objDALDiagno.InsertDiagno1(objBELDiagno);
            }

            DynamicMessage(lblMessage, Message);

            FillDiagno1Grid();
            
        }
    }
    protected void btnResetD1_Click(object sender, EventArgs e)
    {
        txtDiagnosis1.Text = "";
        txtICDCode.Text = "";
    }
    protected void gvDiagno1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDiagno1.PageIndex = e.NewPageIndex;
        FillDiagno1Grid();

    }
    public void clearall()
    {
        txtDiagnosis1.Text = "";
        txtICDCode.Text = "";
    }
    protected void gvDiagno1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string TrDiagnoId = (gvDiagno1.DataKeys[e.RowIndex]["TrDiagnoId"].ToString());

        string Message = objDALDiagno.DeleteDiagno1(Convert.ToInt32(TrDiagnoId));
        DynamicMessage(lblMessage, Message);

        FillDiagno1Grid();
        clearall();

    }
    protected void FillDiagno1Page()
    {
        try
        {
            objBELDiagno = objDALDiagno.SelectOneDiagno1(Convert.ToInt32(ViewState["TrDiagnoId"]));
            txtDiagnosis1.Text = objBELDiagno.TrDiagnoName;
            txtICDCode.Text = objBELDiagno.ICDId;           

        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void gvDiagno1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {

            string TrDiagnoId = (gvDiagno1.DataKeys[e.NewEditIndex]["TrDiagnoId"].ToString());
            ViewState["TrDiagnoId"] = TrDiagnoId;
            FillDiagno1Page();
            e.Cancel = true;
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }

    //____________________________________Diagno2_____________________________________________

    protected void FillDiagno1Drop()
    {
        ddlParentDiagno.DataSource = objDALDiagno.FillDiagno1Drop();
        ddlParentDiagno.DataValueField = "TrDiagnoId";  
        ddlParentDiagno.DataTextField = "TrDiagnoName";                     
        ddlParentDiagno.DataBind();
    }
    protected void ddlParentDiagno_SelectedIndexChanged(object sender, EventArgs e)
    {
        int TrDiagnoId = Convert.ToInt32(ddlParentDiagno.SelectedValue);
        FillDiagno2Grid(TrDiagnoId);
    }
    protected void btnSaveDiagno2_Click(object sender, EventArgs e)
    {
        string Message = "";
        
           
        if (!(txtDiagno2.Text.Equals(string.Empty)))
        {
            if (Convert.ToInt32(ViewState["TrDiagnostage2Id"]) > 0)
            {
                // objBELOt = objDALOt.SelectOneOpCat(Convert.ToInt32(ViewState["OprnId"]));
                objBELDiagno.TrDiagnoNameStg2 = txtDiagno2.Text;
                objBELDiagno.TrDiagnostage2Id = Convert.ToInt32(ViewState["TrDiagnostage2Id"]);
                objBELDiagno.TrDiagnoId = Convert.ToInt32(ddlParentDiagno.SelectedValue);
                objBELDiagno.Stage2Id = txtIcd2.Text;
                objBELDiagno.UpdatedBy = Convert.ToString(Session["username"]);

                Message = objDALDiagno.UpdateDiagno2(objBELDiagno);
            }
            else
            {
                objBELDiagno.TrDiagnoNameStg2 = txtDiagno2.Text;
                objBELDiagno.Stage2Id = txtIcd2.Text;
                objBELDiagno.TrDiagnoId = Convert.ToInt32(ddlParentDiagno.SelectedValue);
                objBELDiagno.BranchId = Convert.ToInt32(Session["Branchid"]);
                objBELDiagno.CreatedBy = Convert.ToString(Session["username"]);
                Message = objDALDiagno.InsertDiagno2(objBELDiagno);
            }

            DynamicMessage(lblMessage, Message);

            FillDiagno2Grid(Convert.ToInt32(ddlParentDiagno.SelectedValue));

        }
    }
    protected void btnResetDiagno2t_Click(object sender, EventArgs e)
    {
        clearall2();
    }
    public void clearall2()
    {
        ddlParentDiagno.SelectedValue = "0";
        txtIcd2.Text = "";
        txtDiagno2.Text = "";
    }
    protected void gvDiagno2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDiagno2.PageIndex = e.NewPageIndex;
        FillDiagno2Grid(Convert.ToInt32(ddlParentDiagno.SelectedValue));
    }
    protected void gvDiagno2_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string TrDiagnostage2Id = (gvDiagno2.DataKeys[e.RowIndex]["TrDiagnostage2Id"].ToString());

        string Message = objDALDiagno.DeleteDiagno2(Convert.ToInt32(TrDiagnostage2Id));
        DynamicMessage(lblMessage, Message);

        FillDiagno2Grid(Convert.ToInt32(ddlParentDiagno.SelectedValue));
        clearall();
    }
    protected void FillDiagno2Page()
    {
        try
        {
            objBELDiagno = objDALDiagno.SelectOneDiagno2(Convert.ToInt32(ViewState["TrDiagnostage2Id"]));
            txtDiagno2.Text = objBELDiagno.TrDiagnoNameStg2;
            ddlParentDiagno.SelectedValue =Convert.ToString(objBELDiagno.TrDiagnostage2Id);
            txtIcd2.Text = objBELDiagno.Stage2Id;

        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void gvDiagno2_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {

            string TrDiagnostage2Id = (gvDiagno2.DataKeys[e.NewEditIndex]["TrDiagnostage2Id"].ToString());
            ViewState["TrDiagnostage2Id"] = TrDiagnostage2Id;
            FillDiagno2Page();
            e.Cancel = true;
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }


    //____________________________________Diagno3_____________________________________________

    protected void FillDiagno2Drop()
    {
        ddlParentDiagno2.DataSource = objDALDiagno.FillDiagno2Drop();
        ddlParentDiagno2.DataValueField = "TrDiagnostage2Id";
        ddlParentDiagno2.DataTextField = "TrDiagnoNameStg2";
        ddlParentDiagno2.DataBind();
        ddlParentDiagno2.Items.Insert(0, "Select Parent Diagnosis");
        ddlParentDiagno2.SelectedIndex = 0;
    }
    protected void ddlParentDiagno2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlParentDiagno2.SelectedIndex > 0)
        {
            int TrDiagnostage2Id = Convert.ToInt32(ddlParentDiagno2.SelectedValue);
            FillDiagno3Grid(TrDiagnostage2Id);
        }
    }
    protected void gvDiagno3_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDiagno3.PageIndex = e.NewPageIndex;
        FillDiagno3Grid(Convert.ToInt32(ddlParentDiagno2.SelectedValue));
    }
    protected void btnSaveDiagno3_Click(object sender, EventArgs e)
    {
        string Message = "";


        if (!(txtDiagno3.Text.Equals(string.Empty)))
        {
            if (Convert.ToInt32(ViewState["TrDiagnostage3Id"]) > 0)
            {
                // objBELOt = objDALOt.SelectOneOpCat(Convert.ToInt32(ViewState["OprnId"]));
                objBELDiagno.TrDiagnoNameStg3 = txtDiagno3.Text;
                objBELDiagno.TrDiagnostage3Id = Convert.ToInt32(ViewState["TrDiagnostage3Id"]);
                objBELDiagno.Stage3Id = txtIcd3.Text;
                objBELDiagno.TrDiagnostage2Id = Convert.ToInt32(ddlParentDiagno2.SelectedValue);
                objBELDiagno.UpdatedBy = Convert.ToString(Session["username"]);

                Message = objDALDiagno.UpdateDiagno3(objBELDiagno);
            }
            else
            {
                objBELDiagno.TrDiagnoNameStg3 = txtDiagno3.Text;
                objBELDiagno.Stage3Id = txtIcd3.Text;
                objBELDiagno.TrDiagnostage2Id = Convert.ToInt32(ddlParentDiagno2.SelectedValue);
                objBELDiagno.BranchId = Convert.ToInt32(Session["Branchid"]);
                objBELDiagno.CreatedBy = Convert.ToString(Session["username"]);
                Message = objDALDiagno.InsertDiagno3(objBELDiagno);
            }

            DynamicMessage(lblMessage, Message);

            FillDiagno3Grid(Convert.ToInt32(ddlParentDiagno2.SelectedValue));

        }
    }
    protected void btnResetDiagno3_Click(object sender, EventArgs e)
    {
        txtIcd3.Text = "";
        txtDiagno3.Text = "";
        ddlParentDiagno2.SelectedValue = "0";
    }
    protected void gvDiagno3_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string TrDiagnostage3Id = (gvDiagno3.DataKeys[e.RowIndex]["TrDiagnostage3Id"].ToString());

        string Message = objDALDiagno.DeleteDiagno3(Convert.ToInt32(TrDiagnostage3Id));
        DynamicMessage(lblMessage, Message);

        FillDiagno3Grid(Convert.ToInt32(ddlParentDiagno2.SelectedValue));
        clearall();
    }

    protected void FillDiagno3Page()
    {
        try
        {
            objBELDiagno = objDALDiagno.SelectOneDiagno3(Convert.ToInt32(ViewState["TrDiagnostage3Id"]));
            txtDiagno3.Text = objBELDiagno.TrDiagnoNameStg3;
            ddlParentDiagno2.SelectedValue = Convert.ToString(objBELDiagno.TrDiagnostage2Id);
            txtIcd3.Text = objBELDiagno.Stage3Id;

        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void gvDiagno3_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {

            string TrDiagnostage3Id = (gvDiagno3.DataKeys[e.NewEditIndex]["TrDiagnostage3Id"].ToString());
            ViewState["TrDiagnostage3Id"] = TrDiagnostage3Id;
            FillDiagno3Page();
            e.Cancel = true;
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }

    }
}