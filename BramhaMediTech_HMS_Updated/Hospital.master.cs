using System;
using System.Collections.Generic;
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
using System.Configuration;
using System.Web.Configuration;

public partial class Hospital : System.Web.UI.MasterPage
{
    TreeviewBind_C ObjTB = new TreeviewBind_C();
    string Username = "";
    protected void Page_Load(object sender, EventArgs e)
    {
      
        if (!IsPostBack)
        {
            Username = Convert.ToString(Session["username"]);

            
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
             UsernameLB2.Text = Convert.ToString(Session["Name"]);
            if (Convert.ToString(Session["username"]) != "" && Convert.ToString(Session["Branchid"]) != "")
            {
                LblUtype.Text = Convert.ToString(Session["username"]);
                DataTable dt = new DataTable();
               // dt = ObjTB.BindMainMenu(Convert.ToString(Session["username"]), Convert.ToString(Session["password"]));
                //this.PopulateTreeView(dt, 0, null);
                LoadSlideBar(Username, Convert.ToString(Session["ModuleId"]));
            }
            else
            {
                Server.Transfer("~/Login.aspx", true);
            }

        }
        else
        {
            LoadSlideBar(Username, Convert.ToString(Session["ModuleId"]));
        }
        if (Convert.ToString(Session["Branchid"]) == "0")
        {
            Server.Transfer("~/Login.aspx", true);
        }

    }

    //protected void Page_Load(object sender, EventArgs e)
    //{
    //    if (!this.IsPostBack)
    //    {
    //        DataTable dt = this.GetData("SELECT cId, cName FROM TopBill where [Pid] = 0");
    //        this.PopulateTreeView(dt, null);
    //    }
    //}

