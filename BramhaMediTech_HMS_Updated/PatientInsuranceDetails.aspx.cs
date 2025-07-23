using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PatientInsuranceDetails : BaseClass
{
    BELInsurance ObjBELInsurance = new BELInsurance();
    DAlInsurance ObjDALInsurance = new DAlInsurance();
    BELPatientInformation objBELPatInfo = new BELPatientInformation();
    DALPatientInformation objDALPatInfo = new DALPatientInformation();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadInsuranceCorporateComp(RdbCompany.SelectedValue);
            LoadTitleName();
            LoadGenderName();
            if (Request.QueryString["PatRegId"] != "")
            {
                FillPatientInformation(Convert.ToInt32(Request.QueryString["PatRegId"]));
                FillInsuranceDetails(Convert.ToInt32(Request.QueryString["PatRegId"]), Convert.ToInt32(Request.QueryString["IpdId"]));
            }
        }
            btnReset.Attributes.Add("onclick", "window.close();");

    }

    public void FillInsuranceDetails(int PatRegId,int IpdId)
    {
        ObjBELInsurance.FId = Convert.ToInt32(Session["FId"]);
        ObjBELInsurance.BranchId = Convert.ToInt32(Session["Branchid"]);
        ObjBELInsurance.PatRegId = PatRegId;
        ObjBELInsurance.IpdId = IpdId;
        string Exists = ObjDALInsurance.ChkExistPatientInsuranceDetails(ObjBELInsurance);
        if (Exists == "Yes")
        {
            ObjBELInsurance = ObjDALInsurance.SelectPatientInsuranceDetails(ObjBELInsurance);
            RdbCompany.SelectedValue = Convert.ToString(ObjBELInsurance.CompanyType);
            LoadInsuranceCorporateComp(RdbCompany.SelectedValue);
            ddlInsuranceCompany.SelectedValue = Convert.ToString(ObjBELInsurance.InsuranceCompanyId);
            txtMemberName.Text = ObjBELInsurance.MemberName;
            ddlTitleName.SelectedValue = Convert.ToString(ObjBELInsurance.TitleId);
            txtMembershipNo.Text = Convert.ToString(ObjBELInsurance.MembershipNo);
            txtRelation.Text = Convert.ToString(ObjBELInsurance.Relation);
        }
        else
        {
            RdbCompany.SelectedValue = "Insurance";
            LoadInsuranceCorporateComp(RdbCompany.SelectedValue);
            ddlInsuranceCompany.SelectedValue = "0";
            txtMemberName.Text = "";
            ddlTitleName.SelectedValue = "0";
            txtMembershipNo.Text = "";
            txtRelation.Text = "";
        }
       
    }
    public void FillPatientInformation(int PatRegId)
    {
       objBELPatInfo = objDALPatInfo.SelectOne(PatRegId);

       
        ViewState["TitleID"] = objBELPatInfo.TitleId;
        ddlTitleName.SelectedValue = Convert.ToString(objBELPatInfo.TitleId);
        txtPatientName.Text = objBELPatInfo.FirstName;
        
        ddlGender.SelectedValue = Convert.ToString(objBELPatInfo.GenderId);
        txtPatientAddress.Text = objBELPatInfo.PatientAddress;
        
        
        if (objBELPatInfo.Age != "")
        {
            
             if (Convert.ToDouble(objBELPatInfo.Age) < 0.084)
            {
                txtAge.Text = Convert.ToString(Math.Round((Convert.ToDecimal(objBELPatInfo.Age) * 12) * 30));
                ddlAge.SelectedValue = "Days";
            }
            else if (Convert.ToDouble(objBELPatInfo.Age) < 1)
            {
                txtAge.Text = Convert.ToString(Math.Round(Convert.ToDecimal(objBELPatInfo.Age) * 12));
                ddlAge.SelectedValue = "Months";
            }
            else
            {
                txtAge.Text = Convert.ToString(Math.Round(Convert.ToDecimal(objBELPatInfo.Age)));
                ddlAge.SelectedValue = "Years";
            }
        }
        else
        {
            txtAge.Text = "";
        }
}
    private void LoadTitleName()
    {
        ddlTitleName.DataSource = objDALPatInfo.FillTitleName();
        ddlTitleName.DataTextField = "Title";
        ddlTitleName.DataValueField = "TitleId";
        ddlTitleName.DataBind();
        ddlmemberTitle.DataSource = objDALPatInfo.FillTitleName();
        ddlmemberTitle.DataTextField = "Title";
        ddlmemberTitle.DataValueField = "TitleId";
        ddlmemberTitle.DataBind();

        
    }
    private void LoadGenderName()
    {
        ddlGender.DataSource = objDALPatInfo.FillGender();
        ddlGender.DataTextField = "GenderName";
        ddlGender.DataValueField = "GenderId";
        ddlGender.DataBind();
        //ddlTitleName_SelectedIndexChanged(null, null);
    }
    public void LoadInsuranceCorporateComp(string CompanyType)
    {
        int FId = Convert.ToInt32(Session["FId"]);
        int BranchId = Convert.ToInt32(Session["Branchid"]);
        if (CompanyType == "Insurance")
        {

            ddlInsuranceCompany.DataSource = ObjDALInsurance.FillInsuranceCorporateCompany(CompanyType,FId,BranchId);
            ddlInsuranceCompany.DataValueField = "InsuranceCompanyId";
            ddlInsuranceCompany.DataTextField = "InsuranceCompanyName";
            ddlInsuranceCompany.DataBind();
        }
        else
        {
            ddlInsuranceCompany.DataSource = ObjDALInsurance.FillInsuranceCorporateCompany(CompanyType,FId,BranchId);
            ddlInsuranceCompany.DataValueField = "CorporateCompanyId";
            ddlInsuranceCompany.DataTextField = "CorporateCompanyName";
            ddlInsuranceCompany.DataBind();
        }

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        object[] returns;
        string Message;
        ObjBELInsurance.InsuranceCompanyId = Convert.ToInt32(ddlInsuranceCompany.SelectedValue);
        ObjBELInsurance.PatRegId = Convert.ToInt32(Request.QueryString["PatRegId"]);
        ObjBELInsurance.IpdId = Convert.ToInt32(Request.QueryString["IpdId"]);
        ObjBELInsurance.MemberName = txtMemberName.Text;
        ObjBELInsurance.Relation = txtRelation.Text;
        ObjBELInsurance.TitleId = Convert.ToInt32(ddlTitleName.SelectedValue);
        ObjBELInsurance.MembershipNo = txtMembershipNo.Text;
        ObjBELInsurance.CompanyType = Convert.ToString(RdbCompany.SelectedValue);
        ObjBELInsurance.BranchId = Convert.ToInt32(Session["Branchid"]);
        ObjBELInsurance.FId = Convert.ToInt32(Session["FId"]);
        returns = ObjDALInsurance.InsertPatientInsuranceDetails(ObjBELInsurance);
        Message = Convert.ToString(returns[0]);
        DynamicMessage(lblMessage, Message);
       


        
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {

    }
    protected void RdbCompany_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadInsuranceCorporateComp(RdbCompany.SelectedValue);
    }
}