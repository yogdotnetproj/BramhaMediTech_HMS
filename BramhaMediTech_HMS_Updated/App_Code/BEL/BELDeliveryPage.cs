using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;


/// <summary>
/// Summary description for DeliveryPage
/// </summary>
public class BELDeliveryPage
{

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

    private DateTime _DateOfBirth;
    public DateTime DateOfBirth { get { return _DateOfBirth; } set { _DateOfBirth = value; } }

    private bool _MaternialDeath;
    public bool MaternialDeath { get { return _MaternialDeath; } set { _MaternialDeath = value; } }

    private string _TimeOfBirth;
    public string TimeOfBirth { get { return _TimeOfBirth; } set { _TimeOfBirth = value; } }
    private string _BirthGender;
    public string BirthGender { get { return _BirthGender; } set { _BirthGender = value; } }
    private string _BirthWeight;
    public string BirthWeight { get { return _BirthWeight; } set { _BirthWeight = value; } }

    private string _TotalActivity1;
    public string TotalActivity1 { get { return _TotalActivity1; } set { _TotalActivity1 = value; } }
    private string _TotalPulse1;
    public string TotalPulse1 { get { return _TotalPulse1; } set { _TotalPulse1 = value; } }
    private string _TotalGrimace1;
    public string TotalGrimace1 { get { return _TotalGrimace1; } set { _TotalGrimace1 = value; } }
    private string _TotalAppearance1;
    public string TotalAppearance1 { get { return _TotalAppearance1; } set { _TotalAppearance1 = value; } }
    private string _TotalRespiration1;
    public string TotalRespiration1 { get { return _TotalRespiration1; } set { _TotalRespiration1 = value; } }

    private string _TotalActivity5;
    public string TotalActivity5 { get { return _TotalActivity5; } set { _TotalActivity5 = value; } }
    private string _TotalPulse5;
    public string TotalPulse5 { get { return _TotalPulse5; } set { _TotalPulse5 = value; } }
    private string _TotalGrimace5;
    public string TotalGrimace5 { get { return _TotalGrimace5; } set { _TotalGrimace5 = value; } }
    private string _TotalAppearance5;
    public string TotalAppearance5 { get { return _TotalAppearance5; } set { _TotalAppearance5 = value; } }
    private string _TotalRespiration5;
    public string TotalRespiration5 { get { return _TotalRespiration5; } set { _TotalRespiration5 = value; } }

    private bool _SpontaneousVaginal;
    public bool SpontaneousVaginal { get { return _SpontaneousVaginal; } set { _SpontaneousVaginal = value; } }
    private bool _InductionOxytocin;
    public bool InductionOxytocin { get { return _InductionOxytocin; } set { _InductionOxytocin = value; } }
    private bool _InductionCytotec;
    public bool InductionCytotec { get { return _InductionCytotec; } set { _InductionCytotec = value; } }
    private bool _VaccumExtraction;
    public bool VaccumExtraction { get { return _VaccumExtraction; } set { _VaccumExtraction = value; } }
    private bool _Forcepsdelivery;
    public bool Forcepsdelivery { get { return _Forcepsdelivery; } set { _Forcepsdelivery = value; } }
    private bool _Caesariansection;
    public bool Caesariansection { get { return _Caesariansection; } set { _Caesariansection = value; } }

    private DateTime _Stage1Date;
    public DateTime Stage1Date { get { return _Stage1Date; } set { _Stage1Date = value; } }
    private DateTime _Stage2Date;
    public DateTime Stage2Date { get { return _Stage2Date; } set { _Stage2Date = value; } }
    private DateTime _Stage3Date;
    public DateTime Stage3Date { get { return _Stage3Date; } set { _Stage3Date = value; } }

    private string _Stage1TimeFrom;
    public string Stage1TimeFrom { get { return _Stage1TimeFrom; } set { _Stage1TimeFrom = value; } }
    private string _Stage2TimeFrom;
    public string Stage2TimeFrom { get { return _Stage2TimeFrom; } set { _Stage2TimeFrom = value; } }
    private string _Stage3TimeFrom;
    public string Stage3TimeFrom { get { return _Stage3TimeFrom; } set { _Stage3TimeFrom = value; } }

    private string _Stage1TimeTo;
    public string Stage1TimeTo { get { return _Stage1TimeTo; } set { _Stage1TimeTo = value; } }
    private string _Stage2TimeTo;
    public string Stage2TimeTo { get { return _Stage2TimeTo; } set { _Stage2TimeTo = value; } }
    private string _Stage3TimeTo;
    public string Stage3TimeTo { get { return _Stage3TimeTo; } set { _Stage3TimeTo = value; } }


    private string _Stage1Duration;
    public string Stage1Duration { get { return _Stage1Duration; } set { _Stage1Duration = value; } }
    private string _Stage2Duration;
    public string Stage2Duration { get { return _Stage2Duration; } set { _Stage2Duration = value; } }
    private string _Stage3Duration;
    public string Stage3Duration { get { return _Stage3Duration; } set { _Stage3Duration = value; } }

    private bool _PlacentaComplete;
    public bool PlacentaComplete { get { return _PlacentaComplete; } set { _PlacentaComplete = value; } }
    private bool _PlacentaInComplete;
    public bool PlacentaInComplete { get { return _PlacentaInComplete; } set { _PlacentaInComplete = value; } }
    private bool _bloodVessels;
    public bool bloodVessels { get { return _bloodVessels; } set { _bloodVessels = value; } }
    private bool _MeconiumStaining;
    public bool MeconiumStaining { get { return _MeconiumStaining; } set { _MeconiumStaining = value; } }
    private bool _Cordaround;
    public bool Cordaround { get { return _Cordaround; } set { _Cordaround = value; } }
    private bool _Episiotomy;
    public bool Episiotomy { get { return _Episiotomy; } set { _Episiotomy = value; } }
    private bool _Vaginal;
    public bool Vaginal { get { return _Vaginal; } set { _Vaginal = value; } }

    private string _RepairBy;
    public string RepairBy { get { return _RepairBy; } set { _RepairBy = value; } }

    private string _Timeofrupturemembrance;
    public string Timeofrupturemembrance { get { return _Timeofrupturemembrance; } set { _Timeofrupturemembrance = value; } }
    private string _BloodLoss;
    public string BloodLoss { get { return _BloodLoss; } set { _BloodLoss = value; } }
    private string _TypeofForceps;
    public string TypeofForceps { get { return _TypeofForceps; } set { _TypeofForceps = value; } }
    private string _NumberofPulls;
    public string NumberofPulls { get { return _NumberofPulls; } set { _NumberofPulls = value; } }
    private string _Numberofslippage;
    public string Numberofslippage { get { return _Numberofslippage; } set { _Numberofslippage = value; } }
    private string _COC;
    public string COC { get { return _COC; } set { _COC = value; } }
    private string _COH;
    public string COH { get { return _COH; } set { _COH = value; } }
    //------------------------------ New Born Record --------------------------------------------------------------------------------

    private string _InfantName;
    public string InfantName { get { return _InfantName; } set { _InfantName = value; } }
    private string _MotherName;
    public string MotherName { get { return _MotherName; } set { _MotherName = value; } }
    private string _FileNo;
    public string FileNo { get { return _FileNo; } set { _FileNo = value; } }

