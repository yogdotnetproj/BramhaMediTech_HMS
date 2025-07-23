using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
/// <summary>
/// Summary description for DALBillDetails
/// </summary>
public class DALBillDetails
{
    BELPayment objBELPayment = new BELPayment();

    BELBillDetails objBELBillDetail = new BELBillDetails();
    BaseClass objBaseClass = new BaseClass();
    //Database objDatabase = DatabaseFactory.CreateDatabase();
    //DataSet ds = new DataSet();
    //DataTable dt = new DataTable();

	public DALBillDetails()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public string InsertIPDLabServiceDetail(BELBillDetails obj1)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_IPDLabServiceDetails", con);
        cmd.CommandType = CommandType.StoredProcedure;


        cmd.Parameters.AddWithValue("@PatRegId", obj1.PatRegId);
        cmd.Parameters.AddWithValue("@BillNo", obj1.BillNo);
        cmd.Parameters.AddWithValue("@BillGroup", obj1.BillGroupName);
        cmd.Parameters.AddWithValue("@BillServiceId", obj1.BillServiceId);
        cmd.Parameters.AddWithValue("@DrId", obj1.EmployeeId);
        cmd.Parameters.AddWithValue("@BillServiceCharges", obj1.Charges);
        cmd.Parameters.AddWithValue("@TotalCharges", obj1.TotalCharges);
        cmd.Parameters.AddWithValue("@Qty", obj1.Qty);
        cmd.Parameters.AddWithValue("@ProcedureId", obj1.ProcedureId);
        cmd.Parameters.AddWithValue("@CreatedBy", obj1.CreatedBy);
        cmd.Parameters.AddWithValue("@FId", obj1.FId);
        cmd.Parameters.AddWithValue("@BranchId", obj1.BranchId);
        cmd.Parameters.AddWithValue("@OPDNo", obj1.OpdNo);
        cmd.Parameters.AddWithValue("@IPDNO", obj1.IpdNo);
        cmd.Parameters.AddWithValue("@MTCode", obj1.MTCode);
        cmd.Parameters.AddWithValue("@ReceiptNo", obj1.ReceiptNo);

        cmd.Parameters.AddWithValue("@Initial", obj1.Initial);
        cmd.Parameters.AddWithValue("@Sex", obj1.Sex);
        cmd.Parameters.AddWithValue("@PatientName", obj1.PatientName);
        cmd.Parameters.AddWithValue("@Age", obj1.Age);
        cmd.Parameters.AddWithValue("@RefDoc", obj1.RefDoc);
        cmd.Parameters.AddWithValue("@TestName", obj1.TestName);
        cmd.Parameters.AddWithValue("@TestRate", obj1.TestRate);
        cmd.Parameters.AddWithValue("@MobileNo", obj1.MobileNo);
        cmd.Parameters.AddWithValue("@MDY", obj1.MDY);
        cmd.Parameters.AddWithValue("@ReferBy", obj1.ReferBy);
        cmd.Parameters.AddWithValue("@LabPtype", obj1.LabPtype);

        cmd.Parameters.AddWithValue("@InsuranceID", obj1.InsuranceID);

        cmd.Parameters.AddWithValue("@MainDocId", obj1.MainDocId);

        cmd.Parameters.AddWithValue("@ReferPhy", obj1.ReferPhy);
        cmd.Parameters.AddWithValue("@OtherRefDoc", obj1.OtherRefDoc);

        cmd.Parameters.AddWithValue("@PatAddress", obj1.PatAddress);
        cmd.Parameters.AddWithValue("@PatBirthDate", obj1.PatBirthDate);
        cmd.Parameters.AddWithValue("@MainDoctor", obj1.MainDoctor);
        cmd.Parameters.AddWithValue("@LabNo", obj1.LabNo);
        cmd.Parameters.AddWithValue("@ClinicalHistory", obj1.ClinicalHistory);

        object Result = cmd.ExecuteScalar();


