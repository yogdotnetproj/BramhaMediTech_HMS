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

public partial class MRC_Patientsuspend : BasePage
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
          //  LoadRdbPaymentType();
           
           // LoadConsultantDoc();
            ViewState["ReceiptNo"] = "0";
          
            if (Request.QueryString["RegId"] != "" && Request.QueryString["IpdId"] != "")
            {

                int RegId = Convert.ToInt32(Request.QueryString["RegId"]);
                int IpdId = Convert.ToInt32(Request.QueryString["IpdId"]);
                FillIpdPatInfo(RegId, IpdId);
              //  GetDepositAmount();
              //  Get_SurgeryDepositAmt();
                
            }
            if (Convert.ToString(Request.QueryString["resume"]) == "yes")
            {
                lblPatType.Text = "Suspend Remark";
                btnsave.Text = "Suspend";
                btnsave.BackColor = System.Drawing.Color.Red;
               
            }
            if (Convert.ToString(Request.QueryString["resume"]) == "No")
            {
                lblPatType.Text = "Resume Remark";
                btnsave.Text = "Resume";
                btnsave.BackColor = System.Drawing.Color.Green;


            }
            
        }
    }
    public void GetDepositAmount()
    {
        decimal DepositAmt = objDALOpdPatReg.GetDepositAmount(Convert.ToInt32(Request.QueryString["RegId"]), Convert.ToInt32(Session["FId"]), Convert.ToInt32(Session["BranchId"]));
        ViewState["DepositAmt"] = DepositAmt;
       // lblDepositAmt.Text = "(Deposit Amount=" + Convert.ToString(DepositAmt) + ")";
                    
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
      //  FillPage(Convert.ToInt32(lblRegNo.Text),Convert.ToInt32(Session["FId"]),Convert.ToInt32(lblIPDNo.Text),Convert.ToInt32(lblIPDNo.Text));
       
        
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
       // if (txtAmtPaid.Text != "0")
       // {
            InsertInBill();
           
        //}
        //else
        //{
        //   // lblerrormsg.Text = "Advance amt is zero";
        //    return;
        //}
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
                ViewState["ReceiptNo"] = "0";
            }
            dsCustomers = objBLLReports.GetIPDBillDetails(Convert.ToInt32(lblIPDNo.Text), Convert.ToInt32(ViewState["ReceiptNo"]), Convert.ToInt32(lblIPDNo.Text), Convert.ToInt32(lblRegNo.Text), Convert.ToInt32(Session["FId"]), Convert.ToInt32(Session["BranchId"]));
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
      
        objBELBillInfo.PatRegId = Convert.ToInt32(lblRegNo.Text);
        objBELBillInfo.BillDate = System.DateTime.Now;
        objBELBillInfo.IpdNo = Convert.ToInt32(lblIPDNo.Text);
        objBELBillInfo.BillNo = Convert.ToInt32(lblIPDNo.Text);
        objBELBillInfo.ConsultantDrId = Convert.ToInt32(0);
        objBELBillInfo.Remark = txtremark.Text; ;
        
       

        objBELBillInfo.CreatedBy = Convert.ToString(Session["username"]);
       
        
        objBELBillInfo.CreatedBy = Convert.ToString(Session["username"]);
        objBELBillInfo.BranchId = Convert.ToInt32(Session["Branchid"]);
        objBELBillInfo.FId = Convert.ToInt32(Session["FId"]);
        int ISSuspend = 0;
        if (Convert.ToString(Request.QueryString["resume"]) == "yes")
        {
            ISSuspend = 1;
        }
        else
        {
            ISSuspend = 0;
        }
       // returns = objDALBillInfo.InsertIPDBillTransaction(objBELBillInfo);
        objDALBillInfo.MRC_PatientSuspend(Convert.ToInt32(lblRegNo.Text), Convert.ToInt32(lblIPDNo.Text), Convert.ToString(Session["username"]), txtremark.Text, ISSuspend);

       // ViewState["BillPaymentId"] = Convert.ToInt32(returns[0]);
        lblMessage.Text = "Record Saved Successfully";
        Clear();
    }
    public void Clear()
    {
       

    }

    public void UpdateDepositMaster()
    {
        objBELBillInfo.PatRegId = Convert.ToInt32(lblRegNo.Text);
        objBELBillInfo.DepositAmount = -(Convert.ToDecimal(0));
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
        objBELBillInfo.ReceiptNew = Convert.ToInt32(0);
        //ViewState["ReceiptNo"] = objBELBillInfo.ReceiptNew;
        objBELBillInfo.PatRegId = Convert.ToInt32(lblRegNo.Text);
        objBELBillInfo.BillDate = System.DateTime.Now;
        objBELBillInfo.IpdNo = Convert.ToInt32(lblIPDNo.Text);
        objBELBillInfo.BillNo = Convert.ToInt32(lblIPDNo.Text);
        objBELBillInfo.Remark = "";
        objBELBillInfo.CreatedBy = Convert.ToString(Session["username"]);
        objBELBillInfo.ReceiptNo = Convert.ToInt32(0);


        // objBELBillInfo.CreatedBy = Convert.ToString(Session["username"]);
        objBELBillInfo.BranchId = Convert.ToInt32(Session["Branchid"]);
        objBELBillInfo.FId = Convert.ToInt32(Session["FId"]);

        returns = objDALBillInfo.InsertIPD_CancelReceiptTransaction(objBELBillInfo);
       // FillGrid(Convert.ToInt32(lblRegNo.Text), Convert.ToInt32(Session["FId"]), Convert.ToInt32(lblIPDNo.Text), Convert.ToInt32(lblIPDNo.Text));
        //ViewState["BillPaymentId"] = Convert.ToInt32(returns[0]);
        lblMessage.Text = "cancel receipt Saved Successfully";
        Clear();
    }
}