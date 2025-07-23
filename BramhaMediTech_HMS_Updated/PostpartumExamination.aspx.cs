using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PostpartumExamination : System.Web.UI.Page
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
        if (rblsmoking.SelectedValue == "0")
        {
            ObjDALPPE.DouSmoke = Convert.ToBoolean(false);
        }
        else
        {
            ObjDALPPE.DouSmoke = Convert.ToBoolean(true);
        }
        ObjDALPPE.SmokeRemark = Convert.ToString(txtSmokeRemark.Text);
        if (txtStart.Text != "")
        {
            ObjDALPPE.SmokeDateQuite = Convert.ToString(txtStart.Text);
        }
        if (chkDep.Checked == true)
        {
            ObjDALPPE.Depression = Convert.ToBoolean(true);
        }
       
        ObjDALPPE.DepressionRemark = Convert.ToString(txtDepressioncomment.Text);
        ObjDALPPE.Feeding = Convert.ToString( rblFeeding.SelectedItem.Text);
        ObjDALPPE.FeedingRemark = Convert.ToString(txtFeedingComment.Text);

        ObjDALPPE.Bleeding = Convert.ToString(rblBleeding.SelectedItem.Text);
        ObjDALPPE.BleedingRemark = Convert.ToString(txtbleedingComment.Text);

        ObjDALPPE.BrestExam = Convert.ToString(rblBrestExam.SelectedItem.Text);
        ObjDALPPE.BrestRemark = Convert.ToString(txtBrestComment.Text);

        ObjDALPPE.BrestComplant = Convert.ToString(txtbrestcomplants.Text);

        

        ObjDALPPE.CSection = Convert.ToString(RblCSection.SelectedItem.Text);
        ObjDALPPE.CSectionRemark = Convert.ToString(txtCComment.Text);
        if (RblEPisiotomy.SelectedValue != "")
        {
           // ObjDALPPE.Episiotomy = Convert.ToInt32(RblEPisiotomy.SelectedValue);
            ObjDALPPE.Episiotomy = Convert.ToString(RblEPisiotomy.SelectedItem.Text);
        }
       
        ObjDALPPE.EpisiotomyRemark = Convert.ToString(txtEpisiotomyComment.Text);

        if (RblUterus.SelectedValue != "")
        {
            //ObjDALPPE.Uterus = Convert.ToInt32(RblUterus.SelectedValue);
            ObjDALPPE.Uterus = Convert.ToString(RblUterus.SelectedItem.Text);
        }
        
      
        ObjDALPPE.UterusRemark = Convert.ToString(txtUterusComment.Text);

        ObjDALPPE.BirthControl = Convert.ToString(RblBirthControl.SelectedItem.Text);
        ObjDALPPE.BirthControlRemark = Convert.ToString(txtbirthcontrolComment.Text);

       
        ObjDALPPE.GeneralRemark = Convert.ToString(txtRemark.Text);
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
            if (Convert.ToString(Session["PatAdmit"]) == "No")
            {
                lblmsg.ForeColor = System.Drawing.Color.Red;
                lblmsg.Text = "Patient already discharge!";
                return;
            }
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

        ObjBELPPE.InsertPostpartumExam(ObjDALPPE);
        lblmsg.Text = "Record save successfully.!";
        lblmsg.ForeColor = System.Drawing.Color.Green;
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
        tempDatatable = ObjBELPPE.GetAllPostpartumExam(ObjDALPPE);
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
        BindPE();
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
       


    }
}