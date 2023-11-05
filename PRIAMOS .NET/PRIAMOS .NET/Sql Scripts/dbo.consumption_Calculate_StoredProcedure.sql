USE [Priamos_NET]
GO
/****** Object:  StoredProcedure [dbo].[consumption_Calculate]    Script Date: 5/11/2023 7:20:30 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		John Mavroselinos
-- Create date: 10/09/2023
-- Description:	Υπολογισμός Κατανάλωσης 
-- =============================================

ALTER PROCEDURE [dbo].[consumption_Calculate]	
			(@consumptionID as uniqueidentifier,	--ID Κατανάλωσης
			 @bdgID as uniqueidentifier,			--ID Πολυκατοικίας
			 @ahpbHID as uniqueidentifier,			--ID Header μετρήσεων ωρών
			 @ahpbHIDB as uniqueidentifier,			--ID Header μετρήσεων ωρών Boiler
			 @totConsumption decimal(18,2),			--Σύνολικό ποσό Κατανάλωσης
			 @totConsumptionLiter decimal(18,2),	--Σύνολικά λίτρα Κατανάλωσης
			 @createdBy as uniqueidentifier,		--Χρήστης Καταχώρησης
			 @MachineName nvarchar(200),			--Όνομα Μηχανήματος
			 @invGasID as uniqueidentifier			--ID Τιμολογίου Φυσικού αερίου
			 )
	
AS
BEGIN

declare @TotalMesHH INT --Σύνολο μέτρησης ωρών θέρμανσης
declare @TotalMesHB INT --Σύνολο μέτρησης ωρών Boiler
declare @calH INT --Θερμίδες Θέρμανσης Πολυκατοικίας
declare @calB INT --Θερμίδες Bolier Πολυκατοικίας
declare @CalHCons Integer --Κατανάλωση Θερμίδες Θέρμανσης
declare @CalBCons Integer --Κατανάλωση Θερμίδες Boiler
declare @CalTotalCons Integer --Σύνολο Κατανάλωσης Θερμίδων
declare @consumptionH float			--Ποσό Κατανάλωσης Θέρμανσης
declare @consumptionB float			--Ποσό Κατανάλωσης Boiler
declare @consumptionLiterH float	--Λίτρα Κατανάλωσης Θέρμανσης
declare @consumptionLiterB float	--Λίτρα Κατανάλωσης Boiler


SELECT  @TotalMesHH  = 0, @calH = 0, @TotalMesHB = 0, @calB = 0

--Θέρμανση
SELECT @TotalMesHH = isnull(totalBdgMesDif,0) ,@calH = isnull(calH,0)
FROM   AHPB_H 
INNER JOIN BDG ON BDG.ID = AHPB_H.bdgID
WHERE BDG.ID = @bdgID and AHPB_H.id =@ahpbHID 

--Boiler
SELECT @TotalMesHB = isnull(totalBdgMesDif,0) ,@calB = isnull(calB,0)
FROM   AHPB_H 
INNER JOIN BDG ON BDG.ID = AHPB_H.bdgID
WHERE BDG.ID = @bdgID and AHPB_H.id =@ahpbHIDB 

--Κατανάλωση Θερμίδων Θέρμανσης/Boiler
SELECT @CalHCons = @TotalMesHH  * @calH ,@CalBCons  = @TotalMesHB  * @calB

--Σύολο Κατανάλωσης Θερμίδων Θέρμανσης + Boiler 
SET @CalTotalCons = @CalHCons + @CalBCons  
 
if @CalTotalCons = 0 RAISERROR ('Το σύνολο θερμίδων κατανάλωσης δεν μπορεί να είναι μηδέν(0).', 16, 1)

-- Ποσό Κατανάλωσης Θέρμανσης
SET @consumptionH = @totConsumption / @CalTotalCons
SET @consumptionH = @consumptionH * @CalHCons
-- Ποσό Κατανάλωσης Boiler
SET @consumptionB = @totConsumption / @CalTotalCons
SET @consumptionB = @consumptionB * @CalBCons

-- Λίτρα Κατανάλωσης Θέρμανσης
SET @consumptionLiterH = @totConsumptionLiter / @CalTotalCons
SET @consumptionLiterH = @consumptionLiterH * @CalHCons
-- Λίτρα Κατανάλωσης Boiler
SET @consumptionLiterB = @totConsumptionLiter / @CalTotalCons
SET @consumptionLiterB = @consumptionLiterB * @CalBCons



-- Καταχώρηση εγγραφής στις καταναλώσεις
INSERT INTO CONSUMPTIONS 
([ID], [bdgID],[invGasID],  [ahpbHIDH], [ahpbHIDB], [calH], [calB], [totalCal], [consumptionH], [consumptionB], [totConsumption], [consumptionLiterH], [consumptionLiterB], [totConsumptionLiter], [createdOn], [createdBy],[modifiedBy], [MachineName])
SELECT @consumptionID ,@bdgID,@invGasID ,@ahpbHID,@ahpbHIDB,@CalHCons,@CalBCons,@CalTotalCons ,@consumptionH,@consumptionB,@totConsumption,@consumptionLiterH,@consumptionLiterB,@totConsumptionLiter ,GETDATE(),@createdBy,@createdBy,@MachineName  

end