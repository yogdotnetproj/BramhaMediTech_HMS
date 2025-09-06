using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Login :BasePage
{
    TreeviewBind_C ObjTB = new TreeviewBind_C(); 
    LoginDetails_b ld = new LoginDetails_b();
    financialYear_b finyr = new financialYear_b();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            //Session.RemoveAll();
            //Session.Abandon();

           // ModalPopupExtender1.Hide();
        }

        txtUName.Focus();
        //if (Convert.ToString( Request.QueryString["Activation"]) == "Yes")
        //{
        //   // ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Contact to system administrator.');", true);
        //}
      // string Currentdate=DateTime.Now.ToString("dd/MM/yyyy");
      //   string Currentdate = Date.getdate().ToString("dd/MM/yyyy");
         //if (Convert.ToDateTime(Currentdate) >= Convert.ToDateTime("26 /09/ 2019") && Convert.ToDateTime(Currentdate) < Convert.ToDateTime("26 / 10 / 2019"))
         //{
         //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Software will expire few days,please contact to system administrator.');", true);
         //}
         //if (Convert.ToDateTime(Currentdate) >= Convert.ToDateTime("06 /09/ 2025") && Convert.ToDateTime(Currentdate) < Convert.ToDateTime("26 /09/ 2025"))
         //{
         //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('contact to system administrator.');", true);
         //}

       // */__________________________________________________________________________________________________/*//
         //if (Convert.ToDateTime(Currentdate) >= Convert.ToDateTime("28 /04/ 2017") )
         //{
         //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Contact to system administrator.');", true);
             
         //}
         //string BCount = Patmst_New_Bal_C.PatientCountBanner(1);
         //if (Convert.ToInt32(BCount) > 210 && Convert.ToInt32(BCount) < 310)
         //{
         //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Software will expire few days,please contact to system administrator.');", true);
         //}
        // */__________________________________________________________________________________________________/*//
    }
    protected void btnChangepw_Click(object sender, EventArgs e)
    {
        // Response.Redirect("ChangePasswordNew.aspx");
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        //string Currentdate = Date.getdate().ToString("dd/MM/yyyy");
        //if (Convert.ToDateTime(Currentdate) >= Convert.ToDateTime("26 /10/ 2025"))
        //{
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Contact to system administrator.');", true);
        //    return;
        //} //31-10-2018
      DataTable  dtban = ObjTB.Bindbanner();
      Session["Bannername"] = Convert.ToString(dtban.Rows[0]["BannerName"]).Trim();
      Session["BannerCode"] = Convert.ToString(dtban.Rows[0]["BannerName"]).Trim();
       
        bool ChangePass = true;
        if (txtUName.Text == "")
        {
            return;
        }
       

      

        ObjTB.AutoDischarge();
        ObjTB.AutoAdmited();
        bool login = false;
        Session["usertype"] = null;
        Session["username"] = null;
        Session["pscStatus"] = null;
        Session["LabCode"] = null;
        Session["LoginTime"] = null;
        Session["LoginDate"] = null;
       
        Session["distid"] = null;

       // Session["LoginTime"] = Date.getTime();
       // Session["LoginDate"] = Date.getdate().ToString("dd/MM/yyyy"); //31-10-2018
            createuserTable_Bal_C u = new createuserTable_Bal_C(txtUName.Text.Trim(), txtPassword.Text.Trim());
           // if (u.Username != "")
            if (Convert.ToString( u.Username) != "")          
            {
                Session["password"] = txtPassword.Text.Trim();
                Session["Branchid"] = u.P_branchid;
                Session["username"] = txtUName.Text.Trim();
                Session["usertype"] = u.Usertype;
              //  Session["Branchid"] = null;
                Session["UserId"] = u.UserId;
                Session["FId"] = "1";
                Session["DigModule"] = "1";
                Session["EmpId"] = u.EmpId;
                Session["Name"] = u.Name;
                Session["Parameter"] = "NO";
                if (u.Usertype == "Patient" || u.Usertype == "patient")
                {
                    Server.Transfer("PatientPortal.aspx", false);
                }
                else
                {
                    ChangePass = ObjTB.isChangepassword(txtUName.Text.Trim());
                }
                if (ChangePass == false)
                {
                   // Server.Transfer("ChangePassword.aspx",false);
                }
                if (u.P_ModuleName == "HMS")
                {
                    Server.Transfer("~/HomeTemp.aspx", true);
                   // Response.Redirect("~/Lab/Home1.aspx?UserType=" + Session["usertype"] + " &FID=" + Session["FId"] + "&username=" + Session["username"] + "&HMS=Yes ",false);

                }
                else if (u.P_ModuleName == "Pathology")
                {
                    //Server.Transfer("~/Home.aspx", true);
                   // Response.Redirect("~/Pathology/Home1.aspx?UserType=" + Session["usertype"] + " &FID=" + Session["FId"] + "&username=" + Session["username"] + "&HMS=Yes ", false);
                    string LabName = "Pathology";
                    Response.Redirect("~/Pathology/Home1.aspx?UserType=" + Session["usertype"] + " &FID=" + Session["FId"] + "&username=" + Session["username"] + "&LabName=" + LabName + "&HMS=Yes ", true);

                }
                else if (u.P_ModuleName == "Radiology")
                {
                    //Server.Transfer("~/Home.aspx", true);
                    //Response.Redirect("~/Radiology/Home1.aspx?UserType=" + Session["usertype"] + " &FID=" + Session["FId"] + "&username=" + Session["username"] + "&HMS=Yes ", false);
                    string LabName = "Radiology";
                    Response.Redirect("~/Radiology/Home1.aspx?UserType=" + Session["usertype"] + " &FID=" + Session["FId"] + "&username=" + Session["username"] + "&LabName=" + LabName + "&HMS=Yes ", true);

                }
                else if (u.P_ModuleName == "Pharmacy")
                {
                    Response.Redirect("~/Pharmacy/Home.aspx?UserType=" + Session["usertype"] + " &FID=" + Session["FId"] + "&username=" + Session["username"] + "&HMS=Yes ", true);

                }
                else if (u.P_ModuleName == "Inventory")
                {
                    Response.Redirect("~/Inventory/Home.aspx?UserType=" + Session["usertype"] + " &FID=" + Session["FId"] + "&username=" + Session["username"] + "&HMS=Yes ", true);

                }
                else
                {
                    // Server.Transfer("~/Home.aspx", true);
                    Server.Transfer("~/MainHomePage1.aspx", true);
                }
                
            }
            else
            {
                lblerrorLogin.Text = "Username and Password does not Exist!!";
                return;
            }
    }


    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Session["usertype"] = null;
        Session["username"] = null;
        
        txtUName.Text = "";
        txtPassword.Text = "";
    }    
}