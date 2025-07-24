using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class TwoHourlyRepositioningTurningChart : BasePage
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
            if (Convert.ToString(Session["Branchid"]) == "")
            {
                Response.Redirect("~/Login.aspx", false);
                return;
            }
            if (Convert.ToString(Session["Branchid"]) == "0")
            {
                Response.Redirect("~/Login.aspx", false);
                return;
            }
            if (Convert.ToString(Session["Branchid"]) == null)
            {
                Response.Redirect("~/Login.aspx", false);
                return;
            }
            if (Session["EmrRegNo"] != "")
            {
                DateTime time1 = DateTime.Now;
                txtRegistrationDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                String s = time1.ToString("hh:mm tt");
                txtTime.Text = s;
                string regId = Convert.ToString(Session["EmrRegNo"]);
                string name = Request.QueryString["Name"];
                string opd = Convert.ToString(Session["EmrOpdNo"]);
                string entrydate = Request.QueryString["EntryDate"];
                int IpdId = Convert.ToInt32(Session["EmrIpdNo"]);
                objBELIO.FId = Convert.ToInt32(Session["FId"]);
                objBELIO.BranchId = Convert.ToInt32(Session["Branchid"]);
                SetInitialRow();
               // lblOpd.Text = opd;
                DateTime time = DateTime.Now;
              //  txttimestart.Text = DateTime.Now.ToString("dd/MM/yyyy");
                //String s = time.ToString("hh:mm tt");
                //txtTime.Text = s;               
                BindPatientInformation();
               // txtNurse.Text = Convert.ToString(Session["Name"]);
                BindDailyNurseNotes();
              //  txttimestart.Enabled = false;
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
        dt = objDALIO.Fill_TwoWayRepositoryChart(objBELIO);
        gvDailyNurseNote.DataSource = dt;
        gvDailyNurseNote.DataBind();
    }
    public void BindPatientInformation()
    {
        
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["Branchid"]) == "")
        {
            Response.Redirect("~/Login.aspx", false);
            return;
        }
        if (Convert.ToString(Session["Branchid"]) == "0")
        {
            Response.Redirect("~/Login.aspx", false);
            return;
        }
        if (Convert.ToString(Session["Branchid"]) == null)
        {
            Response.Redirect("~/Login.aspx", false);
            return;
        }
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
            if (Convert.ToString(Session["PatAdmit"]) == "No")
            {
                LblMSg.ForeColor = System.Drawing.Color.Red;
                LblMSg.Text = "Patient already discharge!";
                return;
            }
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
        //objBELIO.DrId = Convert.ToInt32(ViewState["DrId"]);
        //objBELIO.DateInput = Convert.ToDateTime(txttimestart.Text);
        //objBELIO.TimeInput = Convert.ToString(txtTime.Text);
        //objBELIO.Remark = Convert.ToString(txtRemark.InnerText);
        objBELIO.UserId = Convert.ToInt32(Session["UserId"]);

        //objBELIO.BloodSugarOrder = Convert.ToString(txtBloodSugar.Text);
        if (ChkPressure.Checked == true)
        {
            objBELIO.PressureRelieving = true;
        }
        else
        {
            objBELIO.PressureRelieving = true;
        }
        if (ChkCushion.Checked == true)
        {
            objBELIO.Cushion = true;
        }
        else
        {
            objBELIO.Cushion = true;
        }

        if (ChkHeelPads.Checked == true)
        {
            objBELIO.HeelPads = true;
        }
        else
        {
            objBELIO.HeelPads = true;
        }

        if (ChkYes.Checked == true)
        {
            objBELIO.DiscussWithPat = true;
        }
        else
        {
            objBELIO.DiscussWithPat = false;
        }

        if (ChkRYes.Checked == true)
        {
            objBELIO.DiscussWithRelative = true;
        }
        else
        {
            objBELIO.DiscussWithRelative = false;
        }
        objBELIO.DiscussWithPat_Remark = txtPatientRemark.Text;
        objBELIO.DiscussWithRelative_Remark = txtrelativeRemark.Text; 

        objBELIO.EntryDate = Convert.ToDateTime( txtRegistrationDate.Text);
        objBELIO.EnterTime = Convert.ToString(txtTime.Text);
        string Msg;
        if (Convert.ToInt32(ViewState["Id"]) > 0)
        {
            objBELIO.NurseNoteId = Convert.ToInt32(ViewState["Id"]);
            // Msg = objDALIO.UpdateDailyNurseNote(objBELIO);
            ViewState["Id"] = "0";
        }
        else
        {

            for (int i = 0; i < GvHairLaser.Rows.Count; i++)
            {

                //extract the TextBox values

                TextBox box1 = (TextBox)GvHairLaser.Rows[i].Cells[1].FindControl("txtDate");
                TextBox box2 = (TextBox)GvHairLaser.Rows[i].Cells[2].FindControl("txtTime");
                TextBox box3 = (TextBox)GvHairLaser.Rows[i].Cells[3].FindControl("txtLeftSide");
                TextBox box4 = (TextBox)GvHairLaser.Rows[i].Cells[4].FindControl("txtRightSide");
                TextBox box5 = (TextBox)GvHairLaser.Rows[i].Cells[5].FindControl("txtSupine");
                TextBox box6 = (TextBox)GvHairLaser.Rows[i].Cells[6].FindControl("txtHeadTilt");

                TextBox box7 = (TextBox)GvHairLaser.Rows[i].Cells[7].FindControl("txtInChair");
                TextBox box8 = (TextBox)GvHairLaser.Rows[i].Cells[8].FindControl("txtSkinIntegrityObserved");
                TextBox box9 = (TextBox)GvHairLaser.Rows[i].Cells[9].FindControl("txtComments");


                objBELIO.BDate = box1.Text;
                objBELIO.BTime = box2.Text;
                objBELIO.LeftSide = box3.Text;
                objBELIO.RightSide = box4.Text;

                objBELIO.Supine = box5.Text;
                objBELIO.HeadTilt = box6.Text;
                objBELIO.InChari = box7.Text;
                objBELIO.SkinIntegrity = box8.Text;
                objBELIO.Remark = box9.Text;





                Msg = objDALIO.Insert_TwoHourlyTurningChart(objBELIO);
            }


        }
       
        BindDailyNurseNotes();

        //txtRemark.InnerText = "";
        //DateTime time = DateTime.Now;
        //txttimestart.Text = DateTime.Now.ToString("dd/MM/yyyy");
        //String s = time.ToString("hh:mm tt");
        //txtTime.Text = s;           
        LblMSg.Text = "Record save successfully!";
        LblMSg.ForeColor = System.Drawing.Color.Green;



        //}
        //}
    }
    protected void gvDailyNurseNote_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string NurseNoteId = (gvDailyNurseNote.DataKeys[e.RowIndex]["NurseNoteId"].ToString());


        string Message = objDALIO.DeleteDailyNurseNote(Convert.ToInt32(NurseNoteId));
        LblMSg.Text = Message;
        LblMSg.ForeColor = System.Drawing.Color.Green;
        BindDailyNurseNotes();


    }
    protected void gvDailyNurseNote_RowEditing(object sender, GridViewEditEventArgs e)
    {
        
        try
        {
            string NurseNoteId = (gvDailyNurseNote.DataKeys[e.NewEditIndex]["NurseNoteId"].ToString());
            ViewState["NurseNoteId"] = NurseNoteId;
            FillPage();
            e.Cancel = true;
        }
        catch (Exception ex)
        {
            LblMSg.Text = ex.Message;
        }
    }

    public void FillPage()
    {
        //objBELIO = objDALIO.SelectDailyNurseNote(Convert.ToInt32(ViewState["NurseNoteId"]));
        //txttimestart.Text = Convert.ToDateTime(objBELIO.DateInput).ToString("dd/MM/yyyy");
        //txtTime.Text = Convert.ToString(objBELIO.TimeInput);
        //txtRemark.InnerText = objBELIO.Remark;
        //txtNurse.Text = objBELIO.UserName;
        //int UserId = Convert.ToInt32(objBELIO.UserId);

    }

    protected void gvDailyNurseNote_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDailyNurseNote.PageIndex = e.NewPageIndex;
        BindDailyNurseNotes();
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
        objDALIO.Alter_TwoWayRepositoryChart(objBELIO);
        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Report/Rpt_TwoHourlyRepositiory.rpt");
        Session["reportname"] = "TwoHourlyRepositiory";
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

        dt.Columns.Add(new DataColumn("Date", typeof(string)));
        dt.Columns.Add(new DataColumn("Time", typeof(string)));
        dt.Columns.Add(new DataColumn("LeftSide", typeof(string)));
        dt.Columns.Add(new DataColumn("RightSide", typeof(string)));

        dt.Columns.Add(new DataColumn("Supine", typeof(string)));
        dt.Columns.Add(new DataColumn("HeadTilt", typeof(string)));
        dt.Columns.Add(new DataColumn("InChair", typeof(string)));
        dt.Columns.Add(new DataColumn("SkinIntegrityObserved", typeof(string)));
        dt.Columns.Add(new DataColumn("Comments", typeof(string)));





        dr = dt.NewRow();
        DateTime time = DateTime.Now;        
        String s = time.ToString("hh:mm tt");
        //txtTime.Text = s;    

        dr["RowNumber"] = 1;

        dr["Date"] = DateTime.Now.ToString("dd/MM/yyyy"); ;
        dr["Time"] = s;
        dr["LeftSide"] = string.Empty;
        dr["RightSide"] = string.Empty;

        dr["Supine"] = string.Empty;
        dr["HeadTilt"] = string.Empty;
        dr["InChair"] = string.Empty;
        dr["SkinIntegrityObserved"] = string.Empty;
        dr["Comments"] = string.Empty;


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

                    TextBox box1 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[1].FindControl("txtDate");// = DateTime.Now.ToString("dd/MM/yyyy"); ;
                    TextBox box2 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[2].FindControl("txtTime");
                    TextBox box3 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[3].FindControl("txtLeftSide");
                    TextBox box4 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[4].FindControl("txtRightSide");

                    TextBox box5 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[5].FindControl("txtSupine");
                    TextBox box6 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[6].FindControl("txtHeadTilt");
                    TextBox box7 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[7].FindControl("txtInChair");
                    TextBox box8 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[8].FindControl("txtSkinIntegrityObserved");
                    TextBox box9 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[9].FindControl("txtComments");

                    box1.Text = DateTime.Now.ToString("dd/MM/yyyy");

                    drCurrentRow = dtCurrentTable.NewRow();

                    drCurrentRow["RowNumber"] = i + 1;



                    dtCurrentTable.Rows[i - 1]["Date"] = box1.Text; ; ;
                    dtCurrentTable.Rows[i - 1]["Time"] = box2.Text;
                    dtCurrentTable.Rows[i - 1]["LeftSide"] = box3.Text;
                    dtCurrentTable.Rows[i - 1]["RightSide"] = box4.Text;

                    dtCurrentTable.Rows[i - 1]["Supine"] = box5.Text;
                    dtCurrentTable.Rows[i - 1]["HeadTilt"] = box6.Text;
                    dtCurrentTable.Rows[i - 1]["InChair"] = box7.Text;
                    dtCurrentTable.Rows[i - 1]["SkinIntegrityObserved"] = box8.Text;
                    dtCurrentTable.Rows[i - 1]["Comments"] = box9.Text;


                    rowIndex++;

                }

                drCurrentRow["RowNumber"] = rowIndex;
                DateTime time = DateTime.Now;
                String s = time.ToString("hh:mm tt");

                drCurrentRow["Date"] = DateTime.Now.ToString("dd/MM/yyyy"); ;
                drCurrentRow["Time"] = s;
                drCurrentRow["LeftSide"] = string.Empty;
                drCurrentRow["RightSide"] = string.Empty;

                drCurrentRow["Supine"] = string.Empty;
                drCurrentRow["HeadTilt"] = string.Empty;
                drCurrentRow["InChair"] = string.Empty;
                drCurrentRow["SkinIntegrityObserved"] = string.Empty;
                drCurrentRow["Comments"] = string.Empty;


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

                  

                    TextBox box1 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[1].FindControl("txtDate");
                    TextBox box2 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[2].FindControl("txtTime");
                    TextBox box3 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[3].FindControl("txtLeftSide");
                    TextBox box4 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[4].FindControl("txtRightSide");

                    TextBox box5 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[5].FindControl("txtSupine");
                    TextBox box6 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[6].FindControl("txtHeadTilt");
                    TextBox box7 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[7].FindControl("txtInChair");
                    TextBox box8 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[8].FindControl("txtSkinIntegrityObserved");
                    TextBox box9 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[9].FindControl("txtComments");

                    box1.Text = dt.Rows[i]["Date"].ToString();
                    box2.Text = dt.Rows[i]["Time"].ToString();
                    box3.Text = dt.Rows[i]["LeftSide"].ToString();
                    box4.Text = dt.Rows[i]["RightSide"].ToString();

                    box5.Text = dt.Rows[i]["Supine"].ToString();
                    box6.Text = dt.Rows[i]["HeadTilt"].ToString();
                    box7.Text = dt.Rows[i]["InChair"].ToString();
                    box8.Text = dt.Rows[i]["SkinIntegrityObserved"].ToString();
                    box9.Text = dt.Rows[i]["Comments"].ToString();


                    rowIndex++;

                }

            }

        }

    }
}