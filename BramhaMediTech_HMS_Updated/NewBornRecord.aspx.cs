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

public partial class NewBornRecord : BasePage
{
    BELDeliveryPage ObjNbr = new BELDeliveryPage();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Get_All_NewBorn_Data(Convert.ToInt32(Session["EmrRegNo"]), Convert.ToInt32(Session["EmrIpdNo"]));
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {


        if (Convert.ToString(Session["EmrOpdNo"]) != "")
        {
            ObjNbr.OpdNo = Convert.ToInt32(Session["EmrOpdNo"]);
        }
        else
        {
            ObjNbr.OpdNo = 0;
        }
        if (Convert.ToString(Session["EmrIpdNo"]) != "")
        {
            ObjNbr.IpdNo = Convert.ToInt32(Session["EmrIpdNo"]);
        }
        else
        {
            ObjNbr.IpdNo = 0;
        }
        ObjNbr.Patregid = Convert.ToString(Session["EmrRegNo"]);
        ObjNbr.CreatedBy = Convert.ToString(Session["username"]);
        ObjNbr.UpdatedBy = Convert.ToString(Session["username"]);
        ObjNbr.FId = Convert.ToInt32(Session["FId"]); ;
        ObjNbr.BranchId = Convert.ToInt32(Session["Branchid"]);

        ObjNbr.InfantName = txtinfantname.Text;
        ObjNbr.MotherName = txtmothername.Text;
        if (txtBirthDate.Text.Trim() != "")
        {
            ObjNbr.DateOfBirth = Convert.ToDateTime( txtBirthDate.Text);
        }
        ObjNbr.BirthGender = RblGender.SelectedValue;
        ObjNbr.FileNo = txtFileNo.Text;
        ObjNbr.CIRC = txtCIRC.Text;
        ObjNbr.DrName = txtDr.Text;

        ObjNbr.Time1 = txttime1.Text;
        ObjNbr.Time2 = txttime2.Text;
        ObjNbr.Time3 = txttime3.Text;
        ObjNbr.Time4 = txttime4.Text;
        ObjNbr.Time5 = txttime5.Text;
        ObjNbr.Time6 = txttime6.Text;
        ObjNbr.Time7 = txttime7.Text;
        ObjNbr.Time8 = txttime8.Text;
        ObjNbr.Time9 = txttime9.Text;

        ObjNbr.Temperature1 = txtTemperature1.Text;
        ObjNbr.Temperature2 = txtTemperature2.Text;
        ObjNbr.Temperature3 = txtTemperature3.Text;
        ObjNbr.Temperature4 = txtTemperature4.Text;
        ObjNbr.Temperature5 = txtTemperature5.Text;
        ObjNbr.Temperature6 = txtTemperature6.Text;
        ObjNbr.Temperature7 = txtTemperature7.Text;
        ObjNbr.Temperature8 = txtTemperature8.Text;
        ObjNbr.Temperature9 = txtTemperature9.Text;

        ObjNbr.Respirations1 = txtRespirations1.Text;
        ObjNbr.Respirations2 = txtRespirations2.Text;
        ObjNbr.Respirations3 = txtRespirations3.Text;
        ObjNbr.Respirations4 = txtRespirations4.Text;
        ObjNbr.Respirations5 = txtRespirations5.Text;
        ObjNbr.Respirations6 = txtRespirations6.Text;
        ObjNbr.Respirations7 = txtRespirations7.Text;
        ObjNbr.Respirations8 = txtRespirations8.Text;
        ObjNbr.Respirations9 = txtRespirations9.Text;

        ObjNbr.HeartRate1 = txtHeartRate1.Text;
        ObjNbr.HeartRate2 = txtHeartRate2.Text;
        ObjNbr.HeartRate3 = txtHeartRate3.Text;
        ObjNbr.HeartRate4 = txtHeartRate4.Text;
        ObjNbr.HeartRate5 = txtHeartRate5.Text;
        ObjNbr.HeartRate6 = txtHeartRate6.Text;
        ObjNbr.HeartRate7 = txtHeartRate7.Text;
        ObjNbr.HeartRate8 = txtHeartRate8.Text;
        ObjNbr.HeartRate9 = txtHeartRate9.Text;

        ObjNbr.Ftime1 = txtFtime1.Text;
        ObjNbr.Ftime2 = txtFtime2.Text;
        ObjNbr.Ftime3 = txtFtime3.Text;
        ObjNbr.Ftime4 = txtFtime4.Text;
        ObjNbr.Ftime5 = txtFtime5.Text;
        ObjNbr.Ftime6 = txtFtime6.Text;
        ObjNbr.Ftime7 = txtFtime7.Text;
        ObjNbr.Ftime8 = txtFtime8.Text;
        ObjNbr.Ftime9 = txtFtime9.Text;

        ObjNbr.Formula1 = txtFormula1.Text;
        ObjNbr.Formula2 = txtFormula2.Text;
        ObjNbr.Formula3 = txtFormula3.Text;
        ObjNbr.Formula4 = txtFormula4.Text;
        ObjNbr.Formula5 = txtFormula5.Text;
        ObjNbr.Formula6 = txtFormula6.Text;
        ObjNbr.Formula7 = txtFormula7.Text;
        ObjNbr.Formula8 = txtFormula8.Text;
        ObjNbr.Formula9 = txtFormula9.Text;

        ObjNbr.Breast1 = txtBreast1.Text;
        ObjNbr.Breast2 = txtBreast2.Text;
        ObjNbr.Breast3 = txtBreast3.Text;
        ObjNbr.Breast4 = txtBreast4.Text;
        ObjNbr.Breast5 = txtBreast5.Text;
        ObjNbr.Breast6 = txtBreast6.Text;
        ObjNbr.Breast7 = txtBreast7.Text;
        ObjNbr.Breast8 = txtBreast8.Text;
        ObjNbr.Breast9 = txtBreast9.Text;

        ObjNbr.Supplement1 = txtSupplement1.Text;
        ObjNbr.Supplement2 = txtSupplement2.Text;
        ObjNbr.Supplement3 = txtSupplement3.Text;
        ObjNbr.Supplement4 = txtSupplement4.Text;
        ObjNbr.Supplement5 = txtSupplement5.Text;
        ObjNbr.Supplement6 = txtSupplement6.Text;
        ObjNbr.Supplement7 = txtSupplement7.Text;
        ObjNbr.Supplement8 = txtSupplement8.Text;
        ObjNbr.Supplement9 = txtSupplement9.Text;

        ObjNbr.cordCare1 = txtcordCare1.Text;
        ObjNbr.cordCare2 = txtcordCare2.Text;
        ObjNbr.cordCare3 = txtcordCare3.Text;
        ObjNbr.cordCare4 = txtcordCare4.Text;
        ObjNbr.cordCare5 = txtcordCare5.Text;
        ObjNbr.cordCare6 = txtcordCare6.Text;
        ObjNbr.cordCare7 = txtcordCare7.Text;
        ObjNbr.cordCare8 = txtcordCare8.Text;
        ObjNbr.cordCare9 = txtcordCare9.Text;

        ObjNbr.Urine1 = txtUrine1.Text;
        ObjNbr.Urine2 = txtUrine2.Text;
        ObjNbr.Urine3 = txtUrine3.Text;
        ObjNbr.Urine4 = txtUrine4.Text;
        ObjNbr.Urine5 = txtUrine5.Text;
        ObjNbr.Urine6 = txtUrine6.Text;
        ObjNbr.Urine7 = txtUrine7.Text;
        ObjNbr.Urine8 = txtUrine8.Text;
        ObjNbr.Urine9 = txtUrine9.Text;

        ObjNbr.Stools1 = txtStools1.Text;
        ObjNbr.Stools2 = txtStools2.Text;
        ObjNbr.Stools3 = txtStools3.Text;
        ObjNbr.Stools4 = txtStools4.Text;
        ObjNbr.Stools5 = txtStools5.Text;
        ObjNbr.Stools6 = txtStools6.Text;
        ObjNbr.Stools7 = txtStools7.Text;
        ObjNbr.Stools8 = txtStools8.Text;
        ObjNbr.Stools9 = txtStools9.Text;

        ObjNbr.RNSignature1 = txtRNSignature1.Text;
        ObjNbr.RNSignature2 = txtRNSignature2.Text;
        ObjNbr.RNSignature3 = txtRNSignature3.Text;
        ObjNbr.RNSignature4 = txtRNSignature4.Text;
        ObjNbr.RNSignature5 = txtRNSignature5.Text;
        ObjNbr.RNSignature6 = txtRNSignature6.Text;
        ObjNbr.RNSignature7 = txtRNSignature7.Text;
        ObjNbr.RNSignature8 = txtRNSignature8.Text;
        ObjNbr.RNSignature9 = txtRNSignature9.Text;

        ObjNbr.Insert_NewBornRecord();
        LblMSg.Text = "Record Save Successfully";
        LblMSg.ForeColor = System.Drawing.Color.Green;
        Get_All_NewBorn_Data(Convert.ToInt32(Session["EmrRegNo"]), Convert.ToInt32(Session["EmrIpdNo"]));
        clear();

    }
    public void clear()
    {
        txtBreast1.Text = "";
        txtBreast2.Text = "";
        txtBreast3.Text = "";
        txtBreast4.Text = "";
        txtBreast5.Text = "";
        txtBreast6.Text = "";
        txtBreast7.Text = "";
        txtBreast8.Text = "";
        txtBreast9.Text = "";
        txtCIRC.Text = "";
        txtcordCare1.Text = "";
        txtcordCare2.Text = "";
        txtcordCare3.Text = "";
        txtcordCare4.Text = "";
        txtcordCare5.Text = "";
        txtcordCare6.Text = "";
        txtcordCare7.Text = "";
        txtcordCare8.Text = "";
        txtcordCare9.Text = "";
        txtDr.Text = "";
        txtFileNo.Text = "";
        txtFormula1.Text = "";
        txtFormula2.Text = "";
        txtFormula3.Text = "";
        txtFormula4.Text="";
        txtFormula5.Text="";
        txtFormula6.Text="";
        txtFormula7.Text="";
        txtFormula8.Text="";
        txtFormula9.Text = "";
        txtFtime1.Text = "";
        txtFtime2.Text = "";
        txtFtime3.Text="";
        txtFtime4.Text = "";
        txtFtime5.Text = "";
        txtFtime6.Text = "";
        txtFtime7.Text = "";
        txtFtime8.Text = "";
        txtFtime9.Text = "";
        txtHeartRate1.Text = "";
        txtHeartRate2.Text = "";
        txtHeartRate3.Text = "";
        txtHeartRate4.Text = "";
        txtHeartRate5.Text = "";
        txtHeartRate6.Text = "";
        txtHeartRate7.Text = "";
        txtHeartRate8.Text = "";
        txtHeartRate9.Text = "";
        txtinfantname.Text = "";
        txtmothername.Text = "";
        txtRespirations1.Text = "";
        txtRespirations2.Text = "";
        txtRespirations3.Text = "";
        txtRespirations4.Text = "";
        txtRespirations5.Text = "";
        txtRespirations6.Text = "";
        txtRespirations7.Text = "";
        txtRespirations8.Text = "";
        txtRespirations9.Text = "";
        txtRNSignature1.Text = "";
        txtRNSignature2.Text = "";
        txtRNSignature3.Text = "";
        txtRNSignature4.Text = "";
        txtRNSignature5.Text = "";
        txtRNSignature6.Text = "";
        txtRNSignature7.Text = "";
        txtRNSignature8.Text = "";
        txtRNSignature9.Text = "";
        txtStools1.Text = "";
        txtStools2.Text = "";
        txtStools3.Text = "";
        txtStools4.Text = "";
        txtStools5.Text = "";
        txtStools6.Text = "";
        txtStools7.Text = "";
        txtStools8.Text = "";
        txtStools9.Text = "";
        txtSupplement1.Text = "";
        txtSupplement2.Text = "";
        txtSupplement3.Text = "";
        txtSupplement4.Text = "";
        txtSupplement5.Text = "";
        txtSupplement6.Text = "";
        txtSupplement7.Text = "";
        txtSupplement8.Text = "";
        txtSupplement9.Text = "";
        txtTemperature1.Text = "";
        txtTemperature2.Text = "";
        txtTemperature3.Text = "";
        txtTemperature4.Text = "";
        txtTemperature5.Text = "";
        txtTemperature6.Text = "";
        txtTemperature7.Text = "";
        txtTemperature8.Text = "";
        txtTemperature9.Text = "";
        txttime1.Text = "";
        txttime2.Text = "";
        txttime3.Text = "";
        txttime4.Text = "";
        txttime5.Text = "";
        txttime6.Text = "";
        txttime7.Text = "";
        txttime8.Text = "";
        txttime9.Text = "";
        txtUrine1.Text = "";
        txtUrine2.Text = "";
        txtUrine3.Text = "";
        txtUrine4.Text = "";
        txtUrine5.Text = "";
        txtUrine6.Text = "";
        txtUrine7.Text = "";
        txtUrine8.Text = "";
        txtUrine9.Text = "";
        


    }
    protected void btnReport_Click(object sender, EventArgs e)
    {
        SqlConnection conn21 = DataAccess.ConInitForDC();
        SqlCommand sc21 = conn21.CreateCommand();
        sc21.CommandText = "ALTER VIEW [dbo].[VW_NewBornRecord] AS (SELECT        PatientInformation.FirstName, Gender.GenderName, PatientInformation.MobileNo, PatientInformation.PhoneNo, PatientInformation.PatientAddress, PatientInformation.Age, PatientInformation.AgeType, NewBornRecord.BId, "+
                         "   NewBornRecord.Patregid, NewBornRecord.OpdNo, NewBornRecord.IpdNo, NewBornRecord.InfantName, NewBornRecord.MotherName, NewBornRecord.BirthDate, NewBornRecord.FileNo, NewBornRecord.CIRC, "+
                          "  NewBornRecord.DrName, NewBornRecord.Time1, NewBornRecord.Time2, NewBornRecord.Time3, NewBornRecord.Time4, NewBornRecord.Time5, NewBornRecord.Time6, NewBornRecord.Time7, NewBornRecord.Time8, "+
                          "  NewBornRecord.Time9, NewBornRecord.Temperature1, NewBornRecord.Temperature2, NewBornRecord.Temperature3, NewBornRecord.Temperature4, NewBornRecord.Temperature5, NewBornRecord.Temperature6, "+
                          "  NewBornRecord.Temperature7, NewBornRecord.Temperature8, NewBornRecord.Temperature9, NewBornRecord.Respirations1, NewBornRecord.Respirations2, NewBornRecord.Respirations3, NewBornRecord.Respirations4, "+
                          "  NewBornRecord.Respirations5, NewBornRecord.Respirations6, NewBornRecord.Respirations7, NewBornRecord.Respirations8, NewBornRecord.Respirations9, NewBornRecord.HeartRate1, NewBornRecord.HeartRate2, "+
                          "  NewBornRecord.HeartRate3, NewBornRecord.HeartRate4, NewBornRecord.HeartRate5, NewBornRecord.HeartRate6, NewBornRecord.HeartRate7, NewBornRecord.HeartRate8, NewBornRecord.HeartRate9, "+
                          "  NewBornRecord.Ftime1, NewBornRecord.Ftime2, NewBornRecord.Ftime3, NewBornRecord.Ftime4, NewBornRecord.Ftime5, NewBornRecord.Ftime6, NewBornRecord.Ftime7, NewBornRecord.Ftime8, NewBornRecord.Ftime9, "+
                          "  NewBornRecord.Formula1, NewBornRecord.Formula2, NewBornRecord.Formula3, NewBornRecord.Formula4, NewBornRecord.Formula5, NewBornRecord.Formula6, NewBornRecord.Formula7, NewBornRecord.Formula8, "+
                          "  NewBornRecord.Formula9, NewBornRecord.Breast1, NewBornRecord.Breast2, NewBornRecord.Breast3, NewBornRecord.Breast4, NewBornRecord.Breast5, NewBornRecord.Breast6, NewBornRecord.Breast7, "+
                          "  NewBornRecord.Breast8, NewBornRecord.Breast9, NewBornRecord.Supplement1, NewBornRecord.Supplement2, NewBornRecord.Supplement3, NewBornRecord.Supplement4, NewBornRecord.Supplement5, "+
                          "  NewBornRecord.Supplement6, NewBornRecord.Supplement7, NewBornRecord.Supplement8, NewBornRecord.Supplement9, NewBornRecord.cordCare1, NewBornRecord.cordCare2, NewBornRecord.cordCare3, "+
                          "  NewBornRecord.cordCare4, NewBornRecord.cordCare5, NewBornRecord.cordCare6, NewBornRecord.cordCare7, NewBornRecord.cordCare8, NewBornRecord.cordCare9, NewBornRecord.Urine1, NewBornRecord.Urine2, "+
                          "  NewBornRecord.Urine3, NewBornRecord.Urine4, NewBornRecord.Urine5, NewBornRecord.Urine6, NewBornRecord.Urine7, NewBornRecord.Urine8, NewBornRecord.Urine9, NewBornRecord.Stools1, NewBornRecord.Stools2, "+
                          "  NewBornRecord.Stools3, NewBornRecord.Stools4, NewBornRecord.Stools5, NewBornRecord.Stools6, NewBornRecord.Stools7, NewBornRecord.Stools8, NewBornRecord.Stools9, NewBornRecord.RNSignature1, "+
                          "  NewBornRecord.RNSignature2, NewBornRecord.RNSignature3, NewBornRecord.RNSignature4, NewBornRecord.RNSignature5, NewBornRecord.RNSignature6, NewBornRecord.RNSignature7, NewBornRecord.RNSignature8, "+
                          "  NewBornRecord.RNSignature9, NewBornRecord.Branchid, NewBornRecord.FID, NewBornRecord.CreatedBy, NewBornRecord.CreatedOn, NewBornRecord.UpdatedBy, NewBornRecord.UpdatedOn "+
                          "  FROM            PatientInformation INNER JOIN "+
                          "  Gender ON PatientInformation.GenderId = Gender.GenderId INNER JOIN "+
                          "  NewBornRecord ON PatientInformation.PatRegId = NewBornRecord.Patregid " +
                      "Where 1=1";
        sc21.CommandText += " and NewBornRecord.Patregid ='" + Convert.ToString(Session["EmrRegNo"]) + "' and NewBornRecord.IPDNo= '" + Convert.ToString(Session["EmrIPDNo"]) + "'";
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
        Session["rptname"] = Server.MapPath("~/DiagnosticReport/Rpt_NewBornRecord.rpt");
        Session["reportname"] = "NewBornRecord";
        Session["RPTFORMAT"] = "pdf";
       // Session["Parameter"] = "Yes";
        //  Session["rptDate"] = fromdate.Text + "  To  " + todate.Text;
        //  Session["rptusername"] = Convert.ToString(Session["username"]);


        ReportParameterClass.SelectionFormula = sql;
        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);
    }

    public void Get_All_NewBorn_Data(int Patregid, int IpdNo)
    {

        DataTable dt = new DataTable();

        using (SqlConnection con = DataAccess.ConInitForDC())
        {
            using (SqlCommand cmd = new SqlCommand("SP_GetNewBornRecordData", con))
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
        int BId = Convert.ToInt32((GridView1.DataKeys[e.NewEditIndex]["BId"]));
        ViewState["BId"] = BId;
        Get_All_NewBorn_Data_Edit(Convert.ToInt32(Session["EmrRegNo"]), Convert.ToInt32(Session["EmrIpdNo"]), BId);
        e.Cancel = true;
    }

    public void Get_All_NewBorn_Data_Edit(int Patregid, int IpdNo, int BId)
    {

        DataTable dt = new DataTable();

        using (SqlConnection con = DataAccess.ConInitForDC())
        {
            using (SqlCommand cmd = new SqlCommand("SP_GetNewBornRecordData_Edit", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@PatRegId", Convert.ToInt32(Session["EmrRegNo"]));
                cmd.Parameters.AddWithValue("@IPDNo", Convert.ToInt32(IpdNo));
                cmd.Parameters.AddWithValue("@BId", Convert.ToInt32(BId));

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
                if (Convert.ToString(dt.Rows[0]["BirthDate"]) != "")
                {
                    txtBirthDate.Text = Convert.ToString(dt.Rows[0]["BirthDate"]);
                }
                ObjNbr.InfantName = txtinfantname.Text = Convert.ToString(dt.Rows[0]["InfantName"]);
                ObjNbr.MotherName = txtmothername.Text = Convert.ToString(dt.Rows[0]["MotherName"]);
                if (Convert.ToString(dt.Rows[0]["MotherName"]) == "Male")
                {
                    RblGender.SelectedValue = "Male";
                }
                else
                {
                    RblGender.SelectedValue = "Female";
                }
               // ObjNbr.BirthGender = RblGender.SelectedValue;
                ObjNbr.FileNo = txtFileNo.Text = Convert.ToString(dt.Rows[0]["FileNo"]);
                ObjNbr.CIRC = txtCIRC.Text = Convert.ToString(dt.Rows[0]["CIRC"]);
                ObjNbr.DrName = txtDr.Text = Convert.ToString(dt.Rows[0]["DrName"]);

                ObjNbr.Time1 = txttime1.Text = Convert.ToString(dt.Rows[0]["Time1"]);
                ObjNbr.Time2 = txttime2.Text = Convert.ToString(dt.Rows[0]["Time2"]);
                ObjNbr.Time3 = txttime3.Text = Convert.ToString(dt.Rows[0]["Time3"]);
                ObjNbr.Time4 = txttime4.Text = Convert.ToString(dt.Rows[0]["Time4"]);
                ObjNbr.Time5 = txttime5.Text = Convert.ToString(dt.Rows[0]["Time5"]);
                ObjNbr.Time6 = txttime6.Text = Convert.ToString(dt.Rows[0]["Time6"]);
                ObjNbr.Time7 = txttime7.Text = Convert.ToString(dt.Rows[0]["Time7"]);
                ObjNbr.Time8 = txttime8.Text = Convert.ToString(dt.Rows[0]["Time8"]);
                ObjNbr.Time9 = txttime9.Text = Convert.ToString(dt.Rows[0]["Time9"]);

                ObjNbr.Temperature1 = txtTemperature1.Text = Convert.ToString(dt.Rows[0]["Temperature1"]);
                ObjNbr.Temperature2 = txtTemperature2.Text = Convert.ToString(dt.Rows[0]["Temperature2"]);
                ObjNbr.Temperature3 = txtTemperature3.Text = Convert.ToString(dt.Rows[0]["Temperature3"]);
                ObjNbr.Temperature4 = txtTemperature4.Text = Convert.ToString(dt.Rows[0]["Temperature4"]);
                ObjNbr.Temperature5 = txtTemperature5.Text = Convert.ToString(dt.Rows[0]["Temperature5"]);
                ObjNbr.Temperature6 = txtTemperature6.Text = Convert.ToString(dt.Rows[0]["Temperature6"]);
                ObjNbr.Temperature7 = txtTemperature7.Text = Convert.ToString(dt.Rows[0]["Temperature7"]);
                ObjNbr.Temperature8 = txtTemperature8.Text = Convert.ToString(dt.Rows[0]["Temperature8"]);
                ObjNbr.Temperature9 = txtTemperature9.Text = Convert.ToString(dt.Rows[0]["Temperature9"]);

                ObjNbr.Respirations1 = txtRespirations1.Text = Convert.ToString(dt.Rows[0]["Respirations1"]);
                ObjNbr.Respirations2 = txtRespirations2.Text = Convert.ToString(dt.Rows[0]["Respirations2"]);
                ObjNbr.Respirations3 = txtRespirations3.Text = Convert.ToString(dt.Rows[0]["Respirations3"]);
                ObjNbr.Respirations4 = txtRespirations4.Text = Convert.ToString(dt.Rows[0]["Respirations4"]);
                ObjNbr.Respirations5 = txtRespirations5.Text = Convert.ToString(dt.Rows[0]["Respirations5"]);
                ObjNbr.Respirations6 = txtRespirations6.Text = Convert.ToString(dt.Rows[0]["Respirations6"]);
                ObjNbr.Respirations7 = txtRespirations7.Text = Convert.ToString(dt.Rows[0]["Respirations7"]);
                ObjNbr.Respirations8 = txtRespirations8.Text = Convert.ToString(dt.Rows[0]["Respirations8"]);
                ObjNbr.Respirations9 = txtRespirations9.Text = Convert.ToString(dt.Rows[0]["Respirations9"]);

                ObjNbr.HeartRate1 = txtHeartRate1.Text = Convert.ToString(dt.Rows[0]["HeartRate1"]);
                ObjNbr.HeartRate2 = txtHeartRate2.Text = Convert.ToString(dt.Rows[0]["HeartRate2"]);
                ObjNbr.HeartRate3 = txtHeartRate3.Text = Convert.ToString(dt.Rows[0]["HeartRate3"]);
                ObjNbr.HeartRate4 = txtHeartRate4.Text = Convert.ToString(dt.Rows[0]["HeartRate4"]);
                ObjNbr.HeartRate5 = txtHeartRate5.Text = Convert.ToString(dt.Rows[0]["HeartRate5"]);
                ObjNbr.HeartRate6 = txtHeartRate6.Text = Convert.ToString(dt.Rows[0]["HeartRate6"]);
                ObjNbr.HeartRate7 = txtHeartRate7.Text = Convert.ToString(dt.Rows[0]["HeartRate7"]);
                ObjNbr.HeartRate8 = txtHeartRate8.Text = Convert.ToString(dt.Rows[0]["HeartRate8"]);
                ObjNbr.HeartRate9 = txtHeartRate9.Text = Convert.ToString(dt.Rows[0]["HeartRate9"]);

                ObjNbr.Ftime1 = txtFtime1.Text = Convert.ToString(dt.Rows[0]["Ftime1"]);
                ObjNbr.Ftime2 = txtFtime2.Text = Convert.ToString(dt.Rows[0]["Ftime2"]);
                ObjNbr.Ftime3 = txtFtime3.Text = Convert.ToString(dt.Rows[0]["Ftime3"]);
                ObjNbr.Ftime4 = txtFtime4.Text = Convert.ToString(dt.Rows[0]["Ftime4"]);
                ObjNbr.Ftime5 = txtFtime5.Text = Convert.ToString(dt.Rows[0]["Ftime5"]);
                ObjNbr.Ftime6 = txtFtime6.Text = Convert.ToString(dt.Rows[0]["Ftime6"]);
                ObjNbr.Ftime7 = txtFtime7.Text = Convert.ToString(dt.Rows[0]["Ftime7"]);
                ObjNbr.Ftime8 = txtFtime8.Text = Convert.ToString(dt.Rows[0]["Ftime8"]);
                ObjNbr.Ftime9 = txtFtime9.Text = Convert.ToString(dt.Rows[0]["Ftime9"]);

                ObjNbr.Formula1 = txtFormula1.Text = Convert.ToString(dt.Rows[0]["Formula1"]);
                ObjNbr.Formula2 = txtFormula2.Text = Convert.ToString(dt.Rows[0]["Formula2"]);
                ObjNbr.Formula3 = txtFormula3.Text = Convert.ToString(dt.Rows[0]["Formula3"]);
                ObjNbr.Formula4 = txtFormula4.Text = Convert.ToString(dt.Rows[0]["Formula4"]);
                ObjNbr.Formula5 = txtFormula5.Text = Convert.ToString(dt.Rows[0]["Formula5"]);
                ObjNbr.Formula6 = txtFormula6.Text = Convert.ToString(dt.Rows[0]["Formula6"]);
                ObjNbr.Formula7 = txtFormula7.Text = Convert.ToString(dt.Rows[0]["Formula7"]);
                ObjNbr.Formula8 = txtFormula8.Text = Convert.ToString(dt.Rows[0]["Formula8"]);
                ObjNbr.Formula9 = txtFormula9.Text = Convert.ToString(dt.Rows[0]["Formula9"]);

                ObjNbr.Breast1 = txtBreast1.Text = Convert.ToString(dt.Rows[0]["Breast1"]);
                ObjNbr.Breast2 = txtBreast2.Text = Convert.ToString(dt.Rows[0]["Breast2"]);
                ObjNbr.Breast3 = txtBreast3.Text = Convert.ToString(dt.Rows[0]["Breast3"]);
                ObjNbr.Breast4 = txtBreast4.Text = Convert.ToString(dt.Rows[0]["Breast4"]);
                ObjNbr.Breast5 = txtBreast5.Text = Convert.ToString(dt.Rows[0]["Breast5"]);
                ObjNbr.Breast6 = txtBreast6.Text = Convert.ToString(dt.Rows[0]["Breast6"]);
                ObjNbr.Breast7 = txtBreast7.Text = Convert.ToString(dt.Rows[0]["Breast7"]);
                ObjNbr.Breast8 = txtBreast8.Text = Convert.ToString(dt.Rows[0]["Breast8"]);
                ObjNbr.Breast9 = txtBreast9.Text = Convert.ToString(dt.Rows[0]["Breast9"]);

                ObjNbr.Supplement1 = txtSupplement1.Text = Convert.ToString(dt.Rows[0]["Supplement1"]);
                ObjNbr.Supplement2 = txtSupplement2.Text = Convert.ToString(dt.Rows[0]["Supplement2"]);
                ObjNbr.Supplement3 = txtSupplement3.Text = Convert.ToString(dt.Rows[0]["Supplement3"]);
                ObjNbr.Supplement4 = txtSupplement4.Text = Convert.ToString(dt.Rows[0]["Supplement4"]);
                ObjNbr.Supplement5 = txtSupplement5.Text = Convert.ToString(dt.Rows[0]["Supplement5"]);
                ObjNbr.Supplement6 = txtSupplement6.Text = Convert.ToString(dt.Rows[0]["Supplement6"]);
                ObjNbr.Supplement7 = txtSupplement7.Text = Convert.ToString(dt.Rows[0]["Supplement7"]);
                ObjNbr.Supplement8 = txtSupplement8.Text = Convert.ToString(dt.Rows[0]["Supplement8"]);
                ObjNbr.Supplement9 = txtSupplement9.Text = Convert.ToString(dt.Rows[0]["Supplement9"]);

                ObjNbr.cordCare1 = txtcordCare1.Text = Convert.ToString(dt.Rows[0]["cordCare1"]);
                ObjNbr.cordCare2 = txtcordCare2.Text = Convert.ToString(dt.Rows[0]["cordCare2"]);
                ObjNbr.cordCare3 = txtcordCare3.Text = Convert.ToString(dt.Rows[0]["cordCare3"]);
                ObjNbr.cordCare4 = txtcordCare4.Text = Convert.ToString(dt.Rows[0]["cordCare4"]);
                ObjNbr.cordCare5 = txtcordCare5.Text = Convert.ToString(dt.Rows[0]["cordCare5"]);
                ObjNbr.cordCare6 = txtcordCare6.Text = Convert.ToString(dt.Rows[0]["cordCare6"]);
                ObjNbr.cordCare7 = txtcordCare7.Text = Convert.ToString(dt.Rows[0]["cordCare7"]);
                ObjNbr.cordCare8 = txtcordCare8.Text = Convert.ToString(dt.Rows[0]["cordCare8"]);
                ObjNbr.cordCare9 = txtcordCare9.Text = Convert.ToString(dt.Rows[0]["cordCare9"]);

                ObjNbr.Urine1 = txtUrine1.Text = Convert.ToString(dt.Rows[0]["Urine1"]);
                ObjNbr.Urine2 = txtUrine2.Text = Convert.ToString(dt.Rows[0]["Urine2"]);
                ObjNbr.Urine3 = txtUrine3.Text = Convert.ToString(dt.Rows[0]["Urine3"]);
                ObjNbr.Urine4 = txtUrine4.Text = Convert.ToString(dt.Rows[0]["Urine4"]);
                ObjNbr.Urine5 = txtUrine5.Text = Convert.ToString(dt.Rows[0]["Urine5"]);
                ObjNbr.Urine6 = txtUrine6.Text = Convert.ToString(dt.Rows[0]["Urine6"]);
                ObjNbr.Urine7 = txtUrine7.Text = Convert.ToString(dt.Rows[0]["Urine7"]);
                ObjNbr.Urine8 = txtUrine8.Text = Convert.ToString(dt.Rows[0]["Urine8"]);
                ObjNbr.Urine9 = txtUrine9.Text = Convert.ToString(dt.Rows[0]["Urine9"]);

                ObjNbr.Stools1 = txtStools1.Text = Convert.ToString(dt.Rows[0]["Stools1"]);
                ObjNbr.Stools2 = txtStools2.Text = Convert.ToString(dt.Rows[0]["Stools2"]);
                ObjNbr.Stools3 = txtStools3.Text = Convert.ToString(dt.Rows[0]["Stools3"]);
                ObjNbr.Stools4 = txtStools4.Text = Convert.ToString(dt.Rows[0]["Stools4"]);
                ObjNbr.Stools5 = txtStools5.Text = Convert.ToString(dt.Rows[0]["Stools5"]);
                ObjNbr.Stools6 = txtStools6.Text = Convert.ToString(dt.Rows[0]["Stools6"]);
                ObjNbr.Stools7 = txtStools7.Text = Convert.ToString(dt.Rows[0]["Stools7"]);
                ObjNbr.Stools8 = txtStools8.Text = Convert.ToString(dt.Rows[0]["Stools8"]);
                ObjNbr.Stools9 = txtStools9.Text = Convert.ToString(dt.Rows[0]["Stools9"]);

                ObjNbr.RNSignature1 = txtRNSignature1.Text = Convert.ToString(dt.Rows[0]["RNSignature1"]);
                ObjNbr.RNSignature2 = txtRNSignature2.Text = Convert.ToString(dt.Rows[0]["RNSignature2"]);
                ObjNbr.RNSignature3 = txtRNSignature3.Text = Convert.ToString(dt.Rows[0]["RNSignature3"]);
                ObjNbr.RNSignature4 = txtRNSignature4.Text = Convert.ToString(dt.Rows[0]["RNSignature4"]);
                ObjNbr.RNSignature5 = txtRNSignature5.Text = Convert.ToString(dt.Rows[0]["RNSignature5"]);
                ObjNbr.RNSignature6 = txtRNSignature6.Text = Convert.ToString(dt.Rows[0]["RNSignature6"]);
                ObjNbr.RNSignature7 = txtRNSignature7.Text = Convert.ToString(dt.Rows[0]["RNSignature7"]);
                ObjNbr.RNSignature8 = txtRNSignature8.Text = Convert.ToString(dt.Rows[0]["RNSignature8"]);
                ObjNbr.RNSignature9 = txtRNSignature9.Text = Convert.ToString(dt.Rows[0]["RNSignature9"]);

                btnSave.Enabled = false;
            }


        }
    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        if (txtinfantname.Text.Trim() == "")
        {
            return;
        }
        if (txtBirthDate.Text.Trim() == "")
        {
            return;
        }
        if (Convert.ToString(Session["EmrOpdNo"]) != "")
        {
            ObjNbr.OpdNo = Convert.ToInt32(Session["EmrOpdNo"]);
        }
        else
        {
            ObjNbr.OpdNo = 0;
        }
        if (Convert.ToString(Session["EmrIpdNo"]) != "")
        {
            ObjNbr.IpdNo = Convert.ToInt32(Session["EmrIpdNo"]);
        }
        else
        {
            ObjNbr.IpdNo = 0;
        }
        ObjNbr.Patregid = Convert.ToString(Session["EmrRegNo"]);
        ObjNbr.CreatedBy = Convert.ToString(Session["username"]);
        ObjNbr.UpdatedBy = Convert.ToString(Session["username"]);
        ObjNbr.FId = Convert.ToInt32(Session["FId"]); ;
        ObjNbr.BranchId = Convert.ToInt32(Session["Branchid"]);

        ObjNbr.InfantName = txtinfantname.Text;
        ObjNbr.MotherName = txtmothername.Text;
        if (txtBirthDate.Text.Trim() != "")
        {
            ObjNbr.DateOfBirth = Convert.ToDateTime(txtBirthDate.Text);
        }

        if (RblGender.SelectedValue == "Male")
        {
            ObjNbr.BirthGender = "Male";
        }
        else
        {
            ObjNbr.BirthGender = "Female";
        }

        ObjNbr.Insert_NewBornRegister();
        LblMSg.Text = "New born register Successfully";
        LblMSg.ForeColor = System.Drawing.Color.Green;
    }
    protected void btnCard_Click(object sender, EventArgs e)
    {
        SqlConnection conn21 = DataAccess.ConInitForDC();
        SqlCommand sc21 = conn21.CreateCommand();
        sc21.CommandText = "ALTER VIEW [dbo].[VW_NewBorn_Card] AS SELECT   top(99.99) percent    PatientInformation.FirstName, Gender.GenderName, PatientInformation.MobileNo, PatientInformation.PhoneNo, PatientInformation.PatientAddress, PatientInformation.Age, PatientInformation.AgeType, NewBornRecord.BId, " +
                         "   PatientInformation.Patregid, NewBornRecord.OpdNo, NewBornRecord.IpdNo, NewBornRecord.InfantName, NewBornRecord.MotherName, NewBornRecord.BirthDate, NewBornRecord.FileNo, NewBornRecord.CIRC, " +
                          "  NewBornRecord.DrName, NewBornRecord.Time1, NewBornRecord.Time2, NewBornRecord.Time3, NewBornRecord.Time4, NewBornRecord.Time5, NewBornRecord.Time6, NewBornRecord.Time7, NewBornRecord.Time8, " +
                          "  NewBornRecord.Time9, NewBornRecord.Temperature1, NewBornRecord.Temperature2, NewBornRecord.Temperature3, NewBornRecord.Temperature4, NewBornRecord.Temperature5, NewBornRecord.Temperature6, " +
                          "  NewBornRecord.Temperature7, NewBornRecord.Temperature8, NewBornRecord.Temperature9, NewBornRecord.Respirations1, NewBornRecord.Respirations2, NewBornRecord.Respirations3, NewBornRecord.Respirations4, " +
                          "  NewBornRecord.Respirations5, NewBornRecord.Respirations6, NewBornRecord.Respirations7, NewBornRecord.Respirations8, NewBornRecord.Respirations9, NewBornRecord.HeartRate1, NewBornRecord.HeartRate2, " +
                          "  NewBornRecord.HeartRate3, NewBornRecord.HeartRate4, NewBornRecord.HeartRate5, NewBornRecord.HeartRate6, NewBornRecord.HeartRate7, NewBornRecord.HeartRate8, NewBornRecord.HeartRate9, " +
                          "  NewBornRecord.Ftime1, NewBornRecord.Ftime2, NewBornRecord.Ftime3, NewBornRecord.Ftime4, NewBornRecord.Ftime5, NewBornRecord.Ftime6, NewBornRecord.Ftime7, NewBornRecord.Ftime8, NewBornRecord.Ftime9, " +
                          "  NewBornRecord.Formula1, NewBornRecord.Formula2, NewBornRecord.Formula3, NewBornRecord.Formula4, NewBornRecord.Formula5, NewBornRecord.Formula6, NewBornRecord.Formula7, NewBornRecord.Formula8, " +
                          "  NewBornRecord.Formula9, NewBornRecord.Breast1, NewBornRecord.Breast2, NewBornRecord.Breast3, NewBornRecord.Breast4, NewBornRecord.Breast5, NewBornRecord.Breast6, NewBornRecord.Breast7, " +
                          "  NewBornRecord.Breast8, NewBornRecord.Breast9, NewBornRecord.Supplement1, NewBornRecord.Supplement2, NewBornRecord.Supplement3, NewBornRecord.Supplement4, NewBornRecord.Supplement5, " +
                          "  NewBornRecord.Supplement6, NewBornRecord.Supplement7, NewBornRecord.Supplement8, NewBornRecord.Supplement9, NewBornRecord.cordCare1, NewBornRecord.cordCare2, NewBornRecord.cordCare3, " +
                          "  NewBornRecord.cordCare4, NewBornRecord.cordCare5, NewBornRecord.cordCare6, NewBornRecord.cordCare7, NewBornRecord.cordCare8, NewBornRecord.cordCare9, NewBornRecord.Urine1, NewBornRecord.Urine2, " +
                          "  NewBornRecord.Urine3, NewBornRecord.Urine4, NewBornRecord.Urine5, NewBornRecord.Urine6, NewBornRecord.Urine7, NewBornRecord.Urine8, NewBornRecord.Urine9, NewBornRecord.Stools1, NewBornRecord.Stools2, " +
                          "  NewBornRecord.Stools3, NewBornRecord.Stools4, NewBornRecord.Stools5, NewBornRecord.Stools6, NewBornRecord.Stools7, NewBornRecord.Stools8, NewBornRecord.Stools9, NewBornRecord.RNSignature1, " +
                          "  NewBornRecord.RNSignature2, NewBornRecord.RNSignature3, NewBornRecord.RNSignature4, NewBornRecord.RNSignature5, NewBornRecord.RNSignature6, NewBornRecord.RNSignature7, NewBornRecord.RNSignature8, " +
                          "  NewBornRecord.RNSignature9, NewBornRecord.Branchid, NewBornRecord.FID, NewBornRecord.CreatedBy, NewBornRecord.CreatedOn, NewBornRecord.UpdatedBy, NewBornRecord.UpdatedOn " +
                          "  FROM            PatientInformation INNER JOIN " +
                          "  Gender ON PatientInformation.GenderId = Gender.GenderId  LEFT OUTER JOIN " +
                          "  NewBornRecord ON PatientInformation.NewBornRegMotherNo = NewBornRecord.Patregid " +
                      "Where 1=1";
        sc21.CommandText += " and PatientInformation.NewBornRegMotherNo ='" + Convert.ToString(Session["EmrRegNo"]) + "' order by NewBornRecord.BId ";
        //if (fromdate.Text != "")
        //{
        //    sc21.CommandText += " and (CAST(CAST(YEAR(RecM.transdate) AS varchar(4)) + '/' + CAST(MONTH(RecM.transdate) AS varchar(2)) + '/' + CAST(DAY(RecM.transdate) AS varchar(2)) AS datetime))  between ('" + Convert.ToDateTime(fromdate.Text).ToString("MM/dd/yyyy") + "') and ('" + Convert.ToDateTime(todate.Text).ToString("MM/dd/yyyy") + "')";// 
        //}

        //if (ddlusername.SelectedIndex > 0)
        //{
        //    sc21.CommandText += " and RecM.username='" + ddlusername.SelectedItem.Text.Trim() + "'";
        //}
        sc21.CommandText += " ";

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
        Session["rptname"] = Server.MapPath("~/DiagnosticReport/Rpt_NewBornCard.rpt");
        Session["reportname"] = "NewBornCard";
        Session["RPTFORMAT"] = "pdf";
        // Session["Parameter"] = "Yes";
        //  Session["rptDate"] = fromdate.Text + "  To  " + todate.Text;
        //  Session["rptusername"] = Convert.ToString(Session["username"]);


        ReportParameterClass.SelectionFormula = sql;
        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);
    }
}