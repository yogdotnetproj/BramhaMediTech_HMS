using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Showpackage : System.Web.UI.Page
{
    TreeviewBind_C ObjTB = new TreeviewBind_C();
    dbconnection dc = new dbconnection();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {

            try
            {                
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
    }
 
    private void bindgrid()
    {
        try
        {
            GV_ShowPackage.DataSource = PackagenewHMS_Bal_C.getPackGroups(Convert.ToInt32(Session["Branchid"]), Convert.ToInt32(Session["DigModule"]));
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
    protected void GV_ShowPackage_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            string gcode = GV_ShowPackage.Rows[e.NewEditIndex].Cells[1].Text;
            Response.Redirect("CreatePackage.aspx?PackageCode=" + gcode);
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
        try
        {
            if (e.Row.RowIndex == -1)
                return;

            string groupcd = e.Row.Cells[1].Text.Trim();
            string MT_Code = "", testNames = "";

            int i = 0;
            IEnumerator ie = PackageLHMS_Bal_C.Get_PackageDetails(groupcd, Convert.ToInt32(Session["Branchid"])).GetEnumerator();
            while (ie.MoveNext())
            {
                i++;

                if (MT_Code == "")
                {
                    MT_Code = (ie.Current as PackageHMS_Bal_C).MTCode;
                    testNames = (ie.Current as PackageHMS_Bal_C).TestName;
                }
                else
                {
                    MT_Code = MT_Code + "," + (ie.Current as PackageHMS_Bal_C).MTCode;
                    testNames = testNames + "," + (ie.Current as PackageHMS_Bal_C).TestName;
                }
                if (i % 3 == 0)
                {
                    MT_Code = MT_Code + "<br>";
                    //testNames = testNames + "<br>";
                }

            }

            (e.Row.FindControl("lbltestNames") as Label).Text = testNames;
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
    protected void GV_ShowPackage_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            PackageNameHMS_Bal_C group1 = new PackageNameHMS_Bal_C();
            group1.PackageCode = GV_ShowPackage.Rows[e.RowIndex].Cells[1].Text;
            group1.Delete(Convert.ToInt32(Session["Branchid"]));
            group1.Delete_Details(Convert.ToInt32(Session["Branchid"]));
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
    protected void GV_ShowPackage_PageIndexChanged(object sender, EventArgs e)
    {

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


    protected void btnaddnew_Click(object sender, EventArgs e)
    {
        Response.Redirect("CreatePackage.aspx");
    }
  
}