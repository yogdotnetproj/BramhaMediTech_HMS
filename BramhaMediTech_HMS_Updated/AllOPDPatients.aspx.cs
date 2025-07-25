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

public partial class AllOPDPatients :BasePage
{

    BELPatientInformation objBELPatInfo = new BELPatientInformation();
    DALPatientInformation objDALPatInfo = new DALPatientInformation();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtFrom.Text = Date.getdate().ToString("dd/MM/yyyy");
            txtTo.Text = Date.getdate().ToString("dd/MM/yyyy");
            Alter_view();
        }
    }
    public void Alter_view()
    {
        string sql = "";
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd1 = con.CreateCommand();

        string query = "ALTER VIEW [dbo].[VW_OpdVisitForWomeans] AS (SELECT DISTINCT " +
               " OpdRegistration.OpdNo, OpdRegistration.TokenNo, OpdRegistration.PatRegId, OpdRegistration.DrId, OpdRegistration.VisitingNo, FORMAT(OpdRegistration.Entrydate, 'dd/MM/yyyy') AS EntryDate, " +
               " OpdRegistration.RegistrationType, OpdRegistration.ReferenceDoc, OpdRegistration.DeptId, OpdRegistration.PatientComplaints, OpdRegistration.PatientMainCategoryId, OpdRegistration.PatientSubCategoryId, " +
               " OpdRegistration.FId, OpdRegistration.BranchId, OpdRegistration.CreatedBy, OpdRegistration.CreatedOn, OpdRegistration.UpdatedBy, OpdRegistration.UpdatedOn, OpdRegistration.IsPatientChecked, " +
               " Initial.Title + ' ' + PatientInformation.FirstName AS PatientName, PatientInformation.GenderId, CAST(PatientInformation.Age AS nvarchar(50)) + ' ' + PatientInformation.AgeType AS PatientAge, " +
               " PatientInformation.TitleId, Gender.GenderName, OpdRegistration.Entrydate AS EntryDateNew, DepartmentMst.DeptName,PatientInformation.FirstName, PatientInformation.MobileNo " +
               " FROM            OpdRegistration INNER JOIN " +
               " PatientInformation ON OpdRegistration.PatRegId = PatientInformation.PatRegId INNER JOIN " +
               " Gender ON PatientInformation.GenderId = Gender.GenderId INNER JOIN " +
               " DepartmentMst ON OpdRegistration.DeptId = DepartmentMst.DeptId LEFT OUTER JOIN " +
               " Initial ON PatientInformation.TitleId = Initial.TitleId  " +
        " where OpdRegistration.branchid=" + Convert.ToInt32(Session["Branchid"]) + " "; // and (PatientInformation.AgeType = 'Years') and ( PatientInformation.Age > 19) and GenderName='Female'
        if (txtFrom.Text != "" && txtTo.Text != "")
        {
            query += " and    OpdRegistration.Entrydate between ('" + Convert.ToDateTime(txtFrom.Text).ToString("MM/dd/yyyy") + "') and ('" + Convert.ToDateTime(txtTo.Text).AddDays(1).ToString("MM/dd/yyyy") + "')";
        }



        cmd1.CommandText = query + ")";

        con.Open();
        cmd1.ExecuteNonQuery();
        con.Close(); con.Dispose();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Alter_view();
        BindGrid();
    }
    public void BindGrid()
    {
        DataTable dt = new DataTable();
        DALPatientInformation ObjDPI = new DALPatientInformation();
        dt = ObjDPI.FillGrid_OpdVisitForWomeans();
        gvDailyCash.DataSource = dt;
        gvDailyCash.DataBind();

    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        string sql = "";
        Alter_view();
        BindGrid();



        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Report/Rpt_OpdVisitForAllPatient.rpt");
        Session["reportname"] = "Rpt_OpdVisitForAllPatient";
        Session["RPTFORMAT"] = "pdf";

        //ReportParameterClass.SelectionFormula = sql;
        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);
    }
    protected void gvDailyCash_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDailyCash.PageIndex = e.NewPageIndex;
        BindGrid();
    }
    protected void gvDailyCash_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void gvDailyCash_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
}