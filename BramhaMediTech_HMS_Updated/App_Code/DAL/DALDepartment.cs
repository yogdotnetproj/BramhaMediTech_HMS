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
/// Summary description for DALDepartment
/// </summary>
public class DALDepartment
{
    BELDepartment objBELDept = new BELDepartment();
	public DALDepartment()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataSet FillMainDepartmentDrop()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("Sp_DeptMainFillDrop", con);
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


    public DataSet FillGridDepartment()
    {

        SqlConnection con = DataAccess.ConInitForDC();
        SqlDataAdapter da = new SqlDataAdapter("SP_DeptFillGrid", con);
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


    public BELDepartment SelectOneDept(int DeptId)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_DeptSelectOne", con);
        cmd.CommandType = CommandType.StoredProcedure;


        try
        {
            cmd.Parameters.AddWithValue("@DeptId", DeptId);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                objBELDept.DeptId = Convert.ToInt32(sdr["DeptId"]);
                objBELDept.DeptName = Convert.ToString(sdr["DeptName"]);
                objBELDept.DeptCode = Convert.ToString(sdr["DeptCode"]);
               
                
            }
            return objBELDept;
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


    public string UpdateDepartment(BELDepartment objBELDept)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_DeptUpdate", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {
            cmd.Parameters.AddWithValue("@DeptId", objBELDept.DeptId);
            cmd.Parameters.AddWithValue("@DeptName", objBELDept.DeptName);
            cmd.Parameters.AddWithValue("@DeptCode", objBELDept.DeptCode);
            cmd.Parameters.AddWithValue("@UpdatedBy", objBELDept.UpdatedBy);

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

    public string InsertDeparment(BELDepartment objBELDept)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_DeptInsert", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {

            cmd.Parameters.AddWithValue("@DeptName", objBELDept.DeptName);
            cmd.Parameters.AddWithValue("@DeptCode", objBELDept.DeptCode);
            cmd.Parameters.AddWithValue("@CreatedBy", objBELDept.CreatedBy);

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

    public string DeleteDepartment(int DeptId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_DeptDelete", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@DeptId", DeptId);
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


    public string InsertAccount_Head(BELDepartment objBELDept)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_Insert_AccHead", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {

            cmd.Parameters.AddWithValue("@AccHead", objBELDept.DeptName);
            cmd.Parameters.AddWithValue("@AccCode", objBELDept.DeptCode);
            

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

    public string Update_AccountHead(BELDepartment objBELDept)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_Update_Acccodes", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {
            cmd.Parameters.AddWithValue("@ID", objBELDept.DeptId);
            cmd.Parameters.AddWithValue("@AccHead", objBELDept.DeptName);
            cmd.Parameters.AddWithValue("@AccCode", objBELDept.DeptCode);
           // cmd.Parameters.AddWithValue("@UpdatedBy", objBELDept.UpdatedBy);

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

    public DataSet FillGrid_AccountHead()
    {

        SqlConnection con = DataAccess.ConInitForDC();
        SqlDataAdapter da = new SqlDataAdapter("Sp_GetAcccodes", con);
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

    public BELDepartment GetAccount_Code(int DeptId)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_EditAcccodes", con);
        cmd.CommandType = CommandType.StoredProcedure;


        try
        {
            cmd.Parameters.AddWithValue("@ID", DeptId);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                objBELDept.DeptId = Convert.ToInt32(sdr["ID"]);
                objBELDept.DeptName = Convert.ToString(sdr["AccHead"]);
                objBELDept.DeptCode = Convert.ToString(sdr["AccCode"]);


            }
            return objBELDept;
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

    public string Insert_CashPaymentVoucher(BELDepartment objBELDept)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_Insert_AccHead", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {

            cmd.Parameters.AddWithValue("@AccCode", objBELDept.AccCode);
            cmd.Parameters.AddWithValue("@AccHead", objBELDept.AccHead);
            cmd.Parameters.AddWithValue("@Amount", objBELDept.Amount);
            cmd.Parameters.AddWithValue("@CreatedBy", objBELDept.CreatedBy);


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


    public string Insert_CashPaymentVoucher_Details(BELDepartment objBELDept)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("SP_InsertCashVoucherPayment_Details", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {
            cmd.Parameters.AddWithValue("@CashId", objBELDept.Cash_VoucherNo);
            cmd.Parameters.AddWithValue("@AccCode", objBELDept.AccCode);
            cmd.Parameters.AddWithValue("@AccHead", objBELDept.AccHead);
            cmd.Parameters.AddWithValue("@Amount", objBELDept.Amount);
            cmd.Parameters.AddWithValue("@CreatedBy", objBELDept.CreatedBy);


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
    public int Get_CashVoucherNo(BELDepartment objBELDept)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_InsertCashVoucherPayment_Master", con);
        cmd.CommandType = CommandType.StoredProcedure;
       
       
        cmd.Parameters.AddWithValue("@PayTo", objBELDept.PayTo);
        cmd.Parameters.AddWithValue("@ParticularName", objBELDept.ParticularName);
        cmd.Parameters.AddWithValue("@CreatedBy", objBELDept.CreatedBy);
        cmd.Parameters.AddWithValue("@PaymentType", objBELDept.ModeofPayment);
        cmd.Parameters.AddWithValue("@VoucherNo", objBELDept.VoucherNo);
        try
        {

            object count = Convert.ToInt32(cmd.ExecuteScalar());
            return Convert.ToInt32(count);
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