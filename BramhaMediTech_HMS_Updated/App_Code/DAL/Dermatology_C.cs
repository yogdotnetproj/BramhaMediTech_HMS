using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Dental_Clinic_C
/// </summary>
public class Dermatology_C
{
    DataAccess da = new DataAccess();
    public Dermatology_C()
	{
       // this.P_DischargeDate = Date.getMinDate();
        this.P_EntryDate = Date.getMinDate();
       // this.P_TreatementDate = Date.getMinDate();
	}
    private int Patregid;    public int P_Patregid    {        get { return Patregid; }        set { Patregid = value; }    }
    private int OpdNo;    public int P_OpdNo    {        get { return OpdNo; }        set { OpdNo = value; }    }
    private int IpdNo;    public int P_IpdNo    {        get { return IpdNo; }        set { IpdNo = value; }    }

    private DateTime EntryDate;    public DateTime P_EntryDate    {        get { return EntryDate; }        set { EntryDate = value; }    }   

    private int Branchid;    public int P_Branchid    {        get { return Branchid; }        set { Branchid = value; }    }
    private string CreatedBy;    public string P_CreatedBy    {        get { return CreatedBy; }        set { CreatedBy = value; }    }  
    private string Remarks; public string P_Remarks { get { return Remarks; } set { Remarks = value; } }
    private string Area; public string P_Area { get { return Area; } set { Area = value; } }
    private string Depth; public string P_Depth { get { return Depth; } set { Depth = value; } }
    private string Level; public string P_Level { get { return Level; } set { Level = value; } }
    private string Time; public string P_Time { get { return Time; } set { Time = value; } }

    private string Pulse; public string P_Pulse { get { return Pulse; } set { Pulse = value; } }
    private string Energy; public string P_Energy { get { return Energy; } set { Energy = value; } }
    private string Charge; public string P_Charge { get { return Charge; } set { Charge = value; } }

    private string BloodPressure; public string P_BloodPressure { get { return BloodPressure; } set { BloodPressure = value; } }
    private string Temperature; public string P_Temperature { get { return Temperature; } set { Temperature = value; } }
    private string Other_Complaints; public string P_Other_Complaints { get { return Other_Complaints; } set { Other_Complaints = value; } }
    private string ExaminationFindings; public string P_ExaminationFindings { get { return ExaminationFindings; } set { ExaminationFindings = value; } }
    private string OtherTreatment; public string P_OtherTreatment { get { return OtherTreatment; } set { OtherTreatment = value; } }
    private string Treatment; public string P_Treatment { get { return Treatment; } set { Treatment = value; } }
    private string Peel; public string P_Peel { get { return Peel; } set { Peel = value; } }
    private string IntraLeisonSteroidOther; public string P_IntraLeisonSteroidOther { get { return IntraLeisonSteroidOther; } set { IntraLeisonSteroidOther = value; } }

    private bool _Is_Itech; public bool Is_Itech { get { return _Is_Itech; } set { _Is_Itech = value; } }
    private bool _Is_Rash; public bool Is_Rash { get { return _Is_Rash; } set { _Is_Rash = value; } }
    private bool _Is_Pigmentation; public bool Is_Pigmentation { get { return _Is_Pigmentation; } set { _Is_Pigmentation = value; } }
    private bool _Is_Acne; public bool Is_Acne { get { return _Is_Acne; } set { _Is_Acne = value; } }
    private bool _Is_Scar; public bool Is_Scar { get { return _Is_Scar; } set { _Is_Scar = value; } }

    private bool _Is_Hirsutism; public bool Is_Hirsutism { get { return _Is_Hirsutism; } set { _Is_Hirsutism = value; } }
    private bool _Is_HairLoss; public bool Is_HairLoss { get { return _Is_HairLoss; } set { _Is_HairLoss = value; } }
    private bool _Is_ExcessHairGrowth; public bool Is_ExcessHairGrowth { get { return _Is_ExcessHairGrowth; } set { _Is_ExcessHairGrowth = value; } }
    private bool _Is_Face; public bool Is_Face { get { return _Is_Face; } set { _Is_Face = value; } }
    private bool _Is_Body; public bool Is_Body { get { return _Is_Body; } set { _Is_Body = value; } }

