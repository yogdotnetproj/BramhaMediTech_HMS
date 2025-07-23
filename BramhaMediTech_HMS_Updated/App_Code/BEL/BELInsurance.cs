using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BELInsurance
/// </summary>
public class BELInsurance
{
	public BELInsurance()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private int _InsuranceCompanyId;

    public int InsuranceCompanyId { get { return _InsuranceCompanyId; } set { _InsuranceCompanyId = value; } }

    private string _InsuranceCompanyName;

    public string InsuranceCompanyName { get { return _InsuranceCompanyName; } set { _InsuranceCompanyName = value; } }

    private string _InsuranceCompanyAddress;

    public string InsuranceCompanyAddress { get { return _InsuranceCompanyAddress; } set { _InsuranceCompanyAddress = value; } }

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

    private int _FId;

    public int FId { get { return _FId; } set { _FId = value; } }

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
    private int _PatRegId;

    public int PatRegId
    {
        get { return _PatRegId; }
        set { _PatRegId = value; }
    }
    private int _IpdId;

    public int IpdId { get { return _IpdId; } set { _IpdId = value; } }
    private bool _IsInsuranceCompany;

    public bool IsInsuranceCompany { get { return _IsInsuranceCompany; } set { _IsInsuranceCompany = value; } }

    private bool _IsCorporateCompany;
    public bool IsCorporateCompany { get { return _IsCorporateCompany; } set { _IsCorporateCompany = value; } }

    private string _CompanyType;
    public string CompanyType { get { return _CompanyType; } set { _CompanyType = value; } }

    private int _TitleId;
    public int TitleId { get { return _TitleId; } set { _TitleId = value; } }

    private string _MemberName;
    public string MemberName { get { return _MemberName; } set { _MemberName = value; } }

    private string _MembershipNo;
    public string MembershipNo { get { return _MembershipNo; } set { _MembershipNo = value; } }

    private string _Relation;
    public string Relation { get { return _Relation; } set { _Relation = value; } }


   

}