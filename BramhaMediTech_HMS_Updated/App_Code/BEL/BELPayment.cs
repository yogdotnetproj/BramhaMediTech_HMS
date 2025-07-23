using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BELPayment
/// </summary>
public class BELPayment
{
	public BELPayment()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private int _PaymentId; public int PaymentId { get { return _PaymentId; } set { _PaymentId = value; } }

    /// <summary>
    /// BillId
    /// Sets And Gets BillId
    /// </summary>
    private int _BillId; public int BillId { get { return _BillId; } set { _BillId = value; } }


    /// <summary>
    /// BillAmount
    /// Sets And Gets BillAmount
    /// </summary>
    private decimal _BillAmount; public decimal BillAmount { get { return _BillAmount; } set { _BillAmount = value; } }


    /// <summary>
    /// BillAmountWithDisc
    /// Sets And Gets BillAmountWithDisc
    /// </summary>
    private decimal _BillAmountWithDisc; public decimal BillAmountWithDisc { get { return _BillAmountWithDisc; } set { _BillAmountWithDisc = value; } }
    /// <summary>
    /// UserName
    /// Sets And Gets UserName
    /// </summary>
    private string _UserName; public string UserName { get { return _UserName; } set { _UserName = value; } }

    private string _PatientName; public string PatientName { get { return _PatientName; } set { _PatientName = value; } }
    private int _PrnNo;

    public int PrnNo
    {
        get { return _PrnNo; }
        set { _PrnNo = value; }
    }
    private string _RegNo; public string RegNo { get { return _RegNo; } set { _RegNo = value; } }
    /// <summary>
    /// PaymentDate
    /// Sets And Gets PaymentDate
    /// </summary>
    private string _PaymentDate; public string PaymentDate { get { return _PaymentDate; } set { _PaymentDate = value; } }
    private int _TotalBillAmount;

    public int TotalBillAmount
    {
        get { return _TotalBillAmount; }
        set { _TotalBillAmount = value; }
    }
    /// <summary>
    /// DiscountPercent
    /// Sets And Gets DiscountPercent
    /// </summary>
    private decimal _DiscountPercent; public decimal DiscountPercent { get { return _DiscountPercent; } set { _DiscountPercent = value; } }

    /// <summary>
    /// Amount
    /// Sets And Gets Amount
    /// </summary>
    private decimal _Amount; public decimal Amount { get { return _Amount; } set { _Amount = value; } }



    /// <summary>
    /// PaymentTypeId
    /// Sets And Gets PaymentTypeId
    /// </summary>
    private int _PaymentTypeId; public int PaymentTypeId { get { return _PaymentTypeId; } set { _PaymentTypeId = value; } }
    /// <summary>
    /// String 
    /// </summary>
    private string _PaymentTypeName; public string PaymentTypeName { get { return _PaymentTypeName; } set { _PaymentTypeName = value; } }
    /// <summary>
    /// ReasonForDiscountId
    /// Sets And Gets ReasonForDiscountId
    /// </summary>
    private int _ReasonForDiscountId; public int ReasonForDiscountId { get { return _ReasonForDiscountId; } set { _ReasonForDiscountId = value; } }
    /// <summary>
    /// 
    /// </summary>
    private string _ReasonForDiscountName; public string ReasonForDiscountName { get { return _ReasonForDiscountName; } set { _ReasonForDiscountName = value; } }
    /// <summary>
    /// DiscountGivenById
    /// Sets And Gets DiscountGivenById
    /// </summary>
    private int _DiscountGivenById; public int DiscountGivenById { get { return _DiscountGivenById; } set { _DiscountGivenById = value; } }
    private string _DiscountGivenBy; public string DiscountGivenBy { get { return _DiscountGivenBy; } set { _DiscountGivenBy = value; } }
    /// <summary>
    /// DiscountGiven
    /// Sets And Gets DiscountGiven
    /// </summary>
    private decimal _DiscountGiven; public decimal DiscountGiven { get { return _DiscountGiven; } set { _DiscountGiven = value; } }
    private decimal _Balance; public decimal Balance { get { return _Balance; } set { _Balance = value; } }

    /// <summary>
    /// ReasonForBalanceId
    /// Sets And Gets ReasonForBalanceId
    /// </summary>
    private int _ReasonForBalanceId; public int ReasonForBalanceId { get { return _ReasonForBalanceId; } set { _ReasonForBalanceId = value; } }
    private string _ReasonForBalance; public string ReasonForBalance { get { return _ReasonForBalance; } set { _ReasonForBalance = value; } }


   
    private decimal _AmountPaid; public decimal AmountPaid { get { return _AmountPaid; } set { _AmountPaid = value; } }

    private decimal _AmountPaidPerTransaction; public decimal AmountPaidPerTransaction { get { return _AmountPaidPerTransaction; } set { _AmountPaidPerTransaction = value; } }

    private bool _IsActive; public bool IsActive { get { return _IsActive; } set { _IsActive = value; } }

    private string _CreatedBy; public string CreatedBy { get { return _CreatedBy; } set { _CreatedBy = value; } }

    
    private DateTime _CreatedDateTime; public DateTime CreatedDateTime { get { return _CreatedDateTime; } set { _CreatedDateTime = value; } }

    private string _UpdatedBy; public string UpdatedBy { get { return _UpdatedBy; } set { _UpdatedBy = value; } }

    
    private DateTime _UpdatedOn; public DateTime UpdatedOn { get { return _UpdatedOn; } set { _UpdatedOn = value; } }

    private string _ChequeCardNo; public string ChequeCardNo { get { return _ChequeCardNo; } set { _ChequeCardNo = value; } }
    private string _BankName; public string BankName { get { return _BankName; } set { _BankName = value; } }
    private string _ChequeDate; public string ChequeDate { get { return _ChequeDate; } set { _ChequeDate = value; } }
   
}