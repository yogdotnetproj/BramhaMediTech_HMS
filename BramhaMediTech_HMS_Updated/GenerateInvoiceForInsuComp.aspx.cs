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

public partial class GenerateInvoiceForInsuComp : BasePage
{
    BELOPDPatReg objBELOpdReg = new BELOPDPatReg();
    DALOpdReg objDALOpdReg = new DALOpdReg();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ViewState["InsuranceId"] = 0;
            txtStart.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtEnd.Text = DateTime.Now.ToString("dd/MM/yyyy");
            btngenerate.Visible = true;
            btnSearch.Visible = false;
         
            lblMessage.Text = "";
       
        }

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(ViewState["InsuranceId"]) == 0)
        {
            lblMessage.Text = "Please Select Insurance Company";
            lblMessage.ForeColor = System.Drawing.Color.Red;
            return;
        }
        else
        {
            lblMessage.Text = "";
        }
        string flag = "Search";
        Fillgrid(flag);
    }
    protected void btngenerate_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(ViewState["InsuranceId"]) == 0)
        {
            lblMessage.Text = "Please Select Insurance Company";
            lblMessage.ForeColor = System.Drawing.Color.Red;
            return;
        }
        else
        {
            lblMessage.Text = "";
        }
        int FId = Convert.ToInt32(Session["FId"]);
        int BranchId = Convert.ToInt32(Session["Branchid"]);
        string UserName = Convert.ToString(Session["username"]);
        string flag = "Generate";
        object[] Result = objDALOpdReg.GenerateInvoice(Convert.ToInt32(ViewState["InsuranceId"]), txtStart.Text, txtEnd.Text, FId, BranchId, UserName);
        lblMessage.Text = Convert.ToString(Result[0]);
        int InvoiceNo = Convert.ToInt32(Result[1]);
        DataTable dt=new DataTable();
        //dt=objDALOpdReg.FillInvoiceDetails(Convert.ToInt32(ViewState["InsuranceId"]), txtStart.Text, txtEnd.Text, FId, BranchId);
        //if (dt.Rows.Count > 0)
        //{
            //for (int i = 0; i < dt.Rows.Count; i++)
            for (int i = 0; i < GVPAtientInvoice.Rows.Count; i++)
            {
               
                CheckBox ChkGen = (GVPAtientInvoice.Rows[i].FindControl("ChkGenInv") as CheckBox);
                if (ChkGen.Checked == true)
                {

                   // int PatRegId = Convert.ToInt32(dt.Rows[i]["PatRegId"]);
                   // int IpdNo = Convert.ToInt32(dt.Rows[i]["IpdNo"]);
                   // float BillAmount = Convert.ToSingle(dt.Rows[i]["Sponsor1Amt"]);
                    int PatRegId = Convert.ToInt32(GVPAtientInvoice.Rows[i].Cells[1].Text);
                    int IpdNo = Convert.ToInt32(GVPAtientInvoice.Rows[i].Cells[2].Text);
                   
                    float BillAmount = Convert.ToSingle(GVPAtientInvoice.Rows[i].Cells[5].Text);

                    objDALOpdReg.InserInvoiceDetails(InvoiceNo, Convert.ToInt32(ViewState["InsuranceId"]), PatRegId, IpdNo, BillAmount, FId, BranchId);
                }
            }
       // }
            this.btnGenInvoiceSearch_Click(null, null);

    }
    public void Fillgrid(string flag)
    {
        gvPatientInfo.DataSource = objDALOpdReg.fillInvoiceGrid(Convert.ToInt32(ViewState["InsuranceId"]), txtStart.Text, txtEnd.Text, Convert.ToInt32(Session["FId"]), Convert.ToInt32(Session["Branchid"]),flag);
        gvPatientInfo.DataBind();
    }

    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchInsurance(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        return objDALOpdReg.FillAllInsurance(prefixText);
    }

    protected void gvPatientInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void gvPatientInfo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        BLLReports objreports = new BLLReports();
        string sql = "";
        if (e.CommandName == "Report")
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            //Reference the GridView Row.
            GridViewRow row = gvPatientInfo.Rows[rowIndex];
            int InvoiceNo = Convert.ToInt32(gvPatientInfo.DataKeys[rowIndex].Values["InvoiceNo"]);
            int InsuCompId = Convert.ToInt32(gvPatientInfo.DataKeys[rowIndex].Values["InsuranceCompId"]);
            int BranchId = Convert.ToInt32(Session["Branchid"]);
            int FId = Convert.ToInt32(Session["FId"]);

           
            objreports.PatientInsuranceDetails_Invoice(InvoiceNo, InsuCompId, FId, BranchId);
            Session.Add("rptsql", sql);
            Session["rptname"] = Server.MapPath("~/Reports/Rpt_PatientInsuranceDetailsInvoice.rpt");
            Session["reportname"] = "PatientInvoiceDetails";
            Session["RPTFORMAT"] = "pdf";


            string close = "<script language='javascript'>javascript:OpenReport();</script>";
            Type title1 = this.GetType();
            Page.ClientScript.RegisterStartupScript(title1, "", close);


        }

    }
    protected void txtInsuranceid_TextChanged(object sender, EventArgs e)
    {
        if (txtInsuranceid.Text != "")
        {
            string[] InsuranceId = txtInsuranceid.Text.Split('-');
            txtInsuranceid.Text = InsuranceId[1];

            if (txtInsuranceid.Text != "")
                ViewState["InsuranceId"] = InsuranceId[0];
            else
                ViewState["InsuranceId"] = 0;
        }
        else
        {
            ViewState["InsuranceId"] = 0;
        }
    }
    protected void RdbServicesFlag_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RdbServicesFlag.SelectedValue == "Generate")
        {
            btngenerate.Visible = true;
            btnSearch.Visible = false;
            btnGenInvoiceSearch.Visible = true;
            PInV.Visible = true;
            search1.Visible = false;
        }
        else
        {
            btngenerate.Visible =false;
            btnSearch.Visible = true;
            btnGenInvoiceSearch.Visible = false;
            PInV.Visible = false;
            search1.Visible = true;
        }

    }
    protected void btnGenInvoiceSearch_Click(object sender, EventArgs e)
    {
        if (RblInvComp.SelectedValue == "1")
        {
            btngenerate.Enabled = false;
        }
        else
        {
            btngenerate.Enabled = true;
        }
        BLLReports objreports = new BLLReports();
        objreports.GetAll_AllInvoicePatient_ForIPD(Convert.ToInt32(ViewState["InsuranceId"]), txtStart.Text, txtEnd.Text, Convert.ToInt32(RblInvComp.SelectedValue));

        GVPAtientInvoice.DataSource = objDALOpdReg.FillInvoiceGrid_IPD(Convert.ToInt32(ViewState["InsuranceId"]), txtStart.Text, txtEnd.Text);
        GVPAtientInvoice.DataBind();
    }
    protected void GVPAtientInvoice_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void GVPAtientInvoice_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        BLLReports objreports = new BLLReports();
        string sql = "";
        if (e.CommandName == "Report")
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GVPAtientInvoice.Rows[rowIndex];
            int IpdId = Convert.ToInt32(GVPAtientInvoice.DataKeys[rowIndex].Values["IpdNo"]);
            int PatRegId = Convert.ToInt32(GVPAtientInvoice.DataKeys[rowIndex].Values["PatRegId"]);
            int BranchId = Convert.ToInt32(Session["Branchid"]);
            int FId = Convert.ToInt32(Session["FId"]);
            //objreports.IpdBillSummary(IpdId, PatRegId);

            //Session.Add("rptsql", sql);
            //Session["rptname"] = Server.MapPath("~/Reports/Rpt_IpdBillSummary.rpt");
            //Session["reportname"] = "IpdBillSummary_Report";
            //Session["RPTFORMAT"] = "pdf";
            objreports.IpdBillDetails(IpdId, PatRegId, FId, BranchId);
            Session.Add("rptsql", sql);
            // Session["rptname"] = Server.MapPath("~/Reports/Rpt_IpdBillSummary.rpt");
            Session["rptname"] = Server.MapPath("~/Reports/Rpt_IpdBillDetails_summary.rpt");
            Session["reportname"] = "IpdBillSummary_Report";
            Session["RPTFORMAT"] = "pdf";

            string close = "<script language='javascript'>javascript:OpenReport();</script>";
            Type title1 = this.GetType();
            Page.ClientScript.RegisterStartupScript(title1, "", close);

        }
    }
    protected void GVPAtientInvoice_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex == -1)
            return;

        bool GenerateInvoice = Convert.ToBoolean((e.Row.FindControl("hdnGenerateInvoice") as HiddenField).Value);

        if (GenerateInvoice == true)
        {
            (e.Row.FindControl("ChkGenInv") as CheckBox).Enabled = false;
            e.Row.Cells[07].Text = "<span class='btn btn-xs btn-success' >Yes</span>";
        }
        else
        {
            (e.Row.FindControl("ChkGenInv") as CheckBox).Enabled = true;
            e.Row.Cells[07].Text = "<span class='btn btn-xs btn-danger' >No</span>";
        }
    }
    protected void btnReporrt_Click(object sender, EventArgs e)
    {
        BLLReports objreports = new BLLReports();
        string sql = "";
        int InvoiceNo = Convert.ToInt32(0);
        int InsuCompId = Convert.ToInt32(Convert.ToInt32(ViewState["InsuranceId"]));
        int BranchId = Convert.ToInt32(Session["Branchid"]);
        int FId = Convert.ToInt32(Session["FId"]);


       // objreports.PatientInsuranceDetails_Invoice_ForAllIPD(InvoiceNo, InsuCompId, FId, BranchId);
        objreports.GetAll_AllInvoicePatient_ForIPD(Convert.ToInt32(ViewState["InsuranceId"]), txtStart.Text, txtEnd.Text, Convert.ToInt32(RblInvComp.SelectedValue));
        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Reports/Rpt_PatientInsuranceDetailsInvoice.rpt");
        Session["reportname"] = "IPDInsurancePatientList";
        Session["RPTFORMAT"] = "pdf";


        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);
    }
}