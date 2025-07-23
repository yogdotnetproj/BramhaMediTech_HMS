
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
using System.IO;
using System.Drawing;

public partial class OPD_ReferToAdmission : System.Web.UI.Page
{
    clsEmr obj = new clsEmr();

    DataTable dt1 = new DataTable();
    DataTable dt2 = new DataTable();
    DataTable dt3 = new DataTable();
    DataTable dt = new DataTable();

    //DataTable dtChief = new DataTable();
    //DataTable dtVitals = new DataTable();
    //DataTable dtAllergies = new DataTable();
    //DataTable dtMedical = new DataTable();
    //DataTable dtSurgery = new DataTable();
    //DataTable dtPastHis = new DataTable();
    //DataTable dtPersHisl = new DataTable();
    //DataTable dtFamHis = new DataTable();
    //DataTable dtNote = new DataTable();
    //DataTable dtDiagno = new DataTable();
    //DataTable dtProvDiagno = new DataTable();
     DataTable tempDatatable = new DataTable();
     DAL ObjDal = new DAL();
    clsTreatment objTreat = new clsTreatment();
    clsTreatmentTransaction transaction = new clsTreatmentTransaction();

    BELBillDetails objBELBillDetail = new BELBillDetails();
    DALBillDetails objDALBillDetail = new DALBillDetails();
    BELOPDPatReg objBELOpdReg = new BELOPDPatReg();
    DALOpdReg objDALOpdReg = new DALOpdReg();
    double Billtotal = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if (Session["EmrRegNo"]!="" )
            {
                string regId = Convert.ToString( Session["EmrRegNo"]);
                string name = Request.QueryString["Name"];
                string opd =  Convert.ToString( Session["EmrOpdNo"]);
                string entrydate = Request.QueryString["EntryDate"];
                ViewState["Edit"] = "";
                ViewState["Types"] = "Add";
                txtTreatId.Value = "0";
                ViewState["TreatId"] = "0";
                Session["PType"] = 3;
                txtStart.Text = DateTime.Now.ToString("dd-MM-yyyy");
                FillRoomTypeDrop();
               // Session["Branchid"] = "1";
                PindPatientInformationInv();
                //lblPatientName.Text = name;
               // txtpatientregid.Text = regId;
              
               // lblOpd.Text = opd;
                if (Convert.ToString(Session["usertype"]) == "Doctor" || Convert.ToString(Session["usertype"]) == "Dr.Madhu")
                {
                   // btnSave.Enabled = true;
                }
              //  btnSave.Enabled = true;
                BindGridviewData();
                BindFrequencyDrop();
                PindPatientInformation();
                GetRecords_Diagnosis();
                GetRecords();
                MakeBillTable();
                DataTable dt = (DataTable)ViewState["BillTable"];
                gvBill.DataSource = dt;
                gvBill.DataBind();
            }
            else
            {
                Response.Redirect(string.Format("IPDListPatients.aspx"));
            }
            
        }
        else
        {
            BindGridviewData();
        }
    }
    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchConsultDoc(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        return objDALOpdReg.FillAllConsultDoc(prefixText);
    }
    protected void txtConsDoctorName_TextChanged(object sender, EventArgs e)
    {
        if (txtConsDoctorName.Text != "")
        {
            string[] PatientInfo = txtConsDoctorName.Text.Split('-');
            if (PatientInfo.Length > 1)
            {
                txtConsDoctorName.Text = PatientInfo[1];
                ViewState["ConsultID"] = PatientInfo[0];
            }
            else
            {
                ViewState["ConsultID"] = "0";

            }
        }
        else
        {
            ViewState["ConsultID"] = "0";

        }
    }
    protected void FillRoomTypeDrop()
    {
        ddlRoomTypeName.DataSource = obj.FillRoomTypeCombo();
        ddlRoomTypeName.DataTextField = "RType";
        ddlRoomTypeName.DataValueField = "RTypeId";
        ddlRoomTypeName.DataBind();
    }
    private DataTable GetRecords_Diagnosis()
    {
        string patientregid = Convert.ToString(Session["EmrRegNo"]);
        string opd = Convert.ToString(Session["EmrOpdNo"]);
        string ipd = Convert.ToString(Session["EmrIpdNo"]);
        string branchid = Convert.ToString(Session["Branchid"]);

        DataTable dt = new DataTable();
        try
        {
            dt = obj.GetGeneralEmrDetailsEdit(patientregid, opd, ipd, branchid);
            if (dt.Rows.Count > 0)
            {
                txtDiagnosisTreatment.Text = Convert.ToString(dt.Rows[0]["Diagnosis"]);
            }
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    private void MakeBillTable()
    {
        DataTable dt = new DataTable();
        dt.Clear();

        dt.Columns.Add("Service");
        dt.Columns.Add("EmpName");
        dt.Columns.Add("SingleBillServiceCharges");
        dt.Columns.Add("Qty");
        dt.Columns.Add("Charge");
        dt.Columns.Add("DrId");
        dt.Columns.Add("BillServiceId");
        dt.Columns.Add("MTCode");
        dt.Columns.Add("LabType");
        ViewState["BillTable"] = dt;
    }
   
    public void PindPatientInformation()
    {
        DataTable dt = new DataTable();
        dt = obj.Get_AllPatientInformation(Convert.ToString(Session["EmrRegNo"]), Convert.ToString(Session["EmrOpdNo"]),Convert.ToInt32( Session["EmrIpdNo"]), Convert.ToInt32(Session["Branchid"]));
        try
        {
            if (dt != null)
            {
                ViewState["DrName"] = Convert.ToString(dt.Rows[0]["DrName"]);
                ViewState["ConsultID"] = Convert.ToInt32(dt.Rows[0]["DrId"]);

                ViewState["DrId"] = Convert.ToInt32(dt.Rows[0]["DrId"]);
                Session["DrId"] = ViewState["DrId"];
            }
        //        lblPatientName.Text = Convert.ToString(dt.Rows[0]["PatientName"]);
        //        txtpatientregid.Text = Convert.ToString( dt.Rows[0]["PatRegId"]);
        //       // lblIpd.Text = "0";
        //        //lblOpd.Text = Convert.ToString(dt.Rows[0]["PatRegId"]);
        //        lblOpd.Text = Convert.ToString(dt.Rows[0]["OpdNo"]);
        //        lblMobileNo.Text = Convert.ToString(dt.Rows[0]["MobileNo"]);
        //        lbldrname.Text = Convert.ToString(dt.Rows[0]["DrName"]);
        //        string Birthdate = Convert.ToString(dt.Rows[0]["BirthDate"]);
        //        Birthdate = DateTime.Parse(Birthdate).ToString("dd/MM/yyyy");
        //        getAge(Birthdate);
        //        //lblAge.Text = Convert.ToString(dt.Rows[0]["Age"]) + "" + Convert.ToString(dt.Rows[0]["AgeType"]) + "/" + Convert.ToString(dt.Rows[0]["GenderName"]);
        //        lblAge.Text =lblAge.Text +"/" + Convert.ToString(dt.Rows[0]["GenderName"]);
        //        lblVisitingNo.Text = Convert.ToString(dt.Rows[0]["VisitingNo"]);
        //        lblToken.Text = Convert.ToString(dt.Rows[0]["TokenNo"]);
        //        lblDept.Text = Convert.ToString(dt.Rows[0]["DeptName"]);
        //        ViewState["DrId"] = Convert.ToInt32(dt.Rows[0]["DrId"]);
        //        lblAddress.Text = Convert.ToString(dt.Rows[0]["PatientAddress"]);
                
        //    }
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
    //        lblAge.Text = intYear.ToString() +" Years";
    //        //ddlAge.SelectedIndex = 0;
    //    }
    //    else if (intMonth > 0)
    //    {
    //        lblAge.Text = intMonth.ToString() + " Months";
    //        //ddlAge.SelectedIndex = 1;
    //    }
    //    else if (intDays > 0)
    //    {
    //        lblAge.Text = intDays.ToString()+ " Days";
    //       // ddlAge.SelectedIndex = 2;
    //    }
    //}
    private void GetRadios()
    {
        try
        {
            DataSet ds = obj.ReadDataHistoryList();

            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    dt1 = ds.Tables[0];
                    dt2 = ds.Tables[1];
                    dt3 = ds.Tables[2];
                }
            }
        }
        catch (Exception)
        {
        }
    }

  
    private DataTable GetRecords()
    {
        string patientregid = Convert.ToString(Session["EmrRegNo"]);
        string opd = Convert.ToString(Session["EmrOpdNo"]);
        string ipd = Convert.ToString(Session["EmrIpdNo"]);
        string regId = Convert.ToString(Session["EmrRegNo"]);
        string name = Request.QueryString["Name"];
       // string opd = Convert.ToString(Session["EmrIpdNo"]);
        string branchid = Convert.ToString( Session["Branchid"]);
        string Usertype = Convert.ToString(Session["usertype"]);
        string createdby = Convert.ToString(Session["Name"]).Trim();
        DataTable dt = new DataTable();
        try
        {
            dt = obj.GetDailyDrNote_ReferToAdmission(patientregid, ipd, branchid, Usertype, createdby.Trim());
            GvNoteIngrid.DataSource = dt;
            GvNoteIngrid.DataBind();
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

   
    private void ErrorMessage(string msg)
    {
        lblMsg.Text = msg; lblMsg.Visible = true; lblMsg.ForeColor = System.Drawing.Color.Red;
    }

    private void SuccessMessage(string msg)
    {
        lblMsg.Text = msg; lblMsg.Visible = true; lblMsg.ForeColor = System.Drawing.Color.Green;
    }
   

    

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            //string regId = txtpatientregid.Text.ToString();
            //string opd = !string.IsNullOrEmpty(lblOpd.Text.ToString()) ? lblOpd.Text.ToString() : "0";
            //string ipd = !string.IsNullOrEmpty(lblIpd.Text.ToString()) ? lblIpd.Text.ToString() : "0";

            string regId = Convert.ToString(Session["EmrRegNo"]);
            string opd = Convert.ToString(Session["EmrOpdNo"]);
            string ipd = Convert.ToString(Session["EmrIpdNo"]);

            string branch = Convert.ToString(Session["Branchid"]);
            string name = "";
            string entry =  DateTime.Now.ToString("dd/MM/yyyy");

            string createdby = Convert.ToString(Session["Name"]).Trim(); ;
            string createdon = DateTime.Now.ToString("dd/MM/yyyy");
            string updatedby = Convert.ToString(Session["username"]); ;
            string updatedon = DateTime.Now.ToString("dd/MM/yyyy");
            string WardName="";
            if(ddlRoomTypeName.SelectedItem.Text!="Select Room Type")
            {
                WardName=ddlRoomTypeName.SelectedItem.Text;
            }

            obj.SaveEmr_DailyDrNote_ReferToAdmission(regId, ipd, Editor1.Text, createdby, branch, Convert.ToString(Session["FId"]), ddlPlan.SelectedItem.Text, txtdiagnosis.Text, txtRemarks.Text, txtinvdetails.Text, txttreatmentshow.Text, opd, txtConsDoctorName.Text, WardName,txtbedName.Text);
                btnSave.Text = "Save";
                GetRecords();
                SuccessMessage("Record Save successfully!.");
                ClearFields();
        }
        catch (Exception ex)
        {
            ErrorMessage(ex.Message);
        }
    }

    private void ClearFields()
    {
        Editor1.Text = "";
        txtRemarks.Text = "";
        txtdiagnosis.Text = "";
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        ClearFields();
    }

    protected void GvNoteIngrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GetRecords();
    }
    protected void txtService_TextChanged(object sender, EventArgs e)
    {
        //if (txtConsDoctorName_New.Text != "")
        //{
        if (txtService.Text != "")
        {
            RBLLabType.Enabled = false;
            string[] Service = txtService.Text.Split('=');
            if (Service.Length > 1)
            {                

                if (Service.Length == 7)
                {
                    txtService.Text = Service[1] + " " + Service[2];
                    ViewState["Charges"] = Service[3];
                    ViewState["LabType"] = RBLLabType.SelectedValue; //Service[5];
                    ViewState["ServiceId"] = Service[6];
                }
                if (Service.Length == 6)
                {
                    txtService.Text = Service[1];
                    ViewState["Charges"] = Service[2];
                    ViewState["LabType"] = RBLLabType.SelectedValue; //Service[4];
                    ViewState["ServiceId"] = Service[5];
                }
                ViewState["MTCode"] = Service[0];
               // txtTotalCharges.Text = Convert.ToString(Convert.ToDecimal(txtCharges.Text) * Convert.ToDecimal(txtQty.Text));
              

               // this.btnAdd_Click(null, null);
                AddToGridView();
                txtinvdetails.Text = txtinvdetails.Text + ", " + txtService.Text;
                txtService.Text = "";
            }
         
        }
       
    }
    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchService(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();

        string Type = Convert.ToString(HttpContext.Current.Session["PatientSubCategoryID"]);
        string PType = Convert.ToString(HttpContext.Current.Session["PType"]);

        if (Convert.ToString(Type) == "")
        {
            Type = "1";
        }
        if (Convert.ToString(PType) == "")
        {
            PType = "0";
            // string AA = "Test already added.";
            //ScriptManager.RegisterStartupScript( null, "", "", "<script>alert('" + AA.ToString() + "');</script>", false);
            // ScriptManager.RegisterStartupScript(this, this.GetType(), "", "<script>alert('" + AA.ToString() + "');</script>", false);
        }
        return objDALOpdReg.FillAllLAbService_Name_Charges(prefixText, Type, Convert.ToInt32(PType));


    }
    private void AddToGridView()
    {
        
            DataTable dt = (DataTable)ViewState["BillTable"];
            // TableTestWise = (DataTable)ViewState["TableTestWise"];
            if (ViewState["Edit"] != "")
            {
                int index = Convert.ToInt32(ViewState["Index"]);
                dt.Rows[index]["Service"] = txtService.Text;
                dt.Rows[index]["Qty"] = "1";
                dt.Rows[index]["SingleBillServiceCharges"] = "0";
                dt.Rows[index]["Charge"] = "0";
                if (Convert.ToInt32(ViewState["ServiceId"]) == 0)
                {
                    dt.Rows[index]["BillServiceId"] = Convert.ToInt32(dt.Rows[index]["BillServiceId"]);
                }
                else
                {
                    dt.Rows[index]["BillServiceId"] = Convert.ToInt32(ViewState["ServiceId"]);
                }
                if (Convert.ToString(ViewState["MTCode"]) == "")
                {
                    dt.Rows[index]["MTCode"] = Convert.ToString(dt.Rows[index]["MTCode"]);
                }
                else
                {
                    dt.Rows[index]["MTCode"] = Convert.ToString(ViewState["MTCode"]);
                }
                if (Convert.ToInt32(ViewState["ConsultID"]) == 0)
                {
                    dt.Rows[index]["DrId"] = Convert.ToInt32(dt.Rows[index]["DrId"]);
                }
                else
                {
                    dt.Rows[index]["DrId"] = ViewState["ConsultID"];
                }
                if (Convert.ToString(ViewState["LabType"]) == "")
                {
                    dt.Rows[index]["LabType"] = Convert.ToString(dt.Rows[index]["LabType"]);
                }
                else
                {
                    dt.Rows[index]["LabType"] = Convert.ToString(ViewState["LabType"]);
                }
            }
            else
            {

                DataRow dr = dt.NewRow();

                dr["DrId"] = Convert.ToInt32(ViewState["ConsultID"]);
                if (Convert.ToInt32(ViewState["ConsultID"]) == 0)
                {
                    dr["Empname"] = "";
                }
                else
                {
                    dr["Empname"] = Convert.ToString( ViewState["DrName"]);
                }


                dr["Qty"] = "1";
                dr["SingleBillServiceCharges"] = ViewState["Charges"];

                dr["BillServiceId"] = Convert.ToInt32(ViewState["ServiceId"]);
                dr["Service"] = txtService.Text;
                dr["Charge"] = Convert.ToSingle( ViewState["Charges"])* 1;
                dr["MTCode"] = Convert.ToString(ViewState["MTCode"]);
                dr["LabType"] = Convert.ToString(ViewState["LabType"]);
                bool alreadyExist = false;
                // foreach (DataRow dr1 in dt.Rows)
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["MTCode"].ToString().Trim() == Convert.ToString(ViewState["MTCode"]).Trim())
                    {
                        alreadyExist = true;
                        break;
                    }
                }
                if (alreadyExist)
                {
                    string AA = "Test already added.";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "", "<script>alert('" + AA.ToString() + "');</script>", false);
                }
                else
                {
                    dt.Rows.Add(dr);
                }
            }
            ViewState["BillTable"] = dt;

            gvBill.DataSource = dt;
            gvBill.DataBind();
          
        
    }
    protected void gvBill_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvBill.PageIndex = e.NewPageIndex;
        AddToGridView();
    }
    protected void gvBill_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataTable dt = (DataTable)ViewState["BillTable"];
        int index = Convert.ToInt32(e.RowIndex);

        dt.Rows.RemoveAt(index);
        // dt.Rows[index].Delete();
        if (dt.Rows.Count > 0)
        {
            gvBill.DataSource = dt;
            gvBill.DataBind();
        }
        else
        {
            MakeBillTable();
            dt = (DataTable)ViewState["BillTable"];
            gvBill.DataSource = dt;
            gvBill.DataBind();

        }



        string Message = "1Record Deleted Sucessfully";
       // DynamicMessage(lblMessage, Message);
    }
    protected void gvBill_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int index = Convert.ToInt32(e.NewEditIndex);
        DataTable dt = ViewState["BillTable"] as DataTable;

        //txtService.Text = dt.Rows[index]["Service"].ToString();
        //txtConsDoctorName.Text = dt.Rows[index]["EmpName"].ToString();
        //txtQty.Text = dt.Rows[index]["Qty"].ToString();
        //txtCharges.Text = dt.Rows[index]["SingleBillServiceCharges"].ToString(); ;
        //txtTotalCharges.Text = dt.Rows[index]["Charge"].ToString();

        int DrId = Convert.ToInt32(dt.Rows[index]["DrId"]);
        ViewState["ConsultID"] = DrId;

        int BillServiceId = Convert.ToInt32(dt.Rows[index]["BillServiceId"]);
        ViewState["BillServiceId"] = BillServiceId;
        string MTCode = Convert.ToString(dt.Rows[index]["MTCode"]);
        ViewState["MTCode"] = MTCode;
        string LabType = Convert.ToString(dt.Rows[index]["LabType"]);
        ViewState["LabType"] = LabType;

        ViewState["Index"] = index;
        ViewState["Edit"] = "1";
        ViewState["BillTable"] = dt;
        e.Cancel = true;
    }
    protected void gvBill_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void gvBill_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Billtotal += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Charge"));
            ViewState["Total"] = Billtotal;
            //DiscountToatl += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "DiscountGiven"));
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {

            e.Row.Cells[4].Text = "Total";
            e.Row.Cells[4].Font.Bold = true;
            //e.Row.Cells[8].HorizontalAlign.Equals("Right");
            e.Row.Cells[5].Text = Billtotal.ToString();
            e.Row.Cells[5].Font.Bold = true;
        }
    }
    protected void btnSaveInv_Click(object sender, EventArgs e)
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
        
            if (gvBill.Rows.Count > 0)
            {
                InsertRecortToAll();
            }
            RBLLabType.Enabled = true;
    }
    public void PindPatientInformationInv()
    {
        DataTable dt = new DataTable();
        dt = obj.Get_AllPatientInformationInv_ReferToAdmision(Convert.ToString(Session["EmrRegNo"]), Convert.ToInt32(Session["Branchid"]));
        try
        {
            if (dt != null)
            {
                //txtPatientName.Text = Convert.ToString(dt.Rows[0]["FirstName"]);
                //txtPatientAddress.Text = Convert.ToString(dt.Rows[0]["PatientAddress"]);
                //ddlTitleName.SelectedValue = Convert.ToString(dt.Rows[0]["TitleId"]);
                //this.ddlTitleName_SelectedIndexChanged(null, null);

                //if (Convert.ToString(dt.Rows[0]["AgeType"]) == "Years")
                //{
                //    ddlAge.SelectedItem.Text = "Year";
                //}
                //else if (Convert.ToString(dt.Rows[0]["AgeType"]) == "Months")
                //{
                //    ddlAge.SelectedItem.Text = "Month";
                //}
                //else if (Convert.ToString(dt.Rows[0]["AgeType"]) == "Days")
                //{
                //    ddlAge.SelectedItem.Text = "Day";
                //}
                //else
                //{
                //    ddlAge.SelectedItem.Text = Convert.ToString(dt.Rows[0]["AgeType"]);
                //}


                
                string Birthdate = Convert.ToString(dt.Rows[0]["BirthDate"]);
                ViewState["BirthDate"] = DateTime.Parse(Birthdate).ToString("dd/MM/yyyy");
                // getAge(Birthdate);
                // lblAge.Text = Convert.ToString(dt.Rows[0]["Age"]) + "" + Convert.ToString(dt.Rows[0]["AgeType"]) + "/" + Convert.ToString(dt.Rows[0]["GenderName"]);
                // // lblAge.Text = lblAge.Text + "/" + Convert.ToString(dt.Rows[0]["GenderName"]);
                // lblVisitingNo.Text = "0"; // Convert.ToString(dt.Rows[0]["VisitingNo"]);
                // lblToken.Text = "0";// Convert.ToString(dt.Rows[0]["TokenNo"]);
                // lblDept.Text = Convert.ToString(dt.Rows[0]["DeptName"]);
                ViewState["DrId"] = Convert.ToInt32(dt.Rows[0]["DrId"]);
                // lblAddress.Text = Convert.ToString(dt.Rows[0]["PatientAddress"]);
                ViewState["RefByDrName"] = Convert.ToString(dt.Rows[0]["DrName"]);
                ViewState["RefBy"] = Convert.ToInt32(dt.Rows[0]["DrId"]);


                ViewState["PatientInfoId"] = Convert.ToString(Request.QueryString["RegId"]);
                //Ipd.Visible = true;
                //Opd.Visible = false;
                //lblOpd.Visible = false;
                //lblIpd.Text = Convert.ToString(dt.Rows[0]["IpdNo"]);
                //lblMobileNo.Text = Convert.ToString(dt.Rows[0]["MobileNo"]);
                // ViewState["Initial"] = PatientInfo[1];
                //ViewState["Sex"] = PatientInfo[4];
            }
        }
        catch (Exception ex)
        {

        }
    }
    private void InsertRecortToAll()
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
        if (gvBill.Rows.Count <= 0)
        {
            AddToGridView();

           // txtCharges.Text = "";
        }
        object[] returns;
        string Message = "";
        //if (rdbgroup.SelectedValue != "" && rdbgroup.SelectedValue != null)
        //{
        objBELOpdReg = WriteDO();
        if (Request.QueryString["Flag"] != "AddBill")
        {
            returns = objDALOpdReg.InsertEMR_LabPatientRegistration_ReferToAdmission(objBELOpdReg);
            ViewState["LabNo"] = Convert.ToInt32(returns[0]);
        }

        //lblVisitingNo.Text = "Your Reg No is :"+ViewState["PatientInfoId"]+" , Lab No is " + ViewState["LabNo"] + " and visiting No is " + Convert.ToString(objBELOpdReg.VisitingNo);


        // InsertInBill();//
        InsertInBillDetail();
        lblMsg.Text = "Investigation send successfully!";
        SuccessMessage("Revord save successfully!.");
        gvBill.DataSource = null;
        gvBill.DataBind();
    }

    protected BELOPDPatReg WriteDO()
    {
        objBELOpdReg = new BELOPDPatReg();

        objBELOpdReg.PatRegId = Convert.ToInt32(Convert.ToString(Session["EmrRegNo"]));
        objBELOpdReg.PatMainTypeId = Convert.ToInt32(1);
        objBELOpdReg.PatientInsuTypeId = Convert.ToInt32(1);
        objBELOpdReg.BillAmount = Convert.ToDecimal(ViewState["Total"]);
        objBELOpdReg.BillGroup = "Lab Bill";

        //objBELOpdReg.DrId = Convert.ToInt32(ViewState["ConsultID"]);
        objBELOpdReg.DrId = Convert.ToInt32(ViewState["RefBy"]);
        objBELOpdReg.VisitingNo = objDALOpdReg.GetMaxVisitingNo(objBELOpdReg);
        objBELOpdReg.TokenNo = objDALOpdReg.GetTokenNo(objBELOpdReg);
        objBELOpdReg.ReferenceDrName = "";
        objBELOpdReg.ReferBy = Convert.ToString( ViewState["RefByDrName"]);
         objBELOpdReg.LabPtype = RBLLabType.SelectedValue; ;
        //objBELOpdReg.DeptId = Convert.ToInt32(ddlDepartment.SelectedValue);
        objBELOpdReg.DeptId = Convert.ToInt32(0);
        if (Convert.ToString(Session["EmrIpdNo"]) != "0")
        {
            objBELOpdReg.IpdNo = Convert.ToInt32(Session["EmrIpdNo"]);
            objBELOpdReg.OpdNo = 0;
        }
        else
        {
            objBELOpdReg.OpdNo = Convert.ToInt32(Session["EmrOpdNo"]);
            objBELOpdReg.IpdNo = 0;
        }

        objBELOpdReg.ClinicalHistory = Convert.ToString("");


        objBELOpdReg.DiscountAmt = 0;



        objBELOpdReg.PaidAmt = Convert.ToDecimal(0);


        objBELOpdReg.ReasonForDiscountId = 0;


        objBELOpdReg.DiscountGivenById = Convert.ToInt32(0);


        objBELOpdReg.ReasonForBalanceId = 0;



        objBELOpdReg.InsuranceAmount = 0;


        objBELOpdReg.CreatedBy = Convert.ToString(Session["username"]);
        objBELOpdReg.BranchId = Convert.ToInt32(Session["Branchid"]);
        objBELOpdReg.FId = Convert.ToInt32(Session["FId"]);

        objBELOpdReg.MainDoctor = Convert.ToString("");

        objBELOpdReg.IsEmergency = false; ;


        objBELOpdReg.WardName = Convert.ToString("");

        return objBELOpdReg;
    }

    private void InsertInBillDetail()
    {

        string Message = "";
        DataTable dt = (DataTable)ViewState["BillTable"];
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            objBELBillDetail = new BELBillDetails();

            objBELBillDetail.PatRegId = Convert.ToInt32(Session["EmrRegNo"]);
            objBELBillDetail.BillNo = Convert.ToInt32(0);
            objBELBillDetail.BillGroupName = "";
            if (Convert.ToInt32(dt.Rows[i]["BillServiceId"]) > 0)
                objBELBillDetail.BillServiceId = Convert.ToInt32(dt.Rows[i]["BillServiceId"]);
            objBELBillDetail.EmployeeId = Convert.ToInt32(dt.Rows[i]["DrId"]);
            if ((dt.Rows[i]["Qty"]) != "")
                objBELBillDetail.Qty = Convert.ToDecimal(dt.Rows[i]["Qty"]);
            else
                objBELBillDetail.Qty = 1;
            if (dt.Rows[i]["Charge"] != "")
                objBELBillDetail.TotalCharges = Convert.ToDecimal(ViewState["Total"]);
            if (dt.Rows[i]["SingleBillServiceCharges"] != "")
                objBELBillDetail.Charges = Convert.ToDecimal(dt.Rows[i]["SingleBillServiceCharges"]);
            objBELBillDetail.CreatedBy = Convert.ToString(Session["username"]);
            objBELBillDetail.BranchId = Convert.ToInt32(Session["Branchid"]);
            objBELBillDetail.FId = Convert.ToInt32(Session["FId"]);
            objBELBillDetail.ProcedureId = Convert.ToInt32(ViewState["ProcedureId"]);

            // objBELBillDetail.OpdNo = Convert.ToInt32(0);
            // objBELBillDetail.IpdNo = Convert.ToInt32(0);

            if (Convert.ToString(Session["EmrIpdNo"]) != "0")
            {
                objBELBillDetail.IpdNo = Convert.ToInt32(Session["EmrIpdNo"]);
                objBELBillDetail.OpdNo = 0;
            }
            else
            {
                objBELBillDetail.OpdNo = Convert.ToInt32(0);
                objBELBillDetail.IpdNo = 0;
            }
            objBELBillDetail.LabNo = Convert.ToInt32(ViewState["LabNo"]);
            objBELBillDetail.ReceiptNo = Convert.ToInt32(0);
            objBELBillDetail.MTCode = Convert.ToString(dt.Rows[i]["MTCode"]);

            objBELBillDetail.LabPtype = Convert.ToString(dt.Rows[i]["LabType"]);

            if (Convert.ToString(ViewState["Initial"]) != "")
            {
                objBELBillDetail.Initial = Convert.ToString(ViewState["Initial"]);
            }
            else
            {
                objBELBillDetail.Initial = Convert.ToString("");
            }
            if (Convert.ToString(ViewState["Sex"]) != "")
            {
                objBELBillDetail.Sex = Convert.ToString(ViewState["Sex"]);
            }
            else
            {
                objBELBillDetail.Sex = Convert.ToString("");
            }

            objBELBillDetail.PatientName = Convert.ToString("");
            objBELBillDetail.Age = Convert.ToString("0");
            objBELBillDetail.RefDoc = Convert.ToString(dt.Rows[i]["DrId"]);
            objBELBillDetail.TestName = Convert.ToString(dt.Rows[i]["Service"]);
            if (dt.Rows[i]["Charge"] != "")
                objBELBillDetail.TestRate = Convert.ToSingle(dt.Rows[i]["Charge"]);

           
            objBELBillDetail.MobileNo = Convert.ToString("");

            if (Convert.ToString(ViewState["Age"]) != "")
            {
                objBELBillDetail.MDY = Convert.ToString(ViewState["Age"]);
            }
            else
            {
                objBELBillDetail.MDY = Convert.ToString("");
            }
            objBELBillDetail.ReferBy = Convert.ToString(ViewState["RefBy"]).Trim();

            objBELBillDetail.ReferPhy = Convert.ToString("").Trim();
            objBELBillDetail.OtherRefDoc = Convert.ToString("").Trim();

            objBELBillDetail.OtherRefDoc = Convert.ToString("").Trim();
           
                objBELBillDetail.InsuranceID = Convert.ToInt32(0);
            
           
                objBELBillDetail.InsuranceAmt = Convert.ToSingle(0);
            
           
                objBELBillDetail.MainDocId = 999;
            
                 objBELBillDetail.PaidAmt = Convert.ToSingle(0);
                objBELBillDetail.BalanceAmt = Convert.ToSingle(0);
                objBELBillDetail.DiscountAmt = Convert.ToSingle(0);
            
            objBELBillDetail.ModeOfPay = "1";
             objBELBillDetail.LabPtype = RBLLabType.SelectedValue;

            objBELBillDetail.PatAddress = Convert.ToString("").Trim();

            objBELBillDetail.PatBirthDate = Convert.ToDateTime(ViewState["BirthDate"]);
            
            objBELBillDetail.ClinicalHistory = Convert.ToString("").Trim();

            Message = objDALBillDetail.InsertEMR_LabServiceDetail_ReferToAdmission(objBELBillDetail);
           // DynamicMessage(lblMessage, Message);

        }
    }

    protected void RBLLabType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RBLLabType.SelectedValue == "P")
        {
            Session["PType"] = 1;
        }
        if (RBLLabType.SelectedValue == "R")
        {
            Session["PType"] = 2;
        }
        if (RBLLabType.SelectedValue == "M")
        {
            Session["PType"] = 3;
        }
       // LoadMainDoctor();
    }
    //========================= Pharmacy ==================
    protected void drpfrequency_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    //protected void rdbpkg_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    Session["UID"] = rdbpkg.SelectedValue;
    //}
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
            float Qty;
            float Times;
            if (txtDays.Text != "")
            {
                Qty = ObjDal.GetDoseTimes(Convert.ToInt32(ddlDoseTime.SelectedValue));
                Times = ObjDal.GetDoseQuantity(Convert.ToInt32(drpfrequency.SelectedValue));

                if (txtnewDose.Text != "")
                {
                    if (txtnewDose.Text != "0")
                    {
                        txtQty.Text = Convert.ToString(Math.Round(Qty * Convert.ToSingle(txtnewDose.Text) * Convert.ToSingle(txtDays.Text)));
                    }
                    else
                    {
                        txtQty.Text = Convert.ToString(Math.Round(Qty * Times * Convert.ToSingle(txtDays.Text)));
                    }
                }
                else
                {
                    txtQty.Text = Convert.ToString(Math.Round(Qty * Times * Convert.ToSingle(txtDays.Text)));
                }
            }
        }
        catch (Exception ex)
        {
            txtEnd.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
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
                if (Convert.ToInt32(Item[2]) < 1)
                {
                    txtDrugName.BorderColor = System.Drawing.Color.Red;
                    lblMsg.Text = "Drug currently not available at our pharmacy,for more info please call Pharmacy !";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    txtDrugName.BorderColor = System.Drawing.Color.Green;
                    lblMsg.Text = "";

                }
               
            }
        }
        else
        {
            ViewState["ItemId"] = "0";
        }
    }
    public void Add_Treatment()
    {
        try
        {
            float Qty = 0;
            string drugname = txtDrugName.Text;
            string freq = drpfrequency.SelectedItem.ToString();
            int days = Convert.ToInt32(txtDays.Text);
            string startDate = txtStart.Text.ToString();
            string endDate = txtEnd.Text.ToString();
            string note = txtNote.Text.ToString().Trim();
            string Dose = ddlDoseTime.SelectedItem.Text.Trim();
            int DoseId = Convert.ToInt32(drpfrequency.SelectedValue);
            int DoseTimeId = Convert.ToInt32(ddlDoseTime.SelectedValue);
            int ItemId = Convert.ToInt32(ViewState["ItemId"]);
            string InstName = ddlinstruction.SelectedItem.Text.Trim();
            string NewDose = txtnewDose.Text.Trim();
            string Route = ddlRoute.SelectedItem.Text.Trim();
            if (txtQty.Text != "")
            {
                Qty = Convert.ToSingle(txtQty.Text);
            }
            tempDatatable = (DataTable)ViewState["tempDatatable"];
            if (Convert.ToInt32(ViewState["TransId"]) > 0)
            {

                transaction.UpdateTreatementTransaction(drugname, DoseId, Dose, DoseTimeId, Convert.ToString(days), note, ItemId, Convert.ToInt32(ViewState["TransId"]), freq, InstName, NewDose, Route);
                lblMsg.Text = "Record Updated Successfully!!";
               // BindTreamentGrid(Convert.ToInt32(Session["EmrRegNo"]), Convert.ToInt32(Session["EmrOpdNo"]), Convert.ToInt32(Session["EmrIpdNo"]));
              //  ClearTreatment();
            }
            else
            {
                if (!string.IsNullOrEmpty(drugname) && !string.IsNullOrEmpty(freq) && !string.IsNullOrEmpty(Dose) && !string.IsNullOrEmpty(startDate)
                    && !string.IsNullOrEmpty(endDate) && days >= 0)
                {
                    if (Convert.ToString( ViewState["Types"]) == "Add")
                    {
                        //CreateNewTable(drugname,freq,days.ToString(),startDate,endDate,note);

                        tempDatatable.Rows.Add(tempDatatable.Rows.Count + 1, drugname, Dose, freq, days, startDate, endDate, note, DoseTimeId, DoseId, ItemId, Qty, InstName, NewDose, Route);

                        
                    }
                    else if (Convert.ToString( ViewState["Types"]) == "Update")
                    {
                        int rowId = ViewState["rowId"] != null ? (int)ViewState["rowId"] : -1;
                        if (rowId >= 0)
                        {
                            string idd = "Id=" + rowId;

                            DataRow row = tempDatatable.NewRow();

                            if (row != null)
                            {
                                tempDatatable.Rows.RemoveAt(rowId);

                                tempDatatable.Rows.Add(rowId, drugname, Dose, freq, days, startDate, endDate, note, DoseTimeId, DoseId, ItemId, Qty, InstName, NewDose, Route);
                                gvTempTable.EditIndex = -1;
                                ViewState["rowId"] = -1;
                               // btnAdd.Text = "Add";
                            }


                        }
                    }
                    lblMsg.Text = "";

                    ViewState["tempDatatable"] = tempDatatable;
                    gvTempTable.DataSource = tempDatatable;
                    gvTempTable.DataBind();

                   // txttreatmentshow.Text = txttreatmentshow.Text + ", " + txtDrugName.Text + " = " + ddlDoseTime.SelectedItem.Text + " -  " + drpfrequency.SelectedItem.Text + " -  " + txtDays.Text + " Days -" + txtNote.Text + "\r\n";// + " - " + txtnewDose.Text
                    txttreatmentshow.Text = txttreatmentshow.Text + ", " + txtDrugName.Text + "=" + txtnewDose.Text + " " + drpfrequency.SelectedItem.Text + " - " + ddlDoseTime.SelectedItem.Text + " -  " + ddlRoute.SelectedItem.Text + "  For " + txtDays.Text + "  Days " + "\r\n";// + " - " + txtnewDose.Text

                    txtDrugName.Text = "";
                    drpfrequency.SelectedIndex = -1; ;
                    txtDays.Text = "0";
                    txtEnd.Text = txtStart.Text = DateTime.Now.ToString("dd-MM-yyyy");
                    txtNote.Text = "";
                    txtFollowUp.Text = DateTime.Now.AddDays(7).ToString("dd-MM-yyyy");
                    txtQty.Text = "";
                    //ddlinstruction.SelectedValue = "0";
                    txtnewDose.Text = "";

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

    protected void gvTempTable_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

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
                string dosetime = gvTempTable.Rows[rowIndex].Cells[7].Text.Trim();
                string doseQty = gvTempTable.Rows[rowIndex].Cells[8].Text.Trim();
                ViewState["ItemId"] = gvTempTable.Rows[rowIndex].Cells[9].Text.Trim();

                ddlinstruction.SelectedItem.Text = gvTempTable.Rows[rowIndex].Cells[10].Text.Trim();
                if (gvTempTable.Rows[rowIndex].Cells[11].Text.Trim() == "&nbsp;")
                {
                    txtnewDose.Text = "";
                }
                else
                {
                    txtnewDose.Text = gvTempTable.Rows[rowIndex].Cells[11].Text.Trim();
                }

                txtDrugName.Text = drug;
                drpfrequency.SelectedIndex = drpfrequency.Items.IndexOf(drpfrequency.Items.FindByText(freq));
                txtDays.Text = days;
                ddlDoseTime.SelectedValue = dosetime;
                drpfrequency.SelectedValue = doseQty;
                //txtStart.Text = start;
                //txtEnd.Text = end;
                if (note == "&nbsp;")
                {
                    txtNote.Text = "";
                }
                else
                {
                    txtNote.Text = note;
                }

                ViewState["Types"]="Update";

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
    protected void gvTempTable_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void gvTempTable_RowEditing(object sender, GridViewEditEventArgs e)
    {
        e.Cancel = true;
        gvTempTable.DataSource = tempDatatable;
        gvTempTable.DataBind();

    }
    protected void btnTreatment_Click(object sender, EventArgs e)
    {
        try
        {
            if (tempDatatable != null && tempDatatable.Rows.Count > 0)
            {
                int recId = string.IsNullOrEmpty(txtTreatId.Value) ? 0 : Convert.ToInt32(txtTreatId.Value);
                string ttype = (recId == 0) ? "Insert" : "Update";

                string[] dtt = System.DateTime.Now.ToShortDateString().Split('/');
                string[] followDate = txtFollowUp.Text.Split('-');

                objTreat.patientId = Convert.ToString(Session["EmrRegNo"]);
                objTreat.ipd = Convert.ToString(Session["EmrIpdNo"]);
                objTreat.opd = Convert.ToString(Session["EmrOpdNo"]);
                objTreat.branchId = Convert.ToString(Session["Branchid"]);
                objTreat.followUp = followDate[2] + "-" + followDate[1] + "-" + followDate[0];
                objTreat.createdBy = Convert.ToString(Session["username"]);
                objTreat.createdOn = dtt[2] + "-" + dtt[1] + "-" + dtt[0];
                objTreat.treatId = recId.ToString();
                objTreat.updatedBy = Convert.ToString(Session["username"]);
                objTreat.updatedOn = dtt[2] + "-" + dtt[1] + "-" + dtt[0];
                objTreat.DrId = Convert.ToInt32(ViewState["DrId"]);
                objTreat.DiscMedication = false;
                objTreat.IsApproveByNurse = true;
                objTreat.WardName = "";
                objTreat.Diagnosis = Convert.ToString(txtDiagnosisTreatment.Text);
                int res = 0;
                if (objTreat.getallreadyIPDRecPayment_New_ReferToAdmission(DateTime.Now.AddMinutes(-1), Convert.ToInt32(Session["EmrRegNo"]), Convert.ToInt32(Session["EmrIpdNo"]), Convert.ToInt32(Session["EmrOpdNo"])))
                {
                    res = objTreat.InsertUpdateDeleteMain_ReferToAdmission(ttype);
                    if (res == 0)
                    {
                        DataTable dtid = new DataTable();
                        dtid = transaction.GetTreatmentIDFor_PatientId_ReferToAdmission(Convert.ToString(Session["EmrRegNo"]), Convert.ToString(Session["EmrOpdNo"]), Convert.ToString(Session["EmrIpdNo"]));
                        if (dtid.Rows.Count > 0)
                        {
                            res = Convert.ToInt32(dtid.Rows[0]["TreatmentId"]);
                        }
                    }
                    ViewState["res"] = res;
                }
                else
                {
                    res = Convert.ToInt32(ViewState["res"]);
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

                        transaction.InstName = Convert.ToString(tempDatatable.Rows[i]["InstName"]);

                        transaction.NewDose = Convert.ToString(tempDatatable.Rows[i]["NewDose"]);

                        transaction.NurseOrder = Convert.ToBoolean(0);
                        transaction.Route = Convert.ToString(tempDatatable.Rows[i]["Route"]);
                        if (transaction.TransId == "0")
                        {
                            int r = transaction.InsertUpdateDeleteMain_ReferToAdmission("Insert");
                            if (r > 0)
                            {
                                lblMsg.Text = "Record inserted successfully.";
                                lblMsg.ForeColor = System.Drawing.Color.Green;
                                lblMsg.Visible = true;
                                SuccessMessage("Drug Add successfully!.");
                            }
                            else
                            {
                                lblMsg.Text = "Failed to insert t.";
                                lblMsg.ForeColor = System.Drawing.Color.Red;
                                lblMsg.Visible = true;
                            }
                        }
                    }
                    gvTempTable.DataSource = null;
                    gvTempTable.DataBind();
                   // BindTreamentGrid(Convert.ToInt32(objTreat.patientId), Convert.ToInt32(Session["EmrOpdNo"]), Convert.ToInt32(Session["EmrIpdNo"]));

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
    public OPD_ReferToAdmission()
    {
        tempDatatable = CreateTable();
    }
    private DataTable CreateTable()
    {
        tempDatatable.Columns.Add("Id", typeof(Int32));
        tempDatatable.Columns.Add("DrugName", typeof(string));
        tempDatatable.Columns.Add("Dose", typeof(string));
        tempDatatable.Columns.Add("Frequency", typeof(string));
        tempDatatable.Columns.Add("Days", typeof(Int32));
        tempDatatable.Columns.Add("StartDate", typeof(string));
        tempDatatable.Columns.Add("EndDate", typeof(string));
        tempDatatable.Columns.Add("Note", typeof(string));
        tempDatatable.Columns.Add("DoseTimeId", typeof(Int32));
        tempDatatable.Columns.Add("DoseId", typeof(Int32));
        tempDatatable.Columns.Add("ItemId", typeof(Int32));
        tempDatatable.Columns.Add("Qty", typeof(float));

        tempDatatable.Columns.Add("InstName", typeof(string));
        tempDatatable.Columns.Add("NewDose", typeof(string));
        tempDatatable.Columns.Add("Route", typeof(string));
        ViewState["tempDatatable"] = tempDatatable;

        return tempDatatable;
    }
    protected void BindGridviewData()
    {
        if (ViewState["tempDatatable"] != null)
        {
            tempDatatable = (DataTable)ViewState["tempDatatable"];
        }
        gvTempTable.DataSource = tempDatatable;
        gvTempTable.DataBind();
    }
    [WebMethod]
    public static List<string> GetDrugsName(string prefixText)
    {
        clsTreatment objj = new clsTreatment();
        string Type = Convert.ToString("Drug");
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

    public void PindPatientInformation_Drug()
    {
        dt = new DataTable();
        dt = obj.Get_AllPatientInformation(Convert.ToString(Session["EmrRegNo"]), Convert.ToString(Session["EmrOpdNo"]), Convert.ToInt32(Session["EmrIpdNo"]), Convert.ToInt32(Session["Branchid"]));
        try
        {
            if (dt != null)
            {
                //            lblPatientName.Text = Convert.ToString(dt.Rows[0]["PatientName"]);
                //            txtpatientregid.Text = Convert.ToString(dt.Rows[0]["PatRegId"]);
                //            lblIpd.Text = Convert.ToString(dt.Rows[0]["IpdNo"]);
                //            lblOpd.Text = Convert.ToString(dt.Rows[0]["OpdNo"]);
                //            lblMobileNo.Text = Convert.ToString(dt.Rows[0]["MobileNo"]);
                //            lbldrname.Text = Convert.ToString(dt.Rows[0]["DrName"]);
                ViewState["DrId"] = Convert.ToInt32(dt.Rows[0]["DrId"]);
                Session["DrId"] = ViewState["DrId"];
                //            lblAge.Text = Convert.ToString(dt.Rows[0]["Age"]) + "" + Convert.ToString(dt.Rows[0]["AgeType"]) + "/" + Convert.ToString(dt.Rows[0]["GenderName"]);

                //        }
                //        dt=new DataTable ();
                //        dt = obj.Get_AllPatientVitalTaken(Convert.ToString(Session["EmrRegNo"]), Convert.ToString(Session["EmrOpdNo"]), 0, Convert.ToInt32(Session["Branchid"]));
                //        if (dt.Rows.Count > 0)
                //        {
                //            lblvtaken.Text = Convert.ToString( dt.Rows[0]["CreatedOn"]);
            }
        }
        catch (Exception ex)
        {

        }
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

        ddlinstruction.DataSource = objTreat.GetInstruction();
        ddlinstruction.DataValueField = "InstId";
        ddlinstruction.DataTextField = "InstName";
        ddlinstruction.DataBind();

        ddlRoute.DataSource = objTreat.Fill_Route();
        ddlRoute.DataValueField = "Id";
        ddlRoute.DataTextField = "Route";
        ddlRoute.DataBind();

     //dt= objTreat.Get_DailyDrNote_Investigation(Convert.ToString(Session["EmrIpdNo"]));
     //txtinvdetails.Text = Convert.ToString(dt.Rows[0]["products"]);
     //dt = objTreat.GetDrNoteTreatment(Convert.ToString(Session["EmrIpdNo"]));
     //txttreatmentshow.Text = Convert.ToString(dt.Rows[0]["products"]);


    }
    protected void btnAddTreat_Click(object sender, EventArgs e)
    {
        Add_Treatment();
    }
}