    private string _CIRC;
    public string CIRC { get { return _CIRC; } set { _CIRC = value; } }
    private string _DrName;
    public string DrName { get { return _DrName; } set { _DrName = value; } }

    private string _Time1;
    public string Time1 { get { return _Time1; } set { _Time1 = value; } }
    private string _Time2;
    public string Time2 { get { return _Time2; } set { _Time2 = value; } }
    private string _Time3;
    public string Time3 { get { return _Time3; } set { _Time3 = value; } }
    private string _Time4;
    public string Time4 { get { return _Time4; } set { _Time4 = value; } }
    private string _Time5;
    public string Time5 { get { return _Time5; } set { _Time5 = value; } }
    private string _Time6;
    public string Time6 { get { return _Time6; } set { _Time6 = value; } }
    private string _Time7;
    public string Time7 { get { return _Time7; } set { _Time7 = value; } }
    private string _Time8;
    public string Time8 { get { return _Time8; } set { _Time8 = value; } }
    private string _Time9;
    public string Time9 { get { return _Time9; } set { _Time9 = value; } }

    private string _Temperature1;
    public string Temperature1 { get { return _Temperature1; } set { _Temperature1 = value; } }
    private string _Temperature2;
    public string Temperature2 { get { return _Temperature2; } set { _Temperature2 = value; } }
    private string _Temperature3;
    public string Temperature3 { get { return _Temperature3; } set { _Temperature3 = value; } }
    private string _Temperature4;
    public string Temperature4 { get { return _Temperature4; } set { _Temperature4 = value; } }
    private string _Temperature5;
    public string Temperature5 { get { return _Temperature5; } set { _Temperature5 = value; } }
    private string _Temperature6;
    public string Temperature6 { get { return _Temperature6; } set { _Temperature6 = value; } }
    private string _Temperature7;
    public string Temperature7 { get { return _Temperature7; } set { _Temperature7 = value; } }
    private string _Temperature8;
    public string Temperature8 { get { return _Temperature8; } set { _Temperature8 = value; } }
    private string _Temperature9;
    public string Temperature9 { get { return _Temperature9; } set { _Temperature9 = value; } }

    private string _Respirations1;
    public string Respirations1 { get { return _Respirations1; } set { _Respirations1 = value; } }
    private string _Respirations2;
    public string Respirations2 { get { return _Respirations2; } set { _Respirations2 = value; } }
    private string _Respirations3;
    public string Respirations3 { get { return _Respirations3; } set { _Respirations3 = value; } }
    private string _Respirations4;
    public string Respirations4 { get { return _Respirations4; } set { _Respirations4 = value; } }
    private string _Respirations5;
    public string Respirations5 { get { return _Respirations5; } set { _Respirations5 = value; } }
    private string _Respirations6;
    public string Respirations6 { get { return _Respirations6; } set { _Respirations6 = value; } }
    private string _Respirations7;
    public string Respirations7 { get { return _Respirations7; } set { _Respirations7 = value; } }
    private string _Respirations8;
    public string Respirations8 { get { return _Respirations8; } set { _Respirations8 = value; } }
    private string _Respirations9;
    public string Respirations9 { get { return _Respirations9; } set { _Respirations9 = value; } }

    private string _HeartRate1;
    public string HeartRate1 { get { return _HeartRate1; } set { _HeartRate1 = value; } }
    private string _HeartRate2;
    public string HeartRate2 { get { return _HeartRate2; } set { _HeartRate2 = value; } }
    private string _HeartRate3;
    public string HeartRate3 { get { return _HeartRate3; } set { _HeartRate3 = value; } }
    private string _HeartRate4;
    public string HeartRate4 { get { return _HeartRate4; } set { _HeartRate4 = value; } }
    private string _HeartRate5;
    public string HeartRate5 { get { return _HeartRate5; } set { _HeartRate5 = value; } }
    private string _HeartRate6;
    public string HeartRate6 { get { return _HeartRate6; } set { _HeartRate6 = value; } }
    private string _HeartRate7;
    public string HeartRate7 { get { return _HeartRate7; } set { _HeartRate7 = value; } }
    private string _HeartRate8;
    public string HeartRate8 { get { return _HeartRate8; } set { _HeartRate8 = value; } }
    private string _HeartRate9;
    public string HeartRate9 { get { return _HeartRate9; } set { _HeartRate9 = value; } }

    private string _Ftime1;
    public string Ftime1 { get { return _Ftime1; } set { _Ftime1 = value; } }
    private string _Ftime2;
    public string Ftime2 { get { return _Ftime2; } set { _Ftime2 = value; } }
    private string _Ftime3;
    public string Ftime3 { get { return _Ftime3; } set { _Ftime3 = value; } }
    private string _Ftime4;
    public string Ftime4 { get { return _Ftime4; } set { _Ftime4 = value; } }
    private string _Ftime5;
    public string Ftime5 { get { return _Ftime5; } set { _Ftime5 = value; } }
    private string _Ftime6;
    public string Ftime6 { get { return _Ftime6; } set { _Ftime6 = value; } }
    private string _Ftime7;
    public string Ftime7 { get { return _Ftime7; } set { _Ftime7 = value; } }
    private string _Ftime8;
    public string Ftime8 { get { return _Ftime8; } set { _Ftime8 = value; } }
    private string _Ftime9;
    public string Ftime9 { get { return _Ftime9; } set { _Ftime9 = value; } }

    private string _Formula1;
    public string Formula1 { get { return _Formula1; } set { _Formula1 = value; } }
    private string _Formula2;
    public string Formula2 { get { return _Formula2; } set { _Formula2 = value; } }
    private string _Formula3;
    public string Formula3 { get { return _Formula3; } set { _Formula3 = value; } }
    private string _Formula4;
    public string Formula4 { get { return _Formula4; } set { _Formula4 = value; } }
    private string _Formula5;
    public string Formula5 { get { return _Formula5; } set { _Formula5 = value; } }
    private string _Formula6;
    public string Formula6 { get { return _Formula6; } set { _Formula6 = value; } }
    private string _Formula7;
    public string Formula7 { get { return _Formula7; } set { _Formula7 = value; } }
    private string _Formula8;
    public string Formula8 { get { return _Formula8; } set { _Formula8 = value; } }
    private string _Formula9;
    public string Formula9 { get { return _Formula9; } set { _Formula9 = value; } }

    private string _Breast1;
    public string Breast1 { get { return _Breast1; } set { _Breast1 = value; } }
    private string _Breast2;
    public string Breast2 { get { return _Breast2; } set { _Breast2 = value; } }
    private string _Breast3;
    public string Breast3 { get { return _Breast3; } set { _Breast3 = value; } }
    private string _Breast4;
    public string Breast4 { get { return _Breast4; } set { _Breast4 = value; } }
    private string _Breast5;
    public string Breast5 { get { return _Breast5; } set { _Breast5 = value; } }
    private string _Breast6;
    public string Breast6 { get { return _Breast6; } set { _Breast6 = value; } }
    private string _Breast7;
    public string Breast7 { get { return _Breast7; } set { _Breast7 = value; } }
    private string _Breast8;
    public string Breast8 { get { return _Breast8; } set { _Breast8 = value; } }
    private string _Breast9;
    public string Breast9 { get { return _Breast9; } set { _Breast9 = value; } }

