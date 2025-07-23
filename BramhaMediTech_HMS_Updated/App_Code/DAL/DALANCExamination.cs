using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DALPostpartumExamination
/// </summary>
public class DALANCExamination
{
    public DALANCExamination()
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
    private DateTime _EstDeliveryDate;
    public DateTime EstDeliveryDate { get { return _EstDeliveryDate; } set { _EstDeliveryDate = value; } }
    private string _FundelHeight;
    public string FundelHeight { get { return _FundelHeight; } set { _FundelHeight = value; } }
    private string _Gestation;
    public string Gestation { get { return _Gestation; } set { _Gestation = value; } }

    private bool _FotealMovement;
    public bool FotealMovement { get { return _FotealMovement; } set { _FotealMovement = value; } }

    private string _Parity;
    public string Parity { get { return _Parity; } set { _Parity = value; } }
    private string _FeatelHEarthBeat;
    public string FeatelHEarthBeat { get { return _FeatelHEarthBeat; } set { _FeatelHEarthBeat = value; } }

    private bool _TT1;
    public bool TT1 { get { return _TT1; } set { _TT1 = value; } }
    private bool _TT2;
    public bool TT2 { get { return _TT2; } set { _TT2 = value; } }
    private bool _IPT1;
    public bool IPT1 { get { return _IPT1; } set { _IPT1 = value; } }
    private bool _IPT2;
    public bool IPT2 { get { return _IPT2; } set { _IPT2 = value; } }
    private bool _HIV;
    public bool HIV { get { return _HIV; } set { _HIV = value; } }
    private bool _HB;
    public bool HB { get { return _HB; } set { _HB = value; } }
    private bool _BloodGroup;
    public bool BloodGroup { get { return _BloodGroup; } set { _BloodGroup = value; } }
    private bool _SyphilisTest;
    public bool SyphilisTest { get { return _SyphilisTest; } set { _SyphilisTest = value; } }
    private bool _Urinalysis;
    public bool Urinalysis { get { return _Urinalysis; } set { _Urinalysis = value; } }
    private bool _UltrasoundScan;
    public bool UltrasoundScan { get { return _UltrasoundScan; } set { _UltrasoundScan = value; } }


    private string _BPD;
    public string BPD { get { return _BPD; } set { _BPD = value; } }
    private string _FL;
    public string FL { get { return _FL; } set { _FL = value; } }
    private string _HL;
    public string HL { get { return _HL; } set { _HL = value; } }
    private string _HC;
    public string HC { get { return _HC; } set { _HC = value; } }
    private string _AC;
    public string AC { get { return _AC; } set { _AC = value; } }
    private string _Estimatedfoetalsize;
    public string Estimatedfoetalsize { get { return _Estimatedfoetalsize; } set { _Estimatedfoetalsize = value; } }
    private string _EstimatedfoetalWidth;
    public string EstimatedfoetalWidth { get { return _EstimatedfoetalWidth; } set { _EstimatedfoetalWidth = value; } }
    private string _Complant;
    public string Complant { get { return _Complant; } set { _Complant = value; } }
    private string _Conclusion;
    public string Conclusion { get { return _Conclusion; } set { _Conclusion = value; } }

   

    

   
    
}