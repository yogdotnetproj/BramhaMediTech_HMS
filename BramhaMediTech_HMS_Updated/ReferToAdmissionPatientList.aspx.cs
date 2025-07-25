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

public partial class ReferToAdmissionPatientList :BasePage
{
    BELPatientInformation objBELPatInfo = new BELPatientInformation();
    DALPatientInformation objDALPatInfo = new DALPatientInformation();
    BLLReports ObjDOReport = new BLLReports();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {


            // txtEntryDate.Text = DateTime.Now.ToShortDateString();
            txtToDate.Text = System.DateTime.Now.AddDays(2).ToShortDateString();
            txtFromDate.Text = System.DateTime.Now.ToShortDateString();
            FillCancelPatientRegGrid();



        }
    }

    protected void FillCancelPatientRegGrid()
    {
        

        ViewState["FromDate"] = Convert.ToDateTime(txtFromDate.Text).ToString("yyyy-MM-dd");
        ViewState["ToDate"] = Convert.ToDateTime(txtToDate.Text).ToString("yyyy-MM-dd");
        gvPatientInfo.DataSource = objDALPatInfo.FillReferToAdmissionPatientList(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]));
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
    protected void gvPatientInfo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Refer")
        {
            //Determine the RowIndex of the Row whose Button was clicked.
            int rowIndex = Convert.ToInt32(e.CommandArgument);

            //Reference the GridView Row.
            GridViewRow row = gvPatientInfo.Rows[rowIndex];

            string regId = gvPatientInfo.Rows[rowIndex].Cells[0].Text;
            string OPDNO = gvPatientInfo.Rows[rowIndex].Cells[1].Text;
            string DrId = gvPatientInfo.Rows[rowIndex].Cells[7].Text;
            string response = @"~/IPDDesk.aspx?PatientInfoID=" + regId + "&OpdNo=" + OPDNO + "&ReferToAdmi=" + DrId + "&ReferToAdmit=YES";
          //  Response.Redirect("~/IPDDesk.aspx?PatientInfoID=" + Convert.ToString(ViewState["PatientInfoID"]), false);
            Response.Redirect(string.Format(response));
        }

    }
    protected void gvPatientInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex != -1)
        {
            string PatientAdmit = Convert.ToString((e.Row.FindControl("HdnPatientAdmit") as HiddenField).Value);
            if (PatientAdmit == "Yes")
            {
                e.Row.Cells[11].Text = "<span class='btn btn-xs btn-success' >Yes</span>";
                e.Row.Cells[12].Enabled = false;
            }
            else
            {
                e.Row.Cells[11].Text = "<span class='btn btn-xs btn-danger' >No</span>";
            }
        }
    }
}