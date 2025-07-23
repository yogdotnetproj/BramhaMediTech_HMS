using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class TemplateMaster : System.Web.UI.MasterPage
{
    clsEmr obj = new clsEmr();
    BELOPDPatReg objBELIpd = new BELOPDPatReg();
    DALIPDDesk ObjDALIpd = new DALIPDDesk();
    protected void Page_Load(object sender, EventArgs e)
    {
        //Menu menu = (Menu)FindControl("Treatement") as Menu;
        //menu.Items.Remove(menu.FindItem("frmTreatment2.aspx"));
       // menu.Items.Remove(menu.FindItem("Register.aspx"));
        if (!this.IsPostBack)
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
            PindPatientInformation();
           
        }
        //if (Convert.ToString(Session["FormType"]) == "IPDNurse")
        //{
        //       Treatement.Visible = false;
        //       Procedure.Visible = false;
        //        SurQuotes.Visible = false;
        //        Diagnosis.Visible = false;
        //        Postpartum.Visible = false;
        //        GeneralEMR.Visible = false;

        //        IntakeOutputSheet.Visible = true;
        //        DailyNurseNotes.Visible = true;
        //        DailyDoctorNotes.Visible = true;
        //        IVFluidChart.Visible = true;
        //        IPDPatientTreatmentSheet.Visible = true;
        //        DiabeticPatientSheet.Visible = true;
        //        BloodTransfusion.Visible = true;
        //        NurseRequestToPharmacy.Visible = true;
        //        Dailydrnote.Visible = true;
        //        IpdDsum.Visible = true;
        //        PatientHistoryForm.Visible = true;
        //        PhysicalExamination.Visible = true;
        //        OnAdmissionSheet.Visible = true;
        //        MedicalLab.Visible = true;
        //        PathoLab.Visible = true;
        //        RadoLab.Visible = true;
        //        CardLab.Visible = true;
        //        OtNote.Visible = true;
        //        vaccination.Visible = false;

        //        BrestLumpform.Visible = false;
        //        FamilyPlan.Visible = false;
        //        ANC.Visible = false;
        //        HIVEncounter.Visible = false;
        //        DeliveryNote.Visible = true;
        //        BirthRegister.Visible = true;
        //        vitalSigns.Visible = true;
        //        DischargeMedication.Visible = true;
        //        NurseDrugOrder.Visible = true;
        //        Session["EmrDash"] = "";
        //}
        //if (Convert.ToString(Session["FormType"]) == "OPDNurse")
        //{
        //    //Treatement.Visible = false;
        //    Treatement.Visible = true;
        //    IPDEMRDashboard.Visible = false;
        //    Procedure.Visible = true;
        //    SurQuotes.Visible = true;
        //    Diagnosis.Visible = true;
        //    Postpartum.Visible = true;
        //    GeneralEMR.Visible = true;

        //    IntakeOutputSheet.Visible = false;
        //    DailyNurseNotes.Visible = false;
        //    DailyDoctorNotes.Visible = false;
        //    IVFluidChart.Visible = false;
        //    IPDPatientTreatmentSheet.Visible = false;
        //    DiabeticPatientSheet.Visible = false;
        //    BloodTransfusion.Visible = false;
        //    NurseRequestToPharmacy.Visible = false;
        //    Dailydrnote.Visible = false;
        //    IpdDsum.Visible = false;
        //    PatientHistoryForm.Visible = false;
        //    PhysicalExamination.Visible = false;
        //    OnAdmissionSheet.Visible = false;

        //    MedicalLab.Visible = true;
        //    PathoLab.Visible = true;
        //    RadoLab.Visible = true;
        //    CardLab.Visible = true;
        //    OtNote.Visible = true;
        //    vaccination.Visible = true;

        //    //BrestLumpform.Visible = true;
        //    //FamilyPlan.Visible = true;
        //    //ANC.Visible = true;
        //    //HIVEncounter.Visible = true;
        //    DeliveryNote.Visible = false;
        //    BirthRegister.Visible = false;
        //    vitalSigns.Visible = false;
        //    DischargeMedication.Visible = false;
        //    NurseDrugOrder.Visible = false;

        //    GenGyno.Visible=true;
        //    UI.Visible=true;
        //    IVF.Visible=true;
        //    OXA.Visible=true;
        //    Col.Visible=true;
        //    VFer.Visible=true;
        //    INfer.Visible=true;
        //    EFin.Visible=true;
        //    Ant.Visible = true;
        //    Session["EmrDash"] = "";
        //}

        //if (Convert.ToString(Session["EmrDash"]) == "NurseOrder")
        //{
        //    IPDEMRDashboard.Visible = true;
        //    NurseDrugOrder.Visible = true;
        //}
        //if (Convert.ToString(Session["EmrDash"]) == "OTNote")
        //{
        //    IPDEMRDashboard.Visible = true;
        //    OtNote.Visible = true;
        //}
        //if (Convert.ToString(Session["EmrDash"]) == "DiscSummary")
        //{
        //    IPDEMRDashboard.Visible = true;
        //    IpdDsum.Visible = true;
        //}
        //if (Convert.ToString(Session["EmrDash"]) == "InvReport")
        //{
        //    IPDEMRDashboard.Visible = true;
        //    MedicalLab.Visible = true;
        //    PathoLab.Visible = true;
        //    RadoLab.Visible = true;
        //    CardLab.Visible = true;
        //}
        //if (Convert.ToString(Session["EmrDash"]) == "DrNote")
        //{
        //    IPDEMRDashboard.Visible = true;
        //    DailyDoctorNotes.Visible = true;
        //}
        //if (Convert.ToString(Session["EmrDash"]) == "InOutSheet")
        //{
        //    IPDEMRDashboard.Visible = true;
        //    IntakeOutputSheet.Visible = true;
        //}
        //if (Convert.ToString(Session["EmrDash"]) == "NurseNote")
        //{
        //    IPDEMRDashboard.Visible = true;
        //    DailyNurseNotes.Visible = true;
        //}

        //if (Convert.ToString(Session["EmrDash"]) == "AdmSheet")
        //{
        //    IPDEMRDashboard.Visible = true;
        //    PhysicalExamination.Visible = true;
        //    PatientHistoryForm.Visible = true;
        //    AdmissionSheet.Visible = true;
        //    OnAdmissionSheet.Visible = true;
        //}
        //if (Convert.ToString(Session["EmrDash"]) == "Ordersheet")
        //{
        //    IPDEMRDashboard.Visible = true;
        //    Treatement.Visible = true;
        //    PostopTreat.Visible = true;
          
        //}
        //if (Convert.ToString(Session["EmrDash"]) == "MAR")
        //{
        //    IPDEMRDashboard.Visible = true;
        //    IPDPatientTreatmentSheet.Visible = true;

        //}
        //if (Convert.ToString(Session["EmrDash"]) == "Vital")
        //{
        //    IPDEMRDashboard.Visible = true;
        //    vitalSigns.Visible = true;

        //}
        //if (Convert.ToString(Session["EmrDash"]) == "DiscMedi")
        //{
        //    IPDEMRDashboard.Visible = true;

        //    DischargeMedication.Visible = true;
        //    //Treatement.Visible = true;

        //}

        //if (Convert.ToString(Session["EmrDash"]) == "DrDocNote")
        //{
        //    IPDEMRDashboard.Visible = true;
        //    Dailydrnote.Visible = true;

        //}
        
        
        
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
                    Div8.Visible=false;
                    Div7.Visible=true;
                    lblIpd.Text = Convert.ToString(dt.Rows[0]["IpdNo"]);
                    IpdRmCat.Visible = true;
                    
                    FillIpdPatInfo(Convert.ToInt32(Session["EmrRegNo"]), Convert.ToInt32(Session["EmrIpdNo"]));
                }
                else
                {
                    Div8.Visible = true;
                    Div7.Visible = false;
                    lblOpd.Text = Convert.ToString(dt.Rows[0]["OpdNo"]);
                    IpdRmCat.Visible = false ;
                   
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
       // lblPatientName.Text = Convert.ToString(objBELIpd.PatientName);
        lblAdmissionDate.Text = Convert.ToString(objBELIpd.EntryDate);
        lblIpd.Text = Convert.ToString(objBELIpd.IpdNo);
        //lblPatRegId.Text = Convert.ToString(objBELIpd.PatRegId);
        //lblBillNo.Text = Convert.ToString(BillNo);//BillNo

        lblRoomName.Text = Convert.ToString(objBELIpd.RoomName);
        lbldrname.Text = Convert.ToString(objBELIpd.DRName);
       // LblRoomType.Text = Convert.ToString(objBELIpd.RType);
        lblBedName.Text = Convert.ToString(objBELIpd.BedName);

        lblKin.Text = Convert.ToString(objBELIpd.ContactPerson1);
        lblConct.Text = Convert.ToString(objBELIpd.Contact1);
        lblRelation.Text = Convert.ToString(objBELIpd.RelationName);

       
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
