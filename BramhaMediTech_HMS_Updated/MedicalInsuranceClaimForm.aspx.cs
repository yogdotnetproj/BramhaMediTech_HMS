using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MedicalInsuranceClaimForm :BasePage
{
    clsEmr obj = new clsEmr();
    clsTreatment objTreat = new clsTreatment();
    clsTreatmentTransaction transaction = new clsTreatmentTransaction();
    DataTable tempDatatable = new DataTable();
    BLLPatientCategory objBLLPatientCategory = new BLLPatientCategory();
    DOPatientCategory objDOPatientCategory = new DOPatientCategory();

    DALPostpartumExamination ObjDALPPE = new DALPostpartumExamination();
    BELPostpartumExamination ObjBELPPE = new BELPostpartumExamination();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if (Session["EmrRegNo"] != "")
            {
                string regId = Convert.ToString(Session["EmrRegNo"]);
                string name = Request.QueryString["Name"];
                string opd = Convert.ToString(Session["EmrOpdNo"]);
                string entrydate = Request.QueryString["EntryDate"];
                Session["Branchid"] = "1";
               // lblOpd.Text = opd;
                PindPatientInformation();
                BindPE();
            }
        }
    }
    public void PindPatientInformation()
    {
        DataTable dt = new DataTable();
        dt = obj.Get_AllPatientInformation_MedicalClaim(Convert.ToString(Session["EmrRegNo"]), Convert.ToString(Session["EmrOpdNo"]), Convert.ToInt32(Session["EmrIpdNo"]), Convert.ToInt32(Session["Branchid"]));
        try
        {
            if (dt != null)
            {
                txtpatientname.Text = Convert.ToString(dt.Rows[0]["PatientName"]);
                txtHospitalID.Text = Convert.ToString(dt.Rows[0]["PatRegId"]);
                //lblIpd.Text = Convert.ToString(dt.Rows[0]["Ipdno"]);
                //lblOpd.Text = Convert.ToString(dt.Rows[0]["PatRegId"]);
                //lblMobileNo.Text = Convert.ToString(dt.Rows[0]["MobileNo"]);
                txtnameofdr.Text = Convert.ToString(dt.Rows[0]["DrName"]);
                txtageofpatient.Text = Convert.ToString(dt.Rows[0]["Age"]) + " " + Convert.ToString(dt.Rows[0]["AgeType"]) + "/" + Convert.ToString(dt.Rows[0]["GenderName"]);
                ViewState["Age"] = Convert.ToString(dt.Rows[0]["Age"]);
                ViewState["AgeType"] = Convert.ToString(dt.Rows[0]["AgeType"]);
                txtCertificate.Text = Convert.ToString(dt.Rows[0]["LetterNo"]);
                txtInsuranceCompany.Text = Convert.ToString(dt.Rows[0]["PatientInsuType"]);
                ViewState["InsuranceCompId"] = Convert.ToString(dt.Rows[0]["PatientSubType"]);
                ViewState["DrId"] = Convert.ToString(dt.Rows[0]["DrId"]);
                txtDiagnosisofDoctor.Text = Convert.ToString(dt.Rows[0]["Diagnosis"]);
                txtConsultationdate.Text = Convert.ToDateTime(dt.Rows[0]["Entrydate"]).ToString("dd/MM/yyyy");
                
            }
            //dt = new DataTable();
            //dt = obj.Get_AllPatientVitalTaken(Convert.ToString(Session["EmrRegNo"]), Convert.ToString(Session["EmrOpdNo"]), Convert.ToInt32(Session["EmrIpdNo"]), Convert.ToInt32(Session["Branchid"]));
            //if (dt.Rows.Count > 0)
            //{
            //    lblvtaken.Text = Convert.ToString(dt.Rows[0]["CreatedOn"]);
            //}
        }
        catch (Exception ex)
        {

        }
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        
        if (txtConsultationdate.Text == "")
        {
            txtConsultationdate.Focus();
            txtConsultationdate.BorderColor = System.Drawing.Color.Red;
            return;
        }
        if (Convert.ToString(Session["EmrOpdNo"]) != "")
        {
            ObjDALPPE.OpdNo = Convert.ToInt32(Session["EmrOpdNo"]);
        }
        else
        {
            ObjDALPPE.OpdNo = 0;
        }
        if (Convert.ToString(Session["EmrIpdNo"]) != "")
        {
            ObjDALPPE.IpdNo = Convert.ToInt32(Session["EmrIpdNo"]);
        }
        else
        {
            ObjDALPPE.IpdNo = 0;
        }
        ObjDALPPE.Patregid = Convert.ToString(Session["EmrRegNo"]);
        ObjDALPPE.CreatedBy = Convert.ToString(Session["username"]);
        ObjDALPPE.UpdatedBy = Convert.ToString(Session["username"]);
        ObjDALPPE.FId = Convert.ToInt32(Session["FId"]); ;
        ObjDALPPE.BranchId = Convert.ToInt32(Session["Branchid"]);

        ObjDALPPE.InsuranceCompName = Convert.ToInt32( ViewState["InsuranceCompId"]);
        ObjDALPPE.DateofConsultant = Convert.ToDateTime(txtConsultationdate.Text);
        ObjDALPPE.NameofEmployer = txtnameofemployer.Text;
        ObjDALPPE.NameofEmployee = txtEmployeeName.Text;
        ObjDALPPE.CertificateNo = txtCertificate.Text;
        ObjDALPPE.Age = txtageofpatient.Text;
        ObjDALPPE.RelationshipPatToEmployee = txtrelationofPatients.Text;
        ObjDALPPE.Accidentoccur = txtSymptoms.Text;
        ObjDALPPE.Injuryorsickness = txtinjury.Text;
        ObjDALPPE.Illnessorcondition = txtnatureofillness.Text;
        ObjDALPPE.patientcovered = txtispatintCovered.Text;
        ObjDALPPE.Duetopregnancy = txtPregnancycondition.Text;
        ObjDALPPE.Similarondition = txtsimilarCondition.Text;
        ObjDALPPE.DiagnosisofDoctor = txtDiagnosisofDoctor.Text;
        ObjDALPPE.TestPrescribed = txttestPrescribed.Text;
        ObjDALPPE.MedicationPrescribed = txtMedicationPrescribed.Text;

        ObjBELPPE.Insert_MedicalInsuranceClaim(ObjDALPPE);
        lblmsg.Text = "Record save successfully.!";
        lblmsg.ForeColor = System.Drawing.Color.Green;
        txtageofpatient.Text = "";
        txtCertificate.Text = "";
        txtConsultationdate.Text = "";
        txtDiagnosisofDoctor.Text = "";
        txtEmployeeName.Text = ""; 
        txtHospitalID.Text = "";
        txtIdOfPatients.Text = "";
        txtinjury.Text = "";
        txtInsuranceCompany.Text = "";
        txtispatintCovered.Text = "";
        txtMedicationPrescribed.Text = "";
        txtnameofdr.Text = "";
        txtnameofemployer.Text = "";
        txtnatureofillness.Text = "";
        txtpatientname.Text = "";
        txtPregnancycondition.Text = "";
        txtrelationofPatients.Text = "";
        txtsignature.Text = "";
        txtsignatureofdoctor.Text = "";
        txtsimilarCondition.Text = "";
        txtSymptoms.Text = "";
        txttestPrescribed.Text = "";
        

        BindPE();
    }
    private void BindPE()
    {
        if (Convert.ToString(Session["EmrOpdNo"]) != "")
        {
            ObjDALPPE.OpdNo = Convert.ToInt32(Session["EmrOpdNo"]);
        }
        else
        {
            ObjDALPPE.OpdNo = 0;
        }
        if (Convert.ToString(Session["EmrIpdNo"]) != "")
        {
            ObjDALPPE.IpdNo = Convert.ToInt32(Session["EmrIpdNo"]);
        }
        else
        {
            ObjDALPPE.IpdNo = 0;
        }
        ObjDALPPE.Patregid = Convert.ToString(Session["EmrRegNo"]);
        ObjDALPPE.CreatedBy = Convert.ToString(Session["username"]);
        ObjDALPPE.UpdatedBy = Convert.ToString(Session["username"]);
        ObjDALPPE.FId = Convert.ToInt32(Session["FId"]); ;
        ObjDALPPE.BranchId = Convert.ToInt32(Session["Branchid"]);
        
    }
   
    public void Clear()
    {
       


    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        string sql = "";
        if (Convert.ToString(Session["EmrOpdNo"]) != "")
        {
            ObjDALPPE.OpdNo = Convert.ToInt32(Session["EmrOpdNo"]);
        }
        else
        {
            ObjDALPPE.OpdNo = 0;
        }
        if (Convert.ToString(Session["EmrIpdNo"]) != "")
        {
            ObjDALPPE.IpdNo = Convert.ToInt32(Session["EmrIpdNo"]);
        }
        else
        {
            ObjDALPPE.IpdNo = 0;
        }
        ObjDALPPE.Patregid = Convert.ToString(Session["EmrRegNo"]);
       // objDALIO.Alter_Vw_Theatre_CheckList(ObjDALPPE);
        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Report/Rpt_MedicalInsuranceClaim.rpt");
        Session["reportname"] = "MedicalInsuranceClaim";
        Session["RPTFORMAT"] = "pdf";

        //ReportParameterClass.SelectionFormula = sql;
        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);
    }
}