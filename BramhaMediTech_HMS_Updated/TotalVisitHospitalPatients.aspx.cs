using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Services;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using CrystalDecisions.CrystalReports.Engine;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.Collections;

public partial class TotalVisitHospitalPatients : System.Web.UI.Page
{
    BELPatientInformation objBELPatInfo = new BELPatientInformation();
    DALPatientInformation objDALPatInfo = new DALPatientInformation();
    BLLReports ObjDOReport = new BLLReports();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {


            // txtEntryDate.Text = DateTime.Now.ToShortDateString();
            txtToDate.Text = System.DateTime.Now.ToShortDateString();
            txtFromDate.Text = System.DateTime.Now.ToShortDateString();
            BindTime();
            FillCancelPatientRegGrid();



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
        if (txtFromDate.Text.ToString() != "")
        {
            ViewState["FromDate"] = Convert.ToDateTime(txtFromDate.Text).ToString("MM/dd/yyyy") + " " + ddlTimeFrom.Text; ;

        }
        else
        {
            ViewState["FromDate"] = "";
        }
        if (txtToDate.Text.ToString() != "")
        {

            ViewState["ToDate"] = Convert.ToDateTime(txtToDate.Text).ToString("MM/dd/yyyy") + " " + ddlTimeTo.Text;


        }
        else
        {
            ViewState["ToDate"] = "";
        }

        string query = "ALTER VIEW [dbo].[VW_TotalVisitHospitalPatients] AS (SELECT        'New Patients' AS PatMainType, FirstName, 'New Registration' AS BillGroup, PatRegId, MobileNo, PhoneNo, PatientAddress, Email, Age, AgeType,CreatedOn ,''as Empname " +
          "  FROM            PatientInformation " +
            // "  WHERE        (CAST(CAST(YEAR(CreatedOn) AS varchar(4)) + '/' + CAST(MONTH(CreatedOn) AS varchar(2)) + '/' + CAST(DAY(CreatedOn) AS varchar(2)) AS datetime) BETWEEN  '" + ViewState["FromDate"] + "'  and '" + ViewState["ToDate"] + "' ) " +
         "  WHERE     CreatedOn   BETWEEN  '" + ViewState["FromDate"] + "'  and '" + ViewState["ToDate"] + "'  " +
          "  union all " +
          "  SELECT  distinct PatMainType.PatMainType, PatientInformation.FirstName, ProcedureBillMaster.BillGroup, ProcedureBillMaster.PatRegId, MobileNo, PhoneNo, PatientAddress, PatientInformation.Email, Age, AgeType " +
          "  ,ProcedureBillMaster.CreatedOn , HospEmpMst.Empname" +
          "  FROM            ProcedureBillMaster INNER JOIN "+
          "  PatMainType ON ProcedureBillMaster.PatientMainType = PatMainType.PatMainTypeId INNER JOIN "+
          "  PatientInformation ON ProcedureBillMaster.PatRegId = PatientInformation.PatRegId INNER JOIN "+
          "  ProcedureServiceDetails ON ProcedureBillMaster.PatRegId = ProcedureServiceDetails.PatRegId AND ProcedureBillMaster.ProcedureId = ProcedureServiceDetails.ProcedureId LEFT OUTER JOIN "+
          "  HospEmpMst ON ProcedureServiceDetails.DrId = HospEmpMst.DrId " +
            // "  where  (CAST(CAST(YEAR(dbo.ProcedureBillMaster.CreatedOn) AS varchar(4)) + '/' + CAST(MONTH(dbo.ProcedureBillMaster.CreatedOn) AS varchar(2)) + '/' + CAST(DAY(dbo.ProcedureBillMaster.CreatedOn) AS varchar(2)) AS datetime)) between  '" + ViewState["FromDate"] + "'  and '" + ViewState["ToDate"] + "'  " +
          "  WHERE     ProcedureBillMaster.CreatedOn   BETWEEN  '" + ViewState["FromDate"] + "'  and '" + ViewState["ToDate"] + "'  " +
          "  union all " +
          "  SELECT  PatMainType.PatMainType, PatientInformation.FirstName, case when LabRegistration.LabPtype='M' then 'Medical Lab' when LabRegistration.LabPtype='R' then 'Radiology' else 'Laboratory' end  as BillGroup, LabRegistration.PatRegId " +
          "  , MobileNo, PhoneNo, PatientAddress, Email, Age, AgeType,LabRegistration.CreatedOn, LabRegistration.ReferBy " +
          "  FROM  LabRegistration INNER JOIN " +
          "  PatMainType ON LabRegistration.PatientMainCategoryId = PatMainType.PatMainTypeId INNER JOIN " +
          "  PatientInformation ON LabRegistration.PatRegId = PatientInformation.PatRegId " +
            //where  (CAST(CAST(YEAR(dbo.LabRegistration.CreatedOn) AS varchar(4)) + '/' + CAST(MONTH(dbo.LabRegistration.CreatedOn) AS varchar(2)) + '/' + CAST(DAY(dbo.LabRegistration.CreatedOn) AS varchar(2)) AS datetime)) between '09/04/2023' and '09/04/2023' " +
            //       " where (CAST(CAST(YEAR(LabRegistration.Createdon) AS varchar(4)) + '/' + CAST(MONTH(LabRegistration.Createdon) AS varchar(2)) + '/' + CAST(DAY(LabRegistration.Createdon) AS varchar(2)) AS datetime)) between '" + ViewState["FromDate"] + "'  and '" + ViewState["ToDate"] + "' ";
        "  WHERE      LabRegistration.BillNo>0 and LabRegistration.CreatedOn   BETWEEN  '" + ViewState["FromDate"] + "'  and '" + ViewState["ToDate"] + "' "+
         "    union all   "+
         "   SELECT        PatMainType.PatMainType, PatientInformation.FirstName, 'Admission' AS BillGroup, IpdRegistration.PatRegId, PatientInformation.MobileNo, PatientInformation.PhoneNo, PatientInformation.PatientAddress, "+
         "   PatientInformation.Email, PatientInformation.Age, PatientInformation.AgeType, IpdRegistration.CreatedOn, HospEmpMst.Empname "+
         "   FROM            IpdRegistration INNER JOIN "+
         "   PatMainType ON IpdRegistration.PatientMainCategoryId = PatMainType.PatMainTypeId INNER JOIN "+
         "   PatientInformation ON IpdRegistration.PatRegId = PatientInformation.PatRegId INNER JOIN "+
         "   HospEmpMst ON IpdRegistration.PrimaryDoc = HospEmpMst.DrId where IpdRegistration.CreatedOn   BETWEEN  '" + ViewState["FromDate"] + "'  and '" + ViewState["ToDate"] + "' ";
        cmd1.CommandText = query + ")";
        conrp.Open();
        cmd1.ExecuteNonQuery();
        conrp.Close(); conrp.Dispose();
    }
    protected void FillCancelPatientRegGrid()
    {
        

        ViewState["FromDate"] = Convert.ToDateTime(txtFromDate.Text).ToString("yyyy-MM-dd");
        ViewState["ToDate"] = Convert.ToDateTime(txtToDate.Text).ToString("yyyy-MM-dd");       
        gvPatientInfo.DataSource = objDALPatInfo.FillCancelPatientGrid(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]));
        gvPatientInfo.DataBind();
    }




    
    protected void gvPatientInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvPatientInfo.PageIndex = e.NewPageIndex;
        FillCancelPatientRegGrid();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        FillCancelPatientRegGrid();
        Reset();
    }

    private void Reset()
    {

        
    }



    protected void btnPrint_Click(object sender, EventArgs e)
    {
        string sql = "";

        try
        {

            if (txtFromDate.Text.ToString() != "")
            {
                ViewState["FromDate"] = txtFromDate.Text.ToString();

            }
            else
            {
                ViewState["FromDate"] = "";
            }
            if (txtToDate.Text.ToString() != "")
            {

                ViewState["ToDate"] = txtToDate.Text.ToString();


            }
            else
            {
                ViewState["ToDate"] = "";
            }
            int BranchId = Convert.ToInt32(Session["BranchId"]);
            int FId = Convert.ToInt32(Session["FId"]);
            Alterview();
           // ObjDOReport.Get_CancelReport(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]));

            Session.Add("rptsql", sql);
            Session["rptname"] = Server.MapPath("~/Reports/Rpt_TotalVisitHospitalPatients.rpt");
            Session["reportname"] = "TotalVisitHospitalPatients";
            Session["RPTFORMAT"] = "pdf";


            string close = "<script language='javascript'>javascript:OpenReport();</script>";
            Type title1 = this.GetType();
            Page.ClientScript.RegisterStartupScript(title1, "", close);


        }
        catch (Exception ex)
        {
          //  lblMessage.Text = ex.Message;
        }
    }
}