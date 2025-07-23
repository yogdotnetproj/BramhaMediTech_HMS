using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for clsEmr
/// </summary>
public class clsEmr
{
    //public string EmrId { get; set; }
    //public string Patientregid { get; set; }
    //public string opd { get; set; }
    //public string ipd { get; set; }
    //public string branchid { get; set; }
    //public string createdby { get; set; }
    //public string createdon { get; set; }
    //public string updatedby { get; set; }
    //public string updatedon { get; set; }
    //public string chiefcomplaints { get; set; }
    //public string allergies { get; set; }
    //public string medicalhistory { get; set; }
    //public string ht { get; set; }
    //public string wt { get; set; }
    //public string pulse { get; set; }
    //public string bp { get; set; }
    //public string resp { get; set; }
    //public string spo2 { get; set; }
    //public string chest { get; set; }
    //public string a { get; set; }
    //public string b { get; set; }
    //public string c { get; set; }
    //public string d { get; set; }
    //public string e { get; set; }
    //public string pasthistory { get; set; }
    //public string personalhistory { get; set; }
    //public string familyhistory { get; set; }
    //public string surgicalhistory { get; set; }
    //public string f { get; internal set; }
    public clsEmr()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataSet FillRoomTypeCombo()
    {

        SqlConnection con = DataAccess.ConInitForDC();
        SqlDataAdapter da = new SqlDataAdapter("Sp_RoomTypeFillDrop", con);
        DataSet ds = new DataSet();
        con.Open();
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
    public DataSet ReadDataHistoryList()
    {
        DataSet dt = new DataSet();
        try
        {


            using (SqlConnection connection =
                       DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetHistoryListData", connection))
                {
                    connection.Open();

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                    connection.Close();
                    connection.Dispose();
                }
            }
        }
        catch (Exception)
        {
        }
        return dt;
    }
    public DataTable GetGeneralEmrDetailsEdit(string patregId, string opd, string ipd, string branchid)
    {
        DataTable dt = new DataTable();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;

            using (SqlConnection connection =
                      DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetGeneralEmrDetailsByPatientId", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Patientregid", SqlDbType.VarChar).Value = patregId;
                    cmd.Parameters.Add("@Opd", SqlDbType.VarChar).Value = opd;
                    cmd.Parameters.Add("@Ipd", SqlDbType.VarChar).Value = ipd;
                    cmd.Parameters.Add("@BranchId", SqlDbType.VarChar).Value = branchid;

                    connection.Open();

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                    connection.Close();
                    connection.Dispose();
                    return dt;
                    
                }
            }
        }
        catch (Exception)
        {

            return null;
        }

    }

    public DataSet ReadAllDetails(string patregId)
    {
        DataSet dt = new DataSet();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;
            using (SqlConnection connection =
                      DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetEmrAllDetails", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Patientregid", SqlDbType.VarChar).Value = patregId;
                    connection.Open();

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                    connection.Close();
                    connection.Dispose();
                }
            }
        }
        catch (Exception)
        {
        }
        return dt;
    }

    public int Save_DrOTRegistration( int SurganDrId, string OperationName, string ScheduleDate, string Remarks,string CreatedBy,int Branchid)
    {
        try
        {

            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;

            using (SqlConnection connection = DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("usp_InsertDrOTRegistration", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                 

                    cmd.Parameters.Add("@SurganDrId", SqlDbType.Int).Value = SurganDrId;
                    cmd.Parameters.Add("@OperationName", SqlDbType.NVarChar,250).Value = OperationName;
                    cmd.Parameters.Add("@Remarks", SqlDbType.NVarChar,250).Value = Remarks;
                    cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = CreatedBy;
                    cmd.Parameters.Add("@BranchId", SqlDbType.VarChar).Value = Branchid;

                    if (ScheduleDate == "")
                        cmd.Parameters.Add(new SqlParameter("@ScheduleDate", SqlDbType.DateTime)).Value = DBNull.Value;
                    else
                        cmd.Parameters.Add(new SqlParameter("@ScheduleDate", SqlDbType.DateTime)).Value = ScheduleDate;

                    connection.Open();

                    int rowsAffected = Convert.ToInt32(cmd.ExecuteScalar());

                    connection.Close();
                    connection.Dispose();
                    return rowsAffected;
                }
            }
        }
        catch (Exception ex)
        {
            return -1;
        }
    }


    public int SaveEmr(string type, string RegId, string PatientName, string Ipd, string Opd, string EntryDate, string BranchId, string createdby, string createdon,
       string updatedby, string updatedon, string chiefcomplaints, string allergies, string medicalhistory, string ht, string wt, string pulse,
       string bp, string resp, string spo2, string chest, string a, string b, string c, string d, string e, string surgicalhistory,
       string pastHistory, string personalHistory, string familyHistory, string EmrId, string pastHis, string persHis, string famHis, string Note, int DrId, string Diagno, string ProvDiagno, string FollowUpDate, string ICDCode)
    {
        try
        {

            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;

            using (SqlConnection connection = DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("usp_InsertUpdateEmr", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@type", SqlDbType.Int).Value = Convert.ToInt32(type);
                    cmd.Parameters.Add("@RegId", SqlDbType.VarChar).Value = RegId;
                    cmd.Parameters.Add("@PatientName", SqlDbType.VarChar).Value = PatientName;
                    cmd.Parameters.Add("@Ipd", SqlDbType.VarChar).Value = Ipd;
                    cmd.Parameters.Add("@Opd", SqlDbType.VarChar).Value = Opd;
                    cmd.Parameters.Add("@EntryDate", SqlDbType.VarChar).Value = EntryDate;
                    cmd.Parameters.Add("@BranchId", SqlDbType.VarChar).Value = BranchId;
                    cmd.Parameters.Add("@createdby", SqlDbType.VarChar).Value = createdby;
                    cmd.Parameters.Add("@createdon", SqlDbType.VarChar).Value = createdon;
                    cmd.Parameters.Add("@updatedby", SqlDbType.VarChar).Value = updatedby;
                    cmd.Parameters.Add("@updatedon", SqlDbType.VarChar).Value = updatedon;
                    cmd.Parameters.Add("@chiefcomplaints", SqlDbType.VarChar).Value = chiefcomplaints;
                    cmd.Parameters.Add("@allergies", SqlDbType.VarChar).Value = allergies;
                    cmd.Parameters.Add("@medicalhistory", SqlDbType.VarChar).Value = medicalhistory;
                    cmd.Parameters.Add("@ht", SqlDbType.VarChar).Value = ht;
                    cmd.Parameters.Add("@wt", SqlDbType.VarChar).Value = wt;
                    cmd.Parameters.Add("@pulse", SqlDbType.VarChar).Value = pulse;
                    cmd.Parameters.Add("@bp", SqlDbType.VarChar).Value = bp;
                    cmd.Parameters.Add("@resp", SqlDbType.VarChar).Value = resp;
                    cmd.Parameters.Add("@spo2", SqlDbType.VarChar).Value = spo2;
                    cmd.Parameters.Add("@chest", SqlDbType.VarChar).Value = chest;
                    cmd.Parameters.Add("@a", SqlDbType.VarChar).Value = a;
                    cmd.Parameters.Add("@b", SqlDbType.VarChar).Value = b;
                    cmd.Parameters.Add("@c", SqlDbType.VarChar).Value = c;
                    cmd.Parameters.Add("@d", SqlDbType.VarChar).Value = d;
                    cmd.Parameters.Add("@e", SqlDbType.VarChar).Value = e;
                    cmd.Parameters.Add("@surgicalhistory", SqlDbType.VarChar).Value = surgicalhistory;
                    cmd.Parameters.Add("@pastHistory", SqlDbType.VarChar).Value = pastHistory;
                    cmd.Parameters.Add("@personalHistory", SqlDbType.VarChar).Value = personalHistory;
                    cmd.Parameters.Add("@familyHistory", SqlDbType.VarChar).Value = familyHistory;
                    cmd.Parameters.Add("@EmrId", SqlDbType.VarChar).Value = EmrId;
                    cmd.Parameters.Add("@pastHis", SqlDbType.VarChar).Value = pastHis;
                    cmd.Parameters.Add("@perHis", SqlDbType.VarChar).Value = persHis;
                    cmd.Parameters.Add("@famHis", SqlDbType.VarChar).Value = famHis;
                    cmd.Parameters.Add("@Note", SqlDbType.NVarChar, 3500).Value = Note;
                    cmd.Parameters.Add("@DrId", SqlDbType.Int).Value = DrId;
                    cmd.Parameters.Add("@Diagno", SqlDbType.VarChar).Value = Diagno;
                    cmd.Parameters.Add("@ProvDiagno", SqlDbType.VarChar).Value = ProvDiagno;
                    cmd.Parameters.Add("@ICDCode", SqlDbType.VarChar).Value = ICDCode;
                    

                    if (FollowUpDate=="")
                        cmd.Parameters.Add(new SqlParameter("@FollowUpDate", SqlDbType.DateTime)).Value = DBNull.Value;
                    else
                        cmd.Parameters.Add(new SqlParameter("@FollowUpDate", SqlDbType.DateTime)).Value = FollowUpDate;

                    connection.Open();

                    int rowsAffected = Convert.ToInt32(cmd.ExecuteScalar());

                    connection.Close();
                    connection.Dispose();
                    return rowsAffected;
                }
            }
        }
        catch (Exception ex)
        {
            return -1;
        }
    }


    public int SaveEmr_Observ(string type, string RegId, string PatientName, string Ipd, string Opd, string EntryDate, string BranchId, string createdby, string createdon,
        string updatedby, string updatedon, string chiefcomplaints, string allergies, string medicalhistory, string ht, string wt, string pulse, 
        string bp, string resp, string spo2, string chest, string a, string b, string c, string d, string e, string surgicalhistory,
        string pastHistory, string personalHistory, string familyHistory, string EmrId, string pastHis, string persHis, string famHis, string Note, int DrId, string Diagno, string ProvDiagno, string NurseNote, int TriageCriteria)
    {
        try
        {

            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;

            using (SqlConnection connection = DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("usp_InsertUpdateEmr_Observ", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@type", SqlDbType.Int).Value = Convert.ToInt32(type);
                    cmd.Parameters.Add("@RegId", SqlDbType.VarChar).Value = RegId;
                    cmd.Parameters.Add("@PatientName", SqlDbType.VarChar).Value = PatientName;
                    cmd.Parameters.Add("@Ipd", SqlDbType.VarChar).Value = Ipd;
                    cmd.Parameters.Add("@Opd", SqlDbType.VarChar).Value = Opd;
                    cmd.Parameters.Add("@EntryDate", SqlDbType.VarChar).Value = EntryDate;
                    cmd.Parameters.Add("@BranchId", SqlDbType.VarChar).Value = BranchId;
                    cmd.Parameters.Add("@createdby", SqlDbType.VarChar).Value = createdby;
                    cmd.Parameters.Add("@createdon", SqlDbType.VarChar).Value = createdon;
                    cmd.Parameters.Add("@updatedby", SqlDbType.VarChar).Value = updatedby;
                    cmd.Parameters.Add("@updatedon", SqlDbType.VarChar).Value = updatedon;
                    cmd.Parameters.Add("@chiefcomplaints", SqlDbType.VarChar).Value = chiefcomplaints;
                    cmd.Parameters.Add("@allergies", SqlDbType.VarChar).Value = allergies;
                    cmd.Parameters.Add("@medicalhistory", SqlDbType.VarChar).Value = medicalhistory;
                    cmd.Parameters.Add("@ht", SqlDbType.VarChar).Value = ht;
                    cmd.Parameters.Add("@wt", SqlDbType.VarChar).Value = wt;
                    cmd.Parameters.Add("@pulse", SqlDbType.VarChar).Value = pulse;
                    cmd.Parameters.Add("@bp", SqlDbType.VarChar).Value = bp;
                    cmd.Parameters.Add("@resp", SqlDbType.VarChar).Value = resp;
                    cmd.Parameters.Add("@spo2", SqlDbType.VarChar).Value = spo2;
                    cmd.Parameters.Add("@chest", SqlDbType.VarChar).Value = chest;
                    cmd.Parameters.Add("@a", SqlDbType.VarChar).Value = a;
                    cmd.Parameters.Add("@b", SqlDbType.VarChar).Value = b;
                    cmd.Parameters.Add("@c", SqlDbType.VarChar).Value = c;
                    cmd.Parameters.Add("@d", SqlDbType.VarChar).Value = d;
                    cmd.Parameters.Add("@e", SqlDbType.VarChar).Value = e;
                    cmd.Parameters.Add("@surgicalhistory", SqlDbType.VarChar).Value = surgicalhistory;
                    cmd.Parameters.Add("@pastHistory", SqlDbType.VarChar).Value = pastHistory;
                    cmd.Parameters.Add("@personalHistory", SqlDbType.VarChar).Value = personalHistory;
                    cmd.Parameters.Add("@familyHistory", SqlDbType.VarChar).Value = familyHistory;
                    cmd.Parameters.Add("@EmrId", SqlDbType.VarChar).Value = EmrId;
                    cmd.Parameters.Add("@pastHis", SqlDbType.VarChar).Value = pastHis;
                    cmd.Parameters.Add("@perHis", SqlDbType.VarChar).Value = persHis;
                    cmd.Parameters.Add("@famHis", SqlDbType.VarChar).Value = famHis;
                    cmd.Parameters.Add("@Note", SqlDbType.NVarChar,4000).Value = Note;
                    cmd.Parameters.Add("@DrId", SqlDbType.Int).Value = DrId;
                    cmd.Parameters.Add("@Diagno", SqlDbType.VarChar).Value = Diagno;
                    cmd.Parameters.Add("@ProvDiagno", SqlDbType.VarChar).Value = ProvDiagno;
                    cmd.Parameters.Add("@NurseNote", SqlDbType.NVarChar,3500).Value = NurseNote;
                    cmd.Parameters.Add("@TriageCriteria", SqlDbType.Int).Value = TriageCriteria;

                    connection.Open();

                    int rowsAffected = Convert.ToInt32(cmd.ExecuteScalar());

                    connection.Close();
                    connection.Dispose();
                    return rowsAffected;
                }
            }
        }
        catch (Exception ex)
        {
            return -1;
        }
    }

    public DataTable Get_All_EMR_Patient_Test(string patregId, string LabNo, int branchid)
    {
        DataTable dt = new DataTable();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;

            using (SqlConnection connection =
                      DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("SP_GetAllEMR_Test", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Patientregid", SqlDbType.VarChar).Value = patregId;
                    cmd.Parameters.Add("@LabNo", SqlDbType.VarChar).Value = LabNo;
                    cmd.Parameters.Add("@BranchId", SqlDbType.VarChar).Value = branchid;

                    connection.Open();

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                    connection.Close();
                    connection.Dispose();
                    return dt;
                    
                }
            }
        }
        catch (Exception)
        {

            return null;
        }

    }

    public DataTable Get_All_EMR_PatientInformation(string patregId, string LabNo,  int branchid)
    {
        DataTable dt = new DataTable();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;

            using (SqlConnection connection =
                      DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("SP_GetAllEMRPatientInfo", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Patientregid", SqlDbType.VarChar).Value = patregId;
                    cmd.Parameters.Add("@LabNo", SqlDbType.VarChar).Value = LabNo;                   
                    cmd.Parameters.Add("@BranchId", SqlDbType.VarChar).Value = branchid;

                    connection.Open();

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                    connection.Close();
                    connection.Dispose();
                    return dt;
                   
                }
            }
        }
        catch (Exception)
        {

            return null;
        }

    }

    public DataTable Get_All_Radiology_PatientInformation(string patregId, string LabNo, int branchid)
    {
        DataTable dt = new DataTable();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;

            using (SqlConnection connection =
                      DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("SP_GetRadiology_PatientInfo", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Patientregid", SqlDbType.VarChar).Value = patregId;
                    cmd.Parameters.Add("@LabNo", SqlDbType.VarChar).Value = LabNo;
                    cmd.Parameters.Add("@BranchId", SqlDbType.VarChar).Value = branchid;

                    connection.Open();

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                    connection.Close();
                    connection.Dispose();
                    return dt;
                   
                }
            }
        }
        catch (Exception)
        {

            return null;
        }

    }

    public DataTable Get_All_Radiologyt_Test(string patregId, string LabNo, int branchid)
    {
        DataTable dt = new DataTable();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;

            using (SqlConnection connection =
                      DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("SP_GetAllRadiology_Test", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Patientregid", SqlDbType.VarChar).Value = patregId;
                    cmd.Parameters.Add("@LabNo", SqlDbType.VarChar).Value = LabNo;
                    cmd.Parameters.Add("@BranchId", SqlDbType.VarChar).Value = branchid;

                    connection.Open();

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                    connection.Close();
                    connection.Dispose();
                    return dt;
                   
                }
            }
        }
        catch (Exception)
        {

            return null;
        }

    }


    public DataTable Get_AllPatientInformation_Quotation(int SurgEstimationId)
    {
        DataTable dt = new DataTable();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;

            using (SqlConnection connection =
                      DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("Sp_FillSurgeryPatientInfo", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@SurgEstimationId", SqlDbType.Int).Value = SurgEstimationId;
                    

                    connection.Open();

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                    connection.Close();
                    connection.Dispose();
                    return dt;
                   
                }
            }
        }
        catch (Exception)
        {

            return null;
        }

    }
    public DataTable GetFinalQuotation(int SurgEstimationId)
    {
        DataTable dt = new DataTable();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;

            using (SqlConnection connection =
                      DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("Sp_FillFinalQuotation", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@SurgEstimationId", SqlDbType.Int).Value = SurgEstimationId;


                    connection.Open();

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                    connection.Close();
                    connection.Dispose();
                    return dt;
                    
                }
            }
        }
        catch (Exception)
        {

            return null;
        }

    }
    public DataTable Get_SurgeryQuotationByDoc(int PatRegId,int OPDNo,int IPDNo,int BranchId)
    {
        DataTable dt = new DataTable();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;

            using (SqlConnection connection =
                      DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("Sp_GetSurgeryQuotationByDoc", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@PatRegId", SqlDbType.Int).Value = PatRegId;
                    cmd.Parameters.Add("@OpdNo", SqlDbType.Int).Value = OPDNo;
                    cmd.Parameters.Add("@BranchId", SqlDbType.Int).Value = BranchId;
                    cmd.Parameters.Add("@IpdNo", SqlDbType.Int).Value = IPDNo;

                    connection.Open();

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                    connection.Close();
                    connection.Dispose();
                    return dt;
                   
                }
            }
        }
        catch (Exception)
        {

            return null;
        }

    }

    public DataTable Get_AllPatientInformationInv(string patregId, int branchid)
    {
        DataTable dt = new DataTable();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;

            using (SqlConnection connection =
                      DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("SP_GetAllPatientInfoInv", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Patientregid", SqlDbType.VarChar).Value = patregId;
                    //cmd.Parameters.Add("@OpdNo", SqlDbType.VarChar).Value = opd;
                    //cmd.Parameters.Add("@IpdNo", SqlDbType.VarChar).Value = ipd;
                    cmd.Parameters.Add("@BranchId", SqlDbType.VarChar).Value = branchid;

                    connection.Open();

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                    connection.Close();
                    connection.Dispose();
                    return dt;
                }
               
            }
        }
        catch (Exception)
        {

            return null;
        }

    }

    public DataTable Get_AllPatientInformationInv_ReferToAdmision(string patregId, int branchid)
    {
        DataTable dt = new DataTable();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;

            using (SqlConnection connection =
                      DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("SP_GetAllPatientInfoInv_ReferToAdmision", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Patientregid", SqlDbType.VarChar).Value = patregId;
                    //cmd.Parameters.Add("@OpdNo", SqlDbType.VarChar).Value = opd;
                    //cmd.Parameters.Add("@IpdNo", SqlDbType.VarChar).Value = ipd;
                    cmd.Parameters.Add("@BranchId", SqlDbType.VarChar).Value = branchid;

                    connection.Open();

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                    connection.Close();
                    connection.Dispose();
                    return dt;
                }

            }
        }
        catch (Exception)
        {

            return null;
        }

    }

    public DataTable GetGeneralEmrDetailsEdit_Notes(string patregId, string opd, string ipd, string branchid)
    {
        DataTable dt = new DataTable();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;

            using (SqlConnection connection =
                      DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetGeneralEmrDetailsByPatientId_Note", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Patientregid", SqlDbType.VarChar).Value = patregId;
                    cmd.Parameters.Add("@Opd", SqlDbType.VarChar).Value = opd;
                    cmd.Parameters.Add("@Ipd", SqlDbType.VarChar).Value = ipd;
                    cmd.Parameters.Add("@BranchId", SqlDbType.VarChar).Value = branchid;

                    connection.Open();

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                    connection.Close();
                    connection.Dispose();
                    return dt;
                   
                }
            }
        }
        catch (Exception)
        {

            return null;
        }

    }

    public DataTable Get_AllPatientInformation_ForPAtentPortal(string UserName, string Password, int branchid)
    {
        DataTable dt = new DataTable();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;

            using (SqlConnection connection =
                      DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("SP_getDataPatientPortal", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = UserName;
                    cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = Password;
                    
                    cmd.Parameters.Add("@BranchId", SqlDbType.VarChar).Value = branchid;

                    connection.Open();

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                    connection.Close();
                    connection.Dispose();
                    return dt;
                }


            }
        }
        catch (Exception)
        {

            return null;
        }

    }

    public DataTable Get_AllICDDiagnoName( int branchid)
    {
        DataTable dt = new DataTable();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;

            using (SqlConnection connection =
                      DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("SP_GetICDDiagnoName", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                   
                    cmd.Parameters.Add("@BranchId", SqlDbType.VarChar).Value = branchid;

                    connection.Open();

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                    connection.Close();
                    connection.Dispose();
                    return dt;
                }


            }
        }
        catch (Exception)
        {

            return null;
        }

    }
    public DataTable Get_AllPatientInformation(string patregId, string opd, int ipd, int branchid)
    {
        DataTable dt = new DataTable();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;

            using (SqlConnection connection =
                      DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("SP_GetAllPatientInfo", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Patientregid", SqlDbType.VarChar).Value = patregId;
                    cmd.Parameters.Add("@OpdNo", SqlDbType.VarChar).Value = opd;
                    cmd.Parameters.Add("@IpdNo", SqlDbType.VarChar).Value = ipd;
                    cmd.Parameters.Add("@BranchId", SqlDbType.VarChar).Value = branchid;

                    connection.Open();

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                    connection.Close();
                    connection.Dispose();
                    return dt;
                }
               
               
            }
        }
        catch (Exception)
        {

            return null;
        }

    }
    public DataTable Get_AllPatientInformation_MedicalClaim(string patregId, string opd, int ipd, int branchid)
    {
        DataTable dt = new DataTable();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;

            using (SqlConnection connection =
                      DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("SP_GetAll_MedicalInsuranceClaim", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Patientregid", SqlDbType.VarChar).Value = patregId;
                    cmd.Parameters.Add("@OpdNo", SqlDbType.VarChar).Value = opd;
                    cmd.Parameters.Add("@IpdNo", SqlDbType.VarChar).Value = ipd;
                    cmd.Parameters.Add("@BranchId", SqlDbType.VarChar).Value = branchid;

                    connection.Open();

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                    connection.Close();
                    connection.Dispose();
                    return dt;
                }


            }
        }
        catch (Exception)
        {

            return null;
        }

    }

    public DataTable GetAllCaccnationRegisterCriteria(string fromage, string Agetype, int VaccianId)
    {
        DataTable dt = new DataTable();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;

            using (SqlConnection connection =
                      DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("SP_GetAllCaccnationRegisterCriteria", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@fromage", SqlDbType.VarChar).Value = fromage;
                    cmd.Parameters.Add("@Agetype", SqlDbType.VarChar).Value = Agetype;
                    cmd.Parameters.Add("@VaccianId", SqlDbType.VarChar).Value = VaccianId;
                   

                    connection.Open();

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                    connection.Close();
                    connection.Dispose();
                    return dt;
                }
               
            }
        }
        catch (Exception)
        {

            return null;
        }

    }

    public DataTable Get_AllPatientVitalTaken(string patregId, string opd, int ipd, int branchid)
    {
        DataTable dt = new DataTable();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;

            using (SqlConnection connection =
                      DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("SP_GetvitalEntry", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Patientregid", SqlDbType.VarChar).Value = patregId;
                    cmd.Parameters.Add("@OpdNo", SqlDbType.VarChar).Value = opd;
                    cmd.Parameters.Add("@IpdNo", SqlDbType.VarChar).Value = ipd;
                    cmd.Parameters.Add("@BranchId", SqlDbType.VarChar).Value = branchid;

                    connection.Open();

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                    connection.Close();
                    connection.Dispose();
                    return dt;
                }
              
            }
        }
        catch (Exception)
        {

            return null;
        }

    }

    public int SaveEmr_DailyDrNote_ReferToAdmission(string Patregid, string IpdNo, string DrNote, string Createdby, string Branchid, string Fid, string DrPlan, string Diagnosis, string Remarks, string InvestigationDetails, string TreatmentDetails, string OPDNO, string AttendingPhysican, string WardName,string BedName)
    {
        try
        {

            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;

            using (SqlConnection connection = DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("SP_IPDDrDailyNote_New_ReferToAdmission", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@Patregid", SqlDbType.VarChar).Value = Patregid;
                    cmd.Parameters.Add("@DrNote", SqlDbType.VarChar).Value = DrNote;
                    cmd.Parameters.Add("@IpdNo", SqlDbType.VarChar).Value = IpdNo;
                    cmd.Parameters.Add("@OPDNO", SqlDbType.VarChar).Value = OPDNO;
                    cmd.Parameters.Add("@Createdby", SqlDbType.VarChar).Value = Createdby;
                    cmd.Parameters.Add("@BranchId", SqlDbType.VarChar).Value = Branchid;
                    cmd.Parameters.Add("@Fid", SqlDbType.VarChar).Value = Fid;
                    cmd.Parameters.Add("@DrPlan", SqlDbType.VarChar).Value = DrPlan;
                    cmd.Parameters.Add("@Diagnosis", SqlDbType.VarChar).Value = Diagnosis;
                    cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = Remarks;
                    cmd.Parameters.Add("@InvestigationDetails", SqlDbType.VarChar).Value = InvestigationDetails;
                    cmd.Parameters.Add("@TreatmentDetails", SqlDbType.VarChar).Value = TreatmentDetails;
                    cmd.Parameters.Add("@AttendingPhysican", SqlDbType.VarChar).Value = AttendingPhysican;
                    cmd.Parameters.Add("@WardName", SqlDbType.VarChar).Value = WardName;
                    cmd.Parameters.Add("@BedName", SqlDbType.VarChar).Value = BedName;
                    connection.Open();

                    int rowsAffected = Convert.ToInt32(cmd.ExecuteScalar());

                    connection.Close();
                    connection.Dispose();
                    return rowsAffected;
                }
            }
        }
        catch (Exception ex)
        {
            return -1;
        }
    }

    public int SaveEmr_DailyDrNote(string Patregid, string IpdNo, string DrNote, string Createdby, string Branchid, string Fid, string DrPlan, string Diagnosis, string Remarks, string InvestigationDetails, string TreatmentDetails, string Allergy, string ICDCode)
    {
        try
        {

            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;

            using (SqlConnection connection = DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("SP_IPDDrDailyNote_New", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@Patregid", SqlDbType.VarChar).Value = Patregid;
                    cmd.Parameters.Add("@DrNote", SqlDbType.VarChar).Value = DrNote;
                    cmd.Parameters.Add("@IpdNo", SqlDbType.VarChar).Value = IpdNo;

                    cmd.Parameters.Add("@Createdby", SqlDbType.VarChar).Value = Createdby;
                    cmd.Parameters.Add("@BranchId", SqlDbType.VarChar).Value = Branchid;
                    cmd.Parameters.Add("@Fid", SqlDbType.VarChar).Value = Fid;
                    cmd.Parameters.Add("@DrPlan", SqlDbType.VarChar).Value = DrPlan;
                    cmd.Parameters.Add("@Diagnosis", SqlDbType.VarChar).Value = Diagnosis;
                    cmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = Remarks;
                    cmd.Parameters.Add("@InvestigationDetails", SqlDbType.VarChar).Value = InvestigationDetails;
                    cmd.Parameters.Add("@TreatmentDetails", SqlDbType.VarChar).Value = TreatmentDetails;
                    cmd.Parameters.Add("@Allergy", SqlDbType.VarChar).Value = Allergy;
                    cmd.Parameters.Add("@ICDCode", SqlDbType.VarChar).Value = ICDCode;

                    connection.Open();

                    int rowsAffected = Convert.ToInt32(cmd.ExecuteScalar());

                    connection.Close();
                    connection.Dispose();
                    return rowsAffected;
                }
            }
        }
        catch (Exception ex)
        {
            return -1;
        }
    }

    public int SaveEmr_DailyDrNote_555(string Patregid, string IpdNo, string DrNote, string Createdby, string Branchid, string Fid)
    {
        try
        {

            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;

            using (SqlConnection connection = DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("SP_IPDDrDailyNote", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@Patregid", SqlDbType.VarChar).Value = Patregid;
                    cmd.Parameters.Add("@DrNote", SqlDbType.VarChar).Value = DrNote;
                    cmd.Parameters.Add("@IpdNo", SqlDbType.VarChar).Value = IpdNo;

                    cmd.Parameters.Add("@Createdby", SqlDbType.VarChar).Value = Createdby;
                    cmd.Parameters.Add("@BranchId", SqlDbType.VarChar).Value = Branchid;
                    cmd.Parameters.Add("@Fid", SqlDbType.VarChar).Value = Fid;


                    connection.Open();

                    int rowsAffected = Convert.ToInt32(cmd.ExecuteScalar());

                    connection.Close();
                    connection.Dispose();
                    return rowsAffected;
                }
            }
        }
        catch (Exception ex)
        {
            return -1;
        }
    }

    public DataTable GetDailyDrNote(string patregId, string ipd, string branchid,string Usertype,string CreatedBy)
    {
        DataTable dt = new DataTable();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;

            using (SqlConnection connection =
                      DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetDailyDrNote", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Patientregid", SqlDbType.VarChar).Value = patregId;

                    cmd.Parameters.Add("@Ipd", SqlDbType.VarChar).Value = ipd;
                    cmd.Parameters.Add("@BranchId", SqlDbType.VarChar).Value = branchid;
                    cmd.Parameters.Add("@Usertype", SqlDbType.VarChar).Value = Usertype;
                    cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = CreatedBy;
                    connection.Open();

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                    connection.Close();
                    connection.Dispose();
                    return dt;
                    
                }
            }
        }
        catch (Exception)
        {

            return null;
        }

    }

    public DataTable GetDailyDrNote_ReferToAdmission(string patregId, string ipd, string branchid, string Usertype, string CreatedBy)
    {
        DataTable dt = new DataTable();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;

            using (SqlConnection connection =
                      DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetDailyDrNote_ReferToAdmission", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Patientregid", SqlDbType.VarChar).Value = patregId;

                    cmd.Parameters.Add("@Ipd", SqlDbType.VarChar).Value = ipd;
                    cmd.Parameters.Add("@BranchId", SqlDbType.VarChar).Value = branchid;
                    cmd.Parameters.Add("@Usertype", SqlDbType.VarChar).Value = Usertype;
                    cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = CreatedBy;
                    connection.Open();

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                    connection.Close();
                    connection.Dispose();
                    return dt;

                }
            }
        }
        catch (Exception)
        {

            return null;
        }

    }
    public DataTable Get_RefillTreatment(string patregId, string TreatmentId, int ipd, int branchid)
    {
        DataTable dt = new DataTable();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;

            using (SqlConnection connection =
                      DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("SP_TreatmentRefill", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Patientregid", SqlDbType.VarChar).Value = patregId;
                    cmd.Parameters.Add("@TreatmentId", SqlDbType.Int).Value = TreatmentId;


                    connection.Open();

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                    connection.Close();
                    connection.Dispose();
                    return dt;
                }
               
            }
        }
        catch (Exception)
        {

            return null;
        }

    }

    public int SaveReferalnoteformatmaster(string FormatName, string Format, string Createdby, string Branchid)
    {
        try
        {

            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;

            using (SqlConnection connection = DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("SP_InsertReferalnoteformatmaster", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@ReferalFormatName", SqlDbType.VarChar).Value = FormatName;
                    cmd.Parameters.Add("@ReferalFormat", SqlDbType.VarChar).Value = Format;
                   

                    cmd.Parameters.Add("@Createdby", SqlDbType.VarChar).Value = Createdby;
                    cmd.Parameters.Add("@BranchId", SqlDbType.VarChar).Value = Branchid;
                   


                    connection.Open();

                    int rowsAffected = Convert.ToInt32(cmd.ExecuteScalar());

                    connection.Close();
                    connection.Dispose();
                    return rowsAffected;
                }
            }
        }
        catch (Exception ex)
        {
            return -1;
        }
    }


    public DataTable GeFormatNote( string branchid)
    {
        DataTable dt = new DataTable();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;

            using (SqlConnection connection =
                      DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("SP_Getformatmaster", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                   
                    cmd.Parameters.Add("@BranchId", SqlDbType.VarChar).Value = branchid;

                    connection.Open();

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                    connection.Close();
                    connection.Dispose();
                    return dt;
                    
                }
            }
        }
        catch (Exception)
        {

            return null;
        }

    }

    public int SaveEmr_ReferalNote(string Patregid, string IpdNo, string FormatName, string Createdby, string Branchid, string Fid)
    {
        try
        {

            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;

            using (SqlConnection connection = DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("SP_InsertDrReferalnote", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@Patregid", SqlDbType.VarChar).Value = Patregid;
                    cmd.Parameters.Add("@ReferalNote", SqlDbType.VarChar).Value = FormatName;
                    cmd.Parameters.Add("@IpdNo", SqlDbType.VarChar).Value = IpdNo;

                    cmd.Parameters.Add("@Createdby", SqlDbType.VarChar).Value = Createdby;
                    cmd.Parameters.Add("@BranchId", SqlDbType.VarChar).Value = Branchid;
                    cmd.Parameters.Add("@Fid", SqlDbType.VarChar).Value = Fid;


                    connection.Open();

                    int rowsAffected = Convert.ToInt32(cmd.ExecuteScalar());

                    connection.Close();
                    connection.Dispose();
                    return rowsAffected;
                }
            }
        }
        catch (Exception ex)
        {
            return -1;
        }
    }


    public DataTable GetReferal_Note(string patregId, string ipd, string branchid)
    {
        DataTable dt = new DataTable();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;

            using (SqlConnection connection =
                      DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetReferalNote", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Patientregid", SqlDbType.VarChar).Value = patregId;

                    cmd.Parameters.Add("@Ipd", SqlDbType.VarChar).Value = ipd;
                    cmd.Parameters.Add("@BranchId", SqlDbType.VarChar).Value = branchid;

                    connection.Open();

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                    connection.Close();
                    connection.Dispose();
                    return dt;
                    
                }
            }
        }
        catch (Exception)
        {

            return null;
        }

    }

    public DataTable SelectFormatNote(string branchid,int ForId)
    {
        DataTable dt = new DataTable();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;

            using (SqlConnection connection =
                      DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("SP_selectformatmaster", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@BranchId", SqlDbType.VarChar).Value = branchid;
                    cmd.Parameters.Add("@ForId", SqlDbType.Int).Value = ForId;

                    connection.Open();

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                    connection.Close();
                    connection.Dispose();
                    return dt;
                   
                }
            }
        }
        catch (Exception)
        {

            return null;
        }

    }

    public DataTable Get_AllPatientOPD_Inform(string patregId,  int branchid)
    {
        DataTable dt = new DataTable();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;

            using (SqlConnection connection =
                      DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("SP_GetAll_OpdPatientInfo", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Patientregid", SqlDbType.VarChar).Value = patregId;
                   
                    cmd.Parameters.Add("@BranchId", SqlDbType.VarChar).Value = branchid;

                    connection.Open();

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                    connection.Close();
                    connection.Dispose();
                    return dt;
                }
               
            }
        }
        catch (Exception)
        {

            return null;
        }

    }


    public DataTable Get_All_Radiologyt_Bill_Charges(string patregId, string LabNo, int branchid)
    {
        DataTable dt = new DataTable();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;

            using (SqlConnection connection =
                      DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("SP_GetAllRadiology_Charges", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Patientregid", SqlDbType.VarChar).Value = patregId;
                    cmd.Parameters.Add("@LabNo", SqlDbType.VarChar).Value = LabNo;
                    cmd.Parameters.Add("@BranchId", SqlDbType.VarChar).Value = branchid;

                    connection.Open();

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                    connection.Close();
                    connection.Dispose();
                    return dt;
                   
                }
            }
        }
        catch (Exception)
        {

            return null;
        }

    }

    public DataTable Get_AllPatientInformation_ChargeNumber(string patregId)
    {
        DataTable dt = new DataTable();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;

            using (SqlConnection connection =
                      DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("SP_GetAllPatientInformation", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Patientregid", SqlDbType.VarChar).Value = patregId;
                   

                    connection.Open();

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                    connection.Close();
                    connection.Dispose();
                    return dt;
                }
               
            }
        }
        catch (Exception)
        {

            return null;
        }

    }

    public DataTable EditPatientInvoice(string InvoiceNo)
    {
        DataTable dt = new DataTable();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;

            using (SqlConnection connection =
                      DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("SP_GetChargePAtientDetails", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@InvoiceNo", SqlDbType.VarChar).Value = InvoiceNo;


                    connection.Open();

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                    connection.Close();
                    connection.Dispose();
                    return dt;
                }
               
            }
        }
        catch (Exception)
        {

            return null;
        }

    }


    public DataTable GetDailyDrNote_ForIPD(string patregId, string ipd, string branchid)
    {
        DataTable dt = new DataTable();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;

            using (SqlConnection connection =
                      DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetDailyDrNote", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Patientregid", SqlDbType.VarChar).Value = patregId;

                    cmd.Parameters.Add("@Ipd", SqlDbType.VarChar).Value = ipd;
                    cmd.Parameters.Add("@BranchId", SqlDbType.VarChar).Value = branchid;

                    connection.Open();

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                    connection.Close();
                    connection.Dispose();
                    return dt;

                }
            }
        }
        catch (Exception)
        {

            return null;
        }

    }

    public int Save_ReferToAdmission(string Patregid, string OPDNO, string ReferType, string ReferBy,string ReferTo,string ReferNote, string Branchid)
    {
        try
        {

            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;

            using (SqlConnection connection = DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("SP_ReferToAdmission", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@Patregid", SqlDbType.NVarChar).Value = Patregid;
                    cmd.Parameters.Add("@OPDNO", SqlDbType.NVarChar).Value = OPDNO;
                    cmd.Parameters.Add("@ReferType", SqlDbType.NVarChar).Value = ReferType;
                    cmd.Parameters.Add("@ReferBy", SqlDbType.NVarChar).Value = ReferBy;
                    cmd.Parameters.Add("@ReferNote", SqlDbType.NVarChar).Value = ReferNote;

                    cmd.Parameters.Add("@ReferTo", SqlDbType.VarChar).Value = ReferTo;
                    cmd.Parameters.Add("@BranchId", SqlDbType.VarChar).Value = Branchid;
                   


                    connection.Open();

                    int rowsAffected = Convert.ToInt32(cmd.ExecuteScalar());

                    connection.Close();
                    connection.Dispose();
                    return rowsAffected;
                }
            }
        }
        catch (Exception ex)
        {
            return -1;
        }
    }
    public DataTable Get_AllPatientInformation_EmrOPD(string patregId, string opd, int ipd, int branchid)
    {
        DataTable dt = new DataTable();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;

            using (SqlConnection connection =
                      DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("SP_GetAllPatientInfo_EMROPD", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Patientregid", SqlDbType.NVarChar).Value = patregId;
                    cmd.Parameters.Add("@OpdNo", SqlDbType.NVarChar).Value = opd;
                    cmd.Parameters.Add("@IpdNo", SqlDbType.NVarChar).Value = ipd;
                    cmd.Parameters.Add("@BranchId", SqlDbType.NVarChar).Value = branchid;

                    connection.Open();

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                    connection.Close();
                    connection.Dispose();
                    return dt;
                }


            }
        }
        catch (Exception)
        {

            return null;
        }

    }
}

