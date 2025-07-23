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
/// Summary description for DALSDC
/// </summary>
public class DALSDC
{
    BELSDC objBELSDC = new BELSDC();
	public DALSDC()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataSet FillGridCountry()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("Sp_CountryFillGrid", con);
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
    public string  CountryInsert(BELSDC ObjBELSDC)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_CountryInsert", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {

            cmd.Parameters.AddWithValue("@CountryName", ObjBELSDC.CountryName);
            cmd.Parameters.AddWithValue("@CountryCode", ObjBELSDC.CountryCode);
            cmd.Parameters.AddWithValue("@CreatedBy", ObjBELSDC.CreatedBy);
          //  cmd.Parameters.AddWithValue("@BranchId", ObjBELSDC.BranchId);
           

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
    public BELSDC SelectOneCountry(int CountryId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_CountrySelectOne", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {
            cmd.Parameters.AddWithValue("@CountryId", CountryId);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                objBELSDC.CountryName = sdr["CountryName"].ToString();
                objBELSDC.CountryCode=sdr["CountryCode"].ToString();
                
            }
            return objBELSDC;
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
    public string UpdateCountry(BELSDC objBELSDC)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_CountryUpdate", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {
            cmd.Parameters.AddWithValue("@CountryId", objBELSDC.CountryId);
            cmd.Parameters.AddWithValue("@CountryName", objBELSDC.CountryName);
            cmd.Parameters.AddWithValue("@CountryCode", objBELSDC.CountryCode);
            cmd.Parameters.AddWithValue("@UpdatedBy", objBELSDC.UpdatedBy);

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

    public string DeleteCountry(int CountryId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_CountryDelete", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@CountryId", CountryId);
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


    public DataSet FillGridState()
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("Sp_StateFillGrid", con);
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


    public BELSDC SelectOneState(int StateId)
    {
       
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_StateSelectOne", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {
            cmd.Parameters.AddWithValue("@StateId", StateId);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
               
                objBELSDC.StateId = Convert.ToInt32(sdr["StateId"]);
                objBELSDC.StateName = Convert.ToString(sdr["StateName"]);
                objBELSDC.CountryId = Convert.ToInt32(sdr["CountryId"]);
            }
            return objBELSDC;
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


    public string UpdateState(BELSDC objBELSDC)
    {
        
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_StateUpdate", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@StateId", objBELSDC.StateId);
            cmd.Parameters.AddWithValue("@StateName", objBELSDC.StateName);
            cmd.Parameters.AddWithValue("@CountryId", objBELSDC.CountryId);
            cmd.Parameters.AddWithValue("@UpdatedBy", objBELSDC.UpdatedBy);

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


    public string InsertState(BELSDC objBELSDC)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_StateInsert", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {
            
            cmd.Parameters.AddWithValue("@StateName", objBELSDC.StateName);
            cmd.Parameters.AddWithValue("@CountryId", objBELSDC.CountryId);
            cmd.Parameters.AddWithValue("@CreatedBy", objBELSDC.CreatedBy);

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

    
    public string DeleteState(int StateId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_StateDelete", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@StateId", StateId);
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

    public DataSet FillCountryDrop()
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

    
    public DataSet FillStateDrop()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("Sp_StateFillDrop", con);
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


    public DataSet FillGridCity()
    {

        SqlConnection con = DataAccess.ConInitForDC();
        SqlDataAdapter da = new SqlDataAdapter("SP_CityFillGrid", con);
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


    public BELSDC SelectOneCity(int CityId)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_CitySelectOne", con);
        cmd.CommandType = CommandType.StoredProcedure;
        
        
        try
        {
            cmd.Parameters.AddWithValue("@CityId",CityId);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {

                objBELSDC.StateId = Convert.ToInt32(sdr["StateId"]);
                objBELSDC.CityName = Convert.ToString(sdr["CityName"]);
                objBELSDC.CityId = Convert.ToInt32(sdr["CityId"]);
            }
            return objBELSDC;
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


    public string UpdateCity(BELSDC objBELSDC)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_CityUpdate", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {
            cmd.Parameters.AddWithValue("@CityId", objBELSDC.CityId);
            cmd.Parameters.AddWithValue("@CityName", objBELSDC.CityName);
            cmd.Parameters.AddWithValue("@StateId", objBELSDC.StateId);
            cmd.Parameters.AddWithValue("@UpdatedBy", objBELSDC.UpdatedBy);

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


    public string InsertCity(BELSDC objBELSDC)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_CityInsert", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {

            cmd.Parameters.AddWithValue("@CityName", objBELSDC.CityName);
            cmd.Parameters.AddWithValue("@StateId", objBELSDC.StateId);
            cmd.Parameters.AddWithValue("@CreatedBy", objBELSDC.CreatedBy);

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


    public string DeleteCity(int CityId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_CityDelete", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@CityId", CityId);
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

    public DataSet FillStateDrop_ByCountry(int CountryId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_StateFillCombo_ByCountryId", con);
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

    public DataSet FillCityDrop_ByState(int StateId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_CityFillCombo_ByStateId", con);
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


}