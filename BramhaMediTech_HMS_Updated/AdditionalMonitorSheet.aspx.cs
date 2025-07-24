using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class AdditionalMonitorSheet : BasePage
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
                txttimestart.Text = DateTime.Now.ToString("dd/MM/yyyy");
                String s = time.ToString("hh:mm tt");
                txtTime.Text = s;
                //DateTime time = DateTime.Now;
                //txttimestart.Text = DateTime.Now.ToString("dd/MM/yyyy");
                //String s = time.ToString("hh:mm tt");
                //txtTime.Text = s;
                //txtEndTime.Text = s;
                BindPatientInformation();
              //  txtNurse.Text = Convert.ToString(Session["Name"]);
                BindDailyNurseNotes();
                txttimestart.Enabled = false;
                txtTime.Enabled = false;
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
        dt = objDALIO.GetAdditionalVitalSheet(objBELIO);
        gvDailyNurseNote.DataSource = dt;
        gvDailyNurseNote.DataBind();
        ClearData();
    }
    public void ClearData()
    {
        txtBloodPressure.Text = "";
     
        txtContractions.Text = "";
        txtBloodSugar.Text = "";
      
        txtFHR.Text = "";
        txtMISC.Text = "";
        txtPulse.Text = "";
        txtRemark.Text = "";
        txtRespRate.Text = "";
        txtspo2.Text = "";
        txtTemp.Text = "";
        txtUrinaryoutput.Text = "";
        txtnameposi.Text = "";
        
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
        if (Convert.ToString(Session["Branchid"]) == null)
        {
            Response.Redirect("~/Login.aspx", false);
            return;
        }
        //if (txtSystolic.Text == "")
        //{
        //    txtSystolic.Text = "0";
        //}
        //if (txtDiastolic.Text == "")
        //{
        //    txtDiastolic.Text = "0";
        //}
        // if (txtHr.Text == "")
        //{
        //    txtHr.Text = "0";
        //}
       
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

        objBELIO.DateInput = Convert.ToDateTime(txttimestart.Text);
        objBELIO.TimeInput = Convert.ToString(txtTime.Text);

        objBELIO.BloodPRessure = txtBloodPressure.Text;
        objBELIO.Temp = txtTemp.Text;
        objBELIO.Pulse = txtPulse.Text;
        objBELIO.RespRate = txtRespRate.Text;
        objBELIO.Spo2 = txtRespRate.Text;
        objBELIO.BloodSugar = txtBloodSugar.Text;
        objBELIO.UrinaryOutput = txtUrinaryoutput.Text;
        objBELIO.FHR = txtFHR.Text;
        objBELIO.MISC = txtMISC.Text;
        objBELIO.Contractions = txtContractions.Text;
        objBELIO.NamePosition = txtnameposi.Text;      

        objBELIO.VitalRemark = txtRemark.Text;       

        string Msg;
        if (Convert.ToInt32(ViewState["VId"]) > 0)
        {
            objBELIO.VId = Convert.ToInt32(ViewState["VId"]);
            Msg = objDALIO.Insert_AdditionalMonitorSheet(objBELIO);
            ViewState["VId"] = "0";
        }
        else
        {
            objBELIO.PhId = 0;
            Msg = objDALIO.Insert_AdditionalMonitorSheet(objBELIO);
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
        string IVChartId = (gvDailyNurseNote.DataKeys[e.RowIndex]["VId"].ToString());


        string Message = objDALIO.DeleteIVChart(Convert.ToInt32(IVChartId));
        LblMSg.Text = Message;
        LblMSg.ForeColor = System.Drawing.Color.Green;
        BindDailyNurseNotes();


    }
    protected void gvDailyNurseNote_RowEditing(object sender, GridViewEditEventArgs e)
    {

        try
        {
            string VId = (gvDailyNurseNote.DataKeys[e.NewEditIndex]["VId"].ToString());
            ViewState["VId"] = VId;
            txttimestart.Enabled = false;
            txtTime.Enabled = false;
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
        objBELIO = objDALIO.GetVitalSheet(Convert.ToInt32(ViewState["VId"]), Convert.ToInt32(Session["Branchid"]), Convert.ToInt32(Session["FId"]));
        //txttimestart.Text = Convert.ToDateTime(objBELIO.DateInput).ToString("dd/MM/yyyy");
        //txtTime.Text = Convert.ToString(objBELIO.TimeInput);
        
        //txtNurse.Text = objBELIO.UserName;
        //===============================================
        //txttimestart.Text = Convert.ToDateTime(objBELIO.DateInput).ToString("dd/MM/yyyy");
        //txtTime.Text = Convert.ToString(objBELIO.TimeInput);
        //txtTemprature.Text = objBELIO.Temprature;

        //txtbp.Text = objBELIO.BPVital;
        //txtHr.Text = objBELIO.HR;
        //txtrr.Text = objBELIO.RR;
        //txtspo2.Text = objBELIO.Spo2;
        //txtInspired.Text = objBELIO.Inspired;

        //txtrrScore.Text = objBELIO.RRScore;
        //txturinescore.Text = objBELIO.UrineScore;

        //txtCnsScore.Text = objBELIO.CNScore;
        //txtRemark.Text = objBELIO.VitalRemark;
        //txtSystolic.Text = objBELIO.Systolic;
        //txtDiastolic.Text = objBELIO.Diastolic;
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
    protected void gvDailyNurseNote_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
           string Systolic= e.Row.Cells[6].Text;
           string Diastolic = e.Row.Cells[7].Text;
           string HR = e.Row.Cells[8].Text;

            //if (Convert.ToSingle(Systolic) > 170 || Convert.ToSingle(Systolic)<110)
            //{
            //    e.Row.Cells[6].ForeColor = System.Drawing.Color.Red;
            //    e.Row.Cells[6].Font.Bold = true; ;
            //   // e.Row.Cells[5]. = System.Drawing.Color.Red;
            //}
            //if (Convert.ToSingle(Diastolic) > 80 || Convert.ToSingle(Diastolic) < 50)
            //{
            //    e.Row.Cells[7].ForeColor = System.Drawing.Color.Red;
            //    e.Row.Cells[7].Font.Bold = true; ;
            //    // e.Row.Cells[5]. = System.Drawing.Color.Red;
            //}
            //if (HR != "")
            //{
            //    if (HR != "&nbsp;")
            //    {
            //        if (Convert.ToSingle(HR) > 120)
            //        {
            //            e.Row.Cells[8].ForeColor = System.Drawing.Color.Red;
            //            e.Row.Cells[8].Font.Bold = true; ;
            //            // e.Row.Cells[5]. = System.Drawing.Color.Red;
            //        }
            //    }
            //}

        }
    }
}