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

public partial class ProcedureServiceWiseIncome :BasePage
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
          //  LoadBillGroup();
            AutoCompleteExtender1.ContextKey = ddlBillGroup.SelectedValue;
            // Session["GroupID"] =Convert.ToInt32(ddlBillGroup.SelectedValue);
            ViewState["ServiceID"] = 0;
            //LoadServiceByBillGroup(Convert.ToInt32(ddlBillGroup.SelectedValue));
            fillgrid();

        }
    }
    //private void LoadBillGroup()
    //{
    //    ddlBillGroup.DataSource = objDALOpdReg.FillBillGroupNameOPD();
    //    ddlBillGroup.DataTextField = "GroupName";
    //    ddlBillGroup.DataValueField = "BillGroupId";
    //    ddlBillGroup.DataBind();


    //}
    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchAllService(string prefixText, int count, string contextKey)
    {
        //  DALOpdReg objDALOpdReg = new DALOpdReg();
        DALBillInfo ObjDALBillInfo = new DALBillInfo();
       // int GroupID = Convert.ToInt32(HttpContext.Current.Session["GroupID"]);
        return ObjDALBillInfo.FillGroupWiseService_Procedure(prefixText, Convert.ToString(contextKey));
    }
    protected void txtBillServices_TextChanged(object sender, EventArgs e)
    {
        if (txtBillServices.Text != "")
        {

            string[] ServiceInfo = txtBillServices.Text.Split('-');
            if (ServiceInfo.Length > 1)
            {
                txtBillServices.Text = ServiceInfo[1];
                ViewState["ServiceID"] = ServiceInfo[0];
            }
            else
            {
                ViewState["ServiceID"] = 0;
            }

        }
        else
        {
            ViewState["ServiceID"] = 0;
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
        string BillGroupName =ddlBillGroup.SelectedValue;
        int ServiceId = Convert.ToInt32(ViewState["ServiceID"]);

        DataTable dt = new DataTable();
        dt = ObjDOReport.FillServicewiseIncomeGrid_Procedure(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), BillGroupName, ServiceId, DrId, BranchId, FId);
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

    protected void btnSearch_Click(object sender, EventArgs e)
    {
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
            int BillServiceId = Convert.ToInt32(gvGroup.DataKeys[rowIndex].Values["BillServiceId"]);
            int BranchId = Convert.ToInt32(Session["Branchid"]);
            int FId = Convert.ToInt32(Session["FId"]);
            int DrId = Convert.ToInt32(ViewState["ConsultID"]);
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
            objreports.ServiceWiseIncomeReport_Procedure(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), BillServiceId,DrId, FId, BranchId);

            Session.Add("rptsql", sql);
            Session["rptname"] = Server.MapPath("~/Reports/Rpt_ServiceWiseIncomeReport_Procedure.rpt");
            Session["reportname"] = "ServiceWiseIncomeProcedure_Report";
            Session["RPTFORMAT"] = "pdf";


            string close = "<script language='javascript'>javascript:OpenReport();</script>";
            Type title1 = this.GetType();
            Page.ClientScript.RegisterStartupScript(title1, "", close);
        }
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
    protected void ddlBillGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        string BillGroupName = ddlBillGroup.SelectedValue;
        //Session["GroupID"] = BillGroupId;
        AutoCompleteExtender1.ContextKey = ddlBillGroup.SelectedValue;
        // LoadServiceByBillGroup(Convert.ToInt32(BillGroupId));
    }


    private void LoadServiceByBillGroup(int BillGroupId)
    {
        ddlBillServices.DataSource = ObjDALBillInfo.FillServiceName(BillGroupId);
        ddlBillServices.DataTextField = "ServiceName";
        ddlBillServices.DataValueField = "BillServiceId";
        ddlBillServices.DataBind();
    }
}