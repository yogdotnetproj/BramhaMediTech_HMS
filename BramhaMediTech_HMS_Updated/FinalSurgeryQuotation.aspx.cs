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

public partial class FinalSurgeryQuotation : System.Web.UI.Page
{
    clsEmr obj = new clsEmr();
    clsTreatment objTreat = new clsTreatment();
    clsTreatmentTransaction transaction = new clsTreatmentTransaction();
    DALBillDetails objDALBillDetail = new DALBillDetails();



    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if (Request.QueryString["SurgEstimationId"]!= "")
            {
               
                FindPatientInformation();

                GetFinalQuotation();



            }
            else
            {
                Response.Redirect(string.Format("ListPatients.aspx"));
            }
        }

    }
    public void FindPatientInformation()
    {
        DataTable dt = new DataTable();
        dt = obj.Get_AllPatientInformation_Quotation(Convert.ToInt32(Request.QueryString["SurgEstimationId"]));
        try
        {
            if (dt != null)
            {
                lblOperation.Text=Convert.ToString(dt.Rows[0]["OperationName"]);
                lblPatientName.Text = Convert.ToString(dt.Rows[0]["PatientName"]);
                lblAddress.Text = Convert.ToString(dt.Rows[0]["PatientAddress"]);
                lblMobileNo.Text = Convert.ToString(dt.Rows[0]["MobileNo"]);
                lblDate.Text = Convert.ToString(dt.Rows[0]["CreatedOn"]);
                txtSurgeonName.Text = Convert.ToString(dt.Rows[0]["SurgeonName"]);
                ViewState["SurgeonID"] = Convert.ToInt32(dt.Rows[0]["Surgeon"]);
                ViewState["PatRegId"] = Convert.ToInt32(dt.Rows[0]["Patregid"]);
                ViewState["OPDNo"] = Convert.ToInt32(dt.Rows[0]["OPDNO"]);
                ViewState["IPDNo"] = Convert.ToInt32(dt.Rows[0]["IPDNO"]);
                ViewState["ConsultantDr"] = Convert.ToInt32(dt.Rows[0]["ConsultantDrId"]);
                ViewState["OperationId"] = Convert.ToInt32(dt.Rows[0]["Operation"]);
           }
           
        }
        catch (Exception ex)
        {

        }
    }
    public void GetFinalQuotation()
    {
        DataTable dt = new DataTable();
        dt = obj.GetFinalQuotation(Convert.ToInt32(Request.QueryString["SurgEstimationId"]));
        try
        {
            if (dt != null)
            {
                txtSurgeonFee.Text = Convert.ToString(dt.Rows[0]["SurgeonFee"]);
                txtInvestigations.Text = Convert.ToString(dt.Rows[0]["InvestigationFees"]);
                txtMedicineCharges.Text = Convert.ToString(dt.Rows[0]["MedicineFees"]);
                txttheatreFee.Text = Convert.ToString(dt.Rows[0]["TheatreFees"]);
                txtWardCharges.Text = Convert.ToString(dt.Rows[0]["WardCharges"]);
                txtAnaestFee.Text = Convert.ToString(dt.Rows[0]["AnaesthetistFees"]);
                txtTotalCharges.Text = Convert.ToString(dt.Rows[0]["TotalCharges"]);
                
            }

        }
        catch (Exception ex)
        {

        }
    }


 

   
    protected void btnClear_Click(object sender, EventArgs e)
    {
        try
        {

            Clear();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {

    }




    private void Clear()
    {
        txtAnaestFee.Text = "";
        txtMedicineCharges.Text = "";
        txtSurgeonFee.Text = "";
        txttheatreFee.Text = "";
        txtWardCharges.Text = "";
        txtTotalCharges.Text = "";
        txtInvestigations.Text = "";
       

    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        btnClear_Click(null, null);
        Clear();

    }



    protected void btnReset_Click(object sender, EventArgs e)
    {
        Clear();

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        BELBillDetails objBELBillDetail = new BELBillDetails();
        string Message = "";

       
        objBELBillDetail.PatRegId = Convert.ToInt32(ViewState["PatRegId"]);
        objBELBillDetail.IpdNo = Convert.ToInt32(ViewState["IPDNo"]);
        objBELBillDetail.OpdNo = Convert.ToInt32(ViewState["OPDNo"]);
        objBELBillDetail.ConsultantDrId = Convert.ToInt32(ViewState["ConsultantDr"]);
        //objBELBillDetail.ConsultantDoc = Convert.ToString(lbldrname.Text);
        objBELBillDetail.SurgEstimationId=  Convert.ToInt32(Request.QueryString["SurgEstimationId"]);

        objBELBillDetail.Surgan = Convert.ToInt32(ViewState["SurgeonID"]);
       
        objBELBillDetail.SurgeonName = Convert.ToString(txtSurgeonName.Text);

        objBELBillDetail.OperationName = Convert.ToString(lblOperation.Text);
        objBELBillDetail.Operation = Convert.ToInt32(ViewState["OperationId"]);
       
        if (txtInvestigations.Text != "")
        {
            objBELBillDetail.InvestigationCharges = Convert.ToDecimal(txtInvestigations.Text.Trim());
        }
        else
        {
            objBELBillDetail.InvestigationCharges = 0;
        }


        if (txttheatreFee.Text != "")
            objBELBillDetail.TheatreFee = Convert.ToDecimal(txttheatreFee.Text);
        else
            objBELBillDetail.TheatreFee = 0;
        if (txtSurgeonFee.Text != "")
        {
            objBELBillDetail.SurgeonFee = Convert.ToDecimal(txtSurgeonFee.Text);
        }
        else
        {
            objBELBillDetail.SurgeonFee = 0;
        }

        if (txtWardCharges.Text != "")
        {
            objBELBillDetail.WardCharges = Convert.ToDecimal(txtWardCharges.Text);
        }
        else
        {
            objBELBillDetail.WardCharges = 0;
        }

        if (txtAnaestFee.Text != "")
            objBELBillDetail.AnesthetistCharges =Convert.ToDecimal(txtAnaestFee.Text);
        else
            objBELBillDetail.AnesthetistCharges = 0;

        if (txtMedicineCharges.Text != "")
            objBELBillDetail.MedicineCharges = Convert.ToDecimal(txtMedicineCharges.Text);
        else
            objBELBillDetail.MedicineCharges = 0;
        if (txtTotalCharges.Text != "")
            objBELBillDetail.TotalCharges = Convert.ToDecimal(txtTotalCharges.Text);
        else
            objBELBillDetail.TotalCharges = 0;


        objBELBillDetail.CreatedBy = Convert.ToString(Session["username"]);
        objBELBillDetail.BranchId = Convert.ToInt32(Session["Branchid"]);

        objBELBillDetail.FId = Convert.ToInt32(Session["FId"]);



        Message = objDALBillDetail.InsertSurgeryQuoteFinal(objBELBillDetail);
        lblMsg.Text = "Record saved Successfully..";
        Clear();

    }
    protected void txtInvestigations_TextChanged(object sender, EventArgs e)
    {
        if (txtInvestigations.Text == "")
        {
            txtInvestigations.Text = "0";
        }
        if (txtAnaestFee.Text == "")
        {
            txtAnaestFee.Text = "0";
        }
        if (txtMedicineCharges.Text == "")
        {
            txtMedicineCharges.Text = "0";
        }
        if (txtSurgeonFee.Text == "")
        {
            txtSurgeonFee.Text = "0";
        }
        if (txttheatreFee.Text == "")
        {
            txttheatreFee.Text = "0";
        }
        if (txtWardCharges.Text == "")
        {
            txtWardCharges.Text = "0";
        }

        txtTotalCharges.Text = Convert.ToString(Convert.ToDecimal(txtInvestigations.Text) + Convert.ToDecimal(txttheatreFee.Text) + Convert.ToDecimal(txtSurgeonFee.Text)
            + Convert.ToDecimal(txtWardCharges.Text) + Convert.ToDecimal(txtAnaestFee.Text)+Convert.ToDecimal(txtMedicineCharges.Text));
           
    }


    protected void txtWardCharges_TextChanged(object sender, EventArgs e)
    {
        if (txtInvestigations.Text == "")
        {
            txtInvestigations.Text = "0";
        }
        if (txtAnaestFee.Text == "")
        {
            txtAnaestFee.Text = "0";
        }
        if (txtMedicineCharges.Text == "")
        {
            txtMedicineCharges.Text = "0";
        }
        if (txtSurgeonFee.Text == "")
        {
            txtSurgeonFee.Text = "0";
        }
        if (txttheatreFee.Text == "")
        {
            txttheatreFee.Text = "0";
        }
        if (txtWardCharges.Text == "")
        {
            txtWardCharges.Text = "0";
        }

        txtTotalCharges.Text = Convert.ToString(Convert.ToDecimal(txtInvestigations.Text) + Convert.ToDecimal(txttheatreFee.Text) + Convert.ToDecimal(txtSurgeonFee.Text)
            + Convert.ToDecimal(txtWardCharges.Text) + Convert.ToDecimal(txtAnaestFee.Text) + Convert.ToDecimal(txtMedicineCharges.Text));
           

    }
    protected void txtMedicineCharges_TextChanged(object sender, EventArgs e)
    {
        if (txtInvestigations.Text == "")
        {
            txtInvestigations.Text = "0";
        }
        if (txtAnaestFee.Text == "")
        {
            txtAnaestFee.Text = "0";
        }
        if (txtMedicineCharges.Text == "")
        {
            txtMedicineCharges.Text = "0";
        }
        if (txtSurgeonFee.Text == "")
        {
            txtSurgeonFee.Text = "0";
        }
        if (txttheatreFee.Text == "")
        {
            txttheatreFee.Text = "0";
        }
        if (txtWardCharges.Text == "")
        {
            txtWardCharges.Text = "0";
        }

        txtTotalCharges.Text = Convert.ToString(Convert.ToDecimal(txtInvestigations.Text) + Convert.ToDecimal(txttheatreFee.Text) + Convert.ToDecimal(txtSurgeonFee.Text)
            + Convert.ToDecimal(txtWardCharges.Text) + Convert.ToDecimal(txtAnaestFee.Text) + Convert.ToDecimal(txtMedicineCharges.Text));
           
    }
    protected void txtSurgeonFee_TextChanged(object sender, EventArgs e)
    {
        if (txtInvestigations.Text == "")
        {
            txtInvestigations.Text = "0";
        }
        if (txtAnaestFee.Text == "")
        {
            txtAnaestFee.Text = "0";
        }
        if (txtMedicineCharges.Text == "")
        {
            txtMedicineCharges.Text = "0";
        }
        if (txtSurgeonFee.Text == "")
        {
            txtSurgeonFee.Text = "0";
        }
        if (txttheatreFee.Text == "")
        {
            txttheatreFee.Text = "0";
        }
        if (txtWardCharges.Text == "")
        {
            txtWardCharges.Text = "0";
        }

        txtTotalCharges.Text = Convert.ToString(Convert.ToDecimal(txtInvestigations.Text) + Convert.ToDecimal(txttheatreFee.Text) + Convert.ToDecimal(txtSurgeonFee.Text)
            + Convert.ToDecimal(txtWardCharges.Text) + Convert.ToDecimal(txtAnaestFee.Text) + Convert.ToDecimal(txtMedicineCharges.Text));
           
    }
    protected void txttheatreFee_TextChanged(object sender, EventArgs e)
    {
        if (txtInvestigations.Text == "")
        {
            txtInvestigations.Text = "0";
        }
        if (txtAnaestFee.Text == "")
        {
            txtAnaestFee.Text = "0";
        }
        if (txtMedicineCharges.Text == "")
        {
            txtMedicineCharges.Text = "0";
        }
        if (txtSurgeonFee.Text == "")
        {
            txtSurgeonFee.Text = "0";
        }
        if (txttheatreFee.Text == "")
        {
            txttheatreFee.Text = "0";
        }
        if (txtWardCharges.Text == "")
        {
            txtWardCharges.Text = "0";
        }

        txtTotalCharges.Text = Convert.ToString(Convert.ToDecimal(txtInvestigations.Text) + Convert.ToDecimal(txttheatreFee.Text) + Convert.ToDecimal(txtSurgeonFee.Text)
            + Convert.ToDecimal(txtWardCharges.Text) + Convert.ToDecimal(txtAnaestFee.Text) + Convert.ToDecimal(txtMedicineCharges.Text));
           
    }
    protected void txtAnaestFee_TextChanged(object sender, EventArgs e)
    {
        if (txtInvestigations.Text == "")
        {
            txtInvestigations.Text = "0";
        }
        if (txtAnaestFee.Text == "")
        {
            txtAnaestFee.Text = "0";
        }
        if (txtMedicineCharges.Text == "")
        {
            txtMedicineCharges.Text = "0";
        }
        if (txtSurgeonFee.Text == "")
        {
            txtSurgeonFee.Text = "0";
        }
        if (txttheatreFee.Text == "")
        {
            txttheatreFee.Text = "0";
        }
        if (txtWardCharges.Text == "")
        {
            txtWardCharges.Text = "0";
        }

        txtTotalCharges.Text = Convert.ToString(Convert.ToDecimal(txtInvestigations.Text) + Convert.ToDecimal(txttheatreFee.Text) + Convert.ToDecimal(txtSurgeonFee.Text)
            + Convert.ToDecimal(txtWardCharges.Text) + Convert.ToDecimal(txtAnaestFee.Text) + Convert.ToDecimal(txtMedicineCharges.Text));
           
    }
    protected void btnReport_Click(object sender, EventArgs e)
    {

        BLLReports objreports = new BLLReports();
        ReportDocument crystalReport = new ReportDocument();
        DataSet OtNotes = new DataSet();

        crystalReport.Load(Server.MapPath("~/Report/Rpt_SurgeryFinalQuotation.rpt"));

        //int PatRegId = Convert.ToInt32(Session["EmrRegNo"]);
        //int BranchId = Convert.ToInt32(Session["Branchid"]);
        //int FId = Convert.ToInt32(Session["FId"]);
        int SurgEstimationId = Convert.ToInt32(Request.QueryString["SurgEstimationId"]);
        OtNotes = objreports.GetSurgeryFinalQuatation_Rpt(SurgEstimationId);//, PatRegId, FId, BranchId);
        crystalReport.SetDataSource(OtNotes);
        //crystalReport.ParameterFields["HospitalName"].CurrentValues.AddValue(Convert.ToString(Application["OrgnizationName"]));
        //crystalReport.ParameterFields["HospitalAddress"].CurrentValues.AddValue(Convert.ToString(Application["OrgnizationAddress"]));
        //crystalReport.ParameterFields["ReportFooter"].CurrentValues.AddValue("Hospital Software | Ph.020 123456789");
        crystalReport.ExportToHttpResponse
        (CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "FinalQuatation");
 

    }
}