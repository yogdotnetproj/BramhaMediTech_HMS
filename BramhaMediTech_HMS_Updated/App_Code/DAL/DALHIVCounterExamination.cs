using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DALPostpartumExamination
/// </summary>
public class DALHIVCounterExamination
{
    public DALHIVCounterExamination()
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

    private bool _PatientAdult;
    public bool PatientAdult { get { return _PatientAdult; } set { _PatientAdult = value; } }
    private bool _MTCTPluse;
    public bool MTCTPluse { get { return _MTCTPluse; } set { _MTCTPluse = value; } }
    private bool _Married;
    public bool Married { get { return _Married; } set { _Married = value; } }
    private bool _DiscloseToHubby;
    public bool DiscloseToHubby { get { return _DiscloseToHubby; } set { _DiscloseToHubby = value; } }

    private string _Numberofwives;
    public string Numberofwives { get { return _Numberofwives; } set { _Numberofwives = value; } }
    private string _NumberofChildren;
    public string NumberofChildren { get { return _NumberofChildren; } set { _NumberofChildren = value; } }
    private bool _Divorced;
    public bool Divorced { get { return _Divorced; } set { _Divorced = value; } }
    private string _AgeofFirstchild;
    public string AgeofFirstchild { get { return _AgeofFirstchild; } set { _AgeofFirstchild = value; } }
    private string _AgeofLastchild;
    public string AgeofLastchild { get { return _AgeofLastchild; } set { _AgeofLastchild = value; } }


    private bool _SpouseDead;
    public bool SpouseDead { get { return _SpouseDead; } set { _SpouseDead = value; } }
    private bool _SuspicionHIVcauseofdead;
    public bool SuspicionHIVcauseofdead { get { return _SuspicionHIVcauseofdead; } set { _SuspicionHIVcauseofdead = value; } }

    private bool _SexualpartnerdiedofHIV;
    public bool SexualpartnerdiedofHIV { get { return _SexualpartnerdiedofHIV; } set { _SexualpartnerdiedofHIV = value; } }
    private bool _SpouseawareofHIV;
    public bool SpouseawareofHIV { get { return _SpouseawareofHIV; } set { _SpouseawareofHIV = value; } }
    private bool _SexPartnerOutsideMarraige;
    public bool SexPartnerOutsideMarraige { get { return _SexPartnerOutsideMarraige; } set { _SexPartnerOutsideMarraige = value; } }
    private bool _SpouseSexOutsideMarraige;
    public bool SpouseSexOutsideMarraige { get { return _SpouseSexOutsideMarraige; } set { _SpouseSexOutsideMarraige = value; } }
    private bool _SexuallyActivity6Month;
    public bool SexuallyActivity6Month { get { return _SexuallyActivity6Month; } set { _SexuallyActivity6Month = value; } }
    private bool _AlwaysuseCondom;
    public bool AlwaysuseCondom { get { return _AlwaysuseCondom; } set { _AlwaysuseCondom = value; } }

    private bool _HIVTheraphy;
    public bool HIVTheraphy { get { return _HIVTheraphy; } set { _HIVTheraphy = value; } }
    private string _NumberOfPartner;
    public string NumberOfPartner { get { return _NumberOfPartner; } set { _NumberOfPartner = value; } }
    private string _Comments;
    public string Comments { get { return _Comments; } set { _Comments = value; } }


  
    
}