using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Masters_ChangePassword :BasePage
{
    LoginDetails_b objBLLUser = new LoginDetails_b();
    public enum MessageType { Success, Error, Info, Warning };
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtOldPassWord.Text = "";
            txtNewPassword.Text = "";
            txtConfirmPassword.Text = "";
        }
    }
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
    protected void txtOldPassWord_TextChanged(object sender, EventArgs e)
    {

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
       
        int BranchId=Convert.ToInt32(Session["BranchId"]);
        objBLLUser.UpdatePassword(txtNewPassword.Text,txtOldPassWord.Text,Convert.ToInt32(Session["UserId"]),BranchId);
        lblMsg.Text = "Password Changed Successfully";
        ShowMessage("Password Changed Successfully!", MessageType.Success);
        Response.Redirect("Login.aspx", false);
        //Response.Redirect("~/Login.aspx");
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtOldPassWord.Text = "";
        txtNewPassword.Text = "";
        txtConfirmPassword.Text = "";
    }
    protected void txtConfirmPassword_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txtNewPassword_TextChanged(object sender, EventArgs e)
    {

    }
}