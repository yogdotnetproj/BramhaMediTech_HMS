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


public partial class HomeTemp : System.Web.UI.Page
{
    TreeviewBind_C ObjTB = new TreeviewBind_C();
    
    DataTable dt = new DataTable();
    string Username = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Username = Convert.ToString(Session["username"]);
           // LblDCName.Text = Convert.ToString(Session["Bannername"]);
            //LblDCCode.Text = Convert.ToString(Session["BannerCode"]);
            UsernameLB2.Text = Convert.ToString(Session["Name"]);
            if (Convert.ToString(Session["usertype"]) == "Administrator")
            {
                LoadSlideBar(Convert.ToString(Session["username"]), "");
            }
            else
            {
                LoadSlideBar(Username, "");
                // Response.Redirect("Login.aspx", false);

            }
            //if (Session["usertype"].ToString() == "Administrator")
            //{
            //    TTTTT.Visible = true;
            //    ddlSelectGraph_SelectedIndexChanged(null, null);

            //    dddlpatcount_SelectedIndexChanged(null, null);
            //}
        }
    }
//    protected void ddlSelectGraph_SelectedIndexChanged(object sender, EventArgs e)
//    {
//        if (ddlSelectGraph.SelectedItem.Text == "3D Graph" || ddlSelectGraph.SelectedItem.Text == "Piechart")
//            FCLiteral.Text = CreatePieAndCollumnCharts(Convert.ToString(ddlSelectGraph.SelectedItem.Value));
//        else if (ddlSelectGraph.SelectedItem.Text == "Combine Graph")
//            FCLiteral.Text = CreateCombineCharts();
//        else
//            FCLiteral.Text = CreateChartsStack();
//    }
//    private string[] CreateColorForReport()
//    {
//        string[] asColor = new string[10];
//        asColor[0] = "AFD8F8";
//        asColor[1] = "F6BD0F";
//        asColor[2] = "8BBA00";
//        asColor[3] = "FF8E46";
//        asColor[4] = "008E8E";
//        asColor[5] = "D64646";
//        asColor[6] = "8E468E";
//        asColor[7] = "588526";
//        asColor[8] = "B3AA00";
//        asColor[9] = "008ED6";
//        return asColor;
//    }
//    public string CreateCombineCharts()
//    {

//        int i = 0;
//        string[] sColor = CreateColorForReport();
//        DataTable dt = ObjGR.GetDetailsToBindGraphForG();
//        string strXML = "";
//        string sLastWeek = @"<dataset parentYAxis='P'  seriesname='Net payment for year ' color='AFD8F8' alpha='100'>";
//        string sLastSexMonth = @"<dataset parentYAxis='P' seriesname='Amt receiv for year' color='F6BD0F' alpha='100'>";
//        string sTotal = @"<dataset parentYAxis='S' seriesname='Total' color='008ED6' alpha='100'>";
//        string sCategory = @"<categories font='Arial' fontSize='10' fontColor='000000'>";
//        strXML += @"<graph  caption='Total collection Details' subcaption='(For Financial year)' PYAxisName='Score' SYAxisName='Total' xaxisname='Date'  canvasbgcolor='F1F1F1' animation=''
//                 numdivlines='3' divLineColor='333333' decimalPrecision='2' showLegend='1' showColumnShadow='1' yAxisMaxValue='30'>";
//        while (i < dt.Rows.Count)
//        {
//            sCategory += @"<category name='" + dt.Rows[i]["FID"].ToString() + @"' />";
//            sLastWeek += @"<set  value='" + dt.Rows[i]["NetPayment"].ToString() + @"' />";
//            sLastSexMonth += @"<set value='" + dt.Rows[i]["AmtReceived"].ToString() + @"' />";
//            sTotal += @"<set value='" + dt.Rows[i]["Balance"].ToString() + @"' />";

