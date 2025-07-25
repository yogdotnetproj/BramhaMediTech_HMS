
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Services;
using System.Web.Script.Services;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Web.Management;
using System.Net;
using System.IO;

public partial class NurseAssignToWard :BasePage
{
    AddRoleRight_C ObjRoleRight = new AddRoleRight_C();
    // dbconnection dc = new dbconnection();
    TreeviewBind_C ObjTB = new TreeviewBind_C();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           // LUNAME.Text = Convert.ToString(Session["username"]);
            //LblDCName.Text = Convert.ToString(Session["Bannername"]);
            //LblDCCode.Text = Convert.ToString(Session["BannerCode"]);
            bindusertype();
            dt = new DataTable();
            dt = ObjTB.Bind_ward(Convert.ToString(Session["username"]), Convert.ToString(Session["password"]), "0");
            


           
            //dt = new DataTable();
            //dt = ObjTB.BindMainMenu_treeview();
            //this.PopulateTreeView(dt, 0, null);
            this.PopulateTreeView(dt, 0, null);
        }

    }

    public void bindusertype()
    {
       

        ddlmainmodule.DataSource = ObjRoleRight.BindUsers(Session["Branchid"].ToString(), "2");
        ddlmainmodule.DataValueField = "CUId";
        ddlmainmodule.DataTextField = "Username";
        ddlmainmodule.DataBind();
        ddlmainmodule.Items.Insert(0, "Select Nurse");
        ddlmainmodule.Items[0].Value = "0";
        ddlmainmodule.SelectedIndex = -1;
    }
    private void GetMenuITem()
    {

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString);
        SqlDataAdapter da = new SqlDataAdapter("SP_phmnuds", conn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ds.Relations.Add("childRows", ds.Tables[0].Columns["MenuID"], ds.Tables[1].Columns["MenuID"]);
        foreach (DataRow level1dataRow in ds.Tables[0].Rows)
        {
            MenuItem item = new MenuItem();
            item.Text = level1dataRow["MenuName"].ToString();
            item.NavigateUrl = level1dataRow["NavigateURL"].ToString();
            DataRow[] level2DataRows = level1dataRow.GetChildRows("childRows");
            foreach (DataRow level2DataRow in level2DataRows)
            {

                MenuItem ChildItem = new MenuItem();
                ChildItem.Text = level2DataRow["SubMenuName"].ToString();
                ChildItem.NavigateUrl = level2DataRow["SubMenuNavigateURL"].ToString();
                item.ChildItems.Add(ChildItem);
            }

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
                TR_RoleRight.Nodes.Add(child);
                DataTable dtchild = new DataTable();
                dtchild = ObjTB.BindChildWard_treeview(child.Value);
                if (dtchild.Rows.Count > 0)
                {
                    PopulateTreeView(dtchild, int.Parse(child.Value), child);
                }

            }
            else
            {
                treeNode.ChildNodes.Add(child);
                // child.Checked = true;
                // treeNode.Checked = true;
            }

        }
    }


    protected void TR_RoleRight_SelectedNodeChanged(object sender, EventArgs e)
    {
        int tId = Convert.ToInt32(TR_RoleRight.SelectedValue);
        DataTable dtform = new DataTable();
        dtform = ObjTB.BindForm(tId);
        if (dtform.Rows.Count > 0)
        {
            Response.Redirect(dtform.Rows[0]["SubMenuNavigateURL"].ToString());
        }
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        foreach (TreeNode tn in TR_RoleRight.CheckedNodes)
        {
            string V = tn.Value;
            string M = tn.Text;
            ObjTB.P_Branchid = Convert.ToInt32(Session["Branchid"].ToString());
            ObjTB.P_FormId = Convert.ToInt32(tn.Value);
            ObjTB.P_FormName = tn.Text;
            ObjTB.P_Usertypeid = Convert.ToInt32(ddlmainmodule.SelectedValue);
            ObjTB.Insert_NurseRoleRight();

        }
        BindGrid();
    }
    protected void ddlUsertype_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
    }
    public void BindGrid()
    {
        DataTable dtgv = new DataTable();
        dtgv = ObjTB.Get_Nurse_Rollright(ddlmainmodule.SelectedValue);
        GV_userrollright.DataSource = dtgv;
        GV_userrollright.DataBind();
    }
    protected void GV_userrollright_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GV_userrollright.PageIndex = e.NewPageIndex;
            BindGrid();
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
    //private void PopulateTreeView1(DataTable dtparent, int Parentid, TreeNode treeNode)
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
    //            PopulateTreeView1(dtchild, int.Parse(child.Value), child);

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

    //    Response.Redirect(dtform.Rows[0]["SubMenuNavigateURL"].ToString());
    //}
    protected void chkall_CheckedChanged(object sender, EventArgs e)
    {
        dt = new DataTable();
        dt = ObjTB.BindMainMenu_treeview();
        if (chkall.Checked == true)
        {
            //this.PopulateTreeView(null, 0, null);
            this.PopulateTreeView_all(dt, 0, null);
        }
        else
        {
            this.PopulateTreeView(dt, 0, null);
        }
    }
    private void PopulateTreeView_all(DataTable dtparent, int Parentid, TreeNode treeNode)
    {
        foreach (DataRow row in dtparent.Rows)
        {
            TreeNode child = new TreeNode
            {

                // Text = row["MenuName"].ToString(),
                // Value = row["MenuID"].ToString()


            };
            child.Checked = true;
            // treeNode.Checked = true;
            //if (Parentid == 0)
            //{
            //    TR_RoleRight.Nodes.Add(child);
            //    DataTable dtchild = new DataTable();
            //    dtchild = ObjTB.BindChildMenu_treeview(child.Value);
            //    PopulateTreeView_all(dtchild, int.Parse(child.Value), child);

            //}
            //else
            //{
            //    treeNode.ChildNodes.Add(child);
            //    child.Checked = true;
            //    treeNode.Checked = true;
            //}


        }
    }
    protected void GV_userrollright_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        // Userright_Bal_C ObjUBC = new Userright_Bal_C();
        string Id = GV_userrollright.DataKeys[e.RowIndex].Value.ToString();

        ObjRoleRight.deleteNurse_Rights(Id);

        BindGrid();
    }
    protected void ddlmainmodule_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlmainmodule.SelectedValue !="0")
        {
            ddlmainmodule.Enabled = false;
            BindGrid();
            //Response.Redirect("~/Addroleright.aspx",false);

           // this.PopulateTreeViewNew(null, 0, null);
            //TreeNode child = new TreeNode
            //{
            //    Text = "",
            //    Value = ""

            //};
            //TR_RoleRight.Nodes.Add(child);
            //TR_RoleRight.DataSource = null;
            //TR_RoleRight.DataBind();
            
           // dt = new DataTable();
           // dt = ObjTB.BindMainMenu(Convert.ToString(Session["username"]), Convert.ToString(Session["password"]),ddlmainmodule.SelectedValue);
           // //this.PopulateTreeView1(dt, 0, null);


           // //bindusertype();
           // //dt = new DataTable();
           //// dt = ObjTB.BindMainMenu_treeview();
           //// dt = ObjTB.BindMainMenu_treeview();
           // this.PopulateTreeView(dt, 0, null);
        }
    }

    private void PopulateTreeViewNew(DataTable dtparent, int Parentid, TreeNode treeNode)
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
                TR_RoleRight.Nodes.Add(child);
                DataTable dtchild = new DataTable();
                dtchild = ObjTB.BindChildMenu_treeview(child.Value);
                PopulateTreeView(dtchild, int.Parse(child.Value), child);

            }
            else
            {
                treeNode.ChildNodes.Add(child);
                // child.Checked = true;
                // treeNode.Checked = true;
            }

        }
    }

    protected void btnAction_Click(object sender, EventArgs e)
    {
        if (ddlmainmodule.SelectedValue !="0")
        {
            dt = new DataTable();
            dt = ObjTB.Bind_ward(Convert.ToString(Session["username"]), Convert.ToString(Session["password"]), ddlmainmodule.SelectedValue);
            //this.PopulateTreeView1(dt, 0, null);


            //bindusertype();
            //dt = new DataTable();
            // dt = ObjTB.BindMainMenu_treeview();
            // dt = ObjTB.BindMainMenu_treeview();
            this.PopulateTreeView(dt, 0, null);
        }
    }
}