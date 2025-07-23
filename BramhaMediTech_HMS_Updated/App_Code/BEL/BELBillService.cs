using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BELBillService
/// </summary>
public class BELBillService
{
	public BELBillService()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    

    private int _BillServiceId; 
    public int BillServiceId { get { return _BillServiceId; } set { _BillServiceId = value; } }

    private string _ServiceName; 
    public string ServiceName { get { return _ServiceName; } set { _ServiceName = value; } }

    private string _DailyServiceName;
    public string DailyServiceName { get { return _DailyServiceName; } set { _DailyServiceName = value; } }

    private string _RoomType;
    public string RoomType { get { return _RoomType; } set { _RoomType = value; } }

    
    private string _GroupName;
    public string GroupName { get { return _GroupName; } set { _GroupName = value; } }
    private string _UnitOfCharges;
    public string UnitOfCharges { get { return _UnitOfCharges; } set { _UnitOfCharges = value; } } 
    

    private bool _IsIpd;
    public bool IsIpd { get { return _IsIpd; } set { _IsIpd = value; } }

    private bool _IsOpd;
    public bool IsOpd { get { return _IsOpd; } set { _IsOpd = value; } }

    private int _BillGroupId;
    public int BillGroupId { get { return _BillGroupId; } set { _BillGroupId = value; } }

    private int _ServiceOrder;
    public int ServiceOrder { get { return _ServiceOrder; } set { _ServiceOrder = value; } }
    
    private bool _Isdoc; 
    public bool Isdoc { get { return _Isdoc; } set { _Isdoc = value; } }

    private bool _IsActive;
    public bool IsActive { get { return _IsActive; } set { _IsActive = value; } }

    private bool _IPDDaily;
    public bool IPDDaily { get { return _IPDDaily; } set { _IPDDaily = value; } }

    private bool _IsDirect;
    public bool IsDirect { get { return _IsDirect; } set { _IsDirect = value; } }

    private bool _IsRoomwise; 
    public bool IsRoomwise { get { return _IsRoomwise; } set { _IsRoomwise = value; } }

    private bool _IsDrvisible;
    public bool IsDrvisible { get { return _IsDrvisible; } set { _IsDrvisible = value; } }
   

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