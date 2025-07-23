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
public class BELVitroFertilization
{
    DALVitroFertilization ObjDALANC = new DALVitroFertilization();
    public BELVitroFertilization()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataTable GetVitroFertilization(DALVitroFertilization obj)//string patregId
    {
        DataTable dt = new DataTable();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;
            using (SqlConnection connection =
                      DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("SP_GetVitroFertilization", connection))
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
                       // connection.Open();
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
    public string InsertVitroFertilization(DALVitroFertilization obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_InsertVitroFertilization", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@Patregid", obj.Patregid);
            cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
            cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);
            cmd.Parameters.AddWithValue("@LMPDate", obj.LMPDate);

            cmd.Parameters.AddWithValue("@RPR", obj.RPR);

            cmd.Parameters.AddWithValue("@YearOfInfert", obj.YearOfInfert);
            cmd.Parameters.AddWithValue("@YearOfInfert1", obj.YearOfInfert1);
            cmd.Parameters.AddWithValue("@HIV", obj.HIV);

            cmd.Parameters.AddWithValue("@AFC", obj.AFC);
            cmd.Parameters.AddWithValue("@RBS", obj.RBS);
            cmd.Parameters.AddWithValue("@HepB", obj.HepB);
            cmd.Parameters.AddWithValue("@HepC", obj.HepC);

            cmd.Parameters.AddWithValue("@BloodGrouping", obj.BloodGrouping);
            cmd.Parameters.AddWithValue("@PartnerName", obj.PartnerName);
            cmd.Parameters.AddWithValue("@PartnerAge", obj.PartnerAge);
            cmd.Parameters.AddWithValue("@ParHIV", obj.ParHIV);

            cmd.Parameters.AddWithValue("@ParHepB", obj.ParHepB);
            cmd.Parameters.AddWithValue("@RarHepC", obj.RarHepC);
            cmd.Parameters.AddWithValue("@FSH", obj.FSH);
            cmd.Parameters.AddWithValue("@AMH", obj.AMH);

            cmd.Parameters.AddWithValue("@LH", obj.LH);
            cmd.Parameters.AddWithValue("@Prolact", obj.Prolact);
            cmd.Parameters.AddWithValue("@TSH", obj.TSH);


            cmd.Parameters.AddWithValue("@E2", obj.E2);
            cmd.Parameters.AddWithValue("@T3", obj.T3);
            cmd.Parameters.AddWithValue("@T4", obj.T4);
            cmd.Parameters.AddWithValue("@P4", obj.P4);

            cmd.Parameters.AddWithValue("@CMV", obj.CMV);
            cmd.Parameters.AddWithValue("@SemenAnalysisNote", obj.SemenAnalysisNote);
            cmd.Parameters.AddWithValue("@Fibroids", obj.Fibroids);
            cmd.Parameters.AddWithValue("@Endometriosis", obj.Endometriosis);

            cmd.Parameters.AddWithValue("@Cycts", obj.Cycts);
            cmd.Parameters.AddWithValue("@Hydrosalpinx", obj.Hydrosalpinx);
            cmd.Parameters.AddWithValue("@AntrialFollicleNote", obj.AntrialFollicleNote);


            cmd.Parameters.AddWithValue("@TrialTransfer", obj.TrialTransfer);
            cmd.Parameters.AddWithValue("@TrialTransferDetalis", obj.TrialTransferDetalis);
            cmd.Parameters.AddWithValue("@Endometrialscrath", obj.Endometrialscrath);
            cmd.Parameters.AddWithValue("@Endometria_Date", obj.Endometria_Date);

            cmd.Parameters.AddWithValue("@HysteroscopyFinding", obj.HysteroscopyFinding);
            cmd.Parameters.AddWithValue("@DLap", obj.DLap);
            cmd.Parameters.AddWithValue("@PreviousInfertHist", obj.PreviousInfertHist);
            cmd.Parameters.AddWithValue("@VitroRemarks", obj.VitroRemarks);

            cmd.Parameters.AddWithValue("@DHEAS", obj.DHEAS);
            cmd.Parameters.AddWithValue("@LongAgonist", obj.LongAgonist);
            cmd.Parameters.AddWithValue("@Antagonist", obj.Antagonist);

            cmd.Parameters.AddWithValue("@OCsDate", obj.OCsDate);
            cmd.Parameters.AddWithValue("@VitroNote", obj.VitroNote);
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