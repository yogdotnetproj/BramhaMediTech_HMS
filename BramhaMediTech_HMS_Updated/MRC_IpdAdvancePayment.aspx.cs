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

public partial class MRC_IpdAdvancePayment :BasePage
{
    DALIPDDesk ObjDALIpd = new DALIPDDesk();
   
    BELOPDPatReg objBELOpdPatReg = new BELOPDPatReg();
    DALOpdReg objDALOpdPatReg = new DALOpdReg();
    BELBillInfo objBELBillInfo = new BELBillInfo();
    DALBillInfo objDALBillInfo = new DALBillInfo();
    DALPatientInformation objDALPatInfo = new DALPatientInformation();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
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
            LoadRdbPaymentType();
            RdbPayment.SelectedValue = "1";
            PaymentDetails.Visible = false;
            txtAmtPaid.Text = "0";
            LoadConsultantDoc();
            ViewState["ReceiptNo"] = "0";
          
            if (Request.QueryString["RegId"] != "" && Request.QueryString["IpdId"] != "")
            {

                int RegId = Convert.ToInt32(Request.QueryString["RegId"]);
                int IpdId = Convert.ToInt32(Request.QueryString["IpdId"]);
                FillIpdPatInfo(RegId, IpdId);
                GetDepositAmount();
                Get_SurgeryDepositAmt();
                
            }
            if (Convert.ToString( Request.QueryString["Discharge"]) == "Yes")
            {
                btnsave.Visible = false;
                chkDeposite.Enabled = false;
            }
            
        }
    }
    public void GetDepositAmount()
    {
        decimal DepositAmt = objDALOpdPatReg.GetDepositAmount(Convert.ToInt32(Request.QueryString["RegId"]), Convert.ToInt32(Session["FId"]), Convert.ToInt32(Session["BranchId"]));
        ViewState["DepositAmt"] = DepositAmt;
        lblDepositAmt.Text = "(Deposit Amount=" + Convert.ToString(DepositAmt) + ")";
                    
    }

    public void Get_SurgeryDepositAmt()
    {
        decimal DepositAmt = objDALOpdPatReg.GetSurgeryDepositAmount(Convert.ToInt32(Request.QueryString["RegId"]), Convert.ToInt32(Session["FId"]), Convert.ToInt32(Session["BranchId"]), Convert.ToInt32(Request.QueryString["IpdId"]));
        if (DepositAmt > 0)
        {
            txtAmtPaid.Text = Convert.ToString(DepositAmt);
            LblSurgeryDepAmt.Text = "Surgery Deposit Amount : " + Convert.ToString(DepositAmt);
        }
        else
        {
            LblSurgeryDepAmt.Text = "";
        }
       // lblDepositAmt.Text = "(Deposit Amount=" + Convert.ToString(DepositAmt) + ")";

    }
    private void LoadConsultantDoc()
    {

        ddlConsDoctorName.DataSource = objDALOpdPatReg.FillConsultantDocName();
        ddlConsDoctorName.DataValueField = "DrId";
        ddlConsDoctorName.DataTextField = "EmpName";
        ddlConsDoctorName.DataBind();
    }
    public void FillIpdPatInfo(int RegId, int IpdId)
    {
        objBELOpdPatReg.IpdId = IpdId;
        objBELOpdPatReg.PatRegId = RegId;
        objBELOpdPatReg.FId = Convert.ToInt32(Session["FId"]);
        objBELOpdPatReg.BranchId = Convert.ToInt32(Session["Branchid"]);
        objBELOpdPatReg = ObjDALIpd.GetIpdPatientInformation(objBELOpdPatReg);
        lblPatName.Text = Convert.ToString(objBELOpdPatReg.PatientName);
        lblIPDNo.Text = Convert.ToString(objBELOpdPatReg.IpdNo);
        lblRegNo.Text = Convert.ToString(objBELOpdPatReg.PatRegId);
        FillPage(Convert.ToInt32(lblRegNo.Text),Convert.ToInt32(Session["FId"]),Convert.ToInt32(lblIPDNo.Text),Convert.ToInt32(lblIPDNo.Text));
        FillGrid(Convert.ToInt32(lblRegNo.Text), Convert.ToInt32(Session["FId"]), Convert.ToInt32(lblIPDNo.Text), Convert.ToInt32(lblIPDNo.Text));
        LoadReceipts();
        
    }
    private void LoadReceipts()
    {
        DataTable dt = objDALBillInfo.GetIpdReceiptNo(Convert.ToInt32(lblRegNo.Text), Convert.ToInt32(Session["FId"]), Convert.ToInt32(ViewState["IpdNo"]), Convert.ToInt32(ViewState["IpdNo"]));
        if (dt.Rows.Count > 0)
        {
            
            ddlreceipts.DataSource = dt;
            ddlreceipts.DataTextField = "ReceiptNo";
            ddlreceipts.DataValueField = "ReceiptNo";
            ddlreceipts.DataBind();
            ddlreceipts.Items.Insert(0, "-Receipt-");
            ddlreceipts.SelectedIndex = 0;
        }
    }
    private void LoadRdbPaymentType()
    {

        RdbPayment.DataSource = objDALBillInfo.FillModeOfPayment();
        RdbPayment.DataValueField = "ModeOfPaymentId";
        RdbPayment.DataTextField = "ModeOfPaymentName";
        RdbPayment.DataBind();
        txtbankName.DataSource = objDALPatInfo.GetBankName();
        txtbankName.DataTextField = "BankName";
        txtbankName.DataValueField = "BankCode";
        txtbankName.DataBind();

        txtbankName.Items.Insert(0, new ListItem("Select Bank", "0"));

    }
   
   
    public void FillGrid(int PatRegId, int FID, int BillNo, int IpdNo)
    {
        gvBillTransaction.DataSource = objDALOpdPatReg.Fill_MRC_IPDBilltransactions(PatRegId, FID, BillNo, IpdNo);
        gvBillTransaction.DataBind();
    }
    public void FillPage(int PatRegId, int FID, int BillNo, int IpdNo)
    {
       // objBELOpdPatReg = objDALOpdPatReg.GetMRC_PatientIPDBillDetails(PatRegId, FID, BillNo, IpdNo);
        DataSet ds = new DataSet();
        ds = objDALOpdPatReg.GetMRC_PatientIPDBillDetails(PatRegId, FID, BillNo, IpdNo);

        if (ds.Tables[0].Rows.Count > 0)
        {
            lblDiscAmt.Text = Convert.ToString(ds.Tables[0].Rows[0]["BillAmount"]);
        }
        if (ds.Tables[1].Rows.Count > 0)
        {
            lblBillServiceCharges.Text = Convert.ToString(ds.Tables[1].Rows[0]["BalanceForward"]);

            // lblBalance.Text = Convert.ToString(Convert.ToSingle( ds.Tables[0].Rows[0]["BillAmount"]) + Convert.ToSingle( ds.Tables[1].Rows[0]["BalanceForward"]));
            lblBalance.Text = Convert.ToString(Convert.ToSingle(ds.Tables[1].Rows[0]["BalanceForward"]));
        }
        if (ds.Tables[2].Rows.Count > 0)
        {
        lblAdvanceAmt.Text = Convert.ToString(ds.Tables[2].Rows[0]["ReceivedAmount"]); 
        }

       // ViewState["IpdNo"] = Convert.ToString(ds.Tables[3].Rows[0]["IpdNo"]);
        ViewState["IpdNo"] = Convert.ToString(Request.QueryString["IpdId"]);

        //lblBillServiceCharges.Text = Convert.ToString(objBELOpdPatReg.BillServiceCharges);
        //lblAdvanceAmt.Text = Convert.ToString(objBELOpdPatReg.AdvanceAmt);        
        //lblBalance.Text = Convert.ToString(objBELOpdPatReg.BalanceAmt);
        //lblDiscAmt.Text = Convert.ToString(objBELOpdPatReg.DiscountAmt);
        //lblInsurance.Text = Convert.ToString(objBELOpdPatReg.InsuranceAmount);   



    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
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
        if (txtAmtPaid.Text != "0")
        {
            InsertInBill();
            FillGrid(Convert.ToInt32(lblRegNo.Text), Convert.ToInt32(Session["FId"]), Convert.ToInt32(lblIPDNo.Text), Convert.ToInt32(lblIPDNo.Text));
            FillPage(Convert.ToInt32(lblRegNo.Text), Convert.ToInt32(Session["FId"]), Convert.ToInt32(lblIPDNo.Text), Convert.ToInt32(lblIPDNo.Text));
            LoadReceipts();
            txtRemark.Value = "";
            txtAmtPaid.Text = "0";
            lblerrormsg.Text = "Advance amt received";
        }
        else
        {
            lblerrormsg.Text = "Advance amt is zero";
            return;
        }
    }
   
    private void PrintReport()
    {
        try
        {
            BLLReports objBLLReports = new BLLReports();
            DataSet dsCustomers = new DataSet();
            ReportDocument crystalReport = new ReportDocument();
            crystalReport.Load(Server.MapPath("~/Report/Rpt_IpdPaymentReceipt.rpt"));
            if (Convert.ToString( ViewState["ReceiptNo"]) == "0")
            {
                ViewState["ReceiptNo"] = ddlreceipts.SelectedValue;
            }
            dsCustomers = objBLLReports.GetIPDBillDetails(Convert.ToInt32(ViewState["IpdNo"]), Convert.ToInt32(ViewState["ReceiptNo"]), Convert.ToInt32(ViewState["IpdNo"]), Convert.ToInt32(lblRegNo.Text), Convert.ToInt32(Session["FId"]), Convert.ToInt32(Session["BranchId"]));
            crystalReport.SetDataSource(dsCustomers);
            //crystalReport.ParameterFields["HospitalName"].CurrentValues.AddValue(Convert.ToString(Application["OrgnizationName"]));
            //crystalReport.ParameterFields["HospitalAddress"].CurrentValues.AddValue(Convert.ToString(Application["OrgnizationAddress"]));
            //crystalReport.ParameterFields["Image"].CurrentValues.AddValue(Application["ImagePath"]);
            // crystalReport.ParameterFields["ReportFooter"].CurrentValues.AddValue("Hospital Software | Ph.020 0000000000");
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

    private void InsertInBill()
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
        object[] returns;
        // string Message = "";
        BELBillInfo objBELBillInfo = new BELBillInfo();
       // objBELBillInfo.BillNo = Convert.ToInt32(lblBillNo.Text);
        int ReceiptNo = objDALBillInfo.GetMaxIpdReceiptNo(Convert.ToInt32(Session["FId"]));
        objBELBillInfo.ReceiptNo = ReceiptNo + 1;
        ViewState["ReceiptNo"] = objBELBillInfo.ReceiptNo;
        objBELBillInfo.PatRegId = Convert.ToInt32(lblRegNo.Text);
        objBELBillInfo.BillDate = System.DateTime.Now;
        objBELBillInfo.IpdNo = Convert.ToInt32(ViewState["IpdNo"]);
        objBELBillInfo.BillNo = Convert.ToInt32(ViewState["IpdNo"]);
        objBELBillInfo.ConsultantDrId = Convert.ToInt32(ddlConsDoctorName.SelectedValue);
        objBELBillInfo.Remark = txtRemark.Value;
        objBELBillInfo.BillType = "Advance Receipt";
        objBELBillInfo.PaymentType = RdbPayment.SelectedValue;
        if (chkDeposite.Checked == true)
        {
            if (Convert.ToDecimal(txtAmtPaid.Text) > Convert.ToDecimal(ViewState["DepositAmt"]))
            {
                lblerrormsg.Text = "Deposit Amount is less than Amount Given";
                return;
            }
            else
            {
                objBELBillInfo.AmountPaid = Convert.ToDecimal(txtAmtPaid.Text);
                objBELBillInfo.IsDeposit = true;
                UpdateDepositMaster();
            }

        }
        else
        {
            objBELBillInfo.AmountPaid = Convert.ToDecimal(txtAmtPaid.Text);
        }

        objBELBillInfo.CreatedBy = Convert.ToString(Session["username"]);
        if (txtNumber.Text != "")
        {
            objBELBillInfo.ChequeCardNo = txtNumber.Text;
        }
        else
            objBELBillInfo.ChequeCardNo = "0";


        if (txtbankName.SelectedItem.Text != "Select Bank")
        {
            objBELBillInfo.BankName = txtbankName.SelectedItem.Text;
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

        returns = objDALBillInfo.InsertIPDBillTransaction(objBELBillInfo);

        objBELBillInfo.Balance = Convert.ToDecimal(lblBillServiceCharges.Text);
        objBELBillInfo.IpdNo = Convert.ToInt32(lblIPDNo.Text);
        returns = objDALBillInfo.Insert_MRC_IPDBillTransaction(objBELBillInfo);

        ViewState["BillPaymentId"] = Convert.ToInt32(returns[0]);
        lblMessage.Text = "Record Saved Successfully";
        Clear();
    }
    public void Clear()
    {
        txtAmtPaid.Text = "0";
        txtRemark.Value = "";
        ddlConsDoctorName.SelectedValue = "0";
        chkDeposite.Checked = false;

    }

    public void UpdateDepositMaster()
    {
        objBELBillInfo.PatRegId = Convert.ToInt32(lblRegNo.Text);
        objBELBillInfo.DepositAmount = -(Convert.ToDecimal(txtAmtPaid.Text));
        objBELBillInfo.CreatedBy = Convert.ToString(Session["username"]);
        objBELBillInfo.BranchId = Convert.ToInt32(Session["Branchid"]);
        objBELBillInfo.FId = Convert.ToInt32(Session["FId"]);
        objBELBillInfo.BillType = "Withdrawal";
        objBELBillInfo.Remark = "IPD Bill Advance";
        objBELBillInfo.PaymentType = "0";
        objBELBillInfo.flag = "AdvanceReceipt";
        objDALBillInfo.InsertDepositTransaction(objBELBillInfo);
        GetDepositAmount();
    }



    protected void btnIPDBill_Click(object sender, EventArgs e)
    {
        //Response.Redirect("~/IpdBillForPatientServices.aspx?RegId=137555&IpdId=12", false);
        string response = @"~/IpdBillForPatientServices.aspx?RegId=" + lblRegNo.Text + "&IpdId=" + lblIPDNo.Text;

        Response.Redirect(string.Format(response),false);
        return;
    }
    protected void btncancelreceipt_Click(object sender, EventArgs e)
    {
        if (ddlreceipts.SelectedValue != "-Receipt-")
        {
            if (txtRemark.Value == "")
            {
                lblMessage.Text = "pls enter remark";

                txtRemark.Focus();
            }
            else
            {
                InsertCancelReceiptInBill();
            }
        }
        else
        {
            ddlreceipts.Focus();
            ddlreceipts.BorderColor = System.Drawing.Color.Red;
            lblMessage.Text = "pls select receipt no";
        }
    }

    private void InsertCancelReceiptInBill()
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
        object[] returns;
        // string Message = "";
        BELBillInfo objBELBillInfo = new BELBillInfo();
        // objBELBillInfo.BillNo = Convert.ToInt32(lblBillNo.Text);
        // int ReceiptNo = objDALBillInfo.GetMaxIpdReceiptNo(Convert.ToInt32(Session["FId"]));
        objBELBillInfo.ReceiptNew = Convert.ToInt32(ddlreceipts.SelectedValue);
        //ViewState["ReceiptNo"] = objBELBillInfo.ReceiptNew;
        objBELBillInfo.PatRegId = Convert.ToInt32(lblRegNo.Text);
        objBELBillInfo.BillDate = System.DateTime.Now;
        objBELBillInfo.IpdNo = Convert.ToInt32(lblIPDNo.Text);
        objBELBillInfo.BillNo = Convert.ToInt32(lblIPDNo.Text);
        objBELBillInfo.Remark = txtRemark.Value;
        objBELBillInfo.CreatedBy = Convert.ToString(Session["username"]);
        objBELBillInfo.ReceiptNo = Convert.ToInt32(ddlreceipts.SelectedValue);


        // objBELBillInfo.CreatedBy = Convert.ToString(Session["username"]);
        objBELBillInfo.BranchId = Convert.ToInt32(Session["Branchid"]);
        objBELBillInfo.FId = Convert.ToInt32(Session["FId"]);

        returns = objDALBillInfo.InsertIPD_CancelReceiptTransaction(objBELBillInfo);
        FillGrid(Convert.ToInt32(lblRegNo.Text), Convert.ToInt32(Session["FId"]), Convert.ToInt32(lblIPDNo.Text), Convert.ToInt32(lblIPDNo.Text));
        //ViewState["BillPaymentId"] = Convert.ToInt32(returns[0]);
        lblMessage.Text = "cancel receipt Saved Successfully";
        Clear();
    }
}