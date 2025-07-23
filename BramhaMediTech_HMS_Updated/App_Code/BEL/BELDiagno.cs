using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BELDiagno
/// </summary>
public class BELDiagno
{
	public BELDiagno()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private int _TrDiagnoId;
    public int TrDiagnoId { get { return _TrDiagnoId; } set { _TrDiagnoId = value; } }


    private string _TrDiagnoName;
    public string TrDiagnoName { get { return _TrDiagnoName; } set { _TrDiagnoName = value; } }

    private string _ICDId;
    public string ICDId { get { return _ICDId; } set { _ICDId = value; } }

    private int _TrDiagnostage2Id;
    public int TrDiagnostage2Id { get { return _TrDiagnostage2Id; } set { _TrDiagnostage2Id = value; } }


    private string _TrDiagnoNameStg2;
    public string TrDiagnoNameStg2 { get { return _TrDiagnoNameStg2; } set { _TrDiagnoNameStg2 = value; } }

    private string _Stage2Id;
    public string Stage2Id { get { return _Stage2Id; } set { _Stage2Id = value; } }

    private int _TrDiagnostage3Id;
    public int TrDiagnostage3Id { get { return _TrDiagnostage3Id; } set { _TrDiagnostage3Id = value; } }


    private string _TrDiagnoNameStg3;
    public string TrDiagnoNameStg3 { get { return _TrDiagnoNameStg3; } set { _TrDiagnoNameStg3 = value; } }

    private string _Stage3Id;
    public string Stage3Id { get { return _Stage3Id; } set { _Stage3Id = value; } }




    private string _FId;
    public string FId { get { return _FId; } set { _FId = value; } }

    private string _CreatedBy;
    public string CreatedBy { get { return _CreatedBy; } set { _CreatedBy = value; } }

    private DateTime _CreatedOn;
    public DateTime CreatedOn { get { return _CreatedOn; } set { _CreatedOn = value; } }

    private string _UpdatedBy;
    public string UpdatedBy { get { return _UpdatedBy; } set { _UpdatedBy = value; } }

    private DateTime _UpdatedOn;
    public DateTime UpdatedOn { get { return _UpdatedOn; } set { _UpdatedOn = value; } }

    private int _BranchId;
    public int BranchId { get { return _BranchId; } set { _BranchId = value; } }

}