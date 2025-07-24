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


public partial class MonthWiseIncome :BasePage
{
    BLLReports ObjDOReport = new BLLReports();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
          
            //RdbPayment.SelectedValue = "All";
           // FillUsers();
            FillUsers();
           
           

        }

    }
   
  
    [WebMethod]
    [ScriptMethod]
    public static string[] SearchReferBy(string prefixText, int count)
    {
        SqlConnection con = new SqlConnection();
        string PType = "0";
        DataTable dt1 = new DataTable();
        // new String[dt1.Rows.Count];
        string[] DummyTest = new String[dt1.Rows.Count];
       
            PType = "0";
        
        //if (PType == "1")
        //{
        //    con = DataAccess.ConInitForPathology();
        //}
        //if (PType == "2")
        //{
        //    con = DataAccess.ConInitForRadiology();
        //}
        //if (PType == "3")
        //{
        //    con = DataAccess.ConInitForMedical();
        //}
        //if (PType == "4")
        //{
        //    con = DataAccess.ConInitForCardiology();
        //}
        con = DataAccess.ConInitForDC();
        if (PType == "0")
        {
            string collectioncode = Convert.ToString(HttpContext.Current.Session["CenterCodeTemp"]);
            // string dd = HttpContext.Current.s(txtCenter.Text);
            SqlDataAdapter sda = null;
            con.Open();

            sda = new SqlDataAdapter("SELECT distinct ReferBy as name from  labregistration where  ( ReferBy like N'%" + prefixText + "%') ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            con.Dispose();
            string[] tests = new String[dt.Rows.Count];
            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                tests.SetValue(dr["name"] , i);
                i++;
            }
            return tests;
        }
        return DummyTest;
    }
    protected void txtRefBy_TextChanged(object sender, EventArgs e)
    {
       
    }

    protected void FillUsers()
    {
        int UserId = Convert.ToInt32(Session["UserId"]);
        int BranchId = Convert.ToInt32(Session["BranchId"]);
        int FId = Convert.ToInt32(Session["FId"]);
        DataTable dt = new DataTable();
        dt = ObjDOReport.FillIncomeBillGroup(BranchId);
        GroupTyp.DataSource = dt;
        GroupTyp.DataValueField = "BillBroupId";
        GroupTyp.DataTextField = "BillGroupName";
        GroupTyp.DataBind();
    }



    private void Reset()
    {

    }

  
   

   
    public void AlterPharma()
    {
        try
        {

           
            int BranchId = Convert.ToInt32(Session["BranchId"]);
            int FId = Convert.ToInt32(Session["FId"]);

            //DALReports objDalReport = new DALReports();
            //DataSet dsCashSummary = new DataSet();
            ////ReportDocument crystalReport = new ReportDocument();
            //////crystalReport.Load(Server.MapPath("~/Reports/Rpt_DeptStoreWiseItems.rpt"));

            ////crystalReport.Load(Server.MapPath("~/Reports/Rpt_UserWiseDailyCashReport.rpt"));
            //dsCashSummary = objDalReport.GetUserWiseIncomeReport(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), Convert.ToInt32(ddldeptname.SelectedValue), ddlUser.SelectedValue, RdbPayment.SelectedValue, BranchId, FId, RdbPatientType.SelectedValue);
            ////crystalReport.SetDataSource(dsCashSummary);

            ////crystalReport.ExportToHttpResponse
            ////(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Employee");


            string sql = "";
            SqlConnection conrp = DataAccess.ConInitForPharmacy();
            SqlCommand cmd1 = conrp.CreateCommand();

            string query = "ALTER VIEW [dbo].[Vw_DailyCashReport] AS (SELECT dbo.PatientIssueVoucher.PatientType, dbo.PatientIssueVoucher.PatRegNo, dbo.PatientIssueVoucher.PatientName, dbo.PatientIssueVoucher.PatAddress,   " +
                           " CONVERT(varchar(10), dbo.PatientIssueVoucher.Age) + ' ' + dbo.PatientIssueVoucher.AgeType AS Age, dbo.PatientIssueVoucher.Allergies,   " +
                           " dbo.PatientIssueVoucher.DrName, dbo.PatientIssueVoucher.IssueVoucherNo, dbo.PatientIssueVoucher.IssueDate, dbo.PatientIssueVoucher.PaymentType,   " +
                           " dbo.PatientIssueVoucher.TotalAmt, CASE dbo.PatientIssueVoucher.PaymentType WHEN 0 THEN SUM(dbo.PatientIssueVoucher.AmountReceived) END AS Cash,   " +
                           " CASE dbo.PatientIssueVoucher.PaymentType WHEN 2 THEN SUM(dbo.PatientIssueVoucher.AmountReceived) END AS RCard,   " +
                           " CASE dbo.PatientIssueVoucher.PaymentType WHEN 1 THEN SUM(dbo.PatientIssueVoucher.AmountReceived) END AS Cheque,   " +
                           " CASE dbo.PatientIssueVoucher.PaymentType WHEN 4 THEN SUM(dbo.PatientIssueVoucher.AmountReceived) END AS ChargeToAccount,   " +
                           " CASE dbo.PatientIssueVoucher.IsInsurance WHEN 1 THEN SUM(dbo.PatientIssueVoucher.AmountReceived) END AS InsuranceCash,   " +
                           " CASE PatientIssueVoucher.DiscType WHEN 0 THEN PatientIssueVoucher.DiscAmt WHEN 1 THEN ((PatientIssueVoucher.GrandTotal * PatientIssueVoucher.DiscAmt)  " +
                           " / 100) END AS DiscAmt, dbo.PatientIssueVoucher.TotalTax, dbo.PatientIssueVoucher.GrandTotal, SUM(dbo.PatientIssueVoucher.AmountReceived)   " +
                           " AS AmountReceived, dbo.PatientIssueVoucher.Balance, dbo.PatientIssueVoucher.DiscRemark, dbo.PatientIssueVoucher.Note,   " +
                           " dbo.PatientIssueVoucher.CreatedBy, dbo.PatientIssueVoucher.DeptId, dbo.PatientIssueVoucher.ChequeNo, dbo.PatientIssueVoucher.BankName,   " +
                           " dbo.PatientIssueVoucher.InsuranceComp, dbo.PatientIssueVoucher.InsuranceAmount, dbo.PatientIssueVoucher.StaffName,   " +
                           " dbo.PatientIssueVoucher.StaffRemark, dbo.PatientIssueVoucher.CardName, dbo.PatientIssueVoucher.FId, dbo.PatientIssueVoucher.BranchId,   " +
                           " dbo.PatientIssueVoucher.CreatedOn, dbo.tbl_Dept.DeptName, dbo.PatientIssueVoucher.IsInsurance, dbo.PatientIssueVoucher.FinalSettledBy,   " +
                           " dbo.PatientIssueVoucher.FinalSettledFlag, dbo.PatientIssueVoucher.IsPrescription, dbo.PatientIssueVoucher.IsApprovedPrescription,PatientIssueVoucher.fullcancelvoucher  " +
                           " FROM    dbo.PatientIssueVoucher INNER JOIN  " +
                           " dbo.tbl_Dept ON dbo.PatientIssueVoucher.DeptId = dbo.tbl_Dept.DeptId  " +
                               " Where 1=1";
            query += " and ((dbo.PatientIssueVoucher.FullCancelVoucher <> 1) AND (dbo.PatientIssueVoucher.IsPrescription = 1) AND   " +
                           " (dbo.PatientIssueVoucher.IsApprovedPrescription = 1) OR  " +
                           " (dbo.PatientIssueVoucher.FullCancelVoucher <> 1) AND (dbo.PatientIssueVoucher.IsPrescription IS NULL) AND   " +
                           " (dbo.PatientIssueVoucher.IsApprovedPrescription IS NULL))  " +
                           "  and YEAR(PatientIssueVoucher.CreatedOn)=" + ddlYear.SelectedValue + " ";
               //  "  and (CAST(CAST(YEAR(PatientIssueVoucher.CreatedOn) AS varchar(4)) + '/' + CAST(MONTH(PatientIssueVoucher.CreatedOn) AS varchar(2)) + '/' + CAST(DAY(PatientIssueVoucher.CreatedOn) AS varchar(2)) AS datetime))  between ('" + Convert.ToDateTime(txtFrom.Text).ToString("MM/dd/yyyy") + "') and ('" + Convert.ToDateTime(txtTo.Text).ToString("MM/dd/yyyy") + "') "+// 
              //   "  and (CAST(CAST(YEAR(PatientIssueVoucher.CreatedOn) AS varchar(4)) + '/' + CAST(MONTH(PatientIssueVoucher.CreatedOn) AS varchar(2)) + '/' + CAST(DAY(PatientIssueVoucher.CreatedOn) AS varchar(2)) AS datetime))  between ('" + Convert.ToDateTime(txtFrom.Text).ToString("MM/dd/yyyy") + "') and ('" + Convert.ToDateTime(txtTo.Text).ToString("MM/dd/yyyy") + "')";// 
           // " and PatientIssueVoucher.CreatedOn between '" + Convert.ToString(ViewState["FromDate"]) + "'  and '" + Convert.ToString(ViewState["ToDate"]) + "' ";

            query += "  and  PatientType<>'IPD'   ";


            query += " GROUP BY dbo.PatientIssueVoucher.PatientType, dbo.PatientIssueVoucher.PatRegNo, dbo.PatientIssueVoucher.PatientName, dbo.PatientIssueVoucher.PatAddress,   " +
                           " dbo.PatientIssueVoucher.Age, dbo.PatientIssueVoucher.AgeType, dbo.PatientIssueVoucher.Allergies, dbo.PatientIssueVoucher.DrName,   " +
                           " dbo.PatientIssueVoucher.IssueVoucherNo, dbo.PatientIssueVoucher.IssueDate, dbo.PatientIssueVoucher.PaymentType, dbo.PatientIssueVoucher.TotalAmt,   " +
                           " dbo.PatientIssueVoucher.DiscAmt, dbo.PatientIssueVoucher.TotalTax, dbo.PatientIssueVoucher.DiscType, dbo.PatientIssueVoucher.GrandTotal,   " +
                           " dbo.PatientIssueVoucher.Balance, dbo.PatientIssueVoucher.DiscRemark, dbo.PatientIssueVoucher.Note, dbo.PatientIssueVoucher.CreatedBy,   " +
                           " dbo.PatientIssueVoucher.DeptId, dbo.PatientIssueVoucher.ChequeNo, dbo.PatientIssueVoucher.BankName, dbo.PatientIssueVoucher.InsuranceComp, " +
                           " dbo.PatientIssueVoucher.InsuranceAmount, dbo.PatientIssueVoucher.StaffName, dbo.PatientIssueVoucher.StaffRemark, dbo.PatientIssueVoucher.CardName,   " +
                           " dbo.PatientIssueVoucher.FId, dbo.PatientIssueVoucher.BranchId, dbo.PatientIssueVoucher.CreatedOn, dbo.tbl_Dept.DeptName,   " +
                           " dbo.PatientIssueVoucher.IsInsurance, dbo.PatientIssueVoucher.FinalSettledBy, dbo.PatientIssueVoucher.FinalSettledFlag,   " +
                           " dbo.PatientIssueVoucher.IsPrescription, dbo.PatientIssueVoucher.IsApprovedPrescription, PatientIssueVoucher.fullcancelvoucher  ";

            cmd1.CommandText = query + ")";

            conrp.Open();
            cmd1.ExecuteNonQuery();
            conrp.Close(); conrp.Dispose();
            alterviewChild();
            alterviewChild_Refund();
            //Session.Add("rptsql", sql);
            //Session["rptname"] = Server.MapPath("~/Reports/Rpt_UserWiseDailyCashReport_Details.rpt");
            //Session["reportname"] = "Rpt_UserWiseDailyCashReport_Details";
            //Session["RPTFORMAT"] = "pdf";

            //string close = "<script language='javascript'>javascript:OpenReport();</script>";
            //Type title1 = this.GetType();
            //Page.ClientScript.RegisterStartupScript(title1, "", close);
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    public void alterviewChild_Refund()
    {
        SqlConnection conrp = DataAccess.ConInitForPharmacy();
        SqlCommand cmd1 = conrp.CreateCommand();

        string query = "ALTER VIEW [dbo].[Vw_DailyCashReport_Child_Refund] AS (SELECT        PatIssueVoucherDetails.PatIssueVoucherDetailId, PatIssueVoucherDetails.ItemId, PatIssueVoucherDetails.BatchNo, PatIssueVoucherDetails.ExpDate, PatIssueVoucherDetails.CurrentStock, " +
                      "  PatIssueVoucherDetails.IssueQty, PatIssueVoucherDetails.Rate, PatIssueVoucherDetails.Tax, PatIssueVoucherDetails.DeptId, PatIssueVoucherDetails.FId, PatIssueVoucherDetails.BranchId, PatIssueVoucherDetails.CreatedBy, " +
                      "  PatIssueVoucherDetails.CreatedOn, PatIssueVoucherDetails.UpdatedBy, PatIssueVoucherDetails.UpdatedOn, PatIssueVoucherDetails.PatIssueVoucherId, PatIssueVoucherDetails.IssueVoucherNo, " +
                      "  PatIssueVoucherDetails.IssueDate, PatIssueVoucherDetails.DoseId, PatIssueVoucherDetails.Days, PatIssueVoucherDetails.DoseTimeId, " +
                      "  PatIssueVoucherDetails.Remark, PatIssueVoucherDetails.IsPartialCancel,  " +
                      "  tbl_Items.ItemName, " +
                      "  round((PatIssueVoucherDetails.Rate*PatIssueVoucherDetails.IssueQty)* PatIssueVoucherDetails.Tax/100,0) as TaxAmount " +
                      "  FROM            PatIssueVoucherDetails INNER JOIN " +
                      "  tbl_Items ON PatIssueVoucherDetails.ItemId = tbl_Items.ItemId  " +
                       "  where PatIssueVoucherDetails.IssueQty<0 and Year( PatIssueVoucherDetails.CreatedOn)=" + ddlYear.SelectedValue + " ";// 
                     // "  where PatIssueVoucherDetails.IssueQty<0 and (CAST(CAST(YEAR(PatIssueVoucherDetails.CreatedOn) AS varchar(4)) + '/' + CAST(MONTH(PatIssueVoucherDetails.CreatedOn) AS varchar(2)) + '/' + CAST(DAY(PatIssueVoucherDetails.CreatedOn) AS varchar(2)) AS datetime))  between ('" + Convert.ToDateTime(txtFrom.Text).ToString("MM/dd/yyyy") + "') and ('" + Convert.ToDateTime(txtTo.Text).ToString("MM/dd/yyyy") + "')";// 



        cmd1.CommandText = query + ")";

        conrp.Open();
        cmd1.ExecuteNonQuery();
        conrp.Close(); conrp.Dispose();
    }
    public void alterviewChild()
    {
        SqlConnection conrp = DataAccess.ConInitForPharmacy();
        SqlCommand cmd1 = conrp.CreateCommand();

        string query = "ALTER VIEW [dbo].[Vw_DailyCashReport_Child] AS (SELECT        PatIssueVoucherDetails.PatIssueVoucherDetailId, PatIssueVoucherDetails.ItemId, PatIssueVoucherDetails.BatchNo, PatIssueVoucherDetails.ExpDate, PatIssueVoucherDetails.CurrentStock, " +
                      "  PatIssueVoucherDetails.IssueQty, PatIssueVoucherDetails.Rate, PatIssueVoucherDetails.Tax, PatIssueVoucherDetails.DeptId, PatIssueVoucherDetails.FId, PatIssueVoucherDetails.BranchId, PatIssueVoucherDetails.CreatedBy, " +
                      "  PatIssueVoucherDetails.CreatedOn, PatIssueVoucherDetails.UpdatedBy, PatIssueVoucherDetails.UpdatedOn, PatIssueVoucherDetails.PatIssueVoucherId, PatIssueVoucherDetails.IssueVoucherNo, " +
                      "  PatIssueVoucherDetails.IssueDate, PatIssueVoucherDetails.DoseId, PatIssueVoucherDetails.Days, PatIssueVoucherDetails.DoseTimeId, " +
                      "  PatIssueVoucherDetails.Remark, PatIssueVoucherDetails.IsPartialCancel,  " +
                      "  tbl_Items.ItemName, " +
                      "  round((PatIssueVoucherDetails.Rate*PatIssueVoucherDetails.IssueQty)* PatIssueVoucherDetails.Tax/100,0) as TaxAmount " +
                      "  FROM            PatIssueVoucherDetails INNER JOIN " +
                      "  tbl_Items ON PatIssueVoucherDetails.ItemId = tbl_Items.ItemId  " +
                      "  where PatIssueVoucherDetails.IssueQty>0 and Year( PatIssueVoucherDetails.CreatedOn)=" + ddlYear.SelectedValue + " ";// 
                    // "  where PatIssueVoucherDetails.IssueQty>0 and (CAST(CAST(YEAR(PatIssueVoucherDetails.CreatedOn) AS varchar(4)) + '/' + CAST(MONTH(PatIssueVoucherDetails.CreatedOn) AS varchar(2)) + '/' + CAST(DAY(PatIssueVoucherDetails.CreatedOn) AS varchar(2)) AS datetime))  between ('" + Convert.ToDateTime(txtFrom.Text).ToString("MM/dd/yyyy") + "') and ('" + Convert.ToDateTime(txtTo.Text).ToString("MM/dd/yyyy") + "')";// 



        cmd1.CommandText = query + ")";

        conrp.Open();
        cmd1.ExecuteNonQuery();
        conrp.Close(); conrp.Dispose();
    }
  
  
  
    protected void btnAllPrint_Click(object sender, EventArgs e)
    {
        BLLReports objreports = new BLLReports();
        int BranchId = Convert.ToInt32(Session["BranchId"]);
        int FId = Convert.ToInt32(Session["FId"]);


       
        // int BranchId = Convert.ToInt32(Session["BranchId"]);
        //int FId = Convert.ToInt32(Session["FId"]);

        //DALReports objDalReport = new DALReports();
        //DataSet dsCashSummary = new DataSet();
        ////ReportDocument crystalReport = new ReportDocument();
        //////crystalReport.Load(Server.MapPath("~/Reports/Rpt_DeptStoreWiseItems.rpt"));

        ////crystalReport.Load(Server.MapPath("~/Reports/Rpt_UserWiseDailyCashReport.rpt"));
        //dsCashSummary = objDalReport.GetUserWiseIncomeReport(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), Convert.ToInt32(ddldeptname.SelectedValue), ddlUser.SelectedValue, RdbPayment.SelectedValue, BranchId, FId, RdbPatientType.SelectedValue);
        ////crystalReport.SetDataSource(dsCashSummary);

        ////crystalReport.ExportToHttpResponse
        ////(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Employee");


        string sql = "";
        SqlConnection conrp = DataAccess.ConInitForPharmacy();
        SqlCommand cmd1 = conrp.CreateCommand();

        string query = "ALTER VIEW [dbo].[Vw_DailyCashReport] AS (SELECT dbo.PatientIssueVoucher.PatientType, dbo.PatientIssueVoucher.PatRegNo, dbo.PatientIssueVoucher.PatientName, dbo.PatientIssueVoucher.PatAddress,   " +
                       " CONVERT(varchar(10), dbo.PatientIssueVoucher.Age) + ' ' + dbo.PatientIssueVoucher.AgeType AS Age, dbo.PatientIssueVoucher.Allergies,   " +
                       " dbo.PatientIssueVoucher.DrName, dbo.PatientIssueVoucher.IssueVoucherNo, dbo.PatientIssueVoucher.IssueDate, dbo.PatientIssueVoucher.PaymentType,   " +
                       " dbo.PatientIssueVoucher.TotalAmt, CASE dbo.PatientIssueVoucher.PaymentType WHEN 0 THEN SUM(dbo.PatientIssueVoucher.AmountReceived) END AS Cash,   " +
                       " CASE dbo.PatientIssueVoucher.PaymentType WHEN 2 THEN SUM(dbo.PatientIssueVoucher.AmountReceived) END AS RCard,   " +
                       " CASE dbo.PatientIssueVoucher.PaymentType WHEN 1 THEN SUM(dbo.PatientIssueVoucher.AmountReceived) END AS Cheque,   " +
                       " CASE dbo.PatientIssueVoucher.PaymentType WHEN 4 THEN SUM(dbo.PatientIssueVoucher.AmountReceived) END AS ChargeToAccount,   " +
                       " CASE dbo.PatientIssueVoucher.IsInsurance WHEN 1 THEN SUM(dbo.PatientIssueVoucher.AmountReceived) END AS InsuranceCash,   " +
                       " CASE PatientIssueVoucher.DiscType WHEN 0 THEN PatientIssueVoucher.DiscAmt WHEN 1 THEN ((PatientIssueVoucher.GrandTotal * PatientIssueVoucher.DiscAmt)  " +
                       " / 100) END AS DiscAmt, dbo.PatientIssueVoucher.TotalTax, dbo.PatientIssueVoucher.GrandTotal, SUM(dbo.PatientIssueVoucher.AmountReceived)   " +
                       " AS AmountReceived, dbo.PatientIssueVoucher.Balance, dbo.PatientIssueVoucher.DiscRemark, dbo.PatientIssueVoucher.Note,   " +
                       " dbo.PatientIssueVoucher.CreatedBy, dbo.PatientIssueVoucher.DeptId, dbo.PatientIssueVoucher.ChequeNo, dbo.PatientIssueVoucher.BankName,   " +
                       " dbo.PatientIssueVoucher.InsuranceComp, dbo.PatientIssueVoucher.InsuranceAmount, dbo.PatientIssueVoucher.StaffName,   " +
                       " dbo.PatientIssueVoucher.StaffRemark, dbo.PatientIssueVoucher.CardName, dbo.PatientIssueVoucher.FId, dbo.PatientIssueVoucher.BranchId,   " +
                       " dbo.PatientIssueVoucher.CreatedOn, dbo.tbl_Dept.DeptName, dbo.PatientIssueVoucher.IsInsurance, dbo.PatientIssueVoucher.FinalSettledBy,   " +
                       " dbo.PatientIssueVoucher.FinalSettledFlag, dbo.PatientIssueVoucher.IsPrescription, dbo.PatientIssueVoucher.IsApprovedPrescription,PatientIssueVoucher.fullcancelvoucher  " +
                       " FROM    dbo.PatientIssueVoucher INNER JOIN  " +
                       " dbo.tbl_Dept ON dbo.PatientIssueVoucher.DeptId = dbo.tbl_Dept.DeptId  " +
                           " Where 1=1";
        query += " and ((dbo.PatientIssueVoucher.FullCancelVoucher <> 1) AND (dbo.PatientIssueVoucher.IsPrescription = 1) AND   " +
                       " (dbo.PatientIssueVoucher.IsApprovedPrescription = 1) OR  " +
                       " (dbo.PatientIssueVoucher.FullCancelVoucher <> 1) AND (dbo.PatientIssueVoucher.IsPrescription IS NULL) AND   " +
                       " (dbo.PatientIssueVoucher.IsApprovedPrescription IS NULL))  " +
                         "  and Year( PatientIssueVoucher.CreatedOn)=" + ddlYear.SelectedValue + " ";// 
      //  "  and (CAST(CAST(YEAR(PatientIssueVoucher.CreatedOn) AS varchar(4)) + '/' + CAST(MONTH(PatientIssueVoucher.CreatedOn) AS varchar(2)) + '/' + CAST(DAY(PatientIssueVoucher.CreatedOn) AS varchar(2)) AS datetime))  between ('" + Convert.ToDateTime(txtFrom.Text).ToString("MM/dd/yyyy") + "') and ('" + Convert.ToDateTime(txtTo.Text).ToString("MM/dd/yyyy") + "')";// 



        query += " GROUP BY dbo.PatientIssueVoucher.PatientType, dbo.PatientIssueVoucher.PatRegNo, dbo.PatientIssueVoucher.PatientName, dbo.PatientIssueVoucher.PatAddress,   " +
                       " dbo.PatientIssueVoucher.Age, dbo.PatientIssueVoucher.AgeType, dbo.PatientIssueVoucher.Allergies, dbo.PatientIssueVoucher.DrName,   " +
                       " dbo.PatientIssueVoucher.IssueVoucherNo, dbo.PatientIssueVoucher.IssueDate, dbo.PatientIssueVoucher.PaymentType, dbo.PatientIssueVoucher.TotalAmt,   " +
                       " dbo.PatientIssueVoucher.DiscAmt, dbo.PatientIssueVoucher.TotalTax, dbo.PatientIssueVoucher.DiscType, dbo.PatientIssueVoucher.GrandTotal,   " +
                       " dbo.PatientIssueVoucher.Balance, dbo.PatientIssueVoucher.DiscRemark, dbo.PatientIssueVoucher.Note, dbo.PatientIssueVoucher.CreatedBy,   " +
                       " dbo.PatientIssueVoucher.DeptId, dbo.PatientIssueVoucher.ChequeNo, dbo.PatientIssueVoucher.BankName, dbo.PatientIssueVoucher.InsuranceComp, " +
                       " dbo.PatientIssueVoucher.InsuranceAmount, dbo.PatientIssueVoucher.StaffName, dbo.PatientIssueVoucher.StaffRemark, dbo.PatientIssueVoucher.CardName,   " +
                       " dbo.PatientIssueVoucher.FId, dbo.PatientIssueVoucher.BranchId, dbo.PatientIssueVoucher.CreatedOn, dbo.tbl_Dept.DeptName,   " +
                       " dbo.PatientIssueVoucher.IsInsurance, dbo.PatientIssueVoucher.FinalSettledBy, dbo.PatientIssueVoucher.FinalSettledFlag,   " +
                       " dbo.PatientIssueVoucher.IsPrescription, dbo.PatientIssueVoucher.IsApprovedPrescription, PatientIssueVoucher.fullcancelvoucher  ";

        cmd1.CommandText = query + ")";

        conrp.Open();
        cmd1.ExecuteNonQuery();
        conrp.Close(); conrp.Dispose();
       

       


        //if (BillGroup == "Radiology")
        //{
            SqlConnection con1H = DataAccess.ConInitForRadiology();
            // con1H.Open();
            string PatDB = con1H.Database;
                       string query12 = "ALTER VIEW [dbo].[VW_LabWiseRevuenew_Year] AS (SELECT   'OPD' as  CenterName,  count( LabRegistration.PatRegId) as NoOfPatient,  sum( LabServiceDetails.Qty) as Qty ,sum( LabServiceDetails.BillServiceCharges) AS TotalCharges, LabServiceDetails.FId, LabServiceDetails.BranchId, " +
                           " BillGroup.GroupName, " +
                           " " + PatDB + ".dbo.SubDepartment.subdeptName " +
                           " , SUM(LabBillPaymentTrns.ReceivedAmount) AS RecAmt, SUM(LabBillPaymentTrns.DiscountAmt) AS Discount, SUM(LabBillPaymentTrns.InsuranceAmount) AS InsuAmt "+
                           //" FROM            LabServiceDetails INNER JOIN " +
                           //" BillGroup ON LabServiceDetails.BillGroup = BillGroup.BillGroupId INNER JOIN " +
                           //" LabRegistration ON LabServiceDetails.BillNo = LabRegistration.BillNo AND LabServiceDetails.LabNo = LabRegistration.LabNo AND LabServiceDetails.PatRegId = LabRegistration.PatRegId INNER JOIN " +
                           //" " + PatDB + ".dbo.MainTest ON LabServiceDetails.MTCode = " + PatDB + ".dbo.MainTest.MTCode INNER JOIN " +
                           //" " + PatDB + ".dbo.SubDepartment ON " + PatDB + ".dbo.MainTest.SDCode = " + PatDB + ".dbo.SubDepartment.SDCode " +
                                " FROM  LabServiceDetails INNER JOIN BillGroup ON LabServiceDetails.BillGroup = BillGroup.BillGroupId INNER JOIN "+
                              "  LabRegistration ON LabServiceDetails.BillNo = LabRegistration.BillNo AND LabServiceDetails.LabNo = LabRegistration.LabNo AND LabServiceDetails.PatRegId = LabRegistration.PatRegId INNER JOIN "+
                              "  " + PatDB + ".dbo.MainTest ON LabServiceDetails.MTCode = " + PatDB + ".dbo.MainTest.MTCode INNER JOIN " +
                              "  " + PatDB + ".dbo.SubDepartment ON " + PatDB + ".dbo.MainTest.SDCode = " + PatDB + ".dbo.SubDepartment.SDCode INNER JOIN " +
                              "  LabBillPaymentTrns ON LabRegistration.PatRegId = LabBillPaymentTrns.PatRegId AND LabRegistration.LabNo = LabBillPaymentTrns.LabNo " +

                           " WHERE        (LabRegistration.CancelBill <> 1) AND (LabRegistration.BranchId = 1) AND  YEAR( LabRegistration.CreatedOn)="+ddlYear.SelectedValue+" "+
                           //" (CAST(CAST(YEAR(LabRegistration.CreatedOn) AS varchar(4)) + '/' + CAST(MONTH(LabRegistration.CreatedOn) AS varchar(2)) " +
                           //" + '/' + CAST(DAY(LabRegistration.CreatedOn) AS varchar(2)) AS datetime) BETWEEN '" + ViewState["FromDate"] + "'  and '" + ViewState["ToDate"] + "') " +
                           " group by LabServiceDetails.FId,  LabServiceDetails.BranchId, BillGroup.GroupName," + PatDB + ".dbo.SubDepartment.subdeptName union all " +//and YEAR(patmstd.Patregdate)=" + ddlYear.SelectedValue + " and Month(patmstd.Patregdate)=" + DdlMonth.SelectedValue + " ";
                           " SELECT 'IPD' as  CenterName,  count( IpdBillMaster.PatRegId) as NoOfPatient, sum( IpdBillServiceDetails.Qty) as Qty, " +
                           " SUM(IpdBillServiceDetails.TotalCharges) AS TotalCharges,IpdBillServiceDetails.FId, IpdBillServiceDetails.BranchId,  BillGroup.GroupName, " +
                           " isnull(" + PatDB + ".dbo.SubDepartment.subdeptName,'') as subdeptName, SUM(IpdBillMaster.AmountReceived) AS RecAmt, SUM(IpdBillMaster.Discount)as Discount , SUM(IpdBillMaster.InsuranceAmt) AS InsuAmt  FROM            IpdBillServiceDetails LEFT OUTER JOIN " +
                           " " + PatDB + ".dbo.MainTest ON IpdBillServiceDetails.MTCode = " + PatDB + ".dbo.MainTest.MTCode LEFT OUTER JOIN" +
                           " " + PatDB + ".dbo.SubDepartment ON " + PatDB + ".dbo.MainTest.SDCode = " + PatDB + ".dbo.SubDepartment.SDCode LEFT OUTER JOIN " +
                           " IpdBillMaster ON IpdBillServiceDetails.PatRegId = IpdBillMaster.PatRegId AND IpdBillServiceDetails.IpdNo = IpdBillMaster.IpdNo LEFT OUTER JOIN " +
                           " BillGroup ON IpdBillServiceDetails.BillGroupId = BillGroup.BillGroupId where IpdBillMaster.IsDischarge=1  and  " +
                           " IpdBillServiceDetails.FId=1 and IpdBillServiceDetails.BranchId=1 and IpdBillServiceDetails.BillGroupId =20 " +
                           //" AND (CAST(CAST(YEAR(IpdBillMaster.FinalDischargeOn) AS varchar(4)) + '/' + CAST(MONTH(IpdBillMaster.FinalDischargeOn) AS varchar(2)) " +
                           //" + '/' + CAST(DAY(IpdBillMaster.FinalDischargeOn) AS varchar(2)) AS datetime) BETWEEN '" + ViewState["FromDate"] + "'  and '" + ViewState["ToDate"] + "') "+
                          " AND YEAR( IpdBillMaster.FinalDischargeOn)="+ddlYear.SelectedValue+" " +

                           " GROUP BY BillGroup.GroupName, IpdBillServiceDetails.BillGroupId, IpdBillServiceDetails.FId, IpdBillServiceDetails.BranchId," + PatDB + ".dbo.SubDepartment.subdeptName ";


            SqlConnection con12 = DataAccess.ConInitForDC();
            SqlCommand cmd112 = con12.CreateCommand();
            cmd112.CommandText = query12 + ")";
            con12.Open();
            cmd112.ExecuteNonQuery();
            con12.Close(); con12.Dispose();



            //string query1 = "ALTER VIEW [dbo].[VW_LabWiseRevuenewwithservice] AS (SELECT    'OPD' as  CenterName, LabServiceDetails.Qty, LabServiceDetails.BillServiceCharges AS TotalCharges, LabServiceDetails.FId, LabServiceDetails.BranchId, BillGroup.GroupName, LabServiceDetails.ServiceName, " +
            //              "   isnull(" + PatDB + ".dbo.SubDepartment.subdeptName,'') as subdeptName, PatientInformation.FirstName, Gender.GenderName, PatientInformation.MobileNo, PatientInformation.PhoneNo, PatientInformation.PatientAddress, LabRegistration.ReferenceDoc, " +
            //               "  LabRegistration.ReferBy, LabRegistration.LabNo, LabRegistration.BillNo, LabRegistration.PatRegId, LabRegistration.Entrydate " +
            //               " FROM            PatientInformation INNER JOIN " +
            //               " LabServiceDetails INNER JOIN " +
            //               " BillGroup ON LabServiceDetails.BillGroup = BillGroup.BillGroupId INNER JOIN " +
            //               " LabRegistration ON LabServiceDetails.BillNo = LabRegistration.BillNo AND LabServiceDetails.LabNo = LabRegistration.LabNo AND LabServiceDetails.PatRegId = LabRegistration.PatRegId ON " +
            //               " PatientInformation.PatRegId = LabRegistration.PatRegId INNER JOIN " +
            //               " Gender ON PatientInformation.GenderId = Gender.GenderId LEFT OUTER JOIN " +
            //               " " + PatDB + ".dbo.SubDepartment LEFT OUTER JOIN " +
            //               " " + PatDB + ".dbo.MainTest ON " + PatDB + ".dbo.SubDepartment.SDCode = " + PatDB + ".dbo.MainTest.SDCode ON LabServiceDetails.MTCode = " + PatDB + ".dbo.MainTest.MTCode " +
            //               " WHERE      (LabRegistration.LabPtype = 'R') AND  (LabRegistration.CancelBill <> 1) AND (LabRegistration.BranchId = 1) AND (CAST(CAST(YEAR(LabRegistration.CreatedOn) AS varchar(4)) + '/' + CAST(MONTH(LabRegistration.CreatedOn) AS varchar(2)) " +
            //             " + '/' + CAST(DAY(LabRegistration.CreatedOn) AS varchar(2)) AS datetime) BETWEEN '" + ViewState["FromDate"] + "'  and '" + ViewState["ToDate"] + "') union all SELECT        'IPD' AS CenterName, IpdBillServiceDetails.Qty, IpdBillServiceDetails.TotalCharges, IpdBillServiceDetails.FId, IpdBillServiceDetails.BranchId, BillGroup.GroupName, " +
            //             "  IpdBillServiceDetails.ServiceName, " +
            //             "  isnull(" + PatDB + ".dbo.SubDepartment.subdeptName,'') as subdeptName,  PatientInformation.FirstName, Gender.GenderName, PatientInformation.MobileNo, PatientInformation.PhoneNo, PatientInformation.PatientAddress, " +
            //             "  IpdBillServiceDetails.MainDoctor,IpdBillServiceDetails.MainDoctor, " +
            //             "  IpdBillServiceDetails.LabNo,  " +
            //             "  IpdBillServiceDetails.BillNo, IpdBillServiceDetails.PatRegId,IpdBillServiceDetails.CreatedOn " +
            //            " FROM            BillGroup INNER JOIN " +
            //               " IpdBillMaster INNER JOIN " +
            //               " IpdBillServiceDetails INNER JOIN " +
            //               " PatientInformation ON IpdBillServiceDetails.PatRegId = PatientInformation.PatRegId ON IpdBillMaster.IpdNo = IpdBillServiceDetails.IpdNo AND IpdBillMaster.PatRegId = IpdBillServiceDetails.PatRegId ON " +
            //               " BillGroup.BillGroupId = IpdBillServiceDetails.BillGroupId LEFT OUTER JOIN " +
            //               " Gender ON PatientInformation.GenderId = Gender.GenderId LEFT OUTER JOIN " +
            //               " " + PatDB + ".dbo.SubDepartment LEFT OUTER JOIN " +
            //               " " + PatDB + ".dbo.MainTest ON " + PatDB + ".dbo.SubDepartment.SDCode = " + PatDB + ".dbo.MainTest.SDCode ON IpdBillServiceDetails.MTCode = " + PatDB + ".dbo.MainTest.MTCode " +
            //               " WHERE        (IpdBillServiceDetails.BillGroupId = 20) AND (IpdBillServiceDetails.IsDischarge <> 0) AND (IpdBillServiceDetails.BranchId = 1) AND (CAST(CAST(YEAR(IpdBillMaster.FinalDischargeOn) AS varchar(4)) " +
            //               " + '/' + CAST(MONTH(IpdBillMaster.FinalDischargeOn) AS varchar(2)) + '/' + CAST(DAY(IpdBillMaster.FinalDischargeOn) AS varchar(2)) AS datetime) BETWEEN '" + ViewState["FromDate"] + "'  and '" + ViewState["ToDate"] + "') ";
          
            //SqlConnection con1 = DataAccess.ConInitForDC();
            //SqlCommand cmd11 = con1.CreateCommand();
            //cmd11.CommandText = query1 + ")";
            //con1.Open();
            //cmd11.ExecuteNonQuery();
            //con1.Close(); con1.Dispose();
            
       // }
           
            DataTable dt = new DataTable();
            dt = ObjDOReport.FillGroupwiseIncomeGrid_LAB_Year(Convert.ToString(ddlYear.SelectedValue), Convert.ToString(""), BranchId, FId);

            ObjDOReport.VW_GetAllServiceIncome_Year(Convert.ToString(ddlYear.SelectedValue), Convert.ToString(""), BranchId, FId, GroupTyp.SelectedItem.Text);

        Session.Add("rptsql", "");
        Session["rptname"] = Server.MapPath("~/Reports/Rpt_AllServiceIncome_Year.rpt");
        Session["reportname"] = "Rpt_GetAllServiceIncome_Year";
        Session["RPTFORMAT"] = "PDF";//EXCEL

        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);
    }
    protected void brnAllPrintExcel_Click(object sender, EventArgs e)
    {
        BLLReports objreports = new BLLReports();
        int BranchId = Convert.ToInt32(Session["BranchId"]);
        int FId = Convert.ToInt32(Session["FId"]);



        // int BranchId = Convert.ToInt32(Session["BranchId"]);
        //int FId = Convert.ToInt32(Session["FId"]);

        //DALReports objDalReport = new DALReports();
        //DataSet dsCashSummary = new DataSet();
        ////ReportDocument crystalReport = new ReportDocument();
        //////crystalReport.Load(Server.MapPath("~/Reports/Rpt_DeptStoreWiseItems.rpt"));

        ////crystalReport.Load(Server.MapPath("~/Reports/Rpt_UserWiseDailyCashReport.rpt"));
        //dsCashSummary = objDalReport.GetUserWiseIncomeReport(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), Convert.ToInt32(ddldeptname.SelectedValue), ddlUser.SelectedValue, RdbPayment.SelectedValue, BranchId, FId, RdbPatientType.SelectedValue);
        ////crystalReport.SetDataSource(dsCashSummary);

        ////crystalReport.ExportToHttpResponse
        ////(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Employee");


        string sql = "";
        SqlConnection conrp = DataAccess.ConInitForPharmacy();
        SqlCommand cmd1 = conrp.CreateCommand();

        string query = "ALTER VIEW [dbo].[Vw_DailyCashReport] AS (SELECT dbo.PatientIssueVoucher.PatientType, dbo.PatientIssueVoucher.PatRegNo, dbo.PatientIssueVoucher.PatientName, dbo.PatientIssueVoucher.PatAddress,   " +
                       " CONVERT(varchar(10), dbo.PatientIssueVoucher.Age) + ' ' + dbo.PatientIssueVoucher.AgeType AS Age, dbo.PatientIssueVoucher.Allergies,   " +
                       " dbo.PatientIssueVoucher.DrName, dbo.PatientIssueVoucher.IssueVoucherNo, dbo.PatientIssueVoucher.IssueDate, dbo.PatientIssueVoucher.PaymentType,   " +
                       " dbo.PatientIssueVoucher.TotalAmt, CASE dbo.PatientIssueVoucher.PaymentType WHEN 0 THEN SUM(dbo.PatientIssueVoucher.AmountReceived) END AS Cash,   " +
                       " CASE dbo.PatientIssueVoucher.PaymentType WHEN 2 THEN SUM(dbo.PatientIssueVoucher.AmountReceived) END AS RCard,   " +
                       " CASE dbo.PatientIssueVoucher.PaymentType WHEN 1 THEN SUM(dbo.PatientIssueVoucher.AmountReceived) END AS Cheque,   " +
                       " CASE dbo.PatientIssueVoucher.PaymentType WHEN 4 THEN SUM(dbo.PatientIssueVoucher.AmountReceived) END AS ChargeToAccount,   " +
                       " CASE dbo.PatientIssueVoucher.IsInsurance WHEN 1 THEN SUM(dbo.PatientIssueVoucher.AmountReceived) END AS InsuranceCash,   " +
                       " CASE PatientIssueVoucher.DiscType WHEN 0 THEN PatientIssueVoucher.DiscAmt WHEN 1 THEN ((PatientIssueVoucher.GrandTotal * PatientIssueVoucher.DiscAmt)  " +
                       " / 100) END AS DiscAmt, dbo.PatientIssueVoucher.TotalTax, dbo.PatientIssueVoucher.GrandTotal, SUM(dbo.PatientIssueVoucher.AmountReceived)   " +
                       " AS AmountReceived, dbo.PatientIssueVoucher.Balance, dbo.PatientIssueVoucher.DiscRemark, dbo.PatientIssueVoucher.Note,   " +
                       " dbo.PatientIssueVoucher.CreatedBy, dbo.PatientIssueVoucher.DeptId, dbo.PatientIssueVoucher.ChequeNo, dbo.PatientIssueVoucher.BankName,   " +
                       " dbo.PatientIssueVoucher.InsuranceComp, dbo.PatientIssueVoucher.InsuranceAmount, dbo.PatientIssueVoucher.StaffName,   " +
                       " dbo.PatientIssueVoucher.StaffRemark, dbo.PatientIssueVoucher.CardName, dbo.PatientIssueVoucher.FId, dbo.PatientIssueVoucher.BranchId,   " +
                       " dbo.PatientIssueVoucher.CreatedOn, dbo.tbl_Dept.DeptName, dbo.PatientIssueVoucher.IsInsurance, dbo.PatientIssueVoucher.FinalSettledBy,   " +
                       " dbo.PatientIssueVoucher.FinalSettledFlag, dbo.PatientIssueVoucher.IsPrescription, dbo.PatientIssueVoucher.IsApprovedPrescription,PatientIssueVoucher.fullcancelvoucher  " +
                       " FROM    dbo.PatientIssueVoucher INNER JOIN  " +
                       " dbo.tbl_Dept ON dbo.PatientIssueVoucher.DeptId = dbo.tbl_Dept.DeptId  " +
                           " Where 1=1";
        query += " and ((dbo.PatientIssueVoucher.FullCancelVoucher <> 1) AND (dbo.PatientIssueVoucher.IsPrescription = 1) AND   " +
                       " (dbo.PatientIssueVoucher.IsApprovedPrescription = 1) OR  " +
                       " (dbo.PatientIssueVoucher.FullCancelVoucher <> 1) AND (dbo.PatientIssueVoucher.IsPrescription IS NULL) AND   " +
                       " (dbo.PatientIssueVoucher.IsApprovedPrescription IS NULL))  " +
                         "  and Year( PatientIssueVoucher.CreatedOn)=" + ddlYear.SelectedValue + " ";// 
        //  "  and (CAST(CAST(YEAR(PatientIssueVoucher.CreatedOn) AS varchar(4)) + '/' + CAST(MONTH(PatientIssueVoucher.CreatedOn) AS varchar(2)) + '/' + CAST(DAY(PatientIssueVoucher.CreatedOn) AS varchar(2)) AS datetime))  between ('" + Convert.ToDateTime(txtFrom.Text).ToString("MM/dd/yyyy") + "') and ('" + Convert.ToDateTime(txtTo.Text).ToString("MM/dd/yyyy") + "')";// 



        query += " GROUP BY dbo.PatientIssueVoucher.PatientType, dbo.PatientIssueVoucher.PatRegNo, dbo.PatientIssueVoucher.PatientName, dbo.PatientIssueVoucher.PatAddress,   " +
                       " dbo.PatientIssueVoucher.Age, dbo.PatientIssueVoucher.AgeType, dbo.PatientIssueVoucher.Allergies, dbo.PatientIssueVoucher.DrName,   " +
                       " dbo.PatientIssueVoucher.IssueVoucherNo, dbo.PatientIssueVoucher.IssueDate, dbo.PatientIssueVoucher.PaymentType, dbo.PatientIssueVoucher.TotalAmt,   " +
                       " dbo.PatientIssueVoucher.DiscAmt, dbo.PatientIssueVoucher.TotalTax, dbo.PatientIssueVoucher.DiscType, dbo.PatientIssueVoucher.GrandTotal,   " +
                       " dbo.PatientIssueVoucher.Balance, dbo.PatientIssueVoucher.DiscRemark, dbo.PatientIssueVoucher.Note, dbo.PatientIssueVoucher.CreatedBy,   " +
                       " dbo.PatientIssueVoucher.DeptId, dbo.PatientIssueVoucher.ChequeNo, dbo.PatientIssueVoucher.BankName, dbo.PatientIssueVoucher.InsuranceComp, " +
                       " dbo.PatientIssueVoucher.InsuranceAmount, dbo.PatientIssueVoucher.StaffName, dbo.PatientIssueVoucher.StaffRemark, dbo.PatientIssueVoucher.CardName,   " +
                       " dbo.PatientIssueVoucher.FId, dbo.PatientIssueVoucher.BranchId, dbo.PatientIssueVoucher.CreatedOn, dbo.tbl_Dept.DeptName,   " +
                       " dbo.PatientIssueVoucher.IsInsurance, dbo.PatientIssueVoucher.FinalSettledBy, dbo.PatientIssueVoucher.FinalSettledFlag,   " +
                       " dbo.PatientIssueVoucher.IsPrescription, dbo.PatientIssueVoucher.IsApprovedPrescription, PatientIssueVoucher.fullcancelvoucher  ";

        cmd1.CommandText = query + ")";

        conrp.Open();
        cmd1.ExecuteNonQuery();
        conrp.Close(); conrp.Dispose();





        //if (BillGroup == "Radiology")
        //{
        SqlConnection con1H = DataAccess.ConInitForRadiology();
        // con1H.Open();
        string PatDB = con1H.Database;
        string query12 = "ALTER VIEW [dbo].[VW_LabWiseRevuenew_Year] AS (SELECT   'OPD' as  CenterName,  count( LabRegistration.PatRegId) as NoOfPatient,  sum( LabServiceDetails.Qty) as Qty ,sum( LabServiceDetails.BillServiceCharges) AS TotalCharges, LabServiceDetails.FId, LabServiceDetails.BranchId, " +
            " BillGroup.GroupName, " +
            " " + PatDB + ".dbo.SubDepartment.subdeptName " +
            " , SUM(LabBillPaymentTrns.ReceivedAmount) AS RecAmt, SUM(LabBillPaymentTrns.DiscountAmt) AS Discount, SUM(LabBillPaymentTrns.InsuranceAmount) AS InsuAmt " +
            //" FROM            LabServiceDetails INNER JOIN " +
            //" BillGroup ON LabServiceDetails.BillGroup = BillGroup.BillGroupId INNER JOIN " +
            //" LabRegistration ON LabServiceDetails.BillNo = LabRegistration.BillNo AND LabServiceDetails.LabNo = LabRegistration.LabNo AND LabServiceDetails.PatRegId = LabRegistration.PatRegId INNER JOIN " +
            //" " + PatDB + ".dbo.MainTest ON LabServiceDetails.MTCode = " + PatDB + ".dbo.MainTest.MTCode INNER JOIN " +
            //" " + PatDB + ".dbo.SubDepartment ON " + PatDB + ".dbo.MainTest.SDCode = " + PatDB + ".dbo.SubDepartment.SDCode " +
                 " FROM  LabServiceDetails INNER JOIN BillGroup ON LabServiceDetails.BillGroup = BillGroup.BillGroupId INNER JOIN " +
               "  LabRegistration ON LabServiceDetails.BillNo = LabRegistration.BillNo AND LabServiceDetails.LabNo = LabRegistration.LabNo AND LabServiceDetails.PatRegId = LabRegistration.PatRegId INNER JOIN " +
               "  " + PatDB + ".dbo.MainTest ON LabServiceDetails.MTCode = " + PatDB + ".dbo.MainTest.MTCode INNER JOIN " +
               "  " + PatDB + ".dbo.SubDepartment ON " + PatDB + ".dbo.MainTest.SDCode = " + PatDB + ".dbo.SubDepartment.SDCode INNER JOIN " +
               "  LabBillPaymentTrns ON LabRegistration.PatRegId = LabBillPaymentTrns.PatRegId AND LabRegistration.LabNo = LabBillPaymentTrns.LabNo " +

            " WHERE        (LabRegistration.CancelBill <> 1) AND (LabRegistration.BranchId = 1) AND  YEAR( LabRegistration.CreatedOn)=" + ddlYear.SelectedValue + " " +
            //" (CAST(CAST(YEAR(LabRegistration.CreatedOn) AS varchar(4)) + '/' + CAST(MONTH(LabRegistration.CreatedOn) AS varchar(2)) " +
            //" + '/' + CAST(DAY(LabRegistration.CreatedOn) AS varchar(2)) AS datetime) BETWEEN '" + ViewState["FromDate"] + "'  and '" + ViewState["ToDate"] + "') " +
            " group by LabServiceDetails.FId,  LabServiceDetails.BranchId, BillGroup.GroupName," + PatDB + ".dbo.SubDepartment.subdeptName union all " +//and YEAR(patmstd.Patregdate)=" + ddlYear.SelectedValue + " and Month(patmstd.Patregdate)=" + DdlMonth.SelectedValue + " ";
            " SELECT 'IPD' as  CenterName,  count( IpdBillMaster.PatRegId) as NoOfPatient, sum( IpdBillServiceDetails.Qty) as Qty, " +
            " SUM(IpdBillServiceDetails.TotalCharges) AS TotalCharges,IpdBillServiceDetails.FId, IpdBillServiceDetails.BranchId,  BillGroup.GroupName, " +
            " isnull(" + PatDB + ".dbo.SubDepartment.subdeptName,'') as subdeptName, SUM(IpdBillMaster.AmountReceived) AS RecAmt, SUM(IpdBillMaster.Discount)as Discount , SUM(IpdBillMaster.InsuranceAmt) AS InsuAmt  FROM            IpdBillServiceDetails LEFT OUTER JOIN " +
            " " + PatDB + ".dbo.MainTest ON IpdBillServiceDetails.MTCode = " + PatDB + ".dbo.MainTest.MTCode LEFT OUTER JOIN" +
            " " + PatDB + ".dbo.SubDepartment ON " + PatDB + ".dbo.MainTest.SDCode = " + PatDB + ".dbo.SubDepartment.SDCode LEFT OUTER JOIN " +
            " IpdBillMaster ON IpdBillServiceDetails.PatRegId = IpdBillMaster.PatRegId AND IpdBillServiceDetails.IpdNo = IpdBillMaster.IpdNo LEFT OUTER JOIN " +
            " BillGroup ON IpdBillServiceDetails.BillGroupId = BillGroup.BillGroupId where IpdBillMaster.IsDischarge=1  and  " +
            " IpdBillServiceDetails.FId=1 and IpdBillServiceDetails.BranchId=1 and IpdBillServiceDetails.BillGroupId =20 " +
            //" AND (CAST(CAST(YEAR(IpdBillMaster.FinalDischargeOn) AS varchar(4)) + '/' + CAST(MONTH(IpdBillMaster.FinalDischargeOn) AS varchar(2)) " +
            //" + '/' + CAST(DAY(IpdBillMaster.FinalDischargeOn) AS varchar(2)) AS datetime) BETWEEN '" + ViewState["FromDate"] + "'  and '" + ViewState["ToDate"] + "') "+
           " AND YEAR( IpdBillMaster.FinalDischargeOn)=" + ddlYear.SelectedValue + " " +

            " GROUP BY BillGroup.GroupName, IpdBillServiceDetails.BillGroupId, IpdBillServiceDetails.FId, IpdBillServiceDetails.BranchId," + PatDB + ".dbo.SubDepartment.subdeptName ";


        SqlConnection con12 = DataAccess.ConInitForDC();
        SqlCommand cmd112 = con12.CreateCommand();
        cmd112.CommandText = query12 + ")";
        con12.Open();
        cmd112.ExecuteNonQuery();
        con12.Close(); con12.Dispose();



        //string query1 = "ALTER VIEW [dbo].[VW_LabWiseRevuenewwithservice] AS (SELECT    'OPD' as  CenterName, LabServiceDetails.Qty, LabServiceDetails.BillServiceCharges AS TotalCharges, LabServiceDetails.FId, LabServiceDetails.BranchId, BillGroup.GroupName, LabServiceDetails.ServiceName, " +
        //              "   isnull(" + PatDB + ".dbo.SubDepartment.subdeptName,'') as subdeptName, PatientInformation.FirstName, Gender.GenderName, PatientInformation.MobileNo, PatientInformation.PhoneNo, PatientInformation.PatientAddress, LabRegistration.ReferenceDoc, " +
        //               "  LabRegistration.ReferBy, LabRegistration.LabNo, LabRegistration.BillNo, LabRegistration.PatRegId, LabRegistration.Entrydate " +
        //               " FROM            PatientInformation INNER JOIN " +
        //               " LabServiceDetails INNER JOIN " +
        //               " BillGroup ON LabServiceDetails.BillGroup = BillGroup.BillGroupId INNER JOIN " +
        //               " LabRegistration ON LabServiceDetails.BillNo = LabRegistration.BillNo AND LabServiceDetails.LabNo = LabRegistration.LabNo AND LabServiceDetails.PatRegId = LabRegistration.PatRegId ON " +
        //               " PatientInformation.PatRegId = LabRegistration.PatRegId INNER JOIN " +
        //               " Gender ON PatientInformation.GenderId = Gender.GenderId LEFT OUTER JOIN " +
        //               " " + PatDB + ".dbo.SubDepartment LEFT OUTER JOIN " +
        //               " " + PatDB + ".dbo.MainTest ON " + PatDB + ".dbo.SubDepartment.SDCode = " + PatDB + ".dbo.MainTest.SDCode ON LabServiceDetails.MTCode = " + PatDB + ".dbo.MainTest.MTCode " +
        //               " WHERE      (LabRegistration.LabPtype = 'R') AND  (LabRegistration.CancelBill <> 1) AND (LabRegistration.BranchId = 1) AND (CAST(CAST(YEAR(LabRegistration.CreatedOn) AS varchar(4)) + '/' + CAST(MONTH(LabRegistration.CreatedOn) AS varchar(2)) " +
        //             " + '/' + CAST(DAY(LabRegistration.CreatedOn) AS varchar(2)) AS datetime) BETWEEN '" + ViewState["FromDate"] + "'  and '" + ViewState["ToDate"] + "') union all SELECT        'IPD' AS CenterName, IpdBillServiceDetails.Qty, IpdBillServiceDetails.TotalCharges, IpdBillServiceDetails.FId, IpdBillServiceDetails.BranchId, BillGroup.GroupName, " +
        //             "  IpdBillServiceDetails.ServiceName, " +
        //             "  isnull(" + PatDB + ".dbo.SubDepartment.subdeptName,'') as subdeptName,  PatientInformation.FirstName, Gender.GenderName, PatientInformation.MobileNo, PatientInformation.PhoneNo, PatientInformation.PatientAddress, " +
        //             "  IpdBillServiceDetails.MainDoctor,IpdBillServiceDetails.MainDoctor, " +
        //             "  IpdBillServiceDetails.LabNo,  " +
        //             "  IpdBillServiceDetails.BillNo, IpdBillServiceDetails.PatRegId,IpdBillServiceDetails.CreatedOn " +
        //            " FROM            BillGroup INNER JOIN " +
        //               " IpdBillMaster INNER JOIN " +
        //               " IpdBillServiceDetails INNER JOIN " +
        //               " PatientInformation ON IpdBillServiceDetails.PatRegId = PatientInformation.PatRegId ON IpdBillMaster.IpdNo = IpdBillServiceDetails.IpdNo AND IpdBillMaster.PatRegId = IpdBillServiceDetails.PatRegId ON " +
        //               " BillGroup.BillGroupId = IpdBillServiceDetails.BillGroupId LEFT OUTER JOIN " +
        //               " Gender ON PatientInformation.GenderId = Gender.GenderId LEFT OUTER JOIN " +
        //               " " + PatDB + ".dbo.SubDepartment LEFT OUTER JOIN " +
        //               " " + PatDB + ".dbo.MainTest ON " + PatDB + ".dbo.SubDepartment.SDCode = " + PatDB + ".dbo.MainTest.SDCode ON IpdBillServiceDetails.MTCode = " + PatDB + ".dbo.MainTest.MTCode " +
        //               " WHERE        (IpdBillServiceDetails.BillGroupId = 20) AND (IpdBillServiceDetails.IsDischarge <> 0) AND (IpdBillServiceDetails.BranchId = 1) AND (CAST(CAST(YEAR(IpdBillMaster.FinalDischargeOn) AS varchar(4)) " +
        //               " + '/' + CAST(MONTH(IpdBillMaster.FinalDischargeOn) AS varchar(2)) + '/' + CAST(DAY(IpdBillMaster.FinalDischargeOn) AS varchar(2)) AS datetime) BETWEEN '" + ViewState["FromDate"] + "'  and '" + ViewState["ToDate"] + "') ";

        //SqlConnection con1 = DataAccess.ConInitForDC();
        //SqlCommand cmd11 = con1.CreateCommand();
        //cmd11.CommandText = query1 + ")";
        //con1.Open();
        //cmd11.ExecuteNonQuery();
        //con1.Close(); con1.Dispose();

        // }

        DataTable dt = new DataTable();
        dt = ObjDOReport.FillGroupwiseIncomeGrid_LAB_Year(Convert.ToString(ddlYear.SelectedValue), Convert.ToString(""), BranchId, FId);

        ObjDOReport.VW_GetAllServiceIncome_Year(Convert.ToString(ddlYear.SelectedValue), Convert.ToString(""), BranchId, FId, GroupTyp.SelectedItem.Text);

        Session.Add("rptsql", "");
        Session["rptname"] = Server.MapPath("~/Reports/Rpt_AllServiceIncome_Year.rpt");
        Session["reportname"] = "Rpt_GetAllServiceIncome_Year";
        Session["RPTFORMAT"] = "EXCEL";//EXCEL

        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);
    }
}