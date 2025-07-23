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
public class BELGynology_UterineInsemination
{
    DALGynology_UterineInsemination ObjDALANC = new DALGynology_UterineInsemination();
    public BELGynology_UterineInsemination()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataTable GetIntraUterineInsemination(DALGynology_UterineInsemination obj)//string patregId
    {
        DataTable dt = new DataTable();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;
            using (SqlConnection connection =
                      DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("SP_GetIntraUterineInsemination", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Patregid", obj.Patregid);
                    cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
                    cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);
                    cmd.Parameters.AddWithValue("@Branchid", obj.BranchId);
                    
                    connection.Open();

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                      //  connection.Open();
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
    public string InsertUterinelnemination(DALGynology_UterineInsemination obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_Insert_IntraUterineInsemination", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@Patregid", obj.Patregid);
            cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
            cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);
            cmd.Parameters.AddWithValue("@LMPDate", obj.LastLMP);

            cmd.Parameters.AddWithValue("@LMPRemark", obj.LMPRemark);

            cmd.Parameters.AddWithValue("@Clomifene", obj.Clomifene);
            cmd.Parameters.AddWithValue("@LetroZole", obj.LetroZole);
            cmd.Parameters.AddWithValue("@Metformin", obj.Metformin);

            cmd.Parameters.AddWithValue("@Inj_FSH", obj.Inj_FSH);
            cmd.Parameters.AddWithValue("@FollCareDate", obj.FollCareDate);
            cmd.Parameters.AddWithValue("@FollicareDay", obj.FollicareDay);

            cmd.Parameters.AddWithValue("@FolliclesRightOvary", obj.FolliclesRightOvary);
            cmd.Parameters.AddWithValue("@FolliclesLiftOvary", obj.FolliclesLiftOvary);
            cmd.Parameters.AddWithValue("@Endometrial", obj.Endometrial);

            cmd.Parameters.AddWithValue("@FolliclesPlan", obj.FolliclesPlan);
            cmd.Parameters.AddWithValue("@FolliclesRemark", obj.FolliclesRemark);
            cmd.Parameters.AddWithValue("@FolliclesTrigger", obj.FolliclesTrigger);

            cmd.Parameters.AddWithValue("@IUIDate", obj.IUIDate);
            cmd.Parameters.AddWithValue("@Motility", obj.Motility);
            cmd.Parameters.AddWithValue("@LutealSupport", obj.LutealSupport);

            cmd.Parameters.AddWithValue("@FolliclesCount", obj.FolliclesCount);
            cmd.Parameters.AddWithValue("@FolliclesComments", obj.FolliclesComments);
            
            
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