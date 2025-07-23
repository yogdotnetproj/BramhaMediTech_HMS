using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// Summary description for AddMedicalRecord
/// </summary>
public class AddMedicalRecord_C
{
    DataAccess da = new DataAccess();
    public AddMedicalRecord_C()
	{
        //this.P_AdmissionDate = Date.getdate();
        //this.P_DischargeDate = Date.getdate();

        this.P_DischargeDate = Date.getMinDate();
        this.P_AdmissionDate = Date.getMinDate();
		//
		// TODO: Add constructor logic here
		//
	}

    private int Patregid;
    public int P_Patregid
    {

        get { return Patregid; }
        set { Patregid = value; }
    }

    private DateTime AdmissionDate;
    public DateTime P_AdmissionDate
    {

        get { return AdmissionDate; }
        set { AdmissionDate = value; }
    }

    private DateTime DischargeDate;
    public DateTime P_DischargeDate
    {

        get { return DischargeDate; }
        set { DischargeDate = value; }
    }

    private string PatientType;
    public string P_PatientType
    {

        get { return PatientType; }
        set { PatientType = value; }
    }

    private string DrName;
    public string P_DrName
    {

        get { return DrName; }
        set { DrName = value; }
    }

    private string RelativeName;
    public string P_RelativeName
    {

        get { return RelativeName; }
        set { RelativeName = value; }
    }


    private string RelativeName1;
    public string P_RelativeName1
    {

        get { return RelativeName1; }
        set { RelativeName1 = value; }
    }

    private string ContactNo;
    public string P_ContactNo
    {

        get { return ContactNo; }
        set { ContactNo = value; }
    }


    private string ContactNo1;
    public string P_ContactNo1
    {

        get { return ContactNo1; }
        set { ContactNo1 = value; }
    }

    private int Relation1;
    public int P_Relation1
    {

        get { return Relation1; }
        set { Relation1 = value; }
    }

    private int Relation;
    public int P_Relation
    {

        get { return Relation; }
        set { Relation = value; }
    }

    private string DocumentNumber;
    public string P_DocumentNumber
    {

        get { return DocumentNumber; }
        set { DocumentNumber = value; }
    }

    private string Diagnostics;
    public string P_Diagnostics
    {

        get { return Diagnostics; }
        set { Diagnostics = value; }
    }


    private string DocumentFileName;
    public string P_DocumentFileName
    {

        get { return DocumentFileName; }
        set { DocumentFileName = value; }
    }
    private string DocumentFilePath;
    public string P_DocumentFilePath
    {

        get { return DocumentFilePath; }
        set { DocumentFilePath = value; }
    }

    private string CreatedBy;
    public string P_CreatedBy
    {

        get { return CreatedBy; }
        set { CreatedBy = value; }
    }

