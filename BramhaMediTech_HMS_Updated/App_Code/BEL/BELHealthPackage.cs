using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BELHealthPackage
/// </summary>
public class BELHealthPackage
{
	public BELHealthPackage()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private int _HPackId;
    public int HPackId { get { return _HPackId; } set { _HPackId = value; } }

    private string _HPackName;
    public string HPackName { get { return _HPackName; } set { _HPackName = value; } }

    private string _HPackDetails;
    public string HPackDetails { get { return _HPackDetails; } set { _HPackDetails = value; } }

    private decimal _HPackAmount;
    public decimal HPackAmount { get { return _HPackAmount; } set { _HPackAmount = value; } }

    private int _BillServiceId;
    public int BillServiceId { get { return _BillServiceId; } set { _BillServiceId = value; } }

    private int _BillSubServiceId;
    public int BillSubServiceId { get { return _BillSubServiceId; } set { _BillSubServiceId = value; } }

    private string _ServiceDetails;
    public string ServiceDetails { get { return _ServiceDetails; } set { _ServiceDetails = value; } }

    private string _ServiceName;
    public string ServiceName { get { return _ServiceName; } set { _ServiceName = value; } }

    private int _Qty;
    public int Qty { get { return _Qty; } set { _Qty = value; } }

    private decimal _Amount;
    public decimal Amount { get { return _Amount; } set { _Amount = value; } }
   
    private DateTime _FromDate;
    public DateTime FromDate { get { return _FromDate; } set { _FromDate = value; } }


    private DateTime _ToDate;
    public DateTime ToDate { get { return _ToDate; } set { _ToDate = value; } }

    private bool _IsOpd;
    public bool IsOpd { get { return _IsOpd; } set { _IsOpd = value; } }

    private bool _IsIpd;
    public bool IsIpd { get { return _IsIpd; } set { _IsIpd = value; } }

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