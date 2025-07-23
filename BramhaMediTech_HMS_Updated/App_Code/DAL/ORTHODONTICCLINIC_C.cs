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
public class ORTHODONTICCLINIC_C
{
    DataAccess da = new DataAccess();
    public ORTHODONTICCLINIC_C()
	{
       // this.P_DischargeDate = Date.getMinDate();
        this.P_EntryDate = Date.getMinDate();
        this.P_TreatementDate = Date.getMinDate();
	}
    private int Patregid;    public int P_Patregid    {        get { return Patregid; }        set { Patregid = value; }    }

    private int OpdNo;    public int P_OpdNo    {        get { return OpdNo; }        set { OpdNo = value; }    }

    private int IpdNo;    public int P_IpdNo    {        get { return IpdNo; }        set { IpdNo = value; }    }

    private DateTime EntryDate;    public DateTime P_EntryDate    {        get { return EntryDate; }        set { EntryDate = value; }    }
    private string ReferBy; public string P_ReferBy { get { return ReferBy; } set { ReferBy = value; } }
    private string OrthoNo; public string P_OrthoNo { get { return OrthoNo; } set { OrthoNo = value; } }
    private string Medication; public string P_Medication { get { return Medication; } set { Medication = value; } }
    private string ChiefComplants;    public string P_ChiefComplants    {        get { return ChiefComplants; }        set { ChiefComplants = value; }    }  
   
    private string Habits;    public string P_Habits    {        get { return Habits; }        set { Habits = value; }    }
    private string PastDentalHistory;    public string P_PastDentalHistory    {        get { return PastDentalHistory; }        set { PastDentalHistory = value; }    }
    private string FamilyHistory; public string P_FamilyHistory { get { return FamilyHistory; } set { FamilyHistory = value; } }
    private string OtherHistory; public string P_OtherHistory { get { return OtherHistory; } set { OtherHistory = value; } }

    private bool Hypertension;    public bool P_Hypertension    {        get { return Hypertension; }        set { Hypertension = value; }    }
    private bool Diabetes;    public bool P_Diabetes   {        get { return Diabetes; }        set { Diabetes = value; }    }
    private bool Anaemia;    public bool P_Anaemia    {        get { return Anaemia; }        set { Anaemia = value; }    }
    private bool KidneyDisease;    public bool P_KidneyDisease    {        get { return KidneyDisease; }        set { KidneyDisease = value; }    }
    private bool Asthama;    public bool P_Asthama    {        get { return Asthama; }        set { Asthama = value; }    }
    private bool Jaundice;    public bool P_Jaundice    {        get { return Jaundice; }        set { Jaundice = value; }    }
    private bool Allergy; public bool P_Allergy { get { return Allergy; } set { Allergy = value; } }
    private bool BleedingDisorder; public bool P_BleedingDisorder { get { return BleedingDisorder; } set { BleedingDisorder = value; } }
    private bool Pregnant; public bool P_Pregnant { get { return Pregnant; } set { Pregnant = value; } }
    private int Branchid;    public int P_Branchid    {        get { return Branchid; }        set { Branchid = value; }    }
    private string CreatedBy;    public string P_CreatedBy    {        get { return CreatedBy; }        set { CreatedBy = value; }    }



    private string Diagnosis; public string P_Diagnosis { get { return Diagnosis; } set { Diagnosis = value; } }
    private string TreatmentAdvised; public string P_TreatmentAdvised { get { return TreatmentAdvised; } set { TreatmentAdvised = value; } }

    private DateTime TreatementDate; public DateTime P_TreatementDate { get { return TreatementDate; } set { TreatementDate = value; } }
    private string TreatmentDone; public string P_TreatmentDone { get { return TreatmentDone; } set { TreatmentDone = value; } }
    private string NextAppointment; public string P_NextAppointment { get { return NextAppointment; } set { NextAppointment = value; } }
    private string Remarks; public string P_Remarks { get { return Remarks; } set { Remarks = value; } }


