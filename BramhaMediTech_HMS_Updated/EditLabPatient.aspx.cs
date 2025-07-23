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

public partial class EditLabPatient : System.Web.UI.Page
{
    BLLReports ObjDOReport = new BLLReports();
    decimal total = 0;
    decimal AmountPaid = 0;
    int Balance = 0;

    int Balance1 = 0;
    ReportDocument crystalReport = new ReportDocument();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["Report"] = "";
            txtFrom.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtTo.Text = DateTime.Now.ToString("dd/MM/yyyy");
            RdbStatus.SelectedValue = "2";
            ViewState["PatRegId"] = "0";
            FillUsers();
           // FillGrid();

        }
        this.RegisterPostBackControl();

    }

    protected void Page_Unload(object sender, EventArgs e)
    {
        if ((ViewState["Report"].ToString()) != "")
        {

            crystalReport.Close();
            crystalReport.Dispose();
        }
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

    }
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
        int BillNo = 0;
        if (txtbillNo.Text != "")
        {
            BillNo = Convert.ToInt32(txtbillNo.Text);
        }
        else
        {
            BillNo = 0;
        }

        gvDailyCash.DataSource = ObjDOReport.FillLabEditPatients(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), Convert.ToInt32(ViewState["PatRegId"]), txtMobileNo.Text.Trim(), RdbStatus.SelectedValue, BranchId, FId, BillNo, RdbStatus.SelectedValue, ddlUser.SelectedValue); //Convert.ToInt32(ddlUser.SelectedValue));
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
            
            Button btnPrint = (e.Row.FindControl("btnPrint") as Button);
            Button btnPay = (e.Row.FindControl("btnPay") as Button);

            

            int PatRegId = Convert.ToInt32(gvDailyCash.DataKeys[e.Row.RowIndex]["LabNo"].ToString());
            int FID =Convert.ToInt32 ((e.Row.FindControl("HdnFId") as HiddenField).Value);
            int BranchId = Convert.ToInt32 ((e.Row.FindControl("HdnBranchId") as HiddenField).Value);
            int LAbNo = Convert.ToInt32 ((e.Row.FindControl("HdnLabNo") as HiddenField).Value);
            int BillNo = Convert.ToInt32 ((e.Row.FindControl("HdnBillNo") as HiddenField).Value);
            string LabType = Convert.ToString((e.Row.FindControl("HdnLabPType") as HiddenField).Value);
            if (LabType == "P")
            {
                e.Row.Cells[10].Text = "<span class='btn btn-xs btn-success' >Path</span>";
            }
            else if (LabType == "R")
            {
                e.Row.Cells[10].Text = "<span class='btn btn-xs btn-danger' >Radio</span>";
            }
            else if (LabType == "C")
            {
                e.Row.Cells[10].Text = "<span class='btn btn-xs btn-primary' >Car</span>";
            }
            else
            {
                e.Row.Cells[10].Text = "<span class='btn btn-xs btn-warning' >Medi</span>";
            }
            //DropDownList ddl_Receipt = e.Row.FindControl("ddlReceipt") as DropDownList;

            //DataTable dt = new DataTable();
            //dt = ObjDOReport.GetLabReceiptNo(PatRegId, 0, BillNo, FID, BranchId, LAbNo);
            //if (dt.Rows.Count > 0)
            //{
            //    ddl_Receipt.DataSource = dt;
            //    ddl_Receipt.DataTextField = "ReceiptNo";
            //    ddl_Receipt.DataValueField = "ReceiptNo";
            //    ddl_Receipt.DataBind();
            //    ddl_Receipt.Items.Insert(0, "-Receipt-");
            //    ddl_Receipt.SelectedIndex = 0;
            //}

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
        string LAbNo = (gvDailyCash.Rows[e.NewEditIndex].FindControl("HdnLabNo") as HiddenField).Value;
        string BillNo = (gvDailyCash.Rows[e.NewEditIndex].FindControl("HdnBillNo") as HiddenField).Value;
        Response.Redirect("LabPaybillOutstanding.aspx?PatRegId=" + PatRegId + "&FID=" + FID + "&BillNo=" + BillNo + "&LabNo=" + LAbNo, false);

    }
    private void RegisterPostBackControl()
    {
        foreach (GridViewRow row in gvDailyCash.Rows)
        {
            DropDownList ddl_Receipt = row.FindControl("ddlReceipt") as DropDownList;
            Button btnPrint= row.FindControl("btnPrint") as Button;
            Button btncasepaper = row.FindControl("btncasepaper") as Button;
            ScriptManager.GetCurrent(this).RegisterPostBackControl(ddl_Receipt);
            ScriptManager.GetCurrent(this).RegisterPostBackControl(btnPrint);
            ScriptManager.GetCurrent(this).RegisterPostBackControl(btncasepaper);
            
        }
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {

        ViewState["Report"] = "True";
        Button Btnprint = (Button)sender;
        GridViewRow row = (GridViewRow)Btnprint.NamingContainer;

        this.RegisterPostBackControl();

        DropDownList ddl_Receipt = gvDailyCash.Rows[row.RowIndex].FindControl("ddlReceipt") as DropDownList;
        HiddenField HdnLabNo = gvDailyCash.Rows[row.RowIndex].FindControl("HdnLabNo") as HiddenField;
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
       
       
        string query = "ALTER VIEW [dbo].[Vw_LabFinalBillReport] AS (SELECT        Vw_LabOutstanding.BillNo, Vw_LabOutstanding.PatientName, Vw_LabOutstanding.BillServiceCharges, Vw_LabOutstanding.Entrydate, Vw_LabOutstanding.LabNo, Vw_LabOutstanding.PatRegId, "+
                   " SUM(BillPaymentTrns.ReceivedAmount) AS ReceivedAmount, SUM(BillPaymentTrns.DiscountAmt) AS DiscountAmt, Vw_LabOutstanding.BillServiceCharges - (SUM(BillPaymentTrns.DiscountAmt) "+
                   " + SUM(BillPaymentTrns.ReceivedAmount)) AS BalanceAmt, Vw_LabOutstanding.MobileNo, Vw_LabOutstanding.FId, Vw_LabOutstanding.BranchId, Vw_LabOutstanding.Age, Vw_LabOutstanding.AgeType,  "+
                   " Vw_LabOutstanding.GenderName, Vw_LabOutstanding.Empname, Vw_LabOutstanding.PatientInsuType, Vw_LabOutstanding.PatMainType, Vw_LabOutstanding.BloodGroup, Vw_LabOutstanding.BirthDate, "+
                   " ProcedureServiceDetails.Qty, Vw_LabOutstanding.BillServiceCharges AS SingleBillServiceCharges,  "+
                   " ProcedureServiceDetails.ServiceName + '' + CASE WHEN ProcedureServiceDetails.CancelBill = 1 THEN ' [Cancel Service]' ELSE '' END AS ServiceName, ProcedureServiceDetails.BillServiceId, "+
                   " ProcedureServiceDetails.BillServiceCharges AS TotalCharges " +
                  "  FROM            Vw_LabOutstanding INNER JOIN "+
                  "  BillPaymentTrns ON Vw_LabOutstanding.BillNo = BillPaymentTrns.BillNo AND Vw_LabOutstanding.PatRegId = BillPaymentTrns.PatRegId AND Vw_LabOutstanding.LabNo = BillPaymentTrns.LabNo INNER JOIN "+
                  "  ProcedureServiceDetails ON Vw_LabOutstanding.PatRegId = ProcedureServiceDetails.PatRegId AND Vw_LabOutstanding.LabNo = ProcedureServiceDetails.LabNo AND  "+
                  "  Vw_LabOutstanding.BillNo = ProcedureServiceDetails.BillNo "+
                " where Vw_LabOutstanding.BillNo=" + Convert.ToInt32(HdnBillNo.Value) + "  and Vw_LabOutstanding.LabNo=" + Convert.ToInt32(HdnLabNo.Value) + " and " +
                " dbo.Vw_LabOutstanding.PatRegId=" + Convert.ToInt32(PatRegId) + " and dbo.BillPaymentTrns.FId=" + Convert.ToInt32(HdnFId.Value) + " and dbo.BillPaymentTrns.BranchId=" + Convert.ToInt32(Session["BranchId"]) + " " +                
                "  GROUP BY Vw_LabOutstanding.BillNo, Vw_LabOutstanding.PatientName, Vw_LabOutstanding.BillServiceCharges, Vw_LabOutstanding.Entrydate, Vw_LabOutstanding.LabNo, Vw_LabOutstanding.PatRegId, Vw_LabOutstanding.MobileNo,  "+
                 "   Vw_LabOutstanding.FId, Vw_LabOutstanding.BranchId, Vw_LabOutstanding.Age, Vw_LabOutstanding.AgeType, Vw_LabOutstanding.GenderName, Vw_LabOutstanding.Empname, Vw_LabOutstanding.PatientInsuType,  "+
                  "  Vw_LabOutstanding.PatMainType, Vw_LabOutstanding.BloodGroup, Vw_LabOutstanding.BirthDate, ProcedureServiceDetails.Qty, ProcedureServiceDetails.BillServiceId, ProcedureServiceDetails.BillServiceCharges, "+
                  "  ProcedureServiceDetails.CancelBill,ProcedureServiceDetails.ServiceName ";
        
        cmd1.CommandText = query + ")";

        conrp.Open();
        cmd1.ExecuteNonQuery();
        conrp.Close(); conrp.Dispose();
        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Reports/Rpt_LabFinalBillPrint.rpt");
        Session["reportname"] = "LabFinalBillPrint";
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
        HiddenField HdnLabNo = gvDailyCash.Rows[RowIndex1].FindControl("HdnLabNo") as HiddenField;
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


            string query = "ALTER VIEW [dbo].[Vw_LabBillReport] AS (SELECT dbo.Vw_LabBillServiceDetails.BillNo, dbo.BillPaymentTrns.ReceiptNo, dbo.Vw_LabBillServiceDetails.FirstName AS PatientName, " +
                    " dbo.Vw_LabBillServiceDetails.PatRegId, dbo.Vw_LabBillServiceDetails.LabNo, dbo.Vw_LabBillServiceDetails.ServiceName, " +
                    " dbo.BillPaymentTrns.ReceivedAmount, dbo.BillPaymentTrns.DiscountAmt, dbo.BillPaymentTrns.BalanceAmt, dbo.BillPaymentTrns.BankName," +
                    " dbo.BillPaymentTrns.ChequeDate, dbo.BillPaymentTrns.ChequeNo, dbo.BillPaymentTrns.PaymentMode, dbo.Vw_LabBillServiceDetails.BillServiceCharges," +
                    " dbo.BillPaymentTrns.PaymentDate, dbo.Vw_LabBillServiceDetails.Entrydate, dbo.Vw_LabBillServiceDetails.RegistrationType," +
                    " dbo.Vw_LabBillServiceDetails.ReferenceDoc, dbo.BillPaymentTrns.CreatedBy, dbo.Vw_LabBillServiceDetails.PatientComplaints," +
                    " dbo.Vw_LabBillServiceDetails.Empname, dbo.Vw_LabBillServiceDetails.DrId, dbo.BillPaymentTrns.DiscGivenBy, dbo.BillPaymentTrns.ReasonForBalance, " +
                    " dbo.BillPaymentTrns.ReasonForDisc, dbo.BillPaymentTrns.UpdatedOn, dbo.HospEmpMst.Empname AS DiscountGivenBy, dbo.DiscountTypeMst.DiscType, " +
                    " dbo.ReasonForBalance.ReasonForBalanceName, dbo.BillPaymentTrns.BranchId, dbo.BillPaymentTrns.FId, dbo.ModeOfPayment.ModeOfPaymentName, " +
                    " dbo.Vw_LabBillServiceDetails.Qty, dbo.Vw_LabBillServiceDetails.SingleBillServiceCharges " +                    
                    " FROM            Vw_LabBillServiceDetails INNER JOIN "+
                     "   BillPaymentTrns ON Vw_LabBillServiceDetails.BillNo = BillPaymentTrns.BillNo AND Vw_LabBillServiceDetails.LabNo = BillPaymentTrns.LabNo AND "+
                     "   Vw_LabBillServiceDetails.ReceiptNo = BillPaymentTrns.ReceiptNo INNER JOIN "+
                     "   ModeOfPayment ON BillPaymentTrns.PaymentMode = ModeOfPayment.ModeOfPaymentId LEFT OUTER JOIN "+
                     "   HospEmpMst ON BillPaymentTrns.DiscGivenBy = HospEmpMst.DrId LEFT OUTER JOIN "+
                     "   DiscountTypeMst ON BillPaymentTrns.ReasonForDisc = DiscountTypeMst.DiscTypeId LEFT OUTER JOIN "+
                     "   ReasonForBalance ON BillPaymentTrns.ReasonForBalance = ReasonForBalance.ReasonForBalanceId  " +
                    " where Vw_LabBillServiceDetails.BillNo=" + Convert.ToInt32(HdnBillNo.Value) + " and dbo.BillPaymentTrns.ReceiptNo= " + Convert.ToInt32(ddl_Receipt.SelectedValue) + " and Vw_LabBillServiceDetails.LabNo=" + Convert.ToInt32(HdnLabNo.Value) + " and dbo.Vw_LabBillServiceDetails.PatRegId=" + Convert.ToInt32(PatRegId) + " and dbo.BillPaymentTrns.FId=" + Convert.ToInt32(HdnFId.Value) + " and dbo.BillPaymentTrns.BranchId=" + Convert.ToInt32(Session["BranchId"]) + " ";

            cmd1.CommandText = query + ")";
            conrp.Open();
            cmd1.ExecuteNonQuery();
            conrp.Close(); conrp.Dispose();
            Session.Add("rptsql", sql);
            Session["rptname"] = Server.MapPath("~/Report/Rpt_LabBilling.rpt");
            Session["reportname"] = "LabReceipt";
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
            dsCustomers = objBLLReports.GetOPDBillDetails(Convert.ToInt32(Request.QueryString["BillNo"]), Convert.ToInt32(ViewState["ReceiptNo"]), Convert.ToInt32(Request.QueryString["LabNo"]), Convert.ToInt32(Request.QueryString["PatRegId"]), Convert.ToInt32(Request.QueryString["FID"]), Convert.ToInt32(Session["BranchId"]));
            crystalReport.SetDataSource(dsCustomers);
            //crystalReport.ParameterFields["HospitalName"].CurrentValues.AddValue(Convert.ToString(Application["OrgnizationName"]));
            //crystalReport.ParameterFields["HospitalAddress"].CurrentValues.AddValue(Convert.ToString(Application["OrgnizationAddress"]));
            //crystalReport.ParameterFields["Image"].CurrentValues.AddValue(Application["ImagePath"]);
            // crystalReport.ParameterFields["ReportFooter"].CurrentValues.AddValue("Hospital Software | Ph.020 0000000000");
            try
            {
                crystalReport.ExportToHttpResponse
                (CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Employee");
            }
            catch (Exception ex)
            {
            }
            finally
            {
                crystalReport.Close();
                ((IDisposable)crystalReport).Dispose();
                GC.Collect();
                GC.SuppressFinalize(crystalReport);
            }

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
        HiddenField HdnLabNo = gvDailyCash.Rows[row.RowIndex].FindControl("HdnLabNo") as HiddenField;
       // HiddenField HdnBillNo = gvDailyCash.Rows[row.RowIndex].FindControl("HdnBillNo") as HiddenField;
        HiddenField HdnFId = gvDailyCash.Rows[row.RowIndex].FindControl("HdnFId") as HiddenField;
        int PatRegId = Convert.ToInt32(gvDailyCash.DataKeys[row.RowIndex]["PatRegId"]);
        HiddenField HDNPatRegId = gvDailyCash.Rows[row.RowIndex].FindControl("HdnPatRegId") as HiddenField;
        Response.Redirect("EditLabPatientRegistration.aspx?Flag=AddBill&PatRegId=" + HDNPatRegId.Value + "&FID=" + HdnFId.Value + "&LabNo=" + HdnLabNo.Value, false);

    }
    protected void btncasepaper_Click(object sender, EventArgs e)
    {
        Button btncasepaper = (Button)sender;
        GridViewRow row = (GridViewRow)btncasepaper.NamingContainer;

        this.RegisterPostBackControl();

        DropDownList ddl_Receipt = gvDailyCash.Rows[row.RowIndex].FindControl("ddlReceipt") as DropDownList;
        HiddenField HdnLabNo = gvDailyCash.Rows[row.RowIndex].FindControl("HdnLabNo") as HiddenField;
        HiddenField HdnBillNo = gvDailyCash.Rows[row.RowIndex].FindControl("HdnBillNo") as HiddenField;
        HiddenField HdnFId = gvDailyCash.Rows[row.RowIndex].FindControl("HdnFId") as HiddenField;
        int PatRegId = Convert.ToInt32(gvDailyCash.DataKeys[row.RowIndex]["PatRegId"]);

        ViewState["LabNo"] = HdnLabNo.Value;
        ViewState["PatientInfoId"] = PatRegId;
        Alter_view();
        string sql = "";
        BLLReports objBLLReports = new BLLReports();
        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Report/Rpt_CaseReport.rpt");
        Session["reportname"] = "Rpt_CaseReport";
        Session["RPTFORMAT"] = "pdf";

        //ReportParameterClass.SelectionFormula = sql;
        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);
        
    }
    public void Alter_view()
    {
        string sql = "";
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd1 = con.CreateCommand();

        string query = "ALTER VIEW [dbo].[VW_OPDCasePaper] AS (SELECT DISTINCT " +
              "  Initial.Title + ' ' + PatientInformation.FirstName AS FirstName, OpdRegistration.PatRegId, OpdRegistration.Entrydate, OpdRegistration.RegistrationType, OpdRegistration.ReferenceDoc, OpdRegistration.CreatedBy,  " +
             "   OpdRegistration.FId, OpdRegistration.BranchId, OpdRegistration.PatientComplaints, OpdRegistration.OpdNo, ProcedureServiceDetails.BillServiceId, BillService.ServiceName, ProcedureServiceDetails.DrId, " +
             "   HospEmpMst.Title + ' ' + HospEmpMst.Empname AS Empname, ProcedureServiceDetails.BillServiceCharges, ProcedureServiceDetails.BillNo, ProcedureServiceDetails.Qty, 0 as SingleBillServiceCharges, " +
             "   OpdRegistration.TokenNo, Initial.Title, Gender.GenderName, DepartmentMst.DeptName, HospEmpMst.Title AS DrInitial, PatientInformation.PatientAddress, PatientInformation.MobileNo, PatMainType.PatMainType  ,cast(PatientInformation.Age as nvarchar(50))+' '+ PatientInformation.AgeType as AgeType " +
             "   FROM            OpdRegistration INNER JOIN " +
             "   ProcedureServiceDetails ON OpdRegistration.OpdNo = ProcedureServiceDetails.OpdNo INNER JOIN " +
             "   PatientInformation ON OpdRegistration.PatRegId = PatientInformation.PatRegId INNER JOIN " +
             "   BillService ON ProcedureServiceDetails.BillServiceId = BillService.BillServiceId INNER JOIN " +
             "   Initial ON PatientInformation.TitleId = Initial.TitleId INNER JOIN " +
             "   Gender ON PatientInformation.GenderId = Gender.GenderId INNER JOIN  " +
             "   DepartmentMst ON OpdRegistration.DeptId = DepartmentMst.DeptId INNER JOIN " +
             "   PatMainType ON OpdRegistration.PatientMainCategoryId = PatMainType.PatMainTypeId LEFT OUTER JOIN " +
             "   HospEmpMst ON ProcedureServiceDetails.DrId = HospEmpMst.DrId " +
        " where OpdRegistration.branchid=" + Convert.ToInt32(Session["Branchid"]) + "  and OpdRegistration.OpdNo= " + Convert.ToInt32(ViewState["LabNo"]) + " and  OpdRegistration.PatRegId= " + Convert.ToInt32(ViewState["PatientInfoId"]) + "";
        //if (txtFrom.Value != "" && txtTo.Value != "")
        //{
        //    query += " and    DagnosisAssigtTpPatient.CreatedOn between ('" + Convert.ToDateTime(txtFrom.Value).ToString("MM/dd/yyyy") + "') and ('" + Convert.ToDateTime(txtTo.Value).AddDays(1).ToString("MM/dd/yyyy") + "')";
        //}



        cmd1.CommandText = query + ")";

        con.Open();
        cmd1.ExecuteNonQuery();
        con.Close(); con.Dispose();
    }
    protected void gvDailyCash_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (txtCancelremark.Text == "")
        {
            txtCancelremark.Focus();
            lblMessage.Text = "Enter Cancel Remark!.";
        }
        else
        {
            int BranchId = Convert.ToInt32(Session["BranchId"]);
            string ProcedureServiceId = (gvDailyCash.DataKeys[e.RowIndex]["LabNo"].ToString());
            string PatRegId = (gvDailyCash.Rows[e.RowIndex].FindControl("HdnPatRegId") as HiddenField).Value;
            string BillNo = (gvDailyCash.Rows[e.RowIndex].FindControl("HdnBillNo") as HiddenField).Value;
            string Message = ObjDOReport.Delete_LabService(Convert.ToInt32(BillNo), Convert.ToInt32(ProcedureServiceId), Convert.ToInt32(PatRegId), BranchId, Convert.ToString(Session["username"]), txtCancelremark.Text);
            FillGrid();
            txtCancelremark.Text = "";
            lblMessage.Text = "Cancel successfully!.";
        }
    }
    protected void gvDailyCash_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Print")
        {
            ViewState["Report"] = "True";
            //Button Btnprint = (Button)sender;
            //GridViewRow row = (GridViewRow)Btnprint.NamingContainer;
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvDailyCash.Rows[rowIndex];
          
 

           // this.RegisterPostBackControl();

            DropDownList ddl_Receipt = gvDailyCash.Rows[row.RowIndex].FindControl("ddlReceipt") as DropDownList;
            HiddenField HdnLabNo = gvDailyCash.Rows[row.RowIndex].FindControl("HdnLabNo") as HiddenField;
            HiddenField HdnBillNo = gvDailyCash.Rows[row.RowIndex].FindControl("HdnBillNo") as HiddenField;
            HiddenField HdnFId = gvDailyCash.Rows[row.RowIndex].FindControl("HdnFId") as HiddenField;
          //  int PatRegId = Convert.ToInt32(gvDailyCash.DataKeys[row.RowIndex]["PatRegId"]);
            int PatRegId = Convert.ToInt32(gvDailyCash.Rows[rowIndex].Cells[5].Text);
            string sql = "";


            BLLReports objBLLReports = new BLLReports();
            DataSet dsCustomers = new DataSet();

            dsCustomers = objBLLReports.GetLabBillDetailsAll(Convert.ToInt32(HdnBillNo.Value), Convert.ToInt32(HdnLabNo.Value), Convert.ToInt32(PatRegId), Convert.ToInt32(Session["FId"]), Convert.ToInt32(Session["BranchId"]));

            Session.Add("rptsql", sql);
            Session["rptname"] = Server.MapPath("~/Report/Rpt_LabBilling.rpt");
            Session["reportname"] = "LabReceipt";
            Session["RPTFORMAT"] = "pdf";


            string close = "<script language='javascript'>javascript:OpenReport();</script>";
            Type title1 = this.GetType();
            Page.ClientScript.RegisterStartupScript(title1, "", close);
        }


    }
}