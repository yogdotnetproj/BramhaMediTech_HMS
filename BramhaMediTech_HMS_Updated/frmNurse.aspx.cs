using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmNurse : System.Web.UI.Page
{
    clsDocSche objDocSche = new clsDocSche();
    clsData objData = new clsData();
    clsNurse obj = new clsNurse();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            txtStartDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtStartTime.Text = DateTime.Now.ToString("hh:mm tt");
            BindDoctors();
            BindTheatre();
            BindGrid();
        }
    }

    private void BindGrid()
    {
        int docId = doctorNames.SelectedIndex > 0 ? Convert.ToInt32(doctorNames.SelectedItem.Value) : 0;
        DataTable dt = obj.GetRecords(docId);
        gdvNurse.DataSource = dt;
        gdvNurse.DataBind();
    }

    public void BindTheatre()
    {
        DataSet ds = objData.FillOtSelects();
        if (ds != null)
        {
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[2].Rows.Count > 0)
                {
                    drpTheatre.DataSource = ds.Tables[2];
                    drpTheatre.DataValueField = "OTId";
                    drpTheatre.DataTextField = "OTType";
                    drpTheatre.DataBind();
                    drpTheatre.Items.Insert(0, new ListItem("--Select--", "-1"));
                    drpTheatre.SelectedIndex = 0;
                }
            }
        }
    }

    protected void doctorNames_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
    }

    protected void drpTheatre_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string regId = txtpatientregid.Text.ToString();
            string opd = lblOpd.Text.ToString();
            string ipd = lblIpd.Text.ToString();
            string branch = Session["Branchid"].ToString();
            string name = lblPatientName.Text.ToString();
            string entry = lblEntryDate.Text.ToString();
            string stTime = txtStartTime.Text.ToString();
            string duration = drpDuration.SelectedItem.Value.ToString();
            string stDate = txtStartDate.Text.ToString();
            string docId = doctorNames.SelectedItem.Value.ToString();

            string theatre = drpTheatre.SelectedItem.Text.ToString();
            string type = (string.IsNullOrEmpty(txtSchId.Value) || txtSchId.Value == "0") ? "1" : "2";

            int res = obj.SaveNurse(type: type, date1: stDate, docId: docId, time1: stTime,duration:duration,theatre:theatre,
                schId: txtSchId.Value.ToString(),regId:regId, name:name,ipd:ipd,opd:opd,branchId:branch,entrydate:entry);

            if (res > 0)
            {
                string msg = type == "1" ? "Saved successfully." : "Updated successfully.";
                SuccessMessage(msg);
                ClearFields();
                
                BindGrid();
                btnSave.Text = "Save";
            }
            else
            {
                string msg = type == "-1" ? "Date and time not available" : "Failed to save";
                ErrorMessage(msg);
            }
        }
        catch (Exception ex)
        {
            ErrorMessage(ex.Message);
        }
    }

    private void ClearFields()
    {
       
        doctorNames.SelectedIndex = 0;
        drpDuration.SelectedIndex = 0;
        drpTheatre.SelectedIndex = 0;
        txtStartDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        txtStartTime.Text = DateTime.Now.ToString("hh:mm tt");
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        ClearFields();
    }

    protected void gdvNurse_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvNurse.PageIndex = e.NewPageIndex;
        BindGrid();
    }
    private void BindDoctors()
    {
        doctorNames.DataSource = objDocSche.ReadDataDocList();
        doctorNames.DataValueField = "DoctorId";
        doctorNames.DataTextField = "DoctorName";
        doctorNames.DataBind();
        doctorNames.Items.Insert(0, new ListItem("--Select--", "-1"));
        doctorNames.SelectedIndex = 0;
    }
    protected void gdvNurse_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gdvNurse.Rows[rowIndex];
            var x = gdvNurse.DataKeys;

            string docId = gdvNurse.Rows[rowIndex].Cells[5].Text;
            string theatre = gdvNurse.Rows[rowIndex].Cells[1].Text;
            string stDate = gdvNurse.Rows[rowIndex].Cells[2].Text;
            string stTime = gdvNurse.Rows[rowIndex].Cells[3].Text;
            string duration = gdvNurse.Rows[rowIndex].Cells[4].Text;

            txtSchId.Value = x[rowIndex].Value.ToString();

            txtStartTime.Text = stTime;
            txtStartDate.Text = stDate;
            doctorNames.SelectedIndex = doctorNames.Items.IndexOf(doctorNames.Items.FindByValue(docId));
            drpTheatre.SelectedIndex = drpTheatre.Items.IndexOf(drpTheatre.Items.FindByText(theatre));
            drpDuration.SelectedIndex = drpDuration.Items.IndexOf(drpDuration.Items.FindByValue(duration));

            btnSave.Text = "Update";
           
        }
    }

    protected void gdvNurse_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string scId = e.Keys[0].ToString();

        if (obj.DeleteNurse(scId) > 0)
        {
            SuccessMessage("Record deleted successfully.");
            BindGrid();
        }
        else
        {
            ErrorMessage("Could not delete.");
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
    protected void gdvNurse_RowEditing(object sender, GridViewEditEventArgs e)
    {
        e.Cancel = true;
    }
}