        con.Close();
        con.Dispose();
        return Convert.ToString(Result);
    }
    public string InsertLabServiceDetail(BELBillDetails obj1)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_LabServiceDetails", con);
        cmd.CommandType = CommandType.StoredProcedure;


        cmd.Parameters.AddWithValue("@PatRegId", obj1.PatRegId);
        cmd.Parameters.AddWithValue("@BillNo", obj1.BillNo);
        cmd.Parameters.AddWithValue("@BillGroup", obj1.BillGroupName);
        cmd.Parameters.AddWithValue("@BillServiceId", obj1.BillServiceId);
        cmd.Parameters.AddWithValue("@DrId", obj1.EmployeeId);
        cmd.Parameters.AddWithValue("@BillServiceCharges", obj1.Charges);
        cmd.Parameters.AddWithValue("@TotalCharges", obj1.TotalCharges);
        cmd.Parameters.AddWithValue("@Qty", obj1.Qty);
        cmd.Parameters.AddWithValue("@ProcedureId", obj1.ProcedureId);
        cmd.Parameters.AddWithValue("@CreatedBy", obj1.CreatedBy);
        cmd.Parameters.AddWithValue("@FId", obj1.FId);
        cmd.Parameters.AddWithValue("@BranchId", obj1.BranchId);
        cmd.Parameters.AddWithValue("@OPDNo", obj1.OpdNo);
        cmd.Parameters.AddWithValue("@LabNo", obj1.LabNo);
        cmd.Parameters.AddWithValue("@MTCode", obj1.MTCode);
        cmd.Parameters.AddWithValue("@ReceiptNo", obj1.ReceiptNo);

        cmd.Parameters.AddWithValue("@Initial", obj1.Initial);
        cmd.Parameters.AddWithValue("@Sex", obj1.Sex);
        cmd.Parameters.AddWithValue("@PatientName", obj1.PatientName);
        cmd.Parameters.AddWithValue("@Age", obj1.Age);
        cmd.Parameters.AddWithValue("@RefDoc", obj1.RefDoc);
        cmd.Parameters.AddWithValue("@TestName", obj1.TestName);
        cmd.Parameters.AddWithValue("@TestRate", obj1.TestRate);
        cmd.Parameters.AddWithValue("@MobileNo", obj1.MobileNo);
        cmd.Parameters.AddWithValue("@ReferBy", obj1.ReferBy);
        cmd.Parameters.AddWithValue("@IPDNO", obj1.IpdNo);
        cmd.Parameters.AddWithValue("@MDY", obj1.MDY);
        cmd.Parameters.AddWithValue("@ReferPhy", obj1.ReferPhy);
        cmd.Parameters.AddWithValue("@OtherRefDoc", obj1.OtherRefDoc);

        cmd.Parameters.AddWithValue("@InsuranceID", obj1.InsuranceID);
        cmd.Parameters.AddWithValue("@InsuranceAmt", obj1.InsuranceAmt);
        cmd.Parameters.AddWithValue("@MainDocId", obj1.MainDocId);

        cmd.Parameters.AddWithValue("@PaidAmt", obj1.PaidAmt);
        cmd.Parameters.AddWithValue("@BalanceAmt", obj1.BalanceAmt);
        cmd.Parameters.AddWithValue("@DiscountAmt", obj1.DiscountAmt);
        cmd.Parameters.AddWithValue("@ModeOfPay", obj1.ModeOfPay);
        cmd.Parameters.AddWithValue("@LabPtype", obj1.LabPtype);

        cmd.Parameters.AddWithValue("@PatAddress", obj1.PatAddress);
        cmd.Parameters.AddWithValue("@PatBirthDate", obj1.PatBirthDate);
        cmd.Parameters.AddWithValue("@RepType", obj1.RepType);
        cmd.Parameters.AddWithValue("@Email", obj1.Email);
       
        cmd.Parameters.AddWithValue("@ClinicalHistory", obj1.ClinicalHistory);
        cmd.Parameters.AddWithValue("@CenterName", obj1.CenterName);
        
        object Result = cmd.ExecuteScalar();


        con.Close();
        con.Dispose();
        return Convert.ToString(Result);
    }

    public object FillGrid(int BillId)
    {
        List<BELBillDetails> objDOBillDetails = new List<BELBillDetails>();
       
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_BillDetail_FillGrid_PID", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@BillId", BillId);
        SqlDataReader reader=cmd.ExecuteReader();
        
        while (reader.Read())
        {
            BELBillDetails objBELBillDetail = new BELBillDetails();
            objBELBillDetail.BillDetailId = Convert.ToInt32(reader["BillDetailId"]);
            //objBELBillDetail.BillId = Convert.ToInt32(reader["BillId"]);
            objBELBillDetail.BillParticular = Convert.ToString(reader["BillParticular"]);
            objBELBillDetail.EmployeeName = Convert.ToString(reader["EmployeeName"]);
            objBELBillDetail.Charges = Convert.ToInt32(reader["Charges"]);
            objBELBillDetail.NoOfTimes = Convert.ToInt32(reader["NoOfTimes"]);
            objBELBillDetail.Amount = Convert.ToInt32(reader["Amount"]);
            objBELBillDetail.Note = Convert.ToString(reader["Note"]);
            objBELBillDetail.BillDetailDatetime = Convert.ToString(reader["BillDetailDatetime"]);
            objDOBillDetails.Add(objBELBillDetail);
        }
        reader.Close();
        reader.Dispose();
        return objDOBillDetails;
    }

   
    public string InsertIPDBillDetail(BELBillDetails obj1)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_InsertIpdBillServiceDetails", con);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@IpdId", obj1.IpdId);
        cmd.Parameters.AddWithValue("@IpdNo", obj1.IpdNo);
        cmd.Parameters.AddWithValue("@PatRegId", obj1.PatRegId);
        cmd.Parameters.AddWithValue("@BillNo",obj1.BillNo);
        
        cmd.Parameters.AddWithValue("@BillGroupId", obj1.BillGroupId);
        cmd.Parameters.AddWithValue("@BillServiceId", obj1.BillServiceId);
        cmd.Parameters.AddWithValue("@DrId",obj1.EmployeeId);
        cmd.Parameters.AddWithValue("@DeptId", 0); 
        cmd.Parameters.AddWithValue("@BillServiceCharges",obj1.Charges);
        cmd.Parameters.AddWithValue("@TotalCharges", obj1.TotalCharges);
        cmd.Parameters.AddWithValue("@Qty", obj1.Qty);
        cmd.Parameters.AddWithValue("@CreatedBy",obj1.CreatedBy);
        cmd.Parameters.AddWithValue("@FId", obj1.FId);
        cmd.Parameters.AddWithValue("@BranchId", obj1.BranchId);
        cmd.Parameters.AddWithValue("@Description", obj1.Description);
        cmd.Parameters.AddWithValue("@BillServiceType", obj1.BillTypeName);
        cmd.Parameters.AddWithValue("@InFant", obj1.InfantPatient);
        //cmd.Parameters.AddWithValue("@ItemId", obj1.ItemId);
        //cmd.Parameters.AddWithValue("@ItemName", obj1.ItemName);


        object Result = cmd.ExecuteScalar();
        con.Close();
        con.Dispose();
        return Convert.ToString(Result);
    }
    public string InsertBillDetail(BELBillDetails obj1)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_InsertBillServiceDetails", con);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@OpdNo", obj1.OpdNo);
        cmd.Parameters.AddWithValue("@PatRegId", obj1.PatRegId);
        cmd.Parameters.AddWithValue("@BillNo", obj1.BillNo);
        cmd.Parameters.AddWithValue("@BillGroupId", obj1.BillGroupId);
        cmd.Parameters.AddWithValue("@BillServiceId", obj1.BillServiceId);
        cmd.Parameters.AddWithValue("@DrId", obj1.EmployeeId);
        cmd.Parameters.AddWithValue("@DeptId", obj1.DeptId);
        cmd.Parameters.AddWithValue("@BillServiceCharges", obj1.TotalCharges);
        cmd.Parameters.AddWithValue("@SingleBillServiceCharges", obj1.Charges);
        cmd.Parameters.AddWithValue("@Qty", obj1.Qty);
        cmd.Parameters.AddWithValue("@CreatedBy", obj1.CreatedBy);
        cmd.Parameters.AddWithValue("@FId", obj1.FId);
        cmd.Parameters.AddWithValue("@BranchId", obj1.BranchId);

        object Result = cmd.ExecuteScalar();
        con.Close();
        con.Dispose();
        return Convert.ToString(Result);
    }


    public BELBillDetails SelectOne(int IpdBillServiceDetailId)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_IPDBillDetail_SelectOne", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@IpdBillServiceDetailId", IpdBillServiceDetailId);
        SqlDataReader reader = cmd.ExecuteReader();
       
       
        if (reader.Read())
        {

           // objBELBillDetail.BillDetailId = Convert.ToInt32(reader["BillDetailId"]);
            objBELBillDetail.BillServiceId = Convert.ToInt32(reader["BillServiceId"]);
            objBELBillDetail.EmployeeId = Convert.ToInt32(reader["DrId"]);
            objBELBillDetail.Charges = Convert.ToInt32(reader["BillServiceCharges"]);
            objBELBillDetail.Qty = Convert.ToDecimal(reader["Qty"]);
            objBELBillDetail.TotalCharges = Convert.ToDecimal(reader["TotalCharges"]);
            objBELBillDetail.Description = Convert.ToString(reader["Description"]);
            objBELBillDetail.EmployeeName = Convert.ToString(reader["DocName"]);
            objBELBillDetail.ServiceName = Convert.ToString(reader["ServiceName"]);
            objBELBillDetail.ItemId = Convert.ToInt32(reader["ItemId"]);
            objBELBillDetail.ItemName = Convert.ToString(reader["ItemName"]);
            

        }
        con.Close();
        con.Dispose();
        return objBELBillDetail;
    }



    public string UpdateBillDetail(BELBillDetails obj1)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_IPDBillDetail_Update", con);
        cmd.CommandType = CommandType.StoredProcedure;


        cmd.Parameters.AddWithValue("@IpdBillServiceDetailId", obj1.IpdBillServiceDetailId);
        cmd.Parameters.AddWithValue("@Description", obj1.Description);
        cmd.Parameters.AddWithValue("@Qty", obj1.Qty);        
        cmd.Parameters.AddWithValue("@Charges",obj1.Charges);
        cmd.Parameters.AddWithValue("@TotalCharges", obj1.TotalCharges);
        cmd.Parameters.AddWithValue("@IpdId", obj1.IpdId);
        cmd.Parameters.AddWithValue("@IpdNo", obj1.IpdNo);
        cmd.Parameters.AddWithValue("@PatRegId", obj1.PatRegId);
        cmd.Parameters.AddWithValue("@BillNo", obj1.BillNo);
        cmd.Parameters.AddWithValue("@FId", obj1.FId);
        cmd.Parameters.AddWithValue("@BranchId", obj1.BranchId);
        cmd.Parameters.AddWithValue("@UpdatedBy",obj1.UpdatedBy);
        //cmd.Parameters.AddWithValue("@ItemId", obj1.ItemId);
        //cmd.Parameters.AddWithValue("@ItemName", obj1.ItemName);
        object Result = cmd.ExecuteScalar();
        con.Close();
        con.Dispose();
        return Convert.ToString(Result);
    }

    public object FillGridPayment(int BillId)
    {
        List<BELPayment> objDOPayments = new List<BELPayment>();
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_OPDPayment_FillGrid", con);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataReader reader = cmd.ExecuteReader(); 
        cmd.Parameters.AddWithValue("@BillId",BillId);
        reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            BELPayment objDOPayment = new BELPayment();
            objDOPayment.PaymentId = Convert.ToInt32(reader["PaymentId"]);
            objDOPayment.BillId = Convert.ToInt32(reader["BillId"]);
            objDOPayment.PaymentDate = Convert.ToString(reader["PaymentDate"]);
            objDOPayment.BillAmount = Convert.ToDecimal(reader["BillAmount"]);
            objDOPayment.DiscountGiven = Convert.ToInt32(reader["DiscountGiven"]);
            objDOPayment.PaymentTypeName = Convert.ToString(reader["PaymentTypeName"]);
            objDOPayment.UserName = Convert.ToString(reader["UserName"]);
            objDOPayment.AmountPaid = Convert.ToInt32(reader["AmountPaid"]);
            objDOPayment.TotalBillAmount = Convert.ToInt32(reader["TotalBillAmount"]);
            objDOPayments.Add(objDOPayment);
        }
        con.Close();
        con.Dispose();
        return objDOPayments;
    }

    public string DeleteBillDetail(int BillDetailId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_BillDetail_Delete", con);
        cmd.CommandType = CommandType.StoredProcedure;   
       
        cmd.Parameters.AddWithValue("@BillDetailId",BillDetailId);
        object Result = cmd.ExecuteScalar();
        con.Close();
        con.Dispose();
        return Convert.ToString(Result);
    }
    public string DeleteIPDBillDetail(int IpdBillServiceDetailId,BELBillDetails obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_IPDBillDetailDelete", con);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@IpdBillServiceDetailId", IpdBillServiceDetailId);
        cmd.Parameters.AddWithValue("@IpdId", obj.IpdId);
        cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);
        cmd.Parameters.AddWithValue("@PatRegId", obj.PatRegId);
        cmd.Parameters.AddWithValue("@FId", obj.FId);
        cmd.Parameters.AddWithValue("@BranchId", obj.BranchId);
        
        object Result = cmd.ExecuteScalar();
        con.Close();
        con.Dispose();
        return Convert.ToString(Result);
    }


    public object[] InsertPayment(BELPayment objDOPayment)
    {
        object[] Result = new object[10];
       
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_Payment_Insert", con);
        cmd.CommandType = CommandType.StoredProcedure;   
       
        cmd.Parameters.AddWithValue("@BillId",objDOPayment.BillId);
        cmd.Parameters.AddWithValue("@PaymentDate",objDOPayment.PaymentDate);
        cmd.Parameters.AddWithValue("@DiscountPercent",objDOPayment.DiscountPercent);
        cmd.Parameters.AddWithValue("@PaymentTypeId",objDOPayment.PaymentTypeId);
        cmd.Parameters.AddWithValue("@ReasonForDiscountId",objDOPayment.ReasonForDiscountId);//("dd/MM/yyyy hh:MM:ss tt")
        cmd.Parameters.AddWithValue("@DiscountGivenById",objDOPayment.DiscountGivenById);
        cmd.Parameters.AddWithValue("@DiscountGiven",objDOPayment.DiscountGiven);
        cmd.Parameters.AddWithValue("@ReasonForBalanceId",objDOPayment.ReasonForBalanceId);
        cmd.Parameters.AddWithValue("@AmountPaidPerTransaction",objDOPayment.AmountPaidPerTransaction);
        cmd.Parameters.AddWithValue("@CreatedBy",objDOPayment.CreatedBy);
        cmd.Parameters.AddWithValue("@CardChequeNo",objDOPayment.ChequeCardNo);
        cmd.Parameters.AddWithValue("@ChequeDate", objDOPayment.ChequeDate);
        cmd.Parameters.AddWithValue("@BankName", objDOPayment.BankName);
        cmd.Parameters.Add("@PaymentId", SqlDbType.Int);
        cmd.Parameters["@PaymentId"].Direction = ParameterDirection.Output;
        Result[0] = cmd.ExecuteScalar();
        Result[1] = Convert.ToInt32(cmd.Parameters["@PaymentId"].Value);
        con.Close();
        con.Dispose();
        return Result;
            
        
    }

    public List<BELBillDetails> GetIPDFixCharges()
    {
        List<BELBillDetails> objDOBillDetails = new List<BELBillDetails>();
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_IPDFixCharges_SelectAll", con);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataReader reader = cmd.ExecuteReader();
       
        while (reader.Read())
        {
            BELBillDetails objBELBillDetail = new BELBillDetails();
            objBELBillDetail.BillGroupId = Convert.ToInt32(reader["BillGroupId"]);
            objBELBillDetail.BillServiceId = Convert.ToInt32(reader["BillParticularId"]);
            objBELBillDetail.Charges = Convert.ToDecimal(reader["Charges"]);//Charges
            objDOBillDetails.Add(objBELBillDetail);
        }
        con.Close();
        con.Dispose();
        return objDOBillDetails;
    }

    public List<BELBillDetails> FillGridBillDetail(int BillId)
    {
        List<BELBillDetails> objDOBillDetails = new List<BELBillDetails>();
       
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_BillDetail_FillGridBillDetail_PID", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@BillId",BillId);
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            BELBillDetails objBELBillDetail = new BELBillDetails();
            objBELBillDetail.BillDetailId = Convert.ToInt32(reader["BillDetailId"]);
            //objBELBillDetail.BillId = Convert.ToInt32(reader["BillId"]);
            objBELBillDetail.BillParticular = Convert.ToString(reader["BillParticular"]);
            objBELBillDetail.EmployeeName = Convert.ToString(reader["EmployeeName"]);
            objBELBillDetail.Charges = Convert.ToInt32(reader["Charges"]);
            objBELBillDetail.NoOfTimes = Convert.ToInt32(reader["Qty"]);
            objBELBillDetail.Amount = Convert.ToInt32(reader["Amount"]);
            objBELBillDetail.Note = Convert.ToString(reader["Note"]);
            objBELBillDetail.BillDetailDatetime = Convert.ToString(reader["Date"]);
            objDOBillDetails.Add(objBELBillDetail);
        }
        con.Close();
        con.Dispose();
        return objDOBillDetails;
    }

    public DataTable GetBillDetails(string BillId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_Rpt_BillServices", con);
        cmd.CommandType = CommandType.StoredProcedure;      
        cmd.Parameters.AddWithValue("@BillId",BillId);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);

        DataTable dt = ds.Tables[0].Copy();
        dt.TableName = "BillServices";
        con.Close();
        con.Dispose();
        return dt;
    }

    public List<BELBillDetails> SelectAllIPDAdmitedCharges()
    {
        List<BELBillDetails> objDOBillDetails = new List<BELBillDetails>();
        
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_IPDFixCharges_FillGrid", con);
        cmd.CommandType = CommandType.StoredProcedure;
       
        SqlDataReader reader = cmd.ExecuteReader();
      

        while (reader.Read())
        {
            BELBillDetails objBELBillDetail = new BELBillDetails();
            objBELBillDetail.IPDFixChargesId = Convert.ToInt32(reader["IPDFixChargesId"]);
            objBELBillDetail.BillGroupId = Convert.ToInt32(reader["BillGroupId"]);
            objBELBillDetail.BillGroupName = Convert.ToString(reader["BillGroupName"]);
            objBELBillDetail.BillServiceId = Convert.ToInt32(reader["BillParticularId"]);
            objBELBillDetail.BillParticular = Convert.ToString(reader["BillParticular"]);
            objBELBillDetail.Charges = Convert.ToDecimal(reader["Charges"]);//Charges
            objDOBillDetails.Add(objBELBillDetail);
        }
        con.Close();
        con.Dispose();
        return objDOBillDetails;
    }   
   
     public DataSet FillGridIpdBillDetail(BELBillDetails obj)
    {
               
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_IPDBillServiceDetailsFillGrid", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@IpdId", obj.IpdId);
        cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);
        cmd.Parameters.AddWithValue("@PatRegId", obj.PatRegId);
        cmd.Parameters.AddWithValue("@FId", obj.FId);
        cmd.Parameters.AddWithValue("@BranchId", obj.BranchId);
        cmd.Parameters.AddWithValue("@BillServiceType", obj.BillTypeName);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
         DataSet ds=new DataSet();
         sda.Fill(ds);
         con.Close();
         con.Dispose();
        return ds;

     }

     public string UpdateBillDuscountDetail(BELBillDetails obj1)
     {
         SqlConnection con = DataAccess.ConInitForDC();
         con.Open();
         SqlCommand cmd = new SqlCommand("SP_UpdateBillDiscount", con);
         cmd.CommandType = CommandType.StoredProcedure;



         cmd.Parameters.AddWithValue("@Discount", obj1.TotalCharges);
      
         cmd.Parameters.AddWithValue("@IpdNo", obj1.IpdNo);
         cmd.Parameters.AddWithValue("@Patregid", obj1.PatRegId);
         
         cmd.Parameters.AddWithValue("@BranchId", obj1.BranchId);
         cmd.Parameters.AddWithValue("@DiscountGivenBy", obj1.DiscountGivenBy);
         cmd.Parameters.AddWithValue("@ReasonforDiscount", obj1.ReasonforDiscount);
      
         object Result = cmd.ExecuteScalar();
         con.Close();
         con.Dispose();
         return Convert.ToString(Result);
     }

     public string UpdateBillFinalDischarge(BELBillDetails obj1)
     {
         SqlConnection con = DataAccess.ConInitForDC();
         con.Open();
         SqlCommand cmd = new SqlCommand("SP_UpdateBillFinalDischarge", con);
         cmd.CommandType = CommandType.StoredProcedure;

         cmd.Parameters.AddWithValue("@IpdNo", obj1.IpdNo);
         cmd.Parameters.AddWithValue("@Patregid", obj1.PatRegId);

         cmd.Parameters.AddWithValue("@BranchId", obj1.BranchId);
         cmd.Parameters.AddWithValue("@UserName", obj1.CreatedBy);
         cmd.Parameters.AddWithValue("@ReasonForBalance_Refund", obj1.ReasonForBalanceId);

         object Result = cmd.ExecuteScalar();
         con.Close();
         con.Dispose();
         return Convert.ToString(Result);
     }
     public string Insert_OTRegister(BELBillDetails obj1)
     {
         SqlConnection con = DataAccess.ConInitForDC();
         con.Open();
         SqlCommand cmd = new SqlCommand("SP_InsertOTRegister", con);
         cmd.CommandType = CommandType.StoredProcedure;


         cmd.Parameters.AddWithValue("@IpdNo", obj1.IpdNo);
         cmd.Parameters.AddWithValue("@PatRegId", obj1.PatRegId);


         cmd.Parameters.AddWithValue("@Surgan", obj1.Surgan);
         cmd.Parameters.AddWithValue("@ANAESTHETIST", obj1.ANAESTHETIST);
         cmd.Parameters.AddWithValue("@FirstAssistant", obj1.FirstAssistant);
         cmd.Parameters.AddWithValue("@SecondAssistant", obj1.SecondAssistant);
         cmd.Parameters.AddWithValue("@TrollyNurse", obj1.TrollyNurse);
         cmd.Parameters.AddWithValue("@SteriNurse", obj1.SteriNurse);
         cmd.Parameters.AddWithValue("@Disease", obj1.Disease);

         cmd.Parameters.AddWithValue("@Operation", obj1.Operation);
         cmd.Parameters.AddWithValue("@SwabCountNurse", obj1.SwabCountNurse);

         cmd.Parameters.AddWithValue("@InstrumentCountNurse", obj1.InstrumentCountNurse);
         cmd.Parameters.AddWithValue("@OperationStartTime", obj1.OperationStartTime);
         cmd.Parameters.AddWithValue("@OperationEndTime", obj1.OperationEndTime);

         cmd.Parameters.AddWithValue("@OperationStartDate", obj1.OperationStartDate);
         cmd.Parameters.AddWithValue("@OperationEndDate", obj1.OperationEndDate);

         cmd.Parameters.AddWithValue("@AnisticTime", obj1.AnisticTime);
         cmd.Parameters.AddWithValue("@Remark", obj1.Remark);
         cmd.Parameters.AddWithValue("@CreatedBy", obj1.CreatedBy);
         cmd.Parameters.AddWithValue("@FId", obj1.FId);
         cmd.Parameters.AddWithValue("@BranchId", obj1.BranchId);

         cmd.Parameters.AddWithValue("@OperationName", obj1.OperationName.Trim());
         cmd.Parameters.AddWithValue("@DiseaseName", obj1.DiseaseName.Trim());

         cmd.Parameters.AddWithValue("@SwabCountNurse2", obj1.swabSecountNurse);
         cmd.Parameters.AddWithValue("@InstrumentCountNurse2", obj1.InstrumentSecoundNurse);

         cmd.Parameters.AddWithValue("@GeneralOT", obj1.GeneralOT);
         cmd.Parameters.AddWithValue("@ASA", obj1.ASA);
         cmd.Parameters.AddWithValue("@OTClass", obj1.OTClass);
         cmd.Parameters.AddWithValue("@Flag", obj1.Flag);
         object Result = cmd.ExecuteScalar();
         con.Close();
         con.Dispose();
         return Convert.ToString(Result);
     }

     public string InsertSurgeryQuoteByDoc(BELBillDetails obj1)
     {
         SqlConnection con = DataAccess.ConInitForDC();
         con.Open();
         SqlCommand cmd = new SqlCommand("SP_InsertSurgeryQuoteByDoc", con);
         cmd.CommandType = CommandType.StoredProcedure;


         cmd.Parameters.AddWithValue("@IpdNo", obj1.IpdNo);
         cmd.Parameters.AddWithValue("@PatRegId", obj1.PatRegId);
         cmd.Parameters.AddWithValue("@OpdNo", obj1.OpdNo);
         cmd.Parameters.AddWithValue("@SurganName", obj1.SurgeonName);
         cmd.Parameters.AddWithValue("@OperationName", obj1.OperationName);        
         cmd.Parameters.AddWithValue("@Surgan", obj1.Surgan);        
         cmd.Parameters.AddWithValue("@Operation", obj1.Operation);
         cmd.Parameters.AddWithValue("@OTTime",obj1.OTTime);
         cmd.Parameters.AddWithValue("@SurgeonsFee",obj1.SurgeonsFee);
         cmd.Parameters.AddWithValue("@HospitalStay",obj1.HospitalStay);
         cmd.Parameters.AddWithValue("@ASA",obj1.ASA);
         cmd.Parameters.AddWithValue("@SpecialInvestigation", obj1.SpecialInvestigation);
         cmd.Parameters.AddWithValue("@CreatedBy", obj1.CreatedBy);
         cmd.Parameters.AddWithValue("@FId", obj1.FId);
         cmd.Parameters.AddWithValue("@BranchId", obj1.BranchId);
         cmd.Parameters.AddWithValue("@ConsultantDrId", obj1.ConsultantDrId);
         cmd.Parameters.AddWithValue("@ConsultantDoc", obj1.ConsultantDoc);

       
        
         object Result = cmd.ExecuteScalar();
         con.Close();
         con.Dispose();
         return Convert.ToString(Result);
     }

     public string InsertSurgeryQuoteFinal(BELBillDetails obj1)
     {
         SqlConnection con = DataAccess.ConInitForDC();
         con.Open();
         SqlCommand cmd = new SqlCommand("SP_InsertSurgeryQuoteFinal", con);
         cmd.CommandType = CommandType.StoredProcedure;

         cmd.Parameters.AddWithValue("@SurgEstimationId", obj1.SurgEstimationId);
         cmd.Parameters.AddWithValue("@IpdNo", obj1.IpdNo);
         cmd.Parameters.AddWithValue("@PatRegId", obj1.PatRegId);
         cmd.Parameters.AddWithValue("@OpdNo", obj1.OpdNo);
         cmd.Parameters.AddWithValue("@SurganName", obj1.SurgeonName);

         cmd.Parameters.AddWithValue("@SurgeonID", obj1.Surgan);
        
         cmd.Parameters.AddWithValue("@SurgeonsFee", obj1.SurgeonFee);
         cmd.Parameters.AddWithValue("@TheatreFee", obj1.TheatreFee);
         cmd.Parameters.AddWithValue("@WardCharges", obj1.WardCharges);
         cmd.Parameters.AddWithValue("@InvestigationFees", obj1.InvestigationCharges);
         cmd.Parameters.AddWithValue("@MedicineCharges", obj1.MedicineCharges);
         cmd.Parameters.AddWithValue("@AnesthetistCharges", obj1.AnesthetistCharges);
         cmd.Parameters.AddWithValue("@CreatedBy", obj1.CreatedBy);
         cmd.Parameters.AddWithValue("@FId", obj1.FId);
         cmd.Parameters.AddWithValue("@BranchId", obj1.BranchId);
         cmd.Parameters.AddWithValue("@ConsultantDrId", obj1.ConsultantDrId);
         cmd.Parameters.AddWithValue("@ConsultantDoc", obj1.ConsultantDoc);
         cmd.Parameters.AddWithValue("@TotalCharges", obj1.TotalCharges);
         cmd.Parameters.AddWithValue("@OperationName", obj1.OperationName);

         cmd.Parameters.AddWithValue("@OperationId", obj1.Operation);
        


         object Result = cmd.ExecuteScalar();
         con.Close();
         con.Dispose();
         return Convert.ToString(Result);
     }
     public string Insert_OTNotes(BELBillDetails obj1)
     {
         SqlConnection con = DataAccess.ConInitForDC();
         con.Open();
         SqlCommand cmd = new SqlCommand("SP_InsertOTNotes", con);
         cmd.CommandType = CommandType.StoredProcedure;


         cmd.Parameters.AddWithValue("@IpdNo", obj1.IpdNo);
         cmd.Parameters.AddWithValue("@PatRegId", obj1.PatRegId);


         cmd.Parameters.AddWithValue("@Surgan", obj1.Surgan);
         cmd.Parameters.AddWithValue("@ANAESTHETIST", obj1.ANAESTHETIST);
         //cmd.Parameters.AddWithValue("@FirstAssistant", obj1.FirstAssistant);
         cmd.Parameters.AddWithValue("@SecondAssistant", obj1.SecondAssistant);
        
         cmd.Parameters.AddWithValue("@Disease", obj1.Disease);

         cmd.Parameters.AddWithValue("@Operation", obj1.Operation);

         cmd.Parameters.AddWithValue("@Type", obj1.Type);
         cmd.Parameters.AddWithValue("@TypeOfAnaesthesia", obj1.TypeOfAnaesthesia);
         cmd.Parameters.AddWithValue("@Procedure", obj1.Procedure);
         cmd.Parameters.AddWithValue("@Incision", obj1.Incision);
         cmd.Parameters.AddWithValue("@BloodLoss", obj1.BloodLoss);
         cmd.Parameters.AddWithValue("@SurgeryDone", obj1.SurgeryDone);
         cmd.Parameters.AddWithValue("@AdvertEvents", obj1.AdvertEvents);
         cmd.Parameters.AddWithValue("@Comments", obj1.Comments);

      
         cmd.Parameters.AddWithValue("@OperationStartDate", obj1.OperationStartDate);
         
         cmd.Parameters.AddWithValue("@CreatedBy", obj1.CreatedBy);
         cmd.Parameters.AddWithValue("@FId", obj1.FId);
         cmd.Parameters.AddWithValue("@BranchId", obj1.BranchId);

         cmd.Parameters.AddWithValue("@OperationName", obj1.OperationName.Trim());
         cmd.Parameters.AddWithValue("@DiseaseName", obj1.DiseaseName.Trim());

        
         cmd.Parameters.AddWithValue("@GeneralOT", obj1.GeneralOT);
         cmd.Parameters.AddWithValue("@OTId", obj1.OTId);
         cmd.Parameters.AddWithValue("@OTImagePath", obj1.OTImagePath);

         object Result = cmd.ExecuteScalar();
         con.Close();
         con.Dispose();
         return Convert.ToString(Result);
     }
     public string InsertIPDBillDetailOT(BELBillDetails obj1)
     {
         SqlConnection con = DataAccess.ConInitForDC();
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_InsertIpdBillServiceDetails_OT", con);
         cmd.CommandType = CommandType.StoredProcedure;

         cmd.Parameters.AddWithValue("@IpdId", obj1.IpdId);
         cmd.Parameters.AddWithValue("@IpdNo", obj1.IpdNo);
         cmd.Parameters.AddWithValue("@PatRegId", obj1.PatRegId);
         cmd.Parameters.AddWithValue("@BillNo", obj1.BillNo);

         cmd.Parameters.AddWithValue("@BillGroupId", obj1.BillGroupId);
         cmd.Parameters.AddWithValue("@BillServiceId", obj1.BillServiceId);
         cmd.Parameters.AddWithValue("@DrId", obj1.EmployeeId);
         cmd.Parameters.AddWithValue("@DeptId", 0);
         cmd.Parameters.AddWithValue("@BillServiceCharges", obj1.Charges);
         cmd.Parameters.AddWithValue("@TotalCharges", obj1.TotalCharges);
         cmd.Parameters.AddWithValue("@Qty", obj1.Qty);
         cmd.Parameters.AddWithValue("@CreatedBy", obj1.CreatedBy);
         cmd.Parameters.AddWithValue("@FId", obj1.FId);
         cmd.Parameters.AddWithValue("@BranchId", obj1.BranchId);
         cmd.Parameters.AddWithValue("@Description", obj1.Description);
         cmd.Parameters.AddWithValue("@BillServiceType", obj1.BillTypeName);

         object Result = cmd.ExecuteScalar();
         con.Close();
         con.Dispose();
         return Convert.ToString(Result);
     }

     public DataSet FillGridIpdBillDetail_OT(BELBillDetails obj)
     {

         SqlConnection con = DataAccess.ConInitForDC();
         con.Open();
         SqlCommand cmd = new SqlCommand("SP_IPDBillServiceDetailsFillGrid_OT", con);
         cmd.CommandType = CommandType.StoredProcedure;
         cmd.Parameters.AddWithValue("@IpdId", obj.IpdId);
         cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);
         cmd.Parameters.AddWithValue("@PatRegId", obj.PatRegId);
         cmd.Parameters.AddWithValue("@FId", obj.FId);
         cmd.Parameters.AddWithValue("@BranchId", obj.BranchId);
         cmd.Parameters.AddWithValue("@BillServiceType", obj.BillTypeName);
         SqlDataAdapter sda = new SqlDataAdapter(cmd);
         DataSet ds = new DataSet();
         sda.Fill(ds);
         con.Close();
         con.Dispose();
         return ds;

     }

     public string Insert_QuotionServiceDetails(BELBillDetails obj1)
     {
         SqlConnection con = DataAccess.ConInitForDC();
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_QuotionServiceDetails", con);
         cmd.CommandType = CommandType.StoredProcedure;


        
         cmd.Parameters.AddWithValue("@BillServiceId", obj1.BillServiceId);
       
         cmd.Parameters.AddWithValue("@BillServiceCharges", obj1.Charges);
         cmd.Parameters.AddWithValue("@TotalCharges", obj1.TotalCharges);
         cmd.Parameters.AddWithValue("@Qty", obj1.Qty);
         cmd.Parameters.AddWithValue("@ProcedureId", obj1.ProcedureId);
         cmd.Parameters.AddWithValue("@CreatedBy", obj1.CreatedBy);
         cmd.Parameters.AddWithValue("@FId", obj1.FId);
         cmd.Parameters.AddWithValue("@BranchId", obj1.BranchId);
        


         object Result = cmd.ExecuteScalar();
         con.Close();
         con.Dispose();
         return Convert.ToString(Result);
     }
     public string InsertProcedureServiceDetail(BELBillDetails obj1)
     {
         SqlConnection con = DataAccess.ConInitForDC();
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_ProcedureServiceDetails", con);
         cmd.CommandType = CommandType.StoredProcedure;

        
         cmd.Parameters.AddWithValue("@PatRegId", obj1.PatRegId);
         cmd.Parameters.AddWithValue("@BillNo", obj1.BillNo);
         cmd.Parameters.AddWithValue("@BillGroup", obj1.BillGroupName);
         cmd.Parameters.AddWithValue("@BillServiceId", obj1.BillServiceId);
         cmd.Parameters.AddWithValue("@DrId", obj1.EmployeeId);        
         cmd.Parameters.AddWithValue("@BillServiceCharges", obj1.Charges);
         cmd.Parameters.AddWithValue("@TotalCharges", obj1.TotalCharges);
         cmd.Parameters.AddWithValue("@Qty", obj1.Qty);
         cmd.Parameters.AddWithValue("@ProcedureId", obj1.ProcedureId);        
         cmd.Parameters.AddWithValue("@CreatedBy", obj1.CreatedBy);
         cmd.Parameters.AddWithValue("@FId", obj1.FId);
         cmd.Parameters.AddWithValue("@BranchId", obj1.BranchId);
         cmd.Parameters.AddWithValue("@PatMainTypeId", obj1.PatMainTypeId);
         cmd.Parameters.AddWithValue("@PatientInsuTypeId", obj1.PatientInsuTypeId);
         

         object Result = cmd.ExecuteScalar();
         con.Close();
         con.Dispose();
         return Convert.ToString(Result);
     }

     public DataSet FillGridIpdBillDetail_Search(BELBillDetails obj)
     {

         SqlConnection con = DataAccess.ConInitForDC();
         con.Open();
         SqlCommand cmd = new SqlCommand("SP_IPDBillServiceDetailsFillGrid_Search", con);
         cmd.CommandType = CommandType.StoredProcedure;
         cmd.Parameters.AddWithValue("@IpdId", obj.IpdId);
         cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);
         cmd.Parameters.AddWithValue("@PatRegId", obj.PatRegId);
         cmd.Parameters.AddWithValue("@FId", obj.FId);
         cmd.Parameters.AddWithValue("@BranchId", obj.BranchId);
         cmd.Parameters.AddWithValue("@BillServiceType", obj.BillTypeName);
         SqlDataAdapter sda = new SqlDataAdapter(cmd);
         DataSet ds = new DataSet();
         sda.Fill(ds);
         con.Close();
         con.Dispose();
         return ds;

     }

     public DataTable Fill_GetPackageServiceDetails(int packid)
     {

         SqlConnection con = DataAccess.ConInitForDC();
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_GetAllPackageServiceDetails", con);
         cmd.CommandType = CommandType.StoredProcedure;
         cmd.Parameters.AddWithValue("@packid", packid);
       
         SqlDataAdapter sda = new SqlDataAdapter(cmd);
         DataTable ds = new DataTable();
         sda.Fill(ds);
         con.Close();
         con.Dispose();
         return ds;

     }

     public string InsertEMR_LabServiceDetail(BELBillDetails obj1)
     {
         SqlConnection con = DataAccess.ConInitForDC();
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_EMRLabServiceDetails", con);
         cmd.CommandType = CommandType.StoredProcedure;


         cmd.Parameters.AddWithValue("@PatRegId", obj1.PatRegId);
         cmd.Parameters.AddWithValue("@BillNo", obj1.BillNo);
         cmd.Parameters.AddWithValue("@BillGroup", obj1.BillGroupName);
         cmd.Parameters.AddWithValue("@BillServiceId", obj1.BillServiceId);
         cmd.Parameters.AddWithValue("@DrId", obj1.EmployeeId);
         cmd.Parameters.AddWithValue("@BillServiceCharges", obj1.Charges);
         cmd.Parameters.AddWithValue("@TotalCharges", obj1.TotalCharges);
         cmd.Parameters.AddWithValue("@Qty", obj1.Qty);
         cmd.Parameters.AddWithValue("@ProcedureId", obj1.ProcedureId);
         cmd.Parameters.AddWithValue("@CreatedBy", obj1.CreatedBy);
         cmd.Parameters.AddWithValue("@FId", obj1.FId);
         cmd.Parameters.AddWithValue("@BranchId", obj1.BranchId);
         cmd.Parameters.AddWithValue("@OPDNo", obj1.OpdNo);
         cmd.Parameters.AddWithValue("@LabNo", obj1.LabNo);
         cmd.Parameters.AddWithValue("@MTCode", obj1.MTCode);
         cmd.Parameters.AddWithValue("@ReceiptNo", obj1.ReceiptNo);

         cmd.Parameters.AddWithValue("@Initial", obj1.Initial);
         cmd.Parameters.AddWithValue("@Sex", obj1.Sex);
         cmd.Parameters.AddWithValue("@PatientName", obj1.PatientName);
         cmd.Parameters.AddWithValue("@Age", obj1.Age);
         cmd.Parameters.AddWithValue("@RefDoc", obj1.RefDoc);
         cmd.Parameters.AddWithValue("@TestName", obj1.TestName);
         cmd.Parameters.AddWithValue("@TestRate", obj1.TestRate);
         cmd.Parameters.AddWithValue("@MobileNo", obj1.MobileNo);
         cmd.Parameters.AddWithValue("@ReferBy", obj1.ReferBy);
         cmd.Parameters.AddWithValue("@IPDNO", obj1.IpdNo);
         cmd.Parameters.AddWithValue("@MDY", obj1.MDY);
         cmd.Parameters.AddWithValue("@ReferPhy", obj1.ReferPhy);
         cmd.Parameters.AddWithValue("@OtherRefDoc", obj1.OtherRefDoc);

         cmd.Parameters.AddWithValue("@InsuranceID", obj1.InsuranceID);
         cmd.Parameters.AddWithValue("@InsuranceAmt", obj1.InsuranceAmt);
         cmd.Parameters.AddWithValue("@MainDocId", obj1.MainDocId);

         cmd.Parameters.AddWithValue("@PaidAmt", obj1.PaidAmt);
         cmd.Parameters.AddWithValue("@BalanceAmt", obj1.BalanceAmt);
         cmd.Parameters.AddWithValue("@DiscountAmt", obj1.DiscountAmt);
         cmd.Parameters.AddWithValue("@ModeOfPay", obj1.ModeOfPay);
         cmd.Parameters.AddWithValue("@LabPtype", obj1.LabPtype);

         cmd.Parameters.AddWithValue("@PatAddress", obj1.PatAddress);
         cmd.Parameters.AddWithValue("@PatBirthDate", obj1.PatBirthDate);
         cmd.Parameters.AddWithValue("@ClinicalHistory", obj1.ClinicalHistory);

         object Result = cmd.ExecuteScalar();


         con.Close();
         con.Dispose();
         return Convert.ToString(Result);
     }

     public string InsertEMR_LabServiceDetail_ReferToAdmission(BELBillDetails obj1)
     {
         SqlConnection con = DataAccess.ConInitForDC();
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_EMRLabServiceDetails_ReferToAdmission", con);
         cmd.CommandType = CommandType.StoredProcedure;


         cmd.Parameters.AddWithValue("@PatRegId", obj1.PatRegId);
         cmd.Parameters.AddWithValue("@BillNo", obj1.BillNo);
         cmd.Parameters.AddWithValue("@BillGroup", obj1.BillGroupName);
         cmd.Parameters.AddWithValue("@BillServiceId", obj1.BillServiceId);
         cmd.Parameters.AddWithValue("@DrId", obj1.EmployeeId);
         cmd.Parameters.AddWithValue("@BillServiceCharges", obj1.Charges);
         cmd.Parameters.AddWithValue("@TotalCharges", obj1.TotalCharges);
         cmd.Parameters.AddWithValue("@Qty", obj1.Qty);
         cmd.Parameters.AddWithValue("@ProcedureId", obj1.ProcedureId);
         cmd.Parameters.AddWithValue("@CreatedBy", obj1.CreatedBy);
         cmd.Parameters.AddWithValue("@FId", obj1.FId);
         cmd.Parameters.AddWithValue("@BranchId", obj1.BranchId);
         cmd.Parameters.AddWithValue("@OPDNo", obj1.OpdNo);
         cmd.Parameters.AddWithValue("@LabNo", obj1.LabNo);
         cmd.Parameters.AddWithValue("@MTCode", obj1.MTCode);
         cmd.Parameters.AddWithValue("@ReceiptNo", obj1.ReceiptNo);

         cmd.Parameters.AddWithValue("@Initial", obj1.Initial);
         cmd.Parameters.AddWithValue("@Sex", obj1.Sex);
         cmd.Parameters.AddWithValue("@PatientName", obj1.PatientName);
         cmd.Parameters.AddWithValue("@Age", obj1.Age);
         cmd.Parameters.AddWithValue("@RefDoc", obj1.RefDoc);
         cmd.Parameters.AddWithValue("@TestName", obj1.TestName);
         cmd.Parameters.AddWithValue("@TestRate", obj1.TestRate);
         cmd.Parameters.AddWithValue("@MobileNo", obj1.MobileNo);
         cmd.Parameters.AddWithValue("@ReferBy", obj1.ReferBy);
         cmd.Parameters.AddWithValue("@IPDNO", obj1.IpdNo);
         cmd.Parameters.AddWithValue("@MDY", obj1.MDY);
         cmd.Parameters.AddWithValue("@ReferPhy", obj1.ReferPhy);
         cmd.Parameters.AddWithValue("@OtherRefDoc", obj1.OtherRefDoc);

         cmd.Parameters.AddWithValue("@InsuranceID", obj1.InsuranceID);
         cmd.Parameters.AddWithValue("@InsuranceAmt", obj1.InsuranceAmt);
         cmd.Parameters.AddWithValue("@MainDocId", obj1.MainDocId);

         cmd.Parameters.AddWithValue("@PaidAmt", obj1.PaidAmt);
         cmd.Parameters.AddWithValue("@BalanceAmt", obj1.BalanceAmt);
         cmd.Parameters.AddWithValue("@DiscountAmt", obj1.DiscountAmt);
         cmd.Parameters.AddWithValue("@ModeOfPay", obj1.ModeOfPay);
         cmd.Parameters.AddWithValue("@LabPtype", obj1.LabPtype);

         cmd.Parameters.AddWithValue("@PatAddress", obj1.PatAddress);
         cmd.Parameters.AddWithValue("@PatBirthDate", obj1.PatBirthDate);
         cmd.Parameters.AddWithValue("@ClinicalHistory", obj1.ClinicalHistory);

         object Result = cmd.ExecuteScalar();


         con.Close();
         con.Dispose();
         return Convert.ToString(Result);
     }

     public DataTable Fill_InFantDetails(int Patregid, int IpdNo, int BillNo)
     {

         SqlConnection con = DataAccess.ConInitForDC();
         con.Open();
         SqlCommand cmd = new SqlCommand("SP_Fill_InFantDetails", con);
         cmd.CommandType = CommandType.StoredProcedure;
         cmd.Parameters.AddWithValue("@Patregid", Patregid);
         cmd.Parameters.AddWithValue("@IpdNo", IpdNo);
         cmd.Parameters.AddWithValue("@BillNo", BillNo);


         SqlDataAdapter sda = new SqlDataAdapter(cmd);
         DataTable ds = new DataTable();
         sda.Fill(ds);
         con.Close();
         con.Dispose();
         return ds;

     }

     public DataTable Fill_InFantDetails_Mother( int IpdNo)
     {

         SqlConnection con = DataAccess.ConInitForDC();
         con.Open();
         SqlCommand cmd = new SqlCommand("SP_Fill_InFantDetails_Mother", con);
         cmd.CommandType = CommandType.StoredProcedure;
         
         cmd.Parameters.AddWithValue("@IpdNo", IpdNo);
        


         SqlDataAdapter sda = new SqlDataAdapter(cmd);
         DataTable ds = new DataTable();
         sda.Fill(ds);
         con.Close();
         con.Dispose();
         return ds;

     }

     public string ShiftInfantServiceToMother(int IpdNo, int PatRegId, int BillServiceId)
     {
         SqlConnection con = DataAccess.ConInitForDC();
         con.Open();
         SqlCommand cmd = new SqlCommand("sp_ShiftInfantServiceToMother", con);
         cmd.CommandType = CommandType.StoredProcedure;

         cmd.Parameters.AddWithValue("@IpdNo", IpdNo);
         cmd.Parameters.AddWithValue("@Patregid", PatRegId);

         cmd.Parameters.AddWithValue("@BillServiceId", BillServiceId);
        

         object Result = cmd.ExecuteScalar();
         con.Close();
         con.Dispose();
         return Convert.ToString(Result);
     }

     public DataTable Check_InfiniteDischargePatients(int IPDNO, int PatRegId, int BranchId, string CreatedBy)
     {

         SqlConnection con = DataAccess.ConInitForDC();
         con.Open();
         SqlCommand cmd = new SqlCommand("SP_Check_InfiniteDischargePatients", con);
         cmd.CommandType = CommandType.StoredProcedure;
         cmd.Parameters.AddWithValue("@IpdNo", IPDNO);
         cmd.Parameters.AddWithValue("@Patregid", PatRegId);

         cmd.Parameters.AddWithValue("@BranchId", BranchId);
         cmd.Parameters.AddWithValue("@UserName", CreatedBy);

         SqlDataAdapter sda = new SqlDataAdapter(cmd);
         DataTable ds = new DataTable();
         sda.Fill(ds);
         con.Close();
         con.Dispose();
         return ds;

     }
     public DataSet FillGridIpdBillDetail_NursePost(BELBillDetails obj)
     {

         SqlConnection con = DataAccess.ConInitForDC();
         con.Open();
         SqlCommand cmd = new SqlCommand("SP_IPDBillServiceDetailsFillGrid_NursePost", con);
         cmd.CommandType = CommandType.StoredProcedure;
         cmd.Parameters.AddWithValue("@IpdId", obj.IpdId);
         cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);
         cmd.Parameters.AddWithValue("@PatRegId", obj.PatRegId);
         cmd.Parameters.AddWithValue("@FId", obj.FId);
         cmd.Parameters.AddWithValue("@BranchId", obj.BranchId);
         cmd.Parameters.AddWithValue("@BillServiceType", obj.BillTypeName);
         cmd.Parameters.AddWithValue("@CreatedBy", obj.CreatedBy);
         cmd.Parameters.AddWithValue("@Usertype", obj.Usertype);
         SqlDataAdapter sda = new SqlDataAdapter(cmd);
         DataSet ds = new DataSet();
         sda.Fill(ds);
         con.Close();
         con.Dispose();
         return ds;

     }
     public string InsertIPDBillDetail_NursePostCharge(BELBillDetails obj1)
     {
         SqlConnection con = DataAccess.ConInitForDC();
         con.Open();
         SqlCommand cmd = new SqlCommand("Sp_InsertIpdBillServiceDetails_NursePost", con);
         cmd.CommandType = CommandType.StoredProcedure;

         cmd.Parameters.AddWithValue("@IpdId", obj1.IpdId);
         cmd.Parameters.AddWithValue("@IpdNo", obj1.IpdNo);
         cmd.Parameters.AddWithValue("@PatRegId", obj1.PatRegId);
         cmd.Parameters.AddWithValue("@BillNo", obj1.BillNo);

         cmd.Parameters.AddWithValue("@BillGroupId", obj1.BillGroupId);
         cmd.Parameters.AddWithValue("@BillServiceId", obj1.BillServiceId);
         cmd.Parameters.AddWithValue("@DrId", obj1.EmployeeId);
         cmd.Parameters.AddWithValue("@DeptId", 0);
         cmd.Parameters.AddWithValue("@BillServiceCharges", obj1.Charges);
         cmd.Parameters.AddWithValue("@TotalCharges", obj1.TotalCharges);
         cmd.Parameters.AddWithValue("@Qty", obj1.Qty);
         cmd.Parameters.AddWithValue("@CreatedBy", obj1.CreatedBy);
         cmd.Parameters.AddWithValue("@FId", obj1.FId);
         cmd.Parameters.AddWithValue("@BranchId", obj1.BranchId);
         cmd.Parameters.AddWithValue("@Description", obj1.Description);
         cmd.Parameters.AddWithValue("@BillServiceType", obj1.BillTypeName);

         object Result = cmd.ExecuteScalar();
         con.Close();
         con.Dispose();
         return Convert.ToString(Result);
     }

     public string Insert_OTBookingForm(BELBillDetails obj1)
     {
         SqlConnection con = DataAccess.ConInitForDC();
         con.Open();
         SqlCommand cmd = new SqlCommand("SP_InsertOTBookingForm", con);
         cmd.CommandType = CommandType.StoredProcedure;


         cmd.Parameters.AddWithValue("@PatRegId", obj1.PatRegId);
         cmd.Parameters.AddWithValue("@SurgenId", obj1.Surgan);
         cmd.Parameters.AddWithValue("@OperationId", obj1.Operation);
         cmd.Parameters.AddWithValue("@OperationName", obj1.OperationName);
         cmd.Parameters.AddWithValue("@ScheduleSurgeryDate", obj1.ScheduleSurgeryDate);
         cmd.Parameters.AddWithValue("@EstimatedCost", obj1.EstimatedCost);
         cmd.Parameters.AddWithValue("@NonRefDeposit", obj1.NonRefDeposit);
        
         cmd.Parameters.AddWithValue("@CreatedBy", obj1.CreatedBy);
       
         cmd.Parameters.AddWithValue("@BranchId", obj1.BranchId);

        
         object Result = cmd.ExecuteScalar();
         con.Close();
         con.Dispose();
         return Convert.ToString(Result);
     }
}