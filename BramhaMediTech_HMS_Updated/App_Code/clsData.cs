using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for clsData
/// </summary>
public class clsData
{
    public Dictionary<string, string> listOpCategory { get; set; }
    public Dictionary<string, string> listOpName { get; set; }
    public Dictionary<string, string> listOpTheater { get; set; }
    public Dictionary<string, string> listDocName { get; set; }
    public Dictionary<string, string> listAnName { get; set; }

    public clsData()
    {
        listOpCategory = new Dictionary<string, string>();
        listOpName = new Dictionary<string, string>();
        listOpTheater = new Dictionary<string, string>();
        listDocName = new Dictionary<string, string>();
        listAnName = new Dictionary<string, string>();
    }

    public DataSet FillOtSelects()
    {
        DataSet dt = new DataSet();
        try
        {

            using (SqlConnection connection = DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("usb_GetOTScheduleSelect", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    connection.Open();

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                }
            }
        }
        catch (Exception)
        {


        }
        return dt;
    }

    public DataTable GetOtSche(string PatRegId)
    {
        DataTable dt = new DataTable();
        try
        {


            using (SqlConnection connection = DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("usb_GetOtSchedule", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Patientregid", SqlDbType.VarChar).Value = PatRegId;
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
        catch (Exception)
        {


        }
        return dt;
    }

    public int InsertUpdateOtSchedule(string type, string PatRegId, string Opd, string Ipd, string OpCategory, string OpName,
        string OpTheater, string DrName, string AnName, string OtDate, string OtTime,string schId)
    {
        try
        {
            string[] date1 = OtDate.Split('/');

            using (SqlConnection connection = DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("usp_InsertUpdateOtSchedule", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@type", SqlDbType.Int).Value = Convert.ToInt32(type);
                    cmd.Parameters.Add("@OtSchId", SqlDbType.VarChar).Value = schId;
                    cmd.Parameters.Add("@Patientregid", SqlDbType.VarChar).Value = PatRegId;
                    cmd.Parameters.Add("@opd", SqlDbType.VarChar).Value = Opd;
                    cmd.Parameters.Add("@ipd", SqlDbType.VarChar).Value = Ipd;
                    cmd.Parameters.Add("@createdby", SqlDbType.VarChar).Value = "Alex";
                    cmd.Parameters.Add("@OpCategory", SqlDbType.VarChar).Value = OpCategory;
                    cmd.Parameters.Add("@OpName", SqlDbType.VarChar).Value = OpName;
                    cmd.Parameters.Add("@OpTheater", SqlDbType.VarChar).Value = OpTheater;
                    cmd.Parameters.Add("@DrName", SqlDbType.VarChar).Value = DrName;
                    cmd.Parameters.Add("@AnName", SqlDbType.VarChar).Value = AnName;
                    cmd.Parameters.Add("@OtDate", SqlDbType.VarChar).Value = date1[1] + "-" + date1[0] + "-" + date1[2];
                    cmd.Parameters.Add("@OtTime", SqlDbType.VarChar).Value = OtTime;

                    connection.Open();

                    int rowsAffected = Convert.ToInt32(cmd.ExecuteScalar());

                    connection.Close();
                    connection.Dispose();
                    return rowsAffected;
                }

            }
        }
        catch(Exception e)
        {
            return -1;
        }

    }

    public int DeleteOtSchedule(string schId)
    {
        try
        {
            using (SqlConnection connection = DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("usp_DeleteOtSchedule", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@OtSchId", SqlDbType.VarChar).Value = schId;
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

