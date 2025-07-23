using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for AutoCompleteService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
 [System.Web.Script.Services.ScriptService]
public class AutoCompleteService : System.Web.Services.WebService {

    public AutoCompleteService () 
    {
        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }
    
    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<string> SearchPatient(string prefixText, int count)
    {
       
        DALOpdReg objDALOpdReg = new DALOpdReg();
        return objDALOpdReg.FillAllPatient(prefixText);

        
    }

   
   
}
