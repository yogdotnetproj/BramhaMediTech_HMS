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
/// Summary description for DAlInsurance
/// </summary>
public class DAlInsurance
{
    BELInsurance objBELInsu = new BELInsurance();
    
	public DAlInsurance()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public BELInsurance SelectOne(int InsuranceCompanyId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_InsuranceCompSelectOne", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@InsuranceCompanyId", InsuranceCompanyId);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                objBELInsu.InsuranceCompanyId = Convert.ToInt32(sdr["InsuranceCompanyId"]);
                objBELInsu.InsuranceCompanyName = Convert.ToString(sdr["InsuranceCompanyName"]);
                objBELInsu.InsuranceCompanyAddress = Convert.ToString(sdr["InsuranceCompanyAddress"]);
                objBELInsu.CountryId = Convert.ToInt32(sdr["CountryId"]);
                objBELInsu.StateId = Convert.ToInt32(sdr["StateId"]);
                objBELInsu.CityId = Convert.ToInt32(sdr["CityId"]);
                objBELInsu.PostalCode = Convert.ToString(sdr["PostalCode"]);
                objBELInsu.Email = Convert.ToString(sdr["Email"]);
                objBELInsu.PhoneNo = Convert.ToString(sdr["PhoneNo"]);
                objBELInsu.FaxNo = Convert.ToString(sdr["FaxNo"]);
                objBELInsu.ContactPersonName = Convert.ToString(sdr["ContactPersonName"]);
                objBELInsu.CPMobileNo = Convert.ToString(sdr["CPMobileNo"]);
                objBELInsu.CPPhone = Convert.ToString(sdr["CPPhone"]);
                objBELInsu.CPEmail = Convert.ToString(sdr["CPEmail"]);
                objBELInsu.Notes = Convert.ToString(sdr["Notes"]);
                //objBELInsu.IsActive = Convert.ToBoolean(sdr["IsActive"]);
                //objBELInsu.CreatedBy = Convert.ToString(sdr["CreatedBy"]);
                //objBELInsu.CreatedOn = Convert.ToDateTime(sdr["CreatedOn"]);
                //objBELInsu.UpdatedBy = Convert.ToString(sdr["UpdatedBy"]);
                //objBELInsu.UpdatedOn = Convert.ToDateTime(sdr["UpdatedOn"]);



            }
            return objBELInsu;
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


    public DataSet FillInsuranceCorporateCompany(string CompanyType,int FId,int BranchId)
    {          
        SqlConnection con = DataAccess.ConInitForDC();
       
        SqlCommand cmd=new SqlCommand("Sp_FillInsuranceCorporateCompany", con);
        cmd.CommandType = CommandType.StoredProcedure; 
        con.Open();
        cmd.Parameters.AddWithValue("@Flag",CompanyType);
        cmd.Parameters.AddWithValue("@FId", FId);
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
   
     public DataSet FillGrid()
    {          
        SqlConnection con = DataAccess.ConInitForDC();
        SqlDataAdapter da = new SqlDataAdapter("Sp_InsuranceCompFillGrid", con);
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

     public object[] InsertPatientInsuranceDetails(BELInsurance objBELInsu)
     {
         object[] Result = new object[10];
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_InsertUpdatePatInsuranceDetails", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {

            cmd.Parameters.AddWithValue("@InsuranceCompanyId", objBELInsu.InsuranceCompanyId);
            cmd.Parameters.AddWithValue("@PatRegId", objBELInsu.PatRegId);
            cmd.Parameters.AddWithValue("@IpdId", objBELInsu.IpdId);
            cmd.Parameters.AddWithValue("@MemberName", objBELInsu.MemberName);
            cmd.Parameters.AddWithValue("@MembershipNo", objBELInsu.MembershipNo);
            cmd.Parameters.AddWithValue("@CompanyType", objBELInsu.CompanyType);
            cmd.Parameters.AddWithValue("@Relation", objBELInsu.Relation);     
            cmd.Parameters.AddWithValue("@CreatedBy",objBELInsu.CreatedBy);
            cmd.Parameters.AddWithValue("@TitleId", objBELInsu.TitleId);
            cmd.Parameters.AddWithValue("@FId", objBELInsu.FId);
            cmd.Parameters.AddWithValue("@BranchId", objBELInsu.BranchId);
            Result[0] = cmd.ExecuteScalar();
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

     public string InsertInsuranceCompany(BELInsurance objBELInsu)
     {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_InsuranceCompInsert", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {

            cmd.Parameters.AddWithValue("@InsuranceCompanyName", objBELInsu.InsuranceCompanyName);
            cmd.Parameters.AddWithValue("@InsuranceCompanyAddress", objBELInsu.InsuranceCompanyAddress);
            cmd.Parameters.AddWithValue("@CountryId", objBELInsu.CountryId);
            cmd.Parameters.AddWithValue("@StateId",objBELInsu.StateId);
            cmd.Parameters.AddWithValue("@CityId", objBELInsu.CityId);
            cmd.Parameters.AddWithValue("@PostalCode", objBELInsu.PostalCode);
            cmd.Parameters.AddWithValue("@Email", objBELInsu.Email);
            cmd.Parameters.AddWithValue("@PhoneNo", objBELInsu.PhoneNo);
            cmd.Parameters.AddWithValue("@FaxNo", objBELInsu.FaxNo);
            cmd.Parameters.AddWithValue("@ContactPersonName", objBELInsu.ContactPersonName);
            cmd.Parameters.AddWithValue("@CPMobileNo", objBELInsu.CPMobileNo);
            cmd.Parameters.AddWithValue("@CPPhone", objBELInsu.CPPhone);
            cmd.Parameters.AddWithValue("@CPEmail", objBELInsu.CPEmail);
            cmd.Parameters.AddWithValue("@Notes", objBELInsu.Notes);
            cmd.Parameters.AddWithValue("@CreatedBy",objBELInsu.CreatedBy);
            cmd.Parameters.AddWithValue("@FId", objBELInsu.FId);
            cmd.Parameters.AddWithValue("@BranchId", objBELInsu.BranchId);

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


     public string UpdateInsuranceCompany(BELInsurance objBELInsu)
     {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_InsuranceCompUpdate", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {
            cmd.Parameters.AddWithValue("@InsuranceCompanyId", objBELInsu.InsuranceCompanyId);
            cmd.Parameters.AddWithValue("@InsuranceCompanyName", objBELInsu.InsuranceCompanyName);
            cmd.Parameters.AddWithValue("@InsuranceCompanyAddress", objBELInsu.InsuranceCompanyAddress);
            cmd.Parameters.AddWithValue("@CountryId", objBELInsu.CountryId);
            cmd.Parameters.AddWithValue("@StateId", objBELInsu.StateId);
            cmd.Parameters.AddWithValue("@CityId", objBELInsu.CityId);
            cmd.Parameters.AddWithValue("@PostalCode", objBELInsu.PostalCode);
            cmd.Parameters.AddWithValue("@Email", objBELInsu.Email);
            cmd.Parameters.AddWithValue("@PhoneNo", objBELInsu.PhoneNo);
            cmd.Parameters.AddWithValue("@FaxNo", objBELInsu.FaxNo);
            cmd.Parameters.AddWithValue("@ContactPersonName", objBELInsu.ContactPersonName);
            cmd.Parameters.AddWithValue("@CPMobileNo", objBELInsu.CPMobileNo);
            cmd.Parameters.AddWithValue("@CPPhone", objBELInsu.CPPhone);
            cmd.Parameters.AddWithValue("@CPEmail", objBELInsu.CPEmail);
            cmd.Parameters.AddWithValue("@Notes", objBELInsu.Notes);
            cmd.Parameters.AddWithValue("@UpdatedBy", objBELInsu.UpdatedBy);

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

   
    public string DeleteInsuranceCompany(int InsuranceCompanyId)
    {      
        
         SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_InsuranceCompDelete", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@InsuranceCompanyId", InsuranceCompanyId);
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
    public string ChkExistPatientInsuranceDetails(BELInsurance objBELInsu)
    {
        string Exists = "";
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_ChkExistPatientInsuranceDetails", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {
            cmd.Parameters.AddWithValue("@PatRegId", objBELInsu.PatRegId);
            cmd.Parameters.AddWithValue("@IpdId", objBELInsu.IpdId);
            cmd.Parameters.AddWithValue("@FId", objBELInsu.FId);
            cmd.Parameters.AddWithValue("@BranchId", objBELInsu.BranchId);
            Exists =Convert.ToString(cmd.ExecuteScalar());
            return Exists;
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


    public BELInsurance SelectPatientInsuranceDetails(BELInsurance objBELInsu)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_SelectPatientInsuranceDetails", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {
            cmd.Parameters.AddWithValue("@PatRegId", objBELInsu.PatRegId);
            cmd.Parameters.AddWithValue("@IpdId", objBELInsu.IpdId);
            cmd.Parameters.AddWithValue("@FId", objBELInsu.FId);
            cmd.Parameters.AddWithValue("@BranchId", objBELInsu.BranchId);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                objBELInsu.InsuranceCompanyId = Convert.ToInt32(sdr["InsuranceCompanyId"]);
                objBELInsu.MemberName = Convert.ToString(sdr["MemberName"]);
                objBELInsu.MembershipNo = Convert.ToString(sdr["MembershipNo"]);
                objBELInsu.Relation = Convert.ToString(sdr["Relation"]);
                objBELInsu.TitleId=Convert.ToInt32(sdr["TitleId"]);
                objBELInsu.CompanyType = Convert.ToString(sdr["CompanyType"]);
            }
            return objBELInsu;
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