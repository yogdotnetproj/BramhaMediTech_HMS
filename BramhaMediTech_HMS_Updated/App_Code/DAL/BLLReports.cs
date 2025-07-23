using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
/// <summary>
/// Summary description for BLLReports
/// </summary>
public class BLLReports
{
	public BLLReports()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public void AllOPD_Service_Report(int PatRegId, int OPDNO)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("USp_Vw_GetAllOPD_Report", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@PatRegId", PatRegId);
            cmd.Parameters.AddWithValue("@OPDNO", OPDNO);

            cmd.ExecuteNonQuery();


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

    public DataSet Get_EMR_Lab_IPDPatients(string FromDate, string ToDate, int PatRegId, string MobileNo, string PaymentStatus, int FId, int BranchId, string LabPtype, string UserName, string TestStatus)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Get_EMR_LabPatients_IPD", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            if (FromDate == "")
            {
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@FromDate", FromDate);
                // cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture));
            }
            if (ToDate == "")
            {
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            }
            else
            {

                cmd.Parameters.AddWithValue("@ToDate", ToDate);
                // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                // cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
                // cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture));

            }
            cmd.Parameters.AddWithValue("@PatRegId", PatRegId);
            cmd.Parameters.AddWithValue("@MobileNo", MobileNo);
            cmd.Parameters.AddWithValue("@PaymentStatus", PaymentStatus);
            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.Parameters.AddWithValue("@LabPtype", LabPtype);
            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@TestStatus", TestStatus);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            //ds.Tables[0].TableName = "Vw_LabBillPatientsPayment";
            return ds;

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



    public DataSet Get_EMR_LabPatients(string FromDate, string ToDate, int PatRegId, string MobileNo, string PaymentStatus, int FId, int BranchId,  string LabPtype, string UserName,string TestStatus)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Get_EMR_LabPatients", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            if (FromDate == "")
            {
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@FromDate", FromDate);
                // cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture));
            }
            if (ToDate == "")
            {
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            }
            else
            {

                cmd.Parameters.AddWithValue("@ToDate", ToDate);
                // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                // cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
                // cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture));

            }
            cmd.Parameters.AddWithValue("@PatRegId", PatRegId);
            cmd.Parameters.AddWithValue("@MobileNo", MobileNo);
            cmd.Parameters.AddWithValue("@PaymentStatus", PaymentStatus);
            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);           
            cmd.Parameters.AddWithValue("@LabPtype", LabPtype);
            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@TestStatus", TestStatus);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            cmd.CommandTimeout = 5000;
            sda.Fill(ds);
            //ds.Tables[0].TableName = "Vw_LabBillPatientsPayment";
            return ds;

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


