

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

public partial class PatientInvoiceSubCategory :BasePage
{
    BLLPatientCategory objBLLPatientCategory = new BLLPatientCategory();
    DOPatientCategory objDOPatientCategory;
    BELBillCharges objBELBillCharges = new BELBillCharges();
    DALBillCharges objDALBillCharges = new DALBillCharges();
    public enum MessageType { Success, Error, Info, Warning };
    string UserId = "";


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                FillPatientSubCategoryGrid();
                FillPatMainTypeDrop();
                FillRateTypeDrop();
               //FillLabRateTypeDrop();
            }
            catch (Exception)
            {
            }

        }
    }
    protected void FillLabRateTypeDrop()
    {

        //ddlLabRateType.DataSource = objDALBillCharges.FillLabRateTypeDrop();
        //ddlLabRateType.DataValueField = "RatID";
        //ddlLabRateType.DataTextField = "RateName";
        //ddlLabRateType.DataBind();


    }
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
      
    protected void FillRateTypeDrop()
    {

        ddlRateType.DataSource = objBLLPatientCategory.Fill_MainInsuranceCompany();
        ddlRateType.DataTextField = "PatientInsuType";
        ddlRateType.DataValueField = "PatientInsuTypeId";
        ddlRateType.DataBind();
        ddlRateType.Items.Insert(0, new ListItem("All Insurance Company ", "0"));
        ddlRateType.SelectedIndex = 0;
    }
    protected void FillPatientSubCategoryGrid()
    {
        gvPatientSubCat.DataSource = objBLLPatientCategory.GetAllPatientInsu_SubType();
        gvPatientSubCat.DataBind();
    }


    

    protected void btnsave_Click(object sender, EventArgs e)
    {
        if (Session["UserId"] != null)
            UserId = Session["UserId"].ToString();
        string Message = "";
        objDOPatientCategory = new DOPatientCategory();
        if (!(txtPatientSubCat.Text.Equals(string.Empty)) || !(txtPatientSubCatins.Text.Equals(string.Empty)))
        {
            if (Convert.ToInt32(ViewState["PatientCategoryID"]) > 0)
            {
                objDOPatientCategory.PatMainTypeId = Convert.ToInt32(ddlpatmaincat.SelectedValue);
                objDOPatientCategory.PatientInsuTypeId = Convert.ToInt32(ddlRateType.SelectedValue);

                objDOPatientCategory.PatientInsuType = txtPatientSubCat.Text;
                objDOPatientCategory.ContactNumber = txtContactNumber.Text;

                objDOPatientCategory.InsuranceNote = txtDescription.Text;

                objDOPatientCategory.CreatedBy = Convert.ToString(Session["username"]);
                objDOPatientCategory.FId = Convert.ToInt32(Session["FId"]); ;
                objDOPatientCategory.BranchId = Convert.ToInt32(Session["Branchid"]);

                objDOPatientCategory.ID = Convert.ToInt32(ViewState["PatientCategoryID"]);

                Message = objBLLPatientCategory.UpdatePatient_InsuranceSubType(objDOPatientCategory);
                ShowMessage("Record Update successfully", MessageType.Success);
            }
            else
            {
                objDOPatientCategory.PatMainTypeId = Convert.ToInt32(ddlpatmaincat.SelectedValue);
                objDOPatientCategory.PatientInsuTypeId = Convert.ToInt32(ddlRateType.SelectedValue);

                objDOPatientCategory.PatientInsuType = txtPatientSubCat.Text;
                objDOPatientCategory.ContactNumber = txtContactNumber.Text;

                objDOPatientCategory.InsuranceNote = txtDescription.Text;

                objDOPatientCategory.CreatedBy = Convert.ToString(Session["username"]);
                objDOPatientCategory.FId = Convert.ToInt32(Session["FId"]); ;
                objDOPatientCategory.BranchId = Convert.ToInt32(Session["Branchid"]);


                Message = objBLLPatientCategory.InsertPatient_InsuranceSubType(objDOPatientCategory);
                ShowMessage("Record submitted successfully", MessageType.Success);
            }

            DynamicMessage(lblMessage, Message);

            FillPatientSubCategoryGrid();
            txtPatientSubCat.Text = "";
            txtPatientSubCatins.Text = "";
            txtDescription.Text = "";
            ddlpatmaincat.SelectedValue = "0";
            ViewState["PatientCategoryID"] = 0;

        }

    }


    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtPatientSubCat.Text = "";
        ViewState["PatientCategoryID"] = 0;
        lblMessage.Text = "";
        txtDescription.Text = "";
        txtContactNumber.Text = "";


    }


    protected void FillPage()
    {
        try
        {
            FillPatMainTypeDrop();
            objDOPatientCategory = objBLLPatientCategory.Select_InvoiceSubCategory(Convert.ToInt32(ViewState["PatientCategoryID"]));
           // txtPatientSubCat.Text = objDOPatientCategory.PatientInsuType;
            ddlpatmaincat.SelectedValue = Convert.ToString(objDOPatientCategory.PatMainTypeId);
            this.ddlpatmaincat_SelectedIndexChanged(null, null);
            ddlRateType.SelectedValue = Convert.ToString(objDOPatientCategory.PatientInsuTypeId);

            txtPatientSubCat.Text = Convert.ToString(objDOPatientCategory.PatientInsuType);
            txtContactNumber.Text = Convert.ToString(objDOPatientCategory.ContactNumber);
            txtDescription.Text = Convert.ToString(objDOPatientCategory.InsuranceNote);

           
           
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }


    protected void btnPrint_Click(object sender, EventArgs e)
    {
        try
        {
            BLLReports objBLLReports = new BLLReports();
            DataSet dsCustomers = new DataSet();
            ReportDocument crystalReport = new ReportDocument();
            crystalReport.Load(Server.MapPath("~/Report/RptPatientCatagory.rpt"));
            //dsCustomers = objBLLReports.GetPatientCategory();
            crystalReport.SetDataSource(dsCustomers);
            crystalReport.ParameterFields["HospitalName"].CurrentValues.AddValue(Convert.ToString(Application["OrgnizationName"]));
            crystalReport.ParameterFields["HospitalAddress"].CurrentValues.AddValue(Convert.ToString(Application["OrgnizationAddress"]));
            //crystalReport.ParameterFields["Image"].CurrentValues.AddValue(Application["ImagePath"]);
            crystalReport.ParameterFields["ReportFooter"].CurrentValues.AddValue("Hospital Software | Ph.020 0000000000");
            crystalReport.ExportToHttpResponse
            (CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Employee");
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }




    protected void gvPatientSubCat_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string PatientCategoryID = (gvPatientSubCat.DataKeys[e.RowIndex]["Id"].ToString());

        string Message = objBLLPatientCategory.Delete_ChildInsurance(Convert.ToInt32(PatientCategoryID));//Convert.ToInt32(ViewState["PCId"])
        DynamicMessage(lblMessage, Message);
        FillPatientSubCategoryGrid();
        txtPatientSubCat.Text = "";
        ShowMessage("Record Delete Successfully", MessageType.Error);


    }
    protected void gvPatientSubCat_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {

            string PatientCategoryID = (gvPatientSubCat.DataKeys[e.NewEditIndex]["Id"].ToString());
            ViewState["PatientCategoryID"] = PatientCategoryID;
            FillPage();
            e.Cancel = true;
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void gvPatientSubCat_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvPatientSubCat.PageIndex = e.NewPageIndex;
        if (ddlRateType.SelectedIndex > 0)
        {
            gvPatientSubCat.DataSource = objBLLPatientCategory.GetAllPatientInsu_SubType_Search_InsuranceComp(Convert.ToInt32(ddlRateType.SelectedValue));
            gvPatientSubCat.DataBind();
        }
        else
        {
            FillPatientSubCategoryGrid();
        }
    }
    
    public void FillPatMainTypeDrop()
    {

        ddlpatmaincat.DataSource = objBLLPatientCategory.FillPatMainTypeCombo();
        ddlpatmaincat.DataTextField = "PatMainType";
        ddlpatmaincat.DataValueField = "PatMainTypeId";
        ddlpatmaincat.DataBind();
        ddlpatmaincat.Items.Insert(0,new ListItem("All Main Category","0"));
        ddlpatmaincat.SelectedIndex = 0;
    }

    protected void ddlpatmaincat_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlRateType.DataSource = objBLLPatientCategory.Fill_MainInsuranceCompany_WithMainCategory(Convert.ToInt32( ddlpatmaincat.SelectedValue));
        ddlRateType.DataTextField = "PatientInsuType";
        ddlRateType.DataValueField = "PatientInsuTypeId";
        ddlRateType.DataBind();
        ddlRateType.Items.Insert(0, new ListItem("All Insurance Company ", "0"));
        ddlRateType.SelectedIndex = 0;
    }
    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchPatient(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        return objDALOpdReg.FillAllInsuranceCompany(prefixText);
    }
    protected void ddlRateType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlRateType.SelectedIndex > 0)
        {
            gvPatientSubCat.DataSource = objBLLPatientCategory.GetAllPatientInsu_SubType_Search_InsuranceComp(Convert.ToInt32( ddlRateType.SelectedValue));
            gvPatientSubCat.DataBind();
        }
        else
        {
            FillPatientSubCategoryGrid();
        }
    }
    protected void txtPatientSubCat_TextChanged(object sender, EventArgs e)
    {
        if (txtPatientSubCat.Text != "")
        {

            gvPatientSubCat.DataSource = objBLLPatientCategory.GetAllPatientInsu_SubType_Search_ChildInsuranceComp(Convert.ToString(txtPatientSubCat.Text));
            gvPatientSubCat.DataBind();
        }
        else
        {
           // FillPatientSubCategoryGrid();
        }
    }
}