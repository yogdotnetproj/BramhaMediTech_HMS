using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class IVFluidChart :BasePage
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
                lblOpd.Text = opd;
                DateTime time = DateTime.Now;
                txttimestart.Text = DateTime.Now.ToString("dd/MM/yyyy");
                String s = time.ToString("hh:mm tt");
                txtTime.Text = s;
                txtEndTime.Text = s;
                BindPatientInformation();
                txtNurse.Text = Convert.ToString(Session["Name"]);
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
        dt = objDALIO.FillIVChart(objBELIO);
        gvDailyNurseNote.DataSource = dt;
        gvDailyNurseNote.DataBind();
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
        objBELIO.DateInput = Convert.ToDateTime(txttimestart.Text);
        objBELIO.TimeInput = Convert.ToString(txtTime.Text);
        objBELIO.EndTime = Convert.ToString(txtEndTime.Text);
        objBELIO.UserId = Convert.ToInt32(Session["UserId"]);
        objBELIO.IvFluid = Convert.ToString(txtIVFluid.Text);
        objBELIO.DrugName = Convert.ToString(txtDrug.Text);
       // objBELIO.IvFluidId = Convert.ToInt32(ddlIvfluid.SelectedValue);

        string Msg;
        if (Convert.ToInt32(ViewState["IVChartId"]) > 0)
        {
            objBELIO.IVChartId = Convert.ToInt32(ViewState["IVChartId"]);
            Msg = objDALIO.UpdateIVchart(objBELIO);
            ViewState["IVChartId"] = "0";
        }
        else
        {
            Msg = objDALIO.InsertIVChart(objBELIO);
        }

        BindDailyNurseNotes();

      
        DateTime time = DateTime.Now;
        txttimestart.Text = DateTime.Now.ToString("dd/MM/yyyy");
        String s = time.ToString("hh:mm tt");
        txtTime.Text = s;
        txtEndTime.Text = s;
        LblMSg.Text = Msg;
        LblMSg.ForeColor = System.Drawing.Color.Green;



        //}
        //}
    }
    protected void gvDailyNurseNote_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string IVChartId = (gvDailyNurseNote.DataKeys[e.RowIndex]["IVChartId"].ToString());


        string Message = objDALIO.DeleteIVChart(Convert.ToInt32(IVChartId));
        LblMSg.Text = Message;
        LblMSg.ForeColor = System.Drawing.Color.Green;
        BindDailyNurseNotes();


    }
    protected void gvDailyNurseNote_RowEditing(object sender, GridViewEditEventArgs e)
    {

        try
        {
            string IVChartId = (gvDailyNurseNote.DataKeys[e.NewEditIndex]["IVChartId"].ToString());
            ViewState["IVChartId"] = IVChartId;
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
        objBELIO = objDALIO.SelectIVChart(Convert.ToInt32(ViewState["IVChartId"]));
        txttimestart.Text = Convert.ToDateTime(objBELIO.DateInput).ToString("dd/MM/yyyy");
        txtTime.Text = Convert.ToString(objBELIO.TimeInput);
        
        txtNurse.Text = objBELIO.UserName;
        int UserId = Convert.ToInt32(objBELIO.UserId);

    }

    protected void gvDailyNurseNote_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDailyNurseNote.PageIndex = e.NewPageIndex;
        BindDailyNurseNotes();
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        
        DateTime time = DateTime.Now;
        txttimestart.Text = DateTime.Now.ToString("dd/MM/yyyy");
        String s = time.ToString("hh:mm tt");
        txtTime.Text = s;
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
        objDALIO.Alter_Vw_IVChart(objBELIO);
        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Report/Rpt_IVChart.rpt");
        Session["reportname"] = "Rpt_IVChart";
        Session["RPTFORMAT"] = "pdf";

        //ReportParameterClass.SelectionFormula = sql;
        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);
    }
}