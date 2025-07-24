using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserwiseCashReportForProcedure : BasePage
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

    protected void Print_Click(object sender, EventArgs e)
    {
        string sql = "";
        BLLReports objreports = new BLLReports();
        try
        {

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
            objreports.FillProcedureIncomeReport(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), ddlUser.SelectedValue, Convert.ToInt32(RdbPayment.SelectedValue), ddlBillGroup.SelectedValue, BranchId, FId,ddlBank.SelectedItem.Text);

            Session.Add("rptsql", sql);
            Session["rptname"] = Server.MapPath("~/Reports/Rpt_UserWiseProcedureCashReport.rpt");
            Session["reportname"] = "UserWiseProcedureCash_Report";
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
            objreports.FillProcedureIncomeReport(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), ddlUser.SelectedValue, Convert.ToInt32(RdbPayment.SelectedValue), ddlBillGroup.SelectedValue, BranchId, FId,ddlBank.SelectedItem.Text);

            Session.Add("rptsql", sql);
            Session["rptname"] = Server.MapPath("~/Reports/Rpt_UserWiseProcedureCashReport.rpt");
            Session["reportname"] = "UserWiseProcedureCash_Report";
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