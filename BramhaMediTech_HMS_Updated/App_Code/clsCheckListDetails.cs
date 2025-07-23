using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for clsCheckListDetails
/// </summary>
/// 
public class clsCheckListDetails
{
    public clsCheckListDetails()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string checkListDetailsId { get; set; }
    public string MrdNo { get; set; }
    public string Ipd { get; set; }
    public string PatientName { get; set; }
    public string DoctorInc { get; set; }
    public string RoomType { get; set; }
    public string DateOfAdmission { get; set; }
    public string BedNo { get; set; }
    public string Diagnosis { get; set; }

    public List<clsCheckListTrans> transactions { get; set; }

    public DataTable GetCheckListCategoriesDt()
    {
        DataTable dt = new DataTable();
        try { 
        using (SqlConnection connection = DataAccess.ConInitForDC())
        {
            using (SqlCommand cmd = new SqlCommand("usp_GetCheckListCats", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

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

    public DataTable GetCheckListCatTypeByMrd(string mrd, string ipd, string checkType)
    {
        DataTable dt = new DataTable();
        try
        {

        
        using (SqlConnection connection = DataAccess.ConInitForDC())
        {
            using (SqlCommand cmd = new SqlCommand("usp_GetCheckTypeByMrd", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@mrd", SqlDbType.VarChar).Value = mrd;
                cmd.Parameters.Add("@ipd", SqlDbType.VarChar).Value = ipd;
                cmd.Parameters.Add("@checkType", SqlDbType.VarChar).Value = checkType;

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

    public DataTable GetCheckListCategoriesTypeDt(string checkListType, string mrd, string ipd)
    {
        DataTable dt = new DataTable();
        try { 
        using (SqlConnection connection = DataAccess.ConInitForDC())
        {
            using (SqlCommand cmd = new SqlCommand("usp_GetCheckListCatsType", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@checkListId", SqlDbType.VarChar).Value = checkListType;
                cmd.Parameters.Add("@mrd", SqlDbType.VarChar).Value = mrd;
                cmd.Parameters.Add("@ipd", SqlDbType.VarChar).Value = ipd;
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

    public DataSet GetCheckListMainGridDetail(string mrd, string ipd, string schId)
    {
        DataSet ds = new DataSet();
        try { 
        using (SqlConnection connection = DataAccess.ConInitForDC())
        {
            using (SqlCommand cmd = new SqlCommand("usp_GetChecklistMainDetails", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@mrd", SqlDbType.VarChar).Value = mrd;
                cmd.Parameters.Add("@ipd", SqlDbType.VarChar).Value = ipd;
                cmd.Parameters.Add("@schid", SqlDbType.VarChar).Value = schId;

                connection.Open();

                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(ds);
                }
            }
            connection.Close();
            connection.Dispose();
        }
        }
        catch (Exception)
        {

        }
        return ds;
    }

    public int InsertMainRec(string stmtType)
    {
        try
        {
            using (SqlConnection connection = DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("InsertUpdateDelete_tbl_SurgeryCheckListDetails", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@checkListDetailsId", SqlDbType.VarChar).Value = checkListDetailsId;
                    cmd.Parameters.Add("@MrdNo", SqlDbType.VarChar).Value = MrdNo;
                    cmd.Parameters.Add("@Ipd", SqlDbType.VarChar).Value = Ipd;
                    cmd.Parameters.Add("@PatientName", SqlDbType.VarChar).Value = PatientName;
                    cmd.Parameters.Add("@DoctorInc", SqlDbType.VarChar).Value = DoctorInc;
                    cmd.Parameters.Add("@RoomType", SqlDbType.VarChar).Value = RoomType;
                    cmd.Parameters.Add("@DateOfAdmission", SqlDbType.VarChar).Value = DateOfAdmission;
                    cmd.Parameters.Add("@BedNo", SqlDbType.VarChar).Value = BedNo;
                    cmd.Parameters.Add("@Diagnosis", SqlDbType.VarChar).Value = Diagnosis;
                    cmd.Parameters.Add("@StatementType", SqlDbType.VarChar).Value = stmtType;

                    connection.Open();

                    int result = -1;

                    if (stmtType == "Insert")
                    {
                        result = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    else
                    {
                        result = cmd.ExecuteNonQuery();
                    }

                    return result;
                    connection.Close();
                    connection.Dispose();
                }
            }
        }
        catch (Exception ex)
        {
            return -1;
        }
    }

    public int InsertUpdateTransactionsRec(string checkListDetailsId, string checkListType, string checkListDesc, string remarks)
    {
        try
        {
            using (SqlConnection connection = DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("usp_InsertUpdateCheckListTransactions", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@checkListDetailsId", SqlDbType.VarChar).Value = checkListDetailsId;
                    cmd.Parameters.Add("@checkListType", SqlDbType.VarChar).Value = checkListType;
                    cmd.Parameters.Add("@checkListDesc", SqlDbType.VarChar).Value = checkListDesc;
                    cmd.Parameters.Add("@remarks", SqlDbType.VarChar).Value = remarks;

                    connection.Open();

                    int result = cmd.ExecuteNonQuery();
                    return result;
                    connection.Close();
                    connection.Dispose();
                }
            }
        }
        catch (Exception)
        {
            return -1;
        }
    }
}

public class clsCheckListTrans
{
    public clsCheckListTrans()
    {

    }

    public string checkListDetailsTranId { get; set; }
    public string checkListType { get; set; }
    public string checkListDesc { get; set; }
    public string Remarks { get; set; }
    public string checkDate { get; set; }
    public string checkListDetailsId { get; set; }
}