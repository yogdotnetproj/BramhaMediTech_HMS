using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class RecordsofMonitor_Oxygen : System.Web.UI.Page
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
                BindDailyOxygen_Record();
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
        dt = objDALIO.Fill_Monitor_Record(objBELIO);
        gvDailyNurseNote.DataSource = dt;
        gvDailyNurseNote.DataBind();
    }

    public void BindDailyOxygen_Record()
    {
        DataTable dt = new DataTable();
        objBELIO.Patregid = Convert.ToInt32(Session["EmrRegNo"]);
        objBELIO.OpdNo = Convert.ToInt32(Session["EmrOpdNo"]);
        string entrydate = Request.QueryString["EntryDate"];
        objBELIO.IpdNo = Convert.ToInt32(Session["EmrIpdNo"]);
        objBELIO.FId = Convert.ToInt32(Session["FId"]);
        objBELIO.BranchId = Convert.ToInt32(Session["Branchid"]);
        dt = objDALIO.Fill_Oxygen_Record(objBELIO);
        GridView1.DataSource = dt;
        GridView1.DataBind();
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
        objBELIO.UserId = Convert.ToInt32(Session["UserId"]);

        //objBELIO.BloodSugarOrder = Convert.ToString(txtBloodSugar.Text);
       
        string Msg;
        if (Convert.ToInt32(ViewState["Id"]) > 0)
        {
            objBELIO.NurseNoteId = Convert.ToInt32(ViewState["Id"]);
           // Msg = objDALIO.UpdateDailyNurseNote(objBELIO);
            ViewState["Id"] = "0";
        }
        else
        {

           
           
           
        }
       
        BindDailyNurseNotes();

        //txtRemark.InnerText = "";
        //DateTime time = DateTime.Now;
        //txttimestart.Text = DateTime.Now.ToString("dd/MM/yyyy");
        //String s = time.ToString("hh:mm tt");
        //txtTime.Text = s;           
        LblMSg.Text = "Record Save Successfully";
        LblMSg.ForeColor = System.Drawing.Color.Green;



        //}
        //}
    }
    protected void gvDailyNurseNote_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string Id = (gvDailyNurseNote.DataKeys[e.RowIndex]["Id"].ToString());


        string Message = objDALIO.Delete_Investigation_Record(Convert.ToInt32(Id));
        LblMSg.Text = Message;
        LblMSg.ForeColor = System.Drawing.Color.Green;
        BindDailyNurseNotes();


    }
    protected void gvDailyNurseNote_RowEditing(object sender, GridViewEditEventArgs e)
    {
        
        try
        {
            string Id = (gvDailyNurseNote.DataKeys[e.NewEditIndex]["Id"].ToString());
            ViewState["Id"] = Id;
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
        objDALIO.Alter_Vw_Oxygen_Report(objBELIO);
        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Report/Rpt_OxygenUsed_Record.rpt");
        Session["reportname"] = "OxygenUsed_Record";
        Session["RPTFORMAT"] = "pdf";

        //ReportParameterClass.SelectionFormula = sql;
        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);
    }



    protected void btnaddMonitor_Click(object sender, EventArgs e)
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
        
        objBELIO.BranchId = Convert.ToInt32(Session["Branchid"]);
        if (txtDateAttached.Text != "")
        {
            objBELIO.MonAttDate = Convert.ToDateTime(txtDateAttached.Text);
            objBELIO.AttachedBy = Convert.ToString(Session["username"]);
        }
        objBELIO.MonAttTime = Convert.ToString(txtTimeAttached.Text);

        if (txtDateDetached.Text != "")
        {
            objBELIO.MonDetDate = Convert.ToDateTime(txtDateDetached.Text);
            objBELIO.DetectedBy = Convert.ToString(Session["username"]);
        }
        objBELIO.MonDetTime = Convert.ToString(txtTimeDetached.Text);

        objDALIO.Insert_MonitorRecords(objBELIO);

        LblMSg.Text = "Record save successfully!";
        LblMSg.ForeColor = System.Drawing.Color.Green;
        BindDailyNurseNotes();
    }
    protected void btnAddOxy_Click(object sender, EventArgs e)
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

        objBELIO.BranchId = Convert.ToInt32(Session["Branchid"]);
        if (txtdateOxy.Text != "")
        {
            objBELIO.OxyStartDate = Convert.ToDateTime(txtdateOxy.Text);
            objBELIO.AttachedBy = Convert.ToString(Session["username"]);
        }
        objBELIO.OxyStartTime = Convert.ToString(txtTimeOxystart.Text);
        objBELIO.LMP = Convert.ToString(txtLmp.Text);
        if (txtdateDisOxy.Text != "")
        {
            objBELIO.OxydisDate = Convert.ToDateTime(txtdateDisOxy.Text);
            objBELIO.DiscontinuedBy = Convert.ToString(Session["username"]);
        }
        objBELIO.OxydisTime = Convert.ToString(txtTimeDisOxy.Text);

        objDALIO.Insert_OxygenRecords(objBELIO);

        LblMSg.Text = "Record save successfully!";
        LblMSg.ForeColor = System.Drawing.Color.Green;
        BindDailyOxygen_Record();

    }
    protected void btnMonitorrep_Click(object sender, EventArgs e)
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
        objDALIO.Alter_Vw_Monitor_Report(objBELIO);
        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Report/Rpt_MonitorReports.rpt");
        Session["reportname"] = "MonitorUsed_Record";
        Session["RPTFORMAT"] = "pdf";

        //ReportParameterClass.SelectionFormula = sql;
        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);
    }
}