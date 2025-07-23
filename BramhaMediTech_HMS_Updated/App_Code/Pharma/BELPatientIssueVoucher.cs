using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BELPatientIssueVoucher
/// </summary>
public class BELPatientIssueVoucher
{
	public BELPatientIssueVoucher()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    private int _PatIssueVoucherDetailId;
    public int PatIssueVoucherDetailId
    {
        get { return _PatIssueVoucherDetailId; }
        set { _PatIssueVoucherDetailId = value; }
    }
    private int _DoseId;
    public int DoseId
    {
        get { return _DoseId; }
        set { _DoseId = value; }
    }
    private int _DoseTimeId;
    public int DoseTimeId
    {
        get { return _DoseTimeId; }
        set { _DoseTimeId = value; }
    }
    private string _DoseTimeName;
    public string DoseTimeName
    {
        get { return _DoseTimeName; }
        set { _DoseTimeName = value; }
    }
    private string _DoseName;
    public string DoseName
    {
        get { return _DoseName; }
        set { _DoseName = value; }
    }
    private decimal _Days;
    public decimal Days
    {
        get { return _Days; }
        set { _Days = value; }
    }
    private int _ItemId;
    public int ItemId
    {
        get { return _ItemId; }
        set { _ItemId = value; }
    }
    private int _DeptId;
    public int DeptId
    {
        get { return _DeptId; }
        set { _DeptId = value; }
    }
    private int _OpdNo;
    public int OpdNo
    {
        get { return _OpdNo; }
        set { _OpdNo = value; }
    }
    private int _IpdNo;
    public int IpdNo
    {
        get { return _IpdNo; }
        set { _IpdNo = value; }
    }

    private string _ItemName;
    public string ItemName
    {
        get { return _ItemName; }
        set { _ItemName = value; }
    }
    private int _BranchId;
    public int BranchId
    {
        get { return _BranchId; }
        set { _BranchId = value; }
    }
    private int _wareHouseId;
    public int wareHouseId
    {
        get { return _wareHouseId; }
        set { _wareHouseId = value; }
    }
    
    private int _BillNo;
    public int BillNo
    {
        get { return _BillNo; }
        set { _BillNo = value; }
    }
     private int _Fid;
    public int Fid
    {
        get { return _Fid; }
        set { _Fid = value; }
    }
    private int _IssueQty;
    public int IssueQty
    {
        get { return _IssueQty; }
        set { _IssueQty = value; }
    }

    private int _IssueTo;
    public int IssueTo
    {
        get { return _IssueTo; }
        set { _IssueTo = value; }
    }

    private string _CreatedBy;
    public string CreatedBy
    {
        get { return _CreatedBy; }
        set { _CreatedBy = value; }
    }
    private DateTime _CreatedOn;
    public DateTime CreatedOn
    {
        get { return _CreatedOn; }
        set { _CreatedOn = value; }
    }
    private DateTime _UpdatedOn;
    public DateTime UpdatedOn
    {
        get { return _UpdatedOn; }
        set { _UpdatedOn = value; }
    }
    private string _UpdatedBy;
    public string UpdatedBy
    {
        get { return _UpdatedBy; }
        set { _UpdatedBy = value; }
    }

    private string _InvoiceExpdate;
    public string InvoiceExpdate
    {
        get { return _InvoiceExpdate; }
        set { _InvoiceExpdate = value; }
    }
    private string _BatchNo;
    public string BatchNo
    {
        get { return _BatchNo; }
        set { _BatchNo = value; }
    }
    private decimal _CounterItemPerIPD;
    public decimal CounterItemPerIPD
    {
        get { return _CounterItemPerIPD; }
        set { _CounterItemPerIPD = value; }
    }
    private decimal _PrescItemPerIPD;
    public decimal PrescItemPerIPD
    {
        get { return _PrescItemPerIPD; }
        set { _PrescItemPerIPD = value; }
    }
    private int _StoreType;
    public int StoreType
    {
        get { return _StoreType; }
        set { _StoreType = value; }
    }
    private string _PatientType;
    public string PatientType
    {
        get { return _PatientType; }
        set { _PatientType = value; }
    }
    private string _DrName;
    public string DrName
    {
        get { return _DrName; }
        set { _DrName = value; }
    }
    private string _PatientName;
    public string PatientName
    {
        get { return _PatientName; }
        set { _PatientName = value; }

    }
    private int _Age;
    public int Age
    {
        get { return _Age; }
        set { _Age = value; }
    }
    private int _DrId;
    public int DrId
    {
        get { return _DrId; }
        set { _DrId = value; }
    }

    private string _AgeType;
    public string AgeType
    {
        get { return _AgeType; }
        set { _AgeType = value; }

    }
    private string _DiscType;
    public string DiscType
    {
        get { return _DiscType; }
        set { _DiscType = value; }

    }
    private string _PaymentType;
    public string PaymentType
    {
        get { return _PaymentType; }
        set { _PaymentType = value; }

    }
    private bool _IsInsuranceFlag;
    public bool IsInsuranceFlag
    {
        get { return _IsInsuranceFlag; }
        set { _IsInsuranceFlag = value; }

    }
    private string _PatRegNo;
    public string PatRegNo
    {
        get { return _PatRegNo; }
        set { _PatRegNo = value; }
    }
    private string _PatAddress;
    public string PatAddress
    {
        get { return _PatAddress; }
        set { _PatAddress = value; }
    }

