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

public partial class DoctorWiseCashReport :BasePage
{
    BLLReports ObjDOReport = new BLLReports();
    DALOpdReg objDALOpdReg = new DALOpdReg();
    DALBillCharges objDALBillCharges = new DALBillCharges();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtFrom.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtTo.Text = DateTime.Now.ToString("dd/MM/yyyy");
          //  RdbPayment.SelectedValue = "All";
            ViewState["ConsultID"] = "0";
            FillConsulatantDoctors();
            FillBillServiceDrop();
           // FillGrid();

        }

    }


    protected void FillConsulatantDoctors()
    {
        int UserId = Convert.ToInt32(Session["UserId"]);
        int BranchId = Convert.ToInt32(Session["BranchId"]);
        int FId = Convert.ToInt32(Session["FId"]);
        ddlConsDoctorName.DataSource = objDALOpdReg.FillConsultantDocName();
        ddlConsDoctorName.DataValueField = "DrId";
        ddlConsDoctorName.DataTextField = "EmpName";
        ddlConsDoctorName.DataBind();

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


        gvDailyCash.DataSource = ObjDOReport.FillDoctorWiseCashReport(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), Convert.ToInt32(ViewState["ConsultID"]), Convert.ToInt32(ddlBillService.SelectedValue), BranchId, FId); //Convert.ToInt32(ddlUser.SelectedValue));ddlConsDoctorName.SelectedValue
        gvDailyCash.DataBind();
    }
    private void Reset()
    {

    }
    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchConsultDoc(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        return objDALOpdReg.FillAllConsultDoc(prefixText);
    }
    protected void txtConsDoctorName_TextChanged(object sender, EventArgs e)
    {
        if (txtConsDoctorName.Text != "")
        {
            string[] PatientInfo = txtConsDoctorName.Text.Split('-');
            if (PatientInfo.Length > 1)
            {
                txtConsDoctorName.Text = PatientInfo[1];
                ViewState["ConsultID"] = PatientInfo[0];
            }
            else
            {
                ViewState["ConsultID"] = "0";

            }
        }
    }

    protected void Print_Click(object sender, EventArgs e)
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

            crystalReport.Load(Server.MapPath("~/Report/Rpt_DoctorWiseDailyCash.rpt"));
            dsCashSummary = ObjDOReport.FillDoctorWiseCashReport(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), Convert.ToInt32(ViewState["ConsultID"]), Convert.ToInt32(ddlBillService.SelectedValue), BranchId, FId);
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
    protected void FillBillServiceDrop()
    {

        ddlBillService.DataSource = objDALBillCharges.FillBillServices("DocWise",1, Convert.ToInt32(Session["FId"]), Convert.ToInt32(Session["Branchid"]));
        ddlBillService.DataValueField = "BillServiceId";
        ddlBillService.DataTextField = "ServiceName";
        ddlBillService.DataBind();

    }
    protected void ddlBillService_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlConsDoctorName_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnPrintExcel_Click(object sender, EventArgs e)
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

            crystalReport.Load(Server.MapPath("~/Report/Rpt_DoctorWiseDailyCash.rpt"));
            dsCashSummary = ObjDOReport.FillDoctorWiseCashReport(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), Convert.ToInt32(ViewState["ConsultID"]), Convert.ToInt32(ddlBillService.SelectedValue), BranchId, FId);
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
                (CrystalDecisions.Shared.ExportFormatType.ExcelWorkbook, Response, false, "Employee");
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
}