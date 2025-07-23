
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

public partial class PatientReferalNoteCreate : System.Web.UI.Page
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
                string regId = Convert.ToString(Session["EmrRegNo"]);
                string name = Request.QueryString["Name"];
                string opd = Convert.ToString(Session["EmrOpdNo"]);
                string entrydate = Request.QueryString["EntryDate"];
                // Session["Branchid"] = "1";

                //lblPatientName.Text = name;
                //txtpatientregid.Text = regId;

                //lblOpd.Text = opd;
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
        string ipd =   Convert.ToString(Session["EmrIpdNo"]);
        string branchid = Convert.ToString( Session["Branchid"]);

        DataTable dt = new DataTable();
        try
        {
            dt = obj.GeFormatNote( branchid);
            ddlformatnote.DataSource = dt;
            ddlformatnote.DataTextField = "ReferalFormatName";
            ddlformatnote.DataValueField = "ForId";
            ddlformatnote.DataBind();
            ddlformatnote.Items.Insert(0, new ListItem("Select format", "0"));
            dt = new DataTable();

            dt = obj.GetReferal_Note(patientregid,ipd, branchid);
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
            if (Convert.ToString(Session["Branchid"]) == "")
            {
                Response.Redirect("~/Login.aspx", false);
                return;
            }
            if (Convert.ToString(Session["Branchid"]) == "0")
            {
                Response.Redirect("~/Login.aspx", false);
                return;
            }
            if (Convert.ToString(Session["Branchid"]) == null)
            {
                Response.Redirect("~/Login.aspx", false);
                return;
            }
            string regId = Convert.ToString(Session["EmrRegNo"]);
            string opd = Convert.ToString(Session["EmrOpdNo"]);
            string ipd =  Convert.ToString(Session["EmrIpdNo"]);
            string branch = Convert.ToString(Session["Branchid"]);
          //  string name = lblPatientName.Text.ToString();
            string entry = DateTime.Now.ToString("dd/MM/yyyy");
            if (Convert.ToString(Session["EmrIpdNo"]) != "0")
            {
                if (Convert.ToString(Session["PatAdmit"]) == "No")
                {
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = "Patient already discharge!";
                    return;
                }
            }
            string createdby = Convert.ToString(Session["username"]); ;
            string createdon = DateTime.Now.ToString("dd/MM/yyyy");
            string updatedby = Convert.ToString(Session["username"]); ;
            string updatedon = DateTime.Now.ToString("dd/MM/yyyy");
            obj.SaveEmr_ReferalNote(regId, ipd, Editor1.Text, createdby, branch, Convert.ToString(Session["FId"]));
                btnSave.Text = "Save";
                GetRecords();
                SuccessMessage("Format Save successfully!.");
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
    protected void ddlformatnote_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dtF = new DataTable();
        dtF = obj.SelectFormatNote(Convert.ToString(Session["Branchid"]),Convert.ToInt32( ddlformatnote.SelectedValue));
        if (dtF.Rows.Count > 0)
        {
            Editor1.Text =Convert.ToString( dtF.Rows[0]["ReferalFormat"]); 
        }

    }
}