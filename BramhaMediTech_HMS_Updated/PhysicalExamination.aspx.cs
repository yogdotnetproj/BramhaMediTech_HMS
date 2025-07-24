using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class PhysicalExamination :BasePage
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
            if (Convert.ToString(Session["EmrRegNo"]) != "")
            {
                string regId = Convert.ToString(Session["EmrRegNo"]);
                string name = Request.QueryString["Name"];
                string opd = Convert.ToString(Session["EmrOpdNo"]);
                string entrydate = Request.QueryString["EntryDate"];
                int IpdId = Convert.ToInt32(Session["EmrIpdNo"]);
                objBELIO.FId = Convert.ToInt32(Session["FId"]);
                objBELIO.BranchId = Convert.ToInt32(Session["Branchid"]);
               // lblOpd.Text = opd;
                //DateTime time = DateTime.Now;
                //txttimestart.Text = DateTime.Now.ToString("dd/MM/yyyy");
                //String s = time.ToString("hh:mm tt");
                //txtTime.Text = s;
                //txtEndTime.Text = s;
                BindPatientInformation();
                //txtNurse.Text = Convert.ToString(Session["Name"]);
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
        dt = objDALIO.BindPhysicalExamination(objBELIO);
        gvDailyNurseNote.DataSource = dt;
        gvDailyNurseNote.DataBind();
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
       // objBELIO.DrId = Convert.ToInt32(ViewState["DrId"]);
        //objBELIO.DateInput = Convert.ToDateTime(txttimestart.Text);
        //objBELIO.TimeInput = Convert.ToString(txtTime.Text);
        //objBELIO.EndTime = Convert.ToString(txtEndTime.Text);
        //objBELIO.UserId = Convert.ToInt32(Session["UserId"]);
        //objBELIO.IvFluid = Convert.ToString(txtIVFluid.Text);
        //objBELIO.DrugName = Convert.ToString(txtDrug.Text);
       // objBELIO.IvFluidId = Convert.ToInt32(ddlIvfluid.SelectedValue);
        if (chkBedsore.Checked == true)
        {
            objBELIO.Bedsore = true;
        }
        else
        {
            objBELIO.Bedsore = false;
        }
        if (chkDentures.Checked == true)
        {
            objBELIO.Dentures = true;
        }
        else
        {
            objBELIO.Dentures = false;
        }
        if (chkSpectacles.Checked == true)
        {
            objBELIO.Spectacles = true;
        }
        else
        {
            objBELIO.Spectacles = false;
        }

        if (chkPhyinj.Checked == true)
        {
            objBELIO.CheckPhInj = true;
        }
        else
        {
            objBELIO.CheckPhInj = false;
        }
        objBELIO.PhysicalInjuries = txtphyinjremark.Text;

        if (chkFoleys.Checked == true)
        {
            objBELIO.CheckFoleys = true;
        }
        else
        {
            objBELIO.CheckFoleys = false;
        }
        if (chkNGTube.Checked == true)
        {
            objBELIO.CheckNGTube = true;
        }
        else
        {
            objBELIO.CheckNGTube = false;
        }
        if (chkIntraCatch.Checked == true)
        {
            objBELIO.CheckIntraCath = true;
        }
        else
        {
            objBELIO.CheckIntraCath = false;
        }
        objBELIO.PhysicalSize = txtsize.Text;

        if (chkcentralline.Checked == true)
        {
            objBELIO.CheckCentralLine = true;
        }
        else
        {
            objBELIO.CheckCentralLine = false;
        }
        objBELIO.CentralLine = txtcentralline.Text;

        if (chkimpladevice.Checked == true)
        {
            objBELIO.CheckImpDevice = true;
        }
        else
        {
            objBELIO.CheckImpDevice = false;
        }
        objBELIO.ImpDevice = txtimpladevice.Text;

        if (chkJewellery.Checked == true)
        {
            objBELIO.CheckJewellery = true;
        }
        else
        {
            objBELIO.CheckJewellery = false;
        }
        if (chkjevfamily.Checked == true)
        {
            objBELIO.CheckJewellerytofami = true;
        }
        else
        {
            objBELIO.CheckJewellerytofami = false;
        }

        if (chkpatfamily.Checked == true)
        {
            objBELIO.CheckPatfamily = true;
        }
        else
        {
            objBELIO.CheckPatfamily = false;
        }
        objBELIO.signature = txtsignature.Text;
        objBELIO.Relationship = txtrelationship.Text;
        objBELIO.OtherRemark = txtotherremark.Text;
        objBELIO.NurseRemark = txtnurserem.Text;


        string Msg;
        if (Convert.ToInt32(ViewState["PhId"]) > 0)
        {
            objBELIO.PhId = Convert.ToInt32(ViewState["PhId"]);
            Msg = objDALIO.InsertPhysicalExam(objBELIO);
            ViewState["IVChartId"] = "0";
            LblMSg.Text = "Record Update successfully!";
        }
        else
        {
            Msg = objDALIO.InsertPhysicalExam(objBELIO);
            LblMSg.Text = "Record Save successfully!" ;
        }

        BindDailyNurseNotes();

      
       
        
        LblMSg.ForeColor = System.Drawing.Color.Green;

        txtnurserem.Text = "";
        txtotherremark.Text = "";
        txtrelationship.Text = "";
        txtsignature.Text = "";

        txtimpladevice.Text = "";
        txtcentralline.Text = "";
        txtsize.Text = "";
        txtphyinjremark.Text = "";



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
        objBELIO = objDALIO.GetPhEx(Convert.ToInt32(ViewState["PhId"]), Convert.ToInt32(Session["Branchid"]), Convert.ToInt32(Session["FId"]));
        //txttimestart.Text = Convert.ToDateTime(objBELIO.DateInput).ToString("dd/MM/yyyy");
        //txtTime.Text = Convert.ToString(objBELIO.TimeInput);
        
        //txtNurse.Text = objBELIO.UserName;

        if (objBELIO.Bedsore == true)
        {
            chkBedsore.Checked = true;
        }
        else
        {
            chkBedsore.Checked = false;
        }
        if ( objBELIO.Dentures== true)
        {
            chkDentures.Checked = true;
        }
        else
        {
            chkDentures.Checked = false;
        }
        if (objBELIO.Spectacles == true)
        {
            chkSpectacles.Checked = true;
        }
        else
        {
            chkSpectacles.Checked = false;
        }

        if (objBELIO.CheckPhInj == true)
        {
            chkPhyinj.Checked = true;
        }
        else
        {
            chkPhyinj.Checked = false;
        }
        txtphyinjremark.Text =objBELIO.PhysicalInjuries;

        if (objBELIO.CheckFoleys == true)
        {
            chkFoleys.Checked = true;
        }
        else
        {
            chkFoleys.Checked = false;
        }
        if (objBELIO.CheckNGTube == true)
        {
            chkNGTube.Checked = true;
        }
        else
        {
            chkNGTube.Checked = false;
        }
        if (objBELIO.CheckIntraCath == true)
        {
            chkIntraCatch.Checked = true;
        }
        else
        {
            chkIntraCatch.Checked = false;
        }
       txtsize.Text= objBELIO.PhysicalSize ;

        if (objBELIO.CheckCentralLine== true)
        {
            chkcentralline.Checked = true;
        }
        else
        {
            chkcentralline.Checked = false;
        }
        txtcentralline.Text= objBELIO.CentralLine ;

        if (objBELIO.CheckImpDevice == true)
        {
            chkimpladevice.Checked = true;
        }
        else
        {
            chkimpladevice.Checked = false;
        }
       txtimpladevice.Text= objBELIO.ImpDevice  ;

       if (objBELIO.CheckJewellery == true)
        {
            chkJewellery.Checked = true;
        }
        else
        {
            chkJewellery.Checked = false;
        }
       if (objBELIO.CheckJewellerytofami == true)
        {
            chkjevfamily.Checked = true;
        }
        else
        {
            chkjevfamily.Checked = false;
        }

       if (objBELIO.CheckPatfamily == true)
        {
            chkpatfamily.Checked = true;
        }
        else
        {
            chkpatfamily.Checked = false;
        }
       txtsignature.Text = objBELIO.signature;
       txtrelationship.Text = objBELIO.Relationship;
       txtotherremark.Text=objBELIO.OtherRemark;
       txtnurserem.Text = objBELIO.NurseRemark;


      //  int UserId = Convert.ToInt32(objBELIO.UserId);

    }

    protected void gvDailyNurseNote_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDailyNurseNote.PageIndex = e.NewPageIndex;
        BindDailyNurseNotes();
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        
      
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
        objDALIO.Alter_Vw_GetPatientPhiscalExam(objBELIO);
        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Report/Rpt_PatientPhiscalExam.rpt");
        Session["reportname"] = "Rpt_PatientPhiscalExam";
        Session["RPTFORMAT"] = "pdf";

        //ReportParameterClass.SelectionFormula = sql;
        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);
    }
}