    private bool Pre_Lateral; public bool P_Pre_Lateral { get { return Pre_Lateral; } set { Pre_Lateral = value; } }
    private bool Pre_Frontal; public bool P_Pre_Frontal { get { return Pre_Frontal; } set { Pre_Frontal = value; } }
    private bool Pre_OPG; public bool P_Pre_OPG { get { return Pre_OPG; } set { Pre_OPG = value; } }
    private bool Pre_IOPA; public bool P_Pre_IOPA { get { return Pre_IOPA; } set { Pre_IOPA = value; } }
    private bool Pre_SLOB; public bool P_Pre_SLOB { get { return Pre_SLOB; } set { Pre_SLOB = value; } }
    private bool Pre_OCCLUSAL; public bool P_Pre_OCCLUSAL { get { return Pre_OCCLUSAL; } set { Pre_OCCLUSAL = value; } }
    private bool Mid_Lateral; public bool P_Mid_Lateral { get { return Mid_Lateral; } set { Mid_Lateral = value; } }
    private bool Mid_Frontal; public bool P_Mid_Frontal { get { return Mid_Frontal; } set { Mid_Frontal = value; } }
    private bool Mid_OPG; public bool P_Mid_OPG { get { return Mid_OPG; } set { Mid_OPG = value; } }

    private bool Mid_IOPA; public bool P_Mid_IOPA { get { return Mid_IOPA; } set { Mid_IOPA = value; } }
    private bool Mid_SLOB; public bool P_Mid_SLOB { get { return Mid_SLOB; } set { Mid_SLOB = value; } }
    private bool Mid_OCCLUSAL; public bool P_Mid_OCCLUSAL { get { return Mid_OCCLUSAL; } set { Mid_OCCLUSAL = value; } }
    private bool Post_Lateral; public bool P_Post_Lateral { get { return Post_Lateral; } set { Post_Lateral = value; } }
    private bool Post_Frontal; public bool P_Post_Frontal { get { return Post_Frontal; } set { Post_Frontal = value; } }
    private bool Post_OPG; public bool P_Post_OPG { get { return Post_OPG; } set { Post_OPG = value; } }

    private bool Post_IOPA; public bool P_Post_IOPA { get { return Post_IOPA; } set { Post_IOPA = value; } }
    private bool Post_SLOB; public bool P_Post_SLOB { get { return Post_SLOB; } set { Post_SLOB = value; } }
    private bool Post_OCCLUSAL; public bool P_Post_OCCLUSAL { get { return Post_OCCLUSAL; } set { Post_OCCLUSAL = value; } }
    private bool EXTRAORAL; public bool P_EXTRAORAL { get { return EXTRAORAL; } set { EXTRAORAL = value; } }
    private bool INTRAORAL; public bool P_INTRAORAL { get { return INTRAORAL; } set { INTRAORAL = value; } }


    private string Pre_Model; public string P_Pre_Model { get { return Pre_Model; } set { Pre_Model = value; } }
    private string Mid_Model; public string P_Mid_Model { get { return Mid_Model; } set { Mid_Model = value; } }
    private string Post_Model; public string P_Post_Model { get { return Post_Model; } set { Post_Model = value; } }
    private string Pre_PHOTOGRAPHS; public string P_Pre_PHOTOGRAPHS { get { return Pre_PHOTOGRAPHS; } set { Pre_PHOTOGRAPHS = value; } }
    private string Mid_PHOTOGRAPHS; public string P_Mid_PHOTOGRAPHS { get { return Mid_PHOTOGRAPHS; } set { Mid_PHOTOGRAPHS = value; } }
    private string Post_PHOTOGRAPHS; public string P_Post_PHOTOGRAPHS { get { return Post_PHOTOGRAPHS; } set { Post_PHOTOGRAPHS = value; } }
    private string Pre_Other; public string P_Pre_Other { get { return Pre_Other; } set { Pre_Other = value; } }
    private string Mid_Other; public string P_Mid_Other { get { return Mid_Other; } set { Mid_Other = value; } }
    private string Post_Other; public string P_Post_Other { get { return Post_Other; } set { Post_Other = value; } }