    private string _Supplement1;
    public string Supplement1 { get { return _Supplement1; } set { _Supplement1 = value; } }
    private string _Supplement2;
    public string Supplement2 { get { return _Supplement2; } set { _Supplement2 = value; } }
    private string _Supplement3;
    public string Supplement3 { get { return _Supplement3; } set { _Supplement3 = value; } }
    private string _Supplement4;
    public string Supplement4 { get { return _Supplement4; } set { _Supplement4 = value; } }
    private string _Supplement5;
    public string Supplement5 { get { return _Supplement5; } set { _Supplement5 = value; } }
    private string _Supplement6;
    public string Supplement6 { get { return _Supplement6; } set { _Supplement6 = value; } }
    private string _Supplement7;
    public string Supplement7 { get { return _Supplement7; } set { _Supplement7 = value; } }
    private string _Supplement8;
    public string Supplement8 { get { return _Supplement8; } set { _Supplement8 = value; } }
    private string _Supplement9;
    public string Supplement9 { get { return _Supplement9; } set { _Supplement9 = value; } }

    private string _cordCare1;
    public string cordCare1 { get { return _cordCare1; } set { _cordCare1 = value; } }
    private string _cordCare2;
    public string cordCare2 { get { return _cordCare2; } set { _cordCare2 = value; } }
    private string _cordCare3;
    public string cordCare3 { get { return _cordCare3; } set { _cordCare3 = value; } }
    private string _cordCare4;
    public string cordCare4 { get { return _cordCare4; } set { _cordCare4 = value; } }
    private string _cordCare5;
    public string cordCare5 { get { return _cordCare5; } set { _cordCare5 = value; } }
    private string _cordCare6;
    public string cordCare6 { get { return _cordCare6; } set { _cordCare6 = value; } }
    private string _cordCare7;
    public string cordCare7 { get { return _cordCare7; } set { _cordCare7 = value; } }
    private string _cordCare8;
    public string cordCare8 { get { return _cordCare8; } set { _cordCare8 = value; } }
    private string _cordCare9;
    public string cordCare9 { get { return _cordCare9; } set { _cordCare9 = value; } }

    private string _Urine1;
    public string Urine1 { get { return _Urine1; } set { _Urine1 = value; } }
    private string _Urine2;
    public string Urine2 { get { return _Urine2; } set { _Urine2 = value; } }
    private string _Urine3;
    public string Urine3 { get { return _Urine3; } set { _Urine3 = value; } }
    private string _Urine4;
    public string Urine4 { get { return _Urine4; } set { _Urine4 = value; } }
    private string _Urine5;
    public string Urine5 { get { return _Urine5; } set { _Urine5 = value; } }
    private string _Urine6;
    public string Urine6 { get { return _Urine6; } set { _Urine6 = value; } }
    private string _Urine7;
    public string Urine7 { get { return _Urine7; } set { _Urine7 = value; } }
    private string _Urine8;
    public string Urine8 { get { return _Urine8; } set { _Urine8 = value; } }
    private string _Urine9;
    public string Urine9 { get { return _Urine9; } set { _Urine9 = value; } }

    private string _Stools1;
    public string Stools1 { get { return _Stools1; } set { _Stools1 = value; } }
    private string _Stools2;
    public string Stools2 { get { return _Stools2; } set { _Stools2 = value; } }
    private string _Stools3;
    public string Stools3 { get { return _Stools3; } set { _Stools3 = value; } }
    private string _Stools4;
    public string Stools4 { get { return _Stools4; } set { _Stools4 = value; } }
    private string _Stools5;
    public string Stools5 { get { return _Stools5; } set { _Stools5 = value; } }
    private string _Stools6;
    public string Stools6 { get { return _Stools6; } set { _Stools6 = value; } }
    private string _Stools7;
    public string Stools7 { get { return _Stools7; } set { _Stools7 = value; } }
    private string _Stools8;
    public string Stools8 { get { return _Stools8; } set { _Stools8 = value; } }
    private string _Stools9;
    public string Stools9 { get { return _Stools9; } set { _Stools9 = value; } }

    private string _RNSignature1;
    public string RNSignature1 { get { return _RNSignature1; } set { _RNSignature1 = value; } }
    private string _RNSignature2;
    public string RNSignature2 { get { return _RNSignature2; } set { _RNSignature2 = value; } }
    private string _RNSignature3;
    public string RNSignature3 { get { return _RNSignature3; } set { _RNSignature3 = value; } }
    private string _RNSignature4;
    public string RNSignature4 { get { return _RNSignature4; } set { _RNSignature4 = value; } }
    private string _RNSignature5;
    public string RNSignature5 { get { return _RNSignature5; } set { _RNSignature5 = value; } }
    private string _RNSignature6;
    public string RNSignature6 { get { return _RNSignature6; } set { _RNSignature6 = value; } }
    private string _RNSignature7;
    public string RNSignature7 { get { return _RNSignature7; } set { _RNSignature7 = value; } }
    private string _RNSignature8;
    public string RNSignature8 { get { return _RNSignature8; } set { _RNSignature8 = value; } }
    private string _RNSignature9;
    public string RNSignature9 { get { return _RNSignature9; } set { _RNSignature9 = value; } }

    //--------------------------------Maternial Patient Info---------------------------------------------------

    private int _ISSmoking;
    public int ISSmoking { get { return _ISSmoking; } set { _ISSmoking = value; } }
    private int _IsAlcohol;
    public int IsAlcohol { get { return _IsAlcohol; } set { _IsAlcohol = value; } }
    private int _RecreationalDrugs;
    public int RecreationalDrugs { get { return _RecreationalDrugs; } set { _RecreationalDrugs = value; } }
            
    private string _Allergise;
    public string Allergise { get { return _Allergise; } set { _Allergise = value; } }
    private string _FoodPreferences;
    public string FoodPreferences { get { return _FoodPreferences; } set { _FoodPreferences = value; } }
    private string _ChiefComplaints;
    public string ChiefComplaints { get { return _ChiefComplaints; } set { _ChiefComplaints = value; } }

    private bool _IsLowerabdominalpains;
    public bool IsLowerabdominalpains { get { return _IsLowerabdominalpains; } set { _IsLowerabdominalpains = value; } }
    private string _Lowerabdominalpains;
    public string  Lowerabdominalpains { get { return _Lowerabdominalpains; } set { _Lowerabdominalpains = value; } }

    private bool _IsContractions;
    public bool IsContractions { get { return _IsContractions; } set { _IsContractions = value; } }
    private string _Contractions;
    public string Contractions { get { return _Contractions; } set { _Contractions = value; } }

    private bool _IsBleeding;
    public bool IsBleeding { get { return _IsBleeding; } set { _IsBleeding = value; } }
    private string _Bleeding;
    public string Bleeding { get { return _Bleeding; } set { _Bleeding = value; } }

    private bool _IsHeavybleeding;
    public bool IsHeavybleeding { get { return _IsHeavybleeding; } set { _IsHeavybleeding = value; } }
    private string _Heavybleeding;
    public string Heavybleeding { get { return _Heavybleeding; } set { _Heavybleeding = value; } }