    private string _Allergies;
    public string Allergies
    {
        get { return _Allergies; }
        set { _Allergies = value; }
    }

    private int _IssueVoucherNo;
    public int IssueVoucherNo
    {
        get { return _IssueVoucherNo; }
        set { _IssueVoucherNo = value; }
    }
    private string _Issuedate;
    public string Issuedate
    {
        get { return _Issuedate; }
        set { _Issuedate = value; }
    }
    private string _Note;
    public string Note
    {
        get { return _Note; }
        set { _Note = value; }
    }

    private decimal _TotalAmt;
    public decimal TotalAmt
    {
        get { return _TotalAmt; }
        set { _TotalAmt = value; }
    }
    private decimal _GrandTotal;
    public decimal GrandTotal
    {
        get { return _GrandTotal; }
        set { _GrandTotal = value; }
    }
    private decimal _TotalTax;
    public decimal TotalTax
    {
        get { return _TotalTax; }
        set { _TotalTax = value; }
    }
    private decimal _Tax;
    public decimal Tax
    {
        get { return _Tax; }
        set { _Tax = value; }
    }
    private decimal _Rate;
    public decimal Rate
    {
        get { return _Rate; }
        set { _Rate = value; }
    }
    private decimal _Balance;
    public decimal Balance
    {
        get { return _Balance; }
        set { _Balance = value; }
    }

    private decimal _AmountReceived;
    public decimal AmountReceived
    {
        get { return _AmountReceived; }
        set { _AmountReceived = value; }
    }

    private decimal _DiscAmt;
    public decimal DiscAmt
    {
        get { return _DiscAmt; }
        set { _DiscAmt = value; }
    }
    private string _DiscRemark;
    public string DiscRemark
    {
        get { return _DiscRemark; }
        set { _DiscRemark = value; }
    }
    
    private decimal _DiscountPercent;
    public decimal DiscountPercent
    {
        get { return _DiscountPercent; }
        set { _DiscountPercent = value; }
    }
    private string _ChequeNo;
    public string ChequeNo
    {
        get { return _ChequeNo; }
        set { _ChequeNo = value; }
    }
    private string  _BankName;
	public string BankName
    {
        get { return _BankName; }
        set { _BankName = value; }
    }

    private string  _InsuranceComp;
	public string InsuranceComp
    {
        get { return _InsuranceComp; }
        set { _InsuranceComp = value; }
    }

    private int _InsuranceComp_ID;
    public int  InsuranceComp_ID
    {
        get { return _InsuranceComp_ID; }
        set { _InsuranceComp_ID = value; }
    }

    private int _InsuranceChildComp_ID;
    public int InsuranceChildComp_ID
    {
        get { return _InsuranceChildComp_ID; }
        set { _InsuranceChildComp_ID = value; }
    }
    private int _PatientMainType;
    public int PatientMainType
    {
        get { return _PatientMainType; }
        set { _PatientMainType = value; }
    }
    

    private decimal _InsuranceAmount;
    public decimal InsuranceAmount
    {
        get { return _InsuranceAmount; }
        set { _InsuranceAmount = value; }
    }

    private string  _StaffName;
	public string StaffName
    {
        get { return _StaffName; }
        set { _StaffName = value; }
    } 

    private string  _StaffRemark;
	public string StaffRemark
    {
        get { return _StaffRemark; }
        set { _StaffRemark = value; }
    }
    private string _Remark;
    public string Remark
    {
        get { return _Remark; }
        set { _Remark = value; }
    }  
     private string _InstName;
    public string InstName
    {
        get { return _InstName; }
        set { _InstName = value; }
    }
    private string _NewDose;
    public string NewDose
    {
        get { return _NewDose; }
        set { _NewDose = value; }
    } 
    

        
    private string  _CardName;
	public string CardName
    {
        get { return _CardName; }
        set { _CardName = value; }
    }

    private int _PatIssueVoucherId;
    public int PatIssueVoucherId
    {
        get { return _PatIssueVoucherId; }
        set { _PatIssueVoucherId = value; }
    }
    private decimal _CurrentStock;
    public decimal CurrentStock
    {
        get { return _CurrentStock; }
        set { _CurrentStock = value; }
    }
    private int _TreatmentId;
    public int TreatmentId
    {
        get { return _TreatmentId; }
        set { _TreatmentId = value; }
    }
    private bool _IsEmergency;
    public bool IsEmergency
    {
        get { return _IsEmergency; }
        set { _IsEmergency = value; }

    }
    private int _UnitId;
    public int UnitId
    {
        get { return _UnitId; }
        set { _UnitId = value; }
    }
    private int _ManConsumptionId;
    public int ManConsumptionId
    {
        get { return _ManConsumptionId; }
        set { _ManConsumptionId = value; }
    }
    
}