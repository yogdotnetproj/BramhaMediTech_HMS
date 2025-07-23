using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DALPostpartumExamination
/// </summary>
public class DALBreastLumpExamination
{
    public DALBreastLumpExamination()
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
    private string _HPIComment;
    public string HPIComment { get { return _HPIComment; } set { _HPIComment = value; } }


    private string _LeftBrestComplant;
    public string LeftBrestComplant { get { return _LeftBrestComplant; } set { _LeftBrestComplant = value; } }
    private string _LeftBrestComplantDuration;
    public string LeftBrestComplantDuration { get { return _LeftBrestComplantDuration; } set { _LeftBrestComplantDuration = value; } }
    private bool _LeftSoftCystic;
    public bool LeftSoftCystic { get { return _LeftSoftCystic; } set { _LeftSoftCystic = value; } }
    private string _LeftSoftCysticComment;
    public string LeftSoftCysticComment { get { return _LeftSoftCysticComment; } set { _LeftSoftCysticComment = value; } }
    private bool _LeftFirm;
    public bool LeftFirm { get { return _LeftFirm; } set { _LeftFirm = value; } }
    private string _LeftFirmComment;
    public string LeftFirmComment { get { return _LeftFirmComment; } set { _LeftFirmComment = value; } }
    private bool _LeftMobile;
    public bool LeftMobile { get { return _LeftMobile; } set { _LeftMobile = value; } }
    private string _LeftMobileComment;
    public string LeftMobileComment { get { return _LeftMobileComment; } set { _LeftMobileComment = value; } }
    private bool _LeftPreMenopausal;
    public bool LeftPreMenopausal { get { return _LeftPreMenopausal; } set { _LeftPreMenopausal = value; } }
    private string _LeftPostMenopausal;
    public string LeftPostMenopausal { get { return _LeftPostMenopausal; } set { _LeftPostMenopausal = value; } }

    private string _RightBrestComplant;
    public string RightBrestComplant { get { return _RightBrestComplant; } set { _RightBrestComplant = value; } }
    private string _RightBrestComplantDuration;
    public string RightBrestComplantDuration { get { return _RightBrestComplantDuration; } set { _RightBrestComplantDuration = value; } }
    private bool _RightSoftCystic;
    public bool RightSoftCystic { get { return _RightSoftCystic; } set { _RightSoftCystic = value; } }
    private string _RightSoftCysticComment;
    public string RightSoftCysticComment { get { return _RightSoftCysticComment; } set { _RightSoftCysticComment = value; } }
    private bool _RightFirm;
    public bool RightFirm { get { return _RightFirm; } set { _RightFirm = value; } }
    private string _RightFirmComment;
    public string RightFirmComment { get { return _RightFirmComment; } set { _RightFirmComment = value; } }
    private bool _RightMobile;
    public bool RightMobile { get { return _RightMobile; } set { _RightMobile = value; } }
    private string _RightMobileComment;
    public string RightMobileComment { get { return _RightMobileComment; } set { _RightMobileComment = value; } }
    private bool _RightPreMenopausal;
    public bool RightPreMenopausal { get { return _RightPreMenopausal; } set { _RightPreMenopausal = value; } }
    private string _RightPostMenopausal;
    public string RightPostMenopausal { get { return _RightPostMenopausal; } set { _RightPostMenopausal = value; } }


    private bool _Fibrocystic;
    public bool Fibrocystic { get { return _Fibrocystic; } set { _Fibrocystic = value; } }
    private bool _Clinicallyfeels;
    public bool Clinicallyfeels { get { return _Clinicallyfeels; } set { _Clinicallyfeels = value; } }
    private bool _ClinicallySuspicious;
    public bool ClinicallySuspicious { get { return _ClinicallySuspicious; } set { _ClinicallySuspicious = value; } }

    private string _Comments;
    public string Comments { get { return _Comments; } set { _Comments = value; } }

   
    
}