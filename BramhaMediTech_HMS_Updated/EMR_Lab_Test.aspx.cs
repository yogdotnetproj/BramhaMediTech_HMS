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

public partial class EMR_Lab_Test :BasePage
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
            txtFrom.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtTo.Text = DateTime.Now.ToString("dd/MM/yyyy");
            RdbStatus.SelectedValue = "2";
            ViewState["PatRegId"] = "0";
            FillUsers();
            //FillUsers();
            FillGrid();

        }
        this.RegisterPostBackControl();

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
            BillNo =  Convert.ToInt32( txtbillNo.Text);
        }
        else
        {
            BillNo = 0;
        }

        gvDailyCash.DataSource = ObjDOReport.Get_EMR_LabPatients(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), Convert.ToInt32(ViewState["PatRegId"]), txtMobileNo.Text.Trim(), RdbStatus.SelectedValue, BranchId, FId, RdbStatus.SelectedValue, ddlUser.SelectedValue, RblTestStatue.SelectedValue); //Convert.ToInt32(ddlUser.SelectedValue));
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
            bool CancelBill = Convert.ToBoolean((e.Row.FindControl("HdnCancelBill") as HiddenField).Value);
            if (CancelBill== false)
            {
                e.Row.Cells[2].Text = "<span class='btn btn-xs btn-danger' >Pending</span>";
            }
            else
            {
               // e.Row.Cells[0].Enabled = false;
                e.Row.Cells[2].Text = "<span class='btn btn-xs btn-success' >Done</span>";
            }
            Button btnPrint = (e.Row.FindControl("btnPrint") as Button);
            Button btnPay = (e.Row.FindControl("btnPay") as Button);
            string LabType = Convert.ToString((e.Row.FindControl("HdnLabPType") as HiddenField).Value);
            if (LabType == "P")
            {
                e.Row.Cells[09].Text = "<span class='btn btn-xs btn-success' >Path</span>";
            }
            else if (LabType == "R")
            {
                e.Row.Cells[09].Text = "<span class='btn btn-xs btn-danger' >Radio</span>";
            }
            else if (LabType == "C")
            {
                e.Row.Cells[09].Text = "<span class='btn btn-xs btn-primary' >Car</span>";
            }
            else
            {
                e.Row.Cells[09].Text = "<span class='btn btn-xs btn-warning' >Medi</span>";
            }

            int PatRegId = Convert.ToInt32(gvDailyCash.DataKeys[e.Row.RowIndex]["PatRegId"].ToString());
            int FID =Convert.ToInt32 ((e.Row.FindControl("HdnFId") as HiddenField).Value);
            int BranchId = Convert.ToInt32 ((e.Row.FindControl("HdnBranchId") as HiddenField).Value);
            int LAbNo = Convert.ToInt32 ((e.Row.FindControl("HdnLabNo") as HiddenField).Value);
            int BillNo = Convert.ToInt32 ((e.Row.FindControl("HdnBillNo") as HiddenField).Value);
      
            DropDownList ddl_Receipt = e.Row.FindControl("ddlReceipt") as DropDownList;

            DataTable dt = new DataTable();
            dt = ObjDOReport.GetLabReceiptNo(PatRegId, 0, BillNo, FID, BranchId, LAbNo);
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
          //  ScriptManager.GetCurrent(this).RegisterPostBackControl(btncasepaper);
            
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
      
        BLLReports objBLLReports = new BLLReports();
        DataSet dsCustomers = new DataSet();
        //ReportDocument crystalReport = new ReportDocument();
        //crystalReport.Load(Server.MapPath("~/Report/Rpt_OPDBilling.rpt"));
       // dsCustomers = objBLLReports.GetLabBillDetailsAll(Convert.ToInt32(HdnBillNo.Value),  Convert.ToInt32(HdnLabNo.Value), Convert.ToInt32(PatRegId), Convert.ToInt32(Session["FId"]), Convert.ToInt32(Session["BranchId"]));
        dsCustomers = objBLLReports.GetEMR_LabBillDetails(Convert.ToInt32(HdnLabNo.Value), Convert.ToInt32(PatRegId), Convert.ToInt32(Session["FId"]), Convert.ToInt32(Session["BranchId"]));


       
        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Report/Rpt_LabBilling.rpt");
        Session["reportname"] = "LabEMRReceipt";
        Session["RPTFORMAT"] = "pdf";

        //ReportParameterClass.SelectionFormula = sql;
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
        HiddenField HdnLabNo = gvDailyCash.Rows[row.RowIndex].FindControl("HdnLabNo") as HiddenField;
       // HiddenField HdnBillNo = gvDailyCash.Rows[row.RowIndex].FindControl("HdnBillNo") as HiddenField;
        HiddenField HdnFId = gvDailyCash.Rows[row.RowIndex].FindControl("HdnFId") as HiddenField;
        int PatRegId = Convert.ToInt32(gvDailyCash.DataKeys[row.RowIndex]["PatRegId"]);
        HiddenField HDNPatRegId = gvDailyCash.Rows[row.RowIndex].FindControl("HdnPatRegId") as HiddenField;
        Response.Redirect("LabPatientRegistration.aspx?Flag=AddBill&PatRegId=" + HDNPatRegId.Value + "&FID=" + HdnFId.Value + "&LabNo=" + HdnLabNo.Value+  "&EmrFlag=EMR", false);

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
}