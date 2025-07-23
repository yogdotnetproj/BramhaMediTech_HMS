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

public partial class DeliveryPage : System.Web.UI.Page
{
    BELDeliveryPage ObjDp = new BELDeliveryPage();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Get_All_Delivery_Data(Convert.ToInt32(Session["EmrRegNo"]),Convert.ToInt32(Session["EmrIpdNo"]));
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
            ObjDp.OpdNo = Convert.ToInt32(Session["EmrOpdNo"]);
        }
        else
        {
            ObjDp.OpdNo = 0;
        }
        if (Convert.ToString(Session["EmrIpdNo"]) != "")
        {
            ObjDp.IpdNo = Convert.ToInt32(Session["EmrIpdNo"]);
            if (Convert.ToString(Session["PatAdmit"]) == "No")
            {
                LblMSg.ForeColor = System.Drawing.Color.Red;
                LblMSg.Text = "Patient already discharge!";
                return;
            }
        }
        else
        {
            ObjDp.IpdNo = 0;
        }
        ObjDp.Patregid = Convert.ToString(Session["EmrRegNo"]);
        ObjDp.CreatedBy = Convert.ToString(Session["username"]);
        ObjDp.UpdatedBy = Convert.ToString(Session["username"]);
        ObjDp.FId = Convert.ToInt32(Session["FId"]); ;
        ObjDp.BranchId = Convert.ToInt32(Session["Branchid"]);


        if (txtdob.Text != "")
        {
            ObjDp.DateOfBirth =Convert.ToDateTime( txtdob.Text);
        }
        ObjDp.TimeOfBirth = txttimeofbirth.Text;
        if (ChkMale.Checked == true)
        {
            ObjDp.BirthGender="Male";
        }
        if (ChkFemale.Checked == true)
        {
            ObjDp.BirthGender = "Female";
        }
        ObjDp.BirthWeight = txtbirthWeight.Text;

        ObjDp.TotalActivity1 = txttotal1Activity.Text;
        ObjDp.TotalPulse1 = txtTotal1Pulse.Text;
        ObjDp.TotalGrimace1 = txttotal1Grimace.Text;
        ObjDp.TotalAppearance1 = txttotal1Appearance.Text;
        ObjDp.TotalRespiration1 = txttotal1Respiration.Text;

        ObjDp.TotalActivity5 = txttotal5Activity.Text;
        ObjDp.TotalPulse5 = txttotal5Pulse.Text;
        ObjDp.TotalGrimace5 = txttotal5Grimace.Text;
        ObjDp.TotalAppearance5 = txttotal5Appearance.Text;
        ObjDp.TotalRespiration5 = txttotal5Respiration.Text;

        if (txtstage1date.Text.Trim() != "")
        {
            ObjDp.Stage1Date =Convert.ToDateTime( txtstage1date.Text);
        }
        ObjDp.Stage1TimeFrom = Convert.ToString(txtstage1timefrom.Text);
        ObjDp.Stage1TimeTo = Convert.ToString(txtstage1TimeTo.Text);
        ObjDp.Stage1Duration = Convert.ToString(txtstage1duration.Text);

        if (txtstage2date.Text.Trim() != "")
        {
            ObjDp.Stage2Date = Convert.ToDateTime(txtstage2date.Text);
        }
        ObjDp.Stage2TimeFrom = Convert.ToString(txtstage2timefrom.Text);
        ObjDp.Stage2TimeTo = Convert.ToString(txtstage2timeto.Text);
        ObjDp.Stage2Duration = Convert.ToString(txtstage2duration.Text);

        if (txtstage3date.Text.Trim() != "")
        {
            ObjDp.Stage3Date = Convert.ToDateTime(txtstage3date.Text);
        }
        ObjDp.Stage3TimeFrom = Convert.ToString(txtstage3timefrom.Text);
        ObjDp.Stage3TimeTo = Convert.ToString(txtstage3timeto.Text);
        ObjDp.Stage3Duration = Convert.ToString(txtstage3duration.Text);

        if (ChkPlacentacom.Checked == true)
        {
            ObjDp.PlacentaComplete = true;
        }
        if (ChkPlacentainc.Checked == true)
        {
            ObjDp.PlacentaInComplete = true;
        }
        if (Chk3blood.Checked == true)
        {
            ObjDp.bloodVessels = true;
        }
        if (ChkMeconium.Checked == true)
        {
            ObjDp.MeconiumStaining = true;
        }
        if (ChkCord.Checked == true)
        {
            ObjDp.Cordaround = true;
        }
        if (ChkEpisiotomy.Checked == true)
        {
            ObjDp.Episiotomy = true;
        }
        if (ChkVaginal.Checked == true)
        {
            ObjDp.Vaginal = true;
        }
        //---------------------------------------------------------
        if (ChkSpontaneousVaginal.Checked == true)
        {
           // ChkSpontaneousVaginal.Checked = true;
            ObjDp.SpontaneousVaginal = true;
        }
        if (ChkInductionOxy.Checked == true)
        {           
            ObjDp.InductionOxytocin = true;
        }
        if (ChkInduction.Checked == true)
        {
            ObjDp.InductionCytotec = true;           
        }
        if (ChkVaccum.Checked == true)
        {
            ObjDp.VaccumExtraction = true;           
        }
        if (ChkForceps.Checked == true)
        {
            ObjDp.Forcepsdelivery = true;
           
        }
        if (ChkCaesarian.Checked== true)
        {
            ObjDp.Caesariansection = true;
           
        }

        ObjDp.RepairBy = Convert.ToString(txtRepairBy.Text);
        ObjDp.Timeofrupturemembrance = Convert.ToString(txtTimeofrupture.Text);
        ObjDp.BloodLoss = Convert.ToString(txtbloodloss.Text);
        ObjDp.TypeofForceps = Convert.ToString(txttypeofForceps.Text);
        ObjDp.NumberofPulls = Convert.ToString(txtnumberofpulls.Text);
        ObjDp.Numberofslippage = Convert.ToString(txtnumberofslippage.Text);

        ObjDp.COC = Convert.ToString(txtCOC.Text);
        ObjDp.COH = Convert.ToString(txtCOH.Text);

        ObjDp.InsertDelivery_Page();
        Get_All_Delivery_Data(Convert.ToInt32(Session["EmrRegNo"]), Convert.ToInt32(Session["EmrIpdNo"]));
        LblMSg.Text = "Record save successfully!";
        LblMSg.ForeColor = System.Drawing.Color.Green;
        clear();

    }
    public void clear()
    {
        txtbirthWeight.Text = "";
        txtbloodloss.Text = "";
        txtdob.Text = "";
        txtnumberofpulls.Text = "";
        txtnumberofslippage.Text = "";
        txtRepairBy.Text = "";
        txtstage1date.Text = "";
        txtstage1duration.Text = "";
        txtstage1timefrom.Text = "";
        txtstage1TimeTo.Text = "";
        txtstage2date.Text = "";
        txtstage2duration.Text = "";
        txtstage2timefrom.Text = "";
        txtstage2timeto.Text = "";
        txtstage3date.Text = "";
        txtstage3duration.Text = "";
        txtstage3timefrom.Text = "";
        txtstage3timeto.Text = "";
        txttimeofbirth.Text = "";
        txtTimeofrupture.Text = "";
        txttotal1Activity.Text = "";
        txttotal1Appearance.Text = "";
        txttotal1Grimace.Text = "";
        txtTotal1Pulse.Text = "";
        txttotal1Respiration.Text = "";
        txttotal5Activity.Text = "";
        txttotal5Appearance.Text = "";
        txttotal5Grimace.Text = "";
        txttotal5Pulse.Text = "";
        txttotal5Respiration.Text = "";
        txttypeofForceps.Text = "";
        txtCOC.Text = "";
        txtCOH.Text = "";
        
    }
    protected void btnReport_Click(object sender, EventArgs e)
    {
        SqlConnection conn21 = DataAccess.ConInitForDC();
        SqlCommand sc21 = conn21.CreateCommand();
        sc21.CommandText = "ALTER VIEW [dbo].[VW_DeliveryPage] AS (SELECT        PatientInformation.FirstName, Gender.GenderName, PatientInformation.MobileNo, PatientInformation.PhoneNo, PatientInformation.PatientAddress, PatientInformation.Age, PatientInformation.AgeType, DeliveryPage.DeliveryId, "+
                      "  DeliveryPage.PatregId, DeliveryPage.OpdNo, DeliveryPage.IpdNo, DeliveryPage.DateOfBirth, DeliveryPage.TimeOfBirth, DeliveryPage.BirthGender, DeliveryPage.BirthWeight, DeliveryPage.TotalActivity1, "+
                      "  DeliveryPage.TotalPulse1, DeliveryPage.TotalGrimace1, DeliveryPage.TotalAppearance1, DeliveryPage.TotalRespiration1, DeliveryPage.TotalActivity5, DeliveryPage.TotalPulse5, DeliveryPage.TotalGrimace5, "+
                      "  DeliveryPage.TotalAppearance5, DeliveryPage.TotalRespiration5, DeliveryPage.SpontaneousVaginal, DeliveryPage.InductionOxytocin, DeliveryPage.InductionCytotec, DeliveryPage.VaccumExtraction, "+
                      "  DeliveryPage.Forcepsdelivery, DeliveryPage.Caesariansection, DeliveryPage.Stage1Date, DeliveryPage.Stage1TimeFrom, DeliveryPage.Stage1TimeTo, DeliveryPage.Stage1Duration, DeliveryPage.Stage2Date, "+ 
                      "  DeliveryPage.Stage2TimeFrom, DeliveryPage.Stage2TimeTo, DeliveryPage.Stage2Duration, DeliveryPage.Stage3Date, DeliveryPage.Stage3TimeFrom, DeliveryPage.Stage3TimeTo, DeliveryPage.Stage3Duration, "+
                      "  DeliveryPage.PlacentaComplete, DeliveryPage.PlacentaInComplete, DeliveryPage.bloodVessels, DeliveryPage.MeconiumStaining, DeliveryPage.Cordaround, DeliveryPage.Episiotomy, DeliveryPage.Vaginal, "+
                      "  DeliveryPage.RepairBy, DeliveryPage.Timeofrupturemembrance, DeliveryPage.BloodLoss, DeliveryPage.TypeofForceps, DeliveryPage.NumberofPulls, DeliveryPage.Numberofslippage, DeliveryPage.Branchid, "+
                      "  DeliveryPage.CreatedBy, DeliveryPage.CreatedOn, DeliveryPage.UpdatedBy, DeliveryPage.UpdatedOn "+
                      "  FROM            PatientInformation INNER JOIN "+
                      "  Gender ON PatientInformation.GenderId = Gender.GenderId INNER JOIN "+
                      "  DeliveryPage ON PatientInformation.PatRegId = DeliveryPage.PatregId " +
                      "Where 1=1";
        sc21.CommandText += " and DeliveryPage.Patregid ='" + Convert.ToString(Session["EmrRegNo"]) + "' and DeliveryPage.IPDNo= '" + Convert.ToString(Session["EmrIPDNo"]) + "'";
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
        Session["rptname"] = Server.MapPath("~/DiagnosticReport/Rpt_DeliveryPage.rpt");
        Session["reportname"] = "DeliveryPage";
        Session["RPTFORMAT"] = "pdf";
       // Session["Parameter"] = "Yes";
        //  Session["rptDate"] = fromdate.Text + "  To  " + todate.Text;
        //  Session["rptusername"] = Convert.ToString(Session["username"]);


        ReportParameterClass.SelectionFormula = sql;
        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);
    }

    public void Get_All_Delivery_Data(int Patregid, int IpdNo)
    {

        DataTable dt = new DataTable();

        using (SqlConnection con = DataAccess.ConInitForDC())
        {
            using (SqlCommand cmd = new SqlCommand("SP_GetDeliveryData", con))
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

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int DeliveryId = Convert.ToInt32((GridView1.DataKeys[e.NewEditIndex]["DeliveryId"]));
        ViewState["DeliveryId"] = DeliveryId;
        Get_All_Delivery_Data_Edit(Convert.ToInt32(Session["EmrRegNo"]), Convert.ToInt32(Session["EmrIpdNo"]), DeliveryId);
        e.Cancel = true;
    }
    public void Get_All_Delivery_Data_Edit(int Patregid, int IpdNo, int DeliveryId)
    {

        DataTable dt = new DataTable();

        using (SqlConnection con = DataAccess.ConInitForDC())
        {
            using (SqlCommand cmd = new SqlCommand("SP_GetDeliveryData_Edit", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@PatRegId", Convert.ToInt32(Session["EmrRegNo"]));
                cmd.Parameters.AddWithValue("@IPDNo", Convert.ToInt32(IpdNo));
                cmd.Parameters.AddWithValue("@DeliveryId", Convert.ToInt32(DeliveryId));

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
                if (Convert.ToString(dt.Rows[0]["DateOfBirth"]) != "")
                {
                   txtdob.Text =Convert.ToString( dt.Rows[0]["DateOfBirth"]);
                }
               txttimeofbirth.Text = Convert.ToString(dt.Rows[0]["TimeOfBirth"]);
               if (Convert.ToString(dt.Rows[0]["BirthGender"]) != "Male")
               {
                   ChkMale.Checked = true;
               }
               else
               {
                   ChkFemale.Checked = true;
               }

               ObjDp.BirthWeight = txtbirthWeight.Text = Convert.ToString(dt.Rows[0]["BirthWeight"]);

               ObjDp.TotalActivity1 = txttotal1Activity.Text = Convert.ToString(dt.Rows[0]["TotalActivity1"]);
               ObjDp.TotalPulse1 = txtTotal1Pulse.Text = Convert.ToString(dt.Rows[0]["TotalPulse1"]);
               ObjDp.TotalGrimace1 = txttotal1Grimace.Text = Convert.ToString(dt.Rows[0]["TotalGrimace1"]);
               ObjDp.TotalAppearance1 = txttotal1Appearance.Text = Convert.ToString(dt.Rows[0]["TotalAppearance1"]);
               ObjDp.TotalRespiration1 = txttotal1Respiration.Text = Convert.ToString(dt.Rows[0]["TotalRespiration1"]);

               ObjDp.TotalActivity5 = txttotal5Activity.Text = Convert.ToString(dt.Rows[0]["TotalActivity5"]);
               ObjDp.TotalPulse5 = txttotal5Pulse.Text = Convert.ToString(dt.Rows[0]["TotalPulse5"]);
               ObjDp.TotalGrimace5 = txttotal5Grimace.Text = Convert.ToString(dt.Rows[0]["TotalGrimace5"]);
               ObjDp.TotalAppearance5 = txttotal5Appearance.Text = Convert.ToString(dt.Rows[0]["TotalAppearance5"]);
               ObjDp.TotalRespiration5 = txttotal5Respiration.Text = Convert.ToString(dt.Rows[0]["TotalRespiration5"]);

               if (Convert.ToString(dt.Rows[0]["Stage1Date"]) != "") 
                {
                   txtstage1date.Text = Convert.ToString(dt.Rows[0]["Stage1Date"]);
                }
              txtstage1timefrom.Text = Convert.ToString(dt.Rows[0]["Stage1TimeFrom"]);
              txtstage1TimeTo.Text = Convert.ToString(dt.Rows[0]["Stage1TimeTo"]);
             txtstage1duration.Text = Convert.ToString(dt.Rows[0]["Stage1Duration"]);

                if (Convert.ToString(dt.Rows[0]["Stage2Date"]) != "") 
                {
                    txtstage2date.Text = Convert.ToString(dt.Rows[0]["Stage2Date"]); ;
                }
               txtstage2timefrom.Text = Convert.ToString(dt.Rows[0]["Stage2TimeFrom"]);
               txtstage2timeto.Text = Convert.ToString(dt.Rows[0]["Stage2TimeTo"]);
               txtstage2duration.Text = Convert.ToString(dt.Rows[0]["Stage2Duration"]);

                if (Convert.ToString(dt.Rows[0]["Stage3Date"]) != "") 
                {
                    txtstage3date.Text = Convert.ToString(dt.Rows[0]["Stage3Date"]);
                }
                txtstage3timefrom.Text = Convert.ToString(dt.Rows[0]["Stage3TimeFrom"]);
                txtstage3timeto.Text = Convert.ToString(dt.Rows[0]["Stage3TimeTo"]);
                txtstage3duration.Text = Convert.ToString(dt.Rows[0]["Stage3Duration"]);

                if (Convert.ToBoolean(dt.Rows[0]["PlacentaComplete"]) == true)
                {
                    ChkPlacentacom.Checked = true;
                }
                if (Convert.ToBoolean(dt.Rows[0]["PlacentaInComplete"]) == true)
                {
                    ChkPlacentainc.Checked = true;
                }
                if (Convert.ToBoolean(dt.Rows[0]["bloodVessels"]) == true)
                {
                    Chk3blood.Checked = true;
                }

                if (Convert.ToBoolean(dt.Rows[0]["MeconiumStaining"]) == true)
                {
                    ChkMeconium.Checked = true;
                }

                if (Convert.ToBoolean(dt.Rows[0]["Cordaround"]) == true)
                {
                    ChkCord.Checked = true;
                }
                if (Convert.ToBoolean(dt.Rows[0]["Episiotomy"]) == true)
                {
                    ChkEpisiotomy.Checked = true;
                }
                if (Convert.ToBoolean(dt.Rows[0]["Vaginal"]) == true)
                {
                    ChkVaginal.Checked = true;
                }

              //  ---------------------------------------------------------
                if (Convert.ToBoolean(dt.Rows[0]["SpontaneousVaginal"]) == true)
                {
                    ChkSpontaneousVaginal.Checked = true;
                }
                if (Convert.ToBoolean(dt.Rows[0]["InductionOxytocin"]) == true)
                {
                    ChkInductionOxy.Checked = true;
                }
                if (Convert.ToBoolean(dt.Rows[0]["InductionCytotec"]) == true)
                {
                    ChkInduction.Checked = true;
                }
                if (Convert.ToBoolean(dt.Rows[0]["VaccumExtraction"]) == true)
                {
                    ChkVaccum.Checked = true;
                }
                if (Convert.ToBoolean(dt.Rows[0]["Forcepsdelivery"]) == true)
                {
                    ChkForceps.Checked = true;
                }
                if (Convert.ToBoolean(dt.Rows[0]["Caesariansection"]) == true)
                {
                    ChkCaesarian.Checked = true;
                }


                txtRepairBy.Text = Convert.ToString(dt.Rows[0]["RepairBy"]);
                txtTimeofrupture.Text = Convert.ToString(dt.Rows[0]["Timeofrupturemembrance"]);
                txtbloodloss.Text = Convert.ToString(dt.Rows[0]["BloodLoss"]);
                txttypeofForceps.Text = Convert.ToString(dt.Rows[0]["TypeofForceps"]);
                txtnumberofpulls.Text = Convert.ToString(dt.Rows[0]["NumberofPulls"]);
                txtnumberofslippage.Text = Convert.ToString(dt.Rows[0]["Numberofslippage"]);

                btnSave.Enabled = false;
            }


        }
    }
}