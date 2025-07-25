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


public partial class InitialMst :BasePage
{
    BELInitial objBELInitial = new BELInitial();
    DALInitial ObjDALInitial = new DALInitial();
    string Message = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadGenderName();
            FillInitialGrid();
           
        }
    }
    private void LoadGenderName()
    {

        ddlGender.DataSource = ObjDALInitial.FillGenderCombo();
        ddlGender.DataTextField = "GenderName";
        ddlGender.DataValueField = "GenderId";
        ddlGender.DataBind();
        ddlGender.Items.Insert(0, "Select Gender");
        ddlGender.SelectedIndex = 0;
    }
   
    

    
    public void FillInitialGrid()
    {
        gvTitle.DataSource = ObjDALInitial.FillGrid();
        gvTitle.DataBind();
    }

    protected void txtTitleName_TextChanged(object sender, EventArgs e)
    {
        txtTitleName.Text = txtTitleName.Text.Trim();
    }

    
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //if (Session["UserId"] != null)
        //    UserId = Session["UserId"].ToString();
        //string Message = "";
        
        if (!(txtTitleName.Text.Equals(string.Empty)))
        {
            if (Convert.ToInt32(ViewState["TitleID"]) > 0)
            {
                objBELInitial = ObjDALInitial.SelectOneInitial(Convert.ToInt32(ViewState["TitleID"]));
                objBELInitial.TitleId = Convert.ToInt32(ViewState["TitleID"]);
                objBELInitial.TitleName = txtTitleName.Text;
                objBELInitial.GenderId = Convert.ToInt32(ddlGender.SelectedValue);
                objBELInitial.UpdatedBy = Convert.ToString(Session["username"]);
                if (IsDefault.Checked == true)
                {
                    objBELInitial.IsDefault = true;
                }
                else
                    objBELInitial.IsDefault = false;
                
                Message = ObjDALInitial.UpdateTitle(objBELInitial);
            }
            else
            {
                objBELInitial.TitleName = txtTitleName.Text;
                objBELInitial.GenderId = Convert.ToInt32(ddlGender.SelectedValue);
                objBELInitial.CreatedBy = Convert.ToString(Session["username"]);
                objBELInitial.FId = Convert.ToInt32(Session["FId"]); 
                objBELInitial.BranchId = Convert.ToInt32(Session["Branchid"]);
                if (IsDefault.Checked == true)
                {
                    objBELInitial.IsDefault = true;
                }
                else
                    objBELInitial.IsDefault = false;
                
                Message = ObjDALInitial.InsertTitle(objBELInitial);
            }

            DynamicMessage(lblMessage, Message);

            FillInitialGrid();
            ClearAll();
           
        }
    }

    /// <summary>
    ///  It Called When Reset Button Clicked
    /// </summary>
    /// <param name="sender">Sender Of Event</param>
    /// <param name="e">Event Occured</param>
    protected void btnReset_Click(object sender, EventArgs e)
    {
        Reset();
      

    }

    private void Reset()
    {
        txtTitleName.Text = "";
        ddlGender.SelectedIndex = 0;
        ViewState["TitleID"] = 0;
        lblMessage.Text = "";

    }

    private void ClearAll()
    {
        txtTitleName.Text = "";
        ddlGender.SelectedIndex = 0;
        ViewState["TitleID"] = 0;
        //lblMessage.Text = "";


    }

    
    protected void gvTitle_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
           
            string TitleID = (gvTitle.DataKeys[e.NewEditIndex]["TitleId"].ToString());
            ViewState["TitleID"] = TitleID;
            FillPage();
            e.Cancel = true;
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }

   
    protected void FillPage()
    {
        try
        {
            objBELInitial = ObjDALInitial.SelectOneInitial(Convert.ToInt32(ViewState["TitleID"]));
            txtTitleName.Text = objBELInitial.TitleName;
            ddlGender.SelectedValue = Convert.ToString(objBELInitial.GenderId);
            IsDefault.Checked = objBELInitial.IsDefault;
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }

    /// <summary>
    ///  It called when User click on Delete Button
    /// It deletes Row From Grid and Title Table Of Database.  
    /// </summary>
    ///<param name="sender">Sender Of Event</param>
    /// <param name="e">Event Occured</param>
    protected void gvTitle_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string TitleID = (gvTitle.DataKeys[e.RowIndex]["TitleId"].ToString());

        string Message = ObjDALInitial.DeleteTitle(Convert.ToInt32(TitleID));
        DynamicMessage(lblMessage, Message);
        FillInitialGrid();
       


    }

    protected void gvTitle_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvTitle.PageIndex = e.NewPageIndex;
        FillInitialGrid();
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        try
        {
            BLLReports objBLLReports = new BLLReports();
            DataSet dsCustomers = new DataSet();
            ReportDocument crystalReport = new ReportDocument();
            crystalReport.Load(Server.MapPath("~/Report/RptTitle.rpt"));
           // dsCustomers = objBLLReports.GetTitle();
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
    protected void ddlGender_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    

}