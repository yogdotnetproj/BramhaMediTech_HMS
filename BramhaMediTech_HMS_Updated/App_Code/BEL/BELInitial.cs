using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BELInitial
/// </summary>
public class BELInitial
{
	public BELInitial()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private int _TitleId;

    public int TitleId { get { return _TitleId; } set { _TitleId = value; } }


    private int _GenderId;

    public int GenderId { get { return _GenderId; } set { _GenderId = value; } }
    private int _FId;

    public int FId { get { return _FId; } set { _FId = value; } }

    private int _BranchId;

    public int BranchId { get { return _BranchId; } set { _BranchId = value; } }


    private string _GenderName;

    public string GenderName { get { return _GenderName; } set { _GenderName = value; } }

    private string _TitleName;

   
    public string TitleName { get { return _TitleName; } set { _TitleName = value; } }

    private bool _IsActive;

    public bool IsActive { get { return _IsActive; } set { _IsActive = value; } }

    private bool _IsDefault;
    public  bool IsDefault { get { return _IsDefault; } set { _IsDefault = value; } }


    private string _CreatedBy;
    public string CreatedBy { get { return _CreatedBy; } set { _CreatedBy = value; } }

    private DateTime _CreatedDateTime;
    public DateTime CreatedDateTime { get { return _CreatedDateTime; } set { _CreatedDateTime = value; } }

    private string _UpdatedBy;   
    public string UpdatedBy { get { return _UpdatedBy; } set { _UpdatedBy = value; } }

    private DateTime _UpdatedDateTime;
    public DateTime UpdatedDateTime { get { return _UpdatedDateTime; } set { _UpdatedDateTime = value; } }
}