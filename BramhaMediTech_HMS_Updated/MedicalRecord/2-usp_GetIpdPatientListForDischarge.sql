USE [MediTortal_HMS]
GO

/****** Object:  StoredProcedure [dbo].[usp_GetIpdPatientListForDischarge]    Script Date: 14-11-2022 7.20.29 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO








-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[usp_GetIpdPatientListForDischarge]

	@start varchar(20) =null,
	@end varchar(20) =null,
	@PatRegId nvarchar(250)='0',
	@RTypeId int=null,
	@FId int=null,
	@BranchId int=null
AS
BEGIN
--declare @start date = '2015-05-01',
--@end date = '2015-05-20',
--@PatRegId nvarchar(250)='',
--@RTypeId int =0,
--@BranchId int=1
	 Declare @sql varchar(5000)


set @sql='SELECT        RoomType.RType, RoomMst.RoomName, IpdRegistration.IpdNo, IpdRegistration.PatRegId, IpdRegistration.IpdId, IpdRegistration.EntryDate, IpdRegistration.EntryTime, IpdRegistration.DeptId, IpdRegistration.PrimaryDoc, 
                         IpdRegistration.SecodaryDoc, IpdRegistration.ReferenceDoc, IpdRegistration.PatientMainCategoryId, IpdRegistration.ContactPerson1, IpdRegistration.ContactPerson2, IpdRegistration.Relation1, IpdRegistration.Relation2, 
                         IpdRegistration.Contact1, IpdRegistration.Contact2, IpdRegistration.BedId, IpdRegistration.IsAdmited, IpdRegistration.CreatedBy, IpdRegistration.CreatedOn, IpdRegistration.FId, IpdRegistration.BranchId, 
                         IpdRegistration.UpdatedBy, IpdRegistration.UpdatedOn, IpdRegistration.IsUniversalPrecaution, IpdRegistration.IsEmergency, BedMst.BedName, AlloctnOfBed.PatStatus, AlloctnOfBed.DateOfAdmission, HospEmpMst.Title +'' ''+HospEmpMst.Empname as Empname, 
                         RoomMst.RTypeId, Initial.Title +'' ''+PatientInformation.FirstName as FirstName, PatientInformation.TitleId, Initial.Title, HospEmpMst.Title AS Expr1, ISNULL(IpdBillMaster.BillAmount, 0) AS BillAmount, ISNULL(IpdBillMaster.InvoiceNo, 0) AS InvoiceNo, 
                         IpdBillMaster.BillNo,PatMainType.PatMainType, PatientInsuType.PatientInsuType,
						 ISNULL(IpdBillMaster.BillAmount, 0) -(ISNULL(IpdBillMaster.AmountReceived, 0) +ISNULL(IpdBillMaster.InsuranceAmt, 0))as BalanceAmt
FROM            IpdBillMaster INNER JOIN
IpdRegistration ON IpdBillMaster.IpdNo = IpdRegistration.IpdNo AND IpdBillMaster.PatRegId = IpdRegistration.PatRegId INNER JOIN
PatMainType ON IpdRegistration.PatientMainCategoryId = PatMainType.PatMainTypeId INNER JOIN
PatientInsuType ON PatMainType.PatMainTypeId = PatientInsuType.PatMainTypeId AND IpdRegistration.PatientSubCategoryId = PatientInsuType.PatientInsuTypeId LEFT OUTER JOIN
PatientInformation LEFT OUTER JOIN
Initial ON PatientInformation.TitleId = Initial.TitleId ON IpdRegistration.PatRegId = PatientInformation.PatRegId LEFT OUTER JOIN
HospEmpMst ON IpdRegistration.PrimaryDoc = HospEmpMst.DrId LEFT OUTER JOIN
BedMst INNER JOIN
AlloctnOfBed ON BedMst.BedId = AlloctnOfBed.BedId INNER JOIN
RoomMst ON BedMst.RoomId = RoomMst.RoomId INNER JOIN
RoomType ON RoomMst.RTypeId = RoomType.RTypeId ON IpdRegistration.IPDNO = AlloctnOfBed.IpdId
WHERE        (IpdBillMaster.IsDischarge = 1)  AND (AlloctnOfBed.PatStatus = ''Discharged'')
	and IpdRegistration.BranchId='''+ convert(varchar(10),@BranchId)+''''
	if(convert(varchar(250),@PatRegId)<>'0' or @RTypeId<>0)
	begin
	if(convert(varchar(250),@PatRegId)<>'0')
	begin	
	 set @sql=@Sql +' and IpdRegistration.PatRegId = ''' +  convert(varchar(250),@PatRegId)  + '''' 
	end
	
	if(@RTypeId<>0 )
	begin
	 set @sql=@Sql +' and RoomMst.RTypeId = ''' +  convert(varchar(10),@RTypeId)  + '''' 
	end
	end
	else
	begin 
	if(@start<>'' and @end<>'' )
	begin	
	set @sql=@Sql +' and CONVERT(date, AlloctnOfBed.DateofDischarge) 	between '''+ CONVERT(VARCHAR(10), CONVERT(date, @start, 105), 23) +'''and '''+CONVERT(VARCHAR(10), CONVERT(date, @end, 105), 23)+'''' 
	end
	end
	
	print(@sql)
	Exec(@sql + ' order by IpdRegistration.IpdId desc ')

	

END








GO