//            i++;
//        }
//        sCategory += "</categories>";
//        sLastWeek += "</dataset>";
//        sLastSexMonth += "</dataset>";
//        sTotal += "</dataset>";
//        strXML = strXML + " " + sCategory + " " + sLastWeek + " " + sLastSexMonth + " " + sTotal;
//        strXML += "</graph>";
//        return FusionCharts.RenderChartHTML("FusionCharts/FCF_MSColumn2DLineDY.swf", "", strXML, "myNext", "700", "400", false);
//    }
//    public string CreatePieAndCollumnCharts(string sChartType)
//    {
//        int i = 0;
//        string[] sColor = CreateColorForReport();
//        DataTable dt = ObjGR.GetDetailsToBindGraphForG();
//        string strXML = "";
//        strXML += "<graph caption='Total Income' subcaption='(For financial year)' xAxisName='Date' showPercentageInLabel='1' pieSliceDepth='25' showNames='1'  pieSliceDepth='30' yAxisName='Total'  decimalPrecision='2' rotateNames='1'>";
//        while (i < dt.Rows.Count)
//        {
//            strXML += "<set color='" + sColor[1] + "' name='" + dt.Rows[i]["FID"].ToString() + "' value='" + dt.Rows[i]["NetPayment"].ToString() + "' />";
//            strXML += "<set color='" + sColor[2] + "' name='" + dt.Rows[i]["FID"].ToString() + "' value='" + dt.Rows[i]["AmtReceived"].ToString() + "' />";
//            strXML += "<set color='" + sColor[3] + "' name='" + dt.Rows[i]["FID"].ToString() + "' value='" + dt.Rows[i]["Discount"].ToString() + "' />";
//            strXML += "<set color='" + sColor[4] + "' name='" + dt.Rows[i]["FID"].ToString() + "' value='" + dt.Rows[i]["Balance"].ToString() + "' />";
//            i++;
//        }
//        strXML += "</graph>";
//        //Create the chart - Column 3D Chart with data from strXML variable using dataXML method FCF_Pie3D , FCF_Column3D
//        return FusionCharts.RenderChartHTML("FusionCharts/" + sChartType + ".swf", "", strXML, "myNext", "500", "300", false);
//    }
//    public string CreateChartsStack()
//    {

//        int i = 0;
//        string[] sColor = CreateColorForReport();
//        DataTable dt = ObjGR.GetDetailsToBindGraphForG();
//        string strXML = "";
//        string sLastWeek = @"<dataset parentYAxis='P'  seriesname='Net payment for year' color='AFD8F8' alpha='1000'>";
//        string sLastSexMonth = @"<dataset parentYAxis='P' seriesname='Amt Received for year' color='F6BD0F' alpha='1000'>";

//        string sCategory = @"<categories font='Arial' fontSize='10' fontColor='000000'>";
//        strXML += @"<graph  caption='Total Income' subcaption='(For financial year)' xaxisname='Date' yaxisname='Score' canvasbgcolor='F1F1F1' animation='1'
//                 numdivlines='3' divLineColor='333333' decimalPrecision='2' showLegend='1' showColumnShadow='1' yAxisMaxValue='20'>";
//        while (i < dt.Rows.Count)
//        {
//            sCategory += @"<category name='" + dt.Rows[i]["FID"].ToString() + @"' />";
//            sLastWeek += @"<set  value='" + dt.Rows[i]["NetPayment"].ToString() + @"' />";
//            sLastSexMonth += @"<set value='" + dt.Rows[i]["AmtReceived"].ToString() + @"' />";

//            i++;
//        }
//        sCategory += "</categories>";
//        sLastWeek += "</dataset>";
//        sLastSexMonth += "</dataset>";
//        strXML = strXML + " " + sCategory + " " + sLastWeek + " " + sLastSexMonth;
//        strXML += "</graph>";
//        return FusionCharts.RenderChartHTML("FusionCharts/FCF_StackedColumn2D.swf", "", strXML, "myNext", "600", "300", false);
//    }
//    protected void dddlpatcount_SelectedIndexChanged(object sender, EventArgs e)
//    {
//        if (ddlpatcount.SelectedItem.Text == "3D Graph" || ddlpatcount.SelectedItem.Text == "Piechart")
//            FCLiteralPcount.Text = CreatePieAndCollumnCharts_Pcount(Convert.ToString(ddlpatcount.SelectedItem.Value));
//        else if (ddlpatcount.SelectedItem.Text == "Combine Graph")
//            FCLiteralPcount.Text = CreateCombineCharts_Pcount();
//        else
//            FCLiteralPcount.Text = CreateChartsStack_Pcount();
//    }

//    public string CreateCombineCharts_Pcount()
//    {

//        int i = 0;
//        string[] sColor = CreateColorForReport();
//        DataTable dt = ObjGR.GetDetailsToBindGraphFor_Pcount();
//        string strXML = "";
//        string sLastWeek = @"<dataset parentYAxis='P'  seriesname=' .' color='AFD8F8' alpha='100'>";
//        // string sLastSexMonth = @"<dataset parentYAxis='P' seriesname='Amt receiv for year' color='F6BD0F' alpha='100'>";
//        // string sTotal = @"<dataset parentYAxis='S' seriesname='Total' color='008ED6' alpha='100'>";
//        string sCategory = @"<categories font='Arial' fontSize='10' fontColor='000000'>";
//        strXML += @"<graph  caption='Total patients' subcaption='(For Patient count)' PYAxisName='P count' SYAxisName='Total' xaxisname='Date'  canvasbgcolor='F1F1F1' animation=''
//                 numdivlines='3' divLineColor='333333' decimalPrecision='2' showLegend='1' showColumnShadow='1' yAxisMaxValue='30'>";
//        while (i < dt.Rows.Count)
//        {
//            sCategory += @"<category name='" + Convert.ToDateTime(dt.Rows[i]["exam_date"]).ToString("dd/MM/yyyy") + @"' />";
//            sLastWeek += @"<set  value='" + dt.Rows[i]["Pcount"].ToString() + @"' />";
//            // sLastSexMonth += @"<set value='" + dt.Rows[i]["AmtReceived"].ToString() + @"' />";
//            // sTotal += @"<set value='" + dt.Rows[i]["Balance"].ToString() + @"' />";

