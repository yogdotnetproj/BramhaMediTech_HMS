using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DALPostpartumExamination
/// </summary>
public class DALExaminationFinding
{
    public DALExaminationFinding()
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

    

    private string _Mass;
    public string Mass { get { return _Mass; } set { _Mass = value; } }
    private string _Tenderness;
    public string Tenderness { get { return _Tenderness; } set { _Tenderness = value; } }
   
    private string _Size;
    public string Size { get { return _Size; } set { _Size = value; } }

    


    private bool _Warts;
    public bool Warts { get { return _Warts; } set { _Warts = value; } }
    private bool _Herpetic;
    public bool Herpetic { get { return _Herpetic; } set { _Herpetic = value; } }

    private bool _Others;
    public bool Others { get { return _Others; } set { _Others = value; } }
    private string _CervixHealthy;
    public string CervixHealthy { get { return _CervixHealthy; } set { _CervixHealthy = value; } }

    private string _Notes;
    public string Notes { get { return _Notes; } set { _Notes = value; } }
    private string _Polyp;
    public string Polyp { get { return _Polyp; } set { _Polyp = value; } }
    private string _UterusSize;
    public string UterusSize { get { return _UterusSize; } set { _UterusSize = value; } }
    private string _UterusWeek;
    public string UterusWeek { get { return _UterusWeek; } set { _UterusWeek = value; } }
    private string _Position;
    public string Position { get { return _Position; } set { _Position = value; } }

    private bool _IsTenderness;
    public bool IsTenderness { get { return _IsTenderness; } set { _IsTenderness = value; } }
    private bool _ISMass;
    public bool ISMass { get { return _ISMass; } set { _ISMass = value; } }



    private string _Medications;
    public string Medications { get { return _Medications; } set { _Medications = value; } }
   private string _SurgicalAdvice;
   public string SurgicalAdvice { get { return _SurgicalAdvice; } set { _SurgicalAdvice = value; } }

   private int _SurgeryId;
   public int SurgeryId { get { return _SurgeryId; } set { _SurgeryId = value; } }


  
    
}