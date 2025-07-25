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
using System.Drawing;
using System.Media;

public partial class PatientInformation :BasePage
{
    BELPatientInformation objBELPatInfo = new BELPatientInformation();
    DALPatientInformation objDALPatInfo = new DALPatientInformation();
    DALOpdReg objDALOpdReg = new DALOpdReg();
    public enum MessageType { Success, Error, Info, Warning };
    string UserId = "";

    string PatientCategoryId = "", PatientSubCategoryId = "", GenderId = "", GuardianTitleId = "";
    string CountryId = "";
    string StateId = "";
    string CityId = "";
   

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            try
            {
               // PAtValidate();
                imgPatient.ImageUrl = "~/Images0/Preview.png";
                ViewState["PhotoPath"] = "~/Images0/Preview.png";
                
                LoadTitleName();
              
                LoadGenderName();
              
                LoadCountryName();
                LoadRelation();


                if (Request.QueryString["PatientInfoID"] != null)
                {

                    ViewState["PatientInfoID"] = Request.QueryString["PatientInfoID"];
                    ViewState["PatientInfoIDTemp"] = Request.QueryString["PatientInfoID"];
                    lblRegNo.Text = "Registration No. Is : " + ViewState["PatientInfoIDTemp"];
                    FillPage();
                    btnOPD.Visible = true;
                    btnIPD.Visible = true;
                    btnLab.Visible = true;
                    btnProcedure.Visible = true;
                }
                else
                {
                     btnOPD.Visible = false;
                     btnIPD.Visible = false;
                     btnLab.Visible = false;
                     btnProcedure.Visible = false;
                }
               
                string Type = Convert.ToString(Request.QueryString["Type"]);
                if (Type == "Appointment")
                {
                    ViewState["AppointmentId"] = Convert.ToString(Request.QueryString["AppointmentId"]);
                    txtFirstName.Text = Convert.ToString(Request.QueryString["FirstName"]);
                   
                    txtMobileNo.Text = Convert.ToString(Request.QueryString["MobileNo"]);
                    txtPatientAddress.Value = Convert.ToString(Request.QueryString["Address"]);
                }
                FileUpload1.Attributes["onchange"] = "UploadFile(this)";


            }
            catch (Exception)
            {
            }

        }
        if (Convert.ToString(Session["Branchid"]) == null && Convert.ToString(Session["Branchid"]) == "" && Convert.ToString(Session["Branchid"]) == "0")
        {
            Server.Transfer("~/Login.aspx", true);
        }
    }

    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }

    private void GetPatientID()
    {
       
      

        int MaxPrnBarcode = objDALPatInfo.GetPrnBarcodeNo();
        int PrnBarCode = MaxPrnBarcode + 1;
       
        ViewState["PRNNo"] = Convert.ToString(PrnBarCode);
        ViewState["BarcodeId"] = Convert.ToString(PrnBarCode);


    }

    private void LoadTitleName()
    {
        ddlTitleName.DataSource=objDALPatInfo.FillTitleName();
        ddlTitleName.DataTextField="Title";
        ddlTitleName.DataValueField="TitleId";
        ddlTitleName.DataBind();
    }

    //private void LoadPatientMainType()
    //{
    //    ddlPatientCategoryName.DataSource = objDALPatInfo.FillPatMainTypeDrop();
    //    ddlPatientCategoryName.DataTextField = "PatMainType";
    //    ddlPatientCategoryName.DataValueField = "PatMainTypeId";
    //    ddlPatientCategoryName.DataBind();
    //}

    //private void LoadPatientSubCategoryName()
    //{
    //    ddlPatientSubCategoryName.DataSource = objDALPatInfo.FillPatInsuTypeDrop(Convert.ToInt32(ViewState["PatientCategoryID"]));
    //    ddlPatientSubCategoryName.DataTextField = "PatientInsuType";
    //    ddlPatientSubCategoryName.DataValueField = "PatientInsuTypeId";
    //    ddlPatientSubCategoryName.DataBind();
    //}

    
    private void LoadGenderName()
    {        
        ddlGender.DataSource=objDALPatInfo.FillGender();
        ddlGender.DataTextField = "GenderName";
        ddlGender.DataValueField = "GenderId";
        ddlGender.DataBind();
        ddlTitleName_SelectedIndexChanged(null, null);
    }

    
    //private void LoadGuardianTitleName()
    //{
    //    ddlGuardianTitle.DataSource = objDALPatInfo.FillTitleName();
    //    ddlGuardianTitle.DataTextField = "Title";
    //    ddlGuardianTitle.DataValueField = "TitleId";
    //    ddlGuardianTitle.DataBind();
    //}

   
    protected void LoadCountryName()
    {   
        ddlCountryName.DataSource = objDALPatInfo.FillCountryName();
        ddlCountryName.DataTextField = "CountryName";
        ddlCountryName.DataValueField = "CountryId";
        ddlCountryName.DataBind();
        ddlCountryName_SelectedIndexChanged(null, null);

        ddlReligion.DataSource = objDALPatInfo.Get_Religion();
        ddlReligion.DataTextField = "Religion";
        ddlReligion.DataValueField = "ReligionID";
        ddlReligion.DataBind();
        ddlReligion.Items.Insert(0, new ListItem("Select Religion", "0"));


        ddlRace.DataSource = objDALPatInfo.Get_Race();
        ddlRace.DataTextField = "RaceName";
        ddlRace.DataValueField = "RaceID";
        ddlRace.DataBind();
        ddlRace.Items.Insert(0, new ListItem("Select Race", "0"));
    }

   


    
    

    protected void ddlTitleName_SelectedIndexChanged(object sender, EventArgs e)
    {
        int TitleId = Convert.ToInt32(ddlTitleName.SelectedValue.ToString());
        ViewState["TitleID"] = TitleId;
        objBELPatInfo = objDALPatInfo.GetGenderId(TitleId);
        ddlGender.SelectedValue = Convert.ToString(objBELPatInfo.GenderId);
        ViewState["GenderID"] = ddlGender.SelectedValue;
    }


    

    protected void ddlGender_SelectedIndexChanged(object sender, EventArgs e)
    {
        GenderId = ddlGender.SelectedValue.ToString();
        ViewState["GenderID"] = GenderId;
    }

    protected void chbxIsConfirmBirthDate_CheckedChanged(object sender, EventArgs e)
    {

    }

    

    

    private void RegisterPostBackControl()
    {

        ScriptManager.GetCurrent(this).RegisterPostBackControl(ddlCountryName);

    }
    protected void ddlCountryName_SelectedIndexChanged(object sender, EventArgs e)
    {


        CountryId = ddlCountryName.SelectedValue.ToString();
        ViewState["CountryID"] = CountryId;

        LoadStateName();
       
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "ShowInformation();", true);
        
    }

   
    protected void LoadStateName()
    {
        ddlStateName.DataSource=objDALPatInfo.FillStateName(Convert.ToInt32(ddlCountryName.SelectedValue.ToString()));
        ddlStateName.DataTextField = "StateName";
        ddlStateName.DataValueField = "StateId";
        ddlStateName.DataBind();
        ddlStateName_SelectedIndexChanged(null, null);
    }

    protected void ddlStateName_SelectedIndexChanged(object sender, EventArgs e)
    {
        StateId = ddlStateName.SelectedValue.ToString();
        ViewState["StateID"] = StateId;        
        LoadCityName();

    }

   
    protected void LoadCityName()
    {
        if (ddlStateName.SelectedValue != "")
        {
            ddlCityName.DataSource = objDALPatInfo.FillCityName(Convert.ToInt32(ddlStateName.SelectedValue.ToString()));
            ddlCityName.DataTextField = "CityName";
            ddlCityName.DataValueField = "CityId";
            ddlCityName.DataBind();
        }
        else
        {
            ddlCityName.DataSource = objDALPatInfo.FillCityName(0);
            ddlCityName.DataTextField = "CityName";
            ddlCityName.DataValueField = "CityId";
            ddlCityName.DataBind();
        }
    }

    protected void ddlCityName_SelectedIndexChanged(object sender, EventArgs e)
    {
        //CityId = ddlCityName.SelectedValue.ToString();
        //ViewState["CityID"] = CityId;

        //if (Convert.ToInt32(CityId) > 0)
        //{
        //    LoadLandMarkName();
        //}
        
    }

    //protected void LoadLandMarkName()
    //{
    //    BLLCombo objBLLCombo = new BLLCombo();

    //    FillCombo(ddlLandMarkName, objBLLCombo.FillLandMark(Convert.ToInt32(ViewState["CityID"])));
    //    FillCombo(ddlLandMarkName, objBLLCombo.FillLandMark(Convert.ToInt32(ddlCityName.SelectedValue.ToString())));
    //}

    
    //protected void ddlLandMark_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    LandMarkId = ddlLandMarkName.SelectedValue.ToString();
    //    ViewState["LandMarkID"] = LandMarkId;
        
    //}

    public bool validation()
    {
        
            if (txtFirstName.Text == "")
            {
                txtFirstName.Focus();
                txtFirstName.BorderColor = Color.Red;
                ShowMessage("Enter Name!", MessageType.Warning);
                return false;
            }
            else
            {
                txtFirstName.BorderColor = Color.White;
            }
            string[] PatientInfo = txtFirstName.Text.Split('-');
            if (PatientInfo.Length>1)
            {
                txtFirstName.Focus();
                txtFirstName.BorderColor = Color.Red;
                ShowMessage("Dash not allowed!", MessageType.Warning);
                return false;
            }
            if (txtBirthDate.Text == "")
            {
                txtBirthDate.Focus();
                txtBirthDate.BorderColor = Color.Red;
                ShowMessage("Enter Date of Birth!", MessageType.Warning);
                return false;
            }
            else
            {
                txtBirthDate.BorderColor = Color.White;
            }

            if (txtAge.Text == "")
            {
                txtAge.Focus();
                txtAge.BorderColor = Color.Red;
                ShowMessage("Enter Age!", MessageType.Warning);
                return false;
            }
            else
            {
                txtAge.BorderColor = Color.White;
            }
            if (ddlGender.SelectedValue == "0")
            {
                ddlGender.Focus();
                ddlGender.BorderColor = Color.Red;
                ShowMessage("select  gender!", MessageType.Warning);
                return false;
            }
            else
            {
                ddlGender.BorderColor = Color.White;
            }
           
        return true;
    }
    
    protected void btnSave_Click(object sender, EventArgs e)
    {
       
        string Message = "";

        if (Convert.ToString(Session["Branchid"]) == "")
        {
            Response.Redirect("~/Login.aspx", false);
            return;
        }
        if (Convert.ToString(Session["Branchid"]) == "0")
        {
            Response.Redirect("~/Login.aspx", false);
            return;
        }
        if (Convert.ToString(Session["Branchid"]) == null)
        {
            Response.Redirect("~/Login.aspx", false);
            return;
        }
        if (validation() == true)
        {
            //System.Threading.Thread.Sleep(3000);
           
            if (Convert.ToInt32(ViewState["PatientInfoIDTemp"]) > 0)
            {

                if (txtEditRemark.Text.Trim() == "")
                {
                    txtEditRemark.Focus();
                    txtEditRemark.BorderColor = System.Drawing.Color.Red;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Enter Edit Remark!.');", true);
                    return;
                }
                objBELPatInfo = WriteDO();
                Message = objDALPatInfo.UpdatePatientInfo(objBELPatInfo);
                Message = objDALPatInfo.EditPatientInfoRemark(objBELPatInfo);
                btnsave.Enabled = false;
                ShowMessage("Record update successfully", MessageType.Success);
            }
            else
            {

                objBELPatInfo = WriteDO();
                string ChkExist = objDALPatInfo.CheckExist(objBELPatInfo);
                if (ChkExist == "Yes")
                {
                   
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Patient already exits!.');", true);
                    return;

                }
                object[] Result = objDALPatInfo.InsertPatientInfo(objBELPatInfo);
                Message = Convert.ToString(Result[0]);
                ViewState["PatientInfoID"] = Convert.ToString(Result[1]);
                ViewState["PatientInfoIDTemp"] = Convert.ToString(Result[1]);
                ShowMessage("Record Save successfully", MessageType.Success);
                string MSgShow = "Your Register number is:" + ViewState["PatientInfoID"] + " ";
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Patient already exits!.');", true);
               // ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + MSgShow.ToString() + "');", true);
                lblRegNo.Text = "Your Registration Number is: " + ViewState["PatientInfoID"];
               
            }
           // ModalPopupExtender1.Hide();

            ViewState["PatientInfoIDTemp"] = "0";
           // DynamicMessage(lblMessage, Message);
            btnOPD.Visible = true;
            btnIPD.Visible = true;
            btnLab.Visible = true;
            btnProcedure.Visible = true;

            Reset();
        }
    }

    

    
    protected BELPatientInformation WriteDO()
    {

        if (Convert.ToInt32(ViewState["PatientInfoIDTemp"]) > 0)
        {            
            objBELPatInfo.UpdatedBy = Convert.ToString(Session["username"]);
            objBELPatInfo.PatientInfoId = Convert.ToInt32(ViewState["PatientInfoID"]);
            lblRegNo.Text= "Register Number is:" + ViewState["PatientInfoID"] + " ";
        }
        else
        {            
            objBELPatInfo.CreatedBy = Convert.ToString(Session["username"]);
            GetPatientID();  
            objBELPatInfo.PatRegId = Convert.ToString(ViewState["PRNNo"]);                  
            objBELPatInfo.BarcodeId= Convert.ToString(ViewState["BarcodeId"]);
            objBELPatInfo.FId = Convert.ToInt32(Session["FId"]);
            objBELPatInfo.BranchId = Convert.ToInt32(Session["Branchid"]);
           
        }

        objBELPatInfo.EditRemark = Convert.ToString(txtEditRemark.Text.Trim());
        if (ViewState["TitleID"] != null)
            objBELPatInfo.TitleId = Convert.ToInt32(ViewState["TitleID"]);
        else
            objBELPatInfo.TitleId = Convert.ToInt32(Convert.ToString(ddlTitleName.SelectedValue));

        objBELPatInfo.FirstName = txtFirstName.Text.Trim();
        
        objBELPatInfo.PatMainTypeId = 0;
        objBELPatInfo.PatientInsuTypeId = 0;
        if (Convert.ToString(ViewState["GenderID"]) != "0")
            objBELPatInfo.GenderId = Convert.ToInt32(ViewState["GenderID"]);
        else
            objBELPatInfo.GenderId = Convert.ToInt32(Convert.ToString(ddlGender.SelectedValue));

        if (txtBirthDate.Text != "")
        {
            objBELPatInfo.BirthDate = Convert.ToDateTime(txtBirthDate.Text.Trim());
            
        }
        
        if (txtAge.Text != "")
        {
            objBELPatInfo.Age = txtAge.Text;
        }
        else
        {
            objBELPatInfo.Age = "";
        }
        objBELPatInfo.AgeType = ddlAge.SelectedValue;

            objBELPatInfo.BloodGroup=ddlBloodGroup.Text;
        
       
            objBELPatInfo.MaritalStatus= Convert.ToString(ddlMaritalStatus.Text);

      
        objBELPatInfo.MobileNo = txtMobileNo.Text.Trim();
        
        objBELPatInfo.PatientAddress = txtPatientAddress.Value.Trim();

        if (ViewState["CountryID"] != null)
            objBELPatInfo.CountryId = Convert.ToInt32(ViewState["CountryID"]);
        else
            objBELPatInfo.CountryId = Convert.ToInt32(Convert.ToString(ddlCountryName.SelectedValue));

        if (ViewState["StateID"] != null)
            objBELPatInfo.StateId = Convert.ToInt32(ViewState["StateID"]);
        else
            objBELPatInfo.StateId = Convert.ToInt32(Convert.ToString(ddlStateName.SelectedValue));

        if (ViewState["CityID"] != null)
            objBELPatInfo.CityId = Convert.ToInt32(ViewState["CityID"]);
        else
            objBELPatInfo.CityId = Convert.ToInt32(Convert.ToString(ddlCityName.SelectedValue));

        objBELPatInfo.Email = txtEmail.Text.Trim();

        objBELPatInfo.ImagePath = Convert.ToString(ViewState["PhotoPath"]);
        objBELPatInfo.Nationality = Convert.ToString(txtNationality.Text);
        objBELPatInfo.BirthPlace = Convert.ToString(txtBirthPlace.Text);
        if (ddlRace.SelectedValue != "")
        {
            objBELPatInfo.RaceId = Convert.ToInt32(ddlRace.SelectedValue);
        }
        else
        {
            objBELPatInfo.RaceId = 0;
        }
        if (ddlReligion.SelectedValue != "")
        {
            objBELPatInfo.ReligionId = Convert.ToInt32(ddlReligion.SelectedValue);
        }
        else
        {
            objBELPatInfo.ReligionId = 0;
        }
        objBELPatInfo.HealthCardNo = Convert.ToString(txthealthcardNo.Text);
        objBELPatInfo.PassportNo = Convert.ToString(txtpassportNo.Text);
        objBELPatInfo.VaccinationStatus = RblVaccineType.SelectedItem.Text.Trim();

        objBELPatInfo.Allergy = txtallergy.Text.Trim();
        objBELPatInfo.ChiefComplant = txtComplant.Text.Trim();


        objBELPatInfo.P_Relation = Convert.ToInt32(ddlRelation.SelectedValue);
        objBELPatInfo.P_Relation1 = Convert.ToInt32(ddlrelation2.SelectedValue); ;
        objBELPatInfo.P_RelativeName = txtrelativeName.Text;
        objBELPatInfo.P_Address1 = txtAddress1.Text;

        objBELPatInfo.P_RelativeName1 = txtRelativeName2.Text;
        objBELPatInfo.P_ContactNo = txtContactNo.Text;
        objBELPatInfo.P_ContactNo1 = txtcontaxtNo2.Text;
        objBELPatInfo.P_Address2 = txtaddress2.Text;

        objBELPatInfo.Usertype = "patient";
        if (txtFirstName.Text.Length > 3)
        {
            objBELPatInfo.P_PUserName = txtFirstName.Text.Substring(0, 3);
            objBELPatInfo.P_PPassword = Convert.ToString(txtBirthDate.Text.Trim().Replace(@"/", ""));
        }
        else
        {
            objBELPatInfo.P_PUserName = txtFirstName.Text.Trim();
            objBELPatInfo.P_PPassword = Convert.ToString(txtBirthDate.Text.Trim().Replace(@"/", ""));
        }
        //}
        return objBELPatInfo;
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/PatientInformation.aspx");
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
    private void ReadDO_MobileNo()
    {
        objBELPatInfo = objDALPatInfo.SelectOne_MobileNo(Convert.ToString(txtSearchMobile.Text));

        // txtPrnNo.Text = Convert.ToString(Session["HospitalName"]) + '-' + objBELPatInfo.PatRegId + '-' + Convert.ToString(Session["FinancialYear"]);
        //txtBarCodeId.Text = objBELPatInfo.BarcodeId;
        ViewState["TitleID"] = objBELPatInfo.TitleId;
        ddlTitleName.SelectedValue = Convert.ToString(objBELPatInfo.TitleId);
        txtFirstName.Text = objBELPatInfo.FirstName;
        //txtMiddleName.Text = objBELPatInfo.MiddleName;
        //txtLastName.Text = objBELPatInfo.LastName;
        //ddlPatientCategoryName.SelectedValue = Convert.ToString(objBELPatInfo.PatMainTypeId);
        ViewState["PatientCategoryID"] = objBELPatInfo.PatMainTypeId;
        //LoadPatientSubCategoryName();
        //ddlPatientSubCategoryName.SelectedValue = Convert.ToString(objBELPatInfo.PatientInsuTypeId);
        //ViewState["PatientSubCategoryID"] = objBELPatInfo.PatientInsuTypeId;

        //txtPolicyNo.Text = objBELPatInfo.PolicyNo;
        ddlGender.SelectedValue = Convert.ToString(objBELPatInfo.GenderId);
        ViewState["GenderID"] = objBELPatInfo.GenderId;
        txtBirthDate.Text = Convert.ToString(objBELPatInfo.BirthDate);//12.10,2014
        if (txtBirthDate.Text != "")
        {
            txtBirthDate.Text = DateTime.Parse(txtBirthDate.Text).ToString("dd/MM/yyyy");

            txtBirthDate_TextChanged(null, null);
        }
        ddlBloodGroup.SelectedValue = Convert.ToString(objBELPatInfo.BloodGroup);
        ddlMaritalStatus.SelectedValue = Convert.ToString(objBELPatInfo.MaritalStatus);
        //ddlGuardianTitle.SelectedValue = Convert.ToString(objBELPatInfo.GuardianTitleId);
        //ViewState["GuardianTitleID"] = objBELPatInfo.GuardianTitleId;
        //txtGuardianName.Text = objBELPatInfo.GuardianName;
        txtMobileNo.Text = objBELPatInfo.MobileNo;
        // txtPhoneNo.Text = objBELPatInfo.PhoneNo;
        txtPatientAddress.Value = objBELPatInfo.PatientAddress;
        LoadCountryName();
        ddlCountryName.SelectedValue = Convert.ToString(objBELPatInfo.CountryId);
        if (ddlCountryName.SelectedValue == "0")
        {
            ddlCountryName.SelectedValue = "1";
        }
        LoadStateName();
        ddlStateName.SelectedValue = Convert.ToString(objBELPatInfo.StateId);
        if (ddlStateName.SelectedValue == "0")
        {
            ddlStateName.SelectedValue = "1";
        }
        LoadCityName();
        ddlCityName.SelectedValue = Convert.ToString(objBELPatInfo.CityId);


        txtEmail.Text = objBELPatInfo.Email;

        txthealthcardNo.Text = objBELPatInfo.HealthCardNo;
        txtpassportNo.Text = objBELPatInfo.PassportNo;
        ddlRace.SelectedValue =  Convert.ToString( objBELPatInfo.RaceId);
        ddlReligion.SelectedValue = Convert.ToString( objBELPatInfo.ReligionId);
        //txtEntryDate.Text = Convert.ToString(objBELPatInfo.EntryDate);
        // ImagePath =Convert.ToString( objDOPatientInfo.ImagePath);
        ViewState["PhotoPath"] = objBELPatInfo.ImagePath;
        imgPatient.ImageUrl = objBELPatInfo.ImagePath;
        //if (objBELPatInfo.Age != "")
        //{
        //    txtAge.Text = objBELPatInfo.Age;
        //}
        //else
        //{
        //    txtAge.Text = "";
        //}
    }
   
    private void ReadDO()
    {
        objBELPatInfo = objDALPatInfo.SelectOne(Convert.ToInt32(ViewState["PatientInfoID"]));

      
        ViewState["TitleID"] = objBELPatInfo.TitleId;
        ddlTitleName.SelectedValue = Convert.ToString(objBELPatInfo.TitleId);
        txtFirstName.Text = objBELPatInfo.FirstName;
       
        ViewState["PatientCategoryID"] = objBELPatInfo.PatMainTypeId;
      
        ddlGender.SelectedValue = Convert.ToString(objBELPatInfo.GenderId);
        ViewState["GenderID"] = objBELPatInfo.GenderId;
        txtBirthDate.Text = Convert.ToString(objBELPatInfo.BirthDate);//12.10,2014
        if (txtBirthDate.Text != "")
        {
            txtBirthDate.Text = DateTime.Parse(txtBirthDate.Text).ToString("dd/MM/yyyy");

            txtBirthDate_TextChanged(null, null);
        }
        ddlBloodGroup.SelectedValue = Convert.ToString(objBELPatInfo.BloodGroup);
        ddlMaritalStatus.SelectedValue = Convert.ToString(objBELPatInfo.MaritalStatus);        
       
        txtMobileNo.Text = objBELPatInfo.MobileNo;
       
        txtPatientAddress.Value = objBELPatInfo.PatientAddress;
        LoadCountryName();
        ddlCountryName.SelectedValue = Convert.ToString(objBELPatInfo.CountryId);
        if (ddlCountryName.SelectedValue == "0")
        {
            ddlCountryName.SelectedValue = "1";
        }
        LoadStateName();
        ddlStateName.SelectedValue = Convert.ToString(objBELPatInfo.StateId);
        if (ddlStateName.SelectedValue == "0")
        {
            ddlStateName.SelectedValue = "1";
        }
        LoadCityName();
        ddlCityName.SelectedValue = Convert.ToString(objBELPatInfo.CityId);
        txtNationality.Text = Convert.ToString(objBELPatInfo.Nationality);
        txtBirthPlace.Text = Convert.ToString(objBELPatInfo.BirthPlace);

        txtEmail.Text = objBELPatInfo.Email;
        RblVaccineType.SelectedValue = Convert.ToString( objBELPatInfo.VaccinationStatus);

        txtallergy.Text = Convert.ToString(objBELPatInfo.Allergy);
        txtComplant.Text = Convert.ToString(objBELPatInfo.ChiefComplant);
        
        ViewState["PhotoPath"] = objBELPatInfo.ImagePath;
        imgPatient.ImageUrl = objBELPatInfo.ImagePath;



       ddlRelation.SelectedValue= Convert.ToString( objBELPatInfo.P_Relation);
       txtrelativeName.Text = objBELPatInfo.P_RelativeName;
       txtContactNo.Text = objBELPatInfo.P_ContactNo;
       txtAddress1.Text = objBELPatInfo.P_Address1;


       ddlrelation2.SelectedValue = Convert.ToString(objBELPatInfo.P_Relation1);
       txtRelativeName2.Text = objBELPatInfo.P_RelativeName1;
       txtcontaxtNo2.Text = objBELPatInfo.P_ContactNo1;
       txtaddress2.Text = objBELPatInfo.P_Address2;

       ddlRace.SelectedValue = Convert.ToString( objBELPatInfo.RaceId);

       ddlReligion.SelectedValue = Convert.ToString(objBELPatInfo.ReligionId);
       txtpassportNo.Text = Convert.ToString(objBELPatInfo.PassportNo);
    }

    protected void btnOPD_Click(object sender, EventArgs e)
    {
        Session["PatientInfoID"] = Convert.ToInt32(ViewState["PatientInfoID"]);
       // Response.Redirect("~/OPDPatientRegistration.aspx?PatientInfoID=" + Convert.ToString(ViewState["PatientInfoID"]),false);
        Response.Redirect("~/Procedures.aspx?PatientInfoID=" + Convert.ToString(ViewState["PatientInfoID"]), false);
    }

    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchPatient(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        return objDALOpdReg.FillAllPatient(prefixText);
    }

    protected void txtPatientName_TextChanged(object sender, EventArgs e)
    {
        string[] PatientInfo = txtPatientName.Text.Split('-');
        if (PatientInfo.Length > 1)
        {
            txtPatientName.Text = PatientInfo[1];
            ViewState["PatientInfoID"] = PatientInfo[0];
            ViewState["PatientInfoIDTemp"] = PatientInfo[0];
            
            //ViewState["PatientInfoID"] = hfPatientId.Value.ToString();
            // int Id = Convert.ToInt32(ViewState["PatientInfoID"]);
            if (ViewState["PatientInfoID"] != null)
            {
                //  ViewState["PatientInfoID"] = Id;           
                FillPage();
            }
            lblMessage.Text = "";
            btnOPD.Visible = true;
            btnIPD.Visible = true;
            btnLab.Visible = true;
            btnProcedure.Visible = true;
        }
        else
        {
            lblMessage.Text = "Patient Not found";
        }
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        UpdatePanel1.Visible = true;
        Reset();
        ViewState["PatientInfoID"] = "0";
        ViewState["PatientInfoIDTemp"] = "0";
      
        
    }

    private void Reset()
    {      
        txtPatientName.Text = "";       
        ViewState["TitleID"] = 0;      
        txtFirstName.Text = "";        
        ViewState["PatientCategoryID"] = 0;      
        ViewState["PatientSubCategoryID"] = 0;       
        ViewState["GenderID"] = 0;
        ddlGender.SelectedIndex = -1;
        txtBirthDate.Text = "";        
        ddlBloodGroup.SelectedIndex = -1;        
        ddlMaritalStatus.SelectedIndex = -1;
        ViewState["GuardianTitleID"] = 0;       
        txtMobileNo.Text = "";       
        txtEmail.Text = "";        
        ddlCountryName.SelectedIndex = 0;
        ddlStateName.SelectedIndex = -1;
        ddlCityName.SelectedIndex = -1;      
        txtPatientAddress.InnerText = "";
        ViewState["CountryID"] = 0;
        ViewState["StateID"] = 0;
        ViewState["CityID"] = 0;
        imgPatient.ImageUrl = "~/Images0/Preview.png";
        ViewState["PhotoPath"] = "";
        txtAge.Text = "";
        txtSearchMobile.Text = "";
        txtBirthPlace.Text = "";
        txtNationality.Text = "";
        txtallergy.Text = "";
        txtComplant.Text = "";
       
        this.ddlTitleName_SelectedIndexChanged(null,null);
    }
    protected void btnIPD_Click(object sender, EventArgs e)
    {
        Session["PatientInfoID"] = Convert.ToInt32(ViewState["PatientInfoID"]);
       // Response.Redirect("~/IPDDesk.aspx");
        Response.Redirect("~/IPDDesk.aspx?PatientInfoID=" + Convert.ToString(ViewState["PatientInfoID"]), false);
    }
    protected void txtAge_TextChanged(object sender, EventArgs e)
    {
        if (txtAge.Text != "")
        {
            ViewState["Today"] = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
            int age = Convert.ToInt32(txtAge.Text);
            int days = 0;
            int year = Convert.ToInt32(DateTime.Now.Year - age);
            if (year % 400 == 0 || (year % 4 == 0 && year % 100 != 0))
            {
                if (DateTime.Now.Month == 02)
                {
                    days = 29;
                }
                else
                {
                    days = DateTime.Now.Day;
                }

            }
            else
            {
                if (DateTime.Now.Month == 02)
                {
                    days = 28;
                }
                else
                {
                    days = DateTime.Now.Day;
                }
            }

            ViewState["Year"] = Convert.ToString(DateTime.Now.Year - age);

            ViewState["Today"] = days + "/" + DateTime.Now.Month.ToString("00") + "/" + ViewState["Year"];
            // txtBirthDate.Text = Convert.ToString(MyDateTime.GetMMDDYYYYDateString(ViewState["Today"].ToString())); //Convert.ToDateTime(MyDateTime.GetMMDDYYYYDateString(txtBirthDate.Text));
            txtBirthDate.Text = Convert.ToString(ViewState["Today"].ToString());//Date Format- dd/MM/yyyy 
            //chbxIsConfirmBirthDate.Checked = false;
            //chbxIsConfirmBirthDate.Disabled = true;
        }
    }
    protected void ddlAge_SelectedIndexChanged(object sender, EventArgs e)
    {

        int Age = Convert.ToInt32(ddlAge.SelectedIndex);
        ViewState["Age"] = Convert.ToInt32(Age);

        if ((Convert.ToInt32(ViewState["Age"])) == 0)
        {
            int age = Convert.ToInt32(txtAge.Text);

            ViewState["Year"] = Convert.ToString(DateTime.Now.Year - age);
            ViewState["Today"] = DateTime.Now.Day + "/" + DateTime.Now.Month.ToString("00") + "/" + ViewState["Year"];
            // txtBirthDate.Text = Convert.ToString(MyDateTime.GetMMDDYYYYDateString(ViewState["Today"].ToString())); 
            txtBirthDate.Text = Convert.ToString(ViewState["Today"].ToString());//Date Format- dd/MM/yyyy 

        }
        else if ((Convert.ToInt32(ViewState["Age"])) == 1)
        {
            int age = Convert.ToInt32(txtAge.Text);
            if (age > 12)
            {
                age = 1;
                ViewState["Year"] = Convert.ToString(DateTime.Now.Year - age);
                ViewState["Today"] = DateTime.Now.Day + "/" + DateTime.Now.Month.ToString("00") + "/" + ViewState["Year"];
                //txtBirthDate.Text = Convert.ToString(MyDateTime.GetMMDDYYYYDateString(ViewState["Today"].ToString()));
                txtBirthDate.Text = Convert.ToString(ViewState["Today"].ToString());//Date Format- dd/MM/yyyy 
            }
            else
            {
                ViewState["Month"] = Convert.ToString(DateTime.Now.Month - age);
                ViewState["Today"] = DateTime.Now.Day + "/" + ViewState["Month"] + "/" + DateTime.Now.Year;
                //txtBirthDate.Text = Convert.ToString(MyDateTime.GetMMDDYYYYDateString(ViewState["Today"].ToString()));
                txtBirthDate.Text = Convert.ToString(ViewState["Today"].ToString());//Date Format- dd/MM/yyyy 
            }
        }
        else
        {
            int age = Convert.ToInt32(txtAge.Text);
            ViewState["Day"] = Convert.ToString(DateTime.Now.Day - age);
            ViewState["Today"] = ViewState["Day"] + "/" + DateTime.Now.Month.ToString("00") + "/" + DateTime.Now.Year;
            //txtBirthDate.Text = Convert.ToString(MyDateTime.GetMMDDYYYYDateString(ViewState["Today"].ToString()));
            txtBirthDate.Text = Convert.ToString(ViewState["Today"].ToString());//Date Format- dd/MM/yyyy 
        }
        //chbxIsConfirmBirthDate.Checked = false;
        //chbxIsConfirmBirthDate.Disabled = true;
    }
    protected void txtBirthDate_TextChanged(object sender, EventArgs e)
    {
        int intYear, intMonth, intDays;
        DateTime Birthday = Convert.ToDateTime(txtBirthDate.Text);
        intYear = Birthday.Year;
        intMonth = Birthday.Month;
        intDays = Birthday.Day;

        DateTime dtt = Convert.ToDateTime(txtBirthDate.Text);

        DateTime td = DateTime.Now;
        int Leap_Year = 0;
        for (int i = dtt.Year; i < td.Year; i++)
        {
            if (DateTime.IsLeapYear(i))
            {
                ++Leap_Year;
            }
        }
        TimeSpan timespan = td.Subtract(Birthday);
        intDays = timespan.Days - Leap_Year;
        int intResult = 0;
        intYear = Math.DivRem(intDays, 365, out intResult);
        intMonth = Math.DivRem(intResult, 30, out intResult);
        intDays = intResult;
        if (intYear > 0 && intDays > 0)
        {
            txtAge.Text = intYear.ToString();
            ddlAge.SelectedIndex = 0;
        }
        else if (intYear > 0 && intDays == 0)
        {
            txtAge.Text = intYear.ToString();
            ddlAge.SelectedIndex = 0;
        }
        else if (intMonth > 0)
        {
            txtAge.Text = intMonth.ToString();
            ddlAge.SelectedIndex = 1;
        }
        else if (intDays > 0)
        {
            txtAge.Text = intDays.ToString();
            ddlAge.SelectedIndex = 2;
        }
        //if (DateTime.Now.Year > Birthday.Year)
        //{
        //    int BirthAge = ((DateTime.Now.Year - Birthday.Year) * 372 + (DateTime.Now.Month - Birthday.Month) * 31 + (DateTime.Now.Day - Birthday.Day)) / 372;
        //    txtAge.Text = BirthAge.ToString();
        //    ddlAge.SelectedIndex = 0;
        //}

    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        try
        {
            if (FileUpload1.PostedFile.FileName != "")
            {
               // string fileName = "~/PatientImages/" + Path.GetFileName(FileUpload1.PostedFile.FileName);
                string fileName1 = FileUpload1.PostedFile.FileName;
                string fileName = HttpContext.Current.Server.MapPath(string.Format("~/PatientImages/{0}", fileName1));
                FileUpload1.SaveAs(Server.MapPath("~/PatientImages/" + FileUpload1.FileName));
                //"~/upload/" + FileUpload1.FileName;
                ViewState["PhotoPath"] = fileName;
                imgPatient.ImageUrl = Convert.ToString(ViewState["PhotoPath"]);
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;

        }
    }
    protected void btnEditImage_Click(object sender, EventArgs e)
    {
        // this.ModalPopupExtender1.Show();
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
    }
    protected void txtFirstName_TextChanged(object sender, EventArgs e)
    {
        // txtPrnNo.Text= txtFirstName.Text +'-'+ txtPrnNo.Text +'-'+"2018-2019";
    }
    protected void btnRemoveImage_Click(object sender, EventArgs e)
    {
        imgPatient.ImageUrl = "~/Images/PatientImages/Preview.png";
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
              ReadDO_MobileNo();
            
            lblMessage.Text = "";
            btnOPD.Visible = true;
            btnIPD.Visible = true;
            btnLab.Visible = true;
            btnProcedure.Visible = true;
       
    }
    protected void btnCard_Click(object sender, EventArgs e)
    {
        try
        {

          
            int BranchId = Convert.ToInt32(Session["Branchid"]);
            int FId = Convert.ToInt32(Session["FId"]);

            BLLReports ObjDOReport = new BLLReports();
            DataSet dsPatInfo = new DataSet();
            ReportDocument crystalReport = new ReportDocument();
            //crystalReport.Load(Server.MapPath("~/Reports/Rpt_DeptStoreWiseItems.rpt"));


            //string sql = "";
            //SqlConnection con = DataAccess.ConInitForDC();
            //SqlCommand cmd1 = con.CreateCommand();

            //string query = "ALTER VIEW [dbo].[Vw_PatientInfo] AS (SELECT        TOP (100) PERCENT PatientInformation.PatientInfoId, ISNULL(T.Title, ' ') + ' ' + PatientInformation.FirstName + ' ' + ISNULL(PatientInformation.MiddleName, '') + ' ' + ISNULL(PatientInformation.LastName, '') AS PatientName,  " +
            //      "  PatientInformation.PatRegId, PatientInformation.BarcodeId, PC.PatMainTypeId, PSC.PatientInsuTypeId, PC.PatMainType, PSC.PatientInsuType, G.GenderName, CONVERT(varchar(10), PatientInformation.BirthDate, 103) "+
            //      "  AS BirthDate, PatientInformation.IsConfirmBirthDate, PatientInformation.BloodGroup, PatientInformation.MaritalStatus, GT.Title + ' ' + PatientInformation.GuardianName AS GuardianName, PatientInformation.MobileNo, "+
            //      "  PatientInformation.PhoneNo, PatientInformation.PatientAddress, D.CityName, PatientInformation.Email, PatientInformation.EntryDate, PatientInformation.ImagePath, PatientInformation.PolicyNo, PatientInformation.IsActive,  "+
            //      "  PatientInformation.BranchId, PatientInformation.FId, CONVERT(varchar(10), PatientInformation.Age) + '  ' + PatientInformation.AgeType AS Age, T.Title, PatientInformation.CreatedBy, PatientInformation.CreatedOn, "+
            //      "  PatientInformation.ParentMergNo, PatientInformation.MergeBy, PatientInformation.MergeOn, PatientInformation.IsMerge, PatientInformation.IsFileUpload, PatientInformation.Image1, PatientInformation.ImagePathPhoto "+
            //      "  FROM            PatientInformation LEFT OUTER JOIN "+
            //      "  Initial AS T ON T.TitleId = PatientInformation.TitleId LEFT OUTER JOIN "+
            //      "  PatMainType AS PC ON PC.PatMainTypeId = PatientInformation.PatMainTypeId LEFT OUTER JOIN "+
            //      "  PatientInsuType AS PSC ON PSC.PatientInsuTypeId = PatientInformation.PatientInsuTypeId LEFT OUTER JOIN "+
            //      "  Gender AS G ON G.GenderId = PatientInformation.GenderId LEFT OUTER JOIN "+
            //      "  Initial AS GT ON GT.TitleId = PatientInformation.GuardianTitleId LEFT OUTER JOIN "+
            //      "  CountryMst AS C ON C.CountryId = PatientInformation.CountryId LEFT OUTER JOIN "+
            //      "  StateMst AS S ON S.StateId = PatientInformation.StateId LEFT OUTER JOIN "+
            //      "  CityMst AS D ON D.CityId = PatientInformation.CityId   where PatientInformation.PatRegId=" + Convert.ToInt32(ViewState["PatientInfoID"]) + " " +
            //      "  ORDER BY PatientInformation.EntryDate DESC " ;
            



            //cmd1.CommandText = query + ")";

            //con.Open();
            //cmd1.ExecuteNonQuery();
            //con.Close(); con.Dispose();

            crystalReport.Load(Server.MapPath("~/Report/Rpt_PatientCard.rpt"));
            dsPatInfo = ObjDOReport.FillPatientCard(Convert.ToInt32(ViewState["PatientInfoID"]), BranchId, FId);
            crystalReport.SetDataSource(dsPatInfo);
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

    private void LoadRelation()
    {
        ddlRelation.DataSource = objDALOpdReg.FillRelationDrop();
        ddlRelation.DataValueField = "RelationId";
        ddlRelation.DataTextField = "RelationName";
        ddlRelation.DataBind();

        ddlrelation2.DataSource = objDALOpdReg.FillRelationDrop();
        ddlrelation2.DataValueField = "RelationId";
        ddlrelation2.DataTextField = "RelationName";
        ddlrelation2.DataBind();
    }
    protected void ChkISsameAdd_CheckedChanged(object sender, EventArgs e)
    {
        if (ChkISsameAdd.Checked == true)
        {
            txtAddress1.Text = txtPatientAddress.Value;
        }

    }
    protected void chkisSameaddress1_CheckedChanged(object sender, EventArgs e)
    {
        if (chkisSameaddress1.Checked == true)
        {
            txtaddress2.Text = txtPatientAddress.Value;
        }
    }


    protected void btnLab_Click(object sender, EventArgs e)
    {
        Session["PatientInfoID"] = Convert.ToInt32(ViewState["PatientInfoID"]);
        Response.Redirect("~/LabPatientRegistration.aspx?PatientInfoID=" + Convert.ToString(ViewState["PatientInfoID"]), false);

    }

    protected void btnProcedure_Click(object sender, EventArgs e)
    {
        Session["PatientInfoID"] = Convert.ToInt32(ViewState["PatientInfoID"]);
        Response.Redirect("~/Procedures.aspx?PatientInfoID=" + Convert.ToString(ViewState["PatientInfoID"]), false);
    }
    protected void btncapturephoto_Click(object sender, EventArgs e)
    {
        Session["PID_Img"] = ViewState["PatientInfoID"];
        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(1000/2);var Mtop = (screen.height/2)-(500/2);window.open( 'CS.aspx?PID=" + ViewState["PatientInfoID"] + "&PatRegID=" + ViewState["PatientInfoID"] + "&Branchid=" + Session["Branchid"].ToString() + "&FID=" + Session["FId"] + " ', null, 'height=500,width=1000,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);

    }
    protected void btnbabycard_Click(object sender, EventArgs e)
    {
        try
        {


            int BranchId = Convert.ToInt32(Session["Branchid"]);
            int FId = Convert.ToInt32(Session["FId"]);

            BLLReports ObjDOReport = new BLLReports();
            DataSet dsPatInfo = new DataSet();
            ReportDocument crystalReport = new ReportDocument();
            //crystalReport.Load(Server.MapPath("~/Reports/Rpt_DeptStoreWiseItems.rpt"));


            //string sql = "";
            //SqlConnection con = DataAccess.ConInitForDC();
            //SqlCommand cmd1 = con.CreateCommand();

            //string query = "ALTER VIEW [dbo].[Vw_PatientInfo] AS (SELECT        TOP (100) PERCENT PatientInformation.PatientInfoId, ISNULL(T.Title, ' ') + ' ' + PatientInformation.FirstName + ' ' + ISNULL(PatientInformation.MiddleName, '') + ' ' + ISNULL(PatientInformation.LastName, '') AS PatientName,  " +
            //      "  PatientInformation.PatRegId, PatientInformation.BarcodeId, PC.PatMainTypeId, PSC.PatientInsuTypeId, PC.PatMainType, PSC.PatientInsuType, G.GenderName, CONVERT(varchar(10), PatientInformation.BirthDate, 103) "+
            //      "  AS BirthDate, PatientInformation.IsConfirmBirthDate, PatientInformation.BloodGroup, PatientInformation.MaritalStatus, GT.Title + ' ' + PatientInformation.GuardianName AS GuardianName, PatientInformation.MobileNo, "+
            //      "  PatientInformation.PhoneNo, PatientInformation.PatientAddress, D.CityName, PatientInformation.Email, PatientInformation.EntryDate, PatientInformation.ImagePath, PatientInformation.PolicyNo, PatientInformation.IsActive,  "+
            //      "  PatientInformation.BranchId, PatientInformation.FId, CONVERT(varchar(10), PatientInformation.Age) + '  ' + PatientInformation.AgeType AS Age, T.Title, PatientInformation.CreatedBy, PatientInformation.CreatedOn, "+
            //      "  PatientInformation.ParentMergNo, PatientInformation.MergeBy, PatientInformation.MergeOn, PatientInformation.IsMerge, PatientInformation.IsFileUpload, PatientInformation.Image1, PatientInformation.ImagePathPhoto "+
            //      "  FROM            PatientInformation LEFT OUTER JOIN "+
            //      "  Initial AS T ON T.TitleId = PatientInformation.TitleId LEFT OUTER JOIN "+
            //      "  PatMainType AS PC ON PC.PatMainTypeId = PatientInformation.PatMainTypeId LEFT OUTER JOIN "+
            //      "  PatientInsuType AS PSC ON PSC.PatientInsuTypeId = PatientInformation.PatientInsuTypeId LEFT OUTER JOIN "+
            //      "  Gender AS G ON G.GenderId = PatientInformation.GenderId LEFT OUTER JOIN "+
            //      "  Initial AS GT ON GT.TitleId = PatientInformation.GuardianTitleId LEFT OUTER JOIN "+
            //      "  CountryMst AS C ON C.CountryId = PatientInformation.CountryId LEFT OUTER JOIN "+
            //      "  StateMst AS S ON S.StateId = PatientInformation.StateId LEFT OUTER JOIN "+
            //      "  CityMst AS D ON D.CityId = PatientInformation.CityId   where PatientInformation.PatRegId=" + Convert.ToInt32(ViewState["PatientInfoID"]) + " " +
            //      "  ORDER BY PatientInformation.EntryDate DESC " ;




            //cmd1.CommandText = query + ")";

            //con.Open();
            //cmd1.ExecuteNonQuery();
            //con.Close(); con.Dispose();

            crystalReport.Load(Server.MapPath("~/Report/Rpt_BabyPatientCard.rpt"));
            dsPatInfo = ObjDOReport.FillPatientCard(Convert.ToInt32(ViewState["PatientInfoID"]), BranchId, FId);
            crystalReport.SetDataSource(dsPatInfo);
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
    public void PAtValidate()
    {
        DataTable dtLDP = new DataTable();
        dtLDP = objDALOpdReg.Get_TotalPatientVal();
        if (dtLDP.Rows.Count > 0)
        {          
           
        }
        else
        {
            string BCount = Patmst_New_Bal_C.PatientCountBanner(1);
            if (Convert.ToInt32(BCount) > 1111)
            {
                Server.Transfer("~/Login.aspx", true);
            }
        }
    }
}