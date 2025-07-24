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

public partial class EditPatientInvoice : BasePage
{
    clsEmr obj = new clsEmr();
    DALPatientInformation objDALPatInfo = new DALPatientInformation();
    DALOpdReg objDALOpdReg = new DALOpdReg();
    BLLReports objreports = new BLLReports();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ViewState["InsuranceId"] = 0;
            ViewState["ConsultID"] = "0";
            ViewState["ServiceId"] = "0";
            PindPatientInformation();
            BindPatientDetails();
        }

    }

  
        

    public void PindPatientInformation()
    {
        DataTable dt = new DataTable();
        
        dt = obj.EditPatientInvoice(Convert.ToString(Request.QueryString["InvoiceNo"]));
        try
        {
            if (dt != null)
            {
                lblPatientName.Text = Convert.ToString(dt.Rows[0]["FirstName"]);
                txtpatientregid.Text = Convert.ToString(dt.Rows[0]["PatRegId"]);
                // lblIpd.Text = "0";
                //lblOpd.Text = Convert.ToString(dt.Rows[0]["PatRegId"]);
                //lblOpd.Text = Convert.ToString(dt.Rows[0]["OpdNo"]);
                lblMobileNo.Text = Convert.ToString(dt.Rows[0]["MobileNo"]);
               
                string Birthdate = Convert.ToString(dt.Rows[0]["BirthDate"]);
                Birthdate = DateTime.Parse(Birthdate).ToString("dd/MM/yyyy");
                getAge(Birthdate);
                //lblAge.Text = Convert.ToString(dt.Rows[0]["Age"]) + "" + Convert.ToString(dt.Rows[0]["AgeType"]) + "/" + Convert.ToString(dt.Rows[0]["GenderName"]);
                lblAge.Text = lblAge.Text + "/" + Convert.ToString(dt.Rows[0]["GenderName"]);
             
                //ViewState["DrId"] = Convert.ToInt32(dt.Rows[0]["DrId"]);
                lblAddress.Text = Convert.ToString(dt.Rows[0]["PatientAddress"]);
                lblCompany.Text = Convert.ToString(dt.Rows[0]["PatientInsuType"]);
                txtchargeNumber.Text = Convert.ToString(dt.Rows[0]["ChargeNo"]);
                txtgenerateOn.Text = Convert.ToString(dt.Rows[0]["CreatedOn"]);

                lblBillAmount.Text = Convert.ToString(dt.Rows[0]["BillAmt"]);

                lblInsuanceAmt.Text = Convert.ToString(dt.Rows[0]["InsuranceAmt"]);
               // txtdiscgiven.Text = Convert.ToString(dt.Rows[0]["discount"]);
               

            }
        }
        catch (Exception ex)
        {

        }
    }
    public void getAge(string Birthdate)
    {
        int intYear, intMonth, intDays;
        DateTime Birthday = Convert.ToDateTime(Birthdate);
        intYear = Birthday.Year;
        intMonth = Birthday.Month;
        intDays = Birthday.Day;

        DateTime dtt = Convert.ToDateTime(Birthdate);

        DateTime td = DateTime.Now;
        int Leap_Year = 0;
        for (int i = dtt.Year; i < td.Year; i++)
        {
            if (DateTime.IsLeapYear(i))
            {
                ++Leap_Year;
            }
        }
        TimeSpan timespan = td.Subtract(Birthday);
        intDays = timespan.Days - Leap_Year;
        int intResult = 0;
        intYear = Math.DivRem(intDays, 365, out intResult);
        intMonth = Math.DivRem(intResult, 30, out intResult);
        intDays = intResult;
        if (intYear > 0)//&& intDays > 0
        {
            lblAge.Text = intYear.ToString() + " Years";
            //ddlAge.SelectedIndex = 0;
        }
        else if (intMonth > 0)
        {
            lblAge.Text = intMonth.ToString() + " Months";
            //ddlAge.SelectedIndex = 1;
        }
        else if (intDays > 0)
        {
            lblAge.Text = intDays.ToString() + " Days";
            // ddlAge.SelectedIndex = 2;
        }
    }

    protected void GVPAtientInvoice_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVPAtientInvoice.PageIndex = e.NewPageIndex;
        BindPatientDetails();
    }

    public void BindPatientDetails()
    {

        objreports.PatientInsuranceDetails_Invoice_ForOPD_Edit(Convert.ToInt32(Request.QueryString["InvoiceNo"]), "0");
        GVPAtientInvoice.DataSource = objDALOpdReg.Get_ChargeNo_ForOPDPatients(Convert.ToString(Request.QueryString["InvoiceNo"]));
        GVPAtientInvoice.DataBind();
    }
    protected void GVPAtientInvoice_RowCommand(object sender, GridViewCommandEventArgs e)
    {
    }
    protected void txtdiscgiven_TextChanged(object sender, EventArgs e)
    {
        if (txtdiscgiven.Text.Trim() != "")
        {
            if (Convert.ToSingle(txtdiscgiven.Text) > 0)
            {
                if (RblDisType.SelectedValue == "2")
                {
                    if (Convert.ToSingle(txtdiscgiven.Text) <= 100)
                    {
                        double DiscAmt = Convert.ToSingle(lblInsuanceAmt.Text) * Convert.ToSingle(txtdiscgiven.Text) / 100;
                        txtAftDiscAmt.Text = Convert.ToString(Convert.ToSingle(lblInsuanceAmt.Text) - DiscAmt);
                    }
                    else
                    {
                        lblMessage.Text = "Discount(%) not greater than 100%!";
                    }

                }
                else
                {
                    txtAftDiscAmt.Text = Convert.ToString(Convert.ToSingle(lblInsuanceAmt.Text) - Convert.ToSingle(txtdiscgiven.Text));

                }
            }
            else
            {
                lblMessage.Text = "Discount(%) must greater than Zero!";
            }
        }
        else
        {
            lblMessage.Text = "Required Discount Amt (%)!";
        }
    }
    protected void bnSave_Click(object sender, EventArgs e)
    {
        if (txtdiscgiven.Text.Trim() != "")
        {
            if (Convert.ToSingle(txtdiscgiven.Text) > 0)
            {
                double DiscAmt = 0, DiscAmtGiven = 0,Disper=0;
                if (RblDisType.SelectedValue == "2")
                {
                    if (Convert.ToSingle(txtdiscgiven.Text) <= 100)
                    {
                         DiscAmt = Convert.ToSingle(lblInsuanceAmt.Text) * Convert.ToSingle(txtdiscgiven.Text) / 100;
                        txtAftDiscAmt.Text = Convert.ToString(Convert.ToSingle(lblInsuanceAmt.Text) - DiscAmt);
                        DiscAmtGiven = DiscAmt;
                        Disper = Convert.ToSingle(txtdiscgiven.Text);
                    }
                    else
                    {

                        lblMessage.Text = "Discount(%) not greater than 100%!";
                        return;
                    }
                    
                }
                else
                {
                    txtAftDiscAmt.Text = Convert.ToString(Convert.ToSingle(lblInsuanceAmt.Text) - Convert.ToSingle(txtdiscgiven.Text));
                    DiscAmtGiven = Convert.ToSingle(txtdiscgiven.Text);
                }
               
                   

                    int FId = Convert.ToInt32(Session["FId"]);
                    int BranchId = Convert.ToInt32(Session["BranchId"]);
                    string username = Convert.ToString(Session["username"]);
                    string Message = objDALOpdReg.InsertInsuranceEditInvoice_ForOPD(Convert.ToInt32(Request.QueryString["InvoiceNo"]), Convert.ToSingle(txtAftDiscAmt.Text),
                        Convert.ToSingle(Disper), Convert.ToSingle(DiscAmtGiven), Convert.ToSingle(lblInsuanceAmt.Text), Convert.ToString(txtdiscRemark.Text), Convert.ToString(username));
                    lblMessage.Text = Message;
                    txtdiscRemark.Text = "";
                    txtdiscgiven.Text = "";
                    PindPatientInformation();
                    BindPatientDetails();
            }
            else
            {
                lblMessage.Text = "Discount(%) must greater than Zero!";
            }
        }
        else
        {
            lblMessage.Text = "Required Discount Amt (%)!";
        }
       
    }
    protected void ChkaddService_CheckedChanged(object sender, EventArgs e)
    {
        if (ChkaddService.Checked == true)
        {
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
        else
        {
            ViewState["ConsultID"] = "0";

        }
        
    }

    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchService(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();

        string Type = ""; ;

        return objDALOpdReg.FillAll_OPDService(prefixText, Type);


    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (txtserviceName.Text == "")
        {
            txtserviceName.Focus();
            txtserviceName.BorderColor = System.Drawing.Color.Red;
            lblAddService.Text = "Enter service!";
            return;
        }
        if (Convert.ToInt32( ViewState["ServiceId"]) == 0)
        {
            txtserviceName.Focus();
            txtserviceName.BorderColor = System.Drawing.Color.Red;
            lblAddService.Text = "Select  service!";
            return;
        }
        if (txtcharges.Text == "")
        {
            txtcharges.Focus();
            txtcharges.BorderColor = System.Drawing.Color.Red;
            lblAddService.Text = "Enter charges!";
            return;
        }
        if (txtcharges.Text == "0")
        {
            txtcharges.Focus();
            txtcharges.BorderColor = System.Drawing.Color.Red;
            lblAddService.Text = "Enter charges!";
            return;
        }
        if (txtqty.Text == "")
        {
            txtqty.Focus();
            txtqty.BorderColor = System.Drawing.Color.Red;
            lblAddService.Text = "Enter qty!";
            return;
        }
        if (txtqty.Text == "0")
        {
            txtqty.Focus();
            txtqty.BorderColor = System.Drawing.Color.Red;
            lblAddService.Text = "Enter qty!";
            return;
        }
        if (Convert.ToInt32(ViewState["ServiceId"]) == 1111111)
        {
            ViewState["ServiceId"] = 0;
        }
        string username = Convert.ToString(Session["username"]);
        if (Convert.ToString(txtDate.Text) == "")
        {
            txtDate.Focus();
            txtDate.BorderColor = System.Drawing.Color.Red;
            return;

        }

        float BillAmt = Convert.ToSingle(txtcharges.Text) * Convert.ToSingle(txtqty.Text);
        string Message = objDALOpdReg.UpdatePatientInvoiceChargeService(Convert.ToInt32(Request.QueryString["InvoiceNo"]), Convert.ToSingle(BillAmt), Convert.ToInt32(ViewState["ServiceId"]), Convert.ToInt32(ViewState["ConsultID"]), Convert.ToInt32(txtqty.Text), Convert.ToSingle(txtcharges.Text), Convert.ToString(username),Convert.ToString(ViewState["MTCode"]),Convert.ToString(ViewState["GroupName"]),Convert.ToDateTime( txtDate.Text));
        lblAddService.Text = "Service Added successfully!";
        BindPatientDetails();
        PindPatientInformation();
        txtserviceName.Text = "";
        txtConsDoctorName.Text = "";
        txtcharges.Text = "";
        txtqty.Text = "";
    }
    protected void txtserviceName_TextChanged(object sender, EventArgs e)
    {
        if (txtserviceName.Text != "")
        {
            string[] Service = txtserviceName.Text.Split('-');
            if (txtserviceName.Text.Split('-').Length > 1)
            {

                if (txtserviceName.Text.Split('-').Length == 4)
                {
                    txtserviceName.Text = Service[1];
                    ViewState["GroupName"] = Service[3];
                    txtcharges.Text = Service[2];
                }
                if (txtserviceName.Text.Split('-').Length == 5)
                {
                    txtserviceName.Text = Service[1] + " " + Service[2];
                    ViewState["GroupName"] = Service[4];
                    txtcharges.Text = Service[3];
                }
                if (txtserviceName.Text.Split('-').Length == 6)
                {
                    txtserviceName.Text = Service[1] + " " + Service[2] + " " + Service[3];
                    ViewState["GroupName"] = Service[5];
                    txtcharges.Text = Service[4];
                }
                if (Convert.ToString(ViewState["GroupName"]) == "M")
                {
                    ViewState["ServiceId"] ="1111111";
                    ViewState["MTCode"] = Convert.ToString(Service[0]);
                }
                else if (Convert.ToString(ViewState["GroupName"]) == "R")
                {
                    ViewState["ServiceId"]="1111111";
                    ViewState["MTCode"] = Convert.ToString(Service[0]);
                }
                else
                {
                    ViewState["ServiceId"] = Convert.ToInt32(Service[0]);
                    ViewState["MTCode"] = Convert.ToString("0");
                }
            }
            else
            {
                ViewState["ServiceId"] = "0";
            }
        }
        else
        {
            ViewState["ServiceId"] = "0";
        }
    }
    protected void GVPAtientInvoice_RowEditing(object sender, GridViewEditEventArgs e)
    {
        if (e.NewEditIndex == -1)
            return;
        int PID = Convert.ToInt32(GVPAtientInvoice.DataKeys[e.NewEditIndex].Value);
        e.Cancel = true;
        objDALOpdReg.DeletePatient_ChargeService(PID);
        BindPatientDetails();
        PindPatientInformation();
        lblAddService.Text = "Service deleted succfully!";

    }
}