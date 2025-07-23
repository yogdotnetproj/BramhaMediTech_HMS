using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Services;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using CrystalDecisions.CrystalReports.Engine;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.Collections;
using System.IO;
using System.Drawing;

public partial class OperationNameMst : BaseClass
{
    BELOperationTheater objBELOt = new BELOperationTheater();
    DALOperationTheater objDALOt = new DALOperationTheater();



    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["Operation"] = "0";
            FillOpNameGrid(Convert.ToInt32(ViewState["Operation"]));
          //  FillOpMainCatDrop();
            show.Visible = false;
            List.Visible = true;

        }
    }
    public void FillOpMainCatDrop()
    {

        ddlOpMainCat.DataSource = objDALOt.FillOpMainCatCombo();
        ddlOpMainCat.DataValueField = "OTDeptId";
        ddlOpMainCat.DataTextField = "OTDeptName";        
        ddlOpMainCat.DataBind();

    }

    protected void FillOpNameGrid(int OperationId)
    {
        gvOpName.DataSource = objDALOt.FillGridOpName(OperationId);
        gvOpName.DataBind();
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {

        string Message = "";


        if (!(txtOprn.Text.Equals(string.Empty)))
        {
            if (Convert.ToInt32(ViewState["OprnId"]) > 0)
            {
                //objBELOt= objDALOt.SelectOneOT(Convert.ToInt32(ViewState["OTId"]));
                objBELOt.Oprn = txtOprn.Text;
              //  objBELOt.OprnCd = txtOprnCode.Text;
                objBELOt.OprnId = Convert.ToInt32(ViewState["OprnId"]);
                objBELOt.UpdatedBy = Convert.ToString(Session["username"]);

                Message = objDALOt.UpdateOpName(objBELOt);
            }
            else
            {
                objBELOt.Oprn = txtOprn.Text;
                objBELOt.OprnCd = txtOprnCode.Text;
              //  objBELOt.OTDeptId = Convert.ToInt32(ddlOpMainCat.SelectedValue);
                objBELOt.FId = "1";
                objBELOt.BranchId = Convert.ToInt32(Session["Branchid"]);
                objBELOt.CreatedBy = Convert.ToString(Session["username"]);

                Message = objDALOt.InsertOpName(objBELOt);
            }

            DynamicMessage(lblMessage, Message);

            FillOpNameGrid(Convert.ToInt32(ViewState["OperationId"]));
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
        txtOprn.Text = "";
        ViewState["OprnId"] = 0;
        ViewState["Operation"] = "0";
        ddlOpMainCat.SelectedValue = "0";
        lblMessage.Text = "";
        show.Visible = false;
        List.Visible = true;

    }
    private void clearall()
    {
        txtOprn.Text = "";
        ViewState["OprnId"] = 0;

    }

    protected void FillPage()
    {
        try
        {
            objBELOt = objDALOt.SelectOneOpName(Convert.ToInt32(ViewState["OprnId"]));
            txtOprn.Text = objBELOt.Oprn;
           // txtOprnCode.Text = objBELOt.OprnCd;
           // ddlOpMainCat.SelectedValue =Convert.ToString(objBELOt.OTDeptId);


        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }

    protected void gvOpName_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            show.Visible = true;
            List.Visible = false;

            string OprnId = (gvOpName.DataKeys[e.NewEditIndex]["OperationId"].ToString());
            ViewState["OprnId"] = OprnId;
            FillPage();
            e.Cancel = true;
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }

    }
    protected void gvOpName_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string OprnId = (gvOpName.DataKeys[e.RowIndex]["OperationId"].ToString());

        string Message = objDALOt.DeleteOpName(Convert.ToInt32(OprnId));
        DynamicMessage(lblMessage, Message);

        FillOpNameGrid(Convert.ToInt32(ViewState["Operation"]));
        clearall();

    }
    protected void gvOpName_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvOpName.PageIndex = e.NewPageIndex;
        FillOpNameGrid(Convert.ToInt32(ViewState["Operation"]));
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        FillOpNameGrid(Convert.ToInt32(ViewState["Operation"]));
        ViewState["Operation"] = "0";
        txtoperation.Text = "";
    }
    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchOperaation(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        string Type = "1";
        return objDALOpdReg.FillAllOperation(prefixText, Type);
    }
    protected void txtoperation_TextChanged(object sender, EventArgs e)
    {
        if (txtoperation.Text != "")
        {
            string[] PatientInfo = txtoperation.Text.Split('-');
            if (PatientInfo.Length == 2)
            {
                txtoperation.Text = PatientInfo[1];
                ViewState["Operation"] = PatientInfo[0];
            }
            else
            {
                ViewState["Operation"] = "0";

            }
        }
        else
        {
            ViewState["Operation"] = "0";
        }
    }
}