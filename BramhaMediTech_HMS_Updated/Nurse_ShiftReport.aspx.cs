using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Nurse_ShiftReport : System.Web.UI.Page
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
        dt = objDALIO.FillNurseShift(objBELIO);
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

        objBELIO.CurrentComplaint = Convert.ToString(txtCurrent.Text);
        objBELIO.AdmissionDiagnosis = Convert.ToString(txtAdmDiagnosis.Text);
        objBELIO.T = Convert.ToString(txtTem.Text);
        objBELIO.P = Convert.ToString(txtPulse.Text);
        objBELIO.R = Convert.ToString(txtR.Text);
        objBELIO.BP = Convert.ToString(txtBP.Text);

        objBELIO.SPO2 = Convert.ToString(txtspo2.Text);
        objBELIO.RA = Convert.ToString(txtrao.Text);
        objBELIO.LOC = Convert.ToString(txtLoC.Text);
        objBELIO.RBS = Convert.ToString(txtRBS.Text);

        objBELIO.Diet = Convert.ToString(txtDiet.Text);
        if (chkFullCode.Checked == true)
        {
            objBELIO.FullCode = true;
        }
        else
        {
            objBELIO.FullCode = false;
        }

        if (ChkConfort.Checked == true)
        {
            objBELIO.ComfortMeasures = true;
        }
        else
        {
            objBELIO.ComfortMeasures = false;
        }
        if (ChkDNR.Checked == true)
        {
            objBELIO.DNR = true;
        }
        else
        {
            objBELIO.DNR = false;
        }
        if (ChkDm.Checked == true)
        {
            objBELIO.PDM = true;
        }
        else
        {
            objBELIO.PDM = false;
        }
        if (ChkHTN.Checked == true)
        {
            objBELIO.PHTN = true;
        }
        else
        {
            objBELIO.PHTN = false;
        }
        if (ChkCancer.Checked == true)
        {
            objBELIO.PCancer = true;
        }
        else
        {
            objBELIO.PCancer = false;
        }
        objBELIO.PastMedicalHistory = Convert.ToString(txtpastmedicalHistory.Text);
        objBELIO.Allergies = Convert.ToString(txtAllergies.Text);
        objBELIO.PastSurgeryHistory = Convert.ToString(txtPastsurgeryHistory.Text);
        if (ChkDMF.Checked == true)
        {
            objBELIO.FDM = true;
        }
        else
        {
            objBELIO.FDM = false;
        }
        if (CHKHTNF.Checked == true)
        {
            objBELIO.FHTN = true;
        }
        else
        {
            objBELIO.FHTN = false;
        }
        if (ChkCancerF.Checked == true)
        {
            objBELIO.FCancer = true;
        }
        else
        {
            objBELIO.FCancer = false;
        }

        objBELIO.FamilyHistory = Convert.ToString(txtFamilyHistory.Text);
        if (ChkSmoker.Checked == true)
        {
            objBELIO.Smoker = true;
        }
        else
        {
            objBELIO.Smoker = false;
        }
        objBELIO.SmokerRemark = Convert.ToString(txtSmoker.Text);

        if (ChkAlcohol.Checked == true)
        {
            objBELIO.Alcohol = true;
        }
        else
        {
            objBELIO.Alcohol = false;
        }
        objBELIO.AlcoholRemark = Convert.ToString(txtAlcohol.Text);

        if (ChkDruguse.Checked == true)
        {
            objBELIO.Druguse = true;
        }
        else
        {
            objBELIO.Druguse = false;
        }
        objBELIO.DruguseRemark = Convert.ToString(txtdrugUSe.Text);

        objBELIO.OtherRemark = Convert.ToString(txtOther.Text);
        objBELIO.Medications = Convert.ToString(txtMedications.Text);
        objBELIO.IVSite = Convert.ToString(txtIVSite.Text);
        objBELIO.DrainsCatheters = Convert.ToString(txtDrainsCatheters.Text);
        objBELIO.Proceduress = Convert.ToString(txtProceduresdone.Text);
        objBELIO.AbnormalAssessments = Convert.ToString(txtAbnormalAssessment.Text);

        objBELIO.PainScore = Convert.ToString(txtPainscore.Text);
        objBELIO.Intervention = Convert.ToString(txtIntervention.Text);
        objBELIO.Safetys = Convert.ToString(txtSafety.Text);

        objBELIO.RecommendationNeeded = Convert.ToString(txtneededchanges.Text);
        objBELIO.RecommendationConcerned = Convert.ToString(txtConcerned.Text);
        objBELIO.PendingLabs = Convert.ToString(txtPendingLab.Text);
        objBELIO.AwareofNext = Convert.ToString(txtnextshiftaware.Text);

        objBELIO.UserId = Convert.ToInt32(Session["UserId"]);
       
        string Msg;
        if (Convert.ToInt32(ViewState["NurseNoteId"]) > 0)
        {
            objBELIO.NurseNoteId = Convert.ToInt32(ViewState["NurseNoteId"]);
            Msg = objDALIO.UpdateDailyNurseNote(objBELIO);
            ViewState["NurseNoteId"] = "0";
        }
        else
        {
            Msg = objDALIO.Insert_NurseShiftReport(objBELIO);
        }
       
        BindDailyNurseNotes();

        //txtRemark.InnerText = "";
        //DateTime time = DateTime.Now;
        //txttimestart.Text = DateTime.Now.ToString("dd/MM/yyyy");
        //String s = time.ToString("hh:mm tt");
        //txtTime.Text = s;           
        LblMSg.Text = Msg;
        LblMSg.ForeColor = System.Drawing.Color.Green;

        txtAbnormalAssessment.Text = "";
        txtAdmDiagnosis.Text = "";
        txtAlcohol.Text = "";
        txtAllergies.Text = "";
        txtBP.Text = "";
        txtConcerned.Text = "";
        txtCurrent.Text = "";
        txtDiet.Text = "";
        txtDrainsCatheters.Text = "";
        txtdrugUSe.Text = "";
        txtFamilyHistory.Text = "";
        txtIntervention.Text = "";
        txtIVSite.Text = "";
        txtLoC.Text = "";
        txtMedications.Text = "";
        txtneededchanges.Text = "";
        txtnextshiftaware.Text = "";
        txtOther.Text = "";
        txtPainscore.Text = "";
        txtpastmedicalHistory.Text = "";
        txtPastsurgeryHistory.Text = "";
        txtPendingLab.Text = "";
        txtProceduresdone.Text = "";
        txtPulse.Text = "";
        txtR.Text = "";
        txtrao.Text = "";
        txtRBS.Text = "";
        txtSafety.Text = "";
        txtSmoker.Text = "";
        txtspo2.Text = "";
        txtTem.Text = "";
        


        //}
        //}
    }
    protected void gvDailyNurseNote_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string ShiftId = (gvDailyNurseNote.DataKeys[e.RowIndex]["ShiftId"].ToString());


        string Message = objDALIO.Delete_NurseShift(Convert.ToInt32(ShiftId));
        LblMSg.Text = Message;
        LblMSg.ForeColor = System.Drawing.Color.Green;
        BindDailyNurseNotes();


    }
    protected void gvDailyNurseNote_RowEditing(object sender, GridViewEditEventArgs e)
    {
        
        try
        {
            string ShiftId = (gvDailyNurseNote.DataKeys[e.NewEditIndex]["ShiftId"].ToString());
            ViewState["ShiftId"] = ShiftId;
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
        objDALIO.Alter_NurseShiftList(objBELIO);
        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Report/Rpt_NurseShiftReport.rpt");
        Session["reportname"] = "NurseShiftReport";
        Session["RPTFORMAT"] = "pdf";

        //ReportParameterClass.SelectionFormula = sql;
        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);
    }
    protected void gvDailyNurseNote_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Report")
        {

            //Determine the RowIndex of the Row whose Button was clicked.
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            //Reference the GridView Row.
            GridViewRow row = gvDailyNurseNote.Rows[rowIndex];
            objBELIO.ShiftId = Convert.ToInt32(gvDailyNurseNote.DataKeys[rowIndex].Values["ShiftId"]);
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
            objDALIO.Alter_NurseShiftList(objBELIO);
            Session.Add("rptsql", sql);
            Session["rptname"] = Server.MapPath("~/Report/Rpt_NurseShiftReport.rpt");
            Session["reportname"] = "NurseShiftReport";
            Session["RPTFORMAT"] = "pdf";

            //ReportParameterClass.SelectionFormula = sql;
            string close = "<script language='javascript'>javascript:OpenReport();</script>";
            Type title1 = this.GetType();
            Page.ClientScript.RegisterStartupScript(title1, "", close);
           
        }
    }
}