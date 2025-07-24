using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Services;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using CrystalDecisions.CrystalReports.Engine;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.Collections;

public partial class InfiniChart :BasePage
{
    public enum MessageType { Success, Error, Info, Warning };
    Dermatology_C ObjDer = new Dermatology_C();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            SetInitialRow();
        }
    }

    private void SetInitialRow()
    {

        DataTable dt = new DataTable();

        DataRow dr = null;

        dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));

        dt.Columns.Add(new DataColumn("DermDate", typeof(string)));
        dt.Columns.Add(new DataColumn("Area", typeof(string)));
        dt.Columns.Add(new DataColumn("Depth", typeof(string)));
        dt.Columns.Add(new DataColumn("Level", typeof(string)));
        dt.Columns.Add(new DataColumn("Time", typeof(string)));
       



        dr = dt.NewRow();

        dr["RowNumber"] = 1;

        dr["DermDate"] = string.Empty;
        dr["Area"] = string.Empty;
        dr["Depth"] = string.Empty;
        dr["Level"] = string.Empty;
        dr["Time"] = string.Empty;
       
        dt.Rows.Add(dr);
        //----------------------------
        dr = dt.NewRow();

        dr["RowNumber"] = 2;

        dr["DermDate"] = string.Empty;
        dr["Area"] = string.Empty;
        dr["Depth"] = string.Empty;
        dr["Level"] = string.Empty;
        dr["Time"] = string.Empty;
        dt.Rows.Add(dr);
        //----------------------------
        dr = dt.NewRow();

        dr["RowNumber"] = 3;

        dr["DermDate"] = string.Empty;
        dr["Area"] = string.Empty;
        dr["Depth"] = string.Empty;
        dr["Level"] = string.Empty;
        dr["Time"] = string.Empty;
        dt.Rows.Add(dr);
        //----------------------------
        dr = dt.NewRow();

        dr["RowNumber"] = 4;

        dr["DermDate"] = string.Empty;
        dr["Area"] = string.Empty;
        dr["Depth"] = string.Empty;
        dr["Level"] = string.Empty;
        dr["Time"] = string.Empty;
        dt.Rows.Add(dr);
        //----------------------------
        dr = dt.NewRow();

        dr["RowNumber"] = 5;

        dr["DermDate"] = string.Empty;
        dr["Area"] = string.Empty;
        dr["Depth"] = string.Empty;
        dr["Level"] = string.Empty;
        dr["Time"] = string.Empty;
        dt.Rows.Add(dr);
        //----------------------------
        dr = dt.NewRow();

        dr["RowNumber"] = 6;

        dr["DermDate"] = string.Empty;
        dr["Area"] = string.Empty;
        dr["Depth"] = string.Empty;
        dr["Level"] = string.Empty;
        dr["Time"] = string.Empty;
        dt.Rows.Add(dr);
        //----------------------------
        dr = dt.NewRow();

        dr["RowNumber"] = 7;

        dr["DermDate"] = string.Empty;
        dr["Area"] = string.Empty;
        dr["Depth"] = string.Empty;
        dr["Level"] = string.Empty;
        dr["Time"] = string.Empty;
        dt.Rows.Add(dr);
        //----------------------------
        dr = dt.NewRow();

        dr["RowNumber"] = 8;

        dr["DermDate"] = string.Empty;
        dr["Area"] = string.Empty;
        dr["Depth"] = string.Empty;
        dr["Level"] = string.Empty;
        dr["Time"] = string.Empty;
        dt.Rows.Add(dr);
        //----------------------------
        dr = dt.NewRow();

        dr["RowNumber"] = 9;

        dr["DermDate"] = string.Empty;
        dr["Area"] = string.Empty;
        dr["Depth"] = string.Empty;
        dr["Level"] = string.Empty;
        dr["Time"] = string.Empty;
        dt.Rows.Add(dr);
        //----------------------------
        dr = dt.NewRow();

        dr["RowNumber"] = 10;

        dr["DermDate"] = string.Empty;
        dr["Area"] = string.Empty;
        dr["Depth"] = string.Empty;
        dr["Level"] = string.Empty;
        dr["Time"] = string.Empty;
        dt.Rows.Add(dr);
        //----------------------------
        dr = dt.NewRow();

        dr["RowNumber"] = 11;

        dr["DermDate"] = string.Empty;
        dr["Area"] = string.Empty;
        dr["Depth"] = string.Empty;
        dr["Level"] = string.Empty;
        dr["Time"] = string.Empty;
        dt.Rows.Add(dr);
        //----------------------------
        dr = dt.NewRow();

        dr["RowNumber"] = 12;

        dr["DermDate"] = string.Empty;
        dr["Area"] = string.Empty;
        dr["Depth"] = string.Empty;
        dr["Level"] = string.Empty;
        dr["Time"] = string.Empty;
        dt.Rows.Add(dr);
        //----------------------------
        dr = dt.NewRow();

        dr["RowNumber"] = 13;

        dr["DermDate"] = string.Empty;
        dr["Area"] = string.Empty;
        dr["Depth"] = string.Empty;
        dr["Level"] = string.Empty;
        dr["Time"] = string.Empty;
        dt.Rows.Add(dr);
        //----------------------------
        dr = dt.NewRow();

        dr["RowNumber"] = 14;

        dr["DermDate"] = string.Empty;
        dr["Area"] = string.Empty;
        dr["Depth"] = string.Empty;
        dr["Level"] = string.Empty;
        dr["Time"] = string.Empty;
        dt.Rows.Add(dr);
        //----------------------------
        dr = dt.NewRow();

        dr["RowNumber"] = 15;

        dr["DermDate"] = string.Empty;
        dr["Area"] = string.Empty;
        dr["Depth"] = string.Empty;
        dr["Level"] = string.Empty;
        dr["Time"] = string.Empty;
        dt.Rows.Add(dr);



        //dr = dt.NewRow();



        //Store the DataTable in ViewState

        ViewState["CurrentTable"] = dt;



        GvInfiChart.DataSource = dt;

        GvInfiChart.DataBind();

    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < GvInfiChart.Rows.Count; i++)
        {

            //extract the TextBox values

            TextBox box1 = (TextBox)GvInfiChart.Rows[i].Cells[1].FindControl("txtAntaDate");
            TextBox box2 = (TextBox)GvInfiChart.Rows[i].Cells[2].FindControl("txtArea");
            TextBox box3 = (TextBox)GvInfiChart.Rows[i].Cells[3].FindControl("txtDepth");
            TextBox box4 = (TextBox)GvInfiChart.Rows[i].Cells[4].FindControl("txtLevel");
            TextBox box5 = (TextBox)GvInfiChart.Rows[i].Cells[5].FindControl("txtTime");
            if (Convert.ToString(Session["EmrOpdNo"]) != "")
            {
                ObjDer.P_OpdNo = Convert.ToInt32(Session["EmrOpdNo"]);
            }
            else
            {
                ObjDer.P_OpdNo = 0;
            }
            if (Convert.ToString(Session["EmrIpdNo"]) != "")
            {
                ObjDer.P_IpdNo = Convert.ToInt32(Session["EmrIpdNo"]);
            }
            else
            {
                ObjDer.P_IpdNo = 0;
            }
            ObjDer.P_Patregid = Convert.ToInt32(Session["EmrRegNo"]);
            ObjDer.P_CreatedBy = Convert.ToString(Session["username"]);
            if (box1.Text != "")
            {
                ObjDer.P_EntryDate = Convert.ToDateTime(box1.Text);
            }
            ObjDer.P_Area = box2.Text;
            ObjDer.P_Depth = box3.Text;
            ObjDer.P_Level = box4.Text;
            ObjDer.P_Time = box5.Text;
            ObjDer.P_Branchid = Convert.ToInt32(Session["Branchid"]);

            ObjDer.Insert_InfiniChart();
           
        }
        ShowMessage("Record save successfully", MessageType.Success);
    }
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
    protected void btnreport_Click(object sender, EventArgs e)
    {
        string sql = "";
        if (Convert.ToString(Session["EmrOpdNo"]) != "")
        {
            ObjDer.P_OpdNo = Convert.ToInt32(Session["EmrOpdNo"]);
        }
        else
        {
            ObjDer.P_OpdNo = 0;
        }
        if (Convert.ToString(Session["EmrIpdNo"]) != "")
        {
            ObjDer.P_IpdNo = Convert.ToInt32(Session["EmrIpdNo"]);
        }
        else
        {
            ObjDer.P_IpdNo = 0;
        }
        ObjDer.P_Patregid = Convert.ToInt32(Session["EmrRegNo"]);
        // objDALIO.Alter_TwoWayRepositoryChart(objBELIO);
        ObjDer.Alter_InfiChart_Report(Convert.ToInt32(Session["EmrRegNo"]), Convert.ToInt32(Session["EmrOpdNo"]), Convert.ToInt32(Session["EmrIpdNo"]));
        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Report/Rpt_InfiniChart_Report.rpt");
        Session["reportname"] = "InfiniChart_Report";
        Session["RPTFORMAT"] = "pdf";

        //ReportParameterClass.SelectionFormula = sql;
        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);
    }
}