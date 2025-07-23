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

public partial class IPDRegistration : BaseClass
{
    DALPatientInformation objDALPatInfo = new DALPatientInformation();
    BELPatientInformation objBELPatInfo = new BELPatientInformation();
    DALEmpReg objDALEmpReg = new DALEmpReg();
    BELOPDPatReg objBELOpdReg = new BELOPDPatReg();
    DALOpdReg objDALOpdReg = new DALOpdReg();
    DALIpdRegistration objDALIpdReg = new DALIpdRegistration();
    public enum MessageType { Success, Error, Info, Warning };
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["PatientChargeSubCategory"] = "0";
            ViewState["PatientSubCategory"] = "0";
            ViewState["PatientSubCategory2"] = "0";
            ViewState["InfantIPDNO"] = "0";
            LoadTitleName();
            FillDepartmentDrop();
            LoadConsultantDoc();
            LoadReferenceDoc();
            LoadPatientMainType();
            LoadRelation();
            btnInsurance.Visible = false;
           //txtTime.Text=DateTime.Now.

            txtInfantaDOB.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");

            DateTime time = DateTime.Now;
            txtRegistrationDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            String s = time.ToString("hh:mm tt");
           txtTime.Text = s;
            //ddlPatientCategoryName_SelectedIndexChanged(null, null);
            if (Request.QueryString["RoomId"] != null && Request.QueryString["BedId"] != null && Request.QueryString["BedName"] != null && Request.QueryString["RoomName"] != null)
            {
               string RoomName=Convert.ToString(Request.QueryString["RoomName"]);
                string BedName=Convert.ToString(Request.QueryString["BedName"]);
               // lblVisitingNo.Text = "Room Name is = " + RoomName + " and Bed Name is = " + BedName;
                lblRoomInfo.Text = "Room Name is = " + RoomName + " and Bed Name is = " + BedName;
                ViewState["PatientInfoId"] = Convert.ToString( Request.QueryString["RegNo"]);
                txtRegNo.Text = Convert.ToString(Request.QueryString["RegNo"]);
                rblPatcate_SelectedIndexChanged(null, null);
                fillInformation();
            }
            if (Request.QueryString["ReferToAdmi"] != null)
            {
                if (Convert.ToString( Request.QueryString["ReferToAdmi"]) != "")
                {
                    DataTable dt = new DataTable();
                    dt = objDALOpdReg.Get_DrNAme(Convert.ToString(Request.QueryString["ReferToAdmi"]));
                    txtConsDoctorName.Text = Convert.ToString(dt.Rows[0]["EmpName"]);
                }
            }
            if (Request.QueryString["Type"] == "EditIPDReg")
            {
                FillIpdRegistration();
                btnInsurance.Visible = true;
                ViewState["IpdId"] = Convert.ToInt32(Request.QueryString["IpdId"]);
               
                fillInformation();
            }
            else
            {
                ddlPatientCategoryName_SelectedIndexChanged(null, null);
            }
            if (Request.QueryString["ReferToAdmit"] == "YES")
            {
                ViewState["PatientInfoId"] = Request.QueryString["RegNo"];
                txtRegNo.Text = Convert.ToString(Request.QueryString["RegNo"]);
                lblMessage.Text = "Your Reg No:" + txtRegNo.Text;
                fillInformation();
                this.txtConsDoctorName_TextChanged(null, null);
            }
            if(Convert.ToInt32( rblPatcate.SelectedValue)!=1)
            {
                PayType.Visible = true;
            }
        }
        if (Convert.ToString(Session["Branchid"]) == null && Convert.ToString(Session["Branchid"]) == "" && Convert.ToString(Session["Branchid"]) == "0")
        {
            Server.Transfer("~/Login.aspx", true);
        }
    
        
    }

    public void FillIpdRegistration()
    {
        int FId = Convert.ToInt32(Session["FId"]);
        int BranchId = Convert.ToInt32(Session["Branchid"]);
        objBELOpdReg=objDALIpdReg.SelectOne(Convert.ToInt32(Request.QueryString["IpdId"]),FId,BranchId);
        txtRegNo.Text = Convert.ToString(objBELOpdReg.PatRegId);
        ViewState["PatientInfoId"] = Convert.ToString(objBELOpdReg.PatRegId);
       // ddlPatientCategoryName.SelectedValue = Convert.ToString(objBELOpdReg.PatMainTypeId);
       // ddlPatientSubCategoryName.SelectedValue = Convert.ToString(objBELOpdReg.PatientInsuTypeId);
        rblPatcate.SelectedValue = Convert.ToString(objBELOpdReg.PatMainTypeId);
        rblPatcate_SelectedIndexChanged(null, null);
        ddlPatientSubCategoryName1.Text = Convert.ToString(objBELOpdReg.PatientInsuType);
        ddlChargeSubCategory1.Text = Convert.ToString(objBELOpdReg.ChildCompanyName);
        txtInsurance2.Text = Convert.ToString(objBELOpdReg.PatientInsurance2);
       

        ViewState["PatientSubCategory"] = Convert.ToString(objBELOpdReg.PatientInsuTypeId);
        ViewState["PatientSubCategory2"]= Convert.ToString(objBELOpdReg.PatientInsuTypeId2);
        ViewState["PatientChargeSubCategory"] = Convert.ToString(objBELOpdReg.ChargeCompanyId);
       
        if (ddlPatientCategoryName.SelectedValue != "1")
        {
            sp1.Visible = true;
            sp2.Visible = true;
            LoadPatientSubCategoryName();
            ddlPatientSubCategoryName2.SelectedValue = Convert.ToString(objBELOpdReg.PatientInsuTypeId2);
        }
        else
        {
            ddlPatientCategoryName_SelectedIndexChanged(null, null);
        }
        ddlConsultantDoc.SelectedValue= Convert.ToString(objBELOpdReg.PrimaryDoc);
        ViewState["ConsultID"]= Convert.ToString(objBELOpdReg.PrimaryDoc);

        txtConsDoctorName.Text= Convert.ToString(objBELOpdReg.FullDocName);
        ddlSecDoc.SelectedValue = Convert.ToString(objBELOpdReg.SecodaryDoc);
        ViewState["SecondaryDr"] = Convert.ToString(objBELOpdReg.SecodaryDoc);
        txtsecondaryDr.Text = Convert.ToString(objBELOpdReg.SecondaryDoc);
        
        ddlRefDoctor.SelectedValue= Convert.ToString(objBELOpdReg.ReferenceDrId);
        ddlrealation1.SelectedValue = Convert.ToString(objBELOpdReg.Relation1);
        ddlrealation2.SelectedValue = Convert.ToString(objBELOpdReg.Relation2);
        txtContactNo1.Text=Convert.ToString(objBELOpdReg.Contact1);
        txtContactNo2.Text = Convert.ToString(objBELOpdReg.Contact2);
        txtContactPerson1.Text= Convert.ToString(objBELOpdReg.ContactPerson1);
        txtContactPerson2.Text = Convert.ToString(objBELOpdReg.ContactPerson2);
        ddlDepartment.SelectedValue=Convert.ToString(objBELOpdReg.DeptId);
        ViewState["DeptID"] = Convert.ToString(objBELOpdReg.DeptId);
        txtdepartment.Text = Convert.ToString(objBELOpdReg.FullDeptName);
        ddlTitleName.SelectedValue = Convert.ToString(objBELOpdReg.TitleId);
        txtPatientName.Text = Convert.ToString(objBELOpdReg.PatientName);
      //  txtMobileNo.Text = Convert.ToString(objBELOpdReg.MobileNo);
        txtsponsor.Text = Convert.ToString(objBELOpdReg.DiseaseName);
        txtProcedure.Text = Convert.ToString(objBELOpdReg.OperatioName);

        txtaddress1.Text = Convert.ToString(objBELOpdReg.Address1);
        txtaddress2.Text = Convert.ToString(objBELOpdReg.Address2);

        txtletterNumber.Text = Convert.ToString(objBELOpdReg.LetterNumber);

        ViewState["DISEASE"] = Convert.ToInt32(objBELOpdReg.DiseaseId);
        ViewState["Operation"] = Convert.ToInt32(objBELOpdReg.OperationId);
        //if (Convert.ToDouble(objBELOpdReg.Age) < 0.084)
        //{
        //    txtAge.Text = Convert.ToString(Math.Round((Convert.ToDecimal(objBELOpdReg.Age) * 12) * 30));
        //    ddlAge.SelectedValue = "Days";
        //}
        //else if (Convert.ToDouble(objBELOpdReg.Age) < 1)
        //{
        //    txtAge.Text = Convert.ToString(Math.Round(Convert.ToDecimal(objBELOpdReg.Age) * 12));
        //    ddlAge.SelectedValue = "Months";
        //}
        //else
        //{
        //    txtAge.Text = Convert.ToString(Math.Round(Convert.ToDecimal(objBELOpdReg.Age)));
        //    ddlAge.SelectedValue = "Years";
        //}
       
        txtRegistrationDate.Text = Convert.ToString(objBELOpdReg.EntryDate);
        ChkUni.Checked = Convert.ToBoolean(objBELOpdReg.IsUniversalPrecaution);
        ChkEmergency.Checked = Convert.ToBoolean(objBELOpdReg.IsEmergency);
        ddlSurgeryType.SelectedItem.Text = Convert.ToString(objBELOpdReg.SurgeryType);
        ViewState["DepositAmt"]=Convert.ToString(objBELOpdReg.DepositAmt);

        if (objBELOpdReg.Infant == 1)
        {
            Infanta1.Visible = true;
            Infanta2.Visible = true;
            txtInfantaDOB.Text = Convert.ToString(objBELOpdReg.InfantDOB);
            ddlGender.SelectedItem.Text = Convert.ToString(objBELOpdReg.InfantGender);
            ddlRace.SelectedValue = Convert.ToString( objBELOpdReg.InfantRace);
            ChkInfant.Checked = true;
            btnInfant.Visible = true;
        }
        else
        {
            ChkInfant.Checked = false;
            Infanta1.Visible = false;
            Infanta2.Visible = false;
            btnInfant.Visible = false;
        }
        if (Convert.ToInt32(rblPatcate.SelectedValue) != 1)
        {
            PayType.Visible = true;

            rblPaymentype.SelectedValue = Convert.ToString(objBELOpdReg.PaymentType);
            if (Convert.ToString(objBELOpdReg.PaymentType) == "3")
            {
                txtpartpayment.Text = Convert.ToString(objBELOpdReg.PaymentRemark);
                PartPay.Visible = true;
            }
            
        }
        BindImages();
    }
    private void LoadReferenceDoc()
    {
        ddlRefDoctor.DataSource = objDALOpdReg.FillReferenceDoctor();
        ddlRefDoctor.DataValueField = "DrId";
        ddlRefDoctor.DataTextField = "EmpName";
        ddlRefDoctor.DataBind();

        ddlGender.DataSource = objDALPatInfo.FillGender();
        ddlGender.DataTextField = "GenderName";
        ddlGender.DataValueField = "GenderId";
        ddlGender.DataBind();

        ddlRace.DataSource = objDALPatInfo.Get_Race();
        ddlRace.DataTextField = "RaceName";
        ddlRace.DataValueField = "RaceID";
        ddlRace.DataBind();
        ddlRace.Items.Insert(0, new ListItem("Select Race", "0"));
    }
    private void LoadRelation()
    {
        ddlrealation1.DataSource = objDALOpdReg.FillRelationDrop();
        ddlrealation1.DataValueField = "RelationId";
        ddlrealation1.DataTextField = "RelationName";
        ddlrealation1.DataBind();

        ddlrealation2.DataSource = objDALOpdReg.FillRelationDrop();
        ddlrealation2.DataValueField = "RelationId";
        ddlrealation2.DataTextField = "RelationName";
        ddlrealation2.DataBind();
    }

    private void LoadConsultantDoc()
    {

        ddlConsultantDoc.DataSource = objDALOpdReg.FillConsultantDocName();
        ddlConsultantDoc.DataValueField = "DrId";
        ddlConsultantDoc.DataTextField = "EmpName";
        ddlConsultantDoc.DataBind();

        ddlSecDoc.DataSource = objDALOpdReg.FillConsultantDocName();
        ddlSecDoc.DataValueField = "DrId";
        ddlSecDoc.DataTextField = "EmpName";
        ddlSecDoc.DataBind();
    }

    private void LoadPatientMainType()
    {
        ddlPatientCategoryName.DataSource = objDALPatInfo.FillPatMainTypeDrop();
        ddlPatientCategoryName.DataTextField = "PatMainType";
        ddlPatientCategoryName.DataValueField = "PatMainTypeId";
        ddlPatientCategoryName.DataBind();
    }

    private void LoadPatientSubCategoryName()
    {
        ddlPatientSubCategoryName.DataSource = objDALPatInfo.FillPatInsuTypeDrop(Convert.ToInt32(ViewState["PatientCategoryID"]));
        ddlPatientSubCategoryName.DataTextField = "PatientInsuType";
        ddlPatientSubCategoryName.DataValueField = "PatientInsuTypeId";
        ddlPatientSubCategoryName.DataBind();
        //ddlPatientSubCategoryName.Items.Insert(0, new ListItem("Select sponser", "0"));
        ddlPatientSubCategoryName2.DataSource = objDALPatInfo.FillPatInsuTypeDrop(Convert.ToInt32(ViewState["PatientCategoryID"]));
        ddlPatientSubCategoryName2.DataTextField = "PatientInsuType";
        ddlPatientSubCategoryName2.DataValueField = "PatientInsuTypeId";
        ddlPatientSubCategoryName2.DataBind();
        ddlPatientSubCategoryName2.Items.Insert(0, new ListItem("Select sponser", "0"));
    }
    private void LoadTitleName()
    {
        ddlTitleName.DataSource = objDALPatInfo.FillTitleName();
        ddlTitleName.DataTextField = "Title";
        ddlTitleName.DataValueField = "TitleId";
        ddlTitleName.DataBind();

        ddlSurgeryType.DataSource = objDALPatInfo.Get_Surgery_Type();
        ddlSurgeryType.DataTextField = "SurgeryName";
        ddlSurgeryType.DataValueField = "SurgeryId";
        ddlSurgeryType.DataBind();
        ddlSurgeryType.Items.Insert(0, new ListItem("Select Surgery", "0"));
        
    }
    protected void FillDepartmentDrop()
    {
        ddlDepartment.DataSource = objDALEmpReg.FillDeptDrop();
        ddlDepartment.DataValueField = "DeptId";
        ddlDepartment.DataTextField = "DeptName";
        ddlDepartment.DataBind();
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
            if (PatientInfo.Length == 3)
            {
                txtPatientName.Text = PatientInfo[1];
                ViewState["PatientInfoId"] = PatientInfo[0];
                txtRegNo.Text = Convert.ToString(PatientInfo[0]);
                lblMessage.Text = "Your Reg No:" + txtRegNo.Text;
                fillInformation();
            }
            else
            {
                ShowMessage("Pls Register Patient First and then admit!", MessageType.Warning);
                lblvalidate.Text = "Pls Register Patient First and then admit.";
            }


    }
    protected void fillInformation()
    {
        if (Convert.ToString(ViewState["PatientInfoId"]) != "")
        {
            objBELPatInfo = objDALPatInfo.SelectOne(Convert.ToInt32(ViewState["PatientInfoId"]));

            txtPatientName.Text = objBELPatInfo.FirstName;// + ' ' + objBELPatInfo.MiddleName + ' ' + objBELPatInfo.LastName;
            ddlTitleName.SelectedValue = Convert.ToString(objBELPatInfo.TitleId);

            lblPatientName.Text = txtPatientName.Text;
            txtpatientregid.Text = Convert.ToString(ViewState["PatientInfoId"]);
            if (Convert.ToDouble(objBELPatInfo.Age) < 0.084)
            {
                string Ag = Convert.ToString(Math.Round((Convert.ToDecimal(objBELPatInfo.Age) * 12) * 30));
                //ddlAge.SelectedValue = "Days";
                lblAge.Text = Ag + " Days  /  " + objBELPatInfo.GenderName; ;
            }
            else if (Convert.ToDouble(objBELPatInfo.Age) < 1)
            {
                string Ag = Convert.ToString(Math.Round(Convert.ToDecimal(objBELPatInfo.Age) * 12));
                //ddlAge.SelectedValue = "Months";
                lblAge.Text = Ag + "  Months  /  " + objBELPatInfo.GenderName; ;
            }
            else
            {
                string Ag = Convert.ToString(Math.Round(Convert.ToDecimal(objBELPatInfo.Age)));
                // ddlAge.SelectedValue = "Years";
                lblAge.Text = Ag + "  Years  /  " + objBELPatInfo.GenderName;
            }

            lblMobileNo.Text = objBELPatInfo.MobileNo;
            lbladdr.Text = objBELPatInfo.PatientAddress;
            // txtaddress2.Text = objBELPatInfo.PatientAddress;
            if (txtContactNo1.Text == "")
            {
                txtContactNo1.Text = objBELPatInfo.P_ContactNo;
            }
            if (ddlrealation1.SelectedIndex == 0)
            {
                ddlrealation1.SelectedValue = Convert.ToString(objBELPatInfo.P_Relation);
            }
            if (txtContactPerson1.Text == "")
            {
                txtContactPerson1.Text = objBELPatInfo.P_RelativeName;
            }
            if (txtContactNo1.Text == "")
            {
                txtContactNo1.Text = objBELPatInfo.P_ContactNo;
            }
            if (txtaddress1.Text == "")
            {
                txtaddress1.Text = objBELPatInfo.P_Address1;
            }
            if (txtContactNo2.Text == "")
            {
                txtContactNo2.Text = objBELPatInfo.P_ContactNo1;
            }
            if (ddlrealation2.SelectedIndex == 0)
            {
                ddlrealation2.SelectedValue = Convert.ToString(objBELPatInfo.P_Relation1);
            }
            if (txtContactPerson2.Text == "")
            {
                txtContactPerson2.Text = objBELPatInfo.P_RelativeName1;
            }
            if (txtContactNo2.Text == "")
            {
                txtContactNo2.Text = objBELPatInfo.P_ContactNo1;
            }
            if (txtaddress2.Text == "")
            {
                txtaddress2.Text = objBELPatInfo.P_Address2;
            }
            DataTable dtIPReg = new DataTable();
            if (ChkInfant.Checked == true)
            {
                //objBELPatInfo = objDALPatInfo.SelectOne();
               
                dtIPReg = objDALPatInfo.Get_IpdRegistrationDetails(Convert.ToInt32(ViewState["PatientInfoId"]));
                if (dtIPReg.Rows.Count > 0)
                {
                    LblMsgAdmitDate.Text = Convert.ToString(Convert.ToDateTime(  dtIPReg.Rows[0]["EntryDate"]).ToString("dd/MM/yyyy")) + " " + Convert.ToString( dtIPReg.Rows[0]["EntryTime"]);
                }
            }

             dtIPReg = new DataTable();
             dtIPReg = objDALPatInfo.Get_CheckOpdPending_Request(Convert.ToInt32(ViewState["PatientInfoId"]));
             if (dtIPReg.Rows.Count > 0)
             {
                 lblMessage.Text = "Pls check LAB Pending Order";
             }
            
        }
    }

    protected void ddlPatientCategoryName_SelectedIndexChanged(object sender, EventArgs e)
    {
        int PatientCategoryId = Convert.ToInt32(ddlPatientCategoryName.SelectedValue);
        ViewState["PatientCategoryID"] = PatientCategoryId;
        if(PatientCategoryId!=1)
        {
            sp1.Visible = true;
            sp2.Visible = true;
        }
        LoadPatientSubCategoryName();
    }
    public bool validation()
    {

        if (txtPatientName.Text == "")
        {
            txtPatientName.Focus();
            txtPatientName.BackColor = Color.Red;
            ShowMessage("Enter Patient Name!", MessageType.Warning);
            return false;
        }
        else
        {
            txtPatientName.BackColor = Color.White;
        }
        if (txtConsDoctorName.Text == "")
        {
            txtConsDoctorName.Focus();
            txtConsDoctorName.BackColor = Color.Red;
            ShowMessage("Enter dr name!", MessageType.Warning);
            return false;
        }
        else
        {
            txtConsDoctorName.BackColor = Color.White;
        }

        //if (txtAge.Text == "")
        //{
        //    txtAge.Focus();
        //    txtAge.BackColor = Color.Red;
        //    ShowMessage("Enter Age!", MessageType.Warning);
        //    return false;
        //}
        //else
        //{
        //    txtAge.BackColor = Color.White;
        //}
        if (ddlSurgeryType.SelectedItem.Text == "Select Surgery")
        {
            ddlSurgeryType.Focus();
            ddlSurgeryType.BackColor = Color.Red;
            ShowMessage("Select Surgery Type!", MessageType.Warning);
            return false;
        }
        else
        {
            ddlSurgeryType.BackColor = Color.White;
        }

        return true;
    }
   
    protected void btnSave_Click(object sender, EventArgs e)
    {
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
        object[] returns;
        string Message = "";
        if (validation() == true)
        {
            if (Request.QueryString["Type"] == "EditIPDReg")
            {
                if (txtRegNo.Text != "")
                {
                    objBELOpdReg.PatRegId = Convert.ToInt32(txtRegNo.Text);
                }
                //objBELOpdReg.PatMainTypeId = Convert.ToInt32(ddlPatientCategoryName.SelectedValue);
                //objBELOpdReg.PatientInsuTypeId = Convert.ToInt32(ddlPatientSubCategoryName.SelectedValue);
                //objBELOpdReg.PatientInsuTypeId2 = Convert.ToInt32(ddlPatientSubCategoryName2.SelectedValue);

                objBELOpdReg.PatMainTypeId = Convert.ToInt32(rblPatcate.SelectedValue);
                objBELOpdReg.PatientInsuTypeId = Convert.ToInt32(ViewState["PatientSubCategory"]);
                objBELOpdReg.PatientInsuTypeId2 = Convert.ToInt32(ViewState["PatientSubCategory2"]);
                objBELOpdReg.ChargeCompanyId = Convert.ToInt32(ViewState["PatientChargeSubCategory"]);


                //objBELOpdReg.PrimaryDoc = Convert.ToInt32(ddlConsultantDoc.SelectedValue);
                objBELOpdReg.PrimaryDoc = Convert.ToInt32(ViewState["ConsultID"]);
               // objBELOpdReg.SecodaryDoc = Convert.ToInt32(ddlSecDoc.SelectedValue);
                objBELOpdReg.SecodaryDoc = Convert.ToInt32(ViewState["SecondaryDr"]);
                objBELOpdReg.ReferenceDrId = Convert.ToInt32(ddlRefDoctor.SelectedValue);
                objBELOpdReg.Relation1 = Convert.ToInt32(ddlrealation1.SelectedValue);
                objBELOpdReg.Relation2 = Convert.ToInt32(ddlrealation2.SelectedValue);
                objBELOpdReg.Contact1 = Convert.ToString(txtContactNo1.Text);
                objBELOpdReg.Contact2 = Convert.ToString(txtContactNo2.Text);
                objBELOpdReg.ContactPerson1 = Convert.ToString(txtContactPerson1.Text);
                objBELOpdReg.ContactPerson2 = Convert.ToString(txtContactPerson2.Text);
                // objBELOpdReg.DeptId = Convert.ToInt32(ddlDepartment.SelectedValue);
                objBELOpdReg.DeptId = Convert.ToInt32(ViewState["DeptID"]);
                objBELOpdReg.UpdatedBy = Convert.ToString(Session["username"]);
                objBELOpdReg.IpdId = Convert.ToInt32(Request.QueryString["IpdId"]);
                objBELOpdReg.BranchId = Convert.ToInt32(Session["Branchid"]);
                objBELOpdReg.FId = Convert.ToInt32(Session["FId"]);
                objBELOpdReg.IsEmergency = Convert.ToBoolean(ChkEmergency.Checked);
                objBELOpdReg.IsUniversalPrecaution = Convert.ToBoolean(ChkUni.Checked);
                objBELOpdReg.DiseaseName = txtsponsor.Text;
                objBELOpdReg.OperatioName = txtProcedure.Text;

                objBELOpdReg.LetterNumber = txtletterNumber.Text;
                if (ddlSurgeryType.SelectedItem.Text != "Select Surgery")
                {
                    objBELOpdReg.SurgeryType = Convert.ToString(ddlSurgeryType.SelectedItem.Text);
                }
                else
                {
                    objBELOpdReg.SurgeryType = "";
                }
                if (txtsponsor.Text != "")
                {
                    objBELOpdReg.DiseaseId = Convert.ToInt32(ViewState["DISEASE"]);
                }
                else
                {
                    objBELOpdReg.DiseaseId = 0;
                }
                if (txtProcedure.Text != "")
                {
                    objBELOpdReg.OperationId = Convert.ToInt32(ViewState["Operation"]);
                }
                else
                {
                    objBELOpdReg.OperationId = 0;
                }
                if (txtRegistrationDate.Text != "")
                {
                    objBELOpdReg.RegisterDate = Convert.ToDateTime(txtRegistrationDate.Text.Trim());

                }
                objBELOpdReg.Address1 = txtaddress1.Text;
                objBELOpdReg.Address2 = txtaddress2.Text;

                if (Convert.ToInt32(rblPatcate.SelectedValue) > 1)
                {
                    objBELOpdReg.PaymentType = Convert.ToInt32(rblPaymentype.SelectedValue);
                    objBELOpdReg.PaymentRemark = txtpartpayment.Text;
                }
                else
                {
                    objBELOpdReg.PaymentType = Convert.ToInt32(0);
                    objBELOpdReg.PaymentRemark = "";
                }
                objBELOpdReg.DepositAmt = Convert.ToString(ViewState["DepositAmt"]);
                ViewState["IpdId"] = Convert.ToInt32(Request.QueryString["IpdId"]);
                returns = objDALIpdReg.UpdateIPDPatientRegistration(objBELOpdReg);
                Message = Convert.ToString(returns[0]);
                ShowMessage("Record update successfully!", MessageType.Success);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Record update.');", true);
            }
            else
            {
               
                if (txtRegNo.Text != "")
                {
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
                    objBELOpdReg.PatRegId = Convert.ToInt32(txtRegNo.Text);

                    //objBELOpdReg.PatMainTypeId = Convert.ToInt32(ddlPatientCategoryName.SelectedValue);
                    //objBELOpdReg.PatientInsuTypeId = Convert.ToInt32(ddlPatientSubCategoryName.SelectedValue);
                    //objBELOpdReg.PatientInsuTypeId2 = Convert.ToInt32(ddlPatientSubCategoryName2.SelectedValue);

                    objBELOpdReg.PatMainTypeId = Convert.ToInt32(rblPatcate.SelectedValue);
                    objBELOpdReg.PatientInsuTypeId = Convert.ToInt32(ViewState["PatientSubCategory"]);
                    objBELOpdReg.PatientInsuTypeId2 = Convert.ToInt32(ViewState["PatientSubCategory2"]);
                    objBELOpdReg.ChargeCompanyId = Convert.ToInt32(ViewState["PatientChargeSubCategory"]);

                    // objBELOpdReg.PrimaryDoc = Convert.ToInt32(ddlConsultantDoc.SelectedValue);
                    objBELOpdReg.PrimaryDoc = Convert.ToInt32(ViewState["ConsultID"]);
                    objBELOpdReg.SecodaryDoc = Convert.ToInt32(ViewState["SecondaryDr"]);
                    objBELOpdReg.ReferenceDrId = Convert.ToInt32(ddlRefDoctor.SelectedValue);
                    objBELOpdReg.Relation1 = Convert.ToInt32(ddlrealation1.SelectedValue);
                    objBELOpdReg.Relation2 = Convert.ToInt32(ddlrealation2.SelectedValue);
                    objBELOpdReg.Contact1 = Convert.ToString(txtContactNo1.Text);
                    objBELOpdReg.Contact2 = Convert.ToString(txtContactNo2.Text);
                    objBELOpdReg.ContactPerson1 = Convert.ToString(txtContactPerson1.Text);
                    objBELOpdReg.ContactPerson2 = Convert.ToString(txtContactPerson2.Text);
                    //objBELOpdReg.DeptId = Convert.ToInt32(ddlDepartment.SelectedValue);
                    objBELOpdReg.DeptId = Convert.ToInt32(ViewState["DeptID"]);
                    objBELOpdReg.BedId = Convert.ToInt32(Request.QueryString["BedId"]);
                    objBELOpdReg.IsAdmited = true;
                    objBELOpdReg.EntryTime = Convert.ToString(txtTime.Text);
                    objBELOpdReg.BranchId = Convert.ToInt32(Session["Branchid"]);
                    objBELOpdReg.FId = Convert.ToInt32(Session["FId"]);
                    objBELOpdReg.CreatedBy = Convert.ToString(Session["username"]);
                    objBELOpdReg.IsEmergency = Convert.ToBoolean(ChkEmergency.Checked);
                    objBELOpdReg.IsUniversalPrecaution = Convert.ToBoolean(ChkUni.Checked);
                    objBELOpdReg.Sponsor = txtsponsor.Text;
                    objBELOpdReg.Procedure = txtProcedure.Text;

                    objBELOpdReg.Address1 = txtaddress1.Text;
                    objBELOpdReg.Address2 = txtaddress2.Text;
                    objBELOpdReg.LetterNumber = txtletterNumber.Text;
                    objBELOpdReg.DepositAmt = Convert.ToString( ViewState["DepositAmt"]);
                    objBELOpdReg.RoomCategory = Convert.ToInt32(Request.QueryString["RoomType"]);
                    if (ddlSurgeryType.SelectedItem.Text != "Select Surgery")
                    {
                        objBELOpdReg.SurgeryType = Convert.ToString(ddlSurgeryType.SelectedItem.Text);
                    }
                    else
                    {
                        objBELOpdReg.SurgeryType = "";
                    }

                    if (txtsponsor.Text != "")
                    {
                        objBELOpdReg.DiseaseId = Convert.ToInt32(ViewState["DISEASE"]);
                    }
                    else
                    {
                        objBELOpdReg.DiseaseId = 0;
                    }
                    if (txtProcedure.Text != "")
                    {
                        objBELOpdReg.OperationId = Convert.ToInt32(ViewState["Operation"]);
                    }
                    else
                    {
                        objBELOpdReg.OperationId = 0;
                    }
                    if (txtRegistrationDate.Text != "")
                    {
                        objBELOpdReg.RegisterDate = Convert.ToDateTime(txtRegistrationDate.Text.Trim());

                    }
                    if (ChkInfant.Checked == true)
                    {
                        if (txtInfantaDOB.Text == "")
                        {
                            txtInfantaDOB.BorderColor = System.Drawing.Color.Red;
                            txtInfantaDOB.Focus();
                            return;
                        }
                        if (ddlGender.SelectedValue == "0")
                        {
                            ddlGender.Focus();
                            ddlGender.BorderColor = Color.Red;
                            ShowMessage("select  gender!", MessageType.Warning);
                            return ;
                        }
                        else
                        {
                            ddlGender.BorderColor = Color.White;
                        }
                        objBELOpdReg.Infant = 1;
                        objBELOpdReg.InfantDOB = txtInfantaDOB.Text;
                        objBELOpdReg.InfantGender = ddlGender.SelectedItem.Text; ;
                        objBELOpdReg.InfantRace = Convert.ToInt32( ddlRace.SelectedValue);
                        objBELOpdReg.InfantMotherIPDNO = Convert.ToInt32( ViewState["InfantIPDNO"]);
                        objBELOpdReg.InFantPatientName = txtPatientName.Text;
                    }
                    else
                    {
                        objBELOpdReg.Infant = 0;
                        objBELOpdReg.InfantDOB = "";
                        objBELOpdReg.InfantGender = "" ;
                        objBELOpdReg.InfantRace = Convert.ToInt32(0);
                        objBELOpdReg.InfantMotherIPDNO = Convert.ToInt32(ViewState["InfantIPDNO"]);
                    }
                    if (Convert.ToInt32(rblPatcate.SelectedValue) > 1)
                    {
                        objBELOpdReg.PaymentType = Convert.ToInt32(rblPaymentype.SelectedValue);
                        objBELOpdReg.PaymentRemark = txtpartpayment.Text;
                    }
                    else
                    {
                        objBELOpdReg.PaymentType = Convert.ToInt32(0);
                        objBELOpdReg.PaymentRemark = "";
                    }
                    if (objDALIpdReg.getallreadyRegister(DateTime.Now.AddMinutes(-2), txtRegNo.Text.Trim()))
                    {
                        objBELOpdReg.IpdNo = objDALIpdReg.GetMaxIpdNo(Convert.ToInt32(Session["FId"]));
                        returns = objDALIpdReg.InsertIPDPatientRegistration(objBELOpdReg);
                        ViewState["IpdId"] = Convert.ToInt32(returns[0]);
                        objBELOpdReg.RoomId = Convert.ToInt32(Request.QueryString["RoomId"]);
                        objBELOpdReg.IpdId = Convert.ToInt32(returns[0]);
                        if (Convert.ToInt32(ViewState["IpdId"]) > 0)
                        {
                            objDALIpdReg.InsertBedAllocationInfo(objBELOpdReg);
                            Message = Convert.ToString(returns[1]);

                            int BillNoT = objDALIpdReg.GetMaxIpdBillNo(Convert.ToInt32(Session["FId"]));
                            objBELOpdReg.BillNo = BillNoT + 1;
                            if (ChkInfant.Checked == true)
                            {
                                objBELOpdReg.InfantMotherIPDNO = Convert.ToInt32(ViewState["InfantIPDNO"]);
                                objBELOpdReg.Infant = 1;
                            }
                            else
                            {
                                objBELOpdReg.InfantMotherIPDNO = Convert.ToInt32(0);
                                objBELOpdReg.Infant = 0;
                            }
                             objDALIpdReg.InsertRoomCharges(objBELOpdReg);
                             if (Convert.ToString(Request.QueryString["ReferToAdmit"]) == "YES")
                             {
                                 ViewState["IpdId"] = Convert.ToInt32(returns[0]);
                                 objBELOpdReg.RoomId = Convert.ToInt32(Request.QueryString["RoomId"]);
                                 objBELOpdReg.IpdId = Convert.ToInt32(returns[0]);
                                 objBELOpdReg.OpdNo = Convert.ToInt32(Request.QueryString["OpdNo"]);
                                 objDALIpdReg.Insert_ReferToAdmissionData(objBELOpdReg);
                             }
                             else
                             {
                                 ViewState["IpdId"] = Convert.ToInt32(returns[0]);
                                 objBELOpdReg.RoomId = Convert.ToInt32(Request.QueryString["RoomId"]);
                                 objBELOpdReg.IpdId = Convert.ToInt32(returns[0]);
                                 objBELOpdReg.OpdNo = Convert.ToInt32(0);
                                 objDALIpdReg.Insert_ReferToAdmissionData(objBELOpdReg);
                             }
                            btnInsurance.Visible = true;
                            btnsave.Enabled = false;
                            ShowMessage("Record Save successfully!", MessageType.Success);
                            DynamicMessage(lblMessage, Message);
                            // ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Record saved.');", true);
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + Message + "');", true);
                        }
                        else
                        {
                            Message = Convert.ToString(returns[1]);
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + Message + "');", true);

                        }
                    }
                }
                else
                {
                    objBELOpdReg.PatRegId = Convert.ToInt32(0);
                }
            }
        }
       
             
    }
    protected void btnInsurance_Click(object sender, EventArgs e)
    {
        int IpdId = Convert.ToInt32(ViewState["IpdId"]);
        int patRegId = Convert.ToInt32(txtRegNo.Text);
        string url = "PatientInsuranceDetails.aspx?PatRegId=" + patRegId + "&IpdId=" + IpdId; // +"&voucherNo=" + voucherNo;
       
        string fullURL = "window.open('" + url + "','_blank','width=1000,height=450,left=100,top=50,resizable=yes,menubar=no')";
     
        //'width=1000,height=100,left=0,top=50,resizable=yes');";'popup_window'
        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", fullURL, true);
      
    }
    protected void btnPatCard_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        BLLReports objReports=new BLLReports();
        int IpdId = Convert.ToInt32(ViewState["IpdId"]);
        int FId=Convert.ToInt32(Session["FId"]);
        int BranchId=Convert.ToInt32(Session["Branchid"]);
        ReportDocument CrystalReport = new ReportDocument();
        CrystalReport.Load(Server.MapPath("~/Report/Rpt_IpdPatientCard.rpt"));
        ds=objReports.GetIpdPatientCard(IpdId,FId,BranchId);        
        CrystalReport.SetDataSource(ds);
        try
        {

            CrystalReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Employee");
        }
        catch (Exception ex)
        {
        }
        finally
        {
            CrystalReport.Close();
            ((IDisposable)CrystalReport).Dispose();
            GC.Collect();
            GC.SuppressFinalize(CrystalReport);
        }

    }
    protected void txtConsDoctorName_TextChanged(object sender, EventArgs e)
    {
        if (txtConsDoctorName.Text != "")
        {
            string[] PatientInfo = txtConsDoctorName.Text.Split('-');
            if (PatientInfo.Length > 1)
            {
                txtConsDoctorName.Text = PatientInfo[1];
                ViewState["ConsultID"] = PatientInfo[0];
                //ConsultantDrId = ddlConsDoctorName.SelectedValue.ToString();

                int BranchId = Convert.ToInt32(Session["Branchid"]);
                int FId = Convert.ToInt32(Session["FId"]);

                //string DeptId = objDALOpdReg.GetDeptId(Convert.ToInt32(ddlConsDoctorName.SelectedValue), FId, BranchId);
                string DeptId = objDALOpdReg.GetDeptId_WithName(Convert.ToInt32(ViewState["ConsultID"]), FId, BranchId);
                // ddlConsDoctorName
                //ddlDepartment.SelectedValue = DeptId;
                // ViewState["DeptID"] = DeptId;
                string[] DeptName = DeptId.Split('-');
                // ddlConsDoctorName
                //ddlDepartment.SelectedValue = DeptId;
                ViewState["DeptID"] = DeptName[0];
                txtdepartment.Text = DeptId;


            }
            else
            {
                txtConsDoctorName.Text = "";
            }
        }
    }
    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchConsultDoc(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        return objDALOpdReg.FillAllConsultDoc(prefixText);
    }
    protected void txtdepartment_TextChanged(object sender, EventArgs e)
    {
        if (txtdepartment.Text != "")
        {
            string[] PatientInfo = txtdepartment.Text.Split('-');
            if (PatientInfo.Length > 1)
            {
                txtdepartment.Text = PatientInfo[1];
                ViewState["DeptID"] = PatientInfo[0];

            }

        }
    }

    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchDepartment(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        return objDALOpdReg.FillAllDepartment(prefixText);
    }
    protected void btnpatientband_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        BLLReports objReports = new BLLReports();
        int IpdId = Convert.ToInt32(ViewState["IpdId"]);
        int FId = Convert.ToInt32(Session["FId"]);
        int BranchId = Convert.ToInt32(Session["Branchid"]);
        ReportDocument CrystalReport = new ReportDocument();
        CrystalReport.Load(Server.MapPath("~/Report/Rpt_IpdPatientBand.rpt"));
        ds = objReports.GetIpdPatientCard(IpdId, FId, BranchId);
        CrystalReport.SetDataSource(ds);
       // CrystalReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Employee");

        try
        {

            CrystalReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Employee");
        }
        catch (Exception ex)
        {
        }
        finally
        {
            CrystalReport.Close();
            ((IDisposable)CrystalReport).Dispose();
            GC.Collect();
            GC.SuppressFinalize(CrystalReport);
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {

    }
    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchProcedure(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        return objDALOpdReg.FillAllProcedure(prefixText);
    }
    protected void btnfrontsheetreport_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        BLLReports objReports = new BLLReports();
        int IpdId = Convert.ToInt32(ViewState["IpdId"]);
        int FId = Convert.ToInt32(Session["FId"]);
        int BranchId = Convert.ToInt32(Session["Branchid"]);
        ReportDocument CrystalReport = new ReportDocument();
        CrystalReport.Load(Server.MapPath("~/Report/Rpt_AdmissionFrontSheet.rpt"));
        ds = objReports.GetIpdPatientCard(IpdId, FId, BranchId);
        CrystalReport.SetDataSource(ds);

        try
        {

            CrystalReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Employee");
        }
        catch (Exception ex)
        {
        }
        finally
        {
            CrystalReport.Close();
            ((IDisposable)CrystalReport).Dispose();
            GC.Collect();
            GC.SuppressFinalize(CrystalReport);
        }
       
       
       
    }
    protected void txtsponsor_TextChanged(object sender, EventArgs e)
    {
        if (txtsponsor.Text != "")
        {
            string[] PatientInfo = txtsponsor.Text.Split('-');
            if (PatientInfo.Length == 2)
            {
                txtsponsor.Text = PatientInfo[1];
                ViewState["DISEASE"] = PatientInfo[0];
            }
            else
            {
                ViewState["DISEASE"] = "0";
            }
        }
        else
        {
            ViewState["DISEASE"] = "0";
            txtsponsor.BorderColor = Color.LightGray;
        }
    }
    protected void txtProcedure_TextChanged(object sender, EventArgs e)
    {
        if (txtProcedure.Text != "")
        {
            string[] PatientInfo = txtProcedure.Text.Split('-');
            if (PatientInfo.Length == 2)
            {
                txtProcedure.Text = PatientInfo[1];
                ViewState["Operation"] = PatientInfo[0];
            }
            else
            {
                ViewState["Operation"] = "0";

            }
        }
        else
        {
            ViewState["Operation"] = "0";
        }
    }
    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchDisease(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        // string Type = Convert.ToString(HttpContext.Current.Session["UID"]);
        string Type = "1";

        return objDALOpdReg.FillAllDisease(prefixText, Type);
    }
    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchOperaation(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        string Type = "1";
        return objDALOpdReg.FillAllOperation(prefixText, Type);
    }
    protected void btnChildrenband_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        BLLReports objReports = new BLLReports();
        int IpdId = Convert.ToInt32(ViewState["IpdId"]);
        int FId = Convert.ToInt32(Session["FId"]);
        int BranchId = Convert.ToInt32(Session["Branchid"]);
        ReportDocument CrystalReport = new ReportDocument();
        CrystalReport.Load(Server.MapPath("~/Report/Rpt_IpdChildBand.rpt"));
        ds = objReports.GetIpdPatientCard(IpdId, FId, BranchId);
        CrystalReport.SetDataSource(ds);
       // CrystalReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Employee");

        try
        {

            CrystalReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Employee");
        }
        catch (Exception ex)
        {
        }
        finally
        {
            CrystalReport.Close();
            ((IDisposable)CrystalReport).Dispose();
            GC.Collect();
            GC.SuppressFinalize(CrystalReport);
        }
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        
        if (Convert.ToString( ViewState["PatientInfoId"]) != "0")
        {

            if (FileUpload1.HasFile)
            {

                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                filename = "UID" + ViewState["PatientInfoId"] + "-" + filename;
                string filePath = "~/IPDPatientFiles/" + filename;
                FileUpload1.SaveAs(Server.MapPath(filePath));
                SqlConnection conn = DataAccess.ConInitForDC();
                conn.Open();


                SqlCommand cmd = new SqlCommand("Insert into IPDPatientFiles(PatRegId,FileName,Path) values(@PatRegId,@FileName,@Path)", conn);
                cmd.Parameters.AddWithValue("@Path", filePath);
                cmd.Parameters.AddWithValue("@PatRegId", Convert.ToInt32(ViewState["PatientInfoId"]));
                cmd.Parameters.AddWithValue("@filename", filename);
                //    conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                conn.Dispose();
                BindImages();
                //}  
                // }  
            }
        }
        else
        {
            lblMessage.Text = "Please Select Patient";
            return;
        }
      
    }
    
    protected void lnkDownload_Click(object sender, EventArgs e)
    {
        LinkButton lnkbtn = sender as LinkButton;
        GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;
        // this.RegisterPostBackControl();
        string filePath = gvImages.DataKeys[gvrow.RowIndex].Value.ToString();
        Response.ContentType = "image/jpg";
        Response.AddHeader("Content-Disposition", "attachment;filename=\"" + filePath + "\"");
        Response.TransmitFile(Server.MapPath(filePath));
        Response.End();
    }
    public void BindImages()
    {
        SqlConnection conn = DataAccess.ConInitForDC();
        conn.Open();

        using (SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM IPDPatientFiles where PatRegId=" + Convert.ToInt32(ViewState["PatientInfoId"]), conn))
        {
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                UploadedFiles.Visible = true;
                gvImages.DataSource = dt;
                gvImages.DataBind();
            }
            else
            {
                UploadedFiles.Visible = false;

            }

        }
        conn.Close();
        conn.Dispose();

    }
    protected void gvImages_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int FileId = Convert.ToInt32(gvImages.DataKeys[e.RowIndex]["FileId"]);

        SqlConnection conn = DataAccess.ConInitForDC();
        conn.Open();


        SqlCommand cmd = new SqlCommand("Delete  IPDPatientFiles where FileId=@FileId ", conn);
        cmd.Parameters.AddWithValue("@FileId", FileId);
        // cmd.Parameters.AddWithValue("@PatRegId", Convert.ToInt32(ViewState["PatientInfoId"]));
        /// cmd.Parameters.AddWithValue("@filename", filename);

        cmd.ExecuteNonQuery();
        conn.Close();
        conn.Dispose();
        // BindImages();

        //  string Message = objDALOpdReg.DeleteBillGroup(Convert.ToInt32(BillGroupId));

        // DynamicMessage(lblMessage, Message);

        BindImages();
    }
    protected void ddlSurgeryType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSurgeryType.SelectedItem.Text!="Select Surgery")
        {
            SqlConnection conn = DataAccess.ConInitForDC();
            conn.Open();
            DataTable dt = new DataTable();
            using (SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM SurgeryDepositDetails where RoomType=" + Request.QueryString["RoomType"] + " and  surgeryType='" + ddlSurgeryType.SelectedItem.Text+ "'" , conn))
            {
                
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    lblsurgeryType.Text = "Deposit Amount is:   " + dt.Rows[0]["DepositAmount"];
                    ViewState["DepositAmt"] = dt.Rows[0]["DepositAmount"];
                }
                else
                {
                    lblsurgeryType.Text = "";
                    ViewState["DepositAmt"] =0;

                }

            }
            conn.Close();
            conn.Dispose();
        }
        else
        {
            lblsurgeryType.Text = "";
        }

    }

    //================================================================================================

    protected void ddlPatientSubCategoryName1_TextChanged(object sender, EventArgs e)
    {
        if (Convert.ToString(ddlPatientSubCategoryName1.Text) != "")
        {
            if (ddlPatientSubCategoryName1.Text.Split('-').Length < 2)
            {
               // hfPatientId.Value = "0";
                ViewState["PatientSubCategory"] = "0";
            }
            else
            {
                string[] PatientInfo = ddlPatientSubCategoryName1.Text.Split('-');
                ddlPatientSubCategoryName1.Text = PatientInfo[1];
                ViewState["PatientSubCategory"] = PatientInfo[0];
                Session["LabPatientSubCategory"] = PatientInfo[0];
                ddlChargeSubCategory1.Text = "";
              //  txtcompdes.Text = "";
            }
        }
    }

    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchSubCategory(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        string PatientCategoryID = Convert.ToString(HttpContext.Current.Session["PatientCategoryID"]);
        return objDALOpdReg.FillAllSubCategoryName(prefixText, PatientCategoryID);
    }

    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchChargeSubCategory(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        string PatientCategoryID = Convert.ToString(HttpContext.Current.Session["LabPatientSubCategory"]);
        return objDALOpdReg.FillAllSubChargeCategoryName(prefixText, PatientCategoryID);
    }
    protected void ddlChargeSubCategory1_TextChanged(object sender, EventArgs e)
    {
        if (Convert.ToString(ddlChargeSubCategory1.Text) != "")
        {
            if (ddlChargeSubCategory1.Text.Split('-').Length < 2)
            {
               // hfPatientId.Value = "0";
                ViewState["PatientChargeSubCategory"] = "0";
            }
            else
            {
                string[] PatientInfo = ddlChargeSubCategory1.Text.Split('-');
                ddlChargeSubCategory1.Text = PatientInfo[1];
                ViewState["PatientChargeSubCategory"] = PatientInfo[0];


                //DataTable dt = new DataTable();
                //dt = objDALPatInfo.Get_ChildCompany_Description(Convert.ToInt32(ViewState["PatientChargeSubCategory"]));
                //if (dt.Rows.Count > 0)
                //{
                //    txtcompdes.Text = Convert.ToString(dt.Rows[0]["CompanyDescription"]);
                //}
                //else
                //{
                //    txtcompdes.Text = "";
                //}
            }
        }
        else
        {
            //txtcompdes.Text = "";
            ddlChargeSubCategory1.Text = "";
        }
    }

    protected void rblPatcate_SelectedIndexChanged(object sender, EventArgs e)
    {

        int PatientCategoryId = Convert.ToInt32(rblPatcate.SelectedValue);
        ViewState["PatientCategoryID"] = PatientCategoryId;
        Session["PatientCategoryID"] = PatientCategoryId;
        if (Convert.ToInt32(rblPatcate.SelectedValue) == 1)
        {
            ddlPatientSubCategoryName1.Text = "CASH";
            ViewState["PatientSubCategory"] = "1";
            ddlPatientSubCategoryName1.Enabled = false;
            ddlChargeSubCategory1.Enabled = false;
          
            ddlChargeSubCategory1.Text = "";
            txtInsurance2.Enabled = false;
           // txtcompdes.Text = "";
        }
        else
        {
            ddlPatientSubCategoryName1.Enabled = true;
            ddlChargeSubCategory1.Enabled = true;
            ddlPatientSubCategoryName1.Text = "";
            ViewState["PatientSubCategory"] = "";
          
            ddlPatientSubCategoryName1.Text = "";
            ddlChargeSubCategory1.Text = "";
            txtInsurance2.Enabled = true;
            PayType.Visible = true;
           // txtcompdes.Text = "";
        }
        LoadPatientSubCategoryName();
       
    }


    protected void txtInsurance2_TextChanged(object sender, EventArgs e)
    {
        if (Convert.ToString(txtInsurance2.Text) != "")
        {
            if (txtInsurance2.Text.Split('-').Length < 2)
            {
                // hfPatientId.Value = "0";
                ViewState["PatientSubCategory2"] = "0";
            }
            else
            {
                string[] PatientInfo = txtInsurance2.Text.Split('-');
                txtInsurance2.Text = PatientInfo[1];
                ViewState["PatientSubCategory2"] = PatientInfo[0];
                //Session["LabPatientSubCategory"] = PatientInfo[0];
                //ddlChargeSubCategory1.Text = "";
                //  txtcompdes.Text = "";
            }
        }
    }
    protected void ChkInfant_CheckedChanged(object sender, EventArgs e)
    {
        if (ChkInfant.Checked == true)
        {
            Infanta1.Visible = true;
            Infanta2.Visible = true;
            btnInfant.Visible = true;
            btnIPDBill.Visible = false;

                //objBELPatInfo = objDALPatInfo.SelectOne();
            if ( Convert.ToString( ViewState["PatientInfoId"]) == "")
            {
                ViewState["PatientInfoId"] = "0";
                string Message = "Select Patient!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + Message + "');", true);
                txtPatientName.Focus();
                return;
            }
                DataTable dtIPReg = new DataTable();
                dtIPReg = objDALPatInfo.Get_IpdRegistrationDetails(Convert.ToInt32(ViewState["PatientInfoId"]));
                if (dtIPReg.Rows.Count > 0)
                {
                    LblMsgAdmitDate.Text = Convert.ToString(Convert.ToDateTime(dtIPReg.Rows[0]["EntryDate"]).ToString("dd/MM/yyyy")) + "         " + Convert.ToString(dtIPReg.Rows[0]["EntryTime"]);
                    ViewState["InfantIPDNO"] = dtIPReg.Rows[0]["IpdNo"];
                    txtPatientName.Text = "InFant" + "  " + txtPatientName.Text;
                }
                else
                {
                  string   Message = "Patient is already discharged!";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + Message + "');", true);
                    txtPatientName.Text = "";
                    ViewState["PatientInfoId"] = "";
                }
            
        }
        else
        {
            Infanta1.Visible = false;
            Infanta2.Visible = false;
            btnInfant.Visible = false;
            ViewState["InfantIPDNO"] = "0";
        }
    }
    protected void btnInfant_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        BLLReports objReports = new BLLReports();
        int IpdId = Convert.ToInt32(ViewState["IpdId"]);
        int FId = Convert.ToInt32(Session["FId"]);
        int BranchId = Convert.ToInt32(Session["Branchid"]);
        ReportDocument CrystalReport = new ReportDocument();
        CrystalReport.Load(Server.MapPath("~/Report/Rpt_AdmissionFrontSheetInfant.rpt"));
        ds = objReports.GetIpdPatientCard(IpdId, FId, BranchId);
        CrystalReport.SetDataSource(ds);

        try
        {

            CrystalReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Employee");
        }
        catch (Exception ex)
        {
        }
        finally
        {
            CrystalReport.Close();
            ((IDisposable)CrystalReport).Dispose();
            GC.Collect();
            GC.SuppressFinalize(CrystalReport);
        }
       

    }

    protected void btnIPDBill_Click(object sender, EventArgs e)
    {
        //Response.Redirect("~/IpdBillForPatientServices.aspx?RegId=137555&IpdId=12", false);
        string response = @"~/IpdAdvancePayment.aspx?RegId=" + txtRegNo.Text + "&IpdId=" + ViewState["IpdId"];

        Response.Redirect(string.Format(response), false);
        return;
    }
    protected void txtsecondaryDr_TextChanged(object sender, EventArgs e)
    {
        if (txtsecondaryDr.Text != "")
        {

            string[] PatientInfo = txtsecondaryDr.Text.Split('-');
                if (PatientInfo.Length > 1)
                {
                    txtsecondaryDr.Text = PatientInfo[1];
                    ViewState["SecondaryDr"] = PatientInfo[0];
                }
                else
                {
                    txtsecondaryDr.Text = "";
                }
            
        }
    }

    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchSecondaryDoc(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        return objDALOpdReg.FillSecondaryDoc(prefixText);
    }
    protected void rblPaymentype_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt32(rblPaymentype.SelectedValue) == 3)
        {
            PartPay.Visible = true;
        }
        else
        {
            PartPay.Visible = false;
        }
    }
}