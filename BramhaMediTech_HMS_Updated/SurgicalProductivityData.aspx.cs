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

public partial class SurgicalProductivityData : System.Web.UI.Page
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
        Session["rptname"] = Server.MapPath("~/Reports/Rpt_SurgicalProductivityData.rpt");
        Session["reportname"] = "SurgicalProductivityData";
        Session["RPTFORMAT"] = "EXCEL";


        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        Alterview();
        Session.Add("rptsql", "");
        Session["rptname"] = Server.MapPath("~/Reports/Rpt_SurgicalProductivityData.rpt");
        Session["reportname"] = "SurgicalProductivityData";
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


        string query = "ALTER VIEW [dbo].[VW_SurgicalProductivityData] AS (SELECT        OTRegisterDetails.OTId, OTRegisterDetails.Patregid, OTRegisterDetails.IPDNO, OTRegisterDetails.Surgan, OTRegisterDetails.ANAESTHETIST, OTRegisterDetails.FirstAssistant, OTRegisterDetails.SecondAssistant,   " +
                      "  OTRegisterDetails.TrollyNurse, OTRegisterDetails.SteriNurse, OTRegisterDetails.Disease, OTRegisterDetails.Operation, OTRegisterDetails.SwabCountNurse, OTRegisterDetails.InstrumentCountNurse,   "+
                      "  OTRegisterDetails.SwabCountNurse2, OTRegisterDetails.InstrumentCountNurse2, OTRegisterDetails.OperationStartDate, OTRegisterDetails.OperationStartTime, OTRegisterDetails.OperationEndDate,   "+
                      "  OTRegisterDetails.OperationEndTime, OTRegisterDetails.AnisticTime, OTRegisterDetails.Remark, OTRegisterDetails.GeneralOT, OTRegisterDetails.Branchid, OTRegisterDetails.FID, OTRegisterDetails.Createdby,   "+
                      "  OTRegisterDetails.CreatedOn, OTRegisterDetails.UpdatedBy, OTRegisterDetails.UpdatedOn, OTRegisterDetails.ASA, OTRegisterDetails.OTClass, OperationMst.OperationName,   "+
                      "  HospEmpMst.Title+' '+ HospEmpMst.Empname as DrName,  "+
                      "  Month(OTRegisterDetails.Createdon) as SurgicalMonth,Year(OTRegisterDetails.Createdon) as SurgicalYear,  IpdRegistration.DeptId,DepartmentMst.DeptName "+
                      "  FROM OTRegisterDetails INNER JOIN "+
                      "  OperationMst ON OTRegisterDetails.Operation = OperationMst.OperationId INNER JOIN "+
                      "  HospEmpMst ON OTRegisterDetails.Surgan = HospEmpMst.DrId INNER JOIN "+
                      "  IpdRegistration ON OTRegisterDetails.IPDNO = IpdRegistration.IpdNo AND OTRegisterDetails.Patregid = IpdRegistration.PatRegId INNER JOIN "+
                      "  DepartmentMst ON IpdRegistration.DeptId = DepartmentMst.DeptId where Year(OTRegisterDetails.Createdon)="+ddlYear.SelectedValue+"  ";
        cmd1.CommandText = query + ")";
        conrp.Open();
        cmd1.ExecuteNonQuery();
        conrp.Close(); conrp.Dispose();
    }
}