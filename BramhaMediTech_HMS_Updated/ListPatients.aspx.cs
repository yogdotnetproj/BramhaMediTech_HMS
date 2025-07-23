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

public partial class ListPatients : System.Web.UI.Page
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
            Session["FormType"] = "OPDNurse";
           // txtOpdNo.Text = "0";
            if (Convert.ToString( Session["Usertype"]) == "Administrator" || Convert.ToString( Session["Usertype"]) == "Admin")
            {
                refreshdata();
                LoadConsultantDoc();
                FillDepartmentDrop();
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

        ddlConsDoctorName.DataSource = objDALOpdReg.FillConsultantDocName_Emr();
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
                cmd.CommandTimeout = 5000;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    
                    sda.Fill(dt);
                }

                con.Close();
                con.Dispose();
            }
            gvPatientInfo.DataSource = dt;
            gvPatientInfo.DataBind();

            lblMsg.Text = "Total Patient's:" + dt.Rows.Count;
        }

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (PType.SelectedValue == "OPD")
        {
            Session["FormType"] = "OPDNurse";
            refreshdata();
        }
        else
        {
            Session["FormType"] = "IPDNurse";
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

        if (e.CommandName == "Refer")
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            //Reference the GridView Row.
            GridViewRow row = gvPatientInfo.Rows[rowIndex];
           // int IpdId = Convert.ToInt32(GVIPD.DataKeys[rowIndex].Values["IpdId"]);

            string PatRegId = gvPatientInfo.Rows[rowIndex].Cells[1].Text;

            int OPDNO = Convert.ToInt32( gvPatientInfo.Rows[rowIndex].Cells[2].Text);
            //string name = GVIPD.Rows[rowIndex].Cells[4].Text.Trim();
            //string RefDr = GVIPD.Rows[rowIndex].Cells[12].Text.Trim();
            TextBox txtTestRemark = (gvPatientInfo.Rows[rowIndex].FindControl("txtConsDoctorName1") as TextBox);
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
                    objDALOpdReg.ReferToOtherDoctor(OPDNO, PatRegId, Convert.ToString(Session["username"]), Convert.ToInt32(PatientInfo[0]));
                    txtTestRemark.BorderColor = System.Drawing.Color.Green;
                    lblMsg.Text = "Refer patient successfully!";
                }

            }
            else
            {


                TextBox txtTestRemark2 = (gvPatientInfo.Rows[rowIndex].FindControl("txtConsDoctorName2") as TextBox);
                if (txtTestRemark2.Text != "")
                {

                    string[] PatientInfo = txtTestRemark2.Text.Split('-');
                    if (PatientInfo.Length > 1)
                    {
                        //txtConsDoctorName.Text = PatientInfo[1];
                        // ViewState["ConsultID"] = PatientInfo[0];
                        //ConsultantDrId = ddlConsDoctorName.SelectedValue.ToString();

                        int BranchId = Convert.ToInt32(Session["Branchid"]);
                        int FId = Convert.ToInt32(Session["FId"]);
                        objDALOpdReg.HandOverToOtherDoctor(OPDNO, PatRegId, Convert.ToString(Session["username"]), Convert.ToInt32(PatientInfo[0]));
                        txtTestRemark2.BorderColor = System.Drawing.Color.Green;
                        lblMsg.Text = "HandOver patient successfully!";
                    }

                }
            }

            //  TextBox txtTestRemark = GVAAresultEntrySub.Rows[i].FindControl("txtTestRemark") as TextBox;
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
            //string flag = e.Row.Cells[10].Text;
            //e.Row.Cells[10].Visible = false;
            //foreach (TableCell cell in e.Row.Cells)
            //{
            //    if (flag == "True")
            //    {
            //        cell.BackColor = Color.SpringGreen;
            //    }


            //}

            bool PatientChecked = Convert.ToBoolean((e.Row.FindControl("hdnIsPatientChecked") as HiddenField).Value);
            if (PatientChecked == true)
            {
                e.Row.BackColor = Color.SpringGreen;
            }
            int LabPtype = Convert.ToInt32((e.Row.FindControl("hdnTriageCriteria") as HiddenField).Value);
          //  e.Row.Cells[9].Text = "<span class='btn btn-xs btn-success'>Low Risk</span>";
            if (LabPtype == 0)
            {
                e.Row.Cells[9].Text = "<span class='btn btn-xs btn-success'>Low Risk</span>";
            }
            else if (LabPtype == 2)
            {
                e.Row.Cells[9].Text = "<span class='btn btn-xs btn-warning'>Medium Risk</span>";
            }
            else
            {
                e.Row.Cells[9].Text = "<span class='btn btn-xs btn-danger'>High Risk</span>";
            }
        }
    }

    public void refreshdata1()
    {
        DataTable dt = new DataTable();

        using (SqlConnection con = DataAccess.ConInitForDC())
        {
            using (SqlCommand cmd = new SqlCommand("usp_GetIpdPatientList", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FId", Convert.ToInt32(Session["FId"]));
                cmd.Parameters.AddWithValue("@BranchId", Convert.ToInt32(Session["Branchid"]));
                cmd.Parameters.AddWithValue("@PatRegId", Convert.ToInt32(ViewState["PatientInfoId"]));
                
               cmd.Parameters.AddWithValue("@RTypeId", Convert.ToInt32(0));
                

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

        }

    }

    protected void PType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (PType.SelectedValue == "OPD")
        {
            Session["FormType"] = "OPDNurse";
            refreshdata();
            GVOP.Visible = true;
            GVIP.Visible = false;
        }
        else
        {
            Session["FormType"] = "IPDNurse";
            refreshdata1();
            GVOP.Visible = false;
            GVIP.Visible = true;
        }
    }
    protected void GVIPD_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        BLLReports objreports = new BLLReports();
        string sql = "";
        if (e.CommandName == "Select")
        {
            //Determine the RowIndex of the Row whose Button was clicked.
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            //Reference the GridView Row.
            GridViewRow row = GVIPD.Rows[rowIndex];
            int IpdId = Convert.ToInt32(GVIPD.DataKeys[rowIndex].Values["IpdId"]);

            string PatRegId = GVIPD.Rows[rowIndex].Cells[1].Text;
            string name = GVIPD.Rows[rowIndex].Cells[4].Text.Trim();

            string entryDate = GVIPD.Rows[rowIndex].Cells[6].Text;
            int opd = 0;

            // string response = @"~/frmTreatment2.aspx?RegId=" + regId + "&OpdNo=" + opd + "&Name=" + name + "&EntryDate=" + entryDate;
           // string response = @"~/IpdBillForPatientServices.aspx?RegId=" + PatRegId + "&IpdId=" + IpdId;
            Session["EmrRegNo"] = PatRegId;
            Session["EmrOpdNo"] = 0;
            Session["EmrIpdNo"] = IpdId;
            // string response = @"~/frmTreatment2.aspx?RegId=" + regId + "&OpdNo=" + opd + "&Name=" + name + "&EntryDate=" + entryDate;
            string response = "";
            if (PType.SelectedValue == "OPD")
            {
                response = @"~/GeneralEmr2.aspx?RegId=" + PatRegId + "&OpdNo=" + opd + "&IpdNo=" + IpdId + "&Name=" + name + "&EntryDate=" + entryDate;
            }
            else
            {
                response = @"~/IntakeOutputSheet.aspx?RegId=" + PatRegId + "&OpdNo=" + opd + "&Name=" + name + "&IpdNo=" + IpdId;//+ "&EntryDate=" + entryDate

            }
            Response.Redirect(string.Format(response));

            // ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Name: " + name + "\\nRegId: " + regId + "');", true);
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
}