using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using CrystalDecisions.CrystalReports.Engine;
using System.Web.UI.HtmlControls;
using System.Web.Services;
using System.Web.Script.Services;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Web.Management;
using System.Net;
using System.IO;

public partial class CancelOpdRegistration : BaseClass
{
    BLLReports ObjDOReport = new BLLReports();
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtFrom.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtTo.Text = DateTime.Now.ToString("dd/MM/yyyy");
           
            ViewState["PatRegId"] = "0";
           
            FillGrid();

        }
        

    }


    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchPatient(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        return objDALOpdReg.FillAllOPDPatient(prefixText);
    }
   
    protected void txtTo_TextChanged(object sender, EventArgs e)
    {
        ViewState["ToDate"] = txtTo.Text.ToString();
    }
    protected void txtFrom_TextChanged(object sender, EventArgs e)
    {
        ViewState["FromDate"] = txtFrom.Text.ToString();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {

        FillGrid();
        Reset();
    }

    private void FillGrid()
    {
        if (txtFrom.Text.ToString() != "")
        {

            ViewState["FromDate"] = txtFrom.Text.ToString();
            ViewState["FromDate"] = Convert.ToDateTime(txtFrom.Text).ToString("yyyy-MM-dd");

        }
        else
        {
            ViewState["FromDate"] = "";
        }
        if (txtTo.Text.ToString() != "")
        {

            ViewState["ToDate"] = txtTo.Text.ToString();
            ViewState["ToDate"] = Convert.ToDateTime(txtTo.Text).ToString("yyyy-MM-dd");
        }
        else
        {
            ViewState["ToDate"] = "";
        }
        int BranchId = Convert.ToInt32(Session["BranchId"]);
        int FId = Convert.ToInt32(Session["FId"]);


        gvDailyCash.DataSource = ObjDOReport.FillOpdPatientList(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), Convert.ToInt32(ViewState["PatRegId"]), txtMobileNo.Text.Trim(), BranchId, FId,Convert.ToInt32(ViewState["ConsultID"])); //Convert.ToInt32(ddlUser.SelectedValue));
        gvDailyCash.DataBind();
    }
    private void Reset()
    {

    }
    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchConsultDoc(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        return objDALOpdReg.FillAllConsultDoc(prefixText);
    }
   
    protected void btnReset_Click(object sender, EventArgs e)
    {

    }
    protected void gvDailyCash_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDailyCash.PageIndex = e.NewPageIndex;
        FillGrid();
    }
    
    protected void txtPatientName_TextChanged(object sender, EventArgs e)
    {
        if (txtPatientName.Text != "")
        {
            string[] PatientInfo = txtPatientName.Text.Split('-');
            txtPatientName.Text = PatientInfo[1];
            ViewState["PatRegId"] = PatientInfo[0];
        }
        else
        {
            ViewState["PatRegId"] = "0";
        }
    }
    protected void gvDailyCash_RowEditing(object sender, GridViewEditEventArgs e)
    {
        if (e.NewEditIndex == -1)
            return;
        int PatRegId = Convert.ToInt32(gvDailyCash.DataKeys[e.NewEditIndex].Value);
        string FID = (gvDailyCash.Rows[e.NewEditIndex].FindControl("HdnFId") as HiddenField).Value;
        string BranchId = (gvDailyCash.Rows[e.NewEditIndex].FindControl("HdnBranchId") as HiddenField).Value;
        string OpdNo = (gvDailyCash.Rows[e.NewEditIndex].FindControl("HdnOpdNo") as HiddenField).Value;
        string BillNo = (gvDailyCash.Rows[e.NewEditIndex].FindControl("HdnBillNo") as HiddenField).Value;
        Response.Redirect("OpdPaybillOutstanding.aspx?PatRegId=" + PatRegId + "&FID=" + FID + "&BillNo=" + BillNo + "&OpdNo=" + OpdNo, false);

    }


    protected void gvDailyCash_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string PatRegId = (gvDailyCash.DataKeys[e.RowIndex]["PatRegId"].ToString());
        string OpdNo = (gvDailyCash.DataKeys[e.RowIndex]["OpdNo"].ToString());
        string Message = ObjDOReport.DeleteOpdRegistration(Convert.ToInt32(PatRegId),Convert.ToInt32(OpdNo));
        DynamicMessage(lblMessage, Message);
        FillGrid();

    }

    protected void txtConsDoctorName_TextChanged(object sender, EventArgs e)
    {
        if (txtConsDoctorName.Text != "")
        {
            string[] PatientInfo = txtConsDoctorName.Text.Split('-');
            if (PatientInfo.Length > 1)
            {
                txtConsDoctorName.Text = PatientInfo[1];
                ViewState["ConsultID"] = PatientInfo[0];

            }
            else
            {
                ViewState["ConsultID"] = "0";
            }
        }
    }
}