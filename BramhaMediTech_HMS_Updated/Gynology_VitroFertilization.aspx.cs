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

public partial class Gynology_VitroFertilization: BasePage
{
    clsEmr obj = new clsEmr();
    clsTreatment objTreat = new clsTreatment();
    clsTreatmentTransaction transaction = new clsTreatmentTransaction();
    DataTable tempDatatable = new DataTable();
    BELVitroFertilization objBLLHCE = new BELVitroFertilization();
    DALVitroFertilization objDAHCE = new DALVitroFertilization();
    DataTable dt = new DataTable();
    BELGeneralGynology objBLLHCET1 = new BELGeneralGynology();
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
                Session["Branchid"] = "1";
               // lblOpd.Text = opd;
                BindSurgicalAdvice();
                BindHIVEncounter();
                BindTemplate();
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

        objDAHCE.LMPDate =Convert.ToDateTime( txtLMP.Text);
        objDAHCE.RPR = Convert.ToString(ddlRPR.SelectedItem.Text);
        objDAHCE.YearOfInfert = Convert.ToString(txtYearofInfer.Text);
        objDAHCE.YearOfInfert1 = Convert.ToString(ddlYearOfInfe.SelectedItem.Text);
        objDAHCE.HIV = Convert.ToString(ddlHiv.SelectedItem.Text);
        objDAHCE.HepB = Convert.ToString(ddlHepB.SelectedItem.Text);

        objDAHCE.HepC = Convert.ToString(txthepc.Text);
        objDAHCE.AFC = Convert.ToString(txtAfc.Text);
        objDAHCE.RBS = Convert.ToString(txtRBS.Text);
        objDAHCE.BloodGrouping = Convert.ToString(txtbloodgrooping.Text);
        objDAHCE.PartnerName = Convert.ToString(txtpartnerName.Text);
        objDAHCE.PartnerAge = Convert.ToString(txtage.Text);

        objDAHCE.ParHIV = Convert.ToString(ddlPartnerHiv.SelectedItem.Text);
        objDAHCE.ParHepB = Convert.ToString(ddlPartnerHepb.SelectedItem.Text);
        objDAHCE.RarHepC = Convert.ToString(ddlPartnerHepc.SelectedItem.Text);

        objDAHCE.FSH = Convert.ToString(txtFSH.Text);
        objDAHCE.AMH = Convert.ToString(txtAMH.Text);
        objDAHCE.LH = Convert.ToString(txtLH.Text);
        objDAHCE.Prolact = Convert.ToString(txtProlact.Text);
        objDAHCE.TSH = Convert.ToString(txtTSH.Text);
        objDAHCE.T3 = Convert.ToString(txtT3.Text);
        objDAHCE.T4 = Convert.ToString(txtt4.Text);
        objDAHCE.P4 = Convert.ToString(txtP4.Text);
        objDAHCE.CMV = Convert.ToString(ddlCMV.SelectedItem.Text);


       objDAHCE.AntrialFollicleNote = Convert.ToString(txtAntrialFollicleCount.Text);
       objDAHCE.TrialTransfer = Convert.ToString(ddlTrialTransfer.SelectedItem.Text);
       objDAHCE.TrialTransferDetalis = Convert.ToString(txtTrialTransfer.Text);
       objDAHCE.Endometrialscrath = Convert.ToString(ddlEndometrialscrath.SelectedItem.Text);
       objDAHCE.Endometria_Date = Convert.ToDateTime(txtEndometrialscrath.Text);

       objDAHCE.DHEAS = Convert.ToString(ddlDheas.SelectedItem.Text);
       objDAHCE.LongAgonist = Convert.ToString(ddlLongAgonist.SelectedItem.Text);
       objDAHCE.Antagonist = Convert.ToString(ddlAntagonist.SelectedItem.Text);
       objDAHCE.OCsDate = Convert.ToDateTime(txtocDate.Text);

