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
using System.IO;
using System.Drawing;

public partial class IPDDashboardReport : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        }
    }

    protected void btnfrontsheetreport_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        BLLReports objReports = new BLLReports();
        int IpdId = Convert.ToInt32(Request.QueryString["IpdNo"]);
        int FId = Convert.ToInt32(Session["FId"]);
        int BranchId = Convert.ToInt32(Session["Branchid"]);
        ReportDocument CrystalReport = new ReportDocument();
        CrystalReport.Load(Server.MapPath("~/Report/Rpt_AdmissionFrontSheet.rpt"));
        ds = objReports.GetIpdPatientCard(IpdId, FId, BranchId);
        CrystalReport.SetDataSource(ds);

        try
        {

            CrystalReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Employee");
        }
        catch (Exception ex)
        {
        }
        finally
        {
            CrystalReport.Close();
            ((IDisposable)CrystalReport).Dispose();
            GC.Collect();
            GC.SuppressFinalize(CrystalReport);
        }



    }
    protected void btnVitalSheet_Click(object sender, EventArgs e)
    {
        SqlConnection conrpV = DataAccess.ConInitForDC();
        SqlCommand cmd1V = conrpV.CreateCommand();
        string queryV = "ALTER VIEW [dbo].[Vw_IPDVitalSignForm] AS (SELECT DISTINCT VitalSignForm.Vid, VitalSignForm.PatregId, VitalSignForm.OpdNo, VitalSignForm.IpdNo, VitalSignForm.Temprature, VitalSignForm.BP, VitalSignForm.HR, VitalSignForm.RR, VitalSignForm.Spo2, VitalSignForm.Inspired, "+
              "  VitalSignForm.RRScore, VitalSignForm.UrineScore, VitalSignForm.CNScore, VitalSignForm.BranchId, VitalSignForm.CreatedBy, VitalSignForm.CreatedOn, VitalSignForm.UpdatedBy, VitalSignForm.UpdatedOn, VitalSignForm.FId, "+
              "  VitalSignForm.DateInput, VitalSignForm.TimeInput, VitalSignForm.VitalRemark, VitalSignForm.Systolic, VitalSignForm.Diastolic, PatientInformation.FirstName, PatientInformation.LastName, Gender.GenderName, "+
              "  PatientInformation.BirthDate, PatientInformation.MobileNo, PatientInformation.PhoneNo, PatientInformation.PatientAddress, PatientInformation.Email,Initial.Title " +
              "  FROM VitalSignForm INNER JOIN "+
              "  PatientInformation ON VitalSignForm.PatregId = PatientInformation.PatRegId INNER JOIN "+
              "  Gender ON PatientInformation.GenderId = Gender.GenderId INNER JOIN "+
              "  Initial ON PatientInformation.TitleId = Initial.TitleId " +
              " where VitalSignForm.IpdNo=" + Convert.ToInt32(Request.QueryString["IpdNo"]) + "  and dbo.VitalSignForm.PatRegId=" + Convert.ToInt32(Request.QueryString["RegId"]) + " ";

        cmd1V.CommandText = queryV + ")";
        conrpV.Open();
        cmd1V.ExecuteNonQuery();
        conrpV.Close(); conrpV.Dispose();

        Session.Add("rptsql", "");
        Session["rptname"] = Server.MapPath("~/Report/Rpt_IPDVitalSignForm.rpt");
        Session["reportname"] = "IPDVitalSignReport";
        Session["RPTFORMAT"] = "pdf";

        //ReportParameterClass.SelectionFormula = sql;
        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);
    }
    protected void btnIntake_Click(object sender, EventArgs e)
    {
        string sql = "";
        BELIntakeOutputChart objBELIO = new BELIntakeOutputChart();
        DALInputOutPutChart objDALIO = new DALInputOutPutChart();
            objBELIO.OpdNo = 0;
        
        
            objBELIO.IpdNo = Convert.ToInt32(Request.QueryString["IpdNo"]);
       
        objBELIO.Patregid = Convert.ToInt32(Request.QueryString["RegId"]);
        objDALIO.Alter_Vw_IntakeOutputSheet(objBELIO);
        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Report/Rpt_IntakeOutputChart.rpt");
        Session["reportname"] = "Rpt_IntakeOutputChart";
        Session["RPTFORMAT"] = "pdf";

        //ReportParameterClass.SelectionFormula = sql;
        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);
    }
    protected void btnNurseNote_Click(object sender, EventArgs e)
    {
        BELIntakeOutputChart objBELIO = new BELIntakeOutputChart();
        DALInputOutPutChart objDALIO = new DALInputOutPutChart();
        string sql = "";
       
        objBELIO.OpdNo = 0;   
        objBELIO.IpdNo = Convert.ToInt32(Request.QueryString["IpdNo"]);
        objBELIO.Patregid = Convert.ToInt32(Request.QueryString["RegId"]);
        objDALIO.Alter_Vw_DailyNurseNote(objBELIO);
        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Report/Rpt_DailyNurseNotes.rpt");
        Session["reportname"] = "Rpt_DailyNurseNotes";
        Session["RPTFORMAT"] = "pdf";

        //ReportParameterClass.SelectionFormula = sql;
        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);
    }
    protected void btndrNote_Click(object sender, EventArgs e)
    {
        SqlConnection conrpV = DataAccess.ConInitForDC();
        SqlCommand cmd1V = conrpV.CreateCommand();
        string queryV = "ALTER VIEW [dbo].[Vw_IPDDrDailyNote] AS (SELECT DISTINCT PatientInformation.FirstName, PatientInformation.LastName, Gender.GenderName, PatientInformation.BirthDate, PatientInformation.MobileNo, PatientInformation.PhoneNo, PatientInformation.PatientAddress, " +
                  "  PatientInformation.Email, Initial.Title, IPDDrDailyNote.Id, IPDDrDailyNote.Patregid, IPDDrDailyNote.IpdNo, IPDDrDailyNote.DrNote, IPDDrDailyNote.Createdby, IPDDrDailyNote.CreatedOn, IPDDrDailyNote.UpdatedBy, "+
                  "  IPDDrDailyNote.Updatedon, IPDDrDailyNote.Branchid, IPDDrDailyNote.Fid, IPDDrDailyNote.DrBy, IPDDrDailyNote.DrPlan, IPDDrDailyNote.Diagnosis, IPDDrDailyNote.Remarks, IPDDrDailyNote.InvestigationDetails, "+
                  "  IPDDrDailyNote.TreatmentDetails "+
                  "  FROM            IPDDrDailyNote INNER JOIN "+
                  "  PatientInformation ON IPDDrDailyNote.Patregid = PatientInformation.PatRegId INNER JOIN "+
                  "  Gender ON PatientInformation.GenderId = Gender.GenderId INNER JOIN "+
                  "  Initial ON PatientInformation.TitleId = Initial.TitleId " +
              " where IPDDrDailyNote.IpdNo=" + Convert.ToInt32(Request.QueryString["IpdNo"]) + "  and dbo.IPDDrDailyNote.PatRegId=" + Convert.ToInt32(Request.QueryString["RegId"]) + " ";

        cmd1V.CommandText = queryV + ")";
        conrpV.Open();
        cmd1V.ExecuteNonQuery();
        conrpV.Close(); conrpV.Dispose();

        Session.Add("rptsql", "");
        Session["rptname"] = Server.MapPath("~/Report/Rpt_IPDDrDailyNote.rpt");
        Session["reportname"] = "IPDDrDailyNote";
        Session["RPTFORMAT"] = "pdf";

        //ReportParameterClass.SelectionFormula = sql;
        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);
    }
    protected void btnOtNoteReport_Click(object sender, EventArgs e)
    {
        BLLReports objreports = new BLLReports();
        ReportDocument crystalReport = new ReportDocument();
        DataSet OtNotes = new DataSet();

        crystalReport.Load(Server.MapPath("~/Report/Rpt_OTNotes.rpt"));
        int IpdId = Convert.ToInt32(Request.QueryString["IpdNo"]);
        int PatRegId = Convert.ToInt32(Request.QueryString["RegId"]);
        int BranchId = Convert.ToInt32(Session["Branchid"]);
        int FId = Convert.ToInt32(Session["FId"]);

        OtNotes = objreports.GetOperationNotes_Report(IpdId, PatRegId, FId, BranchId);
        crystalReport.SetDataSource(OtNotes);
        //crystalReport.ParameterFields["HospitalName"].CurrentValues.AddValue(Convert.ToString(Application["OrgnizationName"]));
        //crystalReport.ParameterFields["HospitalAddress"].CurrentValues.AddValue(Convert.ToString(Application["OrgnizationAddress"]));
        //crystalReport.ParameterFields["ReportFooter"].CurrentValues.AddValue("Hospital Software | Ph.020 123456789");
        crystalReport.ExportToHttpResponse
        (CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "OtNotes");

        //try
        //{

        //    crystalReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Employee");
        //}
        //catch (Exception ex)
        //{
        //}
        //finally
        //{
        //    crystalReport.Close();
        //    ((IDisposable)crystalReport).Dispose();
        //    GC.Collect();
        //    GC.SuppressFinalize(crystalReport);
        //}
    }
    protected void btnInvestigation_Click(object sender, EventArgs e)
    {

    }
    protected void btnTreatment_Click(object sender, EventArgs e)
    {

        SqlConnection conrpIT = DataAccess.ConInitForDC();
        SqlCommand cmd1IT = conrpIT.CreateCommand();
        string queryIT = "ALTER VIEW [dbo].[Vw_IPDTreatmentList] AS (SELECT        tbl_Treatment.TreatmentId, tbl_Treatment.FollowUpDate, tbl_Treatment.PatientRegId, tbl_Treatment.Opd, tbl_Treatment.Ipd, tbl_Treatment.BranchId, tbl_Treatment.CreatedBy, tbl_Treatment.CreatedOn, tbl_Treatment.UpdatedBy, "+
              "  tbl_Treatment.UpdatedOn, tbl_Treatment.DrId, tbl_Treatment.ReceiveToPharma, tbl_Treatment.EntryDate, tbl_Treatment.IsEmergency, tbl_Treatment.PaymentStatus, tbl_Treatment.IsApproveByNurse, "+
              "  tbl_Treatment.DiscMedication, tbl_Treatment.PostpoTreat, tbl_Treatment.WardName, tbl_Treatment.MackAddress, tbl_Treatment.PresPrintBy, tbl_Treatment.PrintOn, tbl_Treatment.ReasonForPrint, "+
              "  tbl_TreatmentTransaction.DrugName, tbl_TreatmentTransaction.FrequencyType, tbl_TreatmentTransaction.Days, tbl_TreatmentTransaction.StartDate, tbl_TreatmentTransaction.EndDate, tbl_TreatmentTransaction.Note, "+
              "  tbl_TreatmentTransaction.Dose, tbl_TreatmentTransaction.DoseId, tbl_TreatmentTransaction.DoseTimeId, tbl_TreatmentTransaction.ItemId, tbl_TreatmentTransaction.IsEmergency AS Expr1, tbl_TreatmentTransaction.Qty, "+
              "  tbl_TreatmentTransaction.NurseOrder, tbl_TreatmentTransaction.Vital, tbl_TreatmentTransaction.Diet, tbl_TreatmentTransaction.QtyML, tbl_TreatmentTransaction.InstName, tbl_TreatmentTransaction.NewDose, "+
              "  tbl_TreatmentTransaction.Route, PatientInformation.FirstName, PatientInformation.LastName, Gender.GenderName, PatientInformation.BirthDate, PatientInformation.MobileNo, PatientInformation.PatientAddress, "+
              "  PatientInformation.Age, PatientInformation.AgeType, Initial.Title "+
              "  FROM            tbl_Treatment INNER JOIN "+
              "  tbl_TreatmentTransaction ON tbl_Treatment.TreatmentId = tbl_TreatmentTransaction.TreatmentId INNER JOIN "+
              "  PatientInformation ON tbl_Treatment.PatientRegId = PatientInformation.PatRegId INNER JOIN "+
              "  Gender ON PatientInformation.GenderId = Gender.GenderId INNER JOIN "+
              "  Initial ON PatientInformation.TitleId = Initial.TitleId " +
         " where tbl_Treatment.Ipd=" + Convert.ToInt32(Request.QueryString["IpdNo"]) + "  and dbo.tbl_Treatment.PatientRegId=" + Convert.ToInt32(Request.QueryString["RegId"]) + " ";

        cmd1IT.CommandText = queryIT + ")";
        conrpIT.Open();
        cmd1IT.ExecuteNonQuery();
        conrpIT.Close(); conrpIT.Dispose();


        Session.Add("rptsql", "");
        Session["rptname"] = Server.MapPath("~/Report/Rpt_IPDTreatmentList.rpt");
        Session["reportname"] = "IPDTreatmentList";
        Session["RPTFORMAT"] = "pdf";

        //ReportParameterClass.SelectionFormula = sql;
        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);
    }
    protected void btndischargesummary_Click(object sender, EventArgs e)
    {
        BLLReports objreports = new BLLReports();
        //int IpdId = Convert.ToInt32(IpdId);
        int PatRegId = Convert.ToInt32(Request.QueryString["RegId"]);
        int BranchId = Convert.ToInt32(Session["Branchid"]);
        int FId = Convert.ToInt32(Session["FId"]);
        AlterView_VE_GetLabNo(Convert.ToString(Request.QueryString["IpdNo"]));
        //VW_DescriptiveViewLogic.SP_Getresultnondesc_Report(Convert.ToInt32(Session["Branchid"]), ViewTestCode, Request.QueryString["PatRegID"], Request.QueryString["FID"]);
        // SP_Getresultnondesc_Report();
        // SP_Getresultnondesc_Report(BranchId,Convert.ToString( Request.QueryString["IpdId"]),Convert.ToString(Session["FId"]));
        // SP_Getresultdesc_Report(BranchId, Convert.ToString(Request.QueryString["IpdId"]), Convert.ToString(Session["FId"]));
        objreports.IpdDischrge_Summary_Report(Convert.ToInt32(Request.QueryString["IpdNo"]), PatRegId, FId, BranchId);


        Session.Add("rptsql", "");
        // Session["rptname"] = Server.MapPath("~/Reports/Rpt_DischargeSummaryReport.rpt");
        Session["rptname"] = Server.MapPath("~/Reports/Rpt_DischargeSummaryReport.rpt");
        Session["reportname"] = "DischargeSummaryReport";
        Session["RPTFORMAT"] = "pdf";


        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);
    }
    public void AlterView_VE_GetLabNo(string IPDNO)
    {
        int i;
        SqlConnection conn = DataAccess.ConInitForPathology();
        SqlCommand sc = conn.CreateCommand();
        sc.CommandText = "ALTER VIEW [dbo].[VW_GetLabNo]AS (select  LabNo,patmst.PatRegID,MTCode,patmst.Branchid,patmst.FID FROM   patmstd INNER JOIN patmst ON patmstd.PatRegID = patmst.PatRegID AND patmstd.PID = patmst.PID  where  patmst.IPDNO='" + IPDNO + "'  and patmst.branchid ='" + Convert.ToInt32(Session["Branchid"]) + "' and  patmst.FID ='" + Convert.ToString(Session["FId"]) + "' )";
        try
        {
            conn.Open();
            sc.ExecuteNonQuery();

        }
        catch (Exception exx)
        { }
        finally
        {
            try
            {

                conn.Close();
                conn.Dispose();
            }
            catch (SqlException)
            {
                // Log an event in the Application Event Log.
                throw;
            }

        }




    }
}