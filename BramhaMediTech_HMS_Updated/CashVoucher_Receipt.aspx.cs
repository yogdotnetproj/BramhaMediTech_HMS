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

public partial class CashVoucher_Receipt : BasePage
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
        
            ViewState["PatRegId"] = "0";
          
            FillUsers();
            //FillGrid();

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
    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchPayTo(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        return objDALOpdReg.VoucherPayment_PayTo(prefixText);
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
        int Sponser = Convert.ToInt32(ViewState["PayTo"]);
        gvDailyCash.DataSource = ObjDOReport.Fill_CashVoucherr_Receipt(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), Convert.ToInt32(Sponser), Convert.ToString(ddlUser.SelectedValue)); //Convert.ToInt32(ddlUser.SelectedValue));
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
    protected void gvDailyCash_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex != -1)
        {
            //float balance;
            //if (e.Row.Cells[13].Text == "&nbsp;")
            //{
            //    balance = 0;
            //}
            //else
            //{
            //    balance = Convert.ToSingle(e.Row.Cells[13].Text);
            //}
            //if (balance > 0)
            //{
            //    e.Row.Cells[2].Text = "<span class='btn btn-xs btn-danger' >Pending</span>";
            //}
            //else
            //{
            //   // e.Row.Cells[0].Enabled = false;
            //    e.Row.Cells[2].Text = "<span class='btn btn-xs btn-success' >Done</span>";
            //}
            //Button btnPrint = (e.Row.FindControl("btnPrint") as Button);
            //Button btnPay = (e.Row.FindControl("btnPay") as Button);
            //string LabType = Convert.ToString((e.Row.FindControl("HdnLabPType") as HiddenField).Value);
            //if (LabType == "P")
            //{
            //    e.Row.Cells[15].Text = "<span class='btn btn-xs btn-success' >Path</span>";
            //}
            //else if (LabType == "R")
            //{
            //    e.Row.Cells[15].Text = "<span class='btn btn-xs btn-danger' >Radio</span>";
            //}
            //else if (LabType == "C")
            //{
            //    e.Row.Cells[15].Text = "<span class='btn btn-xs btn-primary' >Car</span>";
            //}
            //else
            //{
            //    e.Row.Cells[15].Text = "<span class='btn btn-xs btn-warning' >Medi</span>";
            //}

            //int PatRegId = Convert.ToInt32(gvDailyCash.DataKeys[e.Row.RowIndex]["PatRegId"].ToString());
            //int FID =Convert.ToInt32 ((e.Row.FindControl("HdnFId") as HiddenField).Value);
            //int BranchId = Convert.ToInt32 ((e.Row.FindControl("HdnBranchId") as HiddenField).Value);
            //int LAbNo = Convert.ToInt32 ((e.Row.FindControl("HdnLabNo") as HiddenField).Value);
            //int BillNo = Convert.ToInt32 ((e.Row.FindControl("HdnBillNo") as HiddenField).Value);
      
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

        

    }
   
    private void RegisterPostBackControl()
    {
        foreach (GridViewRow row in gvDailyCash.Rows)
        {
           // DropDownList ddl_Receipt = row.FindControl("ddlReceipt") as DropDownList;
            Button btnPrint= row.FindControl("btnPrint") as Button;
            Button btncasepaper = row.FindControl("btncasepaper") as Button;
            //ScriptManager.GetCurrent(this).RegisterPostBackControl(ddl_Receipt);
            ScriptManager.GetCurrent(this).RegisterPostBackControl(btnPrint);
            //ScriptManager.GetCurrent(this).RegisterPostBackControl(btncasepaper);
            
        }
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {

        ViewState["Report"] = "True";
        Button Btnprint = (Button)sender;
        GridViewRow row = (GridViewRow)Btnprint.NamingContainer;

        this.RegisterPostBackControl();

       
        HiddenField HdnSponser = gvDailyCash.Rows[row.RowIndex].FindControl("HdnSponser") as HiddenField;
        int ReceiptNo = Convert.ToInt32(gvDailyCash.DataKeys[row.RowIndex]["CashId"]);

        BLLReports objreports = new BLLReports();
        string sql = "";
        int FId = Convert.ToInt32(Session["FId"]);
        int BranchId = Convert.ToInt32(Session["BranchId"]);
        //int ReceiptNo = 0;

       // int ReceiptNo = Convert.ToInt32(ddlreceipts.SelectedValue);


        int Sponser = Convert.ToInt32(ViewState["PayTo"]);
        //objreports.InsurancePaymentReceipts_ForOPD(ReceiptNo,Convert.ToInt32( HdnSponser.Value), FId, BranchId);

        //Session.Add("rptsql", sql);
        //Session["rptname"] = Server.MapPath("~/Reports/Rpt_InsurancePaymentReceipt_ForOPD.rpt");
        //Session["reportname"] = "InsurancePaymentReceipt_ForOPD";
        //Session["RPTFORMAT"] = "pdf";

        objreports.CashVoucherAllPaymentReceipts_Report(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), Sponser, "0", BranchId, ReceiptNo);

        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Reports/Rpt_CashVoucher_PaymentReceipt.rpt");
        Session["reportname"] = "CashVoucher_PaymentReceipt";
        Session["RPTFORMAT"] = "pdf";


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
    protected void gvDailyCash_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Print_Click(object sender, EventArgs e)
    {
        BLLReports objreports = new BLLReports();
        string sql = "";
        int FId = Convert.ToInt32(Session["FId"]);
        int BranchId = Convert.ToInt32(Session["BranchId"]);
        //int ReceiptNo = 0;

      //  int ReceiptNo = Convert.ToInt32(ddlreceipts.SelectedValue);

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
        int Sponser = Convert.ToInt32(ViewState["PayTo"]);


        objreports.CashVoucherAllPaymentReceipts_Report(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), Sponser, Convert.ToString(ddlUser.SelectedValue), BranchId, 0);

        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Reports/Rpt_CashVoucher_PaymentReceipt.rpt");
        Session["reportname"] = "CashVoucher_PaymentReceipt";
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
        if (txtInsuranceid.Text != "")
        {
            string[] PatientInfo = txtInsuranceid.Text.Split('-');
            if (PatientInfo.Length > 1)
            {
                txtInsuranceid.Text = PatientInfo[1];
                ViewState["PayTo"] = PatientInfo[0];
            }
            else
            {
                ViewState["PayTo"] = "0";

            }
        }

    }
    protected void txtFrom_TextChanged1(object sender, EventArgs e)
    {

    }
    protected void txtTo_TextChanged1(object sender, EventArgs e)
    {

    }
   
}