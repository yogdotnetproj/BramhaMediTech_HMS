using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DALPostpartumExamination
/// </summary>
public class DALInfertility
{
    public DALInfertility()
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


    private DateTime _LMPDate;
    public DateTime LMPDate { get { return _LMPDate; } set { _LMPDate = value; } }
    private string _RPR;
    public string RPR { get { return _RPR; } set { _RPR = value; } }
    private string _YearOfInfert;
    public string YearOfInfert { get { return _YearOfInfert; } set { _YearOfInfert = value; } }
    private string _YearOfInfert1;
    public string YearOfInfert1 { get { return _YearOfInfert1; } set { _YearOfInfert1 = value; } }
    private string _HIV;
    public string HIV { get { return _HIV; } set { _HIV = value; } }
    private string _AFC;
    public string AFC { get { return _AFC; } set { _AFC = value; } }
    private string _RBS;
    public string RBS { get { return _RBS; } set { _RBS = value; } }

    private string _HepB;
    public string HepB { get { return _HepB; } set { _HepB = value; } }
    private string _HepC;
    public string HepC { get { return _HepC; } set { _HepC = value; } }

    private string _BloodGrouping;
    public string BloodGrouping { get { return _BloodGrouping; } set { _BloodGrouping = value; } }
    //---------------------------------------------------------

    private string _PartnerName;
    public string PartnerName { get { return _PartnerName; } set { _PartnerName = value; } }
    private string _PartnerAge;
    public string PartnerAge { get { return _PartnerAge; } set { _PartnerAge = value; } }

    private string _ParHIV;
    public string ParHIV { get { return _ParHIV; } set { _ParHIV = value; } }
    private string _ParHepB;
    public string ParHepB { get { return _ParHepB; } set { _ParHepB = value; } }
    private string _RarHepC;
    public string RarHepC { get { return _RarHepC; } set { _RarHepC = value; } }
    //--------------------------------------------------------
    private string _FSH;
    public string FSH { get { return _FSH; } set { _FSH = value; } }
    private string _AMH;
    public string AMH { get { return _AMH; } set { _AMH = value; } }
    private string _LH;
    public string LH { get { return _LH; } set { _LH = value; } }

    private string _Prolact;
    public string Prolact { get { return _Prolact; } set { _Prolact = value; } }
    private string _TSH;
    public string TSH { get { return _TSH; } set { _TSH = value; } }
    private string _E2;
    public string E2 { get { return _E2; } set { _E2 = value; } }

    private string _T3;
    public string T3 { get { return _T3; } set { _T3 = value; } }
    private string _T4;
    public string T4 { get { return _T4; } set { _T4 = value; } }
    private string _P4;
    public string P4 { get { return _P4; } set { _P4 = value; } }
    private string _CMV;
    public string CMV { get { return _CMV; } set { _CMV = value; } }
    //------------------------------------


    private string _SemenAnalysisNote;
    public string SemenAnalysisNote { get { return _SemenAnalysisNote; } set { _SemenAnalysisNote = value; } }
    private string _Fibroids;
    public string Fibroids { get { return _Fibroids; } set { _Fibroids = value; } }
    private string _Endometriosis;
    public string Endometriosis { get { return _Endometriosis; } set { _Endometriosis = value; } }
    private string _Cycts;
    public string Cycts { get { return _Cycts; } set { _Cycts = value; } }
    private string _Hydrosalpinx;
    public string Hydrosalpinx { get { return _Hydrosalpinx; } set { _Hydrosalpinx = value; } }
    //--------------------------------------------------

    private string _UltrasoundFinding;
    public string UltrasoundFinding { get { return _UltrasoundFinding; } set { _UltrasoundFinding = value; } }
    private string _HysteroscopyFinding;
    public string HysteroscopyFinding { get { return _HysteroscopyFinding; } set { _HysteroscopyFinding = value; } }
    private string _LaparoscopyFinding;
    public string LaparoscopyFinding { get { return _LaparoscopyFinding; } set { _LaparoscopyFinding = value; } }
    private string _Notes;
    public string Notes { get { return _Notes; } set { _Notes = value; } }
    


  
    
}