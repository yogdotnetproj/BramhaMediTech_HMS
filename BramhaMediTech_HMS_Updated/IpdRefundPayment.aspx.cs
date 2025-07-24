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

public partial class IpdRefundPayment :BasePage
{
    DALIPDDesk ObjDALIpd = new DALIPDDesk();

    BELOPDPatReg objBELOpdPatReg = new BELOPDPatReg();
    DALOpdReg objDALOpdPatReg = new DALOpdReg();
    BELBillInfo objBELBillInfo = new BELBillInfo();
    DALBillInfo objDALBillInfo = new DALBillInfo();
    BELOPDPatReg objBELIpd = new BELOPDPatReg();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            LoadRdbPaymentType();
            RdbPayment.SelectedValue = "1";
            PaymentDetails.Visible = false;
            txtRefundAmt.Text = "0";
           

            if (Request.QueryString["RegId"] != "" && Request.QueryString["IpdId"] != "")
            {

                int RegId = Convert.ToInt32(Request.QueryString["RegId"]);
                int IpdId = Convert.ToInt32(Request.QueryString["IpdId"]);
                FillIpdPatInfo(RegId, IpdId);
                FillIpdPatInfoAmt(RegId, IpdId);

            }

            if (Convert.ToString( Request.QueryString["ISCancel"]) == "Yes")
            {
                chkiscancel.Visible = true;
                chkiscancel.Checked = true;
            }
        }
    }
    public void FillIpdPatInfo(int RegId, int IpdId)
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
        Label6.Text = Convert.ToString(objBELIpd.Sponsor);
        Label8.Text = Convert.ToString(objBELIpd.Sponsor2);
    }

    public void FillIpdPatInfoAmt(int RegId, int IpdId)
    {
        objBELOpdPatReg.IpdId = IpdId;
        objBELOpdPatReg.PatRegId = RegId;
        objBELOpdPatReg.FId = Convert.ToInt32(Session["FId"]);
        objBELOpdPatReg.BranchId = Convert.ToInt32(Session["Branchid"]);
        objBELOpdPatReg = ObjDALIpd.GetIpdPatientInformation(objBELOpdPatReg);
       // lblPatName.Text = Convert.ToString(objBELOpdPatReg.PatientName);
        lblIpd.Text = Convert.ToString(objBELOpdPatReg.IpdNo);
        lblPatRegId.Text = Convert.ToString(objBELOpdPatReg.PatRegId);
        FillPage(Convert.ToInt32(lblPatRegId.Text), Convert.ToInt32(IpdId), Convert.ToInt32(Session["FId"]), Convert.ToInt32(Session["Branchid"]));

    }
   
    private void LoadRdbPaymentType()
    {

        RdbPayment.DataSource = objDALBillInfo.FillModeOfPayment();
        RdbPayment.DataValueField = "ModeOfPaymentId";
        RdbPayment.DataTextField = "ModeOfPaymentName";
        RdbPayment.DataBind();


    }



    public void FillPage(int PatRegId, int IpdId, int FID, int BranchId)
    {
        objBELOpdPatReg = objDALOpdPatReg.GetIPDBillMasterDetails(PatRegId,IpdId, FID,BranchId);


        lblBillServiceCharges.Text = Convert.ToString(objBELOpdPatReg.BillServiceCharges);
        lblAdvanceAmt.Text = Convert.ToString(objBELOpdPatReg.AdvanceAmt);
       // lblBalance.Text = Convert.ToString(objBELOpdPatReg.BalanceAmt);
        lblDiscAmt.Text = Convert.ToString(objBELOpdPatReg.DiscountAmt);
        lblInsurance.Text = Convert.ToString(objBELOpdPatReg.InsuranceAmount);

        txtRefundAmt.Text = Convert.ToString(Convert.ToSingle(lblBillServiceCharges.Text) - (Convert.ToSingle(lblAdvanceAmt.Text) + Convert.ToSingle(lblDiscAmt.Text) + Convert.ToSingle(lblInsurance.Text)));

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





    protected void txtAmtPaid_TextChanged(object sender, EventArgs e)
    {


    }

    protected void btnreport_Click(object sender, EventArgs e)
    {
        PrintReport();

    }

    protected void btnsave_Click(object sender, EventArgs e)
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
        InsertInBill();
       // FillGrid(Convert.ToInt32(lblRegNo.Text), Convert.ToInt32(Session["FId"]), Convert.ToInt32(lblIpd.Text), Convert.ToInt32(lblIpd.Text));
        FillPage(Convert.ToInt32(lblPatRegId.Text), Convert.ToInt32(Request.QueryString["IpdId"]), Convert.ToInt32(Session["FId"]), Convert.ToInt32(Session["BranchId"]));
       // LoadReceipts();
        txtRemark.Value = "";
        txtRefundAmt.Text = "0";
    }

    private void PrintReport()
    {
        try
        {
            BLLReports objBLLReports = new BLLReports();
            DataSet dsCustomers = new DataSet();
            ReportDocument crystalReport = new ReportDocument();
            crystalReport.Load(Server.MapPath("~/Report/Rpt_IpdPaymentReceipt.rpt"));
            //if (Convert.ToString(ViewState["ReceiptNo"]) == "0")
            //{
            //    ViewState["ReceiptNo"] = ddlreceipts.SelectedValue;
            //}
            int ReceiptNo = objDALBillInfo.GetMaxIpdReceiptNo_ForRef(Convert.ToInt32(Session["FId"]));
            dsCustomers = objBLLReports.GetIPDBillDetails(Convert.ToInt32(lblIpd.Text), Convert.ToInt32(ReceiptNo), Convert.ToInt32(lblIpd.Text), Convert.ToInt32(lblPatRegId.Text), Convert.ToInt32(Session["FId"]), Convert.ToInt32(Session["BranchId"]));
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

    private void InsertInBill()
    {
        object[] returns;
        // string Message = "";
        BELBillInfo objBELBillInfo = new BELBillInfo();
        // objBELBillInfo.BillNo = Convert.ToInt32(lblBillNo.Text);
        int ReceiptNo = objDALBillInfo.GetMaxIpdReceiptNo(Convert.ToInt32(Session["FId"]));
        objBELBillInfo.ReceiptNo = ReceiptNo + 1;
        ViewState["ReceiptNo"] = objBELBillInfo.ReceiptNo;
        objBELBillInfo.PatRegId = Convert.ToInt32(lblPatRegId.Text);
        objBELBillInfo.BillDate = System.DateTime.Now;
        objBELBillInfo.IpdNo = Convert.ToInt32(lblIpd.Text);
        objBELBillInfo.BillNo = Convert.ToInt32(lblIpd.Text);
        //objBELBillInfo.ConsultantDrId = Convert.ToInt32(ddlConsDoctorName.SelectedValue);
        objBELBillInfo.Remark = txtRemark.Value;
        objBELBillInfo.BillType = "Refund Receipt";
        objBELBillInfo.PaymentType = RdbPayment.SelectedValue;
        if (chkDeposite.Checked == true)
        {

                
                objBELBillInfo.IsDeposit =true;
                objBELBillInfo.AmountPaid = Convert.ToDecimal(txtRefundAmt.Text);
                UpdateDepositMaster();
            
        }
        else
        {
            objBELBillInfo.IsDeposit = false;
            objBELBillInfo.AmountPaid = (Convert.ToDecimal(txtRefundAmt.Text));
        }

        objBELBillInfo.CreatedBy = Convert.ToString(Session["username"]);
        if (txtNumber.Text != "")
        {
            objBELBillInfo.ChequeCardNo = txtNumber.Text;
        }
        else
            objBELBillInfo.ChequeCardNo = "0";


        if (txtBankName.Text != "")
        {
            objBELBillInfo.BankName = txtBankName.Text;
        }
        else
            objBELBillInfo.BankName = "";
        if (txtchequedate.Value != "")
        {
            objBELBillInfo.ChequeDate = txtchequedate.Value.ToString();
        }
        objBELBillInfo.CreatedBy = Convert.ToString(Session["username"]);
        objBELBillInfo.BranchId = Convert.ToInt32(Session["Branchid"]);
        objBELBillInfo.FId = Convert.ToInt32(Session["FId"]);

        returns = objDALBillInfo.InsertIPDBillTransaction(objBELBillInfo);
        if (chkiscancel.Checked == true)
        {
            objDALBillInfo.InsertIPDBillTransaction_BillCancel(objBELBillInfo);
            lblMessage.Text = "Admission cancel Successfully";
        }
        else
        {
            lblMessage.Text = "Refund Saved Successfully";
        }

        ViewState["BillPaymentId"] = Convert.ToInt32(returns[0]);
        
        Clear();
    }
    public void Clear()
    {

        txtRefundAmt.Text = "0";
        txtRemark.Value = "";
        
        chkDeposite.Checked = false;

    }

    public void UpdateDepositMaster()
    {
        objBELBillInfo.PatRegId = Convert.ToInt32(lblPatRegId.Text);
        if (Convert.ToSingle(txtRefundAmt.Text) < 0)
        {
            objBELBillInfo.DepositAmount = Convert.ToDecimal(txtRefundAmt.Text)*-1;
        }
        else
        {
            objBELBillInfo.DepositAmount = Convert.ToDecimal(txtRefundAmt.Text);
        }
        objBELBillInfo.CreatedBy = Convert.ToString(Session["username"]);
        objBELBillInfo.BranchId = Convert.ToInt32(Session["Branchid"]);
        objBELBillInfo.FId = Convert.ToInt32(Session["FId"]);
        objBELBillInfo.BillType = "Deposit";
        objBELBillInfo.Remark = "Refund transfer to Deposit";
        objBELBillInfo.PaymentType = "0";
        objBELBillInfo.flag = "RefundReceipt";
        objDALBillInfo.InsertDepositTransaction(objBELBillInfo);
       
    }



    protected void chkiscancel_CheckedChanged(object sender, EventArgs e)
    {
        if (Convert.ToSingle(txtRefundAmt.Text) < 0)
        {
             
        }
    }
}