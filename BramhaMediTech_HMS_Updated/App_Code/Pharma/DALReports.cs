using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.Common;

/// <summary>
/// Summary description for DALReports
/// </summary>
public class DALReports
{
    string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;//ToString();
	public DALReports()
	{
		//
		// TODO: Add constructor logic here
		//
	}

 public DataSet GetIndends(BEL indent )
    {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("SPR_VW_IndendRequest", con);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@DeptId", indent.DeptId);
        cmd.Parameters.AddWithValue("@ItemId", indent.ItemId);
        cmd.Parameters.AddWithValue("@ReqId", indent.ReqId);
        cmd.Parameters.AddWithValue("@RPIFlag",indent.RPIflag);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
     
        sda.Fill(ds);
        ds.Tables[0].TableName = "Vw_IndentRequest";
       
        con.Close();
            return ds;
        
    }
 public DataSet GetIndendReq(BEL indent)
 {
     SqlConnection con = new SqlConnection(constr);
     con.Open();
     SqlCommand cmd = new SqlCommand("SPR_VW_IndendRequestOnSave", con);
     cmd.CommandType = CommandType.StoredProcedure;

     cmd.Parameters.AddWithValue("@DeptId", indent.DeptId);     
     cmd.Parameters.AddWithValue("@ReqId", indent.ReqId);
     cmd.Parameters.AddWithValue("@RPIFlag", indent.RPIflag);
     cmd.Parameters.AddWithValue("@FId", indent.Fid);
     
     cmd.Parameters.AddWithValue("@BranchId", indent.BranchId);
     cmd.Parameters.AddWithValue("@VoucherNo", indent.VoucherNo);
     SqlDataAdapter sda = new SqlDataAdapter(cmd);
     DataSet ds = new DataSet();

     sda.Fill(ds);
     ds.Tables[0].TableName = "Vw_IndentRequest";

     con.Close();
     return ds;

 }

 public DataTable GetIndendReq_Report(BEL indent)
 {
     SqlConnection con = new SqlConnection(constr);
     con.Open();
     SqlCommand cmd = new SqlCommand("SPR_VW_IndendRequestOnSave", con);
     cmd.CommandType = CommandType.StoredProcedure;

     cmd.Parameters.AddWithValue("@DeptId", indent.DeptId);
     cmd.Parameters.AddWithValue("@ReqId", indent.ReqId);
     cmd.Parameters.AddWithValue("@RPIFlag", indent.RPIflag);
     cmd.Parameters.AddWithValue("@FId", indent.Fid);

     cmd.Parameters.AddWithValue("@BranchId", indent.BranchId);
     cmd.Parameters.AddWithValue("@VoucherNo", indent.VoucherNo);
     SqlDataAdapter sda = new SqlDataAdapter(cmd);
     DataTable ds = new DataTable();

     sda.Fill(ds);
     //ds.Tables[0].TableName = "Vw_IndentRequest";

     con.Close();
     con.Dispose();
     return ds;

 }

 public DataSet GetIndendReq_WareHouseDept(BEL indent)
 {
     SqlConnection con = new SqlConnection(constr);
     con.Open();
     SqlCommand cmd = new SqlCommand("SPR_VW_DeptIndReq_Warehouse", con);
     cmd.CommandType = CommandType.StoredProcedure;

     cmd.Parameters.AddWithValue("@DeptId", indent.DeptId);
     cmd.Parameters.AddWithValue("@ReqId", indent.ReqId);
     //cmd.Parameters.AddWithValue("@RPIFlag", indent.RPIflag);
     cmd.Parameters.AddWithValue("@FId", indent.Fid);
     cmd.Parameters.AddWithValue("@BranchId", indent.BranchId);
     cmd.Parameters.AddWithValue("@WareHouseId", indent.WareHouseId);
     SqlDataAdapter sda = new SqlDataAdapter(cmd);
     DataSet ds = new DataSet();

     sda.Fill(ds);
     ds.Tables[0].TableName = "VW_DeptIndReq_Warehouse";

     con.Close();
     return ds;

 }

