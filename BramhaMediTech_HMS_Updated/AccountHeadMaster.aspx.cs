using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using System.Data;

public partial class AccountHeadMaster :BasePage
{
    BELDepartment objBELDept = new BELDepartment();
    DALDepartment objDALDept = new DALDepartment();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillDepartmentGrid();
           
            show.Visible = false;
            List.Visible = true;

        }
    }
    protected void FillDepartmentGrid()
    {
        gvDepartment.DataSource = objDALDept.FillGrid_AccountHead();
        gvDepartment.DataBind();
    }

   
    protected void btnSave_Click(object sender, EventArgs e)
    {
        
        string Message = "";
       
        if (!(txtDepartmentName.Text.Equals(string.Empty)))
        {
            if (Convert.ToInt32(ViewState["DepartmentID"]) > 0)
            {
                objBELDept = objDALDept.SelectOneDept(Convert.ToInt32(ViewState["DepartmentID"]));
                objBELDept.DeptName = txtDepartmentName.Text;
                objBELDept.DeptId = Convert.ToInt32(ViewState["DepartmentID"]);

               
                     objBELDept.DeptCode = txtdeptcode.Text;
                
                    objBELDept.UpdatedBy = Convert.ToString(Session["username"]);

                    Message = objDALDept.Update_AccountHead(objBELDept);
                   // exampleModal.Visible = false;
                    
            }
            else
            {
                objBELDept.DeptName = txtDepartmentName.Text;                
                objBELDept.DeptCode = txtdeptcode.Text;
               // objBELDept.CreatedBy = Convert.ToString(Session["username"]);

                Message = objDALDept.InsertAccount_Head(objBELDept);
            }

            DynamicMessage(lblMessage, Message);

            FillDepartmentGrid();
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
        txtDepartmentName.Text = "";
        ViewState["DepartmentID"] = 0;        
        lblMessage.Text = "";
        show.Visible = false;
        List.Visible = true;

    }
    private void clearall()
    {
        txtDepartmentName.Text = "";
        ViewState["DepartmentID"] = 0;
        
    }
    
    protected void FillPage()
    {
        try
        {
            objBELDept = objDALDept.GetAccount_Code(Convert.ToInt32(ViewState["DepartmentID"]));
            txtDepartmentName.Text = objBELDept.DeptName;
            txtdeptcode.Text = objBELDept.DeptCode;
            
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
            crystalReport.Load(Server.MapPath("~/Report/RptSubDepartment.rpt"));
            //dsCustomers = objBLLReports.GetSubDepartment();
            crystalReport.SetDataSource(dsCustomers);
            crystalReport.ParameterFields["HospitalName"].CurrentValues.AddValue(Convert.ToString(Application["OrgnizationName"]));
            crystalReport.ParameterFields["HospitalAddress"].CurrentValues.AddValue(Convert.ToString(Application["OrgnizationAddress"]));
            //crystalReport.ParameterFields["Image"].CurrentValues.AddValue(Application["ImagePath"]);
            crystalReport.ParameterFields["ReportFooter"].CurrentValues.AddValue("Hospital Software | Ph.020 0000000000");
            try
            {
                crystalReport.ExportToHttpResponse
                (CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Employee");
            }
            catch (Exception ex)
            {
            }
            finally
            {
                crystalReport.Close();
                ((IDisposable)crystalReport).Dispose();
                GC.Collect();
                GC.SuppressFinalize(crystalReport);
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void gvDepartment_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            show.Visible = true;
            List.Visible = false;

            string DepartmentID = (gvDepartment.DataKeys[e.NewEditIndex]["ID"].ToString());
            ViewState["DepartmentID"] = DepartmentID;
            FillPage();
            e.Cancel = true;
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }

    }
    protected void gvDepartment_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string DepartmentID = (gvDepartment.DataKeys[e.RowIndex]["DeptId"].ToString());

        string Message = objDALDept.DeleteDepartment(Convert.ToInt32(DepartmentID));
        DynamicMessage(lblMessage, Message);

        FillDepartmentGrid();
        clearall();

    }
    protected void gvDepartment_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDepartment.PageIndex = e.NewPageIndex;
        FillDepartmentGrid();
    }
    
    
}