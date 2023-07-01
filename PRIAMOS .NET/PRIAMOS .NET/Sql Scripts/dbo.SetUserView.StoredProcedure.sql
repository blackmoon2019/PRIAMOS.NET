USE [Priamos_NET]
GO
/****** Object:  StoredProcedure [dbo].[SetUserView]    Script Date: 27/6/2023 8:52:42 πμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: 12/08/2020
-- Description:	Καταγράφει το τελευταίο σχέδιο που χρησιμοποιήθηκε από τον Χρήστη
-- =============================================
CREATE PROCEDURE [dbo].[SetUserView]
	-- Add the parameters for the stored procedure here
	@sDataTable nvarchar(100),@ID uniqueidentifier,@CurrentView nvarchar(100)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    IF EXISTS (SELECT * FROM USR_V  WHERE usrID =@ID and DataTable=@sDataTable  )
	begin
		UPDATE USR_V  SET CurrentView=@CurrentView WHERE usrID =@ID and DataTable=@sDataTable  
	end
	else
	begin
		insert into USR_V  (usrID,DataTable,CurrentView) 
		select @ID,@sDataTable,@CurrentView 
	end
	
END
GO
