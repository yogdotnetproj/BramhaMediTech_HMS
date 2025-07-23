using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for clsDocSchedule
/// </summary>
public class clsDocSchedule
{
    public string DoctorId { get; set; }
    public string Date1 { get; set; }
    public string Date2 { get; set; }
    public string Time1 { get; set; }
    public string Time2 { get; set; }
    public string Slot { get; set; }
    public clsDocSchedule()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}