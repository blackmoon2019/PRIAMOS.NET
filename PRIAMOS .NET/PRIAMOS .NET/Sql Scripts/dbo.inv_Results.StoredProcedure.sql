USE [Priamos_NET]
GO
/****** Object:  StoredProcedure [dbo].[inv_Results]    Script Date: 27/6/2023 8:52:42 πμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		John Mavroselinos
-- Create date: 14/06/2021
-- Description:	Αποτελέματα Παραστατικού
-- =============================================
CREATE PROCEDURE [dbo].[inv_Results]	(@inhid as uniqueidentifier	)	--ID Παραστατικού
	
AS
BEGIN

 DECLARE @cols AS NVARCHAR(MAX),
    @query  AS NVARCHAR(MAX)

	create table #Repnames	(ttl nvarchar(250))

		insert into #Repnames	
		SELECT DISTINCT ',' + QUOTENAME(repName) 
		from vw_INC 
		where inhID  =@inhid
		group by repName, id
		union
		SELECT DISTINCT ',' + QUOTENAME(repName + ' ΕΠΙΒ.') 
		from vw_INC 
		where inhID  =@inhid
		group by repName, id
		union
		SELECT DISTINCT ',' + QUOTENAME(repName + ' ΣΥΝΟΛΟ') 
		from vw_INC 
		where inhID  =@inhid
		group by repName, id
		select @cols = STUFF((select ttl from #Repnames	FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)')    ,1,1,'')
		SET @cols = @cols + ',[ΣΥΝΟΛΟ]'


/*
select @cols = STUFF((SELECT DISTINCT ',' + QUOTENAME(repName) 
                    from vw_INC 
					where inhID  =@inhid--'35652BC8-0B40-482D-8156-EF5B48E6BBCB'   
                    group by repName, id
	                  
            FOR XML PATH(''), TYPE
            ).value('.', 'NVARCHAR(MAX)') 
        ,1,1,'')
		--SET @cols = @cols + ',[ΣΥΝΟΛΟ]'
		SET @cols = @cols + ',[ΣΥΝΟΛΟ]'
*/
set @query = N'SELECT APTNAM AS ΔΙΑΜΕΡΙΣΜΑΤΑ, ' + @cols + N' from 
             (
                select aptNamTtl as APTNAM,ord,
				SUM(case when calcCatID  = ''C8ADCD0B-D8BC-4F68-B6BB-D5CBCB88B4B9'' THEN SHARED 
						 when calcCatID  = ''7FA0D7BA-2713-405C-8748-61DD8537A9CC'' THEN ELEVATOR
						 when calcCatID  = ''9C3F4423-6FB6-44FD-A3C0-64E5D609C2CB'' THEN BILLING
						 when calcCatID  = ''8D47E8AB-3692-48F1-8CBA-1E3F41AFC13D'' then HEATING 
						 when calcCatID  = ''BBFDA968-8C0C-431B-A804-AC8B8CA4B3D3'' then SPECIAL_COSTS
						 when calcCatID  = ''8D417A79-9757-4B18-8695-AE1BDF9416DD'' then GARAGE
						 when calcCatID  = ''E371555E-BB81-425B-9702-FB1EDE8DE73D'' then OWNERS
						 when calcCatID  = ''3FE81416-EF7C-4D3B-B1EA-E4CC40350FDE'' then MONOMERS1
						 when calcCatID  = ''EBD46C24-FBB0-47AD-A325-143C953A4AB4'' then MONOMERS2
						 when calcCatID  = ''2AE90BA0-DD3D-424D-9F6E-DA7A9A518620'' then MONOMERS3
						 when calcCatID  = ''B139CE26-1ABA-4680-A1EE-623EC97C475B'' then HEATING_CONSUMPTION
						 when calcCatID  = ''2A9470F9-CC5B-41F9-AE3B-D902FF1A2E72'' then BOILER_CONSUMPTION
				ELSE 0 END)
				AS AMOUNTS,[repName]
			
                from vw_INC 
				where inhID  =''' + CAST(@inhid AS NVARCHAR(MAX)) + '''
				GROUP BY aptNamTtl,[repName],ord

				UNION

               select aptNamTtl as APTNAM,ord,
				SUM(case when calcCatID  = ''C8ADCD0B-D8BC-4F68-B6BB-D5CBCB88B4B9'' THEN ep_shared  
						 when calcCatID  = ''7FA0D7BA-2713-405C-8748-61DD8537A9CC'' THEN ep_elevator 
						 when calcCatID  = ''9C3F4423-6FB6-44FD-A3C0-64E5D609C2CB'' THEN ep_billing 
						 when calcCatID  = ''8D47E8AB-3692-48F1-8CBA-1E3F41AFC13D'' then ep_heating  
						 when calcCatID  = ''BBFDA968-8C0C-431B-A804-AC8B8CA4B3D3'' then ep_special_costs 
						 when calcCatID  = ''8D417A79-9757-4B18-8695-AE1BDF9416DD'' then ep_garage 
						 when calcCatID  = ''E371555E-BB81-425B-9702-FB1EDE8DE73D'' then ep_owners 
						 when calcCatID  = ''3FE81416-EF7C-4D3B-B1EA-E4CC40350FDE'' then ep_monomers1 
						 when calcCatID  = ''EBD46C24-FBB0-47AD-A325-143C953A4AB4'' then ep_monomers2 
						 when calcCatID  = ''2AE90BA0-DD3D-424D-9F6E-DA7A9A518620'' then ep_monomers3 
						 when calcCatID  = ''B139CE26-1ABA-4680-A1EE-623EC97C475B'' then ep_heating_consumption 
						 when calcCatID  = ''2A9470F9-CC5B-41F9-AE3B-D902FF1A2E72'' then ep_boiler_consumption 
				ELSE 0 END)
				AS AMOUNTS,[repName] + '' ΕΠΙΒ.''
			
                from vw_INC 
				where inhID  =''' + CAST(@inhid AS NVARCHAR(MAX)) + '''
				GROUP BY aptNamTtl,[repName] + '' ΕΠΙΒ.'' ,ord
				
				UNION

               select aptNamTtl as APTNAM,ord,
				SUM(case when calcCatID  = ''C8ADCD0B-D8BC-4F68-B6BB-D5CBCB88B4B9'' THEN tot_shared  
						 when calcCatID  = ''7FA0D7BA-2713-405C-8748-61DD8537A9CC'' THEN tot_elevator 
						 when calcCatID  = ''9C3F4423-6FB6-44FD-A3C0-64E5D609C2CB'' THEN tot_billing 
						 when calcCatID  = ''8D47E8AB-3692-48F1-8CBA-1E3F41AFC13D'' then tot_heating  
						 when calcCatID  = ''BBFDA968-8C0C-431B-A804-AC8B8CA4B3D3'' then tot_special_costs 
						 when calcCatID  = ''8D417A79-9757-4B18-8695-AE1BDF9416DD'' then tot_garage 
						 when calcCatID  = ''E371555E-BB81-425B-9702-FB1EDE8DE73D'' then tot_owners 
						 when calcCatID  = ''3FE81416-EF7C-4D3B-B1EA-E4CC40350FDE'' then tot_monomers1 
						 when calcCatID  = ''EBD46C24-FBB0-47AD-A325-143C953A4AB4'' then tot_monomers2 
						 when calcCatID  = ''2AE90BA0-DD3D-424D-9F6E-DA7A9A518620'' then tot_monomers3 
						 when calcCatID  = ''B139CE26-1ABA-4680-A1EE-623EC97C475B'' then tot_heating_consumption 
						 when calcCatID  = ''2A9470F9-CC5B-41F9-AE3B-D902FF1A2E72'' then tot_boiler_consumption 
				ELSE 0 END)
				AS AMOUNTS,[repName] + '' ΣΥΝΟΛΟ''
			
                from vw_INC 
				where inhID  =''' + CAST(@inhid AS NVARCHAR(MAX)) + '''
				GROUP BY aptNamTtl,[repName] + '' ΣΥΝΟΛΟ'' ,ord

			 UNION

			select aptNamTtl as APTNAM,ord,
				SUM(SHARED + EP_SHARED ) + 
				SUM(ELEVATOR + EP_ELEVATOR) + 
				SUM(BILLING + EP_BILLING ) + 
				SUM(HEATING + EP_HEATING) + 
				SUM(SPECIAL_COSTS + EP_SPECIAL_COSTS) + 
				SUM(GARAGE + EP_GARAGE) +
				SUM(OWNERS + EP_OWNERS) + 
				SUM(MONOMERS1 + EP_MONOMERS1) + 
				SUM(MONOMERS2 + EP_MONOMERS2)  + 
				SUM(MONOMERS3 + EP_MONOMERS3)  + 
				SUM(HEATING_CONSUMPTION + EP_HEATING_CONSUMPTION ) + 
				SUM(BOILER_CONSUMPTION  + EP_BOILER_CONSUMPTION ) 
				AS AMOUNTS,''ΣΥΝΟΛΟ''
			
                from vw_INC 
				where inhID   =''' + CAST(@inhid AS NVARCHAR(MAX)) + '''
				GROUP BY aptNamTtl,ord
				 
            ) x
            pivot  ( SUM( AMOUNTS)  for repName in (' + @cols + N') ) p1
			order by ord
			'
			drop table #Repnames
PRINT @query
 exec sp_executesql @query;
 end
 


   
GO
