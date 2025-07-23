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

public partial class BillGroupWiseIncomeReport : System.Web.UI.Page
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
        dt = ObjDOReport.FillGroupwiseIncomeGrid(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), BranchId, FId);
        gvGroup.DataSource = dt;
        gvGroup.DataBind();
        if (dt.Rows.Count > 0)
        {
            double TotalAmt = dt.AsEnumerable().Sum(row => row.Field<double>("TotalCharges"));
            gvGroup.FooterRow.Cells[3].Text = "Total";
            gvGroup.FooterRow.Cells[3].HorizontalAlign = HorizontalAlign.Right;
            gvGroup.FooterRow.Cells[4].Text = TotalAmt.ToString("N2");
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

            if (RdbServices.SelectedValue == "DoctorWise")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = gvGroup.Rows[rowIndex];
                int BillGroupId = Convert.ToInt32(gvGroup.DataKeys[rowIndex].Values["BillGroupId"]);
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
                //objreports.InvoicewiseBillGroupIncome(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]),BillGroupId,FId, BranchId);

                objreports.PatientwiseBillGroupIncome(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), BillGroupId, FId, BranchId);

                Session.Add("rptsql", sql);
                Session["rptname"] = Server.MapPath("~/Reports/Rpt_DoctorwiseBillGroupIncome.rpt");
                Session["reportname"] = "DoctorwiseBillGroupIncome_Report";
                Session["RPTFORMAT"] = "pdf";


                string close = "<script language='javascript'>javascript:OpenReport();</script>";
                Type title1 = this.GetType();
                Page.ClientScript.RegisterStartupScript(title1, "", close);
            }
            if (RdbServices.SelectedValue == "PatientWise")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = gvGroup.Rows[rowIndex];
                int BillGroupId = Convert.ToInt32(gvGroup.DataKeys[rowIndex].Values["BillGroupId"]);
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



                objreports.PatientwiseBillGroupIncome_Pharmacy(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), BillGroupId, FId, BranchId);

                Session.Add("rptsql", sql);
                Session["rptname"] = Server.MapPath("~/Reports/Rpt_PatientwiseBillGroupIncome.rpt");
                Session["reportname"] = "PatientwiseBillGroupIncome_Report";
                Session["RPTFORMAT"] = "pdf";

                string close = "<script language='javascript'>javascript:OpenReport();</script>";
                Type title1 = this.GetType();
                Page.ClientScript.RegisterStartupScript(title1, "", close);
            }
            if (RdbServices.SelectedValue == "ServiceWise")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = gvGroup.Rows[rowIndex];
                int BillGroupId = Convert.ToInt32(gvGroup.DataKeys[rowIndex].Values["BillGroupId"]);
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



                objreports.PatientwiseBillGroupIncome(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), BillGroupId, FId, BranchId);

                Session.Add("rptsql", sql);
                Session["rptname"] = Server.MapPath("~/Reports/Rpt_ServicewiseBillGroupIncome.rpt");
                Session["reportname"] = "ServicewiseBillGroupIncome_Report";
                Session["RPTFORMAT"] = "pdf";

                string close = "<script language='javascript'>javascript:OpenReport();</script>";
                Type title1 = this.GetType();
                Page.ClientScript.RegisterStartupScript(title1, "", close);
            }

            if (RdbServices.SelectedValue == "DoctorWisesingle")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = gvGroup.Rows[rowIndex];
                int BillGroupId = Convert.ToInt32(gvGroup.DataKeys[rowIndex].Values["BillGroupId"]);
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
                //objreports.InvoicewiseBillGroupIncome(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]),BillGroupId,FId, BranchId);

                objreports.PatientwiseBillGroupIncome(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), BillGroupId, FId, BranchId);

                Session.Add("rptsql", sql);
                Session["rptname"] = Server.MapPath("~/Reports/Rpt_DoctorwiseBillGroupIncome_single.rpt");
                Session["reportname"] = "DoctorwiseBillGroupIncome_single";
                Session["RPTFORMAT"] = "pdf";


                string close = "<script language='javascript'>javascript:OpenReport();</script>";
                Type title1 = this.GetType();
                Page.ClientScript.RegisterStartupScript(title1, "", close);
            }


        }
        if (e.CommandName == "ExcelReport")
        {

            if (RdbServices.SelectedValue == "DoctorWise")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = gvGroup.Rows[rowIndex];
                int BillGroupId = Convert.ToInt32(gvGroup.DataKeys[rowIndex].Values["BillGroupId"]);
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
                //objreports.InvoicewiseBillGroupIncome(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]),BillGroupId,FId, BranchId);

                objreports.PatientwiseBillGroupIncome(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), BillGroupId, FId, BranchId);

                Session.Add("rptsql", sql);
                Session["rptname"] = Server.MapPath("~/Reports/Rpt_DoctorwiseBillGroupIncome.rpt");
                Session["reportname"] = "DoctorwiseBillGroupIncome_Report";
                Session["RPTFORMAT"] = "EXCEL";


                string close = "<script language='javascript'>javascript:OpenReport();</script>";
                Type title1 = this.GetType();
                Page.ClientScript.RegisterStartupScript(title1, "", close);
            }
            if (RdbServices.SelectedValue == "PatientWise")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = gvGroup.Rows[rowIndex];
                int BillGroupId = Convert.ToInt32(gvGroup.DataKeys[rowIndex].Values["BillGroupId"]);
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



                objreports.PatientwiseBillGroupIncome(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), BillGroupId, FId, BranchId);

                Session.Add("rptsql", sql);
                Session["rptname"] = Server.MapPath("~/Reports/Rpt_PatientwiseBillGroupIncome.rpt");
                Session["reportname"] = "PatientwiseBillGroupIncome_Report";
                Session["RPTFORMAT"] = "EXCEL";

                string close = "<script language='javascript'>javascript:OpenReport();</script>";
                Type title1 = this.GetType();
                Page.ClientScript.RegisterStartupScript(title1, "", close);
            }
            if (RdbServices.SelectedValue == "ServiceWise")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = gvGroup.Rows[rowIndex];
                int BillGroupId = Convert.ToInt32(gvGroup.DataKeys[rowIndex].Values["BillGroupId"]);
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



                objreports.PatientwiseBillGroupIncome(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), BillGroupId, FId, BranchId);

                Session.Add("rptsql", sql);
                Session["rptname"] = Server.MapPath("~/Reports/Rpt_ServicewiseBillGroupIncome.rpt");
                Session["reportname"] = "ServicewiseBillGroupIncome_Report";
                Session["RPTFORMAT"] = "EXCEL";

                string close = "<script language='javascript'>javascript:OpenReport();</script>";
                Type title1 = this.GetType();
                Page.ClientScript.RegisterStartupScript(title1, "", close);
            }

            if (RdbServices.SelectedValue == "DoctorWisesingle")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = gvGroup.Rows[rowIndex];
                int BillGroupId = Convert.ToInt32(gvGroup.DataKeys[rowIndex].Values["BillGroupId"]);
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
                //objreports.InvoicewiseBillGroupIncome(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]),BillGroupId,FId, BranchId);

                objreports.PatientwiseBillGroupIncome(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), BillGroupId, FId, BranchId);

                Session.Add("rptsql", sql);
                Session["rptname"] = Server.MapPath("~/Reports/Rpt_DoctorwiseBillGroupIncome_single.rpt");
                Session["reportname"] = "DoctorwiseBillGroupIncome_single";
                Session["RPTFORMAT"] = "EXCEL";


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
        ObjDOReport.BillGroupSalesSummary(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), BranchId, FId);
        
        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Reports/Rpt_BillGroupSalesSummary.rpt");
        Session["reportname"] = "BillGroupSalesSummary";
        Session["RPTFORMAT"] = "pdf";

        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);
    }
    protected void btnExcel_Click(object sender, EventArgs e)
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
        ObjDOReport.BillGroupSalesSummary(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), BranchId, FId);

        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Reports/Rpt_BillGroupSalesSummary.rpt");
        Session["reportname"] = "BillGroupSalesSummary";
        Session["RPTFORMAT"] = "EXCEL";

        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);
    }
}