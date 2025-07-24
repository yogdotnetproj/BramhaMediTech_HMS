using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class IPDPatientTreatmentSheet : BasePage
{
    clsEmr obj = new clsEmr();
    clsTreatment objTreat = new clsTreatment();
    clsTreatmentTransaction transaction = new clsTreatmentTransaction();
    BELIntakeOutputChart objBELIO = new BELIntakeOutputChart();
    DALInputOutPutChart objDALIO = new DALInputOutPutChart();
    protected void Page_PreInit(object sender, EventArgs e)
    {
        try
        {
           // FormType=Nurse
            if (Convert.ToString(Request.QueryString["FormType"]) == "Nurse")
            {
                Session["UID"]="Drug";
                this.Page.MasterPageFile = "~/Hospital.master";
            }
            else
                this.Page.MasterPageFile = "~/mainMaster.master";

        }
        catch (Exception ex)
        {

        }
    }
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
                //lblOpd.Text = opd;
                DateTime time = DateTime.Now;
                txttimestart.Text = DateTime.Now.ToString("dd/MM/yyyy");
                String s = time.ToString("hh:mm tt");
                txtTime.Text = s;
                BindPatientInformation();
                txtNurse.Text = Convert.ToString(Session["Name"]);
                BindDailyNurseNotes();
                txttimestart.Enabled = false;
               // txtTime.Enabled = false;
                BindTreamentGrid(Convert.ToInt32( regId), Convert.ToInt32( opd), IpdId);
            }
        }
    }
    [WebMethod]
    public static List<string> GetDrugsName(string prefixText)
    {
        clsTreatment objj = new clsTreatment();

        string Type = Convert.ToString(HttpContext.Current.Session["UID"]);
        int DrId = Convert.ToInt32(HttpContext.Current.Session["DrId"]);

        DataTable dt = objj.GetDrugsMaster(prefixText, Type, DrId);
        List<string> list = new List<string>();

        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["ItemName"] != DBNull.Value)
                    {
                        list.Add(Convert.ToString(dt.Rows[i]["ItemName"]));
                    }
                }
            }
        }

        return list;
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
        //if (Request.QueryString["OpdNo"] != null)
        //{
        //    dt = objDALIO.FillPatTreatmentSheet_OPDEMER(objBELIO);
        //}
        //else
        //{
            dt = objDALIO.FillPatTreatmentSheet(objBELIO);
        //}
        gvDailyNurseNote.DataSource = dt;
        gvDailyNurseNote.DataBind();
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
        objBELIO.DrId = Convert.ToInt32(ViewState["DrId"]);
        objBELIO.DateInput = Convert.ToDateTime(txttimestart.Text);
        objBELIO.TimeInput = Convert.ToString(txtTime.Text);
        objBELIO.Remark = Convert.ToString(txtRemark.InnerText);
        objBELIO.UserId = Convert.ToInt32(Session["UserId"]);
        objBELIO.DrugId = Convert.ToInt32(ViewState["DrugId"]);
        objBELIO.DrugName = Convert.ToString(txtDrugName.Text);
        objBELIO.Qty = Convert.ToString(txtQty.Text);
        objBELIO.Routess = Convert.ToString(txtRoute.Text);

        string Msg;
        if (Convert.ToInt32(ViewState["PatTreatmentId"]) > 0)
        {
            objBELIO.PatTreatmentId = Convert.ToInt32(ViewState["PatTreatmentId"]);
            Msg = objDALIO.UpdatePatTreatmentSheet(objBELIO);
            ViewState["PatTreatmentId"] = "0";
        }
        else
        {
            Msg = objDALIO.InsertPatTreatmentSheet(objBELIO);
        }

       
        BindDailyNurseNotes();

        btnReset_Click(null,null);
        txtRemark.InnerText = "";
        DateTime time = DateTime.Now;
        txttimestart.Text = DateTime.Now.ToString("dd/MM/yyyy");
        String s = time.ToString("hh:mm tt");
        txtTime.Text = s;
        LblMSg.Text = Msg;
        LblMSg.ForeColor = System.Drawing.Color.Green;



        //}
        //}
    }
    protected void gvDailyNurseNote_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string PatTreatmentId = (gvDailyNurseNote.DataKeys[e.RowIndex]["PatTreatmentId"].ToString());


        string Message = objDALIO.DeletePatTreatmentSheet(Convert.ToInt32(PatTreatmentId));
        LblMSg.Text = Message;
        LblMSg.ForeColor = System.Drawing.Color.Green;
        BindDailyNurseNotes();


    }
    protected void gvDailyNurseNote_RowEditing(object sender, GridViewEditEventArgs e)
    {

        try
        {
            string PatTreatmentId = (gvDailyNurseNote.DataKeys[e.NewEditIndex]["PatTreatmentId"].ToString());
            ViewState["PatTreatmentId"] = PatTreatmentId;
            txttimestart.Enabled = false;
            txtTime.Enabled = false;
            FillPage1();
            e.Cancel = true;
        }
        catch (Exception ex)
        {
            LblMSg.Text = ex.Message;
        }
    }

    public void FillPage()
    {
        objBELIO = objDALIO.SelectPatTreatmentSheet(Convert.ToInt32(ViewState["PatTreatmentId"]));
        txttimestart.Text = Convert.ToDateTime(objBELIO.DateInput).ToString("dd/MM/yyyy");
        txtTime.Text = Convert.ToString(objBELIO.TimeInput);
        txtRemark.InnerText = objBELIO.Remark;
        txtNurse.Text = objBELIO.UserName;
        int UserId = Convert.ToInt32(objBELIO.UserId);
        txtQty.Text = Convert.ToString(objBELIO.Qty);
        txtDrugName.Text = Convert.ToString(objBELIO.DrugName);
        ViewState["DrugId"] = Convert.ToInt32(objBELIO.DrugId);

    }

    protected void gvDailyNurseNote_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDailyNurseNote.PageIndex = e.NewPageIndex;
        BindDailyNurseNotes();
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtRemark.InnerText = "";
        DateTime time = DateTime.Now;
        txttimestart.Text = DateTime.Now.ToString("dd/MM/yyyy");
        String s = time.ToString("hh:mm tt");
        txtTime.Text = s;
        txtQty.Text = "0";
        txtDrugName.Text = "";
        ViewState["DrugId"] = "0";
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
        objDALIO.Alter_Vw_PatTreatmentSheet(objBELIO);
        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Report/Rpt_PatTreatmentSheet.rpt");
        Session["reportname"] = "Rpt_PatTreatmentSheet";
        Session["RPTFORMAT"] = "pdf";

        //ReportParameterClass.SelectionFormula = sql;
        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);
    }
    protected void txtDrugName_TextChanged(object sender, EventArgs e)
    {
        if (txtDrugName.Text != "")
        {
            string[] Item = txtDrugName.Text.Split('=');
            if (txtDrugName.Text.Split('=').Length < 2)
            {
                ViewState["ItemId"] = "0";
            }
            else
            {
                txtDrugName.Text = Item[1];
                ViewState["ItemId"] = Item[0];
            }
        }
        else
        {
            ViewState["ItemId"] = "0";
        }
    }
    protected void GvNoteIngrid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
    }
    protected void GvNoteIngrid_DataBound(object sender, EventArgs e)
    {
    }
    protected void GvNoteIngrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        clsTreatmentTransaction Obj = new clsTreatmentTransaction();
        int TransId = Convert.ToInt32(GvNoteIngrid.DataKeys[e.RowIndex].Values["TransId"].ToString());

       // Obj.DeleteDrugTransaction(TransId);
       // lblMsg.Text = "Record Deleted Successfully!!";
        //BindTreamentGrid(Convert.ToInt32(Session["EmrRegNo"]), Convert.ToInt32(lblOpd.Text), Convert.ToInt32(lblIpd.Text));
       
    }
    protected void GvNoteIngrid_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {


            string TransId = (GvNoteIngrid.DataKeys[e.NewEditIndex]["TransId"].ToString());
            ViewState["TransId"] = TransId;
            //ViewState["PatTreatmentId"] = TransId;
            FillPage1();
            e.Cancel = true;
        }
        catch (Exception ex)
        {
           // lblMsg.Text = ex.Message;
        }
    }
    protected void IsChkRefill_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox BtnApprove = (CheckBox)sender;
        GridViewRow row1 = (GridViewRow)BtnApprove.NamingContainer;
        int IndReqDeptId = Convert.ToInt32(GvNoteIngrid.DataKeys[row1.RowIndex]["TreatmentId"].ToString());

        //dt = new DataTable();
        //dt = obj.Get_RefillTreatment(Convert.ToString(Session["EmrRegNo"]), Convert.ToString(IndReqDeptId), 0, Convert.ToInt32(Session["Branchid"]));
        //if (dt.Rows.Count > 0)
        //{
        //    for (int P = 0; P < dt.Rows.Count; P++)
        //    {
        //        // ItemId = Convert.ToInt32(dt.Rows[i]["ItemId"]);
        //        try
        //        {
        //            string drugname = Convert.ToString(dt.Rows[P]["DrugNameA"]);
        //            string freq = Convert.ToString(dt.Rows[P]["FrequencyType"]);
        //            int days = Convert.ToInt32(dt.Rows[P]["Days"]);
        //            string startDate = txtStart.Text.ToString();
        //            AddDay(days);
        //            string endDate = txtEnd.Text.ToString();
        //            string note = Convert.ToString(dt.Rows[P]["Note"]); ;
        //            string Dose = Convert.ToString(dt.Rows[P]["Dose"]);
        //            int DoseId = Convert.ToInt32(dt.Rows[P]["DoseId"]);
        //            int DoseTimeId = Convert.ToInt32(dt.Rows[P]["DoseTimeId"]);
        //            int ItemId = Convert.ToInt32(dt.Rows[P]["ItemId"]);
        //            float Qty = Convert.ToSingle(dt.Rows[P]["Qty"]);
        //            tempDatatable = (DataTable)ViewState["tempDatatable"];
        //            if (Convert.ToInt32(ViewState["TransId"]) > 0)
        //            {

        //                transaction.UpdateTreatementTransaction(drugname, DoseId, Dose, DoseTimeId, Convert.ToString(days), note, ItemId, Convert.ToInt32(ViewState["TransId"]), freq);
        //                lblMsg.Text = "Record Updated Successfully!!";
        //                BindTreamentGrid(Convert.ToInt32(Session["EmrRegNo"]), Convert.ToInt32(lblOpd.Text), Convert.ToInt32(lblIpd.Text));
        //                ClearTreatment();
        //            }
        //            else
        //            {
        //                if (!string.IsNullOrEmpty(drugname) && !string.IsNullOrEmpty(freq) && !string.IsNullOrEmpty(Dose) && !string.IsNullOrEmpty(startDate)
        //                    && !string.IsNullOrEmpty(endDate) && days >= 0)
        //                {
        //                    if (btnAdd.Text == "Add")
        //                    {
        //                        //CreateNewTable(drugname,freq,days.ToString(),startDate,endDate,note);
        //                        if (rdbpkg.SelectedValue == "Package")
        //                        {

        //                            dt = new DataTable();
        //                            int PackageId = Convert.ToInt32(ViewState["ItemId"]);
        //                            dt = objTreat.FillPackageDetails_DrID(PackageId);
        //                            if (dt.Rows.Count > 0)
        //                            {
        //                                for (int i = 0; i < dt.Rows.Count; i++)
        //                                {
        //                                    ItemId = Convert.ToInt32(dt.Rows[i]["ItemId"]);
        //                                    Qty = Convert.ToSingle(dt.Rows[i]["Qty"]);
        //                                    drugname = Convert.ToString(dt.Rows[i]["ItemName"]);
        //                                    Dose = Convert.ToString(dt.Rows[i]["DoseTimeName"]);
        //                                    DoseTimeId = Convert.ToInt32(dt.Rows[i]["DoseTimeId"]);
        //                                    freq = Convert.ToString(dt.Rows[i]["DoseName"]);
        //                                    DoseTimeId = Convert.ToInt32(dt.Rows[i]["DoseId"]);
        //                                    days = Convert.ToInt32(dt.Rows[i]["Days"]);
        //                                    note = Convert.ToString(dt.Rows[i]["Remark"]);
        //                                    //  tempDatatable.Rows.Add(tempDatatable.Rows.Count + 1, drugname, Qty, startDate, endDate, note, ItemId);
        //                                    tempDatatable.Rows.Add(tempDatatable.Rows.Count + 1, drugname, Dose, freq, days, startDate, endDate, note, DoseTimeId, DoseId, ItemId, Qty);

        //                                }
        //                            }

        //                        }
        //                        else
        //                        {
        //                            tempDatatable.Rows.Add(tempDatatable.Rows.Count + 1, drugname, Dose, freq, days, startDate, endDate, note, DoseTimeId, DoseId, ItemId, Qty);

        //                        }
        //                    }
        //                    else if (btnAdd.Text == "Update")
        //                    {
        //                        int rowId = ViewState["rowId"] != null ? (int)ViewState["rowId"] : -1;
        //                        if (rowId >= 0)
        //                        {
        //                            string idd = "Id=" + rowId;

        //                            DataRow row = tempDatatable.NewRow();

        //                            if (row != null)
        //                            {
        //                                tempDatatable.Rows.RemoveAt(rowId);

        //                                tempDatatable.Rows.Add(rowId, drugname, Dose, freq, days, startDate, endDate, note, DoseTimeId, DoseId, ItemId, Qty);
        //                                gvTempTable.EditIndex = -1;
        //                                ViewState["rowId"] = -1;
        //                                btnAdd.Text = "Add";
        //                            }


        //                        }
        //                    }
        //                    lblMsg.Text = "";

        //                    ViewState["tempDatatable"] = tempDatatable;
        //                    gvTempTable.DataSource = tempDatatable;
        //                    gvTempTable.DataBind();
        //                    ClearFields();

        //                }
        //                else
        //                {
        //                    lblMsg.Text = "Please select atleast 1 drug";
        //                    lblMsg.ForeColor = System.Drawing.Color.Red;
        //                    lblMsg.Visible = true;
        //                }
        //            }

        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //    }
        //}
    }


    private void BindTreamentGrid(int PatRegId, int OpdNo, int IpdNo)
    {
        if (Request.QueryString["OpdNo"] != null)
        {
            GvNoteIngrid.DataSource = transaction.GetTreatementDetailsTreatment_OPEMERG(PatRegId, OpdNo, IpdNo);
        }
        else
        {

            GvNoteIngrid.DataSource = transaction.GetTreatementDetailsTreatment(PatRegId, OpdNo, IpdNo);
        }
        GvNoteIngrid.DataBind();
        for (int i = 0; i < GvNoteIngrid.Rows.Count; i++)
        {

            if (i > 0)
            {

                if (GvNoteIngrid.DataKeys[i].Value.ToString().Trim() == GvNoteIngrid.DataKeys[i - 1].Value.ToString().Trim())
                {
                    //GvNoteIngrid.Rows[i].Cells[0].Text = "";
                    GvNoteIngrid.Rows[i].Cells[1].Text = "";
                    GvNoteIngrid.Rows[i].Cells[2].Text = "";
                    GvNoteIngrid.Rows[i].Cells[3].Text = "";
                    //  GvNoteIngrid.Rows[i].Cells[2].Text = "";
                }
            }
        }
    }

    protected void FillPage1()
    {
        try
        {
            clsTreatmentTransaction Obj = new clsTreatmentTransaction();
            Obj = Obj.SelectDrugTrasaction(Convert.ToInt32(ViewState["TransId"]));
            txtDrugName.Text = Convert.ToString(Obj.DrugName);
            //ddlDoseTime.SelectedValue = Convert.ToString(Obj.DoseTimeId);
            //drpfrequency.SelectedValue = Convert.ToString(Obj.DoseId);
            txtQty.Text = Convert.ToString(Obj.Qty);
            txtRemark.InnerText = Convert.ToString(Obj.Note);
            ViewState["ItemId"] = Convert.ToString(Obj.ItemId);




        }
        catch (Exception ex)
        {
           // lblMsg.Text = ex.Message;
        }
    }
}