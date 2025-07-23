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


public class DALIpdRateType
{
    BELIpdRateType objBELIpdRateType = new BELIpdRateType();
	public DALIpdRateType()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public BELIpdRateType SelectOne(int RateTypeIpdId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_IpdRateTypeSelectOne", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@RateTypeIpdId", RateTypeIpdId);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                objBELIpdRateType.RateTypeId = Convert.ToInt32(sdr["RateTypeId"]);
                objBELIpdRateType.RTypeId = Convert.ToInt32(sdr["RTypeId"]);
                if (sdr["PatMainTypeId"] != DBNull.Value)
                    objBELIpdRateType.PatMainTypeId = Convert.ToInt32(sdr["PatMainTypeId"]);
                else
                    objBELIpdRateType.PatMainTypeId = 0;

                if (sdr["PatientInsuTypeId"] != DBNull.Value)
                    objBELIpdRateType.PatientInsuTypeId = Convert.ToInt32(sdr["PatientInsuTypeId"]);
                else
                    objBELIpdRateType.PatientInsuTypeId = 0;


            }
            return objBELIpdRateType;
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
        SqlDataAdapter da = new SqlDataAdapter("Sp_IpdRateTypeFillGrid", con);
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
    public DataSet FillRoomTypeDrop()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("Sp_RoomTypeFillDrop", con);
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
    public DataSet FillSearchGrid(BELIpdRateType objBELIpdRateType)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_IpdRateTypeSearch", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PatMainType", objBELIpdRateType.PatMainType);
        cmd.Parameters.AddWithValue("@RateType", objBELIpdRateType.RateType);
        cmd.Parameters.AddWithValue("@PatientInsuType", objBELIpdRateType.PatientInsuType);
        cmd.Parameters.AddWithValue("@RType", objBELIpdRateType.RType);

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

    public string InsertRateTypeIpd(BELIpdRateType objBELIpdRateType)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_IpdRateTypeInsert", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {

            cmd.Parameters.AddWithValue("@RateTypeId", objBELIpdRateType.RateTypeId);
            cmd.Parameters.AddWithValue("@PatMainTypeId", objBELIpdRateType.PatMainTypeId);
            cmd.Parameters.AddWithValue("@PatientInsuTypeId", objBELIpdRateType.PatientInsuTypeId);
            cmd.Parameters.AddWithValue("@RTypeId", objBELIpdRateType.RTypeId);
            cmd.Parameters.AddWithValue("@CreatedBy", objBELIpdRateType.CreatedBy);
            cmd.Parameters.AddWithValue("@FId", objBELIpdRateType.FId);
            cmd.Parameters.AddWithValue("@BranchId", objBELIpdRateType.BranchId);

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

    public string UpdateIpdRateType(BELIpdRateType objBELIpdRateType)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_IpdRateTypeUpdate", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {
            cmd.Parameters.AddWithValue("@RateTypeIpdId", objBELIpdRateType.RateTypeIpdId);
            cmd.Parameters.AddWithValue("@RateTypeId", objBELIpdRateType.RateTypeId);
            cmd.Parameters.AddWithValue("@PatMainTypeId", objBELIpdRateType.PatMainTypeId);
            cmd.Parameters.AddWithValue("@PatientInsuTypeId", objBELIpdRateType.PatientInsuTypeId);
            cmd.Parameters.AddWithValue("@RTypeId", objBELIpdRateType.RTypeId);
            cmd.Parameters.AddWithValue("@UpdatedBy", objBELIpdRateType.UpdatedBy);

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

    public string DeleteIpdRateType(int RateTypeIpdId)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_IpdRateTypeDelete", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@RateTypeIpdId", RateTypeIpdId);
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