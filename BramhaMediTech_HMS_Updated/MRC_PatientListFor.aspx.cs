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

public partial class MRC_PatientListFor :BasePage
{
    BELOPDPatReg objBELOpdReg = new BELOPDPatReg();
    DALOpdReg objDALOpdReg = new DALOpdReg();
    BELEmpReg objBELEmpReg = new BELEmpReg();
    DALEmpReg objDALEmpReg = new DALEmpReg();
    DALIPDDesk objDalIpdDesk = new DALIPDDesk();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            txtStart.Text = DateTime.Now.AddMonths(-1).ToString("dd/MM/yyyy");
            txtEnd.Text = DateTime.Now.ToString("dd/MM/yyyy");
            FillRoomCategory();
            refreshdata();
        }
    }

    protected void FillRoomCategory()
    {
        ddlRoomCategory.DataSource = objDalIpdDesk.FillRoomTypes(Convert.ToInt32(Session["FId"]), Convert.ToInt32(Session["BranchId"]));
        ddlRoomCategory.DataTextField = "RType";
        ddlRoomCategory.DataValueField = "RTypeId";
        ddlRoomCategory.DataBind();
        ddlRoomCategory.Items.Insert(0, new ListItem("Select Room", "0"));
    }

    public void refreshdata()
    {
        DataTable dt = new DataTable();

        using (SqlConnection con = DataAccess.ConInitForDC())
        {
            using (SqlCommand cmd = new SqlCommand("usp_MRC_GetIpdPatientListForAdvancePayment", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FId", Convert.ToInt32(Session["FId"]));
                cmd.Parameters.AddWithValue("@BranchId", Convert.ToInt32(Session["Branchid"]));
                cmd.Parameters.AddWithValue("@PatRegId", Convert.ToInt32(ViewState["PatientInfoId"]));
                if (ddlRoomCategory.SelectedValue == "")
                {
                    ddlRoomCategory.SelectedValue = "0";
                }
                else
                {
                    cmd.Parameters.AddWithValue("@RTypeId", Convert.ToInt32(ddlRoomCategory.SelectedValue));
                }
                cmd.Parameters.AddWithValue("@start", txtStart.Text);
                cmd.Parameters.AddWithValue("@end", txtEnd.Text);
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

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        refreshdata();
    }

    protected void gvPatientInfo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        BLLReports objreports = new BLLReports();
        string sql = "";
        if (e.CommandName == "Select")
        {
            //Determine the RowIndex of the Row whose Button was clicked.
            int rowIndex = Convert.ToInt32(e.CommandArgument);

            //Reference the GridView Row.
            GridViewRow row = gvPatientInfo.Rows[rowIndex];
            int IpdId = Convert.ToInt32(gvPatientInfo.DataKeys[rowIndex].Values["IpdId"]);

            string PatRegId = gvPatientInfo.Rows[rowIndex].Cells[1].Text;


            // string response = @"~/frmTreatment2.aspx?RegId=" + regId + "&OpdNo=" + opd + "&Name=" + name + "&EntryDate=" + entryDate;
            string response = @"~/MRC_IpdAdvancePayment.aspx?RegId=" + PatRegId + "&IpdId=" + IpdId;

            Response.Redirect(string.Format(response));

            // ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Name: " + name + "\\nRegId: " + regId + "');", true);
        }
        if (e.CommandName == "Report")
        {

            //Determine the RowIndex of the Row whose Button was clicked.
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            //Reference the GridView Row.
            GridViewRow row = gvPatientInfo.Rows[rowIndex];
            int IpdId = Convert.ToInt32(gvPatientInfo.DataKeys[rowIndex].Values["IpdId"]);
            int PatRegId = Convert.ToInt32(gvPatientInfo.Rows[rowIndex].Cells[1].Text);
            int BranchId = Convert.ToInt32(Session["Branchid"]);
            int FId = Convert.ToInt32(Session["FId"]);

            objreports.IpdBillDetails(IpdId, PatRegId, FId, BranchId);

            Session.Add("rptsql", sql);
            Session["rptname"] = Server.MapPath("~/Reports/Rpt_IpdBillDetails.rpt");
            Session["reportname"] = "IpdBillDetails_Report";
            Session["RPTFORMAT"] = "pdf";


            string close = "<script language='javascript'>javascript:OpenReport();</script>";
            Type title1 = this.GetType();
            Page.ClientScript.RegisterStartupScript(title1, "", close);




        }
        if (e.CommandName == "Summary")
        {

            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvPatientInfo.Rows[rowIndex];
            int IpdId = Convert.ToInt32(gvPatientInfo.DataKeys[rowIndex].Values["IpdId"]);
            int PatRegId = Convert.ToInt32(gvPatientInfo.Rows[rowIndex].Cells[1].Text);
            int BranchId = Convert.ToInt32(Session["Branchid"]);
            int FId = Convert.ToInt32(Session["FId"]);
            // objreports.IpdBillSummary(IpdId, PatRegId);

            objreports.IpdBillDetails(IpdId, PatRegId, FId, BranchId);
            Session.Add("rptsql", sql);
            // Session["rptname"] = Server.MapPath("~/Reports/Rpt_IpdBillSummary.rpt");
            Session["rptname"] = Server.MapPath("~/Reports/Rpt_IpdBillDetails_summary.rpt");
            Session["reportname"] = "IpdBillSummary_Report";
            Session["RPTFORMAT"] = "pdf";


            string close = "<script language='javascript'>javascript:OpenReport();</script>";
            Type title1 = this.GetType();
            Page.ClientScript.RegisterStartupScript(title1, "", close);


        }

    }

    protected void gvPatientInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvPatientInfo.PageIndex = e.NewPageIndex;
        refreshdata();
    }
    //protected void ddlConsDoctorName_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    // if (Convert.ToBoolean(ViewState["IsDirect"]) != true)
    //    //{

    //    int ConsultantDrId = Convert.ToInt32(ddlConsDoctorName.SelectedValue);
    //    int BranchId = Convert.ToInt32(Session["Branchid"]);
    //    int FId = Convert.ToInt32(Session["FId"]);

    //    string DeptId = objDALOpdReg.GetDeptId(Convert.ToInt32(ddlConsDoctorName.SelectedValue), FId, BranchId);

    //    ddlDepartment.SelectedValue = DeptId;


    //}
    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchPatient(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        return objDALOpdReg.FillAllPatient(prefixText);
    }
    protected void txtPatientName_TextChanged(object sender, EventArgs e)
    {

        string[] PatientInfo = txtPatientName.Text.Split('-');
        if (PatientInfo.Length > 1)
        {
            txtPatientName.Text = PatientInfo[1];
            ViewState["PatientInfoId"] = PatientInfo[0];
        }

    }

}