    private bool _Is_Extremities; public bool Is_Extremities { get { return _Is_Extremities; } set { _Is_Extremities = value; } }
    private bool _Is_DM; public bool Is_DM { get { return _Is_DM; } set { _Is_DM = value; } }
    private bool _Is_HTN; public bool Is_HTN { get { return _Is_HTN; } set { _Is_HTN = value; } }
    private bool _Is_Smoker; public bool Is_Smoker { get { return _Is_Smoker; } set { _Is_Smoker = value; } }
    private bool _Is_Alcoholic; public bool Is_Alcoholic { get { return _Is_Alcoholic; } set { _Is_Alcoholic = value; } }

    private bool _Is_Tablets; public bool Is_Tablets { get { return _Is_Tablets; } set { _Is_Tablets = value; } }
    private bool _Is_Capsules; public bool Is_Capsules { get { return _Is_Capsules; } set { _Is_Capsules = value; } }
    private bool _Is_Cream; public bool Is_Cream { get { return _Is_Cream; } set { _Is_Cream = value; } }
    private bool _Is_Ointment; public bool Is_Ointment { get { return _Is_Ointment; } set { _Is_Ointment = value; } }
    private bool _Is_Lotion; public bool Is_Lotion { get { return _Is_Lotion; } set { _Is_Lotion = value; } }
    private bool _Is_Shampoo; public bool Is_Shampoo { get { return _Is_Shampoo; } set { _Is_Shampoo = value; } }
    private bool _Is_Soap; public bool Is_Soap { get { return _Is_Soap; } set { _Is_Soap = value; } }
    private bool _Is_Sunscreen; public bool Is_Sunscreen { get { return _Is_Sunscreen; } set { _Is_Sunscreen = value; } }

    private bool _Is_HairLaser; public bool Is_HairLaser { get { return _Is_HairLaser; } set { _Is_HairLaser = value; } }
    private bool _Is_CO2Laser; public bool Is_CO2Laser { get { return _Is_CO2Laser; } set { _Is_CO2Laser = value; } }
    private bool _Is_INFINITouch; public bool Is_INFINITouch { get { return _Is_INFINITouch; } set { _Is_INFINITouch = value; } }
    private bool _Is_Triamcinolone; public bool Is_Triamcinolone { get { return _Is_Triamcinolone; } set { _Is_Triamcinolone = value; } }

    // ----------------Opthalmology------------------

    public void Insert_InfiniChart()
    {

        SqlConnection conn = DataAccess.ConInitForDC();
        SqlCommand sc = new SqlCommand();
        sc.CommandType = CommandType.StoredProcedure;
        sc.Connection = conn;
        sc.CommandText = "SP_Insert_Drematology_InfiniChart";
        sc.Parameters.Add(new SqlParameter("@Patregid", SqlDbType.Int)).Value = P_Patregid;
        sc.Parameters.Add(new SqlParameter("@OPDNO", SqlDbType.Int)).Value = P_OpdNo;
        sc.Parameters.Add(new SqlParameter("@IPDNO", SqlDbType.Int)).Value = P_IpdNo;
        sc.Parameters.Add(new SqlParameter("@Area", SqlDbType.NVarChar, 500)).Value = P_Area;
        sc.Parameters.Add(new SqlParameter("@Depth", SqlDbType.NVarChar, 500)).Value = P_Depth;


        if (this.P_EntryDate == Date.getMinDate())
            sc.Parameters.Add(new SqlParameter("@InfiniDate", SqlDbType.DateTime)).Value = DBNull.Value;
        else
            sc.Parameters.Add(new SqlParameter("@InfiniDate", SqlDbType.DateTime)).Value = P_EntryDate;
        sc.Parameters.Add(new SqlParameter("@InfiLevel", SqlDbType.NVarChar, 250)).Value = P_Level;

        sc.Parameters.Add(new SqlParameter("@InfiTime", SqlDbType.NVarChar, 250)).Value = P_Time;
      
        sc.Parameters.Add(new SqlParameter("@CreatedBy", SqlDbType.NVarChar, 250)).Value = P_CreatedBy;
       
        sc.Parameters.Add(new SqlParameter("@Branchid", SqlDbType.Int)).Value = P_Branchid;



        try
        {
            conn.Open();
            sc.ExecuteNonQuery();
        }
        catch (SqlException)
        {
            throw;
        }
        finally
        {
            conn.Close(); conn.Dispose();
        }
    }

