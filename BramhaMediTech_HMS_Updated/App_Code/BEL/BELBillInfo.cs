using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BELBillInfo
/// </summary>
public class BELBillInfo
{
	public BELBillInfo()
	{
		//
		// TODO: Add constructor logic here
		//
        this.P_lastpodateintake = Date.getMinDate();
        this.P_lastvoidedurinedate = Date.getMinDate();
        this.P_lastbowelmovementdate = Date.getMinDate();
        this.P_RelativeDate = Date.getMinDate();
        this.P_WitnessDate = Date.getMinDate();
	}
     private int _PatientInfoId;    
    public int PatientInfoId { get { return _PatientInfoId; } set { _PatientInfoId = value; } }
    private int _PatRegId;
    public int PatRegId { get { return _PatRegId; } set { _PatRegId = value; } }
    private int _IpdId;
    public int IpdId { get { return _IpdId; } set { _IpdId = value; } }
    private int _FId;
    public int FId { get { return _FId; } set { _FId = value; } }
    private int _BranchId;
    public int BranchId { get { return _BranchId; } set { _BranchId = value; } }
    private int _IpdNo;
    public int IpdNo { get { return _IpdNo; } set { _IpdNo = value; } }

    private int _ReceiptNew;
    public int ReceiptNew
    {
        get { return _ReceiptNew; }
        set { _ReceiptNew = value; }
    }

    private int _OpdNo;
    public int OpdNo { get { return _OpdNo; } set { _OpdNo = value; } }

    private int _ProcedureNo;
    public int ProcedureNo { get { return _ProcedureNo; } set { _ProcedureNo = value; } }

    private int _LabNo;
    public int LabNo { get { return _LabNo; } set { _LabNo = value; } }
    
    private string _PrnNo;

    private int _ReasonForDiscountId; public int ReasonForDiscountId { get { return _ReasonForDiscountId; } set { _ReasonForDiscountId = value; } }

    private string _ReasonForDiscountName; public string ReasonForDiscountName { get { return _ReasonForDiscountName; } set { _ReasonForDiscountName = value; } }
   
    private int _DiscountGivenById; public int DiscountGivenById { get { return _DiscountGivenById; } set { _DiscountGivenById = value; } }
    private string _DiscountGivenBy; public string DiscountGivenBy { get { return _DiscountGivenBy; } set { _DiscountGivenBy = value; } }
    private int _ReasonForBalanceId; public int ReasonForBalanceId { get { return _ReasonForBalanceId; } set { _ReasonForBalanceId = value; } }
 
    private decimal _DiscountGiven; public decimal DiscountGiven { get { return _DiscountGiven; } set { _DiscountGiven = value; } }
    private decimal _Balance; public decimal Balance { get { return _Balance; } set { _Balance = value; } }

    public string PrnNo { get { return _PrnNo; } set { _PrnNo = value; } }

    private string _PaymentType;
    public string PaymentType { get { return _PaymentType; } set { _PaymentType = value; } }


    private int _SrNo;

    /// <summary>
    /// PrnNo
    /// Sets And Gets PrnNo
    /// </summary>
    public int SrNo { get { return _SrNo; } set { _SrNo = value; } }

    private string _BarcodeId;

    /// <summary>
    /// BarcodeId
    /// Sets And Gets BarcodeId
    /// </summary>
    public string BarcodeId { get { return _BarcodeId; } set { _BarcodeId = value; } }

    private int _TitleId;

    /// <summary>
    /// TitleId
    /// Sets And Gets TitleId
    /// </summary>
    public int TitleId { get { return _TitleId; } set { _TitleId = value; } }

    private string _TitleName;

    /// <summary>
    /// TitleName
    /// Sets And Gets TitleName
    /// </summary>
    public string TitleName { get { return _TitleName; } set { _TitleName = value; } }

    private string _FirstName;

    /// <summary>
    /// FirstName
    /// Sets And Gets FirstName
    /// </summary>
    public string FirstName { get { return _FirstName; } set { _FirstName = value; } }

    private string _MiddleName;

    /// <summary>
    /// MiddleName
    /// Sets And Gets MiddleName
    /// </summary>
    public string MiddleName { get { return _MiddleName; } set { _MiddleName = value; } }

    private string _LastName;

    /// <summary>
    /// LastName
    /// Sets And Gets LastName
    /// </summary>
    public string LastName { get { return _LastName; } set { _LastName = value; } }

    private string _PatientName;

    /// <summary>
    /// PatientName
    /// Sets And Gets PatientName
    /// </summary>
    public string PatientName { get { return _PatientName; } set { _PatientName = value; } }

    private string _Age;

    /// <summary>
    /// Age
    /// Sets And Gets Age
    /// </summary>
    public string Age { get { return _Age; } set { _Age = value; } }

