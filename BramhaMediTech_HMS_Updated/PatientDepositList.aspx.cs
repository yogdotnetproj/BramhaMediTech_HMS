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


public partial class PatientDepositList :BasePage
{
    BELPatientInformation objBELPatInfo = new BELPatientInformation();
    DALPatientInformation objDALPatInfo = new DALPatientInformation();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
          

          
            txtToDate.Text = System.DateTime.Now.ToShortDateString();
            txtFromDate.Text = System.DateTime.Now.ToShortDateString();
            FillPatientInfoGrid();



        }
    }

    protected void FillPatientInfoGrid()
    {
        objBELPatInfo.PatRegId = txtPrnNo.Text;
        //objBELPatInfo.BarcodeId=txtBarcode.Text;
        objBELPatInfo.PatientName = txtPatientName.Text;
        //objBELPatInfo.PatMainTypeId=Convert.ToInt32( ddlPatientCategory.SelectedValue);
        //objBELPatInfo.PatientInsuTypeId=Convert.ToInt32(ddlPatientSubCategory.SelectedValue);

        ViewState["FromDate"] = Convert.ToDateTime(txtFromDate.Text).ToString("yyyy-MM-dd");
        ViewState["ToDate"] = Convert.ToDateTime(txtToDate.Text).ToString("yyyy-MM-dd");
        //ViewState["FromDate"] = DateTime.ParseExact(txtFromDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
        //ViewState["ToDate"] = DateTime.ParseExact(txtToDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

        objBELPatInfo.MobileNo = txtMobileNo.Text;
        string Birthdate = "";
        if (txtBirthDate.Text != "")
        {
            Birthdate = Convert.ToDateTime(txtBirthDate.Text).ToString("yyyy-MM-dd");
            //objBELPatInfo.BirthDate = Convert.ToDateTime(txtBirthDate.Text);
        }
        gvPatientInfo.DataSource = objDALPatInfo.FillGridDeposit(objBELPatInfo, Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), Birthdate);
        gvPatientInfo.DataBind();
    }
    

    protected void gvPatientInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvPatientInfo.PageIndex = e.NewPageIndex;
        FillPatientInfoGrid();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        FillPatientInfoGrid();
        Reset();
    }

    private void Reset()
    {
        //txtBarcode.Text = "";
        //txtEntryDate.Text = "";
        txtPatientName.Text = "";
        txtPrnNo.Text = "";
        //ddlPatientCategory.SelectedIndex = 0;
        //ddlPatientSubCategory.SelectedIndex = 0;
    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("PatientInformation.aspx");
    }

    protected void gvPatientInfo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvPatientInfo.Rows[rowIndex];
            int PatientInfoId = Convert.ToInt32(gvPatientInfo.DataKeys[rowIndex].Values["PatientInfoId"]);

            string response = @"~/PatientDepositMaster.aspx?PatientInfoId=" + PatientInfoId;

            Response.Redirect(string.Format(response));

            // ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Name: " + name + "\\nRegId: " + regId + "');", true);
        }
        
    }
    protected void gvPatientInfo_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void gvPatientInfo_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchPatient(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        return objDALOpdReg.FillAllPatient(prefixText);
    }
    protected void txtPatientName_TextChanged(object sender, EventArgs e)
    {

        string[] PatientInfo = txtPatientName.Text.Split('-');
        txtPatientName.Text = PatientInfo[1];
        ViewState["PatientInfoId"] = PatientInfo[0];

    }
}