using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BELIpdRateType
/// </summary>
public class BELIpdRateType
{
	public BELIpdRateType()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private int _RateTypeIpdId;
    public int RateTypeIpdId { get { return _RateTypeIpdId; } set { _RateTypeIpdId = value; } }

    private int _RateTypeId;
    public int RateTypeId { get { return _RateTypeId; } set { _RateTypeId = value; } }

    private string _RateType;
    public string RateType { get { return _RateType; } set { _RateType = value; } }

    private int _PatientInsuTypeId;
    public int PatientInsuTypeId { get { return _PatientInsuTypeId; } set { _PatientInsuTypeId = value; } }

    private string _PatientInsuType;
    public string PatientInsuType { get { return _PatientInsuType; } set { _PatientInsuType = value; } }

    private int _PatMainTypeId;
    public int PatMainTypeId { get { return _PatMainTypeId; } set { _PatMainTypeId = value; } }

    private string _PatMainType;
    public string PatMainType { get { return _PatMainType; } set { _PatMainType = value; } }

    private int _RTypeId;
    public int RTypeId { get { return _RTypeId; } set { _RTypeId = value; } }

    private string _RType;
    public string RType { get { return _RType; } set { _RType = value; } }



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