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

public partial class ReceiveInsurancePayment : System.Web.UI.Page
{
    BELOPDPatReg objBELOpdReg = new BELOPDPatReg();
    DALOpdReg objDALOpdReg = new DALOpdReg();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            RdbPayment.SelectedValue = "Cheque";
            ddlreceipts.Visible = false;
            btnreport.Visible = false;
            //PaymentDetails.Visible = false;
           // ChequeDate.Visible = false;
        }
    }
    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchInsurance(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        return objDALOpdReg.FillAllInsurance(prefixText);
    }
    protected void RdbPayment_SelectedIndexChanged(object sender, EventArgs e)
    {
      
            PaymentDetails.Visible = true;
            ChequeDate.Visible = true;

    }


    private void LoadReceipts()
    {

        DataTable dt = objDALOpdReg.GetInsurancePaymentReceiptNo(Convert.ToInt32(ViewState["InsuranceId"]), Convert.ToInt32(Session["FId"]), Convert.ToInt32(Session["BranchId"]));
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
    //private void LoadRdbPaymentType()
    //{

    //    RdbPayment.DataSource = objDALBillInfo.FillModeOfPayment();
    //    RdbPayment.DataValueField = "ModeOfPaymentId";
    //    RdbPayment.DataTextField = "ModeOfPaymentName";
    //    RdbPayment.DataBind();


    //}
   
   
    protected void txtInsuranceid_TextChanged(object sender, EventArgs e)
    {
        if (txtInsuranceid.Text != "")
        {
            string[] InsuranceId = txtInsuranceid.Text.Split('-');
            txtInsuranceid.Text = InsuranceId[1];

            if (txtInsuranceid.Text != "")
            {
                ViewState["InsuranceId"] = InsuranceId[0];
            }
            else
            {
                ViewState["InsuranceId"] = 0;
            }
            GetInsurancePaymentDetails();
            LoadReceipts();

        }
        else
        {
            ViewState["InsuranceId"] = 0;
        }

       
    }
    public void GetInsurancePaymentDetails()
    {
        objBELOpdReg = objDALOpdReg.GetInsurancePaymentDetails(Convert.ToInt32(ViewState["InsuranceId"]), Convert.ToInt32(Session["FId"]), Convert.ToInt32(Session["BranchId"]));
        txtPaid.Text = Convert.ToString(objBELOpdReg.PaidAmt);
        txtInsuranceAmount.Text = Convert.ToString(objBELOpdReg.InsuranceAmount);
        txtBalance.Text = Convert.ToString(objBELOpdReg.BalanceAmt);
        GVPAtientInvoice.DataSource = objDALOpdReg.Get_InvoiceGeneratePatients_ForIPD(Convert.ToInt32(ViewState["InsuranceId"]));

        GVPAtientInvoice.DataBind();
        float Charges = 0;
        for (int i = 0; i < GVPAtientInvoice.Rows.Count; i++)
        {

            string txt_17 = (GVPAtientInvoice.Rows[i].Cells[4].Text);
            if (txt_17 != "")
            {
                Charges = Charges + Convert.ToSingle(txt_17);

            }
        }
        LblInsTotAmt.Text = "Total Insurance Amt is: " + Charges.ToString("F0");// Convert.ToString(Charges);
        //lblRecAmt.Text= Convert.ToString(Charges) ;
        lblRecAmt.Text = Convert.ToString(0);
    }
    
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (ViewState["InsuranceId"] != "0")
        {
            //int InsuranceId = Convert.ToInt32(ViewState["InsuranceId"]);
            //string TransactionType = "Credit";
            //string PaymentMode = RdbPayment.SelectedValue;
            //string BankName = txtBankName.Text;
            //string ChequeDate = txtchequedate.Value;
            //string chequeNo = txtNumber.Text;
            //float AmountGiven = Convert.ToSingle(txtAmtGiven.Text);
            //int FId= Convert.ToInt32(Session["FId"]);
            //int BranchId=Convert.ToInt32(Session["BranchId"]);
            //string username = Convert.ToString(Session["username"]);
           // string Message=objDALOpdReg.InsertInsurancePaymentTransaction(InsuranceId, TransactionType, PaymentMode,BankName,ChequeDate,chequeNo, AmountGiven, FId, BranchId,username);
            //lblMessage.Text = Message;

            //GetInsurancePaymentDetails();
            //LoadReceipts();
            //txtAmtGiven.Text = "0";

            int InsuranceId = Convert.ToInt32(ViewState["InsuranceId"]);
            string TransactionType = "Credit";
            string PaymentMode = RdbPayment.SelectedValue;
            string BankName = txtBankName.Text;
            string ChequeDate = txtchequedate.Text;
            string chequeNo = txtNumber.Text;
            if (txtNumber.Text == "")
            {
                txtNumber.Focus();
                txtNumber.BorderColor = System.Drawing.Color.Red;
                return;
            }
            float AmountGiven = Convert.ToSingle(txtAmtGiven.Text);
            if (Convert.ToSingle(txtAmtGiven.Text) > 0)
            {
                int FId = Convert.ToInt32(Session["FId"]);
                int BranchId = Convert.ToInt32(Session["BranchId"]);
                string username = Convert.ToString(Session["username"]);
                if (Convert.ToSingle(ViewState["RecAmt"]) > 0)
                {
                    if (Convert.ToSingle(ViewState["RecAmt"]) == Convert.ToSingle(txtAmtGiven.Text))
                    {
                        string Message = objDALOpdReg.InsertInsurancePaymentTransaction(InsuranceId, TransactionType, PaymentMode, BankName, ChequeDate, chequeNo, AmountGiven, FId, BranchId, username);
                        // lblMessage.Text = Message;
                        ViewState["RecAmt"] = "0";
                        for (int i = 0; i < GVPAtientInvoice.Rows.Count; i++)
                        {
                            int PartialPayRec = 0;
                            CheckBox ChkGen = (GVPAtientInvoice.Rows[i].FindControl("ChkGenInv") as CheckBox);
                            if (ChkGen.Checked == true)
                            {
                                HiddenField HdnIpdNo = (GVPAtientInvoice.Rows[i].FindControl("HdnIpdNo") as HiddenField);
                                float BillAmountT = Convert.ToSingle(GVPAtientInvoice.Rows[i].Cells[4].Text);
                                TextBox txtrecAmt = (GVPAtientInvoice.Rows[i].FindControl("txtrecamt") as TextBox);
                                if (txtrecAmt.Text != "")
                                {
                                    if (txtrecAmt.Text != "0")
                                    {
                                        if (Convert.ToSingle(txtrecAmt.Text) < BillAmountT)
                                        {
                                            BillAmountT = Convert.ToSingle(txtrecAmt.Text);
                                            PartialPayRec = 2;
                                        }
                                        else
                                        {
                                            return;
                                        }
                                    }
                                }
                                else
                                {
                                    PartialPayRec = 1;
                                }
                                string ChargeNo = Convert.ToString(GVPAtientInvoice.Rows[i].Cells[4].Text);
                                int Patregid = Convert.ToInt32(GVPAtientInvoice.Rows[i].Cells[2].Text);
                                int IPDNo = Convert.ToInt32( HdnIpdNo.Value);
                                ViewState["ReceiptNo"] = Convert.ToInt32(Message);
                                string Message1 = objDALOpdReg.Update_InsurancePayment_Status_IPD(InsuranceId, ChargeNo, Patregid, Convert.ToInt32(Message), PartialPayRec, BillAmountT, Convert.ToString(Session["username"]), IPDNo);
                                ViewState["RecAmt"] = "0";
                            }
                        }
                        GetInsurancePaymentDetails();
                        Label1.Text = "Payment receive successfully!";
                        txtAmtGiven.Text = "0";
                        txtNumber.Text = "";
                        BLLReports objreports = new BLLReports();
                        string sql = "";
                        // int FId = Convert.ToInt32(Session["FId"]);
                        //int BranchId = Convert.ToInt32(Session["BranchId"]);
                        int ReceiptNo = 0;
                        if (Convert.ToInt32(ViewState["ReceiptNo"]) > 0)
                        {
                            ReceiptNo = Convert.ToInt32(ViewState["ReceiptNo"]);
                        }
                        else
                        {
                            ReceiptNo = Convert.ToInt32(ddlreceipts.SelectedValue);
                        }

                        int Sponser = Convert.ToInt32(ViewState["InsuranceId"]);


                        objreports.InsurancePaymentReceipts_For_IPD(ReceiptNo, Sponser, FId, BranchId);

                        Session.Add("rptsql", sql);
                        Session["rptname"] = Server.MapPath("~/Reports/Rpt_InsurancePaymentReceipt_ForOPD.rpt");
                        Session["reportname"] = "InsurancePaymentReceipt_ForOPD";
                        Session["RPTFORMAT"] = "pdf";


                        string close = "<script language='javascript'>javascript:OpenReport();</script>";
                        Type title1 = this.GetType();
                        Page.ClientScript.RegisterStartupScript(title1, "", close);

                    }
                   
                }
            }
        }

    }
    protected void btnreport_Click(object sender, EventArgs e)
    {   
        BLLReports objreports = new BLLReports();
        string sql = "";
        int FId = Convert.ToInt32(Session["FId"]);
        int BranchId = Convert.ToInt32(Session["BranchId"]);
        int ReceiptNo = Convert.ToInt32(ddlreceipts.SelectedValue);
        int Sponser = Convert.ToInt32(ViewState["InsuranceId"]);

        objreports.InsurancePaymentReceipts_For_IPD(ReceiptNo, Sponser, FId, BranchId);
      //  objreports.InsurancePaymentReceipts(ReceiptNo, Sponser, FId, BranchId);

            Session.Add("rptsql", sql);
            Session["rptname"] = Server.MapPath("~/Reports/Rpt_InsurancePaymentReceipt_ForOPD.rpt");
            Session["reportname"] = "InsurancePaymentReceipt_ForOPD";
            //Session["rptname"] = Server.MapPath("~/Reports/Rpt_InsurancePaymentReceipt.rpt");
            //Session["reportname"] = "InsurancePaymentReceipt";
            Session["RPTFORMAT"] = "pdf";


            string close = "<script language='javascript'>javascript:OpenReport();</script>";
            Type title1 = this.GetType();
            Page.ClientScript.RegisterStartupScript(title1, "", close);


        

    }
    protected void ChkReceipt_CheckedChanged(object sender, EventArgs e)
    {
        if (ChkReceipt.Checked == true)
        {
            ddlreceipts.Visible = true;
            btnreport.Visible = true;

        }
        else
        {
            ddlreceipts.Visible = false;
            btnreport.Visible = false;
        }
    }
    protected void GVPAtientInvoice_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void btnCalc_Click(object sender, EventArgs e)
    {

        float BillAmount = 0;
        for (int i = 0; i < GVPAtientInvoice.Rows.Count; i++)
        {
            CheckBox ChkGen = (GVPAtientInvoice.Rows[i].FindControl("ChkGenInv") as CheckBox);
            if (ChkGen.Checked == true)
            {
                //string ChargeNo = Convert.ToString(GVPAtientInvoice.Rows[i].Cells[4].Text);
                float BillAmountT = Convert.ToSingle(GVPAtientInvoice.Rows[i].Cells[4].Text);
                TextBox txtrecAmt = (GVPAtientInvoice.Rows[i].FindControl("txtrecamt") as TextBox);
                if (txtrecAmt.Text != "")
                {
                    if (txtrecAmt.Text != "0")
                    {
                        if (Convert.ToSingle(txtrecAmt.Text) < BillAmountT)
                        {
                            BillAmountT = Convert.ToSingle(txtrecAmt.Text);
                            Label1.Text = "";
                        }
                        else
                        {
                            BillAmountT = 0;
                            txtrecAmt.Text = "0";
                            Label1.Text = "Enter rec amt not greater than Insurance amt!";
                        }
                    }
                }
                // string txt_17 = (GV_Billdesk.Rows[i].Cells[13].Text);
                if (BillAmountT > 0)
                {
                    BillAmount = BillAmount + Convert.ToSingle(BillAmountT);

                }
            }
        }
        lblRecAmt.Text = BillAmount.ToString("F0");//.ToString(BillAmount);
        ViewState["RecAmt"] = BillAmount.ToString("F0");
    }
}