    private bool _isDrainingliquor;
    public bool isDrainingliquor { get { return _isDrainingliquor; } set { _isDrainingliquor = value; } }
    private string _Drainingliquor;
    public string Drainingliquor { get { return _Drainingliquor; } set { _Drainingliquor = value; } }
    private int _ExaminationFinding;
    public int ExaminationFinding { get { return _ExaminationFinding; } set { _ExaminationFinding = value; } }
    private string _Heightoffundus;
    public string Heightoffundus { get { return _Heightoffundus; } set { _Heightoffundus = value; } }
    private string _Presentingpart;
    public string Presentingpart { get { return _Presentingpart; } set { _Presentingpart = value; } }
    private string _Fetalheart;
    public string Fetalheart { get { return _Fetalheart; } set { _Fetalheart = value; } }
    private bool _Establishedlaborr;
    public bool Establishedlaborr { get { return _Establishedlaborr; } set { _Establishedlaborr = value; } }
    private bool _Notinlabor;
    public bool Notinlabor { get { return _Notinlabor; } set { _Notinlabor = value; } }
    private string _AntenatalClinic;
    public string AntenatalClinic { get { return _AntenatalClinic; } set { _AntenatalClinic = value; } }
    private string _ClinicCardseen;
    public string ClinicCardseen { get { return _ClinicCardseen; } set { _ClinicCardseen = value; } }

    private bool _Hb;
    public bool Hb { get { return _Hb; } set { _Hb = value; } }
    private bool _BloodSugar;
    public bool BloodSugar { get { return _BloodSugar; } set { _BloodSugar = value; } }
    private bool _VDRL;
    public bool VDRL { get { return _VDRL; } set { _VDRL = value; } }
    private bool _SicklingTest;
    public bool SicklingTest { get { return _SicklingTest; } set { _SicklingTest = value; } }
    private bool _HIV;
    public bool HIV { get { return _HIV; } set { _HIV = value; } }
    private bool _HepB;
    public bool HepB { get { return _HepB; } set { _HepB = value; } }
    private bool _SullivanTest;
    public bool SullivanTest { get { return _SullivanTest; } set { _SullivanTest = value; } }

    private string _HbResult;
    public string HbResult { get { return _HbResult; } set { _HbResult = value; } }
    private string _BloodSugarResult;
    public string BloodSugarResult { get { return _BloodSugarResult; } set { _BloodSugarResult = value; } }
    private string _VDRLResult;
    public string VDRLResult { get { return _VDRLResult; } set { _VDRLResult = value; } }
    private string _SicklingTestResult;
    public string SicklingTestResult { get { return _SicklingTestResult; } set { _SicklingTestResult = value; } }
    private string _HIVResult;
    public string HIVResult { get { return _HIVResult; } set { _HIVResult = value; } }
    private string _HepBResult;
    public string HepBResult { get { return _HepBResult; } set { _HepBResult = value; } }
    private string _SullivanTestResult;
    public string SullivanTestResult { get { return _SullivanTestResult; } set { _SullivanTestResult = value; } }

    private DateTime _LMP;
    public DateTime LMP { get { return _LMP; } set { _LMP = value; } }

    private string _EDD;
    public string EDD { get { return _EDD; } set { _EDD = value; } }
    private string _GestationalTest;
    public string GestationalTest { get { return _GestationalTest; } set { _GestationalTest = value; } }

    private bool _ANCVisit;
    public bool ANCVisit { get { return _ANCVisit; } set { _ANCVisit = value; } }
    private bool _ANCVisit1;
    public bool ANCVisit1 { get { return _ANCVisit1; } set { _ANCVisit1 = value; } }
    private bool _ANCVisit2;
    public bool ANCVisit2 { get { return _ANCVisit2; } set { _ANCVisit2 = value; } }
    private bool _Ultrasound;
    public bool Ultrasound { get { return _Ultrasound; } set { _Ultrasound = value; } }
    private bool _Ultrasound1;
    public bool Ultrasound1 { get { return _Ultrasound1; } set { _Ultrasound1 = value; } }
    private bool _Ultrasound2;
    public bool Ultrasound2 { get { return _Ultrasound2; } set { _Ultrasound2 = value; } }

    private string _Parity;
    public string Parity { get { return _Parity; } set { _Parity = value; } }
    private string _NumberofAbortion;
    public string NumberofAbortion { get { return _NumberofAbortion; } set { _NumberofAbortion = value; } }
    private string _Numberofmiscarriages;
    public string Numberofmiscarriages { get { return _Numberofmiscarriages; } set { _Numberofmiscarriages = value; } }
    private string _Numberofchildrenalive;
    public string Numberofchildrenalive { get { return _Numberofchildrenalive; } set { _Numberofchildrenalive = value; } }
    private string _PreviousPregancies;
    public string PreviousPregancies { get { return _PreviousPregancies; } set { _PreviousPregancies = value; } }

    private DateTime _Date1;
    public DateTime Date1 { get { return _Date1; } set { _Date1 = value; } }
    private string _Gestationalage1;
    public string Gestationalage1 { get { return _Gestationalage1; } set { _Gestationalage1 = value; } }
    private string _TypeofDelivery1;
    public string TypeofDelivery1 { get { return _TypeofDelivery1; } set { _TypeofDelivery1 = value; } }
    private string _Alive1;
    public string Alive1 { get { return _Alive1; } set { _Alive1 = value; } }

    private DateTime _Date2;
    public DateTime Date2 { get { return _Date2; } set { _Date2 = value; } }
    private string _Gestationalage2;
    public string Gestationalage2 { get { return _Gestationalage2; } set { _Gestationalage2 = value; } }
    private string _TypeofDelivery2;
    public string TypeofDelivery2 { get { return _TypeofDelivery2; } set { _TypeofDelivery2 = value; } }
    private string _Alive2;
    public string Alive2 { get { return _Alive2; } set { _Alive2 = value; } }

    private DateTime _Date3;
    public DateTime Date3 { get { return _Date3; } set { _Date3 = value; } }
    private string _Gestationalage3;
    public string Gestationalage3 { get { return _Gestationalage3; } set { _Gestationalage3 = value; } }
    private string _TypeofDelivery3;
    public string TypeofDelivery3 { get { return _TypeofDelivery3; } set { _TypeofDelivery3 = value; } }
    private string _Alive3;
    public string Alive3 { get { return _Alive3; } set { _Alive3 = value; } }

    private DateTime _Date4;
    public DateTime Date4 { get { return _Date4; } set { _Date4 = value; } }
    private string _Gestationalage4;
    public string Gestationalage4 { get { return _Gestationalage4; } set { _Gestationalage4 = value; } }
    private string _TypeofDelivery4;
    public string TypeofDelivery4 { get { return _TypeofDelivery4; } set { _TypeofDelivery4 = value; } }
    private string _Alive4;
    public string Alive4 { get { return _Alive4; } set { _Alive4 = value; } }

