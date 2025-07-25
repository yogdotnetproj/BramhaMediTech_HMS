

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
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.Collections;
using System.IO;

public partial class SurgeryDepositMaster :BasePage
{
    BLLPatientCategory objBLLPatientCategory = new BLLPatientCategory();
    DOPatientCategory objDOPatientCategory;
    BELBillCharges objBELBillCharges = new BELBillCharges();
    DALBillCharges objDALBillCharges = new DALBillCharges();
    public enum MessageType { Success, Error, Info, Warning };
    string UserId = "";


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                FillPatientSubCategoryGrid();
                FillPatMainTypeDrop();
                FillRateTypeDrop();
               //FillLabRateTypeDrop();
            }
            catch (Exception)
            {
            }

        }
    }
    protected void FillLabRateTypeDrop()
    {

        //ddlLabRateType.DataSource = objDALBillCharges.FillLabRateTypeDrop();
        //ddlLabRateType.DataValueField = "RatID";
        //ddlLabRateType.DataTextField = "RateName";
        //ddlLabRateType.DataBind();


    }
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
      
    protected void FillRateTypeDrop()
    {

        DdlSurgeryType.DataSource = objBLLPatientCategory.GetSurgeryType();
        DdlSurgeryType.DataTextField = "SurgeryName";
        DdlSurgeryType.DataValueField = "SurgeryId";
        DdlSurgeryType.DataBind();
        DdlSurgeryType.Items.Insert(0, new ListItem("seleyct Surger", "0"));
        DdlSurgeryType.SelectedIndex = 0;
    }
    protected void FillPatientSubCategoryGrid()
    {
        gvPatientSubCat.DataSource = objBLLPatientCategory.GetAllSurgeryDepositAmount();
        gvPatientSubCat.DataBind();
    }


    

    protected void btnsave_Click(object sender, EventArgs e)
    {
        if (Session["UserId"] != null)
            UserId = Session["UserId"].ToString();
        string Message = "";
        objDOPatientCategory = new DOPatientCategory();

        if (txtsurgeryDepositAmt.Text == "")
        {
            ShowMessage("Enter deposit amount", MessageType.Warning);
            txtsurgeryDepositAmt.Focus();
            return;
        }
        if (txtsurgeryDepositAmt.Text == "0")
        {
            ShowMessage("Enter deposit amount", MessageType.Warning);
            txtsurgeryDepositAmt.Focus();
            return;
        }
        if (Convert.ToInt32(ViewState["SurgID"]) > 0)
            {
                objDOPatientCategory.RoomType = Convert.ToInt32(ddlRoomType.SelectedValue);
                objDOPatientCategory.SurgeryType = Convert.ToString(DdlSurgeryType.SelectedItem.Text);

                objDOPatientCategory.SurgeryDeposotAmt = Convert.ToSingle( txtsurgeryDepositAmt.Text);
               
                objDOPatientCategory.CreatedBy = Convert.ToString(Session["username"]);
                objDOPatientCategory.FId = Convert.ToInt32(Session["FId"]); ;
                objDOPatientCategory.BranchId = Convert.ToInt32(Session["Branchid"]);

                objDOPatientCategory.ID = Convert.ToInt32(ViewState["SurgID"]);

                Message = objBLLPatientCategory.Update_SurgeryDepositAmount(objDOPatientCategory);
                ShowMessage("Record Update successfully", MessageType.Success);
            }
            else
            {
                objDOPatientCategory.RoomType = Convert.ToInt32(ddlRoomType.SelectedValue);
                objDOPatientCategory.SurgeryType = Convert.ToString(DdlSurgeryType.SelectedItem.Text);

                objDOPatientCategory.SurgeryDeposotAmt = Convert.ToSingle( txtsurgeryDepositAmt.Text);
                

                objDOPatientCategory.CreatedBy = Convert.ToString(Session["username"]);
                objDOPatientCategory.FId = Convert.ToInt32(Session["FId"]); ;
                objDOPatientCategory.BranchId = Convert.ToInt32(Session["Branchid"]);


                Message = objBLLPatientCategory.InsertSurgeryDeposit_Amount(objDOPatientCategory);
                ShowMessage("Record submitted successfully", MessageType.Success);
            }

            DynamicMessage(lblMessage, Message);

            FillPatientSubCategoryGrid();
            txtsurgeryDepositAmt.Text = "";

            ViewState["PatientCategoryID"] = 0;

        

    }


    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtsurgeryDepositAmt.Text = "";
        ViewState["SurgID"] = 0;
        lblMessage.Text = "";
        


    }


    protected void FillPage()
    {
        try
        {
           // FillPatMainTypeDrop();
            objDOPatientCategory = objBLLPatientCategory.Select_SurgeryDepositAmount(Convert.ToInt32(ViewState["SurgID"]));
          
            ddlRoomType.SelectedValue = Convert.ToString(objDOPatientCategory.RoomType);
           
           DdlSurgeryType.SelectedItem.Text = Convert.ToString(objDOPatientCategory.SurgeryType);

            txtsurgeryDepositAmt.Text = Convert.ToString(objDOPatientCategory.SurgeryDeposotAmt);
           
           
           
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }


  



    protected void gvPatientSubCat_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string PatientCategoryID = (gvPatientSubCat.DataKeys[e.RowIndex]["Id"].ToString());

        string Message = objBLLPatientCategory.Delete_SurgeryDeposit(Convert.ToInt32(PatientCategoryID));//Convert.ToInt32(ViewState["PCId"])
        DynamicMessage(lblMessage, Message);
        FillPatientSubCategoryGrid();
        txtsurgeryDepositAmt.Text = "";
        ShowMessage("Record Delete Successfully", MessageType.Error);


    }
    protected void gvPatientSubCat_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {

            string SurgDepositID = (gvPatientSubCat.DataKeys[e.NewEditIndex]["Id"].ToString());
            ViewState["SurgID"] = SurgDepositID;
            FillPage();
            e.Cancel = true;
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    protected void gvPatientSubCat_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvPatientSubCat.PageIndex = e.NewPageIndex;
       
            FillPatientSubCategoryGrid();
        
    }
    
    public void FillPatMainTypeDrop()
    {

        ddlRoomType.DataSource = objBLLPatientCategory.GetRoomType();
        ddlRoomType.DataTextField = "RType";
        ddlRoomType.DataValueField = "RTypeId";
        ddlRoomType.DataBind();
        // ddlRoomType.Items.Insert(0, new ListItem("Select RoomType", "0"));
        ddlRoomType.SelectedIndex = 0;
    }

   
}