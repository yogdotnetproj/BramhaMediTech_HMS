using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BELIntakeOutputChart
/// </summary>
public class BELIntakeOutputChart
{
	public BELIntakeOutputChart()
	{
		//
		// TODO: Add constructor logic here
		//
        this.MonAttDate = Date.getMinDate();
        this.MonDetDate = Date.getMinDate();

        this.OxyStartDate = Date.getMinDate();
        this.OxydisDate = Date.getMinDate();
        this.EntryDate = Date.getMinDate();
	}

    private int _NurseNoteId;
    public int NurseNoteId { get { return _NurseNoteId; } set { _NurseNoteId = value; } }
    private int _DoctorNoteId;
    public int DoctorNoteId { get { return _DoctorNoteId; } set { _DoctorNoteId = value; } }
    private int _UserId;
    public int UserId { get { return _UserId; } set { _UserId = value; } }
    private int _IOId;
    public int IOId { get { return _IOId; } set { _IOId = value; } }
    private int _Patregid;
    public int Patregid { get { return _Patregid; } set { _Patregid = value; } }
    private int _OpdNo;
    public int OpdNo { get { return _OpdNo; } set { _OpdNo = value; } }

    private int _ShiftId;
    public int ShiftId { get { return _ShiftId; } set { _ShiftId = value; } }

    private int _Id;
    public int Id { get { return _Id; } set { _Id = value; } }

    private int _IpdNo;
    public int IpdNo { get { return _IpdNo; } set { _IpdNo = value; } }
    private string _CreatedBy;
    public string CreatedBy { get { return _CreatedBy; } set { _CreatedBy = value; } }
    private string _UserName;
    public string UserName { get { return _UserName; } set { _UserName = value; } }

    private DateTime _CreatedOn;
    public DateTime CreatedOn { get { return _CreatedOn; } set { _CreatedOn = value; } }

    private string _UpdatedBy;
    public string UpdatedBy { get { return _UpdatedBy; } set { _UpdatedBy = value; } }

    private DateTime _UpdatedOn;
    public DateTime UpdatedOn { get { return _UpdatedOn; } set { _UpdatedOn = value; } }

    private int _FId;
    public int FId { get { return _FId; } set { _FId = value; } }

  

    private int _BranchId;
    public int BranchId { get { return _BranchId; } set { _BranchId = value; } }

    private DateTime _DateInput;
    public DateTime DateInput { get { return _DateInput; } set { _DateInput = value; } }

    private string _TimeInput;
    public string TimeInput { get { return _TimeInput; } set { _TimeInput = value; } }

    private string _EndTime;
    public string EndTime { get { return _EndTime; } set { _EndTime = value; } }


    private string _TypeOfOralIntake;
    public string TypeOfOralIntake { get { return _TypeOfOralIntake; } set { _TypeOfOralIntake = value; } }

    private float _OralIntakeQty;
    public float OralIntakeQty { get { return _OralIntakeQty; } set { _OralIntakeQty = value; } }

   
    private string _OralIntakeUnit;
    public string OralIntakeUnit { get { return _OralIntakeUnit; } set { _OralIntakeUnit = value; } }

    private string _OtherIntakeType;
    public string OtherIntakeType { get { return _OtherIntakeType; } set { _OtherIntakeType = value; } }

    private float _OtherIntake;
    public float OtherIntake { get { return _OtherIntake; } set { _OtherIntake = value; } }
   
    private string _OtherIntakeUnit;
    public string OtherIntakeUnit { get { return _OtherIntakeUnit; } set { _OtherIntakeUnit = value; } }

     private float _BloodIntake;
    public float BloodIntake { get { return _BloodIntake; } set { _BloodIntake = value; } }

    private float _IVIntake;
    public float IVIntake { get { return _IVIntake; } set { _IVIntake = value; } }

    private float _RTF;
    public float RTF { get { return _RTF; } set { _RTF = value; } }

    private string _Remark;
    public string Remark { get { return _Remark; } set { _Remark = value; } }

    private float _VomitOutPut;
    public float VomitOutPut { get { return _VomitOutPut; } set { _VomitOutPut = value; } }

