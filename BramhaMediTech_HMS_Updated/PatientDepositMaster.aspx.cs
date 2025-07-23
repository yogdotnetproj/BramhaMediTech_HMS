using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PatientDepositMaster : System.Web.UI.Page
{
    BELBillInfo objBELBillInfo = new BELBillInfo();
    DALBillInfo objDALBillInfo = new DALBillInfo();
    BELPatientInformation objBELPatInfo = new BELPatientInformation();
    DALPatientInformation objDALPatInfo = new DALPatientInformation();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["PatientInfoId"] != "")
            {

                int PatientInfoId = Convert.ToInt32(Request.QueryString["PatientInfoId"]);

                FillPage(PatientInfoId);
                BindGrid();

                

            }
           
            LoadRdbPaymentType();
            RdbPayment.SelectedValue = "1";
           
            PaymentDetails.Visible = false;
           
        }

    }
    public void FillPage(int PatientInfoId)
    {
        objBELPatInfo = objDALPatInfo.SelectOne(PatientInfoId);
        lblPatientName.Text = objBELPatInfo.TitleName +' '+ objBELPatInfo.FirstName;
        lblGender.Text = objBELPatInfo.GenderName;
        lblMobileNo.Text = objBELPatInfo.MobileNo;
        lblAddress.Text = objBELPatInfo.PatientAddress;
        lblPatRegId.Text = objBELPatInfo.PatRegId;       
       
       
        string birthdate= Convert.ToString(objBELPatInfo.BirthDate);//12.10,2014
        if (birthdate != "")
        {
            birthdate = DateTime.Parse(birthdate).ToString("dd/MM/yyyy"); 
             int intYear, intMonth, intDays;
             DateTime Birthday = Convert.ToDateTime(birthdate);
             intYear = Birthday.Year;
             intMonth = Birthday.Month;
             intDays = Birthday.Day;

             DateTime dtt = Convert.ToDateTime(birthdate);

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
            lblAge.Text = intYear.ToString() + "Year";
           
        }
        else if (intMonth > 0)
        {
           
            lblAge.Text = intMonth.ToString() + "Month";
        }
        else if (intDays > 0)
        {
           
            lblAge.Text = intDays.ToString() + "Days";
        }
       
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
    protected void gvBill_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void gvBill_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
         string DepositId = ( gvBill.DataKeys[e.RowIndex]["DepositId"].ToString());
         objDALBillInfo.DeleteDeposite(Convert.ToInt32(DepositId));
         lblMessage.Text="Record Deleted Successfully";
         BindGrid();

        
    }
    protected void gvBill_RowEditing(object sender, GridViewEditEventArgs e)
    {
        string DepositId = (gvBill.DataKeys[e.NewEditIndex]["DepositId"].ToString());

        objBELBillInfo=objDALBillInfo.SelectDeposit(Convert.ToInt32(DepositId));
        txtDepositAmt.Text = Convert.ToString(objBELBillInfo.DepositAmount);
        txtRemark.Value = Convert.ToString(objBELBillInfo.Remark);
        ddlType.SelectedValue = Convert.ToString(objBELBillInfo.BillType);
        RdbPayment.SelectedValue = Convert.ToString(objBELBillInfo.PaymentId);
        RdbPayment_SelectedIndexChanged(null, null);
        txtbankName.SelectedItem.Text = Convert.ToString(objBELBillInfo.BankName);
        txtNumber.Text = Convert.ToString(objBELBillInfo.ChequeCardNo);
        txtchequedate.Value = Convert.ToString(objBELBillInfo.ChequeDate);
        ViewState["DepositIdEdit"] = Convert.ToInt32(DepositId);
        e.Cancel = true;


        

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
    protected void btnSave_Click(object sender, EventArgs e)
    {
       
       
        BELBillInfo objBELBillInfo = new BELBillInfo();
        if (Convert.ToInt32(ViewState["DepositIdEdit"]) > 0)
        {
            int DepositeId = Convert.ToInt32(ViewState["DepositIdEdit"]);
            objBELBillInfo.Remark = txtRemark.Value;

            objBELBillInfo.PaymentType = RdbPayment.SelectedValue;
            if (ddlType.SelectedValue != "0")
            {
                objBELBillInfo.BillType = ddlType.SelectedValue;

            }
            else
            {
                objBELBillInfo.BillType = "";
            }
            if (ddlType.SelectedValue == "Deposit")
            {
                objBELBillInfo.DepositAmount = Convert.ToDecimal(txtDepositAmt.Text);
            }
            else
            {
                objBELBillInfo.DepositAmount = -(Convert.ToDecimal(txtDepositAmt.Text));
            }


            objBELBillInfo.UpdatedBy = Convert.ToString(Session["username"]);
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


            if (txtchequedate.Value != "")
            {
                objBELBillInfo.ChequeDate = txtchequedate.Value.ToString();
            }

            objBELBillInfo.DepositId = DepositeId;

            objDALBillInfo.UpdateDepositTransaction(objBELBillInfo);
            ViewState["DepositeId"] = DepositeId;
            lblMessage.Text = "Record Updated Successfully";
            ViewState["DepositIdEdit"] = 0;
        }
        else
        {

            objBELBillInfo.PatRegId = Convert.ToInt32(lblPatRegId.Text);

            objBELBillInfo.Remark = txtRemark.Value;

            objBELBillInfo.PaymentType = RdbPayment.SelectedValue;
            if (ddlType.SelectedValue != "0")
            {
                objBELBillInfo.BillType = ddlType.SelectedValue;

            }
            else
            {
                objBELBillInfo.BillType = "";
            }
            if (ddlType.SelectedValue == "Deposit")
            {
                objBELBillInfo.DepositAmount = Convert.ToDecimal(txtDepositAmt.Text);
            }
            else
            {
                objBELBillInfo.DepositAmount = -(Convert.ToDecimal(txtDepositAmt.Text));
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


            if (txtchequedate.Value != "")
            {
                objBELBillInfo.ChequeDate = txtchequedate.Value.ToString();
            }

            objBELBillInfo.CreatedBy = Convert.ToString(Session["username"]);
            objBELBillInfo.BranchId = Convert.ToInt32(Session["Branchid"]);
            objBELBillInfo.FId = Convert.ToInt32(Session["FId"]);

            int DepositeId = objDALBillInfo.InsertDepositTransaction(objBELBillInfo);
            ViewState["DepositeId"] = DepositeId;
            lblMessage.Text = "Record Saved Successfully";
        }
            BindGrid();
            Clear();
        
    }
    public void Clear()
    {
        txtRemark.Value = "";
        txtDepositAmt.Text = "0";
        ddlType.SelectedValue = "0";
    }
    public void BindGrid()
    {
        gvBill.DataSource = objDALBillInfo.FillDepositGrid(Convert.ToInt32(lblPatRegId.Text), Convert.ToInt32(Session["FId"]), Convert.ToInt32(Session["Branchid"]));
        gvBill.DataBind();
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {

    }
    protected void btnReport_Click(object sender, EventArgs e)
    {
        string sql = "";
        if (ViewState["DepositeId"] != "")
        {
            BLLReports objreports = new BLLReports();
            int PatRegId = Convert.ToInt32(lblPatRegId.Text);
            int DepositId = Convert.ToInt32(ViewState["DepositeId"]);
            int FId = Convert.ToInt32(Session["FId"]);
            int BranchId = Convert.ToInt32(Session["Branchid"]);
            objreports.GetDepositReport(DepositId, PatRegId, FId, BranchId);

            Session.Add("rptsql", sql);
            Session["rptname"] = Server.MapPath("~/Reports/Rpt_DepositReport.rpt");
            Session["reportname"] = "Deposit_Report";
            Session["RPTFORMAT"] = "pdf";


            string close = "<script language='javascript'>javascript:OpenReport();</script>";
            Type title1 = this.GetType();
            Page.ClientScript.RegisterStartupScript(title1, "", close);
        }
        else
        {
            lblMessage.Text = "Please Save the Record first!!";
        }


    }
    protected void gvBill_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string sql = "";
        if (e.CommandName == "Select")
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvBill.Rows[rowIndex];
            BLLReports objreports = new BLLReports();
            int PatRegId = Convert.ToInt32(lblPatRegId.Text);
            int DepositId = Convert.ToInt32(gvBill.DataKeys[rowIndex].Values["DepositId"]);
           // int DepositId = Convert.ToInt32(ViewState["DepositeId"]);
            int FId = Convert.ToInt32(Session["FId"]);
            int BranchId = Convert.ToInt32(Session["Branchid"]);
            objreports.GetDepositReport(DepositId, PatRegId, FId, BranchId);

            Session.Add("rptsql", sql);
            Session["rptname"] = Server.MapPath("~/Reports/Rpt_DepositReport.rpt");
            Session["reportname"] = "Deposit_Report";
            Session["RPTFORMAT"] = "pdf";


            string close = "<script language='javascript'>javascript:OpenReport();</script>";
            Type title1 = this.GetType();
            Page.ClientScript.RegisterStartupScript(title1, "", close);
        }
    }
}