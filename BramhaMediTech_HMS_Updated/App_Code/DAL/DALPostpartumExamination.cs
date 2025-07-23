using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DALPostpartumExamination
/// </summary>
public class DALPostpartumExamination
{
	public DALPostpartumExamination()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private string _Patregid;
    public string Patregid { get { return _Patregid; } set { _Patregid = value; } }
    private int _OpdNo;
    public int OpdNo { get { return _OpdNo; } set { _OpdNo = value; } }
    private int _IpdNo;
    public int IpdNo { get { return _IpdNo; } set { _IpdNo = value; } }
    private string _CreatedBy;
    public string CreatedBy { get { return _CreatedBy; } set { _CreatedBy = value; } }

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


    private bool _DouSmoke;
    public bool DouSmoke { get { return _DouSmoke; } set { _DouSmoke = value; } }
    private string _SmokeRemark;
    public string SmokeRemark { get { return _SmokeRemark; } set { _SmokeRemark = value; } }
    private string _SmokeDateQuite;
    public string SmokeDateQuite { get { return _SmokeDateQuite; } set { _SmokeDateQuite = value; } }

    private bool _Depression;
    public bool Depression { get { return _Depression; } set { _Depression = value; } }

    private string _DepressionRemark;
    public string DepressionRemark { get { return _DepressionRemark; } set { _DepressionRemark = value; } }

    private string _Feeding;
    public string Feeding { get { return _Feeding; } set { _Feeding = value; } }
    private string _FeedingRemark;
    public string FeedingRemark { get { return _FeedingRemark; } set { _FeedingRemark = value; } }

    private string _Bleeding;
    public string Bleeding { get { return _Bleeding; } set { _Bleeding = value; } }
    private string _BleedingRemark;
    public string BleedingRemark { get { return _BleedingRemark; } set { _BleedingRemark = value; } }

    private string _BrestExam;
    public string BrestExam { get { return _BrestExam; } set { _BrestExam = value; } }
    private string _BrestRemark;
    public string BrestRemark { get { return _BrestRemark; } set { _BrestRemark = value; } }

    private string _BrestComplant;
    public string BrestComplant { get { return _BrestComplant; } set { _BrestComplant = value; } }

    private string _CSection;
    public string CSection { get { return _CSection; } set { _CSection = value; } }
    private string _CSectionRemark;
    public string CSectionRemark { get { return _CSectionRemark; } set { _CSectionRemark = value; } }

    private string _Episiotomy;
    public string Episiotomy { get { return _Episiotomy; } set { _Episiotomy = value; } }
    private string _EpisiotomyRemark;
    public string EpisiotomyRemark { get { return _EpisiotomyRemark; } set { _EpisiotomyRemark = value; } }

    private string _Uterus;
    public string Uterus { get { return _Uterus; } set { _Uterus = value; } }
    private string _UterusRemark;
    public string UterusRemark { get { return _UterusRemark; } set { _UterusRemark = value; } }

    private string _BirthControl;
    public string BirthControl { get { return _BirthControl; } set { _BirthControl = value; } }
    private string _BirthControlRemark;
    public string BirthControlRemark { get { return _BirthControlRemark; } set { _BirthControlRemark = value; } }
    private string _GeneralRemark;
    public string GeneralRemark { get { return _GeneralRemark; } set { _GeneralRemark = value; } }

    private int _InsuranceCompName;
    public int InsuranceCompName { get { return _InsuranceCompName; } set { _InsuranceCompName = value; } }

    private int _DrId;
    public int DrId { get { return _DrId; } set { _DrId = value; } }

    
    private DateTime _DateofConsultant;
    public DateTime DateofConsultant { get { return _DateofConsultant; } set { _DateofConsultant = value; } }

    private string _NameofEmployer;
    public string NameofEmployer { get { return _NameofEmployer; } set { _NameofEmployer = value; } }
    private string _NameofEmployee;
    public string NameofEmployee { get { return _NameofEmployee; } set { _NameofEmployee = value; } }
    private string _CertificateNo;
    public string CertificateNo { get { return _CertificateNo; } set { _CertificateNo = value; } }
    private string _Age;
    public string Age { get { return _Age; } set { _Age = value; } }
    private string _RelationshipPatToEmployee;
    public string RelationshipPatToEmployee { get { return _RelationshipPatToEmployee; } set { _RelationshipPatToEmployee = value; } }
    private string _Accidentoccur;
    public string Accidentoccur { get { return _Accidentoccur; } set { _Accidentoccur = value; } }
    private string _Injuryorsickness;
    public string Injuryorsickness { get { return _Injuryorsickness; } set { _Injuryorsickness = value; } }
    private string _Illnessorcondition;
    public string Illnessorcondition { get { return _Illnessorcondition; } set { _Illnessorcondition = value; } }
    private string _patientcovered;
    public string patientcovered { get { return _patientcovered; } set { _patientcovered = value; } }
    private string _Duetopregnancy;
    public string Duetopregnancy { get { return _Duetopregnancy; } set { _Duetopregnancy = value; } }


    private string _Similarondition;
    public string Similarondition { get { return _Similarondition; } set { _Similarondition = value; } }
    private string _DiagnosisofDoctor;
    public string DiagnosisofDoctor { get { return _DiagnosisofDoctor; } set { _DiagnosisofDoctor = value; } }
    private string _TestPrescribed;
    public string TestPrescribed { get { return _TestPrescribed; } set { _TestPrescribed = value; } }
    private string _MedicationPrescribed;
    public string MedicationPrescribed { get { return _MedicationPrescribed; } set { _MedicationPrescribed = value; } }
   

    
    
}