    private int _PatientCategoryId;

    /// <summary>
    /// PatientCategoryId
    /// Sets And Gets PatientCategoryId
    /// </summary>
    public int PatientCategoryId { get { return _PatientCategoryId; } set { _PatientCategoryId = value; } }

    private string _PatientCategoryName;

    /// <summary>
    /// PatientCategoryName
    /// Sets And Gets PatientCategoryName
    /// </summary>
    public string PatientCategoryName { get { return _PatientCategoryName; } set { _PatientCategoryName = value; } }



    private string _LetterNo;
    public string LetterNo { get { return _LetterNo; } set { _LetterNo = value; } }

    private string _ChildCompName;
    public string ChildCompName { get { return _ChildCompName; } set { _ChildCompName = value; } }


    private int _PatientInsuChargeId;
    public int PatientInsuChargeId { get { return _PatientInsuChargeId; } set { _PatientInsuChargeId = value; } }

    
    private int _PatientSubCategoryId;   
    public int PatientSubCategoryId { get { return _PatientSubCategoryId; } set { _PatientSubCategoryId = value; } }

    private int _PatientTypeId;
    public int PatientTypeId { get { return _PatientTypeId; } set { _PatientTypeId = value; } }

    private string _PatientSubCategoryName;   
    public string PatientSubCategoryName { get { return _PatientSubCategoryName; } set { _PatientSubCategoryName = value; } }

    private int _GenderId;

    /// <summary>
    /// GenderId
    /// Sets And Gets GenderId 
    /// </summary>
    public int GenderId { get { return _GenderId; } set { _GenderId = value; } }


    private string _Gender;

    /// <summary>
    /// Gender
    /// Sets And Gets Gender 
    /// </summary>
    public string Gender { get { return _Gender; } set { _Gender = value; } }

    private string _GenderName;

    /// <summary>
    /// GenderName
    /// Sets And Gets GenderName
    /// </summary>
    public string GenderName { get { return _GenderName; } set { _GenderName = value; } }

    //private DateTime _BirthDate;

    ///// <summary>
    ///// BirthDate
    ///// Sets And Gets BirthDate
    ///// </summary>
    //public DateTime BirthDate { get { return _BirthDate; } set { _BirthDate = value; } }

    private string _BirthDate;

    /// <summary>
    /// BirthDate
    /// Sets And Gets BirthDate
    /// </summary>
    public string BirthDate { get { return _BirthDate; } set { _BirthDate = value; } }

    private bool _IsConfirmBirthDate;

    /// <summary>
    /// IsConfirmBirthDate
    /// Sets And Gets IsConfirmBirthDate
    /// </summary>
    public bool IsConfirmBirthDate { get { return _IsConfirmBirthDate; } set { _IsConfirmBirthDate = value; } }

    private int _BloodGroupId;

    /// <summary>
    /// BloodGroupId
    /// Sets And Gets BloodGroupId
    /// </summary>
    public int BloodGroupId { get { return _BloodGroupId; } set { _BloodGroupId = value; } }

    private string _BloodGroupName;

    /// <summary>
    /// BloodGroupName
    /// Sets And Gets BloodGroupName
    /// </summary>
    public string BloodGroupName { get { return _BloodGroupName; } set { _BloodGroupName = value; } }

    private int _MaritalStatusId;

    /// <summary>
    /// MaritalStatusId
    /// Sets And Gets MaritalStatusId
    /// </summary>
    public int MaritalStatusId { get { return _MaritalStatusId; } set { _MaritalStatusId = value; } }

    private string _MaritalStatusName;

    /// <summary>
    /// MaritalStatusName
    /// Sets And Gets MaritalStatusName
    /// </summary>
    public string MaritalStatusName { get { return _MaritalStatusName; } set { _MaritalStatusName = value; } }

    private int _GuardianTitleId;

    /// <summary>
    /// GuardianTitleId
    /// Sets And Gets GuardianTitleId
    /// </summary>
    public int GuardianTitleId { get { return _GuardianTitleId; } set { _GuardianTitleId = value; } }

    private string _GuardianTitleName;

    /// <summary>
    /// GuardianTitleName
    /// Sets And Gets GuardianTitleName
    /// </summary>
    public string GuardianTitleName { get { return _GuardianTitleName; } set { _GuardianTitleName = value; } }

    private string _GuardianName;

    /// <summary>
    /// GuardianName
    /// Sets And Gets GuardianName
    /// </summary>
    public string GuardianName { get { return _GuardianName; } set { _GuardianName = value; } }

    private string _MobileNo;

    /// <summary>
    /// MobileNo
    /// Sets And Gets MobileNo
    /// </summary>
    public string MobileNo { get { return _MobileNo; } set { _MobileNo = value; } }

