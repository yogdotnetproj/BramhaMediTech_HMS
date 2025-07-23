using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DALPostpartumExamination
/// </summary>
public class DALDeliveryNote
{
    public DALDeliveryNote()
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


    private string _DeliveryConductBy;
    public string DeliveryConductBy { get { return _DeliveryConductBy; } set { _DeliveryConductBy = value; } }
    private string _Gravida;
    public string Gravida { get { return _Gravida; } set { _Gravida = value; } }
    private string _HusbandName;
    public string HusbandName { get { return _HusbandName; } set { _HusbandName = value; } }
    private string _Condition;
    public string Condition { get { return _Condition; } set { _Condition = value; } }
    private DateTime _DeliveryDate;
    public DateTime DeliveryDate { get { return _DeliveryDate; } set { _DeliveryDate = value; } }
    private string _Matuarity;
    public string Matuarity { get { return _Matuarity; } set { _Matuarity = value; } }

    private int _NumberOfBaby;
    public int NumberOfBaby { get { return _NumberOfBaby; } set { _NumberOfBaby = value; } }
    private bool _MaternialDeath;
    public bool MaternialDeath { get { return _MaternialDeath; } set { _MaternialDeath = value; } }
    private string _ModeofDelivery;
    public string ModeofDelivery { get { return _ModeofDelivery; } set { _ModeofDelivery = value; } }
    private string _GenderofBaby;
    public string GenderofBaby { get { return _GenderofBaby; } set { _GenderofBaby = value; } }

    private string _DeliveryTime;
    public string DeliveryTime { get { return _DeliveryTime; } set { _DeliveryTime = value; } }
    private string _WeightOfBaby;
    public string WeightOfBaby { get { return _WeightOfBaby; } set { _WeightOfBaby = value; } }
    private string _Para;
    public string Para { get { return _Para; } set { _Para = value; } }
    private string _StillBirth;
    public string StillBirth { get { return _StillBirth; } set { _StillBirth = value; } }
    private string _Living;
    public string Living { get { return _Living; } set { _Living = value; } }
    private string _Abortion;
    public string Abortion { get { return _Abortion; } set { _Abortion = value; } }
    private string _Comments;
    public string Comments { get { return _Comments; } set { _Comments = value; } }
    private string _MaterinityDeathReason;
    public string MaterinityDeathReason { get { return _MaterinityDeathReason; } set { _MaterinityDeathReason = value; } }




   
}