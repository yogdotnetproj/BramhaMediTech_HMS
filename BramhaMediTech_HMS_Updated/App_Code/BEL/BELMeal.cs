using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BELMeal
/// </summary>
public class BELMeal
{
	public BELMeal()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private int _MealTimeId;
    public int MealTimeId { get { return _MealTimeId; } set { _MealTimeId = value; } }

    private int _OrderNo;
    public int OrderNo { get { return _OrderNo; } set { _OrderNo = value; } }

    private string _MealTime;
    public string MealTime { get { return _MealTime; } set { _MealTime = value; } }

    private int _ItemUnitId;
    public int ItemUnitId { get { return _ItemUnitId; } set { _ItemUnitId = value; } }

    private string _ItemUnitName;
    public string ItemUnitName { get { return _ItemUnitName; } set { _ItemUnitName = value; } }

    private string _ItemUnitCode;
    public string ItemUnitCode { get { return _ItemUnitCode; } set { _ItemUnitCode = value; } }

    private int _FoodItemId;
    public int FoodItemId { get { return _FoodItemId; } set { _FoodItemId = value; } }

    private string _FoodItemName;
    public string FoodItemName { get { return _FoodItemName; } set { _FoodItemName = value; } }

    private int _FoodItemQty;
    public int FoodItemQty { get { return _FoodItemQty; } set { _FoodItemQty = value; } }

    private string _Unit;
    public string Unit { get { return _Unit; } set { _Unit = value; } }

    private int _Calories;
    public int Calories { get { return _Calories; } set { _Calories = value; } }


    private string _FId;
    public string FId { get { return _FId; } set { _FId = value; } }

    private string _CreatedBy;
    public string CreatedBy { get { return _CreatedBy; } set { _CreatedBy = value; } }

    private DateTime _CreatedOn;
    public DateTime CreatedOn { get { return _CreatedOn; } set { _CreatedOn = value; } }

    private string _UpdatedBy;
    public string UpdatedBy { get { return _UpdatedBy; } set { _UpdatedBy = value; } }

    private DateTime _UpdatedOn;
    public DateTime UpdatedOn { get { return _UpdatedOn; } set { _UpdatedOn = value; } }

    private int _BranchId;
    public int BranchId { get { return _BranchId; } set { _BranchId = value; } }

}