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

public partial class DiscountReport : System.Web.UI.Page
{
    BLLReports ObjDOReport = new BLLReports();
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtFrom.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtTo.Text = DateTime.Now.ToString("dd/MM/yyyy");
            //RdbPayment.SelectedValue = "All";
            FillUsers();
           
           
           

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
    
    protected void txtTo_TextChanged(object sender, EventArgs e)
    {
        ViewState["ToDate"] = txtTo.Text.ToString();
    }
    protected void txtFrom_TextChanged(object sender, EventArgs e)
    {
        ViewState["FromDate"] = txtFrom.Text.ToString();
    }
    

   
    private void Reset()
    {

    }

    protected void Print_Click(object sender, EventArgs e)
    {
        string sql = "";
        BLLReports objreports = new BLLReports();
        try
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
            objreports.Fill_Discount_Report(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), ddlUser.SelectedValue,  BranchId, FId);

            Session.Add("rptsql", sql);
            Session["rptname"] = Server.MapPath("~/Reports/Rpt_DiscountReport.rpt");
            Session["reportname"] = "DiscountReport";
            Session["RPTFORMAT"] = "pdf";


            string close = "<script language='javascript'>javascript:OpenReport();</script>";
            Type title1 = this.GetType();
            Page.ClientScript.RegisterStartupScript(title1, "", close);

            // DALReports objDalReport = new DALReports();
            //DataSet dsCashSummary = new DataSet();
            //ReportDocument crystalReport = new ReportDocument();
            ////crystalReport.Load(Server.MapPath("~/Reports/Rpt_DeptStoreWiseItems.rpt"));

            //crystalReport.Load(Server.MapPath("~/Report/Rpt_UserWiseDailyCashReport.rpt"));
            //dsCashSummary = ObjDOReport.FillUserWiseCashSummary(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), Convert.ToInt32(ViewState["PatRegId"]), ddlUser.SelectedValue, RdbPayment.SelectedValue, BranchId, FId);
            //crystalReport.SetDataSource(dsCashSummary);
            //crystalReport.ParameterFields["FromDate"].CurrentValues.AddValue(Convert.ToString(ViewState["FromDate"]));
            //crystalReport.ParameterFields["ToDate"].CurrentValues.AddValue(Convert.ToString(ViewState["ToDate"]));

            //crystalReport.ParameterFields["HospitalName"].CurrentValues.AddValue(Convert.ToString(Application["OrgnizationName"]));
            //crystalReport.ParameterFields["HospitalAddress"].CurrentValues.AddValue(Convert.ToString(Application["OrgnizationAddress"]));
            ////crystalReport.ParameterFields["Image"].CurrentValues.AddValue(Application["ImagePath"]);
            //crystalReport.ParameterFields["ReportFooter"].CurrentValues.AddValue("Hospital Software | Ph.020 123456789");
            //crystalReport.ExportToHttpResponse
            //(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Employee");
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {

    }
}