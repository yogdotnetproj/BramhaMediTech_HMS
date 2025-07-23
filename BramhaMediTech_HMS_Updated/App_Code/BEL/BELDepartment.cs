using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BELDepartment
/// </summary>
public class BELDepartment
{
	public BELDepartment()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private int _DeptId;
    public int DeptId { get { return _DeptId; } set { _DeptId = value; } }

    private int _MainDeptId;
    public int MainDeptId { get { return _MainDeptId; } set { _MainDeptId = value; } }

    private string _DeptName;
    public string DeptName { get { return _DeptName; } set { _DeptName = value; } }

    private string _DeptCode;
    public string DeptCode { get { return _DeptCode; } set { _DeptCode = value; } }

    private string _AccHead;
    public string AccHead { get { return _AccHead; } set { _AccHead = value; } }

    private string _AccCode;
    public string AccCode { get { return _AccCode; } set { _AccCode = value; } }
    private float _Amount;
    public float Amount { get { return _Amount; } set { _Amount = value; } }

    

    private string _FId;
    public string FId { get { return _FId; } set { _FId = value; } }

    private string _CreatedBy;
    public string CreatedBy { get { return _CreatedBy; } set { _CreatedBy = value; } }
    private string _PayTo;
    public string PayTo { get { return _PayTo; } set { _PayTo = value; } }
    private string _ParticularName;
    public string ParticularName { get { return _ParticularName; } set { _ParticularName = value; } }

    private int _Cash_VoucherNo;
    public int Cash_VoucherNo { get { return _Cash_VoucherNo; } set { _Cash_VoucherNo = value; } }
    

    private DateTime _CreatedOn;
    public DateTime CreatedOn { get { return _CreatedOn; } set { _CreatedOn = value; } }

    private string _UpdatedBy;
    public string UpdatedBy { get { return _UpdatedBy; } set { _UpdatedBy = value; } }

    private DateTime _UpdatedOn;
    public DateTime UpdatedOn { get { return _UpdatedOn; } set { _UpdatedOn = value; } }

    private int _BranchId;
    public int BranchId { get { return _BranchId; } set { _BranchId = value; } }

    private int _ModeofPayment;
    public int ModeofPayment { get { return _ModeofPayment; } set { _ModeofPayment = value; } }

    private string _VoucherNo;
    public string VoucherNo { get { return _VoucherNo; } set { _VoucherNo = value; } }

    
}