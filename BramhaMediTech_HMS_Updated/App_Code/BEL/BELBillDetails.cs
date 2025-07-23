using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BELBillDetails
/// </summary>
public class BELBillDetails
{
	public BELBillDetails()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private int _ReceiptNo;

    public int ReceiptNo
    {
        get { return _ReceiptNo; }
        set { _ReceiptNo = value; }
    }
    private int _BillDetailId;

    public int BillDetailId
    {
        get { return _BillDetailId; }
        set { _BillDetailId = value; }
    }
    private int _IpdBillServiceDetailId;

    public int IpdBillServiceDetailId
    {
        get { return _IpdBillServiceDetailId; }
        set { _IpdBillServiceDetailId = value; }
    }

    private int _Amount;
    public int Amount
    {
        get { return _Amount; }
        set { _Amount = value; }
    }

    private int _BillId;
    public int BillId
    {
        get { return _BillId; }
        set { _BillId = value; }
    }

    private int _OpdNo;
    public int OpdNo
    {
        get { return _OpdNo; }
        set { _OpdNo = value; }
    }
    private int _LabNo;
    public int LabNo
    {
        get { return _LabNo; }
        set { _LabNo = value; }
    }
    private string _MTCode;
    public string MTCode
    {
        get { return _MTCode; }
        set { _MTCode = value; }
    }

    private string _ClinicalHistory;
     public string ClinicalHistory
    {
        get { return _ClinicalHistory; }
        set { _ClinicalHistory = value; }
    }

    
    private int _IpdNo;
    public int IpdNo
    {
        get { return _IpdNo; }
        set { _IpdNo = value; }
    }
    private int _IpdId;
    public int IpdId
    {
        get { return _IpdId; }
        set { _IpdId = value; }
    }
    private int _PatRegId;
    public int PatRegId
    {
        get { return _PatRegId; }
        set { _PatRegId = value; }
    }
    private int _FId;
    public int FId
    {
        get { return _FId; }
        set { _FId = value; }
    }
    private int _BranchId;
    public int BranchId
    {
        get { return _BranchId; }
        set { _BranchId = value; }
    }
    private int _BillNo;

    public int BillNo
    {
        get { return _BillNo; }
        set { _BillNo = value; }
    }
    private int _BillGroupId;
    public int BillGroupId
    {
        get { return _BillGroupId; }
        set { _BillGroupId = value; }
    }


    private string _BillGroupName;
    public string BillGroupName
    {
        get { return _BillGroupName; }
        set { _BillGroupName = value; }
    }

    private string _InfantPatient;
    public string InfantPatient
    {
        get { return _InfantPatient; }
        set { _InfantPatient = value; }
    }

    private string _ReasonforDiscount;
     public string ReasonforDiscount
    {
        get { return _ReasonforDiscount; }
        set { _ReasonforDiscount = value; }
    }
     private string _DiscountGivenBy;
     public string DiscountGivenBy
     {
         get { return _DiscountGivenBy; }
         set { _DiscountGivenBy = value; }
     }
    

    private string _Description;

    public string Description
    {
        get { return _Description; }
        set { _Description = value; }
    }
    private int _BillServiceId;

    public int BillServiceId
    {
        get { return _BillServiceId; }
        set { _BillServiceId = value; }
    }

    private string _BillParticular;

    public string BillParticular
    {
        get { return _BillParticular; }
        set { _BillParticular = value; }
    }

    private int _EmployeeId;

    public int EmployeeId
    {
        get { return _EmployeeId; }
        set { _EmployeeId = value; }
    }
    private int _DeptId;

    public int DeptId
    {
        get { return _DeptId; }
        set { _DeptId = value; }
    }
    private string _EmployeeName;
    public string EmployeeName
    {
        get { return _EmployeeName; }
        set { _EmployeeName = value; }
    }

    private string _ServiceName;
    public string ServiceName
    {
        get { return _ServiceName; }
        set { _ServiceName = value; }
    }
    private string _ItemName;
    public string ItemName
    {
        get { return _ItemName; }
        set { _ItemName = value; }
    }
    private int _ItemId;
    public int ItemId
    {
        get { return _ItemId; }
        set { _ItemId = value; }
    }
    private string _PatientName;
    public string PatientName
    {
        get { return _PatientName; }
        set { _PatientName = value; }
    }

    private string _Initial;
    public string Initial
    {
        get { return _Initial; }
        set { _Initial = value; }
    }

