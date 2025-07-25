using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SetIPDRoomCharges :BasePage
{
    BELBillCharges objBELBillCharges = new BELBillCharges();
    DALBillCharges objDALBillCharges = new DALBillCharges();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            FillRateTypeDrop();
        }
    }
   
    protected void FillRateTypeDrop()
    {

        ddlRateType.DataSource = objDALBillCharges.FillRateTypeDrop();
        ddlRateType.DataValueField = "RateTypeId";
        ddlRateType.DataTextField = "RateType";
        ddlRateType.DataBind();
        ddlcategory.DataSource = objDALBillCharges.FillPatientcategory();
        ddlcategory.DataValueField = "PatMainTypeId";
        ddlcategory.DataTextField = "PatMainType";
        ddlcategory.DataBind();

    }
    protected void ddlPatientType_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
    protected void gvBillServiceCharge_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void gvBillServiceCharge_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void gvBillServiceCharge_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
   
    protected void btnsave_Click(object sender, EventArgs e)
    {
        string Message = "";
        for (int p = 0; p < gvBillServiceCharge.Rows.Count; p++)
        {
            if ((gvBillServiceCharge.Rows[p].Cells[2].FindControl("txtRoomCharges") as TextBox).Text != "")
            {
                string ServiceName = gvBillServiceCharge.Rows[p].Cells[1].Text;
                int ServiceId = Convert.ToInt32(gvBillServiceCharge.DataKeys[p].Values[0]);
                int RateTypeId = Convert.ToInt32(ddlRateType.SelectedValue);
                int PatientType = Convert.ToInt32(ddlPatientType.SelectedValue);
                int Groupid = Convert.ToInt32(0);
                float ServicAmt = Convert.ToSingle((gvBillServiceCharge.Rows[p].Cells[2].FindControl("txtRoomCharges") as TextBox).Text);
                objDALBillCharges.IsRoomCharges = true;
               // Message = objDALBillCharges.InsertUpdate_BillService_Charges(Convert.ToInt32(ServiceId), Convert.ToInt32(PatientType), Convert.ToInt32(RateTypeId), Convert.ToSingle(ServicAmt), "Single", Convert.ToInt32(Session["Branchid"]), Convert.ToString(Session["username"]), 0, Convert.ToInt32(ddlcategory.SelectedValue), 0, 0,false,true,false);

            }
        }
        DynamicMessage(lblMessage, Message);
       // lblMessage.Text = "Record save Successfully.!";
    }
    protected void btnaction_Click(object sender, EventArgs e)
    {
            objDALBillCharges.Branchid = Convert.ToInt32( Session["Branchid"]);
            //gvBillServiceCharge.DataSource = objDALBillCharges.Get_RoomCategory();
            //gvBillServiceCharge.DataBind();

       
    }
}