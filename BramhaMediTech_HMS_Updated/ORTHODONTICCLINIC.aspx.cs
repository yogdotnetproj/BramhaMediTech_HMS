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

public partial class ORTHODONTICCLINIC :BasePage
{
    ORTHODONTICCLINIC_C ObjOC = new ORTHODONTICCLINIC_C();
    public enum MessageType { Success, Error, Info, Warning };
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            
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
        Investigat.Visible = false;
    }
    protected void btnIntraralExamination_Click(object sender, EventArgs e)
    {
        historyTem.Visible = false;
        DiagNostTreatment.Visible = false;
        IntrarorExm.Visible = true;
        TreatmentDet.Visible = false;
        Investigat.Visible = false;
    }
    protected void btnDiagnisis_Treatment_Click(object sender, EventArgs e)
    {
        DiagNostTreatment.Visible = true;
        historyTem.Visible = false;
        IntrarorExm.Visible = false;
        TreatmentDet.Visible = false;
        Investigat.Visible = false;
    }
    protected void btnTreatmentdetails_Click(object sender, EventArgs e)
    {
        TreatmentDet.Visible = true;
        DiagNostTreatment.Visible = false;
        historyTem.Visible = false;
        IntrarorExm.Visible = false;
        Investigat.Visible = false;
        SetInitialRow();

    }
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
    protected void btnInvistigation_Click(object sender, EventArgs e)
    {
        Investigat.Visible = true;
        TreatmentDet.Visible = false;
        DiagNostTreatment.Visible = false;
        historyTem.Visible = false;
        IntrarorExm.Visible = false;
    }
    protected void btnreportHistory_Click(object sender, EventArgs e)
    {
        string sql = "";
        if (Convert.ToString(Session["EmrOpdNo"]) != "")
        {
            ObjOC.P_OpdNo = Convert.ToInt32(Session["EmrOpdNo"]);
        }
        else
        {
            ObjOC.P_OpdNo = 0;
        }
        if (Convert.ToString(Session["EmrIpdNo"]) != "")
        {
            ObjOC.P_IpdNo = Convert.ToInt32(Session["EmrIpdNo"]);
        }
        else
        {
            ObjOC.P_IpdNo = 0;
        }
        ObjOC.P_Patregid = Convert.ToInt32(Session["EmrRegNo"]);
        ObjOC.Alter_Orthodontic_Dental_Clinic_History_Report(Convert.ToInt32(Session["EmrRegNo"]), Convert.ToInt32(Session["EmrOpdNo"]), Convert.ToInt32(Session["EmrIpdNo"]));
        // ObjDC.Alter_Vw_Theatre_CheckList(ObjDALPPE);
        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Report/Rpt_Orthodontic_Dental_Clinic_History_Report.rpt");
        Session["reportname"] = "Orthodontic_Dental_Clinic_History";
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
            ObjOC.P_OpdNo = Convert.ToInt32(Session["EmrOpdNo"]);
        }
        else
        {
            ObjOC.P_OpdNo = 0;
        }
        if (Convert.ToString(Session["EmrIpdNo"]) != "")
        {
            ObjOC.P_IpdNo = Convert.ToInt32(Session["EmrIpdNo"]);
        }
        else
        {
            ObjOC.P_IpdNo = 0;
        }
        ObjOC.P_Patregid = Convert.ToInt32(Session["EmrRegNo"]);
        ObjOC.P_CreatedBy = Convert.ToString(Session["username"]);
        ObjOC.P_ReferBy = txtreferby.Text;
        ObjOC.P_OrthoNo =txtOrthoNo.Text;
       
        ObjOC.P_ChiefComplants = txtChiefcomplaints.Text;
        ObjOC.P_FamilyHistory = txtFamilyHistory.Text;
      
        ObjOC.P_Medication = txtMedication.Text;
        ObjOC.P_Habits = txtHabits.Text;
        ObjOC.P_PastDentalHistory = txtPastDentalHistory.Text;
        ObjOC.P_OtherHistory = txtOther.Text;
        if (ChkHypertension.Checked == true)
        {
            ObjOC.P_Hypertension = true;
        }
        else
        {
            ObjOC.P_Hypertension = false;
        }
        if (ChkDiabetes.Checked == true)
        {
            ObjOC.P_Diabetes = true;
        }
        else
        {
            ObjOC.P_Diabetes = false;
        }
        if (ChkAnaemia.Checked == true)
        {
            ObjOC.P_Anaemia = true;
        }
        else
        {
            ObjOC.P_Anaemia = false;
        }
        if (ChkKidneyDisease.Checked == true)
        {
            ObjOC.P_KidneyDisease = true;
        }
        else
        {
            ObjOC.P_KidneyDisease = false;
        }
        if (chkAsthama.Checked == true)
        {
            ObjOC.P_Asthama = true;
        }
        else
        {
            ObjOC.P_Asthama = false;
        }
        if (chkJaundice.Checked == true)
        {
            ObjOC.P_Jaundice = true;
        }
        else
        {
            ObjOC.P_Jaundice = false;
        }

        if (ChkAllergy.Checked == true)
        {
            ObjOC.P_Allergy = true;
        }
        else
        {
            ObjOC.P_Allergy  = false;
        }
        if (ChkBleedingdisorder.Checked == true)
        {
            ObjOC.P_BleedingDisorder = true;
        }
        else
        {
            ObjOC.P_BleedingDisorder = false;
        }
        if (ChkPregnant.Checked == true)
        {
            ObjOC.P_Pregnant = true;
        }
        else
        {
            ObjOC.P_Pregnant = false;
        }
        ObjOC.Insert_Orthodontic_Dental_Clinic_History();
        ShowMessage("Record save successfully", MessageType.Success);
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
            ObjOC.P_OpdNo = Convert.ToInt32(Session["EmrOpdNo"]);
        }
        else
        {
            ObjOC.P_OpdNo = 0;
        }
        if (Convert.ToString(Session["EmrIpdNo"]) != "")
        {
            ObjOC.P_IpdNo = Convert.ToInt32(Session["EmrIpdNo"]);
        }
        else
        {
            ObjOC.P_IpdNo = 0;
        }
        ObjOC.P_Patregid = Convert.ToInt32(Session["EmrRegNo"]);
        ObjOC.Alter_Orthodontic_Diagnosis_Treatment_Report(Convert.ToInt32(Session["EmrRegNo"]), Convert.ToInt32(Session["EmrOpdNo"]), Convert.ToInt32(Session["EmrIpdNo"]));
        // ObjDC.Alter_Vw_Theatre_CheckList(ObjDALPPE);
        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Report/Rpt_Orthodontic_DiagnosisTreatment_Report.rpt");
        Session["reportname"] = "Orthodontic_DiagnosisTreatment";
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
            ObjOC.P_OpdNo = Convert.ToInt32(Session["EmrOpdNo"]);
        }
        else
        {
            ObjOC.P_OpdNo = 0;
        }
        if (Convert.ToString(Session["EmrIpdNo"]) != "")
        {
            ObjOC.P_IpdNo = Convert.ToInt32(Session["EmrIpdNo"]);
        }
        else
        {
            ObjOC.P_IpdNo = 0;
        }
        ObjOC.P_Patregid = Convert.ToInt32(Session["EmrRegNo"]);
        ObjOC.P_ReferBy = txtreferby.Text;
        ObjOC.P_OrthoNo = txtOrthoNo.Text;

        ObjOC.P_TreatmentAdvice = ddlTreatmentAdvise.SelectedValue;
        ObjOC.P_TreatmentAdvice1 = ddlTreatmentAdvise1.SelectedValue;

        if (ChkFunctionalRemoval.Checked == true)
        {
            ObjOC.P_IS_FunctionalRemoval = true;
        }
        else
        {
            ObjOC.P_IS_FunctionalRemoval = false;
        }
        if (ChkFunctionalFixed.Checked == true)
        {
            ObjOC.P_Is_Functional_Fixed = true;
        }
        else
        {
            ObjOC.P_Is_Functional_Fixed = false;
        }
        if (ChkOrthopedic.Checked == true)
        {
            ObjOC.P_IS_Orthopedic = true;
        }
        else
        {
            ObjOC.P_IS_Orthopedic = false;
        }
        if (ChkExpansion.Checked == true)
        {
            ObjOC.P_IS_Expansion = true;
        }
        else
        {
            ObjOC.P_IS_Expansion = false;
        }

        ObjOC.P_FunctionalRemoval = txtfunctionremoval.Text;
        ObjOC.P_Functional_Fixed = txtFunctionalFixed.Text;
        ObjOC.P_Orthopedic = txtOrthopedic.Text;
        ObjOC.P_Expansion = txtExpansion.Text;

        ObjOC.P_Upper_Retention  = ddlUpper.SelectedValue;
        ObjOC.P_Lower_Retention = ddlLower.SelectedValue;

        ObjOC.P_Diagnosis = txttreatmentDiagnosis.Text;
        ObjOC.P_Appliance = txtAppliance.Text;
        ObjOC.P_Extractions = txtExtractions.Text;
        ObjOC.P_Envelope = txtEnvelope.Text;
        ObjOC.P_Approximate = txtApproximatetretime.Text;

        ObjOC.P_CreatedBy = Convert.ToString(Session["username"]);
        ObjOC.P_Branchid = Convert.ToInt32(Session["Branchid"]);
        ObjOC.Insert_Orthodontic_Dental_Diagnosis_Treatment();
        ShowMessage("Record save successfully", MessageType.Success);
    }
    protected void btntreatmentdeta_Click(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["EmrOpdNo"]) != "")
        {
            ObjOC.P_OpdNo = Convert.ToInt32(Session["EmrOpdNo"]);
        }
        else
        {
            ObjOC.P_OpdNo = 0;
        }
        if (Convert.ToString(Session["EmrIpdNo"]) != "")
        {
            ObjOC.P_IpdNo = Convert.ToInt32(Session["EmrIpdNo"]);
        }
        else
        {
            ObjOC.P_IpdNo = 0;
        }
        ObjOC.P_Patregid = Convert.ToInt32(Session["EmrRegNo"]);
        ObjOC.P_CreatedBy = Convert.ToString(Session["username"]);
        ObjOC.P_ReferBy = txtreferby.Text;
        ObjOC.P_OrthoNo = txtOrthoNo.Text;
        if (txtTreatmentAmount.Text != "")
        {
            ObjOC.P_TreatmentAmount = Convert.ToSingle(txtTreatmentAmount.Text);
        }
        else
        {
            ObjOC.P_TreatmentAmount = 0;
        }
        if (txtBalanceAmt.Text != "")
        {
            ObjOC.P_BalanceAmount = Convert.ToSingle(txtBalanceAmt.Text);
        }
        else
        {
            ObjOC.P_BalanceAmount = 0;
        }
        for (int i = 0; i < GvHairLaser.Rows.Count; i++)
        {

            //extract the TextBox values

            TextBox box1 = (TextBox)GvHairLaser.Rows[i].Cells[1].FindControl("txtTreatmentDate");
            TextBox box2 = (TextBox)GvHairLaser.Rows[i].Cells[2].FindControl("txtTreatmentProgress");
            TextBox box3 = (TextBox)GvHairLaser.Rows[i].Cells[3].FindControl("txtPayment");
            TextBox box4 = (TextBox)GvHairLaser.Rows[i].Cells[4].FindControl("txtRemark");

            ObjOC.P_TreatementDate = Convert.ToDateTime(box1.Text);
            ObjOC.P_TreatmentDone = box2.Text;
            ObjOC.P_NextAppointment = box3.Text;
            ObjOC.P_Remarks = box4.Text;

            ObjOC.P_Branchid = Convert.ToInt32(Session["Branchid"]);

            ObjOC.Insert_Dental_Ortho_Treatment_Details();

        }
        ShowMessage("Record save successfully", MessageType.Success);
    }
    protected void btntreatmentPrint_Click(object sender, EventArgs e)
    {
        string sql = "";
        if (Convert.ToString(Session["EmrOpdNo"]) != "")
        {
            ObjOC.P_OpdNo = Convert.ToInt32(Session["EmrOpdNo"]);
        }
        else
        {
            ObjOC.P_OpdNo = 0;
        }
        if (Convert.ToString(Session["EmrIpdNo"]) != "")
        {
            ObjOC.P_IpdNo = Convert.ToInt32(Session["EmrIpdNo"]);
        }
        else
        {
            ObjOC.P_IpdNo = 0;
        }
        ObjOC.P_Patregid = Convert.ToInt32(Session["EmrRegNo"]);
        ObjOC.Alter_Orthodontic_Dental_OrthoTreatment_Details_Report(Convert.ToInt32(Session["EmrRegNo"]), Convert.ToInt32(Session["EmrOpdNo"]), Convert.ToInt32(Session["EmrIpdNo"]));
        // ObjDC.Alter_Vw_Theatre_CheckList(ObjDALPPE);
        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Report/Rpt_Orthodontic_Treatment_Report.rpt");
        Session["reportname"] = "Orthodontic_Treatment";
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
        dt.Columns.Add(new DataColumn("TreatmentProgress", typeof(string)));
        dt.Columns.Add(new DataColumn("Payment", typeof(string)));
        dt.Columns.Add(new DataColumn("Remark", typeof(string)));





        dr = dt.NewRow();

        dr["RowNumber"] = 1;

        dr["TreatmentDate"] = DateTime.Now.ToString("dd/MM/yyyy");
        dr["TreatmentProgress"] = string.Empty;
        dr["Payment"] = string.Empty;
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
                    TextBox box2 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[2].FindControl("txtTreatmentProgress");

                    TextBox box3 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[3].FindControl("txtPayment");
                    TextBox box4 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[4].FindControl("txtRemark");



                    drCurrentRow = dtCurrentTable.NewRow();

                    drCurrentRow["RowNumber"] = i + 1;



                    dtCurrentTable.Rows[i - 1]["TreatmentDate"] = box1.Text;
                    dtCurrentTable.Rows[i - 1]["TreatmentProgress"] = box2.Text;
                    dtCurrentTable.Rows[i - 1]["Payment"] = box3.Text;
                    dtCurrentTable.Rows[i - 1]["Remark"] = box4.Text;


                    rowIndex++;

                }
                drCurrentRow["RowNumber"] = rowIndex;
                DateTime time = DateTime.Now;
                String s = time.ToString("hh:mm tt");

                drCurrentRow["TreatmentDate"] = DateTime.Now.ToString("dd/MM/yyyy"); ;
                drCurrentRow["TreatmentProgress"] = "";
                drCurrentRow["Payment"] = "";
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
                    TextBox box2 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[2].FindControl("txtTreatmentProgress");
                    TextBox box3 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[3].FindControl("txtPayment");
                    TextBox box4 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[4].FindControl("txtRemark");

                    box1.Text = dt.Rows[i]["TreatmentDate"].ToString();
                    box2.Text = dt.Rows[i]["TreatmentProgress"].ToString();
                    box3.Text = dt.Rows[i]["Payment"].ToString();
                    box4.Text = dt.Rows[i]["Remark"].ToString();


                    rowIndex++;

                }

            }

        }

    }

    protected void btnprintinvestigation_Click(object sender, EventArgs e)
    {
        string sql = "";
        if (Convert.ToString(Session["EmrOpdNo"]) != "")
        {
            ObjOC.P_OpdNo = Convert.ToInt32(Session["EmrOpdNo"]);
        }
        else
        {
            ObjOC.P_OpdNo = 0;
        }
        if (Convert.ToString(Session["EmrIpdNo"]) != "")
        {
            ObjOC.P_IpdNo = Convert.ToInt32(Session["EmrIpdNo"]);
        }
        else
        {
            ObjOC.P_IpdNo = 0;
        }
        ObjOC.P_Patregid = Convert.ToInt32(Session["EmrRegNo"]);
        ObjOC.Alter_OrthodonticPrintInvestigation_Report(Convert.ToInt32(Session["EmrRegNo"]), Convert.ToInt32(Session["EmrOpdNo"]), Convert.ToInt32(Session["EmrIpdNo"]));
        // ObjDC.Alter_Vw_Theatre_CheckList(ObjDALPPE);
        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Report/Rpt_Orthodontic_Investigation_Report.rpt");
        Session["reportname"] = "Orthodontic_Investigation";
        Session["RPTFORMAT"] = "pdf";

        //ReportParameterClass.SelectionFormula = sql;
        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);
    }
    protected void btnsaveinvestigation_Click(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["EmrOpdNo"]) != "")
        {
            ObjOC.P_OpdNo = Convert.ToInt32(Session["EmrOpdNo"]);
        }
        else
        {
            ObjOC.P_OpdNo = 0;
        }
        if (Convert.ToString(Session["EmrIpdNo"]) != "")
        {
            ObjOC.P_IpdNo = Convert.ToInt32(Session["EmrIpdNo"]);
        }
        else
        {
            ObjOC.P_IpdNo = 0;
        }
        ObjOC.P_Patregid = Convert.ToInt32(Session["EmrRegNo"]);
        ObjOC.P_ReferBy = txtreferby.Text;
        ObjOC.P_OrthoNo = txtOrthoNo.Text;

        if (ChkLateralCephalogram.Checked == true)
        {
            ObjOC.P_Pre_Lateral = true;
        }
        else
        {
            ObjOC.P_Pre_Lateral = false;
        }
        if (ChkFrontal.Checked == true)
        {
            ObjOC.P_Pre_Frontal = true;
        }
        else
        {
            ObjOC.P_Pre_Frontal = false;
        }
        if (ChkOPG.Checked == true)
        {
            ObjOC.P_Pre_OPG = true;
        }
        else
        {
            ObjOC.P_Pre_Frontal = false;
        }
        if (ChkIOPA.Checked == true)
        {
            ObjOC.P_Pre_IOPA = true;
        }
        else
        {
            ObjOC.P_Pre_IOPA = false;
        }
        if (ChkSLOB.Checked == true)
        {
            ObjOC.P_Pre_SLOB = true;
        }
        else
        {
            ObjOC.P_Pre_SLOB = false;
        }
        if (ChkOCCLUSAL.Checked == true)
        {
            ObjOC.P_Pre_OCCLUSAL = true;
        }
        else
        {
            ObjOC.P_Pre_OCCLUSAL = false;
        }

        //---------
        if (ChkMIDLateral.Checked == true)
        {
            ObjOC.P_Mid_Lateral = true;
        }
        else
        {
            ObjOC.P_Mid_Lateral = false;
        }
        if (ChkMIDFrontal.Checked == true)
        {
            ObjOC.P_Mid_Frontal = true;
        }
        else
        {
            ObjOC.P_Mid_Frontal = false;
        }
        if (ChkMIDOPG.Checked == true)
        {
            ObjOC.P_Mid_OPG = true;
        }
        else
        {
            ObjOC.P_Mid_Frontal = false;
        }
        if (ChkMIDIOPA.Checked == true)
        {
            ObjOC.P_Mid_IOPA = true;
        }
        else
        {
            ObjOC.P_Mid_IOPA = false;
        }
        if (ChkMIDSLOB.Checked == true)
        {
            ObjOC.P_Mid_SLOB = true;
        }
        else
        {
            ObjOC.P_Mid_SLOB = false;
        }
        if (ChkMIDOCCLUSAL.Checked == true)
        {
            ObjOC.P_Mid_OCCLUSAL = true;
        }
        else
        {
            ObjOC.P_Mid_OCCLUSAL = false;
        }
        //---------
        if (ChkPostLateral.Checked == true)
        {
            ObjOC.P_Post_Lateral = true;
        }
        else
        {
            ObjOC.P_Post_Lateral = false;
        }
        if (ChkPostFrontal.Checked == true)
        {
            ObjOC.P_Post_Frontal = true;
        }
        else
        {
            ObjOC.P_Post_Frontal = false;
        }
        if (ChkPostOPG.Checked == true)
        {
            ObjOC.P_Post_OPG = true;
        }
        else
        {
            ObjOC.P_Post_OPG = false;
        }
        if (ChkPostIOPA.Checked == true)
        {
            ObjOC.P_Post_IOPA = true;
        }
        else
        {
            ObjOC.P_Post_IOPA = false;
        }
        if (ChkPostSLOB.Checked == true)
        {
            ObjOC.P_Post_SLOB = true;
        }
        else
        {
            ObjOC.P_Post_SLOB = false;
        }
        if (ChkPostOCCLUSAL.Checked == true)
        {
            ObjOC.P_Post_OCCLUSAL = true;
        }
        else
        {
            ObjOC.P_Post_OCCLUSAL = false;
        }

        if (ChkEXTRAORAL.Checked == true)
        {
            ObjOC.P_EXTRAORAL = true;
        }
        else
        {
            ObjOC.P_EXTRAORAL = false;
        }
        if (ChkINTRAORAL.Checked == true)
        {
            ObjOC.P_INTRAORAL = true;
        }
        else
        {
            ObjOC.P_INTRAORAL = false;
        }
        ObjOC.P_Pre_Model = txtModelPreTreatment.Text;
        ObjOC.P_Mid_Model = txtModelMIDTreatment.Text;
        ObjOC.P_Post_Model = txtModelPostTreatment.Text;

        ObjOC.P_Pre_PHOTOGRAPHS = txtPHOTOGRAPHSPre.Text;
        ObjOC.P_Mid_PHOTOGRAPHS = txtPHOTOGRAPHSMid.Text;
        ObjOC.P_Post_PHOTOGRAPHS = txtPHOTOGRAPHSPost.Text;

        ObjOC.P_Pre_Other = txtOthersPre.Text;
        ObjOC.P_Mid_Other = txtOthersMid.Text;
        ObjOC.P_Post_Other = txtOthersPost.Text;

        ObjOC.P_Comments = txtInvComments.Text;
        ObjOC.P_Comments_Models = txtModealsComments.Text;
        ObjOC.P_Comments_PHOTOGRAPHS = txtPHOTOGRAPHSComments.Text;
        ObjOC.P_Comments_Other = txtOtherscomments.Text;

        ObjOC.P_CreatedBy = Convert.ToString(Session["username"]);
        ObjOC.Insert_Orthodontic_Dental_Investigation_Details();
        ShowMessage("Record save successfully", MessageType.Success);
    }
}