    private string _VomitUnit;
    public string VomitUnit { get { return _VomitUnit; } set { _VomitUnit = value; } }

    private float _UrineOutPut;
    public float UrineOutPut { get { return _UrineOutPut; } set { _UrineOutPut = value; } }

    private string _UrineUnit;
    public string UrineUnit { get { return _UrineUnit; } set { _UrineUnit = value; } }

    private float _RTA;
    public float RTA { get { return _RTA; } set { _RTA = value; } }

    private string _Bowel;
    public string Bowel { get { return _Bowel; } set { _Bowel = value; } }
    
    private float _OtherOutput;
    public float OtherOutput { get { return _OtherOutput; } set { _OtherOutput = value; } }

    private string _OtherOutputUnit;
    public string OtherOutputUnit { get { return _OtherOutputUnit; } set { _OtherOutputUnit = value; } }

    private float _LiquidInput;
    public float LiquidInput { get { return _LiquidInput; } set { _LiquidInput = value; } }

    private float _LiquidOutput;
    public float LiquidOutput { get { return _LiquidOutput; } set { _LiquidOutput = value; } }

    private float _LiquidBalance;
    public float LiquidBalance { get { return _LiquidBalance; } set { _LiquidBalance = value; } }

    private float _SolidInput;
    public float SolidInput { get { return _SolidInput; } set { _SolidInput = value; } }

    private float _SolidOutput;
    public float SolidOutput { get { return _SolidOutput; } set { _SolidOutput = value; } }

    private float _SolidBalance;
    public float SolidBalance { get { return _SolidBalance; } set { _SolidBalance = value; } }

    private int _DrId;
    public int DrId { get { return _DrId; } set { _DrId = value; } }

    private int _DrugId;
    public int DrugId { get { return _DrugId; } set { _DrugId = value; } }

    private string _DrugName;
    public string DrugName { get { return _DrugName; } set { _DrugName = value; } }

    private string _IvFluid;
    public string IvFluid { get { return _IvFluid; } set { _IvFluid = value; } }

    private int _IvFluidId;
    public int IvFluidId { get { return _IvFluidId; } set { _IvFluidId = value; } }

    private int _IVChartId;
    public int IVChartId { get { return _IVChartId; } set { _IVChartId = value; } }


    private int _PatTreatmentId;
    public int PatTreatmentId { get { return _PatTreatmentId; } set { _PatTreatmentId = value; } }

    private int _DiabeticSheetId;
    public int DiabeticSheetId { get { return _DiabeticSheetId; } set { _DiabeticSheetId = value; } }

    private string _Qty;
    public string Qty { get { return _Qty; } set { _Qty = value; } }

    private string _Routess;
    public string Routess { get { return _Routess; } set { _Routess = value; } }

    

    private float _Value;
    public float Value { get { return _Value; } set { _Value = value; } }

    private int _InformToDr;
    public int InformToDr { get { return _InformToDr; } set { _InformToDr = value; } }

   private string _ActionTaken;
   public string ActionTaken { get { return _ActionTaken; } set { _ActionTaken = value; } }

   private string _FastingType;
   public string FastingType { get { return _FastingType; } set { _FastingType = value; } }

   private string _EmpName;
   public string EmpName { get { return _EmpName; } set { _EmpName = value; } }

   private string _BloodGroup;
   public string BloodGroup { get { return _BloodGroup; } set { _BloodGroup = value; } }

   private string _Indication;
   public string Indication { get { return _Indication; } set { _Indication = value; } }

   private bool _WholeBlood;
   public bool WholeBlood { get { return _WholeBlood; } set { _WholeBlood = value; } }

   private bool _PacketCells;
   public bool PacketCells { get { return _PacketCells; } set { _PacketCells = value; } }

   private bool _Platelets;
   public bool Platelets { get { return _Platelets; } set { _Platelets = value; } }

   private bool _Cryoprecipitate;
   public bool Cryoprecipitate { get { return _Cryoprecipitate; } set { _Cryoprecipitate = value; } }

   private bool _FFP;
   public bool FFP { get { return _FFP; } set { _FFP = value; } }

   private string _ConsentTaken;
   public string ConsentTaken { get { return _ConsentTaken; } set { _ConsentTaken = value; } }

