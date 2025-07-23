using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for clsDocSche
/// </summary>
public class clsDocSche
{
    public string DoctorId { get; set; }
    public string Date1 { get; set; }
    public string Date2 { get; set; }
    public string Time1 { get; set; }
    public string Time2 { get; set; }
    public string Slot { get; set; }
    public clsDocSche()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable GetDocSchedule(int docId)
    {
        DataTable dt = new DataTable();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;

            using (SqlConnection connection = DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetDocSchedule", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@docId", SqlDbType.Int).Value = docId;
                    //cmd.Parameters.Add("@clickedDate", SqlDbType.VarChar).Value = string.IsNullOrEmpty(clickedDate) ? null : clickedDate;

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
    public DataTable ReadDataDocList()
    {
        DataTable dt = new DataTable();
        try
        {
            using (SqlConnection connection = DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetDoctorsList", connection))
                {
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

    public int SaveDocSchedule(string type, string date1, string date2, string docId, string time1, string time2, string slotId, string schId, string note)
    {
        try
        {

            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;

            using (SqlConnection connection = DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("usp_InsertDocSchedule", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@type", SqlDbType.Int).Value = Convert.ToInt32(type);
                    cmd.Parameters.Add("@date1", SqlDbType.DateTime).Value = Convert.ToDateTime(date1);
                    cmd.Parameters.Add("@date2", SqlDbType.DateTime).Value = Convert.ToDateTime(date2);
                    cmd.Parameters.Add("@docId", SqlDbType.Int).Value = Convert.ToInt32(docId);
                    cmd.Parameters.Add("@time1", SqlDbType.DateTime).Value = Convert.ToDateTime(time1);
                    cmd.Parameters.Add("@time2", SqlDbType.DateTime).Value = Convert.ToDateTime(time2);
                    cmd.Parameters.Add("@slotId", SqlDbType.Int).Value = Convert.ToInt32(slotId);
                    cmd.Parameters.Add("@ScheduleId", SqlDbType.VarChar).Value = schId;
                    cmd.Parameters.Add("@Note", SqlDbType.VarChar).Value = note;
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

    public int DeleteOtSchedule(string schId)
    {
        try
        {
            using (SqlConnection connection = DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("usp_DeleteDocSchedule", connection))
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