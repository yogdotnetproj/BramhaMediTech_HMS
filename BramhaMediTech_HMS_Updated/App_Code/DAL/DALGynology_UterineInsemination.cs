using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DALPostpartumExamination
/// </summary>
public class DALGynology_UterineInsemination
{
    public DALGynology_UterineInsemination()
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

    private DateTime _LastLMP;
    public DateTime LastLMP { get { return _LastLMP; } set { _LastLMP = value; } }

    private string _LMPRemark;
    public string LMPRemark { get { return _LMPRemark; } set { _LMPRemark = value; } }
    private string _Clomifene;
    public string Clomifene { get { return _Clomifene; } set { _Clomifene = value; } }

    private string _LetroZole;
    public string LetroZole { get { return _LetroZole; } set { _LetroZole = value; } }
    private string _Metformin;
    public string Metformin { get { return _Metformin; } set { _Metformin = value; } }
    private string _Inj_FSH;
    public string Inj_FSH { get { return _Inj_FSH; } set { _Inj_FSH = value; } }

    private DateTime _FollCareDate;
    public DateTime FollCareDate { get { return _FollCareDate; } set { _FollCareDate = value; } }

    private string _FollicareDay;
    public string FollicareDay { get { return _FollicareDay; } set { _FollicareDay = value; } }
    private string _FolliclesRightOvary;
    public string FolliclesRightOvary { get { return _FolliclesRightOvary; } set { _FolliclesRightOvary = value; } }
    private string _FolliclesLiftOvary;
    public string FolliclesLiftOvary { get { return _FolliclesLiftOvary; } set { _FolliclesLiftOvary = value; } }
    private string _Endometrial;
    public string Endometrial { get { return _Endometrial; } set { _Endometrial = value; } }
    private string _FolliclesPlan;
    public string FolliclesPlan { get { return _FolliclesPlan; } set { _FolliclesPlan = value; } }

    private string _FolliclesRemark;
    public string FolliclesRemark { get { return _FolliclesRemark; } set { _FolliclesRemark = value; } }
    private string _FolliclesTrigger;
    public string FolliclesTrigger { get { return _FolliclesTrigger; } set { _FolliclesTrigger = value; } }
    private string _Motility;
    public string Motility { get { return _Motility; } set { _Motility = value; } }

    private DateTime _IUIDate;
    public DateTime IUIDate { get { return _IUIDate; } set { _IUIDate = value; } }





    private string _LutealSupport;
    public string LutealSupport { get { return _LutealSupport; } set { _LutealSupport = value; } }
    private string _FolliclesCount;
    public string FolliclesCount { get { return _FolliclesCount; } set { _FolliclesCount = value; } }
    private string _FolliclesComments;
    public string FolliclesComments { get { return _FolliclesComments; } set { _FolliclesComments = value; } }


  
    
}