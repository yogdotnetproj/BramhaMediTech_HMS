using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Dental_Clinic_C
/// </summary>
public class Dental_Clinic_C
{
    DataAccess da = new DataAccess();
	public Dental_Clinic_C()
	{
       // this.P_DischargeDate = Date.getMinDate();
        this.P_EntryDate = Date.getMinDate();
        this.P_TreatementDate = Date.getMinDate();
        this.P_ARDate = Date.getMinDate();
	}
    private int Patregid;    public int P_Patregid    {        get { return Patregid; }        set { Patregid = value; }    }

    private int OpdNo;    public int P_OpdNo    {        get { return OpdNo; }        set { OpdNo = value; }    }

    private int IpdNo;    public int P_IpdNo    {        get { return IpdNo; }        set { IpdNo = value; }    }

    private DateTime EntryDate;    public DateTime P_EntryDate    {        get { return EntryDate; }        set { EntryDate = value; }    }

     private string IntraoralExamination; public string P_IntraoralExamination { get { return IntraoralExamination; } set { IntraoralExamination = value; } }
    

    private string ReferBy; public string P_ReferBy { get { return ReferBy; } set { ReferBy = value; } }
    //private string ChiefComplants;    public string P_ChiefComplants    {        get { return ChiefComplants; }        set { ChiefComplants = value; }    }
    private string Allergy;    public string P_Allergy    {        get { return Allergy; }        set { Allergy = value; }    }
    private string Pregnancy;    public string P_Pregnancy    {        get { return Pregnancy; }        set { Pregnancy = value; }    }
    private string Medication;    public string P_Medication    {        get { return Medication; }        set { Medication = value; }    }
    private string Habits;    public string P_Habits    {        get { return Habits; }        set { Habits = value; }    }
    private string PastDentalHistory;    public string P_PastDentalHistory    {        get { return PastDentalHistory; }        set { PastDentalHistory = value; }    }
    private string OtherHistory;    public string P_OtherHistory    {        get { return OtherHistory; }        set { OtherHistory = value; }    }

    private bool Hypertension;    public bool P_Hypertension    {        get { return Hypertension; }        set { Hypertension = value; }    }
    private bool Diabetes;    public bool P_Diabetes   {        get { return Diabetes; }        set { Diabetes = value; }    }
    private bool Anaemia;    public bool P_Anaemia    {        get { return Anaemia; }        set { Anaemia = value; }    }
    private bool KidneyDisease;    public bool P_KidneyDisease    {        get { return KidneyDisease; }        set { KidneyDisease = value; }    }
    private bool Asthama;    public bool P_Asthama    {        get { return Asthama; }        set { Asthama = value; }    }
    private bool Jaundice;    public bool P_Jaundice    {        get { return Jaundice; }        set { Jaundice = value; }    }

    private int Branchid;    public int P_Branchid    {        get { return Branchid; }        set { Branchid = value; }    }

    private string CreatedBy;    public string P_CreatedBy    {        get { return CreatedBy; }        set { CreatedBy = value; }    }

   
    private string TreatmentAdvised; public string P_TreatmentAdvised { get { return TreatmentAdvised; } set { TreatmentAdvised = value; } }

    private DateTime TreatementDate; public DateTime P_TreatementDate { get { return TreatementDate; } set { TreatementDate = value; } }
    private string TreatmentDone; public string P_TreatmentDone { get { return TreatmentDone; } set { TreatmentDone = value; } }
    private string NextAppointment; public string P_NextAppointment { get { return NextAppointment; } set { NextAppointment = value; } }
    private string Remarks; public string P_Remarks { get { return Remarks; } set { Remarks = value; } }

    // ----------------Opthalmology------------------
    private string ChiefComplaints; public string P_ChiefComplaints { get { return ChiefComplaints; } set { ChiefComplaints = value; } }
    private string OcularHistory; public string P_OcularHistory { get { return OcularHistory; } set { OcularHistory = value; } }
   
    private string Allergies; public string P_Allergies { get { return Allergies; } set { Allergies = value; } }
    private string FamilyHistory; public string P_FamilyHistory { get { return FamilyHistory; } set { FamilyHistory = value; } }
    private string TreatmentHistory; public string P_TreatmentHistory { get { return TreatmentHistory; } set { TreatmentHistory = value; } }

    private bool NIL; public bool P_NIL { get { return NIL; } set { NIL = value; } }
    private bool DM; public bool P_DM { get { return DM; } set { DM = value; } }
    private bool HTN; public bool P_HTN { get { return HTN; } set { HTN = value; } }
    private bool CAD; public bool P_CAD { get { return CAD; } set { CAD = value; } }
    private bool Thyroid; public bool P_Thyroid { get { return Thyroid; } set { Thyroid = value; } }
    private bool IS_Pregnancy; public bool P_IS_Pregnancy { get { return IS_Pregnancy; } set { IS_Pregnancy = value; } }
    private bool HIV; public bool P_HIV { get { return HIV; } set { HIV = value; } }
    private bool HBsAG; public bool P_HBsAG { get { return HBsAG; } set { HBsAG = value; } }
   // private bool Asthama; public bool P_Asthama { get { return Asthama; } set { Asthama = value; } }
    private bool HTN_Family; public bool P_HTN_Family { get { return HTN_Family; } set { HTN_Family = value; } }
    private bool DMGlaucoma; public bool P_DMGlaucoma { get { return DMGlaucoma; } set { DMGlaucoma = value; } }
    private bool CongCataract; public bool P_CongCataract { get { return CongCataract; } set { CongCataract = value; } }
    private bool RP; public bool P_RP { get { return RP; } set { RP = value; } }
    private bool Glaucoma; public bool P_Glaucoma { get { return Glaucoma; } set { Glaucoma = value; } }
    private string Dilated; public string P_Dilated { get { return Dilated; } set { Dilated = value; } }
    private string DocumentFileName; public string P_DocumentFileName { get { return DocumentFileName; } set { DocumentFileName = value; } }
    private string DocumentFilePath; public string P_DocumentFilePath { get { return DocumentFilePath; } set { DocumentFilePath = value; } }
    //----------------------------

   
    private string OORSPH; public string P_OORSPH { get { return OORSPH; } set { OORSPH = value; } }
    private string OORCYL; public string P_OORCYL { get { return OORCYL; } set { OORCYL = value; } }
    private string OORAXIS; public string P_OORAXIS { get { return OORAXIS; } set { OORAXIS = value; } }
    private string OORemark; public string P_OORemark { get { return OORemark; } set { OORemark = value; } }
    private string OOLSPH; public string P_OOLSPH { get { return OOLSPH; } set { OOLSPH = value; } }
    private string OOLCYL; public string P_OOLCYL { get { return OOLCYL; } set { OOLCYL = value; } }
    private string OOLAXIS; public string P_OOLAXIS { get { return OOLAXIS; } set { OOLAXIS = value; } }

    private string UNRSPH; public string P_UNRSPH { get { return UNRSPH; } set { UNRSPH = value; } }
    private string UNRCYL; public string P_UNRCYL { get { return UNRCYL; } set { UNRCYL = value; } }
    private string UNRAXIS; public string P_UNRAXIS { get { return UNRAXIS; } set { UNRAXIS = value; } }
    private string UNRVA; public string P_UNRVA { get { return UNRVA; } set { UNRVA = value; } }
    private string UNRAdd; public string P_UNRAdd { get { return UNRAdd; } set { UNRAdd = value; } }

    private string UNLSPH; public string P_UNLSPH { get { return UNLSPH; } set { UNLSPH = value; } }
    private string UNLCYL; public string P_UNLCYL { get { return UNLCYL; } set { UNLCYL = value; } }
    private string UNLAXIS; public string P_UNLAXIS { get { return UNLAXIS; } set { UNLAXIS = value; } }
    private string UNLVA; public string P_UNLVA { get { return UNLVA; } set { UNLVA = value; } }
    private string UNLAdd; public string P_UNLAdd { get { return UNLAdd; } set { UNLAdd = value; } }

    private string MedicationUsed; public string P_MedicationUsed { get { return MedicationUsed; } set { MedicationUsed = value; } }
    private string RetnoscopyWorking; public string P_RetnoscopyWorking { get { return RetnoscopyWorking; } set { RetnoscopyWorking = value; } }

    private string DiaRSPH; public string P_DiaRSPH { get { return DiaRSPH; } set { DiaRSPH = value; } }
    private string DiaRCYL; public string P_DiaRCYL { get { return DiaRCYL; } set { DiaRCYL = value; } }
    private string DiaRAXIS; public string P_DiaRAXIS { get { return DiaRAXIS; } set { DiaRAXIS = value; } }
    private string DiaLSPH; public string P_DiaLSPH { get { return DiaLSPH; } set { DiaLSPH = value; } }
    private string DiaLCYL; public string P_DiaLCYL { get { return DiaLCYL; } set { DiaLCYL = value; } }
    private string DiaLAXIS; public string P_DiaLAXIS { get { return DiaLAXIS; } set { DiaLAXIS = value; } }

    private string DiaRRSPH; public string P_DiaRRSPH { get { return DiaRRSPH; } set { DiaRRSPH = value; } }
    private string DiaRRCYL; public string P_DiaRRCYL { get { return DiaRRCYL; } set { DiaRRCYL = value; } }
    private string DiaRRAXIS; public string P_DiaRRAXIS { get { return DiaRRAXIS; } set { DiaRRAXIS = value; } }
    private string DiaRLSPH; public string P_DiaRLSPH { get { return DiaRLSPH; } set { DiaRLSPH = value; } }
    private string DiaRLCYL; public string P_DiaRLCYL { get { return DiaRLCYL; } set { DiaRLCYL = value; } }
    private string DiaRLAXIS; public string P_DiaRLAXIS { get { return DiaRLAXIS; } set { DiaRLAXIS = value; } }

    private string FPRSPH; public string P_FPRSPH { get { return FPRSPH; } set { FPRSPH = value; } }
    private string FPRCYL; public string P_FPRCYL { get { return FPRCYL; } set { FPRCYL = value; } }
    private string FPRAXIS; public string P_FPRAXIS { get { return FPRAXIS; } set { FPRAXIS = value; } }
    private string FPRVA; public string P_FPRVA { get { return FPRVA; } set { FPRVA = value; } }
    private string FPRAdd; public string P_FPRAdd { get { return FPRAdd; } set { FPRAdd = value; } }

    private string FPLSPH; public string P_FPLSPH { get { return FPLSPH; } set { FPLSPH = value; } }
    private string FPLCYL; public string P_FPLCYL { get { return FPLCYL; } set { FPLCYL = value; } }
    private string FPLAXIS; public string P_FPLAXIS { get { return FPLAXIS; } set { FPLAXIS = value; } }
    private string FPLVA; public string P_FPLVA { get { return FPLVA; } set { FPLVA = value; } }
    private string FPLAdd; public string P_FPLAdd { get { return FPLAdd; } set { FPLAdd = value; } }

    private string OPRSPH; public string P_OPRSPH { get { return OPRSPH; } set { OPRSPH = value; } }
    private string OPRCYL; public string P_OPRCYL { get { return OPRCYL; } set { OPRCYL = value; } }
    private string OPRAXIS; public string P_OPRAXIS { get { return OPRAXIS; } set { OPRAXIS = value; } }
   