    private string _Age;
    public string Age
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
    private string _RefDoc;
    public string RefDoc
    {
        get { return _RefDoc; }
        set { _RefDoc = value; }
    }
    private string _TestName;
    public string TestName
    {
        get { return _TestName; }
        set { _TestName = value; }
    }
    private string _MobileNo;
    public string MobileNo
    {
        get { return _MobileNo; }
        set { _MobileNo = value; }
    }
    private string _MDY;
    public string MDY
    {
        get { return _MDY; }
        set { _MDY = value; }
    }

    private string _ReferBy;
    public string ReferBy
    {
        get { return _ReferBy; }
        set { _ReferBy = value; }
    }
     private string _ReferPhy;
    public string ReferPhy
    {
        get { return _ReferPhy; }
        set { _ReferPhy = value; }
    }
    private string _OtherRefDoc;
      public string OtherRefDoc
    {
        get { return _OtherRefDoc; }
        set { _OtherRefDoc = value; }
    }
      private int _InsuranceID;
    public int InsuranceID
    {
        get { return _InsuranceID; }
        set { _InsuranceID = value; }
    }

    private float _InsuranceAmt;
 public float InsuranceAmt
    {
        get { return _InsuranceAmt; }
        set { _InsuranceAmt = value; }
    }
     private float _PaidAmt;
     public float PaidAmt
    {
        get { return _PaidAmt; }
        set { _PaidAmt = value; }
    }
         private float _BalanceAmt;
         public float BalanceAmt
    {
        get { return _BalanceAmt; }
        set { _BalanceAmt = value; }
    }

         private float _DiscountAmt;
         public float DiscountAmt
    {
        get { return _DiscountAmt; }
        set { _DiscountAmt = value; }
    }
        
     private int _MainDocId;
     public int MainDocId
    {
        get { return _MainDocId; }
        set { _MainDocId = value; }
    }
     private string _ModeOfPay;
      public string ModeOfPay
    {
        get { return _ModeOfPay; }
        set { _ModeOfPay = value; }
    }
      private string _LabPtype;
    public string LabPtype
    {
        get { return _LabPtype; }
        set { _LabPtype = value; }
    }
    private string  _RepType;
     public string RepType
    {
        get { return _RepType; }
        set { _RepType = value; }
    }
    

    private string _PatAddress;
    public string PatAddress
    {
        get { return _PatAddress; }
        set { _PatAddress = value; }
    }
    private string _Email;
     public string Email
    {
        get { return _Email; }
        set { _Email = value; }
    }

     private string _CenterName;
     public string CenterName
    {
        get { return _CenterName; }
        set { _CenterName = value; }
    }
    
    
    private string _MainDoctor;
      public string MainDoctor
    {
        get { return _MainDoctor; }
        set { _MainDoctor = value; }
    }
    

    private DateTime _PatBirthDate; public DateTime PatBirthDate { get { return _PatBirthDate; } set { _PatBirthDate = value; } }
    private float _TestRate;
    public float TestRate
    {
        get { return _TestRate; }
        set { _TestRate = value; }
    }
    private string _Note;

    public string Note
    {
        get { return _Note; }
        set { _Note = value; }
    }
    private int _BillStatusId;

    public int BillStatusId
    {
        get { return _BillStatusId; }
        set { _BillStatusId = value; }
    }
    private string _BillStatusName;

    public string BillStatusName
    {
        get { return _BillStatusName; }
        set { _BillStatusName = value; }
    }
    private int _BillTypeId;

    public int BillTypeId
    {
        get { return _BillTypeId; }
        set { _BillTypeId = value; }
    }
    private int _NoOfTimes;

    private string _BillTypeName;

    public string BillTypeName
    {
        get { return _BillTypeName; }
        set { _BillTypeName = value; }
    }
    public int NoOfTimes
    {
        get { return _NoOfTimes; }
        set { _NoOfTimes = value; }
    }


    private string _BillDetailDatetime;
    public string BillDetailDatetime
    {
        get { return _BillDetailDatetime; }
        set { _BillDetailDatetime = value; }
    }


    private decimal _Qty;
    public decimal Qty
    {
        get { return _Qty; }
        set { _Qty = value; }
    }
    private decimal _Charges;

    public decimal Charges
    {
        get { return _Charges; }
        set { _Charges = value; }
    }

    private decimal _TotalCharges;

    public decimal TotalCharges
    {
        get { return _TotalCharges; }
        set { _TotalCharges = value; }
    }
    private decimal _ConcessionPercent;

