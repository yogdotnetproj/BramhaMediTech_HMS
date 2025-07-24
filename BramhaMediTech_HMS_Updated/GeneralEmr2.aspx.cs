
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

public partial class GeneralEmr2 :BasePage
{
    clsEmr obj = new clsEmr();

    DataTable dt1 = new DataTable();
    DataTable dt2 = new DataTable();
    DataTable dt3 = new DataTable();

    DataTable dtChief = new DataTable();
    DataTable dtVitals = new DataTable();
    DataTable dtAllergies = new DataTable();
    DataTable dtMedical = new DataTable();
    DataTable dtSurgery = new DataTable();
    DataTable dtPastHis = new DataTable();
    DataTable dtPersHisl = new DataTable();
    DataTable dtFamHis = new DataTable();
    DataTable dtNote = new DataTable();
    DataTable dtDiagno = new DataTable();
    DataTable dtProvDiagno = new DataTable();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if (Session["EmrRegNo"]!="" )
            {
                string regId = Convert.ToString( Session["EmrRegNo"]);
                string name = Request.QueryString["Name"];
                string opd =  Convert.ToString( Session["EmrOpdNo"]);
                string entrydate = Request.QueryString["EntryDate"];
               // Session["Branchid"] = "1";

               // lblPatientName.Text = name;
               // txtpatientregid.Text = regId;
              
               // lblOpd.Text = opd;
                PindPatientInformation();
                BindMainGrid();
                BindAllGrids();
                //BindChief();
                //BindAllergy();
                //BindMedical();
                //BindVitals();

                BindChiefGrid();
                BindMedicalGrid();
                BindAllergyGrid();
                BindVitalsGrid();
                BindSurgeryGrid();
                BindPastGrid();
                BindPersHisGrid();
                BindFamHislGrid();
                BindNote();
                BindImages();
                GetRadios();

                BindPersonalRadioList();
                BindPastRadioList();
                BindFamilyRadioList();
                BindProvDiagno();
                BindDiagno();

                BindFormFields();
                BindFormFields_Notes();
            }
            else
            {
                Response.Redirect(string.Format("ListPatients.aspx"));
            }
            
        }
    }
    private void BindFormFields_Notes()
    {
        try
        {
            DataTable dt = GetRecords_Notes();
            if (dt != null && dt.Rows.Count > 0)
            {
                txtNote.Value = dt.Rows[0]["Note"].ToString();
            }
            else
            {
                txtNote.Value = "";
            }
        }
        catch (Exception ex)
        {
            ErrorMessage(ex.Message);
        }

    }
    private DataTable GetRecords_Notes()
    {
        string patientregid =  Convert.ToString( Session["EmrRegNo"]);
        string opd = Convert.ToString(Session["EmrOpdNo"]);
        string ipd = Convert.ToString(Session["EmrIpdNo"]);
        string branchid = Convert.ToString(Session["Branchid"]);

        DataTable dt = new DataTable();
        try
        {
            dt = obj.GetGeneralEmrDetailsEdit_Notes(patientregid, opd, ipd, branchid);
        }
        catch (Exception ex)
        {

        }
        return dt;
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

        using (SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM OPDPatientFiles where PatRegId=" + Convert.ToInt32(Session["EmrRegNo"]) + "  union all select MedicalId,Patregid,DocumentFileName,DocumentFilePath from AddMedicalRecord where PatRegId=" + Convert.ToInt32(Session["EmrRegNo"]), conn))
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
        int FileId = Convert.ToInt32(gvImages.DataKeys[e.RowIndex]["FileId"]);

        SqlConnection conn = DataAccess.ConInitForDC();
        conn.Open();


        SqlCommand cmd = new SqlCommand("Delete  OPDPatientFiles where FileId=@FileId ", conn);
        cmd.Parameters.AddWithValue("@FileId", FileId);
        // cmd.Parameters.AddWithValue("@PatRegId", Convert.ToInt32(ViewState["PatientInfoId"]));
        /// cmd.Parameters.AddWithValue("@filename", filename);

        cmd.ExecuteNonQuery();
        conn.Close();
        conn.Dispose();
        // BindImages();

        //  string Message = objDALOpdReg.DeleteBillGroup(Convert.ToInt32(BillGroupId));

        // DynamicMessage(lblMessage, Message);

        BindImages();
    }

    public void PindPatientInformation()
    {
        DataTable dt = new DataTable();
        dt = obj.Get_AllPatientInformation(Convert.ToString(Session["EmrRegNo"]), Convert.ToString(Session["EmrOpdNo"]), Convert.ToInt32(Session["EmrIpdNo"]), Convert.ToInt32(Session["Branchid"]));
        if (dt != null)
        {
            ViewState["PatientName"] = Convert.ToString(dt.Rows[0]["PatientName"]);
            txtAllergy.InnerText = dt.Rows[0]["Allergy"].ToString();
        }
        // dt = new DataTable();
         //dt = obj.Get_AllICDDiagnoName(Convert.ToInt32(Session["Branchid"]));
         //if (dt.Rows.Count > 0)
         //{
             //txticd11.DataSource = dt;
             //txticd11.DataTextField = "NewDiagName";
             //txticd11.DataValueField = "ICDID";
             //txticd11.DataBind();
         //}
    }
        //    try
    //    {
    //        if (dt != null)
    //        {
    //            lblPatientName.Text = Convert.ToString(dt.Rows[0]["PatientName"]);
    //            txtpatientregid.Text = Convert.ToString( dt.Rows[0]["PatRegId"]);
    //           // lblIpd.Text = "0";
    //            //lblOpd.Text = Convert.ToString(dt.Rows[0]["PatRegId"]);
    //            lblOpd.Text = Convert.ToString(dt.Rows[0]["OpdNo"]);
    //            lblMobileNo.Text = Convert.ToString(dt.Rows[0]["MobileNo"]);
    //            lbldrname.Text = Convert.ToString(dt.Rows[0]["DrName"]);
    //            string Birthdate = Convert.ToString(dt.Rows[0]["BirthDate"]);
    //            Birthdate = DateTime.Parse(Birthdate).ToString("dd/MM/yyyy");
    //            getAge(Birthdate);
    //            //lblAge.Text = Convert.ToString(dt.Rows[0]["Age"]) + "" + Convert.ToString(dt.Rows[0]["AgeType"]) + "/" + Convert.ToString(dt.Rows[0]["GenderName"]);
    //            lblAge.Text =lblAge.Text +"/" + Convert.ToString(dt.Rows[0]["GenderName"]);
    //            lblVisitingNo.Text = Convert.ToString(dt.Rows[0]["VisitingNo"]);
    //            lblToken.Text = Convert.ToString(dt.Rows[0]["TokenNo"]);
    //            lblDept.Text = Convert.ToString(dt.Rows[0]["DeptName"]);
    //            ViewState["DrId"] = Convert.ToInt32(dt.Rows[0]["DrId"]);
    //            lblAddress.Text = Convert.ToString(dt.Rows[0]["PatientAddress"]);
    //            Label6.Text = Birthdate;
    //            if (Convert.ToString(dt.Rows[0]["VaccinationStatus"]) != "")
    //            {
    //                lblVaccinationStatus.Text = "Vaccination Status:-"+Convert.ToString(dt.Rows[0]["VaccinationStatus"]);
    //            }
    //            else
    //            {
    //            }
                
    //        }
    //    }
    //    catch (Exception ex)
    //    {

    //    }
    //}
    //public void getAge(string Birthdate)
    //{
    //    int intYear, intMonth, intDays;
    //    DateTime Birthday = Convert.ToDateTime(Birthdate);
    //    intYear = Birthday.Year;
    //    intMonth = Birthday.Month;
    //    intDays = Birthday.Day;

    //    DateTime dtt = Convert.ToDateTime(Birthdate);

    //    DateTime td = DateTime.Now;
    //    int Leap_Year = 0;
    //    for (int i = dtt.Year; i < td.Year; i++)
    //    {
    //        if (DateTime.IsLeapYear(i))
    //        {
    //            ++Leap_Year;
    //        }
    //    }
    //    TimeSpan timespan = td.Subtract(Birthday);
    //    intDays = timespan.Days - Leap_Year;
    //    int intResult = 0;
    //    intYear = Math.DivRem(intDays, 365, out intResult);
    //    intMonth = Math.DivRem(intResult, 30, out intResult);
    //    intDays = intResult;
    //    if (intYear > 0)//&& intDays > 0
    //    {
    //        lblAge.Text = intYear.ToString() +" Years";
    //        //ddlAge.SelectedIndex = 0;
    //    }
    //    else if (intMonth > 0)
    //    {
    //        lblAge.Text = intMonth.ToString() + " Months";
    //        //ddlAge.SelectedIndex = 1;
    //    }
    //    else if (intDays > 0)
    //    {
    //        lblAge.Text = intDays.ToString()+ " Days";
    //       // ddlAge.SelectedIndex = 2;
    //    }
    //}
    private void GetRadios()
    {
        try
        {
            DataSet ds = obj.ReadDataHistoryList();

            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    dt1 = ds.Tables[0];
                    dt2 = ds.Tables[1];
                    dt3 = ds.Tables[2];
                }
            }
        }
        catch (Exception)
        {
        }
    }

    private void BindAllGrids()
    {
        try
        {
            string id = Convert.ToString(Session["EmrRegNo"]);
            DataSet ds = obj.ReadAllDetails(id);

            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    dtChief = ds.Tables[0];
                    dtAllergies = ds.Tables[1];
                    dtMedical = ds.Tables[2];
                    dtVitals = ds.Tables[3];
                    dtSurgery = ds.Tables[4];
                    dtPastHis = ds.Tables[5];
                    dtPersHisl = ds.Tables[6];
                    dtFamHis = ds.Tables[7];
                    dtNote = ds.Tables[8];
                    dtDiagno = ds.Tables[9];
                    dtProvDiagno = ds.Tables[10];
                }
            }
        }
        catch (Exception ex)
        {
        }
    }
    private void BindNote()
    {
       
        GVNote.DataSource = dtNote;
        GVNote.DataBind();
        GvNoteIngrid.DataSource = dtNote;
        GvNoteIngrid.DataBind();
        if (dtNote.Rows.Count > 0)
        {
            btnNote.ForeColor = System.Drawing.Color.White;
            btnNote.BackColor = System.Drawing.Color.Red;
            btnNote_Light.Visible = true;
        }
    }
    private void BindChiefGrid()
    {
        gvdChief.DataSource = dtChief;
        gvdChief.DataBind();
        if (dtChief.Rows.Count > 0)
        {
            btnChief1.ForeColor = System.Drawing.Color.White;
            btnChief1.BackColor = System.Drawing.Color.Red;
            btnChief1_light.Visible = true;
        }
    }
    private void BindSurgeryGrid()
    {
        gdvSurgery.DataSource = dtSurgery;
        gdvSurgery.DataBind();
        if (dtSurgery.Rows.Count > 0)
        {
            btnSurgical.ForeColor = System.Drawing.Color.White;
            btnSurgical.BackColor = System.Drawing.Color.Red;
            btnSurgical_light.Visible = true;
        }
    }
    private void BindPastGrid()
    {
        gdvPastHis.DataSource = dtPastHis;
        gdvPastHis.DataBind();
        if (dtPastHis.Rows.Count > 0)
        {
            btnPastHis.ForeColor = System.Drawing.Color.White;
            btnPastHis.BackColor = System.Drawing.Color.Red;
            btnPastHis_light.Visible = true;
        }
    }
    
    private void BindAllergyGrid()
    {
        gdvAllergy.DataSource = dtAllergies;
        gdvAllergy.DataBind();
        if (dtAllergies.Rows.Count > 0)
        {
            btnAllergy.ForeColor = System.Drawing.Color.White;
            btnAllergy.BackColor = System.Drawing.Color.Red;
            btnAllergy_Light.Visible = true;
        }
    }

    private void BindMedicalGrid()
    {
        gdvMedical.DataSource = dtMedical;
        gdvMedical.DataBind();
        if (dtMedical.Rows.Count > 0)
        {
            btnMedical.ForeColor = System.Drawing.Color.White;
            btnMedical.BackColor = System.Drawing.Color.Red;
            btnEmergency.Visible = true;
        }
    }

    private void BindPersHisGrid() 
    {
        gdvPers.DataSource = dtPersHisl;
        gdvPers.DataBind();
        if (dtPersHisl.Rows.Count > 0)
        {
            btnPersHis.ForeColor = System.Drawing.Color.White;
            btnPersHis.BackColor = System.Drawing.Color.Red;
            btnPersHis_light.Visible = true;
        }
    }
    private void BindFamHislGrid()
    {
        gdvFam.DataSource = dtFamHis;
        gdvFam.DataBind();
        if (dtFamHis.Rows.Count > 0)
        {
            btnFamHis.ForeColor = System.Drawing.Color.White;
            btnFamHis.BackColor = System.Drawing.Color.Red;
            btnFamHis_light.Visible = true;
        }
    }
    private void BindVitalsGrid()
    {
        gdvVital.DataSource = dtVitals;
        gdvVital.DataBind();
        if (dtVitals.Rows.Count > 0)
        {
            btnVitals.ForeColor = System.Drawing.Color.White;
            btnVitals.BackColor = System.Drawing.Color.Red;
            btnVitals_light.Visible = true;
        }
    }
    private void BindDiagno()
    {
        
        
        gvDiagno.DataSource = dtDiagno;
        gvDiagno.DataBind();
        if (dtDiagno.Rows.Count > 0)
        {
            
            btnDiagno.ForeColor = System.Drawing.Color.White;
            btnDiagno.BackColor = System.Drawing.Color.Red;
            btndiagno_light.Visible = true;
        }
    }
    private void BindProvDiagno()
    {

        gvProvDiagno.DataSource = dtProvDiagno;
        gvProvDiagno.DataBind();
        if (dtDiagno.Rows.Count > 0)
        {


            btnProvDiagno.ForeColor = System.Drawing.Color.White;
            btnProvDiagno.BackColor = System.Drawing.Color.Red;
            btnPd_light.Visible = true;
            
        }
    }
    private void BindPersonalRadioList()
    {
        for (int i = 0; i < dt2.Rows.Count; i++)
        {
            radioPersonal.Items.Add(new ListItem() { Text = dt2.Rows[i]["catName"].ToString(), Value = dt2.Rows[i]["catId"].ToString() });
        }
    }

    private void BindFamilyRadioList()
    {
        for (int i = 0; i < dt3.Rows.Count; i++)
        {
            radioFamily.Items.Add(new ListItem() { Text = dt3.Rows[i]["catName"].ToString(), Value = dt3.Rows[i]["catId"].ToString() });
        }
    }
    private void BindPastRadioList()
    {
        for (int i = 0; i < dt1.Rows.Count; i++)
        {
            radioPast.Items.Add(new ListItem() { Text = dt1.Rows[i]["catName"].ToString(), Value = dt1.Rows[i]["catId"].ToString() });
        }
    }
    protected void gvTempTable_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }

    public void BindMainGrid()
    {
        DataTable dt = null;// GetRecords();
        try
        {
            if (dt != null)
            {
                gvTempTable.DataSource = dt;
                gvTempTable.DataBind();
            }
        }
        catch (Exception ex)
        {

        }
    }

    private DataTable GetRecords()
    {
        string patientregid = Convert.ToString(Session["EmrRegNo"]);
        string opd = Convert.ToString(Session["EmrOpdNo"]);
        string ipd = Convert.ToString(Session["EmrIpdNo"]);
        string branchid = Convert.ToString( Session["Branchid"]);

        DataTable dt = new DataTable();
        try
        {
            dt = obj.GetGeneralEmrDetailsEdit(patientregid, opd, ipd, branchid);
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    private void BindFormFields()
    {
        try
        {
            DataTable dt = GetRecords();
            if (dt != null && dt.Rows.Count > 0)
            {
                txtTreatId.Value = dt.Rows[0]["EmrId"].ToString();

                txtChiefComplaints.Text = dt.Rows[0]["chiefcomplaints"].ToString();
              //  txtAllergy.InnerText = dt.Rows[0]["allergies"].ToString();
                txtMedicalHistory.InnerText = dt.Rows[0]["medicalhistory"].ToString();
                txtHeight.Text = dt.Rows[0]["ht"].ToString();
                txtWt.Text = dt.Rows[0]["wt"].ToString();
                txtPulse.Text = dt.Rows[0]["pulse"].ToString();
                txtBp.Text = dt.Rows[0]["bp"].ToString();
                txtResp.Text = dt.Rows[0]["resp"].ToString();
                txtSPO2.Text = dt.Rows[0]["spo2"].ToString();
                txtChest.Text = dt.Rows[0]["chest"].ToString();
                txtAn.Text = dt.Rows[0]["a"].ToString();
                txtPsp.Text = dt.Rows[0]["b"].ToString();
                txtPv.Text = dt.Rows[0]["c"].ToString();
                txtPa.Text = dt.Rows[0]["d"].ToString();
                txtOrd.Text = dt.Rows[0]["e"].ToString();
                txtCys.Text = dt.Rows[0]["e"].ToString();
                txtNote.Value = dt.Rows[0]["Note"].ToString();
                txtDiagnosis.Text = dt.Rows[0]["Diagnosis"].ToString();
                txtProvisionalDiagnosis.InnerText = dt.Rows[0]["ProvisionalDiagnosis"].ToString();

                txtRegistrationDate.Text = dt.Rows[0]["FollowUpDate"].ToString();

                string[] pastArray = !string.IsNullOrEmpty(dt.Rows[0]["pasthistory"].ToString()) ? dt.Rows[0]["pasthistory"].ToString().Split('$') : null;
                string[] personalArray = !string.IsNullOrEmpty(dt.Rows[0]["personalhistory"].ToString()) ? dt.Rows[0]["personalhistory"].ToString().Split('$') : null;
                string[] familyArray = !string.IsNullOrEmpty(dt.Rows[0]["familyhistory"].ToString()) ? dt.Rows[0]["familyhistory"].ToString().Split('$') : null;

                if (pastArray != null && pastArray.Length > 0 && radioPast.Items.Count > 0)
                {
                    foreach (ListItem item in radioPast.Items)
                    {
                        if (pastArray.Contains(item.Text))
                        {
                            item.Selected = true;
                        }
                    }
                }

                if (personalArray != null && personalArray.Length > 0 && radioPersonal.Items.Count > 0)
                {
                    foreach (ListItem item in radioPersonal.Items)
                    {
                        if (personalArray.Contains(item.Text))
                        {
                            item.Selected = true;
                        }
                    }
                }


                if (familyArray != null && familyArray.Length > 0 && radioFamily.Items.Count > 0)
                {
                    foreach (ListItem item in radioFamily.Items)
                    {
                        if (familyArray.Contains(item.Text))
                        {
                            item.Selected = true;
                        }
                    }
                }
                txtSurgicalHistory.InnerText = dt.Rows[0]["surgicalhistory"].ToString();
            }
        }
        catch (Exception ex)
        {
            ErrorMessage(ex.Message);
        }
    }
    private void ErrorMessage(string msg)
    {
        lblMsg.Text = msg; lblMsg.Visible = true; lblMsg.ForeColor = System.Drawing.Color.Red;
    }

    private void SuccessMessage(string msg)
    {
        lblMsg.Text = msg; lblMsg.Visible = true; lblMsg.ForeColor = System.Drawing.Color.Green;
    }
    protected void gvTempTable_RowEditing(object sender, GridViewEditEventArgs e)
    {
        e.Cancel = true;
    }

    protected void gvTempTable_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void gvdChief_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvdChief.PageIndex = e.NewPageIndex;
        BindChiefGrid();
        mp1.Show();
    }

    protected void gvdChief_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }

    protected void gvdChief_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void gvdChief_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }

    private void BindChief()
    {
        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[3] { new DataColumn("Id", typeof(int)),
                            new DataColumn("StartDate",typeof(string)), new DataColumn("Details",typeof(string)) });
        dt.Rows.Add(1, "1/1/2020", "United States");
        dt.Rows.Add(2, "11/1/2020", "India");
        dt.Rows.Add(3, "21/1/2020", "France");
        dt.Rows.Add(4, "31/1/2020", "Russia");
        gvdChief.DataSource = dt;
        gvdChief.DataBind();
    }

    private void BindAllergy()
    {
        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[3] { new DataColumn("Id", typeof(int)),
                            new DataColumn("StartDate",typeof(string)), new DataColumn("Details",typeof(string)) });
        dt.Rows.Add(1, "1/1/2020", "United States");
        dt.Rows.Add(2, "11/1/2020", "India");
        dt.Rows.Add(3, "21/1/2020", "France");
        dt.Rows.Add(4, "31/1/2020", "Russia");
        gdvAllergy.DataSource = dt;
        gdvAllergy.DataBind();
    }
    protected void gdvAllergy_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvAllergy.PageIndex = e.NewPageIndex;
        BindAllergyGrid();
        mp2.Show();
    }

    protected void gdvMedical_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvMedical.PageIndex = e.NewPageIndex;
        BindMedicalGrid();
        mp3.Show();
    }

    protected void gdvFam_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvFam.PageIndex = e.NewPageIndex;
        BindFamHislGrid();
        mp7.Show();
    }

    protected void gdvPers_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvPers.PageIndex = e.NewPageIndex;
        BindPersHisGrid();
        mp6.Show();
    }

    protected void gdvPastHis_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvPastHis.PageIndex = e.NewPageIndex;
        BindPastGrid();
        mp5.Show();
    }

    private void BindMedical()
    {
        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[3] { new DataColumn("Id", typeof(int)),
                            new DataColumn("StartDate",typeof(string)), new DataColumn("Details",typeof(string)) });
        dt.Rows.Add(1, "1/1/2020", "United States");
        dt.Rows.Add(2, "11/1/2020", "India");
        dt.Rows.Add(3, "21/1/2020", "France");
        dt.Rows.Add(4, "31/1/2020", "Russia");
        gdvMedical.DataSource = dt;
        gdvMedical.DataBind();
    }

    protected void gdvVital_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvVital.PageIndex = e.NewPageIndex;
        BindVitalsGrid();
        mp4.Show();
    }

    private void BindVitals()
    {
        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[3] { new DataColumn("Id", typeof(int)),
                            new DataColumn("StartDate",typeof(string)), new DataColumn("Details",typeof(string)) });
        dt.Rows.Add(1, "1/1/2020", "United States");
        dt.Rows.Add(2, "11/1/2020", "India");
        dt.Rows.Add(3, "21/1/2020", "France");
        dt.Rows.Add(4, "31/1/2020", "Russia");
        gdvVital.DataSource = dt;
        gdvVital.DataBind();
    }

    protected void gvTempTable_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string regId = Convert.ToString(Session["EmrRegNo"]);
            string opd = Convert.ToString(Session["EmrOpdNo"]);
            string ipd =  "0";
            string branch = Convert.ToString(Session["Branchid"]);
            string name = Convert.ToString( ViewState["PatientName"]);
            string entry =  DateTime.Now.ToString("dd/MM/yyyy");

            string createdby = Convert.ToString(Session["username"]); ;
            string createdon = DateTime.Now.ToString("dd/MM/yyyy");
            string updatedby = Convert.ToString(Session["username"]); ;
            string updatedon = DateTime.Now.ToString("dd/MM/yyyy");
            string chiefcomplaints = !string.IsNullOrEmpty(txtChiefComplaints.Text.ToString()) ? txtChiefComplaints.Text.ToString() : "";
            string allergies = !string.IsNullOrEmpty(txtAllergy.InnerText.ToString()) ? txtAllergy.InnerText.ToString() : "";
            string medicalhistory = !string.IsNullOrEmpty(txtMedicalHistory.InnerText.ToString()) ? txtMedicalHistory.InnerText.ToString() : "";
            string ht = !string.IsNullOrEmpty(txtHeight.Text) ? txtHeight.Text : "0";
            string wt = !string.IsNullOrEmpty(txtWt.Text) ? txtWt.Text : "0";
            string pulse = !string.IsNullOrEmpty(txtPulse.Text) ? txtPulse.Text : "0";
            string bp = !string.IsNullOrEmpty(txtBp.Text) ? txtBp.Text : "0";
            string resp = !string.IsNullOrEmpty(txtResp.Text) ? txtResp.Text : "0";
            string spo2 = !string.IsNullOrEmpty(txtSPO2.Text) ? txtSPO2.Text : "0";
            string chest = !string.IsNullOrEmpty(txtChest.Text) ? txtChest.Text : "0";
            string a = !string.IsNullOrEmpty(txtAn.Text) ? txtAn.Text : "0";
            string b = !string.IsNullOrEmpty(txtPsp.Text) ? txtPsp.Text : "0";
            string c = !string.IsNullOrEmpty(txtPv.Text) ? txtPv.Text : "0";
            string d = !string.IsNullOrEmpty(txtPa.Text) ? txtPa.Text : "0";
            string ee = !string.IsNullOrEmpty(txtOrd.Text) ? txtOrd.Text : "0";
            string surgicalhistory = !string.IsNullOrEmpty(txtSurgicalHistory.InnerText.ToString()) ? txtSurgicalHistory.InnerText.ToString() : "";

            string pastHis = txtPastHistory.Text.ToString();
            string persHis = txtPersonalHistory.Text.ToString();
            string famHis = txtFamilyHistory.Text.ToString();
            string Diagno = txtDiagnosis.Text.ToString();
            if (Diagno == "")
            {
                txtDiagnosis.Focus();                
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Enter Diagnois!!!');", true);
                return;
            }
            if (txtAllergy.InnerText == "")
            {
                txtAllergy.Focus();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Enter Allergy!!!');", true);
                return;
            }
            
                string FollowUpDate = txtRegistrationDate.Text;
            
            string ProvDiagno = txtProvisionalDiagnosis.InnerText.ToString();
            List<string> pastHistory = new List<string>();
            List<string> personalHistory = new List<string>();
            List<string> familyHistory = new List<string>();

            foreach (ListItem item in radioPast.Items)
            {
                pastHistory.Add(item.Text);
            }

            foreach (ListItem item in radioPersonal.Items)
            {
                personalHistory.Add(item.Text);
            }

            foreach (ListItem item in radioFamily.Items)
            {
                familyHistory.Add(item.Text);
            }

            string EmrId = txtTreatId.Value;
            int DrId = Convert.ToInt32(ViewState["DrId"]);
            string type = (string.IsNullOrEmpty(txtTreatId.Value) || txtTreatId.Value == "0") ? "1" : "2";
            string Note = !string.IsNullOrEmpty(txtNote.Value.ToString()) ? txtNote.Value.ToString() : "";
            int res = obj.SaveEmr(type, regId, name, ipd, opd, entry, branch, createdby, createdon, updatedby, updatedon,
                chiefcomplaints, allergies, medicalhistory, ht, wt, pulse, bp, resp, spo2, chest, a, b, c, d, ee, surgicalhistory,
                string.Join("$", pastHistory.ToArray()), string.Join("$", personalHistory.ToArray()), string.Join("$", familyHistory.ToArray()), EmrId, pastHis, persHis, famHis, Note, DrId, Diagno, ProvDiagno, FollowUpDate, txtICd11.Text);

            if (res > 0)
            {
                string msg = type == "1" ? "Saved successfully." : "Updated successfully.";
                SuccessMessage(msg);
                lblMsg.Text = "Record Save successfully!!";
                ClearFields();
                BindAllGrids();
                BindMainGrid();

                BindChiefGrid();
                BindMedicalGrid();
                BindAllergyGrid();
                BindSurgeryGrid();
                BindVitalsGrid();
                BindPastGrid();
                BindPersHisGrid();
                BindFamHislGrid();
                BindNote();
                BindDiagno();
                BindProvDiagno();
                btnSave.Text = "Save";
            }
            else
            {
                string msg = type == "-1" ? "Date and time not available" : "Failed to save";
                ErrorMessage(msg);
            }
        }
        catch (Exception ex)
        {
            ErrorMessage(ex.Message);
        }
    }

    private void ClearFields()
    {
        txtChiefComplaints.Text = "";
        txtAllergy.InnerText = "";
        txtMedicalHistory.InnerText = "";
        txtSurgicalHistory.InnerText = "";
        txtHeight.Text = "0";
        txtWt.Text = "0";
        txtResp.Text = "0";
        txtSPO2.Text = "0";
        txtPsp.Text = "0";
        txtPv.Text = "0";
        txtCys.Text = "0";
        txtPulse.Text = "0";
        txtBp.Text = "0";
        txtChest.Text = "0";
        txtAn.Text = "0";
        txtPa.Text = "0";
        txtOrd.Text = "0";

        txtPastHistory.Text = "";
        txtPersonalHistory.Text = "";
        txtFamilyHistory.Text = "";
        txtNote.Value = "";
        txtDiagnosis.Text = "";
        txtProvisionalDiagnosis.InnerText = "";

        foreach (ListItem item in radioPast.Items)
        {
            item.Selected = false;
        }
        foreach (ListItem item in radioPersonal.Items)
        {
            item.Selected = false;
        }
        foreach (ListItem item in radioFamily.Items)
        {
            item.Selected = false;
        }
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        ClearFields();
    }
    protected void gdvSurgery_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvSurgery.PageIndex = e.NewPageIndex;
        BindSurgeryGrid();
        mp8.Show();
    }
    protected void txtChiefComplaints_TextChanged(object sender, EventArgs e)
    {

    }
    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchComplant(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        return objDALOpdReg.FillAllChiefComplant(prefixText);
    }

    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchDiagnostics(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        return objDALOpdReg.FillSearchDiagnostics(prefixText);
    }

    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchDiagnostics_New(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        return objDALOpdReg.FillSearchDiagnostics_New(prefixText);
    }

    protected void GVNote_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }

    protected void GVNote_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void GVNote_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void GVNote_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVNote.PageIndex = e.NewPageIndex;
        BindNote();
        MPN.Show();
    }
    protected void GvNoteIngrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvNoteIngrid.PageIndex = e.NewPageIndex;
        BindNote(); 
        MPND.Show();
    }
    protected void gvProvDiagno_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvProvDiagno.PageIndex = e.NewPageIndex;
        BindProvDiagno();
        MPPdiagno.Show();
        
        
    }
    protected void gvDiagno_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDiagno.PageIndex = e.NewPageIndex;
        BindDiagno();
        MPdiagno.Show();
    }
}