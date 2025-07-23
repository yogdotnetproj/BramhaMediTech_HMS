using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CancelPatReg : BaseClass

{
    BELPatientInformation objBELPatInfo = new BELPatientInformation();
    DALPatientInformation objDALPatInfo = new DALPatientInformation();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           

            // txtEntryDate.Text = DateTime.Now.ToShortDateString();
            txtToDate.Text = System.DateTime.Now.ToShortDateString();
            txtFromDate.Text = System.DateTime.Now.ToShortDateString();
            FillPatientInfoGrid();



        }
    }

    protected void FillPatientInfoGrid()
    {
        objBELPatInfo.PatRegId = txtPrnNo.Text;
        
        objBELPatInfo.PatientName = txtPatientName.Text;
        
        ViewState["FromDate"] = Convert.ToDateTime(txtFromDate.Text).ToString("yyyy-MM-dd");
        ViewState["ToDate"] = Convert.ToDateTime(txtToDate.Text).ToString("yyyy-MM-dd");
        
        objBELPatInfo.MobileNo = txtMobileNo.Text;
        gvPatientInfo.DataSource = objDALPatInfo.FillGrid(objBELPatInfo, Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]),"");
        gvPatientInfo.DataBind();
    }


    

    protected void gvEmployee_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            string PatientInfoID = (gvPatientInfo.DataKeys[e.NewEditIndex]["PatientInfoId"].ToString());
            ViewState["PatientInfoID"] = PatientInfoID;
            Response.Redirect("~/PatientInformation.aspx?PatientInfoID=" + PatientInfoID);

        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }

    protected void gvEmployee_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string PatientInfoID = (gvPatientInfo.DataKeys[e.RowIndex]["PatientInfoId"].ToString());

        string Message = objDALPatInfo.DeletePatientInfo(Convert.ToInt32(PatientInfoID));
        DynamicMessage(lblMessage, Message);

        FillPatientInfoGrid();
    }

    protected void gvPatientInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvPatientInfo.PageIndex = e.NewPageIndex;
        FillPatientInfoGrid();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        FillPatientInfoGrid();
       // Reset();
    }

    private void Reset()
    {
       
        txtPatientName.Text = "";
        txtPrnNo.Text = "";
        
    }

   

   
}