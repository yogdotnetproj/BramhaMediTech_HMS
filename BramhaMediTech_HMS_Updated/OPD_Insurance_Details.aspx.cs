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

public partial class OPD_Insurance_Details :BasePage
{
    BLLReports ObjDOReport = new BLLReports();
    decimal total = 0;
    decimal AmountPaid = 0;
    int Balance = 0;
    int Balance1 = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //txtFrom.Text = DateTime.Now.ToString("dd/MM/yyyy");
       //     txtTo.Text = DateTime.Now.ToString("dd/MM/yyyy");
        
            ViewState["PatRegId"] = "0";
            ViewState["InsuranceId"] = "0";
            //FillUsers();
            //FillGrid();

        }
       // this.RegisterPostBackControl();

    }

 
    //protected void FillUsers()
    //{
    //    int UserId = Convert.ToInt32(Session["UserId"]);
    //    int BranchId = Convert.ToInt32(Session["BranchId"]);
    //    int FId = Convert.ToInt32(Session["FId"]);
    //    ddlUser.DataSource = ObjDOReport.fillUsers(UserId, BranchId, FId);
    //    ddlUser.DataValueField = "CUId";
    //    ddlUser.DataTextField = "username";
    //    ddlUser.DataBind();

    //}
    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchPatient(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        return objDALOpdReg.FillAllRegisterPatient(prefixText);
    }
    protected void ddlUser_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
   
    protected void btnSearch_Click(object sender, EventArgs e)
    {       
        Reset();
    }

   
    private void Reset()
    {

    }

  
    protected void btnReset_Click(object sender, EventArgs e)
    {
        BLLReports objreports = new BLLReports();
        string sql = "";
        int FId = Convert.ToInt32(Session["FId"]);
        int BranchId = Convert.ToInt32(Session["BranchId"]);
       // Alter_view();
        objreports.OPD_InsuranceDetailsReport(Convert.ToInt32(ViewState["InsuranceId"]), Convert.ToInt32(ddlMonth.SelectedValue), Convert.ToInt32(ddlYear.SelectedValue), BranchId, Convert.ToInt32(RblType.SelectedValue));

        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Reports/Rpt_Insurance_PaymentRec.rpt");
        Session["reportname"] = "OPD_Insurance_Details";
        Session["RPTFORMAT"] = "EXCEL";


        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);
    }
   
  
    private void PrintReport()
    {
        try
        {
            BLLReports objBLLReports = new BLLReports();
            DataSet dsCustomers = new DataSet();
            ReportDocument crystalReport = new ReportDocument();
            crystalReport.Load(Server.MapPath("~/Report/Rpt_OPDBilling.rpt"));
            dsCustomers = objBLLReports.GetOPDBillDetails(Convert.ToInt32(Request.QueryString["BillNo"]), Convert.ToInt32(ViewState["ReceiptNo"]), Convert.ToInt32(Request.QueryString["LabNo"]), Convert.ToInt32(Request.QueryString["PatRegId"]), Convert.ToInt32(Request.QueryString["FID"]), Convert.ToInt32(Session["BranchId"]));
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
   
    public void Alter_view()
    {
        string sql = "";
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd1 = con.CreateCommand();

        string query = "ALTER VIEW [dbo].[VW_OPDInsurancePatientsDetails] AS (SELECT        ChargeBill_Master.ID, ChargeBill_Master.ChargeId, ChargeBill_Master.ChargeNo, ChargeBill_Master.InsuranceCompId, ChargeBill_Master.Patregid, ChargeBill_Master.BillAmt, ChargeBill_Master.InsuranceAmt, " +
                      "  ChargeBill_Master.CreatedBy, ChargeBill_Master.CreatedOn, ChargeBill_Master.CancelBill, ChargeBill_Master.GenerateInvoice, ChargeBill_Master.BillGroupName, ChargeBill_Master.BillNo, " +
                      "  ChargeBill_Master.PatientMainType, ChargeBill_Master.InsuCompanyId, ChargeBill_Master.CoverageDetails, ChargeBill_Master.Discount, ChargeBill_Master.DiscountAmt, ChargeBill_Master.ActualInsuAmt, " +
                      "  ChargeBill_Master.DiscountGivenBy, ChargeBill_Master.DiscountGivenOn, ChargeBill_Master.DiscountRemark, ChargeBill_Master.PaymentReceive, ChargeBill_Master.PaymentReceiveBy, " +
                      "  ChargeBill_Master.PaymentReceiveOn, ChargeBill_Master.PayRecNo, ChargeBill_Master.PartialPayReceive, ChargeBill_Master.ChargeCompanyId, ChargeBill_Master.ChildCompName, ChargeBill_Master.LetterNo, " +
                      "  ChargeBill_Master.ChargeYear, ChargeBill_Master.ChargeMonth, PatientInformation.FirstName, PatientInsuType.PatientInsuType, " +
                      "  sum( isnull(ChargeBill_Transaction.PatPayAmount,0))as PatPayAmount, sum(isnull(PatientInvoicePaymetReceive.PaymentReceivedAmt,0)) as PaymentReceivedAmt " +
                      "  FROM            ChargeBill_Master INNER JOIN " +
                      "  PatientInformation ON ChargeBill_Master.Patregid = PatientInformation.PatRegId INNER JOIN " +
                      "  PatientInsuType ON ChargeBill_Master.InsuranceCompId = PatientInsuType.PatientInsuTypeId LEFT OUTER JOIN " +
                      "  PatientInvoicePaymetReceive ON ChargeBill_Master.InsuranceCompId = PatientInvoicePaymetReceive.InsuranceCompId AND ChargeBill_Master.Patregid = PatientInvoicePaymetReceive.Patregid AND " +
                      "  ChargeBill_Master.ChargeNo = PatientInvoicePaymetReceive.ChargeNo LEFT OUTER JOIN " +
                      "  ChargeBill_Transaction ON ChargeBill_Master.ChargeId = ChargeBill_Transaction.ChargeId AND ChargeBill_Master.InsuranceCompId = ChargeBill_Transaction.InsuranceCompId AND  " +
                      "  ChargeBill_Master.Patregid = ChargeBill_Transaction.Patregid " +


                    "  group by ChargeBill_Master.ID, ChargeBill_Master.ChargeId, ChargeBill_Master.ChargeNo, ChargeBill_Master.InsuranceCompId, ChargeBill_Master.Patregid, ChargeBill_Master.BillAmt, ChargeBill_Master.InsuranceAmt, " +
                      "  ChargeBill_Master.CreatedBy, ChargeBill_Master.CreatedOn, ChargeBill_Master.CancelBill, ChargeBill_Master.GenerateInvoice, ChargeBill_Master.BillGroupName, ChargeBill_Master.BillNo, " +
                      "  ChargeBill_Master.PatientMainType, ChargeBill_Master.InsuCompanyId, ChargeBill_Master.CoverageDetails, ChargeBill_Master.Discount, ChargeBill_Master.DiscountAmt, ChargeBill_Master.ActualInsuAmt, " +
                      "  ChargeBill_Master.DiscountGivenBy, ChargeBill_Master.DiscountGivenOn, ChargeBill_Master.DiscountRemark, ChargeBill_Master.PaymentReceive, ChargeBill_Master.PaymentReceiveBy, " +
                      "  ChargeBill_Master.PaymentReceiveOn, ChargeBill_Master.PayRecNo, ChargeBill_Master.PartialPayReceive, ChargeBill_Master.ChargeCompanyId, ChargeBill_Master.ChildCompName, ChargeBill_Master.LetterNo, " +
                      "  ChargeBill_Master.ChargeYear, ChargeBill_Master.ChargeMonth, PatientInformation.FirstName, PatientInsuType.PatientInsuType";

        query += "  having   ( ChargeBill_Master.BillAmt-(sum( isnull(ChargeBill_Transaction.PatPayAmount,0))+sum(isnull(PatientInvoicePaymetReceive.PaymentReceivedAmt,0))+ChargeBill_Master.DiscountAmt) )>0 ";// (ChargeBill_Master.ChargeNo = 'GT-2707') ";
        if (Convert.ToString(ViewState["InsuranceId"]) != "0")
        {
            query += " and ChargeBill_Master.InsuranceCompId=" + Convert.ToInt32(ViewState["InsuranceId"]) + "";
        }
        if (ddlYear.SelectedValue != "0")
        {
            query += " and  ChargeBill_Master.ChargeYear=" + ddlYear.SelectedValue + " ";
        }
        if (ddlMonth.SelectedValue != "0")
        {
            query += " and  ChargeBill_Master.ChargeMonth=" + ddlMonth.SelectedValue + " ";
        }
        //if (txtFrom.Value != "" && txtTo.Value != "")
        //{
        //    query += " and    DagnosisAssigtTpPatient.CreatedOn between ('" + Convert.ToDateTime(txtFrom.Value).ToString("MM/dd/yyyy") + "') and ('" + Convert.ToDateTime(txtTo.Value).AddDays(1).ToString("MM/dd/yyyy") + "')";
        //}



        cmd1.CommandText = query + ")";

        con.Open();
        cmd1.ExecuteNonQuery();
        con.Close(); con.Dispose();
    }
    protected void gvDailyCash_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Print_Click(object sender, EventArgs e)
    {
        BLLReports objreports = new BLLReports();
        string sql = "";
        int FId = Convert.ToInt32(Session["FId"]);
        int BranchId = Convert.ToInt32(Session["BranchId"]);
     //   Alter_view();
        //int ReceiptNo = 0;

      //  int ReceiptNo = Convert.ToInt32(ddlreceipts.SelectedValue);

        //if (txtFrom.Text.ToString() != "")
        //{

        //    ViewState["FromDate"] = txtFrom.Text.ToString();
        //    ViewState["FromDate"] = Convert.ToDateTime(txtFrom.Text).ToString("yyyy-MM-dd");

        //}
        //else
        //{
        //    ViewState["FromDate"] = "";
        //}
        //if (txtTo.Text.ToString() != "")
        //{

        //    ViewState["ToDate"] = txtTo.Text.ToString();
        //    ViewState["ToDate"] = Convert.ToDateTime(txtTo.Text).ToString("yyyy-MM-dd");
        //}
        //else
        //{
        //    ViewState["ToDate"] = "";
        //}
        int Sponser = Convert.ToInt32(ViewState["InsuranceId"]);


        objreports.OPD_InsuranceDetailsReport(Convert.ToInt32(ViewState["InsuranceId"]), Convert.ToInt32(ddlMonth.SelectedValue),Convert.ToInt32(ddlYear.SelectedValue),  BranchId,Convert.ToInt32( RblType.SelectedValue));

        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Reports/Rpt_Insurance_PaymentRec.rpt");
        Session["reportname"] = "OPD_Insurance_Details";
        Session["RPTFORMAT"] = "pdf";


        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);

    }
    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchInsurance(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        return objDALOpdReg.FillAllInsurance(prefixText);
    }
    protected void txtInsuranceid_TextChanged(object sender, EventArgs e)
    {
        if (txtInsuranceid.Text.Trim() != "")
        {
            string[] InsuranceId = txtInsuranceid.Text.Split('-');
            txtInsuranceid.Text = InsuranceId[1];

            if (txtInsuranceid.Text != "")
            {
                ViewState["InsuranceId"] = InsuranceId[0];
            }
            else
            {
                ViewState["InsuranceId"] = 0;
            }
           // GetInsurancePaymentDetails();
           // LoadReceipts();

        }
        else
        {
            ViewState["InsuranceId"] = 0;
        }


    }
}