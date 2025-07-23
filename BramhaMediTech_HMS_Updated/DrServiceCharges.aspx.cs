using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DrServiceCharges :  BaseClass
{

    BELBillCharges objBELBillCharges = new BELBillCharges();
    DALBillCharges objDALBillCharges = new DALBillCharges();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillBillServiceDrop(ddlPatientType.SelectedValue);
            FillRateTypeDrop();
        }
    }
    protected void FillBillServiceDrop(string PatType)
    {

        ddlBillService.DataSource = objDALBillCharges.GetDrCharges(PatType);
        ddlBillService.DataValueField = "BillServiceId";
        ddlBillService.DataTextField = "ServiceName";
        ddlBillService.DataBind();

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
        FillBillServiceDrop(ddlPatientType.SelectedValue);
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
    protected void ddlBillService_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlBillService.SelectedValue != "0")
        {
            gvBillServiceCharge.DataSource = objDALBillCharges.GetDrName(Convert.ToInt32(ddlBillService.SelectedValue), Convert.ToInt32(Session["Branchid"]),Convert.ToInt32(ddlRateType.SelectedValue),Convert.ToInt32(ddlPatientType.SelectedValue));
            gvBillServiceCharge.DataBind();

        }
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        string Message="";

        for (int p = 0; p < gvBillServiceCharge.Rows.Count; p++)
        {
            if ((gvBillServiceCharge.Rows[p].Cells[2].FindControl("txtserviceCharges") as TextBox).Text != "")
            {
               // string ServiceName = gvBillServiceCharge.Rows[p].Cells[0].Text;
                int ServiceId = Convert.ToInt32(ddlBillService.SelectedValue);
                int DrId = Convert.ToInt32(gvBillServiceCharge.DataKeys[p].Values[0]);
                int RateTypeId = Convert.ToInt32(ddlRateType.SelectedValue);
                int PatientType = Convert.ToInt32(ddlPatientType.SelectedValue);
                //int Groupid = Convert.ToInt32(ddlBillService.SelectedValue);
                float ServicAmt = Convert.ToSingle((gvBillServiceCharge.Rows[p].Cells[2].FindControl("txtserviceCharges") as TextBox).Text);
                float DrAmt = Convert.ToSingle((gvBillServiceCharge.Rows[p].Cells[3].FindControl("txtsDrAmt") as TextBox).Text);
                float DrAmtPer = Convert.ToSingle((gvBillServiceCharge.Rows[p].Cells[4].FindControl("txtsDrAmtpercent") as TextBox).Text);
                
               // Message = objDALBillCharges.InsertUpdate_BillService_Charges(Convert.ToInt32(ServiceId), Convert.ToInt32(PatientType), Convert.ToInt32(RateTypeId), Convert.ToSingle(ServicAmt), "Single", Convert.ToInt32(Session["Branchid"]), Convert.ToString(Session["username"]), DrId, Convert.ToInt32(ddlcategory.SelectedValue), DrAmt, DrAmtPer,true,false,false);

            }
        }
        DynamicMessage(lblMessage, Message);
    }
    protected void btnaction_Click(object sender, EventArgs e)
    {
        if (ddlBillService.SelectedValue != "0")
        {
            gvBillServiceCharge.DataSource = objDALBillCharges.GetDrName(Convert.ToInt32(ddlBillService.SelectedValue), Convert.ToInt32(Session["Branchid"]),Convert.ToInt32(ddlRateType.SelectedValue),Convert.ToInt32(ddlPatientType.SelectedValue));
            gvBillServiceCharge.DataBind();

        }
    }
}