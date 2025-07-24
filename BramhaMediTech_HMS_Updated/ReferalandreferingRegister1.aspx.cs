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

public partial class ReferalandreferingRegister1 : BasePage
{
    BELPatientInformation objBELPatInfo = new BELPatientInformation();
    DALPatientInformation objDALPatInfo = new DALPatientInformation();
    BLLReports ObjDOReport = new BLLReports();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {


            // txtEntryDate.Text = DateTime.Now.ToShortDateString();
            txtToDate.Text = System.DateTime.Now.ToShortDateString();
            txtFromDate.Text = System.DateTime.Now.ToShortDateString();
            ViewState["RefDrID"] = "0";
            ViewState["ConsultID"] = "0";
            //FillCancelPatientRegGrid();



        }
    }

    protected void txtConsDoctorName_TextChanged(object sender, EventArgs e)
    {
        if (txtConsDoctorName.Text != "")
        {
            string[] PatientInfo = txtConsDoctorName.Text.Split('-');
            if (PatientInfo.Length > 1)
            {
                txtConsDoctorName.Text = PatientInfo[1];
                ViewState["ConsultID"] = PatientInfo[0];
                //ConsultantDrId = ddlConsDoctorName.SelectedValue.ToString();

                int BranchId = Convert.ToInt32(Session["Branchid"]);
                int FId = Convert.ToInt32(Session["FId"]);

              


            }
            else
            {
                txtConsDoctorName.Text = "";
            }
        }
    }
    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchConsultDoc(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        return objDALOpdReg.FillAllConsultDoc(prefixText);
    }



    protected void txtReferingdr_TextChanged(object sender, EventArgs e)
    {
        if (txtReferingdr.Text != "")
        {
            string[] PatientInfo = txtReferingdr.Text.Split('-');
            if (PatientInfo.Length > 1)
            {
                txtReferingdr.Text = PatientInfo[1];
                ViewState["RefDrID"] = PatientInfo[0];
                //ConsultantDrId = ddlConsDoctorName.SelectedValue.ToString();

               // int BranchId = Convert.ToInt32(Session["Branchid"]);
               // int FId = Convert.ToInt32(Session["FId"]);




            }
            else
            {
                txtReferingdr.Text = "";
            }
        }
    }
    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchReferingdr(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        return objDALOpdReg.FillAllConsultDoc(prefixText);
    }
  

    
   

    protected void btnSearch_Click(object sender, EventArgs e)
    {
       // FillCancelPatientRegGrid();
        Reset();
    }

    private void Reset()
    {

        
    }



    protected void btnPrint_Click(object sender, EventArgs e)
    {
        string sql = "";

        try
        {

            if (txtFromDate.Text.ToString() != "")
            {
                ViewState["FromDate"] = txtFromDate.Text.ToString();

            }
            else
            {
                ViewState["FromDate"] = "";
            }
            if (txtToDate.Text.ToString() != "")
            {

                ViewState["ToDate"] = txtToDate.Text.ToString();


            }
            else
            {
                ViewState["ToDate"] = "";
            }
            int BranchId = Convert.ToInt32(Session["BranchId"]);
            int FId = Convert.ToInt32(Session["FId"]);
            ObjDOReport.Get_ReferalandreferingReport(Convert.ToString(ViewState["FromDate"]), Convert.ToString(ViewState["ToDate"]), Convert.ToInt32(ViewState["ConsultID"]), Convert.ToInt32(ViewState["RefDrID"]), Convert.ToInt32(rblReferType.SelectedValue));
            if (rblReferType.SelectedValue == "0")
            {
                Session.Add("rptsql", sql);
                Session["rptname"] = Server.MapPath("~/Reports/Rpt_ReferConsultantReport.rpt");
                Session["reportname"] = "Refertocons";
                Session["RPTFORMAT"] = "pdf";
            }
            else
            {
                Session.Add("rptsql", sql);
                Session["rptname"] = Server.MapPath("~/Reports/Rpt_ReferConsultantReport.rpt");
                Session["reportname"] = "Refertorefering";
                Session["RPTFORMAT"] = "pdf";
            }


            string close = "<script language='javascript'>javascript:OpenReport();</script>";
            Type title1 = this.GetType();
            Page.ClientScript.RegisterStartupScript(title1, "", close);


        }
        catch (Exception ex)
        {
          //  lblMessage.Text = ex.Message;
        }
    }
}