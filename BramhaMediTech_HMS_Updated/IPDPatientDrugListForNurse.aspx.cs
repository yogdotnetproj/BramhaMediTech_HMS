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
using System.Drawing;

public partial class IPDPatientDrugListForNurse :BasePage
{
    clsTreatmentTransaction transaction = new clsTreatmentTransaction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtFromDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtToDate.Text = DateTime.Now.ToString("dd/MM/yyyy");

            FillPurchaseOrderList();
        }
        this.RegisterPostBackControl();
    }
    [ScriptMethod()]
    [WebMethod]
    public static List<string> GetSupplierList(string prefixText, int count)
    {
        clsTreatmentTransaction PatList = new clsTreatmentTransaction();
        return PatList.AutoFillPatientName(prefixText);

    }

    [ScriptMethod()]
    [WebMethod]
    public static List<string> GetDrNameList(string prefixText, int count)
    {
        clsTreatmentTransaction DrList = new clsTreatmentTransaction();
        return DrList.AutoFillDrNameName(prefixText);

    }
    public void FillPurchaseOrderList()
    {

        if (txtFromDate.Text.ToString() != "")
        {
            // InvoiceInfo.FromDate = DateTime.ParseExact(txtFromDate.Value, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            ViewState["FromDate"] = txtFromDate.Text.ToString();
        }
        else
        {
            ViewState["FromDate"] = "";
        }
        if (txtToDate.Text.ToString() != "")
        {
            //InvoiceInfo.ToDate = DateTime.ParseExact(txtToDate.Value, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            ViewState["ToDate"] = txtToDate.Text.ToString();
        }
        else
        {
            ViewState["ToDate"] = "";
        }

        int SuppId;
        if (txtSupplier.Text != "")
        {
            SuppId = Convert.ToInt32(ViewState["Patregid"]);
        }
        else
        {
            SuppId = 0;
        }
        int PoNo;
        if (txtPurchaseOrderNo.Text != "")
        {
            PoNo = Convert.ToInt32(txtPurchaseOrderNo.Text);
        }
        else
        {
            PoNo = 0;
        }

        int DrId;
        if (txtdrname.Text != "")
        {
            DrId = Convert.ToInt32(ViewState["Drid"]);
        }
        else
        {
            DrId = 0;
        }

        string MobNo = "0";
        if (txtMobileNo.Text != "")
        {
            MobNo = Convert.ToString(txtMobileNo.Text);
        }
        else
        {
            MobNo = "0";
        }
        int status = Convert.ToInt32(ddlStatus.SelectedValue);
        ViewState["Paging"] = "Search";
        gvPurchaseList.DataSource = transaction.SearchIPDPatientListForNurse(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), SuppId, PoNo, 0, DrId, MobNo, status, "Nurse");
        gvPurchaseList.DataBind();


    }

    protected void txtSupplier_TextChanged(object sender, EventArgs e)
    {
        if (txtSupplier.Text != "")
        {
            string[] Supplier = txtSupplier.Text.Split('-');
            txtSupplier.Text = Supplier[1];
            ViewState["Patregid"] = Supplier[0];
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (txtFromDate.Text.ToString() != "")
        {
            // InvoiceInfo.FromDate = DateTime.ParseExact(txtFromDate.Value, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            ViewState["FromDate"] = txtFromDate.Text.ToString();
        }
        else
        {
            ViewState["FromDate"] = "";
        }
        if (txtToDate.Text.ToString() != "")
        {
            //InvoiceInfo.ToDate = DateTime.ParseExact(txtToDate.Value, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            ViewState["ToDate"] = txtToDate.Text.ToString();
        }
        else
        {
            ViewState["ToDate"] = "";
        }

        int SuppId;
        if (txtSupplier.Text != "")
        {
            SuppId = Convert.ToInt32(ViewState["Patregid"]);
        }
        else
        {
            SuppId = 0;
        }
        int PoNo;
        if (txtPurchaseOrderNo.Text != "")
        {
            PoNo = Convert.ToInt32(txtPurchaseOrderNo.Text);
        }
        else
        {
            PoNo = 0;
        }
        int DrId;
        if (txtdrname.Text != "")
        {
            DrId = Convert.ToInt32(ViewState["Drid"]);
        }
        else
        {
            DrId = 0;
        }

        string MobNo = "0";
        if (txtMobileNo.Text != "")
        {
            MobNo = Convert.ToString(txtMobileNo.Text);
        }
        else
        {
            MobNo = "0";
        }
        int status = Convert.ToInt32(ddlStatus.SelectedValue);
        ViewState["Paging"] = "Search";
        gvPurchaseList.DataSource = transaction.SearchIPDPatientListForNurse(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), SuppId, PoNo, 0, DrId, MobNo, status, "Nurse");
        gvPurchaseList.DataBind();

    }

    protected void gvPurchaseList_PageIndexChanging1(object sender, GridViewPageEventArgs e)
    {
        gvPurchaseList.PageIndex = e.NewPageIndex;

        FillPurchaseOrderList();

    }
    private void RegisterPostBackControl()
    {
        foreach (GridViewRow row in gvPurchaseList.Rows)
        {
            Button Btnprint = row.FindControl("Btnprint") as Button;
            ScriptManager.GetCurrent(this).RegisterPostBackControl(Btnprint);
        }
    }

    protected void btnReport_Click(object sender, EventArgs e)
    {
        if (txtFromDate.Text.ToString() != "")
        {
            // InvoiceInfo.FromDate = DateTime.ParseExact(txtFromDate.Value, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            ViewState["FromDate"] = txtFromDate.Text.ToString();
        }
        else
        {
            ViewState["FromDate"] = "";
        }
        if (txtToDate.Text.ToString() != "")
        {
            //InvoiceInfo.ToDate = DateTime.ParseExact(txtToDate.Value, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            ViewState["ToDate"] = txtToDate.Text.ToString();
        }
        else
        {
            ViewState["ToDate"] = "";
        }

        int SuppId;
        if (txtSupplier.Text != "")
        {
            SuppId = Convert.ToInt32(ViewState["Patregid"]);
        }
        else
        {
            SuppId = 0;
        }

        int PoNo;
        if (txtPurchaseOrderNo.Text != "")
        {
            PoNo = Convert.ToInt32(txtPurchaseOrderNo.Text);
        }
        else
        {
            PoNo = 0;
        }
        int DrId;
        if (txtdrname.Text != "")
        {
            DrId = Convert.ToInt32(ViewState["Drid"]);
        }
        else
        {
            DrId = 0;
        }

        string MobNo = "0";
        if (txtMobileNo.Text != "")
        {
            MobNo = Convert.ToString(txtMobileNo.Text);
        }
        else
        {
            MobNo = "0";
        }
        int status = Convert.ToInt32(ddlStatus.SelectedValue);

       // DALReports objDALReports = new DALReports();

        DataSet Payment = new DataSet();
        ReportDocument crystalReport = new ReportDocument();
        crystalReport.Load(Server.MapPath("~/Reports/Rpt_PurchaseOrderList.rpt"));
        // crystalReport.Load(Server.MapPath("~/Reports/rpt_TestPurchaseOrderList.rpt"));

       // Payment = objDALReports.GetPurchaseList(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), SuppId, PoNo);
        crystalReport.SetDataSource(Payment);
        crystalReport.ParameterFields["FromDate"].CurrentValues.AddValue(Convert.ToString(ViewState["FromDate"]));
        crystalReport.ParameterFields["ToDate"].CurrentValues.AddValue(Convert.ToString(ViewState["ToDate"]));

        //crystalReport.ParameterFields["HospitalName"].CurrentValues.AddValue(Convert.ToString(Application["OrgnizationName"]));
        //crystalReport.ParameterFields["HospitalAddress"].CurrentValues.AddValue(Convert.ToString(Application["OrgnizationAddress"]));

        //crystalReport.ParameterFields["ReportFooter"].CurrentValues.AddValue("Hospital Software | Ph.020 123456789");
        crystalReport.ExportToHttpResponse
        (CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Employee");

    }

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        Button Btnprint = (Button)sender;
        GridViewRow row = (GridViewRow)Btnprint.NamingContainer;
        // this.ScriptManager.RegisterPostBackControl();
        this.RegisterPostBackControl();
        int PatientRegId = Convert.ToInt32(gvPurchaseList.DataKeys[row.RowIndex]["PatientRegId"].ToString());
        int Ipd = Convert.ToInt32(gvPurchaseList.DataKeys[row.RowIndex]["Ipd"].ToString());
        int TreatmentId = Convert.ToInt32(gvPurchaseList.DataKeys[row.RowIndex]["TreatmentId"].ToString());
        //DALReports objDALReports = new DALReports();

        //BEL InvoiceDetails = new BEL();
        //InvoiceDetails.SuppId = Convert.ToInt32(SupplierId);
        //InvoiceDetails.PONo = Convert.ToInt32(PoNo);

        //DataSet Invoice = new DataSet();
        //ReportDocument crystalReport = new ReportDocument();
        //crystalReport.Load(Server.MapPath("~/Reports/Rpt_PurchaseOrderOnSave.rpt"));
        //Invoice = objDALReports.GetPurchase(InvoiceDetails);
        //crystalReport.SetDataSource(Invoice);
        ////crystalReport.ParameterFields["HospitalName"].CurrentValues.AddValue(Convert.ToString(Application["OrgnizationName"]));
        ////crystalReport.ParameterFields["HospitalAddress"].CurrentValues.AddValue(Convert.ToString(Application["OrgnizationAddress"]));

        ////crystalReport.ParameterFields["ReportFooter"].CurrentValues.AddValue("Hospital Software | Ph.020 123456789");
        //crystalReport.ExportToHttpResponse
        //(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Employee");

        string sql = "";
        Alter_view(PatientRegId, Ipd,TreatmentId);




        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Report/Rpt_Prescription_Report.rpt");
        Session["reportname"] = "Prescription";
        Session["RPTFORMAT"] = "pdf";

        //ReportParameterClass.SelectionFormula = sql;
        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);
    }
    protected void btnDetails_Click(object sender, EventArgs e)
    {
        Button btnDetails = (Button)sender;
        GridViewRow row = (GridViewRow)btnDetails.NamingContainer;
        // this.ScriptManager.RegisterPostBackControl();
        this.RegisterPostBackControl();
        int PatientRegId = Convert.ToInt32(gvPurchaseList.DataKeys[row.RowIndex]["PatientRegId"].ToString());
        int IPDNO = Convert.ToInt32(gvPurchaseList.DataKeys[row.RowIndex]["Ipd"].ToString());
        int TreatmentId = Convert.ToInt32(gvPurchaseList.DataKeys[row.RowIndex]["TreatmentId"].ToString());
        int Opd = 0;
        Session["EmrRegNo"] = PatientRegId;
        Session["EmrOpdNo"] = 0;
        Session["EmrIpdNo"] = IPDNO;
        string response = @"~/EditDrugListForNurse.aspx?TreatmentId=" + TreatmentId + "&RegId=" + PatientRegId + "&OpdNo=" + Opd + "&IPDNO=" + IPDNO + "&PType=IPD&SType=Emergency";

        Response.Redirect(string.Format(response));
    }

    public void Alter_view(int PatientRegId, int Ipd,int TreatmentId)
    {
        string sql = "";
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd1 = con.CreateCommand();

        string query = "ALTER VIEW [dbo].[VW_GetPrescription] AS (SELECT        tbl_TreatmentTransaction.TreatmentId, tbl_Treatment.FollowUpDate, tbl_Treatment.PatientRegId, tbl_Treatment.Opd, tbl_Treatment.Ipd, tbl_Treatment.BranchId, tbl_Treatment.CreatedBy, tbl_Treatment.CreatedOn, tbl_Treatment.UpdatedBy, " +
                  "  tbl_Treatment.UpdatedOn, tbl_Treatment.DrId, Initial.Title + ' ' + PatientInformation.FirstName AS PatientName, Initial.Title, Gender.GenderName, PatientInformation.MobileNo, PatientInformation.PhoneNo, " +
                  "  PatientInformation.PatientAddress, PatientInformation.Age, PatientInformation.AgeType, tbl_TreatmentTransaction.DrugName, tbl_TreatmentTransaction.FrequencyType, tbl_TreatmentTransaction.Days,dbo.tbl_TreatmentTransaction.Qty, " +
                  "  tbl_TreatmentTransaction.StartDate, tbl_TreatmentTransaction.EndDate, tbl_TreatmentTransaction.Note, tbl_TreatmentTransaction.Dose ,HospEmpMst.Title+' '+ HospEmpMst.Empname as DrName, DepartmentMst.DeptName, HospEmpMst.EmployeeType , tbl_GeneralEmrTransaction.Diagnosis, HospEmpMst.DrSignature " +
            //"  FROM            tbl_Treatment INNER JOIN " +
            //"  PatientInformation ON tbl_Treatment.PatientRegId = PatientInformation.PatRegId AND tbl_Treatment.BranchId = PatientInformation.BranchId INNER JOIN " +
            //"  Initial ON PatientInformation.TitleId = Initial.TitleId INNER JOIN " +
            //"  Gender ON PatientInformation.GenderId = Gender.GenderId INNER JOIN  " +
            //"  tbl_TreatmentTransaction ON tbl_Treatment.TreatmentId = tbl_TreatmentTransaction.TreatmentId INNER JOIN " +
            //"  HospEmpMst ON tbl_Treatment.DrId = HospEmpMst.DrId INNER JOIN " +
            //"  DepartmentMst ON HospEmpMst.DeptId = DepartmentMst.DeptId INNER JOIN " +
            //"  tbl_GeneralEMR ON tbl_Treatment.PatientRegId = tbl_GeneralEMR.Patientregid AND tbl_Treatment.Opd = tbl_GeneralEMR.opd AND tbl_Treatment.Ipd = tbl_GeneralEMR.ipd AND " +
            //"  tbl_Treatment.BranchId = tbl_GeneralEMR.branchid INNER JOIN " +
            //"  tbl_GeneralEmrTransaction ON tbl_GeneralEMR.EmrId = tbl_GeneralEmrTransaction.EmrId " +

                   "  FROM            tbl_GeneralEmrTransaction INNER JOIN " +
                      "  tbl_GeneralEMR ON tbl_GeneralEmrTransaction.EmrId = tbl_GeneralEMR.EmrId RIGHT OUTER JOIN " +
                      "  tbl_Treatment INNER JOIN " +
                      "  PatientInformation ON tbl_Treatment.PatientRegId = PatientInformation.PatRegId AND tbl_Treatment.BranchId = PatientInformation.BranchId INNER JOIN " +
                      "  Initial ON PatientInformation.TitleId = Initial.TitleId INNER JOIN " +
                      "  Gender ON PatientInformation.GenderId = Gender.GenderId INNER JOIN " +
                      "  tbl_TreatmentTransaction ON tbl_Treatment.TreatmentId = tbl_TreatmentTransaction.TreatmentId INNER JOIN " +
                      "  HospEmpMst ON tbl_Treatment.DrId = HospEmpMst.DrId INNER JOIN " +
                      "  DepartmentMst ON HospEmpMst.DeptId = DepartmentMst.DeptId ON tbl_GeneralEMR.Patientregid = tbl_Treatment.PatientRegId AND tbl_GeneralEMR.opd = tbl_Treatment.Opd AND tbl_GeneralEMR.ipd = tbl_Treatment.Ipd AND  " +
                      "  tbl_GeneralEMR.branchid = tbl_Treatment.BranchId " +
        " where tbl_TreatmentTransaction.TreatmentId=" + Convert.ToInt32(TreatmentId) + " and tbl_Treatment.branchid=" + Convert.ToInt32(Session["Branchid"]) + " and (tbl_Treatment.PatientRegId = " + Convert.ToString(PatientRegId) + ") AND (tbl_Treatment.Ipd = " + Convert.ToString(Ipd) + ")    ";//AND (tbl_Treatment.Ipd = "+Convert.ToString(Session["EmrIpdNo"])+")
        //if (txtFrom.Value != "" && txtTo.Value != "")
        //{
        //    query += " and    tbl_GeneralEMR.Createdon between ('" + Convert.ToDateTime(txtFrom.Value).ToString("MM/dd/yyyy") + "') and ('" + Convert.ToDateTime(txtTo.Value).AddDays(1).ToString("MM/dd/yyyy") + "')";
        //}
        //Convert.ToString(Session["EmrRegNo"]), Convert.ToString(Session["EmrOpdNo"])


        cmd1.CommandText = query + ")";

        con.Open();
        cmd1.ExecuteNonQuery();
        con.Close(); con.Dispose();
    }
    protected void gvPurchaseList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex == -1)
            return;

        bool ReceiveToPharma = Convert.ToBoolean((e.Row.FindControl("HdnReceiveToPharma") as HiddenField).Value.Trim());
        //if (ReceiveToPharma == true)
        //{
        //    e.Row.Cells[0].Text = "<span class='btn btn-xs btn-success' >Proc</span>";

        //}
        //else
        //{
        //    e.Row.Cells[0].Text = "<span class='btn btn-xs btn-danger' >Pen</span>";
        //}
        bool ApproveByNurse = Convert.ToBoolean((e.Row.FindControl("HdnApprove") as HiddenField).Value.Trim());


        foreach (Button btn in e.Row.Cells[0].Controls.OfType<Button>())
        {
            if (ApproveByNurse == true)
            {
                btn.Enabled = false;
                //btn.BackColor = System.Drawing.Color.Green;
            }
            else
            {
                btn.Enabled = true;
            }


        }
        foreach (Button btn1 in e.Row.Cells[9].Controls.OfType<Button>())
        {
            if (ApproveByNurse == true)
            {
                btn1.Enabled = false;
                btn1.BackColor = System.Drawing.Color.Green;
            }
            else
            {
                btn1.Enabled = true;
                //btn1.BackColor = System.Drawing.Color.Red;
            }

        }
           
           
        string PaymentStatus = Convert.ToString((e.Row.FindControl("HdnPaymentStatus") as HiddenField).Value.Trim());
       
        //string PaymentStatus = Convert.ToString(e.Row.Cells[8].Text);
        foreach (TableCell cell in e.Row.Cells)
        {
            if (PaymentStatus == "Paid")
            {
                cell.BackColor = Color.Red;
               
            }
            else if (PaymentStatus == "PartiallyPaid")
            {
                cell.BackColor = Color.Orange;
               
            }
            else if (PaymentStatus == "IPDPaid")
            {
                e.Row.Cells[8].BackColor = Color.Green;

            }
            else
                cell.BackColor = Color.White;
        }


    }
    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void txtdrname_TextChanged(object sender, EventArgs e)
    {
        if (txtdrname.Text != "")
        {
            string[] Doctor = txtdrname.Text.Split('-');
            txtdrname.Text = Doctor[1];
            ViewState["Drid"] = Doctor[0];
        }
    }
    protected void btnApprove_Click(object sender, EventArgs e)
    {
        Button btnApprove = (Button)sender;
        GridViewRow row = (GridViewRow)btnApprove.NamingContainer;
        
        this.RegisterPostBackControl();
        
        int TreatmentId = Convert.ToInt32(gvPurchaseList.DataKeys[row.RowIndex]["TreatmentId"].ToString());


        transaction.UpdateNurseStatus(TreatmentId);
        lblMsg.Text = "Record Approved Successfully";
        FillPurchaseOrderList();
        
    }
}