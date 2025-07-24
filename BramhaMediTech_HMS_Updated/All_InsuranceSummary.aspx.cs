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

public partial class All_InsuranceSummary : BasePage
{
    BELOPDPatReg objBELOpdReg = new BELOPDPatReg();
    DALOpdReg objDALOpdReg = new DALOpdReg();
    BELEmpReg objBELEmpReg = new BELEmpReg();
    DALEmpReg objDALEmpReg = new DALEmpReg();
    DALIPDDesk objDalIpdDesk = new DALIPDDesk();
    BLLReports objreports = new BLLReports();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ViewState["InsuranceId"] = 0;
            txtStart.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtEnd.Text = DateTime.Now.ToString("dd/MM/yyyy");
          //  FillRoomCategory();
           // refreshdata();
        }
    }

    //protected void FillRoomCategory()
    //{
    //    ddlRoomCategory.DataSource = objDalIpdDesk.FillRoomTypes(Convert.ToInt32(Session["FId"]), Convert.ToInt32(Session["BranchId"]));
    //    ddlRoomCategory.DataTextField = "RType";
    //    ddlRoomCategory.DataValueField = "RTypeId";
    //    ddlRoomCategory.DataBind();
    //    ddlRoomCategory.Items.Insert(0, new ListItem("Select Room", "0"));
    //}

    public void refreshdata()
    {
        DataTable dt = new DataTable();

        using (SqlConnection con = DataAccess.ConInitForDC())
        {
            using (SqlCommand cmd = new SqlCommand("usp_GetInsuranceSummaryForProcedure", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FId", Convert.ToInt32(Session["FId"]));
                cmd.Parameters.AddWithValue("@BranchId", Convert.ToInt32(Session["Branchid"]));
                cmd.Parameters.AddWithValue("@PatRegId", Convert.ToInt32(ViewState["PatientInfoId"]));
                cmd.Parameters.AddWithValue("@InsuranceId", Convert.ToInt32(ViewState["InsuranceId"]));
                cmd.Parameters.AddWithValue("@BillGroup", ddlBillGroup.SelectedValue);                
                cmd.Parameters.AddWithValue("@start", txtStart.Text);
                cmd.Parameters.AddWithValue("@end", txtEnd.Text);
                con.Open();

                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(dt);
                }

                con.Close();
                con.Dispose();
            }
            gvPatientInfo.DataSource = dt;
            gvPatientInfo.DataBind();

        }

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        refreshdata();
    }

    protected void gvPatientInfo_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }

    protected void gvPatientInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvPatientInfo.PageIndex = e.NewPageIndex;
        refreshdata();
    }

    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchPatient(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        return objDALOpdReg.FillAllPatient(prefixText);
    }
    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchInsurance(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        return objDALOpdReg.FillAllInsurance(prefixText);
    }
    protected void txtPatientName_TextChanged(object sender, EventArgs e)
    {

        string[] PatientInfo = txtPatientName.Text.Split('-');
        if (PatientInfo.Length > 1)
        {
            txtPatientName.Text = PatientInfo[1];
            ViewState["PatientInfoId"] = PatientInfo[0];
        }

    }
    protected void Print_Click(object sender, EventArgs e)
    {
        string sql = "";


        int BranchId = Convert.ToInt32(Session["BranchId"]);
        int FId = Convert.ToInt32(Session["FId"]);
        int PatRegId = Convert.ToInt32(ViewState["PatientInfoId"]);
        
        string start = txtStart.Text;
        string end = txtEnd.Text;
        int InsuranceId = Convert.ToInt32(ViewState["InsuranceId"]);
        string InsuranceName = Convert.ToString(ViewState["InsuranceName"]);
        string BillGroup = ddlBillGroup.SelectedValue;

        objreports.InsuranceSummaryForProcedure(start, end, PatRegId, BillGroup, InsuranceId, FId, BranchId);
        objreports.InsuranceSummaryForLab(start, end, PatRegId, BillGroup, InsuranceId, FId, BranchId);
        if (BillGroup == "0" || BillGroup == "Pharmacy")
        {
            objreports.InsuranceSummaryForPharmacy(start, end, PatRegId, BillGroup, Convert.ToString( InsuranceId), FId, BranchId);
        }
        objreports.Insert_Trun_PharmacyInsurance();
        objreports.Insert_PharmacyInsurance();
        objreports.Insert_Lab_Insurance();
        Alterview();
        Alterview1();
        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Report/Rpt_AllInsuranceDetails.rpt");
        Session["reportname"] = "AllInsuranceDetails";
        Session["RPTFORMAT"] = "PDF";


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


        string query = "ALTER VIEW [dbo].[VW_GetAllInsurance] AS (SELECT        PatRegId, PatientInsuType, BillAmount, AmountPaid, Discount, InsuranceAmt, case when  BillGroup='EEG OPD' then 'EEGOPD' else BillGroup end as BillGroup, CONVERT(nvarchar(500),BillNo) as BillNo, " +//
        
                    
                     " FId, BranchId, '' as CreatedBy,  CONVERT(DATE, CreatedOn) as CreatedOn, PatientSubType, rtrim(ltrim(Firstname)) as Firstname " +
                     "  FROM          Vw_InsuranceSummaryForProcedure  " +
                     "  union all " +
                     "  select Patregid,PatientInsuType,BillAmount,amtpaid,DiscountAmt,InsuranceAmount, BillGroup,CONVERT(nvarchar(500),BillNo) as BillNo,FID,BranchId,CreatedBy,createdon,PatientSubCategoryId,rtrim(ltrim(Firstname)) as Firstname " +
                     "  from InsuranceSummaryForLabNew_Temp " +
                     "  union all " +
                     "  select  Patregno,InsuranceComp,GrandTotal,AmountReceived,DiscAmt,InsuranceAmount,'Pharmacy' as billgroup, CONVERT(nvarchar(500),BillNo) as BillNo,FID,BranchId,CreatedBy,CreatedOn, PatientSubType,rtrim(ltrim(PatientName)) as PatientName  " +
                     "  from tbl_PharmacyInsuranceAmt where insuranceAmount>0 ";
              cmd1.CommandText = query + ")";
        conrp.Open();
        cmd1.ExecuteNonQuery();
        conrp.Close(); conrp.Dispose();
    }
    public void Alterview1()
    {
        SqlConnection conrp = DataAccess.ConInitForDC();
        SqlCommand cmd1 = conrp.CreateCommand();

        string DateRange = txtStart.Text + " TO " + txtEnd.Text;
        string query = "ALTER VIEW [dbo].[VW_GetAllInsurance_details] AS (select sum(isnull(HOSPITAL,0)) as HOSPITAL, sum(isnull(EEGOPD,0)) as EEGOPD, sum(isnull(OPD,0))as OPD, sum(isnull(EMERGENCY,0))as EMERGENCY, sum(isnull(OPTHAL,0))as OPTHAL, " +
                      "  sum(isnull(AMBULANCE,0))as AMBULANCE,sum(isnull(Radiology,0)) as Radiology,sum(isnull(Pathology,0))as Pathology,sum(isnull(MedicalLab,0)) as MedicalLab,sum(isnull(Pharmacy,0))as Pharmacy,sum(isnull(Consultation,0))as Consultation,Patregid,Firstname,PatientInsuType,CreatedOn,BillNo,DateRange " +
                      "  from "+
                      "  ( "+
                      "    select InsuranceAmt, Patregid,BillGroup,PatientInsuType,Firstname,CONVERT(DATE, CreatedOn) as CreatedOn, '" + DateRange + "' as DateRange " +
                      " ,BillNo = STUFF((SELECT ', ' + convert( nvarchar(550),BillNo)  "+
                      " FROM VW_GetAllInsurance b   WHERE b.Patregid = a.Patregid and CONVERT(DATE, b.CreatedOn)=CONVERT(DATE, a.CreatedOn)  FOR XML PATH('')), 1, 2, '')  " +


                      "      from VW_GetAllInsurance  a"+//-- where PatientInsuType='GTM'
                      "  ) d "+
                      "  pivot "+
                      "  ( "+
                      "    sum(InsuranceAmt) "+
                      "    for BillGroup in (HOSPITAL, EEGOPD, OPD, EMERGENCY, OPTHAL,AMBULANCE,Radiology,Pathology,MedicalLab,Pharmacy,Consultation) " +
                      "  ) piv group by Patregid,Firstname,PatientInsuType,CreatedOn,BillNo,DateRange";

        //string query = "ALTER VIEW [dbo].[VW_GetAllInsurance] AS (SELECT * from  LabServiceDetails  " +
        //       " where (CAST(CAST(YEAR(Createdon) AS varchar(4)) + '/' + CAST(MONTH(Createdon) AS varchar(2)) + '/' + CAST(DAY(Createdon) AS varchar(2)) AS datetime)) between '" + ViewState["FromDate"] + "'  and '" + ViewState["ToDate"] + "' ";

        cmd1.CommandText = query + ")";
        conrp.Open();
        cmd1.ExecuteNonQuery();
        conrp.Close(); conrp.Dispose();
    }
    protected void txtInsuranceid_TextChanged(object sender, EventArgs e)
    {
        if (txtInsuranceid.Text != "")
        {
            string[] InsuranceId = txtInsuranceid.Text.Split('-');
            txtInsuranceid.Text = InsuranceId[1];

            if (txtInsuranceid.Text != "")
            {
                ViewState["InsuranceId"] = InsuranceId[0];
                ViewState["InsuranceName"] = InsuranceId[1];
            }
            else
            {
                ViewState["InsuranceId"] = 0;
                ViewState["InsuranceName"] = "";
            }
        }
        else
        {
            ViewState["InsuranceId"] = 0;
            ViewState["InsuranceName"] = "";
        }
    }
    protected void btnExcel_Click(object sender, EventArgs e)
    {
        string sql = "";


        int BranchId = Convert.ToInt32(Session["BranchId"]);
        int FId = Convert.ToInt32(Session["FId"]);
        int PatRegId = Convert.ToInt32(ViewState["PatientInfoId"]);

        string start = txtStart.Text;
        string end = txtEnd.Text;
        int InsuranceId = Convert.ToInt32(ViewState["InsuranceId"]);
        string InsuranceName = Convert.ToString(ViewState["InsuranceName"]);
        string BillGroup = ddlBillGroup.SelectedValue;

        objreports.InsuranceSummaryForProcedure(start, end, PatRegId, BillGroup, InsuranceId, FId, BranchId);
        objreports.InsuranceSummaryForLab(start, end, PatRegId, BillGroup, InsuranceId, FId, BranchId);
        if (BillGroup == "0" || BillGroup == "Pharmacy")
        {
            objreports.InsuranceSummaryForPharmacy(start, end, PatRegId, BillGroup, Convert.ToString( InsuranceId), FId, BranchId);
        }
        objreports.Insert_Trun_PharmacyInsurance();
        objreports.Insert_PharmacyInsurance();
        objreports.Insert_Lab_Insurance();
        Alterview();
        Alterview1();
        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Report/Rpt_AllInsuranceDetails.rpt");
        Session["reportname"] = "AllInsuranceDetails";
        Session["RPTFORMAT"] = "EXCEL";


        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);
    }
}