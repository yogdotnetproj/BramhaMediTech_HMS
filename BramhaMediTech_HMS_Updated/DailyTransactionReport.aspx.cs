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

public partial class DailyTransactionReport : System.Web.UI.Page
{

    BLLReports ObjDOReport = new BLLReports();
    decimal total = 0;
    decimal AmountPaid = 0;
    int Balance = 0;
    int Balance1 = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtFrom.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtTo.Text = DateTime.Now.ToString("dd/MM/yyyy");
            RdbPayment.SelectedValue = "All";
            FillUsers();
            FillGrid();

        }

    }
   
    
    protected void FillUsers()
    {
        int UserId = Convert.ToInt32(Session["UserId"]);
        int BranchId = Convert.ToInt32(Session["BranchId"]);
        int FId = Convert.ToInt32(Session["FId"]);
        ddlUser.DataSource = ObjDOReport.fillUsers(UserId,BranchId, FId);
        ddlUser.DataValueField = "CUId";
        ddlUser.DataTextField = "username";
        ddlUser.DataBind();

    }
    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchPatient(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        return objDALOpdReg.FillAllPatient(prefixText);
    }
    protected void ddlUser_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void txtTo_TextChanged(object sender, EventArgs e)
    {
        ViewState["ToDate"] = txtTo.Text.ToString();
    }
    protected void txtFrom_TextChanged(object sender, EventArgs e)
    {
        ViewState["FromDate"] = txtFrom.Text.ToString();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
       
        FillGrid();
        Reset();
    }

    private void FillGrid()
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


        gvDailyCash.DataSource = ObjDOReport.FillUserWiseCashSummary(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]),Convert.ToInt32(ViewState["PatRegId"]), ddlUser.SelectedValue, RdbPayment.SelectedValue, BranchId, FId); //Convert.ToInt32(ddlUser.SelectedValue));
        gvDailyCash.DataBind();
    }
    private void Reset()
    {

    }

    protected void Print_Click(object sender, EventArgs e)
    {
        try
        {

            if (txtFrom.Text.ToString() != "")
            {
                ViewState["FromDate"] = txtFrom.Text.ToString();
               // ViewState["FromDate"] = DateTime.ParseExact(txtFrom.Value, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture).ToString();
            }
            else
            {
                ViewState["FromDate"] = "";
            }
            if (txtTo.Text.ToString() != "")
            {

                ViewState["ToDate"] = txtTo.Text.ToString();
                //ViewState["ToDate"] = DateTime.ParseExact(txtTo.Value, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture).ToString();

            }
            else
            {
                ViewState["ToDate"] = "";
            }
            int BranchId = Convert.ToInt32(Session["BranchId"]);
            int FId = Convert.ToInt32(Session["FId"]);

           // DALReports objDalReport = new DALReports();
            DataSet dsCashSummary = new DataSet();
            ReportDocument crystalReport = new ReportDocument();
            //crystalReport.Load(Server.MapPath("~/Reports/Rpt_DeptStoreWiseItems.rpt"));
           
            crystalReport.Load(Server.MapPath("~/Report/Rpt_DailyTransactionSheet.rpt"));
            dsCashSummary = ObjDOReport.FillUserWiseCashSummary(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), Convert.ToInt32(ViewState["PatRegId"]), ddlUser.SelectedValue, RdbPayment.SelectedValue, BranchId, FId);
            crystalReport.SetDataSource(dsCashSummary);
            crystalReport.ParameterFields["FromDate"].CurrentValues.AddValue(Convert.ToString(ViewState["FromDate"]));
            crystalReport.ParameterFields["ToDate"].CurrentValues.AddValue(Convert.ToString(ViewState["ToDate"]));

            //crystalReport.ParameterFields["HospitalName"].CurrentValues.AddValue(Convert.ToString(Application["OrgnizationName"]));
            //crystalReport.ParameterFields["HospitalAddress"].CurrentValues.AddValue(Convert.ToString(Application["OrgnizationAddress"]));
            ////crystalReport.ParameterFields["Image"].CurrentValues.AddValue(Application["ImagePath"]);
            //crystalReport.ParameterFields["ReportFooter"].CurrentValues.AddValue("Hospital Software | Ph.020 123456789");
            try
            {
                crystalReport.ExportToHttpResponse
                (CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Employee");
            }
            catch (Exception ex)
            {
            }
            finally
            {
                crystalReport.Close();
                ((IDisposable)crystalReport).Dispose();
                GC.Collect();
                GC.SuppressFinalize(crystalReport);
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {

    }
    protected void gvDailyCash_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDailyCash.PageIndex = e.NewPageIndex;
        FillGrid();
    }
    protected void gvDailyCash_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    total += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "AmountReceived"));
           

        //}
        //if (e.Row.RowType == DataControlRowType.Footer)
        //{
        //    e.Row.Cells[7].Text = "Total";
        //    e.Row.Cells[7].Font.Bold = true;
        //    e.Row.Cells[8].Text = total.ToString();
        //    e.Row.Cells[8].Font.Bold = true;
            
        //}

    }
    protected void txtPatientName_TextChanged(object sender, EventArgs e)
    {
        string[] PatientInfo = txtPatientName.Text.Split('-');
        txtPatientName.Text = PatientInfo[1];
        ViewState["PatRegId"] = PatientInfo[0];
    }
}