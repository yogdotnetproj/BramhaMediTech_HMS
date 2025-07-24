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
public partial class AssignDiagnosis : BasePage
{
    clsEmr obj = new clsEmr();
    clsTreatment objTreat = new clsTreatment();
    clsTreatmentTransaction transaction = new clsTreatmentTransaction();
    DataTable tempDatatable = new DataTable();
    BLLPatientCategory objBLLPatientCategory = new BLLPatientCategory();
    DOPatientCategory objDOPatientCategory = new DOPatientCategory();
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
                Session["Branchid"] = "1";
                lblmsg.Text = "";
                PindPatientInformation();
                FillAssignDiagnosis();
               
            }
        }
    }
    public void PindPatientInformation()
    {
        DataTable dt = new DataTable();
        dt = obj.Get_AllPatientInformation(Convert.ToString(Session["EmrRegNo"]), Convert.ToString(Session["EmrOpdNo"]), Convert.ToInt32(Session["EmrIpdNo"]), Convert.ToInt32(Session["Branchid"]));
        try
        {
            if (dt != null)
            {
                //lblPatientName.Text = Convert.ToString(dt.Rows[0]["PatientName"]);
                //txtpatientregid.Text = Convert.ToString(dt.Rows[0]["PatRegId"]);
                //lblIpd.Text = Convert.ToString(dt.Rows[0]["Ipdno"]); 
                //lblOpd.Text = Convert.ToString(dt.Rows[0]["PatRegId"]);
                //lblMobileNo.Text = Convert.ToString(dt.Rows[0]["MobileNo"]);
                //lbldrname.Text = Convert.ToString(dt.Rows[0]["DrName"]);
                //lblAge.Text = Convert.ToString(dt.Rows[0]["Age"]) + "" + Convert.ToString(dt.Rows[0]["AgeType"]) + "/" + Convert.ToString(dt.Rows[0]["GenderName"]);
                ViewState["Age"] = Convert.ToString(dt.Rows[0]["Age"]);
                ViewState["AgeType"] = Convert.ToString(dt.Rows[0]["AgeType"]);

            }
            //dt = new DataTable();
            //dt = obj.Get_AllPatientVitalTaken(Convert.ToString(Session["EmrRegNo"]), Convert.ToString(Session["EmrOpdNo"]),Convert.ToInt32(Session["EmrIpdNo"]), Convert.ToInt32(Session["Branchid"]));
            //if (dt.Rows.Count > 0)
            //{
            //    lblvtaken.Text = Convert.ToString(dt.Rows[0]["CreatedOn"]);
            //}
        }
        catch (Exception ex)
        {

        }
    }
    protected void gvAssignDiagnosis_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvAssignDiagnosis.PageIndex = e.NewPageIndex;
        FillAssignDiagnosis();
    }
    protected void gvAssignDiagnosis_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string VaccianId = (gvAssignDiagnosis.DataKeys[e.RowIndex]["Diagid"].ToString());

        string Message = objBLLPatientCategory.Delete_AssignDiagnosis(Convert.ToInt32(VaccianId));//Convert.ToInt32(ViewState["PCId"])
        //DynamicMessage(lblMessage, Message);
       // lblMessage.Text = "Recore Delete Successfully.";
        FillAssignDiagnosis();
        txtDiagnosis.Text = "";
        lblmsg.Text = "Record delete successfully!.";
    }
    protected void gvAssignDiagnosis_RowEditing(object sender, GridViewEditEventArgs e)
    {
        string Diagid = (gvAssignDiagnosis.DataKeys[e.NewEditIndex]["Diagid"].ToString());
        ViewState["VaccianId"] = Diagid;
       // FillPage();
        e.Cancel = true;
    }
    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchDiagnosis(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        return objDALOpdReg.FillAllDiagnosis(prefixText);
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        string Message = ""; 
        if (txtDiagnosis.Text != "")
        {
            string Diagno = Convert.ToString(txtDiagnosis.Text);
            string[] Data = txtDiagnosis.Text.Trim().Split('-');
             objDOPatientCategory.OpdNo = Convert.ToString(Session["EmrOpdNo"]);
             objDOPatientCategory.IpdNo = Convert.ToString(Session["EmrIpdNo"]);
             objDOPatientCategory.Patregid = Convert.ToString(Session["EmrRegNo"]);
             objDOPatientCategory.CreatedBy = Convert.ToString(Session["username"]);
             objDOPatientCategory.FId = Convert.ToInt32(Session["FId"]); ;
             objDOPatientCategory.BranchId = Convert.ToInt32(Session["Branchid"]);
             objDOPatientCategory.DiagnosisName = Convert.ToString(Data[1]);
             objDOPatientCategory.DiagnosisCode = Convert.ToString(Data[0]);
           // Message = objBLLPatientCategory.Insert_DiagnosisAssignToPatient(Convert.ToString(Session["EmrRegNo"]), Convert.ToString(Session["EmrOpdNo"]), Convert.ToString(Session["EmrIpdNo"]), Diagno, Convert.ToString(Session["username"]), Convert.ToString(Session["FId"]), Convert.ToString(Session["Branchid"]));
             Message = objBLLPatientCategory.Insert_DiagnosisAssignToPatient(objDOPatientCategory);

            FillAssignDiagnosis();
            txtDiagnosis.Text = "";
            lblmsg.Text = "Record save successfully!.";
        }
    }
    protected void FillAssignDiagnosis()
    {
        objDOPatientCategory.OpdNo = Convert.ToString(Session["EmrOpdNo"]);
        objDOPatientCategory.IpdNo = Convert.ToString(Session["EmrIpdNo"]);
        objDOPatientCategory.Patregid = Convert.ToString(Session["EmrRegNo"]);
        objDOPatientCategory.CreatedBy = Convert.ToString(Session["username"]);
        objDOPatientCategory.FId = Convert.ToInt32(Session["FId"]); ;
        objDOPatientCategory.BranchId = Convert.ToInt32(Session["Branchid"]);
        gvAssignDiagnosis.DataSource = objBLLPatientCategory.FillGrid_AssignDiagnosis(objDOPatientCategory);
        gvAssignDiagnosis.DataBind();
    }
}