using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CorporateCompany :BasePage
{
    BELCorporateCompany objBELCorp = new BELCorporateCompany();
    DALCorporateCompany objDALCorp = new DALCorporateCompany();
    DALSDC objDALSDC = new DALSDC();


    
    string CountryId = "";
    string StateId = "";
    string CityId = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            show.Visible = false;
            List.Visible = true;
            FillCorporateCompanyGrid();
            LoadCountryName();

        }
    }


    protected void FillCorporateCompanyGrid()
    {
        gvCorporateCompany.DataSource = objDALCorp.FillGrid();
        gvCorporateCompany.DataBind();
    }


    protected void LoadCountryName()
    {
        ddlCountryName.DataSource = objDALSDC.FillCountryDrop();
        ddlCountryName.DataValueField = "CountryId";
        ddlCountryName.DataTextField = "CountryName";
        ddlCountryName.DataBind();
        ddlCountryName.Items.Insert(0, new ListItem("Select Country", "0"));
    }

    protected void txtCorporateCompanyName_TextChanged(object sender, EventArgs e)
    {
        txtCorporateCompanyName.Text = txtCorporateCompanyName.Text.Trim();
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
        ddlStateName.DataTextField = "StateName";
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
        ddlCityName.DataSource = objDALSDC.FillCityDrop_ByState(Convert.ToInt32(ViewState["StateID"]));
        ddlCityName.DataTextField = "CityName";
        ddlCityName.DataValueField = "CityId";
        ddlCityName.DataBind();
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

        if (!(txtCorporateCompanyName.Text.Equals(string.Empty)))
        {

            objBELCorp.CorporateCompanyId = Convert.ToInt32(ViewState["CorporateCompanyID"]);
            objBELCorp.CorporateCompanyName = txtCorporateCompanyName.Text;
            objBELCorp.CorporateCompanyAddress = txtCorporateCompanyAddress.Text;
            objBELCorp.PostalCode = txtPostalCode.Text;
            objBELCorp.Email = txtEmail.Text;
            objBELCorp.PhoneNo = txtPhoneNo.Text;
            objBELCorp.FaxNo = txtFaxNo.Text;
            objBELCorp.ContactPersonName = txtContactPersonName.Text;
            objBELCorp.CPMobileNo = txtCPMobileNo.Text;
            objBELCorp.CPPhone = txtCPPhoneNo.Text;
            objBELCorp.CPEmail = txtCPEmailId.Text;
            objBELCorp.Notes = txtNotes.Text;
            objBELCorp.CountryId = Convert.ToInt32(Convert.ToString(ddlCountryName.SelectedValue));
            objBELCorp.StateId = Convert.ToInt32(Convert.ToString(ddlStateName.SelectedValue));
            objBELCorp.CityId = Convert.ToInt32(Convert.ToString(ddlCityName.SelectedValue));
            objBELCorp.FId = "1";
            objBELCorp.BranchId = Convert.ToInt32(Session["Branchid"]);


            if (Convert.ToInt32(ViewState["CorporateCompanyID"]) > 0)
            {
                objBELCorp.UpdatedBy = Convert.ToString(Session["username"]);
                Message = objDALCorp.UpdateCorporateCompany(objBELCorp);

            }
            else
            {
                objBELCorp.CreatedBy = Convert.ToString(Session["username"]);
                Message = objDALCorp.InsertCorporateCompany(objBELCorp);
            }
        }
        DynamicMessage(lblMessage, Message);

        FillCorporateCompanyGrid();

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
        txtCorporateCompanyName.Text = "";
        txtCorporateCompanyAddress.Text = "";
        txtPostalCode.Text = "";
        txtEmail.Text = "";
        txtPhoneNo.Text = "";
        txtFaxNo.Text = "";
        txtContactPersonName.Text = "";
        txtCPMobileNo.Text = "";
        txtCPPhoneNo.Text = "";
        txtCPEmailId.Text = "";
        txtNotes.Text = "";

        ViewState["CorporateCompanyID"] = 0;
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
        txtCorporateCompanyName.Text = "";
        txtCorporateCompanyAddress.Text = "";
        txtPostalCode.Text = "";
        txtEmail.Text = "";
        txtPhoneNo.Text = "";
        txtFaxNo.Text = "";
        txtContactPersonName.Text = "";
        txtCPMobileNo.Text = "";
        txtCPPhoneNo.Text = "";
        txtCPEmailId.Text = "";
        txtNotes.Text = "";

        ViewState["CorporateCompanyID"] = 0;
        ddlCountryName.SelectedIndex = -1;
        ddlStateName.SelectedIndex = -1;
        ddlCityName.SelectedIndex = -1;
        ViewState["CountryID"] = 0;
        ViewState["StateID"] = 0;
        ViewState["CityID"] = 0;

        lblMessage.Text = "";
    }


    protected void gvCorporateCompany_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            show.Visible = true;
            List.Visible = false;

            string CorporateCompanyID = (gvCorporateCompany.DataKeys[e.NewEditIndex]["CorporateCompanyId"].ToString());
            ViewState["CorporateCompanyID"] = CorporateCompanyID;
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
        objBELCorp = objDALCorp.SelectOne(Convert.ToInt32(ViewState["CorporateCompanyID"]));
        txtCorporateCompanyName.Text = objBELCorp.CorporateCompanyName;
        txtCorporateCompanyAddress.Text = objBELCorp.CorporateCompanyAddress;
        txtPostalCode.Text = objBELCorp.PostalCode;
        txtEmail.Text = objBELCorp.Email;
        txtPhoneNo.Text = objBELCorp.PhoneNo;
        txtFaxNo.Text = objBELCorp.FaxNo;
        txtContactPersonName.Text = objBELCorp.ContactPersonName;
        txtCPMobileNo.Text = objBELCorp.CPMobileNo;
        txtCPPhoneNo.Text = objBELCorp.CPPhone;
        txtCPEmailId.Text = objBELCorp.CPEmail;
        txtNotes.Text = objBELCorp.Notes;
        ddlCountryName.SelectedValue = Convert.ToString(objBELCorp.CountryId);
        CountryId = ddlCountryName.SelectedValue.ToString();
        ViewState["CountryID"] = CountryId;
        if (Convert.ToInt32(CountryId) > 0)
        {
            LoadStateName();
        }
        ddlStateName.SelectedValue = Convert.ToString(objBELCorp.StateId);
        StateId = ddlStateName.SelectedValue.ToString();
        ViewState["StateID"] = StateId;
        if (Convert.ToInt32(StateId) > 0)
        {
            LoadCityName();
        }

        ddlCityName.SelectedValue = Convert.ToString(objBELCorp.CityId);
        ViewState["CountryID"] = objBELCorp.CountryId;
        ViewState["StateID"] = objBELCorp.StateId;
        ViewState["CityID"] = objBELCorp.CityId;
    }


    protected void gvCorporateCompany_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string CorporateCompanyID = (gvCorporateCompany.DataKeys[e.RowIndex]["CorporateCompanyId"].ToString());

        string Message = objDALCorp.DeleteCorporateCompany(Convert.ToInt32(CorporateCompanyID));
        DynamicMessage(lblMessage, Message);

        FillCorporateCompanyGrid();
    }
    protected void gvCorporateCompany_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvCorporateCompany.PageIndex = e.NewPageIndex;
        FillCorporateCompanyGrid();
    }
}