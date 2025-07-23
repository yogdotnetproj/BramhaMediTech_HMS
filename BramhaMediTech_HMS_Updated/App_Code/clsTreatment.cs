using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for clsTreatment
/// </summary>
public class clsTreatment
{
    public clsTreatment()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string treatId { get; set; }
    public string patientId { get; set; }
    public string opd { get; set; }
    public string ipd { get; set; }
    public string followUp { get; set; }
    public string branchId { get; set; }
    public string drug { get; set; }
    public string freq { get; set; }
    public string days { get; set; }
    public string from { get; set; }
    public string to { get; set; }
    public string transId { get; set; }
    public string createdBy { get; set; }
    public string createdOn { get; set; }
    public string updatedBy { get; set; }
    public string updatedOn { get; set; }
    public int ItemId { get; set; }
    public int DoseId { get; set; }
    public int DoseTimeId { get; set; }
    public string Dose { get; set; }
    public int DrId { get; set; }
    public int FId { get; set; }
    public float Qty { get; set; }
    public int PackageId { get; set; }
    public bool DiscMedication { get; set; }
    public bool NurseOrder { get; set; }
    public bool IsApproveByNurse { get; set; }
    public bool PostpoTreat { get; set; }

    public string InstName { get; set; }
    public string NewDose { get; set; }
    public string WardName { get; set; }
    public string Route { get; set; }
    public string Diagnosis { get; set; }

    public string VerbalBy { get; set; }
    public string VerbalOn { get; set; }

    public List<clsTreatmentTransaction> treatmentTransaction { get; set; }

    public DataTable GetDrugsMaster(string prefix, string Type, int DrId)
    {
        DataTable dt = new DataTable();

        using (SqlConnection con = DataAccess.ConInitForPharmacy())
        {
            using (SqlCommand cmd = new SqlCommand("usp_GetDrugNameForTreatment", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prefix", prefix);
                cmd.Parameters.AddWithValue("@Type", Type);
                cmd.Parameters.AddWithValue("@DrId", DrId);
                con.Open();

                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(dt);
                }

                con.Close();
                con.Dispose();
            }
        }
        return dt;
    }
    public DataTable GetDrugsMaster1(string prefix)
    {
        DataTable dt = new DataTable();

        using (SqlConnection con = DataAccess.ConInitForPharmacy())
        {
            using (SqlCommand cmd = new SqlCommand("usp_GetDrugNameForTreatment", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prefix", prefix);
                // cmd.Parameters.AddWithValue("@DeptId", DeptId);
                con.Open();

                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(dt);
                }

                con.Close();
            }
        }
        return dt;
    }
    public bool getallreadyIPDRecPayment_New_Discharge_Medi(DateTime Patregdate, int Patregid, int IpdNo, int OpdNo)
    {
        bool flag = true;
        // SqlConnection conn = new SqlConnection(ConnectionString.Connectionstring);
        SqlConnection conn = DataAccess.ConInitForDC();

        SqlCommand sc = new SqlCommand();

        sc = new SqlCommand(" SELECT  COUNT(*)  FROM  tbl_Treatment WHERE DiscMedication=1 and  EntryDate between convert(varchar,   DATEADD(Second,-20,GETDATE()), 21) and  convert(varchar,  DATEADD(second,20,GETDATE()), 21)  AND PatientRegId=@Patregid AND Ipd=@IpdNo AND Opd=@OpdNo   ", conn);
        // sc = new SqlCommand(" SELECT  COUNT(*)  FROM  tbl_Treatment WHERE  (CAST(CAST(YEAR(EntryDate) AS varchar(4)) + '/' + CAST(MONTH(EntryDate) AS varchar(2)) + '/' + CAST(DAY(EntryDate) AS varchar(2)) AS datetime)) between  GETDATE() and GETDATE()  AND PatientRegId=@Patregid AND Ipd=@IpdNo AND Opd=@OpdNo   ", conn);


        //    sc.Parameters.Add(new SqlParameter("@Patregdate", SqlDbType.DateTime)).Value = Patregdate;
        sc.Parameters.Add(new SqlParameter("@Patregid", SqlDbType.NVarChar, 250)).Value = Patregid;
        sc.Parameters.Add(new SqlParameter("@IpdNo", SqlDbType.Int)).Value = IpdNo;
        sc.Parameters.Add(new SqlParameter("@OpdNo", SqlDbType.Int)).Value = OpdNo;


        object count;
        try
        {
            conn.Open();
            count = sc.ExecuteScalar();

            if (count != null)
            {
                if (Convert.ToInt32(count) > 0)
                {
                    flag = false;
                }
            }
        }
        catch (SqlException ex)
        { }
        finally
        {
            conn.Close();
            conn.Dispose();
        }
        return flag;
    }
    public DataTable FillPackageDetails(int PackageId)
    {
        DataTable dt = new DataTable();
        using (SqlConnection con = DataAccess.ConInitForPharmacy())
        {

             using (SqlCommand cmd = new SqlCommand("Sp_FillPackageDetailsGrid", con))
            {  
                 cmd.CommandType = CommandType.StoredProcedure;
                 cmd.Parameters.AddWithValue("@PackageId", PackageId);
                 con.Open();

                 using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                 {
                     sda.Fill(dt);
                 }

                 con.Close();
                 con.Dispose();
            }
        }
        return dt;
    }

