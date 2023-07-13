USE [Priamos_NET]
GO

/****** Object:  StoredProcedure [dbo].[CalculateAndReturnDepositA]    Script Date: 13/7/2023 9:35:47 μμ ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		John Mavroselinos
-- Create date: 09/07/2023
-- Description:	Υπολογίζει το Λογιστικό απόθεμα μιας πολυκατοικίας
-- =============================================
ALTER   PROCEDURE [dbo].[CalculateAndReturnDepositA]	(
	@bdgID as uniqueidentifier,				--ID Πολυκατοικίας
	@Amt decimal(18,2) OUTPUT
										)			
	
AS
BEGIN
	
	SELECT @Amt = SUM(AMT) from DEPOSIT_A (NOLOCK) where bdgID=@bdgID 
	UPDATE BDG SET totDepositA = @Amt where ID=@bdgID 
	RETURN @Amt 

END

GO