    private string Comments; public string P_Comments { get { return Comments; } set { Comments = value; } }
    private string Comments_Models; public string P_Comments_Models { get { return Comments_Models; } set { Comments_Models = value; } }
    private string Comments_PHOTOGRAPHS; public string P_Comments_PHOTOGRAPHS { get { return Comments_PHOTOGRAPHS; } set { Comments_PHOTOGRAPHS = value; } }
    private string Comments_Other; public string P_Comments_Other { get { return Comments_Other; } set { Comments_Other = value; } }

    private string TreatmentAdvice; public string P_TreatmentAdvice { get { return TreatmentAdvice; } set { TreatmentAdvice = value; } }
    private string TreatmentAdvice1; public string P_TreatmentAdvice1 { get { return TreatmentAdvice1; } set { TreatmentAdvice1 = value; } }
    private string FunctionalRemoval; public string P_FunctionalRemoval { get { return FunctionalRemoval; } set { FunctionalRemoval = value; } }
    private string Functional_Fixed; public string P_Functional_Fixed { get { return Functional_Fixed; } set { Functional_Fixed = value; } }

    private string Orthopedic; public string P_Orthopedic { get { return Orthopedic; } set { Orthopedic = value; } }
    private string Expansion; public string P_Expansion { get { return Expansion; } set { Expansion = value; } }
    private string Upper_Retention; public string P_Upper_Retention { get { return Upper_Retention; } set { Upper_Retention = value; } }
    private string Lower_Retention; public string P_Lower_Retention { get { return Lower_Retention; } set { Lower_Retention = value; } }

  //  private string Diagnosis; public string P_Diagnosis { get { return Diagnosis; } set { Diagnosis = value; } }
    private string Appliance; public string P_Appliance { get { return Appliance; } set { Appliance = value; } }
    private string Extractions; public string P_Extractions { get { return Extractions; } set { Extractions = value; } }
    private string Envelope; public string P_Envelope { get { return Envelope; } set { Envelope = value; } }
    private string Approximate; public string P_Approximate { get { return Approximate; } set { Approximate = value; } }

    private bool IS_FunctionalRemoval; public bool P_IS_FunctionalRemoval { get { return IS_FunctionalRemoval; } set { IS_FunctionalRemoval = value; } }
    private bool Is_Functional_Fixed; public bool P_Is_Functional_Fixed { get { return Is_Functional_Fixed; } set { Is_Functional_Fixed = value; } }
    private bool IS_Orthopedic; public bool P_IS_Orthopedic { get { return IS_Orthopedic; } set { IS_Orthopedic = value; } }
    private bool IS_Expansion; public bool P_IS_Expansion { get { return IS_Expansion; } set { IS_Expansion = value; } }

    private float TreatmentAmount; public float P_TreatmentAmount { get { return TreatmentAmount; } set { TreatmentAmount = value; } }
    private float BalanceAmount; public float P_BalanceAmount { get { return BalanceAmount; } set { BalanceAmount = value; } }


    public void Alter_Orthodontic_Dental_Clinic_History_Report(int patregid, int OpdNo, int IpdNo)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Alter_Vw_Orthodontic_Dental_Clinic_History_Report", con);
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

    public void Alter_Orthodontic_Diagnosis_Treatment_Report(int patregid, int OpdNo, int IpdNo)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Alter_Vw_Orthodontic_Dental_Diagnosis_Treatment_Report", con);
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

    public void Alter_Orthodontic_Dental_OrthoTreatment_Details_Report(int patregid, int OpdNo, int IpdNo)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Alter_Vw_Orthodontic_Dental_OrthoTreatment_Details_Report", con);
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