    public DataTable FillPackageDetails_DrID(int PackageId)
    {
        DataTable dt = new DataTable();
        using (SqlConnection con = DataAccess.ConInitForPharmacy())
        {

            using (SqlCommand cmd = new SqlCommand("Sp_FillPackageDetailsGrid", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PackageId", PackageId);
                con.Open();

                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(dt);
                }

                con.Close();
                con.Dispose();
            }
        }
        return dt;
    }
    public DataTable GetDrugsMasterEmergency(string prefix,string Type)
    {
        DataTable dt = new DataTable();

        using (SqlConnection con = DataAccess.ConInitForPharmacy())
        {
            using (SqlCommand cmd = new SqlCommand("usp_GetDrugNameForTreatmentEmergency", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prefix", prefix);
                cmd.Parameters.AddWithValue("@Type", Type);
                con.Open();

                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(dt);
                }

                con.Close();
                con.Dispose();
            }
        }
        return dt;
    }
    public DataTable GetFrequencyMaster()
    {
        DataTable dt = new DataTable();

        using (SqlConnection con = DataAccess.ConInitForDC())
        {
            using (SqlCommand cmd = new SqlCommand("usp_GetFrequencyForTreatment", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();

                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(dt);
                }

                con.Close();
                con.Dispose();
            }
        }
        return dt;
    }
    public DataSet FillDoseMaster()
    {
        DataSet ds = new DataSet();
        using (SqlConnection con = DataAccess.ConInitForPharmacy())
        {
            using (SqlCommand cmd = new SqlCommand("Sp_FillDoseMaster", con))
            {

                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds);
                }
                con.Close();
                con.Dispose();
            }
        }
        return ds;
    }

    public DataSet Fill_RoomMst()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("Sp_Fill_RoomMst", con);
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

    public DataSet Fill_Route()
    {
        DataSet ds = new DataSet();
        using (SqlConnection con = DataAccess.ConInitForPharmacy())
        {
            using (SqlCommand cmd = new SqlCommand("Sp_FillRoute", con))
            {

                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds);
                }
                con.Close();
                con.Dispose();
            }
        }
        return ds;
    }

    public DataSet FillDoseTimes()
    {
         DataSet ds = new DataSet();
         using (SqlConnection con = DataAccess.ConInitForPharmacy())
         {
             using (SqlCommand cmd = new SqlCommand("Sp_FillDoseTimes", con))
             {

                 cmd.CommandType = CommandType.StoredProcedure;
                 con.Open();
                 using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                 {
                     da.Fill(ds);
                 }
                 con.Close();
                 con.Dispose();
             }
         }
        return ds;
    }

    public DataSet GetInstruction()
    {
        DataSet ds = new DataSet();
        using (SqlConnection con = DataAccess.ConInitForPharmacy())
        {
            using (SqlCommand cmd = new SqlCommand("Sp_GetInstruction", con))
            {

                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds);
                }
                con.Close();
                con.Dispose();
            }
        }
        return ds;
    }


    public DataTable GetPatientIds(string prefixText)
    {
        DataTable dt = new DataTable();

        using (SqlConnection con = DataAccess.ConInitForDC())
        {
            using (SqlCommand cmd = new SqlCommand("usp_GetPatientIds", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prefix", prefixText);
                con.Open();

                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(dt);
                }

                con.Close();
                con.Dispose();
            }
        }
        return dt;
    }

    public DataTable GetRecordPatientId(string id)
    {
        DataTable dt = new DataTable();

        using (SqlConnection con = DataAccess.ConInitForDC())
        {
            using (SqlCommand cmd = new SqlCommand("usp_GetRecordTreatmentById", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();

                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(dt);
                }

                con.Close();
                con.Dispose();
            }
        }
        return dt;
    }

    public DataTable GetTreatmentDetails(string pId, string ipd, string opd)
    {
        DataTable dt = new DataTable();

        using (SqlConnection con = DataAccess.ConInitForDC())
        {
            using (SqlCommand cmd = new SqlCommand("usp_GetTreatmentByPatient", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@patientId", pId);
                cmd.Parameters.AddWithValue("@ipd", ipd);
                cmd.Parameters.AddWithValue("@opd", opd);
                con.Open();

                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(dt);
                }

                con.Close();
                con.Dispose();
            }
        }
        return dt;
    }

    public DataTable CheckTreatmentDetails(string pId, string ipd, string opd)
    {
        DataTable dt = new DataTable();

        using (SqlConnection con = DataAccess.ConInitForDC())
        {
            using (SqlCommand cmd = new SqlCommand("usp_CheckAndGetTreatmentId", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pId", pId);
                cmd.Parameters.AddWithValue("@ipd", ipd);
                cmd.Parameters.AddWithValue("@opd", opd);
                con.Open();

                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(dt);
                }

                con.Close();
                con.Dispose();
            }
        }
        return dt;
    }

    public int InsertUpdateDeleteMain_Observ(string type)
    {
        try
        {
            using (SqlConnection con = DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetTreatment_Insert_Observ", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@treatId", treatId);
                    cmd.Parameters.AddWithValue("@patientId", patientId);
                    cmd.Parameters.AddWithValue("@opd", opd);
                    cmd.Parameters.AddWithValue("@ipd", ipd);
                    cmd.Parameters.AddWithValue("@DrId", DrId);
                    cmd.Parameters.AddWithValue("@branchId", branchId);
                    cmd.Parameters.AddWithValue("@followUp", followUp);
                    cmd.Parameters.AddWithValue("@createdBy", createdBy);
                    cmd.Parameters.AddWithValue("@createdOn", createdOn);
                    cmd.Parameters.AddWithValue("@updatedBy", updatedBy);
                    cmd.Parameters.AddWithValue("@updatedOn", updatedOn);
                    cmd.Parameters.AddWithValue("@type", type);
                    con.Open();

                    int rowsAffected = Convert.ToInt32(cmd.ExecuteScalar());

                    con.Close();
                    con.Dispose();
                    return rowsAffected;
                }
            }
        }
        catch (Exception ex)
        {

            return -1;
        }
    }

    public int InsertUpdateDeleteMain_Ipd(string type)
    {
        try
        {
            using (SqlConnection con = DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetTreatment_Insert_Ipd", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@treatId", treatId);
                    cmd.Parameters.AddWithValue("@patientId", patientId);
                    cmd.Parameters.AddWithValue("@opd", opd);
                    cmd.Parameters.AddWithValue("@ipd", ipd);
                    cmd.Parameters.AddWithValue("@DrId", DrId);
                    cmd.Parameters.AddWithValue("@branchId", branchId);
                    cmd.Parameters.AddWithValue("@followUp", followUp);
                    cmd.Parameters.AddWithValue("@createdBy", createdBy);
                    cmd.Parameters.AddWithValue("@createdOn", createdOn);
                    cmd.Parameters.AddWithValue("@updatedBy", updatedBy);
                    cmd.Parameters.AddWithValue("@updatedOn", updatedOn);
                    cmd.Parameters.AddWithValue("@type", type);
                    cmd.Parameters.AddWithValue("@IsApproveByNurse", IsApproveByNurse);
                    con.Open();

                    int rowsAffected = Convert.ToInt32(cmd.ExecuteScalar());

                    con.Close();
                    con.Dispose();
                    return rowsAffected;
                }
            }
        }
        catch (Exception ex)
        {

            return -1;
        }
    }
    public bool getallreadyIPDRecPayment_NewPostPo(DateTime Patregdate, int Patregid, int IpdNo, int OpdNo)
    {
        bool flag = true;
        // SqlConnection conn = new SqlConnection(ConnectionString.Connectionstring);
        SqlConnection conn = DataAccess.ConInitForDC();

        SqlCommand sc = new SqlCommand();

        sc = new SqlCommand(" SELECT  COUNT(*)  FROM  tbl_Treatment WHERE PostpoTreat=1 and EntryDate between convert(varchar,   DATEADD(Second,-30,GETDATE()), 21) and  convert(varchar,  DATEADD(second,30,GETDATE()), 21)  AND PatientRegId=@Patregid AND Ipd=@IpdNo AND Opd=@OpdNo   ", conn);
        // sc = new SqlCommand(" SELECT  COUNT(*)  FROM  tbl_Treatment WHERE  (CAST(CAST(YEAR(EntryDate) AS varchar(4)) + '/' + CAST(MONTH(EntryDate) AS varchar(2)) + '/' + CAST(DAY(EntryDate) AS varchar(2)) AS datetime)) between  GETDATE() and GETDATE()  AND PatientRegId=@Patregid AND Ipd=@IpdNo AND Opd=@OpdNo   ", conn);


        //    sc.Parameters.Add(new SqlParameter("@Patregdate", SqlDbType.DateTime)).Value = Patregdate;
        sc.Parameters.Add(new SqlParameter("@Patregid", SqlDbType.NVarChar, 250)).Value = Patregid;
        sc.Parameters.Add(new SqlParameter("@IpdNo", SqlDbType.Int)).Value = IpdNo;
        sc.Parameters.Add(new SqlParameter("@OpdNo", SqlDbType.Int)).Value = OpdNo;


        object count;
        try
        {
            conn.Open();
            count = sc.ExecuteScalar();

            if (count != null)
            {
                if (Convert.ToInt32(count) > 0)
                {
                    flag = false;
                }
            }
        }
        catch (SqlException ex)
        { }
        finally
        {
            conn.Close();
            conn.Dispose();
        }
        return flag;
    }

    public int InsertUpdateDeleteMain_PostPo(string type)
    {
        try
        {
            using (SqlConnection con = DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetTreatment_Insert_PostPo", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@treatId", treatId);
                    cmd.Parameters.AddWithValue("@patientId", patientId);
                    cmd.Parameters.AddWithValue("@opd", opd);
                    cmd.Parameters.AddWithValue("@ipd", ipd);
                    cmd.Parameters.AddWithValue("@DrId", DrId);
                    cmd.Parameters.AddWithValue("@branchId", branchId);
                    cmd.Parameters.AddWithValue("@followUp", followUp);
                    cmd.Parameters.AddWithValue("@createdBy", createdBy);
                    cmd.Parameters.AddWithValue("@createdOn", createdOn);
                    cmd.Parameters.AddWithValue("@updatedBy", updatedBy);
                    cmd.Parameters.AddWithValue("@updatedOn", updatedOn);
                    cmd.Parameters.AddWithValue("@type", type);
                    cmd.Parameters.AddWithValue("@DiscMedication", DiscMedication);
                    cmd.Parameters.AddWithValue("@IsApproveByNurse", IsApproveByNurse);
                    cmd.Parameters.AddWithValue("@PostpoTreat", PostpoTreat);


                    con.Open();

                    int rowsAffected = Convert.ToInt32(cmd.ExecuteScalar());

                    con.Close();
                    con.Dispose();

                    return rowsAffected;
                }
            }
        }
        catch (Exception ex)
        {

            return -1;
        }
    }
    public int InsertUpdateTreatmentDiagnostic(string type)
    {
        try
        {
            using (SqlConnection con = DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetTreatment_Insert_Diagnosis", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@patientId", patientId);

                    cmd.Parameters.AddWithValue("@ipd", ipd);

                    cmd.Parameters.AddWithValue("@branchId", branchId);

                    cmd.Parameters.AddWithValue("@Diagnosis", type);
                    cmd.Parameters.AddWithValue("@FID", FId);



                    con.Open();

                    int rowsAffected = Convert.ToInt32(cmd.ExecuteScalar());

                    con.Close();
                    con.Dispose();

                    return rowsAffected;
                }
            }
        }
        catch (Exception ex)
        {

            return -1;
        }
    }
    public int InsertUpdateDeleteMain(string type)
    {
        try
        {
            using (SqlConnection con = DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetTreatment_Insert", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@treatId", treatId);
                    cmd.Parameters.AddWithValue("@patientId", patientId);
                    cmd.Parameters.AddWithValue("@opd", opd);
                    cmd.Parameters.AddWithValue("@ipd", ipd);
                    cmd.Parameters.AddWithValue("@DrId", DrId);
                    cmd.Parameters.AddWithValue("@branchId", branchId);
                    cmd.Parameters.AddWithValue("@followUp", followUp);
                    cmd.Parameters.AddWithValue("@createdBy", createdBy);
                    cmd.Parameters.AddWithValue("@createdOn", createdOn);
                    cmd.Parameters.AddWithValue("@updatedBy", updatedBy);
                    cmd.Parameters.AddWithValue("@updatedOn", updatedOn);
                    cmd.Parameters.AddWithValue("@type", type);
                    cmd.Parameters.AddWithValue("@DiscMedication", DiscMedication);
                    cmd.Parameters.AddWithValue("@IsApproveByNurse", IsApproveByNurse);
                    cmd.Parameters.AddWithValue("@WardName", WardName);
                    cmd.Parameters.AddWithValue("@VerbalBy", VerbalBy);
                    cmd.Parameters.AddWithValue("@VerbalOn", VerbalOn);

                    
                    con.Open();

                    int rowsAffected = Convert.ToInt32(cmd.ExecuteScalar());

                    con.Close();
                    con.Dispose();

                    return rowsAffected;
                }
            }
        }
        catch (Exception ex)
        {

            return -1;
        }
    }

    public int InsertUpdateDeleteMain_ReferToAdmission(string type)
    {
        try
        {
            using (SqlConnection con = DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetTreatment_Insert_ReferToAdmision", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@treatId", treatId);
                    cmd.Parameters.AddWithValue("@patientId", patientId);
                    cmd.Parameters.AddWithValue("@opd", opd);
                    cmd.Parameters.AddWithValue("@ipd", ipd);
                    cmd.Parameters.AddWithValue("@DrId", DrId);
                    cmd.Parameters.AddWithValue("@branchId", branchId);
                    cmd.Parameters.AddWithValue("@followUp", followUp);
                    cmd.Parameters.AddWithValue("@createdBy", createdBy);
                    cmd.Parameters.AddWithValue("@createdOn", createdOn);
                    cmd.Parameters.AddWithValue("@updatedBy", updatedBy);
                    cmd.Parameters.AddWithValue("@updatedOn", updatedOn);
                    cmd.Parameters.AddWithValue("@type", type);
                    cmd.Parameters.AddWithValue("@DiscMedication", DiscMedication);
                    cmd.Parameters.AddWithValue("@IsApproveByNurse", IsApproveByNurse);
                    cmd.Parameters.AddWithValue("@WardName", WardName);


                    con.Open();

                    int rowsAffected = Convert.ToInt32(cmd.ExecuteScalar());

                    con.Close();
                    con.Dispose();

                    return rowsAffected;
                }
            }
        }
        catch (Exception ex)
        {

            return -1;
        }
    }
    public bool getallreadyIPDRecPayment_New(DateTime Patregdate, int Patregid, int IpdNo, int OpdNo)
    {
        bool flag = true;
        // SqlConnection conn = new SqlConnection(ConnectionString.Connectionstring);
        SqlConnection conn = DataAccess.ConInitForDC();

        SqlCommand sc = new SqlCommand();

        sc = new SqlCommand(" SELECT  COUNT(*)  FROM  tbl_Treatment WHERE  EntryDate between convert(varchar,   DATEADD(Second,-30,GETDATE()), 21) and  convert(varchar,  DATEADD(second,30,GETDATE()), 21)  AND PatientRegId=@Patregid AND Ipd=@IpdNo AND Opd=@OpdNo   ", conn);
       // sc = new SqlCommand(" SELECT  COUNT(*)  FROM  tbl_Treatment WHERE  (CAST(CAST(YEAR(EntryDate) AS varchar(4)) + '/' + CAST(MONTH(EntryDate) AS varchar(2)) + '/' + CAST(DAY(EntryDate) AS varchar(2)) AS datetime)) between  GETDATE() and GETDATE()  AND PatientRegId=@Patregid AND Ipd=@IpdNo AND Opd=@OpdNo   ", conn);


        //    sc.Parameters.Add(new SqlParameter("@Patregdate", SqlDbType.DateTime)).Value = Patregdate;
        sc.Parameters.Add(new SqlParameter("@Patregid", SqlDbType.NVarChar, 250)).Value = Patregid;
        sc.Parameters.Add(new SqlParameter("@IpdNo", SqlDbType.Int)).Value = IpdNo;
        sc.Parameters.Add(new SqlParameter("@OpdNo", SqlDbType.Int)).Value = OpdNo;


        object count;
        try
        {
            conn.Open();
            count = sc.ExecuteScalar();

            if (count != null)
            {
                if (Convert.ToInt32(count) > 0)
                {
                    flag = false;
                }
            }
        }
        catch (SqlException ex)
        { }
        finally
        {
            conn.Close();
            conn.Dispose();
        }
        return flag;
    }

    public bool getallreadyIPDRecPayment_New_ReferToAdmission(DateTime Patregdate, int Patregid, int IpdNo, int OpdNo)
    {
        bool flag = true;
        // SqlConnection conn = new SqlConnection(ConnectionString.Connectionstring);
        SqlConnection conn = DataAccess.ConInitForDC();

        SqlCommand sc = new SqlCommand();

        sc = new SqlCommand(" SELECT  COUNT(*)  FROM  tbl_Treatment_ReferToAdmision WHERE  EntryDate between convert(varchar,   DATEADD(Second,-30,GETDATE()), 21) and  convert(varchar,  DATEADD(second,30,GETDATE()), 21)  AND PatientRegId=@Patregid AND Ipd=@IpdNo AND Opd=@OpdNo   ", conn);
        // sc = new SqlCommand(" SELECT  COUNT(*)  FROM  tbl_Treatment WHERE  (CAST(CAST(YEAR(EntryDate) AS varchar(4)) + '/' + CAST(MONTH(EntryDate) AS varchar(2)) + '/' + CAST(DAY(EntryDate) AS varchar(2)) AS datetime)) between  GETDATE() and GETDATE()  AND PatientRegId=@Patregid AND Ipd=@IpdNo AND Opd=@OpdNo   ", conn);


        //    sc.Parameters.Add(new SqlParameter("@Patregdate", SqlDbType.DateTime)).Value = Patregdate;
        sc.Parameters.Add(new SqlParameter("@Patregid", SqlDbType.NVarChar, 250)).Value = Patregid;
        sc.Parameters.Add(new SqlParameter("@IpdNo", SqlDbType.Int)).Value = IpdNo;
        sc.Parameters.Add(new SqlParameter("@OpdNo", SqlDbType.Int)).Value = OpdNo;


        object count;
        try
        {
            conn.Open();
            count = sc.ExecuteScalar();

            if (count != null)
            {
                if (Convert.ToInt32(count) > 0)
                {
                    flag = false;
                }
            }
        }
        catch (SqlException ex)
        { }
        finally
        {
            conn.Close();
            conn.Dispose();
        }
        return flag;
    }
}