    private string OPLSPH; public string P_OPLSPH { get { return OPLSPH; } set {OPLSPH = value; } }
    private string OPLCYL; public string P_OPLCYL { get { return OPLCYL; } set { OPLCYL = value; } }
    private string OPLAXIS; public string P_OPLAXIS { get { return OPLAXIS; } set { OPLAXIS = value; } }

    private string UNOOAD; public string P_UNOOAD { get { return UNOOAD; } set { UNOOAD = value; } }

    private string UNADOD; public string P_UNADOD { get { return UNADOD; } set { UNADOD = value; } }
    private string UNADOD1; public string P_UNADOD1 { get { return UNADOD1; } set { UNADOD1 = value; } }

    private string UNANOD; public string P_UNANOD { get { return UNANOD; } set { UNANOD = value; } }
    private string UNANOD1; public string P_UNANOD1 { get { return UNANOD1; } set { UNANOD1 = value; } }

    private string WGOD; public string P_WGOD { get { return WGOD; } set { WGOD = value; } }
    private string WGOD1; public string P_WGOD1 { get { return WGOD1; } set { WGOD1 = value; } }
    private string WGNOD; public string P_WGNOD { get { return WGNOD; } set { WGNOD = value; } }
    private string WGNOD1; public string P_WGNOD1 { get { return WGNOD1; } set { WGNOD1 = value; } }

    private string WPDOD; public string P_WPDOD { get { return WPDOD; } set { WPDOD = value; } }
    private string WPDOD1; public string P_WPDOD1 { get { return WPDOD1; } set { WPDOD1 = value; } }
    private string WPNOD; public string P_WPNOD { get { return WPNOD; } set { WPNOD = value; } }
    private string WPNOD1; public string P_WPNOD1 { get { return WPNOD1; } set { WPNOD1 = value; } }

    private string BCDOD; public string P_BCDOD { get { return BCDOD; } set { BCDOD = value; } }
    private string BCDOD1; public string P_BCDOD1 { get { return BCDOD1; } set { BCDOD1 = value; } }
    private string BCNOD; public string P_BCNOD { get { return BCNOD; } set { BCNOD = value; } }
    private string BCNOD1; public string P_BCNOD1 { get { return BCNOD1; } set { BCNOD1 = value; } }

    private string RefractiveNotes; public string P_RefractiveNotes { get { return RefractiveNotes; } set { RefractiveNotes = value; } }
    private string IOP; public string P_IOP { get { return IOP; } set { IOP = value; } }
    private string AntiglucinMedication; public string P_AntiglucinMedication { get { return AntiglucinMedication; } set { AntiglucinMedication = value; } }

    private string REMin1; public string P_REMin1 { get { return REMin1; } set { REMin1 = value; } }
    private string REMin2; public string P_REMin2 { get { return REMin2; } set { REMin2 = value; } }
    private string REMin3; public string P_REMin3 { get { return REMin3; } set { REMin3 = value; } }
    private string REMin4; public string P_REMin4 { get { return REMin4; } set { REMin4 = value; } }

    private string LEMin1; public string P_LEMin1 { get { return LEMin1; } set { LEMin1 = value; } }
    private string LEMin2; public string P_LEMin2 { get { return LEMin2; } set { LEMin2 = value; } }
    private string LEMin3; public string P_LEMin3 { get { return LEMin3; } set { LEMin3 = value; } }
    private string LEMin4; public string P_LEMin4 { get { return LEMin4; } set { LEMin4 = value; } }

    //============================================= Opthalmology Clinic =====================================

    //========================================= Face Examination =============================================

    private string OcularOD; public string P_OcularOD { get { return OcularOD; } set { OcularOD = value; } }
    private string OcularOS; public string P_OcularOS { get { return OcularOS; } set { OcularOS = value; } }
    private string LidsOD; public string P_LidsOD { get { return LidsOD; } set { LidsOD = value; } }
    private string LidsOS; public string P_LidsOS { get { return LidsOS; } set { LidsOS = value; } }

    private string NasolacrinalOD; public string P_NasolacrinalOD { get { return NasolacrinalOD; } set { NasolacrinalOD = value; } }
    private string NasolacrinalOS; public string P_NasolacrinalOS { get { return NasolacrinalOS; } set { NasolacrinalOS = value; } }
    private string SyringingOD; public string P_SyringingOD { get { return SyringingOD; } set { SyringingOD = value; } }
    private string SyringingOS; public string P_SyringingOS { get { return SyringingOS; } set { SyringingOS = value; } }

    private string CenjunctivaOD; public string P_CenjunctivaOD { get { return CenjunctivaOD; } set { CenjunctivaOD = value; } }
    private string CenjunctivaOS; public string P_CenjunctivaOS { get { return CenjunctivaOS; } set { CenjunctivaOS = value; } }
    private string CorneaOD; public string P_CorneaOD { get { return CorneaOD; } set { CorneaOD = value; } }
    private string CorneaOS; public string P_CorneaOS { get { return CorneaOS; } set { CorneaOS = value; } }

    private string IrisOD; public string P_IrisOD { get { return IrisOD; } set { IrisOD = value; } }
    private string IrisOS; public string P_IrisOS { get { return IrisOS; } set { IrisOS = value; } }
    private string PupilOD; public string P_PupilOD { get { return PupilOD; } set { PupilOD = value; } }
    private string PupilOS; public string P_PupilOS { get { return PupilOS; } set { PupilOS = value; } }

    private string LensOD; public string P_LensOD { get { return LensOD; } set { LensOD = value; } }
    private string LensOS; public string P_LensOS { get { return LensOS; } set { LensOS = value; } }
    private string VitreousOD; public string P_VitreousOD { get { return VitreousOD; } set { VitreousOD = value; } }
    private string VitreousOS; public string P_VitreousOS { get { return VitreousOS; } set { VitreousOS = value; } }

    private string OptisDiscOD; public string P_OptisDiscOD { get { return OptisDiscOD; } set { OptisDiscOD = value; } }
    private string OptisDiscOS; public string P_OptisDiscOS { get { return OptisDiscOS; } set { OptisDiscOS = value; } }
    private string COROD; public string P_COROD { get { return COROD; } set { COROD = value; } }
    private string COROS; public string P_COROS { get { return COROS; } set { COROS = value; } }

    private string FUNDUSOD; public string P_FUNDUSOD { get { return FUNDUSOD; } set { FUNDUSOD = value; } }
    private string FUNDUSOS; public string P_FUNDUSOS { get { return FUNDUSOS; } set { FUNDUSOS = value; } }
    private string VESSELSOD; public string P_VESSELSOD { get { return VESSELSOD; } set { VESSELSOD = value; } }
    private string VESSELSOS; public string P_VESSELSOS { get { return VESSELSOS; } set { VESSELSOS = value; } }


    private string MACULAOD; public string P_MACULAOD { get { return MACULAOD; } set { MACULAOD = value; } }
    private string MACULAOS; public string P_MACULAOS { get { return MACULAOS; } set { MACULAOS = value; } }
    private string PERIPHERYOD; public string P_PERIPHERYOD { get { return PERIPHERYOD; } set { PERIPHERYOD = value; } }
    private string PERIPHERYOS; public string P_PERIPHERYOS { get { return PERIPHERYOS; } set { PERIPHERYOS = value; } }

   // private string Diagnosis; public string P_Diagnosis { get { return Diagnosis; } set { Diagnosis = value; } }
    private string Plans; public string P_Plans { get { return Plans; } set { Plans = value; } }
    private string Discussion; public string P_Discussion { get { return Discussion; } set { Discussion = value; } }
    private string Treatment; public string P_Treatment { get { return Treatment; } set { Treatment = value; } }

    private string GonioscopyOD; public string P_GonioscopyOD { get { return GonioscopyOD; } set { GonioscopyOD = value; } }
    private string GonioscopyOS; public string P_GonioscopyOS { get { return GonioscopyOS; } set { GonioscopyOS = value; } }
    private string PanchyneteryOD; public string P_PanchyneteryOD { get { return PanchyneteryOD; } set { PanchyneteryOD = value; } }
    private string PanchyneteryOS; public string P_PanchyneteryOS { get { return PanchyneteryOS; } set { PanchyneteryOS = value; } }

    private string IOPCorrectionOD; public string P_IOPCorrectionOD { get { return IOPCorrectionOD; } set { IOPCorrectionOD = value; } }
    private string IOPCorrectionOS; public string P_IOPCorrectionOS { get { return IOPCorrectionOS; } set { IOPCorrectionOS = value; } }
    private string TopographyOD; public string P_TopographyOD { get { return TopographyOD; } set { TopographyOD = value; } }
    private string TopographyOS; public string P_TopographyOS { get { return TopographyOS; } set { TopographyOS = value; } }

    private string IOLMasterOD; public string P_IOLMasterOD { get { return IOLMasterOD; } set { IOLMasterOD = value; } }
    private string IOLMasterOS; public string P_IOLMasterOS { get { return IOLMasterOS; } set { IOLMasterOS = value; } }
    private string KINAXOD; public string P_KINAXOD { get { return KINAXOD; } set { KINAXOD = value; } }
    private string KINAXOS; public string P_KINAXOS { get { return KINAXOS; } set { KINAXOS = value; } }

    private string KININOD; public string P_KININOD { get { return KININOD; } set { KININOD = value; } }
    private string KININOS; public string P_KININOS { get { return KININOS; } set { KININOS = value; } }
    private string AXILLengthOD; public string P_AXILLengthOD { get { return AXILLengthOD; } set { AXILLengthOD = value; } }
    private string AXILLengthOS; public string P_AXILLengthOS { get { return AXILLengthOS; } set { AXILLengthOS = value; } }


  //  private string LEMin1; public string P_LEMin1 { get { return LEMin1; } set { LEMin1 = value; } }
    //--------------------New Opthalmology -----------------
    private DateTime ARDate; public DateTime P_ARDate { get { return ARDate; } set { ARDate = value; } }
    private string DrName; public string P_DrName { get { return DrName; } set { DrName = value; } }
    private string Diagnosis; public string P_Diagnosis { get { return Diagnosis; } set { Diagnosis = value; } }
    private string ChiefComplants; public string P_ChiefComplants { get { return ChiefComplants; } set { ChiefComplants = value; } }
    private string PastHistory; public string P_PastHistory { get { return PastHistory; } set { PastHistory = value; } }
    private string ClinicalNote; public string P_ClinicalNote { get { return ClinicalNote; } set { ClinicalNote = value; } }
    private string CurrentMedication; public string P_CurrentMedication { get { return CurrentMedication; } set { CurrentMedication = value; } }
    private string AllergyN; public string P_AllergyN { get { return AllergyN; } set { AllergyN = value; } }

    private string UnaidedODD; public string P_UnaidedODD { get { return UnaidedODD; } set { UnaidedODD = value; } }
    private string UnaidedOSD; public string P_UnaidedOSD { get { return UnaidedOSD; } set { UnaidedOSD = value; } }
    private string UnaidedODN; public string P_UnaidedODN { get { return UnaidedODN; } set { UnaidedODN = value; } }
    private string UnaidedOSN; public string P_UnaidedOSN { get { return UnaidedOSN; } set { UnaidedOSN = value; } }
    private string PinholeOD; public string P_PinholeOD { get { return PinholeOD; } set { PinholeOD = value; } }
    private string PinholeOS; public string P_PinholeOS { get { return PinholeOS; } set { PinholeOS = value; } }

