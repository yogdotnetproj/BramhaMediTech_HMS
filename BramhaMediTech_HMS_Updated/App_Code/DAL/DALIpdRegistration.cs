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
/// Summary description for DALIpdRegistration
/// </summary>
public class DALIpdRegistration
{
    BELOPDPatReg objBELOpdReg = new BELOPDPatReg();
	public DALIpdRegistration()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public object[] InsertIPDPatientRegistration(BELOPDPatReg obj1)
    {
        object[] Result = new object[10];
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_InsertIPDRegistration", con);
        cmd.CommandType = CommandType.StoredProcedure;

        try
        {           
            cmd.Parameters.AddWithValue("@PatRegId", obj1.PatRegId);
            cmd.Parameters.AddWithValue("@IpdNo", obj1.IpdNo);
            cmd.Parameters.AddWithValue("@BranchId", obj1.BranchId);
            cmd.Parameters.AddWithValue("@FId", obj1.FId);           
            cmd.Parameters.AddWithValue("@PrimaryDoc", obj1.PrimaryDoc);
            cmd.Parameters.AddWithValue("@SecodaryDoc", obj1.SecodaryDoc);
            cmd.Parameters.AddWithValue("@PatMainTypeId", obj1.PatMainTypeId);
            cmd.Parameters.AddWithValue("@PatientInsuTypeId", obj1.PatientInsuTypeId);            
            cmd.Parameters.AddWithValue("@ReferenceDoc", obj1.ReferenceDrId);
            cmd.Parameters.AddWithValue("@Contact1", obj1.Contact1);
            cmd.Parameters.AddWithValue("@Contact2", obj1.Contact2);
            cmd.Parameters.AddWithValue("@ContactPerson1", obj1.ContactPerson1);
            cmd.Parameters.AddWithValue("@ContactPerson2", obj1.ContactPerson2);
            cmd.Parameters.AddWithValue("@Relation1", obj1.Relation1);
            cmd.Parameters.AddWithValue("@Relation2", obj1.Relation2);
            cmd.Parameters.AddWithValue("@CreatedBy", obj1.CreatedBy);
            cmd.Parameters.AddWithValue("@DeptId", obj1.DeptId);
            cmd.Parameters.AddWithValue("@BedId", obj1.BedId);
            cmd.Parameters.AddWithValue("@EntryTime", obj1.EntryTime);
            cmd.Parameters.AddWithValue("@IsAdmited", obj1.IsAdmited);
            cmd.Parameters.AddWithValue("@IsEmergency", obj1.IsEmergency);
            cmd.Parameters.AddWithValue("@IsUniversalPrecaution", obj1.IsUniversalPrecaution);
            cmd.Parameters.AddWithValue("@PatientInsuTypeId2", obj1.PatientInsuTypeId2);
            cmd.Parameters.AddWithValue("@DiseaseId", obj1.DiseaseId);
            cmd.Parameters.AddWithValue("@OperationId", obj1.OperationId);
            cmd.Parameters.AddWithValue("@DiseaseName", obj1.DiseaseName);
            cmd.Parameters.AddWithValue("@OperationName", obj1.OperatioName);
            cmd.Parameters.AddWithValue("@EntryDate", obj1.RegisterDate);

            cmd.Parameters.AddWithValue("@Address1", obj1.Address1);
            cmd.Parameters.AddWithValue("@Address2", obj1.Address2);
            cmd.Parameters.AddWithValue("@SurgeryType", obj1.SurgeryType);
            cmd.Parameters.AddWithValue("@RoomCategory", obj1.RoomCategory);
            cmd.Parameters.AddWithValue("@LetterNumber", obj1.LetterNumber);
            cmd.Parameters.AddWithValue("@ChargeCompanyId", obj1.ChargeCompanyId);
            cmd.Parameters.AddWithValue("@SurgicalDepositAmt", obj1.DepositAmt);

            cmd.Parameters.AddWithValue("@Infant", obj1.Infant);
            cmd.Parameters.AddWithValue("@InfantDOB", obj1.InfantDOB);
            cmd.Parameters.AddWithValue("@InfantGender", obj1.InfantGender);
            cmd.Parameters.AddWithValue("@InfantRace", obj1.InfantRace);
            cmd.Parameters.AddWithValue("@InfantMotherIPDNO", obj1.InfantMotherIPDNO);
            cmd.Parameters.AddWithValue("@InFantPatientName", obj1.InFantPatientName);

            cmd.Parameters.AddWithValue("@PaymentType", obj1.PaymentType);
            cmd.Parameters.AddWithValue("@PaymentRemark", obj1.PaymentRemark);

            cmd.Parameters.Add("@IpdId", SqlDbType.Int);
            cmd.Parameters["@IpdId"].Direction = ParameterDirection.Output;
            Result[1] = cmd.ExecuteScalar();
            Result[0] = Convert.ToInt32(cmd.Parameters["@IpdId"].Value);
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

    public object[] UpdateIPDPatientRegistration(BELOPDPatReg obj1)
    {
        object[] Result = new object[10];
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_UpdateIPDRegistration", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@PatRegId", obj1.PatRegId);            
           
            cmd.Parameters.AddWithValue("@PrimaryDoc", obj1.PrimaryDoc);
            cmd.Parameters.AddWithValue("@SecodaryDoc", obj1.SecodaryDoc);
            cmd.Parameters.AddWithValue("@PatMainTypeId", obj1.PatMainTypeId);
            cmd.Parameters.AddWithValue("@PatientInsuTypeId", obj1.PatientInsuTypeId);
            
            cmd.Parameters.AddWithValue("@ReferenceDoc", obj1.ReferenceDrId);
            cmd.Parameters.AddWithValue("@Contact1", obj1.Contact1);
            cmd.Parameters.AddWithValue("@Contact2", obj1.Contact2);
            cmd.Parameters.AddWithValue("@ContactPerson1", obj1.ContactPerson1);
            cmd.Parameters.AddWithValue("@ContactPerson2", obj1.ContactPerson2);
            cmd.Parameters.AddWithValue("@Relation1", obj1.Relation1);
            cmd.Parameters.AddWithValue("@Relation2", obj1.Relation2);
            cmd.Parameters.AddWithValue("@UpdatedBy", obj1.UpdatedBy);
            cmd.Parameters.AddWithValue("@DeptId", obj1.DeptId);
            cmd.Parameters.AddWithValue("@IsEmergency", obj1.IsEmergency);
            cmd.Parameters.AddWithValue("@IsUniversalPrecaution", obj1.IsUniversalPrecaution);
            
            cmd.Parameters.AddWithValue("@DiseaseId", obj1.DiseaseId);
            cmd.Parameters.AddWithValue("@OperationId", obj1.OperationId);
            cmd.Parameters.AddWithValue("@DiseaseName", obj1.DiseaseName);
            cmd.Parameters.AddWithValue("@OperationName", obj1.OperatioName);
            cmd.Parameters.AddWithValue("@PatientSubCategoryId2", obj1.PatientInsuTypeId2);
            cmd.Parameters.AddWithValue("@EntryDate", obj1.RegisterDate);
            cmd.Parameters.AddWithValue("@BranchId", obj1.BranchId);
            cmd.Parameters.AddWithValue("@FId", obj1.FId);
            cmd.Parameters.AddWithValue("@Address1", obj1.Address1);
            cmd.Parameters.AddWithValue("@Address2", obj1.Address2);

            cmd.Parameters.AddWithValue("@LetterNumber", obj1.LetterNumber);
            cmd.Parameters.AddWithValue("@ChargeCompanyId", obj1.ChargeCompanyId);
            cmd.Parameters.AddWithValue("@SurgicalDepositAmt", obj1.DepositAmt);
            cmd.Parameters.AddWithValue("@SurgeryType", obj1.SurgeryType);

            cmd.Parameters.AddWithValue("@PaymentType", obj1.PaymentType);
            cmd.Parameters.AddWithValue("@PaymentRemark", obj1.PaymentRemark);

            cmd.Parameters.AddWithValue("@IpdId", obj1.IpdId);
            Result[0] = cmd.ExecuteScalar();            

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

    public object[] UpdateIPDRecomadation(BELOPDPatReg obj1)
    {
        object[] Result = new object[10];
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_UpdateIPDDischargeRecomadation", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@PatRegId", obj1.PatRegId);

          
          //  cmd.Parameters.AddWithValue("@IsUniversalPrecaution", obj1.IsUniversalPrecaution);            
            cmd.Parameters.AddWithValue("@EntryDate", obj1.RegisterDate);
            cmd.Parameters.AddWithValue("@EntryTime", obj1.EntryTime);
            cmd.Parameters.AddWithValue("@BranchId", obj1.BranchId);
            cmd.Parameters.AddWithValue("@RecoBy", obj1.CreatedBy);
            cmd.Parameters.AddWithValue("@RecomRemark", obj1.P_RecomRemark);
            cmd.Parameters.AddWithValue("@IpdNo", obj1.IpdNo);
            Result[0] = cmd.ExecuteScalar();

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
    public BELOPDPatReg SelectOne(int IpdId,int FId, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_IpdRegSelectOne", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@IpdId", IpdId);
            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                objBELOpdReg.PatRegId = Convert.ToInt32(reader["PatientInfoId"]);
                objBELOpdReg.PatMainTypeId = Convert.ToInt32(reader["PatientMainCategoryId"]);
                objBELOpdReg.PatientInsuTypeId = Convert.ToInt32(reader["PatientSubCategoryId"]);
                objBELOpdReg.PrimaryDoc = Convert.ToInt32(reader["PrimaryDoc"]); ;
                objBELOpdReg.SecodaryDoc = Convert.ToInt32(reader["SecodaryDoc"]);
                objBELOpdReg.ReferenceDrId = Convert.ToInt32(reader["ReferenceDoc"]);
                objBELOpdReg.Relation1 = Convert.ToInt32(reader["Relation1"]);
                objBELOpdReg.Relation2 = Convert.ToInt32(reader["Relation2"]);
                objBELOpdReg.Contact1 = Convert.ToString(reader["Contact1"]);
                objBELOpdReg.Contact2 = Convert.ToString(reader["Contact2"]);
                objBELOpdReg.ContactPerson1 = Convert.ToString(reader["ContactPerson1"]);
                objBELOpdReg.ContactPerson2 = Convert.ToString(reader["ContactPerson2"]);
                objBELOpdReg.DeptId = Convert.ToInt32(reader["DeptId"]);
                objBELOpdReg.EntryTime = Convert.ToString(reader["EntryTime"]);
                objBELOpdReg.EntryDate = Convert.ToString(reader["EntryDate"]);
                objBELOpdReg.Age = Convert.ToString(reader["Age"]);
                objBELOpdReg.TitleId = Convert.ToInt32(reader["TitleId"]);
                objBELOpdReg.PatientName = Convert.ToString(reader["PatientName"]);
                objBELOpdReg.MobileNo = Convert.ToString(reader["MobileNo"]);

                objBELOpdReg.LetterNumber = Convert.ToString(reader["LetterNumber"]);

                if (reader["IsEmergency"] != DBNull.Value)
                {
                    objBELOpdReg.IsEmergency = Convert.ToBoolean(reader["IsEmergency"]);
                }
                else
                {
                    objBELOpdReg.IsEmergency = false;
                }
                if (reader["IsUniversalPrecaution"] != DBNull.Value)
                {
                    objBELOpdReg.IsUniversalPrecaution = Convert.ToBoolean(reader["IsUniversalPrecaution"]);
                }
                else
                {
                    objBELOpdReg.IsUniversalPrecaution = false;
                }
                objBELOpdReg.FullDocName = Convert.ToString(reader["FullDocName"]);
                objBELOpdReg.FullDeptName = Convert.ToString(reader["FullDeptName"]);
                objBELOpdReg.DiseaseName = Convert.ToString(reader["Sponsor"]);
                objBELOpdReg.OperatioName = Convert.ToString(reader["ProcedureName"]);
                objBELOpdReg.DiseaseId = Convert.ToInt32(reader["DiseaseId"]);
                objBELOpdReg.OperationId = Convert.ToInt32(reader["OperationId"]);
                objBELOpdReg.SecondaryDoc = Convert.ToString(reader["SecondaryDoc"]);
                if (Convert.ToString(reader["PatientSubCategoryId2"]) != "")
                {
                    objBELOpdReg.PatientInsuTypeId2 = Convert.ToInt32(reader["PatientSubCategoryId2"]);
                }
                else
                {
                    objBELOpdReg.PatientInsuTypeId2 = 0;
                }
                objBELOpdReg.Address1 = Convert.ToString(reader["Address1"]);
                objBELOpdReg.Address2 = Convert.ToString(reader["Address2"]);

                objBELOpdReg.SurgeryType = Convert.ToString(reader["SurgeryType"]);

                objBELOpdReg.PatientInsuType = Convert.ToString(reader["PatientInsuType"]);
                objBELOpdReg.PatientInsurance2 = Convert.ToString(reader["PatientInsurance2"]);
                objBELOpdReg.ChildCompanyName = Convert.ToString(reader["ChildCompanyName"]);
                objBELOpdReg.ChargeCompanyId = Convert.ToInt32(reader["ChargeCompanyId"]);
                objBELOpdReg.DepositAmt = Convert.ToString(reader["SurgicalDepositAmt"]);

                objBELOpdReg.Infant = Convert.ToInt32(reader["Infant"]);
                objBELOpdReg.InfantDOB = Convert.ToString(reader["InfantDOB"]);
                objBELOpdReg.InfantGender = Convert.ToString(reader["InfantGender"]);
                objBELOpdReg.InfantRace = Convert.ToInt32(reader["InfantRace"]);
                objBELOpdReg.InfantMotherIPDNO = Convert.ToInt32(reader["InfantMotherIPDNO"]);
                objBELOpdReg.PaymentType = Convert.ToInt32(reader["PaymentType"]);
                objBELOpdReg.PaymentRemark = Convert.ToString(reader["PaymentRemark"]);

            }
            return objBELOpdReg;
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
    
    public void InsertBedAllocationInfo(BELOPDPatReg obj1)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_InsertBedAllocationInfo", con);
        cmd.CommandType = CommandType.StoredProcedure;

        try
        {
            cmd.Parameters.AddWithValue("@IpdId", obj1.IpdId);
            cmd.Parameters.AddWithValue("@PatRegId", obj1.PatRegId);
            cmd.Parameters.AddWithValue("@IpdNo", obj1.IpdNo);
            cmd.Parameters.AddWithValue("@BranchId", obj1.BranchId);
            cmd.Parameters.AddWithValue("@FId", obj1.FId);
            cmd.Parameters.AddWithValue("@DeptId", obj1.DeptId);
            cmd.Parameters.AddWithValue("@BedId", obj1.BedId);
            cmd.Parameters.AddWithValue("@CreatedBy", obj1.CreatedBy);
            cmd.Parameters.AddWithValue("@RoomID", obj1.RoomId);

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

    public void InsertUpdateBedAllocationInfo_Discharge(BELOPDPatReg obj1)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_InsertUpdateBedAllocationInfo_Discharge", con);
        cmd.CommandType = CommandType.StoredProcedure;

        try
        {
           
            cmd.Parameters.AddWithValue("@PatRegId", obj1.PatRegId);           
            cmd.Parameters.AddWithValue("@BranchId", obj1.BranchId);
            cmd.Parameters.AddWithValue("@FId", obj1.FId);           
            cmd.Parameters.AddWithValue("@BedId", obj1.BedId);           
            cmd.Parameters.AddWithValue("@CreatedBy", obj1.CreatedBy);
            cmd.Parameters.AddWithValue("@IpdNo", obj1.IpdNo);
            cmd.Parameters.AddWithValue("@DateOfDischarge", obj1.DischargeDateTime);
            cmd.Parameters.AddWithValue("@DischargeTime", obj1.DischargeTime);
            cmd.Parameters.AddWithValue("@ReasnoforDischarge", obj1.DischargeReason);
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
    public void InsertUpdateBedAllocationInfo_Shifting(BELOPDPatReg obj1)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_InsertUpdateBedAllocationInfo_Shifting", con);
        cmd.CommandType = CommandType.StoredProcedure;

        try
        {
            //cmd.Parameters.AddWithValue("@IpdId", obj1.IpdId);
            cmd.Parameters.AddWithValue("@PatRegId", obj1.PatRegId);
           // cmd.Parameters.AddWithValue("@IpdNo", obj1.IpdNo);
            cmd.Parameters.AddWithValue("@BranchId", obj1.BranchId);
            cmd.Parameters.AddWithValue("@FId", obj1.FId);
           // cmd.Parameters.AddWithValue("@DeptId", obj1.DeptId);
            cmd.Parameters.AddWithValue("@BedId", obj1.BedId);
            cmd.Parameters.AddWithValue("@OLDBedId", obj1.OLDBedId);
            cmd.Parameters.AddWithValue("@CreatedBy", obj1.CreatedBy);
            cmd.Parameters.AddWithValue("@ReasonForShifting", obj1.ReasonforShifting);
            cmd.Parameters.AddWithValue("@RoomId", obj1.RoomId);

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
    
    public int GetMaxIpdNo(int FId)
    {
        object Result;
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetMaxIpdNo", con);
        cmd.CommandType = CommandType.StoredProcedure;

        try
        {
           
            cmd.Parameters.AddWithValue("@FId",FId);
           

            Result = cmd.ExecuteScalar();

            return Convert.ToInt32(Result);


        }
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

    public bool getallreadyRegister(DateTime Patregdate, string Patregid)
    {
        bool flag = true;
       // SqlConnection conn = new SqlConnection(ConnectionString.Connectionstring);
        SqlConnection conn = DataAccess.ConInitForDC();
       
        SqlCommand sc = new SqlCommand();

        sc = new SqlCommand(" SELECT  COUNT(*)  FROM  IpdRegistration WHERE  CreatedOn between convert(varchar,   DATEADD(MINUTE,-1,GETDATE()), 21) and  convert(varchar,  DATEADD(MINUTE,1,GETDATE()), 21)  AND Patregid=@Patregid  ", conn);

       
        //    sc.Parameters.Add(new SqlParameter("@Patregdate", SqlDbType.DateTime)).Value = Patregdate;
        sc.Parameters.Add(new SqlParameter("@Patregid", SqlDbType.NVarChar, 250)).Value = Patregid;
       

        object count;
        try
        {
            conn.Open();
            count = sc.ExecuteScalar();

            if (count != null)
            {
                if (Convert.ToInt32(count) > 0)
                {
                    flag = false;
                }
            }
        }
        catch (SqlException ex)
        { }
        finally
        {
            conn.Close();
            conn.Dispose();
        }
        return flag;
    }
    public void InsertUpdateBedQty(BELOPDPatReg obj1)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_UpdateAutoQty", con);
        cmd.CommandType = CommandType.StoredProcedure;

        try
        {
            //cmd.Parameters.AddWithValue("@IpdId", obj1.IpdId);
            cmd.Parameters.AddWithValue("@PatRegId", obj1.PatRegId);
            cmd.Parameters.AddWithValue("@ipdno", obj1.IpdNo);
            cmd.Parameters.AddWithValue("@BranchId", obj1.BranchId);


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
    public int GetMaxIpdBillNo(int FId)
    {
        object Result;
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_GetMaxBillNoForIPD", con);
        cmd.CommandType = CommandType.StoredProcedure;

        try
        {

            cmd.Parameters.AddWithValue("@FId", FId);


            Result = cmd.ExecuteScalar();

            return Convert.ToInt32(Result);


        }
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
    public void InsertRoomCharges(BELOPDPatReg obj1)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_InserRoomCharges", con);
        cmd.CommandType = CommandType.StoredProcedure;

        try
        {
            cmd.Parameters.AddWithValue("@IpdId", obj1.IpdId);
            cmd.Parameters.AddWithValue("@PatRegId", obj1.PatRegId);
            cmd.Parameters.AddWithValue("@IpdNo", obj1.IpdNo);
            cmd.Parameters.AddWithValue("@BranchId", obj1.BranchId);
            cmd.Parameters.AddWithValue("@FId", obj1.FId);
            cmd.Parameters.AddWithValue("@DeptId", obj1.DeptId);
            cmd.Parameters.AddWithValue("@BedId", obj1.BedId);
            cmd.Parameters.AddWithValue("@CreatedBy", obj1.CreatedBy);
            cmd.Parameters.AddWithValue("@RoomID", obj1.RoomId);
            cmd.Parameters.AddWithValue("@BillNo", obj1.BillNo);

            cmd.Parameters.AddWithValue("@IsInfant", obj1.Infant);
            cmd.Parameters.AddWithValue("@InfantIPDNo", obj1.InfantMotherIPDNO);

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


    public void Insert_ReferToAdmissionData(BELOPDPatReg obj1)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_InsertRefetToAdmissionData", con);
        cmd.CommandType = CommandType.StoredProcedure;

        try
        {
            cmd.Parameters.AddWithValue("@OPDNO", obj1.OpdNo);
            cmd.Parameters.AddWithValue("@PatRegId", obj1.PatRegId);
            cmd.Parameters.AddWithValue("@IpdNo", obj1.IpdNo);
            cmd.Parameters.AddWithValue("@BranchId", obj1.BranchId);
            cmd.Parameters.AddWithValue("@FId", obj1.FId);
          

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

}