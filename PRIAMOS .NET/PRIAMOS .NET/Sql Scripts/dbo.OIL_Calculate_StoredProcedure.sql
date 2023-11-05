USE [Priamos_NET]
GO
/****** Object:  StoredProcedure [dbo].[OIL_Calculate]    Script Date: 5/11/2023 7:23:10 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		John Mavroselinos
-- Create date: 09/09/2023
-- Description:	Υπολογισμός Πετρελαίου
-- =============================================

ALTER   PROCEDURE [dbo].[OIL_Calculate]	
			(@consumptionID as uniqueidentifier,
			@dtMeasurement as DateTime,
			@bdgID as uniqueidentifier,@createdBy as uniqueidentifier,
			@MachineName nvarchar(200),@totConsumptionH decimal(18,2) OUTPUT,@totConsumptionLitersH decimal(18,2) OUTPUT
			)
	
AS
BEGIN
 DECLARE @MeasurementLiters decimal(10,2),@unchargedLiters decimal(10,2),@invOilID uniqueidentifier,@Price decimal(18, 5)
 DECLARE @ConsumptionH decimal(18,2),@tankID as uniqueidentifier,@TotalUnchargedLiters decimal(10,2)

 BEGIN TRY
    BEGIN TRANSACTION

	SET @totConsumptionH = 0
	set @MeasurementLiters =0
	set @unchargedLiters = 0
	set @Price = 0
	set  @ConsumptionH=0
	set @TotalUnchargedLiters=0

 --Παίρνουμε πρώτα τα λίτρα που έγινε η "Μέτρηση Μήνα(measurementcatID='0933F647-2FC7-43FD-A00E-5F9939AFC6E2')" σύμφωνα με την ημερομηνία μέτρησης @dtMeasurement
 select @MeasurementLiters = isnull(liters,0),@tankID = ID from TANK where bdgID=@bdgID and dtMeasurement =@dtMeasurement and measurementcatID='0933F647-2FC7-43FD-A00E-5F9939AFC6E2'
 
 --Παίρνουμε το σύνολο των λιτρών από τα ανολοκλήρωτα παραστατικά μέχρι και την ημερομηνία μέτρησης
 select @TotalUnchargedLiters=SUM(isnull(unchargedLiters,0)) 
 from INV_OIL 
 INNER JOIN INV_OILP ON INV_OILP.invOilID =INV_OIL.ID 
 where completed = 0 and INV_OIL.bdgID = @bdgID and invDate <=@dtMeasurement 

 SET @MeasurementLiters = @TotalUnchargedLiters -  @MeasurementLiters 

 -- Λίτρα που έκαψε η πολυκατοικία
 SET @totConsumptionLitersH =  @MeasurementLiters 

 -- Εαν δεν βρεθεί εγγραφή στην δεξαμενή δεν προχωράει η διαδικασία
 if @tankID is null RAISERROR ('Δεν βρέθηκε εγγραφή μέτρησης μήνα για την δεξαμενή', 16, 1)

 DECLARE db_cursor CURSOR FOR 
		select INV_OIL.ID, isnull(unchargedLiters,0) AS unchargedLiters ,ISNULL(price,0) AS price
		from INV_OIL 
		INNER JOIN INV_OILP ON INV_OILP.invOilID =INV_OIL.ID 
		where completed = 0 and INV_OIL.bdgID = @bdgID and @dtMeasurement<=@dtMeasurement  
		order by invDate asc
 OPEN db_cursor  
 FETCH NEXT FROM db_cursor INTO @invOilID,@unchargedLiters,@Price
 WHILE @@FETCH_STATUS = 0  
 BEGIN  

	
	--Εαν τα λίτρα που μετρήθηκαν είναι ίσα ή παραπάνω από τα λίτρα του τιμολογίου αγοράς τότε:
	--1. Καταχωρείται κίνηση χρέωσης για το συγκεκριμένο παραστατικό
	--2. Eνημερώνεται το παραστατικό ως ολοκληρωμένο
	--3. Πάιρνουμε την τιμή λίτρου και βγάζουμε την κατανάλωση βάση του συγκεκριμένου παραστατικού
	--4. Ενημερώνουμε τον πίνακα με τα συνολικά αχρέωτα λίτρα που απομένουν
	if @MeasurementLiters>=@unchargedLiters
	BEGIN
		
		--Eνημερώνεται το παραστατικό ως ολοκληρωμένο
		UPDATE INV_OIL SET completed=1 WHERE ID=@invOilID 
		
		--Eνημερώνεται ο πίνακας με τα αχρέωτα λίτρα με μηδέν
		UPDATE INV_OILP SET unchargedLiters = 0 WHERE invOilID =@invOilID 

		--Ποσό κατανάλωσης από το συγκεκριμένο τιμολόγιο
		SET @ConsumptionH = @unchargedLiters * @Price 
		
		--Συνολικό Ποσό κατανάλωσης 
		SET @totConsumptionH = @totConsumptionH + @ConsumptionH
		
		--Λίτρα που απομένουν για χρέωση
		SET @MeasurementLiters = @MeasurementLiters - @unchargedLiters

		--Καταχωρείται κίνηση χρέωσης για το συγκεκριμένο παραστατικό
		INSERT INTO INV_OILD([ID], [invOilID], [consumptionID], [tankID], [liters],[ConsumptionH],[createdOn], [createdBy], [MachineName]) 
		select NEWID(),@invOilID,@consumptionID ,@tankID,@unchargedLiters,@ConsumptionH,GETDATE(),@createdBy,@MachineName 
	END
	ELSE
	BEGIN
 
 
		--Eνημερώνεται ο πίνακας με τα αχρέωτα λίτρα που απομένουν
		UPDATE INV_OILP SET unchargedLiters = @unchargedLiters - @MeasurementLiters WHERE invOilID =@invOilID 

		--Ποσό κατανάλωσης από το συγκεκριμένο τιμολόγιο
		SET @ConsumptionH = @MeasurementLiters  * @Price 
		
		--Συνολικό Ποσό κατανάλωσης 
		SET @totConsumptionH = @totConsumptionH + @ConsumptionH
		
		--Καταχωρείται κίνηση χρέωσης για το συγκεκριμένο παραστατικό
		INSERT INTO INV_OILD([ID], [invOilID], [consumptionID], [tankID], [liters],[ConsumptionH],  [createdOn], [createdBy], [MachineName]) 
		select NEWID(),@invOilID,@consumptionID ,@tankID,  @MeasurementLiters,@ConsumptionH, GETDATE(),@createdBy,@MachineName 
		BREAK

	END
	 FETCH NEXT FROM db_cursor INTO @invOilID,@unchargedLiters,@Price


 END
 CLOSE db_cursor  
 DEALLOCATE db_cursor 	  

-- Ενημέρωση αχρέωτου ποσού πετρελαίου δεξαμενής 
EXEC CalculateUnchargableOil @bdgID
	
-- Ενημέρωση Εγγραφής ότι υπλογίστηκε
UPDATE TANK SET calculated = 1 where ID = @tankID 
-- Συνολικό Ποσό Κατανάλωσης, Συνολικά Λίτρα Κατανάλωσης
select @totConsumptionH = ISNULL(@totConsumptionH,0),@totConsumptionLitersH = ISNULL(@totConsumptionLitersH,0)

 COMMIT TRAN -- Transaction Success!
  	
 END TRY
 BEGIN CATCH
    IF @@TRANCOUNT > 0 
 	
	ROLLBACK TRAN --RollBack in case of Error

    DECLARE @ErrorMessage NVARCHAR(4000);  
    DECLARE @ErrorSeverity INT;  
    DECLARE @ErrorState INT;  

    SELECT   
       @ErrorMessage = ERROR_MESSAGE(),  
       @ErrorSeverity = ERROR_SEVERITY(),  
       @ErrorState = ERROR_STATE();  

    RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);  

END CATCH

end