    public DataTable GetMedicalRecod_PatientInfo(int Patregid)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlDataAdapter sda = new SqlDataAdapter("SELECT        PatientInformation.PatientInfoId, PatientInformation.PatRegId, PatientInformation.BarcodeId, PatientInformation.TitleId, PatientInformation.FirstName, PatientInformation.MiddleName, PatientInformation.LastName, "+
                         "   PatientInformation.PatMainTypeId, PatientInformation.PatientInsuTypeId, PatientInformation.PolicyNo, PatientInformation.GenderId, PatientInformation.BirthDate, PatientInformation.IsConfirmBirthDate, "+
                         "   PatientInformation.BloodGroup, PatientInformation.MaritalStatus, PatientInformation.GuardianTitleId, PatientInformation.GuardianName, PatientInformation.MobileNo, PatientInformation.PhoneNo, "+
                         "   PatientInformation.PatientAddress, PatientInformation.CountryId, PatientInformation.StateId, PatientInformation.CityId, PatientInformation.Email, PatientInformation.EntryDate, PatientInformation.ImagePath, "+
                         "   PatientInformation.CancelReason, PatientInformation.IsActive, PatientInformation.CreatedBy, PatientInformation.CreatedOn, PatientInformation.UpdatedBy, PatientInformation.UpdatedOn, PatientInformation.Age, "+
                         "   PatientInformation.AgeType, PatientInformation.BranchId, PatientInformation.FId, PatientInformation.Nationality, PatientInformation.BirthPlace, PatientInformation.RaceId, PatientInformation.ReligionId, "+
                         "   PatientInformation.HealthCardNo, PatientInformation.PassportNo, PatientInformation.VaccinationStatus, PatientInformation.Allergy, PatientInformation.ChiefComplant, Gender.GenderName "+
                         "   FROM            PatientInformation INNER JOIN "+
                         "   Gender ON PatientInformation.GenderId = Gender.GenderId where PatientInformation.PatRegId=" + Patregid + " ", con);
        DataTable ds = new DataTable();
        try
        {
            sda.Fill(ds);
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
    public void Insert_AddMEdicalRecord()
    {

        SqlConnection conn = DataAccess.ConInitForDC();
        SqlCommand sc = new SqlCommand();
        sc.CommandType = CommandType.StoredProcedure;
        sc.Connection = conn;
        sc.CommandText = "SP_InsertAddMEdicalRecod";
        sc.Parameters.Add(new SqlParameter("@Patregid", SqlDbType.Int)).Value = P_Patregid;
       
        sc.Parameters.Add(new SqlParameter("@PatientType", SqlDbType.NVarChar, 200)).Value = P_PatientType;
       // sc.Parameters.Add(new SqlParameter("@AdmissionDate", SqlDbType.DateTime)).Value = P_AdmissionDate;

        if (this.P_AdmissionDate == Date.getMinDate())
            sc.Parameters.Add(new SqlParameter("@AdmissionDate", SqlDbType.DateTime)).Value = DBNull.Value;
        else
            sc.Parameters.Add(new SqlParameter("@AdmissionDate", SqlDbType.DateTime)).Value = P_AdmissionDate;

        if (this.P_DischargeDate == Date.getMinDate())
            sc.Parameters.Add(new SqlParameter("@DischargeDate", SqlDbType.DateTime)).Value = DBNull.Value;
        else
        sc.Parameters.Add(new SqlParameter("@DischargeDate", SqlDbType.DateTime)).Value = P_DischargeDate;

        sc.Parameters.Add(new SqlParameter("@DrName", SqlDbType.NVarChar, 200)).Value = P_DrName;

        sc.Parameters.Add(new SqlParameter("@DocumentNumber", SqlDbType.NVarChar, 200)).Value = P_DocumentNumber;
        sc.Parameters.Add(new SqlParameter("@DocumentFileName", SqlDbType.NVarChar, 3000)).Value = P_DocumentFileName;
        sc.Parameters.Add(new SqlParameter("@DocumentFilePath", SqlDbType.NVarChar, 4000)).Value = P_DocumentFilePath;
        sc.Parameters.Add(new SqlParameter("@CreatedBy", SqlDbType.NVarChar, 250)).Value = P_CreatedBy;
        sc.Parameters.Add(new SqlParameter("@Diagnostics", SqlDbType.NVarChar, 3550)).Value = P_Diagnostics;

       

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

    public void Insert_AddUploadRecords()
    {

        SqlConnection conn = DataAccess.ConInitForDC();
        SqlCommand sc = new SqlCommand();
        sc.CommandType = CommandType.StoredProcedure;
        sc.Connection = conn;
        sc.CommandText = "SP_InsertAddResourcesRecord";
       // sc.Parameters.Add(new SqlParameter("@Patregid", SqlDbType.Int)).Value = P_Patregid;

        sc.Parameters.Add(new SqlParameter("@PatientType", SqlDbType.NVarChar, 200)).Value = P_PatientType;
        // sc.Parameters.Add(new SqlParameter("@AdmissionDate", SqlDbType.DateTime)).Value = P_AdmissionDate;

       
        sc.Parameters.Add(new SqlParameter("@DocumentNumber", SqlDbType.NVarChar, 200)).Value = P_DocumentNumber;
        sc.Parameters.Add(new SqlParameter("@DocumentFileName", SqlDbType.NVarChar, 3000)).Value = P_DocumentFileName;
        sc.Parameters.Add(new SqlParameter("@DocumentFilePath", SqlDbType.NVarChar, 4000)).Value = P_DocumentFilePath;
        sc.Parameters.Add(new SqlParameter("@CreatedBy", SqlDbType.NVarChar, 250)).Value = P_CreatedBy;
        sc.Parameters.Add(new SqlParameter("@Diagnostics", SqlDbType.NVarChar, 3550)).Value = P_Diagnostics;



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

    public DataTable GetResourceRecod_Info()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlDataAdapter sda = new SqlDataAdapter("SELECT      * from AddResources  order by MedicalId desc ", con);
        DataTable ds = new DataTable();
        try
        {
            sda.Fill(ds);
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
    public DataTable GetMedicalRecod_Info(int Patregid)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlDataAdapter sda = new SqlDataAdapter("SELECT      * from AddMedicalRecord  where PatRegId=" + Patregid + " ", con);
        DataTable ds = new DataTable();
        try
        {
            sda.Fill(ds);
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

    public DataTable GetMedical_CountNoOfFile(int Patregid)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlDataAdapter sda = new SqlDataAdapter("select count(MedicalId)+1 as RecordCount from AddMedicalRecord where PatientType='IPD'  and PatRegId=" + Patregid + " ", con);
        DataTable ds = new DataTable();
        try
        {
            sda.Fill(ds);
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

    public void Delete_AddMedicalRecord(string MedicalId)
    {
        SqlConnection conn = DataAccess.ConInitForDC();

        SqlCommand sc = new SqlCommand("delete from AddMedicalRecord where MedicalId='" + MedicalId + "' ", conn);

        try
        {
            conn.Open();
            sc.ExecuteNonQuery();
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
                throw;
            }

        }
    }

}