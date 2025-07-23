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
/// Summary description for DALReligion
/// </summary>
public class DALReligion
{
    BELReligion ObjBELReligion = new BELReligion();
    
	public DALReligion()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataSet FillGrid()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlDataAdapter da = new SqlDataAdapter("Sp_ReligionFillGrid", con);
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
    public string ReligionInsert(BELReligion ObjBELReligion )
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_ReligionInsert", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@Religion", ObjBELReligion.Religion);            
            cmd.Parameters.AddWithValue("@CreatedBy", ObjBELReligion.CreatedBy);
            cmd.Parameters.AddWithValue("@BranchId", ObjBELReligion.BranchId);
            cmd.Parameters.AddWithValue("@FId", ObjBELReligion.FId);

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
    public BELReligion SelectOne( int ReligionId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_ReligionSelectOne", con);       
        SqlDataReader sdr = null;
        con.Open();
        try
        {
            cmd.Parameters.AddWithValue("@ReligionId", ReligionId);
            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                ObjBELReligion.Religion = sdr["Religion"].ToString();
            }
            return ObjBELReligion;
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
    public string UpdateReligion(BELReligion ObjBELReligion)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_ReligionUpdate", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@ReligionId", ObjBELReligion.ReligionId);
            cmd.Parameters.AddWithValue("@Religion", ObjBELReligion.Religion);
            cmd.Parameters.AddWithValue("@UpdatedBy", ObjBELReligion.UpdatedBy);
            
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

    public string DeleteReligion(int ReligionId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_ReligionDelete", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@ReligionId", ReligionId);
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