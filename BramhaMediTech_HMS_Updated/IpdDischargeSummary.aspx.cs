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

public partial class IpdDischargeSummary :BasePage
{
    DALIPDDesk ObjDALIpd = new DALIPDDesk();
    BELOPDPatReg objBELIpd = new BELOPDPatReg();
    BELBillInfo objBELBillInfo = new BELBillInfo();
    DALBillInfo objDALBillInfo = new DALBillInfo();
    BELRoom objBELRoom = new BELRoom();
    DALRoom objDALRoom = new DALRoom();
    BELOPDPatReg objBELOpdReg = new BELOPDPatReg();
    DALOpdReg objDALOpdReg = new DALOpdReg();
    BELBillDetails objBELBillDetail = new BELBillDetails();
    DALBillDetails objDALBillDetail = new DALBillDetails();

    double Billtotal = 0;
    string Message = "";
    int RegId, IpdId,BillNo;
    void Page_PreInit(Object sender, EventArgs e)
    {
        

            this.MasterPageFile = "~/mainMaster.master";
        
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //txtFromDate.Text = System.DateTime.Now.ToShortDateString();
            if (Convert.ToString( Request.QueryString["RegId"]) != null && Convert.ToString( Request.QueryString["RegId"]) != "" && Convert.ToString( Request.QueryString["IpdId"]) != "")
            {

                 RegId = Convert.ToInt32(Request.QueryString["RegId"]);
                 IpdId = Convert.ToInt32(Request.QueryString["IpdId"]);
                 BillNo = Convert.ToInt32(Request.QueryString["BillNo"]);
                // txtToDate.Text = System.DateTime.Now.ToShortDateString();
                GetprocedureDiagnosis();
                GetOptiRegisterDetails();
                FillIpdPatInfo(RegId, IpdId);
                FillDischargeSummary(RegId, IpdId);
                //BindBillDetails();
                Get_DischargeMedication(RegId, IpdId);
                Get_OnAdmissionDetails(RegId, IpdId);
            }
            else
            {
                 RegId = Convert.ToInt32(Session["EmrRegNo"]);
                 IpdId = Convert.ToInt32(Session["EmrIpdNo"]);
                 BillNo = Convert.ToInt32(Session["EmrBillNo"]);
                
                // txtToDate.Text = System.DateTime.Now.ToShortDateString();
                GetprocedureDiagnosis();
                GetOptiRegisterDetails();
                FillIpdPatInfo(RegId, IpdId);
                FillDischargeSummary(RegId, IpdId);
                Get_DischargeMedication(RegId, IpdId);
                Get_OnAdmissionDetails(RegId, IpdId);
            }
           
        }
        if (Convert.ToString(Session["Branchid"]) == null && Convert.ToString(Session["Branchid"]) == "" && Convert.ToString(Session["Branchid"]) == "0")
        {
            Server.Transfer("~/Login.aspx", true);
        }
        if (Convert.ToString(Request.QueryString["RegId"]) != null && Convert.ToString(Request.QueryString["RegId"]) != "" && Convert.ToString(Request.QueryString["IpdId"]) != "")
        {
            RegId = Convert.ToInt32(Request.QueryString["RegId"]);
            IpdId = Convert.ToInt32(Request.QueryString["IpdId"]);
            BillNo = Convert.ToInt32(Request.QueryString["BillNo"]);
        }
        else
        {
            RegId = Convert.ToInt32(Session["EmrRegNo"]);
            IpdId = Convert.ToInt32(Session["EmrIpdNo"]);
            BillNo = Convert.ToInt32(Session["EmrBillNo"]);
        }
    }

    public void GetprocedureDiagnosis()
    {
        DataTable dt=new DataTable();
        dt = objDALBillInfo.FillDiagnososAndProcedure(RegId, Convert.ToInt32(Session["FId"]), Convert.ToInt32(Session["Branchid"]), Convert.ToInt32(IpdId));
        if(dt.Rows.Count>0)
        {
           
             txtProcedure.Text = Convert.ToString( dt.Rows[0]["ProcedureName"]);
             txtProvDiagnosis.Text = Convert.ToString( dt.Rows[0]["Sponsor"]);   
        }
    }

    public void Get_OnAdmissionDetails(int PatregId, int IpdNo)
    {
        DataTable dt = new DataTable();
        dt = objDALBillInfo.Get_ONAdmissionDetails(RegId, Convert.ToInt32(Session["Branchid"]), Convert.ToInt32(IpdId));
        if (dt.Rows.Count > 0)
        {
            txtProvDiagnosis.Text = Convert.ToString( dt.Rows[0]["IPD_ProvDiagnosis"]);
            txtCaseSummary.Text = Convert.ToString(dt.Rows[0]["IPD_CaseSummary"]);
            txtComplaints.Text = Convert.ToString(dt.Rows[0]["IPD_Complaints"]);
            txtFinaldiagnosis.Text = Convert.ToString(dt.Rows[0]["IPD_FinalDiagnosis"]);
            txtonAdmissiondetails.Text = Convert.ToString(dt.Rows[0]["IPD_AdmisDetails"]);
            //for (int L = 0; L < dt.Rows.Count; L++)
            //{
                //txtTreatmentadvice.Text = txtTreatmentadvice.Text +" "+ Environment.NewLine + Convert.ToString(dt.Rows[L]["DrugName"]) + "  /  " + Convert.ToString(dt.Rows[L]["FrequencyType"]) + "  /  " + Convert.ToString(dt.Rows[L]["Days"])+"Days";
             
           // }
           
        }
    }
    public void Get_DischargeMedication(int PatregId,int IpdNo)
    {
        DataTable dt = new DataTable();
        dt = objDALBillInfo.Get_DischargeMedication(RegId, Convert.ToInt32(Session["Branchid"]), Convert.ToInt32(IpdId));
        if (dt.Rows.Count > 0)
        {
            for (int L = 0; L < dt.Rows.Count; L++)
            {
                txtTreatmentadvice.Text = txtTreatmentadvice.Text +" "+ Environment.NewLine + Convert.ToString(dt.Rows[L]["DrugName"]) + "  /  " + Convert.ToString(dt.Rows[L]["FrequencyType"]) + "  /  " + Convert.ToString(dt.Rows[L]["Days"])+"Days";
              // TextBox1.Text = “First Line” + Environment.NewLine + “Second Line” + Environment.NewLine + “Third Line”
            }
            // txtProvDiagnosis.Text = Convert.ToString(dt.Rows[0]["Sponsor"]);
        }
    }

    public void GetOptiRegisterDetails()
    {

        DataTable dt = new DataTable();

        using (SqlConnection con = DataAccess.ConInitForDC())
        {
            using (SqlCommand cmd = new SqlCommand("usp_GetIpdPatientOTRegister_PatientDetails", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FId", Convert.ToInt32(Session["FId"]));
                cmd.Parameters.AddWithValue("@BranchId", Convert.ToInt32(Session["Branchid"]));
                cmd.Parameters.AddWithValue("@PatRegId", Convert.ToInt32(RegId));
                cmd.Parameters.AddWithValue("@IPDNO", Convert.ToInt32(IpdId));
                con.Open();

                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(dt);
                }

                con.Close();
                con.Dispose();
            }

            if (dt.Rows.Count > 0)
            {
                txtSurgan.Text = Convert.ToString(dt.Rows[0]["SurganName"]);
                txtAnesthetist.Text = Convert.ToString(dt.Rows[0]["ANAESTHETISTName"]);
                
               // txtDISEASE.Text = Convert.ToString(dt.Rows[0]["DiseaseName"]);
                txtOperationnote.Text = Convert.ToString(dt.Rows[0]["OperationName"]);
               
            }


        }
    }
    public void FillDischargeSummary(int RegId, int IpdId)
    {
        BELBillInfo objBELBillInfo = new BELBillInfo();
        objBELIpd.IpdId = IpdId;
        objBELIpd.PatRegId = RegId;
        objBELIpd.FId = Convert.ToInt32(Session["FId"]);
        objBELIpd.BranchId = Convert.ToInt32(Session["Branchid"]);
        objBELIpd = ObjDALIpd.GetIpdPatientInformation(objBELIpd);
       // objDALBillInfo.SelectDischargeSummary(RegId, IpdId);
        objBELIpd = ObjDALIpd.SelectDischargeSummary(objBELIpd);

        if (Convert.ToString(objBELIpd.P_ProcedureDateT) != "01/01/1900 00:00:00" && Convert.ToString(objBELIpd.P_ProcedureDateT) != "01/01/0001 00:00:00")
        {
            txtFromDate.Text = Convert.ToString(objBELIpd.P_ProcedureDateT);

        }

            txtProcedure.Text = objBELIpd.P_Procedure;
            txtProvDiagnosis.Text = objBELIpd.P_ProvDiag;
            txtComplaints.Text = objBELIpd.P_Complant;

            txtCaseSummary.Text = objBELIpd.P_CaseSummary;
            txtFinaldiagnosis.Text = objBELIpd.P_FinalDiagnosis;

            txtSurgan.Text = objBELIpd.P_Surgan;

            txtotNote.Text = objBELIpd.P_OTNote;
            txtAnesthesia.Text = objBELIpd.P_Anesthesia;

            txtAnesthetist.Text = objBELIpd.P_Anesthetist;
            txtonAdmissiondetails.Text = objBELIpd.P_OnAdmissionDet;
            txttreatmentgiven.Text = objBELIpd.P_Treatment;
            txtConondischarge.Text = objBELIpd.P_ConDischarge;

            txtreasonfordischarge.Text = objBELIpd.P_ReasonDischarge;


            txtOperationnote.Text = objBELIpd.P_OperationNote;

            txtnextfollowup.Text = objBELIpd.P_NextFollowUp;

            txtTreatmentadvice.Text = objBELIpd.P_TreatmentAdvice;
            txtGeneralRemark.Text = objBELIpd.P_GeneralRemark;

        //}
       
    }
   
    public void FillIpdPatInfo(int RegId,int IpdId)
    {
        objBELIpd.IpdId = IpdId;
        objBELIpd.PatRegId = RegId;
        objBELIpd.FId = Convert.ToInt32(Session["FId"]);
        objBELIpd.BranchId = Convert.ToInt32(Session["Branchid"]);
        //objBELIpd = ObjDALIpd.GetIpdPatientInformation(objBELIpd);
        //lblPatCat.Text = Convert.ToString(objBELIpd.PatMainType);
        //lblPatientName.Text = Convert.ToString(objBELIpd.PatientName);
        //lblAdmissionDate.Text = Convert.ToString(objBELIpd.EntryDate);
        //lblIpd.Text = Convert.ToString(objBELIpd.IpdNo);
        //lblPatRegId.Text = Convert.ToString(objBELIpd.PatRegId);
        //lblBillNo.Text = Convert.ToString(BillNo);//BillNo

        //lblRoomName.Text = Convert.ToString(objBELIpd.RoomName);
        //lbldrname.Text = Convert.ToString(objBELIpd.DRName);
        //LblRoomType.Text = Convert.ToString(objBELIpd.RType);
        //lblBedName.Text = Convert.ToString(objBELIpd.BedName);

        //Label2.Text = Convert.ToString(objBELIpd.Diagnosis);
        //Label4.Text = Convert.ToString(objBELIpd.ProcedureName);
        //Label6.Text = Convert.ToString(objBELIpd.PatientInsuType);
        //Label8.Text = Convert.ToString(objBELIpd.Sponsor2);
        //lblvisitno.Text = Convert.ToString(objBELIpd.VisitingNo);
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
        if (Convert.ToString(Session["EmrIpdNo"]) != "")
        {
            if (Convert.ToString(Session["PatAdmit"]) == "No")
            {
                lblvalidate.ForeColor = System.Drawing.Color.Red;
                lblvalidate.Text = "Patient already discharge!";
                return;
            }
        }
        objBELBillDetail.BranchId = Convert.ToInt32(Session["Branchid"]);

        objBELBillDetail.PatRegId = Convert.ToInt32(RegId);
        objBELBillDetail.IpdNo = Convert.ToInt32(IpdId);
        objBELBillDetail.BillNo = Convert.ToInt32(BillNo);
        objBELBillDetail.CreatedBy = Convert.ToString(Session["username"]);
        InsertInBill();
      
        lblvalidate.Text = "Record save successfully.!";
       // BtnDischarge.Visible = true;

    }
    
    protected void btnReset_Click(object sender, EventArgs e)
    {

    }
  
    public void Clear()
    {
        
    }
  
  
    
    protected void btnReport_Click(object sender, EventArgs e)
    {
        string sql = "";

        BLLReports objreports = new BLLReports();
        //int IpdId = Convert.ToInt32(IpdId);
        int PatRegId = Convert.ToInt32(RegId);
        int BranchId = Convert.ToInt32(Session["Branchid"]);
        int FId = Convert.ToInt32(Session["FId"]);
        AlterView_VE_GetLabNo(Convert.ToString( IpdId));
        //VW_DescriptiveViewLogic.SP_Getresultnondesc_Report(Convert.ToInt32(Session["Branchid"]), ViewTestCode, Request.QueryString["PatRegID"], Request.QueryString["FID"]);
       // SP_Getresultnondesc_Report();
       // SP_Getresultnondesc_Report(BranchId,Convert.ToString( Request.QueryString["IpdId"]),Convert.ToString(Session["FId"]));
       // SP_Getresultdesc_Report(BranchId, Convert.ToString(Request.QueryString["IpdId"]), Convert.ToString(Session["FId"]));
        objreports.IpdDischrge_Summary_Report(IpdId, PatRegId, FId, BranchId);
       

        Session.Add("rptsql", sql);
       // Session["rptname"] = Server.MapPath("~/Reports/Rpt_DischargeSummaryReport.rpt");
        Session["rptname"] = Server.MapPath("~/Reports/Rpt_DischargeSummaryReport.rpt");
        Session["reportname"] = "DischargeSummaryReport";
        Session["RPTFORMAT"] = "pdf";


        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);


    }

    public static int SP_Getresultnondesc_Report(int branchid,  string IPDNO, string FID)
    {
        int i = 0;
        SqlConnection conn = DataAccess.ConInitForPathology();
        SqlCommand sc = new SqlCommand();
        sc.Connection = conn;
        sc.CommandType = CommandType.StoredProcedure;
        sc.CommandText = "SP_phdatarecfrm_HMS";
        sc.Parameters.AddWithValue("@branchid", branchid);

        sc.Parameters.AddWithValue("@PatRegID", IPDNO);
        sc.Parameters.AddWithValue("@FID", FID);
        try
        {
            conn.Open();
            sc.ExecuteNonQuery();
        }
        catch
        {
            throw;
        }
        finally
        {
            conn.Close();
            conn.Dispose();
        }
        return i;
    }
    public static int SP_Getresultdesc_Report(int branchid, string IPDNO, string FID)
    {
        int i = 0;
        SqlConnection conn = DataAccess.ConInitForPathology();
        SqlCommand sc = new SqlCommand();
        sc.Connection = conn;
        sc.CommandType = CommandType.StoredProcedure;
        sc.CommandText = "SP_phraddata_HMS";
        sc.Parameters.AddWithValue("@branchid", branchid);

        sc.Parameters.AddWithValue("@PatRegID", IPDNO);
        sc.Parameters.AddWithValue("@FID", FID);
        try
        {
            conn.Open();
            sc.ExecuteNonQuery();
        }
        catch
        {
            throw;
        }
        finally
        {
            conn.Close();
            conn.Dispose();
        }
        return i;
    }

    public void AlterView_VE_GetLabNo(string IPDNO)
    {
        int i;
        SqlConnection conn = DataAccess.ConInitForPathology();
        SqlCommand sc = conn.CreateCommand();
        sc.CommandText = "ALTER VIEW [dbo].[VW_GetLabNo]AS (select  LabNo,patmst.PatRegID,MTCode,patmst.Branchid,patmst.FID FROM   patmstd INNER JOIN patmst ON patmstd.PatRegID = patmst.PatRegID AND patmstd.PID = patmst.PID  where  patmst.IPDNO='" + IPDNO + "'  and patmst.branchid ='" + Convert.ToInt32(Session["Branchid"]) + "' and  patmst.FID ='" + Convert.ToString(Session["FId"]) + "' )";
        try
        {
            conn.Open();
            sc.ExecuteNonQuery();

        }
        catch (Exception exx)
        { }
        finally
        {
            try
            {

                conn.Close();
                conn.Dispose();
            }
            catch (SqlException)
            {
                // Log an event in the Application Event Log.
                throw;
            }

        }




    }
    
    private void InsertInBill()
    {
        object[] returns;
        string Message = "";
        BELBillInfo objBELBillInfo = new BELBillInfo();

        //int BillNo = objDALBillInfo.GetMaxBillNo(Convert.ToInt32(Session["FId"]));
        //objBELBillInfo.BillNo = BillNo + 1;
        //ViewState["BillNo"] = objBELBillInfo.BillNo;

        objBELBillInfo.BillNo = Convert.ToInt32(BillNo);
        ViewState["BillNo"] = objBELBillInfo.BillNo;


        objBELBillInfo.PatRegId = Convert.ToInt32(RegId);
        objBELBillInfo.BillDate = System.DateTime.Now;
        objBELBillInfo.IpdId = Convert.ToInt32(IpdId);
        objBELBillInfo.IpdNo = Convert.ToInt32(IpdId);
        

        objBELBillInfo.CreatedBy = Convert.ToString(Session["username"]);
        if (txtFromDate.Text != "")
        {
            objBELBillInfo.P_ProcedureDate = (Convert.ToDateTime(txtFromDate.Text).ToShortDateString());
        }
        if (txtProcedure.Text != "")
        {
            objBELBillInfo.P_Procedure = txtProcedure.Text;
        }
        else
            objBELBillInfo.P_Procedure = "";

        if (txtProvDiagnosis.Text != "")
        {
            objBELBillInfo.P_ProvDiag = txtProvDiagnosis.Text;
        }
        else
            objBELBillInfo.P_ProvDiag = "";

        if (txtComplaints.Text != "")
        {
            objBELBillInfo.P_Complant = txtComplaints.Text;
        }
        else
            objBELBillInfo.P_Complant = "";

        if (txtCaseSummary.Text != "")
        {
            objBELBillInfo.P_CaseSummary = txtCaseSummary.Text;
        }
        else
            objBELBillInfo.P_CaseSummary = "";

        if (txtFinaldiagnosis.Text != "")
        {
            objBELBillInfo.P_FinalDiagnosis = txtFinaldiagnosis.Text;
        }
        else
            objBELBillInfo.P_FinalDiagnosis = "";

        if (txtSurgan.Text != "")
        {
            objBELBillInfo.P_Surgan = txtSurgan.Text;
        }
        else
            objBELBillInfo.P_Surgan = "";

        if (txtotNote.Text != "")
        {
            objBELBillInfo.P_OTNote = txtotNote.Text;
        }
        else
            objBELBillInfo.P_OTNote = "";

        if (txtAnesthesia.Text != "")
        {
            objBELBillInfo.P_Anesthesia = txtAnesthesia.Text;
        }
        else
            objBELBillInfo.P_Anesthesia = "";

        if (txtAnesthetist.Text != "")
        {
            objBELBillInfo.P_Anesthetist = txtAnesthetist.Text;
        }
        else
            objBELBillInfo.P_Anesthetist = "";

        if (txtonAdmissiondetails.Text != "")
        {
            objBELBillInfo.P_OnAdmissionDet = txtonAdmissiondetails.Text;
        }
        else
            objBELBillInfo.P_OnAdmissionDet = "";

        if (txttreatmentgiven.Text != "")
        {
            objBELBillInfo.P_Treatment = txttreatmentgiven.Text;
        }
        else
            objBELBillInfo.P_Treatment = "";

        if (txtConondischarge.Text != "")
        {
            objBELBillInfo.P_ConDischarge = txtConondischarge.Text;
        }
        else
            objBELBillInfo.P_ConDischarge = "";

        if (txtreasonfordischarge.Text != "")
        {
            objBELBillInfo.P_ReasonDischarge = txtreasonfordischarge.Text;
        }
        else
            objBELBillInfo.P_ReasonDischarge = "";

        if (txtOperationnote.Text != "")
        {
            objBELBillInfo.P_OperationNote = txtOperationnote.Text;
        }
        else
            objBELBillInfo.P_OperationNote = "";

        if (txtnextfollowup.Text != "")
        {
            objBELBillInfo.P_NextFollowUp = txtnextfollowup.Text;
        }
        else
            objBELBillInfo.P_NextFollowUp = "";

        if (txtTreatmentadvice.Text != "")
        {
            objBELBillInfo.P_TreatmentAdvice = txtTreatmentadvice.Text;
        }
        else
            objBELBillInfo.P_TreatmentAdvice = "";

        if (txtGeneralRemark.Text != "")
        {
            objBELBillInfo.P_GeneralRemark = txtGeneralRemark.Text;
        }
        else
            objBELBillInfo.P_GeneralRemark = "";

       
      
        objBELBillInfo.CreatedBy = Convert.ToString(Session["username"]);
        objBELBillInfo.BranchId = Convert.ToInt32(Session["Branchid"]);
        objBELBillInfo.FId = Convert.ToInt32(Session["FId"]);

        objDALBillInfo.InsertIPDBDischargeSummary(objBELBillInfo);
        //ViewState["BillPaymentId"] = Convert.ToInt32(returns[0]);

    }

    [WebMethod]
    public static List<string> GetDrugsName(string prefixText)
    {
        clsTreatment objj = new clsTreatment();
        DataTable dt = objj.GetDrugsMaster(prefixText,"Drug",0);
        List<string> list = new List<string>();

        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["drug"] != DBNull.Value)
                    {
                        list.Add(Convert.ToString(dt.Rows[i]["drug"]));
                    }
                }
            }
        }

        return list;
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        if (txtDrugName.Text != "")
        {
            if (txtdays.Text == "")
            {
                txtdays.Text = "0";
                
            }
            if (txtdays.Text != "0")
            {
                if (txtTreatmentadvice.Text == "")
                {
                    txtTreatmentadvice.Text = txtDrugName.Text + "  /  " + drpfrequency.SelectedItem.Text + "  /  " + txtdays.Text;
                }
                else
                {
                    txtTreatmentadvice.Text = txtTreatmentadvice.Text + "  " + txtDrugName.Text + "  /  " + drpfrequency.SelectedItem.Text + "  /  " + txtdays.Text;
                }
            }
        }
    }
}