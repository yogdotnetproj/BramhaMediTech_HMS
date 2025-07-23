using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// Summary description for Dialysis_C
/// </summary>
public class Dialysis_C
{
    DataAccess da = new DataAccess();
	public Dialysis_C()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private int Patregid; public int P_Patregid { get { return Patregid; } set { Patregid = value; } }

    private int OpdNo; public int P_OpdNo { get { return OpdNo; } set { OpdNo = value; } }

    private int IpdNo; public int P_IpdNo { get { return IpdNo; } set { IpdNo = value; } }

    private DateTime EntryDate; public DateTime P_EntryDate { get { return EntryDate; } set { EntryDate = value; } }

    private string DialysisType; public string P_DialysisType { get { return DialysisType; } set { DialysisType = value; } }
    private string Technician; public string P_Technician { get { return Technician; } set { Technician = value; } }
    private bool PulmonaryOedema; public bool P_PulmonaryOedema { get { return PulmonaryOedema; } set { PulmonaryOedema = value; } }
    private bool Hypercalcemia; public bool P_Hypercalcemia { get { return Hypercalcemia; } set { Hypercalcemia = value; } }
    private bool FluidOverload; public bool P_FluidOverload { get { return FluidOverload; } set { FluidOverload = value; } }
    private bool Encephalopathy; public bool P_Encephalopathy { get { return Encephalopathy; } set { Encephalopathy = value; } }

    private string Access; public string P_Access { get { return Access; } set { Access = value; } }
    private string Dialyzer; public string P_Dialyzer { get { return Dialyzer; } set { Dialyzer = value; } }
    private string Reused; public string P_Reused { get { return Reused; } set { Reused = value; } }
    private string Duration; public string P_Duration { get { return Duration; } set { Duration = value; } }
    private string HeparinDosage; public string P_HeparinDosage { get { return HeparinDosage; } set { HeparinDosage = value; } }

    private string BloodFlow; public string P_BloodFlow { get { return BloodFlow; } set { BloodFlow = value; } }
    private string UFRemoval; public string P_UFRemoval { get { return UFRemoval; } set { UFRemoval = value; } }
    private string WeightPRE; public string P_WeightPRE { get { return WeightPRE; } set { WeightPRE = value; } }
    private string PostHD; public string P_PostHD { get { return PostHD; } set { PostHD = value; } }
    private string TimeStarted; public string P_TimeStarted { get { return TimeStarted; } set { TimeStarted = value; } }

    private string TimeEnded; public string P_TimeEnded { get { return TimeEnded; } set { TimeEnded = value; } }
    private string PrimingFluid; public string P_PrimingFluid { get { return PrimingFluid; } set { PrimingFluid = value; } }
    private string DialysateFlow; public string P_DialysateFlow { get { return DialysateFlow; } set { DialysateFlow = value; } }
    private bool Bleeding; public bool P_Bleeding { get { return Bleeding; } set { Bleeding = value; } }
    private bool Hypotension; public bool P_Hypotension { get { return Hypotension; } set { Hypotension = value; } }
    private bool Hypertension; public bool P_Hypertension { get { return Hypertension; } set { Hypertension = value; } }
    private bool Cramps; public bool P_Cramps { get { return Cramps; } set { Cramps = value; } }
    private bool Others; public bool P_Others { get { return Others; } set { Others = value; } }

    private bool Saline; public bool P_Saline { get { return Saline; } set { Saline = value; } }
    private bool FormalineH2O2; public bool P_FormalineH2O2 { get { return FormalineH2O2; } set { FormalineH2O2 = value; } }
    private bool Hyperchloride; public bool P_Hyperchloride { get { return Hyperchloride; } set { Hyperchloride = value; } }
    private string Diagnisis; public string P_Diagnisis { get { return Diagnisis; } set { Diagnisis = value; } }

