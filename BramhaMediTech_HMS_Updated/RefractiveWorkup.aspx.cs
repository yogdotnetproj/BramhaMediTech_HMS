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
using System.Drawing.Printing;
using System.Drawing.Design;

using System.Drawing;

public partial class RefractiveWorkup : System.Web.UI.Page
{
    public enum MessageType { Success, Error, Info, Warning };
    Dental_Clinic_C ObjDC = new Dental_Clinic_C();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            txtEntryDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            Get_All_Opthalmology_Data(Convert.ToInt32(Session["EmrRegNo"]));
            if (Convert.ToString(Session["EmrOpdNo"]) != "")
            {
                ObjDC.P_OpdNo = Convert.ToInt32(Session["EmrOpdNo"]);
                Get_Opthalmology_Clinic(ObjDC.P_OpdNo);
            }
            else
            {
                ObjDC.P_OpdNo = 0;
            }
            if (Convert.ToString(Session["EmrIpdNo"]) != "")
            {
                ObjDC.P_IpdNo = Convert.ToInt32(Session["EmrIpdNo"]);
               
            }
            else
            {
                ObjDC.P_IpdNo = 0;
            }
           
        }
    }
    public void Get_All_Opthalmology_Data(int Patregid)
    {

        DataTable dt = new DataTable();

        using (SqlConnection con = DataAccess.ConInitForDC())
        {
            using (SqlCommand cmd = new SqlCommand("usp_GetAll_Optho_RefractiveWorkup_Details", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@PatRegId", Convert.ToInt32(Session["EmrRegNo"]));

                con.Open();

                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(dt);
                }

                con.Close();
                con.Dispose();
            }

            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();

            }


        }
    }
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
    public void DrawLineInt(Bitmap bmp)
    {

        Bitmap bitmap = new Bitmap(1000, 800, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
        Graphics graphics = Graphics.FromImage(bitmap);

        Pen pen = new Pen(Color.Blue, 2);
        PointF p1 = new PointF(0, 0);   // start point
        PointF c1 = new PointF(0, 800);   // first control point
        PointF c2 = new PointF(1000, 0);  // second control point
        PointF p2 = new PointF(1000, 800);  // end point
        graphics.DrawBezier(pen, p1, c1, c2, p2);

        bitmap.Save("DrawBezierSpline.png");
//----------------------------------------------
        Pen blackPen = new Pen(Color.Black, 3);

        int x1 = 100;
        int y1 = 100;
        int x2 = 500;
        int y2 = 100;
        // Draw line to screen.
      //  e.Graphics.DrawLine(blackPen, x1, y1, x2, y2);
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["EmrOpdNo"]) != "")
        {
            ObjDC.P_OpdNo = Convert.ToInt32(Session["EmrOpdNo"]);
        }
        else
        {
            ObjDC.P_OpdNo = 0;
        }
        if (Convert.ToString(Session["EmrIpdNo"]) != "")
        {
            ObjDC.P_IpdNo = Convert.ToInt32(Session["EmrIpdNo"]);
        }
        else
        {
            ObjDC.P_IpdNo = 0;
        }
        ObjDC.P_Patregid = Convert.ToInt32(Session["EmrRegNo"]);
        ObjDC.P_CreatedBy = Convert.ToString(Session["username"]);
        //ObjDC.P_Branchid = Convert.ToInt32(Session["Branchid"]);

        ObjDC.P_ARDate = Convert.ToDateTime(txtEntryDate.Text);
        ObjDC.P_OORSPH = Convert.ToString(txtsphARR.Text);
        ObjDC.P_OORCYL = Convert.ToString(txtCylArR.Text);
        ObjDC.P_OORAXIS = Convert.ToString(txtAxisARR.Text);
        ObjDC.P_OORemark = Convert.ToString(txtRemarks.Text);

        ObjDC.P_OOLSPH = Convert.ToString(txtsphARL.Text);
        ObjDC.P_OOLCYL = Convert.ToString(txtCylArL.Text);
        ObjDC.P_OOLAXIS = Convert.ToString(txtAxisARL.Text);
        //-------------------------------

        ObjDC.P_UNRSPH = Convert.ToString(txtSPHR.Text);
        ObjDC.P_UNRCYL = Convert.ToString(txtCYLR.Text);
        //************
        ObjDC.P_UNRAXIS = Convert.ToString(txtAXISR.Text);
        ObjDC.P_UNRVA = Convert.ToString(txtVAR.Text);
        ObjDC.P_UNRAdd = Convert.ToString(txtAddR.Text);
        ObjDC.P_UNLSPH = Convert.ToString(txtSPHL.Text);
        ObjDC.P_UNLCYL = Convert.ToString(txtCYLL.Text);

        ObjDC.P_UNLAXIS = Convert.ToString(txtAXISL.Text);
        ObjDC.P_UNLVA = Convert.ToString(txtVAL.Text);
        ObjDC.P_UNLAdd = Convert.ToString(txtAddL.Text);
        ObjDC.P_MedicationUsed = Convert.ToString(txtMedicationUsed.Text);
        ObjDC.P_RetnoscopyWorking = Convert.ToString(txtRetnoscopyWorking.Text);

        ObjDC.P_DiaRSPH = Convert.ToString(txtspl3.Text);
        ObjDC.P_DiaRCYL = Convert.ToString(txtcyl3.Text);
        ObjDC.P_DiaRAXIS = Convert.ToString(txtaxis3.Text);
        ObjDC.P_DiaLSPH = Convert.ToString(txtspiL3.Text);
        ObjDC.P_DiaLCYL = Convert.ToString(txtcylL3.Text);
        ObjDC.P_DiaLAXIS = Convert.ToString(txtAxisL3.Text);

        ObjDC.P_DiaRRSPH = Convert.ToString(txtsplRet.Text);
        ObjDC.P_DiaRRCYL = Convert.ToString(txtcylret.Text);
        ObjDC.P_DiaRRAXIS = Convert.ToString(txtaxixret.Text);
        ObjDC.P_DiaRLSPH = Convert.ToString(txtsplretL.Text);
        ObjDC.P_DiaRLCYL = Convert.ToString(txtcylretL.Text);
        ObjDC.P_DiaRLAXIS = Convert.ToString(txtaxisretlL.Text);
        //--A
        ObjDC.P_FPRSPH = Convert.ToString(txtSPHPR.Text);
        ObjDC.P_FPRCYL = Convert.ToString(txtCYLPR.Text);
        ObjDC.P_FPRAXIS = Convert.ToString(txtAXISPR.Text);
        ObjDC.P_FPRVA = Convert.ToString(txtVAPR.Text);
        ObjDC.P_FPRAdd = Convert.ToString(txtAddPR.Text);
        ObjDC.P_FPLSPH = Convert.ToString(txtSPHPL.Text);
        ObjDC.P_FPLCYL = Convert.ToString(txtCYLPL.Text);
        ObjDC.P_FPLAXIS = Convert.ToString(txtAXISPL.Text);
        ObjDC.P_FPLVA = Convert.ToString(txtVAPL.Text);
        ObjDC.P_FPLAdd = Convert.ToString(txtaddPL.Text);
       // --

        ObjDC.P_OPRSPH = Convert.ToString(txtSPHOL.Text);
        ObjDC.P_OPRCYL = Convert.ToString(txtCYLOL.Text);
        ObjDC.P_OPRAXIS = Convert.ToString(txtAXISOL.Text);
        ObjDC.P_OPLSPH = Convert.ToString(txtSPHOLR.Text);
        ObjDC.P_OPLCYL = Convert.ToString(txtCYLOLR.Text);
        ObjDC.P_OPLAXIS = Convert.ToString(txtAxisOR.Text);
        ObjDC.P_UNOOAD = Convert.ToString(txtAddOR.Text);

        ObjDC.P_UNADOD = Convert.ToString(txtunaddesOD.Text);
        ObjDC.P_UNADOD1 = Convert.ToString(txtUnaddesOd1.Text);
        ObjDC.P_UNANOD = Convert.ToString(txtUnaddedOd2.Text);
        ObjDC.P_UNANOD1 = Convert.ToString(txtUnaddedOd3.Text);

        ObjDC.P_WGOD = Convert.ToString(txtWithGlass.Text);
        ObjDC.P_WGOD1 = Convert.ToString(txtWithGlass1.Text);
        ObjDC.P_WGNOD = Convert.ToString(txtWithGlass2.Text);
        ObjDC.P_WGNOD1 = Convert.ToString(txtWithGlass3.Text);

        ObjDC.P_WPDOD = Convert.ToString(txtWithPinhole.Text);
        ObjDC.P_WPDOD1 = Convert.ToString(txtWithPinhole1.Text);
        ObjDC.P_WPNOD = Convert.ToString(txtWithPinhole2.Text);
        ObjDC.P_WPNOD1 = Convert.ToString(txtWithPinhole3.Text);

        ObjDC.P_BCDOD = Convert.ToString(txtBestCorrect.Text);
        ObjDC.P_BCDOD1 = Convert.ToString(txtBestCorrect1.Text);
        ObjDC.P_BCNOD = Convert.ToString(txtBestCorrect2.Text);
        ObjDC.P_BCNOD1 = Convert.ToString(txtBestCorrect3.Text);

        ObjDC.P_RefractiveNotes = Convert.ToString(txtNotes.Text);
        ObjDC.P_IOP = Convert.ToString(txtInstrument.Text);

         ObjDC.P_AntiglucinMedication = Convert.ToString(txtMedication.Text);
         ObjDC.P_REMin1 = Convert.ToString(txtReMin1.Text);
         ObjDC.P_REMin2 = Convert.ToString(txtLeMin1.Text);
         ObjDC.P_REMin3 = Convert.ToString(txtReMin2.Text);
         ObjDC.P_REMin4 = Convert.ToString(txtLeMin2.Text);

         ObjDC.P_LEMin1 = Convert.ToString(txtReMin3.Text);
         ObjDC.P_LEMin2 = Convert.ToString(txtLeMin3.Text);
         ObjDC.P_LEMin3 = Convert.ToString(txtReMin4.Text);
         ObjDC.P_LEMin4 = Convert.ToString(txtLeMin4.Text);




        ObjDC.Insert_Optha_RefractiveWorkup_Clinic();
        ShowMessage("Record save successfully", MessageType.Success);
        Get_All_Opthalmology_Data(Convert.ToInt32(Session["EmrRegNo"]));
    }
    protected void btnreport_Click(object sender, EventArgs e)
    {
        string sql = "";
        if (Convert.ToString(Session["EmrOpdNo"]) != "")
        {
            ObjDC.P_OpdNo = Convert.ToInt32(Session["EmrOpdNo"]);
        }
        else
        {
            ObjDC.P_OpdNo = 0;
        }
        if (Convert.ToString(Session["EmrIpdNo"]) != "")
        {
            ObjDC.P_IpdNo = Convert.ToInt32(Session["EmrIpdNo"]);
        }
        else
        {
            ObjDC.P_IpdNo = 0;
        }
        ObjDC.P_Patregid = Convert.ToInt32(Session["EmrRegNo"]);
        ObjDC.Alter_Refractive_WorkUp_Report(Convert.ToInt32(Session["EmrRegNo"]), Convert.ToInt32(Session["EmrOpdNo"]), Convert.ToInt32(Session["EmrIpdNo"]));
        // ObjDC.Alter_Vw_Theatre_CheckList(ObjDALPPE);
        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Report/Rpt_Refractive_WorkUp_Report.rpt");
        Session["reportname"] = "Refractive_WorkUp_Report";
        Session["RPTFORMAT"] = "pdf";

        //ReportParameterClass.SelectionFormula = sql;
        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);

    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int OPDNo = Convert.ToInt32(GridView1.DataKeys[e.NewEditIndex]["OPDNo"]);
        ViewState["OPDNO"] = OPDNo;

         Get_Opthalmology_Clinic(OPDNo);
       
        e.Cancel = true;
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }

    public void Get_Opthalmology_Clinic(int OPDNo)
    {

        DataTable dt = new DataTable();

        using (SqlConnection con = DataAccess.ConInitForDC())
        {
            using (SqlCommand cmd = new SqlCommand("usp_Get_Optho_RefractiveWorkup", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@PatRegId", Convert.ToInt32(Session["EmrRegNo"]));
                cmd.Parameters.AddWithValue("@OPDNO", Convert.ToInt32(OPDNo));
                con.Open();

                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(dt);
                }

                con.Close();
                con.Dispose();
            }

            if (dt.Rows.Count > 0)
            {

                txtEntryDate.Text = Convert.ToString(dt.Rows[0]["ARDate"]);
                txtsphARR.Text = Convert.ToString(dt.Rows[0]["OORSPH"]);
                txtCylArR.Text = Convert.ToString(dt.Rows[0]["OORCYL"]);
                txtAxisARR.Text = Convert.ToString(dt.Rows[0]["OORAXIS"]);
                txtRemarks.Text = Convert.ToString(dt.Rows[0]["OORemark"]);

                txtsphARL.Text = Convert.ToString(dt.Rows[0]["OOLSPH"]);
                txtCylArL.Text = Convert.ToString(dt.Rows[0]["OOLCYL"]);
                txtAxisARL.Text = Convert.ToString(dt.Rows[0]["OOLAXIS"]);
                //-------------------------------

                txtSPHR.Text = Convert.ToString(dt.Rows[0]["UNRSPH"]);
                txtCYLR.Text = Convert.ToString(dt.Rows[0]["UNRCYL"]);

              

                ObjDC.P_UNRSPH = Convert.ToString(txtSPHR.Text);
                ObjDC.P_UNRCYL = Convert.ToString(txtCYLR.Text);

                //&&&&
                txtAXISR.Text = Convert.ToString(dt.Rows[0]["UNRAXIS"]);
                txtVAR.Text = Convert.ToString(dt.Rows[0]["UNRVA"]);
                txtAddR.Text = Convert.ToString(dt.Rows[0]["UNRAdd"]);
                txtSPHL.Text = Convert.ToString(dt.Rows[0]["UNLSPH"]);
                txtCYLL.Text = Convert.ToString(dt.Rows[0]["UNLCYL"]);

                txtAXISL.Text = Convert.ToString(dt.Rows[0]["UNLAXIS"]);
                txtVAL.Text = Convert.ToString(dt.Rows[0]["UNLVA"]);
                txtAddL.Text = Convert.ToString(dt.Rows[0]["UNLAdd"]);
                txtMedicationUsed.Text = Convert.ToString(dt.Rows[0]["MedicationUsed"]);
                txtRetnoscopyWorking.Text = Convert.ToString(dt.Rows[0]["RetnoscopyWorking"]);

               

                //***
                txtspl3.Text = Convert.ToString(dt.Rows[0]["DiaRSPH"]);
                txtcyl3.Text = Convert.ToString(dt.Rows[0]["DiaRCYL"]);
                txtaxis3.Text = Convert.ToString(dt.Rows[0]["DiaRAXIS"]);
                txtspiL3.Text = Convert.ToString(dt.Rows[0]["DiaLSPH"]);
                txtcylL3.Text = Convert.ToString(dt.Rows[0]["DiaLCYL"]);
                txtAxisL3.Text = Convert.ToString(dt.Rows[0]["DiaLAXIS"]);

                txtsplRet.Text = Convert.ToString(dt.Rows[0]["DiaRRSPH"]);
                txtcylret.Text = Convert.ToString(dt.Rows[0]["DiaRRCYL"]);
                txtaxixret.Text = Convert.ToString(dt.Rows[0]["DiaRRAXIS"]);
                txtsplretL.Text = Convert.ToString(dt.Rows[0]["DiaRLSPH"]);
                txtcylretL.Text = Convert.ToString(dt.Rows[0]["DiaRLCYL"]);
                txtaxisretlL.Text = Convert.ToString(dt.Rows[0]["DiaRLAXIS"]);

               

              

                //----
                txtSPHPR.Text = Convert.ToString(dt.Rows[0]["FPRSPH"]);
                txtCYLPR.Text = Convert.ToString(dt.Rows[0]["FPRCYL"]);
                txtAXISPR.Text = Convert.ToString(dt.Rows[0]["FPRAXIS"]);
                txtVAPR.Text = Convert.ToString(dt.Rows[0]["FPRVA"]);
                txtAddPR.Text = Convert.ToString(dt.Rows[0]["FPRAdd"]);
                txtSPHPL.Text = Convert.ToString(dt.Rows[0]["FPLSPH"]);
                txtCYLPL.Text = Convert.ToString(dt.Rows[0]["FPLCYL"]);
                txtAXISPL.Text = Convert.ToString(dt.Rows[0]["FPLAXIS"]);
                txtVAPL.Text = Convert.ToString(dt.Rows[0]["FPLVA"]);
                txtaddPL.Text = Convert.ToString(dt.Rows[0]["FPLAdd"]);

                

                txtSPHOL.Text = Convert.ToString(dt.Rows[0]["OPRSPH"]);
                txtCYLOL.Text = Convert.ToString(dt.Rows[0]["OPRCYL"]);
                txtAXISOL.Text = Convert.ToString(dt.Rows[0]["OPRAXIS"]);
                txtSPHOLR.Text = Convert.ToString(dt.Rows[0]["OPLSPH"]);

                txtCYLOLR.Text = Convert.ToString(dt.Rows[0]["OPLCYL"]);
                txtAxisOR.Text = Convert.ToString(dt.Rows[0]["OPLAXIS"]);
               // txtAddOR.Text = Convert.ToString(dt.Rows[0]["UNOOAD"]);

                txtunaddesOD.Text = Convert.ToString(dt.Rows[0]["UNADOD"]);
                txtUnaddesOd1.Text = Convert.ToString(dt.Rows[0]["UNADOD1"]);
                txtUnaddedOd2.Text = Convert.ToString(dt.Rows[0]["UNANOD"]);
                txtUnaddedOd3.Text = Convert.ToString(dt.Rows[0]["UNANOD1"]);



               
                //------------------
                txtWithGlass.Text = Convert.ToString(dt.Rows[0]["WGOD"]);
                txtWithGlass1.Text = Convert.ToString(dt.Rows[0]["WGOD1"]);
                txtWithGlass2.Text = Convert.ToString(dt.Rows[0]["WGNOD"]);
                txtWithGlass3.Text = Convert.ToString(dt.Rows[0]["WGNOD1"]);

                txtWithPinhole.Text = Convert.ToString(dt.Rows[0]["WPDOD"]);
                txtWithPinhole1.Text = Convert.ToString(dt.Rows[0]["WPDOD1"]);
                txtWithPinhole2.Text = Convert.ToString(dt.Rows[0]["WPNOD"]);
                txtWithPinhole3.Text = Convert.ToString(dt.Rows[0]["WPNOD1"]);

                txtBestCorrect.Text = Convert.ToString(dt.Rows[0]["BCDOD"]);
                txtBestCorrect1.Text = Convert.ToString(dt.Rows[0]["BCDOD"]);
                txtBestCorrect2.Text = Convert.ToString(dt.Rows[0]["BCNOD"]);
                txtBestCorrect3.Text = Convert.ToString(dt.Rows[0]["BCNOD1"]);



            

                txtNotes.Text = Convert.ToString(dt.Rows[0]["RefractiveNotes"]);
                txtInstrument.Text = Convert.ToString(dt.Rows[0]["IOP"]);

                txtMedication.Text = Convert.ToString(dt.Rows[0]["AntiglucinMedication"]);
                txtReMin1.Text = Convert.ToString(dt.Rows[0]["REMin1"]);
                txtLeMin1.Text = Convert.ToString(dt.Rows[0]["REMin2"]);
                txtReMin2.Text = Convert.ToString(dt.Rows[0]["REMin3"]);
                txtLeMin2.Text = Convert.ToString(dt.Rows[0]["REMin4"]);

                txtReMin3.Text = Convert.ToString(dt.Rows[0]["LEMin1"]);
                txtLeMin3.Text = Convert.ToString(dt.Rows[0]["LEMin2"]);
                txtReMin4.Text = Convert.ToString(dt.Rows[0]["LEMin3"]);
                txtLeMin4.Text = Convert.ToString(dt.Rows[0]["LEMin4"]);

               

            }


        }
    }

    protected void btnPrescription_Click(object sender, EventArgs e)
    {
        this.btnsave_Click(null, null);
        string sql = "";
        if (Convert.ToString(Session["EmrOpdNo"]) != "")
        {
            ObjDC.P_OpdNo = Convert.ToInt32(Session["EmrOpdNo"]);
        }
        else
        {
            ObjDC.P_OpdNo = 0;
        }
        if (Convert.ToString(Session["EmrIpdNo"]) != "")
        {
            ObjDC.P_IpdNo = Convert.ToInt32(Session["EmrIpdNo"]);
        }
        else
        {
            ObjDC.P_IpdNo = 0;
        }
        ObjDC.P_Patregid = Convert.ToInt32(Session["EmrRegNo"]);
        ObjDC.Alter_Refractive_WorkUp_Report(Convert.ToInt32(Session["EmrRegNo"]), Convert.ToInt32(Session["EmrOpdNo"]), Convert.ToInt32(Session["EmrIpdNo"]));
        // ObjDC.Alter_Vw_Theatre_CheckList(ObjDALPPE);
        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Report/Rpt_Refractive_Prescription_Report.rpt");
        Session["reportname"] = "Refractive_Prescription_Report";
        Session["RPTFORMAT"] = "pdf";

        //ReportParameterClass.SelectionFormula = sql;
        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);
    }
}