    public void Insert_HairLaser()
    {

        SqlConnection conn = DataAccess.ConInitForDC();
        SqlCommand sc = new SqlCommand();
        sc.CommandType = CommandType.StoredProcedure;
        sc.Connection = conn;
        sc.CommandText = "SP_Insert_Hair_Laser_Section";
        sc.Parameters.Add(new SqlParameter("@Patregid", SqlDbType.Int)).Value = P_Patregid;
        sc.Parameters.Add(new SqlParameter("@OPDNO", SqlDbType.Int)).Value = P_OpdNo;
        sc.Parameters.Add(new SqlParameter("@IPDNO", SqlDbType.Int)).Value = P_IpdNo;
        sc.Parameters.Add(new SqlParameter("@Pulse", SqlDbType.NVarChar, 500)).Value = P_Pulse;
        sc.Parameters.Add(new SqlParameter("@Energy", SqlDbType.NVarChar, 500)).Value = P_Energy;


        if (this.P_EntryDate == Date.getMinDate())
            sc.Parameters.Add(new SqlParameter("@HairLaserDate", SqlDbType.DateTime)).Value = DBNull.Value;
        else
            sc.Parameters.Add(new SqlParameter("@HairLaserDate", SqlDbType.DateTime)).Value = P_EntryDate;

        sc.Parameters.Add(new SqlParameter("@Charge", SqlDbType.NVarChar, 250)).Value = P_Charge;
        sc.Parameters.Add(new SqlParameter("@CreatedBy", SqlDbType.NVarChar, 250)).Value = P_CreatedBy;

        sc.Parameters.Add(new SqlParameter("@Branchid", SqlDbType.Int)).Value = P_Branchid;



        try
        {
            conn.Open();
            sc.ExecuteNonQuery();
        }
        catch (SqlException)
        {
            throw;
        }
        finally
        {
            conn.Close(); conn.Dispose();
        }
    }

