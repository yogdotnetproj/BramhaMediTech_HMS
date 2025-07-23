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

public class DALEmpReg
{
    BELEmpReg objBELEmpReg = new BELEmpReg();
	public DALEmpReg()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataSet Search_EmployeeByName(string Empname)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("SP_Search_EmployeeByName", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Empname", Empname);
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
    public DataSet FillEmployeeMaster()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("Sp_EmpMstFillgrid", con);
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

    public DataSet FillDepartmentDropByEmpId(int EmpId)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("SP_DeptFillDropByEmpId", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EmpId", EmpId);
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
    

    public DataSet FillDeptDrop()
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
    
    public DataSet FillDesignationDrop ()
    {

        SqlConnection con = DataAccess.ConInitForDC();
        SqlDataAdapter da = new SqlDataAdapter("SP_DesgnationFillDrop", con);
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

    public DataSet FillTitleDrop()
    {

        SqlConnection con = DataAccess.ConInitForDC();
        SqlDataAdapter da = new SqlDataAdapter("Sp_TitleFillCombo", con);
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


    public BELEmpReg SelectOneEmpMaster(int DrId)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_EmpMstSelectOne", con);
        cmd.CommandType = CommandType.StoredProcedure;


        try
        {
            cmd.Parameters.AddWithValue("@DrId", DrId);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
               
                objBELEmpReg.Empname=Convert.ToString(sdr["Empname"]);
                if (sdr["telno"] != DBNull.Value)
                {
                    objBELEmpReg.telno = Convert.ToString(sdr["telno"]);
                }
                else
                {
                    objBELEmpReg.telno = "";
                }
                if (sdr["mobile"] != DBNull.Value)
                {
                    objBELEmpReg.mobile = Convert.ToString(sdr["mobile"]);
                }
                else
                {
                    objBELEmpReg.mobile = "";
                }
                if (sdr["Address"] != DBNull.Value)
                {
                    objBELEmpReg.Address = Convert.ToString(sdr["Address"]);
                }
                else
                {
                    objBELEmpReg.Address = "";
                }
                if (sdr["DeptId"] != DBNull.Value)
                {
                    objBELEmpReg.DeptId = Convert.ToInt32(sdr["DeptId"]);
                }
                else
                {
                    objBELEmpReg.DeptId = 0;
                }
                if (sdr["DesignationId"] != DBNull.Value)
                {
                    objBELEmpReg.DesignationId = Convert.ToInt32(sdr["DesignationId"]);
                }
                else
                {
                    objBELEmpReg.DesignationId = 0;
                }
                if (sdr["email"] != DBNull.Value)
                {
                    objBELEmpReg.email = Convert.ToString(sdr["email"]);
                }
                else
                {
                    objBELEmpReg.email = "";
                }
                if (sdr["EmployeeType"] != DBNull.Value)
                {
                    objBELEmpReg.EmployeeType = Convert.ToString(sdr["EmployeeType"]);
                }
                else
                {
                    objBELEmpReg.EmployeeType = "0";
                }
                if (sdr["BirthDate"] != DBNull.Value)
                {
                    objBELEmpReg.BirthDate = Convert.ToDateTime(sdr["BirthDate"]);
                }
                
               // objBELEmpReg.AnniversaryDate = Convert.ToDateTime(sdr["AnniversaryDate"]); 
                if (sdr["Title"] != DBNull.Value)
                {
                    objBELEmpReg.Title = Convert.ToString(sdr["Title"]);
                }
                else
                {
                    objBELEmpReg.Title = "0";
                }
                if (sdr["Qualification"] != DBNull.Value)
                {
                    objBELEmpReg.Qualification = Convert.ToString(sdr["Qualification"]);
                }
                else
                {
                    objBELEmpReg.Qualification = "";
                }
                objBELEmpReg.FId = Convert.ToString(sdr["FId"]);	
                objBELEmpReg.BranchId=Convert.ToInt32(sdr["BranchId"]);
                //objBELEmpReg.BloodGroup = Convert.ToString(sdr["BloodGroup"]);
                if (sdr["Empcode"] != DBNull.Value)
                {
                    objBELEmpReg.Empcode = Convert.ToString(sdr["Empcode"]);
                }
                else
                {
                    objBELEmpReg.Empcode = "";
                }
                if (sdr["PANNo"] != DBNull.Value)
                {
                    objBELEmpReg.PANNo = Convert.ToString(sdr["PANNo"]);
                }
                else
                {
                    objBELEmpReg.PANNo = "";
                }
                if (sdr["JoiningDate"] != DBNull.Value)
                {
                    objBELEmpReg.JoiningDate = Convert.ToDateTime(sdr["JoiningDate"]);
                }
               

                

            }
            return objBELEmpReg;
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


    public string UpdateEmpMaster(BELEmpReg objBELEmpReg)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_EmpMstUpdate", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {
            cmd.Parameters.AddWithValue("@DrId", objBELEmpReg.DrId);
            cmd.Parameters.AddWithValue("@DeptId", objBELEmpReg.DeptId);
            cmd.Parameters.AddWithValue("@Address", objBELEmpReg.Address);
            //cmd.Parameters.AddWithValue("@AnniversaryDate", objBELEmpReg.AnniversaryDate);
            cmd.Parameters.AddWithValue("@BirthDate", objBELEmpReg.BirthDate);
           // cmd.Parameters.AddWithValue("@BloodGroup", objBELEmpReg.BloodGroup);
            cmd.Parameters.AddWithValue("@DesignationId", objBELEmpReg.DesignationId);
            cmd.Parameters.AddWithValue("@email", objBELEmpReg.email);
            cmd.Parameters.AddWithValue("@Empcode", objBELEmpReg.Empcode);
            cmd.Parameters.AddWithValue("@EmployeeType", objBELEmpReg.EmployeeType);
            cmd.Parameters.AddWithValue("@Empname", objBELEmpReg.Empname);
            cmd.Parameters.AddWithValue("@Qualification", objBELEmpReg.Qualification);
            cmd.Parameters.AddWithValue("@Title", objBELEmpReg.Title);
            cmd.Parameters.AddWithValue("@PANNo", objBELEmpReg.PANNo);
            cmd.Parameters.AddWithValue("@mobile", objBELEmpReg.mobile);
            cmd.Parameters.AddWithValue("@telno", objBELEmpReg.telno);
            cmd.Parameters.AddWithValue("@UpdatedBy", objBELEmpReg.UpdatedBy);
            cmd.Parameters.AddWithValue("@JoiningDate", objBELEmpReg.JoiningDate);

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

    public string InsertEmpMaster(BELEmpReg objBELEmpReg)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_EmpMstInsert", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {

            cmd.Parameters.AddWithValue("@DeptId", objBELEmpReg.DeptId);
            cmd.Parameters.AddWithValue("@Address", objBELEmpReg.Address);
            //cmd.Parameters.AddWithValue("@AnniversaryDate", objBELEmpReg.AnniversaryDate);
            cmd.Parameters.AddWithValue("@BirthDate", objBELEmpReg.BirthDate);
            //cmd.Parameters.AddWithValue("@BloodGroup", objBELEmpReg.BloodGroup);
            cmd.Parameters.AddWithValue("@DesignationId", objBELEmpReg.DesignationId);
            cmd.Parameters.AddWithValue("@email", objBELEmpReg.email);
            cmd.Parameters.AddWithValue("@Empcode", objBELEmpReg.Empcode);
            cmd.Parameters.AddWithValue("@EmployeeType", objBELEmpReg.EmployeeType);
            cmd.Parameters.AddWithValue("@Empname", objBELEmpReg.Empname);
            cmd.Parameters.AddWithValue("@Qualification", objBELEmpReg.Qualification);
            cmd.Parameters.AddWithValue("@Title", objBELEmpReg.Title);
            cmd.Parameters.AddWithValue("@PANNo", objBELEmpReg.PANNo);
            cmd.Parameters.AddWithValue("@mobile", objBELEmpReg.mobile);
            cmd.Parameters.AddWithValue("@telno", objBELEmpReg.telno);
            cmd.Parameters.AddWithValue("@CreatedBy", objBELEmpReg.CreatedBy);
            cmd.Parameters.AddWithValue("@JoiningDate", objBELEmpReg.JoiningDate);
            cmd.Parameters.AddWithValue("@BranchId", objBELEmpReg.BranchId);
            cmd.Parameters.AddWithValue("@FId", objBELEmpReg.FId);


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

    public string DeleteEmpMaster(int DrId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_EmpMasterDelete", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@DrId", DrId);
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