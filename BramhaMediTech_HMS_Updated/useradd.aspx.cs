using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Data.Odbc;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Web.Management;
using System.Data;
using System.Web.Services;
using System.Web.Script.Services;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


public partial class useradd :BasePage
{
    TreeviewBind_C ObjTB = new TreeviewBind_C();
    //dbconnection dc = new dbconnection();
    DataTable dt = new DataTable();
    BELEmpReg objBELEmpReg = new BELEmpReg();
    DALEmpReg objDALEmpReg = new DALEmpReg();
    createuserTable_Bal_C Objcutb = new createuserTable_Bal_C();
    createuserTable_Bal_C au = new createuserTable_Bal_C();
    string errst;
    protected void Page_Load(object sender, EventArgs e)
    {
        ViewState["Doctor"] = "";
        txtuname.Attributes.Add("onkeyup", "GetPwd();");
        if (!this.IsPostBack)
        {
           // LUNAME.Text = Convert.ToString(Session["username"]);
            //LblDCName.Text = Convert.ToString(Session["Bannername"]);
            //LblDCCode.Text = Convert.ToString(Session["BannerCode"]);
            dt = new DataTable();
            dt = ObjTB.BindMainMenu(Convert.ToString(Session["username"]), Convert.ToString(Session["password"]));
          //  this.PopulateTreeView(dt, 0, null);
            filldrop();
            filllab();
            ViewState["Save"] = "save";
            ViewState["Doctor"] = "0";
            if (Request.QueryString["id"] != null)
            {
                ViewState["Save"] = "Edit";
                EditData();
            }
        }
    }
    //private void PopulateTreeView(DataTable dtparent, int Parentid, TreeNode treeNode)
    //{
    //    foreach (DataRow row in dtparent.Rows)
    //    {
    //        TreeNode child = new TreeNode
    //        {
    //            Text = row["MenuName"].ToString(),
    //            Value = row["MenuID"].ToString()

    //        };
    //        if (Parentid == 0)
    //        {
    //            TrMenu.Nodes.Add(child);
    //            DataTable dtchild = new DataTable();
    //            dtchild = ObjTB.BindChildMenu(child.Value, Convert.ToString(Session["username"]), Convert.ToString(Session["password"]));
    //            PopulateTreeView(dtchild, int.Parse(child.Value), child);

    //        }
    //        else
    //        {
    //            treeNode.ChildNodes.Add(child);
    //        }

    //    }
    //}


    //protected void TrMenu_SelectedNodeChanged(object sender, EventArgs e)
    //{
    //    int tId = Convert.ToInt32(TrMenu.SelectedValue);
    //    DataTable dtform = new DataTable();
    //    dtform = ObjTB.BindForm(tId);
    //    if (dtform.Rows.Count > 0)
    //    {
    //        Response.Redirect(dtform.Rows[0]["SubMenuNavigateURL"].ToString());
    //    }
    //}

