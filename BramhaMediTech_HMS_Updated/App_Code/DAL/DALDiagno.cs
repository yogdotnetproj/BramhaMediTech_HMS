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
/// Summary description for DALDiagno
/// </summary>
public class DALDiagno
{
    BELDiagno objBELDiagno = new BELDiagno();
	public DALDiagno()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    


    public DataSet FillGridDiagno1()
    {

        SqlConnection con = DataAccess.ConInitForDC();
        SqlDataAdapter da = new SqlDataAdapter("SP_Diagno1FillGrid", con);
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

    public BELDiagno SelectOneDiagno1(int TrDiagnoId)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Diagno1SelectOne", con);
        cmd.CommandType = CommandType.StoredProcedure;


        try
        {
            cmd.Parameters.AddWithValue("@TrDiagnoId", TrDiagnoId);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                objBELDiagno.TrDiagnoId = Convert.ToInt32(sdr["TrDiagnoId"]);
                objBELDiagno.TrDiagnoName = Convert.ToString(sdr["TrDiagnoName"]);
                objBELDiagno.ICDId = Convert.ToString(sdr["ICDId"]);


            }
            return objBELDiagno;
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

    public string UpdateDiagno1(BELDiagno objBELDiagno)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_Diagno1Update", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {
            cmd.Parameters.AddWithValue("@TrDiagnoId", objBELDiagno.TrDiagnoId);
            cmd.Parameters.AddWithValue("@TrDiagnoName", objBELDiagno.TrDiagnoName);
            cmd.Parameters.AddWithValue("@ICDId", objBELDiagno.ICDId);
            cmd.Parameters.AddWithValue("@UpdatedBy", objBELDiagno.UpdatedBy);

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

    public string InsertDiagno1(BELDiagno objBELDiagno)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_Diagno1Insert", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {
            
            cmd.Parameters.AddWithValue("@TrDiagnoName", objBELDiagno.TrDiagnoName);
            cmd.Parameters.AddWithValue("@ICDId", objBELDiagno.ICDId);
            cmd.Parameters.AddWithValue("@CreatedBy", objBELDiagno.CreatedBy);
            cmd.Parameters.AddWithValue("@BranchId", objBELDiagno.BranchId);

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

    public string DeleteDiagno1(int TrDiagnoId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Diagno1Delete", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@TrDiagnoId", TrDiagnoId);
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

    //___________________________________________________________________________________________________________//

    public DataSet FillDiagno1Drop()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("Sp_Diagno1FillDrop", con);
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

    public DataSet FillGridDiagno2(int TrDiagnoId)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("SP_Diagno2FillGrid", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@TrDiagnoId", TrDiagnoId);
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

    public BELDiagno SelectOneDiagno2(int TrDiagnostage2Id)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Diagno2SelectOne", con);
        cmd.CommandType = CommandType.StoredProcedure;


        try
        {
            cmd.Parameters.AddWithValue("@TrDiagnostage2Id", TrDiagnostage2Id);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                objBELDiagno.TrDiagnostage2Id = Convert.ToInt32(sdr["TrDiagnostage2Id"]);
                objBELDiagno.TrDiagnoId = Convert.ToInt32(sdr["TrDiagnoId"]);
                objBELDiagno.TrDiagnoNameStg2 = Convert.ToString(sdr["TrDiagnoNameStg2"]);
                objBELDiagno.Stage2Id = Convert.ToString(sdr["Stage2Id"]);


            }
            return objBELDiagno;
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

    public string UpdateDiagno2(BELDiagno objBELDiagno)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_Diagno2Update", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {
            cmd.Parameters.AddWithValue("@TrDiagnostage2Id", objBELDiagno.TrDiagnostage2Id);
            cmd.Parameters.AddWithValue("@TrDiagnoNameStg2", objBELDiagno.TrDiagnoNameStg2);
            cmd.Parameters.AddWithValue("@Stage2Id", objBELDiagno.Stage2Id);
            cmd.Parameters.AddWithValue("@TrDiagnoId", objBELDiagno.TrDiagnoId);
            cmd.Parameters.AddWithValue("@UpdatedBy", objBELDiagno.UpdatedBy);

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

    public string InsertDiagno2(BELDiagno objBELDiagno)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_Diagno2Insert", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {
            cmd.Parameters.AddWithValue("@TrDiagnoId", objBELDiagno.TrDiagnoId);
            cmd.Parameters.AddWithValue("@TrDiagnoNameStg2", objBELDiagno.TrDiagnoNameStg2);
            cmd.Parameters.AddWithValue("@Stage2Id", objBELDiagno.Stage2Id);
            cmd.Parameters.AddWithValue("@CreatedBy", objBELDiagno.CreatedBy);
            cmd.Parameters.AddWithValue("@BranchId", objBELDiagno.BranchId);

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

    public string DeleteDiagno2(int TrDiagnostage2Id)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Diagno2Delete", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@TrDiagnostage2Id", TrDiagnostage2Id);
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

    //_________________________________________________________________________________________________________//

    public DataSet FillDiagno2Drop()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("Sp_Diagno2FillDrop", con);
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

    public DataSet FillGridDiagno3(int TrDiagnostage2Id)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("SP_Diagno3FillGrid", con);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        cmd.Parameters.AddWithValue("@TrDiagnostage2Id", TrDiagnostage2Id);       
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

    public BELDiagno SelectOneDiagno3(int TrDiagnostage3Id)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Diagno3SelectOne", con);
        cmd.CommandType = CommandType.StoredProcedure;


        try
        {
            cmd.Parameters.AddWithValue("@TrDiagnostage3Id", TrDiagnostage3Id);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                objBELDiagno.TrDiagnostage3Id = Convert.ToInt32(sdr["TrDiagnostage3Id"]);
                objBELDiagno.TrDiagnoNameStg3 = Convert.ToString(sdr["TrDiagnoNameStg3"]);
                objBELDiagno.Stage3Id = Convert.ToString(sdr["Stage3Id"]);
                objBELDiagno.TrDiagnostage2Id = Convert.ToInt32(sdr["TrDiagnostage2Id"]);


            }
            return objBELDiagno;
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


    public string UpdateDiagno3(BELDiagno objBELDiagno)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_Diagno3Update", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {
            cmd.Parameters.AddWithValue("@TrDiagnostage3Id", objBELDiagno.TrDiagnostage3Id);
            cmd.Parameters.AddWithValue("@TrDiagnoNameStg3", objBELDiagno.TrDiagnoNameStg3);
            cmd.Parameters.AddWithValue("@Stage3Id", objBELDiagno.Stage3Id);
            cmd.Parameters.AddWithValue("@TrDiagnostage2Id", objBELDiagno.TrDiagnostage2Id);                
            cmd.Parameters.AddWithValue("@UpdatedBy", objBELDiagno.UpdatedBy);

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

    public string InsertDiagno3(BELDiagno objBELDiagno)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_Diagno3Insert", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {
            cmd.Parameters.AddWithValue("@TrDiagnostage2Id", objBELDiagno.TrDiagnostage2Id);
            cmd.Parameters.AddWithValue("@TrDiagnoNameStg3", objBELDiagno.TrDiagnoNameStg3);
            cmd.Parameters.AddWithValue("@Stage3Id", objBELDiagno.Stage3Id);
            cmd.Parameters.AddWithValue("@CreatedBy", objBELDiagno.CreatedBy);
            cmd.Parameters.AddWithValue("@BranchId", objBELDiagno.BranchId);

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

    public string DeleteDiagno3(int TrDiagnostage3Id)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Diagno3Delete", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@TrDiagnostage3Id", TrDiagnostage3Id);
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