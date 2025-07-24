using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PrintReceipt : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["RType"] == "Lab")
            {
               // Response.Redirect("PrintReceipt//" + "$" + Request.QueryString["LabNo"] + Request.QueryString["Date"] + "$" + Convert.ToInt32(Request.QueryString["Patregid"]) + "_" + Convert.ToInt32(Session["Branchid"]) + "_" + "LabBill" + ".pdf");
                this.btnCasePaper_Click(null, null);
            }
            else
            {
                Response.Redirect("PrintReceipt//" + "$" + Request.QueryString["ProcedureId"] + Request.QueryString["Date"] + "$" + Convert.ToInt32(Request.QueryString["Patregid"]) + "_" + Convert.ToInt32(Session["Branchid"]) + "_" + "CasePaper" + ".pdf");
            }
        }
    }
    protected void btnCasePaper_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["RType"] == "Lab")
        {
            Response.Redirect("PrintReceipt//" + "$" + Request.QueryString["LabNo"] + Request.QueryString["Date"] + "$" + Convert.ToInt32(Request.QueryString["Patregid"]) + "_" + Convert.ToInt32(Session["Branchid"]) + "_" + "LabBill" + ".pdf");

        }
        else
        {
            Response.Redirect("PrintReceipt//" + "$" + Request.QueryString["ProcedureId"] + Request.QueryString["Date"] + "$" + Convert.ToInt32(Request.QueryString["Patregid"]) + "_" + Convert.ToInt32(Session["Branchid"]) + "_" + "CasePaper" + ".pdf");
        }
    }
}