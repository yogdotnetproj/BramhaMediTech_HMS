using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for BELPostpartumExamination
/// </summary>
public class BELGeneralGynology
{
    DALGeneralGynology ObjDALANC = new DALGeneralGynology();
    public BELGeneralGynology()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataTable Get_GeneralGynology(DALGeneralGynology obj)//string patregId
    {
        DataTable dt = new DataTable();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;
            using (SqlConnection connection =
                      DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("SP_GetGeneralGynaecology", connection))
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
    public string InsertGeneralGynaclogy(DALGeneralGynology obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_InsertGeneralGynacology", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@Patregid", obj.Patregid);
            cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
            cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);
            cmd.Parameters.AddWithValue("@Duration_Days", obj.Duration_Days);

            cmd.Parameters.AddWithValue("@Duration_Week", obj.Duration_Week);

            cmd.Parameters.AddWithValue("@Duration_Months", obj.Duration_Months);
            cmd.Parameters.AddWithValue("@Duration_Years", obj.Duration_Years);
            cmd.Parameters.AddWithValue("@Parity", obj.Parity);

            //if (obj.LastLMP != null)
            //{
            //    cmd.Parameters.AddWithValue("@LastLMP", DateTime.ParseExact(obj.LastLMP, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            //}
            cmd.Parameters.AddWithValue("@LastLMP", obj.LastLMP);
            cmd.Parameters.AddWithValue("@Note", obj.Note);
            cmd.Parameters.AddWithValue("@PastHistory", obj.PastHistory);
            
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


    public string InsertGynology_GeneralComplants(DALGeneralGynology obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("sp_InsertGeneralComplants", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@Patregid", obj.Patregid);
            cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
            cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);

            cmd.Parameters.AddWithValue("@CompliantName", obj.CompliantName);
            cmd.Parameters.AddWithValue("@CompliantId", obj.CompliantId);

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

    public DataTable Get_Template(int Branchid)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_GetTemplateName", con);
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

    public DataTable Get_AssignTemplate(int Branchid, int Patregid, int OpdNo, int IpdNo)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_GetAssignTemplateToPatients", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Branchid", Branchid);
        cmd.Parameters.AddWithValue("@Patregid", Patregid);
        cmd.Parameters.AddWithValue("@OpdNo", OpdNo);
        cmd.Parameters.AddWithValue("@IpdNo", IpdNo);

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

    public string Insert_CaseSheet( int Patregid,int OPDNo, int IPDNo,  string CreatedBy)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("sp_Insert_CaseGeneration", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@Patregid", Patregid);
            cmd.Parameters.AddWithValue("@OPDNo", OPDNo);
            cmd.Parameters.AddWithValue("@IPDNo", IPDNo);
           
            cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);




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

    public string Insert_CaseSheetTOTemplate(int Patregid, int OPDNo, int IPDNo, int TempId, string TempName, string CreatedBy)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("sp_Insert_CaseAssignToTemplate", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@Patregid", Patregid);
            cmd.Parameters.AddWithValue("@OPDNo", OPDNo);
            cmd.Parameters.AddWithValue("@IPDNo", IPDNo);
            cmd.Parameters.AddWithValue("@TempId", TempId);
            cmd.Parameters.AddWithValue("@TempName", TempName);

            cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);




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

    public void Delete_Template(int Patregid, int OPDNo, int IPDNo, int TempId)
    {
        SqlConnection conn = DataAccess.ConInitForDC();

        SqlCommand sc = new SqlCommand("delete from CaseAssignToTemplate where TempId=" + TempId + " and Patregid=" + Patregid + " and OPDNO=" + OPDNo + "  and IPDNO=" + IPDNo + " ", conn);

        try
        {
            conn.Open();
            sc.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw;
        }
        finally
        {
            try
            {
                conn.Close(); conn.Dispose();
            }
            catch (SqlException)
            {
                throw;
            }

        }
    }