    [WebMethod]
    [ScriptMethod]
    public static string[] FillInfo(string prefixText, int count)
   {

        SqlConnection con = DataAccess.ConInitForDC();

       
        SqlDataAdapter sda = null;
        
        //Page page = (Page)HttpContext.Current.Handler;
        //RadioButtonList RblDType = (RadioButtonList)page.FindControl("RblDType");

      
       // if(RblDType.SelectedValue == "1")
        //{
            sda = new SqlDataAdapter("select DrId,EmpName from HospEmpMst where (EmpName like N'" + prefixText + "%')  or (DrId like N'%" + prefixText + "%')  ", con);
        //}
        //else
        //{
        //    sda = new SqlDataAdapter("select  DrId,EmpName from HospEmpMst where EmployeeType='Other' and ((EmpName like N'" + prefixText + "%')  or (DrId like N'%" + prefixText + "%'))   ", con);
        //}
        DataTable dt = new DataTable();
        sda.Fill(dt);
        string[] tests = new String[dt.Rows.Count];
        int i = 0;
        foreach (DataRow dr in dt.Rows)
        {
            tests.SetValue(dr["DrId"] + " = " + dr["EmpName"], i);
            i++;
        }

        return tests;
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Server.Transfer("~/Adduser.aspx");
    }
    public void EditData()
    {
        DataTable dt = new DataTable();
        dt = au.Get_AlluserDetails(Convert.ToInt32(Request.QueryString["id"]), Convert.ToInt32(Session["Branchid"].ToString()));
        if (dt.Rows.Count > 0)
        {
            txtmobile.Text = Convert.ToString(dt.Rows[0]["MobileNo"]);
            txtphone.Text = Convert.ToString(dt.Rows[0]["PhoneNumber"]);
            txtemail.Text = Convert.ToString(dt.Rows[0]["Email"]);
            txtuname.Text = Convert.ToString(dt.Rows[0]["username"]);
            txtpwd.Text = Convert.ToString(dt.Rows[0]["password"]);
            ddltype.SelectedValue = Convert.ToString(dt.Rows[0]["RollId"]);
            ddltype.SelectedItem.Text = Convert.ToString(dt.Rows[0]["Usertype"]);
            ddldept.SelectedValue = Convert.ToString(dt.Rows[0]["maindeptid"]);
            ddlEmpCategory.SelectedValue = Convert.ToString(dt.Rows[0]["catagory"]);
            ddlModuleName.SelectedValue = Convert.ToString(dt.Rows[0]["ModuleName"]);
            if (Convert.ToInt32(dt.Rows[0]["DRid"]) > 0)
            {
                ddlempname.Text = Convert.ToString(dt.Rows[0]["Name"]);
                ddlempname.Visible = true;
                //ddlempname1.Visible = false;
                RblDType.SelectedValue = "1";
                DocDeg.Visible = true;
                txtDoctorDegree.Text = Convert.ToString(dt.Rows[0]["Degree"]);
                ViewState["DoctorId"] = Convert.ToString(dt.Rows[0]["DRid"]);
                //Image1.ImageAlign=
            }
            else
            {
               ddlempname.Text = Convert.ToString(dt.Rows[0]["Name"]);
                ddlempname.Visible = true;
                //ddlempname1.Visible = true;
                RblDType.SelectedValue = "0";
                ViewState["DoctorId"] = "0";
            }
            if (Convert.ToString(dt.Rows[0]["CenterCode"]) != "0")
            {
                ddlCentercode.SelectedItem.Text = Convert.ToString(dt.Rows[0]["CenterCode"]);
                Collid.Visible = true;
            }
            else
            {
                ddlCentercode.SelectedItem.Text = Convert.ToString(dt.Rows[0]["CenterCode"]);
                Collid.Visible = false;
            }
            if (Convert.ToBoolean(dt.Rows[0]["isactive"]) == true)
            {
                ChkIsActive.Checked = true;
            }
            else
            {
                ChkIsActive.Checked = false;
            }
            txtuname.Enabled = false;
            ViewState["Save"] = "Edit";
        }

    }
    protected void CmdSave_Click(object sender, EventArgs e)
    {
        try
        {

            if (txtuname.Text.Trim() == "" && txtpwd.Text.Trim() == "")
            {
                LBLMsg.Text = "Enter user name or password";
                return;
            }
            else
            { errst = ""; }
            int mx = 0, CheckUsertype = 0;
            dt = au.ReadTable("select * from CTUser where username='" + txtuname.Text.Trim() + "'");
            if (dt.Rows.Count > 5)
            {
                LBLMsg.Text = "User Already Exists";
            }
            else
            {
                if (RblDType.SelectedValue == "1")
                {
                    CheckUsertype = 1;
                }
                else
                {
                    //ddlempname.Text = ddlempname1.Text;
                    CheckUsertype = 0;
                }
                //if (ddldept.SelectedIndex != 0 && ddlempname.Text != "")
                //{
                string Coolcode = "";
                if (ddlCentercode.SelectedIndex > 0)
                {
                    Coolcode = ddlCentercode.SelectedValue;
                }
                else
                {
                    Coolcode = "0";
                }

                // errst = dc.ExecuteSql("insert into users(username,passwd,dept,email,phone,mobile,type,secu_que,secu_ans,EmpName,branchid,mastmodeid,Address,RollId,CollCodeid,CheckUsertype ) values('" + txtuname.Text + "','" + txtpwd.Text + "','" + ddldept.SelectedValue + "','" + txtemail.Text + "','" + txtphone.Text + "','" + txtmobile.Text + "','" + ddltype.SelectedItem.Text + "','" + "" + "','" + "" + "','" + ddlempname.Text + "','" + Session["Branchid"].ToString() + "','" + 2 + "','" + "" + "','" + ddltype.SelectedValue + "','" + Coolcode + "' ,'" + CheckUsertype + "' )");
                string UName = "";
                if (Convert.ToString(ViewState["Save"]) == "save")
                {
                    UName = txtuname.Text.Trim();
                }
                else
                {
                    UName = "NNNNN";
                }
                if (createuserTable_Bal_C.isUserNameExists(UName))
                {

                    LBLMsg.Text = "User Already Exists.";
                    return;
                }
                else
                {
                    au.Name = txtuname.Text;
                    au.Username = txtuname.Text;
                    au.Password = txtpwd.Text;
                    if (ddltype.SelectedItem.Text != "Select UserType")
                    {
                        au.Usertype = ddltype.SelectedItem.Text;
                        au.P_RoleId = Convert.ToInt32(ddltype.SelectedValue);
                    }
                    else
                    {
                        au.Usertype = "";
                        au.P_RoleId = 0;
                    }

                    au.P_branchid = Convert.ToInt32(Session["Branchid"].ToString());

                    if (ddlCentercode.SelectedIndex > 0)
                    {
                        au.LBcode = ddlCentercode.SelectedValue;
                    }
                    else
                    {
                        au.LBcode = ddlLab.SelectedValue;
                    }
                    au.maindeptid = Convert.ToInt32(ddldept.SelectedValue);
                    au.EmpId = Convert.ToInt32(ViewState["DocCode"]);
                    //if (ddldept.SelectedItem.Text.ToUpper() == "RADIOLOGY")
                    //{
                    //    au.maindeptid = 1;
                    //}
                    //if (ddldept.SelectedItem.Text.ToUpper() == "PATHOLOGY")
                    //{
                    //    au.maindeptid = 2;
                    //}
                    //if (ddldept.SelectedItem.Text == "Select Department")
                    //{
                    //    au.maindeptid = 0;
                    //}
                    au.P_Email = txtemail.Text;
                    au.P_PhoneNo = txtphone.Text;
                    au.P_MobileNo = txtmobile.Text;
                    au.P_catagory = ddlEmpCategory.SelectedValue;
                    au.P_ModuleName = ddlModuleName.SelectedValue;
                    if (ChkIsActive.Checked == true)
                    {
                        au.P_ISActive = true;
                    }
                    else
                    {
                        au.P_ISActive = false;
                    }

                    if (RblDType.SelectedValue == "0")
                    {
                        au.CenterCode = Convert.ToString(ddlCentercode.SelectedValue);
                        au.Name = ddlempname.Text;
                        if (Convert.ToString(ViewState["Save"]) != "save")
                        {

                            au.Insert_UpdateCTUser(Convert.ToInt32(Request.QueryString["id"]));
                        }
                        else
                        {
                            au.Insert();//
                        }
                    }
                    else
                    {
                        int mno = au.getMaxNumber_signid(Convert.ToInt32(Session["Branchid"]));
                        au.Drid = mno;
                        au.Drid = mno;
                        au.CenterCode = Convert.ToString("");
                        if (ddltype.SelectedItem.Text == "Reference Doctor")
                        {
                            au.Name = Convert.ToString(ViewState["DocCode"]);
                        }
                        else
                        {
                            au.Name = ddlempname.Text;
                        }
                        au.Username = Convert.ToString(Session["username"]);
                        au.Username = Convert.ToString(txtuname.Text);
                        au.CenterCode = "0";

                        if (Convert.ToString(ViewState["Save"]) != "save")
                        {

                            au.Insert_UpdateCTUser(Convert.ToInt32(Request.QueryString["id"]));
                            au.Degree = txtDoctorDegree.Text;
                            FileUpload img = (FileUpload)FUFileUpload;
                            Byte[] imgByte = null;
                            if (img.HasFile && img.PostedFile != null)
                            {
                                //To create a PostedFile
                                HttpPostedFile File = FUFileUpload.PostedFile;
                                //Create byte Array with file len
                                imgByte = new Byte[File.ContentLength];
                                //force the control to load data in array
                                File.InputStream.Read(imgByte, 0, File.ContentLength);
                                SqlConnection conn = DataAccess.ConInitForDC();
                                SqlCommand sc = new SqlCommand("update   DRST set signatureid=@signatureid,Drsignature=@Drsignature,[username]=@username,[branchid]=@branchid,Degree=@Degree,SignPicture=@SignPicture where signatureid= '" + ViewState["DoctorId"] + "'  ", conn);
                                //  " values(@signatureid,@Drsignature,@username,@branchid,@Degree,@SignPicture)", conn);
                                sc.Parameters.AddWithValue("@signatureid", ViewState["DoctorId"]);
                                sc.Parameters.AddWithValue("@Drsignature", au.Name);
                                sc.Parameters.AddWithValue("@username", au.Username);
                                sc.Parameters.AddWithValue("@branchid", au.P_branchid);
                                sc.Parameters.AddWithValue("@Degree", au.Degree);
                                sc.Parameters.AddWithValue("@SignPicture", imgByte);

                                conn.Open();
                                sc.ExecuteNonQuery();
                                conn.Dispose();
                            }
                            else
                            {
                                // au.SignPic = imgByte;
                                SqlConnection conn = DataAccess.ConInitForDC();
                                SqlCommand sc = new SqlCommand("update   DRST set signatureid=@signatureid,Drsignature=@Drsignature,[username]=@username,[branchid]=@branchid,Degree=@Degree where signatureid= '" + ViewState["DoctorId"] + "'  ", conn);
                                //  " values(@signatureid,@Drsignature,@username,@branchid,@Degree,@SignPicture)", conn);
                                sc.Parameters.AddWithValue("@signatureid", ViewState["DoctorId"]);
                                sc.Parameters.AddWithValue("@Drsignature", au.Name);
                                sc.Parameters.AddWithValue("@username", au.Username);
                                sc.Parameters.AddWithValue("@branchid", au.P_branchid);
                                sc.Parameters.AddWithValue("@Degree", au.Degree);
                                //  sc.Parameters.AddWithValue("@SignPicture", imgByte);

                                conn.Open();
                                sc.ExecuteNonQuery();
                                conn.Dispose();
                            }
                            //au.Insert_Main
                        }
                        else
                        {
                            au.Degree = txtDoctorDegree.Text;
                            //string filePath = FUFileUpload.PostedFile.FileName;
                            //string filename = Path.GetFileName(filePath);
                            //string ext = Path.GetExtension(filename);
                            //string contenttype = String.Empty;

                            //Stream fs = FUFileUpload.PostedFile.InputStream;
                            //BinaryReader br = new BinaryReader(fs);
                            //Byte[] bytes = br.ReadBytes((Int32)fs.Length);

                            FileUpload img = (FileUpload)FUFileUpload;
                            Byte[] imgByte = null;
                            if (img.HasFile && img.PostedFile != null)
                            {
                                //To create a PostedFile
                                HttpPostedFile File = FUFileUpload.PostedFile;
                                //Create byte Array with file len
                                imgByte = new Byte[File.ContentLength];
                                //force the control to load data in array
                                File.InputStream.Read(imgByte, 0, File.ContentLength);
                                SqlConnection conn = DataAccess.ConInitForDC();
                                SqlCommand sc = new SqlCommand("Insert into DRST (signatureid,Drsignature,[username],[branchid],Degree,SignPicture) " +
                              " values(@signatureid,@Drsignature,@username,@branchid,@Degree,@SignPicture)", conn);
                                sc.Parameters.AddWithValue("@signatureid", au.Drid);
                                sc.Parameters.AddWithValue("@Drsignature", au.Name);
                                sc.Parameters.AddWithValue("@username", au.Username);
                                sc.Parameters.AddWithValue("@branchid", au.P_branchid);
                                sc.Parameters.AddWithValue("@Degree", au.Degree);

                                sc.Parameters.AddWithValue("@SignPicture", imgByte);

                                conn.Open();
                                sc.ExecuteNonQuery();
                                conn.Dispose();
                            }
                            else
                            {
                                // au.SignPic = imgByte;
                                SqlConnection conn = DataAccess.ConInitForDC();
                                SqlCommand sc = new SqlCommand("Insert into DRST (signatureid,Drsignature,[username],[branchid],Degree) " +
                              " values(@signatureid,@Drsignature,@username,@branchid,@Degree)", conn);
                                sc.Parameters.AddWithValue("@signatureid", au.Drid);
                                sc.Parameters.AddWithValue("@Drsignature", au.Name);
                                sc.Parameters.AddWithValue("@username", au.Username);
                                sc.Parameters.AddWithValue("@branchid", au.P_branchid);
                                sc.Parameters.AddWithValue("@Degree", au.Degree);

                                // sc.Parameters.AddWithValue("@SignPicture", imgByte);

                                conn.Open();
                                sc.ExecuteNonQuery();
                                conn.Dispose();
                            }
                           // au.Insert_MainDoctor();
                            au.Insert();//
                        }
                       //  au.UpdateDoctorUserName(txtuname.Text, txtpwd.Text, Convert.ToString(ViewState["DocCode"]), Convert.ToInt32(Session["Branchid"]));
                    }
                    clear();
                    //Server.Transfer("~/Adduser.aspx");
                    Response.Redirect("~/Adduser.aspx");
                }

            }

        }
        catch (Exception ex)
        {
            if (ex.Message.Equals("Exception aborted."))
            {
                return;
            }
            else
            {
                //Response.Cookies["error"].Value = ex.Message;
               // Server.Transfer("~/ErrorMessage.aspx");
            }
        }
    }
    public void filldrop()
    {
        // ddldept.DataSource = dc.FillDept(Session["Branchid"].ToString(), "2");
        ddldept.DataSource = Objcutb.FillDept_New(Session["Branchid"].ToString());//, "2");
        ddldept.DataValueField = "DeptId";
        ddldept.DataTextField = "DeptName";
        ddldept.DataBind();
        ddldept.Items.Insert(0, "Select Department");
        ddldept.Items[0].Value = "0";
        ddldept.SelectedIndex = 0;

        ddlCentercode.DataSource = Objcutb.Fill_CenterCode(Session["Branchid"].ToString(), "2");
        ddlCentercode.DataValueField = "DoctorCode";
        ddlCentercode.DataTextField = "DoctorName";
        ddlCentercode.DataBind();
        ddlCentercode.Items.Insert(0, "Select Center");
        ddlCentercode.Items[0].Value = "0";
        ddlCentercode.SelectedIndex = 0;


        ddltype.DataSource = Objcutb.FillUserroles(Session["Branchid"].ToString(), "2");
        ddltype.DataValueField = "ROLLID";
        ddltype.DataTextField = "ROLENAME";
        ddltype.DataBind();
        ddltype.Items.Insert(0, "Select UserType");
        ddltype.Items[0].Value = "0";
        ddltype.SelectedIndex = -1;
    }
    public void filllab()
    {
        ddlLab.DataSource = Objcutb.FillLab(Session["Branchid"].ToString());
        ddlLab.DataValueField = "DoctorCode";
        ddlLab.DataTextField = "DoctorName";
        ddlLab.DataBind();
        ddlLab.Items.Insert(0, "select");
        ddlLab.Items[0].Value = "";
        ddlLab.SelectedIndex = 0;


    }
    protected void ddldept_SelectedIndexChanged(object sender, EventArgs e)
    {

        //ddlempname.DataSource = dc.FillEmpName(ddldept.SelectedValue);
        //ddlempname.DataTextField = "name1";
        //ddlempname.DataValueField = "pno";
        //ddlempname.DataBind();
        //ddlempname.Items.Insert(0, "Select Employee");
        //ddlempname.SelectedIndex = 0;
    }


