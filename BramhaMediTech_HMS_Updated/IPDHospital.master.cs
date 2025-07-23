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

public partial class IPDHospital : System.Web.UI.MasterPage
{
    TreeviewBind_C ObjTB = new TreeviewBind_C();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LblUtype.Text = Convert.ToString(Session["username"]);
            DataTable dt = new DataTable();
           // dt = ObjTB.BindMainMenu(Convert.ToString(Session["username"]), Convert.ToString(Session["password"]));
            dt = ObjTB.IPDBindMainMenu(Convert.ToString(Session["username"]), Convert.ToString(Session["password"]));
            
            this.PopulateTreeView(dt, 0, null);

        }

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
               // dtchild = ObjTB.BindChildMenu(child.Value, Convert.ToString(Session["username"]), Convert.ToString(Session["password"]));
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
        int tId = Convert.ToInt32(TrMenu.SelectedValue);
        DataTable dtform = new DataTable();
        dtform = ObjTB.BindForm(tId);
        if (dtform.Rows.Count > 0)
        {
           // Response.Redirect(dtform.Rows[0]["SubMenuNavigateURL"].ToString());
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

    //private void PopulateTreeView(DataTable dtparent, int Parentid, TreeNode treeNode)
    //{
    //    //foreach (DataRow row in dtParent.Rows)
    //    //{
    //    //    TreeNode child = new TreeNode
    //    //    {
    //    //        Text = row["MenuName"].ToString(),
    //    //        Value = row["MenuId"].ToString()
    //    //    };
    //    //    if (treeNode == null)
    //    //        TrMenu.Nodes.Add(child);
    //    //    else
    //    //        treeNode.ChildNodes.Add(child);
    //    //    DataTable dtChild = ObjTB.BindMainMenu(Convert.ToString(Session["UserName"]), Convert.ToString(Session["Password"]),Convert.ToString(child.Value));

    //    //   // DataTable dtChild = this.GetData("SELECT srNo,cid, cName FROM TopBill WHERE pid = " + child.Value);
    //    //    if (dtChild.Rows.Count != 0)
    //    //        PopulateTreeView(dtChild, child);
    //    //}

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


    //protected void TrMenu_SelectedNodeChanged(object sender, EventArgs e)
    //{
    //    //int tId = Convert.ToInt32(TrMenu.SelectedValue);
    //    //DataTable dtform = new DataTable();
    //    //dtform = ObjTB.BindForm(tId);
    //    //if (dtform.Rows.Count > 0)
    //    //{
    //    //    if (Convert.ToString(dtform.Rows[0]["FormName"]) == "#")
    //    //    {
    //    //    }
    //    //    Response.Redirect(dtform.Rows[0]["FormName"].ToString());
    //    //}
    //    int tId = Convert.ToInt32(TrMenu.SelectedValue);
    //    //DataTable dtform = new DataTable();
    //    //dtform = ObjTB.BindForm(tId);
    //    //if (dtform.Rows.Count > 0)
    //    //{
    //    //    Response.Redirect(dtform.Rows[0]["SubMenuNavigateURL"].ToString());
    //    //}
    //}

}
