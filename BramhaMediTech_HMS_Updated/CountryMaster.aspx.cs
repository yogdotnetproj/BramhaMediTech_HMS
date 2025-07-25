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

public partial class CountryMaster :BasePage
{
    BELSDC objBELSDC = new BELSDC();
    DALSDC objDALSDC = new DALSDC();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                FillGrid();

            }
            catch (Exception)
            {
            }
            
        }
    }

    protected void FillGrid()
    {

        GvCountry.DataSource = objDALSDC.FillGridCountry();
        GvCountry.DataBind();
    }
    
    protected void btnSave_Click(object sender, EventArgs e)
    {
        
        string Message = "";
       
        if (!(txtCountryName.Text).Equals(string.Empty))
        {
            if (Convert.ToInt32(ViewState["ID"]) > 0)
            {
                objBELSDC = objDALSDC.SelectOneCountry(Convert.ToInt32(ViewState["ID"]));
                objBELSDC.CountryId = Convert.ToInt32(ViewState["ID"].ToString());
                objBELSDC.CountryName = txtCountryName.Text;
                objBELSDC.CountryCode = txtCountryCode.Text;
                objBELSDC.UpdatedBy = Convert.ToString(Session["username"]);
                objBELSDC.BranchId = Convert.ToInt32(Session["Branchid"]);
                Message = objDALSDC.UpdateCountry(objBELSDC);

            }
            else
            {
                objBELSDC.CountryName = txtCountryName.Text;
                objBELSDC.CountryCode = txtCountryCode.Text;
                objBELSDC.CreatedBy = Convert.ToString(Session["username"]);
                objBELSDC.BranchId = Convert.ToInt32(Session["Branchid"]);
                Message = objDALSDC.CountryInsert(objBELSDC);
            }
            DynamicMessage(lblMsg, Message);
        }
        FillGrid();
        Clearall();
       

    }

   
    private void Clearall()
    {
        txtCountryCode.Text = "";
        txtCountryName.Text = "";

        ViewState["ID"] = 0;
    }

   
    private void FillPage()
    {

        objBELSDC = objDALSDC.SelectOneCountry(Convert.ToInt32(ViewState["ID"]));
        txtCountryName.Text = objBELSDC.CountryName;
        txtCountryCode.Text = objBELSDC.CountryCode;
    }


   
    protected void btnReset_Click(object sender, EventArgs e)
    {
        Clearall();
        lblMsg.Visible = false;
      
    }
    
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        try
        {
            BLLReports objBLLReports = new BLLReports();
            DataSet dsCustomers = new DataSet();
            ReportDocument crystalReport = new ReportDocument();
            crystalReport.Load(Server.MapPath("~/Report/RptCountry.rpt"));
           // dsCustomers = objBLLReports.GetCountry();
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
    protected void GvCountry_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string Message;
        string ID = (GvCountry.DataKeys[e.RowIndex]["CountryId"].ToString());
        //GridView1.DataKeys[e.RowIndex]["CountryId"].ToString()
        ViewState["ID"] = ID;
        Message = objDALSDC.DeleteCountry(Convert.ToInt32(ID));
        DynamicMessage(lblMsg, Message);
        FillGrid();
        Clearall();
    }
    protected void GvCountry_RowEditing(object sender, GridViewEditEventArgs e)
    {

        try
        {

            string ID = (GvCountry.DataKeys[e.NewEditIndex]["CountryId"].ToString());
            ViewState["ID"] = ID;
            FillPage();
            e.Cancel = true;
        }
        catch (Exception ex)
        {

            lblMsg.Text = ex.Message;
        }
    }
    protected void GvCountry_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvCountry.PageIndex = e.NewPageIndex;
        FillGrid();
    }
}