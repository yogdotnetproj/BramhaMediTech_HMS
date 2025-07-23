using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BELReligion
/// </summary>
public class BELReligion
{
	public BELReligion()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private int _ReligionId; 
    public int ReligionId { get { return _ReligionId; } set { _ReligionId = value; } }

    private string _Religion; 
    public string Religion { get { return _Religion; } set { _Religion = value; } }    

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