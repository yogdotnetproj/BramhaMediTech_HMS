using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BELSDC
/// </summary>
public class BELSDC
{
	public BELSDC()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private int _CountryId; public int CountryId { get { return _CountryId; } set { _CountryId = value; } }
    private string _CountryName; public string CountryName { get { return _CountryName; } set { _CountryName = value; } }
    private string _CountryCode; public string CountryCode { get { return _CountryCode; } set { _CountryCode = value; } }

    private bool _IsActive; public bool IsActive { get { return _IsActive; } set { _IsActive = value; } }
    private string _CreatedBy; public string CreatedBy { get { return _CreatedBy; } set { _CreatedBy = value; } }
    private DateTime _CreatedOn; public DateTime CreatedOn { get { return _CreatedOn; } set { _CreatedOn = value; } }
    private string _UpdatedBy; public string UpdatedBy { get { return _UpdatedBy; } set { _UpdatedBy = value; } }

    private DateTime _UpdatedOn; public DateTime UpdatedOn { get { return _UpdatedOn; } set { _UpdatedOn = value; } }

    private int _BranchId; public int BranchId { get { return _BranchId; } set { _BranchId = value; } }

    private int _StateId; public int StateId { get { return _StateId; } set { _StateId = value; } }
   
      
    private string _StateName; public string StateName { get { return _StateName; } set { _StateName = value; } }

    private int _CityId; public int CityId { get { return _CityId; } set { _CityId = value; } }


    private string _CityName; public string CityName { get { return _CityName; } set { _CityName = value; } }
   
}