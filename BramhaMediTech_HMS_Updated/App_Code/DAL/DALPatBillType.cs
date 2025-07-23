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
/// Summary description for DALPatBillType
/// </summary>
public class DALPatBillType
{
    BELPatBillType objBELBillType = new BELPatBillType();
	public DALPatBillType()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public BELPatBillType SelectOne(int BillGroupId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_BillTypeSelectOne", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@BillTypeId", BillGroupId);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                objBELBillType.BillType = Convert.ToString(sdr["BillType"]);
                objBELBillType.BillTypeId = Convert.ToInt32(sdr["BillTypeId"]);


            }
            return objBELBillType;
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
        SqlDataAdapter da = new SqlDataAdapter("Sp_BillTypeFillGrid", con);
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

    public string InsertBillType(BELPatBillType objBELBillType)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_BillTypeInsert", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {

            cmd.Parameters.AddWithValue("@BillType", objBELBillType.BillType);

            cmd.Parameters.AddWithValue("@CreatedBy", objBELBillType.CreatedBy);
            cmd.Parameters.AddWithValue("@FId", objBELBillType.FId);
            cmd.Parameters.AddWithValue("@BranchId", objBELBillType.BranchId);

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

    public string UpdateBillType(BELPatBillType objBELBillType)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_BillTypeUpdate", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {
            cmd.Parameters.AddWithValue("@BillTypeId", objBELBillType.BillTypeId);
            cmd.Parameters.AddWithValue("@BillType", objBELBillType.BillType);           
            cmd.Parameters.AddWithValue("@UpdatedBy", objBELBillType.UpdatedBy);

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

    public string DeleteBillType(int BillTypeId)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_BillTypeDelete", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@BillTypeId", BillTypeId);
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