using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// Summary description for AddMedicalRecord
/// </summary>
public class OT_Clinical_Template_C
{
    DataAccess da = new DataAccess();
    public OT_Clinical_Template_C()
	{
        //this.P_AdmissionDate = Date.getdate();
        //this.P_DischargeDate = Date.getdate();

        this.OperationDate = Date.getMinDate();
        this.EntryDate = Date.getMinDate();
		//
		// TODO: Add constructor logic here
		//
	}

    private int _Patregid;    public int Patregid    {        get { return _Patregid; }        set { _Patregid = value; }    }
    private int _OPDNO; public int OPDNO { get { return _OPDNO; } set { _OPDNO = value; } }
    private int _IPDNO; public int IPDNO { get { return _IPDNO; } set { _IPDNO = value; } }

    private DateTime _EntryDate; public DateTime EntryDate { get { return _EntryDate; } set { _EntryDate = value; } }
    private DateTime _OperationDate; public DateTime OperationDate { get { return _OperationDate; } set { _OperationDate = value; } }

    private string _NPO; public string NPO { get { return _NPO; } set { _NPO = value; } }
    private string _NPORemark; public string NPORemark { get { return _NPORemark; } set { _NPORemark = value; } }

    private string _Medication; public string Medication { get { return _Medication; } set { _Medication = value; } }


    private string _SugarMonitoring; public string SugarMonitoring { get { return _SugarMonitoring; } set { _SugarMonitoring = value; } }

    private string _Sliding; public string Sliding { get { return _Sliding; } set { _Sliding = value; } }
    private string _Notes; public string Notes { get { return _Notes; } set { _Notes = value; } }




    private string _Branchid; public string Branchid { get { return _Branchid; } set { _Branchid = value; } }
    private string CreatedBy;    public string P_CreatedBy    {        get { return CreatedBy; }        set { CreatedBy = value; }    }

    private string _Schedule; public string Schedule { get { return _Schedule; } set { _Schedule = value; } }
    private string _OperativeProcedure; public string OperativeProcedure { get { return _OperativeProcedure; } set { _OperativeProcedure = value; } }

    private string _PreOperativeDiagnosis; public string PreOperativeDiagnosis { get { return _PreOperativeDiagnosis; } set { _PreOperativeDiagnosis = value; } }
    private string _DurationofSurgery; public string DurationofSurgery { get { return _DurationofSurgery; } set { _DurationofSurgery = value; } }

    private string _PostOperativeAnaesthetist; public string PostOperativeAnaesthetist { get { return _PostOperativeAnaesthetist; } set { _PostOperativeAnaesthetist = value; } }
    private string _SwabCount; public string SwabCount { get { return _SwabCount; } set { _SwabCount = value; } }
    private string _Inflate; public string Inflate { get { return _Inflate; } set { _Inflate = value; } }
    private string _ScrubNurse; public string ScrubNurse { get { return _ScrubNurse; } set { _ScrubNurse = value; } }
    private string _OperationFindings; public string OperationFindings { get { return _OperationFindings; } set { _OperationFindings = value; } }
    private string _Drains; public string Drains { get { return _Drains; } set { _Drains = value; } }

    private string _Anaesthetist; public string Anaesthetist { get { return _Anaesthetist; } set { _Anaesthetist = value; } }

    private string _PostOperativeDiagnosis; public string PostOperativeDiagnosis { get { return _PostOperativeDiagnosis; } set { _PostOperativeDiagnosis = value; } }
    private string _TourniquetTime; public string TourniquetTime { get { return _TourniquetTime; } set { _TourniquetTime = value; } }
    private string _Surgeon; public string Surgeon { get { return _Surgeon; } set { _Surgeon = value; } }
    private string _SpecimenForwarded; public string SpecimenForwarded { get { return _SpecimenForwarded; } set { _SpecimenForwarded = value; } }
    private string _Deflate; public string Deflate { get { return _Deflate; } set { _Deflate = value; } }
    private string _BloodLoss; public string BloodLoss { get { return _BloodLoss; } set { _BloodLoss = value; } }

    private string _CystSize; public string CystSize { get { return _CystSize; } set { _CystSize = value; } }
    private string _Drained; public string Drained { get { return _Drained; } set { _Drained = value; } }
    private string _Oophorectomy; public string Oophorectomy { get { return _Oophorectomy; } set { _Oophorectomy = value; } }
    private string _Site; public string Site { get { return _Site; } set { _Site = value; } }
    private string _Resected; public string Resected { get { return _Resected; } set { _Resected = value; } }
    private string _Adhesions; public string Adhesions { get { return _Adhesions; } set { _Adhesions = value; } }


    private bool _Is_HysteroscopyNormal; public bool Is_HysteroscopyNormal { get { return _Is_HysteroscopyNormal; } set { _Is_HysteroscopyNormal = value; } }
    private string _HysteroscopyNormalRemark; public string HysteroscopyNormalRemark { get { return _HysteroscopyNormalRemark; } set { _HysteroscopyNormalRemark = value; } }
    private bool _Is_Adhesions; public bool Is_Adhesions { get { return _Is_Adhesions; } set { _Is_Adhesions = value; } }
    private bool _Is_SubmucousFibroids; public bool Is_SubmucousFibroids { get { return _Is_SubmucousFibroids; } set { _Is_SubmucousFibroids = value; } }
    private bool _Is_AnyIntervation; public bool Is_AnyIntervation { get { return _Is_AnyIntervation; } set { _Is_AnyIntervation = value; } }
    private string _HysteroscopyRemark; public string HysteroscopyRemark { get { return _HysteroscopyRemark; } set { _HysteroscopyRemark = value; } }

    private bool _Is_PelvicAnatomy; public bool Is_PelvicAnatomy { get { return _Is_PelvicAnatomy; } set { _Is_PelvicAnatomy = value; } }
    private bool _Is_Fibroids; public bool Is_Fibroids { get { return _Is_Fibroids; } set { _Is_Fibroids = value; } }
    private bool _Is_TubePatent; public bool Is_TubePatent { get { return _Is_TubePatent; } set { _Is_TubePatent = value; } }
    private string _TubePatentRemark; public string TubePatentRemark { get { return _TubePatentRemark; } set { _TubePatentRemark = value; } }
    private bool _Is_TubalAnatomy; public bool Is_TubalAnatomy { get { return _Is_TubalAnatomy; } set { _Is_TubalAnatomy = value; } }
    private string _LaparoscopyRemark; public string LaparoscopyRemark { get { return _LaparoscopyRemark; } set { _LaparoscopyRemark = value; } }

    private bool _Is_OvariesNormal; public bool Is_OvariesNormal { get { return _Is_OvariesNormal; } set { _Is_OvariesNormal = value; } }
    private bool _Is_PCO; public bool Is_PCO { get { return _Is_PCO; } set { _Is_PCO = value; } }
    private bool _Is_Cyst; public bool Is_Cyst { get { return _Is_Cyst; } set { _Is_Cyst = value; } }
    private bool _Is_Drilling; public bool Is_Drilling { get { return _Is_Drilling; } set { _Is_Drilling = value; } }
    private bool _Is_Endometriosis; public bool Is_Endometriosis { get { return _Is_Endometriosis; } set { _Is_Endometriosis = value; } }
    private string _OvariesRemark; public string OvariesRemark { get { return _OvariesRemark; } set { _OvariesRemark = value; } }
    private string _DrillingRemark; public string DrillingRemark { get { return _DrillingRemark; } set { _DrillingRemark = value; } }

    private string _Haemoperitonium; public string Haemoperitonium { get { return _Haemoperitonium; } set { _Haemoperitonium = value; } }
    private string _Side; public string Side { get { return _Side; } set { _Side = value; } }
    private string _Ruptured; public string Ruptured { get { return _Ruptured; } set { _Ruptured = value; } }
   // private string _Adhesions; public string Adhesions { get { return _Adhesions; } set { _Adhesions = value; } }
    private string _SpecimenRetrieval; public string SpecimenRetrieval { get { return _SpecimenRetrieval; } set { _SpecimenRetrieval = value; } }
    private string _Bloodclotssuctioned; public string Bloodclotssuctioned { get { return _Bloodclotssuctioned; } set { _Bloodclotssuctioned = value; } }

    private string _SizeofUterus; public string SizeofUterus { get { return _SizeofUterus; } set { _SizeofUterus = value; } }
    private string _Endometriosis; public string Endometriosis { get { return _Endometriosis; } set { _Endometriosis = value; } }
    private bool _Is_Oopherectomy; public bool Is_Oopherectomy { get { return _Is_Oopherectomy; } set { _Is_Oopherectomy = value; } }
    private bool _BladderChecked; public bool BladderChecked { get { return _BladderChecked; } set { _BladderChecked = value; } }
    private bool _BowelChecked; public bool BowelChecked { get { return _BowelChecked; } set { _BowelChecked = value; } }
    private string _MorcellatorUsed; public string MorcellatorUsed { get { return _MorcellatorUsed; } set { _MorcellatorUsed = value; } }
    private string _AdhesionsRemark; public string AdhesionsRemark { get { return _AdhesionsRemark; } set { _AdhesionsRemark = value; } }
    private string _EndometriosisRemark; public string EndometriosisRemark { get { return _EndometriosisRemark; } set { _EndometriosisRemark = value; } }

    private bool _Is_Fetaldistress; public bool Is_Fetaldistress { get { return _Is_Fetaldistress; } set { _Is_Fetaldistress = value; } }
    private bool _Is_CPDinLabour; public bool Is_CPDinLabour { get { return _Is_CPDinLabour; } set { _Is_CPDinLabour = value; } }
    private bool _Is_MaternalChoice; public bool Is_MaternalChoice { get { return _Is_MaternalChoice; } set { _Is_MaternalChoice = value; } }
    private bool _Is_MultiplePregnancy; public bool Is_MultiplePregnancy { get { return _Is_MultiplePregnancy; } set { _Is_MultiplePregnancy = value; } }
    private bool _Is_TwoPreviousLSCS; public bool Is_TwoPreviousLSCS { get { return _Is_TwoPreviousLSCS; } set { _Is_TwoPreviousLSCS = value; } }
    private bool _Is_NonProgressoflabour; public bool Is_NonProgressoflabour { get { return _Is_NonProgressoflabour; } set { _Is_NonProgressoflabour = value; } }
    private bool _Is_PreLSCSwithcomplication; public bool Is_PreLSCSwithcomplication { get { return _Is_PreLSCSwithcomplication; } set { _Is_PreLSCSwithcomplication = value; } }

    private string _LSCSPresentation1; public string LSCSPresentation1 { get { return _LSCSPresentation1; } set { _LSCSPresentation1 = value; } }
    private string _LSCSSex1; public string LSCSSex1 { get { return _LSCSSex1; } set { _LSCSSex1 = value; } }
    private string _LSCSApgar1; public string LSCSApgar1 { get { return _LSCSApgar1; } set { _LSCSApgar1 = value; } }

