using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DALPostpartumExamination
/// </summary>
public class DALColposcopy
{
    public DALColposcopy()
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

    private DateTime _ColposcopyDate;
    public DateTime ColposcopyDate { get { return _ColposcopyDate; } set { _ColposcopyDate = value; } }

  

    private string _PapsmearReport;
    public string PapsmearReport { get { return _PapsmearReport; } set { _PapsmearReport = value; } }
    private string _Ect_Cervix;
    public string Ect_Cervix { get { return _Ect_Cervix; } set { _Ect_Cervix = value; } }

    private string _SCJ;
    public string SCJ { get { return _SCJ; } set { _SCJ = value; } }
    private string _TransitionZone;
    public string TransitionZone { get { return _TransitionZone; } set { _TransitionZone = value; } }

    private string _Biopsysites;
    public string Biopsysites { get { return _Biopsysites; } set { _Biopsysites = value; } }


    private string _ActoWhiteArea;
    public string ActoWhiteArea { get { return _ActoWhiteArea; } set { _ActoWhiteArea = value; } }
  
    


  
    
}