using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

/// <summary>
/// Summary description for DALInputOutPutChart
/// </summary>
public class DALInputOutPutChart
{
    BELIntakeOutputChart objBELIO = new BELIntakeOutputChart();
	public DALInputOutPutChart()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public string InsertInputOutputChart(BELIntakeOutputChart obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_InsertIntakeOutputChart", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@Patregid", obj.Patregid);
            cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
            cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);    
             
           

                //cmd.Parameters.AddWithValue("@LiquidInput",obj.LiquidInput);
                //cmd.Parameters.AddWithValue("@LiquidOutput",obj.LiquidOutput);
                //cmd.Parameters.AddWithValue("@LiquidBalance",obj.LiquidBalance);
                //cmd.Parameters.AddWithValue("@SolidInput",obj.SolidInput);
                //cmd.Parameters.AddWithValue("@SolidOutput",obj.SolidOutput);
                //cmd.Parameters.AddWithValue("@SolidBalance",obj.SolidBalance);

                cmd.Parameters.AddWithValue("@DrId",obj.DrId);
                cmd.Parameters.AddWithValue("@DateInput", obj.DateInput);            
                cmd.Parameters.AddWithValue("@TimeInput",obj.TimeInput);
                cmd.Parameters.AddWithValue("@TypeOfOralIntake",obj.TypeOfOralIntake);
                cmd.Parameters.AddWithValue("@OralIntakeQty",obj.OralIntakeQty);
                cmd.Parameters.AddWithValue("@OralIntakeUnit",obj.OralIntakeUnit);
                cmd.Parameters.AddWithValue("@BloodIntake",obj.BloodIntake);
                cmd.Parameters.AddWithValue("@IVIntake",obj.IVIntake);
                cmd.Parameters.AddWithValue("@OtherIntake", obj.OtherIntake);
                cmd.Parameters.AddWithValue("@OtherIntakeType",obj.OtherIntakeType);
                cmd.Parameters.AddWithValue("@OtherIntakeUnit",obj.OtherIntakeUnit);
                	
                cmd.Parameters.AddWithValue("@Remark", obj.Remark);

                cmd.Parameters.AddWithValue("@OtherOutputUnit", obj.OtherOutputUnit);
                cmd.Parameters.AddWithValue("@OtherOutput", obj.OtherOutput);
                cmd.Parameters.AddWithValue("@Bowel", obj.Bowel);

                cmd.Parameters.AddWithValue("@RTA", obj.RTA);
                cmd.Parameters.AddWithValue("@UrineUnit", obj.UrineUnit);
                cmd.Parameters.AddWithValue("@UrineOutPut", obj.UrineOutPut);
                cmd.Parameters.AddWithValue("@VomitUnit", obj.VomitUnit);

                cmd.Parameters.AddWithValue("@VomitOutPut", obj.VomitOutPut);
                cmd.Parameters.AddWithValue("@RTF", obj.RTF);
            

                cmd.Parameters.AddWithValue("@BranchId", obj.BranchId);
                cmd.Parameters.AddWithValue("@CreatedBy", obj.CreatedBy);
                cmd.Parameters.AddWithValue("@FId", obj.FId);


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

    public string UpdateInputOutputChart(BELIntakeOutputChart obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_UpdateIntakeOutputChart", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@IOId", obj.IOId);
            
                cmd.Parameters.AddWithValue("@DrId",obj.DrId);
                cmd.Parameters.AddWithValue("@DateInput", obj.DateInput);            
                cmd.Parameters.AddWithValue("@TimeInput",obj.TimeInput);
                cmd.Parameters.AddWithValue("@TypeOfOralIntake",obj.TypeOfOralIntake);
                cmd.Parameters.AddWithValue("@OralIntakeQty",obj.OralIntakeQty);
                cmd.Parameters.AddWithValue("@OralIntakeUnit",obj.OralIntakeUnit);
                cmd.Parameters.AddWithValue("@BloodIntake",obj.BloodIntake);
                cmd.Parameters.AddWithValue("@IVIntake",obj.IVIntake);
                cmd.Parameters.AddWithValue("@OtherIntake", obj.OtherIntake);
                cmd.Parameters.AddWithValue("@OtherIntakeType",obj.OtherIntakeType);
                cmd.Parameters.AddWithValue("@OtherIntakeUnit",obj.OtherIntakeUnit);
                	
                cmd.Parameters.AddWithValue("@Remark", obj.Remark);

                cmd.Parameters.AddWithValue("@OtherOutputUnit", obj.OtherOutputUnit);
                cmd.Parameters.AddWithValue("@OtherOutput", obj.OtherOutput);
                cmd.Parameters.AddWithValue("@Bowel", obj.Bowel);

                cmd.Parameters.AddWithValue("@RTA", obj.RTA);
                cmd.Parameters.AddWithValue("@UrineUnit", obj.UrineUnit);
                cmd.Parameters.AddWithValue("@UrineOutPut", obj.UrineOutPut);
                cmd.Parameters.AddWithValue("@VomitUnit", obj.VomitUnit);

                cmd.Parameters.AddWithValue("@VomitOutPut", obj.VomitOutPut);
                cmd.Parameters.AddWithValue("@RTF", obj.RTF);
            

                cmd.Parameters.AddWithValue("@BranchId", obj.BranchId);
                cmd.Parameters.AddWithValue("@UpdatedBy", obj.UpdatedBy);
                cmd.Parameters.AddWithValue("@FId", obj.FId);


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
    
    public DataTable FillInputOutputGrid(BELIntakeOutputChart obj)//string patregId
    {
        DataTable dt = new DataTable();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;
            using (SqlConnection connection =
                      DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("Sp_FillInputOutPutChart", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PatRegId", obj.Patregid);
                    cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
                    cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);
                    cmd.Parameters.AddWithValue("@BranchId", obj.BranchId);
                    cmd.Parameters.AddWithValue("@FId", obj.FId);
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

    public BELIntakeOutputChart SelectInputOutput(int IOId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_IntakeOutputChartSelectOne", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@IOId", IOId);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                objBELIO.TypeOfOralIntake = Convert.ToString(sdr["TypeOfOralIntake"]);
                objBELIO.OralIntakeQty = Convert.ToSingle(sdr["OralIntakeQty"]);
                objBELIO.DateInput = Convert.ToDateTime(sdr["DateInput"]);
                objBELIO.TimeInput = Convert.ToString(sdr["TimeInput"]);
                objBELIO.OralIntakeUnit = Convert.ToString(sdr["OralIntakeUnit"]);
                objBELIO.BloodIntake = Convert.ToSingle(sdr["BloodIntake"]);

                objBELIO.IVIntake = Convert.ToSingle(sdr["IVIntake"]);
                objBELIO.OtherIntake = Convert.ToSingle(sdr["OtherIntake"]);
                objBELIO.OtherIntakeType = Convert.ToString(sdr["OtherIntakeType"]);
                objBELIO.OtherIntakeUnit =Convert.ToString(sdr["OtherIntakeUnit"]);
                objBELIO.RTF = Convert.ToSingle(sdr["RTF"]);
                objBELIO.Remark = Convert.ToString(sdr["Remark"]);


                objBELIO.VomitOutPut = Convert.ToSingle(sdr["VomitOutPut"]);
                objBELIO.VomitUnit = Convert.ToString(sdr["VomitUnit"]);
                objBELIO.UrineOutPut = Convert.ToSingle(sdr["UrineOutPut"]);
                objBELIO.UrineUnit = Convert.ToString(sdr["UrineUnit"]);
                objBELIO.OtherOutput = Convert.ToSingle(sdr["OtherOutput"]);
                objBELIO.OtherOutputUnit = Convert.ToString(sdr["OtherOutputUnit"]);
                objBELIO.RTA = Convert.ToSingle(sdr["RTA"]);
                objBELIO.Bowel = Convert.ToString(sdr["Bowel"]);
            }
            return objBELIO;
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
    
    public string DeleteInputOutput(int IOId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_DeleteIntakeOutputChart", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@IOId", IOId);
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

    public void Alter_Vw_IntakeOutputSheet(BELIntakeOutputChart obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Alter_Vw_IntakeOutputChart", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@PatregId", obj.Patregid);
            cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
            cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);

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
//--------------------------------------------------------------------------------

    public string InsertDailyNurseNote(BELIntakeOutputChart obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_InsertDailyNurseNote", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@PatregId", obj.Patregid);
            cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
            cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);
            cmd.Parameters.AddWithValue("@DrId", obj.DrId);
            cmd.Parameters.AddWithValue("@DateInput", obj.DateInput);
            cmd.Parameters.AddWithValue("@TimeInput", obj.TimeInput);
            cmd.Parameters.AddWithValue("@UserId", obj.UserId);
            cmd.Parameters.AddWithValue("@Remark", obj.Remark);
            cmd.Parameters.AddWithValue("@BranchId", obj.BranchId);
            cmd.Parameters.AddWithValue("@CreatedBy", obj.CreatedBy);
            cmd.Parameters.AddWithValue("@UpdatedBy", obj.UpdatedBy);
            cmd.Parameters.AddWithValue("@FId", obj.FId);
            cmd.Parameters.AddWithValue("@Allergy", obj.Allergies);
            


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

    public string UpdateDailyNurseNote(BELIntakeOutputChart obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_UpdateDailyNurseNote", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@NurseNoteId", obj.NurseNoteId);
            cmd.Parameters.AddWithValue("@DrId", obj.DrId);
            cmd.Parameters.AddWithValue("@DateInput", obj.DateInput);
            cmd.Parameters.AddWithValue("@TimeInput", obj.TimeInput);
            cmd.Parameters.AddWithValue("@Remark", obj.Remark);
            cmd.Parameters.AddWithValue("@UserId", obj.UserId);
            cmd.Parameters.AddWithValue("@BranchId", obj.BranchId);
            cmd.Parameters.AddWithValue("@UpdatedBy", obj.UpdatedBy);
            cmd.Parameters.AddWithValue("@FId", obj.FId);
            cmd.Parameters.AddWithValue("@Allergy", obj.Allergies);
            cmd.Parameters.AddWithValue("@PatregId", obj.Patregid);

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

    public string DeleteDailyNurseNote(int NurseNoteId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_DeleteNurseNote", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@NurseNoteId", NurseNoteId);
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

    public DataTable FillDailyNurseNote(BELIntakeOutputChart obj)//string patregId
    {
        DataTable dt = new DataTable();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;
            using (SqlConnection connection =
                      DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("Sp_FillDailyNurseNote", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PatRegId", obj.Patregid);
                    cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
                    cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);
                    cmd.Parameters.AddWithValue("@BranchId", obj.BranchId);
                    cmd.Parameters.AddWithValue("@FId", obj.FId);
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

    public BELIntakeOutputChart SelectDailyNurseNote(int NurseNoteId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_DailyNurseNoteSelectOne", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@NurseNoteId", NurseNoteId);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                
                objBELIO.DateInput = Convert.ToDateTime(sdr["DateInput"]);
                objBELIO.TimeInput = Convert.ToString(sdr["TimeInput"]);                
                objBELIO.Remark = Convert.ToString(sdr["NurseNote"]);
                objBELIO.UserId = Convert.ToInt32(sdr["UserId"]);
                objBELIO.UserName = Convert.ToString(sdr["Name"]);

               
            }
            return objBELIO;
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

    public void Alter_Vw_DailyNurseNote(BELIntakeOutputChart obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Alter_Vw_DailyNurseNote", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@PatregId", obj.Patregid);
            cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
            cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);

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

 //---------------------------------------------------------------------------

    public string InsertDailyDoctorNote(BELIntakeOutputChart obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_InsertDailyDoctorNote", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@PatregId", obj.Patregid);
            cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
            cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);
            cmd.Parameters.AddWithValue("@DrId", obj.DrId);
            cmd.Parameters.AddWithValue("@DateInput", obj.DateInput);
            cmd.Parameters.AddWithValue("@TimeInput", obj.TimeInput);
            cmd.Parameters.AddWithValue("@UserId", obj.UserId);
            cmd.Parameters.AddWithValue("@Remark", obj.Remark);
            cmd.Parameters.AddWithValue("@BranchId", obj.BranchId);
            cmd.Parameters.AddWithValue("@CreatedBy", obj.CreatedBy);
            cmd.Parameters.AddWithValue("@UpdatedBy", obj.UpdatedBy);
            cmd.Parameters.AddWithValue("@FId", obj.FId);


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

    public string UpdateDailyDoctorNote(BELIntakeOutputChart obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_UpdateDailyDoctorNote", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@DoctorNoteId", obj.DoctorNoteId);
            cmd.Parameters.AddWithValue("@DrId", obj.DrId);
            cmd.Parameters.AddWithValue("@DateInput", obj.DateInput);
            cmd.Parameters.AddWithValue("@TimeInput", obj.TimeInput);
            cmd.Parameters.AddWithValue("@Remark", obj.Remark);
            cmd.Parameters.AddWithValue("@UserId", obj.UserId);
            cmd.Parameters.AddWithValue("@BranchId", obj.BranchId);
            cmd.Parameters.AddWithValue("@UpdatedBy", obj.UpdatedBy);
            cmd.Parameters.AddWithValue("@FId", obj.FId);


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

    public string DeleteDailyDoctorNote(int DoctorNoteId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_DeleteDoctorNote", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@DoctorNoteId", DoctorNoteId);
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

    public DataTable FillDailyDoctorNote(BELIntakeOutputChart obj)//string patregId
    {
        DataTable dt = new DataTable();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;
            using (SqlConnection connection =
                      DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("Sp_FillDailyDoctorNote", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PatRegId", obj.Patregid);
                    cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
                    cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);
                    cmd.Parameters.AddWithValue("@BranchId", obj.BranchId);
                    cmd.Parameters.AddWithValue("@FId", obj.FId);
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

    public BELIntakeOutputChart SelectDailyDoctorNote(int DoctorNoteId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_DailyDoctorNoteSelectOne", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@DoctorNoteId", DoctorNoteId);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {

                objBELIO.DateInput = Convert.ToDateTime(sdr["DateInput"]);
                objBELIO.TimeInput = Convert.ToString(sdr["TimeInput"]);
                objBELIO.Remark = Convert.ToString(sdr["DoctorNote"]);
                objBELIO.UserId = Convert.ToInt32(sdr["UserId"]);
                objBELIO.UserName = Convert.ToString(sdr["Name"]);


            }
            return objBELIO;
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

    public void Alter_Vw_DailyDoctorNote(BELIntakeOutputChart obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Alter_Vw_DailyDoctorNote", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@PatregId", obj.Patregid);
            cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
            cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);

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

    //---------------------------------------------------------------------------
    public string InsertIVChart(BELIntakeOutputChart obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_InsertIVChart", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@PatregId", obj.Patregid);
            cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
            cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);
            cmd.Parameters.AddWithValue("@DrId", obj.DrId);
            cmd.Parameters.AddWithValue("@DateInput", obj.DateInput);
            cmd.Parameters.AddWithValue("@TimeInput", obj.TimeInput);
            cmd.Parameters.AddWithValue("@EndTime", obj.EndTime);
            cmd.Parameters.AddWithValue("@UserId", obj.UserId);
            cmd.Parameters.AddWithValue("@DrugName", obj.DrugName);
            cmd.Parameters.AddWithValue("@IVFluidName", obj.IvFluid);
            cmd.Parameters.AddWithValue("@BranchId", obj.BranchId);
            cmd.Parameters.AddWithValue("@CreatedBy", obj.CreatedBy);
            cmd.Parameters.AddWithValue("@UpdatedBy", obj.UpdatedBy);
            cmd.Parameters.AddWithValue("@FId", obj.FId);


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

    public string UpdateIVchart(BELIntakeOutputChart obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_UpdateIVChart", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@IVChartId", obj.IVChartId);
            cmd.Parameters.AddWithValue("@DrId", obj.DrId);
            cmd.Parameters.AddWithValue("@DateInput", obj.DateInput);
            cmd.Parameters.AddWithValue("@TimeInput", obj.TimeInput);
            cmd.Parameters.AddWithValue("@EndTime", obj.EndTime);
            cmd.Parameters.AddWithValue("@DrugName", obj.DrugName);
            cmd.Parameters.AddWithValue("@IvFluidName", obj.IvFluid);
            cmd.Parameters.AddWithValue("@UserId", obj.UserId);
            cmd.Parameters.AddWithValue("@BranchId", obj.BranchId);
            cmd.Parameters.AddWithValue("@UpdatedBy", obj.UpdatedBy);
            cmd.Parameters.AddWithValue("@FId", obj.FId);


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

    public string DeleteIVChart(int IVChartId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_DeleteIVChart", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@IVChartId", IVChartId);
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

    public DataTable FillIVChart(BELIntakeOutputChart obj)//string patregId
    {
        DataTable dt = new DataTable();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;
            using (SqlConnection connection =
                      DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("Sp_FillIVChart", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PatRegId", obj.Patregid);
                    cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
                    cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);
                    cmd.Parameters.AddWithValue("@BranchId", obj.BranchId);
                    cmd.Parameters.AddWithValue("@FId", obj.FId);
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

    public BELIntakeOutputChart SelectIVChart(int IVChartId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_IVChartSelectOne", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@IVChartId", IVChartId);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {

                objBELIO.DateInput = Convert.ToDateTime(sdr["DateInput"]);
                objBELIO.TimeInput = Convert.ToString(sdr["TimeInput"]);
                objBELIO.EndTime = Convert.ToString(sdr["EndTime"]);
                objBELIO.UserId = Convert.ToInt32(sdr["UserId"]);
                objBELIO.UserName = Convert.ToString(sdr["Name"]);
                objBELIO.DrugName = Convert.ToString(sdr["DrugName"]);
                objBELIO.IvFluid = Convert.ToString(sdr["IvFluidName"]);


            }
            return objBELIO;
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

    public void Alter_Vw_IVChart(BELIntakeOutputChart obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Alter_Vw_IVfluidChart", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@PatregId", obj.Patregid);
            cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
            cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);

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

    //-----------------------------------------------------------------------------------
    public string InsertPatTreatmentSheet(BELIntakeOutputChart obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_InsertPatTreatmentSheet", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@PatregId", obj.Patregid);
            cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
            cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);
            cmd.Parameters.AddWithValue("@DrId", obj.DrId);
            cmd.Parameters.AddWithValue("@DateInput", obj.DateInput);
            cmd.Parameters.AddWithValue("@TimeInput", obj.TimeInput);            
            cmd.Parameters.AddWithValue("@UserId", obj.UserId);
            cmd.Parameters.AddWithValue("@DrugId", obj.DrugId);
            cmd.Parameters.AddWithValue("@Remark", obj.Remark);
            cmd.Parameters.AddWithValue("@BranchId", obj.BranchId);
            cmd.Parameters.AddWithValue("@CreatedBy", obj.CreatedBy);
            cmd.Parameters.AddWithValue("@UpdatedBy", obj.UpdatedBy);
            cmd.Parameters.AddWithValue("@FId", obj.FId);
            cmd.Parameters.AddWithValue("@Qty", obj.Qty);
            cmd.Parameters.AddWithValue("@DrugName", obj.DrugName);
            cmd.Parameters.AddWithValue("@Routess", obj.Routess);
            

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

    public string UpdatePatTreatmentSheet(BELIntakeOutputChart obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_UpdatePatTreatmentSheet", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@PatTreatmentId", obj.PatTreatmentId);
            cmd.Parameters.AddWithValue("@DrId", obj.DrId);
            cmd.Parameters.AddWithValue("@DateInput", obj.DateInput);
            cmd.Parameters.AddWithValue("@TimeInput", obj.TimeInput);
            cmd.Parameters.AddWithValue("@Remark", obj.Remark);
            cmd.Parameters.AddWithValue("@UserId", obj.UserId);
            cmd.Parameters.AddWithValue("@BranchId", obj.BranchId);
            cmd.Parameters.AddWithValue("@UpdatedBy", obj.UpdatedBy);
            cmd.Parameters.AddWithValue("@Qty", obj.Qty);
            cmd.Parameters.AddWithValue("@DrugId", obj.DrugId);
            cmd.Parameters.AddWithValue("@DrugName", obj.DrugName);
            cmd.Parameters.AddWithValue("@FId", obj.FId);

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

    public string DeletePatTreatmentSheet(int PatTreatmentId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_DeletePatTreatmentSheet", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@PatTreatmentId", PatTreatmentId);
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

    public DataTable FillPatTreatmentSheet(BELIntakeOutputChart obj)//string patregId
    {
        DataTable dt = new DataTable();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;
            using (SqlConnection connection =
                      DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("Sp_FillPatTreatmentSheet", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PatRegId", obj.Patregid);
                    cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
                    cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);
                    cmd.Parameters.AddWithValue("@BranchId", obj.BranchId);
                    cmd.Parameters.AddWithValue("@FId", obj.FId);
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

    public BELIntakeOutputChart SelectPatTreatmentSheet(int PatTreatmentId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_PatTreatmentSheetSelectOne", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@PatTreatmentId", PatTreatmentId);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {

                objBELIO.DateInput = Convert.ToDateTime(sdr["DateInput"]);
                objBELIO.TimeInput = Convert.ToString(sdr["TimeInput"]);
              //  objBELIO.EndTime = Convert.ToString(sdr["EndTime"]);
                objBELIO.UserId = Convert.ToInt32(sdr["UserId"]);
                objBELIO.UserName = Convert.ToString(sdr["Name"]);
                objBELIO.DrugName = Convert.ToString(sdr["DrugName"]);
                objBELIO.Qty = Convert.ToString(sdr["Qty"]);
                objBELIO.Remark = Convert.ToString(sdr["Remark"]);
                objBELIO.DrugId = Convert.ToInt32(sdr["DrugId"]);
            }
            return objBELIO;
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

    public void Alter_Vw_PatTreatmentSheet(BELIntakeOutputChart obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Alter_Vw_PatTreatmentSheet", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@PatregId", obj.Patregid);
            cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
            cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);

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

    //--------------------------------------------------------------------------------------

    public string InsertDiabeticSheet(BELIntakeOutputChart obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_InsertDiabeticSheet", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@PatregId", obj.Patregid);
            cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
            cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);
            cmd.Parameters.AddWithValue("@DrId", obj.DrId);
            cmd.Parameters.AddWithValue("@DateInput", obj.DateInput);
            cmd.Parameters.AddWithValue("@TimeInput", obj.TimeInput);
            cmd.Parameters.AddWithValue("@UserId", obj.UserId);          
            cmd.Parameters.AddWithValue("@Remark", obj.Remark);
            cmd.Parameters.AddWithValue("@BranchId", obj.BranchId);
            cmd.Parameters.AddWithValue("@CreatedBy", obj.CreatedBy);
            cmd.Parameters.AddWithValue("@UpdatedBy", obj.UpdatedBy);
            cmd.Parameters.AddWithValue("@FId", obj.FId);
            cmd.Parameters.AddWithValue("@Value", obj.Value);
            cmd.Parameters.AddWithValue("@InformToDr", obj.InformToDr);
            cmd.Parameters.AddWithValue("@ActionTaken", obj.ActionTaken);
            cmd.Parameters.AddWithValue("@FastingType", obj.FastingType);

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

    public string UpdateDiabeticSheet(BELIntakeOutputChart obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_UpdateDiabeticSheet", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@DiabeticSheetId", obj.DiabeticSheetId);
            cmd.Parameters.AddWithValue("@DrId", obj.DrId);
            cmd.Parameters.AddWithValue("@DateInput", obj.DateInput);
            cmd.Parameters.AddWithValue("@TimeInput", obj.TimeInput);
            cmd.Parameters.AddWithValue("@Remark", obj.Remark);
            cmd.Parameters.AddWithValue("@UserId", obj.UserId);
            cmd.Parameters.AddWithValue("@BranchId", obj.BranchId);
            cmd.Parameters.AddWithValue("@UpdatedBy", obj.UpdatedBy);
            cmd.Parameters.AddWithValue("@Value", obj.Value);
            cmd.Parameters.AddWithValue("@InformToDr", obj.InformToDr);
            cmd.Parameters.AddWithValue("@ActionTaken", obj.ActionTaken);
            cmd.Parameters.AddWithValue("@FastingType", obj.FastingType);
            cmd.Parameters.AddWithValue("@FId", obj.FId);

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

    public string DeleteDiabeticSheet(int DiabeticSheetId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_DeleteDiabeticSheet", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@DiabeticSheetId", DiabeticSheetId);
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

    public DataTable FillDiabeticSheet(BELIntakeOutputChart obj)//string patregId
    {
        DataTable dt = new DataTable();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;
            using (SqlConnection connection =
                      DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("Sp_FillDiabeticSheet", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PatRegId", obj.Patregid);
                    cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
                    cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);
                    cmd.Parameters.AddWithValue("@BranchId", obj.BranchId);
                    cmd.Parameters.AddWithValue("@FId", obj.FId);
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

    public BELIntakeOutputChart SelectDiabeticSheet(int DiabeticSheetId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_DiabeticSheetSelectOne", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@DiabeticSheetId", DiabeticSheetId);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {

                objBELIO.DateInput = Convert.ToDateTime(sdr["DateInput"]);
                objBELIO.TimeInput = Convert.ToString(sdr["TimeInput"]);               
                objBELIO.UserId = Convert.ToInt32(sdr["UserId"]);
                objBELIO.UserName = Convert.ToString(sdr["Name"]);
                objBELIO.FastingType = Convert.ToString(sdr["FastingType"]);
                objBELIO.Value = Convert.ToSingle(sdr["Value"]);
                objBELIO.Remark = Convert.ToString(sdr["Remark"]);
                objBELIO.ActionTaken = Convert.ToString(sdr["ActionTaken"]);
                objBELIO.InformToDr = Convert.ToInt32(sdr["InformToDr"]);
                objBELIO.EmpName = Convert.ToString(sdr["EmpName"]);
            }
            return objBELIO;
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

    public void Alter_Vw_DiabeticSheet(BELIntakeOutputChart obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Alter_Vw_DiabeticSheet", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@PatregId", obj.Patregid);
            cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
            cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);

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

    //----------------------------------------------------------------------------------------

    public string InsertBloodTransfusion(BELIntakeOutputChart obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_InsertBloodTransfusion", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@PatregId", obj.Patregid);
            cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
            cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);
            cmd.Parameters.AddWithValue("@DrId", obj.DrId);
            cmd.Parameters.AddWithValue("@UserId", obj.UserId);
            cmd.Parameters.AddWithValue("@BranchId", obj.BranchId);
            cmd.Parameters.AddWithValue("@CreatedBy", obj.CreatedBy);
            cmd.Parameters.AddWithValue("@UpdatedBy", obj.UpdatedBy);
            cmd.Parameters.AddWithValue("@FId", obj.FId);
            cmd.Parameters.AddWithValue("@BloodGroup",obj.BloodGroup);
            cmd.Parameters.AddWithValue("@Indication",obj.Indication);
            cmd.Parameters.AddWithValue("@WholeBlood",obj.WholeBlood);	
            cmd.Parameters.AddWithValue("@PacketCells",obj.PacketCells);
            cmd.Parameters.AddWithValue("@Platelets",obj.Platelets);
            cmd.Parameters.AddWithValue("@Cryoprecipitate",obj.Cryoprecipitate);
            cmd.Parameters.AddWithValue("@FFP",obj.FFP);
            cmd.Parameters.AddWithValue("@ConsentTaken",obj.ConsentTaken);
            cmd.Parameters.AddWithValue("@DoctorOrder",obj.DoctorOrder);
            cmd.Parameters.AddWithValue("@PremedicationOrder",obj.PremedicationOrder);
            cmd.Parameters.AddWithValue("@PrevTransfusion",obj.PrevTransfusion);
            cmd.Parameters.AddWithValue("@PrevTransReaction",obj.PrevTransReaction);
            cmd.Parameters.AddWithValue("@UnitNo", obj.UnitNo);
            cmd.Parameters.AddWithValue("@DateInput", obj.DateInput);
            cmd.Parameters.AddWithValue("@TimeInput", obj.TimeInput);
            cmd.Parameters.AddWithValue("@CheckedBy", obj.CheckedBy);
            cmd.Parameters.AddWithValue("@StartedBy", obj.StartedBy);
            cmd.Parameters.AddWithValue("@Rate", obj.Rate);
            cmd.Parameters.AddWithValue("@StartTime", obj.StartTime);
            cmd.Parameters.AddWithValue("@TimeS", obj.TimeS);
            cmd.Parameters.AddWithValue("@T", obj.T);          
            cmd.Parameters.AddWithValue("@P",obj.P);
            cmd.Parameters.AddWithValue("@R",obj.R);
            cmd.Parameters.AddWithValue("@BP",obj.BP);	
            cmd.Parameters.AddWithValue("@TRDetails",obj.TRDetails);
            cmd.Parameters.AddWithValue("@FinishTime", obj.FinishTime);

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

    public string UpdateBloodTransfusion(BELIntakeOutputChart obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_UpdateBloodTransfusion", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@BloodTransId", obj.BloodTransId);
            cmd.Parameters.AddWithValue("@DrId", obj.DrId); 
            cmd.Parameters.AddWithValue("@UserId", obj.UserId);
            cmd.Parameters.AddWithValue("@BranchId", obj.BranchId);
            cmd.Parameters.AddWithValue("@UpdatedBy", obj.UpdatedBy);           
            cmd.Parameters.AddWithValue("@FId", obj.FId);
            cmd.Parameters.AddWithValue("@BloodGroup", obj.BloodGroup);
            cmd.Parameters.AddWithValue("@Indication", obj.Indication);
            cmd.Parameters.AddWithValue("@WholeBlood", obj.WholeBlood);
            cmd.Parameters.AddWithValue("@PacketCells", obj.PacketCells);
            cmd.Parameters.AddWithValue("@Platelets", obj.Platelets);
            cmd.Parameters.AddWithValue("@Cryoprecipitate", obj.Cryoprecipitate);
            cmd.Parameters.AddWithValue("@FFP", obj.FFP);
            cmd.Parameters.AddWithValue("@ConsentTaken", obj.ConsentTaken);
            cmd.Parameters.AddWithValue("@DoctorOrder", obj.DoctorOrder);
            cmd.Parameters.AddWithValue("@PremedicationOrder", obj.PremedicationOrder);
            cmd.Parameters.AddWithValue("@PrevTransfusion", obj.PrevTransfusion);
            cmd.Parameters.AddWithValue("@PrevTransReaction", obj.PrevTransReaction);
            cmd.Parameters.AddWithValue("@UnitNo", obj.UnitNo);
            cmd.Parameters.AddWithValue("@DateInput", obj.DateInput);
            cmd.Parameters.AddWithValue("@TimeInput", obj.TimeInput);
            
            cmd.Parameters.AddWithValue("@CheckedBy", obj.CheckedBy);
            cmd.Parameters.AddWithValue("@StartedBy", obj.StartedBy);
            cmd.Parameters.AddWithValue("@Rate", obj.Rate);
            cmd.Parameters.AddWithValue("@StartTime", obj.StartTime);
            cmd.Parameters.AddWithValue("@TimeS", obj.TimeS);
            cmd.Parameters.AddWithValue("@T", obj.T);
            cmd.Parameters.AddWithValue("@P", obj.P);
            cmd.Parameters.AddWithValue("@R", obj.R);
            cmd.Parameters.AddWithValue("@BP", obj.BP);
            cmd.Parameters.AddWithValue("@TRDetails", obj.TRDetails);
            cmd.Parameters.AddWithValue("@FinishTime", obj.FinishTime);

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

    public string DeleteBloodTransfusion(int BloodTransId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_DeleteBloodTransfusion", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@BloodTransId", BloodTransId);
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

    public DataTable FillBloodTransfusion(BELIntakeOutputChart obj)//string patregId
    {
        DataTable dt = new DataTable();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;
            using (SqlConnection connection =
                      DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("Sp_FillBloodTransfusion", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PatRegId", obj.Patregid);
                    cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
                    cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);
                    cmd.Parameters.AddWithValue("@BranchId", obj.BranchId);
                    cmd.Parameters.AddWithValue("@FId", obj.FId);
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

    public BELIntakeOutputChart SelectBloodTransfusion(int BloodTransId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_BloodTransfusionSelectOne", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@BloodTransId", BloodTransId);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {

                objBELIO.DateInput = Convert.ToDateTime(sdr["DateInput"]);
                objBELIO.TimeInput = Convert.ToString(sdr["TimeInput"]);
                objBELIO.UserId = Convert.ToInt32(sdr["UserId"]);
                objBELIO.UserName = Convert.ToString(sdr["Name"]);

                 objBELIO.BloodGroup = Convert.ToString(sdr["BloodGroup"]);
                objBELIO.Indication = Convert.ToString(sdr["Indication"]);
                     objBELIO.WholeBlood=Convert.ToBoolean(sdr["WholeBlood"]);
                objBELIO.Cryoprecipitate=Convert.ToBoolean(sdr["Cryoprecipitate"]);
                objBELIO.PacketCells=Convert.ToBoolean(sdr["PacketCells"]);
                objBELIO.FFP=Convert.ToBoolean(sdr["FFP"]);
                objBELIO.Platelets=Convert.ToBoolean(sdr["Platelets"]);

                objBELIO.ConsentTaken = Convert.ToString(sdr["ConsentTaken"]);
                objBELIO.DoctorOrder = Convert.ToString(sdr["DoctorOrder"]);
                objBELIO.PremedicationOrder = Convert.ToString(sdr["PremedicationOrder"]);
                objBELIO.PrevTransfusion = Convert.ToString(sdr["PrevTransfusion"]);
                objBELIO.PrevTransReaction = Convert.ToString(sdr["PrevTransReaction"]);

                objBELIO.UnitNo = Convert.ToString(sdr["UnitNo"]);

                objBELIO.CheckedBy = Convert.ToInt32(sdr["CheckedBy"]);
                objBELIO.StartedBy = Convert.ToInt32(sdr["StartedBy"]);
                objBELIO.StartTime = Convert.ToString(sdr["StartTime"]);
                objBELIO.TimeS = Convert.ToString(sdr["TimeS"]);

                objBELIO.Rate = Convert.ToString(sdr["Rate"]);
                objBELIO.T = Convert.ToString(sdr["T"]);
                objBELIO.P = Convert.ToString(sdr["P"]);
                objBELIO.R = Convert.ToString(sdr["R"]);
                objBELIO.BP = Convert.ToString(sdr["BP"]);
                objBELIO.FinishTime = Convert.ToString(sdr["FinishTime"]);
                objBELIO.TRDetails = Convert.ToString(sdr["TRDetails"]);     
        
            }
            return objBELIO;
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

    public void Alter_Vw_BloodTransfusion(BELIntakeOutputChart obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Alter_Vw_BloodTransfusion", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@PatregId", obj.Patregid);
            cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
            cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);

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
    public DataSet FillNurse()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("Sp_FillNurseNames", con);

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


    public string InsertPatientHisForm(BELIntakeOutputChart obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Insert_PatientHisForm", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@PatregId", obj.Patregid);
            cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
            cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);
            cmd.Parameters.AddWithValue("@DrId", obj.DrId);
            cmd.Parameters.AddWithValue("@CaseNo", obj.CaseNo);
            cmd.Parameters.AddWithValue("@IsMedicalHis", obj.CheckMedHis);
            cmd.Parameters.AddWithValue("@MedicalHis", obj.MedHis);
            cmd.Parameters.AddWithValue("@IsMedication", obj.CheckMedication);
            cmd.Parameters.AddWithValue("@MedicationHistory", obj.Medication);
            cmd.Parameters.AddWithValue("@IsSurgical", obj.Checksurghis);
            cmd.Parameters.AddWithValue("@SurgicalHistory", obj.surghis);
            cmd.Parameters.AddWithValue("@IsGynae", obj.CheckGyna);
            cmd.Parameters.AddWithValue("@GynaeHistory", obj.Gyna);

            cmd.Parameters.AddWithValue("@IsAllergy", obj.CheckAllergy);
            cmd.Parameters.AddWithValue("@AllergyHistory", obj.Allergy);

            cmd.Parameters.AddWithValue("@IsFamily", obj.Checkfamily);
            cmd.Parameters.AddWithValue("@FamilyHistory", obj.FamilyHistory);

            cmd.Parameters.AddWithValue("@IsSmoking", obj.Checksmoking);
            cmd.Parameters.AddWithValue("@SmokingDuration", obj.smokingDurat);
            cmd.Parameters.AddWithValue("@SmokingQty", obj.smokingQty);

            cmd.Parameters.AddWithValue("@IsAlco", obj.CheckAlco);
            cmd.Parameters.AddWithValue("@AlcoDuration", obj.AlcoDurat);
            cmd.Parameters.AddWithValue("@AlcoQty", obj.AlcoQty);

            cmd.Parameters.AddWithValue("@BranchId", obj.BranchId);
            cmd.Parameters.AddWithValue("@CreatedBy", obj.CreatedBy);
          
            cmd.Parameters.AddWithValue("@FId", obj.FId);
            cmd.Parameters.AddWithValue("@PhId", obj.PhId);


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

    public string InsertPhysicalExam(BELIntakeOutputChart obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Insert_PhysicalExam", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@PatregId", obj.Patregid);
            cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
            cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);
            cmd.Parameters.AddWithValue("@Bedsore", obj.Bedsore);
            cmd.Parameters.AddWithValue("@Dentures", obj.Dentures);
            cmd.Parameters.AddWithValue("@Spectacles", obj.Spectacles);
            cmd.Parameters.AddWithValue("@CheckPhInj", obj.CheckPhInj);
            cmd.Parameters.AddWithValue("@PhysicalInjuries", obj.PhysicalInjuries);
            cmd.Parameters.AddWithValue("@CheckFoleys", obj.CheckFoleys);
            cmd.Parameters.AddWithValue("@CheckNGTube", obj.CheckNGTube);
            cmd.Parameters.AddWithValue("@CheckIntraCath", obj.CheckIntraCath);
            cmd.Parameters.AddWithValue("@PhysicalSize", obj.PhysicalSize);
            cmd.Parameters.AddWithValue("@CheckCentralLine", obj.CheckCentralLine);

            cmd.Parameters.AddWithValue("@CentralLine", obj.CentralLine);
            cmd.Parameters.AddWithValue("@CheckImpDevice", obj.CheckImpDevice);

            cmd.Parameters.AddWithValue("@ImpDevice", obj.ImpDevice);
            cmd.Parameters.AddWithValue("@CheckJewellery", obj.CheckJewellery);

            cmd.Parameters.AddWithValue("@CheckJewellerytofami", obj.CheckJewellerytofami);
            cmd.Parameters.AddWithValue("@CheckPatfamily", obj.CheckPatfamily);
            cmd.Parameters.AddWithValue("@signature", obj.signature);

            cmd.Parameters.AddWithValue("@Relationship", obj.Relationship);
            cmd.Parameters.AddWithValue("@OtherRemark", obj.OtherRemark);
            cmd.Parameters.AddWithValue("@NurseRemark", obj.NurseRemark);

            cmd.Parameters.AddWithValue("@BranchId", obj.BranchId);
            cmd.Parameters.AddWithValue("@CreatedBy", obj.CreatedBy);
           
            cmd.Parameters.AddWithValue("@FId", obj.FId);
            cmd.Parameters.AddWithValue("@PhId", obj.PhId);


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


    public DataTable BindPhysicalExamination(BELIntakeOutputChart obj)//string patregId
    {
        DataTable dt = new DataTable();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;
            using (SqlConnection connection =
                      DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("Sp_FillPhysicalExam", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PatRegId", obj.Patregid);
                    cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
                    cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);
                    cmd.Parameters.AddWithValue("@BranchId", obj.BranchId);
                    cmd.Parameters.AddWithValue("@FId", obj.FId);
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

    public BELIntakeOutputChart GetPhEx(int Phid,int BranchId,int FId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetPhysicalExam", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@Phid", Phid);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.Parameters.AddWithValue("@FId", FId);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {

                objBELIO.Bedsore = Convert.ToBoolean(sdr["Bedsore"]);
                objBELIO.Dentures = Convert.ToBoolean(sdr["Dentures"]);
                objBELIO.Spectacles = Convert.ToBoolean(sdr["Spectacles"]);
                objBELIO.CheckPhInj = Convert.ToBoolean(sdr["CheckPhInj"]);
                objBELIO.PhysicalInjuries = Convert.ToString(sdr["PhysicalInjuries"]);
                objBELIO.CheckFoleys = Convert.ToBoolean(sdr["CheckFoleys"]);
                objBELIO.CheckNGTube = Convert.ToBoolean(sdr["CheckNGTube"]);

                objBELIO.CheckIntraCath = Convert.ToBoolean(sdr["CheckIntraCath"]);
                objBELIO.PhysicalSize = Convert.ToString(sdr["PhysicalSize"]);
                objBELIO.CheckCentralLine = Convert.ToBoolean(sdr["CheckCentralLine"]);

                objBELIO.CentralLine = Convert.ToString(sdr["CentralLine"]);
                objBELIO.CheckImpDevice = Convert.ToBoolean(sdr["CheckImpDevice"]);
                objBELIO.ImpDevice = Convert.ToString(sdr["ImpDevice"]);

                objBELIO.CheckJewellery = Convert.ToBoolean(sdr["CheckJewellery"]);
                objBELIO.CheckJewellerytofami = Convert.ToBoolean(sdr["CheckJewellerytofami"]);
                objBELIO.CheckPatfamily = Convert.ToBoolean(sdr["CheckPatfamily"]);

                objBELIO.signature = Convert.ToString(sdr["signature"]);
                objBELIO.Relationship = Convert.ToString(sdr["Relationship"]);
                objBELIO.OtherRemark = Convert.ToString(sdr["OtherRemark"]);
                objBELIO.NurseRemark = Convert.ToString(sdr["NurseRemark"]);


            }
            return objBELIO;
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

    public void Alter_Vw_GetPatientPhiscalExam(BELIntakeOutputChart obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Vw_GetPatientPhiscalExam", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@PatregId", obj.Patregid);
            cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
            cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);

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

    public DataTable GetPatientHistory(BELIntakeOutputChart obj)//string patregId
    {
        DataTable dt = new DataTable();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;
            using (SqlConnection connection =
                      DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("Sp_GetPatientHistoryForm", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PatRegId", obj.Patregid);
                    cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
                    cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);
                    cmd.Parameters.AddWithValue("@BranchId", obj.BranchId);
                    cmd.Parameters.AddWithValue("@FId", obj.FId);
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

    public BELIntakeOutputChart GetPHF(int Phid, int BranchId, int FId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetatientHisForm", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@Phid", Phid);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.Parameters.AddWithValue("@FId", FId);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {

                objBELIO.CheckMedHis = Convert.ToBoolean(sdr["IsMedicalHis"]);
                objBELIO.MedHis = Convert.ToString(sdr["MedicalHis"]);
                objBELIO.CheckMedication = Convert.ToBoolean(sdr["IsMedication"]);
                objBELIO.Medication = Convert.ToString(sdr["MedicationHistory"]);

                objBELIO.surghis = Convert.ToString(sdr["SurgicalHistory"]);
                objBELIO.Checksurghis = Convert.ToBoolean(sdr["IsSurgical"]);
                objBELIO.CheckGyna = Convert.ToBoolean(sdr["IsGynae"]);

                objBELIO.Gyna = Convert.ToString(sdr["GynaeHistory"]);
                objBELIO.Allergy = Convert.ToString(sdr["AllergyHistory"]);
                objBELIO.CheckAllergy = Convert.ToBoolean(sdr["IsAllergy"]);

                objBELIO.FamilyHistory = Convert.ToString(sdr["FamilyHistory"]);
                objBELIO.Checkfamily = Convert.ToBoolean(sdr["IsFamily"]);
                objBELIO.smokingDurat = Convert.ToString(sdr["SmokingDuration"]);

                objBELIO.Checksmoking = Convert.ToBoolean(sdr["IsSmoking"]);

                objBELIO.smokingQty = Convert.ToString(sdr["SmokingQty"]);
                objBELIO.CheckAlco= Convert.ToBoolean(sdr["IsAlco"]);

                objBELIO.AlcoDurat = Convert.ToString(sdr["AlcoDuration"]);
                objBELIO.AlcoQty = Convert.ToString(sdr["AlcoQty"]);
               


            }
            return objBELIO;
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


    public void Alter_Vw_PatientHistory(BELIntakeOutputChart obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Vw_GetPatientPatientHistoryForm", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@PatregId", obj.Patregid);
            cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
            cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);

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


    public string InsertVitalSheetsForm(BELIntakeOutputChart obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Insert_VitalSheet", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@PatregId", obj.Patregid);
            cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
            cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);
            cmd.Parameters.AddWithValue("@Temprature", obj.Temprature);
          
            cmd.Parameters.AddWithValue("@BP", obj.BPVital);
            cmd.Parameters.AddWithValue("@HR", obj.HR);
            cmd.Parameters.AddWithValue("@RR", obj.RR);
            cmd.Parameters.AddWithValue("@Spo2", obj.Spo2);
            cmd.Parameters.AddWithValue("@Inspired", obj.Inspired);
            cmd.Parameters.AddWithValue("@RRScore", obj.RRScore);
            cmd.Parameters.AddWithValue("@UrineScore", obj.UrineScore);
            cmd.Parameters.AddWithValue("@CNScore", obj.CNScore);

            cmd.Parameters.AddWithValue("@DateInput", obj.DateInput);
            cmd.Parameters.AddWithValue("@TimeInput", obj.TimeInput);

            cmd.Parameters.AddWithValue("@BranchId", obj.BranchId);
            cmd.Parameters.AddWithValue("@CreatedBy", obj.CreatedBy);

            cmd.Parameters.AddWithValue("@FId", obj.FId);
            cmd.Parameters.AddWithValue("@VId", obj.VId);
            cmd.Parameters.AddWithValue("@VitalRemark", obj.VitalRemark);

            cmd.Parameters.AddWithValue("@Systolic", obj.Systolic);
            cmd.Parameters.AddWithValue("@Diastolic", obj.Diastolic);


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


    public string Insert_AdditionalMonitorSheet(BELIntakeOutputChart obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Insert_Vital_AdditionalMonotorSheet", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@PatregId", obj.Patregid);
            cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
            cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);
            cmd.Parameters.AddWithValue("@BloodPRessure", obj.BloodPRessure);

            cmd.Parameters.AddWithValue("@Temp", obj.Temp);
            cmd.Parameters.AddWithValue("@Pulse", obj.Pulse);
            cmd.Parameters.AddWithValue("@RespRate", obj.RespRate);
            cmd.Parameters.AddWithValue("@Spo2", obj.Spo2);
            cmd.Parameters.AddWithValue("@BloodSugar", obj.BloodSugar);
            cmd.Parameters.AddWithValue("@UrinaryOutput", obj.UrinaryOutput);
            cmd.Parameters.AddWithValue("@FHR", obj.FHR);
            cmd.Parameters.AddWithValue("@MISC", obj.MISC);
            cmd.Parameters.AddWithValue("@Contractions", obj.Contractions);
            cmd.Parameters.AddWithValue("@NamePosition", obj.NamePosition);
            cmd.Parameters.AddWithValue("@DateInput", obj.DateInput);
            cmd.Parameters.AddWithValue("@TimeInput", obj.TimeInput);

            cmd.Parameters.AddWithValue("@BranchId", obj.BranchId);
            cmd.Parameters.AddWithValue("@CreatedBy", obj.CreatedBy);

            cmd.Parameters.AddWithValue("@FId", obj.FId);
            cmd.Parameters.AddWithValue("@VId", obj.VId);
            cmd.Parameters.AddWithValue("@VitalRemark", obj.VitalRemark);

          


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


    public BELIntakeOutputChart GetVitalSheet(int Vid, int BranchId, int FId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetVitalSignForm_Edit", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@Vid", Vid);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.Parameters.AddWithValue("@FId", FId);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                objBELIO.DateInput = Convert.ToDateTime(sdr["DateInput"]);
                objBELIO.TimeInput = Convert.ToString(sdr["TimeInput"]);

                objBELIO.Temprature = Convert.ToString(sdr["Temprature"]);
                objBELIO.BPVital = Convert.ToString(sdr["BP"]);
                objBELIO.HR = Convert.ToString(sdr["HR"]);
                objBELIO.RR = Convert.ToString(sdr["RR"]);

                objBELIO.Spo2 = Convert.ToString(sdr["Spo2"]);
                objBELIO.Inspired = Convert.ToString(sdr["Inspired"]);
                objBELIO.RRScore = Convert.ToString(sdr["RRScore"]);

                objBELIO.UrineScore = Convert.ToString(sdr["UrineScore"]);
                objBELIO.CNScore = Convert.ToString(sdr["CNScore"]);
                objBELIO.VitalRemark = Convert.ToString(sdr["VitalRemark"]);

                objBELIO.Systolic = Convert.ToString(sdr["Systolic"]);
                objBELIO.Diastolic = Convert.ToString(sdr["Diastolic"]);



            }
            return objBELIO;
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



    public DataTable GetVitalSheet(BELIntakeOutputChart obj)//string patregId
    {
        DataTable dt = new DataTable();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;
            using (SqlConnection connection =
                      DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("Sp_GetVitalSignForm", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PatRegId", obj.Patregid);
                    cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
                    cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);
                    cmd.Parameters.AddWithValue("@BranchId", obj.BranchId);
                    cmd.Parameters.AddWithValue("@FId", obj.FId);
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

    public DataTable GetAdditionalVitalSheet(BELIntakeOutputChart obj)//string patregId
    {
        DataTable dt = new DataTable();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;
            using (SqlConnection connection =
                      DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("Sp_GetAdditionalVitalSignForm", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PatRegId", obj.Patregid);
                    cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
                    cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);
                    cmd.Parameters.AddWithValue("@BranchId", obj.BranchId);
                    cmd.Parameters.AddWithValue("@FId", obj.FId);
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


    public string Insert_TheatreCheckList(BELIntakeOutputChart obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_Insert_TheatreCheckList", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@PatregId", obj.Patregid);
            cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
            cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);
            cmd.Parameters.AddWithValue("@Allergies", obj.Allergies);
            cmd.Parameters.AddWithValue("@SignconsentForm", obj.SignconsentForm);
            cmd.Parameters.AddWithValue("@NameLabels", obj.NameLabels);
            cmd.Parameters.AddWithValue("@BloodWork", obj.BloodWork);

            cmd.Parameters.AddWithValue("@IVAccess", obj.IVAccess);
            cmd.Parameters.AddWithValue("@IVAntiBiotics", obj.IVAntiBiotics);
            cmd.Parameters.AddWithValue("@PainSupposotory", obj.PainSupposotory);
            cmd.Parameters.AddWithValue("@DENTURES", obj.DENTURES);
            cmd.Parameters.AddWithValue("@HAIRCLIPS", obj.HAIRCLIPS);
            cmd.Parameters.AddWithValue("@JEWELLERY", obj.JEWELLERY);
            cmd.Parameters.AddWithValue("@UNDERWEAR", obj.UNDERWEAR);

            cmd.Parameters.AddWithValue("@PROSTHESIS", obj.PROSTHESIS);
            cmd.Parameters.AddWithValue("@SPECTACLES", obj.SPECTACLES);
            cmd.Parameters.AddWithValue("@VitalSigns", obj.VitalSigns);
            cmd.Parameters.AddWithValue("@UrinAnalysis", obj.UrinAnalysis);
            cmd.Parameters.AddWithValue("@TreatmentSheet", obj.TreatmentSheet);
            cmd.Parameters.AddWithValue("@IVFluids", obj.IVFluids);
            cmd.Parameters.AddWithValue("@ECG", obj.ECG);
            cmd.Parameters.AddWithValue("@Orthopaedic", obj.Orthopaedic);

            cmd.Parameters.AddWithValue("@Remarks", obj.Remark);
            cmd.Parameters.AddWithValue("@BranchId", obj.BranchId);
            cmd.Parameters.AddWithValue("@CreatedBy", obj.CreatedBy);
           


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


    public string Delete_TheatreCheckListe(int TCheckId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Delete_Theatre_CheckList", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@TCheckId", TCheckId);
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

    public DataTable Fill_Theatre_CheckList(BELIntakeOutputChart obj)//string patregId
    {
        DataTable dt = new DataTable();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;
            using (SqlConnection connection =
                      DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("Sp_FillTheatre_CheckList", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PatRegId", obj.Patregid);
                    cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
                    cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);
                    cmd.Parameters.AddWithValue("@BranchId", obj.BranchId);
                    cmd.Parameters.AddWithValue("@FId", obj.FId);
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


    public void Alter_Vw_Theatre_CheckList(BELIntakeOutputChart obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Alter_Vw_Theatre_CheckList", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@PatregId", obj.Patregid);
            cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
            cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);

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


    public string Insert_NurseShiftReport(BELIntakeOutputChart obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_InsertNurseShiftReport", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@PatregId", obj.Patregid);
            cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
            cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);
            cmd.Parameters.AddWithValue("@CurrentComplaint", obj.CurrentComplaint);
            cmd.Parameters.AddWithValue("@AdmissionDiagnosis", obj.AdmissionDiagnosis);
            cmd.Parameters.AddWithValue("@T", obj.T);
            cmd.Parameters.AddWithValue("@P", obj.P);
            cmd.Parameters.AddWithValue("@R", obj.R);

            cmd.Parameters.AddWithValue("@BP", obj.BP);
            cmd.Parameters.AddWithValue("@SPO2", obj.SPO2);
            cmd.Parameters.AddWithValue("@RA", obj.RA);

            cmd.Parameters.AddWithValue("@LOC", obj.LOC);
            cmd.Parameters.AddWithValue("@RBS", obj.RBS);
            cmd.Parameters.AddWithValue("@Diet", obj.Diet);

            cmd.Parameters.AddWithValue("@FullCode", obj.FullCode);
            cmd.Parameters.AddWithValue("@ComfortMeasures", obj.ComfortMeasures);
            cmd.Parameters.AddWithValue("@DNR", obj.DNR);

            cmd.Parameters.AddWithValue("@PDM", obj.PDM);
            cmd.Parameters.AddWithValue("@PHTN", obj.PHTN);
            cmd.Parameters.AddWithValue("@PCancer", obj.PCancer);

            cmd.Parameters.AddWithValue("@PastMedicalHistory", obj.PastMedicalHistory);
            cmd.Parameters.AddWithValue("@Allergies", obj.Allergies);
            cmd.Parameters.AddWithValue("@PastSurgeryHistory", obj.PastSurgeryHistory);

            cmd.Parameters.AddWithValue("@FDM", obj.FDM);
            cmd.Parameters.AddWithValue("@FHTN", obj.FHTN);
            cmd.Parameters.AddWithValue("@FCancer", obj.FCancer);

            cmd.Parameters.AddWithValue("@FamilyHistory", obj.FamilyHistory);
            cmd.Parameters.AddWithValue("@Smoker", obj.Smoker);
            cmd.Parameters.AddWithValue("@SmokerRemark", obj.SmokerRemark);

            cmd.Parameters.AddWithValue("@Alcohol", obj.Alcohol);
            cmd.Parameters.AddWithValue("@AlcoholRemark", obj.AlcoholRemark);
            cmd.Parameters.AddWithValue("@Druguse", obj.Druguse);

            cmd.Parameters.AddWithValue("@DruguseRemark", obj.DruguseRemark);
            cmd.Parameters.AddWithValue("@OtherRemark", obj.OtherRemark);
            cmd.Parameters.AddWithValue("@Medications", obj.Medications);

            cmd.Parameters.AddWithValue("@IVSite", obj.IVSite);
            cmd.Parameters.AddWithValue("@DrainsCatheters", obj.DrainsCatheters);
            cmd.Parameters.AddWithValue("@Proceduress", obj.Proceduress);

            cmd.Parameters.AddWithValue("@AbnormalAssessments", obj.AbnormalAssessments);
            cmd.Parameters.AddWithValue("@PainScore", obj.PainScore);
            cmd.Parameters.AddWithValue("@Intervention", obj.Intervention);

            cmd.Parameters.AddWithValue("@Safetys", obj.Safetys);
            cmd.Parameters.AddWithValue("@RecommendationNeeded", obj.RecommendationNeeded);
            cmd.Parameters.AddWithValue("@RecommendationConcerned", obj.RecommendationConcerned);

            cmd.Parameters.AddWithValue("@PendingLabs", obj.PendingLabs);
            cmd.Parameters.AddWithValue("@AwareofNext", obj.AwareofNext);
           


            cmd.Parameters.AddWithValue("@BranchId", obj.BranchId);
            cmd.Parameters.AddWithValue("@CreatedBy", obj.CreatedBy);
       


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

    public string Delete_NurseShift(int ShiftId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Delete_ShiftId", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@ShiftId", ShiftId);
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

    public DataTable FillNurseShift(BELIntakeOutputChart obj)//string patregId
    {
        DataTable dt = new DataTable();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;
            using (SqlConnection connection =
                      DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("Sp_FillNurseShiftReport", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PatRegId", obj.Patregid);
                    cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
                    cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);
                    cmd.Parameters.AddWithValue("@BranchId", obj.BranchId);
                    cmd.Parameters.AddWithValue("@FId", obj.FId);
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


    public string InsertBloodSugar(BELIntakeOutputChart obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_InsertBloodSugar", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@PatregId", obj.Patregid);
            cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
            cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);
            cmd.Parameters.AddWithValue("@BloodSugarOrder", obj.BloodSugarOrder);
            cmd.Parameters.AddWithValue("@BDate", obj.BDate);
            cmd.Parameters.AddWithValue("@BTime", obj.BTime);
            cmd.Parameters.AddWithValue("@BloodSugar", obj.BloodSugar);
            cmd.Parameters.AddWithValue("@Insulin", obj.Insulin);
            cmd.Parameters.AddWithValue("@Remarks", obj.Remark);
            cmd.Parameters.AddWithValue("@BranchId", obj.BranchId);
            cmd.Parameters.AddWithValue("@CreatedBy", obj.CreatedBy);
          


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

    public DataTable Fill_BloodSugarRecord(BELIntakeOutputChart obj)//string patregId
    {
        DataTable dt = new DataTable();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;
            using (SqlConnection connection =
                      DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("SP_GetBloodSugarRecord", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PatRegId", obj.Patregid);
                    cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
                    cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);
                   
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


    public string Delete_BloodSugarRecord(int ID)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_DeleteBloodSugar", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@ID", ID);
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


    public string InsertInvestigation_Record(BELIntakeOutputChart obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_InsertInvestigation_Record", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@PatregId", obj.Patregid);
            cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
            cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);
            
            cmd.Parameters.AddWithValue("@BDate", obj.BDate);
            cmd.Parameters.AddWithValue("@BTime", obj.BTime);
            cmd.Parameters.AddWithValue("@Investigation", obj.Investigation);
            cmd.Parameters.AddWithValue("@Cost", obj.Cost);
            cmd.Parameters.AddWithValue("@Remarks", obj.Remark);
            cmd.Parameters.AddWithValue("@BranchId", obj.BranchId);
            cmd.Parameters.AddWithValue("@CreatedBy", obj.CreatedBy);



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

    public string Delete_Investigation_Record(int ID)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_DeleteInvestigation_Record", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@ID", ID);
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

    public DataTable Fill_Investigation_Record(BELIntakeOutputChart obj)//string patregId
    {
        DataTable dt = new DataTable();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;
            using (SqlConnection connection =
                      DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("SP_GetInvestigation_Record", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PatRegId", obj.Patregid);
                    cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
                    cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);

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


    public string Insert_MonitorRecords(BELIntakeOutputChart obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_InsertMonitorUsed_Record", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@PatregId", obj.Patregid);
            cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
            cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);
            if (obj.MonAttDate == Date.getMinDate())
                cmd.Parameters.Add(new SqlParameter("@MonAttDate", SqlDbType.DateTime)).Value = DBNull.Value;
            else
                cmd.Parameters.Add(new SqlParameter("@MonAttDate", SqlDbType.DateTime)).Value = obj.MonAttDate;

            cmd.Parameters.AddWithValue("@MonAttTime", obj.MonAttTime);
            cmd.Parameters.AddWithValue("@AttachedBy", obj.AttachedBy);

            if (obj.MonDetDate == Date.getMinDate())
                cmd.Parameters.Add(new SqlParameter("@MonDetDate", SqlDbType.DateTime)).Value = DBNull.Value;
            else
                cmd.Parameters.Add(new SqlParameter("@MonDetDate", SqlDbType.DateTime)).Value = obj.MonDetDate;

            cmd.Parameters.AddWithValue("@MonDetTime", obj.MonDetTime);
            cmd.Parameters.AddWithValue("@DetectedBy", obj.DetectedBy);           
            cmd.Parameters.AddWithValue("@BranchId", obj.BranchId);
          



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

    public DataTable Fill_Monitor_Record(BELIntakeOutputChart obj)//string patregId
    {
        DataTable dt = new DataTable();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;
            using (SqlConnection connection =
                      DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("SP_GetMonitorUsed_Record", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PatRegId", obj.Patregid);
                    cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
                    cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);

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

    public string Insert_OxygenRecords(BELIntakeOutputChart obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_InsertOxygenUsed_Record", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@PatregId", obj.Patregid);
            cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
            cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);
            if (obj.OxyStartDate == Date.getMinDate())
                cmd.Parameters.Add(new SqlParameter("@OxyStartDate", SqlDbType.DateTime)).Value = DBNull.Value;
            else
                cmd.Parameters.Add(new SqlParameter("@OxyStartDate", SqlDbType.DateTime)).Value = obj.OxyStartDate;

            cmd.Parameters.AddWithValue("@OxyStartTime", obj.OxyStartTime);
            cmd.Parameters.AddWithValue("@LMP", obj.LMP);
            cmd.Parameters.AddWithValue("@AttachedBy", obj.AttachedBy);

            if (obj.OxydisDate == Date.getMinDate())
                cmd.Parameters.Add(new SqlParameter("@OxydisDate", SqlDbType.DateTime)).Value = DBNull.Value;
            else
                cmd.Parameters.Add(new SqlParameter("@OxydisDate", SqlDbType.DateTime)).Value = obj.OxydisDate;

            cmd.Parameters.AddWithValue("@OxydisTime", obj.OxydisTime);
            cmd.Parameters.AddWithValue("@DiscontinuedBy", obj.DiscontinuedBy);
            cmd.Parameters.AddWithValue("@BranchId", obj.BranchId);




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

    public DataTable Fill_Oxygen_Record(BELIntakeOutputChart obj)//string patregId
    {
        DataTable dt = new DataTable();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;
            using (SqlConnection connection =
                      DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("SP_GetOxygenUsed_Record", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PatRegId", obj.Patregid);
                    cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
                    cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);

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


    public void Alter_NurseShiftList(BELIntakeOutputChart obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Alter_Vw_NurseShiftReport", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@PatregId", obj.Patregid);
            cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
            cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);
            cmd.Parameters.AddWithValue("@ShiftId", obj.ShiftId);

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

    public void Alter_Vw_Oxygen_Report(BELIntakeOutputChart obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Alter_Vw_OxygenUsed_Record", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@PatregId", obj.Patregid);
            cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
            cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);

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

    public void Alter_Vw_Monitor_Report(BELIntakeOutputChart obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Alter_Vw_MonitorUsed_Record", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@PatregId", obj.Patregid);
            cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
            cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);

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


    public void Alter_InvestigationList_Report(BELIntakeOutputChart obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Alter_Vw_Investigation_Record", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@PatregId", obj.Patregid);
            cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
            cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);
            cmd.Parameters.AddWithValue("@Id", obj.Id);

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

    public void Alter_BloodSugar_Report(BELIntakeOutputChart obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Alter_Vw_BloodSugar_Record", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@PatregId", obj.Patregid);
            cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
            cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);
            cmd.Parameters.AddWithValue("@Id", obj.Id);

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


    public string Insert_TwoHourlyTurningChart(BELIntakeOutputChart obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_InsertTwoHourlyRepositioning_Record", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@PatregId", obj.Patregid);
            cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
            cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);

            cmd.Parameters.AddWithValue("@PressureRelieving", obj.PressureRelieving);
            cmd.Parameters.AddWithValue("@Cushion", obj.Cushion);
            cmd.Parameters.AddWithValue("@HeelPads", obj.HeelPads);
            cmd.Parameters.AddWithValue("@EnterDate", obj.EntryDate);
            cmd.Parameters.AddWithValue("@EnterTime", obj.EnterTime);

            cmd.Parameters.AddWithValue("@TDate", obj.BDate);
            cmd.Parameters.AddWithValue("@TTime", obj.BTime);
            cmd.Parameters.AddWithValue("@LeftSide", obj.LeftSide);
            cmd.Parameters.AddWithValue("@RightSide", obj.RightSide);

            cmd.Parameters.AddWithValue("@Supine", obj.Supine);
            cmd.Parameters.AddWithValue("@HeadTilt", obj.HeadTilt);
            cmd.Parameters.AddWithValue("@InChari", obj.InChari);
            cmd.Parameters.AddWithValue("@SkinIntegrity", obj.SkinIntegrity);

            cmd.Parameters.AddWithValue("@Comments", obj.Remark);

            cmd.Parameters.AddWithValue("@DiscussWithPat", obj.DiscussWithPat);
            cmd.Parameters.AddWithValue("@DiscussWithPat_Remark", obj.DiscussWithPat_Remark);
            cmd.Parameters.AddWithValue("@DiscussWithRelative", obj.DiscussWithRelative);
            cmd.Parameters.AddWithValue("@DiscussWithRelative_Remark", obj.DiscussWithRelative_Remark);


            cmd.Parameters.AddWithValue("@BranchId", obj.BranchId);
            cmd.Parameters.AddWithValue("@CreatedBy", obj.CreatedBy);



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

    public DataTable Fill_TwoWayRepositoryChart(BELIntakeOutputChart obj)//string patregId
    {
        DataTable dt = new DataTable();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;
            using (SqlConnection connection =
                      DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("Sp_FillTwoHourlyRepositioning", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PatRegId", obj.Patregid);
                    cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
                    cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);
                    cmd.Parameters.AddWithValue("@BranchId", obj.BranchId);
                    cmd.Parameters.AddWithValue("@FId", obj.FId);
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

    public void Alter_TwoWayRepositoryChart(BELIntakeOutputChart obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Alter_Vw_TwoHourlyRepositioning_Record", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@PatregId", obj.Patregid);
            cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
            cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);
            cmd.Parameters.AddWithValue("@Id", obj.Id);

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

    public DataTable FillPatTreatmentSheet_OPDEMER(BELIntakeOutputChart obj)//string patregId
    {
        DataTable dt = new DataTable();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;
            using (SqlConnection connection =
                      DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("Sp_FillPatTreatmentSheet", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PatRegId", obj.Patregid);
                    cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
                    cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);
                    cmd.Parameters.AddWithValue("@BranchId", obj.BranchId);
                    cmd.Parameters.AddWithValue("@FId", obj.FId);
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

    public DataTable BindAdmissionSheet(BELIntakeOutputChart obj)//string patregId
    {
        DataTable dt = new DataTable();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;
            using (SqlConnection connection =
                      DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("Sp_FillOnIPD_AdmissionDetails", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PatRegId", obj.Patregid);
                    cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
                    cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);
                    cmd.Parameters.AddWithValue("@BranchId", obj.BranchId);
                    cmd.Parameters.AddWithValue("@FId", obj.FId);
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
    public void Alter_Vw_Dialysis_Report(BELIntakeOutputChart obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Alter_DialysisReport", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@PatregId", obj.Patregid);
            cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
            cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);

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