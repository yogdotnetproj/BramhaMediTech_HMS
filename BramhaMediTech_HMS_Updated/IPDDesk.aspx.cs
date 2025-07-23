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

public partial class IPDDesk : System.Web.UI.Page
{
    TreeviewBind_C ObjTB = new TreeviewBind_C();
    DataTable dt = new DataTable();
    DALIPDDesk objDalIpdDesk = new DALIPDDesk();
    BELOPDPatReg objBELOpdReg = new BELOPDPatReg();
    DALIpdRegistration objDALIpdReg = new DALIpdRegistration();
    DataTable dtBeds = new DataTable();
    string RegNo = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            try
            {

                LblDCName.Text = Convert.ToString(Session["Bannername"]);
                LblDCCode.Text = Convert.ToString(Session["BannerCode"]);
                LUNAME.Text = Convert.ToString(Session["username"]);
                 RegNo = Convert.ToString( Request.QueryString["PatientInfoID"]);
                dt = new DataTable();
                dt = ObjTB.IPDBindMainMenu(Convert.ToString(Session["username"]), Convert.ToString(Session["password"]));
                this.PopulateTreeView(dt, 0, null);
                ViewState["Shift"] = "";
                ViewState["PatRegId"] = "";
                ViewState["IpdNo"] = "";
                BindRoomType();
                RdbRoomType.SelectedValue = "1";
                RdbRoomType_SelectedIndexChanged(null, null);
                ViewState["RoomId"] = "1";
                //txtShiftDate.Value = DateTime.Now.ToString("dd/MM/yyyy");

                //DateTime time = System.DateTime.Now;
                //string s = string.Format("{0}/{1} - {2}",time.get(),time.GetMinute(),time.Hour > 12 ? "PM" "AM");

            }
            catch (Exception exc)
            {
                if (exc.Message.Equals("Exception aborted."))
                {
                    return;
                }
                else
                {
                    Response.Cookies["error"].Value = exc.Message;
                    Server.Transfer("~/ErrorMessage.aspx");
                }
            }
        }
        this.RegisterPostBackControl();
    }
    private void PopulateTreeView(DataTable dtparent, int Parentid, TreeNode treeNode)
    {
        foreach (DataRow row in dtparent.Rows)
        {
            TreeNode child = new TreeNode
            {
                Text = row["MenuName"].ToString(),
                Value = row["MenuID"].ToString()

            };
            if (Parentid == 0)
            {
                TrMenu.Nodes.Add(child);
                DataTable dtchild = new DataTable();
                dtchild = ObjTB.IPDBindChildMenu(child.Value, Convert.ToString(Session["username"]), Convert.ToString(Session["password"]));
                PopulateTreeView(dtchild, int.Parse(child.Value), child);

            }
            else
            {
                treeNode.ChildNodes.Add(child);
            }

        }
    }


    protected void TrMenu_SelectedNodeChanged(object sender, EventArgs e)
    {
        txtPatientName.Text = "";
        if (TrMenu.SelectedValue != "")
        {
            int tId = Convert.ToInt32(TrMenu.SelectedValue);
            ViewState["RoomId"] = tId;
            DataTable dtform = new DataTable();
            // dtform = ObjTB.BindForm(tId);
            dtform = ObjTB.BindForm_Room(tId);

            if (dtform.Rows.Count > 0)
            {
                // Response.Redirect(dtform.Rows[0]["SubMenuNavigateURL"].ToString());

                DataTable dtRooms = objDalIpdDesk.BindRooms(Convert.ToInt32(tId));
                if (dtRooms.Rows.Count > 0)
                {
                    RoomsDataList.DataSource = dtRooms;
                    RoomsDataList.DataBind();
                }
                else
                {
                    RoomsDataList.DataSource = null;
                    RoomsDataList.DataBind();
                }
            }
        }
    }
    public void BindRoomType()
    {
        RdbRoomType.DataSource = objDalIpdDesk.FillRoomTypes(Convert.ToInt32(Session["FId"]), Convert.ToInt32(Session["BranchId"]));
        RdbRoomType.DataTextField = "RType";
        RdbRoomType.DataValueField = "RTypeId";
        RdbRoomType.DataBind();
    }
    protected void RdbRoomType_SelectedIndexChanged(object sender, EventArgs e)
    {

        DataTable dtRooms = objDalIpdDesk.BindRooms(Convert.ToInt32(RdbRoomType.SelectedValue));
        if (dtRooms.Rows.Count > 0)
        {
            RoomsDataList.DataSource = dtRooms;
            RoomsDataList.DataBind();
        }
        else
        {
            RoomsDataList.DataSource = null;
            RoomsDataList.DataBind();
        }

    }
    protected void RoomsDataList_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            int RoomId = Convert.ToInt32(RoomsDataList.DataKeys[e.Item.ItemIndex]);
            Label RoomName = e.Item.FindControl("lblRoomName") as Label;

            // string RoomName = ((Label)RoomsDataList.Items[e.Item.ItemIndex].FindControl("lblRoomName")).Text;            
            // This will fetch the datakey on ItemDataBoundb event

            DataList BedDataList = e.Item.FindControl("BedDataList") as DataList;

            // GetDatatable is a function which will get the data into the datatable
            if (txtPatientName.Text == "")
            {
                dtBeds = objDalIpdDesk.FillBeds(Convert.ToInt32(RoomId));
            }
            else
            {
                dtBeds = objDalIpdDesk.BindRooms_AdmitPAtient(Convert.ToString(ViewState["PatientInfoId"]), 0, Convert.ToInt32(RdbRoomType.SelectedValue));
            }
            if (dtBeds.Rows.Count > 0)
            {
                BedDataList.DataSource = dtBeds;
                BedDataList.DataBind();
            }
            else
            {
                BedDataList.DataSource = null;
                BedDataList.DataBind();
            }

        }
    }
    //protected void btnAdmit_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("IPDRegistration.aspx");
    //}
    protected void BedDataList_EditCommand(object source, DataListCommandEventArgs e)
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
        DataList BedDataList = e.Item.NamingContainer as DataList;
        //DataList BedDataList = e.Item.FindControl("BedDataList") as DataList;
        if (ViewState["Shift"].ToString() == "1")
        {
            int RoomId = Convert.ToInt32((BedDataList.NamingContainer.FindControl("lblRoomId") as Label).Text);
            int BedId = Convert.ToInt32(BedDataList.DataKeys[e.Item.ItemIndex].ToString());
            int BedIdOld = Convert.ToInt32(ViewState["BedIdOld"]);
            int PatRegId = Convert.ToInt32(ViewState["PatRegId"]);
            objBELOpdReg.FId = Convert.ToInt32(Session["FId"]);
            objBELOpdReg.BranchId = Convert.ToInt32(Session["Branchid"]);
            objBELOpdReg.CreatedBy = Convert.ToString(Session["username"]);
            objBELOpdReg.BedId = BedId;
            objBELOpdReg.PatRegId = PatRegId;
            objBELOpdReg.OLDBedId = BedIdOld;
            objBELOpdReg.ReasonforShifting = txtshiftReason.Text;
            objBELOpdReg.RoomId = RoomId;
            objDALIpdReg.InsertUpdateBedAllocationInfo_Shifting(objBELOpdReg);
            lblMessage.Text = "Patient Shifted SuccessFully";
            //RdbRoomType_SelectedIndexChanged(null, null);
            TrMenu_SelectedNodeChanged(null, null);
            ViewState["Shift"] = "";
            ShiftingDetails.Visible = false;
            txtshiftReason.Text = "";

        }
        else
        {

            int BedId = Convert.ToInt32(BedDataList.DataKeys[e.Item.ItemIndex].ToString());
            string BedName = ((Label)BedDataList.Items[e.Item.ItemIndex].FindControl("lblBedName")).Text;
            string RoomName = (BedDataList.NamingContainer.FindControl("lblRoomName") as Label).Text;
            int RoomId = Convert.ToInt32((BedDataList.NamingContainer.FindControl("lblRoomId") as Label).Text);

            Response.Redirect("IPDRegistration.aspx?RoomType=" + ViewState["RoomId"] + "&RoomId=" + RoomId + "&BedId=" + BedId + "&BedName=" + BedName + "&RoomName=" + RoomName + "&RegNo=" + Convert.ToString(Request.QueryString["PatientInfoID"]) + "&ReferToAdmi=" + Convert.ToString(Request.QueryString["ReferToAdmi"]) + "&ReferToAdmit=" + Convert.ToString(Request.QueryString["ReferToAdmit"]) + "&OpdNo=" + Convert.ToString(Request.QueryString["OpdNo"]), false);
            BedDataList.EditItemIndex = -1;
        }

    }
    protected void BedDataList_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label IsAdmited = e.Item.FindControl("lblIsAdmited") as Label;
            ImageButton Admit = e.Item.FindControl("btnAdmit") as ImageButton;
            ImageButton Shift = e.Item.FindControl("btnShift") as ImageButton;
            ImageButton Discharge = e.Item.FindControl("btnDischarge") as ImageButton;
            ImageButton Edit = e.Item.FindControl("btnEdit") as ImageButton;
            ImageButton btnFrontSheet = e.Item.FindControl("btnFrontSheet") as ImageButton;
            HiddenField Isuniv = e.Item.FindControl("hdn_IsUniversalPrecaution") as HiddenField;
            ImageButton bPAnic = e.Item.FindControl("btnpanic") as ImageButton;

            if (IsAdmited.Text == "Admitted")
            {
                Admit.Visible = false;
                Edit.Visible = true;
                Shift.Visible = true;
                Discharge.Visible = true;
                btnFrontSheet.Visible = true;

            }
            else
            {
                Admit.Visible = true;
                Edit.Visible = false;
                Shift.Visible = false;
                Discharge.Visible = false;
                btnFrontSheet.Visible = false;
            }
            if (Isuniv.Value == "False")
            {
                bPAnic.Visible = false;
            }
            else
            {
                bPAnic.Visible = true;
            }
            if (((HiddenField)e.Item.FindControl("hdnPatRegId")).Value != "")
            {
                int PatRegId = Convert.ToInt32(((HiddenField)e.Item.FindControl("hdnPatRegId")).Value);
                int IpdNo = Convert.ToInt32(((HiddenField)e.Item.FindControl("hdnIpdNo")).Value);
                DataTable dtdischarge = objDalIpdDesk.BillDeskDischarge(Convert.ToInt32(PatRegId), IpdNo, Convert.ToInt32(Session["Branchid"]));
                if (dtdischarge.Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dtdischarge.Rows[0]["IsDischarge"]) == true)
                    {

                        Admit.Visible = false;
                        Edit.Visible = false;
                        Shift.Visible = false;
                        Discharge.Visible = true;
                        btnFrontSheet.Visible = false;
                    }
                }
            }
        }

    }

    protected void btnDischarge_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "CallConfirmBox", "CallConfirmBox();", true);


    }
    //private void RegisterPostBackControl()
    //{
    //DataList BedDataList = e.Item.NamingContainer as DataList;
    //  DropDownList ddl_Receipt = row.FindControl("ddlReceipt") as DropDownList;
    //  Button btnPrint = row.FindControl("btnPrint") as Button;
    //  ScriptManager.GetCurrent(this).RegisterPostBackControl(ddl_Receipt);
    //  ScriptManager.GetCurrent(this).RegisterPostBackControl(btnPrint);


    //}
    private void RegisterPostBackControl()
    {

        foreach (DataListItem row in RoomsDataList.Items)
        {
            DataList BedDataList = row.FindControl("BedDataList") as DataList;
            foreach (DataListItem row1 in BedDataList.Items)
            {
                ImageButton btnFrontSheet = row1.FindControl("btnFrontSheet") as ImageButton;
                ScriptManager.GetCurrent(this).RegisterPostBackControl(btnFrontSheet);
            }
        }
    }
    protected void BedDataList_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "Shift")
        {
            DataList BedDataList = e.Item.NamingContainer as DataList;
            ShiftingDetails.Visible = true;
            ViewState["Shift"] = "1";
            int BedId = Convert.ToInt32(BedDataList.DataKeys[e.Item.ItemIndex].ToString());
            int PatRegId = Convert.ToInt32(((HiddenField)BedDataList.Items[e.Item.ItemIndex].FindControl("hdnPatRegId")).Value);
            int IpdNo = Convert.ToInt32(((HiddenField)BedDataList.Items[e.Item.ItemIndex].FindControl("hdnIpdNo")).Value);

            ViewState["PatRegId"] = PatRegId;
            ViewState["BedIdOld"] = BedId;
            ViewState["IpdNo"] = IpdNo;

        }
        if (e.CommandName == "Discharge")
        {
            // ScriptManager.RegisterStartupScript(this, this.GetType(), "CallConfirmBox", "CallConfirmBox();", true);

            //if (ViewState["confirmValue"].ToString() == "Yes")
            //{
            DataList BedDataList = e.Item.NamingContainer as DataList;
            ShiftingDetails.Visible = false;

            int BedId = Convert.ToInt32(BedDataList.DataKeys[e.Item.ItemIndex].ToString());
            int PatRegId = Convert.ToInt32(((HiddenField)BedDataList.Items[e.Item.ItemIndex].FindControl("hdnPatRegId")).Value);
            int IpdNo = Convert.ToInt32(((HiddenField)BedDataList.Items[e.Item.ItemIndex].FindControl("hdnIpdNo")).Value);
            objBELOpdReg.FId = Convert.ToInt32(Session["FId"]);
            objBELOpdReg.BranchId = Convert.ToInt32(Session["Branchid"]);
            objBELOpdReg.CreatedBy = Convert.ToString(Session["username"]);
            objBELOpdReg.BedId = BedId;
            objBELOpdReg.PatRegId = PatRegId;
            DataTable dtdischarge = objDalIpdDesk.BillDeskDischarge(Convert.ToInt32(PatRegId), IpdNo, Convert.ToInt32(Session["Branchid"]));
            if (dtdischarge.Rows.Count > 0)
            {
                if (Convert.ToBoolean(dtdischarge.Rows[0]["IsDischarge"]) == false)
                {
                    lblMessage.Text = "Pls contact billing department!";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    //  Response.Redirect("~/PatientDischarge.aspx?PatRegID=" + PatRegId + "&IpdNo=" + IpdNo + "&FID=" + Convert.ToInt32(Session["FId"]) + "&BedId=" + BedId + "", false);

                }
                else
                {
                    //ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(600/2);var Mtop = (screen.height/2)-(500/2);window.open( 'PatientDischarge.aspx?PatRegID=" + PatRegId + "&IpdNo=" + IpdNo + "&FID=" + Convert.ToInt32(Session["FId"]) + " ', null, 'height=300,width=6000,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);
                    //ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(600/2);var Mtop = (screen.height/2)-(500/2);window.open( 'PatientDischarge.aspx', null, 'height=300,width=6000,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);
                    // ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(1250/2);var Mtop = (screen.height/2)-(700/2);window.open( 'ReRunResult.aspx?MTCode=" + PatRegId + "&PatRegID=" + PatRegId + "&Branchid=" + Session["Branchid"].ToString() + " ', null, 'height=700,width=1250,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);
                    Response.Redirect("~/PatientDischarge.aspx?PatRegID=" + PatRegId + "&IpdNo=" + IpdNo + "&FID=" + Convert.ToInt32(Session["FId"]) + "&BedId=" + BedId + "", false);

                    // objDALIpdReg.InsertUpdateBedAllocationInfo_Discharge(objBELOpdReg);
                    lblMessage.Text = "Discharged succssfully!!!";
                    //RdbRoomType_SelectedIndexChanged(null, null);
                }
            }

            //}

        }
        if (e.CommandName == "EditInfo")
        {
            DataList BedDataList = e.Item.NamingContainer as DataList;
            ShiftingDetails.Visible = false;

            int BedId = Convert.ToInt32(BedDataList.DataKeys[e.Item.ItemIndex].ToString());
            int PatRegId = Convert.ToInt32(((HiddenField)BedDataList.Items[e.Item.ItemIndex].FindControl("hdnPatRegId")).Value);
            int IpdNo = Convert.ToInt32(((HiddenField)BedDataList.Items[e.Item.ItemIndex].FindControl("hdnIpdNo")).Value);
            int IpdId = Convert.ToInt32(((HiddenField)BedDataList.Items[e.Item.ItemIndex].FindControl("hdnIpdId")).Value);

            //ViewState["PatRegId"] = PatRegId;
            //ViewState["BedIdOld"] = BedId;
            //ViewState["IpdNo"] = IpdNo;
            Response.Redirect("IPDRegistration.aspx?RoomType=" + RdbRoomType.SelectedValue + "&IpdId=" + IpdId + "&Type=EditIPDReg", false);


        }
        if (e.CommandName == "Report")
        {
            DataList BedDataList = e.Item.NamingContainer as DataList;
            ShiftingDetails.Visible = false;
            this.RegisterPostBackControl();
            // ScriptManager.GetCurrent(this).RegisterPostBackControl(btnFrontSheet);
            DataSet ds = new DataSet();
            BLLReports objReports = new BLLReports();
            int IpdId = Convert.ToInt32(((HiddenField)BedDataList.Items[e.Item.ItemIndex].FindControl("hdnIpdId")).Value);
            int FId = Convert.ToInt32(Session["FId"]);
            int BranchId = Convert.ToInt32(Session["Branchid"]);
            ReportDocument CrystalReport = new ReportDocument();
            CrystalReport.Load(Server.MapPath("~/Report/Rpt_AdmissionFrontSheet.rpt"));
            ds = objReports.GetIpdPatientCard(IpdId, FId, BranchId);
            CrystalReport.SetDataSource(ds);
            CrystalReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, "Employee");
        }
    }




    [ScriptMethod()]
    [WebMethod]
    public static List<string> SearchPatient(string prefixText, int count)
    {
        DALOpdReg objDALOpdReg = new DALOpdReg();
        return objDALOpdReg.FillAllIPDPatient(prefixText);
    }
    protected void txtPatientName_TextChanged(object sender, EventArgs e)
    {

        string[] PatientInfo = txtPatientName.Text.Split('-');
        if (PatientInfo.Length > 1)
        {
            txtPatientName.Text = PatientInfo[1];
            ViewState["PatientInfoId"] = PatientInfo[0];
        }

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (ViewState["PatientInfoId"] == null)
        {
            ViewState["PatientInfoId"] = "0";
        }
        DataTable dtRooms = objDalIpdDesk.BindRooms_AdmitPAtient(Convert.ToString(ViewState["PatientInfoId"]), 0, Convert.ToInt32(RdbRoomType.SelectedValue));
        if (dtRooms.Rows.Count > 0)
        {
            RoomsDataList.DataSource = dtRooms;
            RoomsDataList.DataBind();
            Lmsg.Text = "";
        }
        else
        {
            RoomsDataList.DataSource = null;
            RoomsDataList.DataBind();
            Lmsg.Text = "Record not found";
        }

    }
}