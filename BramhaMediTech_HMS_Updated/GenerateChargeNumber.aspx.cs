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

public partial class GenerateChargeNumber : BasePage
{
    BELPatientInformation objBELPatInfo = new BELPatientInformation();
    DALPatientInformation objDALPatInfo = new DALPatientInformation();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadPatientMainType();
            LoadPatientSubCategoryName();           
            
           // txtEntryDate.Text = DateTime.Now.ToShortDateString();
            txtToDate.Text = System.DateTime.Now.ToShortDateString();
            txtFromDate.Text = System.DateTime.Now.ToShortDateString();
            ViewState["PatientInfoID"] = "";
            FillPatientInfoGrid();
              
  

        }
    }

    protected void FillPatientInfoGrid()
    {
        objBELPatInfo.PatRegId = ViewState["PatientInfoID"].ToString();
       
        objBELPatInfo.PatientName=txtPatientName.Text;
       
        ViewState["FromDate"] = Convert.ToDateTime(txtFromDate.Text).ToString("yyyy-MM-dd");
        ViewState["ToDate"] = Convert.ToDateTime(txtToDate.Text).ToString("yyyy-MM-dd");
      
        objBELPatInfo.MobileNo = txtMobileNo.Text;
        string Birthdate="";
        if (txtBirthDate.Text != "")
        {
            Birthdate = Convert.ToDateTime(txtBirthDate.Text).ToString("yyyy-MM-dd");
           
        }
        gvPatientInfo.DataSource = objDALPatInfo.FillGrid(objBELPatInfo,Convert.ToString(ViewState["FromDate"]),Convert.ToString(ViewState["ToDate"]),Birthdate);
        gvPatientInfo.DataBind();
    }


    private void LoadPatientMainType()
    {
        
        //ddlPatientCategory.DataSource = objDALPatInfo.FillPatMainTypeDrop();
        //ddlPatientCategory.DataTextField = "PatMainType";
        //ddlPatientCategory.DataValueField = "PatMainTypeId";
        //ddlPatientCategory.DataBind();
    }

    private void LoadPatientSubCategoryName()
    {

        //ddlPatientSubCategory.DataSource = objDALPatInfo.FillPatInsuTypeDrop(Convert.ToInt32(ViewState["PatientCategoryID"]));
        //ddlPatientSubCategory.DataTextField = "PatientInsuType";
        //ddlPatientSubCategory.DataValueField = "PatientInsuTypeId";
        //ddlPatientSubCategory.DataBind();
    }

    protected void gvEmployee_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            string PatientInfoID = (gvPatientInfo.DataKeys[e.NewEditIndex]["PatientInfoId"].ToString());
            ViewState["PatientInfoID"] = PatientInfoID;
            Response.Redirect("~/PatientInformation.aspx?PatientInfoID=" + PatientInfoID);

        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }

    protected void gvEmployee_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string PatientInfoID = (gvPatientInfo.DataKeys[e.RowIndex]["PatientInfoId"].ToString());

       // string Message = objDALPatInfo.DeletePatientInfo(Convert.ToInt32(PatientInfoID));
        ViewState["PatientInfoID"] = PatientInfoID;
        Response.Redirect("~/CreateChargeNumber.aspx?PatientInfoID=" + Convert.ToString(ViewState["PatientInfoID"]), false);
       // FillPatientInfoGrid();
    }

    protected void gvPatientInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvPatientInfo.PageIndex = e.NewPageIndex;
        FillPatientInfoGrid();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        FillPatientInfoGrid();
       
    }

    private void Reset()
    {
        //txtBarcode.Text = "";
        //txtEntryDate.Text = "";
        txtPatientName.Text = "";
        txtSearchPatient.Text = "";
       // txtPrnNo.Text = "";
        //ddlPatientCategory.SelectedIndex = 0;
        //ddlPatientSubCategory.SelectedIndex = 0;
    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("PatientInformation.aspx");
    }
    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchPatient(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        return objDALOpdReg.FillAllPatient(prefixText);
    }
    protected void gvPatientInfo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "OPD")
        {
            // LinkButton lnkOPD = (LinkButton)e.CommandSource;
            ViewState["PatientInfoID"] = e.CommandArgument;
            Response.Redirect("../PatientRegistration.aspx?PatientInfoID=" + Convert.ToString(ViewState["PatientInfoID"]));
        }
        if (e.CommandName == "IPD")
        {
            // LinkButton lnkOPD = (LinkButton)e.CommandSource;
            ViewState["PatientInfoID"] = e.CommandArgument;
            Response.Redirect("../IPD/IPDAdmission.aspx?PatientInfoID=" + Convert.ToString(ViewState["PatientInfoID"]));
            //Kalyan 2016.02.08
            //  ViewState["PatientInfoID"] = e.CommandArgument;
            //  Response.Redirect("~/IPDHomeAdv.aspx?PatientInfoID=" + Convert.ToString(ViewState["PatientInfoID"]));
        }
    }
    protected void gvPatientInfo_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void gvPatientInfo_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
    protected void txtSearchPatient_TextChanged(object sender, EventArgs e)
    {
        string[] PatientInfo = txtSearchPatient.Text.Split('-');
        if (txtSearchPatient.Text != "")
        {
            if (PatientInfo.Length > 1)
            {
                txtSearchPatient.Text = PatientInfo[1];
                ViewState["PatientInfoID"] = PatientInfo[0];

            }
            else
            {
                ViewState["PatientInfoID"] = "";
            }
        }
        else
        {
            ViewState["PatientInfoID"] = "";
        }
    }
}