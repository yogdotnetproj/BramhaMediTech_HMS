using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;


public class DALOpdReg
{
   // Database objDatabase = DatabaseFactory.CreateDatabase();
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    BELOPDPatReg objBELOPDPatReg = new BELOPDPatReg();
    BELBillService objBELBillService = new BELBillService();
	public DALOpdReg()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public List<string> FillAllLAbService_Name_Charges(string prefixtext, string Type, int PType)
    {
        //if (PType != 0)
        //{
        SqlConnection con = new SqlConnection();
        if (PType == 1)
        {
            con = DataAccess.ConInitForPathology();
        }
        if (PType == 2)
        {
            con = DataAccess.ConInitForRadiology();
        }
        if (PType == 3)
        {
            con = DataAccess.ConInitForMedical();
        }
        if (PType == 4)
        {
            con = DataAccess.ConInitForCardiology();
        }
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetAllLabServiceNameandCharges", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@ServiceType", Type);
            cmd.Parameters.AddWithValue("@Search", prefixtext);
            List<string> PatientName = new List<string>();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                PatientName.Add(sdr["ServiceName"].ToString());

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
        //}
        //else
        //{
        //    return null;
        //}

    }
    public string HandOverToOtherDoctor(int OrgOpdno, string Patregid, string ReferBy, int DrId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_HandOverToOtherDoctor", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@OrgOpdno", OrgOpdno);
            cmd.Parameters.AddWithValue("@Patregid", Patregid);
            cmd.Parameters.AddWithValue("@DrId", DrId);
            cmd.Parameters.AddWithValue("@ReferBy", ReferBy);


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
    public string ReferToOtherDoctor(int OrgOpdno, string Patregid, string  ReferBy, int DrId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_ReferToOtherDoctor", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@OrgOpdno", OrgOpdno);
            cmd.Parameters.AddWithValue("@Patregid", Patregid);
            cmd.Parameters.AddWithValue("@DrId", DrId);
            cmd.Parameters.AddWithValue("@ReferBy", ReferBy);


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

    public string Update_ReferDr(int IpdNo, string Patregid, int Branchid, int RefDr)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_updateIpdRegistration_ReferBy_Doc", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@IpdNo", IpdNo);
            cmd.Parameters.AddWithValue("@Patregid", Patregid);
            cmd.Parameters.AddWithValue("@Branchid", Branchid);
            cmd.Parameters.AddWithValue("@ReferBy_Doc", RefDr);


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

    public List<string> FillAllIPDPatient_Details(string prefixtext)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_FillAllIPDPatientDetails", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@Search", prefixtext);
            List<string> PatientName = new List<string>();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                PatientName.Add(sdr["PatientName"].ToString());

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

    public List<string> FillAllIPDPatientFullName(string prefixtext)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_PatientInfo_FillAllIPDPatientDetails", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@Search", prefixtext);
            List<string> PatientName = new List<string>();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                PatientName.Add(sdr["PatientName"].ToString());

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
    public List<string> FillAllGroup(string prefixtext, string Type)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetAllBillGroup", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@ServiceType", Type);
            cmd.Parameters.AddWithValue("@Search", prefixtext);
            List<string> PatientName = new List<string>();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                PatientName.Add(sdr["ServiceName"].ToString());

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

    public List<string> FillAllLAbService_Name(string prefixtext, string Type, int PType)
    {
        //if (PType != 0)
        //{
            SqlConnection con = new SqlConnection();
            if (PType == 1)
            {
                con = DataAccess.ConInitForPathology();
            }
            if (PType == 2)
            {
                con = DataAccess.ConInitForRadiology();
            }
            if (PType == 3)
            {
                con = DataAccess.ConInitForMedical();
            }
            if (PType == 4)
            {
                con = DataAccess.ConInitForCardiology();
            }
           con.Open();
            SqlCommand cmd = new SqlCommand("Sp_GetAllLabServiceName", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.AddWithValue("@ServiceType", Type);
                cmd.Parameters.AddWithValue("@Search", prefixtext);
                List<string> PatientName = new List<string>();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    PatientName.Add(sdr["ServiceName"].ToString());

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
        //}
        //else
        //{
        //    return null;
        //}

    }
    public List<string> FillAllSubCategoryName(string prefixtext, string PatientCategoryID)
    {

        SqlConnection con = DataAccess.ConInitForDC();
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

    public List<string> FillAllPatientFullName(string prefixtext)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_PatientInfo_FillAllPatientDetails", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@Search", prefixtext);
            List<string> PatientName = new List<string>();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                PatientName.Add(sdr["PatientName"].ToString());

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
    public string UpdateEMRIPDLabOrderAccept(BELOPDPatReg obj1)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_UpdateEMRIPDLabOrderAccept", con);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@IpdNo", obj1.IpdNo);
        cmd.Parameters.AddWithValue("@Patregid", obj1.PatRegId);

        cmd.Parameters.AddWithValue("@BranchId", obj1.BranchId);
        cmd.Parameters.AddWithValue("@LabNo", obj1.LabNo);
        cmd.Parameters.AddWithValue("@BilledBy", obj1.CreatedBy);

        object Result = cmd.ExecuteScalar();
        con.Close();
        con.Dispose();
        return Convert.ToString(Result);
    }
    public object[] InsertIPDLabPatientRegistration(BELOPDPatReg obj1)
    {
        object[] Result = new object[10];
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_InsertIPDLabRegistration", con);
        cmd.CommandType = CommandType.StoredProcedure;

        try
        {

            // cmd.Parameters.AddWithValue("@RegistrationType", obj1.RegistrationTypeName);
            // cmd.Parameters.AddWithValue("@EntryDate",obj1.EntryDate);
            cmd.Parameters.AddWithValue("@PatRegId", obj1.PatRegId);
            cmd.Parameters.AddWithValue("@BranchId", obj1.BranchId);
            cmd.Parameters.AddWithValue("@FId", obj1.FId);
            cmd.Parameters.AddWithValue("@VisitingNo", obj1.VisitingNo);
            cmd.Parameters.AddWithValue("@TokenNo", obj1.TokenNo);
            cmd.Parameters.AddWithValue("@DrId", obj1.DrId);
            cmd.Parameters.AddWithValue("@PatientComplaints", obj1.PatientComplaint);
            cmd.Parameters.AddWithValue("@PatMainTypeId", obj1.PatMainTypeId);
            cmd.Parameters.AddWithValue("@PatientInsuTypeId", obj1.PatientInsuTypeId);
            //cmd.Parameters.AddWithValue("@Shift",obj1.ShiftName);         
            // cmd.Parameters.AddWithValue("@ReferenceDrText",obj1.ReferenceDrText);
            cmd.Parameters.AddWithValue("@ReferenceDoc", obj1.ReferenceDrName);
            cmd.Parameters.AddWithValue("@CreatedBy", obj1.CreatedBy);
            cmd.Parameters.AddWithValue("@DeptId", obj1.DeptId);
            cmd.Parameters.AddWithValue("@ReferBy", obj1.ReferBy);
            cmd.Parameters.AddWithValue("@LabPtype", obj1.LabPtype);
            cmd.Parameters.AddWithValue("@MainDoctor", obj1.MainDoctor);
            cmd.Parameters.Add("@LabNo", SqlDbType.Int);
            cmd.Parameters["@LabNo"].Direction = ParameterDirection.Output;
            // Result[1] =  
            cmd.ExecuteNonQuery();
            Result[0] = Convert.ToInt32(cmd.Parameters["@LabNo"].Value);
            return Result;


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

    public object[] InsertLabPatientRegistration(BELOPDPatReg obj1)
    {
        object[] Result = new object[10];
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_InsertLabRegistration", con);
        cmd.CommandType = CommandType.StoredProcedure;

        try
        {

            // cmd.Parameters.AddWithValue("@RegistrationType", obj1.RegistrationTypeName);
            // cmd.Parameters.AddWithValue("@EntryDate",obj1.EntryDate);
            cmd.Parameters.AddWithValue("@PatRegId", obj1.PatRegId);
            cmd.Parameters.AddWithValue("@BranchId", obj1.BranchId);
            cmd.Parameters.AddWithValue("@FId", obj1.FId);
            cmd.Parameters.AddWithValue("@VisitingNo", obj1.VisitingNo);
            cmd.Parameters.AddWithValue("@TokenNo", obj1.TokenNo);
            cmd.Parameters.AddWithValue("@DrId", obj1.DrId);
            cmd.Parameters.AddWithValue("@PatientComplaints", obj1.PatientComplaint);
            cmd.Parameters.AddWithValue("@PatMainTypeId", obj1.PatMainTypeId);
            cmd.Parameters.AddWithValue("@PatientInsuTypeId", obj1.PatientInsuTypeId);
            //cmd.Parameters.AddWithValue("@Shift",obj1.ShiftName);         
            // cmd.Parameters.AddWithValue("@ReferenceDrText",obj1.ReferenceDrText);
            cmd.Parameters.AddWithValue("@ReferenceDoc", obj1.ReferenceDrName);
            cmd.Parameters.AddWithValue("@CreatedBy", obj1.CreatedBy);
            cmd.Parameters.AddWithValue("@DeptId", obj1.DeptId);
            cmd.Parameters.AddWithValue("@ReferBy", obj1.ReferBy);
            cmd.Parameters.AddWithValue("@LabPtype", obj1.LabPtype);
            cmd.Parameters.AddWithValue("@MainDoctor", obj1.MainDoctor);
            cmd.Parameters.AddWithValue("@AfterHrs", obj1.AfterHrs);
            cmd.Parameters.AddWithValue("@InsuranceChargeCompany", obj1.PatientInsuChargeId);

            cmd.Parameters.AddWithValue("@LetterNo", obj1.LetterNo);
            cmd.Parameters.AddWithValue("@EmrLabNo", obj1.EmrLabNo); 

            cmd.Parameters.Add("@LabNo", SqlDbType.Int);
            cmd.Parameters["@LabNo"].Direction = ParameterDirection.Output;
            // Result[1] =  
            cmd.ExecuteNonQuery();
            Result[0] = Convert.ToInt32(cmd.Parameters["@LabNo"].Value);
            return Result;


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


    public BELOPDPatReg SelectOne(int OpdNo)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_PatientRegistration_SelectOne", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@OpdNo", OpdNo);
        SqlDataReader sdr = cmd.ExecuteReader();       
        while (sdr.Read())
        {
            objBELOPDPatReg.PatRegId = Convert.ToInt32(sdr["PatRegId"]);
            objBELOPDPatReg.RegistrationNo = Convert.ToString(sdr["RegistrationNo"]);
            objBELOPDPatReg.RegistrationTypeId = Convert.ToInt32(sdr["RegistrationTypeId"]);
            objBELOPDPatReg.RegistrationDateTime = Convert.ToString(sdr["RegistrationDateTime"]);
            objBELOPDPatReg.PatientInfoId = Convert.ToInt32(sdr["PatientInfoId"]);
            objBELOPDPatReg.EmployeeId = Convert.ToInt32(sdr["EmployeeId"]);
            objBELOPDPatReg.EmployeeName = Convert.ToString(sdr["EmployeeName"]);
            objBELOPDPatReg.HospitalId = Convert.ToInt32(sdr["HospitalId"]);
            objBELOPDPatReg.SectionId = Convert.ToInt32(sdr["SectionId"]);
            objBELOPDPatReg.KinName = Convert.ToString(sdr["KinName"]);
            objBELOPDPatReg.RelationOfKin = Convert.ToString(sdr["RelationOfKin"]);
            objBELOPDPatReg.PatientComplaint = Convert.ToString(sdr["PatientComplaint"]);
            objBELOPDPatReg.ShiftId = Convert.ToInt32(sdr["ShiftId"]);
            objBELOPDPatReg.ReferenceDrId = Convert.ToInt32(sdr["ReferenceDrId"]);
            objBELOPDPatReg.ReferenceDrName = Convert.ToString(sdr["ReferenceDrName"]);
            objBELOPDPatReg.ReferenceDrText = Convert.ToString(sdr["ReferenceDrText"]);
            objBELOPDPatReg.AdmissionType = Convert.ToString(sdr["AdmissionType"]);
            objBELOPDPatReg.MLCNo = Convert.ToString(sdr["MLCNo"]);
            objBELOPDPatReg.PatientName = Convert.ToString(sdr["PatientName"]);
            
        }
        con.Close();
        con.Dispose();
        return objBELOPDPatReg;
    }

    //public List<BELOPDPatReg> SelectAll()
    //{
    //    List<BELOPDPatReg> objBELOPDPatRegs = new List<BELOPDPatReg>();
    //    DbCommand objDbCommand = objDatabase.GetStoredProcCommand("SP_PatientRegistration_SelectAll");
    //    IDataReader reader = objDatabase.ExecuteReader(objDbCommand);
    //    while (reader.Read())
    //    {
    //        BELOPDPatReg objBELOPDPatReg = new BELOPDPatReg();

    //        objBELOPDPatReg.PatientRegistrationId = Convert.ToInt32(reader["PatientRegistrationId"]);
    //        objBELOPDPatReg.RegistrationNo = Convert.ToString(reader["RegistrationNo"]);
    //        objBELOPDPatReg.RegistrationTypeId = Convert.ToInt32(reader["RegistrationTypeId"]);
    //        objBELOPDPatReg.RegistrationDateTime = Convert.ToString(reader["RegistrationDateTime"]);
    //        objBELOPDPatReg.PatientInfoId = Convert.ToInt32(reader["PatientInfoId"]);
    //        objBELOPDPatReg.HospitalId = Convert.ToInt32(reader["HospitalId"]);
    //        objBELOPDPatReg.SectionId = Convert.ToInt32(reader["SectionId"]);
    //        objBELOPDPatReg.KinName = Convert.ToString(reader["KinName"]);
    //        objBELOPDPatReg.RelationOfKin = Convert.ToString(reader["RelationOfKin"]);
    //        objBELOPDPatReg.PatientComplaint = Convert.ToString(reader["PatientComplaint"]);
    //        objBELOPDPatReg.ShiftId = Convert.ToInt32(reader["ShiftId"]);
    //        objBELOPDPatReg.ReferenceDrId = Convert.ToInt32(reader["ReferenceDrId"]);
    //        objBELOPDPatReg.ReferenceDrText = Convert.ToString(reader["ReferenceDrText"]);
           

    //        objBELOPDPatRegs.Add(objBELOPDPatReg);

    //    }
    //    reader.Close();
    //    reader.Dispose();
    //    return objBELOPDPatRegs;
    //}

   
    //public List<BELOPDPatReg> FillCombo()
    //{
    //    List<BELOPDPatReg> objBELOPDPatRegs = new List<BELOPDPatReg>();

    //    DbCommand objDbCommand = objDatabase.GetStoredProcCommand("SP_PatientRegistration_FillCombo");
    //    IDataReader reader = objDatabase.ExecuteReader(objDbCommand);
    //    while (reader.Read())
    //    {
    //        BELOPDPatReg objBELOPDPatReg = new BELOPDPatReg();

    //        objBELOPDPatReg.PatientRegistrationId = Convert.ToInt32(reader["PatientRegistrationId"]);
    //        objBELOPDPatReg.RegistrationNo = Convert.ToString(reader["RegistrationNo"]);

    //        objBELOPDPatRegs.Add(objBELOPDPatReg);
    //    }
    //    reader.Close();
    //    reader.Dispose();
    //    return objBELOPDPatRegs;
    //}

    
    public DataSet FillGrid()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();        
        SqlDataAdapter da = new SqlDataAdapter("SP_PatientRegistration_FillGrid", con);

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
   
    public DataSet FillRegistrationTypeName()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();        
        SqlDataAdapter da = new SqlDataAdapter("Sp_RegistrationTypeFillDrop", con);

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


    public DataSet FillReferenceDoctor()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();        
        SqlDataAdapter da = new SqlDataAdapter("Sp_ReferenceDocFillDrop", con);

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

    public DataSet FillRelationDrop()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();        
        SqlDataAdapter da = new SqlDataAdapter("Sp_RelationFillDrop", con);

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
   public decimal GetDepositAmount(int PatRegId,int FId, int BranchId )
   {
         object Result;
         SqlConnection con = DataAccess.ConInitForDC();
         con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetDepositAmt", con);
         cmd.CommandType = CommandType.StoredProcedure;

         try
         {
             cmd.Parameters.AddWithValue("@PatRegId",PatRegId);
             cmd.Parameters.AddWithValue("@BranchId",BranchId);
             cmd.Parameters.AddWithValue("@FId",FId);
             Result = cmd.ExecuteScalar();
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
         return Convert.ToDecimal(Result);
 

   }
   public DataTable Bind_MainDoctor(string PType)
   {
       DataTable ds = new DataTable();
       SqlConnection con = new SqlConnection();
       if (PType != "")
       {
           if (PType == "1")
           {
               con = DataAccess.ConInitForPathology();
           }
           if (PType == "2")
           {
               con = DataAccess.ConInitForRadiology();
           }
           if (PType == "3")
           {
               con = DataAccess.ConInitForMedical();
           }
           if (PType == "4")
           {
               con = DataAccess.ConInitForCardiology();
           }
           con.Open();
           //SqlDataAdapter sda = new SqlDataAdapter(" select top(20) RoutinTestCode,RoutinTestCode+' - '+ RoutinTestName as Maintestname from RoutinTest  ", con);
           SqlDataAdapter sda = new SqlDataAdapter(" SELECT DrId,Name  from  CTUSer where Usertype='Main Doctor' ", con);

           
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
       }
       return ds;
   }
   public DataSet GetBillGroup()
   {
       SqlConnection con = DataAccess.ConInitForDC();
       con.Open();
       SqlDataAdapter da = new SqlDataAdapter("Sp_BillGroupForOPD", con);

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

    public DataSet FillConsultantDocName()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();        
        SqlDataAdapter da = new SqlDataAdapter("Sp_ConsultantDocFillDrop", con);

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

    public DataSet FillConsultantDocName_Emr()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("Sp_ConsultantDocFillDropdown", con);

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
    public DataSet FillConsultantDocNameByEmpId(int EmpId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
       
        SqlCommand cmd = new SqlCommand("Sp_ConsultantDocFillDropByEmpId", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EmpId", EmpId);
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
    public DataSet FillBillGroupNameOPD()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();        
        SqlDataAdapter da = new SqlDataAdapter("Sp_BillGroupOPDFillDrop", con);

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
   
     public DataSet FillInsuranceComp()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();        
        SqlDataAdapter da = new SqlDataAdapter("Sp_InsuranceCompFillDrop", con);

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
    //public List<DOCancelAdmission> FillGridByRegistrationType(string RegistrationType)
    //{
    //    List<DOCancelAdmission> objDOCancelAdmissions = new List<DOCancelAdmission>();

    //    DbCommand objDbCommand = objDatabase.GetStoredProcCommand("SP_PatientRegistration_FillGrid_ByRegistrationType");
    //    objDatabase.AddInParameter(objDbCommand, "@RegistrationTypeName",RegistrationType);
    //    IDataReader reader = objDatabase.ExecuteReader(objDbCommand);
    //    while (reader.Read())
    //    {
    //        DOCancelAdmission objDOCancelAdmission = new DOCancelAdmission();
    //        if (RegistrationType.Equals("OPD"))
    //        {
    //            objDOCancelAdmission.PatientRegistrationId = Convert.ToInt32(reader["PatientRegistrationId"]);
    //            objDOCancelAdmission.RegistrationNo = Convert.ToString(reader["RegistrationNo"]);
    //            objDOCancelAdmission.RegistrationTypeName = Convert.ToString(reader["RegistrationTypeName"]);
    //            objDOCancelAdmission.RegistrationDateTime = Convert.ToString(reader["RegistrationDateTime"]);
    //            objDOCancelAdmission.PatientName = Convert.ToString(reader["PatientName"]);
               
    //            objDOCancelAdmissions.Add(objDOCancelAdmission);
    //        }
    //        else if (RegistrationType.Equals("IPD"))
    //        {
    //            objDOCancelAdmission.PatientRegistrationId = Convert.ToInt32(reader["PatientRegistrationId"]);
    //            objDOCancelAdmission.BedId = Convert.ToInt32(reader["BedId"]);
    //            objDOCancelAdmission.RoomBed = Convert.ToString(reader["RoomBed"]);
    //            objDOCancelAdmission.DrName = Convert.ToString(reader["DrName"]);
    //            objDOCancelAdmission.PatientName = Convert.ToString(reader["PatientName"]);
    //            objDOCancelAdmissions.Add(objDOCancelAdmission);
    //        }
    //    }
    //    reader.Close();
    //    reader.Dispose();
    //    return objDOCancelAdmissions;
    //}

   
    //public List<BELBillInfo> FillSearchGrid(BELBillInfoInfo objBELBillInfoInfo, BELOPDPatReg objBELOPDPatReg, DateTime FromDate, DateTime ToDate, string RegistrationType)
    //{
    //    List<BELBillInfo> objBELBillInfos = new List<BELBillInfo>();

    //    DbCommand objDbCommand = objDatabase.GetStoredProcCommand("SP_PatientRegistration_Search1");
    //    objDatabase.AddInParameter(objDbCommand, "@FromDate", DbType.DateTime, FromDate);
    //    objDatabase.AddInParameter(objDbCommand, "@ToDate", DbType.DateTime, ToDate);
    //    objDatabase.AddInParameter(objDbCommand, "@PatientName",objBELBillInfoInfo.PatientName);
    //    objDatabase.AddInParameter(objDbCommand, "@LastName",objBELBillInfoInfo.LastName);
    //    objDatabase.AddInParameter(objDbCommand, "@DoctorName",objBELOPDPatReg.ReferenceDrName);
    //    objDatabase.AddInParameter(objDbCommand, "@RegistrationNo",objBELOPDPatReg.RegistrationNo);
    //    objDatabase.AddInParameter(objDbCommand, "@PrnNo",objBELBillInfoInfo.PrnNo);
    //    objDatabase.AddInParameter(objDbCommand, "@BarcodeId",objBELBillInfoInfo.BarcodeId);
    //    objDatabase.AddInParameter(objDbCommand, "@ContactNo",objBELBillInfoInfo.MobileNo);
    //    objDatabase.AddInParameter(objDbCommand, "@DepartmentName",objBELOPDPatReg.SectionName);
    //    objDatabase.AddInParameter(objDbCommand, "@RegistrationTypeName",RegistrationType);
    //    IDataReader reader = objDatabase.ExecuteReader(objDbCommand);
    //    while (reader.Read())
    //    {

    //        BELBillInfo objBELBillInfo = new BELBillInfo();
    //        objBELBillInfo.BillId = Convert.ToInt32(reader["BillId"]);
    //        objBELBillInfo.PatientInfoId = Convert.ToInt32(reader["PatientInfoId"]);
    //        objBELBillInfo.PatientRegistrationId = Convert.ToInt32(reader["PatientRegistrationId"]);
    //        objBELBillInfo.RegistrationNo = Convert.ToString(reader["RegistrationNo"]);
    //        objBELBillInfo.PatientName = Convert.ToString(reader["PatientName"]);
    //        objBELBillInfo.Age = Convert.ToString(reader["Age"]);
    //        objBELBillInfo.GenderName = Convert.ToString(reader["GenderName"]);
    //        objBELBillInfo.RegistrationDateTime = Convert.ToString(reader["RegistrationDateTime"]);
    //        objBELBillInfo.PatientCategoryName = Convert.ToString(reader["PatientCategoryName"]);
    //        objBELBillInfo.ConsultantDrName = Convert.ToString(reader["ConsultantDrName"]);
    //        objBELBillInfo.PatientComplaint = Convert.ToString(reader["PatientComplaint"]);
    //        objBELBillInfo.ReferenceDrName = Convert.ToString(reader["ReferenceDr"]);
    //        objBELBillInfo.Balance = Convert.ToInt32(reader["Balance"]);
    //        objBELBillInfos.Add(objBELBillInfo);
    //    }
    //    reader.Close();
    //    reader.Dispose();
    //    return objBELBillInfos;
    //}

   
    public object[] InsertOPDPatientRegistration(BELOPDPatReg obj1)
    {
        object[] Result = new object[10];
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_InsertOPDRegistration",con);
        cmd.CommandType = CommandType.StoredProcedure;
        
        try
        {

        // cmd.Parameters.AddWithValue("@RegistrationType", obj1.RegistrationTypeName);
        // cmd.Parameters.AddWithValue("@EntryDate",obj1.EntryDate);
         cmd.Parameters.AddWithValue("@PatRegId", obj1.PatRegId);
         cmd.Parameters.AddWithValue("@BranchId",obj1.BranchId);
         cmd.Parameters.AddWithValue("@FId",obj1.FId);
         cmd.Parameters.AddWithValue("@VisitingNo",obj1.VisitingNo);
         cmd.Parameters.AddWithValue("@TokenNo", obj1.TokenNo);
         cmd.Parameters.AddWithValue("@DrId",obj1.DrId);
         cmd.Parameters.AddWithValue("@PatientComplaints",obj1.PatientComplaint);
         cmd.Parameters.AddWithValue("@PatMainTypeId", obj1.PatMainTypeId);
         cmd.Parameters.AddWithValue("@PatientInsuTypeId", obj1.PatientInsuTypeId);           
         //cmd.Parameters.AddWithValue("@Shift",obj1.ShiftName);         
        // cmd.Parameters.AddWithValue("@ReferenceDrText",obj1.ReferenceDrText);
         cmd.Parameters.AddWithValue("@ReferenceDoc",obj1.ReferenceDrName);
         cmd.Parameters.AddWithValue("@CreatedBy",obj1.CreatedBy);
         cmd.Parameters.AddWithValue("@DeptId", obj1.DeptId);
         cmd.Parameters.AddWithValue("@VaccinationStatus", obj1.VaccinationStatus);
            cmd.Parameters.Add("@OpdNo",SqlDbType.Int);
            cmd.Parameters["@OpdNo"].Direction = ParameterDirection.Output;
            Result[1] = cmd.ExecuteScalar();
            Result[0] = Convert.ToInt32(cmd.Parameters["@OpdNo"].Value);
            return Result;
            
            
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

    public object[] InsertQuotationBillMaster(BELOPDPatReg obj1)
    {
        object[] Result = new object[10];
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Insert_QuotationBillMaster", con);
        cmd.CommandType = CommandType.StoredProcedure;

        try
        {
            cmd.Parameters.AddWithValue("@PatRegId", obj1.PatRegId);
            cmd.Parameters.AddWithValue("@PatientName", obj1.PatientName);
            cmd.Parameters.AddWithValue("@Age", obj1.Age);
            cmd.Parameters.AddWithValue("@AgeType", obj1.AgeType);
            cmd.Parameters.AddWithValue("@MobileNo", obj1.MobileNo);
            cmd.Parameters.AddWithValue("@PatAddress", obj1.PatientAddress);
            cmd.Parameters.AddWithValue("@DrName", obj1.DRName);
            cmd.Parameters.AddWithValue("@BillAmount", obj1.BillAmount);
          
            cmd.Parameters.AddWithValue("@BranchId", obj1.BranchId);
            cmd.Parameters.AddWithValue("@FId", obj1.FId);
            cmd.Parameters.AddWithValue("@CreatedBy", obj1.CreatedBy);       

            cmd.Parameters.Add("@ProcedureId", SqlDbType.Int);
           // cmd.Parameters.Add("@BillNo", SqlDbType.Int);
            cmd.Parameters["@ProcedureId"].Direction = ParameterDirection.Output;
           // cmd.Parameters["@BillNo"].Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
           // Result[1] = Convert.ToInt32(cmd.Parameters["@BillNo"].Value);
            Result[0] = Convert.ToInt32(cmd.Parameters["@ProcedureId"].Value);
            return Result;

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

    public object[] InsertProcedureMaster(BELOPDPatReg obj1)
    {
        object[] Result = new object[10];
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_InsertProcedureInfo", con);
        cmd.CommandType = CommandType.StoredProcedure;

        try
        {           
            cmd.Parameters.AddWithValue("@PatRegId", obj1.PatRegId);     
            cmd.Parameters.AddWithValue("@PatMainTypeId", obj1.PatMainTypeId);
            cmd.Parameters.AddWithValue("@PatientInsuTypeId", obj1.PatientInsuTypeId);
            cmd.Parameters.AddWithValue("@Details", obj1.Details);
            cmd.Parameters.AddWithValue("@AmountPaid", obj1.PaidAmt);            
            cmd.Parameters.AddWithValue("@DiscountAmt", obj1.DiscountAmt);
            cmd.Parameters.AddWithValue("@BillGroup", obj1.BillGroup);
            cmd.Parameters.AddWithValue("@BillAmount", obj1.BillAmount);
            cmd.Parameters.AddWithValue("@ReasonForDiscountId",obj1.ReasonForDiscountId);//("dd/MM/yyyy hh:MM:ss tt")
            cmd.Parameters.AddWithValue("@DiscountGivenById",obj1.DiscountGivenById);           
            cmd.Parameters.AddWithValue("@ReasonForBalanceId",obj1.ReasonForBalanceId);
            cmd.Parameters.AddWithValue("@InsuranceAmount", obj1.InsuranceAmount); 
            cmd.Parameters.AddWithValue("@BranchId", obj1.BranchId);
            cmd.Parameters.AddWithValue("@FId", obj1.FId); 
            cmd.Parameters.AddWithValue("@CreatedBy", obj1.CreatedBy);

            cmd.Parameters.AddWithValue("@OPDNo", obj1.OpdNo);
            cmd.Parameters.AddWithValue("@BillGroupId", obj1.BillGroupId);
            cmd.Parameters.AddWithValue("@InsuranceChargeCompamt", obj1.InsuranceChargeCompamt);

            cmd.Parameters.AddWithValue("@LetterNo", obj1.LetterNo);
            cmd.Parameters.AddWithValue("@TypeOfVisit", obj1.TypeOfVisit);
           


            cmd.Parameters.Add("@ProcedureId", SqlDbType.Int);
            cmd.Parameters.Add("@BillNo", SqlDbType.Int);
            cmd.Parameters["@ProcedureId"].Direction = ParameterDirection.Output;
            cmd.Parameters["@BillNo"].Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            Result[1] = Convert.ToInt32(cmd.Parameters["@BillNo"].Value);
            Result[0] = Convert.ToInt32(cmd.Parameters["@ProcedureId"].Value);
            return Result;

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

    public string UpdatePatientRegistration(BELOPDPatReg obj1)
    {
       
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_PatientRegistration_Update", con);
        cmd.CommandType = CommandType.StoredProcedure;

        try
        {
            cmd.Parameters.AddWithValue("@OpdNo", obj1.OpdNo);
            cmd.Parameters.AddWithValue("@RegistrationNo", obj1.RegistrationNo);
            cmd.Parameters.AddWithValue("@RegistrationTypeId", obj1.RegistrationTypeId);
            cmd.Parameters.AddWithValue("@RegistrationDateTime", obj1.RegistrationDateTime);
            cmd.Parameters.AddWithValue("@PatientInfoId", obj1.PatientInfoId);
            cmd.Parameters.AddWithValue("@HospitalId", obj1.HospitalId);
            cmd.Parameters.AddWithValue("@SectionId", obj1.SectionId);
            cmd.Parameters.AddWithValue("@KinName", obj1.KinName);
            cmd.Parameters.AddWithValue("@RelationOfKin", obj1.RelationOfKin);
            cmd.Parameters.AddWithValue("@PatientComplaint", obj1.PatientComplaint);
            cmd.Parameters.AddWithValue("@ShiftId", obj1.ShiftId);
            cmd.Parameters.AddWithValue("@ReferenceDrId", obj1.ReferenceDrId);
            cmd.Parameters.AddWithValue("@ReferenceDrText", obj1.ReferenceDrText);
            cmd.Parameters.AddWithValue("@RegistrationStatusId", obj1.RegistrationStatusId);
            cmd.Parameters.AddWithValue("@StatusChangeBy", obj1.EmployeeId);
            cmd.Parameters.AddWithValue("@StatusChangeReason", obj1.StatusChangeReason);
            cmd.Parameters.AddWithValue("@AdmissionType", obj1.AdmissionType);
            cmd.Parameters.AddWithValue("@MLCNo", obj1.AdmissionType);
            cmd.Parameters.AddWithValue("@UpdatedBy", obj1.UpdatedBy);

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

    public string DeletePatientRegistration(int OpdNo)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_PatientRegistration_Delete", con);
        cmd.CommandType = CommandType.StoredProcedure;

        try
        {
            cmd.Parameters.AddWithValue("@OpdNo", OpdNo);            
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

    public string GetMaxPatientRegistrationNo(string RegistrationType)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_GetMaxOpdRegNo", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@RegistrationType", RegistrationType);
            object Result = cmd.ExecuteScalar();
           if (Convert.ToString(Result).Equals(string.Empty))
            {
                Result = RegistrationType + "0";
            }
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

    public int GetMaxVisitingNo(BELOPDPatReg objBELOpdReg )
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_GetMaxVisitingNo", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@DrId", objBELOpdReg.DrId);
            cmd.Parameters.AddWithValue("@PatRegId", objBELOpdReg.PatRegId);
            object Result = cmd.ExecuteScalar();           
            return Convert.ToInt32(Result);
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
    public int GetTokenNo(BELOPDPatReg objBELOpdReg)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_GetMaxTokenNo", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@DrId", objBELOpdReg.DrId);
           // cmd.Parameters.AddWithValue("@PatRegId", objBELOpdReg.PatRegId);
            object Result = cmd.ExecuteScalar();
            return Convert.ToInt32(Result);
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

    public BELOPDPatReg GetPatientRegistrationByPatientId(int PatientInfoId)
    {
        BELOPDPatReg objBELOPDPatReg = new BELOPDPatReg();
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_PatientRegistration_SelectOne_ByPatientInfoId", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PatientInfoId", PatientInfoId);
        SqlDataReader sdr = cmd.ExecuteReader();        
        if (sdr.Read())
        {
            objBELOPDPatReg.OpdNo = Convert.ToInt32(sdr["OpdNo"]);
            objBELOPDPatReg.RegistrationNo = Convert.ToString(sdr["RegistrationNo"]);
            objBELOPDPatReg.RegistrationTypeId = Convert.ToInt32(sdr["RegistrationTypeId"]);
            objBELOPDPatReg.RegistrationDateTime = Convert.ToString(sdr["RegistrationDateTime"]);
            objBELOPDPatReg.PatientInfoId = Convert.ToInt32(sdr["PatientInfoId"]);
            objBELOPDPatReg.EmployeeName = Convert.ToString(sdr["EmployeeName"]);
            objBELOPDPatReg.HospitalId = Convert.ToInt32(sdr["HospitalId"]);
            objBELOPDPatReg.SectionId = Convert.ToInt32(sdr["SectionId"]);
            objBELOPDPatReg.KinName = Convert.ToString(sdr["KinName"]);
            objBELOPDPatReg.RelationOfKin = Convert.ToString(sdr["RelationOfKin"]);
            objBELOPDPatReg.PatientComplaint = Convert.ToString(sdr["PatientComplaint"]);
            objBELOPDPatReg.ShiftId = Convert.ToInt32(sdr["ShiftId"]);
            objBELOPDPatReg.ReferenceDrId = Convert.ToInt32(sdr["ReferenceDrId"]);
            objBELOPDPatReg.ReferenceDrText = Convert.ToString(sdr["ReferenceDrText"]);
            objBELOPDPatReg.IsActive = Convert.ToBoolean(sdr["IsActive"]);
            objBELOPDPatReg.CreatedBy = Convert.ToString(sdr["CreatedBy"]);
            objBELOPDPatReg.CreatedOn = Convert.ToDateTime(sdr["CreatedOn"]);
            objBELOPDPatReg.UpdatedBy = Convert.ToString(sdr["UpdatedBy"]);
            objBELOPDPatReg.UpdatedOn = Convert.ToDateTime(sdr["UpdatedOn"]);
        }
        con.Close();
        con.Dispose();
        return objBELOPDPatReg;
    }

    public string UpdatePatientRegistration(int OpdNo, string RegistrationTypeName, int StatusChangeBy, string StatusChangeReason)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_PatientRegistration_Update_CancleAddmission", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@OpdNo", OpdNo);
            cmd.Parameters.AddWithValue("@RegistrationTypeName", RegistrationTypeName);
            cmd.Parameters.AddWithValue("@StatusChangeBy", StatusChangeBy);
            cmd.Parameters.AddWithValue("@StatusChangeReason", StatusChangeReason);

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

   
    public DataSet FillBilltransactions(int PatRegId,int FId,int BillNo,int OpdNo)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_FillBillTransactions", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@OpdNo", OpdNo);
        cmd.Parameters.AddWithValue("@BillNo",BillNo);
        cmd.Parameters.AddWithValue("@PatRegId",PatRegId);
        cmd.Parameters.AddWithValue("@FId",FId);

        SqlDataAdapter da=new SqlDataAdapter(cmd);
        DataSet ds=new DataSet();
        try
        {
            da.Fill(ds);
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
            
            return ds;
    }

    public DataSet FillIPDBilltransactions(int PatRegId, int FId, int BillNo, int IpdNo)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_FillIPDBillTransactions", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@IpdNo", IpdNo);
        cmd.Parameters.AddWithValue("@BillNo", BillNo);
        cmd.Parameters.AddWithValue("@PatRegId", PatRegId);
        cmd.Parameters.AddWithValue("@FId", FId);

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds);
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

        return ds;
    }
    public DataSet Fill_MRC_IPDBilltransactions(int PatRegId, int FId, int BillNo, int IpdNo)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_MRC_FillIPDBillTransactions", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@IpdNo", IpdNo);
        cmd.Parameters.AddWithValue("@BillNo", BillNo);
        cmd.Parameters.AddWithValue("@PatRegId", PatRegId);
        cmd.Parameters.AddWithValue("@FId", FId);

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds);
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

        return ds;
    }


    public DataSet FillSearchGrid(object PatientType, object UserType, object UserId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_PatientSearch_FillGrid1", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PatientType", PatientType);
        cmd.Parameters.AddWithValue("@UserType", UserType);
        cmd.Parameters.AddWithValue("@UserId", UserId);

        SqlDataAdapter da=new SqlDataAdapter(cmd);
        DataSet ds=new DataSet();
        try
        {
            da.Fill(ds);
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
            
            return ds;
    }

   
    public object FillSearchGridSearchByPatientName(BELPatientInformation objBELPatInfo, BELOPDPatReg objBELOPDPatReg, string RegistrationType)
    {
        List<BELBillInfo> objBELBillInfos = new List<BELBillInfo>();

        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("SP_PatientRegistration_Search", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();

        cmd.Parameters.AddWithValue("@PatientName", objBELPatInfo.PatientName);
        cmd.Parameters.AddWithValue( "@LastName",objBELPatInfo.LastName);
        cmd.Parameters.AddWithValue( "@DoctorName",objBELOPDPatReg.ReferenceDrName);
        cmd.Parameters.AddWithValue( "@RegistrationNo",objBELOPDPatReg.RegistrationNo);
        cmd.Parameters.AddWithValue( "@PatRegId",objBELPatInfo.PatRegId);
        cmd.Parameters.AddWithValue( "@BarcodeId",objBELPatInfo.BarcodeId);
        cmd.Parameters.AddWithValue( "@ContactNo",objBELPatInfo.MobileNo);
        cmd.Parameters.AddWithValue( "@DepartmentName",objBELOPDPatReg.SectionName);
        cmd.Parameters.AddWithValue( "@RegistrationTypeName",RegistrationType);

        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            BELBillInfo objBELBillInfo = new BELBillInfo();

            objBELBillInfo.PatientRegistrationId = Convert.ToInt32(reader["PatientRegistrationId"]);
            objBELBillInfo.RegistrationNo = Convert.ToString(reader["RegistrationNo"]);
            objBELBillInfo.RegistrationDateTime = Convert.ToString(reader["RegistrationDateTime"]);
            objBELBillInfo.PatientName = Convert.ToString(reader["PatientName"]);
            objBELBillInfo.PatientComplaint = Convert.ToString(reader["PatientComplaint"]);
            objBELBillInfo.ReferenceDrName = Convert.ToString(reader["ReferenceDr"]);
            objBELBillInfo.Gender = Convert.ToString(reader["Gender"]);
            objBELBillInfo.Age = Convert.ToString(reader["Age"]);
            objBELBillInfo.ConsultantDrName = Convert.ToString(reader["ConsultantDr"]);
            objBELBillInfo.BedId = Convert.ToInt32(reader["BedId"]);
            objBELBillInfo.RoomBed = Convert.ToString(reader["RoomBed"]);
            objBELBillInfo.DrName = Convert.ToString(reader["DrName"]);
            objBELBillInfo.PatientCategoryName = Convert.ToString(reader["PatientCategoryName"]);
            objBELBillInfo.StatusChangeReason = Convert.ToString(reader["StatusChangeReason"]);

            objBELBillInfos.Add(objBELBillInfo);
        }
        reader.Close();
        reader.Dispose();
        return objBELBillInfos;
    }

   
    
    public BELOPDPatReg getmaxRegistrationID(int PatientInfoId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("SP_PatientRegistration_maxGetId", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        cmd.Parameters.AddWithValue("@PatientInfoId", PatientInfoId);
        SqlDataReader reader = cmd.ExecuteReader();       
        if (reader.Read())
        {
            objBELOPDPatReg.OpdNo = Convert.ToInt32(reader["OpdNo"]);
        }
        con.Close();
        con.Dispose();
        return objBELOPDPatReg;
    }


    public BELOPDPatReg getPatientRegistrationNo(int OpdNo)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("SP_PatientRegistration_RegsNo", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        cmd.Parameters.AddWithValue("@OpdNo", OpdNo);
        SqlDataReader reader = cmd.ExecuteReader();    

       
        if (reader.Read())
        {
            objBELOPDPatReg.RegistrationNo = Convert.ToString(reader["RegistrationNo"]);
        }
        con.Close();
        con.Dispose();
        return objBELOPDPatReg;
    }

    public BELOPDPatReg SelectOne1(int OpdNo)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("SP_PatientRegistration_SelectOne", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        cmd.Parameters.AddWithValue("@OpdNo", OpdNo);
        SqlDataReader reader = cmd.ExecuteReader();    

        if (reader.Read())
        {
            objBELOPDPatReg.OpdNo = Convert.ToInt32(reader["OpdNo"]);
            objBELOPDPatReg.RegistrationNo = Convert.ToString(reader["RegistrationNo"]);
            objBELOPDPatReg.RegistrationTypeId = Convert.ToInt32(reader["RegistrationTypeId"]);
            objBELOPDPatReg.RegistrationDateTime = Convert.ToString(reader["RegistrationDateTime"]);
            objBELOPDPatReg.PatientInfoId = Convert.ToInt32(reader["PatientInfoId"]);
            objBELOPDPatReg.EmployeeName = Convert.ToString(reader["EmployeeName"]);
            objBELOPDPatReg.HospitalId = Convert.ToInt32(reader["HospitalId"]);
            objBELOPDPatReg.SectionId = Convert.ToInt32(reader["SectionId"]);
            objBELOPDPatReg.KinName = Convert.ToString(reader["KinName"]);
            objBELOPDPatReg.RelationOfKin = Convert.ToString(reader["RelationOfKin"]);
            objBELOPDPatReg.PatientComplaint = Convert.ToString(reader["PatientComplaint"]);
            objBELOPDPatReg.ShiftId = Convert.ToInt32(reader["ShiftId"]);
            objBELOPDPatReg.ReferenceDrId = Convert.ToInt32(reader["ReferenceDrId"]);
            objBELOPDPatReg.ReferenceDrText = Convert.ToString(reader["ReferenceDrText"]);
            objBELOPDPatReg.IsActive = Convert.ToBoolean(reader["IsActive"]);
            objBELOPDPatReg.CreatedBy = Convert.ToString(reader["CreatedBy"]);
            objBELOPDPatReg.CreatedOn = Convert.ToDateTime(reader["CreatedOn"]);
            objBELOPDPatReg.UpdatedBy = Convert.ToString(reader["UpdatedBy"]);
            objBELOPDPatReg.UpdatedOn = Convert.ToDateTime(reader["UpdatedOn"]);
        }
        reader.Close();
        reader.Dispose();
        return objBELOPDPatReg;
    }

    public object[] InsertBill(BELBillInfo objDoBill)
    {
        object[] Result = new object[10];
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("SP_Bill_Insert", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();

       // DbCommand objDBCommand = objDatabase.GetStoredProcCommand("SP_Bill_Insert");
       cmd.Parameters.AddWithValue("@BillNo",objDoBill.BillNo);
       cmd.Parameters.AddWithValue("@BillDate", objDoBill.BillDate.ToString("dd/MM/yyyy hh:mm:ss tt"));
       cmd.Parameters.AddWithValue("@PatientRegistrationId", objDoBill.PatientRegistrationId);
       cmd.Parameters.AddWithValue("@BillTotal",objDoBill.BillTotal);
       cmd.Parameters.AddWithValue("@ConcessionPercent",objDoBill.ConcessionPercent);
       cmd.Parameters.AddWithValue("@ConcessionAmount",objDoBill.ConcessionAmount);
       cmd.Parameters.AddWithValue("@TaxPercent",objDoBill.TaxPercent);
       cmd.Parameters.AddWithValue("@TaxAmount",objDoBill.TaxAmount);
       cmd.Parameters.AddWithValue("@FinalAmount", objDoBill.FinalAmount);
        //objDatabase.AddInParameter(objDBCommand, "@AmountInWord",objDoBill.AmountInWord);
       cmd.Parameters.AddWithValue("@CreatedBy", objDoBill.CreatedBy);
       cmd.Parameters.Add("@BillId", SqlDbType.Int);
       cmd.Parameters["@BillId"].Direction = ParameterDirection.Output;        
        Result[0] = cmd.ExecuteScalar();

        Result[1] = Convert.ToInt32(cmd.Parameters["@BillId"].Value);
        con.Close();
        con.Dispose();
        return Result;
    }
    public List<string> FillAllIPDPatient_New(string prefixtext)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_PatientInfo_FillAllIPDPatient_New", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@Search", prefixtext);
            List<string> PatientName = new List<string>();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                PatientName.Add(sdr["PatientName"].ToString());

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
    public List<string> FillAllIPDPatient(string prefixtext)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_PatientInfo_FillAllIPDPatient", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@Search", prefixtext);
            List<string> PatientName = new List<string>();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                PatientName.Add(sdr["PatientName"].ToString());

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
    public List<string> FillAllPatient(string prefixtext)
    {
        
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();        
        SqlCommand cmd = new SqlCommand("SP_PatientInfo_FillAllPatient", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@Search", prefixtext);            
            List<string> PatientName = new List<string>();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                PatientName.Add(sdr["PatientName"].ToString());

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

    public List<string> FillReferDrSec(string prefixtext)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_GetSecondReferalDr", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@Search", prefixtext);
            List<string> PatientName = new List<string>();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                PatientName.Add(sdr["DrNames"].ToString());

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

    public List<string> FillAllIPDPatient1(string prefixtext)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_PatientInfo_FillAllIPDPatient", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@Search", prefixtext);
            List<string> PatientName = new List<string>();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                PatientName.Add(sdr["PatientName"].ToString());

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
    public List<string> FillAllPatientSurgQuotation(string prefixtext)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_FillSurgQuotationPatientList", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@Search", prefixtext);
            List<string> PatientName = new List<string>();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                PatientName.Add(sdr["PatientName"].ToString());

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
    public BELBillService GetserviceInfo(int ServiceId)
    {
        BELBillService objBELPatInfo=new BELBillService();
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetGroupId", con);
        cmd.CommandType = CommandType.StoredProcedure;
        
        try
        {
            cmd.Parameters.AddWithValue("@ServiceId", ServiceId);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                objBELPatInfo.IsDirect = Convert.ToBoolean(reader["IsDirect"]);
                objBELPatInfo.Isdoc = Convert.ToBoolean(reader["Isdoc"]);
                objBELPatInfo.BillGroupId = Convert.ToInt32(reader["BillGroupId"]);
            }
         
           // object GroupId = cmd.ExecuteScalar();
            return objBELPatInfo;

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

    public List<string> FillService(string prefixtext)
    {
        
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();        
        SqlCommand cmd = new SqlCommand("SP_FillServicesForOPD", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@Search", prefixtext);
            List<string> ServiceName = new List<string>();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                ServiceName.Add(sdr["ServiceName"].ToString());

            }
            return ServiceName;
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
    public BELBillService GetDefaultGroup(int FId, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_GetGroupFoConsultation", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@BranchId",BranchId);
        cmd.Parameters.AddWithValue("@FId",FId);
        SqlDataReader sdr = cmd.ExecuteReader();
        while (sdr.Read())
        {

            objBELBillService.GroupName = Convert.ToString(sdr["GroupName"]);
            objBELBillService.BillGroupId = Convert.ToInt32(sdr["BillGroupId"]);
        }
        con.Close();
        con.Dispose();
        return objBELBillService;
    }
     public BELBillService GetDefaultService(int FId, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_GetServiceForOPDConsultation", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@BranchId",BranchId);
        cmd.Parameters.AddWithValue("@FId",FId);
        SqlDataReader sdr = cmd.ExecuteReader();
        while (sdr.Read())
        {

            objBELBillService.BillServiceId = Convert.ToInt32(sdr["BillServiceId"]);
            objBELBillService.ServiceName = Convert.ToString(sdr["ServiceName"]);
        }
        con.Close();
        con.Dispose();
        return objBELBillService;
    }
    public BELOPDPatReg GetPatientBillDetails(int PatRegId,int FId,int BillNo,int OpdNo)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_FillOpdPatientBillDetails", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@OpdNo", OpdNo);
        cmd.Parameters.AddWithValue("@BillNo",BillNo);
        cmd.Parameters.AddWithValue("@PatRegId",PatRegId);
        cmd.Parameters.AddWithValue("@FId",FId);
        SqlDataReader sdr = cmd.ExecuteReader();
        while (sdr.Read())
        {
            objBELOPDPatReg.PatientName = Convert.ToString(sdr["PatientName"]);
            objBELOPDPatReg.OpdNo = Convert.ToInt32(sdr["OpdNo"]);
            objBELOPDPatReg.PatRegId = Convert.ToInt32(sdr["PatRegId"]);
            objBELOPDPatReg.BillNo = Convert.ToInt32(sdr["BillNo"]);
            objBELOPDPatReg.EntryDate = Convert.ToString(sdr["EntryDate"]);
            objBELOPDPatReg.Gender = Convert.ToString(sdr["GenderName"]);
            objBELOPDPatReg.Age = Convert.ToString(sdr["Age"]);
            objBELOPDPatReg.MobileNo = Convert.ToString(sdr["MobileNo"]);
            objBELOPDPatReg.EmployeeName = Convert.ToString(sdr["Empname"]);
            objBELOPDPatReg.BillServiceCharges = Convert.ToDecimal(sdr["BillServiceCharges"]);
            objBELOPDPatReg.AdvanceAmt = Convert.ToDecimal(sdr["ReceivedAmount"]);
            objBELOPDPatReg.BalanceAmt = Convert.ToDecimal(sdr["BalanceAmt"]);
            objBELOPDPatReg.DiscountAmt = Convert.ToDecimal(sdr["DiscountAmt"]);
            objBELOPDPatReg.IsInsuranceFlag = Convert.ToBoolean(sdr["IsInsurance"]);
            objBELOPDPatReg.InsuranceAmount = Convert.ToDecimal(sdr["InsuranceAmount"]);
            objBELOPDPatReg.InsuranceCompId = Convert.ToInt32(sdr["InsuranceCompId"]);
        }
        con.Close();
        con.Dispose();
        return objBELOPDPatReg;
    }
    public BELOPDPatReg GetPatientIPDBillDetails(int PatRegId, int FId, int BillNo, int IpdNo)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_FillIPDPatientBillDetails", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@IpdNo", IpdNo);
        cmd.Parameters.AddWithValue("@BillNo", BillNo);
        cmd.Parameters.AddWithValue("@PatRegId", PatRegId);
        cmd.Parameters.AddWithValue("@FId", FId);
        SqlDataReader sdr = cmd.ExecuteReader();
        while (sdr.Read())
        {
            
            objBELOPDPatReg.BillServiceCharges = Convert.ToDecimal(sdr["BillAmount"]);
            objBELOPDPatReg.AdvanceAmt = Convert.ToDecimal(sdr["ReceivedAmount"]);
            objBELOPDPatReg.BalanceAmt = Convert.ToDecimal(sdr["Balance"]);
            objBELOPDPatReg.DiscountAmt = Convert.ToDecimal(sdr["DiscountAmt"]);
            //objBELOPDPatReg.IsInsuranceFlag = Convert.ToBoolean(sdr["IsInsurance"]);
            objBELOPDPatReg.InsuranceAmount = Convert.ToDecimal(sdr["InsuranceAmount"]);
            //objBELOPDPatReg.InsuranceCompId = Convert.ToInt32(sdr["InsuranceCompId"]);
        }
        con.Close();
        con.Dispose();
        return objBELOPDPatReg;
    }


    public BELOPDPatReg GetMRC_PatientIPDBillDetails1(int PatRegId, int FId, int BillNo, int IpdNo)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_FillMRC_IPDPatientBillDetails", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@IpdNo", IpdNo);
        cmd.Parameters.AddWithValue("@BillNo", BillNo);
        cmd.Parameters.AddWithValue("@PatRegId", PatRegId);
        cmd.Parameters.AddWithValue("@FId", FId);
        SqlDataReader sdr = cmd.ExecuteReader();
        while (sdr.Read())
        {

            objBELOPDPatReg.BillServiceCharges = Convert.ToDecimal(sdr["BalanceForward"]);
            //objBELOPDPatReg.AdvanceAmt = Convert.ToDecimal(sdr["ReceivedAmount"]);
            //objBELOPDPatReg.BalanceAmt = Convert.ToDecimal(sdr["Balance"]);
            //objBELOPDPatReg.DiscountAmt = Convert.ToDecimal(sdr["DiscountAmt"]);
            ////objBELOPDPatReg.IsInsuranceFlag = Convert.ToBoolean(sdr["IsInsurance"]);
            //objBELOPDPatReg.InsuranceAmount = Convert.ToDecimal(sdr["InsuranceAmount"]);
            ////objBELOPDPatReg.InsuranceCompId = Convert.ToInt32(sdr["InsuranceCompId"]);
        }
        con.Close();
        con.Dispose();
        return objBELOPDPatReg;
    }


    public BELOPDPatReg GetIPDBillMasterDetails(int PatRegId,int IpdId, int FId, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_FillIPDPatientBillMaster", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@IpdId", IpdId);
        cmd.Parameters.AddWithValue("@BranchId", BranchId);
        cmd.Parameters.AddWithValue("@PatRegId", PatRegId);
        cmd.Parameters.AddWithValue("@FId", FId);
        SqlDataReader sdr = cmd.ExecuteReader();
        while (sdr.Read())
        {
            
            objBELOPDPatReg.BillServiceCharges = Convert.ToDecimal(sdr["BillAmount"]);
            objBELOPDPatReg.AdvanceAmt = Convert.ToDecimal(sdr["AmountReceived"]);
            objBELOPDPatReg.InsuranceAmount = Convert.ToDecimal(sdr["InsuranceAmt"]);
            objBELOPDPatReg.DiscountAmt = Convert.ToDecimal(sdr["Discount"]);
            //objBELOPDPatReg.IsInsuranceFlag = Convert.ToBoolean(sdr["IsInsurance"]);
            //objBELOPDPatReg.InsuranceAmount = Convert.ToDecimal(sdr["InsuranceAmount"]);
            //objBELOPDPatReg.InsuranceCompId = Convert.ToInt32(sdr["InsuranceCompId"]);
        }
        con.Close();
        con.Dispose();
        return objBELOPDPatReg;
    }
    public string GetDeptId(int DrId, int BranchId, int FId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_GetDocWiseDept", con);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@DrId", DrId);
        cmd.Parameters.AddWithValue("@FId", FId);
        cmd.Parameters.AddWithValue("@BranchId", BranchId);

        //cmd.Parameters.AddWithValue("@DoctorId", obj1.DoctorId);

        object Result = cmd.ExecuteScalar();
        con.Close();
        con.Dispose();
        return Convert.ToString(Result);
    }
    public string GetDeptId_WithName(int DrId, int BranchId, int FId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_GetDocWiseDeptWithName", con);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@DrId", DrId);
        cmd.Parameters.AddWithValue("@FId", FId);
        cmd.Parameters.AddWithValue("@BranchId", BranchId);

        //cmd.Parameters.AddWithValue("@DoctorId", obj1.DoctorId);

        object Result = cmd.ExecuteScalar();
        con.Close();
        con.Dispose();
        return Convert.ToString(Result);
    }
    public List<string> FillAllChiefComplant(string prefixtext)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_GetChiefComplant", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@Search", prefixtext);
            List<string> PatientName = new List<string>();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                PatientName.Add(sdr["PatComplaint"].ToString());

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

    public List<string> FillSearchDiagnostics_New(string prefixtext)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_GetDiagnoName_New", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@Search", prefixtext);
            List<string> PatientName = new List<string>();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                PatientName.Add(sdr["DiagnoName"].ToString());

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

    public List<string> FillSearchDiagnostics(string prefixtext)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_GetDiagnoName", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@Search", prefixtext);
            List<string> PatientName = new List<string>();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                PatientName.Add(sdr["TrDiagnoName"].ToString());

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
    public List<string> FillAllDiagnosis(string prefixtext)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_GetAllDiagnosis", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@Search", prefixtext);
            List<string> PatientName = new List<string>();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                PatientName.Add(sdr["Disgnosis"].ToString());

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

    public List<string> FillAllConsultDoc(string prefixtext)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_GetAllConsultant", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@Search", prefixtext);
            List<string> PatientName = new List<string>();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                PatientName.Add(sdr["EmpName"].ToString());

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

    public List<string> FillSecondaryDoc(string prefixtext)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_GetAllConsultant", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@Search", prefixtext);
            List<string> PatientName = new List<string>();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                PatientName.Add(sdr["EmpName"].ToString());

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

    public List<string> FillAllDepartment(string prefixtext)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_GetAllDepartment", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@Search", prefixtext);
            List<string> PatientName = new List<string>();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                PatientName.Add(sdr["DeptName"].ToString());

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
    public List<string> FillAllRegisterPatient(string prefixtext)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_PatientInfo_FillAllRegisterPatient", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@Search", prefixtext);
            List<string> PatientName = new List<string>();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                PatientName.Add(sdr["PatientName"].ToString());

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
    public List<string> FillAllOPDPatient(string prefixtext)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_PatientInfo_FillAllOPDPatient", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@Search", prefixtext);
            List<string> PatientName = new List<string>();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                PatientName.Add(sdr["PatientName"].ToString());

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
    public List<string> FillAllProcedure(string prefixtext)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_GetallOperation", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@Search", prefixtext);
            List<string> PatientName = new List<string>();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                PatientName.Add(sdr["PatientName"].ToString());

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

    public List<string> FillAllInsuranceCompany(string prefixtext)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_GetallInsuranceCorpname", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@Search", prefixtext);
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

    public List<string> FillAllService(string prefixtext,string Type)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_FillTypeWiseIPDBillServices", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@ServiceType", Type);
            cmd.Parameters.AddWithValue("@Search", prefixtext);
            List<string> PatientName = new List<string>();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                PatientName.Add(sdr["ServiceName"].ToString());

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

    public List<string> FillAllService_ForQuotation(string prefixtext, string Type)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetQuotationForPatients", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@ServiceType", Type);
            cmd.Parameters.AddWithValue("@Search", prefixtext);
            List<string> PatientName = new List<string>();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                PatientName.Add(sdr["ServiceName"].ToString());

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

    public List<string> FillAllService_Procedure(string prefixtext, string Type)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_FillTypeWiseOPDBillServices", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@ServiceType", Type);
            cmd.Parameters.AddWithValue("@Search", prefixtext);
            List<string> PatientName = new List<string>();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                PatientName.Add(sdr["ServiceName"].ToString());

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
    public string InsertUpdate_Insurance_Charges(int Patregid, int IpdNo, int OpdNo, int Sponsor1id, float Sponsar1Amt, int Sponsor2id, float Sponsar2Amt,string SponsorStatus,  int Branchid, string CreatedBy,int FID)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("SP_InsertInsurancePayment", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {
            cmd.Parameters.AddWithValue("@PatRegId", Patregid);
            cmd.Parameters.AddWithValue("@IPDNo", IpdNo);
            cmd.Parameters.AddWithValue("@OPDNo", OpdNo);
            cmd.Parameters.AddWithValue("@Sponsor1", Sponsor1id);
            cmd.Parameters.AddWithValue("@Sponsor1Amt", Sponsar1Amt);
            cmd.Parameters.AddWithValue("@Sponsor2", Sponsor2id);
            cmd.Parameters.AddWithValue("@Sponsor2Amt", Sponsar2Amt);
            cmd.Parameters.AddWithValue("@SponsorStatus", SponsorStatus);
            cmd.Parameters.AddWithValue("@Branchid", Branchid);
            cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);           
            cmd.Parameters.AddWithValue("@FID", FID);  

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

    public object[] GenerateInvoice(int InsuranceCompId, string FromDate, string ToDate, int FId, int BranchId, string username)
    {
        object[] Result = new object[10];
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_Vw_InsuranceBillAmountTotal", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {
            cmd.Parameters.AddWithValue("@FromDate", FromDate);
            cmd.Parameters.AddWithValue("@ToDate", ToDate);
            cmd.Parameters.AddWithValue("@InsuranceCompId", InsuranceCompId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.Parameters.AddWithValue("@CreatedBy", username);
            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.Add("@InvoiceNo1",SqlDbType.Int);            
            cmd.Parameters["@InvoiceNo1"].Direction = ParameterDirection.Output;
            Result[0] = cmd.ExecuteScalar();
            Result[1] = Convert.ToInt32(cmd.Parameters["@InvoiceNo1"].Value);

            return Result;
            // object Result = cmd.ExecuteScalar();
            // return Convert.ToString(Result);
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

    public DataTable FillInvoiceDetails( int InsuranceCompId, string FromDate, string ToDate, int FId, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_SelectPatientInvoiceDatails", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@FromDate", FromDate);
        cmd.Parameters.AddWithValue("@ToDate", ToDate);
        cmd.Parameters.AddWithValue("@InsuranceCompId", InsuranceCompId);
        cmd.Parameters.AddWithValue("@BranchId", BranchId);
       
        cmd.Parameters.AddWithValue("@FId", FId);

        SqlDataAdapter da=new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        try
        {
            da.Fill(dt);
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

        return dt;
    }


    public void InserInvoiceDetails(int InvoiceNo, int InsuranceCompId,int PatRegId,int IpdNo,float BillAmount, int FId, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_InsertPatientInvoiceDatails", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {
            cmd.Parameters.AddWithValue("@PatRegId", PatRegId);
            cmd.Parameters.AddWithValue("@IpdNo", IpdNo);
            cmd.Parameters.AddWithValue("@BillAmount", BillAmount);
            cmd.Parameters.AddWithValue("@InsuranceCompId", InsuranceCompId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.Parameters.AddWithValue("@InvoiceNo", InvoiceNo);
            cmd.Parameters.AddWithValue("@FId", FId);
            
            cmd.ExecuteNonQuery();
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
    public DataSet fillInvoiceGrid(int InsuranceId,string FromDate, string ToDate,int FId,int BranchId,string flag)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_FillInsuranceCompInvoice", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@InsuranceId", InsuranceId);
        cmd.Parameters.AddWithValue("@FromDate", FromDate);
        cmd.Parameters.AddWithValue("@ToDate", ToDate);
        cmd.Parameters.AddWithValue("@FId", FId);
        cmd.Parameters.AddWithValue("@BranchId", BranchId);
        cmd.Parameters.AddWithValue("@flag", flag);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds);
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

        return ds;
    }
    public List<string> FillAllInsurance(string prefixtext)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_FillAllInsurance_corporate", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@Search", prefixtext);
            List<string> PatientSubCategory = new List<string>();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                PatientSubCategory.Add(sdr["PatientSubCategory"].ToString());

            }
            return PatientSubCategory;
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

    public List<string> FillAllSurgan(string prefixtext)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_GetAllSurganName", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@Search", prefixtext);
            List<string> PatientName = new List<string>();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                PatientName.Add(sdr["DoctorName"].ToString());

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

    public List<string> FillAllSurgan_Quotation(string prefixtext)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_GetSurganName_Quotation", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@Search", prefixtext);
            List<string> PatientName = new List<string>();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                PatientName.Add(sdr["DoctorName"].ToString());

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

    public List<string> FillAllAnaesthetist(string prefixtext)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_GetAllANAESTHESIA", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@Search", prefixtext);
            List<string> PatientName = new List<string>();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                PatientName.Add(sdr["DoctorName"].ToString());

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
    
     public List<string> FillAssistanceForOperation(string prefixtext)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_GetAssistantForOperation", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@Search", prefixtext);
            List<string> PatientName = new List<string>();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                PatientName.Add(sdr["DoctorName"].ToString());

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

    public List<string> FillAll1Assists(string prefixtext)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_GetAll1Assistant", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@Search", prefixtext);
            List<string> PatientName = new List<string>();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                PatientName.Add(sdr["DoctorName"].ToString());

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

   public DataTable GetInsurancePaymentReceiptNo(int Sponser,int FId, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetInsuranceReceiptNo", con);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@Sponser", Sponser);
        cmd.Parameters.AddWithValue("@BranchId", BranchId);
       
        cmd.Parameters.AddWithValue("@FId", FId);
       

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable ds = new DataTable();
        da.Fill(ds);
        con.Close();
        con.Dispose();
        return ds;
    }
    public BELOPDPatReg GetInsurancePaymentDetails(int Sponser,int FId,int BranchId)
    {
        BELOPDPatReg obj1 =new BELOPDPatReg();
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetInsuranceTransaction", con);
        cmd.CommandType = CommandType.StoredProcedure;
        
        try
        {
            cmd.Parameters.AddWithValue("@Sponser", Sponser);
            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                obj1.InsuranceAmount = Convert.ToDecimal(reader["InsuranceBillAmount"]);
                obj1.BalanceAmt = Convert.ToDecimal(reader["Balance"]);
               obj1.PaidAmt = Convert.ToDecimal(reader["AmountPaid"]);
            }
         
           // object GroupId = cmd.ExecuteScalar();
            return obj1;

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
    public string InsertInsurancePaymentTransaction(int InsuranceId, string TransactionType,string PaymentMode,string BankName,string ChequeDate,string chequeNo,float AmountGiven,int FId,int BranchId,string username)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_InsertInsurancePaymentTransaction", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {

            cmd.Parameters.AddWithValue("@Sponser", InsuranceId);
            cmd.Parameters.AddWithValue("@PaymentMode", PaymentMode);
            cmd.Parameters.AddWithValue("@CreditAmount", AmountGiven);
            cmd.Parameters.AddWithValue("@ChequeNo", chequeNo);
            cmd.Parameters.AddWithValue("@BankName", BankName);
            cmd.Parameters.AddWithValue("@TransactionType", TransactionType);
             cmd.Parameters.AddWithValue("@BranchId", BranchId);
             cmd.Parameters.AddWithValue("@ChequeDate", ChequeDate);
            cmd.Parameters.AddWithValue("@FId", FId);
             cmd.Parameters.AddWithValue("@CreatedBy", username);

             object result = cmd.ExecuteScalar();
             return Convert.ToString(result);

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


    //public List<string> FillAllSurgan(string prefixtext)
    //{

    //    SqlConnection con = DataAccess.ConInitForDC();
    //    con.Open();
    //    SqlCommand cmd = new SqlCommand("SP_GetAllSurganName", con);
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    try
    //    {
    //        cmd.Parameters.AddWithValue("@Search", prefixtext);
    //        List<string> PatientName = new List<string>();
    //        SqlDataReader sdr = cmd.ExecuteReader();
    //        while (sdr.Read())
    //        {
    //            PatientName.Add(sdr["DoctorName"].ToString());

    //        }
    //        return PatientName;
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

    //public List<string> FillAllAnaesthetist(string prefixtext)
    //{

    //    SqlConnection con = DataAccess.ConInitForDC();
    //    con.Open();
    //    SqlCommand cmd = new SqlCommand("SP_GetAllANAESTHESIA", con);
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    try
    //    {
    //        cmd.Parameters.AddWithValue("@Search", prefixtext);
    //        List<string> PatientName = new List<string>();
    //        SqlDataReader sdr = cmd.ExecuteReader();
    //        while (sdr.Read())
    //        {
    //            PatientName.Add(sdr["DoctorName"].ToString());

    //        }
    //        return PatientName;
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

    //public List<string> FillAll1Assists(string prefixtext)
    //{

    //    SqlConnection con = DataAccess.ConInitForDC();
    //    con.Open();
    //    SqlCommand cmd = new SqlCommand("SP_GetAll1Assistant", con);
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    try
    //    {
    //        cmd.Parameters.AddWithValue("@Search", prefixtext);
    //        List<string> PatientName = new List<string>();
    //        SqlDataReader sdr = cmd.ExecuteReader();
    //        while (sdr.Read())
    //        {
    //            PatientName.Add(sdr["DoctorName"].ToString());

    //        }
    //        return PatientName;
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

    public List<string> FillAllDisease_search(string prefixtext, string Type)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_GetAllDisease_Search", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@Search", prefixtext);
            cmd.Parameters.AddWithValue("@Type", Type);
            List<string> PatientName = new List<string>();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                PatientName.Add(sdr["DiseaseName"].ToString());

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

    public List<string> FillAllDisease(string prefixtext,string Type)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_GetAllDisease", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@Search", prefixtext);
            cmd.Parameters.AddWithValue("@Type", Type);
            List<string> PatientName = new List<string>();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                PatientName.Add(sdr["DiseaseName"].ToString());

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
    public List<string> FillAllOperation_Search(string prefixtext, string Type)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_GetAllOperationNameSearch", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@Search", prefixtext);
            cmd.Parameters.AddWithValue("@Type", Type);
            List<string> PatientName = new List<string>();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                PatientName.Add(sdr["OperationName"].ToString());

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
   
    public List<string> FillAllOperation_Quotation(string prefixtext)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_GetAllOperationName_Quotation", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@Search", prefixtext);
            
            List<string> PatientName = new List<string>();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                PatientName.Add(sdr["OperationName"].ToString());

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

    public List<string> FillAllOperation(string prefixtext,string Type)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_GetAllOperationName", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@Search", prefixtext);
            cmd.Parameters.AddWithValue("@Type", Type);
            List<string> PatientName = new List<string>();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                PatientName.Add(sdr["OperationName"].ToString());

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
    public List<string> FillAllOpthoOTService(string prefixtext, string Type)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_FillOpthoOTService", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@ServiceType", Type);
            cmd.Parameters.AddWithValue("@Search", prefixtext);
            List<string> PatientName = new List<string>();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                PatientName.Add(sdr["ServiceName"].ToString());

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
    public List<string> FillAllGeneralOTService(string prefixtext, string Type)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_FillGeneralOTService", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@ServiceType", Type);
            cmd.Parameters.AddWithValue("@Search", prefixtext);
            List<string> PatientName = new List<string>();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                PatientName.Add(sdr["ServiceName"].ToString());

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


    public List<string> FillAllGeneralNurseService(string prefixtext, string Type)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_FillGeneralNurseService", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@ServiceType", Type);
            cmd.Parameters.AddWithValue("@Search", prefixtext);
            List<string> PatientName = new List<string>();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                PatientName.Add(sdr["ServiceName"].ToString());

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

    public void InserProcedureBillTransaction(BELBillInfo obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_ProcedureBillTransaction", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {
            cmd.Parameters.AddWithValue("@PatRegId", obj.PatRegId);            
            cmd.Parameters.AddWithValue("@BillNo",obj.BillNo);    
            cmd.Parameters.AddWithValue("@ReceivedAmount",obj.AmountPaid);    
            cmd.Parameters.AddWithValue("@PaymentMode",obj.PaymentType);
            cmd.Parameters.AddWithValue("@CardChequeNo",obj.ChequeCardNo);
           // cmd.Parameters.AddWithValue("@ChequeDate",obj.ChequeDate);
            if (obj.ChequeDate != null)
            {
                cmd.Parameters.AddWithValue("@ChequeDate", DateTime.ParseExact(obj.ChequeDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            cmd.Parameters.AddWithValue("@BankName",obj.BankName);
	        cmd.Parameters.AddWithValue("@ProcedureId",obj.ProcedureId);
	        cmd.Parameters.AddWithValue("@BillGroup",obj.BillGroup);
	        cmd.Parameters.AddWithValue("@CreatedBy",obj.CreatedBy);
	        cmd.Parameters.AddWithValue("@FId",obj.FId);
            cmd.Parameters.AddWithValue("@BranchId",obj.BranchId);
            

            cmd.ExecuteNonQuery();
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

    public DataTable FillProcedurePatientList(string FromDate, string ToDate, int PatRegId, int FId, int BranchId,string BillGroup,string UserName,string BillNo)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_ProcedurePatientList", con);
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

            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);           
            cmd.Parameters.AddWithValue("@PatRegId", PatRegId);
            cmd.Parameters.AddWithValue("@BillGroup", BillGroup);
            cmd.Parameters.AddWithValue("@UserName",UserName );
            cmd.Parameters.AddWithValue("@BillNo", BillNo);


            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
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


    public DataTable FillQuotationPatientList(string FromDate, string ToDate,  int FId, int BranchId, string BillGroup,  string BillNo)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_QuotationBillMaster", con);
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

            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
           
            cmd.Parameters.AddWithValue("@BillGroup", BillGroup);
          
            cmd.Parameters.AddWithValue("@BillNo", BillNo);


            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
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

    public DataTable FillCancelProcedurePatientList(string FromDate, string ToDate, int PatRegId, int FId, int BranchId, string BillGroup)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_CancelProcedurePatientList", con);
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

            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.Parameters.AddWithValue("@PatRegId", PatRegId);
            cmd.Parameters.AddWithValue("@BillGroup", BillGroup);


            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
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


    public void CancelProcedureBillTransaction(BELBillInfo obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_CancelProcedureBill", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {
            cmd.Parameters.AddWithValue("@PatRegId", obj.PatRegId);
            cmd.Parameters.AddWithValue("@BillNo", obj.BillNo);
          
            cmd.Parameters.AddWithValue("@ProcedureId", obj.ProcedureId);
            cmd.Parameters.AddWithValue("@BillGroup", obj.BillGroup);            
            cmd.Parameters.AddWithValue("@FId", obj.FId);
            cmd.Parameters.AddWithValue("@BranchId", obj.BranchId);
            cmd.Parameters.AddWithValue("@CreatedBy", obj.CreatedBy);


            cmd.ExecuteNonQuery();
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

    public object[] InsertEMR_LabPatientRegistration(BELOPDPatReg obj1)
    {
        object[] Result = new object[10];
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_InsertEMRLabRegistration", con);
        cmd.CommandType = CommandType.StoredProcedure;

        try
        {

            // cmd.Parameters.AddWithValue("@RegistrationType", obj1.RegistrationTypeName);
            // cmd.Parameters.AddWithValue("@EntryDate",obj1.EntryDate);
            cmd.Parameters.AddWithValue("@PatRegId", obj1.PatRegId);
            cmd.Parameters.AddWithValue("@BranchId", obj1.BranchId);
            cmd.Parameters.AddWithValue("@FId", obj1.FId);
            cmd.Parameters.AddWithValue("@VisitingNo", obj1.VisitingNo);
            cmd.Parameters.AddWithValue("@TokenNo", obj1.TokenNo);
            cmd.Parameters.AddWithValue("@DrId", obj1.DrId);
            cmd.Parameters.AddWithValue("@PatientComplaints", obj1.PatientComplaint);
            cmd.Parameters.AddWithValue("@PatMainTypeId", obj1.PatMainTypeId);
            cmd.Parameters.AddWithValue("@PatientInsuTypeId", obj1.PatientInsuTypeId);
            //cmd.Parameters.AddWithValue("@Shift",obj1.ShiftName);         
            // cmd.Parameters.AddWithValue("@ReferenceDrText",obj1.ReferenceDrText);
            cmd.Parameters.AddWithValue("@ReferenceDoc", obj1.ReferenceDrName);
            cmd.Parameters.AddWithValue("@CreatedBy", obj1.CreatedBy);
            cmd.Parameters.AddWithValue("@DeptId", obj1.DeptId);
            cmd.Parameters.AddWithValue("@ReferBy", obj1.ReferBy);
            cmd.Parameters.AddWithValue("@LabPtype", obj1.LabPtype);
            cmd.Parameters.AddWithValue("@MainDoctor", obj1.MainDoctor);
            cmd.Parameters.AddWithValue("@OPDNO", obj1.OpdNo);
            cmd.Parameters.AddWithValue("@IPDNO", obj1.IpdNo);
            cmd.Parameters.AddWithValue("@ClinicalHistory", obj1.ClinicalHistory);
            cmd.Parameters.AddWithValue("@WardName", obj1.WardName);
            cmd.Parameters.AddWithValue("@Isemergency", obj1.IsEmergency);
            cmd.Parameters.AddWithValue("@VerbalBy", obj1.VerbalBy);
            cmd.Parameters.AddWithValue("@VerbalOn", obj1.VerbalOn);
            cmd.Parameters.AddWithValue("@OrderBy", obj1.OrderBy);
            cmd.Parameters.Add("@LabNo", SqlDbType.Int);
            cmd.Parameters["@LabNo"].Direction = ParameterDirection.Output;
            // Result[1] =  
            cmd.ExecuteNonQuery();
            Result[0] = Convert.ToInt32(cmd.Parameters["@LabNo"].Value);
            return Result;


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

    public object[] InsertEMR_LabPatientRegistration_ReferToAdmission(BELOPDPatReg obj1)
    {
        object[] Result = new object[10];
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_InsertEMRLabRegistration_ReferToAdmission", con);
        cmd.CommandType = CommandType.StoredProcedure;

        try
        {

            // cmd.Parameters.AddWithValue("@RegistrationType", obj1.RegistrationTypeName);
            // cmd.Parameters.AddWithValue("@EntryDate",obj1.EntryDate);
            cmd.Parameters.AddWithValue("@PatRegId", obj1.PatRegId);
            cmd.Parameters.AddWithValue("@BranchId", obj1.BranchId);
            cmd.Parameters.AddWithValue("@FId", obj1.FId);
            cmd.Parameters.AddWithValue("@VisitingNo", obj1.VisitingNo);
            cmd.Parameters.AddWithValue("@TokenNo", obj1.TokenNo);
            cmd.Parameters.AddWithValue("@DrId", obj1.DrId);
            cmd.Parameters.AddWithValue("@PatientComplaints", obj1.PatientComplaint);
            cmd.Parameters.AddWithValue("@PatMainTypeId", obj1.PatMainTypeId);
            cmd.Parameters.AddWithValue("@PatientInsuTypeId", obj1.PatientInsuTypeId);
            //cmd.Parameters.AddWithValue("@Shift",obj1.ShiftName);         
            // cmd.Parameters.AddWithValue("@ReferenceDrText",obj1.ReferenceDrText);
            cmd.Parameters.AddWithValue("@ReferenceDoc", obj1.ReferenceDrName);
            cmd.Parameters.AddWithValue("@CreatedBy", obj1.CreatedBy);
            cmd.Parameters.AddWithValue("@DeptId", obj1.DeptId);
            cmd.Parameters.AddWithValue("@ReferBy", obj1.ReferBy);
            cmd.Parameters.AddWithValue("@LabPtype", obj1.LabPtype);
            cmd.Parameters.AddWithValue("@MainDoctor", obj1.MainDoctor);
            cmd.Parameters.AddWithValue("@OPDNO", obj1.OpdNo);
            cmd.Parameters.AddWithValue("@IPDNO", obj1.IpdNo);
            cmd.Parameters.AddWithValue("@ClinicalHistory", obj1.ClinicalHistory);
            cmd.Parameters.AddWithValue("@WardName", obj1.WardName);
            cmd.Parameters.AddWithValue("@Isemergency", obj1.IsEmergency);
            cmd.Parameters.Add("@LabNo", SqlDbType.Int);
            cmd.Parameters["@LabNo"].Direction = ParameterDirection.Output;
            // Result[1] =  
            cmd.ExecuteNonQuery();
            Result[0] = Convert.ToInt32(cmd.Parameters["@LabNo"].Value);
            return Result;


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



    public string Update_EMRTest(int LabNo, string Patregid, int Branchid)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_updateEMR_Test", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@LabNo", LabNo);
            cmd.Parameters.AddWithValue("@Patregid", Patregid);
            cmd.Parameters.AddWithValue("@Branchid", Branchid);
          

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

    public string Update_BillBy(int LabNo, string Patregid, int Branchid, string LabPType, string CreatedBy)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_UpdateLabBilledBy", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            cmd.Parameters.AddWithValue("@LabNo", LabNo);
            cmd.Parameters.AddWithValue("@Patregid", Patregid);
            cmd.Parameters.AddWithValue("@Branchid", Branchid);
            cmd.Parameters.AddWithValue("@LabPType", LabPType);

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

    public List<string> FillAllCathoOTService(string prefixtext, string Type)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_FillCathoOTService", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@ServiceType", Type);
            cmd.Parameters.AddWithValue("@Search", prefixtext);
            List<string> PatientName = new List<string>();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                PatientName.Add(sdr["ServiceName"].ToString());

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

    public DataSet FillRoomType()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("Sp_GetRoomType", con);

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

    public DataTable Get_LabRegisterNo(string PType,string HmsRegNo)
    {
        DataTable ds = new DataTable();
        SqlConnection con = new SqlConnection();
        if (PType != "")
        {
            if (PType == "1")
            {
                con = DataAccess.ConInitForPathology();
            }
            if (PType == "2")
            {
                con = DataAccess.ConInitForRadiology();
            }
            if (PType == "3")
            {
                con = DataAccess.ConInitForMedical();
            }
            if (PType == "4")
            {
                con = DataAccess.ConInitForCardiology();
            }

            con.Open();
            //SqlDataAdapter sda = new SqlDataAdapter(" select top(20) RoutinTestCode,RoutinTestCode+' - '+ RoutinTestName as Maintestname from RoutinTest  ", con);
            SqlDataAdapter sda = new SqlDataAdapter(" select top(1) * from patmst where ppid='" + HmsRegNo + "' order by 1 desc ", con);


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
        }
        return ds;
    }


    public DataTable GetSMSString_CountryCode_Covid(string SubjString, int branchid,string PType)
    {
        DataAccess data = new DataAccess();
        SqlConnection con = new SqlConnection();
        if (PType == "1")
        {
            con = DataAccess.ConInitForPathology();
        }
        if (PType == "2")
        {
            con = DataAccess.ConInitForRadiology();
        }
        if (PType == "3")
        {
            con = DataAccess.ConInitForMedical();
        }
        if (PType == "4")
        {
            con = DataAccess.ConInitForCardiology();
        }
       // SqlConnection conn = data.ConInitForDC1();
        SqlCommand sc = new SqlCommand("SP_GetCountryCode_Covid", con);



        sc.Parameters.Add(new SqlParameter("@branchid", SqlDbType.NVarChar, 50)).Value = branchid;
        sc.Parameters.Add(new SqlParameter("@SubjString", SqlDbType.NVarChar, 550)).Value = SubjString;

        sc.CommandType = CommandType.StoredProcedure;

        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = sc;

        try
        {
            con.Open();
            DataTable ds = new DataTable();
            da.Fill(ds);
            return ds;

        }
        finally
        {

            con.Close(); con.Dispose();

        }

    }


    public decimal GetSurgeryDepositAmount(int PatRegId, int FId, int BranchId,int IpdNo)
    {
        object Result;
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetSurgeryDepositAmt", con);
        cmd.CommandType = CommandType.StoredProcedure;

        try
        {
            cmd.Parameters.AddWithValue("@PatRegId", PatRegId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@IPDNo", IpdNo);
            Result = cmd.ExecuteScalar();
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
        return Convert.ToDecimal(Result);


    }


    public string UpdateRadiologyPatient_Details(BELOPDPatReg obj1)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_Update_RadiologyLabRegistration", con);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@BillNo", obj1.BillNo);
        cmd.Parameters.AddWithValue("@Patregid", obj1.PatRegId);

        cmd.Parameters.AddWithValue("@BranchId", obj1.BranchId);
        cmd.Parameters.AddWithValue("@LabNo", obj1.LabNo);
        cmd.Parameters.AddWithValue("@PatMainTypeId", obj1.PatMainTypeId);
        cmd.Parameters.AddWithValue("@PatientInsuTypeId", obj1.PatientInsuTypeId);
        //==========================





        object Result = cmd.ExecuteScalar();
        con.Close();
        con.Dispose();
        return Convert.ToString(Result);
    }


    public List<string> FillAllSubChargeCategoryName(string prefixtext, string PatientCategoryID)
    {

        SqlConnection con = DataAccess.ConInitForDC();
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

    public List<string> FillAllEmployee(string prefixtext)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_GetAllEmployees", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@Search", prefixtext);
            List<string> PatientName = new List<string>();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                PatientName.Add(sdr["Empname"].ToString());

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

    //----------------------------------------------

    public object[] GenerateInvoice_OPD(int InsuranceCompId, string FromDate, string ToDate, int FId, int BranchId, string username)
    {
        object[] Result = new object[10];
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_InsuranceBillAmountTotal_OPD", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {
            cmd.Parameters.AddWithValue("@FromDate", FromDate);
            cmd.Parameters.AddWithValue("@ToDate", ToDate);
            cmd.Parameters.AddWithValue("@InsuranceCompId", InsuranceCompId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.Parameters.AddWithValue("@CreatedBy", username);
            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.Add("@InvoiceNo1", SqlDbType.Int);
            cmd.Parameters["@InvoiceNo1"].Direction = ParameterDirection.Output;
            Result[0] = cmd.ExecuteScalar();
            Result[1] = Convert.ToInt32(cmd.Parameters["@InvoiceNo1"].Value);

            return Result;
            // object Result = cmd.ExecuteScalar();
            // return Convert.ToString(Result);
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

    public object[] GenerateInvoice_OPD_Amount1(int InsuranceCompId, string FromDate, string ToDate, int FId, int BranchId, string username, int InvoiceNo)
    {
        object[] Result = new object[10];
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_InsuranceBillAmountTotal_OPD_Amount", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {
            cmd.Parameters.AddWithValue("@InvoiceNo", InvoiceNo);
            cmd.Parameters.AddWithValue("@FromDate", FromDate);
            cmd.Parameters.AddWithValue("@ToDate", ToDate);
            cmd.Parameters.AddWithValue("@InsuranceCompId", InsuranceCompId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.Parameters.AddWithValue("@CreatedBy", username);
            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.Add("@InvoiceNo1", SqlDbType.Int);
            cmd.Parameters["@InvoiceNo1"].Direction = ParameterDirection.Output;
            Result[0] = cmd.ExecuteScalar();
            Result[1] = Convert.ToInt32(cmd.Parameters["@InvoiceNo1"].Value);

            return Result;
            // object Result = cmd.ExecuteScalar();
            // return Convert.ToString(Result);
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
    public string GenerateInvoice_OPD_Amount(int InsuranceCompId, string FromDate, string ToDate, int FId, int BranchId, string username, int InvoiceNo)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_InsuranceBillAmountTotal_OPD_Amount", con);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@InvoiceNo", InvoiceNo);
        cmd.Parameters.AddWithValue("@FromDate", FromDate);
        cmd.Parameters.AddWithValue("@ToDate", ToDate);
        cmd.Parameters.AddWithValue("@InsuranceCompId", InsuranceCompId);
        cmd.Parameters.AddWithValue("@BranchId", BranchId);
        cmd.Parameters.AddWithValue("@CreatedBy", username);
        cmd.Parameters.AddWithValue("@FId", FId);
        //==========================





        object Result = cmd.ExecuteScalar();
        con.Close();
        con.Dispose();
        return Convert.ToString(Result);
    }

    public DataTable FillInvoiceDetails_OPD(int InsuranceCompId, string FromDate, string ToDate, int FId, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_FillInsuranceCompInvoice_ForOPD", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@FromDate", FromDate);
        cmd.Parameters.AddWithValue("@ToDate", ToDate);
        cmd.Parameters.AddWithValue("@InsuranceCompId", InsuranceCompId);
        cmd.Parameters.AddWithValue("@BranchId", BranchId);

        cmd.Parameters.AddWithValue("@FId", FId);

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        try
        {
            da.Fill(dt);
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

        return dt;
    }

    public void InserInvoiceDetails_OPD(int InvoiceNo, int InsuranceCompId, int PatRegId, string ChargeNo, float BillAmount, int FId, int BranchId, string ReceivedBy, string ChargeYear, string ChargeMonth)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_InsertPatientInvoiceDatails_ForOPD", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {
            cmd.Parameters.AddWithValue("@PatRegId", PatRegId);
            cmd.Parameters.AddWithValue("@ChargeNo", ChargeNo);
            cmd.Parameters.AddWithValue("@BillAmount", BillAmount);
            cmd.Parameters.AddWithValue("@InsuranceCompId", InsuranceCompId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.Parameters.AddWithValue("@InvoiceNo", InvoiceNo);
            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@ReceivedBy", ReceivedBy);
            cmd.Parameters.AddWithValue("@ChargeYear", ChargeYear);
            cmd.Parameters.AddWithValue("@ChargeMonth", ChargeMonth);

            cmd.ExecuteNonQuery();
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


    public DataSet fillInvoiceGrid_ForOPD(int InsuranceId, string FromDate, string ToDate, int FId, int BranchId, string flag)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GenerateCompanyInvoice_ForOPD", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@InsuranceId", InsuranceId);
        cmd.Parameters.AddWithValue("@FromDate", FromDate);
        cmd.Parameters.AddWithValue("@ToDate", ToDate);
        cmd.Parameters.AddWithValue("@FId", FId);
        cmd.Parameters.AddWithValue("@BranchId", BranchId);
        cmd.Parameters.AddWithValue("@flag", flag);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds);
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

        return ds;
    }


    public BELOPDPatReg GetInsurancePaymentDetails_ForOPD(int Sponser, int FId, int BranchId)
    {
        BELOPDPatReg obj1 = new BELOPDPatReg();
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetInsuranceTransaction_ForOPD", con);
        cmd.CommandType = CommandType.StoredProcedure;

        try
        {
            cmd.Parameters.AddWithValue("@Sponser", Sponser);
            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                obj1.InsuranceAmount = Convert.ToDecimal(reader["InsuranceBillAmount"]);
                obj1.BalanceAmt = Convert.ToDecimal(reader["Balance"]);
                obj1.PaidAmt = Convert.ToDecimal(reader["AmountPaid"]);
            }

            // object GroupId = cmd.ExecuteScalar();
            return obj1;

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

    public DataTable GetInsurancePaymentReceiptNo_ForOPD(int Sponser, int FId, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetInsuranceReceiptNo_ForOPD", con);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@Sponser", Sponser);
        cmd.Parameters.AddWithValue("@BranchId", BranchId);

        cmd.Parameters.AddWithValue("@FId", FId);


        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable ds = new DataTable();
        da.Fill(ds);
        con.Close();
        con.Dispose();
        return ds;
    }

    public string InsertInsurancePaymentTransaction_ForOPD(int InsuranceId, string TransactionType, string PaymentMode, string BankName, string ChequeDate, string chequeNo, float AmountGiven, int FId, int BranchId, string username)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_InsertInsurancePaymentTransaction_ForOPD", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {

            cmd.Parameters.AddWithValue("@Sponser", InsuranceId);
            cmd.Parameters.AddWithValue("@PaymentMode", PaymentMode);
            cmd.Parameters.AddWithValue("@CreditAmount", AmountGiven);
            cmd.Parameters.AddWithValue("@ChequeNo", chequeNo);
            cmd.Parameters.AddWithValue("@BankName", BankName);
            cmd.Parameters.AddWithValue("@TransactionType", TransactionType);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.Parameters.AddWithValue("@ChequeDate", ChequeDate);
            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@CreatedBy", username);

            object result = cmd.ExecuteScalar();
            return Convert.ToString(result);

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


    public DataSet fillInvoiceGrid_ForOPDPatients(int InsuranceId, string FromDate, string ToDate, string ChargeNumber, string Patname, int GenerateInvoice)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_InvoiceGrid_ForOPDPatients", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@InsuranceId", InsuranceId);
        cmd.Parameters.AddWithValue("@FromDate", FromDate);
        cmd.Parameters.AddWithValue("@ToDate", ToDate);
        cmd.Parameters.AddWithValue("@ChargeNumber", ChargeNumber);
        cmd.Parameters.AddWithValue("@Patname", Patname);
        cmd.Parameters.AddWithValue("@GenerateInvoice", GenerateInvoice);

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        try
        {
            cmd.CommandTimeout = 5000;
            
            da.Fill(ds);
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

        return ds;
    }


    public string GenerateChargeNumber(int PatRegId, int PatientInsuTypeId, string InsuCompanyId, string CoverageDetails, string CreatedBy)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_GenerateChargeNumber", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {

            cmd.Parameters.AddWithValue("@PatRegId", PatRegId);
            cmd.Parameters.AddWithValue("@PatientInsuTypeId", PatientInsuTypeId);
            cmd.Parameters.AddWithValue("@InsuCompanyId", InsuCompanyId);
            cmd.Parameters.AddWithValue("@CoverageDetails", CoverageDetails);
            cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);

            object result = cmd.ExecuteScalar();
            return Convert.ToString(result);

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


    public DataSet Get_ChargeNo_ForOPDPatients(string  ChargeNo)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_ChargePatientInvoiceDetails", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Id", ChargeNo);
       

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds);
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

        return ds;
    }

    public string InsertInsuranceEditInvoice_ForOPD(int InvoiceId, float InsuranceAmt, float Discount, float DiscountAmt, float ActualInsuAmt, string DisRemark, string DiscGivenBy)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_UpdateCharge_InsuranceDiscount", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {

            cmd.Parameters.AddWithValue("@InvoiceId", InvoiceId);
            cmd.Parameters.AddWithValue("@InsuranceAmt", InsuranceAmt);
            cmd.Parameters.AddWithValue("@Discount", Discount);
            cmd.Parameters.AddWithValue("@DiscountAmt", DiscountAmt);
            cmd.Parameters.AddWithValue("@ActualInsuAmt", ActualInsuAmt);
            cmd.Parameters.AddWithValue("@DisRemark", DisRemark);
            cmd.Parameters.AddWithValue("@DiscGivenBy", DiscGivenBy);
            

            object result = cmd.ExecuteScalar();
            return Convert.ToString(result);

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
    public DataSet Get_InvoiceGeneratePatients(int InsuranceId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetInsuranceTransaction_ForOPD_PaymentAccept", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@InsuranceCompId", InsuranceId);
        

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds);
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

        return ds;
    }


    public string Update_InsurancePayment_Status(int InsuranceId, string ChargeNo, int Patregid, int InvoiceNo, int PartialPay, float ReceiveAmt, string UserName)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_Update_InsurancePayment_Status", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {

            cmd.Parameters.AddWithValue("@InsuranceId", InsuranceId);
            cmd.Parameters.AddWithValue("@ChargeNo", ChargeNo);
            cmd.Parameters.AddWithValue("@Patregid", Patregid);
            cmd.Parameters.AddWithValue("@InvoiceNo", InvoiceNo);

            cmd.Parameters.AddWithValue("@PartialPay", PartialPay);
            cmd.Parameters.AddWithValue("@ReceiveAmt", ReceiveAmt);
            cmd.Parameters.AddWithValue("@UserName", UserName);
            object result = cmd.ExecuteScalar();
            return Convert.ToString(result);

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

    public string UpdateFrontDeskBillings(BELOPDPatReg obj1)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_UpdateFrontDeskBilling", con);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@PatRegId", obj1.PatRegId);
        cmd.Parameters.AddWithValue("@PatMainTypeId", obj1.PatMainTypeId);
        cmd.Parameters.AddWithValue("@PatientInsuTypeId", obj1.PatientInsuTypeId);
        cmd.Parameters.AddWithValue("@Details", obj1.Details);
        cmd.Parameters.AddWithValue("@AmountPaid", obj1.PaidAmt);
        cmd.Parameters.AddWithValue("@DiscountAmt", obj1.DiscountAmt);
        cmd.Parameters.AddWithValue("@BillGroup", obj1.BillGroup);
        cmd.Parameters.AddWithValue("@BillAmount", obj1.BillAmount);
        cmd.Parameters.AddWithValue("@ReasonForDiscountId", obj1.ReasonForDiscountId);//("dd/MM/yyyy hh:MM:ss tt")
        cmd.Parameters.AddWithValue("@DiscountGivenById", obj1.DiscountGivenById);
        cmd.Parameters.AddWithValue("@ReasonForBalanceId", obj1.ReasonForBalanceId);
        cmd.Parameters.AddWithValue("@InsuranceAmount", obj1.InsuranceAmount);
        cmd.Parameters.AddWithValue("@BranchId", obj1.BranchId);
        cmd.Parameters.AddWithValue("@FId", obj1.FId);
        cmd.Parameters.AddWithValue("@CreatedBy", obj1.CreatedBy);

      
        cmd.Parameters.AddWithValue("@BillGroupId", obj1.BillGroupId);
        cmd.Parameters.AddWithValue("@InsuranceChargeCompamt", obj1.InsuranceChargeCompamt);

        cmd.Parameters.AddWithValue("@LetterNo", obj1.LetterNo);
        cmd.Parameters.AddWithValue("@TypeOfVisit", obj1.TypeOfVisit);

        cmd.Parameters.Add("@ProcedureId", obj1.ProcedureId);
        cmd.Parameters.Add("@BillNo", obj1.BillNo);
       // cmd.Parameters.Add("@ProcedureId", SqlDbType.Int);
        //cmd.Parameters.Add("@BillNo", SqlDbType.Int);





        object Result = cmd.ExecuteScalar();
        con.Close();
        con.Dispose();
        return Convert.ToString(Result);
    }

    public void Update_FrontDeskTransaction(BELBillInfo obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_UpdateProcedureTransaction", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {
            cmd.Parameters.AddWithValue("@PatRegId", obj.PatRegId);
            cmd.Parameters.AddWithValue("@BillNo", obj.BillNo);
            cmd.Parameters.AddWithValue("@ReceivedAmount", obj.AmountPaid);
            cmd.Parameters.AddWithValue("@PaymentMode", obj.PaymentType);
            cmd.Parameters.AddWithValue("@CardChequeNo", obj.ChequeCardNo);
            // cmd.Parameters.AddWithValue("@ChequeDate",obj.ChequeDate);
            if (obj.ChequeDate != null)
            {
                cmd.Parameters.AddWithValue("@ChequeDate", DateTime.ParseExact(obj.ChequeDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            cmd.Parameters.AddWithValue("@BankName", obj.BankName);
            cmd.Parameters.AddWithValue("@ProcedureId", obj.ProcedureId);
            cmd.Parameters.AddWithValue("@BillGroup", obj.BillGroup);
            cmd.Parameters.AddWithValue("@CreatedBy", obj.CreatedBy);
            cmd.Parameters.AddWithValue("@FId", obj.FId);
            cmd.Parameters.AddWithValue("@BranchId", obj.BranchId);


            cmd.ExecuteNonQuery();
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

    public string Update_ReceivePatients(int IpdNo, string Patregid, int Branchid, string ReceiveBy)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_updateIpdPatReceived", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@IpdNo", IpdNo);
            cmd.Parameters.AddWithValue("@Patregid", Patregid);
            cmd.Parameters.AddWithValue("@Branchid", Branchid);
            cmd.Parameters.AddWithValue("@ReceiveBy", ReceiveBy);


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

    public List<string> FillAll_OPDService(string prefixtext, string Type)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_FillTypeWiseOPDBillServices_Charge", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@ServiceType", Type);
            cmd.Parameters.AddWithValue("@Search", prefixtext);
            List<string> PatientName = new List<string>();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                PatientName.Add(sdr["ServiceName"].ToString());

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

    public string UpdatePatientInvoiceChargeService(int InvoiceId, float BillAmount, int BillServiceId, int Drid, int Qty, float Charges, string CreatedBy, string MTCode, string BillGroupName, DateTime CreatedOn)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_UpdatePatientInvoiceChargeService", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {

            cmd.Parameters.AddWithValue("@InvoiceId", InvoiceId);
            cmd.Parameters.AddWithValue("@BillAmt", BillAmount);
            cmd.Parameters.AddWithValue("@BillServiceId", BillServiceId);
            cmd.Parameters.AddWithValue("@DrId", Drid);
            cmd.Parameters.AddWithValue("@Qty", Qty);
            cmd.Parameters.AddWithValue("@Charges", Charges);
            cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            cmd.Parameters.AddWithValue("@MTCode", MTCode);
            cmd.Parameters.AddWithValue("@BillGroupName", BillGroupName.Trim());
            cmd.Parameters.AddWithValue("@CreatedOn", CreatedOn);
            

            object result = cmd.ExecuteScalar();
            return Convert.ToString(result);

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


    public void DeletePatient_ChargeService(int ID)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_DeletePatient_ChargeService", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {
            cmd.Parameters.AddWithValue("@ID", ID);
            


            cmd.ExecuteNonQuery();
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

    public string UpdatePatient_ChargeBillAmt(int InsuranceCompID, string FromDate, string ToDate)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_UpdateAutoChargeBillAmount", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {

            cmd.Parameters.AddWithValue("@InsuranceCompID", InsuranceCompID);
            cmd.Parameters.AddWithValue("@FromDate", FromDate);
            cmd.Parameters.AddWithValue("@ToDate", ToDate);
           
            object result = cmd.ExecuteScalar();
            return Convert.ToString(result);

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


    public DataSet FillInvoiceGrid_IPD(int InsuranceId, string FromDate, string ToDate)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Vw_IPDInsuranceBillAmount", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@InsuranceId", InsuranceId);
        cmd.Parameters.AddWithValue("@FromDate", FromDate);
        cmd.Parameters.AddWithValue("@ToDate", ToDate);

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds);
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

        return ds;
    }

    public DataSet Get_InvoiceGeneratePatients_ForIPD(int InsuranceId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_GetIPDInvoiceGeneratedPatient", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@InsuranceCompId", InsuranceId);


        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds);
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

        return ds;
    }

    public string Update_InsurancePayment_Status_IPD(int InsuranceId, string ChargeNo, int Patregid, int InvoiceNo, int PartialPay, float ReceiveAmt, string UserName,int IpdNo)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_Update_InsurancePayment_Status_ForIPD", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {

            cmd.Parameters.AddWithValue("@InsuranceId", InsuranceId);
            cmd.Parameters.AddWithValue("@ChargeNo", ChargeNo);
            cmd.Parameters.AddWithValue("@Patregid", Patregid);
            cmd.Parameters.AddWithValue("@InvoiceNo", InvoiceNo);

            cmd.Parameters.AddWithValue("@PartialPay", PartialPay);
            cmd.Parameters.AddWithValue("@ReceiveAmt", ReceiveAmt);
            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@IpdNo", IpdNo);

            object result = cmd.ExecuteScalar();
            return Convert.ToString(result);

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


    public DataTable Get_DrNAme(string drID)
    {
        DataTable ds = new DataTable();
        SqlConnection con = new SqlConnection();
        
                con = DataAccess.ConInitForDC();
            
            con.Open();
            //SqlDataAdapter sda = new SqlDataAdapter(" select top(20) RoutinTestCode,RoutinTestCode+' - '+ RoutinTestName as Maintestname from RoutinTest  ", con);
            SqlDataAdapter sda = new SqlDataAdapter(" SELECT cast( DrId as nvarchar(50))+ ' - ' +Title+''+EmpName as EmpName FROM HospEmpMst where EmployeeType='Consultant'  and DrId=" + drID + " ", con);


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


    public List<string> VoucherPayment_PayTo(string prefixtext)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_GetAllPayTo", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@Search", prefixtext);
            List<string> PatientName = new List<string>();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                PatientName.Add(sdr["SupName"].ToString());

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

    public List<string> Voucher_AccountHead(string prefixtext)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_GetAllAccountName", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@Search", prefixtext);
            List<string> PatientName = new List<string>();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                PatientName.Add(sdr["AccountName"].ToString());

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

    public List<string> SearchSecondaryDoc(string prefixtext)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_GetAllConsultant", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@Search", prefixtext);
            List<string> PatientName = new List<string>();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                PatientName.Add(sdr["EmpName"].ToString());

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

    public DataSet GetMRC_PatientIPDBillDetails(int PatRegId, int FId, int BillNo, int IpdNo)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_FillMRC_IPDPatientBillDetails", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@IpdNo", IpdNo);
        cmd.Parameters.AddWithValue("@BillNo", BillNo);
        cmd.Parameters.AddWithValue("@PatRegId", PatRegId);
        cmd.Parameters.AddWithValue("@FId", FId);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds);
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

        return ds;
    }

    public DataSet GetMRC_PrevPatientIPDBillDetails(int PatRegId, int FId, int BillNo, int IpdNo)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_FillMRC_PrevIPDPatientBillDetails", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@IpdNo", IpdNo);
        cmd.Parameters.AddWithValue("@BillNo", BillNo);
        cmd.Parameters.AddWithValue("@PatRegId", PatRegId);
        cmd.Parameters.AddWithValue("@FId", FId);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds);
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

        return ds;
    }

    public DataSet GetBindDashboard(int branchid, int PType,string FromDate,string ToDate)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_BindDashboard", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PType", PType);
        //cmd.Parameters.AddWithValue("@BillNo", BillNo);
        //cmd.Parameters.AddWithValue("@PatRegId", PatRegId);
        cmd.Parameters.AddWithValue("@branchid", branchid);
        if (FromDate == "")
        {
            cmd.Parameters.AddWithValue("@FromDate", "");
        }
        else
        {

            cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
        }
        if (ToDate == "")
        {
            cmd.Parameters.AddWithValue("@ToDate", "");

        }
        else
        {
            // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
            cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
        }
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        try
        {
            cmd.CommandTimeout = 5000;
            da.Fill(ds);
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

        return ds;
    }
    public DataSet Get_EmergencyProcedure(int patregId,int OpdNo,int IpdNo)
    {
        DataSet dt = new DataSet();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;
            using (SqlConnection connection = DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("SP_GetEmergencyServiceDetails", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Patregid", SqlDbType.Int).Value = patregId;
                    cmd.Parameters.Add("@OpdNo", SqlDbType.Int).Value = OpdNo;
                    cmd.Parameters.Add("@IpdNo", SqlDbType.Int).Value = IpdNo;
                    connection.Open();

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                }
            }
        }
        catch (Exception)
        {
        }
        return dt;
    }

    public DataTable Get_TotalPatientCount(object tdate, object fdate,string PType)
    {

        SqlConnection conn = DataAccess.ConInitForDC();
        SqlDataAdapter da;
        string query = "select COUNT(ID) as PatientCount from LabRegistration " +
                  " where LabPType='" + PType + "' and   (CAST(CAST(YEAR( LabRegistration.CreatedOn) AS varchar(4)) + '/' + CAST(MONTH( LabRegistration.CreatedOn) AS varchar(2)) + '/' + CAST(DAY(LabRegistration.CreatedOn) AS varchar(2)) AS datetime))  between ('" + Convert.ToDateTime(fdate).ToString("MM/dd/yyyy") + "') and ('" + Convert.ToDateTime(tdate).ToString("MM/dd/yyyy") + "')  ";



        da = new SqlDataAdapter(query, conn);
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
            conn.Close(); conn.Dispose();
        }
        return ds;

    }

    public DataTable Get_TotalPatientVal()
    {

        SqlConnection conn = DataAccess.ConInitForDC();
        SqlDataAdapter da;
        string query = "  select * from patientinformation where patregid=1000 and (Firstname='Patricia Liverpool' or Firstname='Khushaan Parboo') ";



        da = new SqlDataAdapter(query, conn);
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
            conn.Close(); conn.Dispose();
        }
        return ds;

    }
}

