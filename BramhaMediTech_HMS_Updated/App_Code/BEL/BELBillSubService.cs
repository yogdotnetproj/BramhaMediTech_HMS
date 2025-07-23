using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BELBillSubService
/// </summary>
public class BELBillSubService
{
	public BELBillSubService()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    private int _BillServiceId;
    public int BillServiceId { get { return _BillServiceId; } set { _BillServiceId = value; } }

    private int _BillSubServiceId;
    public int BillSubServiceId { get { return _BillSubServiceId; } set { _BillSubServiceId = value; } }


    private string _ServiceDetails;
    public string ServiceDetails { get { return _ServiceDetails; } set { _ServiceDetails = value; } }

    private bool _IsIpd;
    public bool IsIpd { get { return _IsIpd; } set { _IsIpd = value; } }

    private bool _IsOpd;
    public bool IsOpd { get { return _IsOpd; } set { _IsOpd = value; } }

    
    private int _ServiceOrder;
    public int ServiceOrder { get { return _ServiceOrder; } set { _ServiceOrder = value; } }

    

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