    private string SpectaclesODD; public string P_SpectaclesODD { get { return SpectaclesODD; } set { SpectaclesODD = value; } }
    private string SpectaclesOSD; public string P_SpectaclesOSD { get { return SpectaclesOSD; } set { SpectaclesOSD = value; } }
    private string SpectaclesODN; public string P_SpectaclesODN { get { return SpectaclesODN; } set { SpectaclesODN = value; } }
    private string SpectaclesOSN; public string P_SpectaclesOSN { get { return SpectaclesOSN; } set { SpectaclesOSN = value; } }

    private string IOPOD; public string P_IOPOD { get { return IOPOD; } set { IOPOD = value; } }
    private string IOPOS; public string P_IOPOS { get { return IOPOS; } set { IOPOS = value; } }
    private string NPC; public string P_NPC { get { return NPC; } set { NPC = value; } }
    private string PachymetryOD; public string P_PachymetryOD { get { return PachymetryOD; } set { PachymetryOD = value; } }
    private string PachymetryOS; public string P_PachymetryOS { get { return PachymetryOS; } set { PachymetryOS = value; } }

    private string R1RMM; public string P_R1RMM { get { return R1RMM; } set { R1RMM = value; } }
    private string R1RD; public string P_R1RD { get { return R1RD; } set { R1RD = value; } }
    private string R1RDeg; public string P_R1RDeg { get { return R1RDeg; } set { R1RDeg = value; } }
    private string R1LMM; public string P_R1LMM { get { return R1LMM; } set { R1LMM = value; } }
    private string R1LD; public string P_R1LD { get { return R1LD; } set { R1LD = value; } }
    private string R1LDeg; public string P_R1LDeg { get { return R1LDeg; } set { R1LDeg = value; } }
    private string R2RMM; public string P_R2RMM { get { return R2RMM; } set { R2RMM = value; } }
    private string R2RD; public string P_R2RD { get { return R2RD; } set { R2RD = value; } }
    private string R2RDeg; public string P_R2RDeg { get { return R2RDeg; } set { R2RDeg = value; } }
    private string R2LMM; public string P_R2LMM { get { return R2LMM; } set { R2LMM = value; } }
    private string R2LD; public string P_R2LD { get { return R2LD; } set { R2LD = value; } }
    private string R2LDeg; public string P_R2LDeg { get { return R2LDeg; } set { R2LDeg = value; } }

    private string AVGRMM; public string P_AVGRMM { get { return AVGRMM; } set { AVGRMM = value; } }
    private string AVGRD; public string P_AVGRD { get { return AVGRD; } set { AVGRD = value; } }
    private string AVGRDeg; public string P_AVGRDeg { get { return AVGRDeg; } set { AVGRDeg = value; } }
    private string AVGLMM; public string P_AVGLMM { get { return AVGLMM; } set { AVGLMM = value; } }
    private string AVGLD; public string P_AVGLD { get { return AVGLD; } set { AVGLD = value; } }
    private string AVGLDeg; public string P_AVGLDeg { get { return AVGLDeg; } set { AVGLDeg = value; } }

    private string CYLRMM; public string P_CYLRMM { get { return CYLRMM; } set { CYLRMM = value; } }
    private string CYLRD; public string P_CYLRD { get { return CYLRD; } set { CYLRD = value; } }
    private string CYLRDeg; public string P_CYLRDeg { get { return CYLRDeg; } set { CYLRDeg = value; } }
    private string CYLLMM; public string P_CYLLMM { get { return CYLLMM; } set { CYLLMM = value; } }
    private string CYLLD; public string P_CYLLD { get { return CYLLD; } set { CYLLD = value; } }
    private string CYLLDeg; public string P_CYLLDeg { get { return CYLLDeg; } set { CYLLDeg = value; } }

    private string PD; public string P_PD { get { return PD; } set { PD = value; } }
    private string Keratometry_N; public string P_Keratometry_N { get { return Keratometry_N; } set { Keratometry_N = value; } }



    private string ColorOD; public string P_ColorOD { get { return ColorOD; } set { ColorOD = value; } }
    private string ColorOS; public string P_ColorOS { get { return ColorOS; } set { ColorOS = value; } }
    private string CoverTest; public string P_CoverTest { get { return CoverTest; } set { CoverTest = value; } }

    private string AxialOD; public string P_AxialOD { get { return AxialOD; } set { AxialOD = value; } }
    private string AxialOS; public string P_AxialOS { get { return AxialOS; } set { AxialOS = value; } }
    private string AConstantOD; public string P_AConstantOD { get { return AConstantOD; } set { AConstantOD = value; } }
    private string AConstantOS; public string P_AConstantOS { get { return AConstantOS; } set { AConstantOS = value; } }
    private string IOLOD; public string P_IOLOD { get { return IOLOD; } set { IOLOD = value; } }
    private string IOLOS; public string P_IOLOS { get { return IOLOS; } set { IOLOS = value; } }
    private string PredictiveOD; public string P_PredictiveOD { get { return PredictiveOD; } set { PredictiveOD = value; } }
    private string PredictiveOS; public string P_PredictiveOS { get { return PredictiveOS; } set { PredictiveOS = value; } }

    private string SPHCSPR; public string P_SPHCSPR { get { return SPHCSPR; } set { SPHCSPR = value; } }
    private string CYLCSPR; public string P_CYLCSPR { get { return CYLCSPR; } set { CYLCSPR = value; } }
    private string AXISCSPR; public string P_AXISCSPR { get { return AXISCSPR; } set { AXISCSPR = value; } }
    private string SPHCSPL; public string P_SPHCSPL { get { return SPHCSPL; } set { SPHCSPL = value; } }
    private string CYLCSPL; public string P_CYLCSPL { get { return CYLCSPL; } set { CYLCSPL = value; } }
    private string AXISCSPL; public string P_AXISCSPL { get { return AXISCSPL; } set { AXISCSPL = value; } }
    private string ADDCSP; public string P_ADDCSP { get { return ADDCSP; } set { ADDCSP = value; } }

    private string SPHAutoR; public string P_SPHAutoR { get { return SPHAutoR; } set { SPHAutoR = value; } }
    private string CYLAutoR; public string P_CYLAutoR { get { return CYLAutoR; } set { CYLAutoR = value; } }
    private string AXISAutoR; public string P_AXISAutoR { get { return AXISAutoR; } set { AXISAutoR = value; } }
    private string SPHAutoL; public string P_SPHAutoL { get { return SPHAutoL; } set { SPHAutoL = value; } }
    private string CYLAutoL; public string P_CYLAutoL { get { return CYLAutoL; } set { CYLAutoL = value; } }
    private string AXISAutoL; public string P_AXISAutoL { get { return AXISAutoL; } set { AXISAutoL = value; } }

    private string SPHMRR; public string P_SPHMRR { get { return SPHMRR; } set { SPHMRR = value; } }
    private string CYLMRR; public string P_CYLMRR { get { return CYLMRR; } set { CYLMRR = value; } }
    private string AXISMRR; public string P_AXISMRR { get { return AXISMRR; } set { AXISMRR = value; } }
    private string VAMRR; public string P_VAMRR { get { return VAMRR; } set { VAMRR = value; } }
    private string SPHMRL; public string P_SPHMRL { get { return SPHMRL; } set { SPHMRL = value; } }
    private string CYLMRL; public string P_CYLMRL { get { return CYLMRL; } set { CYLMRL = value; } }
    private string AXISMRL; public string P_AXISMRL { get { return AXISMRL; } set { AXISMRL = value; } }
    private string VAMRL; public string P_VAMRL { get { return VAMRL; } set { VAMRL = value; } }
    private string ADDMRL; public string P_ADDMRL { get { return ADDMRL; } set { ADDMRL = value; } }
    private string ODMRL; public string P_ODMRL { get { return ODMRL; } set { ODMRL = value; } }
    private string OSMRL; public string P_OSMRL { get { return OSMRL; } set { OSMRL = value; } }

    private string SPHCRR; public string P_SPHCRR { get { return SPHCRR; } set { SPHCRR = value; } }
    private string CYLCRR; public string P_CYLCRR { get { return CYLCRR; } set { CYLCRR = value; } }
    private string AXISCRR; public string P_AXISCRR { get { return AXISCRR; } set { AXISCRR = value; } }
    private string SPHCRL; public string P_SPHCRL { get { return SPHCRL; } set { SPHCRL = value; } }
    private string CYLCRL; public string P_CYLCRL { get { return CYLCRL; } set { CYLCRL = value; } }
    private string AXISCRL; public string P_AXISCRL { get { return AXISCRL; } set { AXISCRL = value; } }
    private string ADDCRL; public string P_ADDCRL { get { return ADDCRL; } set { ADDCRL = value; } }
    private string MedicationUsedN; public string P_MedicationUsedN { get { return MedicationUsedN; } set { MedicationUsedN = value; } }
    private string Retinoscopy; public string P_Retinoscopy { get { return Retinoscopy; } set { Retinoscopy = value; } }

    private string ADNEXAODR; public string P_ADNEXAODR { get { return ADNEXAODR; } set { ADNEXAODR = value; } }
    private string ADNEXAODL; public string P_ADNEXAODL { get { return ADNEXAODL; } set { ADNEXAODL = value; } }
    private string ANTERIORODR; public string P_ANTERIORODR { get { return ANTERIORODR; } set { ANTERIORODR = value; } }
    private string ANTERIORODL; public string P_ANTERIORODL { get { return ANTERIORODL; } set { ANTERIORODL = value; } }
    private string POSTERIORODR; public string P_POSTERIORODR { get { return POSTERIORODR; } set { POSTERIORODR = value; } }
    private string POSTERIORODL; public string P_POSTERIORODL { get { return POSTERIORODL; } set { POSTERIORODL = value; } }
    private string MaculaDilated; public string P_MaculaDilated { get { return MaculaDilated; } set { MaculaDilated = value; } }

