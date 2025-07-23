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

public partial class AddMedicalRecord : System.Web.UI.Page
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
            if (Convert.ToString(Request.QueryString["EmrDash"]) != "Y")
            {
                GetMedicalRecord();
            }
            else
            {
                F1.Visible = false;
                F2.Visible = false;
            }
            BindMedicalRecord();
        }
    }
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
    public void GetMedicalRecord()
    {
        dt = ObjAMR.GetMedicalRecod_PatientInfo(Convert.ToInt32( Request.QueryString["PatientInfoID"]));
        if (dt.Rows.Count > 0)
        {
            lblPatRegId.Text = Convert.ToString( dt.Rows[0]["PatRegId"]);
            lblPatientName.Text = Convert.ToString(dt.Rows[0]["FirstName"]);

            lblBirthDate.Text = Convert.ToString( Convert.ToDateTime(dt.Rows[0]["BirthDate"]).ToString("dd/MM/yyyy"));
            lblGender.Text = Convert.ToString(dt.Rows[0]["GenderName"]);

            lblMobileNo.Text = Convert.ToString(dt.Rows[0]["MobileNo"]);
            lblAddress.Text = Convert.ToString(dt.Rows[0]["PatientAddress"]);
        }
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        try
        {
            int RecordCount = 0;
            if (RblPatType.SelectedValue == "IPD")
            {
                if (txtAdmissionDate.Text == "")
                {
                    txtAdmissionDate.Focus();
                    txtAdmissionDate.BorderColor = System.Drawing.Color.Red;
                    return;
                }
                if (txtDischargeDate.Text == "")
                {
                    txtDischargeDate.Focus();
                    txtDischargeDate.BorderColor = System.Drawing.Color.Red;
                    return;
                }
                ObjAMR.P_PatientType = "IPD";
                ObjAMR.P_AdmissionDate = Convert.ToDateTime( txtAdmissionDate.Text);
                ObjAMR.P_DischargeDate= Convert.ToDateTime(txtDischargeDate.Text);

                if (Convert.ToString(Request.QueryString["EmrDash"]) == "Y")
                {
                    dt = ObjAMR.GetMedical_CountNoOfFile(Convert.ToInt32(Convert.ToString(Session["EmrRegNo"])));
                }
                else
                {
                    dt = ObjAMR.GetMedical_CountNoOfFile(Convert.ToInt32(Request.QueryString["PatientInfoID"]));
                }
                if (dt.Rows.Count > 0)
                {
                    RecordCount = Convert.ToInt32( dt.Rows[0]["RecordCount"]);
                }
                else
                {
                    RecordCount = 1;
                }
            }
            else
            {
                RecordCount = 1;
                ObjAMR.P_PatientType = "OPD";
                //ObjAMR.P_AdmissionDate = DateTimeConvesion.getDateFromString(Date.getdate().Date.ToString("dd/MM/yyyy")).Date;
                //ObjAMR.P_DischargeDate = DateTimeConvesion.getDateFromString(Date.getdate().Date.ToString("dd/MM/yyyy")).Date;
            }
            if (txtdocumentNumber.Text == "")
            {
                txtdocumentNumber.Focus();
                txtdocumentNumber.BorderColor = System.Drawing.Color.Red;
                return;
            }
            if (Convert.ToString(Request.QueryString["EmrDash"]) == "Y")
            {
                ObjAMR.P_Patregid = Convert.ToInt32(Session["EmrRegNo"]);
            }
            else
            {
                ObjAMR.P_Patregid = Convert.ToInt32(Request.QueryString["PatientInfoID"]);
            }
            ObjAMR.P_DrName = txtdrname.Text;
            ObjAMR.P_DocumentNumber = txtdocumentNumber.Text;
            ObjAMR.P_Diagnostics = txtDiagnostics.Text;

            //ObjAMR.P_Relation = Convert.ToInt32(ddlRelation.SelectedValue);
            //ObjAMR.P_Relation1 = Convert.ToInt32(ddlrelation2.SelectedValue); ;
            //ObjAMR.P_RelativeName = txtrelativeName.Text;
            //ObjAMR.P_RelativeName1 = txtRelativeName2.Text;
            //ObjAMR.P_ContactNo = txtContactNo.Text;
            //ObjAMR.P_ContactNo1 = txtcontaxtNo2.Text;
            string RegNo = "";
            if (Convert.ToString(Request.QueryString["EmrDash"]) == "Y")
            {
                RegNo = Convert.ToString(Session["EmrRegNo"]);
            }
            else
            {
                 RegNo = Convert.ToString(Request.QueryString["PatientInfoID"]);
            }

            string fileName = "~/MedicalRecord/" + RegNo + "-" + RecordCount + "-" + txtdocumentNumber.Text + "-" + Path.GetFileName(FileUpload1.PostedFile.FileName);
            FileUpload1.SaveAs(Server.MapPath("~/MedicalRecord/" + RegNo + "-" + RecordCount + "-" + txtdocumentNumber.Text + "-" + FileUpload1.FileName));
            //"~/upload/" + FileUpload1.FileName;
            //ViewState["PhotoPath"] = fileName;

            ObjAMR.P_DocumentFileName = fileName;
            ObjAMR.P_DocumentFilePath = fileName;
            ObjAMR.P_CreatedBy = Convert.ToString(Session["username"]);
           // imgPatient.ImageUrl = Convert.ToString(ViewState["PhotoPath"]);
            ObjAMR.Insert_AddMEdicalRecord();
            ShowMessage("File Upload successfully", MessageType.Success);
            BindMedicalRecord();
            txtdocumentNumber.Text = "";
            txtdrname.Text = "";
            txtDiagnostics.Text = "";
          
        }
        catch (Exception ex)
        {
            //lblMessage.Text = ex.Message;

        }
    }
   
    public void BindMedicalRecord()
    {
        if (Convert.ToString(Request.QueryString["EmrDash"]) == "Y")
        {
            dt = ObjAMR.GetMedicalRecod_Info(Convert.ToInt32(Session["EmrRegNo"]));
        }
        else
        {
            dt = ObjAMR.GetMedicalRecod_Info(Convert.ToInt32(Request.QueryString["PatientInfoID"]));
        }
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