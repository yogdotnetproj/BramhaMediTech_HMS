using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdmittedPatientList :BasePage
{
    BLLReports objreports = new BLLReports();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillGrid();
        }
    }
    public void FillGrid()
    {
        int BranchId = Convert.ToInt32(Session["BranchId"]);
        int FId = Convert.ToInt32(Session["FId"]);
        gvPatientInfo.DataSource=objreports.FillAdmittedPatientList(FId, BranchId);
        gvPatientInfo.DataBind();


    }
    protected void Print_Click(object sender, EventArgs e)
    {
         string sql = "";
        
       
            int BranchId = Convert.ToInt32(Session["BranchId"]);
            int FId = Convert.ToInt32(Session["FId"]);

            objreports.AdmittedPatientList(FId, BranchId);

            Session.Add("rptsql", sql);
            Session["rptname"] = Server.MapPath("~/Reports/Rpt_AdmittedPatientList.rpt");
            Session["reportname"] = "AdmittedPatientList";
            Session["RPTFORMAT"] = "pdf";
            

            string close = "<script language='javascript'>javascript:OpenReport();</script>";
            Type title1 = this.GetType();
            Page.ClientScript.RegisterStartupScript(title1, "", close);        

            
      
    }
    protected void gvPatientInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvPatientInfo.PageIndex = e.NewPageIndex;
        FillGrid();
    }
    protected void btnprintExcel_Click(object sender, EventArgs e)
    {
        string sql = "";


        int BranchId = Convert.ToInt32(Session["BranchId"]);
        int FId = Convert.ToInt32(Session["FId"]);

        objreports.AdmittedPatientList(FId, BranchId);

        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Reports/Rpt_AdmittedPatientList.rpt");
        Session["reportname"] = "AdmittedPatientList";
        Session["RPTFORMAT"] = "EXCEL";


        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);   
    }
}