    private string _LSCSPresentation2; public string LSCSPresentation2 { get { return _LSCSPresentation2; } set { _LSCSPresentation2 = value; } }
    private string _LSCSSex2; public string LSCSSex2 { get { return _LSCSSex2; } set { _LSCSSex2 = value; } }
    private string _LSCSApgar2; public string LSCSApgar2 { get { return _LSCSApgar2; } set { _LSCSApgar2 = value; } }

    private string _LSCSPresentation3; public string LSCSPresentation3 { get { return _LSCSPresentation3; } set { _LSCSPresentation3 = value; } }
    private string _LSCSSex3; public string LSCSSex3 { get { return _LSCSSex3; } set { _LSCSSex3 = value; } }
    private string _LSCSApgar3; public string LSCSApgar3 { get { return _LSCSApgar3; } set { _LSCSApgar3 = value; } }

    private string _NoofFetuses; public string NoofFetuses { get { return _NoofFetuses; } set { _NoofFetuses = value; } }
    private string _PLACENTA; public string PLACENTA { get { return _PLACENTA; } set { _PLACENTA = value; } }
    private string _Intact; public string Intact { get { return _Intact; } set { _Intact = value; } }
    private string _BLADDER; public string BLADDER { get { return _BLADDER; } set { _BLADDER = value; } }
    private string _ADHESIONS; public string ADHESIONS { get { return _ADHESIONS; } set { _ADHESIONS = value; } }

    private string _Incision; public string Incision { get { return _Incision; } set { _Incision = value; } }
    private string _NumberofFibroids; public string NumberofFibroids { get { return _NumberofFibroids; } set { _NumberofFibroids = value; } }
    private string _LocationofFibroids; public string LocationofFibroids { get { return _LocationofFibroids; } set { _LocationofFibroids = value; } }
    private string _Opens; public string Opens { get { return _Opens; } set { _Opens = value; } }
    private string _Ovaries; public string Ovaries { get { return _Ovaries; } set { _Ovaries = value; } }

    private string _Tourniquet; public string Tourniquet { get { return _Tourniquet; } set { _Tourniquet = value; } }
    private string _Emdometrium; public string Emdometrium { get { return _Emdometrium; } set { _Emdometrium = value; } }
    private string _DropBox; public string DropBox { get { return _DropBox; } set { _DropBox = value; } }
    private string _Blocked; public string Blocked { get { return _Blocked; } set { _Blocked = value; } }
    private string _Drilled; public string Drilled { get { return _Drilled; } set { _Drilled = value; } }

    private string _TubesTested; public string TubesTested { get { return _TubesTested; } set { _TubesTested = value; } }
    private string _IntraUterineFoleys; public string IntraUterineFoleys { get { return _IntraUterineFoleys; } set { _IntraUterineFoleys = value; } }

    private string _STANDARDTAH; public string STANDARDTAH { get { return _STANDARDTAH; } set { _STANDARDTAH = value; } }
    private string _STANDARDTAH_R; public string STANDARDTAH_R { get { return _STANDARDTAH_R; } set { _STANDARDTAH_R = value; } }
    private string _UTERINESIZEINWEEK; public string UTERINESIZEINWEEK { get { return _UTERINESIZEINWEEK; } set { _UTERINESIZEINWEEK = value; } }
    private string _ENDOMETRIOSIS; public string ENDOMETRIOSIS { get { return _ENDOMETRIOSIS; } set { _ENDOMETRIOSIS = value; } }
    private string _OOPHORECTOMY; public string OOPHORECTOMY { get { return _OOPHORECTOMY; } set { _OOPHORECTOMY = value; } }


    private string _UterineSize; public string UterineSize { get { return _UterineSize; } set { _UterineSize = value; } }
    private bool _Is_Cystocele; public bool Is_Cystocele { get { return _Is_Cystocele; } set { _Is_Cystocele = value; } }
    private bool _Is_Rectocele; public bool Is_Rectocele { get { return _Is_Rectocele; } set { _Is_Rectocele = value; } }
    private string _CystoceleRemark; public string CystoceleRemark { get { return _CystoceleRemark; } set { _CystoceleRemark = value; } }
    private string _RectoceleRemark; public string RectoceleRemark { get { return _RectoceleRemark; } set { _RectoceleRemark = value; } }
    private string _OophrectomyRemark; public string OophrectomyRemark { get { return _OophrectomyRemark; } set { _OophrectomyRemark = value; } }
    private string _Procedure; public string Procedure { get { return _Procedure; } set { _Procedure = value; } }

    private bool _Is_CystoceleRepaired; public bool Is_CystoceleRepaired { get { return _Is_CystoceleRepaired; } set { _Is_CystoceleRepaired = value; } }
    private bool _Is_RectoceleRepaired; public bool Is_RectoceleRepaired { get { return _Is_RectoceleRepaired; } set { _Is_RectoceleRepaired = value; } }
    private bool _Is_LevatorplastyDone; public bool Is_LevatorplastyDone { get { return _Is_LevatorplastyDone; } set { _Is_LevatorplastyDone = value; } }
    private bool _Is_SacrospinouspexyDone; public bool Is_SacrospinouspexyDone { get { return _Is_SacrospinouspexyDone; } set { _Is_SacrospinouspexyDone = value; } }
    private bool _Is_PackInserted; public bool Is_PackInserted { get { return _Is_PackInserted; } set { _Is_PackInserted = value; } }

    private string _Fibroids; public string Fibroids { get { return _Fibroids; } set { _Fibroids = value; } }
    private string _Numbers; public string Numbers { get { return _Numbers; } set { _Numbers = value; } }
    private string _Location; public string Location { get { return _Location; } set { _Location = value; } }
    private string _LocationSize; public string LocationSize { get { return _LocationSize; } set { _LocationSize = value; } }
    private string _Septum; public string Septum { get { return _Septum; } set { _Septum = value; } }

    private bool _Is_FibroidResection; public bool Is_FibroidResection { get { return _Is_FibroidResection; } set { _Is_FibroidResection = value; } }
    private bool _Is_SeptalResection; public bool Is_SeptalResection { get { return _Is_SeptalResection; } set { _Is_SeptalResection = value; } }
    private bool _Is_Adhesiolysis; public bool Is_Adhesiolysis { get { return _Is_Adhesiolysis; } set { _Is_Adhesiolysis = value; } }

    private string _Oophrectomy; public string Oophrectomy { get { return _Oophrectomy; } set { _Oophrectomy = value; } }
    private string _PackInserted; public string PackInserted { get { return _PackInserted; } set { _PackInserted = value; } }

    private string _ProcedureType; public string ProcedureType { get { return _ProcedureType; } set { _ProcedureType = value; } }
    private string _ProcedurePerformed; public string ProcedurePerformed { get { return _ProcedurePerformed; } set { _ProcedurePerformed = value; } }
    private string _Endoscopist; public string Endoscopist { get { return _Endoscopist; } set { _Endoscopist = value; } }
    private string _Anaesthesia; public string Anaesthesia { get { return _Anaesthesia; } set { _Anaesthesia = value; } }
    private string _Instrument; public string Instrument { get { return _Instrument; } set { _Instrument = value; } }
    private string _IndicationofProcedure; public string IndicationofProcedure { get { return _IndicationofProcedure; } set { _IndicationofProcedure = value; } }
    private string _DescriptionOfProcedure; public string DescriptionOfProcedure { get { return _DescriptionOfProcedure; } set { _DescriptionOfProcedure = value; } }
    private string _Complications; public string Complications { get { return _Complications; } set { _Complications = value; } }
    private string _Impression; public string Impression { get { return _Impression; } set { _Impression = value; } }

