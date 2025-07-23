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
public partial class CashPayment_Voucher : BaseClass
{
    BELDepartment objBELDept = new BELDepartment();
    DALDepartment objDALDept = new DALDepartment();
    double Billtotal = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillDepartmentGrid();
            ViewState["Edit"] = "";
           // show.Visible = false;
           // List.Visible = true;
            MakeBillTable();
            DataTable dt = (DataTable)ViewState["BillTable"];
            gvBill.DataSource = dt;
            gvBill.DataBind();
        }
    }
    private void MakeBillTable()
    {
        DataTable dt = new DataTable();
        dt.Clear();

        dt.Columns.Add("AccHead");
        dt.Columns.Add("AccCode");
        dt.Columns.Add("Amount");
       



        ViewState["BillTable"] = dt;
    }
    private void AddToGridView()
    {
        DataTable dt = (DataTable)ViewState["BillTable"];

        //if (validationPatient() == true)
        //{
            if (ViewState["Edit"].ToString() != "")
            {
                int index = Convert.ToInt32(ViewState["Index"]);
                dt.Rows[index]["AccHead"] = txtAccountHead.Text;
                dt.Rows[index]["AccCode"] = ViewState["AccountCode"];
                dt.Rows[index]["Amount"] = txtAmount.Text;
               
                //if (validationService() == true)
                //{
                //    dt.Rows[index]["BillServiceId"] = Convert.ToInt32(ViewState["ServiceId"]);
                //}
                //else
                //{
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + ViewState["Msg"] + "');", true);
                //    return;

                //}

               
            }
            else
            {

                DataRow dr = dt.NewRow();


                dr["AccHead"] = txtAccountHead.Text;

                dr["AccCode"] = ViewState["AccountCode"]; 
                dr["Amount"] = txtAmount.Text;
                
                dt.Rows.Add(dr);
            }
            ViewState["BillTable"] = dt;

            gvBill.DataSource = dt;
            gvBill.DataBind();
           // Clear();
        //}
        //else
        //{
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + ViewState["Msg"] + "');", true);
        //    return;
        //}

    }
    protected void FillDepartmentGrid()
    {
      //  gvDepartment.DataSource = objDALDept.FillGrid_AccountHead();
      //  gvDepartment.DataBind();
    }

   
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtPayTo.Text == "")
        {
            txtPayTo.Focus();
            txtPayTo.BorderColor = System.Drawing.Color.Red;
            return;
        }
        if (txtParticular.Text == "")
        {
            txtParticular.Focus();
            txtParticular.BorderColor = System.Drawing.Color.Red;
            return;
        }
        if (txtvoucherNo.Text == "")
        {
            txtvoucherNo.Focus();
            txtvoucherNo.BorderColor = System.Drawing.Color.Red;
            return;
        }
       
        
        string Message = "";
        if (gvBill.Rows.Count > 0)
        {
            DataTable dt = (DataTable)ViewState["BillTable"];
            objBELDept.CreatedBy = Convert.ToString(Session["username"]);
            objBELDept.ParticularName = Convert.ToString(txtParticular.Text);
            objBELDept.PayTo = Convert.ToString(ViewState["PayTo"]);
            objBELDept.ModeofPayment = Convert.ToInt32(rblPaytype.SelectedValue);
            objBELDept.VoucherNo = Convert.ToString(txtvoucherNo.Text);
            // objBELDept.PayTo = Convert.ToString(txtPayTo.Text);
            int Cash_VoucherNo = objDALDept.Get_CashVoucherNo(objBELDept);
            for (int i = 0; i < dt.Rows.Count; i++)
            {


                objBELDept.AccCode = Convert.ToString(dt.Rows[i]["AccCode"]);
                objBELDept.AccHead = Convert.ToString(dt.Rows[i]["AccHead"]);
                objBELDept.Amount = Convert.ToSingle(dt.Rows[i]["Amount"]);
                objBELDept.CreatedBy = Convert.ToString(Session["username"]);
                objBELDept.Cash_VoucherNo = Cash_VoucherNo;

                Message = objDALDept.Insert_CashPaymentVoucher_Details(objBELDept);
            }


            txtParticular.Text = "";
            txtPayTo.Text = "";
            txtvoucherNo.Text = "";
            DynamicMessage(lblMessage, " Record save successfully!");

            MakeBillTable();
            DataTable dt1 = (DataTable)ViewState["BillTable"];
            gvBill.DataSource = dt1;
            gvBill.DataBind();


            BLLReports objreports = new BLLReports();
            string sql = "";
            int FId = Convert.ToInt32(Session["FId"]);
            int BranchId = Convert.ToInt32(Session["BranchId"]);
            //int ReceiptNo = 0;

            // int ReceiptNo = Convert.ToInt32(ddlreceipts.SelectedValue);


            int Sponser = Convert.ToInt32(ViewState["PayTo"]);


            objreports.CashVoucherAllPaymentReceipts_Report1( Sponser, "0", BranchId, Cash_VoucherNo);

            Session.Add("rptsql", sql);
            Session["rptname"] = Server.MapPath("~/Reports/Rpt_CashVoucher_PaymentReceipt.rpt");
            Session["reportname"] = "CashVoucher_PaymentReceipt";
            Session["RPTFORMAT"] = "pdf";


            string close = "<script language='javascript'>javascript:OpenReport();</script>";
            Type title1 = this.GetType();
            Page.ClientScript.RegisterStartupScript(title1, "", close);
        }
    }
    protected void btnaddnew_Click(object sender, EventArgs e)
    {
        //show.Visible = true;
        //List.Visible = false;
      //  lblMessage.Text = "";
    }

    
    protected void btnReset_Click(object sender, EventArgs e)
    {
       

    }
    private void clearall()
    {
        //txtDepartmentName.Text = "";
        ViewState["DepartmentID"] = 0;
        txtAccountHead.Text = "";
        txtAmount.Text = "";
        
    }
    
    protected void FillPage()
    {
        try
        {
          ;
            
        }
        catch (Exception ex)
        {
          //  lblMessage.Text = ex.Message;
        }
    }

    
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        try
        {
            BLLReports objBLLReports = new BLLReports();
            DataSet dsCustomers = new DataSet();
            ReportDocument crystalReport = new ReportDocument();
            crystalReport.Load(Server.MapPath("~/Report/RptSubDepartment.rpt"));
            //dsCustomers = objBLLReports.GetSubDepartment();
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



    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (txtAccountHead.Text == "")
        {
            txtAccountHead.Focus();
            txtAccountHead.BorderColor = System.Drawing.Color.Red;
            return;
        }
        if (txtAmount.Text == "")
        {
            txtAmount.Focus();
            txtAmount.BorderColor = System.Drawing.Color.Red;
            return;
        }
        if (txtAmount.Text == "0")
        {
            txtAmount.Focus();
            txtAmount.BorderColor = System.Drawing.Color.Red;
            return;
        }
        AddToGridView();
        txtAmount.Text = "";
        txtAccountHead.Text = "";
    }
    protected void gvBill_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvBill.PageIndex = e.NewPageIndex;
        AddToGridView();
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
        string Message = "1Record Deleted Sucessfully";
        DynamicMessage(lblMessage, Message);
    }
    protected void gvBill_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int index = Convert.ToInt32(e.NewEditIndex);
        DataTable dt = ViewState["BillTable"] as DataTable;

        txtAccountHead.Text = dt.Rows[index]["AccHead"].ToString();
        ViewState["AccountCode"] = dt.Rows[index]["AccCode"].ToString();
        txtAmount.Text = dt.Rows[index]["Amount"].ToString();
      

        ViewState["Index"] = index;
        ViewState["Edit"] = "1";
        ViewState["BillTable"] = dt;
        e.Cancel = true;
    }
    protected void gvBill_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void gvBill_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Billtotal += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Amount"));
            ViewState["Total"] = Billtotal;
            //DiscountToatl += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "DiscountGiven"));
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {

            e.Row.Cells[2].Text = "Total";
            e.Row.Cells[2].Font.Bold = true;
            //e.Row.Cells[8].HorizontalAlign.Equals("Right");
            e.Row.Cells[3].Text = Billtotal.ToString();
            e.Row.Cells[3].Font.Bold = true;
        }
    }

    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchConsultDoc(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        return objDALOpdReg.VoucherPayment_PayTo(prefixText);
    }

    [ScriptMethod()]
    [WebMethod]
    public static List<string> Search_AccountHead(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        return objDALOpdReg.Voucher_AccountHead(prefixText);
    }
   
    protected void txtAccountHead_TextChanged(object sender, EventArgs e)
    {
        if (txtAccountHead.Text != "")
        {
            string[] PatientInfo = txtAccountHead.Text.Split('-');
            if (PatientInfo.Length > 1)
            {
                txtAccountHead.Text = PatientInfo[1];
                ViewState["AccountCode"] = PatientInfo[0];
            }
            else
            {
                ViewState["AccountCode"] = "";

            }
        }
    }
    protected void txtPayTo_TextChanged(object sender, EventArgs e)
    {
        if (txtPayTo.Text != "")
        {
            string[] PatientInfo = txtPayTo.Text.Split('-');
            if (PatientInfo.Length > 1)
            {
                txtPayTo.Text = PatientInfo[1];
                ViewState["PayTo"] = PatientInfo[0];
            }
            else
            {
                ViewState["PayTo"] = "";

            }
        }
    }
}