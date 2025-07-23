using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DALPostpartumExamination
/// </summary>
public class DALIVFFollicular
{
    public DALIVFFollicular()
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

    private string _StimulationProtocol;
    public string StimulationProtocol { get { return _StimulationProtocol; } set { _StimulationProtocol = value; } }

    private DateTime _StimulationDate;
    public DateTime StimulationDate { get { return _StimulationDate; } set { _StimulationDate = value; } }

    private string _CycleDay;
    public string CycleDay { get { return _CycleDay; } set { _CycleDay = value; } }

    private string _SimulationDay ;
    public string SimulationDay { get { return _SimulationDay; } set { _SimulationDay = value; } }

    private string _RightOvary;
    public string RightOvary { get { return _RightOvary; } set { _RightOvary = value; } }

    private string _LeftOvary;
    public string LeftOvary { get { return _LeftOvary; } set { _LeftOvary = value; } }

    private string _EndometriumMM;
    public string EndometriumMM { get { return _EndometriumMM; } set { _EndometriumMM = value; } }
    
    private string _Plan;
    public string Plan { get { return _Plan; } set { _Plan = value; } }

    private string _Remarks;
    public string Remarks { get { return _Remarks; } set { _Remarks = value; } }


  
    
}