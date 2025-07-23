using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BELOPDPatReg
/// </summary>
public class BELOPDPatReg
{
	public BELOPDPatReg()
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
    private int _InsuranceCompId;
    public int InsuranceCompId
    {
        get { return _InsuranceCompId; }
        set { _InsuranceCompId = value; }
    }
    private int _ProcedureId;
    public int ProcedureId
    {
        get { return _ProcedureId; }
        set { _ProcedureId = value; }
    }
    private int _DiseaseId;
    public int DiseaseId
    {
        get { return _DiseaseId; }
        set { _DiseaseId = value; }
    }
    private int _OperationId;
    public int OperationId
    {
        get { return _OperationId; }
        set { _OperationId = value; }
    }

    private int _Infant;
    public int Infant
    {
        get { return _Infant; }
        set { _Infant = value; }
    }

    private int _InfantRace;
    public int InfantRace
    {
        get { return _InfantRace; }
        set { _InfantRace = value; }
    }

    private int _PaymentType;
    public int PaymentType
    {
        get { return _PaymentType; }
        set { _PaymentType = value; }
    }

    private string _PaymentRemark;
    public string PaymentRemark
    {
        get { return _PaymentRemark; }
        set { _PaymentRemark = value; }
    }

    private int _InfantMotherIPDNO;
    public int InfantMotherIPDNO
    {
        get { return _InfantMotherIPDNO; }
        set { _InfantMotherIPDNO = value; }
    }

    private string _InfantDOB;
    public string InfantDOB
    {
        get { return _InfantDOB; }
        set { _InfantDOB = value; }
    }

    private string _InfantGender;
    public string InfantGender
    {
        get { return _InfantGender; }
        set { _InfantGender = value; }
    }

    private string _InFantPatientName;
     public string InFantPatientName
    {
        get { return _InFantPatientName; }
        set { _InFantPatientName = value; }
    }
    

    private string _DiseaseName;
    public string DiseaseName
    {
        get { return _DiseaseName; }
        set { _DiseaseName = value; }
    }
    private string _OperatioName;
    public string OperatioName
    {
        get { return _OperatioName; }
        set { _OperatioName = value; }
    }

    private decimal _InsuranceAmount;
    public decimal InsuranceAmount
    {
        get { return _InsuranceAmount; }
        set { _InsuranceAmount = value; }
    }
    private bool _IsInsuranceFlag;
    public bool IsInsuranceFlag
    {
        get { return _IsInsuranceFlag; }
        set { _IsInsuranceFlag = value; }
    }

    private bool _IsDischarge;
    public bool IsDischarge
    {
        get { return _IsDischarge; }
        set { _IsDischarge = value; }
    }

    

    private decimal _BillServiceCharges;
    public decimal BillServiceCharges
    {
        get { return _BillServiceCharges; }
        set { _BillServiceCharges = value; }
    }

    private decimal _AdvanceAmt;
    public decimal AdvanceAmt
    {
        get { return _AdvanceAmt; }
        set { _AdvanceAmt = value; }
    }
    private decimal _PaidAmt;
    public decimal PaidAmt
    {
        get { return _PaidAmt; }
        set { _PaidAmt = value; }
    }
    private decimal _BillAmount;
    public decimal BillAmount
    {
        get { return _BillAmount; }
        set { _BillAmount = value; }
    }
    private decimal _DiscountAmt;
    public decimal DiscountAmt
    {
        get { return _DiscountAmt; }
        set { _DiscountAmt = value; }
    }
    private decimal _BalanceAmt;
    public decimal BalanceAmt
    {
        get { return _BalanceAmt; }
        set { _BalanceAmt = value; }
    }
    private decimal _NetAmt;
    public decimal NetAmt
    {
        get { return _NetAmt; }
        set { _NetAmt = value; }
    }
    private int _OpdNo;
    public int OpdNo
    {
        get { return _OpdNo; }
        set { _OpdNo = value; }
    }

    private int _BillGroupId;
    public int BillGroupId
    {
        get { return _BillGroupId; }
        set { _BillGroupId = value; }
    }

