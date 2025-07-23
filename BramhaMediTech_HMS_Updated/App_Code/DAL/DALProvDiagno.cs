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
/// Summary description for DALProvDiagno
/// </summary>
public class DALProvDiagno
{
    BELProvDiagno objBELProvDiagno = new BELProvDiagno();
	public DALProvDiagno()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataSet FillGridProvDiagno()
    {

        SqlConnection con = DataAccess.ConInitForDC();
        SqlDataAdapter da = new SqlDataAdapter("SP_ProvDiagnoFillGrid", con);
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


    public BELProvDiagno SelectOneProvDiagno(int ProvDiagnoId)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_ProvDiagnoSelectOne", con);
        cmd.CommandType = CommandType.StoredProcedure;


        try
        {
            cmd.Parameters.AddWithValue("@ProvDiagnoId", ProvDiagnoId);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                objBELProvDiagno.ProvDiagnoId = Convert.ToInt32(sdr["ProvDiagnoId"]);
                objBELProvDiagno.ProvDiagno = Convert.ToString(sdr["ProvDiagno"]);



            }
            return objBELProvDiagno;
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


    public string UpdateProvDiagno(BELProvDiagno objBELProvDiagno)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_ProvDiagnoUpdate", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {
            cmd.Parameters.AddWithValue("@ProvDiagnoId", objBELProvDiagno.ProvDiagnoId);
            cmd.Parameters.AddWithValue("@ProvDiagno", objBELProvDiagno.ProvDiagno);
            cmd.Parameters.AddWithValue("@UpdatedBy", objBELProvDiagno.UpdatedBy);

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

    public string InsertProvDiagno(BELProvDiagno objBELProvDiagno)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_ProvDiagnoInsert", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {

            cmd.Parameters.AddWithValue("@FId", objBELProvDiagno.FId);
            cmd.Parameters.AddWithValue("@BranchId", objBELProvDiagno.BranchId);
            cmd.Parameters.AddWithValue("@ProvDiagno", objBELProvDiagno.ProvDiagno);
            cmd.Parameters.AddWithValue("@CreatedBy", objBELProvDiagno.CreatedBy);

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

    public string DeleteProvDiagno(int ProvDiagnoId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_ProvDiagnoDelete", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@ProvDiagnoId", ProvDiagnoId);
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