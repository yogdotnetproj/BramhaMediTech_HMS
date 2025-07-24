using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmDoctorSchedule2 : BasePage
{
    clsDocSche obj = new clsDocSche();
    clsDocSchedule objs = new clsDocSchedule();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            txtStartDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtEndDate.Text = DateTime.Now.AddDays(7).ToString("dd/MM/yyyy");
            DateTime currentTime = DateTime.Now;
            txtStartTime.Text = currentTime.ToString("HH:mm tt");
            txtEndTime.Text = currentTime.AddMinutes(30).ToString("HH:mm tt");
            BindDoctors();
            BindGrid(0);
        }
    }

    private void BindGrid(int docId)
    {
        DataTable dt = obj.GetDocSchedule(docId);
        gvTempTable.DataSource = dt;
        gvTempTable.DataBind();
    }

    public void GetDocScheduleList(string docId)
    {
        List<clsDocSchedule> listS = new List<clsDocSchedule>();

        //DataTable dt = obj.GetDocSchedule(docId);
        try
        {
            //if (dt != null)
            //{
            //    if (dt.Rows.Count > 0)
            //    {
            //        for (int i = 0; i < dt.Rows.Count; i++)
            //        {
            //            listS.Add(new clsDocSchedule()
            //            {
            //                DoctorId = dt.Rows[i]["DoctorId"].ToString(),
            //                Date1 = dt.Rows[i]["StartDate"].ToString(),
            //                Date2 = dt.Rows[i]["EndDate"].ToString(),
            //                Time1 = dt.Rows[i]["StartTime"].ToString(),
            //                Time2 = dt.Rows[i]["EndTime"].ToString(),
            //                Slot = dt.Rows[i]["Slot"].ToString()
            //            });
            //        }

            //    }
            //}
        }
        catch (Exception)
        {
        }
    }


    private void BindDoctors()
    {
        doctorNames.DataSource = obj.ReadDataDocList();
        doctorNames.DataValueField = "DoctorId";
        doctorNames.DataTextField = "DoctorName";
        doctorNames.DataBind();
        doctorNames.Items.Insert(0, new ListItem("--Select--", "-1"));
        doctorNames.SelectedIndex = 0;
    }

    protected void doctorNames_SelectedIndexChanged(object sender, EventArgs e)
    {
        int docId = doctorNames.SelectedIndex > 0 ? Convert.ToInt32(doctorNames.SelectedItem.Value) : 0;
        BindGrid(docId);
    }

    protected void txtSlot_TextChanged(object sender, EventArgs e)
    {

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string stTime = DateTime.Now.ToString();
            string enTime = DateTime.Now.AddMinutes(30).ToString();
            string stDate = txtStartDate.Text.ToString();
            string enDate = txtEndDate.Text.ToString();
            string docId = doctorNames.SelectedIndex.ToString();
            string slot = txtSlot.Text.ToString();
            string note = txtNote.Text.ToString();
            string type = (string.IsNullOrEmpty(txtSchId.Value) || txtSchId.Value == "0") ? "1" : "2";

            int res = obj.SaveDocSchedule(type: type, date1: stDate, date2: enDate,docId:docId, time1: stTime, 
                time2: enTime,slotId:slot, schId: txtSchId.Value.ToString(), note:note);

            if (res > 0)
            {
                string msg = type == "1" ? "Saved successfully." : "Updated successfully.";
                SuccessMessage(msg);
                ClearFields();
                gvTempTable.EditIndex = -1;
                BindGrid(0);
                btnSave.Text = "Save";
            }
            else
            {
                string msg = type == "-1" ? "Date and time not available" : "Failed to save";
                ErrorMessage(msg);
            }
        }
        catch (Exception)
        {
            ErrorMessage("Error occurred.");

        }
    }

    private void ClearFields()
    {
        //doctorNames.SelectedIndex = -1;
        txtStartDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        txtEndDate.Text = DateTime.Now.AddDays(7).ToString("dd/MM/yyyy");
        DateTime currentTime = DateTime.Now;
        txtStartTime.Text = currentTime.ToString("HH:mm tt");
        txtEndTime.Text = currentTime.AddMinutes(30).ToString("HH:mm tt");
        txtNote.Text = "";
    }

    protected void gvTempTable_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string scId = e.Keys[0].ToString();

        if (obj.DeleteOtSchedule(scId) > 0)
        {
            SuccessMessage("Record deleted successfully.");
            int id = doctorNames.SelectedIndex;
            BindGrid(id);
        }
        else
        {
            ErrorMessage("Could not delete.");
        }
    }

    protected void gvTempTable_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "Edit")
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvTempTable.Rows[rowIndex];
            var x = gvTempTable.DataKeys;
           
            string docId = gvTempTable.Rows[rowIndex].Cells[6].Text;
            string stDate = gvTempTable.Rows[rowIndex].Cells[2].Text;
            string enDate = gvTempTable.Rows[rowIndex].Cells[3].Text;
            string stTime = gvTempTable.Rows[rowIndex].Cells[4].Text;
            string enTime = gvTempTable.Rows[rowIndex].Cells[5].Text;
            string note = gvTempTable.Rows[rowIndex].Cells[7].Text;
            txtSchId.Value = x[rowIndex].Value.ToString();

            txtStartTime.Text = stTime;
            txtEndTime.Text = enTime;
            txtStartDate.Text = stDate;
            txtEndDate.Text = enDate;
            doctorNames.SelectedIndex = doctorNames.Items.IndexOf(doctorNames.Items.FindByValue(docId));
            //txtSlot.Text = slot;
            txtNote.Text = note;
            btnSave.Text = "Update";
            gvTempTable.EditIndex = -1;
        }
        else if (e.CommandName == "Delete")
        {

        }
    }

    protected void gvTempTable_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }

    protected void gvTempTable_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvTempTable.PageIndex = e.NewPageIndex;
        int docId = doctorNames.SelectedIndex > 0 ? Convert.ToInt32(doctorNames.SelectedItem.Value) : 0;
        BindGrid(docId);
    }

    private void ErrorMessage(string msg)
    {
        lblMsg.Text = msg; lblMsg.Visible = true; lblMsg.ForeColor = System.Drawing.Color.Red;
    }

    private void SuccessMessage(string msg)
    {
        lblMsg.Text = msg; lblMsg.Visible = true; lblMsg.ForeColor = System.Drawing.Color.Green;
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        ClearFields();
    }
}