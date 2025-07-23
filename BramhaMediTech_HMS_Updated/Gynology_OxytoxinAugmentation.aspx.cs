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

public partial class Gynology_OxytoxinAugmentation : System.Web.UI.Page
{
    clsEmr obj = new clsEmr();
    clsTreatment objTreat = new clsTreatment();
    clsTreatmentTransaction transaction = new clsTreatmentTransaction();
    DataTable tempDatatable = new DataTable();
    BELOxytoxinAugmentation objBLLHCE = new BELOxytoxinAugmentation();
    DALOxytoxinAugmentation objDAHCE = new DALOxytoxinAugmentation();
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

        objDAHCE.OxytoxinType = Convert.ToString(DdlType.SelectedItem.Text);
        objDAHCE.OxytoxinDate = Convert.ToDateTime(txttype.Text);
        objDAHCE.OxytoxinTablet = Convert.ToString(ddlTablet.SelectedItem.Text);
        objDAHCE.OxytoxinTablet1 = Convert.ToString(txtTablet.Text);
        objDAHCE.OxytoxinIncorporate = Convert.ToString(txtone.Text);
        objDAHCE.OxytoxinStartAt = Convert.ToString(txttwo.Text);

        objDAHCE.OxytoxinIncreaseBy = Convert.ToString(txtthree.Text);
        objDAHCE.OxytoxinIncreaseBy_1 = Convert.ToString(txtthree1.Text);
        objDAHCE.OxytoxinNotes = Convert.ToString(txtnotes.Text);

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

        objBLLHCE.Insert_OxytoxinAugmentation(objDAHCE);
        LblMSg.Text = "Record save successfully.!";
        LblMSg.ForeColor = System.Drawing.Color.Green;
        //BindHIVEncounter();
        //Clear();
    }
    public void Clear()
    {
        txtthree.Text = "";
        txtthree1.Text = "";
        txttwo.Text = "";
        txttype.Text = "";
        txtTablet.Text = "";
        txtone.Text = "";
        txtnotes.Text = "";
        
       
       
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
        tempDatatable = objBLLHCE.GetAllOxytoxinAugmentation(objDAHCE);
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
        Session["rptname"] = Server.MapPath("~/Report/Rpt_OxytoxinAugmentation.rpt");
        Session["reportname"] = "OxytoxinAugmentation";
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

        string query = "ALTER VIEW [dbo].[VW_GetOxytoxinAugmentation] AS (SELECT        PatientInformation.FirstName, PatientInformation.MiddleName, PatientInformation.LastName, Gender.GenderName, PatientInformation.BirthDate, PatientInformation.BloodGroup, PatientInformation.MaritalStatus, "+
                     "   PatientInformation.PhoneNo, PatientInformation.MobileNo, PatientInformation.PatientAddress, PatientInformation.Email, PatientInformation.Age, PatientInformation.AgeType, OxytoxinAugmentation.OxytoId, "+
                     "   OxytoxinAugmentation.Patregid, OxytoxinAugmentation.OPDNo, OxytoxinAugmentation.IPDNo, OxytoxinAugmentation.OxytoxinType, OxytoxinAugmentation.OxytoxinDate, OxytoxinAugmentation.OxytoxinTablet, "+
                     "   OxytoxinAugmentation.OxytoxinTablet1, OxytoxinAugmentation.OxytoxinIncorporate, OxytoxinAugmentation.OxytoxinStartAt, OxytoxinAugmentation.OxytoxinIncreaseBy, OxytoxinAugmentation.OxytoxinIncreaseBy_1, "+
                     "   OxytoxinAugmentation.OxytoxinNotes, OxytoxinAugmentation.Branchid, OxytoxinAugmentation.FID, OxytoxinAugmentation.CreatedBy, OxytoxinAugmentation.CreatedOn, OxytoxinAugmentation.UpdatedBy, "+
                     "   OxytoxinAugmentation.UpdatedOn "+
                     "   FROM            OxytoxinAugmentation INNER JOIN "+
                     "   PatientInformation ON OxytoxinAugmentation.Patregid = PatientInformation.PatRegId INNER JOIN "+
                     "   Gender ON PatientInformation.GenderId = Gender.GenderId " +
        " where OxytoxinAugmentation.Patregid=" + Convert.ToInt32(Session["EmrRegNo"]) + "  and  OxytoxinAugmentation.OPDNo=" + Convert.ToInt32(Session["EmrOpdNo"]) + " and  OxytoxinAugmentation.IPDNO=" + Convert.ToInt32(Session["EmrIpdNo"]) + " ";
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