    public void Insert_DermatologyOutPatients()
    {

        SqlConnection conn = DataAccess.ConInitForDC();
        SqlCommand sc = new SqlCommand();
        sc.CommandType = CommandType.StoredProcedure;
        sc.Connection = conn;
        sc.CommandText = "SP_Insert_DermatologyOutPatient";
        sc.Parameters.Add(new SqlParameter("@Patregid", SqlDbType.Int)).Value = P_Patregid;
        sc.Parameters.Add(new SqlParameter("@OPDNO", SqlDbType.Int)).Value = P_OpdNo;
        sc.Parameters.Add(new SqlParameter("@IPDNO", SqlDbType.Int)).Value = P_IpdNo;
        sc.Parameters.Add(new SqlParameter("@Pulse", SqlDbType.NVarChar, 500)).Value = P_Pulse;
        sc.Parameters.Add(new SqlParameter("@BloodPressure", SqlDbType.NVarChar, 500)).Value = P_BloodPressure;


        //if (this.P_EntryDate == Date.getMinDate())
        //    sc.Parameters.Add(new SqlParameter("@HairLaserDate", SqlDbType.DateTime)).Value = DBNull.Value;
        //else
        //    sc.Parameters.Add(new SqlParameter("@HairLaserDate", SqlDbType.DateTime)).Value = P_EntryDate;

        sc.Parameters.Add(new SqlParameter("@Temperature", SqlDbType.NVarChar, 250)).Value = P_Temperature;
        sc.Parameters.Add(new SqlParameter("@Other_Complaints", SqlDbType.NVarChar, 250)).Value = P_Other_Complaints;
        sc.Parameters.Add(new SqlParameter("@ExaminationFindings", SqlDbType.NVarChar, 250)).Value = P_ExaminationFindings;
        sc.Parameters.Add(new SqlParameter("@OtherTreatment", SqlDbType.NVarChar, 250)).Value = P_OtherTreatment;
        sc.Parameters.Add(new SqlParameter("@Treatment", SqlDbType.NVarChar, 250)).Value = P_Treatment;
        sc.Parameters.Add(new SqlParameter("@Peel", SqlDbType.NVarChar, 250)).Value = P_Peel;
        sc.Parameters.Add(new SqlParameter("@IntraLeisonSteroidOther", SqlDbType.NVarChar, 250)).Value = P_IntraLeisonSteroidOther;

        sc.Parameters.Add(new SqlParameter("@Is_Itech", SqlDbType.Bit)).Value = Is_Itech;
        sc.Parameters.Add(new SqlParameter("@Is_Rash", SqlDbType.Bit)).Value = Is_Rash;
        sc.Parameters.Add(new SqlParameter("@Is_Pigmentation", SqlDbType.Bit)).Value = Is_Pigmentation;
        sc.Parameters.Add(new SqlParameter("@Is_Acne", SqlDbType.Bit)).Value = Is_Acne;
        sc.Parameters.Add(new SqlParameter("@Is_Scar", SqlDbType.Bit)).Value = Is_Scar;
        sc.Parameters.Add(new SqlParameter("@Is_Hirsutism", SqlDbType.Bit)).Value = Is_Hirsutism;
        sc.Parameters.Add(new SqlParameter("@Is_HairLoss", SqlDbType.Bit)).Value = Is_HairLoss;
        sc.Parameters.Add(new SqlParameter("@Is_ExcessHairGrowth", SqlDbType.Bit)).Value = Is_ExcessHairGrowth;
        sc.Parameters.Add(new SqlParameter("@Is_Face", SqlDbType.Bit)).Value = Is_Face;
        sc.Parameters.Add(new SqlParameter("@Is_Body", SqlDbType.Bit)).Value = Is_Body;
        sc.Parameters.Add(new SqlParameter("@Is_Extremities", SqlDbType.Bit)).Value = Is_Extremities;
        sc.Parameters.Add(new SqlParameter("@Is_DM", SqlDbType.Bit)).Value = Is_DM;
        sc.Parameters.Add(new SqlParameter("@Is_HTN", SqlDbType.Bit)).Value = Is_HTN;
        sc.Parameters.Add(new SqlParameter("@Is_Smoker", SqlDbType.Bit)).Value = Is_Smoker;
        sc.Parameters.Add(new SqlParameter("@Is_Alcoholic", SqlDbType.Bit)).Value = Is_Alcoholic;
        sc.Parameters.Add(new SqlParameter("@Is_Tablets", SqlDbType.Bit)).Value = Is_Tablets;
        sc.Parameters.Add(new SqlParameter("@Is_Capsules", SqlDbType.Bit)).Value = Is_Capsules;

        sc.Parameters.Add(new SqlParameter("@Is_Cream", SqlDbType.Bit)).Value = Is_Cream;
        sc.Parameters.Add(new SqlParameter("@Is_Ointment", SqlDbType.Bit)).Value = Is_Ointment;
        sc.Parameters.Add(new SqlParameter("@Is_Lotion", SqlDbType.Bit)).Value = Is_Lotion;
        sc.Parameters.Add(new SqlParameter("@Is_Shampoo", SqlDbType.Bit)).Value = Is_Shampoo;
        sc.Parameters.Add(new SqlParameter("@Is_Soap", SqlDbType.Bit)).Value = Is_Soap;
        sc.Parameters.Add(new SqlParameter("@Is_Sunscreen", SqlDbType.Bit)).Value = Is_Sunscreen;
        sc.Parameters.Add(new SqlParameter("@Is_HairLaser", SqlDbType.Bit)).Value = Is_HairLaser;
        sc.Parameters.Add(new SqlParameter("@Is_CO2Laser", SqlDbType.Bit)).Value = Is_CO2Laser;
        sc.Parameters.Add(new SqlParameter("@Is_INFINITouch", SqlDbType.Bit)).Value = Is_INFINITouch;
        sc.Parameters.Add(new SqlParameter("@Is_Triamcinolone", SqlDbType.Bit)).Value = Is_Triamcinolone;
       


        sc.Parameters.Add(new SqlParameter("@CreatedBy", SqlDbType.NVarChar, 250)).Value = P_CreatedBy;

        sc.Parameters.Add(new SqlParameter("@Branchid", SqlDbType.Int)).Value = P_Branchid;



        try
        {
            conn.Open();
            sc.ExecuteNonQuery();
        }
        catch (SqlException)
        {
            throw;
        }
        finally
        {
            conn.Close(); conn.Dispose();
        }
    }