    private bool _PMHHypertension;
    public bool PMHHypertension { get { return _PMHHypertension; } set { _PMHHypertension = value; } }
    private bool _PMHDiabetes;
    public bool PMHDiabetes { get { return _PMHDiabetes; } set { _PMHDiabetes = value; } }
    private bool _PMHSickleCellDisease;
    public bool PMHSickleCellDisease { get { return _PMHSickleCellDisease; } set { _PMHSickleCellDisease = value; } }
    private bool _PMHAsthma;
    public bool PMHAsthma { get { return _PMHAsthma; } set { _PMHAsthma = value; } }
    private bool _PMHThyroiddisease;
    public bool PMHThyroiddisease { get { return _PMHThyroiddisease; } set { _PMHThyroiddisease = value; } }
    private bool _PMHEpilepsy;
    public bool PMHEpilepsy { get { return _PMHEpilepsy; } set { _PMHEpilepsy = value; } }
    private bool _PMHHepatitis;
    public bool PMHHepatitis { get { return _PMHHepatitis; } set { _PMHHepatitis = value; } }
    private bool _PMHKidneyDisease;
    public bool PMHKidneyDisease { get { return _PMHKidneyDisease; } set { _PMHKidneyDisease = value; } }
    private bool _PMHHIV;
    public bool PMHHIV { get { return _PMHHIV; } set { _PMHHIV = value; } }

    private bool _FHHypertension;
    public bool FHHypertension { get { return _FHHypertension; } set { _FHHypertension = value; } }
    private bool _FHDiabetes;
    public bool FHDiabetes { get { return _FHDiabetes; } set { _FHDiabetes = value; } }
    private bool _FHSickleCellDisease;
    public bool FHSickleCellDisease { get { return _FHSickleCellDisease; } set { _FHSickleCellDisease = value; } }
    private bool _FHAsthma;
    public bool FHAsthma { get { return _FHAsthma; } set { _FHAsthma = value; } }
    private bool _FHThyroiddisease;
    public bool FHThyroiddisease { get { return _FHThyroiddisease; } set { _FHThyroiddisease = value; } }
    private bool _FHEpilepsy;
    public bool FHEpilepsy { get { return _FHEpilepsy; } set { _FHEpilepsy = value; } }
    private bool _FHHepatitis;
    public bool FHHepatitis { get { return _FHHepatitis; } set { _FHHepatitis = value; } }
    private bool _FHKidneyDisease;
    public bool FHKidneyDisease { get { return _FHKidneyDisease; } set { _FHKidneyDisease = value; } }
    private bool _FHHIV;
    public bool FHHIV { get { return _FHHIV; } set { _FHHIV = value; } }
  









