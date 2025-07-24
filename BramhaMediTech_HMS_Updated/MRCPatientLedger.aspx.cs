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

public partial class MRCPatientLedger : BasePage
{
    BELPatientInformation objBELPatInfo = new BELPatientInformation();
    DALPatientInformation objDALPatInfo = new DALPatientInformation();
    BLLReports ObjDOReport = new BLLReports();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {


            // txtEntryDate.Text = DateTime.Now.ToShortDateString();
           // txtToDate.Text = System.DateTime.Now.ToShortDateString();
          //  txtFromDate.Text = System.DateTime.Now.ToShortDateString();
           // FillCancelPatientRegGrid();



        }
    }

    protected void FillCancelPatientRegGrid()
    {
        

       // ViewState["FromDate"] = Convert.ToDateTime(txtFromDate.Text).ToString("yyyy-MM-dd");
       // ViewState["ToDate"] = Convert.ToDateTime(txtToDate.Text).ToString("yyyy-MM-dd");       
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

            //if (txtFromDate.Text.ToString() != "")
            //{
            //    ViewState["FromDate"] = txtFromDate.Text.ToString();

            //}
            //else
            //{
            //    ViewState["FromDate"] = "";
            //}
            //if (txtToDate.Text.ToString() != "")
            //{

            //    ViewState["ToDate"] = txtToDate.Text.ToString();


            //}
            //else
            //{
            //    ViewState["ToDate"] = "";
            //}
            int BranchId = Convert.ToInt32(Session["BranchId"]);
            int FId = Convert.ToInt32(Session["FId"]);
           // ObjDOReport.Get_CancelReport(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]));
            Alterview();
            Session.Add("rptsql", sql);
            Session["rptname"] = Server.MapPath("~/Reports/Rpt_MRCPatientLedger.rpt");
            Session["reportname"] = "MRCPatientLedger";
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
    public void Alterview()
    {
        SqlConnection conrp = DataAccess.ConInitForDC();
        SqlCommand cmd1 = conrp.CreateCommand();
        

        string query = "ALTER VIEW [dbo].[VW_MRCPatientLedger] AS (SELECT DISTINCT top(99.99) percent "+
                      "  IpdBillMaster.PatRegId, ISNULL(IpdBillMaster.BillAmount, 0) AS BillAmount, IpdBillMaster.AmountReceived, IpdBillMaster.BalancebroughtForward, IpdBillMaster.MRCRecAmt, IpdRegistration.SurgeryType, "+
                      "  PatientInformation.FirstName, month( IpdBillMaster.CreatedOn) as AdmitMonth, Year( IpdBillMaster.CreatedOn) as AdmitYear, "+
                      "  DATENAME(month,  IpdBillMaster.CreatedOn)+'-'+ cast( Year( IpdBillMaster.CreatedOn)as nvarchar(50)) as AdmitYearMonth, "+ddlYear.SelectedValue+" as SelectYear  "+
                      "  FROM            IpdBillMaster INNER JOIN "+
                      "  IpdRegistration ON IpdBillMaster.PatRegId = IpdRegistration.PatRegId INNER JOIN "+
                      "  PatientInformation ON IpdRegistration.PatRegId = PatientInformation.PatRegId " +
            //where  (CAST(CAST(YEAR(dbo.LabRegistration.CreatedOn) AS varchar(4)) + '/' + CAST(MONTH(dbo.LabRegistration.CreatedOn) AS varchar(2)) + '/' + CAST(DAY(dbo.LabRegistration.CreatedOn) AS varchar(2)) AS datetime)) between '09/04/2023' and '09/04/2023' " +
            //       " where (CAST(CAST(YEAR(LabRegistration.Createdon) AS varchar(4)) + '/' + CAST(MONTH(LabRegistration.Createdon) AS varchar(2)) + '/' + CAST(DAY(LabRegistration.Createdon) AS varchar(2)) AS datetime)) between '" + ViewState["FromDate"] + "'  and '" + ViewState["ToDate"] + "' ";
        "  WHERE  Year( IpdBillMaster.CreatedOn)=" + ddlYear.SelectedValue + " and   (IpdRegistration.SurgeryType = 'Resident Care(Mercy)') ";
        cmd1.CommandText = query + ")";
        conrp.Open();
        cmd1.ExecuteNonQuery();
        conrp.Close(); conrp.Dispose();
    }
    protected void btnExcel_Click(object sender, EventArgs e)
    {
        string sql = "";

        try
        {

            //if (txtFromDate.Text.ToString() != "")
            //{
            //    ViewState["FromDate"] = txtFromDate.Text.ToString();

            //}
            //else
            //{
            //    ViewState["FromDate"] = "";
            //}
            //if (txtToDate.Text.ToString() != "")
            //{

            //    ViewState["ToDate"] = txtToDate.Text.ToString();


            //}
            //else
            //{
            //    ViewState["ToDate"] = "";
            //}
            int BranchId = Convert.ToInt32(Session["BranchId"]);
            int FId = Convert.ToInt32(Session["FId"]);
            // ObjDOReport.Get_CancelReport(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]));
            Alterview();
            Session.Add("rptsql", sql);
            Session["rptname"] = Server.MapPath("~/Reports/Rpt_MRCPatientLedger.rpt");
            Session["reportname"] = "MRCPatientLedger";
            Session["RPTFORMAT"] = "EXCEL";


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