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
using System.Media;
public partial class New_Opthalmology_Clinic :BasePage
{
    public enum MessageType { Success, Error, Info, Warning };
    Dental_Clinic_C ObjDC = new Dental_Clinic_C();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
           txtEntryDate.Text= DateTime.Now.ToString("dd/MM/yyyy");
            Get_All_Opthalmology_Data(Convert.ToInt32(Session["EmrRegNo"]));

            Get_Opthalmology_Clinic(Convert.ToInt32(Session["EmrOpdNo"]));
            GetRecords();
            BindImages();
        }
    }
    private DataTable GetRecords()
    {
        string patientregid = Convert.ToString(Session["EmrRegNo"]);
        string opd = Convert.ToString(Session["EmrOpdNo"]);
        string ipd = Convert.ToString(Session["EmrIpdNo"]);
        string branchid = Convert.ToString(Session["Branchid"]);

        DataTable dt = new DataTable();
        try
        {
            dt = ObjDC.GetGeneralEmrDetailsEdit(patientregid, opd, ipd, branchid);
            if (dt.Rows.Count > 0)
            {
                txtchiefComplaints.Text = Convert.ToString(dt.Rows[0]["chiefcomplaints"]);
                txtOcularHistory.Text = Convert.ToString(dt.Rows[0]["pasthistory"]);
                txtAllergys.Text = Convert.ToString(dt.Rows[0]["allergies"]);
            }
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    public void Get_All_Opthalmology_Data(int Patregid)
    {

        DataTable dt = new DataTable();

        using (SqlConnection con = DataAccess.ConInitForDC())
        {
            using (SqlCommand cmd = new SqlCommand("usp_GetAll_Opthalmology_Clinic_Details_New", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@PatRegId", Convert.ToInt32(Session["EmrRegNo"]));

                con.Open();

                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(dt);
                }

                con.Close();
                con.Dispose();
            }

            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();

            }


        }
    }
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
  
    protected void btnsave_Click(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["EmrOpdNo"]) != "")
        {
            ObjDC.P_OpdNo = Convert.ToInt32(Session["EmrOpdNo"]);
        }
        else
        {
            ObjDC.P_OpdNo = 0;
        }
        if (Convert.ToString(Session["EmrIpdNo"]) != "")
        {
            ObjDC.P_IpdNo = Convert.ToInt32(Session["EmrIpdNo"]);
        }
        else
        {
            ObjDC.P_IpdNo = 0;
        }
        ObjDC.P_Patregid = Convert.ToInt32(Session["EmrRegNo"]);
        ObjDC.P_CreatedBy = Convert.ToString(Session["username"]);
        ObjDC.P_Branchid = Convert.ToInt32(Session["Branchid"]);

       
