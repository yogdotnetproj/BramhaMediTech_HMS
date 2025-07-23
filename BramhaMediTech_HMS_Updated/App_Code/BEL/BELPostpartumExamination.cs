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
public class BELPostpartumExamination
{
    DALPostpartumExamination ObjDALPPE = new DALPostpartumExamination();
	public BELPostpartumExamination()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataTable GetAllPostpartumExam(DALPostpartumExamination obj)//string patregId
    {
        DataTable dt = new DataTable();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;
            using (SqlConnection connection =
                      DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetAllPostpartumExamination", connection))
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
    public string InsertPostpartumExam(DALPostpartumExamination obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_InsertPostpartumExaminationToPatient", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@Patregid", obj.Patregid);
            cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
            cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);
            cmd.Parameters.AddWithValue("@DouSmoke", obj.DouSmoke);

            cmd.Parameters.AddWithValue("@SmokeRemark", obj.SmokeRemark);
             cmd.Parameters.AddWithValue("@SmokeDateQuite", obj.SmokeDateQuite);
            cmd.Parameters.AddWithValue("@Depression", obj.Depression);
            cmd.Parameters.AddWithValue("@DepressionRemark", obj.DepressionRemark);

            cmd.Parameters.AddWithValue("@Feeding", obj.Feeding);
            cmd.Parameters.AddWithValue("@FeedingRemark", obj.FeedingRemark);
            cmd.Parameters.AddWithValue("@Bleeding", obj.Bleeding);
            cmd.Parameters.AddWithValue("@BleedingRemark", obj.BleedingRemark);

            cmd.Parameters.AddWithValue("@BrestExam", obj.BrestExam);
            cmd.Parameters.AddWithValue("@BrestRemark", obj.BrestRemark);
            cmd.Parameters.AddWithValue("@BrestComplant", obj.BrestComplant);
            cmd.Parameters.AddWithValue("@CSection", obj.CSection);

            cmd.Parameters.AddWithValue("@CSectionRemark", obj.CSectionRemark);
            cmd.Parameters.AddWithValue("@Episiotomy", obj.Episiotomy);
            cmd.Parameters.AddWithValue("@EpisiotomyRemark", obj.EpisiotomyRemark);
            cmd.Parameters.AddWithValue("@Uterus", obj.Uterus);

            cmd.Parameters.AddWithValue("@UterusRemark", obj.UterusRemark);
            cmd.Parameters.AddWithValue("@BirthControl", obj.BirthControl);
            cmd.Parameters.AddWithValue("@BirthControlRemark", obj.BirthControlRemark);
            cmd.Parameters.AddWithValue("@GeneralRemark", obj.GeneralRemark);

            cmd.Parameters.AddWithValue("@Branchid", obj.BranchId);
            cmd.Parameters.AddWithValue("@CreatedBy", obj.CreatedBy);

            cmd.Parameters.AddWithValue("@UpdatedBy", obj.UpdatedBy);

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


    public string Insert_MedicalInsuranceClaim(DALPostpartumExamination obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_Insert_MedicalInsuranceClaim", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@Patregid", obj.Patregid);
            cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
            cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);
            cmd.Parameters.AddWithValue("@InsuranceCompName", obj.InsuranceCompName);
            cmd.Parameters.AddWithValue("@DrId", obj.DrId);

            cmd.Parameters.AddWithValue("@DateofConsultant", obj.DateofConsultant);
            cmd.Parameters.AddWithValue("@NameofEmployer", obj.NameofEmployer);
            cmd.Parameters.AddWithValue("@NameofEmployee", obj.NameofEmployee);
            cmd.Parameters.AddWithValue("@CertificateNo", obj.CertificateNo);

            cmd.Parameters.AddWithValue("@Age", obj.Age);
            cmd.Parameters.AddWithValue("@RelationshipPatToEmployee", obj.RelationshipPatToEmployee);
            cmd.Parameters.AddWithValue("@Accidentoccur", obj.Accidentoccur);
            cmd.Parameters.AddWithValue("@Injuryorsickness", obj.Injuryorsickness);

            cmd.Parameters.AddWithValue("@Illnessorcondition", obj.Illnessorcondition);
            cmd.Parameters.AddWithValue("@patientcovered", obj.patientcovered);
            cmd.Parameters.AddWithValue("@Duetopregnancy", obj.Duetopregnancy);
            cmd.Parameters.AddWithValue("@Similarondition", obj.Similarondition);

            cmd.Parameters.AddWithValue("@DiagnosisofDoctor", obj.DiagnosisofDoctor);
            cmd.Parameters.AddWithValue("@MedicationPrescribed", obj.MedicationPrescribed);
            cmd.Parameters.AddWithValue("@TestPrescribed", obj.TestPrescribed);
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
}