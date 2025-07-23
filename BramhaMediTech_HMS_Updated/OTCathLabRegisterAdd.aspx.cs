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

public partial class OTCathLabRegisterAdd : BaseClass
{
    DALIPDDesk ObjDALIpd = new DALIPDDesk();
    BELOPDPatReg objBELIpd = new BELOPDPatReg();
    BELBillInfo objBELBillInfo = new BELBillInfo();
    DALBillInfo objDALBillInfo = new DALBillInfo();
    BELRoom objBELRoom = new BELRoom();
    DALRoom objDALRoom = new DALRoom();
    BELOPDPatReg objBELOpdReg = new BELOPDPatReg();
    DALOpdReg objDALOpdReg = new DALOpdReg();
    BELBillDetails objBELBillDetail = new BELBillDetails();
    DALBillDetails objDALBillDetail = new DALBillDetails();

    double Billtotal = 0;
    string Message = "";
  
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["RegId"] != "" && Request.QueryString["IpdId"] != "")
            {

                DateTime time = DateTime.Now;
                txttimestart.Text = DateTime.Now.ToString("dd/MM/yyyy");
                //String s = time.ToString("hh:mm tt");
                String s = time.ToString("hh:mm");
                txtTime.Text = s;

               
                txtDateEnd.Text = DateTime.Now.ToString("dd/MM/yyyy");
               // String ET = time.ToString("hh:mm tt");
                String ET = time.ToString("hh:mm");
                txttimeEnd.Text = ET;

                int RegId = Convert.ToInt32(Request.QueryString["RegId"]);
                int IpdId = Convert.ToInt32(Request.QueryString["IpdId"]);
                FillIpdPatInfo(RegId, IpdId);
                GetOptiRegisterDetails();
                //BindBillDetails();
                GetBillDetails();
                GetDepositAmount();
                FillGrid(Convert.ToInt32(RegId), Convert.ToInt32(Session["FId"]), Convert.ToInt32(Request.QueryString["IpdId"]), Convert.ToInt32(Request.QueryString["IpdId"]));
            }
            LoadDiscountGivenBy(); LoadReasonForDiscount(); LoadReasonForBalance();
            LoadBillServices(RdbServicesFlag.SelectedValue);
            RdbServicesFlagNew_SelectedIndexChanged(null, null);
            InsuranceDetails.Visible = false;
            LoadRdbPaymentType();
            RdbPayment.SelectedValue = "1";
            rdbdiscAmt.Checked = true;
            PaymentDetails.Visible = false;
            MakeBillTable();
        }

    }
    public void GetOptiRegisterDetails()
    {
         
        DataTable dt = new DataTable();

        using (SqlConnection con = DataAccess.ConInitForDC())
        {
            using (SqlCommand cmd = new SqlCommand("usp_GetIpdPatientOTRegister_Patient", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FId", Convert.ToInt32(Session["FId"]));
                cmd.Parameters.AddWithValue("@BranchId", Convert.ToInt32(Session["Branchid"]));
                cmd.Parameters.AddWithValue("@PatRegId", Convert.ToInt32(Request.QueryString["RegId"]));
                cmd.Parameters.AddWithValue("@OTID", Convert.ToInt32(Request.QueryString["OTID"]));
                con.Open();

                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(dt);
                }

                con.Close();
                con.Dispose();
            }

            if (dt.Rows.Count > 0)
            {
                txtsurgen.Text = Convert.ToString(dt.Rows[0]["SurganName"]);
                txtAnaesthetist.Text = Convert.ToString(dt.Rows[0]["ANAESTHETISTName"]);
                txt1stAsst.Text = Convert.ToString(dt.Rows[0]["FirstAssistantName"]);

                txt2stAsst.Text = Convert.ToString(dt.Rows[0]["SecondAssistantName"]);
                txtSTERINURSE.Text = Convert.ToString(dt.Rows[0]["SteriNurseName"]);
                txtDISEASE.Text = Convert.ToString(dt.Rows[0]["DiseaseName"]);
                txtoperation.Text = Convert.ToString(dt.Rows[0]["OperationName"]);
                txtremark.Text = Convert.ToString(dt.Rows[0]["Remark"]);
                txttimestart.Text = Convert.ToString(dt.Rows[0]["OperationStartTime"]);
                txttimeEnd.Text = Convert.ToString(dt.Rows[0]["OperationEndTime"]);

                txttimestart.Text = Convert.ToString(dt.Rows[0]["OperationStartDate"]);
                txtDateEnd.Text = Convert.ToString(dt.Rows[0]["OperationEndDate"]);

                txtTTime.Text = Convert.ToString(dt.Rows[0]["AnisticTime"]);

                   ViewState["SurganID"]=Convert.ToString(dt.Rows[0]["Surgan"]);
                    ViewState["Ansstia"]=Convert.ToString(dt.Rows[0]["ANAESTHETIST"]);
                    ViewState["1AssistID"]=Convert.ToString(dt.Rows[0]["FirstAssistant"]);
                    ViewState["2AssistID"] = Convert.ToString(dt.Rows[0]["SecondAssistant"]);
                    ViewState["STERINURSE"] = Convert.ToString(dt.Rows[0]["SteriNurse"]);
                    ViewState["DISEASE"] = Convert.ToString(dt.Rows[0]["Disease"]);
                    ViewState["Operation"] = Convert.ToString(dt.Rows[0]["Operation"]);

            }
        

    }
    }
    public void FillGrid(int PatRegId, int FID, int BillNo, int IpdNo)
    {
        DALOpdReg objDALOpdPatReg = new DALOpdReg();
        gvBillTransaction.DataSource = objDALOpdPatReg.FillIPDBilltransactions(PatRegId, FID, BillNo, IpdNo);
        gvBillTransaction.DataBind();
    }
    public void GetBillDetails()
    {
        objBELOpdReg = objDALOpdReg.GetIPDBillMasterDetails(Convert.ToInt32(Request.QueryString["RegId"]), Convert.ToInt32(Request.QueryString["IpdId"]), Convert.ToInt32(Session["FId"]), Convert.ToInt32(Session["Branchid"]));

        lblBillServiceCharges.Text = Convert.ToString(objBELOpdReg.BillServiceCharges);
        txtTotalAmt.Text = Convert.ToString(objBELOpdReg.BillServiceCharges);
        txtAmount.Text = Convert.ToString(objBELOpdReg.BillServiceCharges);
        lblAdvanceAmt.Text = Convert.ToString(objBELOpdReg.AdvanceAmt);
        lblInsurance.Text = Convert.ToString(objBELOpdReg.InsuranceAmount);
        txtAwardAmt.Text = Convert.ToString(objBELOpdReg.InsuranceAmount);
        lblDiscAmt.Text = Convert.ToString(objBELOpdReg.DiscountAmt);
        txtdiscgiven.Text = Convert.ToString(objBELOpdReg.DiscountAmt);
        txtAmountReceived.Text = Convert.ToString(objBELOpdReg.AdvanceAmt);
       // txtPaid.Text = Convert.ToString(Convert.ToSingle(lblBillServiceCharges.Text) - (Convert.ToSingle(txtAmountReceived.Text) + Convert.ToSingle(lblDiscAmt.Text)));
        txtbalance.Text = Convert.ToString(Convert.ToSingle(lblBillServiceCharges.Text) - (Convert.ToSingle(txtAmountReceived.Text) + Convert.ToSingle(lblDiscAmt.Text) +  Convert.ToSingle(txtAwardAmt.Text )));
        txtPaid.Text="0"; // txtAmount
        if (objBELOpdReg.IsDischarge == true)
        {
            chkFinalDischarge.Checked = true;
            chkFinalDischarge.Enabled = false;
            btnDisk.Enabled = false;
            chkDeposite.Enabled = false;
        }

    }
    public void GetDepositAmount()
    {
        decimal DepositAmt = objDALOpdReg.GetDepositAmount(Convert.ToInt32(Request.QueryString["RegId"]), Convert.ToInt32(Session["FId"]), Convert.ToInt32(Session["BranchId"]));
        ViewState["DepositAmt"] = DepositAmt;
        lblDepositAmt.Text = "(Deposit Amount=" + Convert.ToString(DepositAmt) + ")";

    }
    protected void FillRoomTypeDrop()
    {
        ddlRoomTypeName.DataSource = objDALRoom.FillRoomTypeCombo();
        ddlRoomTypeName.DataTextField = "RType";
        ddlRoomTypeName.DataValueField = "RTypeId";
        ddlRoomTypeName.DataBind();
    }
    public void LoadBillServices(string ServiceType)
    {
        if (ServiceType != "All")
        {
            //ddlBillServices.DataSource = ObjDALIpd.FillBillServices(ServiceType);
            //ddlBillServices.DataTextField = "ServiceName";
            //ddlBillServices.DataValueField = "BillServiceId";
            //ddlBillServices.DataBind();
        }
    }
    private void MakeBillTable()
    {
        DataTable dt = new DataTable();
        dt.Clear();


        dt.Columns.Add("EmpName");
       // dt.Columns.Add("BillGroup");
        dt.Columns.Add("Service");
        dt.Columns.Add("Description");
        dt.Columns.Add("Qty");
        dt.Columns.Add("TotalCharges");
        dt.Columns.Add("BillServiceCharges");
        dt.Columns.Add("BillId");
        dt.Columns.Add("DrId");
       // dt.Columns.Add("BillGroupId");
        dt.Columns.Add("BillServiceId");
        dt.Columns.Add("IpdBillServiceDetailId");
        dt.Columns.Add("DeptId");
        ViewState["BillTable"] = dt;
    }
    private void LoadRdbPaymentType()
    {

        RdbPayment.DataSource = objDALBillInfo.FillModeOfPayment();
        RdbPayment.DataValueField = "ModeOfPaymentId";
        RdbPayment.DataTextField = "ModeOfPaymentName";
        RdbPayment.DataBind();


    }   
   
    public void FillIpdPatInfo(int RegId,int IpdId)
    {
        objBELIpd.IpdId = IpdId;
        objBELIpd.PatRegId = RegId;
        objBELIpd.FId = Convert.ToInt32(Session["FId"]);
        objBELIpd.BranchId = Convert.ToInt32(Session["Branchid"]);
        objBELIpd = ObjDALIpd.GetIpdPatientInformation(objBELIpd);
        lblPatCat.Text = Convert.ToString(objBELIpd.PatMainType);
        lblPatientName.Text = Convert.ToString(objBELIpd.PatientName);
        lblAdmissionDate.Text = Convert.ToString(objBELIpd.EntryDate);
        lblIpd.Text = Convert.ToString(objBELIpd.IpdNo);
        lblPatRegId.Text = Convert.ToString(objBELIpd.PatRegId);
        lblBillNo.Text = Convert.ToString(objBELIpd.IpdNo);

        lblRoomName.Text = Convert.ToString(objBELIpd.RoomName);
        lbldrname.Text = Convert.ToString(objBELIpd.DRName);
        LblRoomType.Text = Convert.ToString(objBELIpd.RType);
        lblBedName.Text = Convert.ToString(objBELIpd.BedName);

        Label2.Text = Convert.ToString(objBELIpd.Diagnosis);
        Label4.Text = Convert.ToString(objBELIpd.ProcedureName);
        Label6.Text = Convert.ToString(objBELIpd.PatientInsuType);
        Label8.Text = Convert.ToString(objBELIpd.Sponsor2);
        lblvisitno.Text = Convert.ToString(objBELIpd.VisitingNo);
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {

        objBELBillDetail.BranchId = Convert.ToInt32(Session["Branchid"]);

        objBELBillDetail.PatRegId = Convert.ToInt32(lblPatRegId.Text);
        objBELBillDetail.IpdNo = Convert.ToInt32(lblIpd.Text);
        objBELBillDetail.BillNo = Convert.ToInt32(lblIpd.Text);
        objBELBillDetail.CreatedBy = Convert.ToString(Session["username"]);

        Message = objDALBillDetail.UpdateBillFinalDischarge(objBELBillDetail);
        lblvalidate.Text = "Final Discharge successfully.!";

    }
    // private void InsertRecortToAll()
    //{
    //    if (gvBill.Rows.Count <= 0)
    //    {


    //        txtCharges.Text = "";
    //    }
    //      object[] returns;
    //      string Message = "";
    //        objBELOpdReg = new BELOPDPatReg();
    //        //if (Request.QueryString["Flag"] == "AddBill")
    //        //{
    //        //    ViewState["OpdNo"] = Convert.ToInt32(Request.QueryString["OpdNo"]);
    //        //   // lblVisitingNo.Text = Convert.ToString(returns[1]);
    //        //    InsertInBill();
    //        //    InsertInBillDetail();
    //        //}
    //        //else
    //        //{
    //            InsertInBill();
    //            InsertInBillDetail();
    //       // }
    //       // Message = Convert.ToString(returns[0]);

    //    //DynamicMessage(lblMessage, Message);
    //}
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
        objBELBillInfo.PatRegId = Convert.ToInt32(lblPatRegId.Text);
        objBELBillInfo.BillDate = System.DateTime.Now;
        objBELBillInfo.IpdId = Convert.ToInt32(Request.QueryString["IpdId"]);
        objBELBillInfo.IpdNo =Convert.ToInt32(lblIpd.Text);
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
        if (PaymentInsurance.Checked == true)
        {
            objBELBillInfo.IsInsuranceFlag = true;
        }
        else
            objBELBillInfo.IsInsuranceFlag = false;
        if (ddlInsuranceCompName.SelectedValue != "")
        {
            objBELBillInfo.InsuranceCompId = Convert.ToInt32(ddlInsuranceCompName.SelectedValue);
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

        returns = objDALBillInfo.InsertIPDBillTransaction(objBELBillInfo);
        ViewState["BillPaymentId"] = Convert.ToInt32(returns[0]);

    }

    private void InsertInBillDetail()
    {

        
        //DataTable dt = (DataTable)ViewState["BillTable"];
        //for (int i = 0; i < dt.Rows.Count; i++)
        //{
            objBELBillDetail = new BELBillDetails();
            objBELBillDetail.IpdId = Convert.ToInt32(Request.QueryString["IpdId"]);
            objBELBillDetail.PatRegId = Convert.ToInt32(lblPatRegId.Text);
            objBELBillDetail.IpdNo = Convert.ToInt32(lblIpd.Text);
            objBELBillDetail.BillNo = Convert.ToInt32(lblIpd.Text);


            //if (txtsurgen.Text != "")
            //{
            //    objBELBillDetail.Surgan = Convert.ToInt32( ViewState["SurganID"]);
            //}
            //else
            //{
            //    objBELBillDetail.Surgan = 0;
            //}
            //if (txtAnaesthetist.Text != "")
            //{
            //    objBELBillDetail.ANAESTHETIST = Convert.ToInt32(ViewState["Ansstia"] );
            //}
            //else
            //{
            //    objBELBillDetail.ANAESTHETIST = 0;
            //}
            //if (txt1stAsst.Text != "")
            //{
            //    objBELBillDetail.FirstAssistant = Convert.ToInt32( ViewState["1AssistID"]);
            //}
            //else
            //{
            //    objBELBillDetail.FirstAssistant = 0;
            //}
            //if (txt2stAsst.Text != "")
            //{
            //    objBELBillDetail.SecondAssistant = Convert.ToInt32(ViewState["2AssistID"] );
            //}
            //else
            //{
            //    objBELBillDetail.SecondAssistant = 0;
            //}
            //if (txtSTERINURSE.Text != "")
            //{
            //    objBELBillDetail.SteriNurse = Convert.ToInt32(ViewState["STERINURSE"]);
            //}
            //else
            //{
            //    objBELBillDetail.SteriNurse = 0;
            //}
            //if (txtDISEASE.Text != "")
            //{
            //    objBELBillDetail.Disease = Convert.ToInt32(ViewState["DISEASE"]);
            //}
            //else
            //{
            //    objBELBillDetail.Disease = 0;
            //}
            //if (txtoperation.Text != "")
            //{
            //    objBELBillDetail.Operation = Convert.ToInt32(ViewState["Operation"] );
            //}
            //else
            //{
            //    objBELBillDetail.Operation = 0;
            //}
            //if (txttimestart.Text != "")
            //{
            //    objBELBillDetail.OperationEndTime = txttimestart.Text + " " + txtTime.Text;
            //}
            //else
            //{
            //    objBELBillDetail.OperationStartTime = "";
            //}
            //if (txtDateEnd.Text != "")
            //{
            //    objBELBillDetail.OperationEndTime = txtDateEnd.Text + " " + txttimeEnd.Text;
            //}
            //else
            //{
            //    objBELBillDetail.OperationEndTime = "";
            //}
            //if (txtTTime.Text != "")
            //{
            //    objBELBillDetail.AnisticTime = txtTTime.Text;
            //}
            //else
            //{
            //    objBELBillDetail.AnisticTime = "";
            //}
            //if (txtremark.Text != "")
            //{
            //    objBELBillDetail.Remark = txtremark.Text;
            //}
            if (txtQty.Text != "")
                objBELBillDetail.Qty = Convert.ToDecimal(txtQty.Text);
            else
                objBELBillDetail.Qty = 0;
            if (txtCharges.Text != "")
                objBELBillDetail.Charges = Convert.ToDecimal(txtCharges.Text);
            else
                objBELBillDetail.Charges = 0;
            if (txtTotalCharges.Text != "")
                objBELBillDetail.TotalCharges = Convert.ToDecimal(txtTotalCharges.Text);
            else
                objBELBillDetail.TotalCharges = 0;
            if (txtdescription.Value != "")
            {
                objBELBillDetail.Description = txtdescription.Value;
            }
            else
            {
                objBELBillDetail.Description = "";
            }
            
            
               // objBELBillDetail.BillServiceId = Convert.ToInt32(ddlBillServices.SelectedValue);
             if (txtBillServices.Text == "")
                {
                    objBELBillDetail.BillServiceId = 0;
                }
                else
                {
                    objBELBillDetail.BillServiceId = Convert.ToInt32(ViewState["ServiceID"]);
                }
       
                //if (ddlConsDoctorName.SelectedValue == "")
                //{
                //    objBELBillDetail.EmployeeId = 0;
                //}
                //else
                //{
                //    objBELBillDetail.EmployeeId = Convert.ToInt32(ddlConsDoctorName.SelectedValue);
                //}
                if (txtConsDoctorName.Text == "")
                {
                    objBELBillDetail.EmployeeId = 0;
                }
                else
                {
                    objBELBillDetail.EmployeeId = Convert.ToInt32(ViewState["ConsultID"]);
                }
          
                objBELBillDetail.CreatedBy =Convert.ToString(Session["username"]);
            objBELBillDetail.BranchId=Convert.ToInt32(Session["Branchid"]);
            objBELBillDetail.FId=Convert.ToInt32(Session["FId"]);
            objBELBillDetail.BillTypeName=RdbServicesFlag.SelectedValue;
          
            Message = objDALBillDetail.InsertIPDBillDetailOT(objBELBillDetail);

                DynamicMessage(lblMessage, Message);
                BindBillDetails();
           
       // }
    }

    public void BindBillDetails()
    {
        int RegId = Convert.ToInt32(Request.QueryString["RegId"]);
        int IpdId = Convert.ToInt32(Request.QueryString["IpdId"]);
        objBELBillDetail.IpdId = IpdId;
        objBELBillDetail.PatRegId = RegId;
        objBELBillDetail.IpdNo = Convert.ToInt32(lblIpd.Text);
        objBELBillDetail.BranchId = Convert.ToInt32(Session["Branchid"]);
        objBELBillDetail.FId = Convert.ToInt32(Session["FId"]);
        objBELBillDetail.BillTypeName = Convert.ToString(RdbServicesFlag.SelectedValue);
        gvBill.DataSource = objDALBillDetail.FillGridIpdBillDetail_OT(objBELBillDetail);
        gvBill.DataBind();

    }

    protected void btnReset_Click(object sender, EventArgs e)
    {

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if( txtBillServices.Text.Trim() != "")
        {
        if(Convert.ToInt32(ViewState["IpdBillServiceDetailId"]) >0)
        {
            if(txtQty.Text !="")
            objBELBillDetail.Qty = Convert.ToDecimal(txtQty.Text);
            else
                objBELBillDetail.Qty=0;
            if(txtCharges.Text !="")
                objBELBillDetail.Charges=Convert.ToDecimal(txtCharges.Text);
            else
                objBELBillDetail.Charges=0;
            if (txtTotalCharges.Text != "")
                objBELBillDetail.TotalCharges = Convert.ToDecimal(txtTotalCharges.Text);
            else
                objBELBillDetail.TotalCharges = 0;
            if (txtdescription.Value != "")
            {
                objBELBillDetail.Description = txtdescription.Value;
            }
            else
            {
                objBELBillDetail.Description = "";
            }
            objBELBillDetail.IpdBillServiceDetailId = Convert.ToInt32(ViewState["IpdBillServiceDetailId"]);
            objBELBillDetail.UpdatedBy = Convert.ToString(Session["username"]);
            objBELBillDetail.IpdId = Convert.ToInt32(Request.QueryString["IpdId"]);
            objBELBillDetail.PatRegId = Convert.ToInt32(lblPatRegId.Text);
            objBELBillDetail.IpdNo = Convert.ToInt32(lblIpd.Text);
            objBELBillDetail.BillNo = Convert.ToInt32(lblIpd.Text);
            objBELBillDetail.BranchId = Convert.ToInt32(Session["Branchid"]);
            objBELBillDetail.FId = Convert.ToInt32(Session["FId"]);

            Message = objDALBillDetail.UpdateBillDetail(objBELBillDetail);
            DynamicMessage(lblMessage, Message);
            BindBillDetails();
            ViewState["IpdBillServiceDetailId"] = "0";
        }
        
        else
        {     
            // AddToGridView();
             InsertInBillDetail();
             btnAdd.Enabled = false;
             
        }
    }
        GetBillDetails();
        Clear();
    }
    public void Clear()
    {
        ddlBillServices.SelectedValue = "0";
        ddlConsDoctorName.SelectedValue = "0";
        txtConsDoctorName.Text = "";
        txtdescription.Value = "";
        txtCharges.Text = "0";
        txtTotalCharges.Text = "0";
        txtQty.Text = "0";
        txtBillServices.Text = "";
    }
    private void LoadConsultantDoc()
    {

        ddlConsDoctorName.DataSource = objDALOpdReg.FillConsultantDocName();
        ddlConsDoctorName.DataValueField = "DrId";
        ddlConsDoctorName.DataTextField = "EmpName";
        ddlConsDoctorName.DataBind();
    }
    
    protected void ddlConsDoctorName_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void gvBill_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvBill.PageIndex = e.NewPageIndex;
      

    }
    protected void gvBill_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void gvBill_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Billtotal += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TotalCharges"));
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
        if (txtPaid.Text == "0")
        {
            txtPaid.Text = Convert.ToString(ViewState["Total"]);
            
        }
        //txtAmount.Text = Convert.ToString(ViewState["Total"]);
        txtDiscount.Text = "0";
        txtPaid.Text = "0";
       // txtbalance.Text = "0";


    }
    protected void gvBill_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string Message = "";
        string ID = (gvBill.DataKeys[e.RowIndex]["IpdBillServiceDetailId"].ToString());

        objBELBillDetail.IpdBillServiceDetailId = Convert.ToInt32(ID);
        objBELBillDetail.CreatedBy = Convert.ToString(Session["username"]);
        objBELBillDetail.BranchId = Convert.ToInt32(Session["Branchid"]);
        objBELBillDetail.FId = Convert.ToInt32(Session["FId"]);
        objBELBillDetail.BillTypeName = RdbServicesFlag.SelectedValue;

        objBELBillDetail.UpdatedBy = Convert.ToString(Session["username"]);
        objBELBillDetail.IpdId = Convert.ToInt32(Request.QueryString["IpdId"]);
        objBELBillDetail.PatRegId = Convert.ToInt32(lblPatRegId.Text);
        objBELBillDetail.IpdNo = Convert.ToInt32(lblIpd.Text);
        objBELBillDetail.BillNo = Convert.ToInt32(lblIpd.Text);


        Message = objDALBillDetail.DeleteIPDBillDetail(Convert.ToInt32(ID), objBELBillDetail);

        DynamicMessage(lblMessage, Message);
        BindBillDetails();
        GetBillDetails();

       
       
       
    }
    protected void PaymentInsurance_CheckedChanged(object sender, EventArgs e)
    {
        if (PaymentInsurance.Checked == true)
        {


            InsuranceDetails.Visible = false;
            txtDiscount.Enabled = false;
            txtbalance.Text = txtAmount.Text;
            ddlDiscountGivenBy.Enabled = false;
            txtPaid.Enabled = false;
            txtPaid.Text = Convert.ToString(Convert.ToDecimal(txtAmount.Text) - Convert.ToDecimal(txtbalance.Text));
            ddlDiscReason.Enabled = false;
           // btnSaveandBill.Enabled = false;

        }
        else
        {

            InsuranceDetails.Visible = false;
            txtPaid.Enabled = true;
            txtDiscount.Enabled = true;
            txtPaid.Text = txtAmount.Text;
            txtDiscount.Enabled = true;
            ddlDiscountGivenBy.Enabled = true;
            ddlDiscReason.Enabled = true;
            txtbalance.Text = Convert.ToString(Convert.ToDecimal(txtAmount.Text) - Convert.ToDecimal(txtPaid.Text));
           // btnSaveandBill.Enabled = true;
        }
    }
    protected void txtInsuranceAmt_TextChanged1(object sender, EventArgs e)
    {

    }
    protected void txtDiscount_TextChanged(object sender, EventArgs e)
    {
        if (rdbdiscAmt.Checked)
        {
            if (txtDiscount.Text != "")
            {
                txtAmount.Text = Convert.ToString(Convert.ToDouble(txtTotalAmt.Text) - (Convert.ToDouble(txtDiscount.Text) + Convert.ToDouble(txtdiscgiven.Text)));
                txtPaid.Text = Convert.ToString(Convert.ToDouble(txtAmount.Text) - Convert.ToDouble(txtAmountReceived.Text));
                txtbalance.Text = Convert.ToString(Convert.ToDouble(txtAmount.Text) - (Convert.ToDouble(txtPaid.Text) + Convert.ToDouble(txtAmountReceived.Text)));

                ViewState["DiscountPercent"] = (Convert.ToDouble(txtDiscount.Text) * 100) / Convert.ToDouble(txtTotalAmt.Text);
                ViewState["DiscountAmount"] = Convert.ToDouble(txtDiscount.Text);
            }
        }
        else
        {
            if (txtDiscount.Text != "")
            {
                txtAmount.Text = Convert.ToString(Convert.ToDouble(txtTotalAmt.Text) - ((Convert.ToDouble(txtTotalAmt.Text) * Convert.ToDouble(txtDiscount.Text)) / 100));
                txtAmount.Text = Convert.ToString(Convert.ToDouble(txtAmount.Text) - Convert.ToDouble(txtdiscgiven.Text));
               // txtPaid.Text = Convert.ToString(Convert.ToDouble(txtAmount.Text));
                txtPaid.Text = Convert.ToString(Convert.ToDouble(txtAmount.Text) - Convert.ToDouble(txtAmountReceived.Text));
                txtbalance.Text = Convert.ToString(Convert.ToDouble(txtAmount.Text) - (Convert.ToDouble(txtPaid.Text) + Convert.ToDouble(txtAmountReceived.Text)));

                ViewState["DiscountPercent"] = Convert.ToDouble(txtDiscount.Text);
                ViewState["DiscountAmount"] = ((Convert.ToDouble(txtTotalAmt.Text) * Convert.ToDouble(txtDiscount.Text)) / 100);
            }
        }
 
    }
    protected void rdblInsuranceAmt_SelectedIndexChanged(object sender, EventArgs e)
    {

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
    private void LoadDiscountGivenBy()
    {
        ddlDiscountGivenBy.DataSource = objDALBillInfo.FillDiscountGivenby();
        ddlDiscountGivenBy.DataValueField = "DrId";
        ddlDiscountGivenBy.DataTextField = "EmpName";
        ddlDiscountGivenBy.DataBind();
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
    protected void RdbServicesFlag_SelectedIndexChanged(object sender, EventArgs e)
    {
            Session["UID"] = RdbServicesFlag.SelectedValue;
            LoadBillServices(RdbServicesFlag.SelectedValue);
            BindBillDetails();
            if (RdbServicesFlag.SelectedValue == "Consultation")
            {
               // Doctor.Visible = true;
               // LoadConsultantDoc();
            }
            else
            {
                //Doctor.Visible = false;
            }
            LoadConsultantDoc();

    }
    protected void txtAmount_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txtQty_TextChanged(object sender, EventArgs e)
    {
        if (txtQty.Text != "")
        {
            txtTotalCharges.Text = Convert.ToString(Convert.ToDecimal(txtQty.Text) * Convert.ToDecimal(txtCharges.Text));
        }

    }
    protected void txtPaid_TextChanged(object sender, EventArgs e)
    {
        txtbalance.Text = Convert.ToString(Convert.ToDouble(txtAmount.Text) - Convert.ToDouble(txtPaid.Text));
    }
    protected void ddlRoomTypeName_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
    protected void ddlBillServices_SelectedIndexChanged(object sender, EventArgs e)
    {
        
            int IpdId=Convert.ToInt32(Request.QueryString["IpdId"]);
            int ServiceId=Convert.ToInt32(ddlBillServices.SelectedValue);
            
            txtCharges.Text = ObjDALIpd.GetIPDRoomcharges(Convert.ToInt32(lblPatRegId.Text), Convert.ToInt32(Session["FId"]), Convert.ToInt32(Session["Branchid"]),IpdId,ServiceId);
       

    }
    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchConsultDoc(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        return objDALOpdReg.FillAllConsultDoc(prefixText);
    }
    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchAllService(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
       // string Type =  RdbServicesFlag.SelectedValue;
      // HttpContext.Current.Session["UID"];
      string Type =Convert.ToString(  HttpContext.Current.Session["UID"]);
      return objDALOpdReg.FillAllCathoOTService(prefixText, Type);
    }

    protected void RdbServicesFlagNew_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["UID"] = RdbServicesFlagNew.SelectedValue;
        // LoadBillServices(RdbServicesFlag.SelectedValue);
      //  BindBillDetails();


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
        }
    }
    protected void gvBill_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            btnAdd.Enabled = true;
            string IpdBillServiceDetailId = (gvBill.DataKeys[e.NewEditIndex]["IpdBillServiceDetailId"].ToString());
            ViewState["IpdBillServiceDetailId"] = IpdBillServiceDetailId;
            FillPage();
            e.Cancel = true;
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void FillPage()
    {
        int i = Convert.ToInt32(ViewState["IpdBillServiceDetailId"]);

        objBELBillDetail = objDALBillDetail.SelectOne(Convert.ToInt32(ViewState["IpdBillServiceDetailId"]));
        ddlBillServices.SelectedValue = Convert.ToString(objBELBillDetail.BillServiceId);
        ddlConsDoctorName.SelectedValue = Convert.ToString(objBELBillDetail.EmployeeId);
        if (objBELBillDetail.EmployeeId != 0)
        {
            txtConsDoctorName.Text = Convert.ToString(objBELBillDetail.EmployeeName);
            ViewState["ConsultID"] = Convert.ToString(objBELBillDetail.EmployeeId);
        }
        else
        {
            ViewState["ConsultID"] = "0";
            txtConsDoctorName.Text = "";
        }
        if (objBELBillDetail.BillServiceId != 0)
        {
            txtBillServices.Text = Convert.ToString(objBELBillDetail.ServiceName);
            ViewState["ServiceID"] = Convert.ToString(objBELBillDetail.BillServiceId);
        }
        else
        {
            ViewState["ServiceID"] = "0";
            txtBillServices.Text = "";
        }
        txtdescription.Value = Convert.ToString(objBELBillDetail.Description);
        txtQty.Text = Convert.ToString(objBELBillDetail.Qty);
        txtCharges.Text = Convert.ToString(objBELBillDetail.Charges);
        txtTotalCharges.Text = Convert.ToString(objBELBillDetail.TotalCharges);
       
    }
    protected void chkFinalDischarge_CheckedChanged(object sender, EventArgs e)
    {
        if (chkFinalDischarge.Checked == true)
        {
           // RdbServicesFlag.SelectedValue = "0";
            RdbServicesFlag.SelectedIndex = 0;
            RdbServicesFlag_SelectedIndexChanged(null, null);
           // txtPaid.Enabled = true;
            if ( Convert.ToSingle(txtbalance.Text)>0)
            {
                if (ddlBalreason.SelectedIndex > 0)
                {
                    btnsave.Visible = true;
                }
                else
                {
                    lblvalidate.Text = "Pay paid amount!";
                }
                
            }
            else
            {
                if (Convert.ToSingle(txtbalance.Text) < 0)
                {
                    btnsave.Visible = false;
                    btnrefund.Visible = true;
                }
                else
                {
                    btnsave.Visible = true;
                    btnrefund.Visible = false;
                }
            }
        }
    }
    protected void btnDisk_Click(object sender, EventArgs e)
    {
        if (txtDiscount.Text != "")
        {
            decimal DisAmt = 0;
            if (rdbdiscAmt.Checked)
            {
                if (txtDiscount.Text != "")
                {
                    DisAmt =  Convert.ToDecimal(txtDiscount.Text);
                    
                }
            }
            else
            {
                if (txtDiscount.Text != "")
                {
                    DisAmt =  ((Convert.ToDecimal(txtTotalAmt.Text) * Convert.ToDecimal(txtDiscount.Text)) / 100);
                  
                }
            }
            if (DisAmt > Convert.ToDecimal(txtbalance.Text))
            {
                lblvalidate.Text = "Discount Amt not greater than paid amt.!";
                BindBillDetails();
                GetBillDetails(); ;
            }
            else
            {
         objBELBillDetail.BranchId = Convert.ToInt32(Session["Branchid"]);
       
        objBELBillDetail.PatRegId = Convert.ToInt32(lblPatRegId.Text);
        objBELBillDetail.IpdNo = Convert.ToInt32(lblIpd.Text);
        objBELBillDetail.BillNo = Convert.ToInt32(lblIpd.Text);

        objBELBillDetail.TotalCharges = DisAmt;
        objBELBillDetail.ReasonforDiscount = ddlDiscReason.SelectedItem.Text;

        objBELBillDetail.DiscountGivenBy = Convert.ToString(Session["username"]); ;
        Message = objDALBillDetail.UpdateBillDuscountDetail(objBELBillDetail);

       // DynamicMessage(lblMessage, Message);
        BindBillDetails();
        GetBillDetails();

                 
                lblvalidate.Text = "Discount Amt save successfully.!";
            }
        }
    }
    protected void btnrefund_Click(object sender, EventArgs e)
    {
        objBELBillDetail.PatRegId = Convert.ToInt32(lblPatRegId.Text);
        objBELBillDetail.IpdNo = Convert.ToInt32(lblIpd.Text);
        string response = @"~/IpdRefundPayment.aspx?RegId=" + Convert.ToInt32(lblPatRegId.Text) + "&IpdId=" + Convert.ToInt32(lblIpd.Text);

        Response.Redirect(string.Format(response));
    }
    protected void txtBillServices_TextChanged(object sender, EventArgs e)
    {
        if (txtBillServices.Text != "")
        {
            btnAdd.Enabled = true;
            string[] PatientInfo = txtBillServices.Text.Split('-');
            if (PatientInfo.Length > 1)
            {
                txtBillServices.Text = PatientInfo[1];
                ViewState["ServiceID"] = PatientInfo[0];
            }
            int IpdId = Convert.ToInt32(Request.QueryString["IpdId"]);
            int ServiceId = Convert.ToInt32(ViewState["ServiceID"]);

            txtCharges.Text = ObjDALIpd.GetIPDRoomcharges(Convert.ToInt32(lblPatRegId.Text), Convert.ToInt32(Session["FId"]), Convert.ToInt32(Session["Branchid"]), IpdId, ServiceId);
       
        }
    }
    protected void btnReport_Click(object sender, EventArgs e)
    {
        string sql = "";

        BLLReports objreports = new BLLReports();
        int IpdId = Convert.ToInt32(Request.QueryString["IpdId"]);
        int PatRegId = Convert.ToInt32(Request.QueryString["RegId"]);
        int BranchId = Convert.ToInt32(Session["Branchid"]);
        int FId = Convert.ToInt32(Session["FId"]);

        objreports.IpdBillDetails(IpdId, PatRegId, FId, BranchId);

        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Reports/Rpt_IpdBillDetails.rpt");
        Session["reportname"] = "IpdBillDetails_Report";
        Session["RPTFORMAT"] = "pdf";


        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);


    }
    protected void btnSummary_Click(object sender, EventArgs e)
    {
        string sql = "";

        BLLReports objreports = new BLLReports();
        int IpdId = Convert.ToInt32(Request.QueryString["IpdId"]);
        int PatRegId = Convert.ToInt32(Request.QueryString["RegId"]);
        int BranchId = Convert.ToInt32(Session["Branchid"]);
        int FId = Convert.ToInt32(Session["FId"]);

        objreports.IpdBillSummary(IpdId, PatRegId);

        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Reports/Rpt_IpdBillSummary.rpt");
        Session["reportname"] = "IpdBillSummary_Report";
        Session["RPTFORMAT"] = "pdf";


        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);


    }
    //=============================================================================

    [ScriptMethod()]
    [WebMethod]
    public static List<string> Searchsurgan(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        return objDALOpdReg.FillAllSurgan(prefixText);
    }
   
   
    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchAnaesthetist(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        return objDALOpdReg.FillAllAnaesthetist(prefixText);
    }
   
    [ScriptMethod()]
    [WebMethod]
    public static List<string> Search1stAsst(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        return objDALOpdReg.FillAll1Assists(prefixText);
    }
    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchDisease(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        string Type = "0";
        return objDALOpdReg.FillAllDisease(prefixText, Type);
    }
    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchOperaation(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        string Type = "0";
        return objDALOpdReg.FillAllOperation(prefixText, Type);
    }
    protected void txtsurgen_TextChanged(object sender, EventArgs e)
    {
        if (txtsurgen.Text != "")
        {
            string[] PatientInfo = txtsurgen.Text.Split('-');
            if (PatientInfo.Length > 1)
            {
                txtsurgen.Text = PatientInfo[1];
                ViewState["SurganID"] = PatientInfo[0];
            }
            else
            {
                ViewState["SurganID"] = "0";
            }
        }
        else
        {
            ViewState["SurganID"] = "0";
        }
    }
    protected void txtAnaesthetist_TextChanged(object sender, EventArgs e)
    {
        if (txtAnaesthetist.Text != "")
        {
            string[] PatientInfo = txtAnaesthetist.Text.Split('-');
            if (PatientInfo.Length == 2)
            {
                txtAnaesthetist.Text = PatientInfo[1];
                ViewState["Ansstia"] = PatientInfo[0];
            }
        }
    }
    protected void txt1stAsst_TextChanged(object sender, EventArgs e)
    {
        if (txt1stAsst.Text != "")
        {
            string[] PatientInfo = txt1stAsst.Text.Split('-');
            if (PatientInfo.Length == 2)
            {
                txt1stAsst.Text = PatientInfo[1];
                ViewState["1AssistID"] = PatientInfo[0];
            }
        }
    }
    protected void txt2stAsst_TextChanged(object sender, EventArgs e)
    {
        if (txt2stAsst.Text != "")
        {
            string[] PatientInfo = txt2stAsst.Text.Split('-');
            if (PatientInfo.Length == 2)
            {
                txt2stAsst.Text = PatientInfo[1];
                ViewState["2AssistID"] = PatientInfo[0];
            }
        }
    }
    protected void txtSTERINURSE_TextChanged(object sender, EventArgs e)
    {
        if (txtSTERINURSE.Text != "")
        {
            string[] PatientInfo = txtSTERINURSE.Text.Split('-');
            if (PatientInfo.Length == 2)
            {
                txtSTERINURSE.Text = PatientInfo[1];
                ViewState["STERINURSE"] = PatientInfo[0];
            }
        }
    }
    protected void txtDISEASE_TextChanged(object sender, EventArgs e)
    {
        if (txtDISEASE.Text != "")
        {
            string[] PatientInfo = txtDISEASE.Text.Split('-');
            if (PatientInfo.Length == 2)
            {
                txtDISEASE.Text = PatientInfo[1];
                ViewState["DISEASE"] = PatientInfo[0];
            }
        }
    }
    protected void txtoperation_TextChanged(object sender, EventArgs e)
    {
        if (txtoperation.Text != "")
        {
            string[] PatientInfo = txtoperation.Text.Split('-');
            if (PatientInfo.Length == 2)
            {
                txtoperation.Text = PatientInfo[1];
                ViewState["Operation"] = PatientInfo[0];
            }
        }
    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        objBELBillDetail = new BELBillDetails();
        objBELBillDetail.IpdId = Convert.ToInt32(Request.QueryString["IpdId"]);
        objBELBillDetail.PatRegId = Convert.ToInt32(lblPatRegId.Text);
        objBELBillDetail.IpdNo = Convert.ToInt32(lblIpd.Text);
        objBELBillDetail.BillNo = Convert.ToInt32(lblIpd.Text);


        if (txtsurgen.Text != "")
        {
            objBELBillDetail.Surgan = Convert.ToInt32(ViewState["SurganID"]);
        }
        else
        {
            objBELBillDetail.Surgan = 0;
        }
        if (txtAnaesthetist.Text != "")
        {
            objBELBillDetail.ANAESTHETIST = Convert.ToInt32(ViewState["Ansstia"]);
        }
        else
        {
            objBELBillDetail.ANAESTHETIST = 0;
        }
        if (txt1stAsst.Text != "")
        {
            objBELBillDetail.FirstAssistant = Convert.ToInt32(ViewState["1AssistID"]);
        }
        else
        {
            objBELBillDetail.FirstAssistant = 0;
        }
        if (txt2stAsst.Text != "")
        {
            objBELBillDetail.SecondAssistant = txt2stAsst.Text;
        }
        else
        {
            objBELBillDetail.SecondAssistant = "";
        }
        if (txtSTERINURSE.Text != "")
        {
            objBELBillDetail.SteriNurse = Convert.ToInt32(ViewState["STERINURSE"]);
        }
        else
        {
            objBELBillDetail.SteriNurse = 0;
        }
        if (txtDISEASE.Text != "")
        {
            objBELBillDetail.Disease = Convert.ToInt32(ViewState["DISEASE"]);
        }
        else
        {
            objBELBillDetail.Disease = 0;
        }
        if (txtoperation.Text != "")
        {
            objBELBillDetail.Operation = Convert.ToInt32(ViewState["Operation"]);
        }
        else
        {
            objBELBillDetail.Operation = 0;
        }
        if (txttimestart.Text != "")
        {
            objBELBillDetail.OperationStartDate = txttimestart.Text;
        }
        else
        {
            objBELBillDetail.OperationStartTime = "";
        }
        if (txtTime.Text != "")
        {
            objBELBillDetail.OperationStartTime = txtTime.Text;
        }

        if (txtDateEnd.Text != "")
        {
            objBELBillDetail.OperationEndDate = txtDateEnd.Text;
        }
        else
        {
            objBELBillDetail.OperationEndDate = "";
        }
        if (txttimeEnd.Text != "")
        {
            objBELBillDetail.OperationEndTime =  txttimeEnd.Text;
        }
        
        if (txtTTime.Text != "")
        {
            objBELBillDetail.AnisticTime = txtTTime.Text;
        }
        else
        {
            objBELBillDetail.AnisticTime = "";
        }
        if (txtremark.Text != "")
        {
            objBELBillDetail.Remark = txtremark.Text;
        }
        objBELBillDetail.CreatedBy = Convert.ToString(Session["username"]);
        objBELBillDetail.BranchId = Convert.ToInt32(Session["Branchid"]);

        objBELBillDetail.FId = Convert.ToInt32(Session["FId"]);
        objBELBillDetail.OperationName = Convert.ToString(txtoperation.Text.Trim());
        objBELBillDetail.DiseaseName = Convert.ToString(txtDISEASE.Text.Trim());
        objBELBillDetail.GeneralOT = Convert.ToInt32(0);
        
        Message = objDALBillDetail.Insert_OTRegister(objBELBillDetail);
        lblMessage.Text = "OT Register save Successfully..";
    }
    protected void txttimeEnd_TextChanged(object sender, EventArgs e)
    {
        if (txttimeEnd.Text != "")
        {
            string STDate = txttimestart.Text + " " + txtTime.Text;
         DateTime Startdate   = Convert.ToDateTime(STDate);
         string ETDate = txtDateEnd.Text + " " + txttimeEnd.Text;
         DateTime Enddate = Convert.ToDateTime(ETDate);
         TimeSpan ts = Enddate.Subtract(Startdate);
         //if (ts.Hours != 0)
         //{
         //    txtTTime.Text = Convert.ToString(ts.Hours) + " Hours" + Convert.ToString(ts.Minutes) + " Minutes"; ;
         //}
         //else
         //{
         //    txtTTime.Text = Convert.ToString(ts.Minutes)+" Minutes";
         //}
         txtTTime.Text = Convert.ToString(ts.Hours) + " Hours" + Convert.ToString(ts.Minutes) + " Minutes"; 
        }
    }
}