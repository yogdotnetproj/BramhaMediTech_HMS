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


public partial class OTNotesReport : BasePage
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
            if (Session["EmrRegNo"] != "")
            {
                string regId = Convert.ToString(Session["EmrRegNo"]);
                refreshdata();
            }
            else
            {
                Response.Redirect(string.Format("ListPatients.aspx"));
            }
        }
    }

    

    public void refreshdata()
    {
        DataTable dt = new DataTable();

        using (SqlConnection con = DataAccess.ConInitForDC())
        {
            using (SqlCommand cmd = new SqlCommand("usp_GetIpdPatientOTRegister_EMR", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FId", Convert.ToInt32(Session["FId"]));
                cmd.Parameters.AddWithValue("@BranchId", Convert.ToInt32(Session["Branchid"]));
                cmd.Parameters.AddWithValue("@PatRegId", Convert.ToInt32(Session["EmrRegNo"]));
                

                con.Open();

                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(dt);
                }

                con.Close();
                con.Dispose();
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



    protected void btnNotes_Click(object sender, EventArgs e)
    {
        Button btnNotes = (Button)sender;
        GridViewRow row = (GridViewRow)btnNotes.NamingContainer;
      

        BLLReports objreports = new BLLReports();
        ReportDocument crystalReport = new ReportDocument();
        DataSet OtNotes = new DataSet();

        crystalReport.Load(Server.MapPath("~/Report/Rpt_OTNotes.rpt"));
        int IpdId = Convert.ToInt32(Request.QueryString["IpdId"]);
        int PatRegId = Convert.ToInt32(Session["EmrRegNo"]);
        int BranchId = Convert.ToInt32(Session["Branchid"]);
        int FId = Convert.ToInt32(Session["FId"]);
        int OTId = Convert.ToInt32(gvPatientInfo.DataKeys[row.RowIndex].Values["OTId"]);
        OtNotes = objreports.GetOperationNotes(OTId, PatRegId, FId, BranchId);
        crystalReport.SetDataSource(OtNotes);
        //crystalReport.ParameterFields["HospitalName"].CurrentValues.AddValue(Convert.ToString(Application["OrgnizationName"]));
        //crystalReport.ParameterFields["HospitalAddress"].CurrentValues.AddValue(Convert.ToString(Application["OrgnizationAddress"]));
        //crystalReport.ParameterFields["ReportFooter"].CurrentValues.AddValue("Hospital Software | Ph.020 123456789");
        crystalReport.ExportToHttpResponse
        (CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "OtNotes");

    }
}