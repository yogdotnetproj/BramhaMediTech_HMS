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

public partial class EditOPDPatientRegistration :BasePage
{
   
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
    BELEmpReg objBELEmpReg = new BELEmpReg();
    DALEmpReg objDALEmpReg = new DALEmpReg();
    public enum MessageType { Success, Error, Info, Warning };
    


    string RegistrationTypeId = "";
    string UserId = "";


    string BillGroupId = "";
    string ServiceId = "";
    string ConsultantDrId = "";
    int DoctorId;
    double Billtotal = 0;
    string BirthDate = "";
    
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
            UploadedFiles.Visible = false;
            InsuranceDetails.Visible = false;
            billdetails.Visible = false;
            txtQty.Text = "1";
            rblPatcate_SelectedIndexChanged(null, null);
           // LoadRegistrationType();
            LoadPatientMainType();
           /// ddlPatientCategoryName_SelectedIndexChanged(null, null);
           // LoadPatientSubCategoryName();
            LoadConsultantDoc();
            FillDepartmentDrop();
            LoadInsuranceComp();
            LoadRdbPaymentType();
            LoadDiscountGivenBy();
            LoadReasonForDiscount();
            LoadReasonForBalance();
            LoadTitleName();
            LoadGenderName();
            
            RdbPayment.SelectedValue = "1";
            rdbdiscAmt.Checked = true;            
            PaymentDetails.Visible = false;
            LoadBillGroup();            
            LoadEmployeeName();
            SetDate();
            MakeBillTable();
            DataTable dt = (DataTable)ViewState["BillTable"];
            gvBill.DataSource = dt;
            gvBill.DataBind();

            if (Request.QueryString["Flag"] == "AddBill")
            {
               string PatientInfoId = Request.QueryString["PatRegId"];                
                ViewState["PatientInfoId"] = PatientInfoId;
                fillInformation();
                BindImages();
            }            

