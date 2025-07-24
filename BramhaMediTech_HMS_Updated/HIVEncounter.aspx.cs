using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HIVEncounter : BasePage
{
    clsEmr obj = new clsEmr();
    clsTreatment objTreat = new clsTreatment();
    clsTreatmentTransaction transaction = new clsTreatmentTransaction();
    DataTable tempDatatable = new DataTable();
    BELHIVCounterExamination objBLLHCE = new BELHIVCounterExamination();
    DALHIVCounterExamination objDAHCE = new DALHIVCounterExamination();
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
                BindHIVEncounter();
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
        //    dt = obj.Get_AllPatientVitalTaken(Convert.ToString(Session["EmrRegNo"]), Convert.ToString(Session["EmrOpdNo"]),Convert.ToInt32(Session["EmrIpdNo"]), Convert.ToInt32(Session["Branchid"]));
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
        if (rbladultchils.SelectedValue == "0")
        {
            objDAHCE.PatientAdult = Convert.ToBoolean(false);
        }
        else
        {
            objDAHCE.PatientAdult = Convert.ToBoolean(true);
        }
        if (chkMTCT.Checked == true)
        {
            objDAHCE.MTCTPluse = Convert.ToBoolean(true);
        }
        if (chkdishusband.Checked == true)
        {
            objDAHCE.DiscloseToHubby = Convert.ToBoolean(true);
        }
        if (chkismarried.Checked == true)
        {
            objDAHCE.Married = Convert.ToBoolean(true);
        }
        objDAHCE.Numberofwives = Convert.ToString(txtnumwives.Text);
        objDAHCE.NumberofChildren = Convert.ToString(txtnumberofchildren.Text);
        if (chkseparated.Checked == true)
        {
            objDAHCE.Divorced = Convert.ToBoolean(true);
        }
        objDAHCE.AgeofFirstchild = Convert.ToString(txtageoffirstchild.Text);
        objDAHCE.AgeofLastchild = Convert.ToString(txtageoflastchild.Text);

        if (chkspousedead.Checked == true)
        {
            objDAHCE.SpouseDead = Convert.ToBoolean(true);
        }

        if (chkSuspicion.Checked == true)
        {
            objDAHCE.SuspicionHIVcauseofdead = Convert.ToBoolean(true);
        }
        if (chkSuspected.Checked == true)
        {
            objDAHCE.SexualpartnerdiedofHIV = Convert.ToBoolean(true);
        }
        if (chkspousaware.Checked == true)
        {
            objDAHCE.SpouseawareofHIV = Convert.ToBoolean(true);
        }
        if (chkoutsidemarriage.Checked == true)
        {
            objDAHCE.SexPartnerOutsideMarraige = Convert.ToBoolean(true);
        }
        if (chkspouseoutsidemarriage.Checked == true)
        {
            objDAHCE.SpouseSexOutsideMarraige = Convert.ToBoolean(true);
        }
        if (chksexualy6.Checked == true)
        {
            objDAHCE.SexuallyActivity6Month = Convert.ToBoolean(true);
        }
        if (chkcondoms.Checked == true)
        {
            objDAHCE.AlwaysuseCondom = Convert.ToBoolean(true);
        }
        if (chkhivtherapy.Checked == true)
        {
            objDAHCE.HIVTheraphy = Convert.ToBoolean(true);
        }
        objDAHCE.NumberOfPartner = Convert.ToString(txtnumberofpartner.Text);
        objDAHCE.Comments = Convert.ToString(txtComment.Text);

        if (Convert.ToString(Session["EmrOpdNo"]) != "")
        {
            objDAHCE.OpdNo = Convert.ToInt32(Session["EmrOpdNo"]);
        }
        else
        {
            objDAHCE.OpdNo = 0;
        }
        if (Convert.ToString(Session["EmrIpdNo"]) != "")
        {
            objDAHCE.IpdNo = Convert.ToInt32(Session["EmrIpdNo"]);
        }
        else
        {
            objDAHCE.IpdNo = 0;
        }
        objDAHCE.Patregid = Convert.ToString(Session["EmrRegNo"]);
        objDAHCE.CreatedBy = Convert.ToString(Session["username"]);
        objDAHCE.UpdatedBy = Convert.ToString(Session["username"]);
        objDAHCE.FId = Convert.ToInt32(Session["FId"]); ;
        objDAHCE.BranchId = Convert.ToInt32(Session["Branchid"]);

        objBLLHCE.InsertHIVCounter(objDAHCE);
        LblMSg.Text = "Record save successfully.!";
        LblMSg.ForeColor = System.Drawing.Color.Green;
        BindHIVEncounter();
        Clear();
    }
    public void Clear()
    {
        txtageoffirstchild.Text = "";
        txtageoflastchild.Text = "";
        txtComment.Text = "";
        txtnumberofchildren.Text = "";
        txtnumberofpartner.Text = "";
        txtnumwives.Text = "";
    }
    private void BindHIVEncounter()
    {
        if (Convert.ToString(Session["EmrOpdNo"]) != "")
        {
            objDAHCE.OpdNo = Convert.ToInt32(Session["EmrOpdNo"]);
        }
        else
        {
            objDAHCE.OpdNo = 0;
        }
        if (Convert.ToString(Session["EmrIpdNo"]) != "")
        {
            objDAHCE.IpdNo = Convert.ToInt32(Session["EmrIpdNo"]);
        }
        else
        {
            objDAHCE.IpdNo = 0;
        }
        objDAHCE.Patregid = Convert.ToString(Session["EmrRegNo"]);
        objDAHCE.CreatedBy = Convert.ToString(Session["username"]);
        objDAHCE.UpdatedBy = Convert.ToString(Session["username"]);
        objDAHCE.FId = Convert.ToInt32(Session["FId"]); ;
        objDAHCE.BranchId = Convert.ToInt32(Session["Branchid"]);
        tempDatatable = objBLLHCE.GetAllHIVCounter(objDAHCE);
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
        BindHIVEncounter();
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