   private string _DoctorOrder;
   public string DoctorOrder { get { return _DoctorOrder; } set { _DoctorOrder = value; } }
 
    private string _PremedicationOrder;
    public string PremedicationOrder { get { return _PremedicationOrder; } set { _PremedicationOrder = value; } }

    private string _PrevTransfusion;
    public string PrevTransfusion { get { return _PrevTransfusion; } set { _PrevTransfusion = value; } }

    private string _PrevTransReaction;
    public string PrevTransReaction { get { return _PrevTransReaction; } set { _PrevTransReaction = value; } }

    private string _UnitNo;
    public string UnitNo { get { return _UnitNo; } set { _UnitNo = value; } }
 
	 private int _CheckedBy;
    public int CheckedBy { get { return _CheckedBy; } set { _CheckedBy = value; } }

    private int _StartedBy;
    public int StartedBy { get { return _StartedBy; } set { _StartedBy = value; } }


    private int _BloodTransId;
    public int BloodTransId { get { return _BloodTransId; } set { _BloodTransId = value; } }
 

    private string _StartTime;
    public string StartTime { get { return _StartTime; } set { _StartTime = value; } }

    
    private string _TimeS;
    public string TimeS { get { return _TimeS; } set { _TimeS = value; } }
 
    private string _Rate;
    public string Rate { get { return _Rate; } set { _Rate = value; } }

    private string _T;
    public string T { get { return _T; } set { _T = value; } }

    private string _P;
    public string P { get { return _P; } set { _P = value; } }

    private string _R;
    public string R { get { return _R; } set { _R = value; } }

    private string _BP;
    public string BP { get { return _BP; } set { _BP = value; } }
 
    private string _TRDetails;
    public string TRDetails { get { return _TRDetails; } set { _TRDetails = value; } }

    private string _FinishTime;
    public string FinishTime { get { return _FinishTime; } set { _FinishTime = value; } }
    //======================================================================================
    private int _PhId;
    public int PhId { get { return _PhId; } set { _PhId = value; } }    
    private string _CaseNo;
    public string CaseNo { get { return _CaseNo; } set { _CaseNo = value; } }

    private bool _CheckMedHis;
    public bool CheckMedHis { get { return _CheckMedHis; } set { _CheckMedHis = value; } }

    private string _MedHis;
    public string MedHis { get { return _MedHis; } set { _MedHis = value; } }

    private bool _CheckMedication;
    public bool CheckMedication { get { return _CheckMedication; } set { _CheckMedication = value; } }

    private string _Medication;
    public string Medication { get { return _Medication; } set { _Medication = value; } }

    private bool _Checksurghis;
    public bool Checksurghis { get { return _Checksurghis; } set { _Checksurghis = value; } }

    private string _surghis;
    public string surghis { get { return _surghis; } set { _surghis = value; } }

    private bool _CheckGyna;
    public bool CheckGyna { get { return _CheckGyna; } set { _CheckGyna = value; } }

    private string _Gyna;
    public string Gyna { get { return _Gyna; } set { _Gyna = value; } }

    private bool _CheckAllergy;
    public bool CheckAllergy { get { return _CheckAllergy; } set { _CheckAllergy = value; } }

    private string _Allergy;
    public string Allergy { get { return _Allergy; } set { _Allergy = value; } }

    private bool _Checkfamily;
    public bool Checkfamily { get { return _Checkfamily; } set { _Checkfamily = value; } }

    private string _FamilyHistory;
    public string FamilyHistory { get { return _FamilyHistory; } set { _FamilyHistory = value; } }

    private bool _Checksmoking;
    public bool Checksmoking { get { return _Checksmoking; } set { _Checksmoking = value; } }

    private string _smokingDurat;
    public string smokingDurat { get { return _smokingDurat; } set { _smokingDurat = value; } }

    private string _smokingQty;
    public string smokingQty { get { return _smokingQty; } set { _smokingQty = value; } }

    private bool _CheckAlco;
    public bool CheckAlco { get { return _CheckAlco; } set { _CheckAlco = value; } }

