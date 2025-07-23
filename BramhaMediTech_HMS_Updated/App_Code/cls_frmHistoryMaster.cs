using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for cls_frmHistoryMaster
/// </summary>
public class cls_frmHistoryMaster
{
    public cls_frmHistoryMaster()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetHis(int typeId)
    {
        DataTable dt = new DataTable();
        try
        {


            using (SqlConnection con = DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetHistoryForPastsMaster", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@typeId", SqlDbType.Int).Value = typeId;

                    con.Open();

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }

                    con.Close();
                    con.Dispose();
                }
            }
        }
        catch (Exception)
        {


        }
        return dt;
    }

    public DataTable GetHisMaster()
    {
        DataTable dt = new DataTable();
        try
        {
            using (SqlConnection con = DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetHisMaster", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }

                    con.Close();
                    con.Dispose();
                }
            }
        }
        catch (Exception)
        {


        }
        return dt;
    }

    public int InsertUpdateDelete(int typeId, int catId, string newTypeName, string type)
    {
        try
        {
            using (SqlConnection con = DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetHistoryForPastsMaster_Insert", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@typeId", typeId);
                    cmd.Parameters.AddWithValue("@catId", catId);
                    cmd.Parameters.AddWithValue("@typeName", newTypeName);
                    cmd.Parameters.AddWithValue("@type", type);
                    con.Open();

                    int Result = cmd.ExecuteNonQuery();

                    con.Close();
                    con.Dispose();
                    return Result;
                }
            }
        }
        catch (Exception ex)
        {

            return -1;
        }
    }
}