using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
public partial class BirthRegister : System.Web.UI.Page
{
    clsEmr obj = new clsEmr();
    clsTreatment objTreat = new clsTreatment();
    clsTreatmentTransaction transaction = new clsTreatmentTransaction();
    DataTable tempDatatable = new DataTable();
    BELBirthRegister OBJBELBR = new BELBirthRegister();
    DALBirthRegister OBJDALBR = new DALBirthRegister();
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
                lblOpd.Text = opd;
                PindPatientInformation();
                BindBirthRegister();
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
                lblIpd.Text = Convert.ToString(dt.Rows[0]["Ipdno"]);
                lblOpd.Text = Convert.ToString(dt.Rows[0]["PatRegId"]);
                lblMobileNo.Text = Convert.ToString(dt.Rows[0]["MobileNo"]);
                lbldrname.Text = Convert.ToString(dt.Rows[0]["DrName"]);
                lblAge.Text = Convert.ToString(dt.Rows[0]["Age"]) + "" + Convert.ToString(dt.Rows[0]["AgeType"]) + "/" + Convert.ToString(dt.Rows[0]["GenderName"]);
                ViewState["Age"] = Convert.ToString(dt.Rows[0]["Age"]);
                ViewState["AgeType"] = Convert.ToString(dt.Rows[0]["AgeType"]);

            }
            dt = new DataTable();
            dt = obj.Get_AllPatientVitalTaken(Convert.ToString(Session["EmrRegNo"]), Convert.ToString(Session["EmrOpdNo"]), Convert.ToInt32(Session["EmrIpdNo"]), Convert.ToInt32(Session["Branchid"]));
            if (dt.Rows.Count > 0)
            {
                lblvtaken.Text = Convert.ToString(dt.Rows[0]["CreatedOn"]);
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        if (validation() == true)
        {
            if (Convert.ToString(Session["EmrOpdNo"]) != "")
            {
                OBJDALBR.OpdNo = Convert.ToInt32(Session["EmrOpdNo"]);
            }
            else
            {
                OBJDALBR.OpdNo = 0;
            }
            if (Convert.ToString(Session["EmrIpdNo"]) != "")
            {
                OBJDALBR.IpdNo = Convert.ToInt32(Session["EmrIpdNo"]);
            }
            else
            {
                OBJDALBR.IpdNo = 0;
            }
            OBJDALBR.Patregid = Convert.ToString(Session["EmrRegNo"]);
            OBJDALBR.CreatedBy = Convert.ToString(Session["username"]);
            OBJDALBR.UpdatedBy = Convert.ToString(Session["username"]);
            OBJDALBR.FId = Convert.ToInt32(Session["FId"]); ;
            OBJDALBR.BranchId = Convert.ToInt32(Session["Branchid"]);

            OBJDALBR.BabyName = Convert.ToString(txtBabyName.Text);
            OBJDALBR.MotherName = Convert.ToString(txtMotherName.Text);
            OBJDALBR.FatherName = Convert.ToString(txtFatherName.Text);
            OBJDALBR.BirthTime = Convert.ToString(txtBirthTime.Text);
            OBJDALBR.BirthDate = Convert.ToDateTime(txtBirthDate.Text);
            OBJDALBR.Sex = Convert.ToString(rblGenderBaby.SelectedItem.Text);
            OBJDALBR.ModeOFDelivery = Convert.ToString(ddlModeofDelivery.SelectedItem.Text);
            OBJDALBR.WaitInGram = Convert.ToString(txtwaitingram.Text);
            OBJDALBR.Comment = Convert.ToString(txtComment.Text);
            OBJBELBR.InsertBirthRegister(OBJDALBR);
            LblMSg.ForeColor = System.Drawing.Color.Green;
            LblMSg.Text = "Record save successfully!.";
            BindBirthRegister();
            Clear();
        }
    }
    public void Clear()
    {
        txtBabyName.Text = "";
        txtBirthDate.Text = "";
        txtBirthTime.Text = "";
        txtComment.Text = "";
        txtFatherName.Text = "";
        txtMotherName.Text = "";
        txtwaitingram.Text = "";
       
    }
    public bool validation()
    {

        if (txtBabyName.Text == "")
        {

            txtBabyName.Focus();
            txtBabyName.BackColor = Color.Red;
            return false;
        }
        else
        {
            txtBabyName.BackColor = Color.White;
        }
        if (txtMotherName.Text == "")
        {

            txtMotherName.Focus();
            txtMotherName.BackColor = Color.Red;
            return false;
        }
        else
        {
            txtMotherName.BackColor = Color.White;
        }
        if (txtFatherName.Text == "")
        {

            txtFatherName.Focus();
            txtFatherName.BackColor = Color.Red;
            return false;
        }
        else
        {
            txtFatherName.BackColor = Color.White;
        }
        if (txtBirthTime.Text == "")
        {

            txtBirthTime.Focus();
            txtBirthTime.BackColor = Color.Red;
            return false;
        }
        else
        {
            txtBirthTime.BackColor = Color.White;
        }
        if (txtBirthDate.Text == "")
        {

            txtBirthDate.Focus();
            txtBirthDate.BackColor = Color.Red;
            return false;
        }
        else
        {
            txtBirthDate.BackColor = Color.White;
        }
        if (txtBirthTime.Text == "")
        {

            txtBirthTime.Focus();
            txtBirthTime.BackColor = Color.Red;
            return false;
        }
        else
        {
            txtBirthTime.BackColor = Color.White;
        }
        if (txtwaitingram.Text == "")
        {

            txtwaitingram.Focus();
            txtwaitingram.BackColor = Color.Red;
            return false;
        }
        else
        {
            txtwaitingram.BackColor = Color.White;
        }

        return true;
    }
    private void BindBirthRegister()
    {
        if (Convert.ToString(Session["EmrOpdNo"]) != "")
        {
            OBJDALBR.OpdNo = Convert.ToInt32(Session["EmrOpdNo"]);
        }
        else
        {
            OBJDALBR.OpdNo = 0;
        }
        if (Convert.ToString(Session["EmrIpdNo"]) != "")
        {
            OBJDALBR.IpdNo = Convert.ToInt32(Session["EmrIpdNo"]);
        }
        else
        {
            OBJDALBR.IpdNo = 0;
        }
        OBJDALBR.Patregid = Convert.ToString(Session["EmrRegNo"]);
        OBJDALBR.CreatedBy = Convert.ToString(Session["username"]);
        OBJDALBR.UpdatedBy = Convert.ToString(Session["username"]);
        OBJDALBR.FId = Convert.ToInt32(Session["FId"]); ;
        OBJDALBR.BranchId = Convert.ToInt32(Session["Branchid"]);
        tempDatatable = OBJBELBR.GetAllBirthRegister(OBJDALBR);
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
        BindBirthRegister();
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
}