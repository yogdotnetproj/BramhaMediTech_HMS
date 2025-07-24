using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;

public partial class StaticialReport : BasePage
{
    BLLPatientCategory objBLLPatientCategory = new BLLPatientCategory();
    DOPatientCategory objDOPatientCategory;
    string UserId = "";


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                
            }
            catch (Exception)
            {
            }

        }
    }
    protected void BtnTotalPAtientCount_Click(object sender, EventArgs e)
    {
       //Response.Redirect("~/OPDVisitForWomeans.aspx",false);
        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(1250/2);var Mtop = (screen.height/2)-(700/2);window.open( 'AllOPDPatients.aspx?Branchid=" + Session["Branchid"].ToString() + " ', null, 'height=700,width=1250,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);


    }
    protected void btntotalwomenPat_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(1250/2);var Mtop = (screen.height/2)-(700/2);window.open( 'OPDVisitForWomeans.aspx?Branchid=" + Session["Branchid"].ToString() + " ', null, 'height=700,width=1250,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);

    }
    protected void btntotalchild_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(1250/2);var Mtop = (screen.height/2)-(700/2);window.open( 'OPDvisitsforchildrenandadolescents.aspx?Branchid=" + Session["Branchid"].ToString() + " ', null, 'height=700,width=1250,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);

    }
    protected void btntotal0to9_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(1250/2);var Mtop = (screen.height/2)-(700/2);window.open( 'OPDvisitsforchildrenoto9.aspx?Branchid=" + Session["Branchid"].ToString() + " ', null, 'height=700,width=1250,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);

    }
    protected void btnbelow6day_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(1250/2);var Mtop = (screen.height/2)-(700/2);window.open( 'OPDvisitsforchildren6Day.aspx?Branchid=" + Session["Branchid"].ToString() + " ', null, 'height=700,width=1250,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);

    }

    protected void btnmalechildren_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(1250/2);var Mtop = (screen.height/2)-(700/2);window.open( 'OPDvisitsforMalechildren.aspx?Branchid=" + Session["Branchid"].ToString() + " ', null, 'height=700,width=1250,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);

    }
    protected void btnTotalFemailchildren_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(1250/2);var Mtop = (screen.height/2)-(700/2);window.open( 'OPDvisitsforFemailChildren.aspx?Branchid=" + Session["Branchid"].ToString() + " ', null, 'height=700,width=1250,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);

    }
    protected void btnAllVital_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(1250/2);var Mtop = (screen.height/2)-(700/2);window.open( 'OPDvisitsforVitalPatient.aspx?Branchid=" + Session["Branchid"].ToString() + " ', null, 'height=700,width=1250,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);

    }
    protected void btnMalariaPatient_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(1250/2);var Mtop = (screen.height/2)-(700/2);window.open( 'VisitForMalariaPatient.aspx?Branchid=" + Session["Branchid"].ToString() + " ', null, 'height=700,width=1250,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);

    }
    protected void btnAncVisit_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(1250/2);var Mtop = (screen.height/2)-(700/2);window.open( 'VisitForANCPatient.aspx?Branchid=" + Session["Branchid"].ToString() + " ', null, 'height=700,width=1250,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);

    }
    protected void btnaltrasoundscan_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(1250/2);var Mtop = (screen.height/2)-(700/2);window.open( 'VisitForAltrasoundScanPatient.aspx?Branchid=" + Session["Branchid"].ToString() + " ', null, 'height=700,width=1250,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);

    }
    protected void btnNeonatal_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(1250/2);var Mtop = (screen.height/2)-(700/2);window.open( 'NeonataltetanusprophylaxisPatient.aspx?Branchid=" + Session["Branchid"].ToString() + " ', null, 'height=700,width=1250,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);

    }
    protected void btnMalariaprophylaxis_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(1250/2);var Mtop = (screen.height/2)-(700/2);window.open( 'MalariaprophylaxisPatient.aspx?Branchid=" + Session["Branchid"].ToString() + " ', null, 'height=700,width=1250,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);

    }
    protected void btnSyphilis_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(1250/2);var Mtop = (screen.height/2)-(700/2);window.open( 'SyphilisUrinarytractPatient.aspx?Branchid=" + Session["Branchid"].ToString() + " ', null, 'height=700,width=1250,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);

    }
    protected void btnhivCount_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(1250/2);var Mtop = (screen.height/2)-(700/2);window.open( 'HIVTotalPatient.aspx?Branchid=" + Session["Branchid"].ToString() + " ', null, 'height=700,width=1250,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);

    }
    protected void btnhivpositivecount_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(1250/2);var Mtop = (screen.height/2)-(700/2);window.open( 'HIVPositiveTotalPatient.aspx?Branchid=" + Session["Branchid"].ToString() + " ', null, 'height=700,width=1250,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);

    }
    protected void btnIntermittentpreventive_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(1250/2);var Mtop = (screen.height/2)-(700/2);window.open( 'IntermittentPreventiveTreatmentPatient.aspx?Branchid=" + Session["Branchid"].ToString() + " ', null, 'height=700,width=1250,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);

    }
    protected void btnnumberofdeliveres_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(1250/2);var Mtop = (screen.height/2)-(700/2);window.open( 'VisitForNumberofdeliveryPatient.aspx?Branchid=" + Session["Branchid"].ToString() + " ', null, 'height=700,width=1250,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);

    }
    protected void btnCaesarean_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(1250/2);var Mtop = (screen.height/2)-(700/2);window.open( 'VisitForNumberofCaesareandeliveryPatient.aspx?Branchid=" + Session["Branchid"].ToString() + " ', null, 'height=700,width=1250,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);

    }
    protected void btnnormaldelivery_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(1250/2);var Mtop = (screen.height/2)-(700/2);window.open( 'VisitForNumberofNormaldeliveryPatient.aspx?Branchid=" + Session["Branchid"].ToString() + " ', null, 'height=700,width=1250,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);

    }
    protected void btnImmunization_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(1250/2);var Mtop = (screen.height/2)-(700/2);window.open( 'VisitForNumberofImmunizationPatient.aspx?Branchid=" + Session["Branchid"].ToString() + " ', null, 'height=700,width=1250,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);

    }
    protected void btncontraceptive_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(1250/2);var Mtop = (screen.height/2)-(700/2);window.open( 'VisitForNumberofcontraceptivePatient.aspx?Branchid=" + Session["Branchid"].ToString() + " ', null, 'height=700,width=1250,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);

    }
    protected void btnMaterinalDeath_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(1250/2);var Mtop = (screen.height/2)-(700/2);window.open( 'MaterinalDeathPatient.aspx?Branchid=" + Session["Branchid"].ToString() + " ', null, 'height=700,width=1250,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);

    }
}