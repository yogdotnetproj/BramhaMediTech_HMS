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
public class BELANCExamination
{
    DALANCExamination ObjDALANC = new DALANCExamination();
    public BELANCExamination()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataTable GetAllANC(DALANCExamination obj)//string patregId
    {
        DataTable dt = new DataTable();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;
            using (SqlConnection connection =
                      DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetAllANC", connection))
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
    public string InsertANCExam(DALANCExamination obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_InsertANCExaminationToPatient", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@Patregid", obj.Patregid);
            cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
            cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);
            cmd.Parameters.AddWithValue("@LMPDate", obj.LMPDate);
            if (obj.EstDeliveryDate == Date.getMinDate())
            {
                cmd.Parameters.Add(new SqlParameter("@EstDeliveryDate", SqlDbType.DateTime)).Value = DBNull.Value;
            }
            else
            {
                cmd.Parameters.AddWithValue("@EstDeliveryDate", obj.EstDeliveryDate);
            }
            cmd.Parameters.AddWithValue("@FundelHeight", obj.FundelHeight);
            cmd.Parameters.AddWithValue("@Gestation", obj.Gestation);
            cmd.Parameters.AddWithValue("@FotealMovement", obj.FotealMovement);

            cmd.Parameters.AddWithValue("@Parity", obj.Parity);
            cmd.Parameters.AddWithValue("@FeatelHEarthBeat", obj.FeatelHEarthBeat);
            cmd.Parameters.AddWithValue("@TT1", obj.TT1);
            cmd.Parameters.AddWithValue("@TT2", obj.TT2);

            cmd.Parameters.AddWithValue("@IPT1", obj.IPT1);
            cmd.Parameters.AddWithValue("@IPT2", obj.IPT2);
            cmd.Parameters.AddWithValue("@HIV", obj.HIV);
            cmd.Parameters.AddWithValue("@HB", obj.HB);

            cmd.Parameters.AddWithValue("@BloodGroup", obj.BloodGroup);
            cmd.Parameters.AddWithValue("@SyphilisTest", obj.SyphilisTest);
            cmd.Parameters.AddWithValue("@Urinalysis", obj.Urinalysis);
            cmd.Parameters.AddWithValue("@UltrasoundScan", obj.UltrasoundScan);

            cmd.Parameters.AddWithValue("@BPD", obj.BPD);
             cmd.Parameters.AddWithValue("@FL", obj.FL);
             cmd.Parameters.AddWithValue("@HL", obj.HL);
             cmd.Parameters.AddWithValue("@HC", obj.HC);

             cmd.Parameters.AddWithValue("@AC", obj.AC);
             cmd.Parameters.AddWithValue("@Estimatedfoetalsize", obj.Estimatedfoetalsize);
             cmd.Parameters.AddWithValue("@EstimatedfoetalWidth", obj.EstimatedfoetalWidth);
             cmd.Parameters.AddWithValue("@Complant", obj.Complant);
             cmd.Parameters.AddWithValue("@Conclusion", obj.Conclusion);
            
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