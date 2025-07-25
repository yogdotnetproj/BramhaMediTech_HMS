using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Investigation_Record :BasePage
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
        dt = objDALIO.Fill_Investigation_Record(objBELIO);
        gvDailyNurseNote.DataSource = dt;
        gvDailyNurseNote.DataBind();
    }
    public void BindPatientInformation()
    {
        
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        //if (validation() == true)
        //{
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
                TextBox box3 = (TextBox)GvHairLaser.Rows[i].Cells[3].FindControl("txtInvestigation");
                TextBox box4 = (TextBox)GvHairLaser.Rows[i].Cells[4].FindControl("txtCost");
                TextBox box5 = (TextBox)GvHairLaser.Rows[i].Cells[5].FindControl("txtCreatedBy");
                TextBox box6 = (TextBox)GvHairLaser.Rows[i].Cells[6].FindControl("txtRemark");
             

                objBELIO.BDate = box1.Text;
                objBELIO.BTime = box2.Text;
                objBELIO.Investigation = box3.Text;
                objBELIO.Cost = box4.Text;
                objBELIO.CreatedBy = box5.Text;
                objBELIO.Remark = box6.Text;


                Msg = objDALIO.InsertInvestigation_Record(objBELIO);
            }
           
           
        }
       
        BindDailyNurseNotes();

        //txtRemark.InnerText = "";
        //DateTime time = DateTime.Now;
        //txttimestart.Text = DateTime.Now.ToString("dd/MM/yyyy");
        //String s = time.ToString("hh:mm tt");
        //txtTime.Text = s;           
        LblMSg.Text = "Record Save Successfully";
        LblMSg.ForeColor = System.Drawing.Color.Green;



        //}
        //}
    }
    protected void gvDailyNurseNote_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string Id = (gvDailyNurseNote.DataKeys[e.RowIndex]["Id"].ToString());


        string Message = objDALIO.Delete_Investigation_Record(Convert.ToInt32(Id));
        LblMSg.Text = Message;
        LblMSg.ForeColor = System.Drawing.Color.Green;
        BindDailyNurseNotes();


    }
    protected void gvDailyNurseNote_RowEditing(object sender, GridViewEditEventArgs e)
    {
        
        try
        {
            string Id = (gvDailyNurseNote.DataKeys[e.NewEditIndex]["Id"].ToString());
            ViewState["Id"] = Id;
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

        dt.Columns.Add(new DataColumn("Date", typeof(string)));
        dt.Columns.Add(new DataColumn("Time", typeof(string)));
        dt.Columns.Add(new DataColumn("Investigation", typeof(string)));
        dt.Columns.Add(new DataColumn("Cost", typeof(string)));

        dt.Columns.Add(new DataColumn("CreatedBy", typeof(string)));
        dt.Columns.Add(new DataColumn("Remarks", typeof(string)));
      

        dr = dt.NewRow();
        DateTime time = DateTime.Now;        
        String s = time.ToString("hh:mm tt");
        //txtTime.Text = s;    

        dr["RowNumber"] = 1;

        dr["Date"] = DateTime.Now.ToString("dd/MM/yyyy"); ;
        dr["Time"] = s;
        dr["Investigation"] = string.Empty;
        dr["Cost"] = string.Empty;
        dr["CreatedBy"] = Convert.ToString(Session["username"]); ;
        dr["Remarks"] = string.Empty;     

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
                    TextBox box3 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[3].FindControl("txtInvestigation");
                    TextBox box4 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[4].FindControl("txtCost");

                    TextBox box5 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[5].FindControl("txtCreatedBy");
                    TextBox box6 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[6].FindControl("txtRemark");
                  

                    box1.Text = DateTime.Now.ToString("dd/MM/yyyy");

                    drCurrentRow = dtCurrentTable.NewRow();

                    drCurrentRow["RowNumber"] = i + 1;



                    dtCurrentTable.Rows[i - 1]["Date"] = box1.Text; 
                    dtCurrentTable.Rows[i - 1]["Time"] = box2.Text;
                    dtCurrentTable.Rows[i - 1]["Investigation"] = box3.Text;
                    dtCurrentTable.Rows[i - 1]["Cost"] = box4.Text;

                    dtCurrentTable.Rows[i - 1]["CreatedBy"] = box5.Text;
                    dtCurrentTable.Rows[i - 1]["Remarks"] = box6.Text;                  

                     rowIndex++;

                }

                drCurrentRow["RowNumber"] = rowIndex;
                DateTime time = DateTime.Now;
                String s = time.ToString("hh:mm tt");

                drCurrentRow["Date"] = DateTime.Now.ToString("dd/MM/yyyy"); ;
                drCurrentRow["Time"] = s;
                drCurrentRow["Investigation"] = string.Empty;
                drCurrentRow["Cost"] = string.Empty;

                drCurrentRow["CreatedBy"] = Convert.ToString(Session["username"]);
                drCurrentRow["Remarks"] = string.Empty;               


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
                    TextBox box3 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[3].FindControl("txtInvestigation");
                    TextBox box4 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[4].FindControl("txtCost");

                    TextBox box5 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[5].FindControl("txtCreatedBy");
                    TextBox box6 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[6].FindControl("txtRemark");
                   

                    box1.Text = dt.Rows[i]["Date"].ToString();
                    box2.Text = dt.Rows[i]["Time"].ToString();
                    box3.Text = dt.Rows[i]["Investigation"].ToString();
                    box4.Text = dt.Rows[i]["Cost"].ToString();

                    box5.Text = dt.Rows[i]["CreatedBy"].ToString();
                    box6.Text = dt.Rows[i]["Remarks"].ToString();
                   


                    rowIndex++;

                }

            }

        }

    }
    protected void gvDailyNurseNote_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Report")
        {

            //Determine the RowIndex of the Row whose Button was clicked.
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            //Reference the GridView Row.
            GridViewRow row = gvDailyNurseNote.Rows[rowIndex];
            objBELIO.Id = Convert.ToInt32(gvDailyNurseNote.DataKeys[rowIndex].Values["Id"]);
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
            objDALIO.Alter_InvestigationList_Report(objBELIO);
            Session.Add("rptsql", sql);
            Session["rptname"] = Server.MapPath("~/Report/Rpt_NurseShiftReport.rpt");
            Session["reportname"] = "Investigation_Record";
            Session["RPTFORMAT"] = "pdf";

            //ReportParameterClass.SelectionFormula = sql;
            string close = "<script language='javascript'>javascript:OpenReport();</script>";
            Type title1 = this.GetType();
            Page.ClientScript.RegisterStartupScript(title1, "", close);

        }
    }
}