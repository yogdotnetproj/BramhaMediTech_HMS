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
public partial class ENDOSCOPY :BasePage
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
        if (txtdateofprocedure.Text != "")
        {
            ObjOCT.OperationDate = Convert.ToDateTime(txtdateofprocedure.Text);
        }
        ObjOCT.ProcedureType = ddlprocedureType.SelectedValue;
        ObjOCT.ProcedurePerformed = txtprocedureperformed.Text;
        ObjOCT.Endoscopist = txtEndoscopist.Text;
        ObjOCT.Anaesthesia = txtAnaesthesia.Text;
        ObjOCT.Instrument = txtInstrument.Text;
        ObjOCT.IndicationofProcedure = txtIndicationOfProcedure.Text;
        ObjOCT.DescriptionOfProcedure = txtDescriptionofprocedure.Text;
        ObjOCT.Complications = txtComplications.Text;
        ObjOCT.Impression = txtImpression.Text;
        ObjOCT.Notes = txtOtherNotes.Text;
        ObjOCT.P_CreatedBy = Convert.ToString(Session["username"]); ;
        ObjOCT.Branchid = Convert.ToString(Session["Branchid"]); ;
        ObjOCT.Insert_ENDOSCOPY_Section();

        ShowMessage("Record save successfully", MessageType.Success);

        txtOtherNotes.Text = "";
        txtInstrument.Text = "";
        txtIndicationOfProcedure.Text = "";
        txtImpression.Text = "";
        txtEndoscopist.Text = "";
        txtDescriptionofprocedure.Text = "";
        txtdateofprocedure.Text = "";
        txtComplications.Text = "";
        txtAnaesthesia.Text = "";
        txtprocedureperformed.Text = "";

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
        ObjOCT.Alter_ENDOSCOPY_Section_Report(Convert.ToInt32(Session["OTRegNo"]), Convert.ToInt32(Session["OTOpdNo"]), Convert.ToInt32(Session["OTIpdNo"]));
        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Report/Rpt_ENDOSCOPY_Section_Report.rpt");
        Session["reportname"] = "ENDOSCOPY_Section_Report";
        Session["RPTFORMAT"] = "pdf";

        //ReportParameterClass.SelectionFormula = sql;
        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);

    }
}