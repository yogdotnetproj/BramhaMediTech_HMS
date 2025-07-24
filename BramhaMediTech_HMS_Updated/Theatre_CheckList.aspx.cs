using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Theatre_CheckList : BasePage
{
    clsEmr obj = new clsEmr();
    clsTreatment objTreat = new clsTreatment();
    clsTreatmentTransaction transaction = new clsTreatmentTransaction();
    BELIntakeOutputChart objBELIO = new BELIntakeOutputChart();
    DALInputOutPutChart objDALIO = new DALInputOutPutChart();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
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
            if (Session["EmrRegNo"] != "")
            {
                string regId = Convert.ToString(Session["EmrRegNo"]);
                string name = Request.QueryString["Name"];
                string opd = Convert.ToString(Session["EmrOpdNo"]);
                string entrydate = Request.QueryString["EntryDate"];
                int IpdId = Convert.ToInt32(Session["EmrIpdNo"]);
                objBELIO.FId = Convert.ToInt32(Session["FId"]);
                objBELIO.BranchId = Convert.ToInt32(Session["Branchid"]);
               // lblOpd.Text = opd;
                DateTime time = DateTime.Now;
              //  txttimestart.Text = DateTime.Now.ToString("dd/MM/yyyy");
                //String s = time.ToString("hh:mm tt");
                //txtTime.Text = s;               
                BindPatientInformation();
               // txtNurse.Text = Convert.ToString(Session["Name"]);
                BindDailyNurseNotes();
              //  txttimestart.Enabled = false;
               // txtTime.Enabled = false;
            }
        }
    }

    public void BindDailyNurseNotes()
    {
        DataTable dt = new DataTable();
        objBELIO.Patregid = Convert.ToInt32(Session["EmrRegNo"]);
        objBELIO.OpdNo = Convert.ToInt32(Session["EmrOpdNo"]);
        string entrydate = Request.QueryString["EntryDate"];
        objBELIO.IpdNo = Convert.ToInt32(Session["EmrIpdNo"]);
        objBELIO.FId = Convert.ToInt32(Session["FId"]);
        objBELIO.BranchId = Convert.ToInt32(Session["Branchid"]);
        dt = objDALIO.Fill_Theatre_CheckList(objBELIO);
        gvDailyNurseNote.DataSource = dt;
        gvDailyNurseNote.DataBind();
    }
    public void BindPatientInformation()
    {
        
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        //if (validation() == true)
        //{
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
        if (Convert.ToString(Session["EmrOpdNo"]) != "")
        {
            objBELIO.OpdNo = Convert.ToInt32(Session["EmrOpdNo"]);
        }
        else
        {
            objBELIO.OpdNo = 0;
        }
        if (Convert.ToString(Session["EmrIpdNo"]) != "")
        {
            objBELIO.IpdNo = Convert.ToInt32(Session["EmrIpdNo"]);
            if (Convert.ToString(Session["PatAdmit"]) == "No")
            {
                LblMSg.ForeColor = System.Drawing.Color.Red;
                LblMSg.Text = "Patient already discharge!";
                return;
            }
        }
        else
        {
            objBELIO.IpdNo = 0;
        }
        objBELIO.Patregid = Convert.ToInt32(Session["EmrRegNo"]);
        objBELIO.CreatedBy = Convert.ToString(Session["username"]);
        objBELIO.UpdatedBy = Convert.ToString(Session["username"]);
        objBELIO.FId = Convert.ToInt32(Session["FId"]); ;
        objBELIO.BranchId = Convert.ToInt32(Session["Branchid"]);
        //objBELIO.DrId = Convert.ToInt32(ViewState["DrId"]);
        //objBELIO.DateInput = Convert.ToDateTime(txttimestart.Text);
        //objBELIO.TimeInput = Convert.ToString(txtTime.Text);
        //objBELIO.Remark = Convert.ToString(txtRemark.InnerText);

        objBELIO.Allergies = Convert.ToString(txtAllergies.Text);

        if (ChkSignedConsent.Checked ==true)
        {
            objBELIO.SignconsentForm = true;
        }
        else
        {
            objBELIO.SignconsentForm = false;
        }
        if (ChkNameLabel.Checked == true)
        {
            objBELIO.NameLabels = true;
        }
        else
        {
            objBELIO.NameLabels = false;
        }
        if (ChkBloodWorksReq.Checked == true)
        {
            objBELIO.BloodWork = true;
        }
        else
        {
            objBELIO.BloodWork = false;
        }
        if (ChkIVAccess.Checked == true)
        {
            objBELIO.IVAccess = true;
        }
        else
        {
            objBELIO.IVAccess = false;
        }
        if (ChkIVAntibiotic.Checked == true)
        {
            objBELIO.IVAntiBiotics = true;
        }
        else
        {
            objBELIO.IVAntiBiotics = false;
        }


        if (ChkPainSuppoistory.Checked == true)
        {
            objBELIO.PainSupposotory = true;
        }
        else
        {
            objBELIO.PainSupposotory = false;
        }
        if (ChkDENTURES.Checked == true)
        {
            objBELIO.DENTURES = true;
        }
        else
        {
            objBELIO.DENTURES = false;
        }
        if (ChkChHairClip.Checked == true)
        {
            objBELIO.HAIRCLIPS = true;
        }
        else
        {
            objBELIO.HAIRCLIPS = false;
        }
        if (ChkJEWELLERY.Checked == true)
        {
            objBELIO.JEWELLERY = true;
        }
        else
        {
            objBELIO.JEWELLERY = false;
        }
        if (ChkUnderwear.Checked == true)
        {
            objBELIO.UNDERWEAR = true;
        }
        else
        {
            objBELIO.UNDERWEAR = false;
        }
        if (ChkPROSTHESIS.Checked == true)
        {
            objBELIO.PROSTHESIS = true;
        }
        else
        {
            objBELIO.PROSTHESIS = false;
        }
        if (ChkSPECTACLES.Checked == true)
        {
            objBELIO.SPECTACLES = true;
        }
        else
        {
            objBELIO.SPECTACLES = false;
        }
        if (ChkVitals.Checked == true)
        {
            objBELIO.VitalSigns = true;
        }
        else
        {
            objBELIO.VitalSigns = false;
        }
        if (ChkUrinanalysis.Checked == true)
        {
            objBELIO.UrinAnalysis = true;
        }
        else
        {
            objBELIO.UrinAnalysis = false;
        }
        if (ChkTreatmentSheet.Checked == true)
        {
            objBELIO.TreatmentSheet = true;
        }
        else
        {
            objBELIO.TreatmentSheet = false;
        }

        if (ChkIVFluid.Checked == true)
        {
            objBELIO.IVFluids = true;
        }
        else
        {
            objBELIO.IVFluids = false;
        }
        if (ChkXray.Checked == true)
        {
            objBELIO.ECG = true;
        }
        else
        {
            objBELIO.ECG = false;
        }
        if (ChkOrthopaedic.Checked == true)
        {
            objBELIO.Orthopaedic = true;
        }
        else
        {
            objBELIO.Orthopaedic = false;
        }
        objBELIO.Remark = Convert.ToString(txtRemarks.Text);
        objBELIO.UserId = Convert.ToInt32(Session["UserId"]);
       
        string Msg;
        if (Convert.ToInt32(ViewState["TCheckId"]) > 0)
        {
            objBELIO.TCheckId = Convert.ToInt32(ViewState["TCheckId"]);
            Msg = objDALIO.UpdateDailyNurseNote(objBELIO);
            ViewState["TCheckId"] = "0";
        }
        else
        {
            Msg = objDALIO.Insert_TheatreCheckList(objBELIO);
        }
       
        BindDailyNurseNotes();

        //txtRemark.InnerText = "";
        //DateTime time = DateTime.Now;
        //txttimestart.Text = DateTime.Now.ToString("dd/MM/yyyy");
        //String s = time.ToString("hh:mm tt");
        //txtTime.Text = s;           
        LblMSg.Text = Msg;
        LblMSg.ForeColor = System.Drawing.Color.Green;



        //}
        //}
    }
    protected void gvDailyNurseNote_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string TCheckId = (gvDailyNurseNote.DataKeys[e.RowIndex]["TCheckId"].ToString());


        string Message = objDALIO.Delete_TheatreCheckListe(Convert.ToInt32(TCheckId));
        LblMSg.Text = Message;
        LblMSg.ForeColor = System.Drawing.Color.Green;
        BindDailyNurseNotes();


    }
    protected void gvDailyNurseNote_RowEditing(object sender, GridViewEditEventArgs e)
    {
        
        try
        {
            string TCheckId = (gvDailyNurseNote.DataKeys[e.NewEditIndex]["TCheckId"].ToString());
            ViewState["TCheckId"] = TCheckId;
            FillPage();
            e.Cancel = true;
        }
        catch (Exception ex)
        {
            LblMSg.Text = ex.Message;
        }
    }

    public void FillPage()
    {
        //objBELIO = objDALIO.SelectDailyNurseNote(Convert.ToInt32(ViewState["NurseNoteId"]));
        //txttimestart.Text = Convert.ToDateTime(objBELIO.DateInput).ToString("dd/MM/yyyy");
        //txtTime.Text = Convert.ToString(objBELIO.TimeInput);
        //txtRemark.InnerText = objBELIO.Remark;
        //txtNurse.Text = objBELIO.UserName;
        //int UserId = Convert.ToInt32(objBELIO.UserId);

    }

    protected void gvDailyNurseNote_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDailyNurseNote.PageIndex = e.NewPageIndex;
        BindDailyNurseNotes();
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        //txtRemark.InnerText = "";
        //DateTime time = DateTime.Now;
        //txttimestart.Text = DateTime.Now.ToString("dd/MM/yyyy");
        //String s = time.ToString("hh:mm tt");
        //txtTime.Text = s;         
    }
    protected void btnReport_Click(object sender, EventArgs e)
    {
        string sql = "";
        if (Convert.ToString(Session["EmrOpdNo"]) != "")
        {
            objBELIO.OpdNo = Convert.ToInt32(Session["EmrOpdNo"]);
        }
        else
        {
            objBELIO.OpdNo = 0;
        }
        if (Convert.ToString(Session["EmrIpdNo"]) != "")
        {
            objBELIO.IpdNo = Convert.ToInt32(Session["EmrIpdNo"]);
        }
        else
        {
            objBELIO.IpdNo = 0;
        }
        objBELIO.Patregid = Convert.ToInt32(Session["EmrRegNo"]);
        objDALIO.Alter_Vw_Theatre_CheckList(objBELIO);
        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Report/Rpt_Theatre_CheckList.rpt");
        Session["reportname"] = "Theatre_CheckList";
        Session["RPTFORMAT"] = "pdf";

        //ReportParameterClass.SelectionFormula = sql;
        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);
    }
}