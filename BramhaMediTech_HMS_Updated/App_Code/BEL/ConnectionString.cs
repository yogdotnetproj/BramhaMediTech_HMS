using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
//using Excel;
using System.Xml;

public static class ConnectionString
{
    private static string _ConnectionstringPatho = System.Configuration.ConfigurationManager.ConnectionStrings["PathologyConn"].ToString();
    private static string _ConnectionstringCardo = System.Configuration.ConfigurationManager.ConnectionStrings["CardiologyConn"].ToString();
    private static string _Connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["myconnection"].ToString();
    private static string _PDConnectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["myconnection"].ToString();
    private static string _ConnectionstringDBH = System.Configuration.ConfigurationManager.ConnectionStrings["DBHospital"].ToString();

    public static string ConnectionstringCardo
    {
        get { return _ConnectionstringCardo; }
        set { _ConnectionstringCardo = value; }
    }
    public static string ConnectionstringDBH
    {
        get
        {
            return _ConnectionstringDBH;

        }
        set
        {
            _ConnectionstringDBH = value;
        }
    }
    public static string ConnectionstringPatho
    {
        get
        {
            return _ConnectionstringPatho;

        }
        set
        {
            _ConnectionstringPatho = value;
        }
    }
    public static string Connectionstring
    {
        get
        {
            return _Connectionstring;
            
        }
        set
        {
            _Connectionstring = value;
        }
    }
    public static string PDConnectionstring
    {
        get
        {
            return _PDConnectionstring;

        }
        set
        {
            _PDConnectionstring = value;
        }
    }
    public static string ConnectionstringWithoutCheck
    {
        get
        {
            return _Connectionstring;
        }
        set
        {
            _Connectionstring = value;
        }
    }
}

