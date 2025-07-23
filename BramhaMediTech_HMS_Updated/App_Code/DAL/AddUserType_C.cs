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
/// Summary description for AddUserType_C
/// </summary>
public class AddUserType_C
{
   
	public AddUserType_C()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private string _Usertype;

    public string Usertype
    {

        get { return _Usertype; }
        set { _Usertype = value; }
    }
    private string _P_username;

    public string P_username
    {

        get { return _P_username; }
        set { _P_username = value; }
    }
    private int _Sampleid;

    public int Sampleid
    {

        get { return _Sampleid; }
        set { _Sampleid = value; }
    } 

    public bool Update(int rid, string Usertype, int branchid)
    {
       
        SqlConnection conn = DataAccess.ConInitForDC(); 
        SqlCommand sc = new SqlCommand("" +
            "UPDATE usr " +
            "SET RoleName=@RoleName WHERE Rollid=@Rollid and branchid=" + branchid + "", conn);

        sc.Parameters.Add(new SqlParameter("@Rollid", SqlDbType.Int)).Value = rid;

        if (Usertype != null)
            sc.Parameters.Add(new SqlParameter("@RoleName", SqlDbType.NVarChar, 200)).Value = Usertype;
        else
            sc.Parameters.Add(new SqlParameter("@RollName", SqlDbType.NVarChar, 200)).Value = "";

        SqlDataReader sdr = null;

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
                if (sdr != null) sdr.Close();
                conn.Close(); conn.Dispose();
            }
            catch (SqlException)
            {
                // Log an event in the Application Event Log.
                throw;
            }
        }
        

        return true;
    } 

  public  bool isUsertypepeeExists(string usertype, int branchid)
    {
        
        SqlConnection conn = DataAccess.ConInitForDC(); 

        SqlCommand sc = new SqlCommand(" SELECT count(*)" +
                         " FROM usr  " +
                         " WHERE ROLENAME=@ROLENAME and branchid=" + branchid + " ", conn); //User_Type     

        sc.Parameters.Add(new SqlParameter("@ROLENAME", SqlDbType.NVarChar, 200)).Value = usertype;

        int cnt = 0;

        try
        {
            conn.Open();
            cnt = Convert.ToInt32(sc.ExecuteScalar());

        }
        finally
        {
            try
            {
                conn.Close(); conn.Dispose();
            }
            catch (SqlException)
            {
                // Log an event in the Application Event Log.
                throw;
            }
            catch
            {
                throw new Exception("Record not found");
            }
        }
        if (cnt != 0)
            return true;
        else
            return false;
    }

   public void Userright_Bal_C(int id, int branchid)
    {
        SqlConnection conn = DataAccess.ConInitForDC();

        SqlCommand sc = new SqlCommand("SELECT * from  usr  where RollId=@Rollid and branchid=" + branchid + " ", conn);//'"+uname+"'",conn);// +User_Type

        sc.Parameters.Add(new SqlParameter("@Rollid", SqlDbType.Int)).Value = id;

        SqlDataReader sdr = null;

        try
        {
            conn.Open();
            sdr = sc.ExecuteReader();
            if (sdr != null && sdr.Read())
            {
                this.Sampleid = Convert.ToInt32(sdr["Rollid"]);
                this.Usertype = sdr["Rolename"].ToString();
            }
            
        }
        catch (Exception ex)
        {
            throw;
        }
        finally
        {
            
                conn.Close(); conn.Dispose();
           
            
        }
    }

 public void delete(int rrid, int branchid)
    {
        SqlConnection conn = DataAccess.ConInitForDC();

        SqlCommand sc = new SqlCommand("delete from usr where RollID='" + rrid + "' and branchid=" + branchid + "", conn);

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
    public DataTable getuserType()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlDataAdapter sda = new SqlDataAdapter("select * from usr order by ROLENAME", con);
        DataTable ds = new DataTable();
        try
        {
            con.Open();
            sda.Fill(ds);
        }
        catch
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
public bool Insert(int branchid)
    {        
        SqlConnection conn = DataAccess.ConInitForDC(); 


        SqlCommand sc = new SqlCommand("" +
        "INSERT INTO usr(RoleName,branchid)" +
        "VALUES(@RoleName,@branchid)", conn);

        // Add the employee ID parameter and set its value.

        sc.Parameters.Add(new SqlParameter("@RoleName", SqlDbType.NVarChar, 200)).Value = this.Usertype;
        sc.Parameters.Add(new SqlParameter("@branchid", SqlDbType.Int)).Value = branchid;
     
        SqlDataReader sdr = null;

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
                if (sdr != null) sdr.Close();
                conn.Close(); conn.Dispose();
            }
            catch (SqlException)
            {
                // Log an event in the Application Event Log.
                throw;
            }
        }
        // Implement Update logic.
        return true;
    }



}