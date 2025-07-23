using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class NICU_MonitorChart : System.Web.UI.Page
{
    clsEmr obj = new clsEmr();
    clsTreatment objTreat = new clsTreatment();
    clsTreatmentTransaction transaction = new clsTreatmentTransaction();
    BELIntakeOutputChart objBELIO = new BELIntakeOutputChart();
    DALInputOutPutChart objDALIO = new DALInputOutPutChart();
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
                int IpdId = Convert.ToInt32(Session["EmrIpdNo"]);
                objBELIO.FId = Convert.ToInt32(Session["FId"]);
                objBELIO.BranchId = Convert.ToInt32(Session["Branchid"]);
                SetInitialRow();
               // lblOpd.Text = opd;
               // DateTime time = DateTime.Now;
               // txttimestart.Text = DateTime.Now.ToString("dd/MM/yyyy");
               // String s = time.ToString("hh:mm tt");
               // txtTime.Text = s;               
                BindPatientInformation();
              //  txtNurse.Text = Convert.ToString(Session["Name"]);
                BindDailyNurseNotes();
               // txttimestart.Enabled = false;
               // txtTime.Enabled = false;
            }
        }
    }

    public void BindDailyNurseNotes()
    {
        DataTable dt = new DataTable();
        objBELIO.Patregid = Convert.ToInt32(Session["EmrRegNo"]);
        objBELIO.OpdNo = Convert.ToInt32(Session["EmrOpdNo"]);
        string entrydate = Request.QueryString["EntryDate"];
        objBELIO.IpdNo = Convert.ToInt32(Session["EmrIpdNo"]);
        objBELIO.FId = Convert.ToInt32(Session["FId"]);
        objBELIO.BranchId = Convert.ToInt32(Session["Branchid"]);
        dt = objDALIO.FillDailyNurseNote(objBELIO);
        //gvDailyNurseNote.DataSource = dt;
        //gvDailyNurseNote.DataBind();
    }
    public void BindPatientInformation()
    {
        //DataTable dt = new DataTable();
        //dt = obj.Get_AllPatientInformation(Convert.ToString(Session["EmrRegNo"]), Convert.ToString(Session["EmrOpdNo"]), Convert.ToInt32(Session["EmrIpdNo"]), Convert.ToInt32(Session["Branchid"]));
        //try
        //{
        //    if (dt != null)
        //    {
        //        lblPatientName.Text = Convert.ToString(dt.Rows[0]["PatientName"]);
        //        txtpatientregid.Text = Convert.ToString(dt.Rows[0]["PatRegId"]);
        //        lblIpd.Text = Convert.ToString(dt.Rows[0]["Ipdno"]);
        //        lblOpd.Text = Convert.ToString(dt.Rows[0]["Opdno"]);
        //        lblMobileNo.Text = Convert.ToString(dt.Rows[0]["MobileNo"]);
        //        lbldrname.Text = Convert.ToString(dt.Rows[0]["DrName"]);
        //        lblAge.Text = Convert.ToString(dt.Rows[0]["Age"]) + "" + Convert.ToString(dt.Rows[0]["AgeType"]) + "/" + Convert.ToString(dt.Rows[0]["GenderName"]);
        //        ViewState["Age"] = Convert.ToString(dt.Rows[0]["Age"]);
        //        ViewState["AgeType"] = Convert.ToString(dt.Rows[0]["AgeType"]);
        //        ViewState["DrId"] = Convert.ToString(dt.Rows[0]["DrId"]);

        //    }
        //    dt = new DataTable();
        //    dt = obj.Get_AllPatientVitalTaken(Convert.ToString(Session["EmrRegNo"]), Convert.ToString(Session["EmrOpdNo"]), Convert.ToInt32(Session["EmrIpdNo"]), Convert.ToInt32(Session["Branchid"]));
        //    if (dt.Rows.Count > 0)
        //    {
        //        lblvtaken.Text = Convert.ToString(dt.Rows[0]["CreatedOn"]);
        //    }
        //}
        //catch (Exception ex)
        //{

        //}
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        //if (validation() == true)
        //{

        if (Convert.ToString(Session["EmrOpdNo"]) != "")
        {
            objBELIO.OpdNo = Convert.ToInt32(Session["EmrOpdNo"]);
        }
        else
        {
            objBELIO.OpdNo = 0;
        }
        if (Convert.ToString(Session["EmrIpdNo"]) != "")
        {
            objBELIO.IpdNo = Convert.ToInt32(Session["EmrIpdNo"]);
        }
        else
        {
            objBELIO.IpdNo = 0;
        }
        objBELIO.Patregid = Convert.ToInt32(Session["EmrRegNo"]);
        objBELIO.CreatedBy = Convert.ToString(Session["username"]);
        objBELIO.UpdatedBy = Convert.ToString(Session["username"]);
        objBELIO.FId = Convert.ToInt32(Session["FId"]); ;
        objBELIO.BranchId = Convert.ToInt32(Session["Branchid"]);
        objBELIO.DrId = Convert.ToInt32(ViewState["DrId"]);
        //objBELIO.DateInput = Convert.ToDateTime(txttimestart.Text);
        //objBELIO.TimeInput = Convert.ToString(txtTime.Text);
        //objBELIO.Remark = Convert.ToString(txtRemark.InnerText);
        objBELIO.UserId = Convert.ToInt32(Session["UserId"]);
       
        string Msg;
        if (Convert.ToInt32(ViewState["NurseNoteId"]) > 0)
        {
            objBELIO.NurseNoteId = Convert.ToInt32(ViewState["NurseNoteId"]);
            Msg = objDALIO.UpdateDailyNurseNote(objBELIO);
            ViewState["NurseNoteId"] = "0";
        }
        else
        {
            Msg = objDALIO.InsertDailyNurseNote(objBELIO);
        }
       
        BindDailyNurseNotes();

        //txtRemark.InnerText = "";
        //DateTime time = DateTime.Now;
        //txttimestart.Text = DateTime.Now.ToString("dd/MM/yyyy");
        //String s = time.ToString("hh:mm tt");
        //txtTime.Text = s;           
        LblMSg.Text = Msg;
        LblMSg.ForeColor = System.Drawing.Color.Green;



        //}
        //}
    }
   
    public void FillPage()
    {
        objBELIO = objDALIO.SelectDailyNurseNote(Convert.ToInt32(ViewState["NurseNoteId"]));
        //txttimestart.Text = Convert.ToDateTime(objBELIO.DateInput).ToString("dd/MM/yyyy");
        //txtTime.Text = Convert.ToString(objBELIO.TimeInput);
        //txtRemark.InnerText = objBELIO.Remark;
        //txtNurse.Text = objBELIO.UserName;
        int UserId = Convert.ToInt32(objBELIO.UserId);

    }

  
    protected void btnReset_Click(object sender, EventArgs e)
    {
        //txtRemark.InnerText = "";
        //DateTime time = DateTime.Now;
        //txttimestart.Text = DateTime.Now.ToString("dd/MM/yyyy");
        //String s = time.ToString("hh:mm tt");
        //txtTime.Text = s;         
    }
    protected void btnReport_Click(object sender, EventArgs e)
    {
        string sql = "";
        if (Convert.ToString(Session["EmrOpdNo"]) != "")
        {
            objBELIO.OpdNo = Convert.ToInt32(Session["EmrOpdNo"]);
        }
        else
        {
            objBELIO.OpdNo = 0;
        }
        if (Convert.ToString(Session["EmrIpdNo"]) != "")
        {
            objBELIO.IpdNo = Convert.ToInt32(Session["EmrIpdNo"]);
        }
        else
        {
            objBELIO.IpdNo = 0;
        }
        objBELIO.Patregid = Convert.ToInt32(Session["EmrRegNo"]);
        objDALIO.Alter_Vw_DailyNurseNote(objBELIO);
        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Report/Rpt_DailyNurseNotes.rpt");
        Session["reportname"] = "Rpt_DailyNurseNotes";
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

        dt.Columns.Add(new DataColumn("Time", typeof(string)));
        dt.Columns.Add(new DataColumn("Temp", typeof(string)));
        dt.Columns.Add(new DataColumn("HR", typeof(string)));

        dt.Columns.Add(new DataColumn("RR", typeof(string)));
        dt.Columns.Add(new DataColumn("BP", typeof(string)));
        dt.Columns.Add(new DataColumn("BSL", typeof(string)));

        dt.Columns.Add(new DataColumn("SpO2", typeof(string)));
        dt.Columns.Add(new DataColumn("AG", typeof(string)));
        dt.Columns.Add(new DataColumn("IntakePO", typeof(string)));

        dt.Columns.Add(new DataColumn("IntakeIV", typeof(string)));
        dt.Columns.Add(new DataColumn("Urine", typeof(string)));
        dt.Columns.Add(new DataColumn("Stool", typeof(string)));
        dt.Columns.Add(new DataColumn("Remark", typeof(string)));

        dr = dt.NewRow();

        dr["RowNumber"] = 1;

        dr["Time"] = string.Empty;
        dr["Temp"] = string.Empty;
        dr["HR"] = string.Empty;

        dr["RR"] = string.Empty;
        dr["BP"] = string.Empty;
        dr["BSL"] = string.Empty;

        dr["SpO2"] = string.Empty;
        dr["AG"] = string.Empty;
        dr["IntakePO"] = string.Empty;

        dr["IntakeIV"] = string.Empty;
        dr["Urine"] = string.Empty;
        dr["Stool"] = string.Empty;
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

                    TextBox box1 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[1].FindControl("txtTime");
                    TextBox box2 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[2].FindControl("txtTemp");
                    TextBox box3 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[3].FindControl("txtHR");

                    TextBox box4 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[4].FindControl("txtRR");
                    TextBox box5 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[5].FindControl("txtBP");
                    TextBox box6 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[6].FindControl("txtBSL");

                    TextBox box7 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[7].FindControl("txtSpO2");
                    TextBox box8 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[8].FindControl("txtAG");
                    TextBox box9 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[9].FindControl("txtIntakePO");

                    TextBox box10 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[10].FindControl("txtIntakeIV");
                    TextBox box11 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[11].FindControl("txtUrine");
                    TextBox box12 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[12].FindControl("txtStool");
                    TextBox box13 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[13].FindControl("txtRemark");



                    drCurrentRow = dtCurrentTable.NewRow();

                    drCurrentRow["RowNumber"] = i + 1;

                    dtCurrentTable.Rows[i - 1]["Time"] = box1.Text;
                    dtCurrentTable.Rows[i - 1]["Temp"] = box2.Text;
                    dtCurrentTable.Rows[i - 1]["HR"] = box3.Text;
                    dtCurrentTable.Rows[i - 1]["RR"] = box4.Text;

                    dtCurrentTable.Rows[i - 1]["BP"] = box5.Text;
                    dtCurrentTable.Rows[i - 1]["BSL"] = box6.Text;
                    dtCurrentTable.Rows[i - 1]["SpO2"] = box7.Text;
                    dtCurrentTable.Rows[i - 1]["AG"] = box8.Text;

                    dtCurrentTable.Rows[i - 1]["IntakePO"] = box9.Text;
                    dtCurrentTable.Rows[i - 1]["IntakeIV"] = box10.Text;
                    dtCurrentTable.Rows[i - 1]["Urine"] = box11.Text;
                    dtCurrentTable.Rows[i - 1]["Stool"] = box12.Text;
                    dtCurrentTable.Rows[i - 1]["Remark"] = box13.Text;



                    rowIndex++;

                }

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
                                       
                    TextBox box1 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[1].FindControl("txtTime");
                    TextBox box2 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[2].FindControl("txtTemp");
                    TextBox box3 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[3].FindControl("txtHR");

                    TextBox box4 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[4].FindControl("txtRR");
                    TextBox box5 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[5].FindControl("txtBP");
                    TextBox box6 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[6].FindControl("txtBSL");

                    TextBox box7 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[7].FindControl("txtSpO2");
                    TextBox box8 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[8].FindControl("txtAG");
                    TextBox box9 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[9].FindControl("txtIntakePO");

                    TextBox box10 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[10].FindControl("txtIntakeIV");
                    TextBox box11 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[11].FindControl("txtUrine");
                    TextBox box12 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[12].FindControl("txtStool");
                    TextBox box13 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[13].FindControl("txtRemark");

                    box1.Text = dt.Rows[i]["Time"].ToString();
                    box2.Text = dt.Rows[i]["Temp"].ToString();
                    box3.Text = dt.Rows[i]["HR"].ToString();
                    box4.Text = dt.Rows[i]["RR"].ToString();

                    box5.Text = dt.Rows[i]["BP"].ToString();
                    box6.Text = dt.Rows[i]["BSL"].ToString();
                    box7.Text = dt.Rows[i]["SpO2"].ToString();
                    box8.Text = dt.Rows[i]["AG"].ToString();

                    box9.Text = dt.Rows[i]["IntakePO"].ToString();
                    box10.Text = dt.Rows[i]["IntakeIV"].ToString();
                    box11.Text = dt.Rows[i]["Urine"].ToString();
                    box12.Text = dt.Rows[i]["Stool"].ToString();
                    box13.Text = dt.Rows[i]["Remark"].ToString();


                    rowIndex++;

                }

            }

        }

    }
}