    private string _AlcoDurat;
    public string AlcoDurat { get { return _AlcoDurat; } set { _AlcoDurat = value; } }

    private string _AlcoQty;
    public string AlcoQty { get { return _AlcoQty; } set { _AlcoQty = value; } }
 //================================================================================
    //===============================================================================
    private int _PeId;
    public int PeId { get { return _PeId; } set { _PeId = value; } }    

    private bool _Bedsore;
    public bool Bedsore { get { return _Bedsore; } set { _Bedsore = value; } }
    private bool _Dentures;
    public bool Dentures { get { return _Dentures; } set { _Dentures = value; } }
    private bool _Spectacles;
    public bool Spectacles { get { return _Spectacles; } set { _Spectacles = value; } }

    private bool _CheckPhInj;
    public bool CheckPhInj { get { return _CheckPhInj; } set { _CheckPhInj = value; } }
    private string _PhysicalInjuries;
    public string PhysicalInjuries { get { return _PhysicalInjuries; } set { _PhysicalInjuries = value; } }

    private bool _CheckFoleys;
    public bool CheckFoleys { get { return _CheckFoleys; } set { _CheckFoleys = value; } }
    private bool _CheckNGTube;
    public bool CheckNGTube { get { return _CheckNGTube; } set { _CheckNGTube = value; } }
    private bool _CheckIntraCath;
    public bool CheckIntraCath { get { return _CheckIntraCath; } set { _CheckIntraCath = value; } }

    private string _PhysicalSize;
    public string PhysicalSize { get { return _PhysicalSize; } set { _PhysicalSize = value; } }

    private bool _CheckCentralLine;
    public bool CheckCentralLine { get { return _CheckCentralLine; } set { _CheckCentralLine = value; } }

    private string _CentralLine;
    public string CentralLine { get { return _CentralLine; } set { _CentralLine = value; } }

    private bool _CheckImpDevice;
    public bool CheckImpDevice { get { return _CheckImpDevice; } set { _CheckImpDevice = value; } }

    private string _ImpDevice;
    public string ImpDevice { get { return _ImpDevice; } set { _ImpDevice = value; } }

    private bool _CheckJewellery;
    public bool CheckJewellery { get { return _CheckJewellery; } set { _CheckJewellery = value; } }

    private bool _CheckJewellerytofami;
    public bool CheckJewellerytofami { get { return _CheckJewellerytofami; } set { _CheckJewellerytofami = value; } }

    private bool _CheckPatfamily;
    public bool CheckPatfamily { get { return _CheckPatfamily; } set { _CheckPatfamily = value; } }

    private string _signature;
    public string signature { get { return _signature; } set { _signature = value; } }
    private string _Relationship;
    public string Relationship { get { return _Relationship; } set { _Relationship = value; } }

    private string _OtherRemark;
    public string OtherRemark { get { return _OtherRemark; } set { _OtherRemark = value; } }

    private string _NurseRemark;
    public string NurseRemark { get { return _NurseRemark; } set { _NurseRemark = value; } }

    //=========================================================================================

    private string _Temprature;
    public string Temprature { get { return _Temprature; } set { _Temprature = value; } }

    private DateTime _VitalDate;
    public DateTime VitalDate { get { return _VitalDate; } set { _VitalDate = value; } }

    

    private string _BPVital;
    public string BPVital { get { return _BPVital; } set { _BPVital = value; } }

    private string _HR;
    public string HR { get { return _HR; } set { _HR = value; } }

    private string _RR;
    public string RR { get { return _RR; } set { _RR = value; } }

    private string _Spo2;
    public string Spo2 { get { return _Spo2; } set { _Spo2 = value; } }

    private string _Inspired;
    public string Inspired { get { return _Inspired; } set { _Inspired = value; } }

    private string _RRScore;
    public string RRScore { get { return _RRScore; } set { _RRScore = value; } }

    private string _UrineScore;
    public string UrineScore { get { return _UrineScore; } set { _UrineScore = value; } }

    private string _Systolic;
    public string Systolic { get { return _Systolic; } set { _Systolic = value; } }

    private string _Diastolic;
    public string Diastolic { get { return _Diastolic; } set { _Diastolic = value; } }

