using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BEL
/// </summary>
public class BEL
{
    private int _DeptId;
    private string _DeptName;
    private string _CreatedBy;
    private string _UpdatedBy;
    private string _BatchNoPrev;

    private DateTime _CreatedOn;
    private DateTime _UpdatedOn;
    private int _BranchId;
    private int _Fid;

    private int _SuppId;
    private string _SuppName;
    private string _SuppDesc;

    private int _MfgCompId;
    private string _MfgCompName;
    private string _MfgCompDesc;

    private int _ItemId;
    private string _ItemName;
    private string _ItemDesc;
    private string _ItemStatus;
    private int _CategoryId;
    private string _CategoryName;

    private string _ReorderLevel;
    private decimal _CostPerUnit;




    //____________________Purchase Order_________________
    private int _PONo; 
    private int _InvoiceNo;
    private string _BatchNo;
    private int _PoId;
      
    private DateTime _date;
    private int _units;
    private int _NoOfPacks;
    private int _UnitsPerPack;
    private DateTime _Expdate;
    private string _Invoicedate;
    private string _InvoiceExpdate;

    private decimal _PerPackCost;
    private decimal _Amt;
    private decimal _TotalAmt;
    private decimal _Tax;
    private string _ChallanNo;
    //_________________Purchase Track____________
    private DateTime _FromDate;
    private DateTime _ToDate;

    //_________Indend request________________
    private int _ReqQty;
    private decimal _CurrStock;
    private int _VoucherNo;
    private int _ReqNo;
    private int _ReqId;
    private string _Remark;
    private int _ReqFrm;

    private int _PendingQty;
    private int _IssueQty;
    private string _RPIflag;
    private DateTime _ReqDate;
    private string _IssueDate;
    private int _IssueToDept;
    private int _IssueFromDept;

    private decimal _Quantity;
    private string _TestName;
    private string _TestCode;
    private int _ConsumptionId;

    private decimal _MainCurrentStock;
    private decimal _AdjustedStock;
    private string _AdjustmentType;

    public string _EmailId;
    public string _MobileNo;
    public string _PANNo;
    public string _GSTNo;

    private string _Usertype;

    public string Usertype
    {

        get { return _Usertype; }
        set { _Usertype = value; }
    }
    private int IssueTo;

    public int P_IssueTo
    {
        get { return IssueTo; }
        set { IssueTo = value; }
    }
    public string AdjustmentType
    {

        get { return _AdjustmentType; }
        set { _AdjustmentType = value; }
    }

    public decimal MainCurrentStock
    {
        get { return _MainCurrentStock; }
        set { _MainCurrentStock = value; }
    }

    public decimal AdjustedStock
    {
        get { return _AdjustedStock; }
        set { _AdjustedStock = value; }
    }

    public int ConsumptionId
    {
        get { return _ConsumptionId; }
        set { _ConsumptionId = value; }
    }
    
    public decimal Quantity
    {
        get { return _Quantity; }
        set { _Quantity = value; }
    }
    public string TestName
    {
        get { return _TestName; }
        set { _TestName = value; }
    }

    public string BatchNoPrev
    {
        get { return _BatchNoPrev; }
        set { _BatchNoPrev = value; }
    }
    public string TestCode
    {
        get { return _TestCode; }
        set { _TestCode = value; }
    }



    public DateTime ReqDate
    {
        get { return _ReqDate; }
        set { _ReqDate = value; }
    }
    public string IssueDate
    {
        get { return _IssueDate; }
        set { _IssueDate = value; }
    }
    public int PendingQty
    {
        get { return _PendingQty; }
        set { _PendingQty = value; }
    }

    public int IssueQty
    {
        get { return _IssueQty; }
        set { _IssueQty = value; }
    }
    public string RPIflag
    {
        get { return _RPIflag; }
        set { _RPIflag = value; }
    }
    public int ReqFrm
    {
        get { return _ReqFrm; }
        set { _ReqFrm = value; }
    }
    public int IssueToDept
    {
        get { return _IssueToDept; }
        set { _IssueToDept = value; }
    }
    public int IssueFromDept
    {
        get { return _IssueFromDept; }
        set { _IssueFromDept = value; }
    }

