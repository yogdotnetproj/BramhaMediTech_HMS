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

public partial class IPD_AdmissionSheet :BasePage
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

    BELIntakeOutputChart objBELIO = new BELIntakeOutputChart();
    DALInputOutPutChart objDALIO = new DALInputOutPutChart();

    double Billtotal = 0;
    string Message = "";
    int RegId, IpdId,BillNo;
  
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SetInitialRow();
            //txtFromDate.Text = System.DateTime.Now.ToShortDateString();
            if (Convert.ToString( Request.QueryString["RegId"]) != null && Convert.ToString( Request.QueryString["RegId"]) != "" && Convert.ToString( Request.QueryString["IpdId"]) != "")
            {

                 RegId = Convert.ToInt32(Request.QueryString["RegId"]);
                 IpdId = Convert.ToInt32(Request.QueryString["IpdId"]);
                 BillNo = Convert.ToInt32(Request.QueryString["BillNo"]);
                // txtToDate.Text = System.DateTime.Now.ToShortDateString();
              
                //FillIpdPatInfo(RegId, IpdId);
                FillDischargeSummary(RegId, IpdId);
                BindAllergise(RegId);
            }
            else
            {
                 RegId = Convert.ToInt32(Session["EmrRegNo"]);
                 IpdId = Convert.ToInt32(Session["EmrIpdNo"]);
                 BillNo = Convert.ToInt32(Session["EmrBillNo"]);
                
                // txtToDate.Text = System.DateTime.Now.ToShortDateString();
              
               // FillIpdPatInfo(RegId, IpdId);
                FillDischargeSummary(RegId, IpdId);
                BindAllergise(RegId);
                
            }
            BindDailyNurseNotes();
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



    public void Get_TReatment_Details(int Patregid, int IPDNo)
    {

        DataTable dt = new DataTable();

        using (SqlConnection con = DataAccess.ConInitForDC())
        {
            using (SqlCommand cmd = new SqlCommand("Usp_OnIPD_AdmissionChild", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@PatRegId", Convert.ToInt32(Session["EmrRegNo"]));
                cmd.Parameters.AddWithValue("@IPDNo", Convert.ToInt32(IPDNo));
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
                GvHairLaser.DataSource = dt;
                GvHairLaser.DataBind();
                ViewState["CurrentTable"] = dt;

            }
            else
            {
                SetInitialRow();
            }


        }
    }
   
    public void FillDischargeSummary(int RegId, int IpdId)
    {
        BELBillInfo objBELBillInfo = new BELBillInfo();
        objBELIpd.IpdId = IpdId;
        objBELIpd.IpdNo = IpdId;
        objBELIpd.PatRegId = RegId;
        objBELOpdReg.IpdId = IpdId;
        objBELOpdReg.PatRegId = RegId;
       // objBELIpd
        objBELIpd.FId = Convert.ToInt32(Session["FId"]);
        objBELIpd.BranchId = Convert.ToInt32(Session["Branchid"]);
        //objBELIpd = ObjDALIpd.GetIpdPatientInformation(objBELIpd);
       // objDALBillInfo.SelectDischargeSummary(RegId, IpdId);
        objBELIpd = ObjDALIpd.Select_IPDAdmissionSheet(objBELIpd);  
        //=============================================================================

        txtComplaints.Text = objBELIpd.P_IPD_Complaints;

        txtonAdmission.Text = objBELIpd.P_IPD_OnAdmisDetails;

        txtcasesummary.Text = objBELIpd.P_IPD_CaseSummary;

        txtProvDiagnosis.Text = objBELIpd.P_IPD_ProvDiagnosis;
        txtFinalDiagnosis.Text = objBELIpd.P_IPD_FinalDiagnosis;

        txtHistory.Text = objBELIpd.P_IPD_History;
        txtTemp.Text = objBELIpd.P_IPD_Temp;
        txtResp.Text = objBELIpd.P_IPD_Resp;

        txtheight.Text = objBELIpd.P_IPD_Height;
        txtpulse.Text = objBELIpd.P_IPD_pulse;
        txtBP.Text = objBELIpd.P_IPD_BP;

        txtweight.Text = objBELIpd.P_IPD_weight;
        txtAlbumin.Text = objBELIpd.P_IPD_Albumin;
        txtsugar.Text = objBELIpd.P_IPD_sugar;

        txtBlood.Text = objBELIpd.P_IPD_Blood;
       //----------------------------------------

        rblCulture.SelectedValue=objBELIpd.P_foodpreferences;
       txtdescribe.Text= objBELIpd.P_Describe ;

       rblBpType.SelectedValue = objBELIpd.P_BpType;

       txtlastpoIntake.Text=objBELIpd.P_lastpoIntake;
       if (Convert.ToString(objBELIpd.P_lastpodateintake) != "01/01/1753 00:00:00")
       txtlastpodateintake.Text=Convert.ToString( objBELIpd.P_lastpodateintake) ;

        txtlasttimepointak.Text=objBELIpd.P_lasttimepointak;
        if(Convert.ToString(objBELIpd.P_lastvoidedurinedate)!="01/01/1753 00:00:00")
        txtlastvoidedurinedate.Text = Convert.ToString(objBELIpd.P_lastvoidedurinedate);

        txtlastvoidedurinetime.Text = objBELIpd.P_lastvoidedurinetime;
        if (Convert.ToString(objBELIpd.P_lastbowelmovementdate) != "01/01/1753 00:00:00")
       txtlastbowelmovementdate.Text = Convert.ToString(objBELIpd.P_lastbowelmovementdate);

       txtlastbowelmovementtime.Text = objBELIpd.P_lastbowelmovementtime;
       RblVision.SelectedValue = objBELIpd.P_Vision;
       rblHearing.SelectedValue= objBELIpd.P_Hearing ;
       RblSpeech.SelectedValue = objBELIpd.P_Speech;
       rblAmbulation.SelectedValue= objBELIpd.P_Ambulation ;
       rbldeclaration.SelectedValue= objBELIpd.P_Declaration ;
       txtrelativename.Text= objBELIpd.P_RelativeName ;
       if (Convert.ToString(objBELIpd.P_RelativeDate) != "01/01/1753 00:00:00")
          txtrelativedate.Text= Convert.ToString(  objBELIpd.P_RelativeDate);

          txtwitnessname.Text= objBELIpd.P_WitnessName;

          if (Convert.ToString(objBELIpd.P_WitnessDate) != "01/01/1753 00:00:00")
           txtwitnessdate.Text= Convert.ToString( objBELIpd.P_WitnessDate);

           if (objBELIpd.P_Awake == true)
           {
               ChkAwake.Checked = true;
           }
           else
           {
               ChkAwake.Checked = false;
           }
           if (objBELIpd.P_Alert == true)
           {
               ChkAlert.Checked = true;
           }
           else
           {
               ChkAlert.Checked = false;
           }
           if (objBELIpd.P_Oriented == true)
           {
               ChkOriented.Checked = true;
           }
           else
           {
               ChkOriented.Checked = false;
           }
           if (objBELIpd.P_Lethargic == true)
           {
               ChkLethargic.Checked = true;
           }
           else
           {
               ChkLethargic.Checked = false;
           }
           if (objBELIpd.P_Disoriented == true)
           {
               ChkDisoriented.Checked = true;
           }
           else
           {
               ChkDisoriented.Checked = false;
           }
           if (objBELIpd.P_Comatose == true)
           {
               ChkComatose.Checked = true;
           }
           else
           {
               ChkComatose.Checked = false;
           }

           txtsurgicalHistory.Text = objBELIpd.P_surgicalHistory;
           txtFamilyHistory.Text=objBELIpd.P_FamilyHistory;
           txtWound.Text = objBELIpd.P_Wound;
           txtwouldsize.Text=objBELIpd.P_WoundSize;
       
    }
   
    //public void FillIpdPatInfo(int RegId,int IpdId)
    //{
    //    objBELIpd.IpdId = IpdId;
    //    objBELIpd.PatRegId = RegId;
    //    objBELIpd.FId = Convert.ToInt32(Session["FId"]);
    //    objBELIpd.BranchId = Convert.ToInt32(Session["Branchid"]);
    //    objBELIpd = ObjDALIpd.GetIpdPatientInformation(objBELIpd);
    //    lblPatCat.Text = Convert.ToString(objBELIpd.PatMainType);
    //    lblPatientName.Text = Convert.ToString(objBELIpd.PatientName);
    //    lblAdmissionDate.Text = Convert.ToString(objBELIpd.EntryDate);
    //    lblIpd.Text = Convert.ToString(objBELIpd.IpdNo);
    //    lblPatRegId.Text = Convert.ToString(objBELIpd.PatRegId);
    //    lblBillNo.Text = Convert.ToString(BillNo);//BillNo

    //    lblRoomName.Text = Convert.ToString(objBELIpd.RoomName);
    //    lbldrname.Text = Convert.ToString(objBELIpd.DRName);
    //    LblRoomType.Text = Convert.ToString(objBELIpd.RType);
    //    lblBedName.Text = Convert.ToString(objBELIpd.BedName);

    //    //Label2.Text = Convert.ToString(objBELIpd.Diagnosis);
    //    //Label4.Text = Convert.ToString(objBELIpd.ProcedureName);
    //    //Label6.Text = Convert.ToString(objBELIpd.PatientInsuType);
    //    //Label8.Text = Convert.ToString(objBELIpd.Sponsor2);
    //    //lblvisitno.Text = Convert.ToString(objBELIpd.VisitingNo);
    //}
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
        if (Convert.ToString(Session["PatAdmit"]) == "No")
        {
            lblvalidate.Text = "Patient already discharge!";
            return;
        }
        if (txtProvDiagnosis.Text == "")
        {
            txtProvDiagnosis.Focus();
            lblvalidate.Text = "Please Enter Allergy!";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Enter Allergy!!!');", true);
            return;
        }
        objBELBillDetail.BranchId = Convert.ToInt32(Session["Branchid"]);

        objBELBillDetail.PatRegId = Convert.ToInt32(RegId);
        objBELBillDetail.IpdNo = Convert.ToInt32(IpdId);
        objBELBillDetail.BillNo = Convert.ToInt32(BillNo);
        objBELBillDetail.CreatedBy = Convert.ToString(Session["username"]);
        InsertInBill();
      
        lblvalidate.Text = "Record save successfully.!";
       // BtnDischarge.Visible = true;
        BindDailyNurseNotes();
       
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

        if (txtComplaints.Text != "")
        {
            objBELBillInfo.P_IPD_Complaints = txtComplaints.Text;
        }
        else
            objBELBillInfo.P_IPD_Complaints = "";

        if (txtonAdmission.Text != "")
        {
            objBELBillInfo.P_IPD_OnAdmisDetails = txtonAdmission.Text;
        }
        else
            objBELBillInfo.P_IPD_OnAdmisDetails = "";

        if (txtcasesummary.Text != "")
        {
            objBELBillInfo.P_IPD_CaseSummary = txtcasesummary.Text;
        }
        else
            objBELBillInfo.P_IPD_CaseSummary = "";

        if (txtProvDiagnosis.Text != "")
        {
            objBELBillInfo.P_IPD_ProvDiagnosis = txtProvDiagnosis.Text;
        }
        else
            objBELBillInfo.P_IPD_ProvDiagnosis = "";

        if (txtFinalDiagnosis.Text != "")
        {
            objBELBillInfo.P_IPD_FinalDiagnosis = txtFinalDiagnosis.Text;
        }
        else
            objBELBillInfo.P_IPD_FinalDiagnosis = "";

        if (txtHistory.Text != "")
        {
            objBELBillInfo.P_IPD_History = txtHistory.Text;
        }
        else
            objBELBillInfo.P_IPD_History = "";

        if (txtTemp.Text != "")
        {
            objBELBillInfo.P_IPD_Temp = txtTemp.Text;
        }
        else
            objBELBillInfo.P_IPD_Temp = "";

        if (txtResp.Text != "")
        {
            objBELBillInfo.P_IPD_Resp= txtResp.Text;
        }
        else
            objBELBillInfo.P_IPD_Resp = "";

        if (txtheight.Text != "")
        {
            objBELBillInfo.P_IPD_Height = txtheight.Text;
        }
        else
            objBELBillInfo.P_IPD_Height = "";

        if (txtpulse.Text != "")
        {
            objBELBillInfo.P_IPD_pulse = txtpulse.Text;
        }
        else
            objBELBillInfo.P_IPD_pulse = "";

        if (txtBP.Text != "")
        {
            objBELBillInfo.P_IPD_BP = txtBP.Text;
        }
        else
            objBELBillInfo.P_IPD_BP = "";

        if (txtweight.Text != "")
        {
            objBELBillInfo.P_IPD_weight = txtweight.Text;
        }
        else
            objBELBillInfo.P_IPD_weight = "";

        if (txtAlbumin.Text != "")
        {
            objBELBillInfo.P_IPD_Albumin = txtAlbumin.Text;
        }
        else
            objBELBillInfo.P_IPD_Albumin = "";

        if (txtsugar.Text != "")
        {
            objBELBillInfo.P_IPD_sugar = txtsugar.Text;
        }
        else
            objBELBillInfo.P_IPD_sugar = "";

        if (txtBlood.Text != "")
        {
            objBELBillInfo.P_IPD_Blood = txtBlood.Text;
        }
        else
            objBELBillInfo.P_IPD_Blood = "";

      

       
      
        objBELBillInfo.CreatedBy = Convert.ToString(Session["username"]);
        objBELBillInfo.BranchId = Convert.ToInt32(Session["Branchid"]);
        objBELBillInfo.FId = Convert.ToInt32(Session["FId"]);
        //-------------------------------------------

        objBELBillInfo.P_foodpreferences= rblCulture.SelectedValue;
        objBELBillInfo.P_Describe = txtdescribe.Text;
        if (rblBpType.SelectedItem.Text != null)
        {
            objBELBillInfo.P_BpType = rblBpType.SelectedItem.Text;
        }
        objBELBillInfo.P_lastpoIntake = txtlastpoIntake.Text;
        if (txtlastpodateintake.Text != "")
        {
            objBELBillInfo.P_lastpodateintake =Convert.ToDateTime( txtlastpodateintake.Text);
        }
       objBELBillInfo.P_lasttimepointak= txtlasttimepointak.Text;
       if (txtlastvoidedurinedate.Text != "")
       {
           objBELBillInfo.P_lastvoidedurinedate = Convert.ToDateTime(txtlastvoidedurinedate.Text);
       }
      objBELBillInfo.P_lastvoidedurinetime= txtlastvoidedurinetime.Text;

      if (txtlastbowelmovementdate.Text != "")
       {
           objBELBillInfo.P_lastbowelmovementdate = Convert.ToDateTime(txtlastbowelmovementdate.Text);
       }
     objBELBillInfo.P_lastbowelmovementtime= txtlastbowelmovementtime.Text;
     objBELBillInfo.P_Vision= RblVision.SelectedItem.Text;
     objBELBillInfo.P_Hearing = rblHearing.SelectedItem.Text;
     objBELBillInfo.P_Speech = RblSpeech.SelectedItem.Text;
     objBELBillInfo.P_Ambulation = rblAmbulation.SelectedItem.Text;
     objBELBillInfo.P_Declaration = rbldeclaration.SelectedItem.Text;
     objBELBillInfo.P_RelativeName = txtrelativename.Text;
     if (txtrelativedate.Text != "")
     {
         objBELBillInfo.P_RelativeDate = Convert.ToDateTime( txtrelativedate.Text);
     }
     objBELBillInfo.P_WitnessName=txtwitnessname.Text;

     if (txtwitnessdate.Text != "")
     {
         objBELBillInfo.P_WitnessDate = Convert.ToDateTime(txtwitnessdate.Text);
     }
     if (ChkAwake.Checked == true)
     {
         objBELBillInfo.P_Awake = true;
     }
     else
     {
         objBELBillInfo.P_Awake = false;
     }
     if (ChkAlert.Checked == true)
     {
         objBELBillInfo.P_Alert = true;
     }
     else
     {
         objBELBillInfo.P_Alert = false;
     }
     if (ChkOriented.Checked == true)
     {
         objBELBillInfo.P_Oriented = true;
     }
     else
     {
         objBELBillInfo.P_Oriented = false;
     }
     if (ChkLethargic.Checked == true)
     {
         objBELBillInfo.P_Lethargic = true;
     }
     else
     {
         objBELBillInfo.P_Lethargic = false;
     }
     if (ChkDisoriented.Checked == true)
     {
         objBELBillInfo.P_Disoriented = true;
     }
     else
     {
         objBELBillInfo.P_Disoriented = false;
     }
     if (ChkComatose.Checked == true)
     {
         objBELBillInfo.P_Comatose = true;
     }
     else
     {
         objBELBillInfo.P_Comatose = false;
     }

     objBELBillInfo.P_surgicalHistory= txtsurgicalHistory.Text;
     objBELBillInfo.P_FamilyHistory = txtFamilyHistory.Text;
     objBELBillInfo.P_Wound = txtWound.Text;
     objBELBillInfo.P_WoundSize = txtwouldsize.Text;

        //-------------------------------------------
        objDALBillInfo.InsertIPD_Admissionsheet(objBELBillInfo);
        //ViewState["BillPaymentId"] = Convert.ToInt32(returns[0]);
        for (int i = 0; i < GvHairLaser.Rows.Count; i++)
        {

            //extract the TextBox values

            TextBox box1 = (TextBox)GvHairLaser.Rows[i].Cells[1].FindControl("txtName");
            TextBox box2 = (TextBox)GvHairLaser.Rows[i].Cells[2].FindControl("txtDose");
            TextBox box3 = (TextBox)GvHairLaser.Rows[i].Cells[3].FindControl("txtFrequency");
            TextBox box4 = (TextBox)GvHairLaser.Rows[i].Cells[4].FindControl("txttimeoflastdose");
            objBELBillInfo.P_Name = box1.Text;
            objBELBillInfo.P_Dose = box2.Text;
            objBELBillInfo.P_Frequency = box3.Text;
            objBELBillInfo.P_LastDose = box4.Text;
            objDALBillInfo.InsertIPD_Admissionsheet_Details(objBELBillInfo);
        }
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
    public void BindDailyNurseNotes()
    {
        DataTable dt = new DataTable();
        objBELIO.Patregid = Convert.ToInt32(Session["EmrRegNo"]);
        objBELIO.OpdNo = Convert.ToInt32(Session["EmrOpdNo"]);
        string entrydate = Request.QueryString["EntryDate"];
        objBELIO.IpdNo = Convert.ToInt32(Session["EmrIpdNo"]);
        objBELIO.FId = Convert.ToInt32(Session["FId"]);
        objBELIO.BranchId = Convert.ToInt32(Session["Branchid"]);
        dt = objDALIO.BindAdmissionSheet(objBELIO);
        gvDailyNurseNote.DataSource = dt;
        gvDailyNurseNote.DataBind();
        Get_TReatment_Details(objBELIO.Patregid, objBELIO.IpdNo);
    }
    protected void gvDailyNurseNote_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDailyNurseNote.PageIndex = e.NewPageIndex;
        BindDailyNurseNotes();
    }
    protected void gvDailyNurseNote_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void gvDailyNurseNote_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            string IVChartId = (gvDailyNurseNote.DataKeys[e.NewEditIndex]["Id"].ToString());
            ViewState["Id"] = IVChartId;
           // FillPage();
            e.Cancel = true;
        }
        catch (Exception ex)
        {
           // LblMSg.Text = ex.Message;
        }
    }

    private void SetInitialRow()
    {

        DataTable dt = new DataTable();

        DataRow dr = null;

        dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));

        dt.Columns.Add(new DataColumn("Name", typeof(string)));
        dt.Columns.Add(new DataColumn("Dose", typeof(string)));
        dt.Columns.Add(new DataColumn("Frequency", typeof(string)));
        dt.Columns.Add(new DataColumn("LastDose", typeof(string)));





        dr = dt.NewRow();

        dr["RowNumber"] = 1;

        dr["Name"] = string.Empty;
        dr["Dose"] = string.Empty;
        dr["Frequency"] = string.Empty;
        dr["LastDose"] = string.Empty;


        dt.Rows.Add(dr);



        //Store the DataTable in ViewState

        ViewState["CurrentTable"] = dt;



        GvHairLaser.DataSource = dt;

        GvHairLaser.DataBind();

    }
    private void SetPreviousData()
    {

        int rowIndex = 0;

        if (ViewState["CurrentTable"] != null)
        {

            DataTable dt = (DataTable)ViewState["CurrentTable"];

            if (dt.Rows.Count > 0)
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    TextBox box1 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[1].FindControl("txtName");
                    TextBox box2 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[2].FindControl("txtDose");
                    TextBox box3 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[3].FindControl("txtFrequency");
                    TextBox box4 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[4].FindControl("txttimeoflastdose");

                    box1.Text = dt.Rows[i]["Name"].ToString();
                    box2.Text = dt.Rows[i]["Dose"].ToString();
                    box3.Text = dt.Rows[i]["Frequency"].ToString();
                    box4.Text = dt.Rows[i]["LastDose"].ToString();


                    rowIndex++;

                }

            }

        }

    }

    private void AddNewRowToGrid()
    {

        int rowIndex = 0;



        if (ViewState["CurrentTable"] != null)
        {

            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];

            DataRow drCurrentRow = null;

            if (dtCurrentTable.Rows.Count > 0)
            {

                for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                {

                    //extract the TextBox values

                    TextBox box1 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[1].FindControl("txtName");
                    TextBox box2 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[2].FindControl("txtDose");

                    TextBox box3 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[3].FindControl("txtFrequency");
                    TextBox box4 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[4].FindControl("txttimeoflastdose");



                    drCurrentRow = dtCurrentTable.NewRow();

                    drCurrentRow["RowNumber"] = i + 1;



                    dtCurrentTable.Rows[i - 1]["Name"] = box1.Text;
                    dtCurrentTable.Rows[i - 1]["Dose"] = box2.Text;
                    dtCurrentTable.Rows[i - 1]["Frequency"] = box3.Text;
                    dtCurrentTable.Rows[i - 1]["LastDose"] = box4.Text;


                    rowIndex++;

                }

                dtCurrentTable.Rows.Add(drCurrentRow);

                ViewState["CurrentTable"] = dtCurrentTable;



                GvHairLaser.DataSource = dtCurrentTable;
                GvHairLaser.DataBind();

            }

        }

        else
        {

            Response.Write("ViewState is null");

        }



        //Set Previous Data on Postbacks

        SetPreviousData();

    }
    protected void ButtonAdd_Click(object sender, EventArgs e)
    {

        AddNewRowToGrid();

    }

    public void BindAllergise( int RegNo)
    {
        SqlConnection conn = DataAccess.ConInitForDC();
        conn.Open();

        using (SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM patientinformation where PatRegId=" + Convert.ToInt32(RegNo), conn))
        {
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                txtProvDiagnosis.Text = Convert.ToString( dt.Rows[0]["Allergy"]);
            }
            else
            {
              

            }

        }
        conn.Close();
        conn.Dispose();

    }
}