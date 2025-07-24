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


public partial class IPDDrNotes : BasePage
{
    BELOPDPatReg objBELOpdReg = new BELOPDPatReg();
    DALOpdReg objDALOpdReg = new DALOpdReg();
    BELEmpReg objBELEmpReg = new BELEmpReg();
    DALEmpReg objDALEmpReg = new DALEmpReg();
    DALIPDDesk objDalIpdDesk = new DALIPDDesk();
    clsEmr obj = new clsEmr();

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!Page.IsPostBack)
        //{
        //    txtStart.Text = DateTime.Now.ToString("dd/MM/yyyy");
        //    txtEnd.Text = DateTime.Now.ToString("dd/MM/yyyy");
        //    FillRoomCategory();
        //    refreshdata();
        //}
        if (!this.IsPostBack)
        {
            if (Session["EmrRegNo"] != "")
            {
                string regId = Convert.ToString(Session["EmrRegNo"]);
                GetRecords();
            }
            else
            {
                Response.Redirect(string.Format("ListPatients.aspx"));
            }
        }
    }

    private DataTable GetRecords()
    {
        string patientregid = Convert.ToString(Session["EmrRegNo"]);
        string opd = Convert.ToString(Session["EmrOpdNo"]);
        string ipd = Convert.ToString(Session["EmrIpdNo"]);
        string regId = Convert.ToString(Session["EmrRegNo"]);
        string name = Request.QueryString["Name"];
        // string opd = Convert.ToString(Session["EmrIpdNo"]);
        string branchid = Convert.ToString(Session["Branchid"]);

        DataTable dt = new DataTable();
        try
        {
            dt = obj.GetDailyDrNote_ForIPD(patientregid, ipd, branchid);
            GvNoteIngrid.DataSource = dt;
            GvNoteIngrid.DataBind();
        }
        catch (Exception ex)
        {

        }
        return dt;
    }










    protected void GvNoteIngrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
}