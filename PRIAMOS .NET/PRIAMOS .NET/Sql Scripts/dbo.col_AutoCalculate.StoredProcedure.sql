USE [Priamos_NET]
GO
/****** Object:  StoredProcedure [dbo].[col_AutoCalculate]    Script Date: 27/6/2023 8:52:42 πμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		John Mavroselinos
-- Create date: 05/06/2022
-- Description:	Αυτόματη εξόφληση παραστατικών όταν υπάρχει αρνητικό υπόλοιπο στο διαμέρισμα
-- =============================================
CREATE PROCEDURE [dbo].[col_AutoCalculate]	(
	@inhid as uniqueidentifier,				--ID Παραστατικού
	@bdgid as uniqueidentifier				--ID Πολυκατοικίας
	)	

	
AS
BEGIN
SET NOCOUNT ON;
Declare @aptID as uniqueidentifier				
Declare @colID as uniqueidentifier				
Declare @debitusrID as uniqueidentifier				
DECLARE @InhDebit decimal (18,2)
	
	DECLARE db_COL_CURSOR CURSOR FOR 
		
		--select APT.ID,sum(debit ),INH.modifiedBy   
		--From APT 
		--inner join COL on COL.aptID = APT.ID  and COL.inhID=@inhid and COL.bdgID=@bdgid and completed=0
		--inner join INH on COL.inhID  = INH.ID
		--where bal_adm<0 AND  APT.bdgID=@bdgid 
		--group by  APT.ID,INH.modifiedBy   
		
		--10/10/2022
		select apt.id,(bal_adm *(-1))
		From APT 
		inner join bdg on bdg.id=apt.bdgID 
		where bal_adm<0 AND  APT.bdgID= @bdgid
		
	OPEN db_COL_CURSOR
	FETCH NEXT FROM db_COL_CURSOR INTO  @aptID,@InhDebit --@aptID,@InhDebit ,@debitusrID
	WHILE @@FETCH_STATUS = 0  
	BEGIN  
		--Αναγκαστικά πρέπει να περάσω αυτόματα χρήστη χρέωσης πάω στην είσπραξη ώστε να εκτελεστεί η διαδικασία σωστά. Ο Χρήστης είναι ο System User
		--UPDATE COL SET debitusrID='26521b58-5590-4880-a31e-4e91a6cf964d' WHERE ID=@colID 
		--10/10/2022
		--exec [dbo].[col_Calculate] '26521b58-5590-4880-a31e-4e91a6cf964d',@bdgID ,@aptID ,@inhID ,@InhDebit ,@debitusrID  , '75E3251D-077D-42B0-B79A-9F2886381A97' , 2 ,0
		exec [dbo].[col_Calculate] '26521b58-5590-4880-a31e-4e91a6cf964d',@bdgID ,@aptID ,@inhID ,@InhDebit ,'26521b58-5590-4880-a31e-4e91a6cf964d'  , '75E3251D-077D-42B0-B79A-9F2886381A97' , 2 ,1
	FETCH NEXT FROM db_COL_CURSOR INTO @aptID,@InhDebit --@aptID,@InhDebit ,@debitusrID 
	end
	CLOSE db_COL_CURSOR
	DEALLOCATE db_COL_CURSOR


END

GO
