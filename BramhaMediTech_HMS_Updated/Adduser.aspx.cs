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

public partial class Adduser : BasePage
{
    AddUser Objau = new AddUser();
    TreeviewBind_C ObjTB = new TreeviewBind_C();
    //  dbconnection dc = new dbconnection();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            //LUNAME.Text = Convert.ToString(Session["username"]);
            //LblDCName.Text = Convert.ToString(Session["Bannername"]);
            //LblDCCode.Text = Convert.ToString(Session["BannerCode"]);
            dt = new DataTable();
            dt = ObjTB.BindMainMenu(Convert.ToString(Session["username"]), Convert.ToString(Session["password"]));
           // this.PopulateTreeView(dt, 0, null);
            ViewState["labcode"] = "";
            FillGrid();

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

    public void FillGrid()
    {
        ViewState["labcode"] = "";
        string UserName = "";
        if (txtusername.Text != "")
        {
            UserName = txtusername.Text;
        }
        userlist.DataSource = Objau.FillUserMasterGrid(Session["Branchid"].ToString(), UserName, "", "2");
        userlist.DataBind();

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/useradd.aspx");
    }
    protected void ItemList_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect("~/useradd.aspx?id=" + (userlist.SelectedRow.FindControl("hdnuid") as HiddenField).Value);
    }
    protected void cmdsearch_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            FillGrid();
        }
        catch (Exception ex)
        {
            if (ex.Message.Equals("Exception aborted."))
            {
                return;
            }
            else
            {
                Response.Cookies["error"].Value = ex.Message;
                Server.Transfer("~/ErrorMessage.aspx");
            }
        }
    }

    protected void userlist_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        ViewState["labcode"] = "";

        userlist.PageIndex = e.NewPageIndex;
        FillGrid();
    }
    protected void userlist_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowIndex == 1)
            return;
       // DataAccess dt = new DataAccess();
        for (int i = 0; i < userlist.Rows.Count; i++)
        {
            string username = userlist.Rows[i].Cells[1].Text.Trim();
            SqlConnection conn = DataAccess.ConInitForDC();
            conn.Open();
            DataTable dt1 = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT  dbo.DrMT.DoctorName FROM dbo.CTuser INNER JOIN dbo.DrMT ON dbo.CTuser.LBcode = dbo.DrMT.DoctorCode where CTuser.username='" + username + "'", conn);
            sda.Fill(dt1);
            conn.Close();
            conn.Dispose();
            if (dt1.Rows.Count != 0)
            {
                //  string labname1 = (userlist.Rows[i].Cells[8].FindControl("Labname") as Label).Text;
                // (userlist.Rows[i].Cells[8].FindControl("Labname") as Label).Text = dt1.Rows[0]["DoctorName"].ToString();

            }
            if (ViewState["labcode"].ToString() != "")
            {
                if (ViewState["labcode"].ToString() != (userlist.Rows[i].Cells[8].FindControl("Labname") as Label).Text)
                {
                    userlist.Rows[i].Visible = false;

                }
                else
                {
                    userlist.Rows[i].Visible = true;

                }
            }

        }
    }
    protected void userlist_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        // Userright_Bal_C ObjUBC=new Userright_Bal_C ();
        string Id = userlist.DataKeys[e.RowIndex].Value.ToString();

        Objau.deleteUsers(Id);

        FillGrid();

    }
    protected void btnAddnew_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/useradd.aspx");
    }
    protected void btnList_Click(object sender, EventArgs e)
    {
        try
        {
            FillGrid();
        }
        catch (Exception ex)
        {
            if (ex.Message.Equals("Exception aborted."))
            {
                return;
            }
            else
            {
                Response.Cookies["error"].Value = ex.Message;
                Server.Transfer("~/ErrorMessage.aspx");
            }
        }
    }
}