    private string _CNScore;
    public string CNScore { get { return _CNScore; } set { _CNScore = value; } }


    private int _VId;
    public int VId { get { return _VId; } set { _VId = value; } }

    private string _VitalRemark;
    public string VitalRemark { get { return _VitalRemark; } set { _VitalRemark = value; } }

    private string _Allergies;
    public string Allergies { get { return _Allergies; } set { _Allergies = value; } }

    private bool _SignconsentForm;
    public bool SignconsentForm { get { return _SignconsentForm; } set { _SignconsentForm = value; } }

    private bool _NameLabels;
    public bool NameLabels { get { return _NameLabels; } set { _NameLabels = value; } }

    private bool _BloodWork;
    public bool BloodWork { get { return _BloodWork; } set { _BloodWork = value; } }

    private bool _IVAccess;
    public bool IVAccess { get { return _IVAccess; } set { _IVAccess = value; } }

    private bool _PainSupposotory;
    public bool PainSupposotory { get { return _PainSupposotory; } set { _PainSupposotory = value; } }

    private bool _IVAntiBiotics;
    public bool IVAntiBiotics { get { return _IVAntiBiotics; } set { _IVAntiBiotics = value; } }

    private bool _DENTURES;
    public bool DENTURES { get { return _DENTURES; } set { _DENTURES = value; } }

    private bool _HAIRCLIPS;
    public bool HAIRCLIPS { get { return _HAIRCLIPS; } set { _HAIRCLIPS = value; } }

    private bool _JEWELLERY;
    public bool JEWELLERY { get { return _JEWELLERY; } set { _JEWELLERY = value; } }

    private bool _UNDERWEAR;
    public bool UNDERWEAR { get { return _UNDERWEAR; } set { _UNDERWEAR = value; } }

    private bool _PROSTHESIS;
    public bool PROSTHESIS { get { return _PROSTHESIS; } set { _PROSTHESIS = value; } }

    private bool _SPECTACLES;
    public bool SPECTACLES { get { return _SPECTACLES; } set { _SPECTACLES = value; } }

    private bool _VitalSigns;
    public bool VitalSigns { get { return _VitalSigns; } set { _VitalSigns = value; } }

    private bool _UrinAnalysis;
    public bool UrinAnalysis { get { return _UrinAnalysis; } set { _UrinAnalysis = value; } }

    private bool _TreatmentSheet;
    public bool TreatmentSheet { get { return _TreatmentSheet; } set { _TreatmentSheet = value; } }

    private bool _IVFluids;
    public bool IVFluids { get { return _IVFluids; } set { _IVFluids = value; } }

    private bool _ECG;
    public bool ECG { get { return _ECG; } set { _ECG = value; } }

    private bool _Orthopaedic;
    public bool Orthopaedic { get { return _Orthopaedic; } set { _Orthopaedic = value; } }

    private int _TCheckId;
    public int TCheckId { get { return _TCheckId; } set { _TCheckId = value; } }


    //-------------------------NurseShiftReport-------------------
    private string _CurrentComplaint;
    public string CurrentComplaint { get { return _CurrentComplaint; } set { _CurrentComplaint = value; } }
    private string _AdmissionDiagnosis;
    public string AdmissionDiagnosis { get { return _AdmissionDiagnosis; } set { _AdmissionDiagnosis = value; } }
    private string _SPO2;
    public string SPO2 { get { return _SPO2; } set { _SPO2 = value; } }
    private string _RA;
    public string RA { get { return _RA; } set { _RA = value; } }

    private string _LOC;
    public string LOC { get { return _LOC; } set { _LOC = value; } }
    private string _RBS;
    public string RBS { get { return _RBS; } set { _RBS = value; } }
    private string _Diet;
    public string Diet { get { return _Diet; } set { _Diet = value; } }

    private bool _FullCode;
    public bool FullCode { get { return _FullCode; } set { _FullCode = value; } }
    private bool _ComfortMeasures;
    public bool ComfortMeasures { get { return _ComfortMeasures; } set { _ComfortMeasures = value; } }
    private bool _DNR;
    public bool DNR { get { return _DNR; } set { _DNR = value; } }