//            i++;
//        }
//        sCategory += "</categories>";
//        sLastWeek += "</dataset>";
//        // sLastSexMonth += "</dataset>";
//        // sTotal += "</dataset>";
//        //strXML = strXML + " " + sCategory + " " + sLastWeek + " " + sLastSexMonth + " " + sTotal;
//        strXML = strXML + " " + sCategory + " " + sLastWeek;
//        strXML += "</graph>";
//        return FusionCharts.RenderChartHTML("FusionCharts/FCF_MSColumn2DLineDY.swf", "", strXML, "myNext", "700", "400", false);
//    }
//    public string CreatePieAndCollumnCharts_Pcount(string sChartType)
//    {
//        int i = 0;
//        string[] sColor = CreateColorForReport();
//        DataTable dt = ObjGR.GetDetailsToBindGraphFor_Pcount();
//        string strXML = "";
//        strXML += "<graph caption='Total Patient' subcaption='(For patient count)' xAxisName='Date' showPercentageInLabel='1' pieSliceDepth='25' showNames='1'  pieSliceDepth='30' yAxisName='Total'  decimalPrecision='2' rotateNames='1'>";
//        while (i < dt.Rows.Count)
//        {
//            strXML += "<set color='" + sColor[i] + "' name='" + Convert.ToDateTime(dt.Rows[i]["exam_date"]).ToString("dd/MM/yyyy") + "' value='" + dt.Rows[i]["Pcount"].ToString() + "' />";
//            i++;
//        }
//        strXML += "</graph>";
//        //Create the chart - Column 3D Chart with data from strXML variable using dataXML method FCF_Pie3D , FCF_Column3D
//        return FusionCharts.RenderChartHTML("FusionCharts/" + sChartType + ".swf", "", strXML, "myNext", "500", "300", false);
//    }
//    public string CreateChartsStack_Pcount()
//    {

//        int i = 0;
//        string[] sColor = CreateColorForReport();
//        DataTable dt = ObjGR.GetDetailsToBindGraphFor_Pcount();
//        string strXML = "";
//        string sLastWeek = @"<dataset parentYAxis='P'  seriesname='Patient count' color='F6BD0F' alpha='10'>";
//        // string sLastSexMonth = @"<dataset parentYAxis='P' seriesname='Amt Received for year' color='F6BD0F' alpha='1000'>";

//        string sCategory = @"<categories font='Arial' fontSize='10' fontColor='000000'>";
//        strXML += @"<graph  caption='Total Patient' subcaption='(Patient count)' xaxisname='Date' yaxisname='Score' canvasbgcolor='F1F1F1' animation='1'
//                 numdivlines='3' divLineColor='333333' decimalPrecision='2' showLegend='1' showColumnShadow='1' yAxisMaxValue='20'>";
//        while (i < dt.Rows.Count)
//        {
//            sCategory += @"<category name='" + Convert.ToDateTime(dt.Rows[i]["exam_date"]).ToString("dd/MM/yyyy") + @"' />";
//            sLastWeek += @"<set  value='" + dt.Rows[i]["Pcount"].ToString() + @"' />";
//            // sLastSexMonth += @"<set value='" + dt.Rows[i]["Pcount"].ToString() + @"' />";

//            i++;
//        }
//        sCategory += "</categories>";
//        sLastWeek += "</dataset>";
//        // sLastSexMonth += "</dataset>";
//        //  strXML = strXML + " " + sCategory + " " + sLastWeek + " " + sLastSexMonth;
//        strXML = strXML + " " + sCategory + " " + sLastWeek;
//        strXML += "</graph>";
//        return FusionCharts.RenderChartHTML("FusionCharts/FCF_StackedColumn2D.swf", "", strXML, "myNext", "600", "300", false);
//    }
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
                    SlideBarHtml += "<a href=" + (char)34 + ModuelName + '/' + SubMenuUrl + (char)34 + ">" + SubMenuName.ToString() + "</a>";
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

}