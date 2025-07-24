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

public partial class IPD_MedicationStateOrder :BasePage
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
               
            }
            else
            {
                 RegId = Convert.ToInt32(Session["EmrRegNo"]);
                 IpdId = Convert.ToInt32(Session["EmrIpdNo"]);
                 BillNo = Convert.ToInt32(Session["EmrBillNo"]);
                
                // txtToDate.Text = System.DateTime.Now.ToShortDateString();
              
               // FillIpdPatInfo(RegId, IpdId);
                FillDischargeSummary(RegId, IpdId);
                
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
            using (SqlCommand cmd = new SqlCommand("Usp_IPD_MEDICATIONSTAT", con))
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
      //  AlterView_VE_GetLabNo(Convert.ToString( IpdId));
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

       
      

       
      
        objBELBillInfo.CreatedBy = Convert.ToString(Session["username"]);
        objBELBillInfo.BranchId = Convert.ToInt32(Session["Branchid"]);
        objBELBillInfo.FId = Convert.ToInt32(Session["FId"]);
        //-------------------------------------------

      

        //-------------------------------------------
        objDALBillInfo.Delete_IPDMedicationState(RegId, IpdId);
        //ViewState["BillPaymentId"] = Convert.ToInt32(returns[0]);
        for (int i = 0; i < GvHairLaser.Rows.Count; i++)
        {

            //extract the TextBox values

            TextBox box1 = (TextBox)GvHairLaser.Rows[i].Cells[1].FindControl("txtMedDateTime");
            TextBox box2 = (TextBox)GvHairLaser.Rows[i].Cells[2].FindControl("txtPhysician");
            TextBox box3 = (TextBox)GvHairLaser.Rows[i].Cells[3].FindControl("txtDosage");
            TextBox box4 = (TextBox)GvHairLaser.Rows[i].Cells[4].FindControl("txtRoute");
            TextBox box5 = (TextBox)GvHairLaser.Rows[i].Cells[5].FindControl("txtRN");
            objBELBillInfo.P_MedDateTime = box1.Text;
            objBELBillInfo.P_Physician = box2.Text;
            objBELBillInfo.P_Dosage = box3.Text;
            objBELBillInfo.P_Route = box4.Text;
            objBELBillInfo.P_RN = box5.Text;
            objDALBillInfo.InsertIPD_MedicationStateOrder_Details(objBELBillInfo);
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

        dt.Columns.Add(new DataColumn("MedDateTime", typeof(string)));
        dt.Columns.Add(new DataColumn("Physician", typeof(string)));
        dt.Columns.Add(new DataColumn("Dosage", typeof(string)));
        dt.Columns.Add(new DataColumn("Route", typeof(string)));
        dt.Columns.Add(new DataColumn("RN", typeof(string)));
        dr = dt.NewRow();

        dr["RowNumber"] = 1;

        dr["MedDateTime"] = string.Empty;
        dr["Physician"] = string.Empty;
        dr["Dosage"] = string.Empty;
        dr["Route"] = string.Empty;
        dr["RN"] = string.Empty;

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
                    TextBox box1 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[1].FindControl("txtMedDateTime");
                    TextBox box2 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[2].FindControl("txtPhysician");
                    TextBox box3 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[3].FindControl("txtDosage");
                    TextBox box4 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[4].FindControl("txtRoute");
                    TextBox box5 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[5].FindControl("txtRN");

                    box1.Text = dt.Rows[i]["MedDateTime"].ToString();
                    box2.Text = dt.Rows[i]["Physician"].ToString();
                    box3.Text = dt.Rows[i]["Dosage"].ToString();
                    box4.Text = dt.Rows[i]["Route"].ToString();
                    box5.Text = dt.Rows[i]["RN"].ToString();

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
                    TextBox box1 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[1].FindControl("txtMedDateTime");
                    TextBox box2 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[2].FindControl("txtPhysician");
                    TextBox box3 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[3].FindControl("txtDosage");
                    TextBox box4 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[4].FindControl("txtRoute");
                    TextBox box5 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[5].FindControl("txtRN");
                    drCurrentRow = dtCurrentTable.NewRow();

                    drCurrentRow["RowNumber"] = i + 1;
                    dtCurrentTable.Rows[i - 1]["MedDateTime"] = box1.Text;
                    dtCurrentTable.Rows[i - 1]["Physician"] = box2.Text;
                    dtCurrentTable.Rows[i - 1]["Dosage"] = box3.Text;
                    dtCurrentTable.Rows[i - 1]["Route"] = box4.Text;
                    dtCurrentTable.Rows[i - 1]["RN"] = box5.Text;
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
}