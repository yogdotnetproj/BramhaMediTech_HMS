using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;
using System.Text;


public class Patmstd_Bal_C
{

    public Patmstd_Bal_C()
    {

        this.PatRegID = "";
        this.FID = "";
        this.Barcodeid = "";
        this.MTCode = "";
        this.SDCode = "";
        this.PackageCode = "";
        this.TestRate = 0;
        this.Patregdate = Date.getOnlydate();
        this.PID = 0;
      
        this.FID = "";
        this.Patname = "";  
        this.Initial = "";
        this.Address1 = "";
        this.City = "";
       
        this.Patregdate = Date.getdate();
       

        this.ReportDate = Date.getdate();
        this.ReportTime = "";
        this.Emergencyflag = false;
        this.DoctorCode = "";
        this.Drname = "";
        this.Age = 0;
        this.Sex = "";
        this.MYD = "";
        this.Phone = "";
        this.CenterCode = "";
        this.CenterName = "";
       
       
      
    
        this.flag = false;
        this.PF = false;
       
    
        this.FinancialYearID = "";
       
        this.TestCharges = 0;
        this.SampleID = "";
        this.Username = "";
        this.Usertype = "";
        this.Tests = "";

        this.FullName = "";
        this.SampleStatus = "";
        this.SampleNotes = "";
        
        this.Barcodeid = "";
        this.PatientcHistory = "";
        this.PID = 0;
        
        this.remark = "";
        this.VCodeTes = "";
    }

   
    public bool Delete(int branchid)
    {
            
        SqlConnection conn = DataAccess.ConInitForPathology();
        SqlCommand sc = new SqlCommand("delete from patmstd  " +
            "where PatRegID = @PatRegID  AND FID = @FID and branchid=" + branchid + "", conn);

        // Add the employee ID parameter and set its value.

        sc.Parameters.Add(new SqlParameter("@PatRegID", SqlDbType.NVarChar, 250)).Value = this.PatRegID;
        sc.Parameters.Add(new SqlParameter("@FID", SqlDbType.NVarChar, 50)).Value = this.FID;

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

    public bool Insert(int branchid)
    {        
        SqlConnection conn = DataAccess.ConInitForPathology(); 
        SqlCommand sc = new SqlCommand("" +
        "insert into patmstd(PatRegID,FID,BarcodeID,MTCode,SDCode,PackageCode,Patregdate,TestRate,PID,UnitCode,branchid,dramt,DigModule,cons,SampleAcceptDate,SampleType)" +
        " values(@PatRegID,@FID,@BarcodeID,@MTCode,@SDCode,@PackageCode,@Patregdate,@TestRate,@PID,@UnitCode,@branchid,@dramt,@DigModule,@cons,@Patregdate,@SampleType)", conn);
        
        sc.Parameters.Add(new SqlParameter("@PatRegID", SqlDbType.NVarChar, 250)).Value = this.PatRegID;
        sc.Parameters.Add(new SqlParameter("@FID", SqlDbType.NVarChar, 50)).Value = this.FID;
        sc.Parameters.Add(new SqlParameter("@BarcodeID", SqlDbType.NVarChar, 50)).Value = this.Barcodeid;
        sc.Parameters.Add(new SqlParameter("@MTCode", SqlDbType.NVarChar, 50)).Value = this.MTCode;
        sc.Parameters.Add(new SqlParameter("@SDCode", SqlDbType.NVarChar, 50)).Value = this.SDCode;
        sc.Parameters.Add(new SqlParameter("@PackageCode", SqlDbType.NVarChar, 50)).Value = this.PackageCode;
        sc.Parameters.Add(new SqlParameter("@Patregdate", SqlDbType.DateTime)).Value = this.Patregdate;
        sc.Parameters.Add(new SqlParameter("@TestRate", SqlDbType.Float)).Value = this.TestRate;
        sc.Parameters.Add(new SqlParameter("@PID", SqlDbType.Int, 4)).Value = this.PID;
        sc.Parameters.Add(new SqlParameter("@UnitCode", SqlDbType.NVarChar, 50)).Value = this.UnitCode;

       
        sc.Parameters.Add(new SqlParameter("@branchid", SqlDbType.Int)).Value = branchid;
        sc.Parameters.Add(new SqlParameter("@dramt", SqlDbType.Float)).Value = this.dramt;
        sc.Parameters.Add(new SqlParameter("@DigModule", SqlDbType.Int)).Value = this.P_DigModule;
        sc.Parameters.Add(new SqlParameter("@cons", SqlDbType.Int)).Value = this.P_perdis;
        sc.Parameters.Add(new SqlParameter("@SampleType", SqlDbType.NVarChar, 250)).Value = this.SampleType;
       
        conn.Close();
        try
        {
            conn.Open();
            sc.ExecuteNonQuery();

        }
        catch (Exception exx)
        { }

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


    public bool Delete(string BarcodeID, int branchid)
    {

        SqlConnection conn = DataAccess.ConInitForPathology();
        SqlCommand sc = new SqlCommand("delete from patmstd " +
            "where BarcodeID=@BarcodeID and branchid=" + branchid + "", conn);        
        sc.Parameters.Add(new SqlParameter("@BarcodeID", SqlDbType.NVarChar, 50)).Value = BarcodeID;

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
                // Log an event in the Application Event Log.
                throw;
            }
        }
       
        return true;
    }

