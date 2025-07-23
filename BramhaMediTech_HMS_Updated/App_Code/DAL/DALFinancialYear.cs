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

public class DALFinancialYear
{
    BELFinancialYear objBELFinancialYear = new BELFinancialYear();
	public DALFinancialYear()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    

    public DataSet FillGridFinancialYear()
    {

        SqlConnection con = DataAccess.ConInitForDC();
        SqlDataAdapter da = new SqlDataAdapter("SP_FinancialYearFillGrid", con);
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


    public  BELFinancialYear SelectOneFinancialYear(int FinancialYearId)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_FinancialYearSelectOne", con);
        cmd.CommandType = CommandType.StoredProcedure;


        try
        {
            cmd.Parameters.AddWithValue("@FinancialYearId", FinancialYearId);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                objBELFinancialYear.FinancialYearId = Convert.ToInt32(sdr["FinancialYearId"]);
                objBELFinancialYear.FinancialYear = Convert.ToString(sdr["FinancialYear"]);
                objBELFinancialYear.StartDate = Convert.ToDateTime(sdr["StartDate"]);
                objBELFinancialYear.EndDate = Convert.ToDateTime(sdr["EndDate"]);
         

            }
            return objBELFinancialYear;
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


    public string UpdateFinancialYear( BELFinancialYear objBELFinancialYear )
    {

        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("SP_FinancialYearUpdate", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {
            cmd.Parameters.AddWithValue("@FinancialYearId", objBELFinancialYear.FinancialYearId);
            cmd.Parameters.AddWithValue("@FinancialYear", objBELFinancialYear.FinancialYear);
            cmd.Parameters.AddWithValue("@StartDate", objBELFinancialYear.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", objBELFinancialYear.EndDate);
            cmd.Parameters.AddWithValue("@UpdatedBy", objBELFinancialYear.UpdatedBy);

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

    public string InsertFinancialYear(BELFinancialYear objBELFinancialYear)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("SP_FinancialYear_Insert", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {
            cmd.Parameters.AddWithValue("@FinancialYear", objBELFinancialYear.FinancialYear);
            cmd.Parameters.AddWithValue("@StartDate", objBELFinancialYear.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", objBELFinancialYear.EndDate);
            cmd.Parameters.AddWithValue("@CreatedBy", objBELFinancialYear.CreatedBy);
            cmd.Parameters.AddWithValue("@BranchId", objBELFinancialYear.BranchId);

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

    public string DeleteFinancialYear(int FinancialYearId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_FinancialYearDelete", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@FinancialYearId",FinancialYearId);
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