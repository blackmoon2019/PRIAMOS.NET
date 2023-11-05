USE [Priamos_NET]
GO
/****** Object:  StoredProcedure [dbo].[inv_cancel]    Script Date: 5/11/2023 7:21:55 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		John Mavroselinos
-- Create date: 11/06/2022
-- Description:	Ακύρωση Παραστατικού
-- =============================================
ALTER PROCEDURE [dbo].[inv_cancel]	(
	@inhid as uniqueidentifier,				--ID Παραστατικού
	@canceledBY as uniqueidentifier			--ID χρήστη ακύρωσης
	)	

	
AS
BEGIN
SET NOCOUNT ON;
	declare @ahpbHID as uniqueidentifier
	declare @ahpbHIDB as uniqueidentifier
	
	select  @ahpbHID = ahpB_HID,@ahpbHIDB = ahpB_HIDB    from INH WHERE ID=@inhid 
	

	--Ενημέρωση Παραστατικού ως ακυρωμένο
	update INH SET canceled=1,canceledBy=@canceledBY,DateOfCancel=GETDATE() WHERE ID=@inhid

	--Ενημέρωση υπολοίπου Διαμερισμάτων 
	Update apt set bal_adm  = BAL_ADM - (select sum(isnull(debit,0)) FROM COL WHERE inhID=@inhid AND aptID=APT.ID)
	
	--Ενημέρωση μετρήσης ωρών θέρμανσης ως διαθέσιμη
	Update AHPB_H set finalized=0 where ID=@ahpbHID

	--Ενημέρωση μετρήσης ωρών Boiler ως διαθέσιμη
	Update AHPB_H set finalized=0 where ID=@ahpbHIDB
	

	-- Διαγραφή εισπράξεων από παραστατικό
	delete from col where inhID=@inhid 

END


