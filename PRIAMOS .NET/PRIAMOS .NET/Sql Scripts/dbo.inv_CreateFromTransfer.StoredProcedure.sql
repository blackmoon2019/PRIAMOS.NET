USE [Priamos_NET]
GO
/****** Object:  StoredProcedure [dbo].[inv_CreateFromTransfer]    Script Date: 27/6/2023 8:52:42 πμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		John Mavroselinos
-- Create date: 18/06/2023
-- Description:	Δημιουργία παραστατικών Εκ Μεταφοράς
-- =============================================

CREATE     PROCEDURE [dbo].[inv_CreateFromTransfer]	
			(@bdgID as uniqueidentifier)
	
AS
BEGIN
 SET NOCOUNT ON;
BEGIN TRAN
BEGIN TRY
    
	

DECLARE @InhID Uniqueidentifier
DECLARE @IndIDOwner Uniqueidentifier
DECLARE @IndIDTenant Uniqueidentifier
Declare @fDate Datetime
Declare @tDate Datetime

	DECLARE db_INH_CURSOR CURSOR FOR 
		
		Select newid(),fdate,tdate
		from tmpBatchCollections where bdgID = @bdgID
		group by [bdgID],  [fDate], [tDate],  [completeDate]  
		order by fDate 

	OPEN db_INH_CURSOR
	FETCH NEXT FROM db_INH_CURSOR INTO @InhID,@fDate,@tDate
	WHILE @@FETCH_STATUS = 0  
	BEGIN  
		set @IndIDOwner= newid()
		set @IndIDTenant = newid()

		-- Καταχώρηση Παραστατικού
		INSERT INTO INH (id,bdgID,CMT,FDATE,TDATE,TotalInh,createdOn,modifiedBY,completeDate,FromTransfer,calculated)
		Select @InhID ,[bdgID], 'Παραστατικό εκ μεταφοράς από πρώην διαχειριστη', [fDate], [tDate], Sum(Amt), getdate(),[createdBy] ,[completeDate], 1,1
		from tmpBatchCollections where bdgID = @bdgID and fDate = @Fdate and tDate = @TDate
		group by [bdgID],  [fDate], [tDate],  [completeDate], [createdBy] 

		-- Καταχώρηση Εξόδων - Ένοικος
		INSERT INTO IND (id,inhID, calcCatID, repName, amt, owner_tenant)
		SELECT @IndIDTenant,@InhID,'3FE81416-EF7C-4D3B-B1EA-E4CC40350FDE','Eκ μεταφοράς ποσό Εν.',sum(amt),owner_tenant 
		from tmpBatchCollections where owner_tenant = 0  and  bdgID = @bdgID and fDate = @Fdate and tDate = @TDate
		group by owner_tenant

		-- Καταχώρηση Εξόδων - Ιδιοκτήτης
		INSERT INTO IND (id,inhID, calcCatID, repName, amt, owner_tenant)
		SELECT @IndIDOwner,@InhID,'3FE81416-EF7C-4D3B-B1EA-E4CC40350FDE','Eκ μεταφοράς ποσό Ιδ.',sum(amt),owner_tenant 
		from tmpBatchCollections where owner_tenant = 1  and  bdgID = @bdgID and fDate = @Fdate and tDate = @TDate
		group by owner_tenant
 
		--Καταχώρηση Υπολογισμένης εγγραφής - Ιδιοκτητης
		INSERT INTO INC (ID,inhID,indID,bdgID,aptID, monomers1,tot_monomers1,createdby)
		SELECT newid(),@InhID,@IndIDOwner ,@bdgID,aptID,sum(amt),sum(amt),createdBy 
		from tmpBatchCollections where owner_tenant = 1  and  bdgID = @bdgID  and fDate = @Fdate and tDate = @TDate
		group by owner_tenant,aptID,createdBy 

		--Καταχώρηση Υπολογισμένης εγγραφής - Ένοικος
		INSERT INTO INC (ID,inhID,indID,bdgID,aptID, monomers1,tot_monomers1,createdby)
		SELECT newid(),@InhID, @IndIDtenant ,@bdgID,aptID,sum(amt),sum(amt),createdBy 
		from tmpBatchCollections where owner_tenant = 0  and  bdgID = @bdgID and fDate = @Fdate and tDate = @TDate
		group by owner_tenant,aptID,createdBy 

		--Καταχώρηση Είσπραξης - Ιδιοκτήτης
		INSERT INTO COL (ID,bdgID,aptID,INHID,debit,CREDIT,BAL,cmt,ColMethodID,createdOn,completed,tenant,modifiedBY)
		SELECT newid(),@bdgID,aptid,@InhID,sum(amt),0,sum(amt),'Eκ μεταφοράς ποσό','75E3251D-077D-42B0-B79A-9F2886381A97',getdate(),0,1,createdBy
		from tmpBatchCollections where owner_tenant = 1  and  bdgID = @bdgID and fDate = @Fdate and tDate = @TDate
		group by owner_tenant,aptID,createdBy 

		--Καταχώρηση Είσπραξης - Ένοικος
		INSERT INTO COL (ID,bdgID,aptID,INHID,debit,CREDIT,BAL,cmt,ColMethodID,createdOn,completed,tenant,modifiedBY)
		SELECT newid(),@bdgID,aptid,@InhID,sum(amt),0,sum(amt),'Eκ μεταφοράς ποσό','75E3251D-077D-42B0-B79A-9F2886381A97',getdate(),0,0,createdBy
		from tmpBatchCollections where owner_tenant = 0  and  bdgID = @bdgID and fDate = @Fdate and tDate = @TDate
		group by owner_tenant,aptID,createdBy 

		--Καταχώρηση Προοδευτικής Χρέωσης - Ιδιοκτήτης
		INSERT INTO COL_P (BDGID,APTID,INHID,debit,tenant)
		SELECT @bdgID,aptid,@InhID,sum(amt),1
		from tmpBatchCollections where owner_tenant = 1  and  bdgID = @bdgID and fDate = @Fdate and tDate = @TDate
		group by aptID

		--Καταχώρηση Προοδευτικής Χρέωσης - Ένοικος
		INSERT INTO COL_P (BDGID,APTID,INHID,debit,tenant)
		SELECT @bdgID,aptid,@InhID,sum(amt),0
		from tmpBatchCollections where owner_tenant = 0  and  bdgID = @bdgID and fDate = @Fdate and tDate = @TDate
		group by aptID


	FETCH NEXT FROM db_INH_CURSOR INTO @InhID,@fDate,@tDate
	end
	CLOSE db_INH_CURSOR
	DEALLOCATE db_INH_CURSOR

	--Ενημέρωση Υπολοίπου Διαμερίσματος
	UPDATE APT 
	set bal_adm = bal_adm + isnull((select sum(isnull(amt,0)) from tmpBatchCollections where bdgid=@bdgID   and  aptid=apt.id ),0)
	from tmpBatchCollections
	inner join apt on apt.id = tmpBatchCollections.aptid
	where tmpBatchCollections.bdgID = @bdgID 

	--Διαγραφή οφειλών από τον προσωρινό πίνακα
	Delete from tmpBatchCollections where tmpBatchCollections.bdgID = @bdgID 


COMMIT TRANSACTION -- Transaction Success!
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0
		CLOSE db_INH_CURSOR
		DEALLOCATE db_INH_CURSOR
        ROLLBACK TRANSACTION;


    -- <EDIT>: From SQL2008 on, you must raise error messages as follows:
    DECLARE @ErrorMessage NVARCHAR(4000);  
    DECLARE @ErrorSeverity INT;  
    DECLARE @ErrorState INT;  

    SELECT   
       @ErrorMessage = ERROR_MESSAGE(),  
       @ErrorSeverity = ERROR_SEVERITY(),  
       @ErrorState = ERROR_STATE();  

    RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);  
    -- </EDIT>
END CATCH

end
GO
