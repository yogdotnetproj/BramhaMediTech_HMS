using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BELBillGroup
/// </summary>
public class BELBillGroup
{
	public BELBillGroup()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    private int _GroupType;
    public int GroupType { get { return _GroupType; } set { _GroupType = value; } }

    private bool _DailyService;
    public bool DailyService { get { return _DailyService; } set { _DailyService = value; } }
  
    private int _BillGroupId;
    public int BillGroupId { get { return _BillGroupId; } set { _BillGroupId = value; } }



    private string _GroupName;
    public string GroupName { get { return _GroupName; } set { _GroupName = value; } }



    private int _GroupOrderNo;
    public int GroupOrderNo { get { return _GroupOrderNo; } set { _GroupOrderNo = value; } }



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