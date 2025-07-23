using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

/// <summary>
/// Summary description for BLLPatientCategory
/// </summary>
public class BLLPatientCategory
{

    DOPatientCategory ObjDOPatientCat = new DOPatientCategory();
    //Database objDatabase = DatabaseFactory.CreateDatabase();
	public BLLPatientCategory()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataSet FillGrid_Vaccination()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlDataAdapter da = new SqlDataAdapter("Sp_GetallVaccnation_Master", con);
        con.Open();
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
        SqlDataAdapter da = new SqlDataAdapter("Sp_PatMainTypeFillgrid", con);
        con.Open();
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
   

    public string InsertPatientCategory(DOPatientCategory obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_PatMainTypeInsert", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@PatMainType", obj.PatMainType);
            cmd.Parameters.AddWithValue("@CreatedBy", obj.CreatedBy);
            cmd.Parameters.AddWithValue("@FId", obj.FId);
            cmd.Parameters.AddWithValue("@BranchId", obj.BranchId);
            //cmd.Parameters.AddWithValue("", obj.UpdatedBy);
            //cmd.Parameters.AddWithValue("", obj.UpdatedOn);

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

    public string UpdatePatientCategory(DOPatientCategory obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_PatMainTypeUpdate", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@PatMainType", obj.PatMainType);
            cmd.Parameters.AddWithValue("@PatMainTypeId", obj.PatMainTypeId);
            cmd.Parameters.AddWithValue("@UpdatedBy", obj.UpdatedBy);
           
           
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