    private void PopulateTreeView(DataTable dtparent, int Parentid, TreeNode treeNode)
    {
        //foreach (DataRow row in dtParent.Rows)
        //{
        //    TreeNode child = new TreeNode
        //    {
        //        Text = row["MenuName"].ToString(),
        //        Value = row["MenuId"].ToString()
        //    };
        //    if (treeNode == null)
        //        TrMenu.Nodes.Add(child);
        //    else
        //        treeNode.ChildNodes.Add(child);
        //    DataTable dtChild = ObjTB.BindMainMenu(Convert.ToString(Session["UserName"]), Convert.ToString(Session["Password"]),Convert.ToString(child.Value));

        //   // DataTable dtChild = this.GetData("SELECT srNo,cid, cName FROM TopBill WHERE pid = " + child.Value);
        //    if (dtChild.Rows.Count != 0)
        //        PopulateTreeView(dtChild, child);
        //}

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
                dtchild = ObjTB.BindChildMenu(child.Value, Convert.ToString(Session["username"]), Convert.ToString(Session["password"]));
                PopulateTreeView(dtchild, int.Parse(child.Value), child);

            }
            else
            {
                treeNode.ChildNodes.Add(child);
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
    //            Value = row["MenuId"].ToString()

    //        };
    //        if (Parentid == 0)
    //        {
    //            TrMenu.Nodes.Add(child);
    //            DataTable dtchild = new DataTable();
    //            dtchild = ObjTB.BindChildMenu(child.Value, Convert.ToString(Session["UserName"]), Convert.ToString(Session["Password"]));
    //            PopulateTreeView(dtchild, int.Parse(child.Value), child);

    //        }
    //        else
    //        {
    //            treeNode.ChildNodes.Add(child);
    //            DataTable dtSubchild = new DataTable();
    //            dtSubchild=ObjTB.checkMenuIdExistInParent(Convert.ToInt32(row["MenuId"]));
    //            if (dtSubchild.Rows.Count > 0)
    //            {
    //                TrMenu.Nodes.Add(child);                   
    //                dtSubchild = ObjTB.BindChildMenu(child.Value, Convert.ToString(Session["UserName"]), Convert.ToString(Session["Password"]));               
    //                PopulateTreeView(dtSubchild, Convert.ToInt32(row["MenuId"]), child);
    //            }
    //        }

    //    }
    //}


    protected void TrMenu_SelectedNodeChanged(object sender, EventArgs e)
    {
        //int tId = Convert.ToInt32(TrMenu.SelectedValue);
        //DataTable dtform = new DataTable();
        //dtform = ObjTB.BindForm(tId);
        //if (dtform.Rows.Count > 0)
        //{
        //    if (Convert.ToString(dtform.Rows[0]["FormName"]) == "#")
        //    {
        //    }
        //    Response.Redirect(dtform.Rows[0]["FormName"].ToString());
        //}
        int tId = Convert.ToInt32(TrMenu.SelectedValue);
        DataTable dtform = new DataTable();
        dtform = ObjTB.BindForm(tId);
        if (dtform.Rows.Count > 0)
        {
            Response.Redirect(dtform.Rows[0]["SubMenuNavigateURL"].ToString());
        }
    }

    private void LoadSlideBar(string UserNm, string MainModule)
    {
        string SlideBarHtml = "";


        // UsernameLB.Text = UserNm;
        //UsernameLB2.Text = UserNm;
        DataTable MenuDt = new DataTable();

        // string MenuSQL = String.Format(@"SELECT Distinct MenuID,MenuName,icon from [dbo].[SlidBarVeiw] WHERE  username = '{0}' ORDER BY MenuID", UserNm);
        // string MenuSQL = String.Format(@"SELECT Distinct MenuID,MenuName,icon from [dbo].[TBL_MenuMaster] where Isactive=1 ORDER BY MenuID", UserNm); //  WHERE  username = '{0}' SlidBarVeiw
        string MenuSQL = "";
       if (Convert.ToString(Session["usertype"]).Trim() == "Administrator" || Convert.ToString(Session["usertype"]).Trim() == "Administrator" && MainModule == "0")
        {
            MenuSQL = String.Format(@"select MenuID , MenuName,icon from TBL_MenuMaster where Isactive=1 and ModuelName='HMS' ");
        }
       else if ((Convert.ToString(Session["usertype"]).ToUpper() == "Administrator") && MainModule != "0")
        {
            MenuSQL = String.Format(@"select MenuID , MenuName,icon from TBL_MenuMaster where Isactive=1 and ModuelName='HMS' ");// and Moduleid = '" + MainModule + "
        }
        //else if (MainModule != "0") 
        //{
        //    sda = new SqlDataAdapter("select MenuID , MenuName from TBL_MenuMaster where Isactive=1 and ModuleId='"+MainModule+"' ", con);
        //}
        else
        {
            MenuSQL = String.Format(@"SELECT DISTINCT    " +
                     "  TBL_MenuMaster.MenuID ,TBL_MenuMaster.MenuName,TBL_MenuMaster.icon  " +
                     "  FROM         Roleright INNER JOIN      " +
                     "  TBL_SubMenuMaster ON Roleright.FormId = TBL_SubMenuMaster.SubMenuID INNER JOIN  " +
                     "  TBL_MenuMaster ON TBL_SubMenuMaster.MenuID = TBL_MenuMaster.MenuID INNER JOIN   " +
                     "  CTuser ON Roleright.Usertypeid = CTuser.RollId      " +
                     "  WHERE     (CTuser.USERNAME = '" + Convert.ToString(Session["username"]) + "') AND (CTuser.password = '" + Convert.ToString(Session["password"]) + "') and  TBL_SubMenuMaster.Isvisible=1  " +
                     "  order by TBL_MenuMaster.MenuID   ");
        }
        string connectionString = ConfigurationManager.ConnectionStrings["DBHospital"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);

        SqlCommand cmd = new SqlCommand(MenuSQL, con);

        SqlDataAdapter Adp = new SqlDataAdapter(cmd);

        Adp.Fill(MenuDt);

        foreach (DataRow MainDr in MenuDt.Rows)
        {
            DataTable SubMenuDt = new DataTable();
            string MainMenuName = MainDr["MenuName"].ToString();
            string Menuid = MainDr["MenuID"].ToString();
            string icon = MainDr["icon"].ToString();
            SlideBarHtml += "<li>";
            SlideBarHtml += "<a href=" + (char)34 + "javascript:;" + (char)34 + "><i class=" + (char)34 + icon + (char)34 + "></i>";
            SlideBarHtml += "<span class=" + (char)34 + "nav-label" + (char)34 + ">" + MainMenuName + "</span><i class=" + (char)34 + "fa fa-angle-down arrow" + (char)34 + "></i></a>";
            SlideBarHtml += "<ul class=" + (char)34 + "nav-2-level collapse" + (char)34 + ">";

            // string SubMenuSQL = String.Format(@"SELECT Distinct SubMenuName,SubMenuNavigateURL,SubMenuID from [dbo].[SlidBarVeiw] WHERE  username = '{0}' and MenuName = '{1}' ORDER BY SubMenuID", UserNm, MainMenuName);
            //string SubMenuSQL = String.Format(@"SELECT Distinct SubMenuName,SubMenuNavigateURL,SubMenuID from TBL_SubMenuMaster INNER JOIN TBL_MenuMaster ON TBL_SubMenuMaster.MenuID = TBL_MenuMaster.MenuID WHERE   MenuName = '{1}' ORDER BY SubMenuID", UserNm, MainMenuName);//username = '{0}' and
            string SubMenuSQL = "";
            //if (USERNAME == "Admin" || USERNAME == "admin")
            if (Convert.ToString(Session["usertype"]).Trim() == "Administrator")
            {

                SubMenuSQL = String.Format(@"select SubMenuID as MenuID,SubMenuName ,SubMenuNavigateURL,TBL_MenuMaster.ModuelName from TBL_SubMenuMaster INNER JOIN TBL_MenuMaster ON TBL_SubMenuMaster.MenuID = TBL_MenuMaster.MenuID where TBL_MenuMaster.MenuID='" + Menuid + "' and   TBL_MenuMaster.ModuelName='HMS' and  TBL_SubMenuMaster.Isvisible=1 ", con);
            }
            else
            {
                SubMenuSQL = String.Format(@" SELECT DISTINCT TBL_SubMenuMaster.SubMenuID as MenuID, TBL_SubMenuMaster.SubMenuName  ,SubMenuNavigateURL ,TBL_MenuMaster.ModuelName " +
                            "   FROM         Roleright INNER JOIN      " +
                            "   TBL_SubMenuMaster ON Roleright.FormId = TBL_SubMenuMaster.SubMenuID INNER JOIN   " +
                            "   TBL_MenuMaster ON TBL_SubMenuMaster.MenuID = TBL_MenuMaster.MenuID INNER JOIN    " +
                            "   CTuser ON Roleright.Usertypeid = CTuser.RollId      " +
                            "   WHERE     (CTuser.USERNAME = '" + Session["username"] + "') and TBL_SubMenuMaster.MenuID='" + Menuid + "'   and  TBL_SubMenuMaster.Isvisible=1", con);
            }

            SqlCommand cmd2 = new SqlCommand(SubMenuSQL, con);
            SqlDataAdapter Adp2 = new SqlDataAdapter(cmd2);
            Adp2.Fill(SubMenuDt);
            //SubMenuPart--------------------------------------------->
            foreach (DataRow SubMainDr in SubMenuDt.Rows)
            {
                string SubMenuName = SubMainDr["SubMenuName"].ToString();
                string SubMenuUrl = SubMainDr["SubMenuNavigateURL"].ToString();
                string ModuelName = SubMainDr["ModuelName"].ToString();
                SlideBarHtml += "<li>";
                if (Convert.ToString(SubMainDr["ModuelName"]) == "HMS")
                {
                    SlideBarHtml += "<a href=" + (char)34 + SubMenuUrl + (char)34 + ">" + SubMenuName.ToString() + "</a>";
                }
                else
                {
                    SlideBarHtml += "<a href=" + (char)34 +ModuelName +'/'+ SubMenuUrl + (char)34 + ">" + SubMenuName.ToString() + "</a>";
                }
                SlideBarHtml += "</li>";
            }
            //SubMenuPart----------------------------------------------

            SlideBarHtml += "</ul>";
            SlideBarHtml += "</li>";

        }


        SlidBarHolder.Controls.Clear();
        SlidBarHolder.Controls.Add(new Literal { Text = SlideBarHtml });
        con.Close();
        con.Dispose();
    }



    protected void lnksignout_Click(object sender, EventArgs e)
    {
        #region MyRegion
        //Save LoginInfo
        Session["Logouttime"] = Date.getTime();
        Session["Logouttime"] = Date.getTime();
        Uri uri = Request.Url;
        string newurl = uri.AbsoluteUri.Remove(uri.AbsoluteUri.LastIndexOf("/"));
       
        Session.Clear();
        Session.Abandon();

        string ss = "";
        if (uri != null)
        {
            ss = newurl + '/' + "Login.aspx";
        }
        else
        {
            ss = System.Configuration.ConfigurationManager.AppSettings["LogOutURLAll"].Trim();
        }
        Response.Redirect(ss);
        #endregion
    }

    protected void btnchangePass_Click(object sender, EventArgs e)
    {
        #region MyRegion
        //Save LoginInfo
        Session["Logouttime"] = Date.getTime();
        Session["Logouttime"] = Date.getTime();
        Uri uri = Request.Url;
        string newurl = uri.AbsoluteUri.Remove(uri.AbsoluteUri.LastIndexOf("/"));

       

        string ss = "";
        if (uri != null)
        {
            ss = newurl + '/' + "ChangePassword.aspx";
        }
        else
        {
            ss = System.Configuration.ConfigurationManager.AppSettings["ChangePassword"].Trim();
        }
        Response.Redirect(ss);
        #endregion
    }

    protected void btnHome_Click(object sender, EventArgs e)
    {
        #region MyRegion
        //Save LoginInfo
        Session["Logouttime"] = Date.getTime();
        Session["Logouttime"] = Date.getTime();
        Uri uri = Request.Url;
        string newurl = uri.AbsoluteUri.Remove(uri.AbsoluteUri.LastIndexOf("/"));



        string ss = "";
        if (uri != null)
        {
            ss = newurl + '/' + "Home.aspx";
        }
        else
        {
            ss = System.Configuration.ConfigurationManager.AppSettings["MainHome"].Trim();
        }
        Response.Redirect(ss);
        #endregion
    }

}
