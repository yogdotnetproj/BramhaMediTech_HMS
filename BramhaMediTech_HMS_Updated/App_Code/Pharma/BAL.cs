using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

/// <summary>
/// Summary description for BAL
/// </summary>
public class BAL
{

    //_________________________________________________________________________________________________________________________________________
   
                       //     Department Code
    //___________________________________________________________________________________________________________________________________________
    
    DAL DeptDetails = new DAL();
    public string InsertDept(BEL DeptInfo)
    {
        string Message;
        try
        {
           Message= DeptDetails.InsertDepartment(DeptInfo);
           return Message;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            DeptDetails = null;
        }

    }
    public string UpdateDept(BEL DeptInfo)
    {
        string Message = "";
        try
        {
            Message=DeptDetails.UpdateDepartment(DeptInfo);
            return Message;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            DeptDetails = null;
        }
    }
    public void DeleteDept(BEL DeptInfo)
    {
        try
        {
            DeptDetails.DeleteDepartment(DeptInfo);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            DeptDetails = null;
        }
    }
    public DataSet FillDdlDept()
    {
         DAL DeptDetails = new DAL();
         try
         {
            return DeptDetails.fillDept();
         }
         catch (Exception ex)
         {
             throw ex;
         }
         finally
         {
             DeptDetails = null;
         }
    }
    public DataSet FillDdlUnit()
    {
        DAL UnitDetails = new DAL();
        try
        {
            return UnitDetails.fillUnit();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            DeptDetails = null;
        }
    }

    public int CheckDeptExists(BEL DeptInfo)
    {
        DAL DeptDetails = new DAL();
        try
        {
            return DeptDetails.CheckExistDept(DeptInfo);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            DeptDetails = null;
        }
    }

  //  _____________________________Supplier Code_________________________________


    DAL SuppDetails = new DAL();
    public void InsertSupp(BEL SuppInfo)
    {
        try
        {
            SuppDetails.InsertSupplier(SuppInfo);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            SuppDetails = null;
        }

    }
    public void UpdateSupp(BEL SuppInfo)
    {
        try
        {
            SuppDetails.UpdateSupplier(SuppInfo);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            SuppDetails = null;
        }
    }
    public void DeleteSupp(BEL SuppInfo)
    {
        try
        {
            SuppDetails.DeleteSupplier(SuppInfo);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            SuppDetails = null;
        }
    }
    public DataSet FillSupp()
    {
        DAL SuppDetails = new DAL();
        try
        {
            return SuppDetails.fillSupp();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            SuppDetails = null;
        }
    }

    public int CheckSuppExists(BEL SuppInfo)
    {
        DAL SuppDetails = new DAL();
        try
        {
            return SuppDetails.CheckExistSupp(SuppInfo);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            SuppDetails = null;
        }
    }

    //_____________________________________________Manufacture company _______________________________________________

    DAL MfgDetails = new DAL();
    public void InsertMfg(BEL MfgInfo)
    {
        try
        {
            MfgDetails.InsertMfg(MfgInfo);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            MfgDetails = null;
        }

    }
    public void UpdateMfg(BEL MfgInfo)
    {
        try
        {
            MfgDetails.UpdateMfg(MfgInfo);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            MfgDetails = null;
        }
    }
    public void DeleteMfg(BEL MfgInfo)
    {
        try
        {
            MfgDetails.DeleteMfg(MfgInfo);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            MfgDetails = null;
        }
    }
    public DataSet FillMfg()
    {
        DAL MfgDetails = new DAL();
        try
        {
            return MfgDetails.fillMfg();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            MfgDetails = null;
        }
    }

    public int CheckMfgExists(BEL MfgInfo)
    {
        DAL MfgDetails = new DAL();
        try
        {
            return MfgDetails.CheckMfgExists(MfgInfo);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            MfgDetails = null;
        }
    }

    //_______________________________________________Item code__________________________________________________


    DAL ItemDetails = new DAL();
    public string InsertItem(BEL ItemInfo)
    {
        string Message = "";
        try
        {
            Message=ItemDetails.InsertItem(ItemInfo);
            return Message;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            ItemDetails = null;
        }

    }
    public string UpdateItem(BEL ItemInfo)
    {
        string Message = "";
        try
        {             
            Message=ItemDetails.UpdateItem(ItemInfo);
            return Message;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            ItemDetails = null;
        }
    }
    public string DeleteItem(BEL ItemInfo)
    {
        try
        {
            string Message = "";
            Message=ItemDetails.DeleteItem(ItemInfo);
            return Message;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            ItemDetails = null;
        }
    }
    public DataSet FillItem()
    {
        DAL ItemDetails = new DAL();
        try
        {
            return ItemDetails.fillItem();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            ItemDetails = null;
        }
    }
    public DataSet FillItem_WareHouse(int WareHouseId)
    {
        DAL ItemDetails = new DAL();
        try
        {
            return ItemDetails.fillItem_WareHouse( WareHouseId);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            ItemDetails = null;
        }
    }