    public int ReqQty
    {
        get { return _ReqQty; }
        set { _ReqQty = value; }
    }
    public decimal CurrStock
    {
        get { return _CurrStock; }
        set { _CurrStock = value; }
    }
    public int VoucherNo
    {
        get { return _VoucherNo; }
        set { _VoucherNo = value; }
    }
    public int ReqNo
    {
        get { return _ReqNo; }
        set { _ReqNo = value; }
    }
    public int InvoiceNo
    {
        get { return _InvoiceNo; }
        set { _InvoiceNo = value; }
    }
    public int ReqId
    {
        get { return _ReqId; }
        set { _ReqId = value; }
    }
    public string Remark
    {
        get { return _Remark; }
        set { _Remark = value; }
    }

    public DateTime FromDate
    {
        get { return _FromDate; }
        set { _FromDate = value; }
    }
    public DateTime ToDate
    {
        get { return _ToDate; }
        set { _ToDate = value; }
    }

    public int PoId
    {
        get { return _PoId; }
        set { _PoId = value; }
    }

    public int PONo
    {
        get { return _PONo; }
        set { _PONo = value; }
    }
    
    public string BatchNo
    {
        get { return _BatchNo; }
        set { _BatchNo = value; }
    }
    public string ChallanNo
    {
        get { return _ChallanNo; }
        set { _ChallanNo = value; }
    }


    public DateTime date
    {
        get { return _date; }
        set { _date = value; }
    }
    public string Invoicedate
    {
        get { return _Invoicedate; }
        set { _Invoicedate = value; }
    }
    private string _GRNReturndate;
    public string GRNReturndate
    {
        get { return _GRNReturndate; }
        set { _GRNReturndate = value; }
    }
    public int units
    {
        get { return _units; }
        set { _units = value; }
    }
    public int UnitsPerPack
    {
        get { return _UnitsPerPack; }
        set { _UnitsPerPack = value; }
    }
    public int NoOfPacks
    {
        get { return _NoOfPacks; }
        set { _NoOfPacks = value; }
    }

    public decimal Amt
    {
        get { return _Amt; }
        set { _Amt = value; }
    }
    public decimal TotalAmt
    {
        get { return _TotalAmt; }
        set { _TotalAmt = value; }
    }
    private decimal _AmtWithoutTax;
    public decimal AmtWithoutTax
    {
        get { return _AmtWithoutTax; }
        set { _AmtWithoutTax = value; }
    }
    public decimal PerPackCost
    {
        get { return _PerPackCost; }
        set { _PerPackCost = value; }
    }
    public decimal Tax
    {
        get { return _Tax; }
        set { _Tax = value; }
    }

    public string ReorderLevel
    {
        get { return _ReorderLevel; }
        set { _ReorderLevel = value; }
    }
    public decimal CostPerUnit
    {
        get { return _CostPerUnit; }
        set { _CostPerUnit = value; }
    }

    private decimal _FreightCharges;
    public decimal FreightCharges
    {
        get { return _FreightCharges; }
        set { _FreightCharges = value; }
    }

    private decimal _GrandTotal;
    public decimal GrandTotal
    {
        get { return _GrandTotal; }
        set { _GrandTotal = value; }
    }

    //_______________________________________________

    private int _PatIssueVoucherId;
    public int PatIssueVoucherId
    {
        get { return _PatIssueVoucherId; }
        set { _PatIssueVoucherId = value; }
    }
    public int DeptId
    {
        get { return _DeptId; }
        set { _DeptId = value; }
    }
    public string DeptName
    {
        get { return _DeptName; }
        set { _DeptName = value; }
    }


    public int SuppId
    {
        get { return _SuppId; }
        set { _SuppId = value; }
    }
    public string SuppName
    {
        get { return _SuppName; }
        set { _SuppName = value; }
    }
    public string SuppDesc
    {
        get { return _SuppDesc; }
        set { _SuppDesc = value; }
    }

    public string MobileNo
    {
        get { return _MobileNo; }
        set { _MobileNo = value; }
    }
    public string PANNo
    {
        get { return _PANNo; }
        set { _PANNo = value; }
    }

    public string GSTNo
    {
        get { return _GSTNo; }
        set { _GSTNo = value; }
    }

    public string EmailId
    {
        get { return _EmailId; }
        set { _EmailId = value; }
    }
    

    public int CategoryId
    {
        get { return _CategoryId; }
        set { _CategoryId = value; }
    }
    public string CategoryName
    {
        get { return _CategoryName; }
        set { _CategoryName = value; }
    }

    public int MfgCompId
    {
        get { return _MfgCompId; }
        set { _MfgCompId = value; }
    }

    private string _TaxTypeName;
    public string TaxTypeName
    {
        get { return _TaxTypeName; }
        set { _TaxTypeName = value; }
    }