//-------------------------------------------------------
        ObjDC.P_Allergies = txtAllergys.Text;
        ObjDC.P_OcularHistory = txtOcularHistory.Text;


        ObjDC.P_TreatmentHistory = txttreatmentHistory.Text;
        if (txtEntryDate.Text != "")
        {
            ObjDC.P_EntryDate = Convert.ToDateTime(txtEntryDate.Text);
        }
        ObjDC.P_DrName = txtdrname.Text;
        ObjDC.P_Diagnosis = txtDiagnosis.Text;
        ObjDC.P_ChiefComplaints = txtchiefComplaints.Text;
        ObjDC.P_PastHistory = txtOcularHistory.Text;
        ObjDC.P_ClinicalNote = txtClinicalNote.Text;
        ObjDC.P_CurrentMedication = txttreatmentHistory.Text;
        ObjDC.P_Allergies = txtAllergys.Text;

        ObjDC.P_UnaidedODD = txtUnaidedODD.Text;
        ObjDC.P_UnaidedOSD = txtUnaidedOSD.Text;
        ObjDC.P_UnaidedODN = txtUnaidedODN.Text;
        ObjDC.P_UnaidedOSN = txtUnaidedOSN.Text;
        ObjDC.P_PinholeOD = txtPinholeODD.Text;
        ObjDC.P_PinholeOS = txtPinholeOSD.Text;

        ObjDC.P_SpectaclesODD = txtSpectaclesODD.Text;
        ObjDC.P_SpectaclesOSD = txtSpectaclesOSD.Text;
        ObjDC.P_SpectaclesODN = txtSpectaclesODN.Text;
        ObjDC.P_SpectaclesOSN = txtSpectaclesOSN.Text;
        ObjDC.P_IOPOD = txtIOPODD.Text;
        ObjDC.P_IOPOS = txtIOPOSD.Text;
        ObjDC.P_NPC = txtNPC.Text;
        ObjDC.P_PachymetryOD = txtPachymetryODD.Text;
        ObjDC.P_PachymetryOS = txtPachymetryODS.Text;

        ObjDC.P_R1RMM = txtR1R.Text;
        ObjDC.P_R1RD = txtR1DR.Text;
        ObjDC.P_R1RDeg = txtR1DegR.Text;
        ObjDC.P_R1LMM = txtR1L.Text;
        ObjDC.P_R1LD = txtR1DL.Text;
        ObjDC.P_R1LDeg = txtR1DegL.Text;

        ObjDC.P_R2RMM = txtR2mmR.Text;
        ObjDC.P_R2RD = txtR2DR.Text;
        ObjDC.P_R2RDeg = txtR2DegR.Text;
        ObjDC.P_R2LMM = txtR2L.Text;
        ObjDC.P_R2LD = txtR2DL.Text;
        ObjDC.P_R2LDeg = txtR2DegL.Text;
        ObjDC.P_AVGRMM = txtAVGmmR.Text;
        ObjDC.P_AVGRD = txtAVGDR.Text;
        ObjDC.P_AVGRDeg = txtAVGDegR.Text;
        ObjDC.P_AVGLMM = txtAVGmmL.Text;
        ObjDC.P_AVGLD = txtAVGDL.Text;
        ObjDC.P_AVGLDeg = txtAVGDegL.Text;

        ObjDC.P_CYLRMM = txtCYLMMR.Text;
        ObjDC.P_CYLRD = txtCYLDR.Text;
        ObjDC.P_CYLRDeg = txtCYLDegR.Text;
        ObjDC.P_CYLLMM = txtCYLmmL.Text;
        ObjDC.P_CYLLD = txtCYLDL.Text;
        ObjDC.P_CYLLDeg = txtCYLDegL.Text;
        ObjDC.P_PD = txtPD.Text;
        ObjDC.P_Keratometry_N = txtN.Text;

        ObjDC.P_ColorOD = txtcolorOD.Text;
        ObjDC.P_ColorOS = txtcolorOS.Text;
        ObjDC.P_CoverTest = txtcoveruncover.Text;

        ObjDC.P_AxialOD = txtAxialLengthOD.Text;
        ObjDC.P_AxialOS = txtAxialLengthOS.Text;
        ObjDC.P_AConstantOD = txtAConstantOD.Text;
        ObjDC.P_AConstantOS = txtAConstantOS.Text;
        ObjDC.P_IOLOD = txtiolPowerOD.Text;
        ObjDC.P_IOLOS = txtiolPowerOS.Text;
        ObjDC.P_PredictiveOD = txtPredictiveOD.Text;
        ObjDC.P_PredictiveOS = txtPredictiveOS.Text;

        ObjDC.P_SPHCSPR = txtSPHRightCSP.Text;
        ObjDC.P_CYLCSPR = txtCYLRightCSP.Text;
        ObjDC.P_AXISCSPR = txtAXISRightCSP.Text;
        ObjDC.P_SPHCSPL = txtSPHLeftCSP.Text;
        ObjDC.P_CYLCSPL = txtCYLLeftCSP.Text;
        ObjDC.P_AXISCSPL = txtAXISLeftCSP.Text;
        ObjDC.P_ADDCSP = txtAddCSP.Text;

        ObjDC.P_SPHAutoR = txtSPHRightAuto.Text;
        ObjDC.P_CYLAutoR = txtCYLRightAuto.Text;
        ObjDC.P_AXISAutoR = txtAXISRightAuto.Text;
        ObjDC.P_SPHAutoL = txtSPHLeftAuto.Text;
        ObjDC.P_CYLAutoL = txtCYLLeftAuto.Text;
        ObjDC.P_AXISAutoL = txtAXISLeftAuto.Text;

        ObjDC.P_SPHMRR = txtSPHMRRight.Text;
        ObjDC.P_CYLMRR = txtCYLMRRight.Text;
        ObjDC.P_AXISMRR = txtAXISMRRight.Text;
        ObjDC.P_VAMRR = txtVAMRRight.Text;
        ObjDC.P_SPHMRL = txtSPHMRLeft.Text;
        ObjDC.P_CYLMRL = txtCYLMRLeft.Text;
        ObjDC.P_AXISMRL = txtAXISMRLeft.Text;
        ObjDC.P_VAMRL = txtVAMRLeft.Text;
        ObjDC.P_ADDMRL = txtAddMRLeft.Text;
        ObjDC.P_ODMRL = txtODMRLeft.Text;
        ObjDC.P_OSMRL = txtOSMRLeft.Text;

        ObjDC.P_SPHCRR = txtSPHCRDRight.Text;
        ObjDC.P_CYLCRR = txtCYLCRDRight.Text;
        ObjDC.P_AXISCRR = txtAXISCRDRight.Text;
        ObjDC.P_SPHCRL = txtSPHCRDLeft.Text;
        ObjDC.P_CYLCRL = txtCYLCRDLeft.Text;
        ObjDC.P_AXISCRL = txtAXISCRDLeft.Text;
        ObjDC.P_ADDCRL = txtADDCRDLeft.Text;
        ObjDC.P_MedicationUsedN = txtMedicationused.Text;
        ObjDC.P_Retinoscopy = txtRetinoscopy.Text;

        ObjDC.P_ADNEXAODR = txtADNEXARight.Text;
        ObjDC.P_ADNEXAODL = txtADNEXALeft.Text;
        ObjDC.P_ANTERIORODR = txtANTERIORSEGMENTRight.Text;
        ObjDC.P_ANTERIORODL = txtANTERIORSEGMENTLeft.Text;
        ObjDC.P_POSTERIORODR = txtPOSTERIORSegmentRight.Text;
        ObjDC.P_POSTERIORODL = txtPOSTERIORSegmentLeft.Text;
        ObjDC.P_MaculaDilated = rblPosterior.SelectedValue;

        ObjDC.P_DIAGNOSISOptha = txtOphthalmicDiagnosis.Text;
        ObjDC.P_MANAGEMENT = txtOphthalmicMANAGEMENT.Text;
        ObjDC.P_INVESTIGATIONS = txtOphthalmicINVESTIGATIONS.Text;
        ObjDC.P_PROCEDURESS = txtOphthalmicPROCEDURES.Text;

        ObjDC.Insert_New_Opthalmology_Clinic();

        Clears();








        //ObjDC.P_FamilyHistory = txtRp.Text;
        //if (ChkNil.Checked == true)
        //{
        //    ObjDC.P_NIL = true;
        //}
        //else
        //{
        //    ObjDC.P_NIL = false;
        //}
        //if (ChkDM.Checked == true)
        //{
        //    ObjDC.P_DM = true;
        //}
        //else
        //{
        //    ObjDC.P_DM = false;
        //}
        //if (ChkHTN.Checked == true)
        //{
        //    ObjDC.P_HTN = true;
        //}
        //else
        //{
        //    ObjDC.P_HTN = false;
        //}
        //if (ChkCad.Checked == true)
        //{
        //    ObjDC.P_CAD = true;
        //}
        //else
        //{
        //    ObjDC.P_CAD = false;
        //}
        //if (ChkThyroid.Checked == true)
        //{
        //    ObjDC.P_Thyroid = true;
        //}
        //else
        //{
        //    ObjDC.P_Thyroid = false;
        //}
        //if (ChkPregnancy.Checked == true)
        //{
        //    ObjDC.P_IS_Pregnancy = true;
        //}
        //else
        //{
        //    ObjDC.P_IS_Pregnancy = false;
        //}
        //if (ChkHIV.Checked == true)
        //{
        //    ObjDC.P_HIV = true;
        //}
        //else
        //{
        //    ObjDC.P_HIV = false;
        //}
        //if (ChkHBsAG.Checked == true)
        //{
        //    ObjDC.P_HBsAG = true;
        //}
        //else
        //{
        //    ObjDC.P_HBsAG = false;
        //}
        //if (ChkAsthamaa.Checked == true)
        //{
        //    ObjDC.P_Asthama = true;
        //}
        //else
        //{
        //    ObjDC.P_Asthama = false;
        //}
        //if (ChkHTNF.Checked == true)
        //{
        //    ObjDC.P_HTN_Family = true;
        //}
        //else
        //{
        //    ObjDC.P_HTN_Family = false;
        //}
        //if (ChkDMGlaucoma.Checked == true)
        //{
        //    ObjDC.P_DMGlaucoma = true;
        //}
        //else
        //{
        //    ObjDC.P_DMGlaucoma = false;
        //}
        //if (ChkCongCataract.Checked == true)
        //{
        //    ObjDC.P_CongCataract = true;
        //}
        //else
        //{
        //    ObjDC.P_CongCataract = false;
        //}
        //if (ChkRP.Checked == true)
        //{
        //    ObjDC.P_RP = true;
        //}
        //else
        //{
        //    ObjDC.P_RP = false;
        //}
        //if (ChkGlaucoma.Checked == true)
        //{
        //    ObjDC.P_Glaucoma = true;
        //}
        //else
        //{
        //    ObjDC.P_Glaucoma = false;
        //}
        //ObjDC.P_Dilated = RblDilated.SelectedValue;
        string fileName = "";
        if (FileUpload1.HasFile)
        {
             fileName = "~/Opthalmology/" + Convert.ToInt32(Session["EmrRegNo"]) + "-" + Convert.ToString(Session["EmrOpdNo"]) + "-" + Path.GetFileName(FileUpload1.PostedFile.FileName);
             FileUpload1.SaveAs(Server.MapPath("~/Opthalmology/" + Convert.ToInt32(Session["EmrRegNo"]) + "-" + Convert.ToString(Session["EmrOpdNo"]) + "-" + FileUpload1.FileName));
        }
        else
        {
        }
        ObjDC.P_DocumentFileName = fileName;
        ObjDC.P_DocumentFilePath = fileName;
        ObjDC.P_Diagnosis = txtDiagnosis.Text;
       // ObjDC.Insert_Opthalmology_Clinic();
        ShowMessage("Record save successfully", MessageType.Success);
        Get_All_Opthalmology_Data(Convert.ToInt32(Session["EmrRegNo"]));
    }
    protected void btnreport_Click(object sender, EventArgs e)
    {
        string sql = "";
        Alter_view();
        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Report/Rpt_Opthalmology_Clinic.rpt");
        Session["reportname"] = "Opthalmology_Clinic";
        Session["RPTFORMAT"] = "pdf";

        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);
    }
    public void Alter_view()
    {
        string sql = "";
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd1 = con.CreateCommand();

        string query = "ALTER VIEW [dbo].[VW_Opthalmology_Clinic] AS (SELECT        PatientInformation.MiddleName, PatientInformation.LastName, Gender.GenderName, PatientInformation.MobileNo, PatientInformation.PhoneNo, PatientInformation.PatientAddress, PatientInformation.Email, "+
                      "  PatientInformation.Age, PatientInformation.AgeType, PatientInformation.FirstName, New_Opthalmology_Clinic.Opthoid, New_Opthalmology_Clinic.Patregid, New_Opthalmology_Clinic.OpdNo, New_Opthalmology_Clinic.IpdNo, "+
                       " New_Opthalmology_Clinic.OpthaDate, New_Opthalmology_Clinic.DrName, New_Opthalmology_Clinic.Diagnosis, New_Opthalmology_Clinic.ChiefComplaints, New_Opthalmology_Clinic.PastHistory, "+
                       " New_Opthalmology_Clinic.ClinicalNote, New_Opthalmology_Clinic.CurrentMedication, New_Opthalmology_Clinic.Allergy, New_Opthalmology_Clinic.UnaidedODD, New_Opthalmology_Clinic.UnaidedOSD, "+
                       " New_Opthalmology_Clinic.UnaidedODN, New_Opthalmology_Clinic.UnaidedOSN, New_Opthalmology_Clinic.PinholeOD, New_Opthalmology_Clinic.PinholeOS, New_Opthalmology_Clinic.SpectaclesODD, "+
                       " New_Opthalmology_Clinic.SpectaclesOSD, New_Opthalmology_Clinic.SpectaclesODN, New_Opthalmology_Clinic.SpectaclesOSN, New_Opthalmology_Clinic.IOPOD, New_Opthalmology_Clinic.IOPOS, "+
                       " New_Opthalmology_Clinic.NPC, New_Opthalmology_Clinic.PachymetryOD, New_Opthalmology_Clinic.PachymetryOS, New_Opthalmology_Clinic.R1RMM, New_Opthalmology_Clinic.R1RD, New_Opthalmology_Clinic.R1RDeg, "+
                       " New_Opthalmology_Clinic.R1LMM, New_Opthalmology_Clinic.R1LD, New_Opthalmology_Clinic.R1LDeg, New_Opthalmology_Clinic.R2RMM, New_Opthalmology_Clinic.R2RD, New_Opthalmology_Clinic.R2RDeg, "+
                       " New_Opthalmology_Clinic.R2LMM, New_Opthalmology_Clinic.R2LD, New_Opthalmology_Clinic.R2LDeg, New_Opthalmology_Clinic.AVGRMM, New_Opthalmology_Clinic.AVGRD, New_Opthalmology_Clinic.AVGRDeg, "+
                       " New_Opthalmology_Clinic.AVGLMM, New_Opthalmology_Clinic.AVGLD, New_Opthalmology_Clinic.AVGLDeg, New_Opthalmology_Clinic.CYLRMM, New_Opthalmology_Clinic.CYLRD, New_Opthalmology_Clinic.CYLRDeg, "+
                       " New_Opthalmology_Clinic.CYLLMM, New_Opthalmology_Clinic.CYLLD, New_Opthalmology_Clinic.CYLLDeg, New_Opthalmology_Clinic.PD, New_Opthalmology_Clinic.Keratometry_N, New_Opthalmology_Clinic.ColorOD, "+
                       " New_Opthalmology_Clinic.ColorOS, New_Opthalmology_Clinic.CoverTest, New_Opthalmology_Clinic.AxialOD, New_Opthalmology_Clinic.AxialOS, New_Opthalmology_Clinic.AConstantOD, "+
                       " New_Opthalmology_Clinic.AConstantOS, New_Opthalmology_Clinic.IOLOD, New_Opthalmology_Clinic.IOLOS, New_Opthalmology_Clinic.PredictiveOD, New_Opthalmology_Clinic.PredictiveOS, "+
                       " New_Opthalmology_Clinic.SPHCSPR, New_Opthalmology_Clinic.CYLCSPR, New_Opthalmology_Clinic.AXISCSPR, New_Opthalmology_Clinic.SPHCSPL, New_Opthalmology_Clinic.CYLCSPL, "+
                       " New_Opthalmology_Clinic.AXISCSPL, New_Opthalmology_Clinic.ADDCSP, New_Opthalmology_Clinic.SPHAutoR, New_Opthalmology_Clinic.CYLAutoR, New_Opthalmology_Clinic.AXISAutoR, New_Opthalmology_Clinic.SPHAutoL, "+
                       " New_Opthalmology_Clinic.CYLAutoL, New_Opthalmology_Clinic.AXISAutoL, New_Opthalmology_Clinic.SPHMRR, New_Opthalmology_Clinic.CYLMRR, New_Opthalmology_Clinic.AXISMRR, New_Opthalmology_Clinic.VAMRR, "+
                       " New_Opthalmology_Clinic.SPHMRL, New_Opthalmology_Clinic.CYLMRL, New_Opthalmology_Clinic.AXISMRL, New_Opthalmology_Clinic.VAMRL, New_Opthalmology_Clinic.ADDMRL, New_Opthalmology_Clinic.ODMRL, "+
                       " New_Opthalmology_Clinic.OSMRL, New_Opthalmology_Clinic.SPHCRR, New_Opthalmology_Clinic.CYLCRR, New_Opthalmology_Clinic.AXISCRR, New_Opthalmology_Clinic.SPHCRL, New_Opthalmology_Clinic.CYLCRL, "+
                       " New_Opthalmology_Clinic.AXISCRL, New_Opthalmology_Clinic.ADDCRL, New_Opthalmology_Clinic.MedicationUsed, New_Opthalmology_Clinic.Retinoscopy, New_Opthalmology_Clinic.ADNEXAODR, "+
                       " New_Opthalmology_Clinic.ADNEXAODL, New_Opthalmology_Clinic.ANTERIORODR, New_Opthalmology_Clinic.ANTERIORODL, New_Opthalmology_Clinic.POSTERIORODR, New_Opthalmology_Clinic.POSTERIORODL, "+
                       " New_Opthalmology_Clinic.MaculaDilated, New_Opthalmology_Clinic.DIAGNOSISOptha, New_Opthalmology_Clinic.MANAGEMENT, New_Opthalmology_Clinic.INVESTIGATIONS, New_Opthalmology_Clinic.PROCEDURESS, "+
                       " New_Opthalmology_Clinic.CreatedBy, New_Opthalmology_Clinic.Branchid, New_Opthalmology_Clinic.CreatedOn "+
                       " FROM            New_Opthalmology_Clinic INNER JOIN "+
                       " PatientInformation ON New_Opthalmology_Clinic.Patregid = PatientInformation.PatRegId INNER JOIN "+
                       " Gender ON PatientInformation.GenderId = Gender.GenderId " +
        " where Opthalmology_Clinic.Patregid=" + Convert.ToInt32(Session["EmrRegNo"]) + "  and  Opthalmology_Clinic.OPDNo=" + Convert.ToInt32(Session["EmrOpdNo"]) + " and  Opthalmology_Clinic.IPDNO=" + Convert.ToInt32(Session["EmrIpdNo"]) + " ";
        //if (txtFrom.Value != "" && txtTo.Value != "")
        //{
        //    query += " and    DagnosisAssigtTpPatient.CreatedOn between ('" + Convert.ToDateTime(txtFrom.Value).ToString("MM/dd/yyyy") + "') and ('" + Convert.ToDateTime(txtTo.Value).AddDays(1).ToString("MM/dd/yyyy") + "')";
        //}



        cmd1.CommandText = query + ")";

        con.Open();
        cmd1.ExecuteNonQuery();
        con.Close(); con.Dispose();
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int OPDNo = Convert.ToInt32(GridView1.DataKeys[e.NewEditIndex]["OPDNo"]);
        ViewState["OPDNO"] = OPDNo;

         Get_Opthalmology_Clinic(OPDNo);
       // Get_Diagnostic_TReatment(1, OPDNo);
       // Get_TReatment_Details(1, OPDNo);
       // Get_IntraoralExamination(1, OPDNo);
        e.Cancel = true;
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    public void Get_Opthalmology_Clinic( int OPDNo)
    {

        DataTable dt = new DataTable();

        using (SqlConnection con = DataAccess.ConInitForDC())
        {
            using (SqlCommand cmd = new SqlCommand("usp_GetOpth_almology_Clinic_Details_New", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@PatRegId", Convert.ToInt32(Session["EmrRegNo"]));
                cmd.Parameters.AddWithValue("@OPDNO", Convert.ToInt32(OPDNo));
                con.Open();

                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(dt);
                }

                con.Close();
                con.Dispose();
            }

            if (dt.Rows.Count > 0)
            {
                txtAllergys.Text = Convert.ToString(dt.Rows[0]["Allergy"]); ;
                       // txtOcularHistory.Text = Convert.ToString(dt.Rows[0]["OcularHistory"]);
                        txtOcularHistory.Text = Convert.ToString(dt.Rows[0]["PastHistory"]);
                        txtchiefComplaints.Text = Convert.ToString(dt.Rows[0]["ChiefComplaints"]);
                        txttreatmentHistory.Text = Convert.ToString(dt.Rows[0]["CurrentMedication"]);
                //-------------------------------------------------------------

                         //txtAllergys.Text= Convert.ToString(dt.Rows[0]["Allergies"]);
                       // txtOcularHistory.Text= Convert.ToString(dt.Rows[0]["Allergies"]);


                       // txttreatmentHistory.Text = Convert.ToString(dt.Rows[0]["Allergies"]);
                        //if (txtEntryDate.Text != "")
                        //{
                        txtEntryDate.Text = Convert.ToString(dt.Rows[0]["OpthaDate"]);
                        //}
                        txtdrname.Text = Convert.ToString(dt.Rows[0]["DrName"]);
                        txtDiagnosis.Text = Convert.ToString(dt.Rows[0]["Diagnosis"]);
                        txtchiefComplaints.Text = Convert.ToString(dt.Rows[0]["ChiefComplaints"]);
                        txtOcularHistory.Text = Convert.ToString(dt.Rows[0]["PastHistory"]);
                        txtClinicalNote.Text = Convert.ToString(dt.Rows[0]["ClinicalNote"]);
                        txttreatmentHistory.Text = Convert.ToString(dt.Rows[0]["CurrentMedication"]);
                        txtAllergys.Text = Convert.ToString(dt.Rows[0]["Allergy"]);

                        txtUnaidedODD.Text = Convert.ToString(dt.Rows[0]["UnaidedODD"]);
                        txtUnaidedOSD.Text = Convert.ToString(dt.Rows[0]["UnaidedOSD"]);
                        txtUnaidedODN.Text = Convert.ToString(dt.Rows[0]["UnaidedODN"]);
                        txtUnaidedOSN.Text = Convert.ToString(dt.Rows[0]["UnaidedOSN"]);
                        txtPinholeODD.Text = Convert.ToString(dt.Rows[0]["PinholeOD"]);
                        txtPinholeOSD.Text = Convert.ToString(dt.Rows[0]["PinholeOS"]);

                        txtSpectaclesODD.Text = Convert.ToString(dt.Rows[0]["SpectaclesODD"]);
                        txtSpectaclesOSD.Text = Convert.ToString(dt.Rows[0]["SpectaclesOSD"]);
                        txtSpectaclesODN.Text = Convert.ToString(dt.Rows[0]["SpectaclesODN"]);
                        txtSpectaclesOSN.Text = Convert.ToString(dt.Rows[0]["SpectaclesOSN"]);
                        txtIOPODD.Text = Convert.ToString(dt.Rows[0]["IOPOD"]);
                        txtIOPOSD.Text = Convert.ToString(dt.Rows[0]["IOPOS"]);
                        txtNPC.Text = Convert.ToString(dt.Rows[0]["NPC"]);
                        txtPachymetryODD.Text = Convert.ToString(dt.Rows[0]["PachymetryOD"]);
                        txtPachymetryODS.Text = Convert.ToString(dt.Rows[0]["PachymetryOS"]);

                        txtR1R.Text = Convert.ToString(dt.Rows[0]["R1RMM"]);
                        txtR1DR.Text = Convert.ToString(dt.Rows[0]["R1RD"]);
                        txtR1DegR.Text = Convert.ToString(dt.Rows[0]["R1RDeg"]);
                        txtR1L.Text = Convert.ToString(dt.Rows[0]["R1LMM"]);
                        txtR1DL.Text = Convert.ToString(dt.Rows[0]["R1LD"]);
                        txtR1DegL.Text = Convert.ToString(dt.Rows[0]["R1LDeg"]);

                        txtR2mmR.Text = Convert.ToString(dt.Rows[0]["R2RMM"]);
                        txtR2DR.Text = Convert.ToString(dt.Rows[0]["R2RD"]);
                        txtR2DegR.Text = Convert.ToString(dt.Rows[0]["R2RDeg"]);
                        txtR2L.Text = Convert.ToString(dt.Rows[0]["R2LMM"]);
                        txtR2DL.Text = Convert.ToString(dt.Rows[0]["R2LD"]);
                        txtR2DegL.Text = Convert.ToString(dt.Rows[0]["R2LDeg"]);
                        txtAVGmmR.Text = Convert.ToString(dt.Rows[0]["AVGRMM"]);
                        txtAVGDR.Text = Convert.ToString(dt.Rows[0]["AVGRD"]);
                        txtAVGDegR.Text = Convert.ToString(dt.Rows[0]["AVGRDeg"]);
                        txtAVGmmL.Text = Convert.ToString(dt.Rows[0]["AVGLMM"]);
                        txtAVGDL.Text = Convert.ToString(dt.Rows[0]["AVGLD"]);
                        txtAVGDegL.Text = Convert.ToString(dt.Rows[0]["AVGLDeg"]);

                        txtCYLMMR.Text = Convert.ToString(dt.Rows[0]["CYLRMM"]);
                        txtCYLDR.Text = Convert.ToString(dt.Rows[0]["CYLRD"]);
                        txtCYLDegR.Text = Convert.ToString(dt.Rows[0]["CYLRDeg"]);
                        txtCYLmmL.Text = Convert.ToString(dt.Rows[0]["CYLLMM"]);
                        txtCYLDL.Text = Convert.ToString(dt.Rows[0]["CYLLD"]);
                        txtCYLDegL.Text = Convert.ToString(dt.Rows[0]["CYLLDeg"]);
                        txtPD.Text = Convert.ToString(dt.Rows[0]["PD"]);
                        txtN.Text = Convert.ToString(dt.Rows[0]["Keratometry_N"]);

                        txtcolorOD.Text = Convert.ToString(dt.Rows[0]["ColorOD"]);
                        txtcolorOS.Text = Convert.ToString(dt.Rows[0]["ColorOS"]);
                        txtcoveruncover.Text = Convert.ToString(dt.Rows[0]["CoverTest"]);

                        txtAxialLengthOD.Text = Convert.ToString(dt.Rows[0]["AxialOD"]);
                        txtAxialLengthOS.Text = Convert.ToString(dt.Rows[0]["AxialOS"]);
                        txtAConstantOD.Text = Convert.ToString(dt.Rows[0]["AConstantOD"]);
                        txtAConstantOS.Text = Convert.ToString(dt.Rows[0]["AConstantOS"]);
                        txtiolPowerOD.Text = Convert.ToString(dt.Rows[0]["IOLOD"]);
                        txtiolPowerOS.Text = Convert.ToString(dt.Rows[0]["IOLOS"]);
                        txtPredictiveOD.Text = Convert.ToString(dt.Rows[0]["PredictiveOD"]);
                        txtPredictiveOS.Text = Convert.ToString(dt.Rows[0]["PredictiveOS"]);

                        txtSPHRightCSP.Text = Convert.ToString(dt.Rows[0]["SPHCSPR"]);
                        txtCYLRightCSP.Text = Convert.ToString(dt.Rows[0]["CYLCSPR"]);
                        txtAXISRightCSP.Text = Convert.ToString(dt.Rows[0]["AXISCSPR"]);
                        txtSPHLeftCSP.Text = Convert.ToString(dt.Rows[0]["SPHCSPL"]);
                        txtCYLLeftCSP.Text = Convert.ToString(dt.Rows[0]["CYLCSPL"]);
                        txtAXISLeftCSP.Text = Convert.ToString(dt.Rows[0]["AXISCSPL"]);
                        txtAddCSP.Text = Convert.ToString(dt.Rows[0]["ADDCSP"]);

                        txtSPHRightAuto.Text = Convert.ToString(dt.Rows[0]["SPHAutoR"]);
                        txtCYLRightAuto.Text = Convert.ToString(dt.Rows[0]["CYLAutoR"]);
                        txtAXISRightAuto.Text = Convert.ToString(dt.Rows[0]["AXISAutoR"]);
                        txtSPHLeftAuto.Text = Convert.ToString(dt.Rows[0]["SPHAutoL"]);
                        txtCYLLeftAuto.Text = Convert.ToString(dt.Rows[0]["CYLAutoL"]);
                        txtAXISLeftAuto.Text = Convert.ToString(dt.Rows[0]["AXISAutoL"]);

                        txtSPHMRRight.Text = Convert.ToString(dt.Rows[0]["SPHMRR"]);
                        txtCYLMRRight.Text = Convert.ToString(dt.Rows[0]["CYLMRR"]);
                        txtAXISMRRight.Text = Convert.ToString(dt.Rows[0]["AXISMRR"]);
                        txtVAMRRight.Text = Convert.ToString(dt.Rows[0]["VAMRR"]);
                        txtSPHMRLeft.Text = Convert.ToString(dt.Rows[0]["SPHMRL"]);
                        txtCYLMRLeft.Text = Convert.ToString(dt.Rows[0]["CYLMRL"]);
                        txtAXISMRLeft.Text = Convert.ToString(dt.Rows[0]["AXISMRL"]);
                        txtVAMRLeft.Text = Convert.ToString(dt.Rows[0]["VAMRL"]);
                        txtAddMRLeft.Text = Convert.ToString(dt.Rows[0]["ADDMRL"]);
                        txtODMRLeft.Text = Convert.ToString(dt.Rows[0]["ODMRL"]);
                        txtOSMRLeft.Text = Convert.ToString(dt.Rows[0]["OSMRL"]);

                        txtSPHCRDRight.Text = Convert.ToString(dt.Rows[0]["SPHCRR"]);
                        txtCYLCRDRight.Text = Convert.ToString(dt.Rows[0]["CYLCRR"]);
                        txtAXISCRDRight.Text = Convert.ToString(dt.Rows[0]["AXISCRR"]);
                        txtSPHCRDLeft.Text = Convert.ToString(dt.Rows[0]["SPHCRL"]);
                        txtCYLCRDLeft.Text = Convert.ToString(dt.Rows[0]["CYLCRL"]);
                        txtAXISCRDLeft.Text = Convert.ToString(dt.Rows[0]["AXISCRL"]);
                        txtADDCRDLeft.Text = Convert.ToString(dt.Rows[0]["ADDCRL"]);
                        txtMedicationused.Text = Convert.ToString(dt.Rows[0]["MedicationUsed"]);
                        txtRetinoscopy.Text = Convert.ToString(dt.Rows[0]["Retinoscopy"]);

                        txtADNEXARight.Text = Convert.ToString(dt.Rows[0]["ADNEXAODR"]);
                        txtADNEXALeft.Text = Convert.ToString(dt.Rows[0]["ADNEXAODL"]);
                        txtANTERIORSEGMENTRight.Text = Convert.ToString(dt.Rows[0]["ANTERIORODR"]);
                        txtANTERIORSEGMENTLeft.Text = Convert.ToString(dt.Rows[0]["ANTERIORODL"]);
                        txtPOSTERIORSegmentRight.Text = Convert.ToString(dt.Rows[0]["POSTERIORODR"]);
                        txtPOSTERIORSegmentLeft.Text = Convert.ToString(dt.Rows[0]["POSTERIORODL"]);
                        rblPosterior.SelectedValue = Convert.ToString(dt.Rows[0]["MaculaDilated"]);

                        txtOphthalmicDiagnosis.Text = Convert.ToString(dt.Rows[0]["DIAGNOSISOptha"]);
                        txtOphthalmicMANAGEMENT.Text = Convert.ToString(dt.Rows[0]["MANAGEMENT"]);
                        txtOphthalmicINVESTIGATIONS.Text = Convert.ToString(dt.Rows[0]["INVESTIGATIONS"]);
                        txtOphthalmicPROCEDURES.Text = Convert.ToString(dt.Rows[0]["PROCEDURESS"]);

                //--------------------------------------------------------------
                        //txtRp.Text = Convert.ToString(dt.Rows[0]["FamilyHistory"]);
                        //if (Convert.ToBoolean(dt.Rows[0]["NIL"]) == true)
                        //{
                        //    ChkNil.Checked = true;
                        //}
                        //else
                        //{
                        //    ChkNil.Checked = false;
                        //}
                        //if (Convert.ToBoolean(dt.Rows[0]["DM"]) == true)
                        //{
                        //    ChkDM.Checked = true;
                        //}
                        //else
                        //{
                        //    ChkDM.Checked = false;
                        //}
                        //if (Convert.ToBoolean(dt.Rows[0]["HTN"]) == true)
                        //{
                        //    ChkHTN.Checked = true;
                        //}
                        //else
                        //{
                        //    ChkHTN.Checked = false;
                        //}
                        //if (Convert.ToBoolean(dt.Rows[0]["CAD"]) == true)
                        //{
                        //    ChkCad.Checked = true;
                        //}
                        //else
                        //{
                        //    ChkCad.Checked = false;
                        //}
                        //if (Convert.ToBoolean(dt.Rows[0]["Thyroid"]) == true)
                        //{
                        //    ChkThyroid.Checked = true;
                        //}
                        //else
                        //{
                        //    ChkThyroid.Checked = false;
                        //}
                        //if (Convert.ToBoolean(dt.Rows[0]["IS_Pregnancy"]) == true)
                        //{
                        //    ChkPregnancy.Checked = true;
                        //}
                        //else
                        //{
                        //    ChkPregnancy.Checked = false;
                        //}
                        //if (Convert.ToBoolean(dt.Rows[0]["HIV"]) == true)
                        //{
                        //    ChkHIV.Checked = true;
                        //}
                        //else
                        //{
                        //    ChkHIV.Checked = false;
                        //}
                        //if (Convert.ToBoolean(dt.Rows[0]["HBsAG"]) == true)
                        //{
                        //    ChkHBsAG.Checked = true;
                        //}
                        //else
                        //{
                        //    ChkHBsAG.Checked = false;
                        //}
                        //if (Convert.ToBoolean(dt.Rows[0]["Asthama"]) == true)
                        //{
                        //    ChkAsthamaa.Checked = true;
                        //}
                        //else
                        //{
                        //    ChkAsthamaa.Checked = false;
                        //}
                        //if (Convert.ToBoolean(dt.Rows[0]["HTN_Family"]) == true)
                        //{
                        //    ChkHTNF.Checked = true;
                        //}
                        //else
                        //{
                        //    ChkHTNF.Checked = false;
                        //}
                        //if (Convert.ToBoolean(dt.Rows[0]["DMGlaucoma"]) == true)
                        //{
                        //    ChkDMGlaucoma.Checked = true;
                        //}
                        //else
                        //{
                        //    ChkDMGlaucoma.Checked = false;
                        //}
                        //if (Convert.ToBoolean(dt.Rows[0]["CongCataract"]) == true)
                        //{
                        //    ChkCongCataract.Checked = true;
                        //}
                        //else
                        //{
                        //    ChkCongCataract.Checked = false;
                        //}
                        //if (Convert.ToBoolean(dt.Rows[0]["RP"]) == true)
                        //{
                        //    ChkRP.Checked = true;
                        //}
                        //else
                        //{
                        //    ChkRP.Checked = false;
                        //}
                        //if (Convert.ToBoolean(dt.Rows[0]["Glaucoma"]) == true)
                        //{
                        //    ChkGlaucoma.Checked = true;
                        //}
                        //else
                        //{
                        //    ChkGlaucoma.Checked = false;
                        //}
                        //RblDilated.SelectedValue = Convert.ToString( dt.Rows[0]["Glaucoma"]);
                        //Hyp_viewPres.NavigateUrl = Convert.ToString(dt.Rows[0]["DocumentFilePath"]);
                        //Hyp_viewPres.Text = "View File";
                        //txtDiagnosis.Text = Convert.ToString(dt.Rows[0]["Diagnosis"]);
            }


        }
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        if (Convert.ToString( Session["EmrRegNo"]) != "0")
        {

            if (FileUpload1.HasFile)
            {
                if (txtfileNAme.Text.Trim() != "")
                {
                    string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    filename = "UID" + Session["EmrRegNo"] + "-" + Session["EmrOpdNo"] + "-" + txtfileNAme.Text;
                    string filePath = "~/Opthalmology/" + filename;
                    FileUpload1.SaveAs(Server.MapPath(filePath));
                    SqlConnection conn = DataAccess.ConInitForDC();
                    conn.Open();


                    SqlCommand cmd = new SqlCommand("Insert into OPthoPatientFiles(PatRegId,OPDNO,FileName,Path,CreatedBy,Branchid) values(@PatRegId,@OPDNO,@FileName,@Path,@CreatedBy,@Branchid)", conn);
                    cmd.Parameters.AddWithValue("@Path", filePath);
                    cmd.Parameters.AddWithValue("@PatRegId", Convert.ToInt32(Session["EmrRegNo"]));
                    cmd.Parameters.AddWithValue("@filename", txtfileNAme.Text.Trim());
                    cmd.Parameters.AddWithValue("@OPDNO", Session["EmrOpdNo"]);
                    cmd.Parameters.AddWithValue("@CreatedBy", Convert.ToString(Session["username"]));
                    cmd.Parameters.AddWithValue("@Branchid", Convert.ToString(Session["Branchid"]));
                    //    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    conn.Dispose();
                    BindImages();
                    txtfileNAme.Text = "";
                    //}  
                    // }
                }
                else
                {
                    txtfileNAme.Focus();
                    ShowMessage("Enter File Name", MessageType.Warning);
                    lblMsg.Text = "Enter File Name!";
                   // return;
                }
            }
            else
            {
                ShowMessage("select File", MessageType.Warning);
                lblMsg.Text = "select File!";
                // lblMessage.Text = "Please Select File";
                // return;
            }
        }
       
    }
    private void RegisterPostBackControl()
    {
        foreach (GridViewRow row in gvImages.Rows)
        {
            LinkButton lnkbtn = row.FindControl("lnkDownload") as LinkButton;
            ScriptManager.GetCurrent(this).RegisterPostBackControl(lnkbtn);


        }
    }
    protected void lnkDownload_Click(object sender, EventArgs e)
    {
        LinkButton lnkbtn = sender as LinkButton;
        GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;
        // this.RegisterPostBackControl();
        string filePath = gvImages.DataKeys[gvrow.RowIndex].Value.ToString();
        Response.ContentType = "image/jpg";
        Response.AddHeader("Content-Disposition", "attachment;filename=\"" + filePath + "\"");
        Response.TransmitFile(Server.MapPath(filePath));
        Response.End();
    }
    public void BindImages()
    {
        SqlConnection conn = DataAccess.ConInitForDC();
        conn.Open();

        using (SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM OPthoPatientFiles where PatRegId=" + Convert.ToInt32(Session["EmrRegNo"]), conn))
        {
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                UploadedFiles.Visible = true;
                gvImages.DataSource = dt;
                gvImages.DataBind();
            }
            else
            {
                UploadedFiles.Visible = false;

            }

        }
        conn.Close();
        conn.Dispose();

    }
    protected void gvImages_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int FileId = Convert.ToInt32(gvImages.DataKeys[e.RowIndex]["OPFileId"]);

        SqlConnection conn = DataAccess.ConInitForDC();
        conn.Open();


        SqlCommand cmd = new SqlCommand("Delete  OPthoPatientFiles where OPFileId=@OPFileId ", conn);
        cmd.Parameters.AddWithValue("@OPFileId", FileId);
        // cmd.Parameters.AddWithValue("@PatRegId", Convert.ToInt32(ViewState["PatientInfoId"]));
        /// cmd.Parameters.AddWithValue("@filename", filename);

        cmd.ExecuteNonQuery();
        conn.Close();
        conn.Dispose();
        // BindImages();

        //  string Message = objDALOpdReg.DeleteBillGroup(Convert.ToInt32(BillGroupId));

        // DynamicMessage(lblMessage, Message);

        BindImages();
        lblMsg.Text = "File delete successfulle!";
        ShowMessage("File delete successfulle!", MessageType.Error);
    }
    public void Clears()
    {
        txtAConstantOD.Text = "";
        txtAConstantOS.Text = "";
        txtADDCRDLeft.Text = "";
        txtAddCSP.Text = "";
        txtAddMRLeft.Text = "";
        txtADNEXALeft.Text = "";
        txtADNEXARight.Text = "";
        txtAllergys.Text = "";
        txtANTERIORSEGMENTLeft.Text = "";
        txtANTERIORSEGMENTRight.Text = "";
        txtAVGDegL.Text = "";
        txtAVGDegR.Text = "";
        txtAVGDL.Text = "";
        txtAVGDR.Text = "";
        txtAVGmmL.Text = "";
        txtAVGmmR.Text = "";
        txtAVGmmR.Text = "";
        txtAxialLengthOD.Text = "";
        txtAxialLengthOS.Text = "";
        txtAXISCRDLeft.Text = "";
        txtAXISCRDRight.Text = "";
        txtAXISLeftAuto.Text = "";
        txtAXISLeftCSP.Text = "";
        txtAXISMRLeft.Text = "";
        txtAXISMRRight.Text = "";
        txtAXISRightAuto.Text = "";
        txtAXISRightCSP.Text = "";
        txtchiefComplaints.Text = "";
        txtClinicalNote.Text = "";
        txtcolorOD.Text = "";
        txtcolorOS.Text = "";
        txtcoveruncover.Text = "";
        txtCYLCRDLeft.Text = "";
        txtCYLCRDRight.Text = "";
        txtCYLDegL.Text = "";
        txtCYLDegR.Text = "";
        txtCYLDL.Text = "";
        txtCYLDR.Text = "";
        txtCYLLeftAuto.Text = ""; txtCYLLeftCSP.Text = "";
        txtCYLmmL.Text = "";
        txtCYLMMR.Text = "";
        txtCYLMRLeft.Text = "";
        txtCYLMRRight.Text = "";
        txtCYLRightAuto.Text = "";
        txtCYLRightCSP.Text = "";
        txtDiagnosis.Text = "";
        txtdrname.Text = "";
        txtiolPowerOD.Text = "";
        txtiolPowerOS.Text = "";
        txtIOPODD.Text = "";
        txtIOPOSD.Text = "";
        txtMedicationused.Text = "";
        txtN.Text = "";
        txtNPC.Text = "";
        txtOcularHistory.Text = "";
        txtODMRLeft.Text = "";
        txtOphthalmicDiagnosis.Text = "";
        txtOphthalmicINVESTIGATIONS.Text = "";
        txtOphthalmicMANAGEMENT.Text = "";
        txtOphthalmicPROCEDURES.Text = "";
        txtOSMRLeft.Text = "";
        txtPachymetryODD.Text = "";
        txtPachymetryODS.Text = "";
        txtPD.Text = "";
        txtPinholeODD.Text = "";
        txtPinholeOSD.Text = "";
        txtPOSTERIORSegmentLeft.Text = "";
        txtPOSTERIORSegmentRight.Text = "";
        txtPredictiveOD.Text = "";
        txtPredictiveOS.Text = "";
        txtR1DegL.Text = "";
        txtR1DegR.Text = "";
        txtR1DL.Text = "";
        txtR1DR.Text = "";
        txtR1L.Text = "";
        txtR1R.Text = "";
        txtR2DegL.Text = "";
        txtR2DegR.Text = "";
        txtR2DL.Text = "";
        txtR2DR.Text = "";
        txtR2L.Text = "";
        txtR2mmR.Text = "";
        txtRetinoscopy.Text = "";
        txtSpectaclesODD.Text = "";
        txtSpectaclesODD.Text = "";
        txtSpectaclesODN.Text = "";
        txtSpectaclesOSD.Text = "";
        txtSpectaclesOSN.Text = "";
        txtSPHCRDLeft.Text = "";
        txtSPHCRDRight.Text = "";
        txtSPHLeftAuto.Text = "";
        txtSPHLeftCSP.Text = "";
        txtSPHMRLeft.Text = "";
        txtSPHMRRight.Text = "";
        txtSPHRightAuto.Text = "";
        txtSPHRightCSP.Text = "";
        txttreatmentHistory.Text = "";
        txtUnaidedODD.Text = "";
        txtUnaidedODN.Text = "";
        txtUnaidedOSD.Text = "";
        txtUnaidedOSN.Text = "";
        txtVAMRLeft.Text = "";
        txtVAMRRight.Text = "";
    }
}