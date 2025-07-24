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

public partial class SettleInsurance :BasePage
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
            txtFrom.Value = DateTime.Now.ToString("dd/MM/yyyy");
            txtTo.Value = DateTime.Now.ToString("dd/MM/yyyy");
            RdbStatus.SelectedValue = "2";
            ViewState["PatRegId"] = "0";
            //FillUsers();
            FillGrid();

        }
        this.RegisterPostBackControl();

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
        return objDALOpdReg.FillAllPatient(prefixText);
    }
    protected void ddlUser_SelectedIndexChanged(object sender, EventArgs e)
    {

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
        }
        else
        {
            ViewState["FromDate"] = "";
        }
        if (txtTo.Value.ToString() != "")
        {

            ViewState["ToDate"] = txtTo.Value.ToString();
        }
        else
        {
            ViewState["ToDate"] = "";
        }
        int BranchId = Convert.ToInt32(Session["BranchId"]);
        int FId = Convert.ToInt32(Session["FId"]);


        gvDailyCash.DataSource = ObjDOReport.FillOpdBillOutstanding_Insurance(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), Convert.ToInt32(ViewState["PatRegId"]), txtMobileNo.Text.Trim(), RdbStatus.SelectedValue, BranchId, FId); //Convert.ToInt32(ddlUser.SelectedValue));
        gvDailyCash.DataBind();
    }
    private void Reset()
    {

    }

    //protected void Print_Click(object sender, EventArgs e)
    //{
    //    try
    //    {

    //        if (txtFrom.Value.ToString() != "")
    //        {
    //            ViewState["FromDate"] = txtFrom.Value.ToString();                
    //        }
    //        else
    //        {
    //            ViewState["FromDate"] = "";
    //        }
    //        if (txtTo.Value.ToString() != "")
    //        {
    //            ViewState["ToDate"] = txtTo.Value.ToString(); 
    //        }
    //        else
    //        {
    //            ViewState["ToDate"] = "";
    //        }
    //        int BranchId = Convert.ToInt32(Session["BranchId"]);
    //        int FId = Convert.ToInt32(Session["FId"]);

    //        // DALReports objDalReport = new DALReports();
    //        DataSet dsCashSummary = new DataSet();
    //        ReportDocument crystalReport = new ReportDocument();
    //        //crystalReport.Load(Server.MapPath("~/Reports/Rpt_DeptStoreWiseItems.rpt"));

    //        crystalReport.Load(Server.MapPath("~/Report/Rpt_UserWiseDailyCashReport.rpt"));
    //        dsCashSummary = ObjDOReport.FillUserWiseCashSummary(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), Convert.ToInt32(ViewState["PatRegId"]), ddlUser.SelectedValue, RdbPayment.SelectedValue, BranchId, FId);
    //        crystalReport.SetDataSource(dsCashSummary);
    //        crystalReport.ParameterFields["FromDate"].CurrentValues.AddValue(Convert.ToString(ViewState["FromDate"]));
    //        crystalReport.ParameterFields["ToDate"].CurrentValues.AddValue(Convert.ToString(ViewState["ToDate"]));

    //        //crystalReport.ParameterFields["HospitalName"].CurrentValues.AddValue(Convert.ToString(Application["OrgnizationName"]));
    //        //crystalReport.ParameterFields["HospitalAddress"].CurrentValues.AddValue(Convert.ToString(Application["OrgnizationAddress"]));
    //        ////crystalReport.ParameterFields["Image"].CurrentValues.AddValue(Application["ImagePath"]);
    //        //crystalReport.ParameterFields["ReportFooter"].CurrentValues.AddValue("Hospital Software | Ph.020 123456789");
    //        crystalReport.ExportToHttpResponse
    //        (CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Employee");
    //    }
    //    catch (Exception ex)
    //    {
    //        lblMessage.Text = ex.Message;
    //    }
    //}
    protected void btnReset_Click(object sender, EventArgs e)
    {

    }
    protected void gvDailyCash_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDailyCash.PageIndex = e.NewPageIndex;
        FillGrid();
    }
    protected void gvDailyCash_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex != -1)
        {
            float balance;
            if (e.Row.Cells[11].Text == "&nbsp;")
            {
                balance = 0;
            }
            else
            {
                balance = Convert.ToSingle(e.Row.Cells[11].Text);
            }
            if (balance > 0)
            {
                e.Row.Cells[03].Text = "<span class='btn btn-xs btn-danger' >Pending</span>";
            }
            else
            {
                e.Row.Cells[0].Enabled = false;
                e.Row.Cells[03].Text = "<span class='btn btn-xs btn-success' >Done</span>";
            }
            Button btnPrint = (e.Row.FindControl("btnPrint") as Button);
            Button btnPay = (e.Row.FindControl("btnPay") as Button);



            int PatRegId = Convert.ToInt32(gvDailyCash.DataKeys[e.Row.RowIndex]["PatRegId"].ToString());
            int FID = Convert.ToInt32((e.Row.FindControl("HdnFId") as HiddenField).Value);
            int BranchId = Convert.ToInt32((e.Row.FindControl("HdnBranchId") as HiddenField).Value);
            int OpdNo = Convert.ToInt32((e.Row.FindControl("HdnOpdNo") as HiddenField).Value);
            int BillNo = Convert.ToInt32((e.Row.FindControl("HdnBillNo") as HiddenField).Value);

            DropDownList ddl_Receipt = e.Row.FindControl("ddlReceipt") as DropDownList;

            DataTable dt = new DataTable();
            dt = ObjDOReport.GetReceiptNo(PatRegId, OpdNo, BillNo, FID, BranchId);
            if (dt.Rows.Count > 0)
            {
                ddl_Receipt.DataSource = dt;
                ddl_Receipt.DataTextField = "ReceiptNo";
                ddl_Receipt.DataValueField = "ReceiptNo";
                ddl_Receipt.DataBind();
                ddl_Receipt.Items.Insert(0, "-Receipt-");
                ddl_Receipt.SelectedIndex = 0;
            }

        }

        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    total += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "AmountReceived"));


        //}
        //if (e.Row.RowType == DataControlRowType.Footer)
        //{
        //    e.Row.Cells[7].Text = "Total";
        //    e.Row.Cells[7].Font.Bold = true;
        //    e.Row.Cells[8].Text = total.ToString();
        //    e.Row.Cells[8].Font.Bold = true;

        //}

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
        Response.Redirect("OpdPaybillOutstanding.aspx?Type=SettleInsurance&PatRegId=" + PatRegId + "&FID=" + FID + "&BillNo=" + BillNo + "&OpdNo=" + OpdNo, false);

    }
    private void RegisterPostBackControl()
    {
        foreach (GridViewRow row in gvDailyCash.Rows)
        {
            DropDownList ddl_Receipt = row.FindControl("ddlReceipt") as DropDownList;
            Button btnPrint = row.FindControl("btnPrint") as Button;
            ScriptManager.GetCurrent(this).RegisterPostBackControl(ddl_Receipt);
            ScriptManager.GetCurrent(this).RegisterPostBackControl(btnPrint);

        }
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {

        ViewState["Report"] = "True";
        Button Btnprint = (Button)sender;
        GridViewRow row = (GridViewRow)Btnprint.NamingContainer;

        this.RegisterPostBackControl();

        DropDownList ddl_Receipt = gvDailyCash.Rows[row.RowIndex].FindControl("ddlReceipt") as DropDownList;
        HiddenField HdnOpdNo = gvDailyCash.Rows[row.RowIndex].FindControl("HdnOpdNo") as HiddenField;
        HiddenField HdnBillNo = gvDailyCash.Rows[row.RowIndex].FindControl("HdnBillNo") as HiddenField;
        HiddenField HdnFId = gvDailyCash.Rows[row.RowIndex].FindControl("HdnFId") as HiddenField;
        int PatRegId = Convert.ToInt32(gvDailyCash.DataKeys[row.RowIndex]["PatRegId"]);

        string sql = "";
        SqlConnection conrp = DataAccess.ConInitForDC();
        SqlCommand cmd1 = conrp.CreateCommand();


        //string query = "ALTER VIEW [dbo].[Vw_OpdFinalBillReport] AS (SELECT dbo.Vw_OPDOutstanding.BillNo, dbo.Vw_OPDOutstanding.PatientName, dbo.Vw_OPDOutstanding.BillServiceCharges, dbo.Vw_OPDOutstanding.Entrydate, " +
        //         " dbo.Vw_OPDOutstanding.OpdNo, dbo.Vw_OPDOutstanding.PatRegId, SUM(dbo.BillPaymentTrns.ReceivedAmount) AS ReceivedAmount, " +
        //         " SUM(dbo.BillPaymentTrns.DiscountAmt) AS DiscountAmt, dbo.Vw_OPDOutstanding.BillServiceCharges - (SUM(dbo.BillPaymentTrns.DiscountAmt) + SUM(dbo.BillPaymentTrns.ReceivedAmount)) AS BalanceAmt, dbo.Vw_OPDOutstanding.MobileNo, dbo.Vw_OPDOutstanding.FId, " +
        //         " dbo.Vw_OPDOutstanding.BranchId, dbo.Vw_OPDOutstanding.Age, dbo.Vw_OPDOutstanding.AgeType, dbo.Vw_OPDOutstanding.GenderName, " +
        //         " dbo.Vw_OPDOutstanding.Empname, dbo.Vw_OPDOutstanding.PatientInsuType, dbo.Vw_OPDOutstanding.PatMainType, dbo.Vw_OPDOutstanding.BloodGroup, " +
        //         " dbo.Vw_OPDOutstanding.BirthDate FROM  dbo.Vw_OPDOutstanding INNER JOIN  dbo.BillPaymentTrns ON dbo.Vw_OPDOutstanding.BillNo = dbo.BillPaymentTrns.BillNo AND " +
        //         " dbo.Vw_OPDOutstanding.PatRegId = dbo.BillPaymentTrns.PatRegId AND dbo.Vw_OPDOutstanding.OpdNo = dbo.BillPaymentTrns.OpdNo " +
        //         " where Vw_OPDOutstanding.BillNo=" + Convert.ToInt32(HdnBillNo.Value) + "  and Vw_OPDOutstanding.OpdNo=" + Convert.ToInt32(HdnOpdNo.Value) + " and dbo.Vw_OPDOutstanding.PatRegId=" + Convert.ToInt32(PatRegId) + " and dbo.BillPaymentTrns.FId=" + Convert.ToInt32(HdnFId.Value) + " and dbo.BillPaymentTrns.BranchId=" + Convert.ToInt32(Session["BranchId"]) + " " +
        //         " GROUP BY dbo.Vw_OPDOutstanding.BillNo, dbo.Vw_OPDOutstanding.PatientName, dbo.Vw_OPDOutstanding.BillServiceCharges, dbo.Vw_OPDOutstanding.Entrydate, " +
        //         " dbo.Vw_OPDOutstanding.OpdNo, dbo.Vw_OPDOutstanding.PatRegId, dbo.Vw_OPDOutstanding.MobileNo, dbo.Vw_OPDOutstanding.FId, " +
        //         " dbo.Vw_OPDOutstanding.BranchId, dbo.Vw_OPDOutstanding.Age, dbo.Vw_OPDOutstanding.AgeType, dbo.Vw_OPDOutstanding.GenderName, " +
        //         " dbo.Vw_OPDOutstanding.Empname, dbo.Vw_OPDOutstanding.PatientInsuType, dbo.Vw_OPDOutstanding.PatMainType, dbo.Vw_OPDOutstanding.BloodGroup,dbo.Vw_OPDOutstanding.BirthDate ";


        string query = "ALTER VIEW [dbo].[Vw_OpdFinalBillReport] AS (SELECT dbo.Vw_OPDOutstanding.BillNo, dbo.Vw_OPDOutstanding.PatientName, dbo.Vw_OPDOutstanding.BillServiceCharges, dbo.Vw_OPDOutstanding.Entrydate, " +
                " dbo.Vw_OPDOutstanding.OpdNo, dbo.Vw_OPDOutstanding.PatRegId, SUM(dbo.BillPaymentTrns.ReceivedAmount) AS ReceivedAmount, " +
                " SUM(dbo.BillPaymentTrns.DiscountAmt) AS DiscountAmt, dbo.Vw_OPDOutstanding.BillServiceCharges - (SUM(dbo.BillPaymentTrns.DiscountAmt) " +
                " + SUM(dbo.BillPaymentTrns.ReceivedAmount)) AS BalanceAmt, dbo.Vw_OPDOutstanding.MobileNo, dbo.Vw_OPDOutstanding.FId, " +
                " dbo.Vw_OPDOutstanding.BranchId, dbo.Vw_OPDOutstanding.Age, dbo.Vw_OPDOutstanding.AgeType, dbo.Vw_OPDOutstanding.GenderName, " +
                " dbo.Vw_OPDOutstanding.Empname, dbo.Vw_OPDOutstanding.PatientInsuType, dbo.Vw_OPDOutstanding.PatMainType, dbo.Vw_OPDOutstanding.BloodGroup, " +
                " dbo.Vw_OPDOutstanding.BirthDate, dbo.OpdIpdBillServiceDetails.Qty, dbo.OpdIpdBillServiceDetails.SingleBillServiceCharges, dbo.BillService.ServiceName," +
                " dbo.OpdIpdBillServiceDetails.BillServiceId, dbo.OpdIpdBillServiceDetails.BillServiceCharges AS TotalCharges " +
                " FROM    dbo.Vw_OPDOutstanding INNER JOIN dbo.BillPaymentTrns ON dbo.Vw_OPDOutstanding.BillNo = dbo.BillPaymentTrns.BillNo AND " +
                " dbo.Vw_OPDOutstanding.PatRegId = dbo.BillPaymentTrns.PatRegId AND dbo.Vw_OPDOutstanding.OpdNo = dbo.BillPaymentTrns.OpdNo INNER JOIN " +
                " dbo.OpdIpdBillServiceDetails ON dbo.Vw_OPDOutstanding.PatRegId = dbo.OpdIpdBillServiceDetails.PatRegId AND " +
                " dbo.Vw_OPDOutstanding.OpdNo = dbo.OpdIpdBillServiceDetails.OpdNo AND dbo.Vw_OPDOutstanding.BillNo = dbo.OpdIpdBillServiceDetails.BillNo INNER JOIN " +
                " dbo.BillService ON dbo.OpdIpdBillServiceDetails.BillServiceId = dbo.BillService.BillServiceId " +
                " where Vw_OPDOutstanding.BillNo=" + Convert.ToInt32(HdnBillNo.Value) + "  and Vw_OPDOutstanding.OpdNo=" + Convert.ToInt32(HdnOpdNo.Value) + " and " +
                " dbo.Vw_OPDOutstanding.PatRegId=" + Convert.ToInt32(PatRegId) + " and dbo.BillPaymentTrns.FId=" + Convert.ToInt32(HdnFId.Value) + " and dbo.BillPaymentTrns.BranchId=" + Convert.ToInt32(Session["BranchId"]) + " " +
                "  GROUP BY dbo.Vw_OPDOutstanding.BillNo, dbo.Vw_OPDOutstanding.PatientName, dbo.Vw_OPDOutstanding.BillServiceCharges, dbo.Vw_OPDOutstanding.Entrydate, " +
                " dbo.Vw_OPDOutstanding.OpdNo, dbo.Vw_OPDOutstanding.PatRegId, dbo.Vw_OPDOutstanding.MobileNo, dbo.Vw_OPDOutstanding.FId, " +
                " dbo.Vw_OPDOutstanding.BranchId, dbo.Vw_OPDOutstanding.Age, dbo.Vw_OPDOutstanding.AgeType, dbo.Vw_OPDOutstanding.GenderName," +
                " dbo.Vw_OPDOutstanding.Empname, dbo.Vw_OPDOutstanding.PatientInsuType, dbo.Vw_OPDOutstanding.PatMainType, dbo.Vw_OPDOutstanding.BloodGroup, " +
                " dbo.Vw_OPDOutstanding.BirthDate, dbo.OpdIpdBillServiceDetails.Qty, dbo.OpdIpdBillServiceDetails.SingleBillServiceCharges, dbo.BillService.ServiceName," +
                " dbo.OpdIpdBillServiceDetails.BillServiceId, dbo.OpdIpdBillServiceDetails.BillServiceCharges ";

        cmd1.CommandText = query + ")";

        conrp.Open();
        cmd1.ExecuteNonQuery();
        conrp.Close(); conrp.Dispose();
        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Reports/Rpt_OPDFinalBillPrint.rpt");
        Session["reportname"] = "OPDFinalBillPrint";
        Session["RPTFORMAT"] = "pdf";

        // ReportParameterClass.SelectionFormula = sql;
        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);





    }
    protected void ddlReceipt_SelectedIndexChanged(object sender, EventArgs e)
    {
        int RowIndex1 = ((GridViewRow)((DropDownList)sender).NamingContainer).RowIndex;


        this.RegisterPostBackControl();
        DropDownList ddl_Receipt = gvDailyCash.Rows[RowIndex1].FindControl("ddlReceipt") as DropDownList;
        HiddenField HdnOpdNo = gvDailyCash.Rows[RowIndex1].FindControl("HdnOpdNo") as HiddenField;
        HiddenField HdnBillNo = gvDailyCash.Rows[RowIndex1].FindControl("HdnBillNo") as HiddenField;
        HiddenField HdnFId = gvDailyCash.Rows[RowIndex1].FindControl("HdnFId") as HiddenField;
        int PatRegId = Convert.ToInt32(gvDailyCash.DataKeys[RowIndex1]["PatRegId"]);
        //BLLReports objBLLReports = new BLLReports();
        //DataSet dsCustomers = new DataSet();
        //ReportDocument crystalReport = new ReportDocument();
        //crystalReport.Load(Server.MapPath("~/Report/Rpt_OPDBilling.rpt"));
        //dsCustomers = objBLLReports.GetOPDBillDetails(Convert.ToInt32(HdnBillNo.Value), Convert.ToInt32(ddl_Receipt.SelectedValue), Convert.ToInt32(HdnOpdNo.Value), Convert.ToInt32(PatRegId), Convert.ToInt32(HdnFId.Value), Convert.ToInt32(Session["BranchId"]));
        //crystalReport.SetDataSource(dsCustomers);
        ////crystalReport.ParameterFields["HospitalName"].CurrentValues.AddValue(Convert.ToString(Application["OrgnizationName"]));
        ////crystalReport.ParameterFields["HospitalAddress"].CurrentValues.AddValue(Convert.ToString(Application["OrgnizationAddress"]));
        ////crystalReport.ParameterFields["Image"].CurrentValues.AddValue(Application["ImagePath"]);
        //// crystalReport.ParameterFields["ReportFooter"].CurrentValues.AddValue("Hospital Software | Ph.020 0000000000");
        //crystalReport.ExportToHttpResponse
        //(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Employee");

        if (ddl_Receipt.SelectedValue != "-Receipt-")
        {
            string sql = "";
            SqlConnection conrp = DataAccess.ConInitForDC();
            SqlCommand cmd1 = conrp.CreateCommand();


            string query = "ALTER VIEW [dbo].[Vw_OpdBillReport] AS (SELECT dbo.Vw_OPDBillServiceDetails.BillNo, dbo.BillPaymentTrns.ReceiptNo, dbo.Vw_OPDBillServiceDetails.FirstName AS PatientName, " +
                    " dbo.Vw_OPDBillServiceDetails.PatRegId, dbo.Vw_OPDBillServiceDetails.OpdNo, dbo.Vw_OPDBillServiceDetails.ServiceName, " +
                    " dbo.BillPaymentTrns.ReceivedAmount, dbo.BillPaymentTrns.DiscountAmt, dbo.BillPaymentTrns.BalanceAmt, dbo.BillPaymentTrns.BankName," +
                    " dbo.BillPaymentTrns.ChequeDate, dbo.BillPaymentTrns.ChequeNo, dbo.BillPaymentTrns.PaymentMode, dbo.Vw_OPDBillServiceDetails.BillServiceCharges," +
                    " dbo.BillPaymentTrns.PaymentDate, dbo.Vw_OPDBillServiceDetails.Entrydate, dbo.Vw_OPDBillServiceDetails.RegistrationType," +
                    " dbo.Vw_OPDBillServiceDetails.ReferenceDoc, dbo.BillPaymentTrns.CreatedBy, dbo.Vw_OPDBillServiceDetails.PatientComplaints," +
                    " dbo.Vw_OPDBillServiceDetails.Empname, dbo.Vw_OPDBillServiceDetails.DrId, dbo.BillPaymentTrns.DiscGivenBy, dbo.BillPaymentTrns.ReasonForBalance, " +
                    " dbo.BillPaymentTrns.ReasonForDisc, dbo.BillPaymentTrns.UpdatedOn, dbo.HospEmpMst.Empname AS DiscountGivenBy, dbo.DiscountTypeMst.DiscType, " +
                    " dbo.ReasonForBalance.ReasonForBalanceName, dbo.BillPaymentTrns.BranchId, dbo.BillPaymentTrns.FId, dbo.ModeOfPayment.ModeOfPaymentName, " +
                    " dbo.Vw_OPDBillServiceDetails.Qty, dbo.Vw_OPDBillServiceDetails.SingleBillServiceCharges " +
                    " FROM dbo.Vw_OPDBillServiceDetails INNER JOIN " +
                    " dbo.BillPaymentTrns ON dbo.Vw_OPDBillServiceDetails.BillNo = dbo.BillPaymentTrns.BillNo AND " +
                    " dbo.Vw_OPDBillServiceDetails.OpdNo = dbo.BillPaymentTrns.OpdNo INNER JOIN " +
                    " dbo.ModeOfPayment ON dbo.BillPaymentTrns.PaymentMode = dbo.ModeOfPayment.ModeOfPaymentId LEFT OUTER JOIN " +
                    " dbo.HospEmpMst ON dbo.BillPaymentTrns.DiscGivenBy = dbo.HospEmpMst.DrId LEFT OUTER JOIN " +
                    " dbo.DiscountTypeMst ON dbo.BillPaymentTrns.ReasonForDisc = dbo.DiscountTypeMst.DiscTypeId LEFT OUTER JOIN " +
                    " dbo.ReasonForBalance ON dbo.BillPaymentTrns.ReasonForBalance = dbo.ReasonForBalance.ReasonForBalanceId  " +
                    " where Vw_OPDBillServiceDetails.BillNo=" + Convert.ToInt32(HdnBillNo.Value) + " and dbo.BillPaymentTrns.ReceiptNo= " + Convert.ToInt32(ddl_Receipt.SelectedValue) + " and Vw_OPDBillServiceDetails.OpdNo=" + Convert.ToInt32(HdnOpdNo.Value) + " and dbo.Vw_OPDBillServiceDetails.PatRegId=" + Convert.ToInt32(PatRegId) + " and dbo.BillPaymentTrns.FId=" + Convert.ToInt32(HdnFId.Value) + " and dbo.BillPaymentTrns.BranchId=" + Convert.ToInt32(Session["BranchId"]) + " ";

            cmd1.CommandText = query + ")";
            conrp.Open();
            cmd1.ExecuteNonQuery();
            conrp.Close(); conrp.Dispose();
            Session.Add("rptsql", sql);
            Session["rptname"] = Server.MapPath("~/Report/Rpt_OPDBilling.rpt");
            Session["reportname"] = "OPDReceipt";
            Session["RPTFORMAT"] = "pdf";

            // ReportParameterClass.SelectionFormula = sql;
            string close = "<script language='javascript'>javascript:OpenReport();</script>";
            Type title1 = this.GetType();
            Page.ClientScript.RegisterStartupScript(title1, "", close);
        }

    }
    private void PrintReport()
    {
        try
        {
            BLLReports objBLLReports = new BLLReports();
            DataSet dsCustomers = new DataSet();
            ReportDocument crystalReport = new ReportDocument();
            crystalReport.Load(Server.MapPath("~/Report/Rpt_OPDBilling.rpt"));
            dsCustomers = objBLLReports.GetOPDBillDetails(Convert.ToInt32(Request.QueryString["BillNo"]), Convert.ToInt32(ViewState["ReceiptNo"]), Convert.ToInt32(Request.QueryString["OpdNo"]), Convert.ToInt32(Request.QueryString["PatRegId"]), Convert.ToInt32(Request.QueryString["FID"]), Convert.ToInt32(Session["BranchId"]));
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
    protected void btnAddBill_Click(object sender, EventArgs e)
    {
        Button Btnprint = (Button)sender;
        GridViewRow row = (GridViewRow)Btnprint.NamingContainer;

        this.RegisterPostBackControl();

        // DropDownList ddl_Receipt = gvDailyCash.Rows[row.RowIndex].FindControl("ddlReceipt") as DropDownList;
        HiddenField HdnOpdNo = gvDailyCash.Rows[row.RowIndex].FindControl("HdnOpdNo") as HiddenField;
        // HiddenField HdnBillNo = gvDailyCash.Rows[row.RowIndex].FindControl("HdnBillNo") as HiddenField;
        HiddenField HdnFId = gvDailyCash.Rows[row.RowIndex].FindControl("HdnFId") as HiddenField;
        int PatRegId = Convert.ToInt32(gvDailyCash.DataKeys[row.RowIndex]["PatRegId"]);
        Response.Redirect("OPDPatientRegistration.aspx?Flag=AddBill&PatRegId=" + PatRegId + "&FID=" + HdnFId.Value + "&OpdNo=" + HdnOpdNo.Value, false);

    }
}