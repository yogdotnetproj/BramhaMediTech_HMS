using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;

public partial class Vaccnation_Master : BasePage
{
    BLLPatientCategory objBLLPatientCategory = new BLLPatientCategory();
    DOPatientCategory objDOPatientCategory;
    string UserId = "";


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                FillVaccination();
            }
            catch (Exception)
            {
            }

        }
    }


    protected void FillVaccination()
    {
        gvPatientCat.DataSource = objBLLPatientCategory.FillGrid_Vaccination();
        gvPatientCat.DataBind();
    }


    protected void txtPatientCategoryName_TextChanged(object sender, EventArgs e)
    {
        txtPatientCat.Text = txtPatientCat.Text.Trim();
    }


    protected void btnsave_Click(object sender, EventArgs e)
    {
        if (Session["UserId"] != null)
            UserId = Session["UserId"].ToString();
        string Message = "";
        objDOPatientCategory = new DOPatientCategory();
        if (!(txtPatientCat.Text.Equals(string.Empty)))
        {
            if (Convert.ToInt32(ViewState["VaccianId"]) > 0)
            {
                //objDOPatientCategory = objBLLPatientCategory.SelectOne(Convert.ToInt32(ViewState["VaccianId"]));
                objDOPatientCategory.VaccnationName = txtPatientCat.Text;
                objDOPatientCategory.FromAge = txtFromRange.Text;
                objDOPatientCategory.ToAge = txtToRange.Text;
                objDOPatientCategory.AgeType =ddlAge.SelectedValue;
                objDOPatientCategory.PatMainTypeId = Convert.ToInt32(ViewState["VaccianId"]);
                objDOPatientCategory.UpdatedBy = Convert.ToString(Session["username"]);
                objDOPatientCategory.BranchId = Convert.ToInt32(Session["Branchid"]);
                Message = objBLLPatientCategory.Update_VaccineMaster(objDOPatientCategory);
                lblMessage.Text = "Recore update Successfully.";
            }
            else
            {
                objDOPatientCategory.VaccnationName = txtPatientCat.Text;
                objDOPatientCategory.FromAge = txtFromRange.Text;
                objDOPatientCategory.ToAge = txtToRange.Text;
                objDOPatientCategory.AgeType = ddlAge.SelectedValue;
                objDOPatientCategory.CreatedBy = Convert.ToString(Session["username"]);
                objDOPatientCategory.FId = Convert.ToInt32(Session["FId"]); ;
                objDOPatientCategory.BranchId = Convert.ToInt32(Session["Branchid"]);
                Message = objBLLPatientCategory.Insert_VaccanationMaster(objDOPatientCategory);
                lblMessage.Text = "Recore Save Successfully.";
            }

           // DynamicMessage(lblMessage, Message);

            FillVaccination();
            txtPatientCat.Text = "";
            ViewState["VaccianId"] = 0;
            txtFromRange.Text = "";
            txtToRange.Text = "";
          
           

        }

    }

    private void DynamicMessage(Label lblMessage, string Message)
    {
        throw new NotImplementedException();
    }


    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtPatientCat.Text = "";
        ViewState["VaccianId"] = 0;
        txtFromRange.Text = "";
        txtToRange.Text = "";
        lblMessage.Text = "";


    }


    protected void FillPage()
    {
        try
        {
            objDOPatientCategory = objBLLPatientCategory.SelectOne_Vaccination(Convert.ToInt32(ViewState["VaccianId"]));
            txtPatientCat.Text = objDOPatientCategory.VaccnationName;
            txtFromRange.Text = objDOPatientCategory.FromAge;
            txtToRange.Text = objDOPatientCategory.ToAge;
            ddlAge.SelectedValue = objDOPatientCategory.AgeType;
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




    protected void gvPatientCat_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string VaccianId = (gvPatientCat.DataKeys[e.RowIndex]["VaccianId"].ToString());

        string Message = objBLLPatientCategory.Delete_Vaccination(Convert.ToInt32(VaccianId));//Convert.ToInt32(ViewState["PCId"])
        //DynamicMessage(lblMessage, Message);
        lblMessage.Text = "Recore Delete Successfully.";
        FillVaccination();
        txtPatientCat.Text = "";


    }
    protected void gvPatientCat_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {

            string PatientCategoryID = (gvPatientCat.DataKeys[e.NewEditIndex]["VaccianId"].ToString());
            ViewState["VaccianId"] = PatientCategoryID;
            FillPage();
            e.Cancel = true;
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void gvPatientCat_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvPatientCat.PageIndex = e.NewPageIndex;
        FillVaccination();
    }
}