USE [Priamos_NET]
GO
/****** Object:  StoredProcedure [dbo].[ChangeAPTOrder]    Script Date: 5/11/2023 7:19:42 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		John Mavroselinos
-- Create date: 29/06/2022
-- Description:	Αλλάζει το order των διαμερισμάτων μιας πολυκατοικίας
-- =============================================
ALTER PROCEDURE [dbo].[ChangeAPTOrder]	(
	@bdgID as uniqueidentifier,				--ID Πολυκατοικίας
	@aptID as uniqueidentifier,				--ID Διαμερίσματος
	@oldOrd as int,							--Παλιό AA Διαμερίσματος
	@NewOrd as int							--Νέο AA Διαμερίσματος
										)			
	
AS
BEGIN
DECLARE @apID as uniqueidentifier				--ID Διαμερίσματος

			UPDATE APT SET ORD=@NewOrd WHERE id=@aptID 
			set @NewOrd = @NewOrd + 1 

			DECLARE db_APT_CURSOR CURSOR FOR 
				select ID FROM APT where bdgid=@bdgID and ord>@oldord
			OPEN db_APT_CURSOR
			FETCH NEXT FROM db_APT_CURSOR INTO @apID
			WHILE @@FETCH_STATUS = 0  
			BEGIN  

			update APT set ord=@NewOrd  where ID=@apID  

			set @NewOrd = @NewOrd + 1 

			FETCH NEXT FROM db_APT_CURSOR INTO @apID 
			end
			CLOSE db_APT_CURSOR
			DEALLOCATE db_APT_CURSOR


END