
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

public partial class Surgen_Notes :BasePage
{
    clsEmr obj = new clsEmr();

    DataTable dt1 = new DataTable();
    DataTable dt2 = new DataTable();
    DataTable dt3 = new DataTable();

    DataTable dtChief = new DataTable();
    DataTable dtVitals = new DataTable();
    DataTable dtAllergies = new DataTable();
    DataTable dtMedical = new DataTable();
    DataTable dtSurgery = new DataTable();
    DataTable dtPastHis = new DataTable();
    DataTable dtPersHisl = new DataTable();
    DataTable dtFamHis = new DataTable();
    DataTable dtNote = new DataTable();
    DataTable dtDiagno = new DataTable();
    DataTable dtProvDiagno = new DataTable();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if (Session["EmrRegNo"]!="" )
            {
                txtNoteDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txtdateofOperation.Text = DateTime.Now.ToString("dd/MM/yyyy");
               // string regId = Convert.ToString( Session["EmrRegNo"]);
               // string name = Request.QueryString["Name"];
               // string opd =  Convert.ToString( Session["EmrOpdNo"]);
               // string entrydate = Request.QueryString["EntryDate"];
               //// Session["Branchid"] = "1";

               // lblPatientName.Text = name;
               // txtpatientregid.Text = regId;
              
               // lblOpd.Text = opd;
               // PindPatientInformation();



               // GetRecords();
               
            }
            //else
            //{
            //    Response.Redirect(string.Format("IPDListPatients.aspx"));
            //}
            
        }
    }

    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchTemplate(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        return objDALOpdReg.FillAllOperation_Search(prefixText,"");
    }
   

   
    private void GetRadios()
    {
        try
        {
            DataSet ds = obj.ReadDataHistoryList();

            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    dt1 = ds.Tables[0];
                    dt2 = ds.Tables[1];
                    dt3 = ds.Tables[2];
                }
            }
        }
        catch (Exception)
        {
        }
    }

  
    
   
    private void ErrorMessage(string msg)
    {
        lblMsg.Text = msg; lblMsg.Visible = true; lblMsg.ForeColor = System.Drawing.Color.Red;
    }

    private void SuccessMessage(string msg)
    {
        lblMsg.Text = msg; lblMsg.Visible = true; lblMsg.ForeColor = System.Drawing.Color.Green;
    }
   

    

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            //string regId = txtpatientregid.Text.ToString();
            //string opd = !string.IsNullOrEmpty(lblOpd.Text.ToString()) ? lblOpd.Text.ToString() : "0";
            //string ipd = !string.IsNullOrEmpty(lblIpd.Text.ToString()) ? lblIpd.Text.ToString() : "0";
            string branch = Convert.ToString(Session["Branchid"]);
            //string name = lblPatientName.Text.ToString();
            //string entry =  DateTime.Now.ToString("dd/MM/yyyy");

            string createdby = Convert.ToString(Session["username"]); ;
            string createdon = DateTime.Now.ToString("dd/MM/yyyy");
            string updatedby = Convert.ToString(Session["username"]); ;
            string updatedon = DateTime.Now.ToString("dd/MM/yyyy");
           // obj.SaveReferalnoteformatmaster(txtformatname.Text, Editor1.Text, createdby, branch);
                btnSave.Text = "Save";
              
                SuccessMessage("Format Save successfully!.");
               
        }
        catch (Exception ex)
        {
            ErrorMessage(ex.Message);
        }
    }

  

    protected void btnClear_Click(object sender, EventArgs e)
    {
       
    }

    protected void GvOTTemplate_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        
    }
}