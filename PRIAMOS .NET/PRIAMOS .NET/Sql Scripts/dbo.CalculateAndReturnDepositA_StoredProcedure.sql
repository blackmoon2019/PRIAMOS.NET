USE [Priamos_NET]
GO
/****** Object:  StoredProcedure [dbo].[CalculateAndReturnDepositA]    Script Date: 5/11/2023 7:15:13 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		John Mavroselinos
-- Create date: 09/07/2023
-- Description:	Υπολογίζει το Λογιστικό απόθεμα και της Προεισπράξης μιας πολυκατοικίας
-- =============================================
ALTER   PROCEDURE [dbo].[CalculateAndReturnDepositA]	(
	@bdgID as uniqueidentifier,				--ID Πολυκατοικίας
	@Amt decimal(18,2) OUTPUT
										)			
	
AS
BEGIN
	DECLARE @AmtPrepayments decimal(18,2)
	SELECT @Amt = isnull(SUM(AMT),0) from DEPOSIT_A (NOLOCK) where bdgID=@bdgID  and isPrepayment = 0
	SELECT @AmtPrepayments = isnull(SUM(AMT),0) from DEPOSIT_A (NOLOCK) where bdgID=@bdgID  and isPrepayment = 1

	UPDATE BDG SET totDepositA = @Amt,totPrepayments = @AmtPrepayments  where ID=@bdgID 
	RETURN @Amt 

END

