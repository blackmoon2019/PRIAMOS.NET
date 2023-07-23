USE [Priamos_NET]
GO
/****** Object:  StoredProcedure [dbo].[batch_create_inv]    Script Date: 27/6/2023 8:52:42 πμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
 -- =============================================
-- Author:		<John Mavroselinos>
-- Create date: <17/08/2022>
-- Description:	<Μαζική καταχώρηση παραστατικών>
-- =============================================
CREATE procEDURE [dbo].[batch_create_inv] ( @fdate datetime,@tdate datetime,@completeDate nvarchar(150),@Months int,@modifiedby uniqueidentifier) as
begin
	
	
	--Καταχωρώ σε εναν προσωρινό πίνακα όλα τα ID των παραστατικών
	select newid() as inhID,id as bdgID, @fdate as fdate ,@tdate as tdate,0 as calculated,@completeDate as completeDate  ,
			@modifiedBy as modifiedBy , GETDATE()  as createdOn  
	into #B
	from BDG where isManaged  = 1  
	--and id not in (select bdgid from inh where fdate=@fdate and tdate = @tdate and reserveAPT=0 )
	and id not in (select bdgid from inh where @fdate   between fdate and tdate   and reserveAPT=0)

	--Καταχώρηση Παραστατικών
	insert INH (ID,bdgid, fdate,tDate,Calculated,completeDate,modifiedBy,createdOn   )
	select inhID,bdgID,fdate,tDate,Calculated,completeDate,modifiedBy,createdOn   
	from #B
	--where bdgID not in (select bdgid from inh where fdate=@fdate and tdate = @tdate and reserveAPT=0)
	where bdgID not in (select bdgid from inh where  @fdate   between fdate and tdate   and reserveAPT=0)
	

	
	--Καταχώρηση εξόδων Παραστατικών
	INSERT INTO IND (inhID, calcCatID, repName, amt, owner_tenant) 
    Select inhID,calcCatID,repName,
	case when calcCatID = '9C3F4423-6FB6-44FD-A3C0-64E5D609C2CB' then amt 
		 when aptID is not null then (select sum(AmtPerCalc)  from vw_inc where inhid = (select top 1 ID from INH (nolock) where bdgid = vw_inc.bdgID  and extraordinary=0 and Calorimetric=0 and reserveAPT=0 and fdate<  @fdate   order by fDate desc) and aptID=IEP.aptID  )
		 else amt *  @Months  end as amt ,	owner_tenant 
	from iep 
	inner join #B on #B.bdgid=iep.bdgID 
	drop table #B
	

	
	drop table #B
end


	 
GO
