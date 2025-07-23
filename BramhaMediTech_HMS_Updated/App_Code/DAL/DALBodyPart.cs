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
/// Summary description for DALBodyPart
/// </summary>
public class DALBodyPart
{
    BELBodyPart objBELBodyPart = new BELBodyPart();
	public DALBodyPart()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataSet FillGridBodyPart()
    {

        SqlConnection con = DataAccess.ConInitForDC();
        SqlDataAdapter da = new SqlDataAdapter("Sp_SpecimenFillGrid", con);
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


    public BELBodyPart SelectOneBodyPart(int SpecimenId)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_SpecimenSelectOne", con);
        cmd.CommandType = CommandType.StoredProcedure;


        try
        {
            cmd.Parameters.AddWithValue("@SpecimenId", SpecimenId);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {

                objBELBodyPart.SpecimenId = Convert.ToInt32(sdr["SpecimenId"]);
                objBELBodyPart.SpecimenName = Convert.ToString(sdr["SpecimenName"]);



            }
            return objBELBodyPart;
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


    public string UpdateBodyPart(BELBodyPart objBELBodyPart)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_SpecimenUpdate", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {
            cmd.Parameters.AddWithValue("@SpecimenId", objBELBodyPart.SpecimenId);
            cmd.Parameters.AddWithValue("@SpecimenName", objBELBodyPart.SpecimenName);
            cmd.Parameters.AddWithValue("@UpdatedBy", objBELBodyPart.UpdatedBy);

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

    public string InsertBodyPart(BELBodyPart objBELBodyPart)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_SpecimenInsert", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {

            cmd.Parameters.AddWithValue("@FId", objBELBodyPart.FId);
            cmd.Parameters.AddWithValue("@BranchId", objBELBodyPart.BranchId);
            cmd.Parameters.AddWithValue("@SpecimenName", objBELBodyPart.SpecimenName);
            cmd.Parameters.AddWithValue("@CreatedBy", objBELBodyPart.CreatedBy);

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

    public string DeleteBodyPart(int SpecimenId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_SpecimenDelete", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@SpecimenId", SpecimenId);
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