    public bool Delete(int PID, int branchid)
    {               
        SqlConnection conn = DataAccess.ConInitForPathology();
        SqlCommand sc = new SqlCommand("delete from patmstd " + "where PID=@PID and branchid=" + branchid + "", conn);
        sc.Parameters.Add(new SqlParameter("@PID", SqlDbType.Int)).Value = PID;

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
                // Log an event in the Application Event Log.
                throw;
            }
        }
       
        return true;
    }
   
 
    public bool Update(int PID, string MTCode, int branchid, int k)
    {
        this.PID = PID;
        string[] tlc = MTCode.Split(',');
        for (int i = 0; i < tlc.Length; i++)
        {
            SqlConnection conn = DataAccess.ConInitForPathology();
            SqlCommand sc = new SqlCommand("" +
           "Update patmstd set BarcodeID=@BarcodeID,UnitCode=@UnitCode,TestRate=@TestRate,dramt=@dramt,SampleType=@SampleType where PID=@PID and MTCode=@MTCode and branchid=" + branchid + "", conn);

            sc.Parameters.Add(new SqlParameter("@PID", SqlDbType.Int, 4)).Value = this.PID;
            sc.Parameters.Add(new SqlParameter("@BarcodeID", SqlDbType.NVarChar, 500)).Value = this.Barcodeid;
            sc.Parameters.Add(new SqlParameter("@MTCode", SqlDbType.NVarChar, 50)).Value = tlc[i];
            sc.Parameters.Add(new SqlParameter("@UnitCode", SqlDbType.NVarChar, 50)).Value = this.UnitCode;
           
            sc.Parameters.Add(new SqlParameter("@TestRate", SqlDbType.Float)).Value = this.TestRate;
            sc.Parameters.Add(new SqlParameter("@dramt", SqlDbType.Float)).Value = this.dramt;
            sc.Parameters.Add(new SqlParameter("@SampleType", SqlDbType.NVarChar, 250)).Value = this.SampleType;
            
            conn.Close();

            try
            {
                conn.Open();
                try
                {
                    sc.ExecuteNonQuery();
                }
                catch { throw; }
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
        return true;
    }

    internal class Patmstd_Bal_CTableException : Exception
    {
        public Patmstd_Bal_CTableException(string msg) : base(msg) { }
    }
    public float Get_ShareMst_amount(string DoctorCode, string STCODE, string branchid)
    {
        SqlConnection conn = DataAccess.ConInitForPathology();
        SqlCommand cmd = new SqlCommand("select Amount,Percentage from sharemst where ratecode = (select top(1) ratetypeid from DrMT where DoctorCode='" + DoctorCode.Trim() + "' and  ratetypeid >0) and STCODE = '" + STCODE + "' and branchid=" + branchid + "", conn);

        SqlDataReader sdr;
        float amount = 0.0f;
        try
        {
            conn.Open();
            sdr = cmd.ExecuteReader();
            sdr.Read();
            if (sdr.HasRows)
            {
                if (sdr["Amount"] != DBNull.Value)
                {
                    if (Convert.ToSingle(sdr["Amount"].ToString()) > 0)
                    {
                        amount = Convert.ToSingle(sdr["Amount"].ToString());
                    }
                    else
                    {
                        if (sdr["Percentage"] != DBNull.Value)
                        {
                            if (Convert.ToSingle(sdr["Percentage"].ToString()) > 0)
                            {
                                P_perdis = Convert.ToSingle(sdr["Percentage"].ToString());
                            }
                            else
                            {
                                P_perdis = 0;
                            }
                        }
                    }
                }
            }
        }
        catch
        {
            throw;
        }
        finally
        {
            conn.Close();
            conn.Dispose();
        }
        return amount;
    }

    

    #region properties

    private int ReportAssignStatus;
    public int P_ReportAssignStatus
    {
        get { return ReportAssignStatus; }
        set { ReportAssignStatus = value; }
    }

    private string PatientCardNo;
    public string P_PatientCardNo
    {
        get { return PatientCardNo; }
        set { PatientCardNo = value; }
    }
    private string PatientCardExpNo;
    public string P_PatientCardExpNo
    {
        get { return PatientCardExpNo; }
        set { PatientCardExpNo = value; }
    }

    private string _PatRegID;
    public string PatRegID
    {
        get { return _PatRegID; }
        set { _PatRegID = value; }
    }

    private string _FID;
    public string FID
    {
        get { return _FID; }
        set { _FID = value; }
    }

    private string _MTCode;
    public string MTCode
    {
        get { return _MTCode; }
        set { _MTCode = value; }
    }

    private string _SDCode;
    public string SDCode
    {
        get { return _SDCode; }
        set { _SDCode = value; }
    }

    private string _PackageCode;
    public string PackageCode
    {
        get { return _PackageCode; }
        set { _PackageCode = value; }
    }
    private DateTime _DateOfEntry;
    public DateTime Patregdate
    {
        get { return _DateOfEntry; }
        set { _DateOfEntry = value; }
    }

    private float _TestRate;
    public float TestRate
    {
        get { return _TestRate; }
        set { _TestRate = value; }
    }
    private string _BarcodeID;
    public string Barcodeid
    {
        get { return _BarcodeID; }
        set { _BarcodeID = value; }
    }
    private int _PID;
    public int PID
    {
        get { return _PID; }
        set { _PID = value; }
    }
    private string _UnitCode;
    public string UnitCode
    {
        get { return _UnitCode; }
        set { _UnitCode = value; }
    }
   
    private float dramt;
    public float P_doctoramount
    {
        get { return dramt; }
        set { dramt = value; }
    }
    private int DigModule;
    public int P_DigModule
    {
        get { return DigModule; }
        set { DigModule = value; }
    }
    private float perdis;
    public float P_perdis
    {
        get { return perdis; }
        set { perdis = value; }
    }
   


    private string _CodeTes;
    public string CodeTes
    {
        get { return _CodeTes; }
        set { _CodeTes = value; }
    }
    private string _VCodeTes;
    public string VCodeTes
    {
        get { return _VCodeTes; }
        set { _VCodeTes = value; }
    }    

    private string _Vsampletype;

    public string Vsampletype
    {
        get { return _Vsampletype; }
        set { _Vsampletype = value; }
    }

    private string _Vtestcodes;

    public string Vtestcodes
    {
        get { return _Vtestcodes; }
        set { _Vtestcodes = value; }
    }

    private string _Vtestnames;

    public string Vtestnames
    {
        get { return _Vtestnames; }
        set { _Vtestnames = value; }
    }
    private string _Vsamplestatus;

    public string Vsamplestatus
    {
        get { return _Vsamplestatus; }
        set { _Vsamplestatus = value; }
    }

    private int _Count;
    public int Count
    {
        get { return _Count; }
        set { _Count = value; }
    }

    private string _MTCodeNew;
    public string MTCodeNew
    {
        get { return _MTCodeNew; }
        set { _MTCodeNew = value; }
    }

    private string _BarcodeIDForBar;
    public string BarcodeIDForBar
    {
        get { return _BarcodeIDForBar; }
        set { _BarcodeIDForBar = value; }
    }

    private int _PIDNew;
    public int PIDNew
    {
        get { return _PIDNew; }
        set { _PIDNew = value; }
    }

    private string _ContBarcodeid;
    public string ContBarcodeid
    {
        get { return _ContBarcodeid; }
        set { _ContBarcodeid = value; }
    }


    private string Weights;
    public string P_Weights
    {
        get { return Weights; }
        set { Weights = value; }
    }
    private string Heights;
    public string P_Heights
    {
        get { return Heights; }
        set { Heights = value; }
    }
    private string Disease;
    public string P_Disease
    {
        get { return Disease; }
        set { Disease = value; }
    }

    private string LastPeriod;
    public string P_LastPeriod
    {
        get { return LastPeriod; }
        set { LastPeriod = value; }
    }
    private string Symptoms;
    public string P_Symptoms
    {
        get { return Symptoms; }
        set { Symptoms = value; }
    }
    private string FSTime;
    public string P_FSTime
    {
        get { return FSTime; }
        set { FSTime = value; }
    }
    private string Therapy;
    public string P_Therapy
    {
        get { return Therapy; }
        set { Therapy = value; }
    }
    private int SocialMedia;
    public int P_SocialMedia
    {
        get { return SocialMedia; }
        set { SocialMedia = value; }
    }

    #endregion

    #region properties

    private int _SrNo;
    public int SrNo
    {
        get { return _SrNo; }
        set { _SrNo = value; }
    }

    private string usertype;
    public string Usertype
    {
        get { return usertype; }
        set { usertype = value; }
    }

    private string username;
    public string Username
    {
        get { return username; }
        set { username = value; }
    }

    private string _Tests;
    public string Tests
    {
        get { return _Tests; }
        set { _Tests = value; }
    }


    private string _Fname;
    public string Patname
    {
        get { return _Fname; }
        set { _Fname = value; }
    }

   

   
    private string _RegCode;

    public string RegCode
    {
        get { return _RegCode; }
        set { _RegCode = value; }
    }
  
    private string _Initial;
    public string Initial
    {
        get { return _Initial; }
        set { _Initial = value; }
    }

    private string _Add1, _City;

    public string Address1
    {
        get { return _Add1; }
        set { _Add1 = value; }
    }

    public string City
    {
        get { return _City; }
        set { _City = value; }
    }
    private string _Email;
    public string Email
    {
        get { return _Email; }
        set { _Email = value; }
    }    
    
    private string _Phone;
    public string Phone
    {
        get { return _Phone; }
        set { _Phone = value; }
    }
    private string _RefDr, _compname;
    public string RefDr
    {
        get { return _RefDr; }
        set { _RefDr = value; }
    }

    private DateTime _DateOfBirth;
    public DateTime DateOfBirth
    {
        get { return _DateOfBirth; }
        set { _DateOfBirth = value; }
    }

    private int _AccDateofBirth;
     public int AccDateofBirth
    {
        get { return _AccDateofBirth; }
        set { _AccDateofBirth = value; }
    }

    
    private DateTime _CollDate;
    public DateTime CollDate
    {
        get { return _CollDate; }
        set { _CollDate = value; }
    }

    private DateTime _CollTime;
    public DateTime CollTime
    {
        get { return _CollTime; }
        set { _CollTime = value; }
    }

    private DateTime _ReportDate;
    public DateTime ReportDate
    {
        get { return _ReportDate; }
        set { _ReportDate = value; }
    }

    private string _ReportTime;
    public string ReportTime
    {
        get { return _ReportTime; }
        set { _ReportTime = value; }
    }

    private bool _Emergencyflag;
    public bool Emergencyflag
    {
        get { return _Emergencyflag; }
        set { _Emergencyflag = value; }
    }

    private int _Age;
    public int Age
    {
        get { return _Age; }
        set { _Age = value; }
    }

    private string _Sex;
    public string Sex
    {
        get { return _Sex; }
        set { _Sex = value; }
    }

    private string _MYD;
    public string MYD
    {
        get { return _MYD; }
        set { _MYD = value; }
    }

    private string _DoctorCode;
    public string DoctorCode
    {
        get { return _DoctorCode; }
        set { _DoctorCode = value; }
    }
    private string  _DoctorName;
    public string Drname
    {
        get { return _DoctorName; }
        set { _DoctorName = value; }
    }
    private string _OtherRefDoctor;
    public string OtherRefDoctor
    {
        get { return _OtherRefDoctor; }
        set { _OtherRefDoctor = value; }
    }
    private string _CenterCode;
    public string CenterCode
    {
        get { return _CenterCode; }
        set { _CenterCode = value; }
    }
    private string _CenterName;
    public string CenterName
    {
        get { return _CenterName; }
        set { _CenterName = value; }
    }

  
    private bool _PF;
    public bool PF
    {
        get { return _PF; }
        set { _PF = value; }
    }


    

 
   

    private string _FinancialYearID;
    public string FinancialYearID
    {
        get { return _FinancialYearID; }
        set { _FinancialYearID = value; }
    }

  

    private Double _TestCharges;
    public Double TestCharges
    {
        get { return _TestCharges; }
        set { _TestCharges = value; }
    }

    private string _SampleID;
    public string SampleID
    {
        get { return _SampleID; }
        set { _SampleID = value; }
    }
    
  

    private bool _flag;
    public bool flag
    {
        get { return _flag; }
        set { _flag = value; }
    }

   

 
    private string sampleType;
    public string SampleType
    {
        get { return sampleType; }
        set { sampleType = value; }
    }

    private string sampleNotes;
    public string SampleNotes
    {
        get { return sampleNotes; }
        set { sampleNotes = value; }
    }
   
    private string fullName;
    public string FullName
    {
        get { return fullName; }
        set { fullName = value; }
    }

    private string sampleStatus;
    public string SampleStatus
    {
        get { return sampleStatus; }
        set { sampleStatus = value; }
    }

   
    private string _clinical_History;
    public string PatientcHistory
    {
        get { return _clinical_History; }
        set { _clinical_History = value; }
    }

  
    

    private DateTime _RegistratonDateTime;
    public DateTime RegistratonDateTime
    {
        get { return _RegistratonDateTime; }
        set { _RegistratonDateTime = value; }
    }

    private string _TelNo;
    public string TelNo
    {
        get { return _TelNo; }
        set { _TelNo = value; }
    }
    private string Patusername;
    public string P_PUserName
    {
        get { return Patusername; }
        set { Patusername = value; }
    }

    private string Patpassword;
    public string P_PPassword
    {
        get { return Patpassword; }
        set { Patpassword = value; }
    }
    private string complimentcharges;
    public string P_complimentcharges
    {
        get { return complimentcharges; }
        set { complimentcharges = value; }
    }
   
    private string remark;
    public string P_remark
    {
        get { return remark; }
        set { remark = value; }
    }

    public string testname1;
    public string TestName
    {

        get { return testname1; }
        set { testname1 = value; }


    }

  
    private int permentPateint1;
    public int P_permentPateint1
    {
        get { return permentPateint1; }
        set { permentPateint1 = value; }


    }
    private bool _BHFlag;
    public bool BHFlag
    {
        get { return _BHFlag; }
        set { _BHFlag = value; }
    }
    private bool _Monthlybill;
    public bool Monthlybill
    {
        get { return _Monthlybill; }
        set { _Monthlybill = value; }
    }

    private bool _IsEmergency;
    public bool IsEmergency
    {
        get { return _IsEmergency; }
        set { _IsEmergency = value; }
    }
    #endregion

    public static Boolean Get_ExistTestCode(int PID, string MTCode, int branchid)
    {
       
        string q = "";
        if (MTCode.Length != 4)
        {
            q = "select * from patmstd where PID=" + PID + " and branchid=" + branchid + " and MTCode='" + MTCode + "'";
        }
        else
        {
            q = "select * from patmstd where PID=" + PID + " and branchid=" + branchid + " and PackageCode='" + MTCode + "'";
        }

        SqlConnection con = new SqlConnection(ConnectionString.ConnectionstringPatho);
        SqlCommand sc = new SqlCommand();
        sc.Connection = con;

        sc.CommandText = q;

        SqlDataReader sdr = null;
        con.Open();
        try
        {
            sdr = sc.ExecuteReader();
            if (sdr.Read())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (SqlException)
        {
            throw;
        }
        finally
        {
            sdr.Close();
            con.Close(); con.Dispose();
        }
    }


    public int Insert_Update_ForPmst(int branchid)
    {
        int PID = 0;        
        SqlConnection con = DataAccess.ConInitForPathology();
        DateTime dateofentrynew = this.Patregdate;
        SqlCommand cmd = new SqlCommand("SP_phpatrecfrm", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@count", SqlDbType.Int, 4)).Value = this.Count;
       
        cmd.Parameters.Add(new SqlParameter("@Patregdate", SqlDbType.DateTime)).Value = this.Patregdate;
        cmd.Parameters.Add(new SqlParameter("@intial", SqlDbType.NVarChar, 10)).Value = this.Initial;
        cmd.Parameters.Add(new SqlParameter("@Patname", SqlDbType.NVarChar, 350)).Value = this.Patname;
        
        cmd.Parameters.Add(new SqlParameter("@Sex", SqlDbType.NVarChar, 6)).Value = this.Sex;
        cmd.Parameters.Add(new SqlParameter("@Age", SqlDbType.Int, 4)).Value = this.Age;
        cmd.Parameters.Add(new SqlParameter("@Mob_no", SqlDbType.NVarChar, 50)).Value = this.Phone;
        if (this.Email != null)
            cmd.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar, 50)).Value = this.Email;
        else
            cmd.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar, 50)).Value = "";
        cmd.Parameters.Add(new SqlParameter("@MDY", SqlDbType.NVarChar, 5)).Value = this.MYD;
        cmd.Parameters.Add(new SqlParameter("@RefDr", SqlDbType.NVarChar, 50)).Value = this.DoctorCode;
        if (this.Address1 != null)
            cmd.Parameters.Add(new SqlParameter("@Pataddress", SqlDbType.NVarChar, 250)).Value = this.Address1;
        else
            cmd.Parameters.Add(new SqlParameter("@Pataddress", SqlDbType.NVarChar, 250)).Value = "";
        if (this.remark != null)
            cmd.Parameters.Add(new SqlParameter("@Remark", SqlDbType.NVarChar, 50)).Value = this.remark;
        else
            cmd.Parameters.Add(new SqlParameter("@Remark", SqlDbType.NVarChar, 50)).Value = "";
   
        if (this.PatientcHistory != null)
            cmd.Parameters.Add(new SqlParameter("@PatientcHistory", SqlDbType.NText)).Value = this.PatientcHistory;
        else
            cmd.Parameters.Add(new SqlParameter("@PatientcHistory", SqlDbType.NText)).Value = "";
        cmd.Parameters.Add(new SqlParameter("@branchid", SqlDbType.Int)).Value = branchid;
        if (this.username != null)
            cmd.Parameters.Add(new SqlParameter("@Username", SqlDbType.NVarChar, 50)).Value = this.Username;
        else
            cmd.Parameters.Add(new SqlParameter("@Username", SqlDbType.NVarChar, 50)).Value = "";

        if (this.Usertype != null)
            cmd.Parameters.Add(new SqlParameter("@Usertype", SqlDbType.NVarChar, 250)).Value = this.Usertype;
        else
            cmd.Parameters.Add(new SqlParameter("@Usertype", SqlDbType.NVarChar, 250)).Value = "";
        if (this.Tests != null)
            cmd.Parameters.Add(new SqlParameter("@Tests", SqlDbType.NText)).Value = this.Tests;
        else
            cmd.Parameters.Add(new SqlParameter("@Tests", SqlDbType.NText)).Value = "";
        cmd.Parameters.Add(new SqlParameter("@PatRegID", SqlDbType.NVarChar, 50)).Value = this.PatRegID;
        cmd.Parameters.Add(new SqlParameter("@FID", SqlDbType.NVarChar, 50)).Value = this.FID;

        cmd.Parameters.Add(new SqlParameter("@CenterName", SqlDbType.NVarChar, 250)).Value = this.CenterName;
        
        cmd.Parameters.Add(new SqlParameter("@PF", SqlDbType.Bit)).Value = this.PF;
        cmd.Parameters.Add(new SqlParameter("@Reportdate", SqlDbType.DateTime)).Value = this.ReportDate;
        if (this.CollDate == Date.getMinDate())
            cmd.Parameters.Add(new SqlParameter("@Phrecdate", SqlDbType.DateTime)).Value = DBNull.Value;
        else
            cmd.Parameters.Add(new SqlParameter("@Phrecdate", SqlDbType.DateTime)).Value = this.CollDate;
        

       
        cmd.Parameters.Add(new SqlParameter("@Patphoneno", SqlDbType.NVarChar, 255)).Value = this.Phone;
       
        cmd.Parameters.Add(new SqlParameter("@emergencyflag", SqlDbType.Bit)).Value = this.Emergencyflag;
       
        cmd.Parameters.Add(new SqlParameter("@DoctorCode", SqlDbType.NVarChar, 50)).Value = this.DoctorCode;
        cmd.Parameters.Add(new SqlParameter("@Drname", SqlDbType.NVarChar, 50)).Value = this.Drname;
        
        cmd.Parameters.Add(new SqlParameter("@CenterCode", SqlDbType.NVarChar, 250)).Value = this.CenterCode;
       
        cmd.Parameters.Add(new SqlParameter("@FinancialYearID", SqlDbType.NVarChar, 50)).Value = this.FinancialYearID;
       
        cmd.Parameters.Add(new SqlParameter("@TestCharges", SqlDbType.Float)).Value = this.TestCharges;
        cmd.Parameters.Add(new SqlParameter("@SampleID", SqlDbType.NVarChar, 50)).Value = this.SampleID;
        
        if (this.SampleType == null)
            cmd.Parameters.Add(new SqlParameter("@SampleType", SqlDbType.NVarChar, 50)).Value = DBNull.Value;
        else
            cmd.Parameters.Add(new SqlParameter("@SampleType", SqlDbType.NVarChar, 50)).Value = this.SampleType;
        
        cmd.Parameters.Add(new SqlParameter("@BarcodeID", SqlDbType.NVarChar, 50)).Value = this.Barcodeid;
      
        cmd.Parameters.Add(new SqlParameter("@TelNo", SqlDbType.NVarChar, 50)).Value = this.TelNo;
        cmd.Parameters.Add(new SqlParameter("@RegistratonDateTime", SqlDbType.DateTime)).Value = this.Patregdate;
        if (this.P_PUserName != null)
            cmd.Parameters.Add(new SqlParameter("@Patusername", SqlDbType.NVarChar, 250)).Value = this.P_PUserName;
        else
            cmd.Parameters.Add(new SqlParameter("@Patusername", SqlDbType.NVarChar, 250)).Value = "";
        if (this.P_PPassword != null)
            cmd.Parameters.Add(new SqlParameter("@Patpassword", SqlDbType.NVarChar, 250)).Value = this.P_PPassword;
        else
            cmd.Parameters.Add(new SqlParameter("@Patpassword", SqlDbType.NVarChar, 250)).Value = "";
        cmd.Parameters.Add(new SqlParameter("@TestName", SqlDbType.NVarChar, 4000)).Value = this.TestName;
        cmd.Parameters.Add(new SqlParameter("@UnitCode", SqlDbType.NVarChar, 50)).Value = this.UnitCode;
                
        cmd.Parameters.Add(new SqlParameter("@MTCode", SqlDbType.NVarChar, 50)).Value = this.MTCode;
        cmd.Parameters.Add(new SqlParameter("@SDCode", SqlDbType.NVarChar, 50)).Value = this.SDCode;
        cmd.Parameters.Add(new SqlParameter("@PackageCode", SqlDbType.NVarChar, 50)).Value = this.PackageCode;
        cmd.Parameters.Add(new SqlParameter("@TestRate", SqlDbType.Float)).Value = this.TestRate;
       
        cmd.Parameters.Add(new SqlParameter("@dramt", SqlDbType.Float)).Value = this.dramt;
        cmd.Parameters.Add(new SqlParameter("@DigModule", SqlDbType.Int)).Value = this.P_DigModule;
        cmd.Parameters.Add(new SqlParameter("@cons", SqlDbType.Int)).Value = this.P_perdis;
        cmd.Parameters.Add(new SqlParameter("@CodeTes", SqlDbType.NVarChar, 50)).Value = this.CodeTes;
        cmd.Parameters.Add(new SqlParameter("@VSampleType", SqlDbType.NVarChar, 200)).Value = (string)(this.Vsampletype);
        cmd.Parameters.Add(new SqlParameter("@VTestCodes", SqlDbType.NVarChar, 1000)).Value = (string)(this.Vtestcodes);
        cmd.Parameters.Add(new SqlParameter("@VTestNames", SqlDbType.NVarChar, 2000)).Value = (string)(this.Vtestnames);
        cmd.Parameters.Add(new SqlParameter("@VCodeTes", SqlDbType.NVarChar, 50)).Value = this.VCodeTes;

        cmd.Parameters.Add(new SqlParameter("@BarcodeIDForBar", SqlDbType.NVarChar, 50)).Value = this.BarcodeIDForBar;
        cmd.Parameters.Add(new SqlParameter("@TempMTCode", SqlDbType.NVarChar, 50)).Value = this.MTCodeNew;

        cmd.Parameters.Add(new SqlParameter("@PIDNew", SqlDbType.Int, 4)).Value = this.PIDNew;
        cmd.Parameters.Add(new SqlParameter("@ContBarcodeid", SqlDbType.NVarChar, 500)).Value = this.ContBarcodeid;
        cmd.Parameters.Add(new SqlParameter("@IsbillBH", SqlDbType.Bit)).Value = this.BHFlag;
        cmd.Parameters.Add(new SqlParameter("@Monthlybill", SqlDbType.Bit)).Value = this.Monthlybill;
        cmd.Parameters.Add(new SqlParameter("@OtherRefDoctor", SqlDbType.NVarChar, 500)).Value = this.OtherRefDoctor;

        cmd.Parameters.Add(new SqlParameter("@Weights", SqlDbType.NVarChar, 500)).Value = P_Weights;
        cmd.Parameters.Add(new SqlParameter("@Heights", SqlDbType.NVarChar, 500)).Value = P_Heights;
        cmd.Parameters.Add(new SqlParameter("@Disease", SqlDbType.NVarChar, 500)).Value = P_Disease;
        cmd.Parameters.Add(new SqlParameter("@LastPeriod", SqlDbType.NVarChar, 500)).Value = P_LastPeriod;
        cmd.Parameters.Add(new SqlParameter("@Symptoms", SqlDbType.NVarChar, 500)).Value = P_Symptoms;
        cmd.Parameters.Add(new SqlParameter("@FSTime", SqlDbType.NVarChar, 500)).Value = P_FSTime;
        cmd.Parameters.Add(new SqlParameter("@Therapy", SqlDbType.NVarChar, 500)).Value = P_Therapy;
        cmd.Parameters.Add(new SqlParameter("@SocialMedia", SqlDbType.Int, 4)).Value = P_SocialMedia;
        cmd.Parameters.Add(new SqlParameter("@AccDateofBirth", SqlDbType.Int, 4)).Value = this.AccDateofBirth;
        cmd.Parameters.Add(new SqlParameter("@DateOfBirth", SqlDbType.DateTime)).Value = this.DateOfBirth;
        cmd.Parameters.Add(new SqlParameter("@ReportAssignStatus", SqlDbType.Int, 4)).Value = P_ReportAssignStatus;
        cmd.Parameters.Add(new SqlParameter("@PatientCardNo", SqlDbType.NVarChar, 500)).Value = P_PatientCardNo;
        cmd.Parameters.Add(new SqlParameter("@PatientCardExpNo", SqlDbType.NVarChar, 500)).Value = P_PatientCardExpNo;

        try
        {
            con.Open();          
            object objectCid;
            cmd.CommandTimeout = 1200;

            objectCid = cmd.ExecuteScalar();

            if (objectCid != null)
            {
                PID = Convert.ToInt32(objectCid);
            }
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
        return PID;
    }

    public string GetSMSString_CountryCode(string SubjString, int branchid)
    {
        SqlConnection conn = DataAccess.ConInitForPathology();
        string s = "";
        try
        {

            conn.Open();
            SqlCommand cmd = new SqlCommand("SP_GetCountryCode", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@branchid", branchid);
            cmd.Parameters.AddWithValue("@SubjString", SubjString);

            s = Convert.ToString(cmd.ExecuteScalar());

        }
        catch (Exception ex)
        {
        }
        finally
        {
            conn.Close();
            conn.Dispose();

        }
        return s;
    }

    public string GetSMSString(string SubjString, int branchid)
    {
        SqlConnection conn = DataAccess.ConInitForPathology();
        string s = "";
        try
        {

            conn.Open();
            SqlCommand cmd = new SqlCommand("SP_phsmqrymst", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@branchid", branchid);
            cmd.Parameters.AddWithValue("@SubjString", SubjString);

            s = Convert.ToString(cmd.ExecuteScalar());

        }
        catch (Exception ex)
        {
        }
        finally
        {
            conn.Close();
            conn.Dispose();

        }
        return s;
    }

    public string GetRegno(int PID, short branchid)
    {
        SqlConnection conn = DataAccess.ConInitForPathology();
        string s = "";
        try
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select PatRegID from patmst where PID=@PID and branchid=@branchid ", conn);
            //cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PID", PID);
            cmd.Parameters.AddWithValue("@branchid", branchid);

            s = Convert.ToString(cmd.ExecuteScalar());

        }
        catch (Exception ex)
        {
        }
        finally
        {
            conn.Close();
            conn.Dispose();

        }
        return s;
    }

    public string GetSMSActiveFlag(string SubjString, int branchid)
    {
        SqlConnection conn = DataAccess.ConInitForPathology();
        string s = "";
        try
        {

            conn.Open();
            SqlCommand cmd = new SqlCommand("SP_phsmrecmst_Flag", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@branchid", branchid);
            cmd.Parameters.AddWithValue("@SubjString", SubjString);

            s = Convert.ToString(cmd.ExecuteScalar());

        }
        catch (Exception ex)
        {
        }
        finally
        {
            conn.Close();
            conn.Dispose();

        }
        return s;
    }

    public bool Delete_Default(int PID, int branchid, string MTCode)
    {
        SqlConnection conn = DataAccess.ConInitForPathology();
        SqlCommand sc = new SqlCommand("delete from patmstd " + "where PID=@PID and branchid=" + branchid + " and MTCode='" + MTCode + "'  ", conn);
        sc.Parameters.Add(new SqlParameter("@PID", SqlDbType.Int)).Value = PID;

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
                // Log an event in the Application Event Log.
                throw;
            }
        }

        return true;
    }

    public bool Insert_Update_ForPmstDefault(int branchid)
    {
        
        SqlConnection con = DataAccess.ConInitForPathology();
        DateTime dateofentrynew = this.Patregdate;
        SqlCommand cmd = new SqlCommand("SP_phpatrecfrm_Temp", con);
        cmd.CommandType = CommandType.StoredProcedure;
       
        cmd.Parameters.Add(new SqlParameter("@PatRegID", SqlDbType.NVarChar, 50)).Value = this.PatRegID;        
        cmd.Parameters.Add(new SqlParameter("@MTCode", SqlDbType.NVarChar, 50)).Value = this.MTCode;       
        cmd.Parameters.Add(new SqlParameter("@PID", SqlDbType.Int)).Value = PID;
       
        try
        {
            con.Open();           
            cmd.CommandTimeout = 1200;

            cmd.ExecuteNonQuery();
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
        return true;
    }

    public void AlterView_Defaulte( int PID)
    {
        SqlConnection con = DataAccess.ConInitForPathology();
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();

            cmd = new SqlCommand(" alter view VW_Test as SELECT     patmstd.MTCode, patmstd.SampleType, MainTest.Maintestname AS testname, patmstd.TestRate, patmstd.PID "+
               " FROM         patmstd INNER JOIN "+
               " MainTest ON patmstd.MTCode = MainTest.MTCode AND patmstd.SDCode = MainTest.SDCode " +
                     " where   dbo.patmstd.PID='" + PID + "'  ", con);
           
            //con.Open();
            cmd.ExecuteNonQuery();
        }
        catch (Exception exc) { }
        finally { con.Close(); con.Dispose(); }
    }

    public bool DisactiveTest(int branchid)
    {

        SqlConnection con = DataAccess.ConInitForPathology();
        DateTime dateofentrynew = this.Patregdate;
        SqlCommand cmd = new SqlCommand("SP_DisactiveTest", con);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("@PatRegID", SqlDbType.NVarChar, 50)).Value = this.PatRegID;
        cmd.Parameters.Add(new SqlParameter("@MTCode", SqlDbType.NVarChar, 50)).Value = this.MTCode;
        cmd.Parameters.Add(new SqlParameter("@PID", SqlDbType.Int)).Value = PID;
        cmd.Parameters.Add(new SqlParameter("@Username", SqlDbType.NVarChar, 50)).Value = this.Username;
        try
        {
            con.Open();
            cmd.CommandTimeout = 1200;

            cmd.ExecuteNonQuery();
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
        return true;
    }

    public string GetSMSString_AuthorizedTest( int pid)
    {
        SqlConnection conn = DataAccess.ConInitForPathology();
        string s = "";
        try
        {

            conn.Open();
            SqlCommand cmd = new SqlCommand("sp_getauthorizedtest", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pid", pid);
           

            s = Convert.ToString(cmd.ExecuteScalar());

        }
        catch (Exception ex)
        {
        }
        finally
        {
            conn.Close();
            conn.Dispose();

        }
        return s;
    }
   
   public bool Insert_Update_ForPmst_Edit(int branchid)
    {
        int PID = 0;
        SqlConnection con = DataAccess.ConInitForPathology();
        DateTime dateofentrynew = this.Patregdate;
        SqlCommand cmd = new SqlCommand("SP_phpatrecfrm_Edit", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@count", SqlDbType.Int, 4)).Value = this.Count;

        cmd.Parameters.Add(new SqlParameter("@Patregdate", SqlDbType.DateTime)).Value = this.Patregdate;
        cmd.Parameters.Add(new SqlParameter("@intial", SqlDbType.NVarChar, 10)).Value = this.Initial;
        cmd.Parameters.Add(new SqlParameter("@Patname", SqlDbType.NVarChar, 350)).Value = this.Patname;

        cmd.Parameters.Add(new SqlParameter("@Sex", SqlDbType.NVarChar, 6)).Value = this.Sex;
        cmd.Parameters.Add(new SqlParameter("@Age", SqlDbType.Int, 4)).Value = this.Age;
        cmd.Parameters.Add(new SqlParameter("@Mob_no", SqlDbType.NVarChar, 50)).Value = this.Phone;
        if (this.Email != null)
            cmd.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar, 50)).Value = this.Email;
        else
            cmd.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar, 50)).Value = "";
        cmd.Parameters.Add(new SqlParameter("@MDY", SqlDbType.NVarChar, 5)).Value = this.MYD;
        cmd.Parameters.Add(new SqlParameter("@RefDr", SqlDbType.NVarChar, 50)).Value = this.DoctorCode;
        if (this.Address1 != null)
            cmd.Parameters.Add(new SqlParameter("@Pataddress", SqlDbType.NVarChar, 250)).Value = this.Address1;
        else
            cmd.Parameters.Add(new SqlParameter("@Pataddress", SqlDbType.NVarChar, 250)).Value = "";
        if (this.remark != null)
            cmd.Parameters.Add(new SqlParameter("@Remark", SqlDbType.NVarChar, 50)).Value = this.remark;
        else
            cmd.Parameters.Add(new SqlParameter("@Remark", SqlDbType.NVarChar, 50)).Value = "";

        if (this.PatientcHistory != null)
            cmd.Parameters.Add(new SqlParameter("@PatientcHistory", SqlDbType.NText)).Value = this.PatientcHistory;
        else
            cmd.Parameters.Add(new SqlParameter("@PatientcHistory", SqlDbType.NText)).Value = "";
        cmd.Parameters.Add(new SqlParameter("@branchid", SqlDbType.Int)).Value = branchid;
        if (this.username != null)
            cmd.Parameters.Add(new SqlParameter("@Username", SqlDbType.NVarChar, 50)).Value = this.Username;
        else
            cmd.Parameters.Add(new SqlParameter("@Username", SqlDbType.NVarChar, 50)).Value = "";

        if (this.Usertype != null)
            cmd.Parameters.Add(new SqlParameter("@Usertype", SqlDbType.NVarChar, 250)).Value = this.Usertype;
        else
            cmd.Parameters.Add(new SqlParameter("@Usertype", SqlDbType.NVarChar, 250)).Value = "";
        if (this.Tests != null)
            cmd.Parameters.Add(new SqlParameter("@Tests", SqlDbType.NText)).Value = this.Tests;
        else
            cmd.Parameters.Add(new SqlParameter("@Tests", SqlDbType.NText)).Value = "";
        cmd.Parameters.Add(new SqlParameter("@PatRegID", SqlDbType.NVarChar, 50)).Value = this.PatRegID;
        cmd.Parameters.Add(new SqlParameter("@FID", SqlDbType.NVarChar, 50)).Value = this.FID;

        cmd.Parameters.Add(new SqlParameter("@CenterName", SqlDbType.NVarChar, 250)).Value = this.CenterName;

        cmd.Parameters.Add(new SqlParameter("@PF", SqlDbType.Bit)).Value = this.PF;
        cmd.Parameters.Add(new SqlParameter("@Reportdate", SqlDbType.DateTime)).Value = this.ReportDate;
        if (this.CollDate == Date.getMinDate())
            cmd.Parameters.Add(new SqlParameter("@Phrecdate", SqlDbType.DateTime)).Value = DBNull.Value;
        else
            cmd.Parameters.Add(new SqlParameter("@Phrecdate", SqlDbType.DateTime)).Value = this.CollDate;



        cmd.Parameters.Add(new SqlParameter("@Patphoneno", SqlDbType.NVarChar, 255)).Value = this.Phone;

        cmd.Parameters.Add(new SqlParameter("@emergencyflag", SqlDbType.Bit)).Value = this.Emergencyflag;

        cmd.Parameters.Add(new SqlParameter("@DoctorCode", SqlDbType.NVarChar, 50)).Value = this.DoctorCode;
        cmd.Parameters.Add(new SqlParameter("@Drname", SqlDbType.NVarChar, 50)).Value = this.Drname;

        cmd.Parameters.Add(new SqlParameter("@CenterCode", SqlDbType.NVarChar, 250)).Value = this.CenterCode;

        cmd.Parameters.Add(new SqlParameter("@FinancialYearID", SqlDbType.NVarChar, 50)).Value = this.FinancialYearID;

        cmd.Parameters.Add(new SqlParameter("@TestCharges", SqlDbType.Float)).Value = this.TestCharges;
        cmd.Parameters.Add(new SqlParameter("@SampleID", SqlDbType.NVarChar, 50)).Value = this.SampleID;

        if (this.SampleType == null)
            cmd.Parameters.Add(new SqlParameter("@SampleType", SqlDbType.NVarChar, 50)).Value = DBNull.Value;
        else
            cmd.Parameters.Add(new SqlParameter("@SampleType", SqlDbType.NVarChar, 50)).Value = this.SampleType;

        cmd.Parameters.Add(new SqlParameter("@BarcodeID", SqlDbType.NVarChar, 50)).Value = this.Barcodeid;

        cmd.Parameters.Add(new SqlParameter("@TelNo", SqlDbType.NVarChar, 50)).Value = this.TelNo;
        cmd.Parameters.Add(new SqlParameter("@RegistratonDateTime", SqlDbType.DateTime)).Value = this.Patregdate;
        if (this.P_PUserName != null)
            cmd.Parameters.Add(new SqlParameter("@Patusername", SqlDbType.NVarChar, 250)).Value = this.P_PUserName;
        else
            cmd.Parameters.Add(new SqlParameter("@Patusername", SqlDbType.NVarChar, 250)).Value = "";
        if (this.P_PPassword != null)
            cmd.Parameters.Add(new SqlParameter("@Patpassword", SqlDbType.NVarChar, 250)).Value = this.P_PPassword;
        else
            cmd.Parameters.Add(new SqlParameter("@Patpassword", SqlDbType.NVarChar, 250)).Value = "";
        cmd.Parameters.Add(new SqlParameter("@TestName", SqlDbType.NVarChar, 4000)).Value = this.TestName;
        cmd.Parameters.Add(new SqlParameter("@UnitCode", SqlDbType.NVarChar, 50)).Value = this.UnitCode;

        cmd.Parameters.Add(new SqlParameter("@MTCode", SqlDbType.NVarChar, 50)).Value = this.MTCode;
        cmd.Parameters.Add(new SqlParameter("@SDCode", SqlDbType.NVarChar, 50)).Value = this.SDCode;
        cmd.Parameters.Add(new SqlParameter("@PackageCode", SqlDbType.NVarChar, 50)).Value = this.PackageCode;
        cmd.Parameters.Add(new SqlParameter("@TestRate", SqlDbType.Float)).Value = this.TestRate;

        cmd.Parameters.Add(new SqlParameter("@dramt", SqlDbType.Float)).Value = this.dramt;
        cmd.Parameters.Add(new SqlParameter("@DigModule", SqlDbType.Int)).Value = this.P_DigModule;
        cmd.Parameters.Add(new SqlParameter("@cons", SqlDbType.Int)).Value = this.P_perdis;
        cmd.Parameters.Add(new SqlParameter("@CodeTes", SqlDbType.NVarChar, 50)).Value = this.CodeTes;
        cmd.Parameters.Add(new SqlParameter("@VSampleType", SqlDbType.NVarChar, 200)).Value = (string)(this.Vsampletype);
        cmd.Parameters.Add(new SqlParameter("@VTestCodes", SqlDbType.NVarChar, 1000)).Value = (string)(this.Vtestcodes);
        cmd.Parameters.Add(new SqlParameter("@VTestNames", SqlDbType.NVarChar, 2000)).Value = (string)(this.Vtestnames);
        cmd.Parameters.Add(new SqlParameter("@VCodeTes", SqlDbType.NVarChar, 50)).Value = this.VCodeTes;

        cmd.Parameters.Add(new SqlParameter("@BarcodeIDForBar", SqlDbType.NVarChar, 50)).Value = this.BarcodeIDForBar;
        cmd.Parameters.Add(new SqlParameter("@TempMTCode", SqlDbType.NVarChar, 50)).Value = this.MTCodeNew;

        cmd.Parameters.Add(new SqlParameter("@PIDNew", SqlDbType.Int, 4)).Value = this.PIDNew;
        cmd.Parameters.Add(new SqlParameter("@ContBarcodeid", SqlDbType.NVarChar, 500)).Value = this.ContBarcodeid;
        cmd.Parameters.Add(new SqlParameter("@IsbillBH", SqlDbType.Bit)).Value = this.BHFlag;
        cmd.Parameters.Add(new SqlParameter("@Monthlybill", SqlDbType.Bit)).Value = this.Monthlybill;
        cmd.Parameters.Add(new SqlParameter("@OtherRefDoctor", SqlDbType.NVarChar, 500)).Value = this.OtherRefDoctor;

        cmd.Parameters.Add(new SqlParameter("@Weights", SqlDbType.NVarChar, 500)).Value = P_Weights;
        cmd.Parameters.Add(new SqlParameter("@Heights", SqlDbType.NVarChar, 500)).Value = P_Heights;
        cmd.Parameters.Add(new SqlParameter("@Disease", SqlDbType.NVarChar, 500)).Value = P_Disease;
        cmd.Parameters.Add(new SqlParameter("@LastPeriod", SqlDbType.NVarChar, 500)).Value = P_LastPeriod;
        cmd.Parameters.Add(new SqlParameter("@Symptoms", SqlDbType.NVarChar, 500)).Value = P_Symptoms;
        cmd.Parameters.Add(new SqlParameter("@FSTime", SqlDbType.NVarChar, 500)).Value = P_FSTime;
        cmd.Parameters.Add(new SqlParameter("@Therapy", SqlDbType.NVarChar, 500)).Value = P_Therapy;
        cmd.Parameters.Add(new SqlParameter("@SocialMedia", SqlDbType.Int, 4)).Value = P_SocialMedia;
        cmd.Parameters.Add(new SqlParameter("@AccDateofBirth", SqlDbType.Int, 4)).Value = this.AccDateofBirth;
        cmd.Parameters.Add(new SqlParameter("@DateOfBirth", SqlDbType.DateTime)).Value = this.DateOfBirth;
        cmd.Parameters.Add(new SqlParameter("@ReportAssignStatus", SqlDbType.Int, 4)).Value = P_ReportAssignStatus;
        cmd.Parameters.Add(new SqlParameter("@PatientCardNo", SqlDbType.NVarChar, 500)).Value = P_PatientCardNo;
        cmd.Parameters.Add(new SqlParameter("@PatientCardExpNo", SqlDbType.NVarChar, 500)).Value = P_PatientCardExpNo;

        try
        {
            con.Open();
            cmd.CommandTimeout = 1200;

            cmd.ExecuteNonQuery();
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
        return true;
    }

   public int GetSMSString_AuthorizedTestSMS(int pid)
   {
       SqlConnection conn = DataAccess.ConInitForPathology();
       int s = 0;
       try
       {

           conn.Open();
           SqlCommand cmd = new SqlCommand("sp_getauthorizedtestSMS", conn);
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.Parameters.AddWithValue("@pid", pid);


           s = Convert.ToInt32(cmd.ExecuteScalar());

       }
       catch (Exception ex)
       {
       }
       finally
       {
           conn.Close();
           conn.Dispose();

       }
       return s;
   }

}

