USE [Priamos_NET]
GO
/****** Object:  StoredProcedure [dbo].[AddNewFormRights]    Script Date: 5/11/2023 7:11:13 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<John Mavroselinos>
-- Create date: 13/09/2022
-- Description:	Προσθέτει ενα όνομα φόρμας σε όλους τους χρήστες
-- =============================================
ALTER PROCEDURE [dbo].[AddNewFormRights]
	@FormName nvarchar(150)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	declare @ID uniqueidentifier
	
	
	select @ID=ID from forms where name=@FormName
	if @ID is null
	begin
		set @ID = newid()
		insert into forms( id,[name]) 	select @id,@FormName
	end

	insert into FORM_RIGHTS( [ID], [uID], [Fid], [view], [insert], [edit], [delete],  [createdOn]) 

	select newid(),id,@id,1,1,1,1,getdate()
	from usr
	where id not in(select fr.uID  
					from FORMS F
					inner join FORM_RIGHTS FR on FR.Fid = F.ID and FR.uID=usr.id
					where name=@FormName )
	
	
END
