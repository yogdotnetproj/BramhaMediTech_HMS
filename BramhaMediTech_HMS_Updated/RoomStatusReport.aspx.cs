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

public partial class RoomStatusReport : System.Web.UI.Page
{
    BELRoom objBELRoom = new BELRoom();
    DALRoom objDALRoom = new DALRoom();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillRoomTypeDrop();
            FillRoomStatusGrid();
        }

    }
    protected void FillRoomTypeDrop()
    {
        ddlRoomTypeName.DataSource = objDALRoom.FillRoomTypeCombo();
        ddlRoomTypeName.DataTextField = "RType";
        ddlRoomTypeName.DataValueField = "RTypeId";
        ddlRoomTypeName.DataBind();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Alter_view();
        FillRoomStatusGrid();

    }
    protected void FillRoomStatusGrid()
    {
        gvRoomMaster.DataSource = objDALRoom.FillRoomStatusGrid(Convert.ToInt32(ddlRoomTypeName.SelectedValue));
        gvRoomMaster.DataBind();
    }
    protected void gvRoomMaster_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Details")
        {
            //Determine the RowIndex of the Row whose Button was clicked.
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            //Reference the GridView Row.
            GridViewRow row = gvRoomMaster.Rows[rowIndex];
            int RoomId = Convert.ToInt32(gvRoomMaster.DataKeys[rowIndex].Values["RoomId"]);
            ViewState["RoomId"] = RoomId;
            GvBedDetails.DataSource = objDALRoom.FillBedDetailsGrid(RoomId);
            GvBedDetails.DataBind();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "openModal();", true);
        }

    }
    protected void gvRoomMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvRoomMaster.PageIndex = e.NewPageIndex;
        FillRoomStatusGrid();

    }
    //protected void GvBedDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    GvBedDetails.PageIndex = e.NewPageIndex;
    //    GvBedDetails.DataSource = objDALRoom.FillBedDetailsGrid(Convert.ToInt32(ViewState["RoomId"]));
    //    GvBedDetails.DataBind();
    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "openModal();", true);

    //}
    protected void btnReport_Click(object sender, EventArgs e)
    {
        try
        {
            //BLLReports objBLLReports = new BLLReports();
            //DataSet dsCustomers = new DataSet();
            //ReportDocument crystalReport = new ReportDocument();
            //crystalReport.Load(Server.MapPath("~/Report/Rpt_CaseReport.rpt"));
            //// dsCustomers = objBLLReports.CaseReport(Convert.ToString(ViewState["PatientRegistrationID"]));
            //crystalReport.SetDataSource(dsCustomers);
            //crystalReport.ParameterFields["HospitalName"].CurrentValues.AddValue(Convert.ToString(Application["OrgnizationName"]));
            //crystalReport.ParameterFields["HospitalAddress"].CurrentValues.AddValue(Convert.ToString(Application["OrgnizationAddress"]));
            ////crystalReport.ParameterFields["Image"].CurrentValues.AddValue(Application["ImagePath"]);
            //crystalReport.ParameterFields["ReportFooter"].CurrentValues.AddValue("Hospital Software | Ph.020 0000000000");
            //crystalReport.ExportToHttpResponse
            //(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Employee");
            Alter_view();
            string sql = "";
            Session.Add("rptsql", sql);
            Session["rptname"] = Server.MapPath("~/Report/Rpt_RoomStatusReport.rpt");
            Session["reportname"] = "Rpt_RoomStatusReport";
            Session["RPTFORMAT"] = "pdf";

            //ReportParameterClass.SelectionFormula = sql;
            string close = "<script language='javascript'>javascript:OpenReport();</script>";
            Type title1 = this.GetType();
            Page.ClientScript.RegisterStartupScript(title1, "", close);
        }
        catch (Exception ex)
        {
            throw ex;
            //lblMessage.Text = ex.Message;
        }
    }
    protected void btnDetailReport_Click(object sender, EventArgs e)
    {
        Alter_viewDetails();
        string sql = "";
        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Report/Rpt_RoomStatusDetailsReport.rpt");
        Session["reportname"] = "Rpt_RoomStatusDetailsReport";
        Session["RPTFORMAT"] = "pdf";

        //ReportParameterClass.SelectionFormula = sql;
        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);
    }

    protected void btnDetailExcelReport_Click(object sender, EventArgs e)
    {
        Alter_viewDetails();
        string sql = "";
        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Report/Rpt_RoomStatusDetailsReport.rpt");
        Session["reportname"] = "Rpt_RoomStatusDetailsReport";
        Session["RPTFORMAT"] = "EXCEL";

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

        string query = "ALTER VIEW [dbo].[Vw_RoomSatus] AS (SELECT t.RoomId, t.RoomName, t.TotalBeds, t.RTypeId, t.RType, t.RoomAddress, t.TotalBeds - ISNULL(at.occupied, 0) AS Unoccupied, ISNULL(at.occupied, 0)    AS occupied  " +
                  "  FROM    (SELECT dbo.RoomMst.RoomName, ISNULL(dbo.RoomMst.TotalBeds, 0) AS TotalBeds, dbo.RoomType.RType, dbo.RoomMst.FId, dbo.RoomMst.RTypeId,   " +
                   "         dbo.RoomMst.BranchId, dbo.RoomMst.RoomAddress, dbo.RoomMst.RoomId  " +
                   " FROM     dbo.RoomMst LEFT OUTER JOIN  " +
                   "         dbo.RoomType ON dbo.RoomMst.RTypeId = dbo.RoomType.RTypeId ";
                   if(Convert.ToInt32(ddlRoomTypeName.SelectedValue)>0)
                   {
            query +=   "  where RoomType.RTypeId=" + Convert.ToInt32(ddlRoomTypeName.SelectedValue) + "   ";
                   }
         query += " ) AS t LEFT OUTER JOIN  " +
                   " (SELECT dbo.BedMst.RoomId, ISNULL(COUNT(dbo.AlloctnOfBed.BedId), 0) AS occupied, dbo.AlloctnOfBed.FId, dbo.AlloctnOfBed.BranchId  "+
                   " FROM     dbo.AlloctnOfBed LEFT OUTER JOIN  "+
                   "             dbo.BedMst ON dbo.AlloctnOfBed.BedId = dbo.BedMst.BedId  "+
                   " WHERE  (dbo.AlloctnOfBed.PatStatus = 'Admitted')  "+
                   " GROUP BY dbo.BedMst.RoomId, dbo.AlloctnOfBed.FId, dbo.AlloctnOfBed.BranchId) AS at ON t.RoomId = at.RoomId  " ;
        //" where OpdRegistration.branchid=" + Convert.ToInt32(Session["Branchid"]) + "  ";
        //if (txtFrom.Value != "" && txtTo.Value != "")
        //{
        //    query += " and    ANCExamination.CreatedOn between ('" + Convert.ToDateTime(txtFrom.Value).ToString("MM/dd/yyyy") + "') and ('" + Convert.ToDateTime(txtTo.Value).AddDays(1).ToString("MM/dd/yyyy") + "')";
        //}



        cmd1.CommandText = query + ")";

        con.Open();
        cmd1.ExecuteNonQuery();
        con.Close(); con.Dispose();
    }

    public void Alter_viewDetails()
    {
        string sql = "";
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd1 = con.CreateCommand();

        string query = "ALTER VIEW [dbo].[Vw_RoomSatus_Details] AS (SELECT        BedMst.BedName, PatientInformation.PatRegId, BedMst.RoomId, BedMst.BedId, Initial.Title + ' ' + PatientInformation.FirstName AS PatientName, BedMst.RoomAddress, RoomMst.RoomName, RoomMst.TotalBeds, " +
                 "   RoomType.RType, AlloctnOfBed.PatStatus "+
                 "   FROM            RoomMst INNER JOIN "+
                 "   RoomType ON RoomMst.RTypeId = RoomType.RTypeId LEFT OUTER JOIN "+
                 "   BedMst ON RoomMst.RoomId = BedMst.RoomId LEFT OUTER JOIN "+
                 "   AlloctnOfBed ON BedMst.BedId = AlloctnOfBed.BedId LEFT OUTER JOIN "+
                 "   PatientInformation ON AlloctnOfBed.PatRegId = PatientInformation.PatRegId LEFT OUTER JOIN "+
                 "   Initial ON PatientInformation.TitleId = Initial.TitleId where AlloctnOfBed.PatStatus ='Admitted'  ";

        if (Convert.ToInt32(ddlRoomTypeName.SelectedValue) > 0)
        {
            query += "  and RoomType.RTypeId=" + Convert.ToInt32(ddlRoomTypeName.SelectedValue) + "   ";
        }


        cmd1.CommandText = query + ")";

        con.Open();
        cmd1.ExecuteNonQuery();
        con.Close(); con.Dispose();
    }
}