    private bool _PDM;
    public bool PDM { get { return _PDM; } set { _PDM = value; } }
    private bool _PHTN;
    public bool PHTN { get { return _PHTN; } set { _PHTN = value; } }
    private bool _PCancer;
    public bool PCancer { get { return _PCancer; } set { _PCancer = value; } }

    private string _PastMedicalHistory;
    public string PastMedicalHistory { get { return _PastMedicalHistory; } set { _PastMedicalHistory = value; } }
    private string _PastSurgeryHistory;
    public string PastSurgeryHistory { get { return _PastSurgeryHistory; } set { _PastSurgeryHistory = value; } }

    private bool _FDM;
    public bool FDM { get { return _FDM; } set { _FDM = value; } }
    private bool _FHTN;
    public bool FHTN { get { return _FHTN; } set { _FHTN = value; } }
    private bool _FCancer;
    public bool FCancer { get { return _FCancer; } set { _FCancer = value; } }

    private bool _Smoker;
    public bool Smoker { get { return _Smoker; } set { _Smoker = value; } }
    private string _SmokerRemark;
    public string SmokerRemark { get { return _SmokerRemark; } set { _SmokerRemark = value; } }

    private bool _Alcohol;
    public bool Alcohol { get { return _Alcohol; } set { _Alcohol = value; } }
    private string _AlcoholRemark;
    public string AlcoholRemark { get { return _AlcoholRemark; } set { _AlcoholRemark = value; } }

    private bool _Druguse;
    public bool Druguse { get { return _Druguse; } set { _Druguse = value; } }
    private string _DruguseRemark;
    public string DruguseRemark { get { return _DruguseRemark; } set { _DruguseRemark = value; } }

    private string _IVSite;
    public string IVSite { get { return _IVSite; } set { _IVSite = value; } }
    private string _Medications;
    public string Medications { get { return _Medications; } set { _Medications = value; } }
    private string _DrainsCatheters;
    public string DrainsCatheters { get { return _DrainsCatheters; } set { _DrainsCatheters = value; } }
    private string _Proceduress;
    public string Proceduress { get { return _Proceduress; } set { _Proceduress = value; } }
    private string _AbnormalAssessments;
    public string AbnormalAssessments { get { return _AbnormalAssessments; } set { _AbnormalAssessments = value; } }
    private string _PainScore;
    public string PainScore { get { return _PainScore; } set { _PainScore = value; } }

    private string _Intervention;
    public string Intervention { get { return _Intervention; } set { _Intervention = value; } }
    private string _Safetys;
    public string Safetys { get { return _Safetys; } set { _Safetys = value; } }
    private string _RecommendationNeeded;
    public string RecommendationNeeded { get { return _RecommendationNeeded; } set { _RecommendationNeeded = value; } }

    private string _RecommendationConcerned;
    public string RecommendationConcerned { get { return _RecommendationConcerned; } set { _RecommendationConcerned = value; } }
    private string _PendingLabs;
    public string PendingLabs { get { return _PendingLabs; } set { _PendingLabs = value; } }
    private string _AwareofNext;
    public string AwareofNext { get { return _AwareofNext; } set { _AwareofNext = value; } }

    private string _BloodSugarOrder;
    public string BloodSugarOrder { get { return _BloodSugarOrder; } set { _BloodSugarOrder = value; } }
    private string _BDate;
    public string BDate { get { return _BDate; } set { _BDate = value; } }
    private string _BTime;
    public string BTime { get { return _BTime; } set { _BTime = value; } }

    private string _Insulin;
    public string Insulin { get { return _Insulin; } set { _Insulin = value; } }
    private string _BloodSugar;
    public string BloodSugar { get { return _BloodSugar; } set { _BloodSugar = value; } }

    private string _Investigation;
    public string Investigation { get { return _Investigation; } set { _Investigation = value; } }
    private string _Cost;
    public string Cost { get { return _Cost; } set { _Cost = value; } }


    private DateTime _MonAttDate; public DateTime MonAttDate { get { return _MonAttDate; } set { _MonAttDate = value; } }
    private DateTime _MonDetDate; public DateTime MonDetDate { get { return _MonDetDate; } set { _MonDetDate = value; } }

