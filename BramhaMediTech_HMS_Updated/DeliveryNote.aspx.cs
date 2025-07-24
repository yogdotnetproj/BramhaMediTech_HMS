using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
public partial class DeliveryNote : BasePage
{
    clsEmr obj = new clsEmr();
    clsTreatment objTreat = new clsTreatment();
    clsTreatmentTransaction transaction = new clsTreatmentTransaction();
    DataTable tempDatatable = new DataTable();
    BELDeliveryNote objBELDN = new BELDeliveryNote();
    DALDeliveryNote objDALDN = new DALDeliveryNote();
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
                BindDeliveryNote();
            }
        }
    }
    public void PindPatientInformation()
    {
        DataTable dt = new DataTable();
        dt = obj.Get_AllPatientInformation(Convert.ToString(Session["EmrRegNo"]), Convert.ToString(Session["EmrOpdNo"]), 0, Convert.ToInt32(Session["Branchid"]));
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
            dt = obj.Get_AllPatientVitalTaken(Convert.ToString(Session["EmrRegNo"]), Convert.ToString(Session["EmrOpdNo"]), 0, Convert.ToInt32(Session["Branchid"]));
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
                objDALDN.OpdNo = Convert.ToInt32(Session["EmrOpdNo"]);
            }
            else
            {
                objDALDN.OpdNo = 0;
            }
            if (Convert.ToString(Session["EmrIpdNo"]) != "")
            {
                objDALDN.IpdNo = Convert.ToInt32(Session["EmrIpdNo"]);
            }
            else
            {
                objDALDN.IpdNo = 0;
            }
            objDALDN.Patregid = Convert.ToString(Session["EmrRegNo"]);
            objDALDN.CreatedBy = Convert.ToString(Session["username"]);
            objDALDN.UpdatedBy = Convert.ToString(Session["username"]);
            objDALDN.FId = Convert.ToInt32(Session["FId"]); ;
            objDALDN.BranchId = Convert.ToInt32(Session["Branchid"]);

            objDALDN.DeliveryConductBy = Convert.ToString(txtDeliveryConduct.Text);
            objDALDN.Gravida = Convert.ToString(txtGravida.Text);
            objDALDN.HusbandName = Convert.ToString(txthusbandname.Text);
            objDALDN.Condition = Convert.ToString(txtCondition.Text);
            objDALDN.Matuarity = Convert.ToString(txtMatuarity.Text);
            objDALDN.DeliveryDate = Convert.ToDateTime(txtdeliverydate.Text);
            if (ChkMaterinalDeath.Checked == true)
            {
                objDALDN.MaternialDeath = Convert.ToBoolean(true);
            }
            objDALDN.MaterinityDeathReason = Convert.ToString(txtmaterinalDReason.Text);
            objDALDN.ModeofDelivery = Convert.ToString(ddlModeofDelivery.SelectedItem.Text);

            //if (rblGenderBaby.SelectedValue == "1")
            //{
            //    objDALDN.GenderofBaby = Convert.ToBoolean(true);
            //}
            //else
            //{
            //    objDALDN.GenderofBaby = Convert.ToBoolean(false);
            //}
            objDALDN.NumberOfBaby = Convert.ToInt32(rblNoOFbaby.SelectedValue);
            objDALDN.GenderofBaby = Convert.ToString(rblGenderBaby.SelectedItem.Text);
            objDALDN.DeliveryTime = Convert.ToString(txtdeliveryTime.Text);
            objDALDN.WeightOfBaby = Convert.ToString(txtweightofbaby.Text);
            objDALDN.Para = Convert.ToString(txtPAra.Text);
            objDALDN.StillBirth = Convert.ToString(txtstillbirth.Text);
            objDALDN.Living = Convert.ToString(txtLiving.Text);
            objDALDN.Abortion = Convert.ToString(txtAbortion.Text);
            objDALDN.Comments = Convert.ToString(txtComment.Text);


            objBELDN.InsertDeliveryNote(objDALDN);
            LblMSg.Text = "Record save successfully.!";
            LblMSg.ForeColor = System.Drawing.Color.Green;
            BindDeliveryNote();
            Clear();
        }
    }
    public bool validation()
    {

        if (txtdeliverydate.Text == "")
        {

            txtdeliverydate.Focus();
            txtdeliverydate.BackColor = Color.Red;
            return false;
        }
        else
        {
            txtdeliverydate.BackColor = Color.White;
        }
        if (txtweightofbaby.Text == "")
        {

            txtweightofbaby.Focus();
            txtweightofbaby.BackColor = Color.Red;
            return false;
        }
        else
        {
            txtweightofbaby.BackColor = Color.White;
        }

        return true;
    }

    public void Clear()
    {
        txtAbortion.Text = "";
        txtComment.Text = "";
        txtCondition.Text = "";
        txtComment.Text = "";
        txtDeliveryConduct.Text = "";
        txtdeliverydate.Text = "";
        txtdeliveryTime.Text = "";

        txtGravida.Text = "";
        txthusbandname.Text = "";
        txtLiving.Text = "";

        txtmaterinalDReason.Text = "";
        txtMatuarity.Text = "";
        txtPAra.Text = "";

        txtweightofbaby.Text = "";
        txtstillbirth.Text = "";
        txtPAra.Text = "";

    }
    private void BindDeliveryNote()
    {
        if (Convert.ToString(Session["EmrOpdNo"]) != "")
        {
            objDALDN.OpdNo = Convert.ToInt32(Session["EmrOpdNo"]);
        }
        else
        {
            objDALDN.OpdNo = 0;
        }
        if (Convert.ToString(Session["EmrIpdNo"]) != "")
        {
            objDALDN.IpdNo = Convert.ToInt32(Session["EmrIpdNo"]);
        }
        else
        {
            objDALDN.IpdNo = 0;
        }
        objDALDN.Patregid = Convert.ToString(Session["EmrRegNo"]);
        objDALDN.CreatedBy = Convert.ToString(Session["username"]);
        objDALDN.UpdatedBy = Convert.ToString(Session["username"]);
        objDALDN.FId = Convert.ToInt32(Session["FId"]); ;
        objDALDN.BranchId = Convert.ToInt32(Session["Branchid"]);
        tempDatatable = objBELDN.GetAllDeliveryNote(objDALDN);
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
        BindDeliveryNote();
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