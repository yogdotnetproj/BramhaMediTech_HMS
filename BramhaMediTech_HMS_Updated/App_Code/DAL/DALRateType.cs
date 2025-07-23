using System;
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
/// Summary description for DALRateType
/// </summary>
public class DALRateType
{
    BELRateType objBELRateType = new BELRateType();
	public DALRateType()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataSet FillGridRateType()
    {

        SqlConnection con = DataAccess.ConInitForDC();
        SqlDataAdapter da = new SqlDataAdapter("SP_RateTypeFillGrid", con);
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


    public BELRateType SelectOneRateType(int RateTypeId)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_RateTypeSelectOne", con);
        cmd.CommandType = CommandType.StoredProcedure;


        try
        {
            cmd.Parameters.AddWithValue("@RateTypeId", RateTypeId);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {

                objBELRateType.RateTypeId = Convert.ToInt32(sdr["RateTypeId"]);
                objBELRateType.RateType = Convert.ToString(sdr["RateType"]);



            }
            return objBELRateType;
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


    public string UpdateRateType(BELRateType objBELRateType)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_RateTypeUpdate", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {
            cmd.Parameters.AddWithValue("@RateTypeId", objBELRateType.RateTypeId);
            cmd.Parameters.AddWithValue("@RateType", objBELRateType.RateType);
            cmd.Parameters.AddWithValue("@UpdatedBy", objBELRateType.UpdatedBy);

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

    public string InsertRateType(BELRateType objBELRateType)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_RateTypeInsert", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {

            cmd.Parameters.AddWithValue("@FId", objBELRateType.FId);
            cmd.Parameters.AddWithValue("@BranchId", objBELRateType.BranchId);
            cmd.Parameters.AddWithValue("@RateType", objBELRateType.RateType);
            cmd.Parameters.AddWithValue("@CreatedBy", objBELRateType.CreatedBy);

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

    public string DeleteRateType(int RateTypeId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_RateTypeDelete", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@RateTypeId", RateTypeId);
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