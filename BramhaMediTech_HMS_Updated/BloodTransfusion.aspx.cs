using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class BloodTransfusion :BasePage
{
    clsEmr obj = new clsEmr();
    clsTreatment objTreat = new clsTreatment();
    clsTreatmentTransaction transaction = new clsTreatmentTransaction();
    BELIntakeOutputChart objBELIO = new BELIntakeOutputChart();
    DALInputOutPutChart objDALIO = new DALInputOutPutChart();
    DALOpdReg objDALOpdReg = new DALOpdReg();
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
                lblOpd.Text = opd;
                DateTime time = DateTime.Now;
                txttimestart.Text = DateTime.Now.ToString("dd/MM/yyyy");
                String s = time.ToString("hh:mm tt");
                txtTime.Text = s;
                BindNurseDropDown();
                BindPatientInformation();
                //txtNurse.Text = Convert.ToString(Session["Name"]);
                //LoadConsultantDoc();
                BindBloodTransfusion();

            //DateTime dt = DateTime.Parse("12:35 PM");
            //MKB.TimePicker.TimeSelector.AmPmSpec am_pm;
            //if (dt.ToString("tt") == "AM")
            //{
            //    am_pm = MKB.TimePicker.TimeSelector.AmPmSpec.AM;
            //}
            //else
            //{
            //    am_pm = MKB.TimePicker.TimeSelector.AmPmSpec.PM;
            //}
            //txtTime.SetTime(dt.Hour, dt.Minute, am_pm);
        
            }
        }
    }
    public void BindNurseDropDown()
    {
        ddlCheckedBy.DataSource = objDALIO.FillNurse();
        ddlCheckedBy.DataValueField = "CUId";
        ddlCheckedBy.DataTextField = "Name";
        ddlCheckedBy.DataBind();

        ddlStartedBy.DataSource = objDALIO.FillNurse();
        ddlStartedBy.DataValueField = "CUId";
        ddlStartedBy.DataTextField = "Name";
        ddlStartedBy.DataBind();
        
        
           

    }
    public void BindBloodTransfusion()
    {
        DataTable dt = new DataTable();
        objBELIO.Patregid = Convert.ToInt32(Session["EmrRegNo"]);
        objBELIO.OpdNo = Convert.ToInt32(Session["EmrOpdNo"]);
        string entrydate = Request.QueryString["EntryDate"];
        objBELIO.IpdNo = Convert.ToInt32(Session["EmrIpdNo"]);
        objBELIO.FId = Convert.ToInt32(Session["FId"]);
        objBELIO.BranchId = Convert.ToInt32(Session["Branchid"]);
        dt = objDALIO.FillBloodTransfusion(objBELIO);
        gvBloodTrans.DataSource = dt;
        gvBloodTrans.DataBind();
    }
    public void BindPatientInformation()
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
                lblOpd.Text = Convert.ToString(dt.Rows[0]["Opdno"]);
                lblMobileNo.Text = Convert.ToString(dt.Rows[0]["MobileNo"]);
                lbldrname.Text = Convert.ToString(dt.Rows[0]["DrName"]);
                lblAge.Text = Convert.ToString(dt.Rows[0]["Age"]) + "" + Convert.ToString(dt.Rows[0]["AgeType"]) + "/" + Convert.ToString(dt.Rows[0]["GenderName"]);
                ViewState["Age"] = Convert.ToString(dt.Rows[0]["Age"]);
                ViewState["AgeType"] = Convert.ToString(dt.Rows[0]["AgeType"]);
                ViewState["DrId"] = Convert.ToString(dt.Rows[0]["DrId"]);

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
        //if (validation() == true)
        //{

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
        objBELIO.CreatedBy = Convert.ToString(Session["username"]);
        objBELIO.UpdatedBy = Convert.ToString(Session["username"]);
        objBELIO.FId = Convert.ToInt32(Session["FId"]); ;
        objBELIO.BranchId = Convert.ToInt32(Session["Branchid"]);
        objBELIO.DrId = Convert.ToInt32(ViewState["DrId"]);
        objBELIO.UserId = Convert.ToInt32(Session["UserId"]);

        objBELIO.BloodGroup = ddlbloodGroup.SelectedValue;
        objBELIO.Indication = txtIndication.Text;
        if (ChkWholeBlood.Checked)
        {
            objBELIO.WholeBlood = true;
        }
        else
        {
            objBELIO.WholeBlood = false;
        }
        if (chkPackedCells.Checked)
            objBELIO.PacketCells = true;
        else
            objBELIO.PacketCells = false;

        if (ChkPlatelets.Checked)
            objBELIO.Platelets = true;
        else
            objBELIO.Platelets = false;
        if (Chkcryo.Checked)
            objBELIO.Cryoprecipitate = true;
        else
            objBELIO.Cryoprecipitate = false;
        if (Chkffp.Checked)
            objBELIO.FFP = true;
        else
            objBELIO.FFP = false;

        objBELIO.ConsentTaken = rdbConsent.SelectedValue;
        objBELIO.PremedicationOrder = rdbPreMedication.SelectedValue;
        objBELIO.DoctorOrder = rdbDocOrder.SelectedValue;
        objBELIO.PrevTransfusion = rdbPreTrans.SelectedValue;
        objBELIO.PrevTransReaction = rdbReaction.SelectedValue;
        

        objBELIO.DateInput = Convert.ToDateTime(txttimestart.Text);
       // DateTime time = DateTime.Parse(string.Format("{0}:{1}: {3}", txtTime.Hour, txtTime.Minute, txtTime.AmPm));
        objBELIO.TimeInput = Convert.ToString(txtTime.Text);
        objBELIO.UnitNo = Convert.ToString(txtUnit.Text);

        objBELIO.CheckedBy = Convert.ToInt32(ddlCheckedBy.SelectedValue);
        objBELIO.StartedBy = Convert.ToInt32(ddlStartedBy.SelectedValue);
        objBELIO.StartTime = Convert.ToString(txtStrtTime.Text);
        objBELIO.TimeS = Convert.ToString(txttime1.Text);
       
        objBELIO.Rate = Convert.ToString(txtRate.Text);
        objBELIO.T = Convert.ToString(txtT.Text);
        objBELIO.P = Convert.ToString(txtP.Text);
        objBELIO.R = Convert.ToString(txtR.Text);
        objBELIO.BP = Convert.ToString(txtBP.Text);
        objBELIO.FinishTime = Convert.ToString(txtFTime.Text);
        objBELIO.TRDetails = Convert.ToString(txtTransfusionReaction.Text);

        string Msg;
        if (Convert.ToInt32(ViewState["BloodTransId"]) > 0)
        {
            objBELIO.BloodTransId = Convert.ToInt32(ViewState["BloodTransId"]);
            Msg = objDALIO.UpdateBloodTransfusion(objBELIO);
            ViewState["BloodTransId"] = "0";
        }
        else
        {
            Msg = objDALIO.InsertBloodTransfusion(objBELIO);
        }

        BindBloodTransfusion();

        btnReset_Click(null, null);
       // txtRemark.InnerText = "";
        DateTime time = DateTime.Now;
        txttimestart.Text = DateTime.Now.ToString("dd/MM/yyyy");
        String s = time.ToString("hh:mm tt");
       txtTime.Text = s;
        LblMSg.Text = Msg;
        LblMSg.ForeColor = System.Drawing.Color.Green;

        

        //}
        //}
    }
    protected void gvBloodTrans_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string BloodTransId = (gvBloodTrans.DataKeys[e.RowIndex]["BloodTransId"].ToString());


        string Message = objDALIO.DeleteBloodTransfusion(Convert.ToInt32(BloodTransId));
        LblMSg.Text = Message;
        LblMSg.ForeColor = System.Drawing.Color.Green;
        BindBloodTransfusion();


    }
    protected void gvBloodTrans_RowEditing(object sender, GridViewEditEventArgs e)
    {

        try
        {
            string BloodTransId = (gvBloodTrans.DataKeys[e.NewEditIndex]["BloodTransId"].ToString());
            ViewState["BloodTransId"] = BloodTransId;
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
        objBELIO = objDALIO.SelectBloodTransfusion(Convert.ToInt32(ViewState["BloodTransId"]));
        txttimestart.Text = Convert.ToDateTime(objBELIO.DateInput).ToString("dd/MM/yyyy");
        txtTime.Text = Convert.ToString(objBELIO.TimeInput);

        ddlbloodGroup.SelectedValue = Convert.ToString(objBELIO.BloodGroup);
        txtIndication.Text = Convert.ToString(objBELIO.Indication);
        ChkWholeBlood.Checked = Convert.ToBoolean(objBELIO.WholeBlood);
        Chkcryo.Checked = Convert.ToBoolean(objBELIO.Cryoprecipitate);
        chkPackedCells.Checked = Convert.ToBoolean(objBELIO.PacketCells);
        Chkffp.Checked = Convert.ToBoolean(objBELIO.FFP);
        ChkPlatelets.Checked = Convert.ToBoolean(objBELIO.Platelets);

        rdbConsent.SelectedValue = Convert.ToString(objBELIO.ConsentTaken);
        rdbDocOrder.SelectedValue = Convert.ToString(objBELIO.DoctorOrder);
        rdbPreMedication.SelectedValue = Convert.ToString(objBELIO.PremedicationOrder);
        rdbPreTrans.SelectedValue = Convert.ToString(objBELIO.PrevTransfusion);
        rdbReaction.SelectedValue = Convert.ToString(objBELIO.PrevTransReaction);

        txtUnit.Text=Convert.ToString(objBELIO.UnitNo);

        ddlCheckedBy.SelectedValue = Convert.ToString(objBELIO.CheckedBy);
        ddlStartedBy.SelectedValue = Convert.ToString(objBELIO.StartedBy);
        txtStrtTime.Text = Convert.ToString(objBELIO.StartTime);
        txttime1.Text = Convert.ToString(objBELIO.TimeS);

        txtRate.Text = Convert.ToString(objBELIO.Rate);
        txtT.Text = Convert.ToString(objBELIO.T);
        txtP.Text = Convert.ToString(objBELIO.P);
        txtR.Text = Convert.ToString(objBELIO.R);
        txtBP.Text = Convert.ToString(objBELIO.BP);
        txtFTime.Text = Convert.ToString(objBELIO.FinishTime);
        txtTransfusionReaction.Text = Convert.ToString(objBELIO.TRDetails);     
        
        int UserId = Convert.ToInt32(objBELIO.UserId);
        
       

        // txtDrugName.Text = Convert.ToString(objBELIO.DrugName);
        // ViewState["DrugId"] = Convert.ToInt32(objBELIO.DrugId);

    }

    protected void gvBloodTrans_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvBloodTrans.PageIndex = e.NewPageIndex;
        BindBloodTransfusion();
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
      
        DateTime time = DateTime.Now;
        txttimestart.Text = DateTime.Now.ToString("dd/MM/yyyy");
        String s = time.ToString("hh:mm tt");
       // txtTime.Text = s;
     
        ViewState["DrugId"] = "0";

        ChkWholeBlood.Checked = false;
        Chkcryo.Checked = false;
        chkPackedCells.Checked = false;
        Chkffp.Checked = false;
        ChkPlatelets.Checked = false;

        rdbConsent.SelectedValue = "No";
        rdbDocOrder.SelectedValue = "No";
        rdbPreMedication.SelectedValue = "No";
        rdbPreTrans.SelectedValue = "No";
        rdbReaction.SelectedValue = "No";

        txtUnit.Text = "";

        ddlCheckedBy.SelectedValue = "0";
        ddlStartedBy.SelectedValue = "0";
        txtStrtTime.Text = "";
        txttime1.Text = "";

        txtRate.Text = "";
        txtT.Text = "";
        txtP.Text = "";
        txtR.Text = "";
        txtBP.Text = "";
        txtFTime.Text = "";
        txtTransfusionReaction.Text = "";     
        
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
        objDALIO.Alter_Vw_BloodTransfusion(objBELIO);
        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Report/Rpt_BloodTransfusion.rpt");
        Session["reportname"] = "Rpt_BloodTransfusion";
        Session["RPTFORMAT"] = "pdf";

        //ReportParameterClass.SelectionFormula = sql;
        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);
    }

    private void LoadConsultantDoc()
    {

        //ddlConsultantDoc.DataSource = objDALOpdReg.FillConsultantDocName();
        //ddlConsultantDoc.DataValueField = "DrId";
        //ddlConsultantDoc.DataTextField = "EmpName";
        //ddlConsultantDoc.DataBind();

        //    ddlInformedTo.DataSource = objDALOpdReg.FillConsultantDocName();
        //    ddlInformedTo.DataValueField = "DrId";
        //    ddlInformedTo.DataTextField = "EmpName";
        //    ddlInformedTo.DataBind();
        //}
    }
}