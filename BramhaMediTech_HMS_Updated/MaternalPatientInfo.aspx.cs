using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

public partial class MaternalPatientInfo :BasePage
{
    BELDeliveryPage ObjMpf = new BELDeliveryPage();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            Get_All_Maternal_Data(Convert.ToInt32(Session["EmrRegNo"]),Convert.ToInt32(Session["EmrIpdNo"]));
        }

    }
    protected void btnSave_Click(object sender, EventArgs e)
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
            ObjMpf.OpdNo = Convert.ToInt32(Session["EmrOpdNo"]);
        }
        else
        {
            ObjMpf.OpdNo = 0;
        }
        if (Convert.ToString(Session["EmrIpdNo"]) != "")
        {
            ObjMpf.IpdNo = Convert.ToInt32(Session["EmrIpdNo"]);
            if (Convert.ToString(Session["PatAdmit"]) == "No")
            {
                LblMSg.ForeColor = System.Drawing.Color.Red;
                LblMSg.Text = "Patient already discharge!";
                return;
            }
        }
        else
        {
            ObjMpf.IpdNo = 0;
        }
        ObjMpf.Patregid = Convert.ToString(Session["EmrRegNo"]);
        ObjMpf.CreatedBy = Convert.ToString(Session["username"]);
        ObjMpf.UpdatedBy = Convert.ToString(Session["username"]);
        ObjMpf.FId = Convert.ToInt32(Session["FId"]); ;
        ObjMpf.BranchId = Convert.ToInt32(Session["Branchid"]);

        if(ChkSmokeNever.Checked==true)
        {
            ObjMpf.ISSmoking = 1;
        }
        if (ChkSmokePerDay.Checked == true)
        {
            ObjMpf.ISSmoking = 2;
        }
        if (ChkSmokePackPer.Checked == true)
        {
            ObjMpf.ISSmoking = 3;
        }
        if (ChkSmokePackPer1.Checked == true)
        {
            ObjMpf.ISSmoking = 4;
        }

        if (ChkAlcohol.Checked == true)
        {
            ObjMpf.IsAlcohol = 1;
        }
        if (ChkOccasionally.Checked == true)
        {
            ObjMpf.IsAlcohol = 2;
        }
        if (ChkHeavyDrinks.Checked == true)
        {
            ObjMpf.IsAlcohol = 3;
        }
        if (ChkRecrelDrugs.Checked == true)
        {
            ObjMpf.RecreationalDrugs = 1;
        }
        if (ChkRecreDrugsOccasionally.Checked == true)
        {
            ObjMpf.RecreationalDrugs = 2;
        }
        if (ChkRecreDrugReg.Checked == true)
        {
            ObjMpf.RecreationalDrugs = 3;
        }
        ObjMpf.Allergise = txtAllergies.Text;
        ObjMpf.ChiefComplaints = txtChiefComplaints.Text;
        ObjMpf.FoodPreferences = txtFoodPreferences.Text;
        if (chklowerAbPain.Checked == true)
        {
            ObjMpf.IsLowerabdominalpains = true;
        }
        if (ChkRegulContra.Checked == true)
        {
            ObjMpf.IsContractions = true;
        }
        if (ChkBleedingShow.Checked == true)
        {
            ObjMpf.IsBleeding = true;
        }
        if (ChkHeavybleeding.Checked == true)
        {
            ObjMpf.IsHeavybleeding = true;
        }
        if (ChkDrainingliquor.Checked == true)
        {
            ObjMpf.isDrainingliquor = true;
        }
        ObjMpf.Lowerabdominalpains = txtlowerAbPain.Text;
        ObjMpf.Contractions = txRegulContra.Text;
        ObjMpf.Bleeding = txtBleedingShow.Text;
        ObjMpf.Heavybleeding = txtHeavybleeding.Text;
        ObjMpf.Drainingliquor = txtDrainingliquor.Text;
        if (ChkHealthylooking.Checked == true)
        {
            ObjMpf.ExaminationFinding = 1;
        }
        if (ChkSicklooking.Checked == true)
        {
            ObjMpf.ExaminationFinding = 2;
        }
        if (ChkEdematousslight.Checked == true)
        {
            ObjMpf.ExaminationFinding = 3;
        }
        if (ChkEdematoussevere.Checked == true)
        {
            ObjMpf.ExaminationFinding = 4;
        }

        ObjMpf.Heightoffundus = txtheightoffunds.Text;
        ObjMpf.Presentingpart = txtPresentingPart.Text;
        ObjMpf.Fetalheart = txtFetalheart.Text;
        if (ChkEstablishedlabor.Checked == true)
        {
            ObjMpf.Establishedlaborr = true;
        }
        if (ChkNotinlabor.Checked == true)
        {
            ObjMpf.Notinlabor = true;
        }
        ObjMpf.AntenatalClinic = txtAntenatalClinic.Text;
        ObjMpf.ClinicCardseen = rblcardSeen.SelectedValue;
        if (ChkHb.Checked == true)
        {
            ObjMpf.Hb = true;
        }
        if (ChkBloodsugar.Checked == true)
        {
            ObjMpf.BloodSugar = true;
        }
        if (ChkVDRL.Checked == true)
        {
            ObjMpf.VDRL = true;
        }
        if (ChkSicklingTest.Checked == true)
        {
            ObjMpf.SicklingTest = true;
        }
        if (ChkHiv.Checked == true)
        {
            ObjMpf.HIV = true;
        }
        if (ChkHepB.Checked == true)
        {
            ObjMpf.HepB = true;
        }
        if (ChkSullivan.Checked == true)
        {
            ObjMpf.SullivanTest = true;
        }

        ObjMpf.HbResult = txtHB.Text;
        ObjMpf.HIVResult = txtHIV.Text;
        ObjMpf.BloodSugarResult = txtBloodSugar.Text;
        ObjMpf.VDRLResult = txtVDRL.Text;
        ObjMpf.SullivanTestResult = txtSullivan.Text;
        ObjMpf.HepBResult = txtHepB.Text;
        ObjMpf.SicklingTestResult = txtSicklingTest.Text;

        if (txtLMP.Text.Trim() != "")
        {
            ObjMpf.LMP = Convert.ToDateTime( txtLMP.Text);
        }
        ObjMpf.EDD = Convert.ToString(txtEDD.Text);
        ObjMpf.GestationalTest = Convert.ToString(txtGestationalTest.Text);

        if (ChkAncbef14.Checked == true)
        {
            ObjMpf.ANCVisit = true;
        }
        if (ChkAncbef20.Checked == true)
        {
            ObjMpf.ANCVisit1 = true;
        }
        if (ChkAncaft20.Checked == true)
        {
            ObjMpf.ANCVisit2 = true;
        }

        if (ChkUltrabef14.Checked == true)
        {
            ObjMpf.Ultrasound = true;
        }
        if (ChkUltraft14.Checked == true)
        {
            ObjMpf.Ultrasound1 = true;
        }
        if (ChkUltraaft20.Checked == true)
        {
            ObjMpf.Ultrasound2 = true;
        }
        ObjMpf.Parity = txtParity.Text;
        ObjMpf.NumberofAbortion = txtnumberofAbortion.Text;
        ObjMpf.Numberofmiscarriages = txtnumberofmiscarriages.Text;
        ObjMpf.Numberofchildrenalive = txtnumberofchild.Text;
        ObjMpf.PreviousPregancies = txtPreviousPre.Text;
        if (txtdate1.Text.Trim() != "")
        {
            ObjMpf.Date1 = Convert.ToDateTime( txtdate1.Text);
        }
        ObjMpf.Gestationalage1 = txtGestationalage1.Text;
        ObjMpf.TypeofDelivery1 = txttypeodDeliv1.Text;
        ObjMpf.Alive1 = txtalive1.Text;

        if (txtdate2.Text.Trim() != "")
        {
            ObjMpf.Date2 = Convert.ToDateTime(txtdate2.Text);
        }
        ObjMpf.Gestationalage2 = txtGestationalage2.Text;
        ObjMpf.TypeofDelivery2 = txttypeodDeliv2.Text;
        ObjMpf.Alive2 = txtalive2.Text;

        if (txtdate3.Text.Trim() != "")
        {
            ObjMpf.Date3 = Convert.ToDateTime(txtdate3.Text);
        }
        ObjMpf.Gestationalage3 = txtGestationalage3.Text;
        ObjMpf.TypeofDelivery3 = txttypeodDeliv3.Text;
        ObjMpf.Alive3 = txtalive3.Text;

        if (txtdate4.Text.Trim() != "")
        {
            ObjMpf.Date4 = Convert.ToDateTime(txtdate4.Text);
        }
        ObjMpf.Gestationalage4 = txtGestationalage4.Text;
        ObjMpf.TypeofDelivery4 = txttypeodDeliv4.Text;
        ObjMpf.Alive4 = txtalive4.Text;

        if (ChkPMHHypertension.Checked == true)
        {
            ObjMpf.PMHHypertension = true;
        }
        if (ChkPMHDiabetes.Checked == true)
        {
            ObjMpf.PMHDiabetes = true;
        }
        if (CHKPMHSickle.Checked == true)
        {
            ObjMpf.PMHSickleCellDisease = true;
        }
        if (ChkPMHAsthma.Checked == true)
        {
            ObjMpf.PMHAsthma = true;
        }
        if (ChkPMHThyroid.Checked == true)
        {
            ObjMpf.PMHThyroiddisease = true;
        }
        if (ChkPMHEpilepsy.Checked == true)
        {
            ObjMpf.PMHEpilepsy = true;
        }
        if (ChkPMHHepatitis.Checked == true)
        {
            ObjMpf.PMHHepatitis = true;
        }
        if (ChkPMHKidneyDisease.Checked == true)
        {
            ObjMpf.PMHKidneyDisease = true;
        }
        if (ChkPMHHiv.Checked == true)
        {
            ObjMpf.PMHHIV = true;
        }

        if (ChkFHHypertension.Checked == true)
        {
            ObjMpf.FHHypertension = true;
        }
        if (ChkFHDiabetes.Checked == true)
        {
            ObjMpf.FHDiabetes = true;
        }
        if (CHKFHSickle.Checked == true)
        {
            ObjMpf.FHSickleCellDisease = true;
        }
        if (ChkFHAsthma.Checked == true)
        {
            ObjMpf.FHAsthma = true;
        }
        if (ChkFHThyroid.Checked == true)
        {
            ObjMpf.FHThyroiddisease = true;
        }
        if (ChkFHEpilepsy.Checked == true)
        {
            ObjMpf.FHEpilepsy = true;
        }
        if (ChkFHHepatitis.Checked == true)
        {
            ObjMpf.FHHepatitis = true;
        }
        if (ChkFHKidneyDisease.Checked == true)
        {
            ObjMpf.FHKidneyDisease = true;
        }
        if (ChkFHHiv.Checked == true)
        {
            ObjMpf.FHHIV = true;
        }

        ObjMpf.Insert_MaternalPatientInfo();
        LblMSg.Text = "Record Save successfully";
        LblMSg.ForeColor = System.Drawing.Color.Green;
        Get_All_Maternal_Data(Convert.ToInt32(Session["EmrRegNo"]), Convert.ToInt32(Session["EmrIpdNo"]));
        clear();
    }
    public void clear()
    {
        txtHB.Text = "";
        txtHepB.Text = "";
        txtHIV.Text = "";
        txtVDRL.Text = "";
        txtSicklingTest.Text = "";
        txtSullivan.Text = "";

        txtalive1.Text = "";
        txtalive2.Text = "";
        txtalive3.Text = "";
        txtalive4.Text = "";
        txtAllergies.Text = "";
        txtAntenatalClinic.Text = "";
        txtBleedingShow.Text = "";
        txtChiefComplaints.Text = "";
        txtdate1.Text = "";
        txtdate2.Text = "";
        txtdate3.Text = "";
        txtdate4.Text = "";
        txtDrainingliquor.Text = "";
        txtEDD.Text = "";
        txtFetalheart.Text = "";
        txtFoodPreferences.Text = "";
        txtGestationalage1.Text = "";
        txtGestationalage2.Text = "";
        txtGestationalage3.Text = "";
        txtGestationalage4.Text = "";
        txtGestationalTest.Text = "";
        txtHeavybleeding.Text = "";
        txtheightoffunds.Text = "";
        txtLMP.Text = "";
        txtlowerAbPain.Text = "";
        txtnumberofAbortion.Text = "";
        txtnumberofchild.Text = "";
        txtnumberofmiscarriages.Text = "";
        txtParity.Text = "";
        txtPresentingPart.Text = "";
        txtPreviousPre.Text = "";
        txttypeodDeliv1.Text = "";
        txttypeodDeliv2.Text = "";
        txttypeodDeliv3.Text = "";
        txttypeodDeliv4.Text = "";
        
    }
    protected void btnReport_Click(object sender, EventArgs e)
    {
       SqlConnection conn21 = DataAccess.ConInitForDC();
        SqlCommand sc21 = conn21.CreateCommand();
        sc21.CommandText = "ALTER VIEW [dbo].[VW_Maternal_PatientInformation] AS (SELECT        Maternal_PatientInformation.InfoId, Maternal_PatientInformation.Patregid, Maternal_PatientInformation.OpdNo, Maternal_PatientInformation.IpdNo, Maternal_PatientInformation.ISSmoking, Maternal_PatientInformation.IsAlcohol, "+
             "   Maternal_PatientInformation.RecreationalDrugs, Maternal_PatientInformation.Allergise, Maternal_PatientInformation.FoodPreferences, Maternal_PatientInformation.ChiefComplaints, "+
             "   Maternal_PatientInformation.IsLowerabdominalpains, Maternal_PatientInformation.Lowerabdominalpains, Maternal_PatientInformation.IsContractions, Maternal_PatientInformation.Contractions, "+
             "   Maternal_PatientInformation.IsBleeding, Maternal_PatientInformation.Bleeding, Maternal_PatientInformation.IsHeavybleeding, Maternal_PatientInformation.Heavybleeding, Maternal_PatientInformation.isDrainingliquor, "+
             "   Maternal_PatientInformation.Drainingliquor, Maternal_PatientInformation.ExaminationFinding, Maternal_PatientInformation.Heightoffundus, Maternal_PatientInformation.Presentingpart, Maternal_PatientInformation.Fetalheart, "+
             "   Maternal_PatientInformation.Establishedlabor, Maternal_PatientInformation.Notinlabor, Maternal_PatientInformation.AntenatalClinic, Maternal_PatientInformation.ClinicCardseen, Maternal_PatientInformation.Hb, "+
             "   Maternal_PatientInformation.BloodSugar, Maternal_PatientInformation.VDRL, Maternal_PatientInformation.SicklingTest, Maternal_PatientInformation.HIV, Maternal_PatientInformation.HepB, "+
             "   Maternal_PatientInformation.SullivanTest, Maternal_PatientInformation.LMP, Maternal_PatientInformation.EDD, Maternal_PatientInformation.GestationalTest, Maternal_PatientInformation.ANCVisit, "+
             "   Maternal_PatientInformation.ANCVisit1, Maternal_PatientInformation.ANCVisit2, Maternal_PatientInformation.Ultrasound, Maternal_PatientInformation.Ultrasound1, Maternal_PatientInformation.Ultrasound2, "+
             "   Maternal_PatientInformation.Parity, Maternal_PatientInformation.NumberofAbortion, Maternal_PatientInformation.Numberofmiscarriages, Maternal_PatientInformation.Numberofchildrenalive, "+
             "   Maternal_PatientInformation.PreviousPregancies, Maternal_PatientInformation.Date1, Maternal_PatientInformation.Gestationalage1, Maternal_PatientInformation.TypeofDelivery1, Maternal_PatientInformation.Alive1, "+
             "   Maternal_PatientInformation.Date2, Maternal_PatientInformation.Gestationalage2, Maternal_PatientInformation.TypeofDelivery2, Maternal_PatientInformation.Alive2, Maternal_PatientInformation.Date3, "+
             "   Maternal_PatientInformation.Gestationalage3, Maternal_PatientInformation.TypeofDelivery3, Maternal_PatientInformation.Alive3, Maternal_PatientInformation.Date4, Maternal_PatientInformation.Gestationalage4, "+
             "   Maternal_PatientInformation.TypeofDelivery4, Maternal_PatientInformation.Alive4, Maternal_PatientInformation.PMHHypertension, Maternal_PatientInformation.PMHDiabetes, "+
             "   Maternal_PatientInformation.PMHSickleCellDisease, Maternal_PatientInformation.PMHAsthma, Maternal_PatientInformation.PMHThyroiddisease, Maternal_PatientInformation.PMHEpilepsy, "+
             "   Maternal_PatientInformation.PMHHepatitis, Maternal_PatientInformation.PMHKidneyDisease, Maternal_PatientInformation.PMHHIV, Maternal_PatientInformation.FHHypertension, Maternal_PatientInformation.FHDiabetes, "+
             "   Maternal_PatientInformation.FHSickleCellDisease, Maternal_PatientInformation.FHAsthma, Maternal_PatientInformation.FHThyroiddisease, Maternal_PatientInformation.FHEpilepsy, Maternal_PatientInformation.FHHepatitis, "+
             "   Maternal_PatientInformation.FHKidneyDisease, Maternal_PatientInformation.FHHIV, Maternal_PatientInformation.BranchId, Maternal_PatientInformation.CreatedBy, Maternal_PatientInformation.CreatedOn, "+
             "   Maternal_PatientInformation.UpdatedBy, Maternal_PatientInformation.UpdatedOn, Maternal_PatientInformation.FID, PatientInformation.FirstName, Gender.GenderName, PatientInformation.MobileNo, PatientInformation.PhoneNo, "+
             "   PatientInformation.PatientAddress, PatientInformation.Age, PatientInformation.AgeType "+
             "   FROM            Maternal_PatientInformation INNER JOIN "+
             "   PatientInformation ON Maternal_PatientInformation.Patregid = PatientInformation.PatRegId INNER JOIN "+
             "   Gender ON PatientInformation.GenderId = Gender.GenderId  " +
                      "Where 1=1";
        sc21.CommandText += " and Maternal_PatientInformation.Patregid ='" + Convert.ToString(Session["EmrRegNo"]) + "' and Maternal_PatientInformation.IPDNo= '" + Convert.ToString(Session["EmrIPDNo"]) + "'";
        //if (fromdate.Text != "")
        //{
        //    sc21.CommandText += " and (CAST(CAST(YEAR(RecM.transdate) AS varchar(4)) + '/' + CAST(MONTH(RecM.transdate) AS varchar(2)) + '/' + CAST(DAY(RecM.transdate) AS varchar(2)) AS datetime))  between ('" + Convert.ToDateTime(fromdate.Text).ToString("MM/dd/yyyy") + "') and ('" + Convert.ToDateTime(todate.Text).ToString("MM/dd/yyyy") + "')";// 
        //}

        //if (ddlusername.SelectedIndex > 0)
        //{
        //    sc21.CommandText += " and RecM.username='" + ddlusername.SelectedItem.Text.Trim() + "'";
        //}
        sc21.CommandText += ")";

        conn21.Open();
        try
        {
            sc21.ExecuteNonQuery();
        }
        catch (Exception) { }
        conn21.Close(); conn21.Dispose();
       

        string sql = "";
        ReportParameterClass.ReportType = "DailyCashSum";


        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/DiagnosticReport/Rpt_Maternal_PatientInformation.rpt");
        Session["reportname"] = "Maternal_PatientInformation";
        Session["RPTFORMAT"] = "pdf";
       // Session["Parameter"] = "Yes";
      //  Session["rptDate"] = fromdate.Text + "  To  " + todate.Text;
      //  Session["rptusername"] = Convert.ToString(Session["username"]);


        ReportParameterClass.SelectionFormula = sql;
        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);

    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int InfoId = Convert.ToInt32((GridView1.DataKeys[e.NewEditIndex]["InfoId"]));
        ViewState["InfoId"] = InfoId;
        Get_All_Maternal_Data_Edit(Convert.ToInt32(Session["EmrRegNo"]), Convert.ToInt32(Session["EmrIpdNo"]), InfoId);
        e.Cancel = true;
    }
   
    public void Get_All_Maternal_Data(int Patregid,int IpdNo)
    {

        DataTable dt = new DataTable();

        using (SqlConnection con = DataAccess.ConInitForDC())
        {
            using (SqlCommand cmd = new SqlCommand("SP_GetMaternal_PatientInformationData", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@PatRegId", Convert.ToInt32(Session["EmrRegNo"]));
                cmd.Parameters.AddWithValue("@IPDNo", Convert.ToInt32(IpdNo));

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


    public void Get_All_Maternal_Data_Edit(int Patregid, int IpdNo, int InfoId)
    {

        DataTable dt = new DataTable();

        using (SqlConnection con = DataAccess.ConInitForDC())
        {
            using (SqlCommand cmd = new SqlCommand("SP_GetMaternal_PatientInformationData_Edit", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@PatRegId", Convert.ToInt32(Session["EmrRegNo"]));
                cmd.Parameters.AddWithValue("@IPDNo", Convert.ToInt32(IpdNo));
                cmd.Parameters.AddWithValue("@InfoId", Convert.ToInt32(InfoId));

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
                if (Convert.ToString(dt.Rows[0]["ISSmoking"]) == "1")
                {
                    ChkSmokeNever.Checked = true;
                }

                if (Convert.ToString(dt.Rows[0]["ISSmoking"]) == "2")
                {
                    ChkSmokePerDay.Checked = true;
                }
                if (Convert.ToString(dt.Rows[0]["ISSmoking"]) == "3")
                {
                    ChkSmokePackPer.Checked = true;
                }
                if (Convert.ToString(dt.Rows[0]["ISSmoking"]) == "4")
                {
                    ChkSmokePackPer1.Checked = true;
                }


                if (Convert.ToString(dt.Rows[0]["IsAlcohol"]) == "1")
                {
                    ChkAlcohol.Checked = true;
                }
                if (Convert.ToString(dt.Rows[0]["IsAlcohol"]) == "2")
                {
                    ChkOccasionally.Checked = true;
                }
                if (Convert.ToString(dt.Rows[0]["IsAlcohol"]) == "3")
                {
                    ChkHeavyDrinks.Checked = true;
                }

                if (Convert.ToString(dt.Rows[0]["RecreationalDrugs"]) == "1")
                {
                    ChkRecrelDrugs.Checked = true;
                }

                if (Convert.ToString(dt.Rows[0]["RecreationalDrugs"]) == "2")
                {
                    ChkRecreDrugsOccasionally.Checked = true;
                }
                if (Convert.ToString(dt.Rows[0]["RecreationalDrugs"]) == "3")
                {
                    ChkRecreDrugReg.Checked = true;
                }


                 txtAllergies.Text = Convert.ToString(dt.Rows[0]["Allergise"]);
                 txtChiefComplaints.Text = Convert.ToString(dt.Rows[0]["FoodPreferences"]);
                 txtFoodPreferences.Text = Convert.ToString(dt.Rows[0]["ChiefComplaints"]);
                //-----------------------------------------------------------------------------
                 if (Convert.ToBoolean(dt.Rows[0]["IsLowerabdominalpains"]) == true)
                {
                    chklowerAbPain.Checked = true;
                }
                if (Convert.ToBoolean(dt.Rows[0]["IsContractions"]) == true)
                {
                    ChkRegulContra.Checked = true;
                }

                if (Convert.ToBoolean(dt.Rows[0]["IsBleeding"]) == true)
                {
                    ChkBleedingShow.Checked = true;
                }
                if (Convert.ToBoolean(dt.Rows[0]["IsHeavybleeding"]) == true)
                {
                    ChkHeavybleeding.Checked = true;
                }

                if (Convert.ToBoolean(dt.Rows[0]["isDrainingliquor"]) == true)
                {
                    ChkDrainingliquor.Checked = true;
                }


                txtlowerAbPain.Text = Convert.ToString(dt.Rows[0]["Lowerabdominalpains"]);
                txRegulContra.Text = Convert.ToString(dt.Rows[0]["Contractions"]);
                txtBleedingShow.Text = Convert.ToString(dt.Rows[0]["Bleeding"]);
                txtHeavybleeding.Text = Convert.ToString(dt.Rows[0]["Heavybleeding"]);
                txtDrainingliquor.Text = Convert.ToString(dt.Rows[0]["Drainingliquor"]);

                if (Convert.ToString(dt.Rows[0]["ExaminationFinding"]) == "1")
                {
                    ChkHealthylooking.Checked = true;
                }
                if (Convert.ToString(dt.Rows[0]["ExaminationFinding"]) == "2")
                {
                    ChkSicklooking.Checked = true;
                }
                if (Convert.ToString(dt.Rows[0]["ExaminationFinding"]) == "3")
                {
                    ChkEdematousslight.Checked = true;
                }
                if (Convert.ToString(dt.Rows[0]["ExaminationFinding"]) == "4")
                {
                    ChkEdematoussevere.Checked = true;
                }



                txtheightoffunds.Text = Convert.ToString(dt.Rows[0]["Heightoffundus"]);
                txtPresentingPart.Text = Convert.ToString(dt.Rows[0]["Presentingpart"]);
                txtFetalheart.Text = Convert.ToString(dt.Rows[0]["Fetalheart"]);

               

                if (Convert.ToBoolean(dt.Rows[0]["Establishedlabor"]) == true)
                {
                    ChkEstablishedlabor.Checked = true;
                }
                if (Convert.ToBoolean(dt.Rows[0]["Notinlabor"]) == true)
                {
                    ChkNotinlabor.Checked = true;
                }


                 txtAntenatalClinic.Text = Convert.ToString(dt.Rows[0]["AntenatalClinic"]);

                 if (Convert.ToString(dt.Rows[0]["ClinicCardseen"]) == "Yes")
                 {
                     rblcardSeen.SelectedValue = "Yes";
                 }
                 else
                 {
                     rblcardSeen.SelectedValue = "No";
                 }

                 if (Convert.ToBoolean(dt.Rows[0]["Hb"]) == true)
                 {
                     ChkHb.Checked = true;
                 }
                 if (Convert.ToBoolean(dt.Rows[0]["BloodSugar"]) == true)
                 {
                     ChkBloodsugar.Checked = true;
                 }
                 if (Convert.ToBoolean(dt.Rows[0]["VDRL"]) == true)
                 {
                     ChkVDRL.Checked = true;
                 }
                 if (Convert.ToBoolean(dt.Rows[0]["SicklingTest"]) == true)
                 {
                     ChkSicklingTest.Checked = true;
                 }
                 if (Convert.ToBoolean(dt.Rows[0]["HIV"]) == true)
                 {
                     ChkHiv.Checked = true;
                 }
                 if (Convert.ToBoolean(dt.Rows[0]["HepB"]) == true)
                 {
                     ChkHepB.Checked = true;
                 }
                 if (Convert.ToBoolean(dt.Rows[0]["SullivanTest"]) == true)
                 {
                     ChkSullivan.Checked = true;
                 }



                 txtHB.Text = Convert.ToString(dt.Rows[0]["HbResult"]);
                 txtHIV.Text = Convert.ToString(dt.Rows[0]["BloodSugarResult"]);
                 txtBloodSugar.Text = Convert.ToString(dt.Rows[0]["VDRLResult"]);
                 txtVDRL.Text = Convert.ToString(dt.Rows[0]["HIVResult"]);
                 txtSullivan.Text = Convert.ToString(dt.Rows[0]["SullivanTestResult"]);
                 txtHepB.Text = Convert.ToString(dt.Rows[0]["HepBResult"]);
                 txtSicklingTest.Text = Convert.ToString(dt.Rows[0]["SicklingTestResult"]);

                 if (Convert.ToString(dt.Rows[0]["LMP"]) != "")
                 {
                     txtLMP.Text = Convert.ToString(dt.Rows[0]["LMP"]);
                 }

                 txtEDD.Text = Convert.ToString(dt.Rows[0]["EDD"]);
                 txtGestationalTest.Text = Convert.ToString(dt.Rows[0]["GestationalTest"]);

                 if (Convert.ToBoolean(dt.Rows[0]["ANCVisit"]) == true)
                 {
                     ChkAncbef14.Checked = true;
                 }
                 if (Convert.ToBoolean(dt.Rows[0]["ANCVisit1"]) == true)
                 {
                     ChkAncbef20.Checked = true;
                 }
                 if (Convert.ToBoolean(dt.Rows[0]["ANCVisit2"]) == true)
                 {
                     ChkAncaft20.Checked = true;
                 }


                 if (Convert.ToBoolean(dt.Rows[0]["Ultrasound"]) == true)
                 {
                     ChkUltrabef14.Checked = true;
                 }
                 if (Convert.ToBoolean(dt.Rows[0]["Ultrasound1"]) == true)
                 {
                     ChkUltraft14.Checked = true;
                 }
                 if (Convert.ToBoolean(dt.Rows[0]["Ultrasound2"]) == true)
                 {
                     ChkUltraaft20.Checked = true;
                 }

                 txtParity.Text = Convert.ToString(dt.Rows[0]["Parity"]);
                 txtnumberofAbortion.Text = Convert.ToString(dt.Rows[0]["NumberofAbortion"]);
                 txtnumberofmiscarriages.Text = Convert.ToString(dt.Rows[0]["Numberofmiscarriages"]);
                 txtnumberofchild.Text = Convert.ToString(dt.Rows[0]["Numberofchildrenalive"]);
                 txtPreviousPre.Text = Convert.ToString(dt.Rows[0]["PreviousPregancies"]);
                 if (Convert.ToString(dt.Rows[0]["Date1"]) != "")
                 {
                     txtdate1.Text = Convert.ToString(dt.Rows[0]["Date1"]);
                 }
                  txtGestationalage1.Text = Convert.ToString(dt.Rows[0]["Gestationalage1"]);
                  txttypeodDeliv1.Text = Convert.ToString(dt.Rows[0]["TypeofDelivery1"]);
                 txtalive1.Text = Convert.ToString(dt.Rows[0]["Alive1"]);

                 if (Convert.ToString(dt.Rows[0]["Date2"]) != "")
                 {
                     txtdate2.Text = Convert.ToString(dt.Rows[0]["Date2"]);
                 }
                 txtGestationalage2.Text = Convert.ToString(dt.Rows[0]["Gestationalage2"]);
                 txttypeodDeliv2.Text = Convert.ToString(dt.Rows[0]["TypeofDelivery2"]);
                 txtalive2.Text = Convert.ToString(dt.Rows[0]["Alive2"]);

                 if (Convert.ToString(dt.Rows[0]["Date3"]) != "")
                 {
                     txtdate3.Text = Convert.ToString(dt.Rows[0]["Date3"]);
                 }
                 txtGestationalage3.Text = Convert.ToString(dt.Rows[0]["Gestationalage3"]);
                 txttypeodDeliv3.Text = Convert.ToString(dt.Rows[0]["TypeofDelivery3"]);
                 txtalive3.Text = Convert.ToString(dt.Rows[0]["Alive3"]);

                 if (Convert.ToString(dt.Rows[0]["Date4"]) != "")
                 {
                     txtdate4.Text = Convert.ToString(dt.Rows[0]["Date4"]);
                 }
                 txtGestationalage4.Text = Convert.ToString(dt.Rows[0]["Gestationalage4"]);
                 txttypeodDeliv4.Text = Convert.ToString(dt.Rows[0]["TypeofDelivery4"]);
                 txtalive4.Text = Convert.ToString(dt.Rows[0]["Alive4"]);

                 if (Convert.ToBoolean(dt.Rows[0]["PMHHypertension"]) == true)
                 {
                     ChkPMHHypertension.Checked = true;
                 }

                 if (Convert.ToBoolean(dt.Rows[0]["PMHDiabetes"]) == true)
                 {
                     ChkPMHDiabetes.Checked = true;
                 }

                 if (Convert.ToBoolean(dt.Rows[0]["PMHSickleCellDisease"]) == true)
                 {
                     CHKPMHSickle.Checked = true;
                 }
                 if (Convert.ToBoolean(dt.Rows[0]["PMHAsthma"]) == true)
                 {
                     ChkPMHAsthma.Checked = true;
                 }
                 if (Convert.ToBoolean(dt.Rows[0]["PMHThyroiddisease"]) == true)
                 {
                     ChkPMHThyroid.Checked = true;
                 }
                 if (Convert.ToBoolean(dt.Rows[0]["PMHEpilepsy"]) == true)
                 {
                     ChkPMHEpilepsy.Checked = true;
                 }
                 if (Convert.ToBoolean(dt.Rows[0]["PMHHepatitis"]) == true)
                 {
                     ChkPMHHepatitis.Checked = true;
                 }
                 if (Convert.ToBoolean(dt.Rows[0]["PMHKidneyDisease"]) == true)
                 {
                     ChkPMHKidneyDisease.Checked = true;
                 }
                 if (Convert.ToBoolean(dt.Rows[0]["PMHHIV"]) == true)
                 {
                     ChkPMHHiv.Checked = true;
                 }
                 if (Convert.ToBoolean(dt.Rows[0]["FHHypertension"]) == true)
                 {
                     ChkFHHypertension.Checked = true;
                 }

                 if (Convert.ToBoolean(dt.Rows[0]["FHDiabetes"]) == true)
                 {
                     ChkFHDiabetes.Checked = true;
                 }
                 if (Convert.ToBoolean(dt.Rows[0]["FHSickleCellDisease"]) == true)
                 {
                     CHKFHSickle.Checked = true;
                 }
                 if (Convert.ToBoolean(dt.Rows[0]["FHAsthma"]) == true)
                 {
                     ChkFHAsthma.Checked = true;
                 }
                 if (Convert.ToBoolean(dt.Rows[0]["FHThyroiddisease"]) == true)
                 {
                     ChkFHThyroid.Checked = true;
                 }
                 if (Convert.ToBoolean(dt.Rows[0]["FHEpilepsy"]) == true)
                 {
                     ChkFHEpilepsy.Checked = true;
                 }
                 if (Convert.ToBoolean(dt.Rows[0]["FHHepatitis"]) == true)
                 {
                     ChkFHHepatitis.Checked = true;
                 }
                 if (Convert.ToBoolean(dt.Rows[0]["FHKidneyDisease"]) == true)
                 {
                     ChkFHKidneyDisease.Checked = true;
                 }
                 if (Convert.ToBoolean(dt.Rows[0]["FHHIV"]) == true)
                 {
                     ChkFHHiv.Checked = true;
                 }

                 btnSave.Enabled = false;
            }


        }
    }
}