    protected void lnkavail_Click(object sender, EventArgs e)
    {
        dt = au.ReadTable("select * from CTuser where username='" + txtuname.Text + "'");
        if (dt.Rows.Count > 0)
        {
            lbluser.Visible = true;
            txtuname.Text = "";
            txtpwd.Text = "";
        }
        else
        {
            lbluser.Visible = false;
        }
    }
    public void clear()
    {
        txtpwd.Text = "";
        txtuname.Text = "";
        txtphone.Text = "";
        txtmobile.Text = "";
        txtemail.Text = "";
        // txtaddress.Text = "";

    }
    protected void ddltype_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddltype.SelectedItem.Text == "Collection Center" || ddltype.SelectedItem.Text == "CollectionCenter")
        {
            Collid.Visible = true;
            DocDeg.Visible = false;
            //  DocDegsig.Visible = false;
        }
        if (ddltype.SelectedItem.Text == "Main Doctor" || ddltype.SelectedItem.Text == "MainDoctor" || ddltype.SelectedItem.Text == "Technician" || ddltype.SelectedItem.Text == "Doctor")
        {
            DocDeg.Visible = true;
            // DocDegsig.Visible = true;
            Collid.Visible = false;
        }
    }
    protected void ddlempname_TextChanged(object sender, EventArgs e)
    {
        if (ddlempname.Text != "")
        {
            
            string[] empname = ddlempname.Text.Split('=');
          
                if (empname.Length > 1)
                {
                    ViewState["DocCode"] = empname[0];
                    ViewState["DocName"] = empname[1];
                    ddlempname.Text = empname[1];
                    FillInformation(Convert.ToInt32(ViewState["DocCode"]));
                }
                else
                {
                    ViewState["DocCode"] = "";
                    ViewState["DocName"] = "";
                }
            
        }

    }

    public void FillInformation(int EmpId)
    {
        objBELEmpReg = objDALEmpReg.SelectOneEmpMaster(EmpId);
          ddlEmpCategory.SelectedValue=objBELEmpReg.EmployeeType;
          ddldept.SelectedValue = Convert.ToString(objBELEmpReg.DeptId);
    }
    protected void RblDType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RblDType.SelectedValue == "1")
        {
            ViewState["Doctor"]= "1";

        }
        else
        {
            ViewState["Doctor"] = "0";

        }
    }

    protected void btnreport_Click(object sender, EventArgs e)
    {
        //string sql = "";
        //ReportParameterClass.ReportType = "UserDetaila";


        //Session.Add("rptsql", sql);
        //Session["rptname"] = Server.MapPath("~/DiagnosticReport/Rpt_UserDetaila.rpt");
        //Session["reportname"] = "UserDetaila";
        //Session["RPTFORMAT"] = "pdf";

        //ReportParameterClass.SelectionFormula = sql;
        //string close = "<script language='javascript'>javascript:OpenReport();</script>";
        //Type title1 = this.GetType();
        //Page.ClientScript.RegisterStartupScript(title1, "", close);
    }

}