public class clsTreatmentTransaction
{
    public string TransId { get; set; }
    public string TreatmentId { get; set; }
    public string DrugName { get; set; }
    public string FrequencyType { get; set; }
    public string Days { get; set; }
    public string StartDate { get; set; }
    public string EndDate { get; set; }
    public string Note { get; set; }
    public int ItemId { get; set; }
    public int DoseId { get; set; }
    public int DoseTimeId { get; set; }
    public string Dose { get; set; }
    public float Qty { get; set; }
    public bool NurseOrder { get; set; }
    public bool PostpoTreat { get; set; }
    public string Vital { get; set; }
    public string Diet { get; set; }
    public string QtyML { get; set; }
        public string InstName { get; set; }
        public string NewDose { get; set; }
        public string Route { get; set; }  
        
    public int InsertUpdateDeleteMain_Observation(string type)
    {
        try
        {
            using (SqlConnection con = DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetTreatmentTransaction_Insert_Observ", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TransId", TransId);
                    cmd.Parameters.AddWithValue("@TreatmentId", TreatmentId);
                    cmd.Parameters.AddWithValue("@DrugName", DrugName);
                    cmd.Parameters.AddWithValue("@FrequencyType", FrequencyType);
                    cmd.Parameters.AddWithValue("@Dose", Dose);
                    cmd.Parameters.AddWithValue("@Days", Days);
                    cmd.Parameters.AddWithValue("@StartDate", StartDate);
                    cmd.Parameters.AddWithValue("@EndDate", EndDate);
                    cmd.Parameters.AddWithValue("@Note", Note);
                    cmd.Parameters.AddWithValue("@type", type);
                    cmd.Parameters.AddWithValue("@ItemId", ItemId);
                    cmd.Parameters.AddWithValue("@DoseId", DoseId);
                    cmd.Parameters.AddWithValue("@DoseTimeId", DoseTimeId);
                    cmd.Parameters.AddWithValue("@Qty", Qty);

                    con.Open();
                    int Result = -1;

                    Result = Convert.ToInt32(cmd.ExecuteScalar());

                    con.Close();
                    con.Dispose();
                    return Result;
                }
            }
        }
        catch (Exception ex)
        {
            return -1;
        }
    }

    public int InsertUpdateDeleteMain_IpdNurseReq(string type)
    {
        try
        {
            using (SqlConnection con = DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetTreatmentTransaction_Insert_IpdNurse", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TransId", TransId);
                    cmd.Parameters.AddWithValue("@TreatmentId", TreatmentId);
                    cmd.Parameters.AddWithValue("@DrugName", DrugName);
                    cmd.Parameters.AddWithValue("@FrequencyType", FrequencyType);
                    cmd.Parameters.AddWithValue("@Dose", Dose);
                    cmd.Parameters.AddWithValue("@Days", Days);
                    cmd.Parameters.AddWithValue("@StartDate", StartDate);
                    cmd.Parameters.AddWithValue("@EndDate", EndDate);
                    cmd.Parameters.AddWithValue("@Note", Note);
                    cmd.Parameters.AddWithValue("@type", type);
                    cmd.Parameters.AddWithValue("@ItemId", ItemId);
                    cmd.Parameters.AddWithValue("@DoseId", DoseId);
                    cmd.Parameters.AddWithValue("@DoseTimeId", DoseTimeId);
                    cmd.Parameters.AddWithValue("@Qty", Qty);
                    cmd.Parameters.AddWithValue("@NurseOrder", NurseOrder);

                    con.Open();
                    int Result = -1;

                    Result = Convert.ToInt32(cmd.ExecuteScalar());

                    con.Close();
                    con.Dispose();
                    return Result;
                }
            }
        }
        catch (Exception ex)
        {
            return -1;
        }
    }
    public int InsertUpdateDeleteMain_PostPo(string type)
    {
        try
        {
            using (SqlConnection con = DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetTreatmentTransaction_Insert_PostPo", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TransId", TransId);
                    cmd.Parameters.AddWithValue("@TreatmentId", TreatmentId);
                    cmd.Parameters.AddWithValue("@DrugName", DrugName);
                    cmd.Parameters.AddWithValue("@FrequencyType", FrequencyType);
                    cmd.Parameters.AddWithValue("@Dose", Dose);
                    cmd.Parameters.AddWithValue("@Days", Days);
                    cmd.Parameters.AddWithValue("@StartDate", StartDate);
                    cmd.Parameters.AddWithValue("@EndDate", EndDate);
                    cmd.Parameters.AddWithValue("@Note", Note);
                    cmd.Parameters.AddWithValue("@type", type);
                    cmd.Parameters.AddWithValue("@ItemId", ItemId);
                    cmd.Parameters.AddWithValue("@DoseId", DoseId);
                    cmd.Parameters.AddWithValue("@DoseTimeId", DoseTimeId);
                    cmd.Parameters.AddWithValue("@Qty", Qty);
                    cmd.Parameters.AddWithValue("@Vital", Vital);
                    cmd.Parameters.AddWithValue("@Diet", Diet);
                    cmd.Parameters.AddWithValue("@QtyML", QtyML);
                    cmd.Parameters.AddWithValue("@Route", Route);
                    con.Open();
                    int Result = -1;

                    Result = Convert.ToInt32(cmd.ExecuteScalar());

                    con.Close();
                    con.Dispose();
                    return Result;
                }
            }
        }
        catch (Exception ex)
        {
            return -1;
        }
    }
    public DataSet GetTreatementDetailsTreatment_PostPo(int patregId, int OpdNo, int IpdNo)
    {
        DataSet dt = new DataSet();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;
            using (SqlConnection connection = DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("Sp_GetTreatmentDetails_Treatment_PostPo", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@PatRegId", SqlDbType.VarChar).Value = patregId;
                    cmd.Parameters.Add("@OpdNo", SqlDbType.Int).Value = OpdNo;
                    cmd.Parameters.Add("@IpdNo", SqlDbType.Int).Value = IpdNo;
                    connection.Open();

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                }
                connection.Close();
                connection.Dispose();
            }
        }
        catch (Exception)
        {
        }
        return dt;
    }

    public int InsertUpdateDeleteMain(string type)
    {
        try
        {
            using (SqlConnection con = DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetTreatmentTransaction_Insert", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TransId", TransId);
                    cmd.Parameters.AddWithValue("@TreatmentId", TreatmentId);
                    cmd.Parameters.AddWithValue("@DrugName", DrugName);
                    cmd.Parameters.AddWithValue("@FrequencyType", FrequencyType);
                    cmd.Parameters.AddWithValue("@Dose", Dose);
                    cmd.Parameters.AddWithValue("@Days", Days);
                    cmd.Parameters.AddWithValue("@StartDate", StartDate);
                    cmd.Parameters.AddWithValue("@EndDate", EndDate);
                    cmd.Parameters.AddWithValue("@Note", Note);
                    cmd.Parameters.AddWithValue("@type", type);
                    cmd.Parameters.AddWithValue("@ItemId", ItemId);
                    cmd.Parameters.AddWithValue("@DoseId", DoseId);
                    cmd.Parameters.AddWithValue("@DoseTimeId", DoseTimeId);
                    cmd.Parameters.AddWithValue("@Qty", Qty);

                    cmd.Parameters.AddWithValue("@InstName", InstName);
                    cmd.Parameters.AddWithValue("@NewDose", NewDose);
                    cmd.Parameters.AddWithValue("@Route", Route);

                    con.Open();
                    int Result = -1;

                    Result = Convert.ToInt32(cmd.ExecuteScalar());

                    con.Close();
                    con.Dispose();
                    return Result;
                }
            }
        }
        catch (Exception ex)
        {
            return -1;
        }
    }

    public int InsertUpdateDeleteMain_ReferToAdmission(string type)
    {
        try
        {
            using (SqlConnection con = DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetTreatmentTransaction_Insert_ReferToAdmission", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TransId", TransId);
                    cmd.Parameters.AddWithValue("@TreatmentId", TreatmentId);
                    cmd.Parameters.AddWithValue("@DrugName", DrugName);
                    cmd.Parameters.AddWithValue("@FrequencyType", FrequencyType);
                    cmd.Parameters.AddWithValue("@Dose", Dose);
                    cmd.Parameters.AddWithValue("@Days", Days);
                    cmd.Parameters.AddWithValue("@StartDate", StartDate);
                    cmd.Parameters.AddWithValue("@EndDate", EndDate);
                    cmd.Parameters.AddWithValue("@Note", Note);
                    cmd.Parameters.AddWithValue("@type", type);
                    cmd.Parameters.AddWithValue("@ItemId", ItemId);
                    cmd.Parameters.AddWithValue("@DoseId", DoseId);
                    cmd.Parameters.AddWithValue("@DoseTimeId", DoseTimeId);
                    cmd.Parameters.AddWithValue("@Qty", Qty);

                    cmd.Parameters.AddWithValue("@InstName", InstName);
                    cmd.Parameters.AddWithValue("@NewDose", NewDose);
                    cmd.Parameters.AddWithValue("@Route", Route);

                    con.Open();
                    int Result = -1;

                    Result = Convert.ToInt32(cmd.ExecuteScalar());

                    con.Close();
                    con.Dispose();
                    return Result;
                }
            }
        }
        catch (Exception ex)
        {
            return -1;
        }
    }

    public DataSet GetTreatementDetailsTreatment(int patregId,int OpdNo,int IpdNo)
    {
        DataSet dt = new DataSet();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;
            using (SqlConnection connection =  DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("Sp_GetTreatmentDetails_Treatment", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@PatRegId", SqlDbType.VarChar).Value = patregId;
                    cmd.Parameters.Add("@OpdNo", SqlDbType.Int).Value = OpdNo;
                    cmd.Parameters.Add("@IpdNo", SqlDbType.Int).Value = IpdNo;
                    connection.Open();

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                }
            }
        }
        catch (Exception)
        {
        }
        return dt;
    }

    public DataSet GetTreatementDetailsTreatment_OPEMERG(int patregId, int OpdNo, int IpdNo)
    {
        DataSet dt = new DataSet();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;
            using (SqlConnection connection = DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("Sp_GetTreatmentDetails_Treatment_OPEmergency", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@PatRegId", SqlDbType.VarChar).Value = patregId;
                    cmd.Parameters.Add("@OpdNo", SqlDbType.Int).Value = OpdNo;
                    cmd.Parameters.Add("@IpdNo", SqlDbType.Int).Value = IpdNo;
                    connection.Open();

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                }
            }
        }
        catch (Exception)
        {
        }
        return dt;
    }

    public DataSet GetTreatementDetails(int patregId)
    {
        DataSet dt = new DataSet();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;
            using (SqlConnection connection = DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("Sp_GetTreatmentDetails", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@PatRegId", SqlDbType.VarChar).Value = patregId;
                  
                    connection.Open();

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                }
            }
        }
        catch (Exception)
        {
        }
        return dt;
    }


    public DataSet GetTreatementDetails_Observ(int patregId)
    {
        DataSet dt = new DataSet();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;
            using (SqlConnection connection = DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("Sp_GetTreatmentDetails_Observ", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@PatRegId", SqlDbType.VarChar).Value = patregId;
                    connection.Open();

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                }
            }
        }
        catch (Exception)
        {
        }
        return dt;
    }

    public DataSet GetReqDrugByNurse(int patregId,int IpdNo)
    {
        DataSet dt = new DataSet();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;
            using (SqlConnection connection = DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("Sp_GetTreatmentDetails_Ipd", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@PatRegId", SqlDbType.VarChar).Value = patregId;
                    cmd.Parameters.Add("@IpdNo", SqlDbType.Int).Value = IpdNo;
                    connection.Open();

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                }
            }
        }
        catch (Exception)
        {
        }
        return dt;
    }
    //public DataSet GetLabInvestigationDetails_IPD(int patregId, int IPDNo)
    //{
    //    DataSet dt = new DataSet();
    //    try
    //    {
    //        //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;
    //        using (SqlConnection connection = DataAccess.ConInitForDC())
    //        {
    //            using (SqlCommand cmd = new SqlCommand("Sp_GetInvestigationDetails_IPD", connection))
    //            {
    //                cmd.CommandType = CommandType.StoredProcedure;
    //                cmd.Parameters.Add("@PatRegId", SqlDbType.VarChar).Value = patregId;
    //                cmd.Parameters.Add("@IPDNo", SqlDbType.VarChar).Value = IPDNo;
    //                connection.Open();

    //                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
    //                {
    //                    sda.Fill(dt);
    //                }
    //            }
    //        }
    //    }
    //    catch (Exception)
    //    {
    //    }
    //    return dt;
    //}


    public DataTable GetLabInvestigationDetails_IPD(int patregId, int IPDNo)
    {
        DataTable dt = new DataTable();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;
            using (SqlConnection connection = DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("Sp_GetInvestigationDetails_IPD", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@PatRegId", SqlDbType.VarChar).Value = patregId;
                    cmd.Parameters.Add("@IPDNo", SqlDbType.VarChar).Value = IPDNo;
                    connection.Open();

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                }
            }
        }
        catch (Exception)
        {
        }
        return dt;
    }

    public DataTable GetLabInvestigationDetails(int patregId )
    {
        DataTable dt = new DataTable();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;
            using (SqlConnection connection = DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("Sp_GetInvestigationDetails", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@PatRegId", SqlDbType.VarChar).Value = patregId;
                    connection.Open();

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                }
            }
        }
        catch (Exception)
        {
        }
        return dt;
    }

    public DataTable GetLabInvestigationDetailsPatho(int patregId)
    {
        DataTable dt = new DataTable();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;
            using (SqlConnection connection = DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("Sp_GetInvestigationDetailsPatho", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@PatRegId", SqlDbType.VarChar).Value = patregId;
                    connection.Open();

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                }
            }
        }
        catch (Exception)
        {
        }
        return dt;
    }

    public DataSet GetLabInvestigationDetailsPatho_IPD(int patregId, int IPDNo)
    {
        DataSet dt = new DataSet();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;
            using (SqlConnection connection = DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("Sp_GetInvestigationDetailsPatho_IPD", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@PatRegId", SqlDbType.VarChar).Value = patregId;
                    cmd.Parameters.Add("@IPDNo", SqlDbType.VarChar).Value = IPDNo;
                    connection.Open();

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                }
            }
        }
        catch (Exception)
        {
        }
        return dt;
    }

    public DataSet GetLabInvestigationDetailsRadio_IPD(int patregId, int IPDNo)
    {
        DataSet dt = new DataSet();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;
            using (SqlConnection connection = DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("Sp_GetInvestigationDetailsRadio_IPD", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@PatRegId", SqlDbType.VarChar).Value = patregId;
                    cmd.Parameters.Add("@IPDNo", SqlDbType.VarChar).Value = IPDNo;
                    connection.Open();

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                }
            }
        }
        catch (Exception)
        {
        }
        return dt;
    }

    public DataTable GetLabInvestigationDetailsCardo_IPD(int patregId, int IPDNo)
    {
        DataTable dt = new DataTable();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;
            using (SqlConnection connection = DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("Sp_GetInvestigationDetailsCardo_IPD", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@PatRegId", SqlDbType.VarChar).Value = patregId;
                    cmd.Parameters.Add("@IPDNo", SqlDbType.VarChar).Value = IPDNo;
                    connection.Open();

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                }
            }
        }
        catch (Exception)
        {
        }
        return dt;
    }

    public DataTable GetLabInvestigationDetailsRadio(int patregId)
    {
        DataTable dt = new DataTable();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;
            using (SqlConnection connection = DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("Sp_GetInvestigationDetailsRadio", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@PatRegId", SqlDbType.VarChar).Value = patregId;
                    connection.Open();

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                }
            }
        }
        catch (Exception)
        {
        }
        return dt;
    }

    public DataTable GetLabInvestigationDetailsCardo(int patregId)
    {
        DataTable dt = new DataTable();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;
            using (SqlConnection connection = DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("Sp_GetInvestigationDetailsCardo", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@PatRegId", SqlDbType.VarChar).Value = patregId;
                    connection.Open();

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                }
            }
        }
        catch (Exception)
        {
        }
        return dt;
    }


    public void DeleteDrugTransaction(int TransId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_DeleteDrugTranaction", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@TransId", TransId);
            
            cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            con.Dispose();
            con.Close();
        }

    }

    public void UpdateNurseStatus(int TreatmentId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_UpdateNurseStatus", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@TreatmentId", TreatmentId);
            
            cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            con.Dispose();
            con.Close();
        }

    }
    public clsTreatmentTransaction SelectDrugTrasaction(int TransId)
    {
        clsTreatmentTransaction obj = new clsTreatmentTransaction();
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_FillEditDrugTransaction", con);
        cmd.CommandType = CommandType.StoredProcedure;


        try
        {
            cmd.Parameters.AddWithValue("@TransId", TransId);
            
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                obj.DrugName = Convert.ToString(sdr["DrugName"]);
                obj.ItemId = Convert.ToInt32(sdr["ItemId"]);
                obj.Qty = Convert.ToSingle(sdr["Qty"]);
                obj.Note = Convert.ToString(sdr["Note"]);
                obj.DoseTimeId = Convert.ToInt32(sdr["DoseTimeId"]);
                obj.Days = Convert.ToString(sdr["Days"]);
                obj.DoseId = Convert.ToInt32(sdr["DoseId"]);
                obj.InstName = Convert.ToString(sdr["InstName"]);
                obj.NewDose = Convert.ToString(sdr["NewDose"]);
                obj.Route = Convert.ToString(sdr["Route"]);
               // obj.routess = Convert.ToString(sdr["NewDose"]);
                
            }
            return obj;
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

    public void UpdateDrugTransaction(string drugname,float Qty,string note,int ItemId,int TransId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_UpdateDrugTransaction", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@TransId", TransId);
            cmd.Parameters.AddWithValue("@ItemId", ItemId);
            cmd.Parameters.AddWithValue("@Qty", Qty);
            cmd.Parameters.AddWithValue("@Note",note);
            cmd.Parameters.AddWithValue("@DrugName", drugname);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            con.Dispose();
            con.Close();
        }

    }
    public void UpdateTreatementTransaction(string drugname, int DoseId, string Dose, int DoseTimeId, string days, string note, int ItemId, int TransId, string FrequencyType, string InstName, string NewDose, string Route)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_UpdateTreatmentTransaction", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@TransId", TransId);
            cmd.Parameters.AddWithValue("@ItemId", ItemId);
            cmd.Parameters.AddWithValue("@DoseId", DoseId);
            cmd.Parameters.AddWithValue("@Dose", Dose);
            cmd.Parameters.AddWithValue("@DoseTimeId", DoseTimeId);
            cmd.Parameters.AddWithValue("@Days", days);
            cmd.Parameters.AddWithValue("@Note", note);
            cmd.Parameters.AddWithValue("@DrugName", drugname);
            cmd.Parameters.AddWithValue("@FrequencyType", FrequencyType);
            cmd.Parameters.AddWithValue("@InstName", InstName);
            cmd.Parameters.AddWithValue("@NewDose", NewDose);
            cmd.Parameters.AddWithValue("@Route", Route);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            con.Dispose();
            con.Close();
        }

    }

    public void UpdateTreatementTransaction_555(string drugname, int DoseId, string Dose, int DoseTimeId, string days, string note, int ItemId, int TransId, string FrequencyType, string InstName, string NewDose,string Route)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_UpdateTreatmentTransaction", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@TransId", TransId);
            cmd.Parameters.AddWithValue("@ItemId", ItemId);
            cmd.Parameters.AddWithValue("@DoseId", DoseId);
            cmd.Parameters.AddWithValue("@Dose", Dose);
            cmd.Parameters.AddWithValue("@DoseTimeId", DoseTimeId);
            cmd.Parameters.AddWithValue("@Days", days);
            cmd.Parameters.AddWithValue("@Note", note);
            cmd.Parameters.AddWithValue("@DrugName", drugname);
            cmd.Parameters.AddWithValue("@FrequencyType", FrequencyType);
            cmd.Parameters.AddWithValue("@InstName", InstName);
            cmd.Parameters.AddWithValue("@NewDose", NewDose);
            cmd.Parameters.AddWithValue("@Route", Route);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            con.Dispose();
            con.Close();
        }

    }
    public DataSet SearchEmergencyPatientList(string FromDate, string ToDate, int Patregid, int OpdNo, int ipdno, int DrId, string MobNo, int Status,string type)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetEmergencyPatientList", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            if (FromDate == "")
            {
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            }
            else
            {
                // cmd.Parameters.AddWithValue("@FromDate",Convert.ToDateTime(FromDate));
                cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            if (ToDate == "")
            {
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            }
            else
            {
                // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }

            cmd.Parameters.AddWithValue("@Patregid", Patregid);
            cmd.Parameters.AddWithValue("@Opdno", OpdNo);
            cmd.Parameters.AddWithValue("@Ipdno", ipdno);

            cmd.Parameters.AddWithValue("@DrId", DrId);
            cmd.Parameters.AddWithValue("@MobNo", MobNo);
            cmd.Parameters.AddWithValue("@Status", Status);
            cmd.Parameters.AddWithValue("@Type", type);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Dispose();
            con.Close();
        }
    }
    public List<string> AutoFillDrNameName(string prefixtext)
    {
        // BEL ItemInfo = new BEL();

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        //con.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;//ToString();

        try
        {
            SqlCommand cmd = new SqlCommand("Sp_Get_DrList", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Search", prefixtext);


            List<string> items = new List<string>();
            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                items.Add(sdr["DrName"].ToString());
            }



            return items;
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

    public List<string> AutoFillPatientName(string prefixtext)
    {
        // BEL ItemInfo = new BEL();

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        //con.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;//ToString();

        try
        {
            SqlCommand cmd = new SqlCommand("Sp_GetTreatmentPatientList", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Search", prefixtext);


            List<string> items = new List<string>();
            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                items.Add(sdr["PatientName"].ToString());
            }



            return items;
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

    public void InsertDrugTransaction(string drugname, float Qty, string note, int ItemId, int TreatmentId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_InsertDrugTransaction", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@TreatmentId", TreatmentId);
            cmd.Parameters.AddWithValue("@ItemId", ItemId);
            cmd.Parameters.AddWithValue("@Qty", Qty);
            cmd.Parameters.AddWithValue("@Note", note);
            cmd.Parameters.AddWithValue("@DrugName", drugname);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            con.Dispose();
            con.Close();
        }

    }

    public DataSet BindDrugList(int TreatmentId)
    {
        DataSet dt = new DataSet();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;
            using (SqlConnection connection =  DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("Sp_GetDrugListOfTreatment", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@TreatmentId", SqlDbType.VarChar).Value = TreatmentId;
                    connection.Open();

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                }
            }
        }
        catch (Exception)
        {
        }
        return dt;
    }

    public DataSet BindDrugList_IPD(int TreatmentId)
    {
        DataSet dt = new DataSet();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;
            using (SqlConnection connection = DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("Sp_GetDrugListOfIPDTreatment", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@TreatmentId", SqlDbType.VarChar).Value = TreatmentId;
                    connection.Open();

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                }
            }
        }
        catch (Exception)
        {
        }
        return dt;
    }



    public DataTable GetTreatmentIDFor_PatientId(string PatientRegId, string Opd, string Ipd)
    {
        DataTable dt = new DataTable();

        using (SqlConnection con = DataAccess.ConInitForDC())
        {
            using (SqlCommand cmd = new SqlCommand("SP_GetTreatmentId", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PatientRegId", PatientRegId);
                cmd.Parameters.AddWithValue("@Opd", Opd);
                cmd.Parameters.AddWithValue("@Ipd", Ipd);
                
                con.Open();

                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(dt);
                }

                con.Close();
                con.Dispose();
            }
        }
        return dt;
    }
    public DataTable GetTreatmentIDFor_PatientId_ReferToAdmission(string PatientRegId, string Opd, string Ipd)
    {
        DataTable dt = new DataTable();

        using (SqlConnection con = DataAccess.ConInitForDC())
        {
            using (SqlCommand cmd = new SqlCommand("SP_GetTreatmentId_ReferToAdmission", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PatientRegId", PatientRegId);
                cmd.Parameters.AddWithValue("@Opd", Opd);
                cmd.Parameters.AddWithValue("@Ipd", Ipd);

                con.Open();

                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(dt);
                }

                con.Close();
                con.Dispose();
            }
        }
        return dt;
    }

    public DataSet SearchIPDPatientListForNurse(string FromDate, string ToDate, int Patregid, int OpdNo, int ipdno, int DrId, string MobNo, int Status, string type)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetPDPatientListForNurse", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            if (FromDate == "")
            {
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            }
            else
            {
                // cmd.Parameters.AddWithValue("@FromDate",Convert.ToDateTime(FromDate));
                cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            if (ToDate == "")
            {
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            }
            else
            {
                // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }

            cmd.Parameters.AddWithValue("@Patregid", Patregid);
            cmd.Parameters.AddWithValue("@Opdno", OpdNo);
            cmd.Parameters.AddWithValue("@Ipdno", ipdno);

            cmd.Parameters.AddWithValue("@DrId", DrId);
            cmd.Parameters.AddWithValue("@MobNo", MobNo);
            cmd.Parameters.AddWithValue("@Status", Status);
            cmd.Parameters.AddWithValue("@Type", type);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            cmd.CommandTimeout = 5000;
            sda.Fill(ds);
            return ds;

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Dispose();
            con.Close();
        }
    }

    public void InsertIPD_DrugTransaction(string drugname, float Qty, string note, int ItemId, int TreatmentId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_InsertIPD_DrugTransaction", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@TreatmentId", TreatmentId);
            cmd.Parameters.AddWithValue("@ItemId", ItemId);
            cmd.Parameters.AddWithValue("@Qty", Qty);
            cmd.Parameters.AddWithValue("@Note", note);
            cmd.Parameters.AddWithValue("@DrugName", drugname);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            con.Dispose();
            con.Close();
        }

    }

    public DataTable GetTreatmentIDFor_PatientId_PostPo(string PatientRegId, string Opd, string Ipd)
    {
        DataTable dt = new DataTable();

        using (SqlConnection con = DataAccess.ConInitForDC())
        {
            using (SqlCommand cmd = new SqlCommand("SP_GetTreatmentId_PostPo", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PatientRegId", PatientRegId);
                cmd.Parameters.AddWithValue("@Opd", Opd);
                cmd.Parameters.AddWithValue("@Ipd", Ipd);

                con.Open();

                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(dt);
                }

                con.Close();
                con.Dispose();
            }
        }
        return dt;
    }
    public DataTable GetReqDrugByNurseToPatient(int patregId, int IpdNo)
    {
        DataTable dt = new DataTable();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;
            using (SqlConnection connection = DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("Sp_GetTreatmentDetails_Ipd_Nurse", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@PatRegId", SqlDbType.VarChar).Value = patregId;
                    cmd.Parameters.Add("@IpdNo", SqlDbType.Int).Value = IpdNo;
                    connection.Open();

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                }
                connection.Close();
                connection.Dispose();
            }
        }
        catch (Exception)
        {
        }
        return dt;
    }
    public DataTable GetTreatmentIDFor_PatientId_DiscMedi(string PatientRegId, string Opd, string Ipd)
    {
        DataTable dt = new DataTable();

        using (SqlConnection con = DataAccess.ConInitForDC())
        {
            using (SqlCommand cmd = new SqlCommand("SP_GetTreatmentId_DiscMedi", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PatientRegId", PatientRegId);
                cmd.Parameters.AddWithValue("@Opd", Opd);
                cmd.Parameters.AddWithValue("@Ipd", Ipd);

                con.Open();

                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(dt);
                }

                con.Close();
                con.Dispose();
            }
        }
        return dt;
    }

    public DataTable CheckTestIsDesc(string patregId)
    {
        DataTable dt = new DataTable();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;
            using (SqlConnection connection = DataAccess.ConInitForMedical())
            {
                using (SqlCommand cmd = new SqlCommand("SP_CheckTestIsDesc", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@PatRegId", SqlDbType.VarChar).Value = patregId;
                    connection.Open();

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                }
            }
        }
        catch (Exception)
        {
        }
        return dt;
    }
}