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
/// Summary description for DALCorporateCompany
/// </summary>
public class DALCorporateCompany
{
    BELCorporateCompany objBELCorp = new BELCorporateCompany();
	public DALCorporateCompany()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public BELCorporateCompany SelectOne(int CorporateCompanyId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_CorporateCompSelectOne", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@CorporateCompanyId", CorporateCompanyId);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                objBELCorp.CorporateCompanyId = Convert.ToInt32(sdr["CorporateCompanyId"]);
                objBELCorp.CorporateCompanyAddress = Convert.ToString(sdr["CorporateCompanyAddress"]);
                objBELCorp.CorporateCompanyName = Convert.ToString(sdr["CorporateCompanyName"]);
                objBELCorp.CountryId = Convert.ToInt32(sdr["CountryId"]);
                objBELCorp.StateId = Convert.ToInt32(sdr["StateId"]);
                objBELCorp.CityId = Convert.ToInt32(sdr["CityId"]);
                objBELCorp.PostalCode = Convert.ToString(sdr["PostalCode"]);
                objBELCorp.Email = Convert.ToString(sdr["Email"]);
                objBELCorp.PhoneNo = Convert.ToString(sdr["PhoneNo"]);
                objBELCorp.FaxNo = Convert.ToString(sdr["FaxNo"]);
                objBELCorp.ContactPersonName = Convert.ToString(sdr["ContactPersonName"]);
                objBELCorp.CPMobileNo = Convert.ToString(sdr["CPMobileNo"]);
                objBELCorp.CPPhone = Convert.ToString(sdr["CPPhone"]);
                objBELCorp.CPEmail = Convert.ToString(sdr["CPEmail"]);
                objBELCorp.Notes = Convert.ToString(sdr["Notes"]);
                //objBELCorp.IsActive = Convert.ToBoolean(sdr["IsActive"]);
                //objBELCorp.CreatedBy = Convert.ToString(sdr["CreatedBy"]);
                //objBELCorp.CreatedOn = Convert.ToDateTime(sdr["CreatedOn"]);
                //objBELCorp.UpdatedBy = Convert.ToString(sdr["UpdatedBy"]);
                //objBELCorp.UpdatedOn = Convert.ToDateTime(sdr["UpdatedOn"]);



            }
            return objBELCorp;
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

   

    public DataSet FillGrid()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlDataAdapter da = new SqlDataAdapter("Sp_CorporateCompFillGrid", con);
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

    public string InsertCorporateCompany(BELCorporateCompany objBELCorp)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_CorporateCompInsert", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {

            cmd.Parameters.AddWithValue("@CorporateCompanyName", objBELCorp.CorporateCompanyName);
            cmd.Parameters.AddWithValue("@CorporateCompanyAddress", objBELCorp.CorporateCompanyAddress);
            cmd.Parameters.AddWithValue("@CountryId", objBELCorp.CountryId);
            cmd.Parameters.AddWithValue("@StateId", objBELCorp.StateId);
            cmd.Parameters.AddWithValue("@CityId", objBELCorp.CityId);
            cmd.Parameters.AddWithValue("@PostalCode", objBELCorp.PostalCode);
            cmd.Parameters.AddWithValue("@Email", objBELCorp.Email);
            cmd.Parameters.AddWithValue("@PhoneNo", objBELCorp.PhoneNo);
            cmd.Parameters.AddWithValue("@FaxNo", objBELCorp.FaxNo);
            cmd.Parameters.AddWithValue("@ContactPersonName", objBELCorp.ContactPersonName);
            cmd.Parameters.AddWithValue("@CPMobileNo", objBELCorp.CPMobileNo);
            cmd.Parameters.AddWithValue("@CPPhone", objBELCorp.CPPhone);
            cmd.Parameters.AddWithValue("@CPEmail", objBELCorp.CPEmail);
            cmd.Parameters.AddWithValue("@Notes", objBELCorp.Notes);
            cmd.Parameters.AddWithValue("@CreatedBy", objBELCorp.CreatedBy);
            cmd.Parameters.AddWithValue("@FId", objBELCorp.FId);
            cmd.Parameters.AddWithValue("@BranchId", objBELCorp.BranchId);

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


    public string UpdateCorporateCompany(BELCorporateCompany objBELCorp)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_CorporateCompUpdate", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {
            cmd.Parameters.AddWithValue("@CorporateCompanyId", objBELCorp.CorporateCompanyId);
            cmd.Parameters.AddWithValue("@CorporateCompanyName", objBELCorp.CorporateCompanyName);
            cmd.Parameters.AddWithValue("@CorporateCompanyAddress", objBELCorp.CorporateCompanyAddress);
            cmd.Parameters.AddWithValue("@CountryId", objBELCorp.CountryId);
            cmd.Parameters.AddWithValue("@StateId", objBELCorp.StateId);
            cmd.Parameters.AddWithValue("@CityId", objBELCorp.CityId);
            cmd.Parameters.AddWithValue("@PostalCode", objBELCorp.PostalCode);
            cmd.Parameters.AddWithValue("@Email", objBELCorp.Email);
            cmd.Parameters.AddWithValue("@PhoneNo", objBELCorp.PhoneNo);
            cmd.Parameters.AddWithValue("@FaxNo", objBELCorp.FaxNo);
            cmd.Parameters.AddWithValue("@ContactPersonName", objBELCorp.ContactPersonName);
            cmd.Parameters.AddWithValue("@CPMobileNo", objBELCorp.CPMobileNo);
            cmd.Parameters.AddWithValue("@CPPhone", objBELCorp.CPPhone);
            cmd.Parameters.AddWithValue("@CPEmail", objBELCorp.CPEmail);
            cmd.Parameters.AddWithValue("@Notes", objBELCorp.Notes);
            cmd.Parameters.AddWithValue("@UpdatedBy", objBELCorp.UpdatedBy);

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


    public string DeleteCorporateCompany(int CorporateCompanyId)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_CorporateCompDelete", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@CorporateCompanyId", CorporateCompanyId);
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

       
}