using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;



public class DataAccess
{	
    //public  SqlConnection ConInitForDC1()
    //{
    //    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBHospital"].ConnectionString);
    //    return con;
    
    //}
    public SqlConnection ConInitForDC1()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString);
        return con;
    }
    public static SqlConnection ConInitForDC()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBHospital"].ConnectionString);
        return con;

    }
    public static SqlConnection ConInitForPharmacy()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
        return con;

    }
    public static SqlConnection ConInitForPathology()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PathologyConn"].ConnectionString);
        return con;

    }
    public static SqlConnection ConInitForRadiology()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["RadiologyConn"].ConnectionString);
        return con;

    }
    public static SqlConnection ConInitForMedical()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MedicalConn"].ConnectionString);
        return con;

    }
    public static SqlConnection ConInitForCardiology()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CardiologyConn"].ConnectionString);
        return con;

    }
    public  SqlConnection ConInitForPathology1()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PathologyConn"].ConnectionString);
        return con;

    }
   
}