    public BELDeliveryPage()
	{
		//
		// TODO: Add constructor logic here
		//
        this.CreatedOn = Date.getMinDate();
        this.Date4 = Date.getMinDate();
        this.Date3 = Date.getMinDate();
        this.Date2 = Date.getMinDate();
        this.Date1 = Date.getMinDate();

        this.LMP = Date.getMinDate();
        this.Stage1Date = Date.getMinDate();
        this.Stage2Date = Date.getMinDate();
        this.Stage3Date = Date.getMinDate();
        this.DateOfBirth = Date.getMinDate();  
	}
    public string InsertDelivery_Page()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_Insert_DeliveryPage", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@Patregid", Patregid);
            cmd.Parameters.AddWithValue("@OpdNo", OpdNo);
            cmd.Parameters.AddWithValue("@IpdNo", IpdNo);
           // cmd.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);

            if (this.DateOfBirth == Date.getMinDate())
                cmd.Parameters.Add(new SqlParameter("@DateOfBirth", SqlDbType.DateTime)).Value = DBNull.Value;
            else
                cmd.Parameters.Add(new SqlParameter("@DateOfBirth", SqlDbType.DateTime)).Value = DateOfBirth;

            cmd.Parameters.AddWithValue("@TimeOfBirth", TimeOfBirth);
            cmd.Parameters.AddWithValue("@BirthGender", BirthGender);
            cmd.Parameters.AddWithValue("@BirthWeight", BirthWeight);
            cmd.Parameters.AddWithValue("@TotalActivity1", TotalActivity1);

            cmd.Parameters.AddWithValue("@TotalPulse1", TotalPulse1);
            cmd.Parameters.AddWithValue("@TotalGrimace1", TotalGrimace1);
            cmd.Parameters.AddWithValue("@TotalAppearance1", TotalAppearance1);
            cmd.Parameters.AddWithValue("@TotalRespiration1", TotalRespiration1);

            cmd.Parameters.AddWithValue("@TotalActivity5", TotalActivity5);
            cmd.Parameters.AddWithValue("@TotalPulse5", TotalPulse5);
            cmd.Parameters.AddWithValue("@TotalGrimace5", TotalGrimace5);
            cmd.Parameters.AddWithValue("@TotalAppearance5", TotalAppearance5);

            cmd.Parameters.AddWithValue("@TotalRespiration5", TotalAppearance5);

            cmd.Parameters.AddWithValue("@SpontaneousVaginal", SpontaneousVaginal);
            cmd.Parameters.AddWithValue("@InductionOxytocin", InductionOxytocin);
            cmd.Parameters.AddWithValue("@InductionCytotec", InductionCytotec);
            cmd.Parameters.AddWithValue("@VaccumExtraction", VaccumExtraction);

            cmd.Parameters.AddWithValue("@Forcepsdelivery", Forcepsdelivery);
            cmd.Parameters.AddWithValue("@Caesariansection", Caesariansection);
            //cmd.Parameters.AddWithValue("@Stage1Date", Stage1Date);

            if (this.Stage1Date == Date.getMinDate())
                cmd.Parameters.Add(new SqlParameter("@Stage1Date", SqlDbType.DateTime)).Value = DBNull.Value;
            else
                cmd.Parameters.Add(new SqlParameter("@Stage1Date", SqlDbType.DateTime)).Value = Stage1Date;

            cmd.Parameters.AddWithValue("@Stage1TimeFrom", Stage1TimeFrom);
            cmd.Parameters.AddWithValue("@Stage1TimeTo", Stage1TimeTo);
            cmd.Parameters.AddWithValue("@Stage1Duration", Stage1Duration);
          //  cmd.Parameters.AddWithValue("@Stage2Date", Stage2Date);

            if (this.Stage2Date == Date.getMinDate())
                cmd.Parameters.Add(new SqlParameter("@Stage2Date", SqlDbType.DateTime)).Value = DBNull.Value;
            else
                cmd.Parameters.Add(new SqlParameter("@Stage2Date", SqlDbType.DateTime)).Value = Stage2Date;

            cmd.Parameters.AddWithValue("@Stage2TimeFrom", Stage2TimeFrom);
            cmd.Parameters.AddWithValue("@Stage2TimeTo", Stage2TimeTo);
            cmd.Parameters.AddWithValue("@Stage2Duration", Stage3Duration);
           // cmd.Parameters.AddWithValue("@Stage3Date", Stage3Date);
            if (this.Stage3Date == Date.getMinDate())
                cmd.Parameters.Add(new SqlParameter("@Stage3Date", SqlDbType.DateTime)).Value = DBNull.Value;
            else
                cmd.Parameters.Add(new SqlParameter("@Stage3Date", SqlDbType.DateTime)).Value = Stage3Date;

            cmd.Parameters.AddWithValue("@Stage3TimeFrom", Stage3TimeFrom);
            cmd.Parameters.AddWithValue("@Stage3TimeTo", Stage3TimeTo);
            cmd.Parameters.AddWithValue("@Stage3Duration", Stage3Duration);

            cmd.Parameters.AddWithValue("@PlacentaComplete", PlacentaComplete);
            cmd.Parameters.AddWithValue("@PlacentaInComplete", PlacentaInComplete);
            cmd.Parameters.AddWithValue("@bloodVessels", bloodVessels);
            cmd.Parameters.AddWithValue("@MeconiumStaining", MeconiumStaining);
            cmd.Parameters.AddWithValue("@Cordaround", Cordaround);
            cmd.Parameters.AddWithValue("@Episiotomy", Episiotomy);
            cmd.Parameters.AddWithValue("@Vaginal", Vaginal);
            cmd.Parameters.AddWithValue("@RepairBy", RepairBy);
            cmd.Parameters.AddWithValue("@Timeofrupturemembrance", Timeofrupturemembrance);

            cmd.Parameters.AddWithValue("@BloodLoss", BloodLoss);
            cmd.Parameters.AddWithValue("@TypeofForceps", TypeofForceps);
            cmd.Parameters.AddWithValue("@NumberofPulls", NumberofPulls);
            cmd.Parameters.AddWithValue("@Numberofslippage", Numberofslippage);
          //  cmd.Parameters.AddWithValue("@Timeofrupturemembrance", obj.MaterinityDeathReason);


            cmd.Parameters.AddWithValue("@Branchid", BranchId);
            cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);



            cmd.Parameters.AddWithValue("@FID", FId);
            cmd.Parameters.AddWithValue("@COC", COC);
            cmd.Parameters.AddWithValue("@COH", COH);


            object Result = cmd.ExecuteScalar();
            return Convert.ToString(Result);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }


    public string Insert_NewBornRecord()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_Insert_NewBornRecord", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@Patregid", Patregid);
            cmd.Parameters.AddWithValue("@OpdNo", OpdNo);
            cmd.Parameters.AddWithValue("@IpdNo", IpdNo);
            cmd.Parameters.AddWithValue("@InfantName", InfantName);
            cmd.Parameters.AddWithValue("@MotherName", MotherName);
           // cmd.Parameters.AddWithValue("@BirthDate", DateOfBirth);
            if (this.DateOfBirth == Date.getMinDate())
                cmd.Parameters.Add(new SqlParameter("@BirthDate", SqlDbType.DateTime)).Value = DBNull.Value;
            else
                cmd.Parameters.Add(new SqlParameter("@BirthDate", SqlDbType.DateTime)).Value = DateOfBirth;
            cmd.Parameters.AddWithValue("@FileNo", FileNo);
            cmd.Parameters.AddWithValue("@CIRC", CIRC);

            cmd.Parameters.AddWithValue("@BirthGender", BirthGender);

            cmd.Parameters.AddWithValue("@DrName", DrName);
            cmd.Parameters.AddWithValue("@Time1", Time1);
            cmd.Parameters.AddWithValue("@Time2", Time2);
            cmd.Parameters.AddWithValue("@Time3", Time3);

            cmd.Parameters.AddWithValue("@Time4", Time4);
            cmd.Parameters.AddWithValue("@Time5", Time5);
            cmd.Parameters.AddWithValue("@Time6", Time6);
            cmd.Parameters.AddWithValue("@Time7", Time7);
            cmd.Parameters.AddWithValue("@Time8", Time8);
            cmd.Parameters.AddWithValue("@Time9", Time9);

            cmd.Parameters.AddWithValue("@Temperature1", Temperature1);
            cmd.Parameters.AddWithValue("@Temperature2", Temperature2);
            cmd.Parameters.AddWithValue("@Temperature3", Temperature3);

            cmd.Parameters.AddWithValue("@Temperature4", Temperature4);
            cmd.Parameters.AddWithValue("@Temperature5", Temperature5);
            cmd.Parameters.AddWithValue("@Temperature6", Temperature6);
            cmd.Parameters.AddWithValue("@Temperature7", Temperature7);
            cmd.Parameters.AddWithValue("@Temperature8", Temperature8);
            cmd.Parameters.AddWithValue("@Temperature9", Temperature9);

            cmd.Parameters.AddWithValue("@Respirations1", Respirations1);
            cmd.Parameters.AddWithValue("@Respirations2", Respirations2);
            cmd.Parameters.AddWithValue("@Respirations3", Respirations3);
            cmd.Parameters.AddWithValue("@Respirations4", Respirations4);
            cmd.Parameters.AddWithValue("@Respirations5", Respirations5);
            cmd.Parameters.AddWithValue("@Respirations6", Respirations6);
            cmd.Parameters.AddWithValue("@Respirations7", Respirations7);
            cmd.Parameters.AddWithValue("@Respirations8", Respirations8);
            cmd.Parameters.AddWithValue("@Respirations9", Respirations9);

            cmd.Parameters.AddWithValue("@HeartRate1", HeartRate1);
            cmd.Parameters.AddWithValue("@HeartRate2", HeartRate2);
            cmd.Parameters.AddWithValue("@HeartRate3", HeartRate3);
            cmd.Parameters.AddWithValue("@HeartRate4", HeartRate4);
            cmd.Parameters.AddWithValue("@HeartRate5", HeartRate5);
            cmd.Parameters.AddWithValue("@HeartRate6", HeartRate6);
            cmd.Parameters.AddWithValue("@HeartRate7", HeartRate7);
            cmd.Parameters.AddWithValue("@HeartRate8", HeartRate8);
            cmd.Parameters.AddWithValue("@HeartRate9", HeartRate9);

            cmd.Parameters.AddWithValue("@Ftime1", Ftime1);
            cmd.Parameters.AddWithValue("@Ftime2", Ftime2);
            cmd.Parameters.AddWithValue("@Ftime3", Ftime3);
            cmd.Parameters.AddWithValue("@Ftime4", Ftime4);
            cmd.Parameters.AddWithValue("@Ftime5", Ftime5);
            cmd.Parameters.AddWithValue("@Ftime6", Ftime6);
            cmd.Parameters.AddWithValue("@Ftime7", Ftime7);
            cmd.Parameters.AddWithValue("@Ftime8", Ftime8);
            cmd.Parameters.AddWithValue("@Ftime9", Ftime9);

            cmd.Parameters.AddWithValue("@Formula1", Formula1);
            cmd.Parameters.AddWithValue("@Formula2", Formula2);
            cmd.Parameters.AddWithValue("@Formula3", Formula3);
            cmd.Parameters.AddWithValue("@Formula4", Formula4);
            cmd.Parameters.AddWithValue("@Formula5", Formula5);
            cmd.Parameters.AddWithValue("@Formula6", Formula6);
            cmd.Parameters.AddWithValue("@Formula7", Formula7);
            cmd.Parameters.AddWithValue("@Formula8", Formula8);
            cmd.Parameters.AddWithValue("@Formula9", Formula9);

            cmd.Parameters.AddWithValue("@Breast1", Breast1);
            cmd.Parameters.AddWithValue("@Breast2", Breast2);
            cmd.Parameters.AddWithValue("@Breast3", Breast3);
            cmd.Parameters.AddWithValue("@Breast4", Breast4);
            cmd.Parameters.AddWithValue("@Breast5", Breast5);
            cmd.Parameters.AddWithValue("@Breast6", Breast6);
            cmd.Parameters.AddWithValue("@Breast7", Breast7);
            cmd.Parameters.AddWithValue("@Breast8", Breast8);
            cmd.Parameters.AddWithValue("@Breast9", Breast9);

            cmd.Parameters.AddWithValue("@Supplement1", Supplement1);
            cmd.Parameters.AddWithValue("@Supplement2", Supplement2);
            cmd.Parameters.AddWithValue("@Supplement3", Supplement3);
            cmd.Parameters.AddWithValue("@Supplement4", Supplement4);
            cmd.Parameters.AddWithValue("@Supplement5", Supplement5);
            cmd.Parameters.AddWithValue("@Supplement6", Supplement6);
            cmd.Parameters.AddWithValue("@Supplement7", Supplement7);
            cmd.Parameters.AddWithValue("@Supplement8", Supplement8);
            cmd.Parameters.AddWithValue("@Supplement9", Supplement9);

            cmd.Parameters.AddWithValue("@cordCare1", cordCare1);
            cmd.Parameters.AddWithValue("@cordCare2", cordCare2);
            cmd.Parameters.AddWithValue("@cordCare3", cordCare3);
            cmd.Parameters.AddWithValue("@cordCare4", cordCare4);
            cmd.Parameters.AddWithValue("@cordCare5", cordCare5);
            cmd.Parameters.AddWithValue("@cordCare6", cordCare6);
            cmd.Parameters.AddWithValue("@cordCare7", cordCare7);
            cmd.Parameters.AddWithValue("@cordCare8", cordCare8);
            cmd.Parameters.AddWithValue("@cordCare9", cordCare9);

            cmd.Parameters.AddWithValue("@Urine1", Urine1);
            cmd.Parameters.AddWithValue("@Urine2", Urine2);
            cmd.Parameters.AddWithValue("@Urine3", Urine3);
            cmd.Parameters.AddWithValue("@Urine4", Urine4);
            cmd.Parameters.AddWithValue("@Urine5", Urine5);
            cmd.Parameters.AddWithValue("@Urine6", Urine6);
            cmd.Parameters.AddWithValue("@Urine7", Urine7);
            cmd.Parameters.AddWithValue("@Urine8", Urine8);
            cmd.Parameters.AddWithValue("@Urine9", Urine9);

            cmd.Parameters.AddWithValue("@Stools1", Stools1);
            cmd.Parameters.AddWithValue("@Stools2", Stools2);
            cmd.Parameters.AddWithValue("@Stools3", Stools3);
            cmd.Parameters.AddWithValue("@Stools4", Stools4);
            cmd.Parameters.AddWithValue("@Stools5", Stools5);
            cmd.Parameters.AddWithValue("@Stools6", Stools6);
            cmd.Parameters.AddWithValue("@Stools7", Stools7);
            cmd.Parameters.AddWithValue("@Stools8", Stools8);
            cmd.Parameters.AddWithValue("@Stools9", Stools9);

            cmd.Parameters.AddWithValue("@RNSignature1", RNSignature1);
            cmd.Parameters.AddWithValue("@RNSignature2", RNSignature2);
            cmd.Parameters.AddWithValue("@RNSignature3", RNSignature3);
            cmd.Parameters.AddWithValue("@RNSignature4", RNSignature4);
            cmd.Parameters.AddWithValue("@RNSignature5", RNSignature5);
            cmd.Parameters.AddWithValue("@RNSignature6", RNSignature6);
            cmd.Parameters.AddWithValue("@RNSignature7", RNSignature7);
            cmd.Parameters.AddWithValue("@RNSignature8", RNSignature8);
            cmd.Parameters.AddWithValue("@RNSignature9", RNSignature9);

            cmd.Parameters.AddWithValue("@Branchid", BranchId);
            cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);



            cmd.Parameters.AddWithValue("@FID", FId);


            object Result = cmd.ExecuteScalar();
            return Convert.ToString(Result);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }

    public string Insert_NewBornRegister()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Insert_NewBornRegister", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@Patregid", Patregid);
            cmd.Parameters.AddWithValue("@OpdNo", OpdNo);
            cmd.Parameters.AddWithValue("@IpdNo", IpdNo);
            cmd.Parameters.AddWithValue("@InfantName", InfantName);
            cmd.Parameters.AddWithValue("@MotherName", MotherName);
            // cmd.Parameters.AddWithValue("@BirthDate", DateOfBirth);
            if (this.DateOfBirth == Date.getMinDate())
                cmd.Parameters.Add(new SqlParameter("@BirthDate", SqlDbType.DateTime)).Value = DBNull.Value;
            else
                cmd.Parameters.Add(new SqlParameter("@BirthDate", SqlDbType.DateTime)).Value = DateOfBirth;

            cmd.Parameters.AddWithValue("@BirthGender", BirthGender);
           

           

            cmd.Parameters.AddWithValue("@Branchid", BranchId);
            cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);



            cmd.Parameters.AddWithValue("@FID", FId);


            object Result = cmd.ExecuteScalar();
            return Convert.ToString(Result);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }


    public string Insert_MaternalPatientInfo()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_Insert_Maternal_PatientInformation", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@Patregid", Patregid);
            cmd.Parameters.AddWithValue("@OpdNo", OpdNo);
            cmd.Parameters.AddWithValue("@IpdNo", IpdNo);
            cmd.Parameters.AddWithValue("@ISSmoking", ISSmoking);
            cmd.Parameters.AddWithValue("@IsAlcohol", IsAlcohol);
            cmd.Parameters.AddWithValue("@RecreationalDrugs", RecreationalDrugs);
            
            cmd.Parameters.AddWithValue("@Allergise", Allergise);
            cmd.Parameters.AddWithValue("@FoodPreferences", FoodPreferences);
            cmd.Parameters.AddWithValue("@ChiefComplaints", ChiefComplaints);

            cmd.Parameters.AddWithValue("@IsLowerabdominalpains", IsLowerabdominalpains);
            cmd.Parameters.AddWithValue("@Lowerabdominalpains", Lowerabdominalpains);
            cmd.Parameters.AddWithValue("@IsContractions", IsContractions);
            cmd.Parameters.AddWithValue("@Contractions", Contractions);

            cmd.Parameters.AddWithValue("@IsBleeding", IsBleeding);
            cmd.Parameters.AddWithValue("@Bleeding", Bleeding);
            cmd.Parameters.AddWithValue("@IsHeavybleeding", IsHeavybleeding);
            cmd.Parameters.AddWithValue("@Heavybleeding", Heavybleeding);
            cmd.Parameters.AddWithValue("@isDrainingliquor", isDrainingliquor);
            cmd.Parameters.AddWithValue("@Drainingliquor", Drainingliquor);

            cmd.Parameters.AddWithValue("@ExaminationFinding", ExaminationFinding);
            cmd.Parameters.AddWithValue("@Heightoffundus", Heightoffundus);
            cmd.Parameters.AddWithValue("@Presentingpart", Presentingpart);

            cmd.Parameters.AddWithValue("@Fetalheart", Fetalheart);
            cmd.Parameters.AddWithValue("@Establishedlabor", Establishedlaborr);
            cmd.Parameters.AddWithValue("@Notinlabor", Notinlabor);
            cmd.Parameters.AddWithValue("@AntenatalClinic", AntenatalClinic);
            cmd.Parameters.AddWithValue("@ClinicCardseen", ClinicCardseen);
            cmd.Parameters.AddWithValue("@Hb", Hb);

            cmd.Parameters.AddWithValue("@BloodSugar", BloodSugar);
            cmd.Parameters.AddWithValue("@VDRL", VDRL);
            cmd.Parameters.AddWithValue("@SicklingTest", SicklingTest);
            cmd.Parameters.AddWithValue("@HIV", HIV);
            cmd.Parameters.AddWithValue("@HepB", HepB);
            cmd.Parameters.AddWithValue("@SullivanTest", SullivanTest);
           // cmd.Parameters.AddWithValue("@LMP", LMP);
            if (this.LMP == Date.getMinDate())
                cmd.Parameters.Add(new SqlParameter("@LMP", SqlDbType.DateTime)).Value = DBNull.Value;
            else
                cmd.Parameters.Add(new SqlParameter("@LMP", SqlDbType.DateTime)).Value = LMP;

            cmd.Parameters.AddWithValue("@EDD", EDD);
            cmd.Parameters.AddWithValue("@GestationalTest", GestationalTest);

            cmd.Parameters.AddWithValue("@ANCVisit", ANCVisit);
            cmd.Parameters.AddWithValue("@ANCVisit1", ANCVisit1);
            cmd.Parameters.AddWithValue("@ANCVisit2", ANCVisit2);
            cmd.Parameters.AddWithValue("@Ultrasound", Ultrasound);
            cmd.Parameters.AddWithValue("@Ultrasound1", Ultrasound1);
            cmd.Parameters.AddWithValue("@Ultrasound2", Ultrasound2);
            cmd.Parameters.AddWithValue("@Parity", Parity);
            cmd.Parameters.AddWithValue("@NumberofAbortion", NumberofAbortion);
            cmd.Parameters.AddWithValue("@Numberofmiscarriages", Numberofmiscarriages);
            cmd.Parameters.AddWithValue("@Numberofchildrenalive", Numberofchildrenalive);
            cmd.Parameters.AddWithValue("@PreviousPregancies", PreviousPregancies);

           // cmd.Parameters.AddWithValue("@Date1", Date1);
            if (this.Date1 == Date.getMinDate())
                cmd.Parameters.Add(new SqlParameter("@Date1", SqlDbType.DateTime)).Value = DBNull.Value;
            else
                cmd.Parameters.Add(new SqlParameter("@Date1", SqlDbType.DateTime)).Value = Date1;
            cmd.Parameters.AddWithValue("@Gestationalage1", Gestationalage1);
            cmd.Parameters.AddWithValue("@TypeofDelivery1", TypeofDelivery1);
            cmd.Parameters.AddWithValue("@Alive1", Alive1);

           // cmd.Parameters.AddWithValue("@Date2", Date2);
            if (this.Date2 == Date.getMinDate())
                cmd.Parameters.Add(new SqlParameter("@Date2", SqlDbType.DateTime)).Value = DBNull.Value;
            else
                cmd.Parameters.Add(new SqlParameter("@Date2", SqlDbType.DateTime)).Value = Date2;
            cmd.Parameters.AddWithValue("@Gestationalage2", Gestationalage2);
            cmd.Parameters.AddWithValue("@TypeofDelivery2", TypeofDelivery2);
            cmd.Parameters.AddWithValue("@Alive2", Alive2);

           // cmd.Parameters.AddWithValue("@Date3", Date3);
            if (this.Date3 == Date.getMinDate())
                cmd.Parameters.Add(new SqlParameter("@Date3", SqlDbType.DateTime)).Value = DBNull.Value;
            else
                cmd.Parameters.Add(new SqlParameter("@Date3", SqlDbType.DateTime)).Value = Date3;
            cmd.Parameters.AddWithValue("@Gestationalage3", Gestationalage3);
            cmd.Parameters.AddWithValue("@TypeofDelivery3", TypeofDelivery3);
            cmd.Parameters.AddWithValue("@Alive3", Alive3);

           // cmd.Parameters.AddWithValue("@Date4", Date4);
            if (this.Date4 == Date.getMinDate())
                cmd.Parameters.Add(new SqlParameter("@Date4", SqlDbType.DateTime)).Value = DBNull.Value;
            else
                cmd.Parameters.Add(new SqlParameter("@Date4", SqlDbType.DateTime)).Value = Date4;
            cmd.Parameters.AddWithValue("@Gestationalage4", Gestationalage4);
            cmd.Parameters.AddWithValue("@TypeofDelivery4", TypeofDelivery4);
            cmd.Parameters.AddWithValue("@Alive4", Alive4);



            cmd.Parameters.AddWithValue("@PMHHypertension", PMHHypertension);
            cmd.Parameters.AddWithValue("@PMHDiabetes", PMHDiabetes);
            cmd.Parameters.AddWithValue("@PMHSickleCellDisease", PMHSickleCellDisease);
            cmd.Parameters.AddWithValue("@PMHAsthma", PMHAsthma);
            cmd.Parameters.AddWithValue("@PMHThyroiddisease", PMHThyroiddisease);
            cmd.Parameters.AddWithValue("@PMHEpilepsy", PMHEpilepsy);
            cmd.Parameters.AddWithValue("@PMHHepatitis", PMHHepatitis);

            cmd.Parameters.AddWithValue("@PMHKidneyDisease", PMHKidneyDisease);
            cmd.Parameters.AddWithValue("@PMHHIV", PMHHIV);

            cmd.Parameters.AddWithValue("@FHHypertension", FHHypertension);
            cmd.Parameters.AddWithValue("@FHDiabetes", FHDiabetes);
            cmd.Parameters.AddWithValue("@FHSickleCellDisease", FHSickleCellDisease);
            cmd.Parameters.AddWithValue("@FHAsthma", FHAsthma);
            cmd.Parameters.AddWithValue("@FHThyroiddisease", FHThyroiddisease);
            cmd.Parameters.AddWithValue("@FHEpilepsy", FHEpilepsy);
            cmd.Parameters.AddWithValue("@FHHepatitis", FHHepatitis);
            cmd.Parameters.AddWithValue("@FHKidneyDisease", FHKidneyDisease);
            cmd.Parameters.AddWithValue("@FHHIV", FHHIV);
            

           

            cmd.Parameters.AddWithValue("@Branchid", BranchId);
            cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            cmd.Parameters.AddWithValue("@FID", FId);

            cmd.Parameters.AddWithValue("@HbResult", HbResult);
            cmd.Parameters.AddWithValue("@BloodSugarResult", BloodSugarResult);
            cmd.Parameters.AddWithValue("@VDRLResult", VDRLResult);
            cmd.Parameters.AddWithValue("@HIVResult", HIVResult);
            cmd.Parameters.AddWithValue("@SullivanTestResult", SullivanTestResult);
            cmd.Parameters.AddWithValue("@HepBResult", HepBResult);
            cmd.Parameters.AddWithValue("@SicklingTestResult", SicklingTestResult);


            object Result = cmd.ExecuteScalar();
            return Convert.ToString(Result);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
}