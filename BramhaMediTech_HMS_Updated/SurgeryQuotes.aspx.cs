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

public partial class SurgeryQuotes : System.Web.UI.Page
{
    BELOPDPatReg objBELOpdReg = new BELOPDPatReg();
    DALOpdReg objDALOpdReg = new DALOpdReg();
    BELEmpReg objBELEmpReg = new BELEmpReg();
    DALEmpReg objDALEmpReg = new DALEmpReg();
    DALIPDDesk objDalIpdDesk = new DALIPDDesk();

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!Page.IsPostBack)
        //{
        //    txtStart.Text = DateTime.Now.ToString("dd/MM/yyyy");
        //    txtEnd.Text = DateTime.Now.ToString("dd/MM/yyyy");
        //    FillRoomCategory();
        //    refreshdata();
        //}
        if (!this.IsPostBack)
        {
            txtStart.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtEnd.Text = DateTime.Now.ToString("dd/MM/yyyy");
            refreshdata();
        }
    }



    public void refreshdata()
    {
        DataTable dt = new DataTable();

        using (SqlConnection con = DataAccess.ConInitForDC())
        {
            using (SqlCommand cmd = new SqlCommand("usp_GetPatientListOfSurgery_Quotation", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FId", Convert.ToInt32(Session["FId"]));
                cmd.Parameters.AddWithValue("@BranchId", Convert.ToInt32(Session["Branchid"]));
                cmd.Parameters.AddWithValue("@PatRegId", Convert.ToInt32(ViewState["PatientInfoId"]));               
                cmd.Parameters.AddWithValue("@start", txtStart.Text);
                cmd.Parameters.AddWithValue("@end", txtEnd.Text);
                cmd.Parameters.AddWithValue("@Operation", Convert.ToInt32(ViewState["Operation"]));                
                cmd.Parameters.AddWithValue("@SurganID", Convert.ToInt32(ViewState["SurganID"]));             

                con.Open();

                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(dt);
                }

                con.Close();
            }
            gvPatientInfo.DataSource = dt;
            gvPatientInfo.DataBind();
           

        }

    }
    protected void gvPatientInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvPatientInfo.PageIndex = e.NewPageIndex;
        refreshdata();
    }


    //protected void gvPatientInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowIndex == -1)
    //        return;

    //    int GenOT = Convert.ToInt32((e.Row.FindControl("HdnGeneralOT") as HiddenField).Value.Trim());
    //    if (GenOT == 1)
    //    {
    //        e.Row.Cells[8].Text = "<span class='btn btn-xs btn-success' >Gen</span>";

    //    }
    //    else
    //    {
    //        e.Row.Cells[8].Text = "<span class='btn btn-xs btn-danger' >EYE</span>";
    //    }
    //}

    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchPatient(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        return objDALOpdReg.FillAllPatientSurgQuotation(prefixText);
    }
    [ScriptMethod()]
    [WebMethod]
    public static List<string> Searchsurgan(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        return objDALOpdReg.FillAllSurgan_Quotation(prefixText);
    }

    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchOperaation(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        
        return objDALOpdReg.FillAllOperation_Quotation(prefixText);
    }
    protected void txtPatientName_TextChanged(object sender, EventArgs e)
    {
        if (txtPatientName.Text != "")
        {
            string[] PatientInfo = txtPatientName.Text.Split('-');
            txtPatientName.Text = PatientInfo[1];
            ViewState["PatientInfoId"] = PatientInfo[0];
        }
        else
        {
            ViewState["PatientInfoId"] = "0";
        }

    }

    protected void txtsurgan_TextChanged(object sender, EventArgs e)
    {
        if (txtsurgan.Text != "")
        {
            string[] PatientInfo = txtsurgan.Text.Split('-');
            if (PatientInfo.Length == 2)
            {
                txtsurgan.Text = PatientInfo[1];
                ViewState["SurganID"] = PatientInfo[0];
            }
            else
            {
                ViewState["SurganID"] = "0";
            }
        }
        else
        {
            ViewState["SurganID"] = "0";
        }
    }
    protected void txtoperation_TextChanged(object sender, EventArgs e)
    {
        if (txtoperation.Text != "")
        {
            string[] PatientInfo = txtoperation.Text.Split('-');
            if (PatientInfo.Length == 2)
            {
                txtoperation.Text = PatientInfo[1];
                ViewState["Operation"] = PatientInfo[0];

            }
            else
            {
                ViewState["SurganID"] = "0";
            }
        }
        else
        {
            ViewState["SurganID"] = "0";
        }
    }
    protected void btnNotes_Click(object sender, EventArgs e)
    {
        Button btnNotes = (Button)sender;
        GridViewRow row = (GridViewRow)btnNotes.NamingContainer;


        BLLReports objreports = new BLLReports();
        ReportDocument crystalReport = new ReportDocument();
        DataSet OtNotes = new DataSet();

        crystalReport.Load(Server.MapPath("~/Report/Rpt_SurguryQuotationByDoc.rpt"));
       
        //int PatRegId = Convert.ToInt32(Session["EmrRegNo"]);
        //int BranchId = Convert.ToInt32(Session["Branchid"]);
        //int FId = Convert.ToInt32(Session["FId"]);
        int SurgEstimationId = Convert.ToInt32(gvPatientInfo.DataKeys[row.RowIndex].Values["SurgEstimationId"]);
        OtNotes = objreports.GetSurgeryNotes(SurgEstimationId);//, PatRegId, FId, BranchId);
        crystalReport.SetDataSource(OtNotes);
        //crystalReport.ParameterFields["HospitalName"].CurrentValues.AddValue(Convert.ToString(Application["OrgnizationName"]));
        //crystalReport.ParameterFields["HospitalAddress"].CurrentValues.AddValue(Convert.ToString(Application["OrgnizationAddress"]));
        //crystalReport.ParameterFields["ReportFooter"].CurrentValues.AddValue("Hospital Software | Ph.020 123456789");
        try
        {
            crystalReport.ExportToHttpResponse
            (CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "OtNotes");
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

    protected void btnQuotation_Click(object sender, EventArgs e)
    {
        Button btnQuotes = (Button)sender;
        GridViewRow row = (GridViewRow)btnQuotes.NamingContainer;
        int SurgEstimationId = Convert.ToInt32(gvPatientInfo.DataKeys[row.RowIndex].Values["SurgEstimationId"]);
        Response.Redirect("~/FinalSurgeryQuotation.aspx?SurgEstimationId=" + SurgEstimationId );
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        refreshdata();
    }
}