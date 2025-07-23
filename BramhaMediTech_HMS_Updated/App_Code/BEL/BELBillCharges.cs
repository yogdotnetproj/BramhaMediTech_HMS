using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BELBillCharges
/// </summary>
public class BELBillCharges
{
	public BELBillCharges()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private int _RateTypeId;
    public int RateTypeId { get { return _RateTypeId; } set { _RateTypeId = value; } }


    private string _RateType;
    public string RateType { get { return _RateType; } set { _RateType = value; } }

    private int _BillServiceId;
    public int BillServiceId { get { return _BillServiceId; } set { _BillServiceId = value; } }

    private int _BillSubServiceId;
    public int BillSubServiceId { get { return _BillSubServiceId; } set { _BillSubServiceId = value; } }

    private string _ServiceDetails;
    public string ServiceDetails { get { return _ServiceDetails; } set { _ServiceDetails = value; } }

    private string _ServiceName;
    public string ServiceName { get { return _ServiceName; } set { _ServiceName = value; } }

    //----------------------------------------------------------------

    private double _BillChargeId;
    /// <summary>
    /// BillChargeId
    /// Sets And Gets BillChargeId
    /// </summary>

    public double BillChargeId
    {
        get { return _BillChargeId; }
        set { _BillChargeId = value; }
    }


    private int _BillGroupId;
    public int BillGroupId
    {
        get { return _BillGroupId; }
        set { _BillGroupId = value; }
    }
    

    private int _PatientTypeId;

    
    public int PatientTypeId { get { return _PatientTypeId; } set { _PatientTypeId = value; } }

    private string _PatientTypeName;

    /// <summary>
    /// PatientTypeName
    /// Sets And Gets PatientTypeName
    /// </summary>
    public string PatientTypeName { get { return _PatientTypeName; } set { _PatientTypeName = value; } }

    private int _DoctorId;

    /// <summary>
    /// DoctorId
    /// Sets And Gets DoctorId
    /// </summary>
    public int DoctorId { get { return _DoctorId; } set { _DoctorId = value; } }

    private string _DoctorName;

    /// <summary>
    /// DoctorName
    /// Sets And Gets DoctorName
    /// </summary>
    public string DoctorName { get { return _DoctorName; } set { _DoctorName = value; } }

    private int _OperationId;

    /// <summary>
    /// OperationId
    /// Sets And Gets OperationId
    /// </summary>
    public int OperationId { get { return _OperationId; } set { _OperationId = value; } }

    private string _OperationName;

    /// <summary>
    /// OperationName
    /// Sets And Gets OperationName
    /// </summary>
    public string OperationName { get { return _OperationName; } set { _OperationName = value; } }

    private int _OperationTheatreId;

    /// <summary>
    /// OperationTheatreId
    /// Sets And Gets OperationTheatreId
    /// </summary>
    public int OperationTheatreId { get { return _OperationTheatreId; } set { _OperationTheatreId = value; } }

    private string _OperationTheatreName;

    /// <summary>
    /// OperationTheatreName
    /// Sets And Gets OperationTheatreName
    /// </summary>
    public string OperationTheatreName { get { return _OperationTheatreName; } set { _OperationTheatreName = value; } }

    private int _RoomCategoryId;

    /// <summary>
    /// RoomCategoryId
    /// Sets And Gets RoomCategoryId
    /// </summary>
    public int RoomCategoryId { get { return _RoomCategoryId; } set { _RoomCategoryId = value; } }

    private string _RoomCategoryName;

    /// <summary>
    /// RoomCategoryName
    /// Sets And Gets RoomCategoryName
    /// </summary>
    public string RoomCategoryName { get { return _RoomCategoryName; } set { _RoomCategoryName = value; } }

    private int _LabTestId;

    /// <summary>
    /// LabTestId
    /// Sets And Gets LabTestId
    /// </summary>
    public int LabTestId { get { return _LabTestId; } set { _LabTestId = value; } }

    private string _LabTestName;

    /// <summary>
    /// LabTestName
    /// Sets And Gets LabTestName
    /// </summary>
    public string LabTestName { get { return _LabTestName; } set { _LabTestName = value; } }

    private int _HospitalId;

    /// <summary>
    /// LabTestId
    /// Sets And Gets HospitalId
    /// </summary>
    public int HospitalId { get { return _HospitalId; } set { _HospitalId = value; } }

    private string _HospitalName;

    /// <summary>
    /// LabTestName
    /// Sets And Gets Hospital
    /// </summary>
    public string HospitalName { get { return _HospitalName; } set { _HospitalName = value; } }

    private int _FromKM;

    /// <summary>
    /// FromKM
    /// Sets And Gets FromKM
    /// </summary>
    public int FromKM { get { return _FromKM; } set { _FromKM = value; } }

    private int _ToKM;

    /// <summary>
    /// ToKM
    /// Sets And Gets ToKM
    /// </summary>
    public int ToKM { get { return _ToKM; } set { _ToKM = value; } }

    private decimal _Rate;

    /// <summary>
    /// Rate
    /// Sets And Gets Rate
    /// </summary>
    public decimal Rate { get { return _Rate; } set { _Rate = value; } }

    private decimal _DoctorPercent;

    
    public decimal DoctorPercent { get { return _DoctorPercent; } set { _DoctorPercent = value; } }

    private decimal _DoctorAmount;

    /// <summary>
    /// DoctorAmount
    /// Sets And Gets DoctorAmount
    /// </summary>
    public decimal DoctorAmount { get { return _DoctorAmount; } set { _DoctorAmount = value; } }
    //------------------------------------------


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

    private bool _IsActive;
    public bool IsActive { get { return _IsActive; } set { _IsActive = value; } }

}