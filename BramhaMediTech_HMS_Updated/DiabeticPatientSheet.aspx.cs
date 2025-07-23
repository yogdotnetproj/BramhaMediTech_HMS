using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class DiabeticPatientSheet : System.Web.UI.Page
{
    clsEmr obj = new clsEmr();
    clsTreatment objTreat = new clsTreatment();
    clsTreatmentTransaction transaction = new clsTreatmentTransaction();
    BELIntakeOutputChart objBELIO = new BELIntakeOutputChart();
    DALInputOutPutChart objDALIO = new DALInputOutPutChart();
    DALOpdReg objDALOpdReg = new DALOpdReg();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if (Session["EmrRegNo"] != "")
            {
                string regId = Convert.ToString(Session["EmrRegNo"]);
                string name = Request.QueryString["Name"];
                string opd = Convert.ToString(Session["EmrOpdNo"]);
                string entrydate = Request.QueryString["EntryDate"];
                int IpdId = Convert.ToInt32(Session["EmrIpdNo"]);
                objBELIO.FId = Convert.ToInt32(Session["FId"]);
                objBELIO.BranchId = Convert.ToInt32(Session["Branchid"]);
                lblOpd.Text = opd;
                DateTime time = DateTime.Now;
                txttimestart.Text = DateTime.Now.ToString("dd/MM/yyyy");
                String s = time.ToString("hh:mm tt");
                txtTime.Text = s;
                BindPatientInformation();
                txtNurse.Text = Convert.ToString(Session["Name"]);
                LoadConsultantDoc();
                BindDailyNurseNotes();
            }
        }
    }
    [WebMethod]
    public static List<string> GetDrugsName(string prefixText)
    {
        clsTreatment objj = new clsTreatment();
        DataTable dt = objj.GetDrugsMaster1(prefixText);
        List<string> list = new List<string>();

        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["ItemName"] != DBNull.Value)
                    {
                        list.Add(Convert.ToString(dt.Rows[i]["ItemName"]));
                    }
                }
            }
        }

        return list;
    }

    public void BindDailyNurseNotes()
    {
        DataTable dt = new DataTable();
        objBELIO.Patregid = Convert.ToInt32(Session["EmrRegNo"]);
        objBELIO.OpdNo = Convert.ToInt32(Session["EmrOpdNo"]);
        string entrydate = Request.QueryString["EntryDate"];
        objBELIO.IpdNo = Convert.ToInt32(Session["EmrIpdNo"]);
        objBELIO.FId = Convert.ToInt32(Session["FId"]);
        objBELIO.BranchId = Convert.ToInt32(Session["Branchid"]);
        dt = objDALIO.FillDiabeticSheet(objBELIO);
        gvDailyNurseNote.DataSource = dt;
        gvDailyNurseNote.DataBind();
    }
    public void BindPatientInformation()
    {
        DataTable dt = new DataTable();
        dt = obj.Get_AllPatientInformation(Convert.ToString(Session["EmrRegNo"]), Convert.ToString(Session["EmrOpdNo"]), Convert.ToInt32(Session["EmrIpdNo"]), Convert.ToInt32(Session["Branchid"]));
        try
        {
            if (dt != null)
            {
                lblPatientName.Text = Convert.ToString(dt.Rows[0]["PatientName"]);
                txtpatientregid.Text = Convert.ToString(dt.Rows[0]["PatRegId"]);
                lblIpd.Text = Convert.ToString(dt.Rows[0]["Ipdno"]);
                lblOpd.Text = Convert.ToString(dt.Rows[0]["Opdno"]);
                lblMobileNo.Text = Convert.ToString(dt.Rows[0]["MobileNo"]);
                lbldrname.Text = Convert.ToString(dt.Rows[0]["DrName"]);
                lblAge.Text = Convert.ToString(dt.Rows[0]["Age"]) + "" + Convert.ToString(dt.Rows[0]["AgeType"]) + "/" + Convert.ToString(dt.Rows[0]["GenderName"]);
                ViewState["Age"] = Convert.ToString(dt.Rows[0]["Age"]);
                ViewState["AgeType"] = Convert.ToString(dt.Rows[0]["AgeType"]);
                ViewState["DrId"] = Convert.ToString(dt.Rows[0]["DrId"]);

            }
            dt = new DataTable();
            dt = obj.Get_AllPatientVitalTaken(Convert.ToString(Session["EmrRegNo"]), Convert.ToString(Session["EmrOpdNo"]), Convert.ToInt32(Session["EmrIpdNo"]), Convert.ToInt32(Session["Branchid"]));
            if (dt.Rows.Count > 0)
            {
                lblvtaken.Text = Convert.ToString(dt.Rows[0]["CreatedOn"]);
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        //if (validation() == true)
        //{

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
        objBELIO.CreatedBy = Convert.ToString(Session["username"]);
        objBELIO.UpdatedBy = Convert.ToString(Session["username"]);
        objBELIO.FId = Convert.ToInt32(Session["FId"]); ;
        objBELIO.BranchId = Convert.ToInt32(Session["Branchid"]);
        objBELIO.DrId = Convert.ToInt32(ViewState["DrId"]);
        objBELIO.DateInput = Convert.ToDateTime(txttimestart.Text);
        objBELIO.TimeInput = Convert.ToString(txtTime.Text);
        objBELIO.Remark = Convert.ToString(txtRemark.InnerText);
        objBELIO.UserId = Convert.ToInt32(Session["UserId"]);
        objBELIO.Value = Convert.ToSingle(txtQty.Text);
        objBELIO.ActionTaken = Convert.ToString(txtAction.Value);
        objBELIO.InformToDr = Convert.ToInt32(ddlInformedTo.SelectedValue);
        objBELIO.FastingType = Convert.ToString(ddlFastingType.SelectedValue);
        //objBELIO.DrugId = Convert.ToInt32(ViewState["DrugId"]);
        //objBELIO.DrugName = Convert.ToString(txtDrugName.Text);
       // objBELIO.Qty = Convert.ToSingle(txtQty.Text);

        string Msg;
        if (Convert.ToInt32(ViewState["DiabeticSheetId"]) > 0)
        {
            objBELIO.DiabeticSheetId = Convert.ToInt32(ViewState["DiabeticSheetId"]);
            Msg = objDALIO.UpdateDiabeticSheet(objBELIO);
            ViewState["DiabeticSheetId"] = "0";
        }
        else
        {
            Msg = objDALIO.InsertDiabeticSheet(objBELIO);
        }

        BindDailyNurseNotes();

        btnReset_Click(null, null);
        txtRemark.InnerText = "";
        DateTime time = DateTime.Now;
        txttimestart.Text = DateTime.Now.ToString("dd/MM/yyyy");
        String s = time.ToString("hh:mm tt");
        txtTime.Text = s;
        LblMSg.Text = Msg;
        LblMSg.ForeColor = System.Drawing.Color.Green;



        //}
        //}
    }
    protected void gvDailyNurseNote_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string DiabeticSheetId = (gvDailyNurseNote.DataKeys[e.RowIndex]["DiabeticSheetId"].ToString());


        string Message = objDALIO.DeleteDiabeticSheet(Convert.ToInt32(DiabeticSheetId));
        LblMSg.Text = Message;
        LblMSg.ForeColor = System.Drawing.Color.Green;
        BindDailyNurseNotes();


    }
    protected void gvDailyNurseNote_RowEditing(object sender, GridViewEditEventArgs e)
    {

        try
        {
            string DiabeticSheetId = (gvDailyNurseNote.DataKeys[e.NewEditIndex]["DiabeticSheetId"].ToString());
            ViewState["DiabeticSheetId"] = DiabeticSheetId;
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
        objBELIO = objDALIO.SelectDiabeticSheet(Convert.ToInt32(ViewState["DiabeticSheetId"]));
        txttimestart.Text = Convert.ToDateTime(objBELIO.DateInput).ToString("dd/MM/yyyy");
        txtTime.Text = Convert.ToString(objBELIO.TimeInput);
        txtRemark.InnerText = objBELIO.Remark;
        txtNurse.Text = objBELIO.UserName;
        int UserId = Convert.ToInt32(objBELIO.UserId);
        txtQty.Text = Convert.ToString(objBELIO.Value);
        txtAction.InnerText = objBELIO.ActionTaken;
        ddlFastingType.SelectedValue = Convert.ToString(objBELIO.FastingType);
        ddlInformedTo.SelectedValue = Convert.ToString(objBELIO.InformToDr);
       
       // txtDrugName.Text = Convert.ToString(objBELIO.DrugName);
       // ViewState["DrugId"] = Convert.ToInt32(objBELIO.DrugId);

    }

    protected void gvDailyNurseNote_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDailyNurseNote.PageIndex = e.NewPageIndex;
        BindDailyNurseNotes();
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtRemark.InnerText = "";
        DateTime time = DateTime.Now;
        txttimestart.Text = DateTime.Now.ToString("dd/MM/yyyy");
        String s = time.ToString("hh:mm tt");
        txtTime.Text = s;
        txtQty.Text = "0";
      //  txtDrugName.Text = "";
        ViewState["DrugId"] = "0";
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
        objDALIO.Alter_Vw_DiabeticSheet(objBELIO);
        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Report/Rpt_DiabeticSheet.rpt");
        Session["reportname"] = "Rpt_DiabeticSheet";
        Session["RPTFORMAT"] = "pdf";

        //ReportParameterClass.SelectionFormula = sql;
        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);
    }
    //protected void txtDrugName_TextChanged(object sender, EventArgs e)
    //{
    //    if (txtDrugName.Text != "")
    //    {
    //        string[] Item = txtDrugName.Text.Split('=');
    //        if (txtDrugName.Text.Split('=').Length < 2)
    //        {
    //            ViewState["ItemId"] = "0";
    //        }
    //        else
    //        {
    //            txtDrugName.Text = Item[1];
    //            ViewState["ItemId"] = Item[0];
    //        }
    //    }
    //    else
    //    {
    //        ViewState["ItemId"] = "0";
    //    }
    //}
    private void LoadConsultantDoc()
    {

        //ddlConsultantDoc.DataSource = objDALOpdReg.FillConsultantDocName();
        //ddlConsultantDoc.DataValueField = "DrId";
        //ddlConsultantDoc.DataTextField = "EmpName";
        //ddlConsultantDoc.DataBind();

        ddlInformedTo.DataSource = objDALOpdReg.FillConsultantDocName();
        ddlInformedTo.DataValueField = "DrId";
        ddlInformedTo.DataTextField = "EmpName";
        ddlInformedTo.DataBind();
    }

   
}