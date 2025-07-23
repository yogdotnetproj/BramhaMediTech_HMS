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

public partial class ProcedureBillGroupSalesReport : System.Web.UI.Page
{
    BELBillInfo ObjBELBillInfo = new BELBillInfo();
    DALBillInfo ObjDALBillInfo = new DALBillInfo();
    BLLReports ObjDOReport = new BLLReports();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtFrom.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtTo.Text = DateTime.Now.ToString("dd/MM/yyyy");
            fillgrid();

        }
    }
    public void fillgrid()
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
        dt = ObjDOReport.FillGroupwiseIncomeGrid_Procedure(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), BranchId, FId);
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
    public void AlterviewL()
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

        string query = "ALTER VIEW [dbo].[VW_GetLabeServiceName_TempLab] AS (SELECT * from  LabServiceDetails  " +
                " where (CAST(CAST(YEAR(Createdon) AS varchar(4)) + '/' + CAST(MONTH(Createdon) AS varchar(2)) + '/' + CAST(DAY(Createdon) AS varchar(2)) AS datetime)) between '" + ViewState["FromDate"] + "'  and '" + ViewState["ToDate"] + "' ";

        cmd1.CommandText = query + ")";
        conrp.Open();
        cmd1.ExecuteNonQuery();
        conrp.Close(); conrp.Dispose();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Alterview();
       // AlterviewL();
        BLLReports objreports = new BLLReports();
        if (txtFrom.Text.ToString() != "")
        {
            ViewState["FromDate"] = txtFrom.Text.ToString() ;

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
      //  objreports.FillLABIncomeReport(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), "0", Convert.ToInt32(0), "R", BranchId, FId, "Select Bank", "");
      //  objreports.FillLABIncomeReport_L(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), "0", Convert.ToInt32(0), "M", BranchId, FId, "Select Bank", "");

        fillgrid();
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

                    if (RdbServices.SelectedValue == "DoctorWise")
                    {
                        Session.Add("rptsql", sql);
                        Session["rptname"] = Server.MapPath("~/Reports/Rpt_DoctorwiseBillGroupIncome_Procedure.rpt");
                        Session["reportname"] = "DoctorwiseBillGroupIncome_Procedure_Report";
                        Session["RPTFORMAT"] = "pdf";


                        string close = "<script language='javascript'>javascript:OpenReport();</script>";
                        Type title1 = this.GetType();
                        Page.ClientScript.RegisterStartupScript(title1, "", close);
                    }

                    if (RdbServices.SelectedValue == "PatientWise")
                    {
                        Session.Add("rptsql", sql);
                        Session["rptname"] = Server.MapPath("~/Reports/Rpt_PatientwiseBillGroupIncome_Procedure.rpt");
                        Session["reportname"] = "PatientwiseBillGroupIncome_Procedure_Report";
                        Session["RPTFORMAT"] = "pdf";

                        string close = "<script language='javascript'>javascript:OpenReport();</script>";
                        Type title1 = this.GetType();
                        Page.ClientScript.RegisterStartupScript(title1, "", close);
                    }

                    if (RdbServices.SelectedValue == "ServiceWise")
                    {

                        Session.Add("rptsql", sql);
                        Session["rptname"] = Server.MapPath("~/Reports/Rpt_ServicewiseBillGroupIncome_Procedure.rpt");
                        Session["reportname"] = "ServicewiseBillGroupIncome_Procedure_Report";
                        Session["RPTFORMAT"] = "pdf";

                        string close = "<script language='javascript'>javascript:OpenReport();</script>";
                        Type title1 = this.GetType();
                        Page.ClientScript.RegisterStartupScript(title1, "", close);
                    }
                
        }
    }
    protected void btnPrint_Click(object sender, EventArgs e)
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
}