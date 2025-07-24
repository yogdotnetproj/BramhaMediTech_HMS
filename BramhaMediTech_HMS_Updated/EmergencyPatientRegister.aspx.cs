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

public partial class EmergencyPatientRegister :BasePage
{
    BLLReports ObjDOReport = new BLLReports();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtFrom.Value = DateTime.Now.ToString("dd/MM/yyyy");
            txtTo.Value = DateTime.Now.ToString("dd/MM/yyyy");
            
            ViewState["PatRegId"] = "0";
            FillDept();
            FillGrid();

        }
       

    }
    public void FillDept()
    {

        BLLReports Deptlist = new BLLReports();
        ddldeptname.DataSource = Deptlist.fillDeptUserwise(Convert.ToInt32(Session["UserId"]));
        ddldeptname.DataTextField = "DeptName";
        ddldeptname.DataValueField = "DeptId";
        ddldeptname.DataBind();
        if (Convert.ToString(Session["Usertype"]) == "Administrator" || Convert.ToString(Session["Usertype"]) == "Admin")
        {
            ddldeptname.SelectedValue = "88";
        }
        //ddldeptname.Items.Insert(0, new ListItem("--Select--", "0"));
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
        ViewState["ToDate"] = txtTo.Value.ToString();
    }
    protected void txtFrom_TextChanged(object sender, EventArgs e)
    {
        ViewState["FromDate"] = txtFrom.Value.ToString();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {

        FillGrid();
        Reset();
    }

    private void FillGrid()
    {
        if (txtFrom.Value.ToString() != "")
        {

            ViewState["FromDate"] = txtFrom.Value.ToString();
           // ViewState["FromDate"] = Convert.ToDateTime(txtFrom.Value).ToString("yyyy-MM-dd");

        }
        else
        {
            ViewState["FromDate"] = "";
        }
        if (txtTo.Value.ToString() != "")
        {

            ViewState["ToDate"] = txtTo.Value.ToString();
            //ViewState["ToDate"] = Convert.ToDateTime(txtTo.Value).ToString("yyyy-MM-dd");
        }
        else
        {
            ViewState["ToDate"] = "";
        }
        int BranchId = Convert.ToInt32(Session["BranchId"]);
        int FId = Convert.ToInt32(Session["FId"]);


        gvDailyCash.DataSource = ObjDOReport.FillEmergencyRegister(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), Convert.ToInt32(ViewState["PatRegId"]), txtMobileNo.Text.Trim(),Convert.ToInt32(ddldeptname.SelectedValue)); //Convert.ToInt32(ddlUser.SelectedValue));
        gvDailyCash.DataBind();
    }
    private void Reset()
    {

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
   
   
    
    
   

    protected void btnReport_Click(object sender, EventArgs e)
    {
        try
        {
            BLLReports objBLLReports = new BLLReports();
            DataSet dsCustomers = new DataSet();
            ReportDocument crystalReport = new ReportDocument();
            crystalReport.Load(Server.MapPath("~/Report/Rpt_EmergencyPatientRegister.rpt"));
            dsCustomers = objBLLReports.FillEmergencyRegister(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), Convert.ToInt32(ViewState["PatRegId"]), txtMobileNo.Text.Trim(), Convert.ToInt32(ddldeptname.SelectedValue));
            crystalReport.SetDataSource(dsCustomers);
            //crystalReport.ParameterFields["HospitalName"].CurrentValues.AddValue(Convert.ToString(Application["OrgnizationName"]));
            //crystalReport.ParameterFields["HospitalAddress"].CurrentValues.AddValue(Convert.ToString(Application["OrgnizationAddress"]));
            //crystalReport.ParameterFields["Image"].CurrentValues.AddValue(Application["ImagePath"]);
            // crystalReport.ParameterFields["ReportFooter"].CurrentValues.AddValue("Hospital Software | Ph.020 0000000000");
            crystalReport.ExportToHttpResponse
            (CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Employee");
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }

    }
    
}