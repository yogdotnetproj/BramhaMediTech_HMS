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

public partial class DiseaseMst :BasePage
{
    BELDisease objBELDisease = new BELDisease();
    DALDisease objDALDisease = new DALDisease();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["DISEASE"] = "0";
            FillDiseaseGrid(Convert.ToInt32(ViewState["DISEASE"]));
            
            show.Visible = false;
            List.Visible = true;

        }
    }

    protected void FillDiseaseGrid(int DiseaseId)
    {

        gvDisease.DataSource = objDALDisease.FillGridDisease(DiseaseId);
        gvDisease.DataBind();
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {

        string Message = "";

        if (!(txtDisease.Text.Equals(string.Empty)))
        {
            if (Convert.ToInt32(ViewState["DiseaseId"]) > 0)
            {
                // objBELOt = objDALOt.SelectOneOpCat(Convert.ToInt32(ViewState["OprnId"]));
                objBELDisease.DiseaseName = txtDisease.Text;
                objBELDisease.DiseaseId = Convert.ToInt32(ViewState["DiseaseId"]);
                objBELDisease.UpdatedBy = Convert.ToString(Session["username"]);

                Message = objDALDisease.UpdateDisease(objBELDisease);
            }
            else
            {
                objBELDisease.DiseaseName = txtDisease.Text;                
                objBELDisease.FId = "1";
                objBELDisease.BranchId = Convert.ToInt32(Session["Branchid"]);
                objBELDisease.CreatedBy = Convert.ToString(Session["username"]);

                Message = objDALDisease.InsertDisease(objBELDisease);
            }

            DynamicMessage(lblMessage, Message);

            FillDiseaseGrid(Convert.ToInt32(ViewState["DISEASE"]));
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
        txtDisease.Text = "";
        ViewState["DISEASE"] = "0";
        ViewState["DiseaseId"] = 0;
        lblMessage.Text = "";
        show.Visible = false;
        List.Visible = true;

    }
    private void clearall()
    {
        txtDisease.Text = "";
        ViewState["DiseaseId"] = 0;

    }

    protected void FillPage()
    {
        try
        {
            objBELDisease = objDALDisease.SelectOneDisease(Convert.ToInt32(ViewState["DiseaseId"]));
            txtDisease.Text = objBELDisease.DiseaseName;
            


        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }

    protected void gvDisease_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            show.Visible = true;
            List.Visible = false;

            string DiseaseId = (gvDisease.DataKeys[e.NewEditIndex]["DiseaseId"].ToString());
            ViewState["DiseaseId"] = DiseaseId;
            FillPage();
            e.Cancel = true;
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }

    }
    protected void gvDisease_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string DiseaseId = (gvDisease.DataKeys[e.RowIndex]["DiseaseId"].ToString());

        string Message = objDALDisease.DeleteDisease(Convert.ToInt32(DiseaseId));
        DynamicMessage(lblMessage, Message);

        FillDiseaseGrid(Convert.ToInt32(ViewState["DISEASE"]));
        clearall();

    }
    protected void gvDisease_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        gvDisease.PageIndex = e.NewPageIndex;

        FillDiseaseGrid(Convert.ToInt32(ViewState["DISEASE"]));
    }
    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchDisease(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        // string Type = Convert.ToString(HttpContext.Current.Session["UID"]);
        string Type = "1";

        return objDALOpdReg.FillAllDisease(prefixText, Type);
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        FillDiseaseGrid(Convert.ToInt32(ViewState["DISEASE"]));
        ViewState["DISEASE"] = "0";
    }
    protected void txtdiseaseSearch_TextChanged(object sender, EventArgs e)
    {
        if (txtdiseaseSearch.Text != "")
        {
            string[] PatientInfo = txtdiseaseSearch.Text.Split('-');
            if (PatientInfo.Length == 2)
            {
                txtdiseaseSearch.Text = PatientInfo[1];
                ViewState["DISEASE"] = PatientInfo[0];
            }
            else
            {
                ViewState["DISEASE"] = "0";
            }
        }
        else
        {
            ViewState["DISEASE"] = "0";
            txtdiseaseSearch.BorderColor = Color.LightGray;
        }
    }
}