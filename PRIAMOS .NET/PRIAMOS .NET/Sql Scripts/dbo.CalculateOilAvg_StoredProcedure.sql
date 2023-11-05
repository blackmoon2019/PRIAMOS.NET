USE [Priamos_NET]
GO
/****** Object:  StoredProcedure [dbo].[CalculateOilAvg]    Script Date: 5/11/2023 7:17:21 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		John Mavroselinos
-- Create date: 10/10/2023
-- Description:	Υπολογίζει την πρόβλεψη πετρελάιου
-- =============================================
ALTER     PROCEDURE [dbo].[CalculateOilAvg]	(
	@bdgID as uniqueidentifier,				--ID Πολυκατοικίας
	@tankID as uniqueidentifier				--ID Δεξαμενής
										)			
	
AS
BEGIN

Declare @CurrentDate Datetime,@PrevDate  Datetime,@mesCurrentPrev decimal (18,3),@mesCurr decimal (18,3),@mesbCurr decimal (18,3),@lpcH AS DECIMAL (5,2),@RemaininglpcH AS DECIMAL (8,3),
@mesTotalL decimal (18,3),@DateDiff as int,@mesbPrev decimal (18,3),@mesTotalP decimal (18,3),@MeasurementCatID uniqueidentifier,@prevision decimal(5,2),@extraCostH int,@RemainingDays int,
@PreviousID uniqueidentifier

SET @prevision = 0


if (select COUNT(ID) from TANK where ID=@tankID) = 0 
begin
	select top 1 @tankID = ID FRom TANK where bdgid=@bdgID order by dtMeasurement desc
end
--Current Record
select @MeasurementCatID =measurementcatID ,@lpcH=ISNULL(lpcH,0),@mesCurr = ISNULL(mes,0),@mesbCurr= ISNULL(mesb,0),@CurrentDate = dtMeasurement,@prevision  =B.prevision ,@extraCostH=extraCostH
from TANK T
INNER JOIN BDG B ON B.ID = T.bdgID 
where T.ID=@tankID  

--Previous Record
select top 1 @mesCurrentPrev=ISNULL(mes,0),@mesbPrev= ISNULL(mesb,0),@PrevDate  =dtMeasurement ,@PreviousID = ID 
from TANK 
where bdgID=@bdgID  and dtMeasurement < @CurrentDate order by dtMeasurement  desc

SET @DateDiff = 0
IF @prevision <> 0 SET @prevision = @prevision / 100 

select @DateDiff = DATEDIFF(day, @PrevDate, @CurrentDate )
print @DateDiff 
--if @DateDiff <= 120 
--begin
print 'Calculate Start'
--Κατανάλωση ανα ημέρα Λίτρα / Ποντοι
SET @mesTotalL = 0
SET @mesTotalP = 0

 if @mesCurrentPrev <> 0 
	begin
		set @mesTotalL = ((@mesCurrentPrev - case when @MeasurementCatID = '0C5AC8B9-41E1-4DAC-AC44-A05DFD4A9D1A' then @mesbCurr else @mesCurr end ) / @DateDiff ) * @lpcH 
		set @mesTotalP = ((@mesCurrentPrev - case when @MeasurementCatID = '0C5AC8B9-41E1-4DAC-AC44-A05DFD4A9D1A' then @mesbCurr else @mesCurr end  ) / @DateDiff ) 
	end
	else
	begin
		set @mesTotalL = ((@mesbPrev - case when @MeasurementCatID = '0C5AC8B9-41E1-4DAC-AC44-A05DFD4A9D1A' then @mesbCurr else @mesCurr end ) / @DateDiff ) * @lpcH 
		set @mesTotalP = ((@mesbPrev - case when @MeasurementCatID = '0C5AC8B9-41E1-4DAC-AC44-A05DFD4A9D1A' then @mesbCurr else @mesCurr end ) / @DateDiff ) 
	end
 

 if @DateDiff <= 120  
	begin
		update TANK SET litersPerDay  = @mesTotalL,lphPerDay = @mesTotalP  WHERE ID =@tankID
	end
	else
	begin
		update TANK set lphPerDay=0,litersPerDay=0 where ID=@tankID 
	end
 

 Declare @TlitersPerDay decimal (18,3),@ClitersPerDay int, @TotlitersPerDay decimal (18,3)
 Declare @TlphPerDay decimal (18,3),@ClphPerDay int, @TotlphPerDay decimal (18,3)
 
SET @TotlphPerDay = 0
SET @ClitersPerDay  = 0
SET @TlitersPerDay  = 0
SET @TotlitersPerDay = 0
set @RemaininglpcH = 0

 select @TlitersPerDay = SUM(litersPerDay),@TlphPerDay=SUM(lphPerDay) from TANK  where bdgID = @bdgID
 select @ClitersPerDay = count(litersPerDay),@ClphPerDay = count(lphPerDay)  from TANK  where bdgID = @bdgID   and litersPerDay<>0
 
 
 IF @ClitersPerDay  <> 0 
BEGIN
	set @TotlitersPerDay = @TlitersPerDay  / @ClitersPerDay 
	set @TotlitersPerDay = @TotlitersPerDay  * @prevision
	select @TotlitersPerDay  = (select SUM(case when litersPerDay > @TotlitersPerDay  then litersPerDay  else 0 end) from TANK  where bdgID = @bdgID) / 
							(select sum (case when litersPerDay > @TotlitersPerDay  then 1 else 0 end) from TANK  where bdgID = @bdgID)
END
 
 
 IF @ClphPerDay   <> 0 
 BEGIN
	 set @TotlphPerDay = @TlphPerDay  / @ClphPerDay 
	 set @TotlphPerDay = @TotlphPerDay  * @prevision
	 select @TotlphPerDay   = (select SUM(case when lphPerDay > @TotlphPerDay  then lphPerDay  else 0 end) from TANK  where bdgID = @bdgID) / 
							  (select sum (case when lphPerDay > @TotlphPerDay  then 1 else 0 end) from TANK  where bdgID = @bdgID)
END

 
 IF @TotlphPerDay <> 0 
 BEGIN
 
	 set @RemaininglpcH = ISNULL(@mesCurr,0) - ISNULL(@extraCostH ,0)
	 set @RemainingDays = convert (int,ISNULL(@RemaininglpcH,0) / ISNULL(@TotlphPerDay,0)   )
	 
	 if (DATEDIFF(day,  GETDATE(),@CurrentDate) )<=0
	 begin
		SELECT @RemainingDays = DATEDIFF(day,  GETDATE(),@CurrentDate) + (@RemainingDays) ; 
     end
	 else
	 begin
		SELECT @RemainingDays = DATEDIFF(day,  GETDATE(),@CurrentDate) - (@RemainingDays) ; 
	 end
 END
	update BDG SET remainingDays=@RemainingDays, avgLpc=@TotlphPerDay,avgLiters=@TotlitersPerDay WHERE ID=@bdgID 
 end 
 --else
 --begin
	--update TANK set lphPerDay=0,litersPerDay=0 where ID=@tankID 
 --end
--END
 
 