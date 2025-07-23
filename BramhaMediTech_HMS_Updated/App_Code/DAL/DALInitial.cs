using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

/// <summary>
/// Summary description for DALInitial
/// </summary>
public class DALInitial
{
    BELInitial objBELInitial = new BELInitial();
	public DALInitial()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public BELInitial SelectOneInitial(int TitleId)
    {
       
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_InitialSelectOne", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@TitleId", TitleId);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {

                objBELInitial.TitleId = Convert.ToInt32(sdr["TitleId"]);
                objBELInitial.GenderId = Convert.ToInt32(sdr["GenderId"]);
                objBELInitial.TitleName = Convert.ToString(sdr["Title"]);
                if (sdr["IsDefault"] != DBNull.Value)
                {
                    objBELInitial.IsDefault = Convert.ToBoolean(sdr["IsDefault"]);
                }
                else
                {
                    objBELInitial.IsDefault = false;
                }
                //objBELInitial.IsActive = Convert.ToBoolean(sdr["IsActive"]);
                //objBELInitial.CreatedBy = Convert.ToString(sdr["CreatedBy"]);
                //objBELInitial.CreatedDateTime = Convert.ToDateTime(sdr["CreatedOn"]);
               // objBELInitial.UpdatedBy = Convert.ToString(sdr["UpdatedBy"]);
               // objBELInitial.UpdatedDateTime = Convert.ToDateTime(sdr["UpdatedOn"]);
            }
            return objBELInitial;
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

  
    public DataSet FillGrid()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlDataAdapter da = new SqlDataAdapter("Sp_InitialFillgrid", con);
        con.Open();
        DataSet ds = new DataSet();
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

    
    public string InsertTitle(BELInitial ObjBELInitial)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_InitialInsert", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@TitleId", ObjBELInitial.TitleId);
            cmd.Parameters.AddWithValue("@Title",ObjBELInitial.TitleName);
            cmd.Parameters.AddWithValue("@GenderId", ObjBELInitial.GenderId);
            cmd.Parameters.AddWithValue("@CreatedBy",ObjBELInitial.CreatedBy);
            cmd.Parameters.AddWithValue("@IsDefault", objBELInitial.IsDefault);
            cmd.Parameters.AddWithValue("@BranchId",ObjBELInitial.BranchId);
            cmd.Parameters.AddWithValue("@FId",ObjBELInitial.FId);

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

    /// <summary>
    ///  It Update Single Record From Database Regarding Id
    /// </summary>
    /// <param name="obj1">It Requires Changing Details Of Title In Form Of DOTitle object  </param>
    /// <returns>Returns Success Message In String</returns>
    public string UpdateTitle(BELInitial ObjBELInitial)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_InitialUpdate", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {
            cmd.Parameters.AddWithValue("@TitleId", ObjBELInitial.TitleId);
            cmd.Parameters.AddWithValue("@Title", ObjBELInitial.TitleName);
            cmd.Parameters.AddWithValue("@GenderId", ObjBELInitial.GenderId);
            cmd.Parameters.AddWithValue("@IsDefault", objBELInitial.IsDefault);
            cmd.Parameters.AddWithValue("@UpdatedBy", ObjBELInitial.UpdatedBy);
            //cmd.Parameters.AddWithValue("@BranchId", ObjBELInitial.BranchId);
            //cmd.Parameters.AddWithValue("@FId", ObjBELInitial.FId);

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

    public string DeleteTitle(int TitleId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_InitialDelete", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@TitleId", TitleId);
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

    public DataSet FillGenderCombo()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("Sp_FillGenderCombo", con);       
        DataSet ds = new DataSet();
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