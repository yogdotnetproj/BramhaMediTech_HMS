using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DOPatientCategory
/// </summary>
public class DOPatientCategory
{
	public DOPatientCategory()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    private int _RoomType;
    public int RoomType { get { return _RoomType; } set { _RoomType = value; } }
    private string _SurgeryType;
    public string SurgeryType { get { return _SurgeryType; } set { _SurgeryType = value; } }

    private float _SurgeryDeposotAmt;
    public float SurgeryDeposotAmt { get { return _SurgeryDeposotAmt; } set { _SurgeryDeposotAmt = value; } }
   

    private int _PatMainTypeId;
    public int PatMainTypeId { get { return _PatMainTypeId; } set { _PatMainTypeId = value; } }
   
    private string _PatMainType;
    public string PatMainType { get { return _PatMainType; } set { _PatMainType = value; } }

    private int _PatientInsuTypeId;
    public int PatientInsuTypeId { get { return _PatientInsuTypeId; } set { _PatientInsuTypeId = value; } }

    private int _PatientRateTypeId;
    public int PatientRateTypeId { get { return _PatientRateTypeId; } set { _PatientRateTypeId = value; } }

    private int _PatientLabRateTypeId;
    public int PatientLabRateTypeId { get { return _PatientLabRateTypeId; } set { _PatientLabRateTypeId = value; } }


    private int _OrderNo;
    public int OrderNo { get { return _OrderNo; } set { _OrderNo = value; } }

    private string _PatientInsuType;
    public string PatientInsuType { get { return _PatientInsuType; } set { _PatientInsuType = value; } }

    private string _CompanyCode;
    public string CompanyCode { get { return _CompanyCode; } set { _CompanyCode = value; } }


    private string _ContactNumber;
    public string ContactNumber { get { return _ContactNumber; } set { _ContactNumber = value; } }


    private string _InsuranceNote;
    public string InsuranceNote { get { return _InsuranceNote; } set { _InsuranceNote = value; } }

    private int _FId;
    public int FId { get { return _FId; } set { _FId = value; } }

    private int _BranchId;
    public int BranchId { get { return _BranchId; } set { _BranchId = value; } }


    private int _ID;
    public int ID { get { return _ID; } set { _ID = value; } }
    

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

    private string _VaccnationName;
    public string VaccnationName { get { return _VaccnationName; } set { _VaccnationName = value; } }

    private string _FromAge;
    public string FromAge { get { return _FromAge; } set { _FromAge = value; } }

    private string _ToAge;
    public string ToAge { get { return _ToAge; } set { _ToAge = value; } }

    private string _Remark;
    public string Remark { get { return _Remark; } set { _Remark = value; } }

    private int _VaccianId;
    public int VaccianId { get { return _VaccianId; } set { _VaccianId = value; } }
    private string _AgeType;
    public string AgeType { get { return _AgeType; } set { _AgeType = value; } }

    private string _Patregid;
    public string Patregid { get { return _Patregid; } set { _Patregid = value; } }
    private string _OpdNo;
    public string OpdNo { get { return _OpdNo; } set { _OpdNo = value; } }
    private string _IpdNo;
    public string IpdNo { get { return _IpdNo; } set { _IpdNo = value; } }

    private string _DiagnosisName;
    public string DiagnosisName { get { return _DiagnosisName; } set { _DiagnosisName = value; } }
    private string _DiagnosisCode;
    public string DiagnosisCode { get { return _DiagnosisCode; } set { _DiagnosisCode = value; } }
   
    
}