using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using CrystalDecisions.CrystalReports.Engine;
using System.Web.UI.HtmlControls;
using System.Web.Services;
using System.Web.Script.Services;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Web.Management;
using System.Net;
using System.IO;

public partial class PatientFollowUp : BaseClass
{
    BLLReports ObjDOReport = new BLLReports();
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtFrom.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtTo.Text = DateTime.Now.AddDays(5).ToString("dd/MM/yyyy");
           
            ViewState["PatRegId"] = "0";
           
            FillGrid();

        }
        

    }


    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchPatient(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        return objDALOpdReg.FillAllOPDPatient(prefixText);
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
            ViewState["FromDate"] = Convert.ToDateTime(txtFrom.Text).ToString("yyyy-MM-dd");

        }
        else
        {
            ViewState["FromDate"] = "";
        }
        if (txtTo.Text.ToString() != "")
        {

            ViewState["ToDate"] = txtTo.Text.ToString();
            ViewState["ToDate"] = Convert.ToDateTime(txtTo.Text).ToString("yyyy-MM-dd");
        }
        else
        {
            ViewState["ToDate"] = "";
        }
        int BranchId = Convert.ToInt32(Session["BranchId"]);
        int FId = Convert.ToInt32(Session["FId"]);


        gvDailyCash.DataSource = ObjDOReport.GetAllPatientFollowUp(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), Convert.ToInt32(ViewState["PatRegId"]), txtMobileNo.Text.Trim(), BranchId, FId, Convert.ToInt32(ViewState["ConsultID"])); //Convert.ToInt32(ddlUser.SelectedValue));
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
   
    protected void btnReset_Click(object sender, EventArgs e)
    {

    }
    protected void gvDailyCash_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDailyCash.PageIndex = e.NewPageIndex;
        FillGrid();
    }
    
    protected void txtPatientName_TextChanged(object sender, EventArgs e)
    {
        if (txtPatientName.Text != "")
        {
            string[] PatientInfo = txtPatientName.Text.Split('-');
            txtPatientName.Text = PatientInfo[1];
            ViewState["PatRegId"] = PatientInfo[0];
        }
        else
        {
            ViewState["PatRegId"] = "0";
        }
    }
    protected void gvDailyCash_RowEditing(object sender, GridViewEditEventArgs e)
    {
        if (e.NewEditIndex == -1)
            return;
        int PatRegId = Convert.ToInt32(gvDailyCash.DataKeys[e.NewEditIndex].Value);
        string FID = (gvDailyCash.Rows[e.NewEditIndex].FindControl("HdnFId") as HiddenField).Value;
        string BranchId = (gvDailyCash.Rows[e.NewEditIndex].FindControl("HdnBranchId") as HiddenField).Value;
        string OpdNo = (gvDailyCash.Rows[e.NewEditIndex].FindControl("HdnOpdNo") as HiddenField).Value;
        string BillNo = (gvDailyCash.Rows[e.NewEditIndex].FindControl("HdnBillNo") as HiddenField).Value;
        Response.Redirect("OpdPaybillOutstanding.aspx?PatRegId=" + PatRegId + "&FID=" + FID + "&BillNo=" + BillNo + "&OpdNo=" + OpdNo, false);

    }


    protected void gvDailyCash_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string PatRegId = (gvDailyCash.DataKeys[e.RowIndex]["PatRegId"].ToString());
        string OpdNo = (gvDailyCash.DataKeys[e.RowIndex]["OpdNo"].ToString());
        string Message = ObjDOReport.DeleteOpdRegistration(Convert.ToInt32(PatRegId),Convert.ToInt32(OpdNo));
        DynamicMessage(lblMessage, Message);
        FillGrid();

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
    protected void gvDailyCash_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EmailSend")
        {
            //Determine the RowIndex of the Row whose Button was clicked.
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            //Reference the GridView Row.
            GridViewRow row = gvDailyCash.Rows[rowIndex];
            int IPDNO = Convert.ToInt32(gvDailyCash.DataKeys[rowIndex].Values["OpdNo"]);
            int PatRegId = Convert.ToInt32(gvDailyCash.DataKeys[rowIndex].Values["PatRegId"]);
           // int PatRegId = Convert.ToInt32(gvDailyCash.Rows[rowIndex].Cells[2].Text);
           // int IPDNO = Convert.ToInt32(gvDailyCash.Rows[rowIndex].Cells[3].Text);
            //string BillNo = gvDailyCash.Rows[rowIndex].Cells[4].Text;
            string Name = gvDailyCash.Rows[rowIndex].Cells[2].Text;
            string DrName = gvDailyCash.Rows[rowIndex].Cells[5].Text;
            int BranchId = Convert.ToInt32(Session["Branchid"]);
            int FId = Convert.ToInt32(Session["FId"]);
            string FollowUpDate = gvDailyCash.Rows[rowIndex].Cells[6].Text;
            string Email = gvDailyCash.Rows[rowIndex].Cells[8].Text;
            if (Email == "&nbsp;")
            {

                gvDailyCash.Caption = "Patient E-mail id not found";
                //Label6.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Patient E-mail id not found.');", true);
                return;

            }
            else if (Email == "")
            {

                gvDailyCash.Caption = "Patient E-mail id not found";
                //Label6.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Patient E-mail id not found.');", true);
                return;

            }
            else
            {
                SendEmail(PatRegId, Name, IPDNO, Email, 0, DrName, FollowUpDate);
            }
        }
    }
    public void SendEmail(int Patregid, string Patname, int IPDNO, string Email, int InvoiceNo,string DrName, string FollowUpDate)
    {
        createuserlogic_Bal_C aut = new createuserlogic_Bal_C();
        aut.getemail_HM(Session["username"].ToString(), Convert.ToInt32(Session["Branchid"]));
        string email = Email;
        if (aut.P_email == "")
        {
            gvDailyCash.Caption = "Email id not found";
            // Label6.Visible = true;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Email id not found.');", true);
            return;

        }
        else if (email == "&nbsp;")
        {

            gvDailyCash.Caption = "Patient E-mail id not found";
            //Label6.Visible = true;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Patient E-mail id not found.');", true);
            return;

        }
        else if (email == "")
        {

            gvDailyCash.Caption = "Patient E-mail id not found";
            //Label6.Visible = true;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Patient E-mail id not found.');", true);
            return;

        }
        else
        {
            // Label6.Visible = false;
        }
        

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
          //  Attachment att = new Attachment(Server.MapPath("~/EmailReport//" + "$" + Patname + Patregid + "$" + IPDNO + "" + Convert.ToInt32(Session["Branchid"]) + "MRC_Bill" + ".pdf"));



           // msgmail.Attachments.Add(att);
            msgmail.Subject = " Reminder of appointment- Sheriff General Hospital.";
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
                msgmail.Body = " Gental reminder of your appointment with " + DrName + " at Sheriff General Hospital on the date of " + FollowUpDate + " ";
                smtp.Send(msgmail);
               // att.Dispose();
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
                gvDailyCash.Caption = "E-mail send successfully.";
                //Label6.Visible = true;
               
                // fi.Delete();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('E-mail send successfully.');", true);
            }
            else
            {

                gvDailyCash.Caption = "Error In E-mail Sending";
                //Label6.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Error In E-mail Sending.');", true);
            }

            //DeleteFile("EmailReport", "Nondescriptive");
            //DeleteFile("EmailReport", "Hemogram");
        }
    }
}