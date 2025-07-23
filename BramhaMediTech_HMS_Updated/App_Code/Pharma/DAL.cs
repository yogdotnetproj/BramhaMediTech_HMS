using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

/// <summary>
/// Summary description for DAL
/// </summary>
public class DAL
{
    string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;//ToString();
    string constrLab = ConfigurationManager.ConnectionStrings["MedicalConn"].ConnectionString;
    string constrHMS = ConfigurationManager.ConnectionStrings["DBHospital"].ConnectionString;
    string Dbhospital = ConfigurationManager.ConnectionStrings["DBHospital"].ConnectionString;
    //______________________________________________________Code For Department__________________________________________________________________

    public List<string> AutoFillPatientName_ForPharma(string prefixtext, string Type)
    {
        // BEL ItemInfo = new BEL();

        SqlConnection con = new SqlConnection(constr);
        string[] Database = Dbhospital.Split(';');
        string InitialCatalog = Database[1];
        string[] db = InitialCatalog.Split('=');
        string DbName = db[1];
        con.Open();
        //con.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;//ToString();

        try
        {
            SqlCommand cmd = new SqlCommand("Sp_GetPatientNameForIssueVoucher", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Search", prefixtext);
            cmd.Parameters.AddWithValue("@Type", Type);
            

            List<string> Tests = new List<string>();
            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                Tests.Add(sdr["PatientName"].ToString());
                //Tests.Add(sdr["Age"].ToString());
                //Tests.Add(sdr["AgeType"].ToString());
                //Tests.Add(sdr["PatientAddress"].ToString());
                //Tests.Add(sdr["DoctorName"].ToString());
                //Tests.Add(sdr["DrId"].ToString());
            }



            return Tests;
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

    public List<string> AutoFillPatientName_ForPharma_DirectBack(string prefixtext, string Type)
    {
        // BEL ItemInfo = new BEL();

        SqlConnection con = new SqlConnection(Dbhospital);
        string[] Database = Dbhospital.Split(';');
        string InitialCatalog = Database[1];
        string[] db = InitialCatalog.Split('=');
        string DbName = db[1];
        con.Open();
        //con.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;//ToString();

        try
        {
            SqlCommand cmd = new SqlCommand("Sp_GetPatientName_IPDCreditBack", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Search", prefixtext);
            cmd.Parameters.AddWithValue("@Type", Type);


            List<string> Tests = new List<string>();
            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                Tests.Add(sdr["PatientName"].ToString());
                //Tests.Add(sdr["Age"].ToString());
                //Tests.Add(sdr["AgeType"].ToString());
                //Tests.Add(sdr["PatientAddress"].ToString());
                //Tests.Add(sdr["DoctorName"].ToString());
                //Tests.Add(sdr["DrId"].ToString());
            }



            return Tests;
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

    public List<string> AutoFillPatientName(string prefixtext, string Type)
    {
        // BEL ItemInfo = new BEL();

        SqlConnection con = new SqlConnection(Dbhospital);
        string[] Database = Dbhospital.Split(';');
        string InitialCatalog = Database[1];
        string[] db = InitialCatalog.Split('=');
        string DbName = db[1];
        con.Open();
        //con.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;//ToString();

        try
        {
            SqlCommand cmd = new SqlCommand("Sp_GetPatientName", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Search", prefixtext);
            cmd.Parameters.AddWithValue("@Type", Type);
            cmd.Parameters.AddWithValue("@database", DbName);

            List<string> Tests = new List<string>();
            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                Tests.Add(sdr["PatientName1"].ToString());
                //Tests.Add(sdr["Age"].ToString());
                //Tests.Add(sdr["AgeType"].ToString());
                //Tests.Add(sdr["PatientAddress"].ToString());
                //Tests.Add(sdr["DoctorName"].ToString());
                //Tests.Add(sdr["DrId"].ToString());
            }



            return Tests;
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

    public BEL SelectOne(int PatRegId, string PatType, int OpdIpdNo)
    {
        BEL obj = new BEL();
        //SqlConnection con = DataAccess.ConInitForPharmacy();
        SqlConnection con = new SqlConnection(Dbhospital);
        string[] Database = Dbhospital.Split(';');
        string InitialCatalog = Database[1];
        string[] db = InitialCatalog.Split('=');
        string DbName = db[1];
        con.Open();


        SqlCommand cmd = new SqlCommand("Sp_PatientInformation", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@PatRegId", PatRegId);
            cmd.Parameters.AddWithValue("@PatType", PatType);
            cmd.Parameters.AddWithValue("@OpdIpdNo", OpdIpdNo);
            cmd.Parameters.AddWithValue("@database", DbName);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                obj.PatAddress = Convert.ToString(reader["PatientAddress"]);
                obj.PatientName = Convert.ToString(reader["PatientName"]);
                obj.DrName = Convert.ToString(reader["DoctorName"]);
                obj.DrId = Convert.ToInt32(reader["DrId"]);
                obj.Gender = Convert.ToString(reader["GenderName"]);
                obj.Age = Convert.ToInt32(reader["Age"]);
                obj.AgeType = Convert.ToString(reader["AgeType"]);


                obj.PatMainTypeId = Convert.ToInt32(reader["PatMainTypeId"]);
                obj.PatientInsuTypeId = Convert.ToInt32(reader["PatientInsuTypeId"]);
                obj.PatientInsuSubTypeId = Convert.ToInt32(reader["PatientInsuSubTypeId"]);
                obj.PatientInsuType = Convert.ToString(reader["PatientInsuType"]);
                obj.PatientInsuSubType = Convert.ToString(reader["ChildCompanyName"]);
            }
            return obj;
        }
        catch (SqlException)
        {
            throw;
        }
        finally
        {
            con.Close();
        }


    }

    public string InsertDepartment(BEL DeptInfo)
    {
        
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_ISUDDept", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@DeptName", DeptInfo.DeptName);
            cmd.Parameters.AddWithValue("@PrescItemPer", DeptInfo.PrescItemPer);
            cmd.Parameters.AddWithValue("@CounterItemPer", DeptInfo.CounterItemPer);            
            cmd.Parameters.AddWithValue("@BranchId", DeptInfo.BranchId);
            cmd.Parameters.AddWithValue("@Fid", DeptInfo.Fid);            
            cmd.Parameters.AddWithValue("@CreatedBy", DeptInfo.CreatedBy);
            cmd.Parameters.AddWithValue("@PrescItemPerIPD", DeptInfo.PrescItemPerIPD);
            cmd.Parameters.AddWithValue("@CounterItemPerIPD", DeptInfo.CounterItemPerIPD);
            cmd.Parameters.AddWithValue("@StoreType", DeptInfo.StoreType);
            
            cmd.Parameters.AddWithValue("@Flag", "Insert");
            object Result = cmd.ExecuteScalar();
            return Convert.ToString(Result);
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            con.Dispose();
            con.Close();
        }

    }
    public string UpdatePackageDetails(BEL DeptInfo)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_UpdatePackageDetails", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@PackageId", DeptInfo.PackageId);
            cmd.Parameters.AddWithValue("@ItemId", DeptInfo.ItemId);
            cmd.Parameters.AddWithValue("@UpdatedBy", DeptInfo.UpdatedBy);
            cmd.Parameters.AddWithValue("@Qty", DeptInfo.Quantity);
            cmd.Parameters.AddWithValue("@DoseId", DeptInfo.DoseId);
            cmd.Parameters.AddWithValue("@Days", DeptInfo.Days);
            cmd.Parameters.AddWithValue("@DoseTimeId", DeptInfo.DoseTimeId);
            cmd.Parameters.AddWithValue("@Remark", DeptInfo.Remark);
            cmd.Parameters.AddWithValue("@PackageDetailId", DeptInfo.PackageDetailId);
            object Result = cmd.ExecuteScalar();
            return Convert.ToString(Result);


        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            con.Dispose();
            con.Close();
        }

    }

