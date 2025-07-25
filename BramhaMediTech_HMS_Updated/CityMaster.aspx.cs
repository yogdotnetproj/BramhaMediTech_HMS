using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Practices.EnterpriseLibrary.Data;
using CrystalDecisions.CrystalReports.Engine;

public partial class CityMaster :BasePage
{
    BELSDC objBELSDC = new BELSDC();
    DALSDC objDALSDC = new DALSDC();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                FillStateDrop();
                FillGrid();
                
            }
            catch (Exception)
            {
            }
            
        }
    }
   
    private void FillGrid()
    {

        gvCity.DataSource = objDALSDC.FillGridCity();
        gvCity.DataBind();
    }
    
    private void FillStateDrop()
    {
        ddlStateName.DataSource = objDALSDC.FillStateDrop();
        ddlStateName.DataTextField = "StateName";
        ddlStateName.DataValueField = "StateId";
        ddlStateName.DataBind();
       
    }
    
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string Message = "";
        
        if (!(txtCityName.Text).Equals(string.Empty))
        {
            if (Convert.ToInt32(ViewState["ID"]) > 0)
            {
                objBELSDC = objDALSDC.SelectOneCity(Convert.ToInt32(ViewState["ID"]));
                objBELSDC.CityId = Convert.ToInt32(ViewState["ID"]);
                objBELSDC.CityName = txtCityName.Text;
                if (ViewState["StateID"].ToString() != null)
                    objBELSDC.StateId = Convert.ToInt32(ViewState["StateID"].ToString());
                else
                    objBELSDC.StateId = Convert.ToInt32(ddlStateName.SelectedValue.ToString());
                objBELSDC.UpdatedBy = Convert.ToString(Session["username"]);
                Message = objDALSDC.UpdateCity(objBELSDC);
            }
            else
            {
                objBELSDC.CityName = txtCityName.Text;
                objBELSDC.StateId = Convert.ToInt32(ddlStateName.SelectedValue.ToString());
                objBELSDC.CreatedBy = Convert.ToString(Session["username"]);
                Message = objDALSDC.InsertCity(objBELSDC);
            }
            DynamicMessage(lblMsg, Message);
        }
        FillGrid();
        
        Clearall();
    }

   
    private void Clearall()
    {
        txtCityName.Text = "";
        ddlStateName.SelectedIndex = 0;
        ViewState["ID"] = 0;
    }
    /// <summary>
    ///  FillPage()
    ///  It Occurs when button Edit is Clicked.
    ///  It is Used For Fill Proper Records with its ID in its Fiels in the Form
    /// </summary>
    private void FillPage()
    {
        objBELSDC = objDALSDC.SelectOneCity(Convert.ToInt32(ViewState["ID"]));
        txtCityName.Text = objBELSDC.CityName;
        ddlStateName.SelectedValue = Convert.ToString(objBELSDC.StateId);
        ViewState["StateID"] = 0;
        ViewState["StateID"] = Convert.ToString(objBELSDC.StateId);
        FillGrid();
    }
    protected void ddlStateName_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["StateID"] = ddlStateName.SelectedValue.ToString();
    }
        
    
    protected void gvCity_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string Message;
        string ID = (gvCity.DataKeys[e.RowIndex]["CityId"].ToString());
        ViewState["CityId"] = ID;
        Message = objDALSDC.DeleteCity(Convert.ToInt32(ID));
        DynamicMessage(lblMsg, Message);
        FillGrid();
        Clearall();
    }
    protected void gvCity_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
           
            string ID = (gvCity.DataKeys[e.NewEditIndex]["CityId"].ToString());
            ViewState["ID"] = ID;
            FillPage();
            e.Cancel = true;
        }
        catch (Exception ex)
        {

            lblMsg.Text = ex.Message;
        }
    }
    protected void gvCity_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvCity.PageIndex = e.NewPageIndex;
        FillGrid();
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        Clearall();
        lblMsg.Text = "";
        
    }
    protected void txtDistrictName_TextChanged(object sender, EventArgs e)
    {
        txtCityName.Text = txtCityName.Text.Trim();
    }
    
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        try
        {
            BLLReports objBLLReports = new BLLReports();
            DataSet dsCustomers = new DataSet();
            ReportDocument crystalReport = new ReportDocument();
            crystalReport.Load(Server.MapPath("~/Report/RptDistrict.rpt"));
            //dsCustomers = objBLLReports.GetDistrict();
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
            lblMsg.Text = ex.Message;
        }
    }
   
}