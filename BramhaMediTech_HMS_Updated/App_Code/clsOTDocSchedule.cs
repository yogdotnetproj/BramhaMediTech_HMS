using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for clsOTDocSchedule
/// </summary>
public class clsOTDocSchedule
{
    public string DocName { get; set; }
    public string TheaterName { get; set; }
    public string OpStartDateTime { get; set; }
    public string Duration { get; set; }
    public string DocSchId { get; set; }
    public clsOTDocSchedule()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    private DataTable GetOtDocSche(string v1, string v2, string v3)
    {
        DataTable dt = new DataTable();
        try
        {
            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;

            using (SqlConnection connection = DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("usb_GetOtDocSchedule", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@docName", SqlDbType.VarChar).Value = v1;
                    cmd.Parameters.Add("@theaterName", SqlDbType.VarChar).Value = v2;
                    cmd.Parameters.Add("@opDateTime", SqlDbType.VarChar).Value = v3;

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
}