USE [Priamos_NET]
GO
/****** Object:  StoredProcedure [dbo].[CalculateAndReturnDepositR]    Script Date: 5/11/2023 7:16:32 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		John Mavroselinos
-- Create date: 30/07/2023
-- Description:	Υπολογίζει το Διαθέσιμο απόθεματικο μιας πολυκατοικίας
-- Διαθέσιμο υπόλοιπο = (Λογιστικό υπόλοιπο  +  απλήρωτα έξοδα υπολογισμένων παραστατικών + Αχρέωτο πετρέλαιο δεξαμενής) - 
--					   (Πληρωμένα Έξοδα ανυπολόγιστων Παραστατικών - Οφειλές Διαμερισμάτων) 
-- =============================================
ALTER   PROCEDURE [dbo].[CalculateAndReturnDepositR]	(
	@bdgID as uniqueidentifier,				-- ID Πολυκατοικίας
	@totDepositR decimal(18,2) OUTPUT,		-- Διαθέσιμο Αποθεματικό	
	@UnchargableOil decimal(18,2) OUTPUT,   -- Αχρέωτο πετρέλαιο δεξαμενής
	@UnpaidInd decimal(18,2) OUTPUT,		-- Απλήρωτα έξοδα υπολογισμένων παραστατικών
	@PaidInd  decimal(18,2) OUTPUT,			-- Πληρωμένα Έξοδα ανυπολόγιστων Παραστατικών 
	@AptBalAdm   decimal(18,2) OUTPUT,		-- Οφειλές Διαμερισμάτων
	@totPrepayments   decimal(18,2) OUTPUT, -- Προεισπράξεις
	@totDepositRAndPrepayments   decimal(18,2) OUTPUT) -- Λογιστικό Αποθεματικό με προεισπράξεις
AS
BEGIN
	

	DECLARE @totalDepositA decimal(18,2) -- Λογιστικό Αποθεματικό
	--DECLARE @UnchargableOil decimal(18,2)-- Αχρέωτο πετρέλαιο δεξαμενής
	--DECLARE @UnpaidInd decimal(18,2)	 -- Απλήρωτα έξοδα υπολογισμένων παραστατικών
	--DECLARE @PaidInd decimal(18,2)		 -- Πληρωμένα Έξοδα ανυπολόγιστων Παραστατικών 
	--DECLARE @AptCol decimal(18,2)		 -- Οφειλές Διαμερισμάτων
	
	-- Ενημέρωση αχρέωτων πετρελαίων
	exec CalculateunchargableOil @bdgID

	-- Λογιστικό Αποθεματικό,Αχρέωτο πετρέλαιο δεξαμενής
	SELECT @totalDepositA = isnull(totDepositA,0),@UnchargableOil =isnull(UnchargableOil,0),
	@totPrepayments =isnull(totPrepayments,0),@totDepositRAndPrepayments = isnull(totDepositRAndPrepayments,0)
	from BDG (NOLOCK) where ID=@bdgID 
	
	-- Απλήρωτα έξοδα υπολογισμένων παραστατικών
	SELECT @UnpaidInd = isnull(sum(isnull(amt,0)) ,0)
	from IND (nolock)
	inner join inh (nolock) on inh.id=ind.inhID
	where calculated=1 and paid = 0 and reserveAPT=0 and FromTransfer = 0 and bdgID=@bdgID 
	
	-- Πληρωμένα Έξοδα ανυπολόγιστων Παραστατικών 
	SELECT @PaidInd = isnull(sum(isnull(amt,0)) ,0)
	from IND (nolock)
	inner join inh (nolock) on inh.id=ind.inhID
	where calculated=0 and paid = 1 and reserveAPT=0 and FromTransfer = 0 and bdgID=@bdgID 

	-- Οφειλές Διαμερισμάτων
	SELECT @AptBalAdm    = isnull(sum(isnull(bal_adm,0)) ,0) from APT (nolock) where bdgID=@bdgID and bal_adm>=0
	
	-- Διαθέσιμο Αποθεματικό
	SET @totDepositR = (@totalDepositA + @UnpaidInd) - (@UnchargableOil + @PaidInd+ @AptBalAdm   )
	UPDATE BDG SET totDepositR = @totDepositR, totDepositRAndPrepayments = isnull(@totDepositR,0) + isnull(totPrepayments,0)  where ID=@bdgID 

	SELECT @totalDepositA = isnull(totDepositA,0),@UnchargableOil =isnull(UnchargableOil,0),
	@totPrepayments =isnull(totPrepayments,0),@totDepositRAndPrepayments = isnull(totDepositRAndPrepayments,0)
	from BDG (NOLOCK) where ID=@bdgID 

	select  @totDepositR ,@UnpaidInd,@PaidInd,@AptBalAdm,@totPrepayments,@totDepositRAndPrepayments   
END