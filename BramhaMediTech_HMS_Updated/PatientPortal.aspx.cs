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
public partial class PatientPortal : System.Web.UI.Page
{
    clsEmr obj = new clsEmr();
    DataTable dt = new DataTable();
    clsTreatmentTransaction transaction = new clsTreatmentTransaction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PindPatientInformation();

        }
    }

    public void PindPatientInformation()
    {
        DataTable dt = new DataTable();
        dt = obj.Get_AllPatientInformation_ForPAtentPortal(Convert.ToString(Session["username"]), Convert.ToString(Session["password"]), Convert.ToInt32(Session["Branchid"]));
        try
        {
            if (dt != null)
            {
                lblPatientName.Text = Convert.ToString(dt.Rows[0]["PatientName"]);
                txtpatientregid.Text = Convert.ToString(dt.Rows[0]["PatRegId"]);
                // lblIpd.Text = "0";
                //lblOpd.Text = Convert.ToString(dt.Rows[0]["PatRegId"]);
               

                lblMobileNo.Text = Convert.ToString(dt.Rows[0]["MobileNo"]);
            
                string Birthdate = Convert.ToString(dt.Rows[0]["BirthDate"]);
                Birthdate = DateTime.Parse(Birthdate).ToString("dd/MM/yyyy");
                getAge(Birthdate);
                //lblAge.Text = Convert.ToString(dt.Rows[0]["Age"]) + "" + Convert.ToString(dt.Rows[0]["AgeType"]) + "/" + Convert.ToString(dt.Rows[0]["GenderName"]);
                lblAge.Text = lblAge.Text + "/" + Convert.ToString(dt.Rows[0]["GenderName"]);
              
                lblAddress.Text = Convert.ToString(dt.Rows[0]["PatientAddress"]);
                Label6.Text = Birthdate;
                //if (Convert.ToString(dt.Rows[0]["VaccinationStatus"]) != "")
                //{
                //    lblVaccinationStatus.Text = "Vaccination Status:-" + Convert.ToString(dt.Rows[0]["VaccinationStatus"]);
                //}
                //else
                //{
                //}
                

            }
        }
        catch (Exception ex)
        {

        }
    }
    public void getAge(string Birthdate)
    {
        int intYear, intMonth, intDays;
        DateTime Birthday = Convert.ToDateTime(Birthdate);
        intYear = Birthday.Year;
        intMonth = Birthday.Month;
        intDays = Birthday.Day;

        DateTime dtt = Convert.ToDateTime(Birthdate);

        DateTime td = DateTime.Now;
        int Leap_Year = 0;
        for (int i = dtt.Year; i < td.Year; i++)
        {
            if (DateTime.IsLeapYear(i))
            {
                ++Leap_Year;
            }
        }
        TimeSpan timespan = td.Subtract(Birthday);
        intDays = timespan.Days - Leap_Year;
        int intResult = 0;
        intYear = Math.DivRem(intDays, 365, out intResult);
        intMonth = Math.DivRem(intResult, 30, out intResult);
        intDays = intResult;
        if (intYear > 0)//&& intDays > 0
        {
            lblAge.Text = intYear.ToString() + " Years";
            //ddlAge.SelectedIndex = 0;
        }
        else if (intMonth > 0)
        {
            lblAge.Text = intMonth.ToString() + " Months";
            //ddlAge.SelectedIndex = 1;
        }
        else if (intDays > 0)
        {
            lblAge.Text = intDays.ToString() + " Days";
            // ddlAge.SelectedIndex = 2;
        }
    }
    protected void GvNoteIngrid_DataBound(object sender, EventArgs e)
    {

    }
    protected void GvNoteIngrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex != -1)
        {
            int IpDNo = Convert.ToInt32((e.Row.FindControl("HdnIPDNo") as HiddenField).Value);
            if (IpDNo > 0)
            {
                e.Row.Cells[06].Text = "<span class='btn btn-xs btn-danger' >IPD</span>";
            }
            else
            {
                e.Row.Cells[06].Text = "<span class='btn btn-xs btn-success' >OPD</span>";
            }
        }
    }
    private void BindTreamentGrid(int PatRegId)
    {
        DataTable dtLabInv = new DataTable();
        // GvNoteIngrid.DataSource = transaction.GetLabInvestigationDetails(PatRegId);
        dtLabInv = transaction.GetLabInvestigationDetails(PatRegId);
        GvNoteIngrid.DataSource = dtLabInv;
        GvNoteIngrid.DataBind();
        for (int i = 0; i < GvNoteIngrid.Rows.Count; i++)
        {

            if (i > 0)
            {
                HiddenField hdnReqType = GvNoteIngrid.Rows[i].FindControl("hdnReqType") as HiddenField;
                if (i > 0)
                {
                    if (hdnReqType.Value == "L")
                    {
                        if (GvNoteIngrid.DataKeys[i].Value.ToString().Trim() == GvNoteIngrid.DataKeys[i - 1].Value.ToString().Trim())
                        {
                            GvNoteIngrid.Rows[i].Cells[0].Text = "";
                            GvNoteIngrid.Rows[i].Cells[1].Text = "";
                            GvNoteIngrid.Rows[i].Cells[2].Text = "";
                            GvNoteIngrid.Rows[i].Cells[3].Text = "";
                            GvNoteIngrid.Rows[i].Cells[4].Text = "";
                            GvNoteIngrid.Rows[i].Visible = false;
                        }
                    }

                    else
                    {
                        GvNoteIngrid.Rows[i].Cells[0].Text = "";
                        GvNoteIngrid.Rows[i].Cells[1].Text = "";
                        GvNoteIngrid.Rows[i].Cells[2].Text = "";
                    }
                }
            }
        }
    }

    private void BindTreamentGrid_Patho(int PatRegId)
    {
        DataTable dtLabInv = new DataTable();
        // GvNoteIngrid.DataSource = transaction.GetLabInvestigationDetails(PatRegId);
        dtLabInv = transaction.GetLabInvestigationDetailsPatho(PatRegId);
        GvNoteIngrid.DataSource = dtLabInv;
        GvNoteIngrid.DataBind();
        for (int i = 0; i < GvNoteIngrid.Rows.Count; i++)
        {

            if (i > 0)
            {
                HiddenField hdnReqType = GvNoteIngrid.Rows[i].FindControl("hdnReqType") as HiddenField;
                if (i > 0)
                {
                    if (hdnReqType.Value == "L")
                    {
                        if (GvNoteIngrid.DataKeys[i].Value.ToString().Trim() == GvNoteIngrid.DataKeys[i - 1].Value.ToString().Trim())
                        {
                            GvNoteIngrid.Rows[i].Cells[0].Text = "";
                            GvNoteIngrid.Rows[i].Cells[1].Text = "";
                            GvNoteIngrid.Rows[i].Cells[2].Text = "";
                            GvNoteIngrid.Rows[i].Cells[3].Text = "";
                            GvNoteIngrid.Rows[i].Cells[4].Text = "";
                            GvNoteIngrid.Rows[i].Visible = false;
                        }
                    }

                    else
                    {
                        GvNoteIngrid.Rows[i].Cells[0].Text = "";
                        GvNoteIngrid.Rows[i].Cells[1].Text = "";
                        GvNoteIngrid.Rows[i].Cells[2].Text = "";
                    }
                }
            }
        }
    }

    private void BindTreamentGrid_Radio(int PatRegId)
    {
        DataTable dtLabInv = new DataTable();
        // GvNoteIngrid.DataSource = transaction.GetLabInvestigationDetails(PatRegId);
        dtLabInv = transaction.GetLabInvestigationDetailsRadio(PatRegId);
        GvNoteIngrid.DataSource = dtLabInv;
        GvNoteIngrid.DataBind();
        for (int i = 0; i < GvNoteIngrid.Rows.Count; i++)
        {

            if (i > 0)
            {
                HiddenField hdnReqType = GvNoteIngrid.Rows[i].FindControl("hdnReqType") as HiddenField;
                if (i > 0)
                {
                    if (hdnReqType.Value == "L")
                    {
                        if (GvNoteIngrid.DataKeys[i].Value.ToString().Trim() == GvNoteIngrid.DataKeys[i - 1].Value.ToString().Trim())
                        {
                            GvNoteIngrid.Rows[i].Cells[0].Text = "";
                            GvNoteIngrid.Rows[i].Cells[1].Text = "";
                            GvNoteIngrid.Rows[i].Cells[2].Text = "";
                            GvNoteIngrid.Rows[i].Cells[3].Text = "";
                            GvNoteIngrid.Rows[i].Cells[4].Text = "";
                            GvNoteIngrid.Rows[i].Visible = false;
                        }
                    }

                    else
                    {
                        GvNoteIngrid.Rows[i].Cells[0].Text = "";
                        GvNoteIngrid.Rows[i].Cells[1].Text = "";
                        GvNoteIngrid.Rows[i].Cells[2].Text = "";
                    }
                }
            }
        }
    }
    private void BindTreamentGrid_Card(int PatRegId)
    {
        DataTable dtLabInv = new DataTable();
        // GvNoteIngrid.DataSource = transaction.GetLabInvestigationDetails(PatRegId);
        dtLabInv = transaction.GetLabInvestigationDetailsCardo(PatRegId);
        GvNoteIngrid.DataSource = dtLabInv;
        GvNoteIngrid.DataBind();
        for (int i = 0; i < GvNoteIngrid.Rows.Count; i++)
        {

            if (i > 0)
            {
                HiddenField hdnReqType = GvNoteIngrid.Rows[i].FindControl("hdnReqType") as HiddenField;
                if (i > 0)
                {
                    if (hdnReqType.Value == "L")
                    {
                        if (GvNoteIngrid.DataKeys[i].Value.ToString().Trim() == GvNoteIngrid.DataKeys[i - 1].Value.ToString().Trim())
                        {
                            GvNoteIngrid.Rows[i].Cells[0].Text = "";
                            GvNoteIngrid.Rows[i].Cells[1].Text = "";
                            GvNoteIngrid.Rows[i].Cells[2].Text = "";
                            GvNoteIngrid.Rows[i].Cells[3].Text = "";
                            GvNoteIngrid.Rows[i].Cells[4].Text = "";
                            GvNoteIngrid.Rows[i].Visible = false;
                        }
                    }

                    else
                    {
                        GvNoteIngrid.Rows[i].Cells[0].Text = "";
                        GvNoteIngrid.Rows[i].Cells[1].Text = "";
                        GvNoteIngrid.Rows[i].Cells[2].Text = "";
                    }
                }
            }
        }
    }

    private void RegisterPostBackControl()
    {
        foreach (GridViewRow row in GvNoteIngrid.Rows)
        {
            //DropDownList ddl_Receipt = row.FindControl("ddlReceipt") as DropDownList;
            Button btnPrint = row.FindControl("btnPrint") as Button;
            //ScriptManager.GetCurrent(this).RegisterPostBackControl(ddl_Receipt);
            ScriptManager.GetCurrent(this).RegisterPostBackControl(btnPrint);

        }
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        ViewState["Report"] = "True";
        Button Btnprint = (Button)sender;
        GridViewRow row = (GridViewRow)Btnprint.NamingContainer;

        this.RegisterPostBackControl();

        // DropDownList ddl_Receipt = GvNoteIngrid.Rows[row.RowIndex].FindControl("ddlReceipt") as DropDownList;
        HiddenField HdnPatrgid = GvNoteIngrid.Rows[row.RowIndex].FindControl("HdnPatRegId") as HiddenField;
        HiddenField HdnPid = GvNoteIngrid.Rows[row.RowIndex].FindControl("HdnPID") as HiddenField;
        HiddenField HdnFId = GvNoteIngrid.Rows[row.RowIndex].FindControl("HdnFId") as HiddenField;
        HiddenField HdnLabRegno = GvNoteIngrid.Rows[row.RowIndex].FindControl("HdnLabRegNo") as HiddenField;
        HiddenField HdnPType = GvNoteIngrid.Rows[row.RowIndex].FindControl("HdnPtype") as HiddenField;
        string sql = "";

        BLLReports objreports = new BLLReports();

        int BranchId = Convert.ToInt32(Session["Branchid"]);
        int FId = Convert.ToInt32(Session["FId"]);

        AlterView_VE_GetPatirntRegister(HdnPatrgid.Value);
        if (HdnPType.Value == "MediallLab")
        {
            AlterView_VE_GetLabNo(HdnPid.Value);
            //VW_DescriptiveViewLogic.SP_Getresultnondesc_Report(Convert.ToInt32(Session["Branchid"]), ViewTestCode, Request.QueryString["PatRegID"], Request.QueryString["FID"]);
            // SP_Getresultnondesc_Report();
            SP_Getresultnondesc_Report(BranchId, Convert.ToString(HdnLabRegno.Value), Convert.ToString(Session["FId"]));
            SP_Getresultdesc_Report(BranchId, Convert.ToString(HdnLabRegno.Value), Convert.ToString(Session["FId"]));



            Session.Add("rptsql", sql);
            // Session["rptname"] = Server.MapPath("~/Reports/Rpt_DischargeSummaryReport.rpt");
            Session["rptname"] = Server.MapPath("~/Reports/RptMedicalLabReport.rpt");
            Session["reportname"] = "MedicalLAbReport";
            Session["RPTFORMAT"] = "pdf";
        }
        if (HdnPType.Value == "Pathology")
        {
            AlterView_VE_GetLabNoPatho(HdnPid.Value);
            //VW_DescriptiveViewLogic.SP_Getresultnondesc_Report(Convert.ToInt32(Session["Branchid"]), ViewTestCode, Request.QueryString["PatRegID"], Request.QueryString["FID"]);
            // SP_Getresultnondesc_Report();
            //SP_Getresultnondesc_Report(BranchId, Convert.ToString(HdnLabRegno.Value), Convert.ToString(Session["FId"]));
            SP_Getresultdesc_Patho_Report(BranchId, Convert.ToString(HdnLabRegno.Value), Convert.ToString(Session["FId"]));



            Session.Add("rptsql", sql);
            // Session["rptname"] = Server.MapPath("~/Reports/Rpt_DischargeSummaryReport.rpt");
            Session["rptname"] = Server.MapPath("~/Reports/RptPatLabReport.rpt");
            Session["reportname"] = "PathoLAbReport";
            Session["RPTFORMAT"] = "pdf";
        }
        if (HdnPType.Value == "Radiology")
        {
            AlterView_VE_GetLabNoRadio(HdnPid.Value);
            //VW_DescriptiveViewLogic.SP_Getresultnondesc_Report(Convert.ToInt32(Session["Branchid"]), ViewTestCode, Request.QueryString["PatRegID"], Request.QueryString["FID"]);
            // SP_Getresultnondesc_Report();
            //SP_Getresultnondesc_Report(BranchId, Convert.ToString(HdnLabRegno.Value), Convert.ToString(Session["FId"]));
            SP_Getresultdesc_Radio_Report(BranchId, Convert.ToString(HdnLabRegno.Value), Convert.ToString(Session["FId"]));

            Session.Add("rptsql", sql);
            // Session["rptname"] = Server.MapPath("~/Reports/Rpt_DischargeSummaryReport.rpt");
            Session["rptname"] = Server.MapPath("~/Reports/RptRadioLabReport.rpt");
            Session["reportname"] = "RadioLAbReport";
            Session["RPTFORMAT"] = "pdf";
        }
        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);

    }
    public static int SP_Getresultnondesc_Report(int branchid, string PatRegID, string FID)
    {
        int i = 0;
        SqlConnection conn = DataAccess.ConInitForMedical();
        SqlCommand sc = new SqlCommand();
        sc.Connection = conn;
        sc.CommandType = CommandType.StoredProcedure;
        sc.CommandText = "SP_phdatarecfrm_MediLab";
        sc.Parameters.AddWithValue("@branchid", branchid);

        sc.Parameters.AddWithValue("@PatRegID", PatRegID);
        sc.Parameters.AddWithValue("@FID", FID);
        try
        {
            conn.Open();
            sc.ExecuteNonQuery();
        }
        catch
        {
            throw;
        }
        finally
        {
            conn.Close();
            conn.Dispose();
        }
        return i;
    }
    public static int SP_Getresultdesc_Report(int branchid, string PatRegID, string FID)
    {
        int i = 0;
        SqlConnection conn = DataAccess.ConInitForMedical();
        SqlCommand sc = new SqlCommand();
        sc.Connection = conn;
        sc.CommandType = CommandType.StoredProcedure;
        sc.CommandText = "SP_phraddata_MediLab";
        sc.Parameters.AddWithValue("@branchid", branchid);

        sc.Parameters.AddWithValue("@PatRegID", PatRegID);
        sc.Parameters.AddWithValue("@FID", FID);
        try
        {
            conn.Open();
            sc.ExecuteNonQuery();
        }
        catch
        {
            throw;
        }
        finally
        {
            conn.Close();
            conn.Dispose();
        }
        return i;
    }

    public static int SP_Getresultdesc_Patho_Report(int branchid, string PatRegID, string FID)
    {
        int i = 0;
        SqlConnection conn = DataAccess.ConInitForPathology();
        SqlCommand sc = new SqlCommand();
        sc.Connection = conn;
        sc.CommandType = CommandType.StoredProcedure;
        sc.CommandText = "SP_phraddata_Pathology";
        sc.Parameters.AddWithValue("@branchid", branchid);

        sc.Parameters.AddWithValue("@PatRegID", PatRegID);
        sc.Parameters.AddWithValue("@FID", FID);
        try
        {
            conn.Open();
            sc.ExecuteNonQuery();
        }
        catch
        {
            throw;
        }
        finally
        {
            conn.Close();
            conn.Dispose();
        }
        return i;
    }
    public static int SP_Getresultdesc_Radio_Report(int branchid, string PatRegID, string FID)
    {
        int i = 0;
        SqlConnection conn = DataAccess.ConInitForRadiology();
        SqlCommand sc = new SqlCommand();
        sc.Connection = conn;
        sc.CommandType = CommandType.StoredProcedure;
        sc.CommandText = "SP_phraddata_Radiology";
        sc.Parameters.AddWithValue("@branchid", branchid);

        sc.Parameters.AddWithValue("@PatRegID", PatRegID);
        sc.Parameters.AddWithValue("@FID", FID);
        try
        {
            conn.Open();
            sc.ExecuteNonQuery();
        }
        catch
        {
            throw;
        }
        finally
        {
            conn.Close();
            conn.Dispose();
        }
        return i;
    }

    public void AlterView_VE_GetLabNo(string PID)
    {
        int i;
        SqlConnection conn = DataAccess.ConInitForMedical();
        SqlCommand sc = conn.CreateCommand();
        sc.CommandText = "ALTER VIEW [dbo].[VW_GetLabNo]AS (select  LabNo,patmst.PatRegID,MTCode,patmst.Branchid,patmst.FID FROM   patmstd INNER JOIN patmst ON patmstd.PatRegID = patmst.PatRegID AND patmstd.PID = patmst.PID  where patmstd.Patauthicante='Authorized' and  patmst.PID='" + PID + "'  and patmst.branchid ='" + Convert.ToInt32(Session["Branchid"]) + "' and  patmst.FID ='" + Convert.ToString(Session["FId"]) + "' )";
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
    public void AlterView_VE_GetLabNoPatho(string PID)
    {
        int i;
        SqlConnection conn = DataAccess.ConInitForPathology();
        SqlCommand sc = conn.CreateCommand();
        sc.CommandText = "ALTER VIEW [dbo].[VW_GetLabNo]AS (select  LabNo,patmst.PatRegID,MTCode,patmst.Branchid,patmst.FID FROM   patmstd INNER JOIN patmst ON patmstd.PatRegID = patmst.PatRegID AND patmstd.PID = patmst.PID  where  patmstd.Patauthicante='Authorized' and  patmst.PID='" + PID + "'  and patmst.branchid ='" + Convert.ToInt32(Session["Branchid"]) + "' and  patmst.FID ='" + Convert.ToString(Session["FId"]) + "' )";
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
    public void AlterView_VE_GetLabNoRadio(string PID)
    {
        int i;
        SqlConnection conn = DataAccess.ConInitForRadiology();
        SqlCommand sc = conn.CreateCommand();
        sc.CommandText = "ALTER VIEW [dbo].[VW_GetLabNo]AS (select  LabNo,patmst.PatRegID,MTCode,patmst.Branchid,patmst.FID FROM   patmstd INNER JOIN patmst ON patmstd.PatRegID = patmst.PatRegID AND patmstd.PID = patmst.PID  where  patmstd.Patauthicante='Authorized' and  patmst.PID='" + PID + "'  and patmst.branchid ='" + Convert.ToInt32(Session["Branchid"]) + "' and  patmst.FID ='" + Convert.ToString(Session["FId"]) + "' )";
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


    public void AlterView_VE_GetPatirntRegister(string PatRegId)
    {
        int i;
        SqlConnection conn = DataAccess.ConInitForDC();
        SqlCommand sc = conn.CreateCommand();
        //sc.CommandText = "ALTER VIEW [dbo].[VW_GetPatientInformation]AS (SELECT        PatientInformation.PatientInfoId, PatientInformation.PatRegId, PatientInformation.BarcodeId, PatientInformation.TitleId, "+
        //                 "   Initial.Title +' '+PatientInformation.FirstName as PatientName, PatientInformation.MiddleName, PatientInformation.LastName,  "+
        //                 "   PatientInformation.PatMainTypeId, PatientInformation.PatientInsuTypeId, PatientInformation.PolicyNo, PatientInformation.GenderId, PatientInformation.BirthDate, PatientInformation.IsConfirmBirthDate, "+
        //                 "   PatientInformation.BloodGroup, PatientInformation.MaritalStatus, PatientInformation.GuardianTitleId, PatientInformation.GuardianName, PatientInformation.MobileNo, PatientInformation.PhoneNo, "+
        //                 "   PatientInformation.PatientAddress, PatientInformation.CountryId, PatientInformation.StateId, PatientInformation.CityId, PatientInformation.Email, PatientInformation.EntryDate, PatientInformation.ImagePath, "+
        //                 "   PatientInformation.CancelReason, PatientInformation.IsActive, PatientInformation.CreatedBy, PatientInformation.CreatedOn, PatientInformation.UpdatedBy, PatientInformation.UpdatedOn, PatientInformation.Age, "+
        //                 "   PatientInformation.AgeType, PatientInformation.BranchId, PatientInformation.FId,  Gender.GenderName "+
        //                 "   FROM            PatientInformation INNER JOIN "+
        //                 "   Initial ON PatientInformation.TitleId = Initial.TitleId INNER JOIN "+
        //                 "   Gender ON PatientInformation.GenderId = Gender.GenderId  where  PatientInformation.PatRegId='" + PatRegId + "'  and PatientInformation.branchid ='" + Convert.ToInt32(Session["Branchid"]) + "'  )";


        sc.CommandText = "ALTER VIEW [dbo].[VW_GetPatientInformation]AS (SELECT        PatientInformation.PatientInfoId, PatientInformation.PatRegId, PatientInformation.BarcodeId, PatientInformation.TitleId, " +
                         "   Initial.Title +' '+PatientInformation.FirstName as PatientName, PatientInformation.MiddleName, PatientInformation.LastName,  " +
                         "   PatientInformation.PatMainTypeId, PatientInformation.PatientInsuTypeId, PatientInformation.PolicyNo, PatientInformation.GenderId, PatientInformation.BirthDate, PatientInformation.IsConfirmBirthDate, " +
                         "   PatientInformation.BloodGroup, PatientInformation.MaritalStatus, PatientInformation.GuardianTitleId, PatientInformation.GuardianName, PatientInformation.MobileNo, PatientInformation.PhoneNo, " +
                         "   PatientInformation.PatientAddress, PatientInformation.CountryId, PatientInformation.StateId, PatientInformation.CityId, PatientInformation.Email, PatientInformation.EntryDate, PatientInformation.ImagePath, " +
                         "   PatientInformation.CancelReason, PatientInformation.IsActive, PatientInformation.CreatedBy, PatientInformation.CreatedOn, PatientInformation.UpdatedBy, PatientInformation.UpdatedOn, PatientInformation.Age, " +
                         "   PatientInformation.AgeType, PatientInformation.BranchId, PatientInformation.FId, 0 as TokenNo,  0 as VisitingNo,  ' ' as DeptName,0 as DrId,0 as OpdNo,0 as IpdNo,' ' as DrName, Gender.GenderName " +
                         "   FROM            PatientInformation INNER JOIN " +
                         "   Initial ON PatientInformation.TitleId = Initial.TitleId INNER JOIN " +
                         "   Gender ON PatientInformation.GenderId = Gender.GenderId  where  PatientInformation.PatRegId='" + PatRegId + "'  and PatientInformation.branchid ='" + Convert.ToInt32(Session["Branchid"]) + "'  )";



        //sc.CommandText = "ALTER VIEW [dbo].[VW_GetPatientInformation]AS (SELECT DISTINCT  Initial.Title, PatientInformation.PatientInfoId, PatientInformation.PatRegId, "+
        //" PatientInformation.BarcodeId, PatientInformation.TitleId, PatientInformation.FirstName, " +
        //" Initial.Title + ' ' + PatientInformation.FirstName AS PatientName,  PatientInformation.MiddleName, " +
        //" PatientInformation.LastName, PatientInformation.PatMainTypeId, PatientInformation.PatientInsuTypeId, " +
        //" PatientInformation.PolicyNo, PatientInformation.GenderId, PatientInformation.BirthDate, "+
        //" PatientInformation.IsConfirmBirthDate, PatientInformation.BloodGroup, PatientInformation.MaritalStatus, "+
        //"  PatientInformation.GuardianTitleId, PatientInformation.GuardianName, PatientInformation.MobileNo, "+
        //"  PatientInformation.PhoneNo, PatientInformation.PatientAddress, PatientInformation.CountryId, "+
        //"  PatientInformation.StateId, PatientInformation.CityId, PatientInformation.Email, "+
        //"  PatientInformation.EntryDate,  PatientInformation.ImagePath, PatientInformation.CancelReason, "+
        //"  PatientInformation.IsActive, PatientInformation.CreatedBy, PatientInformation.CreatedOn, "+
        //"  PatientInformation.UpdatedBy, PatientInformation.UpdatedOn,PatientInformation.BranchId,PatientInformation.FId,PatientInformation.Age, " +
        //"  PatientInformation.AgeType, IpdRegistration.IpdNo, Gender.GenderName, HospEmpMst.Title + ' ' + HospEmpMst.Empname AS DrName,"+
        //"  0 as TokenNo, IpdRegistration.VisitingNo,  DepartmentMst.DeptName, "+
        //"  IpdRegistration.PrimaryDoc as DrId,0 as OpdNo   FROM   "+
        //"  PatientInformation INNER JOIN  IpdRegistration ON PatientInformation.PatRegId = IpdRegistration.PatRegId LEFT OUTER JOIN "+
        //"  HospEmpMst ON IpdRegistration.PrimaryDoc = HospEmpMst.DrId LEFT OUTER JOIN  DepartmentMst ON IpdRegistration.DeptId = DepartmentMst.DeptId LEFT OUTER JOIN "+ 
        //"  Initial ON PatientInformation.TitleId = Initial.TitleId LEFT OUTER JOIN  Gender ON PatientInformation.GenderId = Gender.GenderId "+
        //"  where  PatientInformation.PatRegId='" + PatRegId + "'  and PatientInformation.branchid ='" + Convert.ToInt32(Session["Branchid"]) + "'  )";


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


    public void AlterView_VE_GetInvestigationDet(string PatRegId)
    {
        int i;
        SqlConnection conn = DataAccess.ConInitForDC();
        SqlCommand sc = conn.CreateCommand();
        sc.CommandText = "ALTER VIEW [dbo].[VW_MedicalTest]AS (SELECT DISTINCT  " +
                 "   'MediallLab' AS Ptype, LabEMRRegistration.LabNo, LabEMRServiceDetails.MTCode, LabEMRServiceDetails.ServiceName AS testname, 0 AS PID, LabEMRRegistration.ReferBy AS Drname, CONVERT(varchar(20),  " +
                 "   LabEMRRegistration.Entrydate, 103) + ' ' + CONVERT(varchar(20), CONVERT(time, LabEMRRegistration.Entrydate), 100) AS RegDate, LabEMRServiceDetails.PatRegId, LabEMRServiceDetails.BranchId,  " +
                 "   LabEMRServiceDetails.FId, 0 AS LabRegNo, LabEMRServiceDetails.ServiceName " +
                 "   FROM            LabEMRServiceDetails INNER JOIN " +
                 "   LabEMRRegistration ON LabEMRServiceDetails.LabNo = LabEMRRegistration.LabNo AND LabEMRServiceDetails.PatRegId = LabEMRRegistration.PatRegId " +
                "  where  LabEMRRegistration.PatRegId='" + PatRegId + "'  and LabEMRRegistration.CancelBill=0 and  LabEMRRegistration.LabPtype='M' order by LabEMRRegistration.LabNo desc )";
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
    protected void btnpathology_Click(object sender, EventArgs e)
    {
        BindTreamentGrid_Patho(Convert.ToInt32(txtpatientregid.Text));
    }
    protected void btnMedicalLab_Click(object sender, EventArgs e)
    {
        BindTreamentGrid(Convert.ToInt32(txtpatientregid.Text));
    }
    protected void btnreadiology_Click(object sender, EventArgs e)
    {
        BindTreamentGrid_Radio(Convert.ToInt32(txtpatientregid.Text));
    }
    protected void btncardiology_Click(object sender, EventArgs e)
    {
        BindTreamentGrid_Card(Convert.ToInt32(txtpatientregid.Text));
    }
}