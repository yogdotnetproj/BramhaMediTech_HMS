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

public partial class GeneralGynology : System.Web.UI.Page
{
    clsEmr obj = new clsEmr();
    clsTreatment objTreat = new clsTreatment();
    clsTreatmentTransaction transaction = new clsTreatmentTransaction();
    DataTable tempDatatable = new DataTable();
    BELGeneralGynology objBLLHCE = new BELGeneralGynology();
    DALGeneralGynology objDAHCE = new DALGeneralGynology();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            // Save Done
            if (Session["EmrRegNo"] != "")
            {
                string regId = Convert.ToString(Session["EmrRegNo"]);
                string name = Request.QueryString["Name"];
                string opd = Convert.ToString(Session["EmrOpdNo"]);
                string entrydate = Request.QueryString["EntryDate"];
                Session["Branchid"] = "1";
               // lblOpd.Text = opd;
                PindPatientInformation();
               // BindHIVEncounter();
                BindTemplate();
                DeleteTemplate();
                DeleteCaseSheet();
                LoadSlideBar("", "");
               
            }
        }
    }
    public void PindPatientInformation()
    {
     
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        //if (txtStart.Text == "")
        //{
        //    txtStart.Focus();
        //    txtStart.BorderColor = System.Drawing.Color.Red;
        //    return;
        //}

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
        objDAHCE.Duration_Days = txtdays.Text;
        objDAHCE.Duration_Week = txtweeks.Text;
        objDAHCE.Duration_Months = txtmonths.Text;
        objDAHCE.Duration_Years = txtYears.Text;
        objDAHCE.Parity = ddlParity.SelectedValue;
        if (txtStart.Text != "")
        {
            objDAHCE.LastLMP = Convert.ToString(txtStart.Text);
        }
        else
        {
            objDAHCE.LastLMP = null;
        }
        objDAHCE.Note = txtnotes.Text;
        objDAHCE.PastHistory = txtPastHistory.Text;

        objBLLHCE.InsertGeneralGynaclogy(objDAHCE);
        AddSurgicalAdvice();
       LblMSg.Text = "Record save successfully.!";
       LblMSg.ForeColor = System.Drawing.Color.Green;
       BindHIVEncounter();
        Clear();
    }
    public void AddSurgicalAdvice()
    {
        string SurgeruName = "";
        int SurgeryId = 0;
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
        for (int i = 0; i <= ChkGeneralExam.Items.Count - 1; i++)
        {
            if (ChkGeneralExam.Items[i].Selected)
            {
                SurgeruName = ChkGeneralExam.Items[i].Text.Trim();
                SurgeryId = Convert.ToInt32(ChkGeneralExam.Items[i].Value);
                objDAHCE.CompliantName = SurgeruName;
                objDAHCE.CompliantId = SurgeryId;

                objBLLHCE.InsertGynology_GeneralComplants(objDAHCE);
            }
        }
    }

    
    public void Clear()
    {
        txtnotes .Text = "";
        txtPastHistory.Text = "";
        txtdays.Text = "";
        txtmonths.Text = "";
        txtYears.Text = "";
        txtStart.Text = "";
       
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
        tempDatatable = objBLLHCE.Get_GeneralGynology(objDAHCE);
        gvdChief.DataSource = tempDatatable;
        gvdChief.DataBind();

        GridView1.DataSource = tempDatatable;
        GridView1.DataBind();
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
        Session["rptname"] = Server.MapPath("~/Report/Rpt_GeneralGynocologyComplants.rpt");
        Session["reportname"] = "GeneralGynologyComplaints";
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

        string query = "ALTER VIEW [dbo].[VW_GetGeneralGynologyComplaints] AS (SELECT        GeneralGynaecology.GeneralID, GeneralGynaecology.Patregid, GeneralGynaecology.OPDNo, GeneralGynaecology.IPDNo, GeneralGynaecology.Duration_Days, GeneralGynaecology.Duration_Week, "+
         "   GeneralGynaecology.Duration_Months, GeneralGynaecology.Duration_Years, GeneralGynaecology.Parity, GeneralGynaecology.LastLMP, GeneralGynaecology.Note, GeneralGynaecology.PastHistory, "+
          "  GeneralGynaecology.Branchid, GeneralGynaecology.Fid, GeneralGynaecology.CreatedBy, GeneralGynaecology.CreatedOn, GeneralGynaecology.UpdatedBy, GeneralGynaecology.UpdatedOn, "+
          "  GenologyGeneralComplants.CompliantName, GenologyGeneralComplants.ComplantId, PatientInformation.MiddleName, PatientInformation.LastName, Gender.GenderName, PatientInformation.MobileNo, "+
          "  PatientInformation.PhoneNo, PatientInformation.PatientAddress, PatientInformation.Email, PatientInformation.Age, PatientInformation.AgeType, PatientInformation.FirstName "+
          "  FROM            GeneralGynaecology INNER JOIN "+
          "  PatientInformation ON GeneralGynaecology.Patregid = PatientInformation.PatRegId INNER JOIN "+
          "  Gender ON PatientInformation.GenderId = Gender.GenderId LEFT OUTER JOIN "+
          "  GenologyGeneralComplants ON GeneralGynaecology.Patregid = GenologyGeneralComplants.Patregid AND GeneralGynaecology.OPDNo = GenologyGeneralComplants.OPDNo AND "+
          "  GeneralGynaecology.IPDNo = GenologyGeneralComplants.IPDNo " +
        " where GeneralGynaecology.Patregid=" + Convert.ToInt32(Session["EmrRegNo"]) + "  and  GeneralGynaecology.OPDNo=" + Convert.ToInt32(Session["EmrOpdNo"]) + " and  GeneralGynaecology.IPDNO=" + Convert.ToInt32(Session["EmrIpdNo"]) + " ";
        //if (txtFrom.Value != "" && txtTo.Value != "")
        //{
        //    query += " and    DagnosisAssigtTpPatient.CreatedOn between ('" + Convert.ToDateTime(txtFrom.Value).ToString("MM/dd/yyyy") + "') and ('" + Convert.ToDateTime(txtTo.Value).AddDays(1).ToString("MM/dd/yyyy") + "')";
        //}



        cmd1.CommandText = query + ")";

        con.Open();
        cmd1.ExecuteNonQuery();
        con.Close(); con.Dispose();
    }
    protected void btnAddTemplate_Click(object sender, EventArgs e)
    {
        LoadSlideBar("", "");
    }

    public void BindTemplate()
    {

        dt = new DataTable();
        dt = objBLLHCE.Get_Template(Convert.ToInt32(Session["Branchid"]));
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
                objBLLHCE.Insert_CaseSheetTOTemplate(Convert.ToInt32(Session["EmrRegNo"]), Convert.ToInt32(Session["EmrOpdNo"]), Convert.ToInt32(Session["EmrIpdNo"]), TempVal, TempName, Convert.ToString(Session["username"]));
            }

        }
        LoadSlideBar("", "");
        DeleteTemplate();
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

            SubMenuSQL = String.Format(@"SELECT        CaseAssignToTemplate.Id, CaseAssignToTemplate.Patregid, CaseAssignToTemplate.OPDNo, CaseAssignToTemplate.IPDNo, CaseAssignToTemplate.CaseID, CaseAssignToTemplate.TempID, "+
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
        objBLLHCE.Insert_CaseSheet(Convert.ToInt32(Session["EmrRegNo"]), Convert.ToInt32(Session["EmrOpdNo"]), Convert.ToInt32(Session["EmrIpdNo"]),   Convert.ToString(Session["username"]));

        LoadSlideBar("", "");
    }
    protected void btnCaseSheetDel_Click(object sender, EventArgs e)
    {
        LoadSlideBar("", "");
    }
    protected void ChkGeneralExam_SelectedIndexChanged(object sender, EventArgs e)
    {
        for (int i = 0; i <= ChkGeneralExam.Items.Count - 1; i++)
        {
            if (ChkGeneralExam.Items[i].Selected)
            {
               string  SurgeruName = ChkGeneralExam.Items[i].Text.Trim();
               if (SurgeruName == "Other")
               {
                   txtOther.Visible = true;
               }
            }
        }
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
                objBLLHCE.Delete_Template(Convert.ToInt32(Session["EmrRegNo"]), Convert.ToInt32(Session["EmrOpdNo"]), Convert.ToInt32(Session["EmrIpdNo"]), TempVal);
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
        dt = objBLLHCE.Get_AssignTemplate(Convert.ToInt32(Session["Branchid"]), Convert.ToInt32(Session["EmrRegNo"]), Convert.ToInt32(Session["EmrOpdNo"]), Convert.ToInt32(Session["EmrIpdNo"]));
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
        dt = objBLLHCE.Get_CaseSheet(Convert.ToInt32(Session["Branchid"]), Convert.ToInt32(Session["EmrRegNo"]), Convert.ToInt32(Session["EmrOpdNo"]), Convert.ToInt32(Session["EmrIpdNo"]));
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
                objBLLHCE.Delete_CaseSheet(Convert.ToInt32(Session["EmrRegNo"]), Convert.ToInt32(Session["EmrOpdNo"]), Convert.ToInt32(Session["EmrIpdNo"]), TempVal);
            }

        }
        LoadSlideBar("", "");
        // BindShortcut_test();

    }

}