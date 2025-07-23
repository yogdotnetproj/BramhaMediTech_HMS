using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for DALBillInfo
/// </summary>
public class DALBillInfo
{
	public DALBillInfo()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int Insert_OPDDepositTransaction(BELBillInfo objDOPayment)
    {
        object[] Result = new object[10];

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_InsertDepositTransaction_ForOPD", con);
        cmd.CommandType = CommandType.StoredProcedure;


        cmd.Parameters.AddWithValue("@Remark", objDOPayment.Remark);
        cmd.Parameters.AddWithValue("@BillType", objDOPayment.BillType);
        cmd.Parameters.AddWithValue("@PatRegId", objDOPayment.PatRegId);
        cmd.Parameters.AddWithValue("@PaymentMode", objDOPayment.PaymentType);
        cmd.Parameters.AddWithValue("@DepositAmt", objDOPayment.DepositAmount);
        cmd.Parameters.AddWithValue("@CreatedBy", objDOPayment.CreatedBy);
        cmd.Parameters.AddWithValue("@CardChequeNo", objDOPayment.ChequeCardNo);
        if (objDOPayment.ChequeDate != null)
        {
            cmd.Parameters.AddWithValue("@ChequeDate", DateTime.ParseExact(objDOPayment.ChequeDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
        }

        cmd.Parameters.AddWithValue("@BankName", objDOPayment.BankName);
        cmd.Parameters.AddWithValue("@FId", objDOPayment.FId);
        cmd.Parameters.AddWithValue("@BranchId", objDOPayment.BranchId);
        cmd.Parameters.AddWithValue("@flag", objDOPayment.flag);
        cmd.Parameters.Add("@DepositeId", SqlDbType.Int).Direction = ParameterDirection.Output;

        cmd.ExecuteNonQuery();
        int DepositeId = Convert.ToInt32(cmd.Parameters["@DepositeId"].Value);//.ToString();
        con.Close();
        con.Dispose();
        return DepositeId;
    }
    public object[] InsertIPDLABBillTransaction(BELBillInfo objDOPayment)
    {
        object[] Result = new object[10];

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_InsertIPDBillTransactionForIPDLab", con);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@BillNo", objDOPayment.BillNo);
        cmd.Parameters.AddWithValue("@ReceiptNo", objDOPayment.ReceiptNo);
        cmd.Parameters.AddWithValue("@IpdNo", objDOPayment.IpdNo);
        cmd.Parameters.AddWithValue("@OpdNo", objDOPayment.OpdNo);
        cmd.Parameters.AddWithValue("@DrId", objDOPayment.ConsultantDrId);
        cmd.Parameters.AddWithValue("@Remark", objDOPayment.Remark);
        cmd.Parameters.AddWithValue("@BillType", objDOPayment.BillType);
        cmd.Parameters.AddWithValue("@PatRegId", objDOPayment.PatRegId);
        cmd.Parameters.AddWithValue("@PaymentMode", objDOPayment.PaymentType);
        cmd.Parameters.AddWithValue("@ReceivedAmount", objDOPayment.AmountPaid);
        cmd.Parameters.AddWithValue("@BillAmount", objDOPayment.BillAmountWithDisc);
        cmd.Parameters.AddWithValue("@IsIpd", 1);
        cmd.Parameters.AddWithValue("@DiscountAmt", objDOPayment.Discount);
        cmd.Parameters.AddWithValue("@BalanceAmt", objDOPayment.Balance);
        cmd.Parameters.AddWithValue("@ReasonForDiscountId", objDOPayment.ReasonForDiscountId);//("dd/MM/yyyy hh:MM:ss tt")
        cmd.Parameters.AddWithValue("@DiscountGivenById", objDOPayment.DiscountGivenById);
        //cmd.Parameters.AddWithValue("@DiscountGiven", objDOPayment.DiscountGiven);
        cmd.Parameters.AddWithValue("@ReasonForBalanceId", objDOPayment.ReasonForBalanceId);
        cmd.Parameters.AddWithValue("@CreatedBy", objDOPayment.CreatedBy);
        cmd.Parameters.AddWithValue("@CardChequeNo", objDOPayment.ChequeCardNo);
        if (objDOPayment.ChequeDate != null)
        {
            cmd.Parameters.AddWithValue("@ChequeDate", DateTime.ParseExact(objDOPayment.ChequeDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
        }
        //cmd.Parameters.AddWithValue("@ChequeDate", objDOPayment.ChequeDate);
        cmd.Parameters.AddWithValue("@BankName", objDOPayment.BankName);
        cmd.Parameters.AddWithValue("@FId", objDOPayment.FId);

        cmd.Parameters.AddWithValue("@BranchId", objDOPayment.BranchId);
        cmd.Parameters.AddWithValue("@InsuranceCompId", objDOPayment.InsuranceCompId);
        cmd.Parameters.AddWithValue("@InsuranceAmount", objDOPayment.InsuranceAmount);
        cmd.Parameters.AddWithValue("@IsInsurance", objDOPayment.IsInsuranceFlag);
        cmd.Parameters.AddWithValue("@IsDeposit", objDOPayment.IsDeposit);
        cmd.Parameters.AddWithValue("@LabNo", objDOPayment.LabNo);
        cmd.Parameters.Add("@BillPaymentId", SqlDbType.Int);
        cmd.Parameters["@BillPaymentId"].Direction = ParameterDirection.Output;
        cmd.ExecuteNonQuery();
        Result[0] = Convert.ToInt32(cmd.Parameters["@BillPaymentId"].Value);


        con.Close();
        con.Dispose();

        return Result;


    }

    public int GetBillNo_ForIPD(int FId, int IPDNO)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetBillNoForIPD", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@IPDNO", IPDNO);
            object Result = cmd.ExecuteScalar();
            return Convert.ToInt32(Result);

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
    }

    public int GetBillNo_ForLab(int FId, int LabNo)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetBillNoForLab", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@FId", FId);
            cmd.Parameters.AddWithValue("@LabNo", LabNo);
            object Result = cmd.ExecuteScalar();
            return Convert.ToInt32(Result);

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
    }
    public int GetMaxLabReceiptNo(int FId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetMaxLabReceiptNo", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@FId", FId);
            object Result = cmd.ExecuteScalar();
            return Convert.ToInt32(Result);

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
    }
    public DataSet FillDiscountGivenby()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("Sp_DiscountGivenByDrop", con);

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

    public DataSet FillReasonForDiscount()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("Sp_ReasonForDiscountDrop", con);

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

    public object[] InsertBillTransaction(BELBillInfo objDOPayment)
    {
        object[] Result = new object[10];

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_InsertBillTransaction", con);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@BillNo", objDOPayment.BillNo);
        cmd.Parameters.AddWithValue("@ReceiptNo", objDOPayment.ReceiptNo);
        cmd.Parameters.AddWithValue("@OpdNo", objDOPayment.OpdNo);
        cmd.Parameters.AddWithValue("@PatRegId", objDOPayment.PatRegId);
        cmd.Parameters.AddWithValue("@PaymentMode", objDOPayment.PaymentType);
        cmd.Parameters.AddWithValue("@ReceivedAmount",objDOPayment.AmountPaid);
        cmd.Parameters.AddWithValue("@IsOpd", 1);
        cmd.Parameters.AddWithValue("@DiscountAmt",objDOPayment.Discount);
        cmd.Parameters.AddWithValue("@BalanceAmt", objDOPayment.Balance);
        cmd.Parameters.AddWithValue("@ReasonForDiscountId", objDOPayment.ReasonForDiscountId);//("dd/MM/yyyy hh:MM:ss tt")
        cmd.Parameters.AddWithValue("@DiscountGivenById", objDOPayment.DiscountGivenById);
        //cmd.Parameters.AddWithValue("@DiscountGiven", objDOPayment.DiscountGiven);
        cmd.Parameters.AddWithValue("@ReasonForBalanceId", objDOPayment.ReasonForBalanceId);
        cmd.Parameters.AddWithValue("@CreatedBy", objDOPayment.CreatedBy);
        cmd.Parameters.AddWithValue("@CardChequeNo", objDOPayment.ChequeCardNo);
        if (objDOPayment.ChequeDate != null)
        {
            cmd.Parameters.AddWithValue("@ChequeDate", DateTime.ParseExact(objDOPayment.ChequeDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
        }
        //cmd.Parameters.AddWithValue("@ChequeDate", objDOPayment.ChequeDate);
        cmd.Parameters.AddWithValue("@BankName", objDOPayment.BankName);
        cmd.Parameters.AddWithValue("@FId", objDOPayment.FId);
        cmd.Parameters.AddWithValue("@BranchId", objDOPayment.BranchId);
        cmd.Parameters.AddWithValue("@InsuranceCompId", objDOPayment.InsuranceCompId);
        cmd.Parameters.AddWithValue("@InsuranceAmount", objDOPayment.InsuranceAmount);
        cmd.Parameters.AddWithValue("@IsInsurance", objDOPayment.IsInsuranceFlag);       
        cmd.Parameters.Add("@BillPaymentId", SqlDbType.Int);
        cmd.Parameters["@BillPaymentId"].Direction = ParameterDirection.Output;
        cmd.ExecuteNonQuery();
        Result[0] = Convert.ToInt32(cmd.Parameters["@BillPaymentId"].Value);
        con.Close();
        con.Dispose();
        return Result;


    }
    public object[] InsertIPDBillTransaction(BELBillInfo objDOPayment)
    {
        object[] Result = new object[10];

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_InsertIPDBillTransaction", con);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@BillNo", objDOPayment.BillNo);
        cmd.Parameters.AddWithValue("@ReceiptNo", objDOPayment.ReceiptNo);
        cmd.Parameters.AddWithValue("@IpdNo", objDOPayment.IpdNo);
        cmd.Parameters.AddWithValue("@DrId", objDOPayment.ConsultantDrId);
        cmd.Parameters.AddWithValue("@Remark", objDOPayment.Remark);
        cmd.Parameters.AddWithValue("@BillType",objDOPayment.BillType);
        cmd.Parameters.AddWithValue("@PatRegId", objDOPayment.PatRegId);
        cmd.Parameters.AddWithValue("@PaymentMode", objDOPayment.PaymentType);
        cmd.Parameters.AddWithValue("@ReceivedAmount", objDOPayment.AmountPaid);
        cmd.Parameters.AddWithValue("@IsIpd", 1);
        cmd.Parameters.AddWithValue("@DiscountAmt", objDOPayment.Discount);
        cmd.Parameters.AddWithValue("@BalanceAmt", objDOPayment.Balance);
        cmd.Parameters.AddWithValue("@ReasonForDiscountId", objDOPayment.ReasonForDiscountId);//("dd/MM/yyyy hh:MM:ss tt")
        cmd.Parameters.AddWithValue("@DiscountGivenById", objDOPayment.DiscountGivenById);
        //cmd.Parameters.AddWithValue("@DiscountGiven", objDOPayment.DiscountGiven);
        cmd.Parameters.AddWithValue("@ReasonForBalanceId", objDOPayment.ReasonForBalanceId);
        cmd.Parameters.AddWithValue("@CreatedBy", objDOPayment.CreatedBy);
        cmd.Parameters.AddWithValue("@CardChequeNo", objDOPayment.ChequeCardNo);
        if (objDOPayment.ChequeDate != null)
        {
            cmd.Parameters.AddWithValue("@ChequeDate", DateTime.ParseExact(objDOPayment.ChequeDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
        }
        //cmd.Parameters.AddWithValue("@ChequeDate", objDOPayment.ChequeDate);
        cmd.Parameters.AddWithValue("@BankName", objDOPayment.BankName);
        cmd.Parameters.AddWithValue("@FId", objDOPayment.FId);
        cmd.Parameters.AddWithValue("@BranchId", objDOPayment.BranchId);
        cmd.Parameters.AddWithValue("@InsuranceCompId", objDOPayment.InsuranceCompId);
        cmd.Parameters.AddWithValue("@InsuranceAmount", objDOPayment.InsuranceAmount);
        cmd.Parameters.AddWithValue("@IsInsurance", objDOPayment.IsInsuranceFlag);
        cmd.Parameters.AddWithValue("@IsDeposit", objDOPayment.IsDeposit);
        cmd.Parameters.Add("@BillPaymentId", SqlDbType.Int);
        cmd.Parameters["@BillPaymentId"].Direction = ParameterDirection.Output;
        cmd.ExecuteNonQuery();
        Result[0] = Convert.ToInt32(cmd.Parameters["@BillPaymentId"].Value);
        con.Close();
        con.Dispose();
        return Result;


    }

    public object[] InsertIPD_dISCHARGEsLIP(BELBillInfo objDOPayment)
    {
        object[] Result = new object[10];

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_Insert_IPDDischargeSlip", con);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@PatRegId", objDOPayment.PatRegId);
        cmd.Parameters.AddWithValue("@IpdNo", objDOPayment.IpdNo);

        cmd.Parameters.AddWithValue("@Xray", objDOPayment.P_Xray);
        cmd.Parameters.AddWithValue("@kor", objDOPayment.P_kor);
        cmd.Parameters.AddWithValue("@drugs", objDOPayment.P_drugs);
        cmd.Parameters.AddWithValue("@ECG", objDOPayment.P_ECG);
        cmd.Parameters.AddWithValue("@csr", objDOPayment.P_csr);
        cmd.Parameters.AddWithValue("@Lab", objDOPayment.P_Lab);
        cmd.Parameters.AddWithValue("@room", objDOPayment.P_room);
        cmd.Parameters.AddWithValue("@RBS", objDOPayment.P_RBS);
        cmd.Parameters.AddWithValue("@OXYGEN", objDOPayment.P_OXYGEN);
        cmd.Parameters.AddWithValue("@NEBULIZER", objDOPayment.P_NEBULIZER);

        cmd.Parameters.AddWithValue("@XrayB", objDOPayment.P_Xrayb);
        cmd.Parameters.AddWithValue("@korB", objDOPayment.P_korb);
        cmd.Parameters.AddWithValue("@drugsB", objDOPayment.P_drugsb);
        cmd.Parameters.AddWithValue("@ECGB", objDOPayment.P_ECGb);
        cmd.Parameters.AddWithValue("@csrB", objDOPayment.P_csrb);
        cmd.Parameters.AddWithValue("@LabB", objDOPayment.P_Labb);
        cmd.Parameters.AddWithValue("@roomB", objDOPayment.P_roomb);
        cmd.Parameters.AddWithValue("@RBSB", objDOPayment.P_RBSb);
        cmd.Parameters.AddWithValue("@OXYGENB", objDOPayment.P_OXYGENb);
        cmd.Parameters.AddWithValue("@NEBULIZERB", objDOPayment.P_NEBULIZERb);

        cmd.Parameters.AddWithValue("@CreatedBy", objDOPayment.CreatedBy);      
        cmd.Parameters.AddWithValue("@Remark", objDOPayment.Remark);
        cmd.Parameters.AddWithValue("@Authority", objDOPayment.Authority);
       
      
        cmd.Parameters.AddWithValue("@BranchId", objDOPayment.BranchId);
       
        cmd.Parameters.Add("@BillPaymentId", SqlDbType.Int);
        cmd.Parameters["@BillPaymentId"].Direction = ParameterDirection.Output;
        cmd.ExecuteNonQuery();
        Result[0] = Convert.ToInt32(cmd.Parameters["@BillPaymentId"].Value);
        con.Close();
        con.Dispose();
        return Result;


    }

    public object[] Insert_MRC_IPDBillTransaction(BELBillInfo objDOPayment)
    {
        object[] Result = new object[10];

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_MRCInsertIPDBillTransaction", con);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@BillNo", objDOPayment.BillNo);
        cmd.Parameters.AddWithValue("@ReceiptNo", objDOPayment.ReceiptNo);
        cmd.Parameters.AddWithValue("@IpdNo", objDOPayment.IpdNo);
        cmd.Parameters.AddWithValue("@DrId", objDOPayment.ConsultantDrId);
        cmd.Parameters.AddWithValue("@Remark", objDOPayment.Remark);
        cmd.Parameters.AddWithValue("@BillType", objDOPayment.BillType);
        cmd.Parameters.AddWithValue("@PatRegId", objDOPayment.PatRegId);
        cmd.Parameters.AddWithValue("@PaymentMode", objDOPayment.PaymentType);
        cmd.Parameters.AddWithValue("@ReceivedAmount", objDOPayment.AmountPaid);
        cmd.Parameters.AddWithValue("@IsIpd", 1);
        cmd.Parameters.AddWithValue("@DiscountAmt", objDOPayment.Discount);
        cmd.Parameters.AddWithValue("@BalanceAmt", objDOPayment.Balance);
        cmd.Parameters.AddWithValue("@ReasonForDiscountId", objDOPayment.ReasonForDiscountId);//("dd/MM/yyyy hh:MM:ss tt")
        cmd.Parameters.AddWithValue("@DiscountGivenById", objDOPayment.DiscountGivenById);
        //cmd.Parameters.AddWithValue("@DiscountGiven", objDOPayment.DiscountGiven);
        cmd.Parameters.AddWithValue("@ReasonForBalanceId", objDOPayment.ReasonForBalanceId);
        cmd.Parameters.AddWithValue("@CreatedBy", objDOPayment.CreatedBy);
        cmd.Parameters.AddWithValue("@CardChequeNo", objDOPayment.ChequeCardNo);
        if (objDOPayment.ChequeDate != null)
        {
            cmd.Parameters.AddWithValue("@ChequeDate", DateTime.ParseExact(objDOPayment.ChequeDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
        }
        //cmd.Parameters.AddWithValue("@ChequeDate", objDOPayment.ChequeDate);
        cmd.Parameters.AddWithValue("@BankName", objDOPayment.BankName);
        cmd.Parameters.AddWithValue("@FId", objDOPayment.FId);
        cmd.Parameters.AddWithValue("@BranchId", objDOPayment.BranchId);
        cmd.Parameters.AddWithValue("@InsuranceCompId", objDOPayment.InsuranceCompId);
        cmd.Parameters.AddWithValue("@InsuranceAmount", objDOPayment.InsuranceAmount);
        cmd.Parameters.AddWithValue("@IsInsurance", objDOPayment.IsInsuranceFlag);
        cmd.Parameters.AddWithValue("@IsDeposit", objDOPayment.IsDeposit);
        cmd.Parameters.Add("@BillPaymentId", SqlDbType.Int);
        cmd.Parameters["@BillPaymentId"].Direction = ParameterDirection.Output;
        cmd.ExecuteNonQuery();
        Result[0] = Convert.ToInt32(cmd.Parameters["@BillPaymentId"].Value);
        con.Close();
        con.Dispose();
        return Result;


    }

    public string UpdateRadiologyPatient_Details(BELBillInfo objDOPayment)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_Update_RadiologyLabRegistration_Transaction", con);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@BillNo", objDOPayment.BillNo);
       
        cmd.Parameters.AddWithValue("@PatRegId", objDOPayment.PatRegId);
        cmd.Parameters.AddWithValue("@PaymentMode", objDOPayment.PaymentType);
        //==========================
        cmd.Parameters.AddWithValue("@DiscountAmt", objDOPayment.Discount);
        cmd.Parameters.AddWithValue("@BalanceAmt", objDOPayment.Balance);
        cmd.Parameters.AddWithValue("@ReasonForDiscountId", objDOPayment.ReasonForDiscountId);//("dd/MM/yyyy hh:MM:ss tt")
        cmd.Parameters.AddWithValue("@DiscountGivenById", objDOPayment.DiscountGivenById);
        //cmd.Parameters.AddWithValue("@DiscountGiven", objDOPayment.DiscountGiven);
        cmd.Parameters.AddWithValue("@ReasonForBalanceId", objDOPayment.ReasonForBalanceId);
       
        cmd.Parameters.AddWithValue("@CardChequeNo", objDOPayment.ChequeCardNo);
        if (objDOPayment.ChequeDate != null)
        {
            cmd.Parameters.AddWithValue("@ChequeDate", DateTime.ParseExact(objDOPayment.ChequeDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
        }
        //cmd.Parameters.AddWithValue("@ChequeDate", objDOPayment.ChequeDate);
        cmd.Parameters.AddWithValue("@BankName", objDOPayment.BankName);
        cmd.Parameters.AddWithValue("@FId", objDOPayment.FId);
        cmd.Parameters.AddWithValue("@BranchId", objDOPayment.BranchId);
        cmd.Parameters.AddWithValue("@InsuranceCompId", objDOPayment.InsuranceCompId);
        cmd.Parameters.AddWithValue("@InsuranceAmount", objDOPayment.InsuranceAmount);
        cmd.Parameters.AddWithValue("@IsInsurance", objDOPayment.IsInsuranceFlag);
       
        cmd.Parameters.AddWithValue("@LabNo", objDOPayment.LabNo);




        object Result = cmd.ExecuteScalar();
        con.Close();
        con.Dispose();
        return Convert.ToString(Result);
    }


    public object[] InsertLabBillTransaction(BELBillInfo objDOPayment)
    {
        object[] Result = new object[10];

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_InsertLabBillTransaction", con);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@BillNo", objDOPayment.BillNo);
        cmd.Parameters.AddWithValue("@ReceiptNo", objDOPayment.ReceiptNo);
        cmd.Parameters.AddWithValue("@IpdNo", objDOPayment.IpdNo);
        cmd.Parameters.AddWithValue("@DrId", objDOPayment.ConsultantDrId);
        cmd.Parameters.AddWithValue("@Remark", objDOPayment.Remark);
        cmd.Parameters.AddWithValue("@BillType", objDOPayment.BillType);
        cmd.Parameters.AddWithValue("@PatRegId", objDOPayment.PatRegId);
        cmd.Parameters.AddWithValue("@PaymentMode", objDOPayment.PaymentType);
        cmd.Parameters.AddWithValue("@ReceivedAmount", objDOPayment.AmountPaid);
        cmd.Parameters.AddWithValue("@IsIpd", 1);
        cmd.Parameters.AddWithValue("@DiscountAmt", objDOPayment.Discount);
        cmd.Parameters.AddWithValue("@BalanceAmt", objDOPayment.Balance);
        cmd.Parameters.AddWithValue("@ReasonForDiscountId", objDOPayment.ReasonForDiscountId);//("dd/MM/yyyy hh:MM:ss tt")
        cmd.Parameters.AddWithValue("@DiscountGivenById", objDOPayment.DiscountGivenById);
        //cmd.Parameters.AddWithValue("@DiscountGiven", objDOPayment.DiscountGiven);
        cmd.Parameters.AddWithValue("@ReasonForBalanceId", objDOPayment.ReasonForBalanceId);
        cmd.Parameters.AddWithValue("@CreatedBy", objDOPayment.CreatedBy);
        cmd.Parameters.AddWithValue("@CardChequeNo", objDOPayment.ChequeCardNo);
        if (objDOPayment.ChequeDate != null)
        {
            cmd.Parameters.AddWithValue("@ChequeDate", DateTime.ParseExact(objDOPayment.ChequeDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
        }
        //cmd.Parameters.AddWithValue("@ChequeDate", objDOPayment.ChequeDate);
        cmd.Parameters.AddWithValue("@BankName", objDOPayment.BankName);
        cmd.Parameters.AddWithValue("@FId", objDOPayment.FId);
        cmd.Parameters.AddWithValue("@BranchId", objDOPayment.BranchId);
        cmd.Parameters.AddWithValue("@InsuranceCompId", objDOPayment.InsuranceCompId);
        cmd.Parameters.AddWithValue("@PatientType", objDOPayment.PatientTypeId);
        cmd.Parameters.AddWithValue("@InsuranceAmount", objDOPayment.InsuranceAmount);
        cmd.Parameters.AddWithValue("@IsInsurance", objDOPayment.IsInsuranceFlag);
        cmd.Parameters.AddWithValue("@IsDeposit", objDOPayment.IsDeposit);
        cmd.Parameters.AddWithValue("@LabNo", objDOPayment.LabNo);
        cmd.Parameters.AddWithValue("@BillAmount", objDOPayment.BillAmount);

        cmd.Parameters.AddWithValue("@PatientInsuChargeId", objDOPayment.PatientInsuChargeId);
        cmd.Parameters.AddWithValue("@LetterNo", objDOPayment.LetterNo);
        cmd.Parameters.AddWithValue("@ChildCompName", objDOPayment.ChildCompName);

        cmd.Parameters.Add("@BillPaymentId", SqlDbType.Int);



        cmd.Parameters["@BillPaymentId"].Direction = ParameterDirection.Output;
        cmd.ExecuteNonQuery();
        Result[0] = Convert.ToInt32(cmd.Parameters["@BillPaymentId"].Value);
        con.Close();
        con.Dispose();
        return Result;


    }


    public object[] InsertLabBillTransaction_Radio(BELBillInfo objDOPayment)
    {
        object[] Result = new object[10];

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_InsertLabBillTransaction_Radio", con);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@BillNo", objDOPayment.BillNo);
        cmd.Parameters.AddWithValue("@ReceiptNo", objDOPayment.ReceiptNo);
        cmd.Parameters.AddWithValue("@IpdNo", objDOPayment.IpdNo);
        cmd.Parameters.AddWithValue("@DrId", objDOPayment.ConsultantDrId);
        cmd.Parameters.AddWithValue("@Remark", objDOPayment.Remark);
        cmd.Parameters.AddWithValue("@BillType", objDOPayment.BillType);
        cmd.Parameters.AddWithValue("@PatRegId", objDOPayment.PatRegId);
        cmd.Parameters.AddWithValue("@PaymentMode", objDOPayment.PaymentType);
        cmd.Parameters.AddWithValue("@ReceivedAmount", objDOPayment.AmountPaid);
        cmd.Parameters.AddWithValue("@IsIpd", 1);
        cmd.Parameters.AddWithValue("@DiscountAmt", objDOPayment.Discount);
        cmd.Parameters.AddWithValue("@BalanceAmt", objDOPayment.Balance);
        cmd.Parameters.AddWithValue("@ReasonForDiscountId", objDOPayment.ReasonForDiscountId);//("dd/MM/yyyy hh:MM:ss tt")
        cmd.Parameters.AddWithValue("@DiscountGivenById", objDOPayment.DiscountGivenById);
        //cmd.Parameters.AddWithValue("@DiscountGiven", objDOPayment.DiscountGiven);
        cmd.Parameters.AddWithValue("@ReasonForBalanceId", objDOPayment.ReasonForBalanceId);
        cmd.Parameters.AddWithValue("@CreatedBy", objDOPayment.CreatedBy);
        cmd.Parameters.AddWithValue("@CardChequeNo", objDOPayment.ChequeCardNo);
        if (objDOPayment.ChequeDate != null)
        {
            cmd.Parameters.AddWithValue("@ChequeDate", DateTime.ParseExact(objDOPayment.ChequeDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
        }
        //cmd.Parameters.AddWithValue("@ChequeDate", objDOPayment.ChequeDate);
        cmd.Parameters.AddWithValue("@BankName", objDOPayment.BankName);
        cmd.Parameters.AddWithValue("@FId", objDOPayment.FId);
        cmd.Parameters.AddWithValue("@BranchId", objDOPayment.BranchId);
        cmd.Parameters.AddWithValue("@PatientType", objDOPayment.PatientTypeId);
        cmd.Parameters.AddWithValue("@InsuranceCompId", objDOPayment.InsuranceCompId);
        cmd.Parameters.AddWithValue("@InsuranceAmount", objDOPayment.InsuranceAmount);
        cmd.Parameters.AddWithValue("@IsInsurance", objDOPayment.IsInsuranceFlag);
        cmd.Parameters.AddWithValue("@IsDeposit", objDOPayment.IsDeposit);
        cmd.Parameters.AddWithValue("@LabNo", objDOPayment.LabNo);
        cmd.Parameters.AddWithValue("@BillAmount", objDOPayment.BillAmount);

        cmd.Parameters.AddWithValue("@PatientInsuChargeId", objDOPayment.PatientInsuChargeId);
        cmd.Parameters.AddWithValue("@LetterNo", objDOPayment.LetterNo);
        cmd.Parameters.AddWithValue("@ChildCompName", objDOPayment.ChildCompName);

        cmd.Parameters.Add("@BillPaymentId", SqlDbType.Int);
        cmd.Parameters["@BillPaymentId"].Direction = ParameterDirection.Output;
        cmd.ExecuteNonQuery();
        Result[0] = Convert.ToInt32(cmd.Parameters["@BillPaymentId"].Value);
        con.Close();
        con.Dispose();
        return Result;


    }
  
  
    public DataSet FillReasonForBalance()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("Sp_ReasonForBalanceDrop", con);

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
    public DataTable GetIpdReceiptNo(int PatRegId,int FId, int IpdNo, int BillNo)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetIpdReceiptNo", con);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@PatRegId", PatRegId);
        cmd.Parameters.AddWithValue("@IpdNo", IpdNo);
        cmd.Parameters.AddWithValue("@BillNo", BillNo);
        cmd.Parameters.AddWithValue("@FId", FId);
       

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable ds = new DataTable();
        da.Fill(ds);
        con.Close();
        con.Dispose();
        return ds;



    }


    public DataSet FillModeOfPayment()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("SP_ModeOfPayment_FillGrid", con);

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
    

     public DataSet FillServiceNameDocWise(int BillGroupId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_BillServiceFillCombo_IsDocwise", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@BillGroupId", BillGroupId);

        SqlDataAdapter da = new SqlDataAdapter(cmd);

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


    public DataSet FillServiceName(int BillGroupId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_BillServiceFillCombo_ByBillGroupId", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@BillGroupId", BillGroupId);

        SqlDataAdapter da = new SqlDataAdapter(cmd);

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

    public int GetMaxReceiptNo(int FId)
    {
        SqlConnection con =DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetMaxReceiptNo",con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@FId", FId);
            object Result = cmd.ExecuteScalar();
            return Convert.ToInt32(Result);

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
    }
    public int GetMaxIpdReceiptNo(int FId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetMaxIpdReceiptNo", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@FId", FId);
            object Result = cmd.ExecuteScalar();
            return Convert.ToInt32(Result);

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
    }
    public int GetMaxBillNo(int FId)
    {
        SqlConnection con =DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetMaxBillNo",con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@FId", FId);
            object Result = cmd.ExecuteScalar();
            return Convert.ToInt32(Result);

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
    }

    public object[] InsertIPDBillTransaction_BillCancel(BELBillInfo objDOPayment)
    {
        object[] Result = new object[10];

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_CancelAdmissiondetails", con);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@BillNo", objDOPayment.BillNo);
      
        cmd.Parameters.AddWithValue("@IpdNo", objDOPayment.IpdNo);
       
        cmd.Parameters.AddWithValue("@PatRegId", objDOPayment.PatRegId);
    
        cmd.Parameters.AddWithValue("@FId", objDOPayment.FId);
        cmd.Parameters.AddWithValue("@BranchId", objDOPayment.BranchId);
        
       // cmd.Parameters["@BillPaymentId"].Direction = ParameterDirection.Output;
        cmd.ExecuteNonQuery();
       // Result[0] = Convert.ToInt32(cmd.Parameters["@BillPaymentId"].Value);
        con.Close();
        con.Dispose();
        return Result;


    }

    public int GetMaxIpdReceiptNo_ForRef(int FId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_GetMaxIpdReceiptNo_ForRefund", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@FId", FId);
            object Result = cmd.ExecuteScalar();
            return Convert.ToInt32(Result);

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
    }
    public BELBillInfo SelectDeposit(int DepositId)
    {
        BELBillInfo obj = new BELBillInfo();
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_SelectDeposit", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@DepositId", DepositId);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                obj.DepositAmount = Convert.ToDecimal(sdr["DepositAmt"]);
                obj.BillType = Convert.ToString(sdr["Type"]);
                obj.Remark = Convert.ToString(sdr["Remark"]);
                obj.PaymentId = Convert.ToInt32(sdr["PaymentMode"]);
                obj.BankName = Convert.ToString(sdr["BankName"]);
                obj.ChequeCardNo = Convert.ToString(sdr["ChequeNo"]);
                obj.ChequeDate = Convert.ToString(sdr["ChequeDate"]);
            }
            return obj;
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
    }
    public void DeleteDeposite(int DepositId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_DeleteDeposit", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@DepositId", DepositId);
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
    }

    public void UpdateDepositTransaction(BELBillInfo objDOPayment)
    {


        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_UpdateDepositTransaction", con);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@DepositId", objDOPayment.DepositId);
        cmd.Parameters.AddWithValue("@Remark", objDOPayment.Remark);
        cmd.Parameters.AddWithValue("@BillType", objDOPayment.BillType);
        // cmd.Parameters.AddWithValue("@PatRegId", objDOPayment.PatRegId);
        cmd.Parameters.AddWithValue("@PaymentMode", objDOPayment.PaymentType);
        cmd.Parameters.AddWithValue("@DepositAmt", objDOPayment.DepositAmount);
        cmd.Parameters.AddWithValue("@UpdatedBy", objDOPayment.UpdatedBy);
        cmd.Parameters.AddWithValue("@CardChequeNo", objDOPayment.ChequeCardNo);
        if (objDOPayment.ChequeDate != null)
        {
            cmd.Parameters.AddWithValue("@ChequeDate", DateTime.ParseExact(objDOPayment.ChequeDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
        }

        cmd.Parameters.AddWithValue("@BankName", objDOPayment.BankName);

        cmd.ExecuteNonQuery();

        con.Close();
        con.Dispose();



    }

    public int InsertDepositTransaction(BELBillInfo objDOPayment)
    {
        object[] Result = new object[10];

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_InsertDepositTransaction", con);
        cmd.CommandType = CommandType.StoredProcedure;


        cmd.Parameters.AddWithValue("@Remark", objDOPayment.Remark);
        cmd.Parameters.AddWithValue("@BillType", objDOPayment.BillType);
        cmd.Parameters.AddWithValue("@PatRegId", objDOPayment.PatRegId);
        cmd.Parameters.AddWithValue("@PaymentMode", objDOPayment.PaymentType);
        cmd.Parameters.AddWithValue("@DepositAmt", objDOPayment.DepositAmount);
        cmd.Parameters.AddWithValue("@CreatedBy", objDOPayment.CreatedBy);
        cmd.Parameters.AddWithValue("@CardChequeNo", objDOPayment.ChequeCardNo);
        if (objDOPayment.ChequeDate != null)
        {
            cmd.Parameters.AddWithValue("@ChequeDate", DateTime.ParseExact(objDOPayment.ChequeDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
        }

        cmd.Parameters.AddWithValue("@BankName", objDOPayment.BankName);
        cmd.Parameters.AddWithValue("@FId", objDOPayment.FId);
        cmd.Parameters.AddWithValue("@BranchId", objDOPayment.BranchId);
        cmd.Parameters.AddWithValue("@flag", objDOPayment.flag);
        cmd.Parameters.Add("@DepositeId", SqlDbType.Int).Direction = ParameterDirection.Output;

        cmd.ExecuteNonQuery();
        int DepositeId = Convert.ToInt32(cmd.Parameters["@DepositeId"].Value);//.ToString();
        con.Close();
        con.Dispose();
        return DepositeId;
    }


    public DataSet FillDepositGrid(int PatRegId, int FId, int BranchId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_FillDepositGrid", con);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@PatRegId", PatRegId);
        cmd.Parameters.AddWithValue("@FId", FId);
        cmd.Parameters.AddWithValue("@BranchId", BranchId);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
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
    public List<string> FillGroupWiseService(string prefixtext, int GroupId)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_FillGroupWiseIPDBillServices", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@BillGroupId", GroupId);
            cmd.Parameters.AddWithValue("@Search", prefixtext);
            List<string> PatientName = new List<string>();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                PatientName.Add(sdr["ServiceName"].ToString());

            }
            return PatientName;
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

    public List<string> FillGroupWiseService_Procedure(string prefixtext,string GroupName)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_FillGroupWiseIPDBillServices_Procedure", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@BillGroupName", GroupName);
            cmd.Parameters.AddWithValue("@Search", prefixtext);
            List<string> PatientName = new List<string>();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                PatientName.Add(sdr["ServiceName"].ToString());

            }
            return PatientName;
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

    public DataTable FillDiagnososAndProcedure(int PatRegId, int FId, int BranchId, int IPDNO)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_FillDiagnosisandprocedure", con);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@PatRegId", PatRegId);
        cmd.Parameters.AddWithValue("@FId", FId);
        cmd.Parameters.AddWithValue("@BranchId", BranchId);
        cmd.Parameters.AddWithValue("@IPDNO", IPDNO);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
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
            con.Close();
            con.Dispose();
        }
        return ds;
    }

    public void InsertIPDBDischargeSummary(BELBillInfo objDOPayment)
    {


        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_InsertupdateIPDDischargeSummary", con);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@PatRegId", objDOPayment.PatRegId);
        cmd.Parameters.AddWithValue("@BillNo", objDOPayment.BillNo);
        cmd.Parameters.AddWithValue("@IpdNo", objDOPayment.IpdNo);
        cmd.Parameters.AddWithValue("@CreatedBy", objDOPayment.CreatedBy);
        cmd.Parameters.AddWithValue("@FId", objDOPayment.FId);
        cmd.Parameters.AddWithValue("@BranchId", objDOPayment.BranchId);


        cmd.Parameters.AddWithValue("@ProcedureD", objDOPayment.P_Procedure);
        cmd.Parameters.AddWithValue("@ProvDiag", objDOPayment.P_ProvDiag);
        cmd.Parameters.AddWithValue("@Complant", objDOPayment.P_Complant);

        cmd.Parameters.AddWithValue("@CaseSummary", objDOPayment.P_CaseSummary);
        cmd.Parameters.AddWithValue("@FinalDiagnosis", objDOPayment.P_FinalDiagnosis);
        cmd.Parameters.AddWithValue("@Surgan", objDOPayment.P_Surgan);
        cmd.Parameters.AddWithValue("@OTNote", objDOPayment.P_OTNote);
        cmd.Parameters.AddWithValue("@Anesthesia", objDOPayment.P_Anesthesia);
        cmd.Parameters.AddWithValue("@Anesthetist", objDOPayment.P_Anesthetist);
        cmd.Parameters.AddWithValue("@OnAdmissionDet", objDOPayment.P_OnAdmissionDet);//("dd/MM/yyyy hh:MM:ss tt")
        cmd.Parameters.AddWithValue("@Treatment", objDOPayment.P_Treatment);
        //cmd.Parameters.AddWithValue("@DiscountGiven", objDOPayment.DiscountGiven);
        cmd.Parameters.AddWithValue("@ConDischarge", objDOPayment.P_ConDischarge);

        cmd.Parameters.AddWithValue("@ReasonDischarge", objDOPayment.P_ReasonDischarge);
        if (objDOPayment.P_ProcedureDate != null)
        {
            cmd.Parameters.AddWithValue("@ProcedureDate", DateTime.ParseExact(objDOPayment.P_ProcedureDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
        }

        cmd.Parameters.AddWithValue("@OperationNote", objDOPayment.P_OperationNote);

        cmd.Parameters.AddWithValue("@NextFollowUp", objDOPayment.P_NextFollowUp);
        cmd.Parameters.AddWithValue("@TreatmentAdvice", objDOPayment.P_TreatmentAdvice);
        cmd.Parameters.AddWithValue("@GeneralRemark", objDOPayment.P_GeneralRemark);


        cmd.ExecuteNonQuery();
        con.Close();
        con.Dispose();


    }

    public DataTable Get_DischargeMedication(int PatRegId, int BranchId, int IPDNO)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_IpdPatient_DischargeMedication", con);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@PatRegId", PatRegId);        
        cmd.Parameters.AddWithValue("@BranchId", BranchId);
        cmd.Parameters.AddWithValue("@IPDNO", IPDNO);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
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
            con.Close();
            con.Dispose();
        }
        return ds;
    }

    public void InsertIPD_Admissionsheet(BELBillInfo objDOPayment)
    {


        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_InsertupdateOnIPD_AdmissionDetails", con);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@PatRegId", objDOPayment.PatRegId);
        cmd.Parameters.AddWithValue("@BillNo", objDOPayment.BillNo);
        cmd.Parameters.AddWithValue("@IpdNo", objDOPayment.IpdNo);
        cmd.Parameters.AddWithValue("@CreatedBy", objDOPayment.CreatedBy);
        cmd.Parameters.AddWithValue("@FId", objDOPayment.FId);
        cmd.Parameters.AddWithValue("@BranchId", objDOPayment.BranchId);

       
        cmd.Parameters.AddWithValue("@IPD_Complaints", objDOPayment.P_IPD_Complaints);
        cmd.Parameters.AddWithValue("@IPD_AdmisDetails", objDOPayment.P_IPD_OnAdmisDetails);
        cmd.Parameters.AddWithValue("@IPD_CaseSummary", objDOPayment.P_IPD_CaseSummary);

        cmd.Parameters.AddWithValue("@IPD_ProvDiagnosis", objDOPayment.P_IPD_ProvDiagnosis);
        cmd.Parameters.AddWithValue("@IPD_FinalDiagnosis", objDOPayment.P_IPD_FinalDiagnosis);
        cmd.Parameters.AddWithValue("@IPD_History", objDOPayment.P_IPD_History);
        cmd.Parameters.AddWithValue("@IPD_Temp", objDOPayment.P_IPD_Temp);
        cmd.Parameters.AddWithValue("@IPD_Resp", objDOPayment.P_IPD_Resp);
        cmd.Parameters.AddWithValue("@IPD_Height", objDOPayment.P_IPD_Height);
        cmd.Parameters.AddWithValue("@IPD_pulse", objDOPayment.P_IPD_pulse);//("dd/MM/yyyy hh:MM:ss tt")
        cmd.Parameters.AddWithValue("@IPD_BP", objDOPayment.P_IPD_BP);

        cmd.Parameters.AddWithValue("@IPD_weight", objDOPayment.P_IPD_weight);

        cmd.Parameters.AddWithValue("@IPD_Albumin", objDOPayment.P_IPD_Albumin);

        cmd.Parameters.AddWithValue("@IPD_sugar", objDOPayment.P_IPD_sugar);
        cmd.Parameters.AddWithValue("@IPD_Blood", objDOPayment.P_IPD_Blood);
        //-------------------------------
        cmd.Parameters.AddWithValue("@foodpreferences", objDOPayment.P_foodpreferences);
        cmd.Parameters.AddWithValue("@Describe", objDOPayment.P_Describe);
        cmd.Parameters.AddWithValue("@BpType", objDOPayment.P_BpType);
        cmd.Parameters.AddWithValue("@lastpoIntake", objDOPayment.P_lastpoIntake);
        if (objDOPayment.P_lastpodateintake == Date.getMinDate())
            cmd.Parameters.AddWithValue("@lastpodateintake", DBNull.Value);
        else
            cmd.Parameters.AddWithValue("@lastpodateintake", objDOPayment.P_lastpodateintake);

      //  cmd.Parameters.AddWithValue("@lastpodateintake", objDOPayment.P_lastpodateintake);
        cmd.Parameters.AddWithValue("@lasttimepointak", objDOPayment.P_lasttimepointak);
        if (objDOPayment.P_lastvoidedurinedate == Date.getMinDate())
            cmd.Parameters.AddWithValue("@lastvoidedurinedate", DBNull.Value);
        else
            cmd.Parameters.AddWithValue("@lastvoidedurinedate", objDOPayment.P_lastvoidedurinedate);
       // cmd.Parameters.AddWithValue("@lastvoidedurinedate", objDOPayment.P_lastvoidedurinedate);

        cmd.Parameters.AddWithValue("@lastvoidedurinetime", objDOPayment.P_lastvoidedurinetime);
        if (objDOPayment.P_lastbowelmovementdate == Date.getMinDate())
            cmd.Parameters.AddWithValue("@lastbowelmovementdate", DBNull.Value);
        else
            cmd.Parameters.AddWithValue("@lastbowelmovementdate", objDOPayment.P_lastbowelmovementdate);
        //cmd.Parameters.AddWithValue("@lastbowelmovementdate", objDOPayment.P_lastbowelmovementdate);

        cmd.Parameters.AddWithValue("@lastbowelmovementtime", objDOPayment.P_lastbowelmovementtime);
        cmd.Parameters.AddWithValue("@Vision", objDOPayment.P_Vision);
        cmd.Parameters.AddWithValue("@Hearing", objDOPayment.P_Hearing);
        cmd.Parameters.AddWithValue("@Speech", objDOPayment.P_Speech);
        cmd.Parameters.AddWithValue("@Ambulation", objDOPayment.P_Ambulation);
        cmd.Parameters.AddWithValue("@Declaration", objDOPayment.P_Declaration);
        cmd.Parameters.AddWithValue("@RelativeName", objDOPayment.P_RelativeName);
        if (objDOPayment.P_RelativeDate == Date.getMinDate())
            cmd.Parameters.AddWithValue("@RelativeDate", DBNull.Value);
        else
            cmd.Parameters.AddWithValue("@RelativeDate", objDOPayment.P_RelativeDate);
       // cmd.Parameters.AddWithValue("@RelativeDate", objDOPayment.P_RelativeDate);
        cmd.Parameters.AddWithValue("@WitnessName", objDOPayment.P_WitnessName);
        //cmd.Parameters.AddWithValue("@WitnessDate", objDOPayment.P_WitnessDate);
        if (objDOPayment.P_WitnessDate == Date.getMinDate())
            cmd.Parameters.AddWithValue("@WitnessDate", DBNull.Value);
        else
            cmd.Parameters.AddWithValue("@WitnessDate", objDOPayment.P_WitnessDate);
        cmd.Parameters.AddWithValue("@Awake", objDOPayment.P_Awake);
        cmd.Parameters.AddWithValue("@Alert", objDOPayment.P_Alert);
        cmd.Parameters.AddWithValue("@Oriented", objDOPayment.P_Oriented);
        cmd.Parameters.AddWithValue("@Lethargic", objDOPayment.P_Lethargic);
        cmd.Parameters.AddWithValue("@Disoriented", objDOPayment.P_Disoriented);
        cmd.Parameters.AddWithValue("@Comatose", objDOPayment.P_Comatose);
        cmd.Parameters.AddWithValue("@surgicalHistory", objDOPayment.P_surgicalHistory);
        cmd.Parameters.AddWithValue("@FamilyHistory", objDOPayment.P_FamilyHistory);
        cmd.Parameters.AddWithValue("@Wound", objDOPayment.P_Wound);
        cmd.Parameters.AddWithValue("@WoundSize", objDOPayment.P_WoundSize);
        

        cmd.ExecuteNonQuery();
        con.Close();
        con.Dispose();


    }

    public void InsertIPD_MedicationStateOrder_Details(BELBillInfo objDOPayment)
    {


        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_Insert_IPD_MEDICATIONSTAT", con);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@PatRegId", objDOPayment.PatRegId);
        cmd.Parameters.AddWithValue("@IpdNo", objDOPayment.IpdNo);

        cmd.Parameters.AddWithValue("@MedDateTime", objDOPayment.P_MedDateTime);
        cmd.Parameters.AddWithValue("@Physician", objDOPayment.P_Physician);
        cmd.Parameters.AddWithValue("@Dosage", objDOPayment.P_Dosage);
        cmd.Parameters.AddWithValue("@Route", objDOPayment.P_Route);
        cmd.Parameters.AddWithValue("@RN", objDOPayment.P_RN);
        cmd.Parameters.AddWithValue("@CreatedBy", objDOPayment.CreatedBy);       
        cmd.Parameters.AddWithValue("@BranchId", objDOPayment.BranchId);


        cmd.ExecuteNonQuery();
        con.Close();
        con.Dispose();


    }
    public void InsertIPD_Admissionsheet_Details(BELBillInfo objDOPayment)
    {


        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_Insert_OnIPD_AdmissionChild", con);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@PatRegId", objDOPayment.PatRegId);
        cmd.Parameters.AddWithValue("@IpdNo", objDOPayment.IpdNo);

        cmd.Parameters.AddWithValue("@Name", objDOPayment.P_Name);
        cmd.Parameters.AddWithValue("@Dose", objDOPayment.P_Dose);
        cmd.Parameters.AddWithValue("@Frequency", objDOPayment.P_Frequency);

        cmd.Parameters.AddWithValue("@LastDose", objDOPayment.P_LastDose);
       


        cmd.ExecuteNonQuery();
        con.Close();
        con.Dispose();


    }

    public void InsertIPD_PRNOrder_Details(BELBillInfo objDOPayment)
    {


        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_Insert_IPD_PRNOrder", con);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@PatRegId", objDOPayment.PatRegId);
        cmd.Parameters.AddWithValue("@IpdNo", objDOPayment.IpdNo);

        cmd.Parameters.AddWithValue("@Medication", objDOPayment.P_Medication);
        cmd.Parameters.AddWithValue("@DoseSign1", objDOPayment.P_DoseSign1);
        cmd.Parameters.AddWithValue("@DoseSign2", objDOPayment.P_DoseSign2);
        cmd.Parameters.AddWithValue("@DoseSign3", objDOPayment.P_DoseSign3);
        cmd.Parameters.AddWithValue("@DoseSign4", objDOPayment.P_DoseSign4);
        cmd.Parameters.AddWithValue("@DoseSign5", objDOPayment.P_DoseSign5);
        cmd.Parameters.AddWithValue("@DoseSign6", objDOPayment.P_DoseSign6);
        cmd.Parameters.AddWithValue("@DoseSign7", objDOPayment.P_DoseSign7);
        cmd.Parameters.AddWithValue("@CreatedBy", objDOPayment.CreatedBy);
        cmd.Parameters.AddWithValue("@BranchId", objDOPayment.BranchId);


        cmd.ExecuteNonQuery();
        con.Close();
        con.Dispose();


    }

    public DataTable Get_ONAdmissionDetails(int PatRegId, int BranchId, int IPDNO)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_IpdPatient_OnIpdDetails", con);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@PatRegId", PatRegId);
        cmd.Parameters.AddWithValue("@BranchId", BranchId);
        cmd.Parameters.AddWithValue("@IPDNO", IPDNO);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
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
            con.Close();
            con.Dispose();
        }
        return ds;
    }
    public object[] InsertIPD_CancelReceiptTransaction(BELBillInfo objDOPayment)
    {
        object[] Result = new object[10];

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Usp_IPD_ReceiptCancel", con);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@ReceiptNo", objDOPayment.ReceiptNo);
        cmd.Parameters.AddWithValue("@IpdNo", objDOPayment.IpdNo);
        cmd.Parameters.AddWithValue("@CreatedBy", objDOPayment.CreatedBy);
        cmd.Parameters.AddWithValue("@Remark", objDOPayment.Remark);
        cmd.Parameters.AddWithValue("@PatRegId", objDOPayment.PatRegId);

        cmd.Parameters.AddWithValue("@ReceiptNew", objDOPayment.ReceiptNew);



        cmd.Parameters.Add("@BillPaymentId", SqlDbType.Int);
        cmd.Parameters["@BillPaymentId"].Direction = ParameterDirection.Output;
        cmd.ExecuteNonQuery();
        Result[0] = Convert.ToInt32(cmd.Parameters["@BillPaymentId"].Value);
        con.Close();
        con.Dispose();
        return Result;


    }

    public void Delete_IPDMedicationState(int Patregid,int ipdno)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Delete_IPD_MEDICATIONSTAT", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@Patregid", Patregid);
            cmd.Parameters.AddWithValue("@IPDNo", ipdno);
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
    }

    public void Delete_IPDPRNOrder(int Patregid, int ipdno)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Delete_IPD_PRNOrder", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@Patregid", Patregid);
            cmd.Parameters.AddWithValue("@IPDNo", ipdno);
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
    }
    public void Update_DischargeFinanceApprove(int Patregid,int IPDNo,string ApproveBy)
    {

        SqlConnection conn = DataAccess.ConInitForDC();
        SqlCommand sc = new SqlCommand();
        sc.CommandType = CommandType.StoredProcedure;
        sc.Connection = conn;
        sc.CommandText = "SP_Update_IPDDischargeSlip_ForFinance";
        sc.Parameters.Add(new SqlParameter("@Patregid", SqlDbType.Int)).Value = Patregid;
        sc.Parameters.Add(new SqlParameter("@IPDNo", SqlDbType.Int)).Value = IPDNo;
        sc.Parameters.Add(new SqlParameter("@CreatedBy", SqlDbType.NVarChar, 200)).Value = ApproveBy;
        


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


    public void MRC_PatientSuspend(int Patregid, int IPDNo, string ApproveBy, string Remarks, int Issuspend)
    {

        SqlConnection conn = DataAccess.ConInitForDC();
        SqlCommand sc = new SqlCommand();
        sc.CommandType = CommandType.StoredProcedure;
        sc.Connection = conn;
        sc.CommandText = "SP_InsertMRC_PatientSuspent";
        sc.Parameters.Add(new SqlParameter("@Patregid", SqlDbType.Int)).Value = Patregid;
        sc.Parameters.Add(new SqlParameter("@IPDNo", SqlDbType.Int)).Value = IPDNo;
        sc.Parameters.Add(new SqlParameter("@CreatedBy", SqlDbType.NVarChar, 200)).Value = ApproveBy;
        sc.Parameters.Add(new SqlParameter("@Remarks", SqlDbType.NVarChar, 200)).Value = Remarks;
        sc.Parameters.Add(new SqlParameter("@Issuspend", SqlDbType.Int)).Value = Issuspend;


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
}