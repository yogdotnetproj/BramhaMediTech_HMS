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
public class BELFamilyPlanningExam
{
    DALFamilyPlanningExam ObjDALFPE = new DALFamilyPlanningExam();
    public BELFamilyPlanningExam()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataTable GetAllFamilyPlanning(DALFamilyPlanningExam obj)//string patregId
    {
        DataTable dt = new DataTable();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;
            using (SqlConnection connection =
                      DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetFamilyPlanning", connection))
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
                        connection.Close(); connection.Dispose();
                    }
                }
            }
        }
        catch (Exception)
        {
        }
        return dt;
    }
    public string InsertFamilyPlanningExam(DALFamilyPlanningExam obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_InsertFamilyPlanningExamToPatient", con);
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
             cmd.Parameters.AddWithValue("@FatherAChild", obj.FatherAChild);
             cmd.Parameters.AddWithValue("@FatherNevChild", obj.FatherNevChild);

             cmd.Parameters.AddWithValue("@IsOccuption", obj.IsOccuption);
             cmd.Parameters.AddWithValue("@OccitpionRemark", obj.OccitpionRemark);
             cmd.Parameters.AddWithValue("@TabaccoUse", obj.TabaccoUse);
             cmd.Parameters.AddWithValue("@TabaccoRemark", obj.TabaccoRemark);

             cmd.Parameters.AddWithValue("@DrugUse", obj.DrugUse);
             cmd.Parameters.AddWithValue("@DrugUseRemark", obj.DrugUseRemark);
             cmd.Parameters.AddWithValue("@MenstrualCyclesRegular", obj.MenstrualCyclesRegular);
             cmd.Parameters.AddWithValue("@MenstrualCyclesRemark", obj.MenstrualCyclesRemark);
             cmd.Parameters.AddWithValue("@MenstrualCyclesIrregular", obj.MenstrualCyclesIrregular);

             cmd.Parameters.AddWithValue("@MenstrualCyclesIrregularRemark", obj.MenstrualCyclesIrregularRemark);
             cmd.Parameters.AddWithValue("@CoitalFrequency", obj.CoitalFrequency);
             cmd.Parameters.AddWithValue("@CoitalFrequencyRemark", obj.CoitalFrequencyRemark);
             cmd.Parameters.AddWithValue("@Dysmenorrhea", obj.Dysmenorrhea);
             cmd.Parameters.AddWithValue("@DysmenorrheaRemark", obj.DysmenorrheaRemark);

             cmd.Parameters.AddWithValue("@PelvicPain", obj.PelvicPain);
             cmd.Parameters.AddWithValue("@PelvicPainRemark", obj.PelvicPainRemark);
             cmd.Parameters.AddWithValue("@HSGResult", obj.HSGResult);
             cmd.Parameters.AddWithValue("@HSGResultRemark", obj.HSGResultRemark);
             cmd.Parameters.AddWithValue("@SemenAnalysis", obj.SemenAnalysis);

             cmd.Parameters.AddWithValue("@SemenAnalysisRemark", obj.SemenAnalysisRemark);
             cmd.Parameters.AddWithValue("@Clomid", obj.Clomid);
             cmd.Parameters.AddWithValue("@ClomidRemark", obj.ClomidRemark);
             cmd.Parameters.AddWithValue("@GnRHAgonists", obj.GnRHAgonists);
             cmd.Parameters.AddWithValue("@GnRHAgonistsRemark", obj.GnRHAgonistsRemark);
             cmd.Parameters.AddWithValue("@IUI", obj.IUI);
             cmd.Parameters.AddWithValue("@IUIRemark", obj.IUIRemark);

             cmd.Parameters.AddWithValue("@IVF", obj.IVF);
             cmd.Parameters.AddWithValue("@IVFRemark", obj.IVFRemark);
             cmd.Parameters.AddWithValue("@Hysteroscopy", obj.Hysteroscopy);
             cmd.Parameters.AddWithValue("@HysteroscopyRemark", obj.HysteroscopyRemark);
             cmd.Parameters.AddWithValue("@Laparoscopy", obj.Laparoscopy);
             cmd.Parameters.AddWithValue("@LaparoscopyRemark", obj.LaparoscopyRemark);
           

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