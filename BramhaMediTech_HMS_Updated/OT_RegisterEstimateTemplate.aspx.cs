﻿using System;
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

public partial class OT_RegisterEstimateTemplate :BasePage
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
            using (SqlCommand cmd = new SqlCommand("Sp_Vw_EstimateTemplate", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FId", Convert.ToInt32(Session["FId"]));
                cmd.Parameters.AddWithValue("@BranchId", Convert.ToInt32(Session["Branchid"]));
                
                cmd.Parameters.AddWithValue("@start", txtStart.Text);
                cmd.Parameters.AddWithValue("@end", txtEnd.Text);

                cmd.Parameters.AddWithValue("@Operation", Convert.ToInt32(ViewState["Operation"]));
                //cmd.Parameters.AddWithValue("@anesticia", Convert.ToInt32(ViewState["anesticia"]));
                cmd.Parameters.AddWithValue("@SurganID", Convert.ToInt32(ViewState["SurganID"]));
                //cmd.Parameters.AddWithValue("@Dieseas", Convert.ToInt32(ViewState["Dieseas"]));

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
           // pcount.Text = "Total OT Patient Count: " + dt.Rows.Count;

        }

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        refreshdata();
        //ViewState["SurganID"] = 0;
        //ViewState["anesticia"] = 0;
        //ViewState["Operation"] = 0;
        //ViewState["PatientInfoId"] = 0;
        //ViewState["Dieseas"] = 0;
    }

    //protected void gvPatientInfo_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    BLLReports objreports = new BLLReports();
    //    string sql = "";
    //    if (e.CommandName == "Select")
    //    {

    //        //Determine the RowIndex of the Row whose Button was clicked.
    //        int rowIndex = Convert.ToInt32(e.CommandArgument);

    //        //Reference the GridView Row.
    //        GridViewRow row = gvPatientInfo.Rows[rowIndex];
    //        int OTID = Convert.ToInt32(gvPatientInfo.DataKeys[rowIndex].Values["OTId"]);

    //        string PatRegId = gvPatientInfo.Rows[rowIndex].Cells[1].Text;
    //        string IPDNO = gvPatientInfo.Rows[rowIndex].Cells[2].Text;

    //        // string response = @"~/frmTreatment2.aspx?RegId=" + regId + "&OpdNo=" + opd + "&Name=" + name + "&EntryDate=" + entryDate;
    //        // string response = @"~/IpdAdvancePayment.aspx?RegId=" + PatRegId + "&IpdId=" + IpdId;
    //        string response = "";
    //        int GenOT = Convert.ToInt32((gvPatientInfo.Rows[rowIndex].FindControl("HdnGeneralOT") as HiddenField).Value.Trim());
    //        if (GenOT == 0)
    //        {
    //            response = @"~/OTOPTORegisterAdd.aspx?RegId=" + PatRegId + "&IpdId=" + IPDNO + "&OTID=" + OTID;
    //        }
    //        else
    //        {
    //            response = @"~/OTGeneralRegisterAdd.aspx?RegId=" + PatRegId + "&IpdId=" + IPDNO + "&OTID=" + OTID;
    //        }

    //        Response.Redirect(string.Format(response));

    //        // ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Name: " + name + "\\nRegId: " + regId + "');", true);
    //    }

    //    if (e.CommandName == "Notes")
    //    {
    //        //Determine the RowIndex of the Row whose Button was clicked.
    //        int rowIndex = Convert.ToInt32(e.CommandArgument);

    //        //Reference the GridView Row.
    //        GridViewRow row = gvPatientInfo.Rows[rowIndex];
    //        int OTID = Convert.ToInt32(gvPatientInfo.DataKeys[rowIndex].Values["OTId"]);

    //        string PatRegId = gvPatientInfo.Rows[rowIndex].Cells[1].Text;
    //        string IPDNO = gvPatientInfo.Rows[rowIndex].Cells[2].Text;

    //        // string response = @"~/frmTreatment2.aspx?RegId=" + regId + "&OpdNo=" + opd + "&Name=" + name + "&EntryDate=" + entryDate;
    //        // string response = @"~/IpdAdvancePayment.aspx?RegId=" + PatRegId + "&IpdId=" + IpdId;
    //        string response = "";
    //        int GenOT = Convert.ToInt32((gvPatientInfo.Rows[rowIndex].FindControl("HdnGeneralOT") as HiddenField).Value.Trim());
    //        if (GenOT == 0)
    //        {
    //            response = @"~/OTNotes.aspx?RegId=" + PatRegId + "&IpdId=" + IPDNO + "&OTID=" + OTID;
    //        }
    //        else
    //        {
    //            response = @"~/OTNotes.aspx?RegId=" + PatRegId + "&IpdId=" + IPDNO + "&OTID=" + OTID;
    //        }

    //        Response.Redirect(string.Format(response));

    //        // ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Name: " + name + "\\nRegId: " + regId + "');", true);
    //    }
    //    if (e.CommandName == "Summary")
    //    {

    //        int rowIndex = Convert.ToInt32(e.CommandArgument);
    //        GridViewRow row = gvPatientInfo.Rows[rowIndex];
    //        int PatRegId = Convert.ToInt32(gvPatientInfo.Rows[rowIndex].Cells[1].Text);
    //        int IPDNO = Convert.ToInt32(gvPatientInfo.Rows[rowIndex].Cells[2].Text);
    //        int BranchId = Convert.ToInt32(Session["Branchid"]);
    //        int FId = Convert.ToInt32(Session["FId"]);
    //        // objreports.IpdBillSummary(IpdId, PatRegId);

    //        objreports.IpdBillDetails(IPDNO, PatRegId, FId, BranchId);
    //        Session.Add("rptsql", sql);
    //        // Session["rptname"] = Server.MapPath("~/Reports/Rpt_IpdBillSummary.rpt");
    //        Session["rptname"] = Server.MapPath("~/Reports/Rpt_IpdBillDetails_summary.rpt");
    //        Session["reportname"] = "IpdBillSummary_Report";
    //        Session["RPTFORMAT"] = "pdf";


    //        string close = "<script language='javascript'>javascript:OpenReport();</script>";
    //        Type title1 = this.GetType();
    //        Page.ClientScript.RegisterStartupScript(title1, "", close);


    //    }

    //}

    protected void gvPatientInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvPatientInfo.PageIndex = e.NewPageIndex;
        refreshdata();
    }
    
    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchPatient(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        return objDALOpdReg.FillAllPatient(prefixText);
    }
    [ScriptMethod()]
    [WebMethod]
    public static List<string> Searchsurgan(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        return objDALOpdReg.FillAllSurgan(prefixText);
    }


    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchAnaesthetist(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        return objDALOpdReg.FillAllAnaesthetist(prefixText);
    }
    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchOperaation(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        string Type = "1";
        return objDALOpdReg.FillAllOperation_Search(prefixText, Type);
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
    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchDisease(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        // string Type = Convert.ToString(HttpContext.Current.Session["UID"]);
        string Type = "1";

        return objDALOpdReg.FillAllDisease_search(prefixText, Type);
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
        }
    }
    protected void txtanesticia_TextChanged(object sender, EventArgs e)
    {
        if (txtanesticia.Text != "")
        {
            string[] PatientInfo = txtanesticia.Text.Split('-');
            if (PatientInfo.Length == 2)
            {
                txtanesticia.Text = PatientInfo[1];
                ViewState["anesticia"] = PatientInfo[0];
            }
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
        }
    }
    protected void txtdieses_TextChanged(object sender, EventArgs e)
    {
        if (txtdieses.Text != "")
        {
            string[] PatientInfo = txtdieses.Text.Split('-');
            if (PatientInfo.Length == 2)
            {
                txtdieses.Text = PatientInfo[1];
                ViewState["Dieseas"] = PatientInfo[0];
            }
        }
    }
    protected void btnReport_Click(object sender, EventArgs e)
    {
        int BranchId = Convert.ToInt32(Session["Branchid"]);
        int FId = Convert.ToInt32(Session["FId"]);
       // string sql = "";
        DataSet Batchwisestock = new DataSet();
        ReportDocument crystalReport = new ReportDocument();


        crystalReport.Load(Server.MapPath("~/Report/Rpt_OTEstimateTemplate.rpt"));
        Batchwisestock=refreshdata_Report();
        crystalReport.SetDataSource(Batchwisestock);
        //crystalReport.ParameterFields["FromDate"].CurrentValues.AddValue(Convert.ToString(ViewState["FromDate"]));

        crystalReport.ExportToHttpResponse
        (CrystalDecisions.Shared.ExportFormatType.ExcelWorkbook, Response, false, "EstimateTemplate");
                
       
        //Session.Add("rptsql", sql);
        //Session["rptname"] = Server.MapPath("~/Reports/Rpt_OTEstimateTemplate.rpt");//Rpt_ProcedureBillDetails
        //Session["reportname"] = "Rpt_OTEstimateTemplate";
        //Session["RPTFORMAT"] = "EXCEL";


        //string close = "<script language='javascript'>javascript:OpenReport();</script>";
        //Type title1 = this.GetType();
        //Page.ClientScript.RegisterStartupScript(title1, "", close);
    }

    public DataSet refreshdata_Report()
    {
       // DataTable dt = new DataTable();

        using (SqlConnection con = DataAccess.ConInitForDC())
        {
           
            using (SqlCommand cmd = new SqlCommand("Sp_Vw_EstimateTemplate", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FId", Convert.ToInt32(Session["FId"]));
                cmd.Parameters.AddWithValue("@BranchId", Convert.ToInt32(Session["Branchid"]));
                
                cmd.Parameters.AddWithValue("@start", txtStart.Text);
                cmd.Parameters.AddWithValue("@end", txtEnd.Text);

                cmd.Parameters.AddWithValue("@Operation", Convert.ToInt32(ViewState["Operation"]));
                cmd.Parameters.AddWithValue("@SurganID", Convert.ToInt32(ViewState["SurganID"]));

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                ds.Tables[0].TableName = "Vw_EstimateTemplate";
                return ds;
            }
           
            //gvPatientInfo.DataSource = dt;
            //gvPatientInfo.DataBind();
            //pcount.Text = "Total OT Patient Count: " + dt.Rows.Count;

        }

    }
}