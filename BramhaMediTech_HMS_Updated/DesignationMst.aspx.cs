using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class DesignationMst : BaseClass
{
    BELDesignation objBELDesg = new BELDesignation();
    DALDesignation objDALDesg = new DALDesignation();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillDesgGrid();

            show.Visible = false;
            List.Visible = true;

        }
    }
    protected void FillDesgGrid()
    {
        gvDesignation.DataSource = objDALDesg.FillGridDesg();
        gvDesignation.DataBind();
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {

        string Message = "";

        if (!(txtDesignationName.Text.Equals(string.Empty)))
        {
            if (Convert.ToInt32(ViewState["DesgID"]) > 0)
            {
                //objBELDesg = objDALDesg.SelectOneDesg(Convert.ToInt32(ViewState["DesgID"]));
                objBELDesg.Designation = txtDesignationName.Text;
                objBELDesg.DesignationId = Convert.ToInt32(ViewState["DesgID"]);
                objBELDesg.UpdatedBy = Convert.ToString(Session["username"]);

                Message = objDALDesg.UpdateDesg(objBELDesg);
            }
            else
            {
                objBELDesg.Designation = txtDesignationName.Text;
                objBELDesg.FId = "1";
                objBELDesg.BranchId = Convert.ToInt32(Session["Branchid"]);
                objBELDesg.CreatedBy = Convert.ToString(Session["username"]);

                Message = objDALDesg.InsertDesg(objBELDesg);
            }

            DynamicMessage(lblMessage, Message);

            FillDesgGrid();
            clearall();
        }
        show.Visible = false;
        List.Visible = true;

    }
    protected void btnaddnew_Click(object sender, EventArgs e)
    {
        show.Visible = true;
        List.Visible = false;
        lblMessage.Text = "";
    }


    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtDesignationName.Text = "";
        ViewState["DesgID"] = 0;
        lblMessage.Text = "";
        show.Visible = false;
        List.Visible = true;

    }
    private void clearall()
    {
        txtDesignationName.Text = "";
        ViewState["DesgID"] = 0;

    }

    protected void FillPage()
    {
        try
        {
            objBELDesg = objDALDesg.SelectOneDesg(Convert.ToInt32(ViewState["DesgID"]));
            txtDesignationName.Text = objBELDesg.Designation;
            

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
    //        crystalReport.Load(Server.MapPath("~/Report/RptSubDepartment.rpt"));
    //        //dsCustomers = objBLLReports.GetSubDepartment();
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
    protected void gvDesignation_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            show.Visible = true;
            List.Visible = false;

            string DepartmentID = (gvDesignation.DataKeys[e.NewEditIndex]["DesignationId"].ToString());
            ViewState["DesgID"] = DepartmentID;
            FillPage();
            e.Cancel = true;
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }

    }
    protected void gvDesignation_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string DesgID = (gvDesignation.DataKeys[e.RowIndex]["DesignationId"].ToString());

        string Message = objDALDesg.DeleteDesg(Convert.ToInt32(DesgID));
        DynamicMessage(lblMessage, Message);

        FillDesgGrid();
        clearall();

    }
    protected void gvDesignation_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDesignation.PageIndex = e.NewPageIndex;
        FillDesgGrid();
    }
    
}