    public decimal ConcessionPercent
    {
        get { return _ConcessionPercent; }
        set { _ConcessionPercent = value; }
    }

    private decimal _ConcessionAmount;

    public decimal ConcessionAmount
    {
        get { return _ConcessionAmount; }
        set { _ConcessionAmount = value; }
    }

    private int _IPDFixChargesId;
    public int IPDFixChargesId
    {
        get { return _IPDFixChargesId; }
        set { _IPDFixChargesId = value; }
    }



    private int _ReasonForBalanceId; public int ReasonForBalanceId { get { return _ReasonForBalanceId; } set { _ReasonForBalanceId = value; } }

    private bool _IsActive; public bool IsActive { get { return _IsActive; } set { _IsActive = value; } }
    private string _CreatedBy; public string CreatedBy { get { return _CreatedBy; } set { _CreatedBy = value; } }
    private string _Usertype; public string Usertype { get { return _Usertype; } set { _Usertype = value; } }
    
    private DateTime _CreatedDateTime; public DateTime CreatedDateTime { get { return _CreatedDateTime; } set { _CreatedDateTime = value; } }
    private string _UpdatedBy; public string UpdatedBy { get { return _UpdatedBy; } set { _UpdatedBy = value; } }
    private DateTime _UpdatedDateTime; public DateTime UpdatedDateTime { get { return _UpdatedDateTime; } set { _UpdatedDateTime = value; } }


    private int _Surgan; public int Surgan { get { return _Surgan; } set { _Surgan = value; } }
    private int _ANAESTHETIST; public int ANAESTHETIST { get { return _ANAESTHETIST; } set { _ANAESTHETIST = value; } }
    private int _FirstAssistant; public int FirstAssistant { get { return _FirstAssistant; } set { _FirstAssistant = value; } }
    private string _SecondAssistant; public string SecondAssistant { get { return _SecondAssistant; } set { _SecondAssistant = value; } }
    private int _TrollyNurse; public int TrollyNurse { get { return _TrollyNurse; } set { _TrollyNurse = value; } }
    private int _SteriNurse; public int SteriNurse { get { return _SteriNurse; } set { _SteriNurse = value; } }
    private int _Disease; public int Disease { get { return _Disease; } set { _Disease = value; } }
    private int _Operation; public int Operation { get { return _Operation; } set { _Operation = value; } }
    private int _SwabCountNurse; public int SwabCountNurse { get { return _SwabCountNurse; } set { _SwabCountNurse = value; } }
    private int _InstrumentCountNurse; public int InstrumentCountNurse { get { return _InstrumentCountNurse; } set { _InstrumentCountNurse = value; } }

    private string _OperationStartTime; public string OperationStartTime { get { return _OperationStartTime; } set { _OperationStartTime = value; } }
    private string _OperationEndTime; public string OperationEndTime { get { return _OperationEndTime; } set { _OperationEndTime = value; } }

    private string _OperationStartDate; public string OperationStartDate { get { return _OperationStartDate; } set { _OperationStartDate = value; } }
    private string _OperationEndDate; public string OperationEndDate { get { return _OperationEndDate; } set { _OperationEndDate = value; } }

    private string _AnisticTime; public string AnisticTime { get { return _AnisticTime; } set { _AnisticTime = value; } }
    private string _Remark; public string Remark { get { return _Remark; } set { _Remark = value; } }

    private string _SurgeonName; public string SurgeonName { get { return _SurgeonName; } set { _SurgeonName = value; } }

    private string _OperationName; public string OperationName { get { return _OperationName; } set { _OperationName = value; } }
    private string _DiseaseName; public string DiseaseName { get { return _DiseaseName; } set { _DiseaseName = value; } }
    private int _GeneralOT; public int GeneralOT { get { return _GeneralOT; } set { _GeneralOT = value; } }

    private int _swabFirstNurse; public int swabFirstNurse { get { return _swabFirstNurse; } set { _swabFirstNurse = value; } }
    private int _swabSecountNurse; public int swabSecountNurse { get { return _swabSecountNurse; } set { _swabSecountNurse = value; } }
    private int _InstrumentFirstNurse; public int InstrumentFirstNurse { get { return _InstrumentFirstNurse; } set { _InstrumentFirstNurse = value; } }
    private int _InstrumentSecoundNurse; public int InstrumentSecoundNurse { get { return _InstrumentSecoundNurse; } set { _InstrumentSecoundNurse = value; } }
    private int _ProcedureId; public int ProcedureId { get { return _ProcedureId; } set { _ProcedureId = value; } }

