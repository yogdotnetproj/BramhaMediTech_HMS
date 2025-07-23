using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BELEmpReg
/// </summary>
public class BELEmpReg
{
	public BELEmpReg()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    private string _Title;
    public string Title { get { return _Title; } set { _Title = value; } }

    private string _Qualification;
    public string Qualification { get { return _Qualification; } set { _Qualification = value; } }

    private string _BloodGroup;
    public string BloodGroup { get { return _BloodGroup; } set { _BloodGroup = value; } }

    private string _Empcode;
    public string Empcode { get { return _Empcode; } set { _Empcode = value; } }

    private string _PANNo;
    public string PANNo { get { return _PANNo; } set { _PANNo = value; } }

     private string _Address;
    public string Address { get { return _Address; } set { _Address = value; } }

     private string _email;
    public string email { get { return _email; } set { _email = value; } }

     private string _EmployeeType;
    public string EmployeeType { get { return _EmployeeType; } set { _EmployeeType = value; } }

    
    private string _Empname;
    public string Empname { get { return _Empname; } set { _Empname = value; } }

    
    private string _telno;
    public string telno { get { return _telno; } set { _telno = value; } }

    
    private string _mobile;
    public string mobile { get { return _mobile; } set { _mobile = value; } }


    private int _DrId;
    public int DrId { get { return _DrId; } set { _DrId = value; } }

    private DateTime _BirthDate;
    public DateTime BirthDate { get { return _BirthDate; } set { _BirthDate = value; } }

    private DateTime _AnniversaryDate;
    public DateTime AnniversaryDate { get { return _AnniversaryDate; } set { _AnniversaryDate = value; } }

    private DateTime _JoiningDate;
    public DateTime JoiningDate { get { return _JoiningDate; } set { _JoiningDate = value; } }


    private int _DesignationId;
    public int DesignationId { get { return _DesignationId; } set { _DesignationId = value; } }

    private string _Designation;
    public string Designation { get { return _Designation; } set { _Designation = value; } }

    private int _DeptId;
    public int DeptId { get { return _DeptId; } set { _DeptId = value; } }

    
    private string _DeptName;
    public string DeptName { get { return _DeptName; } set { _DeptName = value; } }

    private string _DeptCode;
    public string DeptCode { get { return _DeptCode; } set { _DeptCode = value; } }

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