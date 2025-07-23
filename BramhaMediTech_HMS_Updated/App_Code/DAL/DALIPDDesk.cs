using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
/// <summary>
/// Summary description for DALIPDDesk
/// </summary>
public class DALIPDDesk
{
    BELOPDPatReg objBELIpd = new BELOPDPatReg();
	public DALIPDDesk()
	{
		//
		// TODO: Add constructor logic here
		//

	}
   
    public DataSet FillRoomTypes( int FId,int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_BindRoomTypes", con);
        cmd.CommandType=CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@FId", FId);
        cmd.Parameters.AddWithValue("@BranchId",BranchId);

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();

        try
        {
            da.Fill(ds);
        }
        catch (SqlException)
        {
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
        return ds;
    }
    public DataTable FillBeds(int RoomId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_BindBeds", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@RoomId", RoomId);
        //cmd.Parameters.AddWithValue("@BranchId", BranchId);

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();

        try
        {
            da.Fill(dt);
        }
        catch (SqlException)
        {
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
        return dt;
    }
    public DataTable BindRooms(int RoomTypeId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_BindRooms", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@RTypeId", RoomTypeId);
        //cmd.Parameters.AddWithValue("@BranchId", BranchId);

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();

        try
        {
            da.Fill(dt);
        }
        catch (SqlException)
        {
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
        return dt;
    }
    public DataSet FillBillServices(string ServiceType)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_FillTypeWiseIPDBillServices", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ServiceType", ServiceType);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds);
        }
        catch (SqlException)
        {
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
        return ds;

    }
    public DataSet FillASA()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_FillASA", con);
        cmd.CommandType = CommandType.StoredProcedure;
       
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds);
        }
        catch (SqlException)
        {
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
        return ds;

    }

    public BELOPDPatReg GetIpdPatientInformation(BELOPDPatReg ObjBELIpdInfo)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetIpdPatientInformation", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@IpdId", ObjBELIpdInfo.IpdId);
        cmd.Parameters.AddWithValue("@PatRegId", ObjBELIpdInfo.PatRegId);
        cmd.Parameters.AddWithValue("@FId", ObjBELIpdInfo.FId);
        cmd.Parameters.AddWithValue("@BranchId", ObjBELIpdInfo.BranchId);
        SqlDataReader sdr = cmd.ExecuteReader();

        while (sdr.Read())
        {
            objBELIpd.PatRegId =Convert.ToInt32(sdr["PatRegId"]);
            objBELIpd.EntryDate = Convert.ToString(sdr["EntryDate"]);
            objBELIpd.EntryTime = Convert.ToString(sdr["EntryTime"]);
            objBELIpd.IpdNo = Convert.ToInt32(sdr["IpdNo"]);
            objBELIpd.PatientName = Convert.ToString(sdr["PatientName"]);
            objBELIpd.PatMainType = Convert.ToString(sdr["PatMainType"]);

            objBELIpd.Sponsor2 = Convert.ToString(sdr["Sponsor2"]);
            objBELIpd.Diagnosis = Convert.ToString(sdr["Sponsor"]);
            objBELIpd.ProcedureName = Convert.ToString(sdr["ProcedureName"]);
            objBELIpd.RType = Convert.ToString(sdr["RType"]);
            objBELIpd.RoomName = Convert.ToString(sdr["RoomName"]);
            objBELIpd.BedName = Convert.ToString(sdr["BedName"]);
            objBELIpd.DRName = Convert.ToString(sdr["DrName"]);
            objBELIpd.PatientInsuType = Convert.ToString(sdr["PatientInsuType"]);
            objBELIpd.VisitingNo = Convert.ToInt32(sdr["VisitingNo"]);
            objBELIpd.FullDeptName = Convert.ToString(sdr["DeptName"]);

            objBELIpd.ContactPerson1 = Convert.ToString(sdr["ContactPerson1"]);
            objBELIpd.Contact1 = Convert.ToString(sdr["Contact1"]);
            objBELIpd.RelationName = Convert.ToString(sdr["RelationName"]);
            objBELIpd.IsAdmited = Convert.ToBoolean(sdr["IsAdmited"]);

            objBELIpd.RecoDate = Convert.ToString(sdr["RecoDate"]);
            objBELIpd.RecoTime = Convert.ToString(sdr["RecoTime"]);
            objBELIpd.RecoBy = Convert.ToString(sdr["RecoBy"]);
        }
        con.Close();
        con.Dispose();
        return objBELIpd;
    }
    public string GetIPDRoomcharges(int PatRegId,int FId,int BranchId,int IpdId,int ServiceId)
    {
        string Charges = "";
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetIpdRoomServiceCharges", con);
        cmd.CommandType = CommandType.StoredProcedure;        
        cmd.Parameters.AddWithValue("@PatRegId", PatRegId);
        cmd.Parameters.AddWithValue("@IpdId", IpdId);
       
        cmd.Parameters.AddWithValue("@ServiceId", ServiceId);
        cmd.Parameters.AddWithValue("@FId", FId);
        cmd.Parameters.AddWithValue("@BranchId",BranchId);
        SqlDataReader sdr = cmd.ExecuteReader();

        while (sdr.Read())
        {
            Charges = Convert.ToString(sdr["Rate"]);
        }
        con.Close();
        con.Dispose();
        return Charges;
    }
    public DataTable BindRooms_AdmitPAtient(string PatRegId, int IpdNo, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_BindBeds_AdmisionPAtient", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PatRegId", PatRegId);
        cmd.Parameters.AddWithValue("@IpdNo", IpdNo);
        cmd.Parameters.AddWithValue("@BranchId", BranchId);

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();

        try
        {
            da.Fill(dt);
        }
        catch (SqlException)
        {
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
        return dt;
    }
    public DataTable BillDeskDischarge(int PatRegid, int IPDNo, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetBillDeskDischargeStatus", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PatRegid", PatRegid);
        cmd.Parameters.AddWithValue("@IPDNo", IPDNo);
        cmd.Parameters.AddWithValue("@BranchId", BranchId);

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();

        try
        {
            da.Fill(dt);
        }
        catch (SqlException)
        {
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
        return dt;
    }

    public BELOPDPatReg SelectDischargeSummary(BELOPDPatReg ObjBELIpdInfo)
    {
        BELBillInfo obj = new BELBillInfo();
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_getIPDDischargeSummary", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@ipdno", ObjBELIpdInfo.IpdNo);
            cmd.Parameters.AddWithValue("@Patregid", ObjBELIpdInfo.PatRegId);

            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {

                objBELIpd.P_Procedure = Convert.ToString(sdr["ProcedureD"]);
                objBELIpd.P_ProvDiag = Convert.ToString(sdr["ProvDiag"]);
                objBELIpd.P_Complant = Convert.ToString(sdr["Complant"]);
                objBELIpd.P_CaseSummary = Convert.ToString(sdr["CaseSummary"]);
                objBELIpd.P_FinalDiagnosis = Convert.ToString(sdr["FinalDiagnosis"]);
                objBELIpd.P_Surgan = Convert.ToString(sdr["Surgan"]);

                objBELIpd.P_OTNote = Convert.ToString(sdr["OTNote"]);
                objBELIpd.P_Anesthesia = Convert.ToString(sdr["Anesthesia"]);
                objBELIpd.P_Anesthetist = Convert.ToString(sdr["Anesthetist"]);
                objBELIpd.P_OnAdmissionDet = Convert.ToString(sdr["OnAdmissionDet"]);
                objBELIpd.P_Treatment = Convert.ToString(sdr["Treatment"]);

                objBELIpd.P_ConDischarge = Convert.ToString(sdr["ConDischarge"]);
                objBELIpd.P_ReasonDischarge = Convert.ToString(sdr["ReasonDischarge"]);
                objBELIpd.P_ProcedureDateT = Convert.ToDateTime(sdr["ProcedureDate"]);
                objBELIpd.P_OperationNote = Convert.ToString(sdr["OperationNote"]);
                objBELIpd.P_NextFollowUp = Convert.ToString(sdr["NextFollowUp"]);

                objBELIpd.P_TreatmentAdvice = Convert.ToString(sdr["TreatmentAdvice"]);
                objBELIpd.P_GeneralRemark = Convert.ToString(sdr["GeneralRemark"]);







            }
            //return obj;
            return objBELIpd;
        }

        catch (SqlException)
        {
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
    public DataTable GetNurseWard(string UserName, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_GetNurseWard", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@UserName", UserName);
        cmd.Parameters.AddWithValue("@BranchId", BranchId);

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable ds = new DataTable();

        try
        {
            da.Fill(ds);
        }
        catch (SqlException)
        {
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
        return ds;
    }
    public static DataTable NurseAssignToWardPatient(string PatRegId, string RTypeId, string WardAssign, int branchid, int FId)
    {
        SqlConnection conn = DataAccess.ConInitForDC();
        //conn.Open();
        // SqlConnection conn = new SqlConnection(ConnectionString.Connectionstring);
        string sql = "SELECT        RoomType.RType, RoomMst.RoomName, IpdRegistration.IpdNo, IpdRegistration.PatRegId, IpdRegistration.IpdId, IpdRegistration.EntryDate, IpdRegistration.EntryTime, IpdRegistration.DeptId, IpdRegistration.PrimaryDoc, " +
                 "   IpdRegistration.SecodaryDoc, IpdRegistration.ReferenceDoc, IpdRegistration.PatientMainCategoryId, IpdRegistration.ContactPerson1, IpdRegistration.ContactPerson2, IpdRegistration.Relation1, IpdRegistration.Relation2, " +
                 "   IpdRegistration.Contact1, IpdRegistration.Contact2, IpdRegistration.BedId, IpdRegistration.IsAdmited, IpdRegistration.CreatedBy, IpdRegistration.CreatedOn, IpdRegistration.FId, IpdRegistration.BranchId,  " +
                 "   IpdRegistration.UpdatedBy, IpdRegistration.UpdatedOn, IpdRegistration.IsUniversalPrecaution, IpdRegistration.IsEmergency, BedMst.BedName, AlloctnOfBed.PatStatus, AlloctnOfBed.DateOfAdmission,  " +
                 "   HospEmpMst.Title + ' ' + HospEmpMst.Empname AS Empname, RoomMst.RTypeId, Initial.Title + ' ' + PatientInformation.FirstName AS FirstName, PatientInformation.TitleId, Initial.Title, HospEmpMst.Title AS Expr1, " +
                 "   ISNULL(IpdBillMaster.BillAmount, 0) AS BillAmount, ISNULL(IpdBillMaster.InvoiceNo, 0) AS InvoiceNo, IpdBillMaster.BillNo, PatMainType.PatMainType, PatientInsuType.PatientInsuType " +
                 "   FROM            PatMainType INNER JOIN " +
                 "   IpdRegistration ON PatMainType.PatMainTypeId = IpdRegistration.PatientMainCategoryId INNER JOIN " +
                 "   PatientInsuType ON PatMainType.PatMainTypeId = PatientInsuType.PatMainTypeId AND IpdRegistration.PatientSubCategoryId = PatientInsuType.PatientInsuTypeId LEFT OUTER JOIN " +
                 "   BedMst INNER JOIN " +
                 "   AlloctnOfBed ON BedMst.BedId = AlloctnOfBed.BedId INNER JOIN " +
                 "   RoomMst ON BedMst.RoomId = RoomMst.RoomId INNER JOIN " +
                 "   RoomType ON RoomMst.RTypeId = RoomType.RTypeId ON IpdRegistration.IpdNo = AlloctnOfBed.IpdNo LEFT OUTER JOIN " +
                 "   IpdBillMaster ON IpdRegistration.IpdNo = IpdBillMaster.IpdNo LEFT OUTER JOIN " +
                 "   PatientInformation LEFT OUTER JOIN " +
                 "   Initial ON PatientInformation.TitleId = Initial.TitleId ON IpdRegistration.PatRegId = PatientInformation.PatRegId LEFT OUTER JOIN " +
                 "   HospEmpMst ON IpdRegistration.PrimaryDoc = HospEmpMst.DrId where (IpdRegistration.IsAdmited = 1) AND (AlloctnOfBed.PatStatus = 'Admitted')  and  IpdRegistration.branchid=" + branchid + " and  IpdRegistration.FId=" + FId + " "; //and FID='" + FID + "'
        // " + WardAssign + " and
        if (PatRegId != "" && PatRegId != "0")
        {
            sql = sql + " and " + " IpdRegistration.PatRegId = '" + PatRegId + "'";
        }

        if (RTypeId != "0")
        {
            sql = sql + " and " + " RoomMst.RTypeId = '" + RTypeId + "'";
        }
        //if (RepDoneBy != "")
        //{
        //    sql = sql + " and " + " VW_patlbvw.DocumentDate = '" + RepDoneBy + "'";
        //}

        sql = sql + " order by  IpdRegistration.IpdNo asc ";
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        DataTable ds = new DataTable();
        try
        {
            conn.Open();

            da.Fill(ds);
        }
        catch (Exception ex)
        {
            throw;
        }
        finally
        {
            try
            {
                conn.Close(); conn.Dispose();
            }
            catch (SqlException)
            {
                // Log an event in the Application Event Log.
                throw;
            }
        }
        return ds;

    }

    public BELOPDPatReg Select_IPDAdmissionSheet(BELOPDPatReg ObjBELIpdInfo)
    {
        BELBillInfo obj = new BELBillInfo();
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetOnIPD_AdmissionDetails", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@ipdno", ObjBELIpdInfo.IpdNo);
            cmd.Parameters.AddWithValue("@Patregid", ObjBELIpdInfo.PatRegId);

            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {

                objBELIpd.P_IPD_Complaints = Convert.ToString(sdr["IPD_Complaints"]);
                objBELIpd.P_IPD_OnAdmisDetails = Convert.ToString(sdr["IPD_AdmisDetails"]);
                objBELIpd.P_IPD_CaseSummary = Convert.ToString(sdr["IPD_CaseSummary"]);
                objBELIpd.P_IPD_ProvDiagnosis = Convert.ToString(sdr["IPD_ProvDiagnosis"]);
                objBELIpd.P_IPD_FinalDiagnosis = Convert.ToString(sdr["IPD_FinalDiagnosis"]);
                objBELIpd.P_IPD_History = Convert.ToString(sdr["IPD_History"]);

                objBELIpd.P_IPD_Temp = Convert.ToString(sdr["IPD_Temp"]);
                objBELIpd.P_IPD_Resp = Convert.ToString(sdr["IPD_Resp"]);
                objBELIpd.P_IPD_Height = Convert.ToString(sdr["IPD_Height"]);
                objBELIpd.P_IPD_pulse = Convert.ToString(sdr["IPD_pulse"]);
                objBELIpd.P_IPD_BP = Convert.ToString(sdr["IPD_BP"]);

                objBELIpd.P_IPD_weight = Convert.ToString(sdr["IPD_weight"]);
                objBELIpd.P_IPD_Albumin = Convert.ToString(sdr["IPD_Albumin"]);
                objBELIpd.P_IPD_sugar = Convert.ToString(sdr["IPD_sugar"]);
                objBELIpd.P_IPD_Blood = Convert.ToString(sdr["IPD_Blood"]); 
                //------------------------------------------------------------

                objBELIpd.P_foodpreferences = Convert.ToString(sdr["foodpreferences"]);
                objBELIpd.P_Describe = Convert.ToString(sdr["Describe"]);
                objBELIpd.P_BpType = Convert.ToString(sdr["BpType"]);
                objBELIpd.P_lastpoIntake = Convert.ToString(sdr["lastpoIntake"]);
                if (Convert.ToString(sdr["lastpodateintake"]) != "")
                {
                    objBELIpd.P_lastpodateintake = Convert.ToDateTime(sdr["lastpodateintake"]);
                }
                objBELIpd.P_lasttimepointak = Convert.ToString(sdr["lasttimepointak"]);
                if (Convert.ToString(sdr["lastvoidedurinedate"]) != "")
                {
                    objBELIpd.P_lastvoidedurinedate = Convert.ToDateTime(sdr["lastvoidedurinedate"]);
                }
                objBELIpd.P_lastvoidedurinetime = Convert.ToString(sdr["lastvoidedurinetime"]);
                if (Convert.ToString(sdr["lastbowelmovementdate"]) != "")
                {
                    objBELIpd.P_lastbowelmovementdate = Convert.ToDateTime(sdr["lastbowelmovementdate"]);
                }
                

                //if (objDOPayment.P_lastpodateintake == Date.getMinDate())
                //    cmd.Parameters.AddWithValue("@lastpodateintake", DBNull.Value);
                //else
                //    cmd.Parameters.AddWithValue("@lastpodateintake", objDOPayment.P_lastpodateintake);


                objBELIpd.P_lastbowelmovementtime = Convert.ToString(sdr["lastbowelmovementtime"]);
                objBELIpd.P_Vision = Convert.ToString(sdr["Vision"]);
                objBELIpd.P_Hearing = Convert.ToString(sdr["Hearing"]);
                objBELIpd.P_Speech = Convert.ToString(sdr["Speech"]);
                objBELIpd.P_Ambulation = Convert.ToString(sdr["Ambulation"]);
                objBELIpd.P_Declaration = Convert.ToString(sdr["Declaration"]);
                objBELIpd.P_RelativeName = Convert.ToString(sdr["RelativeName"]);
                if (Convert.ToString(sdr["RelativeDate"]) != "")
                {
                    objBELIpd.P_RelativeDate = Convert.ToDateTime(sdr["RelativeDate"]);
                }
                objBELIpd.P_WitnessName = Convert.ToString(sdr["WitnessName"]);
                if (Convert.ToString(sdr["WitnessDate"]) != "")
                {
                    objBELIpd.P_WitnessDate = Convert.ToDateTime(sdr["WitnessDate"]);
                }
                objBELIpd.P_Awake = Convert.ToBoolean(sdr["Awake"]);
                objBELIpd.P_Alert = Convert.ToBoolean(sdr["Alert"]);
                objBELIpd.P_Oriented = Convert.ToBoolean(sdr["Oriented"]);
                objBELIpd.P_Lethargic = Convert.ToBoolean(sdr["Lethargic"]);
                objBELIpd.P_Disoriented = Convert.ToBoolean(sdr["Disoriented"]);
                objBELIpd.P_Comatose = Convert.ToBoolean(sdr["Comatose"]);
                objBELIpd.P_surgicalHistory = Convert.ToString(sdr["surgicalHistory"]);
                objBELIpd.P_FamilyHistory = Convert.ToString(sdr["FamilyHistory"]);
                objBELIpd.P_Wound = Convert.ToString(sdr["Wound"]);
                objBELIpd.P_WoundSize = Convert.ToString(sdr["WoundSize"]); 

            }
            //return obj;
            return objBELIpd;
        }

        catch (SqlException)
        {
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }

    public BELOPDPatReg Select_IPDAdmissionSheet_1(BELOPDPatReg ObjBELIpdInfo)
    {
        BELBillInfo obj = new BELBillInfo();
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetOnIPD_AdmissionDetails", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@ipdno", objBELIpd.IpdNo);
            cmd.Parameters.AddWithValue("@Patregid", objBELIpd.PatRegId);

            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {

                objBELIpd.P_IPD_Complaints = Convert.ToString(sdr["IPD_Complaints"]);
                objBELIpd.P_IPD_OnAdmisDetails = Convert.ToString(sdr["IPD_AdmisDetails"]);
                objBELIpd.P_IPD_CaseSummary = Convert.ToString(sdr["IPD_CaseSummary"]);
                objBELIpd.P_IPD_ProvDiagnosis = Convert.ToString(sdr["IPD_ProvDiagnosis"]);
                objBELIpd.P_IPD_FinalDiagnosis = Convert.ToString(sdr["IPD_FinalDiagnosis"]);
                objBELIpd.P_IPD_History = Convert.ToString(sdr["IPD_History"]);

                objBELIpd.P_IPD_Temp = Convert.ToString(sdr["IPD_Temp"]);
                objBELIpd.P_IPD_Resp = Convert.ToString(sdr["IPD_Resp"]);
                objBELIpd.P_IPD_Height = Convert.ToString(sdr["IPD_Height"]);
                objBELIpd.P_IPD_pulse = Convert.ToString(sdr["IPD_pulse"]);
                objBELIpd.P_IPD_BP = Convert.ToString(sdr["IPD_BP"]);

                objBELIpd.P_IPD_weight = Convert.ToString(sdr["IPD_weight"]);
                objBELIpd.P_IPD_Albumin = Convert.ToString(sdr["IPD_Albumin"]);
                objBELIpd.P_IPD_sugar = Convert.ToString(sdr["IPD_sugar"]);
                objBELIpd.P_IPD_Blood = Convert.ToString(sdr["IPD_Blood"]);
                //------------------------------------------------------------

                objBELIpd.P_foodpreferences = Convert.ToString(sdr["foodpreferences"]);
                objBELIpd.P_Describe = Convert.ToString(sdr["Describe"]);
                objBELIpd.P_BpType = Convert.ToString(sdr["BpType"]);
                objBELIpd.P_lastpoIntake = Convert.ToString(sdr["lastpoIntake"]);
                if (Convert.ToString(sdr["lastpodateintake"]) != "")
                {
                    objBELIpd.P_lastpodateintake = Convert.ToDateTime(sdr["lastpodateintake"]);
                }
                objBELIpd.P_lasttimepointak = Convert.ToString(sdr["lasttimepointak"]);
                if (Convert.ToString(sdr["lastvoidedurinedate"]) != "")
                {
                    objBELIpd.P_lastvoidedurinedate = Convert.ToDateTime(sdr["lastvoidedurinedate"]);
                }
                objBELIpd.P_lastvoidedurinetime = Convert.ToString(sdr["lastvoidedurinetime"]);
                if (Convert.ToString(sdr["lastbowelmovementdate"]) != "")
                {
                    objBELIpd.P_lastbowelmovementdate = Convert.ToDateTime(sdr["lastbowelmovementdate"]);
                }
               
                objBELIpd.P_lastbowelmovementtime = Convert.ToString(sdr["lastbowelmovementtime"]);
                objBELIpd.P_Vision = Convert.ToString(sdr["Vision"]);
                objBELIpd.P_Hearing = Convert.ToString(sdr["Hearing"]);
                objBELIpd.P_Speech = Convert.ToString(sdr["Speech"]);
                objBELIpd.P_Ambulation = Convert.ToString(sdr["Ambulation"]);
                objBELIpd.P_Declaration = Convert.ToString(sdr["Declaration"]);
                objBELIpd.P_RelativeName = Convert.ToString(sdr["RelativeName"]);
                if (Convert.ToString(sdr["RelativeDate"]) != "")
                {
                    objBELIpd.P_RelativeDate = Convert.ToDateTime(sdr["RelativeDate"]);
                }
                objBELIpd.P_WitnessName = Convert.ToString(sdr["WitnessName"]);
                if (Convert.ToString(sdr["WitnessDate"]) != "")
                {
                    objBELIpd.P_WitnessDate = Convert.ToDateTime(sdr["WitnessDate"]);
                }
                objBELIpd.P_Awake = Convert.ToBoolean(sdr["Awake"]);
                objBELIpd.P_Alert = Convert.ToBoolean(sdr["Alert"]);
                objBELIpd.P_Oriented = Convert.ToBoolean(sdr["Oriented"]);
                objBELIpd.P_Lethargic = Convert.ToBoolean(sdr["Lethargic"]);
                objBELIpd.P_Disoriented = Convert.ToBoolean(sdr["Disoriented"]);
                objBELIpd.P_Comatose = Convert.ToBoolean(sdr["Comatose"]);
                objBELIpd.P_surgicalHistory = Convert.ToString(sdr["surgicalHistory"]);
                objBELIpd.P_FamilyHistory = Convert.ToString(sdr["FamilyHistory"]);
                objBELIpd.P_Wound = Convert.ToString(sdr["Wound"]);
                objBELIpd.P_WoundSize = Convert.ToString(sdr["WoundSize"]);

            }
            //return obj;
            return objBELIpd;
        }

        catch (SqlException)
        {
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
    public DataTable Get_OTNote(int OTID, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_Get_OTNote", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@OTID", OTID);
        cmd.Parameters.AddWithValue("@BranchId", BranchId);

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable ds = new DataTable();

        try
        {
            da.Fill(ds);
        }
        catch (SqlException)
        {
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
        return ds;
    }
    public string DeleteOT_Patient(int OTId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_OtReg_Delete", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@OTId", OTId);
            object Result = cmd.ExecuteScalar();
            return Convert.ToString(Result);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }


    public DataTable Get_OTOperationCharges(string OperType, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_Get_OTOperationCharges", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@OperType", OperType);       
        cmd.Parameters.AddWithValue("@BranchId", BranchId);

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();

        try
        {
            da.Fill(dt);
        }
        catch (SqlException)
        {
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
        return dt;
    }
}