    public string MfgCompName
    {
        get { return _MfgCompName; }
        set { _MfgCompName = value; }
    }
    public string MfgCompDesc
    {
        get { return _MfgCompDesc; }
        set { _MfgCompDesc = value; }
    }
    private string _PatientType;
    public string PatientType
    {
        get { return _PatientType; }
        set { _PatientType = value; }
    }

    public int ItemId
    {
        get { return _ItemId; }
        set { _ItemId = value; }
    }
    public string ItemName
    {
        get { return _ItemName; }
        set { _ItemName = value; }
    }
    public string ItemDesc
    {
        get { return _ItemDesc; }
        set { _ItemDesc = value; }
    }
    public string ItemStatus
    {
        get { return _ItemStatus; }
        set { _ItemStatus = value; }
    }

    private string _SKU;
    public string SKU
    {
        get { return _SKU; }
        set { _SKU = value; }
    }

    private string _ItemType;
    public string ItemType
    {
        get { return _ItemType; }
        set { _ItemType = value; }
    }

    private int _TaxType;
    public int TaxType
    {
        get { return _TaxType; }
        set { _TaxType = value; }
    }

    private int _MainCategory;
    public int MainCategory
    {
        get { return _MainCategory; }
        set { _MainCategory = value; }
    }

    private int _MarkupOPD;
    public int MarkupOPD
    {
        get { return _MarkupOPD; }
        set { _MarkupOPD = value; }
    }

    private int _MarkupIPD;
    public int MarkupIPD
    {
        get { return _MarkupIPD; }
        set { _MarkupIPD = value; }
    }

    private int _UserID;
    public int UserID
    {
        get { return _UserID; }
        set { _UserID = value; }
    }
    public int BranchId
    {
        get { return _BranchId; }
        set { _BranchId = value; }
    }
    public int Fid
    {
        get { return _Fid; }
        set { _Fid = value; }
    }
    
    public string CreatedBy
    {
        get { return _CreatedBy; }
        set { _CreatedBy = value; }
    }
    public DateTime CreatedOn
    {
        get { return _CreatedOn; }
        set { _CreatedOn = value; }
    }
    public DateTime UpdatedOn
    {
        get { return _UpdatedOn; }
        set { _UpdatedOn = value; }
    }
    public string UpdatedBy
    {
        get { return _UpdatedBy; }
        set { _UpdatedBy = value; }
    }

    public DateTime Expdate
    {
        get { return _Expdate; }
        set { _Expdate = value; }
    }
    public string InvoiceExpdate
    {
        get { return _InvoiceExpdate; }
        set { _InvoiceExpdate = value; }
    }

    private string _PaymentStaus;
    public string PaymentStaus
    {
        get { return _PaymentStaus; }
        set { _PaymentStaus = value; }
    }

    private decimal _SumOfTotalAmt;
    public decimal SumOfTotalAmt
    {
        get { return _SumOfTotalAmt; }
        set { _SumOfTotalAmt = value; }
    }
    private decimal _TotalTax;
    public decimal TotalTax
    {
        get { return _TotalTax; }
        set { _TotalTax = value; }
    }

    private decimal _BalanceAmount;
    public decimal BalanceAmount
    {
       get { return _BalanceAmount; }
       set  {_BalanceAmount=value; }
    }

