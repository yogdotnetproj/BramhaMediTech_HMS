using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BELCorporateCompany
/// </summary>
public class BELCorporateCompany
{
	public BELCorporateCompany()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private int _CorporateCompanyId;

    public int CorporateCompanyId { get { return _CorporateCompanyId; } set { _CorporateCompanyId = value; } }

    private string _CorporateCompanyName;

    public string CorporateCompanyName { get { return _CorporateCompanyName; } set { _CorporateCompanyName = value; } }

    private string _CorporateCompanyAddress;

    public string CorporateCompanyAddress { get { return _CorporateCompanyAddress; } set { _CorporateCompanyAddress = value; } }

    private int _CountryId;

    public int CountryId { get { return _CountryId; } set { _CountryId = value; } }

    private string _CountryName;

    public string CountryName { get { return _CountryName; } set { _CountryName = value; } }

    private int _StateId;

    public int StateId { get { return _StateId; } set { _StateId = value; } }

    private string _StateName;

    public string StateName { get { return _StateName; } set { _StateName = value; } }

    private int _CityId;

    public int CityId { get { return _CityId; } set { _CityId = value; } }

    private string _CityName;

    public string CityName { get { return _CityName; } set { _CityName = value; } }

    private string _PostalCode;

    public string PostalCode { get { return _PostalCode; } set { _PostalCode = value; } }

    private string _Email;

    public string Email { get { return _Email; } set { _Email = value; } }

    private string _PhoneNo;

    public string PhoneNo { get { return _PhoneNo; } set { _PhoneNo = value; } }

    private string _FaxNo;


    public string FaxNo { get { return _FaxNo; } set { _FaxNo = value; } }

    private string _ContactPersonName;

    public string ContactPersonName { get { return _ContactPersonName; } set { _ContactPersonName = value; } }

    private string _CPMobileNo;

    public string CPMobileNo { get { return _CPMobileNo; } set { _CPMobileNo = value; } }

    private string _CPPhone;


    public string CPPhone { get { return _CPPhone; } set { _CPPhone = value; } }

    private string _CPEmail;

    public string CPEmail { get { return _CPEmail; } set { _CPEmail = value; } }

    private string _Notes;

    public string Notes { get { return _Notes; } set { _Notes = value; } }

    private string _FId;

    public string FId { get { return _FId; } set { _FId = value; } }

    private int _BranchId;

    public int BranchId { get { return _BranchId; } set { _BranchId = value; } }

    private bool _IsActive;

    public bool IsActive { get { return _IsActive; } set { _IsActive = value; } }

    private string _CreatedBy;

    public string CreatedBy { get { return _CreatedBy; } set { _CreatedBy = value; } }

    private DateTime _CreatedOn;

    public DateTime CreatedOn { get { return _CreatedOn; } set { _CreatedOn = value; } }

    private string _UpdatedBy;

    public string UpdatedBy { get { return _UpdatedBy; } set { _UpdatedBy = value; } }

    private DateTime _UpdatedOn;

    public DateTime UpdatedOn { get { return _UpdatedOn; } set { _UpdatedOn = value; } }
}