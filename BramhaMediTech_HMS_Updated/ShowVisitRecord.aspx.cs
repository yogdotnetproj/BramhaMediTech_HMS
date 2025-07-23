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

public partial class ShowVisitRecord : System.Web.UI.Page
{
    AddMedicalRecord_C ObjAMR = new AddMedicalRecord_C();
    DataTable dt = new DataTable();
    DALOpdReg objDALOpdReg = new DALOpdReg();
    public enum MessageType { Success, Error, Info, Warning };
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string regId = Convert.ToString(Session["EmrRegNo"]);
            string name = Request.QueryString["Name"];
            string opd = Convert.ToString(Session["EmrOpdNo"]);
            string entrydate = Request.QueryString["EntryDate"];
            int IpdId = Convert.ToInt32(Session["EmrIpdNo"]);
           
            BindMedicalRecord();
        }
    }

    public void BindMedicalRecord()
    {
        dt = ObjAMR.GetMedicalRecod_Info(Convert.ToInt32(Session["EmrRegNo"]));
        if (dt.Rows.Count > 0)
        {
            gvAddMEdicalRecord.DataSource = dt;
            gvAddMEdicalRecord.DataBind();
        }
        else
        {
            gvAddMEdicalRecord.DataSource = null;
            gvAddMEdicalRecord.DataBind();
        }
    }
    protected void gvAddMEdicalRecord_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
}