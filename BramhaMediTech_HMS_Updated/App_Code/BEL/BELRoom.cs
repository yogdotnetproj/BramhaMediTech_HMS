using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BELRoom
/// </summary>
public class BELRoom
{
	public BELRoom()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private int _RTypeId;
    public int RTypeId { get { return _RTypeId; } set { _RTypeId = value; } }


    private string _RType;
    public string RType { get { return _RType; } set { _RType = value; } }

    private int _RoomId;

    public int RoomId
    {
        get { return _RoomId; }
        set { _RoomId = value; }
    }
    private int _TotalBed;

    public int TotalBed
    {
        get { return _TotalBed; }
        set { _TotalBed = value; }
    }


    private string _RoomName;
    public string RoomName { get { return _RoomName; } set { _RoomName = value; } }

    private string _RoomAddress;
    public string RoomAddress { get { return _RoomAddress; } set { _RoomAddress = value; } }

    private int _BedId;

    public int BedId
    {
        get { return _BedId; }
        set { _BedId = value; }
    }

    private string _BedNo;

    public string BedNo
    {
        get { return _BedNo; }
        set { _BedNo = value; }
    }


    private int _FId;
    public int FId { get { return _FId; } set { _FId = value; } }

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