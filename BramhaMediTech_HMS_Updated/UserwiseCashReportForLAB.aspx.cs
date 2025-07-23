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


public partial class UserwiseCashReportForLAB : System.Web.UI.Page
{
    BLLReports ObjDOReport = new BLLReports();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtFrom.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtTo.Text = DateTime.Now.ToString("dd/MM/yyyy");
            BindTime();
            //RdbPayment.SelectedValue = "All";
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
        //  ddlTimeTo.Items.Insert(0, new ListItem("--Select--", "0"));
          ddlTimeTo.Items.Insert(0, new ListItem("23:59", "23:59"));
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
        if (txtRefBy.Text != "")
        {
            string[] PatientInfo = txtRefBy.Text.Split('=');
            if (PatientInfo.Length > 1)
            {
                txtRefBy.Text = PatientInfo[0];
                ViewState["RefBy"] = PatientInfo[1];
            }
        }
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

    protected void Print_Click(object sender, EventArgs e)
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
            objreports.FillLABIncomeReport(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), ddlUser.SelectedValue, Convert.ToInt32(RdbPayment.SelectedValue), ddlBillGroup.SelectedValue, BranchId, FId, ddlBank.SelectedItem.Text, txtRefBy.Text.Trim());

            Session.Add("rptsql", sql);
            Session["rptname"] = Server.MapPath("~/Reports/Rpt_UserWiseLabCashReport.rpt");
            Session["reportname"] = "UserWiseLABCash_Report";
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
    protected void btncharge_Click(object sender, EventArgs e)
    {
        string sql = "";
        BLLReports objreports = new BLLReports();
        try
        {
            Alterview();

            //if (txtFrom.Text.ToString() != "")
            //{
            //    ViewState["FromDate"] = txtFrom.Text.ToString();

            //}
            //else
            //{
            //    ViewState["FromDate"] = "";
            //}
            //if (txtTo.Text.ToString() != "")
            //{

            //    ViewState["ToDate"] = txtTo.Text.ToString();


            //}
            //else
            //{
            //    ViewState["ToDate"] = "";
            //}
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
            objreports.FillLABIncomeReport(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), ddlUser.SelectedValue, Convert.ToInt32(RdbPayment.SelectedValue), ddlBillGroup.SelectedValue, BranchId, FId,ddlBank.SelectedItem.Text,txtRefBy.Text.Trim());

            Session.Add("rptsql", sql);
            Session["rptname"] = Server.MapPath("~/Reports/Rpt_UserWiseLabChargeReport.rpt");
            Session["reportname"] = "UserWiseLABCharge_Report";
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
    protected void btnradiologyprint_Click(object sender, EventArgs e)
    {
        string sql = "";
        BLLReports objreports = new BLLReports();
        try
        {

            Alterview();
            //if (txtFrom.Text.ToString() != "")
            //{
            //    ViewState["FromDate"] = txtFrom.Text.ToString();

            //}
            //else
            //{
            //    ViewState["FromDate"] = "";
            //}
            //if (txtTo.Text.ToString() != "")
            //{

            //    ViewState["ToDate"] = txtTo.Text.ToString();


            //}
            //else
            //{
            //    ViewState["ToDate"] = "";
            //}
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
          
            objreports.FillLABIncomeReport(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), ddlUser.SelectedValue, Convert.ToInt32(RdbPayment.SelectedValue), ddlBillGroup.SelectedValue, BranchId, FId,ddlBank.SelectedItem.Text,txtRefBy.Text.Trim());

            Session.Add("rptsql", sql);
            Session["rptname"] = Server.MapPath("~/Reports/Rpt_UserWiseLabCashReportRadio.rpt");
            Session["reportname"] = "UserWiseLABCash_ReportRadio";
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
    protected void btnprintexcel_Click(object sender, EventArgs e)
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
            objreports.FillLABIncomeReport(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), ddlUser.SelectedValue, Convert.ToInt32(RdbPayment.SelectedValue), ddlBillGroup.SelectedValue, BranchId, FId, ddlBank.SelectedItem.Text, txtRefBy.Text.Trim());

            Session.Add("rptsql", sql);
            Session["rptname"] = Server.MapPath("~/Reports/Rpt_UserWiseLabCashReport.rpt");
            Session["reportname"] = "UserWiseLABCash_Report";
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
    protected void btnsummaryreportExcel_Click(object sender, EventArgs e)
    {
        string sql = "";
        BLLReports objreports = new BLLReports();
        try
        {

            Alterview();
            //if (txtFrom.Text.ToString() != "")
            //{
            //    ViewState["FromDate"] = txtFrom.Text.ToString();

            //}
            //else
            //{
            //    ViewState["FromDate"] = "";
            //}
            //if (txtTo.Text.ToString() != "")
            //{

            //    ViewState["ToDate"] = txtTo.Text.ToString();


            //}
            //else
            //{
            //    ViewState["ToDate"] = "";
            //}
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

            objreports.FillLABIncomeReport(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), ddlUser.SelectedValue, Convert.ToInt32(RdbPayment.SelectedValue), ddlBillGroup.SelectedValue, BranchId, FId, ddlBank.SelectedItem.Text, txtRefBy.Text.Trim());

            Session.Add("rptsql", sql);
            Session["rptname"] = Server.MapPath("~/Reports/Rpt_UserWiseLabCashReportRadio.rpt");
            Session["reportname"] = "UserWiseLABCash_ReportRadio";
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