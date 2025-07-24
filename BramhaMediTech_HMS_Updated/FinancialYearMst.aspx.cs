using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FinancialYearMst :BasePage
{
    BELFinancialYear objBELFinancialYear = new BELFinancialYear();
    DALFinancialYear objDALFinancialYear = new DALFinancialYear();

   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
               
                show.Visible = false;
                List.Visible = true;
            }
            catch (Exception)
            {
            }
            FillFinancialYearGrid();
        }
    }

    /// <summary>
    /// It Calls When PageLoad Event Occur Or After RowEdit delete event of grid Completed OR After Save Button Click Event Completed
    /// It Fills the FinancialYear Grid From Table Data
    /// </summary>
    protected void FillFinancialYearGrid()
    {
        gvFinancialYear.DataSource = objDALFinancialYear.FillGridFinancialYear();
        gvFinancialYear.DataBind();
    }

   
    protected void btnSave_Click(object sender, EventArgs e)
    {
        
        string Message = "";
       
        if (!(txtFinancialYear.Text.Equals(string.Empty)))
        {
            if (Convert.ToInt32(ViewState["FinancialYearId"]) > 0)
            {
                
                objBELFinancialYear = objDALFinancialYear.SelectOneFinancialYear(Convert.ToInt32(ViewState["FinancialYearId"]));
                objBELFinancialYear.FinancialYearId = Convert.ToInt32(ViewState["FinancialYearId"]);
                objBELFinancialYear.FinancialYear = txtFinancialYear.Text;
                objBELFinancialYear.StartDate = Convert.ToDateTime(txtStartDate.Text);
                objBELFinancialYear.EndDate = Convert.ToDateTime(txtEndDate.Text);
                objBELFinancialYear.BranchId = Convert.ToInt32(Session["BranchId"]);
                objBELFinancialYear.UpdatedBy = Session["username"].ToString();

                Message = objDALFinancialYear.UpdateFinancialYear(objBELFinancialYear);

            }
            else
            {
                objBELFinancialYear.FinancialYear = txtFinancialYear.Text;        
                objBELFinancialYear.StartDate = Convert.ToDateTime(txtStartDate.Text);
                objBELFinancialYear.EndDate = Convert.ToDateTime(txtEndDate.Text);
                // objDOFinancialYear.HospitalId = Convert.ToInt32(ddlHospitalName.SelectedValue);
                objBELFinancialYear.CreatedBy = Session["username"].ToString();
                Message = objDALFinancialYear.InsertFinancialYear(objBELFinancialYear);

            }
            Reset();
            DynamicMessage(lblMessage, Message);
            FillFinancialYearGrid();
            show.Visible = false;
            List.Visible = true;
        }
    }

    /// <summary>
    ///  It Called When Reset Button Clicked
    /// </summary>
    /// <param name="sender">Sender Of Event</param>
    /// <param name="e">Event Occured</param>
    /// </summary>
    protected void btnReset_Click(object sender, EventArgs e)
    {
        Reset();
        show.Visible = false;
        List.Visible = true;
    }

    protected void btnaddnew_Click(object sender, EventArgs e)
    {
        show.Visible = true;
        List.Visible = false;
        lblMessage.Text = "";
        //txtSystemConstantName.ReadOnly = false;
    }

    private void Reset()
    {
        txtFinancialYear.Text = "";
        ViewState["FinancialYearId"] = 0;
        lblMessage.Text = "";
        txtEndDate.Text = "";
        txtStartDate.Text = "";
        //  ddlHospitalName.SelectedIndex = -1;

    }

   
    protected void gvFinancialYear_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            show.Visible = true;
            List.Visible = false;
            string FinancialYearId = (gvFinancialYear.DataKeys[e.NewEditIndex]["FinancialYearId"].ToString());
            ViewState["FinancialYearId"] = FinancialYearId;
            FillPage();
            e.Cancel = true;
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    /// <summary>
    /// It Calls Within RowEditing Event Of Grid
    /// It Fills Values Of Controls Regarding Selected Record of Grid.
    /// </summary>
    protected void FillPage()
    {
        try
        {
            objBELFinancialYear = objDALFinancialYear.SelectOneFinancialYear(Convert.ToInt32(ViewState["FinancialYearId"]));
            txtFinancialYear.Text = objBELFinancialYear.FinancialYear;
            txtStartDate.Text = Convert.ToString(objBELFinancialYear.StartDate);
            txtEndDate.Text = Convert.ToString(objBELFinancialYear.EndDate);
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }

    /// <summary>
    ///  It called when User click on Delete Button
    /// It deletes Row From Grid and FinancialYear Table Of Database.  
    /// </summary>
    ///<param name="sender">Sender Of Event</param>
    /// <param name="e">Event Occured</param>
    /// </summary>
    protected void gvFinancialYear_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string FinancialYearId = (gvFinancialYear.DataKeys[e.RowIndex]["FinancialYearId"].ToString());
        string Message = objDALFinancialYear.DeleteFinancialYear(Convert.ToInt32(FinancialYearId));
        DynamicMessage(lblMessage, Message);        
        FillFinancialYearGrid();
    }

   
    protected void gvFinancialYear_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvFinancialYear.PageIndex = e.NewPageIndex;
        FillFinancialYearGrid();
    }
    //protected void btnPrint_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        BLLReports objBLLReports = new BLLReports();
    //        DataSet dsCustomers = new DataSet();
    //        ReportDocument crystalReport = new ReportDocument();
    //        crystalReport.Load(Server.MapPath("~/Report/RptFinancialYear.rpt"));
    //        dsCustomers = objBLLReports.GetFinancialYear();
    //        crystalReport.SetDataSource(dsCustomers);
    //        crystalReport.ParameterFields["HospitalName"].CurrentValues.AddValue(Convert.ToString(Application["OrgnizationName"]));
    //        crystalReport.ParameterFields["HospitalAddress"].CurrentValues.AddValue(Convert.ToString(Application["OrgnizationAddress"]));
    //        //crystalReport.ParameterFields["Image"].CurrentValues.AddValue(Application["ImagePath"]);
    //        crystalReport.ParameterFields["ReportFooter"].CurrentValues.AddValue("Hospital Software | Ph.020 0000000000");
    //        crystalReport.ExportToHttpResponse
    //        (CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Employee");
    //    }
    //    catch (Exception ex)
    //    {
    //        lblMessage.Text = ex.Message;
    //    }
    //}
}