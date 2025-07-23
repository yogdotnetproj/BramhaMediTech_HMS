using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;

/// <summary>
/// Summary description for k_CommonServices
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class k_CommonServices : System.Web.Services.WebService
{
    struct menus
    {
        public string MenuName { get; set; }
        public Dictionary<string, string> SubMenuNames { get; set; }
    }
    public k_CommonServices()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public void BindMenuList()
    {
        List<menus> menuList = new List<menus>() {
            new menus() { MenuName = "OT", SubMenuNames = new Dictionary<string,string>() { { "OT Register", "/OTRegister.aspx" }, { "OT Schedule", "/OTSchedule.aspx" }  } },
            new menus() { MenuName = "EMR", SubMenuNames = new Dictionary<string,string>() { { "General EMR", "/GeneralEMR.aspx" }, } },
        };

        JavaScriptSerializer js = new JavaScriptSerializer();
        Context.Response.Write(js.Serialize(menuList));
    }

}