    //public void Insert_DentalDiagnosis_Treatment()
    //{

    //    SqlConnection conn = DataAccess.ConInitForDC();
    //    SqlCommand sc = new SqlCommand();
    //    sc.CommandType = CommandType.StoredProcedure;
    //    sc.Connection = conn;
    //    sc.CommandText = "SP_InsertDental_Diagnosis_Treatment";
    //    sc.Parameters.Add(new SqlParameter("@Patregid", SqlDbType.Int)).Value = P_Patregid;
    //    sc.Parameters.Add(new SqlParameter("@OPDNo", SqlDbType.Int)).Value = P_OpdNo;
    //    sc.Parameters.Add(new SqlParameter("@IPDNo", SqlDbType.Int)).Value = P_IpdNo;
    //    sc.Parameters.Add(new SqlParameter("@ReferBy", SqlDbType.NVarChar, 500)).Value = P_ReferBy;
      
    //    if (this.P_EntryDate == Date.getMinDate())
    //        sc.Parameters.Add(new SqlParameter("@EntryDate", SqlDbType.DateTime)).Value = DBNull.Value;
    //    else
    //        sc.Parameters.Add(new SqlParameter("@EntryDate", SqlDbType.DateTime)).Value = P_EntryDate;

    //    sc.Parameters.Add(new SqlParameter("@Diagnosis", SqlDbType.NVarChar, 2500)).Value = P_Diagnosis;

    //    sc.Parameters.Add(new SqlParameter("@TreatmentAdvised", SqlDbType.NVarChar, 2500)).Value = P_TreatmentAdvised;
      
    //    sc.Parameters.Add(new SqlParameter("@CreatedBy", SqlDbType.NVarChar, 250)).Value = P_CreatedBy;      
    //    sc.Parameters.Add(new SqlParameter("@Branchid", SqlDbType.Int)).Value = P_Branchid;



    //    try
    //    {
    //        conn.Open();
    //        sc.ExecuteNonQuery();
    //    }
    //    catch (SqlException)
    //    {
    //        throw;
    //    }
    //    finally
    //    {
    //        conn.Close(); conn.Dispose();
    //    }
    //}

    //public void Insert_DentalTreatment_Details()
    //{

    //    SqlConnection conn = DataAccess.ConInitForDC();
    //    SqlCommand sc = new SqlCommand();
    //    sc.CommandType = CommandType.StoredProcedure;
    //    sc.Connection = conn;
    //    sc.CommandText = "SP_InsertDental_Treatment_Details";
    //    sc.Parameters.Add(new SqlParameter("@Patregid", SqlDbType.Int)).Value = P_Patregid;
    //    sc.Parameters.Add(new SqlParameter("@OPDNo", SqlDbType.Int)).Value = P_OpdNo;
    //    sc.Parameters.Add(new SqlParameter("@IPDNo", SqlDbType.Int)).Value = P_IpdNo;
    //    sc.Parameters.Add(new SqlParameter("@ReferBy", SqlDbType.NVarChar, 500)).Value = P_ReferBy;

    //    if (this.P_EntryDate == Date.getMinDate())
    //        sc.Parameters.Add(new SqlParameter("@EntryDate", SqlDbType.DateTime)).Value = DBNull.Value;
    //    else
    //        sc.Parameters.Add(new SqlParameter("@EntryDate", SqlDbType.DateTime)).Value = P_EntryDate;

