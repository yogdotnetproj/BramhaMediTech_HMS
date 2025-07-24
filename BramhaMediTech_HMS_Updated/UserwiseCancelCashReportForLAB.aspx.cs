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
using System.Drawing;

public partial class UserwiseCancelCashReportForLAB : BasePage
{
    BLLReports ObjDOReport = new BLLReports();
   // BLLReports objreports = new BLLReports();
    ReportDocument crystalReport = new ReportDocument();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["Report"] = "";
            txtFrom.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtTo.Text = DateTime.Now.ToString("dd/MM/yyyy");
            //RdbPayment.SelectedValue = "All";
            FillUsers();
            LoadRdbPaymentType();
            RdbPayment.SelectedValue = "0";
            refreshdata();

        }

    }
    protected void Page_Unload(object sender, EventArgs e)
    {
        if ((ViewState["Report"].ToString()) != "")
        {

            crystalReport.Close();
            crystalReport.Dispose();
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
    private void LoadRdbPaymentType()
    {

        RdbPayment.DataSource = ObjDOReport.FillModeOfPaymentForReport();
        RdbPayment.DataValueField = "ModeOfPaymentId";
        RdbPayment.DataTextField = "ModeOfPaymentName";
        RdbPayment.DataBind();


    }
    protected void txtTo_TextChanged(object sender, EventArgs e)
    {
        ViewState["ToDate"] = txtTo.Text.ToString();
    }
    protected void txtFrom_TextChanged(object sender, EventArgs e)
    {
        ViewState["FromDate"] = txtFrom.Text.ToString();
    }

    public void refreshdata()
    {
        DataTable dt = new DataTable();
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
        ObjDOReport.FillLABCancelIncomeReport(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), ddlUser.SelectedValue, Convert.ToInt32(RdbPayment.SelectedValue), ddlBillGroup.SelectedValue, BranchId, FId,0);

        using (SqlConnection con = DataAccess.ConInitForDC())
        {
            using (SqlCommand cmd = new SqlCommand("Sp_Vw_BindLabPaymentTransactionRpt_UserWise_Cancel", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FId", Convert.ToInt32(Session["FId"]));                
                cmd.Parameters.AddWithValue("@BranchId", Convert.ToInt32(Session["Branchid"]));
                con.Open();

                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(dt);
                }

                con.Close();
                con.Dispose();
            }
            gvPatientInfo.DataSource = dt;
            gvPatientInfo.DataBind();

        }

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        refreshdata();
    }

    protected void gvPatientInfo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Print")
        {

        //    int rowIndex = Convert.ToInt32(e.CommandArgument);
        //    GridViewRow row = gvPatientInfo.Rows[rowIndex];
        //   // int PatRegId = Convert.ToInt32(gvPatientInfo.Rows[rowIndex].Cells[1].Text);
        //    int PatRegId = Convert.ToInt32(gvPatientInfo.DataKeys[rowIndex].Values["PatRegId"]);
        //    string sql = "";

        //    try
        //    {

        //        if (txtFrom.Text.ToString() != "")
        //        {
        //            ViewState["FromDate"] = txtFrom.Text.ToString();

        //        }
        //        else
        //        {
        //            ViewState["FromDate"] = "";
        //        }
        //        if (txtTo.Text.ToString() != "")
        //        {

        //            ViewState["ToDate"] = txtTo.Text.ToString();


        //        }
        //        else
        //        {
        //            ViewState["ToDate"] = "";
        //        }
        //        int BranchId = Convert.ToInt32(Session["BranchId"]);
        //        int FId = Convert.ToInt32(Session["FId"]);
        //        ObjDOReport.FillLABCancelIncomeReport(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), ddlUser.SelectedValue, Convert.ToInt32(RdbPayment.SelectedValue), ddlBillGroup.SelectedValue, BranchId, FId,PatRegId);

        //        Session.Add("rptsql", sql);
        //        Session["rptname"] = Server.MapPath("~/Reports/Rpt_UserWiseLabCashCancelReport.rpt");
        //        Session["reportname"] = "UserWiseLABCashCancel_Report";
        //        Session["RPTFORMAT"] = "pdf";


        //        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        //        Type title1 = this.GetType();
        //        Page.ClientScript.RegisterStartupScript(title1, "", close);


        //    }
        //    catch (Exception ex)
        //    {
        //        lblMessage.Text = ex.Message;
        //    }

            
              ViewState["Report"] = "True";
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvPatientInfo.Rows[rowIndex];

            int BranchId = Convert.ToInt32(Session["BranchId"]);
            //int FId = Convert.ToInt32(Session["FId"]);

                // this.RegisterPostBackControl();

                //DropDownList ddl_Receipt = gvPatientInfo.Rows[row.RowIndex].FindControl("ddlReceipt") as DropDownList;
                HiddenField HdnLabNo = gvPatientInfo.Rows[row.RowIndex].FindControl("HdnLabNo") as HiddenField;
                HiddenField HdnBillNo = gvPatientInfo.Rows[row.RowIndex].FindControl("HdnBillNo") as HiddenField;
               // HiddenField HdnFId = gvPatientInfo.Rows[row.RowIndex].FindControl("HdnFId") as HiddenField;
                int PatRegId = Convert.ToInt32(gvPatientInfo.DataKeys[rowIndex].Values["PatRegId"]);
                string sql = "";


                BLLReports objBLLReports = new BLLReports();
                DataSet dsCustomers = new DataSet();

                dsCustomers = objBLLReports.GetLabBillDetailsAll(Convert.ToInt32(HdnBillNo.Value), Convert.ToInt32(HdnLabNo.Value), Convert.ToInt32(PatRegId), Convert.ToInt32(Session["FId"]), Convert.ToInt32(Session["BranchId"]));

                Session.Add("rptsql", sql);
                Session["rptname"] = Server.MapPath("~/Report/Rpt_LabBilling.rpt");
                Session["reportname"] = "LabReceipt";
                Session["RPTFORMAT"] = "pdf";


                string close = "<script language='javascript'>javascript:OpenReport();</script>";
                Type title1 = this.GetType();
                Page.ClientScript.RegisterStartupScript(title1, "", close);
           





        }
       
    }

    protected void gvPatientInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvPatientInfo.PageIndex = e.NewPageIndex;
        refreshdata();
    }

    private void Reset()
    {

    }

    protected void Print_Click(object sender, EventArgs e)
    {
        string sql = "";
       
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
            ObjDOReport.FillLABCancelIncomeReport(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), ddlUser.SelectedValue, Convert.ToInt32(RdbPayment.SelectedValue), ddlBillGroup.SelectedValue, BranchId, FId,0);

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
            lblMessage.Text = ex.Message;
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {

    }
   
}