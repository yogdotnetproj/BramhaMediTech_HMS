using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

public partial class IntakeOutputSheet : System.Web.UI.Page
{
    clsEmr obj = new clsEmr();
    clsTreatment objTreat = new clsTreatment();
    clsTreatmentTransaction transaction = new clsTreatmentTransaction();
    DataTable tempDatatable = new DataTable();
    
    BELIntakeOutputChart objBELIO = new BELIntakeOutputChart();
    DALInputOutPutChart objDALIO= new DALInputOutPutChart();
    double OralSolidIntake = 0;
    double OtherSolidIntake = 0;
    double OralLiquidIntake = 0;
    double OtherLiquidIntake = 0;
    double BloodIntake = 0;
    double IVIntake = 0;
    double RTF = 0;

    double Vomit = 0;
    double urine = 0;
    double OtherOutput = 0;
    double RTA = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if (Session["EmrRegNo"] != "")
            {
                if (Convert.ToString(Session["Branchid"]) == "")
                {
                    Response.Redirect("~/Login.aspx", false);
                    return;
                }
                if (Convert.ToString(Session["Branchid"]) == "0")
                {
                    Response.Redirect("~/Login.aspx", false);
                    return;
                }
                if (Convert.ToString(Session["Branchid"]) == null)
                {
                    Response.Redirect("~/Login.aspx", false);
                    return;
                }
                string regId = Convert.ToString(Session["EmrRegNo"]);
                string name = Request.QueryString["Name"];
                string opd = Convert.ToString(Session["EmrOpdNo"]);
                string entrydate = Request.QueryString["EntryDate"];
                int IpdId = Convert.ToInt32(Session["EmrIpdNo"]);
                objBELIO.FId = Convert.ToInt32(Session["FId"]);
                objBELIO.BranchId = Convert.ToInt32(Session["Branchid"]);
               // lblOpd.Text = opd;
                DateTime time = DateTime.Now;
                txttimestart.Text = DateTime.Now.ToString("dd/MM/yyyy");
                String s = time.ToString("hh:mm tt");
                txtTime.Text = s;
                ddlOralType_SelectedIndexChanged(null,null);
                ddlotherType_SelectedIndexChanged(null,null);
                BindPatientInformation();
                BindInputOutputChart();
                txttimestart.Enabled = false;
                txtTime.Enabled = false;
            }
          
        }
    }

    public void BindInputOutputChart()
    {
        DataTable dt = new DataTable();
        objBELIO.Patregid = Convert.ToInt32(Session["EmrRegNo"]);
        objBELIO.OpdNo = Convert.ToInt32(Session["EmrOpdNo"]);
        string entrydate = Request.QueryString["EntryDate"];
        objBELIO.IpdNo = Convert.ToInt32(Session["EmrIpdNo"]);
        objBELIO.FId = Convert.ToInt32(Session["FId"]);
        objBELIO.BranchId = Convert.ToInt32(Session["Branchid"]);
        dt = objDALIO.FillInputOutputGrid(objBELIO);
        gvIntakeOP.DataSource = dt;
        gvIntakeOP.DataBind();
    }
    public void BindPatientInformation()
    {
        //DataTable dt = new DataTable();
        //dt = obj.Get_AllPatientInformation(Convert.ToString(Session["EmrRegNo"]), Convert.ToString(Session["EmrOpdNo"]), Convert.ToInt32(Session["EmrIpdNo"]), Convert.ToInt32(Session["Branchid"]));
        //try
        //{
        //    if (dt != null)
        //    {
        //        lblPatientName.Text = Convert.ToString(dt.Rows[0]["PatientName"]);
        //        txtpatientregid.Text = Convert.ToString(dt.Rows[0]["PatRegId"]);
        //        lblIpd.Text = Convert.ToString(dt.Rows[0]["Ipdno"]);
        //        lblOpd.Text = Convert.ToString(dt.Rows[0]["Opdno"]);
        //        lblMobileNo.Text = Convert.ToString(dt.Rows[0]["MobileNo"]);
        //        lbldrname.Text = Convert.ToString(dt.Rows[0]["DrName"]);
        //        lblAge.Text = Convert.ToString(dt.Rows[0]["Age"]) + "" + Convert.ToString(dt.Rows[0]["AgeType"]) + "/" + Convert.ToString(dt.Rows[0]["GenderName"]);
        //        ViewState["Age"] = Convert.ToString(dt.Rows[0]["Age"]);
        //        ViewState["AgeType"] = Convert.ToString(dt.Rows[0]["AgeType"]);
        //        ViewState["DrId"] = Convert.ToString(dt.Rows[0]["DrId"]);

        //    }
        //    dt = new DataTable();
        //    dt = obj.Get_AllPatientVitalTaken(Convert.ToString(Session["EmrRegNo"]), Convert.ToString(Session["EmrOpdNo"]), Convert.ToInt32(Session["EmrIpdNo"]), Convert.ToInt32(Session["Branchid"]));
        //    if (dt.Rows.Count > 0)
        //    {
        //        lblvtaken.Text = Convert.ToString(dt.Rows[0]["CreatedOn"]);
        //    }
        //}
        //catch (Exception ex)
        //{

        //}
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        //if (validation() == true)
        //{
        if (Convert.ToString(Session["Branchid"]) == "")
        {
            Response.Redirect("~/Login.aspx", false);
            return;
        }
        if (Convert.ToString(Session["Branchid"]) == "0")
        {
            Response.Redirect("~/Login.aspx", false);
            return;
        }
        if (Convert.ToString(Session["Branchid"]) == null)
        {
            Response.Redirect("~/Login.aspx", false);
            return;
        }
            if (Convert.ToString(Session["EmrOpdNo"]) != "")
            {
                objBELIO.OpdNo = Convert.ToInt32(Session["EmrOpdNo"]);
            }
            else
            {
                objBELIO.OpdNo = 0;
            }
            if (Convert.ToString(Session["EmrIpdNo"]) != "")
            {
                objBELIO.IpdNo = Convert.ToInt32(Session["EmrIpdNo"]);
                if (Convert.ToString(Session["PatAdmit"]) == "No")
                {
                    LblMSg.ForeColor = System.Drawing.Color.Red;
                    LblMSg.Text = "Patient already discharge!";
                    return;
                }
            }
            else
            {
                objBELIO.IpdNo = 0;
            }
            objBELIO.Patregid = Convert.ToInt32(Session["EmrRegNo"]);
            objBELIO.CreatedBy = Convert.ToString(Session["username"]);
            objBELIO.UpdatedBy = Convert.ToString(Session["username"]);
            objBELIO.FId = Convert.ToInt32(Session["FId"]); ;
            objBELIO.BranchId = Convert.ToInt32(Session["Branchid"]);

            objBELIO.DrId = Convert.ToInt32(ViewState["DrId"]);

            objBELIO.DateInput = Convert.ToDateTime(txttimestart.Text);
            objBELIO.TimeInput = Convert.ToString(txtTime.Text);

            objBELIO.TypeOfOralIntake = Convert.ToString(ddlOralType.SelectedValue);
            objBELIO.OralIntakeQty = (float)Math.Round(Convert.ToSingle(txtOralIntake.Text),2);
            objBELIO.OralIntakeUnit = Convert.ToString(ddlUnitOral.SelectedValue);
            objBELIO.BloodIntake = (float)Math.Round(Convert.ToSingle(txtBloodIntake.Text),2);

            objBELIO.IVIntake = (float)Math.Round(Convert.ToSingle(txtIV.Text),2);
            objBELIO.OtherIntake = (float)Math.Round(Convert.ToSingle(txtOtherIntake.Text),2);
            objBELIO.OtherIntakeType = Convert.ToString(ddlotherType.SelectedValue);
            objBELIO.OtherIntakeUnit = Convert.ToString(ddlOtherUnit.SelectedValue);
            objBELIO.RTF = (float)Math.Round(Convert.ToSingle(txtRTF.Text),2);
            objBELIO.Remark = Convert.ToString(txtRemark.InnerText);


            objBELIO.VomitOutPut =(float)Math.Round(Convert.ToSingle(txtVomit.Text),2);
            objBELIO.VomitUnit = Convert.ToString(ddlvomit.SelectedValue);
            objBELIO.UrineOutPut =(float)Math.Round(Convert.ToSingle(txtUrine.Text),2);
            objBELIO.UrineUnit = Convert.ToString(ddlUrine.SelectedValue);
            objBELIO.OtherOutput = (float)Math.Round(Convert.ToSingle(txtOtherOP.Text),2);
            objBELIO.OtherOutputUnit = Convert.ToString(ddlOtherOP.Text);
            objBELIO.RTA = (float)Math.Round(Convert.ToSingle(txtRTA.Text),2);
            objBELIO.Bowel = Convert.ToString(ddlbowel.SelectedValue);

            //objBELIO.SolidInput = Convert.ToSingle(txtSolidIP.Text);
            //objBELIO.SolidOutput = Convert.ToSingle(txtSolidOP.Text);
            //objBELIO.SolidBalance = Convert.ToSingle(txtSolidbalance.Text);
            //objBELIO.LiquidInput = Convert.ToSingle(txtLiquidInput.Text);
            //objBELIO.LiquidOutput = Convert.ToSingle(txtLiquidOutPut.Text);
            //objBELIO.LiquidBalance = Convert.ToSingle(txtbalance.Text);
            string Msg;
            if (Convert.ToInt32(ViewState["IOId"]) > 0)
            {
                objBELIO.IOId = Convert.ToInt32(ViewState["IOId"]);
                Msg = objDALIO.UpdateInputOutputChart(objBELIO);
                ViewState["IOId"] = "0";
            }
            else
            {
                Msg = objDALIO.InsertInputOutputChart(objBELIO);
            }
            BindInputOutputChart();
           

            LblMSg.Text = Msg;
            LblMSg.ForeColor = System.Drawing.Color.Green;



        //}
        //}
    }
    protected void gvIntakeOP_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string IOId = (gvIntakeOP.DataKeys[e.RowIndex]["IOId"].ToString());


        string Message = objDALIO.DeleteInputOutput(Convert.ToInt32(IOId));
        LblMSg.Text = Message;
        LblMSg.ForeColor = System.Drawing.Color.Green;
        BindInputOutputChart();

       
    }
    protected void gvIntakeOP_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void gvIntakeOP_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void gvIntakeOP_RowEditing(object sender, GridViewEditEventArgs e)
    {
        
        try
        {   
            string IOId = (gvIntakeOP.DataKeys[e.NewEditIndex]["IOId"].ToString());
            ViewState["IOId"] = IOId;
            txttimestart.Enabled = false;
            txtTime.Enabled = false;
            FillPage();
            e.Cancel = true;
        }
        catch (Exception ex)
        {
            LblMSg.Text = ex.Message;
        }
    }

    public void FillPage()
    {
        objBELIO = objDALIO.SelectInputOutput(Convert.ToInt32(ViewState["IOId"]));
        txttimestart.Text = Convert.ToDateTime(objBELIO.DateInput).ToString("dd/MM/yyyy");
        txtTime.Text = Convert.ToString(objBELIO.TimeInput);
        ddlOralType.SelectedValue = Convert.ToString(objBELIO.TypeOfOralIntake);
        txtOralIntake.Text = Convert.ToString(objBELIO.OralIntakeQty);
        ddlUnitOral.SelectedValue = Convert.ToString(objBELIO.OralIntakeUnit);
        txtBloodIntake.Text = Convert.ToString(objBELIO.BloodIntake);

        txtIV.Text = Convert.ToString(objBELIO.IVIntake);
        txtOtherIntake.Text =Convert.ToString(objBELIO.OtherIntake);
        ddlotherType.SelectedValue = Convert.ToString(objBELIO.OtherIntakeType);
        ddlOtherUnit.SelectedValue = Convert.ToString(objBELIO.OtherIntakeUnit);
        txtRTF.Text = Convert.ToString(objBELIO.RTF);
        txtRemark.InnerText = Convert.ToString(objBELIO.Remark);


        txtVomit.Text = Convert.ToString(objBELIO.VomitOutPut);
        ddlvomit.SelectedValue = Convert.ToString(objBELIO.VomitUnit);
        txtUrine.Text= Convert.ToString(objBELIO.UrineOutPut);
        objBELIO.UrineUnit = Convert.ToString(ddlUrine.SelectedValue);
        txtOtherOP.Text =Convert.ToString(objBELIO.OtherOutput);
        ddlOtherOP.Text = Convert.ToString(objBELIO.OtherOutputUnit);
        txtRTA.Text = Convert.ToString(objBELIO.RTA);
        ddlbowel.SelectedValue = Convert.ToString(objBELIO.Bowel);
    }


    protected void gvIntakeOP_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string OralIntakeType = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "TypeOfOralIntake"));
            if (OralIntakeType == "Solid")
            {

                OralSolidIntake += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "OralIntakeQty"));
            }
            else
            {
                OralLiquidIntake += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "OralIntakeQty"));
            }
            string OtherIntakeType = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "OtherIntakeType"));
            if (OralIntakeType == "Solid")
            {

                OtherSolidIntake += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "OtherIntake"));
            }
            else
            {
                OtherLiquidIntake += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "OtherIntake"));
            }
            BloodIntake += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "BloodIntake"));
            IVIntake += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "IVIntake"));
            RTF += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "RTF"));

            Vomit += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "VomitOutPut"));
            urine += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "UrineOutPut"));
            RTA += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "RTA"));
            OtherOutput += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "OtherOutput"));
            txtSolidIP.Text = Convert.ToString(Math.Round(OralSolidIntake,2) +Math.Round(OtherSolidIntake,2));
            
            txtLiquidInput.Text = Convert.ToString(OtherLiquidIntake + OralLiquidIntake + BloodIntake + RTF + IVIntake);
            txtLiquidOutPut.Text = Convert.ToString(Vomit + urine + RTA + OtherOutput);
            txtSolidbalance.Text=Convert.ToString(Convert.ToDouble(txtSolidIP.Text)-Convert.ToDouble(txtSolidOP.Text));
            txtbalance.Text = Convert.ToString(Convert.ToDouble(txtLiquidInput.Text) - Convert.ToDouble(txtLiquidOutPut.Text));
            
        }
    }
    protected void ddlOralType_SelectedIndexChanged(object sender, EventArgs e)
    {
        
            if (ddlOralType.SelectedValue == "Solid")
            {
                ddlUnitOral.SelectedValue = "Gram";

            }
            else
            {
                ddlUnitOral.SelectedValue = "ML";
            }
       
        
    }
    protected void ddlotherType_SelectedIndexChanged(object sender, EventArgs e)
    {
        
            if (ddlotherType.SelectedValue == "Solid")
            {

                ddlOtherUnit.SelectedValue = "Gram";

            }
            else
            {
                ddlOtherUnit.SelectedValue = "ML";
            }
      
    }
    protected void btnReport_Click(object sender, EventArgs e)
    {
        string sql = "";
        if (Convert.ToString(Session["EmrOpdNo"]) != "")
        {
            objBELIO.OpdNo = Convert.ToInt32(Session["EmrOpdNo"]);
        }
        else
        {
            objBELIO.OpdNo = 0;
        }
        if (Convert.ToString(Session["EmrIpdNo"]) != "")
        {
            objBELIO.IpdNo = Convert.ToInt32(Session["EmrIpdNo"]);
        }
        else
        {
            objBELIO.IpdNo = 0;
        }
        objBELIO.Patregid = Convert.ToInt32(Session["EmrRegNo"]);
        objDALIO.Alter_Vw_IntakeOutputSheet(objBELIO);
        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Report/Rpt_IntakeOutputChart.rpt");
        Session["reportname"] = "Rpt_IntakeOutputChart";
        Session["RPTFORMAT"] = "pdf";

        //ReportParameterClass.SelectionFormula = sql;
        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);
    }
}