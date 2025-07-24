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

public partial class DentalClinic : BasePage
{
    Dental_Clinic_C ObjDC = new Dental_Clinic_C();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
           txtdate.Text= DateTime.Now.ToString("dd/MM/yyyy");
        }
    }

  
    protected void btnsave_Click(object sender, EventArgs e)
    {

       
    }
    protected void btnreport_Click(object sender, EventArgs e)
    {

    }
    protected void btnhistory_Click(object sender, EventArgs e)
    {
        historyTem.Visible = true;
        IntrarorExm.Visible = false;
        DiagNostTreatment.Visible = false;
        TreatmentDet.Visible = false;
    }
    protected void btnIntraralExamination_Click(object sender, EventArgs e)
    {
        historyTem.Visible = false;
        DiagNostTreatment.Visible = false;
        IntrarorExm.Visible = true;
        TreatmentDet.Visible = false;
    }
    protected void btnDiagnisis_Treatment_Click(object sender, EventArgs e)
    {
        DiagNostTreatment.Visible = true;
        historyTem.Visible = false;
        IntrarorExm.Visible = false;
        TreatmentDet.Visible = false;
    }
    protected void btnTreatmentdetails_Click(object sender, EventArgs e)
    {
        TreatmentDet.Visible = true;
        DiagNostTreatment.Visible = false;
        historyTem.Visible = false;
        IntrarorExm.Visible = false;
        SetInitialRow();

    }
    protected void btnreportHistory_Click(object sender, EventArgs e)
    {
        string sql = "";
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
        ObjDC.Alter_Dental_ClinicalHistory_Report(Convert.ToInt32(Session["EmrRegNo"]), Convert.ToInt32(Session["EmrOpdNo"]), Convert.ToInt32(Session["EmrIpdNo"]));
       // ObjDC.Alter_Vw_Theatre_CheckList(ObjDALPPE);
        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Report/Rpt_Dental_Clinic_History_Report.rpt");
        Session["reportname"] = "Dental_Clinic_History";
        Session["RPTFORMAT"] = "pdf";

        //ReportParameterClass.SelectionFormula = sql;
        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);
    }
    protected void btnsaveHistory_Click(object sender, EventArgs e)
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
        ObjDC.P_ReferBy = txtreferby.Text;
        if (txtdate.Text != "")
        {
            ObjDC.P_EntryDate = Convert.ToDateTime(txtdate.Text);
        }
        ObjDC.P_ChiefComplants = txtChiefcomplaints.Text;
        ObjDC.P_Allergy = txtAllergy.Text;
        ObjDC.P_Pregnancy = txtPregnancy.Text;
        ObjDC.P_Medication = txtMedication.Text;
        ObjDC.P_Habits = txtHabits.Text;
        ObjDC.P_PastDentalHistory = txtPastDentalHistory.Text;
        ObjDC.P_OtherHistory = txtOther.Text;
        if (ChkHypertension.Checked == true)
        {
            ObjDC.P_Hypertension = true;
        }
        else
        {
            ObjDC.P_Hypertension = false;
        }
        if (ChkDiabetes.Checked == true)
        {
            ObjDC.P_Diabetes = true;
        }
        else
        {
            ObjDC.P_Diabetes = false;
        }
        if (ChkAnaemia.Checked == true)
        {
            ObjDC.P_Anaemia = true;
        }
        else
        {
            ObjDC.P_Anaemia = false;
        }
        if (ChkKidneyDisease.Checked == true)
        {
            ObjDC.P_KidneyDisease = true;
        }
        else
        {
            ObjDC.P_KidneyDisease = false;
        }
        if (chkAsthama.Checked == true)
        {
            ObjDC.P_Asthama = true;
        }
        else
        {
            ObjDC.P_Asthama = false;
        }
        if (chkJaundice.Checked == true)
        {
            ObjDC.P_Jaundice = true;
        }
        else
        {
            ObjDC.P_Jaundice = false;
        }

        ObjDC.Insert_DentalClinicHistory();

    }
    protected void btnsavetIntraoral_Click(object sender, EventArgs e)
    {

    }
    protected void btnsavetIntraoralReport_Click(object sender, EventArgs e)
    {

    }
    protected void btnDiagnossaveReport_Click(object sender, EventArgs e)
    {
        string sql = "";
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
        ObjDC.Alter_Dental_Diagnosis_Treatment_Report(Convert.ToInt32(Session["EmrRegNo"]), Convert.ToInt32(Session["EmrOpdNo"]), Convert.ToInt32(Session["EmrIpdNo"]));
        // ObjDC.Alter_Vw_Theatre_CheckList(ObjDALPPE);
        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Report/Rpt_Dental_Diagnosis_Treatment_Report.rpt");
        Session["reportname"] = "Dental_Diagnosis_Treatment";
        Session["RPTFORMAT"] = "pdf";

        //ReportParameterClass.SelectionFormula = sql;
        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);
    }
    protected void btnDiagnossave_Click(object sender, EventArgs e)
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
        ObjDC.P_ReferBy = txtreferby.Text;
        if (txtdate.Text != "")
        {
            ObjDC.P_EntryDate = Convert.ToDateTime(txtdate.Text);
        }
        ObjDC.P_Diagnosis = txtDiagnosis.Text;
        ObjDC.P_TreatmentAdvised= txttreatmentadvised.Text;

        ObjDC.P_Branchid = Convert.ToInt32(Session["Branchid"]);

        ObjDC.Insert_DentalDiagnosis_Treatment();
    }
    protected void btntreatmentdeta_Click(object sender, EventArgs e)
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
        ObjDC.P_ReferBy = txtreferby.Text;
        if (txtdate.Text != "")
        {
            ObjDC.P_EntryDate = Convert.ToDateTime(txtdate.Text);
        }
        for (int i = 0; i < GvHairLaser.Rows.Count; i++)
        {

            //extract the TextBox values

            TextBox box1 = (TextBox)GvHairLaser.Rows[i].Cells[1].FindControl("txtTreatmentDate");
            TextBox box2 = (TextBox)GvHairLaser.Rows[i].Cells[2].FindControl("txtTreatmentDone");
            TextBox box3 = (TextBox)GvHairLaser.Rows[i].Cells[3].FindControl("txtNextAppoin");
            TextBox box4 = (TextBox)GvHairLaser.Rows[i].Cells[4].FindControl("txtRemark");

            ObjDC.P_TreatementDate = Convert.ToDateTime( box1.Text);
            ObjDC.P_TreatmentDone = box2.Text;
            ObjDC.P_NextAppointment = box3.Text;
            ObjDC.P_Remarks = box4.Text;

            ObjDC.P_Branchid = Convert.ToInt32(Session["Branchid"]);

            ObjDC.Insert_DentalTreatment_Details();
        }
    }
    protected void btntreatmentPrint_Click(object sender, EventArgs e)
    {
        string sql = "";
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
        ObjDC.Alter_Dental_Treatment_Report(Convert.ToInt32(Session["EmrRegNo"]), Convert.ToInt32(Session["EmrOpdNo"]), Convert.ToInt32(Session["EmrIpdNo"]));
        // ObjDC.Alter_Vw_Theatre_CheckList(ObjDALPPE);
        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Report/Rpt_Dental_Treatment_Details_Report.rpt");
        Session["reportname"] = "Dental_Treatment_Details";
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

        dt.Columns.Add(new DataColumn("TreatmentDate", typeof(string)));
        dt.Columns.Add(new DataColumn("TreatmentDone", typeof(string)));
        dt.Columns.Add(new DataColumn("NextAppoin", typeof(string)));
        dt.Columns.Add(new DataColumn("Remark", typeof(string)));





        dr = dt.NewRow();

        dr["RowNumber"] = 1;

        dr["TreatmentDate"] = DateTime.Now.ToString("dd/MM/yyyy"); ;
        dr["TreatmentDone"] = string.Empty;
        dr["NextAppoin"] = string.Empty;
        dr["Remark"] = string.Empty;


        dt.Rows.Add(dr);



        //Store the DataTable in ViewState

        ViewState["CurrentTable"] = dt;



        GvHairLaser.DataSource = dt;

        GvHairLaser.DataBind();

    }
    protected void ButtonAdd_Click(object sender, EventArgs e)
    {

        AddNewRowToGrid();

    }
    private void AddNewRowToGrid()
    {

        int rowIndex = 0;



        if (ViewState["CurrentTable"] != null)
        {

            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];

            DataRow drCurrentRow = null;

            if (dtCurrentTable.Rows.Count > 0)
            {

                for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                {

                    //extract the TextBox values

                    TextBox box1 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[1].FindControl("txtTreatmentDate");
                    TextBox box2 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[2].FindControl("txtTreatmentDone");

                    TextBox box3 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[1].FindControl("txtNextAppoin");
                    TextBox box4 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[2].FindControl("txtRemark");



                    drCurrentRow = dtCurrentTable.NewRow();

                    drCurrentRow["RowNumber"] = i + 1;



                    dtCurrentTable.Rows[i - 1]["TreatmentDate"] = box1.Text;
                    dtCurrentTable.Rows[i - 1]["TreatmentDone"] = box2.Text;
                    dtCurrentTable.Rows[i - 1]["NextAppoin"] = box3.Text;
                    dtCurrentTable.Rows[i - 1]["Remark"] = box4.Text;


                    rowIndex++;

                }
                drCurrentRow["RowNumber"] = rowIndex;
                DateTime time = DateTime.Now;
                String s = time.ToString("hh:mm tt");

                drCurrentRow["TreatmentDate"] = DateTime.Now.ToString("dd/MM/yyyy"); ;
                drCurrentRow["TreatmentDone"] = "";
                drCurrentRow["NextAppoin"] = "";
                drCurrentRow["Remark"] = "";

                dtCurrentTable.Rows.Add(drCurrentRow);

                ViewState["CurrentTable"] = dtCurrentTable;



                GvHairLaser.DataSource = dtCurrentTable;
                GvHairLaser.DataBind();

            }

        }

        else
        {

            Response.Write("ViewState is null");

        }



        //Set Previous Data on Postbacks

        SetPreviousData();

    }
    private void SetPreviousData()
    {

        int rowIndex = 0;

        if (ViewState["CurrentTable"] != null)
        {

            DataTable dt = (DataTable)ViewState["CurrentTable"];

            if (dt.Rows.Count > 0)
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    TextBox box1 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[1].FindControl("txtTreatmentDate");
                    TextBox box2 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[2].FindControl("txtTreatmentDone");
                    TextBox box3 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[3].FindControl("txtNextAppoin");
                    TextBox box4 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[4].FindControl("txtRemark");

                    box1.Text = dt.Rows[i]["TreatmentDate"].ToString();
                    box2.Text = dt.Rows[i]["TreatmentDone"].ToString();
                    box3.Text = dt.Rows[i]["NextAppoin"].ToString();
                    box4.Text = dt.Rows[i]["Remark"].ToString();


                    rowIndex++;

                }

            }

        }

    }
}