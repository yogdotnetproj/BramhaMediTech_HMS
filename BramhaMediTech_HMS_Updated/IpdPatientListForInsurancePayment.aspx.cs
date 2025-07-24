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

public partial class IpdPatientListForInsurancePayment : BasePage
{
    BELOPDPatReg objBELOpdReg = new BELOPDPatReg();
    DALOpdReg objDALOpdReg = new DALOpdReg();
    BELEmpReg objBELEmpReg = new BELEmpReg();
    DALEmpReg objDALEmpReg = new DALEmpReg();
    DALIPDDesk objDalIpdDesk = new DALIPDDesk();
    BLLReports objreports = new BLLReports();
    string sql = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            txtStart.Text = DateTime.Now.AddMonths(-1).ToString("dd/MM/yyyy");
            txtEnd.Text = DateTime.Now.ToString("dd/MM/yyyy");
            rblPatcate_SelectedIndexChanged(null, null);
            ViewState["PatientSubCategory"] = "0";
            FillRoomCategory();
           // refreshdata();
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
            using (SqlCommand cmd = new SqlCommand("[usp_GetIpdPatientListForInsurancePayment]", con))
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
                
                cmd.Parameters.AddWithValue("@PatientMainCategoryId", Convert.ToInt32(rblPatcate.SelectedValue));
                cmd.Parameters.AddWithValue("@PatientSubCategoryId", Convert.ToInt32(ViewState["PatientSubCategory"]));
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
       
        if (e.CommandName == "Select")
        {
            //Determine the RowIndex of the Row whose Button was clicked.
            int rowIndex = Convert.ToInt32(e.CommandArgument);

            //Reference the GridView Row.
            GridViewRow row = gvPatientInfo.Rows[rowIndex];
            int IpdId = Convert.ToInt32(gvPatientInfo.DataKeys[rowIndex].Values["IpdId"]);

            string PatRegId = gvPatientInfo.Rows[rowIndex].Cells[1].Text;


            // string response = @"~/frmTreatment2.aspx?RegId=" + regId + "&OpdNo=" + opd + "&Name=" + name + "&EntryDate=" + entryDate;
            string response = @"~/IpdAdvancePayment.aspx?RegId=" + PatRegId + "&IpdId=" + IpdId;

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
        txtPatientName.Text = PatientInfo[1];
        ViewState["PatientInfoId"] = PatientInfo[0];

    }

    protected void btnReport_Click(object sender, EventArgs e)
    {
        int RoomTypeId = 0;
        if (ddlRoomCategory.SelectedValue == "")
        {
            RoomTypeId = 0;
        }
        else
        {
            RoomTypeId = Convert.ToInt32(ddlRoomCategory.SelectedValue);
        }
        if(Convert.ToString( ViewState["PatientSubCategory"])=="")
        {
            ViewState["PatientSubCategory"] = "0";
        }
        objreports.IpdPatient_InsuranceList_Report(RoomTypeId, Convert.ToInt32(ViewState["PatientInfoId"]), Convert.ToInt32(Session["FId"]), Convert.ToInt32(Session["Branchid"]), txtStart.Text, txtEnd.Text, Convert.ToInt32(rblPatcate.SelectedValue), Convert.ToInt32(ViewState["PatientSubCategory"]),Convert.ToInt32( RblType.SelectedValue));
        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Reports/Rpt_IPDDuePatientReport.rpt");
        Session["reportname"] = "Rpt_IPDDuePatientReport";
        Session["RPTFORMAT"] = "pdf";


        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);

    }
    protected void btnexcel_Click(object sender, EventArgs e)
    {
        int RoomTypeId = 0;
        if (ddlRoomCategory.SelectedValue == "")
        {
            RoomTypeId = 0;
        }
        else
        {
            RoomTypeId = Convert.ToInt32(ddlRoomCategory.SelectedValue);
        }
        if (Convert.ToString(ViewState["PatientSubCategory"]) == "")
        {
            ViewState["PatientSubCategory"] = "0";
        }
      //  objreports.IpdPatientDueList_Report(RoomTypeId, Convert.ToInt32(ViewState["PatientInfoId"]), Convert.ToInt32(Session["FId"]), Convert.ToInt32(Session["Branchid"]), txtStart.Text, txtEnd.Text);
        objreports.IpdPatient_InsuranceList_Report(RoomTypeId, Convert.ToInt32(ViewState["PatientInfoId"]), Convert.ToInt32(Session["FId"]), Convert.ToInt32(Session["Branchid"]), txtStart.Text, txtEnd.Text, Convert.ToInt32(rblPatcate.SelectedValue), Convert.ToInt32(ViewState["PatientSubCategory"]), Convert.ToInt32(RblType.SelectedValue));
   
        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Reports/Rpt_IPDDuePatientReport.rpt");
        Session["reportname"] = "Rpt_IPDDuePatientReport";
        Session["RPTFORMAT"] = "EXCEL";


        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);

    }
    protected void rblPatcate_SelectedIndexChanged(object sender, EventArgs e)
    {

        int PatientCategoryId = Convert.ToInt32(rblPatcate.SelectedValue);
        ViewState["PatientCategoryID"] = PatientCategoryId;
        Session["PatientCategoryID"] = PatientCategoryId;
        if (Convert.ToInt32(rblPatcate.SelectedValue) == 1)
        {
            ddlPatientSubCategoryName1.Text = "CASH";
            ViewState["PatientSubCategory"] = "1";
            ddlPatientSubCategoryName1.Enabled = false;
          

           
        }
        else
        {
            ddlPatientSubCategoryName1.Enabled = true;
          
            ddlPatientSubCategoryName1.Text = "";
            ViewState["PatientSubCategory"] = "";
          

            ddlPatientSubCategoryName1.Text = "";
          
        }
    }
    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchSubCategory(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        string PatientCategoryID = Convert.ToString(HttpContext.Current.Session["PatientCategoryID"]);
        return objDALOpdReg.FillAllSubCategoryName(prefixText, PatientCategoryID);
    }
    protected void ddlPatientSubCategoryName1_TextChanged(object sender, EventArgs e)
    {
        if (Convert.ToString(ddlPatientSubCategoryName1.Text) != "")
        {
            if (ddlPatientSubCategoryName1.Text.Split('-').Length < 2)
            {
              //  hfPatientId.Value = "0";
                ViewState["PatientSubCategory"] = "0";
            }
            else
            {
                string[] PatientInfo = ddlPatientSubCategoryName1.Text.Split('-');
                ddlPatientSubCategoryName1.Text = PatientInfo[1];
                ViewState["PatientSubCategory"] = PatientInfo[0];
                Session["LabPatientSubCategory"] = PatientInfo[0];
              
            }
        }
    }
}