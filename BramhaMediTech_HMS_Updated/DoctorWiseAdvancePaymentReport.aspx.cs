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

public partial class DoctorWiseAdvancePaymentReport : BasePage
{
    BELOPDPatReg objBELOpdReg = new BELOPDPatReg();
    DALOpdReg objDALOpdReg = new DALOpdReg();
    BELBillInfo ObjBELBillInfo = new BELBillInfo();
    DALBillInfo ObjDALBillInfo = new DALBillInfo();
    BLLReports ObjDOReport = new BLLReports();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["ConsultID"] = 0;
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
        int DrId = Convert.ToInt32(ViewState["ConsultID"]);
      

        DataTable dt = new DataTable();
        dt = ObjDOReport.FillDoctorwiseAdvanceGrid(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), DrId, FId, BranchId);
        gvGroup.DataSource = dt;
        gvGroup.DataBind();
        if (dt.Rows.Count > 0)
        {
            double TotalAmt = dt.AsEnumerable().Sum(row => row.Field<double>("ReceivedAmount"));
            gvGroup.FooterRow.Cells[3].Text = "Total";
            gvGroup.FooterRow.Cells[3].Font.Bold = true;
            gvGroup.FooterRow.Cells[3].HorizontalAlign = HorizontalAlign.Right;
            gvGroup.FooterRow.Cells[4].Text = TotalAmt.ToString("N2");
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        fillgrid();
    }
   
    protected void gvGroup_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvGroup.PageIndex = e.NewPageIndex;
        fillgrid();
    }
    protected void txtConsDoctorName_TextChanged(object sender, EventArgs e)
    {
        if (txtConsDoctorName.Text != "")
        {
            string[] DocInfo = txtConsDoctorName.Text.Split('-');
            if (DocInfo.Length > 1)
            {
                txtConsDoctorName.Text = DocInfo[1];
                ViewState["ConsultID"] = DocInfo[0];
            }
        }
        else
        {
            ViewState["ConsultID"] = 0;
        }
    }
    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchConsultDoc(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        return objDALOpdReg.FillAllConsultDoc(prefixText);
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
            int DrId = Convert.ToInt32(ViewState["ConsultID"]);

            objreports.DoctorwiseAdvancePaymentReport(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), DrId, FId, BranchId);

            Session.Add("rptsql", sql);
            Session["rptname"] = Server.MapPath("~/Reports/Rpt_DoctorWiseAdvanceReport.rpt");
            Session["reportname"] = "DoctorWiseAdvanceReport";
            Session["RPTFORMAT"] = "pdf";


            string close = "<script language='javascript'>javascript:OpenReport();</script>";
            Type title1 = this.GetType();
            Page.ClientScript.RegisterStartupScript(title1, "", close);

          

            
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
}