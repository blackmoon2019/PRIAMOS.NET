USE [Priamos_NET]
GO
/****** Object:  StoredProcedure [dbo].[batch_create_ind]    Script Date: 5/11/2023 7:11:26 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		John Mavroselinos
-- Create date: 06/08/2023
-- Description:	Δημιουργία εξόδων παραστατικών 
-- =============================================

ALTER    PROCEDURE [dbo].[batch_create_ind]	
			(@RepName nvarchar(100),@CalcCatID uniqueidentifier,@owner_tenant bit,@createdby uniqueidentifier,@Paid bit)
	
AS
BEGIN
 --truncate table IND_BATCH 
    INSERT INTO IND_BATCH (ID,bdgID,repName,amt,inhID,calcCatID,owner_tenant,Paid,IndCreated,createdBy,createdOn )
	
	SELECT newid(),ID,@RepName,0,
	(select top 1 ID from INH (nolock) where bdgID = BDG.ID and Calculated=0 and reserveAPT=0 order by fDate ) as InhID,	
		(SELECT  CALC_CAT.ID 
		 FROM   CALC_CAT
		 INNER JOIN BMLC (nolock) ON CALC_CAT.mlcID = BMLC.mlcID 
		 WHERE BMLC.bdgID=BDG.ID and CALC_CAT.ID=@CalcCatID)  ,
		 @owner_tenant,@Paid,0,@createdby,GETDATE()  
	FROM BDG (nolock) WHERE isManaged = 1 and 
		(select COUNT(id) from INH (nolock)where reserveAPT=0 and Calculated=0 and bdgID=BDG.ID)>0 
		and BDG.ID not in(select bdgid from IND_BATCH where bdgID = BDG.ID and IndCreated=0)
		
 


end
