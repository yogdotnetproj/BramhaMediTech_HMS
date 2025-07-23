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


public partial class Userwise_LedgerReport : System.Web.UI.Page
{
    BLLReports ObjDOReport = new BLLReports();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtFrom.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtTo.Text = DateTime.Now.ToString("dd/MM/yyyy");
            //RdbPayment.SelectedValue = "All";
            BindTime();
            FillUsers();
            LoadRdbPaymentType();
            RdbPayment.SelectedValue = "0";

           
        }

    }

    private void BindTime()
    {
        // Set the start time (00:00 means 12:00 AM)
        DateTime StartTime = DateTime.ParseExact("00:00", "HH:mm", null);
        // Set the end time (23:55 means 11:55 PM)
        DateTime EndTime = DateTime.ParseExact("23:55", "HH:mm", null);
        //Set 5 minutes interval
        TimeSpan Interval = new TimeSpan(0, 15, 0);
        //To set 1 hour interval
        //TimeSpan Interval = new TimeSpan(1, 0, 0);           
        ddlTimeFrom.Items.Clear();
        ddlTimeTo.Items.Clear();
        while (StartTime <= EndTime)
        {
            ddlTimeFrom.Items.Add(StartTime.ToShortTimeString());
            ddlTimeTo.Items.Add(StartTime.ToShortTimeString());
            StartTime = StartTime.Add(Interval);
        }
      //  ddlTimeFrom.Items.Insert(0, new ListItem("--Select--", "0"));
        ddlTimeTo.Items.Insert(0, new ListItem("23:59", "23:59"));
    }
    protected void FillUsers()
    {
        int UserId = Convert.ToInt32(Session["UserId"]);
        int BranchId = Convert.ToInt32(Session["BranchId"]);
        int FId = Convert.ToInt32(Session["FId"]);
        ddlUser.DataSource = ObjDOReport.fillUsers(UserId, BranchId, FId);
        ddlUser.DataValueField = "CUId";
        ddlUser.DataTextField = "username";
        ddlUser.DataBind();
        DALPatientInformation objDALPatInfo = new DALPatientInformation();
        ddlBank.DataSource = objDALPatInfo.GetBankName();
        ddlBank.DataTextField = "BankName";
        ddlBank.DataValueField = "BankCode";
        ddlBank.DataBind();

        ddlBank.Items.Insert(0, new ListItem("Select Bank", "0"));
    }
    private void LoadRdbPaymentType()
    {

        RdbPayment.DataSource = ObjDOReport.FillModeOfPaymentForReport();
        RdbPayment.DataValueField = "ModeOfPaymentId";
        RdbPayment.DataTextField = "ModeOfPaymentName";
        RdbPayment.DataBind();


    }
    protected void txtTo_TextChanged(object sender, EventArgs e)
    {
        ViewState["ToDate"] = txtTo.Text.ToString();
    }
    protected void txtFrom_TextChanged(object sender, EventArgs e)
    {
        ViewState["FromDate"] = txtFrom.Text.ToString();
    }



    private void Reset()
    {

    }
    public void Alterview()
    {
        SqlConnection conrp = DataAccess.ConInitForDC();
        SqlCommand cmd1 = conrp.CreateCommand();
        if (txtFrom.Text.ToString() != "")
        {
            ViewState["FromDate"] = Convert.ToDateTime(txtFrom.Text).ToString("MM/dd/yyyy");

        }
        else
        {
            ViewState["FromDate"] = "";
        }
        if (txtTo.Text.ToString() != "")
        {

            ViewState["ToDate"] = Convert.ToDateTime(txtTo.Text).ToString("MM/dd/yyyy"); //txtTo.Value.ToString();


        }
        else
        {
            ViewState["ToDate"] = "";
        }

        string query = "ALTER VIEW [dbo].[VW_GetLabeServiceName_Temp] AS (SELECT * from  LabServiceDetails  " +
                " where (CAST(CAST(YEAR(Createdon) AS varchar(4)) + '/' + CAST(MONTH(Createdon) AS varchar(2)) + '/' + CAST(DAY(Createdon) AS varchar(2)) AS datetime)) between '" + ViewState["FromDate"] + "'  and '" + ViewState["ToDate"] + "' ";

        cmd1.CommandText = query + ")";
        conrp.Open();
        cmd1.ExecuteNonQuery();
        conrp.Close(); conrp.Dispose();
    }

    public void Alterview_Pharma()
    {
        SqlConnection conrp = DataAccess.ConInitForPharmacy();
        SqlCommand cmd1 = conrp.CreateCommand();
        if (txtFrom.Text.ToString() != "")
        {
            ViewState["FromDate"] = Convert.ToDateTime(txtFrom.Text).ToString("MM/dd/yyyy");

        }
        else
        {
            ViewState["FromDate"] = "";
        }
        if (txtTo.Text.ToString() != "")
        {

            ViewState["ToDate"] = Convert.ToDateTime(txtTo.Text).ToString("MM/dd/yyyy"); //txtTo.Value.ToString();


        }
        else
        {
            ViewState["ToDate"] = "";
        }
       
        string query = "ALTER VIEW [dbo].[VW_GetPharmacyIncomeForHMS] AS (select TotalAmt as CashAmt,0 as ChequeAmt, 0 as RBLAmt, 0 as CTAmt, 'CASH' as ModeOfPaymentName ,'Pharmacy' as BillGroup,AmountReceived as ReceivedAmount, "+
                   " CreatedOn as PaymentDate,Patregno as PatRegId, '' as Title, PatientName as FirstName, FullCancelVoucher as CancelBill, IssueVoucherNo as ProcedureId, CreatedBy,FinalSettledBy as PaymentReceivedBy, CreatedOn,'' as ChequeNo, "+
                   " 1 as PaymentMode, null as ChequeDate, '' as BankName, FId, BranchId, IssueVoucherNo as BillNo, "+
                   " case when IsInsurance=1 then 'Insurance' else 'Paying' end as PatMainType, TotalAmt as BillAmount, InsuranceAmount as InsuranceAmt, "+
                   " DiscAmt as Discount, InsuranceCompId as  PatientSubType, InsuranceComp as PatientInsuType "+
                   "  from PatientIssueVoucher  " +
                " where PatientType<>'IPD' and FullCancelVoucher=0  and (CAST(CAST(YEAR(Createdon) AS varchar(4)) + '/' + CAST(MONTH(Createdon) AS varchar(2)) + '/' + CAST(DAY(Createdon) AS varchar(2)) AS datetime)) between '" + ViewState["FromDate"] + "'  and '" + ViewState["ToDate"] + "' ";
        if (ddlBillGroup.SelectedValue == "IPD")
        {
            query += " and branchid=2";
            
        }
        else
        {
            query += " and branchid=1";
        }
        cmd1.CommandText = query + ")";
        conrp.Open();
        cmd1.ExecuteNonQuery();
        conrp.Close(); conrp.Dispose();
    }

    public void Alterview_Main()
    {
        SqlConnection conrp = DataAccess.ConInitForDC();
        SqlCommand cmd1 = conrp.CreateCommand();
        SqlConnection conrph = DataAccess.ConInitForPharmacy();
        string PharmaDB = conrph.Database;
        if (txtFrom.Text.ToString() != "")
        {
            ViewState["FromDate"] = Convert.ToDateTime(txtFrom.Text).ToString("MM/dd/yyyy");

        }
        else
        {
            ViewState["FromDate"] = "";
        }
        if (txtTo.Text.ToString() != "")
        {

            ViewState["ToDate"] = Convert.ToDateTime(txtTo.Text).ToString("MM/dd/yyyy"); //txtTo.Value.ToString();


        }
        else
        {
            ViewState["ToDate"] = "";
        }
        string query="";
        if (ddlBillGroup.SelectedValue == "0")
        {
            query = "ALTER VIEW [dbo].[VW_GetAllLedger] AS (select  'LAB' as MainGroup, CashAmt,ChequeAmt ,RBLAmt,CTAmt,ModeOfPaymentName,BillGroup,LabpType,ReceivedAmount,PaymentDate,PatRegId,FirstName,BillPaymentid,CreatedBy,CreatedOn,PaymentMode " +
              "  ,BillNo,PatMainType,BillAmount,InsuranceAmount,DiscountAmt,PatientInsuType,'' as PaymentType,SerVicesName from Vw_LabPaymentTransactionRpt_UserWise_Ledger " +
              "  union all " +
              "  select 'Procedure' as MainGroup, CashAmt,ChequeAmt ,RBLAmt,CTAmt,ModeOfPaymentName,BillGroup,'' as LabpType,ReceivedAmount,PaymentDate,PatRegId,FirstName,ProcedureId,CreatedBy,CreatedOn,PaymentMode " +
              "  ,BillNo,PatMainType,BillAmount,InsuranceAmt,Discount,PatientInsuType,'' as PaymentType,'' as SerVicesName from Vw_ProcedurePaymentTransactionRpt_UserWise_Ledger " +
              "  union all " +
             "   select 'IPD' as MainGroup, ReceivedAmount,0,0,0 ,ModeOfPaymentName ,'IPD' as BillGroup,''as LabPType,ReceivedAmount,PaymentDate,PatRegId,PatientName,BillPaymentid,CreatedBy,CreatedOn,PaymentMode " +
             "   , BillNo,ModeOfPaymentName,0 as BillAmount,0 as InsuranceAmount,0 as DiscountAmt,ModeOfPaymentName,PaymentType,'' as ServiceName from Vw_IpdBillTransactionReport_Ledger "+
              " union all  " +
             " select 'Pharmacy' as MainGroup, CashAmt, ChequeAmt, RBLAmt, CTAmt, ModeOfPaymentName COLLATE Latin1_General_CI_AI, BillGroup COLLATE Latin1_General_CI_AI,'' as LabpType, ReceivedAmount , PaymentDate, PatRegId,  FirstName COLLATE Latin1_General_CI_AI "+
              "  ,  ProcedureId, CreatedBy COLLATE Latin1_General_CI_AI,  CreatedOn,     PaymentMode "+
              "  , BillNo, PatMainType COLLATE Latin1_General_CI_AI, BillAmount, InsuranceAmt, Discount,  PatientInsuType COLLATE Latin1_General_CI_AI,'' as PaymentType,'' as SerVicesName "+
              "   from " + PharmaDB + ".dbo.VW_GetPharmacyIncomeForHMS ";

        }
        else if (ddlBillGroup.SelectedValue == "Pharmacy")
        {
            query = "ALTER VIEW [dbo].[VW_GetAllLedger] AS (  select 'Pharmacy' as MainGroup, CashAmt, ChequeAmt, RBLAmt, CTAmt, ModeOfPaymentName, BillGroup,'' as LabpType, ReceivedAmount, PaymentDate, PatRegId,  FirstName,  ProcedureId, CreatedBy,  CreatedOn,  " +
              "   PaymentMode, BillNo, PatMainType, BillAmount, InsuranceAmt, Discount,  PatientInsuType,'' as PaymentType,'' as SerVicesName from " + PharmaDB + ".dbo.VW_GetPharmacyIncomeForHMS ";

        }
        else if (ddlBillGroup.SelectedValue == "IPD")
        {
            query = "ALTER VIEW [dbo].[VW_GetAllLedger] AS ( select 'IPD' as MainGroup, ReceivedAmount as CashAmt ,0 as ChequeAmt,0 as RBLAmt,0 as CTAmt ,ModeOfPaymentName ,'IPD' as BillGroup,''as LabPType,ReceivedAmount,PaymentDate,PatRegId,PatientName as FirstName,BillPaymentid,CreatedBy,CreatedOn,PaymentMode " +
            "   , BillNo,ModeOfPaymentName as PatMainType ,0 as BillAmount,0 as InsuranceAmount,0 as DiscountAmt,ModeOfPaymentName as PatientInsuType,PaymentType,'' as ServiceName from Vw_IpdBillTransactionReport_Ledger ";

        }
        else if (ddlBillGroup.SelectedValue != "IPD")
        {
            query = "ALTER VIEW [dbo].[VW_GetAllLedger] AS (select  'LAB' as MainGroup, CashAmt,ChequeAmt ,RBLAmt,CTAmt,ModeOfPaymentName,BillGroup,LabpType,ReceivedAmount,PaymentDate,PatRegId,FirstName,BillPaymentid,CreatedBy,CreatedOn,PaymentMode " +
              "  ,BillNo,PatMainType,BillAmount,InsuranceAmount,DiscountAmt,PatientInsuType,'' as PaymentType,SerVicesName from Vw_LabPaymentTransactionRpt_UserWise_Ledger " +
              "  union all " +
              "  select 'Procedure' as MainGroup, CashAmt,ChequeAmt ,RBLAmt,CTAmt,ModeOfPaymentName,BillGroup,'' as LabpType,ReceivedAmount,PaymentDate,PatRegId,FirstName,ProcedureId,CreatedBy,CreatedOn,PaymentMode " +
              "  ,BillNo,PatMainType,BillAmount,InsuranceAmt,Discount,PatientInsuType,'' as PaymentType,'' as SerVicesName from Vw_ProcedurePaymentTransactionRpt_UserWise_Ledger "+
             " union all  "+
             " select 'Pharmacy' as MainGroup, CashAmt, ChequeAmt, RBLAmt, CTAmt, ModeOfPaymentName COLLATE Latin1_General_CI_AI, BillGroup COLLATE Latin1_General_CI_AI,'' as LabpType, ReceivedAmount , PaymentDate, PatRegId,  FirstName COLLATE Latin1_General_CI_AI "+
             "   ,  ProcedureId, CreatedBy COLLATE Latin1_General_CI_AI,  CreatedOn,     PaymentMode "+
             "   , BillNo, PatMainType COLLATE Latin1_General_CI_AI, BillAmount, InsuranceAmt, Discount,  PatientInsuType COLLATE Latin1_General_CI_AI,'' as PaymentType,'' as SerVicesName "+
             "    from " + PharmaDB + ".dbo.VW_GetPharmacyIncomeForHMS ";
            
        }
        
      
        cmd1.CommandText = query + ")";
        conrp.Open();
        cmd1.ExecuteNonQuery();
        conrp.Close(); conrp.Dispose();
    }
    protected void Print_Click(object sender, EventArgs e)
    {
        string sql = "";
        BLLReports objreports = new BLLReports();
        try
        {
            Alterview();
            if (txtFrom.Text.ToString() != "")
            {
                ViewState["FromDate"] = txtFrom.Text.ToString() +" "+ ddlTimeFrom.Text; ;

            }
            else
            {
                ViewState["FromDate"] = "";
            }
            if (txtTo.Text.ToString() != "")
            {

                ViewState["ToDate"] = txtTo.Text.ToString() + " " + ddlTimeTo.Text;


            }
            else
            {
                ViewState["ToDate"] = "";
            }
            int BranchId = Convert.ToInt32(Session["BranchId"]);
            int FId = Convert.ToInt32(Session["FId"]);
            objreports.FillProcedureIncomeReport_Ledger(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), ddlUser.SelectedValue, Convert.ToInt32(RdbPayment.SelectedValue), ddlBillGroup.SelectedValue, BranchId, FId, ddlBank.SelectedItem.Text);
            objreports.FillIpdDailyIncomeReport_Ledger(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), ddlUser.SelectedValue, Convert.ToInt32(RdbPayment.SelectedValue), BranchId, FId, ddlBank.SelectedItem.Text);
            objreports.FillLABIncomeReport_Ledger(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), ddlUser.SelectedValue, Convert.ToInt32(RdbPayment.SelectedValue), ddlBillGroup.SelectedValue, BranchId, FId, ddlBank.SelectedItem.Text);
            objreports.FillPharmacyIncomeReport_Ledger(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), ddlUser.SelectedValue, Convert.ToInt32(RdbPayment.SelectedValue), ddlBillGroup.SelectedValue, BranchId, FId, ddlBank.SelectedItem.Text);
            Alterview_Pharma();
            Alterview_Main();

            Session.Add("rptsql", sql);
            Session["rptname"] = Server.MapPath("~/Reports/Rpt_UserWisLedger_Report.rpt");
            Session["reportname"] = "UserWisLedger_Report";
            Session["RPTFORMAT"] = "pdf";


            string close = "<script language='javascript'>javascript:OpenReport();</script>";
            Type title1 = this.GetType();
            Page.ClientScript.RegisterStartupScript(title1, "", close);

            
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        string sql = "";
        BLLReports objreports = new BLLReports();
        try
        {
            Alterview();
            if (txtFrom.Text.ToString() != "")
            {
                ViewState["FromDate"] = txtFrom.Text.ToString() + " " + ddlTimeFrom.Text; ;

            }
            else
            {
                ViewState["FromDate"] = "";
            }
            if (txtTo.Text.ToString() != "")
            {

                ViewState["ToDate"] = txtTo.Text.ToString() + " " + ddlTimeTo.Text;


            }
            else
            {
                ViewState["ToDate"] = "";
            }
            int BranchId = Convert.ToInt32(Session["BranchId"]);
            int FId = Convert.ToInt32(Session["FId"]);
            objreports.FillProcedureIncomeReport_Ledger(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), ddlUser.SelectedValue, Convert.ToInt32(RdbPayment.SelectedValue), ddlBillGroup.SelectedValue, BranchId, FId, ddlBank.SelectedItem.Text);
            objreports.FillIpdDailyIncomeReport_Ledger(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), ddlUser.SelectedValue, Convert.ToInt32(RdbPayment.SelectedValue), BranchId, FId, ddlBank.SelectedItem.Text);
            objreports.FillLABIncomeReport_Ledger(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), ddlUser.SelectedValue, Convert.ToInt32(RdbPayment.SelectedValue), ddlBillGroup.SelectedValue, BranchId, FId, ddlBank.SelectedItem.Text);
            Alterview_Main();

            Session.Add("rptsql", sql);
            Session["rptname"] = Server.MapPath("~/Reports/Rpt_UserWisLedger_Report.rpt");
            Session["reportname"] = "UserWisLedger_Report";
            Session["RPTFORMAT"] = "EXCEL";


            string close = "<script language='javascript'>javascript:OpenReport();</script>";
            Type title1 = this.GetType();
            Page.ClientScript.RegisterStartupScript(title1, "", close);


        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void btnprintService_Click(object sender, EventArgs e)
    {
        string sql = "";
        BLLReports objreports = new BLLReports();
        try
        {

            if (txtFrom.Text.ToString() != "")
            {
                ViewState["FromDate"] = txtFrom.Text.ToString() + " " + ddlTimeFrom.Text; ;

            }
            else
            {
                ViewState["FromDate"] = "";
            }
            if (txtTo.Text.ToString() != "")
            {

                ViewState["ToDate"] = txtTo.Text.ToString() + " " + ddlTimeTo.Text;


            }
            else
            {
                ViewState["ToDate"] = "";
            }
            int BranchId = Convert.ToInt32(Session["BranchId"]);
            int FId = Convert.ToInt32(Session["FId"]);
            objreports.FillProcedureIncomeReport_service(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), ddlUser.SelectedValue, Convert.ToInt32(RdbPayment.SelectedValue), ddlBillGroup.SelectedValue, BranchId, FId,ddlBank.SelectedItem.Text);

            Session.Add("rptsql", sql);
            Session["rptname"] = Server.MapPath("~/Reports/Rpt_UserwiseProcedureCashReport_Service.rpt");
            Session["reportname"] = "UserWiseProcedureCash_Report_service";
            Session["RPTFORMAT"] = "pdf";


            string close = "<script language='javascript'>javascript:OpenReport();</script>";
            Type title1 = this.GetType();
            Page.ClientScript.RegisterStartupScript(title1, "", close);


        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void btnExcelService_Click(object sender, EventArgs e)
    {
        string sql = "";
        BLLReports objreports = new BLLReports();
        try
        {

            if (txtFrom.Text.ToString() != "")
            {
                ViewState["FromDate"] = txtFrom.Text.ToString() + " " + ddlTimeFrom.Text; ;

            }
            else
            {
                ViewState["FromDate"] = "";
            }
            if (txtTo.Text.ToString() != "")
            {

                ViewState["ToDate"] = txtTo.Text.ToString() + " " + ddlTimeTo.Text;


            }
            else
            {
                ViewState["ToDate"] = "";
            }
            int BranchId = Convert.ToInt32(Session["BranchId"]);
            int FId = Convert.ToInt32(Session["FId"]);
            objreports.FillProcedureIncomeReport_service(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), ddlUser.SelectedValue, Convert.ToInt32(RdbPayment.SelectedValue), ddlBillGroup.SelectedValue, BranchId, FId,ddlBank.SelectedItem.Text);

            Session.Add("rptsql", sql);
            Session["rptname"] = Server.MapPath("~/Reports/Rpt_UserwiseProcedureCashReport_Service.rpt");
            Session["reportname"] = "UserWiseProcedureCash_Report_service";
            Session["RPTFORMAT"] = "EXCEL";


            string close = "<script language='javascript'>javascript:OpenReport();</script>";
            Type title1 = this.GetType();
            Page.ClientScript.RegisterStartupScript(title1, "", close);


        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
}