    private decimal _AmountPaid;
    public decimal AmountPaid 
    {
        get { return _AmountPaid; }
        set { _AmountPaid = value; }
    }
    private decimal _BillAmount;
    public decimal BillAmount
    {
        get { return _BillAmount; }
        set { _BillAmount = value; }
    }
    private decimal _BillAmountWithDisc;
    public decimal BillAmountWithDisc
    {
        get { return _BillAmountWithDisc; }
        set { _BillAmountWithDisc = value; }
    }
    private string _BillNo;
    public string BillNo
    {
        get { return _BillNo; }
        set { _BillNo = value; }
    }
    private decimal _DiscountAmount;
    public decimal DiscountAmount 
    {
        get { return _DiscountAmount; }
        set { _DiscountAmount = value; }
    }
    private string _DiscountGivenBy;
     public string  DiscountGivenBy
    {
        get { return _DiscountGivenBy; }
        set { _DiscountGivenBy = value; }
    }
    private int _DiscountGivenById;
    public int DiscountGivenById 
    {
        get { return _DiscountGivenById; }
        set { _DiscountGivenById = value; }
    }
    private decimal _DiscountPercent; 
    public decimal DiscountPercent 
    {
        get { return _DiscountPercent; }
        set { _DiscountPercent = value; }
    }
    private bool _IsActive;
    public bool IsActive
    {
        get { return _IsActive; }
        set { _IsActive = value; }
    }
    private int _PaymentId;
    public int PaymentId 
    {
        get { return _PaymentId; }
        set { _PaymentId = value; }
    }
    private int _PaymentDetailId;
    public int PaymentDetailId
    {
        get { return _PaymentDetailId; }
        set { _PaymentDetailId = value; }
    }
    private int _InvoiceDetailId;
    public int InvoiceDetailId
    {
        get { return _InvoiceDetailId; }
        set { _InvoiceDetailId = value; }
    }
    private int _PaymentTypeId;
    public int PaymentTypeId
    {
        get { return _PaymentTypeId; }
        set { _PaymentTypeId = value; }
    }
    private string _PaymentTypeName;
    public string PaymentTypeName 
    {
        get { return PaymentTypeName; }
        set { PaymentTypeName = value; }
    }
    private string _Paymentdate;
    public string Paymentdate
    {
        get { return _Paymentdate; }
        set { _Paymentdate = value; }
    }
    private string _Chequedate;
    public string Chequedate
    {
        get { return _Chequedate; }
        set { _Chequedate = value; }
    }
    private string _BankName;
    public string BankName
    {
        get { return _BankName; }
        set { _BankName = value; }
    }
    private string _ChequeNumber;
    public string ChequeNumber
    {
        get { return _ChequeNumber; }
        set { _ChequeNumber = value; }
    }
    private decimal _SellingPrice;
    public decimal SellingPrice
    {
        get { return _SellingPrice; }
        set { _SellingPrice = value; }
    }
    private string _ConsumptionDate;
    public string ConsumptionDate
    {
        get { return _ConsumptionDate; }
        set { _ConsumptionDate = value; }
    }

    private decimal _PrescItemPer;
     public decimal PrescItemPer
    {
        get { return _PrescItemPer; }
        set { _PrescItemPer = value; }
    }

     private decimal _CounterItemPer;
     public decimal CounterItemPer
     {
         get { return _CounterItemPer; }
         set { _CounterItemPer = value; }
     }

    private string _IsApprove;
    public string IsApprove
    {
        get { return _IsApprove; }
        set { _IsApprove = value; }
    }
    private int _InvoiceId;
    public int InvoiceId
    {
        get { return _InvoiceId; }
        set { _InvoiceId = value; }
    }
    private decimal _TaxPercentage;
    public decimal TaxPercentage
    {
        get { return _TaxPercentage; }
        set { _TaxPercentage = value; }
    }

    private int _IndreqDeptId;
    public int IndreqDeptId
    {
        get { return _IndreqDeptId; }
        set { _IndreqDeptId = value; }
    }

