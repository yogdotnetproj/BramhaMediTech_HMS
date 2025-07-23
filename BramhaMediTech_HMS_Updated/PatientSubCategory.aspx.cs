

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

public partial class PatientSubCategory : BaseClass
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
                FillLabRateTypeDrop();
            }
            catch (Exception)
            {
            }

        }
    }
    protected void FillLabRateTypeDrop()
    {

        ddlLabRateType.DataSource = objDALBillCharges.FillLabRateTypeDrop();
        ddlLabRateType.DataValueField = "RatID";
        ddlLabRateType.DataTextField = "RateName";
        ddlLabRateType.DataBind();


    }
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
      
    protected void FillRateTypeDrop()
    {

        ddlRateType.DataSource = objDALBillCharges.FillRateTypeDrop();
        ddlRateType.DataValueField = "RateTypeId";
        ddlRateType.DataTextField = "RateType";
        ddlRateType.DataBind();


    }
    protected void FillPatientSubCategoryGrid()
    {
        gvPatientSubCat.DataSource = objBLLPatientCategory.FillGridPatientSubCat();
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
                objDOPatientCategory = objBLLPatientCategory.SelectOne(Convert.ToInt32(ViewState["PatientCategoryID"]));

                if (ddlpatmaincat.SelectedValue == "2" || ddlpatmaincat.SelectedValue == "3")
                {
                    objDOPatientCategory.PatientInsuType = txtPatientSubCatins.Text;
                }
                else
                {
                    objDOPatientCategory.PatientInsuType = txtPatientSubCat.Text;
                }
              
                objDOPatientCategory.PatientInsuTypeId = Convert.ToInt32(ViewState["PatientCategoryID"]);
                objDOPatientCategory.PatMainTypeId = Convert.ToInt32(ddlpatmaincat.SelectedValue.ToString());
                objDOPatientCategory.PatientRateTypeId = Convert.ToInt32(ddlRateType.SelectedValue);
                objDOPatientCategory.UpdatedBy = Convert.ToString(Session["username"]);
                objDOPatientCategory.BranchId = Convert.ToInt32(Session["Branchid"]);
                objDOPatientCategory.OrderNo = Convert.ToInt32(txtOrderNo.Text);
                objDOPatientCategory.PatientLabRateTypeId = Convert.ToInt32(ddlLabRateType.SelectedValue);
                objDOPatientCategory.CompanyCode = txtcompanyCode.Text;
                Message = objBLLPatientCategory.UpdatePatientSubCategory(objDOPatientCategory);
                ShowMessage("Record Update successfully", MessageType.Success);
            }
            else
            {
                if (ddlpatmaincat.SelectedValue == "2" || ddlpatmaincat.SelectedValue == "3")
                {
                    objDOPatientCategory.PatientInsuType = txtPatientSubCatins.Text;
                }
                else
                {
                    objDOPatientCategory.PatientInsuType = txtPatientSubCat.Text;
                }
                // objDOPatientCategory.IsActive = true;
                objDOPatientCategory.CreatedBy = Convert.ToString(Session["username"]);
                objDOPatientCategory.FId = Convert.ToInt32(Session["FId"]); ;
                objDOPatientCategory.BranchId = Convert.ToInt32(Session["Branchid"]);
                objDOPatientCategory.PatMainTypeId = Convert.ToInt32(ddlpatmaincat.SelectedValue);
               // objDOPatientCategory.PatientInsuType = txtPatientSubCat.Text;
                objDOPatientCategory.PatientRateTypeId=Convert.ToInt32(ddlRateType.SelectedValue);
                objDOPatientCategory.OrderNo = Convert.ToInt32(txtOrderNo.Text);
                if (ddlLabRateType.SelectedValue != "")
                {
                    objDOPatientCategory.PatientLabRateTypeId = Convert.ToInt32(ddlLabRateType.SelectedValue);
                }
                else
                {
                    objDOPatientCategory.PatientLabRateTypeId = 0;
                }
                objDOPatientCategory.CompanyCode = txtcompanyCode.Text;
                Message = objBLLPatientCategory.InsertPatientSubCategory(objDOPatientCategory);
                ShowMessage("Record submitted successfully", MessageType.Success);
            }

            DynamicMessage(lblMessage, Message);

            FillPatientSubCategoryGrid();
            txtPatientSubCat.Text = "";
            txtPatientSubCatins.Text = "";
            ddlpatmaincat.SelectedValue = "0";
            txtcompanyCode.Text = "";
            ViewState["PatientCategoryID"] = 0;

        }

    }


    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtPatientSubCat.Text = "";
        ViewState["PatientCategoryID"] = 0;
        lblMessage.Text = "";


    }


    protected void FillPage()
    {
        try
        {
            objDOPatientCategory = objBLLPatientCategory.SelectOnePatSubCategory(Convert.ToInt32(ViewState["PatientCategoryID"]));
            ddlpatmaincat.SelectedValue = Convert.ToString(objDOPatientCategory.PatMainTypeId);
            if (ddlpatmaincat.SelectedValue == "2" || ddlpatmaincat.SelectedValue == "3")
            {
                txtPatientSubCat.Visible = false;
                txtPatientSubCatins.Visible = true;
               // objDOPatientCategory.PatientInsuType = txtPatientSubCatins.Text;
                txtPatientSubCatins.Text = objDOPatientCategory.PatientInsuType;
            }
            else
            {
                txtPatientSubCat.Visible = true; ;
                txtPatientSubCatins.Visible = false;
               // objDOPatientCategory.PatientInsuType = txtPatientSubCat.Text;
                txtPatientSubCat.Text = objDOPatientCategory.PatientInsuType;
            }
           
           
            ddlRateType.SelectedValue = Convert.ToString(objDOPatientCategory.PatientRateTypeId);
            txtOrderNo.Text = Convert.ToString(objDOPatientCategory.OrderNo);
            ddlLabRateType.SelectedValue = Convert.ToString(objDOPatientCategory.PatientLabRateTypeId);
            txtcompanyCode.Text = Convert.ToString(objDOPatientCategory.CompanyCode);
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
        string PatientCategoryID = (gvPatientSubCat.DataKeys[e.RowIndex]["PatientInsuTypeId"].ToString());

        string Message = objBLLPatientCategory.DeletePatientSubCategory(Convert.ToInt32(PatientCategoryID));//Convert.ToInt32(ViewState["PCId"])
        DynamicMessage(lblMessage, Message);
        FillPatientSubCategoryGrid();
        txtPatientSubCat.Text = "";
        ShowMessage("Record Delete Successfully", MessageType.Error);


    }
    protected void gvPatientSubCat_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {

            string PatientCategoryID = (gvPatientSubCat.DataKeys[e.NewEditIndex]["PatientInsuTypeId"].ToString());
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
        FillPatientSubCategoryGrid();
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
        if (ddlpatmaincat.SelectedValue == "2" || ddlpatmaincat.SelectedValue == "3")
        {
            txtPatientSubCat.Visible = false;
            txtPatientSubCatins.Visible = true;
        }
        else
        {
            txtPatientSubCatins.Visible = false;
            txtPatientSubCat.Visible = true;
        }
    }
    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchPatient(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        return objDALOpdReg.FillAllInsuranceCompany(prefixText);
    }
}