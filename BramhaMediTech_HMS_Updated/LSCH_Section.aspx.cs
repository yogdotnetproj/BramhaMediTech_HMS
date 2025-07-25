using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Services;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using CrystalDecisions.CrystalReports.Engine;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.Collections;
using System.IO;
using System.Drawing;
using System.Media;
public partial class LSCH_Section :BasePage
{
    OT_Clinical_Template_C ObjOCT = new OT_Clinical_Template_C();
    BELIntakeOutputChart objBELIO = new BELIntakeOutputChart();
    public enum MessageType { Success, Error, Info, Warning };
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        }

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ObjOCT.Patregid = Convert.ToInt32(Session["OTRegNo"]);
        ObjOCT.OPDNO = Convert.ToInt32(Session["OTOpdNo"]); ;
        ObjOCT.IPDNO = Convert.ToInt32(Session["OTIpdNo"]);
        if (txtdateofoperation.Text != "")
        {
            ObjOCT.OperationDate = Convert.ToDateTime(txtdateofoperation.Text);
        }
        if (txtNoteDate.Text != "")
        {
            ObjOCT.EntryDate = Convert.ToDateTime(txtNoteDate.Text);
        }

        ObjOCT.Schedule = txtschedule.Text;
        ObjOCT.OperativeProcedure = txtoperativeProcedure.Text;

        ObjOCT.PreOperativeDiagnosis = txtpreOperativeDiagnosis.Text;
        ObjOCT.DurationofSurgery = txtdurationofsurgery.Text;
        ObjOCT.PostOperativeAnaesthetist = txtpostoperativeAnaesthetist.Text;
        ObjOCT.SwabCount = txtswabcount.Text;

        ObjOCT.Inflate = txtInflate.Text;
        ObjOCT.ScrubNurse = txtScrubNurse.Text;
        ObjOCT.OperationFindings = txtoperationFinding.Text;
        ObjOCT.Drains = ddlDrains.SelectedValue;

        ObjOCT.Anaesthetist = txtAnaesthetist.Text;
        ObjOCT.PostOperativeDiagnosis = txtpostoperativediagnosis.Text;
        ObjOCT.TourniquetTime = txtTourniquetTime.Text;
        ObjOCT.Surgeon = txtSurgeon.Text;

        ObjOCT.SpecimenForwarded = txtmaterialforwarded.Text;
        ObjOCT.Deflate = txtDeflate.Text;
        ObjOCT.BloodLoss = txtbloodloss.Text;
        ////........................

        if (chkFetalDistress.Checked == true)
        {
            ObjOCT.Is_Fetaldistress = true;
        }
        else
        {
            ObjOCT.Is_Fetaldistress = false;
        }
        if (chkCPD.Checked == true)
        {
            ObjOCT.Is_CPDinLabour = true;
        }
        else
        {
            ObjOCT.Is_CPDinLabour = false;
        }
        if (chkMaternalChoice.Checked == true)
        {
            ObjOCT.Is_MaternalChoice = true;
        }
        else
        {
            ObjOCT.Is_MaternalChoice = false;
        }
        if (chkMultiplePregnancy.Checked == true)
        {
            ObjOCT.Is_MultiplePregnancy = true;
        }
        else
        {
            ObjOCT.Is_MultiplePregnancy = false;
        }
        if (chkTwoPrevLSCS.Checked == true)
        {
            ObjOCT.Is_TwoPreviousLSCS = true;
        }
        else
        {
            ObjOCT.Is_TwoPreviousLSCS = false;
        }
        if (chknonprogresslabour.Checked == true)
        {
            ObjOCT.Is_NonProgressoflabour = true;
        }
        else
        {
            ObjOCT.Is_NonProgressoflabour = false;
        }
        if (chkPRevLSCSComplication.Checked == true)
        {
            ObjOCT.Is_PreLSCSwithcomplication = true;
        }
        else
        {
            ObjOCT.Is_PreLSCSwithcomplication = false;
        }

        ObjOCT.LSCSPresentation1 = ddlPResentation1.SelectedValue;
        ObjOCT.LSCSSex1 = ddlSex1.SelectedValue;
        ObjOCT.LSCSApgar1 = txtapgar1.Text;

        ObjOCT.LSCSPresentation2 = ddlPresentation2.SelectedValue;
        ObjOCT.LSCSSex2 = ddlsex2.SelectedValue;
        ObjOCT.LSCSApgar2 = txtapgar2.Text;
        ObjOCT.LSCSPresentation3 = ddlpresentation3.SelectedValue;
        ObjOCT.LSCSSex3 = ddlsex3.SelectedValue;
        ObjOCT.LSCSApgar3 = txtapgar3.Text;

        ObjOCT.NoofFetuses = txtnooffetuses.Text;
        ObjOCT.PLACENTA = txtPLACENTA.Text;
        ObjOCT.Intact = ddlIntact.SelectedValue;
        ObjOCT.BLADDER = ddlBLADDERIntact.SelectedValue;
        ObjOCT.ADHESIONS = ddlADHESIONS.SelectedValue;
       
      
        ObjOCT.Notes = txtPRevLSCSComplication.Text;

        //----
        //ObjOCT.Notes = txtcomments.Text;

        ObjOCT.P_CreatedBy = Convert.ToString(Session["username"]); ;
        ObjOCT.Branchid = Convert.ToString(Session["Branchid"]); ;
        ObjOCT.Insert_LSCH_Section();
        ShowMessage("Record save successfully", MessageType.Success);

        txtAnaesthetist.Text = "";
        txtapgar1.Text = "";
        txtapgar2.Text = "";
        txtapgar3.Text = "";
        txtbloodloss.Text = "";
        txtdateofoperation.Text = "";
        txtDeflate.Text = "";
        txtdurationofsurgery.Text = "";
        txtInflate.Text = "";
        txtmaterialforwarded.Text = "";
        txtnooffetuses.Text = "";
        txtNoteDate.Text = "";
        txtoperationFinding.Text = "";
        txtoperativeProcedure.Text = "";
        txtPLACENTA.Text = "";
        txtpostoperativeAnaesthetist.Text = "";
        txtpostoperativediagnosis.Text = "";
        txtpreOperativeDiagnosis.Text = "";
        txtPRevLSCSComplication.Text = "";
        txtschedule.Text = "";
        txtScrubNurse.Text = "";
        txtSurgeon.Text = "";
        txtswabcount.Text = "";
        txtTourniquetTime.Text = "";
        

    }
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        string sql = "";
        if (Convert.ToString(Session["OTOpdNo"]) != "")
        {
            objBELIO.OpdNo = Convert.ToInt32(Session["OTOpdNo"]);
        }
        else
        {
            objBELIO.OpdNo = 0;
        }
        if (Convert.ToString(Session["OTIpdNo"]) != "")
        {
            objBELIO.IpdNo = Convert.ToInt32(Session["OTIpdNo"]);
        }
        else
        {
            objBELIO.IpdNo = 0;
        }
        objBELIO.Patregid = Convert.ToInt32(Session["OTRegNo"]);
        // objDALIO.Alter_TwoWayRepositoryChart(objBELIO);
        ObjOCT.Alter_LSCH_Section_Report(Convert.ToInt32(Session["OTRegNo"]), Convert.ToInt32(Session["OTOpdNo"]), Convert.ToInt32(Session["OTIpdNo"]));
        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Report/Rpt_LSCH_Section_Report.rpt");
        Session["reportname"] = "LSCH_Section_Report";
        Session["RPTFORMAT"] = "pdf";

        //ReportParameterClass.SelectionFormula = sql;
        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);
    }
}