    public DOPatientCategory SelectOne(int PatMainTypeId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_PatMainTypeSelectOne", con);
        cmd.CommandType = CommandType.StoredProcedure;
        //DOPatientCategory objDOPatientCategory = new DOPatientCategory();
        try
        {
            cmd.Parameters.AddWithValue("@PatMainTypeId", PatMainTypeId);
            
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                ObjDOPatientCat.PatMainType = Convert.ToString(sdr["PatMainType"]);              


            }
            return ObjDOPatientCat;
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
    public string DeletePatientCategory(int PatMainTypeId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_PatMainTypeDelete", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@PatMainTypeId", PatMainTypeId);
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

//______________________________________PatientSubCategory_____________________________________________________//

    public DataSet FillGridPatientSubCat()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlDataAdapter da = new SqlDataAdapter("Sp_PatSubTypeFillgrid", con);
        con.Open();
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

    public string InsertPatientSubCategory(DOPatientCategory obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_PatInsuTypeInsert", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@PatientInsuType", obj.PatientInsuType);
            cmd.Parameters.AddWithValue("@PatMainTypeId", obj.PatMainTypeId);
            cmd.Parameters.AddWithValue("@RateTypeId", obj.PatientRateTypeId);
            cmd.Parameters.AddWithValue("@OrderNo", obj.OrderNo);
            cmd.Parameters.AddWithValue("@CreatedBy", obj.CreatedBy);
            cmd.Parameters.AddWithValue("@FId", obj.FId);
            cmd.Parameters.AddWithValue("@BranchId", obj.BranchId);
            //cmd.Parameters.AddWithValue("", obj.UpdatedBy);
            //cmd.Parameters.AddWithValue("", obj.UpdatedOn);
            cmd.Parameters.AddWithValue("@LabRateTypeId", obj.PatientLabRateTypeId);
            cmd.Parameters.AddWithValue("@CompanyCode", obj.CompanyCode);

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

    public string UpdatePatientSubCategory(DOPatientCategory obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_PatInsuTypeUpdate", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@PatientInsuType", obj.PatientInsuType);
            cmd.Parameters.AddWithValue("@PatientInsuTypeId", obj.PatientInsuTypeId);
            cmd.Parameters.AddWithValue("@PatMainTypeId", obj.PatMainTypeId);
            cmd.Parameters.AddWithValue("@RateTypeId", obj.PatientRateTypeId);
            cmd.Parameters.AddWithValue("@OrderNo", obj.OrderNo);
            cmd.Parameters.AddWithValue("@FId", obj.FId);
            cmd.Parameters.AddWithValue("@BranchId", obj.BranchId);
            cmd.Parameters.AddWithValue("@UpdatedBy", obj.UpdatedBy);
            cmd.Parameters.AddWithValue("@LabRateTypeId", obj.PatientLabRateTypeId);
            cmd.Parameters.AddWithValue("@CompanyCode", obj.CompanyCode);

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

    public DOPatientCategory SelectOnePatSubCategory(int PatientInsuTypeId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_PatInsuTypeSelectOne", con);
        cmd.CommandType = CommandType.StoredProcedure;
        //DOPatientCategory objDOPatientCategory = new DOPatientCategory();
        try
        {
            cmd.Parameters.AddWithValue("@PatientInsuTypeId", PatientInsuTypeId);

            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                ObjDOPatientCat.PatMainTypeId = Convert.ToInt32(sdr["PatMainTypeId"]);
                ObjDOPatientCat.PatientInsuType = Convert.ToString(sdr["PatientInsuType"]);
                if (sdr["RateTypeId"] != DBNull.Value)
                    ObjDOPatientCat.PatientRateTypeId = Convert.ToInt32(sdr["RateTypeId"]);
                else
                    ObjDOPatientCat.PatientRateTypeId = 0;
                if (sdr["OrderNo"] != DBNull.Value)
                    ObjDOPatientCat.OrderNo = Convert.ToInt32(sdr["OrderNo"]);
                else
                    ObjDOPatientCat.OrderNo = 0;
                if (sdr["LabRateTypeId"] != DBNull.Value)
                    ObjDOPatientCat.PatientLabRateTypeId = Convert.ToInt32(sdr["LabRateTypeId"]);
                else
                    ObjDOPatientCat.PatientLabRateTypeId = 0;

                ObjDOPatientCat.CompanyCode = Convert.ToString(sdr["CompanyCode"]);

            }
            return ObjDOPatientCat;
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
    public string DeletePatientSubCategory(int PatientInsuTypeId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_PatInsuTypeDelete", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@PatientInsuTypeId", PatientInsuTypeId);
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

   
    public DataSet FillPatMainTypeCombo()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("Sp_FillPatMainTypeCombo", con);       
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

    public DOPatientCategory SelectOne_Vaccination(int VaccianId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetAllVaccnation", con);
        cmd.CommandType = CommandType.StoredProcedure;
        //DOPatientCategory objDOPatientCategory = new DOPatientCategory();
        try
        {
            cmd.Parameters.AddWithValue("@VaccianId", VaccianId);

            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                ObjDOPatientCat.VaccnationName = Convert.ToString(sdr["VaccnationName"]);
                ObjDOPatientCat.FromAge = Convert.ToString(sdr["FromAge"]);
                ObjDOPatientCat.ToAge = Convert.ToString(sdr["ToAge"]);
                ObjDOPatientCat.Remark = Convert.ToString(sdr["Remark"]);
                ObjDOPatientCat.AgeType = Convert.ToString(sdr["AgeType"]);


            }
            return ObjDOPatientCat;
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

    public string Insert_VaccanationMaster(DOPatientCategory obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_InsertVaccination", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@VaccnationName", obj.VaccnationName);
            cmd.Parameters.AddWithValue("@FromAge", obj.FromAge);
            cmd.Parameters.AddWithValue("@ToAge", obj.ToAge);
            cmd.Parameters.AddWithValue("@AgeType", obj.AgeType);
            cmd.Parameters.AddWithValue("@BranchId", obj.BranchId);
          

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
    public string Update_VaccineMaster(DOPatientCategory obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_UpdateVaccineMaster", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

           
            cmd.Parameters.AddWithValue("@VaccnationName", obj.VaccnationName);
            cmd.Parameters.AddWithValue("@FromAge", obj.FromAge);
            cmd.Parameters.AddWithValue("@ToAge", obj.ToAge);
            cmd.Parameters.AddWithValue("@AgeType", obj.AgeType);
            cmd.Parameters.AddWithValue("@BranchId", obj.BranchId);
            cmd.Parameters.AddWithValue("@VaccianId", obj.PatMainTypeId);
            

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


    public string Delete_Vaccination(int VaccianId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_DeleteVaccination", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@VaccianId", VaccianId);
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

    public string Insert_VaccanationAssignToPatient(DOPatientCategory obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_InsertVaccineAssigtTpPatient", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@Patregid", obj.Patregid);
            cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
            cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);
            cmd.Parameters.AddWithValue("@VaccianId", obj.VaccianId);
            cmd.Parameters.AddWithValue("@UserName", obj.CreatedBy);
            cmd.Parameters.AddWithValue("@FID", obj.FId);
            cmd.Parameters.AddWithValue("@BranchId", obj.BranchId);


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

    public DataSet FillGrid_VaccinationToPatient(DOPatientCategory obj)
    {
       
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetallVaccnation_AssignToPatient", con);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@Patregid", obj.Patregid);
        cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
        cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);       
        cmd.Parameters.AddWithValue("@BranchId", obj.BranchId);
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
   // public string Insert_DiagnosisAssignToPatient(string Patregid,string OpdNo,string IpdNo,string DiagnosisName,string CreatedBy,string FId,string BranchId)
    public string Insert_DiagnosisAssignToPatient(DOPatientCategory obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_InsertDiagnosisAssigtTpPatient", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@Patregid", obj.Patregid);
            cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
            cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);
            cmd.Parameters.AddWithValue("@DiagnosisName", obj.DiagnosisName);
            cmd.Parameters.AddWithValue("@DiagnosisCode", obj.DiagnosisCode);
            cmd.Parameters.AddWithValue("@UserName", obj.CreatedBy);
            cmd.Parameters.AddWithValue("@FID", obj.FId);
            cmd.Parameters.AddWithValue("@BranchId", obj.BranchId);


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
   
    public DataSet FillGrid_AssignDiagnosis(DOPatientCategory obj)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetalDagnosisAssigtTpPatient", con);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@Patregid", obj.Patregid);
        cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
        cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);
        cmd.Parameters.AddWithValue("@BranchId", obj.BranchId);
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

    public string Delete_AssignDiagnosis(int Diagid)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_DeleteDagnosisAssigtTpPatient", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@Diagid", Diagid);
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
    public string Delete_AssignVaccination(int VId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_DeleteVaccineAssigtTpPatient", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@VId", VId);
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


    public DataSet Fill_MainInsuranceCompany()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("Sp_GetAllPatientInsuType", con);
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

    public string InsertPatient_InsuranceSubType(DOPatientCategory obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_InsertPatientInsu_SubType", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@PatientMainType", obj.PatMainTypeId);
            cmd.Parameters.AddWithValue("@PatientInsuTypeId", obj.PatientInsuTypeId);
            cmd.Parameters.AddWithValue("@ChildCompanyName", obj.PatientInsuType);
            cmd.Parameters.AddWithValue("@ContactNumber", obj.ContactNumber);
            cmd.Parameters.AddWithValue("@CompanyDescription", obj.InsuranceNote);
            cmd.Parameters.AddWithValue("@CreatedBy", obj.CreatedBy);           
            cmd.Parameters.AddWithValue("@BranchId", obj.BranchId);           
           

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

    public string UpdatePatient_InsuranceSubType(DOPatientCategory obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_UpdatePatientInsu_SubType", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@PatientMainType", obj.PatMainTypeId);
            cmd.Parameters.AddWithValue("@PatientInsuTypeId", obj.PatientInsuTypeId);
            cmd.Parameters.AddWithValue("@ChildCompanyName", obj.PatientInsuType);
            cmd.Parameters.AddWithValue("@ContactNumber", obj.ContactNumber);
            cmd.Parameters.AddWithValue("@CompanyDescription", obj.InsuranceNote);
            cmd.Parameters.AddWithValue("@CreatedBy", obj.CreatedBy);
            cmd.Parameters.AddWithValue("@BranchId", obj.BranchId);     
            cmd.Parameters.AddWithValue("@ID", obj.ID);

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


    public DOPatientCategory Select_InvoiceSubCategory(int Id)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_PatInsuSub_Type", con);
        cmd.CommandType = CommandType.StoredProcedure;
        //DOPatientCategory objDOPatientCategory = new DOPatientCategory();
        try
        {
            cmd.Parameters.AddWithValue("@Id", Id);

            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                ObjDOPatientCat.PatMainTypeId = Convert.ToInt32(sdr["PatientMainType"]);
                ObjDOPatientCat.PatientInsuTypeId = Convert.ToInt32(sdr["PatientInsuTypeId"]);

                ObjDOPatientCat.PatientInsuType = Convert.ToString(sdr["ChildCompanyName"]);
                ObjDOPatientCat.ContactNumber = Convert.ToString(sdr["ContactNumber"]);

                ObjDOPatientCat.InsuranceNote = Convert.ToString(sdr["CompanyDescription"]);
               // ObjDOPatientCat.PatientInsuType = Convert.ToString(sdr["PatientInsuTypeId"]);
               

            }
            return ObjDOPatientCat;
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

    public string Delete_ChildInsurance(int ID)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_DeletePatientInsu_SubType", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@Id", ID);
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

    public DataSet GetAllPatientInsu_SubType()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlDataAdapter da = new SqlDataAdapter("Sp_GetAllPatientInsu_SubType", con);
        con.Open();
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


    public DataSet Fill_MainInsuranceCompany_WithMainCategory()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("Sp_GetAllPatientInsuType", con);
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


    public DataSet Fill_MainInsuranceCompany_WithMainCategory(int Id)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetAllPatientInsuType_withCategory", con);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@PatMainTypeId", Id);
       
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


    public DataTable GetAllPatientInsu_SubType_Search_InsuranceComp(int Id)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetAllPatientInsu_SubType_Search_InsuranceComp", con);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@PatientInsuTypeId", Id);

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

    public DataTable GetAllPatientInsu_SubType_Search_ChildInsuranceComp(string  ChildName)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetAllPatientInsu_SubType_Search_ChildComp", con);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@InsuranceChildName", ChildName);

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

    public DataSet GetRoomType()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("Sp_GetRoomType", con);
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

    public DataSet GetSurgeryType()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("Sp_GetSurgeryType", con);
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


    public string InsertSurgeryDeposit_Amount(DOPatientCategory obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_Insertsurgerydepositdetails", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@RoomType", obj.RoomType);
            cmd.Parameters.AddWithValue("@SurgeryType", obj.SurgeryType);
            cmd.Parameters.AddWithValue("@DepositAmount", obj.SurgeryDeposotAmt);
           
            cmd.Parameters.AddWithValue("@CreatedBy", obj.CreatedBy);
           


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


    public string Update_SurgeryDepositAmount(DOPatientCategory obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_Updatesurgerydepositdetails", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@RoomType", obj.RoomType);
            cmd.Parameters.AddWithValue("@SurgeryType", obj.SurgeryType);
            cmd.Parameters.AddWithValue("@DepositAmount", obj.SurgeryDeposotAmt);
            cmd.Parameters.AddWithValue("@ID", obj.ID);

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


    public string Delete_SurgeryDeposit(int ID)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Deletesurgerydepositdetails", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@Id", ID);
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

    public DataSet GetAllSurgeryDepositAmount()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlDataAdapter da = new SqlDataAdapter("Sp_GetSurgeryDepositAmount", con);
        con.Open();
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

    public DOPatientCategory Select_SurgeryDepositAmount(int Id)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_getSurgeryDepositDetails", con);
        cmd.CommandType = CommandType.StoredProcedure;
        //DOPatientCategory objDOPatientCategory = new DOPatientCategory();
        try
        {
            cmd.Parameters.AddWithValue("@Id", Id);

            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                ObjDOPatientCat.RoomType = Convert.ToInt32(sdr["RoomType"]);
                ObjDOPatientCat.SurgeryType = Convert.ToString(sdr["SurgeryType"]);

                ObjDOPatientCat.SurgeryDeposotAmt = Convert.ToSingle(sdr["DepositAmount"]);
                


            }
            return ObjDOPatientCat;
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

}
