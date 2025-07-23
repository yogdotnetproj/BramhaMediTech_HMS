using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for clsNurse
/// </summary>
public class clsNurse
{
    public clsNurse()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable GetRecords(int docId)
    {
        DataTable dt = new DataTable();
        try
        {
            using (SqlConnection connection = DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetNurseRecords", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = docId;
                    connection.Open();

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }

                }
                connection.Close();
                connection.Dispose();
            }
        }
        catch (Exception ex)
        {
        }
        return dt;
    }
    
    public int SaveNurse(string type, string date1, string docId, string time1, string schId, string duration, string theatre,string regId,string name,
        string ipd,string opd, string branchId,string entrydate)
    {
        try
        {

            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;

            using (SqlConnection connection = DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("usp_InsertNurse", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@type", SqlDbType.Int).Value = Convert.ToInt32(type);
                    cmd.Parameters.Add("@RegId", SqlDbType.VarChar).Value = regId;
                    cmd.Parameters.Add("@PatientName", SqlDbType.VarChar).Value = name;
                    cmd.Parameters.Add("@Ipd", SqlDbType.VarChar).Value = ipd;
                    cmd.Parameters.Add("@Opd", SqlDbType.VarChar).Value = opd;
                    cmd.Parameters.Add("@EntryDate", SqlDbType.VarChar).Value = entrydate;
                    cmd.Parameters.Add("@BranchId", SqlDbType.VarChar).Value = branchId;
                    cmd.Parameters.Add("@DoctorId", SqlDbType.VarChar).Value = docId;
                    cmd.Parameters.Add("@OperationTheatre", SqlDbType.VarChar).Value = theatre;
                    cmd.Parameters.Add("@NDate", SqlDbType.VarChar).Value = date1;
                    cmd.Parameters.Add("@NTime", SqlDbType.VarChar).Value = time1;
                    cmd.Parameters.Add("@NurseId", SqlDbType.VarChar).Value = schId;
                    cmd.Parameters.Add("@Duration", SqlDbType.VarChar).Value = duration;
                    connection.Open();
                    int rowsAffected = Convert.ToInt32(cmd.ExecuteScalar());

                    connection.Close();
                    connection.Dispose();
                    return rowsAffected;
                }
            }
        }
        catch (Exception ex)
        {
            return -1;
        }
    }

    public int DeleteNurse(string scId)
    {
        try
        {
            using (SqlConnection connection = DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("usp_DeleteNurse", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = scId;
                    connection.Open();

                    int rowsAffected = cmd.ExecuteNonQuery();

                    connection.Close();
                    connection.Dispose();
                    return rowsAffected;
                }

            }
        }
        catch
        {
            return -1;
        }
    }
}