    private int _InsuranceChargeCompamt;
    public int InsuranceChargeCompamt
    {
        get { return _InsuranceChargeCompamt; }
        set { _InsuranceChargeCompamt = value; }
    }
    

    private int _IpdNo;
    public int IpdNo
    {
        get { return _IpdNo; }
        set { _IpdNo = value; }
    }
    private int _PrimaryDoc;
    public int PrimaryDoc
    {
        get { return _PrimaryDoc; }
        set { _PrimaryDoc = value; }
    }
    private int _SecodaryDoc;
    public int SecodaryDoc
    {
        get { return _SecodaryDoc; }
        set { _SecodaryDoc = value; }
    }

    private string _ContactPerson1;

    public string ContactPerson1
    {
        get { return _ContactPerson1; }
        set { _ContactPerson1 = value; }
    }
     private string _ContactPerson2;

    public string ContactPerson2
    {
        get { return _ContactPerson2; }
        set { _ContactPerson2 = value; }
    }
     private int _Relation1;

    public int Relation1
    {
        get { return _Relation1; }
        set { _Relation1 = value; }
    }

    private int _Relation2;

    public int Relation2
    {
        get { return _Relation2; }
        set { _Relation2 = value; }
    }
    private string _Contact1;

    public string Contact1
    {
        get { return _Contact1; }
        set { _Contact1 = value; }
    }
    private string _Contact2;

    public string Contact2
    {
        get { return _Contact2; }
        set { _Contact2 = value; }
    }
    

    private int _BillNo;

    public int BillNo
    {
        get { return _BillNo; }
        set { _BillNo = value; }
    }

   
    

    private int _DeptId;

    public int DeptId
    {
        get { return _DeptId; }
        set { _DeptId = value; }
    }
    private int _TitleId;

    public int TitleId
    {
        get { return _TitleId; }
        set { _TitleId = value; }
    }
    private int _PatRegId;

    public int PatRegId
    {
        get { return _PatRegId; }
        set { _PatRegId = value; }
    }
    private int _OLDBedId;

    public int OLDBedId
    {
        get { return _OLDBedId; }
        set { _OLDBedId = value; }
    }
    
    private int _FId;
    public int FId
    {
        get { return _FId; }
        set { _FId = value; }
    }

    private int _RoomCategory;
    public int RoomCategory
    {
        get { return _RoomCategory; }
        set { _RoomCategory = value; }
    }

    private int _BranchId;

    public int BranchId
    {
        get { return _BranchId; }
        set { _BranchId = value; }
    }

    private int _LabNo;
    public int LabNo
    {
        get { return _LabNo; }
        set { _LabNo = value; }
    }

    
    private string _RegistrationNo;

    public string RegistrationNo
    {
        get { return _RegistrationNo; }
        set { _RegistrationNo = value; }
    }

