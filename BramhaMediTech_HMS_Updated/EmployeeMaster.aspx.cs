using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Data.Odbc;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Web.Management;
using System.Data;
using System.Web.Services;
using System.Web.Script.Services;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class EmployeeMaster : BaseClass
{
    BELEmpReg objBELEmpReg = new BELEmpReg();
    DALEmpReg objDALEmpReg = new DALEmpReg();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillEmployeeMaster();
            FillDepartmentDrop();
            FillDesignationDrop();
            FillInitialDrop();
            show.Visible = false;
            List.Visible = true;

        }
    }
    protected void FillEmployeeMaster()
    {
        gvEmployee.DataSource = objDALEmpReg.FillEmployeeMaster();
        gvEmployee.DataBind();
    }
    protected void FillDepartmentDrop()
    {
        ddlDepartment.DataSource = objDALEmpReg.FillDeptDrop();
        ddlDepartment.DataValueField = "DeptId";
        ddlDepartment.DataTextField = "DeptName";
        ddlDepartment.DataBind();
    }
    protected void FillDesignationDrop()
    {
        ddlDesignation.DataSource = objDALEmpReg.FillDesignationDrop();
        ddlDesignation.DataValueField = "DesignationId";
        ddlDesignation.DataTextField = "Designation";
        ddlDesignation.DataBind();
    }
    protected void FillInitialDrop()
    {

        ddlTitleName.DataSource = objDALEmpReg.FillTitleDrop();
        ddlTitleName.DataValueField = "Title";
        ddlTitleName.DataTextField = "Title";
        ddlTitleName.DataBind();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {

        string Message = "";

        if (!(txtEmpName.Text.Equals(string.Empty)))
        {
            if (Convert.ToInt32(ViewState["pno"]) > 0)
            {
                objBELEmpReg.DrId = Convert.ToInt32(ViewState["pno"]);
                objBELEmpReg.Empname = txtEmpName.Text;                
                objBELEmpReg.DeptId = Convert.ToInt32(ddlDepartment.SelectedValue);
                objBELEmpReg.DesignationId = Convert.ToInt32(ddlDesignation.SelectedValue);
                objBELEmpReg.Address = txtEmployeeAddress.Value;
                objBELEmpReg.mobile = txtMobileNo.Text;
                objBELEmpReg.telno = txtPhoneNo.Text;
                objBELEmpReg.Title = ddlTitleName.SelectedItem.Text;
                objBELEmpReg.Qualification = txtQualification.Text;
                objBELEmpReg.PANNo = txtPanCardNo.Text;
                objBELEmpReg.email = txtEmail.Text;
                objBELEmpReg.Empcode = txtEmpCode.Text;
                objBELEmpReg.EmployeeType = ddlEmployeeType.SelectedValue;
                objBELEmpReg.PANNo = txtPanCardNo.Text;
                if (txtBirthDate.Text == "")
                {
                    objBELEmpReg.BirthDate = Convert.ToDateTime("01-01-1900");
                }
                else
                {
                    objBELEmpReg.BirthDate = Convert.ToDateTime(txtBirthDate.Text);
                }
                
                
                if (txtJoinDate.Text == "")
                {
                    objBELEmpReg.JoiningDate = Convert.ToDateTime("01-01-1900"); 
                }
                else
                {
                    objBELEmpReg.JoiningDate = Convert.ToDateTime(txtJoinDate.Text);
                }
               
                objBELEmpReg.UpdatedBy = Convert.ToString(Session["username"]);
                Message = objDALEmpReg.UpdateEmpMaster(objBELEmpReg);

                FileUpload img = (FileUpload)FUFileUpload;
                Byte[] imgByte = null;
                if (img.HasFile && img.PostedFile != null)
                {
                    //To create a PostedFile
                    HttpPostedFile File = FUFileUpload.PostedFile;
                    //Create byte Array with file len
                    imgByte = new Byte[File.ContentLength];
                    //force the control to load data in array
                    File.InputStream.Read(imgByte, 0, File.ContentLength);
                    SqlConnection conn = DataAccess.ConInitForDC();
                    SqlCommand sc = new SqlCommand("update   HospEmpMst set DrSignature=@Drsignature where DrId= '" + ViewState["pno"] + "'  ", conn);
                    //  " values(@signatureid,@Drsignature,@username,@branchid,@Degree,@SignPicture)", conn);
                    
                    sc.Parameters.AddWithValue("@Drsignature", imgByte);

                    conn.Open();
                    sc.ExecuteNonQuery();
                    conn.Close();
                    conn.Dispose();
                }
            }
            else
            {
                objBELEmpReg.Empname = txtEmpName.Text;
                objBELEmpReg.DeptId = Convert.ToInt32(ddlDepartment.SelectedValue);
                objBELEmpReg.DesignationId = Convert.ToInt32(ddlDesignation.SelectedValue);
                //objBELEmpReg.BloodGroup = ddlBloodGroup.Text;
                objBELEmpReg.mobile = txtMobileNo.Text;
                objBELEmpReg.telno = txtPhoneNo.Text;
                objBELEmpReg.Title = ddlTitleName.SelectedItem.Text;
                objBELEmpReg.Qualification = txtQualification.Text;
                objBELEmpReg.PANNo = txtPanCardNo.Text;
                objBELEmpReg.Address = txtEmployeeAddress.Value;
                objBELEmpReg.email = txtEmail.Text;
                objBELEmpReg.Empcode = txtEmpCode.Text;
                objBELEmpReg.EmployeeType = ddlEmployeeType.SelectedValue;                
                objBELEmpReg.BranchId = Convert.ToInt32(Session["Branchid"]);
                objBELEmpReg.FId = "1";
                objBELEmpReg.CreatedBy = Convert.ToString(Session["username"]);
                if (txtBirthDate.Text == "")
                {
                    objBELEmpReg.BirthDate = Convert.ToDateTime("01-01-1900");
                }
                else
                {
                    objBELEmpReg.BirthDate = Convert.ToDateTime(txtBirthDate.Text);
                }
               

                if (txtJoinDate.Text == "")
                {
                    objBELEmpReg.JoiningDate = Convert.ToDateTime("01-01-1900");
                }
                else
                {
                    objBELEmpReg.JoiningDate = Convert.ToDateTime(txtJoinDate.Text);
                }

                Message = objDALEmpReg.InsertEmpMaster(objBELEmpReg);

                FileUpload img = (FileUpload)FUFileUpload;
                Byte[] imgByte = null;
                if (img.HasFile && img.PostedFile != null)
                {
                    //To create a PostedFile
                    HttpPostedFile File = FUFileUpload.PostedFile;
                    //Create byte Array with file len
                    imgByte = new Byte[File.ContentLength];
                    //force the control to load data in array
                    File.InputStream.Read(imgByte, 0, File.ContentLength);
                    SqlConnection conn = DataAccess.ConInitForDC();
                    SqlCommand sc = new SqlCommand("update   HospEmpMst set DrSignature=@Drsignature where Empname= '" + txtEmpName.Text + "'  ", conn);
                    //  " values(@signatureid,@Drsignature,@username,@branchid,@Degree,@SignPicture)", conn);
                    

                    sc.Parameters.AddWithValue("@Drsignature", imgByte);

                    conn.Open();
                    sc.ExecuteNonQuery();
                    conn.Dispose();
                    conn.Dispose();
                }
            }

            DynamicMessage(lblMessage, Message);

             FillEmployeeMaster();
             clearall();
        }
        show.Visible = false;
        List.Visible = true;

    }
    protected void btnaddnew_Click(object sender, EventArgs e)
    {
        show.Visible = true;
        List.Visible = false;
        lblMessage.Text = "";
    }


    protected void btnReset_Click(object sender, EventArgs e)
    {
        clearall();
        lblMessage.Text = "";
        show.Visible = false;
        List.Visible = true;

    }
    private void clearall()
    {
        txtEmployeeAddress.Value = "";
       
        txtBirthDate.Text = ""; 
        ddlEmployeeType.SelectedValue = "0";
        txtEmpName.Text = "";
       
        txtEmail.Text = "";
        txtEmpCode.Text = "";
        txtJoinDate.Text = "";
        ViewState["pno"] = 0;
        txtMobileNo.Text = "";
        txtPanCardNo.Text = "";
        txtPhoneNo.Text = "";
        txtQualification.Text = "";
       
        ddlDepartment.SelectedValue = "0";
        ddlDesignation.SelectedValue = "0";
        ddlEmployeeType.SelectedValue = "0";
        ddlTitleName.SelectedIndex = 0;       

    }

    protected void FillPage()
    {
        try
        {
            objBELEmpReg = objDALEmpReg.SelectOneEmpMaster(Convert.ToInt32(ViewState["pno"]));
            txtEmployeeAddress.Value = objBELEmpReg.Address;            
            ddlEmployeeType.SelectedValue =Convert.ToString(objBELEmpReg.EmployeeType);
            txtEmpName.Text = objBELEmpReg.Empname;
            if (objBELEmpReg.BirthDate != Convert.ToDateTime("01/01/0001"))
            {
                txtBirthDate.Text = Convert.ToDateTime(objBELEmpReg.BirthDate).ToShortDateString();
            }
            
            if (objBELEmpReg.JoiningDate != Convert.ToDateTime("01/01/0001"))
            {
                txtJoinDate.Text = Convert.ToDateTime(objBELEmpReg.JoiningDate).ToShortDateString();
            }
            txtEmail.Text = objBELEmpReg.email;
            txtEmpCode.Text =objBELEmpReg.Empcode;            
            txtMobileNo.Text = objBELEmpReg.mobile;
            txtPanCardNo.Text = objBELEmpReg.PANNo;
            txtPhoneNo.Text = objBELEmpReg.telno;
            txtQualification.Text = objBELEmpReg.Qualification;
           
            ddlDepartment.SelectedValue =Convert.ToString(objBELEmpReg.DeptId);
            ddlDesignation.SelectedValue = Convert.ToString(objBELEmpReg.DesignationId);
           
            ddlTitleName.SelectedValue = Convert.ToString(objBELEmpReg.Title);
       
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }


    protected void btnPrint_Click(object sender, EventArgs e)
    {
        //try
        //{
        //    BLLReports objBLLReports = new BLLReports();
        //    DataSet dsCustomers = new DataSet();
        //    ReportDocument crystalReport = new ReportDocument();
        //    crystalReport.Load(Server.MapPath("~/Report/RptSubDepartment.rpt"));
        //    //dsCustomers = objBLLReports.GetSubDepartment();
        //    crystalReport.SetDataSource(dsCustomers);
        //    crystalReport.ParameterFields["HospitalName"].CurrentValues.AddValue(Convert.ToString(Application["OrgnizationName"]));
        //    crystalReport.ParameterFields["HospitalAddress"].CurrentValues.AddValue(Convert.ToString(Application["OrgnizationAddress"]));
        //    //crystalReport.ParameterFields["Image"].CurrentValues.AddValue(Application["ImagePath"]);
        //    crystalReport.ParameterFields["ReportFooter"].CurrentValues.AddValue("Hospital Software | Ph.020 0000000000");
        //    crystalReport.ExportToHttpResponse
        //    (CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Employee");
        //}
        //catch (Exception ex)
        //{
        //    lblMessage.Text = ex.Message;
        //}
    }
    
    
    
    protected void gvEmployee_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvEmployee.PageIndex = e.NewPageIndex;
         FillEmployeeMaster();
        // FillEmployeeMaster();
    }
    protected void gvEmployee_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string pno = (gvEmployee.DataKeys[e.RowIndex]["pno"].ToString());

        string Message = objDALEmpReg.DeleteEmpMaster(Convert.ToInt32(pno));
        DynamicMessage(lblMessage, Message);

         FillEmployeeMaster();
        clearall();
    }
    protected void gvEmployee_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            show.Visible = true;
            List.Visible = false;

            string pno = (gvEmployee.DataKeys[e.NewEditIndex]["DrId"].ToString());
            ViewState["pno"] = pno;
            FillPage();
            e.Cancel = true;
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void txtEmployeeSearch_TextChanged(object sender, EventArgs e)
    {
        if (txtEmployeeSearch.Text != "")
        {

            gvEmployee.DataSource = objDALEmpReg.Search_EmployeeByName(txtEmployeeSearch.Text);
            gvEmployee.DataBind();
        }
        else
        {
            FillEmployeeMaster();
        }
    }
    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchPatient(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        return objDALOpdReg.FillAllEmployee(prefixText);
    }
}