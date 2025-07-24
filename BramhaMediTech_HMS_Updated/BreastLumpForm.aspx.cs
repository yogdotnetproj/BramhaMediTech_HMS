using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BreastLumpForm : BasePage
{
    clsEmr obj = new clsEmr();
    clsTreatment objTreat = new clsTreatment();
    clsTreatmentTransaction transaction = new clsTreatmentTransaction();
    DataTable tempDatatable = new DataTable();
    BLLPatientCategory objBLLPatientCategory = new BLLPatientCategory();
    DOPatientCategory objDOPatientCategory = new DOPatientCategory();

    DALBreastLumpExamination ObjDALBLE = new DALBreastLumpExamination();
    BELBreastLumpExamination ObjBELBLE = new BELBreastLumpExamination();
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
                BindBLE();
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
        if (rblsmoking.SelectedValue == "0")
        {
            ObjDALBLE.DouSmoke = Convert.ToBoolean(false);
        }
        else
        {
            ObjDALBLE.DouSmoke = Convert.ToBoolean(true);
        }
        ObjDALBLE.SmokeRemark = Convert.ToString(txtSmokeRemark.Text);
        if (txtStart.Text != "")
        {
            ObjDALBLE.SmokeDateQuite = Convert.ToString(txtStart.Text);
        }

        ObjDALBLE.HCG = Convert.ToString(txtHCG.Text);
        ObjDALBLE.Leukocytes = Convert.ToString(txtLeukocytes.Text);
        ObjDALBLE.Nitrite = Convert.ToString(txtNitrite.Text);
        ObjDALBLE.Protein = Convert.ToString(txtProtein.Text);
        ObjDALBLE.Glucose = Convert.ToString(txtGlucose.Text);
        ObjDALBLE.Blood = Convert.ToString(txtBlood.Text);
        ObjDALBLE.PH = Convert.ToString(txtPH.Text);

        ObjDALBLE.SpecificGravity = Convert.ToString(txtSpecificGravity.Text);
        ObjDALBLE.Ketone = Convert.ToString(txtKetone.Text);
        ObjDALBLE.Urobilinogen = Convert.ToString(txtUrobilinogen.Text);
        ObjDALBLE.Biliruben = Convert.ToString(txtBiliruben.Text);
        ObjDALBLE.Remarks = Convert.ToString(txtComment.Text);
        ObjDALBLE.HPIComment = Convert.ToString(txthpi.Text);

        ObjDALBLE.LeftBrestComplant = Convert.ToString(txtLeftBreastComp.Text);
        ObjDALBLE.LeftBrestComplantDuration = Convert.ToString(txtLeftBreastDuration.Text);
        if (chkLsoft.Checked == true)
        {
            ObjDALBLE.LeftSoftCystic = Convert.ToBoolean(true);
        }
        ObjDALBLE.LeftSoftCysticComment = Convert.ToString(txtLSoft.Text);
        if (ChkLFirm.Checked == true)
        {
            ObjDALBLE.LeftFirm = Convert.ToBoolean(true);
        }
        ObjDALBLE.LeftFirmComment = Convert.ToString(txtLFirm.Text);
        if (chkLMobile.Checked == true)
        {
            ObjDALBLE.LeftMobile = Convert.ToBoolean(true);
        }
        ObjDALBLE.LeftMobileComment = Convert.ToString(txtlMobile.Text);
        if (chkPreLMenopausal.Checked == true)
        {
            ObjDALBLE.LeftPreMenopausal = Convert.ToBoolean(true);
        }
        ObjDALBLE.LeftPostMenopausal = Convert.ToString(chkPostLMenopausal.Checked);

        ObjDALBLE.RightBrestComplant = Convert.ToString(txtRightBreastComp.Text);
        ObjDALBLE.RightBrestComplantDuration = Convert.ToString(txtRightBreastDuration.Text);
        if (chkRsoft.Checked == true)
        {
            ObjDALBLE.RightSoftCystic = Convert.ToBoolean(true);
        }
        ObjDALBLE.RightSoftCysticComment = Convert.ToString(txtRSoft.Text);
        if (ChkRFirm.Checked == true)
        {
            ObjDALBLE.RightFirm = Convert.ToBoolean(true);
        }
        ObjDALBLE.RightFirmComment = Convert.ToString(txtRFirm.Text);
        if (chkRMobile.Checked == true)
        {
            ObjDALBLE.RightMobile = Convert.ToBoolean(true);
        }
        ObjDALBLE.RightMobileComment = Convert.ToString(txtRMobile.Text);
        if (chkPreRMenopausal.Checked == true)
        {
            ObjDALBLE.RightPreMenopausal = Convert.ToBoolean(true);
        }
        ObjDALBLE.RightPostMenopausal = Convert.ToString(chkPostRMenopausal.Checked);
        if (chkFibrocystic.Checked == true)
        {
            ObjDALBLE.Fibrocystic = Convert.ToBoolean(true);
        }
        if (chkClinicallyFeels.Checked == true)
        {
            ObjDALBLE.Clinicallyfeels = Convert.ToBoolean(true);
        }
        if (chkClinicallySuspic.Checked == true)
        {
            ObjDALBLE.ClinicallySuspicious = Convert.ToBoolean(true);
        }
        ObjDALBLE.Comments = Convert.ToString(txtremark.Text);
        if (Convert.ToString(Session["EmrOpdNo"]) != "")
        {
            ObjDALBLE.OpdNo = Convert.ToInt32(Session["EmrOpdNo"]);
        }
        else
        {
            ObjDALBLE.OpdNo = 0;
        }
        if (Convert.ToString(Session["EmrIpdNo"]) != "")
        {
            ObjDALBLE.IpdNo = Convert.ToInt32(Session["EmrIpdNo"]);
        }
        else
        {
            ObjDALBLE.IpdNo = 0;
        }
        ObjDALBLE.Patregid = Convert.ToString(Session["EmrRegNo"]);
        ObjDALBLE.CreatedBy = Convert.ToString(Session["username"]);
        ObjDALBLE.UpdatedBy = Convert.ToString(Session["username"]);
        ObjDALBLE.FId = Convert.ToInt32(Session["FId"]); ;
        ObjDALBLE.BranchId = Convert.ToInt32(Session["Branchid"]);

        ObjBELBLE.InsertBrestLumpExam(ObjDALBLE);
        LblMSg.Text = "Record save successfully.!";
        LblMSg.ForeColor = System.Drawing.Color.Green;
        BindBLE();
    }
    private void BindBLE()
    {
        if (Convert.ToString(Session["EmrOpdNo"]) != "")
        {
            ObjDALBLE.OpdNo = Convert.ToInt32(Session["EmrOpdNo"]);
        }
        else
        {
            ObjDALBLE.OpdNo = 0;
        }
        if (Convert.ToString(Session["EmrIpdNo"]) != "")
        {
            ObjDALBLE.IpdNo = Convert.ToInt32(Session["EmrIpdNo"]);
        }
        else
        {
            ObjDALBLE.IpdNo = 0;
        }
        ObjDALBLE.Patregid = Convert.ToString(Session["EmrRegNo"]);
        ObjDALBLE.CreatedBy = Convert.ToString(Session["username"]);
        ObjDALBLE.UpdatedBy = Convert.ToString(Session["username"]);
        ObjDALBLE.FId = Convert.ToInt32(Session["FId"]); ;
        ObjDALBLE.BranchId = Convert.ToInt32(Session["Branchid"]);
        tempDatatable = ObjBELBLE.GetAllBLE(ObjDALBLE);
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
        BindBLE();
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
        txtBiliruben.Text = "";
        txtBlood.Text = "";
        txtComment.Text = "";
        txtLeftBreastComp.Text = "";
        txtLeftBreastDuration.Text = "";
        txtGlucose.Text = "";
        txtLeukocytes.Text = "";
        txtHCG.Text = "";
        txtHeight.Text = "";
        txtLFirm.Text = "";
        txtlMobile.Text = "";
        txtLSoft.Text = "";
        txtNitrite.Text = "";
        txtremark.Text = "";
        txtRFirm.Text = "";
        txtRightBreastComp.Text = "";
        txtRightBreastDuration.Text = "";
        txtLeukocytes.Text = "";
        txtNitrite.Text = "";
        txtRMobile.Text = "";
        txtPH.Text = "";
        txtProtein.Text = "";
        txtRSoft.Text = "";
        txtSmokeRemark.Text = "";
        txtSmokeRemark.Text = "";
        txtSpecificGravity.Text = "";
      
        txtUrobilinogen.Text = "";


    }
}