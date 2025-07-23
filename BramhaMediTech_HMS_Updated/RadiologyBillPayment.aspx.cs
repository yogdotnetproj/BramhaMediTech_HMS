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

public partial class RadiologyBillPayment : System.Web.UI.Page
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
            RdbStatus.SelectedValue = "1";
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
        return objDALOpdReg.FillAllOPDPatient(prefixText);
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


        gvDailyCash.DataSource = ObjDOReport.FillRadiologyBillOutstanding(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), Convert.ToInt32(ViewState["PatRegId"]), txtMobileNo.Text.Trim(), RdbStatus.SelectedValue, BranchId, FId); //Convert.ToInt32(ddlUser.SelectedValue));
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
            float balance;
            if (e.Row.Cells[11].Text == "&nbsp;")
            {
                balance = 0;
            }
            else
            {
                balance = Convert.ToSingle(e.Row.Cells[11].Text);
            }
            string LabPtype = Convert.ToString((e.Row.FindControl("hdnLabPtype") as HiddenField).Value);
            if (LabPtype == "R")
            {
                e.Row.Cells[12].Text = "<span class='btn btn-xs btn-success' >Rad</span>";
            }
            else if (LabPtype == "M")
            {
                e.Row.Cells[12].Text = "<span class='btn btn-xs btn-warning' >Med</span>";
            }
            else
            {
                e.Row.Cells[12].Text = "<span class='btn btn-xs btn-danger' >Pat</span>";
            }
            if (balance > 0)
            {
                e.Row.Cells[02].Text = "<span class='btn btn-xs btn-danger' >Pending</span>";
            }
            else
            {
                e.Row.Cells[0].Enabled = false;
                e.Row.Cells[02].Text = "<span class='btn btn-xs btn-success' >Done</span>";
            }
            Button btnPrint = (e.Row.FindControl("btnPrint") as Button);
            Button btnPay = (e.Row.FindControl("btnPay") as Button);
          
            CheckBox Chk = (e.Row.FindControl("ChkFinalSettelement") as CheckBox);
            Button btnUpdate = e.Row.FindControl("btnAddBill") as Button;
           // Button Btnprint = e.Row.FindControl("Btnprint") as Button;
            if (Chk.Checked == true)
            {

                btnPrint.Enabled = true;
                btnUpdate.Enabled = false;

            }
            else
            {
                btnPrint.Enabled = false;
                btnUpdate.Enabled = true;
            }
            

            int PatRegId = Convert.ToInt32(gvDailyCash.DataKeys[e.Row.RowIndex]["PatRegId"].ToString());
            int FID =Convert.ToInt32 ((e.Row.FindControl("HdnFId") as HiddenField).Value);
            int BranchId = Convert.ToInt32 ((e.Row.FindControl("HdnBranchId") as HiddenField).Value);
            int LabNo = Convert.ToInt32 ((e.Row.FindControl("HdnLabNo") as HiddenField).Value);
            int BillNo = Convert.ToInt32 ((e.Row.FindControl("HdnBillNo") as HiddenField).Value);
      
            DropDownList ddl_Receipt = e.Row.FindControl("ddlReceipt") as DropDownList;

            DataTable dt = new DataTable();
            dt = ObjDOReport.GetReceiptNo(PatRegId,LabNo, BillNo, FID, BranchId);
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
        string LabNo = (gvDailyCash.Rows[e.NewEditIndex].FindControl("HdnLabNo") as HiddenField).Value;
        string BillNo = (gvDailyCash.Rows[e.NewEditIndex].FindControl("HdnBillNo") as HiddenField).Value;
        Response.Redirect("Edit_RadiologyRegistration.aspx?PatRegId=" + PatRegId + "&FID=" + FID + "&BillNo=" + BillNo + "&LabNo=" + LabNo, false);

    }
    private void RegisterPostBackControl()
    {
        foreach (GridViewRow row in gvDailyCash.Rows)
        {
            DropDownList ddl_Receipt = row.FindControl("ddlReceipt") as DropDownList;
            Button btnPrint= row.FindControl("btnPrint") as Button;
            Button btnAddBill = row.FindControl("btnAddBill") as Button;
            ScriptManager.GetCurrent(this).RegisterPostBackControl(ddl_Receipt);
            ScriptManager.GetCurrent(this).RegisterPostBackControl(btnPrint);
            ScriptManager.GetCurrent(this).RegisterPostBackControl(btnAddBill);
            
        }
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {

        ViewState["Report"] = "True";
        Button Btnprint = (Button)sender;
        GridViewRow row = (GridViewRow)Btnprint.NamingContainer;

        this.RegisterPostBackControl();

       // DropDownList ddl_Receipt = gvDailyCash.Rows[row.RowIndex].FindControl("ddlReceipt") as DropDownList;
        HiddenField HdnLabNo = gvDailyCash.Rows[row.RowIndex].FindControl("HdnLabNo") as HiddenField;
        HiddenField HdnBillNo = gvDailyCash.Rows[row.RowIndex].FindControl("HdnBillNo") as HiddenField;
        HiddenField HdnFId = gvDailyCash.Rows[row.RowIndex].FindControl("HdnFId") as HiddenField;
        HiddenField HdnReceiptNo = gvDailyCash.Rows[row.RowIndex].FindControl("HdnReceiptNo") as HiddenField;
        int PatRegId = Convert.ToInt32(gvDailyCash.DataKeys[row.RowIndex]["PatRegId"]);

        ViewState["BillNo"]=HdnBillNo.Value;
        ViewState["ReceiptNo"]=HdnReceiptNo.Value;
        ViewState["LabNo"]=HdnLabNo.Value;
        ViewState["PatientInfoId"] = PatRegId;
        OPDPrintReport();


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
                    " where Vw_OPDBillServiceDetails.BillNo=" + Convert.ToInt32(HdnBillNo.Value) + " and dbo.BillPaymentTrns.ReceiptNo= " + Convert.ToInt32(ddl_Receipt.SelectedValue) + " and Vw_OPDBillServiceDetails.OpdNo=" + Convert.ToInt32(HdnLabNo.Value) + " and dbo.Vw_OPDBillServiceDetails.PatRegId=" + Convert.ToInt32(PatRegId) + " and dbo.BillPaymentTrns.FId=" + Convert.ToInt32(HdnFId.Value) + " and dbo.BillPaymentTrns.BranchId=" + Convert.ToInt32(Session["BranchId"]) + " ";

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
        ViewState["Report"] = "True";
        Button btnAddBill = (Button)sender;
        GridViewRow row = (GridViewRow)btnAddBill.NamingContainer;

        this.RegisterPostBackControl();

       // DropDownList ddl_Receipt = gvDailyCash.Rows[row.RowIndex].FindControl("ddlReceipt") as DropDownList;
        HiddenField HdnLabNo = gvDailyCash.Rows[row.RowIndex].FindControl("HdnLabNo") as HiddenField;
       // HiddenField HdnBillNo = gvDailyCash.Rows[row.RowIndex].FindControl("HdnBillNo") as HiddenField;
        HiddenField HdnFId = gvDailyCash.Rows[row.RowIndex].FindControl("HdnFId") as HiddenField;
        int PatRegId = Convert.ToInt32(gvDailyCash.DataKeys[row.RowIndex]["PatRegId"]);
        HiddenField HdnBillPaymentId = gvDailyCash.Rows[row.RowIndex].FindControl("HdnBillPaymentId") as HiddenField;
        
      //  Response.Redirect("OPDPatientRegistration.aspx?Flag=AddBill&PatRegId=" + PatRegId + "&FID=" + HdnFId.Value + "&OpdNo=" + HdnOpdNo.Value, false);
        int FId=Convert.ToInt32(Session["FId"]);
        int BranchId=Convert.ToInt32(Session["Branchid"]);
        string  UserName = Convert.ToString(Session["Username"]);
         float balance = Convert.ToSingle(gvDailyCash.Rows[row.RowIndex].Cells[11].Text);
         HiddenField HdnBillNo = gvDailyCash.Rows[row.RowIndex].FindControl("HdnBillNo") as HiddenField;
         HiddenField HdnReceiptNo = gvDailyCash.Rows[row.RowIndex].FindControl("HdnReceiptNo") as HiddenField;
        CheckBox chk = gvDailyCash.Rows[row.RowIndex].FindControl("ChkFinalSettelement") as CheckBox;
      //  string LabPtype = Convert.ToString((e.Row.FindControl("hdnLabPtype") as HiddenField).Value);
        HiddenField LabPtype = gvDailyCash.Rows[row.RowIndex].FindControl("hdnLabPtype") as HiddenField;
        if (chk.Checked == true)
        {
            ObjDOReport.UpdatePaymentStatusInTreatment(PatRegId, Convert.ToInt32(HdnLabNo.Value), Convert.ToInt32(HdnBillPaymentId.Value), UserName, balance, LabPtype.Value);
          
            ViewState["BillNo"] = HdnBillNo.Value;
            ViewState["ReceiptNo"] = HdnReceiptNo.Value;
            ViewState["LabNo"] = HdnLabNo.Value;
            ViewState["PatientInfoId"] = PatRegId;
            FillGrid();
            OPDPrintReport();
           // 
        }

    }
    protected void ChkFinalSettelement_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox ChkFinalSettelement = (CheckBox)sender;
        GridViewRow row = (GridViewRow)ChkFinalSettelement.NamingContainer;
        //lblmsg.Text = "";


    }

    private void OPDPrintReport()
    {
        try
        {
            BLLReports objBLLReports = new BLLReports();
            DataSet dsCustomers = new DataSet();
            //ReportDocument crystalReport = new ReportDocument();
            //crystalReport.Load(Server.MapPath("~/Report/Rpt_OPDBilling.rpt"));
            dsCustomers = objBLLReports.GetLabBillDetails(Convert.ToInt32(ViewState["BillNo"]), Convert.ToInt32(ViewState["ReceiptNo"]), Convert.ToInt32(ViewState["LabNo"]), Convert.ToInt32(ViewState["PatientInfoId"]), Convert.ToInt32(Session["FId"]), Convert.ToInt32(Session["BranchId"]));
            //crystalReport.SetDataSource(dsCustomers);
            ////crystalReport.ParameterFields["HospitalName"].CurrentValues.AddValue(Convert.ToString(Application["OrgnizationName"]));
            ////crystalReport.ParameterFields["HospitalAddress"].CurrentValues.AddValue(Convert.ToString(Application["OrgnizationAddress"]));
            ////crystalReport.ParameterFields["Image"].CurrentValues.AddValue(Application["ImagePath"]);
            //// crystalReport.ParameterFields["ReportFooter"].CurrentValues.AddValue("Hospital Software | Ph.020 0000000000");
            //crystalReport.ExportToHttpResponse
            //(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Employee");

            string sql = "";
            Session.Add("rptsql", sql);
            Session["rptname"] = Server.MapPath("~/Report/Rpt_LabBilling.rpt");
            Session["reportname"] = "LabReceipt";
            Session["RPTFORMAT"] = "pdf";

            //ReportParameterClass.SelectionFormula = sql;
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