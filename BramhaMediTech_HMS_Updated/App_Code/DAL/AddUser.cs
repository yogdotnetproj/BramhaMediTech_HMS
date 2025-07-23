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
/// Summary description for AddUser
/// </summary>
public class AddUser
{
    //DataAccess data = new DataAccess();
   // SqlConnection data = DataAccess.ConInitForDC();
    public DataSet FillUserMasterGrid(string branchid, string uname, string dept, string id)
    {
        SqlConnection con = DataAccess.ConInitForDC();
       
        
       //string query = "SELECT     BranchMaster.BranchName, tbl_Dept.DeptName AS dept,CTuser.* " +                      
       //              "  FROM BranchMaster INNER JOIN "+
       //              " CTuser ON BranchMaster.branchid = CTuser.branchid INNER JOIN  tbl_Dept ON CTuser.maindeptid = tbl_Dept.DeptId AND CTuser.branchid = tbl_Dept.BranchId "+
       //              " where CTuser.branchid=" + branchid + " ";

        string query = "SELECT     BranchMst.BranchName, DepartmentMst.DeptName AS dept,CTuser.* " +
                     "  FROM BranchMst INNER JOIN " +
                     " CTuser ON BranchMst.branchId = CTuser.branchid INNER JOIN  DepartmentMst ON CTuser.maindeptid = DepartmentMst.DeptId AND CTuser.branchid = DepartmentMst.BranchId " +
                     " where CTuser.branchid=" + branchid + " ";

                    
        
        if (uname != "")
        {
            query += " and  CTuser.USERNAME like '%" + uname + "%'";
        }
        //if (dept != "All" && dept != "")
        //{
        //    query += " and  users.DEPT='" + dept + "'";
        //}
        SqlDataAdapter da = new SqlDataAdapter(query, con);
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
            con.Close(); con.Dispose();
        }
        return ds;
    }

    public void deleteUsers(string CUId)
    {
        SqlConnection conn = DataAccess.ConInitForDC();

        SqlCommand sc = new SqlCommand("delete from CTUser where CUId='" + CUId + "' ", conn);

        try
        {
            conn.Open();
            sc.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw;
        }
        finally
        {
            try
            {
                conn.Close(); conn.Dispose();
            }
            catch (SqlException)
            {
                throw;
            }

        }
    }
}