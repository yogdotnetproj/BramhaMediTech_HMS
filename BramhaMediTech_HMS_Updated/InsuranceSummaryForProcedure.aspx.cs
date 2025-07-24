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

public partial class InsuranceSummaryForProcedure : BasePage
{
    BELOPDPatReg objBELOpdReg = new BELOPDPatReg();
    DALOpdReg objDALOpdReg = new DALOpdReg();
    BELEmpReg objBELEmpReg = new BELEmpReg();
    DALEmpReg objDALEmpReg = new DALEmpReg();
    DALIPDDesk objDalIpdDesk = new DALIPDDesk();
    BLLReports objreports = new BLLReports();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ViewState["InsuranceId"] = 0;
            txtStart.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtEnd.Text = DateTime.Now.ToString("dd/MM/yyyy");
          //  FillRoomCategory();
            refreshdata();
        }
    }

    //protected void FillRoomCategory()
    //{
    //    ddlRoomCategory.DataSource = objDalIpdDesk.FillRoomTypes(Convert.ToInt32(Session["FId"]), Convert.ToInt32(Session["BranchId"]));
    //    ddlRoomCategory.DataTextField = "RType";
    //    ddlRoomCategory.DataValueField = "RTypeId";
    //    ddlRoomCategory.DataBind();
    //    ddlRoomCategory.Items.Insert(0, new ListItem("Select Room", "0"));
    //}

    public void refreshdata()
    {
        DataTable dt = new DataTable();

        using (SqlConnection con = DataAccess.ConInitForDC())
        {
            using (SqlCommand cmd = new SqlCommand("usp_GetInsuranceSummaryForProcedure", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FId", Convert.ToInt32(Session["FId"]));
                cmd.Parameters.AddWithValue("@BranchId", Convert.ToInt32(Session["Branchid"]));
                cmd.Parameters.AddWithValue("@PatRegId", Convert.ToInt32(ViewState["PatientInfoId"]));
                cmd.Parameters.AddWithValue("@InsuranceId", Convert.ToInt32(ViewState["InsuranceId"]));
                cmd.Parameters.AddWithValue("@BillGroup", ddlBillGroup.SelectedValue);                
                cmd.Parameters.AddWithValue("@start", txtStart.Text);
                cmd.Parameters.AddWithValue("@end", txtEnd.Text);
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
            ViewState["Report"] = "True";
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvPatientInfo.Rows[rowIndex];

            int BranchId = Convert.ToInt32(Session["BranchId"]);
            //int FId = Convert.ToInt32(Session["FId"]);

            // this.RegisterPostBackControl();

            //DropDownList ddl_Receipt = gvPatientInfo.Rows[row.RowIndex].FindControl("ddlReceipt") as DropDownList;
            HiddenField HdnLabNo = gvPatientInfo.Rows[row.RowIndex].FindControl("HdnOpdNo") as HiddenField;
            HiddenField HdnProcedureNo = gvPatientInfo.Rows[row.RowIndex].FindControl("HdnProcedureNo") as HiddenField;
            HiddenField HdnBillNo = gvPatientInfo.Rows[row.RowIndex].FindControl("HdnBillNo") as HiddenField;
             HiddenField HdnFId = gvPatientInfo.Rows[row.RowIndex].FindControl("HdnFId") as HiddenField;
            int PatRegId = Convert.ToInt32(gvPatientInfo.DataKeys[rowIndex].Values["PatRegId"]);
            string sql = "";


            //BLLReports objBLLReports = new BLLReports();
            //DataSet dsCustomers = new DataSet();

            //dsCustomers = objBLLReports.GetLabBillDetailsAll(Convert.ToInt32(HdnBillNo.Value), Convert.ToInt32(HdnLabNo.Value), Convert.ToInt32(PatRegId), Convert.ToInt32(Session["FId"]), Convert.ToInt32(Session["BranchId"]));

            //Session.Add("rptsql", sql);
            //Session["rptname"] = Server.MapPath("~/Report/Rpt_LabBilling.rpt");
            //Session["reportname"] = "LabReceipt";
            //Session["RPTFORMAT"] = "pdf";


            //string close = "<script language='javascript'>javascript:OpenReport();</script>";
            //Type title1 = this.GetType();
            //Page.ClientScript.RegisterStartupScript(title1, "", close);



           // string sql = "";
            objreports.GetProcedureBillDetails(Convert.ToInt32( HdnBillNo.Value), Convert.ToInt32( PatRegId), Convert.ToInt32( HdnProcedureNo.Value),Convert.ToInt32(  HdnFId.Value), BranchId);

            Session.Add("rptsql", sql);
            Session["rptname"] = Server.MapPath("~/Reports/Rpt_ProcedureBillReport.rpt");
            Session["reportname"] = "ProcedureBillDetails_Report";
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

    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchPatient(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        return objDALOpdReg.FillAllPatient(prefixText);
    }
    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchInsurance(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        return objDALOpdReg.FillAllInsurance(prefixText);
    }
    protected void txtPatientName_TextChanged(object sender, EventArgs e)
    {

        string[] PatientInfo = txtPatientName.Text.Split('-');
        txtPatientName.Text = PatientInfo[1];
        ViewState["PatientInfoId"] = PatientInfo[0];

    }
    protected void Print_Click(object sender, EventArgs e)
    {
        string sql = "";


        int BranchId = Convert.ToInt32(Session["BranchId"]);
        int FId = Convert.ToInt32(Session["FId"]);
        int PatRegId = Convert.ToInt32(ViewState["PatientInfoId"]);
        
        string start = txtStart.Text;
        string end = txtEnd.Text;
        int InsuranceId = Convert.ToInt32(ViewState["InsuranceId"]);
        string BillGroup = ddlBillGroup.SelectedValue;
        objreports.InsuranceSummaryForProcedure(start, end, PatRegId,BillGroup,InsuranceId, FId, BranchId);

        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Reports/Rpt_InsuranceSummaryProcedure.rpt");
        Session["reportname"] = "InsuranceSummaryProcedure";
        Session["RPTFORMAT"] = "pdf";


        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);



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
}