    private string ComplicationDuringHD; public string P_ComplicationDuringHD { get { return ComplicationDuringHD; } set { ComplicationDuringHD = value; } }
    private string OtherNotes; public string P_OtherNotes { get { return OtherNotes; } set { OtherNotes = value; } }
    private string DoctorNotes; public string P_DoctorNotes { get { return DoctorNotes; } set { DoctorNotes = value; } }

    private string DialysisTime; public string P_DialysisTime { get { return DialysisTime; } set { DialysisTime = value; } }
    private string BP; public string P_BP { get { return BP; } set { BP = value; } }
    private string PR; public string P_PR { get { return PR; } set { PR = value; } }
    private string TMP; public string P_TMP { get { return TMP; } set { TMP = value; } }
    private string VP; public string P_VP { get { return VP; } set { VP = value; } }
    private string Temperature; public string P_Temperature { get { return Temperature; } set { Temperature = value; } }
    private string Medication; public string P_Medication { get { return Medication; } set { Medication = value; } }
    private string Remark; public string P_Remark { get { return Remark; } set { Remark = value; } }
    private string CreatedBy; public string P_CreatedBy { get { return CreatedBy; } set { CreatedBy = value; } }


    public void Insert_Dialysis_Chart()
    {

        SqlConnection conn = DataAccess.ConInitForDC();
        SqlCommand sc = new SqlCommand();
        sc.CommandType = CommandType.StoredProcedure;
        sc.Connection = conn;
        sc.CommandText = "USP_Insert_Dialysis";
        sc.Parameters.Add(new SqlParameter("@Patregid", SqlDbType.Int)).Value = P_Patregid;
        sc.Parameters.Add(new SqlParameter("@OPDNo", SqlDbType.Int)).Value = P_OpdNo;
        sc.Parameters.Add(new SqlParameter("@IPDNo", SqlDbType.Int)).Value = P_IpdNo;


        if (this.P_EntryDate == Date.getMinDate())
            sc.Parameters.Add(new SqlParameter("@EntryDate", SqlDbType.DateTime)).Value = DBNull.Value;
        else
            sc.Parameters.Add(new SqlParameter("@EntryDate", SqlDbType.DateTime)).Value = P_EntryDate;

        sc.Parameters.Add(new SqlParameter("@DialysisType", SqlDbType.NVarChar, 100)).Value = P_DialysisType;
        sc.Parameters.Add(new SqlParameter("@Technician", SqlDbType.NVarChar, 100)).Value = P_Technician;
        sc.Parameters.Add(new SqlParameter("@PulmonaryOedema", SqlDbType.Bit)).Value = P_PulmonaryOedema;
        sc.Parameters.Add(new SqlParameter("@Hypercalcemia", SqlDbType.Bit)).Value = P_Hypercalcemia;
        sc.Parameters.Add(new SqlParameter("@FluidOverload", SqlDbType.Bit)).Value = P_FluidOverload;
        sc.Parameters.Add(new SqlParameter("@Encephalopathy", SqlDbType.Bit)).Value = P_Encephalopathy;

        sc.Parameters.Add(new SqlParameter("@Access", SqlDbType.NVarChar, 100)).Value = P_Access;
        sc.Parameters.Add(new SqlParameter("@Dialyzer", SqlDbType.NVarChar, 100)).Value = P_Dialyzer;
        sc.Parameters.Add(new SqlParameter("@Reused", SqlDbType.NVarChar, 100)).Value = P_Reused;
        sc.Parameters.Add(new SqlParameter("@Duration", SqlDbType.NVarChar, 100)).Value = P_Duration;
        sc.Parameters.Add(new SqlParameter("@HeparinDosage", SqlDbType.NVarChar, 100)).Value = P_HeparinDosage;
        sc.Parameters.Add(new SqlParameter("@BloodFlow", SqlDbType.NVarChar, 100)).Value = P_BloodFlow;
        sc.Parameters.Add(new SqlParameter("@UFRemoval", SqlDbType.NVarChar, 100)).Value = P_UFRemoval;
        sc.Parameters.Add(new SqlParameter("@WeightPRE", SqlDbType.NVarChar, 100)).Value = P_WeightPRE;

        sc.Parameters.Add(new SqlParameter("@PostHD", SqlDbType.NVarChar, 100)).Value = P_PostHD;
        sc.Parameters.Add(new SqlParameter("@TimeStarted", SqlDbType.NVarChar, 100)).Value = P_TimeStarted;
        sc.Parameters.Add(new SqlParameter("@TimeEnded", SqlDbType.NVarChar, 100)).Value = P_TimeEnded;
        sc.Parameters.Add(new SqlParameter("@PrimingFluid", SqlDbType.NVarChar, 100)).Value = P_PrimingFluid;
        sc.Parameters.Add(new SqlParameter("@DialysateFlow", SqlDbType.NVarChar, 100)).Value = P_DialysateFlow;
        sc.Parameters.Add(new SqlParameter("@Bleeding", SqlDbType.Bit)).Value = P_Bleeding;
        sc.Parameters.Add(new SqlParameter("@Hypotension", SqlDbType.Bit)).Value = P_Hypotension;
        sc.Parameters.Add(new SqlParameter("@Hypertension", SqlDbType.Bit)).Value = P_Hypertension;
        sc.Parameters.Add(new SqlParameter("@Cramps", SqlDbType.Bit)).Value = P_Cramps;
        sc.Parameters.Add(new SqlParameter("@Others", SqlDbType.Bit)).Value = P_Others;
        sc.Parameters.Add(new SqlParameter("@Saline", SqlDbType.Bit)).Value = P_Saline;
        sc.Parameters.Add(new SqlParameter("@FormalineH2O2", SqlDbType.Bit)).Value = P_FormalineH2O2;
        sc.Parameters.Add(new SqlParameter("@Hyperchloride", SqlDbType.Bit)).Value = P_Hyperchloride;
        sc.Parameters.Add(new SqlParameter("@Diagnisis", SqlDbType.NVarChar, 300)).Value = P_Diagnisis;
        sc.Parameters.Add(new SqlParameter("@ComplicationDuringHD", SqlDbType.NVarChar, 300)).Value = P_ComplicationDuringHD;
        sc.Parameters.Add(new SqlParameter("@OtherNotes", SqlDbType.NVarChar, 300)).Value = P_OtherNotes;
        sc.Parameters.Add(new SqlParameter("@DoctorNotes", SqlDbType.NVarChar, 300)).Value = P_DoctorNotes;

        sc.Parameters.Add(new SqlParameter("@DialysisTime", SqlDbType.NVarChar, 100)).Value = P_DialysisTime;
        sc.Parameters.Add(new SqlParameter("@BP", SqlDbType.NVarChar, 100)).Value = P_BP;
        sc.Parameters.Add(new SqlParameter("@PR", SqlDbType.NVarChar, 100)).Value = P_PR;
        sc.Parameters.Add(new SqlParameter("@TMP", SqlDbType.NVarChar, 100)).Value = P_TMP;
        sc.Parameters.Add(new SqlParameter("@VP", SqlDbType.NVarChar, 100)).Value = P_VP;
        sc.Parameters.Add(new SqlParameter("@Temperature", SqlDbType.NVarChar, 100)).Value = P_Temperature;
        sc.Parameters.Add(new SqlParameter("@Medication", SqlDbType.NVarChar, 100)).Value = P_Medication;
        sc.Parameters.Add(new SqlParameter("@Remark", SqlDbType.NVarChar, 100)).Value = P_Remark;
      


        sc.Parameters.Add(new SqlParameter("@CreatedBy", SqlDbType.NVarChar, 250)).Value = P_CreatedBy;
        //  sc.Parameters.Add(new SqlParameter("@Branchid", SqlDbType.Int)).Value = P_Branchid;



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