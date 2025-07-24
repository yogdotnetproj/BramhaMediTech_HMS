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

public partial class DischargeSlip : BasePage
{
    DALIPDDesk ObjDALIpd = new DALIPDDesk();
   
    BELOPDPatReg objBELOpdPatReg = new BELOPDPatReg();
    DALOpdReg objDALOpdPatReg = new DALOpdReg();
    BELBillInfo objBELBillInfo = new BELBillInfo();
    DALBillInfo objDALBillInfo = new DALBillInfo();
    DALPatientInformation objDALPatInfo = new DALPatientInformation();
    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (Request.QueryString["RecFlag"] == "Nurse")
        {
            this.MasterPageFile = "~/mainMaster.master";
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
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
            
           
            ViewState["ReceiptNo"] = "0";
          
            if (Request.QueryString["RegId"] != "" && Request.QueryString["IpdId"] != "")
            {
               
                int RegId = Convert.ToInt32(Request.QueryString["RegId"]);
                int IpdId = Convert.ToInt32(Request.QueryString["IpdId"]);
                CheckIpdDischargeSlip(RegId, IpdId);
                FillIpdPatInfo(RegId, IpdId);
               
                
            }
            
            
        }
    }
  
   
    public void FillIpdPatInfo(int RegId, int IpdId)
    {
        objBELOpdPatReg.IpdId = IpdId;
        objBELOpdPatReg.PatRegId = RegId;
        objBELOpdPatReg.FId = Convert.ToInt32(Session["FId"]);
        objBELOpdPatReg.BranchId = Convert.ToInt32(Session["Branchid"]);
        objBELOpdPatReg = ObjDALIpd.GetIpdPatientInformation(objBELOpdPatReg);
        lblPatName.Text = Convert.ToString(objBELOpdPatReg.PatientName);
        lblIPDNo.Text = Convert.ToString(objBELOpdPatReg.IpdNo);
        lblRegNo.Text = Convert.ToString(objBELOpdPatReg.PatRegId);
        lbldrname.Text = Convert.ToString(objBELOpdPatReg.DRName);
        lblRoomType.Text = Convert.ToString(objBELOpdPatReg.RoomName);
        lbladmisiondate.Text = Convert.ToString(objBELOpdPatReg.EntryDate) + " - " + Convert.ToString(objBELOpdPatReg.EntryTime);
        lblDischargeBy.Text = Convert.ToString(objBELOpdPatReg.RecoBy);
        lbldischargedate.Text = Convert.ToString(objBELOpdPatReg.RecoDate) + " - " + Convert.ToString(objBELOpdPatReg.RecoTime);
        
       // FillPage(Convert.ToInt32(lblRegNo.Text),Convert.ToInt32(Session["FId"]),Convert.ToInt32(lblIPDNo.Text),Convert.ToInt32(lblIPDNo.Text));
       // FillGrid(Convert.ToInt32(lblRegNo.Text), Convert.ToInt32(Session["FId"]), Convert.ToInt32(lblIPDNo.Text), Convert.ToInt32(lblIPDNo.Text));
       // LoadReceipts();
        
    }
   
   
   
   
    
    
    protected void btnreport_Click(object sender, EventArgs e)
    {
        string sql = "";
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd1 = con.CreateCommand();

        string query = "ALTER VIEW [dbo].[VW_GetDischargeSlip] AS (SELECT        IpdRegistration.IpdNo, IpdRegistration.PatRegId, IpdRegistration.IpdId, CONVERT(varchar, IpdRegistration.EntryDate, 103) AS EntryDate, IpdRegistration.EntryTime, IpdRegistration.DeptId, IpdRegistration.PrimaryDoc, "+
               " IpdRegistration.SecodaryDoc, IpdRegistration.ReferenceDoc, IpdRegistration.PatientMainCategoryId, IpdRegistration.ContactPerson1, IpdRegistration.ContactPerson2, IpdRegistration.Relation1, IpdRegistration.Relation2, "+
               " IpdRegistration.Contact1, IpdRegistration.Contact2, IpdRegistration.BedId, IpdRegistration.IsAdmited, IpdRegistration.CreatedBy, IpdRegistration.CreatedOn, IpdRegistration.FId, IpdRegistration.BranchId, "+
               " IpdRegistration.UpdatedBy, IpdRegistration.UpdatedOn, IpdRegistration.IsUniversalPrecaution, IpdRegistration.IsEmergency, PatientInformation.TitleId, Initial.Title + ' ' + PatientInformation.FirstName AS PatientName, "+
               " HospEmpMst.Title + ' ' + HospEmpMst.Empname AS DrName, PatientInsuType_1.PatientInsuType, IpdRegistration.PatientSubCategoryId, PatMainType.PatMainType, IpdRegistration.Sponsor, IpdRegistration.ProcedureName, "+
               " IpdRegistration.PatientSubCategoryId2, PatientInsuType.PatientInsuType AS Sponsor2, IpdRegistration.VisitingNo, DepartmentMst.DeptName, Tbl_Relation.RelationName, BedMst.BedName, RoomMst.RoomName, "+
               " RoomType.RType, IpdRegistration.VisitingNo AS Expr1, DepartmentMst.DeptName AS Expr2, Tbl_Relation.RelationName AS Expr3, IpdRegistration.IsAdmited AS Expr4, IpdRegistration.IsDischargeRec, "+
               " CONVERT(varchar,IpdRegistration.RecoDate, 103) AS RecoDate, IpdRegistration.RecoTime, IpdRegistration.RecoBy, IPD_DischargeSlip.Xray, IPD_DischargeSlip.kor, IPD_DischargeSlip.drugs, IPD_DischargeSlip.ECG, IPD_DischargeSlip.csr, "+
               " IPD_DischargeSlip.Lab, IPD_DischargeSlip.room, IPD_DischargeSlip.RBS, IPD_DischargeSlip.OXYGEN, IPD_DischargeSlip.NEBULIZER, IPD_DischargeSlip.XrayB, IPD_DischargeSlip.korB, IPD_DischargeSlip.drugsB, "+
               " IPD_DischargeSlip.ECGB, IPD_DischargeSlip.csrB, IPD_DischargeSlip.LabB, IPD_DischargeSlip.roomB, IPD_DischargeSlip.RBSB, IPD_DischargeSlip.OXYGENB, IPD_DischargeSlip.NEBULIZERB, IPD_DischargeSlip.Remarks, "+
               " IPD_DischargeSlip.Authority, IPD_DischargeSlip.CreatedBy AS NurseApproveBy, IPD_DischargeSlip.CreatedOn AS NurseApproveOn, IPD_DischargeSlip.FinanceApproveBy, IPD_DischargeSlip.FinanceApproveOn "+
               " FROM            PatientInsuType AS PatientInsuType_1 RIGHT OUTER JOIN "+
               " Tbl_Relation RIGHT OUTER JOIN "+
               " IPD_DischargeSlip INNER JOIN "+
               " IpdRegistration ON IPD_DischargeSlip.IpdNo = IpdRegistration.IpdNo AND IPD_DischargeSlip.PatRegId = IpdRegistration.PatRegId ON Tbl_Relation.RelationId = IpdRegistration.Relation1 LEFT OUTER JOIN "+
               " DepartmentMst ON IpdRegistration.DeptId = DepartmentMst.DeptId ON PatientInsuType_1.PatientInsuTypeId = IpdRegistration.PatientSubCategoryId LEFT OUTER JOIN "+
               " BedMst INNER JOIN "+
               " AlloctnOfBed ON BedMst.BedId = AlloctnOfBed.BedId INNER JOIN "+
               " RoomMst ON BedMst.RoomId = RoomMst.RoomId INNER JOIN "+
               " RoomType ON RoomMst.RTypeId = RoomType.RTypeId ON IpdRegistration.PatRegId = AlloctnOfBed.PatRegId AND IpdRegistration.IpdNo = AlloctnOfBed.IpdNo AND  "+
               " IpdRegistration.BranchId = AlloctnOfBed.BranchId LEFT OUTER JOIN "+
               " PatientInsuType ON IpdRegistration.PatientSubCategoryId2 = PatientInsuType.PatientInsuTypeId LEFT OUTER JOIN "+
               " PatMainType ON IpdRegistration.PatientMainCategoryId = PatMainType.PatMainTypeId LEFT OUTER JOIN "+
               " PatientInformation LEFT OUTER JOIN "+
               " Initial ON PatientInformation.TitleId = Initial.TitleId ON IpdRegistration.PatRegId = PatientInformation.PatRegId LEFT OUTER JOIN "+
               " HospEmpMst ON IpdRegistration.PrimaryDoc = HospEmpMst.DrId  where IPD_DischargeSlip.PatRegId=" + Convert.ToInt32(Request.QueryString["RegId"]) + " and IPD_DischargeSlip.IpdNo=" + Convert.ToInt32(Request.QueryString["IpdId"]) + "  ";
             




        cmd1.CommandText = query + ")";

        con.Open();
        cmd1.ExecuteNonQuery();
        con.Close(); con.Dispose();

        Session.Add("rptsql", "");
        // Session["rptname"] = Server.MapPath("~/Reports/Rpt_IpdBillSummary.rpt");
        Session["rptname"] = Server.MapPath("~/Reports/Rpt_IPDDischargeSlip.rpt");
        Session["reportname"] = "IPDDischargeSlip";
        Session["RPTFORMAT"] = "pdf";


        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);

    }

    protected void btnsave_Click(object sender, EventArgs e)
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
        
            InsertInBill();
          
            
       
    }
   
  

    private void InsertInBill()
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
        // string Message = "";
        BELBillInfo objBELBillInfo = new BELBillInfo();
       // objBELBillInfo.BillNo = Convert.ToInt32(lblBillNo.Text);
       // int ReceiptNo = objDALBillInfo.GetMaxIpdReceiptNo(Convert.ToInt32(Session["FId"]));
       // objBELBillInfo.ReceiptNo = ReceiptNo + 1;
       // ViewState["ReceiptNo"] = objBELBillInfo.ReceiptNo;
        objBELBillInfo.PatRegId = Convert.ToInt32(lblRegNo.Text);
        objBELBillInfo.BillDate = System.DateTime.Now;
        objBELBillInfo.IpdNo = Convert.ToInt32(lblIPDNo.Text);
        objBELBillInfo.BillNo = Convert.ToInt32(lblIPDNo.Text);
       // objBELBillInfo.ConsultantDrId = Convert.ToInt32(ddlConsDoctorName.SelectedValue);
       // objBELBillInfo.Remark = txtRemark.Value;
        objBELBillInfo.BillType = "Advance Receipt";
       // objBELBillInfo.PaymentType = RdbPayment.SelectedValue;

        if (chkXray.Checked == true)
        {
            objBELBillInfo.P_Xray = true;
        }
        else
        {
            objBELBillInfo.P_Xray = false;
        }
        if (Chkor.Checked == true)
        {
            objBELBillInfo.P_kor = true;
        }
        else
        {
            objBELBillInfo.P_kor = false;
        }
        if (Chkdrugs.Checked == true)
        {
            objBELBillInfo.P_drugs = true;
        }
        else
        {
            objBELBillInfo.P_drugs = false;
        }
        if (ChkECG.Checked == true)
        {
            objBELBillInfo.P_ECG = true;
        }
        else
        {
            objBELBillInfo.P_ECG = false;
        }
        if (Chkcsr.Checked == true)
        {
            objBELBillInfo.P_csr = true;
        }
        else
        {
            objBELBillInfo.P_csr = false;
        }
        if (ChkLab.Checked == true)
        {
            objBELBillInfo.P_Lab = true;
        }
        else
        {
            objBELBillInfo.P_Lab = false;
        }
        if (Chkroom.Checked == true)
        {
            objBELBillInfo.P_room= true;
        }
        else
        {
            objBELBillInfo.P_room = false;
        }
        if (ChkRBS.Checked == true)
        {
            objBELBillInfo.P_RBS = true;
        }
        else
        {
            objBELBillInfo.P_RBS = false;
        }
        if (ChkOXYGEN.Checked == true)
        {
            objBELBillInfo.P_OXYGEN = true;
        }
        else
        {
            objBELBillInfo.P_OXYGEN = false;
        }
        if (ChkNEBULIZER.Checked == true)
        {
            objBELBillInfo.P_NEBULIZER = true;
        }
        else
        {
            objBELBillInfo.P_NEBULIZER = false;
        }
        //------------------
        if (ChkxRayB.Checked == true)
        {
            objBELBillInfo.P_Xrayb = true;
        }
        else
        {
            objBELBillInfo.P_Xrayb = false;
        }
        if (ChkORB.Checked == true)
        {
            objBELBillInfo.P_korb = true;
        }
        else
        {
            objBELBillInfo.P_korb = false;
        }
        if (ChkDrugsB.Checked == true)
        {
            objBELBillInfo.P_drugsb = true;
        }
        else
        {
            objBELBillInfo.P_drugsb = false;
        }
        if (ChkECGB.Checked == true)
        {
            objBELBillInfo.P_ECGb = true;
        }
        else
        {
            objBELBillInfo.P_ECGb = false;
        }
        if (ChkCSRB.Checked == true)
        {
            objBELBillInfo.P_csrb = true;
        }
        else
        {
            objBELBillInfo.P_csrb = false;
        }
        if (ChkLABB.Checked == true)
        {
            objBELBillInfo.P_Labb = true;
        }
        else
        {
            objBELBillInfo.P_Labb = false;
        }
        if (ChkRoomB.Checked == true)
        {
            objBELBillInfo.P_roomb = true;
        }
        else
        {
            objBELBillInfo.P_roomb = false;
        }
        if (ChkRBSB.Checked == true)
        {
            objBELBillInfo.P_RBSb = true;
        }
        else
        {
            objBELBillInfo.P_RBSb = false;
        }
        if (ChkOXYGENB.Checked == true)
        {
            objBELBillInfo.P_OXYGENb = true;
        }
        else
        {
            objBELBillInfo.P_OXYGENb = false;
        }
        if (ChkNEBULIZERB.Checked == true)
        {
            objBELBillInfo.P_NEBULIZERb = true;
        }
        else
        {
            objBELBillInfo.P_NEBULIZERb = false;
        }
       // objBELBillInfo.CreatedBy = Convert.ToString(Session["username"]);
       
        objBELBillInfo.CreatedBy = Convert.ToString(Session["username"]);
        objBELBillInfo.BranchId = Convert.ToInt32(Session["Branchid"]);
        objBELBillInfo.FId = Convert.ToInt32(Session["FId"]);
        objBELBillInfo.Remark = txtremarks.Text;

        returns = objDALBillInfo.InsertIPD_dISCHARGEsLIP(objBELBillInfo);

        ViewState["BillPaymentId"] = Convert.ToInt32(returns[0]);
        lblMessage.Text = "Record Saved Successfully";
      //  Clear();
    }
   

    public void UpdateDepositMaster()
    {
        objBELBillInfo.PatRegId = Convert.ToInt32(lblRegNo.Text);
       // objBELBillInfo.DepositAmount = -(Convert.ToDecimal(txtAmtPaid.Text));
        objBELBillInfo.CreatedBy = Convert.ToString(Session["username"]);
        objBELBillInfo.BranchId = Convert.ToInt32(Session["Branchid"]);
        objBELBillInfo.FId = Convert.ToInt32(Session["FId"]);
        objBELBillInfo.BillType = "Withdrawal";
        objBELBillInfo.Remark = "IPD Bill Advance";
        objBELBillInfo.PaymentType = "0";
        objBELBillInfo.flag = "AdvanceReceipt";
        objDALBillInfo.InsertDepositTransaction(objBELBillInfo);
       
    }



    protected void btnIPDBill_Click(object sender, EventArgs e)
    {
        //Response.Redirect("~/IpdBillForPatientServices.aspx?RegId=137555&IpdId=12", false);
        string response = @"~/IpdBillForPatientServices.aspx?RegId=" + lblRegNo.Text + "&IpdId=" + lblIPDNo.Text;

        Response.Redirect(string.Format(response),false);
        return;
    }
  

    private void InsertCancelReceiptInBill()
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
        // string Message = "";
        BELBillInfo objBELBillInfo = new BELBillInfo();
        // objBELBillInfo.BillNo = Convert.ToInt32(lblBillNo.Text);
        // int ReceiptNo = objDALBillInfo.GetMaxIpdReceiptNo(Convert.ToInt32(Session["FId"]));
       // objBELBillInfo.ReceiptNew = Convert.ToInt32(ddlreceipts.SelectedValue);
        //ViewState["ReceiptNo"] = objBELBillInfo.ReceiptNew;
        objBELBillInfo.PatRegId = Convert.ToInt32(lblRegNo.Text);
        objBELBillInfo.BillDate = System.DateTime.Now;
        objBELBillInfo.IpdNo = Convert.ToInt32(lblIPDNo.Text);
        objBELBillInfo.BillNo = Convert.ToInt32(lblIPDNo.Text);
       // objBELBillInfo.Remark = txtRemark.Value;
        objBELBillInfo.CreatedBy = Convert.ToString(Session["username"]);
       // objBELBillInfo.ReceiptNo = Convert.ToInt32(ddlreceipts.SelectedValue);


        // objBELBillInfo.CreatedBy = Convert.ToString(Session["username"]);
        objBELBillInfo.BranchId = Convert.ToInt32(Session["Branchid"]);
        objBELBillInfo.FId = Convert.ToInt32(Session["FId"]);

        returns = objDALBillInfo.InsertIPD_CancelReceiptTransaction(objBELBillInfo);
             //ViewState["BillPaymentId"] = Convert.ToInt32(returns[0]);
        lblMessage.Text = "cancel receipt Saved Successfully";
      
    }


    public void CheckIpdDischargeSlip(int Patregid,int IPDNo)
    {
        SqlConnection conn = DataAccess.ConInitForDC();
        conn.Open();

        using (SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM IPD_DischargeSlip where PatRegId=" + Convert.ToInt32(Patregid) + " and Ipdno=" + IPDNo + " ", conn))
        {
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                btnsave.Enabled = false;
                chkFinanceApprove.Enabled = true;
                if (Convert.ToBoolean( dt.Rows[0]["Xray"]) == true)
                {                   
                    chkXray.Checked = true;
                }
                else
                {
                    chkXray.Checked = false;
                }
                if (Convert.ToBoolean( dt.Rows[0]["kor"]) == true)
                {
                   Chkor.Checked = true;
                }
                else
                {
                    Chkor.Checked = false;
                }
                if (Convert.ToBoolean(dt.Rows[0]["drugs"]) == true)
                {
                    Chkdrugs.Checked = true;
                }
                else
                {
                    Chkdrugs.Checked = false;
                }
                if (Convert.ToBoolean(dt.Rows[0]["ECG"]) == true)
                {
                    ChkECG.Checked = true;
                }
                else
                {
                    ChkECG.Checked = false;
                }

                if (Convert.ToBoolean(dt.Rows[0]["csr"]) == true)
                {
                    Chkcsr.Checked = true;
                }
                else
                {
                    Chkcsr.Checked = false;
                }
                if (Convert.ToBoolean(dt.Rows[0]["Lab"]) == true)
                {
                    ChkLab.Checked = true;
                }
                else
                {
                    ChkLab.Checked = false;
                }
                if (Convert.ToBoolean(dt.Rows[0]["room"]) == true)
                {
                    Chkroom.Checked = true;
                }
                else
                {
                    Chkroom.Checked = false;
                }
                if (Convert.ToBoolean(dt.Rows[0]["RBS"]) == true)
                {
                    ChkRBS.Checked = true;
                }
                else
                {
                    ChkRBS.Checked = false;
                }
                if (Convert.ToBoolean(dt.Rows[0]["OXYGEN"]) == true)
                {
                    ChkOXYGEN.Checked = true;
                }
                else
                {
                    ChkOXYGEN.Checked = false;
                }
                if (Convert.ToBoolean(dt.Rows[0]["NEBULIZER"]) == true)
                {
                    ChkNEBULIZER.Checked = true;
                }
                else
                {
                    ChkNEBULIZER.Checked = false;
                }
               //---------------------------------------
                if (Convert.ToBoolean(dt.Rows[0]["XrayB"]) == true)
                {
                    ChkxRayB.Checked = true;
                }
                else
                {
                    ChkxRayB.Checked = false;
                }
                if (Convert.ToBoolean(dt.Rows[0]["korB"]) == true)
                {
                    ChkORB.Checked = true;
                }
                else
                {
                    ChkORB.Checked = false;
                }
                if (Convert.ToBoolean(dt.Rows[0]["drugsB"]) == true)
                {
                    ChkDrugsB.Checked = true;
                }
                else
                {
                    ChkDrugsB.Checked = false;
                }
                if (Convert.ToBoolean(dt.Rows[0]["ECGB"]) == true)
                {
                    ChkECGB.Checked = true;
                }
                else
                {
                    ChkECGB.Checked = false;
                }

                if (Convert.ToBoolean(dt.Rows[0]["csrB"]) == true)
                {
                    ChkCSRB.Checked = true;
                }
                else
                {
                    ChkCSRB.Checked = false;
                }
                if (Convert.ToBoolean(dt.Rows[0]["LabB"]) == true)
                {
                    ChkLABB.Checked = true;
                }
                else
                {
                    ChkLABB.Checked = false;
                }
                if (Convert.ToBoolean(dt.Rows[0]["roomB"]) == true)
                {
                    ChkRoomB.Checked = true;
                }
                else
                {
                    ChkRoomB.Checked = false;
                }
                if (Convert.ToBoolean(dt.Rows[0]["RBSB"]) == true)
                {
                    ChkRBSB.Checked = true;
                }
                else
                {
                    ChkRBSB.Checked = false;
                }
                if (Convert.ToBoolean(dt.Rows[0]["OXYGENB"]) == true)
                {
                    ChkOXYGENB.Checked = true;
                }
                else
                {
                    ChkOXYGENB.Checked = false;
                }
                if (Convert.ToBoolean(dt.Rows[0]["NEBULIZERB"]) == true)
                {
                    ChkNEBULIZERB.Checked = true;
                }
                else
                {
                    ChkNEBULIZERB.Checked = false;
                }
                txtremarks.Text = Convert.ToString(dt.Rows[0]["Remarks"]);
            }
            else
            {
              //  btndischarged.Enabled = true;

            }

        }
        conn.Close();
        conn.Dispose();

    }
    protected void chkFinanceApprove_CheckedChanged(object sender, EventArgs e)
    {
        if (chkFinanceApprove.Checked == true)
        {   
                int RegId = Convert.ToInt32(Request.QueryString["RegId"]);
                int IpdId = Convert.ToInt32(Request.QueryString["IpdId"]);
                objDALBillInfo.Update_DischargeFinanceApprove(RegId, IpdId, Convert.ToString(Session["username"]));
                lblMessage.Text = "Finance approve Successfully";
                lblfinance.Text = "Finance approve Successfully";
        }
    }
}