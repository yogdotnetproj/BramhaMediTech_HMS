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
public class BELBreastLumpExamination
{
    DALBreastLumpExamination ObjDALBLE = new DALBreastLumpExamination();
    public BELBreastLumpExamination()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataTable GetAllBLE(DALBreastLumpExamination obj)//string patregId
    {
        DataTable dt = new DataTable();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;
            using (SqlConnection connection =
                      DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetAllBreastLumpExamination", connection))
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
    public string InsertBrestLumpExam(DALBreastLumpExamination obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_InsertBreastLumpExaminationToPatient", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@Patregid", obj.Patregid);
            cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
            cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);
            cmd.Parameters.AddWithValue("@DouSmoke", obj.DouSmoke);

            cmd.Parameters.AddWithValue("@SmokeRemark", obj.SmokeRemark);
             cmd.Parameters.AddWithValue("@SmokeDateQuite", obj.SmokeDateQuite);
             cmd.Parameters.AddWithValue("@HCG", obj.HCG);
             cmd.Parameters.AddWithValue("@Leukocytes", obj.Leukocytes);

             cmd.Parameters.AddWithValue("@Nitrite", obj.Nitrite);
             cmd.Parameters.AddWithValue("@Protein", obj.Protein);
             cmd.Parameters.AddWithValue("@Glucose", obj.Glucose);
             cmd.Parameters.AddWithValue("@Blood", obj.Blood);

             cmd.Parameters.AddWithValue("@PH", obj.PH);
             cmd.Parameters.AddWithValue("@SpecificGravity", obj.SpecificGravity);
             cmd.Parameters.AddWithValue("@Ketone", obj.Ketone);
             cmd.Parameters.AddWithValue("@Urobilinogen", obj.Urobilinogen);

             cmd.Parameters.AddWithValue("@Biliruben", obj.Biliruben);
             cmd.Parameters.AddWithValue("@Remarks", obj.Remarks);
             cmd.Parameters.AddWithValue("@HPIComment", obj.HPIComment);
             cmd.Parameters.AddWithValue("@LeftBrestComplant", obj.LeftBrestComplant);

             cmd.Parameters.AddWithValue("@LeftBrestComplantDuration", obj.LeftBrestComplantDuration);
             cmd.Parameters.AddWithValue("@LeftSoftCystic", obj.LeftSoftCystic);
             cmd.Parameters.AddWithValue("@LeftSoftCysticComment", obj.LeftSoftCysticComment);
             cmd.Parameters.AddWithValue("@LeftFirm", obj.LeftFirm);

             cmd.Parameters.AddWithValue("@LeftFirmComment", obj.LeftFirmComment);
             cmd.Parameters.AddWithValue("@LeftMobile", obj.LeftMobile);
             cmd.Parameters.AddWithValue("@LeftMobileComment", obj.LeftMobileComment);
             cmd.Parameters.AddWithValue("@LeftPreMenopausal", obj.LeftPreMenopausal);
             cmd.Parameters.AddWithValue("@LeftPostMenopausal", obj.LeftPostMenopausal);

             cmd.Parameters.AddWithValue("@RightBrestComplant", obj.RightBrestComplant);
             cmd.Parameters.AddWithValue("@RightBrestComplantDuration", obj.RightBrestComplantDuration);
             cmd.Parameters.AddWithValue("@RightSoftCystic", obj.RightSoftCystic);
             cmd.Parameters.AddWithValue("@RightSoftCysticComment", obj.RightSoftCysticComment);
             cmd.Parameters.AddWithValue("@RightFirm", obj.RightFirm);
             cmd.Parameters.AddWithValue("@RightFirmComment", obj.RightFirmComment);
             cmd.Parameters.AddWithValue("@RightMobile", obj.RightMobile);
             cmd.Parameters.AddWithValue("@RightMobileComment", obj.RightMobileComment);
             cmd.Parameters.AddWithValue("@RightPreMenopausal", obj.RightPreMenopausal);
             cmd.Parameters.AddWithValue("@RightPostMenopausal", obj.RightPostMenopausal);

             cmd.Parameters.AddWithValue("@Fibrocystic", obj.Fibrocystic);
             cmd.Parameters.AddWithValue("@Clinicallyfeels", obj.Clinicallyfeels);
             cmd.Parameters.AddWithValue("@ClinicallySuspicious", obj.ClinicallySuspicious);
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
}