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

using ZXing;
using ZXing.QrCode;
using ZXing.Common;

public partial class Edit_RadiologyRegistration :BasePage
{
    clsEmr obj = new clsEmr();
    BELPatientInformation objBELPatInfo = new BELPatientInformation();
    DALPatientInformation objDALPatInfo = new DALPatientInformation();

    BELOPDPatReg objBELOpdReg = new BELOPDPatReg();
    DALOpdReg objDALOpdReg = new DALOpdReg();

    BELBillInfo objBELBillInfo = new BELBillInfo();
    DALBillInfo objDALBillInfo = new DALBillInfo();

    BELPayment objBELPayment = new BELPayment();

    BELBillDetails objBELBillDetail = new BELBillDetails();
    DALBillDetails objDALBillDetail = new DALBillDetails();

    BELBillCharges objBELBillCharges = new BELBillCharges();
    DALBillCharges objDALBillCharges = new DALBillCharges();

    BELBillService objBELBillService = new BELBillService();

    public enum MessageType { Success, Error, Info, Warning };


    string RegistrationTypeId = "";
    string UserId = "";


    string BillGroupId = "";
    string ServiceId = "";
    string ConsultantDrId = "";
    int DoctorId;
    double Billtotal = 0;
    string BirthDate = "";
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["PaidAmt"] = "False";
            Session["PatientId"] = 0;
            hfPatientId.Value = "0";
            ViewState["PatientInfoId"] = "0";
            ViewState["ServiceId"] = 0;
            ViewState["IsDirect"] = false;
            ViewState["ConsultID"] = 0;
            ViewState["Edit"] = "";
            InsuranceDetails.Visible = false;
            txtQty.Text = "1";
            Session["UID"] = "";
            LoadPatientMainType();
            ddlPatientCategoryName_SelectedIndexChanged(null, null);
            LoadTitleName();
            LoadGenderName();
            LoadConsultantDoc();
            
            LoadRdbPaymentType();
            LoadDiscountGivenBy();
            LoadReasonForDiscount();
            LoadReasonForBalance();
            LoadMainDoctor();
            RdbPayment.SelectedValue = "1";
            rdbdiscAmt.Checked = true;
            PaymentDetails.Visible = false;
            InsuranceDetails.Visible = false;
      
           
           
            MakeBillTable();
            DataTable dt = (DataTable)ViewState["BillTable"];
            gvBill.DataSource = dt;
            gvBill.DataBind();