       public DataSet GetBatchWiseItemStock(BEL ItemStock)
        {
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("SPR_Vw_BatchwiseItemStock", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ItemId", ItemStock.ItemId);
        cmd.Parameters.AddWithValue("@BatchNo", ItemStock.BatchNo);
        cmd.Parameters.AddWithValue("@CategoryId", ItemStock.CategoryId);
        cmd.Parameters.AddWithValue("@MainCategory", ItemStock.MainCategory);
        cmd.Parameters.AddWithValue("@FId", ItemStock.Fid);
        cmd.Parameters.AddWithValue("@BranchId", ItemStock.BranchId);
        cmd.Parameters.AddWithValue("@Flag", ItemStock.ItemType);
        cmd.Parameters.AddWithValue("@WareHouseId", ItemStock.WareHouseId);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
     
        sda.Fill(ds);
        ds.Tables[0].TableName = "Vw_BatchwiseItemStock";
       
        con.Close();
 return ds;
        
    }
       public DataSet GetBatchWiseItemStockNew(BEL ItemStock)
       {
           SqlConnection con = new SqlConnection(constr);
           con.Open();
           SqlCommand cmd = new SqlCommand("Sp_BatchWiseWarehouseStock", con);
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.Parameters.AddWithValue("@ItemId", ItemStock.ItemId);
           cmd.Parameters.AddWithValue("@BatchNo", ItemStock.BatchNo);
           cmd.Parameters.AddWithValue("@CategoryId", ItemStock.CategoryId);
           cmd.Parameters.AddWithValue("@MainCategory", ItemStock.MainCategory);
           cmd.Parameters.AddWithValue("@FId", ItemStock.Fid);
           cmd.Parameters.AddWithValue("@BranchId", ItemStock.BranchId);
           cmd.Parameters.AddWithValue("@Flag", ItemStock.ItemType);
           cmd.Parameters.AddWithValue("@WareHouseId", ItemStock.WareHouseId);
           SqlDataAdapter sda = new SqlDataAdapter(cmd);
           DataSet ds = new DataSet();

           sda.Fill(ds);
           ds.Tables[0].TableName = "WareHouseItemStock";

           con.Close();
           return ds;

       }

       public DataSet GetItemWiseCurrentStockNew(BEL ItemStock)
       {
           SqlConnection con = new SqlConnection(constr);
           con.Open();
           SqlCommand cmd = new SqlCommand("Sp_ItemWiseWarehouseCurrentStock", con);
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.Parameters.AddWithValue("@ItemId", ItemStock.ItemId);          
           cmd.Parameters.AddWithValue("@CategoryId", ItemStock.CategoryId);
           cmd.Parameters.AddWithValue("@MainCategory", ItemStock.MainCategory);
           cmd.Parameters.AddWithValue("@FId", ItemStock.Fid);
           cmd.Parameters.AddWithValue("@BranchId", ItemStock.BranchId);
           cmd.Parameters.AddWithValue("@WareHouseId", ItemStock.WareHouseId);
           SqlDataAdapter sda = new SqlDataAdapter(cmd);
           DataSet ds = new DataSet();

           sda.Fill(ds);
           ds.Tables[0].TableName = "WareHouseItemStock";

           con.Close();
           return ds;

       }

       public DataSet GetItemWiseCurrentStockNew_Zero(BEL ItemStock)
       {
           SqlConnection con = new SqlConnection(constr);
           con.Open();
           SqlCommand cmd = new SqlCommand("Sp_ItemWiseWarehouseCurrentStock_Zero", con);
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.Parameters.AddWithValue("@ItemId", ItemStock.ItemId);
           cmd.Parameters.AddWithValue("@CategoryId", ItemStock.CategoryId);
           cmd.Parameters.AddWithValue("@MainCategory", ItemStock.MainCategory);
           cmd.Parameters.AddWithValue("@FId", ItemStock.Fid);
           cmd.Parameters.AddWithValue("@BranchId", ItemStock.BranchId);
           cmd.Parameters.AddWithValue("@WareHouseId", ItemStock.WareHouseId);
           SqlDataAdapter sda = new SqlDataAdapter(cmd);
           DataSet ds = new DataSet();

           sda.Fill(ds);
           ds.Tables[0].TableName = "WareHouseItemStock";

           con.Close();
           return ds;

       }
   public DataSet GetItemWiseCurrentStock(BEL ItemStock)
   {
       SqlConnection con = new SqlConnection(constr);
       con.Open();
       SqlCommand cmd = new SqlCommand("Sp_Vw_ItemWiseCurrentStock", con);
       cmd.CommandType = CommandType.StoredProcedure;
       cmd.Parameters.AddWithValue("@ItemId", ItemStock.ItemId);
      // cmd.Parameters.AddWithValue("@BatchNo", ItemStock.BatchNo);
       cmd.Parameters.AddWithValue("@CategoryId", ItemStock.CategoryId);
       cmd.Parameters.AddWithValue("@MainCategory", ItemStock.MainCategory);
       cmd.Parameters.AddWithValue("@FId", ItemStock.Fid);
       cmd.Parameters.AddWithValue("@BranchId", ItemStock.BranchId);

       SqlDataAdapter sda = new SqlDataAdapter(cmd);
       DataSet ds = new DataSet();

       sda.Fill(ds);
       ds.Tables[0].TableName = "Vw_ItemWiseCurrentStock";

       con.Close();
       return ds;

   }
   public DataSet GetDeptItemStock(BEL ItemStock)
   {
       SqlConnection con = new SqlConnection(constr);
       con.Open();
       SqlCommand cmd = new SqlCommand("Sp_BatchWiseDeptStockSearch", con);
       cmd.CommandType = CommandType.StoredProcedure;
       cmd.Parameters.AddWithValue("@ItemId", ItemStock.ItemId);
       cmd.Parameters.AddWithValue("@DeptId", ItemStock.DeptId);
       cmd.Parameters.AddWithValue("@CategoryId", ItemStock.CategoryId);
       cmd.Parameters.AddWithValue("@MainCategory", ItemStock.MainCategory);
       cmd.Parameters.AddWithValue("@BranchId", ItemStock.BranchId);
       cmd.Parameters.AddWithValue("@Flag", ItemStock.ItemType);
       cmd.Parameters.AddWithValue("@FId", ItemStock.Fid);

       SqlDataAdapter sda = new SqlDataAdapter(cmd);
       DataSet ds = new DataSet();

       sda.Fill(ds);
       ds.Tables[0].TableName = "Vw_DeptCurrentStock";

       con.Close();
       return ds;

   }
   public DataSet GetDeptItemStockNew(BEL ItemStock)
   {
       SqlConnection con = new SqlConnection(constr);
       con.Open();
       SqlCommand cmd = new SqlCommand("Sp_BatchWiseDeptStockNew", con);
       cmd.CommandType = CommandType.StoredProcedure;
       cmd.Parameters.AddWithValue("@ItemId", ItemStock.ItemId);
       cmd.Parameters.AddWithValue("@DeptId", ItemStock.DeptId);
       cmd.Parameters.AddWithValue("@CategoryId", ItemStock.CategoryId);
       cmd.Parameters.AddWithValue("@MainCategory", ItemStock.MainCategory);
       cmd.Parameters.AddWithValue("@BranchId", ItemStock.BranchId);
       cmd.Parameters.AddWithValue("@Flag", ItemStock.ItemType);
       cmd.Parameters.AddWithValue("@FId", ItemStock.Fid);

       SqlDataAdapter sda = new SqlDataAdapter(cmd);
       DataSet ds = new DataSet();

       sda.Fill(ds);
       ds.Tables[0].TableName = "ItemWiseDeptStock";

       con.Close();
       return ds;

   }

   public DataSet GetDeptWiseItemStock(BEL ItemStock)
   {
       SqlConnection con = new SqlConnection(constr);
       con.Open();
       SqlCommand cmd = new SqlCommand("SPR_Vw_BatchwiseItemStock", con);
       cmd.CommandType = CommandType.StoredProcedure;
       cmd.Parameters.AddWithValue("@ItemId", ItemStock.ItemId);
       cmd.Parameters.AddWithValue("@BatchNo", ItemStock.BatchNo);

       SqlDataAdapter sda = new SqlDataAdapter(cmd);
       DataSet ds = new DataSet();

       sda.Fill(ds);
       ds.Tables[0].TableName = "Vw_BatchwiseItemStock";

       con.Close();
       return ds;

   }
   public DataSet GetInvoiceList(string FromDate, string ToDate, int SuppId, int InvoiceNo,int Status,int FId,int BranchId,int WareHouseId)
   {
       SqlConnection con = new SqlConnection(constr);
       con.Open();
       SqlCommand cmd = new SqlCommand("Sp_Vw_InvoiceListRpt", con);
       cmd.CommandType = CommandType.StoredProcedure;
       try
       {
           if (FromDate == "")
           {
               cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
           }
           else
           {
               // cmd.Parameters.AddWithValue("@FromDate",Convert.ToDateTime(FromDate));
               cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
           }
           if (ToDate == "")
           {
               cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

           }
           else
           {
               // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
               cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
           }

           cmd.Parameters.AddWithValue("@SupplierId", SuppId);
           cmd.Parameters.AddWithValue("@InvoiceNo", InvoiceNo);
           cmd.Parameters.AddWithValue("@Status", Status);
           cmd.Parameters.AddWithValue("@FId", FId);
           cmd.Parameters.AddWithValue("@BranchId", BranchId);
           cmd.Parameters.AddWithValue("@WareHouseId", WareHouseId);
           SqlDataAdapter sda = new SqlDataAdapter(cmd);
           DataSet ds = new DataSet();
           sda.Fill(ds);
           ds.Tables[0].TableName = "Vw_InvoiceOnSave";
           // ds.Tables[1].TableName = "Vw_POList";
           return ds;

       }
       catch (Exception ex)
       {
           throw ex;
       }
       finally
       {
           con.Dispose();
           con.Close();
       }
   }

   public DataSet GetSupplierInvoiceList(string FromDate, string ToDate, int SuppId, int InvoiceNo, int FId, int BranchId, int ItemId, int MainCategory,int WareHouseId)
   {
       SqlConnection con = new SqlConnection(constr);
       con.Open();
       SqlCommand cmd = new SqlCommand("Sp_SupplierInvoiceListRpt", con);
       cmd.CommandType = CommandType.StoredProcedure;
       try
       {
           if (FromDate == "")
           {
               cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
           }
           else
           {
               // cmd.Parameters.AddWithValue("@FromDate",Convert.ToDateTime(FromDate));
               cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
           }
           if (ToDate == "")
           {
               cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

           }
           else
           {
               // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
               cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
           }

           cmd.Parameters.AddWithValue("@SupplierId", SuppId);
           cmd.Parameters.AddWithValue("@InvoiceNo", InvoiceNo);
           cmd.Parameters.AddWithValue("@FId", FId);
           cmd.Parameters.AddWithValue("@BranchId", BranchId);
           cmd.Parameters.AddWithValue("@ItemId", ItemId);
           cmd.Parameters.AddWithValue("@MainCategory", MainCategory);
           cmd.Parameters.AddWithValue("@WareHouseId", WareHouseId);
           SqlDataAdapter sda = new SqlDataAdapter(cmd);
           DataSet ds = new DataSet();
           sda.Fill(ds);
           ds.Tables[0].TableName = "Vw_InvoiceOnSave";
           // ds.Tables[1].TableName = "Vw_POList";
           return ds;

       }
       catch (Exception ex)
       {
           throw ex;
       }
       finally
       {
           con.Dispose();
           con.Close();
       }
   }
   public DataSet GetItemWiseMonthlyConsumption(string FromDate, string ToDate, int ItemId, int FId, int BranchId,int WareHouseId)
   {
       SqlConnection con = new SqlConnection(constr);
       con.Open();
       SqlCommand cmd = new SqlCommand("Sp_Vw_ItemWiseMonthlyConsumption", con);
       cmd.CommandType = CommandType.StoredProcedure;
       try
       {
           if (FromDate == "")
           {
               cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
           }
           else
           {
               // cmd.Parameters.AddWithValue("@FromDate",Convert.ToDateTime(FromDate));
               cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
           }
           if (ToDate == "")
           {
               cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

           }
           else
           {
               // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
               cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
           }

          
           cmd.Parameters.AddWithValue("@FId", FId);
           cmd.Parameters.AddWithValue("@BranchId", BranchId);
           cmd.Parameters.AddWithValue("@ItemId", ItemId);
           SqlDataAdapter sda = new SqlDataAdapter(cmd);
           DataSet ds = new DataSet();
           sda.Fill(ds);
           ds.Tables[0].TableName = "Vw_ItemWiseMonthlyConsumption";
           // ds.Tables[1].TableName = "Vw_POList";
           return ds;

       }
       catch (Exception ex)
       {
           throw ex;
       }
       finally
       {
           con.Dispose();
           con.Close();
       }
   }
   public DataSet GetItemWiseMonthlyConsumptionForStore(string FromDate, string ToDate, int ItemId,int DeptId, int FId, int BranchId)
   {
       SqlConnection con = new SqlConnection(constr);
       con.Open();
       SqlCommand cmd = new SqlCommand("Sp_Vw_ItemWiseMonthlyConsumptionForStore", con);
       cmd.CommandType = CommandType.StoredProcedure;
       try
       {
           if (FromDate == "")
           {
               cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
           }
           else
           {
               // cmd.Parameters.AddWithValue("@FromDate",Convert.ToDateTime(FromDate));
               cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
           }
           if (ToDate == "")
           {
               cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

           }
           else
           {
               // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
               cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
           }


           cmd.Parameters.AddWithValue("@FId", FId);
           cmd.Parameters.AddWithValue("@BranchId", BranchId);
           cmd.Parameters.AddWithValue("@ItemId", ItemId);
           cmd.Parameters.AddWithValue("@DeptId", DeptId);
           SqlDataAdapter sda = new SqlDataAdapter(cmd);
           DataSet ds = new DataSet();
           sda.Fill(ds);
           ds.Tables[0].TableName = "Vw_ItemWiseMonthlyConsumptionForStore";
           // ds.Tables[1].TableName = "Vw_POList";
           return ds;

       }
       catch (Exception ex)
       {
           throw ex;
       }
       finally
       {
           con.Dispose();
           con.Close();
       }
   }
   public DataSet GetTaxWiseReportForStore(string FromDate, string ToDate, int DeptId, int FId, int BranchId)
   {
       SqlConnection con = new SqlConnection(constr);
       con.Open();
       SqlCommand cmd = new SqlCommand("Sp_TaxByAreaReport", con);
       cmd.CommandType = CommandType.StoredProcedure;
       try
       {
           if (FromDate == "")
           {
               cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
           }
           else
           {
               // cmd.Parameters.AddWithValue("@FromDate",Convert.ToDateTime(FromDate));
               cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
           }
           if (ToDate == "")
           {
               cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

           }
           else
           {
               // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
               cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
           }


           cmd.Parameters.AddWithValue("@FId", FId);
           cmd.Parameters.AddWithValue("@BranchId", BranchId);
           
           cmd.Parameters.AddWithValue("@DeptId", DeptId);
           SqlDataAdapter sda = new SqlDataAdapter(cmd);
           DataSet ds = new DataSet();
           sda.Fill(ds);
           ds.Tables[0].TableName = "Vw_TaxByArea";
           // ds.Tables[1].TableName = "Vw_POList";
           return ds;

       }
       catch (Exception ex)
       {
           throw ex;
       }
       finally
       {
           con.Dispose();
           con.Close();
       }
   }
   
   
   public DataSet GetInvoice(BEL Invoice)
   {
       SqlConnection con = new SqlConnection(constr);
       con.Open();
       SqlCommand cmd = new SqlCommand("SPR_Vw_InvoiceOnSave", con);
       cmd.CommandType = CommandType.StoredProcedure;

       cmd.Parameters.AddWithValue("@InvoiceNo", Invoice.InvoiceNo);
       cmd.Parameters.AddWithValue("@SupplierId", Invoice.SuppId);
       cmd.Parameters.AddWithValue("@InvoiceDetailId", Invoice.InvoiceDetailId);
       cmd.Parameters.AddWithValue("@FId", Invoice.Fid);
       cmd.Parameters.AddWithValue("@BranchId", Invoice.BranchId);
       cmd.Parameters.AddWithValue("@WareHouseId", Invoice.WareHouseId);
       SqlDataAdapter sda = new SqlDataAdapter(cmd);
       DataSet ds = new DataSet();

       sda.Fill(ds);
       ds.Tables[0].TableName = "Vw_InvoiceOnSave";
      // ds.Tables[1].TableName = "Vw_InvoiceAmountDetails";
       con.Close();
       return ds;

   }
   public DataSet GetConsumption(string FromDate, string ToDate)
   {
       SqlConnection con = new SqlConnection(constr);
       con.Open();
       SqlCommand cmd = new SqlCommand("Sp_Vw_ItemConsumption", con);
       cmd.CommandType = CommandType.StoredProcedure;

       cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
       
       cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
       SqlDataAdapter sda = new SqlDataAdapter(cmd);
       DataSet ds = new DataSet();

       sda.Fill(ds);
       ds.Tables[0].TableName = "Vw_ConsumptionReport";

       con.Close();
       return ds;

   }
   public DataSet GetManualConsumption(string FromDate, string ToDate,int DeptId)
   {
       SqlConnection con = new SqlConnection(constr);
       con.Open();
       SqlCommand cmd = new SqlCommand("Sp_ManualConsumptionFillGrid", con);
       cmd.CommandType = CommandType.StoredProcedure;

       cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
       cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
       cmd.Parameters.AddWithValue("@DeptId", DeptId);
       SqlDataAdapter sda = new SqlDataAdapter(cmd);
       DataSet ds = new DataSet();

       sda.Fill(ds);
       ds.Tables[0].TableName = "Vw_ManualConsumption";

       con.Close();
       return ds;

   }

   public DataSet GetInvoiceBill(int InvoiceNo, int SupplierId, int WareHouseId)
   {
       SqlConnection con = new SqlConnection(constr);
       con.Open();
       SqlCommand cmd = new SqlCommand("Sp_Vw_InvoiceBillReport", con);
       cmd.CommandType = CommandType.StoredProcedure;

       cmd.Parameters.AddWithValue("@InvoiceNo",InvoiceNo);       
       cmd.Parameters.AddWithValue("@SupplierId",SupplierId);
       cmd.Parameters.AddWithValue("@WareHouseId", WareHouseId);
       SqlDataAdapter sda = new SqlDataAdapter(cmd);
       DataSet ds = new DataSet();

       sda.Fill(ds);
       ds.Tables[0].TableName = "Vw_InvoiceBillReport";
       ds.Tables[1].TableName = "Vw_InvoiceBillReportWithAmount";
       con.Close();
       return ds;
   }


   public DataSet GetInvoiceBillStatus(string FromDate, string ToDate, int SuppId, int InvoiceNo, string PaymentStatus)
   {
       SqlConnection con = new SqlConnection(constr);
       con.Open();
       SqlCommand cmd = new SqlCommand("Sp_FillSuppwiseInvoiceAmountDetails", con);
       cmd.CommandType = CommandType.StoredProcedure;
       try
       {
           if (FromDate == "")
           {
               cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
           }
           else
           {
               // cmd.Parameters.AddWithValue("@FromDate",Convert.ToDateTime(FromDate));
               cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
           }
           if (ToDate == "")
           {
               cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

           }
           else
           {
               // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
               cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
           }

           cmd.Parameters.AddWithValue("@SupplierId", SuppId);
           cmd.Parameters.AddWithValue("@InvoiceNo", InvoiceNo);
           cmd.Parameters.AddWithValue("@PaymentStatus", PaymentStatus);
           SqlDataAdapter sda = new SqlDataAdapter(cmd);
           DataSet ds = new DataSet();
           sda.Fill(ds);
           ds.Tables[0].TableName = "Vw_InvoiceAmountDetails";
           
           con.Close();
           return ds;

       }
       catch (Exception ex)
       {
           throw ex;
       }
       finally
       {
           con.Dispose();
           con.Close();
       }
      
   }

   public DataSet GetPurchaseList(string FromDate, string ToDate, int SuppId, int PoNo,int WareHouseId)
   {
       SqlConnection con = new SqlConnection(constr);
       con.Open();
       SqlCommand cmd = new SqlCommand("Sp_Vw_PurchaseOrderListRpt", con);
       cmd.CommandType = CommandType.StoredProcedure;
       try
       {
           if (FromDate == "")
           {
               cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
           }
           else
           {
               // cmd.Parameters.AddWithValue("@FromDate",Convert.ToDateTime(FromDate));
               cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
           }
           if (ToDate == "")
           {
               cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

           }
           else
           {
               // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
               cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
           }

           cmd.Parameters.AddWithValue("@SupplierId", SuppId);
           cmd.Parameters.AddWithValue("@PoNo", PoNo);
           cmd.Parameters.AddWithValue("@WareHouseId", WareHouseId);
           SqlDataAdapter sda = new SqlDataAdapter(cmd);
           DataSet ds = new DataSet();
           sda.Fill(ds);
           ds.Tables[0].TableName = "Vw_PurchaseOrderOnSave";
           // ds.Tables[1].TableName = "Vw_POList";
           return ds;

       }
       catch (Exception ex)
       {
           throw ex;
       }
       finally
       {
           con.Dispose();
           con.Close();
       }
   }
    

   public DataSet GetPurchase(BEL Invoice)
   {
       SqlConnection con = new SqlConnection(constr);
       con.Open();
       SqlCommand cmd = new SqlCommand("SPR_Vw_PurchaseOrderOnSave", con);
       cmd.CommandType = CommandType.StoredProcedure;
       try
       {
           cmd.Parameters.AddWithValue("@PONo", Invoice.PONo);
           cmd.Parameters.AddWithValue("@SupplierId", Invoice.SuppId);
           cmd.Parameters.AddWithValue("@WareHouseId", Invoice.WareHouseId);

           SqlDataAdapter sda = new SqlDataAdapter(cmd);
           DataSet ds = new DataSet();

           sda.Fill(ds);
           ds.Tables[0].TableName = "Vw_PurchaseOrderOnSave";

           con.Close();
           return ds;
       }
       catch (Exception ex)
       {
           throw ex;
       }
       finally
       {
           con.Dispose();
           con.Close();
       }

   }
   public DataSet GetDirectIssueVoucher(BEL Issue)
   {
       SqlConnection con = new SqlConnection(constr);
       con.Open();
       SqlCommand cmd = new SqlCommand("Sp_Vw_DirectIssueVoucherOnSave", con);
       cmd.CommandType = CommandType.StoredProcedure;
       try
       {

           cmd.Parameters.AddWithValue("@IssueVoucherNo", Issue.VoucherNo);
           cmd.Parameters.AddWithValue("@DeptId", Issue.DeptId);
           cmd.Parameters.AddWithValue("@PatIssueVoucherId", Issue.PatIssueVoucherId);

           cmd.Parameters.AddWithValue("@FId", Issue.Fid);
           cmd.Parameters.AddWithValue("@BranchId", Issue.BranchId);

           SqlDataAdapter sda = new SqlDataAdapter(cmd);
           DataSet ds = new DataSet();

           sda.Fill(ds);
           ds.Tables[0].TableName = "Vw_DirectIssueVoucherOnSave";

           con.Close();
           //con.Dispose();
           return ds;
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

   public DataSet GetPatientIssueVoucherDetails(string FromDate, string ToDate, int Deptid, int VoucherNo, int FId, int BranchId, string PatRegNo, string PatientType)
   {
       SqlConnection con = new SqlConnection(constr);
       con.Open();
       SqlCommand cmd = new SqlCommand("Sp_PatientIssueVoucherDetails_Rpt", con);
       cmd.CommandType = CommandType.StoredProcedure;
       try
       {

           if (FromDate == "")
           {
               cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
           }
           else
           {
               // cmd.Parameters.AddWithValue("@FromDate",Convert.ToDateTime(FromDate));
               cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
           }
           if (ToDate == "")
           {
               cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

           }
           else
           {
               // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
               cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
           }
           cmd.Parameters.AddWithValue("@PatRegNo", PatRegNo);
           cmd.Parameters.AddWithValue("@DeptId", Deptid);
           cmd.Parameters.AddWithValue("@IssueVoucherNo", VoucherNo);
           cmd.Parameters.AddWithValue("@BranchId", BranchId);
           cmd.Parameters.AddWithValue("@FId", FId);
           cmd.Parameters.AddWithValue("@PatientType", PatientType);

           SqlDataAdapter sda = new SqlDataAdapter(cmd);
           DataSet ds = new DataSet();

           sda.Fill(ds);
           ds.Tables[0].TableName = "PatientIssueVoucherDetails";

           con.Close();
           //con.Dispose();
           return ds;
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


   public DataSet GetExpiredItemListForStore(string month, string year,string CurrentDate,int Flag, int FId, int BranchId, int Deptid)
   {
       SqlConnection con = new SqlConnection(constr);
       con.Open();
       SqlCommand cmd = new SqlCommand("Sp_Store_MonthWiseExpiredItems", con);
       cmd.CommandType = CommandType.StoredProcedure;

       try
       {
           cmd.Parameters.AddWithValue("@month", month);
           cmd.Parameters.AddWithValue("@year", year);
           cmd.Parameters.AddWithValue("@FId", FId);
           cmd.Parameters.AddWithValue("@BranchId", BranchId);
           cmd.Parameters.AddWithValue("@CurrentDate",CurrentDate);// DateTime.ParseExact(CurrentDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
           cmd.Parameters.AddWithValue("@Flag", Flag);      
           cmd.Parameters.AddWithValue("@Deptid", Deptid);
           SqlDataAdapter sda = new SqlDataAdapter(cmd);
           DataSet ds = new DataSet();
           sda.Fill(ds);
           ds.Tables[0].TableName = "Vw_MonthwiseExpiredItemsForStores";
           return ds;

       }

       catch (Exception ex)
       {
           throw ex;
       }
       finally
       {
           con.Dispose();
           con.Close();
       }
   }

   public DataSet GetExpiredItemList(string month, string year, string CurrentDate, int Flag, int FId, int BranchId, int WareHouseId)
   {
       SqlConnection con = new SqlConnection(constr);
       con.Open();
       SqlCommand cmd = new SqlCommand("Sp_MonthWiseExpiredItems", con);
       cmd.CommandType = CommandType.StoredProcedure;

       try
       {
           cmd.Parameters.AddWithValue("@month", month);
           cmd.Parameters.AddWithValue("@year", year);
           cmd.Parameters.AddWithValue("@CurrentDate",CurrentDate);// DateTime.ParseExact(CurrentDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
           cmd.Parameters.AddWithValue("@Flag", Flag);         
           cmd.Parameters.AddWithValue("@FId", FId);
           cmd.Parameters.AddWithValue("@BranchId", BranchId);
           cmd.Parameters.AddWithValue("@WareHouseId", WareHouseId);
           SqlDataAdapter sda = new SqlDataAdapter(cmd);
           DataSet ds = new DataSet();
           sda.Fill(ds);
           ds.Tables[0].TableName = "Vw_MonthwiseExpiredItems";
           return ds;
           
       }

       catch (Exception ex)
       {
           throw ex;
       }
       finally
       {
           con.Dispose();
           con.Close();
       }
   }
   public DataSet GetThreeSixNineMonthExpiryItems(string CurrentDate, string MonthCnt, int FId, int BranchId,int WareHouseId)
   {
       SqlConnection con = new SqlConnection(constr);
       con.Open();
       SqlCommand cmd = new SqlCommand("Sp_ThreeSixNineMonthExpiryItems", con);
       cmd.CommandType = CommandType.StoredProcedure;

       try
       {
           cmd.Parameters.AddWithValue("@CurrentDate",CurrentDate);// DateTime.ParseExact(CurrentDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture)); 
           
           cmd.Parameters.AddWithValue("@MonthCnt", MonthCnt);
           cmd.Parameters.AddWithValue("@FId", FId);
           cmd.Parameters.AddWithValue("@BranchId", BranchId);
           cmd.Parameters.AddWithValue("@WareHouseId", WareHouseId);
           SqlDataAdapter sda = new SqlDataAdapter(cmd);
           DataSet ds = new DataSet();
           sda.Fill(ds);
           ds.Tables[0].TableName = "Vw_MonthwiseExpiredItems";
           return ds;

       }

       catch (Exception ex)
       {
           throw ex;
       }
       finally
       {
           con.Dispose();
           con.Close();
       }
   }

   public DataSet GetThreeSixNineMonthExpiryItemsForStore(string CurrentDate, string MonthCnt, int FId, int BranchId,int DeptId)
   {
       SqlConnection con = new SqlConnection(constr);
       con.Open();
       SqlCommand cmd = new SqlCommand("Sp_ThreeSixNineMonthExpiryItemsForStores", con);
       cmd.CommandType = CommandType.StoredProcedure;

       try
       {
           cmd.Parameters.AddWithValue("@CurrentDate",CurrentDate);// DateTime.ParseExact(CurrentDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));

           cmd.Parameters.AddWithValue("@MonthCnt", MonthCnt);
           cmd.Parameters.AddWithValue("@FId", FId);
           cmd.Parameters.AddWithValue("@BranchId", BranchId);
           cmd.Parameters.AddWithValue("@DeptId", DeptId);
           SqlDataAdapter sda = new SqlDataAdapter(cmd);
           DataSet ds = new DataSet();
           sda.Fill(ds);
           ds.Tables[0].TableName = "Vw_MonthwiseExpiredItemsForStores";
           return ds;

       }

       catch (Exception ex)
       {
           throw ex;
       }
       finally
       {
           con.Dispose();
           con.Close();
       }
   }
   public DataSet GetStoreIssueItemList(string FromDate, string ToDate, int DeptId, int VoucherNo, int FId, int BranchId, int ItemId, int MainCategory,int WareHouseId)
   {
       SqlConnection con = new SqlConnection(constr);
       con.Open();
       SqlCommand cmd = new SqlCommand("Sp_Vw_DeptStoreWiseIssueItems_Store", con);
       //SqlCommand cmd = new SqlCommand("Sp_SearchDeptIndList_ReportView", con);
       cmd.CommandType = CommandType.StoredProcedure;

       try
       {
           if (FromDate == "")
           {
               cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
           }
           else
           {

               cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
           }
           if (ToDate == "")
           {
               cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

           }
           else
           {

               cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
           }
           cmd.Parameters.AddWithValue("@VoucherNo", VoucherNo);
           cmd.Parameters.AddWithValue("@DeptId", DeptId);
           // cmd.Parameters.AddWithValue("@Flag", "DeptIndentList");
           cmd.Parameters.AddWithValue("@FId", FId);
           cmd.Parameters.AddWithValue("@BranchId", BranchId);
           cmd.Parameters.AddWithValue("@ItemId", ItemId);
           cmd.Parameters.AddWithValue("@MainCategory", MainCategory);
           cmd.Parameters.AddWithValue("@WareHouseId", WareHouseId);
           SqlDataAdapter sda = new SqlDataAdapter(cmd);
           DataSet ds = new DataSet();
           sda.Fill(ds);
           ds.Tables[0].TableName = "Vw_DeptStoreWiseIssueItems";
           return ds;

       }

       catch (Exception ex)
       {
           throw ex;
       }
       finally
       {
           con.Dispose();
           con.Close();
       }

   }
   public DataSet GetItemWiseDeptCurrentStock(BEL ItemStock)
   {
       SqlConnection con = new SqlConnection(constr);
       con.Open();
       SqlCommand cmd = new SqlCommand("Sp_Vw_ItemWiseDeptCurrentStock", con);
       cmd.CommandType = CommandType.StoredProcedure;
       cmd.Parameters.AddWithValue("@ItemId", ItemStock.ItemId);
       cmd.Parameters.AddWithValue("@DeptId", ItemStock.DeptId);
       cmd.Parameters.AddWithValue("@CategoryId", ItemStock.CategoryId);
       cmd.Parameters.AddWithValue("@MainCategory", ItemStock.MainCategory);
       cmd.Parameters.AddWithValue("@FId", ItemStock.Fid);
       cmd.Parameters.AddWithValue("@BranchId", ItemStock.BranchId);

       SqlDataAdapter sda = new SqlDataAdapter(cmd);
       DataSet ds = new DataSet();

       sda.Fill(ds);
       //ds.Tables[0].TableName = "Vw_ItemWiseDeptCurrentStock";
       ds.Tables[0].TableName = "ItemWiseDeptStock";
       con.Close();
       return ds;

   }

   public DataSet GetUserWiseIncomeReport(string FromDate, string ToDate,int DeptId,string UserName,string PaymentType, int FId, int BranchId,string PatientType)
   {
       SqlConnection con = new SqlConnection(constr);
       con.Open();
       SqlCommand cmd = new SqlCommand("Sp_Vw_DailyCashSumary", con);
       //SqlCommand cmd = new SqlCommand("Sp_SearchDeptIndList_ReportView", con);
       cmd.CommandType = CommandType.StoredProcedure;

       try
       {
           if (FromDate == "")
           {
               cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
           }
           else
           {
               cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));

              // cmd.Parameters.AddWithValue("@FromDate",FromDate);
           }
           if (ToDate == "")
           {
               cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

           }
           else
           {
               cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));

               //cmd.Parameters.AddWithValue("@ToDate", ToDate);
           }
           cmd.Parameters.AddWithValue("@DeptId", DeptId);
           cmd.Parameters.AddWithValue("@UserName", UserName);
           cmd.Parameters.AddWithValue("@PaymentType", PaymentType);
           cmd.Parameters.AddWithValue("@FId", FId);
           cmd.Parameters.AddWithValue("@BranchId", BranchId);
           cmd.Parameters.AddWithValue("@PatientType", PatientType);
           SqlDataAdapter sda = new SqlDataAdapter(cmd);
           DataSet ds = new DataSet();
           sda.Fill(ds);
           ds.Tables[0].TableName = "Vw_DailyCashReport";
           return ds;

       }

       catch (Exception ex)
       {
           throw ex;
       }
       finally
       {
           con.Dispose();
           con.Close();
       }

   }

   public DataSet GetDoctorWisePatientsReport(string FromDate, string ToDate, int DrId,int DeptId,int FId, int BranchId)
   {
       SqlConnection con = new SqlConnection(constr);
       con.Open();
       SqlCommand cmd = new SqlCommand("Sp_Vw_DoctorWisePatientList", con);
       
       cmd.CommandType = CommandType.StoredProcedure;

       try
       {
           if (FromDate == "")
           {
               cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
           }
           else
           {
               cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));

              
           }
           if (ToDate == "")
           {
               cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

           }
           else
           {
               cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));

              
           }
           cmd.Parameters.AddWithValue("@DrId", DrId);
           cmd.Parameters.AddWithValue("@DeptId", DeptId);           
           cmd.Parameters.AddWithValue("@FId", FId);
           cmd.Parameters.AddWithValue("@BranchId", BranchId);

           SqlDataAdapter sda = new SqlDataAdapter(cmd);
           DataSet ds = new DataSet();
           sda.Fill(ds);
           ds.Tables[0].TableName = "Vw_DoctorWisePatientList";
           return ds;

       }

       catch (Exception ex)
       {
           throw ex;
       }
       finally
       {
           con.Dispose();
           con.Close();
       }

   }
   public DataSet WarehouseStockAdjustReport(int StockAdjustMainId, int FId, int BranchId,int WareHouseId)
   {
       SqlConnection con = new SqlConnection(constr);
       con.Open();
       SqlCommand cmd = new SqlCommand("Sp_WareHouseStockAdjustReport", con);
       cmd.CommandType = CommandType.StoredProcedure;

       try
       {
           //if (FromDate == "")
           //{
           //    cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
           //}
           //else
           //{
           //    //DateTime date = DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
           //    cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
           //}
           //if (ToDate == "")
           //{
           //    cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

           //}
           //else
           //{

           //    cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
           //}
           cmd.Parameters.AddWithValue("@StockAdjustMainId", StockAdjustMainId);
           cmd.Parameters.AddWithValue("@WareHouseId", WareHouseId);
           //cmd.Parameters.AddWithValue("@FId", FId);
           //cmd.Parameters.AddWithValue("@BranchId", BranchId);
           SqlDataAdapter sda = new SqlDataAdapter(cmd);
           DataSet ds = new DataSet();
           sda.Fill(ds);
           ds.Tables[0].TableName = "Vw_WarehouseStockAdjustRpt";
           return ds;

       }

       catch (Exception ex)
       {
           throw ex;
       }
       finally
       {
           con.Dispose();
           con.Close();
       }

   }
   public DataSet DeptStockAdjustReport(int DeptStockAdjustMainId, int FId, int BranchId)
   {
       SqlConnection con = new SqlConnection(constr);
       con.Open();
       SqlCommand cmd = new SqlCommand("Sp_DeptStockAdjustReport", con);
       cmd.CommandType = CommandType.StoredProcedure;

       try
       {
           //if (FromDate == "")
           //{
           //    cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
           //}
           //else
           //{
           //    //DateTime date = DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
           //    cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
           //}
           //if (ToDate == "")
           //{
           //    cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

           //}
           //else
           //{

           //    cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
           //}
           cmd.Parameters.AddWithValue("@DeptStockAdjustMainId", DeptStockAdjustMainId);
           //cmd.Parameters.AddWithValue("@FId", FId);
           //cmd.Parameters.AddWithValue("@BranchId", BranchId);
           SqlDataAdapter sda = new SqlDataAdapter(cmd);
           DataSet ds = new DataSet();
           sda.Fill(ds);
           ds.Tables[0].TableName = "Vw_DeptStockAdjReport";
           return ds;

       }

       catch (Exception ex)
       {
           throw ex;
       }
       finally
       {
           con.Dispose();
           con.Close();
       }

   }
   public DataSet WarehouseStockAdjustReportMain(string FromDate,string ToDate, int FId, int BranchId)
   {
       SqlConnection con = new SqlConnection(constr);
       con.Open();
       SqlCommand cmd = new SqlCommand("Sp_WareHouseStockAdjustReportMain", con);
       cmd.CommandType = CommandType.StoredProcedure;

       try
       {
           if (FromDate == "")
           {
               cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
           }
           else
           {
               //DateTime date = DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
               cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
           }
           if (ToDate == "")
           {
               cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

           }
           else
           {

               cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
           }
          
           SqlDataAdapter sda = new SqlDataAdapter(cmd);
           DataSet ds = new DataSet();
           sda.Fill(ds);
           ds.Tables[0].TableName = "Vw_WarehouseStockAdjustRpt";
           return ds;

       }

       catch (Exception ex)
       {
           throw ex;
       }
       finally
       {
           con.Dispose();
           con.Close();
       }

   }
   public DataSet DeptStoreWiseStockAdjustReport(string FromDate, string ToDate, int DeptId, int FId, int BranchId)
   {
       SqlConnection con = new SqlConnection(constr);
       con.Open();
       SqlCommand cmd = new SqlCommand("Sp_StoreWiseStockAdjustReport", con);
       cmd.CommandType = CommandType.StoredProcedure;

       try
       {
           if (FromDate == "")
           {
               cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
           }
           else
           {
               //DateTime date = DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
               cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
           }
           if (ToDate == "")
           {
               cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

           }
           else
           {

               cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
           }
           cmd.Parameters.AddWithValue("@DeptId", DeptId);
           cmd.Parameters.AddWithValue("@FId", FId);
           cmd.Parameters.AddWithValue("@BranchId", BranchId);
           SqlDataAdapter sda = new SqlDataAdapter(cmd);
           DataSet ds = new DataSet();
           sda.Fill(ds);
           ds.Tables[0].TableName = "Vw_StoreWiseStockAdjustmentReport";
         
           return ds;

       }

       catch (Exception ex)
       {
           throw ex;
       }
       finally
       {
           con.Dispose();
           con.Close();
       }

   }
   public DataSet GetCancelVoucherDetailsReport(string FromDate, string ToDate, int DeptId, int FId, int BranchId,int WareHouseId)
   {
       SqlConnection con = new SqlConnection(constr);
       con.Open();
       SqlCommand cmd = new SqlCommand("Sp_Vw_CancelVoucherDetails", con);
       //SqlCommand cmd = new SqlCommand("Sp_SearchDeptIndList_ReportView", con);
       cmd.CommandType = CommandType.StoredProcedure;

       try
       {
           if (FromDate == "")
           {
               cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
           }
           else
           {

               cmd.Parameters.AddWithValue("@FromDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
           }
           if (ToDate == "")
           {
               cmd.Parameters.AddWithValue("@ToDate", DBNull.Value);

           }
           else
           {

               cmd.Parameters.AddWithValue("@ToDate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
           }
           cmd.Parameters.AddWithValue("@DeptId", DeptId);
          // cmd.Parameters.AddWithValue("@UserName", UserName);
          // cmd.Parameters.AddWithValue("@PaymentType", PaymentType);
           cmd.Parameters.AddWithValue("@FId", FId);
           cmd.Parameters.AddWithValue("@BranchId", BranchId);
           cmd.Parameters.AddWithValue("@WareHouseId", WareHouseId);

           SqlDataAdapter sda = new SqlDataAdapter(cmd);
           DataSet ds = new DataSet();
           sda.Fill(ds);
           ds.Tables[0].TableName = "Vw_CancelVoucherDetails";
           return ds;

       }

       catch (Exception ex)
       {
           throw ex;
       }
       finally
       {
           con.Dispose();
           con.Close();
       }

   }

   public DataSet GetReorderCurrentStock(BEL ItemStock)
   {
       SqlConnection con = new SqlConnection(constr);
       con.Open();
       SqlCommand cmd = new SqlCommand("Sp_Vw_ReorderLevel", con);
       cmd.CommandType = CommandType.StoredProcedure;
       cmd.Parameters.AddWithValue("@ItemId", ItemStock.ItemId);
       // cmd.Parameters.AddWithValue("@BatchNo", ItemStock.BatchNo);
       cmd.Parameters.AddWithValue("@CategoryId", ItemStock.CategoryId);
       cmd.Parameters.AddWithValue("@MainCategory", ItemStock.MainCategory);
       cmd.Parameters.AddWithValue("@FId", ItemStock.Fid);
       cmd.Parameters.AddWithValue("@BranchId", ItemStock.BranchId);

       SqlDataAdapter sda = new SqlDataAdapter(cmd);
       DataSet ds = new DataSet();

       sda.Fill(ds);
       ds.Tables[0].TableName = "Vw_ReorderLevel";

       con.Close();
       return ds;

   }

   public DataTable GetItemWiseLedger(string FromDate, string ToDate, int ItemId,int WareHouseId)
   {
       SqlConnection con = new SqlConnection(constr);
       con.Open();
       SqlCommand cmd = new SqlCommand("sp_stockLedgereport", con);
       cmd.CommandType = CommandType.StoredProcedure;
       try
       {
           if (FromDate == "")
           {
               cmd.Parameters.AddWithValue("@startDate", DBNull.Value);
           }
           else
           {
               // cmd.Parameters.AddWithValue("@FromDate",Convert.ToDateTime(FromDate));
               cmd.Parameters.AddWithValue("@startDate", DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
           }
           if (ToDate == "")
           {
               cmd.Parameters.AddWithValue("@enddate", DBNull.Value);

           }
           else
           {
               // cmd.Parameters.AddWithValue("@ToDate",Convert.ToDateTime(ToDate));
               cmd.Parameters.AddWithValue("@enddate", DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
           }



           cmd.Parameters.AddWithValue("@itemid", ItemId);
           cmd.Parameters.AddWithValue("@WareHouseId", WareHouseId);
           cmd.CommandTimeout = 5000;
           SqlDataAdapter sda = new SqlDataAdapter(cmd);
           cmd.CommandTimeout = 5000;
           DataTable ds = new DataTable();
           sda.Fill(ds);
           //ds.Tables[0].TableName = "Vw_ItemWiseMonthlyConsumption";
           // ds.Tables[1].TableName = "Vw_POList";
           return ds;

       }
       catch (Exception ex)
       {
           throw ex;
       }
       finally
       {
           con.Dispose();
           con.Close();
       }
   }

   public DataSet DeptwiseReorderReport(int DeptId, int FId, int BranchId)
   {
       SqlConnection con = new SqlConnection(constr);
       con.Open();
       SqlCommand cmd = new SqlCommand("Sp_Vw_DeptGetDeptWiseReordeList", con);
       cmd.CommandType = CommandType.StoredProcedure;

       try
       {

           cmd.Parameters.AddWithValue("@DeptId", DeptId);
           //cmd.Parameters.AddWithValue("@FId", FId);
           //cmd.Parameters.AddWithValue("@BranchId", BranchId);
           SqlDataAdapter sda = new SqlDataAdapter(cmd);
           DataSet ds = new DataSet();
           sda.Fill(ds);
           ds.Tables[0].TableName = "Vw_DeptGetDeptWiseReordeList";
           return ds;

       }

       catch (Exception ex)
       {
           throw ex;
       }
       finally
       {
           con.Dispose();
           con.Close();
       }

   }
}