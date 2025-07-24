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

public partial class CreateChargeNumber : BasePage
{
    clsEmr obj = new clsEmr();
    DALPatientInformation objDALPatInfo = new DALPatientInformation();
    DALOpdReg objDALOpdReg = new DALOpdReg();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ViewState["InsuranceId"] = 0;
            PindPatientInformation();
        }

    }
    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchInsurance(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        return objDALOpdReg.FillAllInsurance(prefixText);
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


                ViewState["PatientSubCategory"] = "0";
           
           
               // ddlPatientSubCategoryName1.Text = PatientInfo[1];
                ViewState["PatientSubCategory"] = InsuranceId[0];
                Session["LabPatientSubCategory"] = InsuranceId[0];
                ddlChargeSubCategory1.Text = "";
                txtcompdes.Text = "";
        }
        else
        {
            ViewState["InsuranceId"] = 0;
        }
    }
    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchChargeSubCategory(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        string PatientCategoryID = Convert.ToString(HttpContext.Current.Session["LabPatientSubCategory"]);
        return objDALOpdReg.FillAllSubChargeCategoryName(prefixText, PatientCategoryID);
    }
    protected void btnreport_Click(object sender, EventArgs e)
    {
        string sql = "";
        BLLReports objreports = new BLLReports();
        try
        {
            string Message = objDALOpdReg.GenerateChargeNumber(Convert.ToInt32(Request.QueryString["PatientInfoID"]), Convert.ToInt32(ViewState["InsuranceId"]), Convert.ToString(ViewState["PatientChargeSubCategory"]), txtcompdes.Text, Convert.ToString(Session["username"]));
            int BranchId = Convert.ToInt32(Session["BranchId"]);
            int FId = Convert.ToInt32(Session["FId"]);
            int Sponser = Convert.ToInt32(ViewState["InsuranceId"]);

            objreports.VW_GenerateChargeNumber(Convert.ToString(Request.QueryString["PatientInfoID"]));

            Session.Add("rptsql", sql);
            Session["rptname"] = Server.MapPath("~/Reports/Rpt_GenerateChargeNumber.rpt");
            Session["reportname"] = "GenerateChargeNumber";
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
    protected void ddlChargeSubCategory1_TextChanged(object sender, EventArgs e)
    {
        if (Convert.ToString(ddlChargeSubCategory1.Text) != "")
        {
            if (ddlChargeSubCategory1.Text.Split('-').Length < 2)
            {
               // hfPatientId.Value = "0";
                ViewState["PatientChargeSubCategory"] = "0";
            }
            else
            {
                string[] PatientInfo = ddlChargeSubCategory1.Text.Split('-');
                ddlChargeSubCategory1.Text = PatientInfo[1];
                ViewState["PatientChargeSubCategory"] = PatientInfo[0];


                DataTable dt = new DataTable();
                dt = objDALPatInfo.Get_ChildCompany_Description(Convert.ToInt32(ViewState["PatientChargeSubCategory"]));
                if (dt.Rows.Count > 0)
                {
                    txtcompdes.Text = Convert.ToString(dt.Rows[0]["CompanyDescription"]);
                }
                else
                {
                   txtcompdes.Text = "";
                }
            }
        }
        else
        {
            txtcompdes.Text = "";
            ddlChargeSubCategory1.Text = "";
        }
    }


    public void PindPatientInformation()
    {
        DataTable dt = new DataTable();
        dt = obj.Get_AllPatientInformation_ChargeNumber(Convert.ToString(Request.QueryString["PatientInfoID"]));
        try
        {
            if (dt != null)
            {
                lblPatientName.Text = Convert.ToString(dt.Rows[0]["PatientName"]);
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
    
}