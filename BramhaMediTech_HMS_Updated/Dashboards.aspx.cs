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

public partial class Dashboards :BasePage
{
    BELOPDPatReg objBELOpdPatReg = new BELOPDPatReg();
    DALOpdReg objDALOpdPatReg = new DALOpdReg();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDashboard();
        }
    }

    public void BindDashboard()
    {
        DataSet ds = new DataSet();
        if (txtFrom.Text.ToString() != "")
        {

            ViewState["FromDate"] = txtFrom.Text.ToString();
        }
        else
        {
            ViewState["FromDate"] = "";
        }
        if (txtTo.Text.ToString() != "")
        {

            ViewState["ToDate"] = txtTo.Text.ToString();
        }
        else
        {
            ViewState["ToDate"] = "";
        }

        ds = objDALOpdPatReg.GetBindDashboard(Convert.ToInt32(Session["Branchid"]), Convert.ToInt32( Rbltype.SelectedValue), Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]));
        if (ds.Tables[0].Rows.Count > 0)
        {
            btnopdIncome.Text = "Consultation + OPD:=" + Convert.ToString(ds.Tables[0].Rows[0]["OPDReceiveAmt"]);
        }
        if (ds.Tables[1].Rows.Count > 0)
        {
            btnEmerency.Text = "Emergency :=" + Convert.ToString(ds.Tables[1].Rows[0]["EMERReceiveAmt"]);
        }
        if (ds.Tables[2].Rows.Count > 0)
        {
            btnEEG.Text = "EEG :=" + Convert.ToString(ds.Tables[2].Rows[0]["EEGReceiveAmt"]);
        }
        if (ds.Tables[3].Rows.Count > 0)
        {
            btnAmbulance.Text = "Ambulance :=" + Convert.ToString(ds.Tables[3].Rows[0]["AmbReceiveAmt"]);
        }
        if (ds.Tables[4].Rows.Count > 0)
        {
            btnOphthal.Text = "OPHTHAL :=" + Convert.ToString(ds.Tables[4].Rows[0]["OPTReceiveAmt"]);
        }

        if (ds.Tables[5].Rows.Count > 0)
        {
            btnDeposit.Text = "Deposit :=" + Convert.ToString(ds.Tables[5].Rows[0]["DepoReceiveAmt"]);
        }
        if (ds.Tables[6].Rows.Count > 0)
        {
            btnIpdIncome.Text = "IPD Advance :=" + Convert.ToString(ds.Tables[6].Rows[0]["AdvReceiveAmt"]);
        }
        if (ds.Tables[7].Rows.Count > 0)
        {
            btnRefund.Text = "IPD Refund :=" + Convert.ToString(ds.Tables[7].Rows[0]["RefReceiveAmt"]);
        }
        if (ds.Tables[8].Rows.Count > 0)
        {
            BtnMedicalLab.Text = "Medical Lab :=" + Convert.ToString(ds.Tables[8].Rows[0]["RecAmtMed"]);
        }
        if (ds.Tables[9].Rows.Count > 0)
        {
            btnRadiology.Text = "Radiology Lab :=" + Convert.ToString(ds.Tables[9].Rows[0]["RecAmtRad"]);
        }
        if (ds.Tables[10].Rows.Count > 0)
        {
            btnPathology.Text = "Pathology :=" + Convert.ToString(ds.Tables[10].Rows[0]["RecAmtLab"]);
        }
       // btnopdIncome.Text = "Consultation + OPD:-" + 100123456;
    }
    protected void btnshow_Click(object sender, EventArgs e)
    {
        BindDashboard();
    }
}