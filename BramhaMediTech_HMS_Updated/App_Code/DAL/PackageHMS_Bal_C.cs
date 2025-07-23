using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

public class PackageHMS_Bal_C
{
    internal class PackageHMS_Bal_CException : Exception
    {
        public PackageHMS_Bal_CException(string msg) : base(msg) { }
    }

  
    #region Properties
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
    DateTime? _dateofentry = null;
    public DateTime? Patregdate
    {
        get
        {
            return _dateofentry;
        }
        set
        {
            _dateofentry = value;
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
    string _SDCode = "";
    public String SDCode
    {
        get
        {
            return _SDCode;
        }
        set
        {
            _SDCode = value;
        }
    }

    //string _Qty = "";
    //public String Qty
    //{
    //    get
    //    {
    //        return _Qty;
    //    }
    //    set
    //    {
    //        _Qty = value;
    //    }
    //}
    float _Qty =0;
    public float Qty
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
    string _MTCode = "";
    public String MTCode
    {
        get
        {
            return _MTCode;
        }
        set
        {
            _MTCode = value;
        }
    }
    string _TestName = null;
    public String TestName
    {
        get
        {
            return _TestName;
        }
        set
        {
            _TestName = value;
        }
    }
    float? _TestRate;
    public float? TestRate
    {
        get
        {
            return _TestRate;
        }
        set
        {
            _TestRate = value;
        }
    }
    int _Testordno;
    public int Testordno
    {
        get
        {
            return _Testordno;
        }
        set
        {
            _Testordno = value;
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
    public PackageHMS_Bal_C()
    {
        this.PackageCode = "";
        this.PackageName = "";
        //Flag	nvarchar	3
        this.SDCode = "";
        this.MTCode = "";
        this.TestName = "";
        this.TestRate = 0f;
        this.Patregdate = Date.getOnlydate();
        this.Testordno = 0;
    }
    public PackageHMS_Bal_C(String PackageCode, String MTCode)
    {
        SqlConnection conn = DataAccess.ConInitForDC();
        SqlCommand sc = new SqlCommand(" SELECT * from PackmstD" +
                         " WHERE PackageCode = @PackageCode and MTCode=@MTCode ", conn);

        // Add the employee ID parameter and set its value.

        sc.Parameters.Add(new SqlParameter("@PackageCode", SqlDbType.NVarChar, 4)).Value = PackageCode;
        sc.Parameters.Add(new SqlParameter("@MTCode", SqlDbType.VarChar, 500)).Value = MTCode;

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
                this.TestRate = Convert.ToSingle(sdr["TestRate"]);
                this.MTCode = sdr["ServiceId"].ToString();
                this.TestName = sdr["ServiceName"].ToString();
               
               
                this.Patregdate = Convert.ToDateTime(sdr["Patregdate"]);
                if (!(sdr["Testordno"] is DBNull))
                    this.Testordno = Convert.ToInt32(sdr["Testordno"]);
                else
                    this.Testordno = 0;
            }
            else
            {
                throw new PackageHMS_Bal_CException("No Record Fetched.");
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
            catch (PackageHMS_Bal_CException)
            {
                throw new PackageHMS_Bal_CException("Record not found");
            }
        }
    }


    public PackageHMS_Bal_C(String PackageCode, String MTCode,string ServiceID,string ServiceName,int branchid)
    {
        SqlConnection conn = DataAccess.ConInitForDC();
        SqlCommand sc = new SqlCommand(" SELECT     distinct   BillService.BillServiceId,  BillService.ServiceName, BillSeviceCharges.rate FROM BillService INNER JOIN BillSeviceCharges ON BillService.BillServiceId = BillSeviceCharges.ServiceId " +
                         " WHERE BillService.BillServiceId = @ServiceID and BillService.branchid=@branchid and  BillSeviceCharges.RateTypeId =@RateTypeId ", conn);

        // Add the employee ID parameter and set its value.

        sc.Parameters.Add(new SqlParameter("@ServiceID", SqlDbType.NVarChar, 50)).Value = ServiceID;
        sc.Parameters.Add(new SqlParameter("@branchid", SqlDbType.VarChar, 500)).Value = branchid;
        sc.Parameters.Add(new SqlParameter("@RateTypeId", SqlDbType.NVarChar, 50)).Value = MTCode;

        SqlDataReader sdr = null;

        try
        {
            conn.Open();
            sdr = sc.ExecuteReader();

            // This is not a while loop. It only loops once.
            if (sdr != null && sdr.Read())
            {
                // The IEnumerable contains DataRowView objects. 
               
                this.TestRate = Convert.ToSingle(sdr["rate"]);
                this.MTCode = sdr["BillServiceId"].ToString();
                this.TestName = sdr["ServiceName"].ToString();


              
            }
            else
            {
                throw new PackageHMS_Bal_CException("No Record Fetched.");
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
            catch (PackageHMS_Bal_CException)
            {
                throw new PackageHMS_Bal_CException("Record not found");
            }
        }
    }


    public PackageHMS_Bal_C(String PackageCode)
    {
        SqlConnection conn = DataAccess.ConInitForDC();
        SqlCommand sc = new SqlCommand(" SELECT * from PackmstD" +
                         " WHERE PackageCode = @PackageCode ", conn);

        // Add the employee ID parameter and set its value.

        sc.Parameters.Add(new SqlParameter("@PackageCode", SqlDbType.NVarChar, 4)).Value = PackageCode;
       

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
                this.TestRate = Convert.ToSingle(sdr["TestRate"]);
                this.SDCode = sdr["SDCode"].ToString();
                this.TestName = sdr["TestName"].ToString();
                this.MTCode = sdr["MTCode"].ToString();
                if (!(sdr["Flag"] is DBNull))
                    this.Flag = sdr["Flag"].ToString();
                this.Patregdate = Convert.ToDateTime(sdr["Patregdate"]);
                if (!(sdr["Testordno"] is DBNull))
                    this.Testordno = Convert.ToInt32(sdr["Testordno"]);
                else
                    this.Testordno = 0;
            }
            else
            {
                throw new PackageHMS_Bal_CException("No Record Fetched.");
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
            catch (PackageHMS_Bal_CException)
            {
                throw new PackageHMS_Bal_CException("Record not found");
            }
        }
    }

    #endregion

    public bool Insert(int branchid)
    {
        SqlConnection conn = DataAccess.ConInitForDC(); 
        SqlCommand sc = new SqlCommand("" +
        "INSERT INTO PackmstD " +
        "(PackageCode, PackageName,Qty,dateofentry,ServiceId,ServiceName,TestRate,Testordno,branchid,Createdby) " +
        "VALUES (@PackageCode, @PackageName, @Qty, @dateofentry,@ServiceId,@ServiceName,@TestRate,@Testordno,@branchid,@username)", conn);

        sc.Parameters.Add(new SqlParameter("@PackageCode", SqlDbType.NVarChar, 50)).Value = this.PackageCode;
        sc.Parameters.Add(new SqlParameter("@PackageName", SqlDbType.NVarChar, 255)).Value = this.PackageName;
        sc.Parameters.Add(new SqlParameter("@Qty", SqlDbType.Decimal,2)).Value = this.Qty;
        sc.Parameters.Add(new SqlParameter("@dateofentry", SqlDbType.DateTime)).Value = this.Patregdate;
        
        sc.Parameters.Add(new SqlParameter("@ServiceId", SqlDbType.VarChar, 500)).Value = this.MTCode;
        sc.Parameters.Add(new SqlParameter("@ServiceName", SqlDbType.VarChar, 500)).Value = this.TestName;
        sc.Parameters.Add(new SqlParameter("@TestRate", SqlDbType.Float)).Value = this.TestRate;
        sc.Parameters.Add(new SqlParameter("@Testordno", SqlDbType.Int,9)).Value = this.Testordno;
        sc.Parameters.Add(new SqlParameter("@branchid", SqlDbType.Int)).Value = branchid;
        sc.Parameters.Add(new SqlParameter("@username", SqlDbType.NVarChar, 50)).Value = P_username;
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
    }//End Insert

    public bool Delete(int branchid)
    {
        SqlConnection conn = DataAccess.ConInitForDC(); 
        SqlCommand sc = new SqlCommand("" +
            " Delete from PackmstD" +
            " Where PackageCode=@PackageCode and MTCode=@MTCode  where branchid=" + branchid + "", conn);
        sc.Parameters.Add(new SqlParameter("@PackageCode", SqlDbType.NVarChar, 50)).Value = this.PackageCode;
        sc.Parameters.Add(new SqlParameter("@MTCode", SqlDbType.VarChar, 500)).Value = this.MTCode;
        SqlDataReader sdr = null;
        try
        {
            conn.Open();
            sc.ExecuteNonQuery();
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
    }
    public bool DeleteByPack_Code(string PackageCode, int branchid)
    {
        SqlConnection conn = DataAccess.ConInitForDC(); 
        SqlCommand sc = new SqlCommand("" +
            " Delete from PackmstD" +
            " Where PackageCode=@PackageCode  and branchid=" + branchid + "", conn);
        sc.Parameters.Add(new SqlParameter("@PackageCode", SqlDbType.NVarChar, 50)).Value = PackageCode;
       
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
    }


    public DataTable getAllTestCodesPAck(string PackageCode, int branchid)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        DataTable dt = new DataTable();
        try
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(" select MTCode from PackmstD where PackageCode='" + PackageCode + "' and branchid=" + branchid + "", con);
            da.Fill(dt);
        }
        catch (Exception ex) { throw; }
        finally { con.Close(); con.Dispose(); }
        return dt;
    }

    public DataTable getAllTestCodes(string PackageCode,int branchid)
    {
        SqlConnection con = DataAccess.ConInitForDC(); 
        DataTable dt = new DataTable();
        try
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(" select MTCode from PackmstD where MTCode='" + PackageCode + "' and branchid=" + branchid + "", con);
            da.Fill(dt);
        }
        catch (Exception ex) { throw; }
        finally { con.Close(); con.Dispose(); }
        return dt;
    }

    public DataTable getAllTestCodes_ForPAckage(string PackageCode, int branchid)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        DataTable dt = new DataTable();
        try
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(" select MTCode from PackmstD where PackageCode='" + PackageCode + "' and branchid=" + branchid + "", con);
            da.Fill(dt);
        }
        catch (Exception ex) { throw; }
        finally { con.Close(); con.Dispose(); }
        return dt;
    }


}
