using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FamilyPlanningForm : System.Web.UI.Page
{
    clsEmr obj = new clsEmr();
    clsTreatment objTreat = new clsTreatment();
    clsTreatmentTransaction transaction = new clsTreatmentTransaction();
    DataTable tempDatatable = new DataTable();
    BLLPatientCategory objBLLPatientCategory = new BLLPatientCategory();
    DOPatientCategory objDOPatientCategory = new DOPatientCategory();

    DALFamilyPlanningExam ObjDALFPE = new DALFamilyPlanningExam();
    BELFamilyPlanningExam ObjBELFPE = new BELFamilyPlanningExam();
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
                BindFPF();
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
                //lblPatientName.Text = Convert.ToString(dt.Rows[0]["PatientName"]);
                //txtpatientregid.Text = Convert.ToString(dt.Rows[0]["PatRegId"]);
                //lblIpd.Text = Convert.ToString(dt.Rows[0]["Ipdno"]);
                //lblOpd.Text = Convert.ToString(dt.Rows[0]["PatRegId"]);
                //lblMobileNo.Text = Convert.ToString(dt.Rows[0]["MobileNo"]);
                //lbldrname.Text = Convert.ToString(dt.Rows[0]["DrName"]);
                //lblAge.Text = Convert.ToString(dt.Rows[0]["Age"]) + "" + Convert.ToString(dt.Rows[0]["AgeType"]) + "/" + Convert.ToString(dt.Rows[0]["GenderName"]);
                ViewState["Age"] = Convert.ToString(dt.Rows[0]["Age"]);
                ViewState["AgeType"] = Convert.ToString(dt.Rows[0]["AgeType"]);

            }
            //dt = new DataTable();
            //dt = obj.Get_AllPatientVitalTaken(Convert.ToString(Session["EmrRegNo"]), Convert.ToString(Session["EmrOpdNo"]),Convert.ToInt32(Session["EmrIpdNo"]), Convert.ToInt32(Session["Branchid"]));
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
        if (rblsmoking.SelectedValue == "0")
        {
            ObjDALFPE.DouSmoke = Convert.ToBoolean(false);
        }
        else
        {
            ObjDALFPE.DouSmoke = Convert.ToBoolean(true);
        }
        ObjDALFPE.SmokeRemark = Convert.ToString(txtSmokeRemark.Text);
        if (txtStart.Text != "")
        {
            ObjDALFPE.SmokeDateQuite = Convert.ToString(txtStart.Text);
        }

        ObjDALFPE.HCG = Convert.ToString(txtHCG.Text);
        ObjDALFPE.Leukocytes = Convert.ToString(txtLeukocytes.Text);
        ObjDALFPE.Nitrite = Convert.ToString(txtNitrite.Text);
        ObjDALFPE.Protein = Convert.ToString(txtProtein.Text);
        ObjDALFPE.Glucose = Convert.ToString(txtGlucose.Text);
        ObjDALFPE.Blood = Convert.ToString(txtBlood.Text);
        ObjDALFPE.PH = Convert.ToString(txtPH.Text);

        ObjDALFPE.SpecificGravity = Convert.ToString(txtSpecificGravity.Text);
        ObjDALFPE.Ketone = Convert.ToString(txtKetone.Text);
        ObjDALFPE.Urobilinogen = Convert.ToString(txtUrobilinogen.Text);
        ObjDALFPE.Biliruben = Convert.ToString(txtBiliruben.Text);
        ObjDALFPE.Remarks = Convert.ToString(txtComment.Text);

        if (chkfatherachild.Checked == true)
        {
            ObjDALFPE.FatherAChild = Convert.ToBoolean(true);
        }
        if (chkfathernevachild.Checked == true)
        {
            ObjDALFPE.FatherNevChild = Convert.ToBoolean(true);
        }
        if (ChkOccuption.Checked == true)
        {
            ObjDALFPE.IsOccuption = Convert.ToBoolean(true);
        }
        if (chkTabacouse.Checked == true)
        {
            ObjDALFPE.TabaccoUse = Convert.ToBoolean(true);
        }
        if (chkdruguse.Checked == true)
        {
            ObjDALFPE.DrugUse = Convert.ToBoolean(true);
        }
        ObjDALFPE.OccitpionRemark = Convert.ToString(txtHusremark.Text);
        ObjDALFPE.DrugUseRemark = Convert.ToString(txtdrugyse.Text);
        ObjDALFPE.TabaccoRemark = Convert.ToString(txttabaccouse.Text);

        if (chkRegular.Checked == true)
        {
            ObjDALFPE.MenstrualCyclesRegular = Convert.ToBoolean(true);
        }
        ObjDALFPE.MenstrualCyclesRemark = Convert.ToString(txtregular.Text);
        

        if (ChkIrregular.Checked == true)
        {
            ObjDALFPE.MenstrualCyclesIrregular = Convert.ToBoolean(true);
        }
        ObjDALFPE.MenstrualCyclesIrregularRemark = Convert.ToString(txtIrregular.Text);

        if (chkCoitalFrequency.Checked == true)
        {
            ObjDALFPE.CoitalFrequency = Convert.ToBoolean(true);
        }
        ObjDALFPE.CoitalFrequencyRemark = Convert.ToString(txtCoitalFrequency.Text);

        if (chkDysmenorrhea.Checked == true)
        {
            ObjDALFPE.Dysmenorrhea = Convert.ToBoolean(true);
        }
        ObjDALFPE.DysmenorrheaRemark = Convert.ToString(txtDysmenorrhea.Text);
        if (ChkPelvicPain.Checked == true)
        {
            ObjDALFPE.PelvicPain = Convert.ToBoolean(true);
        }
        ObjDALFPE.PelvicPainRemark = Convert.ToString(txtPelvicPain.Text);

        if (ChkHSGResult.Checked == true)
        {
            ObjDALFPE.HSGResult = Convert.ToBoolean(true);
        }
        ObjDALFPE.HSGResultRemark = Convert.ToString(txtHSgresult.Text);

        if (chksemenanalysis.Checked == true)
        {
            ObjDALFPE.SemenAnalysis = Convert.ToBoolean(true);
        }
        ObjDALFPE.SemenAnalysisRemark = Convert.ToString(txtSemenAnalysis.Text);
        if (chkClomid.Checked == true)
        {
            ObjDALFPE.Clomid = Convert.ToBoolean(true);
        }
        ObjDALFPE.ClomidRemark = Convert.ToString(txtClomid.Text);

        if (chkGnRHAgonists.Checked == true)
        {
            ObjDALFPE.GnRHAgonists = Convert.ToBoolean(true);
        }
        ObjDALFPE.GnRHAgonistsRemark = Convert.ToString(txtGnRHAgonists.Text);
        if (ChkIUI.Checked == true)
        {
            ObjDALFPE.IUI = Convert.ToBoolean(true);
        }
        ObjDALFPE.IUIRemark = Convert.ToString(txtIUI.Text);
        if (chkIVF.Checked == true)
        {
            ObjDALFPE.IVF = Convert.ToBoolean(true);
        }
        ObjDALFPE.IVFRemark = Convert.ToString(txtIVF.Text);
        if (chkHysteroscopy.Checked == true)
        {
            ObjDALFPE.Hysteroscopy = Convert.ToBoolean(true);
        }
        ObjDALFPE.HysteroscopyRemark = Convert.ToString(txtHysteroscopy.Text);
        if (chkLaparoscopy.Checked == true)
        {
            ObjDALFPE.Laparoscopy = Convert.ToBoolean(true);
        }
        ObjDALFPE.LaparoscopyRemark = Convert.ToString(txtLaparoscopy.Text);

        if (Convert.ToString(Session["EmrOpdNo"]) != "")
        {
            ObjDALFPE.OpdNo = Convert.ToInt32(Session["EmrOpdNo"]);
        }
        else
        {
            ObjDALFPE.OpdNo = 0;
        }
        if (Convert.ToString(Session["EmrIpdNo"]) != "")
        {
            ObjDALFPE.IpdNo = Convert.ToInt32(Session["EmrIpdNo"]);
        }
        else
        {
            ObjDALFPE.IpdNo = 0;
        }
        ObjDALFPE.Patregid = Convert.ToString(Session["EmrRegNo"]);
        ObjDALFPE.CreatedBy = Convert.ToString(Session["username"]);
        ObjDALFPE.UpdatedBy = Convert.ToString(Session["username"]);
        ObjDALFPE.FId = Convert.ToInt32(Session["FId"]); ;
        ObjDALFPE.BranchId = Convert.ToInt32(Session["Branchid"]);

        ObjBELFPE.InsertFamilyPlanningExam(ObjDALFPE);
        BindFPF();
        Clear();
    }
    private void BindFPF()
    {
        if (Convert.ToString(Session["EmrOpdNo"]) != "")
        {
            ObjDALFPE.OpdNo = Convert.ToInt32(Session["EmrOpdNo"]);
        }
        else
        {
            ObjDALFPE.OpdNo = 0;
        }
        if (Convert.ToString(Session["EmrIpdNo"]) != "")
        {
            ObjDALFPE.IpdNo = Convert.ToInt32(Session["EmrIpdNo"]);
        }
        else
        {
            ObjDALFPE.IpdNo = 0;
        }
        ObjDALFPE.Patregid = Convert.ToString(Session["EmrRegNo"]);
        ObjDALFPE.CreatedBy = Convert.ToString(Session["username"]);
        ObjDALFPE.UpdatedBy = Convert.ToString(Session["username"]);
        ObjDALFPE.FId = Convert.ToInt32(Session["FId"]); ;
        ObjDALFPE.BranchId = Convert.ToInt32(Session["Branchid"]);
        tempDatatable = ObjBELFPE.GetAllFamilyPlanning(ObjDALFPE);
        gvdChief.DataSource = tempDatatable;
        gvdChief.DataBind();
        if (tempDatatable.Rows.Count > 0)
        {
            BtnBirthRegister.ForeColor = System.Drawing.Color.White;
            BtnBirthRegister.BackColor = System.Drawing.Color.Red;
            //btnChief1_light.Visible = true;
        }
    }
    protected void gvdChief_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvdChief.PageIndex = e.NewPageIndex;
        BindFPF();
        mp1.Show();
    }

    protected void gvdChief_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }

    protected void gvdChief_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void gvdChief_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    public void Clear()
    {
        txtBiliruben.Text = "";
        txtBlood.Text = "";
        txtBMI.Text = "";
        txtClomid.Text = "";
        txtCoitalFrequency.Text = "";
        txtComment.Text = "";
        txtdrugyse.Text = "";
        txtDysmenorrhea.Text = "";
        txtGlucose.Text = "";
        txtGnRHAgonists.Text = "";
        txtHCG.Text = "";
        txtHeight.Text = "";
        txtHSgresult.Text = "";
        txtHusremark.Text = "";
        txtHysteroscopy.Text = "";
        txtIrregular.Text = "";
        txtIUI.Text = "";
        txtIVF.Text = "";
        txtKetone.Text = "";
        txtLaparoscopy.Text = "";
        txtLeukocytes.Text = "";
        txtNitrite.Text = "";
        txtPelvicPain.Text = "";
        txtPH.Text = "";
        txtProtein.Text = "";
        txtregular.Text = "";
        txtSemenAnalysis.Text = "";
        txtSmokeRemark.Text = "";
        txtSpecificGravity.Text = "";
        txttabaccouse.Text = "";
        txtUrobilinogen.Text = "";
       
       
    }
}