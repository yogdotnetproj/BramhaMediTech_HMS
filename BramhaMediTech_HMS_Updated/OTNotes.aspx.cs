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
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Design;

public partial class OTNotes :BasePage
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

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["Register"] = "";
            if (Request.QueryString["RegId"] != "" && Request.QueryString["IpdId"] != "")
            {

                DateTime time = DateTime.Now;
                txttimestart.Text = DateTime.Now.ToString("dd/MM/yyyy");
              

                

                int RegId = Convert.ToInt32(Request.QueryString["RegId"]);
                int IpdId = Convert.ToInt32(Request.QueryString["IpdId"]);
                FillIpdPatInfo(RegId, IpdId);
                GetOperationNotes();
                
            }
            
        }

    }
    public void GetOperationNotes()
    {

        DataTable dt = new DataTable();

        using (SqlConnection con = DataAccess.ConInitForDC())
        {
            using (SqlCommand cmd = new SqlCommand("usp_GetIpdPatientOTNotes", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FId", Convert.ToInt32(Session["FId"]));
                cmd.Parameters.AddWithValue("@BranchId", Convert.ToInt32(Session["Branchid"]));
                cmd.Parameters.AddWithValue("@PatRegId", Convert.ToInt32(Request.QueryString["RegId"]));
                cmd.Parameters.AddWithValue("@OTID", Convert.ToInt32(Request.QueryString["OTID"]));
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
                txtsurgen.Text = Convert.ToString(dt.Rows[0]["SurganName"]);
                txtAnaesthetist.Text = Convert.ToString(dt.Rows[0]["ANAESTHETISTName"]);              
                txt2stAsst.Text = Convert.ToString(dt.Rows[0]["SecondAssistant"]);               
                txtDISEASE.Text = Convert.ToString(dt.Rows[0]["DiseaseName"]);
                txtoperation.Text = Convert.ToString(dt.Rows[0]["OperationName"]);
                ddlAnaesthesia.SelectedValue = Convert.ToString(dt.Rows[0]["TypeOfAnaesthesia"]);
                ddlType.SelectedValue = Convert.ToString(dt.Rows[0]["Type"]);
                txttimestart.Text = Convert.ToString(dt.Rows[0]["OperationStartDate"]);
                txtProcedure.InnerText = Convert.ToString(dt.Rows[0]["OPProcedure"]);
                txtSurgeryDone.Text = Convert.ToString(dt.Rows[0]["SurgeryDone"]);
                txtIncision.Text = Convert.ToString(dt.Rows[0]["Incision"]);
                txtBloodLoss.Text = Convert.ToString(dt.Rows[0]["BloodLoss"]);
                txtAdvert.Text = Convert.ToString(dt.Rows[0]["AdvertEvents"]);
                txtComments.InnerText = Convert.ToString(dt.Rows[0]["Comments"]);
                // txt1stAsst.Text = Convert.ToString(dt.Rows[0]["FirstAssistantName"]);
                // txtSTERINURSE.Text = Convert.ToString(dt.Rows[0]["SteriNurseName"]);
                //txtremark.Text = Convert.ToString(dt.Rows[0]["Remark"]);
                //txtTime.Text = Convert.ToString(dt.Rows[0]["OperationStartTime"]);
                //txttimeEnd.Text = Convert.ToString(dt.Rows[0]["OperationEndTime"]);               
                //txtDateEnd.Text = Convert.ToString(dt.Rows[0]["OperationEndDate"]);
                //txtTTime.Text = Convert.ToString(dt.Rows[0]["AnisticTime"]);
                //txtInstrumentSecoundNurse.Text = Convert.ToString(dt.Rows[0]["InstrumentCountNurseName2"]);
                //txtInstrumentFirstNurse.Text = Convert.ToString(dt.Rows[0]["InstrumentCountNurseName"]);
                //txtswabSecountNurse.Text = Convert.ToString(dt.Rows[0]["SwabCountNurseName2"]);
                //txtswabFirstNurse.Text = Convert.ToString(dt.Rows[0]["SwabCountNurseName"]);
                //txttrollyNurse.Text = Convert.ToString(dt.Rows[0]["TrollyNurseName"]);

                ViewState["SurganID"] = Convert.ToString(dt.Rows[0]["Surgan"]);
                ViewState["Ansstia"] = Convert.ToString(dt.Rows[0]["ANAESTHETIST"]);
                ViewState["1AssistID"] = Convert.ToString(dt.Rows[0]["FirstAssistant"]);
                 ViewState["2AssistID"] = Convert.ToString(dt.Rows[0]["SecondAssistant"]);
               // ViewState["STERINURSE"] = Convert.ToString(dt.Rows[0]["SteriNurse"]);
                ViewState["DISEASE"] = Convert.ToString(dt.Rows[0]["Disease"]);
                ViewState["Operation"] = Convert.ToString(dt.Rows[0]["Operation"]);

                //ViewState["swabFirst"] = Convert.ToString(dt.Rows[0]["SwabCountNurse"]);
                //ViewState["swabSecound"] = Convert.ToString(dt.Rows[0]["SwabCountNurse2"]);
                //ViewState["InstruFirst"] = Convert.ToString(dt.Rows[0]["InstrumentCountNurse"]);
                //ViewState["InstruSeco"] = Convert.ToString(dt.Rows[0]["InstrumentCountNurse2"]);
                //ViewState["TrollyNurse"] = Convert.ToString(dt.Rows[0]["TrollyNurse"]);
                Image1show.ImageUrl = "~/OTImage/" + Path.GetFileName(Convert.ToString(dt.Rows[0]["OTImagePath"]));
                ViewState["Register"] = "true";

            }


        }
    }
   
   
    

    public void FillIpdPatInfo(int RegId, int IpdId)
    {
        objBELIpd.IpdId = IpdId;
        objBELIpd.PatRegId = RegId;
        objBELIpd.FId = Convert.ToInt32(Session["FId"]);
        objBELIpd.BranchId = Convert.ToInt32(Session["Branchid"]);
        objBELIpd = ObjDALIpd.GetIpdPatientInformation(objBELIpd);
        lblPatCat.Text = Convert.ToString(objBELIpd.PatMainType);
        lblPatientName.Text = Convert.ToString(objBELIpd.PatientName);
        lblAdmissionDate.Text = Convert.ToString(objBELIpd.EntryDate);
        lblIpd.Text = Convert.ToString(objBELIpd.IpdNo);
        lblPatRegId.Text = Convert.ToString(objBELIpd.PatRegId);
        lblBillNo.Text = Convert.ToString(objBELIpd.IpdNo);

        lblRoomName.Text = Convert.ToString(objBELIpd.RoomName);
        lbldrname.Text = Convert.ToString(objBELIpd.DRName);
        LblRoomType.Text = Convert.ToString(objBELIpd.RType);
        lblBedName.Text = Convert.ToString(objBELIpd.BedName);

        Label2.Text = Convert.ToString(objBELIpd.Diagnosis);
        Label4.Text = Convert.ToString(objBELIpd.ProcedureName);
        Label6.Text = Convert.ToString(objBELIpd.PatientInsuType);
        Label8.Text = Convert.ToString(objBELIpd.Sponsor2);
        lblvisitno.Text = Convert.ToString(objBELIpd.VisitingNo);
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {

        objBELBillDetail.BranchId = Convert.ToInt32(Session["Branchid"]);

        objBELBillDetail.PatRegId = Convert.ToInt32(lblPatRegId.Text);
        objBELBillDetail.IpdNo = Convert.ToInt32(lblIpd.Text);
        objBELBillDetail.BillNo = Convert.ToInt32(lblIpd.Text);
        objBELBillDetail.CreatedBy = Convert.ToString(Session["username"]);

        Message = objDALBillDetail.UpdateBillFinalDischarge(objBELBillDetail);
       // lblvalidate.Text = "Final Discharge successfully.!";

    }
   
   
   
    //private void LoadConsultantDoc()
    //{

    //    ddlConsDoctorName.DataSource = objDALOpdReg.FillConsultantDocName();
    //    ddlConsDoctorName.DataValueField = "DrId";
    //    ddlConsDoctorName.DataTextField = "EmpName";
    //    ddlConsDoctorName.DataBind();
    //}

    protected void ddlConsDoctorName_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
        [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchConsultDoc(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        return objDALOpdReg.FillAllConsultDoc(prefixText);
    }
    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchAllService(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        // string Type =  RdbServicesFlag.SelectedValue;
        // HttpContext.Current.Session["UID"];
        string Type = Convert.ToString(HttpContext.Current.Session["UID"]);
        return objDALOpdReg.FillAllGeneralOTService(prefixText, Type);
    }
    
   public void GenerateReport()
    {
        
        BLLReports objreports = new BLLReports();
        ReportDocument crystalReport = new ReportDocument();
        DataSet OtNotes = new DataSet();      

        crystalReport.Load(Server.MapPath("~/Report/Rpt_OTNotes.rpt"));
        int IpdId = Convert.ToInt32(Request.QueryString["IpdId"]);
        int PatRegId = Convert.ToInt32(Request.QueryString["RegId"]);
        int BranchId = Convert.ToInt32(Session["Branchid"]);
        int FId = Convert.ToInt32(Session["FId"]);
        int OTId = Convert.ToInt32(Request.QueryString["OTId"]);
        OtNotes = objreports.GetOperationNotes(OTId, PatRegId, FId, BranchId);
        crystalReport.SetDataSource(OtNotes);
        //crystalReport.ParameterFields["HospitalName"].CurrentValues.AddValue(Convert.ToString(Application["OrgnizationName"]));
        //crystalReport.ParameterFields["HospitalAddress"].CurrentValues.AddValue(Convert.ToString(Application["OrgnizationAddress"]));

        //crystalReport.ParameterFields["ReportFooter"].CurrentValues.AddValue("Hospital Software | Ph.020 123456789");
        try
        {
            crystalReport.ExportToHttpResponse
            (CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "OtNotes");

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
    protected void btnSummary_Click(object sender, EventArgs e)
    {
        string sql = "";

        BLLReports objreports = new BLLReports();
        int IpdId = Convert.ToInt32(Request.QueryString["IpdId"]);
        int PatRegId = Convert.ToInt32(Request.QueryString["RegId"]);
        int BranchId = Convert.ToInt32(Session["Branchid"]);
        int FId = Convert.ToInt32(Session["FId"]);

        objreports.IpdBillSummary(IpdId, PatRegId);

        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Reports/Rpt_IpdBillSummary.rpt");
        Session["reportname"] = "IpdBillSummary_Report";
        Session["RPTFORMAT"] = "pdf";


        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);


    }
    //=============================================================================

    [ScriptMethod()]
    [WebMethod]
    public static List<string> Searchsurgan(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        return objDALOpdReg.FillAllSurgan(prefixText);
    }


    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchAnaesthetist(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        return objDALOpdReg.FillAllAnaesthetist(prefixText);
    }

    [ScriptMethod()]
    [WebMethod]
    public static List<string> Search1stAsst(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        return objDALOpdReg.FillAll1Assists(prefixText);
    }
    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchAsst(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        return objDALOpdReg.FillAssistanceForOperation(prefixText);
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
    protected void txtsurgen_TextChanged(object sender, EventArgs e)
    {
        if (txtsurgen.Text != "")
        {
            string[] PatientInfo = txtsurgen.Text.Split('-');
            if (PatientInfo.Length > 1)
            {
                txtsurgen.Text = PatientInfo[1];
                ViewState["SurganID"] = PatientInfo[0];
                txtsurgen.BorderColor = Color.LightGray;
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

    public bool validationSurgeon()
    {
        bool flag = false;
        if (txtsurgen.Text == "")
        {
            if (ViewState["SurganID"].ToString() == "0")
            {
                txtsurgen.Focus();
                txtsurgen.BorderColor = Color.Red;
                ViewState["Msg"] = "Please Select Surgeon!!";
                flag = false;
            }
        }
        else
        {
            if (ViewState["SurganID"].ToString() == "0")
            {
                txtsurgen.Focus();
                txtsurgen.BorderColor = Color.Red;
                ViewState["Msg"] = "Please Select Surgeon!!";
                flag = false;
            }
            else
            {
                txtsurgen.BorderColor = Color.LightGray;
                flag = true;
            }
        }
        return flag;
    }
    //public bool Validation1stAss()
    //{
    //    if (txt1stAsst.Text != "")
    //    {

    //        if (ViewState["1AssistID"].ToString() == "0")
    //        {
    //            txt1stAsst.Focus();
    //            txt1stAsst.BorderColor = Color.Red;
    //            ViewState["Msg"] = "Please Select Assistant!!";
    //            return false;
    //        }
    //        else
    //        {
    //            txt1stAsst.BorderColor = Color.LightGray;
    //            return true;
    //        }
    //    }
    //    else
    //    {
    //        txt1stAsst.BorderColor = Color.LightGray;
    //        ViewState["1AssistID"] = "0";
    //        return true;
    //    }
    //}
    
    public bool ValidationAnaesthetist()
    {
        if (txtAnaesthetist.Text != "")
        {
            if (ViewState["Ansstia"].ToString() == "0")
            {
                txtAnaesthetist.Focus();
                txtAnaesthetist.BorderColor = Color.Red;
                ViewState["Msg"] = "Please Select Anaesthetist!!";
                return false;
            }
            else
            {
                txtAnaesthetist.BorderColor = Color.LightGray;
                return true;
            }
        }
        else
        {
            ViewState["Ansstia"] = "0";
            txtAnaesthetist.BorderColor = Color.LightGray;
            return true;
        }


    }
    //public bool ValidationSTERINURSE()
    //{
    //    if (txtSTERINURSE.Text != "")
    //    {
    //        if (ViewState["STERINURSE"].ToString() == "0")
    //        {
    //            txtSTERINURSE.Focus();
    //            txtSTERINURSE.BorderColor = Color.Red;
    //            ViewState["Msg"] = "Please Select Nurse!!";
    //            return false;
    //        }
    //        else
    //        {
    //            txtSTERINURSE.BorderColor = Color.LightGray;
    //            return true;
    //        }
    //    }
    //    else
    //    {
    //        txtSTERINURSE.BorderColor = Color.LightGray;
    //        ViewState["STERINURSE"] = "0";
    //        return true;
    //    }


    //}
    //public bool ValidationInstrumentFirstNurse()
    //{
    //    if (txtInstrumentFirstNurse.Text != "")
    //    {
    //        if (ViewState["InstruFirst"].ToString() == "0")
    //        {
    //            txtInstrumentFirstNurse.Focus();
    //            txtInstrumentFirstNurse.BorderColor = Color.Red;
    //            ViewState["Msg"] = "Please Select Nurse!!";
    //            return false;
    //        }
    //        else
    //        {
    //            txtInstrumentFirstNurse.BorderColor = Color.LightGray;
    //            return true;
    //        }
    //    }
    //    else
    //    {
    //        txtInstrumentFirstNurse.BorderColor = Color.LightGray;
    //        ViewState["InstruFirst"] = "0";
    //        return true;
    //    }
    //}
    //public bool ValidationInstrumentSecoundNurse()
    //{
    //    if (txtInstrumentSecoundNurse.Text != "")
    //    {
    //        if (ViewState["InstruSeco"].ToString() == "0")
    //        {
    //            txtInstrumentSecoundNurse.Focus();
    //            txtInstrumentSecoundNurse.BorderColor = Color.Red;
    //            ViewState["Msg"] = "Please Select Nurse!!";
    //            return false;
    //        }
    //        else
    //        {
    //            txtInstrumentSecoundNurse.BorderColor = Color.LightGray;
    //            return true;
    //        }
    //    }
    //    else
    //    {
    //        ViewState["InstruSeco"] = "0";
    //        txtInstrumentSecoundNurse.BorderColor = Color.LightGray;
    //        return true;
    //    }
    //}
    //public bool ValidationswabSecountNurse()
    //{
    //    if (txtswabSecountNurse.Text != "")
    //    {
    //        if (ViewState["swabSecound"].ToString() == "0")
    //        {
    //            txtswabSecountNurse.Focus();
    //            txtswabSecountNurse.BorderColor = Color.Red;
    //            ViewState["Msg"] = "Please Select Nurse!!";
    //            return false;
    //        }
    //        else
    //        {
    //            txtswabSecountNurse.BorderColor = Color.LightGray;
    //            return true;
    //        }
    //    }
    //    else
    //    {
    //        txtswabSecountNurse.BorderColor = Color.LightGray;
    //        ViewState["swabSecound"] = "0";
    //        return true;
    //    }
    //}
    //public bool ValidationswabFirstNurse()
    //{
    //    if (txtswabFirstNurse.Text != "")
    //    {
    //        if (ViewState["swabFirst"].ToString() == "0")
    //        {
    //            txtswabFirstNurse.Focus();
    //            txtswabFirstNurse.BorderColor = Color.Red;
    //            ViewState["Msg"] = "Please Select Nurse!!";
    //            return false;
    //        }
    //        else
    //        {
    //            txtswabFirstNurse.BorderColor = Color.LightGray;
    //            return true;
    //        }
    //    }
    //    else
    //    {
    //        txtswabFirstNurse.BorderColor = Color.LightGray;
    //        ViewState["swabFirst"] = "0";
    //        return true;
    //    }
    //}
    //public bool ValidationtrollyNurse()
    //{
    //    if (txttrollyNurse.Text != "")
    //    {
    //        if (ViewState["TrollyNurse"].ToString() == "0")
    //        {
    //            txttrollyNurse.Focus();
    //            txttrollyNurse.BorderColor = Color.Red;
    //            ViewState["Msg"] = "Please Select Nurse!!";
    //            return false;
    //        }
    //        else
    //        {
    //            txttrollyNurse.BorderColor = Color.LightGray;
    //            return true;
    //        }
    //    }
    //    else
    //    {
    //        ViewState["TrollyNurse"] = "0";
    //        txttrollyNurse.BorderColor = Color.LightGray;
    //        return true;
    //    }
    //}

    protected void txtAnaesthetist_TextChanged(object sender, EventArgs e)
    {
        if (txtAnaesthetist.Text != "")
        {
            string[] PatientInfo = txtAnaesthetist.Text.Split('-');
            if (PatientInfo.Length > 1)
            {
                txtAnaesthetist.Text = PatientInfo[1];
                ViewState["Ansstia"] = PatientInfo[0];
                txtAnaesthetist.BorderColor = Color.LightGray;
            }
            else
            {
                ViewState["Ansstia"] = "0";
            }
        }
        else
        {
            ViewState["Ansstia"] = "0";
            txtAnaesthetist.BorderColor = Color.Gray;
        }
    }
    //protected void txt1stAsst_TextChanged(object sender, EventArgs e)
    //{
    //    if (txt1stAsst.Text != "")
    //    {
    //        string[] PatientInfo = txt1stAsst.Text.Split('-');
    //        if (PatientInfo.Length > 1)
    //        {
    //            txt1stAsst.Text = PatientInfo[1];
    //            ViewState["1AssistID"] = PatientInfo[0];
    //            txt1stAsst.BorderColor = Color.LightGray;
    //        }
    //        else
    //        {
    //            ViewState["1AssistID"] = "0";
    //            txt1stAsst.BorderColor = Color.LightGray;
    //        }
    //    }
    //    else
    //    {
    //        ViewState["1AssistID"] = "0";
    //        txt1stAsst.BorderColor = Color.LightGray;
    //    }
    //}
    protected void txt2stAsst_TextChanged(object sender, EventArgs e)
    {
        //if (txt2stAsst.Text != "")
        //{
        //    string[] PatientInfo = txt2stAsst.Text.Split('-');
        //    if (PatientInfo.Length > 1)
        //    {
        //        txt2stAsst.Text = PatientInfo[1];
        //        ViewState["2AssistID"] = PatientInfo[0];
        //    }
        //    else
        //    {
        //        ViewState["2AssistID"] = "0";
        //    }
        //}
        //else
        //{
        //    ViewState["2AssistID"] = "0";
        //}
    }
 
    protected void txtDISEASE_TextChanged(object sender, EventArgs e)
    {
        if (txtDISEASE.Text != "")
        {
            string[] PatientInfo = txtDISEASE.Text.Split('-');
            if (PatientInfo.Length == 2)
            {
                txtDISEASE.Text = PatientInfo[1];
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
            txtDISEASE.BorderColor = Color.LightGray;
        }
    }
    protected void txtoperation_TextChanged(object sender, EventArgs e)
    {
        if (txtoperation.Text != "")
        {
            string[] PatientInfo = txtoperation.Text.Split('-');
            if (PatientInfo.Length == 2)
            {
                txtoperation.Text = PatientInfo[1];
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
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        objBELBillDetail = new BELBillDetails();

        objBELBillDetail.IpdId = Convert.ToInt32(Request.QueryString["IpdId"]);
        objBELBillDetail.PatRegId = Convert.ToInt32(lblPatRegId.Text);
        objBELBillDetail.IpdNo = Convert.ToInt32(lblIpd.Text);
        objBELBillDetail.BillNo = Convert.ToInt32(lblIpd.Text);

        if (validationSurgeon() == true)
        {
            if (txtsurgen.Text != "")
            {
                objBELBillDetail.Surgan = Convert.ToInt32(ViewState["SurganID"]);
            }
            else
            {
                objBELBillDetail.Surgan = 0;
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Enter Surgeon!!!');", true);
            return;

        }

        objBELBillDetail.OperationName = Convert.ToString(txtoperation.Text.Trim());

        objBELBillDetail.DiseaseName = Convert.ToString(txtDISEASE.Text.Trim());


        if (ValidationAnaesthetist() == true)
        {
            objBELBillDetail.ANAESTHETIST = Convert.ToInt32(ViewState["Ansstia"]);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Select Anaesthetist from List!!!');", true);
            return;

        }
        //if (Validation1stAss() == true)
        //{
        //    objBELBillDetail.FirstAssistant = Convert.ToInt32(ViewState["1AssistID"]);
        //}
        //else
        //{
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Select Assistant from List!!!');", true);
        //    return;

        //}
        if (txt2stAsst.Text != "")
        {
            objBELBillDetail.SecondAssistant = txt2stAsst.Text;
        }
        else
        {
            objBELBillDetail.SecondAssistant = "";
        }

        //if (ValidationSTERINURSE() == true)
        //{
        //    objBELBillDetail.SteriNurse = Convert.ToInt32(ViewState["STERINURSE"]);
        //}
        //else
        //{
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Select Nurse from List!!!');", true);
        //    return;

        //}
        if (txtDISEASE.Text != "")
        {
            objBELBillDetail.Disease = Convert.ToInt32(ViewState["DISEASE"]);
        }
        else
        {
            objBELBillDetail.Disease = 0;
        }
        if (txtoperation.Text != "")
        {
            objBELBillDetail.Operation = Convert.ToInt32(ViewState["Operation"]);
        }
        else
        {
            objBELBillDetail.Operation = 0;
        }
        if (txttimestart.Text != "")
        {
            objBELBillDetail.OperationStartDate = txttimestart.Text;
        }
        else
        {
            objBELBillDetail.OperationStartTime = "";
        }
        //if (txtTime.Text != "")
        //{
        //    objBELBillDetail.OperationStartTime = txtTime.Text;
        //}

        //if (txtDateEnd.Text != "")
        //{
        //    objBELBillDetail.OperationEndDate = txtDateEnd.Text;
        //}
        //else
        //{
        //    objBELBillDetail.OperationEndDate = "";
        //}
        //if (txttimeEnd.Text != "")
        //{
        //    objBELBillDetail.OperationEndTime = txttimeEnd.Text;
        //}

        //if (txtTTime.Text != "")
        //{
        //    objBELBillDetail.AnisticTime = txtTTime.Text;
        //}
        //else
        //{
        //    objBELBillDetail.AnisticTime = "";
        //}
        //if (txtremark.Text != "")
        //{
        //    objBELBillDetail.Remark = txtremark.Text;
        //}

        //==================================
        //if (ValidationswabFirstNurse() == true)
        //{
        //    objBELBillDetail.SwabCountNurse = Convert.ToInt32(ViewState["swabFirst"]);
        //}
        //else
        //{
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Select Nurse from List!!!');", true);
        //    return;

        //}
        //if (ValidationswabSecountNurse() == true)
        //{
        //    objBELBillDetail.swabSecountNurse = Convert.ToInt32(ViewState["swabSecound"]);
        //}
        //else
        //{
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Select Nurse from List!!!');", true);
        //    return;

        //}
        //if (ValidationInstrumentFirstNurse() == true)
        //{
        //    objBELBillDetail.InstrumentCountNurse = Convert.ToInt32(ViewState["InstruFirst"]);
        //}
        //else
        //{
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Select Nurse from List!!!');", true);
        //    return;

        //}
        //if (ValidationswabSecountNurse() == true)
        //{
        //    objBELBillDetail.InstrumentSecoundNurse = Convert.ToInt32(ViewState["InstruSeco"]);
        //}
        //else
        //{
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Select Nurse from List!!!');", true);
        //    return;

        //}
        //if (ValidationtrollyNurse() == true)
        //{
        //    objBELBillDetail.TrollyNurse = Convert.ToInt32(ViewState["TrollyNurse"]);
        //}
        //else
        //{
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Select Nurse from List!!!');", true);
        //    return;

        //}

        objBELBillDetail.CreatedBy = Convert.ToString(Session["username"]);
        objBELBillDetail.BranchId = Convert.ToInt32(Session["Branchid"]);

        objBELBillDetail.FId = Convert.ToInt32(Session["FId"]);

         objBELBillDetail.GeneralOT = Convert.ToInt32(1);
         objBELBillDetail.OTId = Convert.ToInt32(Request.QueryString["OTID"]);
         objBELBillDetail.Type=ddlType.SelectedValue;
         objBELBillDetail.TypeOfAnaesthesia=ddlAnaesthesia.SelectedValue;
         objBELBillDetail.Procedure= txtProcedure.InnerText;
         objBELBillDetail.Incision=txtIncision.Text;
         objBELBillDetail.BloodLoss=txtBloodLoss.Text;
         objBELBillDetail.SurgeryDone=txtSurgeryDone.Text;
         objBELBillDetail.AdvertEvents = txtAdvert.Text;
         objBELBillDetail.Comments = txtComments.InnerText;

         string DFile = "";
         string img = string.Empty;
         Bitmap bmpImg = null;
                string PDate = DateTime.Now.ToString("ddMMyyyy");
                //string ViewP = "~/ViewPrescription/" + Pname;
                //FUBrowsePresc.SaveAs(Server.MapPath(ViewP));
                string DefaultFileName = "OTImage/";
                if (FUUploadPhoto.HasFile)
                {
                   // FUUploadPhoto.SaveAs(Server.MapPath(DefaultFileName) + "/" + lblPatRegId.Text + "_" + PDate + "_" + FUUploadPhoto.FileName);
                   // LblUploadph.Text = lblPatRegId.Text + "_" + PDate + "_" + FUUploadPhoto.FileName;

                   // byte[] imageArray = System.IO.File.ReadAllBytes(Server.MapPath("~/Captures/" + LblUploadph.Text + ""));
                    //============================================================

                    string path = Server.MapPath("/" + Request.ApplicationPath + "/OTImage/");
                    bmpImg = Resize_Image(FUUploadPhoto.PostedFile.InputStream, 240, 150);
                    // FUBrowsePresc.SaveAs(Server.MapPath(DefaultFileName) + "/" + ViewState["RegN0"] + "_" + PDate + "_" + FUBrowsePresc.FileName + Guid.NewGuid().ToString());
                    img = Server.MapPath((DefaultFileName) + "/" + lblPatRegId.Text + "_" + PDate + "_" + FUUploadPhoto.FileName);
                    LblUploadph.Text = lblPatRegId.Text + "_" + PDate + "_" + FUUploadPhoto.FileName;
                    DFile = path + "/" + lblPatRegId.Text + "_" + PDate + "_" + FUUploadPhoto.FileName;
                    bmpImg.Save(img, ImageFormat.Jpeg);
                    //===========================================================

                    objBELBillDetail.OTImagePath = DFile;// LblUploadph.Text;



                }
        Message = objDALBillDetail.Insert_OTNotes(objBELBillDetail);
        lblMessage.Text = "OT Notes save Successfully..";
        ViewState["Register"] = "true";
        GenerateReport();

    }


    private Bitmap Resize_Image(Stream streamImage, int maxWidth, int maxHeight)
    {
        Bitmap originalImage = new Bitmap(streamImage);
        int newWidth = originalImage.Width;
        int newHeight = originalImage.Height;
        double aspectRatio = Convert.ToDouble(originalImage.Width) / Convert.ToDouble(originalImage.Height);

        if (aspectRatio <= 1 && originalImage.Width > maxWidth)
        {
            newWidth = maxWidth;
            newHeight = Convert.ToInt32(Math.Round(newWidth / aspectRatio));
        }
        else if (aspectRatio > 1 && originalImage.Height > maxHeight)
        {
            newHeight = maxHeight;
            newWidth = Convert.ToInt32(Math.Round(newHeight * aspectRatio));
        }
        return new Bitmap(originalImage, newWidth, newHeight);
    }
    //else
    //{
    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('"+ ViewState["Msg"] +"');", true);

    //}

    
    
}