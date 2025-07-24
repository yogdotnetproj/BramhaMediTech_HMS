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

public partial class NursePatientList :BasePage
{
    BELOPDPatReg objBELOpdReg = new BELOPDPatReg();
    DALOpdReg objDALOpdReg = new DALOpdReg();
    BELEmpReg objBELEmpReg = new BELEmpReg();
    DALEmpReg objDALEmpReg = new DALEmpReg();
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            txtStart.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtEnd.Text = DateTime.Now.ToString("dd/MM/yyyy");
           // txtOpdNo.Text = "0";
            if (Session["Usertype"].ToString() == "Administrator" || Session["Usertype"].ToString() == "Admin")
            {
               
                LoadConsultantDoc();
                FillDepartmentDrop();
                refreshdata();
            }
            else
            {
                LoadConsultantDocByEmpId();
                FillDepartmentDropByEmpId();
                refreshdata();

            }

        }
    }
    private void LoadConsultantDoc()
    {

        ddlConsDoctorName.DataSource = objDALOpdReg.FillConsultantDocName();
        ddlConsDoctorName.DataValueField = "DrId";
        ddlConsDoctorName.DataTextField = "EmpName";
        ddlConsDoctorName.DataBind();
    }
    protected void FillDepartmentDrop()
    {
        ddlDepartment.DataSource = objDALEmpReg.FillDeptDrop();
        ddlDepartment.DataValueField = "DeptId";
        ddlDepartment.DataTextField = "DeptName";
        ddlDepartment.DataBind();
        ddlDepartment.SelectedValue = "88";
    }
    private void LoadConsultantDocByEmpId()
    {

        ddlConsDoctorName.DataSource = objDALOpdReg.FillConsultantDocNameByEmpId(Convert.ToInt32(Session["EmpId"]));
        ddlConsDoctorName.DataValueField = "DrId";
        ddlConsDoctorName.DataTextField = "EmpName";
        ddlConsDoctorName.DataBind();
    }
    protected void FillDepartmentDropByEmpId()
    {
        ddlDepartment.DataSource = objDALEmpReg.FillDepartmentDropByEmpId(Convert.ToInt32(Session["EmpId"]));
        ddlDepartment.DataValueField = "DeptId";
        ddlDepartment.DataTextField = "DeptName";
        ddlDepartment.DataBind();
        ddlDepartment.SelectedValue = "88";
    }
    public void refreshdata()
    {
        DataTable dt = new DataTable();
        //if (txtOpdNo.Text == "")
        //{
        //    txtOpdNo.Text = "0";
        //}
        using (SqlConnection con = DataAccess.ConInitForDC())
        {
            using (SqlCommand cmd = new SqlCommand("usp_GetPatientListForEMR", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FId",Convert.ToInt32(Session["FId"]));
                cmd.Parameters.AddWithValue("@BranchId", Convert.ToInt32(Session["Branchid"]));
                if (txtOpdNo.Text == "")
                {
                    cmd.Parameters.AddWithValue("@OpdNo", Convert.ToInt32(0));
                }
                else
                {
                    cmd.Parameters.AddWithValue("@OpdNo", Convert.ToInt32(txtOpdNo.Text));
                }
               // cmd.Parameters.AddWithValue("@PatRegId", Convert.ToInt32(ViewState["PatientInfoId"]));
                cmd.Parameters.AddWithValue("@PatRegId", Convert.ToString(txtPatientName.Text));
                
                if (ddlDepartment.SelectedValue == "")
                {
                    ddlDepartment.SelectedValue = "0";
                }
                else
                {
                     cmd.Parameters.AddWithValue("@DeptId", Convert.ToInt32(ddlDepartment.SelectedValue));
                }
                if (ddlConsDoctorName.SelectedValue == "")
                {
                    ddlConsDoctorName.SelectedValue = "0";
                }
                else
                {
                    cmd.Parameters.AddWithValue("@DrId", Convert.ToInt32(ddlConsDoctorName.SelectedValue));
                }
                cmd.Parameters.AddWithValue("@start", txtStart.Text);
                cmd.Parameters.AddWithValue("@end", txtEnd.Text);
                con.Open();

                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    cmd.CommandTimeout = 5000;
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

            string regId = gvPatientInfo.Rows[rowIndex].Cells[1].Text;

            string opd = gvPatientInfo.Rows[rowIndex].Cells[2].Text;

            string name = gvPatientInfo.Rows[rowIndex].Cells[3].Text.Trim();

            string entryDate = gvPatientInfo.Rows[rowIndex].Cells[8].Text;
            Session["EmrRegNo"] = regId;
            Session["EmrOpdNo"] = opd;
           // string response = @"~/frmTreatment2.aspx?RegId=" + regId + "&OpdNo=" + opd + "&Name=" + name + "&EntryDate=" + entryDate;
            string response = @"~/NurseGeneralEmr.aspx?RegId=" + regId + "&OpdNo=" + opd + "&Name=" + name + "&EntryDate=" + entryDate;

            Response.Redirect(string.Format(response));

            // ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Name: " + name + "\\nRegId: " + regId + "');", true);
        }
        if (e.CommandName == "Procedure")
        {
            //Determine the RowIndex of the Row whose Button was clicked.
            int rowIndex = Convert.ToInt32(e.CommandArgument);

            //Reference the GridView Row.
            GridViewRow row = gvPatientInfo.Rows[rowIndex];

            string regId = gvPatientInfo.Rows[rowIndex].Cells[1].Text;

            string opd = gvPatientInfo.Rows[rowIndex].Cells[2].Text;

            string name = gvPatientInfo.Rows[rowIndex].Cells[3].Text.Trim();

            string entryDate = gvPatientInfo.Rows[rowIndex].Cells[8].Text;
            Session["EmrRegNo"] = regId;
            Session["EmrOpdNo"] = opd;
            // string response = @"~/frmTreatment2.aspx?RegId=" + regId + "&OpdNo=" + opd + "&Name=" + name + "&EntryDate=" + entryDate;
            string response = @"~/EmergencyObservations.aspx?FormType=Nurse&RegId=" + regId + "&OpdNo=" + opd + "&Name=" + name + "&EntryDate=" + entryDate;

            Response.Redirect(string.Format(response));

            // ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Name: " + name + "\\nRegId: " + regId + "');", true);
        }
        if (e.CommandName == "Triage")
        {
            //Determine the RowIndex of the Row whose Button was clicked.
            int rowIndex = Convert.ToInt32(e.CommandArgument);

            //Reference the GridView Row.
            GridViewRow row = gvPatientInfo.Rows[rowIndex];

            string regId = gvPatientInfo.Rows[rowIndex].Cells[1].Text;

            string opd = gvPatientInfo.Rows[rowIndex].Cells[2].Text;

            string name = gvPatientInfo.Rows[rowIndex].Cells[3].Text.Trim();

            string entryDate = gvPatientInfo.Rows[rowIndex].Cells[8].Text;
            Session["EmrRegNo"] = regId;
            Session["EmrOpdNo"] = opd;
            // string response = @"~/frmTreatment2.aspx?RegId=" + regId + "&OpdNo=" + opd + "&Name=" + name + "&EntryDate=" + entryDate;
            string response = @"~/Triage_Questionary.aspx?FormType=Nurse&RegId=" + regId + "&OpdNo=" + opd + "&Name=" + name + "&EntryDate=" + entryDate;

            Response.Redirect(string.Format(response));

            // ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Name: " + name + "\\nRegId: " + regId + "');", true);
        }
        if (e.CommandName == "MAR")
        {
            //Determine the RowIndex of the Row whose Button was clicked.
            int rowIndex = Convert.ToInt32(e.CommandArgument);

            //Reference the GridView Row.
            GridViewRow row = gvPatientInfo.Rows[rowIndex];

            string regId = gvPatientInfo.Rows[rowIndex].Cells[1].Text;

            string opd = gvPatientInfo.Rows[rowIndex].Cells[2].Text;

            string name = gvPatientInfo.Rows[rowIndex].Cells[3].Text.Trim();

            string entryDate = gvPatientInfo.Rows[rowIndex].Cells[8].Text;
            Session["EmrRegNo"] = regId;
            Session["EmrOpdNo"] = opd;
            // string response = @"~/frmTreatment2.aspx?RegId=" + regId + "&OpdNo=" + opd + "&Name=" + name + "&EntryDate=" + entryDate;
            string response = @"~/IPDPatientTreatmentSheet.aspx?FormType=Nurse&RegId=" + regId + "&OpdNo=" + opd + "&Name=" + name + "&EntryDate=" + entryDate;

            Response.Redirect(string.Format(response));

            // ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Name: " + name + "\\nRegId: " + regId + "');", true);
        }
        if (e.CommandName == "ER")
        {
            //Determine the RowIndex of the Row whose Button was clicked.
            int rowIndex = Convert.ToInt32(e.CommandArgument);

            //Reference the GridView Row.
            GridViewRow row = gvPatientInfo.Rows[rowIndex];

            string regId = gvPatientInfo.Rows[rowIndex].Cells[1].Text;

            string opd = gvPatientInfo.Rows[rowIndex].Cells[2].Text;

            string name = gvPatientInfo.Rows[rowIndex].Cells[3].Text.Trim();

            string entryDate = gvPatientInfo.Rows[rowIndex].Cells[8].Text;
            Session["EmrRegNo"] = regId;
            Session["EmrOpdNo"] = opd;
            // string response = @"~/frmTreatment2.aspx?RegId=" + regId + "&OpdNo=" + opd + "&Name=" + name + "&EntryDate=" + entryDate;
            string response = @"~/Emergency_Procedures.aspx?FormType=Nurse&RegId=" + regId + "&OpdNo=" + opd + "&Name=" + name + "&EntryDate=" + entryDate;

            Response.Redirect(string.Format(response));

            // ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Name: " + name + "\\nRegId: " + regId + "');", true);
        }
        if (e.CommandName == "OPDRep")
        {
            //Determine the RowIndex of the Row whose Button was clicked.
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            BLLReports objreports = new BLLReports();
            //Reference the GridView Row.
            GridViewRow row = gvPatientInfo.Rows[rowIndex];
            string regId = gvPatientInfo.Rows[rowIndex].Cells[1].Text;
            string opd = gvPatientInfo.Rows[rowIndex].Cells[2].Text;
            string name = gvPatientInfo.Rows[rowIndex].Cells[3].Text.Trim();

            string entryDate = gvPatientInfo.Rows[rowIndex].Cells[4].Text;
            objreports.AllOPD_Service_Report(Convert.ToInt32(regId), Convert.ToInt32(opd));
            int IpdId = 0;
            Session["EmrRegNo"] = regId;
            Session["EmrOpdNo"] = opd;
            Session["EmrIpdNo"] = 0;
            Session.Add("rptsql", "");
            Session["rptname"] = Server.MapPath("~/Reports/Rpt_All_OPDServiceReport.rpt");
            Session["reportname"] = "All_OPDServiceReport";
            Session["RPTFORMAT"] = "pdf";


            string close = "<script language='javascript'>javascript:OpenReport();</script>";
            Type title1 = this.GetType();
            Page.ClientScript.RegisterStartupScript(title1, "", close);
            // string response = @"~/GeneralEmr2.aspx?RegId=" + regId + "&OpdNo=" + opd + "&IpdNo=" + IpdId + "&Name=" + name + "&EntryDate=" + entryDate;

            // Response.Redirect(string.Format(response));

            // ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Name: " + name + "\\nRegId: " + regId + "');", true);
        }
        if (e.CommandName == "Dia")
        {
            //Determine the RowIndex of the Row whose Button was clicked.
            int rowIndex = Convert.ToInt32(e.CommandArgument);

            //Reference the GridView Row.
            GridViewRow row = gvPatientInfo.Rows[rowIndex];

            string regId = gvPatientInfo.Rows[rowIndex].Cells[1].Text;

            string opd = gvPatientInfo.Rows[rowIndex].Cells[2].Text;

            string name = gvPatientInfo.Rows[rowIndex].Cells[3].Text.Trim();

            string entryDate = gvPatientInfo.Rows[rowIndex].Cells[8].Text;
            Session["EmrRegNo"] = regId;
            Session["EmrOpdNo"] = opd;
            // string response = @"~/frmTreatment2.aspx?RegId=" + regId + "&OpdNo=" + opd + "&Name=" + name + "&EntryDate=" + entryDate;
            string response = @"~/Dialysis.aspx?FormType=Nurse&RegId=" + regId + "&OpdNo=" + opd + "&Name=" + name + "&EntryDate=" + entryDate;

            Response.Redirect(string.Format(response));

            // ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Name: " + name + "\\nRegId: " + regId + "');", true);
        }
    }

    protected void gvPatientInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvPatientInfo.PageIndex = e.NewPageIndex;
        refreshdata();
    }
    protected void ddlConsDoctorName_SelectedIndexChanged(object sender, EventArgs e)
    {
        // if (Convert.ToBoolean(ViewState["IsDirect"]) != true)
        //{

        int ConsultantDrId = Convert.ToInt32(ddlConsDoctorName.SelectedValue);       
        int BranchId = Convert.ToInt32(Session["Branchid"]);
        int FId = Convert.ToInt32(Session["FId"]);
        
        string DeptId = objDALOpdReg.GetDeptId(Convert.ToInt32(ddlConsDoctorName.SelectedValue), FId, BranchId);
       
        ddlDepartment.SelectedValue = DeptId;
       

    }
    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchPatient(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        return objDALOpdReg.FillAllPatient(prefixText);
    }
    protected void txtPatientName_TextChanged(object sender, EventArgs e)
    {
        
            //string[] PatientInfo = txtPatientName.Text.Split('-');
            //txtPatientName.Text = PatientInfo[1];
            //ViewState["PatientInfoId"] = PatientInfo[0];           

    }

    protected void gvPatientInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string flag = e.Row.Cells[15].Text;
            e.Row.Cells[15].Visible = false;
            foreach (TableCell cell in e.Row.Cells)
            {
                if (flag == "True")
                {
                    cell.BackColor = Color.SpringGreen;
                }
               

            }
        }
    }
}