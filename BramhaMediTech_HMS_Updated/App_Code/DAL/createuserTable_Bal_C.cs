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
using System.Collections;

public class createuserTable_Bal_C
{
    public createuserTable_Bal_C()
    {
        
        this.Username = "";
        this.Password = "";
       
        this.Usertype = "";
       
        this.CenterCode = "";
       
        this.Name = "";
       
        this.LBcode = "";
        this.MainDept = "";
        this.UnitCode = "";
    }
    private string _UnitCode;
    public string UnitCode
    {
        get { return _UnitCode; }
        set { _UnitCode = value; }
    }
    public DataTable Get_VW_Phlebotomist_Pending(int branchid)
    {
        DataTable dt = new DataTable();
        SqlConnection conn = DataAccess.ConInitForDC();
        try
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT CASE WHEN DiffTimeMin > 60 THEN CONVERT(nvarchar(50), DiffTimeHour) + ' hr' ELSE CONVERT(nvarchar(50), DiffTimeMin) + ' Min' END AS DateDiffA, "+
              "  VW_Phlebotomist_PendingReport_Temp.* "+
              "  FROM         VW_Phlebotomist_PendingReport_Temp ", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }
        catch (Exception ex) { throw; }
        finally { conn.Close(); conn.Dispose(); }
        return dt;
    }
    public static bool Check_IsInterfaceRegNo( int branchid)
    {

        SqlConnection conn = DataAccess.ConInitForDC();

        SqlCommand sc = new SqlCommand("SELECT IsRegNo FROM IsInterfaceRegNo where  branchid=" + branchid + "", conn);

        bool flag = true;

        try
        {
            conn.Open();
            object obj = sc.ExecuteScalar();
            if (obj == DBNull.Value || obj == null)
            {
                flag = true;
            }
            else
            {
                flag = Convert.ToBoolean(obj);
            }
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
                // Log an event in the Application Event Log.
                throw;
            }

        }
        return flag;
    }

    public  int getMaxNumber_signid(int branchid)
    {
        int iNum = 0;
        SqlConnection conn = DataAccess.ConInitForDC();
        SqlCommand sc = new SqlCommand("select max(signatureid) from DRST where branchid=" + branchid + "", conn);
        try
        {
            conn.Open();
            object o = sc.ExecuteScalar();
            if (o == DBNull.Value)
                iNum = 0;
            else
                iNum = Convert.ToInt32(o);
            // This is not a while loop. It only loops once.
        }
        catch (Exception ex)
        {
            throw;
        }
        finally
        {
            try
            {
                //conn.Close(); conn.Dispose();
            }
            catch (SqlException)
            {
                // Log an event in the Application Event Log.
                throw;
            }

        }
        return iNum+1;
    }

    public bool Insert_MainDoctor()
    {


        SqlConnection conn = DataAccess.ConInitForDC();
        SqlCommand sc = new SqlCommand("" +
        "Insert into DRST (signatureid,Drsignature,[username],[branchid],Degree,SignPicture) " +
         " values(@signatureid,@Drsignature,@username,@branchid,@Degree,@SignPicture)", conn);
        // Add the employee ID parameter and set its value.
        sc.Parameters.Add(new SqlParameter("@signatureid", SqlDbType.Int)).Value = Drid;
        sc.Parameters.Add(new SqlParameter("@Drsignature", SqlDbType.NVarChar, 50)).Value = this.Name;
        sc.Parameters.Add(new SqlParameter("@username", SqlDbType.NVarChar, 50)).Value = (this.Username); 
        sc.Parameters.Add(new SqlParameter("@branchid", SqlDbType.Int)).Value = P_branchid;
        sc.Parameters.Add(new SqlParameter("@Degree", SqlDbType.NVarChar, 250)).Value = (this.Degree);
        sc.Parameters.Add(new SqlParameter("@SignPicture", SqlDbType.Binary)).Value = (this.SignPic); 
      

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
    public createuserTable_Bal_C(string uname, string Password, string Usertype, int branchid)
    {
        string msg = "";
       

        SqlConnection conn = DataAccess.ConInitForDC(); 

        SqlCommand sc = new SqlCommand("SELECT * from CTuser where Username=@Username and Password=@Password and Usertype=@Usertype branchid=" + branchid + "", conn);//'"+uname+"'",conn);// +

        // Add the employee ID parameter and set its value.
        sc.Parameters.Add(new SqlParameter("@Username", SqlDbType.NVarChar, 50)).Value = uname;
        sc.Parameters.Add(new SqlParameter("@Password", SqlDbType.NVarChar, 10)).Value = Password;
        sc.Parameters.Add(new SqlParameter("@Usertype", SqlDbType.NVarChar, 250)).Value = Usertype;

        SqlDataReader sdr = null;

        try
        {
            SqlConnection.ClearAllPools();
            conn.Open();
            try
            {
                sdr = sc.ExecuteReader();
            }
            catch { }

            if (sdr != null && sdr.Read())
            {
                this.Username = sdr["Username"].ToString();
                this.Password = sdr["Password"].ToString();
               
                this.Usertype = sdr["Usertype"].ToString();

                if (sdr["Drid"] != DBNull.Value)
                    this.Drid = Convert.ToInt32(sdr["Drid"]);

                if (sdr["CenterCode"] != DBNull.Value)
                    this.CenterCode = sdr["CenterCode"].ToString();
                this.Name = sdr["Name"].ToString();

               
                this.LBcode = sdr["LBcode"].ToString();
            }
            else
            {
                throw new createuserTable_Bal_CTableException("No Record Fetched.");
            }
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
            catch (createuserTable_Bal_CTableException)
            {
                throw new createuserTable_Bal_CTableException("Record not found");
            }
        }
    }
    public createuserTable_Bal_C(string CenterCode, int i, int branchid)
    {
        SqlConnection conn = DataAccess.ConInitForDC();
        SqlCommand sc = new SqlCommand("SELECT * from CTuser where CenterCode=@CenterCode and branchid=" + branchid + "", conn);
        // Add the employee ID parameter and set its value.
        sc.Parameters.Add(new SqlParameter("@CenterCode", SqlDbType.NVarChar, 50)).Value = CenterCode; 
        SqlDataReader sdr = null;

        try
        {
            conn.Open();           
            sdr = sc.ExecuteReader();
           
            if (sdr != null && sdr.Read())
            {
                this.Username = sdr["Username"].ToString();
                this.Password = sdr["Password"].ToString();
              
                this.Usertype = sdr["Usertype"].ToString();

                if (sdr["Drid"] != DBNull.Value)
                    this.Drid = Convert.ToInt32(sdr["Drid"]);

                if (sdr["CenterCode"] != DBNull.Value)
                    this.CenterCode = sdr["CenterCode"].ToString();
                this.Name = sdr["Name"].ToString();

                
                this.LBcode = sdr["LBcode"].ToString();
            }
           
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
            catch (createuserTable_Bal_CTableException)
            {
                throw new createuserTable_Bal_CTableException("Record not found");
            }
        }
    }
    public createuserTable_Bal_C(string uname, int branchid)
    {
        SqlConnection conn = DataAccess.ConInitForDC(); 
        SqlCommand sc = new SqlCommand("SELECT * from CTuser where Username=@Username and branchid=" + branchid + "", conn);        
        sc.Parameters.Add(new SqlParameter("@Username", SqlDbType.NVarChar, 50)).Value = uname;

        SqlDataReader sdr = null;

        try
        {
            conn.Open();
            sdr = sc.ExecuteReader();
            if (sdr != null && sdr.Read())
            {
                this.Username = sdr["Username"].ToString();
                this.Password = sdr["Password"].ToString();
              
                this.Usertype = sdr["Usertype"].ToString();

                if (sdr["CenterCode"] != DBNull.Value)
                    this.CenterCode = sdr["CenterCode"].ToString();
                this.Name = sdr["Name"].ToString();


                if (sdr["Drid"] != DBNull.Value)
                    this.Drid = int.Parse(sdr["Drid"].ToString());
                else
                    this.Drid = 0;
                this.LBcode = sdr["LBcode"].ToString();
                if (sdr["branchid"] != DBNull.Value)
                    this.P_branchid = Convert.ToInt32(sdr["branchid"].ToString());                
                if(sdr["maindeptid"]!=DBNull.Value)
                this.MainDept=Convert.ToString(sdr["maindeptid"]);
            }

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
    public createuserTable_Bal_C(string uname, string Password)
    {
        string msg = ""; 
        SqlConnection conn = DataAccess.ConInitForDC();

        SqlCommand sc = new SqlCommand("SELECT CTuser.CUId, CTuser.username, CTuser.password, CTuser.catagory, CTuser.dateofaccount, CTuser.DRid, CTuser.Usertype, CTuser.LBcode, upper(CTuser.Name) as Name, CTuser.Unlock_Flag, CTuser.uname, CTuser.maindeptid, " +
                              "  CTuser.branchid, CTuser.CenterCode, CTuser.RollId, CTuser.Email, CTuser.PhoneNumber, CTuser.MobileNo, "+
                              "  CTuser.EmpId, CTuser.isactive, CTuser.ModuleName from CTuser where Username=@Username and Password=@Password and isactive=1", conn);

        // Add the employee ID parameter and set its value.
        sc.Parameters.Add(new SqlParameter("@Username", SqlDbType.NVarChar, 50)).Value = uname;
        sc.Parameters.Add(new SqlParameter("@Password", SqlDbType.NVarChar,50)).Value = Password;        
        SqlDataReader sdr = null;

        try
        {
            conn.Open();
            sdr = sc.ExecuteReader();
            if (sdr != null && sdr.Read())
            {
                this.Username = sdr["Username"].ToString();
                this.Password = sdr["Password"].ToString();

                if (sdr["branchid"] != DBNull.Value)
                    this.P_branchid = Convert.ToInt32(sdr["branchid"]);
                if (sdr["Maindeptid"] != DBNull.Value)
                    this.MainDept = Convert.ToString(sdr["Maindeptid"]);
                if (sdr["Usertype"] != DBNull.Value)
                    this.Usertype = Convert.ToString(sdr["Usertype"]);
                UserId = Convert.ToInt32(sdr["CUId"]);
                if (sdr["EmpId"] != DBNull.Value)
                    this.EmpId = Convert.ToInt32(sdr["EmpId"]);

                //if (sdr["ModuleId"] != DBNull.Value)
                //    this.P_ModuleId = Convert.ToInt32(sdr["ModuleId"]);
                if (sdr["Name"] != DBNull.Value)
                    this.Name = Convert.ToString(sdr["Name"]);
                if (sdr["ModuleName"] != DBNull.Value)
                    this.P_ModuleName = Convert.ToString(sdr["ModuleName"]);


            }
            else
            {
                conn.Close();
                conn.Dispose();
                SqlConnection conn1 = DataAccess.ConInitForDC();
                conn1.Open();
                SqlCommand sc1 = new SqlCommand("SELECT * from PatientInformation where PatuserName=@Username and Patpassword=@Password", conn1);
                sc1.Parameters.Add(new SqlParameter("@Username", SqlDbType.NVarChar, 50)).Value = uname;
                sc1.Parameters.Add(new SqlParameter("@Password", SqlDbType.NVarChar, 50)).Value = Password;
                sdr = sc1.ExecuteReader();
                if (sdr != null && sdr.Read())
                {
                    this.Username = sdr["PatuserName"].ToString();
                    this.Password = sdr["Patpassword"].ToString();

                    this.Usertype = sdr["Usertype"].ToString();
                    this.UnitCode = sdr["PatRegId"].ToString();

                    this.Name = sdr["FirstName"].ToString();

                    this.branchid = Convert.ToInt32(sdr["branchid"].ToString());
                    this.P_ModuleName = Convert.ToString("HMS");
                    this.MainDept = Convert.ToString("0");
                    this.EmpId = Convert.ToInt32(0);
                }
                else
                {
                    this.Username = "";
                    this.Password = "";
                }
                
                
                conn1.Close(); conn1.Dispose();
            }
            
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
            catch (createuserTable_Bal_CTableException)
            {
                throw new createuserTable_Bal_CTableException("Record not found");
            }
        }
    }


    internal class createuserTable_Bal_CTableException : Exception
    {
        public createuserTable_Bal_CTableException(string msg) : base(msg) { }
    }

    public void UpdateDrCode(string Centercode, string uname, int branchid)
    {
        SqlConnection conn = DataAccess.ConInitForDC();

        SqlCommand sc = new SqlCommand("update CTuser set Centercode =@Centercode where Username=@Username and branchid=" + branchid + "", conn);
        sc.Parameters.Add(new SqlParameter("@Username", SqlDbType.NVarChar, 50)).Value = uname;
        sc.Parameters.Add(new SqlParameter("@Centercode", SqlDbType.NVarChar, 100)).Value = Centercode;
       
        try
        {
            conn.Open();
            sc.ExecuteNonQuery();
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
            catch (createuserTable_Bal_CTableException)
            {
                throw new createuserTable_Bal_CTableException("Error Updating");
            }
        }
    }
    
    public static bool isUserNameExists(string uName)
    {
        SqlConnection conn = DataAccess.ConInitForDC();
        SqlCommand sc = new SqlCommand(" select count(*) from CTuser where username='" + uName + "'", conn);

        int number = 0;

        try
        {
            conn.Open();
            number = Convert.ToInt16(sc.ExecuteScalar());
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
                // Log an event in the Application Event Log.
                throw;
            }
            
        }
        if (number == 0)
        {
            return false;
        }
        else
            return true;
    }

    public bool Insert(int branchid)
    {
        SqlConnection conn = DataAccess.ConInitForDC();
        SqlCommand sc = new SqlCommand("" +
        "Insert into CTuser ([username], [password],  [dateofaccount],   [CenterCode],  [Drid], [Usertype], [Name],[LBcode],[branchid],uname) " +
         " values(@username, @password,  @dateofaccount,   @CenterCode, @Drid, @Usertype, @Name, @LBcode,@branchid,@uname)", conn);

        sc.Parameters.Add(new SqlParameter("@username", SqlDbType.NVarChar, 50)).Value = (this.Username);
        sc.Parameters.Add(new SqlParameter("@password", SqlDbType.NVarChar, 5)).Value = this.Password;
       
        sc.Parameters.Add(new SqlParameter("@Usertype", SqlDbType.NVarChar, 50)).Value = (this.Usertype);
             
        sc.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar, 50)).Value = this.Name;       
        sc.Parameters.Add(new SqlParameter("@dateofaccount", SqlDbType.DateTime)).Value = Date.getdate().Date;
       
        if (this.Drid == null)
            sc.Parameters.Add(new SqlParameter("@Drid", SqlDbType.Int, 9)).Value = DBNull.Value;
        else
            sc.Parameters.Add(new SqlParameter("@Drid", SqlDbType.Int, 9)).Value = this.Drid;
        if (this.CenterCode == null)
            sc.Parameters.Add(new SqlParameter("@CenterCode", SqlDbType.NVarChar, 50)).Value = DBNull.Value;
        else
            sc.Parameters.Add(new SqlParameter("@CenterCode", SqlDbType.NVarChar, 50)).Value = this.CenterCode;
        sc.Parameters.Add(new SqlParameter("@LBcode", SqlDbType.NVarChar, 50)).Value = this.LBcode;
        sc.Parameters.Add(new SqlParameter("@uname", SqlDbType.NVarChar, 50)).Value = (this.Username); ;
       
        sc.Parameters.Add(new SqlParameter("@branchid", SqlDbType.Int)).Value = branchid;
        conn.Close();
        try
        {
            conn.Open();
            try
            {
                sc.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }
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
        return true;
    }

    public bool Update(string CenterCode, int branchid)
    {
        this.CenterCode = CenterCode;       
        SqlConnection conn = DataAccess.ConInitForDC(); 
        SqlCommand sc = new SqlCommand("" +
        "Update CTuser SET username=@username, password=@password,  dateofaccount=@dateofaccount,  Drid=@Drid, Usertype=@Usertype, Name=@Name, LBcode=@LBcode where CenterCode=@CenterCode and CenterCode<>'' and branchid=" + branchid + "", conn);
       
        sc.Parameters.Add(new SqlParameter("@username", SqlDbType.NVarChar, 50)).Value = (this.Username);
        sc.Parameters.Add(new SqlParameter("@password", SqlDbType.NVarChar, 50)).Value = this.Password;
       
        sc.Parameters.Add(new SqlParameter("@Usertype", SqlDbType.NVarChar, 50)).Value = (this.Usertype);
       
        
        sc.Parameters.Add(new SqlParameter("@dateofaccount", SqlDbType.DateTime)).Value = Date.getdate().Date;
       

        if (this.Drid == null)
            sc.Parameters.Add(new SqlParameter("@Drid", SqlDbType.Int, 9)).Value = DBNull.Value;
        else
            sc.Parameters.Add(new SqlParameter("@Drid", SqlDbType.Int, 9)).Value = this.Drid;

        if (this.CenterCode == null)
            sc.Parameters.Add(new SqlParameter("@CenterCode", SqlDbType.NVarChar, 50)).Value = DBNull.Value;
        else
            sc.Parameters.Add(new SqlParameter("@CenterCode", SqlDbType.NVarChar, 50)).Value = this.CenterCode;
        sc.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar, 50)).Value = this.Name;
        sc.Parameters.Add(new SqlParameter("@LBcode", SqlDbType.NVarChar, 50)).Value = this.LBcode;
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
                throw;
            }
        }        
        return true;
    }



    public bool Update(int branchid)
    {
        SqlConnection conn = DataAccess.ConInitForDC(); 
        SqlCommand sc = new SqlCommand("" +
        "Update CTuser SET username=@username, password=@password, dateofaccount=@dateofaccount, Drid=@Drid, Name=@Name where  Usertype=@Usertype and branchid=" + branchid + "", conn);
        
        sc.Parameters.Add(new SqlParameter("@username", SqlDbType.NVarChar, 50)).Value = (this.Username);
        sc.Parameters.Add(new SqlParameter("@password", SqlDbType.NVarChar, 50)).Value = this.Password;
      
        sc.Parameters.Add(new SqlParameter("@Usertype", SqlDbType.NVarChar, 50)).Value = (this.Usertype);
       
        sc.Parameters.Add(new SqlParameter("@dateofaccount", SqlDbType.DateTime)).Value = Date.getdate().Date;        

        if (this.Drid == null)
            sc.Parameters.Add(new SqlParameter("@Drid", SqlDbType.Int, 9)).Value = DBNull.Value;
        else
            sc.Parameters.Add(new SqlParameter("@Drid", SqlDbType.Int, 9)).Value = this.Drid;
    
        if (this.CenterCode == null)
            sc.Parameters.Add(new SqlParameter("@CenterCode", SqlDbType.NVarChar, 50)).Value = DBNull.Value;
        else
            sc.Parameters.Add(new SqlParameter("@CenterCode", SqlDbType.NVarChar, 50)).Value = this.CenterCode;

        sc.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar, 50)).Value = this.Name;
        sc.Parameters.Add(new SqlParameter("@LBcode", SqlDbType.NVarChar, 50)).Value = this.LBcode;

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
        
        return true;
    } 

    public void UpdateByUname(string uname, int branchid)
    {
        SqlConnection conn = DataAccess.ConInitForDC();

        SqlCommand sc = new SqlCommand("update CTuser set username=@username ,Name=@Name,password=@password,Usertype=@Usertype,Drid=@Drid,LBcode=@LBcode where username='" + uname + "' and branchid=" + branchid + "", conn);
       
        sc.Parameters.Add(new SqlParameter("@Username", SqlDbType.NVarChar, 50)).Value = this.username ;
        sc.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar, 50)).Value =(string)(this.Name) ;
        sc.Parameters.Add(new SqlParameter("@password", SqlDbType.NVarChar, 50)).Value = (string)(this.password);
      
        sc.Parameters.Add(new SqlParameter("@Usertype", SqlDbType.NVarChar, 250)).Value = (string)(this.Usertype);
       
        sc.Parameters.Add(new SqlParameter("@Drid", SqlDbType.Int , 8)).Value = (int)(this.Drid);
        sc.Parameters.Add(new SqlParameter("@LBcode", SqlDbType.NVarChar, 50)).Value = this.LBcode;       
        try
        {
            conn.Open();
            sc.ExecuteNonQuery();
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
            catch (createuserTable_Bal_CTableException)
            {
                throw new createuserTable_Bal_CTableException("Error Updating");
            }
        }
    }

   
    public void delete(string uname, int branchid)
    {
        SqlConnection conn = DataAccess.ConInitForDC();
        SqlCommand sc = new SqlCommand("delete from CTuser where username='" + uname + "' and branchid=" + branchid + "", conn);

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


    public bool UpdateByUserName(string uname, int branchid)
    {        
        SqlConnection conn = DataAccess.ConInitForDC();       
        SqlCommand sc = new SqlCommand("" +
        "Update CTuser set username=@username, password=@password, dateofaccount=@dateofaccount,   DRid=@Drid, Usertype=@Usertype, Name=@Name,  LBcode=@LBcode where  username='" + uname + "' and branchid=" + branchid + "", conn);
        
        sc.Parameters.Add(new SqlParameter("@username", SqlDbType.NVarChar, 50)).Value = (this.Username);
        sc.Parameters.Add(new SqlParameter("@password", SqlDbType.NVarChar, 50)).Value = this.Password;
       
        sc.Parameters.Add(new SqlParameter("@dateofaccount", SqlDbType.DateTime)).Value = Date.getdate().Date;
      
        if (this.Drid == null)
            sc.Parameters.Add(new SqlParameter("@Drid", SqlDbType.Int, 9)).Value = DBNull.Value;
        else
            sc.Parameters.Add(new SqlParameter("@Drid", SqlDbType.Int, 9)).Value = this.Drid;

        if (this.CenterCode == null)
            sc.Parameters.Add(new SqlParameter("@CenterCode", SqlDbType.NVarChar, 50)).Value = DBNull.Value;
        else
            sc.Parameters.Add(new SqlParameter("@CenterCode", SqlDbType.NVarChar, 50)).Value = this.CenterCode;

        sc.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar, 50)).Value = this.Name;
        sc.Parameters.Add(new SqlParameter("@LBcode", SqlDbType.NVarChar, 50)).Value = this.LBcode;

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
         return true;
    }

    public void UpdateUnlockFlag(int Uflg, DateTime dtime, string drcd, int branchid)
    {
        SqlConnection conn = DataAccess.ConInitForDC();
        SqlCommand sc = new SqlCommand("update CTuser set Unlock_Flag =@Unlock_Flag where CenterCode=@CenterCode and CenterCode<>'' and branchid=" + branchid + "", conn);             
        sc.Parameters.Add(new SqlParameter("@Unlock_Flag", SqlDbType.Bit, 1)).Value = Uflg;
        sc.Parameters.Add(new SqlParameter("@TimeLimit", SqlDbType.DateTime)).Value = dtime;
        sc.Parameters.Add(new SqlParameter("@CenterCode", SqlDbType.NVarChar, 50)).Value = drcd;
       
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
    
  
    
 
    public static string getCCCodeByUserName(string userName, int branchid)
    {

        SqlConnection conn = DataAccess.ConInitForDC();

        SqlCommand sc = new SqlCommand(" select CenterCode from CTuser where username='" + userName + "'and branchid=" + branchid + "", conn);

        object drName = null;

        try
        {
            conn.Open();
            drName = sc.ExecuteScalar();
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
            catch (Exception)
            {
                throw new Exception("Record not found");
            }
        }
        return drName.ToString();
    }
    

    
  
    
    public static bool CheckUnlockFlag(string CenterCode, int branchid)
    {

        SqlConnection conn = DataAccess.ConInitForDC();

        SqlCommand sc = new SqlCommand("SELECT CTuser.Unlock_Flag FROM CTuser INNER JOIN DrMT ON CTuser.CenterCode = DrMT.DocCode AND CTuser.branchid = DrMT.branchid where CenterCode='" + CenterCode + "' and CTuser.branchid=" + branchid + "", conn); 

        bool flag=true;

        try
        {
            conn.Open();
            object obj = sc.ExecuteScalar();
            if (obj == DBNull.Value||obj==null)
            {
                flag = true;
            }
            else
            {
                flag = Convert.ToBoolean(obj);
            }
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
                // Log an event in the Application Event Log.
                throw;
            }
            
        }
        return flag;
    }

    

 
    public void UpdateDoctorUserName(string userName, string Password, string CenterCode, int branchid)
    {
        SqlConnection conn = DataAccess.ConInitForDC();
        SqlCommand sc = new SqlCommand("update CTuser set Username=@Username,Password=@Password where CenterCode='" + CenterCode + "' and branchid=" + branchid + "", conn);

        sc.Parameters.Add(new SqlParameter("@username", SqlDbType.NVarChar, 50)).Value = userName;
        sc.Parameters.Add(new SqlParameter("@Password", SqlDbType.NVarChar, 50)).Value = Password;

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

    public bool Insert_UpdateCTUser(int CUId)
    {


        SqlConnection conn = DataAccess.ConInitForDC();

        SqlCommand sc = new SqlCommand("update CTuser set [username]=@username, [password]=@password,catagory=@catagory , [CenterCode]= @CenterCode,   [Usertype]=@Usertype,[Name]= @Name, [LBcode]=@LBcode,uname=@username,maindeptid=@maindeptid,Rollid=@RollId,Email=@Email,PhoneNumber=@PhoneNumber,MobileNo=@MobileNo,ModuleName=@ModuleName,isactive=@IsActive where CUId=" + CUId + "", conn);

        sc.Parameters.Add(new SqlParameter("@username", SqlDbType.NVarChar, 50)).Value = (this.Username);
        sc.Parameters.Add(new SqlParameter("@password", SqlDbType.NVarChar, 50)).Value = this.Password;

        sc.Parameters.Add(new SqlParameter("@Usertype", SqlDbType.NVarChar, 50)).Value = (this.Usertype);
        sc.Parameters.Add(new SqlParameter("@catagory", SqlDbType.NVarChar, 50)).Value = this.P_catagory;
        sc.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar, 50)).Value = this.Name;

        sc.Parameters.Add(new SqlParameter("@dateofaccount", SqlDbType.DateTime)).Value = Date.getdate().Date;

        if (this.Drid == null)
            sc.Parameters.Add(new SqlParameter("@Drid", SqlDbType.Int, 9)).Value = DBNull.Value;
        else
            sc.Parameters.Add(new SqlParameter("@Drid", SqlDbType.Int, 9)).Value = this.Drid;

        if (this.CenterCode == null)
            sc.Parameters.Add(new SqlParameter("@Centercode", SqlDbType.NVarChar, 50)).Value = DBNull.Value;
        else
            sc.Parameters.Add(new SqlParameter("@Centercode", SqlDbType.NVarChar, 50)).Value = this.CenterCode;

        if (this.LBcode == null)
            sc.Parameters.Add(new SqlParameter("@LBcode", SqlDbType.NVarChar, 50)).Value = DBNull.Value;
        else
            sc.Parameters.Add(new SqlParameter("@LBcode", SqlDbType.NVarChar, 50)).Value = this.LBcode;

        sc.Parameters.Add(new SqlParameter("@branchid", SqlDbType.Int)).Value = P_branchid;
        sc.Parameters.Add(new SqlParameter("@maindeptid", SqlDbType.Int)).Value = maindeptid;
        sc.Parameters.Add(new SqlParameter("@RollId", SqlDbType.Int)).Value = P_RoleId;

        sc.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar, 50)).Value = P_Email;
        sc.Parameters.Add(new SqlParameter("@PhoneNumber", SqlDbType.NVarChar, 50)).Value = P_PhoneNo;
        sc.Parameters.Add(new SqlParameter("@MobileNo", SqlDbType.NVarChar, 50)).Value = P_MobileNo;
        sc.Parameters.Add(new SqlParameter("@ModuleName", SqlDbType.NVarChar, 50)).Value = P_ModuleName;

        sc.Parameters.Add(new SqlParameter("@IsActive", SqlDbType.Bit)).Value = P_ISActive;

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
    public bool Insert()
    {


        SqlConnection conn = DataAccess.ConInitForDC(); 
        SqlCommand sc = new SqlCommand("" +
        "Insert into CTuser ([username], [password],catagory, [dateofaccount],  [CenterCode],   [DRid], [Usertype], [Name],[LBcode],uname,maindeptid,[branchid],Rollid,Email,PhoneNumber,MobileNo,EmpId,ModuleName) " +
         " values(@username, @password,@catagory, @dateofaccount,  @CenterCode,   @DRid, @Usertype, @Name, @LBcode,@username,@maindeptid,@branchid,@RollId,@Email,@PhoneNumber,@MobileNo,@EmpId,@ModuleName)", conn);
        // Add the employee ID parameter and set its value.


        sc.Parameters.Add(new SqlParameter("@username", SqlDbType.NVarChar, 50)).Value = (this.Username);
        sc.Parameters.Add(new SqlParameter("@password", SqlDbType.NVarChar, 50)).Value = this.Password;
        sc.Parameters.Add(new SqlParameter("@catagory", SqlDbType.NVarChar, 50)).Value = this.P_catagory;
        sc.Parameters.Add(new SqlParameter("@Usertype", SqlDbType.NVarChar, 50)).Value = (this.Usertype);
        sc.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar, 50)).Value = this.Name;       

        sc.Parameters.Add(new SqlParameter("@dateofaccount", SqlDbType.DateTime)).Value = Date.getdate().Date;      

        if (this.Drid == null)
            sc.Parameters.Add(new SqlParameter("@Drid", SqlDbType.Int, 9)).Value = DBNull.Value;
        else
            sc.Parameters.Add(new SqlParameter("@Drid", SqlDbType.Int, 9)).Value = this.Drid;
            sc.Parameters.Add(new SqlParameter("@EmpId", SqlDbType.Int)).Value = this.EmpId;
        if (this.CenterCode == null)
            sc.Parameters.Add(new SqlParameter("@Centercode", SqlDbType.NVarChar, 50)).Value = DBNull.Value;
        else
            sc.Parameters.Add(new SqlParameter("@Centercode", SqlDbType.NVarChar, 50)).Value = this.CenterCode;

        if (this.LBcode == null)
            sc.Parameters.Add(new SqlParameter("@LBcode", SqlDbType.NVarChar, 50)).Value = DBNull.Value;
        else
        sc.Parameters.Add(new SqlParameter("@LBcode", SqlDbType.NVarChar, 50)).Value = this.LBcode;

        sc.Parameters.Add(new SqlParameter("@branchid", SqlDbType.Int)).Value = P_branchid;
        sc.Parameters.Add(new SqlParameter("@maindeptid", SqlDbType.Int)).Value = maindeptid;
        sc.Parameters.Add(new SqlParameter("@RollId", SqlDbType.Int)).Value = P_RoleId;

        sc.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar, 50)).Value = P_Email;
        sc.Parameters.Add(new SqlParameter("@PhoneNumber", SqlDbType.NVarChar, 50)).Value = P_PhoneNo;
        sc.Parameters.Add(new SqlParameter("@MobileNo", SqlDbType.NVarChar, 50)).Value = P_MobileNo;

        sc.Parameters.Add(new SqlParameter("@ModuleName", SqlDbType.NVarChar, 50)).Value = P_ModuleName;
        
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
    public void addpatasuser(string name)
    {
        SqlConnection conn = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("update patmst set username=@username,password=@password,A_Flag=@A_Flag,UserType=@UserType where PID=" + _P_ID + "", conn);
        cmd.Parameters.Add(new SqlParameter("@username", SqlDbType.NVarChar, 50)).Value = name;
        cmd.Parameters.Add(new SqlParameter("@password", SqlDbType.NVarChar, 50)).Value = name;
        cmd.Parameters.Add(new SqlParameter("@A_Flag", SqlDbType.Bit)).Value = true;
        cmd.Parameters.Add(new SqlParameter("@usertype", SqlDbType.NVarChar, 250)).Value = usertype;
        try
        {
            conn.Open();
            cmd.ExecuteNonQuery();
        }
        catch { }
        finally
        {
            conn.Close();
            conn.Dispose();
        }
    }

    public bool DoctorRecordExistChk(string CenterCode, int i, int branchid)
    {
        SqlConnection conn = DataAccess.ConInitForDC();
        SqlCommand sc = new SqlCommand("SELECT * from CTuser where CenterCode=@CenterCode and branchid=" + branchid + "", conn);
        sc.Parameters.Add(new SqlParameter("@CenterCode", SqlDbType.NVarChar, 50)).Value = CenterCode;
        SqlDataReader sdr = null;
        bool DoctorExistFlag = false;

        try
        {
            conn.Open();            
            sdr = sc.ExecuteReader();           

            if (sdr != null && sdr.Read())
            {
                DoctorExistFlag = true;
                this.Username = sdr["Username"].ToString();
                this.Password = sdr["Password"].ToString();
               
                this.Usertype = sdr["Usertype"].ToString();

                if (sdr["DRid"] != DBNull.Value)
                    this.Drid = Convert.ToInt32(sdr["DRid"]);

                if (sdr["CenterCode"] != DBNull.Value)
                    this.CenterCode = sdr["CenterCode"].ToString();
            
               
                this.LBcode = sdr["LBcode"].ToString();
            }
            else
            {
                DoctorExistFlag = false;
            }
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
            catch (createuserTable_Bal_CTableException)
            {
                throw new createuserTable_Bal_CTableException("Record not found");
            }
        }
        return DoctorExistFlag;
    }

    public static DataTable Get_Alluser(int branchid)
    {

        SqlConnection conn = DataAccess.ConInitForDC();
        SqlDataAdapter da;
        string query = "select DISTINCT subdeptname,subdeptid from SubDepartment where  branchid =" + branchid + "";



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
      public DataTable Get_AlluserDetails(int id,int branchid)
    {
        DataTable dt = new DataTable();
        SqlConnection conn = DataAccess.ConInitForDC();
        try
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT  "+
              "  CTuser.CUId, CTuser.username, CTuser.password, CTuser.catagory, CTuser.dateofaccount, CTuser.DRid, CTuser.Usertype, CTuser.LBcode, CTuser.Name, "+
              "  CTuser.Unlock_Flag, CTuser.uname, CTuser.maindeptid, CTuser.branchid, CTuser.CenterCode, CTuser.RollId, CTuser.Email, CTuser.PhoneNumber, CTuser.MobileNo, "+
              "  DRST.SignPicture, DRST.Degree,CTuser.ModuleName ,CTuser.isactive" +
              "  FROM         CTuser LEFT OUTER JOIN "+
              "  DRST ON CTuser.DRid = DRST.signatureid where  CTuser.branchid =" + branchid + " and CUid=" + id + " ", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }
        catch (Exception ex) { throw; }
        finally { conn.Close(); conn.Dispose(); }
        return dt;
    }

      public DataTable Get_VW_Phlebotomist_acceptReject_Usewise( int branchid)
      {
          DataTable dt = new DataTable();
          SqlConnection conn = DataAccess.ConInitForDC();
          try
          {
              conn.Open();
              SqlCommand cmd = new SqlCommand("SELECT  " +
                " DATEDIFF(MINUTE, createdon,updatedon)as DiffTime, * from VW_Phlebotomist_acceptReject_Usewise where  VW_Phlebotomist_acceptReject_Usewise.branchid =" + branchid + "  Order by patmstid desc ", conn);
              SqlDataAdapter da = new SqlDataAdapter(cmd);
              da.Fill(dt);
          }
          catch (Exception ex) { throw; }
          finally { conn.Close(); conn.Dispose(); }
          return dt;
      }
      public DataSet FillDept_New(string branchid) //, string id)
      {
          SqlConnection con = DataAccess.ConInitForDC();
         // string sql = "select deptid,DeptName from maindepartment where deptid in(1,2) ";//branchid=" + branchid + " and 
          string sql = "select DeptId,DeptName from DepartmentMst ";
          sql += " order by DeptName";
          SqlDataAdapter da = new SqlDataAdapter(sql, con);
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

      public DataSet FillLab(string branchid)
      {

          SqlConnection con = DataAccess.ConInitForDC();
          string sql = "select DoctorCode,DoctorName from DrMT where branchid=" + branchid + " "; //and DrCheck_flag='TE'";

          sql += " order by DoctorCode";
          SqlDataAdapter da = new SqlDataAdapter(sql, con);
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

      public DataSet Fill_CenterCode(string branchid, string id)
      {
          SqlConnection con = DataAccess.ConInitForDC();
          string sql = "select DoctorCode,DoctorName from  DrMT where branchid=" + branchid + "  ";

          sql += " order by DoctorName";
          SqlDataAdapter da = new SqlDataAdapter(sql, con);
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

      public DataTable ReadTable(String SELSTR)
      {
          SqlConnection con = DataAccess.ConInitForDC();//DataAccess.ConInitForDC(); 
          SELSTR = SELSTR.Replace("&amp;", "&");
          SqlDataAdapter DA = new SqlDataAdapter(SELSTR, con);
          DataTable DT = new DataTable();
          DA.Fill(DT);
          con.Close(); con.Dispose();
          return DT;
      }

      public createuserTable_Bal_C FillInformation(int EmpId)
      {
          createuserTable_Bal_C obj1=new createuserTable_Bal_C();
          SqlConnection con = DataAccess.ConInitForDC();
          con.Open();
          SqlCommand cmd = new SqlCommand("Sp_UserEmpInformation", con);
          cmd.CommandType = CommandType.StoredProcedure;
          cmd.Parameters.AddWithValue("@EmpId", EmpId);
          SqlDataReader sdr = cmd.ExecuteReader();
          while (sdr.Read())
          {
            //  sd
          }

          return obj1;
      }

 

    #region Properties
      private int _UserId;
      public int UserId
      {
          get { return _UserId; }
          set { _UserId = value; }
      }
    private string username;
    public string Username
    {
        get { return username; }
        set { username = value; }
    }
   
    private int drid;
    public int Drid
    {
        get { return drid; }
        set { drid = value; }
    }
    private string password;
    public string Password
    {
        get { return password; }
        set { password = value; }
    }
    //private string uname;
    //public string P_username
    //{
    //    get { return uname; }
    //    set { uname = value; }
    //}
    //private string conform;
    //public string Conform
    //{
    //    get { return conform; }
    //    set { conform = value; }
    //}
    private string email;
    public string P_Email
    {
        get { return email; }
        set { email = value; }
    }
    private string PhoneNo;
    public string P_PhoneNo
    {
        get { return PhoneNo; }
        set { PhoneNo = value; }
    }
    private string MobileNo;
    public string P_MobileNo
    {
        get { return MobileNo; }
        set { MobileNo = value; }
    }
    //private string securityquest;
    //public string Securityquest
    //{
    //    get { return securityquest; }
    //    set { securityquest = value; }
    //}
    //private string securityans;
    //public string Securityans
    //{
    //    get { return securityans; }
    //    set { securityans = value; }
    //}
    private string degree;
    public string Degree
    {
        get { return degree; }
        set { degree = value; }
    }
    private byte signpic;
    public byte SignPic
    {
        get { return signpic; }
        set { signpic = value; }
    }
    
    private string usertype;
    public string Usertype
    {
        get { return usertype; }
        set { usertype = value; }
    }

    private string centerCode = "";
    public string CenterCode
    {
        get { return centerCode; }
        set { centerCode = value; }
    }
    private string _Name = "";
    public string Name
    {
        get { return _Name; }
        set { _Name = value; }
    }

    //private string _NameA = "";
    //public string NameA
    //{
    //    get { return _NameA; }
    //    set { _NameA = value; }
    //}

    //private bool _AFlag;
    //public bool AFlag
    //{
    //    get { return _AFlag; }
    //    set { _AFlag = value; }
    //}

    private bool Unlock_Flag;
    public bool P_Unlock_Flag
    {
        get { return Unlock_Flag; }
        set { Unlock_Flag = value; }
    }
    private string _lab_code;
    public string LBcode
    {
        get { return _lab_code; }
        set { _lab_code = value; }
    }
    private string _MainDept;
    public string MainDept
    {
        get { return _MainDept; }
        set { _MainDept = value; }
    }
    //private string _Designation;
    //public string Designation
    //{
    //    get { return _Designation; }
    //    set { _Designation= value; }
    //}
    private int branchid;
    public int P_branchid
    { get { return branchid; }
        set { branchid = value; } }

    //private int signid1;
    //public int P_signid1
    //{
    //    get { return signid1; }
    //    set { signid1 = value; }
    //}
    

        private int _P_ID;
        public int PID
        {
            get { return _P_ID; }
            set { _P_ID = value; }
        }
        private int RoleId;
        public int P_RoleId
        {
            get { return RoleId; }
            set { RoleId = value; }
        }
    private string catagory;public string P_catagory{ get { return catagory; }set { catagory = value; }}
    private string ModuleName; public string P_ModuleName { get { return ModuleName; } set { ModuleName = value; } }
    //private string accesslevel; public string P_accesslevel { get { return accesslevel; } set { accesslevel = value; } }
    //private string Falseauthority; public string P_Falseauthority { get { return Falseauthority; } set { Falseauthority = value; } }
    private DateTime dateofaccount; public DateTime P_dateofaccount { get { return dateofaccount; } set { dateofaccount = value; } }
    private int _maindeptid;
    public int maindeptid
    {
        get { return _maindeptid; }
        set { _maindeptid = value; }
    }
    private int _EmpId;
    public int EmpId
    {
        get { return _EmpId; }
        set { _EmpId = value; }
    }

    private bool ISActive; public bool P_ISActive { get { return ISActive; } set { ISActive = value; } }
    #endregion
}
