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
/// Summary description for DALAntenatal
/// </summary>
public class DALAntenatal
{
    BELAntenatal objBELAnte = new BELAntenatal();
	public DALAntenatal()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public BELAntenatal GetMaxOrderNo()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_GetMaxOrderNo", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {
            object obj = cmd.ExecuteScalar();
            if (obj == DBNull.Value)
                objBELAnte.OrderNo = 0;
            else
                objBELAnte.OrderNo = Convert.ToInt32(obj)+1;

            return objBELAnte;
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

    public DataSet FillGridAnte()
    {

        SqlConnection con = DataAccess.ConInitForDC();
        SqlDataAdapter da = new SqlDataAdapter("SP_AnteFillGrid", con);
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


    public BELAntenatal SelectOneAnte(int GyParticularId)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_AnteSelectOne", con);
        cmd.CommandType = CommandType.StoredProcedure;


        try
        {
            cmd.Parameters.AddWithValue("@GyParticularId", GyParticularId);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                objBELAnte.GyParticularId = Convert.ToInt32(sdr["GyParticularId"]);
                objBELAnte.Particular = Convert.ToString(sdr["Particular"]);
                objBELAnte.OrderNo = Convert.ToInt32(sdr["OrderNo"]);


            }
            return objBELAnte;
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

    public string UpdateAnte(BELAntenatal objBELAnte)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_AnteUpdate", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {
            cmd.Parameters.AddWithValue("@GyParticularId", objBELAnte.GyParticularId);
            cmd.Parameters.AddWithValue("@Particular", objBELAnte.Particular);
            cmd.Parameters.AddWithValue("@OrderNo", objBELAnte.OrderNo);
            cmd.Parameters.AddWithValue("@UpdatedBy", objBELAnte.UpdatedBy);

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

    public string InsertAnte(BELAntenatal objBELAnte)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_AnteInsert", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {

            cmd.Parameters.AddWithValue("@Particular", objBELAnte.Particular);
            cmd.Parameters.AddWithValue("@OrderNo", objBELAnte.OrderNo);
            cmd.Parameters.AddWithValue("@FId", objBELAnte.FId);
            cmd.Parameters.AddWithValue("@BranchId", objBELAnte.BranchId);
            cmd.Parameters.AddWithValue("@CreatedBy", objBELAnte.CreatedBy);

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

    public string DeleteAnte(int GyParticularId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_AnteDelete", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@GyParticularId", GyParticularId);
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