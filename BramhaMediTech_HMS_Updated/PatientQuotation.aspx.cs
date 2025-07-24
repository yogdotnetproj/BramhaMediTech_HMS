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

using CrystalDecisions.Shared;
using System.Web.Management;
using System.Data;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Net.Mail;
using System.Web.Management;

public partial class PatientQuotation :BasePage
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
    Uniquemethod_Bal_C cl = new Uniquemethod_Bal_C();
    
    public enum MessageType { Success, Error, Info, Warning };
    string rptname = "", path = "", selectonFormula = "", PrintUserName = "";
    string RegistrationTypeId = "";
    string UserId = "";


    string BillGroupId = "";
    string ServiceId = "";
    string ConsultantDrId = "";
    int DoctorId;
    double Billtotal = 0;
    string BirthDate = "";
    string Date1 = DateTime.Now.ToString("ddMMyyyy");
    string Date2 = DateTime.Now.AddDays(-1).ToString("ddMMyyyy");
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
           
            txtQty.Text = "1";
            Session["UID"] = "Consultation";
            ViewState["PatientChargeSubCategory"] = "0";
           
            LoadPatientMainType();
            ddlPatientCategoryName_SelectedIndexChanged(null, null);
           
            LoadConsultantDoc();
            
            LoadRdbPaymentType();
            LoadDiscountGivenBy();
            LoadReasonForDiscount();
            LoadReasonForBalance();
           
      
           
           
            MakeBillTable();
            DataTable dt = (DataTable)ViewState["BillTable"];
            gvBill.DataSource = dt;
            gvBill.DataBind();

        //    if (Request.QueryString["Flag"] == "AddBill")
        //    {
        //        string PatientInfoId = Request.QueryString["PatRegId"];
        //        ViewState["PatientInfoId"] = PatientInfoId;
        //        fillInformation();
               
        //    }

        //    else 
            if (Request.QueryString["PatientInfoID"] != null)
            {

                string PatientInfoId = Request.QueryString["PatientInfoID"];
                hfPatientId.Value = PatientInfoId;
                Session["PatientId"] = PatientInfoId;
                ViewState["PatientInfoId"] = PatientInfoId;
                
                fillInformation();
               
                txtService.Text = "1- OPD Consultation";
                ViewState["ServiceId"] = "1";
                
        
            }
            else
            {
                ViewState["PatientInfoId"] = "0";
                Session["PatientId"] = "0";
            }
           

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
        
        string Type = Convert.ToString(HttpContext.Current.Session["UID"]);

        return objDALOpdReg.FillAllService_ForQuotation(prefixText, Type);
       
       
    }
    private void LoadDiscountGivenBy()
    {
       
    }
    protected void fillInformation()
    {
        objBELPatInfo = objDALPatInfo.SelectOne(Convert.ToInt32(ViewState["PatientInfoId"]));

        txtPatientName.Text = objBELPatInfo.FirstName;

        txtBirthDate.Text = Convert.ToDateTime(objBELPatInfo.BirthDate).ToShortDateString();
        txtPatientAddress.Text = objBELPatInfo.PatientAddress;
        txtMobileNo.Text = objBELPatInfo.MobileNo;
       string RegRemarks= objBELPatInfo.ChiefComplant;
       if (RegRemarks != "")
       {
           lblRemarks.Text = objBELPatInfo.ChiefComplant;
          // RegRemark.Visible = true;
       }
        if (Convert.ToDouble(objBELPatInfo.Age) < 0.084)
        {
            txtAge.Text = Convert.ToString(Math.Round((Convert.ToDecimal(objBELPatInfo.Age) * 12) * 30));
            ddlAge.SelectedValue = "Days";
        }
        else if (Convert.ToDouble(objBELPatInfo.Age) < 1)
        {
            txtAge.Text = Convert.ToString(Math.Round(Convert.ToDecimal(objBELPatInfo.Age) * 12));
            ddlAge.SelectedValue = "Months";
        }
        else
        {
            txtAge.Text = Convert.ToString(Math.Round(Convert.ToDecimal(objBELPatInfo.Age)));
            ddlAge.SelectedValue = "Years";
        }
        // txtLetterNo.Text = objBELPatInfo.ChiefComplant;
       
    }
    private void LoadPatientMainType()
    {
        
    }

    private void LoadPatientSubCategoryName()
    {
        
    }

   
    private void LoadReasonForDiscount()
    {

      

    }
    private void LoadReasonForBalance()
    {

    }
    private void LoadRdbPaymentType()
    {

    }
    private void LoadConsultantDoc()
    {

        ddlConsDoctorName.DataSource = objDALOpdReg.FillConsultantDocName();
        ddlConsDoctorName.DataValueField = "DrId";
        ddlConsDoctorName.DataTextField = "EmpName";
        ddlConsDoctorName.DataBind();
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
        dt.Columns.Add("DeptId");

      
       
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

        txtCharges.Text = objDALBillCharges.GetCharges_ForQuotation(Convert.ToInt32(ViewState["ConsultID"]), Convert.ToInt32(ViewState["ServiceId"]), Convert.ToInt32(ViewState["PatientSubCategory"]), BranchId, FId);

    }
    private void SetChargesForDirectService()
    {

        int BranchId = Convert.ToInt32(Session["Branchid"]);
        int FId = Convert.ToInt32(Session["FId"]);
        string Charges;
        Charges = objDALBillCharges.GetDocCharges(0, Convert.ToInt32(ViewState["ServiceId"]), Convert.ToInt32(ViewState["PatientSubCategory"]), BranchId, FId);
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
       
            if (ViewState["ConsultID"] != "0")
            {
                AddToGridView();
            }
            else
            {
                lblvalidate.Text = "Select Dr Name!";
                lblMessage.Text = "Select Dr Name!";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                txtConsDoctorName.Focus();
                txtConsDoctorName.Focus();
                txtConsDoctorName.BorderColor = System.Drawing.Color.Red;
                ShowMessage("select Dr Name!", MessageType.Warning);
            }
       
        
    }
    private void AddToGridView()
    {
        DataTable dt = (DataTable)ViewState["BillTable"];

        if (validationPatient() == true)
        {
            if (ViewState["Edit"].ToString() != "")
            {
                int index = Convert.ToInt32(ViewState["Index"]);
                dt.Rows[index]["Service"] = txtService.Text;
                dt.Rows[index]["Qty"] = txtQty.Text;
                dt.Rows[index]["SingleBillServiceCharges"] = txtCharges.Text;
                dt.Rows[index]["Charge"] = txtTotalCharges.Text;
                if (validationService() == true)
                {
                    dt.Rows[index]["BillServiceId"] = Convert.ToInt32(ViewState["ServiceId"]);
                }
                else
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + ViewState["Msg"] + "');", true);
                    return;


                }

                dt.Rows[index]["DrId"] = ViewState["ConsultID"];
            }
            else
            {

                DataRow dr = dt.NewRow();

                if (txtCharges.Text == "")
                {
                    txtCharges.Text = "0";
                }
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
                if (validationService() == true)
                {
                    dr["BillServiceId"] = Convert.ToInt32(ViewState["ServiceId"]);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + ViewState["Msg"] + "');", true);
                    return;
                }
                dr["Service"] = txtService.Text;
                dr["Charge"] =Convert.ToSingle(  txtCharges.Text) * Convert.ToSingle( txtQty.Text);
                dr["DeptId"] = ViewState["DeptID"];
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
    public void Clear()
    {
        ViewState["ServiceId"] = 0;
       // ViewState["ConsultID"] = 0;
        txtQty.Text = "1";
        txtService.Text = "";
       // txtConsDoctorName.Text = "";
        txtCharges.Text = "0";
        txtTotalCharges.Text ="0";
        ViewState["Edit"] = "";
        ViewState["DiscountAmount"] = "0";
       
       
        

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

       
        ViewState["DiscountAmount"] = "0";

       
        string Message = "1Record Deleted Sucessfully";
        DynamicMessage(lblMessage, Message);
    }
    protected void ddlPatientCategoryName_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }
    protected void ddlPatientSubCategoryName_SelectedIndexChanged(object sender, EventArgs e)
    {
       // int PatientSubCategoryId = Convert.ToInt32(ddlPatientSubCategoryName.SelectedValue);
       // ViewState["PatientSubCategoryID"] = PatientSubCategoryId;
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
        if (Convert.ToString(Session["Branchid"]) == null)
        {
            Response.Redirect("~/Login.aspx", false);
            return;
        }
       
        if (Convert.ToString(ViewState["PaidAmt"]) != "true")
        {
            if (gvBill.Rows.Count > 0)
            {
               

               
                
                string Message = "";
               
                
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

                 //   InsertRecortToAll_OPD();
                
               
                    InsertRecortToAll();
                    
                        PrintReport();
                       // string Obj_A_Test = "DD";
                       //// string[] Obj_A_Test = DispDespCode.Split(',');
                       // string[] targetArr = new string[Obj_A_Test.Length + 1];
                       // string[] urlArr = new string[Obj_A_Test.Length + 1];
                       // string[] featuresArr = new string[Obj_A_Test.Length + 1];

                       // targetArr[Obj_A_Test.Length] = "1";
                       // featuresArr[Obj_A_Test.Length] = "";

                       // urlArr[0] = "Redirect.aspx?rt=DescType&RepName=PrintReport//" + "$" + " lblName.Text" + "Date1" + "$" + Session["Branchid"] + "_" + Convert.ToInt32(Session["Branchid"]) + "_" + "Descriptive" + ".pdf";
                       // //urlArr[0] = "Redirect.aspx?";
                       // ResponseHelper.Redirect(urlArr, targetArr, featuresArr);
                    //this.btnCasePaper_Click(null, null);
                ShowMessage("Record save successfully!", MessageType.Success);
                ViewState["PaidAmt"] = "true";
                Clear();
               
                txtPatientName.Text = "";
                txtBirthDate.Text = "";
                txtAge.Text = "";
                txtLetterNo.Text = "";
                txtMobileNo.Text = "";
                txtPatientAddress.Text = "";
                MakeBillTable();
                DataTable dt = (DataTable)ViewState["BillTable"];
                gvBill.DataSource = dt;
                gvBill.DataBind();
            }


        }
        else
        {
            PrintReport();
            lblMessage.Text = "Record is already Saved";
            lblMessage.ForeColor = System.Drawing.Color.Red;
            ShowMessage("Record already saved!", MessageType.Warning);
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
        objBELPatInfo.PatMainTypeId = Convert.ToInt32(ViewState["PatientSubCategory"]);
        objBELPatInfo.PatientInsuTypeId = Convert.ToInt32(ViewState["PatientChargeSubCategory"]);
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
                 
            txtCharges.Text = "";
        }
        object[] returns;
        string Message = "";
        
            objBELOpdReg = WriteDO();

            returns = objDALOpdReg.InsertQuotationBillMaster(objBELOpdReg);
            //ViewState["BillNo"] = Convert.ToInt32(returns[1]);
            ViewState["ProcedureId"] = Convert.ToInt32(returns[0]);

       //     InsertInProcedureTransaction();
            InsertInBillDetail();
        
       
    }




    protected BELOPDPatReg WriteDO()
    {
        objBELOpdReg = new BELOPDPatReg();
        
        objBELOpdReg.PatRegId = Convert.ToInt32(Convert.ToString(ViewState["PatientInfoId"]));
       // objBELOpdReg.PatMainTypeId = Convert.ToInt32(rblPatcate.SelectedValue);
        objBELOpdReg.PatientInsuTypeId = Convert.ToInt32(ViewState["PatientSubCategory"]);
       //
        objBELOpdReg.BillAmount = Convert.ToDecimal(ViewState["Total"]);
       
            objBELOpdReg.DiscountAmt = 0;
            objBELOpdReg.PatientName = txtPatientName.Text;
            objBELOpdReg.Age = txtAge.Text;
            objBELOpdReg.AgeType = ddlAge.SelectedItem.Text;
            objBELOpdReg.MobileNo = txtMobileNo.Text;
            objBELOpdReg.PatientAddress = txtPatientAddress.Text;
            objBELOpdReg.DRName = txtConsDoctorName.Text;

            objBELOpdReg.PaidAmt = Convert.ToDecimal(0);
      
        
            objBELOpdReg.ReasonForDiscountId = 0;
        
       
            objBELOpdReg.DiscountGivenById = Convert.ToInt32(0);
       
            objBELOpdReg.ReasonForBalanceId = 0;
        
       
        
            objBELOpdReg.InsuranceAmount = 0;
        

        objBELOpdReg.CreatedBy = Convert.ToString(Session["username"]);
        objBELOpdReg.BranchId = Convert.ToInt32(Session["Branchid"]);
        objBELOpdReg.FId = Convert.ToInt32(Session["FId"]);

         objBELOpdReg.OpdNo = Convert.ToInt32( ViewState["OpdNo"]);
        // objBELOpdReg.BillGroupId = Convert.ToInt32(rdbgroup.SelectedValue);
        objBELOpdReg.InsuranceChargeCompamt= Convert.ToInt32(ViewState["PatientChargeSubCategory"]);

        objBELOpdReg.LetterNo = Convert.ToString(txtLetterNo.Text);
        objBELOpdReg.TypeOfVisit = Convert.ToString(ViewState["TypeOfVisit"]);
       // ViewState["OpdNo"]
      

        return objBELOpdReg;
    }


    public void UpdateDepositMaster()
    {
        objBELBillInfo.PatRegId = Convert.ToInt32(ViewState["PatientInfoId"]);
        objBELBillInfo.DepositAmount = -(Convert.ToDecimal(0));
        objBELBillInfo.CreatedBy = Convert.ToString(Session["username"]);
        objBELBillInfo.BranchId = Convert.ToInt32(Session["Branchid"]);
        objBELBillInfo.FId = Convert.ToInt32(Session["FId"]);
        objBELBillInfo.BillType = "Withdrawal";
        objBELBillInfo.Remark = "OPD Bill Payment";
        objBELBillInfo.PaymentType = "0";
        objBELBillInfo.flag = "OPDReceipt";
        objDALBillInfo.Insert_OPDDepositTransaction(objBELBillInfo);
       // GetDepositAmount(Convert.ToInt32(ViewState["PatientInfoId"]));
    }
    //public void GetDepositAmount(int Patregid)
    //{
    //    decimal DepositAmt = objDALOpdReg.GetDepositAmount(Convert.ToInt32(Patregid), Convert.ToInt32(Session["FId"]), Convert.ToInt32(Session["BranchId"]));
    //    ViewState["DepositAmt"] = DepositAmt;
    //    lblDepositAmt.Text = "(Deposit Amount=" + Convert.ToString(DepositAmt) + ")";

    //}
    //private void InsertInProcedureTransaction()
    //{
    //    //object[] returns;
    //    //string Message = "";
    //    BELBillInfo objBELBillInfo = new BELBillInfo();
    //    DALOpdReg objDALOpdReg=new DALOpdReg();
       
    //    objBELBillInfo.PatRegId = Convert.ToInt32(ViewState["PatientInfoId"]);        
    //    objBELBillInfo.AmountPaid = Convert.ToDecimal(txtPaid.Text);        
    //    objBELBillInfo.PaymentType = RdbPayment.SelectedValue;
    //    objBELBillInfo.BillNo = Convert.ToInt32(ViewState["BillNo"]);
    //   // objBELBillInfo.BillGroup = rdbgroup.SelectedItem.Text;
    //    objBELBillInfo.ProcedureId = Convert.ToInt32(ViewState["ProcedureId"]);
    //    objBELBillInfo.CreatedBy = Convert.ToString(Session["username"]);
    //    if (txtNumber.Text != "")
    //    {
    //        objBELBillInfo.ChequeCardNo = txtNumber.Text;
    //    }
    //    else
    //        objBELBillInfo.ChequeCardNo = "0";

    //    if (txtbankName.SelectedItem.Text != "Select Bank")
    //    {
    //        objBELBillInfo.BankName = txtbankName.SelectedItem.Text;
    //    }
    //    else
    //        objBELBillInfo.BankName = "";
    //    if (txtchequedate.Text != "")
    //    {
    //        objBELBillInfo.ChequeDate = (Convert.ToDateTime(txtchequedate.Text).ToShortDateString());
    //    }
        
        
    //    objBELBillInfo.CreatedBy = Convert.ToString(Session["username"]);
    //    objBELBillInfo.BranchId = Convert.ToInt32(Session["Branchid"]);
    //    objBELBillInfo.FId = Convert.ToInt32(Session["FId"]);

    //    //objBELBillInfo.OpdNo = Convert.ToInt32(Session["FId"]);
    //   // objBELBillInfo.ProcedureNo = Convert.ToInt32(Session["FId"]);
    //   // objBELBillInfo.FId = Convert.ToInt32(Session["FId"]);

    //    objDALOpdReg.InserProcedureBillTransaction(objBELBillInfo);
       

    //}
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

                  
           //  SetCharges();
               
        string DeptId = objDALOpdReg.GetDeptId_WithName(Convert.ToInt32(ViewState["ConsultID"]),Convert.ToInt32( Session["FId"]),Convert.ToInt32( Session["Branchid"]));
        string[] DeptName = DeptId.Split('-');
        // ddlConsDoctorName
        //ddlDepartment.SelectedValue = DeptId;
        ViewState["DeptID"] = DeptName[0];
       // txtdepartment.Text = DeptId;
       
           
        
    }
    private void InsertInBillDetail()
    {

        string Message = "";
        DataTable dt = (DataTable)ViewState["BillTable"];
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            objBELBillDetail = new BELBillDetails();
           
          //  objBELBillDetail.PatRegId = Convert.ToInt32(ViewState["PatientInfoId"]);
          //  objBELBillDetail.BillNo = Convert.ToInt32(ViewState["BillNo"]);
           // objBELBillDetail.BillGroupName = rdbgroup.SelectedItem.Text;
            if (Convert.ToInt32(dt.Rows[i]["BillServiceId"]) > 0)
                objBELBillDetail.BillServiceId = Convert.ToInt32(dt.Rows[i]["BillServiceId"]);           
          //  objBELBillDetail.EmployeeId = Convert.ToInt32(dt.Rows[i]["DrId"]);
            if ((dt.Rows[i]["Qty"].ToString()) != "")
                objBELBillDetail.Qty = Convert.ToDecimal(dt.Rows[i]["Qty"]);
            else
                objBELBillDetail.Qty = 1;
            if (dt.Rows[i]["Charge"].ToString() != "")
                objBELBillDetail.TotalCharges = Convert.ToDecimal(dt.Rows[i]["Charge"]);
            if (dt.Rows[i]["SingleBillServiceCharges"].ToString() != "")
                objBELBillDetail.Charges = Convert.ToDecimal(dt.Rows[i]["SingleBillServiceCharges"]);
            objBELBillDetail.CreatedBy = Convert.ToString(Session["username"]);
            objBELBillDetail.BranchId = Convert.ToInt32(Session["Branchid"]);
            objBELBillDetail.FId = Convert.ToInt32(Session["FId"]);
            objBELBillDetail.ProcedureId = Convert.ToInt32(ViewState["ProcedureId"]);
           // objBELBillDetail.PatMainTypeId = Convert.ToInt32(rblPatcate.SelectedValue);

           // objBELBillDetail.PatientInsuTypeId = Convert.ToInt32(ViewState["PatientSubCategory"]);

            Message = objDALBillDetail.Insert_QuotionServiceDetails(objBELBillDetail);
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

      
        txtLetterNo.Text = "";
        MakeBillTable();
        DataTable dt = (DataTable)ViewState["BillTable"];
        gvBill.DataSource = dt;
        gvBill.DataBind();

        txtReferanceDrText.Text = "";
        txtCharges.Text = "";
      
        Response.Redirect("~/Procedures.aspx",false);
       
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

       // txtTotalAmt.Text = Convert.ToString(ViewState["Total"]);


    }
    protected void txtPatientName_TextChanged(object sender, EventArgs e)
    {
        if (txtPatientName.Text != "")
        {
            if (txtPatientName.Text.Split('-').Length > 1)
            {
                string[] PatientInfo = txtPatientName.Text.Split('-');
                txtPatientName.Text = PatientInfo[1];
                ViewState["PatientInfoId"] = PatientInfo[0];
                hfPatientId.Value = PatientInfo[0];
              
                fillInformation();
                txtPatientName.BorderColor = Color.LightGray;
                  
                  //if (rdbgroup.SelectedValue == "1")
                  //{
                  //    txtService.Text = "1- OPD Consultation";
                  //    ViewState["ServiceId"] = "1";
                  //}
                
            }
            else
            {
                hfPatientId.Value = "0";
                ViewState["PatientInfoId"] = "0";
            }
        }
        else
        {
            ViewState["PatientInfoId"] = "0";
        }


    }
    public bool validationPatient()
    {
        bool flag = false;
        if (txtPatientName.Text == "")
        {
           
               // txtPatientName.Focus();
                txtPatientName.BorderColor = Color.Red;
                ViewState["Msg"] = "Enter Patient Name!!";
                flag = false;
           
        }
        else
        {    
                flag = true;
        }
        return flag;
    }



    public void Alter_view(int ProcedureId)
    {
        string sql = "";
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd1 = con.CreateCommand();

        string query = "ALTER VIEW [dbo].[VW_Quotation_Report] AS (SELECT DISTINCT  " +
                          " QuotationBillMaster.ProcedureId, QuotationBillMaster.PatRegId, QuotationBillMaster.PatientName, QuotationBillMaster.Age, QuotationBillMaster.AgeType, QuotationBillMaster.MobileNo, QuotationBillMaster.PatAddress, " +
                          "  QuotationBillMaster.DrName, QuotationBillMaster.BillAmount, QuotationBillMaster.FId, QuotationBillMaster.BranchId, QuotationBillMaster.CreatedBy, QuotationBillMaster.CreatedOn, QuotationBillMaster.UpdatedBy, " +
                          "  QuotationBillMaster.UpdatedOn, BillService.ServiceName, QuotionServiceDetails.BillServiceId, QuotionServiceDetails.BillServiceCharges, QuotionServiceDetails.Qty, QuotionServiceDetails.TotalCharges " +
                          "  FROM            QuotationBillMaster INNER JOIN " +
                          "  QuotionServiceDetails ON QuotationBillMaster.ProcedureId = QuotionServiceDetails.ProcedureId INNER JOIN " +
                          "  BillService ON QuotionServiceDetails.BillServiceId = BillService.BillServiceId  where QuotationBillMaster.ProcedureId=" + Convert.ToInt32(ProcedureId) + " ";
        // " where ProcedureBillMaster.branchid=" + Convert.ToInt32(Session["Branchid"]) + "  and ProcedureBillMaster.OpdNo= " + Convert.ToInt32(ViewState["OpdNo"]) + " and  ProcedureBillMaster.PatRegId= " + Convert.ToInt32(ViewState["PatientInfoId"]) + "";



        cmd1.CommandText = query + ")";

        con.Open();
        cmd1.ExecuteNonQuery();
        con.Close(); con.Dispose();
    }
   
    private void PrintReport()
    {
        try
        {
            
                string sql = "";
                Alter_view(Convert.ToInt32(ViewState["ProcedureId"]));
               

                Session.Add("rptsql", sql);
                Session["rptname"] = Server.MapPath("~/Reports/Rpt_Quotation_Report.rpt");
                Session["reportname"] = "Quotation_Report";
                Session["RPTFORMAT"] = "pdf";


                string close = "<script language='javascript'>javascript:OpenReport();</script>";
                Type title1 = this.GetType();
                Page.ClientScript.RegisterStartupScript(title1, "", close);


        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
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
            BLLReports objBLLReports = new BLLReports();
            DataSet dsCustomers = new DataSet();
            ReportDocument crystalReport = new ReportDocument();
            crystalReport.Load(Server.MapPath("~/Report/Rpt_CaseReport.rpt"));
            // dsCustomers = objBLLReports.CaseReport(Convert.ToString(ViewState["PatientRegistrationID"]));
            crystalReport.SetDataSource(dsCustomers);
            crystalReport.ParameterFields["HospitalName"].CurrentValues.AddValue(Convert.ToString(Application["OrgnizationName"]));
            crystalReport.ParameterFields["HospitalAddress"].CurrentValues.AddValue(Convert.ToString(Application["OrgnizationAddress"]));
            //crystalReport.ParameterFields["Image"].CurrentValues.AddValue(Application["ImagePath"]);
            crystalReport.ParameterFields["ReportFooter"].CurrentValues.AddValue("Hospital Software | Ph.020 0000000000");
            try
            {
                crystalReport.ExportToHttpResponse
                (CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Employee");
            }
            catch (Exception ex)
            {
            }
            finally
            {
                crystalReport.Close();
                ((IDisposable)crystalReport).Dispose();
                GC.Collect();
                GC.SuppressFinalize(crystalReport);
            }
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
  

    public bool validationService()
    {
        bool flag = false;
        if (txtService.Text == "")
        {
            if (ViewState["ServiceId"].ToString() == "0")
            {
                txtService.Focus();
                txtService.BorderColor = Color.Red;
                ViewState["Msg"] = "Please Select Service From List!!";
                flag = false;
            }
        }
        else
        {
            if (ViewState["ServiceId"].ToString() == "0")
            {
                txtService.Focus();
                txtService.BorderColor = Color.Red;
                ViewState["Msg"] = "Please Select Service From List!!";
                flag = false;
            }
            else
            {
                txtService.BorderColor = Color.LightGray;
                flag = true;
            }
        }
        return flag;
    }

    protected void txtService_TextChanged(object sender, EventArgs e)
    {

        if (txtService.Text != "")
        {
            string[] Service = txtService.Text.Split('-');
            if (txtService.Text.Split('-').Length > 1)
            {

                if (txtService.Text.Split('-').Length == 2)
                {
                    txtService.Text = Service[1];
                }
                if (txtService.Text.Split('-').Length == 3)
                {
                    txtService.Text = Service[1] + " " + Service[2];
                }
                if (txtService.Text.Split('-').Length == 4)
                {
                    txtService.Text = Service[1] + " " + Service[2] + " " + Service[3];
                }
                ViewState["ServiceId"] = Convert.ToInt32(Service[0]);
            }
            else
            {
                ViewState["ServiceId"] = "0";
            }
        }
        else
        {
            ViewState["ServiceId"] = "0";
        }
        if ( Convert.ToInt32( ViewState["ServiceId"]) > 0)
        {
            objBELBillService = objDALOpdReg.GetserviceInfo(Convert.ToInt32(ViewState["ServiceId"]));

            bool IsDirect = Convert.ToBoolean(objBELBillService.IsDirect);
            bool IsDocWise = Convert.ToBoolean(objBELBillService.Isdoc);

            if (IsDirect == true)
            {
                ViewState["IsDirect"] = true;
                SetChargesForDirectService();
                txtTotalCharges.Text = Convert.ToString(Convert.ToDecimal(txtCharges.Text) * Convert.ToDecimal(txtQty.Text));

            }
           
                    SetCharges();
                    if (txtCharges.Text == "")
                    {
                        txtCharges.Text = "0";
                    }
                    txtTotalCharges.Text = Convert.ToString(Convert.ToDecimal(txtCharges.Text) * Convert.ToDecimal(txtQty.Text));

                
            
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


    
  

   
    protected void txtAmount_TextChanged(object sender, EventArgs e)
    {

    }
    protected void rdbgroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        
       
            ViewState["OpdNo"] = "0";
       
        txtService.Text = "";
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
        ViewState["ServiceId"] = BillServiceId;
        
        ViewState["Index"] = index;
        ViewState["Edit"] = "1";
        ViewState["BillTable"] = dt;
        e.Cancel = true;
    }
    protected void txtCharges_TextChanged(object sender, EventArgs e)
    {
        if (txtCharges.Text != "")
        {
           
                txtQty_TextChanged(null, null);
            
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
   

    //==================================================================================

    private void InsertRecortToAll_OPD()
    {
        if (gvBill.Rows.Count <= 0)
        {
            AddToGridView();
           // ddlBillGroup.SelectedIndex = 0;
                     
            txtCharges.Text = "";
        }
        object[] returns;
        string Message = "";
        objBELOpdReg = new BELOPDPatReg();

                 objBELOpdReg = WriteDO_OPD();
            returns = objDALOpdReg.InsertOPDPatientRegistration(objBELOpdReg);
            ViewState["OpdNo"] = Convert.ToInt32(returns[0]);
            if (ViewState["OpdNo"] == "0")
            {
                Message = Convert.ToString(returns[0]);
                DynamicMessage(lblMessage, Message);
                return;
            }
            //else
            //{
            //    lblVisitingNo.Text = Convert.ToString(returns[1]);
            //    InsertInBill_OPD();
            //    InsertInBillDetail_OPD();
            //}
        

    }

    protected BELOPDPatReg WriteDO_OPD()
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
       // objBELOpdReg.PatMainTypeId = Convert.ToInt32(rblPatcate.SelectedValue);
        /// objBELOpdReg.PatientInsuTypeId = Convert.ToInt32(ddlPatientSubCategoryName.SelectedValue);
        objBELOpdReg.PatientInsuTypeId = Convert.ToInt32(ViewState["PatientSubCategory"]);
        objBELOpdReg.FId = Convert.ToInt32(Session["FId"]);
        objBELOpdReg.BranchId = Convert.ToInt32(Session["BranchId"]);

        objBELOpdReg.DrId = Convert.ToInt32(ViewState["ConsultID"]);
        objBELOpdReg.VisitingNo = objDALOpdReg.GetMaxVisitingNo(objBELOpdReg);
        objBELOpdReg.TokenNo = objDALOpdReg.GetTokenNo(objBELOpdReg);
        objBELOpdReg.ReferenceDrName = txtDoctorName.Text;

        //if(Convert.ToString(ViewState["DeptID"])!="")
        //{
        objBELOpdReg.DeptId = Convert.ToInt32(ViewState["DeptID"]);
       // }

        objBELOpdReg.PatientComplaint = txtPatientComplaint.Text.Trim();
        objBELOpdReg.VaccinationStatus = ""; ;



        return objBELOpdReg;
    }

    //private void InsertInBill_OPD()
    //{
    //    object[] returns;
    //    string Message = "";
    //    BELBillInfo objBELBillInfo = new BELBillInfo();

    //    int BillNo = objDALBillInfo.GetMaxBillNo(Convert.ToInt32(Session["FId"]));
    //    objBELBillInfo.BillNo = BillNo + 1;
    //    ViewState["BillNo"] = objBELBillInfo.BillNo;
    //    int ReceiptNo = objDALBillInfo.GetMaxReceiptNo(Convert.ToInt32(Session["FId"]));
    //    objBELBillInfo.ReceiptNo = ReceiptNo + 1;
    //    ViewState["ReceiptNo"] = objBELBillInfo.ReceiptNo;
    //    objBELBillInfo.PatRegId = Convert.ToInt32(ViewState["PatientInfoId"]);
    //    objBELBillInfo.BillDate = System.DateTime.Now;
    //    objBELBillInfo.OpdNo = Convert.ToInt32(ViewState["OpdNo"]);
    //    if (txtDiscount.Text != "")
    //    {
    //        objBELBillInfo.Discount = Convert.ToDecimal(ViewState["DiscountAmount"]);
    //    }
    //    else
    //    {
    //        objBELBillInfo.Discount = 0;

    //    }
    //    objBELBillInfo.AmountPaid = Convert.ToDecimal(txtPaid.Text);
    //    objBELBillInfo.Balance = Convert.ToDecimal(txtbalance.Text);

    //    if (ddlDiscReason.SelectedValue != "0")
    //    {
    //        objBELBillInfo.ReasonForDiscountId = Convert.ToInt32(ddlDiscReason.SelectedValue);
    //    }
    //    else
    //    {
    //        objBELBillInfo.ReasonForDiscountId = 0;
    //    }
    //    if (ddlDiscountGivenBy.SelectedValue != "0")
    //    {
    //        objBELBillInfo.DiscountGivenById = Convert.ToInt32(ddlDiscountGivenBy.SelectedValue);
    //    }
    //    if (ddlBalreason.SelectedValue != "0")
    //    {
    //        objBELBillInfo.ReasonForBalanceId = Convert.ToInt32(ddlBalreason.SelectedValue); ;
    //    }
    //    else
    //    {
    //        objBELBillInfo.ReasonForBalanceId = 0;
    //    }
    //    objBELBillInfo.PaymentType = RdbPayment.SelectedValue;

    //    objBELBillInfo.CreatedBy = Convert.ToString(Session["username"]);
    //    if (txtNumber.Text != "")
    //    {
    //        objBELBillInfo.ChequeCardNo = txtNumber.Text;
    //    }
    //    else
    //        objBELBillInfo.ChequeCardNo = "0";

    //    if (txtbankName.SelectedItem.Text != "Select Bank")
    //    {
    //        objBELBillInfo.BankName = txtbankName.SelectedItem.Text;
    //    }
    //    else
    //        objBELBillInfo.BankName = "";
    //    if (txtchequedate.Text != "")
    //    {
    //        objBELBillInfo.ChequeDate = (Convert.ToDateTime(txtchequedate.Text).ToShortDateString());
    //    }
       
       

    //    if (txtInsuranceAmt.Text != "")
    //    {
    //        if (rdblInsuranceAmt.SelectedValue == "0")
    //        {
    //            objBELBillInfo.InsuranceAmount = Convert.ToDecimal(txtInsuranceAmt.Text);
    //        }
    //        if (rdblInsuranceAmt.SelectedValue == "1")
    //        {
    //            //objBELBillInfo.InsuranceAmount = Convert.ToDecimal((Convert.ToSingle(txtAmount.Text) * Convert.ToSingle(txtInsuranceAmt.Text)) / 100);
    //            objBELBillInfo.InsuranceAmount = Convert.ToDecimal((Convert.ToSingle(txtTotalAmt.Text) * Convert.ToSingle(txtInsuranceAmt.Text)) / 100);
                
    //        }
    //    }
    //    else
    //    {
    //        objBELBillInfo.InsuranceAmount = 0;
    //    }

    //    objBELBillInfo.CreatedBy = Convert.ToString(Session["username"]);
    //    objBELBillInfo.BranchId = Convert.ToInt32(Session["Branchid"]);
    //    objBELBillInfo.FId = Convert.ToInt32(Session["FId"]);

    //    returns = objDALBillInfo.InsertBillTransaction(objBELBillInfo);
    //    ViewState["BillPaymentId"] = Convert.ToInt32(returns[0]);

    //}

    private void InsertInBillDetail_OPD()
    {

        string Message = "";
        DataTable dt = (DataTable)ViewState["BillTable"];
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            objBELBillDetail = new BELBillDetails();
            objBELBillDetail.OpdNo = Convert.ToInt32(ViewState["OpdNo"]);
            objBELBillDetail.PatRegId = Convert.ToInt32(ViewState["PatientInfoId"]);
            objBELBillDetail.BillNo = Convert.ToInt32(ViewState["BillNo"]);
           // if (Convert.ToInt32(dt.Rows[i]["BillGroupId"]) > 0)
                objBELBillDetail.BillGroupId = Convert.ToInt32(1);
            if (Convert.ToInt32(dt.Rows[i]["BillServiceId"]) > 0)
                objBELBillDetail.BillServiceId = Convert.ToInt32(dt.Rows[i]["BillServiceId"]);
            //if (Convert.ToInt32(dt.Rows[i]["DrId"]) > 0)
            objBELBillDetail.EmployeeId = Convert.ToInt32(dt.Rows[i]["DrId"]);
            if ((dt.Rows[i]["Qty"]) != "")
                objBELBillDetail.Qty = Convert.ToDecimal(dt.Rows[i]["Qty"]);
            if (dt.Rows[i]["Charge"] != "")
                objBELBillDetail.TotalCharges = Convert.ToDecimal(dt.Rows[i]["Charge"]);
            if (dt.Rows[i]["SingleBillServiceCharges"] != "")
                objBELBillDetail.Charges = Convert.ToDecimal(dt.Rows[i]["SingleBillServiceCharges"]);
            objBELBillDetail.CreatedBy = Convert.ToString(Session["username"]);
            objBELBillDetail.BranchId = Convert.ToInt32(Session["Branchid"]);
            objBELBillDetail.FId = Convert.ToInt32(Session["FId"]);
            objBELBillDetail.DeptId = Convert.ToInt32(dt.Rows[i]["DeptId"]);


            // if (Convert.ToInt32(dt.Rows[i]["DrId"]) > 0)
            //{
            Message = objDALBillDetail.InsertBillDetail(objBELBillDetail);
            DynamicMessage(lblMessage, Message);
            //}
        }
    }

    //==================================================================================

    protected void btnCasePaper_Click(object sender, EventArgs e)
    {
        try
        {
          //  Alter_view();
            PrintCasepaper_Report();
            //string sql = "";
            //BLLReports objBLLReports = new BLLReports();
           
            //Session.Add("rptsql", sql);
            //Session["rptname"] = Server.MapPath("~/Report/Rpt_CaseReport_New.rpt");
            //Session["reportname"] = "Rpt_CaseReport_New";
            //Session["RPTFORMAT"] = "pdf";
            ////ReportParameterClass.SelectionFormula = sql;
            //string close = "<script language='javascript'>javascript:OpenReport();</script>";
            //Type title1 = this.GetType();
            //Page.ClientScript.RegisterStartupScript(title1, "", close);
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void btnDataForm_Click(object sender, EventArgs e)
    {
        try
        {
            Alter_view_DataForm();
            string sql = "";
            BLLReports objBLLReports = new BLLReports();

            Session.Add("rptsql", sql);
            Session["rptname"] = Server.MapPath("~/Report/Rpt_GetDataForm_New.rpt");
            Session["reportname"] = "Rpt_GetDataForm_New";
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

   

    public void Alter_view_DataForm()
    {
        string sql = "";
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd1 = con.CreateCommand();

        string query = "ALTER VIEW [dbo].[VW_GetDataForm] AS (SELECT        PatientInformation.PatientInfoId, PatientInformation.PatRegId, PatientInformation.BarcodeId, PatientInformation.TitleId, PatientInformation.FirstName, PatientInformation.MiddleName, PatientInformation.LastName, "+
                          "  PatientInformation.PatMainTypeId, PatientInformation.PatientInsuTypeId, PatientInformation.PolicyNo, PatientInformation.GenderId, PatientInformation.BirthDate, PatientInformation.IsConfirmBirthDate, "+
                          "  PatientInformation.BloodGroup, PatientInformation.MaritalStatus, PatientInformation.GuardianTitleId, PatientInformation.GuardianName, PatientInformation.MobileNo, PatientInformation.PhoneNo, "+
                          "  PatientInformation.PatientAddress, PatientInformation.CountryId, PatientInformation.StateId, PatientInformation.CityId, PatientInformation.Email, PatientInformation.EntryDate, PatientInformation.ImagePath, "+
                          "  PatientInformation.CancelReason, PatientInformation.IsActive, PatientInformation.CreatedBy, PatientInformation.CreatedOn, PatientInformation.UpdatedBy, PatientInformation.UpdatedOn, PatientInformation.Age, "+
                          "  PatientInformation.AgeType, PatientInformation.BranchId, PatientInformation.FId, PatientInformation.Nationality, PatientInformation.BirthPlace, PatientInformation.VaccinationStatus, PatientInformation.Allergy,  "+
                          "  PatientInformation.ChiefComplant, PatientInformation.ReligionId, PatientInformation.HealthCardNo, PatientInformation.PassportNo, PatientInformation.RaceId, PatientInformation.Relation, PatientInformation.RelativeName, "+
                          "  PatientInformation.ContactNo, PatientInformation.RelaAddress, PatientInformation.Relation1, PatientInformation.RelativeName1, PatientInformation.ContactNo1, PatientInformation.RelaAddress1, Tbl_Race.RaceName, "+
                          "  ReligionMst.Religion, Gender.GenderName, Tbl_Relation.RelationName, Tbl_Relation_1.RelationName AS RelationName2,PatientInformation.ChiefComplant as TTT" + 
                          " FROM            PatientInformation LEFT OUTER JOIN "+
                          "  Tbl_Relation ON PatientInformation.Relation = Tbl_Relation.RelationId LEFT OUTER JOIN "+
                          "  Tbl_Relation AS Tbl_Relation_1 ON PatientInformation.Relation1 = Tbl_Relation_1.RelationId LEFT OUTER JOIN "+
                          "  Gender ON PatientInformation.GenderId = Gender.GenderId LEFT OUTER JOIN "+
                          "  ReligionMst ON PatientInformation.ReligionId = ReligionMst.ReligionID LEFT OUTER JOIN "+
                          "  Tbl_Race ON PatientInformation.RaceId = Tbl_Race.RaceID " +
        " where PatientInformation.branchid=" + Convert.ToInt32(Session["Branchid"]) + "  and  PatientInformation.PatRegId= " + Convert.ToInt32(ViewState["PatientInfoId"]) + "";
        //if (txtFrom.Value != "" && txtTo.Value != "")
        //{
        //    query += " and    DagnosisAssigtTpPatient.CreatedOn between ('" + Convert.ToDateTime(txtFrom.Value).ToString("MM/dd/yyyy") + "') and ('" + Convert.ToDateTime(txtTo.Value).AddDays(1).ToString("MM/dd/yyyy") + "')";
        //}



        cmd1.CommandText = query + ")";

        con.Open();
        cmd1.ExecuteNonQuery();
        con.Close(); con.Dispose();
    }

   // =======================Print Report=================================

    public void PrintCasepaper_Report()
    {
        #region for Casepaper

        

        CrystalDecisions.CrystalReports.Engine.ReportDocument rep = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
        string formula = "", formula1 = "";
        selectonFormula = ReportParameterClass.SelectionFormula;
        ReportDocument CR = new ReportDocument();
        CR.Load(Server.MapPath("~//Report/Rpt_CaseReport_New.rpt"));
        SqlConnection con = DataAccess.ConInitForDC();

        SqlDataAdapter sda = null;
        DataTable dt = new DataTable();

        sda = new SqlDataAdapter("select * from VW_OPDCasePaper_New where ProcedureId="+ ViewState["ProcedureId"]+" and PatRegID='" + Convert.ToInt32(ViewState["PatientInfoId"]) + "' ", con);

        sda.Fill(dt);

        CR.SetDataSource((System.Data.DataTable)dt);
        string path = Server.MapPath("/" + Request.ApplicationPath + "/PrintReceipt/");
        string filename1 = Server.MapPath("PrintReceipt//" + "$" + ViewState["ProcedureId"] + Date1 + "$" + Convert.ToInt32(ViewState["PatientInfoId"]) + "_" + Convert.ToInt32(Session["Branchid"]) + "_" + "CasePaper" + ".pdf");
        System.IO.File.WriteAllText(filename1, "");
        string exportedpath = "", selectionFormula = "";
        ReportParameterClass.SelectionFormula = "{VW_OPDCasePaper_New.ProcedureId}='" + Convert.ToInt32(ViewState["ProcedureId"]) + "' ";
        ReportDocument crReportDocument = null;
        if (CR != null)
        {
            crReportDocument = (ReportDocument)CR;
        }
        CrystalDecisions.Shared.PageMargins pm = CR.PrintOptions.PageMargins;

        int line = 10;
        pm.topMargin = 200 * line;

        exportedpath = filename1;

        cl.ExportandPrintr("pdf", path, exportedpath, formula, CR);

        CR.Close();
        CR.Dispose();
        GC.Collect();

        if (dt.Rows.Count == 0)
        {
            string filepath11 = Server.MapPath("PrintReceipt//" + "$" + ViewState["ProcedureId"] + Date1 + "$" + Convert.ToInt32(ViewState["PatientInfoId"]) + "_" + Convert.ToInt32(Session["Branchid"]) + "_" + "CasePaper" + ".pdf");
            FileInfo fi = new FileInfo(filepath11);
            fi.Delete();
           // Label44.Text = "Report Not Generated, Please Generate Once Again ";
            return;
        }
        string OrgFile = Server.MapPath("PrintReceipt//" + "$" + ViewState["ProcedureId"] + Date1 + "$" + Convert.ToInt32(ViewState["PatientInfoId"]) + "_" + Convert.ToInt32(Session["Branchid"]) + "_" + "CasePaper" + ".pdf");
        string DupFile = Server.MapPath("PrintReceipt//" + "$" + ViewState["ProcedureId"] + Date2 + "$" + Convert.ToInt32(ViewState["PatientInfoId"]) + "_" + Convert.ToInt32(Session["Branchid"]) + "_" + "CasePaper" + ".pdf");

        string[] FilePathSplitOrg = OrgFile.Split('$');
        string[] FilePathSplitDup = DupFile.Split('$');

        if (FilePathSplitOrg[1] != FilePathSplitDup[1])
        {
            foreach (string file in Directory.GetFiles(path))
            {
                string[] NewFile = file.Split('$');
                if (FilePathSplitOrg[1] != NewFile[1])
                {
                    File.Delete(file);
                }
            }
        }
        // Sundept


        Server.Transfer("PrintReceipt.aspx?ProcedureId=" + ViewState["ProcedureId"] + "&Date=" + Date1 + "&Patregid=" + Convert.ToInt32(ViewState["PatientInfoId"]) , false);
       // Response.Redirect("PrintReceipt//" + "$" + ViewState["ProcedureId"] + Date1 + "$" + Convert.ToInt32(ViewState["PatientInfoId"]) + "_" + Convert.ToInt32(Session["Branchid"]) + "_" + "CasePaper" + ".pdf");


        #endregion
    }

    protected void ChkPayforCash_CheckedChanged(object sender, EventArgs e)
    {
       
    }
  

}