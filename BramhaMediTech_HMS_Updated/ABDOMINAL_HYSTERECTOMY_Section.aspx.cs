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
public partial class ABDOMINAL_HYSTERECTOMY_Section : BasePage
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
        // ObjOCT.Notes = txtPRevLSCSComplication.Text;

        //----
        ObjOCT.STANDARDTAH = ddlStandardTAH.SelectedValue;
        ObjOCT.STANDARDTAH_R = ddlStandardTAH1.SelectedValue;
        ObjOCT.UTERINESIZEINWEEK = txtUterineSize.Text;
        ObjOCT.ADHESIONS = ddlADHESIONS.SelectedValue;
        ObjOCT.ENDOMETRIOSIS = ddlENDOMETRIOSIS.SelectedValue;
        ObjOCT.OOPHORECTOMY = ddlOOPHORECTOMY.SelectedValue;

        

        ObjOCT.Notes = txtcomments.Text;

        ObjOCT.P_CreatedBy = Convert.ToString(Session["username"]); ;
        ObjOCT.Branchid = Convert.ToString(Session["Branchid"]); ;
        ObjOCT.Insert_ABDOMINALHYSTERECTOMY_Section();
        ShowMessage("Record save successfully", MessageType.Success);

        txtAnaesthetist.Text = "";
        txtbloodloss.Text = "";
        txtcomments.Text = "";
        txtdateofoperation.Text = "";
        txtDeflate.Text = "";       
        txtdurationofsurgery.Text = "";
        txtInflate.Text = "";       
        txtmaterialforwarded.Text = "";
        txtNoteDate.Text = "";       
        txtoperationFinding.Text = "";
        txtoperativeProcedure.Text = "";
        txtpostoperativeAnaesthetist.Text = "";
        txtpostoperativediagnosis.Text = "";
        txtpreOperativeDiagnosis.Text = "";
        txtschedule.Text = "";
        txtScrubNurse.Text = "";
        txtSurgeon.Text = "";
        txtswabcount.Text = "";
        txtTourniquetTime.Text = "";
        txtUterineSize.Text = "";
        txtcomments.Text = "";
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
        ObjOCT.Alter_Abdominal_Section_Report(Convert.ToInt32(Session["OTRegNo"]), Convert.ToInt32(Session["OTOpdNo"]), Convert.ToInt32(Session["OTIpdNo"]));
        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Report/Rpt_ABDOMINAL_Section_Report.rpt");
        Session["reportname"] = "ABDOMINAL _Section_Report";
        Session["RPTFORMAT"] = "pdf";

        //ReportParameterClass.SelectionFormula = sql;
        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);
    }
}