    //    if (this.P_TreatementDate == Date.getMinDate())
    //        sc.Parameters.Add(new SqlParameter("@TreatementDate", SqlDbType.DateTime)).Value = DBNull.Value;
    //    else
    //        sc.Parameters.Add(new SqlParameter("@TreatementDate", SqlDbType.DateTime)).Value = P_TreatementDate;

    //    sc.Parameters.Add(new SqlParameter("@TreatmentDone", SqlDbType.NVarChar, 2500)).Value = P_TreatmentDone;

    //    sc.Parameters.Add(new SqlParameter("@NextAppointment", SqlDbType.NVarChar, 2500)).Value = P_NextAppointment;
    //    sc.Parameters.Add(new SqlParameter("@Remarks", SqlDbType.NVarChar, 2500)).Value = P_Remarks;

    //    sc.Parameters.Add(new SqlParameter("@CreatedBy", SqlDbType.NVarChar, 250)).Value = P_CreatedBy;
    //    sc.Parameters.Add(new SqlParameter("@Branchid", SqlDbType.Int)).Value = P_Branchid;



    //    try
    //    {
    //        conn.Open();
    //        sc.ExecuteNonQuery();
    //    }
    //    catch (SqlException)
    //    {
    //        throw;
    //    }
    //    finally
    //    {
    //        conn.Close(); conn.Dispose();
    //    }
    //}

    public void Alter_InfiChart_Report(int patregid, int OpdNo, int IpdNo)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Alter_Vw_Drematology_InfiniChart_Report", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@PatregId", patregid);
            cmd.Parameters.AddWithValue("@OpdNo", OpdNo);
            cmd.Parameters.AddWithValue("@IpdNo", IpdNo);

            cmd.ExecuteNonQuery();



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

    public void Alter_Hair_Laser_Section_Report(int patregid, int OpdNo, int IpdNo)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Alter_Vw_Hair_Laser_Section_Report", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@PatregId", patregid);
            cmd.Parameters.AddWithValue("@OpdNo", OpdNo);
            cmd.Parameters.AddWithValue("@IpdNo", IpdNo);

            cmd.ExecuteNonQuery();
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

    public void Alter_DermatologyOutPatients_Report(int patregid, int OpdNo, int IpdNo)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Alter_Vw_DermatologyOutPatient_Report", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@PatregId", patregid);
            cmd.Parameters.AddWithValue("@OpdNo", OpdNo);
            cmd.Parameters.AddWithValue("@IpdNo", IpdNo);

            cmd.ExecuteNonQuery();



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

    //public void Alter_Dental_Diagnosis_Treatment_Report(int patregid, int OpdNo, int IpdNo)
    //{
    //    SqlConnection con = DataAccess.ConInitForDC();
    //    con.Open();
    //    SqlCommand cmd = new SqlCommand("Sp_Alter_Vw_Dental_Diagnosis_Treatment_Report", con);
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    try
    //    {

    //        cmd.Parameters.AddWithValue("@PatregId", patregid);
    //        cmd.Parameters.AddWithValue("@OpdNo", OpdNo);
    //        cmd.Parameters.AddWithValue("@IpdNo", IpdNo);

    //        cmd.ExecuteNonQuery();



    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    finally
    //    {
    //        con.Close();
    //        con.Dispose();
    //    }
    //}

    //public void Alter_Dental_Treatment_Report(int patregid, int OpdNo, int IpdNo)
    //{
    //    SqlConnection con = DataAccess.ConInitForDC();
    //    con.Open();
    //    SqlCommand cmd = new SqlCommand("Sp_Alter_Vw_Dental_Treatment_Details_Report", con);
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    try
    //    {

    //        cmd.Parameters.AddWithValue("@PatregId", patregid);
    //        cmd.Parameters.AddWithValue("@OpdNo", OpdNo);
    //        cmd.Parameters.AddWithValue("@IpdNo", IpdNo);

    //        cmd.ExecuteNonQuery();



    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    finally
    //    {
    //        con.Close();
    //        con.Dispose();
    //    }
    //}

}