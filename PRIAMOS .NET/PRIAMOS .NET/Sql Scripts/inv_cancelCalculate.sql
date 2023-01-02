USE [Priamos_NET]
GO
/****** Object:  StoredProcedure [dbo].[inv_cancelCalculate]    Script Date: 2/1/2023 11:51:23 πμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		John Mavroselinos
-- Create date: 31/07/2022
-- Description:	Ακύρωση Παραστατικού
-- =============================================
ALTER PROCEDURE [dbo].[inv_cancelCalculate]	(@inhid as uniqueidentifier)				--ID Παραστατικού


	
AS
BEGIN
SET NOCOUNT ON;
	declare @ahpbHID as uniqueidentifier
	declare @ahpbHIDB as uniqueidentifier
	
	select  @ahpbHID = ahpB_HID,@ahpbHIDB = ahpB_HIDB    from INH WHERE ID=@inhid 
	

	--Ενημέρωση Παραστατικού ως ακυρωμένο
	update INH SET Calculated =0,DateOfPrint =null,DateOfPrintEidop=null,DateOfPrintEisp=null,ahpb_HID=null,ahpb_HIDB=null,DateOfCalculate=null  WHERE ID=@inhid

	--Ενημέρωση υπολοίπου Διαμερισμάτων 
	Update apt set bal_adm  = ISNULL(BAL_ADM,0) - ISNULL((select sum(isnull(debit,0)) FROM COL WHERE inhID=@inhid AND aptID=APT.ID),0)
	
	--Ενημέρωση μετρήσης ωρών θέρμανσης ως διαθέσιμη
	Update AHPB_H set finalized=0 where ID=@ahpbHID

	--Ενημέρωση μετρήσης ωρών Boiler ως διαθέσιμη
	Update AHPB_H set finalized=0 where ID=@ahpbHIDB
	
	--Διαγραφή υπολογισμού
	delete from inc where inhID  =@inhid 

	-- Διαγραφή προοδευτικών εισπράξεων από παραστατικό
	delete from col_p where inhID=@inhid 

	-- Διαγραφή εισπράξεων από παραστατικό
	delete from col where inhID=@inhid 

END


 