using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Services;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using CrystalDecisions.CrystalReports.Engine;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.Collections;
using System.IO;
using System.Drawing;
using System.Media;

public partial class AdmissionSheet : BasePage
{
    clsEmr obj = new clsEmr();
    clsTreatment objTreat = new clsTreatment();
    clsTreatmentTransaction transaction = new clsTreatmentTransaction();
    BELIntakeOutputChart objBELIO = new BELIntakeOutputChart();
    DALInputOutPutChart objDALIO = new DALInputOutPutChart();

    AddMedicalRecord_C ObjAMR = new AddMedicalRecord_C();
    DataTable dt = new DataTable();
    DALOpdReg objDALOpdReg = new DALOpdReg();
    public enum MessageType { Success, Error, Info, Warning };
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
                //DateTime time = DateTime.Now;
                //txttimestart.Text = DateTime.Now.ToString("dd/MM/yyyy");
                //String s = time.ToString("hh:mm tt");
                //txtTime.Text = s;
                //txtEndTime.Text = s;
                BindPatientInformation();
              //  txtNurse.Text = Convert.ToString(Session["Name"]);
              
            }
        }
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
         //  dt = obj.Get_AllPatientVitalTaken(Convert.ToString(Session["EmrRegNo"]), Convert.ToString(Session["EmrOpdNo"]), Convert.ToInt32(Session["EmrIpdNo"]), Convert.ToInt32(Session["Branchid"]));
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
        //objDALIO.Alter_Vw_PatientHistory(objBELIO);
        //Session.Add("rptsql", sql);
        //Session["rptname"] = Server.MapPath("~/Report/Rpt_PatientHisForm.rpt");
        //Session["reportname"] = "Rpt_PatientHisForm";
        //Session["RPTFORMAT"] = "pdf";

        ////ReportParameterClass.SelectionFormula = sql;
        //string close = "<script language='javascript'>javascript:OpenReport();</script>";
        //Type title1 = this.GetType();
        //Page.ClientScript.RegisterStartupScript(title1, "", close);

        DataSet ds = new DataSet();
        BLLReports objReports = new BLLReports();
        int IpdId = Convert.ToInt32(Session["EmrIpdNo"]);
        int FId = Convert.ToInt32(Session["FId"]);
        int BranchId = Convert.ToInt32(Session["Branchid"]);
        ReportDocument CrystalReport = new ReportDocument();
        CrystalReport.Load(Server.MapPath("~/Report/Rpt_AdmissionFrontSheet.rpt"));
        ds = objReports.GetIpdPatientCard(IpdId, FId, BranchId);
        CrystalReport.SetDataSource(ds);
        try
        {
            CrystalReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Employee");
        }
        catch (Exception ex)
        {
        }
        finally
        {
            CrystalReport.Close();
            ((IDisposable)CrystalReport).Dispose();
            GC.Collect();
            GC.SuppressFinalize(CrystalReport);
        }
  
    }

    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
    public void GetMedicalRecord()
    {
        //dt = ObjAMR.GetMedicalRecod_PatientInfo(Convert.ToInt32(Request.QueryString["PatientInfoID"]));
        //if (dt.Rows.Count > 0)
        //{
        //    lblPatRegId.Text = Convert.ToString(dt.Rows[0]["PatRegId"]);
        //    lblPatientName.Text = Convert.ToString(dt.Rows[0]["FirstName"]);

        //    lblBirthDate.Text = Convert.ToString(Convert.ToDateTime(dt.Rows[0]["BirthDate"]).ToString("dd/MM/yyyy"));
        //    lblGender.Text = Convert.ToString(dt.Rows[0]["GenderName"]);

        //    lblMobileNo.Text = Convert.ToString(dt.Rows[0]["MobileNo"]);
        //    lblAddress.Text = Convert.ToString(dt.Rows[0]["PatientAddress"]);
        //}
    }
   
}