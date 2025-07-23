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
public partial class Diagnostic_Cyste_Section : System.Web.UI.Page
{
    public enum MessageType { Success, Error, Info, Warning };
    OT_Clinical_Template_C ObjOCT = new OT_Clinical_Template_C();
    BELIntakeOutputChart objBELIO = new BELIntakeOutputChart();
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
        ObjOCT.PostOperativeAnaesthetist = txtpostoperativeAnaesthetist.Text;
        ObjOCT.TourniquetTime = txtTourniquetTime.Text;
        ObjOCT.Surgeon = txtSurgeon.Text;

        ObjOCT.SpecimenForwarded = txtmaterialforwarded.Text;
        ObjOCT.Deflate = txtDeflate.Text;
        ObjOCT.BloodLoss = txtbloodloss.Text;

        if (ChkHysteroscopy.Checked == true)
        {
            ObjOCT.Is_HysteroscopyNormal = true;
        }
        else
        {
            ObjOCT.Is_HysteroscopyNormal = false;
        }
        ObjOCT.HysteroscopyNormalRemark = ddlHysteroscopy.SelectedValue; ;
        if (ChkAdhesions.Checked == true)
        {
            ObjOCT.Is_Adhesions = true;
        }
        else
        {
            ObjOCT.Is_Adhesions = false;
        }
        if (chksubmucous.Checked == true)
        {
            ObjOCT.Is_SubmucousFibroids = true;
        }
        else
        {
            ObjOCT.Is_SubmucousFibroids = false;
        }
        if (ChkIntervation.Checked == true)
        {
            ObjOCT.Is_AnyIntervation = true;
        }
        else
        {
            ObjOCT.Is_AnyIntervation = false;
        }
        ObjOCT.HysteroscopyRemark = txtcomments.Text;

        //----
        if (chkPelvicAnatomy.Checked == true)
        {
            ObjOCT.Is_PelvicAnatomy = true;
        }
        else
        {
            ObjOCT.Is_PelvicAnatomy = false;
        }
        if (chkFibroids.Checked == true)
        {
            ObjOCT.Is_Fibroids = true;
        }
        else
        {
            ObjOCT.Is_Fibroids = false;
        }
        if (chkTubePatent.Checked == true)
        {
            ObjOCT.Is_TubePatent = true;
        }
        else
        {
            ObjOCT.Is_TubePatent = false;
        }
        ObjOCT.TubePatentRemark = ddlTubePlates.SelectedValue;
        if (ChkTubalAnatomyNormal.Checked == true)
        {
            ObjOCT.Is_TubalAnatomy = true;
        }
        else
        {
            ObjOCT.Is_TubalAnatomy = false;
        }
       
        ObjOCT.LaparoscopyRemark = txtLaparoscopy.Text;


        //*****
        if (chkOvariesNormal.Checked == true)
        {
            ObjOCT.Is_OvariesNormal = true;
        }
        else
        {
            ObjOCT.Is_OvariesNormal = false;
        }
        if (chkPCO.Checked == true)
        {
            ObjOCT.Is_PCO = true;
        }
        else
        {
            ObjOCT.Is_PCO = false;
        }
        if (chkCyst.Checked == true)
        {
            ObjOCT.Is_Cyst = true;
        }
        else
        {
            ObjOCT.Is_Cyst = false;
        }
        ObjOCT.DrillingRemark = ddlDrilling.SelectedValue;
        if (chkDrilling.Checked == true)
        {
            ObjOCT.Is_Drilling = true;
        }
        else
        {
            ObjOCT.Is_Drilling = false;
        }
        if (chkEndometriosis.Checked == true)
        {
            ObjOCT.Is_Endometriosis = true;
        }
        else
        {
            ObjOCT.Is_Endometriosis = false;
        }
        ObjOCT.OvariesRemark = txtOvariescomments.Text;

        //ObjOCT.CystSize = txtCystSize.Text;

        //ObjOCT.Drains = ddlDrains.SelectedValue;
        //ObjOCT.Oophorectomy = ddlOophorectomy.SelectedValue;
        //ObjOCT.Site = txtsite.Text;
        //ObjOCT.Resected = ddlResected.SelectedValue;
        //ObjOCT.Adhesions = ddlAdhesions.SelectedValue;
        //ObjOCT.Notes = txtcomments.Text;

        ObjOCT.P_CreatedBy = Convert.ToString(Session["username"]); ;
        ObjOCT.Branchid = Convert.ToString(Session["Branchid"]); ;
        ObjOCT.Insert_Diagnostic_Cyste_Section();

        ShowMessage("Record save successfully", MessageType.Success);

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

        ObjOCT.Alter_Diagnostic_Cyste_Section_Report(Convert.ToInt32(Session["OTRegNo"]), Convert.ToInt32(Session["OTOpdNo"]), Convert.ToInt32(Session["OTIpdNo"]));
        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Report/Rpt_Laparoscopic_Cyste_Sectio_Report.rpt");
        Session["reportname"] = "Diagnostic_Cyste_Section";
        Session["RPTFORMAT"] = "pdf";

        //ReportParameterClass.SelectionFormula = sql;
        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);
    }
}