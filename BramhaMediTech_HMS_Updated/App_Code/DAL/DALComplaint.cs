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
/// Summary description for DALComplaint
/// </summary>
public class DALComplaint
{
    BELComplaint objBELComplaint = new BELComplaint();
	public DALComplaint()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataSet FillGridComplaint()
    {

        SqlConnection con = DataAccess.ConInitForDC();
        SqlDataAdapter da = new SqlDataAdapter("SP_ComplaintFillGrid", con);
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


    public BELComplaint SelectOneComplaint(int PatComplaintId)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_ComplaintSelectOne", con);
        cmd.CommandType = CommandType.StoredProcedure;


        try
        {
            cmd.Parameters.AddWithValue("@PatComplaintId", PatComplaintId);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                objBELComplaint.PatComplaintId = Convert.ToInt32(sdr["PatComplaintId"]);
                objBELComplaint.PatComplaint = Convert.ToString(sdr["PatComplaint"]);



            }
            return objBELComplaint;
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


    public string UpdateComplaint(BELComplaint objBELComplaint)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_ComplaintUpdate", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {
            cmd.Parameters.AddWithValue("@PatComplaintId", objBELComplaint.PatComplaintId);
            cmd.Parameters.AddWithValue("@PatComplaint", objBELComplaint.PatComplaint);
            cmd.Parameters.AddWithValue("@UpdatedBy", objBELComplaint.UpdatedBy);

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

    public string InsertComplaint(BELComplaint objBELComplaint)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_ComplaintInsert", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {

            cmd.Parameters.AddWithValue("@FId", objBELComplaint.FId);
            cmd.Parameters.AddWithValue("@BranchId", objBELComplaint.BranchId);
            cmd.Parameters.AddWithValue("@PatComplaint", objBELComplaint.PatComplaint);
            cmd.Parameters.AddWithValue("@CreatedBy", objBELComplaint.CreatedBy);

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

    public string DeleteComplaint(int PatComplaintId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_ComplaintDelete", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@PatComplaintId", PatComplaintId);
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