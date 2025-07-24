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

public partial class OpdPaybillOutstanding : BasePage
{
    BELOPDPatReg objBELOpdPatReg = new BELOPDPatReg();
    DALOpdReg objDALOpdPatReg = new DALOpdReg();
    BELBillInfo objBELBillInfo = new BELBillInfo();
    DALBillInfo objDALBillInfo = new DALBillInfo();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadReasonForDiscount();
            LoadReasonForBalance();
            LoadDiscountGivenBy();
            LoadRdbPaymentType();
            RdbPayment.SelectedValue = "1";
            PaymentDetails.Visible = false;
            txtAmtPaid.Text = "0";
            rdbdiscAmt.Checked = true;
            ViewState["ReceiptNo"] = "0";
            LoadInsuranceComp();
            if (Request.QueryString["Type"] == "SettleInsurance")
            {
                PaymentInsurance.Checked = true;
                InsuranceDetails.Visible = true;
                LoadInsuranceComp();
            }
            else
            {
                PaymentInsurance.Checked = false;
                InsuranceDetails.Visible = false;
            }
            if (Request.QueryString["PatRegId"] != null && Request.QueryString["FID"] != null && Request.QueryString["BillNo"] != null && Request.QueryString["OpdNo"] != null)
            {

                ViewState["PatientInfoID"] = Request.QueryString["PatientInfoID"];
                FillPage(Convert.ToInt32(Request.QueryString["PatRegId"]), Convert.ToInt32(Request.QueryString["FID"]), Convert.ToInt32(Request.QueryString["BillNo"]), Convert.ToInt32(Request.QueryString["OpdNo"]));
                FillGrid(Convert.ToInt32(Request.QueryString["PatRegId"]), Convert.ToInt32(Request.QueryString["FID"]), Convert.ToInt32(Request.QueryString["BillNo"]), Convert.ToInt32(Request.QueryString["OpdNo"]));

            }
        }
    }
    private void LoadRdbPaymentType()
    {

        RdbPayment.DataSource = objDALBillInfo.FillModeOfPayment();
        RdbPayment.DataValueField = "ModeOfPaymentId";
        RdbPayment.DataTextField = "ModeOfPaymentName";
        RdbPayment.DataBind();


    }
    private void LoadInsuranceComp()
    {
        ddlInsuranceCompName.DataSource = objDALOpdPatReg.FillInsuranceComp();
        ddlInsuranceCompName.DataTextField = "InsuranceCompanyName";
        ddlInsuranceCompName.DataValueField = "InsuranceCompanyId";
        ddlInsuranceCompName.DataBind();
    }
    private void LoadDiscountGivenBy()
    {
        ddlDiscountGivenBy.DataSource = objDALBillInfo.FillDiscountGivenby();
        ddlDiscountGivenBy.DataValueField = "DrId";
        ddlDiscountGivenBy.DataTextField = "EmpName";
        ddlDiscountGivenBy.DataBind();
    }
    public void FillGrid(int PatRegId, int FID, int BillNo, int OpdNo)
    {
        gvBillTransaction.DataSource = objDALOpdPatReg.FillBilltransactions(PatRegId, FID, BillNo, OpdNo);
        gvBillTransaction.DataBind();
    }
    public void FillPage(int PatRegId,int FID,int BillNo,int OpdNo)
    {
        objBELOpdPatReg = objDALOpdPatReg.GetPatientBillDetails(PatRegId, FID, BillNo, OpdNo);
        
        lblage.Text = Convert.ToString(objBELOpdPatReg.Age);
        lblBillNo.Text = Convert.ToString(objBELOpdPatReg.BillNo);
        lblPatName.Text = Convert.ToString(objBELOpdPatReg.PatientName);
        lblgender.Text = Convert.ToString(objBELOpdPatReg.Gender);
        lblMobileno.Text = Convert.ToString(objBELOpdPatReg.MobileNo);
        lblConDoc.Text = Convert.ToString(objBELOpdPatReg.EmployeeName);
        lblBillServiceCharges.Text = Convert.ToString(objBELOpdPatReg.BillServiceCharges);
        lblAdvanceAmt.Text = Convert.ToString(objBELOpdPatReg.AdvanceAmt);
        txtBillDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        lblRegNo.Text = Convert.ToString(objBELOpdPatReg.PatRegId);
        txtBalance.Text = Convert.ToString(objBELOpdPatReg.BalanceAmt);
        lblDiscAmt.Text = Convert.ToString(objBELOpdPatReg.DiscountAmt);
        PaymentInsurance.Checked = objBELOpdPatReg.IsInsuranceFlag;
        txtInsuranceAmt.Text = Convert.ToString(objBELOpdPatReg.InsuranceAmount);
        ddlInsuranceCompName.SelectedValue = Convert.ToString(objBELOpdPatReg.InsuranceCompId);
        


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
    protected void txtDiscnt_TextChanged(object sender, EventArgs e)
    {
        lblerrormsg.Text = "";
        double InsuranceAmt = 0;
        if (txtInsuranceAmt.Text != "")
        {
            if (rdblInsuranceAmt.SelectedValue == "1")
            {
                InsuranceAmt = (Convert.ToSingle(lblBillServiceCharges.Text) * Convert.ToSingle(txtInsuranceAmt.Text)) / 100;
                
            }
            if (rdblInsuranceAmt.SelectedValue == "0")
            {
                InsuranceAmt = Convert.ToSingle(txtInsuranceAmt.Text);

               

            }
        }
        else
        {
            InsuranceAmt = 0;
        }

        if (rdbdiscAmt.Checked)
        {
            if (txtDiscnt.Text != "")
            {


                if (txtAmtPaid.Text == "")
                    txtAmtPaid.Text = "0";

                double balance = Convert.ToDouble(Convert.ToDouble(lblBillServiceCharges.Text) - (Convert.ToDouble(lblDiscAmt.Text) + Convert.ToDouble(lblAdvanceAmt.Text) ));


                txtBalance.Text = Convert.ToString(Convert.ToDouble(balance) - (Convert.ToDouble(txtDiscnt.Text) + Convert.ToDouble(txtAmtPaid.Text) + Convert.ToDouble(InsuranceAmt)));
                   
                    ViewState["DiscountPercent"] = (Convert.ToDouble(txtDiscnt.Text) * 100) / Convert.ToDouble(balance);
                    ViewState["DiscountAmount"] = Convert.ToDouble(txtDiscnt.Text);
                
            }
        }
        else
        {
            if (txtDiscnt.Text != "")
            {
                if (txtAmtPaid.Text == "")
                    txtAmtPaid.Text = "0";
                
                    double balance = Convert.ToDouble(Convert.ToDouble(lblBillServiceCharges.Text) - (Convert.ToDouble(lblDiscAmt.Text) + Convert.ToDouble(lblAdvanceAmt.Text)));

                    txtBalance.Text = Convert.ToString(Convert.ToDouble(balance) - (((Convert.ToDouble(balance) * Convert.ToDouble(txtDiscnt.Text)) / 100) + Convert.ToDouble(txtAmtPaid.Text) + Convert.ToDouble(InsuranceAmt)));
                   
                    ViewState["DiscountPercent"] = Convert.ToDouble(txtDiscnt.Text);
                    ViewState["DiscountAmount"] = ((Convert.ToDouble(balance) * Convert.ToDouble(txtDiscnt.Text)) / 100);
                
            }
        }

    }
    
    
   
   
   
    protected void txtAmtPaid_TextChanged(object sender, EventArgs e)
    {
        lblerrormsg.Text = "";
        if (txtAmtPaid.Text != "")
        {
            if (txtDiscnt.Text == "")
                txtDiscnt.Text = "0";
            double balance = Convert.ToDouble(Convert.ToDouble(lblBillServiceCharges.Text) - (Convert.ToDouble(lblDiscAmt.Text) + Convert.ToDouble(txtAmtPaid.Text) + Convert.ToDouble(lblAdvanceAmt.Text) + Convert.ToDouble(txtDiscnt.Text)));
            
            
            //double PaidAmount =
            txtBalance.Text = Convert.ToString(Convert.ToDouble(balance));// - (Convert.ToDouble(txtAmtPaid.Text)+Convert.ToDouble(txtDiscnt.Text)));
        }

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
    protected void btnreport_Click(object sender, EventArgs e)
    {
        PrintReport();

    }

    protected void btnsave_Click(object sender, EventArgs e)
    {
        InsertInBill();
        FillGrid(Convert.ToInt32(Request.QueryString["PatRegId"]), Convert.ToInt32(Request.QueryString["FID"]), Convert.ToInt32(Request.QueryString["BillNo"]), Convert.ToInt32(Request.QueryString["OpdNo"]));
        FillPage(Convert.ToInt32(Request.QueryString["PatRegId"]), Convert.ToInt32(Request.QueryString["FID"]), Convert.ToInt32(Request.QueryString["BillNo"]), Convert.ToInt32(Request.QueryString["OpdNo"]));
        txtAmtPaid.Text = "0";
    }
    protected void Button2_Click1(object sender, EventArgs e)
    {

    }
    private void PrintReport()
    {
        try
        {
            BLLReports objBLLReports = new BLLReports();
            DataSet dsCustomers = new DataSet();
            ReportDocument crystalReport = new ReportDocument();
            crystalReport.Load(Server.MapPath("~/Report/Rpt_OPDBilling.rpt"));            
            dsCustomers = objBLLReports.GetOPDBillDetails(Convert.ToInt32(Request.QueryString["BillNo"]), Convert.ToInt32(ViewState["ReceiptNo"]), Convert.ToInt32(Request.QueryString["OpdNo"]), Convert.ToInt32(Request.QueryString["PatRegId"]), Convert.ToInt32(Request.QueryString["FID"]), Convert.ToInt32(Session["BranchId"]));
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

        //int BillNo = objDALBillInfo.GetMaxBillNo(Convert.ToInt32(Session["FId"]));
        //objBELBillInfo.BillNo = BillNo + 1;
        //ViewState["BillNo"] = objBELBillInfo.BillNo;
        objBELBillInfo.BillNo =Convert.ToInt32(lblBillNo.Text);
        int ReceiptNo = objDALBillInfo.GetMaxReceiptNo(Convert.ToInt32(Session["FId"]));
        objBELBillInfo.ReceiptNo = ReceiptNo + 1;
        ViewState["ReceiptNo"] = objBELBillInfo.ReceiptNo;
        objBELBillInfo.PatRegId = Convert.ToInt32(lblRegNo.Text);
        objBELBillInfo.BillDate = System.DateTime.Now;
        objBELBillInfo.OpdNo = Convert.ToInt32(Request.QueryString["OpdNo"]);
        double balance1 = Convert.ToDouble(Convert.ToDouble(lblBillServiceCharges.Text) - (Convert.ToDouble(lblDiscAmt.Text) + Convert.ToDouble(lblAdvanceAmt.Text)));
          
        if (txtDiscnt.Text != "" &&txtDiscnt.Text !="0")
        {
            if (Convert.ToDouble(ViewState["DiscountAmount"]) > balance1)
            {
                lblerrormsg.Text = "Discount amount should be less/equal than Paid amount";
                return;
            }
            else
                lblerrormsg.Text = "";
            objBELBillInfo.Discount = Convert.ToDecimal(ViewState["DiscountAmount"]);
            
        }
        else
        {
            objBELBillInfo.Discount = 0;

        }
        if (Convert.ToDouble(txtAmtPaid.Text) > balance1)
        {
            lblerrormsg.Text = "Paid amount should be less/equal to balance amount";
            return;
        }
        else
        {
            lblerrormsg.Text = "";
            objBELBillInfo.AmountPaid = Convert.ToDecimal(txtAmtPaid.Text);
        }
        objBELBillInfo.Balance = Convert.ToDecimal(txtBalance.Text);

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
        if (PaymentInsurance.Checked == true)
        {
            objBELBillInfo.IsInsuranceFlag = true;
        }
        else
            objBELBillInfo.IsInsuranceFlag = false;
        
        objBELBillInfo.InsuranceCompId = Convert.ToInt32(ddlInsuranceCompName.SelectedValue);

        if (txtInsuranceAmt.Text != "")
        {
            if (rdblInsuranceAmt.SelectedValue == "0")
            {
                objBELBillInfo.InsuranceAmount = Convert.ToDecimal(txtInsuranceAmt.Text);
            }
            if (rdblInsuranceAmt.SelectedValue == "1")
            {
                objBELBillInfo.InsuranceAmount = Convert.ToDecimal((Convert.ToSingle(lblBillServiceCharges.Text) * Convert.ToSingle(txtInsuranceAmt.Text)) / 100);

            }
        }
        else
        {
            objBELBillInfo.InsuranceAmount = 0;
        }

        objBELBillInfo.CreatedBy = Convert.ToString(Session["username"]);
        objBELBillInfo.BranchId = Convert.ToInt32(Session["Branchid"]);
        objBELBillInfo.FId = Convert.ToInt32(Request.QueryString["FID"]);

        returns = objDALBillInfo.InsertBillTransaction(objBELBillInfo);
        ViewState["BillPaymentId"] = Convert.ToInt32(returns[0]);
        lblMessage.Text = "Record Saved Successfully";

        

        //string message = "Order Placed Successfully. and BillId is "+ ViewState["BillPaymentId"];

        //System.Text.StringBuilder sb = new System.Text.StringBuilder();

        //sb.Append("<script type = 'text/javascript'>");

        //sb.Append("window.onload=function(){");

        //sb.Append("alert('");

        //sb.Append(message);

        //sb.Append("')};");

        //sb.Append("</script>");

        //ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());

      //  ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "<script type = 'text/javascript'> window.onload=function(){alert('Record Saved Successfully')}; </script>");
      //  ScriptManager.RegisterStartupScript(this, GetType(), "alertmsg", "alert('"+message+"') ;", true);

    }

    protected void PaymentInsurance_CheckedChanged(object sender, EventArgs e)
    {
        if (PaymentInsurance.Checked == true)
        {

            // InsuranceDetails.Visible = true;
            InsuranceDetails.Visible = false;

        }
        else
        {
            InsuranceDetails.Visible = false;
        }
    }

    protected void rdblInsuranceAmt_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (txtInsuranceAmt.Text != "0" && txtInsuranceAmt.Text != "")
        //{
        //    if (rdblInsuranceAmt.SelectedValue == "1")
        //    {

        //        //double InsuranceAmt = (Convert.ToSingle(txtAmount.Text) * Convert.ToSingle(txtInsuranceAmt.Text)) / 100;
        //        //txtPaid.Text = Convert.ToString(Convert.ToSingle(txtAmount.Text) - InsuranceAmt);
        //        //txtbalance.Text = Convert.ToString(Convert.ToSingle(txtAmount.Text) - Convert.ToSingle(InsuranceAmt + Convert.ToSingle(txtPaid.Text)));
        //    }
        //    if (rdblInsuranceAmt.SelectedValue == "0")
        //    {
        //        //txtPaid.Text = Convert.ToString(Convert.ToSingle(txtAmount.Text) - Convert.ToSingle(txtInsuranceAmt.Text));
        //        //txtbalance.Text = Convert.ToString(Convert.ToSingle(txtAmount.Text) - (Convert.ToSingle(txtInsuranceAmt.Text) + Convert.ToSingle(txtPaid.Text)));

        //    }

        //}

        double InsuranceAmt = 0;
        if (txtInsuranceAmt.Text != "")
        {
            if (rdblInsuranceAmt.SelectedValue == "1")
            {
                InsuranceAmt = (Convert.ToSingle(lblBillServiceCharges.Text) * Convert.ToSingle(txtInsuranceAmt.Text)) / 100;

            }
            if (rdblInsuranceAmt.SelectedValue == "0")
            {
                InsuranceAmt = Convert.ToSingle(txtInsuranceAmt.Text);



            }
        }
        else
        {
            InsuranceAmt = 0;
        }

        if (rdbdiscAmt.Checked)
        {
            if (txtDiscnt.Text != "")
            {


                if (txtAmtPaid.Text == "")
                    txtAmtPaid.Text = "0";

                double balance = Convert.ToDouble(Convert.ToDouble(lblBillServiceCharges.Text) - (Convert.ToDouble(lblDiscAmt.Text) + Convert.ToDouble(lblAdvanceAmt.Text)));


                txtBalance.Text = Convert.ToString(Convert.ToDouble(balance) - (Convert.ToDouble(txtDiscnt.Text) + Convert.ToDouble(txtAmtPaid.Text) + Convert.ToDouble(InsuranceAmt)));

               

            }
        }
        else
        {
            if (txtDiscnt.Text != "")
            {
                if (txtAmtPaid.Text == "")
                    txtAmtPaid.Text = "0";

                double balance = Convert.ToDouble(Convert.ToDouble(lblBillServiceCharges.Text) - (Convert.ToDouble(lblDiscAmt.Text) + Convert.ToDouble(lblAdvanceAmt.Text)));

                txtBalance.Text = Convert.ToString(Convert.ToDouble(balance) - (((Convert.ToDouble(balance) * Convert.ToDouble(txtDiscnt.Text)) / 100) + Convert.ToDouble(txtAmtPaid.Text) + Convert.ToDouble(InsuranceAmt)));

                

            }
        }
    }

    protected void txtInsuranceAmt_TextChanged1(object sender, EventArgs e)
    {
        //if (txtInsuranceAmt.Text != "0" && txtInsuranceAmt.Text != "")
        //{
        //    if (rdblInsuranceAmt.SelectedValue == "1")
        //    {
        //        //double InsuranceAmt = (Convert.ToSingle(txtAmount.Text) * Convert.ToSingle(txtInsuranceAmt.Text)) / 100;
        //        //txtPaid.Text = Convert.ToString(Convert.ToSingle(txtAmount.Text) - InsuranceAmt);
        //        //txtbalance.Text = Convert.ToString(Convert.ToSingle(txtAmount.Text) - (InsuranceAmt + Convert.ToSingle(txtPaid.Text)));
        //    }
        //    if (rdblInsuranceAmt.SelectedValue == "0")
        //    {
        //        //txtPaid.Text = Convert.ToString(Convert.ToSingle(txtAmount.Text) - Convert.ToSingle(txtInsuranceAmt.Text));
        //        //txtbalance.Text = Convert.ToString(Convert.ToSingle(txtAmount.Text) - (Convert.ToSingle(txtInsuranceAmt.Text) + Convert.ToSingle(txtPaid.Text)));

        //    }

        //}
        double InsuranceAmt = 0;
        if (txtInsuranceAmt.Text != "")
        {
            if (rdblInsuranceAmt.SelectedValue == "1")
            {
                InsuranceAmt = (Convert.ToSingle(lblBillServiceCharges.Text) * Convert.ToSingle(txtInsuranceAmt.Text)) / 100;

            }
            if (rdblInsuranceAmt.SelectedValue == "0")
            {
                InsuranceAmt = Convert.ToSingle(txtInsuranceAmt.Text);



            }
        }
        else
        {
            InsuranceAmt = 0;
        }

        if (rdbdiscAmt.Checked)
        {
            if (txtDiscnt.Text == "")
            {
                txtDiscnt.Text = "0";
            }


                if (txtAmtPaid.Text == "")
                    txtAmtPaid.Text = "0";

                double balance = Convert.ToDouble(Convert.ToDouble(lblBillServiceCharges.Text) - (Convert.ToDouble(lblDiscAmt.Text) + Convert.ToDouble(lblAdvanceAmt.Text)));


                txtBalance.Text = Convert.ToString(Convert.ToDouble(balance) - (Convert.ToDouble(txtDiscnt.Text) + Convert.ToDouble(txtAmtPaid.Text) + Convert.ToDouble(InsuranceAmt)));



            
        }
        else
        {
            if (txtDiscnt.Text == "")
            {
                txtDiscnt.Text = "0";
            }
                if (txtAmtPaid.Text == "")
                    txtAmtPaid.Text = "0";

                double balance = Convert.ToDouble(Convert.ToDouble(lblBillServiceCharges.Text) - (Convert.ToDouble(lblDiscAmt.Text) + Convert.ToDouble(lblAdvanceAmt.Text)));

                txtBalance.Text = Convert.ToString(Convert.ToDouble(balance) - (((Convert.ToDouble(balance) * Convert.ToDouble(txtDiscnt.Text)) / 100) + Convert.ToDouble(txtAmtPaid.Text) + Convert.ToDouble(InsuranceAmt)));



            
        }
    }
    
}