    public void Alter_OrthodonticPrintInvestigation_Report(int patregid, int OpdNo, int IpdNo)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Alter_Vw_Orthodontic_Dental_InvestigationDetails_Report", con);
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

    public void Insert_Orthodontic_Dental_Diagnosis_Treatment()
    {

        SqlConnection conn = DataAccess.ConInitForDC();
        SqlCommand sc = new SqlCommand();
        sc.CommandType = CommandType.StoredProcedure;
        sc.Connection = conn;
        sc.CommandText = "SP_Insert_Orthodontic_Dental_Diagnosis_Treatment";
        sc.Parameters.Add(new SqlParameter("@Patregid", SqlDbType.Int)).Value = P_Patregid;
        sc.Parameters.Add(new SqlParameter("@OPDNo", SqlDbType.Int)).Value = P_OpdNo;
        sc.Parameters.Add(new SqlParameter("@IPDNo", SqlDbType.Int)).Value = P_IpdNo;
        sc.Parameters.Add(new SqlParameter("@ReferBy", SqlDbType.NVarChar, 500)).Value = P_ReferBy;
        sc.Parameters.Add(new SqlParameter("@OrthoNo", SqlDbType.NVarChar, 500)).Value = P_OrthoNo;

        sc.Parameters.Add(new SqlParameter("@TreatmentAdvice", SqlDbType.NVarChar, 500)).Value = P_TreatmentAdvice;
        sc.Parameters.Add(new SqlParameter("@TreatmentAdvice1", SqlDbType.NVarChar, 3000)).Value = P_TreatmentAdvice1;
        sc.Parameters.Add(new SqlParameter("@IS_FunctionalRemoval", SqlDbType.Bit)).Value = P_IS_FunctionalRemoval;
        sc.Parameters.Add(new SqlParameter("@FunctionalRemoval", SqlDbType.NVarChar, 3550)).Value = P_FunctionalRemoval;
        sc.Parameters.Add(new SqlParameter("@Is_Functional_Fixed", SqlDbType.Bit)).Value = P_Is_Functional_Fixed;
        sc.Parameters.Add(new SqlParameter("@Functional_Fixed", SqlDbType.NVarChar, 3550)).Value = P_Functional_Fixed;

        sc.Parameters.Add(new SqlParameter("@IS_Orthopedic", SqlDbType.Bit)).Value = P_IS_Orthopedic;
        sc.Parameters.Add(new SqlParameter("@Orthopedic", SqlDbType.NVarChar, 3550)).Value = P_Orthopedic;
        sc.Parameters.Add(new SqlParameter("@IS_Expansion", SqlDbType.Bit)).Value = P_IS_Expansion;
        sc.Parameters.Add(new SqlParameter("@Expansion", SqlDbType.NVarChar, 3550)).Value = P_Expansion;

        sc.Parameters.Add(new SqlParameter("@Upper_Retention", SqlDbType.NVarChar, 3550)).Value = P_Upper_Retention;
        sc.Parameters.Add(new SqlParameter("@Lower_Retention", SqlDbType.NVarChar, 3550)).Value = P_Lower_Retention;
        sc.Parameters.Add(new SqlParameter("@Diagnosis", SqlDbType.NVarChar, 3550)).Value = P_Diagnosis;
        sc.Parameters.Add(new SqlParameter("@Appliance", SqlDbType.NVarChar, 3550)).Value = P_Appliance;
        sc.Parameters.Add(new SqlParameter("@Extractions", SqlDbType.NVarChar, 3550)).Value = P_Extractions;
        sc.Parameters.Add(new SqlParameter("@Envelope", SqlDbType.NVarChar, 3550)).Value = P_Envelope;
        sc.Parameters.Add(new SqlParameter("@Approximate", SqlDbType.NVarChar, 3550)).Value = P_Approximate;
        sc.Parameters.Add(new SqlParameter("@Branchid", SqlDbType.Int)).Value = P_Branchid;
        sc.Parameters.Add(new SqlParameter("@CreatedBy", SqlDbType.NVarChar, 250)).Value = P_CreatedBy;


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
    public void Insert_Orthodontic_Dental_Clinic_History()
    {

        SqlConnection conn = DataAccess.ConInitForDC();
        SqlCommand sc = new SqlCommand();
        sc.CommandType = CommandType.StoredProcedure;
        sc.Connection = conn;
        sc.CommandText = "SP_InsertOrthodontic_Dental_Clinic_History";
        sc.Parameters.Add(new SqlParameter("@Patregid", SqlDbType.Int)).Value = P_Patregid;
        sc.Parameters.Add(new SqlParameter("@OPDNo", SqlDbType.Int)).Value = P_OpdNo;
        sc.Parameters.Add(new SqlParameter("@IPDNo", SqlDbType.Int)).Value = P_IpdNo;
        sc.Parameters.Add(new SqlParameter("@ReferBy", SqlDbType.NVarChar, 500)).Value = P_ReferBy;
        sc.Parameters.Add(new SqlParameter("@OrthoNo", SqlDbType.NVarChar, 500)).Value = P_OrthoNo;
        sc.Parameters.Add(new SqlParameter("@ChiefComplants", SqlDbType.NVarChar, 500)).Value = P_ChiefComplants;    
        sc.Parameters.Add(new SqlParameter("@Medication", SqlDbType.NVarChar, 3000)).Value = P_Medication;
        sc.Parameters.Add(new SqlParameter("@Habits", SqlDbType.NVarChar, 4000)).Value = P_Habits;     
        sc.Parameters.Add(new SqlParameter("@OtherHistory", SqlDbType.NVarChar, 3550)).Value = P_OtherHistory;
        sc.Parameters.Add(new SqlParameter("@PastDentalHistory", SqlDbType.NVarChar, 3550)).Value = P_PastDentalHistory;
        sc.Parameters.Add(new SqlParameter("@FamilyHistory", SqlDbType.NVarChar, 3550)).Value = P_FamilyHistory;
        
        sc.Parameters.Add(new SqlParameter("@Hypertension", SqlDbType.Bit)).Value = P_Hypertension;
        sc.Parameters.Add(new SqlParameter("@Diabetes", SqlDbType.Bit)).Value = P_Diabetes;
        sc.Parameters.Add(new SqlParameter("@Anaemia", SqlDbType.Bit)).Value = P_Anaemia;
        sc.Parameters.Add(new SqlParameter("@KidneyDisease", SqlDbType.Bit)).Value = P_KidneyDisease;
        sc.Parameters.Add(new SqlParameter("@Asthama", SqlDbType.Bit)).Value = P_Asthama;
        sc.Parameters.Add(new SqlParameter("@Jaundice", SqlDbType.Bit)).Value = P_Jaundice;
        sc.Parameters.Add(new SqlParameter("@Allergy", SqlDbType.Bit)).Value = P_Allergy;
        sc.Parameters.Add(new SqlParameter("@BleedingDisorder", SqlDbType.Bit)).Value = P_BleedingDisorder;
        sc.Parameters.Add(new SqlParameter("@Pregnant", SqlDbType.Bit)).Value = P_Pregnant;
        sc.Parameters.Add(new SqlParameter("@Branchid", SqlDbType.Int)).Value = P_Branchid;
        sc.Parameters.Add(new SqlParameter("@CreatedBy", SqlDbType.NVarChar, 250)).Value = P_CreatedBy;


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


    public void Insert_Orthodontic_Dental_Investigation_Details()
    {

        SqlConnection conn = DataAccess.ConInitForDC();
        SqlCommand sc = new SqlCommand();
        sc.CommandType = CommandType.StoredProcedure;
        sc.Connection = conn;
        sc.CommandText = "SP_Insert_Orthodontic_Dental_InvestigationDetails";
        sc.Parameters.Add(new SqlParameter("@Patregid", SqlDbType.Int)).Value = P_Patregid;
        sc.Parameters.Add(new SqlParameter("@OPDNo", SqlDbType.Int)).Value = P_OpdNo;
        sc.Parameters.Add(new SqlParameter("@IPDNo", SqlDbType.Int)).Value = P_IpdNo;
        sc.Parameters.Add(new SqlParameter("@ReferBy", SqlDbType.NVarChar, 500)).Value = P_ReferBy;
        sc.Parameters.Add(new SqlParameter("@OrthoNo", SqlDbType.NVarChar, 500)).Value = P_OrthoNo;

        sc.Parameters.Add(new SqlParameter("@Pre_Lateral", SqlDbType.Bit)).Value = P_Pre_Lateral;
        sc.Parameters.Add(new SqlParameter("@Pre_Frontal", SqlDbType.Bit)).Value = P_Pre_Frontal;
        sc.Parameters.Add(new SqlParameter("@Pre_OPG", SqlDbType.Bit)).Value = P_Pre_OPG;
        sc.Parameters.Add(new SqlParameter("@Pre_IOPA", SqlDbType.Bit)).Value = P_Pre_IOPA;
        sc.Parameters.Add(new SqlParameter("@Pre_SLOB", SqlDbType.Bit)).Value = P_Pre_SLOB;
        sc.Parameters.Add(new SqlParameter("@Pre_OCCLUSAL", SqlDbType.Bit)).Value = P_Pre_OCCLUSAL;

        sc.Parameters.Add(new SqlParameter("@Mid_Lateral", SqlDbType.Bit)).Value = P_Mid_Lateral;
        sc.Parameters.Add(new SqlParameter("@Mid_Frontal", SqlDbType.Bit)).Value = P_Mid_Frontal;
        sc.Parameters.Add(new SqlParameter("@Mid_OPG", SqlDbType.Bit)).Value = P_Mid_OPG;
        sc.Parameters.Add(new SqlParameter("@Mid_IOPA", SqlDbType.Bit)).Value = P_Mid_IOPA;
        sc.Parameters.Add(new SqlParameter("@Mid_SLOB", SqlDbType.Bit)).Value = P_Mid_SLOB;
        sc.Parameters.Add(new SqlParameter("@Mid_OCCLUSAL", SqlDbType.Bit)).Value = P_Mid_OCCLUSAL;
        sc.Parameters.Add(new SqlParameter("@Post_Lateral", SqlDbType.Bit)).Value = P_Post_Lateral;
        sc.Parameters.Add(new SqlParameter("@Post_Frontal", SqlDbType.Bit)).Value = P_Post_Frontal;
        sc.Parameters.Add(new SqlParameter("@Post_OPG", SqlDbType.Bit)).Value = P_Post_OPG;
        sc.Parameters.Add(new SqlParameter("@Post_IOPA", SqlDbType.Bit)).Value = P_Post_IOPA;
        sc.Parameters.Add(new SqlParameter("@Post_SLOB", SqlDbType.Bit)).Value = P_Post_SLOB;
        sc.Parameters.Add(new SqlParameter("@Post_OCCLUSAL", SqlDbType.Bit)).Value = P_Post_OCCLUSAL;
        sc.Parameters.Add(new SqlParameter("@EXTRAORAL", SqlDbType.Bit)).Value = P_EXTRAORAL;
        sc.Parameters.Add(new SqlParameter("@INTRAORAL", SqlDbType.Bit)).Value = P_INTRAORAL;


        sc.Parameters.Add(new SqlParameter("@Pre_PHOTOGRAPHS", SqlDbType.NVarChar, 500)).Value = P_Pre_PHOTOGRAPHS;
        sc.Parameters.Add(new SqlParameter("@Mid_PHOTOGRAPHS", SqlDbType.NVarChar, 3000)).Value = P_Mid_PHOTOGRAPHS;
        sc.Parameters.Add(new SqlParameter("@Post_PHOTOGRAPHS", SqlDbType.NVarChar, 4000)).Value = P_Post_PHOTOGRAPHS;
        sc.Parameters.Add(new SqlParameter("@Pre_Other", SqlDbType.NVarChar, 3550)).Value = P_Pre_Other;
        sc.Parameters.Add(new SqlParameter("@Mid_Other", SqlDbType.NVarChar, 3550)).Value = P_Mid_Other;
        sc.Parameters.Add(new SqlParameter("@Post_Other", SqlDbType.NVarChar, 3550)).Value = P_Post_Other;
        sc.Parameters.Add(new SqlParameter("@Comments", SqlDbType.NVarChar, 500)).Value = P_Comments;
        sc.Parameters.Add(new SqlParameter("@Comments_Models", SqlDbType.NVarChar, 3000)).Value = P_Comments_Models;
        sc.Parameters.Add(new SqlParameter("@Comments_PHOTOGRAPHS", SqlDbType.NVarChar, 4000)).Value = P_Comments_PHOTOGRAPHS;
        sc.Parameters.Add(new SqlParameter("@Comments_Other", SqlDbType.NVarChar, 3550)).Value = P_Comments_Other;
        sc.Parameters.Add(new SqlParameter("@Pre_Model", SqlDbType.NVarChar, 3550)).Value = P_Pre_Model;
        sc.Parameters.Add(new SqlParameter("@Mid_Model", SqlDbType.NVarChar, 3550)).Value = P_Mid_Model;
        sc.Parameters.Add(new SqlParameter("@Post_Model", SqlDbType.NVarChar, 3550)).Value = P_Post_Model;

        sc.Parameters.Add(new SqlParameter("@Branchid", SqlDbType.Int)).Value = P_Branchid;
        sc.Parameters.Add(new SqlParameter("@CreatedBy", SqlDbType.NVarChar, 250)).Value = P_CreatedBy;


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

    public void Insert_DentalDiagnosis_Treatment()
    {

        SqlConnection conn = DataAccess.ConInitForDC();
        SqlCommand sc = new SqlCommand();
        sc.CommandType = CommandType.StoredProcedure;
        sc.Connection = conn;
        sc.CommandText = "SP_InsertDental_Diagnosis_Treatment";
        sc.Parameters.Add(new SqlParameter("@Patregid", SqlDbType.Int)).Value = P_Patregid;
        sc.Parameters.Add(new SqlParameter("@OPDNo", SqlDbType.Int)).Value = P_OpdNo;
        sc.Parameters.Add(new SqlParameter("@IPDNo", SqlDbType.Int)).Value = P_IpdNo;
        sc.Parameters.Add(new SqlParameter("@ReferBy", SqlDbType.NVarChar, 500)).Value = P_ReferBy;
      
        if (this.P_EntryDate == Date.getMinDate())
            sc.Parameters.Add(new SqlParameter("@EntryDate", SqlDbType.DateTime)).Value = DBNull.Value;
        else
            sc.Parameters.Add(new SqlParameter("@EntryDate", SqlDbType.DateTime)).Value = P_EntryDate;

        sc.Parameters.Add(new SqlParameter("@Diagnosis", SqlDbType.NVarChar, 2500)).Value = P_Diagnosis;

        sc.Parameters.Add(new SqlParameter("@TreatmentAdvised", SqlDbType.NVarChar, 2500)).Value = P_TreatmentAdvised;
      
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

    public void Insert_DentalTreatment_Details()
    {

        SqlConnection conn = DataAccess.ConInitForDC();
        SqlCommand sc = new SqlCommand();
        sc.CommandType = CommandType.StoredProcedure;
        sc.Connection = conn;
        sc.CommandText = "SP_InsertDental_Treatment_Details";
        sc.Parameters.Add(new SqlParameter("@Patregid", SqlDbType.Int)).Value = P_Patregid;
        sc.Parameters.Add(new SqlParameter("@OPDNo", SqlDbType.Int)).Value = P_OpdNo;
        sc.Parameters.Add(new SqlParameter("@IPDNo", SqlDbType.Int)).Value = P_IpdNo;
        sc.Parameters.Add(new SqlParameter("@ReferBy", SqlDbType.NVarChar, 500)).Value = P_ReferBy;

        if (this.P_EntryDate == Date.getMinDate())
            sc.Parameters.Add(new SqlParameter("@EntryDate", SqlDbType.DateTime)).Value = DBNull.Value;
        else
            sc.Parameters.Add(new SqlParameter("@EntryDate", SqlDbType.DateTime)).Value = P_EntryDate;

        if (this.P_TreatementDate == Date.getMinDate())
            sc.Parameters.Add(new SqlParameter("@TreatementDate", SqlDbType.DateTime)).Value = DBNull.Value;
        else
            sc.Parameters.Add(new SqlParameter("@TreatementDate", SqlDbType.DateTime)).Value = P_TreatementDate;

        sc.Parameters.Add(new SqlParameter("@TreatmentDone", SqlDbType.NVarChar, 2500)).Value = P_TreatmentDone;

        sc.Parameters.Add(new SqlParameter("@NextAppointment", SqlDbType.NVarChar, 2500)).Value = P_NextAppointment;
        sc.Parameters.Add(new SqlParameter("@Remarks", SqlDbType.NVarChar, 2500)).Value = P_Remarks;

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

    public void Insert_Dental_Ortho_Treatment_Details()
    {

        SqlConnection conn = DataAccess.ConInitForDC();
        SqlCommand sc = new SqlCommand();
        sc.CommandType = CommandType.StoredProcedure;
        sc.Connection = conn;
        sc.CommandText = "SP_InsertDental_Ortho_Treatment_Details";
        sc.Parameters.Add(new SqlParameter("@Patregid", SqlDbType.Int)).Value = P_Patregid;
        sc.Parameters.Add(new SqlParameter("@OPDNo", SqlDbType.Int)).Value = P_OpdNo;
        sc.Parameters.Add(new SqlParameter("@IPDNo", SqlDbType.Int)).Value = P_IpdNo;
        sc.Parameters.Add(new SqlParameter("@ReferBy", SqlDbType.NVarChar, 500)).Value = P_ReferBy;
        sc.Parameters.Add(new SqlParameter("@OrthoNo", SqlDbType.NVarChar, 500)).Value = P_OrthoNo;
       
        if (this.P_TreatementDate == Date.getMinDate())
            sc.Parameters.Add(new SqlParameter("@TreatementDate", SqlDbType.DateTime)).Value = DBNull.Value;
        else
            sc.Parameters.Add(new SqlParameter("@TreatementDate", SqlDbType.DateTime)).Value = P_TreatementDate;

        sc.Parameters.Add(new SqlParameter("@TreatmentProgress", SqlDbType.NVarChar, 2500)).Value = P_TreatmentDone;

        sc.Parameters.Add(new SqlParameter("@Payment", SqlDbType.NVarChar, 2500)).Value = P_NextAppointment;
        sc.Parameters.Add(new SqlParameter("@Remarks", SqlDbType.NVarChar, 2500)).Value = P_Remarks;

        sc.Parameters.Add(new SqlParameter("@TreatmentAmount", SqlDbType.Float)).Value = P_TreatmentAmount;
        sc.Parameters.Add(new SqlParameter("@BalanceAmount", SqlDbType.Float)).Value = P_BalanceAmount;

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
}