    private string _BedName;
    /// <summary>
    /// BedName
    /// Sets And Gets BedName
    /// </summary>
    public string BedName
    {
        get { return _BedName; }
        set { _BedName = value; }
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

    private int _PatientInfoId;

    /// <summary>
    /// RegistrationTypeId
    /// Sets And Gets RegistrationTypeId
    /// </summary>
    public int PatientInfoId
    {
        get { return _PatientInfoId; }
        set { _PatientInfoId = value; }
    }

    


    private string _RoomAddress;

    /// <summary>
    /// RegistrationTypeName
    /// Sets And Gets RegistrationTypeName
    /// </summary>
    public string RoomAddress
    {
        get { return _RoomAddress; }
        set { _RoomAddress = value; }
    }

    private int _PatientTreatmentId; 
    public int PatientTreatmentId
    {
        get { return _PatientTreatmentId; }
        set { _PatientTreatmentId = value; }
    }

    private string _FullDocName;
    public string FullDocName
    {
        get { return _FullDocName; }
        set { _FullDocName = value; }
    }

    private string _SecondaryDoc;
      public string SecondaryDoc
    {
        get { return _SecondaryDoc; }
        set { _SecondaryDoc = value; }
    }

    
    private string _FullDeptName;
    public string FullDeptName
    {
        get { return _FullDeptName; }
        set { _FullDeptName = value; }
    }

    private string _RelationName;
     public string RelationName
    {
        get { return _RelationName; }
        set { _RelationName = value; }
    }

     private string _RecoDate;
     public string RecoDate
     {
         get { return _RecoDate; }
         set { _RecoDate = value; }
     }
     private string _RecoTime;
     public string RecoTime
     {
         get { return _RecoTime; }
         set { _RecoTime = value; }
     }
     private string _RecoBy;
     public string RecoBy
     {
         get { return _RecoBy; }
         set { _RecoBy = value; }
     }
    private string _PatientName;
    public string PatientName
    {
        get { return _PatientName; }
        set { _PatientName = value; }
    }

    private string _RoomName;

    /// <summary>
    /// RegistrationTypeName
    /// Sets And Gets RegistrationTypeName
    /// </summary>
    public string RoomName
    {
        get { return _RoomName; }
        set { _RoomName = value; }
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

    private string _EntryDate;

   
    public string EntryDate
    {
        get { return _EntryDate; }
        set { _EntryDate = value; }
    }
    private string _Age;
    public string Age
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

    
    private string _Gender;
    public string Gender
    {
        get { return _Gender; }
        set { _Gender = value; }
    }
    private string _MobileNo;
    public string MobileNo
    {
        get { return _MobileNo; }
        set { _MobileNo = value; }
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

    private string _VaccinationStatus;
     public string VaccinationStatus
    {
        get { return _VaccinationStatus; }
        set { _VaccinationStatus = value; }
    }

    
    private int _ShiftId;

    
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
    private int _DrId;

    /// <summary>
    /// ReferenceDrId
    /// Sets And Gets ReferenceDrId
    /// </summary>
    public int DrId
    {
        get { return _DrId; }
        set { _DrId = value; }
    }
    private int _VisitingNo;


    public int VisitingNo
    {
        get { return _VisitingNo; }
        set { _VisitingNo = value; }
    }
    private int _TokenNo;
    public int TokenNo
    {
        get { return _TokenNo; }
        set { _TokenNo = value; }
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

    //DischargeDateTime
    private string _DischargeDateTime;
    public string DischargeDateTime
    {
        get { return _DischargeDateTime; }
        set { _DischargeDateTime = value; }
    }
    private string _EntryTime;
    public string EntryTime
    {
        get { return _EntryTime; }
        set { _EntryTime = value; }
    }
    private bool _IsAdmited;
    public bool IsAdmited
    {
        get { return _IsAdmited; }
        set { _IsAdmited = value; }
    }
    private string _PatientAddress;

    /// <summary>
    /// RegistrationStatusName
    /// Sets And Gets RegistrationStatusName
    /// </summary>
    public string PatientAddress
    {
        get { return _PatientAddress; }
        set { _PatientAddress = value; }
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

    private DateTime _StatusChangeDateTime;

    /// <summary>
    /// StatusChangeDateTime
    /// Sets And Gets StatusChangeDateTime
    /// </summary>
    public DateTime StatusChangeDateTime
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

    private string _MLCNo; 
    public string MLCNo
    {
        get { return _MLCNo; }
        set { _MLCNo = value; }
    }

    private string _AdmissionType; 
    public string AdmissionType
    {
        get { return _AdmissionType; }
        set { _AdmissionType = value; }
    }


    private bool _IsActive;

    /// <summary>
    /// IsActive
    /// Sets And Gets IsActive
    /// </summary>
    public bool IsActive
    {
        get { return _IsActive; }
        set { _IsActive = value; }
    }

    private string _ClinicalHistory;

    public string ClinicalHistory
    {
        get { return _ClinicalHistory; }
        set { _ClinicalHistory = value; }
    }


    private string _WardName;
    public string WardName
    {
        get { return _WardName; }
        set { _WardName = value; }
    }
    private string _VerbalBy;
    public string VerbalBy
    {
        get { return _VerbalBy; }
        set { _VerbalBy = value; }
    }
    private string _VerbalOn;
    public string VerbalOn
    {
        get { return _VerbalOn; }
        set { _VerbalOn = value; }
    }

    
    private string  _CreatedBy;
    public string CreatedBy
    {
        get { return _CreatedBy; }
        set { _CreatedBy = value; }
    }

    private string _OrderBy;
     public string OrderBy
    {
        get { return _OrderBy; }
        set { _OrderBy = value; }
    }

     private string _EmrLabNo;
     public string EmrLabNo
    {
        get { return _EmrLabNo; }
        set { _EmrLabNo = value; }
    }

    

    private string _LetterNo;
     public string LetterNo
    {
        get { return _LetterNo; }
        set { _LetterNo = value; }
    }

     private string _TypeOfVisit;
     public string TypeOfVisit
     {
         get { return _TypeOfVisit; }
         set { _TypeOfVisit = value; }
     }
    
    private string _MainDoctor;
    public string MainDoctor
    {
        get { return _MainDoctor; }
        set { _MainDoctor = value; }
    }

    private string _LetterNumber;
    public string LetterNumber
    {
        get { return _LetterNumber; }
        set { _LetterNumber = value; }
    }

    private string _DepositAmt;
    public string DepositAmt
    {
        get { return _DepositAmt; }
        set { _DepositAmt = value; }
    }
    //private int _Infant;
    // public int Infant
    //{
    //    get { return _Infant; }
    //    set { _Infant = value; }
    //}
    

    private string _ReferBy;
    public string ReferBy
    {
        get { return _ReferBy; }
        set { _ReferBy = value; }
    }

    private string _LabPtype;
    public string LabPtype
    {
        get { return _LabPtype; }
        set { _LabPtype = value; }
    }
    
    private DateTime _CreatedOn;

    /// <summary>
    /// CreatedDateTime
    /// Sets And Gets CreatedDateTime
    /// </summary>
    public DateTime CreatedOn
    {
        get { return _CreatedOn; }
        set { _CreatedOn = value; }
    }
    private bool _IsEmergency;
    public bool IsEmergency
    {
        get { return _IsEmergency; }
        set { _IsEmergency = value; }
    }
    private bool _IsUniversalPrecaution;
    public bool IsUniversalPrecaution
    {
        get { return _IsUniversalPrecaution; }
        set { _IsUniversalPrecaution = value; }
    }
    private int _RoomId;


    public int RoomId
    {
        get { return _RoomId; }
        set { _RoomId = value; }
    }
    private int _BedId;
    public int BedId
    {
        get { return _BedId; }
        set { _BedId = value; }
    }

    private string _UpdatedBy;
    public string UpdatedBy
    {
        get { return _UpdatedBy; }
        set { _UpdatedBy = value; }
    }
    private string _Sponsor;
    public string Sponsor
    {
        get { return _Sponsor; }
        set { _Sponsor = value; }
    }
    private string _Procedure;    public string Procedure    {        get { return _Procedure; }        set { _Procedure = value; }    }
    private DateTime? _RegisterDate;
    public DateTime? RegisterDate { get { return _RegisterDate; } set { _RegisterDate = value; } }

    private DateTime _UpdatedOn;

    /// <summary>
    /// UpdatedDateTime
    /// Sets And Gets UpdatedDateTime
    /// </summary>
    public DateTime UpdatedOn
    {
        get { return _UpdatedOn; }
        set { _UpdatedOn = value; }
    }

    private int _VisitNo;

    public int VisitNo { get { return _VisitNo; } set { _VisitNo = value; } }

    private int _PatMainTypeId;
    public int PatMainTypeId { get { return _PatMainTypeId; } set { _PatMainTypeId = value; } }

    private string _PatMainType;
    public string PatMainType { get { return _PatMainType; } set { _PatMainType = value; } }

    private string _Sponsor2;
    public string Sponsor2 { get { return _Sponsor2; } set { _Sponsor2 = value; } }
    private string _Diagnosis;
    public string Diagnosis { get { return _Diagnosis; } set { _Diagnosis = value; } }
    private string _ProcedureName;
    public string ProcedureName { get { return _ProcedureName; } set { _ProcedureName = value; } }
    private string _RType;
    public string RType { get { return _RType; } set { _RType = value; } }

    private string _DRName;
    public string DRName { get { return _DRName; } set { _DRName = value; } }
    //private string _BedName;
    //public string BedName { get { return _BedName; } set { _BedName = value; } }

    private int _PatientInsuTypeId;
    public int PatientInsuTypeId { get { return _PatientInsuTypeId; } set { _PatientInsuTypeId = value; } }

    private int _PatientInsuChargeId;
    public int PatientInsuChargeId { get { return _PatientInsuChargeId; } set { _PatientInsuChargeId = value; } }


    private int _PatientInsuTypeId2;
    public int PatientInsuTypeId2 { get { return _PatientInsuTypeId2; } set { _PatientInsuTypeId2 = value; } }

    private int _ChargeCompanyId;
    public int ChargeCompanyId { get { return _ChargeCompanyId; } set { _ChargeCompanyId = value; } }
    
    private string _PatientInsuType;
    public string PatientInsuType { get { return _PatientInsuType; } set { _PatientInsuType = value; } }

    private string _PatientInsurance2;
    public string PatientInsurance2 { get { return _PatientInsurance2; } set { _PatientInsurance2 = value; } }

    private string _ChildCompanyName;
    public string ChildCompanyName { get { return _ChildCompanyName; } set { _ChildCompanyName = value; } }
    

    private int _IpdId;

    public int IpdId { get { return _IpdId; } set { _IpdId = value; } }

    private string _ReasonforShifting;
    public string ReasonforShifting { get { return _ReasonforShifting; } set { _ReasonforShifting = value; } }

    private string _Details;
    public string Details { get { return _Details; } set { _Details = value; } }

    private string _DischargeTime;
    public string DischargeTime { get { return _DischargeTime; } set { _DischargeTime = value; } }

    private string _DischargeReason;
    public string DischargeReason { get { return _DischargeReason; } set { _DischargeReason = value; } }

    private int _ReasonForDiscountId; public int ReasonForDiscountId { get { return _ReasonForDiscountId; } set { _ReasonForDiscountId = value; } }

    private string _ReasonForDiscountName; public string ReasonForDiscountName { get { return _ReasonForDiscountName; } set { _ReasonForDiscountName = value; } }

    private int _DiscountGivenById; public int DiscountGivenById { get { return _DiscountGivenById; } set { _DiscountGivenById = value; } }
    private string _DiscountGivenBy; public string DiscountGivenBy { get { return _DiscountGivenBy; } set { _DiscountGivenBy = value; } }
    private int _ReasonForBalanceId; public int ReasonForBalanceId { get { return _ReasonForBalanceId; } set { _ReasonForBalanceId = value; } }

    private decimal _DiscountGiven; public decimal DiscountGiven { get { return _DiscountGiven; } set { _DiscountGiven = value; } }

    private string _PaymentMode;
    public string PaymentMode { get { return _PaymentMode; } set { _PaymentMode = value; } }
    private string _BillGroup;

    public string BillGroup
    {
        get { return _BillGroup; }
        set { _BillGroup = value; }
    }

   // private string _LetterNumber; public string LetterNumber { get { return _LetterNumber; } set { _LetterNumber = value; } }

    private string _Address1; public string Address1 { get { return _Address1; } set { _Address1 = value; } }
    private string _Address2; public string Address2 { get { return _Address2; } set { _Address2 = value; } }

    private string  _SurgeryType; public string SurgeryType { get { return _SurgeryType; } set { _SurgeryType = value; } }

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
    private string RecomRemark; public string P_RecomRemark { get { return RecomRemark; } set { RecomRemark = value; } }
    //============================================IPD Admission sheet ==========================================================
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


    private bool _AfterHrs; public bool AfterHrs { get { return _AfterHrs; } set { _AfterHrs = value; } }


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
}