    public DataSet FillLabBillOutstanding_new(string FromDate, string ToDate, int PatRegId, string MobileNo, string PaymentStatus, int FId, int BranchId, int BillNo, string LabPtype, string UserName)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Vw_LabBillPatientsPayment", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            if (FromDate == "")
            {
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@FromDate", FromDate);
                // cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture));
            }
            if (ToDate == "")
            {
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            }
            else
            {

                cmd.Parameters.AddWithValue("@ToDate", ToDate);
                // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                // cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
                // cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture));

            }
            cmd.Parameters.AddWithValue("@PatRegId", PatRegId);
            cmd.Parameters.AddWithValue("@MobileNo", MobileNo);
            cmd.Parameters.AddWithValue("@PaymentStatus", PaymentStatus);
            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);

            cmd.Parameters.AddWithValue("@BillNo", BillNo);
            cmd.Parameters.AddWithValue("@LabPtype", LabPtype);
            cmd.Parameters.AddWithValue("@UserName", UserName);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            cmd.CommandTimeout = 5000;
            sda.Fill(ds);
            //ds.Tables[0].TableName = "Vw_LabBillPatientsPayment";
            return ds;

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

    public DataTable SelectAllLabService(int PatRegId, string MobileNo, int LabNo, int FId, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetAllLabService", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@PatRegId", PatRegId);
            cmd.Parameters.AddWithValue("@MobileNo", MobileNo);
            cmd.Parameters.AddWithValue("@LabNo", LabNo);
            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            sda.Fill(ds);
            // ds.Tables[0].TableName = "Vw_LabEditPatients";
            return ds;

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

    public DataTable GetLabReceiptNo(int PatRegId, int OpdNo, int BillNo, int FId, int BranchId, int LabNo)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetLabReceiptNo", con);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@PatRegId", PatRegId);
        cmd.Parameters.AddWithValue("@BillNo", BillNo);
        cmd.Parameters.AddWithValue("@FId", FId);
        cmd.Parameters.AddWithValue("@BranchId", BranchId);
        cmd.Parameters.AddWithValue("@LabNo", LabNo);

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable ds = new DataTable();
        da.Fill(ds);

        con.Close();
        con.Dispose();

        return ds;



    }

    public string Delete_LabService(int BillNo, int LabNo, int Patregid, int Branchid, string CancelBy, string CancelRemark)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_LabTestDelete", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@BillNo", BillNo);
            cmd.Parameters.AddWithValue("@LabNo", LabNo);
            cmd.Parameters.AddWithValue("@Patregid", Patregid);
            cmd.Parameters.AddWithValue("@Branchid", Branchid);
            cmd.Parameters.AddWithValue("@CancelBy", CancelBy);
            cmd.Parameters.AddWithValue("@CancelRemark", CancelRemark);
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
    public string Delete_LabIPDService(int IPDNO, int LabNo, int Patregid, int Branchid, string MTCode, string CancelRemark)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_LabIPDTestDelete", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@IPDNo", IPDNO);
            cmd.Parameters.AddWithValue("@LabNo", LabNo);
            cmd.Parameters.AddWithValue("@Patregid", Patregid);
            cmd.Parameters.AddWithValue("@Branchid", Branchid);
            cmd.Parameters.AddWithValue("@MTCode", MTCode);
            cmd.Parameters.AddWithValue("@CancelRemark", CancelRemark);
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
    public DataSet FillIPDLabEditPatients_New(string FromDate, string ToDate, int PatRegId, string MobileNo, int FId, int BranchId, int BillNo, string UserName, string LabPtype)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Vw_IPDLabEditPatients_New", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            if (FromDate == "")
            {
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@FromDate", FromDate);
                // cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture));
            }
            if (ToDate == "")
            {
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            }
            else
            {

                cmd.Parameters.AddWithValue("@ToDate", ToDate);
                // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                // cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
                // cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture));

            }
            cmd.Parameters.AddWithValue("@PatRegId", PatRegId);
            cmd.Parameters.AddWithValue("@MobileNo", MobileNo);

            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.Parameters.AddWithValue("@BillNo", BillNo);
            cmd.Parameters.AddWithValue("@LabPtype", LabPtype);
            cmd.Parameters.AddWithValue("@UserName", UserName);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            // ds.Tables[0].TableName = "Vw_LabEditPatients";
            return ds;

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


    public DataSet FillIPDLabEditPatients(string FromDate, string ToDate, int PatRegId, string MobileNo, int FId, int BranchId, int BillNo, string UserName, string LabPtype)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Vw_IPDLabEditPatients", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            if (FromDate == "")
            {
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@FromDate", FromDate);
                // cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture));
            }
            if (ToDate == "")
            {
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            }
            else
            {

                cmd.Parameters.AddWithValue("@ToDate", ToDate);
                // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                // cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
                // cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture));

            }
            cmd.Parameters.AddWithValue("@PatRegId", PatRegId);
            cmd.Parameters.AddWithValue("@MobileNo", MobileNo);
           
            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.Parameters.AddWithValue("@BillNo", BillNo);
            cmd.Parameters.AddWithValue("@LabPtype", LabPtype);
            cmd.Parameters.AddWithValue("@UserName", UserName);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
           // ds.Tables[0].TableName = "Vw_LabEditPatients";
            return ds;

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

    public DataSet FillLabEditPatients(string FromDate, string ToDate, int PatRegId, string MobileNo, string PaymentStatus, int FId, int BranchId, int BillNo, string LabPtype, string UserName)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Vw_LabEditPatients", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            if (FromDate == "")
            {
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@FromDate", FromDate);
                // cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture));
            }
            if (ToDate == "")
            {
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            }
            else
            {

                cmd.Parameters.AddWithValue("@ToDate", ToDate);
                // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                // cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
                // cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture));

            }
            cmd.Parameters.AddWithValue("@PatRegId", PatRegId);
            cmd.Parameters.AddWithValue("@MobileNo", MobileNo);
            cmd.Parameters.AddWithValue("@PaymentStatus", PaymentStatus);
            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.Parameters.AddWithValue("@BillNo", BillNo);
            cmd.Parameters.AddWithValue("@LabPtype", LabPtype);
            cmd.Parameters.AddWithValue("@UserName", UserName);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            cmd.CommandTimeout = 5000;
            sda.Fill(ds);
            ds.Tables[0].TableName = "Vw_LabEditPatients";
            return ds;

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

    public DataSet GetIPDLabBillDetails(int IpdNo, int Labno, int PatRegId, int FId, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetLabIPDBillingReport", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@IpdNo", IpdNo);

        cmd.Parameters.AddWithValue("@Labno", Labno);
        cmd.Parameters.AddWithValue("@PatRegId", PatRegId);
        cmd.Parameters.AddWithValue("@FId", FId);
        cmd.Parameters.AddWithValue("@BranchId", BranchId);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();

        sda.Fill(ds);
        ds.Tables[0].TableName = "Vw_LabIPDBillReport";

        con.Close();
        con.Dispose();
        return ds;
    }

    public DataSet GetLabBillDetails(int BillNo, int ReceiptNo, int OpdNo, int PatRegId, int FId, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetLabBillingReport", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@BillNo", BillNo);
        cmd.Parameters.AddWithValue("@ReceiptNo", ReceiptNo);
        cmd.Parameters.AddWithValue("@OpdNo", OpdNo);
        cmd.Parameters.AddWithValue("@PatRegId", PatRegId);
        cmd.Parameters.AddWithValue("@FId", FId);
        cmd.Parameters.AddWithValue("@BranchId", BranchId);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();

        sda.Fill(ds);
        ds.Tables[0].TableName = "Vw_LabBillReport";

        con.Close();
        con.Dispose();
        return ds;
    }

    public DataSet GetLabBillDetailsAll(int BillNo,  int OpdNo, int PatRegId, int FId, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetLabBillingReportALL", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@BillNo", BillNo);
       
        cmd.Parameters.AddWithValue("@OpdNo", OpdNo);
        cmd.Parameters.AddWithValue("@PatRegId", PatRegId);
        cmd.Parameters.AddWithValue("@FId", FId);
        cmd.Parameters.AddWithValue("@BranchId", BranchId);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();

        sda.Fill(ds);
        ds.Tables[0].TableName = "Vw_LabBillReport";

        con.Close();
        con.Dispose();
        return ds;
    }

    public DataSet FillPatientCard(int PatRegId, int BranchId, int FId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Vw_PatientInfo", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PatRegId", PatRegId);
        cmd.Parameters.AddWithValue("@FId", FId);
        cmd.Parameters.AddWithValue("@BranchId", BranchId);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ds.Tables[0].TableName = "Vw_PatientInfo";

        con.Close();
        con.Dispose();
        return ds;

    }
    public DataSet GetOPDBillDetails(int BillNo, int ReceiptNo, int OpdNo, int PatRegId, int FId, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetOPDBillingReport", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@BillNo", BillNo);
        cmd.Parameters.AddWithValue("@ReceiptNo", ReceiptNo);
        cmd.Parameters.AddWithValue("@OpdNo", OpdNo);
        cmd.Parameters.AddWithValue("@PatRegId", PatRegId);
        cmd.Parameters.AddWithValue("@FId", FId);
        cmd.Parameters.AddWithValue("@BranchId", BranchId);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();

        sda.Fill(ds);
        ds.Tables[0].TableName = "Vw_OpdBillReport";

        con.Close();
        con.Dispose();
        return ds;
    }

    public void GetProcedureBillDetails(int BillNo,  int PatRegId,int ProcedureId, int FId, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Vw_ProcedureBillReport", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@BillNo", BillNo);        
        cmd.Parameters.AddWithValue("@PatRegId", PatRegId);
        cmd.Parameters.AddWithValue("@ProcedureId", ProcedureId);
        cmd.Parameters.AddWithValue("@FId", FId);
        cmd.Parameters.AddWithValue("@BranchId", BranchId);
        cmd.ExecuteNonQuery();
        con.Close();
        con.Dispose();
        
    }
    public DataSet fillUsers(int UserId, int BranchId, int FId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_FillUsers", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@UserId", UserId);
        cmd.Parameters.AddWithValue("@FId", FId);
        cmd.Parameters.AddWithValue("@BranchId", BranchId);

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        con.Dispose();
        return ds;

    }

    public DataSet PatientInsuranceDetails_Invoice_ForAllOPD_Rept(int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_PatientInsuranceReport", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
      
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.CommandTimeout = 0;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
           
            sda.Fill(ds);
            ds.Tables[0].TableName = "Vw_PatientInsuranceDetailsFor_InsuranceCompany";

            return ds;

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Dispose();
            con.Close();
        }
    }
    public DataSet FillDoctorWiseCashReport(string FromDate, string ToDate, int DrId,int BillServiceId,int FId, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Vw_DailyDoctorCashReport", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            if (FromDate == "")
            {
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            }
            else
            {

                cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            if (ToDate == "")
            {
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            }
            else
            {
                // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            cmd.Parameters.AddWithValue("@DrId", DrId);
            cmd.Parameters.AddWithValue("@BillServiceId", BillServiceId); 
            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            ds.Tables[0].TableName = "Vw_DrWiseIncomeReport";
            
            return ds;

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Dispose();
            con.Close();
        }
    }
    public DataSet FillUserWiseCashSummary(string FromDate, string ToDate, int PatRegId, string UserName, string PaymentType, int FId, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Vw_DailyCashSumary", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            if (FromDate == "")
            {
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            }
            else
            {

                cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            if (ToDate == "")
            {
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            }
            else
            {
                // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            cmd.Parameters.AddWithValue("@PatRegId", PatRegId);
            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@PaymentType",PaymentType);
            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            ds.Tables[0].TableName = "Vw_BillTransactions";
            return ds;

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
    public DataSet FillDailyIncomeReport(string FromDate, string ToDate, int FId, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Vw_DailyIncomeReport", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            if (FromDate == "")
            {
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            }
            else
            {

                cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            if (ToDate == "")
            {
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            }
            else
            {
                // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            
            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();           
            sda.Fill(ds);
            ds.Tables[0].TableName = "Vw_DailyIncomeReport";
            return ds;
            

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
    public DataTable FillDailyIncomeReportGrid(string FromDate, string ToDate, int FId, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Vw_DailyIncomeReport", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            if (FromDate == "")
            {
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            }
            else
            {

                cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            if (ToDate == "")
            {
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            }
            else
            {
                // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }

            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
           // ds.Tables[0].TableName = "Vw_DailyIncomeReport";
            return dt;


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
    public DataTable GetReceiptNo( int PatRegId,int OpdNo,int BillNo,int FId,int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetReceiptNo", con);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@PatRegId", PatRegId);
        cmd.Parameters.AddWithValue("@OpdNo", OpdNo);
        cmd.Parameters.AddWithValue("@BillNo", BillNo);
        cmd.Parameters.AddWithValue("@FId", FId);
        cmd.Parameters.AddWithValue("@BranchId", BranchId);

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable ds = new DataTable();
        da.Fill(ds);
        con.Close();
        con.Dispose();
        return ds;



    }

    public DataSet FillOpdBillOutstanding_Procedure(string FromDate, string ToDate, int PatRegId, string MobileNo, string PaymentStatus, int FId, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Vw_OpdBillOutStandingPayment", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            if (FromDate == "")
            {
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@FromDate", FromDate);
                // cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture));
            }
            if (ToDate == "")
            {
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            }
            else
            {

                cmd.Parameters.AddWithValue("@ToDate", ToDate);
                // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                // cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
                // cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture));

            }
            cmd.Parameters.AddWithValue("@PatRegId", PatRegId);
            cmd.Parameters.AddWithValue("@MobileNo", MobileNo);
            cmd.Parameters.AddWithValue("@PaymentStatus", PaymentStatus);
            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            ds.Tables[0].TableName = "Vw_OpdOutstandingPayment";
            return ds;

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


    public DataSet FillOpdBillOutstanding(string FromDate, string ToDate, int PatRegId,string MobileNo, string PaymentStatus, int FId, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Vw_OpdBillOutStandingPayment", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            if (FromDate == "")
            {
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@FromDate", FromDate);
               // cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture));
            }
            if (ToDate == "")
            {
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            }
            else
            {
               
                cmd.Parameters.AddWithValue("@ToDate", ToDate);
                // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
               // cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
               // cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture));

            }
            cmd.Parameters.AddWithValue("@PatRegId", PatRegId);
            cmd.Parameters.AddWithValue("@MobileNo", MobileNo);
            cmd.Parameters.AddWithValue("@PaymentStatus", PaymentStatus);
            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            ds.Tables[0].TableName = "Vw_OpdOutstandingPayment";
            return ds;

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

    public DataSet FillOpdPatientList(string FromDate, string ToDate, int PatRegId, string MobileNo,  int FId, int BranchId,int DrId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_CancelOpdRegistrationList", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            if (FromDate == "")
            {
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@FromDate", FromDate);
                // cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture));
            }
            if (ToDate == "")
            {
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            }
            else
            {

                cmd.Parameters.AddWithValue("@ToDate", ToDate);
                // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                // cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
                // cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture));

            }
            cmd.Parameters.AddWithValue("@PatRegId", PatRegId);
            cmd.Parameters.AddWithValue("@MobileNo", MobileNo);
            cmd.Parameters.AddWithValue("@DrId", DrId);
            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
           // ds.Tables[0].TableName = "Vw_OpdOutstandingPayment";
            return ds;

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

    public DataSet FillEmergencyRegister(string FromDate, string ToDate, int PatRegId, string MobileNo, int DeptId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_EmergencyPatientRegister", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            if (FromDate == "")
            {
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            }
            else
            {
               // cmd.Parameters.AddWithValue("@FromDate", FromDate);
                cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            if (ToDate == "")
            {
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            }
            else
            {
                cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            cmd.Parameters.AddWithValue("@PatRegId", PatRegId);
            cmd.Parameters.AddWithValue("@MobileNo", MobileNo);
            cmd.Parameters.AddWithValue("@DeptId", DeptId);
            
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            ds.Tables[0].TableName = "EmergencyPatientRegister";
            return ds;

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
    public DataSet FillOpdBillOutstanding_Insurance(string FromDate, string ToDate, int PatRegId, string MobileNo, string PaymentStatus, int FId, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Vw_OpdBillOutStandingPayment_Insurance", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            if (FromDate == "")
            {
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            }
            else
            {

                cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            if (ToDate == "")
            {
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            }
            else
            {
                // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            cmd.Parameters.AddWithValue("@PatRegId", PatRegId);
            cmd.Parameters.AddWithValue("@MobileNo", MobileNo);
            cmd.Parameters.AddWithValue("@PaymentStatus", PaymentStatus);
            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            ds.Tables[0].TableName = "Vw_OpdOutstandingPayment";
            return ds;

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

    public DataSet GetIpdPatientCard(int IpdId, int FId, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Vw_IPDPatientCard", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@IpdId", IpdId);
            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            ds.Tables[0].TableName = "Vw_IPDPatientCard";
            return ds;

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


    public DataSet VW_OpdVisitChildren()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_VW_OpdVisitChildren", con);
        cmd.CommandType = CommandType.StoredProcedure;
       
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();

        sda.Fill(ds);
       // ds.Tables[0].TableName = "Vw_OpdBillReport";

        con.Close();
        con.Dispose();
        return ds;
    }


    public DataSet GetIPDBillDetails(int BillNo, int ReceiptNo, int IpdNo, int PatRegId, int FId, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetIPDBillingReceipt", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@BillNo", BillNo);
        cmd.Parameters.AddWithValue("@ReceiptNo", ReceiptNo);
        cmd.Parameters.AddWithValue("@IpdNo", IpdNo);
        cmd.Parameters.AddWithValue("@PatRegId", PatRegId);
        cmd.Parameters.AddWithValue("@FId", FId);
        cmd.Parameters.AddWithValue("@BranchId", BranchId);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();

        sda.Fill(ds);
        ds.Tables[0].TableName = "Vw_IpdBillPaymentReceipt";

        con.Close();
        con.Dispose();
        return ds;
    }

    public void IpdFrontSheetSummaryReport(int IpdId, int PatRegId, int FId, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        // SqlCommand cmd = new SqlCommand("Sp_Vw_IPDBillDetailsReport", con);
        SqlCommand cmd = new SqlCommand("Sp_VW_FrontsheetSummary", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@IpdId", IpdId);
            cmd.Parameters.AddWithValue("@PatRegId", PatRegId);
            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.ExecuteNonQuery();
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

    public void IpdBillDetails(int IpdId, int PatRegId, int FId, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        // SqlCommand cmd = new SqlCommand("Sp_Vw_IPDBillDetailsReport", con);
        SqlCommand cmd = new SqlCommand("Sp_Vw_IPDBillServicesDetailsReport", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@IpdId", IpdId);
            cmd.Parameters.AddWithValue("@PatRegId", PatRegId);
            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.ExecuteNonQuery();
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
    public DataSet GetOperationNotes(int OTId,int PatRegId, int FId,int BranchId)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("usp_GetIpdPatientOTNotes", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@OTId", OTId);
        cmd.Parameters.AddWithValue("@PatRegId", PatRegId);        
        cmd.Parameters.AddWithValue("@FId",FId);
        cmd.Parameters.AddWithValue("@BranchId",BranchId);
       
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();

        sda.Fill(ds);
        ds.Tables[0].TableName = "OTNotes";

        con.Close();
        con.Dispose();
        return ds;

    }

    public DataSet GetOperationNotes_Report(int IpdNo, int PatRegId, int FId, int BranchId)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("usp_GetIpdPatientOTNotes_Report", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@OTId", IpdNo);
        cmd.Parameters.AddWithValue("@PatRegId", PatRegId);
        cmd.Parameters.AddWithValue("@FId", FId);
        cmd.Parameters.AddWithValue("@BranchId", BranchId);

        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();

        sda.Fill(ds);
        ds.Tables[0].TableName = "OTNotes";

        con.Close();
        con.Dispose();
        return ds;

    }
    public DataSet GetSurgeryNotes(int SurgEstimationId)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("usp_GetSurgeryQuotationByDoc", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@SurgEstimationId", SurgEstimationId);
       

        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();

        sda.Fill(ds);
        ds.Tables[0].TableName = "Vw_SurgeryQuotationByDoc";

        con.Close();
        con.Dispose();
        return ds;

    }
    public DataSet GetSurgeryFinalQuatation_Rpt(int SurgEstimationId)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_FinalSurgeryQuotationRpt", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@SurgEstimationId", SurgEstimationId);


        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();

        sda.Fill(ds);
        ds.Tables[0].TableName = "Vw_FinalSurgeryQuotationRpt";

        con.Close();
        con.Dispose();
        return ds;

    }
    public void IpdBillSummary(int IpdId, int PatRegId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Vw_IpdBillSummary", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@IpdId", IpdId);
            cmd.Parameters.AddWithValue("@PatRegId", PatRegId);
            cmd.ExecuteNonQuery();
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
    public void GetDepositReport(int DepositId, int PatRegId, int FId, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Vw_Deposite", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@DepositId", DepositId);
            cmd.Parameters.AddWithValue("@PatRegId", PatRegId);
            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.ExecuteNonQuery();
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
    public void FillIpdDailyIncomeReport(string FromDate, string ToDate, string UserName, int PaymentType, int FId, int BranchId,string BankName)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Vw_IpdUserwiseDailyCashReport", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            if (FromDate == "")
            {
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            }
            else
            {

               // cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
                cmd.Parameters.AddWithValue("@FromDate", Convert.ToDateTime(FromDate));
            }
            if (ToDate == "")
            {
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            }
            else
            {
                // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
               // cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
                cmd.Parameters.AddWithValue("@ToDate", Convert.ToDateTime(ToDate));
            }

            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@PaymentType", PaymentType);
            cmd.Parameters.AddWithValue("@BankName", BankName);
            cmd.ExecuteNonQuery();


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

    public void FillLABCancelIncomeReport(string FromDate, string ToDate, string UserName, int PaymentType, string BillGroup, int FId, int BranchId,int PatRegId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Vw_LabPaymentTransactionRpt_UserWise_Cancel", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            if (FromDate == "")
            {
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            }
            else
            {

                cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            if (ToDate == "")
            {
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            }
            else
            {
                // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }

            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@BillGroup", BillGroup);
            cmd.Parameters.AddWithValue("@PaymentType", PaymentType);
            cmd.Parameters.AddWithValue("@PatRegId", PatRegId);
            cmd.ExecuteNonQuery();


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

    public void GetSp_VW_IpdLabServicedetails(string FromDate, string ToDate, string UserName, string LabPtype, int PatRegId, int FId, int BranchId, string MobileNo, int BillNo)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_VW_IpdLabServicedetails", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            if (FromDate == "")
            {
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            }
            else
            {

                cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            if (ToDate == "")
            {
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            }
            else
            {
                // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }

            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@LabPtype", LabPtype);
            cmd.Parameters.AddWithValue("@PatRegId", PatRegId);
            cmd.Parameters.AddWithValue("@MobileNo", MobileNo);
            cmd.Parameters.AddWithValue("@BillNo", BillNo);
            

            cmd.ExecuteNonQuery();


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

    public void FillLABIncomeReport(string FromDate, string ToDate, string UserName, int PaymentType, string BillGroup, int FId, int BranchId, string BankName, string ReferBy)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Vw_LabPaymentTransactionRpt_UserWise", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            //if (FromDate == "")
            //{
            //    cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            //}
            //else
            //{

            //    cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            //}
            //if (ToDate == "")
            //{
            //    cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            //}
            //else
            //{
            //    // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
            //    cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            //}
            if (FromDate == "")
            {
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            }
            else
            {

                cmd.Parameters.AddWithValue("@FromDate", Convert.ToDateTime(FromDate));
                // cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            if (ToDate == "")
            {
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            }
            else
            {
                cmd.Parameters.AddWithValue("@ToDate", Convert.ToDateTime(ToDate));
                // cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@BillGroup", BillGroup);
            cmd.Parameters.AddWithValue("@PaymentType", PaymentType);
            cmd.Parameters.AddWithValue("@BankName", BankName);
            cmd.Parameters.AddWithValue("@ReferBy", ReferBy);
            cmd.CommandTimeout = 5000;
            cmd.ExecuteNonQuery();
            

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
    public void FillLABIncomeReport_L(string FromDate, string ToDate, string UserName, int PaymentType, string BillGroup, int FId, int BranchId, string BankName, string ReferBy)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Vw_LabPaymentTransactionRpt_UserWise_L", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            //if (FromDate == "")
            //{
            //    cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            //}
            //else
            //{

            //    cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            //}
            //if (ToDate == "")
            //{
            //    cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            //}
            //else
            //{
            //    // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
            //    cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            //}
            if (FromDate == "")
            {
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            }
            else
            {

                cmd.Parameters.AddWithValue("@FromDate", Convert.ToDateTime(FromDate));
                // cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            if (ToDate == "")
            {
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            }
            else
            {
                cmd.Parameters.AddWithValue("@ToDate", Convert.ToDateTime(ToDate));
                // cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@BillGroup", BillGroup);
            cmd.Parameters.AddWithValue("@PaymentType", PaymentType);
            cmd.Parameters.AddWithValue("@BankName", BankName);
            cmd.Parameters.AddWithValue("@ReferBy", ReferBy);
            cmd.CommandTimeout = 5000;
            cmd.ExecuteNonQuery();


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

    public void FillProcedureIncomeReport(string FromDate, string ToDate, string UserName, int PaymentType,string BillGroup, int FId, int BranchId,string BankName)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Vw_ProcedurePaymentTransactionRpt_UserWise", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            if (FromDate == "")
            {
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            }
            else
            {

                cmd.Parameters.AddWithValue("@FromDate", Convert.ToDateTime(FromDate));
               // cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            if (ToDate == "")
            {
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            }
            else
            {
                cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
               // cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }

            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@BillGroup", BillGroup);
            cmd.Parameters.AddWithValue("@PaymentType", PaymentType);
            cmd.Parameters.AddWithValue("@BankName", BankName);

            cmd.CommandTimeout = 5000;
            cmd.ExecuteNonQuery();


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

    public void FillProcedureIncomeReport_service(string FromDate, string ToDate, string UserName, int PaymentType, string BillGroup, int FId, int BranchId,string BankName)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Vw_ProcedurePaymentTransactionRpt_UserWise_service", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            //if (FromDate == "")
            //{
            //    cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            //}
            //else
            //{

            //    cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            //}
            //if (ToDate == "")
            //{
            //    cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            //}
            //else
            //{
            //    // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
            //    cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            //}
            if (FromDate == "")
            {
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            }
            else
            {

                cmd.Parameters.AddWithValue("@FromDate", Convert.ToDateTime(FromDate));
                // cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            if (ToDate == "")
            {
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            }
            else
            {
                cmd.Parameters.AddWithValue("@ToDate", Convert.ToDateTime(ToDate));
                // cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }

            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@BillGroup", BillGroup);
            cmd.Parameters.AddWithValue("@PaymentType", PaymentType);

            cmd.Parameters.AddWithValue("@BankName", BankName);
            cmd.CommandTimeout = 5000;
            cmd.ExecuteNonQuery();


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

    public DataSet FillModeOfPaymentForReport()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("SP_ModeOfPayment_FillCombo", con);

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

    public void Fill_Discount_Report(string FromDate, string ToDate, string UserName, int FId, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Vw_Disvcount_Report", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            if (FromDate == "")
            {
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            }
            else
            {

                cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            if (ToDate == "")
            {
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            }
            else
            {
                // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }

            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.Parameters.AddWithValue("@UserName", UserName);
           
            cmd.ExecuteNonQuery();


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
    public void PatientwiseBillGroupIncome(string FromDate, string ToDate, int BillGroupId, int FId, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_PatientServiceWiseBillGrpIncome", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            if (FromDate == "")
            {
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            }
            else
            {

                cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            if (ToDate == "")
            {
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            }
            else
            {
                // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            cmd.Parameters.AddWithValue("@BillGroupId", BillGroupId);

            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.ExecuteNonQuery();

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

    public void PatientwiseBillGroupIncome_Pharmacy(string FromDate, string ToDate, int BillGroupId, int FId, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_VW_FillGridGroupWiseIncome_Pharmacy_Report", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            if (FromDate == "")
            {
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            }
            else
            {

                cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            if (ToDate == "")
            {
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            }
            else
            {
                // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            cmd.Parameters.AddWithValue("@BillGroupId", BillGroupId);

            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.ExecuteNonQuery();

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

    public void PatientwiseBillGroupIncome_Pharmacy_OP(string FromDate, string ToDate, int BillGroupId, int FId, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForPharmacy();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_VW_FillGridGroupWiseIncome_Pharmacy_Report", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            if (FromDate == "")
            {
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            }
            else
            {

                cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            if (ToDate == "")
            {
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            }
            else
            {
                // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            cmd.Parameters.AddWithValue("@BillGroupId", BillGroupId);

            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.ExecuteNonQuery();

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

    
    public void PatientwiseBillGroupIncome_Procedure(string FromDate, string ToDate, string BillGroup, int FId, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_BillGrpIncomeServiceWise_Procedure", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            if (FromDate == "")
            {
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            if (ToDate == "")
            {
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            }
            else
            {
                // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            cmd.Parameters.AddWithValue("@BillGroup", BillGroup);

            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.ExecuteNonQuery();

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

    public DataTable FillGroupwiseIncomeGrid(string FromDate, string ToDate, int FId, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_FillGridGroupWiseIncome", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            if (FromDate == "")
            {
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            }
            else
            {

                cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            if (ToDate == "")
            {
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            }
            else
            {
                // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }

            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            return dt;

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

    public DataTable FillGroupwiseIncomeGrid_Pharma(string FromDate, string ToDate, int FId, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_FillGridGroupWiseIncome_ForPharma", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            if (FromDate == "")
            {
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            }
            else
            {

                cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            if (ToDate == "")
            {
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            }
            else
            {
                // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }

            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            return dt;

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

    
    public DataTable FillGroupwiseIncomeGrid_Procedure(string FromDate, string ToDate, int FId, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_FillGridGroupWiseIncome_Procedure", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            if (FromDate == "")
            {
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            }
            else
            {

                cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            if (ToDate == "")
            {
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            }
            else
            {
                // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }

            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            return dt;

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


    public DataTable FillGroupwiseIncomeGrid_LAB(string FromDate, string ToDate, int FId, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_FillGridGroupWiseIncome_LAB", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            if (FromDate == "")
            {
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            }
            else
            {

                cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            if (ToDate == "")
            {
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            }
            else
            {
                // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }

            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            return dt;

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


    public DataTable FillServicewiseIncomeGrid(string FromDate, string ToDate, int BillGroupId, int ServiceId, int DrId, int FId, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_FillGridServiceWiseIncome", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            if (FromDate == "")
            {
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            }
            else
            {

                cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            if (ToDate == "")
            {
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            }
            else
            {
                // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            cmd.Parameters.AddWithValue("@BillGroupId", BillGroupId);
            cmd.Parameters.AddWithValue("@ServiceId", ServiceId);
            cmd.Parameters.AddWithValue("@DrId", DrId);
            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            return dt;

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

    public DataTable FillServicewiseIncomeGrid_Procedure(string FromDate, string ToDate, string BillGroupName, int ServiceId, int DrId, int FId, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_FillGridServiceWiseIncome_Procedure", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            if (FromDate == "")
            {
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            }
            else
            {

                cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            if (ToDate == "")
            {
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            }
            else
            {
                // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            cmd.Parameters.AddWithValue("@BillGroupName", BillGroupName);
            cmd.Parameters.AddWithValue("@ServiceId", ServiceId);
            cmd.Parameters.AddWithValue("@DrId", DrId);
            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            return dt;

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
    public void ServiceWiseIncomeReport(string FromDate, string ToDate, int BillServiceId, int FId, int BranchId,int  ConsultID)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Vw_ServiceWiseIncomeReport", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            if (FromDate == "")
            {
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            }
            else
            {

                cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            if (ToDate == "")
            {
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            }
            else
            {
                // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            cmd.Parameters.AddWithValue("@BillServiceId", BillServiceId);

            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.Parameters.AddWithValue("@ConsultID", ConsultID);
            cmd.ExecuteNonQuery();

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

    public void ServiceWiseIncomeReport_Procedure(string FromDate, string ToDate, int BillServiceId,int DrId, int FId, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Vw_ServiceWiseIncomeReport_Procedure", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            if (FromDate == "")
            {
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            }
            else
            {

                cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            if (ToDate == "")
            {
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            }
            else
            {
                // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            cmd.Parameters.AddWithValue("@BillServiceId", BillServiceId);
            cmd.Parameters.AddWithValue("@DrId", DrId);

            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.ExecuteNonQuery();

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
    public void FillIpdAdmissionRegister(string FromDate, string ToDate, int PatRegId, int DrId, int PatMainTypeId, int PatSubTypeId, int RoomTypeId, int FId, int BranchId, int Referdr, int Patstatus)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Vw_IpdAdmissionRegister", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            if (FromDate == "")
            {
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            }
            else
            {

                cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            if (ToDate == "")
            {
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            }
            else
            {
                // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }

            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.Parameters.AddWithValue("@DrId", DrId);
            cmd.Parameters.AddWithValue("@PatRegId", PatRegId);
            cmd.Parameters.AddWithValue("@PatMainTypeId", PatMainTypeId);
            cmd.Parameters.AddWithValue("@PatSubTypeId", PatSubTypeId);
            cmd.Parameters.AddWithValue("@RoomTypeId", RoomTypeId);
            cmd.Parameters.AddWithValue("@Referdr", Referdr);
            cmd.Parameters.AddWithValue("@Patstatus", Patstatus);

            cmd.ExecuteNonQuery();


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
    public DataSet FillIpdAdmissionRegisterGrid(string FromDate, string ToDate, int PatRegId, int DrId, int PatMainTypeId, int PatSubTypeId, int RoomTypeId, int FId, int BranchId, string AdmissionType, int Referdr,int PatientType)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_IpdAdmissionRegisterFillGrid", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            if (FromDate == "")
            {
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            }
            else
            {

                cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            if (ToDate == "")
            {
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            }
            else
            {
                // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }

            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.Parameters.AddWithValue("@DrId", DrId);
            cmd.Parameters.AddWithValue("@PatRegId", PatRegId);
            cmd.Parameters.AddWithValue("@PatMainTypeId", PatMainTypeId);
            cmd.Parameters.AddWithValue("@PatSubTypeId", PatSubTypeId);
            cmd.Parameters.AddWithValue("@RoomTypeId", RoomTypeId);
            cmd.Parameters.AddWithValue("@AdmissionType", AdmissionType);
            cmd.Parameters.AddWithValue("@SecRefDrId", Referdr);
            cmd.Parameters.AddWithValue("@PatientType", PatientType);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;

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

    public DataTable FillDoctorwiseAdvanceGrid(string FromDate, string ToDate, int DrId, int FId, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_DoctorWiseAdvanceReceipt", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            if (FromDate == "")
            {
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            }
            else
            {

                cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            if (ToDate == "")
            {
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            }
            else
            {
                // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            cmd.Parameters.AddWithValue("@DrId", DrId);
            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            return dt;

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
    public void DoctorwiseAdvancePaymentReport(string FromDate, string ToDate, int DrId, int FId, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Vw_DoctorWiseAdvanceReceipt", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            if (FromDate == "")
            {
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            }
            else
            {

                cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            if (ToDate == "")
            {
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            }
            else
            {
                // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            cmd.Parameters.AddWithValue("@DrId", DrId);

            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.ExecuteNonQuery();

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

    public void MealsFigure(string FromDate, string ToDate, int FId, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Vw_MealsFigureReport", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            if (FromDate == "")
            {
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            }
            else
            {

                cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            if (ToDate == "")
            {
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            }
            else
            {
                // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }

            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.ExecuteNonQuery();

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
    public void BillGroupSalesSummary(string FromDate, string ToDate, int FId, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Vw_BillGroupSalesSummary", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            if (FromDate == "")
            {
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            }
            else
            {

                cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            if (ToDate == "")
            {
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            }
            else
            {
                // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }

            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.ExecuteNonQuery();

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

    public void BillGroupSalesSummary_Procedure(string FromDate, string ToDate, int FId, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Vw_BillGroupSalesSummary_Procedure", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            if (FromDate == "")
            {
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            }
            else
            {

                cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            if (ToDate == "")
            {
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            }
            else
            {
                // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }

            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.ExecuteNonQuery();

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
    public void PatientCount(string FromDate, string ToDate, int FId, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Vw_PatientCount", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            if (FromDate == "")
            {
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            }
            else
            {

                cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            if (ToDate == "")
            {
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            }
            else
            {
                // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }

            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.ExecuteNonQuery();

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
    public DataSet FillAdmittedPatientList(int FId, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_CurrentAdmittedPatient", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
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
    public void AdmittedPatientList(int FId, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Vw_CurrentAdmittedPatient", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.ExecuteNonQuery();

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

    public void InsuranceSummary(string FromDate, string ToDate, int PatRegId,int InsuranceId,int RTypeId, int FId, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        //SqlCommand cmd = new SqlCommand("Sp_Vw_InsuranceSummaryReport", con);
        SqlCommand cmd = new SqlCommand("Sp_Vw_InsuranceSummaryReportNew1", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            
                cmd.Parameters.AddWithValue("@start",FromDate);
            
                cmd.Parameters.AddWithValue("@end", ToDate);

                cmd.Parameters.AddWithValue("@RTypeId", RTypeId);
                cmd.Parameters.AddWithValue("@PatRegId", PatRegId);
                cmd.Parameters.AddWithValue("@InsuranceId", InsuranceId);
            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.ExecuteNonQuery();

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

    public void InsuranceSummaryForLab(string FromDate, string ToDate, int PatRegId, string BillGroup, int InsuranceId, int FId, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        //SqlCommand cmd = new SqlCommand("Sp_Vw_InsuranceSummaryReport", con);
        SqlCommand cmd = new SqlCommand("Sp_Vw_InsuranceSummaryForLAB", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@start", FromDate);

            cmd.Parameters.AddWithValue("@end", ToDate);
            cmd.Parameters.AddWithValue("@BillGroup", BillGroup);

            cmd.Parameters.AddWithValue("@PatRegId", PatRegId);
            cmd.Parameters.AddWithValue("@InsuranceId", InsuranceId);
            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.ExecuteNonQuery();

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

    public void InsuranceSummaryForProcedure(string FromDate, string ToDate, int PatRegId,string BillGroup, int InsuranceId, int FId, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        //SqlCommand cmd = new SqlCommand("Sp_Vw_InsuranceSummaryReport", con);
        SqlCommand cmd = new SqlCommand("Sp_Vw_InsuranceSummaryForProcedure", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@start", FromDate);

            cmd.Parameters.AddWithValue("@end", ToDate);
            cmd.Parameters.AddWithValue("@BillGroup", BillGroup);
           
            cmd.Parameters.AddWithValue("@PatRegId", PatRegId);
            cmd.Parameters.AddWithValue("@InsuranceId", InsuranceId);
            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.ExecuteNonQuery();

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
    public void InsuranceSummaryForPharmacy(string FromDate, string ToDate, int PatRegId, string BillGroup, string InsuranceId, int FId, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForPharmacy();
        con.Open();
        //SqlCommand cmd = new SqlCommand("Sp_Vw_InsuranceSummaryReport", con);
        SqlCommand cmd = new SqlCommand("Sp_Vw_InsuranceSummaryForPharmacy", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@start", FromDate);

            cmd.Parameters.AddWithValue("@end", ToDate);
            cmd.Parameters.AddWithValue("@BillGroup", BillGroup);

            cmd.Parameters.AddWithValue("@PatRegId", PatRegId);
            cmd.Parameters.AddWithValue("@InsuranceId", InsuranceId);
            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.ExecuteNonQuery();

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


    public bool Insert_PharmacyInsurance()
    {
        SqlConnection conn = DataAccess.ConInitForPharmacy();
        SqlCommand sc = new SqlCommand();
        sc.CommandType = CommandType.StoredProcedure;
        sc.Connection = conn;
        sc.CommandTimeout = 1200;
        sc.CommandText = "[SP_InsertPharma_Insurance]";


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

    public bool Insert_Trun_PharmacyInsurance()
    {
        SqlConnection conn = DataAccess.ConInitForDC();
        SqlCommand sc = new SqlCommand();
        sc.CommandType = CommandType.StoredProcedure;
        sc.Connection = conn;
        sc.CommandTimeout = 1200;
        sc.CommandText = "[SP_TrunPharma_Insurance]";


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

    public bool Insert_Lab_Insurance()
    {
        SqlConnection conn = DataAccess.ConInitForDC();
        SqlCommand sc = new SqlCommand();
        sc.CommandType = CommandType.StoredProcedure;
        sc.Connection = conn;
        sc.CommandTimeout = 1200;
        sc.CommandText = "[SP_InsertLab_Insurance]";


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
    public void PatientInsuranceDetails_Invoice( int InvoiceNo, int InsuranceId, int FId, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        
        SqlCommand cmd = new SqlCommand("Sp_Vw_PatientInsuranceDetailsForInvoice", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {


            cmd.Parameters.AddWithValue("@InvoiceNo", InvoiceNo);
            cmd.Parameters.AddWithValue("@Sponser", InsuranceId);
            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.ExecuteNonQuery();

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

    public void InsurancePaymentReceipts(int ReceiptNo, int Sponser, int FId, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();

        SqlCommand cmd = new SqlCommand("Sp_Vw_InsurancePaymentReceipt_Rpt", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {


            cmd.Parameters.AddWithValue("@ReceiptNo", ReceiptNo);
            cmd.Parameters.AddWithValue("@Sponser", Sponser);
            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.ExecuteNonQuery();

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

    public void InsurancePaymentLedger(string Startdate,string Enddate, int Sponser, int FId, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();

        SqlCommand cmd = new SqlCommand("Sp_Vw_InsuranceCompTransactionLedger_Rpt", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {


            cmd.Parameters.AddWithValue("@FromDate", Startdate);
            cmd.Parameters.AddWithValue("@ToDate", Enddate);
            cmd.Parameters.AddWithValue("@Sponser", Sponser);
            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.ExecuteNonQuery();

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

    public void GetProcedureCancelBillDetails(int BillNo, int PatRegId,  int FId, int BranchId,string FromDate, string ToDate)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Vw_CancelprocedureBillMaster", con);
        cmd.CommandType = CommandType.StoredProcedure;
       
        cmd.Parameters.AddWithValue("@PatRegId", PatRegId);
         if (FromDate == "")
            {
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            }
            else
            {

                cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            if (ToDate == "")
            {
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            }
            else
            {
                // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
        
        cmd.Parameters.AddWithValue("@FId", FId);
        cmd.Parameters.AddWithValue("@BranchId", BranchId);
        cmd.ExecuteNonQuery();
        con.Close();
        con.Dispose();

    }

    public DataSet CaseReport(int OpdNo, string  PatRegId, int FId, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetVW_OPDCasePaper", con);
       
        cmd.Parameters.AddWithValue("@OpdNo", OpdNo);
        cmd.Parameters.AddWithValue("@PatRegId", PatRegId);
        cmd.Parameters.AddWithValue("@FId", FId);
        cmd.Parameters.AddWithValue("@BranchId", BranchId);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();

        sda.Fill(ds);
        ds.Tables[0].TableName = "VW_OPDCasePaper";

        con.Close();
        con.Dispose();
        return ds;
    }


    public DataSet GetEMR_LabBillDetails( int OpdNo, int PatRegId, int FId, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetEMR_LabBillingReport", con);
        cmd.CommandType = CommandType.StoredProcedure;
        
        cmd.Parameters.AddWithValue("@OpdNo", OpdNo);
        cmd.Parameters.AddWithValue("@PatRegId", PatRegId);
        cmd.Parameters.AddWithValue("@FId", FId);
        cmd.Parameters.AddWithValue("@BranchId", BranchId);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();

        sda.Fill(ds);
        ds.Tables[0].TableName = "Vw_LabBillReport";

        con.Close();
        con.Dispose();
        return ds;
    }

    public DataSet GetEMR_LabBillDetailsInv( int PatRegId, int FId, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetEMR_LabBillingReportInv", con);
        cmd.CommandType = CommandType.StoredProcedure;

        
        cmd.Parameters.AddWithValue("@PatRegId", PatRegId);
        cmd.Parameters.AddWithValue("@FId", FId);
        cmd.Parameters.AddWithValue("@BranchId", BranchId);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();

        sda.Fill(ds);
        ds.Tables[0].TableName = "Vw_LabBillReport";

        con.Close();
        con.Dispose();
        return ds;
    }
    public DataSet fillDeptUserwise(int UserId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_FillUserwiseDept", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@UserId", UserId);
        
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        con.Dispose();
        return ds;

    }

    public string DeleteOpdRegistration(int PatRegId,int OpdNo)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_CancelOpdRegistration", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@PatRegId", PatRegId);
            cmd.Parameters.AddWithValue("@OpdNo", OpdNo);
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


    public void IpdDischrge_Summary_Report(int IpdId, int PatRegId, int FId, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        // SqlCommand cmd = new SqlCommand("Sp_Vw_IPDBillDetailsReport", con);
        SqlCommand cmd = new SqlCommand("Sp_Vw_IPDDischargeSummaryReport", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@IpdId", IpdId);
            cmd.Parameters.AddWithValue("@PatRegId", PatRegId);
            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.ExecuteNonQuery();
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

    public DataSet FillRadiologyBillOutstanding(string FromDate, string ToDate, int PatRegId, string MobileNo, string PaymentStatus, int FId, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetRadiologyPayment", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            if (FromDate == "")
            {
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@FromDate", FromDate);
                // cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture));
            }
            if (ToDate == "")
            {
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            }
            else
            {

                cmd.Parameters.AddWithValue("@ToDate", ToDate);
                // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                // cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
                // cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture));

            }
            cmd.Parameters.AddWithValue("@PatRegId", PatRegId);
            cmd.Parameters.AddWithValue("@MobileNo", MobileNo);
            cmd.Parameters.AddWithValue("@PaymentStatus", PaymentStatus);
            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            ds.Tables[0].TableName = "Vw_OpdOutstandingPayment";
            return ds;

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

    public void UpdatePaymentStatusInTreatment(int Patregid, int LabNo, int BillPaymentId, string PaymentReceivedBy, float ReceivedPayment,string LabType)
    {

       // SqlConnection con = new SqlConnection(constrHMS);
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_UpdateRadiologyPaymeny", con);
        cmd.CommandType = CommandType.StoredProcedure;
        // string Expdate = "1/1/2000";
        try
        {
            cmd.Parameters.AddWithValue("@Patregid", Patregid);
            cmd.Parameters.AddWithValue("@LabNo", LabNo);
            cmd.Parameters.AddWithValue("@BillPaymentId", BillPaymentId);

            cmd.Parameters.AddWithValue("@PaymentReceivedBy", PaymentReceivedBy);
            cmd.Parameters.AddWithValue("@ReceivedPayment", ReceivedPayment);
            cmd.Parameters.AddWithValue("@LabType", LabType);
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

    public void PatientInsuranceDetails_Invoice_OPD(int InvoiceNo, int InsuranceId, int FId, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();

        SqlCommand cmd = new SqlCommand("Sp_PatientInsuranceDetailsForInvoice_OPD", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {


            cmd.Parameters.AddWithValue("@InvoiceNo", InvoiceNo);
            cmd.Parameters.AddWithValue("@Sponser", InsuranceId);
            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.ExecuteNonQuery();

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

    public void InsurancePaymentReceipts_ForOPD(int ReceiptNo, int Sponser, int FId, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();

        SqlCommand cmd = new SqlCommand("Sp_Vw_InsurancePaymentReceipt_OPD", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {


            cmd.Parameters.AddWithValue("@ReceiptNo", ReceiptNo);
            cmd.Parameters.AddWithValue("@Sponser", Sponser);
            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.ExecuteNonQuery();

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

    public void InsurancePaymentReceipts_For_IPD(int ReceiptNo, int Sponser, int FId, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();

        SqlCommand cmd = new SqlCommand("Sp_Vw_InsurancePaymentReceipt_IPD", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {


            cmd.Parameters.AddWithValue("@ReceiptNo", ReceiptNo);
            cmd.Parameters.AddWithValue("@Sponser", Sponser);
            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.ExecuteNonQuery();

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

    public void InsurancePaymentLedger_ForOPD(string Startdate, string Enddate, int Sponser, int FId, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();

        SqlCommand cmd = new SqlCommand("Sp_Vw_InsuranceCompTransactionLedge_ForOPD", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {


            cmd.Parameters.AddWithValue("@FromDate", Startdate);
            cmd.Parameters.AddWithValue("@ToDate", Enddate);
            cmd.Parameters.AddWithValue("@Sponser", Sponser);
            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.ExecuteNonQuery();

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

    public void GetAll_AllInvoicePatient_ForOPD(int InvoiceNo, string FromDate, string ToDate, int GenerateInvoice)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();

        SqlCommand cmd = new SqlCommand("Sp_Vw_AllInvoicePatient_ForOPD", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@FromDate", FromDate);
            cmd.Parameters.AddWithValue("@ToDate", ToDate);
            cmd.Parameters.AddWithValue("@InvoiceNo", InvoiceNo);
            cmd.Parameters.AddWithValue("@GenerateInvoice", GenerateInvoice);
            cmd.CommandTimeout = 5000;
            cmd.ExecuteNonQuery();

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


    public void PatientInsuranceDetails_Invoice_ForOPD(int InvoiceNo, string ChargeNo, int InsuranceId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();

        SqlCommand cmd = new SqlCommand("Sp_Vw_PatientInsuranceDetailsForInvoice_ForOPD_Report", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {


            cmd.Parameters.AddWithValue("@InvoiceNo", InvoiceNo);
            cmd.Parameters.AddWithValue("@ChargeNo", ChargeNo);
            cmd.Parameters.AddWithValue("@InsuranceId", InsuranceId);
            //cmd.Parameters.AddWithValue("@FromDate", FromDate);
            //cmd.Parameters.AddWithValue("@ToDate", ToDate);
           

            cmd.ExecuteNonQuery();

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

    public void InsuranceSummaryForLab_ForChild(string FromDate, string ToDate, int PatRegId, string BillGroup, int InsuranceId, int FId, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        //SqlCommand cmd = new SqlCommand("Sp_Vw_InsuranceSummaryReport", con);
        SqlCommand cmd = new SqlCommand("Sp_Vw_InsuranceSummaryForLAB_Child", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@start", FromDate);

            cmd.Parameters.AddWithValue("@end", ToDate);
            cmd.Parameters.AddWithValue("@BillGroup", BillGroup);

            cmd.Parameters.AddWithValue("@PatRegId", PatRegId);
            cmd.Parameters.AddWithValue("@InsuranceId", InsuranceId);
            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.ExecuteNonQuery();

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

    public void PatientInsuranceDetails_Invoice_ForOPD(int InvoiceNo, int InsuranceId, int FId, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();

        SqlCommand cmd = new SqlCommand("Sp_Vw_PatientInsuranceDetailsForInvoice_ForOPD", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {


            cmd.Parameters.AddWithValue("@InvoiceNo", InvoiceNo);
            cmd.Parameters.AddWithValue("@Sponser", InsuranceId);
            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.ExecuteNonQuery();

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

    public void VW_GenerateChargeNumber(string Patregid)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();

        SqlCommand cmd = new SqlCommand("Sp_VW_GenerateChargeNumber", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {


           
          
            cmd.Parameters.AddWithValue("@Patregid", Patregid);
            cmd.ExecuteNonQuery();

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

    public DataSet GetFrontDesk_Billing(string FromDate, string ToDate, int PatRegId, string MobileNo, string PaymentStatus, int FId, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetFrontDeskPayment", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            if (FromDate == "")
            {
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@FromDate", FromDate);
                // cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture));
            }
            if (ToDate == "")
            {
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            }
            else
            {

                cmd.Parameters.AddWithValue("@ToDate", ToDate);
                // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                // cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
                // cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture));

            }
            cmd.Parameters.AddWithValue("@PatRegId", PatRegId);
            cmd.Parameters.AddWithValue("@MobileNo", MobileNo);
            cmd.Parameters.AddWithValue("@PaymentStatus", PaymentStatus);
            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            ds.Tables[0].TableName = "Vw_OpdOutstandingPayment";
            return ds;

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

    public void UpdateFrontDeskPayment(int Patregid, int ProcedureId, int ProcBillPaymentId, string PaymentReceivedBy, float ReceivedPayment)
    {

        // SqlConnection con = new SqlConnection(constrHMS);
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_UpdateFrontDeskPayment", con);
        cmd.CommandType = CommandType.StoredProcedure;
        // string Expdate = "1/1/2000";
        try
        {
            cmd.Parameters.AddWithValue("@Patregid", Patregid);
            cmd.Parameters.AddWithValue("@ProcedureId", ProcedureId);
            cmd.Parameters.AddWithValue("@ProcBillPaymentId", ProcBillPaymentId);

            cmd.Parameters.AddWithValue("@PaymentReceivedBy", PaymentReceivedBy);
            cmd.Parameters.AddWithValue("@ReceivedPayment", ReceivedPayment);
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

    public string Delete_IPD_LabService(string Patregid, string LabNo, string BillNo, string CancelBy, string LabType)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Delete_IPD_LabService", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@Patregid", Patregid);
            cmd.Parameters.AddWithValue("@LabNo", LabNo);
            cmd.Parameters.AddWithValue("@BillNo", BillNo);

            cmd.Parameters.AddWithValue("@CancelBy", CancelBy);
            cmd.Parameters.AddWithValue("@LabType", LabType);
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

    public void ReadmitDischargePatient(int IpdId, string PatRegId, int FId, int BranchId, string ReadmitBy)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        // SqlCommand cmd = new SqlCommand("Sp_Vw_IPDBillDetailsReport", con);
        SqlCommand cmd = new SqlCommand("SP_ReAdmitDischargePAtient", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@IpdNo", IpdId);
            cmd.Parameters.AddWithValue("@PatRegId", PatRegId);

            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.Parameters.AddWithValue("@ReadmitBy", ReadmitBy);
            cmd.ExecuteNonQuery();
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



    public void PatientInsuranceDetails_Invoice_ForAllOPD(int InsuranceId,string FromDate,string ToDate,int GenerateInvoice)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();

        SqlCommand cmd = new SqlCommand("Sp_Vw_PatientInsuranceDetailsFor_InsuranceCompanyForOPD_Report", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {


            cmd.Parameters.AddWithValue("@InvoiceNo", InsuranceId);
            cmd.Parameters.AddWithValue("@FromDate", FromDate);
            cmd.Parameters.AddWithValue("@ToDate", ToDate);
            cmd.Parameters.AddWithValue("@GenerateInvoice", GenerateInvoice);
            cmd.CommandTimeout = 0;
            cmd.ExecuteNonQuery();

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

    public void IpdPatientRefundList_Report(int RTypeId, int PatRegId, int FId, int BranchId, string start, string end)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        
        SqlCommand cmd = new SqlCommand("usp_Vw_IpdPatientRefundList", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.Parameters.AddWithValue("@PatRegId", PatRegId);
          
            cmd.Parameters.AddWithValue("@RTypeId", RTypeId);

            cmd.Parameters.AddWithValue("@start", start);
            cmd.Parameters.AddWithValue("@end", end);
            cmd.ExecuteNonQuery();
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

    public void IpdPatientDueList_Report(int RTypeId, int PatRegId, int FId, int BranchId, string start, string end)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();

        SqlCommand cmd = new SqlCommand("usp_Vw_IpdPatientDueList", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.Parameters.AddWithValue("@PatRegId", PatRegId);

            cmd.Parameters.AddWithValue("@RTypeId", RTypeId);

            cmd.Parameters.AddWithValue("@start", start);
            cmd.Parameters.AddWithValue("@end", end);
            cmd.ExecuteNonQuery();
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


    public void Ipddischargerecommendation_Report(int RTypeId, int PatRegId, int FId, int BranchId, string start, string end)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();

        SqlCommand cmd = new SqlCommand("usp_Vw_Ipddischargerecommendation", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.Parameters.AddWithValue("@PatRegId", PatRegId);

            cmd.Parameters.AddWithValue("@RTypeId", RTypeId);

            cmd.Parameters.AddWithValue("@start", start);
            cmd.Parameters.AddWithValue("@end", end);
            cmd.ExecuteNonQuery();
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



    public void IpdPatient_InsuranceList_Report(int RTypeId, int PatRegId, int FId, int BranchId, string start, string end, int PatientMainCategoryId, int PatientSubCategoryId,int DueType)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();

        SqlCommand cmd = new SqlCommand("usp_Vw_IpdPatientInsuranceList", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.Parameters.AddWithValue("@PatRegId", PatRegId);

            cmd.Parameters.AddWithValue("@RTypeId", RTypeId);

            cmd.Parameters.AddWithValue("@start", start);
            cmd.Parameters.AddWithValue("@end", end);
            cmd.Parameters.AddWithValue("@PatientMainCategoryId", PatientMainCategoryId);
            cmd.Parameters.AddWithValue("@PatientSubCategoryId", PatientSubCategoryId);
            cmd.Parameters.AddWithValue("@DueType", DueType);
            cmd.ExecuteNonQuery();
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

    public void Get_CancelReport(string FromDate, string ToDate)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Vw_Vw_CancelPatientInformation_Report", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            if (FromDate == "")
            {
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            }
            else
            {

                cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            if (ToDate == "")
            {
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            }
            else
            {
                // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }

           
            cmd.ExecuteNonQuery();


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

    public void Get_OutPatientCharge_AccountReport(string FromDate, string ToDate)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_VW_OutPatientChargeAccount", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            if (FromDate == "")
            {
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            }
            else
            {

                cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            if (ToDate == "")
            {
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            }
            else
            {
                // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }


            cmd.ExecuteNonQuery();


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
    public void Get_DrCensus_AccountReport(string FromDate, string ToDate)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_VW_DrWiseMonthlyCensusReport", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            if (FromDate == "")
            {
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            }
            else
            {

                cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            if (ToDate == "")
            {
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            }
            else
            {
                // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }


            cmd.ExecuteNonQuery();


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
    public void PatientInsuranceDetails_Invoice_ForOPD_Edit(int InvoiceNo, string ChargeNo)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();

        SqlCommand cmd = new SqlCommand("Sp_Vw_PatientInsuranceDetailsForInvoice_ForOPD_Report_Edit", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {


            cmd.Parameters.AddWithValue("@InvoiceNo", InvoiceNo);
            cmd.Parameters.AddWithValue("@ChargeNo", ChargeNo);
           

            cmd.ExecuteNonQuery();

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

    public DataSet Fill_AllInsurancr_Receipt(string FromDate, string ToDate, int InsuranceCompID, int BranchId,  string UserName)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_InsuranceCompPaymentTransactions", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            if (FromDate == "")
            {
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@FromDate", FromDate);
                // cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture));
            }
            if (ToDate == "")
            {
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            }
            else
            {

                cmd.Parameters.AddWithValue("@ToDate", ToDate);
                // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                // cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
                // cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture));

            }
            cmd.Parameters.AddWithValue("@InsuranceCompID", InsuranceCompID);
          
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.Parameters.AddWithValue("@UserName", UserName);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            cmd.CommandTimeout = 5000;
            sda.Fill(ds);
            //ds.Tables[0].TableName = "Vw_LabBillPatientsPayment";
            return ds;

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

    public DataSet Fill_AllInsurancr_ReceiptIPD(string FromDate, string ToDate, int InsuranceCompID, int BranchId, string UserName)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_InsuranceCompPaymentTransactions_IPD", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            if (FromDate == "")
            {
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@FromDate", FromDate);
                // cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture));
            }
            if (ToDate == "")
            {
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            }
            else
            {

                cmd.Parameters.AddWithValue("@ToDate", ToDate);
                // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                // cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
                // cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture));

            }
            cmd.Parameters.AddWithValue("@InsuranceCompID", InsuranceCompID);

            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.Parameters.AddWithValue("@UserName", UserName);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            cmd.CommandTimeout = 5000;
            sda.Fill(ds);
            //ds.Tables[0].TableName = "Vw_LabBillPatientsPayment";
            return ds;

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



    public void InsurancePaymentReceipts_Report(string FromDate, string ToDate,  int Sponser, string  UserName, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();

        SqlCommand cmd = new SqlCommand("Sp_Vw_Insurance_PaymentRec", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            if (FromDate == "")
            {
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@FromDate", FromDate);
            }
            if (ToDate == "")
            {
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@ToDate", ToDate);               
            }

            cmd.Parameters.AddWithValue("@InsuranceCompID", Sponser);           
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.ExecuteNonQuery();

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

  
    public void InsurancePaymentReceipts_Report_IPD(string FromDate, string ToDate, int Sponser, string UserName, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();

        SqlCommand cmd = new SqlCommand("Sp_Vw_Insurance_PaymentRec_IPD", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            if (FromDate == "")
            {
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@FromDate", FromDate);
            }
            if (ToDate == "")
            {
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@ToDate", ToDate);
            }

            cmd.Parameters.AddWithValue("@InsuranceCompID", Sponser);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.ExecuteNonQuery();

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


    public void IpdPatientDueList_Report_MRC(int RTypeId, int PatRegId, int FId, int BranchId, string start, string end)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();

        SqlCommand cmd = new SqlCommand("usp_Vw_IpdPatientDueList_MRC", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.Parameters.AddWithValue("@PatRegId", PatRegId);

            cmd.Parameters.AddWithValue("@RTypeId", RTypeId);

            cmd.Parameters.AddWithValue("@start", start);
            cmd.Parameters.AddWithValue("@end", end);
            cmd.ExecuteNonQuery();
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

    public void IpdPatientDueList_Report_MRC_Final(int RTypeId, int PatRegId, int FId, int BranchId, string start, string end)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();

        SqlCommand cmd = new SqlCommand("usp_Vw_IpdPatientDueList_MRC_Final", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.Parameters.AddWithValue("@PatRegId", PatRegId);

            cmd.Parameters.AddWithValue("@RTypeId", RTypeId);

            cmd.Parameters.AddWithValue("@start", start);
            cmd.Parameters.AddWithValue("@end", end);
            cmd.ExecuteNonQuery();
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

    public void GetAll_AllInvoicePatient_ForIPD(int InvoiceNo, string FromDate, string ToDate, int GenerateInvoice)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();

        SqlCommand cmd = new SqlCommand("Sp_Vw_InsuranceBillAmountTotalFor_IPD", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@FromDate", FromDate);
            cmd.Parameters.AddWithValue("@ToDate", ToDate);
            cmd.Parameters.AddWithValue("@InsuranceId", InvoiceNo);
            cmd.Parameters.AddWithValue("@GenerateInvoice", GenerateInvoice);

            cmd.ExecuteNonQuery();

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

    public void PatientInsuranceDetails_Invoice_ForAllIPD(int InvoiceNo, int InsuranceId, int FId, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();

        SqlCommand cmd = new SqlCommand("Sp_Vw_PatientInsuranceDetailsForInvoice_ForIPD", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {


            cmd.Parameters.AddWithValue("@InvoiceNo", InvoiceNo);
            cmd.Parameters.AddWithValue("@Sponser", InsuranceId);
            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.ExecuteNonQuery();

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

    public DataSet Fill_AllInsurancr_Receipt_IPD(string FromDate, string ToDate, int InsuranceCompID, int BranchId, string UserName)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_InsuranceCompPaymentTransactions_forIPD", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            if (FromDate == "")
            {
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@FromDate", FromDate);
                // cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture));
            }
            if (ToDate == "")
            {
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            }
            else
            {

                cmd.Parameters.AddWithValue("@ToDate", ToDate);
                // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                // cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
                // cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture));

            }
            cmd.Parameters.AddWithValue("@InsuranceCompID", InsuranceCompID);

            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.Parameters.AddWithValue("@UserName", UserName);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            cmd.CommandTimeout = 5000;
            sda.Fill(ds);
            //ds.Tables[0].TableName = "Vw_LabBillPatientsPayment";
            return ds;

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

    public DataSet GetAllPatientFollowUp(string FromDate, string ToDate, int PatRegId, string MobileNo, int FId, int BranchId, int DrId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_FollowUp_RegistrationList", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            if (FromDate == "")
            {
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@FromDate", FromDate);
                // cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture));
            }
            if (ToDate == "")
            {
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            }
            else
            {

                cmd.Parameters.AddWithValue("@ToDate", ToDate);
                // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                // cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
                // cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture));

            }
            cmd.Parameters.AddWithValue("@PatRegId", PatRegId);
            cmd.Parameters.AddWithValue("@MobileNo", MobileNo);
            cmd.Parameters.AddWithValue("@DrId", DrId);
            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            // ds.Tables[0].TableName = "Vw_OpdOutstandingPayment";
            return ds;

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


    public DataSet Fill_CashVoucherr_Receipt(string FromDate, string ToDate, int PayTo,string UserName)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_CashVoucherReceipts_Report", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            if (FromDate == "")
            {
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@FromDate", FromDate);
                // cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture));
            }
            if (ToDate == "")
            {
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            }
            else
            {

                cmd.Parameters.AddWithValue("@ToDate", ToDate);
                // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                // cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
                // cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture));

            }
            cmd.Parameters.AddWithValue("@PayTo", PayTo);

           
            cmd.Parameters.AddWithValue("@UserName", UserName);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            cmd.CommandTimeout = 5000;
            sda.Fill(ds);
            //ds.Tables[0].TableName = "Vw_LabBillPatientsPayment";
            return ds;

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


    public void CashVoucherAllPaymentReceipts_Report(string FromDate, string ToDate, int PayTo, string UserName, int BranchId,int ReceiptNo)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();

        SqlCommand cmd = new SqlCommand("Sp_Vw_CashVoucherAllPaymentReceipts_Report", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            if (FromDate == "")
            {
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@FromDate", FromDate);
            }
            if (ToDate == "")
            {
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@ToDate", ToDate);
            }

            cmd.Parameters.AddWithValue("@PayTo", PayTo);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@ReceiptNo", ReceiptNo);
            cmd.ExecuteNonQuery();

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

    public void CashVoucherAllPaymentReceipts_Report1( int PayTo, string UserName, int BranchId, int ReceiptNo)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();

        SqlCommand cmd = new SqlCommand("Sp_Vw_CashVoucherAllPaymentReceipts_Report_New", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@PayTo", PayTo);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@ReceiptNo", ReceiptNo);
            cmd.ExecuteNonQuery();

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

    public void FillPharmacyIncomeReport_Ledger(string FromDate, string ToDate, string UserName, int PaymentType, string BillGroup, int FId, int BranchId, string BankName)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Vw_ProcedurePaymentTransactionRpt_UserWise_Ledger", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            if (FromDate == "")
            {
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            }
            else
            {

                cmd.Parameters.AddWithValue("@FromDate", Convert.ToDateTime(FromDate));
                // cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            if (ToDate == "")
            {
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            }
            else
            {
                cmd.Parameters.AddWithValue("@ToDate", Convert.ToDateTime(ToDate));
                // cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }

            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@BillGroup", BillGroup);
            cmd.Parameters.AddWithValue("@PaymentType", PaymentType);
            cmd.Parameters.AddWithValue("@BankName", BankName);

            cmd.ExecuteNonQuery();


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

    public void FillProcedureIncomeReport_Ledger(string FromDate, string ToDate, string UserName, int PaymentType, string BillGroup, int FId, int BranchId, string BankName)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Vw_ProcedurePaymentTransactionRpt_UserWise_Ledger", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            if (FromDate == "")
            {
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            }
            else
            {

                cmd.Parameters.AddWithValue("@FromDate", Convert.ToDateTime(FromDate));
                // cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            if (ToDate == "")
            {
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            }
            else
            {
                cmd.Parameters.AddWithValue("@ToDate", Convert.ToDateTime(ToDate));
                // cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }

            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@BillGroup", BillGroup);
            cmd.Parameters.AddWithValue("@PaymentType", PaymentType);
            cmd.Parameters.AddWithValue("@BankName", BankName);

            cmd.ExecuteNonQuery();


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

    public void FillIpdDailyIncomeReport_Ledger(string FromDate, string ToDate, string UserName, int PaymentType, int FId, int BranchId, string BankName)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Vw_IpdBillTransactionReport_Ledger", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            if (FromDate == "")
            {
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            }
            else
            {

                // cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
                cmd.Parameters.AddWithValue("@FromDate", Convert.ToDateTime(FromDate));
            }
            if (ToDate == "")
            {
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            }
            else
            {
                // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                // cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
                cmd.Parameters.AddWithValue("@ToDate", Convert.ToDateTime(ToDate));
            }

            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@PaymentType", PaymentType);
            cmd.Parameters.AddWithValue("@BankName", BankName);
            cmd.ExecuteNonQuery();


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

    public void FillLABIncomeReport_Ledger(string FromDate, string ToDate, string UserName, int PaymentType, string BillGroup, int FId, int BranchId, string BankName)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Vw_LabPaymentTransactionRpt_UserWise_Ledger", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            //if (FromDate == "")
            //{
            //    cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            //}
            //else
            //{

            //    cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            //}
            //if (ToDate == "")
            //{
            //    cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            //}
            //else
            //{
            //    // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
            //    cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            //}
            if (FromDate == "")
            {
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            }
            else
            {

                cmd.Parameters.AddWithValue("@FromDate", Convert.ToDateTime(FromDate));
                // cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            if (ToDate == "")
            {
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            }
            else
            {
                cmd.Parameters.AddWithValue("@ToDate", Convert.ToDateTime(ToDate));
                // cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@BillGroup", BillGroup);
            cmd.Parameters.AddWithValue("@PaymentType", PaymentType);
            cmd.Parameters.AddWithValue("@BankName", BankName);
            cmd.CommandTimeout = 5000;
            cmd.ExecuteNonQuery();


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

    public void GetOTBookReport(string FromDate, string ToDate,  int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_GetOTBookingFormReport", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            if (FromDate == "")
            {
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            }
            else
            {

                cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            if (ToDate == "")
            {
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            }
            else
            {
                // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }

           
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
           

            cmd.ExecuteNonQuery();


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

    public void InsurancePaymentReceipts_ForOPD_All(int ReceiptNo, int Sponser, int FId, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();

        SqlCommand cmd = new SqlCommand("Sp_Vw_InsurancePaymentReceipt_OPD_All", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {


            cmd.Parameters.AddWithValue("@ReceiptNo", ReceiptNo);
            cmd.Parameters.AddWithValue("@Sponser", Sponser);
            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.ExecuteNonQuery();

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

    public void OPD_InsuranceDetailsReport( int Sponser,int Months,int Years, int BranchId,int PType)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();

        SqlCommand cmd = new SqlCommand("Sp_VW_OPDInsurancePatientsDetails", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

           
            cmd.Parameters.AddWithValue("@InsuranceCompID", Sponser);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.Parameters.AddWithValue("@Months", Months);
            cmd.Parameters.AddWithValue("@Years", Years);
            cmd.Parameters.AddWithValue("@PType", PType);
            cmd.ExecuteNonQuery();

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


    public void Get_SuspendedReport(string FromDate, string ToDate)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_SuspendandResumeReport", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            if (FromDate == "")
            {
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            }
            else
            {

                cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            if (ToDate == "")
            {
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            }
            else
            {
                // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }


            cmd.ExecuteNonQuery();


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


    public void Get_ReferalandreferingReport(string FromDate, string ToDate,int ConsultId,int ReferDrId,int ReferalType)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_VW_ReferandReferingReport", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            if (FromDate == "")
            {
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            }
            else
            {

                cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            if (ToDate == "")
            {
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            }
            else
            {
                // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }

            cmd.Parameters.AddWithValue("@ConsultId", ConsultId);
            cmd.Parameters.AddWithValue("@ReferDrId", ReferDrId);
            cmd.Parameters.AddWithValue("@ReferalType", ReferalType);

            cmd.ExecuteNonQuery();


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


    public void VW_GetAllServiceIncome(string FromDate, string ToDate, int FId, int BranchId, string GroupName)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_VW_GetAllServiceIncome", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            if (FromDate == "")
            {
                cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            }
            else
            {

                cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            if (ToDate == "")
            {
                cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

            }
            else
            {
                // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
                cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }

            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.Parameters.AddWithValue("@GroupName", GroupName);
            cmd.ExecuteNonQuery();

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


    public DataTable FillIncomeBillGroup(int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetBillGroupIncome", con);
        cmd.CommandType = CommandType.StoredProcedure;       
       
        cmd.Parameters.AddWithValue("@BranchId", BranchId);

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable ds = new DataTable();
        da.Fill(ds);
        con.Close();
        con.Dispose();
        return ds;

    }

    public DataTable FillGroupwiseIncomeGrid_LAB_Year(string Year, string Month, int FId, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_FillGridGroupWiseIncome_LAB_Year", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@Year", Year);
            cmd.Parameters.AddWithValue("@Month", Month);
            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            return dt;

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

    public void VW_GetAllServiceIncome_Year(string Year, string Month, int FId, int BranchId, string GroupName)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_VW_GetAllServiceIncome_Year", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@Year", Year);
            cmd.Parameters.AddWithValue("@Month", Month);
            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@BranchId", BranchId);
            cmd.Parameters.AddWithValue("@GroupName", GroupName);
            cmd.ExecuteNonQuery();

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