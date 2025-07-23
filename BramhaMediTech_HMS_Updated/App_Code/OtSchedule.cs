using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;

/// <summary>
/// Summary description for OtSchedule
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class OtSchedule : System.Web.Services.WebService
{

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

    class clsText1
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }




    private static DataSet FillOtSelects()
    {
        DataSet dt = new DataSet();
        try
        {


            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;

            using (SqlConnection connection = DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("usb_GetOTScheduleSelect", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    connection.Open();

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                }
            }
        }
        catch (Exception)
        {


        }
        return dt;
    }


    [WebMethod]
    public void GetOtScheduleData()
    {


        clsData obj = new clsData();
        try
        {
            DataSet ds = FillOtSelects();
            #region bind select
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        obj.listOpCategory.Add(Convert.ToString(ds.Tables[0].Rows[i]["OprnCatId"]), Convert.ToString(ds.Tables[0].Rows[i]["OprnCat"]));
                    }
                }

                if (ds.Tables[1].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                    {
                        obj.listOpName.Add(Convert.ToString(ds.Tables[1].Rows[i]["OprnId"]), Convert.ToString(ds.Tables[1].Rows[i]["Oprn"]));
                    }
                }

                if (ds.Tables[2].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[2].Rows.Count; i++)
                    {
                        obj.listOpTheater.Add(Convert.ToString(ds.Tables[2].Rows[i]["OTId"]), Convert.ToString(ds.Tables[2].Rows[i]["OTType"]));
                    }
                }

                if (ds.Tables[3].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[3].Rows.Count; i++)
                    {
                        obj.listDocName.Add(Convert.ToString(ds.Tables[3].Rows[i]["CUId"]), Convert.ToString(ds.Tables[3].Rows[i]["username"]));
                    }
                }

                if (ds.Tables[4].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[4].Rows.Count; i++)
                    {
                        obj.listAnName.Add(Convert.ToString(ds.Tables[4].Rows[i]["CUId"]), Convert.ToString(ds.Tables[4].Rows[i]["username"]));
                    }
                }
            }
            #endregion
        }
        catch (Exception)
        {


        }
        JavaScriptSerializer js = new JavaScriptSerializer();
        Context.Response.Write(js.Serialize(obj));
    }

    List<clsOTSchedule> listTreatment = new List<clsOTSchedule>();
    //{
    //        new clsOTSchedule() { OpCategory="Cat1", OpName="A1", OpTheater="Th1", DrName="Dr1", AnName="An1",
    //            OtDate ="2/2/2019", OtTime="09:00", PatRegId="2", Opd="Opd1", Ipd="Ipd1" },
    //        new clsOTSchedule() { OpCategory="Cat1", OpName="A1", OpTheater="Th1", DrName="Dr1", AnName="An1",
    //            OtDate ="2/2/2019", OtTime="09:00", PatRegId="1", Opd="Opd1", Ipd="Ipd1" },
    //        new clsOTSchedule() { OpCategory="Cat1", OpName="A1", OpTheater="Th1", DrName="Dr1", AnName="An1",
    //            OtDate ="2/2/2019", OtTime="09:00", PatRegId="3", Opd="Opd1", Ipd="Ipd1" },
    //        new clsOTSchedule() { OpCategory="Cat1", OpName="A1", OpTheater="Th1", DrName="Dr1", AnName="An1",
    //            OtDate ="2/2/2019", OtTime="09:00", PatRegId="2", Opd="Opd1", Ipd="Ipd1" },
    //        new clsOTSchedule() { OpCategory="Cat1", OpName="A1", OpTheater="Th1", DrName="Dr1", AnName="An1",
    //            OtDate ="2/2/2019", OtTime="09:00", PatRegId="1", Opd="Opd1", Ipd="Ipd1" },
    //    };

    private static DataTable GetOtSche(string PatRegId)
    {
        DataTable dt = new DataTable();
        try
        {
            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;

            using (SqlConnection connection = DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("usb_GetOtSchedule", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Patientregid", SqlDbType.VarChar).Value = PatRegId;
                    connection.Open();

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                }
            }
        }
        catch (Exception)
        {


        }
        return dt;
    }

    [WebMethod]
    public void GetOtScheduleTotalData(string patientregid)
    {
        List<clsOTSchedule> list = new List<clsOTSchedule>();
        try
        {
            DataTable dt = GetOtSche(string.IsNullOrEmpty(patientregid) ? "" : patientregid);

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        list.Add(new clsOTSchedule()
                        {
                            OpCategory = Convert.ToString(dt.Rows[i]["OpCategory"]),
                            OpName = Convert.ToString(dt.Rows[i]["OpName"]),
                            OpTheater = Convert.ToString(dt.Rows[i]["OpTheater"]),
                            DrName = Convert.ToString(dt.Rows[i]["DrName"]),
                            AnName = Convert.ToString(dt.Rows[i]["AnName"]),
                            OtDate = Convert.ToString(dt.Rows[i]["OtDate"]),
                            OtTime = Convert.ToString(dt.Rows[i]["OtTime"]),
                            PatRegId = Convert.ToString(dt.Rows[i]["PatRegId"]),
                            Opd = Convert.ToString(dt.Rows[i]["Opd"]),
                            Ipd = Convert.ToString(dt.Rows[i]["Ipd"])
                        });
                    }
                }
            }
        }
        catch (Exception)
        {


        }

        JavaScriptSerializer js = new JavaScriptSerializer();
        Context.Response.Write(js.Serialize(list));
    }

    [WebMethod]
    public void InsertUpdateOtScheduleTotalData(string type, string PatRegId, string Opd, string Ipd, string OpCategory, string OpName,
        string OpTheater, string DrName, string AnName, string OtDate, string OtTime)
    {
        string[] date1 = OtDate.Split('-');
        string res = "";
        try
        {
            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            using (SqlConnection connection = DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("usp_InsertUpdateOtSchedule", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@type", SqlDbType.Int).Value = Convert.ToInt32(type);
                    cmd.Parameters.Add("@OtSchId", SqlDbType.VarChar).Value = "0";
                    cmd.Parameters.Add("@Patientregid", SqlDbType.VarChar).Value = PatRegId;
                    cmd.Parameters.Add("@opd", SqlDbType.VarChar).Value = Opd;
                    cmd.Parameters.Add("@ipd", SqlDbType.VarChar).Value = Ipd;
                    cmd.Parameters.Add("@createdby", SqlDbType.VarChar).Value = "Alex";
                    cmd.Parameters.Add("@OpCategory", SqlDbType.VarChar).Value = OpCategory;
                    cmd.Parameters.Add("@OpName", SqlDbType.VarChar).Value = OpName;
                    cmd.Parameters.Add("@OpTheater", SqlDbType.VarChar).Value = OpTheater;
                    cmd.Parameters.Add("@DrName", SqlDbType.VarChar).Value = DrName;
                    cmd.Parameters.Add("@AnName", SqlDbType.VarChar).Value = AnName;
                    cmd.Parameters.Add("@OtDate", SqlDbType.VarChar).Value = date1[1] + "-" + date1[0] + "-" + date1[2];
                    cmd.Parameters.Add("@OtTime", SqlDbType.VarChar).Value = OtTime;

                    connection.Open();

                    int k = cmd.ExecuteNonQuery();
                    if (k != 0)
                    {
                        res = "Saved successfully.";
                    }
                    else
                    {
                        res = "Something went wrong";
                    }
                }
            }

            //listTreatment.Add(new clsOTSchedule()
            //{
            //    OpCategory = OpCategory,
            //    OpName = OpName,
            //    OpTheater = OpTheater,
            //    DrName = DrName,
            //    AnName = AnName,
            //    OtDate = OtDate,
            //    OtTime = OtTime,
            //    PatRegId = PatRegId,
            //    Opd = Opd,
            //    Ipd = Ipd
            //});


        }
        catch (Exception)
        {


        }
        JavaScriptSerializer js = new JavaScriptSerializer();
        Context.Response.Write(js.Serialize(listTreatment.Where(x => x.PatRegId == PatRegId).ToList()));
    }




    [WebMethod]
    public void GetOtDocScheduleTotalData(string DrName, string OpTheater, string Duration)
    {
        List<clsOTDocSchedule> list = new List<clsOTDocSchedule>();
        try
        {
            DataTable dt = GetOtDocSche(string.IsNullOrEmpty(DrName) || DrName.Contains("Select") ? "" : DrName,
                string.IsNullOrEmpty(OpTheater) || OpTheater.Contains("Select") ? "" : OpTheater,
                string.IsNullOrEmpty(Duration) || Duration.Contains("Select") ? "" : Duration);

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        list.Add(new clsOTDocSchedule()
                        {
                            DocSchId = Convert.ToString(dt.Rows[i]["DocSchId"]),
                            DocName = Convert.ToString(dt.Rows[i]["DocName"]),
                            TheaterName = Convert.ToString(dt.Rows[i]["TheaterName"]),
                            OpStartDateTime = Convert.ToString(dt.Rows[i]["OpStartDateTime"]),
                            Duration = Convert.ToString(dt.Rows[i]["Duration"]),
                        });
                    }
                }
            }
        }
        catch (Exception)
        {


        }
        JavaScriptSerializer js = new JavaScriptSerializer();
        Context.Response.Write(js.Serialize(list));
    }

    private DataTable GetOtDocSche(string v1, string v2, string v3)
    {
        DataTable dt = new DataTable();
        try
        {
            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;

            using (SqlConnection connection = DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("usb_GetOtDocSchedule", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@docName", SqlDbType.VarChar).Value = v1;
                    cmd.Parameters.Add("@theaterName", SqlDbType.VarChar).Value = v2;
                    cmd.Parameters.Add("@opDateTime", SqlDbType.VarChar).Value = v3;

                    connection.Open();

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                }
            }
        }
        catch (Exception)
        {


        }
        return dt;
    }

    [WebMethod]
    public void InsertUpdateOtDocScheduleTotalData(string type, string schId, string thName,
        string DrName, string Duration, string OtDate, string Ottime)
    {
        string[] date1 = OtDate.Split('-');
        string res = "";
        try
        {
            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;

            using (SqlConnection connection = DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("usp_InsertUpdateOtDocSchedule", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@type", SqlDbType.Int).Value = Convert.ToInt32(type);
                    cmd.Parameters.Add("@schId", SqlDbType.VarChar).Value = schId;
                    cmd.Parameters.Add("@DrName", SqlDbType.VarChar).Value = DrName;
                    cmd.Parameters.Add("@thName", SqlDbType.VarChar).Value = thName;
                    cmd.Parameters.Add("@Duration", SqlDbType.VarChar).Value = Duration.Split(' ')[0];
                    //cmd.Parameters.Add("@OtDate", SqlDbType.VarChar).Value = date1;
                    cmd.Parameters.Add("@OtDate", SqlDbType.VarChar).Value = (date1[2] + "-" + date1[1] + "-" + date1[0]) + " " + Ottime;

                    connection.Open();

                    int k = cmd.ExecuteNonQuery();
                    if (k != 0)
                    {
                        res = "Saved successfully.";
                    }
                    else
                    {
                        res = "Something went wrong";
                    }
                }
            }
        }
        catch (Exception)
        {


        }
        JavaScriptSerializer js = new JavaScriptSerializer();
        Context.Response.Write(js.Serialize(res));
    }

    [WebMethod]
    public void DeleteOtDocScheduleTotalData(string schId)
    {
        string res = "";
        try
        {
            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;

            using (SqlConnection connection = DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("usp_DeleteOtDocSchedule", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@schId", SqlDbType.VarChar).Value = schId;

                    connection.Open();

                    int k = cmd.ExecuteNonQuery();
                    if (k != 0)
                    {
                        res = "Deleted successfully.";
                    }
                    else
                    {
                        res = "Something went wrong";
                    }
                }
            }
        }
        catch (Exception)
        {


        }
        JavaScriptSerializer js = new JavaScriptSerializer();
        Context.Response.Write(js.Serialize(res));
    }
}