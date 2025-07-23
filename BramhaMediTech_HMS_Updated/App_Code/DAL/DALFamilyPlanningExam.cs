using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DALPostpartumExamination
/// </summary>
public class DALFamilyPlanningExam
{
    public DALFamilyPlanningExam()
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

    private string _HCG;
    public string HCG { get { return _HCG; } set { _HCG = value; } }
    private string _Leukocytes;
    public string Leukocytes { get { return _Leukocytes; } set { _Leukocytes = value; } }
    private string _Nitrite;
    public string Nitrite { get { return _Nitrite; } set { _Nitrite = value; } }
    private string _Protein;
    public string Protein { get { return _Protein; } set { _Protein = value; } }
    private string _Glucose;
    public string Glucose { get { return _Glucose; } set { _Glucose = value; } }


    private string _Blood;
    public string Blood { get { return _Blood; } set { _Blood = value; } }

    private string _PH;
    public string PH { get { return _PH; } set { _PH = value; } }
    private string _SpecificGravity;
    public string SpecificGravity { get { return _SpecificGravity; } set { _SpecificGravity = value; } }
    private string _Ketone;
    public string Ketone { get { return _Ketone; } set { _Ketone = value; } }
    private string _Urobilinogen;
    public string Urobilinogen { get { return _Urobilinogen; } set { _Urobilinogen = value; } }
    private string _Biliruben;
    public string Biliruben { get { return _Biliruben; } set { _Biliruben = value; } }
    private string _Remarks;
    public string Remarks { get { return _Remarks; } set { _Remarks = value; } }

    private bool _FatherAChild;
    public bool FatherAChild { get { return _FatherAChild; } set { _FatherAChild = value; } }
    private bool _FatherNevChild;
    public bool FatherNevChild { get { return _FatherNevChild; } set { _FatherNevChild = value; } }
    private bool _IsOccuption;
    public bool IsOccuption { get { return _IsOccuption; } set { _IsOccuption = value; } }
    private bool _TabaccoUse;
    public bool TabaccoUse { get { return _TabaccoUse; } set { _TabaccoUse = value; } }
    private bool _DrugUse;
    public bool DrugUse { get { return _DrugUse; } set { _DrugUse = value; } }

    private string _OccitpionRemark;
    public string OccitpionRemark { get { return _OccitpionRemark; } set { _OccitpionRemark = value; } }
    private string _TabaccoRemark;
    public string TabaccoRemark { get { return _TabaccoRemark; } set { _TabaccoRemark = value; } }
    private string _DrugUseRemark;
    public string DrugUseRemark { get { return _DrugUseRemark; } set { _DrugUseRemark = value; } }


    private bool _MenstrualCyclesRegular;
    public bool MenstrualCyclesRegular { get { return _MenstrualCyclesRegular; } set { _MenstrualCyclesRegular = value; } }
    private string _MenstrualCyclesRemark;
    public string MenstrualCyclesRemark { get { return _MenstrualCyclesRemark; } set { _MenstrualCyclesRemark = value; } }

    private bool _MenstrualCyclesIrregular;
    public bool MenstrualCyclesIrregular { get { return _MenstrualCyclesIrregular; } set { _MenstrualCyclesIrregular = value; } }
    private string _MenstrualCyclesIrregularRemark;
    public string MenstrualCyclesIrregularRemark { get { return _MenstrualCyclesIrregularRemark; } set { _MenstrualCyclesIrregularRemark = value; } }

    private bool _CoitalFrequency;
    public bool CoitalFrequency { get { return _CoitalFrequency; } set { _CoitalFrequency = value; } }
    private string _CoitalFrequencyRemark;
    public string CoitalFrequencyRemark { get { return _CoitalFrequencyRemark; } set { _CoitalFrequencyRemark = value; } }

    private bool _Dysmenorrhea;
    public bool Dysmenorrhea { get { return _Dysmenorrhea; } set { _Dysmenorrhea = value; } }
    private string _DysmenorrheaRemark;
    public string DysmenorrheaRemark { get { return _DysmenorrheaRemark; } set { _DysmenorrheaRemark = value; } }

    private bool _PelvicPain;
    public bool PelvicPain { get { return _PelvicPain; } set { _PelvicPain = value; } }
    private string _PelvicPainRemark;
    public string PelvicPainRemark { get { return _PelvicPainRemark; } set { _PelvicPainRemark = value; } }

    private bool _HSGResult;
    public bool HSGResult { get { return _HSGResult; } set { _HSGResult = value; } }
    private string _HSGResultRemark;
    public string HSGResultRemark { get { return _HSGResultRemark; } set { _HSGResultRemark = value; } }

    private bool _SemenAnalysis;
    public bool SemenAnalysis { get { return _SemenAnalysis; } set { _SemenAnalysis = value; } }
    private string _SemenAnalysisRemark;
    public string SemenAnalysisRemark { get { return _SemenAnalysisRemark; } set { _SemenAnalysisRemark = value; } }

    private bool _Clomid;
    public bool Clomid { get { return _Clomid; } set { _Clomid = value; } }
    private string _ClomidRemark;
    public string ClomidRemark { get { return _ClomidRemark; } set { _ClomidRemark = value; } }

    private bool _GnRHAgonists;
    public bool GnRHAgonists { get { return _GnRHAgonists; } set { _GnRHAgonists = value; } }
    private string _GnRHAgonistsRemark;
    public string GnRHAgonistsRemark { get { return _GnRHAgonistsRemark; } set { _GnRHAgonistsRemark = value; } }

    private bool _IUI;
    public bool IUI { get { return _IUI; } set { _IUI = value; } }
    private string _IUIRemark;
    public string IUIRemark { get { return _IUIRemark; } set { _IUIRemark = value; } }

    private bool _IVF;
    public bool IVF { get { return _IVF; } set { _IVF = value; } }
    private string _IVFRemark;
    public string IVFRemark { get { return _IVFRemark; } set { _IVFRemark = value; } }

    private bool _Hysteroscopy;
    public bool Hysteroscopy { get { return _Hysteroscopy; } set { _Hysteroscopy = value; } }
    private string _HysteroscopyRemark;
    public string HysteroscopyRemark { get { return _HysteroscopyRemark; } set { _HysteroscopyRemark = value; } }

    private bool _Laparoscopy;
    public bool Laparoscopy { get { return _Laparoscopy; } set { _Laparoscopy = value; } }
    private string _LaparoscopyRemark;
    public string LaparoscopyRemark { get { return _LaparoscopyRemark; } set { _LaparoscopyRemark = value; } }


    

   
    
}