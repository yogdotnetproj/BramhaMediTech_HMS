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


public partial class OTGeneralRegisterAdd : BaseClass
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
            ViewState["Register"] = "";
            if (Request.QueryString["RegId"] != "" && Request.QueryString["IpdId"] != "")
            {

                DateTime time = DateTime.Now;
                txttimestart.Text = DateTime.Now.ToString("dd/MM/yyyy");
                String s = time.ToString("hh:mm");
                txtTime.Text = s;

               
                txtDateEnd.Text = DateTime.Now.ToString("dd/MM/yyyy");
                String ET = time.ToString("hh:mm");
                txttimeEnd.Text = ET;

                DateTime time1 = DateTime.Now;
                txtOtRegDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                String s1 = time1.ToString("hh:mm");
                txtOtRegTime.Text = s1;


                txtOtRegDate1.Text = DateTime.Now.ToString("dd/MM/yyyy");
                String ET1 = time1.ToString("hh:mm");
                txtOtRegTimeFrom.Text = ET1;

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
            FillASA();
            LoadBillServices(RdbServicesFlag.SelectedValue);
            RdbServicesFlag_SelectedIndexChanged(null, null);
            InsuranceDetails.Visible = false;
            LoadRdbPaymentType();
            RdbPayment.SelectedValue = "1";
            rdbdiscAmt.Checked = true;
            PaymentDetails.Visible = false;
            MakeBillTable();
        }

    }
    protected void FillASA()
    {


        ddlASA.DataSource = ObjDALIpd.FillASA();
        ddlASA.DataValueField = "ASAId";
        ddlASA.DataTextField = "ASA";
        ddlASA.DataBind();

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

                txt2stAsst.Text = Convert.ToString(dt.Rows[0]["SecondAssistant"]);
                txtSTERINURSE.Text = Convert.ToString(dt.Rows[0]["SteriNurseName"]);
                txtDISEASE.Text = Convert.ToString(dt.Rows[0]["DiseaseName"]);
                txtoperation.Text = Convert.ToString(dt.Rows[0]["OperationName"]);
                txtremark.Text = Convert.ToString(dt.Rows[0]["Remark"]);
                txtTime.Text = Convert.ToString(dt.Rows[0]["OperationStartTime"]);
                txttimeEnd.Text = Convert.ToString(dt.Rows[0]["OperationEndTime"]);

                txttimestart.Text = Convert.ToString(dt.Rows[0]["OperationStartDate"]);
                txtDateEnd.Text = Convert.ToString(dt.Rows[0]["OperationEndDate"]);

                txtTTime.Text = Convert.ToString(dt.Rows[0]["AnisticTime"]);

                txtInstrumentSecoundNurse.Text = Convert.ToString(dt.Rows[0]["InstrumentCountNurseName2"]);
                txtInstrumentFirstNurse.Text = Convert.ToString(dt.Rows[0]["InstrumentCountNurseName"]);
                txtswabSecountNurse.Text = Convert.ToString(dt.Rows[0]["SwabCountNurseName2"]);
                txtswabFirstNurse.Text = Convert.ToString(dt.Rows[0]["SwabCountNurseName"]);
                txttrollyNurse.Text = Convert.ToString(dt.Rows[0]["TrollyNurseName"]);
                ddlASA.SelectedValue = Convert.ToString(dt.Rows[0]["ASA"]);
                DdlClass.SelectedValue = Convert.ToString(dt.Rows[0]["OTClass"]);
                   ViewState["SurganID"]=Convert.ToString(dt.Rows[0]["Surgan"]);
                    ViewState["Ansstia"]=Convert.ToString(dt.Rows[0]["ANAESTHETIST"]);
                    ViewState["1AssistID"]=Convert.ToString(dt.Rows[0]["FirstAssistant"]);
                   // ViewState["2AssistID"] = Convert.ToString(dt.Rows[0]["SecondAssistant"]);
                    ViewState["STERINURSE"] = Convert.ToString(dt.Rows[0]["SteriNurse"]);
                    ViewState["DISEASE"] = Convert.ToString(dt.Rows[0]["Disease"]);
                    ViewState["Operation"] = Convert.ToString(dt.Rows[0]["Operation"]);

                    ViewState["swabFirst"] = Convert.ToString(dt.Rows[0]["SwabCountNurse"]);
                    ViewState["swabSecound"] = Convert.ToString(dt.Rows[0]["SwabCountNurse2"]);
                    ViewState["InstruFirst"] = Convert.ToString(dt.Rows[0]["InstrumentCountNurse"]);
                    ViewState["InstruSeco"] = Convert.ToString(dt.Rows[0]["InstrumentCountNurse2"]);
                    ViewState["TrollyNurse"] = Convert.ToString(dt.Rows[0]["TrollyNurse"]);
                    ViewState["Register"] = "true";

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

        
        
        if (RdbServicesFlag.SelectedItem.Text == "Package")
        {
            objBELBillDetail = new BELBillDetails();
            DataTable dtpack = new DataTable();
            dtpack = objDALBillDetail.Fill_GetPackageServiceDetails(Convert.ToInt32(ViewState["ServiceID"]));
            if (dtpack.Rows.Count > 0)
            {
                for (int i = 0; i < dtpack.Rows.Count; i++)
                {
                    objBELBillDetail.IpdId = Convert.ToInt32(Request.QueryString["IpdId"]);
                    objBELBillDetail.PatRegId = Convert.ToInt32(lblPatRegId.Text);
                    objBELBillDetail.IpdNo = Convert.ToInt32(lblIpd.Text);
                    objBELBillDetail.BillNo = Convert.ToInt32(lblIpd.Text);
                    
                        if (txtBillServices.Text == "")
                        {
                            objBELBillDetail.BillServiceId = 0;
                        }
                        else
                        {
                            objBELBillDetail.BillServiceId = Convert.ToInt32(dtpack.Rows[i]["ServiceId"]);
                        }

                       // ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Select Service!!!');", true);
                       // return;

                   

                    if (txtQty.Text != "")
                        objBELBillDetail.Qty = Convert.ToDecimal(dtpack.Rows[i]["Qty"]);
                    else
                        objBELBillDetail.Qty = Convert.ToDecimal(dtpack.Rows[i]["Qty"]);
                    if (txtCharges.Text != "")
                        objBELBillDetail.Charges = Convert.ToDecimal(dtpack.Rows[i]["TestRate"]);
                    else
                        objBELBillDetail.Charges = Convert.ToDecimal(dtpack.Rows[i]["TestRate"]);
                    if (txtTotalCharges.Text != "")
                        objBELBillDetail.TotalCharges = (Convert.ToDecimal(dtpack.Rows[i]["Qty"]) * Convert.ToDecimal(dtpack.Rows[i]["TestRate"]));
                    else
                        objBELBillDetail.TotalCharges = (Convert.ToDecimal(dtpack.Rows[i]["Qty"]) * Convert.ToDecimal(dtpack.Rows[i]["TestRate"]));
                    if (txtdescription.Value != "")
                    {
                        objBELBillDetail.Description = txtdescription.Value;
                    }
                    else
                    {
                        objBELBillDetail.Description = "";
                    }


                   
                    if (txtConsDoctorName.Text == "")
                    {
                        objBELBillDetail.EmployeeId = 0;
                    }
                    else
                    {
                        objBELBillDetail.EmployeeId = Convert.ToInt32(ViewState["ConsultID"]);
                    }

                    objBELBillDetail.CreatedBy = Convert.ToString(Session["username"]);
                    objBELBillDetail.BranchId = Convert.ToInt32(Session["Branchid"]);
                    objBELBillDetail.FId = Convert.ToInt32(Session["FId"]);
                    objBELBillDetail.BillTypeName = RdbServicesFlag.SelectedValue;

                    Message = objDALBillDetail.InsertIPDBillDetailOT(objBELBillDetail);
                }
            }
        }
        else
        {
            objBELBillDetail = new BELBillDetails();
            objBELBillDetail.IpdId = Convert.ToInt32(Request.QueryString["IpdId"]);
            objBELBillDetail.PatRegId = Convert.ToInt32(lblPatRegId.Text);
            objBELBillDetail.IpdNo = Convert.ToInt32(lblIpd.Text);
            objBELBillDetail.BillNo = Convert.ToInt32(lblIpd.Text);
           
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

            
            if (txtConsDoctorName.Text == "")
            {
                objBELBillDetail.EmployeeId = 0;
            }
            else
            {
                objBELBillDetail.EmployeeId = Convert.ToInt32(ViewState["ConsultID"]);
            }

            objBELBillDetail.CreatedBy = Convert.ToString(Session["username"]);
            objBELBillDetail.BranchId = Convert.ToInt32(Session["Branchid"]);
            objBELBillDetail.FId = Convert.ToInt32(Session["FId"]);
            objBELBillDetail.BillTypeName = RdbServicesFlag.SelectedValue;

            Message = objDALBillDetail.InsertIPDBillDetailOT(objBELBillDetail);
        }

                DynamicMessage(lblMessage, Message);
                BindBillDetails();
           
       
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
       // objBELBillDetail.BillTypeName = Convert.ToString(RdbServicesFlag.SelectedValue);
        objBELBillDetail.BillTypeName = "All";
        gvBill.DataSource = objDALBillDetail.FillGridIpdBillDetail_OT(objBELBillDetail);
        gvBill.DataBind();

    }

    protected void btnReset_Click(object sender, EventArgs e)
    {

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (ViewState["Register"].ToString() == "true")
        {
            if (txtBillServices.Text.Trim() != "")
            {
                if (Convert.ToInt32(ViewState["IpdBillServiceDetailId"]) > 0)
                {
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
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Register OT Details!!!');", true);
            return;
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
           // LoadBillServices(RdbServicesFlag.SelectedValue);
           BindBillDetails();
            

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
      return objDALOpdReg.FillAllGeneralOTService(prefixText, Type);
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
    public static List<string> SearchAsst(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        return objDALOpdReg.FillAssistanceForOperation(prefixText);
    }
    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchDisease(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
       // string Type = Convert.ToString(HttpContext.Current.Session["UID"]);
        string Type = "1";

        return objDALOpdReg.FillAllDisease(prefixText,Type);
    }
    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchOperaation(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        string Type = "1";
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
                txtsurgen.BorderColor = Color.LightGray;
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

    public bool validationSurgeon()
    {
        bool flag =false;
        if (txtsurgen.Text == "")
        {
            if (ViewState["SurganID"].ToString() == "0")
            {
                txtsurgen.Focus();
                txtsurgen.BorderColor = Color.Red;
                ViewState["Msg"] = "Please Select Surgeon!!";
                flag=false;
            }
        }
        else
        {
            if (ViewState["SurganID"].ToString() == "0")
            {
                txtsurgen.Focus();
                txtsurgen.BorderColor = Color.Red;               
                ViewState["Msg"] = "Please Select Surgeon!!";
                flag = false;
            }
            else
            {
                txtsurgen.BorderColor = Color.LightGray;
                flag = true;
            }
        }
        return flag;
    }
    public bool Validation1stAss()
    {
        if (txt1stAsst.Text != "")
        {

            if (ViewState["1AssistID"].ToString() == "0")
            {
                txt1stAsst.Focus();
                txt1stAsst.BorderColor = Color.Red;
                ViewState["Msg"] = "Please Select Assistant!!";
                return false;
            }
            else
            {
                txt1stAsst.BorderColor = Color.LightGray;
                return true;
            }
        }
        else
        {
            txt1stAsst.BorderColor = Color.LightGray;
            ViewState["1AssistID"] = "0";
            return true;
        }
    }
    //public bool ValidationAssistance2()
    //{
    //    if (txt2stAsst.Text != "")
    //    {
    //        if (ViewState["2AssistID"].ToString() == "0")
    //        {
    //            txt2stAsst.Focus();
    //            txt2stAsst.BorderColor = Color.Red;
    //            ViewState["Msg"] = "Please Select Assistant!!";
    //            return false;
    //        }
    //        else
    //        {
    //            txt2stAsst.BackColor = Color.LightGray;
    //            return true;
    //        }
    //    }
    //    else
    //    {
    //        return true;
    //    }

       
    //}
    public bool ValidationAnaesthetist()
    {
        if (txtAnaesthetist.Text != "")
        {
            if (ViewState["Ansstia"].ToString() == "0")
            {
                txtAnaesthetist.Focus();
                txtAnaesthetist.BorderColor = Color.Red;
                ViewState["Msg"] = "Please Select Anaesthetist!!";
                return false;
            }
            else
            {
                txtAnaesthetist.BorderColor = Color.LightGray;
                return true;
            }
        }
        else
        {
            ViewState["Ansstia"] = "0";
            txtAnaesthetist.BorderColor = Color.LightGray;
            return true;
        }


    }
    public bool ValidationSTERINURSE()
    {
        if (txtSTERINURSE.Text != "")
        {
            if (ViewState["STERINURSE"].ToString() == "0")
            {
                txtSTERINURSE.Focus();
                txtSTERINURSE.BorderColor = Color.Red;
                ViewState["Msg"] = "Please Select Nurse!!";
                return false;
            }
            else
            {
                txtSTERINURSE.BorderColor = Color.LightGray;
                return true;
            }
        }
        else
        {
            txtSTERINURSE.BorderColor = Color.LightGray;
            ViewState["STERINURSE"] = "0";
            return true;
        }


    }
    public bool ValidationInstrumentFirstNurse()
    {
        if (txtInstrumentFirstNurse.Text != "")
        {
            if (ViewState["InstruFirst"].ToString() == "0")
            {
                txtInstrumentFirstNurse.Focus();
                txtInstrumentFirstNurse.BorderColor = Color.Red;
                ViewState["Msg"] = "Please Select Nurse!!";
                return false;
            }
            else
            {
                txtInstrumentFirstNurse.BorderColor = Color.LightGray;
                return true;
            }
        }
        else
        {
            txtInstrumentFirstNurse.BorderColor = Color.LightGray;
            ViewState["InstruFirst"] = "0";
            return true;
        }
    }
    public bool ValidationInstrumentSecoundNurse()
    {
        if (txtInstrumentSecoundNurse.Text != "")
        {
            if (ViewState["InstruSeco"].ToString() == "0")
            {
                txtInstrumentSecoundNurse.Focus();
                txtInstrumentSecoundNurse.BorderColor = Color.Red;
                ViewState["Msg"] = "Please Select Nurse!!";
                return false;
            }
            else
            {
                txtInstrumentSecoundNurse.BorderColor = Color.LightGray;
                return true;
            }
        }
        else
        {
            ViewState["InstruSeco"] = "0";
            txtInstrumentSecoundNurse.BorderColor = Color.LightGray;
            return true;
        }
    }
    public bool ValidationswabSecountNurse()
    {
        if (txtswabSecountNurse.Text != "")
        {
            if (ViewState["swabSecound"].ToString() == "0")
            {
                txtswabSecountNurse.Focus();
                txtswabSecountNurse.BorderColor = Color.Red;
                ViewState["Msg"] = "Please Select Nurse!!";
                return false;
            }
            else
            {
                txtswabSecountNurse.BorderColor = Color.LightGray;
                return true;
            }
        }
        else
        {
            txtswabSecountNurse.BorderColor = Color.LightGray;
            ViewState["swabSecound"] = "0";
            return true;
        }
    }
    public bool ValidationswabFirstNurse()
    {
        if (txtswabFirstNurse.Text != "")
        {
            if (ViewState["swabFirst"].ToString() == "0")
            {
                txtswabFirstNurse.Focus();
                txtswabFirstNurse.BorderColor = Color.Red;
                ViewState["Msg"] = "Please Select Nurse!!";
                return false;
            }
            else
            {
                txtswabFirstNurse.BorderColor = Color.LightGray;
                return true;
            }
        }
        else
        {
            txtswabFirstNurse.BorderColor = Color.LightGray;
            ViewState["swabFirst"] = "0";
            return true;
        }
    }
    public bool ValidationtrollyNurse()
    {
        if (txttrollyNurse.Text != "")
        {
            if (ViewState["TrollyNurse"].ToString() == "0")
            {
                txttrollyNurse.Focus();
                txttrollyNurse.BorderColor = Color.Red;
                ViewState["Msg"] = "Please Select Nurse!!";
                return false;
            }
            else
            {
                txttrollyNurse.BorderColor = Color.LightGray;
                return true;
            }
        }
        else
        {
            ViewState["TrollyNurse"]="0";
            txttrollyNurse.BorderColor = Color.LightGray;
            return true;
        }
    }

    protected void txtAnaesthetist_TextChanged(object sender, EventArgs e)
    {
        if (txtAnaesthetist.Text != "")
        {
            string[] PatientInfo = txtAnaesthetist.Text.Split('-');
            if (PatientInfo.Length > 1)
            {
                txtAnaesthetist.Text = PatientInfo[1];
                ViewState["Ansstia"] = PatientInfo[0];
                txtAnaesthetist.BorderColor = Color.LightGray;
            }
            else
            {
                ViewState["Ansstia"] = "0";
            }
        }
        else
        {
            ViewState["Ansstia"] = "0";
            txtAnaesthetist.BorderColor = Color.Gray;
        }
    }
    protected void txt1stAsst_TextChanged(object sender, EventArgs e)
    {
        if (txt1stAsst.Text != "")
        {
            string[] PatientInfo = txt1stAsst.Text.Split('-');
            if (PatientInfo.Length > 1)
            {
                txt1stAsst.Text = PatientInfo[1];
                ViewState["1AssistID"] = PatientInfo[0];
                txt1stAsst.BorderColor = Color.LightGray;
            }
            else
            {
                ViewState["1AssistID"] = "0";
                txt1stAsst.BorderColor = Color.LightGray;
            }
        }
        else
        {
            ViewState["1AssistID"] = "0";
            txt1stAsst.BorderColor = Color.LightGray;
        }
    }
    protected void txt2stAsst_TextChanged(object sender, EventArgs e)
    {
        //if (txt2stAsst.Text != "")
        //{
        //    string[] PatientInfo = txt2stAsst.Text.Split('-');
        //    if (PatientInfo.Length > 1)
        //    {
        //        txt2stAsst.Text = PatientInfo[1];
        //        ViewState["2AssistID"] = PatientInfo[0];
        //    }
        //    else
        //    {
        //        ViewState["2AssistID"] = "0";
        //    }
        //}
        //else
        //{
        //    ViewState["2AssistID"] = "0";
        //}
    }
    protected void txtSTERINURSE_TextChanged(object sender, EventArgs e)
    {
        if (txtSTERINURSE.Text != "")
        {
            string[] PatientInfo = txtSTERINURSE.Text.Split('-');
            if (PatientInfo.Length > 1)
            {
                txtSTERINURSE.Text = PatientInfo[1];
                ViewState["STERINURSE"] = PatientInfo[0];
            }
            else
            {
                ViewState["STERINURSE"] = "0";
            }
        }
        else
        {
            ViewState["STERINURSE"] = "0";
            txtSTERINURSE.BorderColor = Color.LightGray;
        }
    }
    protected void txtInstrumentFirstNurse_TextChanged(object sender, EventArgs e)
    {
        if (txtInstrumentFirstNurse.Text != "")
        {
            string[] PatientInfo = txtInstrumentFirstNurse.Text.Split('-');
            if (PatientInfo.Length > 1)
            {
                txtInstrumentFirstNurse.Text = PatientInfo[1];
                ViewState["InstruFirst"] = PatientInfo[0];
            }
            else
            {
                ViewState["InstruFirst"] = "0";
            }
        }
        else
        {
            ViewState["InstruFirst"] = "0";
            txtInstrumentFirstNurse.BorderColor = Color.LightGray;
        }
    }
    protected void txtInstrumentSecoundNurse_TextChanged(object sender, EventArgs e)
    {
        if (txtInstrumentSecoundNurse.Text != "")
        {
            string[] PatientInfo = txtInstrumentSecoundNurse.Text.Split('-');
            if (PatientInfo.Length > 1)
            {
                txtInstrumentSecoundNurse.Text = PatientInfo[1];
                ViewState["InstruSeco"] = PatientInfo[0];
            }
            else
            {
                ViewState["InstruSeco"] = "0";
            }
        }
        else
        {
            ViewState["InstruSeco"] = "0";
            txtInstrumentSecoundNurse.BorderColor = Color.LightGray;
        }
    }
    protected void txtswabSecountNurse_TextChanged(object sender, EventArgs e)
    {
        if (txtswabSecountNurse.Text != "")
        {
            string[] PatientInfo = txtswabSecountNurse.Text.Split('-');
            if (PatientInfo.Length > 1)
            {
                txtswabSecountNurse.Text = PatientInfo[1];
                ViewState["swabSecound"] = PatientInfo[0];
            }
            else
            {
                ViewState["swabSecound"] = "0";
            }
        }
        else
        {
            ViewState["swabSecound"] = "0";
            txtswabSecountNurse.BorderColor = Color.LightGray;
        }
    }
    protected void txtswabFirstNurse_TextChanged(object sender, EventArgs e)
    {
        if (txtswabFirstNurse.Text != "")
        {
            string[] PatientInfo = txtswabFirstNurse.Text.Split('-');
            if (PatientInfo.Length > 1)
            {
                txtswabFirstNurse.Text = PatientInfo[1];
                ViewState["swabFirst"] = PatientInfo[0];
            }
            else
            {
                ViewState["swabFirst"] = "0";
            }
        }
        else
        {
            ViewState["swabFirst"] = "0";
            txtswabSecountNurse.BorderColor = Color.LightGray;
        }
    }
    protected void txttrollyNurse_TextChanged(object sender, EventArgs e)
    {
        if (txttrollyNurse.Text != "")
        {
            string[] PatientInfo = txttrollyNurse.Text.Split('-');
            if (PatientInfo.Length >1)
            {
                txttrollyNurse.Text = PatientInfo[1];
                ViewState["TrollyNurse"] = PatientInfo[0];
            }
            else
            {
                ViewState["TrollyNurse"] = "0";
            }
        }
        else
        {
            ViewState["TrollyNurse"] = "0";
            txttrollyNurse.BorderColor = Color.LightGray;
        }
    }

    protected void txtDISEASE_TextChanged(object sender, EventArgs e)
    {
        if (txtDISEASE.Text != "")
        {
            string[] PatientInfo = txtDISEASE.Text.Split('-');
            if (PatientInfo.Length >1 )
            {
                txtDISEASE.Text = PatientInfo[1];
                ViewState["DISEASE"] = PatientInfo[0];
            }
            else
            {
                ViewState["DISEASE"] = "0";
            }
        }
        else
        {
            ViewState["DISEASE"] = "0";
            txtDISEASE.BorderColor = Color.LightGray;
        }
    }
    protected void txtoperation_TextChanged(object sender, EventArgs e)
    {
        if (txtoperation.Text != "")
        {
            string[] PatientInfo = txtoperation.Text.Split('-');
            if (PatientInfo.Length >1)
            {
                txtoperation.Text = PatientInfo[1];
                ViewState["Operation"] = PatientInfo[0];
            }
            else
            {
                ViewState["Operation"] = "0";
                
            }
        }
        else
        {
            ViewState["Operation"] = "0";
        }
    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        
          objBELBillDetail = new BELBillDetails();
       
            objBELBillDetail.IpdId = Convert.ToInt32(Request.QueryString["IpdId"]);

            objBELBillDetail.PatRegId = Convert.ToInt32(lblPatRegId.Text);
            objBELBillDetail.IpdNo = Convert.ToInt32(lblIpd.Text);
            objBELBillDetail.BillNo = Convert.ToInt32(lblIpd.Text);

            objBELBillDetail.Flag = Convert.ToString(Request.QueryString["Flag"]);
            if (validationSurgeon() == true)
            {
                if (txtsurgen.Text != "")
                {
                    objBELBillDetail.Surgan = Convert.ToInt32(ViewState["SurganID"]);
                }
                else
                {
                    objBELBillDetail.Surgan = 0;
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Enter Surgeon!!!');", true);
                return;

            }
           
                objBELBillDetail.OperationName = Convert.ToString(txtoperation.Text.Trim());           
           
                objBELBillDetail.DiseaseName = Convert.ToString(txtDISEASE.Text.Trim());
            

            if (ValidationAnaesthetist()==true)
            {
                objBELBillDetail.ANAESTHETIST = Convert.ToInt32(ViewState["Ansstia"]);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Select Anaesthetist from List!!!');", true);
                return;

            }
            if (Validation1stAss()==true)
            {
                objBELBillDetail.FirstAssistant = Convert.ToInt32(ViewState["1AssistID"]);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Select Assistant from List!!!');", true);
                return;

            }
            if (txt2stAsst.Text != "")
            {
                objBELBillDetail.SecondAssistant = txt2stAsst.Text;
            }
            else
            {
                objBELBillDetail.SecondAssistant = "";
            }

            if (ValidationSTERINURSE()==true)
            {
                objBELBillDetail.SteriNurse = Convert.ToInt32(ViewState["STERINURSE"]);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Select Nurse from List!!!');", true);
                return;

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
                objBELBillDetail.OperationEndTime = txttimeEnd.Text;
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

            //==================================
            if ( ValidationswabFirstNurse() == true)
            {
                objBELBillDetail.SwabCountNurse = Convert.ToInt32(ViewState["swabFirst"]);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Select Nurse from List!!!');", true);
                return;

            }
            if (ValidationswabSecountNurse()==true)
            {
                objBELBillDetail.swabSecountNurse = Convert.ToInt32(ViewState["swabSecound"]);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Select Nurse from List!!!');", true);
                return;

            }
            if (ValidationInstrumentFirstNurse() ==true)
            {
                objBELBillDetail.InstrumentCountNurse = Convert.ToInt32(ViewState["InstruFirst"]);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Select Nurse from List!!!');", true);
                return;

            }
            if (ValidationswabSecountNurse()==true)
            {
                objBELBillDetail.InstrumentSecoundNurse = Convert.ToInt32(ViewState["InstruSeco"]);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Select Nurse from List!!!');", true);
                return;

            }
            if (ValidationtrollyNurse() ==true)
            {
                objBELBillDetail.TrollyNurse = Convert.ToInt32(ViewState["TrollyNurse"]);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Select Nurse from List!!!');", true);
                return;

            }

            objBELBillDetail.CreatedBy = Convert.ToString(Session["username"]);
            objBELBillDetail.BranchId = Convert.ToInt32(Session["Branchid"]);

            objBELBillDetail.FId = Convert.ToInt32(Session["FId"]);
            
            objBELBillDetail.GeneralOT = Convert.ToInt32(1);
            objBELBillDetail.ASA = ddlASA.SelectedValue;
            if (DdlClass.SelectedValue == "0")
            {
               // DdlClass.Focus();
                //DdlClass.ForeColor = System.Drawing.Color.Red;
               // ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Select Class!!!');", true);
               // return;
                objBELBillDetail.OTClass ="0";
            }
            else
            {
                objBELBillDetail.OTClass = DdlClass.SelectedValue;
            }

            Message = objDALBillDetail.Insert_OTRegister(objBELBillDetail);
          //  lblMessage.Text = "OT Register save Successfully..";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + Message + "');", true);
            ViewState["Register"] = "true";
            
        }
        //else
        //{
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('"+ ViewState["Msg"] +"');", true);

        //}
    
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
         txtTTime.Text = Convert.ToString(ts.Hours) + " Hours " + Convert.ToString(ts.Minutes) + " Minutes"; 
        }
    }

    protected void txtOtRegTimeFrom_TextChanged(object sender, EventArgs e)
    {
        if (txttimeEnd.Text != "")
        {
            string STDate = txtOtRegDate.Text + " " + txtOtRegTime.Text;
            DateTime Startdate = Convert.ToDateTime(STDate);
            string ETDate = txtOtRegDate1.Text + " " + txtOtRegTimeFrom.Text;
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
            int TotHour = 0;
            if (Convert.ToString(ts.Hours) != "0")
            {
                 TotHour = ts.Hours * 2;
            }
            if (Convert.ToInt32(ts.Minutes) > 0)
            {
                if (Convert.ToInt32(ts.Minutes) > 30)
                {
                    TotHour = TotHour + 2;
                }
                else
                {
                    TotHour = TotHour + 1;
                }
            }
            ViewState["TotalMin"] = (TotHour-1);
           // ViewState["TotalMin"] = (TotHour );
            txtTotOTTime.Text = Convert.ToString(ts.Hours) + " Hours " + Convert.ToString(ts.Minutes) + " Minutes";
        }
    }

    protected void btnAddOT_Click(object sender, EventArgs e)
    {
        if (DdlClass.SelectedValue == "0")
        {
            ddlOtGrade.Focus();
            ddlOtGrade.ForeColor = System.Drawing.Color.Red;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Select Class!!!');", true);
            return;
        }
        else
        {
            txtdescription.InnerText = txtOtRegDate.Text + " " + txtOtRegTime.Text + " To " + txtOtRegDate1.Text + " " + txtOtRegTimeFrom.Text + " (" + txtTotOTTime.Text + ") " + ddlOtGrade.SelectedItem.Text + " Case (" + txtoperation.Text + ")";
            //this.btnAdd_Click(null, null);
            if (ddlOtGrade.SelectedValue != "0")
            {
                DataTable dtOp = new DataTable();
                dtOp = ObjDALIpd.Get_OTOperationCharges(ddlOtGrade.SelectedItem.Text, Convert.ToInt32(Session["Branchid"]));
                if (dtOp.Rows.Count > 0)
                {
                    ViewState["ServiceID"] = dtOp.Rows[0]["ServiceId"];
                }
                objBELBillDetail = new BELBillDetails();
                objBELBillDetail.IpdId = Convert.ToInt32(Request.QueryString["IpdId"]);
                objBELBillDetail.PatRegId = Convert.ToInt32(lblPatRegId.Text);
                objBELBillDetail.IpdNo = Convert.ToInt32(lblIpd.Text);
                objBELBillDetail.BillNo = Convert.ToInt32(lblIpd.Text);


                objBELBillDetail.Qty = Convert.ToDecimal(1);

                if (Convert.ToString(ViewState["TotalMin"]) == "0")
                {
                    objBELBillDetail.Charges = Convert.ToDecimal(dtOp.Rows[0]["rate"]);
                    objBELBillDetail.TotalCharges = objBELBillDetail.Charges;
                }
                else
                {
                    objBELBillDetail.Charges = Convert.ToDecimal(dtOp.Rows[0]["rate"]) + (Convert.ToDecimal(dtOp.Rows[0]["OTHourlyRate"]) * Convert.ToDecimal(ViewState["TotalMin"]));
                    objBELBillDetail.TotalCharges = objBELBillDetail.Charges;
                }


                if (txtdescription.Value != "")
                {
                    objBELBillDetail.Description = txtdescription.Value;
                }
                else
                {
                    objBELBillDetail.Description = "";
                }


                // objBELBillDetail.BillServiceId = Convert.ToInt32(ddlBillServices.SelectedValue);

                objBELBillDetail.BillServiceId = Convert.ToInt32(dtOp.Rows[0]["ServiceId"]);



                if (txtConsDoctorName.Text == "")
                {
                    objBELBillDetail.EmployeeId = 0;
                }
                else
                {
                    objBELBillDetail.EmployeeId = Convert.ToInt32(ViewState["ConsultID"]);
                }

                objBELBillDetail.CreatedBy = Convert.ToString(Session["username"]);
                objBELBillDetail.BranchId = Convert.ToInt32(Session["Branchid"]);
                objBELBillDetail.FId = Convert.ToInt32(Session["FId"]);
                objBELBillDetail.BillTypeName = RdbServicesFlag.SelectedValue;

                Message = objDALBillDetail.InsertIPDBillDetailOT(objBELBillDetail);
                BindBillDetails();


            }
        }
    }
    protected void ddlOtGrade_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlOtGrade.SelectedValue != "0")
        {
            DataTable dtOp = new DataTable();
            dtOp = ObjDALIpd.Get_OTOperationCharges(ddlOtGrade.SelectedItem.Text, Convert.ToInt32(Session["Branchid"]));
            if (dtOp.Rows.Count > 0)
            {
                ViewState["ServiceID"] = dtOp.Rows[0]["ServiceId"];
            }
           // txtCharges.Text = ObjDALIpd.GetIPDRoomcharges(Convert.ToInt32(lblPatRegId.Text), Convert.ToInt32(Session["FId"]), Convert.ToInt32(Session["Branchid"]), IpdId, ServiceId);
  
        }
    }
}