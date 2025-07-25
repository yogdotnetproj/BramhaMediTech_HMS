using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OperationMainCategory :BasePage
{
    BELOperationTheater objBELOt = new BELOperationTheater();
    DALOperationTheater objDALOt = new DALOperationTheater();
        
    


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                FillOpMainCatGrid();
                FillDeptDrop();
            }
            catch (Exception)
            {
            }

        }
    }


    protected void FillOpMainCatGrid()
    {
        gvOpMainCat.DataSource = objDALOt.FillGridOpMainCat();
        gvOpMainCat.DataBind();
    }




    protected void btnsave_Click(object sender, EventArgs e)
    {
        
        string Message = "";

        if (!(txtOpMainCat.Text.Equals(string.Empty)))
        {
            if (Convert.ToInt32(ViewState["OTDeptId"]) > 0)
            {
                //objBELOt = objDALOt.SelectOneOpMainCat(Convert.ToInt32(ViewState["OTDeptId"]));
                objBELOt.OTDeptName = txtOpMainCat.Text;
                objBELOt.OTDeptId = Convert.ToInt32(ViewState["OTDeptId"]);
                objBELOt.DeptId = Convert.ToInt32(ddlDept.SelectedValue.ToString());
                objBELOt.UpdatedBy = Convert.ToString(Session["username"]);
                objBELOt.BranchId = Convert.ToInt32(Session["Branchid"]);
                Message = objDALOt.UpdateOpMainCat(objBELOt);
            }
            else
            {
                objBELOt.OTDeptName = txtOpMainCat.Text;
                // objDOPatientCategory.IsActive = true;
                objBELOt.CreatedBy = Convert.ToString(Session["username"]);
                objBELOt.FId = "1";
                objBELOt.BranchId = Convert.ToInt32(Session["Branchid"]);
                objBELOt.DeptId = Convert.ToInt32(ddlDept.SelectedValue);

                Message = objDALOt.InsertOpMainCat(objBELOt);
            }

            DynamicMessage(lblMessage, Message);

            FillOpMainCatGrid();
            txtOpMainCat.Text = "";
            ddlDept.SelectedValue = "0";
            ViewState["OTDeptId"] = 0;

        }

    }


    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtOpMainCat.Text = "";
        ViewState["OTDeptId"] = 0;
        lblMessage.Text = "";
        ddlDept.SelectedValue = "0";


    }


    protected void FillPage()
    {
        try
        {
            objBELOt = objDALOt.SelectOneOpMainCat(Convert.ToInt32(ViewState["OTDeptId"]));
            txtOpMainCat.Text = objBELOt.OTDeptName;
            ddlDept.SelectedValue = Convert.ToString(objBELOt.DeptId);
            
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }


    //protected void btnPrint_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        BLLReports objBLLReports = new BLLReports();
    //        DataSet dsCustomers = new DataSet();
    //        ReportDocument crystalReport = new ReportDocument();
    //        crystalReport.Load(Server.MapPath("~/Report/RptPatientCatagory.rpt"));
    //        //dsCustomers = objBLLReports.GetPatientCategory();
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




    protected void gvOpMainCat_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string OTDeptId = (gvOpMainCat.DataKeys[e.RowIndex]["OTDeptId"].ToString());

        string Message = objDALOt.DeleteOpMainCat(Convert.ToInt32(OTDeptId));//Convert.ToInt32(ViewState["PCId"])
        DynamicMessage(lblMessage, Message);
        FillOpMainCatGrid();
        txtOpMainCat.Text = "";
    }
    protected void gvOpMainCat_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {

            string OTDeptId = (gvOpMainCat.DataKeys[e.NewEditIndex]["OTDeptId"].ToString());
            ViewState["OTDeptId"] = OTDeptId;
            FillPage();
            e.Cancel = true;
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void gvOpMainCat_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvOpMainCat.PageIndex = e.NewPageIndex;
        FillOpMainCatGrid();
    }

    public void FillDeptDrop()
    {

        ddlDept.DataSource = objDALOt.FillDeptCombo();
        ddlDept.DataTextField = "DeptName";
        ddlDept.DataValueField = "DeptId";
        ddlDept.DataBind();
       
    }

}