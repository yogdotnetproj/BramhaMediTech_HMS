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

public partial class FaceExamination :BasePage
{
    public enum MessageType { Success, Error, Info, Warning };
    Dental_Clinic_C ObjDC = new Dental_Clinic_C();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
          // txtdate.Text= DateTime.Now.ToString("dd/MM/yyyy");
            GetRecords();
            Get_All_Data(Convert.ToInt32(Session["EmrRegNo"]));
            Get_Opthalmology_Clinic(Convert.ToInt32(Session["EmrOpdNo"]));
        }
    }
    private DataTable GetRecords()
    {
        string patientregid = Convert.ToString(Session["EmrRegNo"]);
        string opd = Convert.ToString(Session["EmrOpdNo"]);
        string ipd = Convert.ToString(Session["EmrIpdNo"]);
        string branchid = Convert.ToString(Session["Branchid"]);

        DataTable dt = new DataTable();
        try
        {
            dt = ObjDC.GetGeneralEmrDetailsEdit(patientregid, opd, ipd, branchid);
            if (dt.Rows.Count > 0)
            {
                txtdiagnosis.Text = Convert.ToString(dt.Rows[0]["Diagnosis"]);
               // txtPastHistory.Text = Convert.ToString(dt.Rows[0]["pasthistory"]);
               // txtAllergys.Text = Convert.ToString(dt.Rows[0]["allergies"]);
            }
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    public void Get_All_Data(int Patregid)
    {

        DataTable dt = new DataTable();

        using (SqlConnection con = DataAccess.ConInitForDC())
        {
            using (SqlCommand cmd = new SqlCommand("usp_GetAll_Face_Examination", con))
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

        ObjDC.P_OcularOD = txtOcularOD.Text;
        ObjDC.P_OcularOS = txtOcularOS.Text;
        ObjDC.P_LidsOD = txtLidsandAdenexaOD.Text;
        ObjDC.P_LidsOS = txtLidsandAdenexaOS.Text;
        ObjDC.P_NasolacrinalOD = txtNasolacrinalOD.Text;
        ObjDC.P_NasolacrinalOS = txtNasolacrinalOS.Text;
        ObjDC.P_SyringingOD = txtSyringingOD.Text;
        ObjDC.P_SyringingOS = txtSyringingOS.Text;
        ObjDC.P_CenjunctivaOD = txtCenjunctivaOD.Text;
        ObjDC.P_CenjunctivaOS = txtCenjunctivaOS.Text;
        ObjDC.P_CorneaOD = txtCorneaOD.Text;
        ObjDC.P_CorneaOS = txtCorneaOS.Text;

        ObjDC.P_IrisOD = txtIrisOD.Text;
        ObjDC.P_IrisOS = txtIrisOS.Text;
        ObjDC.P_PupilOD = txtPupilOD.Text;
        ObjDC.P_PupilOS = txtPupilOS.Text;

        ObjDC.P_LensOD = txtLensOD.Text;
        ObjDC.P_LensOS = txtLensOS.Text;
        ObjDC.P_VitreousOD = txtVitreousOD.Text;
        ObjDC.P_VitreousOS = txtVitreousOS.Text;
        ObjDC.P_OptisDiscOD = txtOptisDiscOD.Text;
        ObjDC.P_OptisDiscOS = txtOptisDiscOS.Text;
        ObjDC.P_COROD = txtCOROD.Text;
        ObjDC.P_COROS = txtCOROS.Text;
        ObjDC.P_FUNDUSOD = txtFUNDUSOD.Text;
        ObjDC.P_FUNDUSOS = txtFUNDUSOS.Text;
        ObjDC.P_VESSELSOD = txtVESSELSOD.Text;
        ObjDC.P_VESSELSOS = txtVESSELSOS.Text;
        ObjDC.P_MACULAOD = txtMACULAOD.Text;
        ObjDC.P_MACULAOS = txtMACULAOS.Text;

        ObjDC.P_PERIPHERYOD = txtPERIPHERYOD.Text;
        ObjDC.P_PERIPHERYOS = txtPERIPHERYOS.Text;
        ObjDC.P_Diagnosis = txtdiagnosis.Text;
        ObjDC.P_Plans = txtPlan.Text;
        ObjDC.P_Discussion = txtDiscussion.Text;
        ObjDC.P_Treatment = txtTreatment.Text;

        ObjDC.P_GonioscopyOD = txtGonioscopyOD.Text;
        ObjDC.P_GonioscopyOS = txtGonioscopyOS.Text;
        ObjDC.P_PanchyneteryOD = txtPanchyneteryOD.Text;
        ObjDC.P_PanchyneteryOS = txtPanchyneteryOS.Text;
        ObjDC.P_IOPCorrectionOD = txtIOPCorrectionOD.Text;
        ObjDC.P_IOPCorrectionOS = txtIOPCorrectionOS.Text;

        ObjDC.P_TopographyOD = txtTopographyOD.Text;
        ObjDC.P_TopographyOS = txtTopographyOS.Text;
        ObjDC.P_IOLMasterOD = txtIOLMasterOD.Text;
        ObjDC.P_IOLMasterOS = txtIOLMasterOS.Text;
        ObjDC.P_KINAXOD = txtKINAXOD.Text;
        ObjDC.P_KINAXOS = txtKINAXOS.Text;

        ObjDC.P_KININOD = txtKININOD.Text;
        ObjDC.P_KININOS = txtKININOS.Text;
        ObjDC.P_AXILLengthOD = txtAXILLengthOD.Text;
        ObjDC.P_AXILLengthOS = txtAXILLengthOS.Text;


        ObjDC.Insert_Optha_FaceExamination_Clinic();
        ShowMessage("Record save successfully", MessageType.Success);
        Get_All_Data(Convert.ToInt32(Session["EmrRegNo"]));
    }
    protected void btnreport_Click(object sender, EventArgs e)
    {

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
            using (SqlCommand cmd = new SqlCommand("usp_Get_Face_Examinationp", con))
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

                //txtEntryDate.Text = Convert.ToString(dt.Rows[0]["ARDate"]);

                ObjDC.P_OcularOD = txtOcularOD.Text = Convert.ToString(dt.Rows[0]["OcularOD"]);
                ObjDC.P_OcularOS = txtOcularOS.Text = Convert.ToString(dt.Rows[0]["OcularOS"]);
                ObjDC.P_LidsOD = txtLidsandAdenexaOD.Text = Convert.ToString(dt.Rows[0]["LidsOD"]);
                ObjDC.P_LidsOS = txtLidsandAdenexaOS.Text = Convert.ToString(dt.Rows[0]["LidsOS"]);
                ObjDC.P_NasolacrinalOD = txtNasolacrinalOD.Text = Convert.ToString(dt.Rows[0]["NasolacrinalOD"]);
                ObjDC.P_NasolacrinalOS = txtNasolacrinalOS.Text = Convert.ToString(dt.Rows[0]["NasolacrinalOS"]);
                ObjDC.P_SyringingOD = txtSyringingOD.Text = Convert.ToString(dt.Rows[0]["SyringingOD"]);
                ObjDC.P_SyringingOS = txtSyringingOS.Text = Convert.ToString(dt.Rows[0]["SyringingOS"]);
                ObjDC.P_CenjunctivaOD = txtCenjunctivaOD.Text = Convert.ToString(dt.Rows[0]["CenjunctivaOD"]);
                ObjDC.P_CenjunctivaOS = txtCenjunctivaOS.Text = Convert.ToString(dt.Rows[0]["CenjunctivaOS"]);
                ObjDC.P_CorneaOD = txtCorneaOD.Text = Convert.ToString(dt.Rows[0]["CorneaOD"]);
                ObjDC.P_CorneaOS = txtCorneaOS.Text = Convert.ToString(dt.Rows[0]["CorneaOS"]);

                ObjDC.P_IrisOD = txtIrisOD.Text = Convert.ToString(dt.Rows[0]["IrisOD"]);
                ObjDC.P_IrisOS = txtIrisOS.Text = Convert.ToString(dt.Rows[0]["IrisOS"]);
                ObjDC.P_PupilOD = txtPupilOD.Text = Convert.ToString(dt.Rows[0]["PupilOD"]);
                ObjDC.P_PupilOS = txtPupilOS.Text = Convert.ToString(dt.Rows[0]["PupilOS"]);

                ObjDC.P_LensOD = txtLensOD.Text = Convert.ToString(dt.Rows[0]["LensOD"]);
                ObjDC.P_LensOS = txtLensOS.Text = Convert.ToString(dt.Rows[0]["LensOS"]);
                ObjDC.P_VitreousOD = txtVitreousOD.Text = Convert.ToString(dt.Rows[0]["VitreousOD"]);
                ObjDC.P_VitreousOS = txtVitreousOS.Text = Convert.ToString(dt.Rows[0]["VitreousOS"]);
                ObjDC.P_OptisDiscOD = txtOptisDiscOD.Text = Convert.ToString(dt.Rows[0]["OptisDiscOD"]);
                ObjDC.P_OptisDiscOS = txtOptisDiscOS.Text = Convert.ToString(dt.Rows[0]["OptisDiscOS"]);
                ObjDC.P_COROD = txtCOROD.Text = Convert.ToString(dt.Rows[0]["COROD"]);
                ObjDC.P_COROS = txtCOROS.Text = Convert.ToString(dt.Rows[0]["COROS"]);
                ObjDC.P_FUNDUSOD = txtFUNDUSOD.Text = Convert.ToString(dt.Rows[0]["COROS"]);
                ObjDC.P_FUNDUSOS = txtFUNDUSOS.Text = Convert.ToString(dt.Rows[0]["FUNDUSOD"]);
                ObjDC.P_VESSELSOD = txtVESSELSOD.Text = Convert.ToString(dt.Rows[0]["VESSELSOD"]);
                ObjDC.P_VESSELSOS = txtVESSELSOS.Text = Convert.ToString(dt.Rows[0]["VESSELSOS"]);
                ObjDC.P_MACULAOD = txtMACULAOD.Text = Convert.ToString(dt.Rows[0]["MACULAOD"]);
                ObjDC.P_MACULAOS = txtMACULAOS.Text = Convert.ToString(dt.Rows[0]["MACULAOS"]);

                ObjDC.P_PERIPHERYOD = txtPERIPHERYOD.Text = Convert.ToString(dt.Rows[0]["PERIPHERYOD"]);
                ObjDC.P_PERIPHERYOS = txtPERIPHERYOS.Text = Convert.ToString(dt.Rows[0]["PERIPHERYOS"]);
                ObjDC.P_Diagnosis = txtdiagnosis.Text = Convert.ToString(dt.Rows[0]["Diagnosis"]);
                ObjDC.P_Plans = txtPlan.Text = Convert.ToString(dt.Rows[0]["Plans"]);
                ObjDC.P_Discussion = txtDiscussion.Text = Convert.ToString(dt.Rows[0]["Discussion"]);
                ObjDC.P_Treatment = txtTreatment.Text = Convert.ToString(dt.Rows[0]["Treatment"]);

                ObjDC.P_GonioscopyOD = txtGonioscopyOD.Text = Convert.ToString(dt.Rows[0]["GonioscopyOD"]);
                ObjDC.P_GonioscopyOS = txtGonioscopyOS.Text = Convert.ToString(dt.Rows[0]["GonioscopyOS"]);
                ObjDC.P_PanchyneteryOD = txtPanchyneteryOD.Text = Convert.ToString(dt.Rows[0]["PanchyneteryOD"]);
                ObjDC.P_PanchyneteryOS = txtPanchyneteryOS.Text = Convert.ToString(dt.Rows[0]["PanchyneteryOS"]);
                ObjDC.P_IOPCorrectionOD = txtIOPCorrectionOD.Text = Convert.ToString(dt.Rows[0]["IOPCorrectionOD"]);
                ObjDC.P_IOPCorrectionOS = txtIOPCorrectionOS.Text = Convert.ToString(dt.Rows[0]["IOPCorrectionOS"]);

                ObjDC.P_TopographyOD = txtTopographyOD.Text = Convert.ToString(dt.Rows[0]["TopographyOD"]);
                ObjDC.P_TopographyOS = txtTopographyOS.Text = Convert.ToString(dt.Rows[0]["TopographyOS"]);
                ObjDC.P_IOLMasterOD = txtIOLMasterOD.Text = Convert.ToString(dt.Rows[0]["IOLMasterOD"]);
                ObjDC.P_IOLMasterOS = txtIOLMasterOS.Text = Convert.ToString(dt.Rows[0]["IOLMasterOS"]);
                ObjDC.P_KINAXOD = txtKINAXOD.Text = Convert.ToString(dt.Rows[0]["KINAXOD"]);
                ObjDC.P_KINAXOS = txtKINAXOS.Text = Convert.ToString(dt.Rows[0]["KINAXOS"]);

                ObjDC.P_KININOD = txtKININOD.Text = Convert.ToString(dt.Rows[0]["KININOD"]);
                ObjDC.P_KININOS = txtKININOS.Text = Convert.ToString(dt.Rows[0]["KININOS"]);
                ObjDC.P_AXILLengthOD = txtAXILLengthOD.Text = Convert.ToString(dt.Rows[0]["AXILLengthOD"]);
                ObjDC.P_AXILLengthOS = txtAXILLengthOS.Text = Convert.ToString(dt.Rows[0]["AXILLengthOS"]);



            }


        }
    }
    
}