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

public partial class HairLaser :BasePage
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

        dt.Columns.Add(new DataColumn("HairDate", typeof(string)));
        dt.Columns.Add(new DataColumn("Pulse", typeof(string)));
        dt.Columns.Add(new DataColumn("Energy", typeof(string)));
        dt.Columns.Add(new DataColumn("Charge", typeof(string)));
        
       



        dr = dt.NewRow();

        dr["RowNumber"] = 1;

        dr["HairDate"] = string.Empty;
        dr["Pulse"] = string.Empty;
        dr["Energy"] = string.Empty;
        dr["Charge"] = string.Empty;
       
       
        dt.Rows.Add(dr);
        


        //Store the DataTable in ViewState

        ViewState["CurrentTable"] = dt;



        GvHairLaser.DataSource = dt;

        GvHairLaser.DataBind();

    }

    protected void ButtonAdd_Click(object sender, EventArgs e)
    {

        AddNewRowToGrid();

    }
    private void AddNewRowToGrid()
    {

        int rowIndex = 0;



        if (ViewState["CurrentTable"] != null)
        {

            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];

            DataRow drCurrentRow = null;

            if (dtCurrentTable.Rows.Count > 0)
            {

                for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                {

                    //extract the TextBox values

                    TextBox box1 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[1].FindControl("txtHairDate");
                    TextBox box2 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[2].FindControl("txtPulse");

                    TextBox box3 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[1].FindControl("txtEnergy");
                    TextBox box4 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[2].FindControl("txtCharge");



                    drCurrentRow = dtCurrentTable.NewRow();

                    drCurrentRow["RowNumber"] = i + 1;



                    dtCurrentTable.Rows[i - 1]["HairDate"] = box1.Text;
                    dtCurrentTable.Rows[i - 1]["Pulse"] = box2.Text;
                    dtCurrentTable.Rows[i - 1]["Energy"] = box3.Text;
                    dtCurrentTable.Rows[i - 1]["Charge"] = box4.Text;


                    rowIndex++;

                }

                dtCurrentTable.Rows.Add(drCurrentRow);

                ViewState["CurrentTable"] = dtCurrentTable;



                GvHairLaser.DataSource = dtCurrentTable;
                GvHairLaser.DataBind();

            }

        }

        else
        {

            Response.Write("ViewState is null");

        }



        //Set Previous Data on Postbacks

        SetPreviousData();

    }
    private void SetPreviousData()
    {

        int rowIndex = 0;

        if (ViewState["CurrentTable"] != null)
        {

            DataTable dt = (DataTable)ViewState["CurrentTable"];

            if (dt.Rows.Count > 0)
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    TextBox box1 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[1].FindControl("txtHairDate");
                    TextBox box2 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[2].FindControl("txtPulse");
                    TextBox box3 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[3].FindControl("txtEnergy");
                    TextBox box4 = (TextBox)GvHairLaser.Rows[rowIndex].Cells[4].FindControl("txtCharge");

                    box1.Text = dt.Rows[i]["HairDate"].ToString();
                    box2.Text = dt.Rows[i]["Pulse"].ToString();
                    box3.Text = dt.Rows[i]["Energy"].ToString();
                    box4.Text = dt.Rows[i]["Charge"].ToString();


                    rowIndex++;

                }

            }

        }

    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < GvHairLaser.Rows.Count; i++)
        {

            //extract the TextBox values

            TextBox box1 = (TextBox)GvHairLaser.Rows[i].Cells[1].FindControl("txtHairDate");
            TextBox box2 = (TextBox)GvHairLaser.Rows[i].Cells[2].FindControl("txtPulse");
            TextBox box3 = (TextBox)GvHairLaser.Rows[i].Cells[3].FindControl("txtEnergy");
            TextBox box4 = (TextBox)GvHairLaser.Rows[i].Cells[4].FindControl("txtCharge");
            
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
            ObjDer.P_Pulse = box2.Text;
            ObjDer.P_Energy = box3.Text;
            ObjDer.P_Charge = box4.Text;
           
            ObjDer.P_Branchid = Convert.ToInt32(Session["Branchid"]);

            ObjDer.Insert_HairLaser();

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
        ObjDer.Alter_Hair_Laser_Section_Report(Convert.ToInt32(Session["EmrRegNo"]), Convert.ToInt32(Session["EmrOpdNo"]), Convert.ToInt32(Session["EmrIpdNo"]));
        Session.Add("rptsql", sql);
        Session["rptname"] = Server.MapPath("~/Report/Rpt_HairLaser_Report_Report.rpt");
        Session["reportname"] = "HairLaser_Report";
        Session["RPTFORMAT"] = "pdf";

        //ReportParameterClass.SelectionFormula = sql;
        string close = "<script language='javascript'>javascript:OpenReport();</script>";
        Type title1 = this.GetType();
        Page.ClientScript.RegisterStartupScript(title1, "", close);
    }
}