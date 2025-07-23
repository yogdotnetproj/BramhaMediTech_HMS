using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



public partial class InsuranceCompany : BaseClass
{
    BELInsurance objBELInsu = new BELInsurance();
    DAlInsurance objDALInsu = new DAlInsurance();
    DALSDC objDALSDC = new DALSDC();

   
    string UserId = "";
    string CountryId = "";
    string StateId = "";
    string CityId = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            show.Visible = false;
            List.Visible = true;
            FillInsuranceCompanyGrid();
            LoadCountryName();

        }
    }
    
    
    protected void FillInsuranceCompanyGrid()
    {
        gvInsuranceCompany.DataSource = objDALInsu.FillGrid();
        gvInsuranceCompany.DataBind();
    }

   
    protected void LoadCountryName()
    {
        ddlCountryName.DataSource= objDALSDC.FillCountryDrop();
        ddlCountryName.DataValueField = "CountryId";
        ddlCountryName.DataTextField = "CountryName";
        ddlCountryName.DataBind();
        ddlCountryName.Items.Insert(0, new ListItem("Select Country", "0"));
    }

    protected void txtInsuranceCompanyName_TextChanged(object sender, EventArgs e)
    {
        txtInsuranceCompanyName.Text = txtInsuranceCompanyName.Text.Trim();
    }

    
    protected void ddlCountryName_SelectedIndexChanged(object sender, EventArgs e)
    {
        CountryId = ddlCountryName.SelectedValue.ToString();
        ViewState["CountryID"] = CountryId;
        if (Convert.ToInt32(CountryId) > 0)
        {
            LoadStateName();
        }
    }

    protected void LoadStateName()
    {
        ddlStateName.DataSource = objDALSDC.FillStateDrop_ByCountry(Convert.ToInt32(ViewState["CountryID"]));
        ddlStateName.DataValueField = "StateId";
        ddlStateName.DataTextField="StateName";
        ddlStateName.DataBind();
        ddlStateName.Items.Insert(0, new ListItem("Select State", "0"));
    }

   
    protected void ddlStateName_SelectedIndexChanged(object sender, EventArgs e)
    {
        StateId = ddlStateName.SelectedValue.ToString();
        ViewState["StateID"] = StateId;
        if (Convert.ToInt32(StateId) > 0)
        {
            LoadCityName();
        }
    }

    protected void LoadCityName()
    {
        ddlCityName.DataSource=objDALSDC.FillCityDrop_ByState(Convert.ToInt32( ViewState["StateID"]));
        ddlCityName.DataTextField="CityName";
        ddlCityName.DataValueField="CityId";
        ddlCityName.DataBind();
       // ddlCityName.Items.Insert(0, new ListItem("Select City", "0"));
    }

    protected void ddlCityName_SelectedIndexChanged(object sender, EventArgs e)
    {
        CityId = ddlCityName.SelectedValue.ToString();
        ViewState["CityID"] = CityId;
    }

    protected void txtPostalCode_TextChanged(object sender, EventArgs e)
    {
        txtPostalCode.Text = txtPostalCode.Text.Trim();
    }

    protected void txtEmail_TextChanged(object sender, EventArgs e)
    {
        txtEmail.Text = txtEmail.Text.Trim();
    }

    protected void txtPhoneNo_TextChanged(object sender, EventArgs e)
    {
        txtPhoneNo.Text = txtPhoneNo.Text.Trim();
    }

    protected void txtFaxNo_TextChanged(object sender, EventArgs e)
    {
        txtFaxNo.Text = txtFaxNo.Text.Trim();
    }

    protected void txtContactPersonName_TextChanged(object sender, EventArgs e)
    {
        txtContactPersonName.Text = txtContactPersonName.Text.Trim();
    }

   
    protected void txtCPMobileNo_TextChanged(object sender, EventArgs e)
    {
        txtCPMobileNo.Text = txtCPMobileNo.Text.Trim();
    }

    protected void txtCPPhoneNo_TextChanged(object sender, EventArgs e)
    {
        txtCPPhoneNo.Text = txtCPPhoneNo.Text.Trim();
    }

    
    protected void txtCPEmailId_TextChanged(object sender, EventArgs e)
    {
        txtCPEmailId.Text = txtCPEmailId.Text.Trim();
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
         
        string Message = "";
       
        if (!(txtInsuranceCompanyName.Text.Equals(string.Empty)))
        {
            objBELInsu.InsuranceCompanyId= Convert.ToInt32(ViewState["InsuranceCompanyID"]);
            objBELInsu.InsuranceCompanyName = txtInsuranceCompanyName.Text;
            objBELInsu.InsuranceCompanyAddress = txtInsuranceCompanyAddress.Text;
            objBELInsu.PostalCode = txtPostalCode.Text;
            objBELInsu.Email = txtEmail.Text;
            objBELInsu.PhoneNo = txtPhoneNo.Text;
            objBELInsu.FaxNo = txtFaxNo.Text;
            objBELInsu.ContactPersonName = txtContactPersonName.Text;
            objBELInsu.CPMobileNo = txtCPMobileNo.Text;
            objBELInsu.CPPhone = txtCPPhoneNo.Text;
            objBELInsu.CPEmail = txtCPEmailId.Text;
            objBELInsu.Notes = txtNotes.Text;
            objBELInsu.FId = Convert.ToInt32(Session["Branchid"]); ;
            objBELInsu.CountryId = Convert.ToInt32(Convert.ToString(ddlCountryName.SelectedValue));
            objBELInsu.StateId = Convert.ToInt32(Convert.ToString(ddlStateName.SelectedValue));
            objBELInsu.CityId = Convert.ToInt32(Convert.ToString(ddlCityName.SelectedValue));
            objBELInsu.BranchId = Convert.ToInt32(Session["Branchid"]);
            

            if (Convert.ToInt32(ViewState["InsuranceCompanyID"]) > 0)
            {
                objBELInsu.UpdatedBy =Convert.ToString(Session["username"]);
                Message = objDALInsu.UpdateInsuranceCompany(objBELInsu);    
                   
            }
            else
            {
                 objBELInsu.CreatedBy=Convert.ToString(Session["username"]);
                Message = objDALInsu.InsertInsuranceCompany(objBELInsu);
            }
        }
            DynamicMessage(lblMessage, Message);

            FillInsuranceCompanyGrid();

            ClearAll();
            show.Visible = false;
            List.Visible = true;
    }

    protected void btnaddnew_Click(object sender, EventArgs e)
    {
        show.Visible = true;
        List.Visible = false;
        lblMessage.Text = "";
    }  

    
    protected void ClearAll()
    {
        txtInsuranceCompanyName.Text = "";
        txtInsuranceCompanyAddress.Text = "";
        txtPostalCode.Text = "";
        txtEmail.Text = "";
        txtPhoneNo.Text = "";
        txtFaxNo.Text = "";
        txtContactPersonName.Text = "";
        txtCPMobileNo.Text = "";
        txtCPPhoneNo.Text = "";
        txtCPEmailId.Text = "";
        txtNotes.Text = "";

        ViewState["InsuranceCompanyID"] = 0;
        ddlCountryName.SelectedIndex = -1;
        ddlStateName.SelectedIndex = -1;
        ddlCityName.SelectedIndex = -1;
        ViewState["CountryID"] = 0;
        ViewState["StateID"] = 0;
        ViewState["CityID"] = 0;

    }
   
    protected void btnReset_Click(object sender, EventArgs e)
    {
        Reset();
        show.Visible = false;
        List.Visible = true;
    }

    private void Reset()
    {
        txtInsuranceCompanyName.Text = "";
        txtInsuranceCompanyAddress.Text = "";
        txtPostalCode.Text = "";
        txtEmail.Text = "";
        txtPhoneNo.Text = "";
        txtFaxNo.Text = "";
        txtContactPersonName.Text = "";
        txtCPMobileNo.Text = "";
        txtCPPhoneNo.Text = "";
        txtCPEmailId.Text = "";
        txtNotes.Text = "";

        ViewState["InsuranceCompanyID"] = 0;
        ddlCountryName.SelectedIndex = -1;
        ddlStateName.SelectedIndex = -1;
        ddlCityName.SelectedIndex = -1;
        ViewState["CountryID"] = 0;
        ViewState["StateID"] = 0;
        ViewState["CityID"] = 0;

        lblMessage.Text = "";
    }

    
    protected void gvInsuranceCompany_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            show.Visible = true;
            List.Visible = false;

            string InsuranceCompanyID = (gvInsuranceCompany.DataKeys[e.NewEditIndex]["InsuranceCompanyId"].ToString());
            ViewState["InsuranceCompanyID"] = InsuranceCompanyID;
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
            ReadDO();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }

    private void ReadDO()
    {
        objBELInsu = objDALInsu.SelectOne(Convert.ToInt32(ViewState["InsuranceCompanyID"]));

        txtInsuranceCompanyName.Text = objBELInsu.InsuranceCompanyName;
        txtInsuranceCompanyAddress.Text = objBELInsu.InsuranceCompanyAddress;
        txtPostalCode.Text = objBELInsu.PostalCode;
        txtEmail.Text = objBELInsu.Email;
        txtPhoneNo.Text = objBELInsu.PhoneNo;
        txtFaxNo.Text = objBELInsu.FaxNo;
        txtContactPersonName.Text = objBELInsu.ContactPersonName;
        txtCPMobileNo.Text = objBELInsu.CPMobileNo;
        txtCPPhoneNo.Text = objBELInsu.CPPhone;
        txtCPEmailId.Text = objBELInsu.CPEmail;
        txtNotes.Text = objBELInsu.Notes;
        ddlCountryName.SelectedValue = Convert.ToString(objBELInsu.CountryId);
        CountryId = ddlCountryName.SelectedValue.ToString();
        ViewState["CountryID"] = CountryId;
        if (Convert.ToInt32(CountryId) > 0)
        {
            LoadStateName();
        }  
        ddlStateName.SelectedValue = Convert.ToString(objBELInsu.StateId);
        StateId = ddlStateName.SelectedValue.ToString();
        ViewState["StateID"] = StateId;
        if (Convert.ToInt32(StateId) > 0)
        {
            LoadCityName();
        }

        ddlCityName.SelectedValue = Convert.ToString(objBELInsu.CityId);
        ViewState["CountryID"] = objBELInsu.CountryId;
        ViewState["StateID"] = objBELInsu.StateId;
        ViewState["CityID"] = objBELInsu.CityId;
    }

   
    protected void gvInsuranceCompany_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string InsuranceCompanyID = (gvInsuranceCompany.DataKeys[e.RowIndex]["InsuranceCompanyId"].ToString());

        string Message = objDALInsu.DeleteInsuranceCompany(Convert.ToInt32(InsuranceCompanyID));
        DynamicMessage(lblMessage, Message);

        FillInsuranceCompanyGrid();
    }
    protected void gvInsuranceCompany_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvInsuranceCompany.PageIndex = e.NewPageIndex; 
        FillInsuranceCompanyGrid();
    }
}