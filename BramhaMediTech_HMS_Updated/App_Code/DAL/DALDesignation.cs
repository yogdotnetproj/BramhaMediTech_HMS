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
/// Summary description for DALDesignation
/// </summary>
public class DALDesignation
{
    BELDesignation objBELDesg = new BELDesignation();
	public DALDesignation()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    


    public DataSet FillGridDesg()
    {

        SqlConnection con = DataAccess.ConInitForDC();
        SqlDataAdapter da = new SqlDataAdapter("SP_DesgFillGrid", con);
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


    public BELDesignation SelectOneDesg(int DesignationId)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_DesgSelectOne", con);
        cmd.CommandType = CommandType.StoredProcedure;


        try
        {
            cmd.Parameters.AddWithValue("@DesignationId", DesignationId);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                objBELDesg.DesignationId = Convert.ToInt32(sdr["DesignationId"]);
                objBELDesg.Designation = Convert.ToString(sdr["Designation"]);
                


            }
            return objBELDesg;
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


    public string UpdateDesg(BELDesignation objBELDesg)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_DesgUpdate", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {
            cmd.Parameters.AddWithValue("@DesignationId", objBELDesg.DesignationId);
            cmd.Parameters.AddWithValue("@Designation", objBELDesg.Designation);            
            cmd.Parameters.AddWithValue("@UpdatedBy", objBELDesg.UpdatedBy);

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

    public string InsertDesg(BELDesignation objBELDesg)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_DesgInsert", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {

            cmd.Parameters.AddWithValue("@FId", objBELDesg.FId);
            cmd.Parameters.AddWithValue("@BranchId", objBELDesg.BranchId);
            cmd.Parameters.AddWithValue("@Designation", objBELDesg.Designation);
            cmd.Parameters.AddWithValue("@CreatedBy", objBELDesg.CreatedBy);

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

    public string DeleteDesg(int DesignationId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_DesgDelete", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@DesignationId",DesignationId);
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