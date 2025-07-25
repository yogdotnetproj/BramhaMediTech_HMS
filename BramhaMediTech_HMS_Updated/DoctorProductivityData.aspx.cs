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

public partial class DoctorProductivityData :BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlYear.SelectedValue = DateTime.Now.Year.ToString();
        }
    }
    protected void btnExcel_Click(object sender, EventArgs e)
    {
        Alterview();
        Session.Add("rptsql", "");
        Session["rptname"] = Server.MapPath("~/Reports/Rpt_DoctorProductivityData.rpt");
        Session["reportname"] = "DoctorProductivityData";
        Session["RPTFORMAT"] = "EXCEL";


        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        Alterview();
        Session.Add("rptsql", "");
        Session["rptname"] = Server.MapPath("~/Reports/Rpt_DoctorProductivityData.rpt");
        Session["reportname"] = "DoctorProductivityData";
        Session["RPTFORMAT"] = "pdf";


        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);
    }
    public void Alterview()
    {
        SqlConnection conrp = DataAccess.ConInitForDC();
        SqlCommand cmd1 = conrp.CreateCommand();


        //string query = "ALTER VIEW [dbo].[VW_GetAllInsurance] AS (SELECT        PatRegId, PatientInsuType, BillAmount, AmountPaid, Discount, InsuranceAmt, case when  BillGroup='EEG OPD' then 'EEGOPD' else BillGroup end as BillGroup, BillNo, FId, BranchId, CreatedBy, CreatedOn, PatientSubType, FirstName "+
        //              "  FROM          Vw_InsuranceSummaryForProcedure "+
        //              "  union all "+
        //              "  select Patregid,PatientInsuType,BillAmount,amtpaid,DiscountAmt,InsuranceAmount,case   when  BillGroup='Medical Store' then 'MedicalLab' when  BillGroup='Medical Lab' then 'MedicalLab' else BillGroup end as BillGroup,BillNo,FID,BranchId,CreatedBy,createdon,PatientSubCategoryId,Firstname " +
        //              "  from Vw_InsuranceSummaryForLabNew "+
        //              "  union all "+
        //              "  select  Patregno,'',GrandTotal,AmountReceived,DiscAmt,InsuranceAmount,'Pharmacy' as billgroup, BillNo,FID,BranchId,CreatedBy,CreatedOn, PatientSubType,PatientName "+
        //              "  from tbl_PharmacyInsuranceAmt where insuranceAmount>0 ";


        string query = "ALTER VIEW [dbo].[VW_DoctorProductivityData] AS (SELECT        OpdRegistration.OpdNo, OpdRegistration.TokenNo, OpdRegistration.PatRegId, OpdRegistration.DrId, OpdRegistration.VisitingNo, OpdRegistration.Entrydate, OpdRegistration.RegistrationType, OpdRegistration.ReferenceDoc, "+
                  "  OpdRegistration.DeptId, OpdRegistration.PatientComplaints, OpdRegistration.PatientMainCategoryId, OpdRegistration.PatientSubCategoryId, OpdRegistration.FId, OpdRegistration.BranchId, OpdRegistration.CreatedBy, "+
                  "  OpdRegistration.CreatedOn, OpdRegistration.UpdatedBy, OpdRegistration.UpdatedOn, OpdRegistration.IsPatientChecked, OpdRegistration.VaccinationStatus, OpdRegistration.LetterNo, OpdRegistration.TypeOfVisit, "+
                  "  OpdRegistration.IsCancel, OpdRegistration.TriageCriteria, OpdRegistration.ReferBy, OpdRegistration.UpdatedBy1, "+
                  "  HospEmpMst.Title+' '+ HospEmpMst.Empname as DrName,  "+
                  "  Month(OpdRegistration.Createdon) as SurgicalMonth,Year(OpdRegistration.Createdon) as SurgicalYear  "+
                  "  FROM            OpdRegistration INNER JOIN "+
                  "  HospEmpMst ON OpdRegistration.DrId = HospEmpMst.DrId "+
                  "  WHERE        (ISNULL(OpdRegistration.IsCancel, 0) = 0)and Year(OpdRegistration.Createdon)=" + ddlYear.SelectedValue + "  ";
        cmd1.CommandText = query + ")";
        conrp.Open();
        cmd1.ExecuteNonQuery();
        conrp.Close(); conrp.Dispose();
    }
}