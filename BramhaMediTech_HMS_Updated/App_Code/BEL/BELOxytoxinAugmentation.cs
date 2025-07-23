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
public class BELOxytoxinAugmentation
{
    DALOxytoxinAugmentation ObjDALANC = new DALOxytoxinAugmentation();
    public BELOxytoxinAugmentation()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataTable GetAllOxytoxinAugmentation(DALOxytoxinAugmentation obj)//string patregId
    {
        DataTable dt = new DataTable();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;
            using (SqlConnection connection =
                      DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("SP_GetOxytoxinAugmentationr", connection))
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
    public string Insert_OxytoxinAugmentation(DALOxytoxinAugmentation obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_InsertOxytoxinAugmentation", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@Patregid", obj.Patregid);
            cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
            cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);
            cmd.Parameters.AddWithValue("@OxytoxinType", obj.OxytoxinType);

            cmd.Parameters.AddWithValue("@OxytoxinDate", obj.OxytoxinDate);

            cmd.Parameters.AddWithValue("@OxytoxinTablet", obj.OxytoxinTablet);
            cmd.Parameters.AddWithValue("@OxytoxinTablet1", obj.OxytoxinTablet1);
            cmd.Parameters.AddWithValue("@OxytoxinIncorporate", obj.OxytoxinIncorporate);

            cmd.Parameters.AddWithValue("@OxytoxinStartAt", obj.OxytoxinStartAt);
            cmd.Parameters.AddWithValue("@OxytoxinIncreaseBy", obj.OxytoxinIncreaseBy);
            cmd.Parameters.AddWithValue("@OxytoxinIncreaseBy_1", obj.OxytoxinIncreaseBy_1);
            cmd.Parameters.AddWithValue("@OxytoxinNotes", obj.OxytoxinNotes);

           
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