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
public class BELHIVCounterExamination
{
    DALHIVCounterExamination ObjDALANC = new DALHIVCounterExamination();
    public BELHIVCounterExamination()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataTable GetAllHIVCounter(DALHIVCounterExamination obj)//string patregId
    {
        DataTable dt = new DataTable();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;
            using (SqlConnection connection =
                      DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetAllHIVCounter", connection))
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
    public string InsertHIVCounter(DALHIVCounterExamination obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_InsertHIVEncounterExaminationToPatient", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@Patregid", obj.Patregid);
            cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
            cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);
            cmd.Parameters.AddWithValue("@PatientAdult", obj.PatientAdult);

            cmd.Parameters.AddWithValue("@MTCTPluse", obj.MTCTPluse);

            cmd.Parameters.AddWithValue("@Married", obj.Married);
            cmd.Parameters.AddWithValue("@DiscloseToHubby", obj.DiscloseToHubby);
            cmd.Parameters.AddWithValue("@Numberofwives", obj.Numberofwives);

            cmd.Parameters.AddWithValue("@NumberofChildren", obj.NumberofChildren);
            cmd.Parameters.AddWithValue("@Divorced", obj.Divorced);
            cmd.Parameters.AddWithValue("@AgeofFirstchild", obj.AgeofFirstchild);
            cmd.Parameters.AddWithValue("@AgeofLastchild", obj.AgeofLastchild);

            cmd.Parameters.AddWithValue("@SpouseDead", obj.SpouseDead);
            cmd.Parameters.AddWithValue("@SuspicionHIVcauseofdead", obj.SuspicionHIVcauseofdead);
            cmd.Parameters.AddWithValue("@SexualpartnerdiedofHIV", obj.SexualpartnerdiedofHIV);
            cmd.Parameters.AddWithValue("@SpouseawareofHIV", obj.SpouseawareofHIV);

            cmd.Parameters.AddWithValue("@SexPartnerOutsideMarraige", obj.SexPartnerOutsideMarraige);
            cmd.Parameters.AddWithValue("@SpouseSexOutsideMarraige", obj.SpouseSexOutsideMarraige);
            cmd.Parameters.AddWithValue("@SexuallyActivity6Month", obj.SexuallyActivity6Month);
            cmd.Parameters.AddWithValue("@AlwaysuseCondom", obj.AlwaysuseCondom);

            cmd.Parameters.AddWithValue("@NumberOfPartner", obj.NumberOfPartner);
            cmd.Parameters.AddWithValue("@HIVTheraphy", obj.HIVTheraphy);
            cmd.Parameters.AddWithValue("@Comments", obj.Comments);
            
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