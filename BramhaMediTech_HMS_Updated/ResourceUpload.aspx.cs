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

public partial class ResourceUpload :BasePage
{
    AddMedicalRecord_C ObjAMR = new AddMedicalRecord_C();
    DataTable dt = new DataTable();
    DALOpdReg objDALOpdReg = new DALOpdReg();
    public enum MessageType { Success, Error, Info, Warning };
    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (Convert.ToString( Request.QueryString["EmrDash"]) == "Y")
        {
            this.MasterPageFile = "~/mainMaster.master";
           
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           // LoadRelation();
           
           
            BindMedicalRecord();
        }
    }
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
  
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        try
        {
            int RecordCount = 0;
            if (RblPatType.SelectedValue == "Doctor")
            {
               
                ObjAMR.P_PatientType = "Doctor";
               // ObjAMR.P_AdmissionDate = Convert.ToDateTime( txtAdmissionDate.Text);
                //ObjAMR.P_DischargeDate= Convert.ToDateTime(txtDischargeDate.Text);

               
                    RecordCount = 1;
                
            }
            else
            {
                RecordCount = 1;
                ObjAMR.P_PatientType = "Nurses";
                //ObjAMR.P_AdmissionDate = DateTimeConvesion.getDateFromString(Date.getdate().Date.ToString("dd/MM/yyyy")).Date;
                //ObjAMR.P_DischargeDate = DateTimeConvesion.getDateFromString(Date.getdate().Date.ToString("dd/MM/yyyy")).Date;
            }
            if (txtdocumentNumber.Text == "")
            {
                txtdocumentNumber.Focus();
                txtdocumentNumber.BorderColor = System.Drawing.Color.Red;
                return;
            }
          
            ObjAMR.P_DocumentNumber = txtdocumentNumber.Text;
            ObjAMR.P_Diagnostics = txtDiagnostics.Text;

            //ObjAMR.P_Relation = Convert.ToInt32(ddlRelation.SelectedValue);
            //ObjAMR.P_Relation1 = Convert.ToInt32(ddlrelation2.SelectedValue); ;
            //ObjAMR.P_RelativeName = txtrelativeName.Text;
            //ObjAMR.P_RelativeName1 = txtRelativeName2.Text;
            //ObjAMR.P_ContactNo = txtContactNo.Text;
            //ObjAMR.P_ContactNo1 = txtcontaxtNo2.Text;
            //string RegNo = "";

            string RegNo = Convert.ToString(Session["username"]);
            

            string fileName = "~/UploadResource/" + RegNo + "-" + RecordCount + "-" + txtdocumentNumber.Text + "-" + Path.GetFileName(FileUpload1.PostedFile.FileName);
            FileUpload1.SaveAs(Server.MapPath("~/UploadResource/" + RegNo + "-" + RecordCount + "-" + txtdocumentNumber.Text + "-" + FileUpload1.FileName));
            //"~/upload/" + FileUpload1.FileName;
            //ViewState["PhotoPath"] = fileName;

            ObjAMR.P_DocumentFileName = fileName;
            ObjAMR.P_DocumentFilePath = fileName;
            ObjAMR.P_CreatedBy = Convert.ToString(Session["username"]);
           // imgPatient.ImageUrl = Convert.ToString(ViewState["PhotoPath"]);
            ObjAMR.Insert_AddUploadRecords();
            ShowMessage("File Upload successfully", MessageType.Success);
            BindMedicalRecord();
            txtdocumentNumber.Text = "";
          
            txtDiagnostics.Text = "";
          
        }
        catch (Exception ex)
        {
            //lblMessage.Text = ex.Message;

        }
    }
   
    public void BindMedicalRecord()
    {

        dt = ObjAMR.GetResourceRecod_Info();
       
        if (dt.Rows.Count > 0)
        {
            gvAddMEdicalRecord.DataSource = dt;
            gvAddMEdicalRecord.DataBind();
        }
        else
        {
            gvAddMEdicalRecord.DataSource = null;
            gvAddMEdicalRecord.DataBind();
        }
    }
    protected void gvAddMEdicalRecord_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void gvAddMEdicalRecord_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string PatientCategoryID = (gvAddMEdicalRecord.DataKeys[e.RowIndex]["MedicalId"].ToString());
        ObjAMR.Delete_AddMedicalRecord(PatientCategoryID);
       
        ShowMessage("Record Delete Successfully", MessageType.Error);
        BindMedicalRecord();
    }
    protected void gvAddMEdicalRecord_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
}