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
/// Summary description for DALBillService
/// </summary>
public class DALBillService
{
    BELBillService objBELService = new BELBillService();
	public DALBillService()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public BELBillService SelectOne(int BillServiceId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_BillServiceSelectOne", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@BillServiceId", BillServiceId);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                objBELService.ServiceName = Convert.ToString(sdr["ServiceName"]);
                objBELService.BillGroupId = Convert.ToInt32(sdr["BillGroupId"]);
                objBELService.ServiceOrder = Convert.ToInt32(sdr["ServiceOrder"]);
                objBELService.IsIpd = Convert.ToBoolean(sdr["IsIpd"]);
                objBELService.IsOpd = Convert.ToBoolean(sdr["IsOpd"]);
                if (sdr["UnitOfCharges"] != DBNull.Value)
                    objBELService.UnitOfCharges = Convert.ToString(sdr["UnitOfCharges"]);
                else
                    objBELService.UnitOfCharges = "0";
                if (sdr["IsDirect"] != DBNull.Value)
                    objBELService.IsDirect = Convert.ToBoolean(sdr["IsDirect"]);
                else
                    objBELService.IsDirect = false;
                if (sdr["IsActive"] != DBNull.Value)
                    objBELService.IsActive = Convert.ToBoolean(sdr["IsActive"]);
                else
                    objBELService.IsActive = false;
               // objBELService.IsConsultantDocwise = Convert.ToBoolean(sdr["IsConsultantDocwise"]);
                objBELService.Isdoc = Convert.ToBoolean(sdr["Isdoc"]);
                objBELService.IsRoomwise = Convert.ToBoolean(sdr["IsRoomwise"]);
                //objBELService.IsDrvisible = Convert.ToBoolean(sdr["IsDrvisible"]);
                //objBELService.IsDaily = Convert.ToBoolean(sdr["IsDaily"]);
                objBELService.RoomType = Convert.ToString(sdr["RoomType"]);

            }
            return objBELService;
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
        SqlDataAdapter da = new SqlDataAdapter("Sp_BillServiceFillGrid", con);
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
    public DataSet FillSearchGrid(BELBillService objBELService)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_BillServiceSearch", con);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        con.Open();
        try
        {
            cmd.Parameters.AddWithValue("@ServiceName", objBELService.ServiceName);
            cmd.Parameters.AddWithValue("@BillGroupId", objBELService.BillGroupId);
            cmd.Parameters.AddWithValue("@FId", objBELService.FId);
            cmd.Parameters.AddWithValue("@BranchId", objBELService.BranchId);
      
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


    public string InsertBillService(BELBillService objBELService)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_BillServiceInsert", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {

         

            cmd.Parameters.AddWithValue("@ServiceName", objBELService.ServiceName);
            cmd.Parameters.AddWithValue("@ServiceOrder", objBELService.ServiceOrder);
            cmd.Parameters.AddWithValue("@BillGroupid", objBELService.BillGroupId);
            cmd.Parameters.AddWithValue("@UnitOfCharges", objBELService.UnitOfCharges);
            cmd.Parameters.AddWithValue("@IsOpd", objBELService.IsOpd);
            cmd.Parameters.AddWithValue("@IsIpd", objBELService.IsIpd);
            cmd.Parameters.AddWithValue("@IsDirect", objBELService.IsDirect);
            cmd.Parameters.AddWithValue("@Isdoc", objBELService.Isdoc);
            cmd.Parameters.AddWithValue("@IsRoomwise", objBELService.IsRoomwise);
            cmd.Parameters.AddWithValue("@CreatedBy", objBELService.CreatedBy);
            cmd.Parameters.AddWithValue("@FId", objBELService.FId);
            cmd.Parameters.AddWithValue("@BranchId", objBELService.BranchId);
            cmd.Parameters.AddWithValue("@IsActive", objBELService.IsActive);
            cmd.Parameters.AddWithValue("@ISIPDDaily", objBELService.IPDDaily);
            cmd.Parameters.AddWithValue("@DailyServiceName", objBELService.DailyServiceName);
            cmd.Parameters.AddWithValue("@RoomType", objBELService.RoomType);

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


    public string UpdateBillService(BELBillService objBELService)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_BillServiceUpdate", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {
            cmd.Parameters.AddWithValue("@BillServiceId", objBELService.BillServiceId);
            cmd.Parameters.AddWithValue("@ServiceName", objBELService.ServiceName);
            cmd.Parameters.AddWithValue("@ServiceOrder", objBELService.ServiceOrder);
            cmd.Parameters.AddWithValue("@BillGroupid", objBELService.BillGroupId);
            cmd.Parameters.AddWithValue("@UnitOfCharges", objBELService.UnitOfCharges);
            cmd.Parameters.AddWithValue("@IsOpd", objBELService.IsOpd);
            cmd.Parameters.AddWithValue("@IsIpd", objBELService.IsIpd);
            cmd.Parameters.AddWithValue("@IsDirect", objBELService.IsDirect);
            cmd.Parameters.AddWithValue("@IsActive", objBELService.IsActive);
            cmd.Parameters.AddWithValue("@Isdoc", objBELService.Isdoc);
            cmd.Parameters.AddWithValue("@IsRoomwise", objBELService.IsRoomwise);
            cmd.Parameters.AddWithValue("@UpdatedBy", objBELService.UpdatedBy);
            cmd.Parameters.AddWithValue("@ISIPDDaily", objBELService.IPDDaily);
            cmd.Parameters.AddWithValue("@DailyServiceName", objBELService.DailyServiceName);
            cmd.Parameters.AddWithValue("@RoomType", objBELService.RoomType);

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


    public string DeleteBillService(int BillServiceId)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_BillServiceDelete", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@BillServiceId", BillServiceId);
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

    public BELBillService GetMaxOrderNo()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetMaxOrderNoForBillService", con);
        cmd.CommandType = CommandType.StoredProcedure;
       
        try
        {
            objBELService.ServiceOrder = Convert.ToInt32(cmd.ExecuteScalar());
            return objBELService;
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

   
    public DataSet FillBillGroupDrop()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("Sp_BillGroupFillDrop", con);
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
  

    public DataTable CheckIsBillGroupDaily(string id)
    {
        DataTable dt = new DataTable();

        using (SqlConnection con = DataAccess.ConInitForDC())
        {
            using (SqlCommand cmd = new SqlCommand("Sp_IsBillGroupDaily", con))
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



    public DataTable CheckBillServiceIsInUse(string id)
    {
        DataTable dt = new DataTable();

        using (SqlConnection con = DataAccess.ConInitForDC())
        {
            using (SqlCommand cmd = new SqlCommand("Sp_CheckBillServiceIsInUse", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BillServiceId", id);
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