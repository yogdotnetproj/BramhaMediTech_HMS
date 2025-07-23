using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
 public class PackageNameHMS_Bal_C
    {
        internal class PackageNameHMS_Bal_CException : Exception
        {
            public PackageNameHMS_Bal_CException(string msg) : base(msg) { }
        }

   
        #region Properties

        string _RateType = "";
        public String RateType
        {
            get
            {
                return _RateType;
            }
            set
            {
                _RateType = value;
            }
        }

        string _PackType = "";
        public String PackType
        {
            get
            {
                return _PackType;
            }
            set
            {
                _PackType = value;
            }
        }
        string _PackageCode = "";
        public String PackageCode
        {
            get
            {
                return _PackageCode;
            }
            set
            {
                _PackageCode = value;
            }
        }

        string _Qty = "";
        public String Qty
        {
            get
            {
                return _Qty;
            }
            set
            {
                _Qty = value;
            }
        }

        string _PackageName = "";
        public String PackageName
        {
            get
            {
                return _PackageName;
            }
            set
            {
                _PackageName = value;
            }
        }
        string _ServiceName = "";
      public String ServiceName
        {
            get
            {
                return _ServiceName;
            }
            set
            {
                _ServiceName = value;
            }
        }

      int _ServiceId ;
      public int ServiceId
        {
            get
            {
                return _ServiceId;
            }
            set
            {
                _ServiceId = value;
            }
        }

     
        int? _PackageRateAmount;
        public int? PackageRateAmount
        {
            get
            {
                return _PackageRateAmount;
            }
            set
            {
                _PackageRateAmount = value;
            }
        }
       
       
        string _Flag = null;
        public String Flag
        {
            get
            {
                return _Flag;
            }
            set
            {
                _Flag = value;
            }
        }
        

        DateTime? _DateofEntry = null;
        public DateTime? Patregdate
        {
            get
            {
                return _DateofEntry;
            }
            set
            {
                _DateofEntry = value;
            }
        }
     private string username;
     public string P_username
     {
         get { return username; }
         set { username = value; }
     }
        #endregion
        #region Constructors
        public PackageNameHMS_Bal_C()
        {
            this.PackageCode = "";
            this.PackageName = "";
            this.PackageRateAmount = 0;
            
           
            this.Patregdate = Date.getOnlydate();
        }
        public PackageNameHMS_Bal_C(String sGroupCode)
        {
            SqlConnection conn = DataAccess.ConInitForDC();
            SqlCommand sc = new SqlCommand(" SELECT * from PackMst " +
                             " WHERE PackageCode = @PackageCode ", conn);

            
            sc.Parameters.Add(new SqlParameter("@PackageCode", SqlDbType.NVarChar, 500)).Value = (sGroupCode);

            SqlDataReader sdr = null;

            try
            {
                conn.Open();
                sdr = sc.ExecuteReader();

                // This is not a while loop. It only loops once.
                if (sdr != null && sdr.Read())
                {
                    // The IEnumerable contains DataRowView objects.
                    this.PackageCode = sdr["PackageCode"].ToString();
                    this.PackageName = sdr["PackageName"].ToString();
                    this.PackageRateAmount = Convert.ToInt32(sdr["PackageRateAmount"]);
                    this.RateType = sdr["RateType"].ToString();
                    this.Patregdate = Convert.ToDateTime(sdr["DateOfEntry"]);
                    this.PackType = sdr["PackType"].ToString();
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
                    if (sdr != null) sdr.Close();
                    conn.Close(); conn.Dispose();
                }
                catch (SqlException)
                {
                    // Log an event in the Application Event Log.
                    throw;
                }
                
            }
        }
        #endregion
     public bool Insert(int branchid)
        {
            SqlConnection conn = DataAccess.ConInitForDC(); 
            SqlCommand sc = new SqlCommand("" +
            "INSERT INTO PackMst " +
            "(PackageCode, PackageName,RateType,PackageRateAmount,  DateOfEntry,branchid,username,Createdby,PackType) " +
            "VALUES (@PackageCode, @PackageName,@RateType,@PackageRateAmount,  @Patregdate,@branchid,@username,@username,@PackType)", conn);

            sc.Parameters.Add(new SqlParameter("@PackageCode", SqlDbType.NVarChar, 500)).Value = this.PackageCode;
            sc.Parameters.Add(new SqlParameter("@PackageName", SqlDbType.NVarChar, 500)).Value = this.PackageName;
            sc.Parameters.Add(new SqlParameter("@RateType", SqlDbType.NVarChar, 500)).Value = this.RateType;
            sc.Parameters.Add(new SqlParameter("@PackageRateAmount", SqlDbType.Int)).Value = this.PackageRateAmount;
           
        
            sc.Parameters.Add(new SqlParameter("@Patregdate", SqlDbType.DateTime, 4)).Value = this.Patregdate;
           
            sc.Parameters.Add(new SqlParameter("@branchid", SqlDbType.Int)).Value = branchid;
            sc.Parameters.Add(new SqlParameter("@username", SqlDbType.NVarChar, 50)).Value = P_username;

            sc.Parameters.Add(new SqlParameter("@PackType", SqlDbType.NVarChar, 500)).Value = this.PackType;
            SqlDataReader sdr = null;
            try
            {
                conn.Close();
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
                    throw;
                }
            }
            return true;
        }//End Insert

     public bool Delete(int branchid)
        {
            SqlConnection conn = DataAccess.ConInitForDC(); 
            SqlCommand sc = new SqlCommand("" +
                " Delete from PackMst" +
                " Where PackageCode=@PackageCode and branchid=" + branchid + "", conn);
            sc.Parameters.Add(new SqlParameter("@PackageCode", SqlDbType.NVarChar, 500)).Value = this.PackageCode;
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
                    throw;
                }
            }
            return true;
        }//End Delete

     public bool Delete_Details(int branchid)
     {
         SqlConnection conn = DataAccess.ConInitForDC();
         SqlCommand sc = new SqlCommand("" +
             " Delete from PackmstD" +
             " Where PackageCode=@PackageCode  and branchid=" + branchid + "", conn);
         sc.Parameters.Add(new SqlParameter("@PackageCode", SqlDbType.NVarChar, 500)).Value = this.PackageCode;
       
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
                 throw;
             }
         }
         return true;
     }//End Delete

     public bool Delete_DetailsPAckageservice(int branchid, int ServiceId)
     {
         SqlConnection conn = DataAccess.ConInitForDC();
         SqlCommand sc = new SqlCommand("" +
             " Delete from PackmstD" +
             " Where PackageCode=@PackageCode and ServiceId=@ServiceId and branchid=" + branchid + "", conn);
         sc.Parameters.Add(new SqlParameter("@PackageCode", SqlDbType.NVarChar, 500)).Value = this.PackageCode;
         sc.Parameters.Add(new SqlParameter("@ServiceId", SqlDbType.NVarChar, 500)).Value = ServiceId;
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
                 throw;
             }
         }
         return true;
     }//End Delete

     public bool update(string sPrevprofileCode, int branchid)
        {
            SqlConnection conn = DataAccess.ConInitForDC(); 
            SqlCommand sc = new SqlCommand("" +
            "Update PackMst " +
            "Set RateType=@RateType,PackageCode=@PackageCode ,PackageName=@PackageName,PackageRateAmount=@PackageRateAmount,DateOfEntry=@Patregdate  ,Updatedby=@username,Updatedon=@Updatedon,PackType=@PackType  " +
            " Where PackageCode=@PrevprofileCode and branchid=" + branchid + "", conn);


            sc.Parameters.Add(new SqlParameter("@RateType", SqlDbType.NVarChar, 500)).Value = this.RateType;
            sc.Parameters.Add(new SqlParameter("@PackageCode", SqlDbType.NVarChar, 500)).Value = this.PackageCode;
            sc.Parameters.Add(new SqlParameter("@PackageName", SqlDbType.NVarChar, 500)).Value = this.PackageName;
            sc.Parameters.Add(new SqlParameter("@PackageRateAmount", SqlDbType.Int)).Value = this.PackageRateAmount;
            

            sc.Parameters.Add(new SqlParameter("@Patregdate", SqlDbType.DateTime)).Value = this.Patregdate;
            sc.Parameters.Add(new SqlParameter("@PrevprofileCode", SqlDbType.NVarChar, 500)).Value = sPrevprofileCode;
           
            sc.Parameters.Add(new SqlParameter("@username", SqlDbType.NVarChar, 50)).Value = P_username;
            sc.Parameters.Add(new SqlParameter("@Updatedon", SqlDbType.DateTime)).Value = this.Patregdate; ;
            sc.Parameters.Add(new SqlParameter("@PackType", SqlDbType.NVarChar, 500)).Value = this.PackType;
         
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
                    throw;
                }
            }
            return true;
        }//End Update 
    }

