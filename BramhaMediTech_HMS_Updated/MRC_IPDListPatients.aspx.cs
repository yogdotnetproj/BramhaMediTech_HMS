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

public partial class MRC_IPDListPatients :BasePage
{
    BELOPDPatReg objBELOpdReg = new BELOPDPatReg();
    DALOpdReg objDALOpdReg = new DALOpdReg();
    BELEmpReg objBELEmpReg = new BELEmpReg();
    DALEmpReg objDALEmpReg = new DALEmpReg();
    BLLReports objReports = new BLLReports();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Convert.ToString(Session["Branchid"]) == "")
            {
                Response.Redirect("~/Login.aspx", false);
                return;
            }
            if (Convert.ToString(Session["Branchid"]) == "0")
            {
                Response.Redirect("~/Login.aspx", false);
                return;
            }
            if (Convert.ToString(Session["Branchid"]) == null)
            {
                Response.Redirect("~/Login.aspx", false);
                return;
            }
            txtStart.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtEnd.Text = DateTime.Now.ToString("dd/MM/yyyy");
           // txtOpdNo.Text = "0";
            if (Convert.ToString(Session["usertype"]) == "Doctor")
            {
              
                    txtConsDoctorName.Text=Convert.ToString( Session["EmpId"])+"-"+ Convert.ToString( Session["Name"]) ;
                    ViewState["ConsultID"] = Convert.ToString(Session["EmpId"]);
            }
            if (Session["Usertype"].ToString() == "Administrator" || Session["Usertype"].ToString() == "Admin")
            {
                LoadRoomType();
                refreshdata1();
                GVOP.Visible = false;
                GVIP.Visible = true;
               
               // FillDepartmentDrop();
            }
            else
            {
               // LoadConsultantDocByEmpId();
               // FillDepartmentDropByEmpId();
                LoadRoomType();
                refreshdata1();
                GVOP.Visible = false;
                GVIP.Visible = true;

            }

        }
    }
    private void LoadRoomType()
    {

        ddlroomtype.DataSource = objDALOpdReg.FillRoomType();
        ddlroomtype.DataValueField = "RTypeId";
        ddlroomtype.DataTextField = "RType";
        ddlroomtype.DataBind();
    }
    //protected void FillDepartmentDrop()
    //{
    //    ddlDepartment.DataSource = objDALEmpReg.FillDeptDrop();
    //    ddlDepartment.DataValueField = "DeptId";
    //    ddlDepartment.DataTextField = "DeptName";
    //    ddlDepartment.DataBind();
    //}
    //private void LoadConsultantDocByEmpId()
    //{

    //    ddlConsDoctorName.DataSource = objDALOpdReg.FillConsultantDocNameByEmpId(Convert.ToInt32(Session["EmpId"]));
    //    ddlConsDoctorName.DataValueField = "DrId";
    //    ddlConsDoctorName.DataTextField = "EmpName";
    //    ddlConsDoctorName.DataBind();
    //}
    //protected void FillDepartmentDropByEmpId()
    //{
    //    ddlDepartment.DataSource = objDALEmpReg.FillDepartmentDropByEmpId(Convert.ToInt32(Session["EmpId"]));
    //    ddlDepartment.DataValueField = "DeptId";
    //    ddlDepartment.DataTextField = "DeptName";
    //    ddlDepartment.DataBind();
    //}
    //public void refreshdata()
    //{
    //    DataTable dt = new DataTable();
    //    //if (txtOpdNo.Text == "")
    //    //{
    //    //    txtOpdNo.Text = "0";
    //    //}
    //    using (SqlConnection con = DataAccess.ConInitForDC())
    //    {
    //        using (SqlCommand cmd = new SqlCommand("usp_GetPatientListForEMR", con))
    //        {
    //            cmd.CommandType = CommandType.StoredProcedure;
    //            cmd.Parameters.AddWithValue("@FId",Convert.ToInt32(Session["FId"]));
    //            cmd.Parameters.AddWithValue("@BranchId", Convert.ToInt32(Session["Branchid"]));
    //            if (txtOpdNo.Text == "")
    //            {
    //                cmd.Parameters.AddWithValue("@OpdNo", Convert.ToInt32(0));
    //            }
    //            else
    //            {
    //                cmd.Parameters.AddWithValue("@OpdNo", Convert.ToInt32(txtOpdNo.Text));
    //            }
    //           // cmd.Parameters.AddWithValue("@PatRegId", Convert.ToInt32(ViewState["PatientInfoId"]));
    //            cmd.Parameters.AddWithValue("@PatRegId", Convert.ToString(txtPatientName.Text));
                
    //            if (ddlDepartment.SelectedValue == "")
    //            {
    //                ddlDepartment.SelectedValue = "0";
    //            }
    //            else
    //            {
    //                 cmd.Parameters.AddWithValue("@DeptId", Convert.ToInt32(ddlDepartment.SelectedValue));
    //            }
    //            if (ddlConsDoctorName.SelectedValue == "")
    //            {
    //                ddlConsDoctorName.SelectedValue = "0";
    //            }
    //            else
    //            {
    //                cmd.Parameters.AddWithValue("@DrId", Convert.ToInt32(ddlConsDoctorName.SelectedValue));
    //            }
    //            cmd.Parameters.AddWithValue("@start", txtStart.Text);
    //            cmd.Parameters.AddWithValue("@end", txtEnd.Text);
    //            con.Open();

    //            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
    //            {
    //                sda.Fill(dt);
    //            }

    //            con.Close();
    //            con.Dispose();
    //        }
    //        gvPatientInfo.DataSource = dt;
    //        gvPatientInfo.DataBind();

    //    }

    //}

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (PType.SelectedValue == "OPD")
        {
           // refreshdata();
        }
        else
        {
            refreshdata1();
        }
    }

    protected void gvPatientInfo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            //Determine the RowIndex of the Row whose Button was clicked.
            int rowIndex = Convert.ToInt32(e.CommandArgument);

            //Reference the GridView Row.
            GridViewRow row = gvPatientInfo.Rows[rowIndex];

            string regId = gvPatientInfo.Rows[rowIndex].Cells[1].Text;

            string opd = gvPatientInfo.Rows[rowIndex].Cells[2].Text;

            string name = gvPatientInfo.Rows[rowIndex].Cells[3].Text.Trim();

            string entryDate = gvPatientInfo.Rows[rowIndex].Cells[4].Text;
            int IpdId = 0;
           
            Session["EmrRegNo"] = regId;
            Session["EmrOpdNo"] = opd;
            Session["EmrIpdNo"] = 0;
           // string response = @"~/frmTreatment2.aspx?RegId=" + regId + "&OpdNo=" + opd + "&Name=" + name + "&EntryDate=" + entryDate;
            string response = @"~/GeneralEmr2.aspx?RegId=" + regId + "&OpdNo=" + opd + "&IpdNo=" + IpdId + "&Name=" + name + "&EntryDate=" + entryDate;

            Response.Redirect(string.Format(response));

            // ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Name: " + name + "\\nRegId: " + regId + "');", true);
        }

    }

    protected void gvPatientInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvPatientInfo.PageIndex = e.NewPageIndex;
       // refreshdata();
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
        return objDALOpdReg.FillAllIPDPatient(prefixText);
    }
    protected void txtPatientName_TextChanged(object sender, EventArgs e)
    {
        if (txtPatientName.Text != "")
        {
            string[] PatientInfo = txtPatientName.Text.Split('-');
            if (PatientInfo.Length > 1)
            {
                txtPatientName.Text = PatientInfo[1];
                ViewState["PatientInfoId"] = PatientInfo[0];
            }
        }

    }

    protected void gvPatientInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string flag = e.Row.Cells[9].Text;
            e.Row.Cells[9].Visible = false;
            foreach (TableCell cell in e.Row.Cells)
            {
                if (flag == "True")
                {
                    cell.BackColor = Color.SpringGreen;
                }
               

            }
        }
    }

   

    public void refreshdata1()
    {
        DataTable dt = new DataTable();

        if(txtOpdNo.Text!="")
        {
            ViewState["PatientInfoId"] = txtOpdNo.Text;
        }
            
        using (SqlConnection con = DataAccess.ConInitForDC())
        {
            using (SqlCommand cmd = new SqlCommand("usp_GetIpdPatientList_MRC", con))//usp_GetIpdPatientList
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FId", Convert.ToInt32(Session["FId"]));
                cmd.Parameters.AddWithValue("@BranchId", Convert.ToInt32(Session["Branchid"]));
                cmd.Parameters.AddWithValue("@PatRegId", Convert.ToInt32(ViewState["PatientInfoId"]));

                cmd.Parameters.AddWithValue("@RTypeId", Convert.ToInt32(ddlroomtype.SelectedValue));

                if (Convert.ToString(ViewState["ConsultID"]) != "")
                {
                    cmd.Parameters.AddWithValue("@DRName", Convert.ToInt32(ViewState["ConsultID"]));
                }
                else
                {
                    cmd.Parameters.AddWithValue("@DRName", Convert.ToInt32(0));
                }
                cmd.Parameters.AddWithValue("@PatientType", Convert.ToInt32(PType.SelectedValue));

                con.Open();

                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(dt);
                }

                con.Close();
                con.Dispose();
            }
            GVIPD.DataSource = dt;
            GVIPD.DataBind();
            ViewState["PatientInfoId"] = "0";
            lblMsg.Text = "Total Admited Patient's:" + dt.Rows.Count;
        }

    }

    protected void PType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (PType.SelectedValue == "OPD")
        {
           // refreshdata();
            GVOP.Visible = true;
            GVIP.Visible = false;
        }
        else
        {
            refreshdata1();
            GVOP.Visible = false;
            GVIP.Visible = true;
        }
    }
    protected void GVIPD_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        BLLReports objreports = new BLLReports();
        string sql = "";
        if (e.CommandName == "Shift")
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            //Reference the GridView Row.
            GridViewRow row = GVIPD.Rows[rowIndex];
            int IpdId = Convert.ToInt32(GVIPD.DataKeys[rowIndex].Values["IpdId"]);

            string PatRegId = GVIPD.Rows[rowIndex].Cells[1].Text;

            
            string name = GVIPD.Rows[rowIndex].Cells[4].Text.Trim();
            string RefDr = GVIPD.Rows[rowIndex].Cells[12].Text.Trim();

            
            string BillNo = Convert.ToString((GVIPD.Rows[rowIndex].FindControl("hdnBillNo") as HiddenField).Value);
           
            string entryDate = GVIPD.Rows[rowIndex].Cells[6].Text;
            int opd = 0;
            
           // string response = @"~/IPDDesk.aspx?RegId=" + PatRegId + "&OpdNo=" + opd + "&IpdNo=" + IpdId + "&Name=" + name + "&EntryDate=" + entryDate;
            string response = @"~/IPDDesk.aspx";

            Response.Redirect(string.Format(response));

        }
        if (e.CommandName == "Receive")
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            //Reference the GridView Row.
            GridViewRow row = GVIPD.Rows[rowIndex];
            int IpdId = Convert.ToInt32(GVIPD.DataKeys[rowIndex].Values["IpdId"]);

            string PatRegId = GVIPD.Rows[rowIndex].Cells[1].Text;

            string BillNo = GVIPD.Rows[rowIndex].Cells[3].Text;
            string name = GVIPD.Rows[rowIndex].Cells[4].Text.Trim();
            string RefDr = GVIPD.Rows[rowIndex].Cells[12].Text.Trim();
            //TextBox txtTestRemark = (GVIPD.Rows[rowIndex].FindControl("txtConsDoctorName1") as TextBox);
            //if (txtTestRemark.Text != "")
            //{

               // string[] PatientInfo = txtTestRemark.Text.Split('-');
                
                    //txtConsDoctorName.Text = PatientInfo[1];
                    // ViewState["ConsultID"] = PatientInfo[0];
                    //ConsultantDrId = ddlConsDoctorName.SelectedValue.ToString();

                    int BranchId = Convert.ToInt32(Session["Branchid"]);
                    int FId = Convert.ToInt32(Session["FId"]);
                    objDALOpdReg.Update_ReceivePatients(IpdId, PatRegId, BranchId, Convert.ToString(Session["username"]));
                   // txtTestRemark.BorderColor = System.Drawing.Color.Green;
                    lblMsg.Text = "Receive patient successfully!";
                //}
                    refreshdata1();
            //}
            //else
            //{
            //    txtTestRemark.BorderColor = System.Drawing.Color.Red;
            //    txtTestRemark.Focus();
            //}

            //  TextBox txtTestRemark = GVAAresultEntrySub.Rows[i].FindControl("txtTestRemark") as TextBox;
        }
        if (e.CommandName == "Refer")
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            //Reference the GridView Row.
            GridViewRow row = GVIPD.Rows[rowIndex];
            int IpdId = Convert.ToInt32(GVIPD.DataKeys[rowIndex].Values["IpdId"]);

            string PatRegId = GVIPD.Rows[rowIndex].Cells[1].Text;

            string BillNo = GVIPD.Rows[rowIndex].Cells[3].Text;
            string name = GVIPD.Rows[rowIndex].Cells[4].Text.Trim();
            string RefDr = GVIPD.Rows[rowIndex].Cells[12].Text.Trim();
            TextBox txtTestRemark = (GVIPD.Rows[rowIndex].FindControl("txtConsDoctorName1") as TextBox);
            if (txtTestRemark.Text != "")
            {

                string[] PatientInfo = txtTestRemark.Text.Split('-');
                if (PatientInfo.Length > 1)
                {
                    //txtConsDoctorName.Text = PatientInfo[1];
                    // ViewState["ConsultID"] = PatientInfo[0];
                    //ConsultantDrId = ddlConsDoctorName.SelectedValue.ToString();

                    int BranchId = Convert.ToInt32(Session["Branchid"]);
                    int FId = Convert.ToInt32(Session["FId"]);
                    objDALOpdReg.Update_ReferDr(IpdId, PatRegId, BranchId, Convert.ToInt32(PatientInfo[0]));
                    txtTestRemark.BorderColor = System.Drawing.Color.Green;
                    lblMsg.Text = "Refer patient successfully!";
                }

            }
            else
            {
                txtTestRemark.BorderColor = System.Drawing.Color.Red;
                txtTestRemark.Focus();
            }

            //  TextBox txtTestRemark = GVAAresultEntrySub.Rows[i].FindControl("txtTestRemark") as TextBox;
        }
        if (e.CommandName == "Select")
        {
            //Determine the RowIndex of the Row whose Button was clicked.
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            //Reference the GridView Row.
            GridViewRow row = GVIPD.Rows[rowIndex];
            int IpdId = Convert.ToInt32(GVIPD.DataKeys[rowIndex].Values["IpdId"]);


          string BillNo=  Convert.ToString((GVIPD.Rows[rowIndex].FindControl("hdnBillNo") as HiddenField).Value);
            string PatRegId = GVIPD.Rows[rowIndex].Cells[1].Text;

           // string BillNo = GVIPD.Rows[rowIndex].Cells[3].Text;
            string name = GVIPD.Rows[rowIndex].Cells[4].Text.Trim();

            string entryDate = GVIPD.Rows[rowIndex].Cells[6].Text;
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
        if (e.CommandName == "IPDReport")
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            //Reference the GridView Row.
            GridViewRow row = GVIPD.Rows[rowIndex];
            int IpdId = Convert.ToInt32(GVIPD.DataKeys[rowIndex].Values["IpdId"]);


            string BillNo = Convert.ToString((GVIPD.Rows[rowIndex].FindControl("hdnBillNo") as HiddenField).Value);
            string PatRegId = GVIPD.Rows[rowIndex].Cells[1].Text;

            // string BillNo = GVIPD.Rows[rowIndex].Cells[3].Text;
            string name = GVIPD.Rows[rowIndex].Cells[4].Text.Trim();

            string entryDate = GVIPD.Rows[rowIndex].Cells[6].Text;
            int opd = 0;

            string response = @"~/IPDDashboardReport.aspx?RegId=" + PatRegId + "&OpdNo=" + opd + "&IpdNo=" + IpdId + "&Name=" + name + "&EntryDate=" + entryDate;

            Response.Redirect(string.Format(response));
            

           // SqlConnection conrpV = DataAccess.ConInitForDC();
           // SqlCommand cmd1V = conrpV.CreateCommand();
           // string queryV = "ALTER VIEW [dbo].[Vw_IPDVitalSignForm] AS (SELECT DISTINCT "+
           //"  Vid, PatregId, OpdNo, IpdNo, Temprature, BP, HR, RR, Spo2, Inspired, RRScore, UrineScore, CNScore, BranchId, CreatedBy, "+
           //"  CreatedOn, UpdatedBy, UpdatedOn, FId, DateInput, TimeInput, VitalRemark, Systolic, Diastolic "+
           //"  FROM            VitalSignForm  " +
           //       " where VitalSignForm.IpdNo=" + Convert.ToInt32(IpdId) + "  and dbo.VitalSignForm.PatRegId=" + Convert.ToInt32(PatRegId) + " ";

           // cmd1V.CommandText = queryV + ")";
           // conrpV.Open();
           // cmd1V.ExecuteNonQuery();
           // conrpV.Close(); conrpV.Dispose();

            SqlConnection conrpDN = DataAccess.ConInitForDC();
            SqlCommand cmd1DN = conrpDN.CreateCommand();
            string queryDN = "ALTER VIEW [dbo].[Vw_DailyNurseNote] AS (SELECT  tbl_DailyNurseNote.NurseNoteId, tbl_DailyNurseNote.PatRegId, tbl_DailyNurseNote.IpdNo, tbl_DailyNurseNote.OpdNo, tbl_DailyNurseNote.NurseNote, "+
             "   tbl_DailyNurseNote.CreatedBy, tbl_DailyNurseNote.DrId, tbl_DailyNurseNote.DateInput, tbl_DailyNurseNote.TimeInput, tbl_DailyNurseNote.UserId,   tbl_DailyNurseNote.FId, "+
             "   tbl_DailyNurseNote.BranchId, tbl_DailyNurseNote.UpdatedBy, tbl_DailyNurseNote.CreatedOn, tbl_DailyNurseNote.UpdatedOn,  CTuser.Name  "+
             "    FROM  tbl_DailyNurseNote LEFT OUTER JOIN  CTuser ON tbl_DailyNurseNote.UserId = CTuser.CUId " +
             " where tbl_DailyNurseNote.IpdNo=" + Convert.ToInt32(IpdId) + "  and dbo.tbl_DailyNurseNote.PatRegId=" + Convert.ToInt32(PatRegId) + " ";

            cmd1DN.CommandText = queryDN + ")";
            conrpDN.Open();
            cmd1DN.ExecuteNonQuery();
            conrpDN.Close(); conrpDN.Dispose();

            SqlConnection conrpDr = DataAccess.ConInitForDC();
            SqlCommand cmd1Dr = conrpDr.CreateCommand();
            string queryDr = "ALTER VIEW [dbo].[Vw_IPDDrDailyNote] AS (SELECT  Id, Patregid, IpdNo, DrNote, Createdby, CreatedOn, UpdatedBy, Updatedon, Branchid, Fid, DrBy, DrPlan, Diagnosis,"+
                 "   Remarks, InvestigationDetails, TreatmentDetails "+
                 "   FROM            IPDDrDailyNote " +
             " where IPDDrDailyNote.IpdNo=" + Convert.ToInt32(IpdId) + "  and dbo.IPDDrDailyNote.PatRegId=" + Convert.ToInt32(PatRegId) + " ";

            cmd1Dr.CommandText = queryDr + ")";
            conrpDr.Open();
            cmd1Dr.ExecuteNonQuery();
            conrpDr.Close(); conrpDr.Dispose();


            SqlConnection conrpIT = DataAccess.ConInitForDC();
            SqlCommand cmd1IT = conrpIT.CreateCommand();
            string queryIT = "ALTER VIEW [dbo].[Vw_IPDTreatmentList] AS (SELECT        tbl_Treatment.TreatmentId, tbl_Treatment.FollowUpDate, tbl_Treatment.PatientRegId, tbl_Treatment.Opd, tbl_Treatment.Ipd, tbl_Treatment.BranchId, tbl_Treatment.CreatedBy, tbl_Treatment.CreatedOn, tbl_Treatment.UpdatedBy, " +
                "    tbl_Treatment.UpdatedOn, tbl_Treatment.DrId, tbl_Treatment.ReceiveToPharma, tbl_Treatment.EntryDate, tbl_Treatment.IsEmergency, tbl_Treatment.PaymentStatus, tbl_Treatment.IsApproveByNurse, " +
                "    tbl_Treatment.DiscMedication, tbl_Treatment.PostpoTreat, tbl_Treatment.WardName, tbl_Treatment.MackAddress, tbl_Treatment.PresPrintBy, tbl_Treatment.PrintOn, tbl_Treatment.ReasonForPrint, " +
                "    tbl_TreatmentTransaction.DrugName, tbl_TreatmentTransaction.FrequencyType, tbl_TreatmentTransaction.Days, tbl_TreatmentTransaction.StartDate, tbl_TreatmentTransaction.EndDate, tbl_TreatmentTransaction.Note, " +
                "    tbl_TreatmentTransaction.Dose, tbl_TreatmentTransaction.DoseId, tbl_TreatmentTransaction.DoseTimeId, tbl_TreatmentTransaction.ItemId, tbl_TreatmentTransaction.IsEmergency AS Expr1, tbl_TreatmentTransaction.Qty, " +
                "    tbl_TreatmentTransaction.NurseOrder, tbl_TreatmentTransaction.Vital, tbl_TreatmentTransaction.Diet, tbl_TreatmentTransaction.QtyML, tbl_TreatmentTransaction.InstName, tbl_TreatmentTransaction.NewDose, " +
                "    tbl_TreatmentTransaction.Route " +
                "    FROM            tbl_Treatment INNER JOIN tbl_TreatmentTransaction ON tbl_Treatment.TreatmentId = tbl_TreatmentTransaction.TreatmentId " +
             " where tbl_Treatment.Ipd=" + Convert.ToInt32(IpdId) + "  and dbo.tbl_Treatment.PatientRegId=" + Convert.ToInt32(PatRegId) + " ";

            cmd1IT.CommandText = queryIT + ")";
            conrpIT.Open();
            cmd1IT.ExecuteNonQuery();
            conrpIT.Close(); conrpIT.Dispose();


            Session.Add("rptsql", sql);
            Session["rptname"] = Server.MapPath("~/Report/Rpt_AllIpdReportFrontSheet.rpt");
            Session["reportname"] = "AllIpdReport";
            Session["RPTFORMAT"] = "pdf";

            //ReportParameterClass.SelectionFormula = sql;
            string close = "<script language='javascript'>javascript:OpenReport();</script>";
            Type title1 = this.GetType();
            Page.ClientScript.RegisterStartupScript(title1, "", close);
            //Session["EmrRegNo"] = PatRegId;
            //Session["EmrOpdNo"] = 0;
            //Session["EmrIpdNo"] = IpdId;
            //Session["EmrBillNo"] = BillNo;
            //Session["FormType"] = "";
        }
    }
    protected void GVIPD_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVIPD.PageIndex = e.NewPageIndex;
        refreshdata1();

    }
    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchConsultDoc(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        return objDALOpdReg.FillAllConsultDoc(prefixText);
    }

    protected void txtConsDoctorName_TextChanged(object sender, EventArgs e)
    {
        if (txtConsDoctorName.Text != "")
        {
            string[] PatientInfo = txtConsDoctorName.Text.Split('-');
            if (PatientInfo.Length > 1)
            {
                txtConsDoctorName.Text = PatientInfo[1];
                ViewState["ConsultID"] = PatientInfo[0];
                //ConsultantDrId = ddlConsDoctorName.SelectedValue.ToString();

                int BranchId = Convert.ToInt32(Session["Branchid"]);
                int FId = Convert.ToInt32(Session["FId"]);

                //string DeptId = objDALOpdReg.GetDeptId(Convert.ToInt32(ddlConsDoctorName.SelectedValue), FId, BranchId);
                //string DeptId = objDALOpdReg.GetDeptId_WithName(Convert.ToInt32(ViewState["ConsultID"]), FId, BranchId);
                
                //string[] DeptName = DeptId.Split('-');
               
                //ViewState["DeptID"] = DeptName[0];
                //txtdepartment.Text = DeptId;
            }
            else
            {
                txtConsDoctorName.Text = "";
            }
        }
    }
    protected void GVIPD_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex == -1)
            return;
        bool Received = Convert.ToBoolean((e.Row.FindControl("hdnIsReceived") as HiddenField).Value);
        if (Received == true)
        {
            e.Row.Cells[17].Enabled = false;
            e.Row.Cells[0].Enabled = true;
        }
        else
        {
            e.Row.Cells[17].Enabled = true;
            e.Row.Cells[0].Enabled = false;
        }
    }
}