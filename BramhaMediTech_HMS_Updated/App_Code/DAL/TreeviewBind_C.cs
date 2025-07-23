using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

public class TreeviewBind_C
{
	public TreeviewBind_C()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable Get_TestwiseTotalCount(string TestName)
    {
        DataAccess data = new DataAccess();
        SqlConnection conn = DataAccess.ConInitForDC();
        SqlCommand sc = new SqlCommand("SP_TestwiseTotalCount", conn);
        sc.Parameters.Add(new SqlParameter("@TestName", SqlDbType.NVarChar, 50)).Value = TestName;
        sc.CommandType = CommandType.StoredProcedure;

        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = sc;

        try
        {
            conn.Open();
            DataTable ds = new DataTable();
            da.Fill(ds);
            return ds;

        }
        finally
        {

            conn.Close(); conn.Dispose();

        }

    }
    public  DataTable Get_TotalPatientCount(object tdate, object fdate)
    {

        SqlConnection conn = DataAccess.ConInitForDC();
        SqlDataAdapter da;
        string query = "select COUNT(srno) as PatientCount from patmst " +
                  " where    (CAST(CAST(YEAR( patmst.DateOfEntry) AS varchar(4)) + '/' + CAST(MONTH( patmst.DateOfEntry) AS varchar(2)) + '/' + CAST(DAY( patmst.DateOfEntry) AS varchar(2)) AS datetime))  between ('" + Convert.ToDateTime(fdate).ToString("MM/dd/yyyy") + "') and ('" + Convert.ToDateTime(tdate).ToString("MM/dd/yyyy") + "')  ";



        da = new SqlDataAdapter(query, conn);
        DataTable ds = new DataTable();
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
            conn.Close(); conn.Dispose();
        }
        return ds;

    }

    public DataTable Get_TotalSalesummary(object tdate, object fdate)
    {

        SqlConnection conn = DataAccess.ConInitForDC();
        SqlDataAdapter da;
        string query = "SELECT    sum( NetPayment)as amount,sum( AmtReceived)as AmtReceived, " +
           " sum(CAST(Discount AS float))as Discount, " +
           " sum(NetPayment) - (sum(CAST(Discount AS float))) AS Taxable,Round( sum(TaxAmount),2) AS Tax, " +
           " Round( sum(NetPayment) - ((sum(CAST(Discount AS float))) + sum(AmtReceived)),0) AS Balance   from Cshmst" +
        //" where  IsActive=1 and Cshmst.BillDate between '" + Convert.ToDateTime(fdate).ToString("MM/dd/yyyy") + "' and '" + Convert.ToDateTime(tdate).ToString("MM/dd/yyyy") + "' and Cshmst.branchid=" + branchid + "";
        " where    IsActive=1 and (CAST(CAST(YEAR( Cshmst.BillDate) AS varchar(4)) + '/' + CAST(MONTH(Cshmst.BillDate) AS varchar(2)) + '/' + CAST(DAY(Cshmst.BillDate) AS varchar(2)) AS datetime))  between ('" + Convert.ToDateTime(fdate).ToString("MM/dd/yyyy") + "') and ('" + Convert.ToDateTime(tdate).ToString("MM/dd/yyyy") + "')  ";



        da = new SqlDataAdapter(query, conn);
        DataTable ds = new DataTable();
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
            conn.Close(); conn.Dispose();
        }
        return ds;

    }

    public DataTable Get_DefaultDoctor()
    {
        SqlConnection con = DataAccess.ConInitForPathology();
        SqlDataAdapter sda = new SqlDataAdapter("SELECT rtrim(DrInitial)+' '+DoctorName +'='+ DoctorCode as name from  DrMT where DrType='DR' and DefaultDoctor=1  ", con);

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
    public DataTable Bind_TestParameter(string prefixText,string MTCode,int  branchid)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlDataAdapter sda = new SqlDataAdapter("select STCODE as TestCode,TestName from SubTest where   MTCode='" + Convert.ToString(MTCode) + "'  and branchid=" + Convert.ToInt32(branchid) + " and  STCODE <>'H'", con);

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
    public DataTable BindMainMenu(string USERNAME, string Password)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlDataAdapter sda = new SqlDataAdapter();
        if ((USERNAME == "Admin") || (USERNAME == "admin"))
        {
            sda = new SqlDataAdapter("select MenuID , MenuName from TBL_MenuMaster where Isactive=1 ", con);
        }
        else
        {
            sda = new SqlDataAdapter("SELECT DISTINCT    " +
                     "  TBL_MenuMaster.MenuID ,TBL_MenuMaster.MenuName  " +
                     "  FROM         Roleright INNER JOIN      " +
                     "  TBL_SubMenuMaster ON Roleright.FormId = TBL_SubMenuMaster.SubMenuID INNER JOIN  " +
                     "  TBL_MenuMaster ON TBL_SubMenuMaster.MenuID = TBL_MenuMaster.MenuID INNER JOIN   " +
                     "  CTuser ON Roleright.Usertypeid = CTuser.RollId      " +
                     "  WHERE     (CTuser.USERNAME = '" + USERNAME + "') AND (CTuser.password = '" + Password + "') and  TBL_SubMenuMaster.Isvisible=1  " +
                     "  order by TBL_MenuMaster.MenuID   ", con);
        }
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

    //public DataTable BindMainMenu(string USERNAME, string Password)
    //{
    //    SqlConnection con = DataAccess.ConInitForDC();
    //    SqlDataAdapter sda = new SqlDataAdapter();
    //    if ((USERNAME == "Admin") || (USERNAME == "admin"))
    //    {
    //        sda = new SqlDataAdapter("select MenuID , MenuName   from MenuMaster where ParentMenuId='" +ParentMenuId+ "' and Isactive=1", con);
    //    }
    //    else
    //    {
    //        sda = new SqlDataAdapter("SELECT DISTINCT    " +
    //                 "     TBL_MenuMaster.MenuID ,TBL_MenuMaster.MenuName  " +
    //                 "  FROM         Roleright INNER JOIN      " +
    //                 "  TBL_SubMenuMaster ON Roleright.FormId = TBL_SubMenuMaster.SubMenuID INNER JOIN  " +
    //                 "  TBL_MenuMaster ON TBL_SubMenuMaster.MenuID = TBL_MenuMaster.MenuID INNER JOIN   " +
    //                 "  CTuser ON Roleright.Usertypeid = CTuser.RollId      " +
    //                 "  WHERE     (CTuser.USERNAME = '" + USERNAME + "') AND (CTuser.password = '" + Password + "') and  TBL_SubMenuMaster.Isvisable=1  " +
    //                 "  order by MenuID   ", con);

    //        //sda = new SqlDataAdapter("SELECT  MenuMaster.MenuName, Users.UserName,MenuMaster.MenuId,Users.UserPassword, Users.UserId, Users.EmployeeId, Users.IsActive, MenuMaster.ParentMenuId, " +
    //        //          " MenuMaster.IsActive AS MenuActive, UserRole.RoleId, Role.RoleName, Role.IsActive AS RoleActive " +
    //        //          " FROM Users INNER JOIN  UserRole ON Users.UserId = UserRole.UserId INNER JOIN " +
    //        //          " Role ON UserRole.RoleId = Role.RoleId LEFT OUTER JOIN " +
    //        //          " RoleRight ON Role.RoleId = RoleRight.RoleId AND UserRole.RoleId = RoleRight.RoleId LEFT OUTER JOIN " +
    //        //          " MenuMaster ON RoleRight.MenuId = MenuMaster.MenuId " +
    //        //          " WHERE     (MenuMaster.ParentMenuId ='" + ParentMenuId + "') AND (Users.UserName = '" + USERNAME + "') AND (Users.UserPassword='" + Password + "') AND (MenuMaster.IsActive = 1) AND (Role.IsActive = 1) AND (RoleRight.IsActive = 1)  " +
    //        //          " order by MenuId   ", con);
    //     }
    //    DataTable ds = new DataTable();
    //    try
    //    {
    //        sda.Fill(ds);
    //    }
    //    catch (SqlException)
    //    {
    //        throw;
    //    }
    //    finally
    //    {
    //        con.Close();
    //        con.Dispose();
    //    }
    //    return ds;
    //}
    public DataTable Bind_MachinName()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlDataAdapter sda = new SqlDataAdapter("select MachinName from MachinMaster ", con);

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

    public DataTable BindChildMenu1(string  Menuid)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlDataAdapter sda = new SqlDataAdapter("select SubMenuID as MenuID,SubMenuNavigateURL as MenuName from TBL_subMenuMAster where MenuID='" + Menuid + "' ", con);
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

    public DataTable BindChildMenu(string Menuid, string USERNAME, string Password)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlDataAdapter sda = new SqlDataAdapter();
        if (USERNAME == "Admin" || USERNAME == "admin")
        {
            sda = new SqlDataAdapter("select SubMenuID as MenuID,SubMenuName as MenuName from TBL_subMenuMAster where MenuID='" + Menuid + "'  and  TBL_SubMenuMaster.Isvisible=1 ", con);
        }
        else
        {
            sda = new SqlDataAdapter(" SELECT DISTINCT TBL_SubMenuMaster.SubMenuID as MenuID, TBL_SubMenuMaster.SubMenuName  as MenuName  " +
                        "   FROM         Roleright INNER JOIN      " +
                        "   TBL_SubMenuMaster ON Roleright.FormId = TBL_SubMenuMaster.SubMenuID INNER JOIN   " +
                        "   TBL_MenuMaster ON TBL_SubMenuMaster.MenuID = TBL_MenuMaster.MenuID INNER JOIN    " +
                        "   CTuser ON Roleright.Usertypeid = CTuser.RollId      " +
                        "   WHERE     (CTuser.USERNAME = '" + USERNAME + "') AND (CTuser.PASSWord = '" + Password + "') and TBL_SubMenuMaster.MenuID='" + Menuid + "'   and  TBL_SubMenuMaster.Isvisible=1", con);
        }
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


    //public DataTable BindChildMenu(string Menuid, string USERNAME, string Password)
    //{
    //    SqlConnection con = DataAccess.ConInitForDC();
    //    SqlDataAdapter sda = new SqlDataAdapter();
    //    if (USERNAME == "Admin" || USERNAME == "admin")
    //    {
            
    //        sda = sda = new SqlDataAdapter("select MenuID , MenuName   from MenuMaster where ParentMenuId='" + Menuid + "' and Isactive=1", con);
    //    }
    //    else
    //    {           
            
    //        sda = new SqlDataAdapter("SELECT  MenuMaster.MenuName, Users.UserName,MenuMaster.MenuId,Users.UserPassword, Users.UserId, Users.EmployeeId, Users.IsActive, MenuMaster.ParentMenuId, " +
    //                      " MenuMaster.IsActive AS MenuActive, UserRole.RoleId, Role.RoleName, Role.IsActive AS RoleActive " +
    //                      " FROM Users INNER JOIN  UserRole ON Users.UserId = UserRole.UserId INNER JOIN " +
    //                      " Role ON UserRole.RoleId = Role.RoleId LEFT OUTER JOIN " +
    //                      " RoleRight ON Role.RoleId = RoleRight.RoleId AND UserRole.RoleId = RoleRight.RoleId LEFT OUTER JOIN " +
    //                      " MenuMaster ON RoleRight.MenuId = MenuMaster.MenuId " +
    //                      " WHERE     (MenuMaster.ParentMenuId = '" + Menuid + "') AND (Users.UserName = '" + USERNAME + "') AND (Users.UserPassword='" + Password + "') AND (MenuMaster.IsActive = 1) AND (Role.IsActive = 1)  " +
    //                      " order by MenuId   ", con);
    //    }
    //    DataTable ds = new DataTable();
    //    try
    //    {
    //        sda.Fill(ds);
    //    }
    //    catch (SqlException)
    //    {
    //        throw;
    //    }
    //    finally
    //    {
    //        con.Close();
    //        con.Dispose();

    //    }
    //    return ds;
    //}

    public DataTable checkMenuIdExistInParent(int MenuId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        //SqlDataAdapter sda = new SqlDataAdapter("select SubMenuNavigateURL from TBL_subMenuMAster where SubMenuID=" + SubMenuid + " ", con);
        SqlDataAdapter sda = new SqlDataAdapter("select MenuName,MenuId from MenuMaster where ParentMenuId=" + MenuId + " ", con);
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

    //public DataTable BindForm(int SubMenuid)
    //{
    //    SqlConnection con = DataAccess.ConInitForDC();
    //    //SqlDataAdapter sda = new SqlDataAdapter("select SubMenuNavigateURL from TBL_subMenuMAster where SubMenuID=" + SubMenuid + " ", con);
    //    SqlDataAdapter sda = new SqlDataAdapter("select FormName,MenuId from MenuMaster where MenuId=" + SubMenuid + " ", con);
    //    DataTable ds = new DataTable();
    //    try
    //    {
    //        sda.Fill(ds);
    //    }
    //    catch (SqlException)
    //    {
    //        throw;
    //    }
    //    finally
    //    {
    //        con.Close();
    //        con.Dispose();

    //    }
    //    return ds;
    //}

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

    public DataTable BindForm_Room(int SubMenuid)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlDataAdapter sda = new SqlDataAdapter("select RoomName from RoomMst where RtypeId=" + SubMenuid + " ", con);
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
        sc.Parameters.Add(new SqlParameter("@ModuleName", SqlDbType.NVarChar, 200)).Value = P_ModuleName;
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
        SqlDataAdapter sda = new SqlDataAdapter("SELECT     Roleright.Rightid, Roleright.Usertypeid, Roleright.FormId, Roleright.FormName, Roleright.Branchid, usr.ROLENAME, "+
                          "  TBL_SubMenuMaster.SubMenuNavigateURL, TBL_MenuMaster.MenuName "+
                          "  FROM         Roleright INNER JOIN "+
                          "  usr ON Roleright.Usertypeid = usr.ROLLID AND Roleright.Branchid = usr.branchid INNER JOIN "+
                          "  TBL_SubMenuMaster ON Roleright.FormId = TBL_SubMenuMaster.SubMenuID INNER JOIN "+
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

    public DataTable BindChildMenu_treeview(string Menuid)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlDataAdapter sda = new SqlDataAdapter("select SubMenuID as MenuID,SubMenuName as MenuName from TBL_subMenuMAster where MenuID='" + Menuid + "'  and Isvisible=1 ", con);
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
    public DataTable Bindbanner()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlDataAdapter sda = new SqlDataAdapter("select *   from BannerTable order by id asc ", con);

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
    public DataTable Checkflag()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlDataAdapter sda = new SqlDataAdapter("select distinct Checkflag from patmst where Checkflag=1 ", con);

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
    public DataTable Bind_Shortcuttest()
    {
        SqlConnection con = DataAccess.ConInitForPathology();
        SqlDataAdapter sda = new SqlDataAdapter(" select top(20) RoutinTestCode,RoutinTestCode+' - '+ RoutinTestName as Maintestname from RoutinTest  ", con);

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

    public DataTable Checkflag_Result()
    {
        SqlConnection con = DataAccess.ConInitForPathology();
        SqlDataAdapter sda = new SqlDataAdapter("select PatientFlag from patmstd where PatientFlag=1 ", con);

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
    public DataTable bindassignsubdept(string Uname)
    {
        SqlConnection con = DataAccess.ConInitForPathology();
        SqlDataAdapter sda = new SqlDataAdapter("SELECT     Deptwiseuser.username, Deptwiseuser.DeptCodeID, Deptwiseuser.uname, Deptwiseuser.Createdby, Deptwiseuser.Createdon, Deptwiseuser.Updatedby, " +
          "  Deptwiseuser.Updatedon, Deptwiseuser.branchid, SubDepartment.subdeptName " +
          "  FROM         Deptwiseuser INNER JOIN "+
           " SubDepartment ON Deptwiseuser.DeptCodeID = SubDepartment.subdeptid AND Deptwiseuser.branchid = SubDepartment.Branchid  where Deptwiseuser.username='" + Uname + "' ", con);

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

    public bool UpdateAuthincate_result(int branchid)
    {
        SqlConnection conn = DataAccess.ConInitForPathology();
        SqlCommand sc = new SqlCommand("" +
            "Update patmstd set " +
            "PatientFlag=@PatientFlag  where   branchid=" + branchid + "", conn);


        sc.Parameters.Add(new SqlParameter("@PatientFlag", SqlDbType.Bit)).Value = 1;

        SqlDataReader sdr = null;

        try
        {
            conn.Open();
            try
            {
                sc.ExecuteNonQuery();
            }
            catch
            {

            }
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
    public bool UpdateAuthincate(int branchid)
    {
        SqlConnection conn = DataAccess.ConInitForPathology();
        SqlCommand sc = new SqlCommand("" +
            "Update patmst set " +
            "Checkflag=@Checkflag  where   branchid=" + branchid + "", conn);


        sc.Parameters.Add(new SqlParameter("@Checkflag", SqlDbType.Bit)).Value = 1;

        SqlDataReader sdr = null;

        try
        {
            conn.Open();
            try
            {
                sc.ExecuteNonQuery();
            }
            catch
            {

            }
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
    public bool Insert_Deptwiseuser(int DeptCodeID, string username, string uname, int branchid)
    {


        SqlConnection conn = DataAccess.ConInitForDC();
        SqlCommand sc = new SqlCommand("" +
        "Insert into Deptwiseuser (username,DeptCodeID,[uname],[branchid]) " +
         " values(@username,@DeptCodeID,@uname,@branchid)", conn);
        // Add the employee ID parameter and set its value.
        sc.Parameters.Add(new SqlParameter("@DeptCodeID", SqlDbType.Int)).Value = DeptCodeID;
        sc.Parameters.Add(new SqlParameter("@username", SqlDbType.NVarChar, 50)).Value = username;
        sc.Parameters.Add(new SqlParameter("@uname", SqlDbType.NVarChar, 50)).Value = uname;
        sc.Parameters.Add(new SqlParameter("@branchid", SqlDbType.Int)).Value = branchid;


        conn.Close();
        try
        {
            conn.Open();
            try
            {
                sc.ExecuteNonQuery();
            }
            catch { }

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
        }
        // Implement Update logic.
        return true;
    } //insert End

    public DataTable Get_maindoctor()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlDataAdapter sda = new SqlDataAdapter("select * from CTuser where Usertype='Main Doctor' or Usertype='MainDoctor' or Usertype='Technician' or Usertype='Reporting' ", con);
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
    public DataTable Get_subdepartment()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlDataAdapter sda = new SqlDataAdapter("SELECT     subdeptid, subdeptName FROM         SubDepartment ", con);
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
    public bool deletesubdept(string username)
    {
        SqlConnection conn = DataAccess.ConInitForDC();
        SqlCommand sc = new SqlCommand();
        sc.CommandType = CommandType.StoredProcedure;
        sc.Connection = conn;
        sc.CommandTimeout = 1200;
        sc.CommandText = "[SP_deleteDeptwiseuser]";
        sc.Parameters.Add(new SqlParameter("@username", SqlDbType.NVarChar, 200)).Value = username;
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
    public  DataTable GetAllMachinData()
    {

        SqlConnection conn = DataAccess.ConInitForPathology();
        SqlDataAdapter da;
        string query = "select * from  MachinMaster ";


        da = new SqlDataAdapter(query, conn);
        DataTable ds = new DataTable();
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
            conn.Close(); conn.Dispose();
        }
        return ds;

    }

    public DataTable Bind_Machinecodemap(string MTCode,string MachinNAme)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlDataAdapter sda = new SqlDataAdapter("SELECT     Machinecodemap.Srno, Machinecodemap.MachinName, Machinecodemap.MTCode, Machinecodemap.ParameterCode, Machinecodemap.Mapcode, "+
              "  SubTest.TestName, MainTest.Maintestname "+
              "  FROM         Machinecodemap INNER JOIN "+
              "  SubTest ON Machinecodemap.ParameterCode = SubTest.STCODE INNER JOIN "+
              "  MainTest ON Machinecodemap.MTCode = MainTest.MTCode where Machinecodemap.MachinName='" + MachinNAme + "' ", con);

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
    public bool Insert_MachinMapCode(string MachinName, string MTCode, string ParameterCode, string Mapcode)
    {
        SqlConnection conn = DataAccess.ConInitForDC();


        SqlCommand sc = new SqlCommand("" +
        "INSERT INTO Machinecodemap(MachinName,MTCode,ParameterCode,Mapcode)" +
        "VALUES(@MachinName,@MTCode,@ParameterCode,@Mapcode)", conn);

        // Add the employee ID parameter and set its value.

        sc.Parameters.Add(new SqlParameter("@MachinName", SqlDbType.NVarChar, 200)).Value = MachinName;
        sc.Parameters.Add(new SqlParameter("@MTCode", SqlDbType.NVarChar, 200)).Value = MTCode;
        sc.Parameters.Add(new SqlParameter("@ParameterCode", SqlDbType.NVarChar, 200)).Value = ParameterCode;
        sc.Parameters.Add(new SqlParameter("@Mapcode", SqlDbType.NVarChar, 200)).Value = Mapcode;

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
    public void delete_MapParameter(int Mapid)
    {
        SqlConnection conn = DataAccess.ConInitForDC();

        SqlCommand sc = new SqlCommand("delete from Machinecodemap where Srno='" + Mapid + "' ", conn);

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
    public DataTable Check_ExistMachinparameter(string MTCode, string ParameterCode, string MachinName)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlDataAdapter sda = new SqlDataAdapter("select MTCode from Machinecodemap where MachinName = '" + MachinName + "' and MTCode ='" + MTCode + "' and ParameterCode='" + ParameterCode + "' ", con);

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

    public DataTable IPDBindMainMenu(string USERNAME, string Password)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlDataAdapter sda = new SqlDataAdapter();
        
            sda = new SqlDataAdapter("select  top (1)'1' as MenuID ,'IPD Dashboard' as MenuName  from RoomType where status=1  ", con);
        
       
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
    public DataTable IPDBindChildMenu(string Menuid, string USERNAME, string Password)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlDataAdapter sda = new SqlDataAdapter();

        sda = new SqlDataAdapter("select RTypeID as MenuID,RType as MenuName from RoomType  where status=1 ", con);
       
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

    public DataTable IPDBindForm(int SubMenuid)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlDataAdapter sda = new SqlDataAdapter("select SubMenuNavigateURL from TBL_subMenuMAster where SubMenuID='117' ", con);
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

    public DataTable Bind_ward(string USERNAME, string Password, string MainModule)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlDataAdapter sda = new SqlDataAdapter();

        sda = new SqlDataAdapter("select 'Ward'as MenuName,1 as MenuID ", con);


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

    public DataTable BindChildWard_treeview(string Menuid)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlDataAdapter sda = new SqlDataAdapter("select RTypeId as MenuID,RType as MenuName from RoomType ", con);
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


    public void Insert_NurseRoleRight()
    {

        SqlConnection conn = DataAccess.ConInitForDC();
        SqlCommand sc = new SqlCommand();
        sc.CommandType = CommandType.StoredProcedure;
        sc.Connection = conn;
        sc.CommandText = "SP_NurseRoleRight";
        sc.Parameters.Add(new SqlParameter("@Userid", SqlDbType.Int)).Value = P_Usertypeid;
        sc.Parameters.Add(new SqlParameter("@WardId", SqlDbType.Int)).Value = P_FormId;
        sc.Parameters.Add(new SqlParameter("@WardName", SqlDbType.NVarChar, 200)).Value = P_FormName;
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

    public DataTable Get_Nurse_Rollright(string Usertypeid)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlDataAdapter sda = new SqlDataAdapter("SELECT        NurseRoleright.Rightid, NurseRoleright.Userid, NurseRoleright.WardId, NurseRoleright.WardName, NurseRoleright.Branchid, CTuser.username, CTuser.Usertype " +
                                              "  FROM  NurseRoleright INNER JOIN " +
                                              "  CTuser ON NurseRoleright.Userid = CTuser.CUId where Userid='" + Usertypeid + "' ", con);
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

    public DataTable Get_UserStatus(int UsetStatus)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlDataAdapter sda = new SqlDataAdapter();
        if (UsetStatus == 1)
        {
            sda = new SqlDataAdapter("select * from ctuser where Isactive=1 ", con);
        }
        else
        {
            sda = new SqlDataAdapter("select * from ctuser where Isactive=0  ", con);
        }
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


    public bool UpdateUserActive(int IsActive,int Id)
    {
        SqlConnection conn = DataAccess.ConInitForDC();
        SqlCommand sc = new SqlCommand("" +
            "Update Ctuser set " +
            "IsActive=@IsActive  where   CUId=" + Id + "", conn);


        sc.Parameters.Add(new SqlParameter("@IsActive", SqlDbType.Bit)).Value = IsActive;

        SqlDataReader sdr = null;

        try
        {
            conn.Open();
            try
            {
                sc.ExecuteNonQuery();
            }
            catch
            {

            }
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

    public DataTable BindMainMenu_treeview_ModuleName( string ModuleName)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlDataAdapter sda = new SqlDataAdapter("select MenuID , MenuName   from TBL_MenuMAster where ModuelName='" + ModuleName + "' ", con);

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
    public DataTable BindChildMenu_treeview_ModuleName(string Menuid)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlDataAdapter sda = new SqlDataAdapter("select TriageSubId as TriageMasterId,TriageSubHeading as TriageHeading from TriageSubHeading where TriageHeadingId='" + Menuid + "'  and IsActive=1 ", con);
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
    public void AutoDischarge()
    {

        SqlConnection conn = DataAccess.ConInitForDC();
        SqlCommand sc = new SqlCommand();
        sc.CommandType = CommandType.StoredProcedure;
        sc.Connection = conn;
        sc.CommandText = "SP_ResidentCareAutoDischarge";
        sc.Parameters.Add(new SqlParameter("@Branchid1", SqlDbType.Int)).Value = 1;
       
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

    public void AutoAdmited()
    {

        SqlConnection conn = DataAccess.ConInitForDC();
        SqlCommand sc = new SqlCommand();
        sc.CommandType = CommandType.StoredProcedure;
        sc.Connection = conn;
        sc.CommandText = "SP_ResidentCareAutoAdmit";
        sc.Parameters.Add(new SqlParameter("@Branchid1", SqlDbType.Int)).Value = 1;

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

    public DataTable BindTriageREDMenu_treeview()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlDataAdapter sda = new SqlDataAdapter("select TriageMasterId , TriageHeading   from TriageHeading where TriageType='RED' ", con);

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

    public DataTable BindTriageYellowMenu_treeview()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlDataAdapter sda = new SqlDataAdapter("select TriageMasterId , TriageHeading   from TriageHeading where TriageType='YELLOW' ", con);

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
    public DataTable BindTriageVitalMenu_treeview()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlDataAdapter sda = new SqlDataAdapter("select TriageMasterId , TriageHeading   from TriageHeading where TriageType='Vital' ", con);

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

    public void Insert_Triage()
    {

        SqlConnection conn = DataAccess.ConInitForDC();
        SqlCommand sc = new SqlCommand();
        sc.CommandType = CommandType.StoredProcedure;
        sc.Connection = conn;
        sc.CommandText = "SP_InsertTriageQuestionary";
        sc.Parameters.Add(new SqlParameter("@Patregid", SqlDbType.Int)).Value = P_RegId;
        sc.Parameters.Add(new SqlParameter("@OPDNo", SqlDbType.Int)).Value = P_OPDNo;
        sc.Parameters.Add(new SqlParameter("@TriageMasterId", SqlDbType.Int)).Value = P_TriageMasterId;
        sc.Parameters.Add(new SqlParameter("@TriageHeading", SqlDbType.NVarChar, 550)).Value = P_TriageHeading;
        sc.Parameters.Add(new SqlParameter("@TriageCriteria", SqlDbType.Int)).Value = P_TriageCriteria;
        sc.Parameters.Add(new SqlParameter("@CreatedBy", SqlDbType.NVarChar, 200)).Value = P_CreatedBy;
        sc.Parameters.Add(new SqlParameter("@Branchid", SqlDbType.Int)).Value = P_Branchid;
        sc.Parameters.Add(new SqlParameter("@Issuspected", SqlDbType.Bit)).Value = P_Issuspected;
        sc.Parameters.Add(new SqlParameter("@Measures", SqlDbType.NVarChar, 200)).Value = P_Measures;
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
    public bool isChangepassword(string UserName)
    {
        P_IsChangePassword = "0";
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("select CUId from Ctuser where username='" + UserName + "' and PasswordChangeDate> getdate()", con);
        SqlDataReader sdr = null;

        try
        {
            con.Open();
            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                P_IsChangePassword = sdr["CUId"].ToString();
            }

        }
        catch (Exception ex)
        {
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
        if (P_IsChangePassword == "0")
            return false;
        else
            return true;
    }

    private int Usertypeid;    public int P_Usertypeid
    {
        get { return Usertypeid; }  set { Usertypeid = value; }
    }
    private int FormId;  public int P_FormId
    {
        get { return FormId; }
        set { FormId = value; }
    }
    private string FormName;
    public string P_FormName
    {
        get { return FormName; }
        set { FormName = value; }
    }
    private string ModuleName;
    public string P_ModuleName
    {
        get { return ModuleName; }
        set { ModuleName = value; }
    }
    private int Branchid;
    public int P_Branchid
    {
        get { return Branchid; }
        set { Branchid = value; }
    }


    private string TriageHeading;
    public string P_TriageHeading
    {
        get { return TriageHeading; }
        set { TriageHeading = value; }
    }

    private int TriageMasterId;
    public int P_TriageMasterId
    {
        get { return TriageMasterId; }
        set { TriageMasterId = value; }
    }
    private int RegId;
    public int P_RegId
    {
        get { return RegId; }
        set { RegId = value; }
    }
    private int OPDNo;
    public int P_OPDNo
    {
        get { return OPDNo; }
        set { OPDNo = value; }
    }
    private string CreatedBy;
    public string P_CreatedBy
    {
        get { return CreatedBy; }
        set { CreatedBy = value; }
    }

    private int TriageCriteria;
    public int P_TriageCriteria
    {
        get { return TriageCriteria; }
        set { TriageCriteria = value; }
    }
    private bool Issuspected;
    public bool P_Issuspected
    {
        get { return Issuspected; }
        set { Issuspected = value; }
    }

    private string Measures;
    public string P_Measures
    {
        get { return Measures; }
        set { Measures = value; }
    }
    private string IsChangePassword;
    public string P_IsChangePassword
    {
        get { return IsChangePassword; }
        set { IsChangePassword = value; }
    }
    
}