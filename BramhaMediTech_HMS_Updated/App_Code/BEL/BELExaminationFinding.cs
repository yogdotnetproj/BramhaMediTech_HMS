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
public class BELExaminationFinding
{
    DALExaminationFinding ObjDALANC = new DALExaminationFinding();
    public BELExaminationFinding()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataTable GetAllGynology_ExaminationFinding(DALExaminationFinding obj)//string patregId
    {
        DataTable dt = new DataTable();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;
            using (SqlConnection connection =
                      DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("SP_GetGynology_ExaminationFinding", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Patregid", obj.Patregid);
                    cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
                    cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);
                    cmd.Parameters.AddWithValue("@Branchid", obj.BranchId);
                    cmd.Parameters.AddWithValue("@FID", obj.FId);
                   // connection.Open();

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
    public string InsertGynology_ExaminationFinding(DALExaminationFinding obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_InsertGynology_ExaminationFinding", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@Patregid", obj.Patregid);
            cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
            cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);
            cmd.Parameters.AddWithValue("@Mass", obj.Mass);

            cmd.Parameters.AddWithValue("@Tenderness", obj.Tenderness);

            cmd.Parameters.AddWithValue("@Size", obj.Size);
            cmd.Parameters.AddWithValue("@Warts", obj.Warts);
            cmd.Parameters.AddWithValue("@Herpetic", obj.Herpetic);

            cmd.Parameters.AddWithValue("@Others", obj.Others);
            cmd.Parameters.AddWithValue("@CervixHealthy", obj.CervixHealthy);
            cmd.Parameters.AddWithValue("@Notes", obj.Notes);
            cmd.Parameters.AddWithValue("@Polyp", obj.Polyp);

            cmd.Parameters.AddWithValue("@UterusSize", obj.UterusSize);
            cmd.Parameters.AddWithValue("@UterusWeek", obj.UterusWeek);
            cmd.Parameters.AddWithValue("@Position", obj.Position);
            cmd.Parameters.AddWithValue("@IsTenderness", obj.IsTenderness);

            cmd.Parameters.AddWithValue("@ISMass", obj.ISMass);
            cmd.Parameters.AddWithValue("@Medications", obj.Medications);
            //cmd.Parameters.AddWithValue("@SurgicalAdvice", obj.SurgicalAdvice);
            
            
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

    public string InsertGynology_ExaminationSurgicalAdvics(DALExaminationFinding obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("sp_InsertExaminationSurgeryAdvice", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@Patregid", obj.Patregid);
            cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
            cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);
           
            cmd.Parameters.AddWithValue("@SurgicalAdvice", obj.SurgicalAdvice);
            cmd.Parameters.AddWithValue("@SurgeryId", obj.SurgeryId);

            cmd.Parameters.AddWithValue("@Branchid", obj.BranchId);
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

    public DataTable Get_SurgicalAdvice(int Branchid)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_GetSurgicalAdvice", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Branchid", Branchid);

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