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
public class BELColposcopy
{
    DALColposcopy ObjDALANC = new DALColposcopy();
    public BELColposcopy()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataTable GetAllColposcopy(DALColposcopy obj)//string patregId
    {
        DataTable dt = new DataTable();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;
            using (SqlConnection connection =
                      DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("SP_GetColposcopy", connection))
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
                        //connection.Open();
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
    public string Insert_Colposcopy(DALColposcopy obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_Insert_Colposcopy", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@Patregid", obj.Patregid);
            cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
            cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);
            cmd.Parameters.AddWithValue("@ColposcopyDate", obj.ColposcopyDate);

            cmd.Parameters.AddWithValue("@PapsmearReport", obj.PapsmearReport);

            cmd.Parameters.AddWithValue("@Ect_Cervix", obj.Ect_Cervix);
            cmd.Parameters.AddWithValue("@SCJ", obj.SCJ);
            cmd.Parameters.AddWithValue("@TransitionZone", obj.TransitionZone);

            cmd.Parameters.AddWithValue("@Biopsysites", obj.Biopsysites);
            cmd.Parameters.AddWithValue("@ActoWhiteArea", obj.ActoWhiteArea);
    
            cmd.Parameters.AddWithValue("@Branchid", obj.BranchId);
            cmd.Parameters.AddWithValue("@FID", obj.FId);
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