    private int _IndReq;
    public int IndReq
    {
        get { return _IndReq; }
        set { _IndReq = value; }
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
    private  int _Age;
    public int Age
    {
        get { return _Age; }
        set { _Age = value; }
    }
    private string _AgeType;
    public string AgeType
    {
        get { return _AgeType; }
        set { _AgeType = value; }

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

    private string _Allergy;
    public string Allergy
    {
        get { return _Allergy; }
        set { _Allergy = value; }
    }
    private int _DrId;
    public int DrId
    {
        get { return _DrId; }
        set { _DrId = value; }
    }
    private string _Gender;
    public string Gender
    {
        get { return _Gender; }
        set { _Gender = value; }
    }

    private int _PackageId;
    public int PackageId
    {
        get { return _PackageId; }
        set { _PackageId = value; }
    }
    private string _PackageName;
    public string PackageName
    {
        get { return _PackageName; }
        set { _PackageName = value; }
    }
    private int _PackageDetailId;
    public int PackageDetailId
    {
        get { return _PackageDetailId; }
        set { _PackageDetailId = value; }
    }
    private int _StockAdjustId;
    public int StockAdjustId
    {
        get { return _StockAdjustId; }
        set { _StockAdjustId = value; }
    }
    private int _StockAdjustMainId;
    public int StockAdjustMainId
    {
        get { return _StockAdjustMainId; }
        set { _StockAdjustMainId = value; }
    }
    private int _DeptStockAdjustMainId;
    public int DeptStockAdjustMainId
    {
        get { return _DeptStockAdjustMainId; }
        set { _DeptStockAdjustMainId = value; }
    }
    private int _Usage3Months;
    public int Usage3Months
    {
        get { return _Usage3Months; }
        set { _Usage3Months = value; }
    }

    private string _PODate;
    public string PODate
    {
        get { return _PODate; }
        set { _PODate = value; }
    }
    private int _PackQty;
    public int PackQty
    {
        get { return _PackQty; }
        set { _PackQty = value; }
    }
    private decimal _PrevCost;
    public decimal PrevCost
    {
        get { return _PrevCost; }
        set { _PrevCost = value; }
    }
    private bool _IsEmergency;
    public bool IsEmergency
    {
        get { return _IsEmergency; }
        set { _IsEmergency = value; }
    }
    private bool _IsProcess;
    public bool IsProcess
    {
        get { return _IsProcess; }
        set { _IsProcess = value; }
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


    private float _Dis;
    public float Dis
    {
        get { return _Dis; }
        set { _Dis = value; }
    }
    private float _NO_PAck;
    public float NO_PAck
    {
        get { return _NO_PAck; }
        set { _NO_PAck = value; }
    }
    private float _UnitPack;
    public float UnitPack
    {
        get { return _UnitPack; }
        set { _UnitPack = value; }
    }
    private float _PackCost;
     public float PackCost
    {
        get { return _PackCost; }
        set { _PackCost = value; }
    }

     private int _DeptReorderLevel;  public int DeptReorderLevel  {   get { return _DeptReorderLevel; }  set { _DeptReorderLevel = value; }  }

     private int _MedicineTypeId; public int MedicineTypeId { get { return _MedicineTypeId; } set { _MedicineTypeId = value; } }
     private int _PackSizeID; public int PackSizeID { get { return _PackSizeID; } set { _PackSizeID = value; } }
     private int _SubcatID; public int SubcatID { get { return _SubcatID; } set { _SubcatID = value; } }

     private int _WareHouseId; public int WareHouseId { get { return _WareHouseId; } set { _WareHouseId = value; } }
     private int _Issue_ToWareHouseId; public int Issue_ToWareHouseId { get { return _Issue_ToWareHouseId; } set { _Issue_ToWareHouseId = value; } }
    
     private float _MRP; public float MRP { get { return _MRP; } set { _MRP = value; } }

     private bool _ExpiryDtRequired; public bool ExpiryDtRequired { get { return _ExpiryDtRequired; } set { _ExpiryDtRequired = value; } }
     private bool _BatchRequired; public bool BatchRequired { get { return _BatchRequired; } set { _BatchRequired = value; } }
     private bool _IsNonChargable; public bool IsNonChargable { get { return _IsNonChargable; } set { _IsNonChargable = value; } }
     private bool _NoMrp; public bool NoMrp { get { return _NoMrp; } set { _NoMrp = value; } }
     private bool _Asset; public bool Asset { get { return _Asset; } set { _Asset = value; } }
     private bool _HighValueFlag; public bool HighValueFlag { get { return _HighValueFlag; } set { _HighValueFlag = value; } }

     private bool _scheduledItem; public bool scheduledItem { get { return _scheduledItem; } set { _scheduledItem = value; } }
     private bool _narcoticItem; public bool narcoticItem { get { return _narcoticItem; } set { _narcoticItem = value; } }
     private bool _CriticalMedicine; public bool CriticalMedicine { get { return _CriticalMedicine; } set { _CriticalMedicine = value; } }
     private bool _Isxrayfilm; public bool Isxrayfilm { get { return _Isxrayfilm; } set { _Isxrayfilm = value; } }

     private bool _IsApproval; public bool IsApproval { get { return _IsApproval; } set { _IsApproval = value; } }
     private bool _Active; public bool Active { get { return _Active; } set { _Active = value; } }

     private int _PatMainTypeId;

     public int PatMainTypeId { get { return _PatMainTypeId; } set { _PatMainTypeId = value; } }

     private string _PatMainType;

     public string PatMainType { get { return _PatMainType; } set { _PatMainType = value; } }

     private int _PatientInsuTypeId;
     public int PatientInsuTypeId { get { return _PatientInsuTypeId; } set { _PatientInsuTypeId = value; } }

     private int _PatientInsuSubTypeId;
     public int PatientInsuSubTypeId { get { return _PatientInsuSubTypeId; } set { _PatientInsuSubTypeId = value; } }



     private string _PatientInsuType;
     public string PatientInsuType { get { return _PatientInsuType; } set { _PatientInsuType = value; } }

     private string _PatientInsuSubType;
     public string PatientInsuSubType { get { return _PatientInsuSubType; } set { _PatientInsuSubType = value; } }
    
}