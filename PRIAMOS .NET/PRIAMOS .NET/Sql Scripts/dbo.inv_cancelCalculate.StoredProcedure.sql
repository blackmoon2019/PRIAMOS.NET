/****** Object:  StoredProcedure [dbo].[inv_cancelCalculate]    Script Date: 3/12/2023 4:45:52 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		John Mavroselinos
-- Create date: 31/07/2022
-- Description:	Ακύρωση Παραστατικού
-- =============================================
ALTER   PROCEDURE [dbo].[inv_cancelCalculate]	(@inhid as uniqueidentifier)				--ID Παραστατικού


	
AS
BEGIN
SET NOCOUNT ON;
	declare @ahpbHID as uniqueidentifier
	declare @ahpbHIDB as uniqueidentifier
	declare @bdgID as uniqueidentifier

	select  @bdgID  = bdgid, @ahpbHID = ahpB_HID,@ahpbHIDB = ahpB_HIDB    from INH WHERE ID=@inhid 

	

	--Ενημέρωση Παραστατικού ως ακυρωμένο
	update INH SET Calculated =0,DateOfPrint =null,DateOfPrintEidop=null,DateOfPrintEisp=null,ahpb_HID=null,ahpb_HIDB=null,DateOfCalculate=null  WHERE ID=@inhid

	--Ενημέρωση υπολοίπου Διαμερισμάτων 
	--Update apt set bal_adm  = ISNULL(BAL_ADM,0) - ISNULL((select isnull(sum(isnull(debit,0)),0) FROM COL WHERE  inhID=@inhid  and aptID=APT.ID),0) where bdgID=@bdgID and apt.out=0
	
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

	-- Διαγραφή αποθεματικού
	delete from DEPOSIT_A  where inhID=@inhid 
	--Υπολογισμός Αποθεματικού
	DECLARE @Amt decimal(18,2)
	exec [CalculateAndReturnDepositA] @bdgID, @Amt 
	--Ενημέρωση εξόδων ότι δεν πληρώθηκε
	UPDATE IND SET PAID = 0 WHERE ((regardingdeposit=1 or isPrepayment =1) AND inhID=@inhid )

	--Διαγραφή Επισύναψης Εξόδων όταν αφορα Καταναλώσεις Πετρελαίου (αφορά αυτονομία)
	delete from IND_F where indID in(
	SELECT D.ID
	FROM IND D
	INNER JOIN CONSUMPTIONS C ON C.ID=D.consumptionID 
	INNER JOIN INV_OILD OILD ON OILD.consumptionID =C.ID
	INNER JOIN TANK T ON T.ID =OILD.tankID 
	INNER JOIN INV_OIL O ON O.ID=OILD.invOilID 
	INNER JOIN INV_OILF F ON F.invOilID =O.ID
	where D.inhID=@inhid)
		
  --Διαγραφή Επισύναψης Εξόδων όταν αφορα Καταναλώσεις Φ.αερίου (αφορά αυτονομία)
	delete from IND_F where indID in(
	SELECT  D.ID
	FROM IND D
	INNER JOIN CONSUMPTIONS C ON C.ID=D.consumptionID 
	INNER JOIN INV_GAS G ON G.ID=C.invGasID 
	INNER JOIN INV_GASF F ON F.invGASID=G.ID
	where D.inhID=@inhid)

	--Διαγραφή Κατανάλωσης
	DELETE FROM IND WHERE inhID=@inhid and consumptionID is not NULL

	--Διαγραφή Επισύναψης Εξόδων όταν αφορα Καταναλώσεις Καταμερισμός με χιλιοστά
	delete from IND_F where indID in(
	select D.ID
	FROM IND D
	INNER JOIN INV_OIL O ON O.ID=D.invOilID 
	INNER JOIN INV_OILF F ON F.invOilID =O.ID
	INNER JOIN BDG B ON B.ID=O.bdgID 
	where 
	(B.HTypeID = '94CECEE9-739E-4E31-9B43-796D318FB9C5' OR B.BTypeID = '94CECEE9-739E-4E31-9B43-796D318FB9C5' )
	AND D.inhID=@inhid)
	
	--Ενημέρωση εξόδων ότι δεν υπάρχει κατανάλωση
	UPDATE IND SET consumptionID = NULL,paid=0,SelectedFiles=NULL WHERE inhID=@inhid 


	--Επισύναψη Εξόδων όταν το φυσικό αέριο αφορά πάγιο
	delete from IND_F where indID in(
	SELECT  D.ID
	FROM IND D
	INNER JOIN INV_GAS G ON G.ID=D.invGasID 
	INNER JOIN INV_GASF F ON F.invGASID  =G.ID
	where D.inhID=@inhid and G.fixed = 1)

	--Ενημέρωση εξόδων ότι πληρώθηκε όταν το φυσικό αέριο αφορά πάγιο
	UPDATE IND SET PAID = 0 ,SelectedFiles=NULL
	FROM IND D
	INNER JOIN INV_GAS G ON G.ID=D.invGasID 
	INNER JOIN INV_GASF F ON F.invGASID  =G.ID
	where D.inhID=@inhid and G.fixed = 1

END