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

public partial class AdmiteddischargeData : System.Web.UI.Page
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
        Session["rptname"] = Server.MapPath("~/Reports/Rpt_AdmitDischargeProductivityData.rpt");
        Session["reportname"] = "AdmissionDischargeData";
        Session["RPTFORMAT"] = "EXCEL";


        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        Alterview();
        Session.Add("rptsql", "");
        Session["rptname"] = Server.MapPath("~/Reports/Rpt_AdmitDischargeProductivityData.rpt");
        Session["reportname"] = "AdmissionDischargeData";
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


        string query = "ALTER VIEW [dbo].[VW_AdmitDischargeProdictivityData] AS (SELECT  'Discharge Count' as PatientType,      IpdRegistration.IpdId, IpdRegistration.IpdNo, IpdRegistration.PatRegId,isnull(Month( AlloctnOfBed.DateOfDischarge),0) as EntryMonth " +
                 "   , case when isnull(Month( AlloctnOfBed.DateOfDischarge),0)>0 then 1 else 0 end as PatientCount "+
                 "   FROM            IpdRegistration INNER JOIN AlloctnOfBed ON IpdRegistration.IpdId = AlloctnOfBed.IpdId AND IpdRegistration.PatRegId = AlloctnOfBed.PatRegId AND IpdRegistration.IpdNo = AlloctnOfBed.IpdNo "+
                 "   WHERE        (IpdRegistration.SurgeryType <> 'Resident Care(Mercy)') AND (IpdRegistration.CancelAdmission = 0) and AlloctnOfBed.PatStatus='Discharged' "+
                 "   and  Year( AlloctnOfBed.DateOfDischarge)=" + ddlYear.SelectedValue + " " +
                 "   union all "+
                 "   SELECT    'Admission Count' as PatientType,       IpdRegistration.IpdId, IpdRegistration.IpdNo, IpdRegistration.PatRegId,ISNULL(MONTH(IpdRegistration.EntryDate), 0) AS EntryMonth, " +
                 "     case when isnull(Month( IpdRegistration.EntryDate),0)>0 then 1 else 0 end as PatientCount "+
                 "   FROM            IpdRegistration "+
                 "   WHERE        (IpdRegistration.SurgeryType <> 'Resident Care(Mercy)') and  (IpdRegistration.CancelAdmission = 0) and Year(IpdRegistration.EntryDate)=" + ddlYear.SelectedValue + "  ";
                            cmd1.CommandText = query + ")";
        conrp.Open();
        cmd1.ExecuteNonQuery();
        conrp.Close(); conrp.Dispose();
    }
}