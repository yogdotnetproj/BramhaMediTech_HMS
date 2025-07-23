using System;
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

/// <summary>
/// Summary description for DALOperationTheater
/// </summary>
public class DALOperationTheater
{
    BELOperationTheater objBELOt = new BELOperationTheater();
	public DALOperationTheater()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    //____________________________________________________Operation Theater_________________________________________
    public DataSet FillGridOT()
    {

        SqlConnection con = DataAccess.ConInitForDC();
        SqlDataAdapter da = new SqlDataAdapter("SP_OTFillGrid", con);
        DataSet ds = new DataSet();
        con.Open();
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


    public BELOperationTheater SelectOneOT(int OTId)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_OTSelectOne", con);
        cmd.CommandType = CommandType.StoredProcedure;


        try
        {
            cmd.Parameters.AddWithValue("@OTId", OTId);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {

                objBELOt.OTId = Convert.ToInt32(sdr["OTId"]);
                objBELOt.OTType = Convert.ToString(sdr["OTType"]);



            }
            return objBELOt;
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
    }


    public string UpdateOT(BELOperationTheater objBELOt)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_OTUpdate", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {
            cmd.Parameters.AddWithValue("@OTId", objBELOt.OTId);
            cmd.Parameters.AddWithValue("@OTType", objBELOt.OTType);
            cmd.Parameters.AddWithValue("@UpdatedBy", objBELOt.UpdatedBy);

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

    public string InsertOT(BELOperationTheater objBELOt)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_OTInsert", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {

            cmd.Parameters.AddWithValue("@FId", objBELOt.FId);
            cmd.Parameters.AddWithValue("@BranchId", objBELOt.BranchId);
            cmd.Parameters.AddWithValue("@OTType", objBELOt.OTType);
            cmd.Parameters.AddWithValue("@CreatedBy", objBELOt.CreatedBy);

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

    public string DeleteOT(int OTId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_OTDelete", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@OTId", OTId);
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


    //__________________________________________________Operation Category________________________________________//

    public DataSet FillGridOpCat()
    {

        SqlConnection con = DataAccess.ConInitForDC();
        SqlDataAdapter da = new SqlDataAdapter("SP_OpCatFillGrid", con);
        DataSet ds = new DataSet();
        con.Open();
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


    public BELOperationTheater SelectOneOpCat(int OprnCatId)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_OpCatSelectOne", con);
        cmd.CommandType = CommandType.StoredProcedure;


        try
        {
            cmd.Parameters.AddWithValue("@OprnCatId", OprnCatId);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {

                objBELOt.OprnCatId = Convert.ToInt32(sdr["OprnCatId"]);
                objBELOt.OprnCat = Convert.ToString(sdr["OprnCat"]);



            }
            return objBELOt;
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
    }


    public string UpdateOpCat(BELOperationTheater objBELOt)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_OpCatUpdate", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {
            cmd.Parameters.AddWithValue("@OprnCatId", objBELOt.OprnCatId);
            cmd.Parameters.AddWithValue("@OprnCat", objBELOt.OprnCat);
            cmd.Parameters.AddWithValue("@UpdatedBy", objBELOt.UpdatedBy);

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

    public string InsertOpCat(BELOperationTheater objBELOt)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_OpCatInsert", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {

            cmd.Parameters.AddWithValue("@FId", objBELOt.FId);
            cmd.Parameters.AddWithValue("@BranchId", objBELOt.BranchId);
            cmd.Parameters.AddWithValue("@OprnCat", objBELOt.OprnCat);
            cmd.Parameters.AddWithValue("@CreatedBy", objBELOt.CreatedBy);

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

    public string DeleteOpCat(int OprnCatId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_OpCatDelete", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@OprnCatId", OprnCatId);
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

    //__________________________________________________Operation Main Category________________________________________//

    public DataSet FillGridOpMainCat()
    {

        SqlConnection con = DataAccess.ConInitForDC();
        SqlDataAdapter da = new SqlDataAdapter("SP_OpMainCatFillGrid", con);
        DataSet ds = new DataSet();
        con.Open();
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

    public BELOperationTheater SelectOneOpMainCat(int OTDeptId)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_OpMainCatSelectOne", con);
        cmd.CommandType = CommandType.StoredProcedure;


        try
        {
            cmd.Parameters.AddWithValue("@OTDeptId", OTDeptId);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {

                objBELOt.OTDeptId = Convert.ToInt32(sdr["OTDeptId"]);
                objBELOt.OTDeptName = Convert.ToString(sdr["OTDeptName"]);
                objBELOt.DeptId = Convert.ToInt32(sdr["DeptId"]);



            }
            return objBELOt;
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
    }

    public string UpdateOpMainCat(BELOperationTheater objBELOt)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_OpMainCatUpdate", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {
            cmd.Parameters.AddWithValue("@OTDeptId", objBELOt.OTDeptId);
            cmd.Parameters.AddWithValue("@DeptId", objBELOt.DeptId);
            cmd.Parameters.AddWithValue("@OTDeptName", objBELOt.OTDeptName);
            cmd.Parameters.AddWithValue("@UpdatedBy", objBELOt.UpdatedBy);

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

    public string InsertOpMainCat(BELOperationTheater objBELOt)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_OpMainCatInsert", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {

            cmd.Parameters.AddWithValue("@FId", objBELOt.FId);
            cmd.Parameters.AddWithValue("@BranchId", objBELOt.BranchId);
            
            cmd.Parameters.AddWithValue("@DeptId", objBELOt.DeptId);
            cmd.Parameters.AddWithValue("@OTDeptName", objBELOt.OTDeptName);
           
            cmd.Parameters.AddWithValue("@CreatedBy", objBELOt.CreatedBy);

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

    public string DeleteOpMainCat(int OTDeptId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_OpMainCatDelete", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@OTDeptId", OTDeptId);
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

    public DataSet FillDeptCombo()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlDataAdapter da = new SqlDataAdapter("SP_DeptFillDrop", con);
        DataSet ds = new DataSet();
        con.Open();
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


    //__________________________________________________Operation Name________________________________________//

    public DataSet FillGridOpName(int OperationId)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("SP_OpNameFillGrid", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@OperationId", OperationId);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        con.Open();
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
    public DataSet FillGridOpName()
    {

        SqlConnection con = DataAccess.ConInitForDC();
        SqlDataAdapter da = new SqlDataAdapter("SP_OpNameFillGrid", con);
        DataSet ds = new DataSet();
        con.Open();
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

    public DataSet FillOpMainCatCombo()
    {

        SqlConnection con = DataAccess.ConInitForDC();
        SqlDataAdapter da = new SqlDataAdapter("Sp_OpMainCatFillDrop", con);
        DataSet ds = new DataSet();
        con.Open();
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

    public BELOperationTheater SelectOneOpName(int OprnId)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_OpNameSelectOne", con);
        cmd.CommandType = CommandType.StoredProcedure;


        try
        {
            cmd.Parameters.AddWithValue("@OprnId", OprnId);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                objBELOt.OprnId = Convert.ToInt32(sdr["OperationId"]);
                objBELOt.Oprn = Convert.ToString(sdr["OperationName"]);
                //objBELOt.OprnId= Convert.ToInt32(sdr["OprnId"]);
                //objBELOt.Oprn = Convert.ToString(sdr["OprnName"]);
                //objBELOt.OTDeptId = Convert.ToInt32(sdr["OTDeptId"]);




            }
            return objBELOt;
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
    }
    public string UpdateOpName(BELOperationTheater objBELOt)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_OpNameUpdate", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {
            // cmd.Parameters.AddWithValue("@OTDeptId", objBELOt.OTDeptId);
            cmd.Parameters.AddWithValue("@OprnId", objBELOt.OprnId);
            cmd.Parameters.AddWithValue("@OprnName", objBELOt.Oprn);
            // cmd.Parameters.AddWithValue("@Oprncd", objBELOt.OprnId);
            cmd.Parameters.AddWithValue("@UpdatedBy", objBELOt.UpdatedBy);

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

    public string UpdateOpName1(BELOperationTheater objBELOt)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_OpNameUpdate", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {
            cmd.Parameters.AddWithValue("@OTDeptId", objBELOt.OTDeptId);
            cmd.Parameters.AddWithValue("@OprnId", objBELOt.OprnId);
            cmd.Parameters.AddWithValue("@OprnName", objBELOt.Oprn);
            cmd.Parameters.AddWithValue("@Oprncd", objBELOt.OprnId);
            cmd.Parameters.AddWithValue("@UpdatedBy", objBELOt.UpdatedBy);

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
    public string InsertOpName(BELOperationTheater objBELOt)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_OpNameInsert", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {

            cmd.Parameters.AddWithValue("@FId", objBELOt.FId);
            cmd.Parameters.AddWithValue("@BranchId", objBELOt.BranchId);
            // cmd.Parameters.AddWithValue("@OTDeptId", objBELOt.OTDeptId);            
            cmd.Parameters.AddWithValue("@Oprn", objBELOt.Oprn);
            // cmd.Parameters.AddWithValue("@Oprncd", objBELOt.OprnId);
            cmd.Parameters.AddWithValue("@CreatedBy", objBELOt.CreatedBy);

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


    public string InsertOpName1(BELOperationTheater objBELOt)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_OpNameInsert", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {

            cmd.Parameters.AddWithValue("@FId", objBELOt.FId);
            cmd.Parameters.AddWithValue("@BranchId", objBELOt.BranchId);
            cmd.Parameters.AddWithValue("@OTDeptId", objBELOt.OTDeptId);            
            cmd.Parameters.AddWithValue("@OprnName", objBELOt.Oprn);
            cmd.Parameters.AddWithValue("@Oprncd", objBELOt.OprnId);
            cmd.Parameters.AddWithValue("@CreatedBy", objBELOt.CreatedBy);

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

    public string DeleteOpName(int OprnId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_OpNameDelete", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@OprnId", objBELOt.OprnId);
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
