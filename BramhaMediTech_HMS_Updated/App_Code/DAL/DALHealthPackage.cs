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
/// Summary description for DALHealthPackage
/// </summary>
public class DALHealthPackage
{
    BELHealthPackage objBELHPack = new BELHealthPackage();
	public DALHealthPackage()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public BELHealthPackage SelectOne(int HPackId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_HPackSelectOne", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@HPackId", HPackId);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                objBELHPack.HPackName = Convert.ToString(sdr["HPackName"]);
                objBELHPack.HPackDetails = Convert.ToString(sdr["HPackDetails"]);
                objBELHPack.HPackAmount = Convert.ToDecimal(sdr["HPackAmount"]);
                objBELHPack.FromDate = Convert.ToDateTime(sdr["FromDate"]);
                objBELHPack.ToDate = Convert.ToDateTime(sdr["ToDate"]);
                objBELHPack.IsIpd = Convert.ToBoolean(sdr["IsIpd"]);
                objBELHPack.IsOpd = Convert.ToBoolean(sdr["IsOpd"]);
                
                
            }
            return objBELHPack;
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
        SqlDataAdapter da = new SqlDataAdapter("Sp_HPackFillGrid", con);
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



    public string InsertHpack(BELHealthPackage objBELHPack)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_HPackInsert", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {
            cmd.Parameters.AddWithValue("@HPackName", objBELHPack.HPackName);
            cmd.Parameters.AddWithValue("@HPackAmount", objBELHPack.HPackAmount);
            cmd.Parameters.AddWithValue("@HPackDetails", objBELHPack.HPackDetails);
            cmd.Parameters.AddWithValue("@FromDate", objBELHPack.FromDate);
            cmd.Parameters.AddWithValue("@ToDate", objBELHPack.ToDate);
            cmd.Parameters.AddWithValue("@IsOpd", objBELHPack.IsOpd);
            cmd.Parameters.AddWithValue("@IsIpd", objBELHPack.IsIpd);
            cmd.Parameters.AddWithValue("@CreatedBy", objBELHPack.CreatedBy);
            cmd.Parameters.AddWithValue("@FId", objBELHPack.FId);
            cmd.Parameters.AddWithValue("@BranchId", objBELHPack.BranchId);

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


    public string UpdateHpack(BELHealthPackage objBELHPack)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_HPackUpdate", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {
            cmd.Parameters.AddWithValue("@HPackId", objBELHPack.HPackId);
            cmd.Parameters.AddWithValue("@HPackName", objBELHPack.HPackName);
            cmd.Parameters.AddWithValue("@HPackAmount", objBELHPack.HPackAmount);
            cmd.Parameters.AddWithValue("@HPackDetails", objBELHPack.HPackDetails);
            cmd.Parameters.AddWithValue("@FromDate", objBELHPack.FromDate);
            cmd.Parameters.AddWithValue("@ToDate", objBELHPack.ToDate);
            cmd.Parameters.AddWithValue("@IsOpd", objBELHPack.IsOpd);
            cmd.Parameters.AddWithValue("@IsIpd", objBELHPack.IsIpd);
            cmd.Parameters.AddWithValue("@UpdatedBy", objBELHPack.UpdatedBy);

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


    public string DeleteHPack(int HPackId)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_HPackDelete", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@HPackId", HPackId);
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


    public DataSet FillPackServiceGrid(int HPackId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd=new SqlCommand("Sp_HealthPackInfoFillGrid", con);
        cmd.CommandType=CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        cmd.Parameters.AddWithValue("@HPackId", HPackId);
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
    public DataSet FillBillServiceDrop()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("Sp_BillServiceFillCombo", con);
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
    public DataSet FillBillSubServiceDrop(int BillServiceId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_BillSubServiceFillCombo", con);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        cmd.Parameters.AddWithValue("@BillServiceId", BillServiceId);
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

    public string InsertHPackInfo(BELHealthPackage objBELHPack)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_HPackInfoInsert", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {
            cmd.Parameters.AddWithValue("@BillServiceId", objBELHPack.BillServiceId);
            cmd.Parameters.AddWithValue("@BillSubServiceId", objBELHPack.BillSubServiceId);
            cmd.Parameters.AddWithValue("@Qty", objBELHPack.Qty);
            cmd.Parameters.AddWithValue("@Amount", objBELHPack.Amount);
            cmd.Parameters.AddWithValue("@HPackId", objBELHPack.HPackId);            
            cmd.Parameters.AddWithValue("@CreatedBy", objBELHPack.CreatedBy);
            cmd.Parameters.AddWithValue("@FId", objBELHPack.FId);
            cmd.Parameters.AddWithValue("@BranchId", objBELHPack.BranchId);

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


    public string DeleteHPackInfo(int HPackId)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_HPackInfoDelete", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@HPackInfoId", HPackId);
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