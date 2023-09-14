USE [Priamos_NET]
GO
/****** Object:  StoredProcedure [dbo].[inv_SharingDifferences]    Script Date: 27/6/2023 8:52:42 πμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		John Mavroselinos
-- Create date: 22/06/2023
-- Description:	Καταμέρισμός Διαφορών Υπολογισμένων Εξόδων
-- =============================================

CREATE     PROCEDURE [dbo].[inv_SharingDifferences]	
			(@inhID as uniqueidentifier)
	
AS
BEGIN
 SET NOCOUNT ON;
BEGIN TRAN
BEGIN TRY
    
	

DECLARE @Dif decimal(9,2)
DECLARE @CountApt INT
DECLARE @repname nvarchar(200)
Declare @amt decimal(9,2)
Declare @amtpercalc decimal(9,2)
Declare @calcCatID uniqueidentifier
Declare @indID uniqueidentifier
Declare @bdgID uniqueidentifier
Declare @query  AS NVARCHAR(MAX)
Declare @Field  AS NVARCHAR(100)
Declare @TotField  AS NVARCHAR(100)

	DECLARE db_INH_CURSOR CURSOR FOR 
		
		 select repname,bdgID,calcCatID ,indID ,amt,sum(amtpercalc) as amtpercalc,(amt - sum(amtpercalc))   as Dif,
		 ABS(cast((amt - sum(amtpercalc)  )  * 100 as int)) as CountApt
		 from vw_inc 
		 where vw_inc.inhID=@inhID
		 group by repName,amt, calcCatID,indID,bdgID
		 having amt<>sum(amtpercalc) 

	OPEN db_INH_CURSOR
	FETCH NEXT FROM db_INH_CURSOR INTO @repname,@bdgID,@calcCatID ,@indID ,@amt,@amtpercalc ,@Dif,@CountApt
	WHILE @@FETCH_STATUS = 0  
	BEGIN  
			  if @calcCatID  = 'C8ADCD0B-D8BC-4F68-B6BB-D5CBCB88B4B9' SELECT @field='SHARED',@TotField				= 'TOT_SHARED'
			  if @calcCatID  = '7FA0D7BA-2713-405C-8748-61DD8537A9CC' SELECT @field='ELEVATOR',@TotField			= 'TOT_ELEVATOR'
			  if @calcCatID  = '9C3F4423-6FB6-44FD-A3C0-64E5D609C2CB' SELECT @field='BILLING',@TotField				= 'TOT_BILLING'
			  if @calcCatID  = '8D47E8AB-3692-48F1-8CBA-1E3F41AFC13D' SELECT @field='HEATING',@TotField				= 'TOT_HEATING'
			  if @calcCatID  = 'BBFDA968-8C0C-431B-A804-AC8B8CA4B3D3' SELECT @field='SPECIAL_COSTS',@TotField		= 'TOT_SPECIAL_COSTS'
			  if @calcCatID  = '8D417A79-9757-4B18-8695-AE1BDF9416DD' SELECT @field='GARAGE',@TotField				= 'TOT_GARAGE'
			  if @calcCatID  = 'E371555E-BB81-425B-9702-FB1EDE8DE73D' SELECT @field='OWNERS',@TotField				= 'TOT_OWNERS'
			  if @calcCatID  = '3FE81416-EF7C-4D3B-B1EA-E4CC40350FDE' SELECT @field='MONOMERS1',@TotField			= 'TOT_MONOMERS1'
			  if @calcCatID  = 'EBD46C24-FBB0-47AD-A325-143C953A4AB4' SELECT @field='MONOMERS2',@TotField			= 'TOT_MONOMERS2'
			  if @calcCatID  = '2AE90BA0-DD3D-424D-9F6E-DA7A9A518620' SELECT @field='MONOMERS3',@TotField			= 'TOT_MONOMERS3'
			  if @calcCatID  = 'B139CE26-1ABA-4680-A1EE-623EC97C475B' SELECT @field='HEATING_CONSUMPTION',@TotField = 'TOT_HEATING_CONSUMPTION'
			  if @calcCatID  = '2A9470F9-CC5B-41F9-AE3B-D902FF1A2E72' SELECT @field='BOILER_CONSUMPTION',@TotField	= 'TOT_BOILER_CONSUMPTION'


			if @Dif < 0 
			BEGIN
			set @query = N'UPDATE INC SET ' + @field + ' = ' + @field + ' - 0.01, ' + @totfield + ' = ' + @Totfield + ' - 0.01 
						FROM (SELECT TOP ' + cast(@CountApt as nvarchar(4)) + ' ID FROM INC  where  inhID  =''' + CAST(@inhid AS NVARCHAR(MAX)) + ''' and indid=''' + CAST(@indid AS NVARCHAR(MAX)) + ''' and ' + @field + '<>0 ) AS a
						WHERE INC.ID = a.ID AND indid=''' + CAST(@indid AS NVARCHAR(MAX)) + ''''
						--PRINT @query 
						EXEC ( @query )
			END
			ELSE 
			BEGIN
			set @query = N'UPDATE INC SET ' + @field + ' = ' + @field + ' + 0.01, ' + @totfield + ' = ' + @Totfield + ' + 0.01 
						FROM (SELECT TOP ' + cast(@CountApt as nvarchar(4)) + ' ID FROM INC  where  inhID  =''' + CAST(@inhid AS NVARCHAR(MAX)) + ''' and indid=''' + CAST(@indid AS NVARCHAR(MAX)) + ''' and ' + @field + '<>0 ) AS a
						WHERE INC.ID = a.ID AND indid=''' + CAST(@indid AS NVARCHAR(MAX)) + ''''
						--PRINT @query  
						EXEC (@query )
			END



	FETCH NEXT FROM db_INH_CURSOR INTO @repname,@bdgID,@calcCatID ,@indID ,@amt,@amtpercalc ,@Dif,@CountApt
	end
	CLOSE db_INH_CURSOR
	DEALLOCATE db_INH_CURSOR



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
