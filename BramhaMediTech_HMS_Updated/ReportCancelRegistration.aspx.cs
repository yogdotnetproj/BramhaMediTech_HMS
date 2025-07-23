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

public partial class ReportCancelRegistration : System.Web.UI.Page
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
            FillCancelPatientRegGrid();



        }
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
            ObjDOReport.Get_CancelReport(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]));

            Session.Add("rptsql", sql);
            Session["rptname"] = Server.MapPath("~/Reports/Rpt_UserWiseLabCashCancelReport.rpt");
            Session["reportname"] = "UserWiseLABCashCancel_Report";
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