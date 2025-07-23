using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BELPatientInformation
/// </summary>
public class BELPatientInformation
{
	public BELPatientInformation()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private int _DrId;

    public int DrId { get { return _DrId; } set { _DrId = value; } }

    private int _DeptId;
    public int DeptId { get { return _DeptId; } set { _DeptId = value; } }

    private int _ProcedureID;
    public int ProcedureID { get { return _ProcedureID; } set { _ProcedureID = value; } }
    
    private string _DeptName;

    public string DeptName { get { return _DeptName; } set { _DeptName = value; } }

    private string _DocName;

    public string DocName { get { return _DocName; } set { _DocName = value; } }

    private int _PatientInfoId;

    public int PatientInfoId { get { return _PatientInfoId; } set { _PatientInfoId = value; } }

    private int _FId;

    public int FId { get { return _FId; } set { _FId = value; } }

    private int _BranchId;

    public int BranchId { get { return _BranchId; } set { _BranchId = value; } }


    private string _PatRegId;

    public string PatRegId { get { return _PatRegId; } set { _PatRegId = value; } }

    private string _OPDNo;

    public string OPDNo { get { return _OPDNo; } set { _OPDNo = value; } }


    private int _PatientRegistrationId;

    public int PatientRegistrationId { get { return _PatientRegistrationId; } set { _PatientRegistrationId = value; } }


   
    private string _BarcodeId;

    public string BarcodeId { get { return _BarcodeId; } set { _BarcodeId = value; } }

    private int _TitleId;
   
    public int TitleId { get { return _TitleId; } set { _TitleId = value; } }

    private string _TitleName;

    public string TitleName { get { return _TitleName; } set { _TitleName = value; } }

    private string _GenderName;

    public string GenderName { get { return _GenderName; } set { _GenderName = value; } }


    private string _FirstName;

    public string FirstName { get { return _FirstName; } set { _FirstName = value; } }

    private string _MiddleName;

    public string MiddleName { get { return _MiddleName; } set { _MiddleName = value; } }

    private string _LastName;

    public string LastName { get { return _LastName; } set { _LastName = value; } }

    private string _PatientName;

    public string PatientName { get { return _PatientName; } set { _PatientName = value; } }

    private int _PatMainTypeId;

    public int PatMainTypeId { get { return _PatMainTypeId; } set { _PatMainTypeId = value; } }

    private string _PatMainType;

    public string PatMainType { get { return _PatMainType; } set { _PatMainType = value; } }

    private int _PatientInsuTypeId;

    public int PatientInsuTypeId { get { return _PatientInsuTypeId; } set { _PatientInsuTypeId = value; } }

    private string _PatientInsuType;

    public string PatientInsuType { get { return _PatientInsuType; } set { _PatientInsuType = value; } }

    private string _PolicyNo;
    public string PolicyNo
    {
        get { return _PolicyNo; }
        set { _PolicyNo = value; }
    }

    private int _GenderId;

    public int GenderId { get { return _GenderId; } set { _GenderId = value; } }

    private DateTime? _BirthDate;
    public DateTime? BirthDate { get { return _BirthDate; } set { _BirthDate = value; } }

    private bool _IsConfirmBirthDate;

    public bool IsConfirmBirthDate { get { return _IsConfirmBirthDate; } set { _IsConfirmBirthDate = value; } }

    private string _Age;
    public string Age { get { return _Age; } set { _Age = value; } }

    private string _AgeType;
    public string AgeType { get { return _AgeType; } set { _AgeType = value; } }

    private int _BloodGroupId;

    public int BloodGroupId { get { return _BloodGroupId; } set { _BloodGroupId = value; } }

    private string _BloodGroup;

    public string BloodGroup { get { return _BloodGroup; } set { _BloodGroup = value; } }

    private int _MaritalStatusId;    
    public int MaritalStatusId { get { return _MaritalStatusId; } set { _MaritalStatusId = value; } }

    private string _MaritalStatus;
    public string MaritalStatus { get { return _MaritalStatus; } set { _MaritalStatus = value; } }

    private int _GuardianTitleId;

    public int GuardianTitleId { get { return _GuardianTitleId; } set { _GuardianTitleId = value; } }

    private string _GuardianTitleName;

    public string GuardianTitleName { get { return _GuardianTitleName; } set { _GuardianTitleName = value; } }

    private string _GuardianName;

