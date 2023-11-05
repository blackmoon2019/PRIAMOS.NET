USE [Priamos_NET]
GO
/****** Object:  StoredProcedure [dbo].[oil_cancelCalculate]    Script Date: 5/11/2023 7:23:54 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		John Mavroselinos
-- Create date: 09/09/2023
-- Description:	Ακύρωση Υπολογισμού Κατανάλωσης Πετρελαίου
-- =============================================

ALTER   PROCEDURE [dbo].[oil_cancelCalculate]	
			(@tankID as uniqueidentifier)
	
AS
BEGIN

	DECLARE @bdgID as uniqueidentifier

	SELECT @bdgID  = bdgid from TANK where ID=@tankID 

	--Επαναφορά αχρέωτων λίτρων
	update INV_OILP set unchargedLiters =  unchargedLiters + INV_OILD.liters 
	FROM INV_OILD 
	INNER JOIN INV_OILP ON INV_OILP.invOilID  = INV_OILD.invOilID  
	where tankID=@tankID 

	--Ενημέρωση Τιμολογίων ως ανολοκλήρωτα
	UPDATE INV_OIL set completed = 0 	
	FROM INV_OIL
	INNER JOIN INV_OILD  ON INV_OIL.ID  = INV_OILD.invOilID  
	where tankID=@tankID 

	-- Ενημέρωση Εγγραφής ότι δεν υπλογίστηκε
	UPDATE TANK SET calculated = 0 where id=@tankID

	--Διαγραφή Κινήσεων Τιμολογίων πετρελαίου θέρμανσης
	DELETE FROM INV_OILD where tankID=@tankID 
 
	--Διαγραφή Καταναλώσεων
	DELETE CONSUMPTIONS 
	FROM CONSUMPTIONS 
	INNER JOIN tank ON tank.CONSUMPTIONID = CONSUMPTIONS.ID
	where tank.ID=@tankID 

	-- Ενημέρωση αχρέωτου ποσού πετρελαίου δεξαμενής 
	EXEC CalculateUnchargableOil @bdgID
	
	declare @totDepositR decimal(18,2) 		-- Διαθέσιμο Αποθεματικό	
	declare @UnchargableOil decimal(18,2)    -- Αχρέωτο πετρέλαιο δεξαμενής
	declare @UnpaidInd decimal(18,2) 		-- Απλήρωτα έξοδα υπολογισμένων παραστατικών
	declare @PaidInd  decimal(18,2) 			-- Πληρωμένα Έξοδα ανυπολόγιστων Παραστατικών 
	declare @AptBalAdm   decimal(18,2) 		-- Οφειλές Διαμερισμάτων
	declare @totPrepayments   decimal(18,2)  -- Προεισπράξεις
	declare @totDepositRAndPrepayments   decimal(18,2) 
	exec CalculateAndReturnDepositR  @bdgID,@totDepositR,@UnchargableOil,@UnpaidInd,@PaidInd,@AptBalAdm,@totPrepayments,@totDepositRAndPrepayments

end