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
/// Summary description for DALBillGroup
/// </summary>
public class DALBillGroup
{
    BELBillGroup objBELBillGroup = new BELBillGroup();
	public DALBillGroup()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public BELBillGroup SelectOne(int BillGroupId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_BillGroupSelectOne", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@BillGroupId", BillGroupId);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
               
                objBELBillGroup.GroupName = Convert.ToString(sdr["GroupName"]);
                objBELBillGroup.GroupOrderNo = Convert.ToInt32(sdr["GroupOrderNo"]);
                objBELBillGroup.BillGroupId = Convert.ToInt32(sdr["BillGroupId"]);
                objBELBillGroup.GroupType = Convert.ToInt32(sdr["GroupType"]);
                objBELBillGroup.DailyService = Convert.ToBoolean(sdr["DailyService"]);

            }
            return objBELBillGroup;
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
    public BELBillGroup GetMaxOrderNoForBillGroup()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetMaxOrderNoForBillGroup", con);
        cmd.CommandType = CommandType.StoredProcedure;

        try
        {
            objBELBillGroup.GroupOrderNo = Convert.ToInt32(cmd.ExecuteScalar());
            return objBELBillGroup;
        }
        catch (SqlException)
        {
            throw;
        }
        finally
        {
            con.Close(); con.Dispose();
        }
    }

    public DataSet FillGrid()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();        
        SqlDataAdapter da = new SqlDataAdapter("Sp_BillGroupFillGrid", con);
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
    
    public string InsertBillGroup(BELBillGroup objBELBillGroup)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_BillGroupInsert", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {           

            cmd.Parameters.AddWithValue("@GroupName", objBELBillGroup.GroupName);
            cmd.Parameters.AddWithValue("@GroupOrderNo", objBELBillGroup.GroupOrderNo);
            cmd.Parameters.AddWithValue("@CreatedBy", objBELBillGroup.CreatedBy);
            cmd.Parameters.AddWithValue("@FId", objBELBillGroup.FId);
            cmd.Parameters.AddWithValue("@BranchId", objBELBillGroup.BranchId);
            cmd.Parameters.AddWithValue("@GroupType", objBELBillGroup.GroupType);
            cmd.Parameters.AddWithValue("@DailyService", objBELBillGroup.DailyService);

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


    public string UpdateBillGroup(BELBillGroup objBELBillGroup)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_BillGroupUpdate", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {
            
            cmd.Parameters.AddWithValue("@BillGroupId", objBELBillGroup.BillGroupId);
            cmd.Parameters.AddWithValue("@GroupName", objBELBillGroup.GroupName);
            cmd.Parameters.AddWithValue("@GroupOrderNo", objBELBillGroup.GroupOrderNo);
            cmd.Parameters.AddWithValue("@UpdatedBy", objBELBillGroup.UpdatedBy);
            cmd.Parameters.AddWithValue("@GroupType", objBELBillGroup.GroupType);
            cmd.Parameters.AddWithValue("@DailyService", objBELBillGroup.DailyService);

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


    public string DeleteBillGroup(int BillGroupId)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_BillGroupDelete", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@BillGroupId", BillGroupId);
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

    public int GetMaxOrderNo(int BillServiceId)
    {
        int OrderNo;
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetMaxOrderNoForBillSubService", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@BillServiceId", BillServiceId);
        try
        {
            object obj = cmd.ExecuteScalar();
            if (obj == DBNull.Value)
                OrderNo = 1;
            else
                OrderNo = Convert.ToInt32(obj) + 1;
            con.Close();
            con.Dispose();
            return OrderNo;
        }
        catch (SqlException)
        {
            throw;
        }
        finally
        {
            con.Close(); con.Dispose();
        }
    }
    public DataTable CheckGroupIsInUse(string id)
    {
        DataTable dt = new DataTable();

        using (SqlConnection con = DataAccess.ConInitForDC())
        {
            using (SqlCommand cmd = new SqlCommand("Sp_CheckBillGroupIsInUse", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BillGroupId", id);
                con.Open();

                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(dt);
                }

                con.Close();
                con.Dispose();
            }
        }
        return dt;
    }

}