    public DataTable Get_CaseSheet(int Branchid, int Patregid, int OpdNo, int IpdNo)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_GetCaseGenerationToPatients", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Branchid", Branchid);
        cmd.Parameters.AddWithValue("@Patregid", Patregid);
        cmd.Parameters.AddWithValue("@OpdNo", OpdNo);
        cmd.Parameters.AddWithValue("@IpdNo", IpdNo);

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

    public void Delete_CaseSheet(int Patregid, int OPDNo, int IPDNo, int TempId)
    {
        SqlConnection conn = DataAccess.ConInitForDC();

        SqlCommand sc = new SqlCommand("delete from CaseGeneration where CaseId=" + TempId + " and Patregid=" + Patregid + " and OPDNO=" + OPDNo + "  and IPDNO=" + IPDNo + " ", conn);

        try
        {
            conn.Open();
            sc.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw;
        }
        finally
        {
            try
            {
                conn.Close(); conn.Dispose();
            }
            catch (SqlException)
            {
                throw;
            }

        }
    }

    public string InsertGynaclogy_Antenatal(DALGeneralGynology obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_Insert_Gynalogy_ANTENATALCARD", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@Patregid", obj.Patregid);
            cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
            cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);
            cmd.Parameters.AddWithValue("@Gravida", obj.Gravida);

            cmd.Parameters.AddWithValue("@Para", obj.Para);

            cmd.Parameters.AddWithValue("@RiskFactors", obj.RiskFactors);
            cmd.Parameters.AddWithValue("@Allergies", obj.Allergies);
            cmd.Parameters.AddWithValue("@Ethinicity", obj.Ethinicity);

            
            cmd.Parameters.AddWithValue("@SignificantFamilyHistory", obj.SignificantFamilyHistory);
            cmd.Parameters.AddWithValue("@LevelofEducation", obj.LevelofEducation);
            cmd.Parameters.AddWithValue("@HB", obj.HB);

            cmd.Parameters.AddWithValue("@Grp", obj.Grp);
            cmd.Parameters.AddWithValue("@RBS", obj.RBS);
            cmd.Parameters.AddWithValue("@RPR", obj.RPR);
            cmd.Parameters.AddWithValue("@HIV1", obj.HIV1);
            cmd.Parameters.AddWithValue("@HIV2", obj.HIV2);
            cmd.Parameters.AddWithValue("@HBsAg", obj.HBsAg);
            cmd.Parameters.AddWithValue("@Sickling", obj.Sickling);
            cmd.Parameters.AddWithValue("@OGTT", obj.OGTT);
            cmd.Parameters.AddWithValue("@HepC", obj.HepC);
            cmd.Parameters.AddWithValue("@Glucose", obj.Glucose);
            cmd.Parameters.AddWithValue("@UltraSoundFinding", obj.UltraSoundFinding);
            cmd.Parameters.AddWithValue("@SubseqUltraSoundFinding", obj.SubseqUltraSoundFinding);
            cmd.Parameters.AddWithValue("@ModeOfDelivery", obj.ModeOfDelivery);
            cmd.Parameters.AddWithValue("@BirthWeight", obj.BirthWeight);
            cmd.Parameters.AddWithValue("@Note", obj.Note);

            if (obj.LMP_Antinatal_Date == Date.getMinDate())
                cmd.Parameters.Add(new SqlParameter("@LMP_Antinatal_Date", SqlDbType.DateTime)).Value = DBNull.Value;
            else
                cmd.Parameters.Add(new SqlParameter("@LMP_Antinatal_Date", SqlDbType.DateTime)).Value = obj.LMP_Antinatal_Date;

            if (obj.TTINj_Date == Date.getMinDate())
                cmd.Parameters.Add(new SqlParameter("@TTINj_Date", SqlDbType.DateTime)).Value = DBNull.Value;
            else
                cmd.Parameters.Add(new SqlParameter("@TTINj_Date", SqlDbType.DateTime)).Value = obj.TTINj_Date;

            if (obj.Due_Date == Date.getMinDate())
                cmd.Parameters.Add(new SqlParameter("@Due_Date", SqlDbType.DateTime)).Value = DBNull.Value;
            else
                cmd.Parameters.Add(new SqlParameter("@Due_Date", SqlDbType.DateTime)).Value = obj.Due_Date;

           
            if (obj.UltraSound_Date == Date.getMinDate())
                cmd.Parameters.Add(new SqlParameter("@UltraSound_Date", SqlDbType.DateTime)).Value = DBNull.Value;
            else
                cmd.Parameters.Add(new SqlParameter("@UltraSound_Date", SqlDbType.DateTime)).Value = obj.UltraSound_Date;

            if (obj.SubsequentUltraSound_Date == Date.getMinDate())
                cmd.Parameters.Add(new SqlParameter("@SubsequentUltraSound_Date", SqlDbType.DateTime)).Value = DBNull.Value;
            else
                cmd.Parameters.Add(new SqlParameter("@SubsequentUltraSound_Date", SqlDbType.DateTime)).Value = obj.SubsequentUltraSound_Date;

            if (obj.Delivery_Date == Date.getMinDate())
                cmd.Parameters.Add(new SqlParameter("@Delivery_Date", SqlDbType.DateTime)).Value = DBNull.Value;
            else
                cmd.Parameters.Add(new SqlParameter("@Delivery_Date", SqlDbType.DateTime)).Value = obj.Delivery_Date;

            cmd.Parameters.AddWithValue("@Branchid", obj.BranchId);
            cmd.Parameters.AddWithValue("@CreatedBy", obj.CreatedBy);

           // cmd.Parameters.AddWithValue("@FID", obj.FId);


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

    public string InsertGynaclogy_Antenatal_ClinicalDetails(DALGeneralGynology obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_Insert_Gynalogy_ANTENATALCARD_ClinicalDetails", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@Patregid", obj.Patregid);
            cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
            cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);


            cmd.Parameters.AddWithValue("@ClinicalDetails", obj.ClinicalDetails);

            if (obj.Clinical_Date == Date.getMinDate())
                cmd.Parameters.Add(new SqlParameter("@Clinical_Date", SqlDbType.DateTime)).Value = DBNull.Value;
            else
                cmd.Parameters.Add(new SqlParameter("@Clinical_Date", SqlDbType.DateTime)).Value = obj.Clinical_Date;

           

            cmd.Parameters.AddWithValue("@Branchid", obj.BranchId);
            cmd.Parameters.AddWithValue("@CreatedBy", obj.CreatedBy);

            // cmd.Parameters.AddWithValue("@FID", obj.FId);


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

    public string InsertGynaclogy_Antenatal_InvestigationDetails(DALGeneralGynology obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_Insert_Gynalogy_ANTENATALCARD_InvestigationDetails", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@Patregid", obj.Patregid);
            cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
            cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);


            cmd.Parameters.AddWithValue("@InvestigationDetails", obj.InvestigationDetails);

            if (obj.Clinical_Date == Date.getMinDate())
                cmd.Parameters.Add(new SqlParameter("@Investigation_Date", SqlDbType.DateTime)).Value = DBNull.Value;
            else
                cmd.Parameters.Add(new SqlParameter("@Investigation_Date", SqlDbType.DateTime)).Value = obj.Investigation_Date;



            cmd.Parameters.AddWithValue("@Branchid", obj.BranchId);
            cmd.Parameters.AddWithValue("@CreatedBy", obj.CreatedBy);

            // cmd.Parameters.AddWithValue("@FID", obj.FId);


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

    public string InsertGynaclogy_Antenatal_OtherDetails(DALGeneralGynology obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_Insert_Gynalogy_ANTENATALCARD_OtherDetails", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@Patregid", obj.Patregid);
            cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
            cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);


         //   cmd.Parameters.AddWithValue("@InvestigationDetails", obj.InvestigationDetails);

            if (obj.Other_Date == Date.getMinDate())
                cmd.Parameters.Add(new SqlParameter("@Other_Date", SqlDbType.DateTime)).Value = DBNull.Value;
            else
                cmd.Parameters.Add(new SqlParameter("@Other_Date", SqlDbType.DateTime)).Value = obj.Other_Date;

            cmd.Parameters.AddWithValue("@POG", obj.POG);
            cmd.Parameters.AddWithValue("@SFH", obj.SFH);
            cmd.Parameters.AddWithValue("@PPLIE", obj.PPLIE);
            cmd.Parameters.AddWithValue("@FetalHeartBeat", obj.FetalHeartBeat);
            cmd.Parameters.AddWithValue("@BP", obj.BP);
            cmd.Parameters.AddWithValue("@UrinChem", obj.UrinChem);
            cmd.Parameters.AddWithValue("@WeightLBS", obj.WeightLBS);
            cmd.Parameters.AddWithValue("@Investigations", obj.Investigations);
            cmd.Parameters.AddWithValue("@Medications", obj.Medications);
            cmd.Parameters.AddWithValue("@Advice", obj.Advice);
            cmd.Parameters.AddWithValue("@Branchid", obj.BranchId);
            cmd.Parameters.AddWithValue("@CreatedBy", obj.CreatedBy);

            // cmd.Parameters.AddWithValue("@FID", obj.FId);


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


    public string InsertGynaclogy_Antenatal_DrugSchedule(DALGeneralGynology obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_Insert_Gynalogy_ANTENATALCARD_DrugSchedule", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@Patregid", obj.Patregid);
            cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
            cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);


               cmd.Parameters.AddWithValue("@Notes", obj.Note);

            if (obj.DrugScheduleDate == Date.getMinDate())
                cmd.Parameters.Add(new SqlParameter("@DrugScheduleDate", SqlDbType.DateTime)).Value = DBNull.Value;
            else
                cmd.Parameters.Add(new SqlParameter("@DrugScheduleDate", SqlDbType.DateTime)).Value = obj.DrugScheduleDate;

            cmd.Parameters.AddWithValue("@FolliclesLeftOvary", obj.FolliclesLeftOvary);
            cmd.Parameters.AddWithValue("@FolliclesRightOvary", obj.FolliclesRightOvary);
            cmd.Parameters.AddWithValue("@Consent", obj.Consent);

            cmd.Parameters.AddWithValue("@FSH", obj.FSH);
            cmd.Parameters.AddWithValue("@FSHLH", obj.FSHLH);
            cmd.Parameters.AddWithValue("@Units", obj.Units);
            cmd.Parameters.AddWithValue("@Agonist", obj.Agonist);
            cmd.Parameters.AddWithValue("@MISCName", obj.MISCName);
            cmd.Parameters.AddWithValue("@MISCValue", obj.MISCValue);
            cmd.Parameters.AddWithValue("@Comments", obj.Comments);
            cmd.Parameters.AddWithValue("@Branchid", obj.BranchId);
            cmd.Parameters.AddWithValue("@CreatedBy", obj.CreatedBy);

            // cmd.Parameters.AddWithValue("@FID", obj.FId);


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