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

public partial class StateMaster :BasePage
{
    BELSDC objBELSDC = new BELSDC();
    DALSDC objDALSDC = new DALSDC();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillGrid();
            FillCountryDrop();
           
        }

       
    }

    
    private void FillGrid()
    {
        gvState.DataSource = objDALSDC.FillGridState();
        gvState.DataBind();
    }

   
    private void FillCountryDrop()
    {

        ddlCountryName.DataSource = objDALSDC.FillCountryDrop();
        ddlCountryName.DataTextField = "CountryName";
        ddlCountryName.DataValueField = "CountryId";
        ddlCountryName.DataBind();
    }

   
    protected void btnSave_Click(object sender, EventArgs e)
    {
       
        string Message = "";
       
        if (!(txtStateName.Text).Equals(string.Empty))
        {
            if (Convert.ToInt32(ViewState["ID"]) > 0)
            {
                objBELSDC = objDALSDC.SelectOneState(Convert.ToInt32(ViewState["ID"]));
                objBELSDC.StateId = Convert.ToInt32(ViewState["ID"].ToString());
                objBELSDC.StateName = txtStateName.Text;
                if (ViewState["CountryID"].ToString() != null)
                    objBELSDC.CountryId = Convert.ToInt32(ViewState["CountryID"].ToString());
                else
                    objBELSDC.CountryId = Convert.ToInt32(ddlCountryName.SelectedValue.ToString());
                objBELSDC.UpdatedBy = Convert.ToString(Session["username"]);
                Message = objDALSDC.UpdateState(objBELSDC);
            }
            else
            {
                objBELSDC.StateName = txtStateName.Text;
                objBELSDC.CountryId = Convert.ToInt32(ddlCountryName.SelectedValue.ToString());
                objBELSDC.CreatedBy = Convert.ToString(Session["username"]);
                Message = objDALSDC.InsertState(objBELSDC);
            }
            DynamicMessage(lblMsg, Message);
        }
        FillGrid();
        Clearall();
       

    }
    
    private void Clearall()
    {
        txtStateName.Text = "";
        ddlCountryName.SelectedIndex = 0;
        ViewState["ID"] = 0;
    }

    /// <summary>
    /// Clearall()
    /// It Occurs when button Reset is Clicked.
    /// It Clear all Fields in the Form
    /// </summary>
    protected void btnReset_Click(object sender, EventArgs e)
    {
        Clearall();
        lblMsg.Text = "";

       
    }


    protected void gvState_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
    {
        string Message;
        string ID = (gvState.DataKeys[e.RowIndex]["StateId"].ToString());
        ViewState["ID"] = ID;
        Message = objDALSDC.DeleteState(Convert.ToInt32(ID));
        DynamicMessage(lblMsg, Message);
        FillGrid();

    }

   
    protected void gvState_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        try
        {
            
            string ID = (gvState.DataKeys[e.NewEditIndex]["StateId"].ToString());
            ViewState["ID"] = ID;
            FillPage();
            e.Cancel = true;
        }
        catch (Exception ex)
        {

            lblMsg.Text = ex.Message;
        }
    }

    /// <summary>
    ///  FillPage()
    ///  It Occurs when button Edit is Clicked.
    ///  It is Used For Fill Proper Records with its ID in its Fiels in the Form
    /// </summary>
    private void FillPage()
    {

        objBELSDC = objDALSDC.SelectOneState(Convert.ToInt32(ViewState["ID"]));
        txtStateName.Text = objBELSDC.StateName;
        ddlCountryName.SelectedValue = Convert.ToString(objBELSDC.CountryId);
        ViewState["CounrtyID"] = 0;
        ViewState["CountryID"] = Convert.ToString(objBELSDC.CountryId);
    }
    
    protected void ddlCountryName_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["CountryID"] = ddlCountryName.SelectedValue.ToString();
    }

    
    protected void txtStateName_TextChanged(object sender, EventArgs e)
    {
        txtStateName.Text = txtStateName.Text.Trim();
    }
    protected void gvState_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvState.PageIndex = e.NewPageIndex;
        FillGrid();
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        try
        {
            BLLReports objBLLReports = new BLLReports();
            DataSet dsCustomers = new DataSet();
            ReportDocument crystalReport = new ReportDocument();
            crystalReport.Load(Server.MapPath("/Report/RptState.rpt"));
           // dsCustomers = objBLLReports.GetState();
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