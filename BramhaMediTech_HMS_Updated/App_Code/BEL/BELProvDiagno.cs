using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BELProvDiagno
/// </summary>
public class BELProvDiagno
{
	public BELProvDiagno()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    private int _ProvDiagnoId;
    public int ProvDiagnoId { get { return _ProvDiagnoId; } set { _ProvDiagnoId = value; } }


    private string _ProvDiagno;
    public string ProvDiagno { get { return _ProvDiagno; } set { _ProvDiagno = value; } }


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