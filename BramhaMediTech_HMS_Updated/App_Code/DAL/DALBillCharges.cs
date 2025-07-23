using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// Summary description for DALBillCharges
/// </summary>
public class DALBillCharges
{
    BELBillCharges objBELBillCharges = new BELBillCharges();
    
    //Database objDatabase = DatabaseFactory.CreateDatabase();
	public DALBillCharges()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private int _Branchid; public int Branchid { get { return _Branchid; } set { _Branchid = value; } }
    private bool _IsRoomCharges; public bool IsRoomCharges { get { return _IsRoomCharges; } set { _IsRoomCharges = value; } }
    

    public DataSet FillPatientcategory()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("SP_getpatientCategory", con);
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
        }
        return ds;
    }

    public DataSet FillBillServiceDrop(string PatType)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_BillGroup", con);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        cmd.Parameters.AddWithValue("@PatType", PatType);
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
        }
        return ds;
    }
    public DataSet FillBillServicesbyGroup(string ServiceType,int PatientType,int FId,int BranchId,int BillGroupId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_BillServicesByGroup", con);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        cmd.Parameters.AddWithValue("@ServiceType", ServiceType);
        cmd.Parameters.AddWithValue("@PatientType", PatientType);
        cmd.Parameters.AddWithValue("@FId", FId);
        cmd.Parameters.AddWithValue("@BranchId", BranchId);
        cmd.Parameters.AddWithValue("@BillGroupid", BillGroupId);

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
        }
        return ds;
    }

    public DataSet FillBillServices(string ServiceType, int PatientType, int FId, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_BillServices", con);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        cmd.Parameters.AddWithValue("@ServiceType", ServiceType);
        cmd.Parameters.AddWithValue("@PatientType", PatientType);
        cmd.Parameters.AddWithValue("@FId", FId);
        cmd.Parameters.AddWithValue("@BranchId", BranchId);
       // cmd.Parameters.AddWithValue("@BillGroupid", BillGroupId);

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
        }
        return ds;
    }

    public DataSet FillRateTypeDrop()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("Sp_RateTypeFillCombo", con);
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
        }
        return ds;
    }

    public BELBillCharges SelectOne(double BillChargeId)
    {
        BELBillCharges objBELBillCharges = new BELBillCharges();
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_BillCharges_SelectOne", con);
        cmd.CommandType = CommandType.StoredProcedure;    
        
        cmd.Parameters.AddWithValue("@BillChargeId", BillChargeId);
        SqlDataReader reader = cmd.ExecuteReader();
        
        if (reader.Read())
        {
            objBELBillCharges.BillChargeId = Convert.ToDouble(reader["BillChargeId"]);
            objBELBillCharges.BillGroupId = Convert.ToInt32(reader["BillGroupId"]);
            objBELBillCharges.BillServiceId = Convert.ToInt32(reader["BillParticularId"]);
            objBELBillCharges.RateTypeId = Convert.ToInt32(reader["RateTypeId"]);
            objBELBillCharges.PatientTypeId = Convert.ToInt32(reader["PatientTypeId"]);
            objBELBillCharges.DoctorId = Convert.ToInt32(reader["DoctorId"]);
            objBELBillCharges.OperationId = Convert.ToInt32(reader["OperationId"]);
            objBELBillCharges.OperationTheatreId = Convert.ToInt32(reader["OperationTheatreId"]);
            objBELBillCharges.RoomCategoryId = Convert.ToInt32(reader["RoomCategoryId"]);
            objBELBillCharges.LabTestId = Convert.ToInt32(reader["LabTestId"]);
            objBELBillCharges.FromKM = Convert.ToInt32(reader["FromKM"]);
            objBELBillCharges.ToKM = Convert.ToInt32(reader["ToKM"]);
            objBELBillCharges.Rate = Convert.ToInt32(reader["Rate"]);
            objBELBillCharges.DoctorPercent = Convert.ToInt32(reader["DoctorPercent"]);
            objBELBillCharges.DoctorAmount = Convert.ToInt32(reader["DoctorAmount"]);
            objBELBillCharges.IsActive = Convert.ToBoolean(reader["IsActive"]);
            objBELBillCharges.CreatedBy = Convert.ToString(reader["CreatedBy"]);
            objBELBillCharges.CreatedOn = Convert.ToDateTime(reader["CreatedOn"]);
            objBELBillCharges.UpdatedBy = Convert.ToString(reader["UpdatedBy"]);
            objBELBillCharges.UpdatedOn = Convert.ToDateTime(reader["UpdatedOn"]);
        }
        con.Close();
        con.Dispose();
        return objBELBillCharges;
    }

    /// <summary>
    ///  It Reads All Record of BillCharges From Database 
    /// </summary>
    /// <returns> Returns BillCharges Details</returns>
    public List<BELBillCharges> SelectAll()
    {
        List<BELBillCharges> objDOBillChargess = new List<BELBillCharges>();
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_BillCharges_SelectAll", con);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            BELBillCharges objBELBillCharges = new BELBillCharges();

            objBELBillCharges.BillChargeId = Convert.ToInt32(reader["BillChargeId"]);
            objBELBillCharges.BillServiceId = Convert.ToInt32(reader["BillParticularId"]);
            objBELBillCharges.RateTypeId = Convert.ToInt32(reader["RateTypeId"]);
            objBELBillCharges.PatientTypeId = Convert.ToInt32(reader["PatientTypeId"]);
            objBELBillCharges.DoctorId = Convert.ToInt32(reader["DoctorId"]);
            objBELBillCharges.OperationId = Convert.ToInt32(reader["OperationId"]);
            objBELBillCharges.OperationTheatreId = Convert.ToInt32(reader["OperationTheatreId"]);
            objBELBillCharges.RoomCategoryId = Convert.ToInt32(reader["RoomCategoryId"]);
            objBELBillCharges.LabTestId = Convert.ToInt32(reader["LabTestId"]);
            objBELBillCharges.FromKM = Convert.ToInt32(reader["FromKM"]);
            objBELBillCharges.ToKM = Convert.ToInt32(reader["ToKM"]);
            objBELBillCharges.Rate = Convert.ToInt32(reader["Rate"]);
            objBELBillCharges.DoctorPercent = Convert.ToInt32(reader["DoctorPercent"]);
            objBELBillCharges.DoctorAmount = Convert.ToInt32(reader["DoctorAmount"]);
            objBELBillCharges.IsActive = Convert.ToBoolean(reader["IsActive"]);
            objBELBillCharges.CreatedBy = Convert.ToString(reader["CreatedBy"]);
            objBELBillCharges.CreatedOn = Convert.ToDateTime(reader["CreatedOn"]);
            objBELBillCharges.UpdatedBy = Convert.ToString(reader["UpdatedBy"]);
            objBELBillCharges.UpdatedOn = Convert.ToDateTime(reader["CreatedOn"]);

            objDOBillChargess.Add(objBELBillCharges);
        }
        con.Close();
        con.Dispose();
        return objDOBillChargess;
    }

    public string GetCharges(int PatientInfoId, BELBillCharges obj1)
    {
        //int charges = 0;
       
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_BillCharges_GetCharges_DoctorId", con);
        cmd.CommandType = CommandType.StoredProcedure;
      
        cmd.Parameters.AddWithValue("@PatientInfoId",PatientInfoId);
        cmd.Parameters.AddWithValue("@ServiceId", obj1.BillServiceId);
        cmd.Parameters.AddWithValue("@DoctorId",obj1.DoctorId);
        
        object Result = cmd.ExecuteScalar();
        return Convert.ToString(Result);
        //return charges.ToString("0.00");
    }
    
    public string GetDocCharges(int DrId, int ServiceId,int PatSubCategoryId,int BranchId,int FId)
    {
        //int charges = 0;

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_BillCharges_GetCharges_DoctorId", con);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@DrId", DrId);
        cmd.Parameters.AddWithValue("@ServiceId", ServiceId);
        cmd.Parameters.AddWithValue("@PatientSubCategoryId",PatSubCategoryId);
        cmd.Parameters.AddWithValue("@FId", FId);
        cmd.Parameters.AddWithValue("@BranchId", BranchId);
     
        //cmd.Parameters.AddWithValue("@DoctorId", obj1.DoctorId);

        object Result = cmd.ExecuteScalar();
        return Convert.ToString(Result);
        //return charges.ToString("0.00");
    }

    public string GetCharges_ForQuotation(int DrId, int ServiceId, int PatSubCategoryId, int BranchId, int FId)
    {
        //int charges = 0;

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_BillCharges_ForQuotation", con);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@DrId", DrId);
        cmd.Parameters.AddWithValue("@ServiceId", ServiceId);
        cmd.Parameters.AddWithValue("@PatientSubCategoryId", PatSubCategoryId);
        cmd.Parameters.AddWithValue("@FId", FId);
        cmd.Parameters.AddWithValue("@BranchId", BranchId);

        //cmd.Parameters.AddWithValue("@DoctorId", obj1.DoctorId);

        object Result = cmd.ExecuteScalar();
        return Convert.ToString(Result);
        //return charges.ToString("0.00");
    }


    /// <summary>
    ///  It Reads Name of BillCharges From Database
    /// </summary>
    /// <returns> Returns BillCharges Details</returns>
    public List<BELBillCharges> FillCombo()
    {
        List<BELBillCharges> objDOBillChargess = new List<BELBillCharges>();
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_BillCharges_FillCombo", con);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataReader reader = cmd.ExecuteReader();
       
       
        while (reader.Read())
        {
            BELBillCharges objBELBillCharges = new BELBillCharges();

            objBELBillCharges.BillChargeId = Convert.ToInt32(reader["BillChargeId"]);
            objBELBillCharges.Rate = Convert.ToInt32(reader["Rate"]);

            objDOBillChargess.Add(objBELBillCharges);
        }
        con.Close();
        con.Dispose();
        return objDOBillChargess;
    }

    /// <summary>
    ///  It Reads All Record  BillCharges From Database 
    /// </summary>
    /// <returns> Returns BillCharges Details</returns>
    public List<BELBillCharges> FillGrid()
    {
        List<BELBillCharges> objDOBillChargess = new List<BELBillCharges>();

         SqlConnection con = DataAccess.ConInitForDC();
         con.Open();
        SqlCommand cmd = new SqlCommand("SP_BillCharges_FillGrid", con);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataReader reader = cmd.ExecuteReader();
  
        while (reader.Read())
        {
            BELBillCharges objBELBillCharges = new BELBillCharges();

            objBELBillCharges.BillChargeId = Convert.ToInt32(reader["BillChargeId"]);
            objBELBillCharges.ServiceName = Convert.ToString(reader["BillParticular"]);
            objBELBillCharges.RateType = Convert.ToString(reader["RateTypeName"]);
            objBELBillCharges.PatientTypeName = Convert.ToString(reader["PatientTypeName"]);
            objBELBillCharges.DoctorName = Convert.ToString(reader["DoctorName"]);
            objBELBillCharges.OperationName = Convert.ToString(reader["OperationName"]);
            objBELBillCharges.OperationTheatreName = Convert.ToString(reader["OperationTheatreName"]);
            objBELBillCharges.RoomCategoryName = Convert.ToString(reader["RoomCategoryName"]);
            objBELBillCharges.LabTestName = Convert.ToString(reader["LabTestName"]);
            objBELBillCharges.FromKM = Convert.ToInt32(reader["FromKM"]);
            objBELBillCharges.ToKM = Convert.ToInt32(reader["ToKM"]);
            objBELBillCharges.Rate = Convert.ToInt32(reader["Rate"]);
            objBELBillCharges.DoctorAmount = Convert.ToInt32(reader["DoctorAmount"]);
            objDOBillChargess.Add(objBELBillCharges);
        }
        con.Close();
        con.Dispose();
        return objDOBillChargess;
    }


    /// <summary>
    ///  It Reads All Record  BillCharges From Database 
    /// </summary>
    /// <returns> Returns BillCharges Details</returns>
    public List<BELBillCharges> FillSearchGrid(BELBillCharges obj1)
    {
        List<BELBillCharges> objDOBillChargess = new List<BELBillCharges>();
      
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_BillCharges_Search", con);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataReader reader = cmd.ExecuteReader();
  
        cmd.Parameters.AddWithValue("@BillServiceId",obj1.BillServiceId);
        cmd.Parameters.AddWithValue("@BillGroupId",obj1.BillGroupId);
        cmd.Parameters.AddWithValue("@RateTypeId",obj1.RateTypeId);
        cmd.Parameters.AddWithValue("@DoctorId",obj1.DoctorId);
        // cmd.Parameters.AddWithValue("@DoctorId", DbType.Int32, obj1.DoctorId);
       
        while (reader.Read())
        {
            BELBillCharges objBELBillCharges = new BELBillCharges();

            objBELBillCharges.BillChargeId = Convert.ToInt32(reader["BillChargeId"]);
            objBELBillCharges.ServiceName = Convert.ToString(reader["ServiceName"]);
            objBELBillCharges.RateType = Convert.ToString(reader["RateType"]);
            objBELBillCharges.PatientTypeName = Convert.ToString(reader["PatientTypeName"]);
            objBELBillCharges.DoctorName = Convert.ToString(reader["DoctorName"]);
            objBELBillCharges.OperationName = Convert.ToString(reader["OperationName"]);
            objBELBillCharges.OperationTheatreName = Convert.ToString(reader["OperationTheatreName"]);
            objBELBillCharges.RoomCategoryName = Convert.ToString(reader["RoomCategoryName"]);
            objBELBillCharges.LabTestName = Convert.ToString(reader["LabTestName"]);
            objBELBillCharges.FromKM = Convert.ToInt32(reader["FromKM"]);
            objBELBillCharges.ToKM = Convert.ToInt32(reader["ToKM"]);
            objBELBillCharges.Rate = Convert.ToInt32(reader["Rate"]);
            objBELBillCharges.DoctorAmount = Convert.ToInt32(reader["DoctorAmount"]);
            objDOBillChargess.Add(objBELBillCharges);

        }
        con.Close();
        con.Dispose();
        return objDOBillChargess;
    }

    /// <summary>
    ///  It Insert Single Record From Database Regarding Id
    /// </summary>
    /// <param name="obj1">It Requires Inserting Details Of BillCharges In Form Of BELBillCharges object  </param>
    /// <returns>Returns Success Message In String</returns>
    public string InsertBillCharges(BELBillCharges obj1)
    {
        
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("SP_BillCharges_Insert", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        cmd.Parameters.AddWithValue("@BillServiceId",obj1.BillServiceId);
        cmd.Parameters.AddWithValue("@RateTypeId", obj1.RateTypeId);
        cmd.Parameters.AddWithValue("@PatientTypeId",obj1.PatientTypeId);
        cmd.Parameters.AddWithValue("@DoctorId",obj1.DoctorId);
        cmd.Parameters.AddWithValue("@OperationId",obj1.OperationId);
        cmd.Parameters.AddWithValue("@OperationTheatreId",obj1.OperationTheatreId);
        cmd.Parameters.AddWithValue("@RoomCategoryId",obj1.RoomCategoryId);
        cmd.Parameters.AddWithValue("@LabTestId", obj1.LabTestId);
        cmd.Parameters.AddWithValue("@HospitalId",obj1.HospitalId);
        cmd.Parameters.AddWithValue("@FromKm",obj1.FromKM);
        cmd.Parameters.AddWithValue("@ToKm",obj1.ToKM);
        cmd.Parameters.AddWithValue("@Rate",obj1.Rate);
        cmd.Parameters.AddWithValue("@DoctorPercent",obj1.DoctorPercent);
        cmd.Parameters.AddWithValue("@DoctorAmount",obj1.DoctorAmount);
        cmd.Parameters.AddWithValue("@CreatedBy",obj1.CreatedBy);

        object Result = cmd.ExecuteScalar();
        return Convert.ToString(Result);
    }

    /// <summary>
    ///  It Update Single Record From Database Regarding Id
    /// </summary>
    /// <param name="obj1">It Requires Changing Details Of BillCharges In Form Of BELBillCharges object  </param>
    /// <returns>Returns Success Message In String</returns>
    public string UpdateBillCharges(double BillChargeId, int BillParticularId, int RateTypeId, int PatientTypeId, int DoctorId, int OperationId, int OperationTheatreId, int RoomCategoryId, int LabTestId, int HospitalId, int FromKM, int ToKM, decimal Rate, decimal DoctorPercent, decimal DoctorAmount, int UpdatedBy)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("SP_BillCharges_Update", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        cmd.Parameters.AddWithValue("@BillChargeId",BillChargeId);
        cmd.Parameters.AddWithValue("@BillParticularId",BillParticularId);
        cmd.Parameters.AddWithValue("@RateTypeId", RateTypeId);
        cmd.Parameters.AddWithValue("@PatientTypeId",PatientTypeId);
        cmd.Parameters.AddWithValue("@DoctorId",DoctorId);
        cmd.Parameters.AddWithValue("@OperationId",OperationId);
        cmd.Parameters.AddWithValue("@OperationTheatreId",OperationTheatreId);
        cmd.Parameters.AddWithValue("@RoomCategoryId",RoomCategoryId);
        cmd.Parameters.AddWithValue("@LabTestId",LabTestId);
        cmd.Parameters.AddWithValue("@HospitalId",HospitalId);
        cmd.Parameters.AddWithValue("@FromKm",FromKM);
        cmd.Parameters.AddWithValue("@ToKm",ToKM);
        cmd.Parameters.AddWithValue("@Rate",Rate);
        cmd.Parameters.AddWithValue("@DoctorPercent",DoctorPercent);
        cmd.Parameters.AddWithValue("@DoctorAmount",DoctorAmount);
        cmd.Parameters.AddWithValue("@UpdatedBy", UpdatedBy);
        object Result = cmd.ExecuteScalar();
        return Convert.ToString(Result);
    }

   
   
    
    public string DeleteBillCharges(double BillChargeId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("SP_BillCharges_Delete", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        
        cmd.Parameters.AddWithValue("@BillChargeId", BillChargeId);

        object Result = cmd.ExecuteScalar();
        return Convert.ToString(Result);
    }

    public object[] GetDoctorId(int BillParticularId)
    {
        BELBillCharges objBELBillCharges = new BELBillCharges();
        object[] Result = new object[10];
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("SP_BillCharges_GetDoctorId", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();        
        cmd.Parameters.AddWithValue("@BillParticularId",BillParticularId);
        cmd.Parameters.Add("@DoctorId", SqlDbType.Int);
        cmd.Parameters["@DoctorId"].Direction = ParameterDirection.Output;
        Result[0] = cmd.ExecuteScalar();
        string DoctorId = Convert.ToString(cmd.Parameters["@DoctorId"].Value);
        Result[1] = Convert.ToInt32(cmd.Parameters["@DoctorId"].Value);
        if (DoctorId == "")
            objBELBillCharges.DoctorId = 0;
        else
            objBELBillCharges.DoctorId = Convert.ToInt32(cmd.Parameters["@DoctorId"].Value);
        Result[1] = objBELBillCharges.DoctorId;
        return Result;
       
    }

    public string GetCommonCharges(int PatientInfoId, BELBillCharges obj1)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("SP_BillCharges_GetCommonCharges", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();      
        
        cmd.Parameters.AddWithValue("@PatientInfoId",PatientInfoId);
        cmd.Parameters.AddWithValue("@ServiceId",obj1.BillServiceId);
        object Result = cmd.ExecuteScalar();
        return Convert.ToString(Result);
    }


    public string GetIPDAdmitedFixCharges(int BillServiceId, int BillGroupId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("SP_BillCharges_GetChargesForIPDAdmited", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();      
        
        cmd.Parameters.AddWithValue("@BillParticularId",BillServiceId);
        cmd.Parameters.AddWithValue("@BillGroupId",BillGroupId);
        object Result = cmd.ExecuteScalar();
        return Convert.ToString(Result);
    }
    //==========================================================
    public DataSet FillBillServiceName(int BranchId, int PatientType,int RateTypeId,int BillGroupId,int BillServiceId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_Get_BillService", con);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        cmd.Parameters.AddWithValue("@PatientType", PatientType);
        cmd.Parameters.AddWithValue("@BranchId", BranchId);
        cmd.Parameters.AddWithValue("@RateTypeId", RateTypeId);
        cmd.Parameters.AddWithValue("@BillGroupId", BillGroupId);
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
        }
        return ds;
    }
    public DataSet FillBillServiceNameForRoom(int BranchId, int PatientType, int RateTypeId, int BillGroupId, int BillServiceId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_Get_RoomWiseBillService", con);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        cmd.Parameters.AddWithValue("@PatientType", PatientType);
        cmd.Parameters.AddWithValue("@BranchId", BranchId);
        cmd.Parameters.AddWithValue("@RateTypeId", RateTypeId);
        cmd.Parameters.AddWithValue("@BillGroupId", BillGroupId);
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
        }
        return ds;
    }


    public string InsertUpdate_BillService_Charges(int BillGroupId, int ServiceID, int RoomTypeId, int PatientType, int RateTypeId, float Rate, int Branchid, string CreatedBy, int Drid, float DrCompamt, float DrCompPer, bool IsDocWise, bool IsRoomwise, bool IsDirect, string MTCode)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("SP_InsertBillServiceCharges", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {
            cmd.Parameters.AddWithValue("@BillGroupId", BillGroupId);
            cmd.Parameters.AddWithValue("@ServiceID", ServiceID);
            cmd.Parameters.AddWithValue("@RoomTypeId", RoomTypeId);
            cmd.Parameters.AddWithValue("@PatientType", PatientType);
            cmd.Parameters.AddWithValue("@RateTypeId", RateTypeId);
            cmd.Parameters.AddWithValue("@Rate", Rate);

            cmd.Parameters.AddWithValue("@Branchid", Branchid);
            cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);

            cmd.Parameters.AddWithValue("@Drid", Drid);

            cmd.Parameters.AddWithValue("@IsRoomwise", IsRoomwise);
            cmd.Parameters.AddWithValue("@IsDocWise", IsDocWise);
            cmd.Parameters.AddWithValue("@IsDirect", IsDirect);

            cmd.Parameters.AddWithValue("@DrCompPer", DrCompPer);
            cmd.Parameters.AddWithValue("@DrCompamt", DrCompamt);
            cmd.Parameters.AddWithValue("@MTCode", MTCode);

            object Result = cmd.ExecuteScalar();
            return Convert.ToString(Result);
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
    public DataSet GetDrCharges(string IsOpd)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_GetDr_service", con);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(cmd);

        cmd.Parameters.AddWithValue("@IsOpd", IsOpd);
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
        }
        return ds;
    }

    public DataSet GetDrName(int ServiceId,int BranchId,int RateTypeId,int PatientType)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_GetDr_Name", con);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
       
        DataSet ds = new DataSet();
        con.Open();
        try
        {
            cmd.Parameters.AddWithValue("@ServiceId", ServiceId);
            cmd.Parameters.AddWithValue("@RateTypeId", RateTypeId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.Parameters.AddWithValue("@PatientType", PatientType);
            da.Fill(ds);
        }
        catch (SqlException)
        {
            throw;
        }
        finally
        {
            con.Close();
        }
        return ds;
    }

    public DataSet Get_RoomCategory(int ServiceId, int BranchId, int RateTypeId, int PatientType)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_Get_RoomCategory", con);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        cmd.Parameters.AddWithValue("@ServiceId", ServiceId);
        cmd.Parameters.AddWithValue("@RateTypeId", RateTypeId);
        cmd.Parameters.AddWithValue("@BranchId", BranchId);
        cmd.Parameters.AddWithValue("@PatientType", PatientType);
         
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
        }
        return ds;
    }


    public DataSet FillPackageTypeDrop()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("Sp_PackageTypeFillCombo", con);
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
        }
        return ds;
    }

    public DataSet FillBillServiceName_AllLab(int BranchId, int PatientType, int RateTypeId, int BillGroupId, int BillServiceId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_Get_BillService_AllLab", con);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        cmd.Parameters.AddWithValue("@PatientType", PatientType);
        cmd.Parameters.AddWithValue("@BranchId", BranchId);
        cmd.Parameters.AddWithValue("@RateTypeId", RateTypeId);
        cmd.Parameters.AddWithValue("@BillGroupId", BillGroupId);
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

    public DataSet FillBillServiceName_AllLab_search(int BranchId, int PatientType, int RateTypeId, int BillGroupId, int BillServiceId, string Search)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_Get_BillService_AllLab", con);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        cmd.Parameters.AddWithValue("@PatientType", PatientType);
        cmd.Parameters.AddWithValue("@BranchId", BranchId);
        cmd.Parameters.AddWithValue("@RateTypeId", RateTypeId);
        cmd.Parameters.AddWithValue("@BillGroupId", BillGroupId);
        cmd.Parameters.AddWithValue("@BillServiceId", BillServiceId);
        cmd.Parameters.AddWithValue("@BillServiceId", Search);
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


    public DataSet FillBillServiceName_Lab_search(int BranchId, int PatientType, int RateTypeId, int BillGroupId, int BillServiceId, string Search)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_Get_BillService_Lab_search", con);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        cmd.Parameters.AddWithValue("@PatientType", PatientType);
        cmd.Parameters.AddWithValue("@BranchId", BranchId);
        cmd.Parameters.AddWithValue("@RateTypeId", RateTypeId);
        cmd.Parameters.AddWithValue("@BillGroupId", BillGroupId);
        cmd.Parameters.AddWithValue("@BillServiceId", BillServiceId);
        cmd.Parameters.AddWithValue("@Search", Search);
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

    public DataSet FillBillServiceName_Lab(int BranchId, int PatientType, int RateTypeId, int BillGroupId, int BillServiceId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_Get_BillService_Lab", con);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        cmd.Parameters.AddWithValue("@PatientType", PatientType);
        cmd.Parameters.AddWithValue("@BranchId", BranchId);
        cmd.Parameters.AddWithValue("@RateTypeId", RateTypeId);
        cmd.Parameters.AddWithValue("@BillGroupId", BillGroupId);
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

    public DataSet FillBillServiceNameForRoom_DailyNew(int BranchId, int PatientType, int RateTypeId, int BillGroupId, int BillServiceId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_Get_RoomWiseBillService_DailyCharges", con);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        cmd.Parameters.AddWithValue("@PatientType", PatientType);
        cmd.Parameters.AddWithValue("@BranchId", BranchId);
        cmd.Parameters.AddWithValue("@RateTypeId", RateTypeId);
        cmd.Parameters.AddWithValue("@BillGroupId", BillGroupId);
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

    public DataSet FillLabRateTypeDrop()
    {
        SqlConnection con = DataAccess.ConInitForMedical();
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("Sp_LAB_RateTypeFillCombo", con);
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