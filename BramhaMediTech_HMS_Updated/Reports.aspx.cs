using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
using CrystalDecisions;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

public partial class Reports :BasePage
{
    dbconnection da = new dbconnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            FetchReport();
        }
    }
    protected void FetchReport()
    {
        CrystalDecisions.CrystalReports.Engine.ReportDocument rep = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
        DataSetHMS Objrds = new DataSetHMS();
        switch (Session["reportname"].ToString())
        {


            case "OPDFinalBillPrint":
                DataSetHMS.Vw_OpdFinalBillReportDataTable objFinalOPDBill = Objrds.Vw_OpdFinalBillReport;
                DataSetHMSTableAdapters.Vw_OpdFinalBillReportTableAdapter objFinalOPDBill1 = new DataSetHMSTableAdapters.Vw_OpdFinalBillReportTableAdapter();
                objFinalOPDBill1.Fill(objFinalOPDBill);
                rep.Load(Server.MapPath("~//Report//Rpt_OPDFinalBillPrint.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;

            case "OPDReceipt":
                DataSetHMS.Vw_OpdBillReportDataTable ObjCRLInstruction = Objrds.Vw_OpdBillReport;
                DataSetHMSTableAdapters.Vw_OpdBillReportTableAdapter ObjCRLInstruction1 = new DataSetHMSTableAdapters.Vw_OpdBillReportTableAdapter();
                ObjCRLInstruction1.Fill(ObjCRLInstruction);

                rep.Load(Server.MapPath("~//Report//Rpt_OPDBilling.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;

            case "Rpt_OpdVisitChildren":
                DataSetHMS.VW_OpdVisitChildrenDataTable ObjOVC = Objrds.VW_OpdVisitChildren;
                DataSetHMSTableAdapters.VW_OpdVisitChildrenTableAdapter ObjOVC1 = new DataSetHMSTableAdapters.VW_OpdVisitChildrenTableAdapter();
                ObjOVC1.Fill(ObjOVC);

                rep.Load(Server.MapPath("~//Report//Rpt_OpdVisitChildren.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
            case "Rpt_OpdVisitChildrenCount":
                DataSetHMS.VW_OpdVisitChildren_CountDataTable ObjOVCC = Objrds.VW_OpdVisitChildren_Count;
                DataSetHMSTableAdapters.VW_OpdVisitChildren_CountTableAdapter ObjOVCC1 = new DataSetHMSTableAdapters.VW_OpdVisitChildren_CountTableAdapter();
                ObjOVCC1.Fill(ObjOVCC);

                rep.Load(Server.MapPath("~//Report//Rpt_OpdVisitChildrenCount.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;

            case "Rpt_OpdVisitForWomans":
                DataSetHMS.VW_OpdVisitForWomeansDataTable ObjOVW = Objrds.VW_OpdVisitForWomeans;
                DataSetHMSTableAdapters.VW_OpdVisitForWomeansTableAdapter ObjOVW1 = new DataSetHMSTableAdapters.VW_OpdVisitForWomeansTableAdapter();
                ObjOVW1.Fill(ObjOVW);

                rep.Load(Server.MapPath("~//Report//Rpt_OpdVisitForWomans.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;

            case "Rpt_OpdVisitForAllPatient":
                DataSetHMS.VW_OpdVisitForWomeansDataTable ObjOVWA = Objrds.VW_OpdVisitForWomeans;
                DataSetHMSTableAdapters.VW_OpdVisitForWomeansTableAdapter ObjOVW1A = new DataSetHMSTableAdapters.VW_OpdVisitForWomeansTableAdapter();
                ObjOVW1A.Fill(ObjOVWA);

                rep.Load(Server.MapPath("~//Report//Rpt_OpdVisitForAllPatient.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;

            case "Rpt_OpdVisitChildren0To9":
                DataSetHMS.VW_OpdVisitChildrenDataTable ObjOVCC0 = Objrds.VW_OpdVisitChildren;
                DataSetHMSTableAdapters.VW_OpdVisitChildrenTableAdapter ObjOVCC10 = new DataSetHMSTableAdapters.VW_OpdVisitChildrenTableAdapter();
                ObjOVCC10.Fill(ObjOVCC0);

                rep.Load(Server.MapPath("~//Report//Rpt_OpdVisitChildren0To9.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
            case "Rpt_OpdVisitChildren0To6Days":
                DataSetHMS.VW_OpdVisitChildrenDataTable ObjOVCC06 = Objrds.VW_OpdVisitChildren;
                DataSetHMSTableAdapters.VW_OpdVisitChildrenTableAdapter ObjOVCC106 = new DataSetHMSTableAdapters.VW_OpdVisitChildrenTableAdapter();
                ObjOVCC106.Fill(ObjOVCC06);

                rep.Load(Server.MapPath("~//Report//Rpt_OpdVisitChildren0To6Days.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
            case "Rpt_OpdVisitMailChildren":
                DataSetHMS.VW_OpdVisitChildrenDataTable ObjOVCCM= Objrds.VW_OpdVisitChildren;
                DataSetHMSTableAdapters.VW_OpdVisitChildrenTableAdapter ObjOVCC0M = new DataSetHMSTableAdapters.VW_OpdVisitChildrenTableAdapter();
                ObjOVCC0M.Fill(ObjOVCCM);

                rep.Load(Server.MapPath("~//Report//Rpt_OpdVisitMailChildren.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
            case "Rpt_OpdVisitFemailChildren":
                DataSetHMS.VW_OpdVisitChildrenDataTable ObjOVCCF = Objrds.VW_OpdVisitChildren;
                DataSetHMSTableAdapters.VW_OpdVisitChildrenTableAdapter ObjOVCC0F = new DataSetHMSTableAdapters.VW_OpdVisitChildrenTableAdapter();
                ObjOVCC0F.Fill(ObjOVCCF);

                rep.Load(Server.MapPath("~//Report//Rpt_OpdVisitFemaleChildren.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;

            case "Rpt_VisitForMalariaPatient":
                DataSetHMS.VW_VisitForMalariaPatientDataTable ObjVFM = Objrds.VW_VisitForMalariaPatient;
                DataSetHMSTableAdapters.VW_VisitForMalariaPatientTableAdapter ObjVFM1 = new DataSetHMSTableAdapters.VW_VisitForMalariaPatientTableAdapter();
                ObjVFM1.Fill(ObjVFM);

                rep.Load(Server.MapPath("~//Report//Rpt_VisitForMalariaPatient.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
            case "Rpt_VisitForANCPatient":
                DataSetHMS.VW_VisitForANCPatientDataTable ObjANC = Objrds.VW_VisitForANCPatient;
                DataSetHMSTableAdapters.VW_VisitForANCPatientTableAdapter ObjANC1 = new DataSetHMSTableAdapters.VW_VisitForANCPatientTableAdapter();
                ObjANC1.Fill(ObjANC);

                rep.Load(Server.MapPath("~//Report//Rpt_VisitForANCPatient.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
            case "Rpt_VisitForAltrasoundscanPatient":
                DataSetHMS.VW_VisitForANCPatientDataTable ObjANCS = Objrds.VW_VisitForANCPatient;
                DataSetHMSTableAdapters.VW_VisitForANCPatientTableAdapter ObjANCS1 = new DataSetHMSTableAdapters.VW_VisitForANCPatientTableAdapter();
                ObjANCS1.Fill(ObjANCS);

                rep.Load(Server.MapPath("~//Report//Rpt_VisitForAltrasoundscanPatient.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
            case "Rpt_VisitForNeonataltetanusprophylaxisPatient":
                DataSetHMS.VW_VisitForANCPatientDataTable ObjANCSP = Objrds.VW_VisitForANCPatient;
                DataSetHMSTableAdapters.VW_VisitForANCPatientTableAdapter ObjANCSP1 = new DataSetHMSTableAdapters.VW_VisitForANCPatientTableAdapter();
                ObjANCSP1.Fill(ObjANCSP);

                rep.Load(Server.MapPath("~//Report//Rpt_VisitForNeonataltetanusprophylaxisPatient.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
            case "Rpt_VisitForMalariaprophylaxisPatient":
                DataSetHMS.VW_VisitForANCPatientDataTable ObjANCMP = Objrds.VW_VisitForANCPatient;
                DataSetHMSTableAdapters.VW_VisitForANCPatientTableAdapter ObjANCMP1 = new DataSetHMSTableAdapters.VW_VisitForANCPatientTableAdapter();
                ObjANCMP1.Fill(ObjANCMP);

                rep.Load(Server.MapPath("~//Report//Rpt_VisitForMalariaprophylaxisPatient.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
            case "Rpt_VisitForSyphilisUrinarytractPatient":
                DataSetHMS.VW_VisitForANCPatientDataTable ObjANSUP = Objrds.VW_VisitForANCPatient;
                DataSetHMSTableAdapters.VW_VisitForANCPatientTableAdapter ObjANSUP1 = new DataSetHMSTableAdapters.VW_VisitForANCPatientTableAdapter();
                ObjANSUP1.Fill(ObjANSUP);
                rep.Load(Server.MapPath("~//Report//Rpt_VisitForSyphilisUrinarytractPatient.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
            case "Rpt_VisitForHIVPatient":
                DataSetHMS.VW_VisitForANCPatientDataTable ObjANCHIV = Objrds.VW_VisitForANCPatient;
                DataSetHMSTableAdapters.VW_VisitForANCPatientTableAdapter ObjANCHIV1 = new DataSetHMSTableAdapters.VW_VisitForANCPatientTableAdapter();
                ObjANCHIV1.Fill(ObjANCHIV);
                rep.Load(Server.MapPath("~//Report//Rpt_VisitForHIVPatient.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
            case "Rpt_VisitForHIVPositivePatient":
                DataSetHMS.VW_VisitForHIVPositivePatientDataTable ObjANCHIVP = Objrds.VW_VisitForHIVPositivePatient;
                DataSetHMSTableAdapters.VW_VisitForHIVPositivePatientTableAdapter ObjANCHIVP1 = new DataSetHMSTableAdapters.VW_VisitForHIVPositivePatientTableAdapter();
                ObjANCHIVP1.Fill(ObjANCHIVP);
                rep.Load(Server.MapPath("~//Report//Rpt_VisitForHIVPositivePatient.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
            case "Rpt_VisitForIntermittentPreventiveTreatmentPatient":
                 DataSetHMS.VW_VisitForANCPatientDataTable ObjANCIPT = Objrds.VW_VisitForANCPatient;
                 DataSetHMSTableAdapters.VW_VisitForANCPatientTableAdapter ObjANCIPT1 = new DataSetHMSTableAdapters.VW_VisitForANCPatientTableAdapter();
                 ObjANCIPT1.Fill(ObjANCIPT);

                rep.Load(Server.MapPath("~//Report//Rpt_VisitForIntermittentPreventiveTreatmentPatient.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
            case "Rpt_VisitForDeliveryPatient":
                DataSetHMS.VW_VisitForDeliveryPatientDataTable ObjANCDP = Objrds.VW_VisitForDeliveryPatient;
                DataSetHMSTableAdapters.VW_VisitForDeliveryPatientTableAdapter ObjANCDP1 = new DataSetHMSTableAdapters.VW_VisitForDeliveryPatientTableAdapter();
                ObjANCDP1.Fill(ObjANCDP);
                rep.Load(Server.MapPath("~//Report//Rpt_VisitForDeliveryPatient.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
            case "Rpt_VisitForNormalDeliveryPatient":
                DataSetHMS.VW_VisitForDeliveryPatientDataTable ObjANCDPN = Objrds.VW_VisitForDeliveryPatient;
                DataSetHMSTableAdapters.VW_VisitForDeliveryPatientTableAdapter ObjANCDPN1 = new DataSetHMSTableAdapters.VW_VisitForDeliveryPatientTableAdapter();
                ObjANCDPN1.Fill(ObjANCDPN);
                rep.Load(Server.MapPath("~//Report//Rpt_VisitForNormalDeliveryPatient.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
            case "Rpt_VisitForCesareanDeliveryPatient":
                DataSetHMS.VW_VisitForDeliveryPatientDataTable ObjANCDPN2 = Objrds.VW_VisitForDeliveryPatient;
                DataSetHMSTableAdapters.VW_VisitForDeliveryPatientTableAdapter ObjANCDPN12 = new DataSetHMSTableAdapters.VW_VisitForDeliveryPatientTableAdapter();
                ObjANCDPN12.Fill(ObjANCDPN2);
                rep.Load(Server.MapPath("~//Report//Rpt_VisitForCesareanDeliveryPatient.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
            case "Rpt_VisitForImmulizationPatient":
                DataSetHMS.VW_VisitForImmulizationPatientDataTable ObjVIP= Objrds.VW_VisitForImmulizationPatient;
                DataSetHMSTableAdapters.VW_VisitForImmulizationPatientTableAdapter ObjVIP1 = new DataSetHMSTableAdapters.VW_VisitForImmulizationPatientTableAdapter();
                ObjVIP1.Fill(ObjVIP);
                rep.Load(Server.MapPath("~//Report//Rpt_VisitForImmulizationPatient.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
            case "Rpt_VisitForcontraceptivePatient":
                DataSetHMS.VW_VisitForcontraceptivePatientDataTable ObjVFCP = Objrds.VW_VisitForcontraceptivePatient;
                DataSetHMSTableAdapters.VW_VisitForcontraceptivePatientTableAdapter ObjVFCP1 = new DataSetHMSTableAdapters.VW_VisitForcontraceptivePatientTableAdapter();
                ObjVFCP1.Fill(ObjVFCP);
                rep.Load(Server.MapPath("~//Report//Rpt_VisitForcontraceptivePatient.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
            case "Rpt_VisitForMaterinalDeathPatient":
                DataSetHMS.VW_VisitForDeliveryPatientDataTable ObjMATD = Objrds.VW_VisitForDeliveryPatient;
                DataSetHMSTableAdapters.VW_VisitForDeliveryPatientTableAdapter ObjMATD1 = new DataSetHMSTableAdapters.VW_VisitForDeliveryPatientTableAdapter();
                ObjMATD1.Fill(ObjMATD);
                rep.Load(Server.MapPath("~//Report//Rpt_VisitForMaterinalDeathPatient.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
            case "Rpt_VisitForVitalPatient":
                DataSetHMS.VW_VisitForVitalPatientsDataTable ObjVP = Objrds.VW_VisitForVitalPatients;
                DataSetHMSTableAdapters.VW_VisitForVitalPatientsTableAdapter ObjVP1 = new DataSetHMSTableAdapters.VW_VisitForVitalPatientsTableAdapter();
                ObjVP1.Fill(ObjVP);
                rep.Load(Server.MapPath("~//Report//Rpt_VisitForVitalPatient.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
            case "IpdBillDetails_Report":
               
                DataSetHMS.Vw_IpdPatientBillServicesDataTable objIpdBillService = Objrds.Vw_IpdPatientBillServices;
                DataSetHMSTableAdapters.Vw_IpdPatientBillServicesTableAdapter objIpdBillServiceTA = new DataSetHMSTableAdapters.Vw_IpdPatientBillServicesTableAdapter();
                objIpdBillServiceTA.Fill(objIpdBillService);
                DataSetHMS.Vw_IpdInfoForBillServiceDetailDataTable objIPDInfo = Objrds.Vw_IpdInfoForBillServiceDetail;
                DataSetHMSTableAdapters.Vw_IpdInfoForBillServiceDetailTableAdapter objIPDInfoTA = new DataSetHMSTableAdapters.Vw_IpdInfoForBillServiceDetailTableAdapter();
                objIPDInfoTA.Fill(objIPDInfo);

                DataSetHMS.Vw_BillTransactions_BillDataTable objIPDtrans = Objrds.Vw_BillTransactions_Bill;
                DataSetHMSTableAdapters.Vw_BillTransactions_BillTableAdapter objIPDtransA = new DataSetHMSTableAdapters.Vw_BillTransactions_BillTableAdapter();
                objIPDtransA.Fill(objIPDtrans);

                rep.Load(Server.MapPath("~//Report//Rpt_IpdBillDetails.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
            case "IpdBillSummary_Report":

                DataSetHMS.Vw_IpdPatientBillServicesDataTable objIpdBillService5 = Objrds.Vw_IpdPatientBillServices;
                DataSetHMSTableAdapters.Vw_IpdPatientBillServicesTableAdapter objIpdBillServiceTA5 = new DataSetHMSTableAdapters.Vw_IpdPatientBillServicesTableAdapter();
                objIpdBillServiceTA5.Fill(objIpdBillService5);
                DataSetHMS.Vw_IpdInfoForBillServiceDetailDataTable objIPDInfo5 = Objrds.Vw_IpdInfoForBillServiceDetail;
                DataSetHMSTableAdapters.Vw_IpdInfoForBillServiceDetailTableAdapter objIPDInfoTA5 = new DataSetHMSTableAdapters.Vw_IpdInfoForBillServiceDetailTableAdapter();
                objIPDInfoTA5.Fill(objIPDInfo5);

                DataSetHMS.Vw_BillTransactions_BillDataTable objIPDtrans5 = Objrds.Vw_BillTransactions_Bill;
                DataSetHMSTableAdapters.Vw_BillTransactions_BillTableAdapter objIPDtransA5 = new DataSetHMSTableAdapters.Vw_BillTransactions_BillTableAdapter();
                objIPDtransA5.Fill(objIPDtrans5);

                 DataSetHMS.VW_PatientInvoicePaymetReceive_ForIPDDataTable ObjPII2 = Objrds.VW_PatientInvoicePaymetReceive_ForIPD;
                DataSetHMSTableAdapters.VW_PatientInvoicePaymetReceive_ForIPDTableAdapter ObjPII12 = new DataSetHMSTableAdapters.VW_PatientInvoicePaymetReceive_ForIPDTableAdapter();
                ObjPII12.Fill(ObjPII2);

                rep.Load(Server.MapPath("~//Report//Rpt_IpdBillDetails_summary.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;

            case "IpdBillSummary_ReportUSD":

                DataSetHMS.Vw_IpdPatientBillServicesDataTable objIpdBillService5U = Objrds.Vw_IpdPatientBillServices;
                DataSetHMSTableAdapters.Vw_IpdPatientBillServicesTableAdapter objIpdBillServiceTA5U = new DataSetHMSTableAdapters.Vw_IpdPatientBillServicesTableAdapter();
                objIpdBillServiceTA5U.Fill(objIpdBillService5U);
                DataSetHMS.Vw_IpdInfoForBillServiceDetailDataTable objIPDInfo5U = Objrds.Vw_IpdInfoForBillServiceDetail;
                DataSetHMSTableAdapters.Vw_IpdInfoForBillServiceDetailTableAdapter objIPDInfoTA5U = new DataSetHMSTableAdapters.Vw_IpdInfoForBillServiceDetailTableAdapter();
                objIPDInfoTA5U.Fill(objIPDInfo5U);

                DataSetHMS.Vw_BillTransactions_BillDataTable objIPDtrans5U = Objrds.Vw_BillTransactions_Bill;
                DataSetHMSTableAdapters.Vw_BillTransactions_BillTableAdapter objIPDtransA5U = new DataSetHMSTableAdapters.Vw_BillTransactions_BillTableAdapter();
                objIPDtransA5U.Fill(objIPDtrans5U);

                DataSetHMS.VW_PatientInvoicePaymetReceive_ForIPDDataTable ObjPII2U = Objrds.VW_PatientInvoicePaymetReceive_ForIPD;
                DataSetHMSTableAdapters.VW_PatientInvoicePaymetReceive_ForIPDTableAdapter ObjPII12U = new DataSetHMSTableAdapters.VW_PatientInvoicePaymetReceive_ForIPDTableAdapter();
                ObjPII12U.Fill(ObjPII2U);

                rep.Load(Server.MapPath("~//Report//Rpt_IpdBillDetails_summary_USD.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;


            case "IpdBillSummary_ReportNew":
                DataSetHMS.Vw_IPDBillSummaryDataTable objIPDBillSummary = Objrds.Vw_IPDBillSummary;
                DataSetHMSTableAdapters.Vw_IPDBillSummaryTableAdapter objIPDBillSummaryTA = new DataSetHMSTableAdapters.Vw_IPDBillSummaryTableAdapter();
                objIPDBillSummaryTA.Fill(objIPDBillSummary);
                DataSetHMS.Vw_IPDRegistrationInfoDataTable objIPDRegInfo = Objrds.Vw_IPDRegistrationInfo;
                DataSetHMSTableAdapters.Vw_IPDRegistrationInfoTableAdapter objIPDRegInfoTA = new DataSetHMSTableAdapters.Vw_IPDRegistrationInfoTableAdapter();
                objIPDRegInfoTA.Fill(objIPDRegInfo);

                DataSetHMS.Vw_BillTransactions_BillDataTable objIPDtrans1 = Objrds.Vw_BillTransactions_Bill;
                DataSetHMSTableAdapters.Vw_BillTransactions_BillTableAdapter objIPDtransA1 = new DataSetHMSTableAdapters.Vw_BillTransactions_BillTableAdapter();
                objIPDtransA1.Fill(objIPDtrans1);

                DataSetHMS.VW_PatientInvoicePaymetReceive_ForIPDDataTable ObjPII = Objrds.VW_PatientInvoicePaymetReceive_ForIPD;
                DataSetHMSTableAdapters.VW_PatientInvoicePaymetReceive_ForIPDTableAdapter ObjPII1 = new DataSetHMSTableAdapters.VW_PatientInvoicePaymetReceive_ForIPDTableAdapter();
                ObjPII1.Fill(ObjPII);

                rep.Load(Server.MapPath("~//Report//Rpt_IpdBillDetails_summary..rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
            case "Deposit_Report":
                DataSetHMS.Vw_DepositReportDataTable ObjDeposit = Objrds.Vw_DepositReport;
                DataSetHMSTableAdapters.Vw_DepositReportTableAdapter ObjDepositTA = new DataSetHMSTableAdapters.Vw_DepositReportTableAdapter();
                ObjDepositTA.Fill(ObjDeposit);
                rep.Load(Server.MapPath("~//Report//Rpt_DepositReport.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;

            case "UserWiseIpdDailyCash_Report":
                DataSetHMS.Vw_IpdBillTransactionReportDataTable objIpdBill = Objrds.Vw_IpdBillTransactionReport;
                DataSetHMSTableAdapters.Vw_IpdBillTransactionReportTableAdapter objIpdBillTA = new DataSetHMSTableAdapters.Vw_IpdBillTransactionReportTableAdapter();
                objIpdBillTA.Fill(objIpdBill);
                rep.Load(Server.MapPath("~//Report//Rpt_UserWiseIpdDailyCashReport.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                case "DiscountReport":
                DataSetHMS.Vw_Disvcount_ReportDataTable objDis = Objrds.Vw_Disvcount_Report;
                DataSetHMSTableAdapters.Vw_Disvcount_ReportTableAdapter objDisA = new DataSetHMSTableAdapters.Vw_Disvcount_ReportTableAdapter();
                objDisA.Fill(objDis);
                rep.Load(Server.MapPath("~//Report//Rpt_DiscountReport.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                case "PatientwiseBillGroupIncome_Report":
                DataSetHMS.Vw_PatientwiseBillGroupIncomeDataTable objPatientBill = Objrds.Vw_PatientwiseBillGroupIncome;
                DataSetHMSTableAdapters.Vw_PatientwiseBillGroupIncomeTableAdapter objPatientBillTA = new DataSetHMSTableAdapters.Vw_PatientwiseBillGroupIncomeTableAdapter();
                objPatientBillTA.Fill(objPatientBill);
                rep.Load(Server.MapPath("~//Report//Rpt_PatientwiseBillGroupIncome.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                case "ServicewiseBillGroupIncome_Report":
                DataSetHMS.Vw_PatientwiseBillGroupIncomeDataTable objServiceBill = Objrds.Vw_PatientwiseBillGroupIncome;
                DataSetHMSTableAdapters.Vw_PatientwiseBillGroupIncomeTableAdapter objServiceBillTA = new DataSetHMSTableAdapters.Vw_PatientwiseBillGroupIncomeTableAdapter();
                objServiceBillTA.Fill(objServiceBill);
                rep.Load(Server.MapPath("~//Report//Rpt_ServicewiseBillGroupIncome.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                case "DoctorwiseBillGroupIncome_Report":
                DataSetHMS.Vw_PatientwiseBillGroupIncomeDataTable objDoctorBill = Objrds.Vw_PatientwiseBillGroupIncome;
                DataSetHMSTableAdapters.Vw_PatientwiseBillGroupIncomeTableAdapter objDoctorBillTA = new DataSetHMSTableAdapters.Vw_PatientwiseBillGroupIncomeTableAdapter();
                objDoctorBillTA.Fill(objDoctorBill);
                rep.Load(Server.MapPath("~//Report//Rpt_DoctorwiseBillGroupIncome.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                case "ServiceWiseIncome_Report":
                DataSetHMS.Vw_ServiceWiseIncomeReportDataTable objServiceIncome = Objrds.Vw_ServiceWiseIncomeReport;
                DataSetHMSTableAdapters.Vw_ServiceWiseIncomeReportTableAdapter objServiceIncomeTA = new DataSetHMSTableAdapters.Vw_ServiceWiseIncomeReportTableAdapter();
                objServiceIncomeTA.Fill(objServiceIncome);
                rep.Load(Server.MapPath("~//Report//Rpt_ServiceWiseIncomeReport.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;

                case "DoctorWiseAdvanceReport":
                DataSetHMS.Vw_DoctorWiseAdvanceReceiptDataTable objdoc = Objrds.Vw_DoctorWiseAdvanceReceipt;
                DataSetHMSTableAdapters.Vw_DoctorWiseAdvanceReceiptTableAdapter objdocTA = new DataSetHMSTableAdapters.Vw_DoctorWiseAdvanceReceiptTableAdapter();
                objdocTA.Fill(objdoc);
                rep.Load(Server.MapPath("~//Report//Rpt_DoctorWiseAdvanceReport.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                case "IpdAdmissionRegister":
                DataSetHMS.Vw_IpdAdmissionRegisterDataTable objIpdAdmission = Objrds.Vw_IpdAdmissionRegister;
                DataSetHMSTableAdapters.Vw_IpdAdmissionRegisterTableAdapter objIpdAdmissionTA = new DataSetHMSTableAdapters.Vw_IpdAdmissionRegisterTableAdapter();
                objIpdAdmissionTA.Fill(objIpdAdmission);
                rep.Load(Server.MapPath("~//Report//Rpt_IpdAdmissionRegister.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                case "AdmittedPatientList":
                DataSetHMS.Vw_CurrentAdmittedPatientsDataTable objAdmitPat = Objrds.Vw_CurrentAdmittedPatients;
                DataSetHMSTableAdapters.Vw_CurrentAdmittedPatientsTableAdapter objAdmitPatTA = new DataSetHMSTableAdapters.Vw_CurrentAdmittedPatientsTableAdapter();
                objAdmitPatTA.Fill(objAdmitPat);
                rep.Load(Server.MapPath("~//Report//Rpt_AdmittedPatientList.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                case "PatientCount":
                DataSetHMS.Vw_IPDPatientDetailsNewDataTable objCount = Objrds.Vw_IPDPatientDetailsNew;
                DataSetHMSTableAdapters.Vw_IPDPatientDetailsNewTableAdapter objCountTA = new DataSetHMSTableAdapters.Vw_IPDPatientDetailsNewTableAdapter();
                objCountTA.Fill(objCount);
                rep.Load(Server.MapPath("~//Report//Rpt_PatientCount.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                case "MealsFigureReport":
                DataSetHMS.Vw_MealsFigureReportDataTable objmeal = Objrds.Vw_MealsFigureReport;
                DataSetHMSTableAdapters.Vw_MealsFigureReportTableAdapter objmealTA = new DataSetHMSTableAdapters.Vw_MealsFigureReportTableAdapter();
                objmealTA.Fill(objmeal);
                rep.Load(Server.MapPath("~//Report//Rpt_MealsFigureReport.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);

                break;
                case "BillGroupSalesSummary":
                DataSetHMS.Vw_BillGroupSalesSummaryDataTable objBJSS = Objrds.Vw_BillGroupSalesSummary;
                DataSetHMSTableAdapters.Vw_BillGroupSalesSummaryTableAdapter objBJSS1 = new DataSetHMSTableAdapters.Vw_BillGroupSalesSummaryTableAdapter();
                objBJSS1.Fill(objBJSS);
                rep.Load(Server.MapPath("~//Report//Rpt_BillGroupSalesSummary.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;

            //case "InsuranceSummary":
            //    DataSetHMS.Vw_InsuranceSummaryReportDataTable objIS = Objrds.Vw_InsuranceSummaryReport;
            //    DataSetHMSTableAdapters.Vw_InsuranceSummaryReportTableAdapter objISTA = new DataSetHMSTableAdapters.Vw_InsuranceSummaryReportTableAdapter();
            //    objISTA.Fill(objIS);
            //    rep.Load(Server.MapPath("~//Report//Rpt_InsuranceSummaryReport.rpt"));
            //    rep.SetDataSource((System.Data.DataSet)Objrds);
            //    break;
            case "InsuranceSummary":
                DataSetHMS.Vw_InsuranceSummaryDataTable objIS = Objrds.Vw_InsuranceSummary;
                DataSetHMSTableAdapters.Vw_InsuranceSummaryTableAdapter objISTA = new DataSetHMSTableAdapters.Vw_InsuranceSummaryTableAdapter();
                objISTA.Fill(objIS);
                rep.Load(Server.MapPath("~//Report//Rpt_InsuranceSummaryNew.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;

            case "PatientInvoiceDetails":
                DataSetHMS.Vw_PatientInsuranceDetailsForInvoiceDataTable objPID = Objrds.Vw_PatientInsuranceDetailsForInvoice;
                DataSetHMSTableAdapters.Vw_PatientInsuranceDetailsForInvoiceTableAdapter objPIDTA = new DataSetHMSTableAdapters.Vw_PatientInsuranceDetailsForInvoiceTableAdapter();
                objPIDTA.Fill(objPID);
                rep.Load(Server.MapPath("~//Report//Rpt_PatientInsuranceDetailsInvoice.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;

            case "InsurancePaymentReceipt":
                DataSetHMS.Vw_InsurancePaymentReceipt_RptDataTable objIPR = Objrds.Vw_InsurancePaymentReceipt_Rpt;
                DataSetHMSTableAdapters.Vw_InsurancePaymentReceipt_RptTableAdapter objIPRTA = new DataSetHMSTableAdapters.Vw_InsurancePaymentReceipt_RptTableAdapter();
                objIPRTA.Fill(objIPR);
                rep.Load(Server.MapPath("~//Report//Rpt_InsurancePaymentReceipt.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
            case "InsurancePaymentLedger":
                DataSetHMS.Vw_InsurancePaymentReceipt_RptDataTable objIPL = Objrds.Vw_InsurancePaymentReceipt_Rpt;
                DataSetHMSTableAdapters.Vw_InsurancePaymentReceipt_RptTableAdapter objIPLTA = new DataSetHMSTableAdapters.Vw_InsurancePaymentReceipt_RptTableAdapter();
                objIPLTA.Fill(objIPL);
                rep.Load(Server.MapPath("~//Report//Rpt_InsurancePaymentLedger.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;

            case "ProcedureBillDetails_Report":                
                DataSetHMS.Vw_ProcedureBillServiceDetailsDataTable objPBSD = Objrds.Vw_ProcedureBillServiceDetails;
                DataSetHMSTableAdapters.Vw_ProcedureBillServiceDetailsTableAdapter objPBSDTA = new DataSetHMSTableAdapters.Vw_ProcedureBillServiceDetailsTableAdapter();
                objPBSDTA.Fill(objPBSD);
                DataSetHMS.Vw_procedureBillMasterDataTable objPM=Objrds.Vw_procedureBillMaster;
                DataSetHMSTableAdapters.Vw_procedureBillMasterTableAdapter objPMTA=new DataSetHMSTableAdapters.Vw_procedureBillMasterTableAdapter();
                objPMTA.Fill(objPM);
                rep.Load(Server.MapPath("~//Report//Rpt_ProcedureBillReport.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
            case "CancelProcedureBillReport":
                DataSetHMS.Vw_ProcedureBillServiceDetailsDataTable objPBSD1 = Objrds.Vw_ProcedureBillServiceDetails;
                DataSetHMSTableAdapters.Vw_ProcedureBillServiceDetailsTableAdapter objPBSDTA1 = new DataSetHMSTableAdapters.Vw_ProcedureBillServiceDetailsTableAdapter();
                objPBSDTA1.Fill(objPBSD1);
                DataSetHMS.Vw_procedureBillMasterDataTable objPM1 = Objrds.Vw_procedureBillMaster;
                DataSetHMSTableAdapters.Vw_procedureBillMasterTableAdapter objPMTA1 = new DataSetHMSTableAdapters.Vw_procedureBillMasterTableAdapter();
                objPMTA1.Fill(objPM1);
                rep.Load(Server.MapPath("~//Report//Rpt_CancelProcedureBillReport.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;

            case "UserWiseProcedureCash_Report" :
                DataSetHMS.Vw_ProcedurePaymentTransactionRpt_UserWiseDataTable objPC = Objrds.Vw_ProcedurePaymentTransactionRpt_UserWise;
                DataSetHMSTableAdapters.Vw_ProcedurePaymentTransactionRpt_UserWiseTableAdapter objPCTA = new DataSetHMSTableAdapters.Vw_ProcedurePaymentTransactionRpt_UserWiseTableAdapter();
                objPCTA.Fill(objPC);
                rep.Load(Server.MapPath("~//Report//Rpt_UserWiseProcedureCashReport.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;

            case "ProcedureCancelPatientList":
                DataSetHMS.Vw_CancelprocedureBillMasterDataTable objPC0 = Objrds.Vw_CancelprocedureBillMaster;
                DataSetHMSTableAdapters.Vw_CancelprocedureBillMasterTableAdapter objPCTA0 = new DataSetHMSTableAdapters.Vw_CancelprocedureBillMasterTableAdapter();
                objPCTA0.Fill(objPC0);
                rep.Load(Server.MapPath("~//Report//Rpt_ProcedureCancelPatientList.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;

            case "Rpt_CaseReport":
                DataSetHMS.VW_OPDCasePaperDataTable objOCP = Objrds.VW_OPDCasePaper;
                DataSetHMSTableAdapters.VW_OPDCasePaperTableAdapter objOCP1 = new DataSetHMSTableAdapters.VW_OPDCasePaperTableAdapter();
                objOCP1.Fill(objOCP);
                rep.Load(Server.MapPath("~//Report//Rpt_CaseReport.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
            case "Rpt_OTRegisterReport":
                DataSetHMS.Vw_OTPatientListReportDataTable objOPR = Objrds.Vw_OTPatientListReport;
                DataSetHMSTableAdapters.Vw_OTPatientListReportTableAdapter objOPR1 = new DataSetHMSTableAdapters.Vw_OTPatientListReportTableAdapter();
                objOPR1.Fill(objOPR);
                rep.Load(Server.MapPath("~//Report//Rpt_OTRegisterReport.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
           
            case "ServiceWiseIncomeProcedure_Report":
                DataSetHMS.Vw_ServiceWiseIncomeReport_ProcedureDataTable objServiceIncomeP = Objrds.Vw_ServiceWiseIncomeReport_Procedure;
                DataSetHMSTableAdapters.Vw_ServiceWiseIncomeReport_ProcedureTableAdapter objServiceIncomePTA = new DataSetHMSTableAdapters.Vw_ServiceWiseIncomeReport_ProcedureTableAdapter();
                objServiceIncomePTA.Fill(objServiceIncomeP);
                rep.Load(Server.MapPath("~//Report//Rpt_ServiceWiseIncomeReport_Procedure.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;

            case "PatientwiseBillGroupIncome_Procedure_Report":
                DataSetHMS.Vw_PatientwiseBillGroupIncome_ProcedureDataTable objPatientBillP = Objrds.Vw_PatientwiseBillGroupIncome_Procedure;
                DataSetHMSTableAdapters.Vw_PatientwiseBillGroupIncome_ProcedureTableAdapter objPatientBillPTA = new DataSetHMSTableAdapters.Vw_PatientwiseBillGroupIncome_ProcedureTableAdapter();
                objPatientBillPTA.Fill(objPatientBillP);
                rep.Load(Server.MapPath("~//Report//Rpt_PatientwiseBillGroupIncome_Procedure.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;

            case "ServicewiseBillGroupIncome_Procedure_Report":
                DataSetHMS.Vw_PatientwiseBillGroupIncome_ProcedureDataTable objServiceBillP = Objrds.Vw_PatientwiseBillGroupIncome_Procedure;
                DataSetHMSTableAdapters.Vw_PatientwiseBillGroupIncome_ProcedureTableAdapter objServiceBillPTA = new DataSetHMSTableAdapters.Vw_PatientwiseBillGroupIncome_ProcedureTableAdapter();
                objServiceBillPTA.Fill(objServiceBillP);
                rep.Load(Server.MapPath("~//Report//Rpt_ServicewiseBillGroupIncome_Procedure.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
            case "DoctorwiseBillGroupIncome_Procedure_Report":
                DataSetHMS.Vw_PatientwiseBillGroupIncome_ProcedureDataTable objDoctorBillP = Objrds.Vw_PatientwiseBillGroupIncome_Procedure;
                DataSetHMSTableAdapters.Vw_PatientwiseBillGroupIncome_ProcedureTableAdapter objDoctorBillPTA = new DataSetHMSTableAdapters.Vw_PatientwiseBillGroupIncome_ProcedureTableAdapter();
                objDoctorBillPTA.Fill(objDoctorBillP);
                rep.Load(Server.MapPath("~//Report//Rpt_DoctorwiseBillGroupIncome_Procedure.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
            case "BillGroupSalesSummary_Procedure":
                DataSetHMS.Vw_BillGroupSalesSummary_ProcedureDataTable objBJSSP = Objrds.Vw_BillGroupSalesSummary_Procedure;
                DataSetHMSTableAdapters.Vw_BillGroupSalesSummary_ProcedureTableAdapter objBJSSP1 = new DataSetHMSTableAdapters.Vw_BillGroupSalesSummary_ProcedureTableAdapter();
                objBJSSP1.Fill(objBJSSP);
                rep.Load(Server.MapPath("~//Report//Rpt_BillGroupSalesSummary_Procedure.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;

            case "InsuranceSummaryProcedure":
                DataSetHMS.Vw_InsuranceSummaryForProcedureDataTable objISP = Objrds.Vw_InsuranceSummaryForProcedure;
                DataSetHMSTableAdapters.Vw_InsuranceSummaryForProcedureTableAdapter objISPTA = new DataSetHMSTableAdapters.Vw_InsuranceSummaryForProcedureTableAdapter();
                objISPTA.Fill(objISP);
                rep.Load(Server.MapPath("~//Report//Rpt_InsuranceSummaryProcedure.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;

            case "CashReceipt":
                DataSetHMS.VW_cshbill_PathologyDataTable objISP1 = Objrds.VW_cshbill_Pathology;
                DataSetHMSTableAdapters.VW_cshbill_PathologyTableAdapter objISPTA1 = new DataSetHMSTableAdapters.VW_cshbill_PathologyTableAdapter();
                objISPTA1.Fill(objISP1);
                rep.Load(Server.MapPath("~//Report//Rpt_PayReceiptPathology.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
            case "CashReceiptRad":
                DataSetHMS.VW_cshbill_RadiologyDataTable objISP1R = Objrds.VW_cshbill_Radiology;
                DataSetHMSTableAdapters.VW_cshbill_RadiologyTableAdapter objISPTA1R = new DataSetHMSTableAdapters.VW_cshbill_RadiologyTableAdapter();
                objISPTA1R.Fill(objISP1R);
                rep.Load(Server.MapPath("~//Report//Rpt_PayReceiptRadiology.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
            case "CashReceiptMed":
                DataSetHMS.VW_cshbill_MedicalStoreDataTable objISP1M = Objrds.VW_cshbill_MedicalStore;
                DataSetHMSTableAdapters.VW_cshbill_MedicalStoreTableAdapter objISPTA1M = new DataSetHMSTableAdapters.VW_cshbill_MedicalStoreTableAdapter();
                objISPTA1M.Fill(objISP1M);
                rep.Load(Server.MapPath("~//Report//Rpt_PayReceiptMedical.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
            case "LabReceipt":
                DataSetHMS.Vw_LabBillReportDataTable objOPR22 = Objrds.Vw_LabBillReport;
                DataSetHMSTableAdapters.Vw_LabBillReportTableAdapter objOPR122 = new DataSetHMSTableAdapters.Vw_LabBillReportTableAdapter();
                objOPR122.Fill(objOPR22);
                rep.Load(Server.MapPath("~//Report//Rpt_LabBilling.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
            case "LabFinalBillPrint":
                DataSetHMS.Vw_LabFinalBillReportDataTable objOPR2 = Objrds.Vw_LabFinalBillReport;
                DataSetHMSTableAdapters.Vw_LabFinalBillReportTableAdapter objOPR12 = new DataSetHMSTableAdapters.Vw_LabFinalBillReportTableAdapter();
                objOPR12.Fill(objOPR2);
                rep.Load(Server.MapPath("~//Report//Rpt_LabFinalBillPrint.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;

            case "UserWiseLABCash_Report":
                DataSetHMS.Vw_LabPaymentTransactionRpt_UserWiseDataTable objPCL = Objrds.Vw_LabPaymentTransactionRpt_UserWise;
                DataSetHMSTableAdapters.Vw_LabPaymentTransactionRpt_UserWiseTableAdapter objPCTAL = new DataSetHMSTableAdapters.Vw_LabPaymentTransactionRpt_UserWiseTableAdapter();
                objPCTAL.Fill(objPCL);
                rep.Load(Server.MapPath("~//Report//Rpt_UserWiseLabCashReport.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
            case "InsuranceSummaryLAB":
                DataSetHMS.Vw_InsuranceSummaryForLabNewDataTable objISPL = Objrds.Vw_InsuranceSummaryForLabNew;
                DataSetHMSTableAdapters.Vw_InsuranceSummaryForLabNewTableAdapter objISPTAL = new DataSetHMSTableAdapters.Vw_InsuranceSummaryForLabNewTableAdapter();
                objISPTAL.Fill(objISPL);

                DataSetHMS.Vw_InsuranceSummaryForLabNew_ChildDataTable objISPL1 = Objrds.Vw_InsuranceSummaryForLabNew_Child;
                DataSetHMSTableAdapters.Vw_InsuranceSummaryForLabNew_ChildTableAdapter objISPTAL1 = new DataSetHMSTableAdapters.Vw_InsuranceSummaryForLabNew_ChildTableAdapter();
                objISPTAL1.Fill(objISPL1);

                rep.Load(Server.MapPath("~//Report//Rpt_InsuranceSummaryLAB.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;

            case "UserWiseLABCashCancel_Report":
                DataSetHMS.Vw_LABPaymentTransactionRpt_UserWise_CancelDataTable objPCLC = Objrds.Vw_LABPaymentTransactionRpt_UserWise_Cancel;
                DataSetHMSTableAdapters.Vw_LABPaymentTransactionRpt_UserWise_CancelTableAdapter objPCTALC = new DataSetHMSTableAdapters.Vw_LABPaymentTransactionRpt_UserWise_CancelTableAdapter();
                objPCTALC.Fill(objPCLC);
                rep.Load(Server.MapPath("~//Report//Rpt_UserWiseLabCashCancelReport.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
            case "UserWiseLABCash_ReportRadio":
                DataSetHMS.Vw_LabPaymentTransactionRpt_UserWiseDataTable objPCLR = Objrds.Vw_LabPaymentTransactionRpt_UserWise;
                DataSetHMSTableAdapters.Vw_LabPaymentTransactionRpt_UserWiseTableAdapter objPCTALR = new DataSetHMSTableAdapters.Vw_LabPaymentTransactionRpt_UserWiseTableAdapter();
                objPCTALR.Fill(objPCLR);
                rep.Load(Server.MapPath("~//Report//Rpt_UserWiseLabCashReportRadio.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
            case "IpdTestShow":
                DataSetHMS.Vw_LabIPDBillReportDataTable objOPR22T = Objrds.Vw_LabIPDBillReport;
                DataSetHMSTableAdapters.Vw_LabIPDBillReportTableAdapter objOPR122T = new DataSetHMSTableAdapters.Vw_LabIPDBillReportTableAdapter();
                objOPR122T.Fill(objOPR22T);
                rep.Load(Server.MapPath("~//Report//Rpt_LabIPDTestShow.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
            case "IpdLabServicedetails":
                DataSetHMS.VW_IpdLabServicedetailsDataTable objILS = Objrds.VW_IpdLabServicedetails;
                DataSetHMSTableAdapters.VW_IpdLabServicedetailsTableAdapter objILS1 = new DataSetHMSTableAdapters.VW_IpdLabServicedetailsTableAdapter();
                objILS1.Fill(objILS);
                rep.Load(Server.MapPath("~//Report//Rpt_IpdLabServicedetails.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;

            case "LabEMRReceipt":
                DataSetHMS.Vw_EMRLabBillServiceDetailsDataTable objELB = Objrds.Vw_EMRLabBillServiceDetails;
                DataSetHMSTableAdapters.Vw_EMRLabBillServiceDetailsTableAdapter objELB1 = new DataSetHMSTableAdapters.Vw_EMRLabBillServiceDetailsTableAdapter();
                objELB1.Fill(objELB);
                rep.Load(Server.MapPath("~//Report//Rpt_EMR_Lab_Receipt.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;

            case "Prescription":
                DataSetHMS.VW_GetPrescriptionDataTable objGP = Objrds.VW_GetPrescription;
                DataSetHMSTableAdapters.VW_GetPrescriptionTableAdapter objGP1 = new DataSetHMSTableAdapters.VW_GetPrescriptionTableAdapter();
                objGP1.Fill(objGP);
                rep.Load(Server.MapPath("~//Report//Rpt_Prescription.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;

            case "MedicalLAbReport":
                DataSetHMS.VW_GetPatientInformationDataTable objGPI = Objrds.VW_GetPatientInformation;
                DataSetHMSTableAdapters.VW_GetPatientInformationTableAdapter objGPI1 = new DataSetHMSTableAdapters.VW_GetPatientInformationTableAdapter();
                objGPI1.Fill(objGPI);

                DataSetHMS.VW_patdatvwrecvw_MediLabDataTable objLM = Objrds.VW_patdatvwrecvw_MediLab;
                DataSetHMSTableAdapters.VW_patdatvwrecvw_MediLabTableAdapter objLM1 = new DataSetHMSTableAdapters.VW_patdatvwrecvw_MediLabTableAdapter();
                objLM1.Fill(objLM);

                DataSetHMS.VW_desfiledata_org_MediLabDataTable objLMD = Objrds.VW_desfiledata_org_MediLab;
                DataSetHMSTableAdapters.VW_desfiledata_org_MediLabTableAdapter objLMD1 = new DataSetHMSTableAdapters.VW_desfiledata_org_MediLabTableAdapter();
                objLMD1.Fill(objLMD);

                rep.Load(Server.MapPath("~//Report//Pateintreportnondescriptive_MediLab.rpt"));//
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;

            case "PathoLAbReport":
                DataSetHMS.VW_GetPatientInformationDataTable objGPIP = Objrds.VW_GetPatientInformation;
                DataSetHMSTableAdapters.VW_GetPatientInformationTableAdapter objGPI1P = new DataSetHMSTableAdapters.VW_GetPatientInformationTableAdapter();
                objGPI1P.Fill(objGPIP);

                DataSetHMS.VW_desfiledata_org_PathologyDataTable objLPD = Objrds.VW_desfiledata_org_Pathology;
                DataSetHMSTableAdapters.VW_desfiledata_org_PathologyTableAdapter objLPD1 = new DataSetHMSTableAdapters.VW_desfiledata_org_PathologyTableAdapter();
                objLPD1.Fill(objLPD);

                rep.Load(Server.MapPath("~//Report//Pateintreportdescriptive_Patho.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
            case "RadioLAbReport":
                DataSetHMS.VW_GetPatientInformationDataTable objGPIR = Objrds.VW_GetPatientInformation;
                DataSetHMSTableAdapters.VW_GetPatientInformationTableAdapter objGPI1R = new DataSetHMSTableAdapters.VW_GetPatientInformationTableAdapter();
                objGPI1R.Fill(objGPIR);

                DataSetHMS.VW_desfiledata_org_RadiologyDataTable objLRD = Objrds.VW_desfiledata_org_Radiology;
                DataSetHMSTableAdapters.VW_desfiledata_org_RadiologyTableAdapter objLRD1 = new DataSetHMSTableAdapters.VW_desfiledata_org_RadiologyTableAdapter();
                objLRD1.Fill(objLRD);

                rep.Load(Server.MapPath("~//Report//Pateintreportdescriptive_Radio.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;

            case "Rpt_DailyNurseNotes":
                DataSetHMS.Vw_DailyNurseNoteDataTable objdrDN = Objrds.Vw_DailyNurseNote;
                DataSetHMSTableAdapters.Vw_DailyNurseNoteTableAdapter objdrDN1 = new DataSetHMSTableAdapters.Vw_DailyNurseNoteTableAdapter();
                objdrDN1.Fill(objdrDN);
                DataSetHMS.VW_GetPatientInformationDataTable objdrPI = Objrds.VW_GetPatientInformation;
                DataSetHMSTableAdapters.VW_GetPatientInformationTableAdapter objdrPI1 = new DataSetHMSTableAdapters.VW_GetPatientInformationTableAdapter();
                objdrPI1.Fill(objdrPI);
                rep.Load(Server.MapPath("~//Report//Rpt_DailyNurseNotes.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;

            case "Rpt_DailyDoctorNotes":
                DataSetHMS.Vw_DailyDoctorNoteDataTable objdrDocN = Objrds.Vw_DailyDoctorNote;
                DataSetHMSTableAdapters.Vw_DailyDoctorNoteTableAdapter objdrDocN1 = new DataSetHMSTableAdapters.Vw_DailyDoctorNoteTableAdapter();
                objdrDocN1.Fill(objdrDocN);
                DataSetHMS.VW_GetPatientInformationDataTable objdrDPI = Objrds.VW_GetPatientInformation;
                DataSetHMSTableAdapters.VW_GetPatientInformationTableAdapter objdrDPI1 = new DataSetHMSTableAdapters.VW_GetPatientInformationTableAdapter();
                objdrDPI1.Fill(objdrDPI);
                rep.Load(Server.MapPath("~//Report//Rpt_DailyDoctorNotes.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
            case "Rpt_IVChart":
                DataSetHMS.Vw_IVChartDataTable objdrDocIV = Objrds.Vw_IVChart;
                DataSetHMSTableAdapters.Vw_IVChartTableAdapter objdrDocIV1 = new DataSetHMSTableAdapters.Vw_IVChartTableAdapter();
                objdrDocIV1.Fill(objdrDocIV);
                DataSetHMS.VW_GetPatientInformationDataTable objdrDIVPI = Objrds.VW_GetPatientInformation;
                DataSetHMSTableAdapters.VW_GetPatientInformationTableAdapter objdrDIVPI1 = new DataSetHMSTableAdapters.VW_GetPatientInformationTableAdapter();
                objdrDIVPI1.Fill(objdrDIVPI);
                rep.Load(Server.MapPath("~//Report//Rpt_IVChart.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
            case "Rpt_IntakeOutputChart":
                DataSetHMS.Vw_IntakeOutputSheetDataTable objdrDocIOS = Objrds.Vw_IntakeOutputSheet;
                DataSetHMSTableAdapters.Vw_IntakeOutputSheetTableAdapter objdrDocIOS1 = new DataSetHMSTableAdapters.Vw_IntakeOutputSheetTableAdapter();
                objdrDocIOS1.Fill(objdrDocIOS);
                DataSetHMS.VW_GetPatientInformationDataTable objdrDIOPI = Objrds.VW_GetPatientInformation;
                DataSetHMSTableAdapters.VW_GetPatientInformationTableAdapter objdrDIOPI1 = new DataSetHMSTableAdapters.VW_GetPatientInformationTableAdapter();
                objdrDIOPI1.Fill(objdrDIOPI);
                rep.Load(Server.MapPath("~//Report//Rpt_IntakeOutputChart.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;

            case "Rpt_PatTreatmentSheet":
                DataSetHMS.Vw_PatTreatmentSheetDataTable objPT = Objrds.Vw_PatTreatmentSheet;
                DataSetHMSTableAdapters.Vw_PatTreatmentSheetTableAdapter objdrPT1 = new DataSetHMSTableAdapters.Vw_PatTreatmentSheetTableAdapter();
                objdrPT1.Fill(objPT);
                DataSetHMS.VW_GetPatientInformationDataTable objPTPI = Objrds.VW_GetPatientInformation;
                DataSetHMSTableAdapters.VW_GetPatientInformationTableAdapter objdrPTPI1 = new DataSetHMSTableAdapters.VW_GetPatientInformationTableAdapter();
                objdrPTPI1.Fill(objPTPI);
                rep.Load(Server.MapPath("~//Report//Rpt_PatTreatmentSheet.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;

            case "Rpt_DiabeticSheet":
                DataSetHMS.Vw_DiabeticSheetDataTable objDS = Objrds.Vw_DiabeticSheet;
                DataSetHMSTableAdapters.Vw_DiabeticSheetTableAdapter objdrDS1 = new DataSetHMSTableAdapters.Vw_DiabeticSheetTableAdapter();
                objdrDS1.Fill(objDS);
                DataSetHMS.VW_GetPatientInformationDataTable objDSPI = Objrds.VW_GetPatientInformation;
                DataSetHMSTableAdapters.VW_GetPatientInformationTableAdapter objdrDSPI1 = new DataSetHMSTableAdapters.VW_GetPatientInformationTableAdapter();
                objdrDSPI1.Fill(objDSPI);
                rep.Load(Server.MapPath("~//Report//Rpt_DiabeticSheet.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;

            case "Rpt_BloodTransfusion":
                DataSetHMS.Vw_BloodTransfusionDataTable objBS = Objrds.Vw_BloodTransfusion;
                DataSetHMSTableAdapters.Vw_BloodTransfusionTableAdapter objdrBS1 = new DataSetHMSTableAdapters.Vw_BloodTransfusionTableAdapter();
                objdrBS1.Fill(objBS);
                DataSetHMS.VW_GetPatientInformationDataTable objBSPI = Objrds.VW_GetPatientInformation;
                DataSetHMSTableAdapters.VW_GetPatientInformationTableAdapter objdrBSPI1 = new DataSetHMSTableAdapters.VW_GetPatientInformationTableAdapter();
                objdrBSPI1.Fill(objBSPI);
                rep.Load(Server.MapPath("~//Report//Rpt_BloodTransfusion.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;

            case "Rpt_PatientPhiscalExam":
                DataSetHMS.Vw_GetPatientPhiscalExamDataTable objGPE = Objrds.Vw_GetPatientPhiscalExam;
                DataSetHMSTableAdapters.Vw_GetPatientPhiscalExamTableAdapter objGPE1 = new DataSetHMSTableAdapters.Vw_GetPatientPhiscalExamTableAdapter();
                objGPE1.Fill(objGPE);
                rep.Load(Server.MapPath("~//Report//Rpt_PatientPhiscalExam.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
            case "Rpt_PatientHisForm":
                DataSetHMS.Vw_GetPatientPatientHistoryFormDataTable objPHF = Objrds.Vw_GetPatientPatientHistoryForm;
                DataSetHMSTableAdapters.Vw_GetPatientPatientHistoryFormTableAdapter objPHF1 = new DataSetHMSTableAdapters.Vw_GetPatientPatientHistoryFormTableAdapter();
                objPHF1.Fill(objPHF);
                rep.Load(Server.MapPath("~//Report//Rpt_PatientHisForm.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;

            case "DischargeSummaryReport":
                DataSetHMS.VW_DischargeSummaryDataTable ObjVP12 = Objrds.VW_DischargeSummary;
                DataSetHMSTableAdapters.VW_DischargeSummaryTableAdapter ObjVP11 = new DataSetHMSTableAdapters.VW_DischargeSummaryTableAdapter();
                ObjVP11.Fill(ObjVP12);

                //DataSetHMS.VW_patdatvwrecvw_HMSDataTable ObjVP120 = Objrds.VW_patdatvwrecvw_HMS;
                //DataSetHMSTableAdapters.VW_patdatvwrecvw_HMSTableAdapter ObjVP110 = new DataSetHMSTableAdapters.VW_patdatvwrecvw_HMSTableAdapter();
                //ObjVP110.Fill(ObjVP120);

                //DataSetHMS.VW_desfiledata_org_HMSDataTable ObjVP1205 = Objrds.VW_desfiledata_org_HMS;
                //DataSetHMSTableAdapters.VW_desfiledata_org_HMSTableAdapter ObjVP1105 = new DataSetHMSTableAdapters.VW_desfiledata_org_HMSTableAdapter();
                //ObjVP1105.Fill(ObjVP1205);

                rep.Load(Server.MapPath("~//Report//Rpt_DischargeSummaryReport.rpt"));
                //rep.Load(Server.MapPath("~//Report//Pateintreportdescriptive.rpt"));

                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
            case "UserWiseProcedureCash_Report_service":
                DataSetHMS.Vw_ProcedurePaymentTransactionRpt_UserWise_serviceDataTable ObjPUS = Objrds.Vw_ProcedurePaymentTransactionRpt_UserWise_service;
                DataSetHMSTableAdapters.Vw_ProcedurePaymentTransactionRpt_UserWise_serviceTableAdapter ObjPUS1 = new DataSetHMSTableAdapters.Vw_ProcedurePaymentTransactionRpt_UserWise_serviceTableAdapter();
                ObjPUS1.Fill(ObjPUS);
                rep.Load(Server.MapPath("~//Report//Rpt_UserWiseProcedureCashReport_service.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;


            case "UserWiseLABCharge_Report":
                DataSetHMS.Vw_LabPaymentTransactionRpt_UserWiseDataTable objPCL5 = Objrds.Vw_LabPaymentTransactionRpt_UserWise;
                DataSetHMSTableAdapters.Vw_LabPaymentTransactionRpt_UserWiseTableAdapter objPCTAL5 = new DataSetHMSTableAdapters.Vw_LabPaymentTransactionRpt_UserWiseTableAdapter();
                objPCTAL5.Fill(objPCL5);
                rep.Load(Server.MapPath("~//Report//Rpt_UserWiseLabChargeReport.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
            case "Rpt_CaseReport_New":
                DataSetHMS.VW_OPDCasePaper_NewDataTable objCPN = Objrds.VW_OPDCasePaper_New;
                DataSetHMSTableAdapters.VW_OPDCasePaper_NewTableAdapter objCPN1 = new DataSetHMSTableAdapters.VW_OPDCasePaper_NewTableAdapter();
                objCPN1.Fill(objCPN);
                rep.Load(Server.MapPath("~//Report//Rpt_CaseReport_New.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;

            case "Rpt_GetDataForm_New":
                DataSetHMS.VW_GetDataFormDataTable objGDF = Objrds.VW_GetDataForm;
                DataSetHMSTableAdapters.VW_GetDataFormTableAdapter objGDF1 = new DataSetHMSTableAdapters.VW_GetDataFormTableAdapter();
                objGDF1.Fill(objGDF);
                rep.Load(Server.MapPath("~//Report//Rpt_GetDataForm_New.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
            case "PatientInvoiceDetails_OPD":
                DataSetHMS.Vw_PatientInsuranceDetailsForInvoice_ForOPDDataTable objPIDO = Objrds.Vw_PatientInsuranceDetailsForInvoice_ForOPD;
                DataSetHMSTableAdapters.Vw_PatientInsuranceDetailsForInvoice_ForOPDTableAdapter objPIDTAO = new DataSetHMSTableAdapters.Vw_PatientInsuranceDetailsForInvoice_ForOPDTableAdapter();
                objPIDTAO.Fill(objPIDO);
                rep.Load(Server.MapPath("~//Report//Rpt_PatientInsuranceDetailsInvoice_OPD.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;

            case "InsurancePaymentReceipt_ForOPD":
                DataSetHMS.Vw_InsurancePaymentReceipt_OPDDataTable objIPRR = Objrds.Vw_InsurancePaymentReceipt_OPD;
                DataSetHMSTableAdapters.Vw_InsurancePaymentReceipt_OPDTableAdapter objIPRTAR = new DataSetHMSTableAdapters.Vw_InsurancePaymentReceipt_OPDTableAdapter();
                objIPRTAR.Fill(objIPRR);
                rep.Load(Server.MapPath("~//Report//Rpt_InsurancePaymentReceipt_ForOPD.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;

            case "InsurancePaymentLedger_ForOPD":
                DataSetHMS.Vw_InsuranceCompTransactionLedge_ForOPDDataTable objIPLO = Objrds.Vw_InsuranceCompTransactionLedge_ForOPD;
                DataSetHMSTableAdapters.Vw_InsuranceCompTransactionLedge_ForOPDTableAdapter objIPLTAO = new DataSetHMSTableAdapters.Vw_InsuranceCompTransactionLedge_ForOPDTableAdapter();
                objIPLTAO.Fill(objIPLO);
                rep.Load(Server.MapPath("~//Report//Rpt_InsurancePaymentLedger_ForOPD.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;

            case "PatientInvoiceDetails_ForOPD":
                DataSetHMS.Vw_PatientInsuranceDetailsForInvoice_ForOPD_ReportDataTable objPIDOF = Objrds.Vw_PatientInsuranceDetailsForInvoice_ForOPD_Report;
                DataSetHMSTableAdapters.Vw_PatientInsuranceDetailsForInvoice_ForOPD_ReportTableAdapter objPIDTAOF = new DataSetHMSTableAdapters.Vw_PatientInsuranceDetailsForInvoice_ForOPD_ReportTableAdapter();
                objPIDTAOF.Fill(objPIDOF);

                DataSetHMS.Vw_PatientInsuranceChargeBill_Transaction_ReportDataTable objPIDOF2 = Objrds.Vw_PatientInsuranceChargeBill_Transaction_Report;
                DataSetHMSTableAdapters.Vw_PatientInsuranceChargeBill_Transaction_ReportTableAdapter objPIDTAOF2 = new DataSetHMSTableAdapters.Vw_PatientInsuranceChargeBill_Transaction_ReportTableAdapter();
                objPIDTAOF2.Fill(objPIDOF2);

                DataSetHMS.VW_PatientInvoicePaymetReceiveDataTable objPPRO = Objrds.VW_PatientInvoicePaymetReceive;
                DataSetHMSTableAdapters.VW_PatientInvoicePaymetReceiveTableAdapter objPPR1O = new DataSetHMSTableAdapters.VW_PatientInvoicePaymetReceiveTableAdapter();
                objPPR1O.Fill(objPPRO);

                rep.Load(Server.MapPath("~//Report//Rpt_PatientInsuranceDetails_ForOPD.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
            case "PatientInvoiceDetails_ForOPD_USD":
                DataSetHMS.Vw_PatientInsuranceDetailsForInvoice_ForOPD_ReportDataTable objPIDOF1 = Objrds.Vw_PatientInsuranceDetailsForInvoice_ForOPD_Report;
                DataSetHMSTableAdapters.Vw_PatientInsuranceDetailsForInvoice_ForOPD_ReportTableAdapter objPIDTAOF1 = new DataSetHMSTableAdapters.Vw_PatientInsuranceDetailsForInvoice_ForOPD_ReportTableAdapter();
                objPIDTAOF1.Fill(objPIDOF1);

                DataSetHMS.Vw_PatientInsuranceChargeBill_Transaction_ReportDataTable objPIDOF21 = Objrds.Vw_PatientInsuranceChargeBill_Transaction_Report;
                DataSetHMSTableAdapters.Vw_PatientInsuranceChargeBill_Transaction_ReportTableAdapter objPIDTAOF21 = new DataSetHMSTableAdapters.Vw_PatientInsuranceChargeBill_Transaction_ReportTableAdapter();
                objPIDTAOF21.Fill(objPIDOF21);

                DataSetHMS.VW_PatientInvoicePaymetReceiveDataTable objPPRO1 = Objrds.VW_PatientInvoicePaymetReceive;
                DataSetHMSTableAdapters.VW_PatientInvoicePaymetReceiveTableAdapter objPPR1O1 = new DataSetHMSTableAdapters.VW_PatientInvoicePaymetReceiveTableAdapter();
                objPPR1O1.Fill(objPPRO1);

                rep.Load(Server.MapPath("~//Report//Rpt_PatientInsuranceDetails_ForOPD_USD.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;

            case "AllInsurancePatient_ForOPD":
                DataSetHMS.Vw_AllInvoicePatient_ForOPDDataTable objPIDOF19 = Objrds.Vw_AllInvoicePatient_ForOPD;
                DataSetHMSTableAdapters.Vw_AllInvoicePatient_ForOPDTableAdapter objPIDTAOF19 = new DataSetHMSTableAdapters.Vw_AllInvoicePatient_ForOPDTableAdapter();
                objPIDTAOF19.Fill(objPIDOF19);
                rep.Load(Server.MapPath("~//Report//Rpt_AllInsurancePatient_ForOPD.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;

            case "GenerateChargeNumber":
                DataSetHMS.VW_GenerateChargeNumberDataTable objVGCN = Objrds.VW_GenerateChargeNumber;
                DataSetHMSTableAdapters.VW_GenerateChargeNumberTableAdapter objVGCN1 = new DataSetHMSTableAdapters.VW_GenerateChargeNumberTableAdapter();
                objVGCN1.Fill(objVGCN);
                rep.Load(Server.MapPath("~//Report//Rpt_GenerateChargeNumber.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
            case "AllInsuranceDetails":
                DataSetHMS.VW_GetAllInsurance_detailsDataTable ObjAID = Objrds.VW_GetAllInsurance_details;
                DataSetHMSTableAdapters.VW_GetAllInsurance_detailsTableAdapter ObjAID1 = new DataSetHMSTableAdapters.VW_GetAllInsurance_detailsTableAdapter();
                ObjAID1.Fill(ObjAID);
                rep.Load(Server.MapPath("~//Report//Rpt_AllInsuranceDetails.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;

                  case "AllInsurancePatDetails":
                DataSetHMS.Vw_PatientInsuranceDetailsFor_InsuranceCompanyDataTable ObjPIC = Objrds.Vw_PatientInsuranceDetailsFor_InsuranceCompany;
                DataSetHMSTableAdapters.Vw_PatientInsuranceDetailsFor_InsuranceCompanyTableAdapter ObjPIC1 = new DataSetHMSTableAdapters.Vw_PatientInsuranceDetailsFor_InsuranceCompanyTableAdapter();
                ObjPIC1.Fill(ObjPIC);

                DataSetHMS.Vw_PatientInsuranceChargeBill_Transaction_Report_NewDataTable objPIDOF5 = Objrds.Vw_PatientInsuranceChargeBill_Transaction_Report_New;
                DataSetHMSTableAdapters.Vw_PatientInsuranceChargeBill_Transaction_Report_NewTableAdapter objPIDTAOF5 = new DataSetHMSTableAdapters.Vw_PatientInsuranceChargeBill_Transaction_Report_NewTableAdapter();
                objPIDTAOF5.Fill(objPIDOF5);

                DataSetHMS.VW_PatientInvoicePaymetReceiveDataTable objPPR = Objrds.VW_PatientInvoicePaymetReceive;
                DataSetHMSTableAdapters.VW_PatientInvoicePaymetReceiveTableAdapter objPPR1 = new DataSetHMSTableAdapters.VW_PatientInvoicePaymetReceiveTableAdapter();
                objPPR1.Fill(objPPR);

                rep.Load(Server.MapPath("~//Report//Rpt_PatientInsuranceCompanywiseDetails.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;

                  case "Rpt_RoomStatusReport":
                DataSetHMS.Vw_RoomSatusDataTable ObjRS = Objrds.Vw_RoomSatus;
                DataSetHMSTableAdapters.Vw_RoomSatusTableAdapter ObjRS1 = new DataSetHMSTableAdapters.Vw_RoomSatusTableAdapter();
                ObjRS1.Fill(ObjRS);
                rep.Load(Server.MapPath("~//Report//Rpt_RoomStatusReport.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                  case "Rpt_RoomStatusDetailsReport":
                DataSetHMS.Vw_RoomSatus_DetailsDataTable ObjRS9 = Objrds.Vw_RoomSatus_Details;
                DataSetHMSTableAdapters.Vw_RoomSatus_DetailsTableAdapter ObjRS19 = new DataSetHMSTableAdapters.Vw_RoomSatus_DetailsTableAdapter();
                ObjRS19.Fill(ObjRS9);
                rep.Load(Server.MapPath("~//Report//Rpt_RoomStatusDetailsReport.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                  case "Rpt_IPDRefundPatientReport":
                DataSetHMS.Vw_IpdPatientRefundListDataTable ObjIPRL = Objrds.Vw_IpdPatientRefundList;
                DataSetHMSTableAdapters.Vw_IpdPatientRefundListTableAdapter ObjIPRL1 = new DataSetHMSTableAdapters.Vw_IpdPatientRefundListTableAdapter();
                ObjIPRL1.Fill(ObjIPRL);
                rep.Load(Server.MapPath("~//Report//Rpt_IPDRefundPatientReport.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;

                  case "Rpt_IPDDuePatientReport":
                DataSetHMS.Vw_IpdPatientDueListDataTable ObjIPDL = Objrds.Vw_IpdPatientDueList;
                DataSetHMSTableAdapters.Vw_IpdPatientDueListTableAdapter ObjIPDL1 = new DataSetHMSTableAdapters.Vw_IpdPatientDueListTableAdapter();
                ObjIPDL1.Fill(ObjIPDL);
                rep.Load(Server.MapPath("~//Report//Rpt_IPDDuePatientReport.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                  case "Rpt_IPDDuePatientReport_MRC":
                DataSetHMS.Vw_IpdPatientDueListDataTable ObjIPDLMRC = Objrds.Vw_IpdPatientDueList;
                DataSetHMSTableAdapters.Vw_IpdPatientDueListTableAdapter ObjIPDLMRC1 = new DataSetHMSTableAdapters.Vw_IpdPatientDueListTableAdapter();
                ObjIPDLMRC1.Fill(ObjIPDLMRC);
                rep.Load(Server.MapPath("~//Report//Rpt_IPDDuePatientReport_MRC.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                  case "Rpt_DrCensusReport":
                DataSetHMS.VW_DrWiseMonthlyCensusReportDataTable ObjVFM11 = Objrds.VW_DrWiseMonthlyCensusReport;
                DataSetHMSTableAdapters.VW_DrWiseMonthlyCensusReportTableAdapter ObjVFM111 = new DataSetHMSTableAdapters.VW_DrWiseMonthlyCensusReportTableAdapter();
                ObjVFM111.Fill(ObjVFM11);

                rep.Load(Server.MapPath("~//Report//Rpt_DrCensusReport.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                  case "Rpt_OutPatientChargeAccountReport":
                DataSetHMS.VW_OutPatientChargeAccountDataTable Objcpca= Objrds.VW_OutPatientChargeAccount;
                DataSetHMSTableAdapters.VW_OutPatientChargeAccountTableAdapter Objcpca1 = new DataSetHMSTableAdapters.VW_OutPatientChargeAccountTableAdapter();
                Objcpca1.Fill(Objcpca);

                rep.Load(Server.MapPath("~//Report//Rpt_OutPatientChargeAccountReport.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;

                  case "DoctorwiseBillGroupIncome_single":
                DataSetHMS.Vw_PatientwiseBillGroupIncomeDataTable objDoctorBillS = Objrds.Vw_PatientwiseBillGroupIncome;
                DataSetHMSTableAdapters.Vw_PatientwiseBillGroupIncomeTableAdapter objDoctorBillTAS = new DataSetHMSTableAdapters.Vw_PatientwiseBillGroupIncomeTableAdapter();
                objDoctorBillTAS.Fill(objDoctorBillS);
                rep.Load(Server.MapPath("~//Report//Rpt_DoctorwiseBillGroupIncome_single.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                  case "GeneralGynologyComplaints":
                DataSetHMS.VW_GetGeneralGynologyComplaintsDataTable objGC = Objrds.VW_GetGeneralGynologyComplaints;
                DataSetHMSTableAdapters.VW_GetGeneralGynologyComplaintsTableAdapter objGC1 = new DataSetHMSTableAdapters.VW_GetGeneralGynologyComplaintsTableAdapter();
                objGC1.Fill(objGC);
                rep.Load(Server.MapPath("~//Report//Rpt_GeneralGynocologyComplants.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                  case "UterineInsemination":
                DataSetHMS.VW_GetIntraUterineInseminationDataTable objIUI= Objrds.VW_GetIntraUterineInsemination;
                DataSetHMSTableAdapters.VW_GetIntraUterineInseminationTableAdapter objIUI1 = new DataSetHMSTableAdapters.VW_GetIntraUterineInseminationTableAdapter();
                objIUI1.Fill(objIUI);
                rep.Load(Server.MapPath("~//Report//Rpt_UterineInsemination.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                  case "IVFFollicular":
                DataSetHMS.VW_GetIVFFollicularDataTable objIVF = Objrds.VW_GetIVFFollicular;
                DataSetHMSTableAdapters.VW_GetIVFFollicularTableAdapter objIVF1 = new DataSetHMSTableAdapters.VW_GetIVFFollicularTableAdapter();
                objIVF1.Fill(objIVF);
                rep.Load(Server.MapPath("~//Report//Rpt_IVFFollicular.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                  case "Colposcopy":
                DataSetHMS.VW_GetColposcopyDataTable objcol = Objrds.VW_GetColposcopy;
                DataSetHMSTableAdapters.VW_GetColposcopyTableAdapter objcol1 = new DataSetHMSTableAdapters.VW_GetColposcopyTableAdapter();
                objcol1.Fill(objcol);
                rep.Load(Server.MapPath("~//Report//Rpt_Colposcopy.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                  case "OxytoxinAugmentation":
                DataSetHMS.VW_GetOxytoxinAugmentationDataTable objoa = Objrds.VW_GetOxytoxinAugmentation;
                DataSetHMSTableAdapters.VW_GetOxytoxinAugmentationTableAdapter objoa1 = new DataSetHMSTableAdapters.VW_GetOxytoxinAugmentationTableAdapter();
                objoa1.Fill(objoa);
                rep.Load(Server.MapPath("~//Report//Rpt_OxytoxinAugmentation.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                  case "VitroFertilization":
                DataSetHMS.VW_GetVitroFertilizationDataTable objVF = Objrds.VW_GetVitroFertilization;
                DataSetHMSTableAdapters.VW_GetVitroFertilizationTableAdapter objVF1 = new DataSetHMSTableAdapters.VW_GetVitroFertilizationTableAdapter();
                objVF1.Fill(objVF);
                rep.Load(Server.MapPath("~//Report//Rpt_VitroFertilization.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                  case "Infertility":
                DataSetHMS.VW_GetInfertilityDataTable objIFY = Objrds.VW_GetInfertility;
                DataSetHMSTableAdapters.VW_GetInfertilityTableAdapter objIFY1 = new DataSetHMSTableAdapters.VW_GetInfertilityTableAdapter();
                objIFY1.Fill(objIFY);
                rep.Load(Server.MapPath("~//Report//Rpt_Infertility.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                  case "ExaminationFinding":
                DataSetHMS.VW_GetExaminationFindingDataTable objEF = Objrds.VW_GetExaminationFinding;
                DataSetHMSTableAdapters.VW_GetExaminationFindingTableAdapter objEF1 = new DataSetHMSTableAdapters.VW_GetExaminationFindingTableAdapter();
                objEF1.Fill(objEF);
                rep.Load(Server.MapPath("~//Report//Rpt_ExaminationFinding.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                  case "Insurance_PaymentRec":
                DataSetHMS.Vw_Insurance_PaymentRecDataTable objIPR0 = Objrds.Vw_Insurance_PaymentRec;
                DataSetHMSTableAdapters.Vw_Insurance_PaymentRecTableAdapter objIPR01 = new DataSetHMSTableAdapters.Vw_Insurance_PaymentRecTableAdapter();
                objIPR01.Fill(objIPR0);
                rep.Load(Server.MapPath("~//Report//Rpt_Insurance_PaymentRec.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;


                  case "IPDInsurancePatientList":
                DataSetHMS.Vw_InsuranceBillAmountTotalDataTable objPII = Objrds.Vw_InsuranceBillAmountTotal;
                DataSetHMSTableAdapters.Vw_InsuranceBillAmountTotalTableAdapter objPII1 = new DataSetHMSTableAdapters.Vw_InsuranceBillAmountTotalTableAdapter();
                objPII1.Fill(objPII);
                rep.Load(Server.MapPath("~//Report//Rpt_IPDInsurancePatientList.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;

                  case "CashVoucher_PaymentReceipt":
                DataSetHMS.Vw_CashVoucherAllPaymentReceipts_ReportDataTable objCVPR = Objrds.Vw_CashVoucherAllPaymentReceipts_Report;
                DataSetHMSTableAdapters.Vw_CashVoucherAllPaymentReceipts_ReportTableAdapter objCVPR1 = new DataSetHMSTableAdapters.Vw_CashVoucherAllPaymentReceipts_ReportTableAdapter();
                objCVPR1.Fill(objCVPR);
                rep.Load(Server.MapPath("~//Report//Rpt_CashVoucher_PaymentReceipt.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;

                  case "Theatre_CheckList":
                DataSetHMS.Vw_Theatre_CheckListDataTable ObjTCL = Objrds.Vw_Theatre_CheckList;
                DataSetHMSTableAdapters.Vw_Theatre_CheckListTableAdapter ObjTCL1 = new DataSetHMSTableAdapters.Vw_Theatre_CheckListTableAdapter();
                ObjTCL1.Fill(ObjTCL);
                rep.Load(Server.MapPath("~//Report//Rpt_Theatre_CheckList.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;

                  case "NurseShiftReport":
                DataSetHMS.Vw_NurseShiftReportDataTable ObjNSR = Objrds.Vw_NurseShiftReport;
                DataSetHMSTableAdapters.Vw_NurseShiftReportTableAdapter ObjNSR1 = new DataSetHMSTableAdapters.Vw_NurseShiftReportTableAdapter();
                ObjNSR1.Fill(ObjNSR);
                rep.Load(Server.MapPath("~//Report//Rpt_NurseShiftReport.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;

                  case "MonitorUsed_Record":
                DataSetHMS.Vw_MonitorUsed_RecordDataTable ObjMUR = Objrds.Vw_MonitorUsed_Record;
                DataSetHMSTableAdapters.Vw_MonitorUsed_RecordTableAdapter ObjMUR1 = new DataSetHMSTableAdapters.Vw_MonitorUsed_RecordTableAdapter();
                ObjMUR1.Fill(ObjMUR);
                rep.Load(Server.MapPath("~//Report//Rpt_MonitorUsedReport.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;

                  case "OxygenUsed_Record":
                DataSetHMS.Vw_OxygenUsed_RecordDataTable ObjXUR = Objrds.Vw_OxygenUsed_Record;
                DataSetHMSTableAdapters.Vw_OxygenUsed_RecordTableAdapter ObjXUR1 = new DataSetHMSTableAdapters.Vw_OxygenUsed_RecordTableAdapter();
                ObjXUR1.Fill(ObjXUR);
                rep.Load(Server.MapPath("~//Report//Rpt_OxygenUsedReport.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                  case "BloodSugarReport":
                DataSetHMS.Vw_BloodSugar_RecordDataTable ObjBSR = Objrds.Vw_BloodSugar_Record;
                DataSetHMSTableAdapters.Vw_BloodSugar_RecordTableAdapter ObjBSR1 = new DataSetHMSTableAdapters.Vw_BloodSugar_RecordTableAdapter();
                ObjBSR1.Fill(ObjBSR);
                rep.Load(Server.MapPath("~//Report//Rpt_BloodSugarReport.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                  case "Investigation_Record":
                DataSetHMS.Vw_Investigation_RecordDataTable ObjIR= Objrds.Vw_Investigation_Record;
                DataSetHMSTableAdapters.Vw_Investigation_RecordTableAdapter ObjIR1 = new DataSetHMSTableAdapters.Vw_Investigation_RecordTableAdapter();
                ObjIR1.Fill(ObjIR);
                rep.Load(Server.MapPath("~//Report//Rpt_Investigation_Record.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;

                  case "TotalVisitHospitalPatients":
                DataSetHMS.VW_TotalVisitHospitalPatientsDataTable ObjTVH = Objrds.VW_TotalVisitHospitalPatients;
                DataSetHMSTableAdapters.VW_TotalVisitHospitalPatientsTableAdapter ObjTVH1 = new DataSetHMSTableAdapters.VW_TotalVisitHospitalPatientsTableAdapter();
                ObjTVH1.Fill(ObjTVH);
                rep.Load(Server.MapPath("~//Report//Rpt_TotalVisitHospitalPatients.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                  case "MedicalInsuranceClaim":
                DataSetHMS.Vw_MedicalInsuranceClaimDataTable ObjMIC = Objrds.Vw_MedicalInsuranceClaim;
                DataSetHMSTableAdapters.Vw_MedicalInsuranceClaimTableAdapter ObjMIC1 = new DataSetHMSTableAdapters.Vw_MedicalInsuranceClaimTableAdapter();
                ObjMIC1.Fill(ObjMIC);
                rep.Load(Server.MapPath("~//Report//Rpt_MedicalInsuranceClaim.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                  case "TwoHourlyRepositiory":
                DataSetHMS.Vw_TwoHourlyRepositioning_RecordDataTable ObjTHR = Objrds.Vw_TwoHourlyRepositioning_Record;
                DataSetHMSTableAdapters.Vw_TwoHourlyRepositioning_RecordTableAdapter ObjTHR1 = new DataSetHMSTableAdapters.Vw_TwoHourlyRepositioning_RecordTableAdapter();
                ObjTHR1.Fill(ObjTHR);
                rep.Load(Server.MapPath("~//Report//Rpt_TwoHourlyRepositiory.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                  case "CaesareanSection":
                DataSetHMS.VW_CaesareanSection_ReportDataTable ObjCS = Objrds.VW_CaesareanSection_Report;
                DataSetHMSTableAdapters.VW_CaesareanSection_ReportTableAdapter ObjCS1 = new DataSetHMSTableAdapters.VW_CaesareanSection_ReportTableAdapter();
                ObjCS1.Fill(ObjCS);
                rep.Load(Server.MapPath("~//Report//Rpt_CaesareanSection_Report.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                  case "Laparoscopic_Cyste_Sectio":
                DataSetHMS.VW_Laparoscopic_Cyste_Section_ReportDataTable ObjLCS = Objrds.VW_Laparoscopic_Cyste_Section_Report;
                DataSetHMSTableAdapters.VW_Laparoscopic_Cyste_Section_ReportTableAdapter ObjLCS1 = new DataSetHMSTableAdapters.VW_Laparoscopic_Cyste_Section_ReportTableAdapter();
                ObjLCS1.Fill(ObjLCS);
                rep.Load(Server.MapPath("~//Report//Rpt_Laparoscopic_Cyste_Sectio_Report.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                  case "Diagnostic_Cyste_Section":
                DataSetHMS.VW_Diagnostic_Cyste_Section_ReportDataTable ObjDCS = Objrds.VW_Diagnostic_Cyste_Section_Report;
                DataSetHMSTableAdapters.VW_Diagnostic_Cyste_Section_ReportTableAdapter ObjDCS1 = new DataSetHMSTableAdapters.VW_Diagnostic_Cyste_Section_ReportTableAdapter();
                ObjDCS1.Fill(ObjDCS);
                rep.Load(Server.MapPath("~//Report//Rpt_Diagnostic_Cyste_Sectio_Report.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                  case "LaparoscopicEctopic":
                DataSetHMS.VW_LaparoscopicEctopic_Section_ReportDataTable ObjLES = Objrds.VW_LaparoscopicEctopic_Section_Report;
                DataSetHMSTableAdapters.VW_LaparoscopicEctopic_Section_ReportTableAdapter ObjLES1 = new DataSetHMSTableAdapters.VW_LaparoscopicEctopic_Section_ReportTableAdapter();
                ObjLES1.Fill(ObjLES);
                rep.Load(Server.MapPath("~//Report//Rpt_Laparoscopic_Cyste_Section_Report.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                  case "LaparoscopicHysterectomy":
                DataSetHMS.VW_LaparoscopicHysterectomy_Section_ReportDataTable ObjLHS = Objrds.VW_LaparoscopicHysterectomy_Section_Report;
                DataSetHMSTableAdapters.VW_LaparoscopicHysterectomy_Section_ReportTableAdapter ObjLHS1 = new DataSetHMSTableAdapters.VW_LaparoscopicHysterectomy_Section_ReportTableAdapter();
                ObjLHS1.Fill(ObjLHS);
                rep.Load(Server.MapPath("~//Report//Rpt_LaparoscopicHysterectomy_Section_Report.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                  case "LSCH_Section_Report":
                DataSetHMS.VW_LSCH_Section_ReportDataTable ObjLSCH = Objrds.VW_LSCH_Section_Report;
                DataSetHMSTableAdapters.VW_LSCH_Section_ReportTableAdapter ObjLSCH1 = new DataSetHMSTableAdapters.VW_LSCH_Section_ReportTableAdapter();
                ObjLSCH1.Fill(ObjLSCH);
                rep.Load(Server.MapPath("~//Report//Rpt_LSCH_Section_Report.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                  case "MYOMECTOMY_Section_Report":
                DataSetHMS.VW_MYOMECTOMY_Section_ReportDataTable ObjMSR = Objrds.VW_MYOMECTOMY_Section_Report;
                DataSetHMSTableAdapters.VW_MYOMECTOMY_Section_ReportTableAdapter ObjMSR1 = new DataSetHMSTableAdapters.VW_MYOMECTOMY_Section_ReportTableAdapter();
                ObjMSR1.Fill(ObjMSR);
                rep.Load(Server.MapPath("~//Report//Rpt_MYOMECTOMY_Section_Report.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                  case "ABDOMINAL _Section_Report":
                DataSetHMS.VW_ABDOMINALHYSTERECTOMY_Section_ReportDataTable ObjABS = Objrds.VW_ABDOMINALHYSTERECTOMY_Section_Report;
                DataSetHMSTableAdapters.VW_ABDOMINALHYSTERECTOMY_Section_ReportTableAdapter ObjABS1 = new DataSetHMSTableAdapters.VW_ABDOMINALHYSTERECTOMY_Section_ReportTableAdapter();
                ObjABS1.Fill(ObjABS);
                rep.Load(Server.MapPath("~//Report//Rpt_ABDOMINAL_Section_Report.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                  case "VaginalHystErect_Section_Report":
                DataSetHMS.VW_VAGINALHYSTERECTOMY_Section_ReportDataTable ObjVSR= Objrds.VW_VAGINALHYSTERECTOMY_Section_Report;
                DataSetHMSTableAdapters.VW_VAGINALHYSTERECTOMY_Section_ReportTableAdapter ObjVSR1 = new DataSetHMSTableAdapters.VW_VAGINALHYSTERECTOMY_Section_ReportTableAdapter();
                ObjVSR1.Fill(ObjVSR);
                rep.Load(Server.MapPath("~//Report//Rpt_VaginalHystErect_Section_Report.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                  case "UserWisLedger_Report":
                DataSetHMS.VW_GetAllLedgerDataTable ObjGAL = Objrds.VW_GetAllLedger;
                DataSetHMSTableAdapters.VW_GetAllLedgerTableAdapter ObjGAL1 = new DataSetHMSTableAdapters.VW_GetAllLedgerTableAdapter();
                ObjGAL1.Fill(ObjGAL);
                rep.Load(Server.MapPath("~//Report//Rpt_UserWisLedger_Report.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                  case "OPERATIVEHYSTEROSCOPY_Section_Report":
                DataSetHMS.VW_OPERATIVEHYSTEROSCOPY_Section_ReportDataTable ObjOPE = Objrds.VW_OPERATIVEHYSTEROSCOPY_Section_Report;
                DataSetHMSTableAdapters.VW_OPERATIVEHYSTEROSCOPY_Section_ReportTableAdapter ObjOPE1 = new DataSetHMSTableAdapters.VW_OPERATIVEHYSTEROSCOPY_Section_ReportTableAdapter();
                ObjOPE1.Fill(ObjOPE);
                rep.Load(Server.MapPath("~//Report//Rpt_OPERATIVEHYSTEROSCOPY_Section_Report.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                  case "VAGINAL_HYSTE_NONDESCENT_Report":
                DataSetHMS.VW_VAGINAL_HYSTE_NONDESCENT_Section_ReportDataTable ObjVHN = Objrds.VW_VAGINAL_HYSTE_NONDESCENT_Section_Report;
                DataSetHMSTableAdapters.VW_VAGINAL_HYSTE_NONDESCENT_Section_ReportTableAdapter ObjVHN1 = new DataSetHMSTableAdapters.VW_VAGINAL_HYSTE_NONDESCENT_Section_ReportTableAdapter();
                ObjVHN1.Fill(ObjVHN);
                rep.Load(Server.MapPath("~//Report//Rpt_VAGINAL_HYSTE_NONDESCENT_Report.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                  case "ENDOSCOPY_Section_Report":
                DataSetHMS.VW_ENDOSCOPY_Section_ReportDataTable ObjESR = Objrds.VW_ENDOSCOPY_Section_Report;
                DataSetHMSTableAdapters.VW_ENDOSCOPY_Section_ReportTableAdapter ObjESR1 = new DataSetHMSTableAdapters.VW_ENDOSCOPY_Section_ReportTableAdapter();
                ObjESR1.Fill(ObjESR);
                rep.Load(Server.MapPath("~//Report//Rpt_ENDOSCOPY_Section_Report.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                  case "MajorCase_Section_Report":
                DataSetHMS.VW_MajorCase_Section_ReportDataTable ObjMCS = Objrds.VW_MajorCase_Section_Report;
                DataSetHMSTableAdapters.VW_MajorCase_Section_ReportTableAdapter ObjMCS1 = new DataSetHMSTableAdapters.VW_MajorCase_Section_ReportTableAdapter();
                ObjMCS1.Fill(ObjMCS);
                rep.Load(Server.MapPath("~//Report//Rpt_MajorCase_Section_Report.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                  case "Dental_Clinic_History":
                DataSetHMS.Vw_Dental_Clinic_HistoryDataTable ObjDCH= Objrds.Vw_Dental_Clinic_History;
                DataSetHMSTableAdapters.Vw_Dental_Clinic_HistoryTableAdapter ObjDCH1 = new DataSetHMSTableAdapters.Vw_Dental_Clinic_HistoryTableAdapter();
                ObjDCH1.Fill(ObjDCH);
                rep.Load(Server.MapPath("~//Report//Rpt_Dental_Clinic_History_Report.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                  case "Dental_Diagnosis_Treatment":
                DataSetHMS.Vw_Dental_Diagnosis_TreatmentDataTable ObjDDT = Objrds.Vw_Dental_Diagnosis_Treatment;
                DataSetHMSTableAdapters.Vw_Dental_Diagnosis_TreatmentTableAdapter ObjDDT1 = new DataSetHMSTableAdapters.Vw_Dental_Diagnosis_TreatmentTableAdapter();
                ObjDDT1.Fill(ObjDDT);
                rep.Load(Server.MapPath("~//Report//Rpt_Dental_Diagnosis_Treatment_Report.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                  case "Dental_Treatment_Details":
                DataSetHMS.Vw_Dental_Treatment_DetailsDataTable ObjDTD = Objrds.Vw_Dental_Treatment_Details;
                DataSetHMSTableAdapters.Vw_Dental_Treatment_DetailsTableAdapter ObjDTD1 = new DataSetHMSTableAdapters.Vw_Dental_Treatment_DetailsTableAdapter();
                ObjDTD1.Fill(ObjDTD);
                rep.Load(Server.MapPath("~//Report//Rpt_Dental_Treatment_Details_Report.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                  case "InfiniChart_Report":
                DataSetHMS.Vw_Drematology_InfiniChartDataTable ObjDIC = Objrds.Vw_Drematology_InfiniChart;
                DataSetHMSTableAdapters.Vw_Drematology_InfiniChartTableAdapter ObjDIC1 = new DataSetHMSTableAdapters.Vw_Drematology_InfiniChartTableAdapter();
                ObjDIC1.Fill(ObjDIC);
                rep.Load(Server.MapPath("~//Report//Rpt_InfiniChart_Report.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                  case "HairLaser_Report":
                DataSetHMS.Vw_Hair_Laser_SectionDataTable ObjHLS = Objrds.Vw_Hair_Laser_Section;
                DataSetHMSTableAdapters.Vw_Hair_Laser_SectionTableAdapter ObjHLS1 = new DataSetHMSTableAdapters.Vw_Hair_Laser_SectionTableAdapter();
                ObjHLS1.Fill(ObjHLS);
                rep.Load(Server.MapPath("~//Report//Rpt_HairLaser_Report.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                  case "DermatologyOutPatients_Report":
                DataSetHMS.Vw_DermatologyOutPatientDataTable ObjDop = Objrds.Vw_DermatologyOutPatient;
                DataSetHMSTableAdapters.Vw_DermatologyOutPatientTableAdapter ObjDop1 = new DataSetHMSTableAdapters.Vw_DermatologyOutPatientTableAdapter();
                ObjDop1.Fill(ObjDop);
                rep.Load(Server.MapPath("~//Report//Rpt_DermatologyOutPatients_Report.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                  case "Orthodontic_Dental_Clinic_History":
                DataSetHMS.Vw_Orthodontic_Dental_Clinic_HistoryDataTable ObjODC = Objrds.Vw_Orthodontic_Dental_Clinic_History;
                DataSetHMSTableAdapters.Vw_Orthodontic_Dental_Clinic_HistoryTableAdapter ObjODC1 = new DataSetHMSTableAdapters.Vw_Orthodontic_Dental_Clinic_HistoryTableAdapter();
                ObjODC1.Fill(ObjODC);
                rep.Load(Server.MapPath("~//Report//Rpt_Orthodontic_Dental_Clinic_History_Report.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                  case "Orthodontic_DiagnosisTreatment":
                DataSetHMS.Vw_Orthodontic_Dental_Diagnosis_TreatmentDataTable ObjODCT = Objrds.Vw_Orthodontic_Dental_Diagnosis_Treatment;
                DataSetHMSTableAdapters.Vw_Orthodontic_Dental_Diagnosis_TreatmentTableAdapter ObjODCT1 = new DataSetHMSTableAdapters.Vw_Orthodontic_Dental_Diagnosis_TreatmentTableAdapter();
                ObjODCT1.Fill(ObjODCT);
                rep.Load(Server.MapPath("~//Report//Rpt_Orthodontic_DiagnosisTreatment_Report.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                  case "Orthodontic_Treatment":
                DataSetHMS.Vw_Orthodontic_Dental_OrthoTreatment_DetailsDataTable ObjODOT = Objrds.Vw_Orthodontic_Dental_OrthoTreatment_Details;
                DataSetHMSTableAdapters.Vw_Orthodontic_Dental_OrthoTreatment_DetailsTableAdapter ObjODOT1 = new DataSetHMSTableAdapters.Vw_Orthodontic_Dental_OrthoTreatment_DetailsTableAdapter();
                ObjODOT1.Fill(ObjODOT);
                rep.Load(Server.MapPath("~//Report//Rpt_Orthodontic_Treatment_Report.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                  case "Orthodontic_Investigation":
                DataSetHMS.Vw_Orthodontic_Dental_InvestigationDetailsDataTable ObjODI = Objrds.Vw_Orthodontic_Dental_InvestigationDetails;
                DataSetHMSTableAdapters.Vw_Orthodontic_Dental_InvestigationDetailsTableAdapter ObjODI1 = new DataSetHMSTableAdapters.Vw_Orthodontic_Dental_InvestigationDetailsTableAdapter();
                ObjODI1.Fill(ObjODI);
                rep.Load(Server.MapPath("~//Report//Rpt_Orthodontic_Investigation_Report.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                  case "ANTENATALCARD_DrugSchedule":
                DataSetHMS.VW_Gynalogy_ANTENATALCARD_DrugScheduleDataTable ObjADS = Objrds.VW_Gynalogy_ANTENATALCARD_DrugSchedule;
                DataSetHMSTableAdapters.VW_Gynalogy_ANTENATALCARD_DrugScheduleTableAdapter ObjADS1 = new DataSetHMSTableAdapters.VW_Gynalogy_ANTENATALCARD_DrugScheduleTableAdapter();
                ObjADS1.Fill(ObjADS);
                rep.Load(Server.MapPath("~//Report//Rpt_ANTENATALCARD_DrugSchedule.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                  case "ANTENATALCARD":
                DataSetHMS.VW_Gynalogy_ANTENATALCARDDataTable ObjAD = Objrds.VW_Gynalogy_ANTENATALCARD;
                DataSetHMSTableAdapters.VW_Gynalogy_ANTENATALCARDTableAdapter ObjAD1 = new DataSetHMSTableAdapters.VW_Gynalogy_ANTENATALCARDTableAdapter();
                ObjAD1.Fill(ObjAD);
                rep.Load(Server.MapPath("~//Report//Rpt_ANTENATALCARD_Details.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                  case "Opthalmology_Clinic":
                DataSetHMS.VW_Opthalmology_ClinicDataTable ObjOC = Objrds.VW_Opthalmology_Clinic;
                DataSetHMSTableAdapters.VW_Opthalmology_ClinicTableAdapter ObjOC1 = new DataSetHMSTableAdapters.VW_Opthalmology_ClinicTableAdapter();
                ObjOC1.Fill(ObjOC);
                rep.Load(Server.MapPath("~//Report//Rpt_Opthalmology_Clinic.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                  case "All_OPDServiceReport":
                DataSetHMS.VWS_GeneralVitalDataTable ObjGV = Objrds.VWS_GeneralVital;
                DataSetHMSTableAdapters.VWS_GeneralVitalTableAdapter ObjGV1 = new DataSetHMSTableAdapters.VWS_GeneralVitalTableAdapter();
                ObjGV1.Fill(ObjGV);
                DataSetHMS.VWS_GetTreatmentsDataTable ObjGT = Objrds.VWS_GetTreatments;
                DataSetHMSTableAdapters.VWS_GetTreatmentsTableAdapter ObjGT1 = new DataSetHMSTableAdapters.VWS_GetTreatmentsTableAdapter();
                ObjGT1.Fill(ObjGT);
                DataSetHMS.VWS_Get_AllInvestigationDataTable ObjGI = Objrds.VWS_Get_AllInvestigation;
                DataSetHMSTableAdapters.VWS_Get_AllInvestigationTableAdapter ObjGI1 = new DataSetHMSTableAdapters.VWS_Get_AllInvestigationTableAdapter();
                ObjGI1.Fill(ObjGI);
                rep.Load(Server.MapPath("~//Report//Rpt_All_OPDServiceReport.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                  case "Refractive_WorkUp_Report":
                DataSetHMS.Vw_Optho_RefractiveWorkup_DetailsDataTable ObjORW = Objrds.Vw_Optho_RefractiveWorkup_Details;
                DataSetHMSTableAdapters.Vw_Optho_RefractiveWorkup_DetailsTableAdapter ObjORW1 = new DataSetHMSTableAdapters.Vw_Optho_RefractiveWorkup_DetailsTableAdapter();
                ObjORW1.Fill(ObjORW);
                rep.Load(Server.MapPath("~//Report//Rpt_Refractive_WorkUp_Report.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                  case "Refractive_Prescription_Report":
                DataSetHMS.Vw_Optho_RefractiveWorkup_DetailsDataTable ObjORW2 = Objrds.Vw_Optho_RefractiveWorkup_Details;
                DataSetHMSTableAdapters.Vw_Optho_RefractiveWorkup_DetailsTableAdapter ObjORW12 = new DataSetHMSTableAdapters.Vw_Optho_RefractiveWorkup_DetailsTableAdapter();
                ObjORW12.Fill(ObjORW2);
                rep.Load(Server.MapPath("~//Report//Rpt_Refractive_Prescription_Report.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;

                  case "Quotation_Report":
                DataSetHMS.VW_Quotation_ReportDataTable ObjQrd = Objrds.VW_Quotation_Report;
                DataSetHMSTableAdapters.VW_Quotation_ReportTableAdapter ObjQrd1 = new DataSetHMSTableAdapters.VW_Quotation_ReportTableAdapter();
                ObjQrd1.Fill(ObjQrd);
                rep.Load(Server.MapPath("~//Report//Rpt_Quotation_Report.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                  case "MRCPatientLedger":
                DataSetHMS.VW_MRCPatientLedgerDataTable ObjMP = Objrds.VW_MRCPatientLedger;
                DataSetHMSTableAdapters.VW_MRCPatientLedgerTableAdapter ObjMP1 = new DataSetHMSTableAdapters.VW_MRCPatientLedgerTableAdapter();
                ObjMP1.Fill(ObjMP);
                rep.Load(Server.MapPath("~//Report//Rpt_MRCPatientLedger.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                  case "DeliveryPage":
                DataSetHMS.VW_DeliveryPageDataTable ObjDP = Objrds.VW_DeliveryPage;
                DataSetHMSTableAdapters.VW_DeliveryPageTableAdapter ObjDP1 = new DataSetHMSTableAdapters.VW_DeliveryPageTableAdapter();
                ObjDP1.Fill(ObjDP);
                rep.Load(Server.MapPath("~//Report//Rpt_DeliveryPage.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                  case "NewBornRecord":
                DataSetHMS.VW_NewBornRecordDataTable ObjNBR = Objrds.VW_NewBornRecord;
                DataSetHMSTableAdapters.VW_NewBornRecordTableAdapter ObjNBR1 = new DataSetHMSTableAdapters.VW_NewBornRecordTableAdapter();
                ObjNBR1.Fill(ObjNBR);
                rep.Load(Server.MapPath("~//Report//Rpt_NewBornRecord.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                  case "Maternal_PatientInformation":
                DataSetHMS.VW_Maternal_PatientInformationDataTable ObjMPI = Objrds.VW_Maternal_PatientInformation;
                DataSetHMSTableAdapters.VW_Maternal_PatientInformationTableAdapter ObjMPI1 = new DataSetHMSTableAdapters.VW_Maternal_PatientInformationTableAdapter();
                ObjMPI1.Fill(ObjMPI);
                rep.Load(Server.MapPath("~//Report//Rpt_Maternal_PatientInformation.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                  case "NewBornCard":
                DataSetHMS.VW_NewBorn_CardDataTable ObjNBC = Objrds.VW_NewBorn_Card;
                DataSetHMSTableAdapters.VW_NewBorn_CardTableAdapter ObjNBC1 = new DataSetHMSTableAdapters.VW_NewBorn_CardTableAdapter();
                ObjNBC1.Fill(ObjNBC);
                rep.Load(Server.MapPath("~//Report//Rpt_NewBornCard.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                  case "OTBooking_Report":
                DataSetHMS.VW_SP_GetOTBookingFormReportDataTable ObjOTR = Objrds.VW_SP_GetOTBookingFormReport;
                DataSetHMSTableAdapters.VW_SP_GetOTBookingFormReportTableAdapter ObjOTR1 = new DataSetHMSTableAdapters.VW_SP_GetOTBookingFormReportTableAdapter();
                ObjOTR1.Fill(ObjOTR);
                rep.Load(Server.MapPath("~//Report//Rpt_OTBooking_Report.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                  case "AllIpdReport":
                DataSetHMS.Vw_IPDPatientFrontSheetDataTable ObjAIR = Objrds.Vw_IPDPatientFrontSheet;
                DataSetHMSTableAdapters.Vw_IPDPatientFrontSheetTableAdapter ObjAIR1 = new DataSetHMSTableAdapters.Vw_IPDPatientFrontSheetTableAdapter();
                ObjAIR1.Fill(ObjAIR);

               

                DataSetHMS.Vw_DailyNurseNoteDataTable ObjDNN = Objrds.Vw_DailyNurseNote;
                DataSetHMSTableAdapters.Vw_DailyNurseNoteTableAdapter ObjDNN1 = new DataSetHMSTableAdapters.Vw_DailyNurseNoteTableAdapter();
                ObjDNN1.Fill(ObjDNN);
                rep.Load(Server.MapPath("~//Report//Rpt_AllIpdReportFrontSheet.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                 case "IPDVitalSignReport":
                DataSetHMS.Vw_IPDVitalSignFormDataTable ObjIVS = Objrds.Vw_IPDVitalSignForm;
                DataSetHMSTableAdapters.Vw_IPDVitalSignFormTableAdapter ObjIVS1 = new DataSetHMSTableAdapters.Vw_IPDVitalSignFormTableAdapter();
                ObjIVS1.Fill(ObjIVS);
                rep.Load(Server.MapPath("~//Report//Rpt_IPDVitalSignForm.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                 case "IPDDrDailyNote":
                 DataSetHMS.Vw_IPDDrDailyNoteDataTable ObjDRNN = Objrds.Vw_IPDDrDailyNote;
                DataSetHMSTableAdapters.Vw_IPDDrDailyNoteTableAdapter ObjDRNN1 = new DataSetHMSTableAdapters.Vw_IPDDrDailyNoteTableAdapter();
                ObjDRNN1.Fill(ObjDRNN);
                rep.Load(Server.MapPath("~//Report//Rpt_IPDDrDailyNote.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                 case "IPDTreatmentList":
                DataSetHMS.Vw_IPDTreatmentListDataTable ObjIT = Objrds.Vw_IPDTreatmentList;
                DataSetHMSTableAdapters.Vw_IPDTreatmentListTableAdapter ObjIT1 = new DataSetHMSTableAdapters.Vw_IPDTreatmentListTableAdapter();
                ObjIT1.Fill(ObjIT);
                rep.Load(Server.MapPath("~//Report//Rpt_IPDTreatmentList.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                 case "LABServiceIncomeReport":
                DataSetHMS.VW_LabWiseRevuenewDataTable ObjLWR = Objrds.VW_LabWiseRevuenew;
                DataSetHMSTableAdapters.VW_LabWiseRevuenewTableAdapter ObjLWR1 = new DataSetHMSTableAdapters.VW_LabWiseRevuenewTableAdapter();
                ObjLWR1.Fill(ObjLWR);

                DataSetHMS.VW_LabWiseRevuenewwithserviceDataTable ObjLWR2 = Objrds.VW_LabWiseRevuenewwithservice;
                DataSetHMSTableAdapters.VW_LabWiseRevuenewwithserviceTableAdapter ObjLWR12 = new DataSetHMSTableAdapters.VW_LabWiseRevuenewwithserviceTableAdapter();
                ObjLWR12.Fill(ObjLWR2);

                rep.Load(Server.MapPath("~//Report//Rpt_LABServiceIncomeReport.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                 case "Rpt_PatientwiseBillGroupPharmaIPD":
                DataSetHMS.VW_FillGridGroupWiseIncome_Pharmacy_ReportDataTable ObjPBGP = Objrds.VW_FillGridGroupWiseIncome_Pharmacy_Report;
                DataSetHMSTableAdapters.VW_FillGridGroupWiseIncome_Pharmacy_ReportTableAdapter ObjPBGP1 = new DataSetHMSTableAdapters.VW_FillGridGroupWiseIncome_Pharmacy_ReportTableAdapter();
                ObjPBGP1.Fill(ObjPBGP);
                rep.Load(Server.MapPath("~//Report//Rpt_PatientwiseBillGroupPharmaIPD.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;

                 case "Rpt_PatientwiseBillGroupPharmaOPD":
                DataSetHMS.Vw_DailyCashReportDataTable ObjDSR = Objrds.Vw_DailyCashReport;
                DataSetHMSTableAdapters.Vw_DailyCashReportTableAdapter ObjDSR1 = new DataSetHMSTableAdapters.Vw_DailyCashReportTableAdapter();
                ObjDSR1.Fill(ObjDSR);
                rep.Load(Server.MapPath("~//Report//Rpt_PatientwiseBillGroupPharmaOPD.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                 case "BillGroupSalesSummary_Pharmacy":
                DataSetHMS.VW_FillGridGroupWiseIncome_PharmacyDataTable ObjDSRP = Objrds.VW_FillGridGroupWiseIncome_Pharmacy;
                DataSetHMSTableAdapters.VW_FillGridGroupWiseIncome_PharmacyTableAdapter ObjDSRP1 = new DataSetHMSTableAdapters.VW_FillGridGroupWiseIncome_PharmacyTableAdapter();
                ObjDSRP1.Fill(ObjDSRP);
                rep.Load(Server.MapPath("~//Report//RPT_BillGroupSalesSummary_Pharmacy.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;

                 case "LabServiceReport":
                DataSetHMS.VW_FillGridGroupWiseIncome_LABDataTable ObjFGL = Objrds.VW_FillGridGroupWiseIncome_LAB;
                DataSetHMSTableAdapters.VW_FillGridGroupWiseIncome_LABTableAdapter ObjFGL1 = new DataSetHMSTableAdapters.VW_FillGridGroupWiseIncome_LABTableAdapter();
                ObjFGL1.Fill(ObjFGL);
                rep.Load(Server.MapPath("~//Report//Rpt_LabServiceReport.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                 case "IPDDischargeSlip":
                DataSetHMS.VW_GetDischargeSlipDataTable ObjGDS = Objrds.VW_GetDischargeSlip;
                DataSetHMSTableAdapters.VW_GetDischargeSlipTableAdapter ObjGDS1 = new DataSetHMSTableAdapters.VW_GetDischargeSlipTableAdapter();
                ObjGDS1.Fill(ObjGDS);
                rep.Load(Server.MapPath("~//Report//Rpt_IPDDischargeSlip.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                 case "SurgicalProductivityData":
                DataSetHMS.VW_SurgicalProductivityDataDataTable ObjSPD = Objrds.VW_SurgicalProductivityData;
                DataSetHMSTableAdapters.VW_SurgicalProductivityDataTableAdapter ObjSPD1 = new DataSetHMSTableAdapters.VW_SurgicalProductivityDataTableAdapter();
                ObjSPD1.Fill(ObjSPD);
                rep.Load(Server.MapPath("~//Report//Rpt_SurgicalProductivityData.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                 case "DoctorProductivityData":
                DataSetHMS.VW_DoctorProductivityDataDataTable ObjDPD = Objrds.VW_DoctorProductivityData;
                DataSetHMSTableAdapters.VW_DoctorProductivityDataTableAdapter ObjDPD1 = new DataSetHMSTableAdapters.VW_DoctorProductivityDataTableAdapter();
                ObjDPD1.Fill(ObjDPD);
                rep.Load(Server.MapPath("~//Report//Rpt_DoctorProductivityData.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                 case "SpecialityProductivityData":
                DataSetHMS.VW_SpecialityProductivityDataDataTable ObjSPPD = Objrds.VW_SpecialityProductivityData;
                DataSetHMSTableAdapters.VW_SpecialityProductivityDataTableAdapter ObjSPPD1 = new DataSetHMSTableAdapters.VW_SpecialityProductivityDataTableAdapter();
                ObjSPPD1.Fill(ObjSPPD);
                rep.Load(Server.MapPath("~//Report//Rpt_SpecialityProductivityData.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                 case "SpecialityProductivityChart":
                DataSetHMS.VW_SpecialityProductivityDataDataTable ObjSPPDC = Objrds.VW_SpecialityProductivityData;
                DataSetHMSTableAdapters.VW_SpecialityProductivityDataTableAdapter ObjSPPDC1 = new DataSetHMSTableAdapters.VW_SpecialityProductivityDataTableAdapter();
                ObjSPPDC1.Fill(ObjSPPDC);
                rep.Load(Server.MapPath("~//Report//Rpt_SpecialityProductivityData_Chart.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                case "Month_SurgicalProductivityData":
                DataSetHMS.VW_SurgicalProductivityDataDataTable ObjMSPD = Objrds.VW_SurgicalProductivityData;
                DataSetHMSTableAdapters.VW_SurgicalProductivityDataTableAdapter ObjMSPD1 = new DataSetHMSTableAdapters.VW_SurgicalProductivityDataTableAdapter();
                ObjMSPD1.Fill(ObjMSPD);
                rep.Load(Server.MapPath("~//Report//Rpt_Monthly_SurgicalProductivityData.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                case "Month_DRSurgicalProductivityData":
                DataSetHMS.VW_SurgicalProductivityDataDataTable ObjMSPDD = Objrds.VW_SurgicalProductivityData;
                DataSetHMSTableAdapters.VW_SurgicalProductivityDataTableAdapter ObjMSPDD1 = new DataSetHMSTableAdapters.VW_SurgicalProductivityDataTableAdapter();
                ObjMSPDD1.Fill(ObjMSPDD);
                rep.Load(Server.MapPath("~//Report//Rpt_Monthly_DrSurgicalProductivityData.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;

                case "Rpt_DrOTRegisterReport":
                DataSetHMS.Vw_DrOT_RegisterDataTable objVDT = Objrds.Vw_DrOT_Register;
                DataSetHMSTableAdapters.Vw_DrOT_RegisterTableAdapter objVDT1 = new DataSetHMSTableAdapters.Vw_DrOT_RegisterTableAdapter();
                objVDT1.Fill(objVDT);
                rep.Load(Server.MapPath("~//Report//Rpt_DrOTRegisterReport.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                case "PatientDischargeList":
                DataSetHMS.VW_PatientDischargeListDataTable objPD = Objrds.VW_PatientDischargeList;
                DataSetHMSTableAdapters.VW_PatientDischargeListTableAdapter objPD1 = new DataSetHMSTableAdapters.VW_PatientDischargeListTableAdapter();
                objPD1.Fill(objPD);
                rep.Load(Server.MapPath("~//Report//Rpt_PatientDischargeList.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                case "OPD_Insurance_Details":
                DataSetHMS.VW_OPDInsurancePatientsDetailsDataTable objOIP= Objrds.VW_OPDInsurancePatientsDetails;
                DataSetHMSTableAdapters.VW_OPDInsurancePatientsDetailsTableAdapter objOIP1 = new DataSetHMSTableAdapters.VW_OPDInsurancePatientsDetailsTableAdapter();
                objOIP1.Fill(objOIP);
                rep.Load(Server.MapPath("~//Report//Rpt_OPD_Insurance_Details.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                case "SuspendedReport":
                DataSetHMS.VW_SuspendandResumeListDataTable objSRL = Objrds.VW_SuspendandResumeList;
                DataSetHMSTableAdapters.VW_SuspendandResumeListTableAdapter objSRL1 = new DataSetHMSTableAdapters.VW_SuspendandResumeListTableAdapter();
                objSRL1.Fill(objSRL);
                rep.Load(Server.MapPath("~//Report//Rpt_SuspendedReport.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                case "Refertocons":
                DataSetHMS.VW_ReferandReferingReportDataTable objRRC = Objrds.VW_ReferandReferingReport;
                DataSetHMSTableAdapters.VW_ReferandReferingReportTableAdapter objRRC1 = new DataSetHMSTableAdapters.VW_ReferandReferingReportTableAdapter();
                objRRC1.Fill(objRRC);
                rep.Load(Server.MapPath("~//Report//Rpt_ConsultantReferReport.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                case "Refertorefering":
                DataSetHMS.VW_ReferandReferingReportDataTable objRRR = Objrds.VW_ReferandReferingReport;
                DataSetHMSTableAdapters.VW_ReferandReferingReportTableAdapter objRRR1 = new DataSetHMSTableAdapters.VW_ReferandReferingReportTableAdapter();
                objRRR1.Fill(objRRR);
                rep.Load(Server.MapPath("~//Report//Rpt_ReferConsultantReport.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                case "Rpt_dischargerecommendation":
                DataSetHMS.Vw_IpddischargerecommendationDataTable ObjIDR = Objrds.Vw_Ipddischargerecommendation;
                DataSetHMSTableAdapters.Vw_IpddischargerecommendationTableAdapter ObjIDR1 = new DataSetHMSTableAdapters.Vw_IpddischargerecommendationTableAdapter();
                ObjIDR1.Fill(ObjIDR);
                rep.Load(Server.MapPath("~//Report//Rpt_dischargerecommendation_Report.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                case "Rpt_FrontSheetSummary":
                DataSetHMS.VW_FrontsheetSummaryDataTable ObjFSR = Objrds.VW_FrontsheetSummary;
                DataSetHMSTableAdapters.VW_FrontsheetSummaryTableAdapter ObjFSR1 = new DataSetHMSTableAdapters.VW_FrontsheetSummaryTableAdapter();
                ObjFSR1.Fill(ObjFSR);
                rep.Load(Server.MapPath("~//Report//Rpt_FrontSheetSummary_Report.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                case "Rpt_GetAllServiceIncome":
                DataSetHMS.VW_GetAllServiceIncomeDataTable ObjAS = Objrds.VW_GetAllServiceIncome;
                DataSetHMSTableAdapters.VW_GetAllServiceIncomeTableAdapter ObjAS1 = new DataSetHMSTableAdapters.VW_GetAllServiceIncomeTableAdapter();
                ObjAS1.Fill(ObjAS);
                rep.Load(Server.MapPath("~//Report//Rpt_AllServiceIncome.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                case "AdmissionDischargeData":
                DataSetHMS.VW_AdmitDischargeProdictivityDataDataTable ObjADP = Objrds.VW_AdmitDischargeProdictivityData;
                DataSetHMSTableAdapters.VW_AdmitDischargeProdictivityDataTableAdapter ObjADP1 = new DataSetHMSTableAdapters.VW_AdmitDischargeProdictivityDataTableAdapter();
                ObjADP1.Fill(ObjADP);
                rep.Load(Server.MapPath("~//Report//Rpt_AdmitDischargeProductivityData.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                case "Rpt_DialysisReport":
                DataSetHMS.VW_DialysisReportDataTable ObjDR = Objrds.VW_DialysisReport;
                DataSetHMSTableAdapters.VW_DialysisReportTableAdapter ObjDR1 = new DataSetHMSTableAdapters.VW_DialysisReportTableAdapter();
                ObjDR1.Fill(ObjDR);
                rep.Load(Server.MapPath("~//Report//Rpt_DialysisReport.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
                case "Rpt_GetAllServiceIncome_Year":
                DataSetHMS.VW_GetAllServiceIncome_YearDataTable ObjASY = Objrds.VW_GetAllServiceIncome_Year;
                DataSetHMSTableAdapters.VW_GetAllServiceIncome_YearTableAdapter ObjAS1Y = new DataSetHMSTableAdapters.VW_GetAllServiceIncome_YearTableAdapter();
                ObjAS1Y.Fill(ObjASY);
                rep.Load(Server.MapPath("~//Report//Rpt_AllServiceIncome_Year.rpt"));
                rep.SetDataSource((System.Data.DataSet)Objrds);
                break;
        }
        string rptname = Session["rptname"].ToString();
        string path = Server.MapPath("~/Print_Report");
        string sql = Session["rptsql"].ToString();

        string rptuser = Convert.ToString(Session["rptusername"]);
        string rptmodule = Convert.ToString(Session["rptModule"]);
        string rptdate = Convert.ToString(Session["rptDate"]);


        if (Session["RPTFORMAT"] == "Word")
        {
           // da.ExportingAndPrintingCrystalRpt("pdf1", rptname, path, sql, rep, rptuser, rptmodule, rptdate);
            da.ExportingAndPrintingCrystalRpt("Word", rptname, path, sql, rep);
        }
        else if (Session["RPTFORMAT"] == "EXCEL")
        {
            // da.ExportingAndPrintingCrystalRpt("pdf1", rptname, path, sql, rep, rptuser, rptmodule, rptdate);
            da.ExportingAndPrintingCrystalRpt("Excel", rptname, path, sql, rep);
        }
        else
        {
           // da.ExportingAndPrintingCrystalRpt("pdf", rptname, path, sql, rep, rptuser, rptmodule, rptdate);
            if (Convert.ToString(Session["Parameter"]) == "NO")
            {
                da.ExportingAndPrintingCrystalRpt("pdf", rptname, path, sql, rep);
            }
            else
            {
                da.ExportingAndPrintingCrystalRpt_Para("pdf", rptname, path, sql, rep, rptdate, rptuser);
            }
        }

        rep.Close();
        GC.SuppressFinalize(rep);
        rep.Dispose();
        GC.Collect();
        // Session.Abandon();
        // Session.Clear();
        // Session.RemoveAll();        
        Session["Parameter"] = "NO";
        if (Session["RPTFORMAT"] == "EXCEL")
        {
            Session["RPTFORMAT"] = "pdf";
            Response.Redirect("~/Print_Report\\exportedinxls.xls");
        }
        else if (Session["RPTFORMAT"] == "Word")
        {
            Session["RPTFORMAT"] = "pdf";
            Response.Redirect("~/Print_Report\\WordFile.doc");
        }
        else
        {
            Response.Redirect("~/Print_Report\\Exported.pdf");
        }
    }
}