    public string GuardianName { get { return _GuardianName; } set { _GuardianName = value; } }

    private string _MobileNo;

    public string MobileNo { get { return _MobileNo; } set { _MobileNo = value; } }

    private string _PhoneNo;

    public string PhoneNo { get { return _PhoneNo; } set { _PhoneNo = value; } }

    private string _PatientAddress;

    public string PatientAddress { get { return _PatientAddress; } set { _PatientAddress = value; } }

    private int _CountryId;

    public int CountryId { get { return _CountryId; } set { _CountryId = value; } }

    private string _CountryName;

    public string CountryName { get { return _CountryName; } set { _CountryName = value; } }

    public int _StateId;

    public int StateId { get { return _StateId; } set { _StateId = value; } }

    private string _StateName;

    /// <summary>
    /// StateName
    /// Sets And Gets StateName
    /// </summary>
    public string StateName { get { return _StateName; } set { _StateName = value; } }

    public int _CityId;

    public int CityId { get { return _CityId; } set { _CityId = value; } }

    private string _CityName;

    public string CityName { get { return _CityName; } set { _CityName = value; } }

    public int _LandMarkId;

    
    public int LandMarkId { get { return _LandMarkId; } set { _LandMarkId = value; } }

    private string _LandMarkName;

    public string LandMarkName { get { return _LandMarkName; } set { _LandMarkName = value; } }

    private string _Email;

    public string Email { get { return _Email; } set { _Email = value; } }

    private DateTime _EntryDate;


    public DateTime EntryDate { get { return _EntryDate; } set { _EntryDate = value; } }


    private string _ImagePath;

    public string ImagePath { get { return _ImagePath; } set { _ImagePath = value; } }

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

    private string _Nationality;

    public string Nationality { get { return _Nationality; } set { _Nationality = value; } }

    private string _BirthPlace;

    public string BirthPlace { get { return _BirthPlace; } set { _BirthPlace = value; } }


    private string _HealthCardNo;

    public string HealthCardNo { get { return _HealthCardNo; } set { _HealthCardNo = value; } }
    private string _PassportNo;
    public string PassportNo { get { return _PassportNo; } set { _PassportNo = value; } }

    private int _RaceId;
    public int RaceId { get { return _RaceId; } set { _RaceId = value; } }
    private int _ReligionId;
    public int ReligionId { get { return _ReligionId; } set { _ReligionId = value; } }

    private string _VaccinationStatus;
    public string VaccinationStatus
    {
        get { return _VaccinationStatus; }
        set { _VaccinationStatus = value; }
    }

    private string _Allergy;
    public string Allergy
    {
        get { return _Allergy; }
        set { _Allergy = value; }
    }

    private string _ChiefComplant;
    public string ChiefComplant
    {
        get { return _ChiefComplant; }
        set { _ChiefComplant = value; }
    }

    private string _EditRemark;
     public string EditRemark
    {
        get { return _EditRemark; }
        set { _EditRemark = value; }
    }

    

    private string Address1;
    public string P_Address1
    {

        get { return Address1; }
        set { Address1 = value; }
    }
    private string Address2;
    public string P_Address2
    {

        get { return Address2; }
        set { Address2 = value; }
    }
    private string usertype;
    public string Usertype
    {
        get { return usertype; }
        set { usertype = value; }
    }
    private string Patusername;
    public string P_PUserName
    {
        get { return Patusername; }
        set { Patusername = value; }
    }

    private string Patpassword;
    public string P_PPassword
    {
        get { return Patpassword; }
        set { Patpassword = value; }
    }
    private string RelativeName;
    public string P_RelativeName
    {

        get { return RelativeName; }
        set { RelativeName = value; }
    }



    private string RelativeName1;
    public string P_RelativeName1
    {

        get { return RelativeName1; }
        set { RelativeName1 = value; }
    }

    private string ContactNo;
    public string P_ContactNo
    {

        get { return ContactNo; }
        set { ContactNo = value; }
    }


    private string ContactNo1;
    public string P_ContactNo1
    {

        get { return ContactNo1; }
        set { ContactNo1 = value; }
    }

    private int Relation1;
    public int P_Relation1
    {
        get { return Relation1; }
        set { Relation1 = value; }
    }
  
    

    private int Relation;
    public int P_Relation
    {

        get { return Relation; }
        set { Relation = value; }
    }
}