
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

public partial class DailyDrNote_1 :BasePage
{
    clsEmr obj = new clsEmr();

    DataTable dt1 = new DataTable();
    DataTable dt2 = new DataTable();
    DataTable dt3 = new DataTable();

    DataTable dtChief = new DataTable();
    DataTable dtVitals = new DataTable();
    DataTable dtAllergies = new DataTable();
    DataTable dtMedical = new DataTable();
    DataTable dtSurgery = new DataTable();
    DataTable dtPastHis = new DataTable();
    DataTable dtPersHisl = new DataTable();
    DataTable dtFamHis = new DataTable();
    DataTable dtNote = new DataTable();
    DataTable dtDiagno = new DataTable();
    DataTable dtProvDiagno = new DataTable();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if (Session["EmrRegNo"]!="" )
            {
                string regId = Convert.ToString( Session["EmrRegNo"]);
                string name = Request.QueryString["Name"];
                string opd =  Convert.ToString( Session["EmrOpdNo"]);
                string entrydate = Request.QueryString["EntryDate"];
               // Session["Branchid"] = "1";

                //lblPatientName.Text = name;
               // txtpatientregid.Text = regId;
              
               // lblOpd.Text = opd;
                if (Convert.ToString(Session["usertype"]) == "Doctor")
                {
                    btnSave.Enabled = true;
                }
                PindPatientInformation();
                GetRecords();
               
            }
            else
            {
                Response.Redirect(string.Format("IPDListPatients.aspx"));
            }
            
        }
    }
   
   
   
    public void PindPatientInformation()
    {
        //DataTable dt = new DataTable();
        //dt = obj.Get_AllPatientInformation(Convert.ToString(Session["EmrRegNo"]), Convert.ToString(Session["EmrOpdNo"]),Convert.ToInt32( Session["EmrIpdNo"]), Convert.ToInt32(Session["Branchid"]));
        //try
        //{
        //    if (dt != null)
        //    {
        //        lblPatientName.Text = Convert.ToString(dt.Rows[0]["PatientName"]);
        //        txtpatientregid.Text = Convert.ToString( dt.Rows[0]["PatRegId"]);
        //       // lblIpd.Text = "0";
        //        //lblOpd.Text = Convert.ToString(dt.Rows[0]["PatRegId"]);
        //        lblOpd.Text = Convert.ToString(dt.Rows[0]["OpdNo"]);
        //        lblMobileNo.Text = Convert.ToString(dt.Rows[0]["MobileNo"]);
        //        lbldrname.Text = Convert.ToString(dt.Rows[0]["DrName"]);
        //        string Birthdate = Convert.ToString(dt.Rows[0]["BirthDate"]);
        //        Birthdate = DateTime.Parse(Birthdate).ToString("dd/MM/yyyy");
        //        getAge(Birthdate);
        //        //lblAge.Text = Convert.ToString(dt.Rows[0]["Age"]) + "" + Convert.ToString(dt.Rows[0]["AgeType"]) + "/" + Convert.ToString(dt.Rows[0]["GenderName"]);
        //        lblAge.Text =lblAge.Text +"/" + Convert.ToString(dt.Rows[0]["GenderName"]);
        //        lblVisitingNo.Text = Convert.ToString(dt.Rows[0]["VisitingNo"]);
        //        lblToken.Text = Convert.ToString(dt.Rows[0]["TokenNo"]);
        //        lblDept.Text = Convert.ToString(dt.Rows[0]["DeptName"]);
        //        ViewState["DrId"] = Convert.ToInt32(dt.Rows[0]["DrId"]);
        //        lblAddress.Text = Convert.ToString(dt.Rows[0]["PatientAddress"]);
                
        //    }
        //}
        //catch (Exception ex)
        //{

        //}
    }
    //public void getAge(string Birthdate)
    //{
    //    int intYear, intMonth, intDays;
    //    DateTime Birthday = Convert.ToDateTime(Birthdate);
    //    intYear = Birthday.Year;
    //    intMonth = Birthday.Month;
    //    intDays = Birthday.Day;

    //    DateTime dtt = Convert.ToDateTime(Birthdate);

    //    DateTime td = DateTime.Now;
    //    int Leap_Year = 0;
    //    for (int i = dtt.Year; i < td.Year; i++)
    //    {
    //        if (DateTime.IsLeapYear(i))
    //        {
    //            ++Leap_Year;
    //        }
    //    }
    //    TimeSpan timespan = td.Subtract(Birthday);
    //    intDays = timespan.Days - Leap_Year;
    //    int intResult = 0;
    //    intYear = Math.DivRem(intDays, 365, out intResult);
    //    intMonth = Math.DivRem(intResult, 30, out intResult);
    //    intDays = intResult;
    //    if (intYear > 0)//&& intDays > 0
    //    {
    //        lblAge.Text = intYear.ToString() +" Years";
    //        //ddlAge.SelectedIndex = 0;
    //    }
    //    else if (intMonth > 0)
    //    {
    //        lblAge.Text = intMonth.ToString() + " Months";
    //        //ddlAge.SelectedIndex = 1;
    //    }
    //    else if (intDays > 0)
    //    {
    //        lblAge.Text = intDays.ToString()+ " Days";
    //       // ddlAge.SelectedIndex = 2;
    //    }
    //}
    private void GetRadios()
    {
        try
        {
            DataSet ds = obj.ReadDataHistoryList();

            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    dt1 = ds.Tables[0];
                    dt2 = ds.Tables[1];
                    dt3 = ds.Tables[2];
                }
            }
        }
        catch (Exception)
        {
        }
    }

  
    private DataTable GetRecords()
    {
        string patientregid = Convert.ToString(Session["EmrRegNo"]);
        string opd = Convert.ToString(Session["EmrOpdNo"]);
        string ipd = Convert.ToString(Session["EmrIpdNo"]);
        string regId = Convert.ToString(Session["EmrRegNo"]);
        string name = Request.QueryString["Name"];
       // string opd = Convert.ToString(Session["EmrIpdNo"]);
        string branchid = Convert.ToString( Session["Branchid"]);
        string Usertype = Convert.ToString(Session["usertype"]);
        string createdby = Convert.ToString(Session["Name"]).Trim();
        DataTable dt = new DataTable();
        try
        {
            dt = obj.GetDailyDrNote(patientregid, ipd, branchid, Usertype, createdby.Trim());
            GvNoteIngrid.DataSource = dt;
            GvNoteIngrid.DataBind();
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

   
    private void ErrorMessage(string msg)
    {
        lblMsg.Text = msg; lblMsg.Visible = true; lblMsg.ForeColor = System.Drawing.Color.Red;
    }

    private void SuccessMessage(string msg)
    {
        lblMsg.Text = msg; lblMsg.Visible = true; lblMsg.ForeColor = System.Drawing.Color.Green;
    }
   

    

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            //string regId = txtpatientregid.Text.ToString();
            //string opd = !string.IsNullOrEmpty(lblOpd.Text.ToString()) ? lblOpd.Text.ToString() : "0";
            //string ipd = !string.IsNullOrEmpty(lblIpd.Text.ToString()) ? lblIpd.Text.ToString() : "0";

            string regId = Convert.ToString(Session["EmrRegNo"]);
            string opd = Convert.ToString(Session["EmrOpdNo"]);
            string ipd = Convert.ToString(Session["EmrIpdNo"]);

            string branch = Convert.ToString(Session["Branchid"]);
            string name = "";
            string entry =  DateTime.Now.ToString("dd/MM/yyyy");

            string createdby = Convert.ToString(Session["Name"]); ;
            string createdon = DateTime.Now.ToString("dd/MM/yyyy");
            string updatedby = Convert.ToString(Session["username"]); ;
            string updatedon = DateTime.Now.ToString("dd/MM/yyyy");
            obj.SaveEmr_DailyDrNote_555(regId,ipd,Editor1.Text,createdby,branch, Convert.ToString( Session["FId"]) );
                btnSave.Text = "Save";
                GetRecords();
                SuccessMessage("Dr Note Save successfully!.");
                ClearFields();
        }
        catch (Exception ex)
        {
            ErrorMessage(ex.Message);
        }
    }

    private void ClearFields()
    {
        Editor1.Text = "";
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        ClearFields();
    }

    protected void GvNoteIngrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GetRecords();
    }
}