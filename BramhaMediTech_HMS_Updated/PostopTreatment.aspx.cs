using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;

public partial class PostopTreatment : BasePage
{
    clsEmr obj = new clsEmr();
    clsTreatment objTreat = new clsTreatment();
    clsTreatmentTransaction transaction = new clsTreatmentTransaction();
    DataTable tempDatatable = new DataTable();
    DataTable dt = new DataTable();
    public PostopTreatment()
    {
        tempDatatable = CreateTable();
    }

    protected void rdbpkg_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["UID"] = rdbpkg.SelectedValue;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if (Session["EmrRegNo"] != "")
            {

                Session["UID"] = rdbpkg.SelectedValue;
                string regId = Convert.ToString(Session["EmrRegNo"]);
                string name = Request.QueryString["Name"];
                string opd = Convert.ToString(Session["EmrOpdNo"]);
                string IpdNo = Convert.ToString(Session["EmrIpdNo"]);
                string entrydate = Request.QueryString["EntryDate"];
                Session["Branchid"] = "1";
               // lblOpd.Text = opd;
                PindPatientInformation();
                txtStart.Text = DateTime.Now.ToString("dd-MM-yyyy");
                txtTreatId.Value = "0";
                ViewState["TreatId"] = "0";
                BindFrequencyDrop();
                ValidateDays();
                txtFollowUp.Text = DateTime.Now.AddDays(7).ToString("dd/MM/yyyy");
                BindTreamentGrid(Convert.ToInt32(Session["EmrRegNo"]), Convert.ToInt32(Session["EmrOpdNo"]), Convert.ToInt32(Session["EmrIpdNo"]));
                BindGridviewData();
            }
            else
            {
                Response.Redirect(string.Format("ListPatients.aspx"));
            }
        }
        else
        {
            BindGridviewData();
        }
    }
    public void PindPatientInformation()
    {
       
        dt = obj.Get_AllPatientInformation(Convert.ToString(Session["EmrRegNo"]), Convert.ToString(Session["EmrOpdNo"]), Convert.ToInt32(Session["EmrIpdNo"]), Convert.ToInt32(Session["Branchid"]));
        try
        {
            if (dt != null)
            {
        //        lblPatientName.Text = Convert.ToString(dt.Rows[0]["PatientName"]);
        //        txtpatientregid.Text = Convert.ToString(dt.Rows[0]["PatRegId"]);
        //        lblIpd.Text = Convert.ToString(dt.Rows[0]["IpdNo"]);
        //        lblOpd.Text = Convert.ToString(dt.Rows[0]["OpdNo"]);
        //        lblMobileNo.Text = Convert.ToString(dt.Rows[0]["MobileNo"]);
        //        lbldrname.Text = Convert.ToString(dt.Rows[0]["DrName"]);
              ViewState["DrId"] = Convert.ToInt32(dt.Rows[0]["DrId"]);
               Session["DrId"] = ViewState["DrId"];
        //       // lblAge.Text = Convert.ToString(dt.Rows[0]["Age"]) + "" + Convert.ToString(dt.Rows[0]["AgeType"]) + "/" + Convert.ToString(dt.Rows[0]["GenderName"]);
        //        string Birthdate = Convert.ToString(dt.Rows[0]["BirthDate"]);
        //        Birthdate = DateTime.Parse(Birthdate).ToString("dd/MM/yyyy");
        //        getAge(Birthdate);
        //        lblAge.Text = lblAge.Text + "/" + Convert.ToString(dt.Rows[0]["GenderName"]);
        //    }
        //    dt=new DataTable ();
        //    dt = obj.Get_AllPatientVitalTaken(Convert.ToString(Session["EmrRegNo"]), Convert.ToString(Session["EmrOpdNo"]), 0, Convert.ToInt32(Session["Branchid"]));
        //    if (dt.Rows.Count > 0)
        //    {
        //        lblvtaken.Text = Convert.ToString( dt.Rows[0]["CreatedOn"]);
            }
        }
        catch (Exception ex)
        {

        }
    }
    //public void getAge(string Birthdate)
    //{
    //    int intYear, intMonth, intDays;
    //    DateTime Birthday = Convert.ToDateTime(Birthdate);
    //    intYear = Birthday.Year;
    //    intMonth = Birthday.Month;
    //    intDays = Birthday.Day;

    //    DateTime dtt = Convert.ToDateTime(Birthdate);

    //    DateTime td = DateTime.Now;
    //    int Leap_Year = 0;
    //    for (int i = dtt.Year; i < td.Year; i++)
    //    {
    //        if (DateTime.IsLeapYear(i))
    //        {
    //            ++Leap_Year;
    //        }
    //    }
    //    TimeSpan timespan = td.Subtract(Birthday);
    //    intDays = timespan.Days - Leap_Year;
    //    int intResult = 0;
    //    intYear = Math.DivRem(intDays, 365, out intResult);
    //    intMonth = Math.DivRem(intResult, 30, out intResult);
    //    intDays = intResult;
    //    if (intYear > 0)//&& intDays > 0
    //    {
    //        lblAge.Text = intYear.ToString() + " Years";
    //        //ddlAge.SelectedIndex = 0;
    //    }
    //    else if (intMonth > 0)
    //    {
    //        lblAge.Text = intMonth.ToString() + " Months";
    //        //ddlAge.SelectedIndex = 1;
    //    }
    //    else if (intDays > 0)
    //    {
    //        lblAge.Text = intDays.ToString() + " Days";
    //        // ddlAge.SelectedIndex = 2;
    //    }
    //}
    protected void BindGridviewData()
    {
        if (ViewState["tempDatatable"] != null)
        {
            tempDatatable = (DataTable)ViewState["tempDatatable"];
        }
        gvTempTable.DataSource = tempDatatable;
        gvTempTable.DataBind();
    }

    private DataTable CreateTable()
    {
        tempDatatable.Columns.Add("Id", typeof(Int32));
        tempDatatable.Columns.Add("DrugName", typeof(string));
        tempDatatable.Columns.Add("Dose",typeof(string));
        tempDatatable.Columns.Add("Frequency", typeof(string));
        tempDatatable.Columns.Add("Days", typeof(Int32));
        tempDatatable.Columns.Add("StartDate", typeof(string));
        tempDatatable.Columns.Add("EndDate", typeof(string));
        tempDatatable.Columns.Add("Note", typeof(string));
        tempDatatable.Columns.Add("DoseTimeId", typeof(Int32));
        tempDatatable.Columns.Add("DoseId", typeof(Int32));
        tempDatatable.Columns.Add("ItemId", typeof(Int32));
        tempDatatable.Columns.Add("Qty", typeof(float));
        tempDatatable.Columns.Add("Vital", typeof(string));
        tempDatatable.Columns.Add("Diet", typeof(string));
        tempDatatable.Columns.Add("QtyML", typeof(string));
        tempDatatable.Columns.Add("Route", typeof(string));
        ViewState["tempDatatable"] = tempDatatable;

        return tempDatatable;
    }


    private void BindMainGrid(string p, string i, string o)
    {
        //gdvTreatment.DataSource = objTreat.GetTreatmentDetails(p, i, o);
        //gdvTreatment.DataBind();
    }

    private void BindFrequencyDrop()
    {
        //drpfrequency.DataSource = objTreat.GetFrequencyMaster();
        //drpfrequency.DataValueField = "FreId";
        //drpfrequency.DataTextField = "FreType";
        //drpfrequency.DataBind();
        //drpfrequency.Items.Insert(0, new ListItem("--Select--", "-1"));
        //drpfrequency.SelectedIndex = 0;
        drpfrequency.DataSource = objTreat.FillDoseMaster();
        drpfrequency.DataValueField = "DoseId";
        drpfrequency.DataTextField = "DoseName";
        drpfrequency.DataBind();

        ddlDoseTime.DataSource = objTreat.FillDoseTimes();
        ddlDoseTime.DataValueField = "DoseTimeId";
        ddlDoseTime.DataTextField = "DoseTimeName";
        ddlDoseTime.DataBind();

        ddlRoute.DataSource = objTreat.Fill_Route();
        ddlRoute.DataValueField = "Id";
        ddlRoute.DataTextField = "Route";
        ddlRoute.DataBind();
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
                    if (dt.Rows[i]["Drug"] != DBNull.Value)
                    {
                        list.Add(Convert.ToString(dt.Rows[i]["Drug"]));
                    }
                }
            }
        }

        return list;
    }

    [WebMethod]
    public static List<string> GetPatientIds(string prefixText)
    {
        clsTreatment objj = new clsTreatment();
        DataTable dt = objj.GetPatientIds(prefixText);
        List<string> list = new List<string>();

        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["ids"] != DBNull.Value)
                    {
                        list.Add(Convert.ToString(dt.Rows[i]["ids"]));
                    }
                }
            }
        }

        return list;
    }
    protected void drpfrequency_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpfrequency.SelectedIndex > 0)
        {
            Qty1.Visible = true;
            Qty2.Visible = false;
        }
        else
        {
            Qty1.Visible = false;
            Qty2.Visible = true;
        }
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        try
        {
            //txtPatientRegId.Text = "";
            //txtIpd.Text = "";
            //txtOpd.Text = "";
            //txtBranchId.Text = "";
            string[] val = (System.DateTime.Now.ToShortDateString().Replace('/', '-')).Split('-');
            txtFollowUp.Text = val[2] + "-" + val[1] + "-" + val[0];

            Clear();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
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
            if (Convert.ToString(Session["EmrIpdNo"]) != "0")
            {
                if (Convert.ToString(Session["PatAdmit"]) == "No")
                {
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = "Patient already discharge!";
                    return;
                }
            }
            if (tempDatatable != null && tempDatatable.Rows.Count > 0)
            {
                int recId = string.IsNullOrEmpty(txtTreatId.Value) ? 0 : Convert.ToInt32(txtTreatId.Value);
                string ttype = (recId == 0)?"Insert": "Update";

                string[] dtt = System.DateTime.Now.ToShortDateString().Split('/');
                string[] followDate = txtFollowUp.Text.Split('-');

                objTreat.patientId = Convert.ToString(Session["EmrRegNo"]);
                objTreat.ipd = Convert.ToString( Session["EmrIpdNo"]);
                objTreat.opd = Convert.ToString( Session["EmrOpdNo"]);
                objTreat.branchId = Convert.ToString( Session["Branchid"]);
                objTreat.followUp = followDate[2] + "-" + followDate[1] + "-" + followDate[0];
                objTreat.createdBy = Convert.ToString(Session["username"]); 
                objTreat.createdOn = dtt[2] + "-" + dtt[1] + "-" + dtt[0];
                objTreat.treatId = recId.ToString();
                objTreat.updatedBy = Convert.ToString(Session["username"]);
                objTreat.updatedOn = dtt[2] + "-" + dtt[1] + "-" + dtt[0];
                objTreat.DrId = Convert.ToInt32(ViewState["DrId"]);
                objTreat.DiscMedication = false;
                objTreat.IsApproveByNurse = true;
                objTreat.PostpoTreat = Convert.ToBoolean(1);
                int res = 0;
                if (objTreat.getallreadyIPDRecPayment_NewPostPo(DateTime.Now.AddMinutes(-1), Convert.ToInt32(Session["EmrRegNo"]), Convert.ToInt32(Session["EmrIpdNo"]), Convert.ToInt32(Session["EmrOpdNo"])))
                {
                    res = objTreat.InsertUpdateDeleteMain_PostPo(ttype);
                     if (res == 0)
                     {
                         DataTable dtid=new DataTable ();
                         dtid = transaction.GetTreatmentIDFor_PatientId_PostPo(Convert.ToString(Session["EmrRegNo"]), Convert.ToString(Session["EmrOpdNo"]), Convert.ToString(Session["EmrIpdNo"]));
                         if (dtid.Rows.Count > 0)
                         {
                             res = Convert.ToInt32( dtid.Rows[0]["TreatmentId"]);
                         }
                     }
                     ViewState["res"] = res;
                }
                else
                {
                      res= Convert.ToInt32( ViewState["res"]);
                }
                    if (res > 0)
                    {

                        for (int i = 0; i < tempDatatable.Rows.Count; i++)
                        {
                            transaction.TransId = string.IsNullOrEmpty(Convert.ToString(ViewState["TrId"])) ? "0" : Convert.ToString(ViewState["TrId"]);
                            transaction.TreatmentId = res.ToString();

                            transaction.DrugName = tempDatatable.Rows[i]["DrugName"].ToString();
                            transaction.FrequencyType = tempDatatable.Rows[i]["Frequency"].ToString();
                            transaction.Dose = tempDatatable.Rows[i]["Dose"].ToString();
                            transaction.Days = tempDatatable.Rows[i]["Days"].ToString();
                            string[] sDate = tempDatatable.Rows[i]["StartDate"].ToString().Replace('/', '-').Split('-');
                            string[] tDate = tempDatatable.Rows[i]["EndDate"].ToString().Replace('/', '-').Split('-');
                            transaction.StartDate = sDate[2] + "-" + sDate[1] + "-" + sDate[0];
                            transaction.EndDate = tDate[2] + "-" + tDate[1] + "-" + tDate[0];
                            transaction.Note = tempDatatable.Rows[i]["Note"].ToString();
                            transaction.DoseId = Convert.ToInt32(tempDatatable.Rows[i]["DoseId"]);
                            transaction.DoseTimeId = Convert.ToInt32(tempDatatable.Rows[i]["DoseTimeId"]);
                            transaction.ItemId = Convert.ToInt32(tempDatatable.Rows[i]["ItemId"]);
                            transaction.Qty = Convert.ToSingle(tempDatatable.Rows[i]["Qty"]);
                            transaction.NurseOrder = Convert.ToBoolean(0);
                            transaction.PostpoTreat = Convert.ToBoolean(1);
                            transaction.Diet = tempDatatable.Rows[i]["Diet"].ToString(); ;
                            transaction.Vital = tempDatatable.Rows[i]["Vital"].ToString();
                            transaction.QtyML = tempDatatable.Rows[i]["QtyML"].ToString();
                            transaction.Route = tempDatatable.Rows[i]["Route"].ToString();
                            if (transaction.TransId == "0")
                            {
                                int r = transaction.InsertUpdateDeleteMain_PostPo("Insert");
                                if (r > 0)
                                {
                                    lblMsg.Text = "Record inserted successfully.";
                                    lblMsg.ForeColor = System.Drawing.Color.Green;
                                    lblMsg.Visible = true;
                                }
                                else
                                {
                                    lblMsg.Text = "Failed to insert t.";
                                    lblMsg.ForeColor = System.Drawing.Color.Red;
                                    lblMsg.Visible = true;
                                }
                            }
                        }

                        BindTreamentGrid(Convert.ToInt32(objTreat.patientId), Convert.ToInt32(Session["EmrOpdNo"]), Convert.ToInt32(Session["EmrIpdNo"]));

                    }
                    else
                    {
                        lblMsg.Text = "Failed to insert.";
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                        lblMsg.Visible = true;
                    }
                //}
            }
            else
            {
                lblMsg.Text = "Please enter atleast one record";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Visible = true;
            }
        }
        catch (Exception)
        {
            lblMsg.Text = "Error occurred";
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Visible = true;
        }
        
    }

    private void BindTreamentGrid(int PatRegId,int OpdNo,int IpdNo)
    {
        GvNoteIngrid.DataSource = transaction.GetTreatementDetailsTreatment_PostPo(PatRegId, OpdNo, IpdNo);
        GvNoteIngrid.DataBind();
        for (int i = 0; i < GvNoteIngrid.Rows.Count; i++)
        {

            if (i > 0)
            {

                if (GvNoteIngrid.DataKeys[i].Value.ToString().Trim() == GvNoteIngrid.DataKeys[i - 1].Value.ToString().Trim())
                {
                    GvNoteIngrid.Rows[i].Cells[0].Text = "";
                    GvNoteIngrid.Rows[i].Cells[1].Text = "";
                    GvNoteIngrid.Rows[i].Cells[2].Text = "";
                    GvNoteIngrid.Rows[i].Cells[3].Text = "";
                  //  GvNoteIngrid.Rows[i].Cells[2].Text = "";
                }
            }
        }
        txtvital.Text = "";
        txtDiet.Text = "";
    }
    private void OldSave()
    {
        try
        {
            if (tempDatatable != null && tempDatatable.Rows.Count > 0)
            {

                int recId = string.IsNullOrEmpty(txtTreatId.Value) ? 0 : Convert.ToInt32(txtTreatId.Value);

                string pId = "";// txtPatientRegId.Text;
                string ipd = "";//txtIpd.Text;
                string opd = "";//txtOpd.Text;
                string branch = "";//txtBranchId.Text;
                string follow = "";//txtFollowUp.Text;

                string drug = txtDrugName.Text;
                string freq = drpfrequency.Items.Count > 0 ? drpfrequency.SelectedItem.Text : "";
                string days = txtDays.Text;
                string from = txtStart.Text;
                string to = txtEnd.Text;

                if (!string.IsNullOrEmpty(pId) && (!string.IsNullOrEmpty(ipd) || !string.IsNullOrEmpty(opd)) &&
                    !string.IsNullOrEmpty(branch) && !string.IsNullOrEmpty(follow) && !string.IsNullOrEmpty(drug)
                    && !string.IsNullOrEmpty(freq) && !string.IsNullOrEmpty(days) && !string.IsNullOrEmpty(from)
                    && !string.IsNullOrEmpty(to))
                {
                    string[] dtt = System.DateTime.Now.ToShortDateString().Split('/');
                    string[] followDate = follow.Split('-');
                    string[] startDate = from.Split('-');
                    string[] endDate = to.Split('-');
                    objTreat.patientId = pId;
                    objTreat.ipd = ipd;
                    objTreat.opd = opd;
                    objTreat.branchId = branch;
                    objTreat.followUp = followDate[2] + "-" + followDate[1] + "-" + followDate[0];
                    objTreat.createdBy = "Sam";
                    objTreat.createdOn = dtt[2] + "-" + dtt[1] + "-" + dtt[0];
                    objTreat.treatId = recId.ToString();
                    objTreat.updatedBy = "Sam";
                    objTreat.updatedOn = dtt[2] + "-" + dtt[1] + "-" + dtt[0];

                    string ttype = "";

                    if (recId == 0)
                    {
                        ttype = "Insert";
                    }
                    else
                    {
                        ttype = "Update";
                    }

                    int res = objTreat.InsertUpdateDeleteMain(ttype);

                    if (res > 0)
                    {
                        transaction.TransId = string.IsNullOrEmpty(Convert.ToString(ViewState["TrId"])) ? "0" : Convert.ToString(ViewState["TrId"]);
                        transaction.TreatmentId = res.ToString();
                        transaction.DrugName = txtDrugName.Text;
                        transaction.FrequencyType = drpfrequency.SelectedItem.Text;
                        transaction.Days = txtDays.Text;
                        string[] sDate = (txtStart.Text).ToString().Replace('/', '-').Split('-');
                        string[] tDate = (txtEnd.Text).ToString().Replace('/', '-').Split('-');
                        transaction.StartDate = sDate[2] + "-" + sDate[1] + "-" + sDate[0];
                        transaction.EndDate = tDate[2] + "-" + tDate[1] + "-" + tDate[0];
                        transaction.Note = "";//txtNote.Text;
                        if (transaction.TransId == "0")
                        {
                            int r = transaction.InsertUpdateDeleteMain("Insert");
                            if (r > 0)
                            {
                                lblMsg.Text = "Record inserted successfully.";
                                lblMsg.ForeColor = System.Drawing.Color.Green;
                                lblMsg.Visible = true;
                            }
                            else
                            {
                                lblMsg.Text = "Failed to insert t.";
                                lblMsg.ForeColor = System.Drawing.Color.Red;
                                lblMsg.Visible = true;
                            }
                        }


                        Clear();
                        //gdvTreatment.EditIndex = -1;
                    }
                    else
                    {
                        lblMsg.Text = "Failed to insert.";
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                        lblMsg.Visible = true;
                    }
                }
            }
            else
            {
                lblMsg.Text = "Please select atleast 1 drug.";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Visible = true;
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    private void Clear()
    {
        txtDrugName.Text = "";
        drpfrequency.SelectedIndex = -1;
        txtDays.Text = "";
        string[] val = (System.DateTime.Now.ToShortDateString().Replace('/', '-')).Split('-');
        txtStart.Text = val[2] + "-" + val[1] + "-" + val[0];
        txtEnd.Text = val[2] + "-" + val[1] + "-" + val[0];
        //txtNote.Text = "";
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        btnClear_Click(null, null);
        Clear();
        txtTreatId.Value = "0";
        BindMainGrid(null, null, null);
    }

 
    protected void txtStart_TextChanged(object sender, EventArgs e)
    {
        if (DateDifference() > 0)
        {
            ValidateDays();
        }
    }
    public bool IsDateBeforeOrToday(string input)
    {
        int val = DateDifference();
        return val > 0 ? true : false;
    }
    protected void txtEnd_TextChanged(object sender, EventArgs e)
    {
        if (!IsDateBeforeOrToday(txtEnd.Text))
        {
            txtStart.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtEnd.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtDays.Text = "0";
        }
        else
        {
            if (DateDifference() > 0)
            {
                ValidateDays();
            }
        }
    }

    private int DateDifference()
    {
        try
        {
            DateTime start = Convert.ToDateTime(txtStart.Text);
            DateTime end = Convert.ToDateTime(txtEnd.Text);
            return Convert.ToInt32((end - start).TotalDays);
        }
        catch (Exception)
        {
            txtStart.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtEnd.Text = DateTime.Now.ToString("dd/MM/yyyy");
            return 0;
        }

    }

    private void ValidateDays()
    {
        try
        {
            txtDays.Text = DateDifference().ToString();
        }
        catch (Exception ex)
        {
            txtEnd.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
    }

    protected void txtDays_TextChanged(object sender, EventArgs e)
    {
        try
        {
            int days = Convert.ToInt32(txtDays.Text);
            if (days > 0)
            {
                int val = string.IsNullOrEmpty(txtDays.Text) ? 0 : days;

                string start = txtStart.Text;
                string end = DateTime.Parse(start).AddDays(val).ToString("dd/MM/yyyy");

                txtEnd.Text = end;
            }
            else
            {
                txtStart.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txtEnd.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txtDays.Text = "0";
            }
        }
        catch (Exception ex)
        {
            txtEnd.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
    }

  
    protected void GvNoteIngrid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //int rowIndex = Convert.ToInt32(e.CommandArgument);

        //if (rowIndex >= 0)
        //{
        //    if (e.CommandName == "Recall")
        //    {
        //    }
        //}
    }

    protected void gvTempTable_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int rowIndex = Convert.ToInt32(e.CommandArgument);

        if (rowIndex >= 0)
        {
            if (e.CommandName == "Edit")
            {
                //Reference the GridView Row.
                GridViewRow row = gvTempTable.Rows[rowIndex];
                string drug = gvTempTable.Rows[rowIndex].Cells[2].Text;
                string freq = gvTempTable.Rows[rowIndex].Cells[3].Text;
                string days = gvTempTable.Rows[rowIndex].Cells[5].Text;
                //string start = gvTempTable.Rows[rowIndex].Cells[5].Text;
                //string end = gvTempTable.Rows[rowIndex].Cells[6].Text;
                string note = gvTempTable.Rows[rowIndex].Cells[6].Text.Trim();
                string dosetime=gvTempTable.Rows[rowIndex].Cells[7].Text.Trim();
                string doseQty = gvTempTable.Rows[rowIndex].Cells[8].Text.Trim();
                ViewState["ItemId"] = gvTempTable.Rows[rowIndex].Cells[9].Text.Trim();
                txtDrugName.Text = drug;
                drpfrequency.SelectedIndex = drpfrequency.Items.IndexOf(drpfrequency.Items.FindByText(freq));
                txtDays.Text = days;
                ddlDoseTime.SelectedValue = dosetime;
                drpfrequency.SelectedValue = doseQty;
                //txtStart.Text = start;
                //txtEnd.Text = end;
                txtNote.Text = note;
                if (gvTempTable.Rows[rowIndex].Cells[10].Text.Trim() == "&nbsp;")
                {
                    txtvital.Text = "";
                }
                else
                {
                    txtvital.Text = gvTempTable.Rows[rowIndex].Cells[10].Text.Trim();
                }
                if (gvTempTable.Rows[rowIndex].Cells[11].Text.Trim() == "&nbsp;")
                {
                    txtDiet.Text = "";
                }
                else
                {
                    txtDiet.Text = gvTempTable.Rows[rowIndex].Cells[11].Text.Trim();
                }
                txtDoseQty.Text = gvTempTable.Rows[rowIndex].Cells[13].Text.Trim();
                ddlRoute.SelectedItem.Text = gvTempTable.Rows[rowIndex].Cells[14].Text.Trim();
                if( Convert.ToString(txtDoseQty.Text).Trim() !="")
                {
                    if (Convert.ToString(txtDoseQty.Text).Trim() == "&nbsp;")
                    {
                        Qty2.Visible = false;
                        Qty1.Visible = true;
                    }
                    else
                    {
                        Qty2.Visible = true;
                        Qty1.Visible = false;
                    }
                }
                else
                {
                    Qty2.Visible = false;
                    Qty1.Visible = true;
                }
                txtQty.Text = gvTempTable.Rows[rowIndex].Cells[12].Text.Trim();

                btnAdd.Text = "Update";

                ViewState["rowId"] = rowIndex;
            }
            else if (e.CommandName == "Delete")
            {
                tempDatatable = (DataTable)ViewState["tempDatatable"];
                if (tempDatatable != null && tempDatatable.Rows.Count > 0)
                {
                    tempDatatable.Rows.RemoveAt(rowIndex);
                    ViewState["tempDatatable"] = tempDatatable;
                    gvTempTable.DataSource = tempDatatable;
                    gvTempTable.DataBind();

                }
            }
            if (e.CommandName == "Recall")
            {
            }
        }
    }

    private void ClearFields()
    {
        txtDrugName.Text = "";
        drpfrequency.SelectedIndex = -1; ;
        txtDays.Text = "0";
        txtEnd.Text = txtStart.Text = DateTime.Now.ToString("dd-MM-yyyy");
        txtNote.Text = "";
        txtFollowUp.Text = DateTime.Now.AddDays(7).ToString("dd-MM-yyyy");
        txtQty.Text = "";
        Qty2.Visible = true;
        Qty1.Visible = false;
        txtDoseQty.Text = "";
        ddlRoute.SelectedValue = "0";
    }
    private void ClearTreatment()
    {
        txtDrugName.Text = "";
        drpfrequency.SelectedIndex = -1; ;
        txtDays.Text = "0";
      
        ddlDoseTime.SelectedValue = "0";
        txtNote.Text = "";
        ViewState["ItemId"] = "0";
        ViewState["TransId"] = "0";
        Qty2.Visible = true;
        Qty1.Visible = false;
        txtDoseQty.Text = "";
        ddlRoute.SelectedValue = "0";
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtDoseQty.Text.Trim() == "")
            {
                txtDoseQty.Focus();
                txtDoseQty.ForeColor = System.Drawing.Color.Red;
                txtDoseQty.BorderColor = System.Drawing.Color.Red;
                lblMsg.Text = "Enter Dose!";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Visible = true;
                return;
            }
            else
            {
                txtDoseQty.ForeColor = System.Drawing.Color.Black;
                txtDoseQty.BorderColor = System.Drawing.Color.Black;
            }
            if (drpfrequency.SelectedValue == "0")
            {
                drpfrequency.Focus();
                drpfrequency.ForeColor = System.Drawing.Color.Red;
                drpfrequency.BorderColor = System.Drawing.Color.Red;
                lblMsg.Text = "Select Unit!";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Visible = true;
                return;
            }
            else
            {
                drpfrequency.ForeColor = System.Drawing.Color.Black;
                drpfrequency.BorderColor = System.Drawing.Color.Black;
            }
            if (ddlDoseTime.SelectedValue == "0")
            {
                ddlDoseTime.Focus();
                ddlDoseTime.ForeColor = System.Drawing.Color.Red;
                ddlDoseTime.BorderColor = System.Drawing.Color.Red;
                lblMsg.Text = "Select Frequency!";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Visible = true;
                return;
            }
            else
            {
                ddlDoseTime.ForeColor = System.Drawing.Color.Black;
                ddlDoseTime.BorderColor = System.Drawing.Color.Black;
            }
            if (ddlRoute.SelectedValue == "0")
            {
                ddlRoute.Focus();
                ddlRoute.ForeColor = System.Drawing.Color.Red;
                ddlRoute.BorderColor = System.Drawing.Color.Red;
                lblMsg.Text = "Select Route!";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Visible = true;
                return;
            }
            else
            {
                ddlRoute.ForeColor = System.Drawing.Color.Black;
                ddlRoute.BorderColor = System.Drawing.Color.Black;
            }
            if (txtDays.Text == "0")
            {
                txtDays.Focus();
                txtDays.ForeColor = System.Drawing.Color.Red;
                txtDays.BorderColor = System.Drawing.Color.Red;
                lblMsg.Text = "Enter Days!";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Visible = true;
                return;
            }
            else
            {
                txtDays.ForeColor = System.Drawing.Color.Black;
                txtDays.BorderColor = System.Drawing.Color.Black;
            }
            if (Convert.ToString(Session["EmrIpdNo"]) != "0")
            {
                if (Convert.ToString(Session["PatAdmit"]) == "No")
                {
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = "Patient already discharge!";
                    return;
                }
            }
            float Qty = 0;
            string drugname = txtDrugName.Text;
            string freq = drpfrequency.SelectedItem.ToString();
            int days = Convert.ToInt32(txtDays.Text);
            string startDate = txtStart.Text.ToString();
            string endDate = txtEnd.Text.ToString();
            string note = txtNote.Text.ToString().Trim();
            string Dose = ddlDoseTime.SelectedItem.Text;
            int DoseId =Convert.ToInt32(drpfrequency.SelectedValue);
            int DoseTimeId = Convert.ToInt32(ddlDoseTime.SelectedValue);
            int ItemId = Convert.ToInt32(ViewState["ItemId"]);
            string Route = ddlRoute.SelectedItem.Text.Trim();
            if (txtQty.Text != "")
            {
                 Qty = Convert.ToSingle(txtQty.Text);
            }
            if(Convert.ToString(txtvital.Text).Trim() == "&nbsp;")
            {
                txtvital.Text = "";
            }

            if (Convert.ToString(txtDoseQty.Text).Trim() == "&nbsp;")
            {
                txtDoseQty.Text = "";
            }

            string Vital = txtvital.Text;
            string Diet = txtDiet.Text;
            string QtyML = txtDoseQty.Text.Trim();
            tempDatatable = (DataTable)ViewState["tempDatatable"];
            if (Convert.ToInt32(ViewState["TransId"]) > 0)
            {

                transaction.UpdateTreatementTransaction_555(drugname, DoseId, Dose, DoseTimeId, Convert.ToString(days), note, ItemId, Convert.ToInt32(ViewState["TransId"]), freq, "", "", Route);
                lblMsg.Text = "Record Updated Successfully!!";
                BindTreamentGrid(Convert.ToInt32(Session["EmrRegNo"]), Convert.ToInt32(Session["EmrOpdNo"]), Convert.ToInt32(Session["EmrIpdNo"]));
                ClearTreatment();
            }
            else
            {
                if (!string.IsNullOrEmpty(drugname) && !string.IsNullOrEmpty(freq) && !string.IsNullOrEmpty(Dose) && !string.IsNullOrEmpty(startDate)
                    && !string.IsNullOrEmpty(endDate) && days >= 0)
                {
                    if (btnAdd.Text == "Add")
                    {
                        //CreateNewTable(drugname,freq,days.ToString(),startDate,endDate,note);
                        if (rdbpkg.SelectedValue == "Package")
                        {

                            DataTable dt = new DataTable();
                            int PackageId = Convert.ToInt32(ViewState["ItemId"]);
                            dt = objTreat.FillPackageDetails_DrID(PackageId);
                            if (dt.Rows.Count > 0)
                            {
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    ItemId = Convert.ToInt32(dt.Rows[i]["ItemId"]);
                                    Qty = Convert.ToSingle(dt.Rows[i]["Qty"]);
                                    drugname = Convert.ToString(dt.Rows[i]["ItemName"]);
                                    Dose = Convert.ToString(dt.Rows[i]["DoseTimeName"]);
                                    DoseTimeId = Convert.ToInt32(dt.Rows[i]["DoseTimeId"]);
                                    freq = Convert.ToString(dt.Rows[i]["DoseName"]);
                                    DoseTimeId = Convert.ToInt32(dt.Rows[i]["DoseId"]);
                                    days = Convert.ToInt32(dt.Rows[i]["Days"]);
                                    note = Convert.ToString(dt.Rows[i]["Remark"]);
                                  //  tempDatatable.Rows.Add(tempDatatable.Rows.Count + 1, drugname, Qty, startDate, endDate, note, ItemId);
                                    tempDatatable.Rows.Add(tempDatatable.Rows.Count + 1, drugname, Dose, freq, days, startDate, endDate, note, DoseTimeId, DoseId, ItemId, Qty, Vital, Diet, QtyML,Route);

                                }
                            }

                        }
                        else
                        {
                            tempDatatable.Rows.Add(tempDatatable.Rows.Count + 1, drugname, Dose, freq, days, startDate, endDate, note, DoseTimeId, DoseId, ItemId, Qty, Vital, Diet,QtyML,Route);

                        }
                    }
                    else if (btnAdd.Text == "Update")
                    {
                        int rowId = ViewState["rowId"] != null ? (int)ViewState["rowId"] : -1;
                        if (rowId >= 0)
                        {
                            string idd = "Id=" + rowId;

                            DataRow row = tempDatatable.NewRow();

                            if (row != null)
                            {
                                tempDatatable.Rows.RemoveAt(rowId);

                                tempDatatable.Rows.Add(rowId, drugname, Dose, freq, days, startDate, endDate, note, DoseTimeId, DoseId, ItemId, Qty, Vital, Diet, QtyML,Route);
                                gvTempTable.EditIndex = -1;
                                ViewState["rowId"] = -1;
                                btnAdd.Text = "Add";
                            }


                        }
                    }
                    lblMsg.Text = "";

                    ViewState["tempDatatable"] = tempDatatable;
                    gvTempTable.DataSource = tempDatatable;
                    gvTempTable.DataBind();
                    ClearFields();

                }
                else
                {
                    lblMsg.Text = "Please select atleast 1 drug";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Visible = true;
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void gvTempTable_RowEditing(object sender, GridViewEditEventArgs e)
    {
        e.Cancel = true;
        gvTempTable.DataSource = tempDatatable;
        gvTempTable.DataBind();
    }

    protected void gvTempTable_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        btnAdd.Text = "Add";
        ClearFields();
        ViewState["rowId"] = -1;
    }

    protected void gvTempTable_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvTempTable.PageIndex = e.NewPageIndex;
        gvTempTable.DataSource = tempDatatable;
        gvTempTable.DataBind();
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
   

    protected void GvNoteIngrid_DataBound(object sender, EventArgs e)
    {
        //for (int i = GvNoteIngrid.Rows.Count - 1; i > 0; i--)
        //{
        //    GridViewRow row = GvNoteIngrid.Rows[i];
        //    GridViewRow previousRow = GvNoteIngrid.Rows[i - 1];
        //    for (int j = 0; j < row.Cells.Count; j++)
        //    {
        //        if (row.Cells[j].Text == previousRow.Cells[j].Text)
        //        {
        //            if (previousRow.Cells[j].RowSpan == 0)
        //            {
        //                if (row.Cells[j].RowSpan == 0)
        //                {
        //                    previousRow.Cells[j].RowSpan += 2;
        //                }
        //                else
        //                {
        //                    previousRow.Cells[j].RowSpan = row.Cells[j].RowSpan + 1;
        //                }
        //                row.Cells[j].Visible = false;
        //            }
        //        }
        //    }
        //}
    }
    protected void btnreport_Click(object sender, EventArgs e)
    {
        string sql = "";
        Alter_view();
     



        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Report/Rpt_Prescription.rpt");
        Session["reportname"] = "Prescription";
        Session["RPTFORMAT"] = "pdf";

        //ReportParameterClass.SelectionFormula = sql;
        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);
    }

    public void Alter_view()
    {
        string sql = "";
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd1 = con.CreateCommand();

        string query = "ALTER VIEW [dbo].[VW_GetPrescription] AS (SELECT        tbl_Treatment.TreatmentId, tbl_Treatment.FollowUpDate, tbl_Treatment.PatientRegId, tbl_Treatment.Opd, tbl_Treatment.Ipd, tbl_Treatment.BranchId, tbl_Treatment.CreatedBy, tbl_Treatment.CreatedOn, tbl_Treatment.UpdatedBy, "+
                      "  tbl_Treatment.UpdatedOn, tbl_Treatment.DrId, Initial.Title + ' ' + PatientInformation.FirstName AS PatientName, Initial.Title, Gender.GenderName, PatientInformation.MobileNo, PatientInformation.PhoneNo, "+
                      "  PatientInformation.PatientAddress, PatientInformation.Age, PatientInformation.AgeType, tbl_TreatmentTransaction.DrugName, tbl_TreatmentTransaction.FrequencyType,tbl_TreatmentTransaction.Qty, tbl_TreatmentTransaction.Days, " +
                      "  tbl_TreatmentTransaction.StartDate, tbl_TreatmentTransaction.EndDate, tbl_TreatmentTransaction.Note, tbl_TreatmentTransaction.Dose ,HospEmpMst.Title+' '+ HospEmpMst.Empname as DrName, DepartmentMst.DeptName, HospEmpMst.EmployeeType , tbl_GeneralEmrTransaction.Diagnosis, HospEmpMst.DrSignature,tbl_TreatmentTransaction.Route " +
                      "  FROM            tbl_GeneralEmrTransaction INNER JOIN "+
                      "  tbl_GeneralEMR ON tbl_GeneralEmrTransaction.EmrId = tbl_GeneralEMR.EmrId RIGHT OUTER JOIN "+
                      "  tbl_Treatment INNER JOIN "+
                      "  PatientInformation ON tbl_Treatment.PatientRegId = PatientInformation.PatRegId AND tbl_Treatment.BranchId = PatientInformation.BranchId INNER JOIN "+
                      "  Initial ON PatientInformation.TitleId = Initial.TitleId INNER JOIN "+
                      "  Gender ON PatientInformation.GenderId = Gender.GenderId INNER JOIN "+
                      "  tbl_TreatmentTransaction ON tbl_Treatment.TreatmentId = tbl_TreatmentTransaction.TreatmentId INNER JOIN "+
                      "  HospEmpMst ON tbl_Treatment.DrId = HospEmpMst.DrId INNER JOIN "+
                      "  DepartmentMst ON HospEmpMst.DeptId = DepartmentMst.DeptId ON tbl_GeneralEMR.Patientregid = tbl_Treatment.PatientRegId AND tbl_GeneralEMR.opd = tbl_Treatment.Opd AND tbl_GeneralEMR.ipd = tbl_Treatment.Ipd AND  "+
                      "  tbl_GeneralEMR.branchid = tbl_Treatment.BranchId " +
        " where tbl_Treatment.branchid=" + Convert.ToInt32(Session["Branchid"]) + " and (tbl_Treatment.PatientRegId = " + Convert.ToString(Session["EmrRegNo"]) + ")     ";//AND (tbl_Treatment.Ipd = "+Convert.ToString(Session["EmrIpdNo"])+")

        if (Convert.ToString( Session["EmrOpdNo"]) != "0")
        {
            query += " AND (tbl_Treatment.Opd = " + Convert.ToString(Session["EmrOpdNo"]) + ")"; 
        }
        //if (txtFrom.Value != "" && txtTo.Value != "")
        //{
        //    query += " and    tbl_GeneralEMR.Createdon between ('" + Convert.ToDateTime(txtFrom.Value).ToString("MM/dd/yyyy") + "') and ('" + Convert.ToDateTime(txtTo.Value).AddDays(1).ToString("MM/dd/yyyy") + "')";
        //}
        //Convert.ToString(Session["EmrRegNo"]), Convert.ToString(Session["EmrOpdNo"])


        cmd1.CommandText = query + ")";

        con.Open();
        cmd1.ExecuteNonQuery();
        con.Close(); con.Dispose();
    }

    protected void GvNoteIngrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        clsTreatmentTransaction Obj = new clsTreatmentTransaction();
        int TransId = Convert.ToInt32(GvNoteIngrid.DataKeys[e.RowIndex].Values["TransId"].ToString());

        Obj.DeleteDrugTransaction(TransId);
        lblMsg.Text = "Record Deleted Successfully!!";
        BindTreamentGrid(Convert.ToInt32(Session["EmrRegNo"]), Convert.ToInt32(Session["EmrOpdNo"]), Convert.ToInt32(Session["EmrIpdNo"]));
        //FillDept();
    }
    protected void GvNoteIngrid_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {


            string TransId = (GvNoteIngrid.DataKeys[e.NewEditIndex]["TransId"].ToString());
            ViewState["TransId"] = TransId;
            FillPage();
            e.Cancel = true;
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }

    protected void FillPage()
    {
        try
        {
            clsTreatmentTransaction Obj = new clsTreatmentTransaction();
            Obj = Obj.SelectDrugTrasaction(Convert.ToInt32(ViewState["TransId"]));
            txtDrugName.Text = Convert.ToString(Obj.DrugName);
            ddlDoseTime.SelectedValue = Convert.ToString(Obj.DoseTimeId);
            drpfrequency.SelectedValue = Convert.ToString(Obj.DoseId);
            txtDays.Text = Convert.ToString(Obj.Days);
            txtNote.Text = Convert.ToString(Obj.Note);
            if (Convert.ToString(Obj.QtyML) != "")
            {
                txtDoseQty.Text = Convert.ToString(Obj.QtyML);
                Qty2.Visible = true;
                Qty1.Visible = false;
            }
            else
            {
                Qty2.Visible = false;
                Qty1.Visible = true;
                txtQty.Text = Convert.ToString(Obj.Qty);
            }
            txtDiet.Text = Convert.ToString(Obj.Diet);
            txtvital.Text = Convert.ToString(Obj.Vital);
            ViewState["ItemId"] = Convert.ToString(Obj.ItemId);
            ddlRoute.SelectedItem.Text = Obj.Route;




        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
    protected void IsChkRefill_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox BtnApprove = (CheckBox)sender;
        GridViewRow row1 = (GridViewRow)BtnApprove.NamingContainer;
        int IndReqDeptId = Convert.ToInt32(GvNoteIngrid.DataKeys[row1.RowIndex]["TreatmentId"].ToString());

        dt = new DataTable();
        dt = obj.Get_RefillTreatment(Convert.ToString(Session["EmrRegNo"]), Convert.ToString(IndReqDeptId), 0, Convert.ToInt32(Session["Branchid"]));
        if (dt.Rows.Count > 0)
        {
            for (int P = 0; P < dt.Rows.Count; P++)
            {
               // ItemId = Convert.ToInt32(dt.Rows[i]["ItemId"]);
                try
                {
                    string drugname = Convert.ToString(dt.Rows[P]["DrugNameA"]);
                    string freq = Convert.ToString(dt.Rows[P]["FrequencyType"]);
                    int days = Convert.ToInt32(dt.Rows[P]["Days"]);
                    string startDate = txtStart.Text.ToString();
                    AddDay(days);
                    string endDate = txtEnd.Text.ToString();
                    string note = Convert.ToString(dt.Rows[P]["Note"]); ;
                    string Dose = Convert.ToString(dt.Rows[P]["Dose"]);
                    int DoseId = Convert.ToInt32(dt.Rows[P]["DoseId"]);
                    int DoseTimeId = Convert.ToInt32(dt.Rows[P]["DoseTimeId"]);
                    int ItemId = Convert.ToInt32(dt.Rows[P]["ItemId"]);
                    float Qty = Convert.ToSingle(dt.Rows[P]["Qty"]);
                    string Vital = Convert.ToString(dt.Rows[P]["Vital"]);
                    string Diet = Convert.ToString(dt.Rows[P]["Diet"]);
                    string QtyML = Convert.ToString(dt.Rows[P]["QtyML"]);
                    string Route = Convert.ToString(dt.Rows[P]["Route"]);
                    tempDatatable = (DataTable)ViewState["tempDatatable"];
                    if (Convert.ToInt32(ViewState["TransId"]) > 0)
                    {

                        transaction.UpdateTreatementTransaction_555(drugname, DoseId, Dose, DoseTimeId, Convert.ToString(days), note, ItemId, Convert.ToInt32(ViewState["TransId"]), freq, "", "", Route);
                        lblMsg.Text = "Record Updated Successfully!!";
                        BindTreamentGrid(Convert.ToInt32(Session["EmrRegNo"]), Convert.ToInt32(Session["EmrOpdNo"]), Convert.ToInt32(Session["EmrIpdNo"]));
                        ClearTreatment();
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(drugname) && !string.IsNullOrEmpty(freq) && !string.IsNullOrEmpty(Dose) && !string.IsNullOrEmpty(startDate)
                            && !string.IsNullOrEmpty(endDate) && days >= 0)
                        {
                            if (btnAdd.Text == "Add")
                            {
                                //CreateNewTable(drugname,freq,days.ToString(),startDate,endDate,note);
                                if (rdbpkg.SelectedValue == "Package")
                                {

                                    dt = new DataTable();
                                    int PackageId = Convert.ToInt32(ViewState["ItemId"]);
                                    dt = objTreat.FillPackageDetails_DrID(PackageId);
                                    if (dt.Rows.Count > 0)
                                    {
                                        for (int i = 0; i < dt.Rows.Count; i++)
                                        {
                                            ItemId = Convert.ToInt32(dt.Rows[i]["ItemId"]);
                                            Qty = Convert.ToSingle(dt.Rows[i]["Qty"]);
                                            drugname = Convert.ToString(dt.Rows[i]["ItemName"]);
                                            Dose = Convert.ToString(dt.Rows[i]["DoseTimeName"]);
                                            DoseTimeId = Convert.ToInt32(dt.Rows[i]["DoseTimeId"]);
                                            freq = Convert.ToString(dt.Rows[i]["DoseName"]);
                                            DoseTimeId = Convert.ToInt32(dt.Rows[i]["DoseId"]);
                                            days = Convert.ToInt32(dt.Rows[i]["Days"]);
                                            note = Convert.ToString(dt.Rows[i]["Remark"]);
                                            //  tempDatatable.Rows.Add(tempDatatable.Rows.Count + 1, drugname, Qty, startDate, endDate, note, ItemId);
                                            tempDatatable.Rows.Add(tempDatatable.Rows.Count + 1, drugname, Dose, freq, days, startDate, endDate, note, DoseTimeId, DoseId, ItemId,Qty,Route);

                                        }
                                    }

                                }
                                else
                                {
                                    tempDatatable.Rows.Add(tempDatatable.Rows.Count + 1, drugname, Dose, freq, days, startDate, endDate, note, DoseTimeId, DoseId, ItemId,Qty, Vital, Diet, QtyML,Route);

                                }
                            }
                            else if (btnAdd.Text == "Update")
                            {
                                int rowId = ViewState["rowId"] != null ? (int)ViewState["rowId"] : -1;
                                if (rowId >= 0)
                                {
                                    string idd = "Id=" + rowId;

                                    DataRow row = tempDatatable.NewRow();

                                    if (row != null)
                                    {
                                        tempDatatable.Rows.RemoveAt(rowId);

                                        tempDatatable.Rows.Add(rowId, drugname, Dose, freq, days, startDate, endDate, note, DoseTimeId, DoseId, ItemId, Qty, Vital, Diet, QtyML,Route);
                                        gvTempTable.EditIndex = -1;
                                        ViewState["rowId"] = -1;
                                        btnAdd.Text = "Add";
                                    }


                                }
                            }
                            lblMsg.Text = "";

                            ViewState["tempDatatable"] = tempDatatable;
                            gvTempTable.DataSource = tempDatatable;
                            gvTempTable.DataBind();
                            ClearFields();

                        }
                        else
                        {
                            lblMsg.Text = "Please select atleast 1 drug";
                            lblMsg.ForeColor = System.Drawing.Color.Red;
                            lblMsg.Visible = true;
                        }
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }

    public void AddDay(int days)
    {
        try
        {
           // int days = Convert.ToInt32(txtDays.Text);
            if (days > 0)
            {
                int val = string.IsNullOrEmpty(txtDays.Text) ? 0 : days;

                string start = txtStart.Text;
                string end = DateTime.Parse(start).AddDays(val).ToString("dd/MM/yyyy");

                txtEnd.Text = end;
            }
            else
            {
                txtStart.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txtEnd.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txtDays.Text = "0";
            }
        }
        catch (Exception ex)
        {
            txtEnd.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
    }
}