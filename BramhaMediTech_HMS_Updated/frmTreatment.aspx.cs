using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmTreatment : BasePage
{
    clsTreatment objTreat = new clsTreatment();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string pId = Request.QueryString["p"];
            string ipd = Request.QueryString["i"];
            string opd = Request.QueryString["o"];
            string branch = Request.QueryString["b"];
            string follow = Request.QueryString["f"];
            string createdBy = !string.IsNullOrEmpty(Convert.ToString(Request.QueryString["cb"]))? Request.QueryString["cb"]:"Sam";
            string createdOn = !string.IsNullOrEmpty(Convert.ToString(Request.QueryString["co"]))? Request.QueryString["co"] :System.DateTime.Now.ToShortDateString();

            
            if (!string.IsNullOrEmpty(Convert.ToString(Request.QueryString["co"])))
            {
                txtTreatId.Value = Request.QueryString["co"];
            }
            else
            {
                txtTreatId.Value = "0";

                txtPatientRegId.ReadOnly = false;
                txtIpd.ReadOnly = false;
                txtOpd.ReadOnly = false;
                txtBranchId.ReadOnly = false;
                txtFollowUp.ReadOnly = false;

            }

            txtPatientRegId.Text = pId;
            txtIpd.Text = ipd;
            txtOpd.Text = opd;
            txtBranchId.Text = branch;
            txtFollowUp.Text = follow;
            ViewState["createdBy"] = createdBy;
            ViewState["createdOn"] = createdOn;

            CalendarExtender1.SelectedDate = System.DateTime.Now;
            CalendarExtender2.SelectedDate = System.DateTime.Now;
            CalendarExtender3.SelectedDate = System.DateTime.Now;

            BindFrequencyDrop();
            BindMainGrid();
        }
    }

    protected void gdvTreatment_PreRender(object sender, EventArgs e)
    {

    }

    protected void gdvTreatment_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvTreatment.PageIndex = e.NewPageIndex;
        BindMainGrid();
    }

    protected void gdvTreatment_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }

    protected void gdvTreatment_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {

    }

    protected void gdvTreatment_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void gdvTreatment_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void drpfrequency_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {        
        int recId = string.IsNullOrEmpty(txtTreatId.Value) ? 0 : Convert.ToInt32(txtTreatId.Value);

        string pId = txtPatientRegId.Text;
        string ipd = txtIpd.Text;
        string opd = txtOpd.Text;
        string branch = txtBranchId.Text;
        string follow = txtFollowUp.Text;

        string drug = txtDrugName.Text;
        string freq = drpfrequency.SelectedItem.Text;
        string days = txtDays.Text;
        string from = txtStart.Text;
        string to = txtEnd.Text;

        if(!string.IsNullOrEmpty(pId) && (!string.IsNullOrEmpty(ipd) || !string.IsNullOrEmpty(opd)) &&
            !string.IsNullOrEmpty(branch) && !string.IsNullOrEmpty(follow))
        {
            objTreat.patientId = pId;
            objTreat.ipd = ipd;
            objTreat.opd = opd;
            objTreat.branchId = branch;
            objTreat.followUp = follow;
            objTreat.createdBy = "Sam"; // Convert.ToString(ViewState["createdBy"]);
            objTreat.createdOn = DateTime.Now.ToShortDateString(); //Convert.ToString(ViewState["createdOn"]);
            objTreat.treatId = recId.ToString();
            objTreat.updatedBy = "Sam";
            objTreat.updatedOn = System.DateTime.Now.ToShortDateString();
        }

        if (recId == 0)
        {
            int res = objTreat.InsertUpdateDeleteMain("Insert");
            if (res > 0)
            {
                lblMsg.Text = "Record inserted successfully.";
                lblMsg.ForeColor = System.Drawing.Color.Green;
                lblMsg.Visible = true;

                btnCancel_Click(null, null);
                gdvTreatment.EditIndex = -1;
            }
            else
            {
                lblMsg.Text = "Failed to insert.";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Visible = true;
            }

        }
        else
        {
            int res = objTreat.InsertUpdateDeleteMain("Update");
            if (res > 0)
            {
                lblMsg.Text = "Record updated successfully.";
                lblMsg.Visible = true;
                lblMsg.ForeColor = System.Drawing.Color.Green;
                btnCancel_Click(null, null);
                gdvTreatment.EditIndex = -1;
            }
            else
            {
                lblMsg.Text = "Failed to update.";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Visible = true;
            }
        }

        BindMainGrid();
    }

    private void BindMainGrid()
    {
        gdvTreatment.DataSource = objTreat.GetTreatmentDetails(null, null, null);
        gdvTreatment.DataBind();
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtTreatId.Value = "0";
        txtDrugName.Text = "";
        drpfrequency.SelectedIndex = -1;
        txtDays.Text = "0";
        CalendarExtender1.SelectedDate = System.DateTime.Now;
        CalendarExtender2.SelectedDate = System.DateTime.Now;
        CalendarExtender3.SelectedDate = System.DateTime.Now;
        txtNote.Text = "";
        //BindMainGrid();
    }

    [System.Web.Script.Services.ScriptMethod()]
    [WebMethod]
    public static List<string> GetDrugsName(string prefixText)
    {
        clsTreatment objj = new clsTreatment();
        DataTable dt = objj.GetDrugsMaster(prefixText,"Drug",0);
        List<string> list = new List<string>();

        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["drug"] != DBNull.Value)
                    {
                        list.Add(Convert.ToString(dt.Rows[i]["drug"]));
                    }
                }
            }
        }

        return list;
    }

    private void BindFrequencyDrop()
    {
        drpfrequency.DataSource = objTreat.GetFrequencyMaster();
        drpfrequency.DataValueField = "FreId";
        drpfrequency.DataTextField = "FreType";
        drpfrequency.DataBind();
        drpfrequency.Items.Insert(0, new ListItem("--Select--", "-1"));
        drpfrequency.SelectedIndex = 0;
    }

    protected void txtDays_TextChanged(object sender, EventArgs e)
    {
        string noOfDaysText = txtDays.Text;
        double noOfDays = 0;

        if (!string.IsNullOrEmpty(noOfDaysText))
        {
            if (noOfDaysText.All(char.IsNumber))
            {
                noOfDays = Convert.ToDouble(noOfDaysText);

                if (noOfDays > 0)
                {
                    CalendarExtender2.SelectedDate = System.DateTime.Now.AddDays(noOfDays);
                }
                else
                {
                    txtDays.Text = "0";
                }
            }
            else
            {
                txtDays.Text = "0";
            }
        }
        else
        {
            txtDays.Text = "0";
        }

        CalendarExtender2.SelectedDate = System.DateTime.Now.AddDays(noOfDays);
    }

    protected void txtStart_TextChanged(object sender, EventArgs e)
    {
        //NoOfDays();
    }

    private int NoOfDays()
    {
        DateTime date1 = Convert.ToDateTime(txtStart.Text);
        DateTime date2 = Convert.ToDateTime(txtEnd.Text);

        System.TimeSpan diffResult = (date2 - date1);

        txtDays.Text = Convert.ToString(diffResult.Days);

        return diffResult.Days;
    }

    protected void txtEnd_TextChanged(object sender, EventArgs e)
    {
        //NoOfDays();
    }
}