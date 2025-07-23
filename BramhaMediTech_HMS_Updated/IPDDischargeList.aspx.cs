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

public partial class IPDDischargeList : System.Web.UI.Page
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
            txtStart.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtEnd.Text = DateTime.Now.ToString("dd/MM/yyyy");
            ViewState["PatientInfoId"] = "0";
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
            using (SqlCommand cmd = new SqlCommand("usp_GetIpdPatientListForDischarge", con))
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
                if (ddlreasonofdisc.SelectedValue == "")
                {
                    //ddlreasonofdisc.SelectedValue = "0";
                    cmd.Parameters.AddWithValue("@reasonofdisc", Convert.ToString("0"));
                }
                else
                {
                    cmd.Parameters.AddWithValue("@reasonofdisc", Convert.ToString(ddlreasonofdisc.SelectedValue));
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

            string PatRegId = gvPatientInfo.Rows[rowIndex].Cells[2].Text;


            // string response = @"~/frmTreatment2.aspx?RegId=" + regId + "&OpdNo=" + opd + "&Name=" + name + "&EntryDate=" + entryDate;
            string response = @"~/IpdAdvancePayment.aspx?RegId=" + PatRegId + "&IpdId=" + IpdId + "&Discharge=Yes";

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
            int PatRegId = Convert.ToInt32(gvPatientInfo.Rows[rowIndex].Cells[2].Text);
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
            int PatRegId = Convert.ToInt32(gvPatientInfo.Rows[rowIndex].Cells[2].Text);
            int BranchId = Convert.ToInt32(Session["Branchid"]);
            int FId = Convert.ToInt32(Session["FId"]);
            //objreports.IpdBillSummary(IpdId, PatRegId);

            //Session.Add("rptsql", sql);
            //Session["rptname"] = Server.MapPath("~/Reports/Rpt_IpdBillSummary.rpt");
            //Session["reportname"] = "IpdBillSummary_Report";
            //Session["RPTFORMAT"] = "pdf";
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
        if (e.CommandName == "SummaryUSD")
        {

            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvPatientInfo.Rows[rowIndex];
            int IpdId = Convert.ToInt32(gvPatientInfo.DataKeys[rowIndex].Values["IpdId"]);
            int PatRegId = Convert.ToInt32(gvPatientInfo.Rows[rowIndex].Cells[2].Text);
            int BranchId = Convert.ToInt32(Session["Branchid"]);
            int FId = Convert.ToInt32(Session["FId"]);
            //objreports.IpdBillSummary(IpdId, PatRegId);

            //Session.Add("rptsql", sql);
            //Session["rptname"] = Server.MapPath("~/Reports/Rpt_IpdBillSummary.rpt");
            //Session["reportname"] = "IpdBillSummary_Report";
            //Session["RPTFORMAT"] = "pdf";
            objreports.IpdBillDetails(IpdId, PatRegId, FId, BranchId);
            Session.Add("rptsql", sql);
            // Session["rptname"] = Server.MapPath("~/Reports/Rpt_IpdBillSummary.rpt");
            Session["rptname"] = Server.MapPath("~/Reports/Rpt_IpdBillDetails_summary_USD.rpt");
            Session["reportname"] = "IpdBillSummary_ReportUSD";
            Session["RPTFORMAT"] = "pdf";

            string close = "<script language='javascript'>javascript:OpenReport();</script>";
            Type title1 = this.GetType();
            Page.ClientScript.RegisterStartupScript(title1, "", close);


        }
        if (e.CommandName == "Discharge")
        {
            //Determine the RowIndex of the Row whose Button was clicked.
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            //Reference the GridView Row.
            GridViewRow row = gvPatientInfo.Rows[rowIndex];
            int IpdId = Convert.ToInt32(gvPatientInfo.DataKeys[rowIndex].Values["IpdId"]);

           // string PatRegId = gvPatientInfo.Rows[rowIndex].Cells[2].Text;
            string IPDNO = gvPatientInfo.Rows[rowIndex].Cells[3].Text;
            string BillNo = gvPatientInfo.Rows[rowIndex].Cells[4].Text;

            int PatRegId = Convert.ToInt32(gvPatientInfo.Rows[rowIndex].Cells[2].Text);
            int BranchId = Convert.ToInt32(Session["Branchid"]);
            int FId = Convert.ToInt32(Session["FId"]);
            AlterView_VE_GetLabNo(Convert.ToString(IpdId));
            //VW_DescriptiveViewLogic.SP_Getresultnondesc_Report(Convert.ToInt32(Session["Branchid"]), ViewTestCode, Request.QueryString["PatRegID"], Request.QueryString["FID"]);
            // SP_Getresultnondesc_Report();
            // SP_Getresultnondesc_Report(BranchId,Convert.ToString( Request.QueryString["IpdId"]),Convert.ToString(Session["FId"]));
            // SP_Getresultdesc_Report(BranchId, Convert.ToString(Request.QueryString["IpdId"]), Convert.ToString(Session["FId"]));
            objreports.IpdDischrge_Summary_Report(IpdId, PatRegId, FId, BranchId);


            Session.Add("rptsql", sql);
            // Session["rptname"] = Server.MapPath("~/Reports/Rpt_DischargeSummaryReport.rpt");
            Session["rptname"] = Server.MapPath("~/Reports/Rpt_DischargeSummaryReport.rpt");
            Session["reportname"] = "DischargeSummaryReport";
            Session["RPTFORMAT"] = "pdf";


            string close = "<script language='javascript'>javascript:OpenReport();</script>";
            Type title1 = this.GetType();
            Page.ClientScript.RegisterStartupScript(title1, "", close);
           
           // string response = @"~/IpdDischargeSummary.aspx?RegId=" + PatRegId + "&IpdId=" + IPDNO + "&BillNo=" + BillNo;
          //  Response.Redirect(string.Format(response));

            // ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Name: " + name + "\\nRegId: " + regId + "');", true);
        }
        //BLLReports objreports = new BLLReports();
        //string sql = "";
        if (e.CommandName == "SelectEMR")
        {
            //Determine the RowIndex of the Row whose Button was clicked.
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            //Reference the GridView Row.
            GridViewRow row = gvPatientInfo.Rows[rowIndex];
            int IpdId = Convert.ToInt32(gvPatientInfo.DataKeys[rowIndex].Values["IpdId"]);

            string PatRegId = gvPatientInfo.Rows[rowIndex].Cells[2].Text;

            string BillNo = gvPatientInfo.Rows[rowIndex].Cells[4].Text;
            string name = gvPatientInfo.Rows[rowIndex].Cells[5].Text.Trim();

            string entryDate = gvPatientInfo.Rows[rowIndex].Cells[7].Text;
            int opd = 0;

            // string response = @"~/frmTreatment2.aspx?RegId=" + regId + "&OpdNo=" + opd + "&Name=" + name + "&EntryDate=" + entryDate;
            // string response = @"~/IpdBillForPatientServices.aspx?RegId=" + PatRegId + "&IpdId=" + IpdId;
            Session["EmrRegNo"] = PatRegId;
            Session["EmrOpdNo"] = 0;
            Session["EmrIpdNo"] = IpdId;
            Session["EmrBillNo"] = BillNo;
            Session["FormType"] = "";
            // string response = @"~/frmTreatment2.aspx?RegId=" + regId + "&OpdNo=" + opd + "&Name=" + name + "&EntryDate=" + entryDate;
            //string response = @"~/DailyDrNote.aspx?RegId=" + PatRegId + "&OpdNo=" + opd + "&IpdNo=" + IpdId + "&Name=" + name + "&EntryDate=" + entryDate;
            string response = @"~/IPDEMRDashboard.aspx?RegId=" + PatRegId + "&OpdNo=" + opd + "&IpdNo=" + IpdId + "&Name=" + name + "&EntryDate=" + entryDate;

            Response.Redirect(string.Format(response));

            // ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Name: " + name + "\\nRegId: " + regId + "');", true);
        }
        if (e.CommandName == "ReAdmit")
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvPatientInfo.Rows[rowIndex];
            int IpdId = Convert.ToInt32(gvPatientInfo.DataKeys[rowIndex].Values["IpdId"]);

            string PatRegId = gvPatientInfo.Rows[rowIndex].Cells[2].Text;
            int BranchId = Convert.ToInt32(Session["Branchid"]);
            int FId = Convert.ToInt32(Session["FId"]);
            string username = Convert.ToString(Session["username"]);

            objreports.ReadmitDischargePatient(IpdId, PatRegId, FId, BranchId, username);
            gvPatientInfo.Caption = "ACT Open!.";
        }
    }

    public void AlterView_VE_GetLabNo(string IPDNO)
    {
        int i;
        SqlConnection conn = DataAccess.ConInitForPathology();
        SqlCommand sc = conn.CreateCommand();
        sc.CommandText = "ALTER VIEW [dbo].[VW_GetLabNo]AS (select  LabNo,patmst.PatRegID,MTCode,patmst.Branchid,patmst.FID FROM   patmstd INNER JOIN patmst ON patmstd.PatRegID = patmst.PatRegID AND patmstd.PID = patmst.PID  where  patmst.IPDNO='" + IPDNO + "'  and patmst.branchid ='" + Convert.ToInt32(Session["Branchid"]) + "' and  patmst.FID ='" + Convert.ToString(Session["FId"]) + "' )";
        try
        {
            conn.Open();
            sc.ExecuteNonQuery();

        }
        catch (Exception exx)
        { }
        finally
        {
            try
            {

                conn.Close();
                conn.Dispose();
            }
            catch (SqlException)
            {
                // Log an event in the Application Event Log.
                throw;
            }

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
        if (txtPatientName.Text != "")
        {
            string[] PatientInfo = txtPatientName.Text.Split('-');
            txtPatientName.Text = PatientInfo[1];
            ViewState["PatientInfoId"] = PatientInfo[0];
        }

    }

    protected void btnPdf_Click(object sender, EventArgs e)
    {
        string sql = "";
        //if (Convert.ToString(Session["EmrOpdNo"]) != "")
        //{
        //    objBELIO.OpdNo = Convert.ToInt32(Session["EmrOpdNo"]);
        //}
        //else
        //{
        //    objBELIO.OpdNo = 0;
        //}
        //if (Convert.ToString(Session["EmrIpdNo"]) != "")
        //{
        //    objBELIO.IpdNo = Convert.ToInt32(Session["EmrIpdNo"]);
        //}
        //else
        //{
        //    objBELIO.IpdNo = 0;
        //}
        //objBELIO.Patregid = Convert.ToInt32(Session["EmrRegNo"]);
        //objDALIO.Alter_Vw_DailyNurseNote(objBELIO);
        Alter_view();
        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Report/Rpt_PatientDischargeList.rpt");
        Session["reportname"] = "PatientDischargeList";
        Session["RPTFORMAT"] = "pdf";

        //ReportParameterClass.SelectionFormula = sql;
        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);
    }

    public void Alter_view()
    {
        string sql = "";
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd1 = con.CreateCommand();

        string query = "ALTER VIEW [dbo].[VW_PatientDischargeList] AS (SELECT DISTINCT " +
               " RoomType.RType, RoomMst.RoomName, IpdRegistration.IpdNo, IpdRegistration.PatRegId, IpdRegistration.IpdId, IpdRegistration.EntryDate, IpdRegistration.EntryTime, IpdRegistration.DeptId, "+
               " IpdRegistration.PrimaryDoc, IpdRegistration.SecodaryDoc, IpdRegistration.ReferenceDoc, IpdRegistration.PatientMainCategoryId, IpdRegistration.ContactPerson1, IpdRegistration.ContactPerson2, IpdRegistration.Relation1, "+
               " IpdRegistration.Relation2, IpdRegistration.Contact1, IpdRegistration.Contact2, IpdRegistration.BedId, IpdRegistration.IsAdmited, IpdRegistration.CreatedBy, IpdRegistration.CreatedOn, IpdRegistration.FId, "+
               " IpdRegistration.BranchId, IpdRegistration.UpdatedBy, IpdRegistration.UpdatedOn, IpdRegistration.IsUniversalPrecaution, IpdRegistration.IsEmergency, BedMst.BedName, AlloctnOfBed.PatStatus, AlloctnOfBed.DateOfAdmission, "+
               " HospEmpMst.Empname, RoomMst.RTypeId, PatientInformation.FirstName, PatientInformation.TitleId, Initial.Title, HospEmpMst.Title AS Expr1, ISNULL(IpdBillMaster.BillAmount, 0) AS BillAmount, "+
               " ISNULL(IpdBillMaster.InvoiceNo, 0) AS InvoiceNo, IpdBillMaster.BillNo, AlloctnOfBed.ReasonforDischarge, AlloctnOfBed.DischargedBy, AlloctnOfBed.DischargeTime "+
               " FROM            IpdBillMaster INNER JOIN "+
               " IpdRegistration ON IpdBillMaster.IpdId = IpdRegistration.IpdId AND IpdBillMaster.IpdNo = IpdRegistration.IpdNo AND IpdBillMaster.PatRegId = IpdRegistration.PatRegId LEFT OUTER JOIN "+
               " PatientInformation LEFT OUTER JOIN "+
               " Initial ON PatientInformation.TitleId = Initial.TitleId ON IpdRegistration.PatRegId = PatientInformation.PatRegId LEFT OUTER JOIN "+
               " HospEmpMst ON IpdRegistration.PrimaryDoc = HospEmpMst.DrId LEFT OUTER JOIN "+
               " BedMst INNER JOIN "+
               " AlloctnOfBed ON BedMst.BedId = AlloctnOfBed.BedId INNER JOIN "+
               " RoomMst ON BedMst.RoomId = RoomMst.RoomId INNER JOIN "+
               " RoomType ON RoomMst.RTypeId = RoomType.RTypeId ON IpdRegistration.IpdId = AlloctnOfBed.IpdId  " +
        " where  (AlloctnOfBed.PatStatus = 'Discharged')    ";
        if (txtStart.Text != "" && txtEnd.Text != "")
        {
            query += " and    AlloctnOfBed.DateofDischarge between ('" + Convert.ToDateTime(txtStart.Text).ToString("MM/dd/yyyy") + "') and ('" + Convert.ToDateTime(txtEnd.Text).AddDays(1).ToString("MM/dd/yyyy") + "')";
        }
        if (ddlreasonofdisc.SelectedValue != "0")
        {
            //ddlreasonofdisc.SelectedValue = "0";
            query += " and  AlloctnOfBed.ReasonforDischarge ='" + ddlreasonofdisc.SelectedValue + "'";
        }
        else
        {
            
           // cmd.Parameters.AddWithValue("@reasonofdisc", Convert.ToString(ddlreasonofdisc.SelectedValue));
        }
        if (ddlRoomCategory.SelectedValue != "0")
        {
            //ddlreasonofdisc.SelectedValue = "0";
            query += " and  RoomMst.RTypeId ='" + ddlRoomCategory.SelectedValue + "'";
        }
        else
        {
            
           // cmd.Parameters.AddWithValue("@reasonofdisc", Convert.ToString(ddlreasonofdisc.SelectedValue));
        }
        //.SelectedValue
        if (Convert.ToInt32(ViewState["PatientInfoId"]) > 0)
        {
            query += " and  AlloctnOfBed.AlloctnOfBed ='" + ViewState["PatientInfoId"] + "'";
        }

        cmd1.CommandText = query + ")";

        con.Open();
        cmd1.ExecuteNonQuery();
        con.Close(); con.Dispose();
    }
    protected void btnExcel_Click(object sender, EventArgs e)
    {
        string sql = "";
        //if (Convert.ToString(Session["EmrOpdNo"]) != "")
        //{
        //    objBELIO.OpdNo = Convert.ToInt32(Session["EmrOpdNo"]);
        //}
        //else
        //{
        //    objBELIO.OpdNo = 0;
        //}
        //if (Convert.ToString(Session["EmrIpdNo"]) != "")
        //{
        //    objBELIO.IpdNo = Convert.ToInt32(Session["EmrIpdNo"]);
        //}
        //else
        //{
        //    objBELIO.IpdNo = 0;
        //}
        //objBELIO.Patregid = Convert.ToInt32(Session["EmrRegNo"]);
        //objDALIO.Alter_Vw_DailyNurseNote(objBELIO);
        Alter_view();
        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Report/Rpt_PatientDischargeList.rpt");
        Session["reportname"] = "PatientDischargeList";
        Session["RPTFORMAT"] = "EXCEL";

        //ReportParameterClass.SelectionFormula = sql;
        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);
    }
}