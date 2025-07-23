using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class BELFinancialYear
{
	public BELFinancialYear()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    private int _FinancialYearId;

    public int FinancialYearId { get { return _FinancialYearId; } set { _FinancialYearId = value; } }

    private string _FinancialYear;


    public string FinancialYear { get { return _FinancialYear; } set { _FinancialYear = value; } }

    private DateTime _StartDate;

    public DateTime StartDate
    {
        get { return _StartDate; }
        set { _StartDate = value; }
    }

    private DateTime _EndDate;
    
    public DateTime EndDate
    {
        get { return _EndDate; }
        set { _EndDate = value; }
    }


    private int _BranchId;


    public int BranchId { get { return _BranchId; } set { _BranchId = value; } }


    private string _CreatedBy;

    public string CreatedBy { get { return _CreatedBy; } set { _CreatedBy = value; } }

    private DateTime _CreatedOn;

    public DateTime CreatedOn { get { return _CreatedOn; } set { _CreatedOn = value; } }

    private string _UpdatedBy;

    public string UpdatedBy { get { return _UpdatedBy; } set { _UpdatedBy = value; } }

    private DateTime _UpdatedOn;

    public DateTime UpdatedOn { get { return _UpdatedOn; } set { _UpdatedOn = value; } }
   
}