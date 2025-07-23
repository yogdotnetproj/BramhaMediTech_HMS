using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Net;
using System.IO;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Services;
using System.Web.Script.Services;
using System.Data.SqlClient;
using System.Drawing;

public partial class CreatePackage : System.Web.UI.Page
{
    TreeviewBind_C ObjTB = new TreeviewBind_C();
    short shHeadCnt = 0;
    string sSampleType = "";
    PackageName_Bal_C gnm = null;
    DataTable dt = new DataTable();
    dbconnection dc = new dbconnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.SetFocus(txtPackagename);


        if (!IsPostBack)
        {

            try
            {
                FillRateTypeDrop();
                if (Request.QueryString["PackageCode"] != null)
                {
                    string PakCode = Request.QueryString["PackageCode"].ToString();
                    PackageNameHMS_Bal_C PakC = new PackageNameHMS_Bal_C(PakCode);
                    txtPackagecode.Text = PakC.PackageCode;
                    txtPackagename.Text = PakC.PackageName;
                    ddlratelist.SelectedValue = PakC.RateType;
                    ddlType.SelectedValue = PakC.PackType;
                    txtrateamt.Text = Convert.ToString(PakC.PackageRateAmount);
                    bindgrid();
                    //IEnumerator ie = PackageLHMS_Bal_C.Get_PackageDetails(PakCode, Convert.ToInt32(Session["Branchid"])).GetEnumerator();
                    //while (ie.MoveNext())
                    //{
                    //    bool flag = false;
                    //    foreach (ListItem li in chkselectedtest.Items)
                    //    {
                    //        if (li.Value == (ie.Current as PackageHMS_Bal_C).MTCode)
                    //            flag = true;
                    //    }
                    //    if (!flag)
                    //    {
                    //        ListItem li = new ListItem((ie.Current as PackageHMS_Bal_C).TestName, (ie.Current as PackageHMS_Bal_C).MTCode);
                    //        li.Selected = true;
                    //        chkselectedtest.Items.Add(li);
                    //    }

                    //}

                    ViewState["upflag"] = 1;

                }

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
    }
    protected void FillRateTypeDrop()
    {
        DALBillCharges objDALBillCharges = new DALBillCharges();
        ddlratelist.DataSource = objDALBillCharges.FillRateTypeDrop();
        ddlratelist.DataValueField = "RateTypeId";
        ddlratelist.DataTextField = "RateType";
        ddlratelist.DataBind();
        ddlType.DataSource = objDALBillCharges.FillPackageTypeDrop();
        ddlType.DataValueField = "PackTypeId";
        ddlType.DataTextField = "PackType";
        ddlType.DataBind();

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtPackagecode.Text.Trim().Length != 4)
            {
                Label1.Visible = true;
                Label1.Text = "Enter code 4 digits code!";
                Label1.ForeColor = Color.Red;
                txtPackagecode.Focus();
                return;
            }
            else
            {
                Label1.Visible = false;
            }
            if (txttests.Text.Trim() =="")
            {
                Label1.Visible = true;
                Label1.Text = "Enter service name";
                Label1.ForeColor = Color.Red;
                txttests.Focus();
                return;
            }
            if (txtQty.Text.Trim() == "")
            {
                Label1.Visible = true;
                Label1.Text = "Enter Qty ";
                Label1.ForeColor = Color.Red;
                txtQty.Focus();
                return;
            }
            if (txtPackagecode.Text.Trim().Length != 4)
            {
                Label1.Visible = true;
                Label1.Text = "Enter code 4 digits code!";
                Label1.ForeColor = Color.Red;
                txtPackagecode.Focus();
                return;
            }
            if (Convert.ToInt32(ViewState["upflag"]) != 1)
            {
                //if (PackagenewHMS_Bal_C.CheckPackagecode_exist(txtPackagecode.Text.Trim(), Convert.ToInt32(Session["Branchid"])))
                //{
                //    Label1.Visible = true;
                //    Label1.Text = "Package Code already exist .";
                //    txtPackagecode.Focus();
                //    return;
                //}
                //else
                //{
                //    Label1.Visible = false;
                //}

                //if (PackagenewHMS_Bal_C.CheckPackagename_exist(txtPackagename.Text.Trim(), txtPackagecode.Text.Trim(), Convert.ToInt32(Session["Branchid"])))
                //{
                //    Label1.Visible = true;
                //    Label1.Text = "Package Name already exist.";
                //    txtPackagename.Focus();
                //    return;
                //}
                //else
                //{
                //    Label1.Visible = false;
                //}

                PackageNameHMS_Bal_C Pak_C = new PackageNameHMS_Bal_C();
                Pak_C.PackageCode = txtPackagecode.Text.Trim();
                Pak_C.PackageName = txtPackagename.Text.Trim();
                Pak_C.RateType = Convert.ToString(ddlratelist.SelectedValue);
                Pak_C.PackType = Convert.ToString(ddlType.SelectedValue);
                if (txtrateamt.Text != "")
                {
                    Pak_C.PackageRateAmount = Convert.ToInt32(txtrateamt.Text);
                }
                else
                {
                    Pak_C.PackageRateAmount = 0;

                }
                Pak_C.Patregdate = Date.getOnlydate();


                Pak_C.P_username = Convert.ToString(Session["username"]);
                if (PackagenewHMS_Bal_C.CheckPackagecode_exist(txtPackagecode.Text.Trim(), Convert.ToInt32(Session["Branchid"])))
                {
                    //Label1.Visible = true;
                    //Label1.Text = "Package Code already exist .";
                    //txtPackagecode.Focus();
                    //return;
                }
                else
                {
                    Label1.Visible = false;
                    Pak_C.Insert(Convert.ToInt32(Session["Branchid"]));
                }

                

                //foreach (ListItem li in chkselectedtest.Items)
                //{
                //    if (li.Selected)
                //    {
                        PackageHMS_Bal_C Obj_PBC = new PackageHMS_Bal_C();
                        Obj_PBC.Patregdate = Date.getOnlydate();
                        Obj_PBC.PackageCode = txtPackagecode.Text.Trim();
                        Obj_PBC.PackageName = txtPackagename.Text.Trim();

                        PackageHMS_Bal_C MTC = new PackageHMS_Bal_C("", ddlratelist.SelectedValue, Convert.ToString( ViewState["BillServiceId"]), "", Convert.ToInt32(Session["Branchid"]));

                        Obj_PBC.TestName = MTC.TestName;
                        Obj_PBC.TestRate = MTC.TestRate;
                        Obj_PBC.MTCode = MTC.MTCode;
                        Obj_PBC.Qty =Convert.ToSingle(txtQty.Text);

                       
                       
                        Obj_PBC.P_username = Convert.ToString(Session["username"]);
                        Obj_PBC.Insert(Convert.ToInt32(Session["Branchid"]));
                //    }
                //}
                Label1.Visible = true;
                Label1.Text = "Record Saved Successfully";
            }
            else
            {
                PackageNameHMS_Bal_C Pak_C = new PackageNameHMS_Bal_C();
                Pak_C.PackageCode = txtPackagecode.Text.Trim();
                Pak_C.PackageName = txtPackagename.Text.Trim();
                if (txtrateamt.Text != "")
                {
                    Pak_C.PackageRateAmount = Convert.ToInt32(txtrateamt.Text);
                }
                else
                {
                    Pak_C.PackageRateAmount = 0;
                }
                Pak_C.Patregdate = Date.getOnlydate();

                Pak_C.P_username = Convert.ToString(Session["username"]);
                Pak_C.RateType = Convert.ToString(ddlratelist.SelectedValue);
                Pak_C.PackType = Convert.ToString(ddlType.SelectedValue);
                Pak_C.update(Request.QueryString["PackageCode"].ToString(), Convert.ToInt32(Session["Branchid"]));

                PackageHMS_Bal_C Pack_C = new PackageHMS_Bal_C();
              //  Pack_C.DeleteByPack_Code(Request.QueryString["PackageCode"].ToString(), Convert.ToInt32(Session["Branchid"]));

                //foreach (ListItem li in chkselectedtest.Items)
                //{
                //    if (li.Selected)
                //    {
                        PackageHMS_Bal_C Obj_PBC = new PackageHMS_Bal_C();
                        Obj_PBC.Patregdate = Date.getOnlydate();
                        Obj_PBC.PackageCode = txtPackagecode.Text.Trim();
                        Obj_PBC.PackageName = txtPackagename.Text.Trim();
                        Obj_PBC.Qty = Convert.ToSingle(txtQty.Text);
                        PackageHMS_Bal_C MTC = new PackageHMS_Bal_C("", ddlratelist.SelectedValue, Convert.ToString(ViewState["BillServiceId"]), "", Convert.ToInt32(Session["Branchid"]));
                       
                        Obj_PBC.TestName = MTC.TestName;
                        Obj_PBC.TestRate = MTC.TestRate;
                        Obj_PBC.MTCode = MTC.MTCode;
                        Obj_PBC.P_username = Convert.ToString(Session["username"]);
                        Obj_PBC.Insert(Convert.ToInt32(Session["Branchid"]));

                //    }
                //}
                Label1.Visible = true;
                Label1.Text = "Record update Successfully";
               

            }
            txttests.Text = "";
            txtQty.Text = "";
            bindgrid();
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


    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Showpackage.aspx");
    }
    protected void txtCode_TextChanged(object sender, EventArgs e)
    {
        
    }

