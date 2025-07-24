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

public partial class IPDEMRDashboard : BasePage
{
    clsEmr obj = new clsEmr();
    DALIPDDesk ObjDALIpd = new DALIPDDesk();
    BELOPDPatReg objBELIpd = new BELOPDPatReg();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if (Session["EmrRegNo"] != "")
            {
                PindPatientInformation();
                string regId = Convert.ToString(Session["EmrRegNo"]);
                string name = Request.QueryString["Name"];
                string opd = Convert.ToString(Session["EmrOpdNo"]);
                string entrydate = Request.QueryString["EntryDate"];
                string IpdId = Convert.ToString(Session["EmrIpdNo"]);
                // Session["Branchid"] = "1";

                lblPatientName.Text = name;
                //txtpatientregid.Text = regId;
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
                //lblOpd.Text = opd;
                FillIpdPatInfo(Convert.ToInt32( regId), Convert.ToInt32( IpdId));
                //PindPatientInformation();
               // GetRecords();
                if (Convert.ToString(Session["usertype"]) == "Nurse Aide")
                {
                    btnAdmisionSheet.Enabled = false;
                    btnvital.Enabled = true;
                    btnintakeoutput.Enabled = false;
                    btninvestigation.Enabled = false;
                    btnordersheet.Enabled = false;
                    byndrnote.Enabled = false;
                    btnmar.Enabled = false;
                    btnnursenote.Enabled = true;
                    btnsurgeryform.Enabled = false;
                    btndrnote.Enabled = false;
                    btndischargemedication.Enabled = false;
                    btndischargesummary.Enabled = false;
                    btnopdvisitrecord.Enabled = false;
                    btnNurseOrder.Enabled = false;
                    btnIpdFile.Enabled = false;
                    btnNICUChart.Enabled = false;
                    btnIPDVisitrecord.Enabled = false;
                    btnMaternity.Enabled = false;
                    btnPostCharges.Enabled = false;
                }
                else
                {
                    btnAdmisionSheet.Enabled=true;
                    btnvital.Enabled=true;
                    btnintakeoutput.Enabled=true;
                    btninvestigation.Enabled=true;
                    btnordersheet.Enabled=true;
                    byndrnote.Enabled=true;
                    btnmar.Enabled=true;
                    btnnursenote.Enabled=true;
                    btnsurgeryform.Enabled=true;
                    btndrnote.Enabled=true;
                    btndischargemedication.Enabled=true;
                    btndischargesummary.Enabled=true;
                    btnopdvisitrecord.Enabled=true;
                    btnNurseOrder.Enabled=true;
                    btnIpdFile.Enabled=true;
                    btnNICUChart.Enabled=true;
                    btnIPDVisitrecord.Enabled=true;
                    btnMaternity.Enabled=true;
                    btnPostCharges.Enabled = true;
                }
                if (Convert.ToString(Session["usertype"]) == "Nurse")
                {
                    opV1.Visible = false;
                    opV.Visible = false;
                }
                if (Convert.ToInt32(Session["EmrOpdNo"]) > 0)
                {
                    Session["EmrOpdNo"] = 0;
                    Response.Redirect(string.Format("IPDListPatients.aspx"),false);
                }
            }
            else
            {
                Response.Redirect(string.Format("IPDListPatients.aspx"));
            }

        }
    }
    public void PindPatientInformation()
    {
        DataTable dt = new DataTable();
        dt = obj.Get_AllPatientInformation(Convert.ToString(Session["EmrRegNo"]), Convert.ToString(Session["EmrOpdNo"]), Convert.ToInt32(Session["EmrIpdNo"]), Convert.ToInt32(Session["Branchid"]));
        try
        {
            if (dt != null)
            {
                lblPatientName.Text = Convert.ToString(dt.Rows[0]["PatientName"]);
                txtpatientregid.Text = Convert.ToString(dt.Rows[0]["PatRegId"]);
                // lblIpd.Text = "0";
                //lblOpd.Text = Convert.ToString(dt.Rows[0]["PatRegId"]);
                if (Convert.ToString(Session["EmrOpdNo"]) == "0")
                {
                    Div8.Visible = false;
                    Div7.Visible = true;
                    lblIpd.Text = Convert.ToString(dt.Rows[0]["IpdNo"]);
                    IpdRmCat.Visible = true;

                    FillIpdPatInfo(Convert.ToInt32(Session["EmrRegNo"]), Convert.ToInt32(Session["EmrIpdNo"]));
                }
                else
                {
                    Div8.Visible = true;
                    Div7.Visible = false;
                    lblOpd.Text = Convert.ToString(dt.Rows[0]["OpdNo"]);
                    IpdRmCat.Visible = false;

                }

                lblMobileNo.Text = Convert.ToString(dt.Rows[0]["MobileNo"]);
                lbldrname.Text = Convert.ToString(dt.Rows[0]["DrName"]);
                string Birthdate = Convert.ToString(dt.Rows[0]["BirthDate"]);
                Birthdate = DateTime.Parse(Birthdate).ToString("dd/MM/yyyy");
                getAge(Birthdate);
                //lblAge.Text = Convert.ToString(dt.Rows[0]["Age"]) + "" + Convert.ToString(dt.Rows[0]["AgeType"]) + "/" + Convert.ToString(dt.Rows[0]["GenderName"]);
                lblAge.Text = lblAge.Text + "/" + Convert.ToString(dt.Rows[0]["GenderName"]);
                lblVisitingNo.Text = Convert.ToString(dt.Rows[0]["VisitingNo"]);
                lblToken.Text = Convert.ToString(dt.Rows[0]["TokenNo"]);
                lblDept.Text = Convert.ToString(dt.Rows[0]["DeptName"]);
                ViewState["DrId"] = Convert.ToInt32(dt.Rows[0]["DrId"]);
                lblAddress.Text = Convert.ToString(dt.Rows[0]["PatientAddress"]);
                Label6.Text = Birthdate;
                if (Convert.ToString(dt.Rows[0]["VaccinationStatus"]) != "")
                {
                    lblVaccinationStatus.Text = "Vaccination Status:-" + Convert.ToString(dt.Rows[0]["VaccinationStatus"]);
                }
                else
                {
                }

            }
        }
        catch (Exception ex)
        {

        }
    }
    public void FillIpdPatInfo(int RegId, int IpdId)
    {
        objBELIpd.IpdId = IpdId;
        objBELIpd.PatRegId = RegId;
        objBELIpd.FId = Convert.ToInt32(Session["FId"]);
        objBELIpd.BranchId = Convert.ToInt32(Session["Branchid"]);
        objBELIpd = ObjDALIpd.GetIpdPatientInformation(objBELIpd);
        lblPatCat.Text = Convert.ToString(objBELIpd.PatMainType);
        lblPatientName.Text = Convert.ToString(objBELIpd.PatientName);
        lblAdmissionDate.Text = Convert.ToString(objBELIpd.EntryDate) + " - " + Convert.ToString(objBELIpd.EntryTime); ;
        lblIpd.Text = Convert.ToString(objBELIpd.IpdNo);
       // lblPatRegId.Text = Convert.ToString(objBELIpd.PatRegId);
       // lblBillNo.Text = Convert.ToString(objBELIpd.FullDeptName);//BillNo

        lblRoomName.Text = Convert.ToString(objBELIpd.RoomName);
        lbldrname.Text = Convert.ToString(objBELIpd.DRName);
       // LblRoomType.Text = Convert.ToString(objBELIpd.RType);
        lblBedName.Text = Convert.ToString(objBELIpd.BedName);

        //Label2.Text = Convert.ToString(objBELIpd.Diagnosis);
        //Label4.Text = Convert.ToString(objBELIpd.ProcedureName);
        //Label6.Text = Convert.ToString(objBELIpd.PatientInsuType);
        //Label8.Text = Convert.ToString(objBELIpd.Sponsor2);
        //lblvisitno.Text = Convert.ToString(objBELIpd.VisitingNo);
    }
    //public void PindPatientInformation()
    //{
    //    DataTable dt = new DataTable();
    //    dt = obj.Get_AllPatientInformation(Convert.ToString(Session["EmrRegNo"]), Convert.ToString(Session["EmrOpdNo"]), Convert.ToInt32(Session["EmrIpdNo"]), Convert.ToInt32(Session["Branchid"]));
    //    try
    //    {
    //        if (dt != null)
    //        {
    //            lblPatientName.Text = Convert.ToString(dt.Rows[0]["PatientName"]);
    //            txtpatientregid.Text = Convert.ToString(dt.Rows[0]["PatRegId"]);
    //            // lblIpd.Text = "0";
    //            //lblOpd.Text = Convert.ToString(dt.Rows[0]["PatRegId"]);
    //            lblOpd.Text = Convert.ToString(dt.Rows[0]["OpdNo"]);
    //            lblMobileNo.Text = Convert.ToString(dt.Rows[0]["MobileNo"]);
    //            lbldrname.Text = Convert.ToString(dt.Rows[0]["DrName"]);
    //            string Birthdate = Convert.ToString(dt.Rows[0]["BirthDate"]);
    //            Birthdate = DateTime.Parse(Birthdate).ToString("dd/MM/yyyy");
    //            getAge(Birthdate);
    //            //lblAge.Text = Convert.ToString(dt.Rows[0]["Age"]) + "" + Convert.ToString(dt.Rows[0]["AgeType"]) + "/" + Convert.ToString(dt.Rows[0]["GenderName"]);
    //            lblAge.Text = lblAge.Text + "/" + Convert.ToString(dt.Rows[0]["GenderName"]);
    //            lblVisitingNo.Text = Convert.ToString(dt.Rows[0]["VisitingNo"]);
    //            lblToken.Text = Convert.ToString(dt.Rows[0]["TokenNo"]);
    //            lblDept.Text = Convert.ToString(dt.Rows[0]["DeptName"]);
    //            ViewState["DrId"] = Convert.ToInt32(dt.Rows[0]["DrId"]);
    //            lblAddress.Text = Convert.ToString(dt.Rows[0]["PatientAddress"]);

    //        }
    //    }
    //    catch (Exception ex)
    //    {

    //    }
    //}
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
    //        lblAge.Text = intYear.ToString() + " Years";
    //        //ddlAge.SelectedIndex = 0;
    //    }
    //    else if (intMonth > 0)
    //    {
    //        lblAge.Text = intMonth.ToString() + " Months";
    //        //ddlAge.SelectedIndex = 1;
    //    }
    //    else if (intDays > 0)
    //    {
    //        lblAge.Text = intDays.ToString() + " Days";
    //        // ddlAge.SelectedIndex = 2;
    //    }
    //}
    protected void btnAdmisionSheet_Click(object sender, ImageClickEventArgs e)
    {
        if (Convert.ToInt32(Session["EmrOpdNo"]) > 0)
        {
            Session["EmrOpdNo"] = 0;
            Server.Transfer(string.Format("IPDListPatients.aspx"), false);
        }
        string EmrDash = "AdmSheet";
        Session["EmrDash"] = "AdmSheet";
        //Ipd Disk Report
        //2 Id Report
        //3 Physical examination
        //4 Patient History
        Response.Redirect("IPD_AdmissionSheet.aspx?EmrDash=" + EmrDash, false);
    }
    protected void btnvital_Click(object sender, ImageClickEventArgs e)
    {
        if (Convert.ToInt32(Session["EmrOpdNo"]) > 0)
        {
            Session["EmrOpdNo"] = 0;
            Server.Transfer(string.Format("IPDListPatients.aspx"), false);
        }
        string EmrDash = "Vital";
        Session["EmrDash"] = "Vital";
        Response.Redirect("VitalSheet.aspx?EmrDash=" + EmrDash, false);
    }
    protected void btnintakeoutput_Click(object sender, ImageClickEventArgs e)
    {
        if (Convert.ToInt32(Session["EmrOpdNo"]) > 0)
        {
            Session["EmrOpdNo"] = 0;
            Server.Transfer(string.Format("IPDListPatients.aspx"), false);
        }
        string EmrDash = "Intake";
        Session["EmrDash"] = "InOutSheet";
        Response.Redirect("IntakeOutputSheet.aspx?EmrDash=" + EmrDash, false);

    }
    protected void btninvestigation_Click(object sender, ImageClickEventArgs e)
    {
        if (Convert.ToInt32(Session["EmrOpdNo"]) > 0)
        {
            Session["EmrOpdNo"] = 0;
            Server.Transfer(string.Format("IPDListPatients.aspx"), false);
        }
        string EmrDash = "InvReport";
        Session["EmrDash"] = "InvReport";
        Response.Redirect("EMR_LabPatientRegistration.aspx?EmrDash=" + EmrDash, false);
    }
    protected void btnordersheet_Click(object sender, ImageClickEventArgs e)
    {
        if (Convert.ToInt32(Session["EmrOpdNo"]) > 0)
        {
            Session["EmrOpdNo"] = 0;
            Server.Transfer(string.Format("IPDListPatients.aspx"), false);
        }
        string EmrDash = "Ordersheet";
        Session["EmrDash"] = "Ordersheet";
        Response.Redirect("frmTreatment2.aspx?EmrDash=" + EmrDash, false);
    }
    protected void byndrnote_Click(object sender, ImageClickEventArgs e)
    {
        if (Convert.ToInt32(Session["EmrOpdNo"]) > 0)
        {
            Session["EmrOpdNo"] = 0;
            Server.Transfer(string.Format("IPDListPatients.aspx"), false);
        }
        string EmrDash = "DrNote";
        Session["EmrDash"] = "DrNote";
        Response.Redirect("PatientReferalNoteCreate.aspx?EmrDash=" + EmrDash, false);
    }
    protected void btnmar_Click(object sender, ImageClickEventArgs e)
    {
        if (Convert.ToInt32(Session["EmrOpdNo"]) > 0)
        {
            Session["EmrOpdNo"] = 0;
            Server.Transfer(string.Format("IPDListPatients.aspx"), false);
        }
        string EmrDash = "MAR";
        Session["EmrDash"] = "MAR";
        Response.Redirect("IPDPatientTreatmentSheet.aspx?EmrDash=" + EmrDash, false);
        
    }
    protected void btnnursenote_Click(object sender, ImageClickEventArgs e)
    {
        if (Convert.ToInt32(Session["EmrOpdNo"]) > 0)
        {
            Session["EmrOpdNo"] = 0;
            Server.Transfer(string.Format("IPDListPatients.aspx"), false);
        }
        string EmrDash = "NurseNote";
        Session["EmrDash"] = "NurseNote";
        Response.Redirect("DailyNurseNotes.aspx?EmrDash=" + EmrDash, false);
    }
    protected void btnsurgeryform_Click(object sender, ImageClickEventArgs e)
    {
        if (Convert.ToInt32(Session["EmrOpdNo"]) > 0)
        {
            Session["EmrOpdNo"] = 0;
            Server.Transfer(string.Format("IPDListPatients.aspx"), false);
        }
        string EmrDash = "OTNote";
        Session["EmrDash"] = "OTNote";
        Response.Redirect("OTNotesReport.aspx?EmrDash=" + EmrDash, false);
    }
    protected void btndrnote_Click(object sender, ImageClickEventArgs e)
    {
        if (Convert.ToInt32(Session["EmrOpdNo"]) > 0)
        {
            Session["EmrOpdNo"] = 0;
            Server.Transfer(string.Format("IPDListPatients.aspx"), false);
        }
        string EmrDash = "DrDocNote";
        Session["EmrDash"] = "DrDocNote";
        Response.Redirect("DailyDrNote.aspx?EmrDash=" + EmrDash, false);
    }
    protected void btndischargemedication_Click(object sender, ImageClickEventArgs e)
    {
        if (Convert.ToInt32(Session["EmrOpdNo"]) > 0)
        {
            Session["EmrOpdNo"] = 0;
            Server.Transfer(string.Format("IPDListPatients.aspx"), false);
        }
        string EmrDash = "DiscMedi";
        Session["EmrDash"] = "DiscMedi";
       // Response.Redirect("IPDPatientTreatmentSheet.aspx?EmrDash=" + EmrDash, false);
        Response.Redirect("DischargeMedication.aspx?EmrDash=" + EmrDash, false);
    }
    protected void btndischargesummary_Click(object sender, ImageClickEventArgs e)
    {
        if (Convert.ToInt32(Session["EmrOpdNo"]) > 0)
        {
            Session["EmrOpdNo"] = 0;
            Server.Transfer(string.Format("IPDListPatients.aspx"), false);
        }
        string EmrDash = "DiscSummary";
        Session["EmrDash"] = "DiscSummary";
        Response.Redirect("IpdDischargeSummary.aspx?EmrDash=" + EmrDash, false);
    }
    protected void btnopdvisitrecord_Click(object sender, ImageClickEventArgs e)
    {
        //int rowIndex = Convert.ToInt32(e.CommandArgument);

        ////Reference the GridView Row.
        //GridViewRow row = gvPatientInfo.Rows[rowIndex];

        //string regId = gvPatientInfo.Rows[rowIndex].Cells[1].Text;

        //string opd = gvPatientInfo.Rows[rowIndex].Cells[2].Text;

        //string name = gvPatientInfo.Rows[rowIndex].Cells[3].Text.Trim();

        //string entryDate = gvPatientInfo.Rows[rowIndex].Cells[4].Text;


        DataTable dt = new DataTable();
        dt = obj.Get_AllPatientOPD_Inform(Convert.ToString(Session["EmrRegNo"]), Convert.ToInt32(Session["Branchid"]));
        try
        {
            if (dt != null)
            {

                Session["EmrRegNo"] = Convert.ToString(Session["EmrRegNo"]);
                Session["EmrOpdNo"] = dt.Rows[0]["OpdNo"];
                Session["EmrIpdNo"] = 0;
                Session["FormType"] = "OPDNurse";
                // string response = @"~/frmTreatment2.aspx?RegId=" + regId + "&OpdNo=" + opd + "&Name=" + name + "&EntryDate=" + entryDate;
                string response = @"~/GeneralEmr2.aspx?RegId=" + Convert.ToString(Session["EmrRegNo"]) + "&OpdNo=" + dt.Rows[0]["OpdNo"] + "&IpdNo=" + dt.Rows[0]["IpdNo"] + "&Name=" + dt.Rows[0]["PatientName"] + "&EntryDate=" + dt.Rows[0]["EntryDate"];

                Response.Redirect(string.Format(response));
            }
        }
        catch (Exception ex)
        {

        }


    }
    protected void btnNurseOrder_Click(object sender, ImageClickEventArgs e)
    {
        if (Convert.ToInt32(Session["EmrOpdNo"]) > 0)
        {
            Session["EmrOpdNo"] = 0;
            Server.Transfer(string.Format("IPDListPatients.aspx"), false);
        }
        string EmrDash = "NurseOrder";
        Session["EmrDash"] = "NurseOrder";
        Response.Redirect("NurseReqToPharmacyPatient.aspx?EmrDash=" + EmrDash, false);
    }
    protected void btnIpdFile_Click(object sender, ImageClickEventArgs e)
    {
        if (Convert.ToInt32(Session["EmrOpdNo"]) > 0)
        {
            Session["EmrOpdNo"] = 0;
            Server.Transfer(string.Format("IPDListPatients.aspx"), false);
        }
        string EmrDash = "Dialysis";
        Session["EmrDash"] = "Dialysis";
        Response.Redirect("Dialysis.aspx?EmrDash=" + EmrDash, false);
    }
    protected void btnNICUChart_Click(object sender, ImageClickEventArgs e)
    {
        if (Convert.ToInt32(Session["EmrOpdNo"]) > 0)
        {
            Session["EmrOpdNo"] = 0;
            Server.Transfer(string.Format("IPDListPatients.aspx"), false);
        }
        string EmrDash = "NICUChart";
        Session["EmrDash"] = "NICUChart";
        Response.Redirect("NICU_MonitorChart.aspx?EmrDash=" + EmrDash, false);
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
    protected void btnIPDVisitrecord_Click(object sender, ImageClickEventArgs e)
    {
        if (Convert.ToInt32(Session["EmrOpdNo"]) > 0)
        {
            Session["EmrOpdNo"] = 0;
            Server.Transfer(string.Format("IPDListPatients.aspx"), false);
        }
        string EmrDash = "ShowVisitRecord";
        Session["EmrDash"] = "ShowVisitRecord";
        Response.Redirect("ShowVisitRecord.aspx?EmrDash=" + EmrDash, false);
    }
    protected void btnMaternity_Click(object sender, ImageClickEventArgs e)
    {
        if (Convert.ToInt32(Session["EmrOpdNo"]) > 0)
        {
            Session["EmrOpdNo"] = 0;
            Server.Transfer(string.Format("IPDListPatients.aspx"), false);
        }
        string EmrDash = "Maternity";
        Session["EmrDash"] = "Maternity";
        Response.Redirect("MaternalPatientInfo.aspx?EmrDash=" + EmrDash, false);
    }
    protected void btnPostCharges_Click(object sender, ImageClickEventArgs e)
    {
        if (Convert.ToInt32(Session["EmrOpdNo"]) > 0)
        {
            Session["EmrOpdNo"] = 0;
            Server.Transfer(string.Format("IPDListPatients.aspx"), false);
        }
        string EmrDash = "NursePostCharges";
        Session["EmrDash"] = "NursePostCharges";
        Response.Redirect("Nurse_PostCharges.aspx?EmrDash=" + EmrDash, false);
    }
}