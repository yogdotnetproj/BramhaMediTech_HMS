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
/// Summary description for AddRoleRight_C
/// </summary>
public class AddRoleRight_C
{
    DataAccess da = new DataAccess();
	public AddRoleRight_C()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    private int _P_Usertypeid;

    public int P_Usertypeid
    {

        get { return _P_Usertypeid; }
        set { _P_Usertypeid = value; }
    }
    private string _P_FormName;

    public string P_FormName
    {

        get { return _P_FormName; }
        set { _P_FormName = value; }
    }
    private int _P_FormId;
    public int P_FormId
    {

        get { return _P_FormId; }
        set { _P_FormId = value; }
    } 

    private int _P_Branchid;
    public int P_Branchid
    {

        get { return _P_Branchid; }
        set { _P_Branchid = value; }
    } 



    public DataSet FillUserroles(string branchid, string id)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlDataAdapter da = new SqlDataAdapter("select ROLLID,ROLENAME,ROLLDESCRIPTION from usr where branchid=" + branchid + "  order by ROLENAME ", con);
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

    public DataTable BindForm(int SubMenuid)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlDataAdapter sda = new SqlDataAdapter("select SubMenuNavigateURL from TBL_subMenuMAster where SubMenuID=" + SubMenuid + " ", con);
        DataTable ds = new DataTable();
        try
        {
            sda.Fill(ds);
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


    public void Insert_Roleright()
    {

        SqlConnection conn = DataAccess.ConInitForDC();
        SqlCommand sc = new SqlCommand();
        sc.CommandType = CommandType.StoredProcedure;
        sc.Connection = conn;
        sc.CommandText = "SP_phrtroll";
        sc.Parameters.Add(new SqlParameter("@Usertypeid", SqlDbType.Int)).Value = P_Usertypeid;
        sc.Parameters.Add(new SqlParameter("@FormId", SqlDbType.Int)).Value = P_FormId;
        sc.Parameters.Add(new SqlParameter("@FormName", SqlDbType.NVarChar, 200)).Value = P_FormName;
        sc.Parameters.Add(new SqlParameter("@Branchid", SqlDbType.Int)).Value = P_Branchid;
        try
        {
            conn.Open();
            sc.ExecuteNonQuery(); 
        }
        catch (SqlException)
        {
            throw;
        }
        finally
        {
            conn.Close(); conn.Dispose();
        }


    }

    public DataTable Get_Rollright(string Usertypeid)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlDataAdapter sda = new SqlDataAdapter("SELECT     Roleright.Rightid, Roleright.Usertypeid, Roleright.FormId, Roleright.FormName, Roleright.Branchid, usr.ROLENAME, " +
                          "  TBL_SubMenuMaster.SubMenuNavigateURL, TBL_MenuMaster.MenuName " +
                          "  FROM         Roleright INNER JOIN " +
                          "  usr ON Roleright.Usertypeid = usr.ROLLID AND Roleright.Branchid = usr.branchid INNER JOIN " +
                          "  TBL_SubMenuMaster ON Roleright.FormId = TBL_SubMenuMaster.SubMenuID INNER JOIN " +
                          "  TBL_MenuMaster ON TBL_SubMenuMaster.MenuID = TBL_MenuMaster.MenuID where Usertypeid='" + Usertypeid + "' ", con);
        DataTable ds = new DataTable();
        try
        {
            sda.Fill(ds);
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

    public DataTable BindMainMenu_treeview()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlDataAdapter sda = new SqlDataAdapter("select MenuID , MenuName   from TBL_MenuMAster ", con);

        DataTable ds = new DataTable();
        try
        {
            sda.Fill(ds);
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

    public void deleteUsers_Rights(string Rightid)
    {
        SqlConnection conn = DataAccess.ConInitForDC();

        SqlCommand sc = new SqlCommand("delete from Roleright where Rightid='" + Rightid + "' ", conn);

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


    public DataSet BindUsers(string branchid, string id)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlDataAdapter da = new SqlDataAdapter("select CUId,Username from ctuser where branchid=" + branchid + "  order by CUId ", con);
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
    public void deleteNurse_Rights(string Rightid)
    {
        SqlConnection conn = DataAccess.ConInitForDC();

        SqlCommand sc = new SqlCommand("delete from NurseRoleright where Rightid='" + Rightid + "' ", conn);

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