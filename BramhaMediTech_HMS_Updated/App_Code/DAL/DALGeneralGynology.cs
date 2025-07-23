using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DALPostpartumExamination
/// </summary>
public class DALGeneralGynology
{
    public DALGeneralGynology()
	{
		//
		// TODO: Add constructor logic here
		//

        this.EntryDate = Date.getMinDate();
        this.LMP_Antinatal_Date = Date.getMinDate();
        this.TTINj_Date = Date.getMinDate();
        this.Due_Date = Date.getMinDate();
        this.UltraSound_Date = Date.getMinDate();
        this.SubsequentUltraSound_Date = Date.getMinDate();
        this.Delivery_Date = Date.getMinDate();
        this.Clinical_Date = Date.getMinDate();
        this.Investigation_Date = Date.getMinDate();
        this.Other_Date = Date.getMinDate();
        this.DrugScheduleDate = Date.getMinDate();
	}
    private DateTime _EntryDate;
    public DateTime EntryDate { get { return _EntryDate; } set { _EntryDate = value; } }
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



    private string _Duration_Days;
    public string Duration_Days { get { return _Duration_Days; } set { _Duration_Days = value; } }
    private string _Duration_Week;
    public string Duration_Week { get { return _Duration_Week; } set { _Duration_Week = value; } }

    private string _Duration_Months;
    public string Duration_Months { get { return _Duration_Months; } set { _Duration_Months = value; } }
    private string _Parity;
    public string Parity { get { return _Parity; } set { _Parity = value; } }
    private string _Duration_Years;
    public string Duration_Years { get { return _Duration_Years; } set { _Duration_Years = value; } }
    

    private string  _LastLMP1;
    public string LastLMP1 { get { return _LastLMP1; } set { _LastLMP1 = value; } }
    private string _LastLMP;
    public string LastLMP { get { return _LastLMP; } set { _LastLMP = value; } }



    private string _Note;
    public string Note { get { return _Note; } set { _Note = value; } }
    private string _PastHistory;
    public string PastHistory { get { return _PastHistory; } set { _PastHistory = value; } }

    private string _CompliantName;    public string CompliantName { get { return _CompliantName; } set { _CompliantName = value; } }

    private int _CompliantId;
    public int CompliantId { get { return _CompliantId; } set { _CompliantId = value; } }


    private string _Gravida; public string Gravida { get { return _Gravida; } set { _Gravida = value; } }
    private string _Para; public string Para { get { return _Para; } set { _Para = value; } }
    private string _RiskFactors; public string RiskFactors { get { return _RiskFactors; } set { _RiskFactors = value; } }
    private string _Allergies; public string Allergies { get { return _Allergies; } set { _Allergies = value; } }
    private string _Ethinicity; public string Ethinicity { get { return _Ethinicity; } set { _Ethinicity = value; } }
    private string _SignificantFamilyHistory; public string SignificantFamilyHistory { get { return _SignificantFamilyHistory; } set { _SignificantFamilyHistory = value; } }
    private string _LevelofEducation; public string LevelofEducation { get { return _LevelofEducation; } set { _LevelofEducation = value; } }

    private DateTime _LMP_Antinatal_Date; public DateTime LMP_Antinatal_Date { get { return _LMP_Antinatal_Date; } set { _LMP_Antinatal_Date = value; } }
    private DateTime _TTINj_Date; public DateTime TTINj_Date { get { return _TTINj_Date; } set { _TTINj_Date = value; } }
    private DateTime _Due_Date; public DateTime Due_Date { get { return _Due_Date; } set { _Due_Date = value; } }
    private DateTime _UltraSound_Date; public DateTime UltraSound_Date { get { return _UltraSound_Date; } set { _UltraSound_Date = value; } }
    private DateTime _SubsequentUltraSound_Date; public DateTime SubsequentUltraSound_Date { get { return _SubsequentUltraSound_Date; } set { _SubsequentUltraSound_Date = value; } }
    private DateTime _Delivery_Date; public DateTime Delivery_Date { get { return _Delivery_Date; } set { _Delivery_Date = value; } }

    private DateTime _Clinical_Date; public DateTime Clinical_Date { get { return _Clinical_Date; } set { _Clinical_Date = value; } }
    private DateTime _Investigation_Date; public DateTime Investigation_Date { get { return _Investigation_Date; } set { _Investigation_Date = value; } }
    private DateTime _Other_Date; public DateTime Other_Date { get { return _Other_Date; } set { _Other_Date = value; } }

