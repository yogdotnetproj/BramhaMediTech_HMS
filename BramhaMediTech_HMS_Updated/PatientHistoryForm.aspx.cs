using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class PatientHistoryForm : BasePage
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
                //lblOpd.Text = opd;
                //DateTime time = DateTime.Now;
                //txttimestart.Text = DateTime.Now.ToString("dd/MM/yyyy");
                //String s = time.ToString("hh:mm tt");
                //txtTime.Text = s;
                //txtEndTime.Text = s;
                BindPatientInformation();
              //  txtNurse.Text = Convert.ToString(Session["Name"]);
                BindDailyNurseNotes();
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
        dt = objDALIO.GetPatientHistory(objBELIO);
        gvDailyNurseNote.DataSource = dt;
        gvDailyNurseNote.DataBind();
        ClearData();
    }
    public void ClearData()
    {
        txtalcoholdura.Text = "";
        txtalcoholqty.Text = "";
        txtallergiesHistory.Text = "";
        txtcaseno.Text = "";
        txtfamilyHistory.Text = "";
        txtGynaeHis.Text = "";
        txtmedicalhis.Text = "";
        txtmedication.Text = "";
        txtsmokeduration.Text = "";
        txtsurgicalhistory.Text = "";
        
    }
    public void BindPatientInformation()
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
        //        lblOpd.Text = Convert.ToString(dt.Rows[0]["Opdno"]);
        //        lblMobileNo.Text = Convert.ToString(dt.Rows[0]["MobileNo"]);
        //        lbldrname.Text = Convert.ToString(dt.Rows[0]["DrName"]);
        //        lblAge.Text = Convert.ToString(dt.Rows[0]["Age"]) + "" + Convert.ToString(dt.Rows[0]["AgeType"]) + "/" + Convert.ToString(dt.Rows[0]["GenderName"]);
        //        ViewState["Age"] = Convert.ToString(dt.Rows[0]["Age"]);
        //        ViewState["AgeType"] = Convert.ToString(dt.Rows[0]["AgeType"]);
        //        ViewState["DrId"] = Convert.ToString(dt.Rows[0]["DrId"]);

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

        //objBELIO.CaseNo = txtcaseno.Text;
        //objBELIO.DrId = Convert.ToInt32(ViewState["DrId"]);
        if (chkMedicalHistory.Checked == true)
        {
            objBELIO.CheckMedHis = true;
        }
        else
        {
            objBELIO.CheckMedHis = false;
        }
        objBELIO.MedHis = txtmedicalhis.Text;

        if (chkmedication.Checked == true)
        {
            objBELIO.CheckMedication = true;
        }
        else
        {
            objBELIO.CheckMedication = false;
        }
        objBELIO.Medication = txtmedication.Text;

        if (chksurghis.Checked == true)
        {
            objBELIO.Checksurghis = true;
        }
        else
        {
            objBELIO.Checksurghis = false;
        }
        objBELIO.surghis = txtsurgicalhistory.Text;

        if (chkGynae.Checked == true)
        {
            objBELIO.CheckGyna = true;
        }
        else
        {
            objBELIO.CheckGyna = false;
        }
        objBELIO.Gyna = txtGynaeHis.Text;

        if (chkallergies.Checked == true)
        {
            objBELIO.CheckAllergy = true;
        }
        else
        {
            objBELIO.CheckAllergy = false;
        }
        objBELIO.Allergy = txtallergiesHistory.Text;

        if (chkSmoking.Checked == true)
        {
            objBELIO.Checksmoking = true;
        }
        else
        {
            objBELIO.Checksmoking = false;
        }
        objBELIO.smokingDurat = txtsmokeduration.Text;
        objBELIO.smokingQty = txsmoketqty.Text;

        if (chkalcohol.Checked == true)
        {
            objBELIO.CheckAlco = true;
        }
        else
        {
            objBELIO.CheckAlco = false;
        }
        objBELIO.AlcoDurat = txtalcoholdura.Text;
        objBELIO.AlcoQty = txtalcoholqty.Text;     
      

        string Msg;
        if (Convert.ToInt32(ViewState["PhId"]) > 0)
        {
            objBELIO.PhId = Convert.ToInt32(ViewState["PhId"]);
            Msg = objDALIO.InsertPatientHisForm(objBELIO);
            ViewState["PhId"] = "0";
        }
        else
        {
            objBELIO.PhId = 0; 
            Msg = objDALIO.InsertPatientHisForm(objBELIO);
        }

        BindDailyNurseNotes();

      
        //DateTime time = DateTime.Now;
        //txttimestart.Text = DateTime.Now.ToString("dd/MM/yyyy");
        //String s = time.ToString("hh:mm tt");
        //txtTime.Text = s;
        //txtEndTime.Text = s;
        LblMSg.Text = Msg;
        LblMSg.ForeColor = System.Drawing.Color.Green;



        //}
        //}
    }
    protected void gvDailyNurseNote_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string IVChartId = (gvDailyNurseNote.DataKeys[e.RowIndex]["PhId"].ToString());


        string Message = objDALIO.DeleteIVChart(Convert.ToInt32(IVChartId));
        LblMSg.Text = Message;
        LblMSg.ForeColor = System.Drawing.Color.Green;
        BindDailyNurseNotes();


    }
    protected void gvDailyNurseNote_RowEditing(object sender, GridViewEditEventArgs e)
    {

        try
        {
            string IVChartId = (gvDailyNurseNote.DataKeys[e.NewEditIndex]["PhId"].ToString());
            ViewState["PhId"] = IVChartId;
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
        objBELIO = objDALIO.GetPHF(Convert.ToInt32(ViewState["PhId"]) ,Convert.ToInt32(Session["Branchid"]), Convert.ToInt32(Session["FId"]));
        //txttimestart.Text = Convert.ToDateTime(objBELIO.DateInput).ToString("dd/MM/yyyy");
        //txtTime.Text = Convert.ToString(objBELIO.TimeInput);
        
        //txtNurse.Text = objBELIO.UserName;
        //===============================================
        if (objBELIO.CheckMedHis == true)
        {
            chkMedicalHistory.Checked = true;
        }
        else
        {
            chkMedicalHistory.Checked = false;
        }
       txtmedicalhis.Text= objBELIO.MedHis ;

        if (objBELIO.CheckMedication == true)
        {
            chkmedication.Checked = true;
        }
        else
        {
            chkmedication.Checked = false;
        }
       txtmedication.Text= objBELIO.Medication ;

        if (objBELIO.Checksurghis == true)
        {
            chksurghis.Checked = true;
        }
        else
        {
            chksurghis.Checked = false;
        }
        txtsurgicalhistory.Text=objBELIO.surghis;

        if (objBELIO.CheckGyna == true)
        {
            chkGynae.Checked = true;
        }
        else
        {
            chkGynae.Checked = false;
        }
       txtGynaeHis.Text= objBELIO.Gyna ;

        if (objBELIO.CheckAllergy == true)
        {
            chkallergies.Checked = true;
        }
        else
        {
            chkallergies.Checked = false;
        }
        txtallergiesHistory.Text=objBELIO.Allergy  ;

        if (objBELIO.Checksmoking == true)
        {
            chkSmoking.Checked = true;
        }
        else
        {
            chkSmoking.Checked = false;
        }
       txtsmokeduration.Text= objBELIO.smokingDurat ;
       txsmoketqty.Text= objBELIO.smokingQty ;

        if (objBELIO.CheckAlco == true)
        {
            chkalcohol.Checked = true;
        }
        else
        {
            chkalcohol.Checked = false;
        }
       txtalcoholdura.Text= objBELIO.AlcoDurat  ;
       txtalcoholqty.Text= objBELIO.AlcoQty  ;     

       // int UserId = Convert.ToInt32(objBELIO.UserId);

    }

    protected void gvDailyNurseNote_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDailyNurseNote.PageIndex = e.NewPageIndex;
        BindDailyNurseNotes();
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        
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
        objDALIO.Alter_Vw_PatientHistory(objBELIO);
        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Report/Rpt_PatientHisForm.rpt");
        Session["reportname"] = "Rpt_PatientHisForm";
        Session["RPTFORMAT"] = "pdf";

        //ReportParameterClass.SelectionFormula = sql;
        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);
    }
}