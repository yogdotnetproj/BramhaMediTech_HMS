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
/// Summary description for serviceCheckList
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class serviceCheckList : System.Web.Services.WebService
{

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

    [WebMethod]
    public void GetCheckListCategories()
    {
        Dictionary<string, string> list = new Dictionary<string, string>();

        DataTable dt = GetCheckListCategoriesDt();

        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(Convert.ToString(dt.Rows[i]["checkListId"]), Convert.ToString(dt.Rows[i]["checkListType"]));
                }
            }
        }

        JavaScriptSerializer js = new JavaScriptSerializer();
        Context.Response.Write(js.Serialize(list));
    }

    private static DataTable GetCheckListCategoriesDt()
    {
        DataTable dt = new DataTable();

        string ConString = ConfigurationManager.ConnectionStrings["DBHospital"].ConnectionString;

        using (SqlConnection connection =
                   new SqlConnection(ConString))
        {
            using (SqlCommand cmd = new SqlCommand("usp_GetCheckListCats", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                connection.Open();

                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(dt);
                }
            }
        }

        return dt;
    }

    private static DataTable GetChecklistCat(string type, string schId, string checkListType, string details)
    {
        DataTable dt = new DataTable();

        string ConString = ConfigurationManager.ConnectionStrings["DBHospital"].ConnectionString;

        using (SqlConnection connection =
                   new SqlConnection(ConString))
        {
            using (SqlCommand cmd = new SqlCommand("InsertUpdateDelete_tbl_CheckListTran", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@checkListId", SqlDbType.VarChar).Value = checkListType;
                cmd.Parameters.Add("@checkListTranId", SqlDbType.VarChar).Value = schId;
                //cmd.Parameters.Add("@checkListId", SqlDbType.Int).Value = Convert.ToInt32(checkListType);
                //cmd.Parameters.Add("@checkListTranId", SqlDbType.Int).Value = Convert.ToInt32(schId);
                cmd.Parameters.Add("@checkListTranName", SqlDbType.VarChar).Value = details;
                cmd.Parameters.Add("@StatementType", SqlDbType.VarChar).Value = type;

                connection.Open();

                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(dt);
                }
            }
        }

        return dt;
    }

    [WebMethod]
    public void GetCheckListData(string type, string schId, string checkListType, string details)
    {
        Dictionary<string, string> list = new Dictionary<string, string>();

        DataTable dt = GetChecklistCat(type, schId, checkListType, details);

        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(Convert.ToString(dt.Rows[i]["checkListTranId"]) + "-" +
                        Convert.ToString(dt.Rows[i]["checkListId"]),
                        Convert.ToString(dt.Rows[i]["checkListTranName"]));
                }
            }
        }

        JavaScriptSerializer js = new JavaScriptSerializer();
        Context.Response.Write(js.Serialize(list));
    }

    [WebMethod]
    public void InsertUpdateCheckList(string type, string schId, string checkListType, string details)
    {
        string stmtType = "";
        string res = "";

        switch (type)
        {
            case "1":
                stmtType = "Insert";
                res = "Inserted successfully.";
                break;
            case "2":
                stmtType = "Update";
                res = "Updated successfully";
                break;
            case "3":
                stmtType = "Delete";
                res = "Deleted successfully";
                break;
        }

        string ConString = ConfigurationManager.ConnectionStrings["DBHospital"].ConnectionString;

        using (SqlConnection connection =
                   new SqlConnection(ConString))
        {
            using (SqlCommand cmd = new SqlCommand("InsertUpdateDelete_tbl_CheckListTran", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@checkListId", SqlDbType.VarChar).Value = checkListType;
                cmd.Parameters.Add("@checkListTranId", SqlDbType.VarChar).Value = schId;
                cmd.Parameters.Add("@checkListTranName", SqlDbType.VarChar).Value = details;
                cmd.Parameters.Add("@StatementType", SqlDbType.VarChar).Value = stmtType;

                connection.Open();

                int k = cmd.ExecuteNonQuery();
                if (k == 0)
                {
                    res = "Something went wrong";
                }
            }
        }

        JavaScriptSerializer js = new JavaScriptSerializer();
        Context.Response.Write(js.Serialize(res));
    }

    //-------------------------------------------------------------------------------------------------------------

    [WebMethod]
    public void GetCheckListCategoriesType(string checkListType)
    {
        Dictionary<string, string> list = new Dictionary<string, string>();

        DataTable dt = GetCheckListCategoriesTypeDt(checkListType);

        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(Convert.ToString(i),
                        Convert.ToString(dt.Rows[i]["checkListTranName"]));
                }
            }
        }

        JavaScriptSerializer js = new JavaScriptSerializer();
        Context.Response.Write(js.Serialize(list));
    }

    private static DataTable GetCheckListCategoriesTypeDt(string checkListType)
    {
        DataTable dt = new DataTable();

        string ConString = ConfigurationManager.ConnectionStrings["DBHospital"].ConnectionString;

        using (SqlConnection connection =
                   new SqlConnection(ConString))
        {
            using (SqlCommand cmd = new SqlCommand("usp_GetCheckListCatsType", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@checkListId", SqlDbType.VarChar).Value = checkListType;

                connection.Open();

                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(dt);
                }
            }
        }

        return dt;
    }

    [WebMethod]
    public void GetCheckListDetailsData(string type, string schId, string checkListType, string details)
    {
        Dictionary<string, string> list = new Dictionary<string, string>();

        DataTable dt = GetChecklistCat(type, schId, checkListType, details);

        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(Convert.ToString(dt.Rows[i]["checkListTranId"]) + "-" +
                        Convert.ToString(dt.Rows[i]["checkListId"]),
                        Convert.ToString(dt.Rows[i]["checkListTranName"]));
                }
            }
        }

        JavaScriptSerializer js = new JavaScriptSerializer();
        Context.Response.Write(js.Serialize(list));
    }

    [WebMethod]
    public void InsertUpdateCheckListDetails(string type, string checkListDetailsId, string MrdNo, string Ipd,
        string PatientName, string DoctorInc, string RoomType, string DateOfAdmission, string BedNo, string Diagnosis)
    {
        string stmtType = "";
        string res = "";

        switch (type)
        {
            case "1":
                stmtType = "Insert";
                res = "Inserted successfully.";
                break;
            case "2":
                stmtType = "Update";
                res = "Updated successfully";
                break;
            case "3":
                stmtType = "Delete";
                res = "Deleted successfully";
                break;
        }

        string ConString = ConfigurationManager.ConnectionStrings["DBHospital"].ConnectionString;

        using (SqlConnection connection =
                   new SqlConnection(ConString))
        {
            using (SqlCommand cmd = new SqlCommand("InsertUpdateDelete_tbl_SurgeryCheckListDetails", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@checkListDetailsId", SqlDbType.VarChar).Value = checkListDetailsId;
                cmd.Parameters.Add("@MrdNo", SqlDbType.VarChar).Value = MrdNo;
                cmd.Parameters.Add("@Ipd", SqlDbType.VarChar).Value = Ipd;
                cmd.Parameters.Add("@PatientName", SqlDbType.VarChar).Value = PatientName;
                cmd.Parameters.Add("@DoctorInc", SqlDbType.VarChar).Value = DoctorInc;
                cmd.Parameters.Add("@RoomType", SqlDbType.VarChar).Value = RoomType;
                cmd.Parameters.Add("@DateOfAdmission", SqlDbType.VarChar).Value = DateOfAdmission;
                cmd.Parameters.Add("@BedNo", SqlDbType.VarChar).Value = BedNo;
                cmd.Parameters.Add("@Diagnosis", SqlDbType.VarChar).Value = Diagnosis;
                cmd.Parameters.Add("@StatementType", SqlDbType.VarChar).Value = stmtType;

                connection.Open();

                int k = cmd.ExecuteNonQuery();
                if (k == 0)
                {
                    res = "Something went wrong";
                }
            }
        }

        JavaScriptSerializer js = new JavaScriptSerializer();
        Context.Response.Write(js.Serialize(res));
    }

    [WebMethod]
    public void GetCheckListDetails1(string mrd, string ipd, string schId)
    {
        Dictionary<string, string> list = new Dictionary<string, string>();

        DataTable dt = GetChecklistMainDetails(mrd, ipd, schId);

        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    foreach (DataColumn column in dt.Columns)
                    {
                        list.Add(column.ColumnName, row[column].ToString());
                    }
                }
            }
        }

        JavaScriptSerializer js = new JavaScriptSerializer();
        Context.Response.Write(js.Serialize(list));
    }

    private DataTable GetChecklistMainDetails(string mrd, string ipd, string schId)
    {
        DataTable dt = new DataTable();

        string ConString = ConfigurationManager.ConnectionStrings["DBHospital"].ConnectionString;

        using (SqlConnection connection =
                   new SqlConnection(ConString))
        {
            using (SqlCommand cmd = new SqlCommand("usp_GetChecklistMainDetails", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@mrd", SqlDbType.VarChar).Value = mrd;
                cmd.Parameters.Add("@ipd", SqlDbType.VarChar).Value = ipd;
                cmd.Parameters.Add("@schid", SqlDbType.VarChar).Value = schId;

                connection.Open();

                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(dt);
                }
            }
        }

        return dt;
    }
}

