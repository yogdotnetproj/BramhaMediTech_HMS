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
/// Summary description for DALReasonDiscount
/// </summary>
public class DALReasonDiscount
{
    BELReasonDiscount objBELDiscount = new BELReasonDiscount();
	public DALReasonDiscount()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public BELReasonDiscount SelectOne(int DiscTypeId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_DiscReasonSelectOne", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@DiscTypeId", DiscTypeId);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                objBELDiscount.DiscType = Convert.ToString(sdr["DiscType"]);
                objBELDiscount.DiscTypeId = Convert.ToInt32(sdr["DiscTypeId"]);


            }
            return objBELDiscount;
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
        SqlDataAdapter da = new SqlDataAdapter("Sp_DiscReasonFillGrid", con);
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

    public string InsertDiscReason(BELReasonDiscount objBELDiscount)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_DiscReasonInsert", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {

            cmd.Parameters.AddWithValue("@DiscType", objBELDiscount.DiscType);
            cmd.Parameters.AddWithValue("@CreatedBy", objBELDiscount.CreatedBy);
            cmd.Parameters.AddWithValue("@FId", objBELDiscount.FId);
            cmd.Parameters.AddWithValue("@BranchId", objBELDiscount.BranchId);

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


    public string UpdateDiscReason(BELReasonDiscount objBELDiscount)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_DiscReasonUpdate", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {
            cmd.Parameters.AddWithValue("@DiscTypeId", objBELDiscount.DiscTypeId);
            cmd.Parameters.AddWithValue("@DiscType", objBELDiscount.DiscType);
            cmd.Parameters.AddWithValue("@UpdatedBy", objBELDiscount.UpdatedBy);

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


    public string DeleteDiscReason(int DiscTypeId)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_DiscReasonDelete", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@DiscTypeId", DiscTypeId);
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