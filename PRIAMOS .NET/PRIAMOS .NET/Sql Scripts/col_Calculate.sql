USE [Priamos_NET]
GO
/****** Object:  StoredProcedure [dbo].[col_Calculate]    Script Date: 19/12/2022 1:19:39 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		John Mavroselinos
-- Create date: 16/11/2021
-- Description:	Υπολογισμός Εισπραξεων
-- =============================================

ALTER PROCEDURE [dbo].[col_Calculate]	
			(
			@debitusrID as uniqueidentifier,@bdgID as uniqueidentifier,@aptID as uniqueidentifier,
			@inhID as uniqueidentifier,@Givencredit decimal(18,2),@modifiedBy as uniqueidentifier,@ColMethodID as uniqueidentifier,
			@TenantOwner int,@Agreed int,@ComeFrom bit=0,@BankID as uniqueidentifier=NULL,@BankFileName as nvarchar(250) = NULL,@BankDepositDate as DateTime=null,@ColBanksID as uniqueidentifier='00000000-0000-0000-0000-000000000000' 
			)
	
AS
BEGIN
DECLARE @TotalDebit DECIMAL (18,2)
DECLARE @Bal DECIMAL (18,2),@TmpCredit DECIMAL (18,2)
DECLARE @DebitTenant DECIMAL (18,2),@DebitOwner DECIMAL (18,2)
DECLARE @fdate datetime,@tenant bit
DECLARE @colIDTenant uniqueidentifier,@colIDOwner uniqueidentifier

	
 
 	--ΑΦΟΡΑ ΜΟΝΟ ΤΟ ΤEΛΕΥΤΑΙΟ LEVEL ΠΟΥ ΕΙΝΑΙ ΣΕ ΕΠΙΠΕΔΟ ΕΝΟΙΚΟΥ Ή ΙΔΙΟΚΤΗΤΗ
	IF @inhID <> '00000000-0000-0000-0000-000000000000' and @TenantOwner=0	--ΑΦΟΡΑ ΙΔΙΟΚΤΗΤΗ
	begin
	--print'1'

		--Παίρνω το σύνολο της χρέωσης που υπάρχει στο παραστατικό. 
		--select @TotalDebit=sum(isnull(debit,0)) from col where inhID=@inhID and bdgID=@bdgID and aptID=@aptID and tenant=0
		select @TotalDebit=sum(isnull(debit,0)) from col_p where inhID=@inhID and bdgID=@bdgID and aptID=@aptID and tenant=0

		-- Παίρνω το ID και την χρέωση της είσπραξης για ένοικο
		select @colIDOwner=ID from col where inhID=@inhID and bdgID=@bdgID and aptID=@aptID  and tenant=0
		select @DebitOwner = ISNULL(sum(debit) ,0) FROM COL_P where inhID=@inhID and bdgID=@bdgID and aptID=@aptID  and tenant=0 

		--update COL set debitusrID=@debitusrID, dtCredit=CONVERT(date, GETDATE()),
		--			   Debit=@DebitOwner - @Givencredit,credit=0,Bal=@DebitOwner-@Givencredit,ColMethodID=@ColMethodID  
		--			   where inhID=@inhID and bdgID=@bdgID and aptID=@aptID and tenant=0
		update COL set completed=case when @TotalDebit = @Givencredit then 1 else 0 end,
					   debitusrID=@debitusrID, dtCredit=CONVERT(date, GETDATE()),
					   credit=0,Bal=@DebitOwner-@Givencredit,ColMethodID=@ColMethodID,bankID=@BankID   
					   where inhID=@inhID and bdgID=@bdgID and aptID=@aptID and tenant=0
		--Ενημέρωση προοδευτικής χρέωσης
		update COL_P set debit=debit-@Givencredit   where inhID=@inhID and bdgID=@bdgID and aptID=@aptID  and tenant = 0
		
		-- Καταχώρηση κίνησης είσπραξης για ΙΔΙΟΚΤΗΤΗ
		INSERT INTO COL_D(colID,aptID,bdgid,inhid,debitusrID,Credit,debit,Bal,modifiedBy,modifiedOn,createdOn,tenant,ComeFrom,bankFileName,bankDepositDate,colBanksID   )
		select @colIDOwner ,@aptID,@bdgID,@inhID, @debitusrID,@Givencredit,@DebitOwner,@DebitOwner - @Givencredit ,@modifiedBy,GETDATE() ,GETDATE(),0,@ComeFrom,@BankFileName,@BankDepositDate ,@ColBanksID

		RETURN
	end
	IF @inhID <> '00000000-0000-0000-0000-000000000000' and @TenantOwner=1	--ΑΦΟΡΑ ΕΝΟΙΚΟ
	begin
	--print'2'

		
		--Παίρνω το σύνολο της χρέωσης που υπάρχει στο παραστατικό. 
		--select @TotalDebit=sum(isnull(Debit,0)) from col where inhID=@inhID and bdgID=@bdgID and aptID=@aptID and tenant=1 and completed=0
		select @TotalDebit=sum(isnull(Debit,0)) from col_p where inhID=@inhID and bdgID=@bdgID and aptID=@aptID and tenant=1 

		-- Παίρνω το ID και την χρέωση της είσπραξης για ένοικο
		select @colIDTenant=ID from col where inhID=@inhID and bdgID=@bdgID and aptID=@aptID  and tenant=1
		select @DebitTenant = ISNULL(sum(debit) ,0) FROM COL_P where inhID=@inhID and bdgID=@bdgID and aptID=@aptID  and tenant=1 
		--update COL set debitusrID=@debitusrID, dtCredit=CONVERT(date, GETDATE()),
		--			   Debit=@TotalDebit - @Givencredit,credit=0,Bal=@TotalDebit - @Givencredit,ColMethodID=@ColMethodID  
		--			   where inhID=@inhID and bdgID=@bdgID and aptID=@aptID  and tenant=1
		update COL set completed=case when @TotalDebit = @Givencredit then 1 else 0 end,
					   debitusrID=@debitusrID, dtCredit=CONVERT(date, GETDATE()),
					   credit=0,Bal=@DebitTenant - @Givencredit,ColMethodID=@ColMethodID  ,bankID=@BankID 
					   where inhID=@inhID and bdgID=@bdgID and aptID=@aptID  and tenant=1
		--Ενημέρωση προοδευτικής χρέωσης
		update COL_P set debit=debit-@Givencredit   where inhID=@inhID and bdgID=@bdgID and aptID=@aptID  and tenant = 1
		-- Καταχώρηση κίνησης είσπραξης για ΕΝΟΙΚΟ
		INSERT INTO COL_D(colID,aptID,bdgid,inhid,debitusrID,Credit,debit,Bal,modifiedBy,modifiedOn,createdOn,tenant,agreed,ComeFrom,BankFileName,BankDepositDate,colBanksID  )
		select @colIDTenant ,@aptID,@bdgID,@inhID, @debitusrID,@Givencredit,@DebitTenant ,@DebitTenant - @Givencredit  ,@modifiedBy,GETDATE() ,GETDATE(),1,@Agreed,@ComeFrom ,@BankFileName,@BankDepositDate,@ColBanksID

		
		RETURN
	end
	IF @inhID <> '00000000-0000-0000-0000-000000000000' 
	BEGIN
	--print'3'
		DECLARE db_cursor CURSOR FOR 
			select distinct fdate,inhID from vw_col where bdgID=@bdgID and aptID=@aptID and inhID=@inhID  and debitusrID is not null  and completed=0 order by fdate,inhID 
		OPEN db_cursor  
	END
	ELSE
	BEGIN
	--print'4'
		DECLARE db_cursor CURSOR FOR 
			select distinct fdate,inhID from vw_col where bdgID=@bdgID and aptID=@aptID and debitusrID is not null  and completed=0 order by fdate,inhID 
		OPEN db_cursor  
	END
	FETCH NEXT FROM db_cursor INTO @fdate,@inhid
	WHILE @@FETCH_STATUS = 0  
	BEGIN  
		--print @inhID
		--Αρχικοποίηση μεταβλητών
		SELECT @colIDOwner = NULL, @colIDTenant=NULL,@DebitTenant =0,@DebitOwner = 0
		--Παίρνω το σύνολο της χρέωσης που υπάρχει στο παραστατικό. 
		--select @TotalDebit=sum(ISNULL(Debit ,0)) from col where inhID=@inhID and bdgID=@bdgID and aptID=@aptID and completed=0
		select @TotalDebit=sum(ISNULL(Debit ,0)) from col_p where inhID=@inhID and bdgID=@bdgID and aptID=@aptID 

		--select @colIDTenant=ID,@DebitTenant = ISNULL(Debit,0) from col where inhID=@inhID and bdgID=@bdgID and aptID=@aptID  and tenant=1 and completed=0
		--select @colIDOwner=ID,@DebitOwner = ISNULL(Debit,0) from col where inhID=@inhID and bdgID=@bdgID and aptID=@aptID and tenant=0 and completed=0

		-- Παίρνω το ID και την χρέωση της είσπραξης για ένοικο
		select @colIDTenant=ID from col where inhID=@inhID and bdgID=@bdgID and aptID=@aptID  and tenant=1 and completed=0
		select @DebitTenant = ISNULL(sum(debit) ,0) FROM COL_P where inhID=@inhID and bdgID=@bdgID and aptID=@aptID  and tenant=1 
		-- Παίρνω το ID και την χρέωση της είσπραξης για Ιδιοκτήτη
		select @colIDOwner=ID from col where inhID=@inhID and bdgID=@bdgID and aptID=@aptID and tenant=0 and completed=0
		select @DebitOwner = ISNULL(sum(debit) ,0) FROM COL_P where inhID=@inhID and bdgID=@bdgID and aptID=@aptID  and tenant=0 

	
		--print @Givencredit 
		--print @TotalDebit
		--print @DebitTenant 
		--print @DebitOwner 

		--Εαν το ποσό πίστωσης που έχει δώσει ο Χρήστης είναι ίδιο με το ποσό Χρέωσης τοτε πάμε και κάνουμε όλη την κάλυψη. ΑΦΟΡΑ ΕΝΟΙΚΟ
		if @Givencredit = @TotalDebit 
		BEGIN
		--print'5'
			--Αφου καλύπτεται όλο το ποσό βάζουμε μηδεν καρφωτά στο υπόλοιπο και η πίστωση γίνεται ίδια με την χρέωση και για ένοικο και για ιδιοκτήτη
			--εδώ πλέον που κλείνει η είσπραξη βάζω και χρέωση και πίστωση το ποσό που έδωσε ο χρήστης απέξω
			--update COL set completed=1,debitusrID=@debitusrID, dtCredit=CONVERT(date, GETDATE()),Credit=0,Debit=0,Bal=0,ColMethodID=@ColMethodID  where inhID=@inhID and bdgID=@bdgID and aptID=@aptID 
			update COL set completed=1,debitusrID=@debitusrID, dtCredit=CONVERT(date, GETDATE()),Credit=0,Bal=0,ColMethodID=@ColMethodID,bankID=@BankID   where inhID=@inhID and bdgID=@bdgID and aptID=@aptID 

			if @colIDTenant is not null
			begin
				-- Καταχώρηση κίνησης είσπραξης για ΕΝΟΙΚΟ
				INSERT INTO COL_D(colID,aptID,bdgid,inhid,debitusrID,Credit,debit,Bal,modifiedBy,modifiedOn,createdOn,tenant,agreed,ComeFrom,BankFileName,BankDepositDate,colBanksID  )
				select @colIDTenant ,@aptID,@bdgID,@inhID, @debitusrID,@DebitTenant,@DebitTenant,0 ,@modifiedBy,GETDATE() ,GETDATE(),1,@Agreed,@ComeFrom ,@BankFileName,@BankDepositDate,@ColBanksID
				update COL_P set debit=0  where inhID=@inhID and bdgID=@bdgID and aptID=@aptID  and tenant = 1
			end
			if @colIDOwner is not null
			begin
			--print'6'
				-- Καταχώρηση κίνησης είσπραξης για ΙΔΙΟΚΤΗΤΗ
				INSERT INTO COL_D(colID,aptID,bdgid,inhid,debitusrID,Credit,debit,Bal,modifiedBy,modifiedOn,createdOn,tenant,agreed,ComeFrom,BankFileName,BankDepositDate,colBanksID  )
				select @colIDOwner ,@aptID,@bdgID,@inhID, @debitusrID,@DebitOwner,@DebitOwner,0 ,@modifiedBy,GETDATE() ,GETDATE(),0,@Agreed,@ComeFrom ,@BankFileName,@BankDepositDate,@ColBanksID
				update COL_P set debit=0  where inhID=@inhID and bdgID=@bdgID and aptID=@aptID  and tenant = 0
			end
			--RETURN
		END

		--Εαν η πίστωση που έχει δώσει ο Χρήστης είναι μικρότερη από το ποσό χρέωσης 
		if @Givencredit < @TotalDebit  
		BEGIN
			set @TmpCredit = @Givencredit 
			--print'7'
			--Εαν υπάρχει παραστατικό ενοίκου
			IF @colIDTenant IS NOT NULL
			BEGIN
				--Εαν η πίστωση είναι μεγαλύτερη ή ίση με την χρέωση (αφορά ένοικο) τότε μηδενίζουμε το υπόλοιπο και η πίστωση γίνεται ίδια με την χρέωση
				if @Givencredit  >= @DebitTenant  
				begin
					--print'7.1'
					--update COL set completed=1,debitusrID=@debitusrID,dtCredit=CONVERT(date, GETDATE()),Credit=0,Debit=0,Bal=0,ColMethodID=@ColMethodID where inhID=@inhID and bdgID=@bdgID and aptID=@aptID  and tenant = 1
					update COL set completed=1,debitusrID=@debitusrID,dtCredit=CONVERT(date, GETDATE()),Credit=0,Bal=0,ColMethodID=@ColMethodID,bankID=@BankID  where inhID=@inhID and bdgID=@bdgID and aptID=@aptID  and tenant = 1
					update COL_P set debit=debit-@DebitTenant  where inhID=@inhID and bdgID=@bdgID and aptID=@aptID  and tenant = 1
					-- Καταχώρηση κίνησης είσπραξης
					INSERT INTO COL_D(colID,aptID,bdgid,inhid,debitusrID,Credit,debit,Bal,modifiedBy,modifiedOn,createdOn,tenant,Agreed,ComeFrom,BankFileName,BankDepositDate,colBanksID )
					select @colIDTenant ,@aptID,@bdgID,@inhID, @debitusrID,@DebitTenant,@DebitTenant,0 ,@modifiedBy,GETDATE() ,GETDATE(),1,@Agreed,@ComeFrom ,@BankFileName,@BankDepositDate,@ColBanksID
					set @TmpCredit = @Givencredit  - @DebitTenant
				end
				ELSE
				BEGIN
				--print'8'
					--Εαν η πίστωση δεν είναι μεγαλύτερη ή ίση με την χρέωση καλύπτουμε μέρος του παραστατικού
					set @TmpCredit = @Givencredit  - @DebitTenant 
					set @Bal=ABS(@TmpCredit)
					--update COL set completed=0,debitusrID=@debitusrID,dtCredit=CONVERT(date, GETDATE()),debit=ABS(@TmpCredit),Credit=0 ,Bal=ABS(@TmpCredit),ColMethodID=@ColMethodID  where inhID=@inhID and bdgID=@bdgID and aptID=@aptID  and tenant = 1
					update COL set completed=0,debitusrID=@debitusrID,dtCredit=CONVERT(date, GETDATE()),Credit=0 ,Bal=ABS(@TmpCredit),ColMethodID=@ColMethodID,bankID=@BankID   where inhID=@inhID and bdgID=@bdgID and aptID=@aptID  and tenant = 1
					update COL_P set debit=debit-@Givencredit  where inhID=@inhID and bdgID=@bdgID and aptID=@aptID  and tenant = 1
					-- Καταχώρηση κίνησης είσπραξης
					INSERT INTO COL_D(colID,aptID,bdgid,inhid,debitusrID,Credit,debit,Bal,modifiedBy,modifiedOn,createdOn,tenant,Agreed,ComeFrom,BankFileName,BankDepositDate,ColBanksID )
					select @colIDTenant ,@aptID,@bdgid,@inhID, @debitusrID,@Givencredit,@DebitTenant,@Bal ,@modifiedBy,GETDATE() ,GETDATE(),1,@Agreed,@ComeFrom ,@BankFileName,@BankDepositDate,@ColBanksID
					set @Bal=0
				END
			END
			--Εαν έχει μηδενίσει το υπόλοιπο μόνο τότε πάμε στον ιδιοκτήτη. Σημαινει ότι υπάρχει κι άλλη πίστωση για να καλύψει την χρέωση
			if @TmpCredit > 0 AND @colIDOwner is not null
			begin
			--print'9'
				--Ότι μένει το ρίχνουμε στον Ιδιοκτήτη
				set @Bal  = ABS(@DebitOwner - @TmpCredit) 
				--update COL set completed=0,debitusrID=@debitusrID,dtCredit=CONVERT(date, GETDATE()),debit=@Bal,Credit=0  ,Bal=@Bal,ColMethodID=@ColMethodID where inhID=@inhID and bdgID=@bdgID and aptID=@aptID  and tenant = 0
				update COL set completed=0,debitusrID=@debitusrID,dtCredit=CONVERT(date, GETDATE()),Credit=0,Bal=@Bal,ColMethodID=@ColMethodID,bankID=@BankID  where inhID=@inhID and bdgID=@bdgID and aptID=@aptID  and tenant = 0
				update COL_P set debit=debit-@TmpCredit  where inhID=@inhID and bdgID=@bdgID and aptID=@aptID  and tenant = 0
				INSERT INTO COL_D(colID,aptID,bdgid,inhid,debitusrID,Credit,debit,Bal,modifiedBy,modifiedOn,createdOn,tenant,Agreed,ComeFrom,BankFileName,BankDepositDate,ColBanksID )
				select @colIDOwner ,@aptID,@bdgid,@inhID, @debitusrID,@TmpCredit,@DebitOwner,@Bal ,@modifiedBy,GETDATE() ,GETDATE(),0,@Agreed,@ComeFrom,@BankFileName,@BankDepositDate,@ColBanksID 
			end
		END
	
		--Εαν η πίστωση που έχει δώσει ο Χρήστης είναι μεγαλύτερη από το συνολικό ποσό χρέωσης 
		if @Givencredit > @TotalDebit 
		BEGIN
		--print'10'
			--Αφου καλύπτεται όλο το ποσό βάζουμε μηδεν καρφωτά στο υπόλοιπο και η πίστωση γίνεται ίδια με την χρέωση και για ένοικο και για ιδιοκτήτη
			--εδώ πλέον που κλείνει η είσπραξη βάζω και χρέωση και πίστωση το ποσό που έδωσε ο χρήστης απέξω
			update COL set completed=1,debitusrID=@debitusrID,dtCredit=CONVERT(date, GETDATE()),Credit=0,Bal=0,ColMethodID=@ColMethodID,bankID=@BankID  where inhID=@inhID   and bdgID=@bdgID and aptID=@aptID 

			-- Καταχώρηση κίνησης είσπραξης για ΙΔΙΟΚΤΗΤΗ
			if @colIDTenant is not null
			BEGIN
				-- Καταχώρηση κίνησης είσπραξης για ΕΝΟΙΚΟ
				INSERT INTO COL_D(colID,aptID,bdgid,inhid,debitusrID,Credit,debit,Bal,modifiedBy,modifiedOn,createdOn,tenant,Agreed,ComeFrom,BankFileName,BankDepositDate,ColBanksID  )
				select @colIDTenant ,@aptID,@bdgID,@inhID, @debitusrID,@DebitTenant,@DebitTenant,0 ,@modifiedBy,GETDATE() ,GETDATE(),1,@Agreed,@ComeFrom ,@BankFileName,@BankDepositDate,@ColBanksID

				update COL_P set debit=debit-@DebitTenant   where inhID=@inhID and bdgID=@bdgID and aptID=@aptID  and tenant = 1
			END
			--print  '@colIDTenant=' +  cast (@colIDTenant  as nvarchar(40))
			--print  '@colIDOwner=' +  cast (@colIDOwner  as nvarchar(40))
			-- Καταχώρηση κίνησης είσπραξης για ΙΔΙΟΚΤΗΤΗ
			if @colIDOwner is not null
			BEGIN
			--print'11'
				INSERT INTO COL_D(colID,aptID,bdgid,inhid,debitusrID,Credit,debit,Bal,modifiedBy,modifiedOn,createdOn,tenant,Agreed,ComeFrom ,BankFileName,BankDepositDate,ColBanksID )
				select @colIDOwner ,@aptID,@bdgID,@inhID, @debitusrID,@DebitOwner,@DebitOwner,0 ,@modifiedBy,GETDATE() ,GETDATE(),0,@Agreed,@ComeFrom ,@BankFileName,@BankDepositDate,@ColBanksID

				update COL_P set debit=debit-@DebitOwner   where inhID=@inhID and bdgID=@bdgID and aptID=@aptID  and tenant = 0
			END
		END
		-- Ότι απομένει το χρησιμοποιώ για το επόμενο παραστατικό. Εαν δεν έχει απομείνει φεύγω
		SET @Givencredit = @Givencredit  - ABS(@TotalDebit) 
		if @Givencredit <= 0 
		begin
		--print'12'

			CLOSE db_cursor  
			DEALLOCATE db_cursor 	  
			RETURN
		end

    FETCH NEXT FROM db_cursor INTO @fdate,@inhid 
	end
	CLOSE db_cursor  
	DEALLOCATE db_cursor 	  
	--Αυτή η περίπτωση υπάρχει μόνο αν δώσει μια πίστωση σε επίπεδο διαμερίσματος και καλύψει όλα τα παραστατικά και περισσέψουν και λεφτά
	IF @Givencredit >0
	BEGIN
	--print'13'
		
		INSERT INTO COL_D(colID,aptID,bdgid,inhid,debitusrID,Credit,debit,Bal,modifiedBy,modifiedOn,createdOn,Agreed,ComeFrom,BankFileName,BankDepositDate,ColBanksID )
		select @colIDTenant ,@aptID,@bdgID,NULL, @debitusrID,@Givencredit,0,@Givencredit*-1 ,@modifiedBy,GETDATE() ,GETDATE(),@Agreed,@ComeFrom ,@BankFileName,@BankDepositDate,@ColBanksID

	END
	


end
