using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmOtSchedule :BasePage
{
    clsData obj = new clsData();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtTime.Text = DateTime.Now.ToString("hh:mm ");
            BindLists();
            BindGrid();
        }
    }

    private void BindLists()
    {
        try
        {
            DataSet ds = obj.FillOtSelects();
            #region bind select
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    opCategory.DataSource = ds.Tables[0];
                    opCategory.DataValueField = "OprnCatId";
                    opCategory.DataTextField = "OprnCat";
                    opCategory.DataBind();
                    opCategory.Items.Insert(0, new ListItem("--Select--", "-1"));
                    opCategory.SelectedIndex = 0;
                }

                if (ds.Tables[1].Rows.Count > 0)
                {
                    opName.DataSource = ds.Tables[1];
                    opName.DataValueField = "OprnId";
                    opName.DataTextField = "Oprn";
                    opName.DataBind();
                    opName.Items.Insert(0, new ListItem("--Select--", "-1"));
                    opName.SelectedIndex = 0;
                }

                if (ds.Tables[2].Rows.Count > 0)
                {
                    opTheater.DataSource = ds.Tables[2];
                    opTheater.DataValueField = "OTId";
                    opTheater.DataTextField = "OTType";
                    opTheater.DataBind();
                    opTheater.Items.Insert(0, new ListItem("--Select--", "-1"));
                    opTheater.SelectedIndex = 0;
                }

                if (ds.Tables[3].Rows.Count > 0)
                {
                    drName.DataSource = ds.Tables[3];
                    drName.DataValueField = "CUId";
                    drName.DataTextField = "username";
                    drName.DataBind();
                    drName.Items.Insert(0, new ListItem("--Select--", "-1"));
                    drName.SelectedIndex = 0;
                }

                if (ds.Tables[4].Rows.Count > 0)
                {
                    anName.DataSource = ds.Tables[4];
                    anName.DataValueField = "CUId";
                    anName.DataTextField = "username";
                    anName.DataBind();
                    anName.Items.Insert(0, new ListItem("--Select--", "-1"));
                    anName.SelectedIndex = 0;
                }
            }
            #endregion
        }
        catch (Exception)
        {


        }
    }

    private void BindGrid()
    {
        string patientregid = "";
        DataTable dt = obj.GetOtSche(string.IsNullOrEmpty(patientregid) ? "" : patientregid);
        gvTempTable.DataSource = dt;
        gvTempTable.DataBind();
    }

    //public void GetOtScheduleTotalData()
    //{
    //    List<clsOTSchedule> list = new List<clsOTSchedule>();

    //    string patientregid = "";

    //    try
    //    {
    //        DataTable dt = obj.GetOtSche(string.IsNullOrEmpty(patientregid) ? "" : patientregid);

    //        if (dt != null)
    //        {
    //            //if (dt.Rows.Count > 0)
    //            //{
    //            //    for (int i = 0; i < dt.Rows.Count; i++)
    //            //    {
    //            //        list.Add(new clsOTSchedule()
    //            //        {
    //            //            OpCategory = Convert.ToString(dt.Rows[i]["OpCategory"]),
    //            //            OpName = Convert.ToString(dt.Rows[i]["OpName"]),
    //            //            OpTheater = Convert.ToString(dt.Rows[i]["OpTheater"]),
    //            //            DrName = Convert.ToString(dt.Rows[i]["DrName"]),
    //            //            AnName = Convert.ToString(dt.Rows[i]["AnName"]),
    //            //            OtDate = Convert.ToString(dt.Rows[i]["OtDate"]),
    //            //            OtTime = Convert.ToString(dt.Rows[i]["OtTime"]),
    //            //            PatRegId = Convert.ToString(dt.Rows[i]["PatRegId"]),
    //            //            Opd = Convert.ToString(dt.Rows[i]["Opd"]),
    //            //            Ipd = Convert.ToString(dt.Rows[i]["Ipd"])
    //            //        });
    //            //    }
    //            //}
    //        }
    //    }
    //    catch (Exception)
    //    {


    //    }
    //    //return list;
    //    //JavaScriptSerializer js = new JavaScriptSerializer();
    //    //Context.Response.Write(js.Serialize(list));
    //}

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string regId = txtpatientregid.Text.ToString();
            string opd = lblOpd.Text.ToString();
            string ipd = lblIpd.Text.ToString();
            string otDate = txtDate.Text.ToString();
            string otTime = txtTime.Text.ToString();
            string category = opCategory.SelectedItem.Text.ToString();
            string opname = opName.SelectedItem.Text.ToString();
            string optheatre = opTheater.SelectedItem.Text.ToString();
            string drname = drName.SelectedItem.Text.ToString();
            string anname = anName.SelectedItem.Text.ToString();

            string type = (string.IsNullOrEmpty(txtTreatId.Value) || txtTreatId.Value == "0") ? "1" : "2";

            int res = obj.InsertUpdateOtSchedule(type: type, PatRegId: regId, Opd: opd, Ipd: ipd, OpCategory: category, OpName: opname,
                OpTheater: optheatre, DrName: drname, AnName: anname, OtDate: otDate, OtTime: otTime, schId: txtTreatId.Value.ToString());

            if (res > 0)
            {
                string msg = type == "1" ? "Saved successfully." : "Updated successfully.";
                SuccessMessage(msg);
                ClearFields();
                gvTempTable.EditIndex = -1;
                BindGrid();
                btnSave.Text = "Save";
            }
            else
            {
                string msg = type == "-1" ? "Date and time not available" : "Failed to save" ;
                ErrorMessage(msg);
            }
        }
        catch (Exception)
        {
            ErrorMessage("Error occurred.");
           
        }
    }

    protected void gvTempTable_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string scId = e.Keys[0].ToString();

        if (obj.DeleteOtSchedule(scId) > 0)
        {
            SuccessMessage("Record deleted successfully.");
            BindGrid();
        }
        else
        {
            ErrorMessage("Could not delete.");
        }
    }

    protected void gvTempTable_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvTempTable.PageIndex = e.NewPageIndex;
        BindGrid();
    }

    protected void gvTempTable_RowCommand(object sender, GridViewCommandEventArgs e)
    {


        if (e.CommandName == "Edit")
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvTempTable.Rows[rowIndex];

            string otdate = gvTempTable.Rows[rowIndex].Cells[1].Text;
            string ottime = gvTempTable.Rows[rowIndex].Cells[2].Text;

            string schId = gvTempTable.Rows[rowIndex].Cells[3].Text;
            string opcat = gvTempTable.Rows[rowIndex].Cells[4].Text;

            string opname = gvTempTable.Rows[rowIndex].Cells[5].Text;
            string optheatre = gvTempTable.Rows[rowIndex].Cells[6].Text;

            string drname = gvTempTable.Rows[rowIndex].Cells[7].Text;
            string anname = gvTempTable.Rows[rowIndex].Cells[8].Text;

            txtDate.Text = otdate;
            txtTime.Text = ottime;

            txtTreatId.Value = schId;
            opCategory.SelectedIndex = opCategory.Items.IndexOf(opCategory.Items.FindByText(opcat));
            opName.SelectedIndex = opName.Items.IndexOf(opName.Items.FindByText(opname));
            opTheater.SelectedIndex = opTheater.Items.IndexOf(opTheater.Items.FindByText(optheatre));
            drName.SelectedIndex = drName.Items.IndexOf(drName.Items.FindByText(drname));
            anName.SelectedIndex = anName.Items.IndexOf(anName.Items.FindByText(anname));

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

    protected void btnClear_Click(object sender, EventArgs e)
    {
        lblMsg.Text = ""; lblMsg.Visible = false;
        //txtpatientregid.Text="";
        // lblOpd.Text.ToString();
        // lblIpd.Text.ToString();
        ClearFields();
        
    }

    private void ClearFields()
    {
        opCategory.SelectedIndex = 0;
        opName.SelectedIndex = 0;
        opTheater.SelectedIndex = 0;
        drName.SelectedIndex = 0;
        anName.SelectedIndex = 0;
    }

    private void ErrorMessage(string msg)
    {
        lblMsg.Text = msg; lblMsg.Visible = true; lblMsg.ForeColor = System.Drawing.Color.Red;
    }

    private void SuccessMessage(string msg)
    {
        lblMsg.Text = msg; lblMsg.Visible = true; lblMsg.ForeColor = System.Drawing.Color.Green;
    }


    protected void gvTempTable_SelectedIndexChanged(object sender, EventArgs e)
    {
        //GridViewRow row = gvTempTable.SelectedRow;
        //string otdate = row.Cells[1].Text;
        //string ottime = row.Cells[2].Text;

        //string schId = row.Cells[3].Text;
        //string opcat = row.Cells[4].Text;

        //string opname = row.Cells[5].Text;
        //string optheatre = row.Cells[6].Text;

        //string drname = row.Cells[7].Text;
        //string anname = row.Cells[8].Text;

        //txtDate.Text = otdate;
        //txtTime.Text = ottime;

        //txtTreatId.Value = schId;
        //opCategory.SelectedIndex = opCategory.Items.IndexOf(opCategory.Items.FindByText(opcat));
        //opName.SelectedIndex = opName.Items.IndexOf(opName.Items.FindByText(opname));
        //opTheater.SelectedIndex = opTheater.Items.IndexOf(opTheater.Items.FindByText(optheatre));
        //drName.SelectedIndex = drName.Items.IndexOf(drName.Items.FindByText(drname));
        //anName.SelectedIndex = anName.Items.IndexOf(anName.Items.FindByText(anname));

        //btnSave.Text = "Update";
    }
}