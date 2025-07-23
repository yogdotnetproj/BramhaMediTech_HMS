using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

/// <summary>
/// Summary description for DALPatientInformation
/// </summary>
public class DALPatientInformation
{
    BELPatientInformation objBELPatInfo = new BELPatientInformation();
	public DALPatientInformation()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataSet GetBankName()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("Sp_GetBankName", con);
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
    public BELPatientInformation SelectOneDr(int PatientInfoId, int OPDNO)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_PatientDocInfo", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@PatientInfoId", PatientInfoId);
            cmd.Parameters.AddWithValue("@OPDNO", OPDNO);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                objBELPatInfo.DrId = Convert.ToInt32(reader["DrId"]);
                objBELPatInfo.DeptId = Convert.ToInt32(reader["DeptId"]);
                objBELPatInfo.DeptName = Convert.ToString(reader["DeptName"]);
                objBELPatInfo.DocName = Convert.ToString(reader["DrName"]);


            }
            return objBELPatInfo;
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

    public BELPatientInformation SelectOne_MobileNo(string PatientInfoId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_PatientInfoSelectOne_MobileNo", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@PatientInfoId", PatientInfoId);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                objBELPatInfo.PatientInfoId = Convert.ToInt32(reader["PatientInfoId"]);
                objBELPatInfo.PatRegId = Convert.ToString(reader["PatRegId"]);
                objBELPatInfo.BarcodeId = Convert.ToString(reader["BarcodeId"]);
                objBELPatInfo.TitleId = Convert.ToInt32(reader["TitleId"]);
                objBELPatInfo.TitleName = Convert.ToString(reader["Title"]);
                objBELPatInfo.FirstName = Convert.ToString(reader["FirstName"]);
                objBELPatInfo.GenderName = Convert.ToString(reader["GenderName"]);
                objBELPatInfo.PatientName = Convert.ToString(reader["PatientName"]);

                objBELPatInfo.GenderId = Convert.ToInt32(reader["GenderId"]);

                if ((reader["BirthDate"]) != "")
                {
                    objBELPatInfo.BirthDate = Convert.ToDateTime(reader["BirthDate"]);
                }

                objBELPatInfo.IsConfirmBirthDate = Convert.ToBoolean(reader["IsConfirmBirthDate"]);

                objBELPatInfo.BloodGroup = Convert.ToString(reader["BloodGroup"]);
                objBELPatInfo.MaritalStatus = Convert.ToString(reader["MaritalStatus"]);
                objBELPatInfo.GuardianTitleId = Convert.ToInt32(reader["GuardianTitleId"]);
                objBELPatInfo.GuardianName = Convert.ToString(reader["GuardianName"]);
                objBELPatInfo.MobileNo = Convert.ToString(reader["MobileNo"]);
                objBELPatInfo.PhoneNo = Convert.ToString(reader["PhoneNo"]);
                objBELPatInfo.PatientAddress = Convert.ToString(reader["PatientAddress"]);
                objBELPatInfo.CountryId = Convert.ToInt32(reader["CountryId"]);
                objBELPatInfo.StateId = Convert.ToInt32(reader["StateId"]);
                objBELPatInfo.CityId = Convert.ToInt32(reader["CityId"]);
                // objBELPatInfo.LandMarkId = Convert.ToInt32(reader["LandMarkId"]);
                objBELPatInfo.Email = Convert.ToString(reader["Email"]);
                objBELPatInfo.EntryDate = Convert.ToDateTime(reader["EntryDate"]);

                objBELPatInfo.ImagePath = Convert.ToString(reader["ImagePath"]);
                //objBELPatInfo.IsActive = Convert.ToBoolean(reader["IsActive"]);
                //objBELPatInfo.CreatedBy = Convert.ToString(reader["CreatedBy"]);
                //objBELPatInfo.CreatedOn = Convert.ToDateTime(reader["CreatedDateTime"]);
                //objBELPatInfo.UpdatedBy = Convert.ToString(reader["UpdatedBy"]);
                //objBELPatInfo.UpdatedOn = Convert.ToDateTime(reader["UpdatedDateTime"]);
                objBELPatInfo.Age = Convert.ToString(reader["Age"]);

                objBELPatInfo.HealthCardNo = Convert.ToString(reader["HealthCardNo"]);
                objBELPatInfo.PassportNo = Convert.ToString(reader["PassportNo"]);
                objBELPatInfo.RaceId = Convert.ToInt32(reader["RaceId"]);
                objBELPatInfo.ReligionId = Convert.ToInt32(reader["ReligionId"]);

            }
            return objBELPatInfo;
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

  

    public BELPatientInformation SelectOne(int PatientInfoId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_PatientInfoSelectOne", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@PatientInfoId", PatientInfoId);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
            objBELPatInfo.PatientInfoId = Convert.ToInt32(reader["PatientInfoId"]);
            objBELPatInfo.PatRegId = Convert.ToString(reader["PatRegId"]);
            objBELPatInfo.BarcodeId = Convert.ToString(reader["BarcodeId"]);
            objBELPatInfo.TitleId = Convert.ToInt32(reader["TitleId"]);
            objBELPatInfo.TitleName = Convert.ToString(reader["Title"]);
            objBELPatInfo.FirstName = Convert.ToString(reader["FirstName"]);
            objBELPatInfo.GenderName = Convert.ToString(reader["GenderName"]);           
            objBELPatInfo.PatientName = Convert.ToString(reader["PatientName"]);
           
            objBELPatInfo.GenderId = Convert.ToInt32(reader["GenderId"]);
            
            if ((reader["BirthDate"]) != "")
            {
                objBELPatInfo.BirthDate = Convert.ToDateTime(reader["BirthDate"]);
            }
            
            objBELPatInfo.IsConfirmBirthDate = Convert.ToBoolean(reader["IsConfirmBirthDate"]);
            
            objBELPatInfo.BloodGroup = Convert.ToString(reader["BloodGroup"]);
            objBELPatInfo.MaritalStatus = Convert.ToString(reader["MaritalStatus"]);
            objBELPatInfo.GuardianTitleId = Convert.ToInt32(reader["GuardianTitleId"]);
            objBELPatInfo.GuardianName = Convert.ToString(reader["GuardianName"]);
            objBELPatInfo.MobileNo = Convert.ToString(reader["MobileNo"]);
            objBELPatInfo.PhoneNo = Convert.ToString(reader["PhoneNo"]);
            objBELPatInfo.PatientAddress = Convert.ToString(reader["PatientAddress"]);
            objBELPatInfo.CountryId = Convert.ToInt32(reader["CountryId"]);
            objBELPatInfo.StateId = Convert.ToInt32(reader["StateId"]);
            objBELPatInfo.CityId = Convert.ToInt32(reader["CityId"]);
           // objBELPatInfo.LandMarkId = Convert.ToInt32(reader["LandMarkId"]);
            objBELPatInfo.Email = Convert.ToString(reader["Email"]);
            objBELPatInfo.EntryDate = Convert.ToDateTime(reader["EntryDate"]);

            objBELPatInfo.ImagePath = Convert.ToString(reader["ImagePath"]);
            objBELPatInfo.Nationality = Convert.ToString(reader["Nationality"]);
            objBELPatInfo.BirthPlace = Convert.ToString(reader["BirthPlace"]);
            //objBELPatInfo.CreatedOn = Convert.ToDateTime(reader["CreatedDateTime"]);
            //objBELPatInfo.UpdatedBy = Convert.ToString(reader["UpdatedBy"]);
            //objBELPatInfo.UpdatedOn = Convert.ToDateTime(reader["UpdatedDateTime"]);
            objBELPatInfo.Age = Convert.ToString(reader["Age"]);
            objBELPatInfo.VaccinationStatus = Convert.ToString(reader["VaccinationStatus"]);

            objBELPatInfo.Allergy = Convert.ToString(reader["Allergy"]);
            objBELPatInfo.ChiefComplant = Convert.ToString(reader["ChiefComplant"]);

            objBELPatInfo.P_Relation = Convert.ToInt32(reader["Relation"]);
            objBELPatInfo.P_RelativeName = Convert.ToString(reader["RelativeName"]);
            objBELPatInfo.P_ContactNo = Convert.ToString(reader["ContactNo"]);
            objBELPatInfo.P_Address1 = Convert.ToString(reader["RelaAddress"]);


            objBELPatInfo.P_Relation1 = Convert.ToInt32(reader["Relation1"]);
            objBELPatInfo.P_RelativeName1 = Convert.ToString(reader["RelativeName1"]);
            objBELPatInfo.P_ContactNo1 = Convert.ToString(reader["ContactNo1"]);
            objBELPatInfo.P_Address2 = Convert.ToString(reader["RelaAddress1"]);

            objBELPatInfo.RaceId = Convert.ToInt32(reader["RaceId"]);
            objBELPatInfo.ReligionId = Convert.ToInt32(reader["ReligionId"]);
            objBELPatInfo.PassportNo = Convert.ToString(reader["PassportNo"]);

            }
            return objBELPatInfo;
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

    public DataSet FillGrid(BELPatientInformation objBELPatInfo, string FromDate, string ToDate,string Birthdate)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_PatientInfoFillGrid", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PatRegId", objBELPatInfo.PatRegId);
        //cmd.Parameters.AddWithValue("@BarcodeId", objBELPatInfo.BarcodeId);
        cmd.Parameters.AddWithValue("@PatientName",objBELPatInfo.PatientName);
        //cmd.Parameters.AddWithValue("@PatMainTypeId", objBELPatInfo.PatMainTypeId);
        //cmd.Parameters.AddWithValue("@PatientInsuTypeId", objBELPatInfo.PatientInsuTypeId);
        cmd.Parameters.AddWithValue("@MobileNo", objBELPatInfo.MobileNo);
        cmd.Parameters.AddWithValue("@BirthDate", Birthdate);
        cmd.Parameters.AddWithValue("@FromDate",FromDate);
        cmd.Parameters.AddWithValue("@ToDate", ToDate);
       
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
    public DataSet FillGridDeposit(BELPatientInformation objBELPatInfo, string FromDate, string ToDate, string Birthdate)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_PatientInfoFillGridDeposit", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PatRegId", objBELPatInfo.PatRegId);
       
        cmd.Parameters.AddWithValue("@PatientName", objBELPatInfo.PatientName);
       
        cmd.Parameters.AddWithValue("@MobileNo", objBELPatInfo.MobileNo);
        cmd.Parameters.AddWithValue("@BirthDate", Birthdate);
        cmd.Parameters.AddWithValue("@FromDate", FromDate);
        cmd.Parameters.AddWithValue("@ToDate", ToDate);

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
    public string CheckExist(BELPatientInformation obj1)
    {
        string Result;
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_CheckExistPatient", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {
            cmd.Parameters.AddWithValue("@FirstName", obj1.FirstName);
            cmd.Parameters.AddWithValue("@BirthDate", obj1.BirthDate);
            cmd.Parameters.AddWithValue("@MobileNo", obj1.MobileNo);
            Result =Convert.ToString( cmd.ExecuteScalar());
            return Result;
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
    public object[] InsertPatientInfo(BELPatientInformation obj1)
    {
        object[] Result = new object[10];
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_PatientInfoInsert", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {
            cmd.Parameters.AddWithValue("@PatRegId", obj1.PatRegId);
            cmd.Parameters.AddWithValue("@BarcodeId", obj1.BarcodeId);
            cmd.Parameters.AddWithValue("@TitleId", obj1.TitleId);
            cmd.Parameters.AddWithValue("@FirstName", obj1.FirstName);
            cmd.Parameters.AddWithValue("@MiddleName", obj1.MiddleName);
            cmd.Parameters.AddWithValue("@LastName", obj1.LastName);
            cmd.Parameters.AddWithValue("@PatMainTypeId", obj1.PatMainTypeId);
            cmd.Parameters.AddWithValue("@PatientInsuTypeId", obj1.PatientInsuTypeId);
            cmd.Parameters.AddWithValue("@PolicyNo", obj1.PolicyNo);
            cmd.Parameters.AddWithValue("@GenderId", obj1.GenderId);
            cmd.Parameters.AddWithValue("@BirthDate", obj1.BirthDate);
            cmd.Parameters.AddWithValue("@Age", obj1.Age);
            cmd.Parameters.AddWithValue("@AgeType", obj1.AgeType);
            cmd.Parameters.AddWithValue("@IsConfirmBirthDate", obj1.IsConfirmBirthDate);
            cmd.Parameters.AddWithValue("@BloodGroup", obj1.BloodGroup);
            cmd.Parameters.AddWithValue("@MaritalStatus", obj1.MaritalStatus);
            cmd.Parameters.AddWithValue("@GuardianTitleId", obj1.GuardianTitleId);
            cmd.Parameters.AddWithValue("@GuardianName", obj1.GuardianName);
            cmd.Parameters.AddWithValue("@MobileNo", obj1.MobileNo);
            cmd.Parameters.AddWithValue("@PhoneNo", obj1.PhoneNo);
            cmd.Parameters.AddWithValue("@PatientAddress", obj1.PatientAddress);
            cmd.Parameters.AddWithValue("@CountryId", obj1.CountryId);
            cmd.Parameters.AddWithValue("@StateId", obj1.StateId);
            cmd.Parameters.AddWithValue("@CityId", obj1.CityId);           
            cmd.Parameters.AddWithValue("@Email", obj1.Email);
            cmd.Parameters.AddWithValue("@FId", obj1.FId);
            cmd.Parameters.AddWithValue("@BranchId", obj1.BranchId);
            cmd.Parameters.AddWithValue("@Nationality", obj1.Nationality);
            cmd.Parameters.AddWithValue("@BirthPlace", obj1.BirthPlace);

            // objDatabase.AddInParameter(objDBCommand, "@EntryDate", DbType.String, obj1.EntryDate);
            cmd.Parameters.AddWithValue("@ImagePath", Convert.ToString(obj1.ImagePath));
            cmd.Parameters.AddWithValue("@CreatedBy", obj1.CreatedBy);

            cmd.Parameters.AddWithValue("@RaceId", obj1.RaceId);
            cmd.Parameters.AddWithValue("@ReligionId", obj1.ReligionId);
            cmd.Parameters.AddWithValue("@HealthCardNo", obj1.HealthCardNo);
            cmd.Parameters.AddWithValue("@PassportNo", obj1.PassportNo);
            cmd.Parameters.AddWithValue("@VaccinationStatus", obj1.VaccinationStatus);

            cmd.Parameters.AddWithValue("@Allergy", obj1.Allergy);
            cmd.Parameters.AddWithValue("@ChiefComplant", obj1.ChiefComplant);

            cmd.Parameters.AddWithValue("@Relation", obj1.P_Relation);
            cmd.Parameters.AddWithValue("@RelativeName", obj1.P_RelativeName);
            cmd.Parameters.AddWithValue("@ContactNo", obj1.P_ContactNo);
            cmd.Parameters.AddWithValue("@RelaAddress", obj1.P_Address1);

            cmd.Parameters.AddWithValue("@Relation1", obj1.P_Relation1);
            cmd.Parameters.AddWithValue("@RelativeName1", obj1.P_RelativeName1);
            cmd.Parameters.AddWithValue("@ContactNo1", obj1.P_ContactNo1);
            cmd.Parameters.AddWithValue("@RelaAddress1", obj1.P_Address2);

            cmd.Parameters.AddWithValue("@PatUserName", obj1.P_PUserName);
            cmd.Parameters.AddWithValue("@PatPassword", obj1.P_PPassword);
            cmd.Parameters.AddWithValue("@UserType", obj1.Usertype);

            cmd.Parameters.Add("@PatientInfoId",SqlDbType.Int);            
            cmd.Parameters["@PatientInfoId"].Direction = ParameterDirection.Output;
            Result[0] = cmd.ExecuteScalar();
            Result[1] = Convert.ToInt32(cmd.Parameters["@PatientInfoId"].Value);
            return Result;
            
            
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


    public object[] InsertPatientInfo_Online(BELPatientInformation obj1)
    {
        object[] Result = new object[10];
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_PatientInfoInsert", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {
            cmd.Parameters.AddWithValue("@PatRegId", obj1.PatRegId);
            cmd.Parameters.AddWithValue("@BarcodeId", obj1.BarcodeId);
            cmd.Parameters.AddWithValue("@TitleId", obj1.TitleId);
            cmd.Parameters.AddWithValue("@FirstName", obj1.FirstName);
            cmd.Parameters.AddWithValue("@MiddleName", obj1.MiddleName);
            cmd.Parameters.AddWithValue("@LastName", obj1.LastName);
            cmd.Parameters.AddWithValue("@PatMainTypeId", obj1.PatMainTypeId);
            cmd.Parameters.AddWithValue("@PatientInsuTypeId", obj1.PatientInsuTypeId);
            cmd.Parameters.AddWithValue("@PolicyNo", obj1.PolicyNo);
            cmd.Parameters.AddWithValue("@GenderId", obj1.GenderId);
            cmd.Parameters.AddWithValue("@BirthDate", obj1.BirthDate);
            cmd.Parameters.AddWithValue("@Age", obj1.Age);
            cmd.Parameters.AddWithValue("@AgeType", obj1.AgeType);
            cmd.Parameters.AddWithValue("@IsConfirmBirthDate", obj1.IsConfirmBirthDate);
            cmd.Parameters.AddWithValue("@BloodGroup", obj1.BloodGroup);
            cmd.Parameters.AddWithValue("@MaritalStatus", obj1.MaritalStatus);
            cmd.Parameters.AddWithValue("@GuardianTitleId", obj1.GuardianTitleId);
            cmd.Parameters.AddWithValue("@GuardianName", obj1.GuardianName);
            cmd.Parameters.AddWithValue("@MobileNo", obj1.MobileNo);
            cmd.Parameters.AddWithValue("@PhoneNo", obj1.PhoneNo);
            cmd.Parameters.AddWithValue("@PatientAddress", obj1.PatientAddress);
            cmd.Parameters.AddWithValue("@CountryId", obj1.CountryId);
            cmd.Parameters.AddWithValue("@StateId", obj1.StateId);
            cmd.Parameters.AddWithValue("@CityId", obj1.CityId);
            cmd.Parameters.AddWithValue("@Email", obj1.Email);
            cmd.Parameters.AddWithValue("@FId", obj1.FId);
            cmd.Parameters.AddWithValue("@BranchId", obj1.BranchId);
            cmd.Parameters.AddWithValue("@Nationality", obj1.Nationality);
            cmd.Parameters.AddWithValue("@BirthPlace", obj1.BirthPlace);

            // objDatabase.AddInParameter(objDBCommand, "@EntryDate", DbType.String, obj1.EntryDate);
            cmd.Parameters.AddWithValue("@ImagePath", Convert.ToString(obj1.ImagePath));
            cmd.Parameters.AddWithValue("@CreatedBy", obj1.CreatedBy);

            cmd.Parameters.AddWithValue("@RaceId", obj1.RaceId);
            cmd.Parameters.AddWithValue("@ReligionId", obj1.ReligionId);
            cmd.Parameters.AddWithValue("@HealthCardNo", obj1.HealthCardNo);
            cmd.Parameters.AddWithValue("@PassportNo", obj1.PassportNo);
            cmd.Parameters.AddWithValue("@VaccinationStatus", obj1.VaccinationStatus);

            cmd.Parameters.AddWithValue("@Allergy", obj1.Allergy);
            cmd.Parameters.AddWithValue("@ChiefComplant", obj1.ChiefComplant);

            cmd.Parameters.AddWithValue("@Relation", obj1.P_Relation);
            cmd.Parameters.AddWithValue("@RelativeName", obj1.P_RelativeName);
            cmd.Parameters.AddWithValue("@ContactNo", obj1.P_ContactNo);
            cmd.Parameters.AddWithValue("@RelaAddress", obj1.P_Address1);

            cmd.Parameters.AddWithValue("@Relation1", obj1.P_Relation1);
            cmd.Parameters.AddWithValue("@RelativeName1", obj1.P_RelativeName1);
            cmd.Parameters.AddWithValue("@ContactNo1", obj1.P_ContactNo1);
            cmd.Parameters.AddWithValue("@RelaAddress1", obj1.P_Address2);

            cmd.Parameters.AddWithValue("@PatUserName", obj1.P_PUserName);
            cmd.Parameters.AddWithValue("@PatPassword", obj1.P_PPassword);
            cmd.Parameters.AddWithValue("@UserType", obj1.Usertype);

            cmd.Parameters.Add("@PatientInfoId", SqlDbType.Int);
            cmd.Parameters["@PatientInfoId"].Direction = ParameterDirection.Output;
            Result[0] = cmd.ExecuteScalar();
            Result[1] = Convert.ToInt32(cmd.Parameters["@PatientInfoId"].Value);
            return Result;


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

    public string UpdatePatientInfo(BELPatientInformation obj1)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_PatientInfo_Update", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@PatientInfoId",obj1.PatientInfoId);
           // cmd.Parameters.AddWithValue("@PatRegId", obj1.PatRegId);
            //cmd.Parameters.AddWithValue("@BarcodeId",obj1.BarcodeId);
            cmd.Parameters.AddWithValue("@TitleId",obj1.TitleId);
            cmd.Parameters.AddWithValue("@FirstName",obj1.FirstName);
            cmd.Parameters.AddWithValue("@MiddleName",obj1.MiddleName);
            cmd.Parameters.AddWithValue("@LastName",obj1.LastName);
            cmd.Parameters.AddWithValue("@PatMainTypeId", obj1.PatMainTypeId);
            cmd.Parameters.AddWithValue("@PatientInsuTypeId", obj1.PatientInsuTypeId);
            cmd.Parameters.AddWithValue("@PolicyNo",obj1.PolicyNo);
            cmd.Parameters.AddWithValue("@GenderId",obj1.GenderId);
            cmd.Parameters.AddWithValue("@BirthDate",obj1.BirthDate);
            cmd.Parameters.AddWithValue("@Age",obj1.Age);
            cmd.Parameters.AddWithValue("@IsConfirmBirthDate",obj1.IsConfirmBirthDate);
            cmd.Parameters.AddWithValue("@BloodGroup",obj1.BloodGroup);
            cmd.Parameters.AddWithValue("@MaritalStatus",obj1.MaritalStatus);
            cmd.Parameters.AddWithValue("@GuardianTitleId",obj1.GuardianTitleId);
            cmd.Parameters.AddWithValue("@GuardianName",obj1.GuardianName);
            cmd.Parameters.AddWithValue("@MobileNo",obj1.MobileNo);
            cmd.Parameters.AddWithValue("@PhoneNo",obj1.PhoneNo);
            cmd.Parameters.AddWithValue("@PatientAddress",obj1.PatientAddress);
            cmd.Parameters.AddWithValue("@CountryId",obj1.CountryId);
            cmd.Parameters.AddWithValue("@StateId",obj1.StateId);
            cmd.Parameters.AddWithValue("@CityId", obj1.CityId);            
            cmd.Parameters.AddWithValue("@Email",obj1.Email);
            //cmd.Parameters.AddWithValue("@EntryDate",obj1.EntryDate);
            cmd.Parameters.AddWithValue("@ImagePath",obj1.ImagePath);
            cmd.Parameters.AddWithValue("@CancelReason", "");
            cmd.Parameters.AddWithValue("@UpdatedBy", obj1.UpdatedBy);
            cmd.Parameters.AddWithValue("@AgeType", obj1.AgeType);
            cmd.Parameters.AddWithValue("@Nationality", obj1.Nationality);
            cmd.Parameters.AddWithValue("@BirthPlace", obj1.BirthPlace);

            cmd.Parameters.AddWithValue("@RaceId", obj1.RaceId);
            cmd.Parameters.AddWithValue("@ReligionId", obj1.ReligionId);
            cmd.Parameters.AddWithValue("@HealthCardNo", obj1.HealthCardNo);
            cmd.Parameters.AddWithValue("@PassportNo", obj1.PassportNo);
            cmd.Parameters.AddWithValue("@VaccinationStatus", obj1.VaccinationStatus);

            cmd.Parameters.AddWithValue("@Allergy", obj1.Allergy);
            cmd.Parameters.AddWithValue("@ChiefComplant", obj1.ChiefComplant);


            cmd.Parameters.AddWithValue("@Relation", obj1.P_Relation);
            cmd.Parameters.AddWithValue("@RelativeName", obj1.P_RelativeName);
            cmd.Parameters.AddWithValue("@ContactNo", obj1.P_ContactNo);
            cmd.Parameters.AddWithValue("@RelaAddress", obj1.P_Address1);

            cmd.Parameters.AddWithValue("@Relation1", obj1.P_Relation1);
            cmd.Parameters.AddWithValue("@RelativeName1", obj1.P_RelativeName1);
            cmd.Parameters.AddWithValue("@ContactNo1", obj1.P_ContactNo1);
            cmd.Parameters.AddWithValue("@RelaAddress1", obj1.P_Address2);
            

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

    public string EditPatientInfoRemark(BELPatientInformation obj1)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_InsertEditPatientInfoRemark", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@PatregId", obj1.PatientInfoId);




            cmd.Parameters.AddWithValue("@EditBy", obj1.UpdatedBy);
            cmd.Parameters.AddWithValue("@EditRemark", obj1.EditRemark);


           

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

    public string UpdateDrInfo(BELPatientInformation obj1)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_PatientDr_Update", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@Patregid", obj1.PatRegId);

            cmd.Parameters.AddWithValue("@DrId", obj1.DrId);
            cmd.Parameters.AddWithValue("@OPDNo", obj1.OPDNo);
            cmd.Parameters.AddWithValue("@DeptId", obj1.DeptId);
            cmd.Parameters.AddWithValue("@ProcedureID", obj1.ProcedureID);
            cmd.Parameters.AddWithValue("@UpdatedBy", obj1.UpdatedBy);


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

    public string DeletePatientInfo(int PatientInfoId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_PatientInfoDelete", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@PatientInfoId", PatientInfoId);
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
    

    public BELPatientInformation ReportSelectAll()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_ReportPatientDetails", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                objBELPatInfo.PatientInfoId = Convert.ToInt32(reader["PatientInfoId"]);
                objBELPatInfo.FirstName = Convert.ToString(reader["FirstName"]);
                objBELPatInfo.MiddleName = Convert.ToString(reader["MiddleName"]);
                objBELPatInfo.LastName = Convert.ToString(reader["LastName"]);
                objBELPatInfo.GenderId = Convert.ToInt32(reader["GenderId"]);
                objBELPatInfo.MobileNo = Convert.ToString(reader["MobileNo"]);
                objBELPatInfo.PatientAddress = Convert.ToString(reader["PatientAddress"]);
                objBELPatInfo.ImagePath = Convert.ToString(reader["ImagePath"]);
                objBELPatInfo.IsActive = Convert.ToBoolean(reader["IsActive"]);
                objBELPatInfo.CreatedBy = Convert.ToString(reader["CreatedBy"]);
                objBELPatInfo.CreatedOn = Convert.ToDateTime(reader["CreatedOn"]);
                objBELPatInfo.UpdatedBy = Convert.ToString(reader["UpdatedBy"]);
                objBELPatInfo.UpdatedOn = Convert.ToDateTime(reader["UpdatedOn"]);                

            }
            return objBELPatInfo;
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


    public DataSet FillSearchGrid(string PatientName)
    {      
       
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_IPDPatientNameSearch", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PatientName", objBELPatInfo.PatientName);        
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

    public DataSet FillGrid()
    {        
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_IPDPatientName_FillGrid", con);
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

    
    public string PatientDischarge(int PatientRegistrationId)
    {      

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_BedAllot_Discharge", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@PatientRegistrationId", PatientRegistrationId);
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

    public string PatientCancel(int PatientRegistrationId)
    {       
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_BedAllot_Cancel", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@PatientRegistrationId", PatientRegistrationId);
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

    
    public string PatientDischarge2(int PatientRegistrationId)
    {
       
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_BedAllot_Discharge2", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@PatientRegistrationId", PatientRegistrationId);
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

    public string PatientCancel2(int PatientRegistrationId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_BedAllot_Cancel2", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@PatientRegistrationId", PatientRegistrationId);
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

    public string getRegistrationNo(int PatientRegistrationId)
    {
        
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_PatientRegistration_getRegistrationNo", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@PatientRegistrationId", PatientRegistrationId);
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



    public BELPatientInformation getPatientInfoId(int PatientRegistrationId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_PatientInfo_getInfoId", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PatientRegistrationId", PatientRegistrationId);
        SqlDataReader sdr = cmd.ExecuteReader();

        if (sdr.Read())
        {
            objBELPatInfo.PatientInfoId = Convert.ToInt32(sdr["PatientInfoId"]);

        }
        con.Close();
        con.Dispose();
        return objBELPatInfo;
    }

    public BELPatientInformation GedDescId(int PatientInfoId)
    {
        
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_PatientRegistration_GedDescId", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PatientInfoId", PatientInfoId);
        SqlDataReader sdr = cmd.ExecuteReader();

        if (sdr.Read())
        {

            objBELPatInfo.PatientRegistrationId = Convert.ToInt32(sdr["PatientRegistrationId"]);

        }
        con.Close();
        con.Dispose();
        return objBELPatInfo;
    }

    public int GetPrnBarcodeNo()
    {
       // object[] Result = new object[10];
        try
        {
            int MaxPrnBarcode;
            SqlConnection con = DataAccess.ConInitForDC();
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_PatientInfo_GetMaxID", con);
            cmd.CommandType = CommandType.StoredProcedure;
             
             try
             {
                 object obj = cmd.ExecuteScalar();
                // MaxPrnBarcode = Convert.ToInt32(obj) + 1;
                 
                 //object obj = sc.ExecuteScalar();
                 if (obj == DBNull.Value)
                     MaxPrnBarcode = 1;
                 else
                     MaxPrnBarcode = Convert.ToInt32(obj);

                 return MaxPrnBarcode;
             }
             catch (SqlException)
             {
                 throw;
             }
             finally
             {
                 con.Close(); con.Dispose();
             }
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {

        }
    }

    //public List<DOPatientRegistration> GetAdmittedPatientList()
    //{
    //    List<DOPatientRegistration> objDOPatientRegistrations = new List<DOPatientRegistration>();
    //    DbCommand objDbCommand = objDatabase.GetStoredProcCommand("SP_IPD_AdmittedPatientList");
    //    IDataReader reader = objDatabase.ExecuteReader(objDbCommand);
    //    while (reader.Read())
    //    {
    //        DOPatientRegistration objDOPatientRegistration = new DOPatientRegistration();
    //        objDOPatientRegistration.PatientName = Convert.ToString(reader["PatientName"]);
    //        objDOPatientRegistration.RegistrationNo = Convert.ToString(reader["RegistrationNo"]);
    //        objDOPatientRegistration.RegistrationDateTime = Convert.ToString(reader["RegistrationDateTime"]);
    //        objDOPatientRegistration.RoomAddress = Convert.ToString(reader["RoomAddress"]);
    //        objDOPatientRegistration.RoomName = Convert.ToString(reader["RoomName"]);
    //        objDOPatientRegistration.BedName = Convert.ToString(reader["BedName"]);
    //        objDOPatientRegistration.PatientAddress = Convert.ToString(reader["PatientAddress"]);
    //        objDOPatientRegistrations.Add(objDOPatientRegistration);
    //    }
    //    reader.Close();
    //    reader.Dispose();
    //    return objDOPatientRegistrations;
    //}

    //public object GetDischargedPatientList()
    //{
    //    List<DOPatientRegistration> objDOPatientRegistrations = new List<DOPatientRegistration>();
    //    DbCommand objDbCommand = objDatabase.GetStoredProcCommand("SP_IPD_DischaredPatientList");
    //    IDataReader reader = objDatabase.ExecuteReader(objDbCommand);
    //    while (reader.Read())
    //    {
    //        DOPatientRegistration objDOPatientRegistration = new DOPatientRegistration();
    //        objDOPatientRegistration.PatientRegistrationId = Convert.ToInt32(reader["PatientRegistrationId"]);
    //        objDOPatientRegistration.PatientName = Convert.ToString(reader["PatientName"]);
    //        objDOPatientRegistration.RegistrationNo = Convert.ToString(reader["RegistrationNo"]);
    //        objDOPatientRegistration.RegistrationDateTime = Convert.ToString(reader["RegistrationDateTime"]);
    //        objDOPatientRegistration.DischargeDateTime = Convert.ToString(reader["DischargeDateTime"]); //Discharge
    //        objDOPatientRegistrations.Add(objDOPatientRegistration);
    //    }
    //    reader.Close();
    //    reader.Dispose();
    //    return objDOPatientRegistrations;
    //}

    public BELPatientInformation GetGenderId(int TitleId)
    {
       
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_Title_GetGenderId", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@TitleId", TitleId);
        SqlDataReader sdr = cmd.ExecuteReader();
        if (sdr.Read())
        {
            objBELPatInfo.GenderId = Convert.ToInt32(sdr["GenderId"]);

        }
        sdr.Close();
        sdr.Dispose();
        con.Close();
        con.Dispose();
        return objBELPatInfo;
    }

    public DataTable GetPatientInfoForBill(string BillId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_Rpt_PatientInfo", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@BillId", BillId);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        DataTable dt = ds.Tables[0].Copy();
        dt.TableName = "PatientInfo";
        con.Close();
        con.Dispose();
        return dt;
    }

    //public DataTable GetPatientInfoForPrescription(string PatientRegistrationId)
    //{
    //    DbCommand objDbCommand = objDatabase.GetStoredProcCommand("SP_Rpt_PrescriptionGetPatientInfo");
    //    objDatabase.AddInParameter(objDbCommand, "@PatientRegistrationId", DbType.String, PatientRegistrationId);
    //    DataSet ds = objDatabase.ExecuteDataSet(objDbCommand);
    //    DataTable dt = ds.Tables[0].Copy();
    //    dt.TableName = "PatientInfo";
    //    return dt;
    //}    
    //public object FillGridPatient()
    //{

    //    List<DOPatientInfo> objListDOPatientInfo = new List<DOPatientInfo>();
    //    IDataReader reader;
    //    DbCommand objDBCommand = objDatabase.GetStoredProcCommand("SP_WorkOrderMaster_FillGridPatient");
    //    reader = objDatabase.ExecuteReader(objDBCommand);
    //    while (reader.Read())
    //    {
    //        DOPatientInfo objDOPatientInfo = new DOPatientInfo();
    //        objDOPatientInfo.PatientInfoId = Convert.ToInt32(reader["PatientInfoId"]);
    //        objDOPatientInfo.PrnNo = Convert.ToString(reader["PrnNo"]);
    //        objDOPatientInfo.PatientName = Convert.ToString(reader["PatientName"]);
    //        objDOPatientInfo.PatientCategoryName = Convert.ToString(reader["PatientCategoryName"]);
    //        objDOPatientInfo.PatientSubCategoryName = Convert.ToString(reader["PatientSubCategoryName"]);
    //        objDOPatientInfo.PatientAddress = Convert.ToString(reader["PatientAddress"]);
    //        objDOPatientInfo.Email = Convert.ToString(reader["Email"]);
    //        objDOPatientInfo.EntryDate = Convert.ToDateTime(reader["EntryDate"]).ToShortDateString();
    //        objListDOPatientInfo.Add(objDOPatientInfo);
    //    }
    //    reader.Close();
    //    reader.Dispose();
    //    return objListDOPatientInfo;
    //}

    public DataSet FillTitleName()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("Sp_TitleFillCombo", con);
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

    public DataSet FillCollectionCenterName(int PType)
    {
        SqlConnection con = new SqlConnection();
        if (PType == 1)
        {
            con = DataAccess.ConInitForPathology();
        }
        else if (PType == 2)
        {
            con = DataAccess.ConInitForRadiology();
        }
        else  if (PType == 3)
        {
            con = DataAccess.ConInitForMedical();
        }
        else if (PType == 4)
        {
            con = DataAccess.ConInitForCardiology();
        }
        else
        {
            con = DataAccess.ConInitForMedical();
        }
        //SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("SP_GetCollectionCenter", con);
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


    public DataSet FillGender()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("Sp_GenderFillCombo", con);
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
    public DataSet FillPatMainTypeDrop()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("Sp_PatMainTypeFillCombo", con);
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

    public DataSet FillPatInsuTypeDrop(int PatMainTypeId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_PatInsuTypeFillCombo", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PatMainTypeId", PatMainTypeId);
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
    public DataSet FillCountryName()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("SP_CountryFillDrop", con);
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

    public DataSet FillStateName(int CountryId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_StateFillDropByCountry", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@CountryId", CountryId);
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
    public DataSet FillCityName(int StateId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_CityFillDropByState", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@StateId", StateId);
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

    public DataSet FillCancelPatientGrid(string FromDate, string ToDate)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_CancelPatientRegFillGrid", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@FromDate", FromDate);
        cmd.Parameters.AddWithValue("@ToDate", ToDate);

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

    public DataSet FillReferToAdmissionPatientList(string FromDate, string ToDate)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_ReferToAdmissionPatientList", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@FromDate", FromDate);
        cmd.Parameters.AddWithValue("@ToDate", ToDate);

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

    public DataTable FillGrid_OpdVisitChildren()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_VW_OpdVisitChildren", con);
        cmd.CommandType = CommandType.StoredProcedure;
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

    public DataTable FillGrid_OpdVisitForWomeans()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_VW_OpdVisitForWomeans", con);
        cmd.CommandType = CommandType.StoredProcedure;
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
    public DataTable FillGrid_MalerialPatient()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_VW_VisitForMalariaPatient", con);
        cmd.CommandType = CommandType.StoredProcedure;
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
    public DataTable FillGrid_ANCPatient()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_VW_VisitForANCPatient", con);
        cmd.CommandType = CommandType.StoredProcedure;
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

    public DataTable FillGrid_HIVPositivePatient()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_VW_VisitForHIVPositivePatient", con);
        cmd.CommandType = CommandType.StoredProcedure;
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

    public DataTable FillGrid_DeliveryPatient()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_VW_VisitForDeliveryPatient", con);
        cmd.CommandType = CommandType.StoredProcedure;
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

    public DataTable FillGrid_ImmulizationPatient()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_VW_VisitForImmulizationPatient", con);
        cmd.CommandType = CommandType.StoredProcedure;
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

    public DataTable FillGrid_contraceptiveUsePatient()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_VW_VisitForcontraceptivePatient", con);
        cmd.CommandType = CommandType.StoredProcedure;
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
    public DataTable FillGrid_MaternityDeathPatient()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_VW_VisitForMaternityDeathPatient", con);
        cmd.CommandType = CommandType.StoredProcedure;
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
    public DataTable FillGrid_VitalPatients()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_VisitForVitalPatients", con);
        cmd.CommandType = CommandType.StoredProcedure;
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


    public DataTable Get_Religion()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("SP_GetReligion", con);
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

    public DataTable Get_Race()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("SP_GetRace", con);
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

    public DataTable Get_Surgery_Type()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("SP_GetSurgeryType", con);
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


    public DataSet FillPatInsuCharge_TypeDrop(int PatientInsuTypeId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_BindPatientInsu_SubType", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PatientInsuTypeId", PatientInsuTypeId);
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

    public DataTable  Get_ChildCompany_Description(int Id)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_Get_ChildCompany_Description", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Id", Id);
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


    public DataTable Get_LastVisitDate(int Id)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_GetLastVisitDate", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Patregid", Id);
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

    public DataTable Get_ChangeDr(int Id,int OpdNo)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_ChangeDr", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Patregid", Id);
        cmd.Parameters.AddWithValue("@OpdNo", OpdNo);
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

    public DataTable Get_PreviousHistory( int Patregid)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_GetPreviousHistory", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Patregid", Patregid);
       
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

    public DataTable Get_ChargeNumber(int Patregid)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_GetChargeNumber", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Patregid", Patregid);

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

    public DataTable Get_ChargeNumber_ForLAB(int Patregid)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_GetChargeNumber_ForLAB", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Patregid", Patregid);

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

    public DataTable Edit_FrontDeskBill(int Patregid, int ProcedureId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_GetFrontDeskBill", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Patregid", Patregid);
        cmd.Parameters.AddWithValue("@ProcedureId", ProcedureId);

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

    public DataTable Get_IpdRegistrationDetails(int Patregid)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_GetIpdRegistration", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Patregid", Patregid);
        

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

    public DataTable Get_CheckOpdPending_Request(int Patregid)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_CheckOpdPending_Request", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Patregid", Patregid);


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

    public string Update_MergeRegNo( int Patregid,int MergRegNo,string MergeBy)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_MergeDuplicatePatients", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@Patregno", Patregid);
            cmd.Parameters.AddWithValue("@MergeRegNo", MergRegNo);
            cmd.Parameters.AddWithValue("@MergeBy", MergeBy);
            


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

    public DataTable Get_AdmitedCurrentBed(int IPDNO)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_GetCurrentAdmitedBed", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@IPDNO", IPDNO);


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

    public DataSet OTBookingReport(string FromDate, string ToDate, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_GetOTBookingReport", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@FromDate", FromDate);
        cmd.Parameters.AddWithValue("@ToDate", ToDate);
        cmd.Parameters.AddWithValue("@BranchId", BranchId);

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

    public DataTable Get_PatientUserName(int Patregid)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_GetPatientUserName", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Patregid", Patregid);


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

    public DataTable Get_DiscountPercent(int Id)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_Get_DiscountPercent", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Id", Id);
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

    public DataSet SuspendandResumeList(string FromDate, string ToDate)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_SuspendandResumeList", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@FromDate", FromDate);
        cmd.Parameters.AddWithValue("@ToDate", ToDate);

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
}