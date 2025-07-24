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

public partial class CancelProcedurePatientList :BasePage
{
    BELOPDPatReg objBELOpdReg = new BELOPDPatReg();
    DALOpdReg objDALOpdReg = new DALOpdReg();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtFrom.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtTo.Text = DateTime.Now.ToString("dd/MM/yyyy");
            FillPatientList();
        }
    }
    public void FillPatientList()
    {
        if (txtFrom.Text.ToString() != "")
        {
            ViewState["FromDate"] = txtFrom.Text.ToString();

        }
        else
        {
            ViewState["FromDate"] = "";
        }
        if (txtTo.Text.ToString() != "")
        {

            ViewState["ToDate"] = txtTo.Text.ToString();
        }
        else
        {
            ViewState["ToDate"] = "";
        }
        int BranchId = Convert.ToInt32(Session["BranchId"]);
        int FId = Convert.ToInt32(Session["FId"]);
        DataTable dt = new DataTable();
        string rdbgroupV = "";
        if (rdbgroup.SelectedItem.Text == "All")
        {
            rdbgroupV = "0";
        }
        else
        {
            rdbgroupV = rdbgroup.SelectedItem.Text;
        }
        dt = objDALOpdReg.FillCancelProcedurePatientList(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), Convert.ToInt32(ViewState["PatientInfoId"]), BranchId, FId, rdbgroupV);
       gvPatientInfo.DataSource = dt;
       gvPatientInfo.DataBind();
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
        if (txtPatientName.Text != "")
        {
            string[] PatientInfo = txtPatientName.Text.Split('-');
            txtPatientName.Text = PatientInfo[1];
            ViewState["PatientInfoId"] = PatientInfo[0];
        }
        else
        {
            ViewState["PatientInfoId"] = 0;
        }
    }
    protected void gvPatientInfo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        BLLReports objreports = new BLLReports();
        string sql = "";
        
        if (e.CommandName == "Report")
        {

            //Determine the RowIndex of the Row whose Button was clicked.
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            //Reference the GridView Row.
            GridViewRow row = gvPatientInfo.Rows[rowIndex];
            int BillNo = Convert.ToInt32(gvPatientInfo.DataKeys[rowIndex].Values["BillNo"]);
            int PatRegId = Convert.ToInt32(gvPatientInfo.DataKeys[rowIndex].Values["PatRegId"]);
            int ProcedureId = Convert.ToInt32(gvPatientInfo.DataKeys[rowIndex].Values["ProcedureId"]);

            int BranchId = Convert.ToInt32(Session["Branchid"]);
            int FId = Convert.ToInt32(Session["FId"]);

            objreports.GetProcedureBillDetails(BillNo, PatRegId,ProcedureId, FId, BranchId);

            Session.Add("rptsql", sql);
            Session["rptname"] = Server.MapPath("~/Reports/Rpt_CancelProcedureBillReport.rpt");
            Session["reportname"] = "CancelProcedureBillReport";
            Session["RPTFORMAT"] = "pdf";


            string close = "<script language='javascript'>javascript:OpenReport();</script>";
            Type title1 = this.GetType();
            Page.ClientScript.RegisterStartupScript(title1, "", close);



        }
       
    }

       protected void gvPatientInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
       {
           gvPatientInfo.PageIndex = e.NewPageIndex;
           FillPatientList();
       }
       protected void btnSearch_Click(object sender, EventArgs e)
       {
           FillPatientList();
       }
       protected void btnreport_Click(object sender, EventArgs e)
       {

           if (txtFrom.Text.ToString() != "")
           {
               ViewState["FromDate"] = txtFrom.Text.ToString();

           }
           else
           {
               ViewState["FromDate"] = "";
           }
           if (txtTo.Text.ToString() != "")
           {

               ViewState["ToDate"] = txtTo.Text.ToString();
           }
           else
           {
               ViewState["ToDate"] = "";
           }
           int BranchId = Convert.ToInt32(Session["BranchId"]);
           int FId = Convert.ToInt32(Session["FId"]);

           BLLReports objreports = new BLLReports();
           string sql = "";

           objreports.GetProcedureCancelBillDetails(0, Convert.ToInt32(ViewState["PatientInfoId"]), FId, BranchId, Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]));

           Session.Add("rptsql", sql);
           Session["rptname"] = Server.MapPath("~/Reports/Rpt_ProcedureCancelPatientList.rpt");
           Session["reportname"] = "ProcedureCancelPatientList";
           Session["RPTFORMAT"] = "pdf";


           string close = "<script language='javascript'>javascript:OpenReport();</script>";
           Type title1 = this.GetType();
           Page.ClientScript.RegisterStartupScript(title1, "", close);


       }
}