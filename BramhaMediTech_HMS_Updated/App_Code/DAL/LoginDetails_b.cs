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


public class LoginDetails_b
{
    public LoginDetails_b()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region properties
    private DateTime logintime;
    public DateTime P_logintime
    {
        get { return logintime; }
        set { logintime = value; }
    }
    private DateTime logouttime;
    public DateTime P_logouttime
    {
        get { return logouttime; }
        set { logouttime = value; }
    }
    private int billno;
    public int P_billno
    {
        get { return billno; }
        set { billno = value; }
    }
    private DateTime logindate;
    public DateTime P_logindate
    {
        get { return logindate; }
        set { logindate = value; }
    }
    private string username;
    public string P_username
    {
        get { return username; }
        set { username = value; }
    }
    private DateTime logoutdate;
    public DateTime P_logoutdate
    {
        get { return logoutdate; }
        set { logoutdate = value; }
    }
    private string strlogtime;
    public string P_strlogtime
    {
        get { return strlogtime; }
        set { strlogtime = value; }
    }
    private string strlogouttime;
    public string P_strlogouttime
    {
        get { return strlogouttime; }
        set { strlogouttime = value; }
    }
    private int companyid;
    public int P_companyid
    {
        get { return companyid; }
        set { companyid = value; }
    }
    private string url;
    public string P_url
    {
        get { return url; }
        set { url = value; }
    }
    private string ipaddr;
    public string P_ipaddr
    {
        get { return ipaddr; }
        set { ipaddr = value; }
    }
    private DateTime logintime1;
    public DateTime P_logintime1
    {
        get { return logintime1; }
        set { logintime1 = value; }
    }
    private string Address;
    public string P_Address
    {
        get { return Address; }
        set { Address = value; }
    }
    #endregion
    public void insert(int branchid)
    {
        SqlConnection conn = DataAccess.ConInitForDC();
        SqlCommand sc = new SqlCommand("insert into inflog(LoginTime,Username,LoginDate,branchid)" +
        "values(@LoginTime,@Username,@LoginDate,@branchid)", conn);

        sc.Parameters.Add(new SqlParameter("@LoginTime", SqlDbType.DateTime)).Value = P_logintime.ToString("hh:mm:ss");

        sc.Parameters.Add(new SqlParameter("@Username", SqlDbType.NVarChar, 50)).Value = P_username;
        sc.Parameters.Add(new SqlParameter("@LoginDate", SqlDbType.DateTime)).Value = P_logindate;
        sc.Parameters.Add(new SqlParameter("@branchid", SqlDbType.Int)).Value = branchid;
      //  sc.Parameters.Add(new SqlParameter("@LogoutTime", SqlDbType.DateTime)).Value = P_logouttime.ToString("hh:mm:ss");
        try
        {
            conn.Open();
            sc.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
            throw;
        }
        finally
        {
            conn.Close();
            conn.Dispose();
        }
    }
 
    public int getmaxlid()
    {
        int lid = 0;
        SqlConnection conn = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("select max(lid) from inflog", conn);
        SqlDataReader sdr = null;
        object obj = null;
        try
        {
            conn.Open();
            obj = cmd.ExecuteScalar();
            if (obj != null)
                lid = Convert.ToInt32(obj);
        }
        catch (SqlException ex)
        {
            throw;
        }
        finally
        {
            conn.Close();
            conn.Dispose();
        }
        return lid;
    }
   



    public int getmaxlidNew()
    {
        int lid = 0;        
        SqlConnection conn = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("select max(lid) from inflog", conn);
        SqlDataReader sdr = null;
        object obj = null;
        try
        {
            conn.Open();
            obj = cmd.ExecuteScalar();
            if (obj != null)
                lid = Convert.ToInt32(obj);
        }
        catch (SqlException ex)
        {
            throw;
        }
        finally
        {
            conn.Close();
            conn.Dispose();
        }
        return lid;
    }
    public void UpdatePassword(string newPwd, string oldpwd, int UserId, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_ChangePassword", con);
        cmd.CommandType = CommandType.StoredProcedure;
        // string Expdate = "1/1/2000";
        try
        {
            cmd.Parameters.AddWithValue("@newPwd", newPwd);
            cmd.Parameters.AddWithValue("@oldpwd", oldpwd);
            cmd.Parameters.AddWithValue("@UserId", UserId);

            cmd.Parameters.AddWithValue("@BranchId", BranchId);

            cmd.ExecuteNonQuery();
            con.Close();
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
