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
public partial class Gynology_UterineInsemination :BasePage
{
    clsEmr obj = new clsEmr();
    clsTreatment objTreat = new clsTreatment();
    clsTreatmentTransaction transaction = new clsTreatmentTransaction();
    DataTable tempDatatable = new DataTable();
    BELGynology_UterineInsemination objBLLHCE = new BELGynology_UterineInsemination();
    DALGynology_UterineInsemination objDAHCE = new DALGynology_UterineInsemination();
    DataTable dt = new DataTable();
    BELGeneralGynology objBLLHCET1 = new BELGeneralGynology();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {//Save Done
            if (Session["EmrRegNo"] != "")
            {
                string regId = Convert.ToString(Session["EmrRegNo"]);
                string name = Request.QueryString["Name"];
                string opd = Convert.ToString(Session["EmrOpdNo"]);
                string entrydate = Request.QueryString["EntryDate"];
                Session["Branchid"] = "1";
                ViewState["Edit"] = "";
                ViewState["IUDId"] = "0";
               // lblOpd.Text = opd;
                SetInitialRow();
                MakeBillTable();
                BindSurgicalAdvice();
                BindHIVEncounter();
                BindTemplate();
                DeleteTemplate();
                DeleteCaseSheet();
                LoadSlideBar("", "");
            }
        }
    }
    private void MakeBillTable()
    {
        DataTable dt = new DataTable();
        dt.Clear();

        dt.Columns.Add("Clomifene");
        dt.Columns.Add("LetroZole");
        dt.Columns.Add("Metformin");
        dt.Columns.Add("Inj_FSH");
        dt.Columns.Add("IUDId");



        ViewState["BillTable"] = dt;
    }
    public void BindSurgicalAdvice()
    {
       

    }

    private void AddToGridView()
    {
        DataTable dt = (DataTable)ViewState["BillTable"];

        //if (validationPatient() == true)
        //{
            if (ViewState["Edit"].ToString() != "")
            {
                int index = Convert.ToInt32(ViewState["Index"]);
                dt.Rows[index]["Clomifene"] = ddlClomifene.SelectedItem.Text;
                dt.Rows[index]["LetroZole"] = ddlLetroZole.SelectedItem.Text;
                dt.Rows[index]["Metformin"] = ddlMetformin.SelectedItem;
                dt.Rows[index]["Inj_FSH"] = txtInjFsh.Text;

                dt.Rows[index]["IUDId"] = ViewState["IVFID"];

            }
            else
            {

                DataRow dr = dt.NewRow();
                dr["Clomifene"] = ddlClomifene.SelectedItem.Text;
                dr["LetroZole"] = ddlLetroZole.SelectedItem.Text;
                dr["Metformin"] = ddlMetformin.SelectedItem.Text;
                dr["Inj_FSH"] = txtInjFsh.Text;


                dr["IUDId"] = "0";

                dt.Rows.Add(dr);
            }
            ViewState["BillTable"] = dt;

            gvBill.DataSource = dt;
            gvBill.DataBind();
            Clear();
        //}
        //else
        //{
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + ViewState["Msg"] + "');", true);
        //    return;
        //}

    }
    protected void btnsave_Click(object sender, EventArgs e)
    {

        if (txtLMP.Text == "")
        {
            txtLMP.Focus();
            txtLMP.BorderColor = System.Drawing.Color.Red;
            return;
        }
        if (txtLMP.Text != "")
        {
            objDAHCE.LastLMP = Convert.ToDateTime(txtLMP.Text);
        }
        objDAHCE.LMPRemark = Convert.ToString(txtDLAP.Text);
        objDAHCE.Clomifene = Convert.ToString(ddlClomifene.SelectedValue);
        objDAHCE.LetroZole = Convert.ToString(ddlLetroZole.SelectedValue);
        objDAHCE.Metformin = Convert.ToString(ddlMetformin.SelectedValue);
        objDAHCE.Inj_FSH = Convert.ToString(txtInjFsh.Text);
        //if (txtdate.Text != "")
        //{
        //    objDAHCE.FollCareDate = Convert.ToDateTime(txtdate.Text);
        //}
        //objDAHCE.FollicareDay = Convert.ToString(txtday.Text);
        //objDAHCE.FolliclesRightOvary = Convert.ToString(txtFolliclesRightOvary.Text);
        //objDAHCE.FolliclesLiftOvary = Convert.ToString(txtFolliclesleftOvary.Text);
        //objDAHCE.Endometrial = Convert.ToString(txtEndometrialThickness.Text);

        //objDAHCE.FolliclesPlan = Convert.ToString(txtplan.Text);
        //objDAHCE.FolliclesRemark = Convert.ToString(txtRemark.Text);
        objDAHCE.FolliclesTrigger = Convert.ToString(txtTrigger.Text);
        if (txtIUIDate.Text != "")
        {
            objDAHCE.IUIDate = Convert.ToDateTime(txtIUIDate.Text);
        }
        objDAHCE.Motility = Convert.ToString(txtMotility.Text);

        objDAHCE.LutealSupport = Convert.ToString(txtlutealsupport.Text);
        objDAHCE.FolliclesCount = Convert.ToString(txtcount.Text);
        objDAHCE.FolliclesComments = Convert.ToString(txtComments.Text);
      

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

        objBLLHCE.InsertUterinelnemination(objDAHCE);
        LblMSg.Text = "Record save successfully.!";
        LblMSg.ForeColor = System.Drawing.Color.Green;
        BindHIVEncounter();
        Clear();
    }
    public void Clear()
    {
        txtComments.Text = "";
        txtcount.Text = "";
        //txtdate.Text = "";
        //txtday.Text = "";
        //txtDLAP.Text = "";
        //txtEndometrialThickness.Text = "";
        //txtFolliclesleftOvary.Text = "";
        //txtFolliclesRightOvary.Text = "";
        //txtplan.Text = "";
        //txtRemark.Text = "";
        txtInjFsh.Text = "";
        txtIUIDate.Text = "";
        txtLMP.Text = "";
        txtlutealsupport.Text = "";
        txtMotility.Text = "";
     
        txtTrigger.Text = "";

       
       
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
        tempDatatable = objBLLHCE.GetIntraUterineInsemination(objDAHCE);
        gvdChief.DataSource = tempDatatable;
        gvdChief.DataBind();

        GridView1.DataSource = tempDatatable; ;
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
        Session["rptname"] = Server.MapPath("~/Report/Rpt_UterineInsemination.rpt");
        Session["reportname"] = "UterineInsemination";
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

        string query = "ALTER VIEW [dbo].[VW_GetIntraUterineInsemination] AS (SELECT        IntraUterineInsemination.IntraId, IntraUterineInsemination.Patregid, IntraUterineInsemination.OPDNo, IntraUterineInsemination.IPDNo, IntraUterineInsemination.LMPDate, IntraUterineInsemination.LMPRemark, "+
               " IntraUterineInsemination.Clomifene, IntraUterineInsemination.LetroZole, IntraUterineInsemination.Metformin, IntraUterineInsemination.Inj_FSH, IntraUterineInsemination.FollCareDate, IntraUterineInsemination.FollicareDay, "+
               " IntraUterineInsemination.FolliclesRightOvary, IntraUterineInsemination.FolliclesLiftOvary, IntraUterineInsemination.Endometrial, IntraUterineInsemination.FolliclesPlan, IntraUterineInsemination.FolliclesRemark, "+
               " IntraUterineInsemination.FolliclesTrigger, IntraUterineInsemination.IUIDate, IntraUterineInsemination.Motility, IntraUterineInsemination.LutealSupport, IntraUterineInsemination.FolliclesCount, "+
               " IntraUterineInsemination.FolliclesComments, IntraUterineInsemination.Branchid, IntraUterineInsemination.Fid, IntraUterineInsemination.CreatedBy, IntraUterineInsemination.CreatedOn, IntraUterineInsemination.UpdatedBy, "+
               " IntraUterineInsemination.UpdatedOn, PatientInformation.FirstName, PatientInformation.MiddleName, PatientInformation.LastName, Gender.GenderName, PatientInformation.BirthDate, PatientInformation.BloodGroup, "+
               " PatientInformation.MaritalStatus, PatientInformation.PhoneNo, PatientInformation.MobileNo, PatientInformation.PatientAddress, PatientInformation.Email, PatientInformation.Age, PatientInformation.AgeType "+
               " FROM            IntraUterineInsemination INNER JOIN "+
               " PatientInformation ON IntraUterineInsemination.Patregid = PatientInformation.PatRegId INNER JOIN "+
               " Gender ON PatientInformation.GenderId = Gender.GenderId " +
        " where IntraUterineInsemination.Patregid=" + Convert.ToInt32(Session["EmrRegNo"]) + "  and  IntraUterineInsemination.OPDNo=" + Convert.ToInt32(Session["EmrOpdNo"]) + " and  IntraUterineInsemination.IPDNO=" + Convert.ToInt32(Session["EmrIpdNo"]) + " ";
        //if (txtFrom.Value != "" && txtTo.Value != "")
        //{
        //    query += " and    DagnosisAssigtTpPatient.CreatedOn between ('" + Convert.ToDateTime(txtFrom.Value).ToString("MM/dd/yyyy") + "') and ('" + Convert.ToDateTime(txtTo.Value).AddDays(1).ToString("MM/dd/yyyy") + "')";
        //}



        cmd1.CommandText = query + ")";

        con.Open();
        cmd1.ExecuteNonQuery();
        con.Close(); con.Dispose();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        AddToGridView();
        txtInjFsh.Text = "";
        ddlClomifene.SelectedValue = "";
        ddlLetroZole.SelectedValue = "";
        ddlMetformin.SelectedValue = "";
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
    

    protected void gvBill_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void gvBill_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void gvBill_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (ViewState["Edit"] != "")
        {
            DataTable dt = ViewState["BillTable"] as DataTable;
            int index = Convert.ToInt32(e.RowIndex);
            int IVFID = Convert.ToInt32(dt.Rows[index]["IUDId"]);
            if (IVFID > 0)
            {
            }
            else
            {
                dt.Rows[index].Delete();
                ViewState["BillTable"] = dt;
                gvBill.DataSource = dt;
                gvBill.DataBind();
            }
        }
        else
        {
            int index = Convert.ToInt32(e.RowIndex);
            DataTable dt = ViewState["BillTable"] as DataTable;
            dt.Rows[index].Delete();
            ViewState["BillTable"] = dt;
            //ViewState["BillTable"] = dt;

            gvBill.DataSource = dt;
            gvBill.DataBind();
        }
    }
    protected void gvBill_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int index = Convert.ToInt32(e.NewEditIndex);
        DataTable dt = ViewState["BillTable"] as DataTable;
        ddlClomifene.SelectedItem.Text = Convert.ToString(dt.Rows[index]["Clomifene"]);
        ddlLetroZole.SelectedItem.Text = Convert.ToString(dt.Rows[index]["LetroZole"]);
        ddlMetformin.SelectedItem.Text = Convert.ToString(dt.Rows[index]["Metformin"]);
        txtInjFsh.Text = Convert.ToString(dt.Rows[index]["Inj_FSH"]);
       


       
        ViewState["IUDId"] = Convert.ToInt32(dt.Rows[index]["IUDId"]);
        ViewState["BillTable"] = dt;
        ViewState["Index"] = index;
        ViewState["Edit"] = "1";
        e.Cancel = true;
    }
    protected void gvBill_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void SetInitialRow()
    {

        DataTable dt = new DataTable();

        DataRow dr = null;

        dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));

        dt.Columns.Add(new DataColumn("Column1", typeof(string)));

        dt.Columns.Add(new DataColumn("Column2", typeof(string)));

        dt.Columns.Add(new DataColumn("Column3", typeof(string)));
        dt.Columns.Add(new DataColumn("Column4", typeof(string)));
        dt.Columns.Add(new DataColumn("Column5", typeof(string)));
        dt.Columns.Add(new DataColumn("Column6", typeof(string)));
        dt.Columns.Add(new DataColumn("Column7", typeof(string)));

        dr = dt.NewRow();

        dr["RowNumber"] = 1;

        dr["Column1"] = string.Empty;

        dr["Column2"] = string.Empty;

        dr["Column3"] = string.Empty;
        dr["Column4"] = string.Empty;
        dr["Column5"] = string.Empty;
        dr["Column6"] = string.Empty;
        dr["Column7"] = string.Empty;

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

                    TextBox box1 = (TextBox)GVFOL_LICULAR.Rows[rowIndex].Cells[1].FindControl("txtDate1");

                    TextBox box2 = (TextBox)GVFOL_LICULAR.Rows[rowIndex].Cells[2].FindControl("txtDay1");

                    TextBox box3 = (TextBox)GVFOL_LICULAR.Rows[rowIndex].Cells[3].FindControl("txtFolliclesRightOvary1");
                    TextBox box4 = (TextBox)GVFOL_LICULAR.Rows[rowIndex].Cells[4].FindControl("txtFolliclesLeftOvary1");

                    TextBox box5 = (TextBox)GVFOL_LICULAR.Rows[rowIndex].Cells[5].FindControl("txtEndometrialThickness1");

                    TextBox box6 = (TextBox)GVFOL_LICULAR.Rows[rowIndex].Cells[6].FindControl("txtPlan1");

                    TextBox box7 = (TextBox)GVFOL_LICULAR.Rows[rowIndex].Cells[7].FindControl("txtRemark1");

                    drCurrentRow = dtCurrentTable.NewRow();

                    drCurrentRow["RowNumber"] = i + 1;



                    dtCurrentTable.Rows[i - 1]["Column1"] = box1.Text;

                    dtCurrentTable.Rows[i - 1]["Column2"] = box2.Text;

                    dtCurrentTable.Rows[i - 1]["Column3"] = box3.Text;
                    dtCurrentTable.Rows[i - 1]["Column4"] = box4.Text;
                    dtCurrentTable.Rows[i - 1]["Column5"] = box5.Text;
                    dtCurrentTable.Rows[i - 1]["Column6"] = box6.Text;
                    dtCurrentTable.Rows[i - 1]["Column7"] = box7.Text;



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

                    TextBox box1 = (TextBox)GVFOL_LICULAR.Rows[rowIndex].Cells[1].FindControl("txtDate1");

                    TextBox box2 = (TextBox)GVFOL_LICULAR.Rows[rowIndex].Cells[2].FindControl("txtDay1");

                    TextBox box3 = (TextBox)GVFOL_LICULAR.Rows[rowIndex].Cells[3].FindControl("txtFolliclesRightOvary1");
                    TextBox box4 = (TextBox)GVFOL_LICULAR.Rows[rowIndex].Cells[4].FindControl("txtFolliclesLeftOvary1");

                    TextBox box5 = (TextBox)GVFOL_LICULAR.Rows[rowIndex].Cells[5].FindControl("txtEndometrialThickness1");

                    TextBox box6 = (TextBox)GVFOL_LICULAR.Rows[rowIndex].Cells[6].FindControl("txtPlan1");

                    TextBox box7 = (TextBox)GVFOL_LICULAR.Rows[rowIndex].Cells[7].FindControl("txtRemark1");


                    box1.Text = dt.Rows[i]["Column1"].ToString();

                    box2.Text = dt.Rows[i]["Column2"].ToString();

                    box3.Text = dt.Rows[i]["Column3"].ToString();

                    box4.Text = dt.Rows[i]["Column4"].ToString();

                    box5.Text = dt.Rows[i]["Column5"].ToString();

                    box6.Text = dt.Rows[i]["Column6"].ToString();

                    box7.Text = dt.Rows[i]["Column7"].ToString();



                    rowIndex++;

                }

            }

        }

    }
    protected void ButtonAdd_Click(object sender, EventArgs e)
    {

        AddNewRowToGrid();

    }

    protected void ButtonAdd_Click1(object sender, EventArgs e)
    {
        AddNewRowToGrid();
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