    private string _PhoneNo;

    /// <summary>
    /// PhoneNo
    /// Sets And Gets PhoneNo
    /// </summary>
    public string PhoneNo { get { return _PhoneNo; } set { _PhoneNo = value; } }

    private string _PatientAddress;

    /// <summary>
    /// PatientAddress
    /// Sets And Gets PatientAddress
    /// </summary>
    public string PatientAddress { get { return _PatientAddress; } set { _PatientAddress = value; } }

    private int _CountryId;

    /// <summary>
    /// CountryId
    /// Sets And Gets CountryId
    /// </summary>
    public int CountryId { get { return _CountryId; } set { _CountryId = value; } }

    private string _CountryName;

    /// <summary>
    /// CountryName
    /// Sets And Gets CountryName
    /// </summary>
    public string CountryName { get { return _CountryName; } set { _CountryName = value; } }

    public int _StateId;

    /// <summary>
    /// StateId
    /// Sets And Gets StateId
    /// </summary>
    public int StateId { get { return _StateId; } set { _StateId = value; } }

    private string _StateName;

    /// <summary>
    /// StateName
    /// Sets And Gets StateName
    /// </summary>
    public string StateName { get { return _StateName; } set { _StateName = value; } }

    public int _CityId;

    /// <summary>
    /// CityId
    /// Sets And Gets CityId
    /// </summary>
    public int CityId { get { return _CityId; } set { _CityId = value; } }

    private string _CityName;

    /// <summary>
    /// CityName
    /// Sets And Gets CityName
    /// </summary>
    public string CityName { get { return _CityName; } set { _CityName = value; } }

    public int _LandMarkId;

    /// <summary>
    /// LandMarkId
    /// Sets And Gets LandMarkId
    /// </summary>
    public int LandMarkId { get { return _LandMarkId; } set { _LandMarkId = value; } }

    private string _LandMarkName;

    /// <summary>
    /// LandMarkName
    /// Sets And Gets LandMarkName
    /// </summary>
    public string LandMarkName { get { return _LandMarkName; } set { _LandMarkName = value; } }

    private string _Email;

    /// <summary>
    /// Email
    /// Sets And Gets Email
    /// </summary>
    public string Email { get { return _Email; } set { _Email = value; } }

    private string _EntryDate;

    /// <summary>
    /// EntryDate
    /// Sets And Gets EntryDate
    /// </summary>
    public string EntryDate { get { return _EntryDate; } set { _EntryDate = value; } }

    private string _ImagePath;

    /// <summary>
    /// ImagePath
    /// Sets And Gets ImagePath
    /// </summary>
    public string ImagePath { get { return _ImagePath; } set { _ImagePath = value; } }


    private int _PatientRegistrationId;

    /// <summary>
    /// PatientRegistrationId
    /// Sets And Gets PatientRegistrationId
    /// </summary>
    public int PatientRegistrationId
    {
        get { return _PatientRegistrationId; }
        set { _PatientRegistrationId = value; }
    }

    private string _RegistrationNo;

    /// <summary>
    /// RegistrationNo
    /// Sets And Gets RegistrationNo
    /// </summary>
    public string RegistrationNo
    {
        get { return _RegistrationNo; }
        set { _RegistrationNo = value; }
    }

    private int _RegistrationTypeId;

    /// <summary>
    /// RegistrationTypeId
    /// Sets And Gets RegistrationTypeId
    /// </summary>
    public int RegistrationTypeId
    {
        get { return _RegistrationTypeId; }
        set { _RegistrationTypeId = value; }
    }

    private string _RegistrationTypeName;

    /// <summary>
    /// RegistrationTypeName
    /// Sets And Gets RegistrationTypeName
    /// </summary>
    public string RegistrationTypeName
    {
        get { return _RegistrationTypeName; }
        set { _RegistrationTypeName = value; }
    }

    private string _RegistrationDateTime;

    /// <summary>
    /// RegistrationDateTime
    /// Sets And Gets RegistrationDateTime
    /// </summary>
    public string RegistrationDateTime
    {
        get { return _RegistrationDateTime; }
        set { _RegistrationDateTime = value; }
    }

    private int _HospitalId;

    /// <summary>
    /// HospitalId
    /// Sets And Gets HospitalId
    /// </summary>
    public int HospitalId
    {
        get { return _HospitalId; }
        set { _HospitalId = value; }
    }

    private int _SectionId;

    /// <summary>
    /// SectionId
    /// Sets And Gets SectionId
    /// </summary>
    public int SectionId
    {
        get { return _SectionId; }
        set { _SectionId = value; }
    }

    private string _KinName;

