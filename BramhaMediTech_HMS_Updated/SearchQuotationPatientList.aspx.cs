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

public partial class SearchQuotationPatientList : BasePage
{
    BLLReports ObjDOReport = new BLLReports();
    BELOPDPatReg objBELOpdReg = new BELOPDPatReg();
    DALOpdReg objDALOpdReg = new DALOpdReg();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtFrom.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtTo.Text = DateTime.Now.ToString("dd/MM/yyyy");
            FillUsers();
            FillPatientList();
        }
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

    }
    public void FillPatientList()
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
        string PatName = "0";
        if (txtPatientName.Text != "")
        {
            PatName=txtPatientName.Text ;
        }
       
        DataTable dt = new DataTable();
        dt = objDALOpdReg.FillQuotationPatientList(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), BranchId, FId, PatName, txtBillNo.Text);
       gvPatientInfo.DataSource = dt;
       gvPatientInfo.DataBind();
    }
    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchPatient(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        return objDALOpdReg.FillAllPatient(prefixText);
    }
    protected void txtPatientName_TextChanged(object sender, EventArgs e)
    {
        //if (txtPatientName.Text != "")
        //{
        //    string[] PatientInfo = txtPatientName.Text.Split('-');
        //    txtPatientName.Text = PatientInfo[1];
        //    ViewState["PatientInfoId"] = PatientInfo[0];
        //}
        //else
        //{
        //    ViewState["PatientInfoId"] = 0;
        //}
    }
    protected void gvPatientInfo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        BLLReports objreports = new BLLReports();
        string sql = "";
        
        if (e.CommandName == "Report")
        {

            //Determine the RowIndex of the Row whose Button was clicked.
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            //Reference the GridView Row.
            GridViewRow row = gvPatientInfo.Rows[rowIndex];
            int BillNo = Convert.ToInt32(gvPatientInfo.DataKeys[rowIndex].Values["BillNo"]);
            int PatRegId = Convert.ToInt32(gvPatientInfo.DataKeys[rowIndex].Values["PatRegId"]);
            int ProcedureId = Convert.ToInt32(gvPatientInfo.DataKeys[rowIndex].Values["ProcedureId"]);

            int BranchId = Convert.ToInt32(Session["Branchid"]);
            int FId = Convert.ToInt32(Session["FId"]);

            objreports.GetProcedureBillDetails(BillNo, PatRegId,ProcedureId, FId, BranchId);

            Session.Add("rptsql", sql);
            Session["rptname"] = Server.MapPath("~/Reports/Rpt_ProcedureBillReport.rpt");//Rpt_ProcedureBillDetails
            Session["reportname"] = "ProcedureBillDetails_Report";
            Session["RPTFORMAT"] = "pdf";


            string close = "<script language='javascript'>javascript:OpenReport();</script>";
            Type title1 = this.GetType();
            Page.ClientScript.RegisterStartupScript(title1, "", close);



        }

        if (e.CommandName == "CasePaper")
        {

            //Determine the RowIndex of the Row whose Button was clicked.
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            //Reference the GridView Row.
            GridViewRow row = gvPatientInfo.Rows[rowIndex];
           // int BillNo = Convert.ToInt32(gvPatientInfo.DataKeys[rowIndex].Values["BillNo"]);
           // int PatRegId = Convert.ToInt32(gvPatientInfo.DataKeys[rowIndex].Values["PatRegId"]);
            int ProcedureId = Convert.ToInt32(gvPatientInfo.DataKeys[rowIndex].Values["ProcedureId"]);

            int BranchId = Convert.ToInt32(Session["Branchid"]);
            int FId = Convert.ToInt32(Session["FId"]);



            Alter_view( ProcedureId);
           
            BLLReports objBLLReports = new BLLReports();

            Session.Add("rptsql", sql);
            Session["rptname"] = Server.MapPath("~/Reports/Rpt_Quotation_Report.rpt");
            Session["reportname"] = "Quotation_Report";
            Session["RPTFORMAT"] = "pdf";


            string close = "<script language='javascript'>javascript:OpenReport();</script>";
            Type title1 = this.GetType();
            Page.ClientScript.RegisterStartupScript(title1, "", close);
            //ReportParameterClass.SelectionFormula = sql;
          



        }
        if (e.CommandName == "DataForm")
        {

            //Determine the RowIndex of the Row whose Button was clicked.
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            //Reference the GridView Row.
            GridViewRow row = gvPatientInfo.Rows[rowIndex];
            int BillNo = Convert.ToInt32(gvPatientInfo.DataKeys[rowIndex].Values["BillNo"]);
            int PatRegId = Convert.ToInt32(gvPatientInfo.DataKeys[rowIndex].Values["PatRegId"]);
            int ProcedureId = Convert.ToInt32(gvPatientInfo.DataKeys[rowIndex].Values["ProcedureId"]);

            int BranchId = Convert.ToInt32(Session["Branchid"]);
            int FId = Convert.ToInt32(Session["FId"]);

            Alter_view_DataForm(PatRegId);
         
            BLLReports objBLLReports = new BLLReports();

            Session.Add("rptsql", sql);
            Session["rptname"] = Server.MapPath("~/Report/Rpt_GetDataForm_New.rpt");
            Session["reportname"] = "Rpt_GetDataForm_New";
            Session["RPTFORMAT"] = "pdf";

            //ReportParameterClass.SelectionFormula = sql;
            string close = "<script language='javascript'>javascript:OpenReport();</script>";
            Type title1 = this.GetType();
            Page.ClientScript.RegisterStartupScript(title1, "", close);
        }
       
    }

       protected void gvPatientInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
       {
           gvPatientInfo.PageIndex = e.NewPageIndex;
           FillPatientList();
       }
       protected void btnSearch_Click(object sender, EventArgs e)
       {
           FillPatientList();
       }

       public void Alter_view(int Patregid, int ProcedureId)
       {
           string sql = "";
           SqlConnection con = DataAccess.ConInitForDC();
           SqlCommand cmd1 = con.CreateCommand();

           string query = "ALTER VIEW [dbo].[VW_OPDCasePaper_New] AS (SELECT DISTINCT  " +
                             "  Initial.Title + ' ' + PatientInformation.FirstName AS FirstName, ProcedureBillMaster.ChargeNumber as RegistrationType, OpdRegistration.ReferenceDoc, OpdRegistration.FId, OpdRegistration.BranchId, OpdRegistration.PatientComplaints, " +
                             "  OpdRegistration.OpdNo, HospEmpMst.Title + ' ' + HospEmpMst.Empname AS Empname, OpdRegistration.TokenNo, Initial.Title, Gender.GenderName, DepartmentMst.DeptName, HospEmpMst.Title AS DrInitial, " +
                             "  PatientInformation.PatientAddress, PatientInformation.MobileNo, PatMainType.PatMainType, CAST(PatientInformation.Age AS nvarchar(50)) + ' ' + PatientInformation.AgeType AS AgeType, OpdRegistration.VaccinationStatus,  " +
                             "  ProcedureBillMaster.BillAmount, ProcedureBillMaster.AmountPaid, ProcedureBillMaster.InsuranceAmt, ProcedureBillMaster.BillNo, ProcedureBillMaster.LetterNo, ProcedureBillMaster.TypeOfVisit,  " +
                             "  ProcedureServiceDetails.BillServiceCharges, ProcedureServiceDetails.Qty, ProcedureServiceDetails.TotalCharges, BillService.ServiceName, ProcedureServiceDetails.CreatedOn, ProcedureServiceDetails.CreatedBy,  " +
                             "  ProcedureBillMaster.PatRegId, ProcedureBillMaster.BillGroup, PatientInsuType.PatientInsuType, PatientInsu_SubType.ChildCompanyName, PatientInsu_SubType.CompanyDescription, PatientInformation.BirthDate,  " +
                             "  PatientInformation.Email,PatientInformation.ChiefComplant " +
                             //"  FROM            ProcedureServiceDetails INNER JOIN " +
                             //"  ProcedureBillMaster INNER JOIN " +
                             //"  ProcedurePaymentTrns ON ProcedureBillMaster.ProcedureId = ProcedurePaymentTrns.ProcedureId AND ProcedureBillMaster.PatRegId = ProcedurePaymentTrns.PatRegId ON  " +
                             //"  ProcedureServiceDetails.PatRegId = ProcedureBillMaster.PatRegId AND ProcedureServiceDetails.ProcedureId = ProcedureBillMaster.ProcedureId INNER JOIN " +
                             //"  BillService ON ProcedureServiceDetails.BillServiceId = BillService.BillServiceId INNER JOIN " +
                             //"  PatMainType ON ProcedureBillMaster.PatientMainType = PatMainType.PatMainTypeId INNER JOIN " +
                             //"  Initial INNER JOIN " +
                             //"  PatientInformation ON Initial.TitleId = PatientInformation.TitleId INNER JOIN " +
                             //"  Gender ON PatientInformation.GenderId = Gender.GenderId ON ProcedureBillMaster.PatRegId = PatientInformation.PatRegId INNER JOIN " +
                             //"  PatientInsuType ON ProcedureBillMaster.PatientSubType = PatientInsuType.PatientInsuTypeId LEFT OUTER JOIN " +
                             //"  HospEmpMst ON ProcedureServiceDetails.DrId = HospEmpMst.DrId LEFT OUTER JOIN " +
                             //"  PatientInsu_SubType ON ProcedureBillMaster.InsuranceChargeCompamt = PatientInsu_SubType.ID LEFT OUTER JOIN " +
                             //"  DepartmentMst INNER JOIN " +
                             //"  OpdRegistration ON DepartmentMst.DeptId = OpdRegistration.DeptId ON ProcedureBillMaster.OPDNo = OpdRegistration.OpdNo AND " +
                             //"  ProcedureBillMaster.PatRegId = OpdRegistration.PatRegId " +
                              "  FROM            ProcedureServiceDetails INNER JOIN "+
                              "      ProcedureBillMaster INNER JOIN "+
                               "     ProcedurePaymentTrns ON ProcedureBillMaster.ProcedureId = ProcedurePaymentTrns.ProcedureId AND ProcedureBillMaster.PatRegId = ProcedurePaymentTrns.PatRegId ON "+
                               "     ProcedureServiceDetails.PatRegId = ProcedureBillMaster.PatRegId AND ProcedureServiceDetails.ProcedureId = ProcedureBillMaster.ProcedureId INNER JOIN "+
                               "     BillService ON ProcedureServiceDetails.BillServiceId = BillService.BillServiceId INNER JOIN "+
                               "     PatMainType ON ProcedureBillMaster.PatientMainType = PatMainType.PatMainTypeId INNER JOIN "+
                               "     Initial INNER JOIN "+
                               "     PatientInformation ON Initial.TitleId = PatientInformation.TitleId INNER JOIN "+
                               "     Gender ON PatientInformation.GenderId = Gender.GenderId ON ProcedureBillMaster.PatRegId = PatientInformation.PatRegId INNER JOIN "+
                               "     PatientInsuType ON ProcedureBillMaster.PatientSubType = PatientInsuType.PatientInsuTypeId LEFT OUTER JOIN "+
                               "     ChargeBill_Master ON ProcedureBillMaster.PatRegId = ChargeBill_Master.Patregid LEFT OUTER JOIN "+
                               "     HospEmpMst ON ProcedureServiceDetails.DrId = HospEmpMst.DrId LEFT OUTER JOIN "+
                               "     PatientInsu_SubType ON ProcedureBillMaster.InsuranceChargeCompamt = PatientInsu_SubType.ID LEFT OUTER JOIN "+
                               "     DepartmentMst INNER JOIN "+
                               "     OpdRegistration ON DepartmentMst.DeptId = OpdRegistration.DeptId ON ProcedureBillMaster.OPDNo = OpdRegistration.OpdNo AND "+
                               "     ProcedureBillMaster.PatRegId = OpdRegistration.PatRegId " +
           " where ProcedureBillMaster.branchid=" + Convert.ToInt32(Session["Branchid"]) + "  and ProcedureBillMaster.ProcedureID= " + Convert.ToInt32(ProcedureId) + " and  ProcedureBillMaster.PatRegId= " + Convert.ToInt32(Patregid) + "";
           //if (txtFrom.Value != "" && txtTo.Value != "")
           //{
           //    query += " and    DagnosisAssigtTpPatient.CreatedOn between ('" + Convert.ToDateTime(txtFrom.Value).ToString("MM/dd/yyyy") + "') and ('" + Convert.ToDateTime(txtTo.Value).AddDays(1).ToString("MM/dd/yyyy") + "')";
           //}



           cmd1.CommandText = query + ")";

           con.Open();
           cmd1.ExecuteNonQuery();
           con.Close(); con.Dispose();
       }


       public void Alter_view(int ProcedureId)
       {
           string sql = "";
           SqlConnection con = DataAccess.ConInitForDC();
           SqlCommand cmd1 = con.CreateCommand();

           string query = "ALTER VIEW [dbo].[VW_Quotation_Report] AS (SELECT DISTINCT  " +
                             " QuotationBillMaster.ProcedureId, QuotationBillMaster.PatRegId, QuotationBillMaster.PatientName, QuotationBillMaster.Age, QuotationBillMaster.AgeType, QuotationBillMaster.MobileNo, QuotationBillMaster.PatAddress, " +
                             "  QuotationBillMaster.DrName, QuotationBillMaster.BillAmount, QuotationBillMaster.FId, QuotationBillMaster.BranchId, QuotationBillMaster.CreatedBy, QuotationBillMaster.CreatedOn, QuotationBillMaster.UpdatedBy, " +
                             "  QuotationBillMaster.UpdatedOn, BillService.ServiceName, QuotionServiceDetails.BillServiceId, QuotionServiceDetails.BillServiceCharges, QuotionServiceDetails.Qty, QuotionServiceDetails.TotalCharges " +
                             "  FROM            QuotationBillMaster INNER JOIN " +
                             "  QuotionServiceDetails ON QuotationBillMaster.ProcedureId = QuotionServiceDetails.ProcedureId INNER JOIN " +
                             "  BillService ON QuotionServiceDetails.BillServiceId = BillService.BillServiceId  where QuotationBillMaster.ProcedureId=" + Convert.ToInt32(ProcedureId) + " ";
           // " where ProcedureBillMaster.branchid=" + Convert.ToInt32(Session["Branchid"]) + "  and ProcedureBillMaster.OpdNo= " + Convert.ToInt32(ViewState["OpdNo"]) + " and  ProcedureBillMaster.PatRegId= " + Convert.ToInt32(ViewState["PatientInfoId"]) + "";



           cmd1.CommandText = query + ")";

           con.Open();
           cmd1.ExecuteNonQuery();
           con.Close(); con.Dispose();
       }

       public void Alter_view_DataForm(int Patregid)
       {
           string sql = "";
           SqlConnection con = DataAccess.ConInitForDC();
           SqlCommand cmd1 = con.CreateCommand();

           string query = "ALTER VIEW [dbo].[VW_GetDataForm] AS (SELECT        PatientInformation.PatientInfoId, PatientInformation.PatRegId, PatientInformation.BarcodeId, PatientInformation.TitleId, PatientInformation.FirstName, PatientInformation.MiddleName, PatientInformation.LastName, " +
                             "  PatientInformation.PatMainTypeId, PatientInformation.PatientInsuTypeId, PatientInformation.PolicyNo, PatientInformation.GenderId, PatientInformation.BirthDate, PatientInformation.IsConfirmBirthDate, " +
                             "  PatientInformation.BloodGroup, PatientInformation.MaritalStatus, PatientInformation.GuardianTitleId, PatientInformation.GuardianName, PatientInformation.MobileNo, PatientInformation.PhoneNo, " +
                             "  PatientInformation.PatientAddress, PatientInformation.CountryId, PatientInformation.StateId, PatientInformation.CityId, PatientInformation.Email, PatientInformation.EntryDate, PatientInformation.ImagePath, " +
                             "  PatientInformation.CancelReason, PatientInformation.IsActive, PatientInformation.CreatedBy, PatientInformation.CreatedOn, PatientInformation.UpdatedBy, PatientInformation.UpdatedOn, PatientInformation.Age, " +
                             "  PatientInformation.AgeType, PatientInformation.BranchId, PatientInformation.FId, PatientInformation.Nationality, PatientInformation.BirthPlace, PatientInformation.VaccinationStatus, PatientInformation.Allergy,  " +
                             "  PatientInformation.ChiefComplant, PatientInformation.ReligionId, PatientInformation.HealthCardNo, PatientInformation.PassportNo, PatientInformation.RaceId, PatientInformation.Relation, PatientInformation.RelativeName, " +
                             "  PatientInformation.ContactNo, PatientInformation.RelaAddress, PatientInformation.Relation1, PatientInformation.RelativeName1, PatientInformation.ContactNo1, PatientInformation.RelaAddress1, Tbl_Race.RaceName, " +
                             "  ReligionMst.Religion, Gender.GenderName, Tbl_Relation.RelationName, Tbl_Relation_1.RelationName AS RelationName2 " +
                             " FROM            PatientInformation LEFT OUTER JOIN " +
                             "  Tbl_Relation ON PatientInformation.Relation = Tbl_Relation.RelationId LEFT OUTER JOIN " +
                             "  Tbl_Relation AS Tbl_Relation_1 ON PatientInformation.Relation1 = Tbl_Relation_1.RelationId LEFT OUTER JOIN " +
                             "  Gender ON PatientInformation.GenderId = Gender.GenderId LEFT OUTER JOIN " +
                             "  ReligionMst ON PatientInformation.ReligionId = ReligionMst.ReligionID LEFT OUTER JOIN " +
                             "  Tbl_Race ON PatientInformation.RaceId = Tbl_Race.RaceID " +
           " where PatientInformation.branchid=" + Convert.ToInt32(Session["Branchid"]) + "  and  PatientInformation.PatRegId= " + Convert.ToInt32(Patregid) + "";
           //if (txtFrom.Value != "" && txtTo.Value != "")
           //{
           //    query += " and    DagnosisAssigtTpPatient.CreatedOn between ('" + Convert.ToDateTime(txtFrom.Value).ToString("MM/dd/yyyy") + "') and ('" + Convert.ToDateTime(txtTo.Value).AddDays(1).ToString("MM/dd/yyyy") + "')";
           //}



           cmd1.CommandText = query + ")";

           con.Open();
           cmd1.ExecuteNonQuery();
           con.Close(); con.Dispose();
       }
       protected void gvPatientInfo_RowDataBound(object sender, GridViewRowEventArgs e)
       {
           if (e.Row.RowIndex != -1)
           {
               //float balance;
               //if (e.Row.Cells[9].Text == "&nbsp;")
               //{
               //    balance = 0;
               //}
               //else
               //{
               //    balance = Convert.ToSingle(e.Row.Cells[9].Text);
               //}
               //if (balance > 0)
               //{
               //    e.Row.Cells[0].Text = "<span class='btn btn-xs btn-danger' >Pending</span>";
               //}
               //else
               //{
               //    // e.Row.Cells[0].Enabled = false;
               //    e.Row.Cells[0].Text = "<span class='btn btn-xs btn-success' >Done</span>";
               //}
           }
       }
}