using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class DailyNurseNotes :BasePage
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
                BindAllergise(Convert.ToInt32( regId));
                BindPatientInformation();
                txtNurse.Text = Convert.ToString(Session["Name"]);
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
        dt = objDALIO.FillDailyNurseNote(objBELIO);
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
            //if (Convert.ToString(Session["PatAdmit"]) == "No")
            //{
            //    LblMSg.ForeColor = System.Drawing.Color.Red;
            //    LblMSg.Text = "Patient already discharge!";
            //    return;
            //}
        }
        else
        {
            objBELIO.IpdNo = 0;
        }
        if (Convert.ToString(txtRemark.InnerText) == "")
        {
            LblMSg.ForeColor = System.Drawing.Color.Red;
            LblMSg.Text = "pls Enter Nurse Note!";
            return;
        }
        if (Convert.ToString(txtallergy.Text) == "")
        {
            LblMSg.ForeColor = System.Drawing.Color.Red;
            LblMSg.Text = "pls Enter Allergy!";
            return;
        }
        objBELIO.Patregid = Convert.ToInt32(Session["EmrRegNo"]);
        objBELIO.CreatedBy = Convert.ToString(Session["username"]);
        objBELIO.UpdatedBy = Convert.ToString(Session["username"]);
        objBELIO.FId = Convert.ToInt32(Session["FId"]); ;
        objBELIO.BranchId = Convert.ToInt32(Session["Branchid"]);
        objBELIO.DrId = Convert.ToInt32(ViewState["DrId"]);
        objBELIO.DateInput = Convert.ToDateTime(txttimestart.Text);
        objBELIO.TimeInput = Convert.ToString(txtTime.Text);
        objBELIO.Remark = Convert.ToString(txtRemark.InnerText);
        objBELIO.UserId = Convert.ToInt32(Session["UserId"]);
        objBELIO.Allergies = Convert.ToString(txtallergy.Text);
        string Msg;
        if (Convert.ToInt32(ViewState["NurseNoteId"]) > 0)
        {
            objBELIO.NurseNoteId = Convert.ToInt32(ViewState["NurseNoteId"]);
            Msg = objDALIO.UpdateDailyNurseNote(objBELIO);
            ViewState["NurseNoteId"] = "0";
        }
        else
        {
            Msg = objDALIO.InsertDailyNurseNote(objBELIO);
        }
       
        BindDailyNurseNotes();

        txtRemark.InnerText = "";
        DateTime time = DateTime.Now;
        txttimestart.Text = DateTime.Now.ToString("dd/MM/yyyy");
        String s = time.ToString("hh:mm tt");
        txtTime.Text = s;           
        LblMSg.Text = Msg;
        LblMSg.ForeColor = System.Drawing.Color.Green;



        //}
        //}
    }
    protected void gvDailyNurseNote_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string NurseNoteId = (gvDailyNurseNote.DataKeys[e.RowIndex]["NurseNoteId"].ToString());


        string Message = objDALIO.DeleteDailyNurseNote(Convert.ToInt32(NurseNoteId));
        LblMSg.Text = Message;
        LblMSg.ForeColor = System.Drawing.Color.Green;
        BindDailyNurseNotes();


    }
    protected void gvDailyNurseNote_RowEditing(object sender, GridViewEditEventArgs e)
    {
        
        try
        {
            string NurseNoteId = (gvDailyNurseNote.DataKeys[e.NewEditIndex]["NurseNoteId"].ToString());
            ViewState["NurseNoteId"] = NurseNoteId;
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
        objBELIO = objDALIO.SelectDailyNurseNote(Convert.ToInt32(ViewState["NurseNoteId"]));
        txttimestart.Text = Convert.ToDateTime(objBELIO.DateInput).ToString("dd/MM/yyyy");
        txtTime.Text = Convert.ToString(objBELIO.TimeInput);
        txtRemark.InnerText = objBELIO.Remark;
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
        txtRemark.InnerText = "";
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
        objDALIO.Alter_Vw_DailyNurseNote(objBELIO);
        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Report/Rpt_DailyNurseNotes.rpt");
        Session["reportname"] = "Rpt_DailyNurseNotes";
        Session["RPTFORMAT"] = "pdf";

        //ReportParameterClass.SelectionFormula = sql;
        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);
    }
    public void BindAllergise(int RegNo)
    {
        SqlConnection conn = DataAccess.ConInitForDC();
        conn.Open();

        using (SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM patientinformation where PatRegId=" + Convert.ToInt32(RegNo), conn))
        {
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                txtallergy.Text = Convert.ToString(dt.Rows[0]["Allergy"]);
            }
            else
            {


            }

        }
        conn.Close();
        conn.Dispose();

    }
}