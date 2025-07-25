using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmCheckListDetails :BasePage
{
    clsCheckListDetails objCheck = new clsCheckListDetails();
    List<clsCheckListTrans> trans = new List<clsCheckListTrans>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnAdd.Enabled = false;
            btnUpdate.Visible = false;
            btnClear.Enabled = true;

            FilldrpCheckListType();

            BindGrid();

            if (ViewState.Count > 0)
            {
                DataTable dt = (DataTable)ViewState["DataFromGrid"];
            }
        }
    }

    #region dropdowns
    protected void FilldrpCheckListType()
    {
        DataTable dt = objCheck.GetCheckListCategoriesDt();

        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                drpCheckListType.DataSource = dt;
                drpCheckListType.DataBind();
            }
        }
        drpCheckListType.Items.Insert(0, "--Select--");
    }

    public void BindGrid()
    {
        string mrd = txtMrd.Text;
        string ipd = txtIpd.Text;
        string schId = Convert.ToString(txtSchId.Value);
        if (!string.IsNullOrEmpty(mrd) || !string.IsNullOrEmpty(ipd))
        {
            DataSet ds = objCheck.GetCheckListMainGridDetail(mrd, ipd, schId);

            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt2 = ds.Tables[0];

                int ipdCount = dt2.Rows[0]["IpdCount"] != DBNull.Value ? Convert.ToInt32(dt2.Rows[0]["IpdCount"]) : 0;

                if (ipdCount > 0)
                {
                    DataTable dt = ds.Tables[1];

                    gdvCheckListDetails.DataSource = dt;
                    gdvCheckListDetails.DataBind();

                }
                else
                {
                    gdvCheckListDetails.DataSource = null;
                    gdvCheckListDetails.DataBind();
                }
            }
        }
        else
        {
            gdvCheckListDetails.DataSource = null;
            gdvCheckListDetails.DataBind();
        }
    }

    public void BindGridView()
    {
        if (drpCheckListType.SelectedIndex > 0)
        {
            string val = drpCheckListType.SelectedItem.Value.ToString();
            string strVal = drpCheckListType.SelectedItem.Text.ToString();

            string mrd = string.IsNullOrEmpty(txtMrd.Text) ? null : txtMrd.Text;
            string ipd = string.IsNullOrEmpty(txtIpd.Text) ? null : txtIpd.Text;

            DataTable dt1 = objCheck.GetCheckListCategoriesTypeDt(val, mrd, ipd);

            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("Id", typeof(int)),
                new DataColumn("checkListTranId", typeof(string)),
                new DataColumn("checkListTranName",typeof(string)),
                 new DataColumn("checkListType",typeof(string)),
                new DataColumn("remarks", typeof(string))
            });

            if (dt1 != null)
            {
                if (dt1.Rows.Count > 0)
                {
                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {
                        DataRow drRow = dt.NewRow();
                        drRow["Id"] = (i + 1).ToString();
                        drRow["checkListTranId"] = Convert.ToString(dt1.Rows[i]["checkListTranId"]);
                        drRow["checkListTranName"] = Convert.ToString(dt1.Rows[i]["checkListTranName"]);
                        drRow["checkListType"] = strVal;
                        drRow["remarks"] = string.IsNullOrEmpty(mrd) ? string.Empty : dt1.Rows[i]["Remarks"].ToString();

                        dt.Rows.Add(drRow);
                    }
                }
            }

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }


        }
    }
    #endregion

    protected void gdvCheckListDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvCheckListDetails.PageIndex = e.NewPageIndex;
        BindGrid();
    }

    protected void gdvCheckListDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void gdvCheckListDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }

    protected void gdvCheckListDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }

    protected void gdvCheckListDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {

    }

    protected void gdvCheckListDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void gdvCheckListType_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void gdvCheckListType_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }

    protected void drpCheckListType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpCheckListType.SelectedIndex > 0)
        {
            GridView1.EditIndex = -1;

            string val = drpCheckListType.SelectedItem.Value.ToString();
            string strVal = drpCheckListType.SelectedItem.Text.ToString();

            string mrd = string.IsNullOrEmpty(txtMrd.Text) ? null : txtMrd.Text;
            string ipd = string.IsNullOrEmpty(txtIpd.Text) ? null : txtIpd.Text;

            DataTable dt1 = objCheck.GetCheckListCatTypeByMrd(mrd, ipd, val);


            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("Id", typeof(int)),
                new DataColumn("checkListTranId", typeof(string)),
                new DataColumn("checkListTranName",typeof(string)),
                 new DataColumn("checkListType",typeof(string)),
                new DataColumn("remarks", typeof(string))
            });

            if (dt1 != null)
            {
                if (dt1.Rows.Count > 0)
                {
                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {
                        DataRow drRow = dt.NewRow();
                        drRow["Id"] = (i + 1).ToString();
                        drRow["checkListTranId"] = Convert.ToString(dt1.Rows[i]["checkListTranId"]);
                        drRow["checkListTranName"] = Convert.ToString(dt1.Rows[i]["checkListTranName"]);
                        drRow["checkListType"] = strVal;
                        drRow["remarks"] = string.IsNullOrEmpty(mrd) ? string.Empty : dt1.Rows[i]["Remarks"].ToString();
                        dt.Rows.Add(drRow);
                    }
                    AddRowsToGrid(dt);

                    //Store the DataTable in ViewState
                    ViewState["CurrentTable"] = dt;

                    btnAdd.Enabled = true;
                    btnUpdate.Visible = false;
                    btnClear.Enabled = true;
                }
            }
            BindGridView();
        }
        else
        {

            AddRowsToGrid(null);

            GridView1.DataSource = null;
            GridView1.DataBind();

            btnAdd.Enabled = false;
            btnUpdate.Visible = false;
            btnClear.Enabled = false;
        }
    }

    private void AddRowsToGrid(DataTable dt)
    {
        gdvCheckListType.DataSource = dt;
        gdvCheckListType.DataBind();

        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            if (drpCheckListType.SelectedIndex > 0)
            {
                string type = Convert.ToString(drpCheckListType.SelectedItem.Text);

                string schId = Convert.ToString(txtSchId.Value);

                int count = GridView1.Rows.Count;

                DataTable saveDt = new DataTable();
                saveDt.Columns.AddRange(new DataColumn[]
                {
                    new DataColumn("Id", typeof(int)),
                    new DataColumn("checkListTranId", typeof(string)),
                    new DataColumn("checkListTranName",typeof(string)),
                     new DataColumn("checkListType",typeof(string)),
                    new DataColumn("remarks", typeof(string))
                });

                foreach (GridViewRow row in GridView1.Rows)
                {
                    TextBox box1 = (TextBox)row.Cells[4].FindControl("txtRemarks");
                    TextBox remark = (TextBox)row.FindControl("remarks");

                    trans.Add(new clsCheckListTrans()
                    {
                        checkDate = System.DateTime.Now.ToShortDateString(),
                        checkListDesc = row.Cells[2].Text,
                        checkListDetailsId = schId == "0" ? "0" : row.Cells[0].Text,
                        checkListDetailsTranId = schId == "0" ? "0" : row.Cells[1].Text,
                        checkListType = type,
                        Remarks = box1.Text //row.Cells[4].Text
                    });
                }

                if (ViewState.Count > 0)
                {
                    //(ViewState.Values).Items[0].Value;
                    DataTable dt = (DataTable)ViewState["DataFromGrid"];
                    dt.Rows.Add("");
                }
                else if (ViewState.Count == 0)
                {
                    ViewState["DataFromGrid"] = trans;
                }
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtSchId.Value = "";
        txtMrd.Text = "";
        txtIpd.Text = "";
        txtRoomType.Text = "";
        txtBedNo.Text = "";
        txtPatientName.Text = "";
        txtDateOfAdmission.Text = "";
        txtDoctorIncharge.Text = "";
        txtDiagnosis.Text = "";

        drpCheckListType.SelectedIndex = 0;

        GridView1.DataSource = null;
        GridView1.DataBind();

        gdvCheckListDetails.DataSource = null;
        gdvCheckListDetails.DataBind();
    }

    protected void txtMrd_TextChanged(object sender, EventArgs e)
    {
        string mrd = txtMrd.Text;
        string ipd = txtIpd.Text;
        string schId = Convert.ToString(txtSchId.Value);

        GetDetails(mrd, ipd, schId);

        txtIpd.Focus();
    }

    private void GetDetails(string mrd, string ipd, string schId)
    {
        DataSet ds = objCheck.GetCheckListMainGridDetail(mrd, ipd, schId);

        if (ds != null && ds.Tables.Count > 0)
        {
            DataTable dt2 = ds.Tables[0];

            int ipdCount = dt2.Rows[0]["IpdCount"] != DBNull.Value ? Convert.ToInt32(dt2.Rows[0]["IpdCount"]) : 0;

            if (ipdCount > 0)
            {
                DataTable dt = ds.Tables[1];

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        if (ipdCount == 1 || !string.IsNullOrEmpty(ipd))
                        {
                            string id = dt.AsEnumerable()
                                    .Where(x => x.Field<string>("Ipd") == ipd)
                                    .Select(x => x.Field<int>("checkListDetailsId")).FirstOrDefault().ToString();

                            txtSchId.Value = string.IsNullOrEmpty(id) ? "0" : id;
                            txtMrd.Text = dt.Rows[0]["MrdNo"] != DBNull.Value ? Convert.ToString(dt.Rows[0]["MrdNo"]) : "";
                            txtIpd.Text = dt.Rows[0]["Ipd"] != DBNull.Value ? Convert.ToString(dt.Rows[0]["Ipd"]) : "";
                            txtRoomType.Text = dt.Rows[0]["RoomType"] != DBNull.Value ? Convert.ToString(dt.Rows[0]["RoomType"]) : "";
                            txtBedNo.Text = dt.Rows[0]["BedNo"] != DBNull.Value ? Convert.ToString(dt.Rows[0]["BedNo"]) : "";
                            txtPatientName.Text = dt.Rows[0]["PatientName"] != DBNull.Value ? Convert.ToString(dt.Rows[0]["PatientName"]) : "";
                            txtDateOfAdmission.Text = dt.Rows[0]["DateOfAdmission"] != DBNull.Value ? Convert.ToDateTime(dt.Rows[0]["DateOfAdmission"]).ToString("dd-MM-yyyy") : "";
                            txtDoctorIncharge.Text = dt.Rows[0]["DoctorInc"] != DBNull.Value ? Convert.ToString(dt.Rows[0]["DoctorInc"]) : "";
                            txtDiagnosis.Text = dt.Rows[0]["Diagnosis"] != DBNull.Value ? Convert.ToString(dt.Rows[0]["Diagnosis"]) : "";
                        }
                        else if (ipdCount > 1)
                        {
                            if (!string.IsNullOrEmpty(ipd))
                            {
                                string id = dt.AsEnumerable()
                                    .Where(x => x.Field<string>("Ipd") == ipd)
                                    .Select(x => x.Field<string>("checkListDetailsId")).FirstOrDefault().ToString();

                                //txtSchId.Value = dt.Rows[0]["checkListDetailsId"] != DBNull.Value ? Convert.ToString(dt.Rows[0]["checkListDetailsId"]) : "0";
                            }
                        }

                    }
                }
            }
        }

        GridView1.DataSource = null;
        GridView1.DataBind();

        drpCheckListType.SelectedIndex = 0;
        BindGrid();
    }

    private List<clsCheckListTrans> GetCheckListTypeGridValues()
    {
        List<clsCheckListTrans> trans11 = new List<clsCheckListTrans>();
        try
        {
            if (drpCheckListType.SelectedIndex > 0)
            {
                string type = Convert.ToString(drpCheckListType.SelectedItem.Text);

                string schId = Convert.ToString(txtSchId.Value);

                int count = GridView1.Rows.Count;

                DataTable saveDt = new DataTable();
                saveDt.Columns.AddRange(new DataColumn[]
                {
                    new DataColumn("Id", typeof(int)),
                    new DataColumn("checkListTranId", typeof(string)),
                    new DataColumn("checkListTranName",typeof(string)),
                     new DataColumn("checkListType",typeof(string)),
                    new DataColumn("remarks", typeof(string))
                });

                foreach (GridViewRow row in GridView1.Rows)
                {
                    TextBox box1 = (TextBox)row.Cells[4].FindControl("txtRemarks");
                    TextBox remark = (TextBox)row.FindControl("remarks");
                    if (!string.IsNullOrEmpty(box1.Text))
                    {
                        trans11.Add(new clsCheckListTrans()
                        {
                            checkDate = System.DateTime.Now.ToShortDateString(),
                            checkListDesc = row.Cells[2].Text,
                            checkListDetailsId = schId == "0" ? "0" : row.Cells[0].Text,
                            checkListDetailsTranId = schId == "0" ? "0" : row.Cells[1].Text,
                            checkListType = type,
                            Remarks = box1.Text //row.Cells[4].Text
                        });
                    }
                }
            }
        }
        catch (Exception)
        {
            return null;
        }

        return trans11;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string schId = Convert.ToString(txtSchId.Value);
            string mrd = Convert.ToString(txtMrd.Text);
            string ipd = Convert.ToString(txtIpd.Text);
            string room = Convert.ToString(txtRoomType.Text);
            string bed = Convert.ToString(txtBedNo.Text);
            string patientName = Convert.ToString(txtPatientName.Text);
            string dateAd = Convert.ToString(txtDateOfAdmission.Text);
            string docInc = Convert.ToString(txtDoctorIncharge.Text);
            string diag = Convert.ToString(txtDiagnosis.Text);

            //if schId is empty or null i.e its new record      : insert
            //else its existing one                             : update

            //insert------------------------------------------------------------------------

            //1: get main records into obj, insert it in table & return schId
            //2: insert transactions into db

            // update------------------------------------------------------------------------

            //1: update any main records parameter
            //2: update each record in transaction , matching mrd & ipd in main table, get transDetailId..

            objCheck.checkListDetailsId = string.IsNullOrEmpty(schId) ? "0" : schId;
            objCheck.MrdNo = mrd;
            objCheck.Ipd = ipd;
            objCheck.RoomType = room;
            objCheck.BedNo = bed;
            objCheck.PatientName = patientName;
            objCheck.DateOfAdmission = dateAd;
            objCheck.Diagnosis = diag;
            objCheck.DoctorInc = docInc;

            string type = objCheck.checkListDetailsId == "0" ? "Insert" : "Update";

            int returnedValue = objCheck.InsertMainRec(type);

            if (returnedValue == -1)
            {
                lblMsg.Text = "Something went wrong.";
            }
            else if (returnedValue == 0)
            {
                lblMsg.Text = "Error occured during adding record.";
            }
            else if (returnedValue > 0)
            {
                lblMsg.Text = "Updated successfully";
                if (type == "Insert")
                {
                    txtSchId.Value = returnedValue.ToString();
                }
                objCheck.transactions = GetCheckListTypeGridValues();

                if (objCheck.transactions != null && objCheck.transactions.Count > 0)
                {
                    foreach (var item in objCheck.transactions)
                    {
                        try
                        {
                            int r = objCheck.InsertUpdateTransactionsRec(item.checkListDetailsId, item.checkListType, item.checkListDesc, item.Remarks);

                            if (r == -1)
                            {
                                lblMsg.Text = "Could not insert";
                                break;
                            }
                        }
                        catch (Exception)
                        {
                            lblMsg.Text = "Could not insert";
                            break;
                        }


                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        BindGridView();
    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        BindGridView();
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        BindGridView();
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int schId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
        GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];

        Label lblID = (Label)row.FindControl("checkListTranId");

        TextBox remarks = (TextBox)row.Cells[3].Controls[0];

        GridView1.EditIndex = -1;

        //conn.Open();

        //SqlCommand cmd = new SqlCommand("update detail set name='" + textName.Text + "',address='" + textadd.Text 
        //    + "',country='" + textc.Text + "'where id='" + userid + "'", conn);
        //cmd.ExecuteNonQuery();
        //conn.Close();
        BindGridView();
    }

    protected void txtIpd_TextChanged(object sender, EventArgs e)
    {
        string mrd = txtMrd.Text;
        string ipd = txtIpd.Text;
        string schId = Convert.ToString(txtSchId.Value);
        GetDetails(mrd, ipd, schId);
        BindGrid();
        txtRoomType.Focus();
    }
}