    private string DIAGNOSISOptha; public string P_DIAGNOSISOptha { get { return DIAGNOSISOptha; } set { DIAGNOSISOptha = value; } }
    private string MANAGEMENT; public string P_MANAGEMENT { get { return MANAGEMENT; } set { MANAGEMENT = value; } }
    private string INVESTIGATIONS; public string P_INVESTIGATIONS { get { return INVESTIGATIONS; } set { INVESTIGATIONS = value; } }
    private string PROCEDURESS; public string P_PROCEDURESS { get { return PROCEDURESS; } set { PROCEDURESS = value; } }














    
    public void Insert_IntraoralExamination()
    {

        SqlConnection conn = DataAccess.ConInitForDC();
        SqlCommand sc = new SqlCommand();
        sc.CommandType = CommandType.StoredProcedure;
        sc.Connection = conn;
        sc.CommandText = "USp_Insert_Dental_IntraoralExamination";
        sc.Parameters.Add(new SqlParameter("@Patregid", SqlDbType.Int)).Value = P_Patregid;
        sc.Parameters.Add(new SqlParameter("@OPDNo", SqlDbType.Int)).Value = P_OpdNo;
        sc.Parameters.Add(new SqlParameter("@IPDNo", SqlDbType.Int)).Value = P_IpdNo;
        sc.Parameters.Add(new SqlParameter("@ReferBy", SqlDbType.NVarChar, 500)).Value = P_ReferBy;
        sc.Parameters.Add(new SqlParameter("@IntraoralExamination", SqlDbType.NVarChar, 500)).Value = P_IntraoralExamination;


        if (this.P_EntryDate == Date.getMinDate())
            sc.Parameters.Add(new SqlParameter("@EntryDate", SqlDbType.DateTime)).Value = DBNull.Value;
        else
            sc.Parameters.Add(new SqlParameter("@EntryDate", SqlDbType.DateTime)).Value = P_EntryDate;
       
        sc.Parameters.Add(new SqlParameter("@CreatedBy", SqlDbType.NVarChar, 250)).Value = P_CreatedBy;
       
        sc.Parameters.Add(new SqlParameter("@Branchid", SqlDbType.Int)).Value = P_Branchid;



        try
        {
            conn.Open();
            sc.ExecuteNonQuery();
        }
        catch (SqlException)
        {
            throw;
        }
        finally
        {
            conn.Close(); conn.Dispose();
        }
    }

    public void Insert_DentalClinicHistory()
    {

        SqlConnection conn = DataAccess.ConInitForDC();
        SqlCommand sc = new SqlCommand();
        sc.CommandType = CommandType.StoredProcedure;
        sc.Connection = conn;
        sc.CommandText = "SP_Dental_Clinic_History";
        sc.Parameters.Add(new SqlParameter("@Patregid", SqlDbType.Int)).Value = P_Patregid;
        sc.Parameters.Add(new SqlParameter("@OPDNo", SqlDbType.Int)).Value = P_OpdNo;
        sc.Parameters.Add(new SqlParameter("@IPDNo", SqlDbType.Int)).Value = P_IpdNo;
        sc.Parameters.Add(new SqlParameter("@ReferBy", SqlDbType.NVarChar, 500)).Value = P_ReferBy;
        sc.Parameters.Add(new SqlParameter("@ChiefComplants", SqlDbType.NVarChar, 500)).Value = P_ChiefComplants;
        
        
        if (this.P_EntryDate == Date.getMinDate())
            sc.Parameters.Add(new SqlParameter("@EntryDate", SqlDbType.DateTime)).Value = DBNull.Value;
        else
            sc.Parameters.Add(new SqlParameter("@EntryDate", SqlDbType.DateTime)).Value = P_EntryDate;
        sc.Parameters.Add(new SqlParameter("@Allergy", SqlDbType.NVarChar, 2500)).Value = P_Allergy;

        sc.Parameters.Add(new SqlParameter("@Pregnancy", SqlDbType.NVarChar, 2500)).Value = P_Pregnancy;
        sc.Parameters.Add(new SqlParameter("@Medication", SqlDbType.NVarChar, 3000)).Value = P_Medication;
        sc.Parameters.Add(new SqlParameter("@Habits", SqlDbType.NVarChar, 4000)).Value = P_Habits;
        sc.Parameters.Add(new SqlParameter("@CreatedBy", SqlDbType.NVarChar, 250)).Value = P_CreatedBy;
        sc.Parameters.Add(new SqlParameter("@PastDentalHistory", SqlDbType.NVarChar, 3550)).Value = P_PastDentalHistory;

        sc.Parameters.Add(new SqlParameter("@OtherHistory", SqlDbType.NVarChar, 3550)).Value = P_OtherHistory;
        sc.Parameters.Add(new SqlParameter("@Hypertension", SqlDbType.Bit)).Value = P_Hypertension;
        sc.Parameters.Add(new SqlParameter("@Diabetes", SqlDbType.Bit)).Value = P_Diabetes;
        sc.Parameters.Add(new SqlParameter("@Anaemia", SqlDbType.Bit)).Value = P_Anaemia;
        sc.Parameters.Add(new SqlParameter("@KidneyDisease", SqlDbType.Bit)).Value = P_KidneyDisease;
        sc.Parameters.Add(new SqlParameter("@Asthama", SqlDbType.Bit)).Value = P_Asthama;
        sc.Parameters.Add(new SqlParameter("@Jaundice", SqlDbType.Bit)).Value = P_Jaundice;
        sc.Parameters.Add(new SqlParameter("@Branchid", SqlDbType.Int)).Value = P_Branchid;



        try
        {
            conn.Open();
            sc.ExecuteNonQuery();
        }
        catch (SqlException)
        {
            throw;
        }
        finally
        {
            conn.Close(); conn.Dispose();
        }
    }

    public void Insert_DentalDiagnosis_Treatment()
    {

        SqlConnection conn = DataAccess.ConInitForDC();
        SqlCommand sc = new SqlCommand();
        sc.CommandType = CommandType.StoredProcedure;
        sc.Connection = conn;
        sc.CommandText = "SP_InsertDental_Diagnosis_Treatment";
        sc.Parameters.Add(new SqlParameter("@Patregid", SqlDbType.Int)).Value = P_Patregid;
        sc.Parameters.Add(new SqlParameter("@OPDNo", SqlDbType.Int)).Value = P_OpdNo;
        sc.Parameters.Add(new SqlParameter("@IPDNo", SqlDbType.Int)).Value = P_IpdNo;
        sc.Parameters.Add(new SqlParameter("@ReferBy", SqlDbType.NVarChar, 500)).Value = P_ReferBy;
      
        if (this.P_EntryDate == Date.getMinDate())
            sc.Parameters.Add(new SqlParameter("@EntryDate", SqlDbType.DateTime)).Value = DBNull.Value;
        else
            sc.Parameters.Add(new SqlParameter("@EntryDate", SqlDbType.DateTime)).Value = P_EntryDate;

        sc.Parameters.Add(new SqlParameter("@Diagnosis", SqlDbType.NVarChar, 2500)).Value = P_Diagnosis;

        sc.Parameters.Add(new SqlParameter("@TreatmentAdvised", SqlDbType.NVarChar, 2500)).Value = P_TreatmentAdvised;
      
        sc.Parameters.Add(new SqlParameter("@CreatedBy", SqlDbType.NVarChar, 250)).Value = P_CreatedBy;      
        sc.Parameters.Add(new SqlParameter("@Branchid", SqlDbType.Int)).Value = P_Branchid;



        try
        {
            conn.Open();
            sc.ExecuteNonQuery();
        }
        catch (SqlException)
        {
            throw;
        }
        finally
        {
            conn.Close(); conn.Dispose();
        }
    }

    public void Insert_DentalTreatment_Details()
    {

        SqlConnection conn = DataAccess.ConInitForDC();
        SqlCommand sc = new SqlCommand();
        sc.CommandType = CommandType.StoredProcedure;
        sc.Connection = conn;
        sc.CommandText = "SP_InsertDental_Treatment_Details";
        sc.Parameters.Add(new SqlParameter("@Patregid", SqlDbType.Int)).Value = P_Patregid;
        sc.Parameters.Add(new SqlParameter("@OPDNo", SqlDbType.Int)).Value = P_OpdNo;
        sc.Parameters.Add(new SqlParameter("@IPDNo", SqlDbType.Int)).Value = P_IpdNo;
        sc.Parameters.Add(new SqlParameter("@ReferBy", SqlDbType.NVarChar, 500)).Value = P_ReferBy;

        if (this.P_EntryDate == Date.getMinDate())
            sc.Parameters.Add(new SqlParameter("@EntryDate", SqlDbType.DateTime)).Value = DBNull.Value;
        else
            sc.Parameters.Add(new SqlParameter("@EntryDate", SqlDbType.DateTime)).Value = P_EntryDate;

        if (this.P_TreatementDate == Date.getMinDate())
            sc.Parameters.Add(new SqlParameter("@TreatementDate", SqlDbType.DateTime)).Value = DBNull.Value;
        else
            sc.Parameters.Add(new SqlParameter("@TreatementDate", SqlDbType.DateTime)).Value = P_TreatementDate;

        sc.Parameters.Add(new SqlParameter("@TreatmentDone", SqlDbType.NVarChar, 2500)).Value = P_TreatmentDone;

        sc.Parameters.Add(new SqlParameter("@NextAppointment", SqlDbType.NVarChar, 2500)).Value = P_NextAppointment;
        sc.Parameters.Add(new SqlParameter("@Remarks", SqlDbType.NVarChar, 2500)).Value = P_Remarks;

        sc.Parameters.Add(new SqlParameter("@CreatedBy", SqlDbType.NVarChar, 250)).Value = P_CreatedBy;
        sc.Parameters.Add(new SqlParameter("@Branchid", SqlDbType.Int)).Value = P_Branchid;



        try
        {
            conn.Open();
            sc.ExecuteNonQuery();
        }
        catch (SqlException)
        {
            throw;
        }
        finally
        {
            conn.Close(); conn.Dispose();
        }
    }

