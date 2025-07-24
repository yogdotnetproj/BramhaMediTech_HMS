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

public partial class ReceiveInsurancePayment_ForOPD : BasePage
{
    BELOPDPatReg objBELOpdReg = new BELOPDPatReg();
    DALOpdReg objDALOpdReg = new DALOpdReg();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["RecAmt"] = "0";
            RdbPayment.SelectedValue = "Cheque";
            ddlreceipts.Visible = false;
            btnreport.Visible = false;
           // PaymentDetails.Visible = false;
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
        if (RdbPayment.SelectedValue == "Cheque")
        {
            PaymentDetails.Visible = true;
            ChequeDate.Visible = true;
        }
        else
        {
            ChequeDate.Visible = false;
        }
    }


    private void LoadReceipts()
    {

        DataTable dt = objDALOpdReg.GetInsurancePaymentReceiptNo_ForOPD(Convert.ToInt32(ViewState["InsuranceId"]), Convert.ToInt32(Session["FId"]), Convert.ToInt32(Session["BranchId"]));
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
        if (txtInsuranceid.Text.Trim() != "")
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
        objBELOpdReg = objDALOpdReg.GetInsurancePaymentDetails_ForOPD(Convert.ToInt32(ViewState["InsuranceId"]), Convert.ToInt32(Session["FId"]), Convert.ToInt32(Session["BranchId"]));
        txtPaid.Text = Convert.ToString(objBELOpdReg.PaidAmt);
        txtInsuranceAmount.Text = Convert.ToString(objBELOpdReg.InsuranceAmount);
        txtBalance.Text = Convert.ToString(objBELOpdReg.BalanceAmt);
        GVPAtientInvoice.DataSource = objDALOpdReg.Get_InvoiceGeneratePatients(Convert.ToInt32(ViewState["InsuranceId"]));
        
        GVPAtientInvoice.DataBind();
        float Charges = 0;
        for (int i = 0; i < GVPAtientInvoice.Rows.Count; i++)
        {

            string txt_17 = (GVPAtientInvoice.Rows[i].Cells[05].Text);
            if (txt_17 != "")
            {
                Charges = Charges + Convert.ToSingle(txt_17);

            }
        }
        LblInsTotAmt.Text = "Total Insurance Amt is: "+Convert.ToString(Charges) ;
        //lblRecAmt.Text= Convert.ToString(Charges) ;
        lblRecAmt.Text = Convert.ToString(0);
    }
    
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (ViewState["InsuranceId"] != "0")
        {
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
                string username = Convert.ToString(Session["username"] );
                if ( Convert.ToInt32( ViewState["RecAmt"]) > 0)
                {
                    if (Convert.ToSingle(ViewState["RecAmt"]) == Convert.ToSingle(txtAmtGiven.Text))
                    {
                        string Message = objDALOpdReg.InsertInsurancePaymentTransaction_ForOPD(InsuranceId, TransactionType, PaymentMode, BankName, ChequeDate, chequeNo, AmountGiven, FId, BranchId, Convert.ToString(Session["username"]));
                       // lblMessage.Text = Message;
                        ViewState["RecAmt"] = "0";
                        for (int i = 0; i < GVPAtientInvoice.Rows.Count; i++)
                        {
                            int PartialPayRec = 0;
                            CheckBox ChkGen = (GVPAtientInvoice.Rows[i].FindControl("ChkGenInv") as CheckBox);
                            if (ChkGen.Checked == true)
                            {
                                float BillAmountT = Convert.ToSingle(GVPAtientInvoice.Rows[i].Cells[5].Text);
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
                                 ViewState["ReceiptNo"] = Convert.ToInt32(Message);
                                 string Message1 = objDALOpdReg.Update_InsurancePayment_Status(InsuranceId, ChargeNo, Patregid, Convert.ToInt32(Message), PartialPayRec, BillAmountT, Convert.ToString(Session["username"]));
                                 ViewState["RecAmt"] = "0";
                            }
                        }
                       // btnSave.Enabled = false;
                        GetInsurancePaymentDetails();
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


                        objreports.InsurancePaymentReceipts_ForOPD(ReceiptNo, Sponser, FId, BranchId);

                        Session.Add("rptsql", sql);
                        Session["rptname"] = Server.MapPath("~/Reports/Rpt_InsurancePaymentReceipt_ForOPD.rpt");
                        Session["reportname"] = "InsurancePaymentReceipt_ForOPD";
                        Session["RPTFORMAT"] = "pdf";


                        string close = "<script language='javascript'>javascript:OpenReport();</script>";
                        Type title1 = this.GetType();
                        Page.ClientScript.RegisterStartupScript(title1, "", close);

                    }
                    else
                    {
                        Label1.Text = "Amount given and selected amt not match";
                    }
                }
                else
                {
                    Label1.Text = "Pls select Patient List !";
                }
              
                //LoadReceipts();
                txtAmtGiven.Text = "0";
            }
            else
            {
                Label1.Text = "Enter amount Given!";
                txtAmtGiven.Focus();
                txtAmtGiven.BorderColor = System.Drawing.Color.Red;

            }
        }

    }
    protected void btnreport_Click(object sender, EventArgs e)
    {   
        BLLReports objreports = new BLLReports();
        string sql = "";
        int FId = Convert.ToInt32(Session["FId"]);
        int BranchId = Convert.ToInt32(Session["BranchId"]);
        //int ReceiptNo = 0;
        
         int  ReceiptNo = Convert.ToInt32(ddlreceipts.SelectedValue);
        
       
        int Sponser = Convert.ToInt32(ViewState["InsuranceId"]);


        objreports.InsurancePaymentReceipts_ForOPD(ReceiptNo, Sponser, FId, BranchId);

            Session.Add("rptsql", sql);
            Session["rptname"] = Server.MapPath("~/Reports/Rpt_InsurancePaymentReceipt_ForOPD.rpt");
            Session["reportname"] = "InsurancePaymentReceipt_ForOPD";
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
            ViewState["ReceiptNo"] = "0";
        }
        else
        {
            ddlreceipts.Visible = false;
            btnreport.Visible = false;
        }
    }
    protected void GVPAtientInvoice_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex == -1)
            return;

      //  float GenerateInvoice = Convert.ToSingle((e.Row.FindControl("hdnInsuranceamt") as HiddenField).Value);
       
    }
    protected void ChkGenInv_CheckedChanged(object sender, EventArgs e)
    {
        float BillAmount=0;
        for (int i = 0; i < GVPAtientInvoice.Rows.Count; i++)
        {
             CheckBox ChkGen = (GVPAtientInvoice.Rows[i].FindControl("ChkGenInv") as CheckBox);
             if (ChkGen.Checked == true)
             {
                 string ChargeNo = Convert.ToString(GVPAtientInvoice.Rows[i].Cells[4].Text);
               float BillAmountT = Convert.ToSingle(GVPAtientInvoice.Rows[i].Cells[5].Text);
               TextBox txtrecAmt = (GVPAtientInvoice.Rows[i].FindControl("txtrecamt") as TextBox);
               if (txtrecAmt.Text != "")
               {
                   if (txtrecAmt.Text != "0")
                   {
                       if (Convert.ToSingle(txtrecAmt.Text)<BillAmountT)
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
        lblRecAmt.Text = Convert.ToString(  BillAmount );
        ViewState["RecAmt"] = Convert.ToString(BillAmount);
    }
    protected void txtrecamt_TextChanged(object sender, EventArgs e)
    {
        float BillAmount = 0;
        for (int i = 0; i < GVPAtientInvoice.Rows.Count; i++)
        {
            CheckBox ChkGen = (GVPAtientInvoice.Rows[i].FindControl("ChkGenInv") as CheckBox);
            if (ChkGen.Checked == true)
            {
                string ChargeNo = Convert.ToString(GVPAtientInvoice.Rows[i].Cells[4].Text);
                float BillAmountT = Convert.ToSingle(GVPAtientInvoice.Rows[i].Cells[5].Text);
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
        lblRecAmt.Text = Convert.ToString(BillAmount);
        ViewState["RecAmt"] = Convert.ToString(BillAmount);
    }
    protected void btnCalc_Click(object sender, EventArgs e)
    {

        float BillAmount = 0;
        for (int i = 0; i < GVPAtientInvoice.Rows.Count; i++)
        {
            CheckBox ChkGen = (GVPAtientInvoice.Rows[i].FindControl("ChkGenInv") as CheckBox);
            if (ChkGen.Checked == true)
            {
                string ChargeNo = Convert.ToString(GVPAtientInvoice.Rows[i].Cells[4].Text);
                float BillAmountT = Convert.ToSingle(GVPAtientInvoice.Rows[i].Cells[5].Text);
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
        lblRecAmt.Text = Convert.ToString(BillAmount);
        ViewState["RecAmt"] = Convert.ToString(BillAmount);
    }
    protected void ChkAll_CheckedChanged(object sender, EventArgs e)
    {
        if (ChkAll.Checked == true)
        {
            for (int i = 0; i < GVPAtientInvoice.Rows.Count; i++)
            {
                CheckBox ChkGen = (GVPAtientInvoice.Rows[i].FindControl("ChkGenInv") as CheckBox);
                ChkGen.Checked = true;
                lblRecAmt.Text = "0";
                ViewState["RecAmt"] = "0";
            }
        }
        else
        {
            for (int i = 0; i < GVPAtientInvoice.Rows.Count; i++)
            {
                CheckBox ChkGen = (GVPAtientInvoice.Rows[i].FindControl("ChkGenInv") as CheckBox);
                ChkGen.Checked = false;
                lblRecAmt.Text = "0";
                ViewState["RecAmt"] = "0";
            }
        }
    }
    protected void btnreportAll_Click(object sender, EventArgs e)
    {
        BLLReports objreports = new BLLReports();
        string sql = "";
        int FId = Convert.ToInt32(Session["FId"]);
        int BranchId = Convert.ToInt32(Session["BranchId"]);
        //int ReceiptNo = 0;

        int ReceiptNo = Convert.ToInt32(0);


        int Sponser = Convert.ToInt32(0);


        objreports.InsurancePaymentReceipts_ForOPD_All(ReceiptNo, Sponser, FId, BranchId);

        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Reports/Rpt_InsurancePaymentReceipt_ForOPD.rpt");
        Session["reportname"] = "InsurancePaymentReceipt_ForOPD";
        Session["RPTFORMAT"] = "pdf";


        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);




    }
}