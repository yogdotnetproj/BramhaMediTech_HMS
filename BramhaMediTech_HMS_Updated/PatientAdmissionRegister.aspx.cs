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

public partial class PatientAdmissionRegister : System.Web.UI.Page
{
    DALIPDDesk objDalIpdDesk = new DALIPDDesk();
    DALPatientInformation objDALPatInfo = new DALPatientInformation();
    BELPatientInformation objBELPatInfo = new BELPatientInformation();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["ConsultID"] = 0;
            ViewState["PatientInfoId"]=0;
            ViewState["Referdr"] = 0;
            txtFrom.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtTo.Text = DateTime.Now.ToString("dd/MM/yyyy");
            //fillgrid();
            LoadPatientMainType();
            LoadPatientSubCategoryName(Convert.ToInt32(ddlPatientCategoryName.SelectedValue));
            FillRoomCategory();

        }

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
    private void LoadPatientMainType()
    {
        ddlPatientCategoryName.DataSource = objDALPatInfo.FillPatMainTypeDrop();
        ddlPatientCategoryName.DataTextField = "PatMainType";
        ddlPatientCategoryName.DataValueField = "PatMainTypeId";
        ddlPatientCategoryName.DataBind();
        ddlPatientCategoryName.Items.Insert(0, new ListItem("Select Type", "0"));

        ddlSurgeryType.DataSource = objDALPatInfo.Get_Surgery_Type();
        ddlSurgeryType.DataTextField = "SurgeryName";
        ddlSurgeryType.DataValueField = "SurgeryId";
        ddlSurgeryType.DataBind();
        ddlSurgeryType.Items.Insert(0, new ListItem("Select Surgery", "0"));
    }
    protected void FillRoomCategory()
    {
        ddlRoomCategory.DataSource = objDalIpdDesk.FillRoomTypes(Convert.ToInt32(Session["FId"]), Convert.ToInt32(Session["BranchId"]));
        ddlRoomCategory.DataTextField = "RType";
        ddlRoomCategory.DataValueField = "RTypeId";
        ddlRoomCategory.DataBind();
        ddlRoomCategory.Items.Insert(0, new ListItem("Select Room", "0"));
    }
    public void LoadPatientSubCategoryName(int PatientCategoryId)
    {
        ddlPatientSubCategoryName.DataSource = objDALPatInfo.FillPatInsuTypeDrop(PatientCategoryId);
        ddlPatientSubCategoryName.DataTextField = "PatientInsuType";
        ddlPatientSubCategoryName.DataValueField = "PatientInsuTypeId";
        ddlPatientSubCategoryName.DataBind();
        ddlPatientSubCategoryName.Items.Insert(0, new ListItem("Select SubType", "0"));

    }
    protected void ddlPatientCategoryName_SelectedIndexChanged(object sender, EventArgs e)
    {
        int PatientCategoryId = Convert.ToInt32(ddlPatientCategoryName.SelectedValue);
        ViewState["PatientCategoryID"] = PatientCategoryId;

        LoadPatientSubCategoryName(PatientCategoryId);
    }
    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchPatient(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        return objDALOpdReg.FillAllPatient(prefixText);
    }
    protected void txtPatientName_TextChanged(object sender, EventArgs e)
    {
        if (txtPatientName.Text != "")
        {
            string[] PatientInfo = txtPatientName.Text.Split('-');
            if (PatientInfo.Length > 1)
            {
                txtPatientName.Text = PatientInfo[1];
                ViewState["PatientInfoId"] = PatientInfo[0];
            }
        }
        else
        {
            ViewState["PatientInfoId"]=0;
        }


    }


    protected void Print_Click(object sender, EventArgs e)
    {
         string sql = "";
        BLLReports objreports = new BLLReports();
       

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

            int PatMainType = Convert.ToInt32(ddlPatientCategoryName.SelectedValue);
            int PatSubType = Convert.ToInt32(ddlPatientSubCategoryName.SelectedValue);
            int DrId = Convert.ToInt32(ViewState["ConsultID"]);
            int PatRegId = Convert.ToInt32(ViewState["PatientInfoId"]);
            int RoomTypeId = Convert.ToInt32(ddlRoomCategory.SelectedValue);

            int BranchId = Convert.ToInt32(Session["BranchId"]);
            int FId = Convert.ToInt32(Session["FId"]);
            int Referdr = Convert.ToInt32(ViewState["Referdr"]);
            int Patstatus = Convert.ToInt32( RblType.SelectedValue);
            objreports.FillIpdAdmissionRegister(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), PatRegId, DrId, PatMainType, PatSubType, RoomTypeId, FId, BranchId, Referdr, Patstatus);

            Session.Add("rptsql", sql);
            Session["rptname"] = Server.MapPath("~/Reports/Rpt_IpdAdmissionRegister.rpt");
            Session["reportname"] = "IpdAdmissionRegister";
            Session["RPTFORMAT"] = "pdf";


            string close = "<script language='javascript'>javascript:OpenReport();</script>";
            Type title1 = this.GetType();
            Page.ClientScript.RegisterStartupScript(title1, "", close);
        }

    protected void gvPatientInfo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        BLLReports objreports = new BLLReports();
        string sql = "";
        if (e.CommandName == "Select")
        {
                          
                DataSet ds = new DataSet();
                BLLReports objReports = new BLLReports();
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                //Reference the GridView Row.
                GridViewRow row = gvPatientInfo.Rows[rowIndex];
                int IpdId = Convert.ToInt32(gvPatientInfo.DataKeys[rowIndex].Values["IpdId"]);
                int PatRegId = Convert.ToInt32(gvPatientInfo.Rows[rowIndex].Cells[1].Text);
                int BranchId = Convert.ToInt32(Session["Branchid"]);
                int FId = Convert.ToInt32(Session["FId"]);
                ReportDocument CrystalReport = new ReportDocument();
                CrystalReport.Load(Server.MapPath("~/Report/Rpt_AdmissionFrontSheet.rpt"));
                ds = objReports.GetIpdPatientCard(IpdId, FId, BranchId);
                CrystalReport.SetDataSource(ds);
                CrystalReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Employee");
           
        }
        if (e.CommandName == "Report")
        {

            //Determine the RowIndex of the Row whose Button was clicked.
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            //Reference the GridView Row.
            GridViewRow row = gvPatientInfo.Rows[rowIndex];
            int IpdId = Convert.ToInt32(gvPatientInfo.DataKeys[rowIndex].Values["IpdId"]);
            int PatRegId = Convert.ToInt32(gvPatientInfo.Rows[rowIndex].Cells[1].Text);
            int BranchId = Convert.ToInt32(Session["Branchid"]);
            int FId = Convert.ToInt32(Session["FId"]);

            objreports.IpdFrontSheetSummaryReport(IpdId, PatRegId, FId, BranchId);

            Session.Add("rptsql", sql);
            Session["rptname"] = Server.MapPath("~/Reports/Rpt_FrontSheetSummary_Report.rpt");
            Session["reportname"] = "Rpt_FrontSheetSummary";
            Session["RPTFORMAT"] = "pdf";


            string close = "<script language='javascript'>javascript:OpenReport();</script>";
            Type title1 = this.GetType();
            Page.ClientScript.RegisterStartupScript(title1, "", close);




        }
        if (e.CommandName == "Summary")
        {

            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvPatientInfo.Rows[rowIndex];
            int IpdId = Convert.ToInt32(gvPatientInfo.DataKeys[rowIndex].Values["IpdId"]);
            int PatRegId = Convert.ToInt32(gvPatientInfo.Rows[rowIndex].Cells[1].Text);
            int BranchId = Convert.ToInt32(Session["Branchid"]);
            int FId = Convert.ToInt32(Session["FId"]);
            // objreports.IpdBillSummary(IpdId, PatRegId);

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
    public void refreshdata()
    {
        BLLReports objreports = new BLLReports();


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

        int PatMainType = Convert.ToInt32(ddlPatientCategoryName.SelectedValue);
        int PatSubType = Convert.ToInt32(ddlPatientSubCategoryName.SelectedValue);
        int DrId = Convert.ToInt32(ViewState["ConsultID"]);
        int PatRegId = Convert.ToInt32(ViewState["PatientInfoId"]);
        int RoomTypeId = Convert.ToInt32(ddlRoomCategory.SelectedValue);
        string  AdmissionType = Convert.ToString(ddlSurgeryType.SelectedItem.Text);

        int BranchId = Convert.ToInt32(Session["BranchId"]);
        int FId = Convert.ToInt32(Session["FId"]);
        int Referdr = Convert.ToInt32(ViewState["Referdr"]);
        gvPatientInfo.DataSource = objreports.FillIpdAdmissionRegisterGrid(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), PatRegId, DrId, PatMainType, PatSubType, RoomTypeId, FId, BranchId, AdmissionType, Referdr,Convert.ToInt32( RblType.SelectedValue));
        gvPatientInfo.DataBind();
        LblMsg.Text = "Total Patient count is:" + gvPatientInfo.Rows.Count;
    }
    protected void gvPatientInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvPatientInfo.PageIndex = e.NewPageIndex;
        refreshdata();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        refreshdata();
        ViewState["PatientInfoId"] = "0";
    }


    protected void txtreferdr_TextChanged(object sender, EventArgs e)
    {
        if (txtreferdr.Text != "")
        {
            string[] PatientInfo = txtreferdr.Text.Split('-');
            if (PatientInfo.Length > 1)
            {
                txtreferdr.Text = PatientInfo[1];
                ViewState["Referdr"] = PatientInfo[0];
            }
        }
        else
        {
            ViewState["Referdr"] = 0;
        }
    }

    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchReferDr(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        return objDALOpdReg.FillReferDrSec(prefixText);
    }
    protected void btnexcel_Click(object sender, EventArgs e)
    {
        string sql = "";
        BLLReports objreports = new BLLReports();


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

        int PatMainType = Convert.ToInt32(ddlPatientCategoryName.SelectedValue);
        int PatSubType = Convert.ToInt32(ddlPatientSubCategoryName.SelectedValue);
        int DrId = Convert.ToInt32(ViewState["ConsultID"]);
        int PatRegId = Convert.ToInt32(ViewState["PatientInfoId"]);
        int RoomTypeId = Convert.ToInt32(ddlRoomCategory.SelectedValue);

        int BranchId = Convert.ToInt32(Session["BranchId"]);
        int FId = Convert.ToInt32(Session["FId"]);
        int Referdr = Convert.ToInt32(ViewState["Referdr"]);
        int Patstatus = Convert.ToInt32(RblType.SelectedValue);
        objreports.FillIpdAdmissionRegister(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), PatRegId, DrId, PatMainType, PatSubType, RoomTypeId, FId, BranchId, Referdr, Patstatus);

        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Reports/Rpt_IpdAdmissionRegister.rpt");
        Session["reportname"] = "IpdAdmissionRegister";
        Session["RPTFORMAT"] = "EXCEL";


        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);
    }
}

    
