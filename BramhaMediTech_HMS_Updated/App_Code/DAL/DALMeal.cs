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

/// <summary>
/// Summary description for DALMeal
/// </summary>
public class DALMeal
{
    BELMeal objBELMeal = new BELMeal();
	public DALMeal()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public BELMeal GetMaxOrderNo()
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_GetMaxOrderNo_Meal", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {
            object obj = cmd.ExecuteScalar();
            if (obj == DBNull.Value)
                objBELMeal.OrderNo = 0;
            else
                objBELMeal.OrderNo = Convert.ToInt32(obj) + 1;

            return objBELMeal;
        }
        catch (SqlException)
        {
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }

    public DataSet FillGridMealTime()
    {

        SqlConnection con = DataAccess.ConInitForDC();
        SqlDataAdapter da = new SqlDataAdapter("Sp_MealTimeFillGrid", con);
        DataSet ds = new DataSet();
        con.Open();
        try
        {
            da.Fill(ds);
        }
        catch (SqlException)
        {
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
        return ds;
    }


    public BELMeal SelectOneMealTime(int MealTimeId)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_MealTimeSelectOne", con);
        cmd.CommandType = CommandType.StoredProcedure;


        try
        {
            cmd.Parameters.AddWithValue("@MealTimeId", MealTimeId);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                objBELMeal.MealTimeId = Convert.ToInt32(sdr["MealTimeId"]);
                objBELMeal.MealTime = Convert.ToString(sdr["MealTime"]);
               
                objBELMeal.OrderNo = Convert.ToInt32(sdr["OrderNo"]);


            }
            return objBELMeal;
        }
        catch (SqlException)
        {
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }

    public string UpdateMealTime(BELMeal objBELMeal)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_MealTimeUpdate", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {
            cmd.Parameters.AddWithValue("@MealTimeId", objBELMeal.MealTimeId);
            cmd.Parameters.AddWithValue("@MealTime", objBELMeal.MealTime);
            cmd.Parameters.AddWithValue("@OrderNo", objBELMeal.OrderNo);
            cmd.Parameters.AddWithValue("@UpdatedBy", objBELMeal.UpdatedBy);

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

    public string InsertMealTime(BELMeal objBELMeal)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_MealTimeInsert", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {

            cmd.Parameters.AddWithValue("@MealTime", objBELMeal.MealTime);
            cmd.Parameters.AddWithValue("@OrderNo", objBELMeal.OrderNo);
            cmd.Parameters.AddWithValue("@FId", objBELMeal.FId);
            cmd.Parameters.AddWithValue("@BranchId", objBELMeal.BranchId);
            cmd.Parameters.AddWithValue("@CreatedBy", objBELMeal.CreatedBy);

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

    public string DeleteMealTime(int MealTimeId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_MealTimeDelete", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@MealTimeId", MealTimeId);
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

    //______________________________________________Item Unit___________________________________

    public DataSet FillGridItemUnit()
    {

        SqlConnection con = DataAccess.ConInitForDC();
        SqlDataAdapter da = new SqlDataAdapter("Sp_ItemUnitFillGrid", con);
        DataSet ds = new DataSet();
        con.Open();
        try
        {
            da.Fill(ds);
        }
        catch (SqlException)
        {
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
        return ds;
    }


    public BELMeal SelectOneItemUnit(int ItemUnitId)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_ItemUnitSelectOne", con);
        cmd.CommandType = CommandType.StoredProcedure;


        try
        {
            cmd.Parameters.AddWithValue("@ItemUnitId", ItemUnitId);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                objBELMeal.ItemUnitId = Convert.ToInt32(sdr["ItemUnitId"]);
                objBELMeal.ItemUnitName = Convert.ToString(sdr["ItemUnitName"]);

                objBELMeal.ItemUnitCode = Convert.ToString(sdr["ItemUnitCode"]);


            }
            return objBELMeal;
        }
        catch (SqlException)
        {
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }

    public string UpdateItemUnit(BELMeal objBELMeal)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_ItemUnitUpdate", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {
            cmd.Parameters.AddWithValue("@ItemUnitId", objBELMeal.ItemUnitId);
            cmd.Parameters.AddWithValue("@ItemUnitName", objBELMeal.ItemUnitName);
            cmd.Parameters.AddWithValue("@ItemUnitCode", objBELMeal.ItemUnitCode);
            cmd.Parameters.AddWithValue("@UpdatedBy", objBELMeal.UpdatedBy);

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

    public string InsertItemUnit(BELMeal objBELMeal)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_ItemUnitInsert", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {

            cmd.Parameters.AddWithValue("@ItemUnitName", objBELMeal.ItemUnitName);
            cmd.Parameters.AddWithValue("@ItemUnitCode", objBELMeal.ItemUnitCode);
            cmd.Parameters.AddWithValue("@FId", objBELMeal.FId);
            cmd.Parameters.AddWithValue("@BranchId", objBELMeal.BranchId);
            cmd.Parameters.AddWithValue("@CreatedBy", objBELMeal.CreatedBy);

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

    public string DeleteItemUnit(int ItemUnitId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_ItemUnitDelete", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@ItemUnitId", ItemUnitId);
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

    //_______________________________________Meal Item Master______________________________________

    public DataSet FillGridMealItem()
    {

        SqlConnection con = DataAccess.ConInitForDC();
        SqlDataAdapter da = new SqlDataAdapter("Sp_MealItemFillGrid", con);
        DataSet ds = new DataSet();
        con.Open();
        try
        {
            da.Fill(ds);
        }
        catch (SqlException)
        {
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
        return ds;
    }
    public DataSet FillItemUnitDrop()
    {

        SqlConnection con = DataAccess.ConInitForDC();
        SqlDataAdapter da = new SqlDataAdapter("Sp_ItemUnitFillCombo", con);
        DataSet ds = new DataSet();
        con.Open();
        try
        {
            da.Fill(ds);
        }
        catch (SqlException)
        {
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
        return ds;
    }


    public BELMeal SelectOneMealItem(int FoodItemId)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_MealItemSelectOne", con);
        cmd.CommandType = CommandType.StoredProcedure;


        try
        {
            cmd.Parameters.AddWithValue("@FoodItemId", FoodItemId);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                objBELMeal.FoodItemId = Convert.ToInt32(sdr["FoodItemId"]);
                objBELMeal.FoodItemName = Convert.ToString(sdr["FoodItemName"]);
                objBELMeal.Calories = Convert.ToInt32(sdr["Calories"]);
                objBELMeal.FoodItemQty = Convert.ToInt32(sdr["FoodItemQty"]);
                objBELMeal.Unit = Convert.ToString(sdr["Unit"]);

            }
            return objBELMeal;
        }
        catch (SqlException)
        {
            throw;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }

    public string UpdateMealItem(BELMeal objBELMeal)
    {

        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_MealItemUpdate", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {
            cmd.Parameters.AddWithValue("@FoodItemId", objBELMeal.FoodItemId);
            cmd.Parameters.AddWithValue("@FoodItemName", objBELMeal.FoodItemName);
            cmd.Parameters.AddWithValue("@FoodItemQty", objBELMeal.FoodItemQty);
            cmd.Parameters.AddWithValue("@Unit", objBELMeal.Unit);
            cmd.Parameters.AddWithValue("@Calories", objBELMeal.Calories);
            cmd.Parameters.AddWithValue("@UpdatedBy", objBELMeal.UpdatedBy);

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

    public string InsertMealItem(BELMeal objBELMeal)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        SqlCommand cmd = new SqlCommand("Sp_MealItemInsert", con);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        try
        {

            cmd.Parameters.AddWithValue("@FoodItemName", objBELMeal.FoodItemName);
            cmd.Parameters.AddWithValue("@FoodItemQty", objBELMeal.FoodItemQty);
            cmd.Parameters.AddWithValue("@Unit", objBELMeal.Unit);
            cmd.Parameters.AddWithValue("@Calories", objBELMeal.Calories);
            cmd.Parameters.AddWithValue("@FId", objBELMeal.FId);
            cmd.Parameters.AddWithValue("@BranchId", objBELMeal.BranchId);
            cmd.Parameters.AddWithValue("@CreatedBy", objBELMeal.CreatedBy);

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

    public string DeleteMealItem(int FoodItemId)
    {
        SqlConnection con = DataAccess.ConInitForDC();
        con.Open();
        SqlCommand cmd = new SqlCommand("Sp_MealItemDelete", con);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@FoodItemId", FoodItemId);
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