    public string InsertPackageDetails(BEL DeptInfo)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_InsertPackageDetails", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@PackageId", DeptInfo.PackageId);
            cmd.Parameters.AddWithValue("@ItemId", DeptInfo.ItemId);
            cmd.Parameters.AddWithValue("@CreatedBy", DeptInfo.CreatedBy);
            cmd.Parameters.AddWithValue("@Qty", DeptInfo.Quantity);

            cmd.Parameters.AddWithValue("@DoseId", DeptInfo.DoseId);
            cmd.Parameters.AddWithValue("@Days", DeptInfo.Days);
            cmd.Parameters.AddWithValue("@DoseTimeId", DeptInfo.DoseTimeId);
            cmd.Parameters.AddWithValue("@Remark", DeptInfo.Remark);
           
            object Result = cmd.ExecuteScalar();
            return Convert.ToString(Result);


        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            con.Dispose();
            con.Close();
        }

    }

    public string UpdateDepartment(BEL DeptInfo)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_ISUDDept", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@DeptId", DeptInfo.DeptId);
            cmd.Parameters.AddWithValue("@DeptName", DeptInfo.DeptName);
            cmd.Parameters.AddWithValue("@PrescItemPer", DeptInfo.PrescItemPer);
            cmd.Parameters.AddWithValue("@CounterItemPer", DeptInfo.CounterItemPer);

            cmd.Parameters.AddWithValue("@PrescItemPerIPD", DeptInfo.PrescItemPerIPD);
            cmd.Parameters.AddWithValue("@CounterItemPerIPD", DeptInfo.CounterItemPerIPD);
            cmd.Parameters.AddWithValue("@StoreType", DeptInfo.StoreType);
            cmd.Parameters.AddWithValue("@BranchId", DeptInfo.BranchId);
            cmd.Parameters.AddWithValue("@Fid", DeptInfo.Fid);
            cmd.Parameters.AddWithValue("@UpdatedBy", DeptInfo.UpdatedBy);
            cmd.Parameters.AddWithValue("@Flag", "Update");
            object Result = cmd.ExecuteScalar();
            return Convert.ToString(Result);
           
            
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            con.Dispose();
            con.Close();
        }

    }

    public string UpdatePackage(BEL DeptInfo)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_ISUDPackage", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@PackageId", DeptInfo.PackageId);
            cmd.Parameters.AddWithValue("@PackageName", DeptInfo.PackageName);
            cmd.Parameters.AddWithValue("@IsEmergency", DeptInfo.IsEmergency);
            cmd.Parameters.AddWithValue("@DrId", DeptInfo.DrId);
            cmd.Parameters.AddWithValue("@UpdatedBy", DeptInfo.UpdatedBy);
            cmd.Parameters.AddWithValue("@Flag", "Update");
            object Result = cmd.ExecuteScalar();
            return Convert.ToString(Result);


        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            con.Dispose();
            con.Close();
        }

    }

    public string InsertPackage(BEL DeptInfo)
    {

        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_ISUDPackage", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@PackageName", DeptInfo.PackageName);
           
            cmd.Parameters.AddWithValue("@CreatedBy", DeptInfo.CreatedBy);
            cmd.Parameters.AddWithValue("@IsEmergency", DeptInfo.IsEmergency);
            cmd.Parameters.AddWithValue("@DrId", DeptInfo.DrId);
            cmd.Parameters.AddWithValue("@Flag", "Insert");
            object Result = cmd.ExecuteScalar();
            return Convert.ToString(Result);
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            con.Dispose();
            con.Close();
        }

    }

    public BEL SelectOnePackage(int PackageId)
    {
        BEL objBELDept = new BEL();
        SqlConnection con = DataAccess.ConInitForPharmacy();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_ISUDPackage", con);
        cmd.CommandType = CommandType.StoredProcedure;


        try
        {
            cmd.Parameters.AddWithValue("@PackageId", PackageId);
            cmd.Parameters.AddWithValue("@Flag", "SelectOne");
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                objBELDept.PackageId = Convert.ToInt32(sdr["PackageId"]);
                objBELDept.PackageName = Convert.ToString(sdr["PackageName"]);
                objBELDept.IsEmergency = Convert.ToBoolean(sdr["IsEmergency"]);
                objBELDept.DrName = Convert.ToString(sdr["DoctorName"]);
                objBELDept.DrId = Convert.ToInt32(sdr["DoctorId"]);

                
            }
            return objBELDept;
        }
        catch (SqlException)
        {
            throw;
        }
        finally
        {
            con.Close();
        }
    }

    public BEL SelectOnePackageItems(int PackageDetailId)
    {
        BEL objBELDept = new BEL();
        SqlConnection con = DataAccess.ConInitForPharmacy();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_SelectPackageDetails", con);
        cmd.CommandType = CommandType.StoredProcedure;


        try
        {
            cmd.Parameters.AddWithValue("@PackageDetailId", PackageDetailId);
           
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                objBELDept.PackageId = Convert.ToInt32(sdr["PackageId"]);
                objBELDept.PackageName = Convert.ToString(sdr["PackageName"]);
                objBELDept.ItemName = Convert.ToString(sdr["ItemName"]);
                objBELDept.Quantity = Convert.ToDecimal(sdr["Qty"]);
                objBELDept.ItemId = Convert.ToInt32(sdr["ItemId"]);
                objBELDept.DoseId = Convert.ToInt32(sdr["DoseId"]);
                objBELDept.Days = Convert.ToInt32(sdr["Days"]);
                objBELDept.Remark = Convert.ToString(sdr["Remark"]);

            }
            return objBELDept;
        }
        catch (SqlException)
        {
            throw;
        }
        finally
        {
            con.Close();
        }
    }

    public DataSet FillPackageDetails(int PackageId)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_FillPackageDetailsGrid", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PackageId", PackageId);       

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        return ds;

    }
    public DataSet fillPackage()
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("Sp_ISUDPackage", con);
        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        da.SelectCommand.Parameters.AddWithValue("@Flag", "Select");
        DataSet ds = new DataSet();
        da.Fill(ds);
        return ds;

    }

    public BEL SelectOneDept(int DeptId)
    {
        BEL objBELDept = new BEL();
        SqlConnection con = DataAccess.ConInitForPharmacy();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_ISUDDept", con);
        cmd.CommandType = CommandType.StoredProcedure;


        try
        {
            cmd.Parameters.AddWithValue("@DeptId", DeptId);
            cmd.Parameters.AddWithValue("@Flag", "SelectOne");
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                objBELDept.DeptId = Convert.ToInt32(sdr["DeptId"]);
                objBELDept.DeptName = Convert.ToString(sdr["DeptName"]);
                objBELDept.PrescItemPer = Convert.ToDecimal(sdr["PrescItemPer"]);
                objBELDept.CounterItemPer = Convert.ToDecimal(sdr["CounterItemPer"]);
                objBELDept.PrescItemPerIPD = Convert.ToDecimal(sdr["PrescItemPerIPD"]);
                objBELDept.CounterItemPerIPD = Convert.ToDecimal(sdr["CounterItemPerIPD"]);
                objBELDept.StoreType = Convert.ToInt32(sdr["Storetype"]);


            }
            return objBELDept;
        }
        catch (SqlException)
        {
            throw;
        }
        finally
        {
            con.Close();
        }
    }


    public DataSet fillDept()
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("Sp_ISUDDept", con);
        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        da.SelectCommand.Parameters.AddWithValue("@Flag", "Select");
        DataSet ds = new DataSet();
        da.Fill(ds);
        return ds;
        
    }

    public DataSet FillDdlStore(int BranchId,int UserId)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("Sp_ISUDDept", con);
        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        da.SelectCommand.Parameters.AddWithValue("@StoreType", 0);
        da.SelectCommand.Parameters.AddWithValue("@BranchId", BranchId);
        da.SelectCommand.Parameters.AddWithValue("@UserId", UserId);
        da.SelectCommand.Parameters.AddWithValue("@Flag", "StoreWiseUser");
        DataSet ds = new DataSet();
        da.Fill(ds);
        return ds;
        
    }
    public DataSet FillPaymentType()
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("Sp_FillPaymentType", con);
        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        
        DataSet ds = new DataSet();
        da.Fill(ds);
        return ds;

    }
    public DataSet GetMainCategory()
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("SP_GetMainCategory", con);
        da.SelectCommand.CommandType = CommandType.StoredProcedure;

        DataSet ds = new DataSet();
        da.Fill(ds);
        return ds;

    }
    public DataSet fillDeptUserwise(int UserId, int BranchId, int StoreType)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd=new SqlCommand("Sp_ISUDDept", con);
        cmd.CommandType = CommandType.StoredProcedure;        
        cmd.Parameters.AddWithValue("@UserId",UserId );
        cmd.Parameters.AddWithValue("@StoreType", StoreType);
        cmd.Parameters.AddWithValue("@BranchId", BranchId);
        cmd.Parameters.AddWithValue("@Flag","DeptUserWise");
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        return ds;

    }
    //public DataSet fillDeptUserwise_UserType(int UserId, int BranchId, int StoreType,string Usertype)
    //{
    //    SqlConnection con = new SqlConnection(constr);
    //    con.Open();
    //    SqlCommand cmd = new SqlCommand("Sp_ISUDDept", con);
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.Parameters.AddWithValue("@UserId", UserId);
    //    cmd.Parameters.AddWithValue("@StoreType", StoreType);
    //    cmd.Parameters.AddWithValue("@BranchId", BranchId);
    //    cmd.Parameters.AddWithValue("@Flag", "DeptUserWise");
    //    SqlDataAdapter da = new SqlDataAdapter(cmd);
    //    DataSet ds = new DataSet();
    //    da.Fill(ds);
    //    return ds;

    //}

    public DataSet fillUsersDepartment(int DeptId, int BranchId, int FId)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_FillUsersDept", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@DeptId", DeptId);
        cmd.Parameters.AddWithValue("@FId", FId);
        cmd.Parameters.AddWithValue("@BranchId", BranchId);

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        return ds;

    }
    public DataSet fillUsers(int UserId, int BranchId, int FId)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_FillUsers", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@UserId", UserId);
        cmd.Parameters.AddWithValue("@FId", FId);
        cmd.Parameters.AddWithValue("@BranchId", BranchId);
        
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        return ds;

    }
    public DataSet fillDeptUserwise1(int UserId, int BranchId)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_ISUDDept", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@UserId", UserId);
        //cmd.Parameters.AddWithValue("@StoreType", StoreType);
        cmd.Parameters.AddWithValue("@BranchId", BranchId);
        cmd.Parameters.AddWithValue("@Flag", "StoreWiseUser");
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        return ds;

    }
    public DataSet FillMainCategory()
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_FillMainCategory", con);
        cmd.CommandType = CommandType.StoredProcedure;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        return ds;

    }

    public DataTable Bind_AssignuserToDepartment( string usertype)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlConnection con1 = DataAccess.ConInitForPharmacy();
        string PhDB = con1.Database;
        SqlDataAdapter sda = new SqlDataAdapter("select distinct  'Select Dept'  as DeptName,'0' as DeptId  from " + PhDB + ".dbo.tbl_Dept union all SELECT   " + PhDB + ".dbo.tbl_Dept.DeptName,  " + PhDB + ".dbo.tbl_Dept.DeptId " +
            "    FROM            AssignuserToDepartment INNER JOIN "+
            "    usr ON AssignuserToDepartment.RoleId = usr.ROLLID INNER JOIN "+
            "    CTuser ON AssignuserToDepartment.UserId = CTuser.CUId INNER JOIN "+
            "    "+PhDB+".dbo.tbl_Dept ON AssignuserToDepartment.DepartmentID = "+PhDB+".dbo.tbl_Dept.DeptId "+
            "    WHERE       AssignuserToDepartment.UserId='" + usertype + "' ", con);

        DataTable ds = new DataTable();
        try
        {
            sda.Fill(ds);
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

    public DataSet FillIssueToWareHouse(int DeptId)
    {
        //SqlConnection con = new SqlConnection(constr);
        //con.Open();
        //SqlCommand cmd = new SqlCommand("Sp_Fill_AllWarehouse", con);
        //cmd.CommandType = CommandType.StoredProcedure;

        //SqlDataAdapter da = new SqlDataAdapter(cmd);
        //DataSet ds = new DataSet();
        //da.Fill(ds);
        //return ds;

        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Fill_AllWarehouse", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@DeptId", DeptId);
      
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        return ds;

    }

    public DataSet Fill_PackSize()
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetPackSize", con);
        cmd.CommandType = CommandType.StoredProcedure;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        return ds;

    }

    public DataSet Fill_MedicineType()
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetMedicineType_Mst", con);
        cmd.CommandType = CommandType.StoredProcedure;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        return ds;

    }

    public DataSet Fill_SubGroup()
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetSubCategory", con);
        cmd.CommandType = CommandType.StoredProcedure;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        return ds;

    }

    public DataSet FillCategory()
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_FillCategory", con);
        cmd.CommandType = CommandType.StoredProcedure;   
        
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        return ds;

    }
    public DataSet FillTaxType()
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_FillTaxTypeDrop", con);
        cmd.CommandType = CommandType.StoredProcedure; 
        
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        return ds;

    }

    public DataTable FillBatchNo_DeptRequest(int itemid, int BranchId, int FId)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("Sp_FillBatchNo_DeptRequest", con);
        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        da.SelectCommand.Parameters.AddWithValue("@ItemId", itemid);
        da.SelectCommand.Parameters.AddWithValue("@BranchId", BranchId);
        da.SelectCommand.Parameters.AddWithValue("@FId", FId);
       
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable FillBatchNo_WarehouseStockAdjust(int itemid, int BranchId, int FId)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("Sp_FillBatchNo_WarehouseStockAdjust", con);
        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        da.SelectCommand.Parameters.AddWithValue("@ItemId", itemid);
        da.SelectCommand.Parameters.AddWithValue("@BranchId", BranchId);
        da.SelectCommand.Parameters.AddWithValue("@FId", FId);

        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable FillBatchNoForGRN(int itemid, int BranchId, int FId)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("Sp_FillBatchNoForGRN", con);
        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        da.SelectCommand.Parameters.AddWithValue("@ItemId", itemid);
        da.SelectCommand.Parameters.AddWithValue("@BranchId", BranchId);
        da.SelectCommand.Parameters.AddWithValue("@FId", FId);
       
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    

    public DataTable FillBatchNo(int itemid, int BranchId, int FId)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("Sp_FillBatchNo", con);
        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        da.SelectCommand.Parameters.AddWithValue("@ItemId",itemid);
        da.SelectCommand.Parameters.AddWithValue("@BranchId", BranchId);
        da.SelectCommand.Parameters.AddWithValue("@FId", FId);
        //da.SelectCommand.Parameters.AddWithValue("@DeptId", DeptId);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable FillBatchNoForDept(int itemid, int DeptId, int BranchId, int FId)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("Sp_FillBatchNoForDept", con);
        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        da.SelectCommand.Parameters.AddWithValue("@ItemId", itemid);
        da.SelectCommand.Parameters.AddWithValue("@DeptId", DeptId);
        da.SelectCommand.Parameters.AddWithValue("@BranchId", BranchId);
        da.SelectCommand.Parameters.AddWithValue("@FId", FId);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public DataTable FillBatchNoForDept_PatIssue(int itemid, int DeptId, int BranchId, int FId,int WareHouseId)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("Sp_FillBatchNoForDept_PatIssue", con);
        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        da.SelectCommand.Parameters.AddWithValue("@ItemId", itemid);
        da.SelectCommand.Parameters.AddWithValue("@DeptId", DeptId);
        da.SelectCommand.Parameters.AddWithValue("@BranchId", BranchId);
        da.SelectCommand.Parameters.AddWithValue("@FId", FId);
        da.SelectCommand.Parameters.AddWithValue("@WareHouseId", WareHouseId);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

     public DataTable FillBatchNoForDept_StockAdjust(int itemid, int DeptId, int BranchId, int FId)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("Sp_FillBatchNoForDept_StockAdjust", con);
        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        da.SelectCommand.Parameters.AddWithValue("@ItemId", itemid);
        da.SelectCommand.Parameters.AddWithValue("@DeptId", DeptId);
        da.SelectCommand.Parameters.AddWithValue("@BranchId", BranchId);
        da.SelectCommand.Parameters.AddWithValue("@FId", FId);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public BEL FillBatchNoInfoForDept(int itemid,int DeptId, int BranchId, int FId)
    {
        //List<BEL> objBEL = new List<BEL>();

        BEL objBELBatch = new BEL();
        SqlConnection con = DataAccess.ConInitForPharmacy();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_FillBatchNoForDept", con);
        cmd.CommandType = CommandType.StoredProcedure;

         try
        {
              cmd.Parameters.AddWithValue("@ItemId", itemid);
              cmd.Parameters.AddWithValue("@DeptId", DeptId);
              cmd.Parameters.AddWithValue("@BranchId", BranchId);
              cmd.Parameters.AddWithValue("@FId", FId);
     
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                
                objBELBatch.BatchNo = Convert.ToString(sdr["BatchNo"]);
                objBELBatch.CurrStock = Convert.ToDecimal(sdr["CurrentStock"]);
                objBELBatch.InvoiceExpdate = Convert.ToString(sdr["ExpDate"]);
               // objBEL.Add(objBELBatch);

            }
            return objBELBatch;
        }
        catch (SqlException)
        {
            throw;
        }
        finally
        {
            con.Close();
        }
    }
    public BEL FillBatchNoForDept_CurrentStock(int itemid, int DeptId, int BranchId, int FId,string BatchNo,int WareHouseId)
    {
        //List<BEL> objBEL = new List<BEL>();

        BEL objBELBatch = new BEL();
        SqlConnection con = DataAccess.ConInitForPharmacy();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_FillBatchNoForDept_CurrentStock", con);
        cmd.CommandType = CommandType.StoredProcedure;

        try
        {
            cmd.Parameters.AddWithValue("@ItemId", itemid);
            cmd.Parameters.AddWithValue("@DeptId", DeptId);
            cmd.Parameters.AddWithValue("BatchNo", BatchNo);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@WareHouseId", WareHouseId);

            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {

                objBELBatch.BatchNo = Convert.ToString(sdr["BatchNo"]);
                objBELBatch.CurrStock = Convert.ToDecimal(sdr["CurrentStock"]);
                objBELBatch.InvoiceExpdate = Convert.ToString(sdr["ExpDate"]);
                // objBEL.Add(objBELBatch);

            }
            return objBELBatch;
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

    public BEL FillBatchNoForDept_CurrentStock_ManualConsuption(int itemid, int DeptId, int BranchId, int FId, string BatchNo)
    {
        //List<BEL> objBEL = new List<BEL>();

        BEL objBELBatch = new BEL();
        SqlConnection con = DataAccess.ConInitForPharmacy();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_FillBatchNoForDept_CurrentStockForManualConsuption", con);
        cmd.CommandType = CommandType.StoredProcedure;

        try
        {
            cmd.Parameters.AddWithValue("@ItemId", itemid);
            cmd.Parameters.AddWithValue("@DeptId", DeptId);
            cmd.Parameters.AddWithValue("BatchNo", BatchNo);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.Parameters.AddWithValue("@FId", FId);

            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {

                objBELBatch.BatchNo = Convert.ToString(sdr["BatchNo"]);
                objBELBatch.CurrStock = Convert.ToDecimal(sdr["CurrentStock"]);
                objBELBatch.InvoiceExpdate = Convert.ToString(sdr["ExpDate"]);
                // objBEL.Add(objBELBatch);

            }
            return objBELBatch;
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



    public BEL GetItemDetailsForPatIssueVoucher(BEL ObjBEL)
    {
       // 
        SqlConnection con = DataAccess.ConInitForPharmacy();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetItemDetailsForPatIssueVoucher", con);
        cmd.CommandType = CommandType.StoredProcedure;


        try
        {
            cmd.Parameters.AddWithValue("@DeptId", ObjBEL.DeptId);
            cmd.Parameters.AddWithValue("@ItemId", ObjBEL.ItemId);
            cmd.Parameters.AddWithValue("@BatchNo", ObjBEL.BatchNo);
            cmd.Parameters.AddWithValue("@PatientType", ObjBEL.PatientType.Trim());
            cmd.Parameters.AddWithValue("@FId", ObjBEL.Fid);
            cmd.Parameters.AddWithValue("@BranchId", ObjBEL.BranchId);
            cmd.Parameters.AddWithValue("@UserId", ObjBEL.UserID);
            BEL objBELDept = new BEL();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                objBELDept.PerPackCost = Convert.ToDecimal(sdr["PerPackCost"]);
                objBELDept.TaxPercentage = Convert.ToDecimal(sdr["TaxPercentage"]);
                //objBELDept.PrescItemPer = Convert.ToDecimal(sdr["PrescItemPer"]);
                //objBELDept.CounterItemPer = Convert.ToDecimal(sdr["CounterItemPer"]);


            }
            return objBELDept;
        }
        catch (SqlException)
        {
            throw;
        }
        finally
        {
            con.Close();
        }
    }

    public DataSet fillUnit()
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("SP_FillUnit", con);
        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        //da.SelectCommand.Parameters.AddWithValue("@Flag", "Select");
        DataSet ds = new DataSet();
        da.Fill(ds);
        return ds;
    }
    public void DeleteDepartment(BEL DeptInfo)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_ISUDDept", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("DeptId", DeptInfo.DeptId);
            cmd.Parameters.AddWithValue("@Flag", "Delete");
            cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            con.Dispose();
            con.Close();
        }

    }
    public void DeletePackage(BEL DeptInfo)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_ISUDPackage", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("PackageId", DeptInfo.PackageId);
            cmd.Parameters.AddWithValue("@Flag", "Delete");
            cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            con.Dispose();
            con.Close();
        }

    }
    public void DeletePackageDetails(BEL DeptInfo)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_DeletePackageDetails", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("PackageDetailId", DeptInfo.PackageDetailId);
            
            cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            con.Dispose();
            con.Close();
        }

    }
    public int CheckExistDept(BEL DeptInfo)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_CheckExist", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@DeptName", DeptInfo.DeptName);
            cmd.Parameters.AddWithValue("@Flag", "Department");
            int count = Convert.ToInt16(cmd.ExecuteScalar());
            con.Close();
            return count;
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            con.Dispose();
            con.Close();
        }



    }
    //______________________________________________END OF Department Code_____________________________________________________________________
    // ----------------------------------------------------------------------------------------------------------------------------------------------

    //______________________________________________Code For Supplier Information________________________________________________________________


    public void InsertSupplier(BEL SuppInfo)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_ISUDSupp", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            //cmd.Parameters.AddWithValue("@SupplierId", SuppInfo.SuppId);
            cmd.Parameters.AddWithValue("@SupplierName", SuppInfo.SuppName);
            cmd.Parameters.AddWithValue("@SupplierDesc", SuppInfo.SuppDesc);
            cmd.Parameters.AddWithValue("@SuppPANNo", SuppInfo.PANNo);
            cmd.Parameters.AddWithValue("@SuppGSTNo", SuppInfo.GSTNo);
            cmd.Parameters.AddWithValue("@SuppMobileNo", SuppInfo.MobileNo);
            cmd.Parameters.AddWithValue("@SuppEmailId", SuppInfo.EmailId);
           
            cmd.Parameters.AddWithValue("@BranchId", SuppInfo.BranchId);
            cmd.Parameters.AddWithValue("@Fid", SuppInfo.Fid);
            //cmd.Parameters.AddWithValue("@CreatedOn", SuppInfo.CreatedOn);
            cmd.Parameters.AddWithValue("@CreatedBy", SuppInfo.CreatedBy);
           // cmd.Parameters.AddWithValue("@UpdatedOn", SuppInfo.UpdatedOn);
            //cmd.Parameters.AddWithValue("@UpdatedBy", SuppInfo.UpdatedBy);
            cmd.Parameters.AddWithValue("@Flag", "Insert");
            cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            con.Dispose();
            con.Close();
        }

    }
    public void UpdateSupplier(BEL SuppInfo)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_ISUDSupp", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@SupplierId", SuppInfo.SuppId);
            cmd.Parameters.AddWithValue("@SupplierName", SuppInfo.SuppName);
            cmd.Parameters.AddWithValue("@SupplierDesc", SuppInfo.SuppDesc);
            cmd.Parameters.AddWithValue("@SuppPANNo",SuppInfo.PANNo);
            cmd.Parameters.AddWithValue("@SuppGSTNo",SuppInfo.GSTNo);
            cmd.Parameters.AddWithValue("@SuppMobileNo",SuppInfo.MobileNo);
            cmd.Parameters.AddWithValue("@SuppEmailId", SuppInfo.EmailId);
            cmd.Parameters.AddWithValue("@BranchId", SuppInfo.BranchId);
            cmd.Parameters.AddWithValue("@Fid", SuppInfo.Fid);
            //cmd.Parameters.AddWithValue("@CreatedOn", SuppInfo.CreatedOn);
            //cmd.Parameters.AddWithValue("@CreatedBy", SuppInfo.CreatedBy);
           // cmd.Parameters.AddWithValue("@UpdatedOn", SuppInfo.UpdatedOn);
            cmd.Parameters.AddWithValue("@UpdatedBy", SuppInfo.UpdatedBy);
            cmd.Parameters.AddWithValue("@Flag", "Update");
            cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            con.Dispose();
            con.Close();
        }

    }

    public DataSet fillSupp()
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("Sp_ISUDSupp", con);
        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        da.SelectCommand.Parameters.AddWithValue("@Flag", "Select");
        DataSet ds = new DataSet();
        da.Fill(ds);
        return ds;
    }
    public void DeleteSupplier(BEL SuppInfo)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_ISUDSupp", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@SupplierId", SuppInfo.SuppId);
            cmd.Parameters.AddWithValue("@Flag", "Delete");
            cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            con.Dispose();
            con.Close();
        }

    }

    public int CheckExistSupp(BEL SuppInfo)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_CheckExist", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@SupplierName", SuppInfo.SuppName);
            cmd.Parameters.AddWithValue("@Flag", "Supplier");
            int count = Convert.ToInt16(cmd.ExecuteScalar());
            con.Close();
            return count;
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            con.Dispose();
            con.Close();
        }



    }

    //_______________________________________________End OF Supplier Code__________________________________________________________________________
    // ----------------------------------------------------------------------------------------------------------------------------------------------

    //________________________________Code For Manufacturing Company____________________________________________________
    //--------------------------------------------------------------------------------------------------------------------------------------------------------

    public void InsertMfg(BEL MfgInfo)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_ISUDmfg", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@MfgCompName", MfgInfo.MfgCompName);
            cmd.Parameters.AddWithValue("@MfgCompDesc", MfgInfo.MfgCompDesc);
            cmd.Parameters.AddWithValue("@BranchId", MfgInfo.BranchId);
            cmd.Parameters.AddWithValue("@Fid", MfgInfo.Fid);
            cmd.Parameters.AddWithValue("@CreatedOn", MfgInfo.CreatedOn);
            cmd.Parameters.AddWithValue("@CreatedBy", MfgInfo.CreatedBy);
            cmd.Parameters.AddWithValue("@UpdatedOn", MfgInfo.UpdatedOn);
            cmd.Parameters.AddWithValue("@UpdatedBy", MfgInfo.UpdatedBy);
            cmd.Parameters.AddWithValue("@Flag", "Insert");
            cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            con.Dispose();
            con.Close();
        }

    }
    public void UpdateMfg(BEL MfgInfo)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_ISUDmfg", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@MfgCompId", MfgInfo.MfgCompId);
            cmd.Parameters.AddWithValue("@MfgCompName", MfgInfo.MfgCompName);
            cmd.Parameters.AddWithValue("@MfgCompDesc", MfgInfo.MfgCompDesc);
            cmd.Parameters.AddWithValue("@BranchId", MfgInfo.BranchId);
            cmd.Parameters.AddWithValue("@Fid", MfgInfo.Fid);
            cmd.Parameters.AddWithValue("@CreatedOn", MfgInfo.CreatedOn);
            cmd.Parameters.AddWithValue("@CreatedBy", MfgInfo.CreatedBy);
            cmd.Parameters.AddWithValue("@UpdatedOn", MfgInfo.UpdatedOn);
            cmd.Parameters.AddWithValue("@UpdatedBy", MfgInfo.UpdatedBy);
            cmd.Parameters.AddWithValue("@Flag", "Update");

            cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            con.Dispose();
            con.Close();
        }

    }

    public DataSet fillMfg()
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("Sp_ISUDmfg", con);
        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        da.SelectCommand.Parameters.AddWithValue("@Flag", "Select");
        DataSet ds = new DataSet();
        da.Fill(ds);
        return ds;
    }
    public void DeleteMfg(BEL MfgInfo)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_ISUDmfg", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@MfgCompId", MfgInfo.MfgCompId);
            cmd.Parameters.AddWithValue("@Flag", "Delete");
            cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            con.Dispose();
            con.Close();
        }

    }

    public int CheckMfgExists(BEL MfgInfo)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_CheckExist", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@MfgCompName", MfgInfo.MfgCompName);
            cmd.Parameters.AddWithValue("@Flag", "MfgComp");
            int count = Convert.ToInt16(cmd.ExecuteScalar());
            con.Close();
            return count;
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            con.Dispose();
            con.Close();
        }

    }

    //_______________________________________________End OF Manufacturing Code__________________________________________________________________________
    // ----------------------------------------------------------------------------------------------------------------------------------------------

    //_______________________________________Code For Items List__________________________________________________________________________

    public string InsertItem(BEL ItemInfo)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_ISUDItem", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@ItemName", ItemInfo.ItemName);
            cmd.Parameters.AddWithValue("@ItemDesc", ItemInfo.ItemDesc);
            cmd.Parameters.AddWithValue("@ItemStatus", ItemInfo.ItemStatus);
            cmd.Parameters.AddWithValue("@Category",ItemInfo.CategoryId);
           // cmd.Parameters.AddWithValue("@BatchNo",ItemInfo.BatchNo);
	        //cmd.Parameters.AddWithValue("@MgfCompany",ItemInfo.MfgCompId);
	       // cmd.Parameters.AddWithValue("@CurrentStock",ItemInfo.CurrStock);
	        cmd.Parameters.AddWithValue("@UnitsPerPack",ItemInfo.UnitsPerPack);
	        cmd.Parameters.AddWithValue("@Unit",ItemInfo.units);
	        cmd.Parameters.AddWithValue("@CostPerUnit",ItemInfo.CostPerUnit);
	        cmd.Parameters.AddWithValue("@ReorderLevel",ItemInfo.ReorderLevel);
           // cmd.Parameters.AddWithValue("@Supplier", ItemInfo.SuppId);
	
            cmd.Parameters.AddWithValue("@BranchId", ItemInfo.BranchId);
            cmd.Parameters.AddWithValue("@Fid", ItemInfo.Fid);
           
            cmd.Parameters.AddWithValue("@CreatedBy", ItemInfo.CreatedBy);
            cmd.Parameters.AddWithValue("@SKU", ItemInfo.SKU);
            cmd.Parameters.AddWithValue("@TaxType", ItemInfo.TaxType);
            cmd.Parameters.AddWithValue("@ItemType", ItemInfo.ItemType);
            cmd.Parameters.AddWithValue("@MainCategory", ItemInfo.MainCategory);

            cmd.Parameters.AddWithValue("@MarkUpOPD", ItemInfo.MarkupOPD);
            cmd.Parameters.AddWithValue("@MarkUpIPD", ItemInfo.MarkupIPD);


            cmd.Parameters.AddWithValue("@MedicineTypeId", ItemInfo.MedicineTypeId);
            cmd.Parameters.AddWithValue("@PackSizeID", ItemInfo.PackSizeID);
            cmd.Parameters.AddWithValue("@SubcatID", ItemInfo.SubcatID);
            cmd.Parameters.AddWithValue("@MRP", ItemInfo.MRP);
            cmd.Parameters.AddWithValue("@ExpiryDtRequired", ItemInfo.ExpiryDtRequired);
            cmd.Parameters.AddWithValue("@BatchRequired", ItemInfo.BatchRequired);
            cmd.Parameters.AddWithValue("@IsNonChargable", ItemInfo.IsNonChargable);
            cmd.Parameters.AddWithValue("@NoMrp", ItemInfo.NoMrp);
            cmd.Parameters.AddWithValue("@Asset", ItemInfo.Asset);
            cmd.Parameters.AddWithValue("@HighValueFlag", ItemInfo.HighValueFlag);
            cmd.Parameters.AddWithValue("@scheduledItem", ItemInfo.scheduledItem);
            cmd.Parameters.AddWithValue("@narcoticItem", ItemInfo.narcoticItem);
            cmd.Parameters.AddWithValue("@CriticalMedicine", ItemInfo.CriticalMedicine);
            cmd.Parameters.AddWithValue("@Isxrayfilm", ItemInfo.Isxrayfilm);
            cmd.Parameters.AddWithValue("@IsApproval", ItemInfo.IsApproval);
            cmd.Parameters.AddWithValue("@Active", ItemInfo.Active);
            cmd.Parameters.AddWithValue("@WareHouseId", ItemInfo.WareHouseId);
           
           
            cmd.Parameters.AddWithValue("@Flag", "Insert");

            object Result=cmd.ExecuteScalar();
            return Convert.ToString(Result);
            
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            con.Dispose();
            con.Close();
        }

    }
    public string UpdateItem(BEL ItemInfo)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_ISUDItem", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@ItemId", ItemInfo.ItemId);
            cmd.Parameters.AddWithValue("@ItemName", ItemInfo.ItemName);
            cmd.Parameters.AddWithValue("@ItemDesc", ItemInfo.ItemDesc);
            cmd.Parameters.AddWithValue("@ItemStatus", ItemInfo.ItemStatus);
            cmd.Parameters.AddWithValue("@Category", ItemInfo.CategoryId);
           // cmd.Parameters.AddWithValue("@BatchNo", ItemInfo.BatchNo);
           // cmd.Parameters.AddWithValue("@MgfCompany", ItemInfo.MfgCompId);
           // cmd.Parameters.AddWithValue("@CurrentStock", ItemInfo.CurrStock);
            cmd.Parameters.AddWithValue("@UnitsPerPack", ItemInfo.UnitsPerPack);
            cmd.Parameters.AddWithValue("@Unit", ItemInfo.units);
            cmd.Parameters.AddWithValue("@CostPerUnit", ItemInfo.CostPerUnit);
            cmd.Parameters.AddWithValue("@ReorderLevel", ItemInfo.ReorderLevel);
           // cmd.Parameters.AddWithValue("@Supplier", ItemInfo.SuppId);

            cmd.Parameters.AddWithValue("@BranchId", ItemInfo.BranchId);
            cmd.Parameters.AddWithValue("@Fid", ItemInfo.Fid);
            cmd.Parameters.AddWithValue("@SKU", ItemInfo.SKU);
            cmd.Parameters.AddWithValue("@TaxType", ItemInfo.TaxType);
            cmd.Parameters.AddWithValue("@ItemType", ItemInfo.ItemType);           
           
            cmd.Parameters.AddWithValue("@UpdatedBy", ItemInfo.UpdatedBy);
            //cmd.Parameters.AddWithValue("@UpdatedBy", ItemInfo.UpdatedBy);
            cmd.Parameters.AddWithValue("@MainCategory", ItemInfo.MainCategory);
            cmd.Parameters.AddWithValue("@MarkUpOPD", ItemInfo.MarkupOPD);
            cmd.Parameters.AddWithValue("@MarkUpIPD", ItemInfo.MarkupIPD);


            cmd.Parameters.AddWithValue("@MedicineTypeId", ItemInfo.MedicineTypeId);
            cmd.Parameters.AddWithValue("@PackSizeID", ItemInfo.PackSizeID);
            cmd.Parameters.AddWithValue("@SubcatID", ItemInfo.SubcatID);
            cmd.Parameters.AddWithValue("@MRP", ItemInfo.MRP);
            cmd.Parameters.AddWithValue("@ExpiryDtRequired", ItemInfo.ExpiryDtRequired);
            cmd.Parameters.AddWithValue("@BatchRequired", ItemInfo.BatchRequired);
            cmd.Parameters.AddWithValue("@IsNonChargable", ItemInfo.IsNonChargable);
            cmd.Parameters.AddWithValue("@NoMrp", ItemInfo.NoMrp);
            cmd.Parameters.AddWithValue("@Asset", ItemInfo.Asset);
            cmd.Parameters.AddWithValue("@HighValueFlag", ItemInfo.HighValueFlag);
            cmd.Parameters.AddWithValue("@scheduledItem", ItemInfo.scheduledItem);
            cmd.Parameters.AddWithValue("@narcoticItem", ItemInfo.narcoticItem);
            cmd.Parameters.AddWithValue("@CriticalMedicine", ItemInfo.CriticalMedicine);
            cmd.Parameters.AddWithValue("@Isxrayfilm", ItemInfo.Isxrayfilm);
            cmd.Parameters.AddWithValue("@IsApproval", ItemInfo.IsApproval);
            cmd.Parameters.AddWithValue("@Active", ItemInfo.Active);
            cmd.Parameters.AddWithValue("@WareHouseId", ItemInfo.WareHouseId);


            cmd.Parameters.AddWithValue("@Flag", "Update");

           object Result= cmd.ExecuteScalar();
           return Convert.ToString(Result);
            
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            con.Dispose();
            con.Close();
        }

    }

    public DataSet fillItem()
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("Sp_ISUDItem", con);
        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        da.SelectCommand.Parameters.AddWithValue("@Flag", "Select");
        DataSet ds = new DataSet();
        da.Fill(ds);
        return ds;
    }

    public DataSet fillItem_WareHouse(int WareHouseId)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("Sp_ISUDItem", con);
        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        da.SelectCommand.Parameters.AddWithValue("@Flag", "Select_WareHouse");
        da.SelectCommand.Parameters.AddWithValue("@WareHouseId", WareHouseId);
        DataSet ds = new DataSet();
        da.Fill(ds);
        return ds;
    }
   
    public string DeleteItem(BEL ItemInfo)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_ISUDItem", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@ItemId", ItemInfo.ItemId);
            cmd.Parameters.AddWithValue("@Flag", "Delete");
            object Result= cmd.ExecuteScalar();
            return Convert.ToString(Result);
            
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            con.Dispose();
            con.Close();
        }

    }

    public int CheckItemExists(BEL ItemInfo)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_CheckExist", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@ItemName", ItemInfo.ItemName);
            cmd.Parameters.AddWithValue("@Flag", "Item");
            int count = Convert.ToInt16(cmd.ExecuteScalar());
            con.Close();
            return count;
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            con.Dispose();
            con.Close();
        }

    }
    public List<string> AutoFillItems(string prefixtext,int WareHouseId)
    {
        // BEL ItemInfo = new BEL();

        SqlConnection con = new SqlConnection(constr);
        con.Open();
        //con.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;//ToString();

        try
        {
        SqlCommand cmd = new SqlCommand("Sp_GetList", con);
       
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Search", prefixtext);
            cmd.Parameters.AddWithValue("@WareHouseId", WareHouseId);
            cmd.Parameters.AddWithValue("@Flag", "ItemList");
                      
            List<string> items = new List<string>();
            SqlDataReader sdr = cmd.ExecuteReader();
           
                while (sdr.Read())
                {
                    items.Add(sdr["ItemName"].ToString());
                }
            


            return items;
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
    
     public List<string> AutoFillInvoiceItemsWithId(string prefixtext)
    {
        // BEL ItemInfo = new BEL();

        SqlConnection con = new SqlConnection(constr);
        con.Open();
        //con.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;//ToString();

        try
        {
        SqlCommand cmd = new SqlCommand("Sp_GetList", con);
       
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Search", prefixtext);
            cmd.Parameters.AddWithValue("@Flag", "InvoiceItemList");
                      
            List<string> items = new List<string>();
            SqlDataReader sdr = cmd.ExecuteReader();
           
                while (sdr.Read())
                {
                    items.Add(sdr["ItemName"].ToString());
                }
            


            return items;
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
    public List<string> AutoFillPurchItems(string prefixtext,int WareHouseId)
    {
        // BEL ItemInfo = new BEL();

        SqlConnection con = new SqlConnection(constr);
        con.Open();
        //con.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;//ToString();

        try
        {
            SqlCommand cmd = new SqlCommand("Sp_GetList", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Search", prefixtext);
            cmd.Parameters.AddWithValue("@WareHouseId", WareHouseId);
            cmd.Parameters.AddWithValue("@Flag", "PurchaseItemListFill");

            List<string> items = new List<string>();
            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                items.Add(sdr["ItemName"].ToString());
            }



            return items;
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

    public List<string> AutoFillPurchItems_ForIndent(string prefixtext,int CategoryId)
    {
        // BEL ItemInfo = new BEL();

        SqlConnection con = new SqlConnection(constr);
        con.Open();
        //con.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;//ToString();

        try
        {
            SqlCommand cmd = new SqlCommand("Sp_GetList_ForIndent", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Search", prefixtext);
            cmd.Parameters.AddWithValue("@MainCategory", CategoryId);
            cmd.Parameters.AddWithValue("@Flag", "PurchaseItemListFill");

            List<string> items = new List<string>();
            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                items.Add(sdr["ItemName"].ToString());
            }



            return items;
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

    public List<string> AutoFillPurchItemsWithId(string prefixtext)
    {
        // BEL ItemInfo = new BEL();

        SqlConnection con = new SqlConnection(constr);
        con.Open();
        //con.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;//ToString();

        try
        {
            SqlCommand cmd = new SqlCommand("Sp_GetListOfItemWithId", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Search", prefixtext);
            //cmd.Parameters.AddWithValue("@Flag", "PurchaseItemList");

            List<string> items = new List<string>();
            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                items.Add(sdr["ItemName"].ToString());
            }



            return items;
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

    public List<string> AutoFillCategoryWithId(string prefixtext)
    {
        // BEL ItemInfo = new BEL();

        SqlConnection con = new SqlConnection(constr);
        con.Open();
        //con.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;//ToString();

        try
        {
            SqlCommand cmd = new SqlCommand("Sp_GetListOfCategoryWithId", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Search", prefixtext);
            //cmd.Parameters.AddWithValue("@Flag", "PurchaseItemList");

            List<string> items = new List<string>();
            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                items.Add(sdr["CategoryName"].ToString());
            }



            return items;
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


    public List<string> AutoFillTestName(string prefixtext)
    {
        // BEL ItemInfo = new BEL();

        SqlConnection con = new SqlConnection(constr);
        string[] Database = constrLab.Split(';');
        string InitialCatalog = Database[1];
        string[] db = InitialCatalog.Split('=');
        string DbName = db[1];
        con.Open();
        //con.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;//ToString();

        try
        {
            SqlCommand cmd = new SqlCommand("Sp_GetTestName", con);
       
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Search", prefixtext);
            cmd.Parameters.AddWithValue("@database", DbName);
                      
            List<string> Tests = new List<string>();
            SqlDataReader sdr = cmd.ExecuteReader();
           
                while (sdr.Read())
                {
                    Tests.Add(sdr["TestName"].ToString());
                }
            


            return Tests;
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

    public List<string> AutoFillSupplier(string prefixtext)
    {
        
        SqlConnection con = new SqlConnection(constr);
        con.Open();
       
        try
        {
            SqlCommand cmd = new SqlCommand("Sp_GetList", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Search", prefixtext);
            cmd.Parameters.AddWithValue("@Flag", "SupplierList");
            List<string> suppliers = new List<string>();
            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                suppliers.Add(sdr["SupplierName"].ToString());
            }



            return suppliers;
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
    public List<string> AutoFillDoctors(string prefixtext)
    {

        SqlConnection con = new SqlConnection(constr);
        con.Open();

        try
        {
            SqlCommand cmd = new SqlCommand("Sp_GetDoctorList", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Search", prefixtext);
           // cmd.Parameters.AddWithValue("@Flag", "SupplierList");
            List<string> Doctors = new List<string>();
            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                Doctors.Add(sdr["DoctorName"].ToString());
            }



            return Doctors;
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
    public List<string> AutoFillCategory(string prefixtext)
    {

        SqlConnection con = new SqlConnection(constr);
        con.Open();

        try
        {
            SqlCommand cmd = new SqlCommand("Sp_GetList", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Search", prefixtext);
            cmd.Parameters.AddWithValue("@Flag", "CategoryList");
            List<string> Category = new List<string>();
            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                Category.Add(sdr["CategoryName"].ToString());
            }



            return Category;
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

    public List<string> AutoFillMfgCompList(string prefixtext)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetList", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@Search", prefixtext);
            cmd.Parameters.AddWithValue("@Flag", "MfgCompList");
            List<string> Mgfcomp = new List<string>();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                Mgfcomp.Add(sdr["MfgCompName"].ToString());
               
            }
            return Mgfcomp;
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
    public DataSet SearchReorderCurrentStock(BEL Itemstock)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Vw_ReorderLevel", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@ItemId", Itemstock.ItemId);
            //  cmd.Parameters.AddWithValue("@BatchNo", Itemstock.BatchNo);
            cmd.Parameters.AddWithValue("@CategoryId", Itemstock.CategoryId);
            cmd.Parameters.AddWithValue("@MainCategory", Itemstock.MainCategory);
            cmd.Parameters.AddWithValue("@BranchId", Itemstock.BranchId);
            cmd.Parameters.AddWithValue("@FId", Itemstock.Fid);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Dispose();
            con.Close();
        }


    }
    public void InsertPoInfo(BEL PoInfo)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_InsertPO", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@ItemId",PoInfo.ItemId);
            cmd.Parameters.AddWithValue("@PoDate",PoInfo.date);
            cmd.Parameters.AddWithValue("@PoNo",PoInfo.PONo);           
            cmd.Parameters.AddWithValue("@SupplierId",PoInfo.SuppId);
           // cmd.Parameters.AddWithValue("@MfgCompId",PoInfo.MfgCompId); 
            cmd.Parameters.AddWithValue("@Units",PoInfo.units);            
            cmd.Parameters.AddWithValue("@NoOfPacks",PoInfo.NoOfPacks);
            cmd.Parameters.AddWithValue("@PerPackCost", PoInfo.PerPackCost);
            cmd.Parameters.AddWithValue("@Tax",PoInfo.Tax); 
            cmd.Parameters.AddWithValue("@TotalAmt",PoInfo.TotalAmt);
            cmd.Parameters.AddWithValue("@Usage3Months", PoInfo.Usage3Months); 
            cmd.Parameters.AddWithValue("@CurrentStock", PoInfo.CurrStock);
            cmd.Parameters.AddWithValue("@BranchId", PoInfo.BranchId);
            cmd.Parameters.AddWithValue("@FId", PoInfo.Fid);
            cmd.Parameters.AddWithValue("@CreatedBy", PoInfo.CreatedBy);

            cmd.Parameters.AddWithValue("@PrevCost", PoInfo.PrevCost);
            cmd.Parameters.AddWithValue("@PackQty", PoInfo.PackQty);
            cmd.Parameters.AddWithValue("@UnitsPerPack", PoInfo.UnitsPerPack);
            cmd.Parameters.AddWithValue("@Remark", PoInfo.Remark);
            cmd.Parameters.AddWithValue("@WareHouseId", PoInfo.WareHouseId);
            cmd.ExecuteNonQuery();
            con.Close();
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

    public void InsertInvoiceInfo(BEL PoInfo)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_InsertInvoice", con);
        cmd.CommandType = CommandType.StoredProcedure;
        string Expdate="1/1/2000";
        try
        {
            cmd.Parameters.AddWithValue("@ItemId", PoInfo.ItemId);
            cmd.Parameters.AddWithValue("@InvoiceDate",DateTime.ParseExact(PoInfo.Invoicedate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            if (PoInfo.InvoiceExpdate != null)
            {
                cmd.Parameters.AddWithValue("@ExpDate", DateTime.ParseExact(PoInfo.InvoiceExpdate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
           
            cmd.Parameters.AddWithValue("@ChallanNo", PoInfo.ChallanNo);
            cmd.Parameters.AddWithValue("@PoNo", PoInfo.PONo);
            cmd.Parameters.AddWithValue("@InvoiceNo", PoInfo.InvoiceNo);
            cmd.Parameters.AddWithValue("@SupplierId", PoInfo.SuppId);
            cmd.Parameters.AddWithValue("@MfgCompId", PoInfo.MfgCompId);
           // cmd.Parameters.AddWithValue("@ExpStatus", PoInfo.ItemStatus);
            cmd.Parameters.AddWithValue("@BatchNo", PoInfo.BatchNo);
            cmd.Parameters.AddWithValue("@Units", PoInfo.units);
           
            cmd.Parameters.AddWithValue("@NoOfPacks", PoInfo.NoOfPacks);
            cmd.Parameters.AddWithValue("@Tax", PoInfo.Tax);
            cmd.Parameters.AddWithValue("@TotalAmt", PoInfo.TotalAmt);
           
            cmd.Parameters.AddWithValue("@PerPackCost", PoInfo.PerPackCost);
          //  cmd.Parameters.AddWithValue("@IsApprove", "NA");
            cmd.Parameters.AddWithValue("@BranchId", PoInfo.BranchId);
            cmd.Parameters.AddWithValue("@FId", PoInfo.Fid);
            cmd.Parameters.AddWithValue("@CreatedBy", PoInfo.CreatedBy);
            cmd.Parameters.AddWithValue("@InvoiceDetailId", PoInfo.InvoiceDetailId);


            cmd.Parameters.AddWithValue("@PerDis", PoInfo.Dis);
            cmd.Parameters.AddWithValue("@PerNo_Pack", PoInfo.NO_PAck);
            cmd.Parameters.AddWithValue("@PerUnitPack", PoInfo.UnitPack);
            cmd.Parameters.AddWithValue("@Per_PackCost", PoInfo.PackCost);
            cmd.Parameters.AddWithValue("@WareHouseId", PoInfo.WareHouseId);

            cmd.ExecuteNonQuery();
            con.Close();
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

    public void UpdateInvoiceInfo(BEL PoInfo)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_UpdateInvoice", con);
        cmd.CommandType = CommandType.StoredProcedure;
        string Expdate = "1/1/2000";
        try
        {
            cmd.Parameters.AddWithValue("@ItemId", PoInfo.ItemId);
            cmd.Parameters.AddWithValue("@InvoiceDate", DateTime.ParseExact(PoInfo.Invoicedate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            if (PoInfo.InvoiceExpdate != null)
            {
                cmd.Parameters.AddWithValue("@ExpDate", DateTime.ParseExact(PoInfo.InvoiceExpdate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }

            cmd.Parameters.AddWithValue("@ChallanNo", PoInfo.ChallanNo);
            cmd.Parameters.AddWithValue("@PoNo", PoInfo.PONo);
            cmd.Parameters.AddWithValue("@InvoiceNo", PoInfo.InvoiceNo);
            cmd.Parameters.AddWithValue("@SupplierId", PoInfo.SuppId);
            cmd.Parameters.AddWithValue("@MfgCompId", PoInfo.MfgCompId);
            // cmd.Parameters.AddWithValue("@ExpStatus", PoInfo.ItemStatus);
            cmd.Parameters.AddWithValue("@BatchNo", PoInfo.BatchNo);
            cmd.Parameters.AddWithValue("@Units", PoInfo.units);

            cmd.Parameters.AddWithValue("@NoOfPacks", PoInfo.NoOfPacks);
            cmd.Parameters.AddWithValue("@Tax", PoInfo.Tax);
            cmd.Parameters.AddWithValue("@TotalAmt", PoInfo.TotalAmt);
            cmd.Parameters.AddWithValue("@InvoiceId", PoInfo.InvoiceId);
            cmd.Parameters.AddWithValue("@PerPackCost", PoInfo.PerPackCost);
           // cmd.Parameters.AddWithValue("@IsApprove", "NA");
            cmd.Parameters.AddWithValue("@BranchId", PoInfo.BranchId);
            cmd.Parameters.AddWithValue("@FId", PoInfo.Fid);
            cmd.Parameters.AddWithValue("@UpdatedBy", PoInfo.CreatedBy);
            cmd.Parameters.AddWithValue("@InvoiceDetailId", PoInfo.InvoiceDetailId);

            cmd.Parameters.AddWithValue("@PerDis", PoInfo.Dis);
            cmd.Parameters.AddWithValue("@PerNo_Pack", PoInfo.NO_PAck);
            cmd.Parameters.AddWithValue("@PerUnitPack", PoInfo.UnitPack);
            cmd.Parameters.AddWithValue("@Per_PackCost", PoInfo.PackCost);

            cmd.Parameters.AddWithValue("@WareHouseId", PoInfo.WareHouseId);

            cmd.ExecuteNonQuery();
            con.Close();
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
    public void InsertStockDetails(BEL PoInfo)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_StockDetails", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@ItemId", PoInfo.ItemId);            
            cmd.Parameters.AddWithValue("@MfgCompId", PoInfo.MfgCompId);           
            cmd.Parameters.AddWithValue("@BatchNo", PoInfo.BatchNo);
           // cmd.Parameters.AddWithValue("@InvoiceNo", PoInfo.InvoiceNo);
            cmd.Parameters.AddWithValue("@UnitId", PoInfo.units);
            cmd.Parameters.AddWithValue("@CurrentStock", PoInfo.CurrStock);
           // cmd.Parameters.AddWithValue("@IsApprove", "NA");
            cmd.Parameters.AddWithValue("@BranchId", PoInfo.BranchId);
            cmd.Parameters.AddWithValue("@FId", PoInfo.Fid);
            cmd.Parameters.AddWithValue("@CreatedBy", PoInfo.CreatedBy);

            //cmd.Parameters.AddWithValue("@ExpDate", PoInfo.Expdate);
              if (PoInfo.InvoiceExpdate != null && PoInfo.InvoiceExpdate !="" && PoInfo.InvoiceExpdate !="NA")
              {
                  cmd.Parameters.AddWithValue("@ExpDate", DateTime.ParseExact(PoInfo.InvoiceExpdate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
              }
              cmd.Parameters.AddWithValue("@WareHouseId", PoInfo.WareHouseId);
            cmd.ExecuteNonQuery();
            con.Close();
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
    public void InsertDeptStockDetails(BEL PoInfo)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_DeptStockDetails", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@ItemId", PoInfo.ItemId);
            cmd.Parameters.AddWithValue("@DeptId", PoInfo.DeptId);
            cmd.Parameters.AddWithValue("@BatchNo", PoInfo.BatchNo);            
            cmd.Parameters.AddWithValue("@UnitId", PoInfo.units);
            cmd.Parameters.AddWithValue("@CurrentStock", PoInfo.CurrStock);           
            cmd.Parameters.AddWithValue("@BranchId", PoInfo.BranchId);
            cmd.Parameters.AddWithValue("@FId", PoInfo.Fid);
            cmd.Parameters.AddWithValue("@CreatedBy", PoInfo.CreatedBy);

            //cmd.Parameters.AddWithValue("@ExpDate", PoInfo.Expdate);
            if (PoInfo.InvoiceExpdate != null && PoInfo.InvoiceExpdate != "")
            {
                cmd.Parameters.AddWithValue("@ExpDate", DateTime.ParseExact(PoInfo.InvoiceExpdate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            cmd.Parameters.AddWithValue("@IssueTo", PoInfo.P_IssueTo);
            cmd.ExecuteNonQuery();
            con.Close();
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
    public int GetItemId(BEL IdOfItem)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_getId", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@ItemName", IdOfItem.ItemName);
            cmd.Parameters.AddWithValue("@Flag", "Item");
            int ItemId=0;
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                ItemId = Convert.ToInt32(sdr["ItemId"]);
            }
            return ItemId;
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

    public BEL GetItemInfo(int ItemId,int FId,int BranchId)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_SelectItem", con);
        cmd.CommandType = CommandType.StoredProcedure;
        BEL Item=new BEL();
        try
        {
            cmd.Parameters.AddWithValue("@ItemId",ItemId);
            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            //cmd.Parameters.AddWithValue("@Flag", "CurrentStk");
            //int Stock = 0;
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
               
                Item.ItemStatus = Convert.ToString(sdr["Itemstatus"]);               
                Item.MfgCompName = Convert.ToString(sdr["MfgCompName"]);
                Item.SuppName = Convert.ToString(sdr["SupplierName"]);
                Item.units = Convert.ToInt32(sdr["Unit"]);
              
               // Item.BatchNo=Convert.ToString(sdr["BatchNo"]);
               // Item.UnitsPerPack=Convert.ToInt32(sdr["UnitsPerPack"]);
               // Item.CostPerUnit = Convert.ToDecimal(sdr["CostPerUnit"]);
                Item.SuppId = Convert.ToInt32(sdr["Supplier"]);
                Item.MfgCompId = Convert.ToInt32(sdr["MgfCompany"]);
                Item.TaxTypeName =Convert.ToString(sdr["TaxTypeName"]);
                Item.TaxPercentage = Convert.ToDecimal(sdr["TaxPercentage"]);
                Item.PerPackCost = Convert.ToDecimal(sdr["PerPackCost"]);
            }
            return Item;
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
    public BEL GetItemWiseCurrentStockPO(int ItemId,int Fid,int BranchId)
    {
        BEL Item = new BEL();   
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Vw_ItemWiseCurrentStockPO", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ItemId", ItemId);
        cmd.Parameters.AddWithValue("@FId",Fid);
        cmd.Parameters.AddWithValue("@BranchId",BranchId);

        SqlDataReader sdr = cmd.ExecuteReader();
        while (sdr.Read())
        {
            Item.CurrStock = Convert.ToInt32(sdr["CurrentStock"]);           
        }
        return Item;

    }

    public BEL GetItemWiseCurrentStockPO_New(int ItemId, int Fid, int BranchId)
    {
        BEL Item = new BEL();
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Vw_ItemWiseCurrentStockPO_NEW", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ItemId", ItemId);
        cmd.Parameters.AddWithValue("@FId", Fid);
        cmd.Parameters.AddWithValue("@BranchId", BranchId);

        SqlDataReader sdr = cmd.ExecuteReader();
        while (sdr.Read())
        {
            Item.CurrStock = Convert.ToInt32(sdr["CurrentStock"]);
        }
        return Item;

    }

    public BEL GetInvoiceAmountDatails(int SupplierId, int InvoiceNo, int WareHouseId)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetInvoiceAmountDatails", con);
        cmd.CommandType = CommandType.StoredProcedure;
        BEL Invoice = new BEL();
        try
        {
            cmd.Parameters.AddWithValue("@SupplierId", SupplierId);
            cmd.Parameters.AddWithValue("@InvoiceNo",InvoiceNo);
            //int Stock = 0;
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                
                Invoice.TotalTax = Convert.ToDecimal(sdr["TotalTax"]);               
                Invoice.AmtWithoutTax = Convert.ToDecimal(sdr["AmtWithoutTax"]);
                Invoice.SumOfTotalAmt = Convert.ToDecimal(sdr["SumOfTotalAmount"]);
                
               
            }
            return Invoice;
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

    

    public int GetSupplierId(BEL IdOfSupp)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_getId", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@SupplierName", IdOfSupp.SuppName);
            cmd.Parameters.AddWithValue("@Flag", "Supplier");
            int SuppId = 0;
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                SuppId = Convert.ToInt32(sdr["SupplierId"]);
            }
            return SuppId;
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

    public int GetCatId(BEL IdOfCategory)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_getId", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@CategoryName", IdOfCategory.CategoryName);
            cmd.Parameters.AddWithValue("@Flag", "Category");
            int CatId = 0;
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                CatId = Convert.ToInt32(sdr["CategoryId"]);
            }
            return CatId;
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

    public int GetMfgCompId(BEL IdOfMfgCop)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_getId", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@MfgCompName", IdOfMfgCop.MfgCompName);
            cmd.Parameters.AddWithValue("@Flag", "MfgComp");
            int MfgCompId = 0;
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                MfgCompId = Convert.ToInt32(sdr["MfgCompId"]);
            }
            return MfgCompId;
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
    public DataTable FillPurchaseTrack(BEL purtrack)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetPurchaseTrack", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@FromDate", purtrack.FromDate);
        cmd.Parameters.AddWithValue("@ToDate", purtrack.ToDate);
        cmd.Parameters.AddWithValue("@SupplierName", purtrack.SuppName);
        cmd.Parameters.AddWithValue("@PoNo", purtrack.PONo);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //SqlDataReader sdr = cmd.ExecuteReader();
        //DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
       
    }

    public void DeletePurchase(BEL PurchDetails)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_DelPurchTrack", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@POId", PurchDetails.PoId);
            cmd.ExecuteNonQuery();
            con.Close();
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
    public DataSet BindDdlDept()
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_FillDdlDept", con);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        return ds;
    }
    public void InsertIndentRequest(BEL ItemInfo)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_IndentRequest", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@ReqId",ItemInfo.ReqId);                
	        cmd.Parameters.AddWithValue("@VoucherNo",ItemInfo.VoucherNo);
	        cmd.Parameters.AddWithValue("@DeptId",ItemInfo.DeptId);	      
	        cmd.Parameters.AddWithValue("@ItemId",ItemInfo.ItemId);
            cmd.Parameters.AddWithValue("@unit", ItemInfo.units);
            cmd.Parameters.AddWithValue("@BatchNo", ItemInfo.BatchNo);
            cmd.Parameters.AddWithValue("@CurrentStock", ItemInfo.CurrStock);
            cmd.Parameters.AddWithValue("@CostPrice", ItemInfo.PerPackCost);
            cmd.Parameters.AddWithValue("@Tax", ItemInfo.Tax);
            cmd.Parameters.AddWithValue("@TotalAmt", ItemInfo.TotalAmt);
	        cmd.Parameters.AddWithValue("@ReqQty",ItemInfo.ReqQty);
            cmd.Parameters.AddWithValue("@Remark", ItemInfo.Remark);
            cmd.Parameters.AddWithValue("@PendingQty", ItemInfo.PendingQty);
            cmd.Parameters.AddWithValue("@IssueQty", ItemInfo.IssueQty);
            cmd.Parameters.AddWithValue("@RPIflag", ItemInfo.RPIflag);
            cmd.Parameters.AddWithValue("@ReqDate", ItemInfo.ReqDate);
            cmd.Parameters.AddWithValue("@CreatedBy", ItemInfo.CreatedBy);
            cmd.Parameters.AddWithValue("@FId", ItemInfo.Fid);
            cmd.Parameters.AddWithValue("@BranchId", ItemInfo.BranchId);
            cmd.Parameters.AddWithValue("@IndreqDeptId", ItemInfo.IndreqDeptId);
            cmd.Parameters.AddWithValue("@IsApprove", "NA");
            cmd.Parameters.AddWithValue("@Flag", "InsertReq");
            cmd.Parameters.AddWithValue("@IssueTo", ItemInfo.P_IssueTo);
            cmd.Parameters.AddWithValue("@WareHouseId", ItemInfo.WareHouseId);  
            if (ItemInfo.InvoiceExpdate != null)
            {
                cmd.Parameters.AddWithValue("@ExpDate", DateTime.ParseExact(ItemInfo.InvoiceExpdate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }

            cmd.ExecuteNonQuery();
            con.Close();
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
    public void InsertIndentRequest_Warehouse(BEL ItemInfo)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_IndentRequest_Warehouse", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@ReqId", ItemInfo.ReqId);
            cmd.Parameters.AddWithValue("@VoucherNo", ItemInfo.VoucherNo);
            cmd.Parameters.AddWithValue("@DeptId", ItemInfo.DeptId);
            cmd.Parameters.AddWithValue("@ItemId", ItemInfo.ItemId);
            cmd.Parameters.AddWithValue("@unit", ItemInfo.units);
           // cmd.Parameters.AddWithValue("@BatchNo", ItemInfo.BatchNo);
            cmd.Parameters.AddWithValue("@CurrentStock", ItemInfo.CurrStock);
            cmd.Parameters.AddWithValue("@ReqQty", ItemInfo.ReqQty);
            cmd.Parameters.AddWithValue("@Remark", ItemInfo.Remark);
            cmd.Parameters.AddWithValue("@RPIflag", ItemInfo.RPIflag);
            cmd.Parameters.AddWithValue("@ReqDate", ItemInfo.ReqDate);
            cmd.Parameters.AddWithValue("@CreatedBy", ItemInfo.CreatedBy);
            cmd.Parameters.AddWithValue("@FId", ItemInfo.Fid);
            cmd.Parameters.AddWithValue("@BranchId", ItemInfo.BranchId);
            cmd.Parameters.AddWithValue("@IndreqDeptId", ItemInfo.IndreqDeptId);
            cmd.Parameters.AddWithValue("@IsApprove", "NA");
            cmd.Parameters.AddWithValue("@Flag", "InsertReqDetails_Warehouse");
            cmd.Parameters.AddWithValue("@IssueTo", ItemInfo.P_IssueTo);
            

            cmd.ExecuteNonQuery();
            con.Close();
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

    public void UpdateIndReqDept_Warehouse(BEL ItemInfo)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_UpdateIndRequestDept_Warehouse", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
       
            cmd.Parameters.AddWithValue("@UpdatedBy", ItemInfo.UpdatedBy);
            cmd.Parameters.AddWithValue("@FId", ItemInfo.Fid);
            cmd.Parameters.AddWithValue("@BranchId", ItemInfo.BranchId);
            cmd.Parameters.AddWithValue("@IndreqDeptId", ItemInfo.IndreqDeptId);

            cmd.ExecuteNonQuery();
            con.Close();
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
    public void UpdateIndReqDetails_Warehouse(BEL ItemInfo)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_UpdateIndRequestDetails_Warehouse", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@ReqId", ItemInfo.ReqId);
            cmd.Parameters.AddWithValue("@VoucherNo", ItemInfo.VoucherNo);
            cmd.Parameters.AddWithValue("@DeptId", ItemInfo.DeptId);
            cmd.Parameters.AddWithValue("@ItemId", ItemInfo.ItemId);            
            cmd.Parameters.AddWithValue("@unit", ItemInfo.units);
            cmd.Parameters.AddWithValue("@CurrentStock", ItemInfo.CurrStock);
            
            cmd.Parameters.AddWithValue("@ReqQty", ItemInfo.ReqQty);
            cmd.Parameters.AddWithValue("@Remark", ItemInfo.Remark);
            
            cmd.Parameters.AddWithValue("@RPIflag", ItemInfo.RPIflag);
            cmd.Parameters.AddWithValue("@UpdatedBy", ItemInfo.UpdatedBy);
            cmd.Parameters.AddWithValue("@IndReq", ItemInfo.IndReq);
            cmd.Parameters.AddWithValue("@FId", ItemInfo.Fid);
            cmd.Parameters.AddWithValue("@BranchId", ItemInfo.BranchId);
            cmd.Parameters.AddWithValue("@ReqDate", ItemInfo.ReqDate);
            cmd.Parameters.AddWithValue("@IndreqDeptId", ItemInfo.IndreqDeptId);
            cmd.Parameters.AddWithValue("@IssueTo", ItemInfo.P_IssueTo);
            cmd.Parameters.AddWithValue("@WareHouseId", ItemInfo.WareHouseId);
            cmd.Parameters.AddWithValue("@IssueToWareHouse", ItemInfo.Issue_ToWareHouseId);

            cmd.ExecuteNonQuery();
            con.Close();
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
    public void UpdateIndReqDept(BEL ItemInfo)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_UpdateIndRequstDept", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@SumOfTotalAmount", ItemInfo.SumOfTotalAmt);
            cmd.Parameters.AddWithValue("@TotalTax", ItemInfo.TotalTax);
            cmd.Parameters.AddWithValue("@AmtWithoutTax", ItemInfo.AmtWithoutTax);           
            cmd.Parameters.AddWithValue("@UpdatedBy", ItemInfo.UpdatedBy);
            cmd.Parameters.AddWithValue("@FId", ItemInfo.Fid);
            cmd.Parameters.AddWithValue("@BranchId", ItemInfo.BranchId);            
            cmd.Parameters.AddWithValue("@IndreqDeptId", ItemInfo.IndreqDeptId);
            cmd.Parameters.AddWithValue("@WareHouseId", ItemInfo.WareHouseId);
           
            cmd.ExecuteNonQuery();
            con.Close();
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

    public void UpdateReq(BEL ItemInfo)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_UpdateIndRequst", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@ReqId", ItemInfo.ReqId);
            cmd.Parameters.AddWithValue("@VoucherNo", ItemInfo.VoucherNo);
            cmd.Parameters.AddWithValue("@DeptId", ItemInfo.DeptId);            
            cmd.Parameters.AddWithValue("@ItemId", ItemInfo.ItemId);           
            cmd.Parameters.AddWithValue("@BatchNo", ItemInfo.BatchNo);
            cmd.Parameters.AddWithValue("@unit", ItemInfo.units);
            cmd.Parameters.AddWithValue("@CurrentStock", ItemInfo.CurrStock);
            cmd.Parameters.AddWithValue("@CostPrice", ItemInfo.PerPackCost);
            cmd.Parameters.AddWithValue("@Tax", ItemInfo.Tax);
            cmd.Parameters.AddWithValue("@TotalAmt", ItemInfo.TotalAmt);	      
            cmd.Parameters.AddWithValue("@ReqQty", ItemInfo.ReqQty);
            cmd.Parameters.AddWithValue("@Remark", ItemInfo.Remark);
            cmd.Parameters.AddWithValue("@PendingQty", ItemInfo.PendingQty);
            cmd.Parameters.AddWithValue("@IssueQty", ItemInfo.IssueQty);
            cmd.Parameters.AddWithValue("@RPIflag", ItemInfo.RPIflag);
            cmd.Parameters.AddWithValue("@UpdatedBy", ItemInfo.UpdatedBy);
            cmd.Parameters.AddWithValue("@IndReq", ItemInfo.IndReq);
            cmd.Parameters.AddWithValue("@FId", ItemInfo.Fid);
            cmd.Parameters.AddWithValue("@BranchId", ItemInfo.BranchId);
            cmd.Parameters.AddWithValue("@ReqDate", ItemInfo.ReqDate);
            cmd.Parameters.AddWithValue("@IndreqDeptId", ItemInfo.IndreqDeptId);
            cmd.Parameters.AddWithValue("@IssueTo", ItemInfo.P_IssueTo);
            cmd.Parameters.AddWithValue("@WareHouseId", ItemInfo.WareHouseId);  
            if (ItemInfo.InvoiceExpdate != null && ItemInfo.InvoiceExpdate != "&nbsp;" && ItemInfo.InvoiceExpdate != "" && ItemInfo.InvoiceExpdate != "NA")
            {
                cmd.Parameters.AddWithValue("@ExpDate", DateTime.ParseExact(ItemInfo.InvoiceExpdate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }

            //cmd.Parameters.AddWithValue("@Flag", "InsertReq");

            cmd.ExecuteNonQuery();
            con.Close();
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
    public int InsertIndentDept_Warehouse(BEL ItemInfo)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_IndentRequest_Warehouse", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@ReqId", ItemInfo.ReqId);
            cmd.Parameters.AddWithValue("@VoucherNo", ItemInfo.VoucherNo);
            cmd.Parameters.AddWithValue("@DeptId", ItemInfo.DeptId);
            cmd.Parameters.AddWithValue("@Remark", ItemInfo.Remark);
            cmd.Parameters.AddWithValue("@RPIflag", ItemInfo.RPIflag);
            cmd.Parameters.AddWithValue("@ReqDate", ItemInfo.ReqDate);
            cmd.Parameters.AddWithValue("@BranchId", ItemInfo.BranchId);
            cmd.Parameters.AddWithValue("@FId", ItemInfo.Fid);
            cmd.Parameters.AddWithValue("@IssueTo", ItemInfo.P_IssueTo);
            cmd.Parameters.AddWithValue("@IsApprove", "NA");
            cmd.Parameters.AddWithValue("@Flag", "InsertReqDept_Warehouse");
            cmd.Parameters.Add("@IndreqDeptId", SqlDbType.Int).Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();
            int IndreqDeptId = Convert.ToInt32(cmd.Parameters["@IndreqDeptId"].Value);//.ToString();
            return IndreqDeptId;



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

   
    public int InsertIndentDept(BEL ItemInfo)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_IndentRequest", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@ReqId", ItemInfo.ReqId);
            cmd.Parameters.AddWithValue("@VoucherNo", ItemInfo.VoucherNo);
            cmd.Parameters.AddWithValue("@DeptId", ItemInfo.DeptId);
            cmd.Parameters.AddWithValue("@Remark", ItemInfo.Remark);            
            cmd.Parameters.AddWithValue("@RPIflag", ItemInfo.RPIflag);
            cmd.Parameters.AddWithValue("@ReqDate", ItemInfo.ReqDate);
            cmd.Parameters.AddWithValue("@BranchId", ItemInfo.BranchId);
            cmd.Parameters.AddWithValue("@FId", ItemInfo.Fid);
            cmd.Parameters.AddWithValue("@SumOfTotalAmount", ItemInfo.SumOfTotalAmt);
            cmd.Parameters.AddWithValue("@TotalTax", ItemInfo.TotalTax);
            cmd.Parameters.AddWithValue("@AmtWithoutTax", ItemInfo.AmtWithoutTax);
            cmd.Parameters.AddWithValue("@IssueTo", ItemInfo.P_IssueTo);  
            cmd.Parameters.AddWithValue("@IsApprove", "NA");
            cmd.Parameters.AddWithValue("@Flag", "InsertReqDept");
            cmd.Parameters.AddWithValue("@WareHouseId", ItemInfo.WareHouseId); 
            cmd.Parameters.Add("@IndreqDeptId", SqlDbType.Int).Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();
            int IndreqDeptId = Convert.ToInt32(cmd.Parameters["@IndreqDeptId"].Value);//.ToString();
            return IndreqDeptId;

           
           
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

    public void UpdateIndentReq(BEL ItemInfo)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_IndentRequest", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@ReqId", ItemInfo.ReqId);
            cmd.Parameters.AddWithValue("@ItemId", ItemInfo.ItemId);
           //cmd.Parameters.AddWithValue("@VoucherNo", ItemInfo.VoucherNo);
            cmd.Parameters.AddWithValue("@DeptId", ItemInfo.IssueToDept);
            cmd.Parameters.AddWithValue("@PendingQty", ItemInfo.PendingQty);
            cmd.Parameters.AddWithValue("@IssueQty", ItemInfo.IssueQty);
            cmd.Parameters.AddWithValue("@RPIflag", ItemInfo.RPIflag);
            //cmd.Parameters.AddWithValue("@IssueDate", ItemInfo.IssueDate);
            cmd.Parameters.AddWithValue("@BatchNo", ItemInfo.BatchNo);
            cmd.Parameters.AddWithValue("@Flag", "UpdateIndRequest");
            cmd.ExecuteNonQuery();
            con.Close();
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

    public void UpdateIndentReqRejected(BEL ItemInfo)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_IndentRequest", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@ReqId", ItemInfo.ReqId);
            cmd.Parameters.AddWithValue("@ItemId", ItemInfo.ItemId);            
            cmd.Parameters.AddWithValue("@DeptId", ItemInfo.IssueToDept);           
            cmd.Parameters.AddWithValue("@RPIflag", ItemInfo.RPIflag);
           //cmd.Parameters.AddWithValue("@IssueDate", ItemInfo.IssueDate);
            cmd.Parameters.AddWithValue("@BatchNo", ItemInfo.BatchNo);
            cmd.Parameters.AddWithValue("@Flag", "UpdateIndRequestRejFlag");
            cmd.ExecuteNonQuery();
            con.Close();
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
    

    public void InsertVouchNo(BEL vouchInfo)
    {
         SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetAutoVouchNo", con);
        cmd.CommandType = CommandType.StoredProcedure;
       try
        { 
           cmd.Parameters.AddWithValue("@VoucherNO", vouchInfo.VoucherNo);
           cmd.Parameters.AddWithValue("@Flag", "InsertNo");
           cmd.ExecuteNonQuery();
        
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Dispose();
            con.Close();
        }

    }

    public int GetAutoVouchNo(BELPatientIssueVoucher obj)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetAutoVouchNo", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@FId", obj.Fid);
            cmd.Parameters.AddWithValue("@BranchId", obj.BranchId);
            cmd.Parameters.AddWithValue("@DeptId", obj.DeptId);
            cmd.Parameters.AddWithValue("@wareHouseId", obj.wareHouseId);
            cmd.Parameters.AddWithValue("@Flag", "GetNo");
            object count = Convert.ToInt32(cmd.ExecuteScalar());
            return Convert.ToInt32(count);
            //int count = Convert.ToInt16(cmd.ExecuteScalar())+1;
            //con.Close();
            //return count;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Dispose();
            con.Close();
        }

    }
    public int GetAutoReqIdNo()
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetAutoVouchNo", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@Flag", "GetReqNo");
            int count = Convert.ToInt16(cmd.ExecuteScalar()) + 1;
            con.Close();
            return count;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Dispose();
            con.Close();
        }

    }

    public int Get_VoucherNo(int FId, int BranchId, int WareHouseId)
    {
        SqlConnection con = DataAccess.ConInitForPharmacy();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Get_VoucherNo", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@FId", FId);
        cmd.Parameters.AddWithValue("@BranchId", BranchId);
        cmd.Parameters.AddWithValue("@WareHouseId", WareHouseId);
        try
        {

            object count = Convert.ToInt32(cmd.ExecuteScalar());
            return Convert.ToInt32(count);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Dispose();
            con.Close();
        }

    }
    public int GetReqIdAndVoucherNo(int FId,int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForPharmacy();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetReqIdAndVoucherNo", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@FId",FId);
        cmd.Parameters.AddWithValue("@BranchId",BranchId);
        try
        {

            object count = Convert.ToInt32(cmd.ExecuteScalar());
            return Convert.ToInt32(count);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Dispose();
            con.Close();
        }

    }
    public int GetReqIdAndVoucherNo_DtoW(int FId, int BranchId, int WareHouseId)
    {
        SqlConnection con = DataAccess.ConInitForPharmacy();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetReqIdAndVoucherNo_DtoW", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@FId", FId);
        cmd.Parameters.AddWithValue("@BranchId", BranchId);
        cmd.Parameters.AddWithValue("@WareHouseId", WareHouseId);
        try
        {

            object count = Convert.ToInt32(cmd.ExecuteScalar());
            return Convert.ToInt32(count);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Dispose();
            con.Close();
        }

    }
    public void InsertReqNo(BEL Req)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetAutoVouchNo", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@ReqNo", Req.ReqNo);
            cmd.Parameters.AddWithValue("@Flag", "InsertReqNo");
            cmd.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Dispose();
            con.Close();
        }

    }
    public int GetAutoInvoiceNo()
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetAutoVouchNo", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@Flag", "GetInvoiceNo");
            int count = Convert.ToInt16(cmd.ExecuteScalar()) + 1;
            con.Close();
            return count;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Dispose();
            con.Close();
        }

    }

    public int GetAutoPONo( int WareHouseId)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetAutoVouchNo", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@Flag", "GetPONo");
            cmd.Parameters.AddWithValue("@WareHouseId", WareHouseId);
            int count = Convert.ToInt16(cmd.ExecuteScalar()) + 1;
            con.Close();
            return count;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Dispose();
            con.Close();
        }

    }

    public void UpdateInvoiceAmountDetails(BEL Invoice)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_UpdateInvoiceAmountDetails", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@InvoiceNo", Invoice.InvoiceNo);
            cmd.Parameters.AddWithValue("@SumOfTotalAmount", Invoice.SumOfTotalAmt);
            cmd.Parameters.AddWithValue("@TotalTax", Invoice.TotalTax);
            cmd.Parameters.AddWithValue("@AmtWithoutTax", Invoice.AmtWithoutTax);
            cmd.Parameters.AddWithValue("@FreightCharges", Invoice.FreightCharges);
            cmd.Parameters.AddWithValue("@FId", Invoice.Fid);
            cmd.Parameters.AddWithValue("@BranchId", Invoice.BranchId);
            cmd.Parameters.AddWithValue("@UpdatedBy", Invoice.UpdatedBy);
            cmd.Parameters.AddWithValue("@InvoiceDetailId", Invoice.InvoiceDetailId);
            cmd.Parameters.AddWithValue("@ChallanNo", Invoice.ChallanNo);
            cmd.Parameters.AddWithValue("@WareHouseId", Invoice.WareHouseId);   

            //cmd.Parameters.AddWithValue("@IsApprove", "NA");
            // cmd.Parameters.AddWithValue("@PaymentStatus", Invoice.PaymentStaus);
            // cmd.Parameters.AddWithValue("@SupplierId", Invoice.SuppId);
            // cmd.Parameters.AddWithValue("@InvoiceDate", DateTime.ParseExact(Invoice.Invoicedate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
       
           
            cmd.ExecuteNonQuery();
            
  
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Dispose();
            con.Close();
        }

    }

    public int InsertInvoiceAmountDetails(BEL Invoice)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_InsertInvoiceAmountDetails", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@InvoiceNo", Invoice.InvoiceNo);
            cmd.Parameters.AddWithValue("@PaymentStatus", Invoice.PaymentStaus);
            cmd.Parameters.AddWithValue("@ChallanNo", Invoice.ChallanNo);
            cmd.Parameters.AddWithValue("@SupplierId", Invoice.SuppId);
            cmd.Parameters.AddWithValue("@InvoiceDate", DateTime.ParseExact(Invoice.Invoicedate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            cmd.Parameters.AddWithValue("@SumOfTotalAmount", Invoice.SumOfTotalAmt);
            cmd.Parameters.AddWithValue("@TotalTax", Invoice.TotalTax);
            cmd.Parameters.AddWithValue("@AmtWithoutTax", Invoice.AmtWithoutTax);
            cmd.Parameters.AddWithValue("@FreightCharges", Invoice.FreightCharges);
            cmd.Parameters.AddWithValue("@FId", Invoice.Fid);
            cmd.Parameters.AddWithValue("@BranchId", Invoice.BranchId);
            cmd.Parameters.AddWithValue("@CreatedBy", Invoice.CreatedBy);
            cmd.Parameters.AddWithValue("@IsApprove", "NA");
            cmd.Parameters.AddWithValue("@PONumber", Invoice.PONo);
            cmd.Parameters.AddWithValue("@WareHouseId", Invoice.WareHouseId);
            cmd.Parameters.Add("@InvoiceDetailId", SqlDbType.Int).Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();
            int InvoiceDetailId = Convert.ToInt32(cmd.Parameters["@InvoiceDetailId"].Value);//.ToString();
            return InvoiceDetailId;

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Dispose();
            con.Close();
        }

    }
    public void InsertInvoiceNo(BEL Invoice)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetAutoVouchNo", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@InvoiceNo", Invoice.InvoiceNo);
            cmd.Parameters.AddWithValue("@Flag", "InsertInvoiceNo");
            cmd.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Dispose();
            con.Close();
        }

    }
    public void UpdatePOStatus(int PONo)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_UpdatePONoStatus", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@PONo", PONo);
            
            cmd.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Dispose();
            con.Close();
        }

    }
    
    public void InsertPONo(BEL Invoice)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetAutoVouchNo", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@PONo", Invoice.PONo);
            cmd.Parameters.AddWithValue("@WareHouseId", Invoice.WareHouseId);
            cmd.Parameters.AddWithValue("@Flag", "InsertPONo");
            cmd.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Dispose();
            con.Close();
        }

    }

    public BEL GetPriceDetailsForIndent(BEL ItemInfo)
    {
        BEL objBELBatchInfo = new BEL();
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetPriceDeatilsForIndent", con);
        cmd.CommandType = CommandType.StoredProcedure;
       // decimal CurrStock=0;
        try
        {
            cmd.Parameters.AddWithValue("@ItemId", ItemInfo.ItemId);
            cmd.Parameters.AddWithValue("@BatchNo", ItemInfo.BatchNo);
            cmd.Parameters.AddWithValue("@FId", ItemInfo.Fid);
            cmd.Parameters.AddWithValue("BranchId", ItemInfo.BranchId);
           
            
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                objBELBatchInfo.PerPackCost = Convert.ToDecimal(sdr["PerPackCost"]);
                objBELBatchInfo.Tax = Convert.ToDecimal(sdr["Tax"]);
            }
            return objBELBatchInfo;
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
    
   public BEL GetCurrentStkWarehouse(BEL ItemInfo)
    {
        BEL objBELBatchInfo = new BEL();
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetCurrentStockOfWarehouse", con);
        cmd.CommandType = CommandType.StoredProcedure;
       // decimal CurrStock=0;
        try
        {
            cmd.Parameters.AddWithValue("@ItemId", ItemInfo.ItemId);
           
            cmd.Parameters.AddWithValue("@FId", ItemInfo.Fid);
            cmd.Parameters.AddWithValue("@BranchId", ItemInfo.BranchId);
            cmd.Parameters.AddWithValue("@WareHouseId", ItemInfo.WareHouseId);
            
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                objBELBatchInfo.CurrStock = Convert.ToDecimal(sdr["CurrentStock"]);
               // objBELBatchInfo.InvoiceExpdate = Convert.ToString(sdr["ExpDate"]);
            }
            return objBELBatchInfo;
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
    public BEL GetCurrentStk(BEL ItemInfo)
    {
        BEL objBELBatchInfo = new BEL();
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetAutoVouchNo", con);
        cmd.CommandType = CommandType.StoredProcedure;
       // decimal CurrStock=0;
        try
        {
            cmd.Parameters.AddWithValue("@ItemId", ItemInfo.ItemId);
            cmd.Parameters.AddWithValue("@BatchNo", ItemInfo.BatchNo);
            cmd.Parameters.AddWithValue("@FId", ItemInfo.Fid);
            cmd.Parameters.AddWithValue("BranchId", ItemInfo.BranchId);
            cmd.Parameters.AddWithValue("WareHouseId", ItemInfo.WareHouseId);
            cmd.Parameters.AddWithValue("@Flag", "CurrentStk");
            
            
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                objBELBatchInfo.CurrStock = Convert.ToDecimal(sdr["CurrentStock"]);
                objBELBatchInfo.InvoiceExpdate = Convert.ToString(sdr["ExpDate"]);
            }
            return objBELBatchInfo;
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
    public BEL GetCurrentDeptStk(BEL ItemInfo)
    {
        BEL objBELBatchInfo = new BEL();
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetAutoVouchNo", con);
        cmd.CommandType = CommandType.StoredProcedure;
        // decimal CurrStock=0;
        try
        {
            cmd.Parameters.AddWithValue("@ItemId", ItemInfo.ItemId);
            cmd.Parameters.AddWithValue("@BatchNo", ItemInfo.BatchNo);
            cmd.Parameters.AddWithValue("@FId", ItemInfo.Fid);
            cmd.Parameters.AddWithValue("BranchId", ItemInfo.BranchId);
            cmd.Parameters.AddWithValue("DeptId", ItemInfo.DeptId);
            cmd.Parameters.AddWithValue("@Flag", "CurrentStkDept");


            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                objBELBatchInfo.CurrStock = Convert.ToDecimal(sdr["CurrentStock"]);
                objBELBatchInfo.InvoiceExpdate = Convert.ToString(sdr["ExpDate"]);
            }
            return objBELBatchInfo;
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


    public decimal GetCurrentStkBatchwise(BEL ItemInfo)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetAutoVouchNo", con);
        cmd.CommandType = CommandType.StoredProcedure;
        decimal CurrStock = 0;
        try
        {
            cmd.Parameters.AddWithValue("@BatchNo", ItemInfo.BatchNo);
            cmd.Parameters.AddWithValue("@ItemId", ItemInfo.ItemId);
            cmd.Parameters.AddWithValue("@Flag", "CurrentStkBatchwise");


            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                CurrStock = Convert.ToDecimal(sdr["CurrentStock"]);
            }
            return CurrStock;
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
    public int GetIndentNo(BEL Indent)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetAutoVouchNo", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@DeptId", Indent.DeptId);
            cmd.Parameters.AddWithValue("@Flag", "GetIndentNo");
            int count = Convert.ToInt16(cmd.ExecuteScalar()) ;
            con.Close();
            return count;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Dispose();
            con.Close();
        }

    }
    public DataSet GetDeptIndentList_Report_View(string FromDate, string ToDate, int DeptId, int ReqId,int Status, int FId, int BranchId)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_SearchDeptIndList_ReportView", con);
        cmd.CommandType = CommandType.StoredProcedure;

        try
        {
            if (FromDate == "")
            {
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            }
            else
            {

                cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            if (ToDate == "")
            {
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            }
            else
            {

                cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            cmd.Parameters.AddWithValue("@ReqId", ReqId);
            cmd.Parameters.AddWithValue("@DeptId", DeptId);
            cmd.Parameters.AddWithValue("@Status", Status);
            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;

        }

        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Dispose();
            con.Close();
        }

    }

    public DataSet GetDeptIndentListWarehouse_Report_View(string FromDate, string ToDate, int DeptId, int ReqId, int Status, int FId, int BranchId,int WareHouseId)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_SearchDeptIndList_Warehouse_ReportView", con);
        cmd.CommandType = CommandType.StoredProcedure;

        try
        {
            if (FromDate == "")
            {
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            }
            else
            {

                cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            if (ToDate == "")
            {
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            }
            else
            {

                cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            cmd.Parameters.AddWithValue("@ReqId", ReqId);
            cmd.Parameters.AddWithValue("@DeptId", DeptId);
            cmd.Parameters.AddWithValue("@Status", Status);
            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.Parameters.AddWithValue("@WareHouseId", WareHouseId);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;

        }

        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Dispose();
            con.Close();
        }

    }
    public DataSet GetDeptIndentList(string FromDate,string ToDate,int DeptId,int ReqId,int Status,int FId,int BranchId,int WareHouseId )
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_SearchDeptIndList", con);
        cmd.CommandType = CommandType.StoredProcedure;
       
         try
         {
             if (FromDate == "")
             {
                 cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
             }
             else
             {
                
                 cmd.Parameters.AddWithValue("@FromDate",DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
             }
             if (ToDate == "")
             {
                 cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

             }
             else             
             {
                
                 cmd.Parameters.AddWithValue("@ToDate",DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
             }
             cmd.Parameters.AddWithValue("@ReqId", ReqId);
             cmd.Parameters.AddWithValue("@DeptId", DeptId);            
             cmd.Parameters.AddWithValue("@Status", Status);
             cmd.Parameters.AddWithValue("@FId", FId);
             cmd.Parameters.AddWithValue("@BranchId", BranchId);
             cmd.Parameters.AddWithValue("@WareHouseId", WareHouseId);
             SqlDataAdapter sda = new SqlDataAdapter(cmd);
             DataSet ds = new DataSet();
             sda.Fill(ds);
             return ds;

         }

        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Dispose();
            con.Close();
        }

    }
    public DataSet GetDeptIndentList_Warehouse(string FromDate, string ToDate, int DeptId, int ReqId, int Status, int FId, int BranchId,int WareHouseId)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_SearchDeptIndList_Warehouse", con);
        cmd.CommandType = CommandType.StoredProcedure;

        try
        {
            if (FromDate == "")
            {
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            }
            else
            {

                cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            if (ToDate == "")
            {
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            }
            else
            {

                cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            cmd.Parameters.AddWithValue("@ReqId", ReqId);
            cmd.Parameters.AddWithValue("@DeptId", DeptId);
            cmd.Parameters.AddWithValue("@Status", Status);
            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.Parameters.AddWithValue("@WareHouseId", WareHouseId);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;

        }

        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Dispose();
            con.Close();
        }

    }

    public DataSet GetDeptIndentList_WarehouseProcess(string FromDate, string ToDate, int DeptId, int ReqId, int Status, int FId, int BranchId,int MainCategory,int WareHouseId)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_SearchDeptIndList_WarehouseProcess", con);
        cmd.CommandType = CommandType.StoredProcedure;

        try
        {
            if (FromDate == "")
            {
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            }
            else
            {

                cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            if (ToDate == "")
            {
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            }
            else
            {

                cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            cmd.Parameters.AddWithValue("@ReqId", ReqId);
            cmd.Parameters.AddWithValue("@DeptId", DeptId);
            cmd.Parameters.AddWithValue("@Status", Status);
            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.Parameters.AddWithValue("@MainCategory", MainCategory);
            cmd.Parameters.AddWithValue("@WareHouseId", WareHouseId);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;

        }

        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Dispose();
            con.Close();
        }

    }
    public DataSet FillStore_ExpiredItems(string month, string year, string CurrentDate,int Flag, int FId, int BranchId,int Deptid)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Store_MonthWiseExpiredItems", con);
        cmd.CommandType = CommandType.StoredProcedure;

        try
        {
            cmd.Parameters.AddWithValue("@month", month);
            cmd.Parameters.AddWithValue("@year", year);
            cmd.Parameters.AddWithValue("@FId", FId);
           // cmd.Parameters.AddWithValue("@CurrentDate", DateTime.ParseExact(CurrentDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            cmd.Parameters.AddWithValue("@CurrentDate", CurrentDate);
            cmd.Parameters.AddWithValue("@Flag", Flag);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.Parameters.AddWithValue("@Deptid", Deptid);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;

        }

        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Dispose();
            con.Close();
        }
    }
    public DataSet FillExpiredItems(string month, string year, string CurrentDate, int Flag, int FId, int BranchId, int WareHouseId)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_MonthWiseExpiredItems", con);
        cmd.CommandType = CommandType.StoredProcedure;

        try
        {
            cmd.Parameters.AddWithValue("@month", month);
            cmd.Parameters.AddWithValue("@year", year);
            cmd.Parameters.AddWithValue("@CurrentDate",CurrentDate);// DateTime.ParseExact(CurrentDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            cmd.Parameters.AddWithValue("@Flag", Flag);
            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.Parameters.AddWithValue("@WareHouseId", WareHouseId);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;

        }

        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Dispose();
            con.Close();
        }
    }
    public DataSet FillThreeSixNineMonthExpiry(string CurrentDate, string MonthCnt, int FId, int BranchId,int WareHouseId)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_ThreeSixNineMonthExpiryItems", con);
        cmd.CommandType = CommandType.StoredProcedure;

        try
        {
            cmd.Parameters.AddWithValue("@CurrentDate",CurrentDate);// DateTime.ParseExact(CurrentDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture)); 
            cmd.Parameters.AddWithValue("@MonthCnt", MonthCnt);
            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.Parameters.AddWithValue("@WareHouseId", WareHouseId);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;

        }

        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Dispose();
            con.Close();
        }
    }
    public DataSet FillThreeSixNineMonthExpiryForStores(string CurrentDate, string MonthCnt, int FId, int BranchId,int DeptId)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_ThreeSixNineMonthExpiryItemsForStores", con);
        cmd.CommandType = CommandType.StoredProcedure;

        try
        {
            //cmd.Parameters.AddWithValue("@CurrentDate", DateTime.ParseExact(CurrentDate, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            cmd.Parameters.AddWithValue("@CurrentDate", CurrentDate);
            cmd.Parameters.AddWithValue("@MonthCnt", MonthCnt);
            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.Parameters.AddWithValue("@DeptId", DeptId);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;

        }

        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Dispose();
            con.Close();
        }
    }

    public DataSet GetStoreIndentList(string FromDate, string ToDate, int DeptId, int VoucherNo, int FId, int BranchId, int WareHouseId)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_StoreWiseIssueItems", con);
        cmd.CommandType = CommandType.StoredProcedure;
       
         try
         {
             if (FromDate == "")
             {
                 cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
             }
             else
             {
                 //DateTime date = DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                 cmd.Parameters.AddWithValue("@FromDate",DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
             }
             if (ToDate == "")
             {
                 cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

             }
             else             
             {
                
                 cmd.Parameters.AddWithValue("@ToDate",DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
             }
             cmd.Parameters.AddWithValue("@VoucherNo", @VoucherNo);
             cmd.Parameters.AddWithValue("@DeptId", DeptId);            
            // cmd.Parameters.AddWithValue("@Flag", "DeptIndentList");
             cmd.Parameters.AddWithValue("@FId", FId);
             cmd.Parameters.AddWithValue("@BranchId", BranchId);
             cmd.Parameters.AddWithValue("@WareHouseId", WareHouseId);
             SqlDataAdapter sda = new SqlDataAdapter(cmd);
             DataSet ds = new DataSet();
             sda.Fill(ds);
             return ds;

         }

        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Dispose();
            con.Close();
        }

    }

    public DataSet GetDeptIndentList_Report(string FromDate, string ToDate, int DeptId, int ReqId,int Status, int FId, int BranchId)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_SearchDeptIndList_Report", con);
        cmd.CommandType = CommandType.StoredProcedure;

        try
        {
            
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            ds.Tables[0].TableName = "Vw_DeptIndentListSummary";
        
            return ds;
        }

        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Dispose();
            con.Close();
        }

    }

    public DataSet GetDeptIndentListWarehouse_Report(string FromDate, string ToDate, int DeptId, int ReqId, int Status, int FId, int BranchId)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_SearchDeptIndListWareHouse_Report", con);
        cmd.CommandType = CommandType.StoredProcedure;

        try
        {

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            ds.Tables[0].TableName = "View_DeptIndReqSummary_Warehouse";

            return ds;
        }

        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Dispose();
            con.Close();
        }

    }

    public DataSet GetIssueItemList(BEL Indent)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_IndentRequest", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@DeptId", Indent.DeptId);
            cmd.Parameters.AddWithValue("@ReqId", Indent.ReqId);
            cmd.Parameters.AddWithValue("@Flag", "IssueItemList");
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Dispose();
            con.Close();
        }

    }
    public BEL SelectItem(int ItemId)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_SelectItem", con);
        cmd.CommandType = CommandType.StoredProcedure;
        BEL Item=new BEL();
        try
        {
            cmd.Parameters.AddWithValue("@ItemId",ItemId);
            //cmd.Parameters.AddWithValue("@Flag", "CurrentStk");
            //int Stock = 0;
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                Item.ItemName =Convert.ToString(sdr["ItemName"]);
                Item.ItemStatus = Convert.ToString(sdr["Itemstatus"]);
                Item.ItemDesc = Convert.ToString(sdr["ItemDesc"]);
                Item.MfgCompName = Convert.ToString(sdr["MfgCompName"]);
                Item.SuppName = Convert.ToString(sdr["SupplierName"]);
                Item.units = Convert.ToInt32(sdr["Unit"]);
                Item.CategoryName = Convert.ToString(sdr["CategoryName"]);
                Item.CurrStock=Convert.ToInt32(sdr["CurrentStock"]);
                Item.BatchNo=Convert.ToString(sdr["BatchNo"]);
                Item.UnitsPerPack=Convert.ToInt32(sdr["UnitsPerPack"]);
                Item.CostPerUnit = Convert.ToDecimal(sdr["CostPerUnit"]);
                Item.ReorderLevel = Convert.ToString(sdr["ReorderLevel"]);
                Item.SuppId=Convert.ToInt32(sdr["Supplier"]);
                Item.MfgCompId=Convert.ToInt32(sdr["MgfCompany"]);
                Item.CategoryId = Convert.ToInt32(sdr["Category"]);
                
                    
                    
            }
            return Item;
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

    public BEL SelectEditItem(int ItemId)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_SelectEditItem", con);
        cmd.CommandType = CommandType.StoredProcedure;
        BEL Item = new BEL();
        try
        {
            cmd.Parameters.AddWithValue("@ItemId", ItemId);
            //cmd.Parameters.AddWithValue("@Flag", "CurrentStk");
            //int Stock = 0;
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                Item.ItemName = Convert.ToString(sdr["ItemName"]);
                Item.ItemStatus = Convert.ToString(sdr["Itemstatus"]);
                Item.ItemDesc = Convert.ToString(sdr["ItemDesc"]);
                //Item.MfgCompName = Convert.ToString(sdr["MfgCompName"]);
                //Item.SuppName = Convert.ToString(sdr["SupplierName"]);
                Item.units = Convert.ToInt32(sdr["Unit"]);
                Item.CategoryName = Convert.ToString(sdr["CategoryName"]);
                Item.CurrStock = Convert.ToInt32(sdr["CurrentStock"]);
                Item.BatchNo = Convert.ToString(sdr["BatchNo"]);
                Item.UnitsPerPack = Convert.ToInt32(sdr["UnitsPerPack"]);
                Item.CostPerUnit = Convert.ToDecimal(sdr["CostPerUnit"]);
                Item.ReorderLevel = Convert.ToString(sdr["ReorderLevel"]);
               
                Item.CategoryId = Convert.ToInt32(sdr["Category"]);
                Item.ItemType = Convert.ToString(sdr["ItemType"]);
                Item.TaxType = Convert.ToInt32(sdr["TaxType"]);
                Item.SKU = Convert.ToString(sdr["SKU"]);
                Item.MainCategory = Convert.ToInt32(sdr["MainCategory"]);

                Item.MarkupOPD = Convert.ToInt32(sdr["MarkUpOPD"]);
                Item.MarkupIPD = Convert.ToInt32(sdr["MarkUpIPD"]);

                Item.MedicineTypeId = Convert.ToInt32(sdr["MedicineTypeId"]);
                Item.PackSizeID = Convert.ToInt32(sdr["PackSizeID"]);
                Item.SubcatID = Convert.ToInt32(sdr["SubcatID"]);
               // Item.WareHouseId = Convert.ToInt32(sdr["WareHouseId"]);
                Item.MRP = Convert.ToSingle(sdr["MRP"]);
                Item.ExpiryDtRequired = Convert.ToBoolean(sdr["ExpiryDtRequired"]);
                Item.BatchRequired = Convert.ToBoolean(sdr["BatchRequired"]);
                Item.IsNonChargable = Convert.ToBoolean(sdr["IsNonChargable"]);
                Item.NoMrp = Convert.ToBoolean(sdr["NoMrp"]);
                Item.Asset = Convert.ToBoolean(sdr["Asset"]);
                Item.HighValueFlag = Convert.ToBoolean(sdr["HighValueFlag"]);
                Item.scheduledItem = Convert.ToBoolean(sdr["scheduledItem"]);
                Item.narcoticItem = Convert.ToBoolean(sdr["narcoticItem"]);
                Item.CriticalMedicine = Convert.ToBoolean(sdr["CriticalMedicine"]);
                Item.Isxrayfilm = Convert.ToBoolean(sdr["Isxrayfilm"]);
                Item.IsApproval = Convert.ToBoolean(sdr["IsApproval"]);
                Item.Active = Convert.ToBoolean(sdr["Active"]);

                Item.WareHouseId = Convert.ToInt32(sdr["WareHouseId"]);


            }
            return Item;
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


    
    
    public void InsertIssueItem(BEL ItemInfo)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_IssueItem", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@ReqId", ItemInfo.ReqId);
            cmd.Parameters.AddWithValue("@VoucherNo", ItemInfo.VoucherNo);
                     
            cmd.Parameters.AddWithValue("@ItemId", ItemInfo.ItemId);
            
            cmd.Parameters.AddWithValue("@PendingQty", ItemInfo.PendingQty);
            cmd.Parameters.AddWithValue("@IssueQty", ItemInfo.IssueQty);
            
            cmd.Parameters.AddWithValue("@IssueDate", ItemInfo.IssueDate);
            cmd.Parameters.AddWithValue("@BatchNo", ItemInfo.BatchNo);
            cmd.Parameters.AddWithValue("@IssueFrmDept", ItemInfo.IssueFromDept);
            cmd.Parameters.AddWithValue("@IssueToDept", ItemInfo.IssueToDept);
           // cmd.Parameters.AddWithValue("@Flag", "InsertReq");

            cmd.ExecuteNonQuery();
            con.Close();
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
    public void UpadteCurrentStock(BEL ItemCurrStock)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_UpdateCurrentStock", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@ItemId", ItemCurrStock.ItemId);
            cmd.Parameters.AddWithValue("@BatchNo", ItemCurrStock.BatchNo);
            cmd.Parameters.AddWithValue("@CurrentStock", ItemCurrStock.CurrStock);
            cmd.ExecuteNonQuery();
            con.Close();
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
    
    public int InsertMainStkAdjust(BEL ItemCurrStock)
    {

        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_InsertWarehouseStockAdjustMain", con);
        cmd.CommandType = CommandType.StoredProcedure;
        int MainId = 0;
        try
        {
            
            cmd.Parameters.AddWithValue("@FId", ItemCurrStock.Fid);
            cmd.Parameters.AddWithValue("@BranchId", ItemCurrStock.BranchId);
            cmd.Parameters.AddWithValue("@CreatedBy", ItemCurrStock.CreatedBy);
            cmd.Parameters.AddWithValue("@WareHouseId", ItemCurrStock.WareHouseId);
            cmd.Parameters.Add("@StockAdjustMainId", SqlDbType.Int).Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();
            MainId = Convert.ToInt32(cmd.Parameters["@StockAdjustMainId"].Value);//.ToString();
            return MainId;
            
            
            
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


    public int InsertMainStkAdjust_Dept(BEL ItemCurrStock)
    {

        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_InsertWarehouseStockAdjustMain_Dept", con);
        cmd.CommandType = CommandType.StoredProcedure;
        int MainId = 0;
        try
        {
            
            cmd.Parameters.AddWithValue("@FId", ItemCurrStock.Fid);
            cmd.Parameters.AddWithValue("@BranchId", ItemCurrStock.BranchId);
            cmd.Parameters.AddWithValue("@CreatedBy", ItemCurrStock.CreatedBy);
            cmd.Parameters.AddWithValue("@DeptId", ItemCurrStock.DeptId);
            cmd.Parameters.AddWithValue("@WareHouseId", ItemCurrStock.WareHouseId);
            cmd.Parameters.Add("@DeptStockAdjustMainId", SqlDbType.Int).Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();
            MainId = Convert.ToInt32(cmd.Parameters["@DeptStockAdjustMainId"].Value);//.ToString();
            return MainId;
            
            
            
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
    public void UpadteCurrentStock_DeptStockAdjust(BEL ItemCurrStock)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_UpdateCurrentStock_DeptStockAdjust", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@ItemId", ItemCurrStock.ItemId);
            cmd.Parameters.AddWithValue("@BatchNo", ItemCurrStock.BatchNo);
            cmd.Parameters.AddWithValue("@CurrentStock", ItemCurrStock.CurrStock);
            cmd.Parameters.AddWithValue("@FId", ItemCurrStock.Fid);
            cmd.Parameters.AddWithValue("@BranchId", ItemCurrStock.BranchId);
            cmd.Parameters.AddWithValue("@DeptId", ItemCurrStock.DeptId);
            cmd.Parameters.AddWithValue("@CreatedBy", ItemCurrStock.CreatedBy);
            cmd.Parameters.AddWithValue("@Remark", ItemCurrStock.Remark);
            cmd.Parameters.AddWithValue("@DeptStockAdjustMainId", ItemCurrStock.DeptStockAdjustMainId);
            cmd.Parameters.AddWithValue("@WareHouseId", ItemCurrStock.WareHouseId);
            if (ItemCurrStock.InvoiceExpdate != null)
            {
                cmd.Parameters.AddWithValue("@ExpDate", DateTime.ParseExact(ItemCurrStock.InvoiceExpdate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            cmd.ExecuteNonQuery();
            con.Close();
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

    public void UpadteCurrentStock_warehouseStockAdjust(BEL ItemCurrStock)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_UpdateCurrentStock_WarehouseStockAdjust", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@ItemId", ItemCurrStock.ItemId);
            cmd.Parameters.AddWithValue("@BatchNo", ItemCurrStock.BatchNo);
            cmd.Parameters.AddWithValue("@CurrentStock", ItemCurrStock.CurrStock);
            cmd.Parameters.AddWithValue("@FId", ItemCurrStock.Fid);
            cmd.Parameters.AddWithValue("@BranchId", ItemCurrStock.BranchId);
            cmd.Parameters.AddWithValue("@CreatedBy", ItemCurrStock.CreatedBy);
            cmd.Parameters.AddWithValue("@Remark", ItemCurrStock.Remark);
            cmd.Parameters.AddWithValue("@WareHouseId", ItemCurrStock.WareHouseId);
            cmd.Parameters.AddWithValue("@StockAdjustMainId", ItemCurrStock.StockAdjustMainId);
            if (ItemCurrStock.InvoiceExpdate != null)
            {
                cmd.Parameters.AddWithValue("@ExpDate", DateTime.ParseExact(ItemCurrStock.InvoiceExpdate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }


         
            cmd.ExecuteNonQuery();
            con.Close();
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
    public DataSet SearchIndendRequest(BEL IndentRequest)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_SearchIndentRequest", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@RPIflag",IndentRequest.RPIflag );
            cmd.Parameters.AddWithValue("@FromDate",IndentRequest.FromDate);
            cmd.Parameters.AddWithValue("@ToDate", IndentRequest.ToDate);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Dispose();
            con.Close();
        }

    }

    public DataTable SearchCurrentStock(BEL Itemstock)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_ItemWiseStockSearch", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@ItemId", Itemstock.ItemId);
            cmd.Parameters.AddWithValue("@BatchNo", Itemstock.BatchNo);
            cmd.Parameters.AddWithValue("@CategoryId", Itemstock.CategoryId);
            cmd.Parameters.AddWithValue("@MainCategory", Itemstock.MainCategory);
            cmd.Parameters.AddWithValue("@BranchId", Itemstock.BranchId);
            cmd.Parameters.AddWithValue("@Flag", Itemstock.ItemType);
            cmd.Parameters.AddWithValue("@FId", Itemstock.Fid);
            cmd.Parameters.AddWithValue("@WareHouseId", Itemstock.WareHouseId);

           SqlDataAdapter sda = new SqlDataAdapter(cmd);
           DataTable ds = new DataTable();
           sda.Fill(ds);
           return ds;

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Dispose();
            con.Close();
        }

    
    }

    public DataTable SearchCurrentStockNew(BEL Itemstock)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_BatchWiseWarehouseStock", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@ItemId", Itemstock.ItemId);
            cmd.Parameters.AddWithValue("@BatchNo", Itemstock.BatchNo);
            cmd.Parameters.AddWithValue("@CategoryId", Itemstock.CategoryId);
            cmd.Parameters.AddWithValue("@MainCategory", Itemstock.MainCategory);
            cmd.Parameters.AddWithValue("@BranchId", Itemstock.BranchId);
            cmd.Parameters.AddWithValue("@Flag", Itemstock.ItemType);
            cmd.Parameters.AddWithValue("@FId", Itemstock.Fid);
            cmd.Parameters.AddWithValue("@WareHouseId", Itemstock.WareHouseId);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            sda.Fill(ds);
            return ds;

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Dispose();
            con.Close();
        }


    }

    public DataSet SearchCurrentStock_WarehouseStkAdjust(BEL Itemstock)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_ItemWiseStockSearch_WarehouseStockAdjust", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@ItemId", Itemstock.ItemId);
            cmd.Parameters.AddWithValue("@BatchNo", Itemstock.BatchNo);
            //cmd.Parameters.AddWithValue("@CategoryId", Itemstock.CategoryId);
            //cmd.Parameters.AddWithValue("@MainCategory", Itemstock.MainCategory);
            cmd.Parameters.AddWithValue("@BranchId", Itemstock.BranchId);
            //cmd.Parameters.AddWithValue("@Flag", Itemstock.ItemType);
            cmd.Parameters.AddWithValue("@FId", Itemstock.Fid);
            cmd.Parameters.AddWithValue("@WareHouseId", Itemstock.WareHouseId);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Dispose();
            con.Close();
        }


    }

    public DataSet WarehouseStockAdjustReport(string FromDate, string ToDate,int FId, int BranchId)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_WareHouseStockAdjustReport", con);
        cmd.CommandType = CommandType.StoredProcedure;

        try
        {
            if (FromDate == "")
            {
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            }
            else
            {
                //DateTime date = DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            if (ToDate == "")
            {
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            }
            else
            {

                cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            
            //cmd.Parameters.AddWithValue("@FId", FId);
            //cmd.Parameters.AddWithValue("@BranchId", BranchId);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;

        }

        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Dispose();
            con.Close();
        }

    }

    public DataSet WarehouseStockAdjustList(string FromDate, string ToDate, int FId, int BranchId, int WareHouseId)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_WareHouseStockAdjustList", con);
        cmd.CommandType = CommandType.StoredProcedure;

        try
        {
            if (FromDate == "")
            {
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            }
            else
            {
                //DateTime date = DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            if (ToDate == "")
            {
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            }
            else
            {

                cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }

            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.Parameters.AddWithValue("@WareHouseId", WareHouseId);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;

        }

        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Dispose();
            con.Close();
        }

    }
    public DataSet DeptStockAdjustList(string FromDate, string ToDate, int FId, int BranchId,int DeptId)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_DeptStockAdjustList", con);
        cmd.CommandType = CommandType.StoredProcedure;

        try
        {
            if (FromDate == "")
            {
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            }
            else
            {
                //DateTime date = DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            if (ToDate == "")
            {
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            }
            else
            {

                cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }

            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.Parameters.AddWithValue("@DeptId", DeptId);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;

        }

        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Dispose();
            con.Close();
        }

    }
    public DataSet DeptStoreWiseStockAdjustReport(string FromDate, string ToDate,int DeptId, int FId, int BranchId)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_StoreWiseStockAdjustReport", con);
        cmd.CommandType = CommandType.StoredProcedure;

        try
        {
            if (FromDate == "")
            {
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            }
            else
            {
                //DateTime date = DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            if (ToDate == "")
            {
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            }
            else
            {

                cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            cmd.Parameters.AddWithValue("@DeptId", DeptId);
            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;

        }

        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Dispose();
            con.Close();
        }

    }
    public DataSet SearchItemWiseCurrentStock(BEL Itemstock)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Vw_ItemWiseCurrentStock", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@ItemId", Itemstock.ItemId);
          //  cmd.Parameters.AddWithValue("@BatchNo", Itemstock.BatchNo);
            cmd.Parameters.AddWithValue("@CategoryId", Itemstock.CategoryId);
            cmd.Parameters.AddWithValue("@MainCategory", Itemstock.MainCategory);
            cmd.Parameters.AddWithValue("@BranchId", Itemstock.BranchId);
            cmd.Parameters.AddWithValue("@FId", Itemstock.Fid);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Dispose();
            con.Close();
        }


    }

    public DataTable SearchItemWiseCurrentStockNew(BEL Itemstock)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_ItemWiseWarehouseCurrentStock", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@ItemId", Itemstock.ItemId);
            //  cmd.Parameters.AddWithValue("@BatchNo", Itemstock.BatchNo);
            cmd.Parameters.AddWithValue("@CategoryId", Itemstock.CategoryId);
            cmd.Parameters.AddWithValue("@MainCategory", Itemstock.MainCategory);
            cmd.Parameters.AddWithValue("@BranchId", Itemstock.BranchId);
            cmd.Parameters.AddWithValue("@FId", Itemstock.Fid);
            cmd.Parameters.AddWithValue("@WareHouseId", Itemstock.WareHouseId);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            sda.Fill(ds);
            return ds;

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Dispose();
            con.Close();
        }


    }

    public DataTable SearchItemWiseCurrentStockNew_Zero(BEL Itemstock)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_ItemWiseWarehouseCurrentStock_Zero", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@ItemId", Itemstock.ItemId);
            //  cmd.Parameters.AddWithValue("@BatchNo", Itemstock.BatchNo);
            cmd.Parameters.AddWithValue("@CategoryId", Itemstock.CategoryId);
            cmd.Parameters.AddWithValue("@MainCategory", Itemstock.MainCategory);
            cmd.Parameters.AddWithValue("@BranchId", Itemstock.BranchId);
            cmd.Parameters.AddWithValue("@FId", Itemstock.Fid);
            cmd.Parameters.AddWithValue("@WareHouseId", Itemstock.WareHouseId);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            sda.Fill(ds);
            return ds;

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Dispose();
            con.Close();
        }


    }

    public DataSet FillIndendRequstList()
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_IndentRequestList", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
           
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Dispose();
            con.Close();
        }


    }
    public DataSet FillIndRequstGrid(int DeptId,int ReqId,int FId,int BranchId)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_IndentRequestGrid", con);
        cmd.CommandType = CommandType.StoredProcedure;

        try
        {
            cmd.Parameters.AddWithValue("@DeptId", DeptId);
            cmd.Parameters.AddWithValue("@ReqId", ReqId);
            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Dispose();
            con.Close();
        }


    }


   public BEL FillIndRequstDetails(int DeptId,int ReqId,int ItemId)
   {
       SqlConnection con = new SqlConnection(constr);
       con.Open();
       SqlCommand cmd = new SqlCommand("Sp_IndentRequestSelect",con);
       cmd.CommandType = CommandType.StoredProcedure;
       

       BEL IndReqInfo = new BEL();    


       try
       {
           cmd.Parameters.AddWithValue("@ItemId", ItemId);
           cmd.Parameters.AddWithValue("@DeptId", DeptId);
           cmd.Parameters.AddWithValue("@ReqId", ReqId);

           
           SqlDataReader sdr = cmd.ExecuteReader();
           while (sdr.Read())
           {
               IndReqInfo.ItemName = Convert.ToString(sdr["ItemName"]);
               IndReqInfo.units = Convert.ToInt32(sdr["UnitId"]);
               IndReqInfo.ReqQty=Convert.ToInt32(sdr["ReqQty"]);
               IndReqInfo.VoucherNo=Convert.ToInt32(sdr["VoucherNo"]);
               IndReqInfo.DeptId=Convert.ToInt32(sdr["DeptId"]);
            //   IndReqInfo.ReqDate=Convert.ToDateTime(sdr["ReqDate"]);
               IndReqInfo.ReqId=Convert.ToInt32(sdr["ReqId"]);
                      
               //IndReqInfo.BatchNo = Convert.ToString(sdr["BatchNo"]);
               


           }
           return IndReqInfo;
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
   public void DeleteIndReq(string ItemId, string DeptId, string ReqId, string BatchNo)
   {
       SqlConnection con = new SqlConnection(constr);
       con.Open();
       SqlCommand cmd = new SqlCommand("Sp_DeleteIndRequest",con);
       cmd.CommandType = CommandType.StoredProcedure;
       try
       {
            cmd.Parameters.AddWithValue("@ItemId", Convert.ToInt32(ItemId));
            cmd.Parameters.AddWithValue("@DeptId", Convert.ToInt32(DeptId));
            cmd.Parameters.AddWithValue("@ReqId",Convert.ToInt32(ReqId) );
            cmd.Parameters.AddWithValue("@BatchNo", Convert.ToString(BatchNo));
            cmd.ExecuteNonQuery();
            con.Close();
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

    public string ExistDeptInDeptWiseItemStock(BEL ObjItem)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_ExistDeptInDeptWiseItemStock", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@ItemId",ObjItem.ItemId);
            cmd.Parameters.AddWithValue("@DeptId",ObjItem.IssueToDept);
            
            object result= cmd.ExecuteScalar();
            return Convert.ToString(result);
           
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

    public decimal GetDeptItemCurrentStock(BEL DeptDetails)
    {

        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_DeptWiseItemCurrentStock", con);
        cmd.CommandType = CommandType.StoredProcedure;     


        try
        {
            cmd.Parameters.AddWithValue("@ItemId", DeptDetails.ItemId);
            cmd.Parameters.AddWithValue("@DeptId", DeptDetails.IssueToDept);         

            SqlDataReader sdr = cmd.ExecuteReader();
            decimal currentstock=0;
            while (sdr.Read())
            {
                currentstock = Convert.ToDecimal(sdr["CurrentStock"]);
                
            }
            return currentstock;
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

    public void UpdateDeptItemCurrentStock(BEL DeptDetails)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_InsertDeptItemCurrentStock", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@ItemId",DeptDetails.ItemId );
            cmd.Parameters.AddWithValue("@DeptId",DeptDetails.IssueToDept);
            cmd.Parameters.AddWithValue("@CurrentStock",DeptDetails.CurrStock);
            cmd.Parameters.AddWithValue("@Flag", "Update");
            cmd.ExecuteNonQuery();
            con.Close();
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



    public void InsertDeptItemCurrentStock(BEL DeptDetails)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_InsertDeptItemCurrentStock", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@ItemId", DeptDetails.ItemId);
            cmd.Parameters.AddWithValue("@DeptId", DeptDetails.IssueToDept);
            cmd.Parameters.AddWithValue("@CurrentStock", DeptDetails.CurrStock);
            cmd.Parameters.AddWithValue("@Flag", "Insert");
            cmd.ExecuteNonQuery();
            con.Close();
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
    public DataSet FillDeptwiseItem()
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_InsertDeptItemCurrentStock", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@Flag", "Select");
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;
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
    public DataSet FillConsumptionItem()
    {
        SqlConnection con = new SqlConnection(constr);
        string[] Database = constrLab.Split(';');
        string InitialCatalog = Database[1];
        string[] db = InitialCatalog.Split('=');
        string DbName = db[1];
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_CosumptionMasterFillGrid", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@database", DbName);
        try
        {
           
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Dispose();
            con.Close();
        }

    }
    public DataSet FillConsumItemSearch( BEL Consume)
    {
        SqlConnection con = new SqlConnection(constr);
        string[] Database = constrLab.Split(';');
        string InitialCatalog = Database[1];
        string[] db = InitialCatalog.Split('=');
        string DbName = db[1];
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_SearchCosumptionItem", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@ItemId", Consume.ItemId);
            cmd.Parameters.AddWithValue("@database", DbName);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Dispose();
            con.Close();
        }
    }
    public BEL SelectConsumption(int ConsumptionId)
    {
        BEL Items =new BEL();
        SqlConnection con = new SqlConnection(constr);
        string[] Database = constrLab.Split(';');
        string InitialCatalog = Database[1];
        string[] db = InitialCatalog.Split('=');
        string DbName = db[1];
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_ConsumptionMasterSelect", con);
        cmd.CommandType = CommandType.StoredProcedure;
        
        try
        {
            cmd.Parameters.AddWithValue("@database", DbName);

            cmd.Parameters.AddWithValue("@ConsumptionId", ConsumptionId);
            

            SqlDataReader sdr = cmd.ExecuteReader();
            
            while (sdr.Read())
            {
                Items.ItemName = Convert.ToString(sdr["ItemName"]);
                Items.Quantity = Convert.ToDecimal(sdr["Qty"]);
                Items.TestName=Convert.ToString(sdr["Maintestname"]);
                Items.TestCode = Convert.ToString(sdr["TestCode"]);
                Items.ItemId = Convert.ToInt32(sdr["ItemId"]);

            }
            return Items;
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

    public string UpdateConsumeMaster(BEL ObjBELConsume)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_UpdateConsumeMaster", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@ItemId", ObjBELConsume.ItemId);
            cmd.Parameters.AddWithValue("@TestCode", ObjBELConsume.TestCode);
            cmd.Parameters.AddWithValue("@Qty", ObjBELConsume.Quantity);
            cmd.Parameters.AddWithValue("@ConsumptionId", ObjBELConsume.ConsumptionId);
            cmd.Parameters.AddWithValue("@UpdatedBy", ObjBELConsume.UpdatedBy);
            cmd.Parameters.AddWithValue("@UpdatedOn", ObjBELConsume.UpdatedOn);
            object message;
            message = cmd.ExecuteScalar();
            return Convert.ToString(message);
          
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
    public string SaveConsumeMaster(BEL ObjBELConsume)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_SaveConsumeMaster", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@ItemId", ObjBELConsume.ItemId);
            cmd.Parameters.AddWithValue("@TestCode", ObjBELConsume.TestCode);
            cmd.Parameters.AddWithValue("@Qty", ObjBELConsume.Quantity);
            cmd.Parameters.AddWithValue("@CreatedBy", ObjBELConsume.CreatedBy);
            object message;
            message = cmd.ExecuteScalar();
            return Convert.ToString(message);
          
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
    public string DeleteConsumMaster(int ConsumptionId)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_DeleteConsumeMaster", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@ConsumptionId",ConsumptionId);
            object message;
            message = cmd.ExecuteScalar();
            return Convert.ToString(message);

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

    public int GetPendingReqFlagCount(BEL Indent)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetCountOfPendingRequest", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@ReqId", Indent.ReqId);
            cmd.Parameters.AddWithValue("@DeptId", Indent.DeptId);
            
            int count = Convert.ToInt16(cmd.ExecuteScalar());
            con.Close();
            return count;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Dispose();
            con.Close();
        }

    }

   public void UpdateIndDeptReqFlag(BEL Indent)
   {
       SqlConnection con = new SqlConnection(constr);
       con.Open();
       SqlCommand cmd = new SqlCommand("Sp_UpdateIndDeptReqFlag", con);
       cmd.CommandType = CommandType.StoredProcedure;
       try
       {
           
           cmd.Parameters.AddWithValue("@ReqId",Indent.ReqId);
           cmd.Parameters.AddWithValue("@DeptId", Indent.IssueToDept);
           cmd.Parameters.AddWithValue("@RPIflag", Indent.RPIflag);
           
           cmd.ExecuteNonQuery();
           con.Close();
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
   public DataSet FillPatWiseItemConsumption()
   {
       SqlConnection con = new SqlConnection(constr);
       string[] Database = constrLab.Split(';');
       string InitialCatalog = Database[1];
       string[] db = InitialCatalog.Split('=');
       string DbName = db[1];

       con.Open();
       SqlCommand cmd = new SqlCommand("Sp_PatientWiseItemConsumption", con);
       cmd.CommandType = CommandType.StoredProcedure;
       cmd.Parameters.AddWithValue("@DBName", DbName);
       try
       {

           SqlDataAdapter sda = new SqlDataAdapter(cmd);
           DataSet ds = new DataSet();
           sda.Fill(ds);
           return ds;

       }
       catch (Exception ex)
       {
           throw ex;
       }
       finally
       {
           con.Dispose();
           con.Close();
       }

   }

   public DataSet FillItemConsumption(string FromDate, string ToDate)
   {
       SqlConnection con = new SqlConnection(constr);
       con.Open();
       SqlCommand cmd = new SqlCommand("Sp_Vw_ItemConsumption", con);
       cmd.CommandType = CommandType.StoredProcedure;
       try
       {
           if (FromDate == "")
           {
               cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
           }
           else
           {
               // cmd.Parameters.AddWithValue("@FromDate",Convert.ToDateTime(FromDate));
               cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
           }
           if (ToDate == "")
           {
               cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

           }
           else
           {
               // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
               cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
           }
           SqlDataAdapter sda = new SqlDataAdapter(cmd);
           DataSet ds = new DataSet();
           sda.Fill(ds);
           return ds;

       }
       catch (Exception ex)
       {
           throw ex;
       }
       finally
       {
           con.Dispose();
           con.Close();
       }

   }

   public DataSet FillManualConsumption(string FromDate, string ToDate,int DeptId)
   {
       SqlConnection con = new SqlConnection(constr);
       con.Open();
       SqlCommand cmd = new SqlCommand("Sp_ManualConsumptionFillGrid", con);
       cmd.CommandType = CommandType.StoredProcedure;
       try
       {
           if (FromDate == "")
           {
               cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
           }
           else
           {
               // cmd.Parameters.AddWithValue("@FromDate",Convert.ToDateTime(FromDate));
               cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
           }
           if (ToDate == "")
           {
               cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

           }
           else
           {
               // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
               cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
           }
           cmd.Parameters.AddWithValue("@DeptId", DeptId);
           SqlDataAdapter sda = new SqlDataAdapter(cmd);
           DataSet ds = new DataSet();
           sda.Fill(ds);
           return ds;

       }
       catch (Exception ex)
       {
           throw ex;
       }
       finally
       {
           con.Dispose();
           con.Close();
       }

   }
   
    public decimal  GetItemWiseCurrentStock(int ItemId,int DeptId)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_ItemWiseCurrentStock", con);
        cmd.CommandType = CommandType.StoredProcedure;


        try
        {
            cmd.Parameters.AddWithValue("@ItemId", ItemId);
            cmd.Parameters.AddWithValue("@DeptId", DeptId);

            SqlDataReader sdr = cmd.ExecuteReader();
            decimal currentstock = 0;
            while (sdr.Read())
            {
                currentstock = Convert.ToDecimal(sdr["CurrentStock"]);

            }
            return currentstock;
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
    public void UpdateItemWiseCurrentStock(BEL Item)
    {
        SqlConnection con = new SqlConnection(constr);
        
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_UpdateItemWiseCurrentStock", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@ItemId", Item.ItemId);
            cmd.Parameters.AddWithValue("@DeptId", Item.DeptId);
            cmd.Parameters.AddWithValue("@CurrentStock", Item.CurrStock);
           
            cmd.ExecuteNonQuery();
            con.Close();
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

    public void UpdatePatientStatus(string Regno,string MTCode)
    {
        SqlConnection con = new SqlConnection(constr);
        string[] Database = constrLab.Split(';');
        string InitialCatalog = Database[1];
        string[] db = InitialCatalog.Split('=');
        string DbName = db[1];

        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_UpdatePatientsInventoryStatus", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@regno", Regno);
            cmd.Parameters.AddWithValue("@MTCode", MTCode);
            cmd.Parameters.AddWithValue("@database", DbName);

            cmd.ExecuteNonQuery();
            con.Close();
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

    public string SaveManualConsumeMaster(BELPatientIssueVoucher ObjBELManConsume)
   {
       SqlConnection con = new SqlConnection(constr);
       con.Open();
       SqlCommand cmd = new SqlCommand("Sp_ManualConsumptionInsert", con);
       cmd.CommandType = CommandType.StoredProcedure;
       try
       {
           cmd.Parameters.AddWithValue("@ItemId", ObjBELManConsume.ItemId);
           cmd.Parameters.AddWithValue("@UnitId",ObjBELManConsume.UnitId);
           if (ObjBELManConsume.InvoiceExpdate != null)
           {
             cmd.Parameters.AddWithValue("@ExpDate", DateTime.ParseExact(ObjBELManConsume.InvoiceExpdate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
               
           }
           cmd.Parameters.AddWithValue("@BatchNo", ObjBELManConsume.BatchNo);
           cmd.Parameters.AddWithValue("@DeptId", ObjBELManConsume.DeptId);
           cmd.Parameters.AddWithValue("@Remark", ObjBELManConsume.Remark);
           cmd.Parameters.AddWithValue("@ConsumptionDate", DateTime.ParseExact(ObjBELManConsume.Issuedate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
           cmd.Parameters.AddWithValue("@Quantity", ObjBELManConsume.IssueQty);
           cmd.Parameters.AddWithValue("@Rate", ObjBELManConsume.Rate);
           cmd.Parameters.AddWithValue("@Tax", ObjBELManConsume.Tax);
           cmd.Parameters.AddWithValue("@TotalAmount", ObjBELManConsume.GrandTotal);
           cmd.Parameters.AddWithValue("@CreatedBy", ObjBELManConsume.CreatedBy);
           cmd.Parameters.AddWithValue("@FId", ObjBELManConsume.Fid);
           cmd.Parameters.AddWithValue("@BranchId", ObjBELManConsume.BranchId);
           object message;
           message = cmd.ExecuteScalar();
           return Convert.ToString(message);

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
   public DataSet FillManualConsumptionGrid()
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_ManualConsumptionFillGrid", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Dispose();
            con.Close();
        }

    }
    

    public DataSet FillStockAdjustmentGrid()
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_FillStockAdjustmentGrid", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Dispose();
            con.Close();
        }

    }
    public string SaveStockAdjustment(BEL ObjBELStockAdjust)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_SaveStockAdjustment", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@ItemId", ObjBELStockAdjust.ItemId);
            cmd.Parameters.AddWithValue("@UnitId", ObjBELStockAdjust.units);
            cmd.Parameters.AddWithValue("@AdjustmentType", ObjBELStockAdjust.AdjustmentType);
            cmd.Parameters.AddWithValue("@MainCurrentStock", ObjBELStockAdjust.MainCurrentStock);
            cmd.Parameters.AddWithValue("@AdjustedStock", ObjBELStockAdjust.AdjustedStock);
            cmd.Parameters.AddWithValue("@BatchNo", ObjBELStockAdjust.BatchNo);
            cmd.Parameters.AddWithValue("@Remark", ObjBELStockAdjust.Remark);           
            cmd.Parameters.AddWithValue("@CreatedBy", ObjBELStockAdjust.CreatedBy);
            object message;
            message = cmd.ExecuteScalar();
            return Convert.ToString(message);

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

    public DataSet FillItemSearch(BEL Itemdetails)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_SearchItem", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@ItemId", Itemdetails.ItemId);
            cmd.Parameters.AddWithValue("@MainCategory", Itemdetails.MainCategory);
            cmd.Parameters.AddWithValue("@CategoryId",Itemdetails.CategoryId);
            cmd.Parameters.AddWithValue("@FId", Itemdetails.Fid);
            cmd.Parameters.AddWithValue("@BranchId", Itemdetails.BranchId);
            cmd.Parameters.AddWithValue("@WareHouseId", Itemdetails.WareHouseId);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Dispose();
            con.Close();
        }
    
    }
    

     public List<string> AutoFillPackage(string prefixtext)
    {
        // BEL ItemInfo = new BEL();

        SqlConnection con = new SqlConnection(constr);
        con.Open();
        //con.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;//ToString();

        try
        {
            SqlCommand cmd = new SqlCommand("Sp_GetListOfPackageWithId", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Search", prefixtext);
            

            List<string> items = new List<string>();
            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                items.Add(sdr["PackageName"].ToString());
            }



            return items;
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

     public List<string> AutoFillDeptWithId(string prefixtext)
    {
        // BEL ItemInfo = new BEL();

        SqlConnection con = new SqlConnection(constr);
        con.Open();
        //con.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;//ToString();

        try
        {
            SqlCommand cmd = new SqlCommand("Sp_GetListOfDepartmentWithId", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Search", prefixtext);
            

            List<string> items = new List<string>();
            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                items.Add(sdr["DeptName"].ToString());
            }



            return items;
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

     public DataSet FillDeptSearch( BEL dept)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_SearchDepartment", con);
         cmd.CommandType = CommandType.StoredProcedure;
         try
         {
             cmd.Parameters.AddWithValue("@DeptId", dept.DeptId);
            
             SqlDataAdapter sda = new SqlDataAdapter(cmd);
             DataSet ds = new DataSet();
             sda.Fill(ds);
             return ds;

         }
         catch (Exception ex)
         {
             throw ex;
         }
         finally
         {
             con.Dispose();
             con.Close();
         }
     }

     public DataSet FillPackageSearch(BEL dept)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_SearchPackage", con);
         cmd.CommandType = CommandType.StoredProcedure;
         try
         {
             cmd.Parameters.AddWithValue("@PackageId", dept.PackageId);

             SqlDataAdapter sda = new SqlDataAdapter(cmd);
             DataSet ds = new DataSet();
             sda.Fill(ds);
             return ds;

         }
         catch (Exception ex)
         {
             throw ex;
         }
         finally
         {
             con.Dispose();
             con.Close();
         }
     }



     public List<string> AutoFillSuppWithId(string prefixtext)
    {
        // BEL ItemInfo = new BEL();

        SqlConnection con = new SqlConnection(constr);
        con.Open();
        //con.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;//ToString();

        try
        {
            SqlCommand cmd = new SqlCommand("Sp_GetListOfSupplierWithId", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Search", prefixtext);
            

            List<string> items = new List<string>();
            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                items.Add(sdr["SupplierName"].ToString());
            }



            return items;
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

     public DataSet FillSuppSearch( BEL Supp)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_SearchSupplier", con);
         cmd.CommandType = CommandType.StoredProcedure;
         try
         {
             cmd.Parameters.AddWithValue("@SuppId", Supp.SuppId);
            
             SqlDataAdapter sda = new SqlDataAdapter(cmd);
             DataSet ds = new DataSet();
             sda.Fill(ds);
             return ds;

         }
         catch (Exception ex)
         {
             throw ex;
         }
         finally
         {
             con.Dispose();
             con.Close();
         }
     }

     public List<string> AutoFillMfgCompWithId(string prefixtext)
     {
         // BEL ItemInfo = new BEL();

         SqlConnection con = new SqlConnection(constr);
         con.Open();
         //con.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;//ToString();

         try
         {
             SqlCommand cmd = new SqlCommand("Sp_GetListOfMfgCompWithId", con);

             cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.AddWithValue("@Search", prefixtext);


             List<string> items = new List<string>();
             SqlDataReader sdr = cmd.ExecuteReader();

             while (sdr.Read())
             {
                 items.Add(sdr["MfgCompName"].ToString());
             }



             return items;
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

     public DataSet FillMfgSearch(BEL Mfg)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_SearchMfgComp", con);
         cmd.CommandType = CommandType.StoredProcedure;
         try
         {
             cmd.Parameters.AddWithValue("@MfgCompId", Mfg.MfgCompId);

             SqlDataAdapter sda = new SqlDataAdapter(cmd);
             DataSet ds = new DataSet();
             sda.Fill(ds);
             return ds;

         }
         catch (Exception ex)
         {
             throw ex;
         }
         finally
         {
             con.Dispose();
             con.Close();
         }
     }


     public DataSet FillDeptWiseStockSearch(BEL Dept)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_SearchDeptStock", con);
         cmd.CommandType = CommandType.StoredProcedure;
         try
         {
             cmd.Parameters.AddWithValue("@DeptId", Dept.DeptId);
             cmd.Parameters.AddWithValue("@CategoryId", Dept.CategoryId);
             cmd.Parameters.AddWithValue("@IssueTo", Dept.P_IssueTo);
             cmd.Parameters.AddWithValue("@UserId", Dept.UserID);
             cmd.Parameters.AddWithValue("@Branchid", Dept.BranchId);

             SqlDataAdapter sda = new SqlDataAdapter(cmd);
             DataSet ds = new DataSet();
             sda.Fill(ds);
             return ds;

         }
         catch (Exception ex)
         {
             throw ex;
         }
         finally
         {
             con.Dispose();
             con.Close();
         }
     }

     public DataSet Fill_DeptWiseStockSearch(BEL Dept)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_SearchDeptStock", con);
         cmd.CommandType = CommandType.StoredProcedure;
         try
         {
             cmd.Parameters.AddWithValue("@IssueTo", Dept.P_IssueTo);
             cmd.Parameters.AddWithValue("@branchid", Dept.BranchId);

             SqlDataAdapter sda = new SqlDataAdapter(cmd);
             DataSet ds = new DataSet();
             sda.Fill(ds);
             return ds;

         }
         catch (Exception ex)
         {
             throw ex;
         }
         finally
         {
             con.Dispose();
             con.Close();
         }
     }


     public DataSet FillIndReqSearch(BEL Dept)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_SearchIndReqList", con);
         cmd.CommandType = CommandType.StoredProcedure;
         try
         {
             cmd.Parameters.AddWithValue("@DeptId", Dept.DeptId);
             cmd.Parameters.AddWithValue("@ItemId", Dept.ItemId);
             cmd.Parameters.AddWithValue("@ReqId", Dept.ReqId);
             cmd.Parameters.AddWithValue("@RPIFlag", Dept.RPIflag);
             SqlDataAdapter sda = new SqlDataAdapter(cmd);
             DataSet ds = new DataSet();
             sda.Fill(ds);
             return ds;

         }
         catch (Exception ex)
         {
             throw ex;
         }
         finally
         {
             con.Dispose();
             con.Close();
         }
     }
     public DataSet FillInvoiceList()
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_Vw_InvoiceList", con);
         cmd.CommandType = CommandType.StoredProcedure;
         try
         {

             SqlDataAdapter sda = new SqlDataAdapter(cmd);
             DataSet ds = new DataSet();
             sda.Fill(ds);
             return ds;

         }
         catch (Exception ex)
         {
             throw ex;
         }
         finally
         {
             con.Dispose();
             con.Close();
         }
     }
      public DataSet FillBulkInvoiceList(int PONo)
      {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_BulkInvoiceList", con);
         cmd.CommandType = CommandType.StoredProcedure;
         try
         {
             cmd.Parameters.AddWithValue("@PONo", PONo);
             SqlDataAdapter sda = new SqlDataAdapter(cmd);
             DataSet ds = new DataSet();
             sda.Fill(ds);
             return ds;

         }
         catch (Exception ex)
         {
             throw ex;
         }
         finally
         {
             con.Dispose();
             con.Close();
         }
     }

     public DataSet FillPurchaseOrderList()
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_Vw_PurchaseOrderList", con);
         cmd.CommandType = CommandType.StoredProcedure;
         try
         {

             SqlDataAdapter sda = new SqlDataAdapter(cmd);
             DataSet ds = new DataSet();
             sda.Fill(ds);
             return ds;

         }
         catch (Exception ex)
         {
             throw ex;
         }
         finally
         {
             con.Dispose();
             con.Close();
         }
     }

     public DataSet SearchInvoiceList(string FromDate,string ToDate,int SuppId,int InvoiceNo,int Status,int FId,int BranchId,int WareHouseId)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_Vw_SearchInvoiceList", con);
         cmd.CommandType = CommandType.StoredProcedure;
         try
         {
             if (FromDate == "")
             {
                 cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
             }
             else
             {
                
                 cmd.Parameters.AddWithValue("@FromDate",DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
             }
             if (ToDate == "")
             {
                 cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

             }
             else
             {
                // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                 cmd.Parameters.AddWithValue("@ToDate",DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
             }

             cmd.Parameters.AddWithValue("@SupplierId",SuppId);
             cmd.Parameters.AddWithValue("@InvoiceNo",InvoiceNo);
             cmd.Parameters.AddWithValue("@Status", Status);
             cmd.Parameters.AddWithValue("@FId", FId);
             cmd.Parameters.AddWithValue("@BranchId", BranchId);
             cmd.Parameters.AddWithValue("@WareHouseId", WareHouseId);
             SqlDataAdapter sda = new SqlDataAdapter(cmd);
             DataSet ds = new DataSet();
             sda.Fill(ds);
             return ds;

         }
         catch (Exception ex)
         {
             throw ex;
         }
         finally
         {
             con.Dispose();
             con.Close();
         }
     }

     public DataSet SearchIncomeReport(string FromDate, string ToDate, int IssueVoucherNo, int FId, int BranchId)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_IncomeReport", con);
         cmd.CommandType = CommandType.StoredProcedure;
         try
         {
             if (FromDate == "")
             {
                 cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
             }
             else
             {

                 cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
             }
             if (ToDate == "")
             {
                 cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

             }
             else
             {
                 // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                 cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
             }

           
             cmd.Parameters.AddWithValue("@IssueVoucherNo", IssueVoucherNo);
            
             cmd.Parameters.AddWithValue("@FId", FId);
             cmd.Parameters.AddWithValue("@BranchId", BranchId);
             SqlDataAdapter sda = new SqlDataAdapter(cmd);
             DataSet ds = new DataSet();
             sda.Fill(ds);
             ds.Tables[0].TableName = "IncomeReport";
             return ds;

         }
         catch (Exception ex)
         {
             throw ex;
         }
         finally
         {
             con.Dispose();
             con.Close();
         }
     }


     public DataSet SearchSupplierInvoiceList(string FromDate, string ToDate, int SuppId, int InvoiceNo, int FId, int BranchId,int WareHouseId)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_SupplierWiseSummary", con);
         cmd.CommandType = CommandType.StoredProcedure;
         try
         {
             if (FromDate == "")
             {
                 cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
             }
             else
             {

                 cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
             }
             if (ToDate == "")
             {
                 cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

             }
             else
             {
                 // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                 cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
             }

             cmd.Parameters.AddWithValue("@SupplierId", SuppId);
             cmd.Parameters.AddWithValue("@InvoiceNo", InvoiceNo);
             cmd.Parameters.AddWithValue("@FId", FId);
             cmd.Parameters.AddWithValue("@BranchId", BranchId);
             cmd.Parameters.AddWithValue("@WareHouseId", WareHouseId);
             SqlDataAdapter sda = new SqlDataAdapter(cmd);
             DataSet ds = new DataSet();
             sda.Fill(ds);
             return ds;

         }
         catch (Exception ex)
         {
             throw ex;
         }
         finally
         {
             con.Dispose();
             con.Close();
         }
     }


     public DataSet SearchPurchaseList(string FromDate, string ToDate, int SuppId, int PoNo,int Status,int WareHouseId)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_Vw_SearchPOList", con);
         cmd.CommandType = CommandType.StoredProcedure;
         try
         {
             if (FromDate == "")
             {
                 cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
             }
             else
             {
                 // cmd.Parameters.AddWithValue("@FromDate",Convert.ToDateTime(FromDate));
                 cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
             }
             if (ToDate == "")
             {
                 cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

             }
             else
             {
                 // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                 cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
             }

             cmd.Parameters.AddWithValue("@SupplierId", SuppId);
             cmd.Parameters.AddWithValue("@PoNo", PoNo);
             cmd.Parameters.AddWithValue("@Status", Status);
             cmd.Parameters.AddWithValue("@WareHouseId", WareHouseId);
             SqlDataAdapter sda = new SqlDataAdapter(cmd);
             DataSet ds = new DataSet();
             sda.Fill(ds);
             return ds;

         }
         catch (Exception ex)
         {
             throw ex;
         }
         finally
         {
             con.Dispose();
             con.Close();
         }
     }

     public DataSet MPO_SearchPurchaseList(string FromDate, string ToDate, int SuppId, int PoNo, int Status ,int WareHouseId)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_Vw_SearchPOListForMPO", con);
         cmd.CommandType = CommandType.StoredProcedure;
         try
         {
             if (FromDate == "")
             {
                 cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
             }
             else
             {
                 // cmd.Parameters.AddWithValue("@FromDate",Convert.ToDateTime(FromDate));
                 cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
             }
             if (ToDate == "")
             {
                 cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

             }
             else
             {
                 // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                 cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
             }

             cmd.Parameters.AddWithValue("@SupplierId", SuppId);
             cmd.Parameters.AddWithValue("@PoNo", PoNo);
             cmd.Parameters.AddWithValue("@Status", Status);
             cmd.Parameters.AddWithValue("@wareHouseId", WareHouseId);
             SqlDataAdapter sda = new SqlDataAdapter(cmd);
             DataSet ds = new DataSet();
             sda.Fill(ds);
             return ds;

         }
         catch (Exception ex)
         {
             throw ex;
         }
         finally
         {
             con.Dispose();
             con.Close();
         }
     }

     public DataSet SearchInvoiceSupplierPayment(string FromDate, string ToDate, int SuppId, int InvoiceNo, string PaymentStatus, int WareHouseId)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_FillSuppwiseInvoiceAmountDetails", con);
         cmd.CommandType = CommandType.StoredProcedure;
         try
         {
             if (FromDate == "")
             {
                 cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
             }
             else
             {
                 // cmd.Parameters.AddWithValue("@FromDate",Convert.ToDateTime(FromDate));
                 cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
             }
             if (ToDate == "")
             {
                 cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

             }
             else
             {
                 // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                 cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
             }

             cmd.Parameters.AddWithValue("@SupplierId", SuppId);
             cmd.Parameters.AddWithValue("@InvoiceNo", InvoiceNo);
             cmd.Parameters.AddWithValue("@PaymentStatus", PaymentStatus);
             cmd.Parameters.AddWithValue("@WareHouseId", WareHouseId);
             SqlDataAdapter sda = new SqlDataAdapter(cmd);
             DataSet ds = new DataSet();
             sda.Fill(ds);
             return ds;

         }
         catch (Exception ex)
         {
             throw ex;
         }
         finally
         {
             con.Dispose();
             con.Close();
         }
     }

     public DataSet MPO_SearchPurchaseList_AfterMPO(string FromDate, string ToDate, int SuppId, int PoNo, int Status,int WareHouseId)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_Vw_SearchPOListForMPO_After", con);
         cmd.CommandType = CommandType.StoredProcedure;
         try
         {
             if (FromDate == "")
             {
                 cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
             }
             else
             {
                 // cmd.Parameters.AddWithValue("@FromDate",Convert.ToDateTime(FromDate));
                 cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
             }
             if (ToDate == "")
             {
                 cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

             }
             else
             {
                 // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                 cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
             }

             cmd.Parameters.AddWithValue("@SupplierId", SuppId);
             cmd.Parameters.AddWithValue("@PoNo", PoNo);
             cmd.Parameters.AddWithValue("@Status", Status);
             cmd.Parameters.AddWithValue("@WareHouseId", WareHouseId);
             SqlDataAdapter sda = new SqlDataAdapter(cmd);
             DataSet ds = new DataSet();
             sda.Fill(ds);
             return ds;

         }
         catch (Exception ex)
         {
             throw ex;
         }
         finally
         {
             con.Dispose();
             con.Close();
         }
     }

     public DataSet SearchInvoicePaymentTransactions(string FromDate, string ToDate, int SuppId)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_FillSuppwiseInvoiceAmountDetails", con);
         cmd.CommandType = CommandType.StoredProcedure;
         try
         {
             if (FromDate == "")
             {
                 cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
             }
             else
             {
                 // cmd.Parameters.AddWithValue("@FromDate",Convert.ToDateTime(FromDate));
                 cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
             }
             if (ToDate == "")
             {
                 cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

             }
             else
             {
                 // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                 cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
             }

             cmd.Parameters.AddWithValue("@SupplierId", SuppId);
             //cmd.Parameters.AddWithValue("@InvoiceNo", InvoiceNo);
             //cmd.Parameters.AddWithValue("@PaymentStatus", PaymentStatus);
             SqlDataAdapter sda = new SqlDataAdapter(cmd);
             DataSet ds = new DataSet();
             sda.Fill(ds);
             return ds;

         }
         catch (Exception ex)
         {
             throw ex;
         }
         finally
         {
             con.Dispose();
             con.Close();
         }
     }



     public string ExistItemBatch(BEL ObjItem)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_ExistItemBatchInStock", con);
         cmd.CommandType = CommandType.StoredProcedure;
         try
         {
             cmd.Parameters.AddWithValue("@ItemId", ObjItem.ItemId);
             cmd.Parameters.AddWithValue("@BatchNo", ObjItem.BatchNo);

             object result = cmd.ExecuteScalar();
             return Convert.ToString(result);

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

     public decimal GetItemCurrentStockaBatchwise(BEL DeptDetails)
     {

         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_GetBatchWiseItemCurrentStock", con);
         cmd.CommandType = CommandType.StoredProcedure;


         try
         {
             cmd.Parameters.AddWithValue("@ItemId", DeptDetails.ItemId);
             cmd.Parameters.AddWithValue("@BatchNo", DeptDetails.BatchNo);

             SqlDataReader sdr = cmd.ExecuteReader();
             decimal currentstock = 0;
             while (sdr.Read())
             {
                 currentstock = Convert.ToDecimal(sdr["CurrentStock"]);

             }
             return currentstock;
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

     public void UpdateItemCurrentStock(BEL DeptDetails)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_UpdateBatchwiseItemCurrentStock", con);
         cmd.CommandType = CommandType.StoredProcedure;
         try
         {
             cmd.Parameters.AddWithValue("@ItemId", DeptDetails.ItemId);
             cmd.Parameters.AddWithValue("@BatchNo", DeptDetails.BatchNo);
             cmd.Parameters.AddWithValue("@CurrentStock", DeptDetails.CurrStock);
            
             cmd.ExecuteNonQuery();
             con.Close();
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
     public void UpadteDeptWiseCurrentStock(BEL ItemCurrStock)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_UpdateDepartmentBulkStock", con);
         cmd.CommandType = CommandType.StoredProcedure;
         try
         {
             cmd.Parameters.AddWithValue("@ItemId", ItemCurrStock.ItemId);
             cmd.Parameters.AddWithValue("@DeptId", ItemCurrStock.DeptId);
             cmd.Parameters.AddWithValue("@CurrentStock", ItemCurrStock.CurrStock);
             cmd.Parameters.AddWithValue("@BatchNo", ItemCurrStock.BatchNo);
             cmd.Parameters.AddWithValue("@FId", ItemCurrStock.Fid);
             cmd.Parameters.AddWithValue("@Reason", ItemCurrStock.Remark);
             cmd.Parameters.AddWithValue("@BranchId", ItemCurrStock.BranchId);
             cmd.Parameters.AddWithValue("@CreatedBy", ItemCurrStock.CreatedBy);
             cmd.ExecuteNonQuery();
             con.Close();
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

     public object[] LoginValidation(string UserName, string UserPassword)
     {
         object[] Result = new object[10];
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("SP_LoginValidation", con);
         cmd.CommandType = CommandType.StoredProcedure;
         try
         {
        
            
              cmd.Parameters.AddWithValue( "@UserName", UserName);
              cmd.Parameters.AddWithValue("@UserPassword", UserPassword);
             //objDatabase.AddOutParameter(objDBCommand, "@UserId", DbType.Int32, 4);
             //objDatabase.AddOutParameter(objDBCommand, "@RoleId", DbType.Int32, 4);
             //objDatabase.AddOutParameter(objDBCommand, "@RoleName", DbType.String, 150);
             //objDatabase.AddOutParameter(objDBCommand, "@EmployeeId", DbType.String, 151);
             Result[0] = cmd.ExecuteScalar();
             //Result[1] = Convert.ToInt32(Convert.ToString(cmd.ParameterValue(objDBCommand, "@UserId")));
             //Result[2] = Convert.ToInt32(Convert.ToString(objDatabase.GetParameterValue(objDBCommand, "@RoleId")));
             //Result[3] = Convert.ToString(objDatabase.GetParameterValue(objDBCommand, "@RoleName"));
             //Result[4] = Convert.ToString(objDatabase.GetParameterValue(objDBCommand, "@EmployeeId"));
             return Result;
         }
         catch (Exception)
         {
             throw;
         }
         finally
         {

         }
     }

     public DataTable FillDdlPONo()
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlDataAdapter da = new SqlDataAdapter("Sp_FillPONo", con);
         da.SelectCommand.CommandType = CommandType.StoredProcedure;         
         DataTable dt = new DataTable();
         da.Fill(dt);
         return dt;
     }

     public BEL GetsupplierOfPo(int PoNo)
     {
         BEL supp = new BEL();
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_GetsupplierOfPo", con);
         cmd.CommandType = CommandType.StoredProcedure;


         try
         {
             cmd.Parameters.AddWithValue("@PoNo", PoNo);


             SqlDataReader sdr = cmd.ExecuteReader();

             while (sdr.Read())
             {
                 supp.SuppName = Convert.ToString(sdr["SupplierName"]);
                 supp.SuppId = Convert.ToInt32(sdr["SupplierId"]);
                 

             }
             return supp;
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
     public string InsertPayment(BEL objBELPayment)
     {
        
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_InsertInvoicePayment", con);
         cmd.CommandType = CommandType.StoredProcedure;
         try
         {
             cmd.Parameters.AddWithValue("@InvoiceDetailId", objBELPayment.InvoiceDetailId);
             cmd.Parameters.AddWithValue("@BillNo", objBELPayment.BillNo);
             cmd.Parameters.AddWithValue("@BillAmount", objBELPayment.BillAmount);
             cmd.Parameters.AddWithValue("@PaymentDate",DateTime.ParseExact(objBELPayment.Paymentdate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
             cmd.Parameters.AddWithValue("@DiscountPercent", objBELPayment.DiscountPercent);
             cmd.Parameters.AddWithValue("@DiscountAmount", objBELPayment.DiscountAmount);
             cmd.Parameters.AddWithValue("@BillAmountWithDisc", objBELPayment.BillAmountWithDisc);
             cmd.Parameters.AddWithValue("@PaymentTypeId", objBELPayment.PaymentTypeId);
             cmd.Parameters.AddWithValue("@AmountPaid", objBELPayment.AmountPaid);
             cmd.Parameters.AddWithValue("@AmountBalance", objBELPayment.BalanceAmount);
             cmd.Parameters.AddWithValue("@Number", objBELPayment.ChequeNumber);
             if(objBELPayment.Chequedate != null)
             {
             cmd.Parameters.AddWithValue("@ChequeDate", DateTime.ParseExact(objBELPayment.Chequedate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
             }
             cmd.Parameters.AddWithValue("@BankName", objBELPayment.BankName);
             cmd.Parameters.AddWithValue("@IsActive", objBELPayment.IsActive);
             cmd.Parameters.AddWithValue("@CreatedBy", objBELPayment.CreatedBy);
             cmd.Parameters.AddWithValue("@WareHouseId", objBELPayment.WareHouseId);
            
             object Result = cmd.ExecuteScalar();
             return Convert.ToString(Result);





             //cmd.ExecuteNonQuery();
             //con.Close();
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

     public void UpdatePaymentStatusInInvoiceAmtDetail(BEL objBELPayment)
     {
          SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_UpdateInvoiceAmtDetails", con);
         cmd.CommandType = CommandType.StoredProcedure;
         try
         {
             cmd.Parameters.AddWithValue("@InvoiceDetailId", objBELPayment.InvoiceDetailId);
             cmd.Parameters.AddWithValue("@PaymentStatus", objBELPayment.PaymentStaus.Trim());
             cmd.ExecuteNonQuery();
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

     public DataTable FillDdlDirectIssuetoDept()
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlDataAdapter da = new SqlDataAdapter("Sp_BindDdlDirectIssueToDept", con);
         da.SelectCommand.CommandType = CommandType.StoredProcedure;
         DataTable dt = new DataTable();
         da.Fill(dt);
         return dt;
     }

     public BEL FillSupplierWiseItemPrice(int ItemId, int SupplierId)
     {
         BEL price = new BEL();
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_SupplierWiseItemSellingPrice", con);
         cmd.CommandType = CommandType.StoredProcedure;


         try
         {
             cmd.Parameters.AddWithValue("@ItemId", ItemId);
             cmd.Parameters.AddWithValue("@SupplierId", SupplierId);

             SqlDataReader sdr = cmd.ExecuteReader();

             while (sdr.Read())
             {
                 price.PerPackCost = Convert.ToDecimal(sdr["PerPackCost"]);
                 price.UnitsPerPack = Convert.ToInt32(sdr["UnitsPerPack"]);
                 price.SellingPrice = Convert.ToDecimal(sdr["SellingPrice"]);

             }
             return price;
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
     public DataSet BindDdlDIDept()
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_FillDdlDirectIssueToDept", con);
         cmd.CommandType = CommandType.StoredProcedure;
         SqlDataAdapter da = new SqlDataAdapter(cmd);
         DataSet ds = new DataSet();
         da.Fill(ds);
         return ds;
     }

     public DataSet FillInsuranceMaster()
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("FillInsuranceMaster", con);
         cmd.CommandType = CommandType.StoredProcedure;
         SqlDataAdapter da = new SqlDataAdapter(cmd);
         DataSet ds = new DataSet();
         da.Fill(ds);
         return ds;
     }
     public DataSet FillInsuranceMaster_HMS()
     {
         SqlConnection con = new SqlConnection(constrHMS);
         con.Open();
         SqlCommand cmd = new SqlCommand("FillInsuranceMaster_HMS", con);
         cmd.CommandType = CommandType.StoredProcedure;
         SqlDataAdapter da = new SqlDataAdapter(cmd);
         DataSet ds = new DataSet();
         da.Fill(ds);
         return ds;
     }

     public DataSet FillDoseMaster()
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_FillDoseMaster", con);
         cmd.CommandType = CommandType.StoredProcedure;
         SqlDataAdapter da = new SqlDataAdapter(cmd);
         DataSet ds = new DataSet();
         da.Fill(ds);
         return ds;
     }
     public DataSet GetInstruction()
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_GetInstruction", con);
         cmd.CommandType = CommandType.StoredProcedure;
         SqlDataAdapter da = new SqlDataAdapter(cmd);
         DataSet ds = new DataSet();
         da.Fill(ds);
         return ds;
     }
     public DataSet FillDoseTimes()
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_FillDoseTimes", con);
         cmd.CommandType = CommandType.StoredProcedure;
         SqlDataAdapter da = new SqlDataAdapter(cmd);
         DataSet ds = new DataSet();
         da.Fill(ds);
         return ds;
     }
     public int CheckExistDIDept(BEL DeptInfo)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_CheckExist", con);
         cmd.CommandType = CommandType.StoredProcedure;
         try
         {
             cmd.Parameters.AddWithValue("@DeptName", DeptInfo.DeptName);
             cmd.Parameters.AddWithValue("@Flag", "DIDepartment");
             int count = Convert.ToInt16(cmd.ExecuteScalar());
             con.Close();
             return count;
         }
         catch (Exception ex)
         {
             throw (ex);
         }
         finally
         {
             con.Dispose();
             con.Close();
         }
     }

     public void DeleteDIDept(BEL DeptInfo)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_ISUDDirectIssueDept", con);
         cmd.CommandType = CommandType.StoredProcedure;
         try
         {
             cmd.Parameters.AddWithValue("@DeptId", DeptInfo.DeptId);
             cmd.Parameters.AddWithValue("@Flag", "Delete");
             cmd.ExecuteNonQuery();
             con.Close();
         }
         catch (Exception ex)
         {
             throw (ex);
         }
         finally
         {
             con.Dispose();
             con.Close();
         }

     }
     public DataTable FillDdlItemwiseSupplier(int ItemId)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlDataAdapter da = new SqlDataAdapter("Sp_BindItemWiseSupplierList", con);
         da.SelectCommand.CommandType = CommandType.StoredProcedure;
         da.SelectCommand.Parameters.AddWithValue("@ItemId", ItemId);
         DataTable dt = new DataTable();
         da.Fill(dt);
         return dt;
     }
     public DataSet FillDIDeptSearch(BEL dept)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_SearchDIDepartment", con);
         cmd.CommandType = CommandType.StoredProcedure;
         try
         {
             cmd.Parameters.AddWithValue("@DeptId", dept.DeptId);

             SqlDataAdapter sda = new SqlDataAdapter(cmd);
             DataSet ds = new DataSet();
             sda.Fill(ds);
             return ds;

         }
         catch (Exception ex)
         {
             throw ex;
         }
         finally
         {
             con.Dispose();
             con.Close();
         }
     }

     public DataSet FillDirectIssueList()
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_Vw_DirectIssueVoucherList", con);
         cmd.CommandType = CommandType.StoredProcedure;
         try
         {

             SqlDataAdapter sda = new SqlDataAdapter(cmd);
             DataSet ds = new DataSet();
             sda.Fill(ds);
             return ds;

         }
         catch (Exception ex)
         {
             throw ex;
         }
         finally
         {
             con.Dispose();
             con.Close();
         }
     }

    public BEL FillEditInvoiceInfo(int InvoiceDetailId,int FId,int BranchId,int WareHouseId)
    {
        BEL objBELInvoiceInfo=new BEL();
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_FillEditInvoiceInfo", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@InvoiceDetailId", InvoiceDetailId);
        cmd.Parameters.AddWithValue("@FId", FId);
        cmd.Parameters.AddWithValue("@BranchId", BranchId);
        cmd.Parameters.AddWithValue("@WareHouseID", WareHouseId);
        SqlDataReader sdr = cmd.ExecuteReader();
        try
        {
            while (sdr.Read())
            {
               objBELInvoiceInfo.FreightCharges=Convert.ToDecimal(sdr["FreightCharges"]);
               objBELInvoiceInfo.InvoiceNo = Convert.ToInt32(sdr["InvoiceNo"]);
               objBELInvoiceInfo.SuppName = sdr["SupplierName"].ToString();
               objBELInvoiceInfo.Invoicedate = Convert.ToString(sdr["InvoiceDate"]);
               objBELInvoiceInfo.SuppId = Convert.ToInt32(sdr["SupplierId"]);
               objBELInvoiceInfo.ChallanNo = Convert.ToString(sdr["ChallanNo"]);
            }
        }
         catch (Exception ex)
         {
             throw ex;
         }
         finally
         {
             con.Dispose();
             con.Close();
         }


        return objBELInvoiceInfo;
    }

    public BEL FillEditIndentInfo_Warehouse(int IndreqDeptId, int FId, int BranchId, int WareHouseId)
    {
        BEL objBELIndentInfo = new BEL();
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_FillEditIndentInfo_Warehouse", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@IndreqDeptId", IndreqDeptId);
        cmd.Parameters.AddWithValue("@FId", FId);
        cmd.Parameters.AddWithValue("@BranchId", BranchId);
        cmd.Parameters.AddWithValue("@WareHouseId", WareHouseId);

        SqlDataReader sdr = cmd.ExecuteReader();
        try
        {
            while (sdr.Read())
            {
                objBELIndentInfo.ReqId = Convert.ToInt32(sdr["ReqId"]);
                objBELIndentInfo.VoucherNo = Convert.ToInt32(sdr["VoucherNo"]);
                objBELIndentInfo.DeptId = Convert.ToInt32(sdr["DeptId"]);
                objBELIndentInfo.StoreType = Convert.ToInt32(sdr["StoreType"]);
                objBELIndentInfo.Remark = Convert.ToString(sdr["Remark"]);
                objBELIndentInfo.WareHouseId = Convert.ToInt32(sdr["WareHouseId"]);
                //objBELInvoiceInfo.Invoicedate = Convert.ToString(sdr["InvoiceDate"]);
                //objBELInvoiceInfo.SuppId = Convert.ToInt32(sdr["SupplierId"]);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Dispose();
            con.Close();
        }


        return objBELIndentInfo;
    }

    public BEL FillEditIndentInfo(int IndreqDeptId, int FId, int BranchId,int WareHouseId)
    {
        BEL objBELIndentInfo = new BEL();
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_FillEditIndentInfo", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@IndreqDeptId", IndreqDeptId);
        cmd.Parameters.AddWithValue("@FId", FId);
        cmd.Parameters.AddWithValue("@BranchId", BranchId);
        cmd.Parameters.AddWithValue("@WareHouseId", WareHouseId);

        SqlDataReader sdr = cmd.ExecuteReader();
        try
        {
            while (sdr.Read())
            {
                objBELIndentInfo.ReqId = Convert.ToInt32(sdr["ReqId"]);
                objBELIndentInfo.VoucherNo = Convert.ToInt32(sdr["VoucherNo"]);
                objBELIndentInfo.DeptId = Convert.ToInt32(sdr["DeptId"]);
                objBELIndentInfo.StoreType = Convert.ToInt32(sdr["StoreType"]);
                objBELIndentInfo.WareHouseId = Convert.ToInt32(sdr["WareHouseId"]);
                //objBELInvoiceInfo.Invoicedate = Convert.ToString(sdr["InvoiceDate"]);
                //objBELInvoiceInfo.SuppId = Convert.ToInt32(sdr["SupplierId"]);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Dispose();
            con.Close();
        }


        return objBELIndentInfo;
    }
    public string GetMFGCompName(int MfgCompId)
    {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_GetMfgCompName", con);
         cmd.CommandType = CommandType.StoredProcedure;

         try
         {
             cmd.Parameters.AddWithValue("@MfgCompId", MfgCompId);
             object Result = cmd.ExecuteScalar();
             return Convert.ToString(Result);
         }
         catch (Exception ex)
         {
             throw ex;
         }
         finally
         {
             con.Dispose();
             con.Close();
         }

    }
    public DataTable FillEditInvoiceItems(int InvoiceNo, int InvoiceDetailId, int SupplierId, int FId, int BranchId, int WareHouseId)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_FillEditInvoiceItems", con);
         cmd.CommandType = CommandType.StoredProcedure;

         try
         {
             cmd.Parameters.AddWithValue("@SupplierId", SupplierId);
             cmd.Parameters.AddWithValue("@InvoiceNo", InvoiceNo);
             cmd.Parameters.AddWithValue("@InvoiceDetailId", InvoiceDetailId);
             cmd.Parameters.AddWithValue("@FId", FId);
             cmd.Parameters.AddWithValue("@BranchId", BranchId);
             cmd.Parameters.AddWithValue("@WareHouseId", WareHouseId);
             SqlDataAdapter sda = new SqlDataAdapter(cmd);
             DataTable dt= new DataTable();
             sda.Fill(dt);
             return dt;

         }
         catch (Exception ex)
         {
             throw ex;
         }
         finally
         {
             con.Dispose();
             con.Close();
         }
     }

     public DataTable FillEditIndentItems(int IndreqDeptId, int ReqId, int DeptId, int FId, int BranchId,int WareHouseId)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_FillEditIndentItems", con);
         cmd.CommandType = CommandType.StoredProcedure;

         try
         {
             cmd.Parameters.AddWithValue("@ReqId", ReqId);
             cmd.Parameters.AddWithValue("@IndreqDeptId", IndreqDeptId);
             cmd.Parameters.AddWithValue("@DeptId", DeptId);
             cmd.Parameters.AddWithValue("@FId", FId);
             cmd.Parameters.AddWithValue("@BranchId", BranchId);
             cmd.Parameters.AddWithValue("@WareHouseId", WareHouseId);
             SqlDataAdapter sda = new SqlDataAdapter(cmd);
             DataTable dt= new DataTable();
             sda.Fill(dt);
             return dt;

         }
         catch (Exception ex)
         {
             throw ex;
         }
         finally
         {
             con.Dispose();
             con.Close();
         }
     }

     public void InsertIndentItemsInDeptStock(int IndreqDeptId, int ReqId, int DeptId, int FId, int BranchId)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_InsertStockInDept_New", con);
         cmd.CommandType = CommandType.StoredProcedure;

         try
         {
             cmd.Parameters.AddWithValue("@ReqId", ReqId);
             cmd.Parameters.AddWithValue("@IndreqDeptId", IndreqDeptId);
             cmd.Parameters.AddWithValue("@DeptId", DeptId);
             cmd.Parameters.AddWithValue("@FId", FId);
             cmd.Parameters.AddWithValue("@BranchId", BranchId);
             cmd.ExecuteNonQuery();
             con.Close();
             //SqlDataAdapter sda = new SqlDataAdapter(cmd);
             //DataTable dt = new DataTable();
             //sda.Fill(dt);
             //return dt;

         }
         catch (Exception ex)
         {
             throw ex;
         }
         finally
         {
             con.Dispose();
             con.Close();
         }
     }
     public DataTable FillEditIndentItems_Warehouse(int IndreqDeptId, int ReqId, int DeptId, int FId, int BranchId, int WareHouseId)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_FillEditIndentItems_Warehouse", con);
         cmd.CommandType = CommandType.StoredProcedure;

         try
         {
             cmd.Parameters.AddWithValue("@ReqId", ReqId);
             cmd.Parameters.AddWithValue("@IndreqDeptId", IndreqDeptId);
             cmd.Parameters.AddWithValue("@DeptId", DeptId);
             cmd.Parameters.AddWithValue("@FId", FId);
             cmd.Parameters.AddWithValue("@BranchId", BranchId);
             cmd.Parameters.AddWithValue("@WareHouseId", WareHouseId);
             SqlDataAdapter sda = new SqlDataAdapter(cmd);
             DataTable dt = new DataTable();
             sda.Fill(dt);
             return dt;

         }
         catch (Exception ex)
         {
             throw ex;
         }
         finally
         {
             con.Dispose();
             con.Close();
         }
     }
     public void InsertDIDept(BEL DeptInfo)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_ISUDDirectIssueDept", con);
         cmd.CommandType = CommandType.StoredProcedure;
         try
         {
             cmd.Parameters.AddWithValue("@DeptName", DeptInfo.DeptName);

             cmd.Parameters.AddWithValue("@CreatedOn", DeptInfo.CreatedOn);
             cmd.Parameters.AddWithValue("@CreatedBy", DeptInfo.CreatedBy);
             cmd.Parameters.AddWithValue("@UpdatedOn", DeptInfo.UpdatedOn);
             cmd.Parameters.AddWithValue("@UpdatedBy", DeptInfo.UpdatedBy);
             cmd.Parameters.AddWithValue("@Flag", "Insert");
             cmd.ExecuteNonQuery();
             con.Close();
         }
         catch (Exception ex)
         {
             throw (ex);
         }
         finally
         {
             con.Dispose();
             con.Close();
         }

     }
    public DataSet SearchDirectIssueListForInsurance(string FromDate, string ToDate, int Deptid, int VoucherNo, int FId, int BranchId, string PatRegNo,string PatientType,int WareHouseId)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_PatientIssueVoucherListForInsurance", con);
         cmd.CommandType = CommandType.StoredProcedure;
         try
         {
             if (FromDate == "")
             {
                 cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
             }
             else
             {
                 // cmd.Parameters.AddWithValue("@FromDate",Convert.ToDateTime(FromDate));
                 cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
             }
             if (ToDate == "")
             {
                 cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

             }
             else
             {
                 // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                 cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
             }
             cmd.Parameters.AddWithValue("@PatRegNo", PatRegNo);
             cmd.Parameters.AddWithValue("@DeptId", Deptid);
             cmd.Parameters.AddWithValue("@IssueVoucherNo", VoucherNo);
             cmd.Parameters.AddWithValue("@BranchId",BranchId);
             cmd.Parameters.AddWithValue("@FId",FId);
             cmd.Parameters.AddWithValue("@PatientType", PatientType);
             cmd.Parameters.AddWithValue("@WareHouseId", WareHouseId);
             SqlDataAdapter sda = new SqlDataAdapter(cmd);
             DataSet ds = new DataSet();
             sda.Fill(ds);
             return ds;

         }
         catch (Exception ex)
         {
             throw ex;
         }
         finally
         {
             con.Dispose();
             con.Close();
         }
     }

    
     public DataSet SearchDirectIssueListForInsurance_FinalSettlement(string FromDate, string ToDate, int Deptid, int VoucherNo, int FId, int BranchId, string PatRegNo,string PatientType,int WareHouseId)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_PatientIssueVoucherListForFinalSettlement", con);
         cmd.CommandType = CommandType.StoredProcedure;
         try
         {
             if (FromDate == "")
             {
                 cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
             }
             else
             {
                 // cmd.Parameters.AddWithValue("@FromDate",Convert.ToDateTime(FromDate));
                 cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
             }
             if (ToDate == "")
             {
                 cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

             }
             else
             {
                 // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                 cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
             }
             cmd.Parameters.AddWithValue("@PatRegNo", PatRegNo);
             cmd.Parameters.AddWithValue("@DeptId", Deptid);
             cmd.Parameters.AddWithValue("@IssueVoucherNo", VoucherNo);
             cmd.Parameters.AddWithValue("@BranchId",BranchId);
             cmd.Parameters.AddWithValue("@FId",FId);
             cmd.Parameters.AddWithValue("@PatientType",PatientType);
             cmd.Parameters.AddWithValue("@WareHouseId", WareHouseId);
             SqlDataAdapter sda = new SqlDataAdapter(cmd);
             DataSet ds = new DataSet();
             sda.Fill(ds);
             return ds;

         }
         catch (Exception ex)
         {
             throw ex;
         }
         finally
         {
             con.Dispose();
             con.Close();
         }
     }

     public DataSet SearchPrescriptionIssueList(string FromDate, string ToDate, int Deptid, int VoucherNo, int FId, int BranchId, string PatRegNo)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_PatientPrescriptionIssueVoucherList", con);
         cmd.CommandType = CommandType.StoredProcedure;
         try
         {
             if (FromDate == "")
             {
                 cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
             }
             else
             {
                 // cmd.Parameters.AddWithValue("@FromDate",Convert.ToDateTime(FromDate));
                 cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
             }
             if (ToDate == "")
             {
                 cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

             }
             else
             {
                 // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                 cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
             }
             cmd.Parameters.AddWithValue("@PatRegNo", PatRegNo);
             cmd.Parameters.AddWithValue("@DeptId", Deptid);
             cmd.Parameters.AddWithValue("@IssueVoucherNo", VoucherNo);
             cmd.Parameters.AddWithValue("@BranchId", BranchId);
             cmd.Parameters.AddWithValue("@FId", FId);
             SqlDataAdapter sda = new SqlDataAdapter(cmd);
             DataSet ds = new DataSet();
             sda.Fill(ds);
             return ds;

         }
         catch (Exception ex)
         {
             throw ex;
         }
         finally
         {
             con.Dispose();
             con.Close();
         }
     }

    public DataSet SearchDirectIssueList(string FromDate, string ToDate, int Deptid, int VoucherNo, int FId, int BranchId, string PatRegNo,string PatientType,int WareHouseId)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_PatientIssueVoucherList", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            if (FromDate == "")
            {
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            }
            else
            {
                // cmd.Parameters.AddWithValue("@FromDate",Convert.ToDateTime(FromDate));
                cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            if (ToDate == "")
            {
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            }
            else
            {
                // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            cmd.Parameters.AddWithValue("@PatRegNo", PatRegNo);
            cmd.Parameters.AddWithValue("@DeptId", Deptid);
            cmd.Parameters.AddWithValue("@IssueVoucherNo", VoucherNo);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@PatientType", PatientType);
            cmd.Parameters.AddWithValue("@WareHouseId", WareHouseId);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Dispose();
            con.Close();
        }
    }

    public DataTable Search_Credit_BackIssueList( int Deptid, int VoucherNo, int FId, int BranchId, string PatRegNo, string PatientType)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_PatientIssueIPDCreditBackList", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
           
            cmd.Parameters.AddWithValue("@PatRegNo", PatRegNo);
            cmd.Parameters.AddWithValue("@DeptId", Deptid);
            cmd.Parameters.AddWithValue("@IssueVoucherNo", VoucherNo);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@PatientType", PatientType);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            sda.Fill(ds);
            return ds;

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Dispose();
            con.Close();
        }
    }

    //=========================================================
    public void IUpdatePatientDrugDetails(BELPatientIssueVoucher PoInfo)
    {

        SqlConnection con = new SqlConnection(constrHMS);
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_UpdateTreatmentReceive", con);
        cmd.CommandType = CommandType.StoredProcedure;
        // string Expdate = "1/1/2000";
        try
        {
            cmd.Parameters.AddWithValue("@PatRegNo", PoInfo.PatRegNo);
            cmd.Parameters.AddWithValue("@IPDNO", PoInfo.IpdNo);
            cmd.Parameters.AddWithValue("@OPDNO", PoInfo.OpdNo);
            cmd.Parameters.AddWithValue("@BranchId", PoInfo.BranchId);
            cmd.Parameters.AddWithValue("@TreatmentId", PoInfo.TreatmentId);
           

            //cmd.Parameters.AddWithValue("@PerPackCost", PoInfo.PerPackCost);
            // cmd.Parameters.AddWithValue("@SellingPrice", PoInfo.SellingPrice);
            //cmd.Parameters.AddWithValue("@IssueVoucherNO", PoInfo.VoucherNo);


            cmd.ExecuteNonQuery();
            con.Close();
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

    //=========================================================

     public int InserPatientIssueVoucher(BELPatientIssueVoucher PoInfo)
     {
         
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_InsertPatientIssueVoucher", con);
         cmd.CommandType = CommandType.StoredProcedure;
         int PatIssueVoucherId = 0;
         // string Expdate = "1/1/2000";
         try
         {
            //cmd.Parameters.AddWithValue("@ItemId", PoInfo.ItemId);
             cmd.Parameters.AddWithValue("@IssueDate", DateTime.ParseExact(PoInfo.Issuedate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
           //  cmd.Parameters.AddWithValue("@TotalTax", PoInfo.TotalTax);
             //cmd.Parameters.AddWithValue("@TotalAmt", PoInfo.TotalAmt);
            // cmd.Parameters.AddWithValue("@IssueQty", PoInfo.IssueQty);
            cmd.Parameters.AddWithValue("@PatientType",PoInfo.PatientType);
            cmd.Parameters.AddWithValue("@PatRegNo",PoInfo.PatRegNo);
            cmd.Parameters.AddWithValue("@PatientName",PoInfo.PatientName);
            cmd.Parameters.AddWithValue("@PatAddress",PoInfo.PatAddress);
            cmd.Parameters.AddWithValue("@Age",PoInfo.Age);
            cmd.Parameters.AddWithValue("@AgeType",PoInfo.AgeType);
            cmd.Parameters.AddWithValue("@Allergies",PoInfo.Allergies);
            cmd.Parameters.AddWithValue("@DrName",PoInfo.DrName);
            cmd.Parameters.AddWithValue("@DrId", PoInfo.DrId);
            cmd.Parameters.AddWithValue("@IssueVoucherNo",PoInfo.IssueVoucherNo);
            //cmd.Parameters.AddWithValue("@IssueDate",PoInfo.Issuedate);
            cmd.Parameters.AddWithValue("@PaymentType",PoInfo.PaymentType);
            cmd.Parameters.AddWithValue("@TotalAmt",PoInfo.TotalAmt);
            cmd.Parameters.AddWithValue("@DiscAmt",PoInfo.DiscAmt);
            cmd.Parameters.AddWithValue("@DiscType",PoInfo.DiscType);
            cmd.Parameters.AddWithValue("@TotalTax",PoInfo.TotalTax);	
            cmd.Parameters.AddWithValue("@GrandTotal",PoInfo.GrandTotal);
            cmd.Parameters.AddWithValue("@AmountReceived",PoInfo.AmountReceived);
            cmd.Parameters.AddWithValue("@Balance",PoInfo.Balance);
            cmd.Parameters.AddWithValue("@DiscRemark",PoInfo.DiscRemark);
            cmd.Parameters.AddWithValue("@Note",PoInfo.Note);
            cmd.Parameters.AddWithValue("@ChequeNo",PoInfo.ChequeNo);
            cmd.Parameters.AddWithValue("@BankName",PoInfo.BankName);
            cmd.Parameters.AddWithValue("@InsuranceComp",PoInfo.InsuranceComp);
            cmd.Parameters.AddWithValue("@InsuranceAmount",PoInfo.InsuranceAmount);
            cmd.Parameters.AddWithValue("@StaffName",PoInfo.StaffName);
            cmd.Parameters.AddWithValue("@StaffRemark",PoInfo.StaffRemark);
            cmd.Parameters.AddWithValue("@CardName",PoInfo.CardName);
            cmd.Parameters.AddWithValue("@DeptId", PoInfo.DeptId);
            cmd.Parameters.AddWithValue("@CreatedBy", PoInfo.CreatedBy);
            cmd.Parameters.AddWithValue("@FId", PoInfo.Fid);
            cmd.Parameters.AddWithValue("@BranchId", PoInfo.BranchId);
            cmd.Parameters.AddWithValue("@IsInsurance", PoInfo.IsInsuranceFlag);
            cmd.Parameters.AddWithValue("@IsEmergency", PoInfo.IsEmergency);
            cmd.Parameters.AddWithValue("@TreatmentId", PoInfo.TreatmentId);
            cmd.Parameters.AddWithValue("@IPDNO", PoInfo.IpdNo);
            cmd.Parameters.AddWithValue("@wareHouseId", PoInfo.wareHouseId);
            cmd.Parameters.AddWithValue("@InsuranceCompId", PoInfo.InsuranceComp_ID);
            cmd.Parameters.AddWithValue("@ChildInsuranceCompId", PoInfo.InsuranceChildComp_ID);
            cmd.Parameters.AddWithValue("@PatientMainType", PoInfo.PatientMainType);
            cmd.Parameters.Add("@PatIssueVoucherId", SqlDbType.Int).Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();
             PatIssueVoucherId = Convert.ToInt32(cmd.Parameters["@PatIssueVoucherId"].Value);//.ToString();
            return PatIssueVoucherId;
   
             //cmd.ExecuteNonQuery();
             //con.Close();
         }
         catch (Exception ex)
         {
             return PatIssueVoucherId = 0;
             throw ex;
         }
         finally
         {
             con.Close();
             con.Dispose();
         }
     }

     public int InserPatientIssueVoucher_Prescription(BELPatientIssueVoucher PoInfo)
     {

         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_InsertPatientIssueVoucher_Prescription", con);
         cmd.CommandType = CommandType.StoredProcedure;
         int PatIssueVoucherId = 0;
         // string Expdate = "1/1/2000";
         try
         {
             //cmd.Parameters.AddWithValue("@ItemId", PoInfo.ItemId);
             cmd.Parameters.AddWithValue("@IssueDate", DateTime.ParseExact(PoInfo.Issuedate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
             //  cmd.Parameters.AddWithValue("@TotalTax", PoInfo.TotalTax);
             //cmd.Parameters.AddWithValue("@TotalAmt", PoInfo.TotalAmt);
             // cmd.Parameters.AddWithValue("@IssueQty", PoInfo.IssueQty);
             cmd.Parameters.AddWithValue("@PatientType", PoInfo.PatientType);
             cmd.Parameters.AddWithValue("@PatRegNo", PoInfo.PatRegNo);
             cmd.Parameters.AddWithValue("@PatientName", PoInfo.PatientName);
             cmd.Parameters.AddWithValue("@PatAddress", PoInfo.PatAddress);
             cmd.Parameters.AddWithValue("@Age", PoInfo.Age);
             cmd.Parameters.AddWithValue("@AgeType", PoInfo.AgeType);
             cmd.Parameters.AddWithValue("@Allergies", PoInfo.Allergies);
             cmd.Parameters.AddWithValue("@DrName", PoInfo.DrName);
             cmd.Parameters.AddWithValue("@DrId", PoInfo.DrId);
             cmd.Parameters.AddWithValue("@IssueVoucherNo", PoInfo.IssueVoucherNo);
             //cmd.Parameters.AddWithValue("@IssueDate",PoInfo.Issuedate);
             cmd.Parameters.AddWithValue("@PaymentType", PoInfo.PaymentType);
             cmd.Parameters.AddWithValue("@TotalAmt", PoInfo.TotalAmt);
             cmd.Parameters.AddWithValue("@DiscAmt", PoInfo.DiscAmt);
             cmd.Parameters.AddWithValue("@DiscType", PoInfo.DiscType);
             cmd.Parameters.AddWithValue("@TotalTax", PoInfo.TotalTax);
             cmd.Parameters.AddWithValue("@GrandTotal", PoInfo.GrandTotal);
             cmd.Parameters.AddWithValue("@AmountReceived", PoInfo.AmountReceived);
             cmd.Parameters.AddWithValue("@Balance", PoInfo.Balance);
             cmd.Parameters.AddWithValue("@DiscRemark", PoInfo.DiscRemark);
             cmd.Parameters.AddWithValue("@Note", PoInfo.Note);
             cmd.Parameters.AddWithValue("@ChequeNo", PoInfo.ChequeNo);
             cmd.Parameters.AddWithValue("@BankName", PoInfo.BankName);
             cmd.Parameters.AddWithValue("@InsuranceComp", PoInfo.InsuranceComp);
             cmd.Parameters.AddWithValue("@InsuranceAmount", PoInfo.InsuranceAmount);
             cmd.Parameters.AddWithValue("@StaffName", PoInfo.StaffName);
             cmd.Parameters.AddWithValue("@StaffRemark", PoInfo.StaffRemark);
             cmd.Parameters.AddWithValue("@CardName", PoInfo.CardName);
             cmd.Parameters.AddWithValue("@DeptId", PoInfo.DeptId);
             cmd.Parameters.AddWithValue("@CreatedBy", PoInfo.CreatedBy);
             cmd.Parameters.AddWithValue("@FId", PoInfo.Fid);
             cmd.Parameters.AddWithValue("@BranchId", PoInfo.BranchId);
             cmd.Parameters.AddWithValue("@IsInsurance", PoInfo.IsInsuranceFlag);
             cmd.Parameters.Add("@PatIssueVoucherId", SqlDbType.Int).Direction = ParameterDirection.Output;

             cmd.ExecuteNonQuery();
             PatIssueVoucherId = Convert.ToInt32(cmd.Parameters["@PatIssueVoucherId"].Value);//.ToString();
             return PatIssueVoucherId;

             //cmd.ExecuteNonQuery();
             //con.Close();
         }
         catch (Exception ex)
         {
             return PatIssueVoucherId = 0;
             throw ex;
         }
         finally
         {
             con.Close();
             con.Dispose();
         }
     }

     public void InsertPatientItemIN_HMS(BELPatientIssueVoucher PoInfo)
     {

         SqlConnection con = new SqlConnection(Dbhospital);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_InsertPatientIssueDrugDetails", con);
         cmd.CommandType = CommandType.StoredProcedure;
         // string Expdate = "1/1/2000";
         try
         {
             cmd.Parameters.AddWithValue("@CreatedBy", PoInfo.CreatedBy);
             cmd.Parameters.AddWithValue("@ItemId", PoInfo.ItemId);
             cmd.Parameters.AddWithValue("@IssueDate", DateTime.ParseExact(PoInfo.Issuedate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));




             cmd.Parameters.AddWithValue("@patregid", PoInfo.PatRegNo);
             cmd.Parameters.AddWithValue("@IpdNo", PoInfo.IpdNo);
             cmd.Parameters.AddWithValue("@Rate", PoInfo.Rate);

             cmd.Parameters.AddWithValue("@IssueQty", PoInfo.IssueQty);
             cmd.Parameters.AddWithValue("@TotalCharges", PoInfo.TotalAmt);
             cmd.Parameters.AddWithValue("@BillNo", PoInfo.BillNo);
             cmd.Parameters.AddWithValue("@FId", PoInfo.Fid);
             cmd.Parameters.AddWithValue("@BranchId", PoInfo.BranchId);
             cmd.Parameters.AddWithValue("@ItemName", PoInfo.ItemName);
             cmd.Parameters.AddWithValue("@Diagnosis", PoInfo.Allergies);




             cmd.ExecuteNonQuery();
             con.Close();
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

     public void UpdateDrugIssueStatusIN_HMS(BELPatientIssueVoucher PoInfo)
     {

         SqlConnection con = new SqlConnection(Dbhospital);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_UpdateDrugIssueStatusIN_HMS", con);
         cmd.CommandType = CommandType.StoredProcedure;
         // string Expdate = "1/1/2000";
         try
         {
            
             cmd.Parameters.AddWithValue("@patregid", PoInfo.PatRegNo);
             cmd.Parameters.AddWithValue("@IpdNo", PoInfo.IpdNo);           
            
             cmd.Parameters.AddWithValue("@BranchId", PoInfo.BranchId);
             cmd.Parameters.AddWithValue("@TreatmentId", PoInfo.TreatmentId);




             cmd.ExecuteNonQuery();
             con.Close();
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

   
     public void InsertPatientIssueVoucherDetails(BELPatientIssueVoucher PoInfo)
     {
         
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_InsertPatientIssueVoucherDetails", con);
         cmd.CommandType = CommandType.StoredProcedure;
         // string Expdate = "1/1/2000";
         try
         {
             cmd.Parameters.AddWithValue("@CreatedBy", PoInfo.CreatedBy);
             cmd.Parameters.AddWithValue("@ItemId", PoInfo.ItemId);
             cmd.Parameters.AddWithValue("@IssueDate", DateTime.ParseExact(PoInfo.Issuedate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
             if (PoInfo.InvoiceExpdate != null)
             {
                 cmd.Parameters.AddWithValue("@ExpDate", DateTime.ParseExact(PoInfo.InvoiceExpdate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
             }
             


             cmd.Parameters.AddWithValue("@BatchNo", PoInfo.BatchNo);
             cmd.Parameters.AddWithValue("@IssueVoucherNO", PoInfo.IssueVoucherNo);
             cmd.Parameters.AddWithValue("@CurrentStock", PoInfo.CurrentStock);
             cmd.Parameters.AddWithValue("@Rate", PoInfo.Rate);
             cmd.Parameters.AddWithValue("@Tax", PoInfo.Tax);
             //cmd.Parameters.AddWithValue("@TotalAmount", PoInfo.TotalAmt);
             cmd.Parameters.AddWithValue("@IssueQty", PoInfo.IssueQty);
             cmd.Parameters.AddWithValue("@FId", PoInfo.Fid);
             cmd.Parameters.AddWithValue("@BranchId", PoInfo.BranchId);
             cmd.Parameters.AddWithValue("@DeptId", PoInfo.DeptId);
             cmd.Parameters.AddWithValue("@PatIssueVoucherId", PoInfo.PatIssueVoucherId);
             cmd.Parameters.AddWithValue("@IssueTo", PoInfo.IssueTo);
             cmd.Parameters.AddWithValue("@DoseId", PoInfo.DoseId);
             cmd.Parameters.AddWithValue("@Days", PoInfo.Days);
             cmd.Parameters.AddWithValue("@DoseTimeId", PoInfo.DoseTimeId);
             cmd.Parameters.AddWithValue("@Remark", PoInfo.Remark);

             cmd.Parameters.AddWithValue("@InstName", PoInfo.InstName);
             cmd.Parameters.AddWithValue("@NewDose", PoInfo.NewDose);

            // cmd.Parameters.AddWithValue("@IsInsurance", PoInfo.IsInsuranceFlag);
             //cmd.Parameters.AddWithValue("@PerPackCost", PoInfo.PerPackCost);
            // cmd.Parameters.AddWithValue("@SellingPrice", PoInfo.SellingPrice);
             //cmd.Parameters.AddWithValue("@IssueVoucherNO", PoInfo.VoucherNo);


             cmd.ExecuteNonQuery();
             con.Close();
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
     public void InsertPatientIssueVoucherDetails_Prescription(BELPatientIssueVoucher PoInfo)
     {

         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_InsertPatientIssueVoucherDetails_Prescription", con);
         cmd.CommandType = CommandType.StoredProcedure;
         // string Expdate = "1/1/2000";
         try
         {
             cmd.Parameters.AddWithValue("@CreatedBy", PoInfo.CreatedBy);
             cmd.Parameters.AddWithValue("@ItemId", PoInfo.ItemId);
             cmd.Parameters.AddWithValue("@IssueDate", DateTime.ParseExact(PoInfo.Issuedate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
             if (PoInfo.InvoiceExpdate != null)
             {
                 cmd.Parameters.AddWithValue("@ExpDate", DateTime.ParseExact(PoInfo.InvoiceExpdate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
             }



             cmd.Parameters.AddWithValue("@BatchNo", PoInfo.BatchNo);
             cmd.Parameters.AddWithValue("@IssueVoucherNO", PoInfo.IssueVoucherNo);
             cmd.Parameters.AddWithValue("@CurrentStock", PoInfo.CurrentStock);
             cmd.Parameters.AddWithValue("@Rate", PoInfo.Rate);
             cmd.Parameters.AddWithValue("@Tax", PoInfo.Tax);
             //cmd.Parameters.AddWithValue("@TotalAmount", PoInfo.TotalAmt);
             cmd.Parameters.AddWithValue("@IssueQty", PoInfo.IssueQty);
             cmd.Parameters.AddWithValue("@FId", PoInfo.Fid);
             cmd.Parameters.AddWithValue("@BranchId", PoInfo.BranchId);
             cmd.Parameters.AddWithValue("@DeptId", PoInfo.DeptId);
             cmd.Parameters.AddWithValue("@PatIssueVoucherId", PoInfo.PatIssueVoucherId);
             cmd.Parameters.AddWithValue("@IssueTo", PoInfo.IssueTo);
             cmd.Parameters.AddWithValue("@DoseId", PoInfo.DoseId);
             cmd.Parameters.AddWithValue("@Days", PoInfo.Days);
             cmd.Parameters.AddWithValue("@DoseTimeId", PoInfo.DoseTimeId);
             cmd.Parameters.AddWithValue("@Remark", PoInfo.Remark);

             //cmd.Parameters.AddWithValue("@PerPackCost", PoInfo.PerPackCost);
             // cmd.Parameters.AddWithValue("@SellingPrice", PoInfo.SellingPrice);
             //cmd.Parameters.AddWithValue("@IssueVoucherNO", PoInfo.VoucherNo);


             cmd.ExecuteNonQuery();
             con.Close();
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
     public DataSet SearchDirectIssueList(string FromDate, string ToDate, int Deptid, int VoucherNo)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_SearchDirectIssueVoucherList", con);
         cmd.CommandType = CommandType.StoredProcedure;
         try
         {
             if (FromDate == "")
             {
                 cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
             }
             else
             {
                 // cmd.Parameters.AddWithValue("@FromDate",Convert.ToDateTime(FromDate));
                 cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
             }
             if (ToDate == "")
             {
                 cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

             }
             else
             {
                 // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                 cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
             }

             cmd.Parameters.AddWithValue("@IssueTo", Deptid);
             cmd.Parameters.AddWithValue("@IssueVoucherNo", VoucherNo);
             SqlDataAdapter sda = new SqlDataAdapter(cmd);
             DataSet ds = new DataSet();
             sda.Fill(ds);
             return ds;

         }
         catch (Exception ex)
         {
             throw ex;
         }
         finally
         {
             con.Dispose();
             con.Close();
         }
     }

     public DataTable DoctorWisePatientsList(string FromDate, string ToDate, int DrId,int DeptId, int FId,int BranchId)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_DoctorWisePatientList", con);
         cmd.CommandType = CommandType.StoredProcedure;
         try
         {
             if (FromDate == "")
             {
                 cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
             }
             else
             {
                 
                 cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
             }
             if (ToDate == "")
             {
                 cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

             }
             else
             {
                 // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                 cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
             }

             cmd.Parameters.AddWithValue("@DrId", DrId);
             cmd.Parameters.AddWithValue("@DeptId", DeptId);
             cmd.Parameters.AddWithValue("@FId", FId);
             cmd.Parameters.AddWithValue("@BranchId", BranchId);
             SqlDataAdapter sda = new SqlDataAdapter(cmd);
             DataTable dt = new DataTable();
             sda.Fill(dt);
             return dt;

         }
         catch (Exception ex)
         {
             throw ex;
         }
         finally
         {
             con.Dispose();
             con.Close();
         }
     }


     public DataSet FillMonthlyItemConsumptionForStore(string FromDate, string ToDate, int ItemId,int DeptId, int FId,int BranchId )
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_ItemWiseMonthlyConsumptionForStore", con);
         cmd.CommandType = CommandType.StoredProcedure;
         try
         {
             if (FromDate == "")
             {
                 cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
             }
             else
             {
                 // cmd.Parameters.AddWithValue("@FromDate",Convert.ToDateTime(FromDate));
                 cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
             }
             if (ToDate == "")
             {
                 cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

             }
             else
             {
                 // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                 cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
             }

             cmd.Parameters.AddWithValue("@ItemId", ItemId);
             cmd.Parameters.AddWithValue("@DeptId", DeptId);
             cmd.Parameters.AddWithValue("@FId", FId);
             cmd.Parameters.AddWithValue("@BranchId", BranchId);

             SqlDataAdapter sda = new SqlDataAdapter(cmd);
             DataSet ds = new DataSet();
             sda.Fill(ds);
             return ds;

         }
         catch (Exception ex)
         {
             throw ex;
         }
         finally
         {
             con.Dispose();
             con.Close();
         }
     }
     public DataSet FillMonthlyItemTaxForStore(string FromDate, string ToDate, int DeptId, int FId, int BranchId)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_TaxByAreaReport", con);
         cmd.CommandType = CommandType.StoredProcedure;
         try
         {
             if (FromDate == "")
             {
                 cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
             }
             else
             {
                 // cmd.Parameters.AddWithValue("@FromDate",Convert.ToDateTime(FromDate));
                 cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
             }
             if (ToDate == "")
             {
                 cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

             }
             else
             {
                 // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                 cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
             }

            
             cmd.Parameters.AddWithValue("@DeptId", DeptId);
             cmd.Parameters.AddWithValue("@FId", FId);
             cmd.Parameters.AddWithValue("@BranchId", BranchId);

             SqlDataAdapter sda = new SqlDataAdapter(cmd);
             DataSet ds = new DataSet();
             sda.Fill(ds);
             return ds;

         }
         catch (Exception ex)
         {
             throw ex;
         }
         finally
         {
             con.Dispose();
             con.Close();
         }
     }
     public DataSet FillMonthlyItemConsumption(string FromDate, string ToDate, int ItemId, int FId,int BranchId,int WareHouseId)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_ItemWiseMonthlyConsumption", con);
         cmd.CommandType = CommandType.StoredProcedure;
         try
         {
             if (FromDate == "")
             {
                 cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
             }
             else
             {
                 // cmd.Parameters.AddWithValue("@FromDate",Convert.ToDateTime(FromDate));
                 cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
             }
             if (ToDate == "")
             {
                 cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

             }
             else
             {
                 // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                 cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
             }

             cmd.Parameters.AddWithValue("@ItemId", ItemId);
             cmd.Parameters.AddWithValue("@FId", FId);
             cmd.Parameters.AddWithValue("@BranchId", BranchId);
             cmd.Parameters.AddWithValue("@WareHouseId", WareHouseId);

             SqlDataAdapter sda = new SqlDataAdapter(cmd);
             DataSet ds = new DataSet();
             sda.Fill(ds);
             return ds;

         }
         catch (Exception ex)
         {
             throw ex;
         }
         finally
         {
             con.Dispose();
             con.Close();
         }
     }
     public void UpdateDIDept(BEL DeptInfo)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_ISUDDirectIssueDept", con);
         cmd.CommandType = CommandType.StoredProcedure;
         try
         {
             cmd.Parameters.AddWithValue("@DeptId", DeptInfo.DeptId);
             cmd.Parameters.AddWithValue("@DeptName", DeptInfo.DeptName);
             // cmd.Parameters.AddWithValue("@BranchId", DeptInfo.BranchId);
             //cmd.Parameters.AddWithValue("@Fid", DeptInfo.Fid);
             cmd.Parameters.AddWithValue("@CreatedOn", DeptInfo.CreatedOn);
             cmd.Parameters.AddWithValue("@CreatedBy", DeptInfo.CreatedBy);
             cmd.Parameters.AddWithValue("@UpdatedOn", DeptInfo.UpdatedOn);
             cmd.Parameters.AddWithValue("@UpdatedBy", DeptInfo.UpdatedBy);
             cmd.Parameters.AddWithValue("@Flag", "Update");
             cmd.ExecuteNonQuery();
             con.Close();
         }
         catch (Exception ex)
         {
             throw (ex);
         }
         finally
         {
             con.Dispose();
             con.Close();
         }

     }

     public List<string> AutoFillInvoiceItems(string prefixtext)
     {
         // BEL ItemInfo = new BEL();

         SqlConnection con = new SqlConnection(constr);
         con.Open();
         //con.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;//ToString();

         try
         {
             SqlCommand cmd = new SqlCommand("Sp_GetList", con);

             cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.AddWithValue("@Search", prefixtext);
             cmd.Parameters.AddWithValue("@Flag", "InvoiceItemList");

             List<string> items = new List<string>();
             SqlDataReader sdr = cmd.ExecuteReader();

             while (sdr.Read())
             {
                 items.Add(sdr["ItemName"].ToString());
             }



             return items;
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

     public List<string> AutoFillIndentItems(string prefixtext, int DeptId, int WareHouseId)
     {
         // BEL ItemInfo = new BEL();

         SqlConnection con = new SqlConnection(constr);
         con.Open();
         //con.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;//ToString();

         try
         {
             SqlCommand cmd = new SqlCommand("Sp_GetIdentItemList", con);

             cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.AddWithValue("@Search", prefixtext);
            cmd.Parameters.AddWithValue("@DeptId", DeptId);
            cmd.Parameters.AddWithValue("@WareHouseId", WareHouseId);

             List<string> items = new List<string>();
             SqlDataReader sdr = cmd.ExecuteReader();

             while (sdr.Read())
             {
                 items.Add(sdr["ItemName"].ToString());
             }



             return items;
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

     public List<string> AutoFillIndentItems1(string prefixtext)
     {
         // BEL ItemInfo = new BEL();

         SqlConnection con = new SqlConnection(constr);
         con.Open();
         //con.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;//ToString();

         try
         {
             SqlCommand cmd = new SqlCommand("Sp_GetIdentItemList1", con);

             cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.AddWithValue("@Search", prefixtext);
             //cmd.Parameters.AddWithValue("@DeptId", DeptId);

             List<string> items = new List<string>();
             SqlDataReader sdr = cmd.ExecuteReader();

             while (sdr.Read())
             {
                 items.Add(sdr["ItemName"].ToString());
             }



             return items;
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

     public List<string> AutoFillIndentItems2(string prefixtext)
     {
         // BEL ItemInfo = new BEL();

         SqlConnection con = new SqlConnection(constr);
         con.Open();
         //con.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;//ToString();

         try
         {
             SqlCommand cmd = new SqlCommand("Sp_GetIdentItemList3", con);

             cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.AddWithValue("@Search", prefixtext);
             //cmd.Parameters.AddWithValue("@DeptId", DeptId);

             List<string> items = new List<string>();
             SqlDataReader sdr = cmd.ExecuteReader();

             while (sdr.Read())
             {
                 items.Add(sdr["ItemName"].ToString());
             }



             return items;
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

     public List<string> AutoFillDirectIssueDeptWithId(string prefixtext)
     {
         // BEL ItemInfo = new BEL();

         SqlConnection con = new SqlConnection(constr);
         con.Open();
         //con.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;//ToString();

         try
         {
             SqlCommand cmd = new SqlCommand("Sp_GetListOfDirectIssueDepartment", con);

             cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.AddWithValue("@Search", prefixtext);


             List<string> items = new List<string>();
             SqlDataReader sdr = cmd.ExecuteReader();

             while (sdr.Read())
             {
                 items.Add(sdr["DIDeptName"].ToString());
             }



             return items;
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

     public int GetInvoiceNo( BEL objBEL)
     {
         SqlConnection con = DataAccess.ConInitForPharmacy();
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_GetInvoiceNo", con);
         cmd.CommandType = CommandType.StoredProcedure;
         cmd.Parameters.AddWithValue("@FId", objBEL.Fid);
         cmd.Parameters.AddWithValue("@BranchId", objBEL.BranchId);
         cmd.Parameters.AddWithValue("@WareHouseID", objBEL.WareHouseId);
         try
         {

             object count = Convert.ToInt32(cmd.ExecuteScalar());
             return Convert.ToInt32(count);
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
     

     public void UpdateItemStockAndInvoiceStatus(BEL objBELInvoiceDetails)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_UpdateItemStockAndInvoiceStatus", con);
         cmd.CommandType = CommandType.StoredProcedure;
         try
         {
             cmd.Parameters.AddWithValue("@IsApprove", objBELInvoiceDetails.IsApprove);
             cmd.Parameters.AddWithValue("@InvoiceNo", objBELInvoiceDetails.InvoiceNo);
             cmd.Parameters.AddWithValue("@InvoiceDetailId", objBELInvoiceDetails.InvoiceDetailId);
             cmd.Parameters.AddWithValue("@FId", objBELInvoiceDetails.Fid);
             cmd.Parameters.AddWithValue("@BranchId", objBELInvoiceDetails.BranchId);
             cmd.Parameters.AddWithValue("@WareHouseId", objBELInvoiceDetails.WareHouseId);
             cmd.ExecuteNonQuery();
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


     public void UpdateDeptStockAndIndentStatus(BEL objBELIndentDetails)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_UpdateDeptStockAndIndentStatus", con);
         cmd.CommandType = CommandType.StoredProcedure;
         try
         {
             cmd.Parameters.AddWithValue("@IsApprove", objBELIndentDetails.IsApprove);
             cmd.Parameters.AddWithValue("@IssueDate", DateTime.ParseExact(objBELIndentDetails.IssueDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
                  cmd.Parameters.AddWithValue("@DeptId", objBELIndentDetails.DeptId);
             cmd.Parameters.AddWithValue("@ReqId", objBELIndentDetails.ReqId);
             cmd.Parameters.AddWithValue("@IndreqDeptId", objBELIndentDetails.IndreqDeptId);
             cmd.Parameters.AddWithValue("@FId", objBELIndentDetails.Fid);
             cmd.Parameters.AddWithValue("@BranchId", objBELIndentDetails.BranchId);
             cmd.Parameters.AddWithValue("@Createdby", objBELIndentDetails.CreatedBy);
             cmd.Parameters.AddWithValue("@VoucherNo", objBELIndentDetails.VoucherNo);
             cmd.Parameters.AddWithValue("@WareHouseId", objBELIndentDetails.WareHouseId);
             cmd.ExecuteNonQuery();
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
     public void UpdateDeptIndentProcessStatus_Warehouse(bool IsProcess, int ReqId, int IndreqDeptId, int FId, int BranchId, string CreatedBy, int WareHouseId)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_UpdateDeptIndentProcessStatus_warehouse", con);
         cmd.CommandType = CommandType.StoredProcedure;
         try
         {
             cmd.Parameters.AddWithValue("@IsProcess",IsProcess);
           //  cmd.Parameters.AddWithValue("@IssueDate", DateTime.ParseExact(objBELIndentDetails.IssueDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
             //             cmd.Parameters.AddWithValue("@IssueDate", objBELIndentDetails.IssueDate);
             cmd.Parameters.AddWithValue("@ReqId",ReqId);
             cmd.Parameters.AddWithValue("@IndreqDeptId",IndreqDeptId);
             cmd.Parameters.AddWithValue("@FId",FId);
             cmd.Parameters.AddWithValue("@BranchId",BranchId);
             cmd.Parameters.AddWithValue("@Createdby", CreatedBy);
             cmd.Parameters.AddWithValue("@WareHouseId", WareHouseId);
             cmd.ExecuteNonQuery();
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
     public void UpdateDeptIndentStatus_Wareouse(BEL objBELIndentDetails)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_UpdateDeptIndentStatus_Warehouse", con);//Sp_UpdateDeptStockAndIndentStatus
         cmd.CommandType = CommandType.StoredProcedure;
         try
         {
             cmd.Parameters.AddWithValue("@IsApprove", objBELIndentDetails.IsApprove);
             //cmd.Parameters.AddWithValue("@IssueDate", DateTime.ParseExact(objBELIndentDetails.IssueDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
             
             cmd.Parameters.AddWithValue("@ReqId", objBELIndentDetails.ReqId);
             cmd.Parameters.AddWithValue("@IndreqDeptId", objBELIndentDetails.IndreqDeptId);
             cmd.Parameters.AddWithValue("@FId", objBELIndentDetails.Fid);
             cmd.Parameters.AddWithValue("@BranchId", objBELIndentDetails.BranchId);
             cmd.Parameters.AddWithValue("@Createdby", objBELIndentDetails.CreatedBy);
             cmd.Parameters.AddWithValue("@WareHouseId", objBELIndentDetails.WareHouseId);
             cmd.ExecuteNonQuery();
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

     public void DeleteInvoice(int InvoiceId,int FId ,int BranchId,int WareHouseId)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_InvoiceDelete", con);
         cmd.CommandType = CommandType.StoredProcedure;
         try
         {
             cmd.Parameters.AddWithValue("@InvoiceId",InvoiceId);
             cmd.Parameters.AddWithValue("@FId", FId);
             cmd.Parameters.AddWithValue("@BranchId", BranchId);
             cmd.Parameters.AddWithValue("@WareHouseId", WareHouseId);
             cmd.ExecuteNonQuery();
             con.Close();
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

     public void DeletePatIssueVoucher(int PatIssueVoucherDetailId, int FId, int BranchId)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_PatIssueVoucherDelete", con);
         cmd.CommandType = CommandType.StoredProcedure;
         try
         {
             cmd.Parameters.AddWithValue("@PatIssueVoucherDetailId", PatIssueVoucherDetailId);
             cmd.Parameters.AddWithValue("@FId", FId);
             cmd.Parameters.AddWithValue("@BranchId", BranchId);
             cmd.ExecuteNonQuery();
             con.Close();
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
     public void DeleteIndent(int IndReq, int FId, int BranchId,int WareHouseId)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_DeleteIndRequest", con);
         cmd.CommandType = CommandType.StoredProcedure;
         try
         {
             cmd.Parameters.AddWithValue("@IndReq", IndReq);
             cmd.Parameters.AddWithValue("@FId", FId);
             cmd.Parameters.AddWithValue("@BranchId", BranchId);
             cmd.Parameters.AddWithValue("@WareHouseId", WareHouseId);
             cmd.ExecuteNonQuery();
             con.Close();
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

     public void DeleteIndent_Warehouse(int IndReq, int FId, int BranchId)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_DeleteIndRequest_Warehouse", con);
         cmd.CommandType = CommandType.StoredProcedure;
         try
         {
             cmd.Parameters.AddWithValue("@IndReq", IndReq);
             cmd.Parameters.AddWithValue("@FId", FId);
             cmd.Parameters.AddWithValue("@BranchId", BranchId);
             cmd.ExecuteNonQuery();
             con.Close();
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
     public DataSet GetIndent(BEL ObjBELIndentDetails)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_FillEditIndentItems", con);
         cmd.CommandType = CommandType.StoredProcedure;

         try
         {
             cmd.Parameters.AddWithValue("@ReqId", ObjBELIndentDetails.ReqId);
             cmd.Parameters.AddWithValue("@IndreqDeptId", ObjBELIndentDetails.IndreqDeptId);
             cmd.Parameters.AddWithValue("@DeptId", ObjBELIndentDetails.DeptId);
             cmd.Parameters.AddWithValue("@FId", ObjBELIndentDetails.Fid);
             cmd.Parameters.AddWithValue("@BranchId", ObjBELIndentDetails.BranchId);
             SqlDataAdapter sda = new SqlDataAdapter(cmd);
             DataSet dt = new DataSet();
             sda.Fill(dt);
             return dt;

         }
         catch (Exception ex)
         {
             throw ex;
         }
         finally
         {
             con.Dispose();
             con.Close();
         }
     }
     public DataSet GetIndent_Warehouse(BEL ObjBELIndentDetails)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_FillEditIndentItems_Warehouse", con);
         cmd.CommandType = CommandType.StoredProcedure;

         try
         {
             cmd.Parameters.AddWithValue("@ReqId", ObjBELIndentDetails.ReqId);
             cmd.Parameters.AddWithValue("@IndreqDeptId", ObjBELIndentDetails.IndreqDeptId);
             cmd.Parameters.AddWithValue("@DeptId", ObjBELIndentDetails.DeptId);
             cmd.Parameters.AddWithValue("@FId", ObjBELIndentDetails.Fid);
             cmd.Parameters.AddWithValue("@BranchId", ObjBELIndentDetails.BranchId);
             cmd.Parameters.AddWithValue("@WareHouseId", ObjBELIndentDetails.WareHouseId);
             SqlDataAdapter sda = new SqlDataAdapter(cmd);
             DataSet dt = new DataSet();
             sda.Fill(dt);
             return dt;

         }
         catch (Exception ex)
         {
             throw ex;
         }
         finally
         {
             con.Dispose();
             con.Close();
         }
     }
     public BELPatientIssueVoucher FillEditPatientInfo(int PatIssueVoucherId, int FId, int BranchId,int WareHouseId)
     {
         BELPatientIssueVoucher objBELPatientInfo = new BELPatientIssueVoucher();
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_FillEditPatientInfo", con);
         cmd.CommandType = CommandType.StoredProcedure;
         cmd.Parameters.AddWithValue("@PatIssueVoucherId", PatIssueVoucherId);
         cmd.Parameters.AddWithValue("@FId", FId);
         cmd.Parameters.AddWithValue("@BranchId", BranchId);
         cmd.Parameters.AddWithValue("@WareHouseId", WareHouseId);

         SqlDataReader sdr = cmd.ExecuteReader();
         try
         {
             while (sdr.Read())
             {
                 objBELPatientInfo.PatientType = Convert.ToString(sdr["PatientType"]);
                 objBELPatientInfo.PatRegNo = Convert.ToString(sdr["PatRegNo"]);
                 objBELPatientInfo.PatientName = Convert.ToString(sdr["PatientName"]);
                 objBELPatientInfo.PatAddress = Convert.ToString(sdr["PatAddress"]);
                 objBELPatientInfo.Age = Convert.ToInt32(sdr["Age"]);
                 objBELPatientInfo.AgeType = Convert.ToString(sdr["AgeType"]);
                 objBELPatientInfo.Allergies = Convert.ToString(sdr["Allergies"]);
                 objBELPatientInfo.DrName = Convert.ToString(sdr["DrName"]);
                 objBELPatientInfo.IssueVoucherNo = Convert.ToInt32(sdr["IssueVoucherNo"]);
                 objBELPatientInfo.Issuedate = Convert.ToString(Convert.ToDateTime(sdr["IssueDate"]).ToString("dd/MM/yyyy"));
                 objBELPatientInfo.PaymentType = Convert.ToString(sdr["PaymentType"]);
                 objBELPatientInfo.TotalAmt = Convert.ToDecimal(sdr["TotalAmt"]);
                 objBELPatientInfo.DiscAmt = Convert.ToDecimal(sdr["DiscAmt"]);
                 objBELPatientInfo.DiscType = Convert.ToString(sdr["DiscType"]);
                 objBELPatientInfo.TotalTax = Convert.ToDecimal(sdr["TotalTax"]);
                 objBELPatientInfo.GrandTotal = Convert.ToDecimal(sdr["GrandTotal"]);
                 objBELPatientInfo.AmountReceived = Convert.ToDecimal(sdr["AmountReceived"]);
                 objBELPatientInfo.Balance = Convert.ToDecimal(sdr["Balance"]);
                 objBELPatientInfo.DiscRemark = Convert.ToString(sdr["DiscRemark"]);
                 objBELPatientInfo.Note = Convert.ToString(sdr["Note"]);
                 objBELPatientInfo.ChequeNo = Convert.ToString(sdr["ChequeNo"]);
                 objBELPatientInfo.BankName = Convert.ToString(sdr["BankName"]);
                 objBELPatientInfo.InsuranceComp = Convert.ToString(sdr["InsuranceComp"]);
                 objBELPatientInfo.InsuranceAmount = Convert.ToDecimal(sdr["InsuranceAmount"]);
                 objBELPatientInfo.StaffName = Convert.ToString(sdr["StaffName"]);
                 objBELPatientInfo.StaffRemark = Convert.ToString(sdr["StaffRemark"]);
                 objBELPatientInfo.CardName = Convert.ToString(sdr["CardName"]);
                 if (sdr["IsInsurance"] != DBNull.Value)
                 {
                     objBELPatientInfo.IsInsuranceFlag = Convert.ToBoolean(sdr["IsInsurance"]);
                 }
                 else
                 {
                     objBELPatientInfo.IsInsuranceFlag =false;
                 }
                 if (sdr["InsuranceCompId"] != DBNull.Value)
                 {
                     objBELPatientInfo.InsuranceComp_ID = Convert.ToInt32(sdr["InsuranceCompId"]);
                 }
                 else
                 {
                     objBELPatientInfo.InsuranceComp_ID = 0;
                 }
                 if (sdr["WareHouseId"] != DBNull.Value)
                 {
                     objBELPatientInfo.wareHouseId = Convert.ToInt32(sdr["WareHouseId"]);
                 }
                 else
                 {
                     objBELPatientInfo.wareHouseId = 0;
                 }
                 //objBELIndentInfo.ReqId = Convert.ToInt32(sdr["ReqId"]);
                 //objBELIndentInfo.VoucherNo = Convert.ToInt32(sdr["VoucherNo"]);
                 //objBELIndentInfo.DeptId = Convert.ToInt32(sdr["DeptId"]);

             }
         }
         catch (Exception ex)
         {
             throw ex;
         }
         finally
         {
             con.Dispose();
             con.Close();
         }


         return objBELPatientInfo;
     }

     public BELPatientIssueVoucher FillEditPatientInfo_CreditBack(int IPDNO, int FId, int BranchId)
     {
         BELPatientIssueVoucher objBELPatientInfo = new BELPatientIssueVoucher();
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_FillEditPatientInfo_CreditBack", con);
         cmd.CommandType = CommandType.StoredProcedure;
         cmd.Parameters.AddWithValue("@IPDNO", IPDNO);
         cmd.Parameters.AddWithValue("@FId", FId);
         cmd.Parameters.AddWithValue("@BranchId", BranchId);

         SqlDataReader sdr = cmd.ExecuteReader();
         try
         {
             while (sdr.Read())
             {
                 objBELPatientInfo.PatientType = Convert.ToString(sdr["PatientType"]);
                 objBELPatientInfo.PatRegNo = Convert.ToString(sdr["PatRegNo"]);
                 objBELPatientInfo.PatientName = Convert.ToString(sdr["PatientName"]);
                 objBELPatientInfo.PatAddress = Convert.ToString(sdr["PatAddress"]);
                 objBELPatientInfo.Age = Convert.ToInt32(sdr["Age"]);
                 objBELPatientInfo.AgeType = Convert.ToString(sdr["AgeType"]);
                 objBELPatientInfo.Allergies = Convert.ToString(sdr["Allergies"]);
                 objBELPatientInfo.DrName = Convert.ToString(sdr["DrName"]);
                 objBELPatientInfo.IssueVoucherNo = Convert.ToInt32(sdr["IssueVoucherNo"]);
                 objBELPatientInfo.Issuedate = Convert.ToString(Convert.ToDateTime(sdr["IssueDate"]).ToString("dd/MM/yyyy"));
                 objBELPatientInfo.PaymentType = Convert.ToString(sdr["PaymentType"]);
                 objBELPatientInfo.TotalAmt = Convert.ToDecimal(sdr["TotalAmt"]);
                 objBELPatientInfo.DiscAmt = Convert.ToDecimal(sdr["DiscAmt"]);
                 objBELPatientInfo.DiscType = Convert.ToString(sdr["DiscType"]);
                 objBELPatientInfo.TotalTax = Convert.ToDecimal(sdr["TotalTax"]);
                 objBELPatientInfo.GrandTotal = Convert.ToDecimal(sdr["GrandTotal"]);
                 objBELPatientInfo.AmountReceived = Convert.ToDecimal(sdr["AmountReceived"]);
                 objBELPatientInfo.Balance = Convert.ToDecimal(sdr["Balance"]);
                 objBELPatientInfo.DiscRemark = Convert.ToString(sdr["DiscRemark"]);
                 objBELPatientInfo.Note = Convert.ToString(sdr["Note"]);
                 objBELPatientInfo.ChequeNo = Convert.ToString(sdr["ChequeNo"]);
                 objBELPatientInfo.BankName = Convert.ToString(sdr["BankName"]);
                 objBELPatientInfo.InsuranceComp = Convert.ToString(sdr["InsuranceComp"]);
                 objBELPatientInfo.InsuranceAmount = Convert.ToDecimal(sdr["InsuranceAmount"]);
                 objBELPatientInfo.StaffName = Convert.ToString(sdr["StaffName"]);
                 objBELPatientInfo.StaffRemark = Convert.ToString(sdr["StaffRemark"]);
                 objBELPatientInfo.CardName = Convert.ToString(sdr["CardName"]);
                 if (sdr["IsInsurance"] != DBNull.Value)
                 {
                     objBELPatientInfo.IsInsuranceFlag = Convert.ToBoolean(sdr["IsInsurance"]);
                 }
                 else
                 {
                     objBELPatientInfo.IsInsuranceFlag = false;
                 }

                 //objBELIndentInfo.ReqId = Convert.ToInt32(sdr["ReqId"]);
                 //objBELIndentInfo.VoucherNo = Convert.ToInt32(sdr["VoucherNo"]);
                 //objBELIndentInfo.DeptId = Convert.ToInt32(sdr["DeptId"]);

             }
         }
         catch (Exception ex)
         {
             throw ex;
         }
         finally
         {
             con.Dispose();
             con.Close();
         }


         return objBELPatientInfo;
     }
     public DataTable FillEditPatientIssueItems(int PatIssueVoucherId, int IssueVoucherNo, int DeptId, int FId, int BranchId,int WareHouseId)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_FillEditPatientItems", con);
         cmd.CommandType = CommandType.StoredProcedure;

         try
         {
             cmd.Parameters.AddWithValue("@IssueVoucherNo", IssueVoucherNo);
             cmd.Parameters.AddWithValue("@PatIssueVoucherId", PatIssueVoucherId);
             cmd.Parameters.AddWithValue("@DeptId", DeptId);
             cmd.Parameters.AddWithValue("@FId", FId);
             cmd.Parameters.AddWithValue("@BranchId", BranchId);
             cmd.Parameters.AddWithValue("@WareHouseId", WareHouseId);
             SqlDataAdapter sda = new SqlDataAdapter(cmd);
             DataTable dt = new DataTable();
             sda.Fill(dt);
             return dt;

         }
         catch (Exception ex)
         {
             throw ex;
         }
         finally
         {
             con.Dispose();
             con.Close();
         }
     }
     public DataTable FillEditPatientIssueItemsForCancelVoucher_CreditBack(int Patregid, int IPDNO, int DeptId, int FId, int BranchId)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_PatientIssueItemsForCancelVoucher_CreditBack", con);
         cmd.CommandType = CommandType.StoredProcedure;

         try
         {
             cmd.Parameters.AddWithValue("@PatRegNo", Patregid);
             cmd.Parameters.AddWithValue("@IPDNO", IPDNO);
             cmd.Parameters.AddWithValue("@DeptId", DeptId);
             cmd.Parameters.AddWithValue("@FId", FId);
             cmd.Parameters.AddWithValue("@BranchId", BranchId);
             SqlDataAdapter sda = new SqlDataAdapter(cmd);
             DataTable dt = new DataTable();
             sda.Fill(dt);
             return dt;

         }
         catch (Exception ex)
         {
             throw ex;
         }
         finally
         {
             con.Dispose();
             con.Close();
         }
     }

    public DataTable FillEditPatientIssueItemsForCancelVoucher(int PatIssueVoucherId, int IssueVoucherNo, int DeptId, int FId, int BranchId)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_FillEditItemsForCancelIssueVoucher", con);
         cmd.CommandType = CommandType.StoredProcedure;

         try
         {
             cmd.Parameters.AddWithValue("@IssueVoucherNo", IssueVoucherNo);
             cmd.Parameters.AddWithValue("@PatIssueVoucherId", PatIssueVoucherId);
             cmd.Parameters.AddWithValue("@DeptId", DeptId);
             cmd.Parameters.AddWithValue("@FId", FId);
             cmd.Parameters.AddWithValue("@BranchId", BranchId);
             SqlDataAdapter sda = new SqlDataAdapter(cmd);
             DataTable dt = new DataTable();
             sda.Fill(dt);
             return dt;

         }
         catch (Exception ex)
         {
             throw ex;
         }
         finally
         {
             con.Dispose();
             con.Close();
         }
     }
    public void UpdateFinalSettlementUser(int IssueVoucherNo, int DeptId, int PatIssueVoucherId, int FId, int BranchId, string FinalSettledBy, bool FinalSettledFlag, int WareHouseId)
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_UpdateFinalSettlementUser", con);
        cmd.CommandType = CommandType.StoredProcedure;

        try
        {
            cmd.Parameters.AddWithValue("@IssueVoucherNo", IssueVoucherNo);
            cmd.Parameters.AddWithValue("@PatIssueVoucherId", PatIssueVoucherId);
            cmd.Parameters.AddWithValue("@DeptId", DeptId);
            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.Parameters.AddWithValue("@FinalSettledBy", FinalSettledBy);
            cmd.Parameters.AddWithValue("@FinalSettledFlag",FinalSettledFlag);
            cmd.Parameters.AddWithValue("@WareHouseId", WareHouseId);
            cmd.ExecuteNonQuery();
            con.Close();

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Dispose();
            con.Close();
        }
    }
    
     public void UpdatePatientIssueVoucher(BELPatientIssueVoucher PoInfo)
     {

         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_UpdatePatientIssueVoucher", con);
         cmd.CommandType = CommandType.StoredProcedure;
         // string Expdate = "1/1/2000";
         try
         {
             cmd.Parameters.AddWithValue("@UpdatedBy", PoInfo.UpdatedBy);
            // cmd.Parameters.AddWithValue("@IssueDate", DateTime.ParseExact(PoInfo.Issuedate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
             cmd.Parameters.AddWithValue("@IssueVoucherNo", PoInfo.IssueVoucherNo);
             cmd.Parameters.AddWithValue("@PaymentType", PoInfo.PaymentType);
             cmd.Parameters.AddWithValue("@TotalAmt", PoInfo.TotalAmt);
             cmd.Parameters.AddWithValue("@DiscAmt", PoInfo.DiscAmt);
             cmd.Parameters.AddWithValue("@DiscType", PoInfo.DiscType);
             cmd.Parameters.AddWithValue("@TotalTax", PoInfo.TotalTax);
             cmd.Parameters.AddWithValue("@GrandTotal", PoInfo.GrandTotal);
             cmd.Parameters.AddWithValue("@AmountReceived", PoInfo.AmountReceived);
             cmd.Parameters.AddWithValue("@Balance", PoInfo.Balance);
             cmd.Parameters.AddWithValue("@DiscRemark", PoInfo.DiscRemark);
             cmd.Parameters.AddWithValue("@Note", PoInfo.Note);
             cmd.Parameters.AddWithValue("@ChequeNo", PoInfo.ChequeNo);
             cmd.Parameters.AddWithValue("@BankName", PoInfo.BankName);
             cmd.Parameters.AddWithValue("@InsuranceComp", PoInfo.InsuranceComp);
             cmd.Parameters.AddWithValue("@InsuranceAmount", PoInfo.InsuranceAmount);
             cmd.Parameters.AddWithValue("@StaffName", PoInfo.StaffName);
             cmd.Parameters.AddWithValue("@StaffRemark", PoInfo.StaffRemark);
             cmd.Parameters.AddWithValue("@CardName", PoInfo.CardName);
             cmd.Parameters.AddWithValue("@DeptId", PoInfo.DeptId);
            // cmd.Parameters.AddWithValue("@CreatedBy", PoInfo.CreatedBy);
             cmd.Parameters.AddWithValue("@FId", PoInfo.Fid);
             cmd.Parameters.AddWithValue("@BranchId", PoInfo.BranchId);
             cmd.Parameters.AddWithValue("@PatIssueVoucherId", PoInfo.PatIssueVoucherId);
             cmd.Parameters.AddWithValue("@IsInsurance", PoInfo.IsInsuranceFlag);
             cmd.Parameters.AddWithValue("@InsuranceCompId", PoInfo.InsuranceComp_ID);
             cmd.Parameters.AddWithValue("@wareHouseId", PoInfo.wareHouseId);
           //  cmd.Parameters.AddWithValue("@IssueTo", PoInfo.IssueTo);


             cmd.ExecuteNonQuery();
             con.Close();
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


     public void UpdatePatientIssueVoucherDetails(BELPatientIssueVoucher PoInfo)
     {

         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_UpdatePatientIssueVoucherDetails", con);
         cmd.CommandType = CommandType.StoredProcedure;
         // string Expdate = "1/1/2000";
         try
         {
             cmd.Parameters.AddWithValue("@UpdatedBy", PoInfo.UpdatedBy);
             cmd.Parameters.AddWithValue("@ItemId", PoInfo.ItemId);
              cmd.Parameters.AddWithValue("@IssueDate", DateTime.ParseExact(PoInfo.Issuedate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
             if (PoInfo.InvoiceExpdate != null)
             {
                 cmd.Parameters.AddWithValue("@ExpDate", DateTime.ParseExact(PoInfo.InvoiceExpdate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
             }


             cmd.Parameters.AddWithValue("@BatchNo", PoInfo.BatchNo);
             cmd.Parameters.AddWithValue("@IssueVoucherNO", PoInfo.IssueVoucherNo);
             cmd.Parameters.AddWithValue("@CurrentStock", PoInfo.CurrentStock);
             cmd.Parameters.AddWithValue("@Rate", PoInfo.Rate);
             cmd.Parameters.AddWithValue("@Tax", PoInfo.Tax);
             //cmd.Parameters.AddWithValue("@TotalAmount", PoInfo.TotalAmt);
             cmd.Parameters.AddWithValue("@IssueQty", PoInfo.IssueQty);
             cmd.Parameters.AddWithValue("@FId", PoInfo.Fid);
             cmd.Parameters.AddWithValue("@BranchId", PoInfo.BranchId);
             cmd.Parameters.AddWithValue("@DeptId", PoInfo.DeptId);
             cmd.Parameters.AddWithValue("@PatIssueVoucherId", PoInfo.PatIssueVoucherId);
             cmd.Parameters.AddWithValue("@PatIssueVoucherDetailId", PoInfo.PatIssueVoucherDetailId);
             cmd.Parameters.AddWithValue("@DoseId", PoInfo.DoseId);
             cmd.Parameters.AddWithValue("@Days", PoInfo.Days);
             cmd.Parameters.AddWithValue("@DoseTimeId", PoInfo.DoseTimeId);
             cmd.Parameters.AddWithValue("@Remark", PoInfo.Remark);
             cmd.Parameters.AddWithValue("@InstName", PoInfo.InstName);
             cmd.Parameters.AddWithValue("@NewDose", PoInfo.NewDose);


             cmd.ExecuteNonQuery();
             con.Close();
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

     public void UpdatePrescriptionPatientIssueVoucherDetails(BELPatientIssueVoucher PoInfo)
     {

         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_UpdatePatientIssueVoucherDetails_prescription", con);
         cmd.CommandType = CommandType.StoredProcedure;
         // string Expdate = "1/1/2000";
         try
         {
             cmd.Parameters.AddWithValue("@UpdatedBy", PoInfo.UpdatedBy);
             cmd.Parameters.AddWithValue("@ItemId", PoInfo.ItemId);
             cmd.Parameters.AddWithValue("@IssueDate", DateTime.ParseExact(PoInfo.Issuedate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
             if (PoInfo.InvoiceExpdate != null)
             {
                 cmd.Parameters.AddWithValue("@ExpDate", DateTime.ParseExact(PoInfo.InvoiceExpdate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
             }


             cmd.Parameters.AddWithValue("@BatchNo", PoInfo.BatchNo);
             cmd.Parameters.AddWithValue("@IssueVoucherNO", PoInfo.IssueVoucherNo);
             cmd.Parameters.AddWithValue("@CurrentStock", PoInfo.CurrentStock);
             cmd.Parameters.AddWithValue("@Rate", PoInfo.Rate);
             cmd.Parameters.AddWithValue("@Tax", PoInfo.Tax);
             //cmd.Parameters.AddWithValue("@TotalAmount", PoInfo.TotalAmt);
             cmd.Parameters.AddWithValue("@IssueQty", PoInfo.IssueQty);
             cmd.Parameters.AddWithValue("@FId", PoInfo.Fid);
             cmd.Parameters.AddWithValue("@BranchId", PoInfo.BranchId);
             cmd.Parameters.AddWithValue("@DeptId", PoInfo.DeptId);
             cmd.Parameters.AddWithValue("@PatIssueVoucherId", PoInfo.PatIssueVoucherId);
             cmd.Parameters.AddWithValue("@PatIssueVoucherDetailId", PoInfo.PatIssueVoucherDetailId);
             cmd.Parameters.AddWithValue("@DoseId", PoInfo.DoseId);
             cmd.Parameters.AddWithValue("@Days", PoInfo.Days);
             cmd.Parameters.AddWithValue("@DoseTimeId", PoInfo.DoseTimeId);
             cmd.Parameters.AddWithValue("@Remark", PoInfo.Remark);


             cmd.ExecuteNonQuery();
             con.Close();
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

     public void ApprovePrescriptionVoucher(int PatIssueVoucherId, int IssueVoucherNo, int Fid, int BranchId, string CreatedBy)
     {

         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_ApprovePrescriptionVoucher", con);
         cmd.CommandType = CommandType.StoredProcedure;
         // string Expdate = "1/1/2000";
         try
         {
             cmd.Parameters.AddWithValue("@PatIssueVoucherId", PatIssueVoucherId);
             cmd.Parameters.AddWithValue("@IssueVoucherNo", IssueVoucherNo);
             cmd.Parameters.AddWithValue("@FId", Fid);
             cmd.Parameters.AddWithValue("@BranchId", BranchId);
             cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
             cmd.ExecuteNonQuery();
             con.Close();
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

     public void FullCancelIssueVoucher(int PatIssueVoucherId, int IssueVoucherNo, int Fid, int BranchId, string CreatedBy, int WareHouseId)
     {

         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_FullPatientCancelVoucher", con);
         cmd.CommandType = CommandType.StoredProcedure;
         // string Expdate = "1/1/2000";
         try
         {
             cmd.Parameters.AddWithValue("@PatIssueVoucherId", PatIssueVoucherId);
             cmd.Parameters.AddWithValue("@IssueVoucherNo", IssueVoucherNo);
             cmd.Parameters.AddWithValue("@FId", Fid);
             cmd.Parameters.AddWithValue("@BranchId", BranchId);
             cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
             cmd.Parameters.AddWithValue("@WareHouseId", WareHouseId);
             cmd.ExecuteNonQuery();
             con.Close();
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

     public void FullCancelIssueVoucherDetails(int PatIssueVoucherId, int IssueVoucherNo, int Fid, int BranchId, string CreatedBy)
     {

         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_FullPatientCancelIssueVoucher_RefundDetails", con);
         cmd.CommandType = CommandType.StoredProcedure;
         // string Expdate = "1/1/2000";
         try
         {
             cmd.Parameters.AddWithValue("@PatIssueVoucherId", PatIssueVoucherId);
             cmd.Parameters.AddWithValue("@IssueVoucherNo", IssueVoucherNo);
             cmd.Parameters.AddWithValue("@FId", Fid);
             cmd.Parameters.AddWithValue("@BranchId", BranchId);
             cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
             cmd.ExecuteNonQuery();
             con.Close();
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

     public void Patient_ParcialyRefund(int PatIssueVoucherId, int IssueVoucherNo, int Fid, int BranchId, string CreatedBy,float RefAmt,int WareHouseId)
     {

         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_ParctialyPatientCancelVoucherRefund", con);
         cmd.CommandType = CommandType.StoredProcedure;
         // string Expdate = "1/1/2000";
         try
         {
             cmd.Parameters.AddWithValue("@PatIssueVoucherId", PatIssueVoucherId);
             cmd.Parameters.AddWithValue("@IssueVoucherNo", IssueVoucherNo);
             cmd.Parameters.AddWithValue("@FId", Fid);
             cmd.Parameters.AddWithValue("@BranchId", BranchId);

             cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
             cmd.Parameters.AddWithValue("@RefundAmt", RefAmt);
             cmd.Parameters.AddWithValue("@WareHouseId", WareHouseId);

             cmd.ExecuteNonQuery();
             con.Close();
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

     public void ParctialyPatientCancelVoucherRefund_Details(int PatIssueVoucherId, int IssueVoucherNo, int Fid, int BranchId, string CreatedBy, float RefundQty, int PatIssueVoucherDetailId, int ItemId, int WareHouseId)
     {

         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_ParctialyPatientCancelVoucherRefund_Details", con);
         cmd.CommandType = CommandType.StoredProcedure;
         // string Expdate = "1/1/2000";
         try
         {
             cmd.Parameters.AddWithValue("@PatIssueVoucherId", PatIssueVoucherId);
             cmd.Parameters.AddWithValue("@IssueVoucherNo", IssueVoucherNo);
             cmd.Parameters.AddWithValue("@FId", Fid);
             cmd.Parameters.AddWithValue("@BranchId", BranchId);

             cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
             cmd.Parameters.AddWithValue("@RefundQty", RefundQty);
             cmd.Parameters.AddWithValue("@PatIssueVoucherDetailId ", PatIssueVoucherDetailId);
             cmd.Parameters.AddWithValue("@ItemId", ItemId);
             cmd.Parameters.AddWithValue("@WareHouseId", WareHouseId);

             cmd.ExecuteNonQuery();
             con.Close();
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
     public List<string> AutoFillMaincatogaryId(string prefixtext)
     {
         // BEL ItemInfo = new BEL();

         SqlConnection con = new SqlConnection(constr);
         con.Open();
         //con.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;//ToString();

         try
         {
             SqlCommand cmd = new SqlCommand("Sp_GetMaincategoryid", con);

             cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.AddWithValue("@Search", prefixtext);
             //cmd.Parameters.AddWithValue("@Flag", "PurchaseItemList");

             List<string> items = new List<string>();
             SqlDataReader sdr = cmd.ExecuteReader();

             while (sdr.Read())
             {
                 items.Add(sdr["MaincategoryName"].ToString());
             }



             return items;
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

     public void UpdatePassword( string newPwd,string oldpwd,int UserId,int BranchId)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_ChangePassword", con);
         cmd.CommandType = CommandType.StoredProcedure;
         // string Expdate = "1/1/2000";
         try
         {
             cmd.Parameters.AddWithValue("@newPwd", newPwd);
             cmd.Parameters.AddWithValue("@oldpwd", oldpwd);
             cmd.Parameters.AddWithValue("@UserId", UserId);
           
             cmd.Parameters.AddWithValue("@BranchId", BranchId);            

              cmd.ExecuteNonQuery();
             con.Close();
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
     public DataSet BatchWiseDeptCurrentStock(BEL Itemstock)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_BatchWiseDeptStockSearch", con);
         cmd.CommandType = CommandType.StoredProcedure;
         try
         {
             cmd.Parameters.AddWithValue("@ItemId", Itemstock.ItemId);
             cmd.Parameters.AddWithValue("@DeptId", Itemstock.DeptId);
             cmd.Parameters.AddWithValue("@CategoryId", Itemstock.CategoryId);
             cmd.Parameters.AddWithValue("@MainCategory", Itemstock.MainCategory);
             cmd.Parameters.AddWithValue("@BranchId", Itemstock.BranchId);
             cmd.Parameters.AddWithValue("@Flag", Itemstock.ItemType);
             cmd.Parameters.AddWithValue("@FId", Itemstock.Fid);

             SqlDataAdapter sda = new SqlDataAdapter(cmd);
             DataSet ds = new DataSet();
             sda.Fill(ds);
             return ds;

         }
         catch (Exception ex)
         {
             throw ex;
         }
         finally
         {
             con.Dispose();
             con.Close();
         }


     }
     public DataSet DeptStockAdjustment(BEL Itemstock)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_DeptStockAdjustmentSearch", con);
         cmd.CommandType = CommandType.StoredProcedure;
         try
         {
             cmd.Parameters.AddWithValue("@ItemId", Itemstock.ItemId);
             cmd.Parameters.AddWithValue("@DeptId", Itemstock.DeptId);           
             cmd.Parameters.AddWithValue("@BatchNo", Itemstock.BatchNo);
             cmd.Parameters.AddWithValue("@BranchId", Itemstock.BranchId);            
             cmd.Parameters.AddWithValue("@FId", Itemstock.Fid);
             cmd.Parameters.AddWithValue("@WareHouseId", Itemstock.WareHouseId);

             SqlDataAdapter sda = new SqlDataAdapter(cmd);
             DataSet ds = new DataSet();
             sda.Fill(ds);
             return ds;

         }
         catch (Exception ex)
         {
             throw ex;
         }
         finally
         {
             con.Dispose();
             con.Close();
         }


     }

     public DataSet DeptWiseReorderSearch(BEL Itemstock)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_DeptWiseReorderSearch", con);
         cmd.CommandType = CommandType.StoredProcedure;
         try
         {
             cmd.Parameters.AddWithValue("@ItemId", Itemstock.ItemId);
             cmd.Parameters.AddWithValue("@DeptId", Itemstock.DeptId);
             cmd.Parameters.AddWithValue("@BatchNo", Itemstock.BatchNo);
             cmd.Parameters.AddWithValue("@BranchId", Itemstock.BranchId);
             cmd.Parameters.AddWithValue("@FId", Itemstock.Fid);

             SqlDataAdapter sda = new SqlDataAdapter(cmd);
             DataSet ds = new DataSet();
             sda.Fill(ds);
             return ds;

         }
         catch (Exception ex)
         {
             throw ex;
         }
         finally
         {
             con.Dispose();
             con.Close();
         }


     }
     public DataSet SearchItemWiseDeptCurrentStock(BEL Itemstock)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_Vw_ItemWiseDeptCurrentStock", con);
         cmd.CommandType = CommandType.StoredProcedure;
         try
         {
             cmd.Parameters.AddWithValue("@ItemId", Itemstock.ItemId);
             cmd.Parameters.AddWithValue("@DeptId", Itemstock.DeptId);
             cmd.Parameters.AddWithValue("@CategoryId", Itemstock.CategoryId);
             cmd.Parameters.AddWithValue("@MainCategory", Itemstock.MainCategory);
             cmd.Parameters.AddWithValue("@BranchId", Itemstock.BranchId);
             cmd.Parameters.AddWithValue("@FId", Itemstock.Fid);

             SqlDataAdapter sda = new SqlDataAdapter(cmd);
             DataSet ds = new DataSet();
             sda.Fill(ds);
             return ds;

         }
         catch (Exception ex)
         {
             throw ex;
         }
         finally
         {
             con.Dispose();
             con.Close();
         }


     }
     public DataTable GetDeptItemStockNew(BEL ItemStock)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_BatchWiseDeptStockNew", con);
         cmd.CommandType = CommandType.StoredProcedure;
         cmd.Parameters.AddWithValue("@ItemId", ItemStock.ItemId);
         cmd.Parameters.AddWithValue("@DeptId", ItemStock.DeptId);
         cmd.Parameters.AddWithValue("@CategoryId", ItemStock.CategoryId);
         cmd.Parameters.AddWithValue("@MainCategory", ItemStock.MainCategory);
         cmd.Parameters.AddWithValue("@BranchId", ItemStock.BranchId);
         cmd.Parameters.AddWithValue("@Flag", ItemStock.ItemType);
         cmd.Parameters.AddWithValue("@FId", ItemStock.Fid);

         SqlDataAdapter sda = new SqlDataAdapter(cmd);
         DataTable ds = new DataTable();
         cmd.CommandTimeout = 5000;
         sda.Fill(ds);
         //ds.Tables[0].TableName = "ItemWiseDeptStock";

         con.Close();
         return ds;

     }

     public DataTable SearchItemWiseDeptCurrentStockNew(BEL Itemstock)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_Vw_ItemWiseDeptCurrentStock", con);
         cmd.CommandType = CommandType.StoredProcedure;
         try
         {
             cmd.Parameters.AddWithValue("@ItemId", Itemstock.ItemId);
             cmd.Parameters.AddWithValue("@DeptId", Itemstock.DeptId);
             cmd.Parameters.AddWithValue("@CategoryId", Itemstock.CategoryId);
             cmd.Parameters.AddWithValue("@MainCategory", Itemstock.MainCategory);
             cmd.Parameters.AddWithValue("@BranchId", Itemstock.BranchId);
             cmd.Parameters.AddWithValue("@FId", Itemstock.Fid);

             SqlDataAdapter sda = new SqlDataAdapter(cmd);
             DataTable ds = new DataTable();
             sda.Fill(ds);
             return ds;

         }
         catch (Exception ex)
         {
             throw ex;
         }
         finally
         {
             con.Dispose();
             con.Close();
         }


     }
     public int GetMaxSupplierId(int FId, int BranchId)
     {  
       SqlConnection con = DataAccess.ConInitForPharmacy();
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_GetMaxSupplierId", con);
         cmd.CommandType = CommandType.StoredProcedure;
         cmd.Parameters.AddWithValue("@FId", FId);
         cmd.Parameters.AddWithValue("@BranchId", BranchId);
         try
         {

             object count = Convert.ToInt32(cmd.ExecuteScalar());
             return Convert.ToInt32(count);
         }
         catch (Exception ex)
         {
             throw ex;
         }
         finally
         {
             con.Dispose();
             con.Close();
         }

     }
     public BEL GetItemInfoForGRN(BEL objBELInvoiceInfo)
    {
        SqlConnection con = DataAccess.ConInitForPharmacy();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetItemInfoForGRN", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@FId", objBELInvoiceInfo.Fid);
        cmd.Parameters.AddWithValue("@BranchId", objBELInvoiceInfo.BranchId);
        cmd.Parameters.AddWithValue("@ItemId", objBELInvoiceInfo.ItemId);
        cmd.Parameters.AddWithValue("@BatchNo", objBELInvoiceInfo.BatchNo);     

           
        SqlDataReader sdr = cmd.ExecuteReader();
        try
        {
            while (sdr.Read())
            {
               //objBELInvoiceInfo.BatchNo=Convert.ToDecimal(sdr["FreightCharges"]);
               objBELInvoiceInfo.InvoiceNo = Convert.ToInt32(sdr["InvoiceNo"]);
               objBELInvoiceInfo.SuppName = sdr["SupplierName"].ToString();
               //objBELInvoiceInfo.Invoicedate = Convert.ToString(sdr["InvoiceDate"]);
               objBELInvoiceInfo.SuppId = Convert.ToInt32(sdr["SupplierId"]);
               //objBELInvoiceInfo.ChallanNo = Convert.ToString(sdr["ChallanNo"]);
               objBELInvoiceInfo.InvoiceExpdate = Convert.ToString(sdr["ExpDate"]);
            }
        }
         catch (Exception ex)
         {
             throw ex;
         }
         finally
         {
             con.Dispose();
             con.Close();
         }


        return objBELInvoiceInfo;
    }

     public DataSet FillUserWiseCashSummary(string FromDate, string ToDate,int DeptId,string UserName,string PaymentType, int FId, int BranchId,string PatientType,int WareHouseId)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_Vw_DailyCashSumary", con);
         cmd.CommandType = CommandType.StoredProcedure;
         try
         {
             if (FromDate == "")
             {
                 cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
             }
             else
             {
                 cmd.Parameters.AddWithValue("@FromDate", Convert.ToDateTime(FromDate));
                 //cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
             }
             if (ToDate == "")
             {
                 cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

             }
             else
             {
                  cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
               //  cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
             }
             cmd.Parameters.AddWithValue("@DeptId", DeptId);
             cmd.Parameters.AddWithValue("@UserName", UserName);
             cmd.Parameters.AddWithValue("@PaymentType", PaymentType);
             cmd.Parameters.AddWithValue("@PatientType", PatientType);
             cmd.Parameters.AddWithValue("@FId", FId);
             cmd.Parameters.AddWithValue("@BranchId", BranchId);
             cmd.Parameters.AddWithValue("@WareHouseId", WareHouseId);
             SqlDataAdapter sda = new SqlDataAdapter(cmd);
             DataSet ds = new DataSet();
             sda.Fill(ds);
             return ds;

         }
         catch (Exception ex)
         {
             throw ex;
         }
         finally
         {
             con.Dispose();
             con.Close();
         }
     }

     public DataSet SearchCancelIssueVoucherDetails(string FromDate, string ToDate, int DeptId, int FId, int BranchId,int WareHouseId)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_CancelVoucherDetails", con);
         cmd.CommandType = CommandType.StoredProcedure;
         try
         {
             if (FromDate == "")
             {
                 cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
             }
             else
             {

                 cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
             }
             if (ToDate == "")
             {
                 cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

             }
             else
             {
                 // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                 cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
             }
             cmd.Parameters.AddWithValue("@DeptId", DeptId);             
             cmd.Parameters.AddWithValue("@FId", FId);
             cmd.Parameters.AddWithValue("@BranchId", BranchId);
             cmd.Parameters.AddWithValue("@WareHouseId", WareHouseId);
             SqlDataAdapter sda = new SqlDataAdapter(cmd);
             DataSet ds = new DataSet();
             sda.Fill(ds);
             return ds;

         }
         catch (Exception ex)
         {
             throw ex;
         }
         finally
         {
             con.Dispose();
             con.Close();
         }
     }
     public float GetDoseQuantity(int DoseId)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_GetDoseQuantity", con);
         cmd.CommandType = CommandType.StoredProcedure;
         try
         {
             cmd.Parameters.AddWithValue("@DoseId", DoseId);
             object Qty;
             Qty = cmd.ExecuteScalar();
             return Convert.ToSingle(Qty);

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

     public float GetDoseTimes(int DoseTimeId)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_GetDoseTimes", con);
         cmd.CommandType = CommandType.StoredProcedure;
         try
         {
             cmd.Parameters.AddWithValue("@DoseTimeId", DoseTimeId);
             object Times;
             Times = cmd.ExecuteScalar();
             return Convert.ToSingle(Times);

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

     public void PartialCanceVoucherDetailsRpt(string FromDate, string ToDate, int Deptid, int VoucherNo, int BranchId)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_PartialCancelVoucherDetailsRpt", con);
         cmd.CommandType = CommandType.StoredProcedure;
         try
         {
             if (FromDate == "")
             {
                 cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
             }
             else
             {
                 // cmd.Parameters.AddWithValue("@FromDate",Convert.ToDateTime(FromDate));
                 cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
             }
             if (ToDate == "")
             {
                 cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

             }
             else
             {
                 // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                 cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
             }
            // cmd.Parameters.AddWithValue("@PatRegNo", PatRegNo);
             cmd.Parameters.AddWithValue("@DeptId", Deptid);
             cmd.Parameters.AddWithValue("@IssueVoucherNo", VoucherNo);
             cmd.Parameters.AddWithValue("@BranchId", BranchId);
             //cmd.Parameters.AddWithValue("@FId", FId);
             cmd.ExecuteNonQuery();

         }
         catch (Exception ex)
         {
             throw ex;
         }
         finally
         {
             con.Dispose();
             con.Close();
         }
     }



     public DataSet SearchTreatmentPatientList(string FromDate, string ToDate, int Patregid, int OpdNo ,int ipdno,int DrId,string MobNo,int Status)
     {
         SqlConnection con = new SqlConnection(constrHMS);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_GetPatientTreatment", con);
         cmd.CommandType = CommandType.StoredProcedure;
         try
         {
             if (FromDate == "")
             {
                 cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
             }
             else
             {
                 // cmd.Parameters.AddWithValue("@FromDate",Convert.ToDateTime(FromDate));
                 cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
             }
             if (ToDate == "")
             {
                 cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

             }
             else
             {
                 // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                 cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
             }

             cmd.Parameters.AddWithValue("@Patregid", Patregid);
             cmd.Parameters.AddWithValue("@Opdno", OpdNo);
             cmd.Parameters.AddWithValue("@Ipdno", ipdno);

             cmd.Parameters.AddWithValue("@DrId", DrId );
             cmd.Parameters.AddWithValue("@MobNo", MobNo);
             cmd.Parameters.AddWithValue("@Status", Status);

             SqlDataAdapter sda = new SqlDataAdapter(cmd);
             DataSet ds = new DataSet();
             sda.Fill(ds);
             return ds;

         }
         catch (Exception ex)
         {
             throw ex;
         }
         finally
         {
             con.Dispose();
             con.Close();
         }
     }

     public DataSet SearchIpdDrugReqPatientList(string FromDate, string ToDate, int Patregid,int ipdno, int DrId, string MobNo, int Status)
     {
         SqlConnection con = new SqlConnection(constrHMS);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_GetPatientTreatment_Ipd", con);
         cmd.CommandType = CommandType.StoredProcedure;
         try
         {
             if (FromDate == "")
             {
                 cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
             }
             else
             {
                 // cmd.Parameters.AddWithValue("@FromDate",Convert.ToDateTime(FromDate));
                 cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
             }
             if (ToDate == "")
             {
                 cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

             }
             else
             {
                 // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                 cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
             }

             cmd.Parameters.AddWithValue("@Patregid", Patregid);
            // cmd.Parameters.AddWithValue("@Opdno", OpdNo);
             cmd.Parameters.AddWithValue("@Ipdno", ipdno);

             cmd.Parameters.AddWithValue("@DrId", DrId);
             cmd.Parameters.AddWithValue("@MobNo", MobNo);
             cmd.Parameters.AddWithValue("@Status", Status);

             SqlDataAdapter sda = new SqlDataAdapter(cmd);
             DataSet ds = new DataSet();
             sda.Fill(ds);
             return ds;

         }
         catch (Exception ex)
         {
             throw ex;
         }
         finally
         {
             con.Dispose();
             con.Close();
         }
     }



     public DataSet SearchEmergencyPatientList(string FromDate, string ToDate, int Patregid, int OpdNo, int ipdno, int DrId, string MobNo, int Status,string type)
     {
         SqlConnection con = new SqlConnection(constrHMS);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_GetEmergencyPatientList", con);
         cmd.CommandType = CommandType.StoredProcedure;
         try
         {
             if (FromDate == "")
             {
                 cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
             }
             else
             {
                 // cmd.Parameters.AddWithValue("@FromDate",Convert.ToDateTime(FromDate));
                 cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
             }
             if (ToDate == "")
             {
                 cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

             }
             else
             {
                 // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                 cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
             }

             cmd.Parameters.AddWithValue("@Patregid", Patregid);
             cmd.Parameters.AddWithValue("@Opdno", OpdNo);
             cmd.Parameters.AddWithValue("@Ipdno", ipdno);

             cmd.Parameters.AddWithValue("@DrId", DrId);
             cmd.Parameters.AddWithValue("@MobNo", MobNo);
             cmd.Parameters.AddWithValue("@Status", Status);
             cmd.Parameters.AddWithValue("@Type",type);

             SqlDataAdapter sda = new SqlDataAdapter(cmd);
             DataSet ds = new DataSet();
             sda.Fill(ds);
             return ds;

         }
         catch (Exception ex)
         {
             throw ex;
         }
         finally
         {
             con.Dispose();
             con.Close();
         }
     }

     public DataSet SearchIPDPatientDrugList(string FromDate, string ToDate, int Patregid, int OpdNo, int ipdno, int DrId, string MobNo, int Status, string type)
     {
         SqlConnection con = new SqlConnection(constrHMS);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_GetIPDPatientDrugList", con);
         cmd.CommandType = CommandType.StoredProcedure;
         try
         {
             if (FromDate == "")
             {
                 cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
             }
             else
             {
                 // cmd.Parameters.AddWithValue("@FromDate",Convert.ToDateTime(FromDate));
                 cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
             }
             if (ToDate == "")
             {
                 cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

             }
             else
             {
                 // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                 cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
             }

             cmd.Parameters.AddWithValue("@Patregid", Patregid);
             cmd.Parameters.AddWithValue("@Opdno", OpdNo);
             cmd.Parameters.AddWithValue("@Ipdno", ipdno);

             cmd.Parameters.AddWithValue("@DrId", DrId);
             cmd.Parameters.AddWithValue("@MobNo", MobNo);
             cmd.Parameters.AddWithValue("@Status", Status);
             cmd.Parameters.AddWithValue("@Type", type);

             SqlDataAdapter sda = new SqlDataAdapter(cmd);
             DataSet ds = new DataSet();
             cmd.CommandTimeout = 5000;
             sda.Fill(ds);
             return ds;

         }
         catch (Exception ex)
         {
             throw ex;
         }
         finally
         {
             con.Dispose();
             con.Close();
         }
     }

     public DataSet SearchIPDPatientDischargeDrugList(string FromDate, string ToDate, int Patregid, int OpdNo, int ipdno, int DrId, string MobNo, int Status, string type)
     {
         SqlConnection con = new SqlConnection(constrHMS);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_GetIPDPatientDischargeDrugList", con);
         cmd.CommandType = CommandType.StoredProcedure;
         try
         {
             if (FromDate == "")
             {
                 cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
             }
             else
             {
                 // cmd.Parameters.AddWithValue("@FromDate",Convert.ToDateTime(FromDate));
                 cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
             }
             if (ToDate == "")
             {
                 cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

             }
             else
             {
                 // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                 cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
             }

             cmd.Parameters.AddWithValue("@Patregid", Patregid);
             cmd.Parameters.AddWithValue("@Opdno", OpdNo);
             cmd.Parameters.AddWithValue("@Ipdno", ipdno);

             cmd.Parameters.AddWithValue("@DrId", DrId);
             cmd.Parameters.AddWithValue("@MobNo", MobNo);
             cmd.Parameters.AddWithValue("@Status", Status);
             cmd.Parameters.AddWithValue("@Type", type);

             SqlDataAdapter sda = new SqlDataAdapter(cmd);
             DataSet ds = new DataSet();
             cmd.CommandTimeout = 5000;
             sda.Fill(ds);
             return ds;

         }
         catch (Exception ex)
         {
             throw ex;
         }
         finally
         {
             con.Dispose();
             con.Close();
         }
     }


     public List<string> AutoFillDrNameName(string prefixtext)
     {
         // BEL ItemInfo = new BEL();

         SqlConnection con = new SqlConnection(constrHMS);
         con.Open();
         //con.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;//ToString();

         try
         {
             SqlCommand cmd = new SqlCommand("Sp_Get_DrList", con);

             cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.AddWithValue("@Search", prefixtext);


             List<string> items = new List<string>();
             SqlDataReader sdr = cmd.ExecuteReader();

             while (sdr.Read())
             {
                 items.Add(sdr["DrName"].ToString());
             }



             return items;
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

     public List<string> AutoFillPatientName(string prefixtext)
     {
         // BEL ItemInfo = new BEL();

         SqlConnection con = new SqlConnection(constrHMS);
         con.Open();
         //con.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;//ToString();

         try
         {
             SqlCommand cmd = new SqlCommand("Sp_GetTreatmentPatientList", con);

             cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.AddWithValue("@Search", prefixtext);


             List<string> items = new List<string>();
             SqlDataReader sdr = cmd.ExecuteReader();

             while (sdr.Read())
             {
                 items.Add(sdr["PatientName"].ToString());
             }



             return items;
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

     public DataTable Get_AllPatientInformation(string patregId, string opd, int ipd, int branchid)
     {
         DataTable dt = new DataTable();
         try
         {
             //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;

             using (SqlConnection connection =
                       DataAccess.ConInitForPharmacy())
             {
                 using (SqlCommand cmd = new SqlCommand("SP_GetAllPatientInfo", connection))
                 {
                     cmd.CommandType = CommandType.StoredProcedure;
                     cmd.Parameters.Add("@Patientregid", SqlDbType.VarChar).Value = patregId;
                     cmd.Parameters.Add("@OpdNo", SqlDbType.VarChar).Value = opd;
                     cmd.Parameters.Add("@IpdNo", SqlDbType.VarChar).Value = ipd;
                     cmd.Parameters.Add("@BranchId", SqlDbType.VarChar).Value = branchid;

                     connection.Open();

                     using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                     {
                         sda.Fill(dt);
                     }
                     return dt;
                 }
             }
         }
         catch (Exception)
         {

             return null;
         }

     }
     public DataTable OpdPatientTreatmentIssue(int TreatmentId,string patregId, string opd)
     {
         DataTable dt = new DataTable();
         try
         {
             //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;

             using (SqlConnection connection =
                       DataAccess.ConInitForPharmacy())
             {
                 using (SqlCommand cmd = new SqlCommand("SP_OpdPatientTreatmentIssue", connection))
                 {
                     cmd.CommandType = CommandType.StoredProcedure;
                     cmd.Parameters.Add("@PatientRegId", SqlDbType.VarChar).Value = patregId;
                     cmd.Parameters.Add("@OpdNo", SqlDbType.VarChar).Value = opd;
                     cmd.Parameters.Add("@TreatmentId", SqlDbType.Int).Value = TreatmentId;

                     connection.Open();

                     using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                     {
                         sda.Fill(dt);
                     }
                     return dt;
                 }
             }
         }
         catch (Exception)
         {

             return null;
         }

     }

     public DataTable IpdPatientTreatmentIssue(int TreatmentId, string patregId, string Ipd)
     {
         DataTable dt = new DataTable();
         try
         {
             //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;

             using (SqlConnection connection =
                       DataAccess.ConInitForPharmacy())
             {
                 using (SqlCommand cmd = new SqlCommand("SP_IpdPatientTreatmentIssue", connection))
                 {
                     cmd.CommandType = CommandType.StoredProcedure;
                     cmd.Parameters.Add("@PatientRegId", SqlDbType.VarChar).Value = patregId;
                     cmd.Parameters.Add("@IpdNo", SqlDbType.VarChar).Value = Ipd;
                     cmd.Parameters.Add("@TreatmentId", SqlDbType.Int).Value = TreatmentId;

                     connection.Open();

                     using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                     {
                         sda.Fill(dt);
                     }
                     return dt;
                 }
             }
         }
         catch (Exception)
         {

             return null;
         }

     }
     public int CheckBatchExists(int FId, int BranchId, string BatchNo, float ItemId)
     {

         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_CheckBatchExistsInInvoice", con);
         cmd.CommandType = CommandType.StoredProcedure;

         try
         {


             cmd.Parameters.AddWithValue("@FId", FId);
             cmd.Parameters.AddWithValue("@BranchId", BranchId);
             cmd.Parameters.AddWithValue("@BatchNo", BatchNo);
             cmd.Parameters.AddWithValue("@ItemId", ItemId);

             int Flag = Convert.ToInt32(cmd.ExecuteScalar());

             return Flag;



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

     public BEL GetItemInfoOfExistingBatch(int ItemId, string BatchNo, int FId, int BranchId)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_ItemInfoOfExistingBatch", con);
         cmd.CommandType = CommandType.StoredProcedure;
         BEL Item = new BEL();
         try
         {
             cmd.Parameters.AddWithValue("@ItemId", ItemId);
             cmd.Parameters.AddWithValue("@FId", FId);
             cmd.Parameters.AddWithValue("@BranchId", BranchId);
             cmd.Parameters.AddWithValue("@BatchNo", BatchNo);
             //int Stock = 0;
             SqlDataReader sdr = cmd.ExecuteReader();
             while (sdr.Read())
             {

                 Item.InvoiceExpdate = Convert.ToString(sdr["ExpDate"]);

                 Item.Tax = Convert.ToDecimal(sdr["Tax"]);
               //  Item.SellingPrice = Convert.ToDecimal(sdr["MRP"]);

                 Item.PerPackCost = Convert.ToDecimal(sdr["PerPackCost"]);

                 //Item.UnitsPerPack = Convert.ToInt32(sdr["UnitsPerPack"]);
                 //Item.CostPerUnit = Convert.ToDecimal(sdr["CostPerUnit"]);

             }
             return Item;
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

     public void UpdatePaymentStatusInTreatment(int TreatmentId, string PaymentStatus)
     {

         SqlConnection con = new SqlConnection(constrHMS);
         con.Open();
         SqlCommand cmd = new SqlCommand("SP_UpdatePaymentStatusInTreatment", con);
         cmd.CommandType = CommandType.StoredProcedure;
         // string Expdate = "1/1/2000";
         try
         {
             cmd.Parameters.AddWithValue("@TreatmentId", TreatmentId);
             cmd.Parameters.AddWithValue("@PaymentStatus", PaymentStatus);
             cmd.ExecuteNonQuery();
             con.Close();
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

     public DataTable CheckEmergencyPatient()
     {
         DataTable dt = new DataTable();
         try
         {
             //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;

             using (SqlConnection connection =
                       DataAccess.ConInitForPharmacy())
             {
                 using (SqlCommand cmd = new SqlCommand("SP_CheckEmergencyPatient", connection))
                 {
                     cmd.CommandType = CommandType.StoredProcedure;
                     
                     connection.Open();

                     using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                     {
                         sda.Fill(dt);
                     }
                     return dt;
                 }
             }
         }
         catch (Exception)
         {

             return null;
         }

     }

     public float GetPerPackCostPO(int ItemId,int Fid,int BranchId)
     {
         SqlConnection con = DataAccess.ConInitForPharmacy();
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_GetPerPackCostPO", con);
         cmd.CommandType = CommandType.StoredProcedure;
         cmd.Parameters.AddWithValue("@FId", Fid);
         cmd.Parameters.AddWithValue("@BranchId",BranchId);
         cmd.Parameters.AddWithValue("@ItemId", ItemId);
         try
         {

             object Cost = Convert.ToDecimal(cmd.ExecuteScalar());
             return Convert.ToSingle(Cost);
         }
         catch (Exception ex)
         {
             throw ex;
         }
         finally
         {
             con.Dispose();
             con.Close();
         }

     }

     public int GetUsageOfLast3Months(int ItemId, int Fid, int BranchId)
     {
         SqlConnection con = DataAccess.ConInitForPharmacy();
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_GetUsageOfLast3Months", con);
         cmd.CommandType = CommandType.StoredProcedure;
         cmd.Parameters.AddWithValue("@FId", Fid);
         cmd.Parameters.AddWithValue("@BranchId", BranchId);
         cmd.Parameters.AddWithValue("@ItemId", ItemId);
         try
         {

             object Cost = Convert.ToInt32(cmd.ExecuteScalar());
             return Convert.ToInt32(Cost);
         }
         catch (Exception ex)
         {
             throw ex;
         }
         finally
         {
             con.Dispose();
             con.Close();
         }

     }

     public BEL FillEditPOInfo(int PONo, int SupplierId, int FId, int BranchId, int WareHouseId)
     {
         BEL objBELInvoiceInfo = new BEL();
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_FillEditPoInfo", con);
         cmd.CommandType = CommandType.StoredProcedure;
         cmd.Parameters.AddWithValue("@PONo", PONo);
         cmd.Parameters.AddWithValue("@SupplierId", SupplierId);
         cmd.Parameters.AddWithValue("@FId", FId);
         cmd.Parameters.AddWithValue("@BranchId", BranchId);
         cmd.Parameters.AddWithValue("@WareHouseId", WareHouseId);

         SqlDataReader sdr = cmd.ExecuteReader();
         try
         {
             while (sdr.Read())
             {

                 objBELInvoiceInfo.PONo = Convert.ToInt32(sdr["PONo"]);
                 objBELInvoiceInfo.SuppName = sdr["SupplierName"].ToString();
                 objBELInvoiceInfo.PODate = Convert.ToString(sdr["PODate"]);
                 objBELInvoiceInfo.SuppId = Convert.ToInt32(sdr["SupplierId"]);
                 //objBELInvoiceInfo.CompanyId = Convert.ToInt32(sdr["CompanyId"]);
                 //objBELInvoiceInfo.ChallanNo = Convert.ToString(sdr["ChallanNo"]);
             }
         }
         catch (Exception ex)
         {
             throw ex;
         }
         finally
         {
             con.Dispose();
             con.Close();
         }


         return objBELInvoiceInfo;
     }
     //public DataSet fillCompanyMaster()
     //{
     //    SqlConnection con = new SqlConnection(constr);
     //    con.Open();
     //    SqlCommand cmd = new SqlCommand("Sp_FillCompanyMaster", con);
     //    cmd.CommandType = CommandType.StoredProcedure;

     //    SqlDataAdapter da = new SqlDataAdapter(cmd);
     //    DataSet ds = new DataSet();
     //    da.Fill(ds);
     //    return ds;

     //}
     //public void DeletePO(int POId, int FId, int BranchId)
     //{
     //    SqlConnection con = new SqlConnection(constr);
     //    con.Open();
     //    SqlCommand cmd = new SqlCommand("Sp_PODelete", con);
     //    cmd.CommandType = CommandType.StoredProcedure;
     //    try
     //    {
     //        cmd.Parameters.AddWithValue("@POId", POId);
     //        cmd.Parameters.AddWithValue("@FId", FId);
     //        cmd.Parameters.AddWithValue("@BranchId", BranchId);
     //        cmd.ExecuteNonQuery();
     //        con.Close();
     //    }
     //    catch (Exception ex)
     //    {
     //        throw ex;
     //    }
     //    finally
     //    {
     //        con.Close();
     //        con.Dispose();
     //    }

     //}


     public DataTable FillEditPOItems(int PONo, int SupplierId, int FId, int BranchId, int WareHouseId)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_FillEditPOItems", con);
         cmd.CommandType = CommandType.StoredProcedure;

         try
         {
             cmd.Parameters.AddWithValue("@SupplierId", SupplierId);
             cmd.Parameters.AddWithValue("@PONo", PONo);
             // cmd.Parameters.AddWithValue("@InvoiceDetailId", InvoiceDetailId);
             cmd.Parameters.AddWithValue("@FId", FId);
             cmd.Parameters.AddWithValue("@BranchId", BranchId);
             cmd.Parameters.AddWithValue("@WareHouseId", WareHouseId);
             SqlDataAdapter sda = new SqlDataAdapter(cmd);
             DataTable dt = new DataTable();
             sda.Fill(dt);
             return dt;

         }
         catch (Exception ex)
         {
             throw ex;
         }
         finally
         {
             con.Dispose();
             con.Close();
         }
     }

     public void UpdatePOInfo(BEL PoInfo)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_UpdatePO", con);
         cmd.CommandType = CommandType.StoredProcedure;

         try
         {
            
             cmd.Parameters.AddWithValue("@PoNo", PoInfo.PONo);
             cmd.Parameters.AddWithValue("@SupplierId", PoInfo.SuppId);
             cmd.Parameters.AddWithValue("@ItemId", PoInfo.ItemId);
             cmd.Parameters.AddWithValue("@Units", PoInfo.units);
             cmd.Parameters.AddWithValue("@PerPackCost", PoInfo.PerPackCost);
             cmd.Parameters.AddWithValue("@Usage3Months", PoInfo.Usage3Months);
             cmd.Parameters.AddWithValue("@CurrentStock", PoInfo.CurrStock);            
             cmd.Parameters.AddWithValue("@NoOfPacks", PoInfo.NoOfPacks);
             cmd.Parameters.AddWithValue("@Tax", PoInfo.Tax);
             cmd.Parameters.AddWithValue("@TotalAmt", PoInfo.TotalAmt);
             cmd.Parameters.AddWithValue("@POId", PoInfo.PoId);
            
             cmd.Parameters.AddWithValue("@BranchId", PoInfo.BranchId);
             cmd.Parameters.AddWithValue("@FId", PoInfo.Fid);
             cmd.Parameters.AddWithValue("@CreatedBy", PoInfo.CreatedBy);
             cmd.Parameters.AddWithValue("@UpdatedBy", PoInfo.CreatedBy);
             cmd.Parameters.AddWithValue("@PrevCost", PoInfo.PrevCost);
             cmd.Parameters.AddWithValue("@PackQty", PoInfo.PackQty);
             cmd.Parameters.AddWithValue("@UnitsPerPack", PoInfo.UnitsPerPack);
             cmd.Parameters.AddWithValue("@Remark", PoInfo.Remark);
             cmd.Parameters.AddWithValue("@WareHouseId", PoInfo.WareHouseId);
            
             cmd.Parameters.AddWithValue("@PoDate", DateTime.ParseExact(PoInfo.PODate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));


             cmd.ExecuteNonQuery();
             con.Close();
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

     public void DeletePO(int POId, int FId, int BranchId)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_PODelete", con);
         cmd.CommandType = CommandType.StoredProcedure;
         try
         {
             cmd.Parameters.AddWithValue("@POId", POId);
             cmd.Parameters.AddWithValue("@FId", FId);
             cmd.Parameters.AddWithValue("@BranchId", BranchId);
             cmd.ExecuteNonQuery();
             con.Close();
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

     public void UpdateStatusInPO(int PoNo, int SupplierId,int UserId,int WareHouseId)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_UpdateApproveStatusInPO", con);
         cmd.CommandType = CommandType.StoredProcedure;

         try
         {
             cmd.Parameters.AddWithValue("@PoNo", PoNo);
             cmd.Parameters.AddWithValue("@SupplierId", SupplierId);
             cmd.Parameters.AddWithValue("@UserId", UserId);
             cmd.Parameters.AddWithValue("@WareHouseId", WareHouseId);
             cmd.ExecuteNonQuery();
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

     public void UpdateManagementStatusInPO(int PoNo, int SupplierId, int MPOApproveBy, int WareHouseId)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_UpdateApproveStatusInPO_ForMPO", con);
         cmd.CommandType = CommandType.StoredProcedure;

         try
         {
             cmd.Parameters.AddWithValue("@PoNo", PoNo);
             cmd.Parameters.AddWithValue("@SupplierId", SupplierId);
             cmd.Parameters.AddWithValue("@MPOApproveBy", MPOApproveBy);
             cmd.Parameters.AddWithValue("@WareHouseId", WareHouseId);
             cmd.ExecuteNonQuery();
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


     public DataTable  ReminderReorderCurrentStock(BEL Itemstock)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_Vw_ReorderLevel", con);
         cmd.CommandType = CommandType.StoredProcedure;
         try
         {
             cmd.Parameters.AddWithValue("@ItemId", Itemstock.ItemId);
             //  cmd.Parameters.AddWithValue("@BatchNo", Itemstock.BatchNo);
             cmd.Parameters.AddWithValue("@CategoryId", Itemstock.CategoryId);
             cmd.Parameters.AddWithValue("@MainCategory", Itemstock.MainCategory);
             cmd.Parameters.AddWithValue("@BranchId", Itemstock.BranchId);
             cmd.Parameters.AddWithValue("@FId", Itemstock.Fid);

             SqlDataAdapter sda = new SqlDataAdapter(cmd);
             DataTable  ds = new DataTable ();
             sda.Fill(ds);
             return ds;

         }
         catch (Exception ex)
         {
             throw ex;
         }
         finally
         {
             con.Dispose();
             con.Close();
         }
 }
   public BELPatientIssueVoucher FillManualConsumptionEdit(int ManConsumptionId)
   {
       SqlConnection con = new SqlConnection(constr);
       con.Open();
       SqlCommand cmd = new SqlCommand("Sp_ManualConsumptionSelect",con);
       cmd.CommandType = CommandType.StoredProcedure;
       

       BELPatientIssueVoucher IndReqInfo = new BELPatientIssueVoucher();    


       try
       {
           cmd.Parameters.AddWithValue("@ManConsumptionId", ManConsumptionId);         

           
           SqlDataReader sdr = cmd.ExecuteReader();
           while (sdr.Read())
           {
               IndReqInfo.ItemName = Convert.ToString(sdr["ItemName"]);
               IndReqInfo.ItemId = Convert.ToInt32(sdr["ItemId"]);
               IndReqInfo.DeptId = Convert.ToInt32(sdr["DeptId"]);
             //  IndReqInfo.DeptName = Convert.ToString(sdr["DeptName"]);
               IndReqInfo.IssueQty=Convert.ToInt32(sdr["Quantity"]);
               IndReqInfo.BatchNo = Convert.ToString(sdr["BatchNo"]);
               IndReqInfo.TotalAmt = Convert.ToDecimal(sdr["TotalAmount"]);
                IndReqInfo.Rate=  Convert.ToDecimal(sdr["Rate"]);
                IndReqInfo.Tax=Convert.ToDecimal(sdr["Tax"]);
                IndReqInfo.InvoiceExpdate=Convert.ToString(sdr["ExpDate"]);
                IndReqInfo.Remark=Convert.ToString(sdr["Remark"]);
                IndReqInfo.Issuedate = Convert.ToString(sdr["ConsumptionDate"]);              


           }
           return IndReqInfo;
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
   public string DeleteManualConsumption(int ManConsumptionId)
   {
       SqlConnection con = new SqlConnection(constr);
       con.Open();
       SqlCommand cmd = new SqlCommand("Sp_ManualConsumptionDelete", con);
       cmd.CommandType = CommandType.StoredProcedure;
       try
       {
           cmd.Parameters.AddWithValue("@ManConsumptionId", ManConsumptionId);
           object message;
           message = cmd.ExecuteScalar();
           return Convert.ToString(message);

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

   public string UpdateManualConsumption(BELPatientIssueVoucher ObjBELManConsume)
   {
       SqlConnection con = new SqlConnection(constr);
       con.Open();
       SqlCommand cmd = new SqlCommand("Sp_ManualConsumptionUpdate", con);
       cmd.CommandType = CommandType.StoredProcedure;
       try
       {
           cmd.Parameters.AddWithValue("@ManConsumptionId", ObjBELManConsume.ManConsumptionId);
           cmd.Parameters.AddWithValue("@ItemId", ObjBELManConsume.ItemId);
           cmd.Parameters.AddWithValue("@UnitId", ObjBELManConsume.UnitId);
           if (ObjBELManConsume.InvoiceExpdate != null)
           {
               if (ObjBELManConsume.InvoiceExpdate.Trim() != "")
               {
                   cmd.Parameters.AddWithValue("@ExpDate", DateTime.ParseExact(ObjBELManConsume.InvoiceExpdate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
                   //cmd.Parameters.AddWithValue("@ExpDate", ObjBELManConsume.InvoiceExpdate);
               }
           }
           cmd.Parameters.AddWithValue("@BatchNo", ObjBELManConsume.BatchNo);
           cmd.Parameters.AddWithValue("@DeptId", ObjBELManConsume.DeptId);
           cmd.Parameters.AddWithValue("@Remark", ObjBELManConsume.Remark);
           //  cmd.Parameters.AddWithValue("@ConsumptionDate", DateTime.ParseExact(ObjBELManConsume.Issuedate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
           cmd.Parameters.AddWithValue("@Quantity", ObjBELManConsume.IssueQty);
           cmd.Parameters.AddWithValue("@Rate", ObjBELManConsume.Rate);
           cmd.Parameters.AddWithValue("@Tax", ObjBELManConsume.Tax);
           cmd.Parameters.AddWithValue("@TotalAmount", ObjBELManConsume.GrandTotal);
           cmd.Parameters.AddWithValue("@UpdatedBy", ObjBELManConsume.UpdatedBy);
           cmd.Parameters.AddWithValue("@FId", ObjBELManConsume.Fid);
           cmd.Parameters.AddWithValue("@BranchId", ObjBELManConsume.BranchId);
           object message;
           message = cmd.ExecuteScalar();
           return Convert.ToString(message);

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

     public void Approve_ManualConsumption(BELPatientIssueVoucher PoInfo)
     {
         
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("UpdateDeptStock_Manualconsumption", con);
         cmd.CommandType = CommandType.StoredProcedure;
        
         try
         {
             cmd.Parameters.AddWithValue("@ManConsumptionId", PoInfo.ManConsumptionId);
             cmd.Parameters.AddWithValue("@CreatedBy", PoInfo.CreatedBy);
             cmd.Parameters.AddWithValue("@ItemId", PoInfo.ItemId);

             if (PoInfo.InvoiceExpdate != null )
             {
                 if (PoInfo.InvoiceExpdate.Trim() != "")
                 {
                     cmd.Parameters.AddWithValue("@ExpDate", DateTime.ParseExact(PoInfo.InvoiceExpdate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
                 }
             }
             


             cmd.Parameters.AddWithValue("@BatchNo", PoInfo.BatchNo);
             cmd.Parameters.AddWithValue("@IssueQty", PoInfo.IssueQty);
             cmd.Parameters.AddWithValue("@FId", PoInfo.Fid);
             cmd.Parameters.AddWithValue("@BranchId", PoInfo.BranchId);
             cmd.Parameters.AddWithValue("@DeptId", PoInfo.DeptId);
             cmd.Parameters.AddWithValue("@IssueTo", PoInfo.IssueTo);          
           


             cmd.ExecuteNonQuery();
             con.Close();
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

     public void Insert_Partial_AllIPD_TempDate(int PatIssueVoucherId, int DeptId, int IssueVoucherNo, int PatIssueVoucherDetailId, float TotalRefund, int Item_id, string PatRegNo, int IpdNo, int RefQty)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("SP_InsertPartial_allIPD_TempDate", con);
         cmd.CommandType = CommandType.StoredProcedure;

         try
         {
             cmd.Parameters.AddWithValue("@PatIssueVoucherId", PatIssueVoucherId);
             cmd.Parameters.AddWithValue("@IssueVoucherNo", IssueVoucherNo);
             cmd.Parameters.AddWithValue("@DeptId", DeptId);
             cmd.Parameters.AddWithValue("@PatIssueVoucherDetailId", PatIssueVoucherDetailId);
             cmd.Parameters.AddWithValue("@TotalRefund", TotalRefund);
             cmd.Parameters.AddWithValue("@Item_id", Item_id);

             cmd.Parameters.AddWithValue("@PatRegNo", PatRegNo);
             cmd.Parameters.AddWithValue("@IpdNo", IpdNo);
             cmd.Parameters.AddWithValue("@RefQty", RefQty);
            
             cmd.ExecuteNonQuery();
             con.Close();

         }
         catch (Exception ex)
         {
             throw ex;
         }
         finally
         {
             con.Dispose();
             con.Close();
         }
     }

     public void ParctialyPatientCancelVoucherRefund_Credit()
     {

         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_ParctialyPatientCancelVoucherRefund_Credit", con);
         cmd.CommandType = CommandType.StoredProcedure;
         // string Expdate = "1/1/2000";
         try
         {
         

             cmd.ExecuteNonQuery();
             con.Close();
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

     public void InsertPatientItemIN_HMS_CreditBack(BELPatientIssueVoucher PoInfo)
     {

         SqlConnection con = new SqlConnection(Dbhospital);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_InsertPatientIssueDrugDetails_CreditBack", con);
         cmd.CommandType = CommandType.StoredProcedure;
         // string Expdate = "1/1/2000";
         try
         {
             cmd.Parameters.AddWithValue("@CreatedBy", PoInfo.CreatedBy);
             cmd.Parameters.AddWithValue("@ItemId", PoInfo.ItemId);    
             cmd.Parameters.AddWithValue("@patregid", PoInfo.PatRegNo);
             cmd.Parameters.AddWithValue("@IpdNo", PoInfo.IpdNo);
             cmd.Parameters.AddWithValue("@Rate", PoInfo.Rate);

             cmd.Parameters.AddWithValue("@IssueQty", PoInfo.IssueQty);
             cmd.Parameters.AddWithValue("@TotalCharges", PoInfo.TotalAmt);
             cmd.Parameters.AddWithValue("@BillNo", PoInfo.BillNo);
             cmd.Parameters.AddWithValue("@FId", PoInfo.Fid);
             cmd.Parameters.AddWithValue("@BranchId", PoInfo.BranchId);
             cmd.Parameters.AddWithValue("@ItemName", PoInfo.ItemName);
             cmd.Parameters.AddWithValue("@Diagnosis", "");




             cmd.ExecuteNonQuery();
             con.Close();
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

     public void InsertIndentRequest_Warehouse_Add_Item(BEL ItemInfo)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_DeptIndentReqToWareHouse_Temp", con);
         cmd.CommandType = CommandType.StoredProcedure;
         try
         {
           
             cmd.Parameters.AddWithValue("@DeptId", ItemInfo.DeptId);
             cmd.Parameters.AddWithValue("@ItemId", ItemInfo.ItemId);
             cmd.Parameters.AddWithValue("@unit", ItemInfo.units);
             // cmd.Parameters.AddWithValue("@BatchNo", ItemInfo.BatchNo);
             cmd.Parameters.AddWithValue("@CurrentStock", ItemInfo.CurrStock);
             cmd.Parameters.AddWithValue("@ReqQty", ItemInfo.ReqQty);
             cmd.Parameters.AddWithValue("@Remark", ItemInfo.Remark);
             cmd.Parameters.AddWithValue("@RPIflag", ItemInfo.RPIflag);
             cmd.Parameters.AddWithValue("@ReqDate", ItemInfo.ReqDate);
             cmd.Parameters.AddWithValue("@CreatedBy", ItemInfo.CreatedBy);
           
             cmd.Parameters.AddWithValue("@BranchId", ItemInfo.BranchId);
             
             cmd.Parameters.AddWithValue("@IsApprove", "NA");
             cmd.Parameters.AddWithValue("@Flag", "InsertReqDetails_Warehouse");
             cmd.Parameters.AddWithValue("@IssueTo", ItemInfo.P_IssueTo);


             cmd.ExecuteNonQuery();
             con.Close();
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


     public void InsertIndentDept_Warehouse_Temp(BEL ItemInfo)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_IndentRequest_Warehouse_Temp", con);
         cmd.CommandType = CommandType.StoredProcedure;
         try
         {

             cmd.Parameters.AddWithValue("@ReqId", ItemInfo.ReqId);
             cmd.Parameters.AddWithValue("@VoucherNo", ItemInfo.VoucherNo);
             cmd.Parameters.AddWithValue("@DeptId", ItemInfo.DeptId);
             cmd.Parameters.AddWithValue("@Remark", ItemInfo.Remark);
             cmd.Parameters.AddWithValue("@RPIflag", ItemInfo.RPIflag);
             cmd.Parameters.AddWithValue("@ReqDate", ItemInfo.ReqDate);
             cmd.Parameters.AddWithValue("@BranchId", ItemInfo.BranchId);
             cmd.Parameters.AddWithValue("@FId", ItemInfo.Fid);
             cmd.Parameters.AddWithValue("@IssueTo", ItemInfo.P_IssueTo);
             cmd.Parameters.AddWithValue("@CreatedBy", ItemInfo.CreatedBy);
             cmd.Parameters.AddWithValue("@CategoryId", ItemInfo.CategoryId);
             cmd.Parameters.AddWithValue("@WareHouseId", ItemInfo.WareHouseId);
             cmd.Parameters.AddWithValue("@IssueToWareHouse", ItemInfo.Issue_ToWareHouseId);
             cmd.Parameters.AddWithValue("@IsApprove", "NA");
             cmd.Parameters.AddWithValue("@Flag", "InsertReqDept_Warehouse");

             cmd.ExecuteNonQuery();
             con.Close();
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

     public int InsertIndentDept_Warehouse_Temp1(BEL ItemInfo)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_IndentRequest_Warehouse_Temp", con);
         cmd.CommandType = CommandType.StoredProcedure;
         try
         {
             cmd.Parameters.AddWithValue("@ReqId", ItemInfo.ReqId);
             cmd.Parameters.AddWithValue("@VoucherNo", ItemInfo.VoucherNo);
             cmd.Parameters.AddWithValue("@DeptId", ItemInfo.DeptId);
             cmd.Parameters.AddWithValue("@Remark", ItemInfo.Remark);
             cmd.Parameters.AddWithValue("@RPIflag", ItemInfo.RPIflag);
             cmd.Parameters.AddWithValue("@ReqDate", ItemInfo.ReqDate);
             cmd.Parameters.AddWithValue("@BranchId", ItemInfo.BranchId);
             cmd.Parameters.AddWithValue("@FId", ItemInfo.Fid);
             cmd.Parameters.AddWithValue("@IssueTo", ItemInfo.P_IssueTo);
             cmd.Parameters.AddWithValue("@IsApprove", "NA");
             cmd.Parameters.AddWithValue("@Flag", "InsertReqDept_Warehouse");
             cmd.Parameters.Add("@IndreqDeptId", SqlDbType.Int).Direction = ParameterDirection.Output;

             cmd.ExecuteNonQuery();
             int IndreqDeptId = Convert.ToInt32(cmd.Parameters["@IndreqDeptId"].Value);//.ToString();
             return IndreqDeptId;



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


     public void InsertIndentRequest_Delete_UserWise(BEL ItemInfo)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_Delete_DeptIndentReqToWareHouse_Temp", con);
         cmd.CommandType = CommandType.StoredProcedure;
         try
         {

    
             cmd.Parameters.AddWithValue("@CreatedBy", ItemInfo.CreatedBy);
             cmd.Parameters.AddWithValue("@BranchId", ItemInfo.BranchId);

            

             cmd.ExecuteNonQuery();
             con.Close();
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


     public DataTable CheckInvoiceIsApprove(int IndreqDeptId, int ReqId, int DeptId, int VoucherNo, int WarehouseId)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("SP_CheckInvoiceIsApprove", con);
         cmd.CommandType = CommandType.StoredProcedure;

         try
         {
             cmd.Parameters.AddWithValue("@ReqId", ReqId);
             cmd.Parameters.AddWithValue("@IndreqDeptId", IndreqDeptId);
             cmd.Parameters.AddWithValue("@DeptId", DeptId);
             cmd.Parameters.AddWithValue("@VoucherNo", VoucherNo);
             cmd.Parameters.AddWithValue("@WarehouseId", WarehouseId);
            
             SqlDataAdapter sda = new SqlDataAdapter(cmd);
             DataTable dt = new DataTable();
             sda.Fill(dt);
             return dt;

         }
         catch (Exception ex)
         {
             throw ex;
         }
         finally
         {
             con.Dispose();
             con.Close();
         }
     }


     public DataTable CheckInvoiceIsApprove_ItemWise(int IndReq, int WareHouseId)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("SP_CheckInvoiceIsApprove_ItemWise", con);
         cmd.CommandType = CommandType.StoredProcedure;

         try
         {
             cmd.Parameters.AddWithValue("@IndReq", IndReq);
             cmd.Parameters.AddWithValue("@WareHouseId", WareHouseId);

             SqlDataAdapter sda = new SqlDataAdapter(cmd);
             DataTable dt = new DataTable();
             sda.Fill(dt);
             return dt;

         }
         catch (Exception ex)
         {
             throw ex;
         }
         finally
         {
             con.Dispose();
             con.Close();
         }
     }


     public DataTable CheckInvoiceIs_Approve(int InvoiceNo,int WareHouseId)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("SP_CheckSearch_InvoiceIsApprove", con);
         cmd.CommandType = CommandType.StoredProcedure;

         try
         {
             cmd.Parameters.AddWithValue("@InvoiceNo", InvoiceNo);
             cmd.Parameters.AddWithValue("@WareHouseId", WareHouseId);
           

             SqlDataAdapter sda = new SqlDataAdapter(cmd);
             DataTable dt = new DataTable();
             sda.Fill(dt);
             return dt;

         }
         catch (Exception ex)
         {
             throw ex;
         }
         finally
         {
             con.Dispose();
             con.Close();
         }
     }



     public DataTable CheckInvoiceIs_Approve_Check(int InvoiceNo,int WareHouseId)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("SP_CheckSearch_InvoiceIsApprove_Check", con);
         cmd.CommandType = CommandType.StoredProcedure;

         try
         {
             cmd.Parameters.AddWithValue("@InvoiceNo", InvoiceNo);
             cmd.Parameters.AddWithValue("@WareHouseId", WareHouseId);


             SqlDataAdapter sda = new SqlDataAdapter(cmd);
             DataTable dt = new DataTable();
             sda.Fill(dt);
             return dt;

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

     public DataTable CheckChalanNumber_Exists(string ChallanNo, int WareHouseId)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("SP_CheckChalanNumber_Exists", con);
         cmd.CommandType = CommandType.StoredProcedure;

         try
         {
             cmd.Parameters.AddWithValue("@ChallanNo", ChallanNo);
             cmd.Parameters.AddWithValue("@WareHouseId", WareHouseId);


             SqlDataAdapter sda = new SqlDataAdapter(cmd);
             DataTable dt = new DataTable();
             sda.Fill(dt);
             return dt;

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

     public DataSet GetPatientWiseItemIssueQty(string FromDate, string ToDate, int ItemId, int DeptId, int FId, int BranchId)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();

         SqlCommand cmd = new SqlCommand("Sp_PatientWiseItemIssueQty", con);

         cmd.CommandType = CommandType.StoredProcedure;

         try
         {
             if (FromDate == "")
             {
                 cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
             }
             else
             {
                 cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
             }
             if (ToDate == "")
             {
                 cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);
             }
             else
             {
                 cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
             }

             cmd.Parameters.AddWithValue("@FId", FId);
             cmd.Parameters.AddWithValue("@BranchId", BranchId);
             cmd.Parameters.AddWithValue("@ItemId", ItemId);
             cmd.Parameters.AddWithValue("@DeptId", DeptId);


             SqlDataAdapter sda = new SqlDataAdapter(cmd);
             DataSet ds = new DataSet();
             sda.Fill(ds);
             ds.Tables[0].TableName = "PatientWiseIssuedItems";

             return ds;

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

     public List<string> FillAllSubCategoryName(string prefixtext, string PatientCategoryID)
     {

         SqlConnection con = DataAccess.ConInitForPharmacy();
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_PatInsuTypeFillCombo_Bind", con);
         cmd.CommandType = CommandType.StoredProcedure;
         try
         {
             cmd.Parameters.AddWithValue("@Search", prefixtext);
             cmd.Parameters.AddWithValue("@PatMainTypeId", PatientCategoryID);
             List<string> PatientName = new List<string>();
             SqlDataReader sdr = cmd.ExecuteReader();
             while (sdr.Read())
             {
                 PatientName.Add(sdr["CompanyName"].ToString());

             }
             return PatientName;
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

     public List<string> FillAllSubChargeCategoryName(string prefixtext, string PatientCategoryID)
     {

         SqlConnection con = DataAccess.ConInitForPharmacy();
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_PatInsuTypeChargeFillCombo_Bind", con);
         cmd.CommandType = CommandType.StoredProcedure;
         try
         {
             cmd.Parameters.AddWithValue("@Search", prefixtext);
             cmd.Parameters.AddWithValue("@PatientInsuTypeId", PatientCategoryID);
             List<string> PatientName = new List<string>();
             SqlDataReader sdr = cmd.ExecuteReader();
             while (sdr.Read())
             {
                 PatientName.Add(sdr["CompanyName"].ToString());

             }
             return PatientName;
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
     public DataTable Get_ChildCompany_Description(int Id)
     {
         SqlConnection con = DataAccess.ConInitForPharmacy();
         con.Open();
         SqlCommand cmd = new SqlCommand("SP_Get_ChildCompany_Description", con);
         cmd.CommandType = CommandType.StoredProcedure;
         cmd.Parameters.AddWithValue("@Id", Id);
         SqlDataAdapter da = new SqlDataAdapter(cmd);
         DataTable ds = new DataTable();

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


     public DataSet Get_StoreSummaryLedger( int DeptId)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();

         SqlCommand cmd = new SqlCommand("SP_StoreSummaryLedger", con);

         cmd.CommandType = CommandType.StoredProcedure;

         try
         {           

             cmd.Parameters.AddWithValue("@dptid", DeptId);


             SqlDataAdapter sda = new SqlDataAdapter(cmd);
             DataSet ds = new DataSet();
             sda.Fill(ds);
             ds.Tables[0].TableName = "StoreSummaryLedger";

             return ds;

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

     public DataTable FillEditPurchaseItems(int PoNo, int SupplierId, int FId, int BranchId,int WareHouseId)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_FillEditPurchaseItems", con);
         cmd.CommandType = CommandType.StoredProcedure;

         try
         {
             cmd.Parameters.AddWithValue("@SupplierId", SupplierId);
             cmd.Parameters.AddWithValue("@PoNo", PoNo);
             cmd.Parameters.AddWithValue("@FId", FId);
             cmd.Parameters.AddWithValue("@BranchId", BranchId);
             cmd.Parameters.AddWithValue("@WareHouseId", WareHouseId);
             SqlDataAdapter sda = new SqlDataAdapter(cmd);
             DataTable dt = new DataTable();
             sda.Fill(dt);
             return dt;

         }
         catch (Exception ex)
         {
             throw ex;
         }
         finally
         {
             con.Dispose();
             con.Close();
         }
     }

     public string GetSupplierName(int PoNo, int SupplierId, int WareHouseId)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_GetSupplierName", con);
         cmd.CommandType = CommandType.StoredProcedure;

         try
         {


             cmd.Parameters.AddWithValue("@PoNo", PoNo);
             cmd.Parameters.AddWithValue("@SupplierId", SupplierId);
             cmd.Parameters.AddWithValue("@WareHouseId", WareHouseId);
             string Supp = Convert.ToString(cmd.ExecuteScalar());
             //int RefundVoucherId = Convert.ToInt32(cmd.Parameters["@DeptRefundVoucherId"].Value);//.ToString();
             return Supp;



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


     public DataSet SearchApprove_PurchaseList(string FromDate, string ToDate, int SuppId, int PoNo, int Status,int WareHouseId)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_Vw_SearchApprovePOList", con);
         cmd.CommandType = CommandType.StoredProcedure;
         try
         {
             if (FromDate == "")
             {
                 cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
             }
             else
             {
                 // cmd.Parameters.AddWithValue("@FromDate",Convert.ToDateTime(FromDate));
                 cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
             }
             if (ToDate == "")
             {
                 cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

             }
             else
             {
                 // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                 cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
             }

             cmd.Parameters.AddWithValue("@SupplierId", SuppId);
             cmd.Parameters.AddWithValue("@PoNo", PoNo);
             cmd.Parameters.AddWithValue("@Status", Status);
             cmd.Parameters.AddWithValue("@WareHouseId", WareHouseId);
             SqlDataAdapter sda = new SqlDataAdapter(cmd);
             DataSet ds = new DataSet();
             sda.Fill(ds);
             return ds;

         }
         catch (Exception ex)
         {
             throw ex;
         }
         finally
         {
             con.Dispose();
             con.Close();
         }
     }


     public DataSet Fill_Remarks()
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("GetRemark_Master", con);
         cmd.CommandType = CommandType.StoredProcedure;
         SqlDataAdapter da = new SqlDataAdapter(cmd);
         DataSet ds = new DataSet();
         da.Fill(ds);
         return ds;
     }

     public List<string> AutoFillRemarkItems(string prefixtext, int DeptId)
     {
         // BEL ItemInfo = new BEL();

         SqlConnection con = new SqlConnection(constr);
         con.Open();
         //con.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;//ToString();

         try
         {
             SqlCommand cmd = new SqlCommand("Sp_GetRemark_List", con);

             cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.AddWithValue("@Search", prefixtext);
             cmd.Parameters.AddWithValue("@DeptId", DeptId);

             List<string> items = new List<string>();
             SqlDataReader sdr = cmd.ExecuteReader();

             while (sdr.Read())
             {
                 items.Add(sdr["RemarkName"].ToString());
             }



             return items;
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

     public void CancelPurchaseOrder(int PoNo, int SupplierId, string CancelBy,int WareHouseId)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_CancelPoOrder", con);
         cmd.CommandType = CommandType.StoredProcedure;

         try
         {
             cmd.Parameters.AddWithValue("@PoNo", PoNo);
             cmd.Parameters.AddWithValue("@SupplierId", SupplierId);
             cmd.Parameters.AddWithValue("@CancelBy", CancelBy);
             cmd.Parameters.AddWithValue("@WareHouseId", WareHouseId);
             cmd.ExecuteNonQuery();
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

     public void CancelIndentOrder(int ReqId, int DeptId, int IndreqDeptId, string CancelBy)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_CancelIndentOrder", con);
         cmd.CommandType = CommandType.StoredProcedure;

         try
         {
             cmd.Parameters.AddWithValue("@ReqId", ReqId);
             cmd.Parameters.AddWithValue("@DeptId", DeptId);
             cmd.Parameters.AddWithValue("@IndreqDeptId", IndreqDeptId);
             cmd.Parameters.AddWithValue("@CancelBy", CancelBy);
             cmd.ExecuteNonQuery();
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


     public DataSet SearchApprove_PurchaseList_AfterMPO(string FromDate, string ToDate, int SuppId, int PoNo, int Status,int WareHouseId)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_Vw_SearchApprovePOList_ForMPO", con);
         cmd.CommandType = CommandType.StoredProcedure;
         try
         {
             if (FromDate == "")
             {
                 cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
             }
             else
             {
                 // cmd.Parameters.AddWithValue("@FromDate",Convert.ToDateTime(FromDate));
                 cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
             }
             if (ToDate == "")
             {
                 cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

             }
             else
             {
                 // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                 cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
             }

             cmd.Parameters.AddWithValue("@SupplierId", SuppId);
             cmd.Parameters.AddWithValue("@PoNo", PoNo);
             cmd.Parameters.AddWithValue("@Status", Status);
             cmd.Parameters.AddWithValue("@WareHouseId", WareHouseId);
             SqlDataAdapter sda = new SqlDataAdapter(cmd);
             DataSet ds = new DataSet();
             sda.Fill(ds);
             return ds;

         }
         catch (Exception ex)
         {
             throw ex;
         }
         finally
         {
             con.Dispose();
             con.Close();
         }
     }

     public DataTable CheckInvoiceIs_Save_Check(int PoNo, int WareHouseId)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("SP_CheckInvoiceIs_Save_Check", con);
         cmd.CommandType = CommandType.StoredProcedure;

         try
         {
             cmd.Parameters.AddWithValue("@PoNo", PoNo);
             cmd.Parameters.AddWithValue("@WareHouseId", WareHouseId);

             SqlDataAdapter sda = new SqlDataAdapter(cmd);
             DataTable dt = new DataTable();
             sda.Fill(dt);
             return dt;

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

     public DataTable CheckManualConsuptionApprove(int ManConsumptionId)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("SP_CheckManualConsumptionApprove", con);
         cmd.CommandType = CommandType.StoredProcedure;

         try
         {
             cmd.Parameters.AddWithValue("@ManConsumptionId", ManConsumptionId);
             

             SqlDataAdapter sda = new SqlDataAdapter(cmd);
             DataTable dt = new DataTable();
             sda.Fill(dt);
             return dt;

         }
         catch (Exception ex)
         {
             throw ex;
         }
         finally
         {
             con.Dispose();
             con.Close();
         }
     }

     public void Upadte_DeptwiseReorderLevel(BEL ItemCurrStock)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_Insert_UpdateDept_WiseReorderLevel", con);
         cmd.CommandType = CommandType.StoredProcedure;
         try
         {
             cmd.Parameters.AddWithValue("@ItemId", ItemCurrStock.ItemId);
             cmd.Parameters.AddWithValue("@ReOrderLevel", ItemCurrStock.DeptReorderLevel);
             cmd.Parameters.AddWithValue("@BranchId", ItemCurrStock.BranchId);
             cmd.Parameters.AddWithValue("@DeptId", ItemCurrStock.DeptId);
             cmd.Parameters.AddWithValue("@CreatedBy", ItemCurrStock.CreatedBy);
             cmd.Parameters.AddWithValue("@Remark", ItemCurrStock.Remark);
            
             cmd.ExecuteNonQuery();
             con.Close();
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

     public DataSet Search_DeptwiseReorderCurrentStock(BEL Itemstock)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_Vw_DeptwiseReorderLevel", con);
         cmd.CommandType = CommandType.StoredProcedure;
         try
         {
             cmd.Parameters.AddWithValue("@ItemId", Itemstock.ItemId);
             //  cmd.Parameters.AddWithValue("@BatchNo", Itemstock.BatchNo);
             cmd.Parameters.AddWithValue("@CategoryId", Itemstock.CategoryId);
             cmd.Parameters.AddWithValue("@MainCategory", Itemstock.MainCategory);
             cmd.Parameters.AddWithValue("@BranchId", Itemstock.BranchId);
             cmd.Parameters.AddWithValue("@DeptId", Itemstock.Fid);

             SqlDataAdapter sda = new SqlDataAdapter(cmd);
             DataSet ds = new DataSet();
             sda.Fill(ds);
             return ds;

         }
         catch (Exception ex)
         {
             throw ex;
         }
         finally
         {
             con.Dispose();
             con.Close();
         }


     }

     public DataTable ReminderDeptwiseReorderCurrentStock(BEL Itemstock)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_Vw_DeptwiseReorderLevel", con);
         cmd.CommandType = CommandType.StoredProcedure;
         try
         {
             cmd.Parameters.AddWithValue("@ItemId", Itemstock.ItemId);
             //  cmd.Parameters.AddWithValue("@BatchNo", Itemstock.BatchNo);
             cmd.Parameters.AddWithValue("@CategoryId", Itemstock.CategoryId);
             cmd.Parameters.AddWithValue("@MainCategory", Itemstock.MainCategory);
             cmd.Parameters.AddWithValue("@BranchId", Itemstock.BranchId);
             cmd.Parameters.AddWithValue("@DeptId", Itemstock.Fid);

             SqlDataAdapter sda = new SqlDataAdapter(cmd);
             DataTable ds = new DataTable();
             sda.Fill(ds);
             return ds;

         }
         catch (Exception ex)
         {
             throw ex;
         }
         finally
         {
             con.Dispose();
             con.Close();
         }
     }
     public DataSet GetDeptIndentList_Warehouse_DeptWise(string FromDate, string ToDate, int DeptId, int ReqId, int Status, int FId, int BranchId,string UserType,int WareHouseId)
     {
         SqlConnection con = new SqlConnection(constr);
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_SearchDeptIndList_Warehouse_DeptWise", con);
         cmd.CommandType = CommandType.StoredProcedure;

         try
         {
             if (FromDate == "")
             {
                 cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
             }
             else
             {

                 cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
             }
             if (ToDate == "")
             {
                 cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

             }
             else
             {

                 cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
             }
             cmd.Parameters.AddWithValue("@ReqId", ReqId);
             cmd.Parameters.AddWithValue("@DeptId", DeptId);
             cmd.Parameters.AddWithValue("@Status", Status);
             cmd.Parameters.AddWithValue("@FId", FId);
             cmd.Parameters.AddWithValue("@BranchId", BranchId);
             cmd.Parameters.AddWithValue("@UserType", UserType);
             cmd.Parameters.AddWithValue("@WareHouseId", WareHouseId);
             SqlDataAdapter sda = new SqlDataAdapter(cmd);
             DataSet ds = new DataSet();
             sda.Fill(ds);
             return ds;

         }

         catch (Exception ex)
         {
             throw ex;
         }
         finally
         {
             con.Dispose();
             con.Close();
         }

     }

     public List<string> FillAllSubChargeCategoryName1(string prefixtext, string PatientCategoryID)
     {

         SqlConnection con = DataAccess.ConInitForPharmacy();
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_PatInsuTypeChargeFillCombo_Bind", con);
         cmd.CommandType = CommandType.StoredProcedure;
         try
         {
             cmd.Parameters.AddWithValue("@Search", prefixtext);
             cmd.Parameters.AddWithValue("@PatientInsuTypeId", PatientCategoryID);
             List<string> PatientName = new List<string>();
             SqlDataReader sdr = cmd.ExecuteReader();
             while (sdr.Read())
             {
                 PatientName.Add(sdr["CompanyName"].ToString());

             }
             return PatientName;
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


     public DataTable Get_InsuranceAmt(int Id)
     {
         SqlConnection con = DataAccess.ConInitForPharmacy();
         con.Open();
         SqlCommand cmd = new SqlCommand("SP_GetCompany_plan", con);
         cmd.CommandType = CommandType.StoredProcedure;
         cmd.Parameters.AddWithValue("@PolicyMstID", Id);
         SqlDataAdapter da = new SqlDataAdapter(cmd);
         DataTable ds = new DataTable();

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

    
