USE [Priamos_NET]
GO
/****** Object:  StoredProcedure [dbo].[CreateAHPB]    Script Date: 5/11/2023 7:21:17 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		John Mavroselinos
-- Create date: 16/11/2020
-- Description:	Δημιουργεί εγγραφές στις ώρες μετρήσεων για όσα είναι τα διαμερίσματα
-- =============================================
ALTER PROCEDURE [dbo].[CreateAHPB] (
@bdgid as uniqueidentifier,
@ahpbDT as datetime,
@boiler bit,
@modifiedBy as uniqueidentifier)
	
AS
BEGIN
	SET NOCOUNT ON;

declare @ahpbHID uniqueidentifier
set @ahpbHID  = newid()

if (select count(ID) from AHPB_H where bdgid=@bdgid and mdt=@ahpbDT and boiler=@boiler)=0
begin
	--Εισαγωγή Header πληροφορίας μετρήσεων
	insert into AHPB_H (id,bdgid,mdt,createdOn,boiler)
	select @ahpbHID ,@bdgid,@ahpbDT, getdate() ,@boiler
end

--Εισαγωγή Detail πληροφορίας μετρήσεων
insert into AHPB(aptid,mdt,boiler,bdgid,modifiedBy,createdon,ahpbHID,mes,mesDif,mesB  )
select id,@ahpbDT,@boiler,@bdgid,@modifiedBy,getdate(),@ahpbHID ,0,0,0  from apt where bdgID=@bdgid 

END


