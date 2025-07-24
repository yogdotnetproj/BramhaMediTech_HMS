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

public partial class Gynology_DrugSchedule :BasePage
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
                SetInitialRow();
                SetAntaInitialRow();
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

        objDAHCE.FolliclesLeftOvary = Convert.ToString(txtNoofFolliclesleft.Text);
        objDAHCE.FolliclesRightOvary = Convert.ToString(txtNoofFolliclesright.Text);
        objDAHCE.Consent = Convert.ToString(ddlConsent.SelectedValue);
        objDAHCE.Note = Convert.ToString(txtnote.Text);
        for (int i = 0; i < GVlongprotocol.Rows.Count; i++)
        {

            //extract the TextBox values

            TextBox box1 = (TextBox)GVlongprotocol.Rows[i].Cells[1].FindControl("txtLongDate");
            TextBox box2 = (TextBox)GVlongprotocol.Rows[i].Cells[2].FindControl("txtLongFSH");
            TextBox box3 = (TextBox)GVlongprotocol.Rows[i].Cells[3].FindControl("txtLongFSHLH");
            TextBox box4 = (TextBox)GVlongprotocol.Rows[i].Cells[4].FindControl("txtLongUnits");
            TextBox box5 = (TextBox)GVlongprotocol.Rows[i].Cells[5].FindControl("txtlongAgonist");
            TextBox box6 = (TextBox)GVlongprotocol.Rows[i].Cells[6].FindControl("txtLongMiscName");
            TextBox box7 = (TextBox)GVlongprotocol.Rows[i].Cells[7].FindControl("txtLongMiscValue");
            TextBox box8 = (TextBox)GVlongprotocol.Rows[i].Cells[8].FindControl("txtLongComments");

            if (box1.Text != "")
            {
                objDAHCE.DrugScheduleDate = Convert.ToDateTime(box1.Text);
                objDAHCE.FSH = box2.Text;
                objDAHCE.FSHLH = box3.Text;
                objDAHCE.Units = box4.Text;
                objDAHCE.Agonist = box5.Text;
                objDAHCE.MISCName = box6.Text;
                objDAHCE.MISCValue = box7.Text;
                objDAHCE.Comments = box8.Text;
               
                objBLLHCE.InsertGynaclogy_Antenatal_DrugSchedule(objDAHCE);
            }
        }
       //objBLLHCE.InsertGeneralGynaclogy(objDAHCE);
       
       LblMSg.Text = "Record save successfully.!";
       LblMSg.ForeColor = System.Drawing.Color.Green;
      
    }
    
   
    protected void gvdChief_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvdChief.PageIndex = e.NewPageIndex;
       
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
        Session["rptname"] = Server.MapPath("~/Report/Rpt_ANTENATALCARD_DrugSchedule.rpt");
        Session["reportname"] = "ANTENATALCARD_DrugSchedule";
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

        string query = "ALTER VIEW [dbo].[VW_Gynalogy_ANTENATALCARD_DrugSchedule] AS (SELECT        PatientInformation.MiddleName, PatientInformation.LastName, Gender.GenderName, PatientInformation.MobileNo, PatientInformation.PhoneNo, PatientInformation.PatientAddress, PatientInformation.Email, "+
                  "  PatientInformation.Age, PatientInformation.AgeType, PatientInformation.FirstName, Gynalogy_ANTENATALCARD_DrugSchedule.Id, Gynalogy_ANTENATALCARD_DrugSchedule.Patregid, "+
                  "  Gynalogy_ANTENATALCARD_DrugSchedule.OpdNo, Gynalogy_ANTENATALCARD_DrugSchedule.IpdNo, Gynalogy_ANTENATALCARD_DrugSchedule.FolliclesLeftOvary, "+
                  "  Gynalogy_ANTENATALCARD_DrugSchedule.FolliclesRightOvary, Gynalogy_ANTENATALCARD_DrugSchedule.Consent, Gynalogy_ANTENATALCARD_DrugSchedule.Notes, "+ 
                  "  Gynalogy_ANTENATALCARD_DrugSchedule.DrugScheduleDate, Gynalogy_ANTENATALCARD_DrugSchedule.FSH, Gynalogy_ANTENATALCARD_DrugSchedule.FSHLH, Gynalogy_ANTENATALCARD_DrugSchedule.Units, "+
                  "  Gynalogy_ANTENATALCARD_DrugSchedule.Agonist, Gynalogy_ANTENATALCARD_DrugSchedule.MISCName, Gynalogy_ANTENATALCARD_DrugSchedule.MISCValue, Gynalogy_ANTENATALCARD_DrugSchedule.Comments, "+
                  "  Gynalogy_ANTENATALCARD_DrugSchedule.CreatedBy, Gynalogy_ANTENATALCARD_DrugSchedule.CreatedOn, Gynalogy_ANTENATALCARD_DrugSchedule.Branchid "+
                  "  FROM  Gynalogy_ANTENATALCARD_DrugSchedule INNER JOIN "+
                  "  PatientInformation ON Gynalogy_ANTENATALCARD_DrugSchedule.Patregid = PatientInformation.PatRegId INNER JOIN "+
                  "  Gender ON PatientInformation.GenderId = Gender.GenderId " +
        " where Gynalogy_ANTENATALCARD_DrugSchedule.Patregid=" + Convert.ToInt32(Session["EmrRegNo"]) + "  and  Gynalogy_ANTENATALCARD_DrugSchedule.OPDNo=" + Convert.ToInt32(Session["EmrOpdNo"]) + " and  Gynalogy_ANTENATALCARD_DrugSchedule.IPDNO=" + Convert.ToInt32(Session["EmrIpdNo"]) + " ";
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

    protected void ButtonAdd_Click(object sender, EventArgs e)
    {

        AddNewRowToGrid();
        LoadSlideBar("", "");
    }

    private void SetInitialRow()
    {

        DataTable dt = new DataTable();

        DataRow dr = null;

                dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));

        dt.Columns.Add(new DataColumn("LongDate", typeof(string)));
        dt.Columns.Add(new DataColumn("LongFSH", typeof(string)));
        dt.Columns.Add(new DataColumn("LongFSHLH", typeof(string)));
        dt.Columns.Add(new DataColumn("LongUnits", typeof(string)));
        dt.Columns.Add(new DataColumn("longAgonist", typeof(string)));
        dt.Columns.Add(new DataColumn("LongMiscName", typeof(string)));
        dt.Columns.Add(new DataColumn("LongMiscValue", typeof(string)));
        dt.Columns.Add(new DataColumn("LongComments", typeof(string)));



        dr = dt.NewRow();

        dr["RowNumber"] = 1;

        dr["LongDate"] = string.Empty;
        dr["LongFSH"] = string.Empty;
        dr["LongFSHLH"] = string.Empty;
        dr["LongUnits"] = string.Empty;
        dr["longAgonist"] = string.Empty;
        dr["LongMiscName"] = string.Empty;
        dr["LongMiscValue"] = string.Empty;
        dr["LongComments"] = string.Empty;
        dt.Rows.Add(dr);
        //----------------------------
        dr = dt.NewRow();

        dr["RowNumber"] = 2;

        dr["LongDate"] = string.Empty;
        dr["LongFSH"] = string.Empty;
        dr["LongFSHLH"] = string.Empty;
        dr["LongUnits"] = string.Empty;
        dr["longAgonist"] = string.Empty;
        dr["LongMiscName"] = string.Empty;
        dr["LongMiscValue"] = string.Empty;
        dr["LongComments"] = string.Empty;
        dt.Rows.Add(dr);
        //----------------------------
        dr = dt.NewRow();

        dr["RowNumber"] = 3;

        dr["LongDate"] = string.Empty;
        dr["LongFSH"] = string.Empty;
        dr["LongFSHLH"] = string.Empty;
        dr["LongUnits"] = string.Empty;
        dr["longAgonist"] = string.Empty;
        dr["LongMiscName"] = string.Empty;
        dr["LongMiscValue"] = string.Empty;
        dr["LongComments"] = string.Empty;
        dt.Rows.Add(dr);
        //----------------------------
        dr = dt.NewRow();

        dr["RowNumber"] = 4;

        dr["LongDate"] = string.Empty;
        dr["LongFSH"] = string.Empty;
        dr["LongFSHLH"] = string.Empty;
        dr["LongUnits"] = string.Empty;
        dr["longAgonist"] = string.Empty;
        dr["LongMiscName"] = string.Empty;
        dr["LongMiscValue"] = string.Empty;
        dr["LongComments"] = string.Empty;
        dt.Rows.Add(dr);
        //----------------------------
        dr = dt.NewRow();

        dr["RowNumber"] = 5;

        dr["LongDate"] = string.Empty;
        dr["LongFSH"] = string.Empty;
        dr["LongFSHLH"] = string.Empty;
        dr["LongUnits"] = string.Empty;
        dr["longAgonist"] = string.Empty;
        dr["LongMiscName"] = string.Empty;
        dr["LongMiscValue"] = string.Empty;
        dr["LongComments"] = string.Empty;
        dt.Rows.Add(dr);
        //----------------------------
        dr = dt.NewRow();

        dr["RowNumber"] = 6;

        dr["LongDate"] = string.Empty;
        dr["LongFSH"] = string.Empty;
        dr["LongFSHLH"] = string.Empty;
        dr["LongUnits"] = string.Empty;
        dr["longAgonist"] = string.Empty;
        dr["LongMiscName"] = string.Empty;
        dr["LongMiscValue"] = string.Empty;
        dr["LongComments"] = string.Empty;
        dt.Rows.Add(dr);
        //----------------------------
        dr = dt.NewRow();

        dr["RowNumber"] = 7;

        dr["LongDate"] = string.Empty;
        dr["LongFSH"] = string.Empty;
        dr["LongFSHLH"] = string.Empty;
        dr["LongUnits"] = string.Empty;
        dr["longAgonist"] = string.Empty;
        dr["LongMiscName"] = string.Empty;
        dr["LongMiscValue"] = string.Empty;
        dr["LongComments"] = string.Empty;
        dt.Rows.Add(dr);
        //----------------------------
        dr = dt.NewRow();

        dr["RowNumber"] = 8;

        dr["LongDate"] = string.Empty;
        dr["LongFSH"] = string.Empty;
        dr["LongFSHLH"] = string.Empty;
        dr["LongUnits"] = string.Empty;
        dr["longAgonist"] = string.Empty;
        dr["LongMiscName"] = string.Empty;
        dr["LongMiscValue"] = string.Empty;
        dr["LongComments"] = string.Empty;
        dt.Rows.Add(dr);
        //----------------------------
        dr = dt.NewRow();

        dr["RowNumber"] = 9;

        dr["LongDate"] = string.Empty;
        dr["LongFSH"] = string.Empty;
        dr["LongFSHLH"] = string.Empty;
        dr["LongUnits"] = string.Empty;
        dr["longAgonist"] = string.Empty;
        dr["LongMiscName"] = string.Empty;
        dr["LongMiscValue"] = string.Empty;
        dr["LongComments"] = string.Empty;
        dt.Rows.Add(dr);
        //----------------------------
        dr = dt.NewRow();

        dr["RowNumber"] = 10;

        dr["LongDate"] = string.Empty;
        dr["LongFSH"] = string.Empty;
        dr["LongFSHLH"] = string.Empty;
        dr["LongUnits"] = string.Empty;
        dr["longAgonist"] = string.Empty;
        dr["LongMiscName"] = string.Empty;
        dr["LongMiscValue"] = string.Empty;
        dr["LongComments"] = string.Empty;
        dt.Rows.Add(dr);
        //----------------------------
        dr = dt.NewRow();

        dr["RowNumber"] = 11;

        dr["LongDate"] = string.Empty;
        dr["LongFSH"] = string.Empty;
        dr["LongFSHLH"] = string.Empty;
        dr["LongUnits"] = string.Empty;
        dr["longAgonist"] = string.Empty;
        dr["LongMiscName"] = string.Empty;
        dr["LongMiscValue"] = string.Empty;
        dr["LongComments"] = string.Empty;
        dt.Rows.Add(dr);
        //----------------------------
        dr = dt.NewRow();

        dr["RowNumber"] = 12;

        dr["LongDate"] = string.Empty;
        dr["LongFSH"] = string.Empty;
        dr["LongFSHLH"] = string.Empty;
        dr["LongUnits"] = string.Empty;
        dr["longAgonist"] = string.Empty;
        dr["LongMiscName"] = string.Empty;
        dr["LongMiscValue"] = string.Empty;
        dr["LongComments"] = string.Empty;
        dt.Rows.Add(dr);
        //----------------------------
        dr = dt.NewRow();

        dr["RowNumber"] = 13;

        dr["LongDate"] = string.Empty;
        dr["LongFSH"] = string.Empty;
        dr["LongFSHLH"] = string.Empty;
        dr["LongUnits"] = string.Empty;
        dr["longAgonist"] = string.Empty;
        dr["LongMiscName"] = string.Empty;
        dr["LongMiscValue"] = string.Empty;
        dr["LongComments"] = string.Empty;
        dt.Rows.Add(dr);
        //----------------------------
        dr = dt.NewRow();

        dr["RowNumber"] = 14;

        dr["LongDate"] = string.Empty;
        dr["LongFSH"] = string.Empty;
        dr["LongFSHLH"] = string.Empty;
        dr["LongUnits"] = string.Empty;
        dr["longAgonist"] = string.Empty;
        dr["LongMiscName"] = string.Empty;
        dr["LongMiscValue"] = string.Empty;
        dr["LongComments"] = string.Empty;
        dt.Rows.Add(dr);
        //----------------------------
        dr = dt.NewRow();

        dr["RowNumber"] = 15;

        dr["LongDate"] = string.Empty;
        dr["LongFSH"] = string.Empty;
        dr["LongFSHLH"] = string.Empty;
        dr["LongUnits"] = string.Empty;
        dr["longAgonist"] = string.Empty;
        dr["LongMiscName"] = string.Empty;
        dr["LongMiscValue"] = string.Empty;
        dr["LongComments"] = string.Empty;
        dt.Rows.Add(dr);



        //dr = dt.NewRow();



        //Store the DataTable in ViewState

        ViewState["CurrentTable"] = dt;



        GVlongprotocol.DataSource = dt;

        GVlongprotocol.DataBind();

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

                    TextBox box1 = (TextBox)GVlongprotocol.Rows[rowIndex].Cells[1].FindControl("txtLongDate");

                    TextBox box2 = (TextBox)GVlongprotocol.Rows[rowIndex].Cells[2].FindControl("txtLongFSH");
                    TextBox box3 = (TextBox)GVlongprotocol.Rows[rowIndex].Cells[3].FindControl("txtLongFSHLH");

                    TextBox box4 = (TextBox)GVlongprotocol.Rows[rowIndex].Cells[4].FindControl("txtLongUnits");
                    TextBox box5 = (TextBox)GVlongprotocol.Rows[rowIndex].Cells[5].FindControl("txtlongAgonist");

                    TextBox box6 = (TextBox)GVlongprotocol.Rows[rowIndex].Cells[6].FindControl("txtLongMiscName");
                    TextBox box7 = (TextBox)GVlongprotocol.Rows[rowIndex].Cells[7].FindControl("txtLongMiscValue");

                    TextBox box8 = (TextBox)GVlongprotocol.Rows[rowIndex].Cells[8].FindControl("txtLongComments");



                    drCurrentRow = dtCurrentTable.NewRow();

                    drCurrentRow["RowNumber"] = i + 1;



                    dtCurrentTable.Rows[i - 1]["LongDate"] = box1.Text;
                    dtCurrentTable.Rows[i - 1]["LongFSH"] = box2.Text;
                    dtCurrentTable.Rows[i - 1]["LongFSHLH"] = box3.Text;
                    dtCurrentTable.Rows[i - 1]["LongUnits"] = box4.Text;
                    dtCurrentTable.Rows[i - 1]["longAgonist"] = box5.Text;
                    dtCurrentTable.Rows[i - 1]["LongMiscName"] = box6.Text;
                    dtCurrentTable.Rows[i - 1]["LongMiscValue"] = box7.Text;
                    dtCurrentTable.Rows[i - 1]["LongComments"] = box8.Text;


                    rowIndex++;

                }

                dtCurrentTable.Rows.Add(drCurrentRow);

                ViewState["CurrentTable"] = dtCurrentTable;



                GVlongprotocol.DataSource = dtCurrentTable;
                GVlongprotocol.DataBind();

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

                   

                    TextBox box1 = (TextBox)GVlongprotocol.Rows[rowIndex].Cells[1].FindControl("txtLongDate");

                    TextBox box2 = (TextBox)GVlongprotocol.Rows[rowIndex].Cells[2].FindControl("txtLongFSH");
                    TextBox box3 = (TextBox)GVlongprotocol.Rows[rowIndex].Cells[3].FindControl("txtLongFSHLH");

                    TextBox box4 = (TextBox)GVlongprotocol.Rows[rowIndex].Cells[4].FindControl("txtLongUnits");
                    TextBox box5 = (TextBox)GVlongprotocol.Rows[rowIndex].Cells[5].FindControl("txtlongAgonist");

                    TextBox box6 = (TextBox)GVlongprotocol.Rows[rowIndex].Cells[6].FindControl("txtLongMiscName");
                    TextBox box7 = (TextBox)GVlongprotocol.Rows[rowIndex].Cells[7].FindControl("txtLongMiscValue");

                    TextBox box8 = (TextBox)GVlongprotocol.Rows[rowIndex].Cells[8].FindControl("txtLongComments");

                    box1.Text = dt.Rows[i]["LongDate"].ToString();
                    box2.Text = dt.Rows[i]["LongFSH"].ToString();
                    box3.Text = dt.Rows[i]["LongFSHLH"].ToString();
                    box4.Text = dt.Rows[i]["LongUnits"].ToString();
                    box5.Text = dt.Rows[i]["longAgonist"].ToString();
                    box6.Text = dt.Rows[i]["LongMiscName"].ToString();
                    box7.Text = dt.Rows[i]["LongMiscValue"].ToString();
                    box8.Text = dt.Rows[i]["LongComments"].ToString();


                    rowIndex++;

                }

            }

        }

    }

    protected void btnLongPRotocol_Click(object sender, EventArgs e)
    {
        Antagonist.Visible = false;
        Antagonist1.Visible = false;
        Antagonist2.Visible = false;
        Antagonist3.Visible = false;

        longprotocol.Visible = true;
        longprotocol1.Visible = true;
        longprotocol2.Visible = true;
        longprotocol3.Visible = true;
        LoadSlideBar("", "");
    }
    protected void btnAntagonist_Click(object sender, EventArgs e)
    {
        LoadSlideBar("", "");
        Antagonist.Visible = true;
        Antagonist1.Visible = true;
        Antagonist2.Visible = true;
        Antagonist3.Visible = true;

        longprotocol.Visible = false;
        longprotocol1.Visible = false;
        longprotocol2.Visible = false;
        longprotocol3.Visible = false;
    }


    private void SetAntaInitialRow()
    {

        DataTable dt = new DataTable();

        DataRow dr = null;

        dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));

        dt.Columns.Add(new DataColumn("AntaDate", typeof(string)));
        dt.Columns.Add(new DataColumn("AntaFSH", typeof(string)));
        dt.Columns.Add(new DataColumn("AntaFSHLH", typeof(string)));
        dt.Columns.Add(new DataColumn("AntaUnits", typeof(string)));
        dt.Columns.Add(new DataColumn("AntaAgonist", typeof(string)));
        dt.Columns.Add(new DataColumn("AntaMiscName", typeof(string)));
        dt.Columns.Add(new DataColumn("AntaMiscValue", typeof(string)));
        dt.Columns.Add(new DataColumn("AntaComments", typeof(string)));



        dr = dt.NewRow();

        dr["RowNumber"] = 1;

        dr["AntaDate"] = string.Empty;
        dr["AntaFSH"] = string.Empty;
        dr["AntaFSHLH"] = string.Empty;
        dr["AntaUnits"] = string.Empty;
        dr["AntaAgonist"] = string.Empty;
        dr["AntaMiscName"] = string.Empty;
        dr["AntaMiscValue"] = string.Empty;
        dr["AntaComments"] = string.Empty;
        dt.Rows.Add(dr);
        //----------------------------
        dr = dt.NewRow();

        dr["RowNumber"] = 2;

        dr["AntaDate"] = string.Empty;
        dr["AntaFSH"] = string.Empty;
        dr["AntaFSHLH"] = string.Empty;
        dr["AntaUnits"] = string.Empty;
        dr["AntaAgonist"] = string.Empty;
        dr["AntaMiscName"] = string.Empty;
        dr["AntaMiscValue"] = string.Empty;
        dr["AntaComments"] = string.Empty;
        dt.Rows.Add(dr);
        //----------------------------
        dr = dt.NewRow();

        dr["RowNumber"] = 3;

        dr["AntaDate"] = string.Empty;
        dr["AntaFSH"] = string.Empty;
        dr["AntaFSHLH"] = string.Empty;
        dr["AntaUnits"] = string.Empty;
        dr["AntaAgonist"] = string.Empty;
        dr["AntaMiscName"] = string.Empty;
        dr["AntaMiscValue"] = string.Empty;
        dr["AntaComments"] = string.Empty;
        dt.Rows.Add(dr);
        //----------------------------
        dr = dt.NewRow();

        dr["RowNumber"] = 4;

        dr["AntaDate"] = string.Empty;
        dr["AntaFSH"] = string.Empty;
        dr["AntaFSHLH"] = string.Empty;
        dr["AntaUnits"] = string.Empty;
        dr["AntaAgonist"] = string.Empty;
        dr["AntaMiscName"] = string.Empty;
        dr["AntaMiscValue"] = string.Empty;
        dr["AntaComments"] = string.Empty;
        dt.Rows.Add(dr);
        //----------------------------
        dr = dt.NewRow();

        dr["RowNumber"] = 5;

        dr["AntaDate"] = string.Empty;
        dr["AntaFSH"] = string.Empty;
        dr["AntaFSHLH"] = string.Empty;
        dr["AntaUnits"] = string.Empty;
        dr["AntaAgonist"] = string.Empty;
        dr["AntaMiscName"] = string.Empty;
        dr["AntaMiscValue"] = string.Empty;
        dr["AntaComments"] = string.Empty;
        dt.Rows.Add(dr);
        //----------------------------
        dr = dt.NewRow();

        dr["RowNumber"] = 6;

        dr["AntaDate"] = string.Empty;
        dr["AntaFSH"] = string.Empty;
        dr["AntaFSHLH"] = string.Empty;
        dr["AntaUnits"] = string.Empty;
        dr["AntaAgonist"] = string.Empty;
        dr["AntaMiscName"] = string.Empty;
        dr["AntaMiscValue"] = string.Empty;
        dr["AntaComments"] = string.Empty;
        dt.Rows.Add(dr);
        //----------------------------
        dr = dt.NewRow();

        dr["RowNumber"] = 7;

        dr["AntaDate"] = string.Empty;
        dr["AntaFSH"] = string.Empty;
        dr["AntaFSHLH"] = string.Empty;
        dr["AntaUnits"] = string.Empty;
        dr["AntaAgonist"] = string.Empty;
        dr["AntaMiscName"] = string.Empty;
        dr["AntaMiscValue"] = string.Empty;
        dr["AntaComments"] = string.Empty;
        dt.Rows.Add(dr);
        //----------------------------
        dr = dt.NewRow();

        dr["RowNumber"] = 8;

        dr["AntaDate"] = string.Empty;
        dr["AntaFSH"] = string.Empty;
        dr["AntaFSHLH"] = string.Empty;
        dr["AntaUnits"] = string.Empty;
        dr["AntaAgonist"] = string.Empty;
        dr["AntaMiscName"] = string.Empty;
        dr["AntaMiscValue"] = string.Empty;
        dr["AntaComments"] = string.Empty;
        dt.Rows.Add(dr);
        //----------------------------
        dr = dt.NewRow();

        dr["RowNumber"] = 9;

        dr["AntaDate"] = string.Empty;
        dr["AntaFSH"] = string.Empty;
        dr["AntaFSHLH"] = string.Empty;
        dr["AntaUnits"] = string.Empty;
        dr["AntaAgonist"] = string.Empty;
        dr["AntaMiscName"] = string.Empty;
        dr["AntaMiscValue"] = string.Empty;
        dr["AntaComments"] = string.Empty;
        dt.Rows.Add(dr);
        //----------------------------
        dr = dt.NewRow();

        dr["RowNumber"] = 10;

        dr["AntaDate"] = string.Empty;
        dr["AntaFSH"] = string.Empty;
        dr["AntaFSHLH"] = string.Empty;
        dr["AntaUnits"] = string.Empty;
        dr["AntaAgonist"] = string.Empty;
        dr["AntaMiscName"] = string.Empty;
        dr["AntaMiscValue"] = string.Empty;
        dr["AntaComments"] = string.Empty;
        dt.Rows.Add(dr);
        //----------------------------
        dr = dt.NewRow();

        dr["RowNumber"] = 11;

        dr["AntaDate"] = string.Empty;
        dr["AntaFSH"] = string.Empty;
        dr["AntaFSHLH"] = string.Empty;
        dr["AntaUnits"] = string.Empty;
        dr["AntaAgonist"] = string.Empty;
        dr["AntaMiscName"] = string.Empty;
        dr["AntaMiscValue"] = string.Empty;
        dr["AntaComments"] = string.Empty;
        dt.Rows.Add(dr);
        //----------------------------
        dr = dt.NewRow();

        dr["RowNumber"] = 12;

        dr["AntaDate"] = string.Empty;
        dr["AntaFSH"] = string.Empty;
        dr["AntaFSHLH"] = string.Empty;
        dr["AntaUnits"] = string.Empty;
        dr["AntaAgonist"] = string.Empty;
        dr["AntaMiscName"] = string.Empty;
        dr["AntaMiscValue"] = string.Empty;
        dr["AntaComments"] = string.Empty;
        dt.Rows.Add(dr);
        //----------------------------
        dr = dt.NewRow();

        dr["RowNumber"] = 13;

        dr["AntaDate"] = string.Empty;
        dr["AntaFSH"] = string.Empty;
        dr["AntaFSHLH"] = string.Empty;
        dr["AntaUnits"] = string.Empty;
        dr["AntaAgonist"] = string.Empty;
        dr["AntaMiscName"] = string.Empty;
        dr["AntaMiscValue"] = string.Empty;
        dr["AntaComments"] = string.Empty;
        dt.Rows.Add(dr);
        //----------------------------
        dr = dt.NewRow();

        dr["RowNumber"] = 14;

        dr["AntaDate"] = string.Empty;
        dr["AntaFSH"] = string.Empty;
        dr["AntaFSHLH"] = string.Empty;
        dr["AntaUnits"] = string.Empty;
        dr["AntaAgonist"] = string.Empty;
        dr["AntaMiscName"] = string.Empty;
        dr["AntaMiscValue"] = string.Empty;
        dr["AntaComments"] = string.Empty;
        dt.Rows.Add(dr);
        //----------------------------
        dr = dt.NewRow();

        dr["RowNumber"] = 15;

        dr["AntaDate"] = string.Empty;
        dr["AntaFSH"] = string.Empty;
        dr["AntaFSHLH"] = string.Empty;
        dr["AntaUnits"] = string.Empty;
        dr["AntaAgonist"] = string.Empty;
        dr["AntaMiscName"] = string.Empty;
        dr["AntaMiscValue"] = string.Empty;
        dr["AntaComments"] = string.Empty;
        dt.Rows.Add(dr);



        //dr = dt.NewRow();



        //Store the DataTable in ViewState

        ViewState["CurrentTable"] = dt;



        GvAntagonist.DataSource = dt;

        GvAntagonist.DataBind();

    }
}