    private string _HB; public string HB { get { return _HB; } set { _HB = value; } }
    private string _Grp; public string Grp { get { return _Grp; } set { _Grp = value; } }
    private string _RBS; public string RBS { get { return _RBS; } set { _RBS = value; } }
    private string _RPR; public string RPR { get { return _RPR; } set { _RPR = value; } }
    private string _HIV1; public string HIV1 { get { return _HIV1; } set { _HIV1 = value; } }
    private string _HIV2; public string HIV2 { get { return _HIV2; } set { _HIV2 = value; } }
    private string _HBsAg; public string HBsAg { get { return _HBsAg; } set { _HBsAg = value; } }
    private string _Sickling; public string Sickling { get { return _Sickling; } set { _Sickling = value; } }
    private string _OGTT; public string OGTT { get { return _OGTT; } set { _OGTT = value; } }
    private string _HepC; public string HepC { get { return _HepC; } set { _HepC = value; } }
    private string _Glucose; public string Glucose { get { return _Glucose; } set { _Glucose = value; } }

    private string _UltraSoundFinding; public string UltraSoundFinding { get { return _UltraSoundFinding; } set { _UltraSoundFinding = value; } }
    private string _SubseqUltraSoundFinding; public string SubseqUltraSoundFinding { get { return _SubseqUltraSoundFinding; } set { _SubseqUltraSoundFinding = value; } }
    private string _ModeOfDelivery; public string ModeOfDelivery { get { return _ModeOfDelivery; } set { _ModeOfDelivery = value; } }
    private string _BirthWeight; public string BirthWeight { get { return _BirthWeight; } set { _BirthWeight = value; } }

    private string _ClinicalDetails; public string ClinicalDetails { get { return _ClinicalDetails; } set { _ClinicalDetails = value; } }
    private string _InvestigationDetails; public string InvestigationDetails { get { return _InvestigationDetails; } set { _InvestigationDetails = value; } }
    private string _POG; public string POG { get { return _POG; } set { _POG = value; } }
    private string _SFH; public string SFH { get { return _SFH; } set { _SFH = value; } }
    private string _PPLIE; public string PPLIE { get { return _PPLIE; } set { _PPLIE = value; } }
    private string _FetalHeartBeat; public string FetalHeartBeat { get { return _FetalHeartBeat; } set { _FetalHeartBeat = value; } }
    private string _BP; public string BP { get { return _BP; } set { _BP = value; } }

    private string _UrinChem; public string UrinChem { get { return _UrinChem; } set { _UrinChem = value; } }
    private string _WeightLBS; public string WeightLBS { get { return _WeightLBS; } set { _WeightLBS = value; } }
    private string _Investigations; public string Investigations { get { return _Investigations; } set { _Investigations = value; } }
    private string _Medications; public string Medications { get { return _Medications; } set { _Medications = value; } }
    private string _Advice; public string Advice { get { return _Advice; } set { _Advice = value; } }


    private DateTime _DrugScheduleDate;
    public DateTime DrugScheduleDate { get { return _DrugScheduleDate; } set { _DrugScheduleDate = value; } }

    private string _FolliclesLeftOvary; public string FolliclesLeftOvary { get { return _FolliclesLeftOvary; } set { _FolliclesLeftOvary = value; } }
    private string _FolliclesRightOvary; public string FolliclesRightOvary { get { return _FolliclesRightOvary; } set { _FolliclesRightOvary = value; } }
    private string _Consent; public string Consent { get { return _Consent; } set { _Consent = value; } }
    private string _FSH; public string FSH { get { return _FSH; } set { _FSH = value; } }
    private string _FSHLH; public string FSHLH { get { return _FSHLH; } set { _FSHLH = value; } }
    private string _Units; public string Units { get { return _Units; } set { _Units = value; } }
    private string _Agonist; public string Agonist { get { return _Agonist; } set { _Agonist = value; } }
    private string _MISCName; public string MISCName { get { return _MISCName; } set { _MISCName = value; } }
    private string _MISCValue; public string MISCValue { get { return _MISCValue; } set { _MISCValue = value; } }
    private string _Comments; public string Comments { get { return _Comments; } set { _Comments = value; } }

}