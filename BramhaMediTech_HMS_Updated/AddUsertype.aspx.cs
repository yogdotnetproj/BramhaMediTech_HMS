using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Collections;


public partial class AddUsertype : System.Web.UI.Page
{
    AddUserType_C ObjAddUserType = new AddUserType_C();
    TreeviewBind_C ObjTB = new TreeviewBind_C();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {

        Page.SetFocus(txtuserType);
        if (!IsPostBack)
        {

            try
            {
               Label2.Visible = false;
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
            dt = ObjAddUserType.getuserType();
            GV_UserType.DataSource = dt;
            GV_UserType.DataBind();
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
    protected void Button2_Click(object sender, EventArgs e)
    {
        txtuserType.Text = "";
        Label2.Visible = false;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToInt32(ViewState["Editflag"]) == 1)
            {
                //SampleType_Bal_C sam = new SampleType_Bal_C();
                ObjAddUserType.Update(Convert.ToInt32(ViewState["rid"]), txtuserType.Text, Convert.ToInt32(Session["Branchid"]));
                Label2.Visible = true;
                Label2.Text = "Record Updated successfully.";
                bindgrid();
                ViewState["Editflag"] = null;

            }
            else
            {
                if (ObjAddUserType.isUsertypepeeExists(txtuserType.Text, Convert.ToInt32(Session["Branchid"])))
                {
                    Label2.Visible = true;
                    Label2.Text = "user already exist.";
                    txtuserType.Focus();
                    return;
                }
                else
                {
                    Label2.Visible = false;
                }

                ObjAddUserType.Usertype = txtuserType.Text;
                ObjAddUserType.P_username = Convert.ToString(Session["username"]);
                ObjAddUserType.Insert(Convert.ToInt32(Session["Branchid"]));
                Label2.Visible = true;
                Label2.Text = "Record save successfully.";
                bindgrid();

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
    protected void GV_UserType_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            ViewState["rid"] = GV_UserType.DataKeys[e.NewEditIndex].Value;
            //ObjAddUserType samp = new ObjAddUserType(Convert.ToInt32(ViewState["rid"]), Convert.ToInt32(Session["Branchid"]));
            ObjAddUserType.Userright_Bal_C(Convert.ToInt32(ViewState["rid"]), Convert.ToInt32(Session["Branchid"]));
            txtuserType.Text = ObjAddUserType.Usertype;
            ViewState["Editflag"] = 1;

            Label2.Visible = false;
            e.Cancel = true;
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
    protected void GV_UserType_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GV_UserType.PageIndex = e.NewPageIndex;
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
    protected void GV_UserType_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int reaid = Convert.ToInt32(GV_UserType.DataKeys[e.RowIndex].Value);

            ObjAddUserType.delete(reaid, Convert.ToInt32(Session["Branchid"]));
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