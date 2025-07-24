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

public partial class Triage_Questionary : BasePage
{
    AddRoleRight_C ObjRoleRight = new AddRoleRight_C();
    // dbconnection dc = new dbconnection();
    TreeviewBind_C ObjTB = new TreeviewBind_C();
    Triage_Questionary_C ObjTq = new Triage_Questionary_C();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["TriageCriteria"] = "0";
            BindTriageRedCritria();
            BindTriageYellowCritria();
            BindTriageVitalCritria();
        }
    }
    protected void TR_HighRiskCrit_SelectedNodeChanged(object sender, EventArgs e)
    {

    }
    protected void TR_HighRiskCrit_Yellow_SelectedNodeChanged(object sender, EventArgs e)
    {

    }
    protected void TR_HighRiskCrit_Vital_SelectedNodeChanged(object sender, EventArgs e)
    {

    }
    public void BindTriageRedCritria()
    {
        dt = new DataTable();
        dt = ObjTB.BindTriageREDMenu_treeview();
        this.PopulateTreeView(dt, 0, null);
    }
    public void BindTriageYellowCritria()
    {
        dt = new DataTable();
        dt = ObjTB.BindTriageYellowMenu_treeview();
        this.PopulateTreeView_Yellow(dt, 0, null);
    }
    public void BindTriageVitalCritria()
    {
        dt = new DataTable();
        dt = ObjTB.BindTriageVitalMenu_treeview();
        this.PopulateTreeView_Vital(dt, 0, null);
    }
    private void PopulateTreeView(DataTable dtparent, int Parentid, TreeNode treeNode)
    {
        foreach (DataRow row in dtparent.Rows)
        {
            TreeNode child = new TreeNode
            {
                Text = row["TriageHeading"].ToString(),
                Value = row["TriageMasterId"].ToString()

            };
            if (Parentid == 0)
            {
                TR_HighRiskCrit.Nodes.Add(child);
                DataTable dtchild = new DataTable();
                dtchild = ObjTB.BindChildMenu_treeview_ModuleName(child.Value);
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
    private void PopulateTreeView_Yellow(DataTable dtparent, int Parentid, TreeNode treeNode)
    {
        foreach (DataRow row in dtparent.Rows)
        {
            TreeNode child = new TreeNode
            {
                Text = row["TriageHeading"].ToString(),
                Value = row["TriageMasterId"].ToString()

            };
            if (Parentid == 0)
            {
                TR_HighRiskCrit_Yellow.Nodes.Add(child);
                DataTable dtchild = new DataTable();
                dtchild = ObjTB.BindChildMenu_treeview_ModuleName(child.Value);
                PopulateTreeView_Yellow(dtchild, int.Parse(child.Value), child);

            }
            else
            {
                treeNode.ChildNodes.Add(child);
                // child.Checked = true;
                // treeNode.Checked = true;
            }

        }
    }
    private void PopulateTreeView_Vital(DataTable dtparent, int Parentid, TreeNode treeNode)
    {
        foreach (DataRow row in dtparent.Rows)
        {
            TreeNode child = new TreeNode
            {
                Text = row["TriageHeading"].ToString(),
                Value = row["TriageMasterId"].ToString()

            };
            if (Parentid == 0)
            {
                TR_HighRiskCrit_Vital.Nodes.Add(child);
                DataTable dtchild = new DataTable();
                dtchild = ObjTB.BindChildMenu_treeview_ModuleName(child.Value);
                PopulateTreeView_Vital(dtchild, int.Parse(child.Value), child);

            }
            else
            {
                treeNode.ChildNodes.Add(child);
                // child.Checked = true;
                // treeNode.Checked = true;
            }

        }
    }

    protected void btnsave_Click(object sender, EventArgs e)
    {
        foreach (TreeNode tn in TR_HighRiskCrit.CheckedNodes)
        {
            string V = tn.Value;
            string M = tn.Text;
            ObjTB.P_Branchid = Convert.ToInt32(Session["Branchid"].ToString());
            ObjTB.P_TriageMasterId = Convert.ToInt32(tn.Value);
            ObjTB.P_TriageHeading = tn.Text;
            ObjTB.P_RegId =Convert.ToInt32(  Request.QueryString["RegId"]);
            ObjTB.P_OPDNo = Convert.ToInt32(Request.QueryString["OpdNo"]);
            ObjTB.P_CreatedBy = Convert.ToString(Session["username"]);
            ObjTB.P_TriageCriteria = Convert.ToInt32(1);
            ViewState["TriageCriteria"] = Convert.ToInt32(1);
            if (ChkYes.Checked == true)
            {
                ObjTB.P_Issuspected = true;
            }
            if (ChkNo.Checked == true)
            {
                ObjTB.P_Issuspected = false;
            }
            ObjTB.P_Measures = Convert.ToString(txtmeasures.Text);
            ObjTB.Insert_Triage();
            Lblmsg.Text = "Record Save Successfully";
        }
        foreach (TreeNode tn in TR_HighRiskCrit_Yellow.CheckedNodes)
        {
            string V = tn.Value;
            string M = tn.Text;
            ObjTB.P_Branchid = Convert.ToInt32(Session["Branchid"].ToString());
            ObjTB.P_TriageMasterId = Convert.ToInt32(tn.Value);
            ObjTB.P_TriageHeading = tn.Text;
            ObjTB.P_RegId = Convert.ToInt32(Request.QueryString["RegId"]);
            ObjTB.P_OPDNo = Convert.ToInt32(Request.QueryString["OpdNo"]);
            ObjTB.P_CreatedBy = Convert.ToString(Session["username"]);
            if (Convert.ToInt32(ViewState["TriageCriteria"]) == 1)
            {
                ObjTB.P_TriageCriteria = Convert.ToInt32(1);
            }
            else
            {
                ObjTB.P_TriageCriteria = Convert.ToInt32(2);
            }
            if (ChkYes.Checked == true)
            {
                ObjTB.P_Issuspected = true;
            }
            if (ChkNo.Checked == true)
            {
                ObjTB.P_Issuspected = false;
            }
            ObjTB.P_Measures = Convert.ToString(txtmeasures.Text);
            ObjTB.Insert_Triage();
            Lblmsg.Text = "Record Save Successfully";
        }
        foreach (TreeNode tn in TR_HighRiskCrit_Vital.CheckedNodes)
        {
            string V = tn.Value;
            string M = tn.Text;
            ObjTB.P_Branchid = Convert.ToInt32(Session["Branchid"].ToString());
            ObjTB.P_TriageMasterId = Convert.ToInt32(tn.Value);
            ObjTB.P_TriageHeading = tn.Text;
            ObjTB.P_RegId = Convert.ToInt32(Request.QueryString["RegId"]);
            ObjTB.P_OPDNo = Convert.ToInt32(Request.QueryString["OpdNo"]);
            ObjTB.P_CreatedBy = Convert.ToString(Session["username"]);
            ObjTB.P_TriageCriteria = Convert.ToInt32(1);
            if (ChkYes.Checked == true)
            {
                ObjTB.P_Issuspected = true;
            }
            if (ChkNo.Checked == true)
            {
                ObjTB.P_Issuspected = false;
            }
            ObjTB.P_Measures = Convert.ToString(txtmeasures.Text);
            ObjTB.Insert_Triage();
            Lblmsg.Text = "Record Save Successfully";
        }

    }
}