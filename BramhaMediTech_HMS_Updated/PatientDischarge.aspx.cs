using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PatientDischarge : BasePage
{
    clsEmr obj = new clsEmr();
    BELOPDPatReg objBELIpd = new BELOPDPatReg();
    DALIPDDesk ObjDALIpd = new DALIPDDesk();
    DALIpdRegistration objDALIpdReg = new DALIpdRegistration();
    DALIPDDesk objDalIpdDesk = new DALIPDDesk();
    BELOPDPatReg objBELOpdReg = new BELOPDPatReg();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
          //  BindTime();
            txtdischargedate.Text = System.DateTime.Now.ToShortDateString();
            int RegId = Convert.ToInt32(Request.QueryString["PatRegID"]);
            int IpdId = Convert.ToInt32(Request.QueryString["IpdNo"]);
            FillIpdPatInfo(RegId, IpdId);
            DateTime time = DateTime.Now;
            String s = time.ToString("hh:mm tt");
            txtTime.Text = s;
        }
    }
    public void FillIpdPatInfo(int RegId, int IpdId)
    {
        objBELIpd.IpdId = IpdId;
        objBELIpd.PatRegId = RegId;
        objBELIpd.FId = Convert.ToInt32(Session["FId"]);
        objBELIpd.BranchId = Convert.ToInt32(Session["Branchid"]);
        objBELIpd = ObjDALIpd.GetIpdPatientInformation(objBELIpd);
        lblPatCat.Text = Convert.ToString(objBELIpd.PatMainType);
        lblPatientName.Text = Convert.ToString(objBELIpd.PatientName);
        lblAdmissionDate.Text = Convert.ToString(objBELIpd.EntryDate);
        lblIpd.Text = Convert.ToString(objBELIpd.IpdNo);
        lblPatRegId.Text = Convert.ToString(objBELIpd.PatRegId);
        lblBillNo.Text = Convert.ToString(objBELIpd.IpdNo);
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["Branchid"]) == "")
        {
            Response.Redirect("~/Login.aspx", false);
            return;
        }
        if (Convert.ToString(Session["Branchid"]) == "0")
        {
            Response.Redirect("~/Login.aspx", false);
            return;
        }
        if (Convert.ToString(Session["Branchid"]) == null)
        {
            Response.Redirect("~/Login.aspx", false);
            return;
        }
        if (ddlreasonofdisc.SelectedItem.Text != "")
        {
            objBELOpdReg.FId = Convert.ToInt32(Session["FId"]);
            objBELOpdReg.BranchId = Convert.ToInt32(Session["Branchid"]);
            objBELOpdReg.CreatedBy = Convert.ToString(Session["username"]);
            objBELOpdReg.BedId = Convert.ToInt32(Request.QueryString["BedId"]); ;
            objBELOpdReg.PatRegId = Convert.ToInt32(Request.QueryString["PatRegID"]);
            objBELOpdReg.IpdNo = Convert.ToInt32(Request.QueryString["IpdNo"]);
            //objBELOpdReg.DischargeDateTime = txtdischargedate.Text;
            if (txtdischargedate.Text != "")
            {
                objBELOpdReg.DischargeDateTime = DateTime.Parse(txtdischargedate.Text).ToString("MM/dd/yyyy");
            }
            objBELOpdReg.DischargeReason = ddlreasonofdisc.SelectedItem.Text;
            //objBELOpdReg.DischargeTime = DdlDischargeTime.SelectedItem.Text + " " + ddlampm.SelectedItem.Text;
            objBELOpdReg.DischargeTime = txtTime.Text;
            objDALIpdReg.InsertUpdateBedAllocationInfo_Discharge(objBELOpdReg);
            lblMessage.Text = "Discharged succssfully!!!";
        }
        else
        {
            ddlreasonofdisc.Focus();
            lblMessage.Text = "Select Reason for discharge!!!";
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {

    }
    protected void btnReport_Click(object sender, EventArgs e)
    {
        string sql = "";

        BLLReports objreports = new BLLReports();
        int IpdId = Convert.ToInt32(Request.QueryString["IpdNo"]);
        int PatRegId = Convert.ToInt32(Request.QueryString["PatRegID"]);
        int BranchId = Convert.ToInt32(Session["Branchid"]);
        int FId = Convert.ToInt32(Session["FId"]);

        objreports.IpdBillDetails(IpdId, PatRegId, FId, BranchId);

        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Reports/Rpt_IpdBillDetails.rpt");
        Session["reportname"] = "IpdBillDetails_Report";
        Session["RPTFORMAT"] = "pdf";


        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);


    }
    protected void btnSummary_Click(object sender, EventArgs e)
    {
        string sql = "";

        BLLReports objreports = new BLLReports();
        int IpdId = Convert.ToInt32(Request.QueryString["IpdNo"]);
        int PatRegId = Convert.ToInt32(Request.QueryString["PatRegID"]);
        int BranchId = Convert.ToInt32(Session["Branchid"]);
        int FId = Convert.ToInt32(Session["FId"]);

        //objreports.IpdBillSummary(IpdId, PatRegId);

        //Session.Add("rptsql", sql);
        //Session["rptname"] = Server.MapPath("~/Reports/Rpt_IpdBillSummary.rpt");
        //Session["reportname"] = "IpdBillSummary_Report";
        //Session["RPTFORMAT"] = "pdf";

        objreports.IpdBillDetails(IpdId, PatRegId, FId, BranchId);
        Session.Add("rptsql", sql);
        // Session["rptname"] = Server.MapPath("~/Reports/Rpt_IpdBillSummary.rpt");
        Session["rptname"] = Server.MapPath("~/Reports/Rpt_IpdBillDetails_summary.rpt");
        Session["reportname"] = "IpdBillSummary_Report";
        Session["RPTFORMAT"] = "pdf";

        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);


    }
    //public void PindPatientInformation()
    //{
    //    DataTable dt = new DataTable();
    //    dt = obj.Get_AllPatientInformation(Convert.ToString(Session["EmrRegNo"]), Convert.ToString(Session["EmrOpdNo"]), 0, Convert.ToInt32(Session["Branchid"]));
    //    try
    //    {
    //        if (dt != null)
    //        {
    //            lblPatientName.Text = Convert.ToString(dt.Rows[0]["PatientName"]);
    //            txtpatientregid.Text = Convert.ToString(dt.Rows[0]["PatRegId"]);
               
    //            lblOpd.Text = Convert.ToString(dt.Rows[0]["PatRegId"]);
    //            lblMobileNo.Text = Convert.ToString(dt.Rows[0]["MobileNo"]);
    //           // lbldrname.Text = Convert.ToString(dt.Rows[0]["DrName"]);
    //            lblAge.Text = Convert.ToString(dt.Rows[0]["Age"]) + "" + Convert.ToString(dt.Rows[0]["AgeType"]) + "/" + Convert.ToString(dt.Rows[0]["GenderName"]);
    //            ViewState["Age"] = Convert.ToString(dt.Rows[0]["Age"]);
    //            ViewState["AgeType"] = Convert.ToString(dt.Rows[0]["AgeType"]);

    //        }
            
    //    }
    //    catch (Exception ex)
    //    {

    //    }
    //}
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
        DdlDischargeTime.Items.Clear();
      
        while (StartTime <= EndTime)
        {
            DdlDischargeTime.Items.Add(StartTime.ToShortTimeString());
           
            StartTime = StartTime.Add(Interval);
        }
        DdlDischargeTime.Items.Insert(0, new ListItem("--Select--", "0"));
       
    }
}