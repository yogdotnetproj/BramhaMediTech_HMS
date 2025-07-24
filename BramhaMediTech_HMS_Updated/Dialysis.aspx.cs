using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Dialysis : BasePage
{
    clsEmr obj = new clsEmr();
    clsTreatment objTreat = new clsTreatment();
    clsTreatmentTransaction transaction = new clsTreatmentTransaction();
    BELIntakeOutputChart objBELIO = new BELIntakeOutputChart();
    DALInputOutPutChart objDALIO = new DALInputOutPutChart();
    Dialysis_C ObjDC = new Dialysis_C();
    protected void Page_PreInit(object sender, EventArgs e)
    {


        if (Convert.ToString(Request.QueryString["FormType"]) == "Nurse")
        {
            //Session["UID"] = "Drug";
            this.Page.MasterPageFile = "~/Hospital.master";
        }
        else
        {
            this.Page.MasterPageFile = "~/mainMaster.master";
        }
    }
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
                SetInitialRow();
               // lblOpd.Text = opd;
               // DateTime time = DateTime.Now;
               txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
               // String s = time.ToString("hh:mm tt");
               // txtTime.Text = s;  
               PindPatientInformation();
                BindPatientInformation();
                Get_AllDialysis_Data(Convert.ToInt32(Session["EmrRegNo"]));
              
            }
        }
    }

    public void PindPatientInformation()
    {
        DataTable dt = new DataTable();
        string patientregid = Convert.ToString(Request.QueryString["RegId"]);
        string opd = Convert.ToString(Request.QueryString["OpdNo"]);
        string ipd = Convert.ToString(Request.QueryString["IpdNo"]);

     //   objBELIpd.PatRegId = Convert.ToInt32(patientregid);
      //  objBELIpd.OpdNo = Convert.ToInt32(opd);
      //  objBELIpd.IpdId = Convert.ToInt32(ipd);
        dt = obj.Get_AllPatientInformation_EmrOPD(Convert.ToString(patientregid), Convert.ToString(opd), Convert.ToInt32(ipd), Convert.ToInt32(Session["Branchid"]));
        try
        {
            if (dt.Rows.Count>0)
            {
                listt2.Visible = true;
                listt1.Visible = true;
                lblPatientName.Text = Convert.ToString(dt.Rows[0]["PatientName"]);
                txtpatientregid.Text = Convert.ToString(dt.Rows[0]["PatRegId"]);
                // lblIpd.Text = "0";
                //lblOpd.Text = Convert.ToString(dt.Rows[0]["PatRegId"]);
                if (Convert.ToString(Session["EmrOpdNo"]) == "0")
                {
                    Div8.Visible = false;
                    Div7.Visible = true;
                    lblIpd.Text = Convert.ToString(dt.Rows[0]["IpdNo"]);
                    // IpdRmCat.Visible = true;

                    //  FillIpdPatInfo(Convert.ToInt32(Session["EmrRegNo"]), Convert.ToInt32(Session["EmrIpdNo"]));
                }
                else
                {
                    Div8.Visible = true;
                    Div7.Visible = false;
                    lblOpd.Text = Convert.ToString(dt.Rows[0]["OpdNo"]);
                    // IpdRmCat.Visible = false;

                }

                lblMobileNo.Text = Convert.ToString(dt.Rows[0]["MobileNo"]);
                lbldrname.Text = Convert.ToString(dt.Rows[0]["DrName"]);
                string Birthdate = Convert.ToString(dt.Rows[0]["BirthDate"]);
                Birthdate = DateTime.Parse(Birthdate).ToString("dd/MM/yyyy");
                Label6.Text = Birthdate;
                //  getAge(Birthdate);
                lblAge.Text = Convert.ToString(dt.Rows[0]["Age"]) + "" + Convert.ToString(dt.Rows[0]["AgeType"]) + "/" + Convert.ToString(dt.Rows[0]["GenderName"]);
               // lblAge.Text = lblAge.Text + "/" + Convert.ToString(dt.Rows[0]["GenderName"]);
                lblVisitingNo.Text = Convert.ToString(dt.Rows[0]["VisitingNo"]);
                lblToken.Text = Convert.ToString(dt.Rows[0]["TokenNo"]);
                lblDept.Text = Convert.ToString(dt.Rows[0]["DeptName"]);
                ViewState["DrId"] = Convert.ToInt32(dt.Rows[0]["DrId"]);


            }
        }
        catch (Exception ex)
        {

        }
    }
    public void Get_AllDialysis_Data(int Patregid)
    {

        DataTable dt = new DataTable();

        using (SqlConnection con = DataAccess.ConInitForDC())
        {
            using (SqlCommand cmd = new SqlCommand("usp_GetAll_Dialysis_Chart", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@PatRegId", Convert.ToInt32(Session["EmrRegNo"]));
                cmd.Parameters.AddWithValue("@OPDNo", Convert.ToInt32(Session["EmrOpdNo"]));
                cmd.Parameters.AddWithValue("@IPDNo", Convert.ToInt32(Session["EmrIpdNo"]));

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
            else
            {
                SetInitialRow();
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
        //gvDailyNurseNote.DataSource = dt;
        //gvDailyNurseNote.DataBind();
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

       // ObjDC.BranchId = Convert.ToInt32(Session["Branchid"]);

        ObjDC.P_EntryDate = Convert.ToDateTime(txtDate.Text);
        ObjDC.P_DialysisType = ddlType.SelectedItem.Text;
        ObjDC.P_Technician = txtTechnician.Text;
        ObjDC.P_Access = ddlAccess.SelectedItem.Text;
        ObjDC.P_Dialyzer = txtDialyzer.Text;
        ObjDC.P_Reused = ddlReused.SelectedItem.Text;
        ObjDC.P_Duration = txtduration.Text;
        ObjDC.P_HeparinDosage = txtHeparinDosage.Text;
        ObjDC.P_BloodFlow = txtBloodFlow.Text;
        ObjDC.P_UFRemoval = txtUfRemoval.Text;
        ObjDC.P_WeightPRE = txtweightPerHD.Text;

        ObjDC.P_PostHD = txtPostHD.Text;
        ObjDC.P_TimeStarted = txtTimeStarted.Text;
        ObjDC.P_TimeEnded = txtTimeEnded.Text;
        ObjDC.P_PrimingFluid = txtPrimingFluid.Text;
        ObjDC.P_DialysateFlow = txtDialysateFlow.Text;
        ObjDC.P_Diagnisis = txtDiagnisis.Text;
        ObjDC.P_ComplicationDuringHD = txtComplication.Text;
        ObjDC.P_OtherNotes = txtOtherNotes.Text;
        ObjDC.P_DoctorNotes = txtDoctorNotes.Text;

        if (ChkPulmonary.Checked == true)
        {
            ObjDC.P_PulmonaryOedema = true;
        }
        else
        {
            ObjDC.P_PulmonaryOedema = false;
        }

        if (ChkHypercalcemia.Checked == true)
        {
            ObjDC.P_Hypercalcemia = true;
        }
        else
        {
            ObjDC.P_Hypercalcemia = false;
        }

        if (ChkFluidOverload.Checked == true)
        {
            ObjDC.P_FluidOverload = true;
        }
        else
        {
            ObjDC.P_FluidOverload = false;
        }
        if (ChkEncephalopathy.Checked == true)
        {
            ObjDC.P_Encephalopathy = true;
        }
        else
        {
            ObjDC.P_Encephalopathy = false;
        }

        if (chkBleeding.Checked == true)
        {
            ObjDC.P_Bleeding = true;
        }
        else
        {
            ObjDC.P_Bleeding = false;
        }
        if (chkHypotension.Checked == true)
        {
            ObjDC.P_Hypotension = true;
        }
        else
        {
            ObjDC.P_Hypotension = false;
        }
        if (ChkHypertension.Checked == true)
        {
            ObjDC.P_Hypertension = true;
        }
        else
        {
            ObjDC.P_Hypertension = false;
        }
        if (ChkCramps.Checked == true)
        {
            ObjDC.P_Cramps = true;
        }
        else
        {
            ObjDC.P_Cramps = false;
        }
        if (ChkOther.Checked == true)
        {
            ObjDC.P_Others = true;
        }
        else
        {
            ObjDC.P_Others = false;
        }

        if (ChkSaline.Checked == true)
        {
            ObjDC.P_Saline = true;
        }
        else
        {
            ObjDC.P_Saline = false;
        }
        if (ChkFormaline.Checked == true)
        {
            ObjDC.P_FormalineH2O2 = true;
        }
        else
        {
            ObjDC.P_FormalineH2O2 = false;
        }
        if (ChkHyperchloride.Checked == true)
        {
            ObjDC.P_Hyperchloride = true;
        }
        else
        {
            ObjDC.P_Hyperchloride = false;
        }

        for (int i = 0; i < GvHairLaser.Rows.Count; i++)
        {

            //extract the TextBox values

            TextBox box1 = (TextBox)GvHairLaser.Rows[i].Cells[1].FindControl("txtTime");
            TextBox box2 = (TextBox)GvHairLaser.Rows[i].Cells[2].FindControl("txtBP");
            TextBox box3 = (TextBox)GvHairLaser.Rows[i].Cells[3].FindControl("txtPR");
            TextBox box4 = (TextBox)GvHairLaser.Rows[i].Cells[4].FindControl("txtTMP");

            TextBox box5 = (TextBox)GvHairLaser.Rows[i].Cells[5].FindControl("txtVP");
            TextBox box6 = (TextBox)GvHairLaser.Rows[i].Cells[6].FindControl("txtTemperature");
            TextBox box7 = (TextBox)GvHairLaser.Rows[i].Cells[7].FindControl("txtMedication");
            TextBox box8 = (TextBox)GvHairLaser.Rows[i].Cells[8].FindControl("txtRemark");

          
           
                ObjDC.P_DialysisTime = Convert.ToString(box1.Text);
                ObjDC.P_BP = box2.Text;
                ObjDC.P_PR = box3.Text;
                ObjDC.P_TMP = box4.Text;
                ObjDC.P_VP = box5.Text;
                ObjDC.P_Temperature = box6.Text;
                ObjDC.P_Medication= box7.Text;
                ObjDC.P_Remark = box8.Text;
               

                ObjDC.Insert_Dialysis_Chart();
           

        }



        Get_AllDialysis_Data(Convert.ToInt32(Session["EmrRegNo"]));

        //txtRemark.InnerText = "";
        //DateTime time = DateTime.Now;
        //txttimestart.Text = DateTime.Now.ToString("dd/MM/yyyy");
        //String s = time.ToString("hh:mm tt");
        //txtTime.Text = s;           
        //LblMSg.Text = Msg;
        LblMSg.ForeColor = System.Drawing.Color.Green;
        LblMSg.Text = "Record Save successfully!";



        //}
        //}
    }
   
    public void FillPage()
    {
        objBELIO = objDALIO.SelectDailyNurseNote(Convert.ToInt32(ViewState["NurseNoteId"]));
        //txttimestart.Text = Convert.ToDateTime(objBELIO.DateInput).ToString("dd/MM/yyyy");
        //txtTime.Text = Convert.ToString(objBELIO.TimeInput);
        //txtRemark.InnerText = objBELIO.Remark;
        //txtNurse.Text = objBELIO.UserName;
        int UserId = Convert.ToInt32(objBELIO.UserId);

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
        objDALIO.Alter_Vw_Dialysis_Report(objBELIO);
        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Report/Rpt_Rpt_DialysisReport.rpt");
        Session["reportname"] = "Rpt_DialysisReport";
        Session["RPTFORMAT"] = "pdf";

        //ReportParameterClass.SelectionFormula = sql;
        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);
    }

    private void SetInitialRow()
    {

        DataTable dt = new DataTable();

        DataRow dr = null;

        dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));

        dt.Columns.Add(new DataColumn("DialysisTime", typeof(string)));
        dt.Columns.Add(new DataColumn("BP", typeof(string)));
        dt.Columns.Add(new DataColumn("PR", typeof(string)));

        dt.Columns.Add(new DataColumn("TMP", typeof(string)));
        dt.Columns.Add(new DataColumn("VP", typeof(string)));
        dt.Columns.Add(new DataColumn("Temperature", typeof(string)));

        dt.Columns.Add(new DataColumn("Medication", typeof(string)));
       
        dt.Columns.Add(new DataColumn("Remark", typeof(string)));

        dr = dt.NewRow();

        dr["RowNumber"] = 1;

        dr["DialysisTime"] = string.Empty;
        dr["BP"] = string.Empty;
        dr["PR"] = string.Empty;

        dr["TMP"] = string.Empty;
        dr["VP"] = string.Empty;
        dr["Temperature"] = string.Empty;

        dr["Medication"] = string.Empty;
      
        dr["Remark"] = string.Empty;
        dt.Rows.Add(dr);

        dr = dt.NewRow();

        dr["RowNumber"] = 2;

        dr["DialysisTime"] = string.Empty;
        dr["BP"] = string.Empty;
        dr["PR"] = string.Empty;

        dr["TMP"] = string.Empty;
        dr["VP"] = string.Empty;
        dr["Temperature"] = string.Empty;

        dr["Medication"] = string.Empty;

        dr["Remark"] = string.Empty;
        dt.Rows.Add(dr);
        dr = dt.NewRow();

        dr["RowNumber"] = 3;

        dr["DialysisTime"] = string.Empty;
        dr["BP"] = string.Empty;
        dr["PR"] = string.Empty;

        dr["TMP"] = string.Empty;
        dr["VP"] = string.Empty;
        dr["Temperature"] = string.Empty;

        dr["Medication"] = string.Empty;

        dr["Remark"] = string.Empty;
        dt.Rows.Add(dr);
        dr = dt.NewRow();

        dr["RowNumber"] = 4;

        dr["DialysisTime"] = string.Empty;
        dr["BP"] = string.Empty;
        dr["PR"] = string.Empty;

        dr["TMP"] = string.Empty;
        dr["VP"] = string.Empty;
        dr["Temperature"] = string.Empty;

        dr["Medication"] = string.Empty;

        dr["Remark"] = string.Empty;
        dt.Rows.Add(dr);

        //Store the DataTable in ViewState

        ViewState["CurrentTable"] = dt;

        GvHairLaser.DataSource = dt;
        GvHairLaser.DataBind();

    }


    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int OPDNo = Convert.ToInt32(GridView1.DataKeys[e.NewEditIndex]["OPDNo"]);
        int IPDNo = Convert.ToInt32(GridView1.DataKeys[e.NewEditIndex]["IPDNo"]);
        ViewState["OPDNO"] = OPDNo;
        Get_Dialysis_Details(OPDNo, IPDNo);
        e.Cancel = true;
    }

    public void Get_Dialysis_Details(int OPDNO, int IPDNO)
    {

        DataTable dt = new DataTable();

        using (SqlConnection con = DataAccess.ConInitForDC())
        {
            using (SqlCommand cmd = new SqlCommand("usp_Get_Dialysis", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@PatRegId", Convert.ToInt32(Session["EmrRegNo"]));
                cmd.Parameters.AddWithValue("@OPDNO", Convert.ToInt32(Session["EmrOpdNo"]));
                cmd.Parameters.AddWithValue("@IPDNO", Convert.ToInt32(Session["EmrIpdNo"]));
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
                GvHairLaser.DataSource = dt;
                GvHairLaser.DataBind();
                txtDate.Text = Convert.ToString(dt.Rows[0]["EntryDate"]);
               

               // txtduration.Text = Convert.ToString(dt.Rows[0]["Duration"]);
               ddlType.SelectedItem.Text = Convert.ToString(dt.Rows[0]["DialysisType"]);
                txtTechnician.Text = Convert.ToString(dt.Rows[0]["Technician"]);
                ddlAccess.SelectedItem.Text = Convert.ToString(dt.Rows[0]["Access"]);
                 txtDialyzer.Text = Convert.ToString(dt.Rows[0]["Dialyzer"]);
                 ddlReused.SelectedItem.Text = Convert.ToString(dt.Rows[0]["Reused"]);
                txtduration.Text = Convert.ToString(dt.Rows[0]["Duration"]);
                 txtHeparinDosage.Text = Convert.ToString(dt.Rows[0]["HeparinDosage"]);
                txtBloodFlow.Text = Convert.ToString(dt.Rows[0]["BloodFlow"]);
                 txtUfRemoval.Text = Convert.ToString(dt.Rows[0]["UFRemoval"]);
                 txtweightPerHD.Text = Convert.ToString(dt.Rows[0]["WeightPRE"]);

                 txtPostHD.Text = Convert.ToString(dt.Rows[0]["PostHD"]);
                 txtTimeStarted.Text = Convert.ToString(dt.Rows[0]["TimeStarted"]);
                 txtTimeEnded.Text = Convert.ToString(dt.Rows[0]["TimeEnded"]);
                 txtPrimingFluid.Text = Convert.ToString(dt.Rows[0]["PrimingFluid"]);
                 txtDialysateFlow.Text = Convert.ToString(dt.Rows[0]["DialysateFlow"]);

                 txtDiagnisis.Text = Convert.ToString(dt.Rows[0]["Diagnisis"]);
                txtComplication.Text = Convert.ToString(dt.Rows[0]["ComplicationDuringHD"]);
                 txtOtherNotes.Text = Convert.ToString(dt.Rows[0]["OtherNotes"]);
                txtDoctorNotes.Text = Convert.ToString(dt.Rows[0]["DoctorNotes"]);


                if (Convert.ToBoolean( dt.Rows[0]["PulmonaryOedema"])==true)
                {
                    ChkPulmonary.Checked = true;
                }
                else
                {
                    ChkPulmonary.Checked = false;
                }

                if (Convert.ToBoolean( dt.Rows[0]["Hypercalcemia"])==true)
                {
                   ChkHypercalcemia.Checked = true;
                }
                else
                {
                    ChkHypercalcemia.Checked = false;
                }

                if (Convert.ToBoolean(dt.Rows[0]["FluidOverload"]) == true )
                {                  
                    ChkFluidOverload.Checked = true;
                }
                else
                {
                    ChkFluidOverload.Checked = true;
                }
                if (Convert.ToBoolean(dt.Rows[0]["Encephalopathy"]) == true  )
                {
                    ChkEncephalopathy.Checked = true;
                }
                else
                {
                    ChkEncephalopathy.Checked = false;
                }

                if (Convert.ToBoolean(dt.Rows[0]["Bleeding"]) == true)
                {
                    chkBleeding.Checked = true;
                }
                else
                {
                    chkBleeding.Checked = false;
                }
                if (Convert.ToBoolean(dt.Rows[0]["Hypotension"]) == true)
                {
                    chkHypotension.Checked =true;
                }
                else
                {
                    chkHypotension.Checked = false;
                }

                if (Convert.ToBoolean(dt.Rows[0]["Hypertension"]) == true)
                {
                    ChkHypertension.Checked = true;
                }
                else
                {
                    ChkHypertension.Checked = false;
                }


                if (Convert.ToBoolean(dt.Rows[0]["Cramps"]) == true)
                {
                    ChkCramps.Checked = true;
                }
                else
                {
                    ChkCramps.Checked = false;
                }

                if (Convert.ToBoolean(dt.Rows[0]["Others"]) == true)
                {
                    ChkOther.Checked = true;
                }
                else
                {
                    ChkOther.Checked = false;
                }

                if (Convert.ToBoolean(dt.Rows[0]["Saline"]) == true)
                {
                    ChkSaline.Checked = true;
                }
                else
                {
                    ChkSaline.Checked = false;
                }
                if (Convert.ToBoolean(dt.Rows[0]["FormalineH2O2"]) == true)
                {
                    ChkFormaline.Checked = true;
                }
                else
                {
                    ChkFormaline.Checked = false;
                }

                if (Convert.ToBoolean(dt.Rows[0]["Hyperchloride"]) == true)
                {
                    ChkHyperchloride.Checked = true;
                }
                else
                {
                    ChkHyperchloride.Checked = false;
                }
               



                ViewState["CurrentTable"] = dt;
            }
            else
            {
                SetInitialRow();
            }


        }
    }
}