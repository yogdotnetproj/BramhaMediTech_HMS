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


public partial class GenerateInvoiceForOPD_Insu :BasePage
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
          //  btngenerate.Visible = false;
            btnSearch.Visible = true;
            //btnRePort.Visible = false;
            btnRePort.Visible = true;
            lblMessage.Text = "";
       
        }

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (RdbServicesFlag.SelectedValue == "Search")
        {
            //if (Convert.ToInt32(ViewState["InsuranceId"]) == 0)
            //{
            //    lblMessage.Text = "Please Select Insurance Company";
            //    lblMessage.ForeColor = System.Drawing.Color.Red;
            //    return;
            //}
            //else
            //{
            //    lblMessage.Text = "";
            //}
            lblMessage.Text = "";
            
            string flag = "Search";

            Fillgrid(flag);

        }
        else
        {
            lblMessage.Text = "";
            BindPatientDetails();
        }
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
        if (RblInvComp.SelectedValue =="0")
        {
            int FId = Convert.ToInt32(Session["FId"]);
            int BranchId = Convert.ToInt32(Session["Branchid"]);
            string UserName = Convert.ToString(Session["username"]);
            string flag = "Generate";
            object[] Result = objDALOpdReg.GenerateInvoice_OPD(Convert.ToInt32(ViewState["InsuranceId"]), txtStart.Text, txtEnd.Text, FId, BranchId, UserName);
            lblMessage.Text = Convert.ToString(Result[0]);
            int InvoiceNo = Convert.ToInt32(Result[1]);
            DataTable dt = new DataTable();
            // dt = objDALOpdReg.FillInvoiceDetails_OPD(Convert.ToInt32(ViewState["InsuranceId"]), txtStart.Text, txtEnd.Text, FId, BranchId);
            //if (dt.Rows.Count > 0)
            //{
            for (int i = 0; i < GVPAtientInvoice.Rows.Count; i++)
            {
                // int PatRegId = Convert.ToInt32(dt.Rows[i]["PatRegId"]);
                // string ChargeNo = Convert.ToString(dt.Rows[i]["ChargeNo"]);
                // float BillAmount = Convert.ToSingle(dt.Rows[i]["InsuranceAmt"]);
                CheckBox ChkGen = (GVPAtientInvoice.Rows[i].FindControl("ChkGenInv") as CheckBox);
                if (ChkGen.Checked == true)
                {
                    int PatRegId = Convert.ToInt32(GVPAtientInvoice.Rows[i].Cells[4].Text);
                    string ChargeNo = Convert.ToString(GVPAtientInvoice.Rows[i].Cells[6].Text);
                    float BillAmount = Convert.ToSingle(GVPAtientInvoice.Rows[i].Cells[8].Text);
                    HiddenField HdnChargeYear = (GVPAtientInvoice.Rows[i].FindControl("hdnChargeYear") as HiddenField);
                    HiddenField HdnChargeMonth = (GVPAtientInvoice.Rows[i].FindControl("hdnChargeMonth") as HiddenField);
                    objDALOpdReg.InserInvoiceDetails_OPD(InvoiceNo, Convert.ToInt32(ViewState["InsuranceId"]), PatRegId, ChargeNo, BillAmount, FId, BranchId, UserName,Convert.ToString(HdnChargeYear.Value),Convert.ToString(HdnChargeMonth));
                }
            }

            objDALOpdReg.GenerateInvoice_OPD_Amount(Convert.ToInt32(ViewState["InsuranceId"]), txtStart.Text, txtEnd.Text, FId, BranchId, UserName, InvoiceNo);
           // lblMessage.Text = Convert.ToString(Result[0])
            btngenerate.Enabled = false;
            BindPatientDetails();
        }
        else
        {
            lblMessage.Text = "Invoice already generated";
            lblMessage.ForeColor = System.Drawing.Color.Red;
            return;
        }
       // }
           // Fillgrid(flag);

    }
    public void Fillgrid(string flag)
    {
        gvPatientInfo.DataSource = objDALOpdReg.fillInvoiceGrid_ForOPD(Convert.ToInt32(ViewState["InsuranceId"]), txtStart.Text, txtEnd.Text, Convert.ToInt32(Session["FId"]), Convert.ToInt32(Session["Branchid"]), flag);
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
        gvPatientInfo.PageIndex = e.NewPageIndex;
        string flag = "Search";
        
            Fillgrid(flag);
      
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

           // objreports.PatientInsuranceDetails_Invoice_ForOPD(InvoiceNo);
            objreports.PatientInsuranceDetails_Invoice_ForOPD(InvoiceNo, InsuCompId, FId, BranchId);

            Session.Add("rptsql", sql);
            Session["rptname"] = Server.MapPath("~/Reports/Rpt_PatientInsuranceDetailsInvoice_OPD.rpt");
            Session["reportname"] = "PatientInvoiceDetails_OPD";
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
        //if (RdbServicesFlag.SelectedValue == "Generate")
        //{
        //    btngenerate.Visible = true;
        //    btnSearch.Visible = false;
        //    btnRePort.Visible = false;
        //    PInV.Visible = false;
        //    GInV.Visible = true;
        //}
        //else 
        if (RdbServicesFlag.SelectedValue == "Search")
        {
            // btngenerate.Visible = false;
            btnSearch.Visible = true;
            PInV.Visible = false;
            GInV.Visible = true;
            btnRePort.Visible = false;
        }
        else
        {
            // btngenerate.Visible = false;
            btnSearch.Visible = true;
            PInV.Visible = true;
            GInV.Visible = false;
            btnRePort.Visible = true;
        }

    }
    protected void GVPAtientInvoice_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        BLLReports objreports = new BLLReports();
        string sql = "";
        if (e.CommandName == "Edit")
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            //Reference the GridView Row.
            GridViewRow row = GVPAtientInvoice.Rows[rowIndex];
            int InvoiceNo = Convert.ToInt32(GVPAtientInvoice.DataKeys[rowIndex].Values["ID"]);

            Response.Redirect("~/EditPatientInvoice.aspx?InvoiceNo=" + InvoiceNo);
        }
        if (e.CommandName == "Report")
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            //Reference the GridView Row.
            GridViewRow row = GVPAtientInvoice.Rows[rowIndex];
            int InvoiceNo = Convert.ToInt32(GVPAtientInvoice.DataKeys[rowIndex].Values["ID"]);
            string ChargeNo = Convert.ToString(GVPAtientInvoice.DataKeys[rowIndex].Values["ChargeNo"]);
            int InsuCompId = Convert.ToInt32(GVPAtientInvoice.DataKeys[rowIndex].Values["InsuranceCompId"]);
           // int BranchId = Convert.ToInt32(Session["Branchid"]);
           // int FId = Convert.ToInt32(Session["FId"]);

            objreports.PatientInsuranceDetails_Invoice_ForOPD(InvoiceNo, ChargeNo, Convert.ToInt32(InsuCompId));

            Session.Add("rptsql", sql);
            Session["rptname"] = Server.MapPath("~/Reports/Rpt_PatientInsuranceDetails_ForOPD_USD.rpt");
            Session["reportname"] = "PatientInvoiceDetails_ForOPD_USD";
            Session["RPTFORMAT"] = "pdf";


            string close = "<script language='javascript'>javascript:OpenReport();</script>";
            Type title1 = this.GetType();
            Page.ClientScript.RegisterStartupScript(title1, "", close);


        }
        if (e.CommandName == "ReportPDf")
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            //Reference the GridView Row.
            GridViewRow row = GVPAtientInvoice.Rows[rowIndex];
            int InvoiceNo = Convert.ToInt32(GVPAtientInvoice.DataKeys[rowIndex].Values["ID"]);
            string ChargeNo = Convert.ToString(GVPAtientInvoice.DataKeys[rowIndex].Values["ChargeNo"]);
            int InsuCompId = Convert.ToInt32(GVPAtientInvoice.DataKeys[rowIndex].Values["InsuranceCompId"]);
            // int BranchId = Convert.ToInt32(Session["Branchid"]);
            // int FId = Convert.ToInt32(Session["FId"]);

            objreports.PatientInsuranceDetails_Invoice_ForOPD(InvoiceNo, ChargeNo, Convert.ToInt32(InsuCompId));

            Session.Add("rptsql", sql);
            Session["rptname"] = Server.MapPath("~/Reports/Rpt_PatientInsuranceDetails_ForOPD.rpt");
            Session["reportname"] = "PatientInvoiceDetails_ForOPD";
            Session["RPTFORMAT"] = "pdf";


            string close = "<script language='javascript'>javascript:OpenReport();</script>";
            Type title1 = this.GetType();
            Page.ClientScript.RegisterStartupScript(title1, "", close);


        }
        if (e.CommandName == "ReportWord")
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            //Reference the GridView Row.
            GridViewRow row = GVPAtientInvoice.Rows[rowIndex];
            int InvoiceNo = Convert.ToInt32(GVPAtientInvoice.DataKeys[rowIndex].Values["ID"]);
            string ChargeNo = Convert.ToString(GVPAtientInvoice.DataKeys[rowIndex].Values["ChargeNo"]);
            int InsuCompId = Convert.ToInt32(GVPAtientInvoice.DataKeys[rowIndex].Values["InsuranceCompId"]);
            // int BranchId = Convert.ToInt32(Session["Branchid"]);
            // int FId = Convert.ToInt32(Session["FId"]);

            objreports.PatientInsuranceDetails_Invoice_ForOPD(InvoiceNo, ChargeNo, Convert.ToInt32(InsuCompId));

            Session.Add("rptsql", sql);
            Session["rptname"] = Server.MapPath("~/Reports/Rpt_PatientInsuranceDetails_ForOPD.rpt");
            Session["reportname"] = "PatientInvoiceDetails_ForOPD";
            Session["RPTFORMAT"] = "Word";


            string close = "<script language='javascript'>javascript:OpenReport();</script>";
            Type title1 = this.GetType();
            Page.ClientScript.RegisterStartupScript(title1, "", close);


        }
    }
    protected void GVPAtientInvoice_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVPAtientInvoice.PageIndex = e.NewPageIndex;
        BindPatientDetails();
    }

    public void BindPatientDetails()
    {
        if (Convert.ToInt32(ViewState["InsuranceId"]) > 0)
        {
            string Message = objDALOpdReg.UpdatePatient_ChargeBillAmt(Convert.ToInt32(ViewState["InsuranceId"]), txtStart.Text, txtEnd.Text);
        }

        GVPAtientInvoice.DataSource = objDALOpdReg.fillInvoiceGrid_ForOPDPatients(Convert.ToInt32(ViewState["InsuranceId"]), txtStart.Text, txtEnd.Text,txtchargeNumber.Text,txtPatientName.Text,Convert.ToInt32(RblInvComp.SelectedValue));
        GVPAtientInvoice.DataBind();
    }
    protected void btnRePort_Click(object sender, EventArgs e)
    {
        BLLReports objreports = new BLLReports();
        objreports.GetAll_AllInvoicePatient_ForOPD(Convert.ToInt32(ViewState["InsuranceId"]), txtStart.Text, txtEnd.Text, Convert.ToInt32(RblInvComp.SelectedValue));

        Session.Add("rptsql", "");
        Session["rptname"] = Server.MapPath("~/Reports/Rpt_AllInsurancePatient_ForOPD.rpt");
        Session["reportname"] = "AllInsurancePatient_ForOPD";
        Session["RPTFORMAT"] = "pdf";


        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);
    }
    protected void GVPAtientInvoice_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex == -1)
            return;

        bool GenerateInvoice = Convert.ToBoolean((e.Row.FindControl("hdnGenerateInvoice") as HiddenField).Value);
       
        if (GenerateInvoice == true)
        {
            (e.Row.FindControl("ChkGenInv") as CheckBox).Enabled = false;
            e.Row.Cells[10].Text = "<span class='btn btn-xs btn-success' >Yes</span>";
        }
        else
        {
            (e.Row.FindControl("ChkGenInv") as CheckBox).Enabled = true;
            e.Row.Cells[10].Text = "<span class='btn btn-xs btn-danger' >No</span>";
        }
    }
    protected void btnreportAll_Click(object sender, EventArgs e)
    {
        BLLReports objreports = new BLLReports();
        string sql = "";
        if (txtInsuranceid.Text != "")
        {
            objreports.PatientInsuranceDetails_Invoice_ForAllOPD(Convert.ToInt32(ViewState["InsuranceId"]), txtStart.Text, txtEnd.Text, Convert.ToInt32(RblInvComp.SelectedValue));

            Session.Add("rptsql", sql);
            Session["rptname"] = Server.MapPath("~/Reports/Rpt_PatientInsuranceCompanywiseDetails.rpt");
            Session["reportname"] = "AllInsurancePatDetails";
            Session["RPTFORMAT"] = "pdf";


            string close = "<script language='javascript'>javascript:OpenReport();</script>";
            Type title1 = this.GetType();
            Page.ClientScript.RegisterStartupScript(title1, "", close);
              
            //DataSet dsCashSummary = new DataSet();
            //ReportDocument crystalReport = new ReportDocument();
            //  BLLReports ObjDOReport = new BLLReports();
            ////crystalReport.Load(Server.MapPath("~/Reports/Rpt_DeptStoreWiseItems.rpt"));

            //crystalReport.Load(Server.MapPath("~/Report/Rpt_DoctorWiseDailyCash.rpt"));
            //dsCashSummary = ObjDOReport.PatientInsuranceDetails_Invoice_ForAllOPD_Rept(1);
            //crystalReport.SetDataSource(dsCashSummary);
            //crystalReport.ParameterFields["FromDate"].CurrentValues.AddValue(Convert.ToString(ViewState["FromDate"]));
            //crystalReport.ParameterFields["ToDate"].CurrentValues.AddValue(Convert.ToString(ViewState["ToDate"]));

            ////crystalReport.ParameterFields["HospitalName"].CurrentValues.AddValue(Convert.ToString(Application["OrgnizationName"]));
            ////crystalReport.ParameterFields["HospitalAddress"].CurrentValues.AddValue(Convert.ToString(Application["OrgnizationAddress"]));
            //////crystalReport.ParameterFields["Image"].CurrentValues.AddValue(Application["ImagePath"]);
            ////crystalReport.ParameterFields["ReportFooter"].CurrentValues.AddValue("Hospital Software | Ph.020 123456789");
            //try
            //{
            //    crystalReport.ExportToHttpResponse
            //    (CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Employee");
            //}
            //catch (Exception ex)
            //{
            //}
            //finally
            //{
            //    crystalReport.Close();
            //    ((IDisposable)crystalReport).Dispose();
            //    GC.Collect();
            //    GC.SuppressFinalize(crystalReport);
            //}
    
          
        }
        else
        {
            txtInsuranceid.Focus();
            txtInsuranceid.BorderColor = System.Drawing.Color.Red;
        }

    }
    protected void btnExcel_Click(object sender, EventArgs e)
    {
        BLLReports objreports = new BLLReports();
        objreports.GetAll_AllInvoicePatient_ForOPD(Convert.ToInt32(ViewState["InsuranceId"]), txtStart.Text, txtEnd.Text, Convert.ToInt32(RblInvComp.SelectedValue));

        Session.Add("rptsql", "");
        Session["rptname"] = Server.MapPath("~/Reports/Rpt_AllInsurancePatient_ForOPD.rpt");
        Session["reportname"] = "AllInsurancePatient_ForOPD";
        Session["RPTFORMAT"] = "EXCEL";


        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);
    }
    protected void ChkAll_CheckedChanged(object sender, EventArgs e)
    {
        if (ChkAll.Checked == true)
        {
            for (int i = 0; i < GVPAtientInvoice.Rows.Count; i++)
            {
                CheckBox ChkGen = (GVPAtientInvoice.Rows[i].FindControl("ChkGenInv") as CheckBox);
                ChkGen.Checked = true;
               // lblRecAmt.Text = "0";
               // ViewState["RecAmt"] = "0";
            }
        }
        else
        {
            for (int i = 0; i < GVPAtientInvoice.Rows.Count; i++)
            {
                CheckBox ChkGen = (GVPAtientInvoice.Rows[i].FindControl("ChkGenInv") as CheckBox);
                ChkGen.Checked = false;
              //  lblRecAmt.Text = "0";
               // ViewState["RecAmt"] = "0";
            }
        }

    }
    protected void PostBackBind_DataBinding(object sender, EventArgs e)
    {
        LinkButton lb = (LinkButton)sender;
        ScriptManager sm = (ScriptManager)Page.Master.FindControl("PostBackButton");
       // sm.RegisterPostBackControl(lb);
    }
}