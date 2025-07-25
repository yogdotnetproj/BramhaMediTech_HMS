using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;

public partial class EditDrugListForNurse :BasePage
{
     clsEmr obj = new clsEmr();
    clsTreatment objTreat = new clsTreatment();
    clsTreatmentTransaction transaction = new clsTreatmentTransaction();
    

   
 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["EmrRegNo"] != "")
            {
                string regId = Convert.ToString(Session["EmrRegNo"]);
                string name = Request.QueryString["Name"];
                string opd = Convert.ToString(Session["EmrOpdNo"]);
                string entrydate = Request.QueryString["EntryDate"];
                Session["Branchid"] = "1";
                lblOpd.Text = opd;
                PindPatientInformation();
                txtStart.Text = DateTime.Now.ToString("dd-MM-yyyy");
                txtTreatId.Value = "0";
                ViewState["TreatId"] = "0";
               
                Session["UID"] = rdbpkg.SelectedValue;
                txtFollowUp.Text = DateTime.Now.AddDays(7).ToString("dd/MM/yyyy");
                BindTreamentGrid(Convert.ToInt32(Request.QueryString["TreatmentId"]));
                //BindGridviewData();
            }
            else
            {
               // Response.Redirect(string.Format("EmergencyObservationListForNurse.aspx"));
            }
        }
        //else
        //{
        //    BindTreamentGrid(Convert.ToInt32(Request.QueryString["TreatmentId"]));
           
        //}
    }
    public void PindPatientInformation()
    {
        DataTable dt = new DataTable();
        dt = obj.Get_AllPatientInformation(Convert.ToString(Session["EmrRegNo"]), Convert.ToString(Session["EmrOpdNo"]), Convert.ToInt32(Session["EmrIpdNo"]), Convert.ToInt32(Session["Branchid"]));
        try
        {
            if (dt != null)
            {
                lblPatientName.Text = Convert.ToString(dt.Rows[0]["PatientName"]);
                txtpatientregid.Text = Convert.ToString(dt.Rows[0]["PatRegId"]);
                lblIpd.Text = Convert.ToString(dt.Rows[0]["IpdNo"]);
                lblOpd.Text = Convert.ToString(dt.Rows[0]["OpdNo"]);
                lblMobileNo.Text = Convert.ToString(dt.Rows[0]["MobileNo"]);
                lbldrname.Text = Convert.ToString(dt.Rows[0]["DrName"]);
                ViewState["DrId"] = Convert.ToInt32(dt.Rows[0]["DrId"]);
                lblAge.Text = Convert.ToString(dt.Rows[0]["Age"]) + "" + Convert.ToString(dt.Rows[0]["AgeType"]) + "/" + Convert.ToString(dt.Rows[0]["GenderName"]);

            }
            dt=new DataTable ();
            dt = obj.Get_AllPatientVitalTaken(Convert.ToString(Session["EmrRegNo"]), Convert.ToString(Session["EmrOpdNo"]), Convert.ToInt32(Session["EmrIpdNo"]), Convert.ToInt32(Session["Branchid"]));
            if (dt.Rows.Count > 0)
            {
               // lblvtaken.Text = Convert.ToString( dt.Rows[0]["CreatedOn"]);
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void BindTreamentGrid(int TreatmentId)
    {
        if (Convert.ToInt32(Session["EmrIpdNo"]) > 0)
        {
            GvNoteIngrid.DataSource = transaction.BindDrugList_IPD(TreatmentId);
            GvNoteIngrid.DataBind();
        }
        if (Convert.ToInt32(Session["EmrOpdNo"]) > 0)
        {
            GvNoteIngrid.DataSource = transaction.BindDrugList(TreatmentId);
            GvNoteIngrid.DataBind();
        }
       
    }

    


   

    

    [WebMethod]
    public static List<string> GetDrugsName(string prefixText)
    {
        clsTreatment objj = new clsTreatment();
        string Type = Convert.ToString(HttpContext.Current.Session["UID"]);

        DataTable dt = objj.GetDrugsMasterEmergency(prefixText,Type);
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

    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        try
        {
           
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
        
        
    }

    //private void BindTreamentGrid(int PatRegId)
    //{
    //    GvNoteIngrid.DataSource = transaction.GetTreatementDetails_Observ(PatRegId);
    //    GvNoteIngrid.DataBind();
    //    for (int i = 0; i < GvNoteIngrid.Rows.Count; i++)
    //    {

    //        if (i > 0)
    //        {

    //            if (GvNoteIngrid.DataKeys[i].Value.ToString().Trim() == GvNoteIngrid.DataKeys[i - 1].Value.ToString().Trim())
    //            {
    //                GvNoteIngrid.Rows[i].Cells[1].Text = "";
    //                GvNoteIngrid.Rows[i].Cells[2].Text = "";
    //               // GvNoteIngrid.Rows[i].Cells[2].Text = "";
    //            }
    //        }
    //    }
    //}
   

    private void Clear()
    {
        txtDrugName.Text = "";
        //drpfrequency.SelectedIndex = -1;
        txtQty.Text = "1";
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
       
    }

    
    protected void txtStart_TextChanged(object sender, EventArgs e)
    {
       
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
            //txtDays.Text = "0";
        }
        else
        {
            if (DateDifference() > 0)
            {
                //ValidateDays();
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

    


   
    

    private void ClearFields()
    {
        txtDrugName.Text = "";
        //drpfrequency.SelectedIndex = -1; ;
        //txtDays.Text = "0";
       // txtEnd.Text = txtStart.Text = DateTime.Now.ToString("dd-MM-yyyy");
        txtNote.Text = "";
        txtFollowUp.Text = DateTime.Now.AddDays(7).ToString("dd-MM-yyyy");
        ViewState["ItemId"] = "0";
        ViewState["TransId"] = "0";
        txtQty.Text = "1";

    }
    protected void btnAdd_Click(object sender, EventArgs e)
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
            
            string drugname = txtDrugName.Text;
         
            float Qty = Convert.ToSingle(txtQty.Text);
           
            string note = txtNote.Text.ToString().Trim();
          
            int ItemId = Convert.ToInt32(ViewState["ItemId"]);
            int TreatmentId = Convert.ToInt32(Request.QueryString["TreatmentId"]);

           

            
            if (Convert.ToInt32(ViewState["TransId"]) > 0)
            {

                transaction.UpdateDrugTransaction(drugname, Qty, note, ItemId, Convert.ToInt32(ViewState["TransId"]));
                lblMsg.Text = "Record Updated Successfully!!";
                BindTreamentGrid(TreatmentId);
                ClearFields();
            }
            else
            {
                if (!string.IsNullOrEmpty(drugname))// && !string.IsNullOrEmpty(startDate) && !string.IsNullOrEmpty(endDate) && Qty > 0
                {
                   
                        if (rdbpkg.SelectedValue == "Package")
                        {

                            DataTable dt = new DataTable();
                            int PackageId = Convert.ToInt32(ViewState["ItemId"]);
                            dt = objTreat.FillPackageDetails(PackageId);
                            if (dt.Rows.Count > 0)
                            {
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    ItemId = Convert.ToInt32(dt.Rows[i]["ItemId"]);
                                    Qty = Convert.ToSingle(dt.Rows[i]["Qty"]);
                                    drugname = Convert.ToString(dt.Rows[i]["ItemName"]);
                                    //transaction.InsertDrugTransaction(drugname, Qty, note, ItemId,TreatmentId);
                                    if (Convert.ToInt32(Session["EmrIpdNo"]) > 0)
                                    {
                                        transaction.InsertIPD_DrugTransaction(drugname, Qty, note, ItemId, TreatmentId);
                                    }
                                    if (Convert.ToInt32(Session["EmrOpdNo"]) > 0)
                                    {
                                        transaction.InsertDrugTransaction(drugname, Qty, note, ItemId, TreatmentId);
                                    }
                                }
                            }

                        }
                        else
                        {
                            if (Convert.ToInt32(Session["EmrIpdNo"]) > 0)
                            {
                                transaction.InsertIPD_DrugTransaction(drugname, Qty, note, ItemId, TreatmentId);
                            }
                            if (Convert.ToInt32(Session["EmrOpdNo"]) > 0)
                            {
                                transaction.InsertDrugTransaction(drugname, Qty, note, ItemId, TreatmentId);
                            }
                            
                        }

                    
                   
                    lblMsg.Text = "Record Saved Successfully";


                    BindTreamentGrid(TreatmentId);
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

   
    protected void btnReset_Click(object sender, EventArgs e)
    {
        btnAdd.Text = "Add";
        ClearFields();
        ViewState["rowId"] = -1;
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
                      "  PatientInformation.PatientAddress, PatientInformation.Age, PatientInformation.AgeType, tbl_TreatmentTransaction.DrugName, tbl_TreatmentTransaction.FrequencyType, tbl_TreatmentTransaction.Days, "+
                      "  tbl_TreatmentTransaction.StartDate, tbl_TreatmentTransaction.EndDate, tbl_TreatmentTransaction.Note, tbl_TreatmentTransaction.Dose ,HospEmpMst.Title+' '+ HospEmpMst.Empname as DrName, DepartmentMst.DeptName, HospEmpMst.EmployeeType , tbl_GeneralEmrTransaction.Diagnosis, HospEmpMst.DrSignature " +
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
        " where tbl_Treatment.TreatmentId=" + Convert.ToInt32(Request.QueryString["TreatmentId"]) + " and tbl_Treatment.branchid=" + Convert.ToInt32(Session["Branchid"]) + " and (tbl_Treatment.PatientRegId = " + Convert.ToString(Session["EmrRegNo"]) + ") AND (tbl_Treatment.Opd = " + Convert.ToString(Session["EmrOpdNo"]) + ")    ";//AND (tbl_Treatment.Ipd = "+Convert.ToString(Session["EmrIpdNo"])+")
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

    protected void rdbpkg_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["UID"] = rdbpkg.SelectedValue;
    }
    protected void GvNoteIngrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        clsTreatmentTransaction Obj = new clsTreatmentTransaction();
        int TransId = Convert.ToInt16(GvNoteIngrid.DataKeys[e.RowIndex].Values["TransId"].ToString());

        Obj.DeleteDrugTransaction(TransId);
        lblMsg.Text = "Record Deleted Successfully!!";
        BindTreamentGrid(Convert.ToInt32(Request.QueryString["TreatmentId"]));
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
            txtDrugName.Text=Convert.ToString(Obj.DrugName);
            txtQty.Text = Convert.ToString(Obj.Qty);
            txtNote.Text = Convert.ToString(Obj.Note);
            ViewState["ItemId"] = Convert.ToString(Obj.ItemId);
            



        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
         if (Convert.ToInt32(Session["EmrIpdNo"]) > 0)
        {
            Response.Redirect("IPDPatientDrugListForNurse.aspx", false);
        }
         if (Convert.ToInt32(Session["EmrOpdNo"]) > 0)
         {
             Response.Redirect("EmergencyObservationListForNurse.aspx",false);
         }
    }
}