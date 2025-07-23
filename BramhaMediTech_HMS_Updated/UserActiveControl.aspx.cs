using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Services;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using CrystalDecisions.CrystalReports.Engine;


public partial class UserActiveControl : System.Web.UI.Page
{
    TreeviewBind_C ObjTB = new TreeviewBind_C();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           

            FillPurchaseOrderList();
        }
        this.RegisterPostBackControl();
    }
 
    public void FillPurchaseOrderList()
    {     


       // PODetails.Fid = Convert.ToInt32(Session["FId"]);
       // PODetails.BranchId = Convert.ToInt32(Session["BranchId"]);

        gvPurchaseList.DataSource = ObjTB.Get_UserStatus( Convert.ToInt32(RblType.SelectedValue));
        gvPurchaseList.DataBind();

      
    }

   
    protected void btnSearch_Click(object sender, EventArgs e)
    {

        gvPurchaseList.DataSource = ObjTB.Get_UserStatus(Convert.ToInt32(RblType.SelectedValue));
        gvPurchaseList.DataBind();
    }

    protected void gvPurchaseList_PageIndexChanging1(object sender, GridViewPageEventArgs e)
    {
        gvPurchaseList.PageIndex = e.NewPageIndex;

        FillPurchaseOrderList();
        
    }
    private void RegisterPostBackControl()
    {
        foreach (GridViewRow row in gvPurchaseList.Rows)
        {
           // Button Btnprint = row.FindControl("Btnprint") as Button;
           // ScriptManager.GetCurrent(this).RegisterPostBackControl(Btnprint);
        }
    }

  
  
    protected void btnDetails_Click(object sender, EventArgs e)
    {
        Button btnDetails = (Button)sender;
        GridViewRow row = (GridViewRow)btnDetails.NamingContainer;
       // CheckBox ChkFinalApproval = (CheckBox)sender;
        //GridViewRow row1 = (GridViewRow)ChkFinalApproval.NamingContainer;
        // this.ScriptManager.RegisterPostBackControl();
        this.RegisterPostBackControl();
        string PatRegId = Convert.ToString(gvPurchaseList.DataKeys[row.RowIndex]["CUId"].ToString());
        //int IpdNo = Convert.ToInt32(gvPurchaseList.DataKeys[row.RowIndex]["IpdNo"].ToString());
     
        CheckBox ChkFinalApproval = gvPurchaseList.Rows[row.RowIndex].FindControl("ChkFinalApproval") as CheckBox;
     // CheckBox   ChkFinalApproval= ((gvPurchaseList.Rows[row].FindControl("HdnDoseID") as CheckBox).Checked);
        if (ChkFinalApproval.Checked == true)
        {
            //BELPatientIssueVoucher PODetails = new BELPatientIssueVoucher();
            //BAL PoInfo = new BAL();
            //DAL InvoiceDetails = new DAL();


            //    PODetails.IpdNo = Convert.ToInt32(IpdNo);


            //    PODetails.PatRegNo = Convert.ToString( PatRegId);

            //PODetails.Fid = Convert.ToInt32(Session["FId"]);
            //PODetails.BranchId = Convert.ToInt32(Session["BranchId"]);
            //PODetails.CreatedBy = Convert.ToString(Session["username"]);
            //InvoiceDetails.Insert_UpdatePharma_BillApproval(PODetails);
            ObjTB.UpdateUserActive(0, Convert.ToInt32(PatRegId));
            lblMsg.Text = "De-Active successfully!.";
        }
        else
        {
            ObjTB.UpdateUserActive(1, Convert.ToInt32(PatRegId));
            lblMsg.Text = "Active successfully!.";
        }
    }

   
    protected void gvPurchaseList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex == -1)
            return;

        bool ReceiveToPharma = Convert.ToBoolean((e.Row.FindControl("HdnReceiveToPharma") as HiddenField).Value.Trim());
        if (ReceiveToPharma == true)
        {
            e.Row.Cells[0].Text = "<span class='btn btn-xs btn-success' >Active</span>";
           // e.Row.Cells[9].Enabled = false;
        }
        else
        {
            e.Row.Cells[0].Text = "<span class='btn btn-xs btn-danger' >DeActive</span>";
        }
    }
    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void btnsearch_Click(object sender, EventArgs e)
    {
        FillPurchaseOrderList();
    }
}