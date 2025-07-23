using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DALPostpartumExamination
/// </summary>
public class DALBirthRegister
{
    public DALBirthRegister()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private string _Patregid;
    public string Patregid { get { return _Patregid; } set { _Patregid = value; } }
    private int _OpdNo;
    public int OpdNo { get { return _OpdNo; } set { _OpdNo = value; } }
    private int _IpdNo;
    public int IpdNo { get { return _IpdNo; } set { _IpdNo = value; } }
    private string _CreatedBy;
    public string CreatedBy { get { return _CreatedBy; } set { _CreatedBy = value; } }

    private DateTime _CreatedOn;
    public DateTime CreatedOn { get { return _CreatedOn; } set { _CreatedOn = value; } }

    private string _UpdatedBy;
    public string UpdatedBy { get { return _UpdatedBy; } set { _UpdatedBy = value; } }

    private DateTime _UpdatedOn;
    public DateTime UpdatedOn { get { return _UpdatedOn; } set { _UpdatedOn = value; } }
    private int _FId;
    public int FId { get { return _FId; } set { _FId = value; } }

    private int _BranchId;
    public int BranchId { get { return _BranchId; } set { _BranchId = value; } }


    private string _BabyName;
    public string BabyName { get { return _BabyName; } set { _BabyName = value; } }
    private string _MotherName;
    public string MotherName { get { return _MotherName; } set { _MotherName = value; } }
    private string _FatherName;
    public string FatherName { get { return _FatherName; } set { _FatherName = value; } }
    private string _BirthTime;
    public string BirthTime { get { return _BirthTime; } set { _BirthTime = value; } }
    private DateTime _BirthDate;
    public DateTime BirthDate { get { return _BirthDate; } set { _BirthDate = value; } }
    private string _Sex;
    public string Sex { get { return _Sex; } set { _Sex = value; } }



    private string _ModeOFDelivery;
    public string ModeOFDelivery { get { return _ModeOFDelivery; } set { _ModeOFDelivery = value; } }
    private string _WaitInGram;
    public string WaitInGram { get { return _WaitInGram; } set { _WaitInGram = value; } }
    private string _Comment;
    public string Comment { get { return _Comment; } set { _Comment = value; } }
   

   
}