    public int CheckItemExists(BEL ItemInfo)
    {
        DAL ItemDetails = new DAL();
        try
        {
            return ItemDetails.CheckItemExists(ItemInfo);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            ItemDetails = null;
        }
    }

    public void InserPODetails(BEL POinfo)
    {
        DAL PoDetails = new DAL();
        try
        {
            PoDetails.InsertPoInfo(POinfo);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            PoDetails = null;
        }

    }
    public int GetItemId(BEL POinfo)
    {
        DAL PoDetails = new DAL();
        try
        {
           return PoDetails.GetItemId(POinfo);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            PoDetails = null;
        }

    }
    public int GetSupplierId(BEL POinfo)
    {
        DAL PoDetails = new DAL();
        try
        {
            return PoDetails.GetSupplierId(POinfo);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            PoDetails = null;
        }

    }
    public int GetMfgCompId(BEL POinfo)
    {
        DAL PoDetails = new DAL();
        try
        {
            return PoDetails.GetMfgCompId(POinfo);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            PoDetails = null;
        }

    }

    public int GetCategoryId(BEL POinfo)
    {
        DAL PoDetails = new DAL();
        try
        {
            return PoDetails.GetCatId(POinfo);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            PoDetails = null;
        }

    }

    public DataTable FillPurTrack(BEL PurtrackDetails)
    {
        DAL PurTrack = new DAL();
        try
        {
            return PurTrack.FillPurchaseTrack(PurtrackDetails);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            PurTrack = null;
        }
    }

    public void DeletePurchase(BEL purchDetails)
    {
            DAL PurTrack = new DAL();
            try
            {
                PurTrack.DeletePurchase(purchDetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                PurTrack = null;
            }
    }

    public DataSet FillDept()
    {
        DAL DeptDetails = new DAL();
        try
        {
            return DeptDetails.BindDdlDept();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            DeptDetails = null;
        }
    }
    public void InsertReq(BEL Iteminfo)
    {
        DAL IndReq = new DAL();
        try
        {
            IndReq.InsertIndentRequest(Iteminfo);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            IndReq = null;
        }
        
    }
    public int InsertIndDeptReq(BEL Iteminfo)
    {
        DAL IndReq = new DAL();
        try
        {
            int IntreqDetailId = IndReq.InsertIndentDept(Iteminfo);
            return IntreqDetailId;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            IndReq = null;
        }
    }
    public void InsertvoucherNo(BEL VouchDetails)
    {
        DAL Voucher=new DAL();
        try
        {
            Voucher.InsertVouchNo(VouchDetails);
        }
        catch(Exception ex)
        {
            throw ex;
        }
        finally
        {
            Voucher=null;
        }
    }

    public int GetAutoNo( BELPatientIssueVoucher obj)
    {
        DAL GetNo = new DAL();
        try
        {
            return GetNo.GetAutoVouchNo(obj);
                 
        }
        catch(Exception ex)
        {
            throw ex;
        }
        finally
        {
            GetNo = null;
        }
    }
    public BEL CurrentStk(BEL ItemInfo)
    {
        DAL stock=new DAL();
        try
        {
            return stock.GetCurrentStk(ItemInfo);
        }
        catch(Exception ex)
        {
            throw ex;
        }
        finally
        {
            stock = null;
        }
    }

    public int IntendNotificationNo(BEL IndNo)
    {
        DAL IntendNO = new DAL();
        try
        {
            return IntendNO.GetIndentNo(IndNo);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            IntendNO = null;
        }
    }
    //public DataSet DeptIndList(BEL Deptid)
    //{
    //    DAL DeptDetails = new DAL();
    //    try
    //    {
    //        return DeptDetails.GetDeptIndentList(Deptid);
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    finally
    //    {
    //        DeptDetails = null;
    //    }
    //}
    public DataSet IssueList(BEL Indent)
    {
        DAL IndentDetails = new DAL();
        try
        {
            return IndentDetails.GetIssueItemList(Indent);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            IndentDetails = null;
        }
    }
}