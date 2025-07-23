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
/// Summary description for DALRoom
/// </summary>
public class DALRoom
{
    BELRoom objBELRoom = new BELRoom();
	public DALRoom()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    //______________________________________ RoomType___________________________________________________

    public DataSet FillGrid_SupplierMaster()
    {

        SqlConnection con = DataAccess.ConInitForDC();
        SqlDataAdapter da = new SqlDataAdapter("Sp_FillGridSupplier", con);
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

    public string Insert_Supplier(BELRoom objBELRoom)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_Insert_SupplierMaster", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {

            cmd.Parameters.AddWithValue("@SupName", objBELRoom.RType);

           

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
    public string Update_Supplier(BELRoom objBELRoom)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_Update_Supplier", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {
            cmd.Parameters.AddWithValue("@Suppid", objBELRoom.RTypeId);
            cmd.Parameters.AddWithValue("@SupName", objBELRoom.RType);
           

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

    public BELRoom Select_SupplierMaster(int Suppid)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_SelectSupplier", con);
        cmd.CommandType = CommandType.StoredProcedure;


        try
        {
            cmd.Parameters.AddWithValue("@Suppid", Suppid);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                objBELRoom.RTypeId = Convert.ToInt32(sdr["Suppid"]);
                objBELRoom.RType = Convert.ToString(sdr["SupName"]);



            }
            return objBELRoom;
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
    public DataSet FillGridRoomType()
    {

        SqlConnection con = DataAccess.ConInitForDC();
        SqlDataAdapter da = new SqlDataAdapter("SP_RoomTypeFillGrid", con);
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


    public BELRoom SelectOneRoomType(int RTypeId)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_RoomTypeSelectOne", con);
        cmd.CommandType = CommandType.StoredProcedure;


        try
        {
            cmd.Parameters.AddWithValue("@RTypeId", RTypeId);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                objBELRoom.RTypeId = Convert.ToInt32(sdr["RTypeId"]);
                objBELRoom.RType = Convert.ToString(sdr["RType"]);



            }
            return objBELRoom;
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

    public string UpdateRoomType(BELRoom objBELRoom)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_RoomTypeUpdate", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {
            cmd.Parameters.AddWithValue("@RTypeId", objBELRoom.RTypeId);
            cmd.Parameters.AddWithValue("@RType", objBELRoom.RType);
            cmd.Parameters.AddWithValue("@UpdatedBy", objBELRoom.UpdatedBy);

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

    public string InsertRoomType(BELRoom objBELRoom)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_RoomTypeInsert", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {

            cmd.Parameters.AddWithValue("@RType", objBELRoom.RType);

            cmd.Parameters.AddWithValue("@FId", objBELRoom.FId);
            cmd.Parameters.AddWithValue("@BranchId", objBELRoom.BranchId);

            cmd.Parameters.AddWithValue("@CreatedBy", objBELRoom.CreatedBy);

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

    public string DeleteRoomType(int RTypeId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_RoomTypeDelete", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@RTypeId", RTypeId);
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

//________________________________________________________RoomMaster__________________________________________

    public DataSet FillGridRoomMaster()
    {

        SqlConnection con = DataAccess.ConInitForDC();
        SqlDataAdapter da = new SqlDataAdapter("SP_RoomMasterFillGrid", con);
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
    public DataSet FillRoomTypeCombo()
    {

        SqlConnection con = DataAccess.ConInitForDC();
        SqlDataAdapter da = new SqlDataAdapter("Sp_RoomTypeFillDrop", con);
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

    public BELRoom SelectOneRoomMaster(int RoomId)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_RoomMaster_SelectOne", con);
        cmd.CommandType = CommandType.StoredProcedure;


        try
        {
            cmd.Parameters.AddWithValue("@RoomId", RoomId);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                objBELRoom.RoomId = Convert.ToInt32(sdr["RoomId"]);
                objBELRoom.RoomName = Convert.ToString(sdr["RoomName"]);
                objBELRoom.RoomAddress = Convert.ToString(sdr["RoomAddress"]);
                objBELRoom.RTypeId = Convert.ToInt32(sdr["RTypeId"]);
                objBELRoom.TotalBed = Convert.ToInt32(sdr["TotalBeds"]);
            }
            return objBELRoom;
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

    public string UpdateRoomMaster(BELRoom objBELRoom)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_RoomMasterUpdate", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {
            cmd.Parameters.AddWithValue("@RoomId", objBELRoom.RoomId);
            cmd.Parameters.AddWithValue("@TotalBed", objBELRoom.TotalBed);
            cmd.Parameters.AddWithValue("@RoomName", objBELRoom.RoomName);
            cmd.Parameters.AddWithValue("@RoomAddress", objBELRoom.RoomAddress);
            cmd.Parameters.AddWithValue("@RTypeId", objBELRoom.RTypeId);
            cmd.Parameters.AddWithValue("@UpdatedBy", objBELRoom.UpdatedBy);

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

    public string InsertRoomMaster(BELRoom objBELRoom)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_RoomMasterInsert", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {

            cmd.Parameters.AddWithValue("@RoomName", objBELRoom.RoomName);
            cmd.Parameters.AddWithValue("@TotalBed", objBELRoom.TotalBed);
            cmd.Parameters.AddWithValue("@RTypeId", objBELRoom.RTypeId);
            cmd.Parameters.AddWithValue("@FId", objBELRoom.FId);
            cmd.Parameters.AddWithValue("@BranchId", objBELRoom.BranchId);
            cmd.Parameters.AddWithValue("@RoomAddress", objBELRoom.RoomAddress);
            cmd.Parameters.AddWithValue("@CreatedBy", objBELRoom.CreatedBy);

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

    public string DeleteRoomMaster(int RoomId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_RoomMasterDelete", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@RoomId", RoomId);
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
    public BELRoom SelectBed(int RoomId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_BedMasterSelectBed", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@RoomId", RoomId);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                objBELRoom.BedId = Convert.ToInt32(sdr["BedId"]);

            }
            return objBELRoom;
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

 //__________________________________________BedMaster_______________________________________________________

    public DataSet FillGridBedMaster(int RoomId,int FId,int BranchId)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_BedMasterFillGrid", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@RoomId", RoomId);
        cmd.Parameters.AddWithValue("@FId", FId);
        cmd.Parameters.AddWithValue("@BranchId", BranchId);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
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
    public DataSet FillRoomAddressCombo()
    {

        SqlConnection con = DataAccess.ConInitForDC();
        SqlDataAdapter da = new SqlDataAdapter("Sp_RoomAddressFillDrop", con);
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
    public DataSet FillRoomNameCombo(string RoomAddress )
    {

        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("SP_RoomMasterFillCombo_ByRoomAddress", con);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        con.Open();
        try
        {
            cmd.Parameters.AddWithValue("@RoomAddress", RoomAddress);
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

    public BELRoom GetRoomInformation(int RoomId,int FId, int BranchId)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetRoomInformation", con);
        cmd.CommandType = CommandType.StoredProcedure;


        try
        {
            cmd.Parameters.AddWithValue("@RoomId", RoomId);
            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                objBELRoom.RoomId = Convert.ToInt32(sdr["RoomId"]);
                objBELRoom.RType = Convert.ToString(sdr["RType"]);
                objBELRoom.TotalBed = Convert.ToInt32(sdr["TotalBeds"]);
            }
            return objBELRoom;
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


    public BELRoom SelectOneBedMaster(int BedId)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_BedMasterSelectOne", con);
        cmd.CommandType = CommandType.StoredProcedure;


        try
        {
            cmd.Parameters.AddWithValue("@BedId", BedId);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                objBELRoom.RoomId = Convert.ToInt32(sdr["RoomId"]);
                //objBELRoom.RoomName = Convert.ToString(sdr["RoomName"]);
                objBELRoom.RoomAddress = Convert.ToString(sdr["RoomAddress"]);
                objBELRoom.BedNo = Convert.ToString(sdr["BedNo"]);
                //objBELRoom.RTypeId = Convert.ToInt32(sdr["RTypeId"]);




            }
            return objBELRoom;
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

    public string UpdateBedMaster(BELRoom objBELRoom)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_BedMasterUpdate", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {
            cmd.Parameters.AddWithValue("@BedId", objBELRoom.BedId);
            cmd.Parameters.AddWithValue("@BedNo", objBELRoom.BedNo);
            //cmd.Parameters.AddWithValue("@FId", objBELRoom.FId);
           // cmd.Parameters.AddWithValue("@BranchId", objBELRoom.BranchId);
           // cmd.Parameters.AddWithValue("@RoomId", objBELRoom.RoomId);
           // cmd.Parameters.AddWithValue("@RoomAddress", objBELRoom.RoomAddress);
            cmd.Parameters.AddWithValue("@UpdatedBy", objBELRoom.UpdatedBy);

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

    public string InsertBedMaster(BELRoom objBELRoom)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_BedMasterInsert", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {

            cmd.Parameters.AddWithValue("@BedNo", objBELRoom.BedNo);
            cmd.Parameters.AddWithValue("@RoomId", objBELRoom.RoomId);
            cmd.Parameters.AddWithValue("@FId", objBELRoom.FId);
            cmd.Parameters.AddWithValue("@BranchId", objBELRoom.BranchId);
            cmd.Parameters.AddWithValue("@RoomAddress", objBELRoom.RoomAddress);
            cmd.Parameters.AddWithValue("@CreatedBy", objBELRoom.CreatedBy);

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

    public string DeleteBedMaster(int BedId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_BedMasterDelete", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@BedId", BedId);
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

    public DataSet FillRoomStatusGrid(int RoomTypeId)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_FillRoomStatusGrid", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@RoomTypeId", RoomTypeId);
        
        SqlDataAdapter da = new SqlDataAdapter(cmd);
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
    public DataSet FillBedDetailsGrid(int RoomId)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_BedDetailsFillGrid", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@RoomId", RoomId);

        SqlDataAdapter da = new SqlDataAdapter(cmd);
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
}