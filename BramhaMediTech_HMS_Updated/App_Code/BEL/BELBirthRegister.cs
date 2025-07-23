using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

/// <summary>
/// Summary description for BELPostpartumExamination
/// </summary>
public class BELBirthRegister
{
    DALBirthRegister ObjDALBR = new DALBirthRegister();
    public BELBirthRegister()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataTable GetAllBirthRegister(DALBirthRegister obj)//string patregId
    {
        DataTable dt = new DataTable();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;
            using (SqlConnection connection =
                      DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetBirthRegister", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Patregid", obj.Patregid);
                    cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
                    cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);
                    cmd.Parameters.AddWithValue("@Branchid", obj.BranchId);                  
                    cmd.Parameters.AddWithValue("@FID", obj.FId);
                    connection.Open();

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        connection.Open();
                        sda.Fill(dt);
                        connection.Close();
                        connection.Dispose();
                    }
                }
            }
        }
        catch (Exception)
        {
        }
        return dt;
    }
    public string InsertBirthRegister(DALBirthRegister obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_InsertBirthRegisterToPatient", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@Patregid", obj.Patregid);
            cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
            cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);
            cmd.Parameters.AddWithValue("@BabyName", obj.BabyName);
            cmd.Parameters.AddWithValue("@MotherName", obj.MotherName);
            cmd.Parameters.AddWithValue("@FatherName", obj.FatherName);
            cmd.Parameters.AddWithValue("@BirthTime", obj.BirthTime);
            cmd.Parameters.AddWithValue("@BirthDate", obj.BirthDate);

            cmd.Parameters.AddWithValue("@Sex", obj.Sex);
            cmd.Parameters.AddWithValue("@ModeOFDelivery", obj.ModeOFDelivery);
            cmd.Parameters.AddWithValue("@WaitInGram", obj.WaitInGram);
            cmd.Parameters.AddWithValue("@Comment", obj.Comment);                       
            
            cmd.Parameters.AddWithValue("@Branchid", obj.BranchId);
            cmd.Parameters.AddWithValue("@CreatedBy", obj.CreatedBy);          

            cmd.Parameters.AddWithValue("@FID", obj.FId);
           

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