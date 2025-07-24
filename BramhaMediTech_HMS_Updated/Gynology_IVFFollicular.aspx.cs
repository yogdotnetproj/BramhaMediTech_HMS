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

public partial class Gynology_IVFFollicular :BasePage
{
    clsEmr obj = new clsEmr();
    clsTreatment objTreat = new clsTreatment();
    clsTreatmentTransaction transaction = new clsTreatmentTransaction();
    DataTable tempDatatable = new DataTable();
    BELIVFFollicular objBLLHCE = new BELIVFFollicular();
    DALIVFFollicular objDAHCE = new DALIVFFollicular();
    DataTable dt = new DataTable();
    BELGeneralGynology objBLLHCET = new BELGeneralGynology();
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
                ViewState["Edit"] = "";
                 ViewState["IVFID"]="0";
               // lblOpd.Text = opd;
                BindSurgicalAdvice();
                BindHIVEncounter();
                MakeBillTable();
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

        foreach (GridViewRow row in gvBill.Rows)
        {


            objDAHCE.StimulationDate = Convert.ToDateTime(row.Cells[1].Text);
            objDAHCE.CycleDay = Convert.ToString(row.Cells[2].Text);
            objDAHCE.SimulationDay = Convert.ToString(row.Cells[3].Text);
            objDAHCE.RightOvary = Convert.ToString(row.Cells[4].Text);
            objDAHCE.LeftOvary = Convert.ToString(row.Cells[5].Text);

            objDAHCE.EndometriumMM = Convert.ToString(row.Cells[6].Text);
            objDAHCE.Plan = Convert.ToString(row.Cells[7].Text);
            objDAHCE.Remarks = Convert.ToString(row.Cells[8].Text);
            objDAHCE.LastLMP = Convert.ToDateTime(txtLMP.Text);

            objDAHCE.StimulationProtocol = Convert.ToString(txtStimulationProtocol.Text);
          
            //if (row.Cells[4].Text == "&nbsp;")
            //{
            //    IndReq.BatchNo = "";
            //}
            //else
            //{
            //    IndReq.BatchNo = Convert.ToString(row.Cells[4].Text);
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

            objBLLHCE.InsertIVFFollicular(objDAHCE);
        }
        LblMSg.Text = "Record save successfully.!";
        LblMSg.ForeColor = System.Drawing.Color.Green;
        BindHIVEncounter();
        Clear();
    }
    public void Clear()
    {
        txtdate.Text = ""; ;
        txtcycleDay.Text = "";

        txtSimulation.Text = "";
        txtRightovary.Text = "";
        txtLeftOvary.Text = "";
        txtEndometrium.Text = "";
        txtplan.Text = "";
        txtRemarks.Text = "";
       
       
    }

    private void MakeBillTable()
    {
        DataTable dt = new DataTable();
        dt.Clear();

        dt.Columns.Add("StimulationProtocol");
        dt.Columns.Add("LastLMP");
        dt.Columns.Add("StimulationDate");
        dt.Columns.Add("CycleDay");
        dt.Columns.Add("SimulationDay");
        dt.Columns.Add("RightOvary");
        dt.Columns.Add("LeftOvary");
        dt.Columns.Add("EndometriumMM");
        dt.Columns.Add("IVFPlan");
        dt.Columns.Add("Remarks");
        dt.Columns.Add("IVFID");
        


        ViewState["BillTable"] = dt;
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
        tempDatatable = objBLLHCE.Get_IVFFollicular(objDAHCE);
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

    private void AddToGridView()
    {
        DataTable dt = (DataTable)ViewState["BillTable"];

        if (validationPatient() == true)
        {
            if (ViewState["Edit"].ToString() != "")
            {
                int index = Convert.ToInt32(ViewState["Index"]);
                dt.Rows[index]["StimulationProtocol"] =txtStimulationProtocol.Text;
                dt.Rows[index]["LastLMP"] = txtLMP.Text;
                dt.Rows[index]["StimulationDate"] = txtdate.Text;
                dt.Rows[index]["CycleDay"] = txtcycleDay.Text;
                dt.Rows[index]["SimulationDay"] = txtSimulation.Text;
                dt.Rows[index]["RightOvary"] = txtRightovary.Text;
               

                dt.Rows[index]["LeftOvary"] = txtLeftOvary.Text;
                dt.Rows[index]["EndometriumMM"] = txtEndometrium.Text;
                 dt.Rows[index]["IVFPlan"] =txtplan.Text;
                 dt.Rows[index]["Remarks"] = txtRemarks.Text;
                 dt.Rows[index]["IVFID"] = ViewState["IVFID"];
                
            }
            else
            {

                DataRow dr = dt.NewRow();
                dr["StimulationProtocol"] = txtdate.Text;
                dr["LastLMP"] = txtcycleDay.Text;
                dr["StimulationDate"] = txtdate.Text;
                dr["CycleDay"] = txtcycleDay.Text;

                dr["SimulationDay"] = txtSimulation.Text;
                dr["RightOvary"] =txtRightovary.Text;
                dr["LeftOvary"] = txtLeftOvary.Text;
                dr["EndometriumMM"] = txtEndometrium.Text;
                dr["IVFPlan"] = txtplan.Text;
                dr["Remarks"] = txtRemarks.Text;
                dr["IVFID"] = "0";
                
                dt.Rows.Add(dr);
            }
            ViewState["BillTable"] = dt;

            gvBill.DataSource = dt;
            gvBill.DataBind();
            Clear();
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + ViewState["Msg"] + "');", true);
            return;
        }

    }

    public bool validationPatient()
    {
       // bool flag = false;
        if (txtLMP.Text == "")
        {
            txtLMP.Focus();
            txtLMP.BorderColor = System.Drawing.Color.Red;
            return false;
        }

        return true;
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
            int IVFID = Convert.ToInt32(dt.Rows[index]["IVFID"]);
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
        txtStimulationProtocol.Text = Convert.ToString(dt.Rows[index]["StimulationProtocol"]);
        txtLMP.Text = Convert.ToString(dt.Rows[index]["LastLMP"]);
        txtdate.Text = Convert.ToString( dt.Rows[index]["Date"]);
        txtcycleDay.Text = Convert.ToString(dt.Rows[index]["CycleDay"]);
         txtSimulation.Text=Convert.ToString(dt.Rows[index]["SimulationDay"]) ;
         txtRightovary.Text = Convert.ToString(dt.Rows[index]["RightOvary"]);


         txtLeftOvary.Text=Convert.ToString(dt.Rows[index]["LeftOvary"]);
         txtEndometrium.Text = Convert.ToString(dt.Rows[index]["Endometrium"]);
         txtplan.Text = Convert.ToString(dt.Rows[index]["Plan"]);
      txtRemarks.Text=  Convert.ToString(dt.Rows[index]["Remark"] );
       ViewState["IVFID"]=Convert.ToInt32(dt.Rows[index]["IVFID"]);
       ViewState["BillTable"] = dt;
       ViewState["Index"] = index;
        ViewState["Edit"] = "1";
        e.Cancel = true;
    }
    protected void gvBill_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        AddToGridView();
    }
    protected void btnreport_Click(object sender, EventArgs e)
    {
        string sql = "";
        Alter_view();
        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Report/Rpt_IVFFollicular.rpt");
        Session["reportname"] = "IVFFollicular";
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

        string query = "ALTER VIEW [dbo].[VW_GetIVFFollicular] AS (SELECT        PatientInformation.FirstName, PatientInformation.MiddleName, PatientInformation.LastName, Gender.GenderName, PatientInformation.BirthDate, PatientInformation.BloodGroup, PatientInformation.MaritalStatus, "+
                  "  PatientInformation.PhoneNo, PatientInformation.MobileNo, PatientInformation.PatientAddress, PatientInformation.Email, PatientInformation.Age, PatientInformation.AgeType, IVFFollicular.IVFID, IVFFollicular.Patregid, "+
                  "  IVFFollicular.OPDNo, IVFFollicular.IPDNo, IVFFollicular.LastLMP, IVFFollicular.StimulationProtocol, IVFFollicular.StimulationDate, IVFFollicular.CycleDay, IVFFollicular.SimulationDay, IVFFollicular.RightOvary, "+
                  "  IVFFollicular.LeftOvary, IVFFollicular.EndometriumMM, IVFFollicular.IVFPlan, IVFFollicular.Remarks, IVFFollicular.CreatedBy, IVFFollicular.CreatedOn, IVFFollicular.Branchid, IVFFollicular.Fid, IVFFollicular.UpdatedBy, "+
                  "  IVFFollicular.UpdatedOn "+
                  "  FROM            IVFFollicular INNER JOIN "+
                  "  PatientInformation ON IVFFollicular.Patregid = PatientInformation.PatRegId INNER JOIN "+
                  "  Gender ON PatientInformation.GenderId = Gender.GenderId " +
        " where IVFFollicular.Patregid=" + Convert.ToInt32(Session["EmrRegNo"]) + "  and  IVFFollicular.OPDNo=" + Convert.ToInt32(Session["EmrOpdNo"]) + " and  IVFFollicular.IPDNO=" + Convert.ToInt32(Session["EmrIpdNo"]) + " ";
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