    /// <summary>
    /// KinName
    /// Sets And Gets KinName
    /// </summary>
    public string KinName
    {
        get { return _KinName; }
        set { _KinName = value; }
    }

    private string _RelationOfKin;

    /// <summary>
    /// RelationOfKin
    /// Sets And Gets RelationOfKin
    /// </summary>
    public string RelationOfKin
    {
        get { return _RelationOfKin; }
        set { _RelationOfKin = value; }
    }

    private string _SectionName;

    /// <summary>
    /// SectionName
    /// Sets And Gets SectionName
    /// </summary>
    public string SectionName
    {
        get { return _SectionName; }
        set { _SectionName = value; }
    }

    private string _PatientComplaint;

    /// <summary>
    /// PatientComplaint
    /// Sets And Gets PatientComplaint
    /// </summary>
    public string PatientComplaint
    {
        get { return _PatientComplaint; }
        set { _PatientComplaint = value; }
    }

    private int _ShiftId;

    /// <summary>
    /// ShiftId
    /// Sets And Gets ShiftId
    /// </summary>
    public int ShiftId
    {
        get { return _ShiftId; }
        set { _ShiftId = value; }
    }
    private string _ShiftName;

    /// <summary>
    /// ShiftName
    /// Sets And Gets ShiftName
    /// </summary>
    public string ShiftName
    {
        get { return _ShiftName; }
        set { _ShiftName = value; }
    }

    private int _ReferenceDrId;

    /// <summary>
    /// ReferenceDrId
    /// Sets And Gets ReferenceDrId
    /// </summary>
    public int ReferenceDrId
    {
        get { return _ReferenceDrId; }
        set { _ReferenceDrId = value; }
    }


    private int _RegistrationStatusId;

    /// <summary>
    /// RegistrationStatusId
    /// Sets And Gets RegistrationStatusId
    /// </summary>
    public int RegistrationStatusId
    {
        get { return _RegistrationStatusId; }
        set { _RegistrationStatusId = value; }
    }

    private string _RegistrationStatusName;

    /// <summary>
    /// RegistrationStatusName
    /// Sets And Gets RegistrationStatusName
    /// </summary>
    public string RegistrationStatusName
    {
        get { return _RegistrationStatusName; }
        set { _RegistrationStatusName = value; }
    }

    private int _EmployeeId;

    /// <summary>
    /// EmployeeId
    /// Sets And Gets EmployeeId
    /// </summary>
    public int EmployeeId
    {
        get { return _EmployeeId; }
        set { _EmployeeId = value; }
    }

    private string _EmployeeName;

    /// <summary>
    /// EmployeeName
    /// Sets And Gets EmployeeName
    /// </summary>
    public string EmployeeName
    {
        get { return _EmployeeName; }
        set { _EmployeeName = value; }
    }
    private string _BillParticular;
    public string BillParticular
    {
        get { return _BillParticular; }
        set { _BillParticular = value; }
    }
    private string _ReferenceDrName;

    /// <summary>
    /// ReferenceDrName
    /// Sets And Gets ReferenceDrName
    /// </summary>
    public string ReferenceDrName
    {
        get { return _ReferenceDrName; }
        set { _ReferenceDrName = value; }
    }

    private string _ReferenceDrText;

    /// <summary>
    /// ReferenceDrText
    /// Sets And Gets ReferenceDrText
    /// </summary>
    public string ReferenceDrText
    {
        get { return _ReferenceDrText; }
        set { _ReferenceDrText = value; }
    }
    private string _Remark;
    public string Remark
    {
        get { return _Remark; }
        set { _Remark = value; }
    }
    private string _Authority;
     public string Authority
    {
        get { return _Authority; }
        set { _Authority = value; }
    }
    
    private string _BillType;
    public string BillType
    {
        get { return _BillType; }
        set { _BillType = value; }
    }
    private int _ConsultantDrId;

    /// <summary>
    /// ConsultantDrId
    /// Sets And Gets ConsultantDrId
    /// </summary>
    public int ConsultantDrId
    {
        get { return _ConsultantDrId; }
        set { _ConsultantDrId = value; }
    }

    private string _ConsultantDrName;

    /// <summary>
    /// ConsultantDrName
    /// Sets And Gets ConsultantDrName
    /// </summary>
    public string ConsultantDrName
    {
        get { return _ConsultantDrName; }
        set { _ConsultantDrName = value; }
    }

    private string _RoomBed;

    /// <summary>
    /// RoomBed
    /// Sets And Gets RoomBed
    /// </summary>
    public string RoomBed
    {
        get { return _RoomBed; }
        set { _RoomBed = value; }
    }

    private int _BedId;

