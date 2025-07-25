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

public partial class Gynology_Antenatal :BasePage
{
    clsEmr obj = new clsEmr();
    clsTreatment objTreat = new clsTreatment();
    clsTreatmentTransaction transaction = new clsTreatmentTransaction();
    DataTable tempDatatable = new DataTable();
   // BELHIVCounterExamination objBLLHCE = new BELHIVCounterExamination();
   // DALHIVCounterExamination objDAHCE = new DALHIVCounterExamination();
   // DataTable dt = new DataTable();
    BELGeneralGynology objBLLHCET = new BELGeneralGynology();

   // clsEmr obj = new clsEmr();
   // clsTreatment objTreat = new clsTreatment();
   // clsTreatmentTransaction transaction = new clsTreatmentTransaction();
   // DataTable tempDatatable = new DataTable();
    BELGeneralGynology objBLLHCE = new BELGeneralGynology();
    DALGeneralGynology objDAHCE = new DALGeneralGynology();
    DataTable dt = new DataTable();
    
    string RegistrationTypeId = "";
    string UserId = "";


    string BillGroupId = "";
    string ServiceId = "";
    string ConsultantDrId = "";
    int DoctorId;
    double Billtotal = 0;
    string BirthDate = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            // txtStart.Text = DateTime.Now.ToString("dd/MM/yyyy");
            if (Session["EmrRegNo"] != "")
            {
                string regId = Convert.ToString(Session["EmrRegNo"]);
                string name = Request.QueryString["Name"];
                string opd = Convert.ToString(Session["EmrOpdNo"]);
                string entrydate = Request.QueryString["EntryDate"];
                Session["Branchid"] = "1";
                // lblOpd.Text = opd;
                BindSurgicalAdvice();
               // BindHIVEncounter();
                BindTemplate();
                SetInitialRow();
                SetInitialRow_Clinical();
                SetInitialRow_Othdet();
                DeleteTemplate();
                DeleteCaseSheet();
                LoadSlideBar("", "");
            }
        }
    }       
    
    public void BindSurgicalAdvice()
    {
       

    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["EmrOpdNo"]) != "")
        {
            objDAHCE.OpdNo = Convert.ToInt32(Session["EmrOpdNo"]);
        }
        else
        {
            objDAHCE.OpdNo = 0;
        }
        if (Convert.ToString(Session["EmrIpdNo"]) != "")
        {
            objDAHCE.IpdNo = Convert.ToInt32(Session["EmrIpdNo"]);
        }
        else
        {
            objDAHCE.IpdNo = 0;
        }
        objDAHCE.Patregid = Convert.ToString(Session["EmrRegNo"]);

        

        objDAHCE.CreatedBy = Convert.ToString(Session["username"]);
        objDAHCE.UpdatedBy = Convert.ToString(Session["username"]);
        objDAHCE.FId = Convert.ToInt32(Session["FId"]); ;
        objDAHCE.BranchId = Convert.ToInt32(Session["Branchid"]);
        objDAHCE.Gravida = txtGravida.Text;
        objDAHCE.Para = txtPara.Text;
        objDAHCE.RiskFactors = txtRiskFactor.Text;
        objDAHCE.Allergies = txtAllergies.Text;
        objDAHCE.Ethinicity = ddlEthinicity.SelectedValue;
        objDAHCE.SignificantFamilyHistory = txtSignificantFamilyHis.Text;
        objDAHCE.LevelofEducation = ddlLevelOfEdu.SelectedValue;
        objDAHCE.HB = txtHB.Text;
        objDAHCE.Grp = txtgrp.Text;
        objDAHCE.RBS = txtRBS.Text;
        objDAHCE.RPR = ddlRPR.SelectedValue;
        objDAHCE.HIV1 = ddlHiv1.SelectedValue;
        objDAHCE.HIV2 = ddlHiv2.SelectedValue;
        objDAHCE.HBsAg = ddlHBsAg.SelectedValue;
        objDAHCE.Sickling = ddlSickling.SelectedValue;
        objDAHCE.Glucose = txthrafterGlu.Text;
        objDAHCE.OGTT = txtOGTT.Text;
        objDAHCE.HepC = ddlHepC.SelectedValue;

        objDAHCE.UltraSoundFinding = txtUltraFinding.Text;
        objDAHCE.SubseqUltraSoundFinding = txtSubUltraFinding.Text;
        objDAHCE.ModeOfDelivery = txtModeOfDelivery.Text;
        objDAHCE.BirthWeight = txtbabyweight.Text;
        if (txtLMP.Text != "")
        {
            objDAHCE.LMP_Antinatal_Date = Convert.ToDateTime(txtLMP.Text);
        }
        if (txtinjTT.Text != "")
        {
            objDAHCE.TTINj_Date = Convert.ToDateTime(txtinjTT.Text);
        }
        if (txtdueDate.Text != "")
        {
            objDAHCE.Due_Date = Convert.ToDateTime(txtdueDate.Text);
        }
        if (txtultraDate.Text != "")
        {
            objDAHCE.UltraSound_Date = Convert.ToDateTime(txtultraDate.Text);
        }
        if (txtsubDate.Text != "")
        {
            objDAHCE.SubsequentUltraSound_Date = Convert.ToDateTime(txtsubDate.Text);
        }
        if (txtdeleiveryDate.Text != "")
        {
            objDAHCE.Delivery_Date = Convert.ToDateTime(txtdeleiveryDate.Text);
        }

        objBLLHCE.InsertGynaclogy_Antenatal(objDAHCE);

        for (int i = 0; i < GVClinicalDetails.Rows.Count; i++)
        {

            //extract the TextBox values

            TextBox box1 = (TextBox)GVClinicalDetails.Rows[i].Cells[1].FindControl("txtClinDate");
            TextBox box2 = (TextBox)GVClinicalDetails.Rows[i].Cells[2].FindControl("txtClinDetails");

            if (box1.Text != "")
            {
                objDAHCE.Clinical_Date = Convert.ToDateTime(box1.Text);
                objDAHCE.ClinicalDetails = box2.Text;
                objBLLHCE.InsertGynaclogy_Antenatal_ClinicalDetails(objDAHCE);
            }
        }
        for (int i = 0; i < GVFOL_LICULAR.Rows.Count; i++)
        {

            //extract the TextBox values

            TextBox box1 = (TextBox)GVFOL_LICULAR.Rows[i].Cells[1].FindControl("txtInvDate");
            TextBox box2 = (TextBox)GVFOL_LICULAR.Rows[i].Cells[2].FindControl("txtInVDetails");

            if (box1.Text != "")
            {
                objDAHCE.Investigation_Date = Convert.ToDateTime(box1.Text);
                objDAHCE.InvestigationDetails = box2.Text;
                objBLLHCE.InsertGynaclogy_Antenatal_InvestigationDetails(objDAHCE);
            }
        }
        for (int i = 0; i < GVOthDetails.Rows.Count; i++)
        {

            //extract the TextBox values

            TextBox box1 = (TextBox)GVOthDetails.Rows[i].Cells[1].FindControl("txtOthDate");
            TextBox box2 = (TextBox)GVOthDetails.Rows[i].Cells[2].FindControl("txtPOG");
            TextBox box3 = (TextBox)GVOthDetails.Rows[i].Cells[3].FindControl("txtSFH");
            TextBox box4 = (TextBox)GVOthDetails.Rows[i].Cells[4].FindControl("txtPPLIE");
            TextBox box5 = (TextBox)GVOthDetails.Rows[i].Cells[5].FindControl("txtFetalHeartBeat");
            TextBox box6 = (TextBox)GVOthDetails.Rows[i].Cells[6].FindControl("txtBP");
            TextBox box7 = (TextBox)GVOthDetails.Rows[i].Cells[7].FindControl("txtUrinChem");
            TextBox box8 = (TextBox)GVOthDetails.Rows[i].Cells[8].FindControl("txtWeightLBS");
            TextBox box9 = (TextBox)GVOthDetails.Rows[i].Cells[9].FindControl("txtInvestigations");
            TextBox box10 = (TextBox)GVOthDetails.Rows[i].Cells[10].FindControl("txtMedications");
            TextBox box11= (TextBox)GVOthDetails.Rows[i].Cells[11].FindControl("txtAdvice");
            

            if (box1.Text != "")
            {
                objDAHCE.Other_Date = Convert.ToDateTime(box1.Text);
                objDAHCE.POG = box2.Text;
                objDAHCE.SFH = box3.Text;
                objDAHCE.PPLIE = box4.Text;
                objDAHCE.FetalHeartBeat = box5.Text;
                objDAHCE.BP = box6.Text;
                objDAHCE.UrinChem = box7.Text;
                objDAHCE.WeightLBS = box8.Text;
                objDAHCE.Investigations = box9.Text;
                objDAHCE.Medications = box10.Text;
                objDAHCE.Advice = box11.Text;
                objBLLHCE.InsertGynaclogy_Antenatal_OtherDetails(objDAHCE);
            }
        }
        LblMSg.Text = "Record Save successfully!";
    }
    public void Clear1()
    {
        //txtnotes .Text = "";
        //txtMedications.Text = "";
       
        //txtsize.Text = "";
        //txtweeks.Text = "";
       
       
    }
   
    protected void gvdChief_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvdChief.PageIndex = e.NewPageIndex;
       // BindHIVEncounter();
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

    protected void btnNeoEntry_Click(object sender, EventArgs e)
    {
        NeoEntry.Visible = true;
        Investigation.Visible = false;
        OthDetails.Visible = false;
        ClincDet.Visible = false;
    }

    protected void btnInvistigation_Click(object sender, EventArgs e)
    {
        Investigation.Visible = true;
        NeoEntry.Visible = false;
        ClincDet.Visible = false;
        OthDetails.Visible = false;
    }
   //========================================= Investigation ================================

   

    protected void btnClinicalDet_Click(object sender, EventArgs e)
    {
        Investigation.Visible = false;
        NeoEntry.Visible = false;
        ClincDet.Visible = true;
        OthDetails.Visible = false;
    }
    protected void btnOtherdet_Click(object sender, EventArgs e)
    {
        Investigation.Visible = false;
        NeoEntry.Visible = false;
        ClincDet.Visible = false;
        OthDetails.Visible = true;
    }
    protected void btnreport_Click(object sender, EventArgs e)
    {
        string sql = "";
        Alter_view();
        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Report/Rpt_ANTENATALCARD_Details.rpt");
        Session["reportname"] = "ANTENATALCARD";
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

        string query = "ALTER VIEW [dbo].[VW_Gynalogy_ANTENATALCARD] AS (SELECT        PatientInformation.MiddleName, PatientInformation.LastName, Gender.GenderName, PatientInformation.MobileNo, PatientInformation.PhoneNo, PatientInformation.PatientAddress, PatientInformation.Email, "+
                     "   PatientInformation.Age, PatientInformation.AgeType, PatientInformation.FirstName, Gynalogy_ANTENATALCARD.AntiId, Gynalogy_ANTENATALCARD.Patregid, Gynalogy_ANTENATALCARD.OPDNo, "+
                     "   Gynalogy_ANTENATALCARD.IPDNo, Gynalogy_ANTENATALCARD.Gravida, Gynalogy_ANTENATALCARD.Para, Gynalogy_ANTENATALCARD.RiskFactors, Gynalogy_ANTENATALCARD.Allergies,  "+
                     "   Gynalogy_ANTENATALCARD.Ethinicity, Gynalogy_ANTENATALCARD.SignificantFamilyHistory, Gynalogy_ANTENATALCARD.LevelofEducation, Gynalogy_ANTENATALCARD.HB, Gynalogy_ANTENATALCARD.Grp, "+
                     "   Gynalogy_ANTENATALCARD.RBS, Gynalogy_ANTENATALCARD.RPR, Gynalogy_ANTENATALCARD.HIV1, Gynalogy_ANTENATALCARD.HIV2, Gynalogy_ANTENATALCARD.HBsAg, Gynalogy_ANTENATALCARD.Sickling, "+
                     "   Gynalogy_ANTENATALCARD.OGTT, Gynalogy_ANTENATALCARD.HepC, Gynalogy_ANTENATALCARD.Glucose, Gynalogy_ANTENATALCARD.UltraSoundFinding, Gynalogy_ANTENATALCARD.SubseqUltraSoundFinding, "+
                     "   Gynalogy_ANTENATALCARD.ModeOfDelivery, Gynalogy_ANTENATALCARD.BirthWeight, Gynalogy_ANTENATALCARD.Note, Gynalogy_ANTENATALCARD.LMP_Antinatal_Date, Gynalogy_ANTENATALCARD.TTINj_Date, "+
                     "   Gynalogy_ANTENATALCARD.Due_Date, Gynalogy_ANTENATALCARD.UltraSound_Date, Gynalogy_ANTENATALCARD.SubsequentUltraSound_Date, Gynalogy_ANTENATALCARD.Delivery_Date, "+
                     "   Gynalogy_ANTENATALCARD.CreatedBy, Gynalogy_ANTENATALCARD.CreatedOn, Gynalogy_ANTENATALCARD.Branchid, Gynalogy_ANTENATALCARD_ClinicalDetails.Clinical_Date, "+
                     "   Gynalogy_ANTENATALCARD_ClinicalDetails.ClinicalDetails, Gynalogy_ANTENATALCARD_InvestigationDetails.Investigation_Date, Gynalogy_ANTENATALCARD_InvestigationDetails.InvestigationDetails, "+
                     "   Gynalogy_ANTENATALCARD_OtherDetails.Other_Date, Gynalogy_ANTENATALCARD_OtherDetails.POG, Gynalogy_ANTENATALCARD_OtherDetails.SFH, Gynalogy_ANTENATALCARD_OtherDetails.PPLIE, "+
                     "   Gynalogy_ANTENATALCARD_OtherDetails.FetalHeartBeat, Gynalogy_ANTENATALCARD_OtherDetails.BP, Gynalogy_ANTENATALCARD_OtherDetails.UrinChem, Gynalogy_ANTENATALCARD_OtherDetails.WeightLBS, "+
                     "   Gynalogy_ANTENATALCARD_OtherDetails.Investigations, Gynalogy_ANTENATALCARD_OtherDetails.Medications, Gynalogy_ANTENATALCARD_OtherDetails.Advice "+
                     "   FROM   PatientInformation INNER JOIN "+
                     "   Gender ON PatientInformation.GenderId = Gender.GenderId INNER JOIN "+
                     "   Gynalogy_ANTENATALCARD ON PatientInformation.PatRegId = Gynalogy_ANTENATALCARD.Patregid LEFT OUTER JOIN "+
                     "   Gynalogy_ANTENATALCARD_OtherDetails ON Gynalogy_ANTENATALCARD.Patregid = Gynalogy_ANTENATALCARD_OtherDetails.Patregid AND "+
                     "   Gynalogy_ANTENATALCARD.OPDNo = Gynalogy_ANTENATALCARD_OtherDetails.OPDNo AND Gynalogy_ANTENATALCARD.IPDNo = Gynalogy_ANTENATALCARD_OtherDetails.IPDNo AND "+
                     "   Gynalogy_ANTENATALCARD.AntiId = Gynalogy_ANTENATALCARD_OtherDetails.ANTENATALCARDID LEFT OUTER JOIN "+
                     "   Gynalogy_ANTENATALCARD_InvestigationDetails ON Gynalogy_ANTENATALCARD.AntiId = Gynalogy_ANTENATALCARD_InvestigationDetails.ANTENATALCARDID AND "+
                     "   Gynalogy_ANTENATALCARD.OPDNo = Gynalogy_ANTENATALCARD_InvestigationDetails.OPDNo AND Gynalogy_ANTENATALCARD.IPDNo = Gynalogy_ANTENATALCARD_InvestigationDetails.IPDNo AND "+
                     "   Gynalogy_ANTENATALCARD.Patregid = Gynalogy_ANTENATALCARD_InvestigationDetails.Patregid LEFT OUTER JOIN "+
                     "   Gynalogy_ANTENATALCARD_ClinicalDetails ON Gynalogy_ANTENATALCARD.AntiId = Gynalogy_ANTENATALCARD_ClinicalDetails.ANTENATALCARDID AND "+
                     "   Gynalogy_ANTENATALCARD.Patregid = Gynalogy_ANTENATALCARD_ClinicalDetails.Patregid AND Gynalogy_ANTENATALCARD.OPDNo = Gynalogy_ANTENATALCARD_ClinicalDetails.OPDNo AND "+
                     "   Gynalogy_ANTENATALCARD.IPDNo = Gynalogy_ANTENATALCARD_ClinicalDetails.IPDNo " +
        " where Gynalogy_ANTENATALCARD.Patregid=" + Convert.ToInt32(Session["EmrRegNo"]) + "  and  Gynalogy_ANTENATALCARD.OPDNo=" + Convert.ToInt32(Session["EmrOpdNo"]) + " and  Gynalogy_ANTENATALCARD.IPDNO=" + Convert.ToInt32(Session["EmrIpdNo"]) + " ";
        //if (txtFrom.Value != "" && txtTo.Value != "")
        //{
        //    query += " and    DagnosisAssigtTpPatient.CreatedOn between ('" + Convert.ToDateTime(txtFrom.Value).ToString("MM/dd/yyyy") + "') and ('" + Convert.ToDateTime(txtTo.Value).AddDays(1).ToString("MM/dd/yyyy") + "')";
        //}



        cmd1.CommandText = query + ")";

        con.Open();
        cmd1.ExecuteNonQuery();
        con.Close(); con.Dispose();
    }
    public void BindTemplate()
    {

        dt = new DataTable();
        dt = objBLLHCET.Get_Template(Convert.ToInt32(Session["Branchid"]));
        if (dt.Rows.Count > 0)
        {
            Chkmaintestshort.DataSource = dt;
            Chkmaintestshort.DataTextField = "TemplateName";
            Chkmaintestshort.DataValueField = "TempId";
            Chkmaintestshort.DataBind();

        }
        else
        {

        }
    }
   
  

    private void SetInitialRow()
    {

        DataTable dt = new DataTable();

        DataRow dr = null;

        dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));

        dt.Columns.Add(new DataColumn("Inv_Date", typeof(string)));

        dt.Columns.Add(new DataColumn("Details", typeof(string)));

       

        dr = dt.NewRow();

        dr["RowNumber"] = 1;

        dr["Inv_Date"] = string.Empty;

        dr["Details"] = string.Empty;

      

        dt.Rows.Add(dr);

        //dr = dt.NewRow();



        //Store the DataTable in ViewState

        ViewState["CurrentTable"] = dt;



        GVFOL_LICULAR.DataSource = dt;

        GVFOL_LICULAR.DataBind();

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

                    TextBox box1 = (TextBox)GVFOL_LICULAR.Rows[rowIndex].Cells[1].FindControl("txtInvDate");

                    TextBox box2 = (TextBox)GVFOL_LICULAR.Rows[rowIndex].Cells[2].FindControl("txtInVDetails");

                  

                    drCurrentRow = dtCurrentTable.NewRow();

                    drCurrentRow["RowNumber"] = i + 1;



                    dtCurrentTable.Rows[i - 1]["Inv_Date"] = box1.Text;

                    dtCurrentTable.Rows[i - 1]["Details"] = box2.Text;

                  
                    rowIndex++;

                }

                dtCurrentTable.Rows.Add(drCurrentRow);

                ViewState["CurrentTable"] = dtCurrentTable;



                GVFOL_LICULAR.DataSource = dtCurrentTable;
                GVFOL_LICULAR.DataBind();

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

                    TextBox box1 = (TextBox)GVFOL_LICULAR.Rows[rowIndex].Cells[1].FindControl("txtInvDate");
                    TextBox box2 = (TextBox)GVFOL_LICULAR.Rows[rowIndex].Cells[2].FindControl("txtInVDetails");

                    box1.Text = dt.Rows[i]["Inv_Date"].ToString();

                    box2.Text = dt.Rows[i]["Details"].ToString();

                    
                    rowIndex++;

                }

            }

        }

    }
    protected void ButtonAdd_Click(object sender, EventArgs e)
    {

        AddNewRowToGrid();

    }

    private void SetInitialRow_Clinical()
    {

        DataTable dtClin = new DataTable();

        DataRow dr = null;

        dtClin.Columns.Add(new DataColumn("RowNumber", typeof(string)));

        dtClin.Columns.Add(new DataColumn("ClinDate", typeof(string)));

        dtClin.Columns.Add(new DataColumn("ClinDetails", typeof(string)));



        dr = dtClin.NewRow();

        dr["RowNumber"] = 1;

        dr["ClinDate"] = string.Empty;

        dr["ClinDetails"] = string.Empty;



        dtClin.Rows.Add(dr);

        //dr = dt.NewRow();



        //Store the DataTable in ViewState

        ViewState["CurrentTableClin"] = dtClin;



        GVClinicalDetails.DataSource = dtClin;

        GVClinicalDetails.DataBind();

    }

    private void AddNewRowToGrid_Clinical()
    {

        int rowIndex = 0;



        if (ViewState["CurrentTableClin"] != null)
        {

            DataTable dtCurrentTableClin = (DataTable)ViewState["CurrentTableClin"];

            DataRow drCurrentRow = null;

            if (dtCurrentTableClin.Rows.Count > 0)
            {

                for (int i = 1; i <= dtCurrentTableClin.Rows.Count; i++)
                {

                    //extract the TextBox values

                    TextBox box1 = (TextBox)GVClinicalDetails.Rows[rowIndex].Cells[1].FindControl("txtClinDate");

                    TextBox box2 = (TextBox)GVClinicalDetails.Rows[rowIndex].Cells[2].FindControl("txtClinDetails");



                    drCurrentRow = dtCurrentTableClin.NewRow();

                    drCurrentRow["RowNumber"] = i + 1;



                    dtCurrentTableClin.Rows[i - 1]["ClinDate"] = box1.Text;

                    dtCurrentTableClin.Rows[i - 1]["ClinDetails"] = box2.Text;


                    rowIndex++;

                }

                dtCurrentTableClin.Rows.Add(drCurrentRow);

                ViewState["CurrentTableClin"] = dtCurrentTableClin;



                GVClinicalDetails.DataSource = dtCurrentTableClin;
                GVClinicalDetails.DataBind();

            }

        }

        else
        {

            Response.Write("ViewState is null");

        }



        //Set Previous Data on Postbacks

        SetPreviousData_Clinical();

    }

    private void SetPreviousData_Clinical()
    {

        int rowIndex = 0;

        if (ViewState["CurrentTableClin"] != null)
        {

            DataTable dtclin = (DataTable)ViewState["CurrentTableClin"];

            if (dtclin.Rows.Count > 0)
            {

                for (int i = 0; i < dtclin.Rows.Count; i++)
                {

                    TextBox box1 = (TextBox)GVClinicalDetails.Rows[rowIndex].Cells[1].FindControl("txtClinDate");
                    TextBox box2 = (TextBox)GVClinicalDetails.Rows[rowIndex].Cells[2].FindControl("txtClinDetails");

                    box1.Text = dtclin.Rows[i]["ClinDate"].ToString();

                    box2.Text = dtclin.Rows[i]["ClinDetails"].ToString();


                    rowIndex++;

                }

            }

        }

    }
    protected void ButtonAddC_Click(object sender, EventArgs e)
    {

        AddNewRowToGrid_Clinical();

    }

    //=======================Other Details ---------------------------\\

    private void SetInitialRow_Othdet()
    {

        DataTable Othdet = new DataTable();

        DataRow dr = null;

        Othdet.Columns.Add(new DataColumn("RowNumber", typeof(string)));

        Othdet.Columns.Add(new DataColumn("OthDate", typeof(string)));
        Othdet.Columns.Add(new DataColumn("POG", typeof(string)));
        Othdet.Columns.Add(new DataColumn("SFH", typeof(string)));
        Othdet.Columns.Add(new DataColumn("PPLIE", typeof(string)));
        Othdet.Columns.Add(new DataColumn("FetalHeartBeat", typeof(string)));
        Othdet.Columns.Add(new DataColumn("BP", typeof(string)));
        Othdet.Columns.Add(new DataColumn("UrinChem", typeof(string)));
        Othdet.Columns.Add(new DataColumn("WeightLBS", typeof(string)));

        Othdet.Columns.Add(new DataColumn("Investigations", typeof(string)));
        Othdet.Columns.Add(new DataColumn("Medications", typeof(string)));
        Othdet.Columns.Add(new DataColumn("Advice", typeof(string)));


        dr = Othdet.NewRow();

        dr["RowNumber"] = 1;

        dr["OthDate"] = string.Empty;

        dr["POG"] = string.Empty;
        dr["SFH"] = string.Empty;
        dr["PPLIE"] = string.Empty;
        dr["FetalHeartBeat"] = string.Empty;
        dr["BP"] = string.Empty;
        dr["UrinChem"] = string.Empty;
        dr["WeightLBS"] = string.Empty;
        dr["Investigations"] = string.Empty;
        dr["Medications"] = string.Empty;
        dr["Advice"] = string.Empty;


        Othdet.Rows.Add(dr);
        //dr = dt.NewRow();
        //Store the DataTable in ViewState
        ViewState["CurrentTableOthdet"] = Othdet;

        GVOthDetails.DataSource = Othdet;
        GVOthDetails.DataBind();

    }

    private void AddNewRowToGrid_OthDet()
    {

        int rowIndex = 0;



        if (ViewState["CurrentTableOthdet"] != null)
        {

            DataTable dtCurrentTableoth = (DataTable)ViewState["CurrentTableOthdet"];

            DataRow drCurrentRow = null;

            if (dtCurrentTableoth.Rows.Count > 0)
            {

                for (int i = 1; i <= dtCurrentTableoth.Rows.Count; i++)
                {

                    //extract the TextBox values

                    TextBox box1 = (TextBox)GVOthDetails.Rows[rowIndex].Cells[1].FindControl("txtOthDate");
                    TextBox box2 = (TextBox)GVOthDetails.Rows[rowIndex].Cells[2].FindControl("txtPOG");
                    TextBox box3 = (TextBox)GVOthDetails.Rows[rowIndex].Cells[3].FindControl("txtSFH");
                    TextBox box4 = (TextBox)GVOthDetails.Rows[rowIndex].Cells[4].FindControl("txtPPLIE");

                    TextBox box5 = (TextBox)GVOthDetails.Rows[rowIndex].Cells[5].FindControl("txtFetalHeartBeat");
                    TextBox box6 = (TextBox)GVOthDetails.Rows[rowIndex].Cells[6].FindControl("txtBP");
                    TextBox box7 = (TextBox)GVOthDetails.Rows[rowIndex].Cells[7].FindControl("txtUrinChem");
                    TextBox box8 = (TextBox)GVOthDetails.Rows[rowIndex].Cells[8].FindControl("txtWeightLBS");

                    TextBox box9 = (TextBox)GVOthDetails.Rows[rowIndex].Cells[9].FindControl("txtInvestigations");
                    TextBox box10 = (TextBox)GVOthDetails.Rows[rowIndex].Cells[10].FindControl("txtMedications");
                    TextBox box11 = (TextBox)GVOthDetails.Rows[rowIndex].Cells[11].FindControl("txtAdvice");
                   


                    drCurrentRow = dtCurrentTableoth.NewRow();

                    drCurrentRow["RowNumber"] = i + 1;



                    dtCurrentTableoth.Rows[i - 1]["OthDate"] = box1.Text;
                    dtCurrentTableoth.Rows[i - 1]["POG"] = box2.Text;
                    dtCurrentTableoth.Rows[i - 1]["SFH"] = box3.Text;
                    dtCurrentTableoth.Rows[i - 1]["PPLIE"] = box4.Text;

                    dtCurrentTableoth.Rows[i - 1]["FetalHeartBeat"] = box5.Text;
                    dtCurrentTableoth.Rows[i - 1]["BP"] = box6.Text;
                    dtCurrentTableoth.Rows[i - 1]["UrinChem"] = box7.Text;
                    dtCurrentTableoth.Rows[i - 1]["WeightLBS"] = box8.Text;

                    dtCurrentTableoth.Rows[i - 1]["Investigations"] = box9.Text;
                    dtCurrentTableoth.Rows[i - 1]["Medications"] = box10.Text;
                    dtCurrentTableoth.Rows[i - 1]["Advice"] = box11.Text;
                    rowIndex++;
                }

                dtCurrentTableoth.Rows.Add(drCurrentRow);
                ViewState["CurrentTableOthdet"] = dtCurrentTableoth;

                GVOthDetails.DataSource = dtCurrentTableoth;
                GVOthDetails.DataBind();

            }
        }

        else
        {
            Response.Write("ViewState is null");
        }
        
        //Set Previous Data on Postbacks

        SetPreviousData_OthDet();

    }

    private void SetPreviousData_OthDet()
    {

        int rowIndex = 0;

        if (ViewState["CurrentTableOthdet"] != null)
        {

            DataTable dtotDet = (DataTable)ViewState["CurrentTableOthdet"];

            if (dtotDet.Rows.Count > 0)
            {

                for (int i = 0; i < dtotDet.Rows.Count; i++)
                {

                    TextBox box1 = (TextBox)GVOthDetails.Rows[rowIndex].Cells[1].FindControl("txtOthDate");
                    TextBox box2 = (TextBox)GVOthDetails.Rows[rowIndex].Cells[2].FindControl("txtPOG");
                    TextBox box3 = (TextBox)GVOthDetails.Rows[rowIndex].Cells[3].FindControl("txtSFH");
                    TextBox box4 = (TextBox)GVOthDetails.Rows[rowIndex].Cells[4].FindControl("txtPPLIE");

                    TextBox box5 = (TextBox)GVOthDetails.Rows[rowIndex].Cells[5].FindControl("txtFetalHeartBeat");
                    TextBox box6 = (TextBox)GVOthDetails.Rows[rowIndex].Cells[6].FindControl("txtBP");
                    TextBox box7 = (TextBox)GVOthDetails.Rows[rowIndex].Cells[7].FindControl("txtUrinChem");
                    TextBox box8 = (TextBox)GVOthDetails.Rows[rowIndex].Cells[8].FindControl("txtWeightLBS");

                    TextBox box9 = (TextBox)GVOthDetails.Rows[rowIndex].Cells[9].FindControl("txtInvestigations");
                    TextBox box10 = (TextBox)GVOthDetails.Rows[rowIndex].Cells[10].FindControl("txtMedications");
                    TextBox box11 = (TextBox)GVOthDetails.Rows[rowIndex].Cells[11].FindControl("txtAdvice");

                    box1.Text = dtotDet.Rows[i]["OthDate"].ToString();
                    box2.Text = dtotDet.Rows[i]["POG"].ToString();
                    box3.Text = dtotDet.Rows[i]["SFH"].ToString();
                    box4.Text = dtotDet.Rows[i]["PPLIE"].ToString();

                    box5.Text = dtotDet.Rows[i]["FetalHeartBeat"].ToString();
                    box6.Text = dtotDet.Rows[i]["BP"].ToString();
                    box7.Text = dtotDet.Rows[i]["UrinChem"].ToString();
                    box8.Text = dtotDet.Rows[i]["WeightLBS"].ToString();

                    box9.Text = dtotDet.Rows[i]["Investigations"].ToString();
                    box10.Text = dtotDet.Rows[i]["Medications"].ToString();
                    box11.Text = dtotDet.Rows[i]["Advice"].ToString();
                  


                    rowIndex++;

                }

            }

        }

    }
    protected void ButtonAddoth_Click(object sender, EventArgs e)
    {

        AddNewRowToGrid_OthDet();

    }

    protected void btnAddTemplate_Click(object sender, EventArgs e)
    {
        LoadSlideBar("", "");
    }

   
    protected void Chkmaintestshort_SelectedIndexChanged(object sender, EventArgs e)
    {
        string TempName = "";
        int TempVal = 0;
        for (int i = 0; i < Chkmaintestshort.Items.Count; i++)
        {
            if (Chkmaintestshort.Items[i].Selected)
            {

                TempName = Chkmaintestshort.Items[i].Text;
                TempVal = Convert.ToInt32(Chkmaintestshort.Items[i].Value);
                // BindShortTest();
                objBLLHCET.Insert_CaseSheetTOTemplate(Convert.ToInt32(Session["EmrRegNo"]), Convert.ToInt32(Session["EmrOpdNo"]), Convert.ToInt32(Session["EmrIpdNo"]), TempVal, TempName, Convert.ToString(Session["username"]));
            }

        }
        LoadSlideBar("", "");
        // BindShortcut_test();

    }


    private void LoadSlideBar(string UserNm, string MainModule)
    {
        string SlideBarHtml = "";


        // UsernameLB.Text = UserNm;
        //UsernameLB2.Text = UserNm;
        DataTable MenuDt = new DataTable();

        // string MenuSQL = String.Format(@"SELECT Distinct MenuID,MenuName,icon from [dbo].[SlidBarVeiw] WHERE  username = '{0}' ORDER BY MenuID", UserNm);
        // string MenuSQL = String.Format(@"SELECT Distinct MenuID,MenuName,icon from [dbo].[TBL_MenuMaster] where Isactive=1 ORDER BY MenuID", UserNm); //  WHERE  username = '{0}' SlidBarVeiw
        string MenuSQL = "";

        MenuSQL = String.Format(@"select distinct CaseId ,CaseName ,Patregid,OPDNo,IPDNO ,icon from CaseGeneration     " +
                     "  WHERE     (Patregid = '" + Convert.ToString(Session["EmrRegNo"]) + "') AND (OPDNo= '" + Convert.ToString(Session["EmrOpdNo"]) + "') " +
                     "  order by opdno   ");

        string connectionString = ConfigurationManager.ConnectionStrings["DBHospital"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);

        SqlCommand cmd = new SqlCommand(MenuSQL, con);

        SqlDataAdapter Adp = new SqlDataAdapter(cmd);

        Adp.Fill(MenuDt);

        foreach (DataRow MainDr in MenuDt.Rows)
        {
            DataTable SubMenuDt = new DataTable();
            string MainMenuName = MainDr["CaseName"].ToString();
            string Menuid = MainDr["Patregid"].ToString();
            string icon = MainDr["icon"].ToString();
            string CaseId = MainDr["CaseId"].ToString();
            SlideBarHtml += "<li>";
            SlideBarHtml += "<a href=" + (char)34 + "javascript:;" + (char)34 + ">";
            SlideBarHtml += "<strong class=" + (char)34 + "nav-label text-danger" + (char)34 + ">" + MainMenuName + "</strong></a>";
            //  SlideBarHtml += "<ul aria-expanded=" + (char)34 + "true"+""+ "  class=" + (char)34 + "nav-2-level collapse" + (char)34 + ">";

            // string SubMenuSQL = String.Format(@"SELECT Distinct SubMenuName,SubMenuNavigateURL,SubMenuID from [dbo].[SlidBarVeiw] WHERE  username = '{0}' and MenuName = '{1}' ORDER BY SubMenuID", UserNm, MainMenuName);
            //string SubMenuSQL = String.Format(@"SELECT Distinct SubMenuName,SubMenuNavigateURL,SubMenuID from TBL_SubMenuMaster INNER JOIN TBL_MenuMaster ON TBL_SubMenuMaster.MenuID = TBL_MenuMaster.MenuID WHERE   MenuName = '{1}' ORDER BY SubMenuID", UserNm, MainMenuName);//username = '{0}' and
            string SubMenuSQL = "";
            //if (USERNAME == "Admin" || USERNAME == "admin")

            SubMenuSQL = String.Format(@"SELECT        CaseAssignToTemplate.Id, CaseAssignToTemplate.Patregid, CaseAssignToTemplate.OPDNo, CaseAssignToTemplate.IPDNo, CaseAssignToTemplate.CaseID, CaseAssignToTemplate.TempID, " +
                              "  CaseAssignToTemplate.TempName, CaseAssignToTemplate.TempDescription, CaseAssignToTemplate.CreatedBy, CaseAssignToTemplate.CreatedOn , TemplateMaster.TempDesc" +
                              "  FROM   CaseAssignToTemplate INNER JOIN TemplateMaster ON CaseAssignToTemplate.TempID = TemplateMaster.TempId     " +
                            "   WHERE   caseid='" + Convert.ToString(CaseId) + "' and (CaseAssignToTemplate.Patregid = '" + Convert.ToString(Session["EmrRegNo"]) + "') AND (CaseAssignToTemplate.OPDNo= '" + Convert.ToString(Session["EmrOpdNo"]) + "') ", con);


            SqlCommand cmd2 = new SqlCommand(SubMenuSQL, con);
            SqlDataAdapter Adp2 = new SqlDataAdapter(cmd2);
            Adp2.Fill(SubMenuDt);
            //SubMenuPart--------------------------------------------->
            foreach (DataRow SubMainDr in SubMenuDt.Rows)
            {
                string SubMenuName = SubMainDr["TempName"].ToString();
                string SubMenuUrl = SubMainDr["TempDesc"].ToString();
                // string ModuelName = SubMainDr["ModuelName"].ToString();
                SlideBarHtml += "<li>";
                //if (Convert.ToString(SubMainDr["ModuelName"]) == "HMS")
                //{
                SlideBarHtml += "<a  class=" + (char)34 + "nav-label text-success ms-2 fw-bold" + (char)34 + " href=" + (char)34 + SubMenuUrl + (char)34 + ">" + SubMenuName.ToString() + "</a>";
                // SlideBarHtml += "<strong class=" + (char)34 + "nav-label text-success" + (char)34 + ">" + SubMenuName.ToString() + "</strong></a>";
                //}
                //else
                //{
                //    SlideBarHtml += "<a href=" + (char)34 + ModuelName + '/' + SubMenuUrl + (char)34 + ">" + SubMenuName.ToString() + "</a>";
                //}
                SlideBarHtml += "</li>";
            }
            //SubMenuPart----------------------------------------------

            // SlideBarHtml += "</ul>";
            SlideBarHtml += "</li>";

        }


        SlidBarHolder.Controls.Clear();
        SlidBarHolder.Controls.Add(new Literal { Text = SlideBarHtml });
        con.Close();
        con.Dispose();
    }
    protected void btnCaseSheet_Click(object sender, EventArgs e)
    {
        objBLLHCET.Insert_CaseSheet(Convert.ToInt32(Session["EmrRegNo"]), Convert.ToInt32(Session["EmrOpdNo"]), Convert.ToInt32(Session["EmrIpdNo"]), Convert.ToString(Session["username"]));

        LoadSlideBar("", "");
    }
    protected void btnCaseSheetDel_Click(object sender, EventArgs e)
    {
        LoadSlideBar("", "");
    }

    protected void btnAddT_Click(object sender, EventArgs e)
    {
        LoadSlideBar("", "");
    }
    protected void btnDelTemplate_Click(object sender, EventArgs e)
    {

        LoadSlideBar("", "");
    }

    protected void ChkDelTemplate_SelectedIndexChanged(object sender, EventArgs e)
    {
        string TempName = "";
        int TempVal = 0;
        for (int i = 0; i < ChkDelTemplate.Items.Count; i++)
        {
            if (ChkDelTemplate.Items[i].Selected)
            {

                TempName = ChkDelTemplate.Items[i].Text;
                TempVal = Convert.ToInt32(ChkDelTemplate.Items[i].Value);
                // BindShortTest();
                objBLLHCET.Delete_Template(Convert.ToInt32(Session["EmrRegNo"]), Convert.ToInt32(Session["EmrOpdNo"]), Convert.ToInt32(Session["EmrIpdNo"]), TempVal);
            }

        }
        LoadSlideBar("", "");
        // BindShortcut_test();

    }

    protected void btnDelT_Click(object sender, EventArgs e)
    {
        string TempName = "";
        int TempVal = 0;
        for (int i = 0; i < ChkDelTemplate.Items.Count; i++)
        {
            if (ChkDelTemplate.Items[i].Selected)
            {

                TempName = ChkDelTemplate.Items[i].Text;
                TempVal = Convert.ToInt32(ChkDelTemplate.Items[i].Value);
                // BindShortTest();
                // objBLLHCE.Delete_Template(Convert.ToInt32(Session["EmrRegNo"]), Convert.ToInt32(Session["EmrOpdNo"]), Convert.ToInt32(Session["EmrIpdNo"]), TempVal);
            }

        }
        LoadSlideBar("", "");
    }

    public void DeleteTemplate()
    {
        dt = new DataTable();
        dt = objBLLHCET.Get_AssignTemplate(Convert.ToInt32(Session["Branchid"]), Convert.ToInt32(Session["EmrRegNo"]), Convert.ToInt32(Session["EmrOpdNo"]), Convert.ToInt32(Session["EmrIpdNo"]));
        if (dt.Rows.Count > 0)
        {
            ChkDelTemplate.DataSource = dt;
            ChkDelTemplate.DataTextField = "TemplateName";
            ChkDelTemplate.DataValueField = "TempId";
            ChkDelTemplate.DataBind();

        }
        else
        {

        }
    }

    public void DeleteCaseSheet()
    {
        dt = new DataTable();
        dt = objBLLHCET.Get_CaseSheet(Convert.ToInt32(Session["Branchid"]), Convert.ToInt32(Session["EmrRegNo"]), Convert.ToInt32(Session["EmrOpdNo"]), Convert.ToInt32(Session["EmrIpdNo"]));
        if (dt.Rows.Count > 0)
        {
            ChkCaseSheet.DataSource = dt;
            ChkCaseSheet.DataTextField = "CaseName";
            ChkCaseSheet.DataValueField = "CaseId";
            ChkCaseSheet.DataBind();

        }
        else
        {

        }
    }
    protected void ChkCaseSheet_SelectedIndexChanged(object sender, EventArgs e)
    {
        string TempName = "";
        int TempVal = 0;
        for (int i = 0; i < ChkCaseSheet.Items.Count; i++)
        {
            if (ChkCaseSheet.Items[i].Selected)
            {

                TempName = ChkCaseSheet.Items[i].Text;
                TempVal = Convert.ToInt32(ChkCaseSheet.Items[i].Value);
                // BindShortTest();
                objBLLHCET.Delete_CaseSheet(Convert.ToInt32(Session["EmrRegNo"]), Convert.ToInt32(Session["EmrOpdNo"]), Convert.ToInt32(Session["EmrIpdNo"]), TempVal);
            }

        }
        LoadSlideBar("", "");
        // BindShortcut_test();

    }
}