    private int _PatMainTypeId; public int PatMainTypeId { get { return _PatMainTypeId; } set { _PatMainTypeId = value; } }

    private int _PatientInsuTypeId; public int PatientInsuTypeId { get { return _PatientInsuTypeId; } set { _PatientInsuTypeId = value; } }

    
    private string _Type; public string Type { get { return _Type; } set { _Type = value; } }
    private string _TypeOfAnaesthesia; public string TypeOfAnaesthesia { get { return _TypeOfAnaesthesia; } set { _TypeOfAnaesthesia = value; } }
    private string _Procedure; public string Procedure { get { return _Procedure; } set { _Procedure = value; } }
    private string _Incision; public string Incision { get { return _Incision; } set { _Incision = value; } }
    private string _BloodLoss; public string BloodLoss { get { return _BloodLoss; } set { _BloodLoss = value; } }
    private string _SurgeryDone; public string SurgeryDone { get { return _SurgeryDone; } set { _SurgeryDone = value; } }
    private string _AdvertEvents; public string AdvertEvents { get { return _AdvertEvents; } set { _AdvertEvents = value; } }
    private string _Comments; public string Comments { get { return _Comments; } set { _Comments = value; } }
    private int _OTId; public int OTId { get { return _OTId; } set { _OTId = value; } }


    private string _OTTime; public string OTTime { get { return _OTTime; } set { _OTTime = value; } }
    private string _SurgeonsFee; public string SurgeonsFee { get { return _SurgeonsFee; } set { _SurgeonsFee = value; } }
    private string _HospitalStay; public string HospitalStay { get { return _HospitalStay; } set { _HospitalStay = value; } }
    private string _ASA; public string ASA { get { return _ASA; } set { _ASA = value; } }
    private string _SpecialInvestigation; public string SpecialInvestigation { get { return _SpecialInvestigation; } set { _SpecialInvestigation = value; } }
    private int _ConsultantDrId; public int ConsultantDrId { get { return _ConsultantDrId; } set { _ConsultantDrId = value; } }
    private string _ConsultantDoc; public string ConsultantDoc { get { return _ConsultantDoc; } set { _ConsultantDoc = value; } }

    private int _SurgEstimationId; public int SurgEstimationId { get { return _SurgEstimationId; } set { _SurgEstimationId = value; } }

    private string _OTClass; public string OTClass { get { return _OTClass; } set { _OTClass = value; } }

    private decimal _SurgeonFee;
    public decimal SurgeonFee
    {
        get { return _SurgeonFee; }
        set { _SurgeonFee = value; }
    }

    private decimal _TheatreFee;
    public decimal TheatreFee
    {
        get { return _TheatreFee; }
        set { _TheatreFee = value; }
    }

    private decimal _MedicineCharges;
    public decimal MedicineCharges
    {
        get { return _MedicineCharges; }
        set { _MedicineCharges = value; }
    }
    private decimal _WardCharges;
    public decimal WardCharges
    {
        get { return _WardCharges; }
        set { _WardCharges = value; }
    }
    private decimal _InvestigationCharges;
    public decimal InvestigationCharges
    {
        get { return _InvestigationCharges; }
        set { _InvestigationCharges = value; }
    }
    private decimal _AnesthetistCharges;
    public decimal AnesthetistCharges
    {
        get { return _AnesthetistCharges; }
        set { _AnesthetistCharges = value; }
    }

    private int _ASAId;
    public int ASAId
    {
        get { return _ASAId; }
        set { _ASAId = value; }
    }

    private string _Flag;
    public string Flag
    {
        get { return _Flag; }
        set { _Flag = value; }
    }

    private string _OTImagePath; public string OTImagePath { get { return _OTImagePath; } set { _OTImagePath = value; } }


    private bool _AfterHrs; public bool AfterHrs { get { return _AfterHrs; } set { _AfterHrs = value; } }


    private DateTime _ScheduleSurgeryDate; public DateTime ScheduleSurgeryDate { get { return _ScheduleSurgeryDate; } set { _ScheduleSurgeryDate = value; } }
    private float _EstimatedCost; public float EstimatedCost { get { return _EstimatedCost; } set { _EstimatedCost = value; } }
    private float _NonRefDeposit; public float NonRefDeposit { get { return _NonRefDeposit; } set { _NonRefDeposit = value; } }
   
}