            else  if (Request.QueryString["PatientInfoID"] != null)
            {
               
                string PatientInfoId = Request.QueryString["PatientInfoID"];
                hfPatientId.Value = PatientInfoId;                
                Session["PatientId"] = PatientInfoId;
                ViewState["PatientInfoId"] = PatientInfoId;
                fillInformation();
                BindImages();
            }
            else
            {
                ViewState["PatientInfoId"] = "0";
                Session["PatientId"] = "0";
            }
            btnConsultation.Visible = false;
           // btnRdlcReport.Visible = false;
            btnCaseReport.Visible = false;

        }

        //this.RegisterPostBackControl();
    }

    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchPatient(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        return objDALOpdReg.FillAllPatient(prefixText);
    }
    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchService(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        return objDALOpdReg.FillService(prefixText);
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
        //lblPatRegId.Text = "PatRegId :" + Convert.ToString(ViewState["PatientInfoId"]);
        txtPatientName.Text = objBELPatInfo.FirstName;// + ' ' + objBELPatInfo.MiddleName + ' ' + objBELPatInfo.LastName;
        //ddlPatientCategoryName.SelectedValue = Convert.ToString(objBELPatInfo.PatMainTypeId);
        //ddlPatientCategoryName_SelectedIndexChanged(null, null);
        //ddlPatientSubCategoryName.SelectedValue=Convert.ToString(objBELPatInfo.PatientInsuTypeId);
        txtBirthDate.Text =Convert.ToString(objBELPatInfo.BirthDate);
        if (txtBirthDate.Text != "")
        {
            txtBirthDate.Text = DateTime.Parse(txtBirthDate.Text).ToString("dd/MM/yyyy");

            txtBirthDate_TextChanged(null, null);
        }
        ddlGender.SelectedValue = Convert.ToString( objBELPatInfo.GenderId);
        txtPatientAddress.Text = objBELPatInfo.PatientAddress;
        txtMobileNo.Text = objBELPatInfo.MobileNo;
        RblVaccineType.SelectedValue = Convert.ToString( objBELPatInfo.VaccinationStatus);
        DataTable dt = new DataTable();
        dt = objDALPatInfo.Get_ChangeDr(Convert.ToInt32(ViewState["PatientInfoId"]), Convert.ToInt32(Request.QueryString["OpdNo"]));
        if (dt.Rows.Count > 0)
        {
            txtConsDoctorName.Text = Convert.ToString( dt.Rows[0]["DrName"]);
            txtdepartment.Text = Convert.ToString(dt.Rows[0]["DeptName"]);

            ViewState["DeptID"] = Convert.ToString(dt.Rows[0]["DeptId"]);
            ViewState["ConsultID"] = Convert.ToString(dt.Rows[0]["DrId"]);
        }
    }
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
    private void LoadPatientMainType()
    {
        //ddlPatientCategoryName.DataSource = objDALPatInfo.FillPatMainTypeDrop();
        //ddlPatientCategoryName.DataTextField = "PatMainType";
        //ddlPatientCategoryName.DataValueField = "PatMainTypeId";
        //ddlPatientCategoryName.DataBind();
    }

    private void LoadPatientSubCategoryName()
    {
        //ddlPatientSubCategoryName.DataSource = objDALPatInfo.FillPatInsuTypeDrop(Convert.ToInt32(ViewState["PatientCategoryID"]));
        //ddlPatientSubCategoryName.DataTextField = "PatientInsuType";
        //ddlPatientSubCategoryName.DataValueField = "PatientInsuTypeId";
        //ddlPatientSubCategoryName.DataBind();
    }

    //private void LoadRegistrationType()
    //{    
    //    ddlRegistrationType.DataSource=objDALOpdReg.FillRegistrationTypeName();
    //    ddlRegistrationType.DataValueField= "RegistrationTypeId";
    //    ddlRegistrationType.DataTextField = "RegistrationTypeName";
    //    ddlRegistrationType.DataBind();
    //    ddlRegistrationType.SelectedValue = "OPD";
            
    //}
    private void LoadReasonForDiscount()
    {

        ddlDiscReason.DataSource = objDALBillInfo.FillReasonForDiscount();
        ddlDiscReason.DataValueField = "DiscTypeId";
        ddlDiscReason.DataTextField = "DiscType";
        ddlDiscReason.DataBind();

    }
    private void LoadReasonForBalance()
    {
        
       ddlBalreason.DataSource=objDALBillInfo.FillReasonForBalance();
       ddlBalreason.DataValueField="ReasonForBalanceId";
       ddlBalreason.DataTextField = "ReasonForBalanceName";
       ddlBalreason.DataBind();

    }
    private void LoadRdbPaymentType()
    {
        
        RdbPayment.DataSource=objDALBillInfo.FillModeOfPayment();
        RdbPayment.DataValueField = "ModeOfPaymentId";
        RdbPayment.DataTextField = "ModeOfPaymentName";
        RdbPayment.DataBind();


    }   
   
    private void LoadConsultantDoc()
    {
        
        ddlConsDoctorName.DataSource= objDALOpdReg.FillConsultantDocName();
        ddlConsDoctorName.DataValueField = "DrId";
        ddlConsDoctorName.DataTextField = "EmpName";
        ddlConsDoctorName.DataBind();
    }


    private void LoadBillGroup()
    {
        ddlBillGroup.DataSource = objDALOpdReg.FillBillGroupNameOPD();
        ddlBillGroup.DataTextField = "GroupName";
        ddlBillGroup.DataValueField = "BillGroupId";
        ddlBillGroup.DataBind();


    }
    private void LoadInsuranceComp()
    {
        //ddlInsuranceCompName.DataSource = objDALOpdReg.FillInsuranceComp();
        //ddlInsuranceCompName.DataTextField = "InsuranceCompanyName";
        //ddlInsuranceCompName.DataValueField = "InsuranceCompanyId";
        //ddlInsuranceCompName.DataBind();
    }

    protected void FillDepartmentDrop()
    {
        ddlDepartment.DataSource = objDALEmpReg.FillDeptDrop();
        ddlDepartment.DataValueField = "DeptId";
        ddlDepartment.DataTextField = "DeptName";
        ddlDepartment.DataBind();
    }
    private void LoadRegistrationStatus()
    {
       // BLLCombo objBLLCombo = new BLLCombo();
        // FillCombo(ddlRegistrationStatus, objBLLCombo.FillRegistrationStatusName());
    }

    
    private void LoadEmployeeName()
    {
        //BLLCombo objBLLCombo = new BLLCombo();
        //  FillCombo(ddlStatusChangedBy, objBLLCombo.FillEmployeeName());
    }

    
     private void SetDate()
    {
       // txtRegistrationDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
       
    }

    
   
    private void MakeBillTable()
    {
        DataTable dt = new DataTable();
        dt.Clear();
       
       
        dt.Columns.Add("EmpName");       
        dt.Columns.Add("BillGroup");        
        dt.Columns.Add("Service");
        dt.Columns.Add("Qty");
        dt.Columns.Add("Charge");
        dt.Columns.Add("SingleBillServiceCharges");
        dt.Columns.Add("BillId");
        dt.Columns.Add("DrId");
        dt.Columns.Add("BillGroupId");
        dt.Columns.Add("BillServiceId");
        dt.Columns.Add("BillServiceDetailId");
        dt.Columns.Add("DeptId");
        ViewState["BillTable"] = dt;
    }

    private void SetRegistrationType()
    {

    }





    protected void ddlBillGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        BillGroupId = ddlBillGroup.SelectedValue;
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
        
        int BranchId=Convert.ToInt32(Session["Branchid"]);
        int FId =Convert.ToInt32(Session["FId"]);

        txtCharges.Text = objDALBillCharges.GetDocCharges(Convert.ToInt32(ViewState["ConsultID"]), Convert.ToInt32(ViewState["ServiceId"]), Convert.ToInt32(ViewState["PatientSubCategory"]), BranchId, FId);

    }
    private void SetChargesForDirectService()
    {

        int BranchId = Convert.ToInt32(Session["Branchid"]);
        int FId = Convert.ToInt32(Session["FId"]);

        txtCharges.Text = objDALBillCharges.GetDocCharges(0, Convert.ToInt32(ViewState["ServiceId"]), Convert.ToInt32(ViewState["PatientSubCategory"]), BranchId, FId);

    }

    
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        AddToGridView();
        ddlBillGroup.SelectedIndex = 0;        
       // ddlService.SelectedIndex = 0;
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
        DataTable dt = (DataTable)ViewState["BillTable"];
        DataRow dr = dt.NewRow();       
        
        //dr["DrId"] = ddlConsDoctorName.SelectedValue;
        dr["DrId"] = ViewState["ConsultID"];
        //if (ddlConsDoctorName.SelectedValue == "0")
        if (ViewState["ConsultID"] == "0")
        {
            dr["Empname"] = "";
        }
        else
        {
           // dr["Empname"] = ddlConsDoctorName.SelectedItem.Text;
            dr["Empname"] = txtConsDoctorName.Text;
        }
        int BranchId = Convert.ToInt32(Session["Branchid"]);
        int FId = Convert.ToInt32(Session["FId"]);
        objBELBillService = objDALOpdReg.GetDefaultGroup(FId,BranchId);
        dr["BillGroupId"] = Convert.ToInt32(objBELBillService.BillGroupId);
        dr["BillGroup"] = Convert.ToString(objBELBillService.GroupName);
        //dr["BillGroupId"] = Convert.ToInt32(Convert.ToString(ddlBillGroup.SelectedValue));
        //dr["BillGroup"] = ddlBillGroup.SelectedItem;
        dr["Qty"]=1;
        objBELBillService = objDALOpdReg.GetDefaultService(FId, BranchId);
        dr["BillServiceId"] = Convert.ToInt32(objBELBillService.BillServiceId);
        dr["Service"] = Convert.ToString(objBELBillService.ServiceName);
        ViewState["ServiceId"] = Convert.ToInt32(objBELBillService.BillServiceId);
        string Charges = "0";
         Charges = objDALBillCharges.GetDocCharges(Convert.ToInt32(ViewState["ConsultID"]), Convert.ToInt32(ViewState["ServiceId"]), Convert.ToInt32(ViewState["PatientSubCategory"]), BranchId, FId);

        dr["SingleBillServiceCharges"] = Charges;
          dr["Charge"] = Charges;
        dr["BillServiceDetailId"] = 0;
       // dr["DeptId"] = ddlDepartment.SelectedValue;
        dr["DeptId"] = ViewState["DeptID"];
        dt.Rows.Add(dr);
        ViewState["BillTable"] = dt;
    
        gvBill.DataSource = dt;
        gvBill.DataBind();
    }

    protected void gvBill_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int index = 0;
        string ID = (gvBill.DataKeys[e.RowIndex]["BillServiceDetailId"].ToString());
        DataTable dt = (DataTable)ViewState["BillTable"];
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (Convert.ToInt32(ID) == Convert.ToInt32(dt.Rows[i]["BillServiceDetailId"]))
            {
                index = i;
                break;
            }
        }
        dt.Rows.RemoveAt(index);
        //dt.Rows.RemoveAt(Convert.ToInt32(ID) - 1);
        ViewState["BillTable"] = dt;
        //gvBill.DeleteRow(e.RowIndex);
        gvBill.DataSource = dt;
        gvBill.DataBind();
        string Message = "1Record Deleted Sucessfully";
        ShowMessage("Record deleted successfully!", MessageType.Error);
        DynamicMessage(lblMessage, Message);
    }

    //protected void ddlPatientCategoryName_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //   int PatientCategoryId =Convert.ToInt32(ddlPatientCategoryName.SelectedValue);
    //    ViewState["PatientCategoryID"] = PatientCategoryId;
    //    LoadPatientSubCategoryName();
    //}


    //protected void ddlPatientSubCategoryName_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    int PatientSubCategoryId =Convert.ToInt32(ddlPatientSubCategoryName.SelectedValue);
    //    ViewState["PatientSubCategoryID"] = PatientSubCategoryId;
    //}

    public bool validationPatName()
    {
        bool flag = false;

        if (txtPatientName.Text == "")
        {
            if (ViewState["PatientInfoId"].ToString() == "0")
            {
                txtPatientName.Focus();
                txtPatientName.BorderColor = Color.Red;
                ViewState["Msg"] = "Please Select Patient!!";
                flag = false;
            }
        }
        else
        {
            if (ViewState["PatientInfoId"].ToString() == "0")
            {
                txtPatientName.Focus();
                txtPatientName.BorderColor = Color.Red;
                ViewState["Msg"] = "Please Select Patient!!";
                flag = false;
            }
            else
            {
                txtPatientName.BackColor = Color.White;
                flag = true;
            }
        }
        return flag;
    }

    protected void btnSave_Click(object sender, EventArgs e)
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

        //if (validationPatName() == true)
        //{
        //if (Convert.ToString(ViewState["PaidAmt"]) != "true")
        //{
        //    if (txtConsDoctorName.Text.Trim() == "")
        //    {
        //        lblvalidate.Text = "Enter Dr Name!";
        //        txtConsDoctorName.Focus();
        //        ShowMessage("Enter Dr Name!", MessageType.Warning);
        //        return;
        //    }
        //    if (gvBill.Rows.Count > 0)
        //    {

        //        if (Convert.ToDouble(txtAmount.Text) < Convert.ToDouble(txtPaid.Text))
        //        {
        //            lblvalidate.Text = "Paid amount should not be greater than total amount!";
        //            txtPaid.Focus();
        //            ShowMessage("Paid amount should not be greater than total amount!!", MessageType.Warning);

        //            return;
        //        }
        //        if (Convert.ToDouble(txtbalance.Text) > 0 && ddlBalreason.SelectedValue == "0")
        //        {
        //            lblvalidate.Text = "Select Reason for Balance!";
        //            gvBill.Caption = "Select Reason for Balance!";
        //            gvBill.ForeColor = System.Drawing.Color.Red;
        //            ddlBalreason.Focus();
        //            ddlBalreason.BorderColor = System.Drawing.Color.Red;
        //            ShowMessage("Select Reason for Balance!", MessageType.Warning);
        //            return;
        //        }
        //        if (Convert.ToDouble(txtDiscount.Text) > 0 && ddlDiscReason.SelectedValue == "0" & ddlDiscountGivenBy.SelectedValue == "0")
        //        {
        //            lblvalidate.Text = "Select Discount reason and given by!";
        //            gvBill.Caption = "Select Discount reason and given by!";
        //            gvBill.ForeColor = System.Drawing.Color.Red;
        //            ddlDiscReason.Focus();
        //            ddlDiscReason.BorderColor = System.Drawing.Color.Red;
        //            ddlDiscountGivenBy.Focus();
        //            ddlDiscountGivenBy.BorderColor = System.Drawing.Color.Red;
        //            ShowMessage("Select Discount reason and given by!", MessageType.Warning);
        //            return;
        //        }
        //        string Message = "";
        //        //if (Request.QueryString["PatientInfoID"] == null)
        //        //{
        //        //    if (ViewState["PatientInfoId"].ToString() == "0")
        //        //    {
        //        //        GetPatientID();
        objBELPatInfo = WriteToPatientReg();
        objDALPatInfo.UpdateDrInfo(objBELPatInfo);

        lblMessage.Text = "Dr change successfully";
                ShowMessage("Dr change successfully !", MessageType.Success);
       // object[] Result = objDALPatInfo.InsertPatientInfo(objBELPatInfo);
        //        //        Message = Convert.ToString(Result[0]);
        //        //        ViewState["PatientInfoId"] = Convert.ToString(Result[1]);
        //        //        Session["PatientId"] = Convert.ToString(Result[1]);
        //        //        hfPatientId.Value = Convert.ToString(Result[1]);
        //        //    }
        //        //}

        //        InsertRecortToAll();
        //        ShowMessage("Record Save Successfully!", MessageType.Success);
        //        btnConsultation.Visible = true;
        //        btnRdlcReport.Visible = true;
        //        btnCaseReport.Visible = true;
        //        ViewState["PaidAmt"] = "true";
        //    }
        //    else
        //    {
               
        //            lblvalidate.Text = "Enter Dr Name!";
        //            ShowMessage("Enter Dr Name!", MessageType.Warning);
        //            return;
                
        //    }

        //    }
        //    else
        //    {
        //        lblMessage.Text = "Record is already Saved";
        //        ShowMessage("Record is already Saved!", MessageType.Warning);
        //    }
        //}
        //else
        //{
        //    lblvalidate.Text = "Please Select Patient From List!!!";
        //    lblMessage.Text = "Please Select Patient From List!!!";
        //    ShowMessage("Please Select Patient From List!", MessageType.Warning);
        //    //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Select Patient From List!!!');", true);
        //    //return;

        //}


    }
    //public void  ReSet()
    //{
    //    txtTotalAmt.Text = Convert.ToString(ViewState["Total"]);
    //    txtbalance.Text = Convert.ToString(ViewState["Total"]);
    //    txtAmount.Text = Convert.ToString(ViewState["Total"]);
    //    txtDiscount.Text = "0";
    //    txtPaid.Text = "0";
    //}
    protected BELPatientInformation  WriteToPatientReg()
    {
        objBELPatInfo = new BELPatientInformation();
        objBELPatInfo.CreatedBy = Convert.ToString(Session["username"]);
        objBELPatInfo.UpdatedBy = Convert.ToString(Session["username"]);
        //string patientname = txtPatientName.Text.Trim();

        objBELPatInfo.FirstName = txtPatientName.Text.Trim();

        objBELPatInfo.PatRegId = Convert.ToString(Request.QueryString["PatRegId"]);



        objBELPatInfo.DeptId = Convert.ToInt32( ViewState["DeptID"]);
        objBELPatInfo.DrId = Convert.ToInt32(ViewState["ConsultID"]);
       // objBELPatInfo.PatRegId = Request.QueryString["PatientInfoID"];
        objBELPatInfo.OPDNo = Request.QueryString["OpdNo"];

        objBELPatInfo.ProcedureID = Convert.ToInt32( Request.QueryString["ProcId"]);

        return objBELPatInfo;
    }

    private void GetPatientID()
    {
        
         int returns = objDALPatInfo.GetPrnBarcodeNo();
         ViewState["PatientInfoId"] = Convert.ToString(returns + 1);      


    }

   //private void InsertNotPayment()
   // {

   //     string Message = "";
   //     object[] returns;
   //     BELPayment objBELPayment = new BELPayment();
   //     string date = DateTime.Now.ToShortDateString();
   //     objBELPayment.BillId = Convert.ToInt32(Convert.ToString(ViewState["BillID"]));
   //     objBELPayment.PaymentDate = Convert.ToDateTime(date).ToString();
   //     if (txtDiscount.Text != "")
   //     {
   //         objBELPayment.DiscountPercent = Convert.ToDecimal(ViewState["DiscountPercent"]);
   //         objBELPayment.DiscountGiven = Convert.ToDecimal(ViewState["DiscountAmount"]);
   //     }
   //     else
   //     {
   //         objBELPayment.DiscountPercent = 0;
   //         objBELPayment.DiscountGiven = 0;
   //     }
   //     objBELPayment.PaymentTypeId = Convert.ToInt32(RdbPayment.SelectedValue);
   //     if (ddlDiscReason.SelectedValue != "0")
   //     {
   //         objBELPayment.ReasonForDiscountId = Convert.ToInt32(ddlDiscReason.SelectedValue);
   //     }
   //     if (ddlDiscountGivenBy.SelectedValue != "0")
   //     {
   //         objBELPayment.DiscountGivenById = Convert.ToInt32(ddlDiscountGivenBy.SelectedValue);
   //     }
   //     if (ddlBalreason.SelectedValue != "0")
   //     {
   //         objBELPayment.ReasonForBalanceId = Convert.ToInt32(ddlBalreason.SelectedValue);
   //     }

   //     if (txtNumber.Text != "")
   //     {
   //         objBELPayment.ChequeCardNo = txtNumber.Text;
   //     }
   //     else
   //         objBELPayment.ChequeCardNo = "0";

   //     if (txtbankName.Text != "")
   //     {
   //         objBELPayment.BankName = txtbankName.Text;
   //     }
   //     else
   //         objBELPayment.BankName = "";
   //     if (txtchequedate.Text != "")
   //     {
   //         objBELPayment.ChequeDate = (Convert.ToDateTime(txtchequedate.Text).ToShortDateString());
   //     }


   //     objBELPayment.AmountPaidPerTransaction = Convert.ToDecimal(txtPaid.Text);
        
   //     objBELPayment.CreatedBy = Convert.ToString(Session["username"]);        
   //     returns = objDALBillDetail.InsertPayment(objBELPayment);
   //     Message = Convert.ToString(returns[0]);
   //     ViewState["PaymentId"] = Convert.ToInt32(returns[1]);
   //     DynamicMessage(lblMessage, Message);
   // }

    private void InsertRecortToAll()
    {
        if (gvBill.Rows.Count <= 0)
        {
            AddToGridView();
            ddlBillGroup.SelectedIndex = 0;            
            //ddlService.SelectedIndex = 0;            
            txtCharges.Text = "";
        }
          object[] returns;
          string Message = "";
            objBELOpdReg = new BELOPDPatReg();
            if (Request.QueryString["Flag"] == "AddBill")
            {
                ViewState["OpdNo"] = Convert.ToInt32(Request.QueryString["OpdNo"]);
               
                InsertInBill();
                InsertInBillDetail();
            }
            else
            {
                objBELOpdReg = WriteDO();
                returns = objDALOpdReg.InsertOPDPatientRegistration(objBELOpdReg);
                ViewState["OpdNo"] = Convert.ToInt32(returns[0]);
                if (ViewState["OpdNo"] == "0")
                {
                    Message = Convert.ToString(returns[0]);
                    DynamicMessage(lblMessage, Message);
                    return;
                }
                else
                {
                    lblVisitingNo.Text = Convert.ToString(returns[1]);
                    InsertInBill();
                    InsertInBillDetail();
                }
            }
           
    }

  
  
    
    protected BELOPDPatReg WriteDO()
    {
        objBELOpdReg = new BELOPDPatReg();
        if (Convert.ToInt32(ViewState["OpdNo"]) > 0)
        {
           
            
                objBELOpdReg.UpdatedBy = Convert.ToString(Session["usename"]);
        }
        else
        {
            
            objBELOpdReg.CreatedBy = Convert.ToString(Session["usename"]);
        }



        objBELOpdReg.PatRegId = Convert.ToInt32(Convert.ToString(ViewState["PatientInfoId"]));

      
       /// objBELOpdReg.PatMainTypeId = Convert.ToInt32(ddlPatientCategoryName.SelectedValue);
        objBELOpdReg.PatMainTypeId = Convert.ToInt32(rblPatcate.SelectedValue);
       /// objBELOpdReg.PatientInsuTypeId = Convert.ToInt32(ddlPatientSubCategoryName.SelectedValue);
        objBELOpdReg.PatientInsuTypeId = Convert.ToInt32(ViewState["PatientSubCategory"]);
        objBELOpdReg.FId = Convert.ToInt32(Session["FId"]);
        objBELOpdReg.BranchId = Convert.ToInt32(Session["BranchId"]);
       
        objBELOpdReg.DrId = Convert.ToInt32(ViewState["ConsultID"]);
        objBELOpdReg.VisitingNo = objDALOpdReg.GetMaxVisitingNo(objBELOpdReg);
        objBELOpdReg.TokenNo = objDALOpdReg.GetTokenNo(objBELOpdReg);
        objBELOpdReg.ReferenceDrName = txtDoctorName.Text;
        
        objBELOpdReg.DeptId = Convert.ToInt32(ViewState["DeptID"]);
       
        objBELOpdReg.PatientComplaint = txtPatientComplaint.Text.Trim();
        objBELOpdReg.VaccinationStatus = RblVaccineType.SelectedItem.Text.Trim(); 
       
        

        return objBELOpdReg;
    }

   
  

    private void InsertInBill()
    {
        object[] returns;
        string Message = "";
       BELBillInfo objBELBillInfo = new BELBillInfo();
     
        int BillNo = objDALBillInfo.GetMaxBillNo(Convert.ToInt32(Session["FId"]));
        objBELBillInfo.BillNo = BillNo + 1;
        ViewState["BillNo"] = objBELBillInfo.BillNo;
        int ReceiptNo = objDALBillInfo.GetMaxReceiptNo(Convert.ToInt32(Session["FId"]));
        objBELBillInfo.ReceiptNo = ReceiptNo + 1;
        ViewState["ReceiptNo"] = objBELBillInfo.ReceiptNo;
        objBELBillInfo.PatRegId = Convert.ToInt32(ViewState["PatientInfoId"]);
        objBELBillInfo.BillDate = System.DateTime.Now;
        objBELBillInfo.OpdNo = Convert.ToInt32(ViewState["OpdNo"]);
        if (txtDiscount.Text != "")
        {            
            objBELBillInfo.Discount = Convert.ToDecimal(ViewState["DiscountAmount"]);
        }
        else
        {
            objBELBillInfo.Discount = 0;

        }
        objBELBillInfo.AmountPaid = Convert.ToDecimal(txtPaid.Text);
        objBELBillInfo.Balance = Convert.ToDecimal(txtbalance.Text);
        
        if (ddlDiscReason.SelectedValue != "0")
        {
            objBELBillInfo.ReasonForDiscountId = Convert.ToInt32(ddlDiscReason.SelectedValue);
        }
        else
        {
            objBELBillInfo.ReasonForDiscountId = 0;
        }
        if (ddlDiscountGivenBy.SelectedValue != "0")
        {
            objBELBillInfo.DiscountGivenById = Convert.ToInt32(ddlDiscountGivenBy.SelectedValue);
        }
        if (ddlBalreason.SelectedValue != "0")
        {
            objBELBillInfo.ReasonForBalanceId = Convert.ToInt32(ddlBalreason.SelectedValue); ;
        }
        else
        {
            objBELBillInfo.ReasonForBalanceId = 0;
        }
        objBELBillInfo.PaymentType = RdbPayment.SelectedValue;
       
        objBELBillInfo.CreatedBy = Convert.ToString(Session["username"]);
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
            objBELBillInfo.ChequeDate = (Convert.ToDateTime(txtchequedate.Text).ToShortDateString());
        }
        //if (PaymentInsurance.Checked == true)
        //{
        //    objBELBillInfo.IsInsuranceFlag = true;
        //}
        //else
        //    objBELBillInfo.IsInsuranceFlag = false;
        //if (ddlInsuranceCompName.SelectedValue != "")
        //{
        //    objBELBillInfo.InsuranceCompId = Convert.ToInt32(ddlInsuranceCompName.SelectedValue);
        //}
        //else
        //{
        //    objBELBillInfo.InsuranceCompId = 0;
        //}
         if (ddlChargeSubCategory1.Text != "")
        {
            objBELBillInfo.InsuranceCompId = Convert.ToInt32(ViewState["PatientChargeSubCategory"]);
        }
        else
        {
            objBELBillInfo.InsuranceCompId = 0;
        }
        
        if (txtInsuranceAmt.Text != "")
        {
            if (rdblInsuranceAmt.SelectedValue == "0")
            {
                objBELBillInfo.InsuranceAmount = Convert.ToDecimal(txtInsuranceAmt.Text);
            }
            if (rdblInsuranceAmt.SelectedValue == "1")
            {
                objBELBillInfo.InsuranceAmount = Convert.ToDecimal((Convert.ToSingle(txtAmount.Text) * Convert.ToSingle(txtInsuranceAmt.Text)) / 100);

            }
        }
        else
        {
            objBELBillInfo.InsuranceAmount = 0;
        }

        objBELBillInfo.CreatedBy = Convert.ToString(Session["username"]);
        objBELBillInfo.BranchId = Convert.ToInt32(Session["Branchid"]);
        objBELBillInfo.FId = Convert.ToInt32(Session["FId"]);
           
        returns = objDALBillInfo.InsertBillTransaction(objBELBillInfo);
        ViewState["BillPaymentId"] = Convert.ToInt32(returns[0]);

    }

    private void InsertInBillDetail()
    {

        string Message = "";
        DataTable dt = (DataTable)ViewState["BillTable"];
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            objBELBillDetail = new BELBillDetails();
            objBELBillDetail.OpdNo = Convert.ToInt32(ViewState["OpdNo"]);
            objBELBillDetail.PatRegId = Convert.ToInt32(ViewState["PatientInfoId"]);
            objBELBillDetail.BillNo = Convert.ToInt32(ViewState["BillNo"]);
            if (Convert.ToInt32(dt.Rows[i]["BillGroupId"]) > 0)
                objBELBillDetail.BillGroupId = Convert.ToInt32(dt.Rows[i]["BillGroupId"]);
            if (Convert.ToInt32(dt.Rows[i]["BillServiceId"]) > 0)
                objBELBillDetail.BillServiceId = Convert.ToInt32(dt.Rows[i]["BillServiceId"]);
            //if (Convert.ToInt32(dt.Rows[i]["DrId"]) > 0)
                objBELBillDetail.EmployeeId = Convert.ToInt32(dt.Rows[i]["DrId"]);
           if((dt.Rows[i]["Qty"])!="")
               objBELBillDetail.Qty = Convert.ToDecimal(dt.Rows[i]["Qty"]);
           if (dt.Rows[i]["Charge"] != "")
                objBELBillDetail.TotalCharges = Convert.ToDecimal(dt.Rows[i]["Charge"]);
           if (dt.Rows[i]["SingleBillServiceCharges"] != "")
                 objBELBillDetail.Charges = Convert.ToDecimal(dt.Rows[i]["SingleBillServiceCharges"]);
                objBELBillDetail.CreatedBy =Convert.ToString(Session["username"]);
            objBELBillDetail.BranchId=Convert.ToInt32(Session["Branchid"]);
            objBELBillDetail.FId=Convert.ToInt32(Session["FId"]);
            objBELBillDetail.DeptId= Convert.ToInt32(dt.Rows[i]["DeptId"]);
           

           // if (Convert.ToInt32(dt.Rows[i]["DrId"]) > 0)
            //{
                Message = objDALBillDetail.InsertBillDetail(objBELBillDetail);
                DynamicMessage(lblMessage, Message);
            //}
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
        //ddlConsDoctorName.SelectedValue = "0";
        ViewState["ConsultID"] = "0";
        //ddlRegistrationType.SelectedIndex = -1;
        //txtRegistrationDate.Text = "";
        //txtKinName.Text = "";
        //txtKinRelation.Text = "";
        txtPatientComplaint.Text = "";
       // ddlShift.SelectedIndex = -1;

        ddlBillGroup.SelectedIndex = -1;
        //ddlService.SelectedIndex = -1;

        txtAmount.Text = "";
        txtbalance.Text = "";
        txtTotalAmt.Text = "";
        txtDiscount.Text = "";
        txtPaid.Text = "";
        ddlBalreason.SelectedValue = "0";
        ddlDiscReason.SelectedValue = "0";

        MakeBillTable();
        DataTable dt = (DataTable)ViewState["BillTable"];
        gvBill.DataSource = dt;
        gvBill.DataBind();

        txtReferanceDrText.Text = "";
        txtCharges.Text = "";
        SetDate();
        //SetShift();
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

       // ddlRegistrationType.SelectedValue = Convert.ToString(objBELOpdReg.RegistrationTypeId);
        //txtRegistrationDate.Text = Convert.ToString(objBELOpdReg.RegistrationDateTime);
        //txtKinName.Text = objBELOpdReg.KinName;
        //txtKinRelation.Text = objBELOpdReg.RelationOfKin;
        txtPatientComplaint.Text = objBELOpdReg.PatientComplaint;
        //ddlShift.SelectedValue = Convert.ToString(objBELOpdReg.ShiftId);
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
            if (DataBinder.Eval(e.Row.DataItem, "SingleBillServiceCharges") != "")
            {
                Billtotal += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "SingleBillServiceCharges"));
            }
            ViewState["Total"] = Billtotal;
            //DiscountToatl += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "DiscountGiven"));
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {

            e.Row.Cells[2].Text = "Total";
            e.Row.Cells[2].Font.Bold = true;
            //e.Row.Cells[8].HorizontalAlign.Equals("Right");
            e.Row.Cells[4].Text = Billtotal.ToString();
            e.Row.Cells[4].Font.Bold = true;
        }

        txtTotalAmt.Text = Convert.ToString(ViewState["Total"]);
        txtPaid.Text = Convert.ToString(ViewState["Total"]);
        txtAmount.Text = Convert.ToString(ViewState["Total"]);
        txtDiscount.Text = "0";
        txtbalance.Text = "0";


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
            txtPatientName.Text = PatientInfo[1];
            ViewState["PatientInfoId"] = PatientInfo[0];
            hfPatientId.Value = PatientInfo[0];
            //lblPatRegId.Text = "PatRegId :" + Convert.ToString(ViewState["PatientInfoId"]);      
            fillInformation();
            BindImages();
        }
       
       
    }

    protected void btnSaveandBill_Click(object sender, EventArgs e)
    {
        string Message = "";
        // if (ViewState["PatientInfoId"] == "0")
        if (Convert.ToString(ViewState["PaidAmt"]) != "true")
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
            if (Convert.ToDouble(txtAmount.Text) < Convert.ToDouble(txtPaid.Text))
            {
                lblvalidate.Text = "Paid amount should not be greater than total amount!";
                txtPaid.Focus();
                ShowMessage("Paid amount should not be greater than total amount!", MessageType.Warning);
                return;
            }
            if (Convert.ToDouble(txtbalance.Text) > 0 && ddlBalreason.SelectedValue == "0")
            {
                lblvalidate.Text = "Select Reason for Balance!";
                gvBill.Caption = "Select Reason for Balance!";
                gvBill.ForeColor = System.Drawing.Color.Red;
                ddlBalreason.Focus();
                ddlBalreason.BorderColor = System.Drawing.Color.Red;
                ShowMessage("Select Reason for Balance!", MessageType.Warning);
                return;
            }
            if (Convert.ToDouble(txtDiscount.Text) > 0 && ddlDiscReason.SelectedValue == "0" & ddlDiscountGivenBy.SelectedValue == "0")
            {
                lblvalidate.Text = "Select Discount reason and given by!";
                gvBill.Caption = "Select Discount reason and given by!";
                gvBill.ForeColor = System.Drawing.Color.Red;
                ddlDiscReason.Focus();
                ddlDiscReason.BorderColor = System.Drawing.Color.Red;
                ddlDiscountGivenBy.Focus();
                ddlDiscountGivenBy.BorderColor = System.Drawing.Color.Red;
                ShowMessage("Select Discount reason and given by!", MessageType.Warning);
                return;
            }
            if (txtConsDoctorName.Text.Trim() == "")
            {
                lblvalidate.Text = "Enter Dr Name!";
                txtConsDoctorName.Focus();
                ShowMessage("Enter Dr Name!", MessageType.Warning);
                return;
            }
            if (validationPatName() == true)
            {
                if (Session["PatientId"] == "0")
                {
                    if (ViewState["PatientInfoId"] == "0")
                    {
                        GetPatientID();
                        objBELPatInfo = WriteToPatientReg();
                        object[] Result = objDALPatInfo.InsertPatientInfo(objBELPatInfo);
                        Message = Convert.ToString(Result[0]);
                        ViewState["PatientInfoId"] = Convert.ToString(Result[1]);
                        Session["PatientId"] = Convert.ToString(Result[1]);
                        hfPatientId.Value = Convert.ToString(Result[1]);
                    }
                }

                InsertRecortToAll();
                // InsertPayment();
                ShowMessage("Record Save Successfully!", MessageType.Success);
                PrintReport();
                btnConsultation.Visible = true;
                btnRdlcReport.Visible = true;
                btnCaseReport.Visible = true;
            }
            else
            {
                lblvalidate.Text = "Please Select Patient From List!!!";
                lblMessage.Text = "Please Select Patient From List!!!";
                ShowMessage("Please Select Patient From List!", MessageType.Warning);
               // ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Select Patient From List!!!');", true);
               // return;
            }
        }        
       

    }

   

    //private void PrintReport()
    //{
    //    try
    //    {
    //        BLLReports objBLLReports = new BLLReports();
    //        DataSet dsCustomers = new DataSet();
    //        ReportDocument crystalReport = new ReportDocument();
    //        crystalReport.Load(Server.MapPath("~/Report/RptBillReportSearch1.rpt"));
    //        dsCustomers = objBLLReports.BillReport(Convert.ToString( ViewState["BillID"]));
    //        crystalReport.SetDataSource(dsCustomers);
    //        crystalReport.ParameterFields["HospitalName"].CurrentValues.AddValue(Convert.ToString(Application["OrgnizationName"]));
    //        crystalReport.ParameterFields["HospitalAddress"].CurrentValues.AddValue(Convert.ToString(Application["OrgnizationAddress"]));
    //        //crystalReport.ParameterFields["Image"].CurrentValues.AddValue(Application["ImagePath"]);
    //        crystalReport.ParameterFields["ReportFooter"].CurrentValues.AddValue("Hospital Software | Ph.020 0000000000");
    //        crystalReport.ExportToHttpResponse
    //        (CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Employee");
    //    }
    //    catch (Exception ex)
    //    {
    //        lblMessage.Text = ex.Message; 
    //    }
    //}

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

    protected void btnConsultation_Click(object sender, EventArgs e)
    {
        string url = "";
        string PatientInfoID = Convert.ToString(ViewState["PatientInfoId"]);
        Session["PatientInfoID"] = PatientInfoID;
        string PatientRegistrationID = Convert.ToString(ViewState["PatientRegistrationID"]);
        ViewState["PatientRegistrationID"] = Convert.ToString(ViewState["PatientRegistrationID"]);

        ViewState["FormType"] = "Consultant";
        url = "~/PatientConsultation.aspx?PatientRegistrationId=" + Convert.ToString(ViewState["PatientRegistrationID"]) + "&& FormType=" + Convert.ToString(ViewState["FormType"]);
        Response.Redirect(url);



    }
    protected void btnRdlcReport_Click(object sender, EventArgs e)
    {
        if (Convert.ToString(ViewState["PaidAmt"]) != "true")
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
            if (Convert.ToDouble(txtAmount.Text) < Convert.ToDouble(txtPaid.Text))
            {
                lblvalidate.Text = "Paid amount should not be greater than total amount!";
                return;
            }
            if (Convert.ToDouble(txtbalance.Text) > 0 && ddlBalreason.SelectedValue == "0")
            {
                lblvalidate.Text = "Select Reason for Balance!";
                gvBill.Caption = "Select Reason for Balance!";
                gvBill.ForeColor = System.Drawing.Color.Red;
                ddlBalreason.Focus();
                ddlBalreason.BorderColor = System.Drawing.Color.Red;
                return;
            }
            if (Convert.ToDouble(txtDiscount.Text) > 0 && ddlDiscReason.SelectedValue == "0" & ddlDiscountGivenBy.SelectedValue == "0")
            {
                lblvalidate.Text = "Select Discount reason and given by!";
                gvBill.Caption = "Select Discount reason and given by!";
                gvBill.ForeColor = System.Drawing.Color.Red;
                ddlDiscReason.Focus();
                ddlDiscReason.BorderColor = System.Drawing.Color.Red;
                ddlDiscountGivenBy.Focus();
                ddlDiscountGivenBy.BorderColor = System.Drawing.Color.Red;
                return;
            }
            if (validationPatName() == true)
            {
                InsertRecortToAll();
                // InsertPayment();
                string url = "";
                ViewState["FormType"] = "OPDBill";

                url = "RDLCReport/RDLCReport.aspx?BillId=" + Convert.ToString(ViewState["BillID"]) + "&&FormType=" + Convert.ToString(ViewState["FormType"]);
                // Response.Redirect(url);
                string fullURL = "window.open('" + url + "','_blank')";

                ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", fullURL, true);
            }
        }

        //Server.Transfer(url);
    }

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
       // if (Convert.ToBoolean(ViewState["IsDirect"]) != true)
        //{
           
            ConsultantDrId = ddlConsDoctorName.SelectedValue.ToString();

            ViewState["ConsultantDrID"] = ConsultantDrId;
            DoctorId = Convert.ToInt32(ConsultantDrId);
            int BranchId = Convert.ToInt32(Session["Branchid"]);
            int FId = Convert.ToInt32(Session["FId"]);
            SetCharges();
            string DeptId=objDALOpdReg.GetDeptId(Convert.ToInt32(ddlConsDoctorName.SelectedValue),FId,BranchId);
           // ddlConsDoctorName
       // ddlDepartment.SelectedValue = DeptId;
            ViewState["DeptID"] = DeptId;
        btnAdd_Click(null, null);
          //  AddToGridView();
            //if (txtCharges.Text != "")
            //{
            //    txtTotalCharges.Text = Convert.ToString(Convert.ToDecimal(txtCharges.Text) * Convert.ToDecimal(txtQty.Text));
            //}
        //}

    }
    protected void txtDiscount_TextChanged(object sender, EventArgs e)
    {
        if (rdbdiscAmt.Checked)
        {
            if (txtDiscount.Text != "")
            {
                txtAmount.Text = Convert.ToString(Convert.ToDouble(txtTotalAmt.Text) - Convert.ToDouble(txtDiscount.Text));
                txtPaid.Text = Convert.ToString(Convert.ToDouble(txtAmount.Text));
                txtbalance.Text = Convert.ToString(Convert.ToDouble(txtAmount.Text) - Convert.ToDouble(txtPaid.Text));

                ViewState["DiscountPercent"] = (Convert.ToDouble(txtDiscount.Text) * 100) / Convert.ToDouble(txtTotalAmt.Text);
                ViewState["DiscountAmount"] = Convert.ToDouble(txtDiscount.Text);
            }
        }
        else
        {
            if (txtDiscount.Text != "")
            {
                txtAmount.Text = Convert.ToString(Convert.ToDouble(txtTotalAmt.Text) - ((Convert.ToDouble(txtTotalAmt.Text) * Convert.ToDouble(txtDiscount.Text)) / 100));
                txtPaid.Text = Convert.ToString(Convert.ToDouble(txtAmount.Text));
                txtbalance.Text = Convert.ToString(Convert.ToDouble(txtAmount.Text) - Convert.ToDouble(txtPaid.Text));

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
    protected void ddlAge_SelectedIndexChanged(object sender, EventArgs e)
    {

        int Age = Convert.ToInt32(ddlAge.SelectedIndex);
        ViewState["Age"] = Convert.ToInt32(Age);

        if ((Convert.ToInt32(ViewState["Age"])) == 0)
        {
            int age = Convert.ToInt32(txtAge.Text);

            ViewState["Year"] = Convert.ToString(DateTime.Now.Year - age);
            ViewState["Today"] = DateTime.Now.Day + "/" + DateTime.Now.Month.ToString("00") + "/" + ViewState["Year"];
            // txtBirthDate.Text = Convert.ToString(MyDateTime.GetMMDDYYYYDateString(ViewState["Today"].ToString())); 
            BirthDate = Convert.ToString(ViewState["Today"].ToString());//Date Format- dd/MM/yyyy 

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
                BirthDate = Convert.ToString(ViewState["Today"].ToString());//Date Format- dd/MM/yyyy 
            }
            else
            {
                ViewState["Month"] = Convert.ToString(DateTime.Now.Month - age);
                ViewState["Today"] = DateTime.Now.Day + "/" + ViewState["Month"] + "/" + DateTime.Now.Year;
                //txtBirthDate.Text = Convert.ToString(MyDateTime.GetMMDDYYYYDateString(ViewState["Today"].ToString()));
                BirthDate = Convert.ToString(ViewState["Today"].ToString());//Date Format- dd/MM/yyyy 
            }
        }
        else
        {
            int age = Convert.ToInt32(txtAge.Text);
            ViewState["Day"] = Convert.ToString(DateTime.Now.Day - age);
            ViewState["Today"] = ViewState["Day"] + "/" + DateTime.Now.Month.ToString("00") + "/" + DateTime.Now.Year;
            //txtBirthDate.Text = Convert.ToString(MyDateTime.GetMMDDYYYYDateString(ViewState["Today"].ToString()));
            BirthDate = Convert.ToString(ViewState["Today"].ToString());//Date Format- dd/MM/yyyy 
        }
    }
    protected void txtAge_TextChanged(object sender, EventArgs e)
    {
        ViewState["Today"] = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
        int age = Convert.ToInt32(txtAge.Text);

        ViewState["Year"] = Convert.ToString(DateTime.Now.Year - age);
        ViewState["Today"] = DateTime.Now.Day + "/" + DateTime.Now.Month.ToString("00") + "/" + ViewState["Year"];
        // txtBirthDate.Text = Convert.ToString(MyDateTime.GetMMDDYYYYDateString(ViewState["Today"].ToString())); //Convert.ToDateTime(MyDateTime.GetMMDDYYYYDateString(txtBirthDate.Text));
        string BirthDate = Convert.ToString(ViewState["Today"].ToString());//Date Format- dd/MM/yyyy 

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
        
        string[] Service = txtService.Text.Split('-');
        txtService.Text = Service[1];
        ViewState["ServiceId"] = Convert.ToInt32(Service[0]);
       // ddlBillGroup.SelectedValue=
        objBELBillService = objDALOpdReg.GetserviceInfo(Convert.ToInt32(ViewState["ServiceId"]));
        ddlBillGroup.SelectedValue = Convert.ToString(objBELBillService.BillGroupId);
        bool IsDirect = Convert.ToBoolean(objBELBillService.IsDirect);
        bool IsDocWise = Convert.ToBoolean(objBELBillService.Isdoc);
        
        if (IsDirect == true)
        {
            ViewState["IsDirect"] = true;
            SetChargesForDirectService();
            txtTotalCharges.Text = Convert.ToString(Convert.ToDecimal(txtCharges.Text) * Convert.ToDecimal(txtQty.Text));

        }
        else if (IsDocWise == true)
        {
            //if (ddlConsDoctorName.SelectedValue != "0")
              if(ViewState["ConsultID"] != "")
            {
                SetCharges();
                txtTotalCharges.Text = Convert.ToString(Convert.ToDecimal(txtCharges.Text) * Convert.ToDecimal(txtQty.Text));

            }
        }
    }
    protected void txtQty_TextChanged(object sender, EventArgs e)
    {
        if (txtCharges.Text != "")
        {
            txtTotalCharges.Text = Convert.ToString(Convert.ToDecimal(txtCharges.Text) * Convert.ToDecimal(txtQty.Text));
        }
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
            txtAge.Text = intYear.ToString();
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
        else
        {
            txtAge.Text = intYear.ToString();
            ddlAge.SelectedIndex = 0;
        }
        //if (DateTime.Now.Year > Birthday.Year)
        //{
        //    int BirthAge = ((DateTime.Now.Year - Birthday.Year) * 372 + (DateTime.Now.Month - Birthday.Month) * 31 + (DateTime.Now.Day - Birthday.Day)) / 372;
        //    txtAge.Text = BirthAge.ToString();
        //    ddlAge.SelectedIndex = 0;
        //}

    }


    protected void btnUpload_Click(object sender, EventArgs e)
    {
        //dynamic fileUploadControl = fileuploadimages;
        //    if (fileUploadControl.HasFile == false)   
        //{  
        //    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", "script>alert('No File Uploaded.')</script>", false);  
        //}  
        //else  
        //{

        //foreach (HttpPostedFile postedFile in fileuploadimages.PostedFile)  
        //{
        if (ViewState["PatientInfoId"].ToString() != "0")
        {

            if (FileUpload1.HasFile)
            {

                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                filename = "UID" + ViewState["PatientInfoId"]+"-"+ filename ;
                string filePath = "~/OPDPatientFiles/" + filename;
                FileUpload1.SaveAs(Server.MapPath(filePath));
                SqlConnection conn = DataAccess.ConInitForDC();
                conn.Open();


                SqlCommand cmd = new SqlCommand("Insert into OPDPatientFiles(PatRegId,FileName,Path) values(@PatRegId,@FileName,@Path)", conn);
                cmd.Parameters.AddWithValue("@Path", filePath);
                cmd.Parameters.AddWithValue("@PatRegId", Convert.ToInt32(ViewState["PatientInfoId"]));
                cmd.Parameters.AddWithValue("@filename", filename);
                //    conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                conn.Dispose();
                BindImages();
                //}  
                // }  
            }
        }
        else
        {
            lblMessage.Text = "Please Select Patient";
            return;
        }
        //Response.Redirect(Request.Url.AbsoluteUri);   
    }
    private void RegisterPostBackControl()
    {
        foreach (GridViewRow row in gvImages.Rows)
        {
            LinkButton lnkbtn = row.FindControl("lnkDownload") as LinkButton;           
            ScriptManager.GetCurrent(this).RegisterPostBackControl(lnkbtn);
           

        }
    }
    protected void lnkDownload_Click(object sender, EventArgs e)
    {
        LinkButton lnkbtn = sender as LinkButton;
        GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;
       // this.RegisterPostBackControl();
        string filePath = gvImages.DataKeys[gvrow.RowIndex].Value.ToString();
        Response.ContentType = "image/jpg";
        Response.AddHeader("Content-Disposition", "attachment;filename=\"" + filePath + "\"");
        Response.TransmitFile(Server.MapPath(filePath));
        Response.End();
    }
    public void BindImages()
    {
        SqlConnection conn = DataAccess.ConInitForDC();
        conn.Open();

        using (SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM OPDPatientFiles where PatRegId="+ Convert.ToInt32(ViewState["PatientInfoId"]), conn))
            {
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    UploadedFiles.Visible = true;
                    gvImages.DataSource = dt;
                    gvImages.DataBind();
                }
                else
                {
                    UploadedFiles.Visible = false;

                }

            }
        conn.Close();
        conn.Dispose();
        
    }
    protected void gvImages_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int FileId = Convert.ToInt32(gvImages.DataKeys[e.RowIndex]["FileId"]);

        SqlConnection conn = DataAccess.ConInitForDC();
        conn.Open();


        SqlCommand cmd = new SqlCommand("Delete  OPDPatientFiles where FileId=@FileId ", conn);
        cmd.Parameters.AddWithValue("@FileId", FileId);
       // cmd.Parameters.AddWithValue("@PatRegId", Convert.ToInt32(ViewState["PatientInfoId"]));
       /// cmd.Parameters.AddWithValue("@filename", filename);
        
        cmd.ExecuteNonQuery();
        conn.Close();
        conn.Dispose();
       // BindImages();

       //  string Message = objDALOpdReg.DeleteBillGroup(Convert.ToInt32(BillGroupId));

       // DynamicMessage(lblMessage, Message);

        BindImages();
    }
    //protected void PaymentInsurance_CheckedChanged(object sender, EventArgs e)
    //{
    //    if (txtAmount.Text.Trim() != "")
    //    {
    //        if (txtAmount.Text.Trim() != "0")
    //        {
    //            if (PaymentInsurance.Checked == true)
    //            {


    //                InsuranceDetails.Visible = false;
    //                txtDiscount.Enabled = false;
    //                txtbalance.Text = txtAmount.Text;
    //                ddlDiscountGivenBy.Enabled = false;
    //                txtPaid.Enabled = false;
    //                txtPaid.Text = Convert.ToString(Convert.ToDecimal(txtAmount.Text) - Convert.ToDecimal(txtbalance.Text));
    //                ddlDiscReason.Enabled = false;
    //                btnSaveandBill.Enabled = false;

    //            }
    //            else
    //            {

    //                InsuranceDetails.Visible = false;
    //                txtPaid.Enabled = true;
    //                txtDiscount.Enabled = true;
    //                txtPaid.Text = txtAmount.Text;
    //                txtDiscount.Enabled = true;
    //                ddlDiscountGivenBy.Enabled = true;
    //                ddlDiscReason.Enabled = true;
    //                txtbalance.Text = Convert.ToString(Convert.ToDecimal(txtAmount.Text) - Convert.ToDecimal(txtPaid.Text));
    //                btnSaveandBill.Enabled = true;
    //            }
    //        }
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
        if (txtInsuranceAmt.Text != "0" && txtInsuranceAmt.Text != "")
        {
            if (rdblInsuranceAmt.SelectedValue == "1")
            {
                double InsuranceAmt = (Convert.ToSingle(txtAmount.Text) * Convert.ToSingle(txtInsuranceAmt.Text)) / 100;
                txtPaid.Text = Convert.ToString(Convert.ToSingle(txtAmount.Text) - InsuranceAmt);
                txtbalance.Text = Convert.ToString(Convert.ToSingle(txtAmount.Text) - (InsuranceAmt + Convert.ToSingle(txtPaid.Text)));
            }
            if (rdblInsuranceAmt.SelectedValue == "0")
            {
                txtPaid.Text = Convert.ToString(Convert.ToSingle(txtAmount.Text) - Convert.ToSingle(txtInsuranceAmt.Text));
                txtbalance.Text = Convert.ToString(Convert.ToSingle(txtAmount.Text) - (Convert.ToSingle(txtInsuranceAmt.Text) + Convert.ToSingle(txtPaid.Text)));

            }

        }
    }
    protected void txtAmount_TextChanged(object sender, EventArgs e)
    {

    }

    protected void ddlGender_SelectedIndexChanged(object sender, EventArgs e)
    {
       int GenderId = Convert.ToInt32(ddlGender.SelectedValue);
        ViewState["GenderID"] = GenderId;
    }
    private void LoadTitleName()
    {
        ddlTitleName.DataSource = objDALPatInfo.FillTitleName();
        ddlTitleName.DataTextField = "Title";
        ddlTitleName.DataValueField = "TitleId";
        ddlTitleName.DataBind();
    }
    protected void ddlTitleName_SelectedIndexChanged(object sender, EventArgs e)
    {
        int TitleId = Convert.ToInt32(ddlTitleName.SelectedValue.ToString());
        ViewState["TitleID"] = TitleId;
        objBELPatInfo = objDALPatInfo.GetGenderId(TitleId);
        ddlGender.SelectedValue = Convert.ToString(objBELPatInfo.GenderId);
        ViewState["GenderID"] = ddlGender.SelectedValue;
    }
    private void LoadGenderName()
    {
        ddlGender.DataSource = objDALPatInfo.FillGender();
        ddlGender.DataTextField = "GenderName";
        ddlGender.DataValueField = "GenderId";
        ddlGender.DataBind();
        ddlTitleName_SelectedIndexChanged(null, null);
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

                //ConsultantDrId = ddlConsDoctorName.SelectedValue.ToString();
                ConsultantDrId = Convert.ToString(ViewState["ConsultID"]);
                ViewState["ConsultantDrID"] = ConsultantDrId;
                DoctorId = Convert.ToInt32(ConsultantDrId);
                int BranchId = Convert.ToInt32(Session["Branchid"]);
                int FId = Convert.ToInt32(Session["FId"]);
                SetCharges();
                //string DeptId = objDALOpdReg.GetDeptId(Convert.ToInt32(ddlConsDoctorName.SelectedValue), FId, BranchId);
                string DeptId = objDALOpdReg.GetDeptId_WithName(Convert.ToInt32(ConsultantDrId), FId, BranchId);
                string[] DeptName = DeptId.Split('-');
                // ddlConsDoctorName
                //ddlDepartment.SelectedValue = DeptId;
                ViewState["DeptID"] = DeptName[0];
                txtdepartment.Text = DeptId;
                
                btnAdd_Click(null, null);
            }
        }
    }
    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchConsultDoc(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        return objDALOpdReg.FillAllConsultDoc(prefixText);
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

    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchDepartment(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        return objDALOpdReg.FillAllDepartment(prefixText);
    }

    public void Alter_view()
    {
        string sql = "";
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd1 = con.CreateCommand();

        string query = "ALTER VIEW [dbo].[VW_OPDCasePaper] AS (SELECT DISTINCT " +
              "  Initial.Title + ' ' + PatientInformation.FirstName AS FirstName, OpdRegistration.PatRegId, OpdRegistration.Entrydate, OpdRegistration.RegistrationType, OpdRegistration.ReferenceDoc, OpdRegistration.CreatedBy,  "+
             "   OpdRegistration.FId, OpdRegistration.BranchId, OpdRegistration.PatientComplaints, OpdRegistration.OpdNo, OpdIpdBillServiceDetails.BillServiceId, BillService.ServiceName, OpdIpdBillServiceDetails.DrId, "+
             "   HospEmpMst.Title + ' ' + HospEmpMst.Empname AS Empname, OpdIpdBillServiceDetails.BillServiceCharges, OpdIpdBillServiceDetails.BillNo, OpdIpdBillServiceDetails.Qty, OpdIpdBillServiceDetails.SingleBillServiceCharges, "+
             "   OpdRegistration.TokenNo, Initial.Title, Gender.GenderName, DepartmentMst.DeptName, HospEmpMst.Title AS DrInitial, PatientInformation.PatientAddress, PatientInformation.MobileNo, PatMainType.PatMainType  ,cast(PatientInformation.Age as nvarchar(50))+' '+ PatientInformation.AgeType as AgeType " +
             "   FROM            OpdRegistration INNER JOIN "+
             "   OpdIpdBillServiceDetails ON OpdRegistration.OpdNo = OpdIpdBillServiceDetails.OpdNo INNER JOIN "+
             "   PatientInformation ON OpdRegistration.PatRegId = PatientInformation.PatRegId INNER JOIN "+
             "   BillService ON OpdIpdBillServiceDetails.BillServiceId = BillService.BillServiceId INNER JOIN "+
             "   Initial ON PatientInformation.TitleId = Initial.TitleId INNER JOIN "+
             "   Gender ON PatientInformation.GenderId = Gender.GenderId INNER JOIN  "+
             "   DepartmentMst ON OpdRegistration.DeptId = DepartmentMst.DeptId INNER JOIN "+
             "   PatMainType ON OpdRegistration.PatientMainCategoryId = PatMainType.PatMainTypeId LEFT OUTER JOIN "+
             "   HospEmpMst ON OpdIpdBillServiceDetails.DrId = HospEmpMst.DrId " +
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

    protected void rblPatcate_SelectedIndexChanged(object sender, EventArgs e)
    {

        int PatientCategoryId = Convert.ToInt32(rblPatcate.SelectedValue);
        ViewState["PatientCategoryID"] = PatientCategoryId;
        Session["PatientCategoryID"] = PatientCategoryId;
        if (Convert.ToInt32(rblPatcate.SelectedValue) == 1)
        {
            ddlPatientSubCategoryName1.Text = "CASH";
            ViewState["PatientSubCategory"] = "1";
            ddlPatientSubCategoryName1.Enabled = false;
            ddlChargeSubCategory1.Enabled = false;
        }
        else
        {
            ddlPatientSubCategoryName1.Enabled = true;
            ddlChargeSubCategory1.Enabled = true;
            ddlPatientSubCategoryName1.Text = "";
            ViewState["PatientSubCategory"] = "";
        }
        LoadPatientSubCategoryName();
        if (Convert.ToInt32(rblPatcate.SelectedValue) != 1)
        {
            InsuranceDetails.Visible = true;
        }
        else
        {
            InsuranceDetails.Visible = true;
        }
        //if (RBLLabType.SelectedValue == "R")
        //{
        //    if (rblPatcate.SelectedValue == "2")
        //    {
        //        KKK.Visible = true;
        //        txtPaid.Text = "0";
        //        txtbalance.Text = txtTotalAmt.Text;
        //        txtPaid.Enabled = false;
        //    }
        //    else if (rblPatcate.SelectedValue == "3")
        //    {
        //        KKK.Visible = true;
        //        txtPaid.Text = "0";
        //        txtbalance.Text = txtTotalAmt.Text;
        //        txtPaid.Enabled = false;
        //    }
        //    else
        //    {
        //        KKK.Visible = false;
        //        txtPaid.Text = "0";
        //        txtbalance.Text = txtTotalAmt.Text;
        //    }
        //}
        //else
        //{
        //    KKK.Visible = true;
        //}
        //txtInsuranceAmt.Text = "0";
        //txtDiscount.Text = "0";
        //this.txtInsuranceAmt_TextChanged1(null, null);
        //this.txtDiscount_TextChanged(null, null);


    }

  
    protected void ddlPatientSubCategoryName1_TextChanged(object sender, EventArgs e)
    {
        if (Convert.ToString(ddlPatientSubCategoryName1.Text) != "")
        {
            if (ddlPatientSubCategoryName1.Text.Split('-').Length < 2)
            {
                hfPatientId.Value = "0";
                ViewState["PatientSubCategory"] = "0";
            }
            else
            {
                string[] PatientInfo = ddlPatientSubCategoryName1.Text.Split('-');
                ddlPatientSubCategoryName1.Text = PatientInfo[1];
                ViewState["PatientSubCategory"] = PatientInfo[0];
                Session["LabPatientSubCategory"] = PatientInfo[0];
                 ddlChargeSubCategory1.Text = "";
            }
        }
    }

    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchSubCategory(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        string PatientCategoryID = Convert.ToString(HttpContext.Current.Session["PatientCategoryID"]);
        return objDALOpdReg.FillAllSubCategoryName(prefixText, PatientCategoryID);
    }

    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchChargeSubCategory(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        string PatientCategoryID = Convert.ToString(HttpContext.Current.Session["LabPatientSubCategory"]);
        return objDALOpdReg.FillAllSubChargeCategoryName(prefixText, PatientCategoryID);
    }
    protected void ddlChargeSubCategory1_TextChanged(object sender, EventArgs e)
    {
        if (Convert.ToString(ddlChargeSubCategory1.Text) != "")
        {
            if (ddlChargeSubCategory1.Text.Split('-').Length < 2)
            {
                hfPatientId.Value = "0";
                ViewState["PatientChargeSubCategory"] = "0";
            }
            else
            {
                string[] PatientInfo = ddlChargeSubCategory1.Text.Split('-');
                ddlChargeSubCategory1.Text = PatientInfo[1];
                ViewState["PatientChargeSubCategory"] = PatientInfo[0];
               

                DataTable dt = new DataTable();
                dt = objDALPatInfo.Get_ChildCompany_Description(Convert.ToInt32(ViewState["PatientChargeSubCategory"]));
                if (dt.Rows.Count > 0)
                {
                    txtcompdes.Text = Convert.ToString(dt.Rows[0]["CompanyDescription"]);
                }
            }
        }
    }

}