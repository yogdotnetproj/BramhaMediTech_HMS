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

public class DALOpdRateType
{
    BELOpdRateType objBELOpdRateType = new BELOpdRateType();
	public DALOpdRateType()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public BELOpdRateType SelectOne(int RateTypeOpdId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_OpdRateTypeSelectOne", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@RateTypeOpdId", RateTypeOpdId);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                objBELOpdRateType.RateTypeId = Convert.ToInt32(sdr["RateTypeId"]);
                objBELOpdRateType.PatMainTypeId = Convert.ToInt32(sdr["PatMainTypeId"]);
                if (sdr["PatientInsuTypeId"] != DBNull.Value)
                    objBELOpdRateType.PatientInsuTypeId = Convert.ToInt32(sdr["PatientInsuTypeId"]);
                else
                    objBELOpdRateType.PatientInsuTypeId = 0;


            }
            return objBELOpdRateType;
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
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("Sp_OpdRateTypeFillGrid", con);
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
    public DataSet FillRateTypeDrop()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("Sp_RateTypeFillCombo", con);
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
        cmd.CommandType=CommandType.StoredProcedure;
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
    public DataSet FillSearchGrid(BELOpdRateType objBELOpdRateType)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_OpdRateTypeSearch", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PatMainType", objBELOpdRateType.PatMainType);
        cmd.Parameters.AddWithValue("@RateType", objBELOpdRateType.RateType);
        cmd.Parameters.AddWithValue("@PatientInsuType", objBELOpdRateType.PatientInsuType);

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

    public string InsertRateTypeOpd(BELOpdRateType objBELOpdRateType)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_OpdRateTypeInsert", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {

            cmd.Parameters.AddWithValue("@RateTypeId", objBELOpdRateType.RateTypeId);
            cmd.Parameters.AddWithValue("@PatMainTypeId", objBELOpdRateType.PatMainTypeId);
            cmd.Parameters.AddWithValue("@PatientInsuTypeId", objBELOpdRateType.PatientInsuTypeId);
            cmd.Parameters.AddWithValue("@CreatedBy", objBELOpdRateType.CreatedBy);
            cmd.Parameters.AddWithValue("@FId", objBELOpdRateType.FId);
            cmd.Parameters.AddWithValue("@BranchId", objBELOpdRateType.BranchId);

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

    public string UpdateOpdRateType(BELOpdRateType objBELOpdRateType)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_OpdRateTypeUpdate", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {
            cmd.Parameters.AddWithValue("@RateTypeOpdId", objBELOpdRateType.RateTypeOpdId);
            cmd.Parameters.AddWithValue("@RateTypeId", objBELOpdRateType.RateTypeId);
            cmd.Parameters.AddWithValue("@PatMainTypeId", objBELOpdRateType.PatMainTypeId);
            cmd.Parameters.AddWithValue("@PatientInsuTypeId", objBELOpdRateType.PatientInsuTypeId);
            cmd.Parameters.AddWithValue("@UpdatedBy", objBELOpdRateType.UpdatedBy);

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

    public string DeleteOpdRateType(int RateTypeOpdId)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_OpdRateTypeDelete", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@RateTypeOpdId", RateTypeOpdId);
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