       objDAHCE.SemenAnalysisNote = Convert.ToString(txtSemenAnalysis.Text);
       objDAHCE.Fibroids = Convert.ToString(ddlFibroids.SelectedItem.Text);
       objDAHCE.Endometriosis = Convert.ToString(ddlEndometrialscrath.SelectedItem.Text);
       objDAHCE.Cycts = Convert.ToString(ddlCycts.SelectedItem.Text);
       objDAHCE.Hydrosalpinx = Convert.ToString(ddlHydrosalpinx.SelectedItem.Text);

       objDAHCE.HysteroscopyFinding = Convert.ToString(txtHysteroscopyFindings.Text);
       objDAHCE.DLap = Convert.ToString(txtDlap.Text);

       objDAHCE.PreviousInfertHist = Convert.ToString(txtPrevInfertilityTreatment.Text);
       objDAHCE.VitroRemarks = Convert.ToString(txtremark.Text);
       objDAHCE.VitroNote = Convert.ToString(txtNotes.Text);






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

        objBLLHCE.InsertVitroFertilization(objDAHCE);
        LblMSg.Text = "Record save successfully.!";
        LblMSg.ForeColor = System.Drawing.Color.Green;
        BindHIVEncounter();
        Clear();
    }
    public void Clear()
    {
        txtAfc.Text = "";
        txtage.Text = "";
        txtAMH.Text = "";
        txtbloodgrooping.Text = "";
        txtE2.Text = "";
        txtFSH.Text = "";
        txthepc.Text = "";
        //txtHysteroscopyFinding.Text = "";
        //txtLaparoscopyFinding.Text = "";
        txtLH.Text = "";
        txtLMP.Text = "";
        txtNotes.Text = "";
        txtP4.Text = "";
        txtpartnerName.Text = "";
        txtProlact.Text = "";
        txtRBS.Text = "";
        txtSemenAnalysis.Text = "";
        txtT3.Text = "";
        txtt4.Text = "";
        txtTSH.Text = "";
       // txtUltraSoundFinding.Text = "";
        txtweeks.Text = "";
        txtYearofInfer.Text = "";
       // txtNotes.Text;
        txtocDate.Text = "";
        txtP4.Text = "";
        
       
       
    }
    private void BindHIVEncounter()
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
        tempDatatable = objBLLHCE.GetVitroFertilization(objDAHCE);
        gvdChief.DataSource = tempDatatable;
        gvdChief.DataBind();
        if (tempDatatable.Rows.Count > 0)
        {
            BtnBirthRegister.ForeColor = System.Drawing.Color.White;
            BtnBirthRegister.BackColor = System.Drawing.Color.Red;
            //btnChief1_light.Visible = true;
        }
    }
    protected void gvdChief_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvdChief.PageIndex = e.NewPageIndex;
        BindHIVEncounter();
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
    protected void btnreport_Click(object sender, EventArgs e)
    {
        string sql = "";
        Alter_view();
        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Report/Rpt_VitroFertilization.rpt");
        Session["reportname"] = "VitroFertilization";
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

        string query = "ALTER VIEW [dbo].[VW_GetVitroFertilization] AS (SELECT        PatientInformation.FirstName, PatientInformation.MiddleName, PatientInformation.LastName, Gender.GenderName, PatientInformation.BirthDate, PatientInformation.BloodGroup, PatientInformation.MaritalStatus, "+
                      "  PatientInformation.PhoneNo, PatientInformation.MobileNo, PatientInformation.PatientAddress, PatientInformation.Email, PatientInformation.Age, PatientInformation.AgeType, VitroFertilization.VitroId, VitroFertilization.Patregid, "+
                      "  VitroFertilization.OPDNo, VitroFertilization.IPDNo, VitroFertilization.LMPDate, VitroFertilization.RPR, VitroFertilization.YearOfInfert, VitroFertilization.YearOfInfert1, VitroFertilization.HIV, VitroFertilization.AFC, "+
                      "  VitroFertilization.RBS, VitroFertilization.HepB, VitroFertilization.HepC, VitroFertilization.BloodGrouping, VitroFertilization.PartnerName, VitroFertilization.PartnerAge, VitroFertilization.ParHIV, VitroFertilization.ParHepB, "+
                      "  VitroFertilization.RarHepC, VitroFertilization.FSH, VitroFertilization.AMH, VitroFertilization.LH, VitroFertilization.Prolact, VitroFertilization.TSH, VitroFertilization.E2, VitroFertilization.T3, VitroFertilization.T4, VitroFertilization.P4, "+
                      "  VitroFertilization.CMV, VitroFertilization.SemenAnalysisNote, VitroFertilization.Fibroids, VitroFertilization.Endometriosis, VitroFertilization.Cycts, VitroFertilization.Hydrosalpinx, VitroFertilization.AntrialFollicleNote, "+
                      "  VitroFertilization.TrialTransfer, VitroFertilization.TrialTransferDetalis, VitroFertilization.Endometrialscrath, VitroFertilization.Endometria_Date, VitroFertilization.HysteroscopyFinding, VitroFertilization.DLap, "+
                      "  VitroFertilization.PreviousInfertHist, VitroFertilization.VitroRemarks, VitroFertilization.DHEAS, VitroFertilization.LongAgonist, VitroFertilization.Antagonist, VitroFertilization.OCsDate, VitroFertilization.VitroNote, "+ 
                      "  VitroFertilization.Branchid, VitroFertilization.Fid, VitroFertilization.CreatedBy, VitroFertilization.CreatedOn, VitroFertilization.UpdatedBy, VitroFertilization.UpdatedOn "+
                      "  FROM            VitroFertilization INNER JOIN "+
                      "  PatientInformation ON VitroFertilization.Patregid = PatientInformation.PatRegId INNER JOIN "+
                      "  Gender ON PatientInformation.GenderId = Gender.GenderId " +
        " where VitroFertilization.Patregid=" + Convert.ToInt32(Session["EmrRegNo"]) + "  and  VitroFertilization.OPDNo=" + Convert.ToInt32(Session["EmrOpdNo"]) + " and  VitroFertilization.IPDNO=" + Convert.ToInt32(Session["EmrIpdNo"]) + " ";
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
        dt = objBLLHCET1.Get_Template(Convert.ToInt32(Session["Branchid"]));
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
                objBLLHCET1.Insert_CaseSheetTOTemplate(Convert.ToInt32(Session["EmrRegNo"]), Convert.ToInt32(Session["EmrOpdNo"]), Convert.ToInt32(Session["EmrIpdNo"]), TempVal, TempName, Convert.ToString(Session["username"]));
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
        objBLLHCET1.Insert_CaseSheet(Convert.ToInt32(Session["EmrRegNo"]), Convert.ToInt32(Session["EmrOpdNo"]), Convert.ToInt32(Session["EmrIpdNo"]), Convert.ToString(Session["username"]));

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
                objBLLHCET1.Delete_Template(Convert.ToInt32(Session["EmrRegNo"]), Convert.ToInt32(Session["EmrOpdNo"]), Convert.ToInt32(Session["EmrIpdNo"]), TempVal);
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
        dt = objBLLHCET1.Get_AssignTemplate(Convert.ToInt32(Session["Branchid"]), Convert.ToInt32(Session["EmrRegNo"]), Convert.ToInt32(Session["EmrOpdNo"]), Convert.ToInt32(Session["EmrIpdNo"]));
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
        dt = objBLLHCET1.Get_CaseSheet(Convert.ToInt32(Session["Branchid"]), Convert.ToInt32(Session["EmrRegNo"]), Convert.ToInt32(Session["EmrOpdNo"]), Convert.ToInt32(Session["EmrIpdNo"]));
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
                objBLLHCET1.Delete_CaseSheet(Convert.ToInt32(Session["EmrRegNo"]), Convert.ToInt32(Session["EmrOpdNo"]), Convert.ToInt32(Session["EmrIpdNo"]), TempVal);
            }

        }
        LoadSlideBar("", "");
        // BindShortcut_test();

    }
}