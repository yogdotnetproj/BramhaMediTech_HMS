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


public partial class LAB_ServiceWiseIncome : System.Web.UI.Page
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
            Diag.Visible = false;
            OPDPr.Visible = true;
            IPDPro.Visible = false;
            Phar.Visible = false;
            FillgridOPD();
           

        }

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        this.RdbServices_SelectedIndexChanged(null, null);
       
      //  objreports.FillLABIncomeReport(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), "0", Convert.ToInt32(0), "R", BranchId, FId, "Select Bank", "");
      //  objreports.FillLABIncomeReport_L(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), "0", Convert.ToInt32(0), "M", BranchId, FId, "Select Bank", "");

       
    }
    public void fillgrid()
    {
        Alterview();
        // AlterviewL();
        BLLReports objreports = new BLLReports();
        if (txtFrom.Text.ToString() != "")
        {
            ViewState["FromDate"] = txtFrom.Text.ToString();

        }
        else
        {
            ViewState["FromDate"] = "";
        }
        if (txtTo.Text.ToString() != "")
        {

            ViewState["ToDate"] = txtTo.Text.ToString();


        }
        else
        {
            ViewState["ToDate"] = "";
        }

        int BranchId = Convert.ToInt32(Session["BranchId"]);
        int FId = Convert.ToInt32(Session["FId"]);

       

        DataTable dt = new DataTable();
        dt = ObjDOReport.FillGroupwiseIncomeGrid_LAB(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), BranchId, FId);
        gvGroup.DataSource = dt;
        gvGroup.DataBind();
        if (dt.Rows.Count > 0)
        {
            double TotalAmt = dt.AsEnumerable().Sum(row => row.Field<double>("TotalCharges"));
            gvGroup.FooterRow.Cells[2].Text = "Total";
            gvGroup.FooterRow.Cells[2].HorizontalAlign = HorizontalAlign.Right;
            gvGroup.FooterRow.Cells[3].Text = TotalAmt.ToString("N2");
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
          ddlTimeTo.Items.Insert(0, new ListItem("24:00", "00:00"));
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
      DataTable dt=new DataTable ();
      dt = ObjDOReport.FillIncomeBillGroup(BranchId);
      GroupTyp.DataSource = dt;
      GroupTyp.DataValueField = "BillBroupId";
      GroupTyp.DataTextField = "BillGroupName";
      GroupTyp.DataBind();
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

    private void LoadRdbPaymentType()
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
                ViewState["FromDate"] = txtFrom.Text.ToString();

            }
            else
            {
                ViewState["FromDate"] = "";
            }
            if (txtTo.Text.ToString() != "")
            {

                ViewState["ToDate"] = txtTo.Text.ToString();


            }
            else
            {
                ViewState["ToDate"] = "";
            }
          
            int BranchId = Convert.ToInt32(Session["BranchId"]);
            int FId = Convert.ToInt32(Session["FId"]);
           // objreports.FillLABIncomeReport(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), "0", Convert.ToInt32(0), ddlBillGroup.SelectedValue, BranchId, FId, "","");
            DataTable dt = new DataTable();
            dt = ObjDOReport.FillGroupwiseIncomeGrid_LAB(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), BranchId, FId);

            Session.Add("rptsql", sql);
            Session["rptname"] = Server.MapPath("~/Reports/Rpt_LabServiceReport.rpt");
            Session["reportname"] = "LabServiceReport";
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
                ViewState["FromDate"] = txtFrom.Text.ToString();

            }
            else
            {
                ViewState["FromDate"] = "";
            }
            if (txtTo.Text.ToString() != "")
            {

                ViewState["ToDate"] = txtTo.Text.ToString();


            }
            else
            {
                ViewState["ToDate"] = "";
            }
          
            int BranchId = Convert.ToInt32(Session["BranchId"]);
            int FId = Convert.ToInt32(Session["FId"]);
           // objreports.FillLABIncomeReport(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), "0", Convert.ToInt32(0), ddlBillGroup.SelectedValue, BranchId, FId, "","");
            DataTable dt = new DataTable();
            dt = ObjDOReport.FillGroupwiseIncomeGrid_LAB(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), BranchId, FId);

            Session.Add("rptsql", sql);
            Session["rptname"] = Server.MapPath("~/Reports/Rpt_LabServiceReport.rpt");
            Session["reportname"] = "LabServiceReport";
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

    protected void gvGroup_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        BLLReports objreports = new BLLReports();
        string sql = "";
        if (e.CommandName == "Report")
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);

            GridViewRow row = gvGroup.Rows[rowIndex];
            string BillGroup = gvGroup.DataKeys[rowIndex].Values["BillGroup"].ToString();
            int BranchId = Convert.ToInt32(Session["Branchid"]);
            int FId = Convert.ToInt32(Session["FId"]);

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


            if (BillGroup == "Laboratory")
            {

                SqlConnection con1H = DataAccess.ConInitForMedical();
                // con1H.Open();
                string PatDB = con1H.Database;
                string query12 = "ALTER VIEW [dbo].[VW_LabWiseRevuenew] AS (SELECT   'OPD' as  CenterName,  count( LabRegistration.PatRegId) as NoOfPatient,  sum( LabServiceDetails.Qty) as Qty ,sum( LabServiceDetails.BillServiceCharges) AS TotalCharges, LabServiceDetails.FId, LabServiceDetails.BranchId, " +
                               " BillGroup.GroupName, " +
                               "  isnull(" + PatDB + ".dbo.SubDepartment.subdeptName,'') as subdeptName " +
                               //" FROM            LabServiceDetails INNER JOIN " +
                               //" BillGroup ON LabServiceDetails.BillGroup = BillGroup.BillGroupId INNER JOIN " +
                               //" LabRegistration ON LabServiceDetails.BillNo = LabRegistration.BillNo AND LabServiceDetails.LabNo = LabRegistration.LabNo AND LabServiceDetails.PatRegId = LabRegistration.PatRegId INNER JOIN " +
                               //" " + PatDB + ".dbo.MainTest ON LabServiceDetails.MTCode = " + PatDB + ".dbo.MainTest.MTCode INNER JOIN " +
                               //" " + PatDB + ".dbo.SubDepartment ON " + PatDB + ".dbo.MainTest.SDCode = " + PatDB + ".dbo.SubDepartment.SDCode " +
                               " FROM            " + PatDB + ".dbo.SubDepartment INNER JOIN " +
                               " " + PatDB + ".dbo.MainTest ON " + PatDB + ".dbo.SubDepartment.SDCode = " + PatDB + ".dbo.MainTest.SDCode RIGHT OUTER JOIN " +
                               " LabServiceDetails INNER JOIN " +
                               " BillGroup ON LabServiceDetails.BillGroup = BillGroup.BillGroupId INNER JOIN " +
                               " LabRegistration ON LabServiceDetails.BillNo = LabRegistration.BillNo AND LabServiceDetails.LabNo = LabRegistration.LabNo AND LabServiceDetails.PatRegId = LabRegistration.PatRegId ON " +
                               " " + PatDB + ".dbo.MainTest.MTCode = LabServiceDetails.MTCode " +

                               " WHERE     (LabRegistration.LabPtype = 'M') AND   (LabRegistration.CancelBill <> 1) AND (LabRegistration.BranchId = 1) AND (CAST(CAST(YEAR(LabRegistration.CreatedOn) AS varchar(4)) + '/' + CAST(MONTH(LabRegistration.CreatedOn) AS varchar(2)) " +
                               " + '/' + CAST(DAY(LabRegistration.CreatedOn) AS varchar(2)) AS datetime) BETWEEN '" + ViewState["FromDate"] + "'  and '" + ViewState["ToDate"] + "') " +
                               " group by LabServiceDetails.FId,  LabServiceDetails.BranchId, BillGroup.GroupName," + PatDB + ".dbo.SubDepartment.subdeptName union all " +//and YEAR(patmstd.Patregdate)=" + ddlYear.SelectedValue + " and Month(patmstd.Patregdate)=" + DdlMonth.SelectedValue + " ";
                               " SELECT 'IPD' as  CenterName,  count( IpdBillMaster.PatRegId) as NoOfPatient, sum( IpdBillServiceDetails.Qty) as Qty, " +
                               " SUM(IpdBillServiceDetails.TotalCharges) AS TotalCharges,IpdBillServiceDetails.FId, IpdBillServiceDetails.BranchId,  BillGroup.GroupName, " +
                               " isnull(" + PatDB + ".dbo.SubDepartment.subdeptName,'') as subdeptName  FROM            IpdBillServiceDetails LEFT OUTER JOIN " +
                               " " + PatDB + ".dbo.MainTest ON IpdBillServiceDetails.MTCode = " + PatDB + ".dbo.MainTest.MTCode LEFT OUTER JOIN " +
                               " " + PatDB + ".dbo.SubDepartment ON " + PatDB + ".dbo.MainTest.SDCode = " + PatDB + ".dbo.SubDepartment.SDCode LEFT OUTER JOIN " +
                               " IpdBillMaster ON IpdBillServiceDetails.PatRegId = IpdBillMaster.PatRegId AND IpdBillServiceDetails.IpdNo = IpdBillMaster.IpdNo LEFT OUTER JOIN " +
                               " BillGroup ON IpdBillServiceDetails.BillGroupId = BillGroup.BillGroupId where IpdBillMaster.IsDischarge=1  and  " +
                               " IpdBillServiceDetails.FId=1 and IpdBillServiceDetails.BranchId=1 and IpdBillServiceDetails.BillGroupId =16 " +
                               " AND (CAST(CAST(YEAR(IpdBillMaster.FinalDischargeOn) AS varchar(4)) + '/' + CAST(MONTH(IpdBillMaster.FinalDischargeOn) AS varchar(2)) " +
                               " + '/' + CAST(DAY(IpdBillMaster.FinalDischargeOn) AS varchar(2)) AS datetime) BETWEEN '" + ViewState["FromDate"] + "'  and '" + ViewState["ToDate"] + "') GROUP BY BillGroup.GroupName, IpdBillServiceDetails.BillGroupId, IpdBillServiceDetails.FId, IpdBillServiceDetails.BranchId," + PatDB + ".dbo.SubDepartment.subdeptName ";


                SqlConnection con12 = DataAccess.ConInitForDC();
                SqlCommand cmd112 = con12.CreateCommand();
                cmd112.CommandText = query12 + ")";
                con12.Open();
                cmd112.ExecuteNonQuery();
                con12.Close(); con12.Dispose();

                string query1 = "ALTER VIEW [dbo].[VW_LabWiseRevuenewwithservice] AS (SELECT    'OPD' as  CenterName, LabServiceDetails.Qty, LabServiceDetails.BillServiceCharges AS TotalCharges, LabServiceDetails.FId, LabServiceDetails.BranchId, BillGroup.GroupName, LabServiceDetails.ServiceName, " +
                               "   isnull(" + PatDB + ".dbo.SubDepartment.subdeptName,'') as subdeptName, PatientInformation.FirstName, Gender.GenderName, PatientInformation.MobileNo, PatientInformation.PhoneNo, PatientInformation.PatientAddress, LabRegistration.ReferenceDoc, " +
                               "  LabRegistration.ReferBy, LabRegistration.LabNo, LabRegistration.BillNo, LabRegistration.PatRegId, LabRegistration.Entrydate " +
                               " FROM            PatientInformation INNER JOIN " +
                               " LabServiceDetails INNER JOIN " +
                               " BillGroup ON LabServiceDetails.BillGroup = BillGroup.BillGroupId INNER JOIN " +
                               " LabRegistration ON LabServiceDetails.BillNo = LabRegistration.BillNo AND LabServiceDetails.LabNo = LabRegistration.LabNo AND LabServiceDetails.PatRegId = LabRegistration.PatRegId ON " +
                               " PatientInformation.PatRegId = LabRegistration.PatRegId INNER JOIN " +
                               " Gender ON PatientInformation.GenderId = Gender.GenderId LEFT OUTER JOIN " +
                               " " + PatDB + ".dbo.SubDepartment LEFT OUTER JOIN " +
                               " " + PatDB + ".dbo.MainTest ON " + PatDB + ".dbo.SubDepartment.SDCode = " + PatDB + ".dbo.MainTest.SDCode ON LabServiceDetails.MTCode = " + PatDB + ".dbo.MainTest.MTCode " +
                                " WHERE      (LabRegistration.LabPtype = 'M') AND (LabRegistration.CancelBill <> 1) AND (LabRegistration.BranchId = 1) AND (CAST(CAST(YEAR(LabRegistration.CreatedOn) AS varchar(4)) + '/' + CAST(MONTH(LabRegistration.CreatedOn) AS varchar(2)) " +
                               " + '/' + CAST(DAY(LabRegistration.CreatedOn) AS varchar(2)) AS datetime) BETWEEN '" + ViewState["FromDate"] + "'  and '" + ViewState["ToDate"] + "') union all SELECT        'IPD' AS CenterName, IpdBillServiceDetails.Qty, IpdBillServiceDetails.TotalCharges, IpdBillServiceDetails.FId, IpdBillServiceDetails.BranchId, BillGroup.GroupName, " +
                               "  IpdBillServiceDetails.ServiceName, " +
                               " isnull(" + PatDB + ".dbo.SubDepartment.subdeptName,'') as subdeptName, PatientInformation.FirstName, Gender.GenderName, PatientInformation.MobileNo, PatientInformation.PhoneNo, PatientInformation.PatientAddress, " +
                               "  IpdBillServiceDetails.MainDoctor,IpdBillServiceDetails.MainDoctor, " +
                               "  IpdBillServiceDetails.LabNo,  " +
                               "  IpdBillServiceDetails.BillNo, IpdBillServiceDetails.PatRegId,IpdBillServiceDetails.CreatedOn " +
                               " FROM            BillGroup INNER JOIN " +
                               " IpdBillMaster INNER JOIN " +
                               " IpdBillServiceDetails INNER JOIN " +
                               " PatientInformation ON IpdBillServiceDetails.PatRegId = PatientInformation.PatRegId ON IpdBillMaster.IpdNo = IpdBillServiceDetails.IpdNo AND IpdBillMaster.PatRegId = IpdBillServiceDetails.PatRegId ON " +
                               " BillGroup.BillGroupId = IpdBillServiceDetails.BillGroupId LEFT OUTER JOIN " +
                               " Gender ON PatientInformation.GenderId = Gender.GenderId LEFT OUTER JOIN " +
                               " " + PatDB + ".dbo.SubDepartment LEFT OUTER JOIN " +
                               " " + PatDB + ".dbo.MainTest ON " + PatDB + ".dbo.SubDepartment.SDCode = " + PatDB + ".dbo.MainTest.SDCode ON IpdBillServiceDetails.MTCode = " + PatDB + ".dbo.MainTest.MTCode " +
                               " WHERE        (IpdBillServiceDetails.BillGroupId = 16) AND (IpdBillServiceDetails.IsDischarge <> 0) AND (IpdBillServiceDetails.BranchId = 1) AND (CAST(CAST(YEAR(IpdBillMaster.FinalDischargeOn) AS varchar(4)) " +
                               " + '/' + CAST(MONTH(IpdBillMaster.FinalDischargeOn) AS varchar(2)) + '/' + CAST(DAY(IpdBillMaster.FinalDischargeOn) AS varchar(2)) AS datetime) BETWEEN '" + ViewState["FromDate"] + "'  and '" + ViewState["ToDate"] + "') ";
                //"  ";//and YEAR(patmstd.Patregdate)=" + ddlYear.SelectedValue + " and Month(patmstd.Patregdate)=" + DdlMonth.SelectedValue + " ";

                SqlConnection con1 = DataAccess.ConInitForDC();
                SqlCommand cmd11 = con1.CreateCommand();
                cmd11.CommandText = query1 + ")";
                con1.Open();
                cmd11.ExecuteNonQuery();
                con1.Close(); con1.Dispose();


                //  objreports.PatientwiseBillGroupIncome_Procedure(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), BillGroup, FId, BranchId);

                Session.Add("rptsql", sql);
                Session["rptname"] = Server.MapPath("~/Reports/Rpt_LABServiceIncomeReport.rpt");
                Session["reportname"] = "LABServiceIncomeReport";
                Session["RPTFORMAT"] = "pdf";


                string close = "<script language='javascript'>javascript:OpenReport();</script>";
                Type title1 = this.GetType();
                Page.ClientScript.RegisterStartupScript(title1, "", close);
            }

            if (BillGroup == "Radiology")
            {
                SqlConnection con1H = DataAccess.ConInitForRadiology();
                // con1H.Open();
                string PatDB = con1H.Database;
                //string query12 = "ALTER VIEW [dbo].[VW_LabWiseRevuenew] AS (SELECT   'OPD' as  CenterName,  count( LabRegistration.PatRegId) as NoOfPatient,  sum( LabServiceDetails.Qty) as Qty ,sum( LabServiceDetails.BillServiceCharges) AS TotalCharges, LabServiceDetails.FId, LabServiceDetails.BranchId, " +
                //               " BillGroup.GroupName, " +
                //               " " + PatDB + ".dbo.SubDepartment.subdeptName " +
                //               " FROM            LabServiceDetails INNER JOIN " +
                //               " BillGroup ON LabServiceDetails.BillGroup = BillGroup.BillGroupId INNER JOIN " +
                //               " LabRegistration ON LabServiceDetails.BillNo = LabRegistration.BillNo AND LabServiceDetails.LabNo = LabRegistration.LabNo AND LabServiceDetails.PatRegId = LabRegistration.PatRegId INNER JOIN " +
                //               " " + PatDB + ".dbo.MainTest ON LabServiceDetails.MTCode = " + PatDB + ".dbo.MainTest.MTCode INNER JOIN " +
                //               " " + PatDB + ".dbo.SubDepartment ON " + PatDB + ".dbo.MainTest.SDCode = " + PatDB + ".dbo.SubDepartment.SDCode " +
                //               " WHERE        (LabRegistration.CancelBill <> 1) AND (LabRegistration.BranchId = 1) AND (CAST(CAST(YEAR(LabRegistration.CreatedOn) AS varchar(4)) + '/' + CAST(MONTH(LabRegistration.CreatedOn) AS varchar(2)) " +
                //               " + '/' + CAST(DAY(LabRegistration.CreatedOn) AS varchar(2)) AS datetime) BETWEEN '" + ViewState["FromDate"] + "'  and '" + ViewState["ToDate"] + "') " +
                //               " group by LabServiceDetails.FId,  LabServiceDetails.BranchId, BillGroup.GroupName," + PatDB + ".dbo.SubDepartment.subdeptName ";//and YEAR(patmstd.Patregdate)=" + ddlYear.SelectedValue + " and Month(patmstd.Patregdate)=" + DdlMonth.SelectedValue + " ";
                string query12 = "ALTER VIEW [dbo].[VW_LabWiseRevuenew] AS (SELECT   'OPD' as  CenterName,  count( LabRegistration.PatRegId) as NoOfPatient,  sum( LabServiceDetails.Qty) as Qty ,sum( LabServiceDetails.BillServiceCharges) AS TotalCharges, LabServiceDetails.FId, LabServiceDetails.BranchId, " +
                               " BillGroup.GroupName, " +
                               "  isnull(" + PatDB + ".dbo.SubDepartment.subdeptName,'') as subdeptName " +
                               //" FROM            LabServiceDetails INNER JOIN " +
                               //" BillGroup ON LabServiceDetails.BillGroup = BillGroup.BillGroupId INNER JOIN " +
                               //" LabRegistration ON LabServiceDetails.BillNo = LabRegistration.BillNo AND LabServiceDetails.LabNo = LabRegistration.LabNo AND LabServiceDetails.PatRegId = LabRegistration.PatRegId INNER JOIN " +
                               //" " + PatDB + ".dbo.MainTest ON LabServiceDetails.MTCode = " + PatDB + ".dbo.MainTest.MTCode INNER JOIN " +
                               //" " + PatDB + ".dbo.SubDepartment ON " + PatDB + ".dbo.MainTest.SDCode = " + PatDB + ".dbo.SubDepartment.SDCode " +
                                " FROM            " + PatDB + ".dbo.SubDepartment INNER JOIN " +
                               " " + PatDB + ".dbo.MainTest ON " + PatDB + ".dbo.SubDepartment.SDCode = " + PatDB + ".dbo.MainTest.SDCode RIGHT OUTER JOIN " +
                               " LabServiceDetails INNER JOIN " +
                               " BillGroup ON LabServiceDetails.BillGroup = BillGroup.BillGroupId INNER JOIN " +
                               " LabRegistration ON LabServiceDetails.BillNo = LabRegistration.BillNo AND LabServiceDetails.LabNo = LabRegistration.LabNo AND LabServiceDetails.PatRegId = LabRegistration.PatRegId ON " +
                               " " + PatDB + ".dbo.MainTest.MTCode = LabServiceDetails.MTCode " +

                               " WHERE        (LabRegistration.LabPtype = 'R') AND (LabRegistration.CancelBill <> 1) AND (LabRegistration.BranchId = 1) AND (CAST(CAST(YEAR(LabRegistration.CreatedOn) AS varchar(4)) + '/' + CAST(MONTH(LabRegistration.CreatedOn) AS varchar(2)) " +
                               " + '/' + CAST(DAY(LabRegistration.CreatedOn) AS varchar(2)) AS datetime) BETWEEN '" + ViewState["FromDate"] + "'  and '" + ViewState["ToDate"] + "') " +
                               " group by LabServiceDetails.FId,  LabServiceDetails.BranchId, BillGroup.GroupName," + PatDB + ".dbo.SubDepartment.subdeptName union all " +//and YEAR(patmstd.Patregdate)=" + ddlYear.SelectedValue + " and Month(patmstd.Patregdate)=" + DdlMonth.SelectedValue + " ";
                               " SELECT 'IPD' as  CenterName,  count( IpdBillMaster.PatRegId) as NoOfPatient, sum( IpdBillServiceDetails.Qty) as Qty, " +
                               " SUM(IpdBillServiceDetails.TotalCharges) AS TotalCharges,IpdBillServiceDetails.FId, IpdBillServiceDetails.BranchId,  BillGroup.GroupName, " +
                               " isnull(" + PatDB + ".dbo.SubDepartment.subdeptName,'') as subdeptName  FROM            IpdBillServiceDetails LEFT OUTER JOIN " +
                               " " + PatDB + ".dbo.MainTest ON IpdBillServiceDetails.MTCode = " + PatDB + ".dbo.MainTest.MTCode LEFT OUTER JOIN" +
                               " " + PatDB + ".dbo.SubDepartment ON " + PatDB + ".dbo.MainTest.SDCode = " + PatDB + ".dbo.SubDepartment.SDCode LEFT OUTER JOIN " +
                               " IpdBillMaster ON IpdBillServiceDetails.PatRegId = IpdBillMaster.PatRegId AND IpdBillServiceDetails.IpdNo = IpdBillMaster.IpdNo LEFT OUTER JOIN " +
                               " BillGroup ON IpdBillServiceDetails.BillGroupId = BillGroup.BillGroupId where IpdBillMaster.IsDischarge=1  and  " +
                               " IpdBillServiceDetails.FId=1 and IpdBillServiceDetails.BranchId=1 and IpdBillServiceDetails.BillGroupId =20 " +
                               " AND (CAST(CAST(YEAR(IpdBillMaster.FinalDischargeOn) AS varchar(4)) + '/' + CAST(MONTH(IpdBillMaster.FinalDischargeOn) AS varchar(2)) " +
                               " + '/' + CAST(DAY(IpdBillMaster.FinalDischargeOn) AS varchar(2)) AS datetime) BETWEEN '" + ViewState["FromDate"] + "'  and '" + ViewState["ToDate"] + "') GROUP BY BillGroup.GroupName, IpdBillServiceDetails.BillGroupId, IpdBillServiceDetails.FId, IpdBillServiceDetails.BranchId," + PatDB + ".dbo.SubDepartment.subdeptName ";


                SqlConnection con12 = DataAccess.ConInitForDC();
                SqlCommand cmd112 = con12.CreateCommand();
                cmd112.CommandText = query12 + ")";
                con12.Open();
                cmd112.ExecuteNonQuery();
                con12.Close(); con12.Dispose();


                string query1 = "ALTER VIEW [dbo].[VW_LabWiseRevuenewwithservice] AS (SELECT    'OPD' as  CenterName, LabServiceDetails.Qty, LabServiceDetails.BillServiceCharges AS TotalCharges, LabServiceDetails.FId, LabServiceDetails.BranchId, BillGroup.GroupName, LabServiceDetails.ServiceName, " +
                              "   isnull(" + PatDB + ".dbo.SubDepartment.subdeptName,'') as subdeptName, PatientInformation.FirstName, Gender.GenderName, PatientInformation.MobileNo, PatientInformation.PhoneNo, PatientInformation.PatientAddress, LabRegistration.ReferenceDoc, " +
                               "  LabRegistration.ReferBy, LabRegistration.LabNo, LabRegistration.BillNo, LabRegistration.PatRegId, LabRegistration.Entrydate " +
                               " FROM            PatientInformation INNER JOIN " +
                               " LabServiceDetails INNER JOIN " +
                               " BillGroup ON LabServiceDetails.BillGroup = BillGroup.BillGroupId INNER JOIN " +
                               " LabRegistration ON LabServiceDetails.BillNo = LabRegistration.BillNo AND LabServiceDetails.LabNo = LabRegistration.LabNo AND LabServiceDetails.PatRegId = LabRegistration.PatRegId ON " +
                               " PatientInformation.PatRegId = LabRegistration.PatRegId INNER JOIN " +
                               " Gender ON PatientInformation.GenderId = Gender.GenderId LEFT OUTER JOIN " +
                               " " + PatDB + ".dbo.SubDepartment LEFT OUTER JOIN " +
                               " " + PatDB + ".dbo.MainTest ON " + PatDB + ".dbo.SubDepartment.SDCode = " + PatDB + ".dbo.MainTest.SDCode ON LabServiceDetails.MTCode = " + PatDB + ".dbo.MainTest.MTCode " +
                               " WHERE      (LabRegistration.LabPtype = 'R') AND  (LabRegistration.CancelBill <> 1) AND (LabRegistration.BranchId = 1) AND (CAST(CAST(YEAR(LabRegistration.CreatedOn) AS varchar(4)) + '/' + CAST(MONTH(LabRegistration.CreatedOn) AS varchar(2)) " +
                             " + '/' + CAST(DAY(LabRegistration.CreatedOn) AS varchar(2)) AS datetime) BETWEEN '" + ViewState["FromDate"] + "'  and '" + ViewState["ToDate"] + "') union all SELECT        'IPD' AS CenterName, IpdBillServiceDetails.Qty, IpdBillServiceDetails.TotalCharges, IpdBillServiceDetails.FId, IpdBillServiceDetails.BranchId, BillGroup.GroupName, " +
                             "  IpdBillServiceDetails.ServiceName, " +
                             "  isnull(" + PatDB + ".dbo.SubDepartment.subdeptName,'') as subdeptName,  PatientInformation.FirstName, Gender.GenderName, PatientInformation.MobileNo, PatientInformation.PhoneNo, PatientInformation.PatientAddress, " +
                             "  IpdBillServiceDetails.MainDoctor,IpdBillServiceDetails.MainDoctor, " +
                             "  IpdBillServiceDetails.LabNo,  " +
                             "  IpdBillServiceDetails.BillNo, IpdBillServiceDetails.PatRegId,IpdBillServiceDetails.CreatedOn " +
                            " FROM            BillGroup INNER JOIN " +
                               " IpdBillMaster INNER JOIN " +
                               " IpdBillServiceDetails INNER JOIN " +
                               " PatientInformation ON IpdBillServiceDetails.PatRegId = PatientInformation.PatRegId ON IpdBillMaster.IpdNo = IpdBillServiceDetails.IpdNo AND IpdBillMaster.PatRegId = IpdBillServiceDetails.PatRegId ON " +
                               " BillGroup.BillGroupId = IpdBillServiceDetails.BillGroupId LEFT OUTER JOIN " +
                               " Gender ON PatientInformation.GenderId = Gender.GenderId LEFT OUTER JOIN " +
                               " " + PatDB + ".dbo.SubDepartment LEFT OUTER JOIN " +
                               " " + PatDB + ".dbo.MainTest ON " + PatDB + ".dbo.SubDepartment.SDCode = " + PatDB + ".dbo.MainTest.SDCode ON IpdBillServiceDetails.MTCode = " + PatDB + ".dbo.MainTest.MTCode " +
                               " WHERE        (IpdBillServiceDetails.BillGroupId = 20) AND (IpdBillServiceDetails.IsDischarge <> 0) AND (IpdBillServiceDetails.BranchId = 1) AND (CAST(CAST(YEAR(IpdBillMaster.FinalDischargeOn) AS varchar(4)) " +
                               " + '/' + CAST(MONTH(IpdBillMaster.FinalDischargeOn) AS varchar(2)) + '/' + CAST(DAY(IpdBillMaster.FinalDischargeOn) AS varchar(2)) AS datetime) BETWEEN '" + ViewState["FromDate"] + "'  and '" + ViewState["ToDate"] + "') ";
                //"  ";//and YEAR(patmstd.Patregdate)=" + ddlYear.SelectedValue + " and Month(patmstd.Patregdate)=" + DdlMonth.SelectedValue + " ";


                SqlConnection con1 = DataAccess.ConInitForDC();
                SqlCommand cmd11 = con1.CreateCommand();
                cmd11.CommandText = query1 + ")";
                con1.Open();
                cmd11.ExecuteNonQuery();
                con1.Close(); con1.Dispose();
                // objreports.PatientwiseBillGroupIncome_Procedure(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), BillGroup, FId, BranchId);

                Session.Add("rptsql", sql);
                Session["rptname"] = Server.MapPath("~/Reports/Rpt_LABServiceIncomeReport.rpt");
                Session["reportname"] = "LABServiceIncomeReport";
                Session["RPTFORMAT"] = "pdf";

                string close = "<script language='javascript'>javascript:OpenReport();</script>";
                Type title1 = this.GetType();
                Page.ClientScript.RegisterStartupScript(title1, "", close);
            }
            if (BillGroup == "Pathology")
            {
                SqlConnection con1H = DataAccess.ConInitForPathology();
                // con1H.Open();
                string PatDB = con1H.Database;
                string query12 = "ALTER VIEW [dbo].[VW_LabWiseRevuenew] AS (SELECT   'OPD' as  CenterName,  count( LabRegistration.PatRegId) as NoOfPatient,  sum( LabServiceDetails.Qty) as Qty ,sum( LabServiceDetails.BillServiceCharges) AS TotalCharges, LabServiceDetails.FId, LabServiceDetails.BranchId, " +
                                " BillGroup.GroupName, " +
                                "  isnull(" + PatDB + ".dbo.SubDepartment.subdeptName,'') as subdeptName " +
                                //" FROM            LabServiceDetails INNER JOIN " +
                                //" BillGroup ON LabServiceDetails.BillGroup = BillGroup.BillGroupId INNER JOIN " +
                                //" LabRegistration ON LabServiceDetails.BillNo = LabRegistration.BillNo AND LabServiceDetails.LabNo = LabRegistration.LabNo AND LabServiceDetails.PatRegId = LabRegistration.PatRegId INNER JOIN " +
                                //" " + PatDB + ".dbo.MainTest ON LabServiceDetails.MTCode = " + PatDB + ".dbo.MainTest.MTCode INNER JOIN " +
                                //" " + PatDB + ".dbo.SubDepartment ON " + PatDB + ".dbo.MainTest.SDCode = " + PatDB + ".dbo.SubDepartment.SDCode " +
                                 " FROM            " + PatDB + ".dbo.SubDepartment INNER JOIN " +
                               " " + PatDB + ".dbo.MainTest ON " + PatDB + ".dbo.SubDepartment.SDCode = " + PatDB + ".dbo.MainTest.SDCode RIGHT OUTER JOIN " +
                               " LabServiceDetails INNER JOIN " +
                               " BillGroup ON LabServiceDetails.BillGroup = BillGroup.BillGroupId INNER JOIN " +
                               " LabRegistration ON LabServiceDetails.BillNo = LabRegistration.BillNo AND LabServiceDetails.LabNo = LabRegistration.LabNo AND LabServiceDetails.PatRegId = LabRegistration.PatRegId ON " +
                               " " + PatDB + ".dbo.MainTest.MTCode = LabServiceDetails.MTCode " +

                                " WHERE       (LabRegistration.LabPtype = 'P') AND  (LabRegistration.CancelBill <> 1) AND (LabRegistration.BranchId = 1) AND (CAST(CAST(YEAR(LabRegistration.CreatedOn) AS varchar(4)) + '/' + CAST(MONTH(LabRegistration.CreatedOn) AS varchar(2)) " +
                                " + '/' + CAST(DAY(LabRegistration.CreatedOn) AS varchar(2)) AS datetime) BETWEEN '" + ViewState["FromDate"] + "'  and '" + ViewState["ToDate"] + "') " +
                                " group by LabServiceDetails.FId,  LabServiceDetails.BranchId, BillGroup.GroupName," + PatDB + ".dbo.SubDepartment.subdeptName union all " +//and YEAR(patmstd.Patregdate)=" + ddlYear.SelectedValue + " and Month(patmstd.Patregdate)=" + DdlMonth.SelectedValue + " ";
                                " SELECT 'IPD' as  CenterName,  count( IpdBillMaster.PatRegId) as NoOfPatient, sum( IpdBillServiceDetails.Qty) as Qty, " +
                                " SUM(IpdBillServiceDetails.TotalCharges) AS TotalCharges,IpdBillServiceDetails.FId, IpdBillServiceDetails.BranchId,  BillGroup.GroupName, " +
                                " isnull(" + PatDB + ".dbo.SubDepartment.subdeptName,'') as subdeptName  FROM            IpdBillServiceDetails LEFT OUTER JOIN" +
                                " " + PatDB + ".dbo.MainTest ON IpdBillServiceDetails.MTCode = " + PatDB + ".dbo.MainTest.MTCode LEFT OUTER JOIN " +
                                " " + PatDB + ".dbo.SubDepartment ON " + PatDB + ".dbo.MainTest.SDCode = " + PatDB + ".dbo.SubDepartment.SDCode LEFT OUTER JOIN " +
                                " IpdBillMaster ON IpdBillServiceDetails.PatRegId = IpdBillMaster.PatRegId AND IpdBillServiceDetails.IpdNo = IpdBillMaster.IpdNo LEFT OUTER JOIN " +
                                " BillGroup ON IpdBillServiceDetails.BillGroupId = BillGroup.BillGroupId where IpdBillMaster.IsDischarge=1  and  " +
                                " IpdBillServiceDetails.FId=1 and IpdBillServiceDetails.BranchId=1 and IpdBillServiceDetails.BillGroupId =19 " +
                                " AND (CAST(CAST(YEAR(IpdBillMaster.FinalDischargeOn) AS varchar(4)) + '/' + CAST(MONTH(IpdBillMaster.FinalDischargeOn) AS varchar(2)) " +
                                " + '/' + CAST(DAY(IpdBillMaster.FinalDischargeOn) AS varchar(2)) AS datetime) BETWEEN '" + ViewState["FromDate"] + "'  and '" + ViewState["ToDate"] + "') GROUP BY BillGroup.GroupName, IpdBillServiceDetails.BillGroupId, IpdBillServiceDetails.FId, IpdBillServiceDetails.BranchId," + PatDB + ".dbo.SubDepartment.subdeptName ";

                SqlConnection con12 = DataAccess.ConInitForDC();
                SqlCommand cmd112 = con12.CreateCommand();
                cmd112.CommandText = query12 + ")";
                con12.Open();
                cmd112.ExecuteNonQuery();
                con12.Close(); con12.Dispose();


                string query1 = "ALTER VIEW [dbo].[VW_LabWiseRevuenewwithservice] AS (SELECT    'OPD' as  CenterName, LabServiceDetails.Qty, LabServiceDetails.BillServiceCharges AS TotalCharges, LabServiceDetails.FId, LabServiceDetails.BranchId, BillGroup.GroupName, LabServiceDetails.ServiceName, " +
                                "   isnull(" + PatDB + ".dbo.SubDepartment.subdeptName,'') as subdeptName, PatientInformation.FirstName, Gender.GenderName, PatientInformation.MobileNo, PatientInformation.PhoneNo, PatientInformation.PatientAddress, LabRegistration.ReferenceDoc, " +
                               "  LabRegistration.ReferBy, LabRegistration.LabNo, LabRegistration.BillNo, LabRegistration.PatRegId, LabRegistration.Entrydate " +
                               " FROM            PatientInformation INNER JOIN " +
                               " LabServiceDetails INNER JOIN " +
                               " BillGroup ON LabServiceDetails.BillGroup = BillGroup.BillGroupId INNER JOIN " +
                               " LabRegistration ON LabServiceDetails.BillNo = LabRegistration.BillNo AND LabServiceDetails.LabNo = LabRegistration.LabNo AND LabServiceDetails.PatRegId = LabRegistration.PatRegId ON " +
                               " PatientInformation.PatRegId = LabRegistration.PatRegId INNER JOIN " +
                               " Gender ON PatientInformation.GenderId = Gender.GenderId LEFT OUTER JOIN " +
                               " " + PatDB + ".dbo.SubDepartment LEFT OUTER JOIN " +
                               " " + PatDB + ".dbo.MainTest ON " + PatDB + ".dbo.SubDepartment.SDCode = " + PatDB + ".dbo.MainTest.SDCode ON LabServiceDetails.MTCode = " + PatDB + ".dbo.MainTest.MTCode " +
                               " WHERE      (LabRegistration.LabPtype = 'P') AND   (LabRegistration.CancelBill <> 1) AND (LabRegistration.BranchId = 1) AND (CAST(CAST(YEAR(LabRegistration.CreatedOn) AS varchar(4)) + '/' + CAST(MONTH(LabRegistration.CreatedOn) AS varchar(2)) " +
                              " + '/' + CAST(DAY(LabRegistration.CreatedOn) AS varchar(2)) AS datetime) BETWEEN '" + ViewState["FromDate"] + "'  and '" + ViewState["ToDate"] + "') union all SELECT        'IPD' AS CenterName, IpdBillServiceDetails.Qty, IpdBillServiceDetails.TotalCharges, IpdBillServiceDetails.FId, IpdBillServiceDetails.BranchId, BillGroup.GroupName, " +
                              "  IpdBillServiceDetails.ServiceName, " +
                              "  isnull(" + PatDB + ".dbo.SubDepartment.subdeptName,'') as subdeptName,  PatientInformation.FirstName, Gender.GenderName, PatientInformation.MobileNo, PatientInformation.PhoneNo, PatientInformation.PatientAddress, " +
                              "  IpdBillServiceDetails.MainDoctor,IpdBillServiceDetails.MainDoctor, " +
                              "  IpdBillServiceDetails.LabNo,  " +
                              "  IpdBillServiceDetails.BillNo, IpdBillServiceDetails.PatRegId,IpdBillServiceDetails.CreatedOn " +
                                " FROM            BillGroup INNER JOIN " +
                               " IpdBillMaster INNER JOIN " +
                               " IpdBillServiceDetails INNER JOIN " +
                               " PatientInformation ON IpdBillServiceDetails.PatRegId = PatientInformation.PatRegId ON IpdBillMaster.IpdNo = IpdBillServiceDetails.IpdNo AND IpdBillMaster.PatRegId = IpdBillServiceDetails.PatRegId ON " +
                               " BillGroup.BillGroupId = IpdBillServiceDetails.BillGroupId LEFT OUTER JOIN " +
                               " Gender ON PatientInformation.GenderId = Gender.GenderId LEFT OUTER JOIN " +
                               " " + PatDB + ".dbo.SubDepartment LEFT OUTER JOIN " +
                               " " + PatDB + ".dbo.MainTest ON " + PatDB + ".dbo.SubDepartment.SDCode = " + PatDB + ".dbo.MainTest.SDCode ON IpdBillServiceDetails.MTCode = " + PatDB + ".dbo.MainTest.MTCode " +
                               " WHERE        (IpdBillServiceDetails.BillGroupId = 19) AND (IpdBillServiceDetails.IsDischarge <> 0) AND (IpdBillServiceDetails.BranchId = 1) AND (CAST(CAST(YEAR(IpdBillMaster.FinalDischargeOn) AS varchar(4)) " +
                               " + '/' + CAST(MONTH(IpdBillMaster.FinalDischargeOn) AS varchar(2)) + '/' + CAST(DAY(IpdBillMaster.FinalDischargeOn) AS varchar(2)) AS datetime) BETWEEN '" + ViewState["FromDate"] + "'  and '" + ViewState["ToDate"] + "') ";
                //"  ";//and YEAR(patmstd.Patregdate)=" + ddlYear.SelectedValue + " and Month(patmstd.Patregdate)=" + DdlMonth.SelectedValue + " ";

                SqlConnection con1 = DataAccess.ConInitForDC();
                SqlCommand cmd11 = con1.CreateCommand();
                cmd11.CommandText = query1 + ")";
                con1.Open();
                cmd11.ExecuteNonQuery();
                con1.Close(); con1.Dispose();
                // objreports.PatientwiseBillGroupIncome_Procedure(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), BillGroup, FId, BranchId);

                Session.Add("rptsql", sql);
                Session["rptname"] = Server.MapPath("~/Reports/Rpt_LABServiceIncomeReport.rpt");
                Session["reportname"] = "LABServiceIncomeReport";
                Session["RPTFORMAT"] = "pdf";

                string close = "<script language='javascript'>javascript:OpenReport();</script>";
                Type title1 = this.GetType();
                Page.ClientScript.RegisterStartupScript(title1, "", close);
            }
        }

        if (e.CommandName == "ReportExcel")
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);

            GridViewRow row = gvGroup.Rows[rowIndex];
            string BillGroup = gvGroup.DataKeys[rowIndex].Values["BillGroup"].ToString();
            int BranchId = Convert.ToInt32(Session["Branchid"]);
            int FId = Convert.ToInt32(Session["FId"]);

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


            if (BillGroup == "Laboratory")
            {

                SqlConnection con1H = DataAccess.ConInitForMedical();
                // con1H.Open();
                string PatDB = con1H.Database;
                string query12 = "ALTER VIEW [dbo].[VW_LabWiseRevuenew] AS (SELECT   'OPD' as  CenterName,  count( LabRegistration.PatRegId) as NoOfPatient,  sum( LabServiceDetails.Qty) as Qty ,sum( LabServiceDetails.BillServiceCharges) AS TotalCharges, LabServiceDetails.FId, LabServiceDetails.BranchId, " +
                               " BillGroup.GroupName, " +
                               " " + PatDB + ".dbo.SubDepartment.subdeptName " +
                               " FROM            LabServiceDetails INNER JOIN " +
                               " BillGroup ON LabServiceDetails.BillGroup = BillGroup.BillGroupId INNER JOIN " +
                               " LabRegistration ON LabServiceDetails.BillNo = LabRegistration.BillNo AND LabServiceDetails.LabNo = LabRegistration.LabNo AND LabServiceDetails.PatRegId = LabRegistration.PatRegId INNER JOIN " +
                               " " + PatDB + ".dbo.MainTest ON LabServiceDetails.MTCode = " + PatDB + ".dbo.MainTest.MTCode INNER JOIN " +
                               " " + PatDB + ".dbo.SubDepartment ON " + PatDB + ".dbo.MainTest.SDCode = " + PatDB + ".dbo.SubDepartment.SDCode " +
                               " WHERE        (LabRegistration.CancelBill <> 1) AND (LabRegistration.BranchId = 1) AND (CAST(CAST(YEAR(LabRegistration.CreatedOn) AS varchar(4)) + '/' + CAST(MONTH(LabRegistration.CreatedOn) AS varchar(2)) " +
                               " + '/' + CAST(DAY(LabRegistration.CreatedOn) AS varchar(2)) AS datetime) BETWEEN '" + ViewState["FromDate"] + "'  and '" + ViewState["ToDate"] + "') " +
                               " group by LabServiceDetails.FId,  LabServiceDetails.BranchId, BillGroup.GroupName," + PatDB + ".dbo.SubDepartment.subdeptName union all " +//and YEAR(patmstd.Patregdate)=" + ddlYear.SelectedValue + " and Month(patmstd.Patregdate)=" + DdlMonth.SelectedValue + " ";
                               " SELECT 'IPD' as  CenterName,  count( IpdBillMaster.PatRegId) as NoOfPatient, sum( IpdBillServiceDetails.Qty) as Qty, " +
                               " SUM(IpdBillServiceDetails.TotalCharges) AS TotalCharges,IpdBillServiceDetails.FId, IpdBillServiceDetails.BranchId,  BillGroup.GroupName, " +
                               " isnull(" + PatDB + ".dbo.SubDepartment.subdeptName,'') as subdeptName  FROM            IpdBillServiceDetails LEFT OUTER JOIN " +
                               " " + PatDB + ".dbo.MainTest ON IpdBillServiceDetails.MTCode = " + PatDB + ".dbo.MainTest.MTCode LEFT OUTER JOIN " +
                               " " + PatDB + ".dbo.SubDepartment ON " + PatDB + ".dbo.MainTest.SDCode = " + PatDB + ".dbo.SubDepartment.SDCode LEFT OUTER JOIN " +
                               " IpdBillMaster ON IpdBillServiceDetails.PatRegId = IpdBillMaster.PatRegId AND IpdBillServiceDetails.IpdNo = IpdBillMaster.IpdNo LEFT OUTER JOIN " +
                               " BillGroup ON IpdBillServiceDetails.BillGroupId = BillGroup.BillGroupId where IpdBillMaster.IsDischarge=1  and  " +
                               " IpdBillServiceDetails.FId=1 and IpdBillServiceDetails.BranchId=1 and IpdBillServiceDetails.BillGroupId =16 " +
                               " AND (CAST(CAST(YEAR(IpdBillMaster.FinalDischargeOn) AS varchar(4)) + '/' + CAST(MONTH(IpdBillMaster.FinalDischargeOn) AS varchar(2)) " +
                               " + '/' + CAST(DAY(IpdBillMaster.FinalDischargeOn) AS varchar(2)) AS datetime) BETWEEN '" + ViewState["FromDate"] + "'  and '" + ViewState["ToDate"] + "') GROUP BY BillGroup.GroupName, IpdBillServiceDetails.BillGroupId, IpdBillServiceDetails.FId, IpdBillServiceDetails.BranchId," + PatDB + ".dbo.SubDepartment.subdeptName ";


                SqlConnection con12 = DataAccess.ConInitForDC();
                SqlCommand cmd112 = con12.CreateCommand();
                cmd112.CommandText = query12 + ")";
                con12.Open();
                cmd112.ExecuteNonQuery();
                con12.Close(); con12.Dispose();

                string query1 = "ALTER VIEW [dbo].[VW_LabWiseRevuenewwithservice] AS (SELECT    'OPD' as  CenterName, LabServiceDetails.Qty, LabServiceDetails.BillServiceCharges AS TotalCharges, LabServiceDetails.FId, LabServiceDetails.BranchId, BillGroup.GroupName, LabServiceDetails.ServiceName, " +
                               "   isnull(" + PatDB + ".dbo.SubDepartment.subdeptName,'') as subdeptName, PatientInformation.FirstName, Gender.GenderName, PatientInformation.MobileNo, PatientInformation.PhoneNo, PatientInformation.PatientAddress, LabRegistration.ReferenceDoc, " +
                               "  LabRegistration.ReferBy, LabRegistration.LabNo, LabRegistration.BillNo, LabRegistration.PatRegId, LabRegistration.Entrydate " +
                               " FROM            PatientInformation INNER JOIN " +
                               " LabServiceDetails INNER JOIN " +
                               " BillGroup ON LabServiceDetails.BillGroup = BillGroup.BillGroupId INNER JOIN " +
                               " LabRegistration ON LabServiceDetails.BillNo = LabRegistration.BillNo AND LabServiceDetails.LabNo = LabRegistration.LabNo AND LabServiceDetails.PatRegId = LabRegistration.PatRegId ON " +
                               " PatientInformation.PatRegId = LabRegistration.PatRegId INNER JOIN " +
                               " Gender ON PatientInformation.GenderId = Gender.GenderId LEFT OUTER JOIN " +
                               " " + PatDB + ".dbo.SubDepartment LEFT OUTER JOIN " +
                               " " + PatDB + ".dbo.MainTest ON " + PatDB + ".dbo.SubDepartment.SDCode = " + PatDB + ".dbo.MainTest.SDCode ON LabServiceDetails.MTCode = " + PatDB + ".dbo.MainTest.MTCode " +
                               " WHERE      (LabRegistration.LabPtype = 'M') AND (LabRegistration.CancelBill <> 1) AND (LabRegistration.BranchId = 1) AND (CAST(CAST(YEAR(LabRegistration.CreatedOn) AS varchar(4)) + '/' + CAST(MONTH(LabRegistration.CreatedOn) AS varchar(2)) " +
                               " + '/' + CAST(DAY(LabRegistration.CreatedOn) AS varchar(2)) AS datetime) BETWEEN '" + ViewState["FromDate"] + "'  and '" + ViewState["ToDate"] + "') union all SELECT        'IPD' AS CenterName, IpdBillServiceDetails.Qty, IpdBillServiceDetails.TotalCharges, IpdBillServiceDetails.FId, IpdBillServiceDetails.BranchId, BillGroup.GroupName, " +
                               "  IpdBillServiceDetails.ServiceName, " +
                               " isnull(" + PatDB + ".dbo.SubDepartment.subdeptName,'') as subdeptName, PatientInformation.FirstName, Gender.GenderName, PatientInformation.MobileNo, PatientInformation.PhoneNo, PatientInformation.PatientAddress, " +
                               "  IpdBillServiceDetails.MainDoctor,IpdBillServiceDetails.MainDoctor, " +
                               "  IpdBillServiceDetails.LabNo,  " +
                               "  IpdBillServiceDetails.BillNo, IpdBillServiceDetails.PatRegId,IpdBillServiceDetails.CreatedOn " +
                               " FROM            BillGroup INNER JOIN " +
                               " IpdBillMaster INNER JOIN " +
                               " IpdBillServiceDetails INNER JOIN " +
                               " PatientInformation ON IpdBillServiceDetails.PatRegId = PatientInformation.PatRegId ON IpdBillMaster.IpdNo = IpdBillServiceDetails.IpdNo AND IpdBillMaster.PatRegId = IpdBillServiceDetails.PatRegId ON " +
                               " BillGroup.BillGroupId = IpdBillServiceDetails.BillGroupId LEFT OUTER JOIN " +
                               " Gender ON PatientInformation.GenderId = Gender.GenderId LEFT OUTER JOIN " +
                               " " + PatDB + ".dbo.SubDepartment LEFT OUTER JOIN " +
                               " " + PatDB + ".dbo.MainTest ON " + PatDB + ".dbo.SubDepartment.SDCode = " + PatDB + ".dbo.MainTest.SDCode ON IpdBillServiceDetails.MTCode = " + PatDB + ".dbo.MainTest.MTCode " +
                               " WHERE        (IpdBillServiceDetails.BillGroupId = 16) AND (IpdBillServiceDetails.IsDischarge <> 0) AND (IpdBillServiceDetails.BranchId = 1) AND (CAST(CAST(YEAR(IpdBillMaster.FinalDischargeOn) AS varchar(4)) " +
                               " + '/' + CAST(MONTH(IpdBillMaster.FinalDischargeOn) AS varchar(2)) + '/' + CAST(DAY(IpdBillMaster.FinalDischargeOn) AS varchar(2)) AS datetime) BETWEEN '" + ViewState["FromDate"] + "'  and '" + ViewState["ToDate"] + "') ";
                //"  ";//and YEAR(patmstd.Patregdate)=" + ddlYear.SelectedValue + " and Month(patmstd.Patregdate)=" + DdlMonth.SelectedValue + " ";

                SqlConnection con1 = DataAccess.ConInitForDC();
                SqlCommand cmd11 = con1.CreateCommand();
                cmd11.CommandText = query1 + ")";
                con1.Open();
                cmd11.ExecuteNonQuery();
                con1.Close(); con1.Dispose();


                //  objreports.PatientwiseBillGroupIncome_Procedure(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), BillGroup, FId, BranchId);

                Session.Add("rptsql", sql);
                Session["rptname"] = Server.MapPath("~/Reports/Rpt_LABServiceIncomeReport.rpt");
                Session["reportname"] = "LABServiceIncomeReport";
                Session["RPTFORMAT"] = "EXCEL";


                string close = "<script language='javascript'>javascript:OpenReport();</script>";
                Type title1 = this.GetType();
                Page.ClientScript.RegisterStartupScript(title1, "", close);
            }

            if (BillGroup == "Radiology")
            {
                SqlConnection con1H = DataAccess.ConInitForRadiology();
                // con1H.Open();
                string PatDB = con1H.Database;
                //string query12 = "ALTER VIEW [dbo].[VW_LabWiseRevuenew] AS (SELECT   'OPD' as  CenterName,  count( LabRegistration.PatRegId) as NoOfPatient,  sum( LabServiceDetails.Qty) as Qty ,sum( LabServiceDetails.BillServiceCharges) AS TotalCharges, LabServiceDetails.FId, LabServiceDetails.BranchId, " +
                //               " BillGroup.GroupName, " +
                //               " " + PatDB + ".dbo.SubDepartment.subdeptName " +
                //               " FROM            LabServiceDetails INNER JOIN " +
                //               " BillGroup ON LabServiceDetails.BillGroup = BillGroup.BillGroupId INNER JOIN " +
                //               " LabRegistration ON LabServiceDetails.BillNo = LabRegistration.BillNo AND LabServiceDetails.LabNo = LabRegistration.LabNo AND LabServiceDetails.PatRegId = LabRegistration.PatRegId INNER JOIN " +
                //               " " + PatDB + ".dbo.MainTest ON LabServiceDetails.MTCode = " + PatDB + ".dbo.MainTest.MTCode INNER JOIN " +
                //               " " + PatDB + ".dbo.SubDepartment ON " + PatDB + ".dbo.MainTest.SDCode = " + PatDB + ".dbo.SubDepartment.SDCode " +
                //               " WHERE        (LabRegistration.CancelBill <> 1) AND (LabRegistration.BranchId = 1) AND (CAST(CAST(YEAR(LabRegistration.CreatedOn) AS varchar(4)) + '/' + CAST(MONTH(LabRegistration.CreatedOn) AS varchar(2)) " +
                //               " + '/' + CAST(DAY(LabRegistration.CreatedOn) AS varchar(2)) AS datetime) BETWEEN '" + ViewState["FromDate"] + "'  and '" + ViewState["ToDate"] + "') " +
                //               " group by LabServiceDetails.FId,  LabServiceDetails.BranchId, BillGroup.GroupName," + PatDB + ".dbo.SubDepartment.subdeptName ";//and YEAR(patmstd.Patregdate)=" + ddlYear.SelectedValue + " and Month(patmstd.Patregdate)=" + DdlMonth.SelectedValue + " ";
                string query12 = "ALTER VIEW [dbo].[VW_LabWiseRevuenew] AS (SELECT   'OPD' as  CenterName,  count( LabRegistration.PatRegId) as NoOfPatient,  sum( LabServiceDetails.Qty) as Qty ,sum( LabServiceDetails.BillServiceCharges) AS TotalCharges, LabServiceDetails.FId, LabServiceDetails.BranchId, " +
                               " BillGroup.GroupName, " +
                               " " + PatDB + ".dbo.SubDepartment.subdeptName " +
                               " FROM            LabServiceDetails INNER JOIN " +
                               " BillGroup ON LabServiceDetails.BillGroup = BillGroup.BillGroupId INNER JOIN " +
                               " LabRegistration ON LabServiceDetails.BillNo = LabRegistration.BillNo AND LabServiceDetails.LabNo = LabRegistration.LabNo AND LabServiceDetails.PatRegId = LabRegistration.PatRegId INNER JOIN " +
                               " " + PatDB + ".dbo.MainTest ON LabServiceDetails.MTCode = " + PatDB + ".dbo.MainTest.MTCode INNER JOIN " +
                               " " + PatDB + ".dbo.SubDepartment ON " + PatDB + ".dbo.MainTest.SDCode = " + PatDB + ".dbo.SubDepartment.SDCode " +
                               " WHERE        (LabRegistration.CancelBill <> 1) AND (LabRegistration.BranchId = 1) AND (CAST(CAST(YEAR(LabRegistration.CreatedOn) AS varchar(4)) + '/' + CAST(MONTH(LabRegistration.CreatedOn) AS varchar(2)) " +
                               " + '/' + CAST(DAY(LabRegistration.CreatedOn) AS varchar(2)) AS datetime) BETWEEN '" + ViewState["FromDate"] + "'  and '" + ViewState["ToDate"] + "') " +
                               " group by LabServiceDetails.FId,  LabServiceDetails.BranchId, BillGroup.GroupName," + PatDB + ".dbo.SubDepartment.subdeptName union all " +//and YEAR(patmstd.Patregdate)=" + ddlYear.SelectedValue + " and Month(patmstd.Patregdate)=" + DdlMonth.SelectedValue + " ";
                               " SELECT 'IPD' as  CenterName,  count( IpdBillMaster.PatRegId) as NoOfPatient, sum( IpdBillServiceDetails.Qty) as Qty, " +
                               " SUM(IpdBillServiceDetails.TotalCharges) AS TotalCharges,IpdBillServiceDetails.FId, IpdBillServiceDetails.BranchId,  BillGroup.GroupName, " +
                               " isnull(" + PatDB + ".dbo.SubDepartment.subdeptName,'') as subdeptName  FROM            IpdBillServiceDetails LEFT OUTER JOIN " +
                               " " + PatDB + ".dbo.MainTest ON IpdBillServiceDetails.MTCode = " + PatDB + ".dbo.MainTest.MTCode LEFT OUTER JOIN" +
                               " " + PatDB + ".dbo.SubDepartment ON " + PatDB + ".dbo.MainTest.SDCode = " + PatDB + ".dbo.SubDepartment.SDCode LEFT OUTER JOIN " +
                               " IpdBillMaster ON IpdBillServiceDetails.PatRegId = IpdBillMaster.PatRegId AND IpdBillServiceDetails.IpdNo = IpdBillMaster.IpdNo LEFT OUTER JOIN " +
                               " BillGroup ON IpdBillServiceDetails.BillGroupId = BillGroup.BillGroupId where IpdBillMaster.IsDischarge=1  and  " +
                               " IpdBillServiceDetails.FId=1 and IpdBillServiceDetails.BranchId=1 and IpdBillServiceDetails.BillGroupId =20 " +
                               " AND (CAST(CAST(YEAR(IpdBillMaster.FinalDischargeOn) AS varchar(4)) + '/' + CAST(MONTH(IpdBillMaster.FinalDischargeOn) AS varchar(2)) " +
                               " + '/' + CAST(DAY(IpdBillMaster.FinalDischargeOn) AS varchar(2)) AS datetime) BETWEEN '" + ViewState["FromDate"] + "'  and '" + ViewState["ToDate"] + "') GROUP BY BillGroup.GroupName, IpdBillServiceDetails.BillGroupId, IpdBillServiceDetails.FId, IpdBillServiceDetails.BranchId," + PatDB + ".dbo.SubDepartment.subdeptName ";


                SqlConnection con12 = DataAccess.ConInitForDC();
                SqlCommand cmd112 = con12.CreateCommand();
                cmd112.CommandText = query12 + ")";
                con12.Open();
                cmd112.ExecuteNonQuery();
                con12.Close(); con12.Dispose();


                string query1 = "ALTER VIEW [dbo].[VW_LabWiseRevuenewwithservice] AS (SELECT    'OPD' as  CenterName, LabServiceDetails.Qty, LabServiceDetails.BillServiceCharges AS TotalCharges, LabServiceDetails.FId, LabServiceDetails.BranchId, BillGroup.GroupName, LabServiceDetails.ServiceName, " +
                              "   isnull(" + PatDB + ".dbo.SubDepartment.subdeptName,'') as subdeptName, PatientInformation.FirstName, Gender.GenderName, PatientInformation.MobileNo, PatientInformation.PhoneNo, PatientInformation.PatientAddress, LabRegistration.ReferenceDoc, " +
                               "  LabRegistration.ReferBy, LabRegistration.LabNo, LabRegistration.BillNo, LabRegistration.PatRegId, LabRegistration.Entrydate " +
                               " FROM            PatientInformation INNER JOIN " +
                               " LabServiceDetails INNER JOIN " +
                               " BillGroup ON LabServiceDetails.BillGroup = BillGroup.BillGroupId INNER JOIN " +
                               " LabRegistration ON LabServiceDetails.BillNo = LabRegistration.BillNo AND LabServiceDetails.LabNo = LabRegistration.LabNo AND LabServiceDetails.PatRegId = LabRegistration.PatRegId ON " +
                               " PatientInformation.PatRegId = LabRegistration.PatRegId INNER JOIN " +
                               " Gender ON PatientInformation.GenderId = Gender.GenderId LEFT OUTER JOIN " +
                               " " + PatDB + ".dbo.SubDepartment LEFT OUTER JOIN " +
                               " " + PatDB + ".dbo.MainTest ON " + PatDB + ".dbo.SubDepartment.SDCode = " + PatDB + ".dbo.MainTest.SDCode ON LabServiceDetails.MTCode = " + PatDB + ".dbo.MainTest.MTCode " +
                               " WHERE      (LabRegistration.LabPtype = 'R') AND  (LabRegistration.CancelBill <> 1) AND (LabRegistration.BranchId = 1) AND (CAST(CAST(YEAR(LabRegistration.CreatedOn) AS varchar(4)) + '/' + CAST(MONTH(LabRegistration.CreatedOn) AS varchar(2)) " +
                             " + '/' + CAST(DAY(LabRegistration.CreatedOn) AS varchar(2)) AS datetime) BETWEEN '" + ViewState["FromDate"] + "'  and '" + ViewState["ToDate"] + "') union all SELECT        'IPD' AS CenterName, IpdBillServiceDetails.Qty, IpdBillServiceDetails.TotalCharges, IpdBillServiceDetails.FId, IpdBillServiceDetails.BranchId, BillGroup.GroupName, " +
                             "  IpdBillServiceDetails.ServiceName, " +
                             "  isnull(" + PatDB + ".dbo.SubDepartment.subdeptName,'') as subdeptName,  PatientInformation.FirstName, Gender.GenderName, PatientInformation.MobileNo, PatientInformation.PhoneNo, PatientInformation.PatientAddress, " +
                             "  IpdBillServiceDetails.MainDoctor,IpdBillServiceDetails.MainDoctor, " +
                             "  IpdBillServiceDetails.LabNo,  " +
                             "  IpdBillServiceDetails.BillNo, IpdBillServiceDetails.PatRegId,IpdBillServiceDetails.CreatedOn " +
                            " FROM            BillGroup INNER JOIN " +
                               " IpdBillMaster INNER JOIN " +
                               " IpdBillServiceDetails INNER JOIN " +
                               " PatientInformation ON IpdBillServiceDetails.PatRegId = PatientInformation.PatRegId ON IpdBillMaster.IpdNo = IpdBillServiceDetails.IpdNo AND IpdBillMaster.PatRegId = IpdBillServiceDetails.PatRegId ON " +
                               " BillGroup.BillGroupId = IpdBillServiceDetails.BillGroupId LEFT OUTER JOIN " +
                               " Gender ON PatientInformation.GenderId = Gender.GenderId LEFT OUTER JOIN " +
                               " " + PatDB + ".dbo.SubDepartment LEFT OUTER JOIN " +
                               " " + PatDB + ".dbo.MainTest ON " + PatDB + ".dbo.SubDepartment.SDCode = " + PatDB + ".dbo.MainTest.SDCode ON IpdBillServiceDetails.MTCode = " + PatDB + ".dbo.MainTest.MTCode " +
                               " WHERE        (IpdBillServiceDetails.BillGroupId = 20) AND (IpdBillServiceDetails.IsDischarge <> 0) AND (IpdBillServiceDetails.BranchId = 1) AND (CAST(CAST(YEAR(IpdBillMaster.FinalDischargeOn) AS varchar(4)) " +
                               " + '/' + CAST(MONTH(IpdBillMaster.FinalDischargeOn) AS varchar(2)) + '/' + CAST(DAY(IpdBillMaster.FinalDischargeOn) AS varchar(2)) AS datetime) BETWEEN '" + ViewState["FromDate"] + "'  and '" + ViewState["ToDate"] + "') ";
                //"  ";//and YEAR(patmstd.Patregdate)=" + ddlYear.SelectedValue + " and Month(patmstd.Patregdate)=" + DdlMonth.SelectedValue + " ";


                SqlConnection con1 = DataAccess.ConInitForDC();
                SqlCommand cmd11 = con1.CreateCommand();
                cmd11.CommandText = query1 + ")";
                con1.Open();
                cmd11.ExecuteNonQuery();
                con1.Close(); con1.Dispose();
                // objreports.PatientwiseBillGroupIncome_Procedure(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), BillGroup, FId, BranchId);

                Session.Add("rptsql", sql);
                Session["rptname"] = Server.MapPath("~/Reports/Rpt_LABServiceIncomeReport.rpt");
                Session["reportname"] = "LABServiceIncomeReport";
                Session["RPTFORMAT"] = "EXCEL";

                string close = "<script language='javascript'>javascript:OpenReport();</script>";
                Type title1 = this.GetType();
                Page.ClientScript.RegisterStartupScript(title1, "", close);
            }
            if (BillGroup == "Pathology")
            {
                SqlConnection con1H = DataAccess.ConInitForPathology();
                // con1H.Open();
                string PatDB = con1H.Database;
                string query12 = "ALTER VIEW [dbo].[VW_LabWiseRevuenew] AS (SELECT   'OPD' as  CenterName,  count( LabRegistration.PatRegId) as NoOfPatient,  sum( LabServiceDetails.Qty) as Qty ,sum( LabServiceDetails.BillServiceCharges) AS TotalCharges, LabServiceDetails.FId, LabServiceDetails.BranchId, " +
                                " BillGroup.GroupName, " +
                                " " + PatDB + ".dbo.SubDepartment.subdeptName " +
                                " FROM            LabServiceDetails INNER JOIN " +
                                " BillGroup ON LabServiceDetails.BillGroup = BillGroup.BillGroupId INNER JOIN " +
                                " LabRegistration ON LabServiceDetails.BillNo = LabRegistration.BillNo AND LabServiceDetails.LabNo = LabRegistration.LabNo AND LabServiceDetails.PatRegId = LabRegistration.PatRegId INNER JOIN " +
                                " " + PatDB + ".dbo.MainTest ON LabServiceDetails.MTCode = " + PatDB + ".dbo.MainTest.MTCode INNER JOIN " +
                                " " + PatDB + ".dbo.SubDepartment ON " + PatDB + ".dbo.MainTest.SDCode = " + PatDB + ".dbo.SubDepartment.SDCode " +
                                " WHERE        (LabRegistration.CancelBill <> 1) AND (LabRegistration.BranchId = 1) AND (CAST(CAST(YEAR(LabRegistration.CreatedOn) AS varchar(4)) + '/' + CAST(MONTH(LabRegistration.CreatedOn) AS varchar(2)) " +
                                " + '/' + CAST(DAY(LabRegistration.CreatedOn) AS varchar(2)) AS datetime) BETWEEN '" + ViewState["FromDate"] + "'  and '" + ViewState["ToDate"] + "') " +
                                " group by LabServiceDetails.FId,  LabServiceDetails.BranchId, BillGroup.GroupName," + PatDB + ".dbo.SubDepartment.subdeptName union all " +//and YEAR(patmstd.Patregdate)=" + ddlYear.SelectedValue + " and Month(patmstd.Patregdate)=" + DdlMonth.SelectedValue + " ";
                                " SELECT 'IPD' as  CenterName,  count( IpdBillMaster.PatRegId) as NoOfPatient, sum( IpdBillServiceDetails.Qty) as Qty, " +
                                " SUM(IpdBillServiceDetails.TotalCharges) AS TotalCharges,IpdBillServiceDetails.FId, IpdBillServiceDetails.BranchId,  BillGroup.GroupName, " +
                                " isnull(" + PatDB + ".dbo.SubDepartment.subdeptName,'') as subdeptName  FROM            IpdBillServiceDetails LEFT OUTER JOIN" +
                                " " + PatDB + ".dbo.MainTest ON IpdBillServiceDetails.MTCode = " + PatDB + ".dbo.MainTest.MTCode LEFT OUTER JOIN " +
                                " " + PatDB + ".dbo.SubDepartment ON " + PatDB + ".dbo.MainTest.SDCode = " + PatDB + ".dbo.SubDepartment.SDCode LEFT OUTER JOIN " +
                                " IpdBillMaster ON IpdBillServiceDetails.PatRegId = IpdBillMaster.PatRegId AND IpdBillServiceDetails.IpdNo = IpdBillMaster.IpdNo LEFT OUTER JOIN " +
                                " BillGroup ON IpdBillServiceDetails.BillGroupId = BillGroup.BillGroupId where IpdBillMaster.IsDischarge=1  and  " +
                                " IpdBillServiceDetails.FId=1 and IpdBillServiceDetails.BranchId=1 and IpdBillServiceDetails.BillGroupId =19 " +
                                " AND (CAST(CAST(YEAR(IpdBillMaster.FinalDischargeOn) AS varchar(4)) + '/' + CAST(MONTH(IpdBillMaster.FinalDischargeOn) AS varchar(2)) " +
                                " + '/' + CAST(DAY(IpdBillMaster.FinalDischargeOn) AS varchar(2)) AS datetime) BETWEEN '" + ViewState["FromDate"] + "'  and '" + ViewState["ToDate"] + "') GROUP BY BillGroup.GroupName, IpdBillServiceDetails.BillGroupId, IpdBillServiceDetails.FId, IpdBillServiceDetails.BranchId," + PatDB + ".dbo.SubDepartment.subdeptName ";

                SqlConnection con12 = DataAccess.ConInitForDC();
                SqlCommand cmd112 = con12.CreateCommand();
                cmd112.CommandText = query12 + ")";
                con12.Open();
                cmd112.ExecuteNonQuery();
                con12.Close(); con12.Dispose();


                string query1 = "ALTER VIEW [dbo].[VW_LabWiseRevuenewwithservice] AS (SELECT    'OPD' as  CenterName, LabServiceDetails.Qty, LabServiceDetails.BillServiceCharges AS TotalCharges, LabServiceDetails.FId, LabServiceDetails.BranchId, BillGroup.GroupName, LabServiceDetails.ServiceName, " +
                                "   isnull(" + PatDB + ".dbo.SubDepartment.subdeptName,'') as subdeptName, PatientInformation.FirstName, Gender.GenderName, PatientInformation.MobileNo, PatientInformation.PhoneNo, PatientInformation.PatientAddress, LabRegistration.ReferenceDoc, " +
                               "  LabRegistration.ReferBy, LabRegistration.LabNo, LabRegistration.BillNo, LabRegistration.PatRegId, LabRegistration.Entrydate " +
                               " FROM            PatientInformation INNER JOIN " +
                               " LabServiceDetails INNER JOIN " +
                               " BillGroup ON LabServiceDetails.BillGroup = BillGroup.BillGroupId INNER JOIN " +
                               " LabRegistration ON LabServiceDetails.BillNo = LabRegistration.BillNo AND LabServiceDetails.LabNo = LabRegistration.LabNo AND LabServiceDetails.PatRegId = LabRegistration.PatRegId ON " +
                               " PatientInformation.PatRegId = LabRegistration.PatRegId INNER JOIN " +
                               " Gender ON PatientInformation.GenderId = Gender.GenderId LEFT OUTER JOIN " +
                               " " + PatDB + ".dbo.SubDepartment LEFT OUTER JOIN " +
                               " " + PatDB + ".dbo.MainTest ON " + PatDB + ".dbo.SubDepartment.SDCode = " + PatDB + ".dbo.MainTest.SDCode ON LabServiceDetails.MTCode = " + PatDB + ".dbo.MainTest.MTCode " +
                               " WHERE      (LabRegistration.LabPtype = 'P') AND   (LabRegistration.CancelBill <> 1) AND (LabRegistration.BranchId = 1) AND (CAST(CAST(YEAR(LabRegistration.CreatedOn) AS varchar(4)) + '/' + CAST(MONTH(LabRegistration.CreatedOn) AS varchar(2)) " +
                              " + '/' + CAST(DAY(LabRegistration.CreatedOn) AS varchar(2)) AS datetime) BETWEEN '" + ViewState["FromDate"] + "'  and '" + ViewState["ToDate"] + "') union all SELECT        'IPD' AS CenterName, IpdBillServiceDetails.Qty, IpdBillServiceDetails.TotalCharges, IpdBillServiceDetails.FId, IpdBillServiceDetails.BranchId, BillGroup.GroupName, " +
                              "  IpdBillServiceDetails.ServiceName, " +
                              "  isnull(" + PatDB + ".dbo.SubDepartment.subdeptName,'') as subdeptName,  PatientInformation.FirstName, Gender.GenderName, PatientInformation.MobileNo, PatientInformation.PhoneNo, PatientInformation.PatientAddress, " +
                              "  IpdBillServiceDetails.MainDoctor,IpdBillServiceDetails.MainDoctor, " +
                              "  IpdBillServiceDetails.LabNo,  " +
                              "  IpdBillServiceDetails.BillNo, IpdBillServiceDetails.PatRegId,IpdBillServiceDetails.CreatedOn " +
                                " FROM            BillGroup INNER JOIN " +
                               " IpdBillMaster INNER JOIN " +
                               " IpdBillServiceDetails INNER JOIN " +
                               " PatientInformation ON IpdBillServiceDetails.PatRegId = PatientInformation.PatRegId ON IpdBillMaster.IpdNo = IpdBillServiceDetails.IpdNo AND IpdBillMaster.PatRegId = IpdBillServiceDetails.PatRegId ON " +
                               " BillGroup.BillGroupId = IpdBillServiceDetails.BillGroupId LEFT OUTER JOIN " +
                               " Gender ON PatientInformation.GenderId = Gender.GenderId LEFT OUTER JOIN " +
                               " " + PatDB + ".dbo.SubDepartment LEFT OUTER JOIN " +
                               " " + PatDB + ".dbo.MainTest ON " + PatDB + ".dbo.SubDepartment.SDCode = " + PatDB + ".dbo.MainTest.SDCode ON IpdBillServiceDetails.MTCode = " + PatDB + ".dbo.MainTest.MTCode " +
                               " WHERE        (IpdBillServiceDetails.BillGroupId = 19) AND (IpdBillServiceDetails.IsDischarge <> 0) AND (IpdBillServiceDetails.BranchId = 1) AND (CAST(CAST(YEAR(IpdBillMaster.FinalDischargeOn) AS varchar(4)) " +
                               " + '/' + CAST(MONTH(IpdBillMaster.FinalDischargeOn) AS varchar(2)) + '/' + CAST(DAY(IpdBillMaster.FinalDischargeOn) AS varchar(2)) AS datetime) BETWEEN '" + ViewState["FromDate"] + "'  and '" + ViewState["ToDate"] + "') ";
                //"  ";//and YEAR(patmstd.Patregdate)=" + ddlYear.SelectedValue + " and Month(patmstd.Patregdate)=" + DdlMonth.SelectedValue + " ";

                SqlConnection con1 = DataAccess.ConInitForDC();
                SqlCommand cmd11 = con1.CreateCommand();
                cmd11.CommandText = query1 + ")";
                con1.Open();
                cmd11.ExecuteNonQuery();
                con1.Close(); con1.Dispose();
                // objreports.PatientwiseBillGroupIncome_Procedure(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), BillGroup, FId, BranchId);

                Session.Add("rptsql", sql);
                Session["rptname"] = Server.MapPath("~/Reports/Rpt_LABServiceIncomeReport.rpt");
                Session["reportname"] = "LABServiceIncomeReport";
                Session["RPTFORMAT"] = "EXCEL";

                string close = "<script language='javascript'>javascript:OpenReport();</script>";
                Type title1 = this.GetType();
                Page.ClientScript.RegisterStartupScript(title1, "", close);
            }

        }
    
    }
    protected void gvGroupOP_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        BLLReports objreports = new BLLReports();
        string sql = "";
        if (e.CommandName == "Report")
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);

            GridViewRow row = gvGroupOP.Rows[rowIndex];
            string BillGroup = gvGroupOP.DataKeys[rowIndex].Values["BillGroup"].ToString();
            int BranchId = Convert.ToInt32(Session["Branchid"]);
            int FId = Convert.ToInt32(Session["FId"]);

            if (txtFrom.Text.ToString() != "")
            {
                ViewState["FromDate"] = txtFrom.Text.ToString();

            }
            else
            {
                ViewState["FromDate"] = "";
            }
            if (txtTo.Text.ToString() != "")
            {

                ViewState["ToDate"] = txtTo.Text.ToString();


            }
            else
            {
                ViewState["ToDate"] = "";
            }

            objreports.PatientwiseBillGroupIncome_Procedure(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), BillGroup, FId, BranchId);

            
                Session.Add("rptsql", sql);
                Session["rptname"] = Server.MapPath("~/Reports/Rpt_DoctorwiseBillGroupIncome_Procedure.rpt");
                Session["reportname"] = "DoctorwiseBillGroupIncome_Procedure_Report";
                Session["RPTFORMAT"] = "pdf";


                string close = "<script language='javascript'>javascript:OpenReport();</script>";
                Type title1 = this.GetType();
                Page.ClientScript.RegisterStartupScript(title1, "", close);
        }
        if (e.CommandName == "ReportExcel")
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);

            GridViewRow row = gvGroupOP.Rows[rowIndex];
            string BillGroup = gvGroupOP.DataKeys[rowIndex].Values["BillGroup"].ToString();
            int BranchId = Convert.ToInt32(Session["Branchid"]);
            int FId = Convert.ToInt32(Session["FId"]);

            if (txtFrom.Text.ToString() != "")
            {
                ViewState["FromDate"] = txtFrom.Text.ToString();

            }
            else
            {
                ViewState["FromDate"] = "";
            }
            if (txtTo.Text.ToString() != "")
            {

                ViewState["ToDate"] = txtTo.Text.ToString();


            }
            else
            {
                ViewState["ToDate"] = "";
            }

            objreports.PatientwiseBillGroupIncome_Procedure(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), BillGroup, FId, BranchId);


            Session.Add("rptsql", sql);
            Session["rptname"] = Server.MapPath("~/Reports/Rpt_DoctorwiseBillGroupIncome_Procedure.rpt");
            Session["reportname"] = "DoctorwiseBillGroupIncome_Procedure_Report";
            Session["RPTFORMAT"] = "EXCEL";


            string close = "<script language='javascript'>javascript:OpenReport();</script>";
            Type title1 = this.GetType();
            Page.ClientScript.RegisterStartupScript(title1, "", close);
        }
    }
    protected void RdbServices_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RdbServices.SelectedValue == "OPD")
        {
            Diag.Visible = false;
            OPDPr.Visible = true;
            IPDPro.Visible = false;
            Phar.Visible = false;
            FillgridOPD();
        }
        else if (RdbServices.SelectedValue == "IPD")
        {
            Diag.Visible = false;
            OPDPr.Visible = false;
            IPDPro.Visible = true;
            Phar.Visible = false;
            fillgrid_IPD();
        }
        else if (RdbServices.SelectedValue == "Pharmacy")
        {
            Diag.Visible = false;
            OPDPr.Visible = false;
            IPDPro.Visible = false;
            Phar.Visible = true;
            fillgrid_Pharma();
        }
        else
        {
            Diag.Visible = true;
            OPDPr.Visible = false;
            IPDPro.Visible = false;
            Phar.Visible = false;
            fillgrid();
        }
    }
    public void FillgridOPD()
    {
        Alterview_OPD();
        // AlterviewL();
        BLLReports objreports = new BLLReports();
        if (txtFrom.Text.ToString() != "")
        {
            ViewState["FromDate"] = txtFrom.Text.ToString();

        }
        else
        {
            ViewState["FromDate"] = "";
        }
        if (txtTo.Text.ToString() != "")
        {

            ViewState["ToDate"] = txtTo.Text.ToString();


        }
        else
        {
            ViewState["ToDate"] = "";
        }

        int BranchId = Convert.ToInt32(Session["BranchId"]);
        int FId = Convert.ToInt32(Session["FId"]);
        DataTable dt = new DataTable();
        dt = ObjDOReport.FillGroupwiseIncomeGrid_Procedure(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), BranchId, FId);
        gvGroupOP.DataSource = dt;
        gvGroupOP.DataBind();
        if (dt.Rows.Count > 0)
        {
            double TotalAmt = dt.AsEnumerable().Sum(row => row.Field<double>("TotalCharges"));
            gvGroupOP.FooterRow.Cells[2].Text = "Total";
            gvGroupOP.FooterRow.Cells[2].HorizontalAlign = HorizontalAlign.Right;
            gvGroupOP.FooterRow.Cells[3].Text = TotalAmt.ToString("N2");
        }
    }
    public void Alterview_OPD()
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
    protected void gvGroupIPD_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        BLLReports objreports = new BLLReports();
        string sql = "";
        if (e.CommandName == "Report")
        {

          
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = gvGroupIPD.Rows[rowIndex];
                int BillGroupId = Convert.ToInt32(gvGroupIPD.DataKeys[rowIndex].Values["BillGroupId"]);
                int BranchId = Convert.ToInt32(Session["Branchid"]);
                int FId = Convert.ToInt32(Session["FId"]);
                if (txtFrom.Text.ToString() != "")
                {
                    ViewState["FromDate"] = txtFrom.Text.ToString();

                }
                else
                {
                    ViewState["FromDate"] = "";
                }
                if (txtTo.Text.ToString() != "")
                {

                    ViewState["ToDate"] = txtTo.Text.ToString();


                }
                else
                {
                    ViewState["ToDate"] = "";
                }

                

                objreports.PatientwiseBillGroupIncome(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), BillGroupId, FId, BranchId);

                Session.Add("rptsql", sql);
                Session["rptname"] = Server.MapPath("~/Reports/Rpt_PatientwiseBillGroupIncome.rpt");
                Session["reportname"] = "PatientwiseBillGroupIncome_Report";
                Session["RPTFORMAT"] = "pdf";

                string close = "<script language='javascript'>javascript:OpenReport();</script>";
                Type title1 = this.GetType();
                Page.ClientScript.RegisterStartupScript(title1, "", close);
            }
        if (e.CommandName == "ExcelReport")
        {


            int rowIndex = Convert.ToInt32(e.CommandArgument);

            GridViewRow row = gvGroupIPD.Rows[rowIndex];
            int BillGroupId = Convert.ToInt32(gvGroupIPD.DataKeys[rowIndex].Values["BillGroupId"]);
            int BranchId = Convert.ToInt32(Session["Branchid"]);
            int FId = Convert.ToInt32(Session["FId"]);
            if (txtFrom.Text.ToString() != "")
            {
                ViewState["FromDate"] = txtFrom.Text.ToString();

            }
            else
            {
                ViewState["FromDate"] = "";
            }
            if (txtTo.Text.ToString() != "")
            {

                ViewState["ToDate"] = txtTo.Text.ToString();


            }
            else
            {
                ViewState["ToDate"] = "";
            }



            objreports.PatientwiseBillGroupIncome(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), BillGroupId, FId, BranchId);

            Session.Add("rptsql", sql);
            Session["rptname"] = Server.MapPath("~/Reports/Rpt_PatientwiseBillGroupIncome.rpt");
            Session["reportname"] = "PatientwiseBillGroupIncome_Report";
            Session["RPTFORMAT"] = "EXCEL";

            string close = "<script language='javascript'>javascript:OpenReport();</script>";
            Type title1 = this.GetType();
            Page.ClientScript.RegisterStartupScript(title1, "", close);
        }
          
    }

    public void fillgrid_IPD()
    {
        if (txtFrom.Text.ToString() != "")
        {

            ViewState["FromDate"] = txtFrom.Text.ToString();
        }
        else
        {
            ViewState["FromDate"] = "";
        }
        if (txtTo.Text.ToString() != "")
        {

            ViewState["ToDate"] = txtTo.Text.ToString();
        }
        else
        {
            ViewState["ToDate"] = "";
        }
        int BranchId = Convert.ToInt32(Session["BranchId"]);
        int FId = Convert.ToInt32(Session["FId"]);


        DataTable dt = new DataTable();
        dt = ObjDOReport.FillGroupwiseIncomeGrid(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), BranchId, FId);
        gvGroupIPD.DataSource = dt;
        gvGroupIPD.DataBind();
        if (dt.Rows.Count > 0)
        {
            double TotalAmt = dt.AsEnumerable().Sum(row => row.Field<double>("TotalCharges"));
            gvGroupIPD.FooterRow.Cells[3].Text = "Total";
            gvGroupIPD.FooterRow.Cells[3].HorizontalAlign = HorizontalAlign.Right;
            gvGroupIPD.FooterRow.Cells[4].Text = TotalAmt.ToString("N2");
        }
    }
    protected void btnIPDPrint_Click(object sender, EventArgs e)
    {
        string sql = "";
        if (txtFrom.Text.ToString() != "")
        {

            ViewState["FromDate"] = txtFrom.Text.ToString();
        }
        else
        {
            ViewState["FromDate"] = "";
        }
        if (txtTo.Text.ToString() != "")
        {

            ViewState["ToDate"] = txtTo.Text.ToString();
        }
        else
        {
            ViewState["ToDate"] = "";
        }
        int BranchId = Convert.ToInt32(Session["BranchId"]);
        int FId = Convert.ToInt32(Session["FId"]);
        ObjDOReport.BillGroupSalesSummary(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), BranchId, FId);

        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Reports/Rpt_BillGroupSalesSummary.rpt");
        Session["reportname"] = "BillGroupSalesSummary";
        Session["RPTFORMAT"] = "pdf";

        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);
    }
    protected void btnPrintOPD_Click(object sender, EventArgs e)
    {
        string sql = "";
        if (txtFrom.Text.ToString() != "")
        {

            ViewState["FromDate"] = txtFrom.Text.ToString();
        }
        else
        {
            ViewState["FromDate"] = "";
        }
        if (txtTo.Text.ToString() != "")
        {

            ViewState["ToDate"] = txtTo.Text.ToString();
        }
        else
        {
            ViewState["ToDate"] = "";
        }
        int BranchId = Convert.ToInt32(Session["BranchId"]);
        int FId = Convert.ToInt32(Session["FId"]);
        ObjDOReport.BillGroupSalesSummary_Procedure(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), BranchId, FId);

        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Reports/Rpt_BillGroupSalesSummary_Procedure.rpt");
        Session["reportname"] = "BillGroupSalesSummary_Procedure";
        Session["RPTFORMAT"] = "pdf";

        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);
    }

    public void fillgrid_Pharma()
    {
        AlterPharma();
        if (txtFrom.Text.ToString() != "")
        {

            ViewState["FromDate"] = txtFrom.Text.ToString();
        }
        else
        {
            ViewState["FromDate"] = "";
        }
        if (txtTo.Text.ToString() != "")
        {

            ViewState["ToDate"] = txtTo.Text.ToString();
        }
        else
        {
            ViewState["ToDate"] = "";
        }
        int BranchId = Convert.ToInt32(Session["BranchId"]);
        int FId = Convert.ToInt32(Session["FId"]);
       // AlterPharma();

        DataTable dt = new DataTable();
        dt = ObjDOReport.FillGroupwiseIncomeGrid_Pharma(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), BranchId, FId);
        GVPharmaIn.DataSource = dt;
        GVPharmaIn.DataBind();
        if (dt.Rows.Count > 0)
        {
            double TotalAmt = dt.AsEnumerable().Sum(row => row.Field<double>("TotalCharges"));
            GVPharmaIn.FooterRow.Cells[3].Text = "Total";
            GVPharmaIn.FooterRow.Cells[3].HorizontalAlign = HorizontalAlign.Right;
            GVPharmaIn.FooterRow.Cells[4].Text = TotalAmt.ToString("N2");
            GVPharmaIn.FooterRow.Cells[4].Text = Convert.ToString(TotalAmt);
        }
    }
    protected void GVPharmaIn_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        BLLReports objreports = new BLLReports();
        string sql = "";
        if (e.CommandName == "Report")
        {


            int rowIndex = Convert.ToInt32(e.CommandArgument);

            GridViewRow row = GVPharmaIn.Rows[rowIndex];
            int BillGroupId = Convert.ToInt32(GVPharmaIn.DataKeys[rowIndex].Values["BillGroupId"]);
            int BranchId = Convert.ToInt32(Session["Branchid"]);
            int FId = Convert.ToInt32(Session["FId"]);
            if (txtFrom.Text.ToString() != "")
            {
                ViewState["FromDate"] = txtFrom.Text.ToString();

            }
            else
            {
                ViewState["FromDate"] = "";
            }
            if (txtTo.Text.ToString() != "")
            {

                ViewState["ToDate"] = txtTo.Text.ToString();


            }
            else
            {
                ViewState["ToDate"] = "";
            }

            if (BillGroupId == 13)
            {

                objreports.PatientwiseBillGroupIncome_Pharmacy(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), BillGroupId, FId, BranchId);

                Session.Add("rptsql", sql);
                Session["rptname"] = Server.MapPath("~/Reports/Rpt_PatientwiseBillGroupPharmaIPD.rpt");
                Session["reportname"] = "Rpt_PatientwiseBillGroupPharmaIPD";
                Session["RPTFORMAT"] = "pdf";
            }
            else
            {
                //objreports.PatientwiseBillGroupIncome_Pharmacy_OP(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), BillGroupId, FId, BranchId);
                AlterPharma();
                Session.Add("rptsql", sql);
                Session["rptname"] = Server.MapPath("~/Reports/Rpt_PatientwiseBillGroupPharmaOPD.rpt");
                Session["reportname"] = "Rpt_PatientwiseBillGroupPharmaOPD";
                Session["RPTFORMAT"] = "pdf";
            }
        }
        if (e.CommandName == "ReportExcel")
        {


            int rowIndex = Convert.ToInt32(e.CommandArgument);

            GridViewRow row = GVPharmaIn.Rows[rowIndex];
            int BillGroupId = Convert.ToInt32(GVPharmaIn.DataKeys[rowIndex].Values["BillGroupId"]);
            int BranchId = Convert.ToInt32(Session["Branchid"]);
            int FId = Convert.ToInt32(Session["FId"]);
            if (txtFrom.Text.ToString() != "")
            {
                ViewState["FromDate"] = txtFrom.Text.ToString();

            }
            else
            {
                ViewState["FromDate"] = "";
            }
            if (txtTo.Text.ToString() != "")
            {

                ViewState["ToDate"] = txtTo.Text.ToString();


            }
            else
            {
                ViewState["ToDate"] = "";
            }

            if (BillGroupId == 13)
            {

                objreports.PatientwiseBillGroupIncome_Pharmacy(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), BillGroupId, FId, BranchId);

                Session.Add("rptsql", sql);
                Session["rptname"] = Server.MapPath("~/Reports/Rpt_PatientwiseBillGroupPharmaIPD.rpt");
                Session["reportname"] = "Rpt_PatientwiseBillGroupPharmaIPD";
                Session["RPTFORMAT"] = "pdf";
            }
            else
            {
                //objreports.PatientwiseBillGroupIncome_Pharmacy_OP(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), BillGroupId, FId, BranchId);
                AlterPharma();
                Session.Add("rptsql", sql);
                Session["rptname"] = Server.MapPath("~/Reports/Rpt_PatientwiseBillGroupPharmaOPD.rpt");
                Session["reportname"] = "Rpt_PatientwiseBillGroupPharmaOPD";
                Session["RPTFORMAT"] = "pdf";
            }
        }
            string close = "<script language='javascript'>javascript:OpenReport();</script>";
            Type title1 = this.GetType();
            Page.ClientScript.RegisterStartupScript(title1, "", close);
        
    }
    public void AlterPharma()
    {
        try
        {

            if (txtFrom.Text.ToString() != "")
            {

                ViewState["FromDate"] = Convert.ToDateTime(txtFrom.Text).ToString("MM/dd/yyyy") + " " + ddlTimeFrom.Text; ;
            }
            else
            {
                ViewState["FromDate"] = "";
            }
            if (txtTo.Text.ToString() != "")
            {

                ViewState["ToDate"] = Convert.ToDateTime(txtTo.Text).ToString("MM/dd/yyyy") + " " + ddlTimeTo.Text; ;
            }
            else
            {
                ViewState["ToDate"] = "";
            }
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
               //  "  and (CAST(CAST(YEAR(PatientIssueVoucher.CreatedOn) AS varchar(4)) + '/' + CAST(MONTH(PatientIssueVoucher.CreatedOn) AS varchar(2)) + '/' + CAST(DAY(PatientIssueVoucher.CreatedOn) AS varchar(2)) AS datetime))  between ('" + Convert.ToDateTime(txtFrom.Text).ToString("MM/dd/yyyy") + "') and ('" + Convert.ToDateTime(txtTo.Text).ToString("MM/dd/yyyy") + "') "+// 
                  "  and (CAST(CAST(YEAR(PatientIssueVoucher.CreatedOn) AS varchar(4)) + '/' + CAST(MONTH(PatientIssueVoucher.CreatedOn) AS varchar(2)) + '/' + CAST(DAY(PatientIssueVoucher.CreatedOn) AS varchar(2)) AS datetime))  between ('" + Convert.ToDateTime(txtFrom.Text).ToString("MM/dd/yyyy") + "') and ('" + Convert.ToDateTime(txtTo.Text).ToString("MM/dd/yyyy") + "')";// 
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
                      "  where PatIssueVoucherDetails.IssueQty<0 and (CAST(CAST(YEAR(PatIssueVoucherDetails.CreatedOn) AS varchar(4)) + '/' + CAST(MONTH(PatIssueVoucherDetails.CreatedOn) AS varchar(2)) + '/' + CAST(DAY(PatIssueVoucherDetails.CreatedOn) AS varchar(2)) AS datetime))  between ('" + Convert.ToDateTime(txtFrom.Text).ToString("MM/dd/yyyy") + "') and ('" + Convert.ToDateTime(txtTo.Text).ToString("MM/dd/yyyy") + "')";// 



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
                      "  where PatIssueVoucherDetails.IssueQty>0 and (CAST(CAST(YEAR(PatIssueVoucherDetails.CreatedOn) AS varchar(4)) + '/' + CAST(MONTH(PatIssueVoucherDetails.CreatedOn) AS varchar(2)) + '/' + CAST(DAY(PatIssueVoucherDetails.CreatedOn) AS varchar(2)) AS datetime))  between ('" + Convert.ToDateTime(txtFrom.Text).ToString("MM/dd/yyyy") + "') and ('" + Convert.ToDateTime(txtTo.Text).ToString("MM/dd/yyyy") + "')";// 



        cmd1.CommandText = query + ")";

        conrp.Open();
        cmd1.ExecuteNonQuery();
        conrp.Close(); conrp.Dispose();
    }
    protected void btnPrintOPDEX_Click(object sender, EventArgs e)
    {
        string sql = "";
        if (txtFrom.Text.ToString() != "")
        {

            ViewState["FromDate"] = txtFrom.Text.ToString();
        }
        else
        {
            ViewState["FromDate"] = "";
        }
        if (txtTo.Text.ToString() != "")
        {

            ViewState["ToDate"] = txtTo.Text.ToString();
        }
        else
        {
            ViewState["ToDate"] = "";
        }
        int BranchId = Convert.ToInt32(Session["BranchId"]);
        int FId = Convert.ToInt32(Session["FId"]);
        ObjDOReport.BillGroupSalesSummary_Procedure(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), BranchId, FId);

        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Reports/Rpt_BillGroupSalesSummary_Procedure.rpt");
        Session["reportname"] = "BillGroupSalesSummary_Procedure";
        Session["RPTFORMAT"] = "EXCEL";

        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);
    }
    protected void btnIPDPrintExcel_Click(object sender, EventArgs e)
    {
        string sql = "";
        if (txtFrom.Text.ToString() != "")
        {

            ViewState["FromDate"] = txtFrom.Text.ToString();
        }
        else
        {
            ViewState["FromDate"] = "";
        }
        if (txtTo.Text.ToString() != "")
        {

            ViewState["ToDate"] = txtTo.Text.ToString();
        }
        else
        {
            ViewState["ToDate"] = "";
        }
        int BranchId = Convert.ToInt32(Session["BranchId"]);
        int FId = Convert.ToInt32(Session["FId"]);
       ObjDOReport.BillGroupSalesSummary(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), BranchId, FId);
       
        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Reports/Rpt_BillGroupSalesSummary.rpt");
        Session["reportname"] = "BillGroupSalesSummary";
        Session["RPTFORMAT"] = "EXCEL";

        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);
    }
    protected void btnPrintPharmacy_Click(object sender, EventArgs e)
    {
        string sql = "";
        if (txtFrom.Text.ToString() != "")
        {

            ViewState["FromDate"] = txtFrom.Text.ToString();
        }
        else
        {
            ViewState["FromDate"] = "";
        }
        if (txtTo.Text.ToString() != "")
        {

            ViewState["ToDate"] = txtTo.Text.ToString();
        }
        else
        {
            ViewState["ToDate"] = "";
        }
        int BranchId = Convert.ToInt32(Session["BranchId"]);
        int FId = Convert.ToInt32(Session["FId"]);
       // ObjDOReport.BillGroupSalesSummary(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), BranchId, FId);
        DataTable dt = new DataTable();
        dt = ObjDOReport.FillGroupwiseIncomeGrid_Pharma(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), BranchId, FId);
        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Reports/RPT_BillGroupSalesSummary_Pharmacy.rpt");
        Session["reportname"] = "BillGroupSalesSummary_Pharmacy";
        Session["RPTFORMAT"] = "pdf";

        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);
    }
    protected void btnPrintPharmacyExcel_Click(object sender, EventArgs e)
    {
        string sql = "";
        if (txtFrom.Text.ToString() != "")
        {

            ViewState["FromDate"] = txtFrom.Text.ToString();
        }
        else
        {
            ViewState["FromDate"] = "";
        }
        if (txtTo.Text.ToString() != "")
        {

            ViewState["ToDate"] = txtTo.Text.ToString();
        }
        else
        {
            ViewState["ToDate"] = "";
        }
        int BranchId = Convert.ToInt32(Session["BranchId"]);
        int FId = Convert.ToInt32(Session["FId"]);
       // ObjDOReport.BillGroupSalesSummary(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), BranchId, FId);
        DataTable dt = new DataTable();
        dt = ObjDOReport.FillGroupwiseIncomeGrid_Pharma(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), BranchId, FId);
        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Reports/RPT_BillGroupSalesSummary_Pharmacy.rpt");
        Session["reportname"] = "BillGroupSalesSummary_Pharmacy";
        Session["RPTFORMAT"] = "EXCEL";

        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);

    }
    protected void btnAllPrint_Click(object sender, EventArgs e)
    {
        BLLReports objreports = new BLLReports();
        int BranchId = Convert.ToInt32(Session["BranchId"]);
        int FId = Convert.ToInt32(Session["FId"]);


        if (txtFrom.Text.ToString() != "")
        {

            ViewState["FromDate"] = Convert.ToDateTime(txtFrom.Text).ToString("MM/dd/yyyy") + " " + ddlTimeFrom.Text; ;
        }
        else
        {
            ViewState["FromDate"] = "";
        }
        if (txtTo.Text.ToString() != "")
        {

            ViewState["ToDate"] = Convert.ToDateTime(txtTo.Text).ToString("MM/dd/yyyy") + " " + ddlTimeTo.Text; ;
        }
        else
        {
            ViewState["ToDate"] = "";
        }
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
            //  "  and (CAST(CAST(YEAR(PatientIssueVoucher.CreatedOn) AS varchar(4)) + '/' + CAST(MONTH(PatientIssueVoucher.CreatedOn) AS varchar(2)) + '/' + CAST(DAY(PatientIssueVoucher.CreatedOn) AS varchar(2)) AS datetime))  between ('" + Convert.ToDateTime(txtFrom.Text).ToString("MM/dd/yyyy") + "') and ('" + Convert.ToDateTime(txtTo.Text).ToString("MM/dd/yyyy") + "') "+// 
              "  and (CAST(CAST(YEAR(PatientIssueVoucher.CreatedOn) AS varchar(4)) + '/' + CAST(MONTH(PatientIssueVoucher.CreatedOn) AS varchar(2)) + '/' + CAST(DAY(PatientIssueVoucher.CreatedOn) AS varchar(2)) AS datetime))  between ('" + Convert.ToDateTime(txtFrom.Text).ToString("MM/dd/yyyy") + "') and ('" + Convert.ToDateTime(txtTo.Text).ToString("MM/dd/yyyy") + "')";// 
        // " and PatientIssueVoucher.CreatedOn between '" + Convert.ToString(ViewState["FromDate"]) + "'  and '" + Convert.ToString(ViewState["ToDate"]) + "' ";

        //  query += "  and  PatientType<>'IPD'   ";


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

       


        //if (BillGroup == "Radiology")
        //{
            SqlConnection con1H = DataAccess.ConInitForRadiology();
            // con1H.Open();
            string PatDB = con1H.Database;
                       string query12 = "ALTER VIEW [dbo].[VW_LabWiseRevuenew] AS (SELECT   'OPD' as  CenterName,  count( LabRegistration.PatRegId) as NoOfPatient,  sum( LabServiceDetails.Qty) as Qty ,sum( LabServiceDetails.BillServiceCharges) AS TotalCharges, LabServiceDetails.FId, LabServiceDetails.BranchId, " +
                           " BillGroup.GroupName, " +
                           " " + PatDB + ".dbo.SubDepartment.subdeptName " +
                           " FROM            LabServiceDetails INNER JOIN " +
                           " BillGroup ON LabServiceDetails.BillGroup = BillGroup.BillGroupId INNER JOIN " +
                           " LabRegistration ON LabServiceDetails.BillNo = LabRegistration.BillNo AND LabServiceDetails.LabNo = LabRegistration.LabNo AND LabServiceDetails.PatRegId = LabRegistration.PatRegId INNER JOIN " +
                           " " + PatDB + ".dbo.MainTest ON LabServiceDetails.MTCode = " + PatDB + ".dbo.MainTest.MTCode INNER JOIN " +
                           " " + PatDB + ".dbo.SubDepartment ON " + PatDB + ".dbo.MainTest.SDCode = " + PatDB + ".dbo.SubDepartment.SDCode " +
                           " WHERE        (LabRegistration.CancelBill <> 1) AND (LabRegistration.BranchId = 1) AND (CAST(CAST(YEAR(LabRegistration.CreatedOn) AS varchar(4)) + '/' + CAST(MONTH(LabRegistration.CreatedOn) AS varchar(2)) " +
                           " + '/' + CAST(DAY(LabRegistration.CreatedOn) AS varchar(2)) AS datetime) BETWEEN '" + ViewState["FromDate"] + "'  and '" + ViewState["ToDate"] + "') " +
                           " group by LabServiceDetails.FId,  LabServiceDetails.BranchId, BillGroup.GroupName," + PatDB + ".dbo.SubDepartment.subdeptName union all " +//and YEAR(patmstd.Patregdate)=" + ddlYear.SelectedValue + " and Month(patmstd.Patregdate)=" + DdlMonth.SelectedValue + " ";
                           " SELECT 'IPD' as  CenterName,  count( IpdBillMaster.PatRegId) as NoOfPatient, sum( IpdBillServiceDetails.Qty) as Qty, " +
                           " SUM(IpdBillServiceDetails.TotalCharges) AS TotalCharges,IpdBillServiceDetails.FId, IpdBillServiceDetails.BranchId,  BillGroup.GroupName, " +
                           " isnull(" + PatDB + ".dbo.SubDepartment.subdeptName,'') as subdeptName  FROM            IpdBillServiceDetails LEFT OUTER JOIN " +
                           " " + PatDB + ".dbo.MainTest ON IpdBillServiceDetails.MTCode = " + PatDB + ".dbo.MainTest.MTCode LEFT OUTER JOIN" +
                           " " + PatDB + ".dbo.SubDepartment ON " + PatDB + ".dbo.MainTest.SDCode = " + PatDB + ".dbo.SubDepartment.SDCode LEFT OUTER JOIN " +
                           " IpdBillMaster ON IpdBillServiceDetails.PatRegId = IpdBillMaster.PatRegId AND IpdBillServiceDetails.IpdNo = IpdBillMaster.IpdNo LEFT OUTER JOIN " +
                           " BillGroup ON IpdBillServiceDetails.BillGroupId = BillGroup.BillGroupId where IpdBillMaster.IsDischarge=1  and  " +
                           " IpdBillServiceDetails.FId=1 and IpdBillServiceDetails.BranchId=1 and IpdBillServiceDetails.BillGroupId =20 " +
                           " AND (CAST(CAST(YEAR(IpdBillMaster.FinalDischargeOn) AS varchar(4)) + '/' + CAST(MONTH(IpdBillMaster.FinalDischargeOn) AS varchar(2)) " +
                           " + '/' + CAST(DAY(IpdBillMaster.FinalDischargeOn) AS varchar(2)) AS datetime) BETWEEN '" + ViewState["FromDate"] + "'  and '" + ViewState["ToDate"] + "') GROUP BY BillGroup.GroupName, IpdBillServiceDetails.BillGroupId, IpdBillServiceDetails.FId, IpdBillServiceDetails.BranchId," + PatDB + ".dbo.SubDepartment.subdeptName ";


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
            if (txtFrom.Text.ToString() != "")
            {
                ViewState["FromDate"] = txtFrom.Text.ToString();

            }
            else
            {
                ViewState["FromDate"] = "";
            }
            if (txtTo.Text.ToString() != "")
            {

                ViewState["ToDate"] = txtTo.Text.ToString();


            }
            else
            {
                ViewState["ToDate"] = "";
            }
            DataTable dt = new DataTable();
            dt = ObjDOReport.FillGroupwiseIncomeGrid_LAB(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), BranchId, FId);

            ObjDOReport.VW_GetAllServiceIncome(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), BranchId, FId, GroupTyp.SelectedItem.Text);

        Session.Add("rptsql", "");
        Session["rptname"] = Server.MapPath("~/Reports/Rpt_AllServiceIncome.rpt");
        Session["reportname"] = "Rpt_GetAllServiceIncome";
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


        if (txtFrom.Text.ToString() != "")
        {

            ViewState["FromDate"] = Convert.ToDateTime(txtFrom.Text).ToString("MM/dd/yyyy") + " " + ddlTimeFrom.Text; ;
        }
        else
        {
            ViewState["FromDate"] = "";
        }
        if (txtTo.Text.ToString() != "")
        {

            ViewState["ToDate"] = Convert.ToDateTime(txtTo.Text).ToString("MM/dd/yyyy") + " " + ddlTimeTo.Text; ;
        }
        else
        {
            ViewState["ToDate"] = "";
        }
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
            //  "  and (CAST(CAST(YEAR(PatientIssueVoucher.CreatedOn) AS varchar(4)) + '/' + CAST(MONTH(PatientIssueVoucher.CreatedOn) AS varchar(2)) + '/' + CAST(DAY(PatientIssueVoucher.CreatedOn) AS varchar(2)) AS datetime))  between ('" + Convert.ToDateTime(txtFrom.Text).ToString("MM/dd/yyyy") + "') and ('" + Convert.ToDateTime(txtTo.Text).ToString("MM/dd/yyyy") + "') "+// 
              "  and (CAST(CAST(YEAR(PatientIssueVoucher.CreatedOn) AS varchar(4)) + '/' + CAST(MONTH(PatientIssueVoucher.CreatedOn) AS varchar(2)) + '/' + CAST(DAY(PatientIssueVoucher.CreatedOn) AS varchar(2)) AS datetime))  between ('" + Convert.ToDateTime(txtFrom.Text).ToString("MM/dd/yyyy") + "') and ('" + Convert.ToDateTime(txtTo.Text).ToString("MM/dd/yyyy") + "')";// 
        // " and PatientIssueVoucher.CreatedOn between '" + Convert.ToString(ViewState["FromDate"]) + "'  and '" + Convert.ToString(ViewState["ToDate"]) + "' ";

        //  query += "  and  PatientType<>'IPD'   ";


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




        //if (BillGroup == "Radiology")
        //{
        SqlConnection con1H = DataAccess.ConInitForRadiology();
        // con1H.Open();
        string PatDB = con1H.Database;
        string query12 = "ALTER VIEW [dbo].[VW_LabWiseRevuenew] AS (SELECT   'OPD' as  CenterName,  count( LabRegistration.PatRegId) as NoOfPatient,  sum( LabServiceDetails.Qty) as Qty ,sum( LabServiceDetails.BillServiceCharges) AS TotalCharges, LabServiceDetails.FId, LabServiceDetails.BranchId, " +
            " BillGroup.GroupName, " +
            " " + PatDB + ".dbo.SubDepartment.subdeptName " +
            " FROM            LabServiceDetails INNER JOIN " +
            " BillGroup ON LabServiceDetails.BillGroup = BillGroup.BillGroupId INNER JOIN " +
            " LabRegistration ON LabServiceDetails.BillNo = LabRegistration.BillNo AND LabServiceDetails.LabNo = LabRegistration.LabNo AND LabServiceDetails.PatRegId = LabRegistration.PatRegId INNER JOIN " +
            " " + PatDB + ".dbo.MainTest ON LabServiceDetails.MTCode = " + PatDB + ".dbo.MainTest.MTCode INNER JOIN " +
            " " + PatDB + ".dbo.SubDepartment ON " + PatDB + ".dbo.MainTest.SDCode = " + PatDB + ".dbo.SubDepartment.SDCode " +
            " WHERE        (LabRegistration.CancelBill <> 1) AND (LabRegistration.BranchId = 1) AND (CAST(CAST(YEAR(LabRegistration.CreatedOn) AS varchar(4)) + '/' + CAST(MONTH(LabRegistration.CreatedOn) AS varchar(2)) " +
            " + '/' + CAST(DAY(LabRegistration.CreatedOn) AS varchar(2)) AS datetime) BETWEEN '" + ViewState["FromDate"] + "'  and '" + ViewState["ToDate"] + "') " +
            " group by LabServiceDetails.FId,  LabServiceDetails.BranchId, BillGroup.GroupName," + PatDB + ".dbo.SubDepartment.subdeptName union all " +//and YEAR(patmstd.Patregdate)=" + ddlYear.SelectedValue + " and Month(patmstd.Patregdate)=" + DdlMonth.SelectedValue + " ";
            " SELECT 'IPD' as  CenterName,  count( IpdBillMaster.PatRegId) as NoOfPatient, sum( IpdBillServiceDetails.Qty) as Qty, " +
            " SUM(IpdBillServiceDetails.TotalCharges) AS TotalCharges,IpdBillServiceDetails.FId, IpdBillServiceDetails.BranchId,  BillGroup.GroupName, " +
            " isnull(" + PatDB + ".dbo.SubDepartment.subdeptName,'') as subdeptName  FROM            IpdBillServiceDetails LEFT OUTER JOIN " +
            " " + PatDB + ".dbo.MainTest ON IpdBillServiceDetails.MTCode = " + PatDB + ".dbo.MainTest.MTCode LEFT OUTER JOIN" +
            " " + PatDB + ".dbo.SubDepartment ON " + PatDB + ".dbo.MainTest.SDCode = " + PatDB + ".dbo.SubDepartment.SDCode LEFT OUTER JOIN " +
            " IpdBillMaster ON IpdBillServiceDetails.PatRegId = IpdBillMaster.PatRegId AND IpdBillServiceDetails.IpdNo = IpdBillMaster.IpdNo LEFT OUTER JOIN " +
            " BillGroup ON IpdBillServiceDetails.BillGroupId = BillGroup.BillGroupId where IpdBillMaster.IsDischarge=1  and  " +
            " IpdBillServiceDetails.FId=1 and IpdBillServiceDetails.BranchId=1 and IpdBillServiceDetails.BillGroupId =20 " +
            " AND (CAST(CAST(YEAR(IpdBillMaster.FinalDischargeOn) AS varchar(4)) + '/' + CAST(MONTH(IpdBillMaster.FinalDischargeOn) AS varchar(2)) " +
            " + '/' + CAST(DAY(IpdBillMaster.FinalDischargeOn) AS varchar(2)) AS datetime) BETWEEN '" + ViewState["FromDate"] + "'  and '" + ViewState["ToDate"] + "') GROUP BY BillGroup.GroupName, IpdBillServiceDetails.BillGroupId, IpdBillServiceDetails.FId, IpdBillServiceDetails.BranchId," + PatDB + ".dbo.SubDepartment.subdeptName ";


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
        if (txtFrom.Text.ToString() != "")
        {
            ViewState["FromDate"] = txtFrom.Text.ToString();

        }
        else
        {
            ViewState["FromDate"] = "";
        }
        if (txtTo.Text.ToString() != "")
        {

            ViewState["ToDate"] = txtTo.Text.ToString();


        }
        else
        {
            ViewState["ToDate"] = "";
        }
        DataTable dt = new DataTable();
        dt = ObjDOReport.FillGroupwiseIncomeGrid_LAB(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), BranchId, FId);

        ObjDOReport.VW_GetAllServiceIncome(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), BranchId, FId, GroupTyp.SelectedItem.Text);

        Session.Add("rptsql", "");
        Session["rptname"] = Server.MapPath("~/Reports/Rpt_AllServiceIncome.rpt");
        Session["reportname"] = "Rpt_GetAllServiceIncome";
        Session["RPTFORMAT"] = "EXCEL";//EXCEL

        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);
    }
}