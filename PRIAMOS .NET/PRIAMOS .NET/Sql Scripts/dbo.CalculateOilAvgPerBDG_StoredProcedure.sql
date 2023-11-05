USE [Priamos_NET]
GO
/****** Object:  StoredProcedure [dbo].[CalculateOilAvgPerBDG]    Script Date: 5/11/2023 7:18:02 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		John Mavroselinos
-- Create date: 05/11/2023
-- Description:	Υπολογίζει την πρόβλεψη πετρελάιου ανα πολυκατοικία
-- =============================================
ALTER PROCEDURE [dbo].[CalculateOilAvgPerBDG]	

	
AS
BEGIN
SET NOCOUNT ON;
Declare @dtmeasurement as datetime
Declare @bdgid as uniqueidentifier				
Declare @tankID as uniqueidentifier				

	
	DECLARE db_OIL_CURSOR CURSOR FOR 
		
			select MAX(dtmeasurement),bdgid 
			from TANK 
			group by bdgid		

	OPEN db_OIL_CURSOR 
	FETCH NEXT FROM db_OIL_CURSOR INTO  @dtmeasurement,@bdgid 
	WHILE @@FETCH_STATUS = 0  
	BEGIN  

		select top 1 @tankID = ID from  TANK  where BDGid=@bdgid  and dtMeasurement=@dtmeasurement 

		exec [CalculateOilAvg] @bdgid,@tankid 

	FETCH NEXT FROM db_OIL_CURSOR  INTO @dtmeasurement,@bdgid 
	end
	CLOSE db_OIL_CURSOR 
	DEALLOCATE db_OIL_CURSOR 


END

