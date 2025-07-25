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

public partial class PatientCategory :BasePage
{
    BLLPatientCategory objBLLPatientCategory = new BLLPatientCategory();
    DOPatientCategory objDOPatientCategory;
    string UserId = "";
    public enum MessageType { Success, Error, Info, Warning };
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                FillPatientCategoryGrid(); 
            }
            catch (Exception)
            {
            }
           
        }
    }

    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
    protected void FillPatientCategoryGrid()
    {
        gvPatientCat.DataSource = objBLLPatientCategory.FillGrid();
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
        //Thread.Sleep(6000);
        //System.Threading.Thread.Sleep(3000);
       
        if (!(txtPatientCat.Text.Equals(string.Empty)))
        {
            if (Convert.ToInt32(ViewState["PatientCategoryID"]) > 0)
            {
                objDOPatientCategory = objBLLPatientCategory.SelectOne(Convert.ToInt32(ViewState["PatientCategoryID"]));
                objDOPatientCategory.PatMainType = txtPatientCat.Text;
                objDOPatientCategory.PatMainTypeId = Convert.ToInt32(ViewState["PatientCategoryID"]);                
                objDOPatientCategory.UpdatedBy =Convert.ToString(Session["username"]);
                objDOPatientCategory.BranchId = Convert.ToInt32(Session["Branchid"]);
                Message = objBLLPatientCategory.UpdatePatientCategory(objDOPatientCategory);
               // MsgText.Visible = true;
                ShowMessage("Record Update successfully", MessageType.Success);
            }
            else
            {
                objDOPatientCategory.PatMainType = txtPatientCat.Text;
               // objDOPatientCategory.IsActive = true;
                objDOPatientCategory.CreatedBy = Convert.ToString(Session["username"]);
                objDOPatientCategory.FId = Convert.ToInt32(Session["FId"]); ;
                objDOPatientCategory.BranchId = Convert.ToInt32(Session["Branchid"]);
                Message = objBLLPatientCategory.InsertPatientCategory(objDOPatientCategory);
               // MsgText.Visible = true;
                ShowMessage("Record Save successfully", MessageType.Success);
            }

           // DynamicMessage(lblMessage, Message);

            FillPatientCategoryGrid();
            txtPatientCat.Text = "";
            ViewState["PatientCategoryID"] = 0;
           
        }
       
    }

   
    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtPatientCat.Text = "";
        ViewState["PatientCategoryID"] = 0;
        lblMessage.Text = "";
        

    }

    
    protected void FillPage()
    {
        try
        {
            objDOPatientCategory = objBLLPatientCategory.SelectOne(Convert.ToInt32(ViewState["PatientCategoryID"]));
            txtPatientCat.Text = objDOPatientCategory.PatMainType;
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
        string PatientCategoryID = (gvPatientCat.DataKeys[e.RowIndex]["PatMainTypeId"].ToString());

        string Message = objBLLPatientCategory.DeletePatientCategory(Convert.ToInt32(PatientCategoryID));//Convert.ToInt32(ViewState["PCId"])
       // DynamicMessage(lblMessage, Message);
        ShowMessage("Record Delete Successfully", MessageType.Error);
        FillPatientCategoryGrid();
        txtPatientCat.Text = "";
        

    }
    protected void gvPatientCat_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {

            string PatientCategoryID = (gvPatientCat.DataKeys[e.NewEditIndex]["PatMainTypeId"].ToString());
            ViewState["PatientCategoryID"] = PatientCategoryID;
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
        FillPatientCategoryGrid();
    }
    
}