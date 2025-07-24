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
public partial class Opthalmology_Clinic :BasePage
{
    public enum MessageType { Success, Error, Info, Warning };
    Dental_Clinic_C ObjDC = new Dental_Clinic_C();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
          // txtdate.Text= DateTime.Now.ToString("dd/MM/yyyy");
            Get_All_Opthalmology_Data(Convert.ToInt32(Session["EmrRegNo"]));

            Get_Opthalmology_Clinic(Convert.ToInt32(Session["EmrOpdNo"]));
            GetRecords();
            BindImages();
        }
    }
    private DataTable GetRecords()
    {
        string patientregid = Convert.ToString(Session["EmrRegNo"]);
        string opd = Convert.ToString(Session["EmrOpdNo"]);
        string ipd = Convert.ToString(Session["EmrIpdNo"]);
        string branchid = Convert.ToString(Session["Branchid"]);

        DataTable dt = new DataTable();
        try
        {
            dt = ObjDC.GetGeneralEmrDetailsEdit(patientregid, opd, ipd, branchid);
            if (dt.Rows.Count > 0)
            {
                txtchiefComplaints.Text = Convert.ToString(dt.Rows[0]["chiefcomplaints"]);
                txtPastHistory.Text = Convert.ToString(dt.Rows[0]["pasthistory"]);
                txtAllergys.Text = Convert.ToString(dt.Rows[0]["allergies"]);
            }
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    public void Get_All_Opthalmology_Data(int Patregid)
    {

        DataTable dt = new DataTable();

        using (SqlConnection con = DataAccess.ConInitForDC())
        {
            using (SqlCommand cmd = new SqlCommand("usp_GetAll_Opthalmology_Clinic_Details", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@PatRegId", Convert.ToInt32(Session["EmrRegNo"]));

                con.Open();

                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(dt);
                }

                con.Close();
                con.Dispose();
            }

            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();

            }


        }
    }
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
  
    protected void btnsave_Click(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["EmrOpdNo"]) != "")
        {
            ObjDC.P_OpdNo = Convert.ToInt32(Session["EmrOpdNo"]);
        }
        else
        {
            ObjDC.P_OpdNo = 0;
        }
        if (Convert.ToString(Session["EmrIpdNo"]) != "")
        {
            ObjDC.P_IpdNo = Convert.ToInt32(Session["EmrIpdNo"]);
        }
        else
        {
            ObjDC.P_IpdNo = 0;
        }
        ObjDC.P_Patregid = Convert.ToInt32(Session["EmrRegNo"]);
        ObjDC.P_CreatedBy = Convert.ToString(Session["username"]);
        ObjDC.P_Branchid = Convert.ToInt32(Session["Branchid"]);

        ObjDC.P_Allergies = txtAllergys.Text;
        ObjDC.P_OcularHistory = txtOcularHistory.Text;
        ObjDC.P_PastHistory = txtPastHistory.Text;
        ObjDC.P_ChiefComplaints = txtchiefComplaints.Text;
        ObjDC.P_TreatmentHistory = txttreatmentHistory.Text;
        ObjDC.P_FamilyHistory = txtRp.Text;

        if (ChkNil.Checked == true)
        {
            ObjDC.P_NIL = true;
        }
        else
        {
            ObjDC.P_NIL = false;
        }
        if (ChkDM.Checked == true)
        {
            ObjDC.P_DM = true;
        }
        else
        {
            ObjDC.P_DM = false;
        }
        if (ChkHTN.Checked == true)
        {
            ObjDC.P_HTN = true;
        }
        else
        {
            ObjDC.P_HTN = false;
        }
        if (ChkCad.Checked == true)
        {
            ObjDC.P_CAD = true;
        }
        else
        {
            ObjDC.P_CAD = false;
        }
        if (ChkThyroid.Checked == true)
        {
            ObjDC.P_Thyroid = true;
        }
        else
        {
            ObjDC.P_Thyroid = false;
        }
        if (ChkPregnancy.Checked == true)
        {
            ObjDC.P_IS_Pregnancy = true;
        }
        else
        {
            ObjDC.P_IS_Pregnancy = false;
        }
        if (ChkHIV.Checked == true)
        {
            ObjDC.P_HIV = true;
        }
        else
        {
            ObjDC.P_HIV = false;
        }
        if (ChkHBsAG.Checked == true)
        {
            ObjDC.P_HBsAG = true;
        }
        else
        {
            ObjDC.P_HBsAG = false;
        }
        if (ChkAsthamaa.Checked == true)
        {
            ObjDC.P_Asthama = true;
        }
        else
        {
            ObjDC.P_Asthama = false;
        }
        if (ChkHTNF.Checked == true)
        {
            ObjDC.P_HTN_Family = true;
        }
        else
        {
            ObjDC.P_HTN_Family = false;
        }
        if (ChkDMGlaucoma.Checked == true)
        {
            ObjDC.P_DMGlaucoma = true;
        }
        else
        {
            ObjDC.P_DMGlaucoma = false;
        }
        if (ChkCongCataract.Checked == true)
        {
            ObjDC.P_CongCataract = true;
        }
        else
        {
            ObjDC.P_CongCataract = false;
        }
        if (ChkRP.Checked == true)
        {
            ObjDC.P_RP = true;
        }
        else
        {
            ObjDC.P_RP = false;
        }
        if (ChkGlaucoma.Checked == true)
        {
            ObjDC.P_Glaucoma = true;
        }
        else
        {
            ObjDC.P_Glaucoma = false;
        }
        ObjDC.P_Dilated = RblDilated.SelectedValue;
        string fileName = "";
        if (FileUpload1.HasFile)
        {
             fileName = "~/Opthalmology/" + Convert.ToInt32(Session["EmrRegNo"]) + "-" + Convert.ToString(Session["EmrOpdNo"]) + "-" + Path.GetFileName(FileUpload1.PostedFile.FileName);
             FileUpload1.SaveAs(Server.MapPath("~/Opthalmology/" + Convert.ToInt32(Session["EmrRegNo"]) + "-" + Convert.ToString(Session["EmrOpdNo"]) + "-" + FileUpload1.FileName));
        }
        else
        {
        }
        ObjDC.P_DocumentFileName = fileName;
        ObjDC.P_DocumentFilePath = fileName;
        ObjDC.P_Diagnosis = txtDiagnosis.Text;
        ObjDC.Insert_Opthalmology_Clinic();
        ShowMessage("Record save successfully", MessageType.Success);
        Get_All_Opthalmology_Data(Convert.ToInt32(Session["EmrRegNo"]));
    }
    protected void btnreport_Click(object sender, EventArgs e)
    {
        string sql = "";
        Alter_view();
        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Report/Rpt_Opthalmology_Clinic.rpt");
        Session["reportname"] = "Opthalmology_Clinic";
        Session["RPTFORMAT"] = "pdf";

        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);
    }
    public void Alter_view()
    {
        string sql = "";
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd1 = con.CreateCommand();

        string query = "ALTER VIEW [dbo].[VW_Opthalmology_Clinic] AS (SELECT        PatientInformation.MiddleName, PatientInformation.LastName, Gender.GenderName, PatientInformation.MobileNo, PatientInformation.PhoneNo, PatientInformation.PatientAddress, PatientInformation.Email, " +
                  "  PatientInformation.Age, PatientInformation.AgeType, PatientInformation.FirstName, Opthalmology_Clinic.Id, Opthalmology_Clinic.Patregid, Opthalmology_Clinic.OPDNo, Opthalmology_Clinic.IPDNo, "+
                  "  Opthalmology_Clinic.ChiefComplaints, Opthalmology_Clinic.OcularHistory, Opthalmology_Clinic.PastHistory, Opthalmology_Clinic.Allergies, Opthalmology_Clinic.FamilyHistory, Opthalmology_Clinic.TreatmentHistory, "+
                  "  Opthalmology_Clinic.NIL, Opthalmology_Clinic.DM, Opthalmology_Clinic.HTN, Opthalmology_Clinic.CAD, Opthalmology_Clinic.Thyroid, Opthalmology_Clinic.IS_Pregnancy, Opthalmology_Clinic.HIV, Opthalmology_Clinic.HBsAG, "+
                  "  Opthalmology_Clinic.Asthama, Opthalmology_Clinic.HTN_Family, Opthalmology_Clinic.DMGlaucoma, Opthalmology_Clinic.CongCataract, Opthalmology_Clinic.RP, Opthalmology_Clinic.CreatedBy, "+
                  "  Opthalmology_Clinic.CreatedOn, Opthalmology_Clinic.Branchid "+
                  "  FROM            Opthalmology_Clinic INNER JOIN "+
                  "  PatientInformation ON Opthalmology_Clinic.Patregid = PatientInformation.PatRegId INNER JOIN "+
                  "  Gender ON PatientInformation.GenderId = Gender.GenderId " +
        " where Opthalmology_Clinic.Patregid=" + Convert.ToInt32(Session["EmrRegNo"]) + "  and  Opthalmology_Clinic.OPDNo=" + Convert.ToInt32(Session["EmrOpdNo"]) + " and  Opthalmology_Clinic.IPDNO=" + Convert.ToInt32(Session["EmrIpdNo"]) + " ";
        //if (txtFrom.Value != "" && txtTo.Value != "")
        //{
        //    query += " and    DagnosisAssigtTpPatient.CreatedOn between ('" + Convert.ToDateTime(txtFrom.Value).ToString("MM/dd/yyyy") + "') and ('" + Convert.ToDateTime(txtTo.Value).AddDays(1).ToString("MM/dd/yyyy") + "')";
        //}



        cmd1.CommandText = query + ")";

        con.Open();
        cmd1.ExecuteNonQuery();
        con.Close(); con.Dispose();
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int OPDNo = Convert.ToInt32(GridView1.DataKeys[e.NewEditIndex]["OPDNo"]);
        ViewState["OPDNO"] = OPDNo;

         Get_Opthalmology_Clinic(OPDNo);
       // Get_Diagnostic_TReatment(1, OPDNo);
       // Get_TReatment_Details(1, OPDNo);
       // Get_IntraoralExamination(1, OPDNo);
        e.Cancel = true;
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    public void Get_Opthalmology_Clinic( int OPDNo)
    {

        DataTable dt = new DataTable();

        using (SqlConnection con = DataAccess.ConInitForDC())
        {
            using (SqlCommand cmd = new SqlCommand("usp_GetOpth_almology_Clinic_Details", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@PatRegId", Convert.ToInt32(Session["EmrRegNo"]));
                cmd.Parameters.AddWithValue("@OPDNO", Convert.ToInt32(OPDNo));
                con.Open();

                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(dt);
                }

                con.Close();
                con.Dispose();
            }

            if (dt.Rows.Count > 0)
            {
                        txtAllergys.Text = Convert.ToString(dt.Rows[0]["Allergies"]); ;
                        txtOcularHistory.Text = Convert.ToString(dt.Rows[0]["OcularHistory"]);
                        txtPastHistory.Text = Convert.ToString(dt.Rows[0]["PastHistory"]);
                        txtchiefComplaints.Text = Convert.ToString(dt.Rows[0]["ChiefComplaints"]);
                        txttreatmentHistory.Text = Convert.ToString(dt.Rows[0]["TreatmentHistory"]);
                        txtRp.Text = Convert.ToString(dt.Rows[0]["FamilyHistory"]);

                        if (Convert.ToBoolean(dt.Rows[0]["NIL"]) == true)
                        {
                            ChkNil.Checked = true;
                        }
                        else
                        {
                            ChkNil.Checked = false;
                        }
                        if (Convert.ToBoolean(dt.Rows[0]["DM"]) == true)
                        {
                            ChkDM.Checked = true;
                        }
                        else
                        {
                            ChkDM.Checked = false;
                        }
                        if (Convert.ToBoolean(dt.Rows[0]["HTN"]) == true)
                        {
                            ChkHTN.Checked = true;
                        }
                        else
                        {
                            ChkHTN.Checked = false;
                        }
                        if (Convert.ToBoolean(dt.Rows[0]["CAD"]) == true)
                        {
                            ChkCad.Checked = true;
                        }
                        else
                        {
                            ChkCad.Checked = false;
                        }
                        if (Convert.ToBoolean(dt.Rows[0]["Thyroid"]) == true)
                        {
                            ChkThyroid.Checked = true;
                        }
                        else
                        {
                            ChkThyroid.Checked = false;
                        }
                        if (Convert.ToBoolean(dt.Rows[0]["IS_Pregnancy"]) == true)
                        {
                            ChkPregnancy.Checked = true;
                        }
                        else
                        {
                            ChkPregnancy.Checked = false;
                        }
                        if (Convert.ToBoolean(dt.Rows[0]["HIV"]) == true)
                        {
                            ChkHIV.Checked = true;
                        }
                        else
                        {
                            ChkHIV.Checked = false;
                        }
                        if (Convert.ToBoolean(dt.Rows[0]["HBsAG"]) == true)
                        {
                            ChkHBsAG.Checked = true;
                        }
                        else
                        {
                            ChkHBsAG.Checked = false;
                        }
                        if (Convert.ToBoolean(dt.Rows[0]["Asthama"]) == true)
                        {
                            ChkAsthamaa.Checked = true;
                        }
                        else
                        {
                            ChkAsthamaa.Checked = false;
                        }
                        if (Convert.ToBoolean(dt.Rows[0]["HTN_Family"]) == true)
                        {
                            ChkHTNF.Checked = true;
                        }
                        else
                        {
                            ChkHTNF.Checked = false;
                        }
                        if (Convert.ToBoolean(dt.Rows[0]["DMGlaucoma"]) == true)
                        {
                            ChkDMGlaucoma.Checked = true;
                        }
                        else
                        {
                            ChkDMGlaucoma.Checked = false;
                        }
                        if (Convert.ToBoolean(dt.Rows[0]["CongCataract"]) == true)
                        {
                            ChkCongCataract.Checked = true;
                        }
                        else
                        {
                            ChkCongCataract.Checked = false;
                        }
                        if (Convert.ToBoolean(dt.Rows[0]["RP"]) == true)
                        {
                            ChkRP.Checked = true;
                        }
                        else
                        {
                            ChkRP.Checked = false;
                        }
                        if (Convert.ToBoolean(dt.Rows[0]["Glaucoma"]) == true)
                        {
                            ChkGlaucoma.Checked = true;
                        }
                        else
                        {
                            ChkGlaucoma.Checked = false;
                        }
                        RblDilated.SelectedValue = Convert.ToString( dt.Rows[0]["Glaucoma"]);
                        Hyp_viewPres.NavigateUrl = Convert.ToString(dt.Rows[0]["DocumentFilePath"]);
                        Hyp_viewPres.Text = "View File";
                        txtDiagnosis.Text = Convert.ToString(dt.Rows[0]["Diagnosis"]);
            }


        }
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        if (Convert.ToString( Session["EmrRegNo"]) != "0")
        {

            if (FileUpload1.HasFile)
            {
                if (txtfileNAme.Text.Trim() != "")
                {
                    string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    filename = "UID" + Session["EmrRegNo"] + "-" + Session["EmrOpdNo"] + "-" + txtfileNAme.Text;
                    string filePath = "~/Opthalmology/" + filename;
                    FileUpload1.SaveAs(Server.MapPath(filePath));
                    SqlConnection conn = DataAccess.ConInitForDC();
                    conn.Open();


                    SqlCommand cmd = new SqlCommand("Insert into OPthoPatientFiles(PatRegId,OPDNO,FileName,Path,CreatedBy,Branchid) values(@PatRegId,@OPDNO,@FileName,@Path,@CreatedBy,@Branchid)", conn);
                    cmd.Parameters.AddWithValue("@Path", filePath);
                    cmd.Parameters.AddWithValue("@PatRegId", Convert.ToInt32(Session["EmrRegNo"]));
                    cmd.Parameters.AddWithValue("@filename", txtfileNAme.Text.Trim());
                    cmd.Parameters.AddWithValue("@OPDNO", Session["EmrOpdNo"]);
                    cmd.Parameters.AddWithValue("@CreatedBy", Convert.ToString(Session["username"]));
                    cmd.Parameters.AddWithValue("@Branchid", Convert.ToString(Session["Branchid"]));
                    //    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    conn.Dispose();
                    BindImages();
                    txtfileNAme.Text = "";
                    //}  
                    // }
                }
                else
                {
                    txtfileNAme.Focus();
                    ShowMessage("Enter File Name", MessageType.Warning);
                    lblMsg.Text = "Enter File Name!";
                   // return;
                }
            }
            else
            {
                ShowMessage("select File", MessageType.Warning);
                lblMsg.Text = "select File!";
                // lblMessage.Text = "Please Select File";
                // return;
            }
        }
       
    }
    private void RegisterPostBackControl()
    {
        foreach (GridViewRow row in gvImages.Rows)
        {
            LinkButton lnkbtn = row.FindControl("lnkDownload") as LinkButton;
            ScriptManager.GetCurrent(this).RegisterPostBackControl(lnkbtn);


        }
    }
    protected void lnkDownload_Click(object sender, EventArgs e)
    {
        LinkButton lnkbtn = sender as LinkButton;
        GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;
        // this.RegisterPostBackControl();
        string filePath = gvImages.DataKeys[gvrow.RowIndex].Value.ToString();
        Response.ContentType = "image/jpg";
        Response.AddHeader("Content-Disposition", "attachment;filename=\"" + filePath + "\"");
        Response.TransmitFile(Server.MapPath(filePath));
        Response.End();
    }
    public void BindImages()
    {
        SqlConnection conn = DataAccess.ConInitForDC();
        conn.Open();

        using (SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM OPthoPatientFiles where PatRegId=" + Convert.ToInt32(Session["EmrRegNo"]), conn))
        {
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                UploadedFiles.Visible = true;
                gvImages.DataSource = dt;
                gvImages.DataBind();
            }
            else
            {
                UploadedFiles.Visible = false;

            }

        }
        conn.Close();
        conn.Dispose();

    }
    protected void gvImages_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int FileId = Convert.ToInt32(gvImages.DataKeys[e.RowIndex]["OPFileId"]);

        SqlConnection conn = DataAccess.ConInitForDC();
        conn.Open();


        SqlCommand cmd = new SqlCommand("Delete  OPthoPatientFiles where OPFileId=@OPFileId ", conn);
        cmd.Parameters.AddWithValue("@OPFileId", FileId);
        // cmd.Parameters.AddWithValue("@PatRegId", Convert.ToInt32(ViewState["PatientInfoId"]));
        /// cmd.Parameters.AddWithValue("@filename", filename);

        cmd.ExecuteNonQuery();
        conn.Close();
        conn.Dispose();
        // BindImages();

        //  string Message = objDALOpdReg.DeleteBillGroup(Convert.ToInt32(BillGroupId));

        // DynamicMessage(lblMessage, Message);

        BindImages();
        lblMsg.Text = "File delete successfulle!";
        ShowMessage("File delete successfulle!", MessageType.Error);
    }
}