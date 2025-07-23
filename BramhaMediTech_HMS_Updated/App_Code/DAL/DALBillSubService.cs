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
/// Summary description for DALBillSubService
/// </summary>
public class DALBillSubService
{
    BELBillSubService objBELSubService = new BELBillSubService();
	public DALBillSubService()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public BELBillSubService SelectOne(int BillSubServiceId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_BillSubServiceSelectOne", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@BillSubServiceId", BillSubServiceId);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                objBELSubService.ServiceDetails = Convert.ToString(sdr["ServiceDetails"]);
                objBELSubService.BillServiceId = Convert.ToInt32(sdr["BillServiceId"]);
                objBELSubService.ServiceOrder = Convert.ToInt32(sdr["ServiceOrder"]);
               

            }
            return objBELSubService;
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




    public DataSet FillGrid(int BillServiceId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd=new SqlCommand("Sp_BillSubServiceFillGrid", con);
        cmd.CommandType=CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@BillServiceId", BillServiceId);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
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
    public DataSet FillSearchGrid(BELBillSubService objBELSubService)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_BillSubServiceSearch", con);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        con.Open();
        try
        {
            cmd.Parameters.AddWithValue("@ServiceDetails", objBELSubService.ServiceDetails);
            cmd.Parameters.AddWithValue("@BillSubServiceId", objBELSubService.BillSubServiceId);
            cmd.Parameters.AddWithValue("@ServiceOrder", objBELSubService.ServiceOrder);

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


    public string InsertBillSubService(BELBillSubService objBELSubService)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_BillSubServiceInsert", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {

            cmd.Parameters.AddWithValue("@ServiceDetails", objBELSubService.ServiceDetails);
            cmd.Parameters.AddWithValue("@BillServiceId", objBELSubService.BillServiceId);
            cmd.Parameters.AddWithValue("@ServiceOrder", objBELSubService.ServiceOrder);
            cmd.Parameters.AddWithValue("@CreatedBy", objBELSubService.CreatedBy);
            cmd.Parameters.AddWithValue("@FId", objBELSubService.FId);
            cmd.Parameters.AddWithValue("@BranchId", objBELSubService.BranchId);

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


    public string UpdateBillSubService(BELBillSubService objBELSubService)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_BillSubServiceUpdate", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {
            cmd.Parameters.AddWithValue("@BillServiceId", objBELSubService.BillServiceId);
            cmd.Parameters.AddWithValue("@ServiceDetails", objBELSubService.ServiceDetails);
            cmd.Parameters.AddWithValue("@BillSubServiceId", objBELSubService.BillSubServiceId);
            cmd.Parameters.AddWithValue("@UpdatedBy", objBELSubService.UpdatedBy);

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


    public string DeleteBillSubService(int BillSubServiceId)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_BillSubServiceDelete", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@BillSubServiceId", BillSubServiceId);
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

}