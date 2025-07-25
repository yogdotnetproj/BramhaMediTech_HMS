using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class BillServiceCharges :BasePage
{
    BELBillCharges objBELBillCharges = new BELBillCharges();
    DALBillCharges objDALBillCharges = new DALBillCharges();
    BELBillService objBELService = new BELBillService();
    DALBillService objDALService = new DALBillService();
    protected void Page_Load(object sender, EventArgs e)
    
    {
        if(!IsPostBack)
        {
            ViewState["Service"] = "";
             
             FillRateTypeDrop();
             RdbServicesFlag.SelectedValue = "DocWise";
             LoadBillGroupName();
             FillBillServiceDrop();
        }
    }

    private void LoadBillGroupName()
    {

        ddlBillGroupNameSearch.DataSource = objDALService.FillBillGroupDrop();
        ddlBillGroupNameSearch.DataTextField = "GroupName";
        ddlBillGroupNameSearch.DataValueField = "BillGroupId";
        ddlBillGroupNameSearch.DataBind();
    }
    protected void FillBillServiceDrop()
    {
        string GroupName = "";
        DataTable dt = new DataTable();
        dt = objDALService.CheckIsBillGroupDaily(ddlBillGroupNameSearch.SelectedValue);
        if (dt.Rows.Count > 0)
        {
            if (Convert.ToBoolean(dt.Rows[0]["DailyService"]) == true)
            {
                GroupName = "RoomWise";
                ViewState["DailyService"] = "Yes";
            }
            else
            {
                ViewState["DailyService"] = "No";
                GroupName = RdbServicesFlag.SelectedValue;
            }
        }
        else
        {
            ViewState["DailyService"] = "No";
            GroupName = RdbServicesFlag.SelectedValue;
        }


       // ddlBillService.DataSource = objDALBillCharges.FillBillServicesbyGroup(RdbServicesFlag.SelectedValue, Convert.ToInt32(ddlPatientType.SelectedValue),Convert.ToInt32(Session["FId"]), Convert.ToInt32(Session["Branchid"]), Convert.ToInt32(ddlBillGroupNameSearch.SelectedValue));
        ddlBillService.DataSource = objDALBillCharges.FillBillServicesbyGroup(GroupName, Convert.ToInt32(ddlPatientType.SelectedValue), Convert.ToInt32(Session["FId"]), Convert.ToInt32(Session["Branchid"]), Convert.ToInt32(ddlBillGroupNameSearch.SelectedValue));

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

       
    }
    protected void ddlPatientType_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillBillServiceDrop();
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
        //if (ddlBillService.SelectedItem.Text != "Select BillGroup")
        //{
        //    gvBillServiceCharge.DataSource = objDALBillCharges.FillBillServiceName( Convert.ToInt32( ddlBillService.SelectedValue),Convert.ToInt32(ddlPatientType.SelectedValue));
        //    gvBillServiceCharge.DataBind();

        //}
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        string Message = "";
        if (ViewState["Service"].ToString() == "Lab")
        {
            for (int p = 0; p < gvBillServiceChargesDirect.Rows.Count; p++)
            {
                if ((gvBillServiceChargesDirect.Rows[p].Cells[1].FindControl("txtserviceCharges") as TextBox).Text != "")
                {
                    string ServiceName = gvBillServiceChargesDirect.Rows[p].Cells[0].Text;
                    int ServiceId = Convert.ToInt32(0);
                    int RateTypeId = Convert.ToInt32(ddlRateType.SelectedValue);
                    int PatientType = Convert.ToInt32(ddlPatientType.SelectedValue);
                    int BillGroupId = Convert.ToInt32(ddlBillGroupNameSearch.SelectedValue);

                    float ServicAmt = Convert.ToSingle((gvBillServiceChargesDirect.Rows[p].Cells[1].FindControl("txtserviceCharges") as TextBox).Text);
                   // string MTCode = gvBillServiceChargesDirect.Rows[p].Cells[2].Text;
                    string MTCode = "";
                    Message = objDALBillCharges.InsertUpdate_BillService_Charges(BillGroupId, Convert.ToInt32(ServiceId), 0, Convert.ToInt32(PatientType), Convert.ToInt32(RateTypeId), Convert.ToSingle(ServicAmt), Convert.ToInt32(Session["Branchid"]), Convert.ToString(Session["username"]), 0, 0, 0, false, false, true,MTCode);

                }
            }
        }
        if (ViewState["Service"].ToString() == "Direct")
        {
            for (int p = 0; p < gvBillServiceChargesDirect.Rows.Count; p++)
            {
                if ((gvBillServiceChargesDirect.Rows[p].Cells[1].FindControl("txtserviceCharges") as TextBox).Text != "")
                {
                    string ServiceName = gvBillServiceChargesDirect.Rows[p].Cells[0].Text;
                    int ServiceId = Convert.ToInt32(gvBillServiceChargesDirect.DataKeys[p].Values[0]);
                    int RateTypeId = Convert.ToInt32(ddlRateType.SelectedValue);
                    int PatientType = Convert.ToInt32(ddlPatientType.SelectedValue);
                    int BillGroupId = Convert.ToInt32(ddlBillGroupNameSearch.SelectedValue);

                    float ServicAmt = Convert.ToSingle((gvBillServiceChargesDirect.Rows[p].Cells[1].FindControl("txtserviceCharges") as TextBox).Text);
                   // string MTCode = gvBillServiceChargesDirect.Rows[p].Cells[2].Text;
                    string MTCode = "";
                    Message = objDALBillCharges.InsertUpdate_BillService_Charges(BillGroupId, Convert.ToInt32(ServiceId), 0, Convert.ToInt32(PatientType), Convert.ToInt32(RateTypeId), Convert.ToSingle(ServicAmt), Convert.ToInt32(Session["Branchid"]), Convert.ToString(Session["username"]), 0, 0, 0, false, false, true, "");

                }
            }
        }
        if(ViewState["Service"].ToString() =="DocWise")
        {

        for (int p = 0; p < gvBillServiceCharge.Rows.Count; p++)
        {
            if ((gvBillServiceCharge.Rows[p].Cells[2].FindControl("txtserviceCharges") as TextBox).Text != "")
            {
               
                int ServiceId = Convert.ToInt32(ddlBillService.SelectedValue);
                int DrId = Convert.ToInt32(gvBillServiceCharge.DataKeys[p].Values[0]);
                int RateTypeId = Convert.ToInt32(ddlRateType.SelectedValue);
                int PatientType = Convert.ToInt32(ddlPatientType.SelectedValue);
                int BillGroupId = Convert.ToInt32(ddlBillGroupNameSearch.SelectedValue);
              
                float ServicAmt = Convert.ToSingle((gvBillServiceCharge.Rows[p].Cells[2].FindControl("txtserviceCharges") as TextBox).Text);
                float DrAmt = Convert.ToSingle((gvBillServiceCharge.Rows[p].Cells[3].FindControl("txtsDrAmt") as TextBox).Text);
                float DrAmtPer = Convert.ToSingle((gvBillServiceCharge.Rows[p].Cells[4].FindControl("txtsDrAmtpercent") as TextBox).Text);

                Message = objDALBillCharges.InsertUpdate_BillService_Charges(BillGroupId,Convert.ToInt32(ServiceId), 0, Convert.ToInt32(PatientType), Convert.ToInt32(RateTypeId), Convert.ToSingle(ServicAmt), Convert.ToInt32(Session["Branchid"]), Convert.ToString(Session["username"]), DrId, DrAmt, DrAmtPer, true, false, false,"");

            }
        }
        }
        if (ViewState["Service"].ToString() == "RoomWise")
        {
            for (int p = 0; p < gvBillChargesRoomwise.Rows.Count; p++)
            {
                if ((gvBillChargesRoomwise.Rows[p].Cells[1].FindControl("txtRoomCharges") as TextBox).Text != "")
                {
                    string ServiceName = gvBillChargesRoomwise.Rows[p].Cells[0].Text;
                    int ServiceId = Convert.ToInt32(gvBillChargesRoomwise.DataKeys[p].Values[0]);
                    int RateTypeId = Convert.ToInt32(ddlRateType.SelectedValue);
                    int PatientType = Convert.ToInt32(ddlPatientType.SelectedValue);
                    int BillGroupId = Convert.ToInt32(ddlBillGroupNameSearch.SelectedValue);

                    float ServicAmt = Convert.ToSingle((gvBillChargesRoomwise.Rows[p].Cells[1].FindControl("txtRoomCharges") as TextBox).Text);

                    Message = objDALBillCharges.InsertUpdate_BillService_Charges(BillGroupId,Convert.ToInt32(ServiceId), 0, Convert.ToInt32(PatientType), Convert.ToInt32(RateTypeId), Convert.ToSingle(ServicAmt), Convert.ToInt32(Session["Branchid"]), Convert.ToString(Session["username"]), 0, 0, 0, false, true, false,"");

                    //int ServiceId = Convert.ToInt32(ddlBillService.SelectedValue);
                    //int RoomTypeId = Convert.ToInt32(gvBillChargesRoomwise.DataKeys[p].Values[0]);
                    //int RateTypeId = Convert.ToInt32(ddlRateType.SelectedValue);
                    //int PatientType = Convert.ToInt32(ddlPatientType.SelectedValue);

                    //float ServicAmt = Convert.ToSingle((gvBillChargesRoomwise.Rows[p].Cells[1].FindControl("txtRoomCharges") as TextBox).Text);
                    
                   // Message = objDALBillCharges.InsertUpdate_BillService_Charges(Convert.ToInt32(ServiceId), RoomTypeId, Convert.ToInt32(PatientType), Convert.ToInt32(RateTypeId), Convert.ToSingle(ServicAmt), Convert.ToInt32(Session["Branchid"]), Convert.ToString(Session["username"]), 0, 0, 0, false, true, false);

                }
            }
        }

        DynamicMessage(lblMessage, Message);
    }
    protected void btnaction_Click(object sender, EventArgs e)
    {
        if (RdbServicesFlag.SelectedValue == "DocWise")
        {
            ViewState["Service"] = "DocWise";
            DoctorWise.Visible = true;
            RoomWise.Visible = false;
            Direct.Visible = false;

            if (ddlBillService.SelectedValue != "0")
            {
                gvBillServiceCharge.DataSource = objDALBillCharges.GetDrName(Convert.ToInt32(ddlBillService.SelectedValue), Convert.ToInt32(Session["Branchid"]), Convert.ToInt32(ddlRateType.SelectedValue), Convert.ToInt32(ddlPatientType.SelectedValue));
                gvBillServiceCharge.DataBind();

            }
            else
            {
                gvBillServiceCharge.DataSource = null;
                gvBillServiceCharge.DataBind();
            }
        }
        if (RdbServicesFlag.SelectedValue == "RoomWise")
        {
            ViewState["Service"] = "RoomWise";
            DoctorWise.Visible = false;
            RoomWise.Visible = true;
            Direct.Visible = false;

           // gvBillChargesRoomwise.DataSource = objDALBillCharges.Get_RoomCategory(Convert.ToInt32(ddlBillService.SelectedValue), Convert.ToInt32(Session["Branchid"]), Convert.ToInt32(ddlRateType.SelectedValue), Convert.ToInt32(ddlPatientType.SelectedValue)); 
           // gvBillChargesRoomwise.DataBind();
            if (Convert.ToString(ViewState["DailyService"]) == "Yes")
            {
                gvBillChargesRoomwise.DataSource = objDALBillCharges.FillBillServiceNameForRoom_DailyNew(Convert.ToInt32(Session["Branchid"]), Convert.ToInt32(ddlPatientType.SelectedValue), Convert.ToInt32(ddlRateType.SelectedValue), Convert.ToInt32(ddlBillGroupNameSearch.SelectedValue), Convert.ToInt32(ddlBillService.SelectedValue));
                gvBillChargesRoomwise.DataBind(); //FillBillServiceNameForRoom_Daily
            }
            else
            {
                gvBillChargesRoomwise.DataSource = objDALBillCharges.FillBillServiceNameForRoom(Convert.ToInt32(Session["Branchid"]), Convert.ToInt32(ddlPatientType.SelectedValue), Convert.ToInt32(ddlRateType.SelectedValue), Convert.ToInt32(ddlBillGroupNameSearch.SelectedValue), Convert.ToInt32(ddlBillService.SelectedValue));
                gvBillChargesRoomwise.DataBind();
            }
              
            
        }
        if (RdbServicesFlag.SelectedValue == "Direct")
        {
            ViewState["Service"] = "Direct";
            DoctorWise.Visible = false;
            RoomWise.Visible = false;
            Direct.Visible = true;
            gvBillServiceChargesDirect.DataSource = objDALBillCharges.FillBillServiceName(Convert.ToInt32(Session["Branchid"]), Convert.ToInt32(ddlPatientType.SelectedValue),Convert.ToInt32(ddlRateType.SelectedValue),Convert.ToInt32(ddlBillGroupNameSearch.SelectedValue),Convert.ToInt32(ddlBillService.SelectedValue));
            gvBillServiceChargesDirect.DataBind();
        }
        if (RdbServicesFlag.SelectedValue == "Lab")
        {
            ViewState["Service"] = "Lab";
            DoctorWise.Visible = false;
            RoomWise.Visible = false;
            Direct.Visible = true;
            btnSearch.Visible = true;
            txtsearch.Visible = true;
            gvBillServiceChargesDirect.DataSource = objDALBillCharges.FillBillServiceName_Lab(Convert.ToInt32(Session["Branchid"]), Convert.ToInt32(ddlPatientType.SelectedValue), Convert.ToInt32(ddlRateType.SelectedValue), Convert.ToInt32(ddlBillGroupNameSearch.SelectedValue), Convert.ToInt32(ddlBillService.SelectedValue));
            gvBillServiceChargesDirect.DataBind();
        }
        

       
    }
    protected void RdbServicesFlag_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillBillServiceDrop();
        DoctorWise.Visible = false;
        RoomWise.Visible = false;
        Direct.Visible = false;
        btnSearch.Visible = false;
        txtsearch.Visible = false;
        if (RdbServicesFlag.SelectedValue == "Lab")
        {
           // btnok.Visible = true;
        }
    }
    protected void ddlBillGroupNameSearch_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillBillServiceDrop();
    }
    protected void btnok_Click(object sender, EventArgs e)
    {
        if (RdbServicesFlag.SelectedValue == "Lab")
        {
            ViewState["Service"] = "Lab";
            DoctorWise.Visible = false;
            RoomWise.Visible = false;
            Direct.Visible = true;
            gvBillServiceChargesDirect.DataSource = objDALBillCharges.FillBillServiceName_AllLab(Convert.ToInt32(Session["Branchid"]), Convert.ToInt32(ddlPatientType.SelectedValue), Convert.ToInt32(ddlRateType.SelectedValue), Convert.ToInt32(ddlBillGroupNameSearch.SelectedValue), Convert.ToInt32(ddlBillService.SelectedValue));
            gvBillServiceChargesDirect.DataBind();
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
       

        if (RdbServicesFlag.SelectedValue == "Lab")
        {
            ViewState["Service"] = "Lab";
            DoctorWise.Visible = false;
            RoomWise.Visible = false;
            Direct.Visible = true;
            btnSearch.Visible = true;
            txtsearch.Visible = true;
            gvBillServiceChargesDirect.DataSource = objDALBillCharges.FillBillServiceName_Lab_search(Convert.ToInt32(Session["Branchid"]), Convert.ToInt32(ddlPatientType.SelectedValue), Convert.ToInt32(ddlRateType.SelectedValue), Convert.ToInt32(ddlBillGroupNameSearch.SelectedValue), Convert.ToInt32(ddlBillService.SelectedValue),Convert.ToString(txtsearch.Text));
            gvBillServiceChargesDirect.DataBind();
        }
    }
}