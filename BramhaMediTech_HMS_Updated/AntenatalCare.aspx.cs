using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
public partial class AntenatalCare :BasePage
{
    clsEmr obj = new clsEmr();
    clsTreatment objTreat = new clsTreatment();
    clsTreatmentTransaction transaction = new clsTreatmentTransaction();
    DataTable tempDatatable = new DataTable();
    //BLLPatientCategory objBLLPatientCategory = new BLLPatientCategory();
    //DOPatientCategory objDOPatientCategory = new DOPatientCategory();
    DALANCExamination ObjDALANC = new DALANCExamination();
    BELANCExamination ObjBELANC = new BELANCExamination();
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
                //lblOpd.Text = opd;
                PindPatientInformation();
                BindANC();
            }
        }
    }
    public void PindPatientInformation()
    {
        //DataTable dt = new DataTable();
        //dt = obj.Get_AllPatientInformation(Convert.ToString(Session["EmrRegNo"]), Convert.ToString(Session["EmrOpdNo"]), Convert.ToInt32(Session["EmrIpdNo"]), Convert.ToInt32(Session["Branchid"]));
        //try
        //{
        //    if (dt != null)
        //    {
        //        lblPatientName.Text = Convert.ToString(dt.Rows[0]["PatientName"]);
        //        txtpatientregid.Text = Convert.ToString(dt.Rows[0]["PatRegId"]);
        //        lblIpd.Text = Convert.ToString(dt.Rows[0]["Ipdno"]);
        //        lblOpd.Text = Convert.ToString(dt.Rows[0]["PatRegId"]);
        //        lblMobileNo.Text = Convert.ToString(dt.Rows[0]["MobileNo"]);
        //        lbldrname.Text = Convert.ToString(dt.Rows[0]["DrName"]);
        //        lblAge.Text = Convert.ToString(dt.Rows[0]["Age"]) + "" + Convert.ToString(dt.Rows[0]["AgeType"]) + "/" + Convert.ToString(dt.Rows[0]["GenderName"]);
        //        ViewState["Age"] = Convert.ToString(dt.Rows[0]["Age"]);
        //        ViewState["AgeType"] = Convert.ToString(dt.Rows[0]["AgeType"]);

        //    }
        //    dt = new DataTable();
        //    dt = obj.Get_AllPatientVitalTaken(Convert.ToString(Session["EmrRegNo"]), Convert.ToString(Session["EmrOpdNo"]), Convert.ToInt32(Session["EmrIpdNo"]), Convert.ToInt32(Session["Branchid"]));
        //    if (dt.Rows.Count > 0)
        //    {
        //        lblvtaken.Text = Convert.ToString(dt.Rows[0]["CreatedOn"]);
        //    }
        //}
        //catch (Exception ex)
        //{

        //}
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        if (validation() == true)
        {
            if (txtLPMDate.Text != "")
            {
                ObjDALANC.LMPDate = Convert.ToDateTime(txtLPMDate.Text);
            }
            if (txtEstimateDelDate.Text != "")
            {
                ObjDALANC.EstDeliveryDate = Convert.ToDateTime(txtEstimateDelDate.Text);
            }
            else
            {
                ObjDALANC.EstDeliveryDate = DateTimeConvesion.getDateFromString(Date.getdate().Date.ToString("dd/MM/yyyy")).Date;
                //  ObjDALANC.EstDeliveryDate = null;
            }

            ObjDALANC.FundelHeight = Convert.ToString(txtFundelHeight.Text);
            ObjDALANC.Gestation = Convert.ToString(txtGestation.Text);
            ObjDALANC.Parity = Convert.ToString(txtParity.Text);
            if (rblFoetalMovement.SelectedValue == "1")
            {
                ObjDALANC.FotealMovement = true;
            }
            else
            {
                ObjDALANC.FotealMovement = false;
            }
            ObjDALANC.FeatelHEarthBeat = Convert.ToString(txtFetalHearthBeat.Text);

            if (ChkTT1.Checked == true)
            {
                ObjDALANC.TT1 = Convert.ToBoolean(true);
            }
            if (ChkTT2.Checked == true)
            {
                ObjDALANC.TT2 = Convert.ToBoolean(true);
            }
            if (chkIPT1.Checked == true)
            {
                ObjDALANC.IPT1 = Convert.ToBoolean(true);
            }
            if (chkIPT2.Checked == true)
            {
                ObjDALANC.IPT2 = Convert.ToBoolean(true);
            }
            if (chkHB.Checked == true)
            {
                ObjDALANC.HIV = Convert.ToBoolean(true);
            }
            if (chkHB.Checked == true)
            {
                ObjDALANC.HB = Convert.ToBoolean(true);
            }
            if (ChkBloodGroup.Checked == true)
            {
                ObjDALANC.BloodGroup = Convert.ToBoolean(true);
            }
            if (ChkSyphilis.Checked == true)
            {
                ObjDALANC.SyphilisTest = Convert.ToBoolean(true);
            }
            if (chkurinalysis.Checked == true)
            {
                ObjDALANC.Urinalysis = Convert.ToBoolean(true);
            }
            if (ChkUltraScoundScan.Checked == true)
            {
                ObjDALANC.UltrasoundScan = Convert.ToBoolean(true);
            }
            ObjDALANC.Estimatedfoetalsize = Convert.ToString(txtestimatelfoetalsize.Text);
            ObjDALANC.EstimatedfoetalWidth = Convert.ToString(txtestimatelfoetalweight.Text);
            ObjDALANC.Complant = Convert.ToString(txtCompalnt.Text);
            ObjDALANC.Conclusion = Convert.ToString(txtConclusion.Text);

            if (Convert.ToString(Session["EmrOpdNo"]) != "")
            {
                ObjDALANC.OpdNo = Convert.ToInt32(Session["EmrOpdNo"]);
            }
            else
            {
                ObjDALANC.OpdNo = 0;
            }
            if (Convert.ToString(Session["EmrIpdNo"]) != "")
            {
                ObjDALANC.IpdNo = Convert.ToInt32(Session["EmrIpdNo"]);
            }
            else
            {
                ObjDALANC.IpdNo = 0;
            }
            ObjDALANC.Patregid = Convert.ToString(Session["EmrRegNo"]);
            ObjDALANC.CreatedBy = Convert.ToString(Session["username"]);
            ObjDALANC.UpdatedBy = Convert.ToString(Session["username"]);
            ObjDALANC.FId = Convert.ToInt32(Session["FId"]); ;
            ObjDALANC.BranchId = Convert.ToInt32(Session["Branchid"]);

            ObjBELANC.InsertANCExam(ObjDALANC);
            LblMSg.Text = "Record save successfully.!";
            LblMSg.ForeColor = System.Drawing.Color.Green;
            BindANC();
            Clear();
        }
    }
    public bool validation()
    {

        if (txtLPMDate.Text == "")
        {

            txtLPMDate.Focus();
            txtLPMDate.BackColor = Color.Red;
            return false;
        }
        else
        {
            txtLPMDate.BackColor = Color.White;
        }
        if (txtEstimateDelDate.Text == "")
        {

            txtEstimateDelDate.Focus();
            txtEstimateDelDate.BackColor = Color.Red;
            return false;
        }
        else
        {
            txtEstimateDelDate.BackColor = Color.White;
        }

        return true;
    }
    private void BindANC()
    {
        if (Convert.ToString(Session["EmrOpdNo"]) != "")
        {
            ObjDALANC.OpdNo = Convert.ToInt32(Session["EmrOpdNo"]);
        }
        else
        {
            ObjDALANC.OpdNo = 0;
        }
        if (Convert.ToString(Session["EmrIpdNo"]) != "")
        {
            ObjDALANC.IpdNo = Convert.ToInt32(Session["EmrIpdNo"]);
        }
        else
        {
            ObjDALANC.IpdNo = 0;
        }
        ObjDALANC.Patregid = Convert.ToString(Session["EmrRegNo"]);
        ObjDALANC.CreatedBy = Convert.ToString(Session["username"]);
        ObjDALANC.UpdatedBy = Convert.ToString(Session["username"]);
        ObjDALANC.FId = Convert.ToInt32(Session["FId"]); ;
        ObjDALANC.BranchId = Convert.ToInt32(Session["Branchid"]);
        tempDatatable = ObjBELANC.GetAllANC(ObjDALANC);
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
        BindANC();
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
        txtAC.Text = "";
        txtBPD.Text = "";
        txtCompalnt.Text = "";
        txtConclusion.Text = "";
        txtEstimateDelDate.Text = "";
        txtestimatelfoetalsize.Text = "";
        txtestimatelfoetalweight.Text = "";
        txtFetalHearthBeat.Text = "";
        txtFL.Text = "";
        txtFundelHeight.Text = "";
        txtGestation.Text = "";
        txtHC.Text = "";
        txtHL.Text = "";
        txtLPMDate.Text = "";
        txtParity.Text = "";
    }
}