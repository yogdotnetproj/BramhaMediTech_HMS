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

public partial class SurgeryQuatationByDoctor :BasePage
{
    clsEmr obj = new clsEmr();
    clsTreatment objTreat = new clsTreatment();
    clsTreatmentTransaction transaction = new clsTreatmentTransaction();
    DALBillDetails objDALBillDetail = new DALBillDetails();

   
  
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if (Session["EmrRegNo"] != "")
            {
                string regId = Convert.ToString(Session["EmrRegNo"]);
                string name = Request.QueryString["Name"];
                string opd = Convert.ToString(Session["EmrOpdNo"]);
                string entrydate = Request.QueryString["EntryDate"];
                Session["Branchid"] = "1";
               // lblOpd.Text = opd;
                PindPatientInformation();
                FindPatientInformation();

               
                

            }
            else
            {
                Response.Redirect(string.Format("ListPatients.aspx"));
            }
        }
        
    }
    public void FindPatientInformation()
    {
        DataTable dt = new DataTable();
        dt = obj.Get_SurgeryQuotationByDoc(Convert.ToInt32(Session["EmrRegNo"]), Convert.ToInt32(Session["EmrOpdNo"]), Convert.ToInt32( Session["EmrIpdNo"]), Convert.ToInt32(Session["Branchid"]));
        try
        {
            if (dt != null)
            {
                txtHospStay.Text=Convert.ToString(dt.Rows[0]["HospitalStay"]);
                txtOTTime.Text=Convert.ToString(dt.Rows[0]["OTTime"]);
                txtASA.Text=Convert.ToString(dt.Rows[0]["ASA"]);
                txtprocedure.Text=Convert.ToString(dt.Rows[0]["OperationName"]);
                txtSurgeonName.Text=Convert.ToString(dt.Rows[0]["SurgeonName"]);
                txtSpeInv.Text=Convert.ToString(dt.Rows[0]["SpecialInvestigation"]);
                txtSurgeonFee.Text = Convert.ToString(dt.Rows[0]["SurgeonsFee"]);  

              
            }

        }
        catch (Exception ex)
        {

        }
    }

    public void PindPatientInformation()
    {
        DataTable dt = new DataTable();
        dt = obj.Get_AllPatientInformation(Convert.ToString(Session["EmrRegNo"]), Convert.ToString(Session["EmrOpdNo"]), Convert.ToInt32(Session["EmrIpdNo"]), Convert.ToInt32(Session["Branchid"]));
        try
        {
            if (dt != null)
            {
                //lblPatientName.Text = Convert.ToString(dt.Rows[0]["PatientName"]);
                //txtpatientregid.Text = Convert.ToString(dt.Rows[0]["PatRegId"]);
                //lblIpd.Text = Convert.ToString(dt.Rows[0]["Ipdno"]);
                //lblOpd.Text = Convert.ToString(dt.Rows[0]["OpdNo"]);
                //lblMobileNo.Text = Convert.ToString(dt.Rows[0]["MobileNo"]);
                //lbldrname.Text = Convert.ToString(dt.Rows[0]["DrName"]);
                ViewState["DrId"] = Convert.ToInt32(dt.Rows[0]["DrId"]);
                ViewState["drname"] = Convert.ToString(dt.Rows[0]["DrId"]);
               // lblAge.Text = Convert.ToString(dt.Rows[0]["Age"]) + "" + Convert.ToString(dt.Rows[0]["AgeType"]) + "/" + Convert.ToString(dt.Rows[0]["GenderName"]);

            }
            //dt=new DataTable ();
            //dt = obj.Get_AllPatientVitalTaken(Convert.ToString(Session["EmrRegNo"]), Convert.ToString(Session["EmrOpdNo"]), Convert.ToInt32(Session["EmrIpdNo"]), Convert.ToInt32(Session["Branchid"]));
            //if (dt.Rows.Count > 0)
            //{
            //    lblvtaken.Text = Convert.ToString( dt.Rows[0]["CreatedOn"]);
            //}
        }
        catch (Exception ex)
        {

        }
    }


    [ScriptMethod()]
    [WebMethod]
    public static List<string> Searchsurgan(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        return objDALOpdReg.FillAllSurgan(prefixText);
    }

    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchOperaation(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        string Type = "1";
        return objDALOpdReg.FillAllOperation(prefixText, Type);
    }

    
    [WebMethod]
    public static List<string> GetDrugsName(string prefixText)
    {
        clsTreatment objj = new clsTreatment();
        string Type = Convert.ToString(HttpContext.Current.Session["UID"]);

        DataTable dt = objj.GetDrugsMasterEmergency(prefixText,Type);
        List<string> list = new List<string>();

        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["Drug"] != DBNull.Value)
                    {
                        list.Add(Convert.ToString(dt.Rows[i]["Drug"]));
                    }
                }
            }
        }

        return list;
    }

    [WebMethod]
    public static List<string> GetPatientIds(string prefixText)
    {
        clsTreatment objj = new clsTreatment();
        DataTable dt = objj.GetPatientIds(prefixText);
        List<string> list = new List<string>();

        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["ids"] != DBNull.Value)
                    {
                        list.Add(Convert.ToString(dt.Rows[i]["ids"]));
                    }
                }
            }
        }

        return list;
    }
    protected void drpfrequency_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        try
        {
           
            Clear();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        
    }

   
   

    private void Clear()
    {
        txtHospStay.Text = "";
        txtASA.Text = "";
        txtOTTime.Text = "";
        txtprocedure.Text = "";
        txtSpeInv.Text = "";
        txtSurgeonFee.Text = "";
        txtSurgeonName.Text = "";

       
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        btnClear_Click(null, null);
        Clear();
        
    }







    protected void btnReset_Click(object sender, EventArgs e)
    {
        Clear();

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        BELBillDetails objBELBillDetail = new BELBillDetails();
        string Message = "";


        objBELBillDetail.PatRegId = Convert.ToInt32(Session["EmrRegNo"]);
        objBELBillDetail.IpdNo = Convert.ToInt32(Session["EmrIpdNo"]);
        objBELBillDetail.OpdNo = Convert.ToInt32(Session["EmrOpdNo"]);
        objBELBillDetail.ConsultantDrId = Convert.ToInt32(ViewState["DrId"]);
        objBELBillDetail.ConsultantDoc = Convert.ToString(ViewState["drname"]);
            

        objBELBillDetail.Surgan = Convert.ToInt32(ViewState["SurganID"]);
        objBELBillDetail.OperationName = Convert.ToString(txtprocedure.Text.Trim());
        objBELBillDetail.SurgeonName = Convert.ToString(txtSurgeonName.Text);     

       
        if (txtprocedure.Text != "")
        {
            objBELBillDetail.Operation = Convert.ToInt32(ViewState["Operation"]);
        }
        else
        {
            objBELBillDetail.Operation = 0;
        }
        if (txtOTTime.Text != "")
            objBELBillDetail.OTTime = txtOTTime.Text;
        else
            objBELBillDetail.OTTime = "";
        if (txtSurgeonFee.Text != "")
        {
            objBELBillDetail.SurgeonsFee = txtSurgeonFee.Text;
        }
        else
        {
            objBELBillDetail.SurgeonsFee = "";
        }
        if (txtSpeInv.Text != "")
        {
            objBELBillDetail.SpecialInvestigation = txtSpeInv.Text;
        }
        else
        {
            objBELBillDetail.SpecialInvestigation = "";
        }
        if (txtASA.Text != "")
            objBELBillDetail.ASA = txtASA.Text;
        else
            objBELBillDetail.ASA = "";
        if (txtHospStay.Text != "")
            objBELBillDetail.HospitalStay = txtHospStay.Text;
        else
            objBELBillDetail.HospitalStay = "";


        objBELBillDetail.CreatedBy = Convert.ToString(Session["username"]);
        objBELBillDetail.BranchId = Convert.ToInt32(Session["Branchid"]);

        objBELBillDetail.FId = Convert.ToInt32(Session["FId"]);



        Message = objDALBillDetail.InsertSurgeryQuoteByDoc(objBELBillDetail);
        lblMsg.Text = "Record saved Successfully..";
        Clear();

    }
    protected void txtprocedure_TextChanged(object sender, EventArgs e)
    {
        if (txtprocedure.Text != "")
        {
          string[] PatientInfo = txtprocedure.Text.Split('-');
            if (PatientInfo.Length == 2)
            {
                txtprocedure.Text = PatientInfo[1];
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
    protected void txtSurgeonName_TextChanged(object sender, EventArgs e)
    {
        if (txtSurgeonName.Text != "")
        {
            string[] PatientInfo = txtSurgeonName.Text.Split('-');
            if (PatientInfo.Length > 1)
            {
                txtSurgeonName.Text = PatientInfo[1];
                ViewState["SurganID"] = PatientInfo[0];
                txtSurgeonName.BorderColor = Color.LightGray;
            }
            else
            {
                ViewState["SurganID"] = "0";
            }
        }
        else
        {
            ViewState["SurganID"] = "0";
        }
    }
    
}