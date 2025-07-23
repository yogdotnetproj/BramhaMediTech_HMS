using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

/// <summary>
/// Summary description for BELPostpartumExamination
/// </summary>
public class BELDeliveryNote
{
    DALDeliveryNote ObjDALDN = new DALDeliveryNote();
    public BELDeliveryNote()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataTable GetAllDeliveryNote(DALDeliveryNote obj)//string patregId
    {
        DataTable dt = new DataTable();
        try
        {
            //string ConString = ConfigurationManager.ConnectionStrings["myconnection1"].ConnectionString;
            using (SqlConnection connection =
                      DataAccess.ConInitForDC())
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetDeliveryNote", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Patregid", obj.Patregid);
                    cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
                    cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);
                    cmd.Parameters.AddWithValue("@Branchid", obj.BranchId);
                    cmd.Parameters.AddWithValue("@FID", obj.FId);
                    connection.Open();

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        connection.Open();
                        sda.Fill(dt);
                        connection.Close();
                        connection.Dispose();
                    }
                }
            }
        }
        catch (Exception)
        {
        }
        return dt;
    }
    public string InsertDeliveryNote(DALDeliveryNote obj)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("SP_InsertDeliveryNoteToPatient", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            cmd.Parameters.AddWithValue("@Patregid", obj.Patregid);
            cmd.Parameters.AddWithValue("@OpdNo", obj.OpdNo);
            cmd.Parameters.AddWithValue("@IpdNo", obj.IpdNo);
            cmd.Parameters.AddWithValue("@DeliveryConductBy", obj.DeliveryConductBy);
            cmd.Parameters.AddWithValue("@Gravida", obj.Gravida);
            cmd.Parameters.AddWithValue("@HusbandName", obj.HusbandName);
            cmd.Parameters.AddWithValue("@Condition", obj.Condition);
            cmd.Parameters.AddWithValue("@DeliveryDate", obj.DeliveryDate);

            cmd.Parameters.AddWithValue("@Matuarity", obj.Matuarity);
            cmd.Parameters.AddWithValue("@NumberOfBaby", obj.NumberOfBaby);
            cmd.Parameters.AddWithValue("@MaternialDeath", obj.MaternialDeath);
            cmd.Parameters.AddWithValue("@ModeofDelivery", obj.ModeofDelivery);

            cmd.Parameters.AddWithValue("@GenderofBaby", obj.GenderofBaby);
            cmd.Parameters.AddWithValue("@DeliveryTime", obj.DeliveryTime);
            cmd.Parameters.AddWithValue("@WeightOfBaby", obj.WeightOfBaby);
            cmd.Parameters.AddWithValue("@Para", obj.Para);

            cmd.Parameters.AddWithValue("@StillBirth", obj.StillBirth);
            cmd.Parameters.AddWithValue("@Living", obj.Living);
            cmd.Parameters.AddWithValue("@Abortion", obj.Abortion);
            cmd.Parameters.AddWithValue("@Comments", obj.Comments);
            cmd.Parameters.AddWithValue("@MaterinityDeathReason", obj.MaterinityDeathReason);
            
            
            cmd.Parameters.AddWithValue("@Branchid", obj.BranchId);
            cmd.Parameters.AddWithValue("@CreatedBy", obj.CreatedBy);

          

            cmd.Parameters.AddWithValue("@FID", obj.FId);
           

            object Result = cmd.ExecuteScalar();
            return Convert.ToString(Result);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }
}