            string PatientInfoId = Request.QueryString["PatRegId"];
            ViewState["PatientInfoId"] = PatientInfoId;
            ViewState["OpdNo"] = Request.QueryString["OpdNo"];
            // fillInformation();
            BIND_EMR_PatientInformation();
            txtPatientName.Enabled = false;
            ddlPatientCategoryName.Enabled = false;
            ddlPatientSubCategoryName.Enabled = false;
            txtMobileNo.Enabled = false;
            txtAge.Enabled = false;
            txtPatientAddress.Enabled = false;
          
           
                ddlPatientCategoryName.Enabled = true;
                ddlPatientSubCategoryName.Enabled = true;
           
           
        }

        //this.RegisterPostBackControl();
    }

    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchPatient(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        return objDALOpdReg.FillAllPatientFullName(prefixText);
    }
    //[ScriptMethod()]
    //[WebMethod]
    //public static List<string> SearchGroup(string prefixText, int count)
    //{
    //    DALOpdReg objDALOpdReg = new DALOpdReg();

    //    string Type = Convert.ToString(HttpContext.Current.Session["UID"]);
    //    Type = "OPD";
    //    return objDALOpdReg.FillAllGroup(prefixText, Type);


    //}


    public void BIND_EMR_PatientInformation()
    {
        DataTable dt = new DataTable();
        dt = obj.Get_All_Radiology_PatientInformation(Convert.ToString(Request.QueryString["PatRegId"]), Convert.ToString(Request.QueryString["LabNo"]), Convert.ToInt32(Session["Branchid"]));
        try
        {
            if (dt != null)
            {
                RBLLabType.SelectedValue = Convert.ToString(dt.Rows[0]["LabPtype"]);
                this.RBLLabType_SelectedIndexChanged(null,null);
                txtPatientName.Text = Convert.ToString(dt.Rows[0]["FirstName"]);
                txtPatientAddress.Text = Convert.ToString(dt.Rows[0]["PatientAddress"]);
                ddlTitleName.SelectedValue = Convert.ToString(dt.Rows[0]["TitleId"]);
                this.ddlTitleName_SelectedIndexChanged(null, null);

               // ddlAge.SelectedItem.Text = Convert.ToString(dt.Rows[0]["AgeType"]);
                if (Convert.ToString(dt.Rows[0]["AgeType"]) == "Years")
                {
                    ddlAge.SelectedItem.Text = "Year";
                }
                else if (Convert.ToString(dt.Rows[0]["AgeType"]) == "Months")
                {
                    ddlAge.SelectedItem.Text = "Month";
                }
                else if (Convert.ToString(dt.Rows[0]["AgeType"]) == "Days")
                {
                    ddlAge.SelectedItem.Text = "Day";
                }
                else
                {
                    ddlAge.SelectedItem.Text = Convert.ToString(dt.Rows[0]["AgeType"]);
                }
                ddlPatientCategoryName.SelectedValue = Convert.ToString(dt.Rows[0]["PatientMainCategoryId"]);
                this.ddlPatientCategoryName_SelectedIndexChanged(null, null);
                ddlPatientSubCategoryName.SelectedValue = Convert.ToString(dt.Rows[0]["PatientsubCategoryId"]);

                txtMobileNo.Text = Convert.ToString(dt.Rows[0]["MobileNo"]);
               // lbldrname.Text = Convert.ToString(dt.Rows[0]["DrName"]);
                string Birthdate = Convert.ToString(dt.Rows[0]["BirthDate"]);
                txtBirthDate.Text = DateTime.Parse(Birthdate).ToString("dd/MM/yyyy");
                getAge(Birthdate);
               // lblAge.Text = Convert.ToString(dt.Rows[0]["Age"]) + "" + Convert.ToString(dt.Rows[0]["AgeType"]) + "/" + Convert.ToString(dt.Rows[0]["GenderName"]);
               // ddlAge.SelectedItem.Text = Convert.ToString(dt.Rows[0]["AgeType"]);
               // lblVisitingNo.Text = Convert.ToString(dt.Rows[0]["VisitingNo"]);
                //lblToken.Text = Convert.ToString(dt.Rows[0]["TokenNo"]);
                //lblDept.Text = Convert.ToString(dt.Rows[0]["DeptName"]);
                ViewState["DrId"] = Convert.ToInt32(dt.Rows[0]["DrId"]);
               // lblAddress.Text = Convert.ToString(dt.Rows[0]["PatientAddress"]);
                txtRefBy.Text = Convert.ToString(dt.Rows[0]["ReferBy"]);
                ViewState["RefBy"] = Convert.ToInt32(dt.Rows[0]["DrId"]);


                ViewState["PatientInfoId"] = Convert.ToString(Request.QueryString["PatRegId"]);
                // ViewState["Initial"] = PatientInfo[1];
                //ViewState["Sex"] = PatientInfo[4];
            }
        }
        catch (Exception ex)
        {

        }
         dt = new DataTable();
         dt = obj.Get_All_Radiologyt_Test(Convert.ToString(Request.QueryString["PatRegId"]), Convert.ToString(Request.QueryString["LabNo"]), Convert.ToInt32(Session["Branchid"]));
        try
        {
            if (dt.Rows.Count > 0)
            {
                DataTable dtService = (DataTable)ViewState["BillTable"];
                for (int P = 0; P < dt.Rows.Count; P++)
                {
                    DataRow dr = dtService.NewRow();

                    dr["DrId"] = Convert.ToInt32(dt.Rows[P]["DrId"]);
                    if (Convert.ToInt32(ViewState["ConsultID"]) == 0)
                    {
                        dr["Empname"] = "";
                    }
                    else
                    {
                        dr["Empname"] = Convert.ToString(dt.Rows[P]["ReferBy"]); ;
                    }


                    dr["Qty"] = "1";
                    dr["SingleBillServiceCharges"] = Convert.ToString(dt.Rows[P]["BillServiceCharges"]);

                    dr["BillServiceId"] = Convert.ToInt32(0);
                    dr["Service"] = Convert.ToString(dt.Rows[P]["ServiceName"]);
                    dr["Charge"] = Convert.ToString(dt.Rows[P]["BillServiceCharges"]);
                    dr["MTCode"] = Convert.ToString(dt.Rows[P]["MTCode"]);
                  
                    dr["OPDNO"] = Convert.ToString("0");
                    dr["IPDNO"] = Convert.ToString(dt.Rows[P]["IPDNO"]);
                    dr["ClinicalHistory"] = Convert.ToString(dt.Rows[P]["ClinicalHistory"]);

                    bool alreadyExist = false;
                    // foreach (DataRow dr1 in dt.Rows)
                    for (int i = 0; i < dtService.Rows.Count; i++)
                    {
                        if (dtService.Rows[i]["MTCode"].ToString().Trim() == Convert.ToString(dr["MTCode"]).Trim())
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
                        dtService.Rows.Add(dr);
                    }
                }


                ViewState["BillTable"] = dtService;

                gvBill.DataSource = dtService;
            gvBill.DataBind();
            }
        }
        catch (Exception ex)
        {

        }

        dt = new DataTable();
        dt = obj.Get_All_Radiologyt_Bill_Charges(Convert.ToString(Request.QueryString["PatRegId"]), Convert.ToString(Request.QueryString["LabNo"]), Convert.ToInt32(Session["Branchid"]));
        if (dt.Rows.Count > 0)
        {
            txtbalance.Text = Convert.ToString(dt.Rows[0]["BalanceAmt"]);
            txtAmount.Text = Convert.ToString(dt.Rows[0]["BillAmount"]);
            txtTotalAmt.Text = Convert.ToString(dt.Rows[0]["BillAmount"]);
            txtInsuranceAmt.Text = Convert.ToString(dt.Rows[0]["InsuranceAmount"]);
            txtDiscount.Text = Convert.ToString(dt.Rows[0]["DiscountAmt"]);
        }
    }
    public void getAge(string Birthdate)
    {
        int intYear, intMonth, intDays;
        DateTime Birthday = Convert.ToDateTime(Birthdate);
        intYear = Birthday.Year;
        intMonth = Birthday.Month;
        intDays = Birthday.Day;

        DateTime dtt = Convert.ToDateTime(Birthdate);

        DateTime td = DateTime.Now;
        int Leap_Year = 0;
        for (int i = dtt.Year; i < td.Year; i++)
        {
            if (DateTime.IsLeapYear(i))
            {
                ++Leap_Year;
            }
        }
        TimeSpan timespan = td.Subtract(Birthday);
        intDays = timespan.Days - Leap_Year;
        int intResult = 0;
        intYear = Math.DivRem(intDays, 365, out intResult);
        intMonth = Math.DivRem(intResult, 30, out intResult);
        intDays = intResult;
        if (intYear > 0 && intDays > 0)
        {
            txtAge.Text = intYear.ToString();
            //ddlAge.SelectedIndex = 0;
        }
        else if (intMonth > 0)
        {
            txtAge.Text = intMonth.ToString();
            //ddlAge.SelectedIndex = 1;
        }
        else if (intDays > 0)
        {
            txtAge.Text = intDays.ToString();
            // ddlAge.SelectedIndex = 2;
        }
    }

    private void LoadDiscountGivenBy()
    {
        ddlDiscountGivenBy.DataSource = objDALBillInfo.FillDiscountGivenby();
        ddlDiscountGivenBy.DataValueField = "DrId";
        ddlDiscountGivenBy.DataTextField = "EmpName";
        ddlDiscountGivenBy.DataBind();
    }
    protected void fillInformation()
    {
        objBELPatInfo = objDALPatInfo.SelectOne(Convert.ToInt32(ViewState["PatientInfoId"]));

        txtPatientName.Text = objBELPatInfo.FirstName;
       
        txtBirthDate.Text = Convert.ToDateTime(objBELPatInfo.BirthDate).ToShortDateString();
        txtPatientAddress.Text = objBELPatInfo.PatientAddress;
        txtMobileNo.Text = objBELPatInfo.MobileNo;
        if (Convert.ToDouble(objBELPatInfo.Age) < 0.084)
        {
            txtAge.Text = Convert.ToString(Math.Round((Convert.ToDecimal(objBELPatInfo.Age) * 12) * 30));
            ddlAge.SelectedValue = "Day";
        }
        else if (Convert.ToDouble(objBELPatInfo.Age) < 1) 
        {
            txtAge.Text = Convert.ToString(Math.Round(Convert.ToDecimal(objBELPatInfo.Age) * 12));
            ddlAge.SelectedValue = "Month";
        }
        else
        {
            txtAge.Text = Convert.ToString(Math.Round(Convert.ToDecimal(objBELPatInfo.Age)));
            ddlAge.SelectedValue = "Year";
        }
        ViewState["Age"] = ddlAge.SelectedValue;
        ddlTitleName.SelectedValue = Convert.ToString(objBELPatInfo.TitleId);
        ddlGender.SelectedValue = Convert.ToString(objBELPatInfo.GenderId);
        objBELPatInfo = objDALPatInfo.SelectOneDr(Convert.ToInt32(ViewState["PatientInfoId"]), Convert.ToInt32( ViewState["OpdNo"]));
        txtdepartment.Text = objBELPatInfo.DeptName;
        txtConsDoctorName_New.Text = objBELPatInfo.DocName;
        txtEmail.Text = objBELPatInfo.Email;
        ViewState["ConsultID"] = Convert.ToInt32( objBELPatInfo.DrId);
        ViewState["DeptID"] =  objBELPatInfo.DeptId;
        
    }
    private void LoadPatientMainType()
    {
        ddlPatientCategoryName.DataSource = objDALPatInfo.FillPatMainTypeDrop();
        ddlPatientCategoryName.DataTextField = "PatMainType";
        ddlPatientCategoryName.DataValueField = "PatMainTypeId";
        ddlPatientCategoryName.DataBind();
    }

    private void LoadPatientSubCategoryName()
    {
        ddlPatientSubCategoryName.DataSource = objDALPatInfo.FillPatInsuTypeDrop(Convert.ToInt32(ViewState["PatientCategoryID"]));
        ddlPatientSubCategoryName.DataTextField = "PatientInsuType";
        ddlPatientSubCategoryName.DataValueField = "PatientInsuTypeId";
        ddlPatientSubCategoryName.DataBind();
    }

   
    private void LoadReasonForDiscount()
    {

        ddlDiscReason.DataSource = objDALBillInfo.FillReasonForDiscount();
        ddlDiscReason.DataValueField = "DiscTypeId";
        ddlDiscReason.DataTextField = "DiscType";
        ddlDiscReason.DataBind();

    }
    private void LoadReasonForBalance()
    {

        ddlBalreason.DataSource = objDALBillInfo.FillReasonForBalance();
        ddlBalreason.DataValueField = "ReasonForBalanceId";
        ddlBalreason.DataTextField = "ReasonForBalanceName";
        ddlBalreason.DataBind();

    }
    private void LoadRdbPaymentType()
    {

        RdbPayment.DataSource = objDALBillInfo.FillModeOfPayment();
        RdbPayment.DataValueField = "ModeOfPaymentId";
        RdbPayment.DataTextField = "ModeOfPaymentName";
        RdbPayment.DataBind();


    }
    private void LoadMainDoctor()
    {
        DataTable dtMainDoc = new DataTable();
        string PType = Convert.ToString(HttpContext.Current.Session["PType"]);

        if (Convert.ToString(PType) == "0")
        {
            PType = "0";
        }
        if (Convert.ToString(PType) != "0")
        {
            dtMainDoc = objDALOpdReg.Bind_MainDoctor(PType);
            if (dtMainDoc.Rows.Count > 0)
            {
                DdlMainDoctor.DataSource = dtMainDoc;
                DdlMainDoctor.DataTextField = "Name";
                DdlMainDoctor.DataValueField = "DrId";
                DdlMainDoctor.DataBind();
                DdlMainDoctor.Items.Insert(0, new ListItem("Select MainDoc", "0"));
            }
        }
    }
    private void LoadConsultantDoc()
    {

        ddlConsDoctorName.DataSource = objDALOpdReg.FillConsultantDocName();
        ddlConsDoctorName.DataValueField = "DrId";
        ddlConsDoctorName.DataTextField = "EmpName";
        ddlConsDoctorName.DataBind();


   
        
        //ddlBillGroup.DataSource = objDALOpdReg.GetBillGroup();
        //ddlBillGroup.DataValueField = "BillGroupId";
        //ddlBillGroup.DataTextField = "GroupName";
        //ddlBillGroup.DataBind();
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
        dt.Columns.Add("OPDNO");
        dt.Columns.Add("IPDNO");
        dt.Columns.Add("ClinicalHistory"); 
        ViewState["BillTable"] = dt;
    }
    private void SetCommonCharges()
    {
        if (Convert.ToString(ViewState["ServiceID"]).Equals(string.Empty))
            objBELBillCharges.BillServiceId = 0;
        else
            objBELBillCharges.BillServiceId = Convert.ToInt32(Convert.ToString(ViewState["ServiceID"]));
        txtCharges.Text = objDALBillCharges.GetCommonCharges(Convert.ToInt32(hfPatientId.Value), objBELBillCharges);

    }
    private void GetDoctorId()
    {
        object[] returns;
        string Message = "";
        returns = objDALBillCharges.GetDoctorId(Convert.ToInt32(ViewState["ServiceID"]));
        Message = Convert.ToString(returns[0]);
        ViewState["DoctorId"] = Convert.ToInt32(returns[1]);
    }
    private void SetCharges()
    {

        int BranchId = Convert.ToInt32(Session["Branchid"]);
        int FId = Convert.ToInt32(Session["FId"]);

        txtCharges.Text = objDALBillCharges.GetDocCharges(Convert.ToInt32(ViewState["ConsultID"]), Convert.ToInt32(ViewState["ServiceId"]), Convert.ToInt32(ddlPatientSubCategoryName.SelectedValue), BranchId, FId);

    }
    private void SetChargesForDirectService()
    {

        int BranchId = Convert.ToInt32(Session["Branchid"]);
        int FId = Convert.ToInt32(Session["FId"]);
        string Charges;
         Charges= objDALBillCharges.GetDocCharges(0, Convert.ToInt32(ViewState["ServiceId"]), Convert.ToInt32(ddlPatientSubCategoryName.SelectedValue), BranchId, FId);
         if (Charges == "")
         { 
             txtCharges.Text = "0";
         }
         else
         {
             txtCharges.Text = Charges;
         }


    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        AddToGridView();
        
        txtCharges.Text = "";
        txtTotalCharges.Text = "";
        txtService.Text = "";
        txtTotalAmt.Text = Convert.ToString(ViewState["Total"]);
        txtPaid.Text = Convert.ToString(ViewState["Total"]);
        txtAmount.Text = Convert.ToString(ViewState["Total"]);
        txtDiscount.Text = "0";
        txtbalance.Text = "0";
    }
    private void AddToGridView()
    {
        string BB = RBLLabType.SelectedValue;
        if (txtRefBy.Text == "")
        {
            string AA = "Select Ref By.";
            txtRefBy.Focus();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "<script>alert('" + AA.ToString() + "');</script>", false);
        }
        else if (BB == "")
        {
            string AA = "Select Main Group.";
            RBLLabType.Focus();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "<script>alert('" + AA.ToString() + "');</script>", false);
        }
        else
        {
            DataTable dt = (DataTable)ViewState["BillTable"];
            // TableTestWise = (DataTable)ViewState["TableTestWise"];
            if (ViewState["Edit"] != "")
            {
                int index = Convert.ToInt32(ViewState["Index"]);
                dt.Rows[index]["Service"] = txtService.Text;
                dt.Rows[index]["Qty"] = txtQty.Text;
                dt.Rows[index]["SingleBillServiceCharges"] = txtCharges.Text;
                dt.Rows[index]["Charge"] = txtTotalCharges.Text;
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
                dt.Rows[index]["OPDNO"] = Convert.ToString("0");
                dt.Rows[index]["IPDNO"] = Convert.ToString(dt.Rows[index]["IPDNO"]);
                dt.Rows[index]["ClinicalHistory"] = Convert.ToString(dt.Rows[index]["ClinicalHistory"]);
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
                    dr["Empname"] = txtConsDoctorName.Text;
                }


                dr["Qty"] = txtQty.Text;
                dr["SingleBillServiceCharges"] = txtCharges.Text;

                dr["BillServiceId"] = Convert.ToInt32(ViewState["ServiceId"]);
                dr["Service"] = txtService.Text;
                dr["Charge"] = txtTotalCharges.Text;
                dr["MTCode"] = Convert.ToString(ViewState["MTCode"]);
                dr["OPDNO"] = Convert.ToString("0");
                dr["IPDNO"] = Convert.ToString(0);
                dr["ClinicalHistory"] = Convert.ToString("");

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
            Clear();
        }
    }
    public void Clear()
    {
        ViewState["ServiceId"] = 0;
        ViewState["MTCode"] = "";
       // ViewState["ConsultID"] = 0;
        txtQty.Text = "1";
        txtService.Text = "";
        txtConsDoctorName.Text = "";
        txtCharges.Text = "0";
        txtTotalCharges.Text ="0";

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
        DynamicMessage(lblMessage, Message);
    }
    protected void ddlPatientCategoryName_SelectedIndexChanged(object sender, EventArgs e)
    {
        int PatientCategoryId = Convert.ToInt32(ddlPatientCategoryName.SelectedValue);
        ViewState["PatientCategoryID"] = PatientCategoryId;
        LoadPatientSubCategoryName();
        if (Convert.ToInt32(ddlPatientCategoryName.SelectedValue) != 1)
        {
            InsuranceDetails.Visible = true;
        }
        else
        {
            InsuranceDetails.Visible = true;
        }
    }
    protected void ddlPatientSubCategoryName_SelectedIndexChanged(object sender, EventArgs e)
    {
        int PatientSubCategoryId = Convert.ToInt32(ddlPatientSubCategoryName.SelectedValue);
        ViewState["PatientSubCategoryID"] = PatientSubCategoryId;
        Session["PatientSubCategoryID"] = PatientSubCategoryId;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {

        if (Convert.ToString(ViewState["PaidAmt"]) != "true")
        {
            if (gvBill.Rows.Count > 0)
            {
                if (Convert.ToDouble(txtAmount.Text) < Convert.ToDouble(txtPaid.Text))
                {
                    lblvalidate.Text = "Paid amount should not be greater than total amount!";
                    txtPaid.Focus();
                    ShowMessage("Paid amount should not be greater than total amount!", MessageType.Warning);
                    return;
                }
                if (txtDiscount.Text == "")
                {
                    txtDiscount.Text = "0";
                }
                if (txtDiscount.Text != "0")
                {
                    if (ddlDiscReason.SelectedValue == "0")
                    {
                        lblvalidate.Text = "Select reason for Disc!";
                        lblMessage.Text = "Select reason for Disc!";
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        ddlDiscReason.Focus();
                        ShowMessage("Select reason for Disc!", MessageType.Warning);
                        return;
                    }
                    if (ddlDiscountGivenBy.SelectedValue == "0")
                    {
                        lblvalidate.Text = "Select Disc Given By!";
                        lblMessage.Text = "Select Disc Given By!";
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        ShowMessage("Select Disc Given By!", MessageType.Warning);
                        ddlDiscountGivenBy.Focus();
                        return;
                    }
                }
            
                string Message = "";

                if (Convert.ToInt32(ViewState["PatientInfoId"]) > 0)
                {
                    InsertRecortToAll();
                    // PrintReport();
                   // OPDPrintReport();//
                    ViewState["PaidAmt"] = "true";
                    Session["PType"] = "0";
                    ShowMessage("Record Save Successfully!", MessageType.Success);
                    Response.Redirect("RadiologyBillPayment.aspx", false);
                }
                else
                {
                    lblMessage.Text = "Pls Register patients .";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    ShowMessage("Pls Register patients!", MessageType.Warning);
                }
            }


        }
        else
        {
            //PrintReport();
            lblMessage.Text = "Record is already Saved";
            lblMessage.ForeColor = System.Drawing.Color.Red;
            ShowMessage("Record is already saved!", MessageType.Warning);
        }

       }
   
    protected BELPatientInformation WriteToPatientReg()
    {
        objBELPatInfo = new BELPatientInformation();
        objBELPatInfo.CreatedBy = Convert.ToString(Session["username"]);
       

        objBELPatInfo.FirstName = txtPatientName.Text.Trim();

        objBELPatInfo.PatRegId = Convert.ToString(ViewState["PatientInfoId"]);

        objBELPatInfo.BarcodeId = "";

        if (ViewState["TitleID"] != null)
            objBELPatInfo.TitleId = 0;
        objBELPatInfo.PatMainTypeId = Convert.ToInt32(ddlPatientCategoryName.SelectedValue);
        objBELPatInfo.PatientInsuTypeId = Convert.ToInt32(ddlPatientSubCategoryName.SelectedValue);
        objBELPatInfo.PolicyNo = "";
        

        objBELPatInfo.GenderId = 0;
        if (BirthDate == "")
        {
            objBELPatInfo.BirthDate = null;
        }
        else
        {
            
            objBELPatInfo.BirthDate = Convert.ToDateTime(BirthDate);
        }
        if (txtAge.Text != "")
        {
            objBELPatInfo.Age = txtAge.Text;
        }
        else
        {
            objBELPatInfo.Age = "";
        }

        objBELPatInfo.IsConfirmBirthDate = false;
        objBELPatInfo.BloodGroupId = 0;
        objBELPatInfo.MaritalStatusId = 0;
        // objBELPatInfo.GuardianTitleId = 0;
        //objBELPatInfo.GuardianName = "";
        objBELPatInfo.MobileNo = txtMobileNo.Text.Trim();
        objBELPatInfo.PatientAddress = txtPatientAddress.Text;

        objBELPatInfo.CountryId = 1;
        objBELPatInfo.StateId = 1;
        objBELPatInfo.CityId = 1;

        objBELPatInfo.Email = "";
     
        // objBELPatInfo.EntryDate =Convert.ToDateTime(txtRegistrationDate.Text);
        objBELPatInfo.ImagePath = Convert.ToString(ViewState["PhotoPath"]);

        return objBELPatInfo;
    }

    private void GetPatientID()
    {

        int returns = objDALPatInfo.GetPrnBarcodeNo();
        ViewState["PatientInfoId"] = Convert.ToString(returns + 1);
        int PrnBarCode = returns + 1;
        //txtPrnNo.Text = Convert.ToString(Session["HospitalName"]) + '-' + Convert.ToString(PrnBarCode) + '-' + Convert.ToString(Session["FinancialYear"]);
        //txtBarCodeId.Text = Convert.ToString(PrnBarCode);
        ViewState["PRNNo"] = Convert.ToString(PrnBarCode);
        ViewState["BarcodeId"] = Convert.ToString(PrnBarCode);

    }

    

    private void InsertRecortToAll()
    {
        if (gvBill.Rows.Count <= 0)
        {
            AddToGridView();
                 
            txtCharges.Text = "";
        }
        object[] returns;
        string Message = "";
        //if (rdbgroup.SelectedValue != "" && rdbgroup.SelectedValue != null)
        //{
            objBELOpdReg = WriteDO();

            objDALOpdReg.UpdateRadiologyPatient_Details(objBELOpdReg);
           
           // ViewState["BillNo"] = Convert.ToInt32(returns[1]);
           // lblVisitingNo.Text = "Your Reg No is :"+ViewState["PatientInfoId"]+" , Lab No is " + ViewState["LabNo"] + " and visiting No is " + Convert.ToString(objBELOpdReg.VisitingNo);

            //returns = objDALOpdReg.InsertProcedureMaster(objBELOpdReg);
            //ViewState["BillNo"] = Convert.ToInt32(returns[1]);
            //ViewState["ProcedureId"] = Convert.ToInt32(returns[0]);

            //InsertInProcedureTransaction();
            InsertInBill();//
           // InsertInBillDetail();

         DataTable HmsReg = new DataTable();
        string PType = Convert.ToString(HttpContext.Current.Session["PType"]);

        if (Convert.ToString(PType) == "0")
        {
            PType = "0";
        }
        if (Convert.ToString(PType) != "0")
        {
           
            HmsReg = objDALOpdReg.Get_LabRegisterNo(PType, Convert.ToString(ViewState["PatientInfoId"]));
            if (HmsReg.Rows.Count > 0)
            {
                GenerateQRCode(Convert.ToString( HmsReg.Rows[0]["Patregid"]));
            }
        }
        //    if (RBLLabType.SelectedValue == "R" )
        //    {
        //         DataTable dtMainDoc = new DataTable();
        //string PType = Convert.ToString(HttpContext.Current.Session["PType"]);

        //if (Convert.ToString(PType) == "0")
        //{
        //    PType = "0";
        //}
        //if (Convert.ToString(PType) != "0")
        //{
        //    dtMainDoc = objDALOpdReg.Bind_MainDoctor(PType);
        //    if (dtMainDoc.Rows.Count > 0)
        //    {
        //    }
        //    else if ( RBLLabType.SelectedValue == "P" )
        //    {
        //    }
        //    else
        //    {
        //    }

        //}
        //else
        //{
        //    lblMessage.Text = "please Select Bill Group";
        //    lblMessage.ForeColor = System.Drawing.Color.Red;

        //}
       
    }

    private void InsertInBill()
    {
        object[] returns;
        // string Message = "";
        BELBillInfo objBELBillInfo = new BELBillInfo();
        // objBELBillInfo.BillNo = Convert.ToInt32(lblBillNo.Text);
        //int ReceiptNo = objDALBillInfo.GetMaxLabReceiptNo(Convert.ToInt32(Session["FId"]));
        //objBELBillInfo.ReceiptNo = ReceiptNo + 1;
        //ViewState["ReceiptNo"] = objBELBillInfo.ReceiptNo;
        objBELBillInfo.PatRegId = Convert.ToInt32(ViewState["PatientInfoId"]);
        objBELBillInfo.BillDate = System.DateTime.Now;
        objBELBillInfo.IpdNo = Convert.ToInt32(0);
        objBELBillInfo.OpdNo = Convert.ToInt32(0);
        objBELBillInfo.LabNo = Convert.ToInt32(ViewState["LabNo"]);
       // ViewState["BillNo"] = objDALBillInfo.GetBillNo_ForLab(Convert.ToInt32(Session["FId"]), Convert.ToInt32(ViewState["LabNo"]));
        objBELBillInfo.BillNo = Convert.ToInt32(ViewState["BillNo"]);
       // objBELBillInfo.BillNo =
        objBELBillInfo.ConsultantDrId = Convert.ToInt32(ddlConsDoctorName.SelectedValue);
        objBELBillInfo.Remark = "";
        objBELBillInfo.BillType = "Lab Bill";
        objBELBillInfo.PaymentType = RdbPayment.SelectedValue;
        objBELBillInfo.AmountPaid = Convert.ToDecimal(txtPaid.Text);

        if (Convert.ToDecimal(txtDiscount.Text) > 0)
        {
            objBELBillInfo.Discount = Convert.ToDecimal(ViewState["DiscountAmount"]);
        }
        else
        {
            objBELBillInfo.Discount = Convert.ToDecimal(txtDiscount.Text);
        }
        objBELBillInfo.BillAmountWithDisc = Convert.ToDecimal(txtTotalAmt.Text);
        if (txtbalance.Text == "")
        {
            txtbalance.Text = "0";
        }
        objBELBillInfo.Balance = Convert.ToDecimal(txtbalance.Text);

        objBELBillInfo.CreatedBy = Convert.ToString(Session["username"]);
        if (ddlDiscReason.SelectedValue != "0")
        {
            objBELBillInfo.ReasonForDiscountId = Convert.ToInt32(ddlDiscReason.SelectedValue);
        }
        else
            objBELBillInfo.ReasonForDiscountId = 0;

        if (ddlDiscountGivenBy.SelectedValue != "0")
        {
            objBELBillInfo.DiscountGivenById = Convert.ToInt32(ddlDiscReason.SelectedValue);
        }
        else
            objBELBillInfo.DiscountGivenById = 0;

        if (ddlBalreason.SelectedValue != "0")
        {
            objBELBillInfo.ReasonForBalanceId = Convert.ToInt32(ddlBalreason.SelectedValue);
        }
        else
            objBELBillInfo.ReasonForBalanceId = 0;

        if (txtNumber.Text != "")
        {
            objBELBillInfo.ChequeCardNo = txtNumber.Text;
        }
        else
            objBELBillInfo.ChequeCardNo = "0";


        if (txtbankName.Text != "")
        {
            objBELBillInfo.BankName = txtbankName.Text;
        }
        else
            objBELBillInfo.BankName = "";


        if (txtchequedate.Text != "")
        {
            objBELBillInfo.ChequeDate = txtchequedate.Text.ToString();
        }

        objBELBillInfo.CreatedBy = Convert.ToString(Session["username"]);
        objBELBillInfo.BranchId = Convert.ToInt32(Session["Branchid"]);
        objBELBillInfo.FId = Convert.ToInt32(Session["FId"]);
        objBELBillInfo.BillAmount = Convert.ToDecimal(txtTotalAmt.Text);
        if (txtInsuranceAmt.Text == "")
        {
            txtInsuranceAmt.Text = "0";
        }
        if (txtInsuranceAmt.Text != "0")
        {
            objBELBillInfo.InsuranceCompId = Convert.ToInt32(ddlPatientSubCategoryName.SelectedValue);
            objBELBillInfo.IsInsuranceFlag = true;
            objBELBillInfo.InsuranceAmount = Convert.ToDecimal(ViewState["InsuranceAmt"]);
        }
        objBELBillInfo.LabNo = Convert.ToInt32(Request.QueryString["LabNo"]);
        objBELBillInfo.BillNo = Convert.ToInt32(Request.QueryString["BillNo"]);
       // returns = objDALBillInfo.InsertLabBillTransaction(objBELBillInfo);
        objDALBillInfo.UpdateRadiologyPatient_Details(objBELBillInfo);
       // ViewState["BillPaymentId"] = Convert.ToInt32(returns[0]);
        lblMessage.Text = "Record Saved Successfully";
        Clear();
    }

  
    protected BELOPDPatReg WriteDO()
    {
        objBELOpdReg = new BELOPDPatReg();
        
        objBELOpdReg.PatRegId = Convert.ToInt32(Convert.ToString(ViewState["PatientInfoId"]));
        objBELOpdReg.PatMainTypeId = Convert.ToInt32(ddlPatientCategoryName.SelectedValue);
        objBELOpdReg.PatientInsuTypeId = Convert.ToInt32(ddlPatientSubCategoryName.SelectedValue);
        objBELOpdReg.BillAmount = Convert.ToDecimal(txtTotalAmt.Text);
        objBELOpdReg.BillGroup = "Lab Bill";

        objBELOpdReg.DrId = Convert.ToInt32(ViewState["ConsultID"]);
        objBELOpdReg.VisitingNo = objDALOpdReg.GetMaxVisitingNo(objBELOpdReg);
        objBELOpdReg.TokenNo = objDALOpdReg.GetTokenNo(objBELOpdReg);
        objBELOpdReg.ReferenceDrName = txtDoctorName.Text;
        objBELOpdReg.ReferBy = txtRefBy.Text;
        objBELOpdReg.LabPtype = RBLLabType.SelectedValue; ;
        //objBELOpdReg.DeptId = Convert.ToInt32(ddlDepartment.SelectedValue);
        objBELOpdReg.DeptId = Convert.ToInt32(ViewState["DeptID"]);

        if (txtDiscount.Text != "")
        {
            objBELOpdReg.DiscountAmt = Convert.ToDecimal(ViewState["DiscountAmount"]);
        }
        else
        {
            objBELOpdReg.DiscountAmt = 0;

        }

        objBELOpdReg.PaidAmt = Convert.ToDecimal(txtPaid.Text);
      
        if (ddlDiscReason.SelectedValue != "0")
        {
            objBELOpdReg.ReasonForDiscountId = Convert.ToInt32(ddlDiscReason.SelectedValue);
        }
        else
        {
            objBELOpdReg.ReasonForDiscountId = 0;
        }
        if (ddlDiscountGivenBy.SelectedValue != "0")
        {
            objBELOpdReg.DiscountGivenById = Convert.ToInt32(ddlDiscountGivenBy.SelectedValue);
        }
        if (ddlBalreason.SelectedValue != "0")
        {
            objBELOpdReg.ReasonForBalanceId = Convert.ToInt32(ddlBalreason.SelectedValue); ;
        }
        else
        {
            objBELOpdReg.ReasonForBalanceId = 0;
        }
       
        if (txtInsuranceAmt.Text != "")
        {
            if (rdblInsuranceAmt.SelectedValue == "0")
            {
                objBELOpdReg.InsuranceAmount = Convert.ToDecimal(txtInsuranceAmt.Text);
            }
            if (rdblInsuranceAmt.SelectedValue == "1")
            {
                objBELOpdReg.InsuranceAmount = Convert.ToDecimal((Convert.ToSingle(txtAmount.Text) * Convert.ToSingle(txtInsuranceAmt.Text)) / 100);

            }
        }
        else
        {
            objBELOpdReg.InsuranceAmount = 0;
        }

        objBELOpdReg.CreatedBy = Convert.ToString(Session["username"]);
        objBELOpdReg.BranchId = Convert.ToInt32(Session["Branchid"]);
        objBELOpdReg.FId = Convert.ToInt32(Session["FId"]);
        objBELOpdReg.LabNo = Convert.ToInt32(Request.QueryString["LabNo"]);
        objBELOpdReg.BillNo = Convert.ToInt32(Request.QueryString["BillNo"]);

        objBELOpdReg.MainDoctor = Convert.ToString(DdlMainDoctor.SelectedItem.Text);

        return objBELOpdReg;
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
    private void InsertInBillDetail()
    {

        string Message = "";
        DataTable dt = (DataTable)ViewState["BillTable"];
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            objBELBillDetail = new BELBillDetails();
           
            objBELBillDetail.PatRegId = Convert.ToInt32(ViewState["PatientInfoId"]);
            objBELBillDetail.BillNo = Convert.ToInt32(ViewState["BillNo"]);
            objBELBillDetail.BillGroupName = rdbgroup.SelectedValue;
            if (Convert.ToInt32(dt.Rows[i]["BillServiceId"]) > 0)
                objBELBillDetail.BillServiceId = Convert.ToInt32(dt.Rows[i]["BillServiceId"]);
            if (Request.QueryString["EmrFlag"] == "EMR")
            {
                objBELBillDetail.EmployeeId = Convert.ToInt32(0);
            }
            else
            {
                objBELBillDetail.EmployeeId = Convert.ToInt32(dt.Rows[i]["DrId"]);
            }
            if ((dt.Rows[i]["Qty"]) != "")
                objBELBillDetail.Qty = Convert.ToDecimal(dt.Rows[i]["Qty"]);
            else
                objBELBillDetail.Qty = 1;
            if (dt.Rows[i]["Charge"] != "")
                objBELBillDetail.TotalCharges = Convert.ToDecimal(txtTotalAmt.Text);
            if (dt.Rows[i]["SingleBillServiceCharges"] != "")
                objBELBillDetail.Charges = Convert.ToDecimal(dt.Rows[i]["SingleBillServiceCharges"]);
            objBELBillDetail.CreatedBy = Convert.ToString(Session["username"]);
            objBELBillDetail.BranchId = Convert.ToInt32(Session["Branchid"]);
            objBELBillDetail.FId = Convert.ToInt32(Session["FId"]);
            objBELBillDetail.ProcedureId = Convert.ToInt32(ViewState["ProcedureId"]);

            objBELBillDetail.OpdNo = Convert.ToInt32(0);
            objBELBillDetail.IpdNo = Convert.ToInt32(dt.Rows[i]["IPDNO"]);
            objBELBillDetail.ClinicalHistory = Convert.ToString(dt.Rows[i]["ClinicalHistory"]);
            objBELBillDetail.LabNo = Convert.ToInt32(ViewState["LabNo"]);
            objBELBillDetail.ReceiptNo = Convert.ToInt32(ViewState["ReceiptNo"]);
            objBELBillDetail.MTCode = Convert.ToString(dt.Rows[i]["MTCode"]);

            if (Convert.ToString( ViewState["Initial"]) != "")
            {
                objBELBillDetail.Initial = Convert.ToString(ViewState["Initial"]);
            }
            else
            {
                objBELBillDetail.Initial = Convert.ToString(ddlTitleName.SelectedItem.Text);
            }
            if (Convert.ToString(ViewState["Sex"]) != "")
            {
                objBELBillDetail.Sex = Convert.ToString(ViewState["Sex"]);
            }
            else
            {
                objBELBillDetail.Sex = Convert.ToString(ddlGender.SelectedItem.Text);
            }
           
            objBELBillDetail.PatientName = Convert.ToString(txtPatientName.Text);
            objBELBillDetail.Age = Convert.ToString(txtAge.Text);
            if (Request.QueryString["EmrFlag"] == "EMR")
            {
                objBELBillDetail.RefDoc = Convert.ToString(dt.Rows[i]["DrId"]);
            }
            else
            {
                objBELBillDetail.RefDoc = Convert.ToString(dt.Rows[i]["DrId"]);

            }
            objBELBillDetail.TestName = Convert.ToString(dt.Rows[i]["Service"]);
            if (dt.Rows[i]["Charge"] != "")
                objBELBillDetail.TestRate = Convert.ToSingle(dt.Rows[i]["Charge"]);

           // objBELBillDetail.TestRate = Convert.ToSingle(txtAge.Text);
            objBELBillDetail.MobileNo = Convert.ToString(txtMobileNo.Text);

            if (Convert.ToString(ViewState["Age"]) != "")
            {
                objBELBillDetail.MDY = Convert.ToString(ViewState["Age"]);
            }
            else
            {
                objBELBillDetail.MDY = Convert.ToString(ddlAge.Text);
            }
            if (Request.QueryString["EmrFlag"] == "EMR")
            {
                objBELBillDetail.ReferBy = Convert.ToString(dt.Rows[i]["DrId"]).Trim();
            }
            else
            {
                objBELBillDetail.ReferBy = Convert.ToString(ViewState["RefBy"]).Trim();
            }

            objBELBillDetail.ReferPhy = Convert.ToString(txtRefPhy.Text).Trim();
            objBELBillDetail.OtherRefDoc = Convert.ToString(txtotherrefDocror.Text).Trim();

            objBELBillDetail.OtherRefDoc = Convert.ToString(txtotherrefDocror.Text).Trim();
            if (Convert.ToInt32(ddlPatientCategoryName.SelectedValue) != 1)
              {
                  objBELBillDetail.InsuranceID = Convert.ToInt32(ddlPatientSubCategoryName.SelectedValue);
            }
            if (txtInsuranceAmt.Text != "")
            {
                objBELBillDetail.InsuranceAmt = Convert.ToSingle(txtInsuranceAmt.Text);
            }
            if (DdlMainDoctor.SelectedItem.Text != "Select MainDoc")
            {
                //string[] MainDocI = txt_remark.Text.Split('=');
                objBELBillDetail.MainDocId = Convert.ToInt32(DdlMainDoctor.SelectedValue);
            }
            else
            {
                objBELBillDetail.MainDocId = 999;
            }
            if (txtPaid.Text != "")
            {
                objBELBillDetail.PaidAmt = Convert.ToSingle(txtPaid.Text);
            }
            if (txtbalance.Text != "")
            {
                objBELBillDetail.BalanceAmt = Convert.ToSingle(txtbalance.Text);
            }
            if (txtDiscount.Text != "")
            {
                objBELBillDetail.DiscountAmt = Convert.ToSingle(txtDiscount.Text);
            }
            objBELBillDetail.ModeOfPay = RdbPayment.SelectedItem.Text;
            objBELBillDetail.LabPtype = RBLLabType.SelectedValue;

            objBELBillDetail.PatAddress = Convert.ToString(txtPatientAddress.Text).Trim();
            if (txtBirthDate.Text != "")
            {
                objBELBillDetail.PatBirthDate = Convert.ToDateTime(txtBirthDate.Text);
            }
            objBELBillDetail.Email = Convert.ToString(txtEmail.Text).Trim();
            //objBELBillDetail.RepType =  RblRepType.SelectedValue;
           

            string k = "";
            for (int L = 0; L < RblRepType.Items.Count; L++)
            {
                if (RblRepType.Items[L].Selected)
                {
                    if (L == 0)
                    {
                        k = RblRepType.Items[L].Text;
                    }
                    else
                    {
                        k = k +","+ RblRepType.Items[L].Text;
                    }
                }

            }
            objBELBillDetail.RepType =k;
            Message = objDALBillDetail.InsertLabServiceDetail(objBELBillDetail);
            DynamicMessage(lblMessage, Message);
            
        }
    }


    protected void btnReset_Click(object sender, EventArgs e)
    {
        ReSet();
        lblMessage.Text = "";
        //ViewState["PatientRegistrationId"] = 0;
    }

    /// <summary>
    /// 
    /// </summary>
    private void ReSet()
    {

        txtPatientName.Text = "";
        txtDoctorName.Text = "";
        ddlConsDoctorName.SelectedValue = "0";      
        txtPatientComplaint.Text = "";    

        txtAmount.Text = "";
        txtbalance.Text = "";
        txtTotalAmt.Text = "";
        txtDiscount.Text = "";
        txtPaid.Text = "";
        txtReferanceDrText.Text = "";
        txtRefPhy.Text = "";
        ddlBalreason.SelectedValue = "0";
        ddlDiscReason.SelectedValue = "0";

        MakeBillTable();
        DataTable dt = (DataTable)ViewState["BillTable"];
        gvBill.DataSource = dt;
        gvBill.DataBind();

        txtReferanceDrText.Text = "";
        txtCharges.Text = "";
       
    }



    protected void FillPage()
    {
        try
        {
            ReadDO();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }

    /// <summary>
    /// It Reads The Record Value From Data object and Set in FormFields
    /// </summary>
    private void ReadDO()
    {
        objBELOpdReg = objDALOpdReg.SelectOne(Convert.ToInt32(ViewState["PatientRegistrationID"]));

       
        txtPatientComplaint.Text = objBELOpdReg.PatientComplaint;
       
        if (Convert.ToString(objBELOpdReg.ReferenceDrId) != null)
            hfDoctorId.Value = Convert.ToString(objBELOpdReg.ReferenceDrId);
        txtReferanceDrText.Text = objBELOpdReg.ReferenceDrText;
    }


    protected void gvBill_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvBill.PageIndex = e.NewPageIndex;
        AddToGridView();
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

        //txtTotalAmt.Text = Convert.ToString(ViewState["Total"]);

        //txtbalance.Text = Convert.ToString(ViewState["Total"]);
        //txtAmount.Text = Convert.ToString(ViewState["Total"]);
        txtPaid.Text = "0";
    }
    protected void txtPatientName_TextChanged(object sender, EventArgs e)
    {
        if (txtPatientName.Text.Split('-').Length < 2)
        {
            hfPatientId.Value = "0";
            ViewState["PatientInfoId"] = "0";
        }
        else
        {
            string[] PatientInfo = txtPatientName.Text.Split('-');
            txtPatientName.Text = PatientInfo[2];
            ViewState["PatientInfoId"] = PatientInfo[0];
            ViewState["Initial"] = PatientInfo[1];
            ViewState["Sex"] = PatientInfo[4];
            hfPatientId.Value = PatientInfo[0];
            fillInformation();
            txtPatientAddress.Enabled = false;
            lblVisitingNo.Text = "Your Reg No is :"+ViewState["PatientInfoId"]+"";
        }


    }

    //protected void btnSaveandBill_Click(object sender, EventArgs e)
    //{
    //    string Message = "";
    //    // if (ViewState["PatientInfoId"] == "0")
    //    if (Convert.ToString(ViewState["PaidAmt"]) != "true")
    //    {
    //        if (Session["PatientId"] == "0")
    //        {
    //            if (ViewState["PatientInfoId"] == "0")
    //            {
    //                GetPatientID();
    //                objBELPatInfo = WriteToPatientReg();
    //                object[] Result = objDALPatInfo.InsertPatientInfo(objBELPatInfo);
    //                Message = Convert.ToString(Result[0]);
    //                ViewState["PatientInfoId"] = Convert.ToString(Result[1]);
    //                Session["PatientId"] = Convert.ToString(Result[1]);
    //                hfPatientId.Value = Convert.ToString(Result[1]);
    //            }
    //        }

    //        InsertRecortToAll();
    //        // InsertPayment();
    //    }
    //    PrintReport();
        

    //}



   
  

    //protected void btnConsultation_Click(object sender, EventArgs e)
    //{
    //    string url = "";
    //    string PatientInfoID = Convert.ToString(ViewState["PatientInfoId"]);
    //    Session["PatientInfoID"] = PatientInfoID;
    //    string PatientRegistrationID = Convert.ToString(ViewState["PatientRegistrationID"]);
    //    ViewState["PatientRegistrationID"] = Convert.ToString(ViewState["PatientRegistrationID"]);

    //    ViewState["FormType"] = "Consultant";
    //    url = "~/PatientConsultation.aspx?PatientRegistrationId=" + Convert.ToString(ViewState["PatientRegistrationID"]) + "&& FormType=" + Convert.ToString(ViewState["FormType"]);
    //    Response.Redirect(url);



    //}
    //protected void btnRdlcReport_Click(object sender, EventArgs e)
    //{
    //    InsertRecortToAll();
    //    // InsertPayment();
    //    string url = "";
    //    ViewState["FormType"] = "OPDBill";

    //    url = "RDLCReport/RDLCReport.aspx?BillId=" + Convert.ToString(ViewState["BillID"]) + "&&FormType=" + Convert.ToString(ViewState["FormType"]);
    //    // Response.Redirect(url);
    //    string fullURL = "window.open('" + url + "','_blank')";

    //    ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", fullURL, true);

    //    //Server.Transfer(url);
    //}

    protected void txtDoctorName_TextChanged(object sender, EventArgs e)
    {

    }
    protected void btnPatientInfo_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Masters/PatientInfo16.aspx");

    }

    protected void gvBill_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlConsDoctorName_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToBoolean(ViewState["IsDirect"]) != true)
        {
            ConsultantDrId = ddlConsDoctorName.SelectedValue.ToString();
            ViewState["ConsultantDrID"] = ConsultantDrId;
            DoctorId = Convert.ToInt32(ConsultantDrId);
            SetCharges();
            if (txtCharges.Text != "")
            {
                txtTotalCharges.Text = Convert.ToString(Convert.ToDecimal(txtCharges.Text) * Convert.ToDecimal(txtQty.Text));
            }
        }

    }
    protected void txtDiscount_TextChanged(object sender, EventArgs e)
    {
        decimal insuamt=0;
        if (rdbdiscAmt.Checked)
        {
            if (txtDiscount.Text != "")
            {
               
                if (txtInsuranceAmt.Text != "")
                {
                    if (rdblInsuranceAmt.SelectedValue == "0")
                    {
                        insuamt = Convert.ToDecimal(txtInsuranceAmt.Text);
                    }
                    if (rdblInsuranceAmt.SelectedValue == "1")
                    {
                        insuamt = Convert.ToDecimal((Convert.ToSingle(txtAmount.Text) * Convert.ToSingle(txtInsuranceAmt.Text)) / 100);

                    }
                }
                else
                {
                    insuamt = 0;
                }

                txtAmount.Text = Convert.ToString(Convert.ToDouble(txtTotalAmt.Text) - (Convert.ToDouble(txtDiscount.Text) + Convert.ToDouble(insuamt)));
               // txtPaid.Text = Convert.ToString(Convert.ToDouble(txtAmount.Text));
            
              txtbalance.Text = Convert.ToString(Convert.ToDouble(txtAmount.Text) - Convert.ToDouble(0));

                ViewState["DiscountPercent"] = (Convert.ToDouble(txtDiscount.Text) * 100) / Convert.ToDouble(txtTotalAmt.Text);
                ViewState["DiscountAmount"] = Convert.ToDouble(txtDiscount.Text);
            }
        }
        else
        {
            if (txtDiscount.Text != "")
            {
                if (txtInsuranceAmt.Text != "")
                {
                    if (rdblInsuranceAmt.SelectedValue == "0")
                    {
                        insuamt = Convert.ToDecimal(txtInsuranceAmt.Text);
                    }
                    if (rdblInsuranceAmt.SelectedValue == "1")
                    {
                        insuamt = Convert.ToDecimal((Convert.ToSingle(txtAmount.Text) * Convert.ToSingle(txtInsuranceAmt.Text)) / 100);

                    }
                }
                else
                {
                    insuamt = 0;
                }

                txtAmount.Text = Convert.ToString(Convert.ToDouble(txtTotalAmt.Text) - (((Convert.ToDouble(txtTotalAmt.Text) * Convert.ToDouble(txtDiscount.Text)) / 100) + Convert.ToDouble(insuamt)));
               // txtPaid.Text = Convert.ToString(Convert.ToDouble(txtAmount.Text));
             
                txtbalance.Text = Convert.ToString(Convert.ToDouble(txtAmount.Text) - Convert.ToDouble(0));

                ViewState["DiscountPercent"] = Convert.ToDouble(txtDiscount.Text);
                ViewState["DiscountAmount"] = ((Convert.ToDouble(txtTotalAmt.Text) * Convert.ToDouble(txtDiscount.Text)) / 100);
            }
        }
    }
    protected void txtPaid_TextChanged(object sender, EventArgs e)
    {

        txtbalance.Text = Convert.ToString(Convert.ToDouble(txtAmount.Text) - Convert.ToDouble(txtPaid.Text));
    }
    //protected void txttax_TextChanged(object sender, EventArgs e)
    //{
    //    if (rdbTaxAmt.Checked)
    //    {
    //        txtAmount.Text = Convert.ToString(Convert.ToDouble(txtTotalAmt.Text) + Convert.ToDouble(txttax.Text));
    //        ViewState["TaxAmount"] = Convert.ToDouble(txttax.Text);
    //    }
    //    else
    //    {
    //        txtAmount.Text = Convert.ToString(Convert.ToDouble(txtTotalAmt.Text) + ((Convert.ToDouble(txtTotalAmt.Text) * Convert.ToDouble(txttax.Text)) / 100));
    //        ViewState["TaxAmount"] = ((Convert.ToDouble(txtTotalAmt.Text) * Convert.ToDouble(txttax.Text)) / 100);
    //    }
    //}
  
    protected void ddlAge_SelectedIndexChanged(object sender, EventArgs e)
    {

        //int Age = Convert.ToInt32(ddlAge.SelectedIndex);
        //ViewState["Age"] = Convert.ToInt32(Age);

        //if ((Convert.ToInt32(ViewState["Age"])) == 0)
        //{
        //    int age = Convert.ToInt32(txtAge.Text);

        //    ViewState["Year"] = Convert.ToString(DateTime.Now.Year - age);
        //    ViewState["Today"] = DateTime.Now.Day + "/" + DateTime.Now.Month.ToString("00") + "/" + ViewState["Year"];
        //    // txtBirthDate.Text = Convert.ToString(MyDateTime.GetMMDDYYYYDateString(ViewState["Today"].ToString())); 
        //    BirthDate = Convert.ToString(ViewState["Today"].ToString());//Date Format- dd/MM/yyyy 

        //}
        //else if ((Convert.ToInt32(ViewState["Age"])) == 1)
        //{
        //    int age = Convert.ToInt32(txtAge.Text);
        //    if (age > 12)
        //    {
        //        age = 1;
        //        ViewState["Year"] = Convert.ToString(DateTime.Now.Year - age);
        //        ViewState["Today"] = DateTime.Now.Day + "/" + DateTime.Now.Month.ToString("00") + "/" + ViewState["Year"];
        //        //txtBirthDate.Text = Convert.ToString(MyDateTime.GetMMDDYYYYDateString(ViewState["Today"].ToString()));
        //        BirthDate = Convert.ToString(ViewState["Today"].ToString());//Date Format- dd/MM/yyyy 
        //    }
        //    else
        //    {
        //        ViewState["Month"] = Convert.ToString(DateTime.Now.Month - age);
        //        ViewState["Today"] = DateTime.Now.Day + "/" + ViewState["Month"] + "/" + DateTime.Now.Year;
        //        //txtBirthDate.Text = Convert.ToString(MyDateTime.GetMMDDYYYYDateString(ViewState["Today"].ToString()));
        //        BirthDate = Convert.ToString(ViewState["Today"].ToString());//Date Format- dd/MM/yyyy 
        //    }
        //}
        //else
        //{
        //    int age = Convert.ToInt32(txtAge.Text);
        //    ViewState["Day"] = Convert.ToString(DateTime.Now.Day - age);
        //    ViewState["Today"] = ViewState["Day"] + "/" + DateTime.Now.Month.ToString("00") + "/" + DateTime.Now.Year;
        //    //txtBirthDate.Text = Convert.ToString(MyDateTime.GetMMDDYYYYDateString(ViewState["Today"].ToString()));
        //    BirthDate = Convert.ToString(ViewState["Today"].ToString());//Date Format- dd/MM/yyyy 
        //}
        int Age = Convert.ToInt32(ddlAge.SelectedIndex);
        ViewState["Age"] = Convert.ToInt32(Age);

        if ((Convert.ToInt32(ViewState["Age"])) == 0)
        {
            int age = Convert.ToInt32(txtAge.Text);

            ViewState["Year"] = Convert.ToString(DateTime.Now.Year - age);
            ViewState["Today"] = DateTime.Now.Day + "/" + DateTime.Now.Month.ToString("00") + "/" + ViewState["Year"];
            // txtBirthDate.Text = Convert.ToString(MyDateTime.GetMMDDYYYYDateString(ViewState["Today"].ToString())); 
            txtBirthDate.Text = Convert.ToString(ViewState["Today"].ToString());//Date Format- dd/MM/yyyy 

        }
        else if ((Convert.ToInt32(ViewState["Age"])) == 1)
        {
            int age = Convert.ToInt32(txtAge.Text);
            if (age > 12)
            {
                age = 1;
                ViewState["Year"] = Convert.ToString(DateTime.Now.Year - age);
                ViewState["Today"] = DateTime.Now.Day + "/" + DateTime.Now.Month.ToString("00") + "/" + ViewState["Year"];
                //txtBirthDate.Text = Convert.ToString(MyDateTime.GetMMDDYYYYDateString(ViewState["Today"].ToString()));
                txtBirthDate.Text = Convert.ToString(ViewState["Today"].ToString());//Date Format- dd/MM/yyyy 
            }
            else
            {
                ViewState["Month"] = Convert.ToString(DateTime.Now.Month - age);
                ViewState["Today"] = DateTime.Now.Day + "/" + ViewState["Month"] + "/" + DateTime.Now.Year;
                //txtBirthDate.Text = Convert.ToString(MyDateTime.GetMMDDYYYYDateString(ViewState["Today"].ToString()));
                txtBirthDate.Text = Convert.ToString(ViewState["Today"].ToString());//Date Format- dd/MM/yyyy 
            }
        }
        else
        {
            int age = Convert.ToInt32(txtAge.Text);
            ViewState["Day"] = Convert.ToString(DateTime.Now.Day - age);
            ViewState["Today"] = ViewState["Day"] + "/" + DateTime.Now.Month.ToString("00") + "/" + DateTime.Now.Year;
            //txtBirthDate.Text = Convert.ToString(MyDateTime.GetMMDDYYYYDateString(ViewState["Today"].ToString()));
            txtBirthDate.Text = Convert.ToString(ViewState["Today"].ToString());//Date Format- dd/MM/yyyy 
        }
    }
    protected void txtAge_TextChanged(object sender, EventArgs e)
    {
        //ViewState["Today"] = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
        //int age = Convert.ToInt32(txtAge.Text);

        //ViewState["Year"] = Convert.ToString(DateTime.Now.Year - age);
        //ViewState["Today"] = DateTime.Now.Day + "/" + DateTime.Now.Month.ToString("00") + "/" + ViewState["Year"];
        //// txtBirthDate.Text = Convert.ToString(MyDateTime.GetMMDDYYYYDateString(ViewState["Today"].ToString())); //Convert.ToDateTime(MyDateTime.GetMMDDYYYYDateString(txtBirthDate.Text));
        //string BirthDate = Convert.ToString(ViewState["Today"].ToString());//Date Format- dd/MM/yyyy 

        if (txtAge.Text != "")
        {
            ViewState["Today"] = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
            int age = Convert.ToInt32(txtAge.Text);
            int days = 0;
            int year = Convert.ToInt32(DateTime.Now.Year - age);
            if (year % 400 == 0 || (year % 4 == 0 && year % 100 != 0))
            {
                if (DateTime.Now.Month == 02)
                {
                    days = 29;
                }
                else
                {
                    days = DateTime.Now.Day;
                }

            }
            else
            {
                if (DateTime.Now.Month == 02)
                {
                    days = 28;
                }
                else
                {
                    days = DateTime.Now.Day;
                }
            }

            ViewState["Year"] = Convert.ToString(DateTime.Now.Year - age);

            ViewState["Today"] = days + "/" + DateTime.Now.Month.ToString("00") + "/" + ViewState["Year"];
            // txtBirthDate.Text = Convert.ToString(MyDateTime.GetMMDDYYYYDateString(ViewState["Today"].ToString())); //Convert.ToDateTime(MyDateTime.GetMMDDYYYYDateString(txtBirthDate.Text));
            txtBirthDate.Text = Convert.ToString(ViewState["Today"].ToString());//Date Format- dd/MM/yyyy 
            //chbxIsConfirmBirthDate.Checked = false;
            //chbxIsConfirmBirthDate.Disabled = true;
            ddlAge.Focus();
        }
    }
    protected void RdbPayment_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt32(RdbPayment.SelectedIndex) == 1)
        {
            PaymentDetails.Visible = true;
            ChequeDate.Visible = false;

        }
        else if (Convert.ToInt32(RdbPayment.SelectedIndex) == 2)
        {
            PaymentDetails.Visible = true;
            ChequeDate.Visible = true;

        }
        else
        {
            PaymentDetails.Visible = false;
            ChequeDate.Visible = false;

        }

    }
    protected void txtService_TextChanged(object sender, EventArgs e)
    {
        //if (txtConsDoctorName_New.Text != "")
        //{
            if (txtService.Text != "")
            {
                string[] Service = txtService.Text.Split('=');
                if (Service.Length > 1)
                {
                    if (Service.Length == 4)
                    {
                        txtService.Text = Service[1] + " " + Service[2];
                        txtCharges.Text = Service[3];
                    }
                    if (Service.Length == 3)
                    {
                        txtService.Text = Service[1];
                        txtCharges.Text = Service[2];
                    }

                    ViewState["MTCode"] = Service[0];
                    txtTotalCharges.Text = Convert.ToString(Convert.ToDecimal(txtCharges.Text) * Convert.ToDecimal(txtQty.Text));
                    //if (txtConsDoctorName_New.Text != "")
                    //{
                    //    string[] PatientInfo = txtConsDoctorName_New.Text.Split('-');
                    //    if (PatientInfo.Length > 1)
                    //    {
                    //        txtConsDoctorName_New.Text = PatientInfo[1];
                    //        txtConsDoctorName.Text = PatientInfo[1];
                    //    }
                    //}
                   
                    this.btnAdd_Click(null, null);
                    //ViewState["ServiceId"] = Convert.ToInt32(Service[0]);

                    //objBELBillService = objDALOpdReg.GetserviceInfo(Convert.ToInt32(ViewState["ServiceId"]));
                }
                //bool IsDirect = Convert.ToBoolean(objBELBillService.IsDirect);
                //bool IsDocWise = Convert.ToBoolean(objBELBillService.Isdoc);

                //if (IsDirect == true)
                //{
                //    ViewState["IsDirect"] = true;

                //    SetChargesForDirectService();
                //    if (txtCharges.Text == "")
                //    {
                //        txtCharges.Text = "0";
                //    }
                //    

                //}
                //else if (IsDocWise == true)
                //{
                //    if (ViewState["ConsultID"] != "0")
                //    {
                //        SetCharges();
                //        if (txtCharges.Text == "")
                //        {
                //            txtCharges.Text = "0";
                //        }
                //        txtTotalCharges.Text = Convert.ToString(Convert.ToDecimal(txtCharges.Text) * Convert.ToDecimal(txtQty.Text));

                //    }
                //}
            }
            if (RBLLabType.SelectedValue == "R")
            {
               // KKK.Visible = false;
                txtPaid.Text = "0";
                txtbalance.Text = txtTotalAmt.Text;
            }
            else
            {
                KKK.Visible = true;
            }
    }
    protected void txtQty_TextChanged(object sender, EventArgs e)
    {
        if (txtCharges.Text != "")
        {
            txtTotalCharges.Text = Convert.ToString(Convert.ToDecimal(txtCharges.Text) * Convert.ToDecimal(txtQty.Text));
        }
        btnAdd.Focus();
    }
    protected void txtBirthDate_TextChanged(object sender, EventArgs e)
    {
        int intYear, intMonth, intDays;
        DateTime Birthday = Convert.ToDateTime(txtBirthDate.Text);
        intYear = Birthday.Year;
        intMonth = Birthday.Month;
        intDays = Birthday.Day;

        DateTime dtt = Convert.ToDateTime(txtBirthDate.Text);

        DateTime td = DateTime.Now;
        int Leap_Year = 0;
        for (int i = dtt.Year; i < td.Year; i++)
        {
            if (DateTime.IsLeapYear(i))
            {
                ++Leap_Year;
            }
        }
        TimeSpan timespan = td.Subtract(Birthday);
        intDays = timespan.Days - Leap_Year;
        int intResult = 0;
        intYear = Math.DivRem(intDays, 365, out intResult);
        intMonth = Math.DivRem(intResult, 30, out intResult);
        intDays = intResult;
        if (intYear > 0 && intDays > 0)
        {
            txtAge.Text =intYear.ToString();
            ddlAge.SelectedIndex = 0;
        }
        else if (intMonth > 0)
        {
            txtAge.Text = intMonth.ToString();
            ddlAge.SelectedIndex = 1;
        }
        else if (intDays > 0)
        {
            txtAge.Text = intDays.ToString();
            ddlAge.SelectedIndex = 2;
        }
        //if (DateTime.Now.Year > Birthday.Year)
        //{
        //    int BirthAge = ((DateTime.Now.Year - Birthday.Year) * 372 + (DateTime.Now.Month - Birthday.Month) * 31 + (DateTime.Now.Day - Birthday.Day)) / 372;
        //    txtAge.Text = BirthAge.ToString();
        //    ddlAge.SelectedIndex = 0;
        //}

    }


    
    //protected void PaymentInsurance_CheckedChanged(object sender, EventArgs e)
    //{
    //    if (PaymentInsurance.Checked == true)
    //    {


    //        InsuranceDetails.Visible = false;
    //        txtDiscount.Enabled = false;
    //        txtbalance.Text = txtAmount.Text;
    //        ddlDiscountGivenBy.Enabled = false;
    //        txtPaid.Enabled = false;
    //        txtPaid.Text = Convert.ToString(Convert.ToDecimal(txtAmount.Text) - Convert.ToDecimal(txtbalance.Text));
    //        ddlDiscReason.Enabled = false;
    //        btnSaveandBill.Enabled = false;

    //    }
    //    else
    //    {

    //        InsuranceDetails.Visible = false;
    //        txtPaid.Enabled = true;
    //        txtDiscount.Enabled = true;
    //        txtPaid.Text = txtAmount.Text;
    //        txtDiscount.Enabled = true;
    //        ddlDiscountGivenBy.Enabled = true;
    //        ddlDiscReason.Enabled = true;
    //        txtbalance.Text = Convert.ToString(Convert.ToDecimal(txtAmount.Text) - Convert.ToDecimal(txtPaid.Text));
    //        btnSaveandBill.Enabled = true;
    //    }
    //}

    protected void rdblInsuranceAmt_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (txtInsuranceAmt.Text != "0" && txtInsuranceAmt.Text != "")
        {
            if (rdblInsuranceAmt.SelectedValue == "1")
            {

                double InsuranceAmt = (Convert.ToSingle(txtAmount.Text) * Convert.ToSingle(txtInsuranceAmt.Text)) / 100;
                txtPaid.Text = Convert.ToString(Convert.ToSingle(txtAmount.Text) - InsuranceAmt);
                txtbalance.Text = Convert.ToString(Convert.ToSingle(txtAmount.Text) - Convert.ToSingle(InsuranceAmt + Convert.ToSingle(txtPaid.Text)));
            }
            if (rdblInsuranceAmt.SelectedValue == "0")
            {
                txtPaid.Text = Convert.ToString(Convert.ToSingle(txtAmount.Text) - Convert.ToSingle(txtInsuranceAmt.Text));
                txtbalance.Text = Convert.ToString(Convert.ToSingle(txtAmount.Text) - (Convert.ToSingle(txtInsuranceAmt.Text) + Convert.ToSingle(txtPaid.Text)));

            }

        }
    }

    protected void txtInsuranceAmt_TextChanged1(object sender, EventArgs e)
    {
        double DiscountAmt = 0;
        if (txtInsuranceAmt.Text != "0" && txtInsuranceAmt.Text != "")
        {
            if (txtDiscount.Text != "")
            {
                DiscountAmt = Convert.ToDouble(ViewState["DiscountAmount"]);
            }
            else
            {
               DiscountAmt = 0;

            }
            if (rdblInsuranceAmt.SelectedValue == "1")
            {
                double InsuranceAmt = (Convert.ToSingle(txtTotalAmt.Text) * Convert.ToSingle(txtInsuranceAmt.Text)) / 100;
                txtAmount.Text = Convert.ToString(Convert.ToDouble(txtTotalAmt.Text) - (DiscountAmt + InsuranceAmt));
              //  txtPaid.Text = Convert.ToString(txtAmount.Text); // - (InsuranceAmt+DiscountAmt));
                txtbalance.Text = Convert.ToString(Convert.ToSingle(txtAmount.Text) -  Convert.ToSingle(0));
                ViewState["InsuranceAmt"] = InsuranceAmt;
            }
            if (rdblInsuranceAmt.SelectedValue == "0")
            {
                txtAmount.Text = Convert.ToString(Convert.ToDouble(txtTotalAmt.Text) - (DiscountAmt + Convert.ToSingle(txtInsuranceAmt.Text)));             
               // txtPaid.Text = Convert.ToString(Convert.ToSingle(txtAmount.Text) );
                txtbalance.Text = Convert.ToString(Convert.ToSingle(txtAmount.Text) -  Convert.ToSingle(0));
                ViewState["InsuranceAmt"] = txtInsuranceAmt.Text;

            }

        }
    }
    protected void txtAmount_TextChanged(object sender, EventArgs e)
    {

    }
    protected void rdbgroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        Session["UID"] = rdbgroup.SelectedValue;
    }
    protected void gvBill_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int index = Convert.ToInt32(e.NewEditIndex);
        DataTable dt = ViewState["BillTable"] as DataTable;
       
        txtService.Text = dt.Rows[index]["Service"].ToString();
        txtConsDoctorName.Text  = dt.Rows[index]["EmpName"].ToString();
        txtQty.Text=dt.Rows[index]["Qty"].ToString();
        txtCharges.Text = dt.Rows[index]["SingleBillServiceCharges"].ToString(); ;
        txtTotalCharges.Text = dt.Rows[index]["Charge"].ToString();

        int DrId = Convert.ToInt32(dt.Rows[index]["DrId"]);
        ViewState["ConsultID"] = DrId;

        int BillServiceId = Convert.ToInt32(dt.Rows[index]["BillServiceId"]);
        ViewState["BillServiceId"] = BillServiceId;
        string MTCode = Convert.ToString(dt.Rows[index]["MTCode"]);
        ViewState["MTCode"] = MTCode;
        
        ViewState["Index"] = index;
        ViewState["Edit"] = "1";
        ViewState["BillTable"] = dt;
        e.Cancel = true;
    }
    protected void txtCharges_TextChanged(object sender, EventArgs e)
    {
        txtQty_TextChanged(null, null);
        txtQty.Focus();
    }

    private void PrintReport()
    {
        try
        {
            BLLReports objBLLReports = new BLLReports();
            DataSet dsCustomers = new DataSet();
            ReportDocument crystalReport = new ReportDocument();
            crystalReport.Load(Server.MapPath("~/Report/Rpt_OPDBilling.rpt"));
            dsCustomers = objBLLReports.GetOPDBillDetails(Convert.ToInt32(ViewState["BillNo"]), Convert.ToInt32(ViewState["ReceiptNo"]), Convert.ToInt32(ViewState["OpdNo"]), Convert.ToInt32(ViewState["PatientInfoId"]), Convert.ToInt32(Session["FId"]), Convert.ToInt32(Session["BranchId"]));
            crystalReport.SetDataSource(dsCustomers);
            //crystalReport.ParameterFields["HospitalName"].CurrentValues.AddValue(Convert.ToString(Application["OrgnizationName"]));
            //crystalReport.ParameterFields["HospitalAddress"].CurrentValues.AddValue(Convert.ToString(Application["OrgnizationAddress"]));
            //crystalReport.ParameterFields["Image"].CurrentValues.AddValue(Application["ImagePath"]);
            // crystalReport.ParameterFields["ReportFooter"].CurrentValues.AddValue("Hospital Software | Ph.020 0000000000");
            crystalReport.ExportToHttpResponse
            (CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Employee");
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }


    protected void txtConsDoctorName_New_TextChanged(object sender, EventArgs e)
    {
        if (txtConsDoctorName_New.Text != "")
        {
            string[] PatientInfo = txtConsDoctorName_New.Text.Split('-');
            if (PatientInfo.Length > 1)
            {
                txtConsDoctorName_New.Text = PatientInfo[1];
                txtConsDoctorName.Text = PatientInfo[1];
                ViewState["ConsultID"] = PatientInfo[0];

               // //ConsultantDrId = ddlConsDoctorName.SelectedValue.ToString();
               // ConsultantDrId = Convert.ToString(ViewState["ConsultID"]);
               // ViewState["ConsultantDrID"] = ConsultantDrId;
               // DoctorId = Convert.ToInt32(ConsultantDrId);
               // int BranchId = Convert.ToInt32(Session["Branchid"]);
               // int FId = Convert.ToInt32(Session["FId"]);
               // SetCharges();
               // //string DeptId = objDALOpdReg.GetDeptId(Convert.ToInt32(ddlConsDoctorName.SelectedValue), FId, BranchId);
               // string DeptId = objDALOpdReg.GetDeptId_WithName(Convert.ToInt32(ConsultantDrId), FId, BranchId);
               // string[] DeptName = DeptId.Split('-');
               // // ddlConsDoctorName
               // //ddlDepartment.SelectedValue = DeptId;
               // ViewState["DeptID"] = DeptName[0];
               // txtdepartment.Text = DeptId;

               //// 
               // txtService.Text =  "3552"+" - "+ "OPD Consultaion";
               // txtService_TextChanged(null, null);
               // btnAdd_Click(null, null);
            }
        }

    }
    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchDepartment(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        return objDALOpdReg.FillAllDepartment(prefixText);
    }
    protected void txtdepartment_TextChanged(object sender, EventArgs e)
    {
        if (txtdepartment.Text != "")
        {
            string[] PatientInfo = txtdepartment.Text.Split('-');
            if (PatientInfo.Length > 1)
            {
                txtdepartment.Text = PatientInfo[1];
                ViewState["DeptID"] = PatientInfo[0];

            }

        }
    }
    protected void btnCaseReport_Click(object sender, EventArgs e)
    {
        try
        {
            Alter_view();
            string sql = "";
            BLLReports objBLLReports = new BLLReports();
            //DataSet dsCustomers = new DataSet();
            //ReportDocument crystalReport = new ReportDocument();
            //crystalReport.Load(Server.MapPath("~/Report/Rpt_CaseReport.rpt"));
            //dsCustomers = objBLLReports.CaseReport(Convert.ToInt32(ViewState["OpdNo"]), Convert.ToString(ViewState["PatientInfoId"]), Convert.ToInt32(Session["FId"]), Convert.ToInt32(Session["BranchId"]));
            //crystalReport.SetDataSource(dsCustomers);
            ////crystalReport.ParameterFields["HospitalName"].CurrentValues.AddValue(Convert.ToString(Application["OrgnizationName"]));
            ////crystalReport.ParameterFields["HospitalAddress"].CurrentValues.AddValue(Convert.ToString(Application["OrgnizationAddress"]));
            //////crystalReport.ParameterFields["Image"].CurrentValues.AddValue(Application["ImagePath"]);
            ////crystalReport.ParameterFields["ReportFooter"].CurrentValues.AddValue("Hospital Software | Ph.020 0000000000");
            //crystalReport.ExportToHttpResponse
            //(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Employee");
            Session.Add("rptsql", sql);
            Session["rptname"] = Server.MapPath("~/Report/Rpt_CaseReport.rpt");
            Session["reportname"] = "Rpt_CaseReport";
            Session["RPTFORMAT"] = "pdf";

            //ReportParameterClass.SelectionFormula = sql;
            string close = "<script language='javascript'>javascript:OpenReport();</script>";
            Type title1 = this.GetType();
            Page.ClientScript.RegisterStartupScript(title1, "", close);
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    public void Alter_view()
    {
        string sql = "";
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd1 = con.CreateCommand();

        string query = "ALTER VIEW [dbo].[VW_OPDCasePaper] AS (SELECT DISTINCT " +
              "  Initial.Title + ' ' + PatientInformation.FirstName AS FirstName, OpdRegistration.PatRegId, OpdRegistration.Entrydate, OpdRegistration.RegistrationType, OpdRegistration.ReferenceDoc, OpdRegistration.CreatedBy,  " +
             "   OpdRegistration.FId, OpdRegistration.BranchId, OpdRegistration.PatientComplaints, OpdRegistration.OpdNo, ProcedureServiceDetails.BillServiceId, BillService.ServiceName, ProcedureServiceDetails.DrId, " +
             "   HospEmpMst.Title + ' ' + HospEmpMst.Empname AS Empname, ProcedureServiceDetails.BillServiceCharges, ProcedureServiceDetails.BillNo, ProcedureServiceDetails.Qty, 0 as SingleBillServiceCharges, " +
             "   OpdRegistration.TokenNo, Initial.Title, Gender.GenderName, DepartmentMst.DeptName, HospEmpMst.Title AS DrInitial, PatientInformation.PatientAddress, PatientInformation.MobileNo, PatMainType.PatMainType  ,cast(PatientInformation.Age as nvarchar(50))+' '+ PatientInformation.AgeType as AgeType " +
             "   FROM            OpdRegistration INNER JOIN " +
             "   ProcedureServiceDetails ON OpdRegistration.OpdNo = ProcedureServiceDetails.OpdNo INNER JOIN " +
             "   PatientInformation ON OpdRegistration.PatRegId = PatientInformation.PatRegId INNER JOIN " +
             "   BillService ON ProcedureServiceDetails.BillServiceId = BillService.BillServiceId INNER JOIN " +
             "   Initial ON PatientInformation.TitleId = Initial.TitleId INNER JOIN " +
             "   Gender ON PatientInformation.GenderId = Gender.GenderId INNER JOIN  " +
             "   DepartmentMst ON OpdRegistration.DeptId = DepartmentMst.DeptId INNER JOIN " +
             "   PatMainType ON OpdRegistration.PatientMainCategoryId = PatMainType.PatMainTypeId LEFT OUTER JOIN " +
             "   HospEmpMst ON ProcedureServiceDetails.DrId = HospEmpMst.DrId " +
        " where OpdRegistration.branchid=" + Convert.ToInt32(Session["Branchid"]) + "  and OpdRegistration.OpdNo= " + Convert.ToInt32(ViewState["OpdNo"]) + " and  OpdRegistration.PatRegId= " + Convert.ToInt32(ViewState["PatientInfoId"]) + "";
        //if (txtFrom.Value != "" && txtTo.Value != "")
        //{
        //    query += " and    DagnosisAssigtTpPatient.CreatedOn between ('" + Convert.ToDateTime(txtFrom.Value).ToString("MM/dd/yyyy") + "') and ('" + Convert.ToDateTime(txtTo.Value).AddDays(1).ToString("MM/dd/yyyy") + "')";
        //}



        cmd1.CommandText = query + ")";

        con.Open();
        cmd1.ExecuteNonQuery();
        con.Close(); con.Dispose();
    }
    private void OPDPrintReport()
    {
        try
        {
            BLLReports objBLLReports = new BLLReports();
            DataSet dsCustomers = new DataSet();
            //ReportDocument crystalReport = new ReportDocument();
            //crystalReport.Load(Server.MapPath("~/Report/Rpt_OPDBilling.rpt"));
            dsCustomers = objBLLReports.GetLabBillDetails(Convert.ToInt32(ViewState["BillNo"]), Convert.ToInt32(ViewState["ReceiptNo"]), Convert.ToInt32(ViewState["LabNo"]), Convert.ToInt32(ViewState["PatientInfoId"]), Convert.ToInt32(Session["FId"]), Convert.ToInt32(Session["BranchId"]));
            //crystalReport.SetDataSource(dsCustomers);
            ////crystalReport.ParameterFields["HospitalName"].CurrentValues.AddValue(Convert.ToString(Application["OrgnizationName"]));
            ////crystalReport.ParameterFields["HospitalAddress"].CurrentValues.AddValue(Convert.ToString(Application["OrgnizationAddress"]));
            ////crystalReport.ParameterFields["Image"].CurrentValues.AddValue(Application["ImagePath"]);
            //// crystalReport.ParameterFields["ReportFooter"].CurrentValues.AddValue("Hospital Software | Ph.020 0000000000");
            //crystalReport.ExportToHttpResponse
            //(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Employee");

            string sql = "";
            Session.Add("rptsql", sql);
            Session["rptname"] = Server.MapPath("~/Report/Rpt_LabBilling.rpt");
            Session["reportname"] = "LabReceipt";
            Session["RPTFORMAT"] = "pdf";

            //ReportParameterClass.SelectionFormula = sql;
            string close = "<script language='javascript'>javascript:OpenReport();</script>";
            Type title1 = this.GetType();
            Page.ClientScript.RegisterStartupScript(title1, "", close);

            //string PType = Convert.ToString(HttpContext.Current.Session["PType"]);

            // if (Convert.ToString(PType) == "")
            //{
            //    PType = "1";
            //}
            //string sql1 = "";
            //if (PType == "1")
            //{
            //    SqlConnection conn1 = DataAccess.ConInitForPathology();
            //    SqlCommand sc1 = conn1.CreateCommand();
            //    PatSt_Bal_C PBC = new PatSt_Bal_C();
            //    sc1.CommandText = "ALTER VIEW [dbo].[VW_cshbill_Pathology] AS (SELECT dbo.Cshmst.BillNo, dbo.Cshmst.RecDate, dbo.Cshmst.BillType, dbo.Cshmst.AmtReceived,  dbo.Cshmst.Discount, dbo.Cshmst.NetPayment, " +
            //       "  dbo.Cshmst.AmtPaid,   dbo.Cshmst.Balance,  dbo.Cshmst.username,dbo.Cshmst.OtherCharges,dbo.patmst.PatRegID, dbo.patmst.intial, dbo.patmst.Patname, " +
            //       "  dbo.patmst.sex, dbo.patmst.Age, dbo.patmst.Drname,  dbo.patmst.TelNo, dbo.DrMT.DoctorCode, dbo.DrMT.DoctorName, dbo.MainTest.Maintestname, " +
            //       "  dbo.MainTest.MTCode,  dbo.patmstd.TestRate, dbo.PackMst.PackageName, dbo.patmstd.PackageCode, dbo.Cshmst.DisFlag,  " +
            //       "  dbo.patmst.Patusername,   dbo.patmst.Patpassword, dbo.Cshmst.Comment,dbo.patmst.MDY,dbo.patmst.Remark AS PatientRemark,dbo.patmst.Pataddress, " +
            //       "  dbo.patmst.PPID ,dbo.Cshmst.PaymentType as UnitCode ,   Cshmst.TaxAmount, Cshmst.TaxPer, 0 as PrintCount , patmst.OtherRefDoctor,  " +
            //       " isnull(Cshmst.InsuranceCash,0)as InsuranceCash, isnull(InsuranceMaster.InsuranceName,'')as InsuranceName " +
            //       "  FROM         patmst INNER JOIN " +
            //       "  DrMT ON patmst.CenterCode = DrMT.DoctorCode AND patmst.Branchid = DrMT.Branchid INNER JOIN " +
            //       "  Cshmst INNER JOIN " +
            //       "  MainTest INNER JOIN " +
            //       "  patmstd ON MainTest.MTCode = patmstd.MTCode AND MainTest.Branchid = patmstd.Branchid ON Cshmst.PID = patmstd.PID AND " +
            //       "  Cshmst.Branchid = patmstd.Branchid ON patmst.PID = patmstd.PID AND patmst.Branchid = patmstd.Branchid INNER JOIN " +
            //       "  RecM ON Cshmst.BillNo = RecM.BillNo AND Cshmst.PID = RecM.PID AND Cshmst.Branchid = RecM.branchid LEFT OUTER JOIN " +
            //       "  InsuranceMaster ON Cshmst.InsuranceID = InsuranceMaster.ID LEFT OUTER JOIN " +
            //       "  PackMst ON patmstd.Branchid = PackMst.branchid AND patmstd.PackageCode = PackMst.PackageCode where DrMT.DrType='CC' and patmst.branchid=" + Session["Branchid"].ToString() + " and patmst.labRegMediPro='" + ViewState["LabNo"] + "' )";// and Cshmst.BillNo=" + bno + "


            //    conn1.Open();
            //    sc1.ExecuteNonQuery();
            //    conn1.Close(); conn1.Dispose();

            //    Session.Add("rptsql", sql1);
            //    Session["rptname"] = Server.MapPath("~/Report/Rpt_PayReceiptPatholog.rpt");
            //    Session["reportname"] = "CashReceipt";
            //    Session["RPTFORMAT"] = "pdf";
            //}
            //else if (PType == "2")
            //{
            //    SqlConnection conn1 = DataAccess.ConInitForRadiology();
            //    SqlCommand sc1 = conn1.CreateCommand();
            //    PatSt_Bal_C PBC = new PatSt_Bal_C();
            //    sc1.CommandText = "ALTER VIEW [dbo].[VW_cshbill_Radiology] AS (SELECT dbo.Cshmst.BillNo, dbo.Cshmst.RecDate, dbo.Cshmst.BillType, dbo.Cshmst.AmtReceived,  dbo.Cshmst.Discount, dbo.Cshmst.NetPayment, " +
            //       "  dbo.Cshmst.AmtPaid,   dbo.Cshmst.Balance,  dbo.Cshmst.username,dbo.Cshmst.OtherCharges,dbo.patmst.PatRegID, dbo.patmst.intial, dbo.patmst.Patname, " +
            //       "  dbo.patmst.sex, dbo.patmst.Age, dbo.patmst.Drname,  dbo.patmst.TelNo, dbo.DrMT.DoctorCode, dbo.DrMT.DoctorName, dbo.MainTest.Maintestname, " +
            //       "  dbo.MainTest.MTCode,  dbo.patmstd.TestRate, dbo.PackMst.PackageName, dbo.patmstd.PackageCode, dbo.Cshmst.DisFlag,  " +
            //       "  dbo.patmst.Patusername,   dbo.patmst.Patpassword, dbo.Cshmst.Comment,dbo.patmst.MDY,dbo.patmst.Remark AS PatientRemark,dbo.patmst.Pataddress, " +
            //       "  dbo.patmst.PPID ,dbo.Cshmst.PaymentType as UnitCode ,   Cshmst.TaxAmount, Cshmst.TaxPer, 0 as PrintCount , patmst.OtherRefDoctor,  " +
            //       " isnull(Cshmst.InsuranceCash,0)as InsuranceCash, isnull(InsuranceMaster.InsuranceName,'')as InsuranceName " +
            //       "  FROM         patmst INNER JOIN " +
            //       "  DrMT ON patmst.CenterCode = DrMT.DoctorCode AND patmst.Branchid = DrMT.Branchid INNER JOIN " +
            //       "  Cshmst INNER JOIN " +
            //       "  MainTest INNER JOIN " +
            //       "  patmstd ON MainTest.MTCode = patmstd.MTCode AND MainTest.Branchid = patmstd.Branchid ON Cshmst.PID = patmstd.PID AND " +
            //       "  Cshmst.Branchid = patmstd.Branchid ON patmst.PID = patmstd.PID AND patmst.Branchid = patmstd.Branchid INNER JOIN " +
            //       "  RecM ON Cshmst.BillNo = RecM.BillNo AND Cshmst.PID = RecM.PID AND Cshmst.Branchid = RecM.branchid LEFT OUTER JOIN " +
            //       "  InsuranceMaster ON Cshmst.InsuranceID = InsuranceMaster.ID LEFT OUTER JOIN " +
            //       "  PackMst ON patmstd.Branchid = PackMst.branchid AND patmstd.PackageCode = PackMst.PackageCode where DrMT.DrType='CC' and patmst.branchid=" + Session["Branchid"].ToString() + " and patmst.labRegMediPro='" + ViewState["LabNo"] + "' )";// and Cshmst.BillNo=" + bno + "


            //    conn1.Open();
            //    sc1.ExecuteNonQuery();
            //    conn1.Close(); conn1.Dispose();

            //    Session.Add("rptsql", sql1);
            //    Session["rptname"] = Server.MapPath("~/Report/Rpt_PayReceiptRadiology.rpt");
            //    Session["reportname"] = "CashReceiptRad";
            //    Session["RPTFORMAT"] = "pdf";
            //}
            //else
            //{
              
            //        SqlConnection conn1 = DataAccess.ConInitForMedical();
            //        SqlCommand sc1 = conn1.CreateCommand();
            //        PatSt_Bal_C PBC = new PatSt_Bal_C();
            //        sc1.CommandText = "ALTER VIEW [dbo].[VW_cshbill_MedicalStore] AS (SELECT dbo.Cshmst.BillNo, dbo.Cshmst.RecDate, dbo.Cshmst.BillType, dbo.Cshmst.AmtReceived,  dbo.Cshmst.Discount, dbo.Cshmst.NetPayment, " +
            //           "  dbo.Cshmst.AmtPaid,   dbo.Cshmst.Balance,  dbo.Cshmst.username,dbo.Cshmst.OtherCharges,dbo.patmst.PatRegID, dbo.patmst.intial, dbo.patmst.Patname, " +
            //           "  dbo.patmst.sex, dbo.patmst.Age, dbo.patmst.Drname,  dbo.patmst.TelNo, dbo.DrMT.DoctorCode, dbo.DrMT.DoctorName, dbo.MainTest.Maintestname, " +
            //           "  dbo.MainTest.MTCode,  dbo.patmstd.TestRate, dbo.PackMst.PackageName, dbo.patmstd.PackageCode, dbo.Cshmst.DisFlag,  " +
            //           "  dbo.patmst.Patusername,   dbo.patmst.Patpassword, dbo.Cshmst.Comment,dbo.patmst.MDY,dbo.patmst.Remark AS PatientRemark,dbo.patmst.Pataddress, " +
            //           "  dbo.patmst.PPID ,dbo.Cshmst.PaymentType as UnitCode ,   Cshmst.TaxAmount, Cshmst.TaxPer, 0 as PrintCount , patmst.OtherRefDoctor,  " +
            //           " isnull(Cshmst.InsuranceCash,0)as InsuranceCash, isnull(InsuranceMaster.InsuranceName,'')as InsuranceName " +
            //           "  FROM         patmst INNER JOIN " +
            //           "  DrMT ON patmst.CenterCode = DrMT.DoctorCode AND patmst.Branchid = DrMT.Branchid INNER JOIN " +
            //           "  Cshmst INNER JOIN " +
            //           "  MainTest INNER JOIN " +
            //           "  patmstd ON MainTest.MTCode = patmstd.MTCode AND MainTest.Branchid = patmstd.Branchid ON Cshmst.PID = patmstd.PID AND " +
            //           "  Cshmst.Branchid = patmstd.Branchid ON patmst.PID = patmstd.PID AND patmst.Branchid = patmstd.Branchid INNER JOIN " +
            //           "  RecM ON Cshmst.BillNo = RecM.BillNo AND Cshmst.PID = RecM.PID AND Cshmst.Branchid = RecM.branchid LEFT OUTER JOIN " +
            //           "  InsuranceMaster ON Cshmst.InsuranceID = InsuranceMaster.ID LEFT OUTER JOIN " +
            //           "  PackMst ON patmstd.Branchid = PackMst.branchid AND patmstd.PackageCode = PackMst.PackageCode where DrMT.DrType='CC' and patmst.branchid=" + Session["Branchid"].ToString() + " and patmst.labRegMediPro='" + ViewState["LabNo"] + "' )";// and Cshmst.BillNo=" + bno + "


            //        conn1.Open();
            //        sc1.ExecuteNonQuery();
            //        conn1.Close(); conn1.Dispose();

            //        Session.Add("rptsql", sql1);
            //        Session["rptname"] = Server.MapPath("~/Report/Rpt_PayReceiptMedical.rpt");
            //        Session["reportname"] = "CashReceiptMed";
            //        Session["RPTFORMAT"] = "pdf";
                
            //}
           // ReportParameterClass.SelectionFormula = sql1;
            //string close = "<script language='javascript'>javascript:OpenReport();</script>";
            //Type title1 = this.GetType();
            //Page.ClientScript.RegisterStartupScript(title1, "", close);
            //Session["PID_report"] = Convert.ToInt32(ViewState["PID"]);
            //Session["RecNo_report"] = 0;
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
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
       return objDALOpdReg.FillAllLAbService_Name(prefixText, Type, Convert.ToInt32( PType));


    }

    [WebMethod]
    [ScriptMethod]
    public static string[] FillTests(string prefixText, int count)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlDataAdapter sda = null;
        con.Open();
            sda = new SqlDataAdapter("SELECT        CAST(LabUK_01_04.dbo.MainTest.MTCode AS nvarchar(50)) + ' = ' +CAST( LabUK_01_04.dbo.MainTest.Maintestname AS nvarchar(50))+ ' = ' + CAST(LabUK_01_04.dbo.TestCharges.Amount AS nvarchar(50)) AS ServiceName "+
                               " FROM            LabUK_01_04.dbo.MainTest INNER JOIN "+
                               " LabUK_01_04.dbo.TestCharges ON LabUK_01_04.dbo.MainTest.MTCode = LabUK_01_04.dbo.TestCharges.STCODE AND LabUK_01_04.dbo.MainTest.Branchid = LabUK_01_04.dbo.TestCharges.Branchid WHERE LabUK_01_04.dbo.MainTest.Maintestname like '%" + prefixText + "%' ", con);
                              //  " select MTCode, Maintestname , 'T' as Tes from MainTest WHERE ISTestActive=1 and (MTCode like '%" + prefixText + "%' or Maintestname like '%" + prefixText + "%') order by Maintestname ", con);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        con.Close();
        con.Dispose();
        string[] tests = new String[dt.Rows.Count];
        int i = 0;
        foreach (DataRow dr in dt.Rows)
        {
           // tests.SetValue(dr["MTCode"] + " - " + dr["Maintestname"] + " - " + dr["Tes"], i);
            tests.SetValue(dr["ServiceName"] , i);
            i++;
        }

        return tests;
    }
    protected void ddlBillGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
       
            ViewState["GroupID"] = ddlBillGroup.SelectedValue;
            Session["GroupID"] = ddlBillGroup.SelectedValue;
        
    }
    protected void txtRefBy_TextChanged(object sender, EventArgs e)
    {
        if (txtRefBy.Text != "")
        {
            string[] PatientInfo = txtRefBy.Text.Split('=');
            if (PatientInfo.Length > 1)
            {
                txtRefBy.Text = PatientInfo[0];               
                ViewState["RefBy"] = PatientInfo[1];
            }
        }
    }

    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchReferBy1(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        return objDALOpdReg.FillAllConsultDoc(prefixText);
    }

    [WebMethod]
    [ScriptMethod]
    public static string[] SearchReferBy(string prefixText, int count)
    {
        SqlConnection con = new SqlConnection();
        string PType = Convert.ToString(HttpContext.Current.Session["PType"]);
        DataTable dt1 = new DataTable();
        // new String[dt1.Rows.Count];
        string[] DummyTest = new String[dt1.Rows.Count];
        if (Convert.ToString(PType) == "0")
        {
            PType = "0";
        }
        if (PType == "1")
        {
            con = DataAccess.ConInitForPathology();
        }
         if (PType == "2")
        {
            con = DataAccess.ConInitForRadiology();
        }
         if (PType == "3")
        {
            con = DataAccess.ConInitForMedical();
        }
         if (PType != "0")
         {
             string collectioncode = Convert.ToString(HttpContext.Current.Session["CenterCodeTemp"]);
             // string dd = HttpContext.Current.s(txtCenter.Text);
             SqlDataAdapter sda = null;
             con.Open();
             if (HttpContext.Current.Session["DigModule"] != null && HttpContext.Current.Session["DigModule"] != "0")
                 sda = new SqlDataAdapter("SELECT DoctorCode, rtrim(DrInitial)+' '+DoctorName as name from  DrMT where DrType='DR' AND  ( DoctorName like N'%" + prefixText + "%' or DoctorCode like N'%" + prefixText + "%' ) ", con);
             else
                 sda = new SqlDataAdapter("SELECT DoctorCode, rtrim(DrInitial)+' '+DoctorName as name from  DrMT where DrType='DR' AND  ( DoctorName like N'%" + prefixText + "%' or DoctorCode like N'%" + prefixText + "%' ) ", con);
             DataTable dt = new DataTable();
             sda.Fill(dt);
             con.Close();
             con.Dispose();
             string[] tests = new String[dt.Rows.Count];
             int i = 0;
             foreach (DataRow dr in dt.Rows)
             {
                 tests.SetValue(dr["name"] + " = " + dr["DoctorCode"], i);
                 i++;
             }
             return tests;
         }
         return DummyTest;
    }

    protected void txtPatientAddress_TextChanged(object sender, EventArgs e)
    {
        if (txtPatientAddress.Text != "")
        {
            if (validation() == true)
            {
                //objBELPatInfo = WriteDO1();
                //object[] Result = objDALPatInfo.InsertPatientInfo(objBELPatInfo);
                // Message = Convert.ToString(Result[0]);
                //ViewState["PatientInfoId"] = Convert.ToString(Result[1]);
                //ViewState["PatientInfoIDTemp"] = Convert.ToString(Result[1]);
                //string MSgShow = "Your Register number is:" + ViewState["PatientInfoId"] + " ";
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Patient already exits!.');", true);
               // ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + MSgShow.ToString() + "');", true);
               // lblMessage.Text = MSgShow;
               // lblMessage.ForeColor = System.Drawing.Color.Red;
               // txtPatientAddress.Enabled = false;
            }
        }
    }
    protected BELPatientInformation WriteDO1()
    {

        if (Convert.ToInt32(ViewState["PatientInfoIDTemp"]) > 0)
        {
            objBELPatInfo.UpdatedBy = Convert.ToString(Session["username"]);
            objBELPatInfo.PatientInfoId = Convert.ToInt32(ViewState["PatientInfoID"]);
        }
        else
        {
            objBELPatInfo.CreatedBy = Convert.ToString(Session["username"]);
            GetPatientID();
            objBELPatInfo.PatRegId = Convert.ToString(ViewState["PRNNo"]);
            objBELPatInfo.BarcodeId = Convert.ToString(ViewState["BarcodeId"]);
            objBELPatInfo.FId = Convert.ToInt32(Session["FId"]);
            objBELPatInfo.BranchId = Convert.ToInt32(Session["Branchid"]);
            //string s = txtPrnNo.Text;
            //string[] prnNo = s.Split('-');
            //objBELPatInfo.PatRegId = prnNo[1];
        }
        //objBELPatInfo.BarcodeId = txtBarCodeId.Text.Trim();

        if (ViewState["TitleID"] != null)
            objBELPatInfo.TitleId = Convert.ToInt32(ViewState["TitleID"]);
        else
            objBELPatInfo.TitleId = Convert.ToInt32(Convert.ToString(ddlTitleName.SelectedValue));

        objBELPatInfo.FirstName = txtPatientName.Text.Trim();
        //objBELPatInfo.MiddleName = txtMiddleName.Text.Trim();
        //objBELPatInfo.LastName = txtLastName.Text.Trim();

        //if (ViewState["PatientCategoryID"] != null)
        //    objBELPatInfo.PatMainTypeId = Convert.ToInt32(ViewState["PatientCategoryID"]);
        //else
        //    objBELPatInfo.PatMainTypeId = Convert.ToInt32(Convert.ToString(ddlPatientCategoryName.SelectedValue));

        //if (ViewState["PatientSubCategoryID"] != null)
        //    objBELPatInfo.PatientInsuTypeId = Convert.ToInt32(ViewState["PatientSubCategoryID"]);
        //else
        //    objBELPatInfo.PatientInsuTypeId = Convert.ToInt32(Convert.ToString(ddlPatientSubCategoryName.SelectedValue));
        //objBELPatInfo.PolicyNo = txtPolicyNo.Text;
        objBELPatInfo.PatMainTypeId = 0;
        objBELPatInfo.PatientInsuTypeId = 0;
        if (Convert.ToString(ViewState["GenderID"]) != "0")
            objBELPatInfo.GenderId = Convert.ToInt32(ViewState["GenderID"]);
        else
            objBELPatInfo.GenderId = Convert.ToInt32(Convert.ToString(ddlGender.SelectedValue));

        if (txtBirthDate.Text != "")
        {
            objBELPatInfo.BirthDate = Convert.ToDateTime(txtBirthDate.Text.Trim());

        }

        if (txtAge.Text != "")
        {
            objBELPatInfo.Age = txtAge.Text;
        }
        else
        {
            objBELPatInfo.Age = "";
        }
        objBELPatInfo.AgeType = ddlAge.SelectedValue;


        //if (chbxIsConfirmBirthDate.Checked)
        //    objBELPatInfo.IsConfirmBirthDate = true;
        //else
        //    objBELPatInfo.IsConfirmBirthDate = false;


        objBELPatInfo.BloodGroup = "";


        objBELPatInfo.MaritalStatus = Convert.ToString("");

        //if (ViewState["GuardianTitleID"] != null)
        //    objBELPatInfo.GuardianTitleId = Convert.ToInt32(ViewState["GuardianTitleID"]);
        //else
        //    objBELPatInfo.GuardianTitleId = Convert.ToInt32(Convert.ToString(ddlGuardianTitle.SelectedValue));


        //objBELPatInfo.GuardianName = txtGuardianName.Text.Trim();
        objBELPatInfo.MobileNo = txtMobileNo.Text.Trim();
        //objBELPatInfo.PhoneNo = txtPhoneNo.Text.Trim();
        objBELPatInfo.PatientAddress = txtPatientAddress.Text.Trim();

        if (ViewState["CountryID"] != null)
            objBELPatInfo.CountryId = Convert.ToInt32(ViewState["CountryID"]);
        else
            objBELPatInfo.CountryId = Convert.ToInt32(Convert.ToString(129));

        //if (ViewState["StateID"] != null)
        //    objBELPatInfo.StateId = Convert.ToInt32(ViewState["StateID"]);
        //else
        //    objBELPatInfo.StateId = Convert.ToInt32(Convert.ToString(ddlStateName.SelectedValue));

        //if (ViewState["CityID"] != null)
        //    objBELPatInfo.CityId = Convert.ToInt32(ViewState["CityID"]);
        //else
        //    objBELPatInfo.CityId = Convert.ToInt32(Convert.ToString(ddlCityName.SelectedValue));

        //if (ViewState["LandMarkID"] != null)
        //    objBELPatInfo.LandMarkId = Convert.ToInt32(ViewState["LandMarkID"]);
        //else
        //    objBELPatInfo.LandMarkId = Convert.ToInt32(Convert.ToString(ddlLandMarkName.SelectedValue));

        objBELPatInfo.Email = "";

        //objBELPatInfo.EntryDate =Convert.ToDateTime(txtEntryDate.Text);
        ////if (ImagePath.HasFile)
        ////{
        ////    FileInfo f = new FileInfo(ImagePath.PostedFile.FileName);
        ////   string FileName=f.FullName+""+f.Extension;
        objBELPatInfo.ImagePath = Convert.ToString(ViewState["PhotoPath"]);
        //}
        return objBELPatInfo;
    }
    protected void ddlTitleName_SelectedIndexChanged(object sender, EventArgs e)
    {
        int TitleId = Convert.ToInt32(ddlTitleName.SelectedValue.ToString());
        ViewState["TitleID"] = TitleId;
        objBELPatInfo = objDALPatInfo.GetGenderId(TitleId);
        ddlGender.SelectedValue = Convert.ToString(objBELPatInfo.GenderId);
        ViewState["GenderID"] = ddlGender.SelectedValue;
    }

    private void LoadTitleName()
    {
        ddlTitleName.DataSource = objDALPatInfo.FillTitleName();
        ddlTitleName.DataTextField = "Title";
        ddlTitleName.DataValueField = "TitleId";
        ddlTitleName.DataBind();
    }
    private void LoadGenderName()
    {
        ddlGender.DataSource = objDALPatInfo.FillGender();
        ddlGender.DataTextField = "GenderName";
        ddlGender.DataValueField = "GenderId";
        ddlGender.DataBind();
        ddlTitleName_SelectedIndexChanged(null, null);
    }

    protected void ddlGender_SelectedIndexChanged(object sender, EventArgs e)
    {
        string GenderId = ddlGender.SelectedValue.ToString();
        ViewState["GenderID"] = GenderId;
        txtMobileNo.Focus();
    }
    public bool validation()
    {

        if (txtPatientName.Text == "")
        {
            txtPatientName.Focus();
            txtPatientName.BackColor = Color.Red;
            return false;
        }
        else
        {
            txtPatientName.BackColor = Color.White;
        }
        if (txtBirthDate.Text == "")
        {
            txtBirthDate.Focus();
            txtBirthDate.BackColor = Color.Red;
            return false;
        }
        else
        {
            txtBirthDate.BackColor = Color.White;
        }

        if (txtAge.Text == "")
        {
            txtAge.Focus();
            txtAge.BackColor = Color.Red;
            return false;
        }
        else
        {
            txtAge.BackColor = Color.White;
        }
        if (txtMobileNo.Text == "")
        {
            txtMobileNo.Focus();
            txtMobileNo.BackColor = Color.Red;
            return false;
        }
        else
        {
            txtMobileNo.BackColor = Color.White;
        }

        if (txtPatientAddress.Text == "")
        {
            txtPatientAddress.Focus();
            txtPatientAddress.BackColor = Color.Red;
            return false;
        }
        else
        {
            txtPatientAddress.BackColor = Color.White;
        }

        return true;
    }
    protected void RBLLabType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RBLLabType.SelectedValue == "P")
        {
            Session["PType"] = 1;
        }
         if (RBLLabType.SelectedValue == "R")
        {
            Session["PType"] =2;
        }
        if (RBLLabType.SelectedValue == "M")
        {
            Session["PType"] = 3;
        }
        LoadMainDoctor();
    }

    protected void txtRefPhy_TextChanged(object sender, EventArgs e)
    {
        if (txtRefPhy.Text != "")
        {
            string[] PatientInfo = txtRefPhy.Text.Split('=');
            if (PatientInfo.Length > 1)
            {
                txtRefPhy.Text = PatientInfo[0];
                ViewState["RefPhy"] = PatientInfo[1];
            }
        }
    }

    public void GenerateQRCode( string LabRegNo)
    {
        Patmstd_Bal_C PBC = new Patmstd_Bal_C();
        string CounCode = "";
       // string p_fname = lblName.Text;
        DataTable dtQ = new DataTable();
        string Branchid = Convert.ToString(Session["Branchid"]);
       // string msg = PBC.GetSMSString("URL", Convert.ToInt16(Branchid));
        //string CounCode = PBC.GetSMSString_CountryCode("URL", Convert.ToInt16(Branchid));
        string PType = Convert.ToString(HttpContext.Current.Session["PType"]);

        if (Convert.ToString(PType) == "0")
        {
            PType = "0";
        }
        dtQ = objDALOpdReg.GetSMSString_CountryCode_Covid("URL", Convert.ToInt16(Branchid), PType);
        // CounCode = CounCode + "UrlReport//_"+Request.QueryString["PatRegID"].Trim()+".pdf";
        if (dtQ.Rows.Count > 0)
        {
            CounCode = dtQ.Rows[0]["CountryCode"] + "UrlReport//" + dtQ.Rows[0]["smsString"] + LabRegNo.Trim() + ".pdf";
        }
        string Code = CounCode;
        QrCodeEncodingOptions Option = new QrCodeEncodingOptions();
        var qrWrite = new BarcodeWriter(); ;
        qrWrite.Format = BarcodeFormat.QR_CODE;
        qrWrite.Options = new EncodingOptions() { Height = 100, Width = 100, Margin = 0 };

        var result = new Bitmap(qrWrite.Write(Code));
        byte[] byteImage;
        using (Bitmap bitMap = new Bitmap(qrWrite.Write(Code)))
        {
            using (MemoryStream ms = new MemoryStream())
            {
                bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                {
                    byteImage = ms.ToArray();
                }
            }
        }
        SqlConnection conn = DataAccess.ConInitForDC();
        SqlCommand sc = new SqlCommand("" +
        "Update LabRegistration " +
        "Set QRImage=@SignImage " +
        " Where PatRegID=@id ", conn);
        SqlDataReader sdr = null;
        if (byteImage != null)
        {
            sc.Parameters.AddWithValue("@SignImage", byteImage);
        }
        else
        {
            SqlParameter imageParameter = new SqlParameter("@SignImage", SqlDbType.Image);
            imageParameter.Value = DBNull.Value;
            sc.Parameters.Add(imageParameter);
        }

        sc.Parameters.AddWithValue("@id", ViewState["PatientInfoId"]);
        try
        {
            conn.Open();
            sc.ExecuteNonQuery();
        }
        finally
        {
            try
            {
                if (sdr != null) sdr.Close();
                conn.Close(); conn.Dispose();
            }
            catch (SqlException)
            {
                throw;
            }
        }
        //return byteImage;

    }

}