    private string _MonAttTime; public string MonAttTime { get { return _MonAttTime; } set { _MonAttTime = value; } }
    private string _AttachedBy; public string AttachedBy { get { return _AttachedBy; } set { _AttachedBy = value; } }

    private string _MonDetTime; public string MonDetTime { get { return _MonDetTime; } set { _MonDetTime = value; } }
    private string _DetectedBy; public string DetectedBy { get { return _DetectedBy; } set { _DetectedBy = value; } }

    private DateTime _OxyStartDate; public DateTime OxyStartDate { get { return _OxyStartDate; } set { _OxyStartDate = value; } }
    private DateTime _OxydisDate; public DateTime OxydisDate { get { return _OxydisDate; } set { _OxydisDate = value; } }

    private string _OxyStartTime; public string OxyStartTime { get { return _OxyStartTime; } set { _OxyStartTime = value; } }
    private string _LMP; public string LMP { get { return _LMP; } set { _LMP = value; } }

    private string _OxydisTime; public string OxydisTime { get { return _OxydisTime; } set { _OxydisTime = value; } }
    private string _DiscontinuedBy; public string DiscontinuedBy { get { return _DiscontinuedBy; } set { _DiscontinuedBy = value; } }

    private bool _PressureRelieving; public bool PressureRelieving { get { return _PressureRelieving; } set { _PressureRelieving = value; } }
    private bool _Cushion; public bool Cushion { get { return _Cushion; } set { _Cushion = value; } }
    private bool _HeelPads; public bool HeelPads { get { return _HeelPads; } set { _HeelPads = value; } }

    private DateTime _EntryDate; public DateTime EntryDate { get { return _EntryDate; } set { _EntryDate = value; } }

    private string _EnterTime; public string EnterTime { get { return _EnterTime; } set { _EnterTime = value; } }

    private string _LeftSide; public string LeftSide { get { return _LeftSide; } set { _LeftSide = value; } }
    private string _RightSide; public string RightSide { get { return _RightSide; } set { _RightSide = value; } }

    private string _Supine; public string Supine { get { return _Supine; } set { _Supine = value; } }
    private string _HeadTilt; public string HeadTilt { get { return _HeadTilt; } set { _HeadTilt = value; } }
    private string _InChari; public string InChari { get { return _InChari; } set { _InChari = value; } }
    private string _SkinIntegrity; public string SkinIntegrity { get { return _SkinIntegrity; } set { _SkinIntegrity = value; } }

    private bool _DiscussWithPat; public bool DiscussWithPat { get { return _DiscussWithPat; } set { _DiscussWithPat = value; } }
    private string _DiscussWithPat_Remark; public string DiscussWithPat_Remark { get { return _DiscussWithPat_Remark; } set { _DiscussWithPat_Remark = value; } }

    private bool _DiscussWithRelative; public bool DiscussWithRelative { get { return _DiscussWithRelative; } set { _DiscussWithRelative = value; } }
    private string _DiscussWithRelative_Remark; public string DiscussWithRelative_Remark { get { return _DiscussWithRelative_Remark; } set { _DiscussWithRelative_Remark = value; } }

    //-------------------------------------
    private string _BloodPRessure;
    public string BloodPRessure { get { return _BloodPRessure; } set { _BloodPRessure = value; } }
    private string _Temp;
    public string Temp { get { return _Temp; } set { _Temp = value; } }
    private string _Pulse;
    public string Pulse { get { return _Pulse; } set { _Pulse = value; } }
    private string _RespRate;
    public string RespRate { get { return _RespRate; } set { _RespRate = value; } }
    private string _UrinaryOutput;
    public string UrinaryOutput { get { return _UrinaryOutput; } set { _UrinaryOutput = value; } }
    private string _FHR;
    public string FHR { get { return _FHR; } set { _FHR = value; } }
    private string _MISC;
    public string MISC { get { return _MISC; } set { _MISC = value; } }
    private string _Contractions;
    public string Contractions { get { return _Contractions; } set { _Contractions = value; } }
    private string _NamePosition;
    public string NamePosition { get { return _NamePosition; } set { _NamePosition = value; } }
    
    

 }