    public void Alter_Dental_ClinicalHistory_Report(int patregid, int OpdNo, int IpdNo)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Alter_Vw_Dental_Clinic_History_Report", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@PatregId", patregid);
            cmd.Parameters.AddWithValue("@OpdNo", OpdNo);
            cmd.Parameters.AddWithValue("@IpdNo", IpdNo);

            cmd.ExecuteNonQuery();



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

    public void Alter_Dental_Diagnosis_Treatment_Report(int patregid, int OpdNo, int IpdNo)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Alter_Vw_Dental_Diagnosis_Treatment_Report", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@PatregId", patregid);
            cmd.Parameters.AddWithValue("@OpdNo", OpdNo);
            cmd.Parameters.AddWithValue("@IpdNo", IpdNo);

            cmd.ExecuteNonQuery();



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

    public void Alter_Dental_Treatment_Report(int patregid, int OpdNo, int IpdNo)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Alter_Vw_Dental_Treatment_Details_Report", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@PatregId", patregid);
            cmd.Parameters.AddWithValue("@OpdNo", OpdNo);
            cmd.Parameters.AddWithValue("@IpdNo", IpdNo);

            cmd.ExecuteNonQuery();



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
    public void Insert_New_Opthalmology_Clinic()
    {

        SqlConnection conn = DataAccess.ConInitForDC();
        SqlCommand sc = new SqlCommand();
        sc.CommandType = CommandType.StoredProcedure;
        sc.Connection = conn;
        sc.CommandText = "SP_Insert_NewOpthalmology_Clinic";
        sc.Parameters.Add(new SqlParameter("@Patregid", SqlDbType.Int)).Value = P_Patregid;
        sc.Parameters.Add(new SqlParameter("@OPDNo", SqlDbType.Int)).Value = P_OpdNo;
        sc.Parameters.Add(new SqlParameter("@IPDNo", SqlDbType.Int)).Value = P_IpdNo;


        if (this.P_EntryDate == Date.getMinDate())
            sc.Parameters.Add(new SqlParameter("@OpthaDate", SqlDbType.DateTime)).Value = DBNull.Value;
        else
            sc.Parameters.Add(new SqlParameter("@OpthaDate", SqlDbType.DateTime)).Value = P_EntryDate;

        sc.Parameters.Add(new SqlParameter("@DrName", SqlDbType.NVarChar, 500)).Value = P_DrName;
        sc.Parameters.Add(new SqlParameter("@Diagnosis", SqlDbType.NVarChar, 500)).Value = P_Diagnosis;
        sc.Parameters.Add(new SqlParameter("@ChiefComplaints", SqlDbType.NVarChar, 500)).Value = P_ChiefComplaints;

        sc.Parameters.Add(new SqlParameter("@PastHistory", SqlDbType.NVarChar, 2500)).Value = P_PastHistory;
        sc.Parameters.Add(new SqlParameter("@Allergy", SqlDbType.NVarChar, 2500)).Value = P_Allergies;
        sc.Parameters.Add(new SqlParameter("@ClinicalNote", SqlDbType.NVarChar, 500)).Value = P_ClinicalNote;
        sc.Parameters.Add(new SqlParameter("@CurrentMedication", SqlDbType.NVarChar, 500)).Value = P_CurrentMedication;


        sc.Parameters.Add(new SqlParameter("@UnaidedODD", SqlDbType.NVarChar, 50)).Value = P_UnaidedODD;
        sc.Parameters.Add(new SqlParameter("@UnaidedOSD", SqlDbType.NVarChar, 50)).Value = P_UnaidedOSD;
        sc.Parameters.Add(new SqlParameter("@UnaidedODN", SqlDbType.NVarChar, 50)).Value = P_UnaidedODN;
        sc.Parameters.Add(new SqlParameter("@UnaidedOSN", SqlDbType.NVarChar, 50)).Value = P_UnaidedOSN;
        sc.Parameters.Add(new SqlParameter("@PinholeOD", SqlDbType.NVarChar, 50)).Value = P_PinholeOD;
        sc.Parameters.Add(new SqlParameter("@PinholeOS", SqlDbType.NVarChar, 50)).Value = P_PinholeOS;
        sc.Parameters.Add(new SqlParameter("@SpectaclesODD", SqlDbType.NVarChar, 50)).Value = P_SpectaclesODD;
        sc.Parameters.Add(new SqlParameter("@SpectaclesOSD", SqlDbType.NVarChar, 50)).Value = P_SpectaclesOSD;
        sc.Parameters.Add(new SqlParameter("@SpectaclesODN", SqlDbType.NVarChar, 50)).Value = P_SpectaclesODN;
        sc.Parameters.Add(new SqlParameter("@SpectaclesOSN", SqlDbType.NVarChar, 50)).Value = P_SpectaclesOSN;
        sc.Parameters.Add(new SqlParameter("@IOPOD", SqlDbType.NVarChar, 50)).Value = P_IOPOD;
        sc.Parameters.Add(new SqlParameter("@IOPOS", SqlDbType.NVarChar, 50)).Value = P_IOPOS;
        sc.Parameters.Add(new SqlParameter("@NPC", SqlDbType.NVarChar, 50)).Value = P_NPC;
        sc.Parameters.Add(new SqlParameter("@PachymetryOD", SqlDbType.NVarChar, 50)).Value = P_PachymetryOD;
        sc.Parameters.Add(new SqlParameter("@PachymetryOS", SqlDbType.NVarChar, 50)).Value = P_PachymetryOS;
        sc.Parameters.Add(new SqlParameter("@R1RMM", SqlDbType.NVarChar, 50)).Value = P_R1RMM;
        sc.Parameters.Add(new SqlParameter("@R1RD", SqlDbType.NVarChar, 50)).Value = P_R1RD;
        sc.Parameters.Add(new SqlParameter("@R1RDeg", SqlDbType.NVarChar, 50)).Value = P_R1RDeg;
        sc.Parameters.Add(new SqlParameter("@R1LMM", SqlDbType.NVarChar, 50)).Value = P_R1LMM;
        sc.Parameters.Add(new SqlParameter("@R1LD", SqlDbType.NVarChar, 50)).Value = P_R1LD;
        sc.Parameters.Add(new SqlParameter("@R1LDeg", SqlDbType.NVarChar, 50)).Value = P_R1LDeg;
        sc.Parameters.Add(new SqlParameter("@R2RMM", SqlDbType.NVarChar, 50)).Value = P_R2RMM;
        sc.Parameters.Add(new SqlParameter("@R2RD", SqlDbType.NVarChar, 50)).Value = P_R2RD;
        sc.Parameters.Add(new SqlParameter("@R2RDeg", SqlDbType.NVarChar, 50)).Value = P_R2RDeg;
        sc.Parameters.Add(new SqlParameter("@R2LMM", SqlDbType.NVarChar, 50)).Value = P_R2LMM;

        sc.Parameters.Add(new SqlParameter("@R2LD", SqlDbType.NVarChar, 50)).Value = P_R2LD;
        sc.Parameters.Add(new SqlParameter("@R2LDeg", SqlDbType.NVarChar, 50)).Value = P_R2LDeg;
        sc.Parameters.Add(new SqlParameter("@AVGRMM", SqlDbType.NVarChar, 50)).Value = P_AVGRMM;
        sc.Parameters.Add(new SqlParameter("@AVGRD", SqlDbType.NVarChar, 50)).Value = P_AVGRD;
        sc.Parameters.Add(new SqlParameter("@AVGRDeg", SqlDbType.NVarChar, 50)).Value = P_AVGRDeg;
        sc.Parameters.Add(new SqlParameter("@AVGLMM", SqlDbType.NVarChar, 50)).Value = P_AVGLMM;
        sc.Parameters.Add(new SqlParameter("@AVGLD", SqlDbType.NVarChar, 50)).Value = P_AVGLD;
        sc.Parameters.Add(new SqlParameter("@AVGLDeg", SqlDbType.NVarChar, 50)).Value = P_AVGLDeg;
        sc.Parameters.Add(new SqlParameter("@CYLRMM", SqlDbType.NVarChar, 50)).Value = P_CYLRMM;
        sc.Parameters.Add(new SqlParameter("@CYLRD", SqlDbType.NVarChar, 50)).Value = P_CYLRD;
        sc.Parameters.Add(new SqlParameter("@CYLRDeg", SqlDbType.NVarChar, 50)).Value = P_CYLRDeg;
        sc.Parameters.Add(new SqlParameter("@CYLLMM", SqlDbType.NVarChar, 50)).Value = P_CYLLMM;
        sc.Parameters.Add(new SqlParameter("@CYLLD", SqlDbType.NVarChar, 50)).Value = P_CYLLD;
        sc.Parameters.Add(new SqlParameter("@CYLLDeg", SqlDbType.NVarChar, 50)).Value = P_CYLLDeg;
        sc.Parameters.Add(new SqlParameter("@PD", SqlDbType.NVarChar, 50)).Value = P_PD;
        sc.Parameters.Add(new SqlParameter("@Keratometry_N", SqlDbType.NVarChar, 50)).Value = P_Keratometry_N;
        sc.Parameters.Add(new SqlParameter("@ColorOD", SqlDbType.NVarChar, 50)).Value = P_ColorOD;
        sc.Parameters.Add(new SqlParameter("@ColorOS", SqlDbType.NVarChar, 50)).Value = P_ColorOS;

        sc.Parameters.Add(new SqlParameter("@CoverTest", SqlDbType.NVarChar, 50)).Value = P_CoverTest;
        sc.Parameters.Add(new SqlParameter("@AxialOD", SqlDbType.NVarChar, 50)).Value = P_AxialOD;
        sc.Parameters.Add(new SqlParameter("@AxialOS", SqlDbType.NVarChar, 50)).Value = P_AxialOS;
        sc.Parameters.Add(new SqlParameter("@AConstantOD", SqlDbType.NVarChar, 50)).Value = P_AConstantOD;
        sc.Parameters.Add(new SqlParameter("@AConstantOS", SqlDbType.NVarChar, 50)).Value = P_AConstantOS;
        sc.Parameters.Add(new SqlParameter("@IOLOD", SqlDbType.NVarChar, 50)).Value = P_IOLOD;
        sc.Parameters.Add(new SqlParameter("@IOLOS", SqlDbType.NVarChar, 50)).Value = P_IOLOS;
        sc.Parameters.Add(new SqlParameter("@PredictiveOD", SqlDbType.NVarChar, 50)).Value = P_PredictiveOD;
        sc.Parameters.Add(new SqlParameter("@PredictiveOS", SqlDbType.NVarChar, 50)).Value = P_PredictiveOS;
        sc.Parameters.Add(new SqlParameter("@SPHCSPR", SqlDbType.NVarChar, 50)).Value = P_SPHCSPR;
        sc.Parameters.Add(new SqlParameter("@CYLCSPR", SqlDbType.NVarChar, 50)).Value = P_CYLCSPR;
        sc.Parameters.Add(new SqlParameter("@AXISCSPR", SqlDbType.NVarChar, 50)).Value = P_AXISCSPR;
        sc.Parameters.Add(new SqlParameter("@SPHCSPL", SqlDbType.NVarChar, 50)).Value = P_SPHCSPL;
        sc.Parameters.Add(new SqlParameter("@CYLCSPL", SqlDbType.NVarChar, 50)).Value = P_CYLCSPL;
        sc.Parameters.Add(new SqlParameter("@AXISCSPL", SqlDbType.NVarChar, 50)).Value = P_AXISCSPL;
        sc.Parameters.Add(new SqlParameter("@ADDCSP", SqlDbType.NVarChar, 50)).Value = P_ADDCSP;
        sc.Parameters.Add(new SqlParameter("@SPHAutoR", SqlDbType.NVarChar, 50)).Value = P_SPHAutoR;
        sc.Parameters.Add(new SqlParameter("@CYLAutoR", SqlDbType.NVarChar, 50)).Value = P_CYLAutoR;
        sc.Parameters.Add(new SqlParameter("@AXISAutoR", SqlDbType.NVarChar, 50)).Value = P_AXISAutoR;
        sc.Parameters.Add(new SqlParameter("@SPHAutoL", SqlDbType.NVarChar, 50)).Value = P_SPHAutoL;
        sc.Parameters.Add(new SqlParameter("@CYLAutoL", SqlDbType.NVarChar, 50)).Value = P_CYLAutoL;

        sc.Parameters.Add(new SqlParameter("@AXISAutoL", SqlDbType.NVarChar, 50)).Value = P_AXISAutoL;
        sc.Parameters.Add(new SqlParameter("@SPHMRR", SqlDbType.NVarChar, 50)).Value = P_SPHMRR;
        sc.Parameters.Add(new SqlParameter("@CYLMRR", SqlDbType.NVarChar, 50)).Value = P_CYLMRR;
        sc.Parameters.Add(new SqlParameter("@AXISMRR", SqlDbType.NVarChar, 50)).Value = P_AXISMRR;
        sc.Parameters.Add(new SqlParameter("@VAMRR", SqlDbType.NVarChar, 50)).Value = P_VAMRR;
        sc.Parameters.Add(new SqlParameter("@SPHMRL", SqlDbType.NVarChar, 50)).Value = P_SPHMRL;
        sc.Parameters.Add(new SqlParameter("@CYLMRL", SqlDbType.NVarChar, 50)).Value = P_CYLMRL;
        sc.Parameters.Add(new SqlParameter("@AXISMRL", SqlDbType.NVarChar, 50)).Value = P_AXISMRL;
        sc.Parameters.Add(new SqlParameter("@VAMRL", SqlDbType.NVarChar, 50)).Value = P_VAMRL;
        sc.Parameters.Add(new SqlParameter("@ADDMRL", SqlDbType.NVarChar, 50)).Value = P_ADDMRL;
        sc.Parameters.Add(new SqlParameter("@ODMRL", SqlDbType.NVarChar, 50)).Value = P_ODMRL;
        sc.Parameters.Add(new SqlParameter("@OSMRL", SqlDbType.NVarChar, 50)).Value = P_OSMRL;
        sc.Parameters.Add(new SqlParameter("@SPHCRR", SqlDbType.NVarChar, 50)).Value = P_SPHCRR;

        sc.Parameters.Add(new SqlParameter("@CYLCRR", SqlDbType.NVarChar, 50)).Value = P_CYLCRR;
        sc.Parameters.Add(new SqlParameter("@AXISCRR", SqlDbType.NVarChar, 50)).Value = P_AXISCRR;
        sc.Parameters.Add(new SqlParameter("@SPHCRL", SqlDbType.NVarChar, 50)).Value = P_SPHCRL;
        sc.Parameters.Add(new SqlParameter("@CYLCRL", SqlDbType.NVarChar, 50)).Value = P_CYLCRL;
        sc.Parameters.Add(new SqlParameter("@AXISCRL", SqlDbType.NVarChar, 50)).Value = P_AXISCRL;
        sc.Parameters.Add(new SqlParameter("@ADDCRL", SqlDbType.NVarChar, 50)).Value = P_ADDCRL;
        sc.Parameters.Add(new SqlParameter("@MedicationUsed", SqlDbType.NVarChar, 50)).Value = P_MedicationUsed;
        sc.Parameters.Add(new SqlParameter("@Retinoscopy", SqlDbType.NVarChar, 250)).Value = P_Retinoscopy;

        sc.Parameters.Add(new SqlParameter("@ADNEXAODR", SqlDbType.NVarChar, 250)).Value = P_ADNEXAODR;
        sc.Parameters.Add(new SqlParameter("@ADNEXAODL", SqlDbType.NVarChar, 250)).Value = P_ADNEXAODL;
        sc.Parameters.Add(new SqlParameter("@ANTERIORODR", SqlDbType.NVarChar, 250)).Value = P_ANTERIORODR;
        sc.Parameters.Add(new SqlParameter("@ANTERIORODL", SqlDbType.NVarChar, 250)).Value = P_ANTERIORODL;
        sc.Parameters.Add(new SqlParameter("@POSTERIORODR", SqlDbType.NVarChar, 250)).Value = P_POSTERIORODR;
        sc.Parameters.Add(new SqlParameter("@POSTERIORODL", SqlDbType.NVarChar, 250)).Value = P_POSTERIORODL;
        sc.Parameters.Add(new SqlParameter("@MaculaDilated", SqlDbType.NVarChar, 50)).Value = P_MaculaDilated;
        sc.Parameters.Add(new SqlParameter("@DIAGNOSISOptha", SqlDbType.NVarChar, 250)).Value = P_DIAGNOSISOptha;
        sc.Parameters.Add(new SqlParameter("@MANAGEMENT", SqlDbType.NVarChar, 250)).Value = P_MANAGEMENT;
        sc.Parameters.Add(new SqlParameter("@INVESTIGATIONS", SqlDbType.NVarChar, 250)).Value = P_INVESTIGATIONS;
        sc.Parameters.Add(new SqlParameter("@PROCEDURESS", SqlDbType.NVarChar, 250)).Value = P_PROCEDURESS;
      



      //  sc.Parameters.Add(new SqlParameter("@DocumentFileName", SqlDbType.NVarChar, 550)).Value = P_DocumentFileName;
      //  sc.Parameters.Add(new SqlParameter("@DocumentFilePath", SqlDbType.NVarChar, 550)).Value = P_DocumentFilePath;

        sc.Parameters.Add(new SqlParameter("@CreatedBy", SqlDbType.NVarChar, 250)).Value = P_CreatedBy;
        sc.Parameters.Add(new SqlParameter("@Branchid", SqlDbType.Int)).Value = P_Branchid;
       


        try
        {
            conn.Open();
            sc.ExecuteNonQuery();
        }
        catch (SqlException)
        {
            throw;
        }
        finally
        {
            conn.Close(); conn.Dispose();
        }
    }
    public void Insert_Opthalmology_Clinic()
    {

        SqlConnection conn = DataAccess.ConInitForDC();
        SqlCommand sc = new SqlCommand();
        sc.CommandType = CommandType.StoredProcedure;
        sc.Connection = conn;
        sc.CommandText = "SP_Insert_Opthalmology_Clinic";
        sc.Parameters.Add(new SqlParameter("@Patregid", SqlDbType.Int)).Value = P_Patregid;
        sc.Parameters.Add(new SqlParameter("@OPDNo", SqlDbType.Int)).Value = P_OpdNo;
        sc.Parameters.Add(new SqlParameter("@IPDNo", SqlDbType.Int)).Value = P_IpdNo;
        sc.Parameters.Add(new SqlParameter("@ChiefComplaints", SqlDbType.NVarChar, 500)).Value = P_ChiefComplaints;

        //if (this.P_EntryDate == Date.getMinDate())
        //    sc.Parameters.Add(new SqlParameter("@EntryDate", SqlDbType.DateTime)).Value = DBNull.Value;
        //else
        //    sc.Parameters.Add(new SqlParameter("@EntryDate", SqlDbType.DateTime)).Value = P_EntryDate;


        sc.Parameters.Add(new SqlParameter("@OcularHistory", SqlDbType.NVarChar, 2500)).Value = P_OcularHistory;

        sc.Parameters.Add(new SqlParameter("@PastHistory", SqlDbType.NVarChar, 2500)).Value = P_PastHistory;
        sc.Parameters.Add(new SqlParameter("@Allergies", SqlDbType.NVarChar, 2500)).Value = P_Allergies;
        sc.Parameters.Add(new SqlParameter("@FamilyHistory", SqlDbType.NVarChar, 500)).Value = P_FamilyHistory;
        sc.Parameters.Add(new SqlParameter("@TreatmentHistory", SqlDbType.NVarChar, 500)).Value = P_TreatmentHistory;

        sc.Parameters.Add(new SqlParameter("@NIL", SqlDbType.Bit)).Value = P_NIL;
        sc.Parameters.Add(new SqlParameter("@DM", SqlDbType.Bit)).Value = P_DM;
        sc.Parameters.Add(new SqlParameter("@HTN", SqlDbType.Bit)).Value = P_HTN;
        sc.Parameters.Add(new SqlParameter("@CAD", SqlDbType.Bit)).Value = P_CAD;
        sc.Parameters.Add(new SqlParameter("@Thyroid", SqlDbType.Bit)).Value = P_Thyroid;
        sc.Parameters.Add(new SqlParameter("@IS_Pregnancy", SqlDbType.Bit)).Value = P_IS_Pregnancy;
        sc.Parameters.Add(new SqlParameter("@HIV", SqlDbType.Bit)).Value = P_HIV;
        sc.Parameters.Add(new SqlParameter("@HBsAG", SqlDbType.Bit)).Value = P_HBsAG;
        sc.Parameters.Add(new SqlParameter("@Asthama", SqlDbType.Bit)).Value = P_Asthama;
        sc.Parameters.Add(new SqlParameter("@HTN_Family", SqlDbType.Bit)).Value = P_HTN_Family;
        sc.Parameters.Add(new SqlParameter("@DMGlaucoma", SqlDbType.Bit)).Value = P_DMGlaucoma;
        sc.Parameters.Add(new SqlParameter("@CongCataract", SqlDbType.Bit)).Value = P_CongCataract;
        sc.Parameters.Add(new SqlParameter("@RP", SqlDbType.Bit)).Value = P_RP;

        sc.Parameters.Add(new SqlParameter("@Glaucoma", SqlDbType.Bit)).Value = P_Glaucoma;
        sc.Parameters.Add(new SqlParameter("@Dilated", SqlDbType.NVarChar, 50)).Value = P_Dilated;
        sc.Parameters.Add(new SqlParameter("@DocumentFileName", SqlDbType.NVarChar, 550)).Value = P_DocumentFileName;
        sc.Parameters.Add(new SqlParameter("@DocumentFilePath", SqlDbType.NVarChar, 550)).Value = P_DocumentFilePath;

        sc.Parameters.Add(new SqlParameter("@CreatedBy", SqlDbType.NVarChar, 250)).Value = P_CreatedBy;
        sc.Parameters.Add(new SqlParameter("@Branchid", SqlDbType.Int)).Value = P_Branchid;
        sc.Parameters.Add(new SqlParameter("@Diagnosis", SqlDbType.NVarChar, 550)).Value = P_Diagnosis;



        try
        {
            conn.Open();
            sc.ExecuteNonQuery();
        }
        catch (SqlException)
        {
            throw;
        }
        finally
        {
            conn.Close(); conn.Dispose();
        }
    }

    public void Insert_Optha_RefractiveWorkup_Clinic()
    {

        SqlConnection conn = DataAccess.ConInitForDC();
        SqlCommand sc = new SqlCommand();
        sc.CommandType = CommandType.StoredProcedure;
        sc.Connection = conn;
        sc.CommandText = "Usp_Insert_Optho_RefractiveWorkup";
        sc.Parameters.Add(new SqlParameter("@Patregid", SqlDbType.Int)).Value = P_Patregid;
        sc.Parameters.Add(new SqlParameter("@OPDNo", SqlDbType.Int)).Value = P_OpdNo;
        sc.Parameters.Add(new SqlParameter("@IPDNo", SqlDbType.Int)).Value = P_IpdNo;
        //sc.Parameters.Add(new SqlParameter("@ChiefComplaints", SqlDbType.NVarChar, 500)).Value = P_ChiefComplaints;

        if (this.P_ARDate == Date.getMinDate())
            sc.Parameters.Add(new SqlParameter("@ARDate", SqlDbType.DateTime)).Value = DBNull.Value;
        else
            sc.Parameters.Add(new SqlParameter("@ARDate", SqlDbType.DateTime)).Value = P_ARDate;


        sc.Parameters.Add(new SqlParameter("@OORSPH", SqlDbType.NVarChar, 250)).Value = P_OORSPH;

        sc.Parameters.Add(new SqlParameter("@OORCYL", SqlDbType.NVarChar, 250)).Value = P_OORCYL;
        sc.Parameters.Add(new SqlParameter("@OORAXIS", SqlDbType.NVarChar, 250)).Value = P_OORAXIS;
        sc.Parameters.Add(new SqlParameter("@OORemark", SqlDbType.NVarChar, 500)).Value = P_OORemark;
        sc.Parameters.Add(new SqlParameter("@OOLSPH", SqlDbType.NVarChar, 500)).Value = P_OOLSPH;

        sc.Parameters.Add(new SqlParameter("@OOLCYL", SqlDbType.NVarChar, 250)).Value = P_OOLCYL;
        sc.Parameters.Add(new SqlParameter("@OOLAXIS", SqlDbType.NVarChar, 250)).Value = P_OOLAXIS;
        sc.Parameters.Add(new SqlParameter("@UNRSPH", SqlDbType.NVarChar, 250)).Value = P_UNRSPH;
        sc.Parameters.Add(new SqlParameter("@UNRCYL", SqlDbType.NVarChar, 250)).Value = P_UNRCYL;
        sc.Parameters.Add(new SqlParameter("@UNRAXIS", SqlDbType.NVarChar, 250)).Value = P_UNRAXIS;
        sc.Parameters.Add(new SqlParameter("@UNRVA", SqlDbType.NVarChar, 250)).Value = P_UNRVA;
        sc.Parameters.Add(new SqlParameter("@UNRAdd", SqlDbType.NVarChar, 250)).Value = P_UNRAdd;
        sc.Parameters.Add(new SqlParameter("@UNLSPH", SqlDbType.NVarChar, 250)).Value = P_UNLSPH;
        sc.Parameters.Add(new SqlParameter("@UNLCYL", SqlDbType.NVarChar, 250)).Value = P_UNLCYL;
        sc.Parameters.Add(new SqlParameter("@UNLAXIS", SqlDbType.NVarChar, 250)).Value = P_UNLAXIS;
        sc.Parameters.Add(new SqlParameter("@UNLVA", SqlDbType.NVarChar, 250)).Value = P_UNLVA;
        sc.Parameters.Add(new SqlParameter("@UNLAdd", SqlDbType.NVarChar, 250)).Value = P_UNLAdd;
        sc.Parameters.Add(new SqlParameter("@MedicationUsed", SqlDbType.NVarChar, 250)).Value = P_MedicationUsed;
        sc.Parameters.Add(new SqlParameter("@RetnoscopyWorking", SqlDbType.NVarChar, 250)).Value = P_RetnoscopyWorking;
        sc.Parameters.Add(new SqlParameter("@DiaRSPH", SqlDbType.NVarChar, 250)).Value = P_DiaRSPH;
        sc.Parameters.Add(new SqlParameter("@DiaRCYL", SqlDbType.NVarChar, 250)).Value = P_DiaRCYL;
        sc.Parameters.Add(new SqlParameter("@DiaRAXIS", SqlDbType.NVarChar, 250)).Value = P_DiaRAXIS;
        sc.Parameters.Add(new SqlParameter("@DiaLSPH", SqlDbType.NVarChar, 250)).Value = P_DiaLSPH;
        sc.Parameters.Add(new SqlParameter("@DiaLCYL", SqlDbType.NVarChar, 250)).Value = P_DiaLCYL;
        sc.Parameters.Add(new SqlParameter("@DiaLAXIS", SqlDbType.NVarChar, 250)).Value = P_DiaLAXIS;
        sc.Parameters.Add(new SqlParameter("@DiaRRSPH", SqlDbType.NVarChar, 250)).Value = P_DiaRRSPH;
        sc.Parameters.Add(new SqlParameter("@DiaRRCYL", SqlDbType.NVarChar, 250)).Value = P_DiaRRCYL;
        sc.Parameters.Add(new SqlParameter("@DiaRRAXIS", SqlDbType.NVarChar, 250)).Value = P_DiaRRAXIS;
        sc.Parameters.Add(new SqlParameter("@DiaRLSPH", SqlDbType.NVarChar, 250)).Value = P_DiaRLSPH;
        sc.Parameters.Add(new SqlParameter("@DiaRLCYL", SqlDbType.NVarChar, 250)).Value = P_DiaRLCYL;
        sc.Parameters.Add(new SqlParameter("@DiaRLAXIS", SqlDbType.NVarChar, 250)).Value = P_DiaRLAXIS;
        sc.Parameters.Add(new SqlParameter("@FPRSPH", SqlDbType.NVarChar, 250)).Value = P_FPRSPH;
        sc.Parameters.Add(new SqlParameter("@FPRCYL", SqlDbType.NVarChar, 250)).Value = P_FPRCYL;
        sc.Parameters.Add(new SqlParameter("@FPRAXIS", SqlDbType.NVarChar, 250)).Value = P_FPRAXIS;
        sc.Parameters.Add(new SqlParameter("@FPRVA", SqlDbType.NVarChar, 250)).Value = P_FPRVA;
        sc.Parameters.Add(new SqlParameter("@FPRAdd", SqlDbType.NVarChar, 250)).Value = P_FPRAdd;
        sc.Parameters.Add(new SqlParameter("@FPLSPH", SqlDbType.NVarChar, 250)).Value = P_FPLSPH;
        sc.Parameters.Add(new SqlParameter("@FPLCYL", SqlDbType.NVarChar, 250)).Value = P_FPLCYL;
        sc.Parameters.Add(new SqlParameter("@FPLAXIS", SqlDbType.NVarChar, 250)).Value = P_FPLAXIS;
        sc.Parameters.Add(new SqlParameter("@FPLVA", SqlDbType.NVarChar, 250)).Value = P_FPLVA;
        sc.Parameters.Add(new SqlParameter("@FPLAdd", SqlDbType.NVarChar, 250)).Value = P_FPLAdd;
        sc.Parameters.Add(new SqlParameter("@OPRSPH", SqlDbType.NVarChar, 250)).Value = P_OPRSPH;
        sc.Parameters.Add(new SqlParameter("@OPRCYL", SqlDbType.NVarChar, 250)).Value = P_OPRCYL;
        sc.Parameters.Add(new SqlParameter("@OPRAXIS", SqlDbType.NVarChar, 250)).Value = P_OPRAXIS;
        sc.Parameters.Add(new SqlParameter("@OPLSPH", SqlDbType.NVarChar, 250)).Value = P_OPLSPH;
        sc.Parameters.Add(new SqlParameter("@OPLCYL", SqlDbType.NVarChar, 250)).Value = P_OPLCYL;
        sc.Parameters.Add(new SqlParameter("@OPLAXIS", SqlDbType.NVarChar, 250)).Value = P_OPLAXIS;
        sc.Parameters.Add(new SqlParameter("@UNADOD", SqlDbType.NVarChar, 250)).Value = P_UNADOD;
        sc.Parameters.Add(new SqlParameter("@UNADOD1", SqlDbType.NVarChar, 250)).Value = P_UNADOD1;
        sc.Parameters.Add(new SqlParameter("@UNANOD", SqlDbType.NVarChar, 250)).Value = P_UNANOD;
        sc.Parameters.Add(new SqlParameter("@UNANOD1", SqlDbType.NVarChar, 250)).Value = P_UNANOD1;
        sc.Parameters.Add(new SqlParameter("@WGOD", SqlDbType.NVarChar, 250)).Value = P_WGOD;
        sc.Parameters.Add(new SqlParameter("@WGOD1", SqlDbType.NVarChar, 250)).Value = P_WGOD1;
        sc.Parameters.Add(new SqlParameter("@WGNOD", SqlDbType.NVarChar, 250)).Value = P_WGNOD;
        sc.Parameters.Add(new SqlParameter("@WGNOD1", SqlDbType.NVarChar, 250)).Value = P_WGNOD1;
        sc.Parameters.Add(new SqlParameter("@WPDOD", SqlDbType.NVarChar, 250)).Value = P_WPDOD;
        sc.Parameters.Add(new SqlParameter("@WPDOD1", SqlDbType.NVarChar, 250)).Value = P_WPDOD1;
        sc.Parameters.Add(new SqlParameter("@WPNOD", SqlDbType.NVarChar, 250)).Value = P_WPNOD;
        sc.Parameters.Add(new SqlParameter("@WPNOD1", SqlDbType.NVarChar, 250)).Value = P_WPNOD1;
        sc.Parameters.Add(new SqlParameter("@BCDOD", SqlDbType.NVarChar, 250)).Value = P_BCDOD;
        sc.Parameters.Add(new SqlParameter("@BCDOD1", SqlDbType.NVarChar, 250)).Value = P_BCDOD1;
        sc.Parameters.Add(new SqlParameter("@BCNOD", SqlDbType.NVarChar, 250)).Value = P_BCNOD;
        sc.Parameters.Add(new SqlParameter("@BCNOD1", SqlDbType.NVarChar, 250)).Value = P_BCNOD1;
        sc.Parameters.Add(new SqlParameter("@RefractiveNotes", SqlDbType.NVarChar, 250)).Value = P_RefractiveNotes;
        sc.Parameters.Add(new SqlParameter("@IOP", SqlDbType.NVarChar, 250)).Value = P_IOP;
        sc.Parameters.Add(new SqlParameter("@AntiglucinMedication", SqlDbType.NVarChar, 250)).Value = P_AntiglucinMedication;
        sc.Parameters.Add(new SqlParameter("@REMin1", SqlDbType.NVarChar, 250)).Value = P_REMin1;
        sc.Parameters.Add(new SqlParameter("@REMin2", SqlDbType.NVarChar, 250)).Value = REMin2;

        sc.Parameters.Add(new SqlParameter("@REMin3", SqlDbType.NVarChar, 250)).Value = P_REMin3;
        sc.Parameters.Add(new SqlParameter("@REMin4", SqlDbType.NVarChar, 250)).Value = P_REMin4;
        sc.Parameters.Add(new SqlParameter("@LEMin1", SqlDbType.NVarChar, 250)).Value = P_LEMin1;
        sc.Parameters.Add(new SqlParameter("@LEMin2", SqlDbType.NVarChar, 250)).Value = P_LEMin2;
        sc.Parameters.Add(new SqlParameter("@LEMin3", SqlDbType.NVarChar, 250)).Value = P_LEMin3;
        sc.Parameters.Add(new SqlParameter("@LEMin4", SqlDbType.NVarChar, 250)).Value = P_LEMin4;
        sc.Parameters.Add(new SqlParameter("@CreatedBy", SqlDbType.NVarChar, 250)).Value = P_CreatedBy;
        

        


       // sc.Parameters.Add(new SqlParameter("@CreatedBy", SqlDbType.NVarChar, 250)).Value = P_CreatedBy;
        sc.Parameters.Add(new SqlParameter("@Branchid", SqlDbType.Int)).Value = P_Branchid;



        try
        {
            conn.Open();
            sc.ExecuteNonQuery();
        }
        catch (SqlException)
        {
            throw;
        }
        finally
        {
            conn.Close(); conn.Dispose();
        }
    }


    public void Insert_Optha_FaceExamination_Clinic()
    {

        SqlConnection conn = DataAccess.ConInitForDC();
        SqlCommand sc = new SqlCommand();
        sc.CommandType = CommandType.StoredProcedure;
        sc.Connection = conn;
        sc.CommandText = "USP_Insert_FaceExamination";
        sc.Parameters.Add(new SqlParameter("@Patregid", SqlDbType.Int)).Value = P_Patregid;
        sc.Parameters.Add(new SqlParameter("@OPDNo", SqlDbType.Int)).Value = P_OpdNo;
        sc.Parameters.Add(new SqlParameter("@IPDNo", SqlDbType.Int)).Value = P_IpdNo;



        sc.Parameters.Add(new SqlParameter("@OcularOD", SqlDbType.NVarChar, 250)).Value = P_OcularOD;

        sc.Parameters.Add(new SqlParameter("@OcularOS", SqlDbType.NVarChar, 250)).Value = P_OcularOS;
        sc.Parameters.Add(new SqlParameter("@LidsOD", SqlDbType.NVarChar, 250)).Value = P_LidsOD;
        sc.Parameters.Add(new SqlParameter("@LidsOS", SqlDbType.NVarChar, 500)).Value = P_LidsOS;
        sc.Parameters.Add(new SqlParameter("@NasolacrinalOD", SqlDbType.NVarChar, 500)).Value = P_NasolacrinalOD;

        sc.Parameters.Add(new SqlParameter("@NasolacrinalOS", SqlDbType.NVarChar, 250)).Value = P_NasolacrinalOS;
        sc.Parameters.Add(new SqlParameter("@SyringingOD", SqlDbType.NVarChar, 250)).Value = P_SyringingOD;
        sc.Parameters.Add(new SqlParameter("@SyringingOS", SqlDbType.NVarChar, 250)).Value = P_SyringingOS;
        sc.Parameters.Add(new SqlParameter("@CenjunctivaOD", SqlDbType.NVarChar, 250)).Value = P_CenjunctivaOD;
        sc.Parameters.Add(new SqlParameter("@CenjunctivaOS", SqlDbType.NVarChar, 250)).Value = P_CenjunctivaOS;
        sc.Parameters.Add(new SqlParameter("@CorneaOD", SqlDbType.NVarChar, 250)).Value = P_CorneaOD;
        sc.Parameters.Add(new SqlParameter("@CorneaOS", SqlDbType.NVarChar, 250)).Value = P_CorneaOS;
        sc.Parameters.Add(new SqlParameter("@IrisOD", SqlDbType.NVarChar, 250)).Value = P_IrisOD;//---
        sc.Parameters.Add(new SqlParameter("@IrisOS", SqlDbType.NVarChar, 250)).Value = P_IrisOS;
        sc.Parameters.Add(new SqlParameter("@PupilOD", SqlDbType.NVarChar, 250)).Value = P_PupilOD;
        sc.Parameters.Add(new SqlParameter("@PupilOS", SqlDbType.NVarChar, 250)).Value = P_PupilOS;
        sc.Parameters.Add(new SqlParameter("@LensOD", SqlDbType.NVarChar, 250)).Value = P_LensOD;
        sc.Parameters.Add(new SqlParameter("@LensOS", SqlDbType.NVarChar, 250)).Value = P_LensOS;
        sc.Parameters.Add(new SqlParameter("@VitreousOD", SqlDbType.NVarChar, 250)).Value = P_VitreousOD;
        sc.Parameters.Add(new SqlParameter("@VitreousOS", SqlDbType.NVarChar, 250)).Value = P_VitreousOD;
        sc.Parameters.Add(new SqlParameter("@OptisDiscOD", SqlDbType.NVarChar, 250)).Value = P_OptisDiscOD;
        sc.Parameters.Add(new SqlParameter("@OptisDiscOS", SqlDbType.NVarChar, 250)).Value = P_OptisDiscOS;
        sc.Parameters.Add(new SqlParameter("@COROD", SqlDbType.NVarChar, 250)).Value = P_COROD;
        sc.Parameters.Add(new SqlParameter("@COROS", SqlDbType.NVarChar, 250)).Value = P_COROS;
        sc.Parameters.Add(new SqlParameter("@FUNDUSOD", SqlDbType.NVarChar, 250)).Value = P_FUNDUSOD;
        sc.Parameters.Add(new SqlParameter("@FUNDUSOS", SqlDbType.NVarChar, 250)).Value = P_FUNDUSOS;
        sc.Parameters.Add(new SqlParameter("@VESSELSOD", SqlDbType.NVarChar, 250)).Value = P_VESSELSOD;
        sc.Parameters.Add(new SqlParameter("@VESSELSOS", SqlDbType.NVarChar, 250)).Value = P_VESSELSOS;
        sc.Parameters.Add(new SqlParameter("@MACULAOD", SqlDbType.NVarChar, 250)).Value = P_MACULAOD;
        sc.Parameters.Add(new SqlParameter("@MACULAOS", SqlDbType.NVarChar, 250)).Value = P_MACULAOS;
        sc.Parameters.Add(new SqlParameter("@PERIPHERYOD", SqlDbType.NVarChar, 250)).Value = P_PERIPHERYOD;
        sc.Parameters.Add(new SqlParameter("@PERIPHERYOS", SqlDbType.NVarChar, 250)).Value = P_PERIPHERYOS;
        sc.Parameters.Add(new SqlParameter("@Diagnosis", SqlDbType.NVarChar, 350)).Value = P_Diagnosis;
        sc.Parameters.Add(new SqlParameter("@Plans", SqlDbType.NVarChar, 350)).Value = P_Plans;
        sc.Parameters.Add(new SqlParameter("@Discussion", SqlDbType.NVarChar, 350)).Value = P_Discussion;
        sc.Parameters.Add(new SqlParameter("@Treatment", SqlDbType.NVarChar, 350)).Value = P_Treatment;
        sc.Parameters.Add(new SqlParameter("@GonioscopyOD", SqlDbType.NVarChar, 250)).Value = P_GonioscopyOD;
        sc.Parameters.Add(new SqlParameter("@GonioscopyOS", SqlDbType.NVarChar, 250)).Value = P_GonioscopyOS;
        sc.Parameters.Add(new SqlParameter("@PanchyneteryOD", SqlDbType.NVarChar, 250)).Value = P_PanchyneteryOD;
        sc.Parameters.Add(new SqlParameter("@PanchyneteryOS", SqlDbType.NVarChar, 250)).Value = P_PanchyneteryOS;
        sc.Parameters.Add(new SqlParameter("@IOPCorrectionOD", SqlDbType.NVarChar, 250)).Value = P_IOPCorrectionOD;
        sc.Parameters.Add(new SqlParameter("@IOPCorrectionOS", SqlDbType.NVarChar, 250)).Value = P_IOPCorrectionOS;
        sc.Parameters.Add(new SqlParameter("@TopographyOD", SqlDbType.NVarChar, 250)).Value = P_TopographyOD;
        sc.Parameters.Add(new SqlParameter("@TopographyOS", SqlDbType.NVarChar, 250)).Value = P_TopographyOS;
        sc.Parameters.Add(new SqlParameter("@IOLMasterOD", SqlDbType.NVarChar, 250)).Value = P_IOLMasterOD;
        sc.Parameters.Add(new SqlParameter("@IOLMasterOS", SqlDbType.NVarChar, 250)).Value = P_IOLMasterOS;
        sc.Parameters.Add(new SqlParameter("@KINAXOD", SqlDbType.NVarChar, 250)).Value = P_KINAXOD;
        sc.Parameters.Add(new SqlParameter("@KINAXOS", SqlDbType.NVarChar, 250)).Value = P_KINAXOS;
        sc.Parameters.Add(new SqlParameter("@KININOD", SqlDbType.NVarChar, 250)).Value = P_KININOD;
        sc.Parameters.Add(new SqlParameter("@KININOS", SqlDbType.NVarChar, 250)).Value = P_KININOS;
        sc.Parameters.Add(new SqlParameter("@AXILLengthOD", SqlDbType.NVarChar, 250)).Value = P_AXILLengthOD;
        sc.Parameters.Add(new SqlParameter("@AXILLengthOS", SqlDbType.NVarChar, 250)).Value = P_AXILLengthOS;
      
      

      
        sc.Parameters.Add(new SqlParameter("@CreatedBy", SqlDbType.NVarChar, 250)).Value = P_CreatedBy;

        try
        {
            conn.Open();
            sc.ExecuteNonQuery();
        }
        catch (SqlException)
        {
            throw;
        }
        finally
        {
            conn.Close(); conn.Dispose();
        }
    }


    public void Alter_Refractive_WorkUp_Report(int patregid, int OpdNo, int IpdNo)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Usp_Alter_Vw_Optho_RefractiveWorkup_Details", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@PatregId", patregid);
            cmd.Parameters.AddWithValue("@OpdNo", OpdNo);
            cmd.Parameters.AddWithValue("@IpdNo", IpdNo);

            cmd.ExecuteNonQuery();



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

    public DataTable GetGeneralEmrDetailsEdit(string patregId, string opd, string ipd, string branchid)
    {
        DataTable dt = new DataTable();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;

            using (SqlConnection connection =
                      DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetGeneralEmrDetailsByPatientId", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Patientregid", SqlDbType.VarChar).Value = patregId;
                    cmd.Parameters.Add("@Opd", SqlDbType.VarChar).Value = opd;
                    cmd.Parameters.Add("@Ipd", SqlDbType.VarChar).Value = ipd;
                    cmd.Parameters.Add("@BranchId", SqlDbType.VarChar).Value = branchid;

                    connection.Open();

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                    connection.Close();
                    connection.Dispose();
                    return dt;

                }
            }
        }
        catch (Exception)
        {

            return null;
        }

    }

    public DataTable Get_PreAnastiaEvaluation(string patregId, string opd, string ipd, string branchid)
    {
        DataTable dt = new DataTable();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;

            using (SqlConnection connection =
                      DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("USP_GetPreAnaesthesiaEvaluation", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Patientregid", SqlDbType.VarChar).Value = patregId;
                    cmd.Parameters.Add("@Opd", SqlDbType.VarChar).Value = opd;
                    cmd.Parameters.Add("@Ipd", SqlDbType.VarChar).Value = ipd;
                    cmd.Parameters.Add("@BranchId", SqlDbType.VarChar).Value = branchid;

                    connection.Open();

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                    connection.Close();
                    connection.Dispose();
                    return dt;

                }
            }
        }
        catch (Exception)
        {

            return null;
        }

    }

    public DataTable Get_PreOperativeOrder(string patregId, string opd, string ipd, string branchid)
    {
        DataTable dt = new DataTable();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;

            using (SqlConnection connection =
                      DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("USP_GetPreOperativeOrders", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Patientregid", SqlDbType.VarChar).Value = patregId;
                    cmd.Parameters.Add("@Opd", SqlDbType.VarChar).Value = opd;
                    cmd.Parameters.Add("@Ipd", SqlDbType.VarChar).Value = ipd;
                    cmd.Parameters.Add("@BranchId", SqlDbType.VarChar).Value = branchid;

                    connection.Open();

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                    connection.Close();
                    connection.Dispose();
                    return dt;

                }
            }
        }
        catch (Exception)
        {

            return null;
        }

    }

    public DataTable Get_PostOperativeOrder(string patregId, string opd, string ipd, string branchid)
    {
        DataTable dt = new DataTable();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;

            using (SqlConnection connection =
                      DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("USP_GetPostOperativeOrders", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Patientregid", SqlDbType.VarChar).Value = patregId;
                    cmd.Parameters.Add("@Opd", SqlDbType.VarChar).Value = opd;
                    cmd.Parameters.Add("@Ipd", SqlDbType.VarChar).Value = ipd;
                    cmd.Parameters.Add("@BranchId", SqlDbType.VarChar).Value = branchid;

                    connection.Open();

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                    connection.Close();
                    connection.Dispose();
                    return dt;

                }
            }
        }
        catch (Exception)
        {

            return null;
        }

    }
}