    /// <summary>
    /// BedId
    /// Sets And Gets BedId
    /// </summary>
    public int BedId
    {
        get { return _BedId; }
        set { _BedId = value; }
    }

    private string _Bed;

    /// <summary>
    /// RoomBed
    /// Sets And Gets RoomBed
    /// </summary>
    public string Bed
    {
        get { return _Bed; }
        set { _Bed = value; }
    }

    private int _RoomId;

    /// <summary>
    /// RoomId
    /// Sets And Gets RoomId
    /// </summary>
    public int RoomId
    {
        get { return _RoomId; }
        set { _RoomId = value; }
    }

    private string _Room;

    /// <summary>
    /// Room
    /// Sets And Gets Room
    /// </summary>
    public string Room
    {
        get { return _Room; }
        set { _Room = value; }
    }

    private string _DrName;

    /// <summary>
    /// DrName
    /// Sets And Gets DrName
    /// </summary>
    public string DrName
    {
        get { return _DrName; }
        set { _DrName = value; }
    }

    private string _StatusChangeDateTime;

    /// <summary>
    /// StatusChangeDateTime
    /// Sets And Gets StatusChangeDateTime
    /// </summary>
    public string StatusChangeDateTime
    {
        get { return _StatusChangeDateTime; }
        set { _StatusChangeDateTime = value; }
    }
   
    private string _StatusChangeReason;

    /// <summary>
    /// StatusChangeReason
    /// Sets And Gets StatusChangeReason
    /// </summary>
    public string StatusChangeReason
    {
        get { return _StatusChangeReason; }
        set { _StatusChangeReason = value; }
    }
    private int _BillId;

    public int BillId
    {
        get { return _BillId; }
        set { _BillId = value; }
    }

    private int _ReceiptNo;

    public int ReceiptNo
    {
        get { return _ReceiptNo; }
        set { _ReceiptNo = value; }
    }
    private int _PaymentId;

    public int PaymentId
    {
        get { return _PaymentId; }
        set { _PaymentId = value; }
    }

    private int _BillParticularId;

    public int BillParticularId
    {
        get { return _BillParticularId; }
        set { _BillParticularId = value; }
    }

    private decimal _BillAmountWithDisc;

    public decimal BillAmountWithDisc
    {
        get { return _BillAmountWithDisc; }
        set { _BillAmountWithDisc = value; }
    }
    private decimal _BillTotal;

    public decimal BillTotal
    {
        get { return _BillTotal; }
        set { _BillTotal = value; }
    }

    private decimal _AmountPaid;

    public decimal AmountPaid
    {
        get { return _AmountPaid; }
        set { _AmountPaid = value; }
    }

    
    private decimal _Discount;

    public decimal Discount
    {
        get { return _Discount; }
        set { _Discount = value; }
    }
    private DateTime _PaymentDate;

    public DateTime PaymentDate
    {
        get { return _PaymentDate; }
        set { _PaymentDate = value; }
    }

    private int _PatientConsultationId;

    public int PatientConsultationId
    {
        get { return _PatientConsultationId; }
        set { _PatientConsultationId = value; }
    }

    private string _UserName;

    public string UserName
    {
        get { return _UserName; }
        set { _UserName = value; }
    }

    private string _ModeOfPaymentName;

    public string ModeOfPaymentName
    {
        get { return _ModeOfPaymentName; }
        set { _ModeOfPaymentName = value; }
    }
    private string _AssignDateTime;

    public string AssignDateTime
    {
        get { return _AssignDateTime; }
        set { _AssignDateTime = value; }
    }
    private string _DiscGivenBy;

    public string DiscGivenBy
    {
        get { return _DiscGivenBy; }
        set { _DiscGivenBy = value; }
    }
    

    private decimal _charges;

    public decimal charges
    {
        get { return _charges; }
        set { _charges = value; }
    }


    //--------------------------------------------------------------------

    

    private int _BillNo;

    public int BillNo
    {
        get { return _BillNo; }
        set { _BillNo = value; }
    }

    private DateTime _BillDate;

