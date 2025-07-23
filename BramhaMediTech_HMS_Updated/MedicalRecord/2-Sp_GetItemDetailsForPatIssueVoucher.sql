USE [Woodland_Pharma]
GO

/****** Object:  StoredProcedure [dbo].[Sp_GetItemDetailsForPatIssueVoucher]    Script Date: 27-11-2022 9.05.00 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[Sp_GetItemDetailsForPatIssueVoucher]
	-- Add the parameters for the stored procedure here
	@ItemId int,
	@DeptId int,
	@BatchNo nvarchar(50),
	@FId int,
	@BranchId int,
	@PatientType nvarchar(50),
	@UserId int=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
Declare @ItemType nvarchar(100)
Declare @MarkUp float
declare @Usertype nvarchar(50)
Declare @TempCostPrice float




--set @ItemType = (select ItemType from tbl_Items where ItemId=@ItemId and FId=@FId and BranchId=@BranchId )

--if(@ItemType='Prescription')
--	begin
--		 if(@PatientType='IPD')
--			 begin
--				--set @MarkUp =(select PrescItemPerIPD from tbl_Dept where DeptId=@DeptId and FId=@FId and BranchId=@BranchId)
--				set @MarkUp = (select MarkUpIPD from tbl_Items where ItemId=@ItemId and FId=@FId and BranchId=@BranchId )	
--				SELECT distinct tbl_IndentReq.ItemId, tbl_Items.ItemName, (Max(tbl_IndentReq.CostPrice) +(Max(tbl_IndentReq.CostPrice)*@MarkUp/100))as PerPackCost, tbl_IndentReq.BatchNo, tbl_TaxType.TaxPercentage, tbl_TaxType.TaxType
--				FROM tbl_IndentReq INNER JOIN tbl_Items ON tbl_IndentReq.ItemId = tbl_Items.ItemId INNER JOIN
--				tbl_TaxType ON tbl_Items.TaxType = tbl_TaxType.TaxTypeId where tbl_IndentReq.ItemId=@ItemId and tbl_IndentReq.BatchNo=@BatchNo and tbl_IndentReq.FId=@FId and tbl_IndentReq.BranchId=@BranchId
--				group by tbl_IndentReq.ItemId, tbl_Items.ItemName, tbl_IndentReq.BatchNo, tbl_TaxType.TaxPercentage, tbl_TaxType.TaxType

--			 end
--		else
--			begin
			
--			set @Usertype =( Select Usertype from CTuser where CUId=@UserId and branchid=@BranchId)

--				if(@Usertype='Store Special')
--					begin
--						--set @MarkUp =(select PrescItemPer+5 from tbl_Dept where DeptId=@DeptId and FId=@FId and BranchId=@BranchId)	
--						set @MarkUp = (select MarkUpIPD+5 from tbl_Items where ItemId=@ItemId and FId=@FId and BranchId=@BranchId )
--						SELECT distinct tbl_IndentReq.ItemId, tbl_Items.ItemName, (Max(tbl_IndentReq.CostPrice) +(Max(tbl_IndentReq.CostPrice)*@MarkUp/100))as PerPackCost, tbl_IndentReq.BatchNo, tbl_TaxType.TaxPercentage, tbl_TaxType.TaxType
--						FROM tbl_IndentReq INNER JOIN tbl_Items ON tbl_IndentReq.ItemId = tbl_Items.ItemId INNER JOIN
--						tbl_TaxType ON tbl_Items.TaxType = tbl_TaxType.TaxTypeId where tbl_IndentReq.ItemId=@ItemId and tbl_IndentReq.BatchNo=@BatchNo and tbl_IndentReq.FId=@FId and tbl_IndentReq.BranchId=@BranchId
--						group by tbl_IndentReq.ItemId, tbl_Items.ItemName, tbl_IndentReq.BatchNo, tbl_TaxType.TaxPercentage, tbl_TaxType.TaxType
--					end
--				else
--					begin
--					--set @MarkUp =(select PrescItemPer from tbl_Dept where DeptId=@DeptId and FId=@FId and BranchId=@BranchId)
--					    set @MarkUp = (select MarkUpOPD from tbl_Items where ItemId=@ItemId and FId=@FId and BranchId=@BranchId )	
--						SELECT distinct tbl_IndentReq.ItemId, tbl_Items.ItemName, (Max(tbl_IndentReq.CostPrice) +(Max(tbl_IndentReq.CostPrice)*@MarkUp/100))as PerPackCost, tbl_IndentReq.BatchNo, tbl_TaxType.TaxPercentage, tbl_TaxType.TaxType
--						FROM tbl_IndentReq INNER JOIN tbl_Items ON tbl_IndentReq.ItemId = tbl_Items.ItemId INNER JOIN
--						tbl_TaxType ON tbl_Items.TaxType = tbl_TaxType.TaxTypeId where tbl_IndentReq.ItemId=@ItemId and tbl_IndentReq.BatchNo=@BatchNo and tbl_IndentReq.FId=@FId and tbl_IndentReq.BranchId=@BranchId
--						group by tbl_IndentReq.ItemId, tbl_Items.ItemName, tbl_IndentReq.BatchNo, tbl_TaxType.TaxPercentage, tbl_TaxType.TaxType
--					end
--			end	

--	end
--else
if(@DeptId=0)
begin
if(@PatientType='IPD')
			begin
				--set @MarkUp =(select CounterItemPerIPD from tbl_Dept where DeptId=@DeptId)
				 set @MarkUp = (select MarkUpIPD from tbl_Items where ItemId=@ItemId and FId=@FId and BranchId=@BranchId )

				  set @TempCostPrice= (SELECT TOP 1 isnull(PerPackCost ,0) as CostPrice
FROM 
    (SELECT TOP 5 PerPackCost 
     FROM tbl_Invoice  where ItemId=@ItemId and FId=@FId and BranchId=@BranchId 
     ORDER BY InvoiceId  DESC) AS Comp 
ORDER BY PerPackCost  desc)
if(@TempCostPrice is null)
begin
set @TempCostPrice=0
end

				SELECT distinct tbl_Invoice.ItemId, tbl_Items.ItemName, (Max(@TempCostPrice) +(Max(@TempCostPrice)*10/100))as PerPackCost, tbl_Invoice.BatchNo, tbl_TaxType.TaxPercentage, tbl_TaxType.TaxType
				FROM tbl_Invoice INNER JOIN  tbl_Items ON tbl_Invoice.ItemId = tbl_Items.ItemId INNER JOIN
				tbl_TaxType ON tbl_Items.TaxType = tbl_TaxType.TaxTypeId 
				where tbl_Invoice.ItemId=@ItemId and tbl_Invoice.BatchNo=@BatchNo and tbl_Invoice.FId=@FId and tbl_Invoice.BranchId=@BranchId
				group by tbl_Invoice.ItemId, tbl_Items.ItemName, tbl_Invoice.BatchNo, tbl_TaxType.TaxPercentage, tbl_TaxType.TaxType


			end
		else
			begin
				
						--set @MarkUp =(select CounterItemPer from tbl_Dept where DeptId=@DeptId)
						  set @MarkUp = (select MarkUpOPD from tbl_Items where ItemId=@ItemId and FId=@FId and BranchId=@BranchId )
						    set @TempCostPrice= (SELECT TOP 1 isnull(PerPackCost ,0) as CostPrice
FROM 
    (SELECT TOP 5 PerPackCost 
     FROM tbl_Invoice  where ItemId=@ItemId and FId=@FId and BranchId=@BranchId 
     ORDER BY InvoiceId  DESC) AS Comp 
ORDER BY PerPackCost  desc)
if(@TempCostPrice is null)
begin
set @TempCostPrice=0
end
						SELECT distinct tbl_Invoice.ItemId, tbl_Items.ItemName, ( Max(@TempCostPrice) +( Max(@TempCostPrice)*@MarkUp/100))as PerPackCost,  tbl_Invoice.BatchNo, tbl_TaxType.TaxPercentage, tbl_TaxType.TaxType
						FROM  tbl_Invoice INNER JOIN  tbl_Items ON  tbl_Invoice.ItemId = tbl_Items.ItemId INNER JOIN
						tbl_TaxType ON tbl_Items.TaxType = tbl_TaxType.TaxTypeId where  tbl_Invoice.ItemId=@ItemId and  tbl_Invoice.BatchNo=@BatchNo and  tbl_Invoice.FId=@FId and  tbl_Invoice.BranchId=@BranchId
						group by tbl_Invoice.ItemId, tbl_Items.ItemName, tbl_Invoice.BatchNo, tbl_TaxType.TaxPercentage, tbl_TaxType.TaxType
					end
			
end
else
	begin
		if(@PatientType='IPD')
			begin
				--set @MarkUp =(select CounterItemPerIPD from tbl_Dept where DeptId=@DeptId)
				 set @MarkUp = (select MarkUpIPD from tbl_Items where ItemId=@ItemId and FId=@FId and BranchId=@BranchId )
				--set @TempCostPrice= (select CostPrice from tbl_IndentReq where ItemId=@ItemId and FId=@FId and BranchId=@BranchId )

				
set @TempCostPrice= (SELECT TOP 1 isnull(CostPrice ,0) as CostPrice
FROM 
    (SELECT TOP 5 CostPrice 
     FROM tbl_IndentReq  where ItemId=@ItemId and deptid=@DeptId and FId=@FId and BranchId=@BranchId 
     ORDER BY IndReq  DESC) AS Comp 
ORDER BY CostPrice  desc)
if(@TempCostPrice is null)
begin
set @TempCostPrice=0
end

				SELECT distinct tbl_IndentReq.ItemId, tbl_Items.ItemName, (Max(@TempCostPrice) +(Max(@TempCostPrice)*@MarkUp/100))as PerPackCost, tbl_IndentReq.BatchNo, tbl_TaxType.TaxPercentage, tbl_TaxType.TaxType
				FROM tbl_IndentReq INNER JOIN  tbl_Items ON tbl_IndentReq.ItemId = tbl_Items.ItemId INNER JOIN
				tbl_TaxType ON tbl_Items.TaxType = tbl_TaxType.TaxTypeId where tbl_IndentReq.ItemId=@ItemId and tbl_IndentReq.BatchNo=@BatchNo and tbl_IndentReq.FId=@FId and tbl_IndentReq.BranchId=@BranchId
				group by tbl_IndentReq.ItemId, tbl_Items.ItemName, tbl_IndentReq.BatchNo, tbl_TaxType.TaxPercentage, tbl_TaxType.TaxType

			end
		else
			begin
				set @Usertype =( Select Usertype from CTuser where CUId=@UserId and branchid=@BranchId)
				if(@Usertype='Store Special')
					begin
						--set @MarkUp =(select CounterItemPer+10 from tbl_Dept where DeptId=@DeptId)
						  set @MarkUp = (select MarkUpOPD+10 from tbl_Items where ItemId=@ItemId and FId=@FId and BranchId=@BranchId )
						  set @TempCostPrice= (SELECT TOP 1 isnull(CostPrice ,0) as CostPrice
FROM 
    (SELECT TOP 5 CostPrice 
     FROM tbl_IndentReq  where ItemId=@ItemId and deptid=@DeptId and FId=@FId and BranchId=@BranchId 
     ORDER BY IndReq  DESC) AS Comp 
ORDER BY CostPrice  desc)
if(@TempCostPrice is null)
begin
set @TempCostPrice=0
end
						SELECT distinct tbl_IndentReq.ItemId, tbl_Items.ItemName, ( Max(@TempCostPrice) +( Max(@TempCostPrice)*@MarkUp/100))as PerPackCost,  tbl_IndentReq.BatchNo, tbl_TaxType.TaxPercentage, tbl_TaxType.TaxType
						FROM  tbl_IndentReq INNER JOIN  tbl_Items ON  tbl_IndentReq.ItemId = tbl_Items.ItemId INNER JOIN
						tbl_TaxType ON tbl_Items.TaxType = tbl_TaxType.TaxTypeId where  tbl_IndentReq.ItemId=@ItemId and  tbl_IndentReq.BatchNo=@BatchNo and  tbl_IndentReq.FId=@FId and  tbl_IndentReq.BranchId=@BranchId
						group by tbl_IndentReq.ItemId, tbl_Items.ItemName, tbl_IndentReq.BatchNo, tbl_TaxType.TaxPercentage, tbl_TaxType.TaxType
					end
				else
					begin
						--set @MarkUp =(select CounterItemPer from tbl_Dept where DeptId=@DeptId)
						  set @MarkUp = (select MarkUpOPD from tbl_Items where ItemId=@ItemId and FId=@FId and BranchId=@BranchId )

						  						  set @TempCostPrice= (SELECT TOP 1 isnull(CostPrice ,0) as CostPrice
FROM 
    (SELECT TOP 5 CostPrice 
     FROM tbl_IndentReq  where ItemId=@ItemId and deptid=@DeptId and FId=@FId and BranchId=@BranchId 
     ORDER BY IndReq  DESC) AS Comp 
ORDER BY CostPrice  desc)
if(@TempCostPrice is null)
begin
set @TempCostPrice=0
end
	

						SELECT distinct tbl_IndentReq.ItemId, tbl_Items.ItemName, ( Max(@TempCostPrice) +( Max(@TempCostPrice)*@MarkUp/100))as PerPackCost,  tbl_IndentReq.BatchNo, tbl_TaxType.TaxPercentage, tbl_TaxType.TaxType
						FROM  tbl_IndentReq INNER JOIN  tbl_Items ON  tbl_IndentReq.ItemId = tbl_Items.ItemId INNER JOIN
						tbl_TaxType ON tbl_Items.TaxType = tbl_TaxType.TaxTypeId where  tbl_IndentReq.ItemId=@ItemId and  tbl_IndentReq.BatchNo=@BatchNo and  tbl_IndentReq.FId=@FId and  tbl_IndentReq.BranchId=@BranchId
						group by tbl_IndentReq.ItemId, tbl_Items.ItemName, tbl_IndentReq.BatchNo, tbl_TaxType.TaxPercentage, tbl_TaxType.TaxType
					end
			end		
	end


END

GO

