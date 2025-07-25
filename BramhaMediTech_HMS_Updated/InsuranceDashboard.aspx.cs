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

public partial class InsuranceDashboard :BasePage
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
            ViewState["InsuranceId"] = 0;
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
            using (SqlCommand cmd = new SqlCommand("usp_GetIpdPatientListForInsurancePatient", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FId", Convert.ToInt32(Session["FId"]));
                cmd.Parameters.AddWithValue("@BranchId", Convert.ToInt32(Session["Branchid"]));
                cmd.Parameters.AddWithValue("@PatRegId", Convert.ToInt32(ViewState["PatientInfoId"]));
                cmd.Parameters.AddWithValue("@InsuranceId", Convert.ToInt32(ViewState["InsuranceId"]));
              
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
            for (int i = 0; i < gvPatientInfo.Rows.Count; i++)
            {
                DropDownList ddloutsourceLab = gvPatientInfo.Rows[i].FindControl("Status") as DropDownList;
                string  LabStatus = Convert.ToString((gvPatientInfo.Rows[i].FindControl("hdnstatus") as HiddenField).Value);
                if (LabStatus !="")
                {
                    ddloutsourceLab.SelectedValue = Convert.ToString(LabStatus);
                    if (LabStatus == "Accept")
                    {
                        gvPatientInfo.Rows[i].ForeColor = Color.Green;
                        
                    }
                    if (LabStatus == "Reject")
                    {
                        gvPatientInfo.Rows[i].ForeColor = Color.Red;
                        
                    }
                    if (LabStatus == "Pending")
                    {
                        gvPatientInfo.Rows[i].ForeColor = Color.Gray;

                    }
                    
                }
            }
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
            string Message = "";
            //Determine the RowIndex of the Row whose Button was clicked.
            int rowIndex = Convert.ToInt32(e.CommandArgument);

            //Reference the GridView Row.
            GridViewRow row = gvPatientInfo.Rows[rowIndex];
            int IpdId = Convert.ToInt32(gvPatientInfo.DataKeys[rowIndex].Values["IpdId"]);

            string PatRegId = gvPatientInfo.Rows[rowIndex].Cells[0].Text;
            string IPDNO = gvPatientInfo.Rows[rowIndex].Cells[1].Text;
            float Sponsor1Amt = 0, Sponsor2Amt = 0;
           int Sponsor1= Convert.ToInt32( (gvPatientInfo.Rows[rowIndex].Cells[1].FindControl("hdnsponsor1") as HiddenField).Value);
           int Sponsor2 = Convert.ToInt32((gvPatientInfo.Rows[rowIndex].Cells[1].FindControl("hdnsponsor2") as HiddenField).Value);
           string InsurStatus = Convert.ToString((gvPatientInfo.Rows[rowIndex].Cells[1].FindControl("Status") as DropDownList).Text);
            //for (int p = 0; p < gvPatientInfo.Rows.Count; p++)
            //{
            if ((gvPatientInfo.Rows[rowIndex].Cells[1].FindControl("sponsor1") as TextBox).Text != "" || (gvPatientInfo.Rows[rowIndex].Cells[1].FindControl("Sponsor2") as TextBox).Text != "")
                {
                    if ((gvPatientInfo.Rows[rowIndex].Cells[1].FindControl("sponsor1") as TextBox).Text != "")
                    {
                        if ((gvPatientInfo.Rows[rowIndex].Cells[1].FindControl("hdnsponsor1") as HiddenField).Value != "0")
                        {
                             Sponsor1Amt = Convert.ToSingle((gvPatientInfo.Rows[rowIndex].Cells[1].FindControl("sponsor1") as TextBox).Text);
                        }
                        else
                        {
                            Sponsor1Amt = 0;
                        }
                    }
                    else
                    {
                        Sponsor1Amt = 0;
                    }
                    if ((gvPatientInfo.Rows[rowIndex].Cells[1].FindControl("Sponsor2") as TextBox).Text != "")
                    {
                        if ((gvPatientInfo.Rows[rowIndex].Cells[1].FindControl("hdnsponsor2") as HiddenField).Value != "0")
                        {
                             Sponsor2Amt = Convert.ToSingle((gvPatientInfo.Rows[rowIndex].Cells[1].FindControl("Sponsor2") as TextBox).Text);
                        }
                        else
                        {
                            Sponsor2Amt = 0;
                        }
                    }
                    else
                    {
                        Sponsor2Amt = 0;
                    }
              int Branchid=  Convert.ToInt32(Session["Branchid"]);
              string UserName=  Convert.ToString(Session["username"]);
                int FID= Convert.ToInt32(Session["FId"]);
                Message = objDALOpdReg.InsertUpdate_Insurance_Charges(Convert.ToInt32(PatRegId), Convert.ToInt32(IPDNO), 0, Sponsor1, Convert.ToSingle(Sponsor1Amt), Sponsor2, Convert.ToSingle(Sponsor2Amt), InsurStatus, Branchid, UserName, FID);
                lblMsg.Text = "Record Save successfully!.";
                refreshdata();
                }

           // }
            
            //string response = @"~/IpdAdvancePayment.aspx?RegId=" + PatRegId + "&IpdId=" + IpdId;

            //Response.Redirect(string.Format(response));

            // ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Name: " + name + "\\nRegId: " + regId + "');", true);
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
    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchInsurance(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        return objDALOpdReg.FillAllInsurance(prefixText);
    }
    protected void txtPatientName_TextChanged(object sender, EventArgs e)
    {

        string[] PatientInfo = txtPatientName.Text.Split('-');
        txtPatientName.Text = PatientInfo[1];
        ViewState["PatientInfoId"] = PatientInfo[0];

    }
    protected void txtInsuranceid_TextChanged(object sender, EventArgs e)
    {
        if (txtInsuranceid.Text != "")
        {
            string[] InsuranceId = txtInsuranceid.Text.Split('-');
            txtInsuranceid.Text = InsuranceId[1];

            if (txtInsuranceid.Text != "")
                ViewState["InsuranceId"] = InsuranceId[0];
            else
                ViewState["InsuranceId"] = 0;
        }
        else
        {
            ViewState["InsuranceId"] = 0;
        }
    }
  
}