    public DateTime BillDate
    {
        get { return _BillDate; }
        set { _BillDate = value; }
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

    private decimal _TaxPercent;

    public decimal TaxPercent
    {
        get { return _TaxPercent; }
        set { _TaxPercent = value; }
    }

    

    

    private decimal _TaxAmount;

    public decimal TaxAmount
    {
        get { return _TaxAmount; }
        set { _TaxAmount = value; }
    }

    private decimal _FinalAmount;

    public decimal FinalAmount
    {
        get { return _FinalAmount; }
        set { _FinalAmount = value; }
    }

    private decimal _FinalAmount1;

    public decimal FinalAmount1
    {
        get { return _FinalAmount1; }
        set { _FinalAmount1 = value; }
    }

    private string _AmountInWord;

    public string AmountInWord
    {
        get { return _AmountInWord; }
        set { _AmountInWord = value; }
    }

   

    private bool _IsActive; public bool IsActive { get { return _IsActive; } set { _IsActive = value; } }
    private string _CreatedBy; public string CreatedBy { get { return _CreatedBy; } set { _CreatedBy = value; } }
    private DateTime _CreatedDateTime; public DateTime CreatedDateTime { get { return _CreatedDateTime; } set { _CreatedDateTime = value; } }
    private string _UpdatedBy; public string UpdatedBy { get { return _UpdatedBy; } set { _UpdatedBy = value; } }
    private DateTime _UpdatedDateTime; public DateTime UpdatedDateTime { get { return _UpdatedDateTime; } set { _UpdatedDateTime = value; } }
    private string _ChequeCardNo; public string ChequeCardNo { get { return _ChequeCardNo; } set { _ChequeCardNo = value; } }
    private string _BankName; public string BankName { get { return _BankName; } set { _BankName = value; } }
    private string _ChequeDate; public string ChequeDate { get { return _ChequeDate; } set { _ChequeDate = value; } }

    private int _ProcedureId;
    public int ProcedureId
    {
        get { return _ProcedureId; }
        set { _ProcedureId = value; }
    }
    private bool _IsInsuranceFlag; public bool IsInsuranceFlag    {        get { return _IsInsuranceFlag; }        set { _IsInsuranceFlag = value; }    }
    private string _BillGroup;
    public string BillGroup
    {
        get { return _BillGroup; }
        set { _BillGroup = value; }
    }
    private string _InsuranceComp;
    public string InsuranceComp
    {
        get { return _InsuranceComp; }
        set { _InsuranceComp = value; }
    }
    private int _InsuranceCompId;
    public int InsuranceCompId
    {
        get { return _InsuranceCompId; }
        set { _InsuranceCompId = value; }
    }

    private decimal _InsuranceAmount;
    public decimal InsuranceAmount
    {
        get { return _InsuranceAmount; }
        set { _InsuranceAmount = value; }
    }
    private decimal _BillAmount;
    public decimal BillAmount
    {
        get { return _BillAmount; }
        set { _BillAmount = value; }
    }
    
    private decimal _DepositAmount;
    public decimal DepositAmount
    {
        get { return _DepositAmount; }
        set { _DepositAmount = value; }
    }
    private int _DepositId;
    public int DepositId
    {
        get { return _DepositId; }
        set { _DepositId = value; }
    }
    private string _flag;
    public string flag
    {
        get { return _flag; }
        set { _flag = value; }
    }
    private bool _IsDeposit; public bool IsDeposit { get { return _IsDeposit; } set { _IsDeposit = value; } }

    private string ProcedureDate; public string P_ProcedureDate { get { return ProcedureDate; } set { ProcedureDate = value; } }
    private DateTime ProcedureDateT; public DateTime P_ProcedureDateT { get { return ProcedureDateT; } set { ProcedureDateT = value; } }
    private string Procedure1; public string P_Procedure { get { return Procedure1; } set { Procedure1 = value; } }
    private string ProvDiag; public string P_ProvDiag { get { return ProvDiag; } set { ProvDiag = value; } }
    private string Complant; public string P_Complant { get { return Complant; } set { Complant = value; } }
    private string CaseSummary; public string P_CaseSummary { get { return CaseSummary; } set { CaseSummary = value; } }

    private string FinalDiagnosis; public string P_FinalDiagnosis { get { return FinalDiagnosis; } set { FinalDiagnosis = value; } }
    private string Surgan; public string P_Surgan { get { return Surgan; } set { Surgan = value; } }
    private string OTNote; public string P_OTNote { get { return OTNote; } set { OTNote = value; } }
    private string Anesthesia; public string P_Anesthesia { get { return Anesthesia; } set { Anesthesia = value; } }


    private string Anesthetist; public string P_Anesthetist { get { return Anesthetist; } set { Anesthetist = value; } }
    private string OnAdmissionDet; public string P_OnAdmissionDet { get { return OnAdmissionDet; } set { OnAdmissionDet = value; } }
    private string Treatment; public string P_Treatment { get { return Treatment; } set { Treatment = value; } }
    private string ConDischarge; public string P_ConDischarge { get { return ConDischarge; } set { ConDischarge = value; } }

    private string ReasonDischarge; public string P_ReasonDischarge { get { return ReasonDischarge; } set { ReasonDischarge = value; } }
    private string OperationNote; public string P_OperationNote { get { return OperationNote; } set { OperationNote = value; } }
    private string NextFollowUp; public string P_NextFollowUp { get { return NextFollowUp; } set { NextFollowUp = value; } }
    private string TreatmentAdvice; public string P_TreatmentAdvice { get { return TreatmentAdvice; } set { TreatmentAdvice = value; } }
    private string GeneralRemark; public string P_GeneralRemark { get { return GeneralRemark; } set { GeneralRemark = value; } }

    //============================================== IPD Admission Sheet ===============================================

    private string IPD_Complaints; public string P_IPD_Complaints { get { return IPD_Complaints; } set { IPD_Complaints = value; } }
    private string IPD_OnAdmisDetails; public string P_IPD_OnAdmisDetails { get { return IPD_OnAdmisDetails; } set { IPD_OnAdmisDetails = value; } }
    private string IPD_CaseSummary; public string P_IPD_CaseSummary { get { return IPD_CaseSummary; } set { IPD_CaseSummary = value; } }
    private string IPD_ProvDiagnosis; public string P_IPD_ProvDiagnosis { get { return IPD_ProvDiagnosis; } set { IPD_ProvDiagnosis = value; } }
    private string IPD_FinalDiagnosis; public string P_IPD_FinalDiagnosis { get { return IPD_FinalDiagnosis; } set { IPD_FinalDiagnosis = value; } }
    private string IPD_History; public string P_IPD_History { get { return IPD_History; } set { IPD_History = value; } }

    private string IPD_Temp; public string P_IPD_Temp { get { return IPD_Temp; } set { IPD_Temp = value; } }
    private string IPD_Resp; public string P_IPD_Resp { get { return IPD_Resp; } set { IPD_Resp = value; } }
    private string IPD_Height; public string P_IPD_Height { get { return IPD_Height; } set { IPD_Height = value; } }
    private string IPD_pulse; public string P_IPD_pulse { get { return IPD_pulse; } set { IPD_pulse = value; } }
    private string IPD_BP; public string P_IPD_BP { get { return IPD_BP; } set { IPD_BP = value; } }
    private string IPD_weight; public string P_IPD_weight { get { return IPD_weight; } set { IPD_weight = value; } }

    private string IPD_Albumin; public string P_IPD_Albumin { get { return IPD_Albumin; } set { IPD_Albumin = value; } }
    private string IPD_sugar; public string P_IPD_sugar { get { return IPD_sugar; } set { IPD_sugar = value; } }
    private string IPD_Blood; public string P_IPD_Blood { get { return IPD_Blood; } set { IPD_Blood = value; } }
    //------------------
    private string foodpreferences; public string P_foodpreferences { get { return foodpreferences; } set { foodpreferences = value; } }
    private string Describe; public string P_Describe { get { return Describe; } set { Describe = value; } }
    private string BpType; public string P_BpType { get { return BpType; } set { BpType = value; } }
    private string lastpoIntake; public string P_lastpoIntake { get { return lastpoIntake; } set { lastpoIntake = value; } }
    private DateTime lastpodateintake; public DateTime P_lastpodateintake { get { return lastpodateintake; } set { lastpodateintake = value; } }

    private string lasttimepointak; public string P_lasttimepointak { get { return lasttimepointak; } set { lasttimepointak = value; } }
    private DateTime lastvoidedurinedate; public DateTime P_lastvoidedurinedate { get { return lastvoidedurinedate; } set { lastvoidedurinedate = value; } }
    private string lastvoidedurinetime; public string P_lastvoidedurinetime { get { return lastvoidedurinetime; } set { lastvoidedurinetime = value; } }
    private DateTime lastbowelmovementdate; public DateTime P_lastbowelmovementdate { get { return lastbowelmovementdate; } set { lastbowelmovementdate = value; } }
    private string lastbowelmovementtime; public string P_lastbowelmovementtime { get { return lastbowelmovementtime; } set { lastbowelmovementtime = value; } }
    private string Vision; public string P_Vision { get { return Vision; } set { Vision = value; } }
    private string Hearing; public string P_Hearing { get { return Hearing; } set { Hearing = value; } }
    private string Speech; public string P_Speech { get { return Speech; } set { Speech = value; } }
    private string Ambulation; public string P_Ambulation { get { return Ambulation; } set { Ambulation = value; } }
    private string Declaration; public string P_Declaration { get { return Declaration; } set { Declaration = value; } }
    private string RelativeName; public string P_RelativeName { get { return RelativeName; } set { RelativeName = value; } }
    private DateTime RelativeDate; public DateTime P_RelativeDate { get { return RelativeDate; } set { RelativeDate = value; } }
    private string WitnessName; public string P_WitnessName { get { return WitnessName; } set { WitnessName = value; } }
    private DateTime WitnessDate; public DateTime P_WitnessDate { get { return WitnessDate; } set { WitnessDate = value; } }

    private bool Awake; public bool P_Awake { get { return Awake; } set { Awake = value; } }
    private bool Alert; public bool P_Alert { get { return Alert; } set { Alert = value; } }
    private bool Oriented; public bool P_Oriented { get { return Oriented; } set { Oriented = value; } }
    private bool Lethargic; public bool P_Lethargic { get { return Lethargic; } set { Lethargic = value; } }
    private bool Disoriented; public bool P_Disoriented { get { return Disoriented; } set { Disoriented = value; } }
    private bool Comatose; public bool P_Comatose { get { return Comatose; } set { Comatose = value; } }
    private string surgicalHistory; public string P_surgicalHistory { get { return surgicalHistory; } set { surgicalHistory = value; } }
    private string FamilyHistory; public string P_FamilyHistory { get { return FamilyHistory; } set { FamilyHistory = value; } }
    private string Wound; public string P_Wound { get { return Wound; } set { Wound = value; } }
    private string WoundSize; public string P_WoundSize { get { return WoundSize; } set { WoundSize = value; } }

    private string Name; public string P_Name { get { return Name; } set { Name = value; } }
    private string Dose; public string P_Dose { get { return Dose; } set { Dose = value; } }
    private string Frequency; public string P_Frequency { get { return Frequency; } set { Frequency = value; } }
    private string LastDose; public string P_LastDose { get { return LastDose; } set { LastDose = value; } }


    private string MedDateTime; public string P_MedDateTime { get { return MedDateTime; } set { MedDateTime = value; } }
    private string Physician; public string P_Physician { get { return Physician; } set { Physician = value; } }
    private string Dosage; public string P_Dosage { get { return Dosage; } set { Dosage = value; } }
    private string Route; public string P_Route { get { return Route; } set { Route = value; } }
    private string RN; public string P_RN { get { return RN; } set { RN = value; } }

    private string Medication; public string P_Medication { get { return Medication; } set { Medication = value; } }
    private string DoseSign1; public string P_DoseSign1 { get { return DoseSign1; } set { DoseSign1 = value; } }
    private string DoseSign2; public string P_DoseSign2 { get { return DoseSign2; } set { DoseSign2 = value; } }
    private string DoseSign3; public string P_DoseSign3 { get { return DoseSign3; } set { DoseSign3 = value; } }
    private string DoseSign4; public string P_DoseSign4 { get { return DoseSign4; } set { DoseSign4 = value; } }
    private string DoseSign5; public string P_DoseSign5 { get { return DoseSign5; } set { DoseSign5 = value; } }
    private string DoseSign6; public string P_DoseSign6 { get { return DoseSign6; } set { DoseSign6 = value; } }
    private string DoseSign7; public string P_DoseSign7 { get { return DoseSign7; } set { DoseSign7 = value; } }

    private bool Xray; public bool P_Xray { get { return Xray; } set { Xray = value; } }
    private bool kor; public bool P_kor { get { return kor; } set { kor = value; } }
    private bool drugs; public bool P_drugs { get { return drugs; } set { drugs = value; } }
    private bool ECG; public bool P_ECG { get { return ECG; } set { ECG = value; } }
    private bool csr; public bool P_csr { get { return csr; } set { csr = value; } }
    private bool Lab; public bool P_Lab { get { return Lab; } set { Lab = value; } }
    private bool room; public bool P_room { get { return room; } set { room = value; } }
    private bool RBS; public bool P_RBS { get { return RBS; } set { RBS = value; } }
    private bool OXYGEN; public bool P_OXYGEN { get { return OXYGEN; } set { OXYGEN = value; } }
    private bool NEBULIZER; public bool P_NEBULIZER { get { return NEBULIZER; } set { NEBULIZER = value; } }

    private bool Xrayb; public bool P_Xrayb { get { return Xrayb; } set { Xrayb = value; } }
    private bool korb; public bool P_korb { get { return korb; } set { korb = value; } }
    private bool drugsb; public bool P_drugsb { get { return drugsb; } set { drugsb = value; } }
    private bool ECGb; public bool P_ECGb { get { return ECGb; } set { ECGb = value; } }
    private bool csrb; public bool P_csrb { get { return csrb; } set { csrb = value; } }
    private bool Labb; public bool P_Labb { get { return Labb; } set { Labb = value; } }
    private bool roomb; public bool P_roomb { get { return roomb; } set { roomb = value; } }
    private bool RBSb; public bool P_RBSb { get { return RBSb; } set { RBSb = value; } }
    private bool OXYGENb; public bool P_OXYGENb { get { return OXYGENb; } set { OXYGENb = value; } }
    private bool NEBULIZERb; public bool P_NEBULIZERb { get { return NEBULIZERb; } set { NEBULIZERb = value; } }

}
