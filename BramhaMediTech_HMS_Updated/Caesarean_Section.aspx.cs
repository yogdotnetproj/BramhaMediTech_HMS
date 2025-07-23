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
public partial class Caesarean_Section : System.Web.UI.Page
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
        ObjOCT.IPDNO = Convert.ToInt32(Session["OTIpdNo"]); ;
        if (txtDate.Text != "")
        {
            ObjOCT.EntryDate = Convert.ToDateTime( txtDate.Text);
        }
       // else
      // {
           // ObjOCT.EntryDate = "";

        //  }
       // ObjOCT.EntryDate = 0;
        ObjOCT.NPO = ddlNPO.SelectedValue;
        ObjOCT.NPORemark = txtdetails.Text;
        ObjOCT.Medication = txtMedication.Text;
        ObjOCT.SugarMonitoring = ddlSugarMonotoring.SelectedValue;
        ObjOCT.Sliding = ddlSliding.SelectedValue;
        ObjOCT.Notes = txtNote.Text;
        ObjOCT.P_CreatedBy = Convert.ToString(Session["username"]); ;
        ObjOCT.Branchid = Convert.ToString(Session["Branchid"]); ;
        ObjOCT.Insert_CaesareanSection();
        ShowMessage("Record save successfully", MessageType.Success);

        txtNote.Text = "";
        txtMedication.Text = "";
        txtdetails.Text = "";
        txtDate.Text = "";
       
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
        ObjOCT.Alter_Casarean_Section_Report(Convert.ToInt32(Session["OTRegNo"]), Convert.ToInt32(Session["OTOpdNo"]), Convert.ToInt32(Session["OTIpdNo"]));
        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Report/Rpt_CaesareanSection_Report.rpt");
        Session["reportname"] = "CaesareanSection";
        Session["RPTFORMAT"] = "pdf";

        //ReportParameterClass.SelectionFormula = sql;
        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);
    }
}