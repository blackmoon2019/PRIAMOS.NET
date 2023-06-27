USE [Priamos_NET]
GO
/****** Object:  StoredProcedure [dbo].[RepClosed]    Script Date: 27/6/2023 8:52:42 πμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RepClosed]	(@inhid as uniqueidentifier)			--ID Παραστατικού
	
AS
BEGIN

Declare @Category nvarchar(150),@ttl nvarchar(20),@percent nvarchar(4)
Declare @TmpCategory nvarchar(150),@Row nvarchar(max)

set @TmpCategory =''
set @Row =''

--Διαγραφή πίνακα γιαυτό το παραστατικό
DELETE FROM RCA WHERE inhID=@inhid 

DECLARE closed_cursor CURSOR FOR   

select   
case when calcCatID  = '7FA0D7BA-2713-405C-8748-61DD8537A9CC' then 'ΑΝΕΛΚΥΣΤΗΡΑ'
	 when calcCatID  = 'C8ADCD0B-D8BC-4F68-B6BB-D5CBCB88B4B9' then 'ΚΟΙΝΟΧΡΗΣΤΩΝ'
	 when calcCatID  = '8D47E8AB-3692-48F1-8CBA-1E3F41AFC13D' then 'ΘΕΡΜΑΝΣΕΩΣ'
	 when calcCatID  = 'BBFDA968-8C0C-431B-A804-AC8B8CA4B3D3' then 'ΕΙΔΙΚΕΣ ΔΑΠΑΝΕΣ'
	 when calcCatID  =  'E371555E-BB81-425B-9702-FB1EDE8DE73D'then 'ΙΔΙΟΚΤΗΤΩΝ'
	 when calcCatID  = '9C3F4423-6FB6-44FD-A3C0-64E5D609C2CB' then 'ΕΚΔΟΣΗ'
	 when calcCatID  =  '8D417A79-9757-4B18-8695-AE1BDF9416DD'then 'ΘΕΣΕΙΣ ΓΚΑΡΑΖ'
	 when calcCatID  = '3FE81416-EF7C-4D3B-B1EA-E4CC40350FDE' then 'ΜΟΝΟΜΕΡΗ 1'
	 when calcCatID  = 'EBD46C24-FBB0-47AD-A325-143C953A4AB4' then 'ΜΟΝΟΜΕΡΗ 2'
	 when calcCatID  =  '2AE90BA0-DD3D-424D-9F6E-DA7A9A518620'then 'ΜΟΝΟΜΕΡΗ 3'
	 when calcCatID  =  'B139CE26-1ABA-4680-A1EE-623EC97C475B'then 'ΚΑΤ/ΣΗ ΘΕΡΜΑΝΣΗΣ'
	 when calcCatID  =  '2A9470F9-CC5B-41F9-AE3B-D902FF1A2E72'then 'ΚΑΤ/ΣΗ BOILER' 
	 else '' end as Category,ttl,closed
from (
SELECT DISTINCT apt.ttl,calcCatID,
/*ΑΝΕΛΚΥΣΤΗΡΑ*/	case when calcCatID  = '7FA0D7BA-2713-405C-8748-61DD8537A9CC' AND APMIL.c_elevator <100 AND APMIL.c_elevator >=0 then 100-APMIL.c_elevator 
/*ΚΟΙΝΟΧΡΗΣΤΩΝ*/		 when calcCatID  = 'C8ADCD0B-D8BC-4F68-B6BB-D5CBCB88B4B9' AND APMIL.c_SHARED <100 AND APMIL.c_SHARED >=0 then 100-APMIL.c_SHARED 
/*ΘΕΡΜΑΝΣΕΩΣ*/	         when calcCatID  = '8D47E8AB-3692-48F1-8CBA-1E3F41AFC13D' AND APMIL.c_heating  <100 AND APMIL.c_heating  >=0 then 100-APMIL.c_heating 
/*ΕΙΔΙΚΕΣ ΔΑΠΑΝΕΣ*/		 when calcCatID  = 'BBFDA968-8C0C-431B-A804-AC8B8CA4B3D3' AND APMIL.c_special_costs  <100 AND APMIL.c_special_costs  >=0  then 100-APMIL.c_special_costs 
/*ΙΔΙΟΚΤΗΤΩΝ*/			 when calcCatID  =  'E371555E-BB81-425B-9702-FB1EDE8DE73D' AND APMIL.c_owners  <100 AND APMIL.c_owners  >=0 then    100-APMIL.c_owners  
/*ΕΚΔΟΣΗ*/				 when calcCatID  = '9C3F4423-6FB6-44FD-A3C0-64E5D609C2CB' AND APMIL.c_billing  <100 AND APMIL.c_billing  >=0 then    100-APMIL.c_billing 
/*ΘΕΣΕΙΣ ΓΚΑΡΑΖ*/		 when calcCatID  =  '8D417A79-9757-4B18-8695-AE1BDF9416DD' AND APMIL.c_garage  <100 AND APMIL.c_garage  >=0 then    100-APMIL.c_garage   
/*ΜΟΝΟΜΕΡΗ 1*/			 when calcCatID  = '3FE81416-EF7C-4D3B-B1EA-E4CC40350FDE' AND APMIL.c_monomers1  <100 AND APMIL.c_monomers1 >=0 then  100-APMIL.c_monomers1    
/*ΜΟΝΟΜΕΡΗ 2*/			 when calcCatID  = 'EBD46C24-FBB0-47AD-A325-143C953A4AB4' AND APMIL.c_monomers2  <100 AND APMIL.c_monomers2 >=0 then  100-APMIL.c_monomers2    
/*ΜΟΝΟΜΕΡΗ 3*/			 when calcCatID  =  '2AE90BA0-DD3D-424D-9F6E-DA7A9A518620' AND APMIL.c_monomers3  <100 AND APMIL.c_monomers3 >=0  then 100-APMIL.c_monomers3   
/*ΚΑΤ/ΣΗ ΘΕΡΜΑΝΣΗΣ*/	 when calcCatID  =  'B139CE26-1ABA-4680-A1EE-623EC97C475B' AND APMIL.c_heating_consumption  <100 AND APMIL.c_heating_consumption >=0 then 100-APMIL.c_heating_consumption    
/*ΚΑΤ/ΣΗ BOILER*/		 when calcCatID  =  '2A9470F9-CC5B-41F9-AE3B-D902FF1A2E72' AND APMIL.c_boiler_consumption  <100 AND APMIL.c_boiler_consumption >=0 then 100-APMIL.c_boiler_consumption     else 0 end as Closed
  FROM INC  
	inner join IND on IND.inhID = INC.inhID and inc.indID=ind.id
	inner join CALC_CAT  on CALC_CAT.ID  = IND.calcCatID 
	inner join APT on APT.id=aptID_closed 
	inner join APMIL  on APMIL.aptID  = APT.ID
 WHERE inc.INHID=@inhid
  ) as c
 where c.Closed>0
 ORDER BY Category 

OPEN closed_cursor 
  
FETCH NEXT FROM closed_cursor 
INTO @Category ,@ttl ,@percent 
  
WHILE @@FETCH_STATUS = 0  
BEGIN    
	if @TmpCategory = @Category 
	begin
		set @Row = @Row + ',' + @ttl + ',' + @percent + '%'
	end
	else
	begin
		if @TmpCategory = ''
		begin
			set @Row = @Category + '--> ' + @ttl + ',' + @percent + '%'
			set @TmpCategory = @Category 
		end
		else
		begin
			insert into RCA(inhID,Closed)
			select @inhid ,@Row
			set @Row = ''
			set @TmpCategory =''
			set @Row = @Category + '--> ' + @ttl + ',' + @percent + '%'
			set @TmpCategory = @Category 
		end
	end

  FETCH NEXT FROM closed_cursor   
    INTO @Category ,@ttl ,@percent 
END   
CLOSE closed_cursor ;  
DEALLOCATE closed_cursor; 

--Αφορά πάντα την τελευτάια γραμμή
if LEN(@row)>0
insert into RCA(inhID,Closed)
select @inhid ,@Row

end
GO
