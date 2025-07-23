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

public partial class DermatologyOutPatient : System.Web.UI.Page
{
    public enum MessageType { Success, Error, Info, Warning };
    Dermatology_C ObjDer = new Dermatology_C();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
           // SetInitialRow();
        }
    }

   
    protected void btnsave_Click(object sender, EventArgs e)
    {
            if (Convert.ToString(Session["EmrOpdNo"]) != "")
            {
                ObjDer.P_OpdNo = Convert.ToInt32(Session["EmrOpdNo"]);
            }
            else
            {
                ObjDer.P_OpdNo = 0;
            }
            if (Convert.ToString(Session["EmrIpdNo"]) != "")
            {
                ObjDer.P_IpdNo = Convert.ToInt32(Session["EmrIpdNo"]);
            }
            else
            {
                ObjDer.P_IpdNo = 0;
            }
            ObjDer.P_Patregid = Convert.ToInt32(Session["EmrRegNo"]);
            ObjDer.P_CreatedBy = Convert.ToString(Session["username"]);
           
            ObjDer.P_Pulse = txtpulse.Text;
            ObjDer.P_BloodPressure = txtBloodPressure.Text;
            ObjDer.P_Temperature = txtTemperature.Text;
            ObjDer.P_Other_Complaints = txtOther.Text;
            ObjDer.P_ExaminationFindings = txtExaminationFinding.Text;
            ObjDer.P_OtherTreatment = txtOther1.Text;

            ObjDer.P_Treatment = txtTreatmentMedication.Text;
            ObjDer.P_Peel = txtPeel.Text;
            ObjDer.P_IntraLeisonSteroidOther = txtOtherIntraLeisonSteroid.Text;
            if (ChkItechking.Checked == true)
            {
                ObjDer.Is_Itech = true;
            }
            else
            {
                ObjDer.Is_Itech = false;
            }
            if (chkRash.Checked == true)
            {
                ObjDer.Is_Rash = true;
            }
            else
            {
                ObjDer.Is_Rash = false;
            }
            if (chkPigmentation.Checked == true)
            {
                ObjDer.Is_Pigmentation = true;
            }
            else
            {
                ObjDer.Is_Pigmentation = false;
            }
            if (chkAcne.Checked == true)
            {
                ObjDer.Is_Acne = true;
            }
            else
            {
                ObjDer.Is_Acne = false;
            }
            if (chkScar.Checked == true)
            {
                ObjDer.Is_Scar = true;
            }
            else
            {
                ObjDer.Is_Scar = false;
            }
            if (chkHirsutism.Checked == true)
            {
                ObjDer.Is_Hirsutism = true;
            }
            else
            {
                ObjDer.Is_Hirsutism = false;
            }
            if (ChkHairLoss.Checked == true)
            {
                ObjDer.Is_HairLoss = true;
            }
            else
            {
                ObjDer.Is_HairLoss = false;
            }
            if (chkExcessHairGrowth.Checked == true)
            {
                ObjDer.Is_ExcessHairGrowth = true;
            }
            else
            {
                ObjDer.Is_ExcessHairGrowth = false;
            }
            if (chkFace.Checked == true)
            {
                ObjDer.Is_Face = true;
            }
            else
            {
                ObjDer.Is_Face = false;
            }
            if (chkBody.Checked == true)
            {
                ObjDer.Is_Body = true;
            }
            else
            {
                ObjDer.Is_Body = false;
            }
            if (chkExtremities.Checked == true)
            {
                ObjDer.Is_Extremities = true;
            }
            else
            {
                ObjDer.Is_Extremities = false;
            }
            if (ChkDM.Checked == true)
            {
                ObjDer.Is_DM = true;
            }
            else
            {
                ObjDer.Is_DM = false;
            }
            if (ChkHTN.Checked == true)
            {
                ObjDer.Is_HTN = true;
            }
            else
            {
                ObjDer.Is_HTN = false;
            }
            if (ChkSmoker.Checked == true)
            {
                ObjDer.Is_Smoker = true;
            }
            else
            {
                ObjDer.Is_Smoker = false;
            }
            if (chkAlcoholic.Checked == true)
            {
                ObjDer.Is_Alcoholic = true;
            }
            else
            {
                ObjDer.Is_Alcoholic = false;
            }
            if (chkTablets.Checked == true)
            {
                ObjDer.Is_Tablets = true;
            }
            else
            {
                ObjDer.Is_Tablets = false;
            }
            if (ChkCapsules.Checked == true)
            {
                ObjDer.Is_Capsules = true;
            }
            else
            {
                ObjDer.Is_Capsules = false;
            }
            if (ChkCream.Checked == true)
            {
                ObjDer.Is_Cream = true;
            }
            else
            {
                ObjDer.Is_Cream = false;
            }
            if (ChkOintment.Checked == true)
            {
                ObjDer.Is_Ointment = true;
            }
            else
            {
                ObjDer.Is_Ointment = false;
            }
            if (ChkLotion.Checked == true)
            {
                ObjDer.Is_Lotion = true;
            }
            else
            {
                ObjDer.Is_Lotion = false;
            }
            if (ChkShampoo.Checked == true)
            {
                ObjDer.Is_Shampoo = true;
            }
            else
            {
                ObjDer.Is_Shampoo = false;
            }
            if (ChkSoap.Checked == true)
            {
                ObjDer.Is_Soap = true;
            }
            else
            {
                ObjDer.Is_Soap = false;
            }
            if (ChkSunscreen.Checked == true)
            {
                ObjDer.Is_Sunscreen = true;
            }
            else
            {
                ObjDer.Is_Sunscreen = false;
            }
            if (ChkHairLaser.Checked == true)
            {
                ObjDer.Is_HairLaser = true;
            }
            else
            {
                ObjDer.Is_HairLaser = false;
            }
            if (ChkCo2Laser.Checked == true)
            {
                ObjDer.Is_CO2Laser = true;
            }
            else
            {
                ObjDer.Is_CO2Laser = false;
            }
            if (ChkInfiniTouch.Checked == true)
            {
                ObjDer.Is_INFINITouch = true;
            }
            else
            {
                ObjDer.Is_INFINITouch = false;
            }
            if (chkTriamcinolone.Checked == true)
            {
                ObjDer.Is_Triamcinolone = true;
            }
            else
            {
                ObjDer.Is_Triamcinolone = false;
            }


           
            ObjDer.P_Branchid = Convert.ToInt32(Session["Branchid"]);
            ObjDer.P_CreatedBy = Convert.ToString(Session["username"]); ;
           
            ObjDer.Insert_DermatologyOutPatients();

        
        ShowMessage("Record save successfully", MessageType.Success);

    }
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
    protected void btnreport_Click(object sender, EventArgs e)
    {
        string sql = "";
        if (Convert.ToString(Session["EmrOpdNo"]) != "")
        {
            ObjDer.P_OpdNo = Convert.ToInt32(Session["EmrOpdNo"]);
        }
        else
        {
            ObjDer.P_OpdNo = 0;
        }
        if (Convert.ToString(Session["EmrIpdNo"]) != "")
        {
            ObjDer.P_IpdNo = Convert.ToInt32(Session["EmrIpdNo"]);
        }
        else
        {
            ObjDer.P_IpdNo = 0;
        }
        ObjDer.P_Patregid = Convert.ToInt32(Session["EmrRegNo"]);
        // objDALIO.Alter_TwoWayRepositoryChart(objBELIO);
        ObjDer.Alter_DermatologyOutPatients_Report(Convert.ToInt32(Session["EmrRegNo"]), Convert.ToInt32(Session["EmrOpdNo"]), Convert.ToInt32(Session["EmrIpdNo"]));
        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Report/Rpt_DermatologyOutPatients_Report.rpt");
        Session["reportname"] = "DermatologyOutPatients_Report";
        Session["RPTFORMAT"] = "pdf";

        //ReportParameterClass.SelectionFormula = sql;
        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);
    }
}