    protected void txttests_TextChanged(object sender, EventArgs e)
    {
        string[] splittedtlcode;
        splittedtlcode = txttests.Text.Split('=');
        try
        {
            if (splittedtlcode.Length > 1)
            {
                ViewState["BillServiceId"] = splittedtlcode[0];
                txttests.Text = splittedtlcode[1];
                //bool flag = false;
                //foreach (ListItem li in chkselectedtest.Items)
                //{
                //    if (li.Value == splittedtlcode[0])
                //        flag = true;
                //}
                //if (!flag)
                //{
                //    if (splittedtlcode.Length > 2)
                //    {
                //        ListItem li1 = new ListItem(splittedtlcode[1] + ' ' + splittedtlcode[2], splittedtlcode[0]);
                //        li1.Selected = true;
                //        chkselectedtest.Items.Add(li1);
                //    }
                //    else
                //    {
                //        ListItem li = new ListItem(splittedtlcode[1], splittedtlcode[0]);
                //        li.Selected = true;
                //        chkselectedtest.Items.Add(li);
                //    }

                //}

                //  txttests.Text = "";
            }
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
    [WebMethod]
    [ScriptMethod]
    public static string[] FillTests(string prefixText, int count)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlDataAdapter sda = null;
        if (HttpContext.Current.Session["DigModule"] != null && HttpContext.Current.Session["DigModule"] != "0")
            sda = new SqlDataAdapter(" SELECT     distinct   BillService.BillServiceId,  BillService.ServiceName, BillSeviceCharges.rate FROM BillService INNER JOIN BillSeviceCharges ON BillService.BillServiceId = BillSeviceCharges.ServiceId  WHERE ( ServiceName like '%" + prefixText + "%')  order by ServiceName ", con);
        else
            sda = new SqlDataAdapter("SELECT     distinct   BillService.BillServiceId,  BillService.ServiceName, BillSeviceCharges.rate FROM BillService INNER JOIN BillSeviceCharges ON BillService.BillServiceId = BillSeviceCharges.ServiceId WHERE  ServiceName like '%" + prefixText + "%' order by ServiceName ", con);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        string[] tests = new String[dt.Rows.Count];
        int i = 0;
        foreach (DataRow dr in dt.Rows)
        {
            tests.SetValue(dr["BillServiceId"] + " = " + dr["ServiceName"], i);
            i++;
        }

        return tests;
    }
    private void bindgrid()
    {
        try
        {
            GV_ShowPackage.DataSource = PackagenewHMS_Bal_C.getPackGroupsdetail(Convert.ToInt32(Session["Branchid"]), Convert.ToInt32(Session["DigModule"]),txtPackagecode.Text);
            GV_ShowPackage.DataBind();
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
    protected void GV_ShowPackage_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GV_ShowPackage.PageIndex = e.NewPageIndex;
            bindgrid();
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
    protected void GV_ShowPackage_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void GV_ShowPackage_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            PackageNameHMS_Bal_C group1 = new PackageNameHMS_Bal_C();
            group1.PackageCode = GV_ShowPackage.Rows[e.RowIndex].Cells[1].Text;
           int ServiceId = Convert.ToInt32( GV_ShowPackage.Rows[e.RowIndex].Cells[6].Text);
           group1.Delete_DetailsPAckageservice(Convert.ToInt32(Session["Branchid"]), ServiceId);
            bindgrid();
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
    protected void GV_ShowPackage_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            string gcode = GV_ShowPackage.Rows[e.NewEditIndex].Cells[1].Text;
           // Response.Redirect("CreatePackage.aspx?PackageCode=" + gcode);
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
}