using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Data.Odbc;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Web.Management;
using System.Data;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Web.Script.Services;
using System.Web.Services;
using System.Net.Mail;
using System.Web.Management;

using System.Collections.Specialized;
using System.Text;

using ZXing;
using ZXing.QrCode;
using ZXing.Common;

public partial class MRC_FinalBillList : System.Web.UI.Page
{
    BELOPDPatReg objBELOpdReg = new BELOPDPatReg();
    DALOpdReg objDALOpdReg = new DALOpdReg();
    BELEmpReg objBELEmpReg = new BELEmpReg();
    DALEmpReg objDALEmpReg = new DALEmpReg();
    DALIPDDesk objDalIpdDesk = new DALIPDDesk();
    DataTable dt = new DataTable();
    Uniquemethod_Bal_C cl = new Uniquemethod_Bal_C();
    string rptname = "", path = "", selectonFormula = "", PrintUserName = "", formula="";
    BLLReports objreports = new BLLReports();
    string sql = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
           // txtStart.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtStart.Text = DateTime.Now.AddMonths(-1).ToString("dd/MM/yyyy");
            txtEnd.Text = DateTime.Now.ToString("dd/MM/yyyy");
            FillRoomCategory();
            refreshdata();
        }
    }

    protected void FillRoomCategory()
    {
        ddlRoomCategory.DataSource = objDalIpdDesk.FillRoomTypes(Convert.ToInt32(Session["FId"]), Convert.ToInt32(Session["BranchId"]));
        ddlRoomCategory.DataTextField = "RType";
        ddlRoomCategory.DataValueField = "RTypeId";
        ddlRoomCategory.DataBind();
        ddlRoomCategory.Items.Insert(0, new ListItem("Select Room", "0"));
    }

    public void refreshdata()
    {
        DataTable dt = new DataTable();

        using (SqlConnection con = DataAccess.ConInitForDC())
        {
            using (SqlCommand cmd = new SqlCommand("usp_GetIpdPatientListForDischarge_MRC", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FId", Convert.ToInt32(Session["FId"]));
                cmd.Parameters.AddWithValue("@BranchId", Convert.ToInt32(Session["Branchid"]));
                cmd.Parameters.AddWithValue("@PatRegId", Convert.ToInt32(ViewState["PatientInfoId"]));
                if (ddlRoomCategory.SelectedValue == "")
                {
                    ddlRoomCategory.SelectedValue = "0";
                }
                else
                {
                    cmd.Parameters.AddWithValue("@RTypeId", Convert.ToInt32(ddlRoomCategory.SelectedValue));
                }
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
        BLLReports objreports = new BLLReports();
        string sql = "";
        if (e.CommandName == "Select")
        {
            //Determine the RowIndex of the Row whose Button was clicked.
            int rowIndex = Convert.ToInt32(e.CommandArgument);

            //Reference the GridView Row.
            GridViewRow row = gvPatientInfo.Rows[rowIndex];
            int IpdId = Convert.ToInt32(gvPatientInfo.DataKeys[rowIndex].Values["IpdId"]);

            string PatRegId = gvPatientInfo.Rows[rowIndex].Cells[2].Text;


            // string response = @"~/frmTreatment2.aspx?RegId=" + regId + "&OpdNo=" + opd + "&Name=" + name + "&EntryDate=" + entryDate;
            string response = @"~/IpdAdvancePayment.aspx?RegId=" + PatRegId + "&IpdId=" + IpdId + "&Discharge=Yes";

            Response.Redirect(string.Format(response));

            // ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Name: " + name + "\\nRegId: " + regId + "');", true);
        }
        if (e.CommandName == "Report")
        {

            //Determine the RowIndex of the Row whose Button was clicked.
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            //Reference the GridView Row.
            GridViewRow row = gvPatientInfo.Rows[rowIndex];
            int IpdId = Convert.ToInt32(gvPatientInfo.DataKeys[rowIndex].Values["IpdId"]);
            int PatRegId = Convert.ToInt32(gvPatientInfo.Rows[rowIndex].Cells[2].Text);
            int BranchId = Convert.ToInt32(Session["Branchid"]);
            int FId = Convert.ToInt32(Session["FId"]);

            objreports.IpdBillDetails(IpdId, PatRegId, FId, BranchId);

            Session.Add("rptsql", sql);
            Session["rptname"] = Server.MapPath("~/Reports/Rpt_IpdBillDetails.rpt");
            Session["reportname"] = "IpdBillDetails_Report";
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
            int PatRegId = Convert.ToInt32(gvPatientInfo.Rows[rowIndex].Cells[2].Text);
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
        if (e.CommandName == "Discharge")
        {
            //Determine the RowIndex of the Row whose Button was clicked.
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            //Reference the GridView Row.
            GridViewRow row = gvPatientInfo.Rows[rowIndex];
            int IpdId = Convert.ToInt32(gvPatientInfo.DataKeys[rowIndex].Values["IpdId"]);

            int PatRegId =  Convert.ToInt32(gvPatientInfo.Rows[rowIndex].Cells[2].Text);
            int IPDNO = Convert.ToInt32(gvPatientInfo.Rows[rowIndex].Cells[3].Text);
            string BillNo = gvPatientInfo.Rows[rowIndex].Cells[4].Text;
             string Name = gvPatientInfo.Rows[rowIndex].Cells[5].Text;
             int BranchId = Convert.ToInt32(Session["Branchid"]);
             int FId = Convert.ToInt32(Session["FId"]);
              string Email = gvPatientInfo.Rows[rowIndex].Cells[10].Text;
              int InvoiceNo = Convert.ToInt32(gvPatientInfo.Rows[rowIndex].Cells[8].Text);
              objreports.IpdBillDetails(IpdId, PatRegId, FId, BranchId);
              if (Email == "&nbsp;")
              {

                  gvPatientInfo.Caption = "Patient E-mail id not found";
                  //Label6.Visible = true;
                  ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Patient E-mail id not found.');", true);
                  return;

              }
              else if (Email == "")
              {

                  gvPatientInfo.Caption = "Patient E-mail id not found";
                  //Label6.Visible = true;
                  ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Patient E-mail id not found.');", true);
                  return;

              }
              else
              {
                  SendEmail(PatRegId, Name, IPDNO, Email, InvoiceNo);
              }
            //if (ValidateEmail() == true)
            //{
               
            //}
           
            //string response = @"~/IpdDischargeSummary.aspx?RegId=" + PatRegId + "&IpdId=" + IPDNO + "&BillNo=" + BillNo;

            //Response.Redirect(string.Format(response));

            // ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Name: " + name + "\\nRegId: " + regId + "');", true);
        }
        //BLLReports objreports = new BLLReports();
        //string sql = "";
        if (e.CommandName == "SelectEMR")
        {
            //Determine the RowIndex of the Row whose Button was clicked.
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            //Reference the GridView Row.
            GridViewRow row = gvPatientInfo.Rows[rowIndex];
            int IpdId = Convert.ToInt32(gvPatientInfo.DataKeys[rowIndex].Values["IpdId"]);

            string PatRegId = gvPatientInfo.Rows[rowIndex].Cells[2].Text;

            string BillNo = gvPatientInfo.Rows[rowIndex].Cells[4].Text;
            string name = gvPatientInfo.Rows[rowIndex].Cells[5].Text.Trim();

            string entryDate = gvPatientInfo.Rows[rowIndex].Cells[7].Text;
            int opd = 0;

            // string response = @"~/frmTreatment2.aspx?RegId=" + regId + "&OpdNo=" + opd + "&Name=" + name + "&EntryDate=" + entryDate;
            // string response = @"~/IpdBillForPatientServices.aspx?RegId=" + PatRegId + "&IpdId=" + IpdId;
            Session["EmrRegNo"] = PatRegId;
            Session["EmrOpdNo"] = 0;
            Session["EmrIpdNo"] = IpdId;
            Session["EmrBillNo"] = BillNo;
            Session["FormType"] = "";
            // string response = @"~/frmTreatment2.aspx?RegId=" + regId + "&OpdNo=" + opd + "&Name=" + name + "&EntryDate=" + entryDate;
            //string response = @"~/DailyDrNote.aspx?RegId=" + PatRegId + "&OpdNo=" + opd + "&IpdNo=" + IpdId + "&Name=" + name + "&EntryDate=" + entryDate;
            string response = @"~/IPDEMRDashboard.aspx?RegId=" + PatRegId + "&OpdNo=" + opd + "&IpdNo=" + IpdId + "&Name=" + name + "&EntryDate=" + entryDate;

            Response.Redirect(string.Format(response));

            // ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Name: " + name + "\\nRegId: " + regId + "');", true);
        }
        if (e.CommandName == "ReAdmit")
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvPatientInfo.Rows[rowIndex];
            int IpdId = Convert.ToInt32(gvPatientInfo.DataKeys[rowIndex].Values["IpdId"]);

            string PatRegId = gvPatientInfo.Rows[rowIndex].Cells[2].Text;
            int BranchId = Convert.ToInt32(Session["Branchid"]);
            int FId = Convert.ToInt32(Session["FId"]);
            string username = Convert.ToString(Session["username"]);

           // objreports.ReadmitDischargePatient(IpdId, PatRegId, FId, BranchId, username);
            gvPatientInfo.Caption = "ACT Open!.";

            string response = @"~/IpdBillForPatientServices.aspx?RegId=" + PatRegId + "&IpdId=" + IpdId;

            Response.Redirect(string.Format(response));
        }
    }
    private bool ValidateEmail()
    {
        //string email = txtpatientmail.Text;
        //Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        //Match match = regex.Match(email);
        //if (match.Success)
        //{
        //    // txtpatientmail.BackColor = Color.White;
        //    // txtpatientmail.ForeColor = Color.Black;
        //}
        //else
        //{
        //    // txtpatientmail.Focus();
        //    //txtpatientmail.BackColor = Color.Orange;
        //    // txtpatientmail.ForeColor = Color.White;
        //    return false;

        //}
       
        return true;

    }
    public void SendEmail(int Patregid, string Patname, int IPDNO, string Email, int InvoiceNo)
    {
        createuserlogic_Bal_C aut = new createuserlogic_Bal_C();
        aut.getemail_HM(Session["username"].ToString(), Convert.ToInt32(Session["Branchid"]));
        string email = Email;
        if (aut.P_email == "")
        {
            gvPatientInfo.Caption = "Email id not found";
           // Label6.Visible = true;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Email id not found.');", true);
            return;

        }
        else if (email == "&nbsp;")
        {
           
                gvPatientInfo.Caption = "Patient E-mail id not found";
                //Label6.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Patient E-mail id not found.');", true);
                return;

        }
        else if (email == "")
        {

            gvPatientInfo.Caption = "Patient E-mail id not found";
            //Label6.Visible = true;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Patient E-mail id not found.');", true);
            return;

        }
        else
        {
           // Label6.Visible = false;
        }
        //selectonFormula = ReportParameterClass.SelectionFormula;
        ReportDocument CR = new ReportDocument();

       


        CrystalDecisions.CrystalReports.Engine.ReportDocument rep = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
        DataSetHMS Objrds = new DataSetHMS();
        DataSetHMS.Vw_IpdPatientBillServicesDataTable objIpdBillService5 = Objrds.Vw_IpdPatientBillServices;
        DataSetHMSTableAdapters.Vw_IpdPatientBillServicesTableAdapter objIpdBillServiceTA5 = new DataSetHMSTableAdapters.Vw_IpdPatientBillServicesTableAdapter();
        objIpdBillServiceTA5.Fill(objIpdBillService5);
        DataSetHMS.Vw_IpdInfoForBillServiceDetailDataTable objIPDInfo5 = Objrds.Vw_IpdInfoForBillServiceDetail;
        DataSetHMSTableAdapters.Vw_IpdInfoForBillServiceDetailTableAdapter objIPDInfoTA5 = new DataSetHMSTableAdapters.Vw_IpdInfoForBillServiceDetailTableAdapter();
        objIPDInfoTA5.Fill(objIPDInfo5);

        DataSetHMS.Vw_BillTransactions_BillDataTable objIPDtrans5 = Objrds.Vw_BillTransactions_Bill;
        DataSetHMSTableAdapters.Vw_BillTransactions_BillTableAdapter objIPDtransA5 = new DataSetHMSTableAdapters.Vw_BillTransactions_BillTableAdapter();
        objIPDtransA5.Fill(objIPDtrans5);

        rep.Load(Server.MapPath("~//Report//Rpt_IpdBillDetails_summary.rpt"));
        rep.SetDataSource((System.Data.DataSet)Objrds);

        string path = Server.MapPath("/" + Request.ApplicationPath + "/EmailReport/");
        string filename11 = Server.MapPath("EmailReport//" + "$" + Patname + Patregid + "$" + IPDNO + "" + Convert.ToInt32(Session["Branchid"]) + "MRC_Bill" + ".pdf");
        System.IO.File.WriteAllText(filename11, "");
        string exportedpath = "", selectionFormula = "";
        ReportParameterClass.SelectionFormula = "{Vw_IpdInfoForBillServiceDetail.PatRegID}='" + Patregid + "' ";
        ReportDocument crReportDocument = null;
        if (rep != null)
        {
            crReportDocument = (ReportDocument)rep;
        }
        CrystalDecisions.Shared.PageMargins pm = CR.PrintOptions.PageMargins;
        //int line = Uniquemethod_Bal_C.getnooflines(Session["Branchid"].ToString());
        int line = 10;
        pm.topMargin = 200 * line;
        //CR.PrintOptions.ApplyPageMargins(pm);

        exportedpath = filename11;
        //cl.ExportandPrintr("pdf", path, exportedpath, formula, CR);
        cl.ExportandPrintr_r("pdf", path, exportedpath, formula, rep);
        rep.Close();
        rep.Dispose();
        GC.Collect();

        //if (dt.Rows.Count == 0)
        //{
        //    string filepath11 = Server.MapPath("EmailReport//" + "$" + Patname + Patregid + "$" + IPDNO + "" + Convert.ToInt32(Session["Branchid"]) + "MRC_Bill" + ".pdf");
        //    FileInfo fi = new FileInfo(filepath11);
        //    fi.Delete();
        //    gvPatientInfo.Caption = "Report Not Generated, Please Generate Once Again ";
        //    return;
        //}

        if (aut.P_email != "")
        {
            bool flag = true;

            MailAddress to = new MailAddress(email.Trim());

            if (email != "" && email != null)
            {
                to = new MailAddress(email.Trim());
            }
            MailAddress from = new MailAddress("<" + aut.P_email + ">", aut.P_displayname);
            MailMessage msgmail = new MailMessage(from, to);
            Attachment att = new Attachment(Server.MapPath("~/EmailReport//" + "$" + Patname + Patregid + "$" + IPDNO + "" + Convert.ToInt32(Session["Branchid"]) + "MRC_Bill" + ".pdf"));

           

            msgmail.Attachments.Add(att);
            msgmail.Subject = "Invoice No:" + InvoiceNo + "-" + Patname;
            SmtpClient smtp = new SmtpClient();
            //smtp.Port = 25;
            smtp.Port = aut.P_Port;
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential(aut.P_email, aut.P_Password);
            msgmail.Priority = MailPriority.High;
            try
            {
                msgmail.IsBodyHtml = true;
                msgmail.Body = " Dear Relative <BR> It was a pleasure to have your relative at MRC. Please see the attached invoice for<BR>" + Patname + ". <BR>Thanking you in advance";
                smtp.Send(msgmail);
                att.Dispose();
            }
            catch (Exception)
            {
                flag = false;
            }
            if (flag == true)
            {
                if (aut.P_email == "")
                {
                    return;
                }
                gvPatientInfo.Caption = "E-mail send successfully.";
                //Label6.Visible = true;
                string filepath11 = Server.MapPath("EmailReport//" + "$" + Patname + Patregid + "$" + IPDNO + "" + Convert.ToInt32(Session["Branchid"]) + "MRC_Bill" + ".pdf");
                FileInfo fi = new FileInfo(filepath11);
               // fi.Delete();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('E-mail send successfully.');", true);
            }
            else
            {

                gvPatientInfo.Caption = "Error In E-mail Sending";
                //Label6.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Error In E-mail Sending.');", true);
            }

            //DeleteFile("EmailReport", "Nondescriptive");
            //DeleteFile("EmailReport", "Hemogram");
        }
    }
    protected void gvPatientInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvPatientInfo.PageIndex = e.NewPageIndex;
        refreshdata();
    }
    //protected void ddlConsDoctorName_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    // if (Convert.ToBoolean(ViewState["IsDirect"]) != true)
    //    //{

    //    int ConsultantDrId = Convert.ToInt32(ddlConsDoctorName.SelectedValue);
    //    int BranchId = Convert.ToInt32(Session["Branchid"]);
    //    int FId = Convert.ToInt32(Session["FId"]);

    //    string DeptId = objDALOpdReg.GetDeptId(Convert.ToInt32(ddlConsDoctorName.SelectedValue), FId, BranchId);

    //    ddlDepartment.SelectedValue = DeptId;


    //}
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
            txtPatientName.Text = PatientInfo[1];
            ViewState["PatientInfoId"] = PatientInfo[0];
        }

    }

    protected void btnReportPdf_Click(object sender, EventArgs e)
    {
        int RoomTypeId = 0;
        if (ddlRoomCategory.SelectedValue == "")
        {
            RoomTypeId = 0;
        }
        else
        {
            RoomTypeId = Convert.ToInt32(ddlRoomCategory.SelectedValue);
        }
        objreports.IpdPatientDueList_Report_MRC_Final(RoomTypeId, Convert.ToInt32(ViewState["PatientInfoId"]), Convert.ToInt32(Session["FId"]), Convert.ToInt32(Session["Branchid"]), txtStart.Text, txtEnd.Text);
        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Reports/Rpt_IPDDuePatientReport_MRC.rpt");
        Session["reportname"] = "Rpt_IPDDuePatientReport_MRC";
        Session["RPTFORMAT"] = "pdf";


        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);
    }
    protected void btnReportExcel_Click(object sender, EventArgs e)
    {
        int RoomTypeId = 0;
        if (ddlRoomCategory.SelectedValue == "")
        {
            RoomTypeId = 0;
        }
        else
        {
            RoomTypeId = Convert.ToInt32(ddlRoomCategory.SelectedValue);
        }
        objreports.IpdPatientDueList_Report_MRC_Final(RoomTypeId, Convert.ToInt32(ViewState["PatientInfoId"]), Convert.ToInt32(Session["FId"]), Convert.ToInt32(Session["Branchid"]), txtStart.Text, txtEnd.Text);
        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Reports/Rpt_IPDDuePatientReport_MRC.rpt");
        Session["reportname"] = "Rpt_IPDDuePatientReport_MRC";
        Session["RPTFORMAT"] = "EXCEL";


        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);
    }
}