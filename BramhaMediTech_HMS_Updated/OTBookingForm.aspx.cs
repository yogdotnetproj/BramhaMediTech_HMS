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
public partial class OTBookingForm : System.Web.UI.Page
{
    public enum MessageType { Success, Error, Info, Warning };
    BELPatientInformation objBELPatInfo = new BELPatientInformation();
    DALPatientInformation objDALPatInfo = new DALPatientInformation();
    BELBillDetails objBELBillDetail = new BELBillDetails();
    DALBillDetails objDALBillDetail = new DALBillDetails();
    string Message = "";
    clsEmr obj = new clsEmr();
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            refreshdata();
        }

    }
    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchPatient(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        return objDALOpdReg.FillAllPatientFullName(prefixText);
    }

    protected void txtPatientName_TextChanged(object sender, EventArgs e)
    {
        if (txtPatientName.Text.Split('-').Length < 2)
        {
           // hfPatientId.Value = "0";
            ViewState["PatientInfoId"] = "0";
        }
        else
        {
            string[] PatientInfo = txtPatientName.Text.Split('-');
            txtPatientName.Text = PatientInfo[2];
            ViewState["PatientInfoId"] = PatientInfo[0];
            ViewState["Initial"] = PatientInfo[1];
            ViewState["Sex"] = PatientInfo[4];
            fillInformation();

           // lblVisitingNo.Text = "Your Reg No is :" + ViewState["PatientInfoId"] + " and IPD No is :" + ViewState["IPDNO"];
        }


    }
    protected void fillInformation()
    {
        objBELPatInfo = objDALPatInfo.SelectOne(Convert.ToInt32(ViewState["PatientInfoId"]));

        txtPatientName.Text = objBELPatInfo.FirstName;

        txtBirthDate.Text = Convert.ToDateTime(objBELPatInfo.BirthDate).ToShortDateString();
      //  txtPatientAddress.Text = objBELPatInfo.PatientAddress;
        txtMobileNo.Text = objBELPatInfo.MobileNo;
        if (Convert.ToDouble(objBELPatInfo.Age) < 0.084)
        {
            txtAge.Text = Convert.ToString(Math.Round((Convert.ToDecimal(objBELPatInfo.Age) * 12) * 30));
            ddlAge.SelectedValue = "Day";
        }
        else if (Convert.ToDouble(objBELPatInfo.Age) < 1)
        {
            txtAge.Text = Convert.ToString(Math.Round(Convert.ToDecimal(objBELPatInfo.Age) * 12));
            ddlAge.SelectedValue = "Month";
        }
        else
        {
            txtAge.Text = Convert.ToString(Math.Round(Convert.ToDecimal(objBELPatInfo.Age)));
            ddlAge.SelectedValue = "Year";
        }
        ViewState["Age"] = ddlAge.SelectedValue;
       // ddlTitleName.SelectedValue = Convert.ToString(objBELPatInfo.TitleId);
       // ddlGender.SelectedValue = Convert.ToString(objBELPatInfo.GenderId);
       // objBELPatInfo = objDALPatInfo.SelectOneDr(Convert.ToInt32(ViewState["PatientInfoId"]), Convert.ToInt32(ViewState["OpdNo"]));
        //txtdepartment.Text = objBELPatInfo.DeptName;
        //txtConsDoctorName_New.Text = objBELPatInfo.DocName;
        //txtEmail.Text = objBELPatInfo.Email;
        //ViewState["ConsultID"] = Convert.ToInt32(objBELPatInfo.DrId);
        //ViewState["DeptID"] = objBELPatInfo.DeptId;

    }
    protected void txtAge_TextChanged(object sender, EventArgs e)
    {

    }
    protected void ddlAge_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void txtBirthDate_TextChanged(object sender, EventArgs e)
    {

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
    public static List<string> SearchOperaation(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        string Type = "1";
        return objDALOpdReg.FillAllOperation(prefixText, Type);
    }
    protected void txtsurgen_TextChanged(object sender, EventArgs e)
    {
        if (txtsurgen.Text != "")
        {
            string[] PatientInfo = txtsurgen.Text.Split('-');
            if (PatientInfo.Length > 1)
            {
                txtsurgen.Text = PatientInfo[1];
                ViewState["SurganID"] = PatientInfo[0];
                txtsurgen.BorderColor = Color.LightGray;
            }
            else
            {
                ViewState["SurganID"] = "0";
            }
        }
        else
        {
            ViewState["SurganID"] = "0";
        }
    }
    protected void txtoperation_TextChanged(object sender, EventArgs e)
    {
        if (txtoperation.Text != "")
        {
            string[] PatientInfo = txtoperation.Text.Split('-');
            if (PatientInfo.Length > 1)
            {
                txtoperation.Text = PatientInfo[1];
                ViewState["Operation"] = PatientInfo[0];
            }
            else
            {
                ViewState["Operation"] = "0";

            }
        }
        else
        {
            ViewState["Operation"] = "0";
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {

        if (validationSurgeon() == true)
        {
            if (txtsurgen.Text != "")
            {
                objBELBillDetail.Surgan = Convert.ToInt32(ViewState["SurganID"]);
            }
            else
            {
                objBELBillDetail.Surgan = 0;
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Enter Surgeon!!!');", true);
            return;

        }
        objBELBillDetail.PatRegId = Convert.ToInt32(ViewState["PatientInfoId"]);
        if (txtoperation.Text != "")
        {
            objBELBillDetail.OperationName = Convert.ToString(txtoperation.Text.Trim());
        }
        else
        {
            txtoperation.Focus();
            txtoperation.BorderColor = System.Drawing.Color.Red;
            return;
        }
        objBELBillDetail.Operation = Convert.ToInt32(ViewState["Operation"]);

        if (txtScheduleDate.Text != "")
        {
            objBELBillDetail.ScheduleSurgeryDate = Convert.ToDateTime(txtScheduleDate.Text.Trim());
        }
        else
        {
            txtScheduleDate.Focus();
            txtScheduleDate.BorderColor = System.Drawing.Color.Red;
            return;
        }
        objBELBillDetail.EstimatedCost = Convert.ToSingle(txtestimatedCost.Text.Trim());
        objBELBillDetail.NonRefDeposit = Convert.ToSingle(txtNonRefDeposit.Text.Trim());

        objBELBillDetail.CreatedBy = Convert.ToString(Session["username"]);
        objBELBillDetail.BranchId = Convert.ToInt32(Session["Branchid"]);




        Message = objDALBillDetail.Insert_OTBookingForm(objBELBillDetail);
        ShowMessage("Record save successfully!", MessageType.Success);
        txtoperation.Text = "";
        txtAge.Text = "";
        txtBirthDate.Text = "";
        txtestimatedCost.Text = "";
        txtMobileNo.Text = "";
        txtNonRefDeposit.Text = "";
        txtoperation.Text = "";
        txtPatientName.Text = "";
        txtScheduleDate.Text = "";
        txtsurgen.Text = "";
        refreshdata();
    }

    public void refreshdata()
    {
        DataTable dt = new DataTable();

        using (SqlConnection con = DataAccess.ConInitForDC())
        {
            using (SqlCommand cmd = new SqlCommand("SP_GetOTBookingForm", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                
                cmd.Parameters.AddWithValue("@BranchId", Convert.ToInt32(Session["Branchid"]));
               

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
          //  pcount.Text = "Total OT Patient Count: " + dt.Rows.Count;

        }

    }
    public bool validationSurgeon()
    {
        bool flag = false;
        if (txtsurgen.Text == "")
        {
            if (ViewState["SurganID"].ToString() == "0")
            {
                txtsurgen.Focus();
                txtsurgen.BorderColor = Color.Red;
                ViewState["Msg"] = "Please Select Surgeon!!";
                flag = false;
            }
        }
        else
        {
            if (ViewState["SurganID"].ToString() == "0")
            {
                txtsurgen.Focus();
                txtsurgen.BorderColor = Color.Red;
                ViewState["Msg"] = "Please Select Surgeon!!";
                flag = false;
            }
            else
            {
                txtsurgen.BorderColor = Color.LightGray;
                flag = true;
            }
        }
        return flag;
    }
    protected void btnreport_Click(object sender, EventArgs e)
    {

    }
    protected void gvPatientInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void gvPatientInfo_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void gvPatientInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void gvPatientInfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
}