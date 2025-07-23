using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BELOperationTheater
/// </summary>
public class BELOperationTheater
{
	public BELOperationTheater()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private int _OTId;
    public int OTId { get { return _OTId; } set { _OTId = value; } }


    private string _OTType;
    public string OTType { get { return _OTType; } set { _OTType = value; } }



    private int _OprnCatId;
    public int OprnCatId { get { return _OprnCatId; } set { _OprnCatId = value; } }


    private string _OprnCat;
    public string OprnCat { get { return _OprnCat; } set { _OprnCat = value; } }

    private int _OTDeptId;
    public int OTDeptId { get { return _OTDeptId; } set { _OTDeptId = value; } }


    private string _OTDeptName;
    public string OTDeptName { get { return _OTDeptName; } set { _OTDeptName = value; } }

    private int _DeptId;
    public int DeptId { get { return _DeptId; } set { _DeptId = value; } }

    private int _OprnId;
    public int OprnId { get { return _OprnCatId; } set { _OprnCatId = value; } }


    private string _Oprn;
    public string Oprn { get { return _Oprn; } set { _Oprn = value; } }


    private string _OprnCd;
    public string OprnCd { get { return _OprnCd; } set { _OprnCd = value; } }


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