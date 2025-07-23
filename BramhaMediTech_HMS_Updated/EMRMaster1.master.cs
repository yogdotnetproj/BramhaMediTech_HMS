using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EMRMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Menu menu = (Menu)FindControl("Treatement") as Menu;
        //menu.Items.Remove(menu.FindItem("frmTreatment2.aspx"));
       // menu.Items.Remove(menu.FindItem("Register.aspx"));
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
        //}
        //if (Convert.ToString(Session["FormType"]) == "OPDNurse")
        //{
        //    //Treatement.Visible = false;
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
        //}
    }
}