    private string _SlidingScaleInsulin; public string SlidingScaleInsulin { get { return _SlidingScaleInsulin; } set { _SlidingScaleInsulin = value; } }
    
    
    public DataTable GetMedicalRecod_PatientInfo(int Patregid)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlDataAdapter sda = new SqlDataAdapter("SELECT        PatientInformation.PatientInfoId, PatientInformation.PatRegId, PatientInformation.BarcodeId, PatientInformation.TitleId, PatientInformation.FirstName, PatientInformation.MiddleName, PatientInformation.LastName, "+
                         "   PatientInformation.PatMainTypeId, PatientInformation.PatientInsuTypeId, PatientInformation.PolicyNo, PatientInformation.GenderId, PatientInformation.BirthDate, PatientInformation.IsConfirmBirthDate, "+
                         "   PatientInformation.BloodGroup, PatientInformation.MaritalStatus, PatientInformation.GuardianTitleId, PatientInformation.GuardianName, PatientInformation.MobileNo, PatientInformation.PhoneNo, "+
                         "   PatientInformation.PatientAddress, PatientInformation.CountryId, PatientInformation.StateId, PatientInformation.CityId, PatientInformation.Email, PatientInformation.EntryDate, PatientInformation.ImagePath, "+
                         "   PatientInformation.CancelReason, PatientInformation.IsActive, PatientInformation.CreatedBy, PatientInformation.CreatedOn, PatientInformation.UpdatedBy, PatientInformation.UpdatedOn, PatientInformation.Age, "+
                         "   PatientInformation.AgeType, PatientInformation.BranchId, PatientInformation.FId, PatientInformation.Nationality, PatientInformation.BirthPlace, PatientInformation.RaceId, PatientInformation.ReligionId, "+
                         "   PatientInformation.HealthCardNo, PatientInformation.PassportNo, PatientInformation.VaccinationStatus, PatientInformation.Allergy, PatientInformation.ChiefComplant, Gender.GenderName "+
                         "   FROM            PatientInformation INNER JOIN "+
                         "   Gender ON PatientInformation.GenderId = Gender.GenderId where PatientInformation.PatRegId=" + Patregid + " ", con);
        DataTable ds = new DataTable();
        try
        {
            sda.Fill(ds);
        }
        catch (SqlException)
        {
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();

        }
        return ds;
    }
    public void Insert_CaesareanSection()
    {

        SqlConnection conn = DataAccess.ConInitForDC();
        SqlCommand sc = new SqlCommand();
        sc.CommandType = CommandType.StoredProcedure;
        sc.Connection = conn;
        sc.CommandText = "SP_Insert_CaesareanSection";
        sc.Parameters.Add(new SqlParameter("@Patregid", SqlDbType.Int)).Value = Patregid;
        sc.Parameters.Add(new SqlParameter("@OPDNO", SqlDbType.Int)).Value = OPDNO;
        sc.Parameters.Add(new SqlParameter("@IPDNO", SqlDbType.Int)).Value = IPDNO;
       
        sc.Parameters.Add(new SqlParameter("@NPO", SqlDbType.NVarChar, 200)).Value = NPO;
        sc.Parameters.Add(new SqlParameter("@NPORemark", SqlDbType.NVarChar, 550)).Value = NPORemark;

        if (this.EntryDate == Date.getMinDate())
            sc.Parameters.Add(new SqlParameter("@EntryDate", SqlDbType.DateTime)).Value = DBNull.Value;
        else
            sc.Parameters.Add(new SqlParameter("@EntryDate", SqlDbType.DateTime)).Value = EntryDate;

        sc.Parameters.Add(new SqlParameter("@Medication", SqlDbType.NVarChar, 200)).Value = Medication;

        sc.Parameters.Add(new SqlParameter("@SugarMonitoring", SqlDbType.NVarChar, 200)).Value = SugarMonitoring;
        sc.Parameters.Add(new SqlParameter("@Sliding ", SqlDbType.NVarChar, 50)).Value = Sliding;
        sc.Parameters.Add(new SqlParameter("@Notes", SqlDbType.NVarChar, 4000)).Value = Notes;
        sc.Parameters.Add(new SqlParameter("@CreatedBy", SqlDbType.NVarChar, 250)).Value = P_CreatedBy;
        sc.Parameters.Add(new SqlParameter("@Branchid ", SqlDbType.Int)).Value = Branchid;

       

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

    public void Alter_Casarean_Section_Report(int patregid,int OpdNo,int IpdNo)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Alter_VW_CaesareanSection_Report", con);
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

    public DataTable GetMedicalRecod_Info(int Patregid)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlDataAdapter sda = new SqlDataAdapter("SELECT      * from AddMedicalRecord  where PatRegId=" + Patregid + " ", con);
        DataTable ds = new DataTable();
        try
        {
            sda.Fill(ds);
        }
        catch (SqlException)
        {
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();

        }
        return ds;
    }

    public DataTable GetMedical_CountNoOfFile(int Patregid)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlDataAdapter sda = new SqlDataAdapter("select count(MedicalId)+1 as RecordCount from AddMedicalRecord where PatientType='IPD'  and PatRegId=" + Patregid + " ", con);
        DataTable ds = new DataTable();
        try
        {
            sda.Fill(ds);
        }
        catch (SqlException)
        {
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();

        }
        return ds;
    }

    public void Delete_AddMedicalRecord(string MedicalId)
    {
        SqlConnection conn = DataAccess.ConInitForDC();

        SqlCommand sc = new SqlCommand("delete from AddMedicalRecord where MedicalId='" + MedicalId + "' ", conn);

        try
        {
            conn.Open();
            sc.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw;
        }
        finally
        {
            try
            {
                conn.Close(); conn.Dispose();
            }
            catch (SqlException)
            {
                throw;
            }

        }
    }

    public void Insert_Laparoscopic_Cyste_Section()
    {

        SqlConnection conn = DataAccess.ConInitForDC();
        SqlCommand sc = new SqlCommand();
        sc.CommandType = CommandType.StoredProcedure;
        sc.Connection = conn;
        sc.CommandText = "SP_InsertLaparoscopic_Cyste_Section";
        sc.Parameters.Add(new SqlParameter("@Patregid", SqlDbType.Int)).Value = Patregid;
        sc.Parameters.Add(new SqlParameter("@OPDNO", SqlDbType.Int)).Value = OPDNO;
        sc.Parameters.Add(new SqlParameter("@IPDNO", SqlDbType.Int)).Value = IPDNO;

        if (this.OperationDate == Date.getMinDate())
            sc.Parameters.Add(new SqlParameter("@DateOfOperation", SqlDbType.DateTime)).Value = DBNull.Value;
        else
            sc.Parameters.Add(new SqlParameter("@DateOfOperation", SqlDbType.DateTime)).Value = OperationDate;

        if (this.EntryDate == Date.getMinDate())
            sc.Parameters.Add(new SqlParameter("@NoteDate", SqlDbType.DateTime)).Value = DBNull.Value;
        else
            sc.Parameters.Add(new SqlParameter("@NoteDate", SqlDbType.DateTime)).Value = EntryDate;

        sc.Parameters.Add(new SqlParameter("@Schedule", SqlDbType.NVarChar, 550)).Value = Schedule;
        sc.Parameters.Add(new SqlParameter("@OperativeProcedure", SqlDbType.NVarChar, 550)).Value = OperativeProcedure;
        sc.Parameters.Add(new SqlParameter("@PreOperativeDiagnosis ", SqlDbType.NVarChar, 550)).Value = PreOperativeDiagnosis;
        sc.Parameters.Add(new SqlParameter("@DurationofSurgery", SqlDbType.NVarChar, 550)).Value = DurationofSurgery;

        sc.Parameters.Add(new SqlParameter("@PostOperativeAnaesthetist", SqlDbType.NVarChar, 550)).Value = PostOperativeAnaesthetist;
        sc.Parameters.Add(new SqlParameter("@SwabCount", SqlDbType.NVarChar, 550)).Value = SwabCount;
        sc.Parameters.Add(new SqlParameter("@Inflate ", SqlDbType.NVarChar, 550)).Value = Inflate;
        sc.Parameters.Add(new SqlParameter("@ScrubNurse", SqlDbType.NVarChar, 550)).Value = ScrubNurse;

        sc.Parameters.Add(new SqlParameter("@OperationFindings", SqlDbType.NVarChar, 550)).Value = OperationFindings;
        sc.Parameters.Add(new SqlParameter("@Drains", SqlDbType.NVarChar, 550)).Value = Drains;
        sc.Parameters.Add(new SqlParameter("@Anaesthetist ", SqlDbType.NVarChar, 550)).Value = Anaesthetist;
        sc.Parameters.Add(new SqlParameter("@PostOperativeDiagnosis", SqlDbType.NVarChar, 550)).Value = PostOperativeDiagnosis;

        sc.Parameters.Add(new SqlParameter("@TourniquetTime", SqlDbType.NVarChar, 550)).Value = TourniquetTime;
        sc.Parameters.Add(new SqlParameter("@Surgeon", SqlDbType.NVarChar, 550)).Value = Surgeon;
        sc.Parameters.Add(new SqlParameter("@SpecimenForwarded ", SqlDbType.NVarChar, 550)).Value = SpecimenForwarded;
        sc.Parameters.Add(new SqlParameter("@Deflate", SqlDbType.NVarChar, 550)).Value = Deflate;

        sc.Parameters.Add(new SqlParameter("@BloodLoss", SqlDbType.NVarChar, 550)).Value = BloodLoss;
        sc.Parameters.Add(new SqlParameter("@CystSize", SqlDbType.NVarChar, 550)).Value = CystSize;
        sc.Parameters.Add(new SqlParameter("@Drained ", SqlDbType.NVarChar, 550)).Value = Drained;
        sc.Parameters.Add(new SqlParameter("@Oophorectomy", SqlDbType.NVarChar, 550)).Value = Oophorectomy;

        sc.Parameters.Add(new SqlParameter("@Site", SqlDbType.NVarChar, 550)).Value = Site;
        sc.Parameters.Add(new SqlParameter("@Resected", SqlDbType.NVarChar, 550)).Value = Resected;
        sc.Parameters.Add(new SqlParameter("@Adhesions ", SqlDbType.NVarChar, 550)).Value = Adhesions;
        sc.Parameters.Add(new SqlParameter("@Comments ", SqlDbType.NVarChar, 550)).Value = Notes;
       

        sc.Parameters.Add(new SqlParameter("@CreatedBy", SqlDbType.NVarChar, 250)).Value = P_CreatedBy;
        sc.Parameters.Add(new SqlParameter("@Branchid ", SqlDbType.Int)).Value = Branchid;



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

    public void Alter_Laparoscopic_Cyste_Section_Report(int patregid, int OpdNo, int IpdNo)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Alter_VW_Laparoscopic_Cyste_Section_Report", con);
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

    public void Insert_Diagnostic_Cyste_Section()
    {

        SqlConnection conn = DataAccess.ConInitForDC();
        SqlCommand sc = new SqlCommand();
        sc.CommandType = CommandType.StoredProcedure;
        sc.Connection = conn;
        sc.CommandText = "SP_Insert_Diagnostic_Cyste_Section";
        sc.Parameters.Add(new SqlParameter("@Patregid", SqlDbType.Int)).Value = Patregid;
        sc.Parameters.Add(new SqlParameter("@OPDNO", SqlDbType.Int)).Value = OPDNO;
        sc.Parameters.Add(new SqlParameter("@IPDNO", SqlDbType.Int)).Value = IPDNO;

        if (this.OperationDate == Date.getMinDate())
            sc.Parameters.Add(new SqlParameter("@DateOfOperation", SqlDbType.DateTime)).Value = DBNull.Value;
        else
            sc.Parameters.Add(new SqlParameter("@DateOfOperation", SqlDbType.DateTime)).Value = OperationDate;

        if (this.EntryDate == Date.getMinDate())
            sc.Parameters.Add(new SqlParameter("@NoteDate", SqlDbType.DateTime)).Value = DBNull.Value;
        else
            sc.Parameters.Add(new SqlParameter("@NoteDate", SqlDbType.DateTime)).Value = EntryDate;

        sc.Parameters.Add(new SqlParameter("@Schedule", SqlDbType.NVarChar, 550)).Value = Schedule;
        sc.Parameters.Add(new SqlParameter("@OperativeProcedure", SqlDbType.NVarChar, 550)).Value = OperativeProcedure;
        sc.Parameters.Add(new SqlParameter("@PreOperativeDiagnosis ", SqlDbType.NVarChar, 550)).Value = PreOperativeDiagnosis;
        sc.Parameters.Add(new SqlParameter("@DurationofSurgery", SqlDbType.NVarChar, 550)).Value = DurationofSurgery;

        sc.Parameters.Add(new SqlParameter("@PostOperativeAnaesthetist", SqlDbType.NVarChar, 550)).Value = PostOperativeAnaesthetist;
        sc.Parameters.Add(new SqlParameter("@SwabCount", SqlDbType.NVarChar, 550)).Value = SwabCount;
        sc.Parameters.Add(new SqlParameter("@Inflate ", SqlDbType.NVarChar, 550)).Value = Inflate;
        sc.Parameters.Add(new SqlParameter("@ScrubNurse", SqlDbType.NVarChar, 550)).Value = ScrubNurse;

        sc.Parameters.Add(new SqlParameter("@OperationFindings", SqlDbType.NVarChar, 550)).Value = OperationFindings;
        sc.Parameters.Add(new SqlParameter("@Drains", SqlDbType.NVarChar, 550)).Value = Drains;
        sc.Parameters.Add(new SqlParameter("@Anaesthetist ", SqlDbType.NVarChar, 550)).Value = Anaesthetist;
        sc.Parameters.Add(new SqlParameter("@PostOperativeDiagnosis", SqlDbType.NVarChar, 550)).Value = PostOperativeDiagnosis;

        sc.Parameters.Add(new SqlParameter("@TourniquetTime", SqlDbType.NVarChar, 550)).Value = TourniquetTime;
        sc.Parameters.Add(new SqlParameter("@Surgeon", SqlDbType.NVarChar, 550)).Value = Surgeon;
        sc.Parameters.Add(new SqlParameter("@SpecimenForwarded ", SqlDbType.NVarChar, 550)).Value = SpecimenForwarded;
        sc.Parameters.Add(new SqlParameter("@Deflate", SqlDbType.NVarChar, 550)).Value = Deflate;

        sc.Parameters.Add(new SqlParameter("@BloodLoss", SqlDbType.NVarChar, 550)).Value = BloodLoss;


        sc.Parameters.Add(new SqlParameter("@Is_HysteroscopyNormal", SqlDbType.Bit)).Value = Is_HysteroscopyNormal;
        sc.Parameters.Add(new SqlParameter("@HysteroscopyNormalRemark ", SqlDbType.NVarChar, 50)).Value = HysteroscopyNormalRemark;
        sc.Parameters.Add(new SqlParameter("@Is_Adhesions", SqlDbType.Bit)).Value = Is_Adhesions;

        sc.Parameters.Add(new SqlParameter("@Is_SubmucousFibroids", SqlDbType.Bit)).Value = Is_SubmucousFibroids;
        sc.Parameters.Add(new SqlParameter("@Is_AnyIntervation", SqlDbType.Bit)).Value = Is_AnyIntervation;
        sc.Parameters.Add(new SqlParameter("@HysteroscopyRemark ", SqlDbType.NVarChar, 550)).Value = HysteroscopyRemark;

        sc.Parameters.Add(new SqlParameter("@Is_PelvicAnatomy", SqlDbType.Bit)).Value = Is_PelvicAnatomy;
        sc.Parameters.Add(new SqlParameter("@TubePatentRemark ", SqlDbType.NVarChar, 50)).Value = TubePatentRemark;
        sc.Parameters.Add(new SqlParameter("@Is_Fibroids", SqlDbType.Bit)).Value = Is_Fibroids;
        sc.Parameters.Add(new SqlParameter("@Is_TubePatent", SqlDbType.Bit)).Value = Is_TubePatent;
        sc.Parameters.Add(new SqlParameter("@Is_TubalAnatomy", SqlDbType.Bit)).Value = Is_TubalAnatomy;
        sc.Parameters.Add(new SqlParameter("@LaparoscopyRemark ", SqlDbType.NVarChar, 550)).Value = LaparoscopyRemark;

        sc.Parameters.Add(new SqlParameter("@Is_OvariesNormal", SqlDbType.Bit)).Value = Is_OvariesNormal;
        sc.Parameters.Add(new SqlParameter("@DrillingRemark ", SqlDbType.NVarChar, 50)).Value = DrillingRemark;
        sc.Parameters.Add(new SqlParameter("@Is_PCO", SqlDbType.Bit)).Value = Is_PCO;
        sc.Parameters.Add(new SqlParameter("@Is_Cyst", SqlDbType.Bit)).Value = Is_Cyst;
        sc.Parameters.Add(new SqlParameter("@Is_Drilling", SqlDbType.Bit)).Value = Is_Drilling;
        sc.Parameters.Add(new SqlParameter("@Is_Endometriosis", SqlDbType.Bit)).Value = Is_Endometriosis;
        sc.Parameters.Add(new SqlParameter("@OvariesRemark ", SqlDbType.NVarChar, 550)).Value = OvariesRemark;
        


        sc.Parameters.Add(new SqlParameter("@CreatedBy", SqlDbType.NVarChar, 250)).Value = P_CreatedBy;
        sc.Parameters.Add(new SqlParameter("@Branchid ", SqlDbType.Int)).Value = Branchid;



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

    public void Alter_Diagnostic_Cyste_Section_Report(int patregid, int OpdNo, int IpdNo)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Alter_VW_Diagnostic_Cyste_Section_Report", con);
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


    public void Insert_LaparoscopicEctopic_Section()
    {

        SqlConnection conn = DataAccess.ConInitForDC();
        SqlCommand sc = new SqlCommand();
        sc.CommandType = CommandType.StoredProcedure;
        sc.Connection = conn;
        sc.CommandText = "SP_Insert_LaparoscopicEctopic_Section";
        sc.Parameters.Add(new SqlParameter("@Patregid", SqlDbType.Int)).Value = Patregid;
        sc.Parameters.Add(new SqlParameter("@OPDNO", SqlDbType.Int)).Value = OPDNO;
        sc.Parameters.Add(new SqlParameter("@IPDNO", SqlDbType.Int)).Value = IPDNO;

        if (this.OperationDate == Date.getMinDate())
            sc.Parameters.Add(new SqlParameter("@DateOfOperation", SqlDbType.DateTime)).Value = DBNull.Value;
        else
            sc.Parameters.Add(new SqlParameter("@DateOfOperation", SqlDbType.DateTime)).Value = OperationDate;

        if (this.EntryDate == Date.getMinDate())
            sc.Parameters.Add(new SqlParameter("@NoteDate", SqlDbType.DateTime)).Value = DBNull.Value;
        else
            sc.Parameters.Add(new SqlParameter("@NoteDate", SqlDbType.DateTime)).Value = EntryDate;

        sc.Parameters.Add(new SqlParameter("@Schedule", SqlDbType.NVarChar, 550)).Value = Schedule;
        sc.Parameters.Add(new SqlParameter("@OperativeProcedure", SqlDbType.NVarChar, 550)).Value = OperativeProcedure;
        sc.Parameters.Add(new SqlParameter("@PreOperativeDiagnosis ", SqlDbType.NVarChar, 550)).Value = PreOperativeDiagnosis;
        sc.Parameters.Add(new SqlParameter("@DurationofSurgery", SqlDbType.NVarChar, 550)).Value = DurationofSurgery;

        sc.Parameters.Add(new SqlParameter("@PostOperativeAnaesthetist", SqlDbType.NVarChar, 550)).Value = PostOperativeAnaesthetist;
        sc.Parameters.Add(new SqlParameter("@SwabCount", SqlDbType.NVarChar, 550)).Value = SwabCount;
        sc.Parameters.Add(new SqlParameter("@Inflate ", SqlDbType.NVarChar, 550)).Value = Inflate;
        sc.Parameters.Add(new SqlParameter("@ScrubNurse", SqlDbType.NVarChar, 550)).Value = ScrubNurse;

        sc.Parameters.Add(new SqlParameter("@OperationFindings", SqlDbType.NVarChar, 550)).Value = OperationFindings;
        sc.Parameters.Add(new SqlParameter("@Drains", SqlDbType.NVarChar, 550)).Value = Drains;
        sc.Parameters.Add(new SqlParameter("@Anaesthetist ", SqlDbType.NVarChar, 550)).Value = Anaesthetist;
        sc.Parameters.Add(new SqlParameter("@PostOperativeDiagnosis", SqlDbType.NVarChar, 550)).Value = PostOperativeDiagnosis;

        sc.Parameters.Add(new SqlParameter("@TourniquetTime", SqlDbType.NVarChar, 550)).Value = TourniquetTime;
        sc.Parameters.Add(new SqlParameter("@Surgeon", SqlDbType.NVarChar, 550)).Value = Surgeon;
        sc.Parameters.Add(new SqlParameter("@SpecimenForwarded ", SqlDbType.NVarChar, 550)).Value = SpecimenForwarded;
        sc.Parameters.Add(new SqlParameter("@Deflate", SqlDbType.NVarChar, 550)).Value = Deflate;

        sc.Parameters.Add(new SqlParameter("@BloodLoss", SqlDbType.NVarChar, 550)).Value = BloodLoss;
      
        sc.Parameters.Add(new SqlParameter("@Haemoperitonium ", SqlDbType.NVarChar, 50)).Value = Haemoperitonium;

        sc.Parameters.Add(new SqlParameter("@Side ", SqlDbType.NVarChar, 550)).Value = Side;
        sc.Parameters.Add(new SqlParameter("@Ruptured ", SqlDbType.NVarChar, 50)).Value = Ruptured;

        sc.Parameters.Add(new SqlParameter("@Adhesions ", SqlDbType.NVarChar, 550)).Value = Adhesions;      
        sc.Parameters.Add(new SqlParameter("@SpecimenRetrieval ", SqlDbType.NVarChar, 50)).Value = SpecimenRetrieval;

        sc.Parameters.Add(new SqlParameter("@Bloodclotssuctioned ", SqlDbType.NVarChar, 550)).Value = Bloodclotssuctioned;
        sc.Parameters.Add(new SqlParameter("@Comments ", SqlDbType.NVarChar, 550)).Value = Notes;

        sc.Parameters.Add(new SqlParameter("@CreatedBy", SqlDbType.NVarChar, 250)).Value = P_CreatedBy;
        sc.Parameters.Add(new SqlParameter("@Branchid ", SqlDbType.Int)).Value = Branchid;



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

    public void Alter_LaparoscopicEctopic_Section_Report(int patregid, int OpdNo, int IpdNo)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Alter_VW_LaparoscopicEctopic_Section_Report", con);
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

    public void Insert_Hysterectomy_Section()
    {

        SqlConnection conn = DataAccess.ConInitForDC();
        SqlCommand sc = new SqlCommand();
        sc.CommandType = CommandType.StoredProcedure;
        sc.Connection = conn;
        sc.CommandText = "SP_Insert_LaparoscopicHysterectomy_Section";
        sc.Parameters.Add(new SqlParameter("@Patregid", SqlDbType.Int)).Value = Patregid;
        sc.Parameters.Add(new SqlParameter("@OPDNO", SqlDbType.Int)).Value = OPDNO;
        sc.Parameters.Add(new SqlParameter("@IPDNO", SqlDbType.Int)).Value = IPDNO;

        if (this.OperationDate == Date.getMinDate())
            sc.Parameters.Add(new SqlParameter("@DateOfOperation", SqlDbType.DateTime)).Value = DBNull.Value;
        else
            sc.Parameters.Add(new SqlParameter("@DateOfOperation", SqlDbType.DateTime)).Value = OperationDate;

        if (this.EntryDate == Date.getMinDate())
            sc.Parameters.Add(new SqlParameter("@NoteDate", SqlDbType.DateTime)).Value = DBNull.Value;
        else
            sc.Parameters.Add(new SqlParameter("@NoteDate", SqlDbType.DateTime)).Value = EntryDate;

        sc.Parameters.Add(new SqlParameter("@Schedule", SqlDbType.NVarChar, 550)).Value = Schedule;
        sc.Parameters.Add(new SqlParameter("@OperativeProcedure", SqlDbType.NVarChar, 550)).Value = OperativeProcedure;
        sc.Parameters.Add(new SqlParameter("@PreOperativeDiagnosis ", SqlDbType.NVarChar, 550)).Value = PreOperativeDiagnosis;
        sc.Parameters.Add(new SqlParameter("@DurationofSurgery", SqlDbType.NVarChar, 550)).Value = DurationofSurgery;

        sc.Parameters.Add(new SqlParameter("@PostOperativeAnaesthetist", SqlDbType.NVarChar, 550)).Value = PostOperativeAnaesthetist;
        sc.Parameters.Add(new SqlParameter("@SwabCount", SqlDbType.NVarChar, 550)).Value = SwabCount;
        sc.Parameters.Add(new SqlParameter("@Inflate ", SqlDbType.NVarChar, 550)).Value = Inflate;
        sc.Parameters.Add(new SqlParameter("@ScrubNurse", SqlDbType.NVarChar, 550)).Value = ScrubNurse;

        sc.Parameters.Add(new SqlParameter("@OperationFindings", SqlDbType.NVarChar, 550)).Value = OperationFindings;
        sc.Parameters.Add(new SqlParameter("@Drains", SqlDbType.NVarChar, 550)).Value = Drains;
        sc.Parameters.Add(new SqlParameter("@Anaesthetist ", SqlDbType.NVarChar, 550)).Value = Anaesthetist;
        sc.Parameters.Add(new SqlParameter("@PostOperativeDiagnosis", SqlDbType.NVarChar, 550)).Value = PostOperativeDiagnosis;

        sc.Parameters.Add(new SqlParameter("@TourniquetTime", SqlDbType.NVarChar, 550)).Value = TourniquetTime;
        sc.Parameters.Add(new SqlParameter("@Surgeon", SqlDbType.NVarChar, 550)).Value = Surgeon;
        sc.Parameters.Add(new SqlParameter("@SpecimenForwarded ", SqlDbType.NVarChar, 550)).Value = SpecimenForwarded;
        sc.Parameters.Add(new SqlParameter("@Deflate", SqlDbType.NVarChar, 550)).Value = Deflate;

        sc.Parameters.Add(new SqlParameter("@BloodLoss", SqlDbType.NVarChar, 550)).Value = BloodLoss;

        sc.Parameters.Add(new SqlParameter("@SizeofUterus", SqlDbType.NVarChar, 50)).Value = SizeofUterus;

        sc.Parameters.Add(new SqlParameter("@Adhesions", SqlDbType.Bit)).Value = Is_Adhesions;
        sc.Parameters.Add(new SqlParameter("@AdhesionsRemark", SqlDbType.NVarChar, 50)).Value = AdhesionsRemark;

        sc.Parameters.Add(new SqlParameter("@Endometriosis", SqlDbType.Bit)).Value = Is_Endometriosis;
        sc.Parameters.Add(new SqlParameter("@EndometriosisRemark", SqlDbType.NVarChar, 50)).Value = EndometriosisRemark;

        sc.Parameters.Add(new SqlParameter("@Oopherectomy", SqlDbType.Bit)).Value = Is_Oopherectomy;
        sc.Parameters.Add(new SqlParameter("@BladderChecked", SqlDbType.Bit)).Value = BladderChecked;
        sc.Parameters.Add(new SqlParameter("@BowelChecked", SqlDbType.Bit)).Value = BowelChecked;
        sc.Parameters.Add(new SqlParameter("@MorcellatorUsed", SqlDbType.NVarChar, 550)).Value = MorcellatorUsed;
        sc.Parameters.Add(new SqlParameter("@Comments", SqlDbType.NVarChar, 550)).Value = Notes;

        sc.Parameters.Add(new SqlParameter("@CreatedBy", SqlDbType.NVarChar, 250)).Value = P_CreatedBy;
        sc.Parameters.Add(new SqlParameter("@Branchid", SqlDbType.Int)).Value = Branchid;



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

    public void Alter_Hysterectomy_Section_Report(int patregid, int OpdNo, int IpdNo)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Alter_VW_LaparoscopicHysterectomy_Section_Report", con);
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

    public void Insert_LSCH_Section()
    {

        SqlConnection conn = DataAccess.ConInitForDC();
        SqlCommand sc = new SqlCommand();
        sc.CommandType = CommandType.StoredProcedure;
        sc.Connection = conn;
        sc.CommandText = "SP_Insert_LSCH_Section";
        sc.Parameters.Add(new SqlParameter("@Patregid", SqlDbType.Int)).Value = Patregid;
        sc.Parameters.Add(new SqlParameter("@OPDNO", SqlDbType.Int)).Value = OPDNO;
        sc.Parameters.Add(new SqlParameter("@IPDNO", SqlDbType.Int)).Value = IPDNO;

        if (this.OperationDate == Date.getMinDate())
            sc.Parameters.Add(new SqlParameter("@DateOfOperation", SqlDbType.DateTime)).Value = DBNull.Value;
        else
            sc.Parameters.Add(new SqlParameter("@DateOfOperation", SqlDbType.DateTime)).Value = OperationDate;

        if (this.EntryDate == Date.getMinDate())
            sc.Parameters.Add(new SqlParameter("@NoteDate", SqlDbType.DateTime)).Value = DBNull.Value;
        else
            sc.Parameters.Add(new SqlParameter("@NoteDate", SqlDbType.DateTime)).Value = EntryDate;

        sc.Parameters.Add(new SqlParameter("@Schedule", SqlDbType.NVarChar, 550)).Value = Schedule;
        sc.Parameters.Add(new SqlParameter("@OperativeProcedure", SqlDbType.NVarChar, 550)).Value = OperativeProcedure;
        sc.Parameters.Add(new SqlParameter("@PreOperativeDiagnosis ", SqlDbType.NVarChar, 550)).Value = PreOperativeDiagnosis;
        sc.Parameters.Add(new SqlParameter("@DurationofSurgery", SqlDbType.NVarChar, 550)).Value = DurationofSurgery;

        sc.Parameters.Add(new SqlParameter("@PostOperativeAnaesthetist", SqlDbType.NVarChar, 550)).Value = PostOperativeAnaesthetist;
        sc.Parameters.Add(new SqlParameter("@SwabCount", SqlDbType.NVarChar, 550)).Value = SwabCount;
        sc.Parameters.Add(new SqlParameter("@Inflate", SqlDbType.NVarChar, 550)).Value = Inflate;
        sc.Parameters.Add(new SqlParameter("@ScrubNurse", SqlDbType.NVarChar, 550)).Value = ScrubNurse;

        sc.Parameters.Add(new SqlParameter("@OperationFindings", SqlDbType.NVarChar, 550)).Value = OperationFindings;
        sc.Parameters.Add(new SqlParameter("@Drains", SqlDbType.NVarChar, 550)).Value = Drains;
        sc.Parameters.Add(new SqlParameter("@Anaesthetist", SqlDbType.NVarChar, 550)).Value = Anaesthetist;
        sc.Parameters.Add(new SqlParameter("@PostOperativeDiagnosis", SqlDbType.NVarChar, 550)).Value = PostOperativeDiagnosis;

        sc.Parameters.Add(new SqlParameter("@TourniquetTime", SqlDbType.NVarChar, 550)).Value = TourniquetTime;
        sc.Parameters.Add(new SqlParameter("@Surgeon", SqlDbType.NVarChar, 550)).Value = Surgeon;
        sc.Parameters.Add(new SqlParameter("@SpecimenForwarded", SqlDbType.NVarChar, 550)).Value = SpecimenForwarded;
        sc.Parameters.Add(new SqlParameter("@Deflate", SqlDbType.NVarChar, 550)).Value = Deflate;

        sc.Parameters.Add(new SqlParameter("@BloodLoss", SqlDbType.NVarChar, 550)).Value = BloodLoss;

        sc.Parameters.Add(new SqlParameter("@Fetaldistress", SqlDbType.Bit)).Value = Is_Fetaldistress;
        sc.Parameters.Add(new SqlParameter("@CPDinLabour", SqlDbType.Bit)).Value = Is_CPDinLabour;
        sc.Parameters.Add(new SqlParameter("@MaternalChoice", SqlDbType.Bit)).Value = Is_MaternalChoice;
        sc.Parameters.Add(new SqlParameter("@MultiplePregnancy", SqlDbType.Bit)).Value = Is_MultiplePregnancy;
        sc.Parameters.Add(new SqlParameter("@TwoPreviousLSCS", SqlDbType.Bit)).Value = Is_TwoPreviousLSCS;
        sc.Parameters.Add(new SqlParameter("@NonProgressoflabour", SqlDbType.Bit)).Value = Is_NonProgressoflabour;
        sc.Parameters.Add(new SqlParameter("@PreLSCSwithcomplication", SqlDbType.Bit)).Value = Is_PreLSCSwithcomplication;

        sc.Parameters.Add(new SqlParameter("@LSCSPresentation1", SqlDbType.NVarChar, 50)).Value = LSCSPresentation1;
        sc.Parameters.Add(new SqlParameter("@LSCSSex1", SqlDbType.NVarChar, 50)).Value = LSCSSex1;
        sc.Parameters.Add(new SqlParameter("@LSCSApgar1", SqlDbType.NVarChar, 50)).Value = LSCSApgar1;
        sc.Parameters.Add(new SqlParameter("@LSCSPresentation2", SqlDbType.NVarChar, 50)).Value = LSCSPresentation2;
        sc.Parameters.Add(new SqlParameter("@LSCSSex2", SqlDbType.NVarChar, 50)).Value = LSCSSex2;
        sc.Parameters.Add(new SqlParameter("@LSCSApgar2", SqlDbType.NVarChar, 50)).Value = LSCSApgar2;
        sc.Parameters.Add(new SqlParameter("@LSCSPresentation3", SqlDbType.NVarChar, 50)).Value = LSCSPresentation3;
        sc.Parameters.Add(new SqlParameter("@LSCSSex3", SqlDbType.NVarChar, 50)).Value = LSCSSex3;
        sc.Parameters.Add(new SqlParameter("@LSCSApgar3", SqlDbType.NVarChar, 50)).Value = LSCSApgar3;

        sc.Parameters.Add(new SqlParameter("@NoofFetuses", SqlDbType.NVarChar, 50)).Value = NoofFetuses;
        sc.Parameters.Add(new SqlParameter("@PLACENTA", SqlDbType.NVarChar, 50)).Value = PLACENTA;
        sc.Parameters.Add(new SqlParameter("@Intact", SqlDbType.NVarChar, 50)).Value = Intact;
        sc.Parameters.Add(new SqlParameter("@BLADDER", SqlDbType.NVarChar, 50)).Value = BLADDER;
        sc.Parameters.Add(new SqlParameter("@ADHESIONS", SqlDbType.NVarChar, 50)).Value = ADHESIONS;

        sc.Parameters.Add(new SqlParameter("@Comments", SqlDbType.NVarChar, 550)).Value = Notes;

        sc.Parameters.Add(new SqlParameter("@CreatedBy", SqlDbType.NVarChar, 250)).Value = P_CreatedBy;
        sc.Parameters.Add(new SqlParameter("@Branchid ", SqlDbType.Int)).Value = Branchid;



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

    public void Alter_LSCH_Section_Report(int patregid, int OpdNo, int IpdNo)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Alter_VW_LSCH_Section_Report", con);
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


    public void Insert_MYOMECTOMY_Section()
    {

        SqlConnection conn = DataAccess.ConInitForDC();
        SqlCommand sc = new SqlCommand();
        sc.CommandType = CommandType.StoredProcedure;
        sc.Connection = conn;
        sc.CommandText = "SP_Insert_MYOMECTOMY_Section";
        sc.Parameters.Add(new SqlParameter("@Patregid", SqlDbType.Int)).Value = Patregid;
        sc.Parameters.Add(new SqlParameter("@OPDNO", SqlDbType.Int)).Value = OPDNO;
        sc.Parameters.Add(new SqlParameter("@IPDNO", SqlDbType.Int)).Value = IPDNO;

        if (this.OperationDate == Date.getMinDate())
            sc.Parameters.Add(new SqlParameter("@DateOfOperation", SqlDbType.DateTime)).Value = DBNull.Value;
        else
            sc.Parameters.Add(new SqlParameter("@DateOfOperation", SqlDbType.DateTime)).Value = OperationDate;

        if (this.EntryDate == Date.getMinDate())
            sc.Parameters.Add(new SqlParameter("@NoteDate", SqlDbType.DateTime)).Value = DBNull.Value;
        else
            sc.Parameters.Add(new SqlParameter("@NoteDate", SqlDbType.DateTime)).Value = EntryDate;

        sc.Parameters.Add(new SqlParameter("@Schedule", SqlDbType.NVarChar, 550)).Value = Schedule;
        sc.Parameters.Add(new SqlParameter("@OperativeProcedure", SqlDbType.NVarChar, 550)).Value = OperativeProcedure;
        sc.Parameters.Add(new SqlParameter("@PreOperativeDiagnosis ", SqlDbType.NVarChar, 550)).Value = PreOperativeDiagnosis;
        sc.Parameters.Add(new SqlParameter("@DurationofSurgery", SqlDbType.NVarChar, 550)).Value = DurationofSurgery;

        sc.Parameters.Add(new SqlParameter("@PostOperativeAnaesthetist", SqlDbType.NVarChar, 550)).Value = PostOperativeAnaesthetist;
        sc.Parameters.Add(new SqlParameter("@SwabCount", SqlDbType.NVarChar, 550)).Value = SwabCount;
        sc.Parameters.Add(new SqlParameter("@Inflate ", SqlDbType.NVarChar, 550)).Value = Inflate;
        sc.Parameters.Add(new SqlParameter("@ScrubNurse", SqlDbType.NVarChar, 550)).Value = ScrubNurse;

        sc.Parameters.Add(new SqlParameter("@OperationFindings", SqlDbType.NVarChar, 550)).Value = OperationFindings;
        sc.Parameters.Add(new SqlParameter("@Drains", SqlDbType.NVarChar, 550)).Value = Drains;
        sc.Parameters.Add(new SqlParameter("@Anaesthetist", SqlDbType.NVarChar, 550)).Value = Anaesthetist;
        sc.Parameters.Add(new SqlParameter("@PostOperativeDiagnosis", SqlDbType.NVarChar, 550)).Value = PostOperativeDiagnosis;

        sc.Parameters.Add(new SqlParameter("@TourniquetTime", SqlDbType.NVarChar, 550)).Value = TourniquetTime;
        sc.Parameters.Add(new SqlParameter("@Surgeon", SqlDbType.NVarChar, 550)).Value = Surgeon;
        sc.Parameters.Add(new SqlParameter("@SpecimenForwarded ", SqlDbType.NVarChar, 550)).Value = SpecimenForwarded;
        sc.Parameters.Add(new SqlParameter("@Deflate", SqlDbType.NVarChar, 550)).Value = Deflate;

        sc.Parameters.Add(new SqlParameter("@BloodLoss", SqlDbType.NVarChar, 550)).Value = BloodLoss;

        sc.Parameters.Add(new SqlParameter("@Incision", SqlDbType.NVarChar, 50)).Value = Incision;
        sc.Parameters.Add(new SqlParameter("@NumberofFibroids", SqlDbType.NVarChar, 50)).Value = NumberofFibroids;
        sc.Parameters.Add(new SqlParameter("@LocationofFibroids", SqlDbType.NVarChar, 50)).Value = LocationofFibroids;
        sc.Parameters.Add(new SqlParameter("@Opens", SqlDbType.NVarChar, 50)).Value = Opens;
        sc.Parameters.Add(new SqlParameter("@Ovaries", SqlDbType.NVarChar, 50)).Value = Ovaries;
        sc.Parameters.Add(new SqlParameter("@Tourniquet", SqlDbType.NVarChar, 50)).Value = Tourniquet;
        sc.Parameters.Add(new SqlParameter("@Emdometrium", SqlDbType.NVarChar, 50)).Value = Emdometrium;

        sc.Parameters.Add(new SqlParameter("@DropBox", SqlDbType.NVarChar, 50)).Value = DropBox;
        sc.Parameters.Add(new SqlParameter("@Blocked", SqlDbType.NVarChar, 50)).Value = Blocked;
        sc.Parameters.Add(new SqlParameter("@Drilled", SqlDbType.NVarChar, 50)).Value = Drilled;
        sc.Parameters.Add(new SqlParameter("@TubesTested", SqlDbType.NVarChar, 50)).Value = TubesTested;
        sc.Parameters.Add(new SqlParameter("@IntraUterineFoleys", SqlDbType.NVarChar, 50)).Value = IntraUterineFoleys;
       

        sc.Parameters.Add(new SqlParameter("@Comments", SqlDbType.NVarChar, 550)).Value = Notes;

        sc.Parameters.Add(new SqlParameter("@CreatedBy", SqlDbType.NVarChar, 250)).Value = P_CreatedBy;
        sc.Parameters.Add(new SqlParameter("@Branchid", SqlDbType.Int)).Value = Branchid;



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

    public void Alter_MYOMECTOMY_Section_Report(int patregid, int OpdNo, int IpdNo)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Alter_VW_MYOMECTOMY_Section_Report", con);
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

    public void Insert_ABDOMINALHYSTERECTOMY_Section()
    {

        SqlConnection conn = DataAccess.ConInitForDC();
        SqlCommand sc = new SqlCommand();
        sc.CommandType = CommandType.StoredProcedure;
        sc.Connection = conn;
        sc.CommandText = "SP_Insert_ABDOMINALHYSTERECTOMY_Section";
        sc.Parameters.Add(new SqlParameter("@Patregid", SqlDbType.Int)).Value = Patregid;
        sc.Parameters.Add(new SqlParameter("@OPDNO", SqlDbType.Int)).Value = OPDNO;
        sc.Parameters.Add(new SqlParameter("@IPDNO", SqlDbType.Int)).Value = IPDNO;

        if (this.OperationDate == Date.getMinDate())
            sc.Parameters.Add(new SqlParameter("@DateOfOperation", SqlDbType.DateTime)).Value = DBNull.Value;
        else
            sc.Parameters.Add(new SqlParameter("@DateOfOperation", SqlDbType.DateTime)).Value = OperationDate;

        if (this.EntryDate == Date.getMinDate())
            sc.Parameters.Add(new SqlParameter("@NoteDate", SqlDbType.DateTime)).Value = DBNull.Value;
        else
            sc.Parameters.Add(new SqlParameter("@NoteDate", SqlDbType.DateTime)).Value = EntryDate;

        sc.Parameters.Add(new SqlParameter("@Schedule", SqlDbType.NVarChar, 550)).Value = Schedule;
        sc.Parameters.Add(new SqlParameter("@OperativeProcedure", SqlDbType.NVarChar, 550)).Value = OperativeProcedure;
        sc.Parameters.Add(new SqlParameter("@PreOperativeDiagnosis ", SqlDbType.NVarChar, 550)).Value = PreOperativeDiagnosis;
        sc.Parameters.Add(new SqlParameter("@DurationofSurgery", SqlDbType.NVarChar, 550)).Value = DurationofSurgery;

        sc.Parameters.Add(new SqlParameter("@PostOperativeAnaesthetist", SqlDbType.NVarChar, 550)).Value = PostOperativeAnaesthetist;
        sc.Parameters.Add(new SqlParameter("@SwabCount", SqlDbType.NVarChar, 550)).Value = SwabCount;
        sc.Parameters.Add(new SqlParameter("@Inflate ", SqlDbType.NVarChar, 550)).Value = Inflate;
        sc.Parameters.Add(new SqlParameter("@ScrubNurse", SqlDbType.NVarChar, 550)).Value = ScrubNurse;

        sc.Parameters.Add(new SqlParameter("@OperationFindings", SqlDbType.NVarChar, 550)).Value = OperationFindings;
        sc.Parameters.Add(new SqlParameter("@Drains", SqlDbType.NVarChar, 550)).Value = Drains;
        sc.Parameters.Add(new SqlParameter("@Anaesthetist", SqlDbType.NVarChar, 550)).Value = Anaesthetist;
        sc.Parameters.Add(new SqlParameter("@PostOperativeDiagnosis", SqlDbType.NVarChar, 550)).Value = PostOperativeDiagnosis;

        sc.Parameters.Add(new SqlParameter("@TourniquetTime", SqlDbType.NVarChar, 550)).Value = TourniquetTime;
        sc.Parameters.Add(new SqlParameter("@Surgeon", SqlDbType.NVarChar, 550)).Value = Surgeon;
        sc.Parameters.Add(new SqlParameter("@SpecimenForwarded ", SqlDbType.NVarChar, 550)).Value = SpecimenForwarded;
        sc.Parameters.Add(new SqlParameter("@Deflate", SqlDbType.NVarChar, 550)).Value = Deflate;

        sc.Parameters.Add(new SqlParameter("@BloodLoss", SqlDbType.NVarChar, 550)).Value = BloodLoss;

        sc.Parameters.Add(new SqlParameter("@STANDARDTAH", SqlDbType.NVarChar, 50)).Value = STANDARDTAH;
        sc.Parameters.Add(new SqlParameter("@STANDARDTAH_R", SqlDbType.NVarChar, 50)).Value = STANDARDTAH_R;
        sc.Parameters.Add(new SqlParameter("@UTERINESIZEINWEEK", SqlDbType.NVarChar, 50)).Value = UTERINESIZEINWEEK;
        sc.Parameters.Add(new SqlParameter("@ADHESIONS", SqlDbType.NVarChar, 50)).Value = ADHESIONS;
        sc.Parameters.Add(new SqlParameter("@ENDOMETRIOSIS", SqlDbType.NVarChar, 50)).Value = ENDOMETRIOSIS;
        sc.Parameters.Add(new SqlParameter("@OOPHORECTOMY", SqlDbType.NVarChar, 50)).Value = OOPHORECTOMY;
       

        sc.Parameters.Add(new SqlParameter("@Comments", SqlDbType.NVarChar, 550)).Value = Notes;

        sc.Parameters.Add(new SqlParameter("@CreatedBy", SqlDbType.NVarChar, 250)).Value = P_CreatedBy;
        sc.Parameters.Add(new SqlParameter("@Branchid", SqlDbType.Int)).Value = Branchid;



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

    public void Alter_Abdominal_Section_Report(int patregid, int OpdNo, int IpdNo)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Alter_VW_ABDOMINALHYSTERECTOMY_Section_Report", con);
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

    public void Insert_VAGINALHYSTERECTOMY_Section()
    {

        SqlConnection conn = DataAccess.ConInitForDC();
        SqlCommand sc = new SqlCommand();
        sc.CommandType = CommandType.StoredProcedure;
        sc.Connection = conn;
        sc.CommandText = "SP_Insert_VAGINALHYSTERECTOMY_Section";
        sc.Parameters.Add(new SqlParameter("@Patregid", SqlDbType.Int)).Value = Patregid;
        sc.Parameters.Add(new SqlParameter("@OPDNO", SqlDbType.Int)).Value = OPDNO;
        sc.Parameters.Add(new SqlParameter("@IPDNO", SqlDbType.Int)).Value = IPDNO;

        if (this.OperationDate == Date.getMinDate())
            sc.Parameters.Add(new SqlParameter("@DateOfOperation", SqlDbType.DateTime)).Value = DBNull.Value;
        else
            sc.Parameters.Add(new SqlParameter("@DateOfOperation", SqlDbType.DateTime)).Value = OperationDate;

        if (this.EntryDate == Date.getMinDate())
            sc.Parameters.Add(new SqlParameter("@NoteDate", SqlDbType.DateTime)).Value = DBNull.Value;
        else
            sc.Parameters.Add(new SqlParameter("@NoteDate", SqlDbType.DateTime)).Value = EntryDate;

        sc.Parameters.Add(new SqlParameter("@Schedule", SqlDbType.NVarChar, 550)).Value = Schedule;
        sc.Parameters.Add(new SqlParameter("@OperativeProcedure", SqlDbType.NVarChar, 550)).Value = OperativeProcedure;
        sc.Parameters.Add(new SqlParameter("@PreOperativeDiagnosis ", SqlDbType.NVarChar, 550)).Value = PreOperativeDiagnosis;
        sc.Parameters.Add(new SqlParameter("@DurationofSurgery", SqlDbType.NVarChar, 550)).Value = DurationofSurgery;

        sc.Parameters.Add(new SqlParameter("@PostOperativeAnaesthetist", SqlDbType.NVarChar, 550)).Value = PostOperativeAnaesthetist;
        sc.Parameters.Add(new SqlParameter("@SwabCount", SqlDbType.NVarChar, 550)).Value = SwabCount;
        sc.Parameters.Add(new SqlParameter("@Inflate ", SqlDbType.NVarChar, 550)).Value = Inflate;
        sc.Parameters.Add(new SqlParameter("@ScrubNurse", SqlDbType.NVarChar, 550)).Value = ScrubNurse;

        sc.Parameters.Add(new SqlParameter("@OperationFindings", SqlDbType.NVarChar, 550)).Value = OperationFindings;
        sc.Parameters.Add(new SqlParameter("@Drains", SqlDbType.NVarChar, 550)).Value = Drains;
        sc.Parameters.Add(new SqlParameter("@Anaesthetist", SqlDbType.NVarChar, 550)).Value = Anaesthetist;
        sc.Parameters.Add(new SqlParameter("@PostOperativeDiagnosis", SqlDbType.NVarChar, 550)).Value = PostOperativeDiagnosis;

        sc.Parameters.Add(new SqlParameter("@TourniquetTime", SqlDbType.NVarChar, 550)).Value = TourniquetTime;
        sc.Parameters.Add(new SqlParameter("@Surgeon", SqlDbType.NVarChar, 550)).Value = Surgeon;
        sc.Parameters.Add(new SqlParameter("@SpecimenForwarded ", SqlDbType.NVarChar, 550)).Value = SpecimenForwarded;
        sc.Parameters.Add(new SqlParameter("@Deflate", SqlDbType.NVarChar, 550)).Value = Deflate;

        sc.Parameters.Add(new SqlParameter("@BloodLoss", SqlDbType.NVarChar, 550)).Value = BloodLoss;

        sc.Parameters.Add(new SqlParameter("@UterineSize", SqlDbType.NVarChar, 50)).Value = UterineSize;
        sc.Parameters.Add(new SqlParameter("@CystoceleRemark", SqlDbType.NVarChar, 50)).Value = CystoceleRemark;
        sc.Parameters.Add(new SqlParameter("@RectoceleRemark", SqlDbType.NVarChar, 50)).Value = RectoceleRemark;
        sc.Parameters.Add(new SqlParameter("@OophrectomyRemark", SqlDbType.NVarChar, 50)).Value = OophrectomyRemark;
        sc.Parameters.Add(new SqlParameter("@ProcedureRemark", SqlDbType.NVarChar, 50)).Value = Procedure;

        sc.Parameters.Add(new SqlParameter("@Is_Cystocele", SqlDbType.Bit)).Value = Is_Cystocele;
        sc.Parameters.Add(new SqlParameter("@Is_Rectocele", SqlDbType.Bit)).Value = Is_Rectocele;
        sc.Parameters.Add(new SqlParameter("@Is_Fibroids", SqlDbType.Bit)).Value = Is_Fibroids;
        sc.Parameters.Add(new SqlParameter("@Is_Adhesions", SqlDbType.Bit)).Value = Is_Adhesions;
        sc.Parameters.Add(new SqlParameter("@Is_Oophrectomy", SqlDbType.Bit)).Value = Is_Oopherectomy;

        sc.Parameters.Add(new SqlParameter("@Is_CystoceleRepaired", SqlDbType.Bit)).Value = Is_CystoceleRepaired;
        sc.Parameters.Add(new SqlParameter("@Is_RectoceleRepaired", SqlDbType.Bit)).Value = Is_RectoceleRepaired;
        sc.Parameters.Add(new SqlParameter("@Is_LevatorplastyDone", SqlDbType.Bit)).Value = Is_LevatorplastyDone;
        sc.Parameters.Add(new SqlParameter("@Is_SacrospinouspexyDone", SqlDbType.Bit)).Value = Is_SacrospinouspexyDone;
        sc.Parameters.Add(new SqlParameter("@Is_PackInserted", SqlDbType.Bit)).Value = Is_PackInserted;


        sc.Parameters.Add(new SqlParameter("@Comments", SqlDbType.NVarChar, 550)).Value = Notes;

        sc.Parameters.Add(new SqlParameter("@CreatedBy", SqlDbType.NVarChar, 250)).Value = P_CreatedBy;
        sc.Parameters.Add(new SqlParameter("@Branchid", SqlDbType.Int)).Value = Branchid;



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

    public void Alter_VaginalHysterect_Section_Report(int patregid, int OpdNo, int IpdNo)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Alter_VW_VAGINALHYSTERECTOMY_Section_Report", con);
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


    public void Insert_OPERATIVEHYSTEROSCOPY_Section()
    {

        SqlConnection conn = DataAccess.ConInitForDC();
        SqlCommand sc = new SqlCommand();
        sc.CommandType = CommandType.StoredProcedure;
        sc.Connection = conn;
        sc.CommandText = "SP_Insert_OPERATIVEHYSTEROSCOPY_Section";
        sc.Parameters.Add(new SqlParameter("@Patregid", SqlDbType.Int)).Value = Patregid;
        sc.Parameters.Add(new SqlParameter("@OPDNO", SqlDbType.Int)).Value = OPDNO;
        sc.Parameters.Add(new SqlParameter("@IPDNO", SqlDbType.Int)).Value = IPDNO;

        if (this.OperationDate == Date.getMinDate())
            sc.Parameters.Add(new SqlParameter("@DateOfOperation", SqlDbType.DateTime)).Value = DBNull.Value;
        else
            sc.Parameters.Add(new SqlParameter("@DateOfOperation", SqlDbType.DateTime)).Value = OperationDate;

        if (this.EntryDate == Date.getMinDate())
            sc.Parameters.Add(new SqlParameter("@NoteDate", SqlDbType.DateTime)).Value = DBNull.Value;
        else
            sc.Parameters.Add(new SqlParameter("@NoteDate", SqlDbType.DateTime)).Value = EntryDate;

        sc.Parameters.Add(new SqlParameter("@Schedule", SqlDbType.NVarChar, 550)).Value = Schedule;
        sc.Parameters.Add(new SqlParameter("@OperativeProcedure", SqlDbType.NVarChar, 550)).Value = OperativeProcedure;
        sc.Parameters.Add(new SqlParameter("@PreOperativeDiagnosis ", SqlDbType.NVarChar, 550)).Value = PreOperativeDiagnosis;
        sc.Parameters.Add(new SqlParameter("@DurationofSurgery", SqlDbType.NVarChar, 550)).Value = DurationofSurgery;

        sc.Parameters.Add(new SqlParameter("@PostOperativeAnaesthetist", SqlDbType.NVarChar, 550)).Value = PostOperativeAnaesthetist;
        sc.Parameters.Add(new SqlParameter("@SwabCount", SqlDbType.NVarChar, 550)).Value = SwabCount;
        sc.Parameters.Add(new SqlParameter("@Inflate ", SqlDbType.NVarChar, 550)).Value = Inflate;
        sc.Parameters.Add(new SqlParameter("@ScrubNurse", SqlDbType.NVarChar, 550)).Value = ScrubNurse;

        sc.Parameters.Add(new SqlParameter("@OperationFindings", SqlDbType.NVarChar, 550)).Value = OperationFindings;
        sc.Parameters.Add(new SqlParameter("@Drains", SqlDbType.NVarChar, 550)).Value = Drains;
        sc.Parameters.Add(new SqlParameter("@Anaesthetist", SqlDbType.NVarChar, 550)).Value = Anaesthetist;
        sc.Parameters.Add(new SqlParameter("@PostOperativeDiagnosis", SqlDbType.NVarChar, 550)).Value = PostOperativeDiagnosis;

        sc.Parameters.Add(new SqlParameter("@TourniquetTime", SqlDbType.NVarChar, 550)).Value = TourniquetTime;
        sc.Parameters.Add(new SqlParameter("@Surgeon", SqlDbType.NVarChar, 550)).Value = Surgeon;
        sc.Parameters.Add(new SqlParameter("@SpecimenForwarded ", SqlDbType.NVarChar, 550)).Value = SpecimenForwarded;
        sc.Parameters.Add(new SqlParameter("@Deflate", SqlDbType.NVarChar, 550)).Value = Deflate;

        sc.Parameters.Add(new SqlParameter("@BloodLoss", SqlDbType.NVarChar, 550)).Value = BloodLoss;

        sc.Parameters.Add(new SqlParameter("@Fibroids", SqlDbType.NVarChar, 50)).Value = Fibroids;
        sc.Parameters.Add(new SqlParameter("@Numbers", SqlDbType.NVarChar, 50)).Value = Numbers;
        sc.Parameters.Add(new SqlParameter("@Locations", SqlDbType.NVarChar, 50)).Value = Location;
        sc.Parameters.Add(new SqlParameter("@LocationSize", SqlDbType.NVarChar, 50)).Value = LocationSize;
        sc.Parameters.Add(new SqlParameter("@Adhesions", SqlDbType.NVarChar, 50)).Value = Adhesions;
        sc.Parameters.Add(new SqlParameter("@Septum", SqlDbType.NVarChar, 50)).Value = Septum;

        sc.Parameters.Add(new SqlParameter("@Is_FibroidResection", SqlDbType.Bit)).Value = Is_FibroidResection;
        sc.Parameters.Add(new SqlParameter("@Is_SeptalResection", SqlDbType.Bit)).Value = Is_SeptalResection;
        sc.Parameters.Add(new SqlParameter("@Is_Adhesiolysis", SqlDbType.Bit)).Value = Is_Adhesiolysis;
      


        sc.Parameters.Add(new SqlParameter("@Comments", SqlDbType.NVarChar, 550)).Value = Notes;

        sc.Parameters.Add(new SqlParameter("@CreatedBy", SqlDbType.NVarChar, 250)).Value = P_CreatedBy;
        sc.Parameters.Add(new SqlParameter("@Branchid", SqlDbType.Int)).Value = Branchid;



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


    public void Alter_OPERATIVEHYSTEROSCOPY_Section_Report(int patregid, int OpdNo, int IpdNo)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Alter_VW_OPERATIVEHYSTEROSCOPY_Section_Report", con);
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

    public void Insert_VAGINAL_HYSTE_NONDESCENT_Section()
    {

        SqlConnection conn = DataAccess.ConInitForDC();
        SqlCommand sc = new SqlCommand();
        sc.CommandType = CommandType.StoredProcedure;
        sc.Connection = conn;
        sc.CommandText = "SP_Insert_VAGINAL_HYSTE_NONDESCENT_Section";
        sc.Parameters.Add(new SqlParameter("@Patregid", SqlDbType.Int)).Value = Patregid;
        sc.Parameters.Add(new SqlParameter("@OPDNO", SqlDbType.Int)).Value = OPDNO;
        sc.Parameters.Add(new SqlParameter("@IPDNO", SqlDbType.Int)).Value = IPDNO;

        if (this.OperationDate == Date.getMinDate())
            sc.Parameters.Add(new SqlParameter("@DateOfOperation", SqlDbType.DateTime)).Value = DBNull.Value;
        else
            sc.Parameters.Add(new SqlParameter("@DateOfOperation", SqlDbType.DateTime)).Value = OperationDate;

        if (this.EntryDate == Date.getMinDate())
            sc.Parameters.Add(new SqlParameter("@NoteDate", SqlDbType.DateTime)).Value = DBNull.Value;
        else
            sc.Parameters.Add(new SqlParameter("@NoteDate", SqlDbType.DateTime)).Value = EntryDate;

        sc.Parameters.Add(new SqlParameter("@Schedule", SqlDbType.NVarChar, 550)).Value = Schedule;
        sc.Parameters.Add(new SqlParameter("@OperativeProcedure", SqlDbType.NVarChar, 550)).Value = OperativeProcedure;
        sc.Parameters.Add(new SqlParameter("@PreOperativeDiagnosis ", SqlDbType.NVarChar, 550)).Value = PreOperativeDiagnosis;
        sc.Parameters.Add(new SqlParameter("@DurationofSurgery", SqlDbType.NVarChar, 550)).Value = DurationofSurgery;

        sc.Parameters.Add(new SqlParameter("@PostOperativeAnaesthetist", SqlDbType.NVarChar, 550)).Value = PostOperativeAnaesthetist;
        sc.Parameters.Add(new SqlParameter("@SwabCount", SqlDbType.NVarChar, 550)).Value = SwabCount;
        sc.Parameters.Add(new SqlParameter("@Inflate ", SqlDbType.NVarChar, 550)).Value = Inflate;
        sc.Parameters.Add(new SqlParameter("@ScrubNurse", SqlDbType.NVarChar, 550)).Value = ScrubNurse;

        sc.Parameters.Add(new SqlParameter("@OperationFindings", SqlDbType.NVarChar, 550)).Value = OperationFindings;
        sc.Parameters.Add(new SqlParameter("@Drains", SqlDbType.NVarChar, 550)).Value = Drains;
        sc.Parameters.Add(new SqlParameter("@Anaesthetist", SqlDbType.NVarChar, 550)).Value = Anaesthetist;
        sc.Parameters.Add(new SqlParameter("@PostOperativeDiagnosis", SqlDbType.NVarChar, 550)).Value = PostOperativeDiagnosis;

        sc.Parameters.Add(new SqlParameter("@TourniquetTime", SqlDbType.NVarChar, 550)).Value = TourniquetTime;
        sc.Parameters.Add(new SqlParameter("@Surgeon", SqlDbType.NVarChar, 550)).Value = Surgeon;
        sc.Parameters.Add(new SqlParameter("@SpecimenForwarded ", SqlDbType.NVarChar, 550)).Value = SpecimenForwarded;
        sc.Parameters.Add(new SqlParameter("@Deflate", SqlDbType.NVarChar, 550)).Value = Deflate;

        sc.Parameters.Add(new SqlParameter("@BloodLoss", SqlDbType.NVarChar, 550)).Value = BloodLoss;

        sc.Parameters.Add(new SqlParameter("@UterineSize", SqlDbType.NVarChar, 50)).Value = UterineSize;
        sc.Parameters.Add(new SqlParameter("@Sites", SqlDbType.NVarChar, 50)).Value = Site;
        sc.Parameters.Add(new SqlParameter("@Oophrectomy", SqlDbType.NVarChar, 50)).Value = Oophrectomy;
        sc.Parameters.Add(new SqlParameter("@PackInserted", SqlDbType.NVarChar, 50)).Value = PackInserted;


        sc.Parameters.Add(new SqlParameter("@Is_Fibroids", SqlDbType.Bit)).Value = Is_Fibroids;
        sc.Parameters.Add(new SqlParameter("@Is_Adhesions", SqlDbType.Bit)).Value = Is_Adhesions;
        sc.Parameters.Add(new SqlParameter("@Is_Oopherectomy", SqlDbType.Bit)).Value = Is_Oopherectomy;



        sc.Parameters.Add(new SqlParameter("@Comments", SqlDbType.NVarChar, 550)).Value = Notes;

        sc.Parameters.Add(new SqlParameter("@CreatedBy", SqlDbType.NVarChar, 250)).Value = P_CreatedBy;
        sc.Parameters.Add(new SqlParameter("@Branchid", SqlDbType.Int)).Value = Branchid;



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


    public void Alter_VAGINAL_HYSTE_NONDESCENT_Report(int patregid, int OpdNo, int IpdNo)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Alter_VW_VAGINAL_HYSTE_NONDESCENT_Section_Report", con);
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


    public void Insert_ENDOSCOPY_Section()
    {

        SqlConnection conn = DataAccess.ConInitForDC();
        SqlCommand sc = new SqlCommand();
        sc.CommandType = CommandType.StoredProcedure;
        sc.Connection = conn;
        sc.CommandText = "SP_Insert_ENDOSCOPY_Section";
        sc.Parameters.Add(new SqlParameter("@Patregid", SqlDbType.Int)).Value = Patregid;
        sc.Parameters.Add(new SqlParameter("@OPDNO", SqlDbType.Int)).Value = OPDNO;
        sc.Parameters.Add(new SqlParameter("@IPDNO", SqlDbType.Int)).Value = IPDNO;

        if (this.OperationDate == Date.getMinDate())
            sc.Parameters.Add(new SqlParameter("@DateOfProcedure", SqlDbType.DateTime)).Value = DBNull.Value;
        else
            sc.Parameters.Add(new SqlParameter("@DateOfProcedure", SqlDbType.DateTime)).Value = OperationDate;



        sc.Parameters.Add(new SqlParameter("@ProcedureType", SqlDbType.NVarChar, 550)).Value = ProcedureType;
        sc.Parameters.Add(new SqlParameter("@ProcedurePerformed", SqlDbType.NVarChar, 550)).Value = ProcedurePerformed;
        sc.Parameters.Add(new SqlParameter("@Endoscopist ", SqlDbType.NVarChar, 550)).Value = Endoscopist;
        sc.Parameters.Add(new SqlParameter("@Anaesthesia", SqlDbType.NVarChar, 550)).Value = Anaesthesia;

        sc.Parameters.Add(new SqlParameter("@Instrument", SqlDbType.NVarChar, 550)).Value = Instrument;
        sc.Parameters.Add(new SqlParameter("@IndicationofProcedure", SqlDbType.NVarChar, 550)).Value = IndicationofProcedure;
        sc.Parameters.Add(new SqlParameter("@DescriptionOfProcedure ", SqlDbType.NVarChar, 550)).Value = DescriptionOfProcedure;
        sc.Parameters.Add(new SqlParameter("@Complications", SqlDbType.NVarChar, 550)).Value = Complications;

        sc.Parameters.Add(new SqlParameter("@Impression", SqlDbType.NVarChar, 550)).Value = Impression;
        sc.Parameters.Add(new SqlParameter("@OtherNotes", SqlDbType.NVarChar, 550)).Value = Notes;
       

        sc.Parameters.Add(new SqlParameter("@CreatedBy", SqlDbType.NVarChar, 250)).Value = P_CreatedBy;
        sc.Parameters.Add(new SqlParameter("@Branchid", SqlDbType.Int)).Value = Branchid;



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

    public void Alter_ENDOSCOPY_Section_Report(int patregid, int OpdNo, int IpdNo)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_Alter_VW_ENDOSCOPY_Section_Report_Report", con);
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

    public void Insert_MajorCase_Section()
    {

        SqlConnection conn = DataAccess.ConInitForDC();
        SqlCommand sc = new SqlCommand();
        sc.CommandType = CommandType.StoredProcedure;
        sc.Connection = conn;
        sc.CommandText = "SP_Insert_MajorCase_Section";
        sc.Parameters.Add(new SqlParameter("@Patregid", SqlDbType.Int)).Value = Patregid;
        sc.Parameters.Add(new SqlParameter("@OPDNO", SqlDbType.Int)).Value = OPDNO;
        sc.Parameters.Add(new SqlParameter("@IPDNO", SqlDbType.Int)).Value = IPDNO;

        if (this.OperationDate == Date.getMinDate())
            sc.Parameters.Add(new SqlParameter("@DateOfMajorCase", SqlDbType.DateTime)).Value = DBNull.Value;
        else
            sc.Parameters.Add(new SqlParameter("@DateOfMajorCase", SqlDbType.DateTime)).Value = OperationDate;


        sc.Parameters.Add(new SqlParameter("@NPO", SqlDbType.NVarChar, 550)).Value = NPO;
        sc.Parameters.Add(new SqlParameter("@NPODetails", SqlDbType.NVarChar, 550)).Value = NPORemark;
        sc.Parameters.Add(new SqlParameter("@Medication", SqlDbType.NVarChar, 550)).Value = Medication;
        sc.Parameters.Add(new SqlParameter("@SugarMonitoring ", SqlDbType.NVarChar, 550)).Value = SugarMonitoring;
        sc.Parameters.Add(new SqlParameter("@SlidingScaleInsulin", SqlDbType.NVarChar, 550)).Value = SlidingScaleInsulin;

        sc.Parameters.Add(new SqlParameter("@OtherNotes", SqlDbType.NVarChar, 550)).Value = Notes;
       
        sc.Parameters.Add(new SqlParameter("@CreatedBy", SqlDbType.NVarChar, 250)).Value = P_CreatedBy;
        sc.Parameters.Add(new SqlParameter("@Branchid", SqlDbType.Int)).Value = Branchid;



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


    public void Alter_MajorCase_Section_Report(int patregid, int OpdNo, int IpdNo)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("VW_MajorCase_Section_Report", con);
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
}